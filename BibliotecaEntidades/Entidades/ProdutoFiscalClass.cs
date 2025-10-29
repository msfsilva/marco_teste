using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ProdutoFiscalClass:ProdutoFiscalBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoFiscalClass";
protected new const string ErroDelete = "Erro ao excluir o ProdutoFiscalClass  ";
protected new const string ErroSave = "Erro ao salvar o ProdutoFiscalClass.";
protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected new const string ErroModeloFiscalIcmsObrigatorio = "O campo ModeloFiscalIcms é obrigatório";
protected new const string ErroNcmObrigatorio = "O campo Ncm é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do ProdutoFiscalClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoFiscalClass está sendo utilizada.";
#endregion


        public ProdutoFiscalClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        public override string ToString()
        {
            return this.Produto.ID.ToString(CultureInfo.InvariantCulture);
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
