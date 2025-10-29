using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{
    public class ServicoClass : ServicoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ServicoClass";
        protected new const string ErroDelete = "Erro ao excluir o ServicoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ServicoClass.";

        protected new const string ErroCollectionPostoTrabalhoClassServico =
            "Erro ao carregar a coleção de PostoTrabalhoClass.";

        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";

        protected new const string ErroIdentificacaoComprimento =
            "O campo Identificacao deve ter no máximo 50 caracteres";

        protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
        protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
        protected new const string ErroIficacaoServicoObrigatorio = "O campo IficacaoServico é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ServicoClass.";

        protected new const string MensagemUtilizadoCollectionPostoTrabalhoClassServico =
            "A entidade ServicoClass está sendo utilizada nos seguintes PostoTrabalhoClass:";

        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ServicoClass está sendo utilizada.";

        #endregion

        


        public ServicoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
