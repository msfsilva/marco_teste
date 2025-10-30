using System;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTPostgreNpgsql;

namespace IWTNFCompleto.BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class MdfeLacreClass:MdfeLacreBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MdfeLacreClass";
protected new const string ErroDelete = "Erro ao excluir o MdfeLacreClass  ";
protected new const string ErroSave = "Erro ao salvar o MdfeLacreClass.";
protected new const string ErroNumeroLacreObrigatorio = "O campo NumeroLacre é obrigatório";
protected new const string ErroNumeroLacreComprimento = "O campo NumeroLacre deve ter no máximo 60 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroMdfeObrigatorio = "O campo Mdfe é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do MdfeLacreClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeLacreClass está sendo utilizada.";
#endregion
        public MdfeLacreClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
