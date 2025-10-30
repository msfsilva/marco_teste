using System; 
using System.Collections.Generic; 
using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using IWTNF.Entidades.Base; 
namespace IWTNF.Entidades.Entidades 
{
    [Serializable()]
    public class NfClienteEnderecoClass:NfClienteEnderecoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfClienteEnderecoClass";
protected new const string ErroDelete = "Erro ao excluir o NfClienteEnderecoClass  ";
protected new const string ErroSave = "Erro ao salvar o NfClienteEnderecoClass.";
protected new const string ErroLogradouroObrigatorio = "O campo Logradouro é obrigatório";
protected new const string ErroLogradouroComprimento = "O campo Logradouro deve ter no máximo 60 caracteres";
protected new const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
protected new const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 60 caracteres";
protected new const string ErroBairroObrigatorio = "O campo Bairro é obrigatório";
protected new const string ErroBairroComprimento = "O campo Bairro deve ter no máximo 60 caracteres";
protected new const string ErroSiglaUfObrigatorio = "O campo SiglaUf é obrigatório";
protected new const string ErroSiglaUfComprimento = "O campo SiglaUf deve ter no máximo 2 caracteres";
protected new const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected new const string ErroNfClienteObrigatorio = "O campo NfCliente é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfClienteEnderecoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfClienteEnderecoClass está sendo utilizada.";
#endregion

        

        public NfClienteEnderecoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
         protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
    }
}
