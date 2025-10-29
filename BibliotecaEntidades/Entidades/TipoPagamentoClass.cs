using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class TipoPagamentoClass:TipoPagamentoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do TipoPagamentoClass";
protected new const string ErroDelete = "Erro ao excluir o TipoPagamentoClass  ";
protected new const string ErroSave = "Erro ao salvar o TipoPagamentoClass.";
protected new const string ErroCollectionContaRecorrenteClassTipoPagamento = "Erro ao carregar a coleção de ContaRecorrenteClass.";
protected new const string ErroCollectionContaReceberClassTipoPagamento = "Erro ao carregar a coleção de ContaReceberClass.";
protected new const string ErroCollectionContaPagarClassTipoPagamento = "Erro ao carregar a coleção de ContaPagarClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do TipoPagamentoClass.";
protected new const string MensagemUtilizadoCollectionContaRecorrenteClassTipoPagamento =  "A entidade TipoPagamentoClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
protected new const string MensagemUtilizadoCollectionContaReceberClassTipoPagamento =  "A entidade TipoPagamentoClass está sendo utilizada nos seguintes ContaReceberClass:";
protected new const string MensagemUtilizadoCollectionContaPagarClassTipoPagamento =  "A entidade TipoPagamentoClass está sendo utilizada nos seguintes ContaPagarClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade TipoPagamentoClass está sendo utilizada.";
#endregion


        public TipoPagamentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
