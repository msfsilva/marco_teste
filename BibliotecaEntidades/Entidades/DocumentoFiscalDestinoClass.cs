using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class DocumentoFiscalDestinoClass:DocumentoFiscalDestinoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do DocumentoFiscalDestinoClass";
protected new const string ErroDelete = "Erro ao excluir o DocumentoFiscalDestinoClass  ";
protected new const string ErroSave = "Erro ao salvar o DocumentoFiscalDestinoClass.";
protected new const string ErroCollectionDocumentoFiscalClassDocumentoFiscalDestino = "Erro ao carregar a coleção de DocumentoFiscalClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do DocumentoFiscalDestinoClass.";
protected new const string MensagemUtilizadoCollectionDocumentoFiscalClassDocumentoFiscalDestino =  "A entidade DocumentoFiscalDestinoClass está sendo utilizada nos seguintes DocumentoFiscalClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade DocumentoFiscalDestinoClass está sendo utilizada.";
#endregion


        public DocumentoFiscalDestinoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
