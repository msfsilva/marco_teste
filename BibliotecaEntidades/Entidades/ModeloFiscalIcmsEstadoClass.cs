using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ModeloFiscalIcmsEstadoClass:ModeloFiscalIcmsEstadoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ModeloFiscalIcmsEstadoClass";
protected new const string ErroDelete = "Erro ao excluir o ModeloFiscalIcmsEstadoClass  ";
protected new const string ErroSave = "Erro ao salvar o ModeloFiscalIcmsEstadoClass.";
protected new const string ErroModeloFiscalIcmsObrigatorio = "O campo ModeloFiscalIcms é obrigatório";
protected new const string ErroEstadoObrigatorio = "O campo Estado é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do ModeloFiscalIcmsEstadoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ModeloFiscalIcmsEstadoClass está sendo utilizada.";
#endregion


        public ModeloFiscalIcmsEstadoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
        }
       public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
           switch (parametro.FieldName)
            {
                case "IDDiferente":
                    whereClause += " AND modelo_fiscal_icms_estado.id_estado <> :id";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer, -10));
                    return true;
                default:
                    return false;
            }
        }
    }
}
