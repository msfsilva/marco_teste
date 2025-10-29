using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class MeioPagamentoClass:MeioPagamentoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MeioPagamentoClass";
protected new const string ErroDelete = "Erro ao excluir o MeioPagamentoClass  ";
protected new const string ErroSave = "Erro ao salvar o MeioPagamentoClass.";
protected new const string ErroCollectionContaPagarClassMeioPagamento = "Erro ao carregar a coleção de ContaPagarClass.";
protected new const string ErroCollectionContaReceberClassMeioPagamento = "Erro ao carregar a coleção de ContaReceberClass.";
protected new const string ErroCollectionFormaPagamentoClassMeioPagamento = "Erro ao carregar a coleção de FormaPagamentoClass.";
protected new const string ErroCollectionPedidoItemClassMeioPagamento = "Erro ao carregar a coleção de PedidoItemClass.";
protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 2 caracteres";
protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do MeioPagamentoClass.";
protected new const string MensagemUtilizadoCollectionContaPagarClassMeioPagamento =  "A entidade MeioPagamentoClass está sendo utilizada nos seguintes ContaPagarClass:";
protected new const string MensagemUtilizadoCollectionContaReceberClassMeioPagamento =  "A entidade MeioPagamentoClass está sendo utilizada nos seguintes ContaReceberClass:";
protected new const string MensagemUtilizadoCollectionFormaPagamentoClassMeioPagamento =  "A entidade MeioPagamentoClass está sendo utilizada nos seguintes FormaPagamentoClass:";
protected new const string MensagemUtilizadoCollectionPedidoItemClassMeioPagamento =  "A entidade MeioPagamentoClass está sendo utilizada nos seguintes PedidoItemClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MeioPagamentoClass está sendo utilizada.";
#endregion
        public MeioPagamentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
