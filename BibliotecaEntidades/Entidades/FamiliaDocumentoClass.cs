using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class FamiliaDocumentoClass:FamiliaDocumentoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do FamiliaDocumentoClass";
protected new const string ErroDelete = "Erro ao excluir o FamiliaDocumentoClass  ";
protected new const string ErroSave = "Erro ao salvar o FamiliaDocumentoClass.";
protected new const string ErroCollectionDocumentoTipoFamiliaClassFamiliaDocumento = "Erro ao carregar a coleção de DocumentoTipoFamiliaClass.";
protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do FamiliaDocumentoClass.";
protected new const string MensagemUtilizadoCollectionDocumentoTipoFamiliaClassFamiliaDocumento =  "A entidade FamiliaDocumentoClass está sendo utilizada nos seguintes DocumentoTipoFamiliaClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade FamiliaDocumentoClass está sendo utilizada.";
#endregion


        public FamiliaDocumentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

     

        public override string ToString()
        {
            return this.Codigo;
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
