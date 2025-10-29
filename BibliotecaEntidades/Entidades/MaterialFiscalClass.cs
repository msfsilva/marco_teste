using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class MaterialFiscalClass:MaterialFiscalBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MaterialFiscalClass";
protected new const string ErroDelete = "Erro ao excluir o MaterialFiscalClass  ";
protected new const string ErroSave = "Erro ao salvar o MaterialFiscalClass.";
protected new const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected new const string ErroModeloFiscalIcmsObrigatorio = "O campo ModeloFiscalIcms é obrigatório";
protected new const string ErroNcmObrigatorio = "O campo Ncm é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do MaterialFiscalClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MaterialFiscalClass está sendo utilizada.";
#endregion

        


        public MaterialFiscalClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }

        public void LimparID()
        {
            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;
        }
    }
}
