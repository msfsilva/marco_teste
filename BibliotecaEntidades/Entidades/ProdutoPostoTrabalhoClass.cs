using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{
    public class ProdutoPostoTrabalhoClass : ProdutoPostoTrabalhoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoPostoTrabalhoClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoPostoTrabalhoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoPostoTrabalhoClass.";
        protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
        protected new const string ErroPostoTrabalhoObrigatorio = "O campo PostoTrabalho é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoPostoTrabalhoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoPostoTrabalhoClass está sendo utilizada.";

        #endregion

        

        public ProdutoPostoTrabalhoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        //private int sequenciaTmp = -1;
        //internal void setSequencia(int novaSequencia)
        //{
        //    if (this.Produto == null)
        //    {
        //        this.sequenciaTmp = novaSequencia;
        //        return;
        //    }

        //    if (this.Produto.exitePostoSequencia(this, novaSequencia))
        //    {
        //        throw new Exception("Não é possível incluir dois postos de trabalho com a mesma sequência.");
        //    }
        //    else
        //    {
        //        this.Sequencia = novaSequencia;
        //    }
        //}


        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
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
        }

      
    }
}
