using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class ProdutoKEtiquetaClass : ProdutoKEtiquetaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoKEtiquetaClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoKEtiquetaClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoKEtiquetaClass.";
        protected new const string ErroProdutoKObrigatorio = "O campo ProdutoK é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoKEtiquetaClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoKEtiquetaClass está sendo utilizada.";

        #endregion

        

        public ProdutoKEtiquetaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

 
        public override string ToString()
        {
            return this.ProdutoK + " - " + this.QuantidadePorEtiqueta;
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
