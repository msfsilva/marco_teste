using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrderItemEtiquetaConferenciaNfClass:OrderItemEtiquetaConferenciaNfBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrderItemEtiquetaConferenciaNfClass";
protected new const string ErroDelete = "Erro ao excluir o OrderItemEtiquetaConferenciaNfClass  ";
protected new const string ErroSave = "Erro ao salvar o OrderItemEtiquetaConferenciaNfClass.";
protected new const string ErroOrderNumberObrigatorio = "O campo OrderNumber é obrigatório";
protected new const string ErroOrderNumberComprimento = "O campo OrderNumber deve ter no máximo 30 caracteres";
protected new const string ErroIdentificacaoEstacaoObrigatorio = "O campo IdentificacaoEstacao é obrigatório";
protected new const string ErroIdentificacaoEstacaoComprimento = "O campo IdentificacaoEstacao deve ter no máximo 255 caracteres";
protected new const string ErroIdentificacaoUsuarioObrigatorio = "O campo IdentificacaoUsuario é obrigatório";
protected new const string ErroIdentificacaoUsuarioComprimento = "O campo IdentificacaoUsuario deve ter no máximo 255 caracteres";
protected new const string ErroOrderItemEtiquetaObrigatorio = "O campo OrderItemEtiqueta é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrderItemEtiquetaConferenciaNfClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrderItemEtiquetaConferenciaNfClass está sendo utilizada.";
#endregion


        public OrderItemEtiquetaConferenciaNfClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
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
    }
}
