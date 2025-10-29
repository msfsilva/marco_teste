using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoPostoTrabalhoClass:OrdemProducaoPostoTrabalhoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoPostoTrabalhoClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoPostoTrabalhoClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoPostoTrabalhoClass.";
protected new const string ErroCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoProducaoClass.";
protected new const string ErroCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho = "Erro ao carregar a coleção de OrdemProducaoDiferencaClass.";
protected new const string ErroPostoCodigoObrigatorio = "O campo PostoCodigo é obrigatório";
protected new const string ErroPostoCodigoComprimento = "O campo PostoCodigo deve ter no máximo 255 caracteres";
protected new const string ErroPostoNomeObrigatorio = "O campo PostoNome é obrigatório";
protected new const string ErroPostoNomeComprimento = "O campo PostoNome deve ter no máximo 255 caracteres";
protected new const string ErroPostoOperacaoObrigatorio = "O campo PostoOperacao é obrigatório";
protected new const string ErroPostoOperacaoComprimento = "O campo PostoOperacao deve ter no máximo 255 caracteres";
protected new const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected new const string ErroPostoTrabalhoObrigatorio = "O campo PostoTrabalho é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoPostoTrabalhoClass.";
protected new const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho =  "A entidade OrdemProducaoPostoTrabalhoClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoProducaoClass:";
protected new const string MensagemUtilizadoCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho =  "A entidade OrdemProducaoPostoTrabalhoClass está sendo utilizada nos seguintes OrdemProducaoDiferencaClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoPostoTrabalhoClass está sendo utilizada.";
#endregion

        

        public OrdemProducaoPostoTrabalhoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
