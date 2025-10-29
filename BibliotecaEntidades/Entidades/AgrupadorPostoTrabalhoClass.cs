using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class AgrupadorPostoTrabalhoClass:AgrupadorPostoTrabalhoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do AgrupadorPostoTrabalhoClass";
protected new const string ErroDelete = "Erro ao excluir o AgrupadorPostoTrabalhoClass  ";
protected new const string ErroSave = "Erro ao salvar o AgrupadorPostoTrabalhoClass.";
protected new const string ErroCollectionPostoTrabalhoClassAgrupadorPostoTrabalho = "Erro ao carregar a coleção de PostoTrabalhoClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 50 caracteres";
protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected new const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do AgrupadorPostoTrabalhoClass.";
protected new const string MensagemUtilizadoCollectionPostoTrabalhoClassAgrupadorPostoTrabalho =  "A entidade AgrupadorPostoTrabalhoClass está sendo utilizada nos seguintes PostoTrabalhoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade AgrupadorPostoTrabalhoClass está sendo utilizada.";
#endregion

        
        public AgrupadorPostoTrabalhoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

 
        public override string ToString()
        {
            return Identificacao;
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
