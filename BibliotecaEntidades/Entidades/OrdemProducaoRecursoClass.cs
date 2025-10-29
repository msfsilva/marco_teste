using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoRecursoClass:OrdemProducaoRecursoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoRecursoClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoRecursoClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoRecursoClass.";
protected new const string ErroRecursoCodigoObrigatorio = "O campo RecursoCodigo é obrigatório";
protected new const string ErroRecursoCodigoComprimento = "O campo RecursoCodigo deve ter no máximo 255 caracteres";
protected new const string ErroRecursoNomeObrigatorio = "O campo RecursoNome é obrigatório";
protected new const string ErroRecursoNomeComprimento = "O campo RecursoNome deve ter no máximo 255 caracteres";
protected new const string ErroPostoTrabalhoCodigoObrigatorio = "O campo PostoTrabalhoCodigo é obrigatório";
protected new const string ErroPostoTrabalhoCodigoComprimento = "O campo PostoTrabalhoCodigo deve ter no máximo 255 caracteres";
protected new const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected new const string ErroRecursoObrigatorio = "O campo Recurso é obrigatório";
protected new const string ErroPostoTrabalhoObrigatorio = "O campo PostoTrabalho é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoRecursoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoRecursoClass está sendo utilizada.";
#endregion

        

        public OrdemProducaoRecursoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
