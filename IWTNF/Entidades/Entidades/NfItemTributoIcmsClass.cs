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
    public class NfItemTributoIcmsClass:NfItemTributoIcmsBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfItemTributoIcmsClass";
protected new const string ErroDelete = "Erro ao excluir o NfItemTributoIcmsClass  ";
protected new const string ErroSave = "Erro ao salvar o NfItemTributoIcmsClass.";
protected new const string ErroCstObrigatorio = "O campo Cst é obrigatório";
protected new const string ErroCstComprimento = "O campo Cst deve ter no máximo 3 caracteres";
protected new const string ErroCodigoAntecipacaoStObrigatorio = "O campo CodigoAntecipacaoSt é obrigatório";
protected new const string ErroCodigoAntecipacaoStComprimento = "O campo CodigoAntecipacaoSt deve ter no máximo 1 caracteres";
protected new const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected new const string ErroNfItemTributoObrigatorio = "O campo NfItemTributo é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfItemTributoIcmsClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfItemTributoIcmsClass está sendo utilizada.";
#endregion

        public NfItemTributoIcmsClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
