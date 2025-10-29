using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ConferenciaCncClass:ConferenciaCncBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ConferenciaCncClass";
protected new const string ErroDelete = "Erro ao excluir o ConferenciaCncClass  ";
protected new const string ErroSave = "Erro ao salvar o ConferenciaCncClass.";
protected new const string ErroValidate = "Erro ao validar os dados do ConferenciaCncClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ConferenciaCncClass está sendo utilizada.";
#endregion


        public ConferenciaCncClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
