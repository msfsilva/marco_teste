using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class TipoNotificacaoDesvioClass:TipoNotificacaoDesvioBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do TipoNotificacaoDesvioClass";
protected new const string ErroDelete = "Erro ao excluir o TipoNotificacaoDesvioClass  ";
protected new const string ErroSave = "Erro ao salvar o TipoNotificacaoDesvioClass.";
protected new const string ErroCollectionNotificacaoDesvioClassTipoNotificacaoDesvio = "Erro ao carregar a coleção de NotificacaoDesvioClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do TipoNotificacaoDesvioClass.";
protected new const string MensagemUtilizadoCollectionNotificacaoDesvioClassTipoNotificacaoDesvio =  "A entidade TipoNotificacaoDesvioClass está sendo utilizada nos seguintes NotificacaoDesvioClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade TipoNotificacaoDesvioClass está sendo utilizada.";
#endregion


        public TipoNotificacaoDesvioClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        


        public override string ToString()
        {
            return this.Identificacao;
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
