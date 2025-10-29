using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class FormaPagamentoClass : FormaPagamentoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do FormaPagamentoClass";
        protected new const string ErroDelete = "Erro ao excluir o FormaPagamentoClass  ";
        protected new const string ErroSave = "Erro ao salvar o FormaPagamentoClass.";
        protected new const string ErroCollectionFornecedorClassFormaPagamento = "Erro ao carregar a coleção de FornecedorClass.";
        protected new const string ErroCollectionOrcamentoItemClassFormaPagamento = "Erro ao carregar a coleção de OrcamentoItemClass.";
        protected new const string ErroCollectionOrdemCompraClassFormaPagamento = "Erro ao carregar a coleção de OrdemCompraClass.";
        protected new const string ErroCollectionPedidoItemClassFormaPagamento = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroCollectionClienteClassFormaPagamento = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do FormaPagamentoClass.";
        protected new const string MensagemUtilizadoCollectionFornecedorClassFormaPagamento = "A entidade FormaPagamentoClass está sendo utilizada nos seguintes FornecedorClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemClassFormaPagamento = "A entidade FormaPagamentoClass está sendo utilizada nos seguintes OrcamentoItemClass:";
        protected new const string MensagemUtilizadoCollectionOrdemCompraClassFormaPagamento = "A entidade FormaPagamentoClass está sendo utilizada nos seguintes OrdemCompraClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassFormaPagamento = "A entidade FormaPagamentoClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassFormaPagamento = "A entidade FormaPagamentoClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade FormaPagamentoClass está sendo utilizada.";

        #endregion


        public FormaPagamentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
