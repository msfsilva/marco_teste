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
     public class ContaReceberBoletoClass:ContaReceberBoletoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ContaReceberBoletoClass";
protected new const string ErroDelete = "Erro ao excluir o ContaReceberBoletoClass  ";
protected new const string ErroSave = "Erro ao salvar o ContaReceberBoletoClass.";
protected new const string ErroCollectionContaReceberClassContaReceberBoleto = "Erro ao carregar a coleção de ContaReceberClass.";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroCobBoletoObrigatorio = "O campo CobBoleto é obrigatório";
protected new const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected new const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do ContaReceberBoletoClass.";
protected new const string MensagemUtilizadoCollectionContaReceberClassContaReceberBoleto =  "A entidade ContaReceberBoletoClass está sendo utilizada nos seguintes ContaReceberClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ContaReceberBoletoClass está sendo utilizada.";
#endregion
        public ContaReceberBoletoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
