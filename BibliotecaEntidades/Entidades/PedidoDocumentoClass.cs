using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class PedidoDocumentoClass : PedidoDocumentoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do PedidoDocumentoClass";
        protected new const string ErroDelete = "Erro ao excluir o PedidoDocumentoClass  ";
        protected new const string ErroSave = "Erro ao salvar o PedidoDocumentoClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do PedidoDocumentoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade PedidoDocumentoClass está sendo utilizada.";

        #endregion


        public PedidoDocumentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public int PedidoItemSubLinha
        {
            get { return this.PedidoItem.SubLinha; }
        }
        public ProdutoClass PedidoItemProduto
        {
            get { return this.PedidoItem.Produto; }
        }


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

        public void LimparID(PedidoItemClass pedidoItem)
        {
            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;
            this.PedidoItem = pedidoItem;
        }
    }
}
