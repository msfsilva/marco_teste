using System;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.EntidadesAlteradas.Base;
using IWTPostgreNpgsql;

namespace IWTNFCompleto.BibliotecaEntidades.EntidadesAlteradas.Entidades 
{ 
    [Serializable()]
     public class BufferEmail2Class:BufferEmailBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do BufferEmail2Class";
protected new const string ErroDelete = "Erro ao excluir o BufferEmail2Class  ";
protected new const string ErroSave = "Erro ao salvar o BufferEmail2Class.";
protected new const string ErroCollectionBufferEmailAnexoClassBufferEmail = "Erro ao carregar a coleção de BufferEmailAnexo2Class.";
protected new const string ErroRemetenteObrigatorio = "O campo Remetente é obrigatório";
protected new const string ErroDestinatarioObrigatorio = "O campo Destinatario é obrigatório";
protected new const string ErroTituloObrigatorio = "O campo Titulo é obrigatório";
protected new const string ErroCorpoMensagemObrigatorio = "O campo CorpoMensagem é obrigatório";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do BufferEmail2Class.";
protected new const string MensagemUtilizadoCollectionBufferEmailAnexoClassBufferEmail =  "A entidade BufferEmail2Class está sendo utilizada nos seguintes BufferEmailAnexo2Class:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade BufferEmail2Class está sendo utilizada.";
#endregion
        public BufferEmail2Class(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
           throw new NotImplementedException();
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
         protected override bool ValidateDataCustom(ref  IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
        protected override void InternalSaveCustom(ref  IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
    }
}
