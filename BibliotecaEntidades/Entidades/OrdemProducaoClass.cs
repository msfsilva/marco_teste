using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using Configurations;
using iTextSharp.text;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades 
{
    public class OrdemProducaoClass : OrdemProducaoBaseClass
    {


        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoClass";
        protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoClass  ";
        protected new const string ErroSave = "Erro ao salvar o OrdemProducaoClass.";
        protected new const string ErroCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoClass.";
        protected new const string ErroCollectionOrdemProducaoMaterialClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoMaterialClass.";
        protected new const string ErroCollectionOrdemProducaoRecursoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoRecursoClass.";
        protected new const string ErroCollectionOrdemProducaoHistoricoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoHistoricoClass.";
        protected new const string ErroCollectionOrdemProducaoEstoqueClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoEstoqueClass.";
        protected new const string ErroCollectionOrdemProducaoDocumentoOpClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoDocumentoOpClass.";
        protected new const string ErroCollectionOrdemProducaoPedidoClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoPedidoClass.";
        protected new const string ErroCollectionOrdemProducaoDiferencaClassOrdemProducao = "Erro ao carregar a coleção de OrdemProducaoDiferencaClass.";
        protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
        protected new const string ErroOrdemProducaoGrupoObrigatorio = "O campo OrdemProducaoGrupo é obrigatório";
        protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoClass.";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassOrdemProducao = "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoMaterialClassOrdemProducao = "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoMaterialClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoRecursoClassOrdemProducao = "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoRecursoClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoHistoricoClassOrdemProducao = "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoHistoricoClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoEstoqueClassOrdemProducao = "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoEstoqueClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoDocumentoOpClassOrdemProducao = "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoDocumentoOpClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoPedidoClassOrdemProducao = "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoPedidoClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoDiferencaClassOrdemProducao = "A entidade OrdemProducaoClass está sendo utilizada nos seguintes OrdemProducaoDiferencaClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade OrdemProducaoClass está sendo utilizada.";

        #endregion


        public OrdemProducaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public string SituacaoTraduzida
        {
            get
            {

                switch (this.Situacao)
                {
                    case StatusOrdemProducao.AguardandoInicioProducao:
                        return "Nova";
                        break;
                    case StatusOrdemProducao.Producao:
                        return "Em Produção";
                        break;
                    case StatusOrdemProducao.Encerrada:
                        return "Encerrada";
                        break;
                    case StatusOrdemProducao.Cancelada:
                        return "Cancelada";
                    case StatusOrdemProducao.AguardandoServicoExterno:
                        return "Aguardando Serviço Externo";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
        }

        public string ClassificacaoProduto
        {
            get { return Produto.ClassificacaoProduto == null ? "" : Produto.ClassificacaoProduto.ToString(); }
        }

        public string Pedidos
        {
            get
            {
                string toRet = "";
                foreach (OrdemProducaoPedidoClass pedido in CollectionOrdemProducaoPedidoClassOrdemProducao)
                {
                    toRet += " - " + pedido.OrderNumber + "/" + pedido.OrderPos;
                }

                if (toRet.Length > 0)
                {
                    toRet = toRet.Substring(3);
                }

                return toRet;

            }
        }

        public OrdemProducaoPostoTrabalhoClass PostoUltimaLeituraEntidade
        {
            get { return CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao.Where(a => a.Tempo1.HasValue).OrderByDescending(a => a.Sequencia).FirstOrDefault(); }
        }

        public string PostoUltimaLeitura
        {
            get
            {
                OrdemProducaoPostoTrabalhoClass postoUtlimaLeitua = PostoUltimaLeituraEntidade;
                return postoUtlimaLeitua?.PostoCodigo + "-" + postoUtlimaLeitua?.PostoNome + " - " + postoUtlimaLeitua?.PostoOperacao;
            }
        }

        public double SaldoEnvioFornecedor
        {
            get
            {
                double qtd = this.Quantidade;
                if (PostoUltimaLeituraEntidade != null && PostoUltimaLeituraEntidade.QuantidadeEntrada.HasValue)
                {
                    qtd = PostoUltimaLeituraEntidade.QuantidadeEntrada.Value;
                }

                return  qtd - CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao.Sum(a => a.Quantidade)
                            - CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao.Sum(a => a.Quantidade);


            }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaCompleta":

                    whereClause += " AND (FALSE ";

                    whereClause += " OR UPPER(ordem_producao.orp_produto_descricao) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_produto_descricao) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(ordem_producao.orp_tipo_documento) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_tipo_documento) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(ordem_producao.orp_numero_documento) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_numero_documento) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(ordem_producao.orp_revisao_documento) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_revisao_documento) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(ordem_producao.orp_cliente_nao_usar) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_cliente_nao_usar) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(ordem_producao.orp_dimensao) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_dimensao) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(ordem_producao.orp_produto_codigo) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_produto_codigo) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(ordem_producao.orp_agrupador_op) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_agrupador_op) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(ordem_producao.orp_observacao_liberacao_qualidade) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordem_producao.orp_observacao_liberacao_qualidade) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(classificacao_produto_busca_completa.clp_identificacao) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(classificacao_produto_busca_completa.clp_identificacao) LIKE :buscaCompletaLower ";

                    whereClause += ") ";

                    command.CommandText += " LEFT JOIN produto produto_busca_completa ON produto_busca_completa.id_produto = ordem_producao.id_produto ";
                    command.CommandText += " LEFT JOIN classificacao_produto classificacao_produto_busca_completa ON produto_busca_completa.id_classificacao_produto = classificacao_produto_busca_completa.id_classificacao_produto ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                    return true;


                case "Abertas":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool) parametro.Fieldvalue)
                        {
                            whereClause += " AND ( " +
                                           "  public.ordem_producao.orp_situacao= 0 OR public.ordem_producao.orp_situacao= 1 " +
                                           ") ";
                        }
                        else
                        {
                            whereClause += " AND ( " +
                                           "  public.ordem_producao.orp_situacao= 2 OR public.ordem_producao.orp_situacao= 3 " +
                                           ") ";
                        }

                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo Boolean");
                    }

                case "DataEncerramentoInicio":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        DateTime data = (DateTime) parametro.Fieldvalue;


                        whereClause += " AND ( " +
                                       "  public.ordem_producao.orp_data_encerramento >= :DataEncerramentoInicio" +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("DataEncerramentoInicio", NpgsqlDbType.Timestamp, data.Date));

                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo DateTime");
                    }

                case "DataEncerramentoFim":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        DateTime data = (DateTime) parametro.Fieldvalue;


                        whereClause += " AND ( " +
                                       "  public.ordem_producao.orp_data_encerramento <= :DataEncerramentoFim" +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("DataEncerramentoFim", NpgsqlDbType.Timestamp, data.Date));

                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo DateTime");
                    }


                case "DataImpressaoInicio":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        DateTime data = (DateTime) parametro.Fieldvalue;


                        whereClause += " AND ( " +
                                       "  public.ordem_producao.orp_data_impressao >= :DataImpressaoInicio" +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("DataImpressaoInicio", NpgsqlDbType.Timestamp, data.Date));

                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo DateTime");
                    }

                case "DataImpressaoFim":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        DateTime data = (DateTime) parametro.Fieldvalue;


                        whereClause += " AND ( " +
                                       "  public.ordem_producao.orp_data_impressao <= :DataImpressaoFim" +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("DataImpressaoFim", NpgsqlDbType.Timestamp, data.Date.AddDays(1)));

                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo DateTime");
                    }

                case "Numero":
                    if (parametro.Fieldvalue is int || parametro.Fieldvalue is decimal || parametro.Fieldvalue is double)
                    {
                        int numero = Convert.ToInt32(parametro.Fieldvalue);


                        whereClause += " AND ( " +
                                       "  public.ordem_producao.id_ordem_producao = :Numero" +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Numero", NpgsqlDbType.Integer, numero));

                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo numero");
                    }

                    break;
                case "Pedidos":
                    whereClause +=
                        " AND (" +
                        "   ordem_producao.id_ordem_producao IN ( " +
                        "   SELECT DISTINCT id_ordem_producao FROM public.ordem_producao_pedido oppPedidos WHERE oppPedidos.opp_order_number||'/'||oppPedidos.opp_order_pos LIKE :Pedidos " +
                        ")) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Pedidos", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue + "%"));
                    return true;
                case "Nova":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool valor = (bool) parametro.Fieldvalue;

                        if (valor)
                        {
                            whereClause += " AND ( " +
                                           "  public.ordem_producao.orp_situacao = 0" +
                                           ") ";
                        }


                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo boolean");
                    }

                case "EmProducao":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool valor = (bool) parametro.Fieldvalue;

                        if (valor)
                        {
                            whereClause += " AND ( " +
                                           "  public.ordem_producao.orp_situacao = 1" +
                                           ") ";
                        }


                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo boolean");
                    }

                case "Encerrada":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool valor = (bool) parametro.Fieldvalue;

                        if (valor)
                        {
                            whereClause += " AND ( " +
                                           "  public.ordem_producao.orp_situacao = 2" +
                                           ") ";
                        }


                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo boolean");
                    }
                case "Cancelada":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool valor = (bool) parametro.Fieldvalue;

                        if (valor)
                        {
                            whereClause += " AND ( " +
                                           "  public.ordem_producao.orp_situacao = 3" +
                                           ") ";
                        }


                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo boolean");
                    }

                case "AguardandoServicoExterno":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool valor = (bool) parametro.Fieldvalue;

                        if (valor)
                        {
                            whereClause += " AND ( " +
                                           "  public.ordem_producao.orp_situacao = 4" +
                                           ") ";
                        }


                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo boolean");
                    }
                case "Suspensa":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool valor = (bool) parametro.Fieldvalue;

                        if (valor)
                        {
                            whereClause += " AND ( " +
                                           "  public.ordem_producao.orp_suspensa = 1" +
                                           ") ";
                        }


                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo boolean");
                    }

                case "PossuiSaldoEnvioPostoExterno":
                    if (parametro.Fieldvalue is bool)
                    {
                        bool valor = (bool) parametro.Fieldvalue;

                        command.CommandText +=
                            "LEFT JOIN  " +
                            "  ( " +
                            "    SELECT " +
                            "    id_ordem_producao, " +
                            "    COALESCE(SUM(quantidade), 0) as qtd_utilizada " +
                            "    FROM( " +
                            "    SELECT " +
                            "      public.ordem_producao_envio_terceiros.id_ordem_producao, " +
                            "      public.ordem_producao_envio_terceiros.oet_quantidade as quantidade " +
                            "    FROM " +
                            "      public.ordem_producao_envio_terceiros " +
                            "    UNION ALL " +
                            "    SELECT " +
                            "      public.ordem_producao_envio_terceiros_cancelamento_saldo.id_ordem_producao, " +
                            "      public.ordem_producao_envio_terceiros_cancelamento_saldo.otc_quantidade as quantidade " +
                            "    FROM " +
                            "      public.ordem_producao_envio_terceiros_cancelamento_saldo " +
                            "    ) as tab1 " +
                            "    GROUP BY " +
                            "    id_ordem_producao " +
                            ") calc_uso ON calc_uso.id_ordem_producao = ordem_producao.id_ordem_producao ";

                        if (valor)
                        {
                            whereClause += " AND (ordem_producao.orp_quantidade > COALESCE(qtd_utilizada,0)) ";
                        }
                        else
                        {
                            whereClause += " AND (ordem_producao.orp_quantidade <= COALESCE(qtd_utilizada,0)) ";
                        }


                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo boolean");
                    }

                    break;
                case "PedidoIdOrderItemEtiqueta":
                    if (parametro.Fieldvalue is long)
                    {
                        command.CommandText += " INNER JOIN public.ordem_producao_pedido PedidoIdOrderItemEtiquetaTab ON (public.ordem_producao.id_ordem_producao = PedidoIdOrderItemEtiquetaTab.id_ordem_producao) ";
                        whereClause += " AND (PedidoIdOrderItemEtiquetaTab.id_order_item_etiqueta = :PedidoIdOrderItemEtiqueta) ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("PedidoIdOrderItemEtiqueta", NpgsqlDbType.Bigint, (long) parametro.Fieldvalue));
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo long");
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
                    command.CommandText +=
                        " JOIN produto prodClassificacaoProduto ON ordem_producao.id_produto = prodClassificacaoProduto.id_produto " +
                        " JOIN classificacao_produto classClassificacaoProduto ON prodClassificacaoProduto.id_classificacao_produto = classClassificacaoProduto.id_classificacao_produto ";

                    orderByClause += ", classClassificacaoProduto.clp_identificacao " + ordenacao.ToString() + " ";
                    return true;
                case "Pedidos":
                    return true;
                case "SituacaoTraduzida":
                    orderByClause += ", orp_situacao " + ordenacao.ToString() + " ";
                    return true;

                case "PostoUltimaLeitura":
                    command.CommandText +=
                        "  LEFT OUTER JOIN " +
                        "( " +
                        "    SELECT " +
                        "        public.ordem_producao_posto_trabalho.id_ordem_producao, " +
                        "        public.ordem_producao_posto_trabalho.opt_posto_codigo, " +
                        "        public.ordem_producao_posto_trabalho.opt_posto_nome, " +
                        "        public.ordem_producao_posto_trabalho.opt_posto_operacao, " +
                        "        rank() OVER w AS ran " +
                        "        FROM " +
                        "        public.ordem_producao_posto_trabalho WHERE ordem_producao_posto_trabalho.opt_operador_tempo_1 IS NOT NULL " +
                        "        WINDOW w AS(PARTITION BY " +
                        "                ordem_producao_posto_trabalho.id_ordem_producao " +
                        "                ORDER BY ordem_producao_posto_trabalho.opt_sequencia DESC " +
                        "            ) " +
                        "            ) as ultimoPostoComTempo ON (public.ordem_producao.id_ordem_producao = ultimoPostoComTempo.id_ordem_producao AND (ran IS NULL OR ran = 1)) ";

                    orderByClause += ", ultimoPostoComTempo.opt_posto_codigo " + ordenacao.ToString() + " " + ", ultimoPostoComTempo.opt_posto_nome " + ordenacao.ToString() + " " + ", ultimoPostoComTempo.opt_posto_operacao " + ordenacao.ToString() + " ";
                    return true;


                default:
                    return false;
            }
        }

        public void VerificaEncerramentoEnvioExterno(ref IWTPostgreNpgsqlCommand command)
        {
            if (this.Situacao != StatusOrdemProducao.AguardandoServicoExterno)
            {
                return;
            }

            if (Math.Abs(SaldoEnvioFornecedor) < 0.00001)
            {
                if (this.CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao.All(a => a.TotalmenteRecebido))
                {
                    this.Situacao = StatusOrdemProducao.Producao;
                    this.PostoUltimaLeituraEntidade.AcsUsuarioTempo2 = UsuarioAtual;
                    this.PostoUltimaLeituraEntidade.Tempo2 = DataIndependenteClass.GetData();

                    double qtdFinal = 0;
                    foreach (OrdemProducaoEnvioTerceirosClass envio in CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao)
                    {
                        qtdFinal = Math.Round(qtdFinal + envio.CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Sum(a => a.Quantidade), 5);
                    }

                    this.PostoUltimaLeituraEntidade.QuantidadeSaida = qtdFinal;
                    this.PostoUltimaLeituraEntidade.OperadorTempo2 = UsuarioAtual.Login;


                    if (Math.Abs(this.PostoUltimaLeituraEntidade.QuantidadeSaida.Value - this.PostoUltimaLeituraEntidade.QuantidadeEntrada.Value) > 0.00001)
                    {
                        //Verificar se a justificativa é obrigatória em caso de diferença de quantidade
                    }


                }
            }

            Save(ref command);


        }

        public void AlterarStatusEncerradoParaCancelado(ref IWTPostgreNpgsqlCommand command)
        {
            if (Situacao != StatusOrdemProducao.Encerrada)
            {
                throw new ExcecaoTratada("A ordem de produção " + this + " não está na situação de encerrada");
            }

            Situacao = StatusOrdemProducao.Cancelada;

            foreach (OrdemProducaoPedidoClass pedido in this.CollectionOrdemProducaoPedidoClassOrdemProducao)
            {
                pedido.OrderItemEtiqueta.OrdemProducaoImpressa = false;
                pedido.OrderItemEtiqueta.OrdemProducaoImpressaData = null;
                pedido.OrderItemEtiqueta.Save(ref command);
                pedido.Save(ref command);
            }

            CollectionOrdemProducaoHistoricoClassOrdemProducao.Add(new OrdemProducaoHistoricoClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
            {
                OrdemProducao = this,
                AcsUsuario = LoginClass.UsuarioLogado.loggedUser,
                DataHora = DataIndependenteClass.GetData(),
                Historico = "Alteração de Status de Encerrado para Cancelado",
            });

            Save(ref command);
        }
    }
}
