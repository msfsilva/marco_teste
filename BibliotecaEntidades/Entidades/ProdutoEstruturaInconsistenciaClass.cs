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
     public class ProdutoEstruturaInconsistenciaClass:ProdutoEstruturaInconsistenciaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoEstruturaInconsistenciaClass";
protected new const string ErroDelete = "Erro ao excluir o ProdutoEstruturaInconsistenciaClass  ";
protected new const string ErroSave = "Erro ao salvar o ProdutoEstruturaInconsistenciaClass.";
protected new const string ErroDadosObrigatorio = "O campo Dados é obrigatório";
protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do ProdutoEstruturaInconsistenciaClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoEstruturaInconsistenciaClass está sendo utilizada.";
#endregion
        public ProdutoEstruturaInconsistenciaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }


        protected override void InitClass()
        {
            this.ControleRevisaoHabilitado = false;
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
