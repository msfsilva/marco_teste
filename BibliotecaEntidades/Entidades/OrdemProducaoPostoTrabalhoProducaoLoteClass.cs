using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoPostoTrabalhoProducaoLoteClass:OrdemProducaoPostoTrabalhoProducaoLoteBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoPostoTrabalhoProducaoLoteClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoPostoTrabalhoProducaoLoteClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoPostoTrabalhoProducaoLoteClass.";
protected new const string ErroOrdemProducaoPostoTrabalhoProducaoObrigatorio = "O campo OrdemProducaoPostoTrabalhoProducao é obrigatório";
protected new const string ErroLoteObrigatorio = "O campo Lote é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoPostoTrabalhoProducaoLoteClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoPostoTrabalhoProducaoLoteClass está sendo utilizada.";
#endregion

        

        public OrdemProducaoPostoTrabalhoProducaoLoteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
