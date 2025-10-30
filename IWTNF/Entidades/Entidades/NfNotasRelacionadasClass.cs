using System; 
using System.Collections.Generic; 
using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 

using IWTNF.Entidades.Base; 
namespace IWTNF.Entidades.Entidades 
{
    [Serializable()]
    public class NfNotasRelacionadasClass:NfNotasRelacionadasBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfNotasRelacionadasClass";
protected new const string ErroDelete = "Erro ao excluir o NfNotasRelacionadasClass  ";
protected new const string ErroSave = "Erro ao salvar o NfNotasRelacionadasClass.";
protected new const string ErroChaveObrigatorio = "O campo Chave é obrigatório";
protected new const string ErroChaveComprimento = "O campo Chave deve ter no máximo 44 caracteres";
protected new const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfNotasRelacionadasClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfNotasRelacionadasClass está sendo utilizada.";
#endregion

        


        public NfNotasRelacionadasClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        public override string ToString()
        {
           throw new NotImplementedException();
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
