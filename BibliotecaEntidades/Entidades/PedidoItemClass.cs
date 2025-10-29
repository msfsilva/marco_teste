using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Operacoes.CalculoPreco;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.NFe;
using BibliotecaEntidades.Operacoes.VisualizacaoNf;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTLog;
using IWTNF;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTPostgreNpgsql;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using IWTNFIndicadorIE = IWTNF.Entidades.Base.IWTNFIndicadorIE;
using PresencaComprador = IWTNF.Entidades.Base.PresencaComprador;


namespace BibliotecaEntidades.Entidades 
{
    public class PedidoItemClass : PedidoItemBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do PedidoItemClass";
        protected new const string ErroDelete = "Erro ao excluir o PedidoItemClass  ";
        protected new const string ErroSave = "Erro ao salvar o PedidoItemClass.";
        protected new const string ErroCollectionPedidoItemQualidadeClassPedidoItem = "Erro ao carregar a coleção de PedidoItemQualidadeClass.";
        protected new const string ErroCollectionAtendimentoClassPedidoItem = "Erro ao carregar a coleção de AtendimentoClass.";
        protected new const string ErroCollectionNotificacaoDesvioClassPedidoItem = "Erro ao carregar a coleção de NotificacaoDesvioClass.";
        protected new const string ErroCollectionOrderItemEtiquetaClassPedidoItem = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
        protected new const string ErroCollectionPedidoKitClassPedidoItem = "Erro ao carregar a coleção de PedidoKitClass.";
        protected new const string ErroCollectionPedidoVariavelClassPedidoItem = "Erro ao carregar a coleção de PedidoVariavelClass.";
        protected new const string ErroCollectionPedidoItemVariavelClassPedidoItem = "Erro ao carregar a coleção de PedidoItemVariavelClass.";
        protected new const string ErroCollectionRepresentanteComissaoClassPedidoItem = "Erro ao carregar a coleção de RepresentanteComissaoClass.";
        protected new const string ErroCollectionPedidoItemLoteClienteClassPedidoItem = "Erro ao carregar a coleção de PedidoItemLoteClienteClass.";
        protected new const string ErroCollectionPedidoDocumentoClassPedidoItem = "Erro ao carregar a coleção de PedidoDocumentoClass.";
        protected new const string ErroCollectionSolicitacaoCompraPedidoClassPedidoItem = "Erro ao carregar a coleção de SolicitacaoCompraPedidoClass.";
        protected new const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
        protected new const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 255 caracteres";
        protected new const string ErroProdutoCodigoClienteObrigatorio = "O campo ProdutoCodigoCliente é obrigatório";
        protected new const string ErroProdutoCodigoClienteComprimento = "O campo ProdutoCodigoCliente deve ter no máximo 255 caracteres";
        protected new const string ErroProdutoDescricaoClienteObrigatorio = "O campo ProdutoDescricaoCliente é obrigatório";
        protected new const string ErroProdutoDescricaoClienteComprimento = "O campo ProdutoDescricaoCliente deve ter no máximo 255 caracteres";
        protected new const string ErroCnpjClienteObrigatorio = "O campo CnpjCliente é obrigatório";
        protected new const string ErroCnpjClienteComprimento = "O campo CnpjCliente deve ter no máximo 100 caracteres";
        protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
        protected new const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
        protected new const string ErroOperacaoObrigatorio = "O campo Operacao é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do PedidoItemClass.";
        protected new const string MensagemUtilizadoCollectionPedidoItemQualidadeClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemQualidadeClass:";
        protected new const string MensagemUtilizadoCollectionAtendimentoClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes AtendimentoClass:";
        protected new const string MensagemUtilizadoCollectionNotificacaoDesvioClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes NotificacaoDesvioClass:";
        protected new const string MensagemUtilizadoCollectionOrderItemEtiquetaClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
        protected new const string MensagemUtilizadoCollectionPedidoKitClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoKitClass:";
        protected new const string MensagemUtilizadoCollectionPedidoVariavelClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoVariavelClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemVariavelClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemVariavelClass:";
        protected new const string MensagemUtilizadoCollectionRepresentanteComissaoClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes RepresentanteComissaoClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemLoteClienteClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemLoteClienteClass:";
        protected new const string MensagemUtilizadoCollectionPedidoDocumentoClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoDocumentoClass:";
        protected new const string MensagemUtilizadoCollectionSolicitacaoCompraPedidoClassPedidoItem = "A entidade PedidoItemClass está sendo utilizada nos seguintes SolicitacaoCompraPedidoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade PedidoItemClass está sendo utilizada.";

        #endregion


        public PedidoItemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        protected override void InitClass()
        {
           
        }

        public string NumeroPosicao
        {
            get { return this.Numero + "/" + this.Posicao; }
        }


