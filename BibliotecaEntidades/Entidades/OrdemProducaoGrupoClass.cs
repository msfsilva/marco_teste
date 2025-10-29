using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoGrupoClass:OrdemProducaoGrupoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoGrupoClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoGrupoClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoGrupoClass.";
protected new const string ErroCollectionOrdemProducaoClassOrdemProducaoGrupo = "Erro ao carregar a coleção de OrdemProducaoClass.";
protected new const string ErroCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo = "Erro ao carregar a coleção de OrdemProducaoDocumentoClass.";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoGrupoClass.";
protected new const string MensagemUtilizadoCollectionOrdemProducaoClassOrdemProducaoGrupo =  "A entidade OrdemProducaoGrupoClass está sendo utilizada nos seguintes OrdemProducaoClass:";
protected new const string MensagemUtilizadoCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo =  "A entidade OrdemProducaoGrupoClass está sendo utilizada nos seguintes OrdemProducaoDocumentoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoGrupoClass está sendo utilizada.";
#endregion

        public OrdemProducaoGrupoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
