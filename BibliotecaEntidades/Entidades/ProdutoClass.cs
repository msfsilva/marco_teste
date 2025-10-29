using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BibiliotecaGerenciamentoKB;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.GerenciamentoKb;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;


namespace BibliotecaEntidades.Entidades
{
    public class ProdutoClass : ProdutoBaseClass
    {
        private bool _salvandoComo = false;

        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoClass.";
        protected new const string ErroCollectionContratoFornecimentoClassProduto = "Erro ao carregar a coleção de ContratoFornecimentoClass.";
        protected new const string ErroCollectionHistoricoCompraProdutoClassProduto = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
        protected new const string ErroCollectionFomularioRetiradaManualEstoqueClassProduto = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
        protected new const string ErroCollectionLoteClassProduto = "Erro ao carregar a coleção de LoteClass.";
        protected new const string ErroCollectionOrcamentoItemClassProduto = "Erro ao carregar a coleção de OrcamentoItemClass.";
        protected new const string ErroCollectionOrderItemEtiquetaClassProduto = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
        protected new const string ErroCollectionOrdemProducaoClassProduto = "Erro ao carregar a coleção de OrdemProducaoClass.";
        protected new const string ErroCollectionPedidoItemClassProduto = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroCollectionProdutoMaterialClassProduto = "Erro ao carregar a coleção de ProdutoMaterialClass.";
        protected new const string ErroCollectionProdutoPrecoClassProduto = "Erro ao carregar a coleção de ProdutoPrecoClass.";
        protected new const string ErroCollectionProdutoRevisaoClassProduto = "Erro ao carregar a coleção de ProdutoRevisaoClass.";
        protected new const string ErroCollectionProdutoFiscalClassProduto = "Erro ao carregar a coleção de ProdutoFiscalClass.";
        protected new const string ErroCollectionProdutoAcabamentoClassProduto = "Erro ao carregar a coleção de ProdutoAcabamentoClass.";
        protected new const string ErroCollectionProdutoDocumentoTipoClassProduto = "Erro ao carregar a coleção de ProdutoDocumentoTipoClass.";
        protected new const string ErroCollectionProdutoFornecedorClassProduto = "Erro ao carregar a coleção de ProdutoFornecedorClass.";
        protected new const string ErroCollectionProdutoPaiFilhoClassProdutoPai = "Erro ao carregar a coleção de ProdutoPaiFilhoClass.";
        protected new const string ErroCollectionProdutoPaiFilhoClassProdutoFilho = "Erro ao carregar a coleção de ProdutoPaiFilhoClass.";
        protected new const string ErroCollectionProdutoPostoTrabalhoClassProduto = "Erro ao carregar a coleção de ProdutoPostoTrabalhoClass.";
        protected new const string ErroCollectionProdutoRecursoClassProduto = "Erro ao carregar a coleção de ProdutoRecursoClass.";
        protected new const string ErroCollectionSolicitacaoCompraClassProduto = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
        protected new const string ErroCollectionOrcamentoConfiguradoClassProduto = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
        protected new const string ErroCollectionProdutoKProdutoClassProduto = "Erro ao carregar a coleção de ProdutoKProdutoClass.";
        protected new const string ErroCollectionOrcamentoCompraItemClassProduto = "Erro ao carregar a coleção de OrcamentoCompraItemClass.";
        protected new const string ErroCodigoObrigatorio = "O campo Código interno é obrigatório";
        protected new const string ErroCodigoComprimento = "O campo Código interno deve ter no máximo 255 caracteres";
        protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoClass.";
        protected new const string MensagemUtilizadoCollectionContratoFornecimentoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ContratoFornecimentoClass:";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
        protected new const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
        protected new const string MensagemUtilizadoCollectionLoteClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes LoteClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes OrcamentoItemClass:";
        protected new const string MensagemUtilizadoCollectionOrderItemEtiquetaClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes OrdemProducaoClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string MensagemUtilizadoCollectionProdutoMaterialClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
        protected new const string MensagemUtilizadoCollectionProdutoPrecoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPrecoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoRevisaoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoRevisaoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoFiscalClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoFiscalClass:";
        protected new const string MensagemUtilizadoCollectionProdutoAcabamentoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoAcabamentoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoDocumentoTipoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoDocumentoTipoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoFornecedorClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionProdutoPaiFilhoClassProdutoPai = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPaiFilhoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoPaiFilhoClassProdutoFilho = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPaiFilhoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoPostoTrabalhoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoPostoTrabalhoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoRecursoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoRecursoClass:";
        protected new const string MensagemUtilizadoCollectionSolicitacaoCompraClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoKProdutoClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes ProdutoKProdutoClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoCompraItemClassProduto = "A entidade ProdutoClass está sendo utilizada nos seguintes OrcamentoCompraItemClass:";
        protected new const string ErroFiguraLoad = "O campo Figura não pode ser carregado";
        protected new const string ErroImagemLoad = "O campo Imagem não pode ser carregado";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoClass está sendo utilizada.";


        #endregion


        public ProdutoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        protected override void InitClass()
        {
            this.CamposNaoIncluirBuscaCompleta.Add("MotivoRevisao");

            this.ControleRevisaoHabilitado = false;

            this.AcsUsuario = this.UsuarioAtual;


            
        }

        public bool DesabilitarJustificativaRevisaoProduto { get; set; }

        public DateTime? RevisaoUltimaData
        {
            get
            {
                ProdutoRevisaoClass revisao = this.CollectionProdutoRevisaoClassProduto.Where(a => a.VersaoEstrutura == this.VersaoEstruturaAtual).OrderByDescending(a => a.Data).FirstOrDefault();
                if (revisao != null)
                {
                    return revisao.Data;
                }

                return null;
            }
        }

        public AcsUsuarioClass RevisaoUltimaUsuario
        {
            get
            {


                ProdutoRevisaoClass revisao = this.CollectionProdutoRevisaoClassProduto.Where(a => a.VersaoEstrutura == this.VersaoEstruturaAtual).OrderByDescending(a => a.Data).FirstOrDefault();
                if (revisao != null)
                {
                    return revisao.AcsUsuario;
                }

                return null;
            }
        }

        public string RevisaoUltimaMotivo
        {
            get
            {

                ProdutoRevisaoClass revisao = this.CollectionProdutoRevisaoClassProduto.Where(a => a.VersaoEstrutura == this.VersaoEstruturaAtual).OrderByDescending(a => a.Data).FirstOrDefault();
                if (revisao != null)
                {
                    return revisao.Observacao;
                }

                return null;
            }
        }