        public string StatusTraduzido
        {
            get { return this.Status.ToString(); }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public AbstractEntity ClassificacaoProduto
        {
            get { return this.Produto != null ? this.Produto.ClassificacaoProduto : null; }
        }

        private int? _semanaEntrega = null;
        
        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public int SemanaEntrega
        {
            get
            {
                if (!_semanaEntrega.HasValue)
                {
                    int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(this.DataEntrega, IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO), IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA));
                    this._semanaEntrega = Convert.ToInt32(this.DataEntrega.ToString("yy") + weekNum.ToString().PadLeft(2, '0'));
                }

                return this._semanaEntrega.Value;
            }
        }




        private NfPrincipalClass _ultimaNF = null;

        public string NumeroPedidoOriginal;
        public int PosPedidoOriginal;

  


        private List<AbstractEntity> EntidadesAvulsasSalvar = new List<AbstractEntity>();
        private double PrecoTotalAnterior;
        private double SaldoAnterior;
        private double QuantidadeAnterior;

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool Alterado
        {
            get { return base.IsDirty(); }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public int? UltimaNf
        {
            get
            {
                if (this._ultimaNF == null)
                {
                    AtendimentoClass att = this.CollectionAtendimentoClassPedidoItem.OrderByDescending(a => a.DataHora).FirstOrDefault();
                    if (att!=null)
                    {
                        this._ultimaNF = att.NfPrincipal;
                    }
                }
                return _ultimaNF != null ? _ultimaNF.Numero : (int?) null;
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public DateTime? DataUltimaNf
        {
            get
            {
                if (this._ultimaNF == null)
                {
                    this.UltimaNf.ToString();
                }
                return _ultimaNF != null ? _ultimaNF.DataEmissao : (DateTime?)null;
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public string FeedbackAtual
        {
            get
            {
                PedidoItemFeedbackClass feedback = this.CollectionPedidoItemFeedbackClassPedidoItem.OrderByDescending(a => a.Data).FirstOrDefault();
                if (feedback != null) return feedback.Texto;
                return "";
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public string FeedbackSecundarioAtual
        {
            get
            {
                PedidoItemFeedbackSecundarioClass feedback = this.CollectionPedidoItemFeedbackSecundarioClassPedidoItem.OrderByDescending(a => a.Data).FirstOrDefault();
                if (feedback != null) return feedback.Texto;
                return "";
            }
        }

        

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PossuiKit
        {
            get { return this.CollectionPedidoKitClassPedidoItem.Count > 0; }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public PedidoKitClass Kit
        {
            get { return this.CollectionPedidoKitClassPedidoItem.FirstOrDefault(); }
        }


         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool UtilizarResponsavelFreteDoProduto
        {
            get { return !this.ResponsavelFrete.HasValue; }
            set
            {
                if (value)
                {
                    this.ResponsavelFrete = null;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PossuiNcm
        {
            get { return Ncm != null; }
            set
            {
                if (!value)
                {
                    this.Ncm = null;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PossuiFormaPagamento
        {
            get { return this.FormaPagamento!=null; }
            set
            {
                if (!value)
                {
                    this.FormaPagamento = null;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PossuiCentroCustoLucro
        {
            get { return this.CentroCustoLucro != null; }
            set
            {
                if (!value)
                {
                    this.CentroCustoLucro = null;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PossuiContaBancaria
        {
            get { return this.ContaBancaria != null; }
            set
            {
                if (!value)
                {
                    this.ContaBancaria = null;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PossuiRepresentante
        {
            get { return this.Representante != null; }
            set
            {
                if (!value)
                {
                    this.Representante = null;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PossuiVendedor
        {
            get { return this.Vendedor != null; }
            set
            {
                if (!value)
                {
                    this.Vendedor = null;
                }
            }
        }



         [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public override double PrecoTotal
        {
            get { return this.PrecoUnitario*this.Quantidade; }
        }


        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public LoadClass TipoKitLoadClass
        {
            get
            {
                return this.Kit != null ? new LoadClass(this.Kit.TipoKit, this.Kit.TipoKit) : null;
            }

            set
            {
                this.SetKit(value == null ? null : value.id);
            }
        }


        public string SituacaoGadTraduzida
        {
            get
            {
                switch (SituacaoGad)
                {
                    case GadIntegracaoPedidoSituacao.SemGad:
                        return "Sem GAD";
                    case GadIntegracaoPedidoSituacao.Enviado:
                        return "Enviado - Ag. Processamento";
                    case GadIntegracaoPedidoSituacao.EmAnalise:
                        return "Em Análise";
                    case GadIntegracaoPedidoSituacao.Liberado:
                        return "Liberado";
                    case GadIntegracaoPedidoSituacao.Programado:
                        return "Programado";
                    case GadIntegracaoPedidoSituacao.Cancelado:
                        return "Cancelado";
                    case GadIntegracaoPedidoSituacao.ErroRecepcionarPedido:
                        return "Erro ao recepcionar pedido";
                    case GadIntegracaoPedidoSituacao.ErroNoPedido:
                        return "Erro no Pedido";
                    case GadIntegracaoPedidoSituacao.AguardandoEnvio:
                        return "Aguardando Envio";

                    default:
                        throw new ArgumentOutOfRangeException("SituacaoGadTraduzida", "Opção do Enum GadIntegracaoPedidoSituacao não reconhecida. " + SituacaoGad.ToString());
                }
            }
        }

        public string ProdutoDescricao
        {
            get { return Produto.Descricao; }
        }
        
        public bool ProdutoBloqueioPrecoVencido
        {
            get { return Produto.BloqueioPrecoVencido; }
        }

        public string ProgramacaoDataCriacao
        {
            get { return GadProgramacaoData; }
        }

        public string ProgramacaoNome
        {
            get { return GadProgramacaoNome; }
        }


        public string ProgramacaoSituacaoGad
        {
            get { return GadProgramado ? "Programado" : "Sem Programação"; }
        }


        public string ProgramacaoSituacaoGadMensagem
        {
            get { return ""; }
        }



        public string OperacaoList
        {
            get
            {
                if (!IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    return Operacao?.ToString();
                }

                return OperacaoCompleta?.ToString();
            }
        }

        public string OperacaoEnvioTerceirosList
        {
            get
            {
                if (!IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    return OperacaoEnvioTerceiros?.ToString();
                }

                return OperacaoCompletaEnvioTerceiros?.ToString();
            }
        }

        public string AplicacaoCliente
        {
            get { return Produto?.AplicacaoCliente?.Identificacao; }
        }

        public double PrecoFinal
        {
            get { return Math.Round(PrecoTotal - Desconto + Frete, 2); }
        }


        public string JustificativaAlteracaoAtual { get; set; }

        public override string ToString()
        {
            return this.Numero + "/" + this.Posicao.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaCompleta":

                    whereClause +=
                        " AND " +
                        " ( " +
                        " UPPER(pei_numero ||'/'|| pei_posicao) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToUpper() + "%' " +
                        " OR UPPER(pei_produto_codigo_cliente) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToUpper() + "%' " +
                        " OR UPPER(cla1.clp_identificacao) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToUpper() + "%' " +
                        " OR UPPER(cl1.cli_nome_resumido) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToUpper() + "%' " +
                        " OR UPPER(pei_projeto_cliente) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToUpper() + "%' " +
                        " OR UPPER(pdfee1.pif_texto) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToUpper() + "%' " +
                        " OR UPPER(pdfees1.pes_texto) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToUpper() + "%' " +
                        " OR UPPER(pei_obs_padrao_espelho) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToUpper() + "%' " +

                        " OR LOWER(pei_numero ||'/'|| pei_posicao) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToLower() + "%' " +
                        " OR LOWER(pei_produto_codigo_cliente) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToLower() + "%' " +
                        " OR LOWER(cla1.clp_identificacao) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToLower() + "%' " +
                        " OR LOWER(cl1.cli_nome_resumido) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToLower() + "%' " +
                        " OR LOWER(pei_projeto_cliente) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToLower() + "%' " +
                        " OR LOWER(pdfee1.pif_texto) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToLower() + "%' " +
                        " OR LOWER(pdfees1.pes_texto) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToLower() + "%' " +
                        " OR LOWER(pei_obs_padrao_espelho) LIKE '%" + parametro.Fieldvalue.ToString().Trim().ToLower() + "%' " +

                        ") ";

                    command.CommandText +=
                        "  INNER JOIN public.cliente cl1 ON (public.pedido_item.id_cliente = cl1.id_cliente) " +
                        "  LEFT OUTER JOIN public.produto pr1 ON pr1.id_produto = public.pedido_item.id_produto " +
                        "  LEFT OUTER JOIN public.classificacao_produto cla1 ON cla1.id_classificacao_produto = pr1.id_classificacao_produto " +
                        "  LEFT OUTER JOIN public.pedido_item_feedback pdfee1 ON (public.pedido_item.id_pedido_item = pdfee1.id_pedido_item AND pdfee1 .pif_atual = 1) "+
                        "  LEFT OUTER JOIN public.pedido_item_feedback_secundario pdfees1 ON (public.pedido_item.id_pedido_item = pdfees1.id_pedido_item AND pdfees1 .pes_atual = 1) ";
                    return true;

                case "Pendente":
                    if (parametro.Fieldvalue is bool)
                    {
                        whereClause += " AND (public.pedido_item.pei_status " + ((bool) parametro.Fieldvalue ? "=" : "<>") + " 0 ) ";
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Suspenso":
                    if (parametro.Fieldvalue is bool)
                    {
                        whereClause += " AND (public.pedido_item.pei_status " + ((bool) parametro.Fieldvalue ? "=" : "<>") + " 4 ) ";
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Encerrado":
                    if (parametro.Fieldvalue is bool)
                    {
                        whereClause += " AND (public.pedido_item.pei_status " + ((bool) parametro.Fieldvalue ? "=" : "<>") + " 1 ) ";
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Cancelado":
                    if (parametro.Fieldvalue is bool)
                    {
                        whereClause += " AND (public.pedido_item.pei_status " + ((bool) parametro.Fieldvalue ? "=" : "<>") + " 2 ) ";
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Reaberto":
                    if (parametro.Fieldvalue is bool)
                    {
                        whereClause += " AND (public.pedido_item.pei_status " + ((bool) parametro.Fieldvalue ? "=" : "<>") + " 3 ) ";
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Pendente_List":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool) parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_status = 0 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Suspenso_List":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool) parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_status = 4 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Encerrado_List":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool) parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_status = 1 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Cancelado_List":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool) parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_status = 2 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Reaberto_List":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool) parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_status = 3 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Todos_List":
                    if (parametro.Fieldvalue is bool)
                    {
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "MesEntrada":
                    if (parametro.Fieldvalue is int)
                    {
                        whereClause += " AND (date_part('month', pei_data_entrada) = :mes_entrada) ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mes_entrada", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = parametro.Fieldvalue;
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo int");
                    }
                    return true;
                case "AnoEntrada":
                    if (parametro.Fieldvalue is int)
                    {
                        whereClause += " AND (date_part('year', pei_data_entrada) = :ano_entrada) ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ano_entrada", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = parametro.Fieldvalue;
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo int");
                    }
                    return true;
                case "NumeroPedido":
                        whereClause += " AND (pedido_item.pei_numero = :numero_pedido_exato) ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("numero_pedido_exato", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = parametro.Fieldvalue;
                    return true;
                    break;
                case "RealizaFaturamentoFuturo":

                    if (parametro.Fieldvalue is bool)
                    {
                        if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                        {
                            command.CommandText += "  INNER JOIN public.operacao_completa op1 ON (public.pedido_item.id_operacao_completa = op1.id_operacao_completa) ";
                            whereClause += " AND (op1.opc_entrega_futura = :RealizaFaturamentoFuturo) ";

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("RealizaFaturamentoFuturo", NpgsqlDbType.Boolean, (bool) parametro.Fieldvalue));

                        }
                        else
                        {
                            command.CommandText +=  "  INNER JOIN public.operacao op1 ON (public.pedido_item.id_operacao = op1.id_operacao) ";
                            whereClause += " AND (op1.ope_entrega_futura = :RealizaFaturamentoFuturo) ";

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("RealizaFaturamentoFuturo", NpgsqlDbType.Smallint, ((bool)parametro.Fieldvalue ? 1 : 0)));
                        }

                        
                    }
                    else
                    {

                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo bool");
                    }
                    return true;

                case "Urgente_Normal":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool)parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_urgente = 0 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Urgente_Antecipacao":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool)parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_urgente =1 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Urgente_Urgente":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool)parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_urgente = 2 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;

                case "Urgente_Critico":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool)parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.pedido_item.pei_urgente = 3 ) ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo boolean");
                    }
                    return true;
                case "Entrada_Inicio":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND (public.pedido_item.pei_data_entrada >= :Entrada_Inicio ) ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Entrada_Inicio", NpgsqlDbType.Date, ((DateTime) parametro.Fieldvalue).Date));
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo data");
                    }
                    return true;
                case "Entrada_Fim":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND (public.pedido_item.pei_data_entrada < :Entrada_Fim ) ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Entrada_Fim", NpgsqlDbType.Date, ((DateTime) parametro.Fieldvalue).Date.AddDays(1)));
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo data");
                    }
                    return true;
                case "Entrega_Inicio":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND (public.pedido_item.pei_data_entrega >= :Entrega_Inicio ) ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Entrega_Inicio", NpgsqlDbType.Date, ((DateTime)parametro.Fieldvalue).Date));
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo data");
                    }
                    return true;
                case "Entrega_Fim":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND (public.pedido_item.pei_data_entrega < :Entrega_Fim ) ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Entrega_Fim", NpgsqlDbType.Date, ((DateTime)parametro.Fieldvalue).Date.AddDays(1)));
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro fornecido não é do tipo data");
                    }
                    return true;
                case "ProgramacaoNome":
                    parametro.ChangeFieldName("GadProgramacaoNome");
                    return false;
                case "ProgramacaoDataCriacao":
                    parametro.ChangeFieldName("GadProgramacaoData");
                    return false;


                case "SomenteConfigurados":
                    if ((bool) parametro.Fieldvalue)
                    {
                        whereClause += " AND (public.pedido_item.pei_configurado = 1) ";
                    }

                    return true;
                case "SomenteNaoConfigurados":
                    if ((bool) parametro.Fieldvalue)
                    {
                        whereClause += " AND (public.pedido_item.pei_configurado = 0) ";
                    }

                    return true;
                    

                case "SomenteComFeedback":
                    if ((bool) parametro.Fieldvalue)
                    {
                        command.CommandText += "  INNER JOIN public.pedido_item_feedback pifb1 ON (public.pedido_item.id_pedido_item = pifb1.id_pedido_item AND pifb1.pif_atual = 1) ";
                    }

                    return true;
                case "SomenteSemFeedback":
                    if ((bool) parametro.Fieldvalue)
                    {
                        command.CommandText += "  LEFT JOIN public.pedido_item_feedback pifb1 ON (public.pedido_item.id_pedido_item = pifb1.id_pedido_item AND pifb1.pif_atual = 1) ";
                        whereClause += " AND (pifb1.id_pedido_item_feedback IS NULL) ";
                    }

                    return true;

                case "SomenteComFeedbackSecundario":
                    if ((bool) parametro.Fieldvalue)
                    {
                        command.CommandText += "  INNER JOIN public.pedido_item_feedback_secundario pifb2 ON (public.pedido_item.id_pedido_item = pifb2.id_pedido_item AND pifb2.pes_atual = 1) ";
                    }

                    return true;
                case "SomenteSemFeedbackSecundario":
                    if ((bool) parametro.Fieldvalue)
                    {
                        command.CommandText += "  LEFT JOIN public.pedido_item_feedback_secundario pifb2 ON (public.pedido_item.id_pedido_item = pifb2.id_pedido_item AND pifb2.pes_atual = 1) ";
                        whereClause += " AND (pifb2.id_pedido_item_feedback_secundario IS NULL) ";
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
                case "ClassificacaoProduto":
                    command.CommandText += "  LEFT OUTER JOIN public.produto pr2 ON pr2.id_produto = public.pedido_item.id_produto " +
                                           "  LEFT OUTER JOIN public.classificacao_produto cla2 ON cla2.id_classificacao_produto = pr2.id_classificacao_produto ";

                    orderByClause += " , cla2.clp_identificacao " + ordenacao.ToString();
                    return true;

                case "AplicacaoCliente":
                    command.CommandText += "  LEFT OUTER JOIN public.produto pr2 ON pr2.id_produto = public.pedido_item.id_produto " +
                                           "  LEFT OUTER JOIN public.aplicacao_cliente apl2 ON apl2.id_aplicacao_cliente = pr2.id_aplicacao_cliente ";

                    orderByClause += " , apl2.apc_identificacao " + ordenacao.ToString();
                    return true;

                case "UltimaNf":
                    command.CommandText += 
                        " LEFT JOIN ("+
                        "     SELECT atend.*, nf1.nfp_numero FROM ( " +
                        "       SELECT        " +
                        "         atend.id_pedido_item, " +
                        "          atend.ate_data_hora, " +
                        "          atend.id_nf_principal, " +
                        "              rank() OVER w AS ran " +
                        "       FROM atendimento atend WINDOW w AS (PARTITION BY " +
                        "        atend.id_pedido_item ORDER BY ate_data_hora DESC, id_nf_principal DESC, atend.id_atendimento) " +
                        "         " +
                        "        ) atend  " +
                        "        LEFT JOIN nf_principal nf1 ON (nf1.id_nf_principal = atend.id_nf_principal) " +
                        "        WHERE ran = 1 " +
                        ") as ultima_nf ON ultima_nf.id_pedido_item = public.pedido_item.id_pedido_item ";


                    orderByClause += " , ultima_nf.nfp_numero " + ordenacao.ToString();
                    return true;
                    

                case "DataUltimaNf":
                    command.CommandText +=
                        " LEFT JOIN (" +
                        "     SELECT atend.*, nf1.nfp_numero FROM ( " +
                        "       SELECT        " +
                        "         atend.id_pedido_item, " +
                        "          atend.ate_data_hora, " +
                        "          atend.id_nf_principal, " +
                        "              rank() OVER w AS ran " +
                        "       FROM atendimento atend WINDOW w AS (PARTITION BY " +
                        "        atend.id_pedido_item ORDER BY ate_data_hora DESC, id_nf_principal DESC,atend.id_atendimento) " +
                        "         " +
                        "        ) atend  " +
                        "        LEFT JOIN nf_principal nf1 ON (nf1.id_nf_principal = atend.id_nf_principal) " +
                        "        WHERE ran = 1 " +
                        ") as ultima_nf ON ultima_nf.id_pedido_item = public.pedido_item.id_pedido_item ";


                    orderByClause += " , ultima_nf.ate_data_hora " + ordenacao.ToString();
                    return true;

                case "FeedbackAtual":
                    command.CommandText += " LEFT OUTER JOIN public.pedido_item_feedback pedido_feedback ON (public.pedido_item.id_pedido_item = pedido_feedback.id_pedido_item AND pedido_feedback.pif_atual = 1) ";
                    orderByClause += " , pedido_feedback.pif_texto " + ordenacao.ToString();
                    return true;

                case "FeedbackSecundarioAtual":
                    command.CommandText += " LEFT OUTER JOIN public.pedido_item_feedback_secundario pedido_feedback_secundario ON (public.pedido_item.id_pedido_item = pedido_feedback_secundario.id_pedido_item AND pedido_feedback_secundario.pes_atual = 1) ";
                    orderByClause += " , pedido_feedback_secundario.pes_texto " + ordenacao.ToString();
                    return true;

                case "NumeroPosicao":
                    orderByClause += " , pei_numero||'/'||pei_posicao " + ordenacao.ToString();
                    return true;

                case "StatusTraduzido":
                    orderByClause += " , CASE pei_status WHEN 0 THEN 'Pendente' WHEN 1 THEN 'Encerrado' WHEN 2 THEN 'Cancelado' WHEN 3 THEN 'Reaberto' WHEN 4 THEN 'Suspenso' END " + ordenacao.ToString();
                    return true;

                case "SemanaEntrega":
                    orderByClause += " , pei_data_entrega " + ordenacao.ToString();
                    return true;

                case "SituacaoGadTraduzida":
                    orderByClause += " , CASE pei_situacao_gad WHEN 0 THEN 'Sem GAD' WHEN 1 THEN 'Enviado - Ag. Processamento' WHEN 2 THEN 'Em Análise' WHEN 3 THEN 'Liberado' WHEN 4 THEN 'Programado' WHEN 5 THEN 'Cancelado' WHEN 6 THEN 'Erro ao recepcionar pedido' WHEN 7 THEN 'Erro no Pedido' ELSE '' END " + ordenacao.ToString();
                    return true;


                case "ProdutoDescricao":
                    command.CommandText += "  LEFT OUTER JOIN public.produto produtoProdutoDescricao ON produtoProdutoDescricao.id_produto = public.pedido_item.id_produto ";

                    orderByClause += " , produtoProdutoDescricao.pro_descricao " + ordenacao.ToString();
                    return true;

                case "ProgramacaoNome":
                    parametro.ChangeFieldName("GadProgramacaoNome");
                    return false;
                case "ProgramacaoDataCriacao":
                    parametro.ChangeFieldName("GadProgramacaoData");
                    return false;
                case "ProgramacaoSituacaoGad":
                    orderByClause += " , CASE pei_gad_programado WHEN 0 THEN 'Sem Programação' WHEN 1 THEN 'Programado' ELSE '' END " + ordenacao.ToString();
                    return true;
                case "ProgramacaoSituacaoGadMensagem":
                    return true;


                case "OperacaoList":
                    if (!IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                    {
                        command.CommandText += " LEFT OUTER JOIN public.operacao as OperacaoList ON (public.pedido_item.id_operacao = OperacaoList.id_operacao) ";
                        orderByClause += " , OperacaoList.ope_descricao " + ordenacao.ToString();
                    }
                    else
                    {
                        command.CommandText += " LEFT OUTER JOIN public.operacao_completa as OperacaoList ON (public.pedido_item.id_operacao_completa = OperacaoList.id_operacao_completa) ";
                        orderByClause += " , OperacaoList.opc_identificacao " + ordenacao.ToString();
                    }
                    return true;

                case "PrecoFinal":
                    orderByClause += " , (pei_preco_total - pei_desconto + pei_frete) " + ordenacao.ToString();
                   

                    return true;
                default:
                    return false;
            }
        }


        protected override void CalcularCamposAntesValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {
            if (this.Kit != null)
            {
                this.Kit.Cliente = Cliente;
            }

            if (Cliente != null)
            {
                this.CnpjCliente = Cliente.Cnpj;
            }


            #region Urgencia

            if (Urgente == UrgenciaPedido.Normal)
            {
                UrgenteSolicitante = null;
                UrgenteDataPrometida = null;
                UrgenteInformacoesComplementares = null;
            }

            #endregion

          
        }

        public void SalvarJustificativa(IWTPostgreNpgsqlCommand command)
        {

            if (SubLinha == 0 && IWTConfiguration.Conf.getBoolConf(Constants.HISTORICO_ALTERACOES_PEDIDO))
            {

                if (string.IsNullOrEmpty(JustificativaAlteracaoAtual))
                {
                    RevisaoCadastroForm formJustificativa =
                        new RevisaoCadastroForm("Sr(a). " + this.UsuarioAtual.Name + " (" +
                                                this.UsuarioAtual.Login +
                                                ") essa operação será registrada como uma revisão em seu nome. Você deseja prosseguir?");

                    formJustificativa.ShowDialog();

                    if (formJustificativa.Abortar)
                    {
                        throw new Exception("Operação abortada pelo usuário");
                    }

                    JustificativaAlteracaoAtual = formJustificativa.Justificativa;
                }

                if (string.IsNullOrWhiteSpace(JustificativaAlteracaoAtual))
                {
                    throw new ExcecaoTratada("Não é possível salvar a justificativa de alteração do pedido vazia");
                }

                CollectionPedidoItemHistoricoAlteracoesClassPedidoItem.Add(new PedidoItemHistoricoAlteracoesClass(UsuarioAtual, command == null?SingleConnection:command.Connection)
                {
                    Justificativa = JustificativaAlteracaoAtual,
                    Data = DateTime.Now,
                    Usuario = UsuarioAtual.Login,
                    PedidoItem = this

                });

                JustificativaAlteracaoAtual = null;
            }
        }

        protected override void CalcularCamposDepoisValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {


                if (this.ID != -1)
                {
                    double difQtd = this.Quantidade - QuantidadeAnterior;
                    if (difQtd + Saldo < 0)
                    {
                        throw new ExcecaoTratada("A nova quantidade é menor do que o quantidade já faturada do pedido (" + (QuantidadeAnterior - Saldo).ToString("F4", CultureInfo.CurrentCulture) + ") e por isso não pode ser utilizada)");
                    }

                    this.Saldo += difQtd;
                }
                else
                {
                    this.Saldo = Quantidade;
                }
            }
            catch
            {
                Saldo = SaldoAnterior;
                throw;
            }


            if (this.ID == -1)
            {
                if (Numero != NumeroPedidoOriginal || Posicao != PosPedidoOriginal)
                {
                    this.NumeroPedidoAutomatico = false;
                }
                else
                {
                    this.NumeroPedidoAutomatico = true;
                }

                this.DataEntregaOriginal = this.DataEntrega;
                this.PrecoTotalOriginal = this.PrecoTotal;
            }

            this.DataUltimaAlteracao = Configurations.DataIndependenteClass.GetData();

            #region Feedback

            List<PedidoItemFeedbackClass> feeds = CollectionPedidoItemFeedbackClassPedidoItem.OrderByDescending(a => a.Data).ToList();

            for (int i = 0; i < feeds.Count; i++)
            {
                PedidoItemFeedbackClass feedback = feeds[i];
                feedback.Atual = i == 0;
            }

            #endregion

            #region Feedback

            List<PedidoItemFeedbackSecundarioClass> feeds2 = CollectionPedidoItemFeedbackSecundarioClassPedidoItem.OrderByDescending(a => a.Data).ToList();

            for (int i = 0; i < feeds2.Count; i++)
            {
                PedidoItemFeedbackSecundarioClass feedback2 = feeds2[i];
                feedback2.Atual = i == 0;
            }

            #endregion



            if (Configurado)
            {
                if (Ncm != _ncmOriginal)
                {

                    
                    foreach (OrderItemEtiquetaClass orderItemEtiqueta in CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido)
                    {
                        if (Ncm != null)
                        {
                            orderItemEtiqueta.NbmPedido = Ncm.Codigo;
                        }
                        else
                        {
                            orderItemEtiqueta.NbmPedido = "";
                        }
                    }
                }
            }

        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {

          

            List<PedidoItemClass> ret = this.Search(new List<SearchParameterClass>()
                                                        {
                                                            new SearchParameterClass("NumeroPedido", Numero),
                                                            new SearchParameterClass("Posicao", Posicao),
                                                            new SearchParameterClass("Cliente", Cliente),
                                                            new SearchParameterClass("SubLinha", SubLinha)
                                                        }).ConvertAll(a => (PedidoItemClass) a);


            if (ret.Any(a => a.ID != this.ID))
            {
                throw new ExcecaoTratada("Já existe um pedido com o mesmo número e posição cadastrado para esse cliente.");
            }

            if (this.Status != StatusPedido.Cancelado)
            {
                if (this.SubLinha == 0 && this.PrecoTotal <= 0)
                {
                    throw new ExcecaoTratada("O pedido não pode ter valor zero.");
                }

                if (this.Quantidade <= 0)
                {
                    throw new ExcecaoTratada("O pedido não pode ter quantidade zero.");
                }
            }

           if (this.Produto.Cliente != null)
           {
               if (this.Produto.Cliente.FamiliaCliente != this.Cliente.FamiliaCliente)
               {
                   throw new ExcecaoTratada("O agrupador de clientes do produto (" + this.Produto.Cliente.FamiliaCliente.Nome + ") é diferente do agrupador do cliente do pedido ("+ this.Cliente.FamiliaCliente.Nome + "), a venda não pode ser realizada");
               }
           }

           if (!IWTConfiguration.Conf.getBoolConf(Constants.PERMITE_PEDIDO_SEM_OPERACAO))
           {
               if (Operacao == null && OperacaoCompleta == null)
               {
                   throw new ExcecaoTratada("A operação deve ser selecionada antes de continuar");
               }
           }


           if (EnvioTerceiros)
           {
               if (ClienteEnvioTerceiros == null)
               {
                   throw new ExcecaoTratada("Selecione o Cliente para Envio para Terceiros ou desabilite a função");
                }

               if (OperacaoEnvioTerceiros == null && OperacaoCompletaEnvioTerceiros == null)
               {
                   throw new ExcecaoTratada("A operação de envio para terceiros deve ser selecionada antes de continuar");
               }
            }
            

            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {


            #region Tratamento de alteração de preço na tabela

            if (this.Configurado && this.Status != StatusPedido.Cancelado && this.Status!=StatusPedido.Encerrado)
            {
                if (this.PrecoTotal != this.PrecoTotalAnterior)
                {
                    
                    string avisos;
                    string log;
                    CalculoPrecoClass calcula = new CalculoPrecoClass(this.SingleConnection, UsuarioAtual);
                    
                    double precoCalculado = calcula.calulaPrecoPedido(this.Numero,
                                                                      this.Posicao.ToString(CultureInfo.InvariantCulture),
                                                                      this.Cliente.ID.ToString(CultureInfo.InvariantCulture),
                                                                      out avisos, false, out log);


                    TabelaPrecoItemVariavelClass search = new TabelaPrecoItemVariavelClass(this.UsuarioAtual, this.SingleConnection);
                    List<TabelaPrecoItemVariavelClass> tabelasPrecoExistente = search.Search(new List<SearchParameterClass>()
                                                                                                 {
                                                                                                     new SearchParameterClass("OrderNumber", this.Numero),
                                                                                                     new SearchParameterClass("Pos", this.Posicao),
                                                                                                     new SearchParameterClass("Cliente", this.Cliente),
                                                                                                 }).ConvertAll(a => (TabelaPrecoItemVariavelClass) a);


                    
                   
                    if (tabelasPrecoExistente.Count>0)
                    {
                        tabelasPrecoExistente[0].Preco = precoCalculado;
                        for (int i=1; i<tabelasPrecoExistente.Count;i++)
                        {
                            this.adicionarObjetoDeletar(tabelasPrecoExistente[i]);

                        }
                    }
                    else
                    {
                        TabelaPrecoItemVariavelClass tab = new TabelaPrecoItemVariavelClass(this.UsuarioAtual, this.SingleConnection)
                                                               {
                                                                   OrderNumber = this.Numero,
                                                                   Pos = this.Posicao,
                                                                   Cliente = this.Cliente,
                                                                   Preco = precoCalculado

                                                               };
                        tab.Save(ref command);
                    }

                }
            }

            #endregion

            #region tratamento dos itens filhos

            this.AjustarItemVariavel();
            this.AjustarPedidoVariavel();
            this.AjustarPedidoKit();
            
            foreach (PedidoItemClass filho in CollectionPedidoItemClassPedidoItemPai)
            {
                filho.Numero = this.Numero;
                filho.Posicao = this.Posicao;
                filho.ProjetoCliente = this.ProjetoCliente;
                filho.Cliente = this.Cliente;
                filho.CnpjCliente = this.CnpjCliente;
                filho.ArmazenagemCliente = this.ArmazenagemCliente;
                filho.Frete = this.Frete;
                filho.DataEntrega = this.DataEntrega;
                filho.Status = this.Status;
                filho.Operacao = this.Operacao;
                filho.PermiteEntregaParcial = this.PermiteEntregaParcial;
                filho.VolumeUnico = this.VolumeUnico;
                filho.Exportacao = this.Exportacao;
                filho.Urgente = this.Urgente;
                filho.UrgenteSolicitante = this.UrgenteSolicitante;
                filho.UrgenteDataPrometida = this.UrgenteDataPrometida;
                filho.UrgenteInformacoesComplementares = this.UrgenteInformacoesComplementares;
                filho.DataEntregaOriginal = this.DataEntregaOriginal;
                filho.InformacaoEspecial = this.InformacaoEspecial;
                filho.RastreamentoMaterial = this.RastreamentoMaterial;
                filho.OrdemVenda = this.OrdemVenda;
                filho.DataEncerramento = this.DataEncerramento;
                filho.DataUltimaAlteracao = this.DataUltimaAlteracao;

                filho.AjustarItemVariavel();
                filho.AjustarPedidoVariavel();
                filho.AjustarPedidoKit();
            }
            #endregion


            foreach (AbstractEntity entity in EntidadesAvulsasSalvar)
            {
                entity.Save(ref command);
            }
            this.EntidadesAvulsasSalvar = new List<AbstractEntity>();
            this.SaldoAnterior = this.Saldo;
            this.PrecoTotalAnterior = PrecoTotal;
            this.QuantidadeAnterior = this.Quantidade;
        }

        private void AjustarPedidoKit()
        {
            foreach (PedidoKitClass kit in CollectionPedidoKitClassPedidoItem)
            {
                kit.Oc = this.Numero;
                kit.Pos = this.Posicao;
                kit.Cliente = this.Cliente;
            }
        }

        private void AjustarPedidoVariavel()
        {
            foreach (PedidoVariavelClass variavel in CollectionPedidoVariavelClassPedidoItem)
            {
                variavel.PedidoNumero = this.Numero;
                variavel.PedidoPosicao = this.Posicao;
                variavel.Cliente = this.Cliente;
            }
        }

        private void AjustarItemVariavel()
        {
            foreach (PedidoItemVariavelClass itemVariavel in CollectionPedidoItemVariavelClassPedidoItem)
            {
                itemVariavel.PedidoNumero = this.Numero;
                itemVariavel.PedidoPosicao = this.Posicao;
                itemVariavel.Cliente = this.Cliente;
                itemVariavel.SubLinha = this.SubLinha;
            }
        }

        public void SalvarComo()
        {
            this.limparLinhaSalvarComo();
            this.Save();
          
        }

        private void limparLinhaSalvarComo(PedidoItemClass pedidoPai = null)
        {

            if (!this._valueCollectionPedidoItemVariavelClassPedidoItemLoaded)
            {
                this.LoadCollectionPedidoItemVariavelClassPedidoItem();
            }

            if (!this._valueCollectionPedidoVariavelClassPedidoItemLoaded)
            {
                this.LoadCollectionPedidoVariavelClassPedidoItem();
            }

            if (!this._valueCollectionPedidoDocumentoClassPedidoItemLoaded)
            {
                this.LoadCollectionPedidoDocumentoClassPedidoItem();
            }

            if (!this._valueCollectionPedidoItemClassPedidoItemPaiLoaded)
            {
                this.LoadCollectionPedidoItemClassPedidoItemPai();
            }

            if (!this._valueCollectionPedidoKitClassPedidoItemLoaded)
            {
                this.LoadCollectionPedidoKitClassPedidoItem();
            }




            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;

            this.Status = StatusPedido.Pendente;
            this.DataEntregaOriginal = this.DataEntrega;
            this.Configurado = false;
            this.DataConfiguracao = null;
            this.DataEntrada = Configurations.DataIndependenteClass.GetData();

            this.DataCancelamento = null;
            this.JustificativaCancelamento = null;
            this.AcsUsuarioCancelamento = null;

            this.DataEncerramento = null;

            this.CollectionPedidoItemLoteClienteClassPedidoItem = new BindingList<PedidoItemLoteClienteClass>();
            this._valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded = true;
            
            this.CollectionOrderItemEtiquetaClassPedidoItem = new BindingList<OrderItemEtiquetaClass>();
            this._valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded = true;
            
            this.CollectionAtendimentoClassPedidoItem = new BindingList<AtendimentoClass>();
            this._valueCollectionAtendimentoClassPedidoItemLoaded = true;

            this.CollectionNotificacaoDesvioClassPedidoItem = new BindingList<NotificacaoDesvioClass>();
            this._valueCollectionNotificacaoDesvioClassPedidoItemLoaded = true;

            this.CollectionPedidoItemFeedbackClassPedidoItem = new BindingList<PedidoItemFeedbackClass>();
            this._valueCollectionPedidoItemFeedbackClassPedidoItemLoaded = true;

            this.CollectionPedidoItemFeedbackSecundarioClassPedidoItem = new BindingList<PedidoItemFeedbackSecundarioClass>();
            this._valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded = true;

            this.CollectionPedidoItemVolumeClassPedidoItem = new BindingList<PedidoItemVolumeClass>();
            this._valueCollectionPedidoItemVolumeClassPedidoItemLoaded = true;

            this.CollectionSolicitacaoCompraPedidoClassPedidoItem = new BindingList<SolicitacaoCompraPedidoClass>();
            this._valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded = true;

            this.CollectionPedidoItemQualidadeClassPedidoItem = new BindingList<PedidoItemQualidadeClass>();
            this._valueCollectionPedidoItemQualidadeClassPedidoItemLoaded = true;


            this.Saldo = this.Quantidade;

            foreach (PedidoItemVariavelClass itemVariavel in CollectionPedidoItemVariavelClassPedidoItem)
            {
                itemVariavel.LimparID(this);
            }

            foreach (PedidoVariavelClass variavel in CollectionPedidoVariavelClassPedidoItem)
            {
                variavel.LimparID(this);
            }

            foreach (PedidoDocumentoClass pedidoDocumento in CollectionPedidoDocumentoClassPedidoItem)
            {
                pedidoDocumento.LimparID(this);
            }

            foreach (PedidoItemClass subLinha in CollectionPedidoItemClassPedidoItemPai)
            {
                subLinha.limparLinhaSalvarComo(this);
            }

            if (this.Kit != null)
            {
                foreach (PedidoKitClass kit in CollectionPedidoKitClassPedidoItem)
                {
                    kit.LimparID(this);
                }
            }



            this.PedidoItemPai = pedidoPai;
        }

        public static void FaturarPedidos(List<PedidoItemClass> pedidos, out int numeroPallet, out long numeroEmbarque, IWTPostgreNpgsqlConnection singleConnection)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                AcsUsuarioClass usuario = pedidos[0].UsuarioAtual;
                IWTPostgreNpgsqlConnection conn = pedidos[0].SingleConnection;


                if (pedidos.Any(a => a.Operacao == null && a.OperacaoCompleta == null))
                {
                    throw new ExcecaoTratada("A operação dos pedidos deve ser selecionada antes do faturamento");
                }


                if (pedidos.Any(a=>!a.Configurado))
                {
                    throw new ExcecaoTratada("Para que seja possível realizar o faturamento direto o pedido deve estar configurado");
                }

                if (pedidos.Any(a => a.Status != StatusPedido.Pendente && a.Status != StatusPedido.Reaberto))
                {
                    throw new ExcecaoTratada("Para que seja possível realizar o faturamento direto o pedido deve estar pendente ou reaberto");
                }

                if (pedidos.Any(pedido => pedido.CollectionOrderItemEtiquetaClassPedidoItem.Any(orderItemEtiqueta => orderItemEtiqueta.CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Count != 0)))
                {
                    throw new ExcecaoTratada("Para que seja possível realizar o faturamento direto o pedido não pode possuir nenhuma conferência ou faturamento direto anterior");
                }


                //Identifica e trava um pallet livre
                PalletClass searchPallet = new PalletClass(usuario, conn);
                PalletClass pallet = (PalletClass) searchPallet.Search(new List<SearchParameterClass>()
                                                                           {
                                                                               new SearchParameterClass("Ocupado", false),
                                                                               new SearchParameterClass("Especial", false),
                                                                               new SearchParameterClass("Bloqueado", false),
                                                                               new SearchParameterClass("UtilizadoMomento", false),
                                                                               new SearchParameterClass("Numero", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Desc, TipoOrdenacao.Numerica)
                                                                           }).FirstOrDefault();

                if (pallet == null)
                {
                    throw new ExcecaoTratada("Não foi possível encontrar nenhum pallet simples, livre e não bloqueado para a incluir os pedidos");
                }

                pallet.UtilizadoMomento = true;
                pallet.Ocupado = true;
                pallet.IdUsuario = (int?) usuario.ID;
                pallet.Sequencia++;

                pallet.Save();
                numeroPallet = pallet.Numero;

                command = singleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                pallet.Fechado = true;
                pallet.Conferido = true;
                pallet.UtilizadoMomento = false;
                pallet.IdUsuario = null;

                pallet.Save(ref command);


                EmbarqueClass embarque = new EmbarqueClass(usuario, conn)
                                             {
                                                 DataHora = Configurations.DataIndependenteClass.GetData(),
                                                 LiberacaoHora = Configurations.DataIndependenteClass.GetData(),
                                                 LiberadoNf = true,
                                                 LiberacaoUsuario = usuario.ToString()
                                             };

                embarque.Save(ref command);
                numeroEmbarque = embarque.ID;

                //Simula a conferência dos pedidos, do pallet e a montagem do embarque
                foreach (PedidoItemClass pedido in pedidos)
                {
                    OrderItemEtiquetaClass searchOrderItemEtiqueta = new OrderItemEtiquetaClass(usuario, conn);
                    List<OrderItemEtiquetaClass> pedidoConfigurado = searchOrderItemEtiqueta.Search(new List<SearchParameterClass>()
                                                                                                        {
                                                                                                            new SearchParameterClass("OrderNumber", pedido.Numero),
                                                                                                            new SearchParameterClass("Cliente", pedido.Cliente),
                                                                                                            new SearchParameterClass("OrderPos", pedido.Posicao),
                                                                                                            new SearchParameterClass("NivelItem", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Numerica)
                                                                                                        }).ConvertAll(a => (OrderItemEtiquetaClass) a);

                    pedidoConfigurado = pedidoConfigurado.Where(a => (a.NotaFiscal == true && a.NivelItem == 0) || (a.EtiquetaInterna)).ToList();

                    if (pedidoConfigurado.Any(a=>a.SituacaoConferencia==SituacaoConferencia.Total))
                    {
                        throw new Exception("Não é possível faturar diretamente o pedido " + pedido + " pois ele já foi conferido.");
                    }

                    foreach (OrderItemEtiquetaClass orderItem in pedidoConfigurado)
                    {
                        orderItem.SaldoConferencia = 0;
                        orderItem.SituacaoConferencia = SituacaoConferencia.Total;



                        OrderItemEtiquetaConferenciaClass ocConf = new OrderItemEtiquetaConferenciaClass(usuario, conn)
                                                                       {
                                                                           OrderNumber = orderItem.OrderNumber,
                                                                           OrderPos = orderItem.OrderPos.Value,
                                                                           CodigoItem = orderItem.CodigoItem,
                                                                           QuantidadeConferida = orderItem.Saldo,
                                                                           DataConferencia = Configurations.DataIndependenteClass.GetData(),
                                                                           IdentificacaoEstacao = "FATURAMENTO DIRETO",
                                                                           OrderItemEtiqueta = orderItem,
                                                                           IdentificacaoUsuario = usuario.ToString(),
                                                                           Volumes = 1,
                                                                           ConferenciaPai = orderItem.NotaFiscal.Value,
                                                                           Pallet = (short) numeroPallet,
                                                                           PalletSequencia = pallet.Sequencia,
                                                                           PesoUnitario = orderItem.NotaFiscal.Value ? orderItem.Produto.PesoUnitario : 0,
                                                                           Embarque = embarque
                                                                       };

                        orderItem.CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Add(ocConf);

                        if (ocConf.ConferenciaPai)
                        {
                            orderItem.EtiquetaExpedicaoImpressa = true;
                            orderItem.Pallet = Convert.ToInt16(numeroPallet);
                            orderItem.SituacaoConferenciaNf = SituacaoConferencia.Total;

                            ocConf.ConferenciaPallet = true;
                            ocConf.ConferenciaPalletUsuario = usuario.ToString();
                            ocConf.ConferenciaPalletData = Configurations.DataIndependenteClass.GetData();
                            
                            OrderItemEtiquetaConferenciaNfClass ocConfNf = new OrderItemEtiquetaConferenciaNfClass(usuario, conn)
                                                                               {
                                                                                   OrderNumber = orderItem.OrderNumber,
                                                                                   OrderPos = orderItem.OrderPos.Value,
                                                                                   Pallet = (short) numeroPallet,
                                                                                   PalletSequencia = pallet.Sequencia,
                                                                                   QuantidadeConferida = orderItem.Saldo,
                                                                                   DataConferencia = Configurations.DataIndependenteClass.GetData(),
                                                                                   IdentificacaoEstacao = "FATURAMENTO DIRETO",
                                                                                   OrderItemEtiqueta = orderItem,
                                                                                   IdentificacaoUsuario = usuario.ToString()
                                                                               };

                            orderItem.CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta.Add(ocConfNf);
                        }

                        //Baixa de estoque dos itens que não são de NF
                        if (!orderItem.NotaFiscal.HasValue || !orderItem.NotaFiscal.Value)
                        {
                            try
                            {

                                //Verifica se o item é emite OP
                                //Se ele for KB quem manda é o cadastro do KB
                                //Caso contrário utilizar cadastro de produto

                                ProdutoClass Produto = orderItem.Produto;

                                bool EmiteOp = false;
                                double multiplicadorQuantidadeItemK = 1;

                                if (orderItem.ProdutoK == null)
                                {
                                    EmiteOp = Produto.EmiteOp;
                                }
                                else
                                {
                                    EmiteOp = orderItem.ProdutoK.EmiteOp;
                                    if (orderItem.ProdutoK.UtilizaDimensaoQuantidadeBaixa)
                                    {
                                        //Utiliza a dimensão do agrupador para indicar a quantidade de itens que devem ser baixados
                                        //do estoque por unidade do agrupador
                                        double tmp;

                                        if (double.TryParse(orderItem.ProdutoK.Dimensao, out tmp))
                                        {
                                            multiplicadorQuantidadeItemK = tmp;
                                        }
                                        else
                                        {
                                            throw new Exception("O item " + Produto.Codigo + " possui um item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                                        }
                                    }

                                }

                                if (EmiteOp)
                                {
                                    if (orderItem.ProdutoK == null)
                                    {

                                        //item Emite OP, baixa o item produzido
                                        EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                            Produto,
                                            orderItem.Saldo*-1*multiplicadorQuantidadeItemK,
                                            "Baixa de Produto Produzido no faturamento direto do pedido",
                                            "Pedido " + pedido.ToString(),
                                            usuario, false, ref command, false);
                                    }
                                    else
                                    {
                                        EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                           orderItem.ProdutoK,
                                           orderItem.Saldo * -1 * multiplicadorQuantidadeItemK,
                                           "Baixa de Produto Kb no faturamento direto do pedido",
                                           "Pedido " + pedido.ToString(),
                                           usuario, false, ref command);
                                    }
                                }
                                else
                                {
                                    //item é não emite OP, baixa os materiais ou  o produto comprado

                                    //Identifica se o item é comprado

                                    switch (Produto.TipoAquisicao)
                                    {
                                        case TipoAquisicao.Fabricado:

                                            //Verifica se existe estoque do produto acabado, se existir ele tem precedencia sobre a baixa de materiais
                                            double qtdBaixar = orderItem.Saldo*multiplicadorQuantidadeItemK;

                                            if (orderItem.ProdutoK == null)
                                            {

                                                double qtdEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(Produto, ref command);
                                                if (qtdEstoque > 0)
                                                {
                                                    if (qtdEstoque >= qtdBaixar)
                                                    {
                                                        EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                                            Produto,
                                                            qtdBaixar*-1,
                                                            "Baixa de produto acabado no faturamento direto do pedido",
                                                            "Pedido " + pedido,
                                                            usuario, false, ref command, false);
                                                        qtdBaixar = 0;
                                                    }
                                                    else
                                                    {
                                                        EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                                            Produto,
                                                            qtdEstoque*-1,
                                                            "Baixa de produto acabado no faturamento direto do pedido",
                                                            "Pedido " + pedido,
                                                            usuario, false, ref command, false);
                                                        qtdBaixar -= qtdEstoque;
                                                    }
                                                }
                                            }
                                            else
                                            {

                                                //Item KB
                                                double qtdEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProdutoK(orderItem.ProdutoK, ref command);
                                                if (qtdEstoque > 0)
                                                {
                                                    if (qtdEstoque >= qtdBaixar)
                                                    {
                                                        EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                                            orderItem.ProdutoK,
                                                            qtdBaixar*-1,
                                                            "Baixa de produto KB no faturamento direto do pedido",
                                                            "Pedido " + pedido,
                                                            usuario, false, ref command);
                                                        qtdBaixar = 0;
                                                    }
                                                    else
                                                    {
                                                        EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                                            orderItem.ProdutoK,
                                                            qtdEstoque*-1,
                                                            "Baixa de produto KB no faturamento direto do pedido",
                                                            "Pedido " + pedido,
                                                            usuario, false, ref command);
                                                        qtdBaixar -= qtdEstoque;
                                                    }
                                                }
                                            }


                                            if (qtdBaixar > 0)
                                            {
                                                foreach (ProdutoMaterialClass mat in Produto.CollectionProdutoMaterialClassProduto)
                                                {

                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoMaterial(
                                                        mat.Material,
                                                        -1*mat.Quantidade*qtdBaixar,
                                                        "Baixa de Materiais no faturamento direto do pedido",
                                                        "Pedido " + pedido,
                                                        usuario, false, ref command, false);

                                                }
                                            }
                                            break;

                                        case TipoAquisicao.Comprado:
                                            EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                                Produto,
                                                orderItem.Saldo*-1*multiplicadorQuantidadeItemK,
                                                "Baixa de Produto Comprado na Conferência",
                                                "Pedido " + pedido,
                                                usuario, false, ref command, false);
                                            break;


                                    }
                                }
                            }
                            catch (ExcecaoTratada)
                            {
                                throw;
                            }
                            catch (Exception e)
                            {
                                throw new ExcecaoTratada("Erro ao realizar a baixa de estoque dos materiais.\r\n" + e.Message, e);
                            }


                        }

                        orderItem.Save(ref command);
                    }

                }




                command.Transaction.Commit();

            }
            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new ExcecaoTratada("Erro inesperado ao faturar os pedidos diretamente\r\n" + e.Message, e);
            }
        }

        public void Suspender(string observacao)
        {
            try
            {
                if (this.Status!= StatusPedido.Pendente && this.Status!=StatusPedido.Reaberto)
                {
                    throw new ExcecaoTratada("Só é possível suspender um pedido pendente ou reaberto");
                }

                this.Status = StatusPedido.Suspenso;
                this.SuspensaoObs = observacao;
                this.AcsUsuarioResponsavelSuspensao = this.UsuarioAtual;

                if (this.Configurado)
                {
                    this.CollectionOrderItemEtiquetaClassPedidoItem[0].StatusPedido = "S";
                }

                this.Save();

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

        public void RemoverSuspencao(string observacao, bool salvar = true)
        {
            try
            {
                if (this.Status != StatusPedido.Suspenso)
                {
                    throw new ExcecaoTratada("Só é possível retirar de suspensão um pedido suspenso");
                }

                this.Status = StatusPedido.Pendente;
                this.SuspensaoObs = observacao;
                this.AcsUsuarioResponsavelSuspensao = this.UsuarioAtual;

                if (this.Configurado)
                {
                    this.CollectionOrderItemEtiquetaClassPedidoItem[0].StatusPedido = "P";
                }

                if (salvar)
                {
                    this.Save();
                }

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

        public void EncerrarSemSaldo(AcsUsuarioClass _acsUsuario)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = SingleConnection.CreateCommand();
                this.ExcluirPedidoPalletsAbertos(ref command);

                if (this.Saldo > 0)
                {
                    this.Quantidade = Quantidade - Saldo;
                }

                this.Status = StatusPedido.Encerrado;
                this.DataEncerramento = Configurations.DataIndependenteClass.GetData();
                this.Save(ref command);

                command.Transaction.Commit();
            }
            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new ExcecaoTratada("Erro ao encerrar o pedido sem saldo.\r\n" + e.Message, e);
            }
        }

        public void Encerrar(int numeroNF, int linhaNF, string CNPJEmitente, DateTime dataNF, AcsUsuarioClass usuario)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();


                this.ExcluirPedidoPalletsAbertos(ref command);

                CNPJEmitente = CNPJEmitente.Replace("/", "").Replace("-", "").Replace(".", "");

                NfPrincipalClass searchNf = new NfPrincipalClass(this.UsuarioAtual, this.SingleConnection);
                List<NfPrincipalClass> nfsEncontradas = searchNf.Search(new List<SearchParameterClass>()
                                                            {
                                                                new SearchParameterClass("Numero", numeroNF), new SearchParameterClass("CnpjEmitente", CnpjCliente)
                                                            }).ConvertAll(a => (NfPrincipalClass) a);



                if (nfsEncontradas.Any(a=>a.CollectionNfItemClassNfPrincipal.Any(b=>b.NumeroItem==linhaNF)))
                {
                    throw new Exception("Já existe uma nota fiscal com o mesmo número e linha cadastrada anteriormente");
                }


                NfPrincipalClass nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                {
                    Numero = numeroNF,
                    NaturezaOperacao = "Emissão Externa",
                    Serie = 1,
                    FormaPagamento = IWTNF.Entidades.Base.FormaPagamento.AVista,
                    ModeloDocFiscal = "XX",
                    DataEmissao = dataNF,
                    DataSaidaEntrada = dataNF,
                    Tipo = TipoNota.Saida,
                    CodMunicipioFatoGerador = 0,
                    FormatoImpressao = FormatoImpressao.Retrato,
                    FormaEmissao = FormaEmissaoNFe.Normal,
                    IdentificacaoAmbiente = 0,
                    FinalidadeEmissao = Finalidade.Normal,
                    ProcessoEmissao = Processo.ContribuinteAplicativoFisco,
                    VersaoProcessoEmissao = "XX",
                    Observacoes = "",
                    TipoEmitente = "P",
                    Situacao = "N"
                };

                NfEmitenteClass emitente = new NfEmitenteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                {
                    NfPrincipal = nf,
                    Razao = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_RAZAO),
                    NomeFantasia = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_RAZAO),
                    Ie = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_IE),
                    IeSt = "",
                    Im = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_IM),
                    Cnae = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CNAE),
                    CnpjCpf = CNPJEmitente,
                    Crt = 1
                };
                nf.NfEmitente = emitente;
                
                nf.CollectionNfItemClassNfPrincipal = new BindingList<NfItemClass>();

                nf.CollectionNfItemClassNfPrincipal.Add(new NfItemClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                {
                    NfPrincipal = nf, 
                    NumeroItem = linhaNF, 
                    Cfop = 0, 
                });

                string descricao = this.Numero + "/" + this.Posicao + " - " + this.ProdutoDescricaoCliente;
                if (descricao.Length > 60)
                {
                    descricao = descricao.Substring(0, 60);
                }

                //public NfProduto(NfItem nfItem, string nfpCodigo, string nfpDescricao, string nfpGtin, string nfpNcm, string nfpExtipi, string nfpGenero, string nfpUnidade, double nfpValorUnitario, string nfpGtimUnidadeTrinutacao,
                //string nfpUnidadeTributacao, double nfpValorUnitarioTrinutacao, double nfpQuantidadeTributavel, double nfpValorTotalTributavel, double nfpValorFrete, double nfpValorSeguro, double nfpValorDesconto, double nfpQuantidade)
                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto =
                    new NfProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                    {
                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                        Codigo = this.ProdutoCodigoCliente,
                        Descricao = descricao,
                        Gtin = "",
                        Ncm = "",
                        Extipi = "",
                        Genero = "",
                        Unidade = "UN",
                        ValorUnitario = this.PrecoUnitario,
                        GtimUnidadeTrinutacao = "",
                        UnidadeTributacao = "UN",
                        ValorUnitarioTrinutacao = this.PrecoUnitario,
                        QuantidadeTributavel = this.Saldo,
                        ValorTotalTributavel = Math.Round(this.PrecoTotal, 2),
                        ValorFrete = 0,
                        ValorSeguro = 0,
                        ValorDesconto = 0,
                        Quantidade = this.Saldo
                    };

                NfPrincipalClass.calculaNf(ref nf, ArredondamentoNF.NaoArredondarValores, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection ?? this.SingleConnection, null);
                nf.Save(ref command);



                AtendimentoClass atendimento = new AtendimentoClass(this.UsuarioAtual, this.SingleConnection)
                                                   {
                                                       NfPrincipal = nf,
                                                       Quantidade = this.Saldo,
                                                       Volumes = 1,
                                                       AtualizadoAccess = true,
                                                       GeradoInvoice = false,
                                                       Atlas = false,
                                                       LinhaNf = linhaNF,
                                                       OrderItemEtiquetaConferencia = null,
                                                       Usuario = this.UsuarioAtual.ToString(),
                                                       DataHora = Configurations.DataIndependenteClass.GetData(),
                                                       PedidoItem = this

                                                   };
                atendimento.OrderItemEtiqueta = this.CollectionOrderItemEtiquetaClassPedidoItem.FirstOrDefault(a => a.ItemOriginalPedido);


                this.CollectionAtendimentoClassPedidoItem.Add(atendimento);

                this.Saldo = 0;
                this.Status = StatusPedido.Encerrado;
                this.DataEncerramento = Configurations.DataIndependenteClass.GetData();

                this.Save(ref command);

                command.Transaction.Commit();
            }
            catch (Exception e)
            {

                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new ExcecaoTratada("Erro ao encerrar o pedido.\r\n" + e.Message, e);
            }

        }

        public void Cancelar(string Justificativa)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                this.Cancelar(Justificativa, command);

                command.Transaction.Commit();
            }
            catch
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
        }

        public void Cancelar(string Justificativa, IWTPostgreNpgsqlCommand command)
        {

            try
            {
                if (Justificativa.Trim().Length < 10)
                {
                    throw new Exception("O campo de justicativa deve conter pelo menos 10 caracteres válidos.");
                }

                VerificarOPsAbertas(ref command);


                this.ExcluirPedidoPalletsAbertos(ref command);

                if (this.Status == StatusPedido.Suspenso)
                {
                    this.RemoverSuspencao("Pedido Cancelado: " + Justificativa, false);
                }


                this.DataCancelamento = Configurations.DataIndependenteClass.GetData();
                this.AcsUsuarioCancelamento = this.UsuarioAtual;
                this.JustificativaCancelamento = Justificativa.Trim();
                this.Status = StatusPedido.Cancelado;


                for (var i = 0; i < CollectionPedidoItemLoteClienteClassPedidoItem.Count; i++)
                {
                    PedidoItemLoteClienteClass pedidoItemLoteCliente = CollectionPedidoItemLoteClienteClassPedidoItem[i];
                    if (pedidoItemLoteCliente.SaldoDevolucao > 0)
                    {
                        if (Math.Abs(pedidoItemLoteCliente.SaldoDevolucao - pedidoItemLoteCliente.Quantidade) < 0.000001)
                        {
                            ExcluirLoteCliente(pedidoItemLoteCliente);
                            i--;
                        }
                        else
                        {
                            ExcluirSaldoLoteCliente(pedidoItemLoteCliente);
                        }
                    }
                }


                this.Save(ref command);


                if (this.Configurado)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.UsuarioAtual.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_justificativa_cancelamento", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Justificativa.Trim();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_numero", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_posicao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Posicao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Cliente.ID;




                    command.CommandText =
                        "UPDATE order_item_etiqueta SET " +
                        " oie_status_pedido = 'C' " +
                        "WHERE " +
                        " oie_order_number = :pei_numero AND " +
                        " oie_order_pos = :pei_posicao AND " +
                        " ((id_cliente = :id_cliente AND oie_item_original_pedido = 1) OR (id_cliente IS NULL AND oie_item_original_pedido = 0))";

                    command.ExecuteNonQuery();



                    command.CommandText =

                        "DELETE FROM order_item_etiqueta_conferencia WHERE id_order_item_etiqueta_conferencia IN (" +
                        "SELECT " +
                        "  order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia " +
                        "FROM " +
                        "  public.order_item_etiqueta_conferencia " +
                        "  INNER JOIN public.order_item_etiqueta ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                        "WHERE " +
                        "  public.order_item_etiqueta_conferencia.oic_order_number = :oic_order_number AND  " +
                        "  public.order_item_etiqueta_conferencia.oic_order_pos = :oic_order_pos AND  " +
                        "  public.order_item_etiqueta.id_cliente = :id_cliente AND " +
                        "  public.order_item_etiqueta_conferencia.oic_nf_emitida = 0 " +
                        ")";

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_order_number", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_order_pos", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Posicao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Cliente.ID;

                    command.ExecuteNonQuery();


                }




            }
            catch (Exception a)
            {
                throw new Exception("Erro ao cancelar o Pedido\r\n" + a.Message, a);
            }

        }

        private void VerificarOPsAbertas(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                OrderItemEtiquetaClass searchOrderItemEtiqueta = new OrderItemEtiquetaClass(UsuarioAtual, command.Connection);
                List<OrderItemEtiquetaClass> pedidoConfigurados = searchOrderItemEtiqueta.Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("OrderNumber", Numero),
                    new SearchParameterClass("Cliente", Cliente),
                    new SearchParameterClass("OrderPos", Posicao),
                    new SearchParameterClass("NivelItem", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Numerica)
                }).ConvertAll(a => (OrderItemEtiquetaClass) a);

                string opsAbertasString = "";
                foreach (OrderItemEtiquetaClass pedidoConfigurado in pedidoConfigurados)
                {
                    List<OrdemProducaoPedidoClass> opsAbertas =
                        pedidoConfigurado.CollectionOrdemProducaoPedidoClassOrderItemEtiqueta.Where(a => a.OrdemProducao.Situacao != StatusOrdemProducao.Cancelada && a.OrdemProducao.Situacao != StatusOrdemProducao.Encerrada).ToList();

                    opsAbertasString = opsAbertas.Aggregate(opsAbertasString, (current, aberta) => current + (", " + aberta.OrdemProducao.ID));
                }
                if (opsAbertasString.Length > 0)
                {
                    throw new ExcecaoTratada("Não é possível cancelar o pedido pois as seguintes OPs estão em aberto, encerre ou cancele as mesmas antes de continuar: " + opsAbertasString.Substring(2));
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao cancelar as ops abertas do pedido.\r\n" + e.Message, e);
            }
        }

        private void ExcluirPedidoPalletsAbertos(ref IWTPostgreNpgsqlCommand command)
        {

            try
            {

                IWTPostgreNpgsqlDataReader read;


                //busca os pallets e sequencias onde o pedido está e não foi faturado ainda
                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet, " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet_sequencia " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                    "WHERE " +
                    "  public.order_item_etiqueta.oie_order_number = :oie_order_number AND  " +
                    "  public.order_item_etiqueta.oie_order_pos = :oie_order_pos AND  " +
                    "  public.order_item_etiqueta.id_cliente = :id_cliente AND  " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pai = 1 AND " +
                    "  public.order_item_etiqueta_conferencia.oic_nf_emitida = 0 ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_order_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Posicao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Cliente.ID;
                read = command.ExecuteReader();
                List<string[]> pallets = new List<string[]>();
                while (read.Read())
                {
                    pallets.Add(new[] {read["oic_pallet"].ToString(), read["oic_pallet_sequencia"].ToString()});
                }
                read.Close();
                List<int> idsEmbarques = new List<int>();
                foreach (string[] pallet in pallets)
                {
                    string numPallet = pallet[0];
                    string sequencia = pallet[1];

                    //Buscar quantidades baixadas
                    command.CommandText = "SELECT  " +
                                          "  public.order_item_etiqueta_conferencia.oic_quantidade_conferida, " +
                                          "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia, " +
                                          "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta, " +
                                          "  public.order_item_etiqueta_conferencia.id_embarque "+
                                          "FROM " +
                                          "  public.order_item_etiqueta_conferencia " +
                                          "  INNER JOIN public.pallet ON (public.order_item_etiqueta_conferencia.oic_pallet = public.pallet.pal_numero) " +
                                          "  AND (public.order_item_etiqueta_conferencia.oic_pallet_sequencia = public.pallet.pal_sequencia) " +
                                          "WHERE " +
                                          "  public.pallet.pal_numero = " + numPallet + " AND pal_sequencia=" +
                                          sequencia + " AND oic_order_number='" + this.Numero + "' AND oic_order_pos=" + this.Posicao +
                                          ";";

                    read = command.ExecuteReader();
                    string sql = "";
                    
                    while (read.Read())
                    {
                        int? idEmbarque = read["id_embarque"] as int?;
                        if (idEmbarque.HasValue && !idsEmbarques.Contains(idEmbarque.Value))
                        {
                            idsEmbarques.Add(idEmbarque.Value);
                        }

                        //devolver status conferencia
                        //devolver saldo conferencia
                        sql +=
                            "UPDATE order_item_etiqueta SET oie_situacao_conferencia=1, oie_pallet = NULL, oie_situacao_conferencia_nf = 0, oie_saldo_conferencia = oie_saldo_conferencia + " +
                            Convert.ToDouble(read["oic_quantidade_conferida"]).ToString("F2",
                                CultureInfo.InvariantCulture) +
                            " WHERE id_order_item_etiqueta=" + read["id_order_item_etiqueta"] + "; ";

                        //remover conferencia 
                        sql +=
                            "DELETE FROM public.order_item_etiqueta_conferencia WHERE id_order_item_etiqueta_conferencia=" +
                            read["id_order_item_etiqueta_conferencia"] + "; ";

                        if (!IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET))
                        {
                            //remover as linhas da conf de pallet
                            sql +=
                                "DELETE FROM " +
                                "  public.order_item_etiqueta_conferencia_nf  " +
                                "WHERE  " +
                                "  id_order_item_etiqueta = " + read["id_order_item_etiqueta"] + "; ";
                        }

                    }

                    if (IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET))
                    {
                        //remover todas conferencia nf
                        sql +=
                            "DELETE FROM " +
                            "  public.order_item_etiqueta_conferencia_nf  " +
                            "WHERE  " +
                            "  oin_pallet = " + numPallet + " AND oin_pallet_sequencia= " + sequencia + "; ";



                        //reabrir pallet para conferencia
                        sql += "UPDATE pallet SET pal_conferido=0 WHERE pal_numero=" + numPallet + "; ";

                        //liberar a conferencia de pallet para os outros itens
                        sql += "UPDATE order_item_etiqueta_conferencia SET oic_conferencia_pallet=0, oic_conferencia_pallet_usuario = NULL,oic_conferencia_pallet_data = NULL  WHERE oic_pallet = " +
                               numPallet + " AND oic_pallet_sequencia=" + sequencia + "; ";
                    }

                    read.Close();

                    command.CommandText = sql;
                    command.ExecuteNonQuery();




                    //teste pallet vazio
                    command.CommandText = "SELECT  " +
                                          "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia " +
                                          "FROM " +
                                          "  public.order_item_etiqueta_conferencia " +
                                          "  INNER JOIN public.pallet ON (public.order_item_etiqueta_conferencia.oic_pallet = public.pallet.pal_numero) " +
                                          "  AND (public.order_item_etiqueta_conferencia.oic_pallet_sequencia = public.pallet.pal_sequencia) " +
                                          "WHERE " +
                                          "  public.pallet.pal_numero = " + numPallet + " AND pal_sequencia=" +
                                          sequencia + ";";

                    read = command.ExecuteReader();
                    if (!read.HasRows)
                    {
                        read.Close();
                        command.CommandText =
                            "UPDATE pallet SET pal_ocupado = 0, pal_fechado=0, pal_conferido=0 WHERE public.pallet.pal_numero = " +
                            numPallet + " AND pal_sequencia=" + sequencia + ";";

                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        read.Close();
                    }

                }

                command.CommandText = "SELECT id_order_item_etiqueta_conferencia FROM order_item_etiqueta_conferencia WHERE id_embarque = :id_embarque ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_embarque", NpgsqlDbType.Integer));

                string sqlClearEmbarque = null;

                foreach (int idEmbarque in idsEmbarques)
                {
                    command.Parameters["id_embarque"].Value = idEmbarque;    
                    read = command.ExecuteReader();

                    if (read.HasRows)
                    {
                        read.Close();
                        continue;
                    }

                    read.Close();
                    sqlClearEmbarque += "DELETE FROM embarque WHERE id_embarque = " + idEmbarque + "; ";
                }

                if (!string.IsNullOrEmpty(sqlClearEmbarque))
                {
                    command.CommandText = sqlClearEmbarque;
                    command.ExecuteNonQuery();
                }



            }
            catch (Exception e)
            {


                throw new Exception("Erro inesperado ao remover os itens já conferidos do pallet.\r\n" + e.Message);

            }



        }

        public static void CarregarNumeroPedidoAutomatico(IWTPostgreNpgsqlConnection conn, out string numero, out int pos)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  COALESCE(MAX(CAST (public.pedido_item.pei_numero AS BIGINT)),0) " +
                    "FROM " +
                    "  public.pedido_item " +
                    "WHERE " +
                    "  public.pedido_item.pei_numero_pedido_automatico = 1 ";
                Int64 maiorPedido = Convert.ToInt64(command.ExecuteScalar());

                command.CommandText =
                   "SELECT  " +
                   "  COALESCE(MAX(CAST (public.orcamento_item.ori_numero AS BIGINT)),0) " +
                   "FROM " +
                   "  public.orcamento_item " +
                   "WHERE " +
                   "  public.orcamento_item.ori_numero_pedido_automatico = 1 ";
                Int64 maiorOrcamento = Convert.ToInt64(command.ExecuteScalar());




                Int64 numeroOriginal = (Math.Max(maiorPedido, maiorOrcamento) + 1);
                numero = numeroOriginal.ToString(CultureInfo.InvariantCulture).PadLeft(10, '0');

                PedidoItemClass search = new PedidoItemClass(LoginClass.UsuarioLogado.loggedUser,conn);
                while (search.Search(new List<SearchParameterClass>() { new SearchParameterClass("NumeroPedido", numero) }).Any())
                {
                    numeroOriginal++;
                    numero = numeroOriginal.ToString(CultureInfo.InvariantCulture).PadLeft(10, '0');
                }


                pos = 1;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o número do pedido/orçamento automaticamente.\r\n" + e.Message, e);
            }
        }

        public void SetKit(string tipoKit)
        {

            this.ForceDirty();

            if (this.Kit == null && !string.IsNullOrEmpty(tipoKit))
            {
                //Criar um Pedido Kit
                this.CollectionPedidoKitClassPedidoItem.Add(new PedidoKitClass(this.UsuarioAtual, this.SingleConnection)
                {
                    Oc = this.Numero, 
                    Pos = this.Posicao, 
                    TipoKit = tipoKit, 
                    Cliente = this.Cliente, 
                    PedidoItem = this
                });
                return;
                
            }

            if (this.Kit != null && !string.IsNullOrEmpty(tipoKit))
            {
                //Alterar um Pedido Kit
                this.Kit.TipoKit = tipoKit;
                return;

            }


            if (string.IsNullOrEmpty(tipoKit))
            {

                for (int i = 0; i < CollectionPedidoKitClassPedidoItem.Count; i++)
                {
                    PedidoKitClass pedidoKitClass = CollectionPedidoKitClassPedidoItem[i];
                    this.adicionarObjetoDeletar(pedidoKitClass);
                    CollectionPedidoKitClassPedidoItem.RemoveAt(i);
                    i--;
                }
            }


        }

        public void AddLoteCliente(LoteClass lote, double quantidade)
        {
            try
            {
                if (lote.SaldoDevolucao < quantidade)
                {
                    throw new ExcecaoTratada("O lote não tem saldo de vinculação com o pedido suficiente para a quantidade selecionada");
                }


                PedidoItemLoteClienteClass lotePedido = this.CollectionPedidoItemLoteClienteClassPedidoItem.FirstOrDefault(a => a.Lote == lote);

                if (lotePedido==null)
                {
                    lotePedido = new PedidoItemLoteClienteClass(this.UsuarioAtual, this.SingleConnection)
                    {
                        PedidoItem = this,
                        Lote = lote,
                        Quantidade = 0,
                        SaldoDevolucao = 0
                    };
                    this.CollectionPedidoItemLoteClienteClassPedidoItem.Add(lotePedido);
                }

                lotePedido.AlterarQuantidadePedido(quantidade);
                if (!this.EntidadesAvulsasSalvar.Contains(lotePedido.Lote))
                {
                    this.EntidadesAvulsasSalvar.Add(lotePedido.Lote);
                }

                this.ForceDirty();


                try
                {


                    string dados = "Pedido: " + this.NumeroPosicao + "; ID:" + ID + ";Lote" + lote.ID + ";Quantidade:" + quantidade;

                    Log.Registrar(IWTLogSeveridade.Info, "ADICIONAR-LOTE", this.GetType().ToString(), "Adicionar", dados, SingleConnection.ConnectionString);
                }
                catch { }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o lote do cliente.\r\n" + e.Message, e);
            }
        }

        public void ExcluirLoteCliente(PedidoItemLoteClienteClass loteCliente)
        {
        
            if (loteCliente==null)
            {
                throw new ExcecaoTratada("Não foi possível encontrar o lote no pedido para excluir.");
            }

            if (loteCliente.OpsUtilizandoPedidoLote.Count>0){

                throw new ExcecaoTratada("Não é possível excluir um lote que já está sendo utilizado por uma OP");
            }

            if (Math.Abs(loteCliente.Quantidade - loteCliente.SaldoDevolucao) > 0.000001)
            {
                throw new ExcecaoTratada("Não é possível excluir o lote pois ele já teve itens devolvidos (faturados)");
            }

            loteCliente.Lote.VinculaLoteClienteAoPedido(-1 * loteCliente.Quantidade);

            this.EntidadesAvulsasSalvar.Add(loteCliente.Lote);
            loteCliente.Lote.CollectionPedidoItemLoteClienteClassLote.Remove(loteCliente);

            this.adicionarObjetoDeletar(loteCliente);

            this.CollectionPedidoItemLoteClienteClassPedidoItem.Remove(loteCliente);
            this.ForceDirty();

            try
            {

                string dados = "Pedido: " + this.NumeroPosicao + "; ID:" + ID + ";Lote" + loteCliente.ID;

                Log.Registrar(IWTLogSeveridade.Info, "EXCLUIR-LOTE", this.GetType().ToString(), "ExcluirLoteCliente", dados, SingleConnection.ConnectionString);
            }
            catch { }

            try
            {

                string dados = "Pedido: " + this.NumeroPosicao + "; ID:" + ID + ";Lote" + loteCliente.ID;

                Log.Registrar(IWTLogSeveridade.Info, "EXCLUIR-LOTE", this.GetType().ToString(), "ExcluirLoteCliente", dados, SingleConnection.ConnectionString);
            }
            catch { }
        }

        public void ExcluirSaldoLoteCliente(PedidoItemLoteClienteClass loteCliente)
        {
        
            if (loteCliente==null)
            {
                throw new ExcecaoTratada("Não foi possível encontrar o lote no pedido para excluir.");
            }

          
            loteCliente.Lote.VinculaLoteClienteAoPedido(-1 * loteCliente.SaldoDevolucao);
            loteCliente.Quantidade = Math.Round(loteCliente.Quantidade - loteCliente.SaldoDevolucao, 5);
            loteCliente.SaldoDevolucao = 0;
            this.EntidadesAvulsasSalvar.Add(loteCliente.Lote);
            this.ForceDirty();

            try
            {

                string dados = "Pedido: " + this.NumeroPosicao + "; ID:" + ID + ";Lote" + loteCliente.ID;

                Log.Registrar(IWTLogSeveridade.Info, "EXCLUIR-SALDO-LOTE", this.GetType().ToString(), "ExcluirSaldoLoteCliente", dados, SingleConnection.ConnectionString);
            }
            catch { }

            try
            {

                string dados = "Pedido: " + this.NumeroPosicao + "; ID:" + ID + ";Lote" + loteCliente.ID;

                Log.Registrar(IWTLogSeveridade.Info, "EXCLUIR-SALDO-LOT", this.GetType().ToString(), "ExcluirSaldoLoteCliente", dados, SingleConnection.ConnectionString);
            }
            catch { }
        }

        public void adicionarSubitem(ProdutoClass produto, string codigoProdutoCliente,
                 string descricaoProdutoCliente, double quantidade, double valorUnitario)
        {
            try
            {
                int maiorSublinha = 0;
                if (this.CollectionPedidoItemClassPedidoItemPai.Count > 0)
                {
                    maiorSublinha = this.CollectionPedidoItemClassPedidoItemPai.Max(a=>a.SubLinha);
                }


                if (!this.CollectionPedidoItemClassPedidoItemPai.Any(a => a.Produto==produto))
                {
                    this.CollectionPedidoItemClassPedidoItemPai.Add(
                        new PedidoItemClass(this.UsuarioAtual, this.SingleConnection)
                            {
                                SubLinha = (maiorSublinha + 1),
                                Produto = produto,
                                ProdutoCodigoCliente = codigoProdutoCliente,
                                ProdutoDescricaoCliente = descricaoProdutoCliente,
                                Quantidade = quantidade,
                                PrecoUnitario = valorUnitario,
                                PedidoItemPai = this
                            });

                }
                else
                {
                    throw new Exception("O produto: " + produto + " já foi existe no pedido!");
                }

                this.ForceDirty();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o item ao pedido.\r\n" + e.Message, e);
            }
        }

        public void excluirSubItem(PedidoItemClass subLinha)
        {
            try
            {
                if (this.CollectionPedidoItemClassPedidoItemPai.Contains(subLinha))
                {
                    this.CollectionPedidoItemClassPedidoItemPai.Remove(subLinha);
                    this.adicionarObjetoDeletar(subLinha);
                }
                else
                {
                    throw new Exception("Sublinha inválida para o pedido");
                }

                this.ForceDirty();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o subitem.\r\n" + e.Message, e);
            }
        }

        public void AtualizarIncluirVariavel(VariavelClass variavel, string valor)
        {
            try
            {
                PedidoVariavelClass pedidoVariavel= this.CollectionPedidoVariavelClassPedidoItem.FirstOrDefault(a=>a.Variavel==variavel);
                if (pedidoVariavel==null)
                {
                    pedidoVariavel = new PedidoVariavelClass(this.UsuarioAtual,this.SingleConnection)
                                         {
                                             Cliente = this.Cliente,
                                             Codigo = variavel.Nome,
                                             PedidoItem = this,
                                             PedidoNumero = this.Numero,
                                             PedidoPosicao = this.Posicao,
                                             Valor = valor
                                         };

                    this.CollectionPedidoVariavelClassPedidoItem.Add(pedidoVariavel);
                }
                else
                {
                    pedidoVariavel.Valor = valor;
                }

                this.ForceDirty();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar/incluir a variável no pedido.\r\n" + e.Message, e);
            }
        }

        public void ExcluirVariavelPedido(PedidoVariavelClass pedidoVariavel)
        {
            try
            {
                if (!this.CollectionPedidoVariavelClassPedidoItem.Any(a=>a==pedidoVariavel))
                {
                    throw new ExcecaoTratada("A variável não foi encontrada no pedido");
                }

                this.CollectionPedidoVariavelClassPedidoItem.Remove(pedidoVariavel);
                this.adicionarObjetoDeletar(pedidoVariavel);

                this.ForceDirty();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao exluir a variável do pedido\r\n" + e.Message, e);
            }

        }

        public void AtualizarIncluirVariavelItem(VariavelClass variavel, string valor, int sublinha)
        {
            try
            {
                PedidoItemVariavelClass pedidoVariavel = null;
                PedidoItemClass sublinhaPedido = null;
                if (sublinha == 0)
                {
                    pedidoVariavel = this.CollectionPedidoItemVariavelClassPedidoItem.FirstOrDefault(a => a.Variavel == variavel);
                    sublinhaPedido = this;
                }
                else
                {
                    sublinhaPedido = this.CollectionPedidoItemClassPedidoItemPai.FirstOrDefault(a => a.SubLinha == sublinha);
                    if (sublinhaPedido==null)
                    {
                        throw new ExcecaoTratada("Sublinha não encontrada no pedido");
                    }

                    pedidoVariavel = sublinhaPedido.CollectionPedidoItemVariavelClassPedidoItem.FirstOrDefault(a => a.Variavel == variavel);
                }


                if (pedidoVariavel == null)
                {
                    pedidoVariavel = new PedidoItemVariavelClass(this.UsuarioAtual, this.SingleConnection)
                    {
                        Cliente = this.Cliente,
                        Codigo = variavel.Nome,
                        PedidoItem = sublinhaPedido,
                        PedidoNumero = this.Numero,
                        PedidoPosicao = this.Posicao,
                        Valor = valor,
                        SubLinha = sublinha,
                        
                    };

                    sublinhaPedido.CollectionPedidoItemVariavelClassPedidoItem.Add(pedidoVariavel);
                }
                else
                {
                    pedidoVariavel.Valor = valor;
                }

                this.ForceDirty();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar/incluir a variável no item do pedido.\r\n" + e.Message, e);
            }
        }

        public void ExcluirVariavelItemPedido(PedidoItemVariavelClass pedidoItemVariavel)
        {
            try
            {
                PedidoItemClass sublinhaPedido = null;
                int sublinha = pedidoItemVariavel.SubLinha;
                if (sublinha == 0)
                {
                    sublinhaPedido = this;
                }
                else
                {
                    sublinhaPedido = this.CollectionPedidoItemClassPedidoItemPai.FirstOrDefault(a => a.SubLinha == sublinha);
                    if (sublinhaPedido == null)
                    {
                        throw new ExcecaoTratada("Sublinha não encontrada no pedido");
                    }

                }


                if (!sublinhaPedido.CollectionPedidoItemVariavelClassPedidoItem.Any(a => a == pedidoItemVariavel))
                {
                    throw new ExcecaoTratada("A variável não foi encontrada no item do pedido");
                }

                sublinhaPedido.CollectionPedidoItemVariavelClassPedidoItem.Remove(pedidoItemVariavel);
                this.adicionarObjetoDeletar(pedidoItemVariavel);

                this.ForceDirty();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao exluir a variável do item do pedido\r\n" + e.Message, e);
            }
        }

        public void AtualizarIncluirDocumento(string familia, string identificacao, string revisao)
        {
            try
            {
                PedidoDocumentoClass pedidoDocumento = this.CollectionPedidoDocumentoClassPedidoItem.FirstOrDefault(a => a.Tipo == familia && a.Codigo==identificacao);
                if (pedidoDocumento == null)
                {
                    pedidoDocumento = new PedidoDocumentoClass(this.UsuarioAtual, this.SingleConnection)
                                          {
                                              Tipo = familia,
                                              Codigo = identificacao,
                                              Revisao = revisao,
                                              PedidoItem = this
                                          };

                    this.CollectionPedidoDocumentoClassPedidoItem.Add(pedidoDocumento);
                }
                else
                {
                    pedidoDocumento.Revisao = revisao;
                }

                this.ForceDirty();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar/incluir o documento no pedido.\r\n" + e.Message, e);
            }
        }

        public void ExcluirDocumentoPedido(PedidoDocumentoClass pedidoDocumento)
        {
            try
            {
                if (!this.CollectionPedidoDocumentoClassPedidoItem.Any(a => a == pedidoDocumento))
                {
                    throw new ExcecaoTratada("O documento não foi encontrado no pedido");
                }

                this.CollectionPedidoDocumentoClassPedidoItem.Remove(pedidoDocumento);
                this.adicionarObjetoDeletar(pedidoDocumento);

                this.ForceDirty();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao exluir o documento do pedido\r\n" + e.Message, e);
            }

        }

        public void InicializarNumeracaoAutomatica()
        {
            try
            {

                this.SalvarValoresAntigosHabilitado = false;
                string numero;
                int pos;
                
                CarregarNumeroPedidoAutomatico(this.SingleConnection, out numero, out pos);

                this.NumeroPedidoOriginal = numero;
                this.PosPedidoOriginal = pos;
                this.Numero = numero;
                this.Posicao = pos;

                this.NumeroPedidoAutomatico = true;

                this.SalvarValoresAntigosHabilitado = true;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao inicializar a númeração do pedido.\r\n" + e.Message, e);
            }
        }

        protected override void CarregamentoConcluido()
        {
            this.PrecoTotalAnterior = this.PrecoTotal;
            this.SaldoAnterior = this.Saldo;
            this.QuantidadeAnterior = this.Quantidade;
        }

        public bool RealizaFaturamentoAntecipado()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {

                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                if (this.SubLinha != 0)
                {
                    throw new ExcecaoTratada("Só é possível faturar a linha zero do pedido");
                }

                if (!IWTConfiguration.Conf.getBoolConf(Constants.PERMITE_PEDIDO_SEM_OPERACAO))
                {
                    if (Operacao == null && OperacaoCompleta == null)
                    {
                        throw new ExcecaoTratada("A operação deve ser selecionada antes de continuar");
                    }
                }


                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    if (this.OperacaoCompleta == null || !this.OperacaoCompleta.EntregaFutura)
                    {
                        throw new ExcecaoTratada("A operação do pedido não permite o faturamento antecipado");
                    }
                }
                else
                {
                    if (this.Operacao == null || !this.Operacao.EntregaFutura)
                    {
                        throw new ExcecaoTratada("A operação do pedido não permite o faturamento antecipado");
                    }
                }

                if (this.FaturamentoAntecipadoRealizado)
                {
                    throw new ExcecaoTratada("A nota fiscal de faturamento antecipado desse pedido já foi emitida anteriormente");
                }

                if (!this.Configurado)
                {
                    throw new ExcecaoTratada("O pedido deve estar configurado para ser faturado");
                }

                TipoEmissaoNFe tipoEmissaoNFe = (TipoEmissaoNFe) Enum.ToObject(typeof(TipoEmissaoNFe), int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)));
                InclusaoPedidoNota inclusaoPedidoNota = (InclusaoPedidoNota) Enum.ToObject(typeof(InclusaoPedidoNota), int.Parse(IWTConfiguration.Conf.getConf(Constants.NF_INCLUIR_NUMERO_PEDIDO_NF)));


                List<string> filesGenerated = new List<string>();
                List<NfPrincipalClass> nfs = new List<NfPrincipalClass>();

                try
                {
                    Ambiente AmbienteEmissaoNFe = Ambiente.Producao;
                    if (IWTConfiguration.Conf.getBoolConf(Constants.AMBIENTE_EMISSAO_NFE_HOMOLOGACAO))
                    {
                        AmbienteEmissaoNFe = Ambiente.Homologacao;
                    }

                    EmitenteClass emitenteCompletoPrimario;
                    PisCofinsInfo pisCofinsPrimario;

                    NfEmitenteClass emitentePrimario = NotaFiscalFuncoesAuxiliares.CarregaEmitente(SingleConnection, out emitenteCompletoPrimario, EasiEmissorNFe.Primario, out pisCofinsPrimario);

                    EmitenteClass emitenteCompletoSecundario;
                    PisCofinsInfo pisCofinsSecundario;

                    NfEmitenteClass emitenteSecundario = NotaFiscalFuncoesAuxiliares.CarregaEmitente(SingleConnection, out emitenteCompletoSecundario, EasiEmissorNFe.Secundario, out pisCofinsSecundario);


                    PisCofinsInfo pisCofinsDefaultPrimario = new PisCofinsInfo(
                        emitenteCompletoPrimario.PisCst,
                        Convert.ToInt16(emitenteCompletoPrimario.PisImpostoRetido),
                        emitenteCompletoPrimario.PisModalidade,
                        emitenteCompletoPrimario.PisAliquota,

                        emitenteCompletoPrimario.CofinsCst,
                        Convert.ToInt16(emitenteCompletoPrimario.CofinsImpostoRetido),
                        emitenteCompletoPrimario.CofinsModalidade,
                        emitenteCompletoPrimario.CofinsAliquota
                    );

                    PisCofinsInfo pisCofinsDefaultSecundario = new PisCofinsInfo(
                        emitenteCompletoSecundario.PisCst,
                        Convert.ToInt16(emitenteCompletoSecundario.PisImpostoRetido),
                        emitenteCompletoSecundario.PisModalidade,
                        emitenteCompletoSecundario.PisAliquota,

                        emitenteCompletoSecundario.CofinsCst,
                        Convert.ToInt16(emitenteCompletoSecundario.CofinsImpostoRetido),
                        emitenteCompletoSecundario.CofinsModalidade,
                        emitenteCompletoSecundario.CofinsAliquota
                    );




                    long idUfEmissor;
                    PisCofinsInfo pisCofinsDefault;
                    NfEmitenteClass emitente;
                    NfEmitenteEnderecoClass emitenteEndereco;
                    EmitenteClass emitenteCompleto;

                    switch (EmissorNfe)
                    {
                        case EasiEmissorNFe.Primario:
                            emitente = emitentePrimario;
                            emitenteCompleto = emitenteCompletoPrimario;
                            idUfEmissor = emitenteCompletoPrimario._cidade.Estado.ID;
                            pisCofinsDefault = pisCofinsDefaultPrimario;
                            break;
                        case EasiEmissorNFe.Secundario:
                            emitente = emitenteSecundario;
                            emitenteCompleto = emitenteCompletoSecundario;
                            idUfEmissor = emitenteCompletoSecundario._cidade.Estado.ID;
                            pisCofinsDefault = pisCofinsDefaultSecundario;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    emitenteEndereco = emitente.NfEmitenteEndereco;

                    CargaTributosDto dtoTributos = CargaTributosDto.CarregaTributos(this, idUfEmissor, ref command, pisCofinsDefault);

                    #region Dados Principais NF

                    NfPrincipalClass nf;
                    try
                    {


                        int numeroNota;
                        int serie = 1;

                        numeroNota = NFeOperacoes.getProximoNumeroNf(emitente.CnpjCpf, "55", command, AmbienteEmissaoNFe == Ambiente.Homologacao ? TAmb.Homologacao : TAmb.Producao, out serie);

                        FormaPagamento formaPagto = IWTNF.Entidades.Base.FormaPagamento.AVista;
                        if (emitenteCompleto.DiasPagamentoPadrao > 0)
                        {
                            formaPagto = IWTNF.Entidades.Base.FormaPagamento.APrazo;
                        }

                        Processo procEmi;




                        procEmi = Processo.AplicativoContribuinte;

                        nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            Numero = numeroNota,
                            NaturezaOperacao = dtoTributos.NaturezaOperacao,
                            Serie = serie,
                            FormaPagamento = formaPagto,
                            ModeloDocFiscal = "55",
                            DataEmissao = Configurations.DataIndependenteClass.GetData(),
                            DataSaidaEntrada = null,
                            Tipo = TipoNota.Saida,
                            CodMunicipioFatoGerador = emitente.NfEmitenteEndereco.CodMunicipio,
                            FormatoImpressao = FormatoImpressao.Retrato,
                            FormaEmissao = FormaEmissaoNFe.Normal,
                            IdentificacaoAmbiente = AmbienteEmissaoNFe == Ambiente.Producao ? 1 : 2,
                            FinalidadeEmissao = Finalidade.Normal,
                            ProcessoEmissao = procEmi,
                            VersaoProcessoEmissao = emitenteCompleto.VersaoEmissorNFe,
                            Observacoes = "",
                            TipoEmitente = "P",
                            Situacao = "N",
                            ConsumidorFinal = dtoTributos.ConsumidorFinal,
                            PresencaComprador = (PresencaComprador) Enum.ToObject(typeof(PresencaComprador), (int) dtoTributos.PresencaConsumidor),
                            EnviarNfeReceita = true
                        };

                        nf.Homologacao = AmbienteEmissaoNFe == Ambiente.Homologacao;

                        nf.NfAtributo = new NfAtributoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            NfPrincipal = nf,
                            VersaoLayout = "3.10",
                            IdNfe = "NFe"
                        };
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os campos principais da NF.\r\n" + e.Message);
                    }

                    nf.NfEmitente = emitente;
                    nf.NfEmitente.NfPrincipal = nf;
                    nf.NfEmitente.NfEmitenteEndereco.NfPrincipal = nf;

                    #endregion

                    #region Cliente

                    string cliObsPadraoNfe = "";

                    IWTNFIndicadorIE? indicadorIE = null;
                    switch (Cliente.IndicadorIe)
                    {
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.ContribuinteICMS:
                            indicadorIE = IWTNFIndicadorIE.ContribuinteICMS;
                            break;
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.Isento:
                            indicadorIE = IWTNFIndicadorIE.Isento;
                            break;
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.NaoContribuinte:
                            indicadorIE = IWTNFIndicadorIE.NaoContribuinte;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    try
                    {
                        nf.NfCliente = new NfClienteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            NfPrincipal = nf,
                            Razao = Cliente.Nome,
                            NomeFantasia = Cliente.Nome,
                            Ie = Cliente.Ie?.Trim().Replace(".", "").Replace("/", "").Replace("-", ""),
                            CnpjCpf = Cliente.Cnpj?.Replace(".", "").Replace("/", "").Replace("-", ""),
                            Isuf = Cliente.InscricaoSuframa,
                            Email = Cliente.Email.ToString(),
                            IndicadorIe = indicadorIE

                        };

                        string cepCliente = Cliente.CepCob.Trim().Replace("-", "");
                        if (cepCliente.Length != 8)
                        {
                            throw new ExcecaoTratada("O cep de cobrança do cliente é inválido: " + Cliente.CepCob);
                        }

                        if (Cliente.CidadeCob == null)
                        {
                            throw new ExcecaoTratada("O cliente não possui cidade de cobrança definda");
                        }

                        if (Cliente.EstadoCob == null)
                        {
                            throw new ExcecaoTratada("O cliente não possui estado de cobrança defindo");
                        }

                        if (!Cliente.CodigoPaisCob.HasValue)
                        {
                            throw new ExcecaoTratada("O cliente não possui código do país de cobrança defindo");
                        }

                        nf.NfCliente.NfClienteEndereco = new NfClienteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            NfPrincipal = nf,
                            Logradouro = Cliente.EnderecoCob.ToString(),
                            Numero = Cliente.EnderecoNumeroCob.ToString(),
                            Complemento = Cliente.ComplementoCob.ToString(),
                            Bairro = Cliente.BairroCob.ToString(),
                            CodMunicipio = Cliente.CidadeCob.CodigoIbge,
                            NomeMunicipio = Cliente.CidadeCob.Nome.ToString(),
                            SiglaUf = Cliente.EstadoCob.Sigla.ToString(),
                            Cep = cepCliente,
                            CodPais = Cliente.CodigoPaisCob.Value,
                            NomePais = Cliente.PaisCob.ToString(),
                            Telefone = Cliente.Fone1.ToString().Replace("(", "").Trim().Replace(")", "").Replace("-", "").Replace(" ", "")

                        };

                        cliObsPadraoNfe = Cliente.ObservacaoPadraoNfe;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados do Cliente da NF.\r\n" + e.Message);
                    }

                    #endregion

                    #region Itens do Pedido

                    int totalVolumes = 0;

                    int numeroLinhaNF = 1;
                    double pesoTotalItens = 0;



                    try
                    {
                        nf.CollectionNfItemClassNfPrincipal = new BindingList<NfItemClass>();



                        if (this.Quantidade <= 0)
                        {
                            throw new ExcecaoTratada("Não é possível realizar o faturamento de um pedido com quantidade zero");
                        }


                        double precoTotal;

                        string descricao = "";
                        if (inclusaoPedidoNota == InclusaoPedidoNota.DescricaoItens)
                        {
                            descricao = this.NumeroPosicao + " - ";
                        }


                        DadosFiscaisItemDto dadosFiscaisItem = DadosFiscaisItemDto.GetDadosFiscaisProduto(Produto);

                        string codItem = "";
                        NcmClass ncm;

                        int CFOP;


                        if (!string.IsNullOrWhiteSpace(ProdutoDescricaoCliente))
                        {
                            descricao += ProdutoDescricaoCliente;
                        }
                        else
                        {
                            descricao += Produto.Descricao;
                        }


                        if (!string.IsNullOrWhiteSpace(ProdutoCodigoCliente))
                        {
                            codItem += ProdutoCodigoCliente;
                        }
                        else
                        {
                            codItem += Produto.CodigoCliente;
                        }

                        ncm = Ncm != null ? Ncm : null;

                        if (nf.NfEmitente.NfEmitenteEndereco.SiglaUf.ToUpper() ==
                            nf.NfCliente.NfClienteEndereco.SiglaUf.ToUpper())
                        {
                            CFOP = dtoTributos.Cfop;
                        }
                        else
                        {
                            CFOP = dtoTributos.Cfop;
                        }


                        #region Validação de Preço

                        if (dtoTributos.ValidaPrecos != EasiValidaPrecos.NaoValida)
                        {
                            //Conferencia Preços 
                            precoTotal = PrecoTotal;
                            bool precoTabelaEncontrado = false;

                            //busca o preço variável
                            IWTPostgreNpgsqlCommand command2 = SingleConnection.CreateCommand();
                            double precoTmp = 0;
                            command2.CommandText =
                                "SELECT  tpv_preco FROM tabela_preco_item_variavel WHERE tpv_order_number LIKE '" +
                                Numero + "' AND tpv_pos=" + Posicao + " AND id_cliente = " + Cliente.ID + ";";
                            IWTPostgreNpgsqlDataReader read2 = command2.ExecuteReader();
                            if (read2.HasRows)
                            {
                                read2.Read();
                                precoTmp += Convert.ToDouble(read2["tpv_preco"]);
                                precoTabelaEncontrado = true;
                            }

                            read2.Close();

                            if (!precoTabelaEncontrado)
                            {
                                string mensagem = "Pedido não encontrado na tabela de preços.\r\nPedido: " + NumeroPosicao + "\r\nCódigo do Item: " + Produto.Codigo;

                                switch (dtoTributos.ValidaPrecos)
                                {
                                    case EasiValidaPrecos.ValidaComBloqueio:
                                        throw new Exception(mensagem);
                                    case EasiValidaPrecos.ValidaSemBloqueio:
                                        MessageBox.Show(mensagem, "Aviso da Validação de Preços", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }


                            if (precoTotal <= (precoTmp + 1) && precoTotal >= (precoTmp - 1))
                            {
                            }
                            else
                            {
                                string mensagem = "Preço inconsistente no pedido e no Tabela de Preços " +
                                                  NumeroPosicao + ".\r\nPreço Tabela: R$ " +
                                                  precoTmp.ToString("F2", CultureInfo.CurrentCulture) +
                                                  " \rPreço Pedido: R$ " +
                                                  precoTotal.ToString("F2", CultureInfo.CurrentCulture);

                                switch (dtoTributos.ValidaPrecos)
                                {
                                    case EasiValidaPrecos.ValidaComBloqueio:
                                        throw new Exception(mensagem);
                                    case EasiValidaPrecos.ValidaSemBloqueio:
                                        MessageBox.Show(mensagem, "Aviso da Validação de Preços", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }

                            if (Cliente.FamiliaCliente.TipoEspecial == TipoFamiliaEspecial.EASSA && Cliente.UtilizarControlesCliente)
                            {
                                //Valida preço SO
                                command2.CommandText =
                                    "SELECT  price_per_unit FROM order_item WHERE order_number LIKE '" +
                                    Numero + "' AND order_pos=" + Posicao + ";";
                                read2 = command2.ExecuteReader();
                                double precoSO = 0;
                                if (read2.HasRows)
                                {
                                    read2.Read();
                                    precoSO += Convert.ToDouble(read2["price_per_unit"]);
                                }

                                read2.Close();

                                precoSO = precoSO * Quantidade;
                                if (precoTotal <= (precoSO + 1) && precoTotal >= (precoSO - 1))
                                {
                                }
                                else
                                {
                                    string mensagem = "Preço inconsistente no pedido e no pedido do cliente " +
                                                      NumeroPosicao + ".\r\nPreço Cliente: R$ " +
                                                      precoSO.ToString("F2", CultureInfo.CurrentCulture) +
                                                      " \rPreço Pedido: R$ " +
                                                      PrecoTotal.ToString("F2", CultureInfo.CurrentCulture);


                                    switch (dtoTributos.ValidaPrecos)
                                    {
                                        case EasiValidaPrecos.ValidaComBloqueio:
                                            throw new Exception(mensagem);
                                        case EasiValidaPrecos.ValidaSemBloqueio:
                                            MessageBox.Show(mensagem, "Aviso da Validação de Preços", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            break;
                                        default:
                                            throw new ArgumentOutOfRangeException();
                                    }
                                }
                            }
                        }
                        else
                        {
                            precoTotal = PrecoTotal;
                        }

                        #endregion

                        if (!Produto.PermiteVenda)
                        {
                            throw new ExcecaoTratada("Não é possível faturar o pedido " + NumeroPosicao + " pois o item " + Produto.Codigo + " não possui autorização de venda");
                        }


                        if (descricao.Length > 60)
                        {
                            descricao = descricao.Substring(0, 60);
                        }

                        if (Produto.CollectionProdutoFiscalClassProduto.Count <= 0)
                        {
                            throw new ExcecaoTratada("O item " + Produto.Codigo + " não possui cadastro fiscal.");
                        }

                        string codigoBeneficioFiscal = null;
                        if (ncm == null)
                        {
                            ncm = dadosFiscaisItem.NCM;
                        }


                        if (ncm != null)
                        {
                            NcmBeneficioFiscalClass beneficioFiscal = ncm.CollectionNcmBeneficioFiscalClassNcm.FirstOrDefault(a => a.Estado == Cliente.EstadoCob && a.Cfop == CFOP);
                            codigoBeneficioFiscal = beneficioFiscal?.CodigoBeneficioFiscal;
                        }


                        nf.CollectionNfItemClassNfPrincipal.Add(new NfItemClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            NfPrincipal = nf,
                            NumeroItem = numeroLinhaNF,
                            Cfop = CFOP,
                        });

                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto =
                            new NfProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                            {
                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Codigo = codItem,
                                Descricao = descricao,
                                Gtin = dadosFiscaisItem.GTIN,
                                Ncm = ncm.Codigo,
                                Cest = ncm.Cest,
                                Extipi = dadosFiscaisItem.exTIPI,
                                Genero = dadosFiscaisItem.Genero,
                                Unidade = Produto.UnidadeMedida.Abreviada,
                                ValorUnitario = PrecoUnitario,
                                GtimUnidadeTrinutacao = dadosFiscaisItem.GTIN,
                                UnidadeTributacao = Produto.UnidadeMedida.Abreviada,
                                ValorUnitarioTrinutacao = PrecoUnitario,
                                QuantidadeTributavel = Quantidade,
                                ValorTotalTributavel = Math.Round(precoTotal, 2),
                                ValorFrete = 0,
                                ValorDesconto = 0,
                                ValorSeguro = 0,
                                Quantidade = Quantidade,
                                Xped = Numero,
                                NumeroItemPedido = Posicao,
                                CodigoBeneficio = codigoBeneficioFiscal
                            };


                        switch (dtoTributos.IpiIncide)
                        {
                            case IncidenciaImposto.NaoIncide:
                                break;
                            case IncidenciaImposto.Incide:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                    new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        ClasseEnquadramentoCigarrosBebidas = null,
                                        CnpjProdutor = null,
                                        ClasseEnquadramento = dtoTributos.IpiCodEnquadramento,
                                        Cst = dtoTributos.IpiCst,
                                        Aliquota = dtoTributos.IpiAliquota,
                                        ModalidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), dtoTributos.IpiModTributacao),
                                        QuantidadeVendida = 0
                                    };
                                break;
                            case IncidenciaImposto.Suspenso:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                    new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        ClasseEnquadramentoCigarrosBebidas = null,
                                        CnpjProdutor = null,
                                        ClasseEnquadramento = dtoTributos.IpiCodEnquadramento,
                                        Cst = dtoTributos.IpiCst,
                                        Aliquota = 0,
                                        ModalidadeTributacao = ModalidadeTributacao.NaoTributado,
                                        QuantidadeVendida = 0
                                    };
                                break;
                        }


                        string icmsCST = "90";
                        int icmsCsosn = 0;

                        if (emitenteCompleto.Crt != CRTTipo.Normal)
                        {
                            icmsCST = "SN";
                            icmsCsosn = 900;
                        }

                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                            new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
                            {
                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Cst = icmsCST,
                                Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), Produto.CollectionProdutoFiscalClassProduto[0].Origem),
                                ModalidadeDeterminacaoBc = ModalidadeDeterminacaoBCICMS.ValorOperacao,
                                Aliquota = 0,
                                AliquotaSt = 0,
                                PercentualReducaoBc = 0,
                                ModalidadeDeterminacaoBcSt = ModalidadeDeterminacaoBCICMSST.MargemValorAgregado,
                                PercentualReducaoBcSt = 0,
                                PercentualMvaSt = 0,
                                CodigoAntecipacaoSt = "X",
                                PercentualDiferimento = 0,
                                ObsDiferimento = "",
                                PercentualBcOperacaoPropria = 0,
                                SiglaUfDevidoIcms = null,
                                ValorBcStRetidoRemetente = 0,
                                ValorIcmsStRetidoRemetente = 0,
                                ValorBcStRetidoDestinatario = 0,
                                ValorIcmsStRetidoDestinatario = 0,
                                CsoSimples = icmsCsosn,
                                AliquotaCreditoSimples = 0
                            };

                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                            new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
                            {
                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Cst = "08",
                                Aliquota = 0,
                                ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                ImpostoRetido = 0
                            };

                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                            new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
                            {
                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Cst = "08",
                                Aliquota = 0,
                                ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                ImpostoRetido = 0
                            };


                        numeroLinhaNF++;



                        if (nf.CollectionNfItemClassNfPrincipal.Count == 0)
                        {
                            throw new Exception("Ao menos um item deve ser selecionado.");
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados dos itens da NF: " + NumeroPosicao + "\r\n" +
                                            e.Message);
                    }

                    #endregion


                    #region Transporte

                    try
                    {

                        nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            NfPrincipal = nf,
                            Modalidade = ModalidadeFrete.Emitente,
                            Razao = "",
                            Ie = "",
                            Endereco = "",
                            SiglaUf = "",
                            Municipio = "",
                            CpfCnpj = "",
                            Volumes = totalVolumes,
                            PesoLiquido = 0,
                            PesoBruto = 0,
                            Placa = null,
                            RegistroAntt = null,
                            SiglaUfVeiculo = null,
                            VolumeEspecie = "Volume",
                            VolumeMarca = ""
                        };



                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados do transporte da NF.\r\n" + e.Message);
                    }

                    #endregion


                    try
                    {
                        NfPrincipalClass.calculaNf(ref nf, Constants.ArredondamentoNF, UsuarioAtual, SingleConnection, null);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao calcular a NF.\r\n" + e.Message);
                    }

                    #region Dados Cobrança

                    List<ContaReceberClass> contasNotaAtual = new List<ContaReceberClass>();
                    AgrupadorContaClass agrupador = new AgrupadorContaClass(UsuarioAtual, SingleConnection);
                    try
                    {

                        nf.NfCobranca = new NfCobrancaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            NfPrincipal = nf,
                            CollectionNfDuplicataClassNfCobranca = new BindingList<NfDuplicataClass>(new List<NfDuplicataClass>())
                        };

                        FormaPagamentoClass formaPagtoLocal = FormaPagamento;
                        if (formaPagtoLocal == null)
                        {
                            formaPagtoLocal = Cliente.FormaPagamento;
                        }

                        ContaBancariaClass contaBancariaLocal = ContaBancaria;
                        if (contaBancariaLocal == null)
                        {
                            contaBancariaLocal = Cliente.ContaBancaria;
                        }


                        CentroCustoLucroClass centroCustoLucroLocal = CentroCustoLucro;
                        if (centroCustoLucroLocal == null)
                        {
                            centroCustoLucroLocal = Cliente.CentroCustoLucro;
                        }

                        TipoPagamentoClass tipoPagamento = TipoPagamento;
                        if (tipoPagamento == null)
                        {
                            if (Cliente.TipoPagamento != null)
                            {
                                tipoPagamento = Cliente.TipoPagamento;
                            }
                        }




                        if (!dtoTributos.GerarContasReceber || (formaPagtoLocal == null && contaBancariaLocal == null && centroCustoLucroLocal == null))
                        {
                            nf.NfCobranca.CollectionNfDuplicataClassNfCobranca.Add(new NfDuplicataClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                            {
                                NfPrincipal = nf,
                                Numero = "001",
                                Valor = nf.NfTotais.ValorTotalNf,
                                Vencimento = Configurations.DataIndependenteClass.GetData().AddDays(emitenteCompleto.DiasPagamentoPadrao)
                            });
                        }
                        else
                        {

                            if (formaPagtoLocal == null)
                            {
                                throw new Exception(
                                    "Não é possível emitir a NFe pois a forma de pagamento não foi selecionada, verifique o pedido e/ou o cliente.\r\n" +
                                    NumeroPosicao);
                            }

                            if (contaBancariaLocal == null)
                            {
                                throw new Exception(
                                    "Não é possível emitir a NFe pois a conta bancária não foi selecionada, verifique o pedido e/ou o cliente.\r\n" +
                                    NumeroPosicao);
                            }

                            if (centroCustoLucroLocal == null)
                            {
                                throw new Exception(
                                    "Não é possível emitir a NFe pois o centro de lucro não foi selecionado, verifique o pedido e/ou o cliente.\r\n" +
                                    NumeroPosicao);
                            }



                            if (!centroCustoLucroLocal.Ativo)
                            {
                                throw new Exception(
                                    "Não é possível emitir a NFe pois o centro de lucro selecionado (" + centroCustoLucroLocal + ") não está ativo, verifique o pedido e/ou o cliente.\r\n" +
                                    NumeroPosicao);
                            }

                            if (!formaPagtoLocal.Ativo)
                            {
                                throw new Exception(
                                    "Não é possível emitir a NFe pois a forma de pagamento selecionada (" + formaPagtoLocal + ") não está ativo, verifique o pedido e/ou o cliente.\r\n" +
                                    NumeroPosicao);
                            }



                            double valorRestante = nf.NfTotais.ValorTotalNf;


                            int totalParcelas = formaPagtoLocal.QuantidadeParcelas;
                            if (formaPagtoLocal.Entrada)
                                totalParcelas++;


                            contasNotaAtual = new List<ContaReceberClass>();
                            double valorPrevistoParcela = Math.Round((valorRestante / totalParcelas), 2);
                            DateTime dataAtual = Configurations.DataIndependenteClass.GetData().Date;

                            CredorDevedorClass cr = Cliente.CollectionCredorDevedorClassCliente.FirstOrDefault();
                            agrupador.Data = dataAtual;

                            for (int indiceParcela = 1; indiceParcela <= totalParcelas; indiceParcela++)
                            {
                                ContaReceberClass tmp;
                                if (formaPagtoLocal.Entrada && indiceParcela == 1)
                                {
                                    dataAtual = dataAtual.AddDays(formaPagtoLocal.DiasEntrada);
                                    //Entrada
                                    tmp = new ContaReceberClass(UsuarioAtual, SingleConnection)
                                    {
                                        NfPrincipal = nf,
                                        
                                        IdDevedor = cr.ID,
                                        CentroCustoLucro = centroCustoLucroLocal,
                                        ContaBancaria = contaBancariaLocal,
                                        NumDocumento = "NFe " + nf.Numero.ToString(),
                                        DataVencimento = dataAtual,
                                        Valor = valorPrevistoParcela,
                                        Historico = "Parcela " + indiceParcela + "/" + totalParcelas,
                                        TipoPagamento = tipoPagamento,
                                        AgrupadorConta = agrupador

                                    };

                                }
                                else
                                {
                                    if (indiceParcela == totalParcelas)
                                    {
                                        //Ultima Parcela ajustar valor
                                        dataAtual = dataAtual.AddDays(formaPagtoLocal.Periodicidade);

                                        tmp = new ContaReceberClass(UsuarioAtual, SingleConnection)
                                        {
                                            NfPrincipal = nf,
                                            Cliente = null,
                                            IdDevedor = cr.ID,
                                            CentroCustoLucro = centroCustoLucroLocal,
                                            ContaBancaria = contaBancariaLocal,
                                            NumDocumento = "NFe " + nf.Numero.ToString(),
                                            DataVencimento = dataAtual,
                                            Valor = valorRestante,
                                            Historico = "Parcela " + indiceParcela + "/" + totalParcelas,
                                            TipoPagamento = tipoPagamento,
                                            AgrupadorConta = agrupador

                                        };


                                    }
                                    else
                                    {
                                        //Demais Parcelas
                                        dataAtual = dataAtual.AddDays(formaPagtoLocal.Periodicidade);


                                        tmp = new ContaReceberClass(UsuarioAtual, SingleConnection)
                                        {
                                            NfPrincipal = nf,
                                            IdDevedor = cr.ID,
                                            CentroCustoLucro = centroCustoLucroLocal,
                                            ContaBancaria = contaBancariaLocal,
                                            NumDocumento = "NFe " + nf.Numero.ToString(),
                                            DataVencimento = dataAtual,
                                            Valor = valorPrevistoParcela,
                                            Historico = "Parcela " + indiceParcela + "/" + totalParcelas,
                                            TipoPagamento = tipoPagamento,
                                            AgrupadorConta = agrupador

                                        };



                                    }
                                }

                                agrupador.CollectionContaReceberClassAgrupadorConta.Add(tmp);
                                contasNotaAtual.Add(tmp);
                                valorRestante -= tmp.Valor;
                                valorRestante = Math.Round(valorRestante, 2);
                            }

                            for (var i = 0; i < contasNotaAtual.Count; i++)
                            {
                                ContaReceberClass receber = contasNotaAtual[i];
                                nf.NfCobranca.CollectionNfDuplicataClassNfCobranca.Add(
                                    new NfDuplicataClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                                    {
                                        NfPrincipal = nf,
                                        Numero = (i + 1).ToString().PadLeft(3, '0'),
                                        Vencimento = receber.DataVencimento,
                                        Valor = receber.Valor,
                                    });
                            }


                            if (formaPagtoLocal.Entrada && formaPagtoLocal.DiasEntrada == 0 && formaPagtoLocal.QuantidadeParcelas == 0)
                            {
                                nf.FormaPagamento = IWTNF.Entidades.Base.FormaPagamento.AVista;
                            }
                            else
                            {
                                nf.FormaPagamento = IWTNF.Entidades.Base.FormaPagamento.APrazo;
                            }


                            NfPagamentoTipo pagto = NfPagamentoTipo.Outros;
                            string xPagto = null;
                            if (tipoPagamento == null || tipoPagamento.Identificacao.ToUpperInvariant().Contains("BOLETO"))
                            {
                                pagto = NfPagamentoTipo.BoletoBancario;
                            }
                            else
                            {
                                switch (tipoPagamento.TipoPagamentoNf)
                                {
                                    case TipoPagamentoNfe.Dinheiro:
                                        pagto = NfPagamentoTipo.Dinheiro;
                                        break;
                                    case TipoPagamentoNfe.Cheque:
                                        pagto = NfPagamentoTipo.Cheque;
                                        break;
                                    case TipoPagamentoNfe.CartaodeCredito:
                                        pagto = NfPagamentoTipo.CartaoCredito;
                                        break;
                                    case TipoPagamentoNfe.CartaodeDebito:
                                        pagto = NfPagamentoTipo.CartaoDebito;
                                        break;
                                    case TipoPagamentoNfe.CreditoLoja:
                                        pagto = NfPagamentoTipo.CreditoLoja;
                                        break;
                                    case TipoPagamentoNfe.ValeAlimentacao:
                                        pagto = NfPagamentoTipo.ValeAlimentacao;
                                        break;
                                    case TipoPagamentoNfe.ValeRefeicao:
                                        pagto = NfPagamentoTipo.ValeRefeicao;
                                        break;
                                    case TipoPagamentoNfe.ValePresente:
                                        pagto = NfPagamentoTipo.ValePresente;
                                        break;
                                    case TipoPagamentoNfe.ValeCombustivel:
                                        pagto = NfPagamentoTipo.ValeCombustivel;
                                        break;
                                    case TipoPagamentoNfe.BoletoBancario:
                                        pagto = NfPagamentoTipo.BoletoBancario;
                                        break;
                                    case TipoPagamentoNfe.DepositoBancario:
                                        pagto = NfPagamentoTipo.DepositoBancario;
                                        break;
                                    case TipoPagamentoNfe.Pix:
                                        pagto = NfPagamentoTipo.Pix;
                                        break;
                                    case TipoPagamentoNfe.TransferenciaBancaria:
                                        pagto = NfPagamentoTipo.TransferenciaBancaria;
                                        break;
                                    case TipoPagamentoNfe.ProgramaFidelidade:
                                        pagto = NfPagamentoTipo.ProgramaFidelidade;
                                        break;
                                    case TipoPagamentoNfe.SemPagamento:
                                        pagto = NfPagamentoTipo.SemPagamento;
                                        break;
                                    case TipoPagamentoNfe.Outros:
                                        pagto = NfPagamentoTipo.Outros;
                                        xPagto = tipoPagamento.TipoPagamentoNfDescricao;
                                        break;
                                    case null:
                                        throw new ExcecaoTratada("O tipo de pagamento " + tipoPagamento.Identificacao + " não possui tipo de pagamento pra nota fiscal definido");
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }


                            }



                            nf.CollectionNfPagamentoClassNfPrincipal.Add(new NfPagamentoClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
                            {
                                NfPrincipal = nf,
                                Tipo = pagto,
                                TipoDescricao = xPagto,
                                Valor = nf.NfTotais.ValorTotalNf,
                            });

                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados das duplicatas da NF.\r\n" + e.Message);
                    }

                    #endregion

                    //Ajusta ICMS
                    foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
                    {
                        item.NfItemTributo.NfItemTributoIcms.ValorBc = 0;
                        item.NfItemTributo.NfItemTributoIcms.ValorBcSt = 0;
                    }

                    nf.NfTotais.BaseCalculoIcms = 0;
                    nf.NfTotais.BaseCalculoIcmsSt = 0;



                    #region Observações

                    string observacaoPedidos = "";
                    if (!string.IsNullOrWhiteSpace(ObservacaoNf))
                    {
                        observacaoPedidos += "Observação do Pedido: " + ObservacaoNf;
                    }

                    if (inclusaoPedidoNota == InclusaoPedidoNota.Observacao)
                    {
                        if (observacaoPedidos.Length > 0)
                        {
                            observacaoPedidos += " ";
                        }

                        observacaoPedidos += "Pedidos Faturados: " + NumeroPosicao;

                    }


                    #endregion

                    nf.Observacoes += emitenteCompleto.ObservacaoEmitente + " " + cliObsPadraoNfe + " " + observacaoPedidos;

                    if (dtoTributos.EntregaFutura)
                    {
                        nf.Observacoes += "  Nota Fiscal emitida nos termos do Artigo 266 RICMS/PR Dec 5141/2001.";
                    }

                    //Visualiza a NF
                    VisualNFeForm form = new VisualNFeForm(nf, "-1", VisualNFeFormUtilizacao.Aceite);
                    form.ShowDialog();
                    if (form.NFeRecusada)
                    {
                        return false;
                    }


                    //NFe nova, envio automático receita

                    if (AmbienteEmissaoNFe == Ambiente.Homologacao)
                    {
                        nf.NfCliente.Razao = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                        nf.IdentificacaoAmbiente = 2;
                    }




                    try
                    {
                        nf.Save(ref command);
                        agrupador.Save(ref command);

                        foreach (ContaReceberClass receber in contasNotaAtual)
                        {
                            receber.Save(ref command);
                        }

                        NfPrincipalFaturamentoAntecipado = nf;
                        FaturamentoAntecipadoRealizado = true;

                        this.Save(ref command);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao salvar a NF.\r\n" + e.Message);
                    }

                    if (contasNotaAtual != null)
                    {
                        foreach (ContaReceberClass receber in contasNotaAtual)
                        {
                            receber.NfPrincipal = nf;
                        }
                    }

                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao emitir a Nota Fiscal.\r\n" + e.Message);
                }


                command.Transaction.Commit();

            }
            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro inesperado ao realizar o faturamento antecipado do pedido\r\n" + e.Message);
            }

            return true;
        }

        public static List<PedidoItemClass> BuscaPedidoPendente(string pedido, int pos, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<PedidoItemClass> toRet = new PedidoItemClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("NumeroExato", pedido),
                    new SearchParameterClass("Posicao", pos),
                    new SearchParameterClass("SubLinha", 0),
                    new SearchParameterClass("Pendente",true)
                }).ConvertAll(a => (PedidoItemClass) a).ToList();

                return toRet;


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao buscar o pedido \r\n" + e.Message, e);
            }
        }

        public static List<PedidoItemClass> BuscaPedido(string pedido, int? pos,ClienteClass cliente, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<SearchParameterClass> parameteros = new List<SearchParameterClass>()
                {
                    new SearchParameterClass("NumeroExato", pedido),

                    new SearchParameterClass("SubLinha", 0),
                    new SearchParameterClass("Cliente", cliente)
                };
                if (pos.HasValue)
                {
                    parameteros.Add(new SearchParameterClass("Posicao", pos));
                }

                List<PedidoItemClass> toRet = new PedidoItemClass(usuario, conn).Search(parameteros).ConvertAll(a => (PedidoItemClass)a).ToList();

                return toRet;


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao buscar o pedido \r\n" + e.Message, e);
            }
        }

        public bool possuiProdutoVencido()
        {
            bool possuiProdutoVencido = false;

            if (this.Configurado)
            {
                foreach (OrderItemEtiquetaClass orderItemEtiqueta in this.CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido)
                {
                    ProdutoPrecoClass produtoPreco =
                        orderItemEtiqueta.Produto.CollectionProdutoPrecoClassProduto.FirstOrDefault(a => a.FimVigencia == null);

                    if (this.produtoPrecoVencido(produtoPreco))
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (PedidoItemClass pedidoItem in this.CollectionPedidoItemClassPedidoItemPai)
                {
                    ProdutoPrecoClass produtoPreco =
                        pedidoItem.Produto.CollectionProdutoPrecoClassProduto.FirstOrDefault(a => a.FimVigencia == null);

                    if (this.produtoPrecoVencido(produtoPreco))
                    {
                        return true;
                    }
                }

                ProdutoPrecoClass produtoPrecoPedidoItem =
                        this.Produto.CollectionProdutoPrecoClassProduto.FirstOrDefault(a => a.FimVigencia == null);

                if (this.produtoPrecoVencido(produtoPrecoPedidoItem))
                {
                    return true;
                }
            }
            
            return possuiProdutoVencido;
        }

        private bool produtoPrecoVencido(ProdutoPrecoClass produtoPreco)
        {
            bool possuiProdutoVencido = false;

            if (produtoPreco != null)
            {
                string configuracaoDiasValidadePreco = IWTConfiguration.Conf.getConf(Constants.DIAS_VALIDADE_PRECO);

                int diasValidadePrecoInt = 0;

                if (configuracaoDiasValidadePreco != null)
                {
                    diasValidadePrecoInt =  Int32.Parse(configuracaoDiasValidadePreco);
                }

                DateTime produtoPrecoDataVencimento = produtoPreco.InicioVigencia.AddDays(diasValidadePrecoInt);

                DateTime dataAtual = DateTime.Now;

                if (produtoPrecoDataVencimento.CompareTo(dataAtual) == -1)
                {
                    return true;
                }
            }

            return possuiProdutoVencido;
        }
    }


}
