using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class MotivoAlteracaoQtdOpClass:MotivoAlteracaoQtdOpBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MotivoAlteracaoQtdOpClass";
protected new const string ErroDelete = "Erro ao excluir o MotivoAlteracaoQtdOpClass  ";
protected new const string ErroSave = "Erro ao salvar o MotivoAlteracaoQtdOpClass.";
protected new const string ErroCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoClass.";
protected new const string ErroCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp = "Erro ao carregar a coleção de OrdemProducaoDiferencaClass.";
protected new const string ErroMotivoObrigatorio = "O campo Motivo é obrigatório";
protected new const string ErroMotivoComprimento = "O campo Motivo deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do MotivoAlteracaoQtdOpClass.";
protected new const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp =  "A entidade MotivoAlteracaoQtdOpClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoClass:";
protected new const string MensagemUtilizadoCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp =  "A entidade MotivoAlteracaoQtdOpClass está sendo utilizada nos seguintes OrdemProducaoDiferencaClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MotivoAlteracaoQtdOpClass está sendo utilizada.";
#endregion


        public MotivoAlteracaoQtdOpClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        public override string ToString()
        {
            return Motivo;
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
