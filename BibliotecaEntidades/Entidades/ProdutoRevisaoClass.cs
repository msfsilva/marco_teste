using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ProdutoRevisaoClass:ProdutoRevisaoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoRevisaoClass";
protected new const string ErroDelete = "Erro ao excluir o ProdutoRevisaoClass  ";
protected new const string ErroSave = "Erro ao salvar o ProdutoRevisaoClass.";
protected new const string ErroObservacaoObrigatorio = "O campo Observacao é obrigatório";
protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do ProdutoRevisaoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoRevisaoClass está sendo utilizada.";
#endregion

        


        public ProdutoRevisaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
    }
}
