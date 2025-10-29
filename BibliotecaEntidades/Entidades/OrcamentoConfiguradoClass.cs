using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrcamentoConfiguradoClass:OrcamentoConfiguradoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrcamentoConfiguradoClass";
protected new const string ErroDelete = "Erro ao excluir o OrcamentoConfiguradoClass  ";
protected new const string ErroSave = "Erro ao salvar o OrcamentoConfiguradoClass.";
protected new const string ErroStatusPedidoObrigatorio = "O campo StatusPedido é obrigatório";
protected new const string ErroStatusPedidoComprimento = "O campo StatusPedido deve ter no máximo 2 caracteres";
protected new const string ErroArmazenagemClienteObrigatorio = "O campo ArmazenagemCliente é obrigatório";
protected new const string ErroArmazenagemClienteComprimento = "O campo ArmazenagemCliente deve ter no máximo 100 caracteres";
protected new const string ErroModeloEtiquetaObrigatorio = "O campo ModeloEtiqueta é obrigatório";
protected new const string ErroModeloEtiquetaComprimento = "O campo ModeloEtiqueta deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do OrcamentoConfiguradoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoConfiguradoClass está sendo utilizada.";
#endregion


        public OrcamentoConfiguradoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
    }
}
