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
     public class CobRemessaClass:CobRemessaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do CobRemessaClass";
protected new const string ErroDelete = "Erro ao excluir o CobRemessaClass  ";
protected new const string ErroSave = "Erro ao salvar o CobRemessaClass.";
protected new const string ErroCollectionCobBoletoClassCobRemessa = "Erro ao carregar a coleção de CobBoletoClass.";
protected new const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected new const string ErroNomeArquivoComprimento = "O campo NomeArquivo deve ter no máximo 255 caracteres";
protected new const string ErroAgenciaObrigatorio = "O campo Agencia é obrigatório";
protected new const string ErroAgenciaComprimento = "O campo Agencia deve ter no máximo 100 caracteres";
protected new const string ErroDvAgenciaObrigatorio = "O campo DvAgencia é obrigatório";
protected new const string ErroDvAgenciaComprimento = "O campo DvAgencia deve ter no máximo 1 caracteres";
protected new const string ErroNumeroContaObrigatorio = "O campo NumeroConta é obrigatório";
protected new const string ErroNumeroContaComprimento = "O campo NumeroConta deve ter no máximo 100 caracteres";
protected new const string ErroDvContaObrigatorio = "O campo DvConta é obrigatório";
protected new const string ErroDvContaComprimento = "O campo DvConta deve ter no máximo 1 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do CobRemessaClass.";
protected new const string MensagemUtilizadoCollectionCobBoletoClassCobRemessa =  "A entidade CobRemessaClass está sendo utilizada nos seguintes CobBoletoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade CobRemessaClass está sendo utilizada.";
#endregion
        public CobRemessaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
           return this.NomeArquivo.ToString();
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
