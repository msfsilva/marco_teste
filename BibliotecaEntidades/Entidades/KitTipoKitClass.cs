using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class KitTipoKitClass:KitTipoKitBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do KitTipoKitClass";
protected new const string ErroDelete = "Erro ao excluir o KitTipoKitClass  ";
protected new const string ErroSave = "Erro ao salvar o KitTipoKitClass.";
protected new const string ErroValidate = "Erro ao validar os dados do KitTipoKitClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade KitTipoKitClass está sendo utilizada.";
#endregion


        public KitTipoKitClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
