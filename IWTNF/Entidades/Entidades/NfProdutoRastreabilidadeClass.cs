using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using IWTNF.Entidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNF.Entidades.Entidades 
{ 
    [Serializable()]
     public class NfProdutoRastreabilidadeClass:NfProdutoRastreabilidadeBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfProdutoRastreabilidadeClass";
protected new const string ErroDelete = "Erro ao excluir o NfProdutoRastreabilidadeClass  ";
protected new const string ErroSave = "Erro ao salvar o NfProdutoRastreabilidadeClass.";
protected new const string ErroNumeroLoteObrigatorio = "O campo NumeroLote é obrigatório";
protected new const string ErroNumeroLoteComprimento = "O campo NumeroLote deve ter no máximo 20 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroNfProdutoObrigatorio = "O campo NfProduto é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfProdutoRastreabilidadeClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoRastreabilidadeClass está sendo utilizada.";
#endregion
        public NfProdutoRastreabilidadeClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
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
         protected override bool ValidateDataCustom(ref  IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
        protected override void InternalSaveCustom(ref  IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public void LimparId()
        {
            this.ID = -1;
        }
    }
}
