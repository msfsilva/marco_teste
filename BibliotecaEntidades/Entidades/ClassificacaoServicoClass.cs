using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ClassificacaoServicoClass:ClassificacaoServicoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ClassificacaoServicoClass";
protected new const string ErroDelete = "Erro ao excluir o ClassificacaoServicoClass  ";
protected new const string ErroSave = "Erro ao salvar o ClassificacaoServicoClass.";
protected new const string ErroCollectionServicoClassIficacaoServico = "Erro ao carregar a coleção de ServicoClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 50 caracteres";
protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do ClassificacaoServicoClass.";
protected new const string MensagemUtilizadoCollectionServicoClassIficacaoServico =  "A entidade ClassificacaoServicoClass está sendo utilizada nos seguintes ServicoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ClassificacaoServicoClass está sendo utilizada.";
#endregion


        public ClassificacaoServicoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public override string ToString()
       {
           return this.Identificacao;
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
