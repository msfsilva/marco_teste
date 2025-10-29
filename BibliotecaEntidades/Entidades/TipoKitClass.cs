using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class TipoKitClass:TipoKitBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do TipoKitClass";
protected new const string ErroDelete = "Erro ao excluir o TipoKitClass  ";
protected new const string ErroSave = "Erro ao salvar o TipoKitClass.";
protected new const string ErroCollectionKitTipoKitClassTipoKit2 = "Erro ao carregar a coleção de KitTipoKitClass.";
protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected new const string ErroEtiquetaObrigatorio = "O campo Etiqueta é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do TipoKitClass.";
protected new const string MensagemUtilizadoCollectionKitTipoKitClassTipoKit2 =  "A entidade TipoKitClass está sendo utilizada nos seguintes KitTipoKitClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade TipoKitClass está sendo utilizada.";
#endregion


        public TipoKitClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       


        public override string ToString()
        {
            return this.Nome;
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
