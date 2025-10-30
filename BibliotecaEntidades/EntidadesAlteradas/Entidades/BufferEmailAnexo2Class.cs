using System;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.EntidadesAlteradas.Base;
using IWTPostgreNpgsql;

namespace IWTNFCompleto.BibliotecaEntidades.EntidadesAlteradas.Entidades 
{ 
    [Serializable()]
     public class BufferEmailAnexo2Class:BufferEmailAnexoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do BufferEmailAnexo2Class";
protected new const string ErroDelete = "Erro ao excluir o BufferEmailAnexo2Class  ";
protected new const string ErroSave = "Erro ao salvar o BufferEmailAnexo2Class.";
protected new const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroBufferEmailObrigatorio = "O campo BufferEmail2 é obrigatório";
protected new const string ErroArquivoObrigatorio = "O campo Arquivo é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do BufferEmailAnexo2Class.";
protected new const string ErroArquivoLoad = "O campo Arquivo não pode ser carregado";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade BufferEmailAnexo2Class está sendo utilizada.";
#endregion
        public BufferEmailAnexo2Class(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
