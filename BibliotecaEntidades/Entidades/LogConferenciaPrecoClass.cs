using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class LogConferenciaPrecoClass:LogConferenciaPrecoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do LogConferenciaPrecoClass";
protected new const string ErroDelete = "Erro ao excluir o LogConferenciaPrecoClass  ";
protected new const string ErroSave = "Erro ao salvar o LogConferenciaPrecoClass.";
protected new const string ErroOcObrigatorio = "O campo Oc é obrigatório";
protected new const string ErroOcComprimento = "O campo Oc deve ter no máximo 255 caracteres";
protected new const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
protected new const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
protected new const string ErroMensagemObrigatorio = "O campo Mensagem é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do LogConferenciaPrecoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade LogConferenciaPrecoClass está sendo utilizada.";
#endregion

        

        public LogConferenciaPrecoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