        public string PoliticaEstoqueTela
        {
            get
            {
                switch (PoliticaEstoque)
                {
                    case PoliticaEstoque.MRP:
                        return "MRP";
                        break;
                    case PoliticaEstoque.Kanban:
                        return "Kanban";
                        break;
                    case PoliticaEstoque.NaoAplicavel:
                        return "Não Aplicável";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        internal int maxSequenciaPosto
        {
            get
            {
                int maxSeqAtual = 0;
                foreach (ProdutoPostoTrabalhoClass produto in this.CollectionProdutoPostoTrabalhoClassProduto)
                {
                    if (produto.Sequencia > maxSeqAtual)
                    {
                        maxSeqAtual = produto.Sequencia;
                    }
                }
                return maxSeqAtual;
            }
        }

        public List<ProdutoMaterialClass> Materiais
        {
            get
            {
                if (this.CollectionProdutoMaterialClassProduto != null)
                {
                    return
                        this.CollectionProdutoMaterialClassProduto.Where(
                            a => a.VersaoEstrutura == this.VersaoEstruturaCarregada).ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public List<ProdutoRecursoClass> Recursos
        {
            get
            {
                if (this.CollectionProdutoRecursoClassProduto != null)
                {
                    return
                        this.CollectionProdutoRecursoClassProduto.Where(
                            a => a.VersaoEstrutura == this.VersaoEstruturaCarregada).ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public List<ProdutoDocumentoTipoClass> Documentos
        {
            get
            {
                if (this.CollectionProdutoDocumentoTipoClassProduto != null)
                {
                    return
                        this.CollectionProdutoDocumentoTipoClassProduto.Where(
                            a => a.VersaoEstrutura == this.VersaoEstruturaCarregada).ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public List<ProdutoPaiFilhoClass> Filhos
        {
            get
            {
                if (this.CollectionProdutoPaiFilhoClassProdutoPai != null)
                {
                    return
                        this.CollectionProdutoPaiFilhoClassProdutoPai.Where(
                            a => a.VersaoEstrutura == this.VersaoEstruturaCarregada).ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public SugestaoKBClass _sugestaoKB = null;

        public SugestaoKBClass sugestaoKB
        {
            get
            {
                if (this._sugestaoKB == null)
                {
                    this.loadSugestaoKb();
                }
                return this._sugestaoKB;
            }
        }

        public bool PossuiEmbalagem
        {
            get { return this.Embalagem != null; }
            set
            {
                if (!value)
                {
                    this.Embalagem = null;
                }
            }
        }

        public bool PossuiVariavel1
        {
            get { return this.Variavel1 != null; }
            set
            {
                if (!value)
                {
                    this.Variavel1 = null;
                }
            }
        }

        public bool PossuiVariavel2
        {
            get { return this.Variavel2 != null; }
            set
            {
                if (!value)
                {
                    this.Variavel2 = null;
                }
            }
        }

        public bool PossuiVariavel3
        {
            get { return this.Variavel3 != null; }
            set
            {
                if (!value)
                {
                    this.Variavel3 = null;
                }
            }
        }

        public bool PossuiVariavel4
        {
            get { return this.Variavel4 != null; }
            set
            {
                if (!value)
                {
                    this.Variavel4 = null;
                }
            }
        }

        public bool PossuiCliente
        {
            get { return this.Cliente != null; }
            set
            {
                if (!value)
                {
                    this.Cliente = null;
                }
            }
        }

        public bool PossuiAplicacaoCliente
        {
            get { return this.AplicacaoCliente != null; }
            set
            {
                if (!value)
                {
                    this.AplicacaoCliente = null;
                }
            }
        }

        public bool PossuiTempoLimite
        {
            get { return this.TempoLimite != null; }
            set
            {
                if (!value)
                {
                    this.TempoLimite = null;
                }
            }
        }

        public bool PossuiRegraValidVar1
        {
            get { return this.RegraValidVar1 != null; }
            set
            {
                if (!value)
                {
                    this.RegraValidVar1 = null;
                }
            }
        }

        public bool PossuiRegraValidVar2
        {
            get { return this.RegraValidVar2 != null; }
            set
            {
                if (!value)
                {
                    this.RegraValidVar2 = null;
                }
            }
        }

        public bool PossuiRegraValidVar3
        {
            get { return this.RegraValidVar3 != null; }
            set
            {
                if (!value)
                {
                    this.RegraValidVar3 = null;
                }
            }
        }

        public bool PossuiRegraValidVar4
        {
            get { return this.RegraValidVar4 != null; }
            set
            {
                if (!value)
                {
                    this.RegraValidVar4 = null;
                }
            }
        }

        public bool PossuiUnidadeMedidaCompra
        {
            get { return this.UnidadeMedidaCompra != null; }
            set
            {
                if (!value)
                {
                    this.UnidadeMedidaCompra = null;
                }
            }
        }

        public bool PossuiComprador
        {
            get { return this.Comprador != null; }
            set
            {
                if (!value)
                {
                    this.Comprador = null;
                }
            }
        }

        public bool PossuiMargemRecebimento
        {
            get { return this.MargemRecebimento != null; }
            set
            {
                if (!value)
                {
                    this.MargemRecebimento = null;
                }
            }
        }

        private int? _versaoEstruturaCarregada = null;
        private string CodigoOriginal;

        public int VersaoEstruturaCarregada
        {
            get { return this._versaoEstruturaCarregada ?? this.VersaoEstruturaAtual; }
            set { this._versaoEstruturaCarregada = value; }
        }

        public string UltimaRevisaoEstruturaMotivo
        {
            get
            {
                ProdutoRevisaoClass toRet = this.CollectionProdutoRevisaoClassProduto.Where(a => a.Tipo_Estrutura && a.VersaoEstrutura == this.VersaoEstruturaCarregada).OrderByDescending(a => a.Data).FirstOrDefault();
                return toRet != null ? toRet.Observacao : null;
            }

        }

        
        public string PoliticaPrecoTela
        {
            get
            {
                switch (CalculoPreco)
                {
                    case TipoCalculoPrecoProdudo.Fixo:
                        return "Preço Fixo";
                        break;
                    case TipoCalculoPrecoProdudo.VariavelRegra:
                        return "Preço Variável - Regra";
                        break;
                    case TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido:
                        return "Preço Variável - Soma TODOS Filhos do Pedido";
                        break;
                    case TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados:
                        return "Preço Variável - Soma Filhos do Pedido SELECIONADOS";
                        break;
                    case TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedidoEEstrutura:
                        return "Preço Variável - Soma TODOS Filhos do Pedido e da Estrutura";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        public override string ToString()
        {
            return this.Codigo;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "CodigoCaseInsensitive":
                    whereClause += " AND (UPPER(pro_codigo) LIKE '" + parametro.Fieldvalue.ToString().ToUpper() + "' OR  LOWER(pro_codigo) LIKE '" + parametro.Fieldvalue.ToString().ToLower() + "') ";
                    return true;
                case "IdDiferente":
                    whereClause += " AND (produto.id_produto <> " + parametro.Fieldvalue + ") ";
                    return true;
                case "GtinExato":
                    whereClause += " AND (produto.pro_gtin LIKE '" + parametro.Fieldvalue.ToString()+ "') ";
                    return true;
                case "Todos":
                    return true;
                case "Inativo":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool tmp = (bool) parametro.Fieldvalue;
                        if (tmp)
                        {
                            whereClause += " AND (produto.pro_ativo = 0) ";
                        }
                    }
                    else
                    {
                        throw new Exception("Parâmetro de tipo inválido.");
                    }
                    
                    return true;
                case "Ativo":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool tmp = (bool)parametro.Fieldvalue;
                        if (tmp)
                        {
                            whereClause += " AND (produto.pro_ativo = 1) ";
                        }
                    }
                    else
                    {
                        throw new Exception("Parâmetro de tipo inválido.");
                    }

                    return true;
                case "BuscaCompleta":
                    whereClause += " AND ( " +
                                   " pro_codigo ILIKE '%"+parametro.Fieldvalue+"%' OR " +
                                   " pro_codigo_cliente ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_descricao ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_regra_dimensao ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_motivo_revisao ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_regra_valid_var1 ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_regra_valid_var2 ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_regra_valid_var3 ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_regra_valid_var4 ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_descricao_adicional ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_gtin ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pro_estrutura_em_revisao_observacao ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " BuscaCompletaClassificacao1.clp_identificacao ILIKE '%" + parametro.Fieldvalue + "%' " +
                                   ") ";
                    command.CommandText += " LEFT JOIN classificacao_produto BuscaCompletaClassificacao1 ON BuscaCompletaClassificacao1.id_classificacao_produto = produto.id_classificacao_produto ";
                    return true;
                    break;
                case "SemPreco":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool tmp = (bool) parametro.Fieldvalue;
                        if (tmp)
                        {
                            whereClause += " AND (preco123.id_produto_preco IS NULL) ";
                        }
                        else
                        {
                            whereClause += " AND (preco123.id_produto_preco IS NOT NULL) ";
                        }

                        command.CommandText += " LEFT OUTER JOIN public.produto_preco preco123 ON (public.produto.id_produto = preco123.id_produto) ";
                    }
                    else
                    {
                        throw new Exception("Parâmetro de tipo inválido.");
                    }

                    return true;

                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "RevisaoUltimaData":
                    orderByClause += " , rev.prr_data " + ordenacao.ToString() + " ";
                    command.CommandText +=
                        "  LEFT OUTER JOIN ( " +
                        "      SELECT produto_revisao.id_produto, " +
                        "             produto_revisao.prr_versao_estrutura, " +
                        "             produto_revisao.id_acs_usuario, " +
                        "             produto_revisao.prr_data, " +
                        "             produto_revisao.prr_observacao, " +
                        "             rank() OVER w AS ran " +
                        "      FROM produto_revisao " +
                        "      WINDOW w AS  " +
                        "      (	PARTITION BY " +
                        "           produto_revisao.id_produto, " +
                        "           produto_revisao.prr_versao_estrutura " +
                        "              ORDER BY produto_revisao.prr_data DESC " +
                        "      ) " +
                        "  ) as rev ON rev.id_produto = produto.id_produto AND rev.prr_versao_estrutura = produto.pro_versao_estrutura_atual AND rev.ran = 1 ";
                    return true;

                case "RevisaoUltimaUsuario":
                    orderByClause += " , rev2.aus_login " + ordenacao.ToString() + " ";
                    command.CommandText +=
                        "  LEFT OUTER JOIN ( " +
                        "      SELECT produto_revisao.id_produto, " +
                        "             produto_revisao.prr_versao_estrutura, " +
                        "             acs_usuario.aus_login, " +
                        "             produto_revisao.prr_data, " +
                        "             produto_revisao.prr_observacao, " +
                        "             rank() OVER w AS ran " +
                        "      FROM produto_revisao LEFT JOIN acs_usuario ON produto_revisao.id_acs_usuario = acs_usuario.id_acs_usuario " +
                        "      WINDOW w AS  " +
                        "      (	PARTITION BY " +
                        "           produto_revisao.id_produto, " +
                        "           produto_revisao.prr_versao_estrutura " +
                        "              ORDER BY produto_revisao.prr_data DESC " +
                        "      ) " +
                        "  ) as rev2 ON rev2.id_produto = produto.id_produto AND rev2.prr_versao_estrutura = produto.pro_versao_estrutura_atual AND rev2.ran = 1 ";
                    return true;

                case "RevisaoUltimaMotivo":
                    orderByClause += " , rev3.prr_observacao " + ordenacao.ToString() + " ";
                    command.CommandText +=
                        "  LEFT OUTER JOIN ( " +
                        "      SELECT produto_revisao.id_produto, " +
                        "             produto_revisao.prr_versao_estrutura, " +
                        "             produto_revisao.id_acs_usuario, " +
                        "             produto_revisao.prr_data, " +
                        "             produto_revisao.prr_observacao, " +
                        "             rank() OVER w AS ran " +
                        "      FROM produto_revisao " +
                        "      WINDOW w AS  " +
                        "      (	PARTITION BY " +
                        "           produto_revisao.id_produto, " +
                        "           produto_revisao.prr_versao_estrutura " +
                        "              ORDER BY produto_revisao.prr_data DESC " +
                        "      ) " +
                        "  ) as rev3 ON rev3.id_produto = produto.id_produto AND rev3.prr_versao_estrutura = produto.pro_versao_estrutura_atual AND rev3.ran = 1 ";
                    return true;
                case "PoliticaEstoqueTela":
                    orderByClause += " , CASE pro_politica_estoque WHEN 0 THEN 'MRP' WHEN 1 THEN 'Kanban' ELSE 'Não Aplicável' END " + ordenacao.ToString();
                    return true;
                case "TipoAquisicao":
                    orderByClause += " , CASE pro_tipo_aquisicao WHEN 0 THEN 'Fabricado' WHEN 1 THEN 'Comprado' ELSE 'Inválido' END " + ordenacao.ToString();
                    return true;

                case "PoliticaPrecoTela":
                    orderByClause += " , pro_calculo_preco  " + ordenacao.ToString();
                    return true;
                default:
                    return false;
            }
        }

        protected override void CalcularCamposAntesValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {
            if (this.Cliente != null)
            {
                this.FamiliaCliente = this.Cliente.FamiliaCliente;
            }
            else
            {
                this.FamiliaCliente = null;
            }


            if (Math.Abs(this.UnidadesPorUnCompra) < 0.0001)
            {
                UnidadesPorUnCompra = 1;
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            IList<ProdutoClass> produtos = this.Search(new List<SearchParameterClass>()
                                                           {
                                                               new SearchParameterClass("CodigoCaseInsensitive", this.Codigo)
                                                           }).ConvertAll(a => (ProdutoClass) a).Where(a => a.ID != this.ID).ToList();

            if (produtos.Any(a => !a.Temporario))
            {
                throw new ExcecaoTratada("Já existe um produto cadastrado com o código interno igual ao atual.");
            }


            ProdutoClass produtoTemporario = produtos.FirstOrDefault(a => a.Temporario);


            bool substituindoTemporario = false;
            if (produtoTemporario != null)
            {
                DialogResult res = MessageBox.Show(null, "Já existe um produto cadastrado automaticamente pelo sistema com o código interno igual ao atual. Você deseja sobrescrever esse produto temporário pelo atual?",
                                                   "Sobrescrever Produto Temporário", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    this.ID = produtoTemporario.ID;
                    this.Version = produtoTemporario.Version;
                    substituindoTemporario = true;

                }
                else
                {
                    return false;
                }


            }




            if (!string.IsNullOrWhiteSpace(this.Gtin))
            {
                if (this.Gtin.Length!=8 && this.Gtin.Length!=12 &&this.Gtin.Length!=13 && this.Gtin.Length!=14)
                {
                    throw new ExcecaoTratada("O código GTIN deve ser de 8, 12, 13 ou 14 caracteres ou estar vazio");
                }

                Int64 tmp;

                if (!Int64.TryParse(this.Gtin, out  tmp))
                {
                    throw new ExcecaoTratada("O código GTIN deve possuir somente números.");
                }

               produtos =  this.Search(new List<SearchParameterClass>()
                                {
                                    new SearchParameterClass("GtinExato",this.Gtin)
                                }).ConvertAll(a => (ProdutoClass)a).Where(a => a.ID != this.ID).ToList();

                if (produtos.Count>0)
                {
                    throw new ExcecaoTratada("Esse código GTIN já está cadastrado para o produto " + produtos[0]);
                }

            }

            if (string.IsNullOrWhiteSpace(this.RegraDimensao))
            {
                this.RegraDimensao = "0";
            }

            //if (this.ID == -1 && this.CollectionProdutoPrecoClassProduto.Count == 0)
            //{
            //    this.atualizarPreco(0, "", Configurations.DataIndependenteClass.GetData(), "Cadastro Novo");
            //    this.setTipoPreco(TipoCalculoPrecoProdudo.Fixo);
            //}

            bool toRet = base.ValidateDataCustom(ref command);

            if (!substituindoTemporario)
            {

                if (!this.DesabilitarJustificativaRevisaoProduto)
                {
                    string justificativa = "";
                    if (this.ID != -1)
                    {

                        JustificativaForm formJustificativa = new JustificativaForm("Sr(a). " + LoginClass.UsuarioLogado.loggedUser.Name + " (" + LoginClass.UsuarioLogado.loggedUser.Login +
                                                   ") essa operação será registrada como uma revisão do cadastro do produto em seu nome. Você deseja prosseguir?");


                        
                        formJustificativa.ShowDialog();

                        if (formJustificativa.Abortar)
                        {
                            return false;
                        }
                        else
                        {
                            justificativa = formJustificativa.Justificativa;
                        }
                    }
                    else
                    {
                        if (_salvandoComo)
                        {
                            justificativa = "Cadastro Inicial - Cópia de " + this._codigoOriginal;
                        }
                        else
                        {
                            justificativa = "Cadastro Inicial";    
                        }
                        
                    }

                    this.RevisarProduto(TipoRevisaoProduto.Principal, justificativa);
                }
            }
            else
            {
                this.RevisarProduto(TipoRevisaoProduto.Principal, "Substituição de Temporário - Salvar Como - " + this.CodigoOriginal);
            }

            if (!this.EstruturaEmRevisao)
            {
                this.EstruturaEmRevisaoObservacao = null;
            }

           if (this.CalculoPreco != TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados)
           {
               foreach (ProdutoPaiFilhoClass filho in this.Filhos)
               {
                   filho.SomaPreco = false;
               }
           }

           if (CollectionProdutoPrecoClassProduto.Count(a => a.Vigente) > 1)
           {
               List<ProdutoPrecoClass> precos = CollectionProdutoPrecoClassProduto.OrderBy(a => a.InicioVigencia).ThenBy(a=>a.ID).ToList();

               for (int i = 0; i < precos.Count()-1; i++)
               {
                   ProdutoPrecoClass preco = precos[i];
                   if (!preco.FimVigencia.HasValue)
                   {
                       preco.FimVigencia = precos[i + 1].InicioVigencia;
                   }
               }
               
           }


           return toRet;
        }

        internal void adicionarMotivoRevisao(string novoMotivo)
        {
            this.MotivoRevisao = Configurations.DataIndependenteClass.GetData().ToString("dd/MM/yyyy HH:mm:ss") + ":" + novoMotivo + "\r\n" + this.MotivoRevisao;
        }

        internal void marcarEngenhariaCadastrado()
        {
            this.CadastroEngenharia = true;
        }

        internal void marcarPCPCadastrado()
        {
            this.CadastroPcp = true;
        }

        internal void marcarPrecoCadastrado()
        {
            this.CadastroPreco = true;
        }

        public void salvarNumeroRevisaoEstrutura(int novaRevisaoEstrutura, string observacao, ref IWTPostgreNpgsqlCommand command)
        {
            this.RevisarProduto(TipoRevisaoProduto.Estrutura, observacao);
            this.Save(ref command);
        }

        public void setEstruturaEmRevisao(bool emRevisao)
        {
            this.EstruturaEmRevisao = emRevisao;
        }

        public void RevisarProduto(TipoRevisaoProduto tipoRevisao, string observacao, int? novaRevisaoEstrutura = null)
        {
            if (novaRevisaoEstrutura.HasValue)
            {
                this.VersaoEstruturaAtual = novaRevisaoEstrutura.Value;
            }
            
            this.CollectionProdutoRevisaoClassProduto.Add(new ProdutoRevisaoClass(
                this.UsuarioAtual, this.SingleConnection)
            {
                AcsUsuario = this.UsuarioAtual,
                Data = Configurations.DataIndependenteClass.GetData(),
                Observacao = observacao,
                Tipo = tipoRevisao,
                Produto = this,
                VersaoEstrutura = novaRevisaoEstrutura ?? this.VersaoEstruturaAtual

            });
        }

        public void SalvarComo(bool estrutura, bool fiscal, bool precos, ref IWTPostgreNpgsqlCommand command)
        {
            _salvandoComo = true;
            List<ProdutoClass> produtos = this.Search(new List<SearchParameterClass>()
                                                          {
                                                              new SearchParameterClass("CodigoCaseInsensitive", this.Codigo)
                                                          }).ConvertAll(a => (ProdutoClass) a).ToList();

            if (produtos.Any(a => !a.Temporario))
            {
                throw new ExcecaoTratada("Já existe um produto cadastrado com o código interno igual ao atual.");
            }

           

            ProdutoClass produtoTemporario = produtos.FirstOrDefault(a => a.Temporario);



            this.CollectionContratoFornecimentoClassProduto = new BindingList<ContratoFornecimentoClass>();
            this._valueCollectionContratoFornecimentoClassProdutoLoaded = true;

            this.CollectionFomularioRetiradaManualEstoqueClassProduto = new BindingList<FomularioRetiradaManualEstoqueClass>();
            this._valueCollectionFomularioRetiradaManualEstoqueClassProdutoLoaded = true;

            this.CollectionHistoricoCompraProdutoClassProduto = new BindingList<HistoricoCompraProdutoClass>();
            this._valueCollectionHistoricoCompraProdutoClassProdutoLoaded = true;

            this.CollectionLoteClassProduto = new BindingList<LoteClass>();
            this._valueCollectionLoteClassProdutoLoaded = true;

            this.CollectionOrcamentoCompraItemClassProduto = new BindingList<OrcamentoCompraItemClass>();
            this._valueCollectionOrcamentoCompraItemClassProdutoLoaded = true;

            this.CollectionOrcamentoConfiguradoClassProduto = new BindingList<OrcamentoConfiguradoClass>();
            this._valueCollectionOrcamentoConfiguradoClassProdutoLoaded = true;

            this.CollectionOrcamentoItemClassProduto = new BindingList<OrcamentoItemClass>();
            this._valueCollectionOrcamentoItemClassProdutoLoaded = true;

            this.CollectionOrdemProducaoClassProduto = new BindingList<OrdemProducaoClass>();
            this._valueCollectionOrdemProducaoClassProdutoLoaded = true;

            this.CollectionOrderItemEtiquetaClassProduto = new BindingList<OrderItemEtiquetaClass>();
            this._valueCollectionOrderItemEtiquetaClassProdutoLoaded = true;

            this.CollectionPedidoItemClassProduto = new BindingList<PedidoItemClass>();
            this._valueCollectionPedidoItemClassProdutoLoaded = true;

            if (estrutura)
            {
                this.CollectionProdutoAcabamentoClassProduto = new BindingList<ProdutoAcabamentoClass>(this.CollectionProdutoAcabamentoClassProduto.Where(a => a.VersaoEstrutura == this.VersaoEstruturaAtual).ToList());
                foreach (ProdutoAcabamentoClass produtoAcabamento in this.CollectionProdutoAcabamentoClassProduto)
                {
                    produtoAcabamento.LimparID();
               
                    produtoAcabamento.VersaoEstrutura = 0;
                }

                this.CollectionProdutoDocumentoTipoClassProduto = new BindingList<ProdutoDocumentoTipoClass>(this.CollectionProdutoDocumentoTipoClassProduto.Where(a => a.VersaoEstrutura == this.VersaoEstruturaAtual).ToList());
                foreach (ProdutoDocumentoTipoClass documentoTipo in CollectionProdutoDocumentoTipoClassProduto)
                {
                    documentoTipo.LimparID();
                    documentoTipo.VersaoEstrutura = 0;
                }

                this.CollectionProdutoMaterialClassProduto = new BindingList<ProdutoMaterialClass>(this.CollectionProdutoMaterialClassProduto.Where(a => a.VersaoEstrutura == this.VersaoEstruturaAtual).ToList());
                foreach (ProdutoMaterialClass produtoMaterial in CollectionProdutoMaterialClassProduto)
                {
                    produtoMaterial.LimparID();
                    produtoMaterial.VersaoEstrutura = 0;
                }

                this.CollectionProdutoPaiFilhoClassProdutoPai = new BindingList<ProdutoPaiFilhoClass>(this.CollectionProdutoPaiFilhoClassProdutoPai.Where(a => a.VersaoEstrutura == this.VersaoEstruturaAtual).ToList());
                foreach (ProdutoPaiFilhoClass produtoPaiFilho in CollectionProdutoPaiFilhoClassProdutoPai)
                {
                    produtoPaiFilho.LimparID();
                    produtoPaiFilho.VersaoEstrutura = 0;
                }

                this.CollectionProdutoRecursoClassProduto = new BindingList<ProdutoRecursoClass>(this.CollectionProdutoRecursoClassProduto.Where(a => a.VersaoEstrutura == this.VersaoEstruturaAtual).ToList());
                foreach (ProdutoRecursoClass produtoRecurso in CollectionProdutoRecursoClassProduto)
                {
                    produtoRecurso.LimparID();
                    produtoRecurso.VersaoEstrutura = 0;
                }

                foreach (ProdutoPostoTrabalhoClass produtoPostoTrabalho in this.CollectionProdutoPostoTrabalhoClassProduto)
                {

                    produtoPostoTrabalho.LimparID();
                }
            }
            else
            {
                this.CollectionProdutoAcabamentoClassProduto = new BindingList<ProdutoAcabamentoClass>();
                this._valueCollectionProdutoAcabamentoClassProdutoLoaded = true;
                this.CollectionProdutoDocumentoTipoClassProduto = new BindingList<ProdutoDocumentoTipoClass>();
                this._valueCollectionProdutoDocumentoTipoClassProdutoLoaded = true;
                this.CollectionProdutoMaterialClassProduto = new BindingList<ProdutoMaterialClass>();
                this._valueCollectionProdutoMaterialClassProdutoLoaded = true;
                this.CollectionProdutoPaiFilhoClassProdutoPai = new BindingList<ProdutoPaiFilhoClass>();
                this._valueCollectionProdutoPaiFilhoClassProdutoPaiLoaded = true;
                this.CollectionProdutoRecursoClassProduto = new BindingList<ProdutoRecursoClass>();
                this._valueCollectionProdutoRecursoClassProdutoLoaded = true;
                this.CollectionProdutoPostoTrabalhoClassProduto = new BindingList<ProdutoPostoTrabalhoClass>();
                this._valueCollectionProdutoPostoTrabalhoClassProdutoLoaded = true;
            }

            this.VersaoEstruturaAtual = 0;

            if (fiscal)
            {
                foreach (ProdutoFiscalClass produtoFiscal in this.CollectionProdutoFiscalClassProduto)
                {
                    produtoFiscal.LimparID();
                }

                if (produtoTemporario != null)
                {
                    while (produtoTemporario.CollectionProdutoFiscalClassProduto.Count > 0)
                    {
                        adicionarObjetoDeletar(produtoTemporario.CollectionProdutoFiscalClassProduto[0]);
                        produtoTemporario.CollectionProdutoFiscalClassProduto.RemoveAt(0);
                    }
                }

            }
            else
            {
                this.CollectionProdutoFiscalClassProduto = new BindingList<ProdutoFiscalClass>();
                this._valueCollectionProdutoFiscalClassProdutoLoaded = true;
            }

            foreach (ProdutoFornecedorClass produtoFornecedor in this.CollectionProdutoFornecedorClassProduto)
            {
                produtoFornecedor.LimparID();

            }

            this.CollectionProdutoKProdutoClassProduto = new BindingList<ProdutoKProdutoClass>();
            _valueCollectionProdutoKProdutoClassProdutoLoaded = true;



            this.CollectionProdutoPaiFilhoClassProdutoFilho = new BindingList<ProdutoPaiFilhoClass>();
            this._valueCollectionProdutoPaiFilhoClassProdutoFilhoLoaded = true;




            if (precos)
            {

                foreach (ProdutoPrecoClass produtoPreco in this.CollectionProdutoPrecoClassProduto)
                {
                    produtoPreco.LimparID();
                    produtoPreco.AcsUsuario = UsuarioAtual;
                    if (produtoPreco.Vigente)
                    {
                        produtoPreco.InicioVigencia = DataIndependenteClass.GetData();
                    }
                }
            }
            else
            {
                this.CollectionProdutoPrecoClassProduto = new BindingList<ProdutoPrecoClass>();
                this._valueCollectionProdutoPrecoClassProdutoLoaded = true;
            }



            this.CollectionProdutoRevisaoClassProduto = new BindingList<ProdutoRevisaoClass>();
            this._valueCollectionProdutoRevisaoClassProdutoLoaded = true;

            this.CollectionSolicitacaoCompraClassProduto = new BindingList<SolicitacaoCompraClass>();
            this._valueCollectionSolicitacaoCompraClassProdutoLoaded = true;

            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;


            this.Save(ref command);

            _salvandoComo = false;

        }

        public ProdutoAcabamentoClass AcabamentoEstruturaCarregada
        {
            get { return this.CollectionProdutoAcabamentoClassProduto.FirstOrDefault(a => a.VersaoEstrutura == this.VersaoEstruturaCarregada); }
        }

        #region Funções Kanban/Compras

        public void SetUtilizandoEstoqueSeguranca(EstoqueSeguranca estoqueSeguranca, bool manual, string entidadeGeradoraRetirada = null, KanbanAcionamentoClass kbEncerrar = null)
        {
            if (estoqueSeguranca == EstoqueSeguranca.NaoUtilizando && this.UtilizandoEstoqueSeguranca == EstoqueSeguranca.NaoUtilizando) return;

            if (estoqueSeguranca != EstoqueSeguranca.NaoUtilizando)
            {

                if (CollectionKanbanAcionamentoClassProduto.Any(a => !a.Encerrado && a.Tipo == estoqueSeguranca))
                {
                    throw new ExcecaoTratada("Já existe um registro de acionamento de Estoque de Segurança não encerrado para o tipo de estoque de segurança " + estoqueSeguranca);
                }

                //Entrada no registro de Kb
                if (!this.UtilizandoEstoqueSegurancaData.HasValue)
                {
                    //Não existe um registro
                    this.UtilizandoEstoqueSegurancaData = Configurations.DataIndependenteClass.GetData();
                }

                this.CollectionKanbanAcionamentoClassProduto.Add(new KanbanAcionamentoClass(UsuarioAtual, SingleConnection)
                {
                    Produto = this,
                    ProdutoK = null,
                    Material = null,
                    Epi = null,
                    Encerrado = false,
                    Tipo = estoqueSeguranca,
                    AcsUsuarioAcionamento = UsuarioAtual,
                    DataAcionamento = DataIndependenteClass.GetData()
                });

                this.UtilizandoEstoqueSeguranca = estoqueSeguranca;
            }
            else
            {
                //Encerramento do Registro
                if (manual)
                {
                    if (kbEncerrar == null)
                    {
                        throw new Exception("Baixa de Aviso de KB Manual sem indicar origem, informe o Suporte IWT");
                    }

                    if (CollectionKanbanAcionamentoClassProduto.Count(a => !a.Encerrado) == 1)
                    {
                        this.UtilizandoEstoqueSeguranca = EstoqueSeguranca.NaoUtilizando;
                        this.UtilizandoEstoqueSegurancaData = null;
                    }

                    kbEncerrar.Encerrar(UsuarioAtual, manual, entidadeGeradoraRetirada);


                }
                else
                {
                    this.UtilizandoEstoqueSeguranca = EstoqueSeguranca.NaoUtilizando;
                    this.UtilizandoEstoqueSegurancaData = null;

                    foreach (KanbanAcionamentoClass acionamento in CollectionKanbanAcionamentoClassProduto.Where(a => !a.Encerrado))
                    {
                        acionamento.Encerrar(UsuarioAtual, manual, entidadeGeradoraRetirada);
                    }
                }
            }
        }

        private void loadSugestaoKb()
        {
            try
            {

                if (this.ID != -1)
                {

                    CalculaSugestaoKBClass calc = new CalculaSugestaoKBClass(SingleConnection);

                    this._sugestaoKB = calc.CalcularProduto(this, this.Verde, this.Amarelo, this.Vermelho,
                                                            (this.UnidadeMedida != null ? this.UnidadeMedida.ToString() : ""));
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as sugestões.\r\n" + e.Message, e);
            }
        }

        public void clearSugestaoKb()
        {
            this._sugestaoKB = null;
        }

        public DateTime calculaEntregaPrevistaCompra(int diasPCP, DateTime dataReferencia)
        {
            bool pulaSabado = !IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_PERMITIR_SC_SABADO);
            bool pulaDomingo = !IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_PERMITIR_SC_DOMINGO);

            DateTime toRet = dataReferencia.AddDays(diasPCP + this.LeadTimeCompra);

            if (pulaSabado && toRet.DayOfWeek == DayOfWeek.Saturday)
            {
                toRet = toRet.AddDays(1);
            }

            if (pulaDomingo && toRet.DayOfWeek == DayOfWeek.Sunday)
            {
                toRet = toRet.AddDays(1);
            }

            return toRet;
        }

        public DateTime? calculaDataProximaUtilizacao()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = (this.SingleConnection ?? this.SingleConnection).CreateCommand();
                command.CommandText =
                    "SELECT MIN(pei_data_entrega) as data " +
                    "FROM " +
                    "  public.order_item_etiqueta " +
                    "  JOIN (  " +
                    "   	SELECT pei_numero, pei_posicao,pei_data_entrega FROM pedido_item WHERE pei_sub_linha = 0 AND (pei_status = 0 OR pei_status = 3)  " +
                    "  ) as pedidos_pai ON pei_numero = oie_order_number AND pei_posicao = oie_order_pos  " +
                    "WHERE " +
                    "  public.order_item_etiqueta.id_produto = " + this.ID + " ";

                object tmp = command.ExecuteScalar();

                if (tmp == null || tmp == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToDateTime(tmp);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular a data da próxima utilização.\r\n" + e.Message, e);
            }
        }

        public DateTime? calculaDataZeraEstoque()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = (this.SingleConnection ?? this.SingleConnection).CreateCommand();
                double qtdAtualEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(this, ref command);

                command.CommandText =
                    "SELECT  " +
                    "  pei_data_entrega, " +
                    "  order_item_etiqueta.oie_saldo as qtd " +
                    "FROM " +
                    "  public.order_item_etiqueta " +
                    "  JOIN (  " +
                    "   	SELECT pei_numero, pei_posicao,pei_data_entrega FROM pedido_item WHERE pei_sub_linha = 0 AND (pei_status = 0 OR pei_status = 3)  " +
                    "  ) as pedidos_pai ON pei_numero = oie_order_number AND pei_posicao = oie_order_pos  " +
                    "WHERE " +
                    "  public.order_item_etiqueta.id_produto  = " + this.ID + " " +
                    "ORDER BY pei_data_entrega ASC ";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    return null;
                }

                read.Read();
                DateTime dataAtual = Convert.ToDateTime(read["pei_data_entrega"]);
                do
                {
                    dataAtual = Convert.ToDateTime(read["pei_data_entrega"]);
                    qtdAtualEstoque -= Convert.ToDouble(read["qtd"]);

                } while (qtdAtualEstoque > 0 && read.Read());

                read.Close();

                if (qtdAtualEstoque > 0)
                {
                    return null;
                }
                else
                {
                    return dataAtual;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular a data do fim do estoque.\r\n" + e.Message, e);
            }
        }

        #endregion

        #region Funções Fornecedores

        public void removerFornecedorProduto(ProdutoFornecedorClass pf)
        {
            try
            {
                if (!this.CollectionProdutoFornecedorClassProduto.Contains(pf))
                {
                    throw new ExcecaoTratada("O Fornecedor não foi encontrado vinculado nesse produto");
                }


                pf.Ativo = false;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("\r\n" + e.Message, e);
            }
        }

        public void adicionarFornecedor(FornecedorClass fornecedor, double ultimoPreco, double icmsIncluso, double ipiNaoIncluso, UnidadeMedidaClass unidadeCompra,bool preferencial,  double? qtdUnidadeUso, double? loteMinimo, double? lotePadrao)
        {
            try
            {

                if (preferencial)
                {
                    if (CollectionProdutoFornecedorClassProduto.Any(a => a.Preferencial && a.Fornecedor != fornecedor))
                    {
                        throw new ExcecaoTratada("Não é possível ter dois fornecedores preferenciais em um mesmo produto");
                    }
                }


                ProdutoFornecedorClass pf;
                if (this.CollectionProdutoFornecedorClassProduto.Any(a => a.Fornecedor == fornecedor))
                {
                    //Atualiza Fornecedor
                    pf = this.CollectionProdutoFornecedorClassProduto.First(a => a.Fornecedor == fornecedor);
                    pf.UltimoPreco = ultimoPreco;
                    pf.Icms = icmsIncluso;
                    pf.Ipi = ipiNaoIncluso;
                    pf.UnidadeMedidaCompra = unidadeCompra;
                    if (unidadeCompra != null)
                    {
                        pf.UnidadesPorUnCompra = qtdUnidadeUso;
                        pf.LotePadrao = lotePadrao;
                        pf.LoteMinimo = loteMinimo;
                    }
                    else
                    {
                        pf.UnidadesPorUnCompra = null;
                        pf.LotePadrao = null;
                        pf.LoteMinimo = null;
                    }
                    pf.Ativo = true;

                    pf.Preferencial = preferencial;

                    return;
                }

                pf = new ProdutoFornecedorClass(this.UsuarioAtual, this.SingleConnection)
                         {
                             Produto = this,
                             Fornecedor = fornecedor,
                             UltimoPreco = ultimoPreco,
                             Icms = icmsIncluso,
                             Ipi = ipiNaoIncluso,
                             UnidadeMedidaCompra = unidadeCompra,
                             Preferencial = preferencial,
                             Ativo = true
                         };

                if (unidadeCompra != null)
                {
                    pf.UnidadesPorUnCompra = qtdUnidadeUso;
                    pf.LotePadrao = lotePadrao;
                    pf.LoteMinimo = loteMinimo;
                }
                else
                {
                    pf.UnidadesPorUnCompra = null;
                    pf.LotePadrao = null;
                    pf.LoteMinimo = null;
                }

                this.CollectionProdutoFornecedorClassProduto.Add(pf);


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao adicionar ou atualizar o fornecedor do produto\r\n" + e.Message, e);
            }
        }

        #endregion

        #region Funções de Materiais

        internal void removeMaterial(MaterialClass material)
        {
            ProdutoMaterialClass produtoMaterial = this.Materiais.FirstOrDefault(a => a.Material == material);
            if (produtoMaterial == null)
            {
                throw new ExcecaoTratada("Material não encontrado no produto");
            }

            this.CollectionProdutoMaterialClassProduto.Remove(produtoMaterial);
            this.adicionarObjetoDeletar(produtoMaterial);
        }

        #endregion

        #region Funções de Postos Trabalho

        internal void removePostoTrabalho(PostoTrabalhoClass postoTrabalho)
        {
            ProdutoPostoTrabalhoClass produtoPosto = this.CollectionProdutoPostoTrabalhoClassProduto.FirstOrDefault(a => a.PostoTrabalho == postoTrabalho);
            if (produtoPosto == null)
            {
                throw new ExcecaoTratada("Posto não encontrado no produto");
            }

            this.CollectionProdutoPostoTrabalhoClassProduto.Remove(produtoPosto);
            this.adicionarObjetoDeletar(produtoPosto);
        }

        internal bool exitePostoSequencia(ProdutoPostoTrabalhoClass postoAtual, int novaSequencia)
        {
            foreach (ProdutoPostoTrabalhoClass posto in this.CollectionProdutoPostoTrabalhoClassProduto)
            {
                if (posto.Sequencia == novaSequencia && posto != postoAtual)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Funções de Documentos

        internal void removeDocumento(DocumentoTipoFamiliaClass documento)
        {
            ProdutoDocumentoTipoClass produtoDocumento = this.Documentos.FirstOrDefault(a => a.DocumentoTipoFamilia == documento);
            if (produtoDocumento == null)
            {
                throw new ExcecaoTratada("Documento não encontrado no produto");
            }

            this.CollectionProdutoDocumentoTipoClassProduto.Remove(produtoDocumento);
            this.adicionarObjetoDeletar(produtoDocumento);
        }

        #endregion

        #region Funções de Recursos

        internal void removeRecurso(RecursoClass recurso)
        {
            ProdutoRecursoClass produtoRecurso = this.Recursos.FirstOrDefault(a => a.Recurso == recurso);
            if (produtoRecurso == null)
            {
                throw new ExcecaoTratada("Recurso não encontrado no produto");
            }

            this.CollectionProdutoRecursoClassProduto.Remove(produtoRecurso);
            this.adicionarObjetoDeletar(produtoRecurso);
        }

        #endregion

        public void SavePCP(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                if (UsuarioAtual == null)
                {
                    throw new Exception("Essa instancia da classe foi carregada sem usuário, não é permitido utiliza-la para salvar.");
                }


                JustificativaForm formJustificativa =
                    new JustificativaForm("Sr(a). " + LoginClass.UsuarioLogado.loggedUser.Name + " (" + LoginClass.UsuarioLogado.loggedUser.Login +
                                           ") essa operação será registrada como uma revisão do cadastro do produto em seu nome. Você deseja prosseguir?");
                formJustificativa.ShowDialog();

                if (formJustificativa.Abortar)
                {
                    return;
                }

                string justificativa = formJustificativa.Justificativa;

                this.CadastroPcp = true;
                this.RevisarProduto(TipoRevisaoProduto.PCP, justificativa);


                if (Math.Abs(UnidadesPorUnCompra) < 0.00001)
                {
                    UnidadesPorUnCompra = 1;
                }


                bool controleHabilitado = base.ControleRevisaoHabilitado;
                bool desabilitarJustificativaRevisaoProduto = this.DesabilitarJustificativaRevisaoProduto;
                try
                {
                    base.ControleRevisaoHabilitado = false;
                    this.DesabilitarJustificativaRevisaoProduto = true;
                    Save(ref command);
                }
                finally
                {
                    base.ControleRevisaoHabilitado = controleHabilitado;
                    DesabilitarJustificativaRevisaoProduto = desabilitarJustificativaRevisaoProduto;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar.\r\n" + e.Message, e);
            }
        }


        public void SavePermissaoVenda(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (UsuarioAtual == null)
                {
                    throw new Exception("Essa instancia da classe foi carregada sem usuário, não é permitido utiliza-la para salvar.");
                }


                JustificativaForm formJustificativa =
                    new JustificativaForm("Sr(a). " + LoginClass.UsuarioLogado.loggedUser.Name + " (" + LoginClass.UsuarioLogado.loggedUser.Login +
                                           ") essa operação será registrada como uma revisão do cadastro do produto em seu nome. Você deseja prosseguir?");
                formJustificativa.ShowDialog();

                if (formJustificativa.Abortar)
                {
                    return;
                }

                string justificativa = formJustificativa.Justificativa;






                if (PermiteVenda)
                {
                    //Limpa o lixo criado durante a implantação da funcionalidade
                    List<ProdutoPermissaoVendaPeriodosClass> tmp2 = this.CollectionProdutoPermissaoVendaPeriodosClassProduto.Where(a => !a.Termino.HasValue && a.InicioJustificativa == "Criada pelo sistema no inicio da funcionalidade").ToList();
                    while (tmp2.Count>0)
                    {
                        this.adicionarObjetoDeletar(tmp2[0]);
                        this.CollectionProdutoPermissaoVendaPeriodosClassProduto.Remove(tmp2[0]);
                        tmp2.RemoveAt(0);
                    }

                    ProdutoPermissaoVendaPeriodosClass tmp = this.CollectionProdutoPermissaoVendaPeriodosClassProduto.FirstOrDefault(a => !a.Termino.HasValue);
                    if (tmp != null)
                    {
                       
                        throw new Exception("Não é possível permitir a venda pois o produto já possui uma permissão ativa.");
                    }

                    this.CollectionProdutoPermissaoVendaPeriodosClassProduto.Add(new ProdutoPermissaoVendaPeriodosClass(UsuarioAtual, SingleConnection)
                    {
                        Produto = this,
                        AcsUsuarioInicio = UsuarioAtual,
                        InicioJustificativa = justificativa,
                        Inicio = Configurations.DataIndependenteClass.GetData()
                    });
                }
                else
                {
                    ProdutoPermissaoVendaPeriodosClass tmp = this.CollectionProdutoPermissaoVendaPeriodosClassProduto.FirstOrDefault(a => !a.Termino.HasValue);
                    if (tmp == null)
                    {
                        throw new Exception("Não é possível encerrar a permissão de venda pois o produto não possui uma permissão ativa.");
                    }

                    tmp.Termino = Configurations.DataIndependenteClass.GetData();
                    tmp.TerminoJustificativa = justificativa;
                    tmp.AcsUsuarioTermino = UsuarioAtual;
                }


                this.RevisarProduto(TipoRevisaoProduto.PermissaoVenda, justificativa);

                

                this.internalSave(ref command);

                #region Exclui deletados

                foreach (AbstractEntity entity in objetosDeletar)
                {
                    entity.Delete(ref command);
                }

                this.objetosDeletar = new List<AbstractEntity>();

                #endregion

                #region Save Vetores do Objeto

                if (SalvarVetoresObjetosHabilitado)
                {
                    this.DisableLoadCollection = true;

                    Type typeObjeto = this.GetType();
                    PropertyInfo[] properties = typeObjeto.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
                    Type typeInterface = typeof(IList);
                    Type typeInterface2 = typeof(IDictionary);

                    foreach (PropertyInfo pi in properties)
                    {
                        if (pi.PropertyType.GetInterface(typeInterface.Name) != null)
                        {
                            IList array = (IList)pi.GetValue(this, null);
                            if (array != null)
                            {
                                if (array.Count > 0)
                                {
                                    if (array[0] is AbstractEntity)
                                    {
                                        foreach (AbstractEntity entity in array)
                                        {

                                            bool ControleRevisaoAnterior = entity.ControleRevisaoHabilitado;

                                            entity.ControleRevisaoHabilitado = false;

                                            entity.Save(ref command);

                                            entity.ControleRevisaoHabilitado = ControleRevisaoAnterior;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (pi.PropertyType.GetInterface(typeInterface2.Name) != null)
                            {
                                IList array = (IList)pi.GetValue(this, null);
                                if (array != null)
                                {
                                    if (array.Count > 0)
                                    {
                                        if (array[0] is AbstractEntity)
                                        {
                                            foreach (AbstractEntity entity in array)
                                            {
                                                bool ControleRevisaoAnterior = entity.ControleRevisaoHabilitado;

                                                entity.ControleRevisaoHabilitado = false;

                                                entity.Save(ref command);

                                                entity.ControleRevisaoHabilitado = ControleRevisaoAnterior;
                                            }
                                        }

                                    }
                                }
                            }

                        }
                    }

                    this.DisableLoadCollection = false;
                }

                #endregion

                



                this.CommitChanges();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar.\r\n" + e.Message, e);
            }
        }

        public void SortVetorPrecos()
        {
            this.CollectionProdutoPrecoClassProduto = new BindingList<ProdutoPrecoClass>(this.CollectionProdutoPrecoClassProduto.OrderBy(a => a.ID).ToList());
        }


        public override bool Utilizado(out string mensagemUtilizado)
        {
            try
            {
                mensagemUtilizado = "";
                if (this.ID == -1)
                {
                    return false;
                }
                if (CollectionContratoFornecimentoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionContratoFornecimentoClassProduto + "\r\n";
                    foreach (Entidades.ContratoFornecimentoClass tmp in CollectionContratoFornecimentoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionFomularioRetiradaManualEstoqueClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassProduto + "\r\n";
                    foreach (Entidades.FomularioRetiradaManualEstoqueClass tmp in CollectionFomularioRetiradaManualEstoqueClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionHistoricoCompraProdutoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraProdutoClassProduto + "\r\n";
                    foreach (Entidades.HistoricoCompraProdutoClass tmp in CollectionHistoricoCompraProdutoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionLoteClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionLoteClassProduto + "\r\n";
                    foreach (Entidades.LoteClass tmp in CollectionLoteClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionOrcamentoCompraItemClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoCompraItemClassProduto + "\r\n";
                    foreach (Entidades.OrcamentoCompraItemClass tmp in CollectionOrcamentoCompraItemClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionOrcamentoConfiguradoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoConfiguradoClassProduto + "\r\n";
                    foreach (Entidades.OrcamentoConfiguradoClass tmp in CollectionOrcamentoConfiguradoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionOrcamentoItemClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassProduto + "\r\n";
                    foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionOrdemProducaoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoClassProduto + "\r\n";
                    foreach (Entidades.OrdemProducaoClass tmp in CollectionOrdemProducaoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionOrderItemEtiquetaClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassProduto + "\r\n";
                    foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionPedidoItemClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassProduto + "\r\n";
                    foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoAcabamentoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoAcabamentoClassProduto + "\r\n";
                    foreach (Entidades.ProdutoAcabamentoClass tmp in CollectionProdutoAcabamentoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoDocumentoTipoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoDocumentoTipoClassProduto + "\r\n";
                    foreach (Entidades.ProdutoDocumentoTipoClass tmp in CollectionProdutoDocumentoTipoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoFiscalClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoFiscalClassProduto + "\r\n";
                    foreach (Entidades.ProdutoFiscalClass tmp in CollectionProdutoFiscalClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoFornecedorClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoFornecedorClassProduto + "\r\n";
                    foreach (Entidades.ProdutoFornecedorClass tmp in CollectionProdutoFornecedorClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoKProdutoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoKProdutoClassProduto + "\r\n";
                    foreach (Entidades.ProdutoKProdutoClass tmp in CollectionProdutoKProdutoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoMaterialClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoMaterialClassProduto + "\r\n";
                    foreach (Entidades.ProdutoMaterialClass tmp in CollectionProdutoMaterialClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoPaiFilhoClassProdutoPai.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoPaiFilhoClassProdutoPai + "\r\n";
                    foreach (Entidades.ProdutoPaiFilhoClass tmp in CollectionProdutoPaiFilhoClassProdutoPai)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoPaiFilhoClassProdutoFilho.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoPaiFilhoClassProdutoFilho + "\r\n";
                    foreach (Entidades.ProdutoPaiFilhoClass tmp in CollectionProdutoPaiFilhoClassProdutoFilho)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionProdutoPostoTrabalhoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoPostoTrabalhoClassProduto + "\r\n";
                    foreach (Entidades.ProdutoPostoTrabalhoClass tmp in CollectionProdutoPostoTrabalhoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }

                if (CollectionProdutoRecursoClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionProdutoRecursoClassProduto + "\r\n";
                    foreach (Entidades.ProdutoRecursoClass tmp in CollectionProdutoRecursoClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                if (CollectionSolicitacaoCompraClassProduto.Count > 0)
                {
                    mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraClassProduto + "\r\n";
                    foreach (Entidades.SolicitacaoCompraClass tmp in CollectionSolicitacaoCompraClassProduto)
                    {
                        mensagemUtilizado += tmp.ToString() + "\r\n";
                    }
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(ErroUtilizado + "\r\n" + e.Message, e);
            }
        }

        protected override void CarregamentoConcluido()
        {
            base.CarregamentoConcluido();
            this.CodigoOriginal = Codigo;
        }

        #region Funcoes Arvore
        public void ExcluirFilho(ProdutoPaiFilhoClass produtoPaiFilho, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("ExcluirFilho:" + produtoPaiFilho.codigoFilho, caminhoLog);
            }
            if (!CollectionProdutoPaiFilhoClassProdutoPai.Contains(produtoPaiFilho))
            {
                string msgErro = "O filho não foi encontrado para exclusão";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new ExcecaoTratada(msgErro);
            }

            this.CollectionProdutoPaiFilhoClassProdutoPai.Remove(produtoPaiFilho);
            this.objetosDeletar.Add(produtoPaiFilho);

            this.ForceDirty();
        }

        public void ExcluirMaterial(ProdutoMaterialClass produtoMaterial, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("ExcluirMaterial:" + produtoMaterial.Material.CodigoComFamilia, caminhoLog);
            }
            if (!CollectionProdutoMaterialClassProduto.Contains(produtoMaterial))
            {
                string msgErro = "O material não foi encontrado para exclusão";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new ExcecaoTratada(msgErro);
            }

            this.CollectionProdutoMaterialClassProduto.Remove(produtoMaterial);
            this.objetosDeletar.Add(produtoMaterial);

            this.ForceDirty();
        }

        public void ExcluirAcabamento(ProdutoAcabamentoClass produtoAcabamento, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("ExcluirAcabamento:" + produtoAcabamento.Acabamento, caminhoLog);
            }
            if (!CollectionProdutoAcabamentoClassProduto.Contains(produtoAcabamento))
            {
                string msgErro = "O acabamento não foi encontrado para exclusão";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new ExcecaoTratada(msgErro);
            }

            this.CollectionProdutoAcabamentoClassProduto.Remove(produtoAcabamento);
            this.objetosDeletar.Add(produtoAcabamento);
            this.ForceDirty();
        }

        public void ExcluirRecurso(ProdutoRecursoClass produtoRecurso, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("ExcluirRecurso:" + produtoRecurso.Recurso, caminhoLog);
            }
            if (!CollectionProdutoRecursoClassProduto.Contains(produtoRecurso))
            {
                string msgErro = "O recurso não foi encontrado para exclusão";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new ExcecaoTratada(msgErro);
            }

            this.CollectionProdutoRecursoClassProduto.Remove(produtoRecurso);
            this.objetosDeletar.Add(produtoRecurso);

            this.ForceDirty();
        }

        public void ExcluirDocumento(ProdutoDocumentoTipoClass produtoDocumentoTipo, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("ExcluirDocumento:" + produtoDocumentoTipo.DocumentoTipoFamilia, caminhoLog);
            }
            if (!CollectionProdutoDocumentoTipoClassProduto.Contains(produtoDocumentoTipo))
            {
                string msgErro = "O documento não foi encontrado para exclusão";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new ExcecaoTratada(msgErro);
            }

            this.CollectionProdutoDocumentoTipoClassProduto.Remove(produtoDocumentoTipo);
            this.objetosDeletar.Add(produtoDocumentoTipo);

            this.ForceDirty();
        }

        public void ExcluirPostoTrabalho(ProdutoPostoTrabalhoClass produtoPosto, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("ExcluirPosto:" + produtoPosto.PostoTrabalho, caminhoLog);
            }
            if (!CollectionProdutoPostoTrabalhoClassProduto.Contains(produtoPosto))
            {
                string msgErro = "O posto de trabalho não foi encontrado para exclusão";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new ExcecaoTratada(msgErro);
            }

            this.CollectionProdutoPostoTrabalhoClassProduto.Remove(produtoPosto);
            this.objetosDeletar.Add(produtoPosto);

            this.ForceDirty();
        }

      

        public void CopiarEstrutura(ProdutoClass origem)
        {
            try
            {
                #region Filhos
                while (this.Filhos.Count > 0)
                {
                    this.ExcluirFilho(this.Filhos[0], null);
                }

                foreach (ProdutoPaiFilhoClass filho in origem.Filhos)
                {
                    this.CollectionProdutoPaiFilhoClassProdutoPai.Add(new ProdutoPaiFilhoClass(this.UsuarioAtual, this.SingleConnection)
                                                                          {
                                                                              ProdutoPai = this,
                                                                              ProdutoFilho = filho.ProdutoFilho,
                                                                              VersaoEstrutura = this.VersaoEstruturaCarregada,
                                                                              VersaoEstruturaFilho = filho.VersaoEstruturaFilho,
                                                                              PosicaoDesenhoPai = filho.PosicaoDesenhoPai,
                                                                              QuantidadeFilho = filho.QuantidadeFilho,
                                                                              SomaPreco = filho.SomaPreco
                                                                          }
                        );


                }
                #endregion

                #region Materiais
                while (this.Materiais.Count > 0)
                {

                    this.ExcluirMaterial(Materiais[0], null);
                }

                foreach (ProdutoMaterialClass filho in origem.Materiais)
                {
                    this.CollectionProdutoMaterialClassProduto.Add(new ProdutoMaterialClass(this.UsuarioAtual, this.SingleConnection)
                                                                       {
                                                                           Produto = this,
                                                                           VersaoEstrutura = this.VersaoEstruturaCarregada,
                                                                           Material = filho.Material,
                                                                           PlanoCorte = filho.PlanoCorte,
                                                                           Dimensao1 = filho.Dimensao1,
                                                                           Dimensao2 = filho.Dimensao2,
                                                                           Dimensao3 = filho.Dimensao3,
                                                                           PlanoCorteDimensao1 = filho.PlanoCorteDimensao1,
                                                                           PlanoCorteDimensao2 = filho.PlanoCorteDimensao2,
                                                                           PlanoCorteDimensao3 = filho.PlanoCorteDimensao3,
                                                                           PlanoCorteInformacoesAdicionais = filho.PlanoCorteInformacoesAdicionais,
                                                                           PlanoCorteQuantidade = filho.Quantidade,
                                                                           PostoTrabalhoCorte = filho.PostoTrabalhoCorte,
                                                                           QtdProdutoPorUnidade = filho.QtdProdutoPorUnidade,
                                                                           Quantidade = filho.Quantidade,
                                                                           UnidadeMedidaDimensao1 = filho.UnidadeMedidaDimensao1,
                                                                           UnidadeMedidaDimensao2 = filho.UnidadeMedidaDimensao2,
                                                                           UnidadeMedidaDimensao3 = filho.UnidadeMedidaDimensao3
                                                                       }
                        );


                }
                #endregion

                #region Documentos
                while (this.Documentos.Count > 0)
                {

                    this.ExcluirDocumento(Documentos[0], null);
                }

                foreach (ProdutoDocumentoTipoClass filho in origem.Documentos)
                {
                    this.CollectionProdutoDocumentoTipoClassProduto.Add(new ProdutoDocumentoTipoClass(this.UsuarioAtual, this.SingleConnection)
                                                                       {
                                                                           Produto = this,
                                                                           VersaoEstrutura = this.VersaoEstruturaCarregada,
                                                                           DocumentoTipoFamilia = filho.DocumentoTipoFamilia
                                                                           
                                                                       }
                        );


                }
                #endregion

                #region Recursos
                while (this.Recursos.Count > 0)
                {

                    this.ExcluirRecurso(Recursos[0], null);
                }

                foreach (ProdutoRecursoClass filho in origem.Recursos)
                {
                    this.CollectionProdutoRecursoClassProduto.Add(new ProdutoRecursoClass(this.UsuarioAtual, this.SingleConnection)
                                                                      {
                                                                          Produto = this,
                                                                          VersaoEstrutura = this.VersaoEstruturaCarregada,
                                                                          Recurso = filho.Recurso,
                                                                          Hierarquia = filho.Hierarquia

                                                                      }
                        );


                }
                #endregion

                #region Acabamento

                while (this.CollectionProdutoAcabamentoClassProduto.Count(a=>a.VersaoEstrutura==this.VersaoEstruturaCarregada) > 0)
                {
                    this.ExcluirAcabamento(this.CollectionProdutoAcabamentoClassProduto.First(a => a.VersaoEstrutura == this.VersaoEstruturaCarregada), null);
                }


                if (origem.AcabamentoEstruturaCarregada != null)
                {
                    this.CollectionProdutoAcabamentoClassProduto.Add(new ProdutoAcabamentoClass(this.UsuarioAtual, this.SingleConnection)
                                                                         {
                                                                             Acabamento = origem.AcabamentoEstruturaCarregada.Acabamento,
                                                                             Produto = this,
                                                                             VersaoEstrutura = this.VersaoEstruturaCarregada
                                                                         }
                        );
                }


                if (this.VersaoEstruturaCarregada == VersaoEstruturaAtual)
                {

                    this.Acabamento = this.AcabamentoEstruturaCarregada != null ? this.AcabamentoEstruturaCarregada.Acabamento : null;
                }

                #endregion

                this.ForceDirty();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao copiar a estrutura.\r\n" + e.Message, e);
            }
        }

        public void AdicionarFilho(ProdutoClass produtoAdicionar, double quantidade, string posicaoDesenhoPai, bool condicional, string condicionalRegra, bool qtdCondicional, string qtdCondicionalRegra, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("AdicionarFilho:" + produtoAdicionar.Codigo, caminhoLog);
            }
            if (this.Filhos.Count(a => a == produtoAdicionar) > 0)
            {
                string msgErro = "Esse produto (" + produtoAdicionar + ") já é filho do mesmo item (" + this + "), altere a quantidade ao invés de incluir outro.";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new Exception(msgErro);
            }

            ProdutoPaiFilhoClass pfNovo = new ProdutoPaiFilhoClass(this.UsuarioAtual, this.SingleConnection)
            {
                ProdutoPai = this,
                ProdutoFilho = produtoAdicionar,
                VersaoEstrutura = this.VersaoEstruturaCarregada,
                VersaoEstruturaFilho = produtoAdicionar.VersaoEstruturaCarregada,
                PosicaoDesenhoPai = posicaoDesenhoPai,
                QuantidadeFilho = quantidade,
                FilhoCondicional = condicional,
                FilhoCondicionalRegra = condicionalRegra,
                QtdCondicional = qtdCondicional,
                QtdCondicionalRegra = qtdCondicionalRegra

            };


            this.CollectionProdutoPaiFilhoClassProdutoPai.Add(pfNovo);

            this.ForceDirty();
        }

        public void AdicionarMaterial(MaterialClass material, double quantidade, bool planoCorte, double? planoCorteQuantidade, string planoCorteInformacoesAdicionais, PostoTrabalhoClass postoTrabalhoCorte, DimensaoClass dimensao1, string dimensao1Valor, UnidadeMedidaClass unidade1, DimensaoClass dimensao2, string dimensao2Valor, UnidadeMedidaClass unidade2, DimensaoClass dimensao3, string dimensao3Valor, UnidadeMedidaClass unidade3, bool condicional, string condicionaRegra, bool qtdCondicional, string qtdCondicionalRegra, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("AdicionarMaterial:" + material.CodigoComFamilia, caminhoLog);
            }
            if (this.Materiais.Count(a => a.Material == material) > 0)
            {
                string msgErro = "Esse material (" + material + ") já é filho do mesmo item (" + this + "), altere a quantidade ao invés de incluir outro.";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new Exception(msgErro);
                
            }

            ProdutoMaterialClass pmNovo = new ProdutoMaterialClass(this.UsuarioAtual, this.SingleConnection)
            {
                Produto = this,
                VersaoEstrutura = VersaoEstruturaCarregada,
                Material = material,
                Quantidade = quantidade,
                PlanoCorte = planoCorte,
                PlanoCorteQuantidade = planoCorteQuantidade,
                PlanoCorteInformacoesAdicionais = planoCorteInformacoesAdicionais,
                PostoTrabalhoCorte = postoTrabalhoCorte,
                Dimensao1 = dimensao1,
                PlanoCorteDimensao1 = dimensao1Valor,
                UnidadeMedidaDimensao1 = unidade1,
                Dimensao2 = dimensao2,
                PlanoCorteDimensao2 = dimensao2Valor,
                UnidadeMedidaDimensao2 = unidade2,
                Dimensao3 = dimensao3,
                PlanoCorteDimensao3 = dimensao3Valor,
                UnidadeMedidaDimensao3 = unidade3,
                QtdProdutoPorUnidade = 1.0 / quantidade,
                MaterialCondicional = condicional,
                MaterialCondicionalRegra = condicionaRegra,
                QtdCondicional = qtdCondicional,
                QtdCondicionalRegra = qtdCondicionalRegra
            };

            CollectionProdutoMaterialClassProduto.Add(pmNovo);
        }

        public void AdicionarDocumento(DocumentoTipoFamiliaClass documento, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("AdicionarDocumento:" + documento, caminhoLog);
            }
            if (this.Documentos.Count(a => a.DocumentoTipoFamilia == documento) > 0)
            {
                string msgErro = "Esse documento (" + documento + ") já é filho do mesmo item (" + this + ").";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new Exception(msgErro);
                
            }

            ProdutoDocumentoTipoClass pdNovo = new ProdutoDocumentoTipoClass(this.UsuarioAtual, this.SingleConnection)
            {
                Produto = this,
                DocumentoTipoFamilia = documento,
                VersaoEstrutura = VersaoEstruturaCarregada

            };


            CollectionProdutoDocumentoTipoClassProduto.Add(pdNovo);

            this.ForceDirty();
        }

        public void AdicionarRecurso(RecursoClass recurso, bool secundario, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("AdicionarRecurso:" + recurso, caminhoLog);
            }
            if (this.Recursos.Count(a => a.Recurso == recurso) > 0)
            {
                string msgErro = "Esse recurso (" + recurso + ") já é filho do mesmo item (" + this + ").";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new Exception(msgErro);
            
            }

            ProdutoRecursoClass prNovo = new ProdutoRecursoClass(this.UsuarioAtual, this.SingleConnection)
            {
                Produto = this,
                Recurso = recurso,
                VersaoEstrutura = VersaoEstruturaCarregada,
                Hierarquia = secundario ? HierarquiaRecursoEstrutura.Secundario : HierarquiaRecursoEstrutura.Primario

            };


            CollectionProdutoRecursoClassProduto.Add(prNovo);

            this.ForceDirty();
        }

        public void SemAcabamento(string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("Sem Acabamento", caminhoLog);
            }
            this.Acabamento = null;
        }
        public void AdicionarAcabamento(AcabamentoClass acabamento, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("AdicionarAcabamento:" + acabamento, caminhoLog);
            }
            if (this.AcabamentoEstruturaCarregada != null)
            {
                string msgErro = "Não é possível incluir mais do que um acabamento por item.";
                if (caminhoLog != null)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new Exception(msgErro);
                
            }

            ProdutoAcabamentoClass paNovo = new ProdutoAcabamentoClass(this.UsuarioAtual, this.SingleConnection)
            {
                Produto = this,
                Acabamento = acabamento,
                VersaoEstrutura = VersaoEstruturaCarregada
            };


            CollectionProdutoAcabamentoClassProduto.Add(paNovo);

            if (this.VersaoEstruturaCarregada == this.VersaoEstruturaAtual)
            {
                this.Acabamento = acabamento;
            }
            this.ForceDirty();

        }


        public void AdcionarPostoTrabalho(PostoTrabalhoClass posto, double tempoProducao, double tempoSetup, int sequencia, string caminhoLog)
        {
            if (caminhoLog != null)
            {
                IWTFunctions.LogClass.EscreverLog("AdicionarPosto:" + posto, caminhoLog);
            }
            ProdutoPostoTrabalhoClass ppNovo = new ProdutoPostoTrabalhoClass(this.UsuarioAtual, this.SingleConnection)
            {
                Produto = this,
                PostoTrabalho = posto,
                TempoProducao = tempoProducao,
                TempoSetup = tempoSetup,
                Sequencia = sequencia
            };



            if (CollectionProdutoPostoTrabalhoClassProduto.Any(a => a.Sequencia == sequencia))
            {
                foreach (ProdutoPostoTrabalhoClass postoTrabalho in CollectionProdutoPostoTrabalhoClassProduto.Where(a => a.Sequencia >= sequencia))
                {
                    postoTrabalho.Sequencia += 1;
                }
            }

            CollectionProdutoPostoTrabalhoClassProduto.Add(ppNovo);

            this.ForceDirty();
        }
        #endregion

        public bool getAlterado()
        {
            return this.IsDirty();
        }

        public void setAlterado(bool _alterado, bool propagarFilhos = false)
        {
            this.RemoveForcesDirtyAndClean();
            if (_alterado)
            {
                ForceDirty();
            }
            else
            {
                ForceClean();
            }


           
            if (propagarFilhos)
            {
                foreach (ProdutoPaiFilhoClass filho in Filhos)
                {
                    filho.ProdutoFilho.setAlterado(_alterado);
                }
            }
        }

        public void limparEstrutura(string caminhoLog)
        {
            IWTFunctions.LogClass.EscreverLog("InicioLimparEstrutura:" + this, caminhoLog);

            try
            {
                while (Filhos.Count>0)
                {
                    this.ExcluirFilho(Filhos[0], caminhoLog);
                }

                while (Materiais.Count > 0)
                {
                    this.ExcluirMaterial(Materiais[0], caminhoLog);
                }

                while (Recursos.Count > 0)
                {
                    this.ExcluirRecurso(Recursos[0], caminhoLog);
                }

                while (Documentos.Count > 0)
                {
                    this.ExcluirDocumento(Documentos[0], caminhoLog);
                }

                while (CollectionProdutoPostoTrabalhoClassProduto.Count > 0)
                {
                    this.ExcluirPostoTrabalho(CollectionProdutoPostoTrabalhoClassProduto[0], caminhoLog);
                }

                if (this.AcabamentoEstruturaCarregada!=null)
                {
                    this.ExcluirAcabamento(this.AcabamentoEstruturaCarregada, caminhoLog);
                }

                IWTFunctions.LogClass.EscreverLog("FimLimparEstrutura:" + this, caminhoLog);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao limpar a estrutura\r\n" + e.Message, e);
            }
        }

        public int getSugestaoLeadtime()
        {
            try
            {
                int mesesMedia = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
                DateTime dataFim = Configurations.DataIndependenteClass.GetData().Date;
                DateTime dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1 * mesesMedia);

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  CAST (ceil(AVG( public.lote.lot_data_recebimento - CAST (public.ordem_compra.orc_data_envio AS DATE))) AS INTEGER)  " +
                    "FROM " +
                    "  public.lote " +
                    "  INNER JOIN public.lote_solicitacao_compra ON (public.lote.id_lote = public.lote_solicitacao_compra.id_lote) " +
                    "  INNER JOIN public.solicitacao_compra ON (public.lote_solicitacao_compra.id_solicitacao_compra = public.solicitacao_compra.id_solicitacao_compra) " +
                    " INNER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                    "WHERE " +
                    "  public.lote.lot_data_recebimento BETWEEN :inicio AND :termino AND  " +
                    "  public.lote.id_produto = :id_produto ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("inicio", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataInicio;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("termino", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataFim;

                int? leadtimeCalculado = command.ExecuteScalar() as int?;

                return leadtimeCalculado ?? 0;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao identificar o leadtime sugerido\r\n" + e.Message, e);
            }
        }


        public IEnumerator<PedidoItemConfiguradoMaterialClass> GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public static List<ProdutoClass> SubstituirItemEstruturas(AbstractEntity origem, AbstractEntity substituto, TipoItemEstrutura tipo, string justificativa, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                List<ProdutoClass> toRet;

                switch (tipo)
                {
                    case TipoItemEstrutura.Produto:
                        toRet = SubstituirProdutoEstruturas((ProdutoClass) origem, (ProdutoClass) substituto, justificativa, ref command, usuario, conn);
                        break;
                    case TipoItemEstrutura.Material:
                        toRet = SubstituirMaterialEstruturas((MaterialClass)origem, (MaterialClass)substituto, justificativa, ref command, usuario, conn);
                        break;
                    case TipoItemEstrutura.Documento:
                        toRet = SubstituirDocumentoEstruturas((DocumentoTipoFamiliaClass)origem, (DocumentoTipoFamiliaClass)substituto, justificativa, ref command, usuario, conn);
                        break;
                    case TipoItemEstrutura.Recurso:
                        toRet = SubstituirRecursoEstruturas((RecursoClass)origem, (RecursoClass)substituto, justificativa, ref command, usuario, conn);
                        break;
                    case TipoItemEstrutura.Acabamento:
                        toRet = SubstituirAcabamentoEstruturas((AcabamentoClass)origem, (AcabamentoClass)substituto, justificativa, ref command, usuario, conn);
                        break;
                    case TipoItemEstrutura.PostoTrabalho:
                        throw new NotImplementedException();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(tipo), tipo, null);
                }

                command.Transaction.Commit();

                
                return toRet;

            }
            catch (ExcecaoTratada)
            {
                command?.Transaction?.Rollback();
                throw;
            }
            catch (Exception e)
            {
                command?.Transaction?.Rollback();
                throw new Exception("Erro inesperado ao substituir os itens das estruturas:" + e.Message, e);
            }
            finally
            {
                BufferAbstractEntity.limparBuffer();
            }

        }

        private static List<ProdutoClass> SubstituirProdutoEstruturas(ProdutoClass origem, ProdutoClass substituto, string justificativa,ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<ProdutoPaiFilhoClass> paisFilhos = new ProdutoPaiFilhoClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("ProdutoFilho", origem),
                    new SearchParameterClass("VersaoEstruturaFilho", origem.VersaoEstruturaAtual),
                    new SearchParameterClass("VersaoAtualPai", true)
                }).ConvertAll(a => (ProdutoPaiFilhoClass) a).ToList();

                foreach (ProdutoPaiFilhoClass paiFilho in paisFilhos)
                {
                    paiFilho.ProdutoFilho = substituto;
                    paiFilho.VersaoEstruturaFilho = substituto._versaoEstruturaAtualOriginal;
                    ProdutoRevisaoClass revisao = paiFilho.ProdutoPai.CollectionProdutoRevisaoClassProduto.LastOrDefault(a => a.VersaoEstrutura == paiFilho.ProdutoPai.VersaoEstruturaAtual);
                    if (revisao == null)
                    {
                        revisao = new ProdutoRevisaoClass(usuario, conn)
                        {
                            Produto = paiFilho.ProdutoPai,
                            Data = DataIndependenteClass.GetData(),
                            AcsUsuario = usuario,
                            Observacao = "Revisão anterior não registrada - Criada automaticamente",
                            Tipo = TipoRevisaoProduto.Estrutura,
                            VersaoEstrutura = paiFilho.ProdutoPai.VersaoEstruturaAtual,
                        };
                        paiFilho.ProdutoPai.CollectionProdutoRevisaoClassProduto.Add(revisao);
                        bool tmp = paiFilho.ProdutoPai.DesabilitarJustificativaRevisaoProduto;
                        try
                        {
                            paiFilho.ProdutoPai.DesabilitarJustificativaRevisaoProduto = true;
                            paiFilho.ProdutoPai.Save(ref command);
                        }
                        finally
                        {
                            paiFilho.ProdutoPai.DesabilitarJustificativaRevisaoProduto = tmp;
                        }
                    }
                    revisao.Observacao += "(Subsituição em massa de " + origem + " por " + substituto + " : " + justificativa + " )";

                    revisao.Save(ref command);
                    paiFilho.Save(ref command);
                }

                return paisFilhos.Select(a => a.ProdutoPai).ToList();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao substituir os produtos das estruturas:" + e.Message, e);
            }
            
        }

        private static List<ProdutoClass> SubstituirMaterialEstruturas(MaterialClass origem, MaterialClass substituto, string justificativa, ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<ProdutoMaterialClass> materiais = new ProdutoMaterialClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Material", origem),
                    new SearchParameterClass("VersaoAtualPai", true)
                }).ConvertAll(a => (ProdutoMaterialClass)a).ToList();

                foreach (ProdutoMaterialClass material in materiais)
                {
                    material.Material = substituto;
                    
                    ProdutoRevisaoClass revisao = material.Produto.CollectionProdutoRevisaoClassProduto.LastOrDefault(a => a.VersaoEstrutura == material.Produto.VersaoEstruturaAtual);
                    if (revisao == null)
                    {
                        revisao = new ProdutoRevisaoClass(usuario, conn)
                        {
                            Produto = material.Produto,
                            Data = DataIndependenteClass.GetData(),
                            AcsUsuario = usuario,
                            Observacao = "Revisão anterior não registrada - Criada automaticamente",
                            Tipo = TipoRevisaoProduto.Estrutura,
                            VersaoEstrutura = material.Produto.VersaoEstruturaAtual,
                        };
                        material.Produto.CollectionProdutoRevisaoClassProduto.Add(revisao);
                        bool tmp = material.Produto.DesabilitarJustificativaRevisaoProduto;
                        try
                        {
                            material.Produto.DesabilitarJustificativaRevisaoProduto = true;
                            material.Produto.Save(ref command);
                        }
                        finally
                        {
                            material.Produto.DesabilitarJustificativaRevisaoProduto = tmp;
                        }
                    }
                    revisao.Observacao += "(Subsituição em massa de " + origem + " por " + substituto + " : " + justificativa + " )";

                    revisao.Save(ref command);
                    material.Save(ref command);
                }

                return materiais.Select(a => a.Produto).ToList();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao substituir os materiais das estruturas:" + e.Message, e);
            }

        }

        private static List<ProdutoClass> SubstituirDocumentoEstruturas(DocumentoTipoFamiliaClass origem, DocumentoTipoFamiliaClass substituto, string justificativa, ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<ProdutoDocumentoTipoClass> documentos = new ProdutoDocumentoTipoClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("DocumentoTipoFamilia", origem),
                    new SearchParameterClass("VersaoAtualPai", true)
                }).ConvertAll(a => (ProdutoDocumentoTipoClass)a).ToList();

                foreach (ProdutoDocumentoTipoClass documento in documentos)
                {
                    documento.DocumentoTipoFamilia = substituto;

                    ProdutoRevisaoClass revisao = documento.Produto.CollectionProdutoRevisaoClassProduto.LastOrDefault(a => a.VersaoEstrutura == documento.Produto.VersaoEstruturaAtual);
                    if (revisao == null)
                    {
                        revisao = new ProdutoRevisaoClass(usuario, conn)
                        {
                            Produto = documento.Produto,
                            Data = DataIndependenteClass.GetData(),
                            AcsUsuario = usuario,
                            Observacao = "Revisão anterior não registrada - Criada automaticamente",
                            Tipo = TipoRevisaoProduto.Estrutura,
                            VersaoEstrutura = documento.Produto.VersaoEstruturaAtual,
                        };
                        documento.Produto.CollectionProdutoRevisaoClassProduto.Add(revisao);
                        bool tmp = documento.Produto.DesabilitarJustificativaRevisaoProduto;
                        try
                        {
                            documento.Produto.DesabilitarJustificativaRevisaoProduto = true;
                            documento.Produto.Save(ref command);
                        }
                        finally
                        {
                            documento.Produto.DesabilitarJustificativaRevisaoProduto = tmp;
                        }
                    }
                    revisao.Observacao += "(Subsituição em massa de " + origem + " por " + substituto + " : " + justificativa + " )";

                    revisao.Save(ref command);
                    documento.Save(ref command);
                }

                return documentos.Select(a => a.Produto).ToList();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao substituir os documentos das estruturas:" + e.Message, e);
            }

        }

        private static List<ProdutoClass> SubstituirRecursoEstruturas(RecursoClass origem, RecursoClass substituto, string justificativa, ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<ProdutoRecursoClass> recursos = new ProdutoRecursoClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Recurso", origem),
                    new SearchParameterClass("VersaoAtualPai", true)
                }).ConvertAll(a => (ProdutoRecursoClass)a).ToList();

                foreach (ProdutoRecursoClass recurso in recursos)
                {
                    recurso.Recurso = substituto;

                    ProdutoRevisaoClass revisao = recurso.Produto.CollectionProdutoRevisaoClassProduto.LastOrDefault(a => a.VersaoEstrutura == recurso.Produto.VersaoEstruturaAtual);
                    if (revisao == null)
                    {
                        revisao = new ProdutoRevisaoClass(usuario, conn)
                        {
                            Produto = recurso.Produto,
                            Data = DataIndependenteClass.GetData(),
                            AcsUsuario = usuario,
                            Observacao = "Revisão anterior não registrada - Criada automaticamente",
                            Tipo = TipoRevisaoProduto.Estrutura,
                            VersaoEstrutura = recurso.Produto.VersaoEstruturaAtual,
                        };
                        recurso.Produto.CollectionProdutoRevisaoClassProduto.Add(revisao);
                        bool tmp = recurso.Produto.DesabilitarJustificativaRevisaoProduto;
                        try
                        {
                            recurso.Produto.DesabilitarJustificativaRevisaoProduto = true;
                            recurso.Produto.Save(ref command);
                        }
                        finally
                        {
                            recurso.Produto.DesabilitarJustificativaRevisaoProduto = tmp;
                        }
                    }
                    revisao.Observacao += "(Subsituição em massa de " + origem + " por " + substituto + " : " + justificativa + " )";

                    revisao.Save(ref command);
                    recurso.Save(ref command);
                }

                return recursos.Select(a => a.Produto).ToList();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao substituir os recursos das estruturas:" + e.Message, e);
            }

        }

        private static List<ProdutoClass> SubstituirAcabamentoEstruturas(AcabamentoClass origem, AcabamentoClass substituto, string justificativa, ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<ProdutoAcabamentoClass> acabamentos = new ProdutoAcabamentoClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Acabamento", origem),
                    new SearchParameterClass("VersaoAtualPai", true)
                }).ConvertAll(a => (ProdutoAcabamentoClass)a).ToList();

                foreach (ProdutoAcabamentoClass acabamento in acabamentos)
                {
                    acabamento.Acabamento = substituto;

                    ProdutoRevisaoClass revisao = acabamento.Produto.CollectionProdutoRevisaoClassProduto.LastOrDefault(a => a.VersaoEstrutura == acabamento.Produto.VersaoEstruturaAtual);
                    if (revisao == null)
                    {
                        revisao = new ProdutoRevisaoClass(usuario, conn)
                        {
                            Produto = acabamento.Produto,
                            Data = DataIndependenteClass.GetData(),
                            AcsUsuario = usuario,
                            Observacao = "Revisão anterior não registrada - Criada automaticamente",
                            Tipo = TipoRevisaoProduto.Estrutura,
                            VersaoEstrutura = acabamento.Produto.VersaoEstruturaAtual,
                        };
                        acabamento.Produto.CollectionProdutoRevisaoClassProduto.Add(revisao);
                        bool tmp = acabamento.Produto.DesabilitarJustificativaRevisaoProduto;
                        try
                        {
                            acabamento.Produto.DesabilitarJustificativaRevisaoProduto = true;
                            acabamento.Produto.Save(ref command);
                        }
                        finally
                        {
                            acabamento.Produto.DesabilitarJustificativaRevisaoProduto = tmp;
                        }
                    }
                    revisao.Observacao += "(Subsituição em massa de " + origem + " por " + substituto + " : " + justificativa + " )";

                    revisao.Save(ref command);
                    acabamento.Save(ref command);
                }

                return acabamentos.Select(a => a.Produto).ToList();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao substituir os acabamentos das estruturas:" + e.Message, e);
            }

        }


        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
          SincronizarSDC(command.Connection);
        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            long idProdutoSimulador = ID + 10000000;
            ApiSimuladorCompras.SincronizarProduto(idProdutoSimulador, true, UsuarioAtual, command);
        }


        public void SincronizarSDC(IWTPostgreNpgsqlConnection conn)
        {
            StringBuilder erros = new StringBuilder();
            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            long idProdutoSimulador = ID + 10000000;

            if (Ativo && TipoAquisicao == TipoAquisicao.Comprado)
            {
                ProdutoDto dto = new ProdutoDto()
                {
                    id = idProdutoSimulador,
                    classificacao = "Produto",
                    codigo = Codigo,
                    descricao = Descricao,
                    unidadeMedidaId = UnidadeMedida.ID
                };

                ApiSimuladorCompras.SincronizarProduto(dto.id, false, UsuarioAtual, conn);


                foreach (ProdutoFornecedorClass fornecedor in CollectionProdutoFornecedorClassProduto)
                {
                    try
                    {
                        if (fornecedor.ID != -1)
                        {
                            fornecedor.SincronizarSDC(conn);
                        }
                    }
                    catch (Exception e)
                    {
                        erros.Append(e.Message);
                    }
                }

           
            }
            else
            {
                ApiSimuladorCompras.SincronizarProduto(idProdutoSimulador, true, UsuarioAtual, conn);
            }

            if (erros?.Length > 0)
            {
                throw new ExcecaoTratada(erros.ToString());
            }
        }

        public void BloquearPorPrecoVencido()
        {
            this.BloqueioPrecoVencido = true;
            bool valorDesabilitarJustificativaRevisaoProduto = this.DesabilitarJustificativaRevisaoProduto;

            try
            {
                this.DesabilitarJustificativaRevisaoProduto = true;
                this.Save();
            }
            finally
            {
                this.DesabilitarJustificativaRevisaoProduto = valorDesabilitarJustificativaRevisaoProduto;
            }

            
        }

        public void DesbloquearPorPrecoVencido()
        {
            this.BloqueioPrecoVencido = false;
            bool valorDesabilitarJustificativaRevisaoProduto = this.DesabilitarJustificativaRevisaoProduto;


            try
            {
                this.DesabilitarJustificativaRevisaoProduto = true;
                this.Save();
            }
            finally
            {
                this.DesabilitarJustificativaRevisaoProduto = valorDesabilitarJustificativaRevisaoProduto;
            }
        }
    }



}
