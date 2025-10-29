using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class LogEventosClass:LogEventosBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do LogEventosClass";
protected new const string ErroDelete = "Erro ao excluir o LogEventosClass  ";
protected new const string ErroSave = "Erro ao salvar o LogEventosClass.";
protected new const string ErroUsuarioResponsavelObrigatorio = "O campo UsuarioResponsavel é obrigatório";
protected new const string ErroUsuarioResponsavelComprimento = "O campo UsuarioResponsavel deve ter no máximo 255 caracteres";
protected new const string ErroLocalGeracaoObrigatorio = "O campo LocalGeracao é obrigatório";
protected new const string ErroLocalGeracaoComprimento = "O campo LocalGeracao deve ter no máximo 255 caracteres";
protected new const string ErroEventoObrigatorio = "O campo Evento é obrigatório";
protected new const string ErroEventoComprimento = "O campo Evento deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do LogEventosClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade LogEventosClass está sendo utilizada.";
#endregion


        public LogEventosClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
