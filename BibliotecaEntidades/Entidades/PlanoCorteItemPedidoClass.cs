using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PlanoCorteItemPedidoClass:PlanoCorteItemPedidoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PlanoCorteItemPedidoClass";
protected new const string ErroDelete = "Erro ao excluir o PlanoCorteItemPedidoClass  ";
protected new const string ErroSave = "Erro ao salvar o PlanoCorteItemPedidoClass.";
protected new const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
protected new const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
protected new const string ErroPedidoNumeroObrigatorio = "O campo PedidoNumero é obrigatório";
protected new const string ErroPedidoNumeroComprimento = "O campo PedidoNumero deve ter no máximo 255 caracteres";
protected new const string ErroPedidoClienteObrigatorio = "O campo PedidoCliente é obrigatório";
protected new const string ErroPedidoClienteComprimento = "O campo PedidoCliente deve ter no máximo 255 caracteres";
protected new const string ErroPlanoCorteItemObrigatorio = "O campo PlanoCorteItem é obrigatório";
protected new const string ErroOrderItemEtiquetaObrigatorio = "O campo OrderItemEtiqueta é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do PlanoCorteItemPedidoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PlanoCorteItemPedidoClass está sendo utilizada.";
#endregion

        

        public PlanoCorteItemPedidoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
    }
}
