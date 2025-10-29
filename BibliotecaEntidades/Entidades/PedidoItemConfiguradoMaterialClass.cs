using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PedidoItemConfiguradoMaterialClass:PedidoItemConfiguradoMaterialBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PedidoItemConfiguradoMaterialClass";
protected new const string ErroDelete = "Erro ao excluir o PedidoItemConfiguradoMaterialClass  ";
protected new const string ErroSave = "Erro ao salvar o PedidoItemConfiguradoMaterialClass.";
protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected new const string ErroUnidadeMedidaObrigatorio = "O campo UnidadeMedida é obrigatório";
protected new const string ErroFamiliaMaterialObrigatorio = "O campo FamiliaMaterial é obrigatório";
protected new const string ErroAcabamentoObrigatorio = "O campo Acabamento é obrigatório";
protected new const string ErroOrderItemEtiquetaObrigatorio = "O campo OrderItemEtiqueta é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do PedidoItemConfiguradoMaterialClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoItemConfiguradoMaterialClass está sendo utilizada.";
#endregion


        public PedidoItemConfiguradoMaterialClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
