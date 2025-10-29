using System; 
using System.Collections.Generic; 
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
     public class BudgetClass:BudgetBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do BudgetClass";
protected new const string ErroDelete = "Erro ao excluir o BudgetClass  ";
protected new const string ErroSave = "Erro ao salvar o BudgetClass.";
protected new const string ErroCollectionBudgetLinhaClassBudget = "Erro ao carregar a coleção de BudgetLinhaClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroAcsUsuarioCriadorObrigatorio = "O campo AcsUsuarioCriador é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do BudgetClass.";
protected new const string MensagemUtilizadoCollectionBudgetLinhaClassBudget =  "A entidade BudgetClass está sendo utilizada nos seguintes BudgetLinhaClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade BudgetClass está sendo utilizada.";
#endregion


        public BudgetClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
