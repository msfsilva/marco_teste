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
    public class NfDuplicataClass:NfDuplicataBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfDuplicataClass";
protected new const string ErroDelete = "Erro ao excluir o NfDuplicataClass  ";
protected new const string ErroSave = "Erro ao salvar o NfDuplicataClass.";
protected new const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected new const string ErroNfCobrancaObrigatorio = "O campo NfCobranca é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfDuplicataClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfDuplicataClass está sendo utilizada.";
#endregion

        

 
        public NfDuplicataClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
