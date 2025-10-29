using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrcamentoCompraItemClass:OrcamentoCompraItemBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrcamentoCompraItemClass";
protected new const string ErroDelete = "Erro ao excluir o OrcamentoCompraItemClass  ";
protected new const string ErroSave = "Erro ao salvar o OrcamentoCompraItemClass.";
protected new const string ErroOrcamentoCompraObrigatorio = "O campo OrcamentoCompra é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrcamentoCompraItemClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoCompraItemClass está sendo utilizada.";
#endregion

        

        public OrcamentoCompraItemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        public override string ToString()
        {
            return this.OrcamentoCompra.ID + " - " + this.ID;
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
