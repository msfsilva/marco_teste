using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ConfiguracaoClienteClass:ConfiguracaoClienteBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ConfiguracaoClienteClass";
protected new const string ErroDelete = "Erro ao excluir o ConfiguracaoClienteClass  ";
protected new const string ErroSave = "Erro ao salvar o ConfiguracaoClienteClass.";
protected new const string ErroModuloObrigatorio = "O campo Modulo é obrigatório";
protected new const string ErroModuloComprimento = "O campo Modulo deve ter no máximo 255 caracteres";
protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected new const string ErroValorObrigatorio = "O campo Valor é obrigatório";
protected new const string ErroValorComprimento = "O campo Valor deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do ConfiguracaoClienteClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ConfiguracaoClienteClass está sendo utilizada.";
#endregion



        public ConfiguracaoClienteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
