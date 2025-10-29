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
     public class NcmBeneficioFiscalClass:NcmBeneficioFiscalBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NcmBeneficioFiscalClass";
protected new const string ErroDelete = "Erro ao excluir o NcmBeneficioFiscalClass  ";
protected new const string ErroSave = "Erro ao salvar o NcmBeneficioFiscalClass.";
protected new const string ErroCodigoBeneficioFiscalObrigatorio = "O campo CodigoBeneficioFiscal é obrigatório";
protected new const string ErroCodigoBeneficioFiscalComprimento = "O campo CodigoBeneficioFiscal deve ter no máximo 10 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroNcmObrigatorio = "O campo Ncm é obrigatório";
protected new const string ErroOperacaoObrigatorio = "O campo Operacao é obrigatório";
protected new const string ErroEstadoObrigatorio = "O campo Estado é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NcmBeneficioFiscalClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NcmBeneficioFiscalClass está sendo utilizada.";
#endregion
        public NcmBeneficioFiscalClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
           return Ncm + " - " + Cfop + " - " + CodigoBeneficioFiscal;
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
