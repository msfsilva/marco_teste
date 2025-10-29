using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoHistoricoClass:OrdemProducaoHistoricoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoHistoricoClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoHistoricoClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoHistoricoClass.";
protected new const string ErroHistoricoObrigatorio = "O campo Historico é obrigatório";
protected new const string ErroHistoricoComprimento = "O campo Historico deve ter no máximo 255 caracteres";
protected new const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoHistoricoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoHistoricoClass está sendo utilizada.";
#endregion

        



        public OrdemProducaoHistoricoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
