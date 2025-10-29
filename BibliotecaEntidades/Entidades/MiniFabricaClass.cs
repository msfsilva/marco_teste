using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class MiniFabricaClass:MiniFabricaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MiniFabricaClass";
protected new const string ErroDelete = "Erro ao excluir o MiniFabricaClass  ";
protected new const string ErroSave = "Erro ao salvar o MiniFabricaClass.";
protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 20 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do MiniFabricaClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MiniFabricaClass está sendo utilizada.";
#endregion

        
        public MiniFabricaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
