using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class ProdutoMaterialClass : ProdutoMaterialBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoMaterialClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoMaterialClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoMaterialClass.";
        protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
        protected new const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoMaterialClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoMaterialClass está sendo utilizada.";

        #endregion


        public ProdutoMaterialClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
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
                    if (parametro.Fieldvalue is bool && (bool)parametro.Fieldvalue)
                    {
                        command.CommandText += " JOIN produto VersaoAtualPai ON VersaoAtualPai.id_produto = produto_material.id_produto ";
                        whereClause += " AND (VersaoAtualPai.pro_versao_estrutura_atual = produto_material.prm_versao_estrutura) ";

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
    }
}
