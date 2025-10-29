using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class DocumentoFiscalClass:DocumentoFiscalBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do DocumentoFiscalClass";
protected new const string ErroDelete = "Erro ao excluir o DocumentoFiscalClass  ";
protected new const string ErroSave = "Erro ao salvar o DocumentoFiscalClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroDocumentoFiscalTipoObrigatorio = "O campo DocumentoFiscalTipo é obrigatório";
protected new const string ErroDocumentoFiscalDestinoObrigatorio = "O campo DocumentoFiscalDestino é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do DocumentoFiscalClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade DocumentoFiscalClass está sendo utilizada.";
#endregion

        


        public DocumentoFiscalClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

    

        public override string ToString()
        {
            return Identificacao;
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
