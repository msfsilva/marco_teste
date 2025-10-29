using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class ProdutoPaiFilhoClass : ProdutoPaiFilhoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoPaiFilhoClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoPaiFilhoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoPaiFilhoClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoPaiFilhoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoPaiFilhoClass está sendo utilizada.";

        #endregion


        public ProdutoPaiFilhoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public string codigoFilho
        {
            get {
                return this.ProdutoFilho != null ? this.ProdutoFilho.Codigo : "";
            }
        }

  
        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "VersaoAtualPai":
                    if (parametro.Fieldvalue is bool && (bool) parametro.Fieldvalue)
                    {
                        command.CommandText += " JOIN produto VersaoAtualPai ON VersaoAtualPai.id_produto = produto_pai_filho.id_produto_pai ";
                        whereClause += " AND (VersaoAtualPai.pro_versao_estrutura_atual = produto_pai_filho.ppf_versao_estrutura) ";
                     
                    }
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

        public bool getAlterado()
        {
            return this.IsDirty();
        }

        public void setAlterado(bool alterado)
        {
            this.RemoveForcesDirtyAndClean();
            if (alterado)
            {
                ForceDirty();
            }
            else
            {
                ForceClean();
            }
            this.ProdutoPai.setAlterado(true);
        }
    }
}
