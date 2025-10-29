using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class MilkrunHistoryClass:MilkrunHistoryBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MilkrunHistoryClass";
protected new const string ErroDelete = "Erro ao excluir o MilkrunHistoryClass  ";
protected new const string ErroSave = "Erro ao salvar o MilkrunHistoryClass.";
protected new const string ErroOrderNumberObrigatorio = "O campo OrderNumber é obrigatório";
protected new const string ErroOrderNumberComprimento = "O campo OrderNumber deve ter no máximo 30 caracteres";
protected new const string ErroMilkrunObrigatorio = "O campo Milkrun é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do MilkrunHistoryClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MilkrunHistoryClass está sendo utilizada.";
#endregion

     

        public MilkrunHistoryClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            return OrderNumber;
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
