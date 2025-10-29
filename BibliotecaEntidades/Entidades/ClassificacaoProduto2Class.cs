using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ClassificacaoProduto2Class:ClassificacaoProduto2BaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ClassificacaoProduto2Class";
protected new const string ErroDelete = "Erro ao excluir o ClassificacaoProduto2Class  ";
protected new const string ErroSave = "Erro ao salvar o ClassificacaoProduto2Class.";
protected new const string ErroCollectionProdutoClassIficacaoProduto2 = "Erro ao carregar a coleção de ProdutoClass.";
protected new const string ErroValidate = "Erro ao validar os dados do ClassificacaoProduto2Class.";
protected new const string MensagemUtilizadoCollectionProdutoClassIficacaoProduto2 =  "A entidade ClassificacaoProduto2Class está sendo utilizada nos seguintes ProdutoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ClassificacaoProduto2Class está sendo utilizada.";
#endregion


 
        public ClassificacaoProduto2Class(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            return this.Descricao;

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
