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
     public class LocalDesembaracoAduaneiroClass:LocalDesembaracoAduaneiroBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do LocalDesembaracoAduaneiroClass";
protected new const string ErroDelete = "Erro ao excluir o LocalDesembaracoAduaneiroClass  ";
protected new const string ErroSave = "Erro ao salvar o LocalDesembaracoAduaneiroClass.";
protected new const string ErroCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro = "Erro ao carregar a coleção de DeclaracaoImportacaoClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroEstadoObrigatorio = "O campo Estado é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do LocalDesembaracoAduaneiroClass.";
protected new const string MensagemUtilizadoCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro =  "A entidade LocalDesembaracoAduaneiroClass está sendo utilizada nos seguintes DeclaracaoImportacaoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade LocalDesembaracoAduaneiroClass está sendo utilizada.";
#endregion
        public LocalDesembaracoAduaneiroClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
           return this.Identificacao.ToString();
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
