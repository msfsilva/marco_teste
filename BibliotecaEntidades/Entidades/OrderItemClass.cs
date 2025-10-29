using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrderItemClass:OrderItemBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrderItemClass";
protected new const string ErroDelete = "Erro ao excluir o OrderItemClass  ";
protected new const string ErroSave = "Erro ao salvar o OrderItemClass.";
protected new const string ErroOrderNumberObrigatorio = "O campo OrderNumber é obrigatório";
protected new const string ErroOrderNumberComprimento = "O campo OrderNumber deve ter no máximo 30 caracteres";
protected new const string ErroBuyerItemCodeObrigatorio = "O campo BuyerItemCode é obrigatório";
protected new const string ErroBuyerItemCodeComprimento = "O campo BuyerItemCode deve ter no máximo 50 caracteres";
protected new const string ErroStatusObrigatorio = "O campo Status é obrigatório";
protected new const string ErroStatusComprimento = "O campo Status deve ter no máximo 10 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do OrderItemClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrderItemClass está sendo utilizada.";
#endregion


        public OrderItemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
                case "OrderNumberExato":
                    whereClause += " AND (order_number = :order_number_exato) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_number_exato", NpgsqlDbType.Varchar, parametro.Fieldvalue));
                    return true;
                default:
                    return false;
            }
        }
    }
}
