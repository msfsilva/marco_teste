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
    public class NfProdutoIimpClass:NfProdutoIimpBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfProdutoIimpClass";
protected new const string ErroDelete = "Erro ao excluir o NfProdutoIimpClass  ";
protected new const string ErroSave = "Erro ao salvar o NfProdutoIimpClass.";
protected new const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected new const string ErroNfProdutoObrigatorio = "O campo NfProduto é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfProdutoIimpClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoIimpClass está sendo utilizada.";
#endregion

        public NfProdutoIimpClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
