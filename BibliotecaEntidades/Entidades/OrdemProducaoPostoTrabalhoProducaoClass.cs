using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoPostoTrabalhoProducaoClass:OrdemProducaoPostoTrabalhoProducaoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoPostoTrabalhoProducaoClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoPostoTrabalhoProducaoClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoPostoTrabalhoProducaoClass.";
protected new const string ErroCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoProducaoLoteClass.";
protected new const string ErroOrdemProducaoPostoTrabalhoObrigatorio = "O campo OrdemProducaoPostoTrabalho é obrigatório";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoPostoTrabalhoProducaoClass.";
protected new const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassOrdemProducaoPostoTrabalhoProducao =  "A entidade OrdemProducaoPostoTrabalhoProducaoClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoProducaoLoteClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoPostoTrabalhoProducaoClass está sendo utilizada.";
#endregion

        


        public OrdemProducaoPostoTrabalhoProducaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
