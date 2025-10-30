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
    public class NfProdutoDeclaracaoImportacaoAdicaoClass:NfProdutoDeclaracaoImportacaoAdicaoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfProdutoDeclaracaoImportacaoAdicaoClass";
protected new const string ErroDelete = "Erro ao excluir o NfProdutoDeclaracaoImportacaoAdicaoClass  ";
protected new const string ErroSave = "Erro ao salvar o NfProdutoDeclaracaoImportacaoAdicaoClass.";
protected new const string ErroCodigoFabricanteObrigatorio = "O campo Código do Fabricante é obrigatório";
protected new const string ErroCodigoFabricanteComprimento = "O campo Código do Fabricante deve ter no máximo 60 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do NfProdutoDeclaracaoImportacaoAdicaoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoDeclaracaoImportacaoAdicaoClass está sendo utilizada.";
#endregion

        


        public NfProdutoDeclaracaoImportacaoAdicaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
