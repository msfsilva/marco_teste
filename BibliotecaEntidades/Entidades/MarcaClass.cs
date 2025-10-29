using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class MarcaClass:MarcaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MarcaClass";
protected new const string ErroDelete = "Erro ao excluir o MarcaClass  ";
protected new const string ErroSave = "Erro ao salvar o MarcaClass.";
protected new const string ErroCollectionHistoricoCompraEpiClassMarca = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
protected new const string ErroCollectionHistoricoCompraMaterialClassMarca = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
protected new const string ErroCollectionHistoricoCompraProdutoClassMarca = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
protected new const string ErroCollectionSolicitacaoCompraClassMarca = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do MarcaClass.";
protected new const string MensagemUtilizadoCollectionHistoricoCompraEpiClassMarca =  "A entidade MarcaClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
protected new const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassMarca =  "A entidade MarcaClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
protected new const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassMarca =  "A entidade MarcaClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
protected new const string MensagemUtilizadoCollectionSolicitacaoCompraClassMarca =  "A entidade MarcaClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MarcaClass está sendo utilizada.";
#endregion


        public MarcaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
