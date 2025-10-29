using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.SDC.Auxiliares;
using BibliotecaEntidades.SDC.dto;
using BibliotecaEntidades.SDC.excecoes;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BibliotecaEntidades.SDC
{

    public static class ApiSimuladorCompras
    {
        private enum SDCTipoOperacao
        {
            Criar,
            Atualizar,
            Excluir
        }

        private static string _baseUrl;
        private static bool _habilitado;
        private static string _user;
        private static string _senha;
        private static string _token;

        private const int LimiteMaximoTentativas = 5;

        public static void Init(string baseUrl, bool habilitado, string user, string senha, string token)
        {
            _baseUrl = baseUrl;
            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new Exception("Base URL Vazia");
            }
            else
            {
                Http.BaseAddress = _baseUrl;

                _habilitado = habilitado;
                _user = user;
                _senha = senha;
                _token = token;

                if (string.IsNullOrWhiteSpace(_token) && _habilitado)
                {
                    GerarTokemAofazerLogin();
                }
            }
        }

        private static void GerarTokemAofazerLogin()
        {
            try
            {
                LoginUserDto loginUserDto = new LoginUserDto();
                loginUserDto.username = _user;
                loginUserDto.password = _senha;

                string response = Http.DoPost(_baseUrl + "/acs-usuario/login", loginUserDto);


                TokenResponseDto tokenResponseDto = (TokenResponseDto) JsonConvert.DeserializeObject<TokenResponseDto>(response);
                if (tokenResponseDto != null && tokenResponseDto.token != null)
                {
                    _token = tokenResponseDto.token;
                }
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao realizar o login do SDC: " + e.Message);
            }
        }

        private static void EnfileirarOperacao(AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command, string tipoEntidade, string tipoOperacao, long entidadeId)
        {
            // Se o ID for -1, significa que a entidade é nova e ainda não foi persistida.
            // A sincronização dela ocorrerá no fluxo de 'CRIAR' após o ID ser gerado.
            if (entidadeId == -1 && tipoOperacao != "CRIAR")
            {
                return;
            }

            try
            {
                // O payload agora é um JSON simples contendo apenas o ID da entidade no EASI.
                string payload = "{\"id\":" + entidadeId + "}";

                var sincronizacao = new SincronizacaoSdcClass(usuario, command.Connection)
                {
                    TipoEntidade = tipoEntidade,
                    TipoOperacao = tipoOperacao,
                    DadosPayload = payload,
                    Status = "PENDENTE"
                };
                sincronizacao.Save(ref command, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao enfileirar operação de sincronização para o SDC: " + e.Message);
            }
        }

        private static void EnfileirarOperacao(AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection connection, string tipoEntidade, string tipoOperacao, long entidadeId)
        {
            IWTPostgreNpgsqlCommand command = connection.CreateCommand();
            command.Transaction = connection.GetActiveTransaction();
            EnfileirarOperacao(usuario, command, tipoEntidade, tipoOperacao, entidadeId);
        }

        #region FunçõesPadrão

        private static void CriarAtualizarExcluir(ISimuladorDto dto, string url, string nomeEntidade, SDCTipoOperacao tipoOperacao, int tentativas = 0)
        {
            ICollection<ValidationResult> results;
            if (!ISimuladorDto.Validate(dto, out results))
            {
                string error = "A entidade " + nomeEntidade + " (" + dto.ToString() + ") não atende todos os critérios do SDC. "+Environment.NewLine;
                foreach (ValidationResult result in results)
                {
                    error += '\t' + result.ErrorMessage + Environment.NewLine;
                }
                throw new ExcecaoTratada(error);
            }
            string textoOperacao;
            switch (tipoOperacao)
            {
                case SDCTipoOperacao.Criar:
                    textoOperacao = "criação";
                    break;
                case SDCTipoOperacao.Atualizar:
                    textoOperacao = "atualização";
                    break;
                case SDCTipoOperacao.Excluir:
                    textoOperacao = "exclusão";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoOperacao), tipoOperacao, null);
            }

            try
            {
                if (_habilitado && tentativas <= LimiteMaximoTentativas)
                {
                    string response = Http.DoPost(_baseUrl + url, dto, _token);
                }
            }
            catch (ServerErrorException e)
            {

                if (e.error.errorCode != HttpStatusCode.Unauthorized)
                {
                    throw new ExcecaoTratada("Erro inesperado ao comunicar a " + textoOperacao + " de um registro de " + nomeEntidade + " para o simulador de compras.", e);
                }

                GerarTokemAofazerLogin();
                int tentativasCount = tentativas + 1;
                CriarAtualizarExcluir(dto, url, nomeEntidade, tipoOperacao, tentativasCount);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao comunicar a " + textoOperacao + " de um registro de " + nomeEntidade + " para o simulador de compras.", e);
            }

        }

        #endregion


        #region Unidade de Medida (Novos e Antigos)

        // --- Nova Abordagem (ID) ---
        public static void SincronizarUnidadeMedida(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "UNIDADE_MEDIDA", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarUnidadeMedida(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "UNIDADE_MEDIDA", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }

        // --- Assinaturas Antigas (DTOs) para Compatibilidade ---
        [Obsolete("Use SincronizarUnidadeMedida(id, isDelete, ...) para enfileirar a operação.")]
        public static void CriarUnidadeMedida(AcsUsuarioClass u, IWTPostgreNpgsqlCommand c, UnidadeMedidaDto dto) { EnfileirarOperacao(u, c, "UNIDADE_MEDIDA", "CRIAR", dto.id); }
        [Obsolete("Use SincronizarUnidadeMedida(id, isDelete, ...) para enfileirar a operação.")]
        public static void CriarUnidadeMedida(AcsUsuarioClass u, IWTPostgreNpgsqlConnection c, UnidadeMedidaDto dto) { EnfileirarOperacao(u, c, "UNIDADE_MEDIDA", "CRIAR", dto.id); }
        [Obsolete("Use SincronizarUnidadeMedida(id, isDelete, ...) para enfileirar a operação.")]
        public static void AtualizarUnidadeMedida(AcsUsuarioClass u, IWTPostgreNpgsqlCommand c, UnidadeMedidaDto dto) { EnfileirarOperacao(u, c, "UNIDADE_MEDIDA", "ATUALIZAR", dto.id); }
        [Obsolete("Use SincronizarUnidadeMedida(id, isDelete, ...) para enfileirar a operação.")]
        public static void AtualizarUnidadeMedida(AcsUsuarioClass u, IWTPostgreNpgsqlConnection c, UnidadeMedidaDto dto) { EnfileirarOperacao(u, c, "UNIDADE_MEDIDA", "ATUALIZAR", dto.id); }
        [Obsolete("Use SincronizarUnidadeMedida(id, isDelete, ...) para enfileirar a operação.")]
        public static void ExcluirUnidadeMedida(AcsUsuarioClass u, IWTPostgreNpgsqlCommand c, ExcluirDto dto) { foreach (var id in dto.ids) EnfileirarOperacao(u, c, "UNIDADE_MEDIDA", "EXCLUIR", id); }
        [Obsolete("Use SincronizarUnidadeMedida(id, isDelete, ...) para enfileirar a operação.")]
        public static void ExcluirUnidadeMedida(AcsUsuarioClass u, IWTPostgreNpgsqlConnection c, ExcluirDto dto) { foreach (var id in dto.ids) EnfileirarOperacao(u, c, "UNIDADE_MEDIDA", "EXCLUIR", id); }

        #endregion

        #region Fornecedor (Novos e Antigos)

        // --- Nova Abordagem (ID) ---
        public static void SincronizarFornecedor(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "FORNECEDOR", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarFornecedor(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "FORNECEDOR", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }

        // --- Assinaturas Antigas (DTOs) para Compatibilidade ---
        [Obsolete("Use SincronizarFornecedor(id, isDelete, ...) para enfileirar a operação.")]
        public static void CriarFornecedor(AcsUsuarioClass u, IWTPostgreNpgsqlCommand c, FornecedorDto dto) { EnfileirarOperacao(u, c, "FORNECEDOR", "CRIAR", dto.id); }
        [Obsolete("Use SincronizarFornecedor(id, isDelete, ...) para enfileirar a operação.")]
        public static void CriarFornecedor(AcsUsuarioClass u, IWTPostgreNpgsqlConnection c, FornecedorDto dto) { EnfileirarOperacao(u, c, "FORNECEDOR", "CRIAR", dto.id); }
        [Obsolete("Use SincronizarFornecedor(id, isDelete, ...) para enfileirar a operação.")]
        public static void AtualizarFornecedor(AcsUsuarioClass u, IWTPostgreNpgsqlCommand c, FornecedorDto dto) { EnfileirarOperacao(u, c, "FORNECEDOR", "ATUALIZAR", dto.id); }
        [Obsolete("Use SincronizarFornecedor(id, isDelete, ...) para enfileirar a operação.")]
        public static void AtualizarFornecedor(AcsUsuarioClass u, IWTPostgreNpgsqlConnection c, FornecedorDto dto) { EnfileirarOperacao(u, c, "FORNECEDOR", "ATUALIZAR", dto.id); }
        [Obsolete("Use SincronizarFornecedor(id, isDelete, ...) para enfileirar a operação.")]
        public static void ExcluirFornecedor(AcsUsuarioClass u, IWTPostgreNpgsqlCommand c, ExcluirDto dto) { foreach (var id in dto.ids) EnfileirarOperacao(u, c, "FORNECEDOR", "EXCLUIR", id); }
        [Obsolete("Use SincronizarFornecedor(id, isDelete, ...) para enfileirar a operação.")]
        public static void ExcluirFornecedor(AcsUsuarioClass u, IWTPostgreNpgsqlConnection c, ExcluirDto dto) { foreach (var id in dto.ids) EnfileirarOperacao(u, c, "FORNECEDOR", "EXCLUIR", id); }

        #endregion

        #region Produto/Material/EPI (Novos e Antigos)

        // --- Nova Abordagem (ID) ---
        public static void SincronizarProduto(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "PRODUTO", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarProduto(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "PRODUTO", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarMaterial(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "MATERIAL", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarMaterial(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "MATERIAL", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarEpi(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "EPI", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarEpi(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "EPI", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }

        #endregion

        #region Produto/Material/EPI Fornecedor (Vínculo - Novos e Antigos)

        // --- Nova Abordagem (ID) ---
        public static void SincronizarProdutoFornecedor(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "PRODUTO_FORNECEDOR", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarProdutoFornecedor(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "PRODUTO_FORNECEDOR", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarMaterialFornecedor(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "MATERIAL_FORNECEDOR", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarMaterialFornecedor(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "MATERIAL_FORNECEDOR", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }

        public static void SincronizarEpiFornecedor(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "EPI_FORNECEDOR", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }
        public static void SincronizarEpiFornecedor(long id, bool isDelete, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "EPI_FORNECEDOR", isDelete ? "EXCLUIR" : "ATUALIZAR", id);
        }

        #endregion

        #region Solicitacao de Compra (Novos e Antigos)

        // --- Nova Abordagem (ID) ---
        public static void SincronizarSolicitacaoCompra(long id, string operacao, AcsUsuarioClass u, IWTPostgreNpgsqlCommand c)
        {
            EnfileirarOperacao(u, c, "SOLICITACAO_COMPRA", operacao, id);
        }
        public static void SincronizarSolicitacaoCompra(long id, string operacao, AcsUsuarioClass u, IWTPostgreNpgsqlConnection c)
        {
            EnfileirarOperacao(u, c, "SOLICITACAO_COMPRA", operacao, id);
        }



       
        #endregion


        #region Solicitacao de Compra - Leitura

        public static DadosScOnAlterarStatusDto BuscarDadosOnAlterarStatusSC(long solicitacaoId, int tentativas = 0)
        {
            return GetDadosOnAlterarStatusSC(solicitacaoId, "/solicitacao-compra/get-dados-on-alterar-status", "solicitacao de compra", tentativas);
        }

        private static DadosScOnAlterarStatusDto GetDadosOnAlterarStatusSC(long solicitacaoId, string url, string nomeEntidade, int tentativas = 0)
        {
            try
            {
                DadosScOnAlterarStatusDto dadosScOnAlterarStatus = new DadosScOnAlterarStatusDto();

                if (_habilitado && tentativas <= LimiteMaximoTentativas)
                {
                    Dictionary<string, string> parametros = new Dictionary<string, string>();
                    parametros.Add("solicitacaoId", solicitacaoId.ToString());

                    string response = Http.DoGet(_baseUrl + url, parametros, _token);

                    dadosScOnAlterarStatus = JsonConvert.DeserializeObject<DadosScOnAlterarStatusDto>(response);
                }

                return dadosScOnAlterarStatus;
            }
            catch (ServerErrorException e)
            {

                if (e.error.errorCode != HttpStatusCode.Unauthorized)
                {
                    throw new ExcecaoTratada("Erro inesperado ao comunicar a busca de dados da solicitação de compras para o simulador de compras.", e);
                }

                GerarTokemAofazerLogin();
                int tentativasCount = tentativas + 1;
                return BuscarDadosOnAlterarStatusSC(solicitacaoId, tentativasCount);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao comunicar a busca de dados da solicitação de compras para o simulador de compras", e);
            }
        }
        #endregion

        #region Ordem de Compra

        public static OrdemCompraSaidaDto GetOrdensCompraPendentes( int tentativas = 0)
        {
            string url = "/ordem-compra/get-pendecias";


            try
            {
                if (_habilitado && tentativas <= LimiteMaximoTentativas)
                {
                    string response = Http.DoGet(_baseUrl + url, _token);

                    return JsonConvert.DeserializeObject<OrdemCompraSaidaDto>(response);
                }
   
            }
            catch (ServerErrorException e)
            {

                if (e.error.errorCode != HttpStatusCode.Unauthorized)
                {
                    throw new ExcecaoTratada("Erro inesperado ao carregar as ocs criadas no simulador de compras.", e);
                }

                GerarTokemAofazerLogin();
                int tentativasCount = tentativas + 1;
                return GetOrdensCompraPendentes(tentativasCount);
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar as ocs criadas no simulador de compras.", e);
            }

            return new OrdemCompraSaidaDto();

        }

        public static void ConsumirOrdemCompra(ConsumirOrdemCompraDto dto)
        {
            CriarAtualizarExcluir(dto, "/ordem-compra/consumir-ordem-compra", "Ordem de Compra", SDCTipoOperacao.Atualizar);
        }

        #endregion
    }

}
