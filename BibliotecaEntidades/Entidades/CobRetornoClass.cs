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
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class CobRetornoClass:CobRetornoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do CobRetornoClass";
protected new const string ErroDelete = "Erro ao excluir o CobRetornoClass  ";
protected new const string ErroSave = "Erro ao salvar o CobRetornoClass.";
protected new const string ErroCollectionCobBoletoRetornoClassCobRetorno = "Erro ao carregar a coleção de CobBoletoRetornoClass.";
protected new const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected new const string ErroNomeArquivoComprimento = "O campo NomeArquivo deve ter no máximo 255 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do CobRetornoClass.";
protected new const string MensagemUtilizadoCollectionCobBoletoRetornoClassCobRetorno =  "A entidade CobRetornoClass está sendo utilizada nos seguintes CobBoletoRetornoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade CobRetornoClass está sendo utilizada.";
#endregion
        public CobRetornoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
           return this.NomeArquivo.ToString();
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
    }
}
