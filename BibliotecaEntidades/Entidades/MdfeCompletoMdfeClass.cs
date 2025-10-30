using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using IWTNFCompleto.BibliotecaEntidades.Base; 
namespace IWTNFCompleto.BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class MdfeCompletoMdfeClass:MdfeCompletoMdfeBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MdfeCompletoMdfeClass";
protected new const string ErroDelete = "Erro ao excluir o MdfeCompletoMdfeClass  ";
protected new const string ErroSave = "Erro ao salvar o MdfeCompletoMdfeClass.";
protected new const string ErroXmlObrigatorio = "O campo Xml é obrigatório";
protected new const string ErroChaveAcessoObrigatorio = "O campo ChaveAcesso é obrigatório";
protected new const string ErroChaveAcessoComprimento = "O campo ChaveAcesso deve ter no máximo 50 caracteres";
protected new const string ErroCnpjEmitenteObrigatorio = "O campo CnpjEmitente é obrigatório";
protected new const string ErroCnpjEmitenteComprimento = "O campo CnpjEmitente deve ter no máximo 14 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroMdfeCompletoLoteObrigatorio = "O campo MdfeCompletoLote é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do MdfeCompletoMdfeClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeCompletoMdfeClass está sendo utilizada.";
#endregion
        public MdfeCompletoMdfeClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
