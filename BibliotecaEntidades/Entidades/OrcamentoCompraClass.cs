using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrcamentoCompraClass:OrcamentoCompraBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrcamentoCompraClass";
protected new const string ErroDelete = "Erro ao excluir o OrcamentoCompraClass  ";
protected new const string ErroSave = "Erro ao salvar o OrcamentoCompraClass.";
protected new const string ErroCollectionOrcamentoCompraItemClassOrcamentoCompra = "Erro ao carregar a coleção de OrcamentoCompraItemClass.";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrcamentoCompraClass.";
protected new const string MensagemUtilizadoCollectionOrcamentoCompraItemClassOrcamentoCompra =  "A entidade OrcamentoCompraClass está sendo utilizada nos seguintes OrcamentoCompraItemClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoCompraClass está sendo utilizada.";
#endregion

        

        public OrcamentoCompraClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
