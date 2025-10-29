using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PedidoItemQualidadeClass:PedidoItemQualidadeBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PedidoItemQualidadeClass";
protected new const string ErroDelete = "Erro ao excluir o PedidoItemQualidadeClass  ";
protected new const string ErroSave = "Erro ao salvar o PedidoItemQualidadeClass.";
protected new const string ErroPedidoItemObrigatorio = "O campo PedidoItem é obrigatório";
protected new const string ErroArquivoObrigatorio = "O campo Arquivo é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do PedidoItemQualidadeClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoItemQualidadeClass está sendo utilizada.";
#endregion


        public PedidoItemQualidadeClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
