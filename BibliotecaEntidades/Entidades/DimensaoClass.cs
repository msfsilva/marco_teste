using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class DimensaoClass:DimensaoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do DimensaoClass";
protected new const string ErroDelete = "Erro ao excluir o DimensaoClass  ";
protected new const string ErroSave = "Erro ao salvar o DimensaoClass.";
protected new const string ErroCollectionProdutoMaterialClassDimensao1 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected new const string ErroCollectionProdutoMaterialClassDimensao2 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected new const string ErroCollectionProdutoMaterialClassDimensao3 = "Erro ao carregar a coleção de ProdutoMaterialClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do DimensaoClass.";
protected new const string MensagemUtilizadoCollectionProdutoMaterialClassDimensao1 =  "A entidade DimensaoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected new const string MensagemUtilizadoCollectionProdutoMaterialClassDimensao2 =  "A entidade DimensaoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected new const string MensagemUtilizadoCollectionProdutoMaterialClassDimensao3 =  "A entidade DimensaoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade DimensaoClass está sendo utilizada.";
#endregion

        public DimensaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public override string ToString()
        {
            return this.Identificacao;
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
