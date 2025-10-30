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

using IWTNFCompleto.BibliotecaEntidades.Base; 
namespace IWTNFCompleto.BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class NfeCompletoCartaCorrecaoClass:NfeCompletoCartaCorrecaoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfeCompletoCartaCorrecaoClass";
protected new const string ErroDelete = "Erro ao excluir o NfeCompletoCartaCorrecaoClass  ";
protected new const string ErroSave = "Erro ao salvar o NfeCompletoCartaCorrecaoClass.";
protected new const string ErroTextoObrigatorio = "O campo Texto é obrigatório";
protected new const string ErroTextoComprimento = "O campo Texto deve ter no máximo 1000 caracteres";
protected new const string ErroNfeCompletoNotaObrigatorio = "O campo NfeCompletoNota é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfeCompletoCartaCorrecaoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletoCartaCorrecaoClass está sendo utilizada.";
#endregion



        public NfeCompletoCartaCorrecaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        protected override void InitClass()
        {
            ControleRevisaoHabilitado = false;
        }
       public override string ToString()
       {
           return this.NfeCompletoNota.Chave;
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
             try
             {
                 if (string.IsNullOrEmpty(Texto))
                 {
                     throw new Exception(ErroTextoObrigatorio);
                 }
                 if (Texto.Length > 1000)
                 {
                     throw new Exception(ErroTextoComprimento);
                 }
                 if (NfeCompletoNota == null)
                 {
                     throw new Exception(ErroNfeCompletoNotaObrigatorio);
                 }

                 return true;
             }
             catch (Exception e)
             {
                 throw new Exception(ErroValidate + "\r\n" + e.Message, e);
             }
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
    }
}
