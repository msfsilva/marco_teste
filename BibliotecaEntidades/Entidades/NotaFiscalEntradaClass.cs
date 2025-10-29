using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class NotaFiscalEntradaClass : NotaFiscalEntradaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NotaFiscalEntradaClass";
        protected new const string ErroDelete = "Erro ao excluir o NotaFiscalEntradaClass  ";
        protected new const string ErroSave = "Erro ao salvar o NotaFiscalEntradaClass.";
        protected new const string ErroCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada = "Erro ao carregar a coleção de NotaFiscalEntradaLinhaClass.";
        protected new const string ErroCollectionContaPagarClassNotaFiscalEntrada = "Erro ao carregar a coleção de ContaPagarClass.";
        protected new const string ErroCnpjObrigatorio = "O campo Cnpj é obrigatório";
        protected new const string ErroCnpjComprimento = "O campo Cnpj deve ter no máximo 255 caracteres";
        protected new const string ErroRazaoFornecedorObrigatorio = "O campo RazaoFornecedor é obrigatório";
        protected new const string ErroRazaoFornecedorComprimento = "O campo RazaoFornecedor deve ter no máximo 255 caracteres";
        protected new const string ErroNumeroNfObrigatorio = "O campo NumeroNf é obrigatório";
        protected new const string ErroNumeroNfComprimento = "O campo NumeroNf deve ter no máximo 255 caracteres";
        protected new const string ErroSerieNfObrigatorio = "O campo SerieNf é obrigatório";
        protected new const string ErroSerieNfComprimento = "O campo SerieNf deve ter no máximo 255 caracteres";
        protected new const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NotaFiscalEntradaClass.";
        protected new const string MensagemUtilizadoCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada = "A entidade NotaFiscalEntradaClass está sendo utilizada nos seguintes NotaFiscalEntradaLinhaClass:";
        protected new const string MensagemUtilizadoCollectionContaPagarClassNotaFiscalEntrada = "A entidade NotaFiscalEntradaClass está sendo utilizada nos seguintes ContaPagarClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NotaFiscalEntradaClass está sendo utilizada.";

        #endregion



        public NotaFiscalEntradaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public bool TotalmenteRecebida
        {
            get { return CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.All(a => a.Vinculada); }
        }

        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
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

        public static NotaFiscalEntradaClass GetByChave(string chaveNf, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            NotaFiscalEntradaClass nfSearch = new NotaFiscalEntradaClass(usuario, conn);

            List<NotaFiscalEntradaClass> notasEncontradas = nfSearch.Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("ChaveNota", chaveNf)
            }).ConvertAll(a => (NotaFiscalEntradaClass) a);

            if (notasEncontradas.Count == 0)
            {
                return null;
            }

            if (notasEncontradas.Count > 1)
            {
                throw new ExcecaoTratada("Foram encontradas diversas notas com a chave " + chaveNf + " entre em contato com a equipe IWT");
            }

            return notasEncontradas[0];
        }


        public static NotaFiscalEntradaClass GetByFornecedorNumero(string cnpjFornecedor, string serie, string numero, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            NotaFiscalEntradaClass nfSearch = new NotaFiscalEntradaClass(usuario, conn);

            List<NotaFiscalEntradaClass> notasEncontradas = nfSearch.Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("CnpjExato", cnpjFornecedor),
                new SearchParameterClass("SerieNfExato", serie),
                new SearchParameterClass("NumeroNfExato", numero),
            }).ConvertAll(a => (NotaFiscalEntradaClass) a);

            if (notasEncontradas.Count == 0)
            {
                return null;
            }

            if (notasEncontradas.Count > 1)
            {
                throw new ExcecaoTratada("Foram encontradas diversas notas com os dados informados entre em contato com a equipe IWT");
            }

            return notasEncontradas[0];
        }

        public static void ReceberServicoExternoAutomatico(string chaveNfe, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {

            NotaFiscalEntradaClass nfEntrada = NotaFiscalEntradaClass.GetByChave(chaveNfe, usuario, conn);
            if (nfEntrada == null)
            {
                throw new ExcecaoTratada("Não foi encontrada nota fiscal importada com a chave " + chaveNfe);
            }

            if (nfEntrada.TotalmenteRecebida)
            {
                throw new ExcecaoTratada("A nota fiscal já foi recebida totalmente");
            }

            List<NotaFiscalEntradaLinhaClass> linhasSemVinculo = nfEntrada.CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Where(a => !a.Vinculada).ToList();

            if (linhasSemVinculo.Any(a => string.IsNullOrEmpty(a.Xped) || a.Posicao == null))
            {
                throw new ExcecaoTratada("Não é possível fazer o recebimento automático dessa nota fiscal pois existem itens na nota sem a indicação de Pedido e/ou Posiçao do Pedido do Cliente");
            }

            if (linhasSemVinculo.Any(a => !a.Xped.ToUpperInvariant().StartsWith("OPET") || a.Posicao != 1))
            {
                throw new ExcecaoTratada("Não é possível fazer o recebimento automático dessa nota fiscal pois existem itens na nota com a indicação de Pedido e/ou Posiçao do Pedido do Cliente inválidos");
            }

          

            IWTPostgreNpgsqlCommand command = null;
            try
            {

                command = conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                foreach (NotaFiscalEntradaLinhaClass linha in linhasSemVinculo)
                {
                    long idEnvio;
                    if (!long.TryParse(linha.Xped.Substring(4), out idEnvio))
                    {
                        throw new ExcecaoTratada("Impossível realizar o recebimento automático da nfe, número do envio da Ordem de Produção inválido na linha " + linha.Linha);
                    }

                    OrdemProducaoEnvioTerceirosClass envio = OrdemProducaoEnvioTerceirosClass.GetEntidade(idEnvio, usuario, conn);
                    if (envio == null)
                    {
                        throw new ExcecaoTratada("Não foi possivel encontrar envio de Ordem de Produção com número: " + linha.Xped + "/" + linha.Posicao);
                    }

                    if (envio.TotalmenteRecebido)
                    {
                        throw new ExcecaoTratada("O envio de Ordem de Produção com número: " + linha.Xped + "/" + linha.Posicao + " já foi totalmente recebido anteriormente");
                    }

                    if (envio.Fornecedor != nfEntrada.Fornecedor)
                    {
                        throw new ExcecaoTratada("O fornecedor identificado para a nota fiscal não corresponde ao fornecedor do envio");
                    }

                    if (Math.Abs(envio.SaldoRecebimento - linha.Quantidade) > 0.00001)
                    {
                        throw new ExcecaoTratada("O Saldo de recebimento do envio de Ordem de Produção com número: " + linha.Xped + "/" + linha.Posicao + " é diferente da quantidade da linha da nota fiscal");
                    }

                    
                    OrdemProducaoEnvioTerceirosRecebimentoClass receb = new OrdemProducaoEnvioTerceirosRecebimentoClass(LoginClass.UsuarioLogado.loggedUser, conn)
                    {
                        Quantidade = linha.Quantidade,
                        OrdemProducaoEnvioTerceiros = envio,
                        AcsUsuarioRecebimento = LoginClass.UsuarioLogado.loggedUser,
                        DataRecebimento = DataIndependenteClass.GetData(),
                        NotaFiscalEntradaLinha = linha
                    };

                    receb.Save(ref command);

                    envio.CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Add(receb);

                    envio.VerificaEncerramentoRecebimento(ref command);


                    linha.Vinculada = true;
                    linha.Save(ref command);

                }

                command.Transaction.Commit();


            }
            catch
            {
                command?.Transaction?.Rollback();
                throw;
            }
        }
    }
}
