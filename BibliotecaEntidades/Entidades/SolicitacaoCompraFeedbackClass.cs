using System; 
using System.Collections.Generic; 
using System.Diagnostics;
using System.Globalization;
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
     public class SolicitacaoCompraFeedbackClass:SolicitacaoCompraFeedbackBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do SolicitacaoCompraFeedbackClass";
protected new const string ErroDelete = "Erro ao excluir o SolicitacaoCompraFeedbackClass  ";
protected new const string ErroSave = "Erro ao salvar o SolicitacaoCompraFeedbackClass.";
protected new const string ErroSolicitacaoCompraObrigatorio = "O campo SolicitacaoCompra é obrigatório";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do SolicitacaoCompraFeedbackClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade SolicitacaoCompraFeedbackClass está sendo utilizada.";
#endregion

        

        public SolicitacaoCompraFeedbackClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

  


        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
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
