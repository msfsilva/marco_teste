using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoDocumentoClass:OrdemProducaoDocumentoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoDocumentoClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoDocumentoClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoDocumentoClass.";
protected new const string ErroCollectionLiberacaoDocumentoClassOrdemProducaoDocumento = "Erro ao carregar a coleção de LiberacaoDocumentoClass.";
protected new const string ErroCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento = "Erro ao carregar a coleção de OrdemProducaoDocumentoOpClass.";
protected new const string ErroDocumentoDescricaoObrigatorio = "O campo DocumentoDescricao é obrigatório";
protected new const string ErroDocumentoDescricaoComprimento = "O campo DocumentoDescricao deve ter no máximo 255 caracteres";
protected new const string ErroDocumentoCopia2Obrigatorio = "O campo DocumentoCopia2 é obrigatório";
protected new const string ErroDocumentoCopia2Comprimento = "O campo DocumentoCopia2 deve ter no máximo 255 caracteres";
protected new const string ErroAvisoObrigatorio = "O campo Aviso é obrigatório";
protected new const string ErroDocumentoCopiaObrigatorio = "O campo DocumentoCopia é obrigatório";
protected new const string ErroDocumentoTipoFamiliaObrigatorio = "O campo DocumentoTipoFamilia é obrigatório";
protected new const string ErroOrdemProducaoGrupoObrigatorio = "O campo OrdemProducaoGrupo é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoDocumentoClass.";
protected new const string MensagemUtilizadoCollectionLiberacaoDocumentoClassOrdemProducaoDocumento =  "A entidade OrdemProducaoDocumentoClass está sendo utilizada nos seguintes LiberacaoDocumentoClass:";
protected new const string MensagemUtilizadoCollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento =  "A entidade OrdemProducaoDocumentoClass está sendo utilizada nos seguintes OrdemProducaoDocumentoOpClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoDocumentoClass está sendo utilizada.";
#endregion

        

        public OrdemProducaoDocumentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
