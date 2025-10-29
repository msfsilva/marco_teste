using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class ContaBancariaClass : ContaBancariaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ContaBancariaClass";
        protected new const string ErroDelete = "Erro ao excluir o ContaBancariaClass  ";
        protected new const string ErroSave = "Erro ao salvar o ContaBancariaClass.";
        protected new const string ErroCollectionConciliacaoBancariaClassContaBancaria = "Erro ao carregar a coleção de ConciliacaoBancariaClass.";
        protected new const string ErroCollectionContaRecorrenteClassContaBancaria = "Erro ao carregar a coleção de ContaRecorrenteClass.";
        protected new const string ErroCollectionFornecedorClassContaBancaria = "Erro ao carregar a coleção de FornecedorClass.";
        protected new const string ErroCollectionOrcamentoItemClassContaBancaria = "Erro ao carregar a coleção de OrcamentoItemClass.";
        protected new const string ErroCollectionPedidoItemClassContaBancaria = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroCollectionRepresentanteComissaoClassContaBancaria = "Erro ao carregar a coleção de RepresentanteComissaoClass.";
        protected new const string ErroCollectionTransferenciaBancariaClassContaBancariaOrigem = "Erro ao carregar a coleção de TransferenciaBancariaClass.";
        protected new const string ErroCollectionTransferenciaBancariaClassContaBancariaDestino = "Erro ao carregar a coleção de TransferenciaBancariaClass.";
        protected new const string ErroCollectionContaReceberClassContaBancaria = "Erro ao carregar a coleção de ContaReceberClass.";
        protected new const string ErroCollectionRepresentanteClassContaBancaria = "Erro ao carregar a coleção de RepresentanteClass.";
        protected new const string ErroCollectionClienteClassContaBancaria = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroCollectionContaPagarClassContaBancaria = "Erro ao carregar a coleção de ContaPagarClass.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do ContaBancariaClass.";
        protected new const string MensagemUtilizadoCollectionConciliacaoBancariaClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes ConciliacaoBancariaClass:";
        protected new const string MensagemUtilizadoCollectionContaRecorrenteClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
        protected new const string MensagemUtilizadoCollectionFornecedorClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes FornecedorClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes OrcamentoItemClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string MensagemUtilizadoCollectionRepresentanteComissaoClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes RepresentanteComissaoClass:";
        protected new const string MensagemUtilizadoCollectionTransferenciaBancariaClassContaBancariaOrigem = "A entidade ContaBancariaClass está sendo utilizada nos seguintes TransferenciaBancariaClass:";
        protected new const string MensagemUtilizadoCollectionTransferenciaBancariaClassContaBancariaDestino = "A entidade ContaBancariaClass está sendo utilizada nos seguintes TransferenciaBancariaClass:";
        protected new const string MensagemUtilizadoCollectionContaReceberClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes ContaReceberClass:";
        protected new const string MensagemUtilizadoCollectionRepresentanteClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes RepresentanteClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string MensagemUtilizadoCollectionContaPagarClassContaBancaria = "A entidade ContaBancariaClass está sendo utilizada nos seguintes ContaPagarClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ContaBancariaClass está sendo utilizada.";

        #endregion


        public ContaBancariaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

 

        public override string ToString()
        {
            return this.Identificacao;
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
    }
}
