using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class ClassificacaoProdutoClass : ClassificacaoProdutoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ClassificacaoProdutoClass";
        protected new const string ErroDelete = "Erro ao excluir o ClassificacaoProdutoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ClassificacaoProdutoClass.";
        protected new const string ErroCollectionProdutoKClassIficacaoProduto = "Erro ao carregar a coleção de ProdutoKClass.";
        protected new const string ErroCollectionProdutoClassIficacaoProduto = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do ClassificacaoProdutoClass.";
        protected new const string MensagemUtilizadoCollectionProdutoKClassIficacaoProduto = "A entidade ClassificacaoProdutoClass está sendo utilizada nos seguintes ProdutoKClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassIficacaoProduto = "A entidade ClassificacaoProdutoClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ClassificacaoProdutoClass está sendo utilizada.";

        #endregion


        public string TipoConsumoEstoqueTela
        {
            get
            {
                switch (TipoConsumoEstoque)
                {
                    case EASITipoConsumoEstoque.MateriaPrima:
                        return "Matéria Prima";
                        break;
                    case EASITipoConsumoEstoque.Consumo:
                        return "Consumo";
                        break;
                    case EASITipoConsumoEstoque.Escolher:
                        return "Definir na SC";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string ConfiguracaoAutomaticaReferenciaTela
        {
            get
            {
                switch (ConfiguracaoAutomaticaReferencia)
                {
                    case EasiConfiguracaoAutomaticaReferencia.DataCadastro:
                        return "Data de Cadastro";
                    case EasiConfiguracaoAutomaticaReferencia.DataEntrega:
                        return "Data de Entrega";

                    case null:
                        return "";

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        public ClassificacaoProdutoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public bool CompradorDef
        {
            get
            {
                if (this.Comprador != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }




        public override string ToString()
        {
            return this.Identificacao;
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {

            switch (parametro.FieldName)
            {
                case "TipoConsumoEstoqueTela":
                    orderByClause += ", clp_tipo_consumo_estoque " + ordenacao.ToString();
                    return true;
                default:
                    return false;
            }
            
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

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (this.ConfiguracaoAutomatica)
            {
                if (!ConfiguracaoAutomaticaReferencia.HasValue)
                {
                    throw new ExcecaoTratada("Selecione a referência para a configuração automática ou desabilite-a");
                }

                if (!ConfiguracaoAutomaticaIntervalo.HasValue)
                {
                    throw new ExcecaoTratada("Selecione o intervalo para a configuração automática ou desabilite-a");
                }
            }

            return true;
        }

        protected override void CalcularCamposAntesValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {
            if (!this.ConfiguracaoAutomatica)
            {
                ConfiguracaoAutomaticaReferencia = null;
                ConfiguracaoAutomaticaIntervalo = null;

            }
        }
    }
}
