using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class AcabamentoClass : AcabamentoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do AcabamentoClass";
        protected new const string ErroDelete = "Erro ao excluir o AcabamentoClass  ";
        protected new const string ErroSave = "Erro ao salvar o AcabamentoClass.";
        protected new const string ErroCollectionProdutoAcabamentoClassAcabamento = "Erro ao carregar a coleção de ProdutoAcabamentoClass.";
        protected new const string ErroCollectionMaterialClassAcabamento = "Erro ao carregar a coleção de MaterialClass.";
        protected new const string ErroCollectionProdutoClassAcabamento = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
        protected new const string ErroDescricaoTecnicaObrigatorio = "O campo DescricaoTecnica é obrigatório";
        protected new const string ErroDescricaoTecnicaComprimento = "O campo DescricaoTecnica deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do AcabamentoClass.";
        protected new const string MensagemUtilizadoCollectionProdutoAcabamentoClassAcabamento = "A entidade AcabamentoClass está sendo utilizada nos seguintes ProdutoAcabamentoClass:";
        protected new const string MensagemUtilizadoCollectionMaterialClassAcabamento = "A entidade AcabamentoClass está sendo utilizada nos seguintes MaterialClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassAcabamento = "A entidade AcabamentoClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade AcabamentoClass está sendo utilizada.";

        #endregion


        public AcabamentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
