using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class SolicitacaoCompraPedidoClass:SolicitacaoCompraPedidoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do SolicitacaoCompraPedidoClass";
protected new const string ErroDelete = "Erro ao excluir o SolicitacaoCompraPedidoClass  ";
protected new const string ErroSave = "Erro ao salvar o SolicitacaoCompraPedidoClass.";
protected new const string ErroSolicitacaoCompraObrigatorio = "O campo SolicitacaoCompra é obrigatório";
protected new const string ErroPedidoItemObrigatorio = "O campo PedidoItem é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do SolicitacaoCompraPedidoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade SolicitacaoCompraPedidoClass está sendo utilizada.";
#endregion

        

        public SolicitacaoCompraPedidoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


 
        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
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
