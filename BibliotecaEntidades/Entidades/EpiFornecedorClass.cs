using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class EpiFornecedorClass : EpiFornecedorBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EpiFornecedorClass";
        protected new const string ErroDelete = "Erro ao excluir o EpiFornecedorClass  ";
        protected new const string ErroSave = "Erro ao salvar o EpiFornecedorClass.";
        protected new const string ErroEpiObrigatorio = "O campo Epi é obrigatório";
        protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EpiFornecedorClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EpiFornecedorClass está sendo utilizada.";

        #endregion


        public EpiFornecedorClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

     

        public override string ToString()
        {
            return this.Fornecedor.RazaoSocial;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }

        public void setUltimoPreco(double valorRecebido, double icmsRecebimento, double ipiRecebimento)
        {
            this.UltimoPreco = valorRecebido;
            this.Icms = icmsRecebimento;
            this.Ipi = ipiRecebimento;
        }

        public void LimparID()
        {
            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;
        }

        public static DateTime? GetDataUltimoRecebimento(EpiClass epi, FornecedorClass fornecedor, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            LoteClass ultimoLote = (LoteClass)new LoteClass(usuario, conn).Search(new List<SearchParameterClass>()
           {
               new SearchParameterClass("Epi", epi),
               new SearchParameterClass("Fornecedor", fornecedor),
               new SearchParameterClass("DataRecebimento", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Desc, TipoOrdenacao.Data)
           }, limit: 1).FirstOrDefault();


            return ultimoLote?.DataRecebimento;
        }

        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            long idEpiSimulador = Epi.ID + 30000000;
            long idEpiFornecedorSimulador = ID + 30000000;

            if (Ativo)
            {

                long idUnidadeMedida;
                double conversaoUnidade;
                double loteMinimo;
                double lotePadrao;
                if (UnidadeMedidaCompra != null)
                {
                    idUnidadeMedida = UnidadeMedidaCompra.ID;
                    conversaoUnidade = this.UnidadesPorUnCompra ?? 1;
                    loteMinimo = LoteMinimo ?? 1;
                    lotePadrao = LotePadrao ?? 1;
                }
                else
                {
                    if (Epi.UnidadeMedidaCompra != null)
                    {
                        idUnidadeMedida = Epi.UnidadeMedidaCompra.ID;
                        conversaoUnidade = Epi.UnidadesPorUnidadeCompra;
                        loteMinimo = Epi.LoteMinimo;
                        lotePadrao = Epi.LotePadrao;
                    }
                    else
                    {
                        idUnidadeMedida = Epi.UnidadeMedidaUso.ID;
                        conversaoUnidade = 1;
                        loteMinimo = 1;
                        lotePadrao = 1;
                    }
                }


                loteMinimo = loteMinimo * conversaoUnidade;
                lotePadrao = lotePadrao * conversaoUnidade;


                ProdutoFornecedorDto dto = new ProdutoFornecedorDto()
                {
                    id = idEpiFornecedorSimulador,
                    unidadeMedidaId = idUnidadeMedida,
                    produtoId = idEpiSimulador,
                    aliquotaIcms = Icms,
                    aliquotaIpi = Ipi,
                    conversaoUnidade = conversaoUnidade,
                    dataUltimaCompra = this.DataUltimaCompra,
                    dataUltimoRecebimento = GetDataUltimoRecebimento(Epi, Fornecedor, UsuarioAtual, command.Connection),
                    fornecedorId = Fornecedor.ID,
                    fornecedorPreferencial = Preferencial,
                    loteMinimo = loteMinimo,
                    lotePadrao = lotePadrao,
                    precoUnitario = Math.Round(UltimoPreco/conversaoUnidade,4,MidpointRounding.AwayFromZero)

                };

                ApiSimuladorCompras.SincronizarEpiFornecedor(dto.id, false, UsuarioAtual, command);
            }
            else
            {

                ApiSimuladorCompras.SincronizarEpiFornecedor(idEpiFornecedorSimulador, true, UsuarioAtual, command);
            }
        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            long idEpiFornecedorSimulador = ID + 30000000;
            ApiSimuladorCompras.SincronizarEpiFornecedor(idEpiFornecedorSimulador, true, UsuarioAtual, command);
        }

        public void SincronizarSDC(IWTPostgreNpgsqlConnection conn)
        {
            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            long idEpiSimulador = Epi.ID + 30000000;
            long idEpiFornecedorSimulador = ID + 30000000;

            if (Ativo)
            {

                long idUnidadeMedida;
                double conversaoUnidade;
                double loteMinimo;
                double lotePadrao;
                if (UnidadeMedidaCompra != null)
                {
                    idUnidadeMedida = UnidadeMedidaCompra.ID;
                    conversaoUnidade = this.UnidadesPorUnCompra ?? 1;
                    loteMinimo = LoteMinimo ?? 1;
                    lotePadrao = LotePadrao ?? 1;
                }
                else
                {
                    if (Epi.UnidadeMedidaCompra != null)
                    {
                        idUnidadeMedida = Epi.UnidadeMedidaCompra.ID;
                        conversaoUnidade = Epi.UnidadesPorUnidadeCompra;
                        loteMinimo = Epi.LoteMinimo;
                        lotePadrao = Epi.LotePadrao;
                    }
                    else
                    {
                        idUnidadeMedida = Epi.UnidadeMedidaUso.ID;
                        conversaoUnidade = 1;
                        loteMinimo = 1;
                        lotePadrao = 1;
                    }
                }

                loteMinimo = loteMinimo * conversaoUnidade;
                lotePadrao = lotePadrao * conversaoUnidade;

                ProdutoFornecedorDto dto = new ProdutoFornecedorDto()
                {
                    id = idEpiFornecedorSimulador,
                    unidadeMedidaId = idUnidadeMedida,
                    produtoId = idEpiSimulador,
                    aliquotaIcms = Icms,
                    aliquotaIpi = Ipi,
                    conversaoUnidade = conversaoUnidade,
                    dataUltimaCompra = this.DataUltimaCompra,
                    dataUltimoRecebimento = GetDataUltimoRecebimento(Epi, Fornecedor, UsuarioAtual, conn),
                    fornecedorId = Fornecedor.ID,
                    fornecedorPreferencial = Preferencial,
                    loteMinimo = loteMinimo,
                    lotePadrao = lotePadrao,
                    precoUnitario = Math.Round(UltimoPreco / conversaoUnidade, 4, MidpointRounding.AwayFromZero)

                };

                ApiSimuladorCompras.SincronizarEpiFornecedor(dto.id, false, UsuarioAtual, conn);
            }
            else
            {
                ApiSimuladorCompras.SincronizarEpiFornecedor(idEpiFornecedorSimulador, true, UsuarioAtual, conn);
            }
        }
    }
}
