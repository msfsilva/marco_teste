using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class CliEassaIdentificaClienteClass:CliEassaIdentificaClienteBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do CliEassaIdentificaClienteClass";
protected new const string ErroDelete = "Erro ao excluir o CliEassaIdentificaClienteClass  ";
protected new const string ErroSave = "Erro ao salvar o CliEassaIdentificaClienteClass.";
protected new const string ErroCnpjObrigatorio = "O campo Cnpj é obrigatório";
protected new const string ErroCnpjComprimento = "O campo Cnpj deve ter no máximo 50 caracteres";
protected new const string ErroMinifabricaObrigatorio = "O campo Minifabrica é obrigatório";
protected new const string ErroMinifabricaComprimento = "O campo Minifabrica deve ter no máximo 50 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do CliEassaIdentificaClienteClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade CliEassaIdentificaClienteClass está sendo utilizada.";
#endregion

        



        public CliEassaIdentificaClienteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
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
