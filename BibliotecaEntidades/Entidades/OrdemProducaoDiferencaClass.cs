using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoDiferencaClass:OrdemProducaoDiferencaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoDiferencaClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoDiferencaClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoDiferencaClass.";
protected new const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected new const string ErroOrdemProducaoPostoTrabalhoObrigatorio = "O campo OrdemProducaoPostoTrabalho é obrigatório";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroMotivoAlteracaoQtdOpObrigatorio = "O campo MotivoAlteracaoQtdOp é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoDiferencaClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoDiferencaClass está sendo utilizada.";
#endregion

        



        public OrdemProducaoDiferencaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
