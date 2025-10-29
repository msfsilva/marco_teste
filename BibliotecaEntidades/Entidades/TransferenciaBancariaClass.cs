using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class TransferenciaBancariaClass:TransferenciaBancariaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do TransferenciaBancariaClass";
protected new const string ErroDelete = "Erro ao excluir o TransferenciaBancariaClass  ";
protected new const string ErroSave = "Erro ao salvar o TransferenciaBancariaClass.";
protected new const string ErroContaBancariaOrigemObrigatorio = "O campo ContaBancariaOrigem é obrigatório";
protected new const string ErroContaBancariaDestinoObrigatorio = "O campo ContaBancariaDestino é obrigatório";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do TransferenciaBancariaClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade TransferenciaBancariaClass está sendo utilizada.";
#endregion


        public TransferenciaBancariaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
