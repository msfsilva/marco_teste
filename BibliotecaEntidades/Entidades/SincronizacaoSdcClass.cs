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
     public class SincronizacaoSdcClass:SincronizacaoSdcBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do SincronizacaoSdcClass";
protected new const string ErroDelete = "Erro ao excluir o SincronizacaoSdcClass  ";
protected new const string ErroSave = "Erro ao salvar o SincronizacaoSdcClass.";
protected new const string ErroTipoEntidadeObrigatorio = "O campo TipoEntidade é obrigatório";
protected new const string ErroTipoEntidadeComprimento = "O campo TipoEntidade deve ter no máximo 50 caracteres";
protected new const string ErroTipoOperacaoObrigatorio = "O campo TipoOperacao é obrigatório";
protected new const string ErroTipoOperacaoComprimento = "O campo TipoOperacao deve ter no máximo 20 caracteres";
protected new const string ErroDadosPayloadObrigatorio = "O campo DadosPayload é obrigatório";
protected new const string ErroStatusObrigatorio = "O campo Status é obrigatório";
protected new const string ErroStatusComprimento = "O campo Status deve ter no máximo 20 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do SincronizacaoSdcClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade SincronizacaoSdcClass está sendo utilizada.";
#endregion
        public SincronizacaoSdcClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
