using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class LiberacaoDocumentoClass:LiberacaoDocumentoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do LiberacaoDocumentoClass";
protected new const string ErroDelete = "Erro ao excluir o LiberacaoDocumentoClass  ";
protected new const string ErroSave = "Erro ao salvar o LiberacaoDocumentoClass.";
protected new const string ErroJustificativaObrigatorio = "O campo Justificativa é obrigatório";
protected new const string ErroJustificativaComprimento = "O campo Justificativa deve ter no máximo 255 caracteres";
protected new const string ErroDocumentoCopiaObrigatorio = "O campo DocumentoCopia é obrigatório";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroOrdemProducaoDocumentoObrigatorio = "O campo OrdemProducaoDocumento é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do LiberacaoDocumentoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade LiberacaoDocumentoClass está sendo utilizada.";
#endregion

        

        public LiberacaoDocumentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
