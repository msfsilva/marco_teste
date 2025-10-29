using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class DivisaoLoteClass:DivisaoLoteBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do DivisaoLoteClass";
protected new const string ErroDelete = "Erro ao excluir o DivisaoLoteClass  ";
protected new const string ErroSave = "Erro ao salvar o DivisaoLoteClass.";
protected new const string ErroCodigoPaiObrigatorio = "O campo CodigoPai é obrigatório";
protected new const string ErroCodigoPaiComprimento = "O campo CodigoPai deve ter no máximo 255 caracteres";
protected new const string ErroCodigoFilhoObrigatorio = "O campo CodigoFilho é obrigatório";
protected new const string ErroCodigoFilhoComprimento = "O campo CodigoFilho deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do DivisaoLoteClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade DivisaoLoteClass está sendo utilizada.";
#endregion


        public DivisaoLoteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
    }
}
