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
    public class NfItemTributoIimpClass:NfItemTributoIimpBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfItemTributoIimpClass";
protected new const string ErroDelete = "Erro ao excluir o NfItemTributoIimpClass  ";
protected new const string ErroSave = "Erro ao salvar o NfItemTributoIimpClass.";
protected new const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected new const string ErroNfItemTributoObrigatorio = "O campo NfItemTributo é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfItemTributoIimpClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfItemTributoIimpClass está sendo utilizada.";
#endregion

        

        public NfItemTributoIimpClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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

        public void LimparId()
        {
            this.ID = -1;
        }
    }
}
