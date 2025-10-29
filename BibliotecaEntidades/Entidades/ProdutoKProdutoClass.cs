using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class ProdutoKProdutoClass : ProdutoKProdutoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoKProdutoClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoKProdutoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoKProdutoClass.";
        protected new const string ErroProdutoKObrigatorio = "O campo ProdutoK é obrigatório";
        protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoKProdutoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoKProdutoClass está sendo utilizada.";

        #endregion

        

        public ProdutoKProdutoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public string CodigoProduto
        {
            get { return Produto.Codigo; }
        }

        public string DescricaoProduto
        {
            get { return Produto.Descricao; }
        }



        public override string ToString()
        {
            return this.ProdutoK + " - " + this.Produto;
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

        public void LimparID()
        {
            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;
            this.objetosDeletar.Clear();
        }
    }
}
