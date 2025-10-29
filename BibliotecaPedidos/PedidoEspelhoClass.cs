using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;

namespace BibliotecaPedidos
{

    public class PedidoEspelhoClass
    {
        public bool ExibirValores { get; }


        public byte[] logoEmpresa { get; private set; }
        public string tituloRelatorio { get; private set; }

        //Dados do Cliente
        public long idCliente { get; private set; }
        public string cliente { get; private set; }
        public string cnpjCliente { get; private set; }
        public string enderecoCliente { get; private set; }
        public string bairroCliente { get; private set; }
        public string cepCliente { get; private set; }
        public string cidadeCliente { get; private set; }
        public string foneCliente { get; private set; }
        public string ufCliente { get; private set; }
        public string inscricaoEstadualCliente { get; private set; }

        //Dados do Pedido
        public string numero { get; private set; }
        public int posicao { get; private set; }
        public string operacao { get; private set; }
        public string projeto { get; private set; }
        public string armazenagem { get; private set; }
        public string ordemVenda { get; private set; }
        public DateTime dataPedido { get; private set; }
        public string formaPagamento { get; private set; }

        public bool representanteEnvioEmail { get; private set; }
        public string representanteEmail { get; private set; }
        public string observacaoPadraoEspelho { get; private set; }
        public string observacaoPadraoEspelhoSistema { get; private set; }

        public string ultimaRevisaoPedido { get; private set; }

        //Dados da linha do grupo
        public long idProdutoHeader { get; private set; }
        public string codProdutoHeader { get; private set; }
        public string codProdutoClienteHeader { get; private set; }
        public string descricaoHeader { get; private set; }
        public double qtdHeader { get; private set; }
        public double valorUnitarioHeader { get; private set; }
        public double valorTotalHeader { get; private set; }
        public string ncmHeader { get; private set; }
        public string informacoesEspeciaisHeader { get; private set; }
        public DateTime dataEntregaHeader { get; private set; }
        public DateTime dataEntregaOriginalHeader { get; private set; }
        public double percIpiHeader { get; private set; }
        public double percIcmHeader { get; private set; }
        public string numeroPosicaoHeader { get; private set; }
        public double valorTotalSoma { get; private set; }


        //Dados da linha do produto (Produtos)
        public int linha { get; private set; }
        public string codProduto { get; private set; }
        public string codProdutoCliente { get; private set; }
        public string descricao { get; private set; }
        public double qtd { get; private set; }
        public bool primeiraSublinha { get; private set; }








        public PedidoEspelhoClass( //Dados do Pedido
            PedidoOrcamento tipo, byte[] logoEmpresa, long idCliente, string cliente, string cnpjCliente, string enderecoCliente, string bairroCliente, string cepCliente,
            string cidadeCliente, string foneCliente, string ufCliente, string inscricaoEstadualCliente, string numero, int posicao,
            string operacao, string projeto, string armazenagem, string ordemVenda, DateTime dataPedido, string formaPagamento, bool representanteEnvioEmail, string representanteEmail, string obsPadraoEspelho,
            string ultimaRevisaoPedido,
            //Dados do Grupo
            string numeroPosicaoHeader, long idProdutoHeader, string codProdutoHeader, string codProdutoClienteHeader, string descricaoHeader, double qtdHeader, double valorUnitarioHeader, double valorTotalHeader,
            string ncmHeader, string informacoesEspeciaisHeader, DateTime dataEntregaHeader, DateTime dataEntregaOriginalHeader, double percIpiHeader, double percIcmHeader,
            //Dados das Linhas(Detail)
            int linha, string codProduto, string codProdutoCliente, string descricao, double qtd, bool exibirValores)
        {
            ExibirValores = exibirValores;
            //Dados do Pedido
            this.tituloRelatorio = tipo == PedidoOrcamento.Pedido ? "Pedido" : "Orçamento";
            this.logoEmpresa = logoEmpresa;
            this.idCliente = idCliente;
            this.cliente = cliente;
            this.cnpjCliente = cnpjCliente;
            this.enderecoCliente = enderecoCliente;
            this.bairroCliente = bairroCliente;
            this.cepCliente = cepCliente;
            this.cidadeCliente = cidadeCliente;
            this.foneCliente = foneCliente;
            this.ufCliente = ufCliente;
            this.inscricaoEstadualCliente = inscricaoEstadualCliente;
            this.numero = numero;
            this.posicao = posicao;
            this.operacao = operacao;
            this.projeto = projeto;
            this.armazenagem = armazenagem;
            this.ordemVenda = ordemVenda;
            this.dataPedido = dataPedido;
            this.formaPagamento = formaPagamento;
            this.representanteEnvioEmail = representanteEnvioEmail;
            this.representanteEmail = representanteEmail;
            this.observacaoPadraoEspelho = obsPadraoEspelho;
            this.observacaoPadraoEspelhoSistema = IWTConfiguration.Conf.getConf(Constants.OBSERVACAO_PADRAO_ESPELHO_PEDIDO_ORCAMENTO);
            this.ultimaRevisaoPedido = ultimaRevisaoPedido;

            //Dados do Grupo
            this.numeroPosicaoHeader = numeroPosicaoHeader;
            this.idProdutoHeader = idProdutoHeader;
            this.codProdutoHeader = codProdutoHeader;
            this.codProdutoClienteHeader = codProdutoClienteHeader;
            this.descricaoHeader = descricaoHeader;
            this.qtdHeader = qtdHeader;
            this.valorUnitarioHeader = valorUnitarioHeader;
            this.valorTotalHeader = valorTotalHeader;
            this.ncmHeader = ncmHeader;
            this.informacoesEspeciaisHeader = informacoesEspeciaisHeader;
            this.dataEntregaHeader = dataEntregaHeader;
            this.dataEntregaOriginalHeader = dataEntregaOriginalHeader;
            this.percIpiHeader = percIpiHeader;
            this.percIcmHeader = percIcmHeader;

            if (linha == 0)
            {
                this.valorTotalSoma = valorTotalHeader;
            }

            //Dados das linhas (Detail)
            this.linha = linha;
            this.codProduto = codProduto;
            this.codProdutoCliente = codProdutoCliente;
            this.descricao = descricao;
            this.qtd = qtd;
        }


        public static List<PedidoEspelhoClass> gerar(List<PedidoEspelhoParametrosBuscaClass> parametros, PedidoOrcamento tipo,bool exibirValores,  ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (tipo == PedidoOrcamento.Pedido)
                {
                    return GerarRelatorioPedidos(parametros,exibirValores, ref command);
                }
                else
                {
                    return GerarRelatorioOrcamentos(parametros, ref command);
                }
                return new List<PedidoEspelhoClass>();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter os dados do pedido.\r\n" + e.Message, e);
            }
        }


        public static List<PedidoEspelhoClass> GerarRelatorioPedidos(List<PedidoEspelhoParametrosBuscaClass> parametros,bool exibirValores, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);
                if (tmp != null)
                {
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    tmp = ms.ToArray();
                }

                List<PedidoEspelhoClass> toRet = new List<PedidoEspelhoClass>();

                string whereClause = null;

                string sql =
                    "SELECT " +
                    "  public.cliente.id_cliente, " +
                    "  public.cliente.cli_nome, " +
                    "  public.cliente.cli_cnpj, " +
                    "  public.cliente.cli_endereco_cob, " +
                    "  public.cliente.cli_endereco_numero_cob, " +
                    "  public.cliente.cli_complemento_cob, " +
                    "  public.cliente.cli_bairro_cob, " +
                    "  public.cliente.cli_cep_cob, " +
                    "  public.cidade.cid_nome, " +
                    "  public.cliente.cli_fone1, " +
                    "  public.estado.est_sigla, " +
                    "  public.cliente.cli_ie, " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao, " +
                    "  public.pedido_item.pei_sub_linha, " +
                    "  public.operacao.ope_descricao, " +
                    "  public.pedido_item.pei_projeto_cliente, " +
                    "  public.pedido_item.pei_armazenagem_cliente, " +
                    "  public.pedido_item.pei_ordem_venda,  " +
                    "  public.pedido_item.pei_data_entrada,  " +
                    "  public.pedido_item.pei_produto_codigo_cliente," +
                    "  public.pedido_item.pei_produto_descricao_cliente," +
                    "  COALESCE(public.forma_pagamento.fop_descricao, forma_pagamento_cliente.fop_descricao) as fop_descricao,  " +
                    "  public.produto.id_produto, " +
                    "  public.produto.pro_codigo, " +
                    "  public.pedido_item.pei_quantidade, " +
                    "  public.pedido_item.pei_preco_unitario, " +
                    "  public.pedido_item.pei_preco_total, " +
                    "  ncm_pedido.ncm_codigo as ncm_do_pedido, " +
                    "  public.pedido_item.pei_informacao_especial, " +
                    "  public.pedido_item.pei_data_entrega, " +
                    "  public.pedido_item.pei_data_entrega_original, " +
                    "   CASE WHEN representante_pedido IS NOT NULL THEN representante_pedido.rep_envio_email ELSE represetante_cliente.rep_envio_email END as representante_envio_email, " +
                    "   CASE WHEN representante_pedido IS NOT NULL THEN representante_pedido.rep_email ELSE represetante_cliente.rep_email END as representante_email, " +
                    "   public.pedido_item.pei_obs_padrao_espelho, " +
                    "   CASE WHEN public.operacao.ope_incide_ipi = 1 THEN public.ncm.ncm_ipi_aliquota ELSE 0 END as ipi, " +
                    "   CASE WHEN public.operacao.ope_incide_icms = 1 THEN public.modelo_fiscal_icms_estado.mfe_aliquota ELSE 0 END as icms, " +
                    "  public.pedido_item.pei_data_ultima_alteracao " +
                    "FROM " +
                    "  public.pedido_item " +
                    "  LEFT JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                    "  LEFT JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto) " +
                    "  LEFT JOIN public.cidade ON (public.cliente.id_cidade_cob = public.cidade.id_cidade) " +
                    "  LEFT JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                    "  LEFT JOIN public.operacao ON (public.pedido_item.id_operacao = public.operacao.id_operacao) " +
                    "  LEFT JOIN public.forma_pagamento ON (public.pedido_item.id_forma_pagamento = public.forma_pagamento.id_forma_pagamento) " +
                    "  LEFT JOIN public.forma_pagamento forma_pagamento_cliente ON (public.cliente.id_forma_pagamento = forma_pagamento_cliente.id_forma_pagamento) " +
                    "  LEFT OUTER JOIN public.representante representante_pedido ON (public.pedido_item.id_representante = representante_pedido.id_representante)  " +
                    "  LEFT OUTER JOIN public.representante represetante_cliente ON (public.cliente.id_representante = represetante_cliente.id_representante) " +
                    "  LEFT OUTER JOIN public.produto_fiscal ON (public.produto.id_produto = public.produto_fiscal.id_produto) " +
                    "  LEFT OUTER JOIN public.ncm ON (public.produto_fiscal.id_ncm = public.ncm.id_ncm) " +
                    "  LEFT OUTER JOIN public.modelo_fiscal_icms_estado ON (public.cliente.id_estado_cob = public.modelo_fiscal_icms_estado.id_estado AND public.produto_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms) " +
                    "  LEFT OUTER JOIN public.ncm as ncm_pedido ON pedido_item.id_ncm = ncm_pedido.id_ncm " +
                    "";


                if (parametros.ToArray().Length > 0)
                {
                    int count = 0;
                    int tipoImpressaoPedidoKit = int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_IMPRESSAO_ESPELHO_PEDIDO));

                    whereClause = " WHERE ";
                    while (count < parametros.ToArray().Length)
                    {
                        if (count == 0)
                        {
                            whereClause += " (public.cliente.id_cliente = " + parametros.ToArray()[count].idCliente + ") ";
                        }
                        else
                        {
                            whereClause += " OR (public.cliente.id_cliente = " + parametros.ToArray()[count].idCliente + ") ";
                        }

                        if (parametros.ToArray()[count].numero != null)
                        {
                            whereClause += "AND (public.pedido_item.pei_numero = '" + parametros.ToArray()[count].numero +
                                           "') ";
                        }
                        if (parametros.ToArray()[count].posicao != null)
                        {
                            whereClause += "AND (public.pedido_item.pei_posicao = " + parametros.ToArray()[count].posicao + ") ";
                        }
                        count++;
                    }

                    //Se for para imprimir somente as sublinhas zero dos pedidos kit
                    if (tipoImpressaoPedidoKit == 1)
                    {
                        whereClause += " AND (public.pedido_item.pei_sub_linha = 0 ) ";
                    }
                }

                string orderByClause = " ORDER BY public.cliente.cli_nome,  " +
                                       "public.pedido_item.pei_numero, " +
                                       "public.pedido_item.pei_posicao, " +
                                       "public.pedido_item.pei_sub_linha, " +
                                       "public.produto.pro_codigo";

                sql += whereClause + orderByClause;


                command.CommandText = sql;


                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                //Declaração das variáveis do grupo
                int idProdutoGrupo = 0;
                string codProdutoGrupo = "";
                string codProdutoClienteGrupo = "";
                string descricaoGrupo = "";
                double qtdGrupo = 0.0;
                double valorUnitarioGrupo = 0.0;
                double valorTotalGrupo = 0.0;
                string ncmGrupo = "";
                string informacoesEspeciaisGrupo = "";
                DateTime dataEntregaGrupo = new DateTime();
                DateTime dataEntregaOriginalGrupo = new DateTime();
                double percIpiGrupo = 0.0;
                double percIcmGrupo = 0.0;
                string numeroPosicaoHeader = "";
                bool primeiraSublinha = true;
                string observacaoPedido = "";
                string ultimaRevisaoPedido = "";

                while (read.Read())
                {
                    if (Convert.ToInt16(read["pei_sub_linha"].ToString()) == 0)
                    {
                        numeroPosicaoHeader = read["pei_numero"].ToString() + "/" + read["pei_posicao"].ToString();
                        idProdutoGrupo = int.Parse(read["id_produto"].ToString());
                        codProdutoGrupo = read["pro_codigo"].ToString();
                        codProdutoClienteGrupo = read["pei_produto_codigo_cliente"].ToString();
                        descricaoGrupo = read["pei_produto_descricao_cliente"].ToString();
                        qtdGrupo = double.Parse(read["pei_quantidade"].ToString());
                        valorUnitarioGrupo = double.Parse(read["pei_preco_unitario"].ToString());
                        valorTotalGrupo = double.Parse(read["pei_preco_total"].ToString());
                        ncmGrupo = read["ncm_do_pedido"].ToString();
                        informacoesEspeciaisGrupo = read["pei_informacao_especial"].ToString();
                        dataEntregaGrupo = Convert.ToDateTime(read["pei_data_entrega"].ToString());
                        dataEntregaOriginalGrupo = read["pei_data_entrega_original"] == DBNull.Value ? dataEntregaGrupo : Convert.ToDateTime(read["pei_data_entrega_original"]);
                        
                        percIpiGrupo = read["ipi"] != DBNull.Value ? Convert.ToDouble(read["ipi"].ToString()) : 0;
                        percIcmGrupo = read["icms"] != DBNull.Value ? Convert.ToDouble(read["icms"].ToString()) : 0;
                        primeiraSublinha = false;
                        observacaoPedido = read["pei_obs_padrao_espelho"].ToString();
                        ultimaRevisaoPedido = Convert.ToDateTime(read["pei_data_ultima_alteracao"]).ToString("dd/MM/yyyy HH:mm:ss");

                    }

                    toRet.Add(
                        new PedidoEspelhoClass(
                            PedidoOrcamento.Pedido,
                            tmp,
                            Convert.ToInt32(read["id_cliente"].ToString()),
                            read["cli_nome"].ToString(),
                            read["cli_cnpj"].ToString(),
                            read["cli_endereco_cob"].ToString() + ", " + read["cli_endereco_numero_cob"] + " " + read["cli_complemento_cob"],
                            read["cli_bairro_cob"].ToString(),
                            read["cli_cep_cob"].ToString(),
                            read["cid_nome"].ToString(),
                            read["cli_fone1"].ToString(),
                            read["est_sigla"].ToString(),
                            read["cli_ie"].ToString(),
                            read["pei_numero"].ToString(),
                            int.Parse(read["pei_posicao"].ToString()),
                            read["ope_descricao"].ToString(),
                            read["pei_projeto_cliente"].ToString(),
                            read["pei_armazenagem_cliente"].ToString(),
                            read["pei_ordem_venda"].ToString(),
                            Convert.ToDateTime(read["pei_data_entrada"].ToString()),
                            read["fop_descricao"].ToString(),
                            read["representante_envio_email"] != DBNull.Value && Convert.ToBoolean(Convert.ToInt16(read["representante_envio_email"].ToString())),
                            read["representante_email"].ToString(),
                           observacaoPedido,
                           ultimaRevisaoPedido,
                            numeroPosicaoHeader,
                            idProdutoGrupo,
                            codProdutoGrupo,
                            codProdutoClienteGrupo,
                            descricaoGrupo,
                            qtdGrupo,
                            valorUnitarioGrupo,
                            valorTotalGrupo,
                            ncmGrupo,
                            informacoesEspeciaisGrupo,
                            dataEntregaGrupo,
                            dataEntregaOriginalGrupo,
                            percIpiGrupo,
                            percIcmGrupo,
                            int.Parse(read["pei_sub_linha"].ToString()),
                            read["pro_codigo"].ToString(),
                            read["pei_produto_codigo_cliente"].ToString(),
                            read["pei_produto_descricao_cliente"].ToString(),
                            double.Parse(read["pei_quantidade"].ToString()),
                            exibirValores
                            )
                        );
                    toRet[toRet.Count - 1].primeiraSublinha = primeiraSublinha;
                    if (toRet[toRet.Count - 1].linha != 0)
                    {
                        primeiraSublinha = false;
                    }
                    else
                    {
                        primeiraSublinha = true;
                    }

                }
                read.Close();

                if (toRet.Count == 0)
                {
                    throw new ExcecaoTratada("Os parâmetros informados não geraram nenhum registro no relatório");
                }



                //Organiza Obs Pedido

                Dictionary<ChavePedido, string> observacoes = new Dictionary<ChavePedido, string>();

                foreach (PedidoEspelhoClass pedido in toRet)
                {
                    ChavePedido chave = new ChavePedido(pedido.idCliente,pedido.numero);
                    if (!observacoes.ContainsKey(chave))
                    {
                        observacoes.Add(chave, "");
                    }

                    if (!observacoes[chave].Contains(pedido.observacaoPadraoEspelho.Trim()))
                    {
                        observacoes[chave] = observacoes[chave] + pedido.observacaoPadraoEspelho.Trim() + " - ";
                    }
                }

                foreach (PedidoEspelhoClass pedido in toRet)
                {
                    ChavePedido chave = new ChavePedido(pedido.idCliente,pedido.numero);
                    pedido.observacaoPadraoEspelho = observacoes[chave].Length > 0 ? observacoes[chave].Substring(0, observacoes[chave].Length - 3) : "";

                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter os dados do pedido.\r\n" + e.Message, e);
            }
        }

        private class ChavePedido : IEquatable<ChavePedido>
        {
            public long IdCliente { get; }
            public string NumeroPedido { get; }

            public bool Equals(ChavePedido other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return IdCliente == other.IdCliente && NumeroPedido == other.NumeroPedido;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ChavePedido) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (IdCliente.GetHashCode() * 397) ^ (NumeroPedido != null ? NumeroPedido.GetHashCode() : 0);
                }
            }

            public ChavePedido(long idCliente, string numeroPedido)
            {
                IdCliente = idCliente;
                NumeroPedido = numeroPedido;
            }
        }

        public static List<PedidoEspelhoClass> GerarRelatorioOrcamentos(List<PedidoEspelhoParametrosBuscaClass> parametros, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);
                if (tmp != null)
                {
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    tmp = ms.ToArray();
                }

                List<PedidoEspelhoClass> toRet = new List<PedidoEspelhoClass>();

                string whereClause = null;

                string sql =
                    "SELECT " +
                    "  public.cliente.id_cliente, " +
                    "  public.cliente.cli_nome, " +
                    "  public.cliente.cli_cnpj, " +
                    "  public.cliente.cli_endereco_cob, " +
                    "  public.cliente.cli_endereco_numero_cob, " +
                    "  public.cliente.cli_complemento_cob, " +
                    "  public.cliente.cli_bairro_cob, " +
                    "  public.cliente.cli_cep_cob, " +
                    "  public.cidade.cid_nome, " +
                    "  public.cliente.cli_fone1, " +
                    "  public.estado.est_sigla, " +
                    "  public.cliente.cli_ie, " +
                    "  public.orcamento_item.ori_numero, " +
                    "  public.orcamento_item.ori_posicao, " +
                    "  public.orcamento_item.ori_sub_linha, " +
                    "  public.operacao.ope_descricao, " +
                    "  public.orcamento_item.ori_projeto_cliente, " +
                    "  public.orcamento_item.ori_armazenagem_cliente, " +
                    "  public.orcamento_item.ori_ordem_venda,  " +
                    "  public.orcamento_item.ori_data_entrada,  " +
                    "  public.orcamento_item.ori_produto_codigo_cliente,  " +
                    "  public.orcamento_item.ori_produto_descricao_cliente,  " +
                    "  public.forma_pagamento.fop_descricao,  " +
                    "  public.produto.id_produto, " +
                    "  public.produto.pro_codigo, " +
                    "  public.orcamento_item.ori_quantidade, " +
                    "  public.orcamento_item.ori_preco_unitario, " +
                    "  public.orcamento_item.ori_preco_total, " +
                    "  public.orcamento_item.ori_nbm, " +
                    "  public.orcamento_item.ori_informacao_especial, " +
                    "  public.orcamento_item.ori_data_entrega, " +
                    "  public.orcamento_item.ori_data_entrega_original, " +
                    "   CASE WHEN representante_pedido IS NOT NULL THEN representante_pedido.rep_envio_email ELSE represetante_cliente.rep_envio_email END as representante_envio_email, " +
                    "   CASE WHEN representante_pedido IS NOT NULL THEN representante_pedido.rep_email ELSE represetante_cliente.rep_email END as representante_email, " +
                    "   public.orcamento_item.ori_obs_padrao_espelho, " +
                    "   CASE WHEN public.operacao.ope_incide_ipi = 1 THEN public.ncm.ncm_ipi_aliquota ELSE 0 END as ipi, " +
                    "   CASE WHEN public.operacao.ope_incide_icms = 1 THEN public.modelo_fiscal_icms_estado.mfe_aliquota ELSE 0 END as icms " +
                    "FROM " +
                    "  public.orcamento_item " +
                    "  LEFT JOIN public.cliente ON (public.orcamento_item.id_cliente = public.cliente.id_cliente) " +
                    "  LEFT JOIN public.produto ON (public.orcamento_item.id_produto = public.produto.id_produto) " +
                    "  LEFT JOIN public.cidade ON (public.cliente.id_cidade_cob = public.cidade.id_cidade) " +
                    "  LEFT JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                    "  LEFT JOIN public.operacao ON (public.orcamento_item.id_operacao = public.operacao.id_operacao) " +
                    "  LEFT JOIN public.forma_pagamento ON (public.orcamento_item.id_forma_pagamento = public.forma_pagamento.id_forma_pagamento) " +
                    "  LEFT OUTER JOIN public.representante representante_pedido ON (public.orcamento_item.id_representante = representante_pedido.id_representante)  " +
                    "  LEFT OUTER JOIN public.representante represetante_cliente ON (public.cliente.id_representante = represetante_cliente.id_representante) " +
                    "  LEFT OUTER JOIN public.produto_fiscal ON (public.produto.id_produto = public.produto_fiscal.id_produto) " +
                    "  LEFT OUTER JOIN public.ncm ON (public.produto_fiscal.id_ncm = public.ncm.id_ncm) " +
                    "  LEFT OUTER JOIN public.modelo_fiscal_icms_estado ON (public.cliente.id_estado_cob = public.modelo_fiscal_icms_estado.id_estado AND public.produto_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms) " +
                    "";

                if (parametros.ToArray().Length > 0)
                {

                    int count = 0;
                    int tipoImpressaoPedidoKit = int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_IMPRESSAO_ESPELHO_PEDIDO));
                    whereClause = " WHERE ";
                    while (count < parametros.ToArray().Length)
                    {
                        if (count == 0)
                        {
                            whereClause += " (public.cliente.id_cliente = " + parametros.ToArray()[count].idCliente + ") ";
                        }
                        else
                        {
                            whereClause += " OR (public.cliente.id_cliente = " + parametros.ToArray()[count].idCliente + ") ";
                        }

                        if (parametros.ToArray()[count].numero != null)
                        {
                            whereClause += "AND (public.orcamento_item.ori_numero = '" + parametros.ToArray()[count].numero +
                                           "') ";
                        }
                        if (parametros.ToArray()[count].posicao != null)
                        {
                            whereClause += "AND (public.orcamento_item.ori_posicao = " + parametros.ToArray()[count].posicao + ") ";
                        }
                        count++;
                    }

                    //Se for para imprimir somente as sublinhas zero dos pedidos kit
                    if (tipoImpressaoPedidoKit == 1)
                    {
                        whereClause += " AND (public.orcamento_item.ori_sub_linha = 0 ) ";
                    }
                }

                string orderByClause = " ORDER BY public.cliente.cli_nome,  " +
                                       "public.orcamento_item.ori_numero, " +
                                       "public.orcamento_item.ori_posicao, " +
                                       "public.orcamento_item.ori_sub_linha, " +
                                       "public.produto.pro_codigo";

                sql += whereClause + orderByClause;


                command.CommandText = sql;


                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();


                //Declaração das variáveis do grupo
                int idProdutoGrupo = 0;
                string codProdutoGrupo = "";
                string codProdutoClienteGrupo = "";
                string descricaoGrupo = "";
                double qtdGrupo = 0.0;
                double valorUnitarioGrupo = 0.0;
                double valorTotalGrupo = 0.0;
                string ncmGrupo = "";
                string informacoesEspeciaisGrupo = "";
                DateTime dataEntregaGrupo = new DateTime();
                DateTime dataEntregaOriginalGrupo = new DateTime();
                double percIpiGrupo = 0.0;
                double percIcmGrupo = 0.0;
                string numeroPosicaoHeader = "";
                bool primeiraSublinha = true;
                string observacaoPedido = "";

                while (read.Read())
                {
                    if (Convert.ToInt16(read["ori_sub_linha"].ToString()) == 0)
                    {
                        numeroPosicaoHeader = read["ori_numero"].ToString() + "/" + read["ori_posicao"].ToString();
                        idProdutoGrupo = int.Parse(read["id_produto"].ToString());
                        codProdutoGrupo = read["pro_codigo"].ToString();
                        codProdutoClienteGrupo = read["pro_codigo_cliente"].ToString();
                        descricaoGrupo = read["pro_descricao"].ToString();
                        qtdGrupo = double.Parse(read["ori_quantidade"].ToString());
                        valorUnitarioGrupo = double.Parse(read["ori_preco_unitario"].ToString());
                        valorTotalGrupo = double.Parse(read["ori_preco_total"].ToString());
                        ncmGrupo = read["ori_nbm"].ToString();
                        informacoesEspeciaisGrupo = read["ori_informacao_especial"].ToString();
                        dataEntregaGrupo = Convert.ToDateTime(read["ori_data_entrega"]);
                        dataEntregaOriginalGrupo = read["ori_data_entrega_original"] == DBNull.Value ? dataEntregaGrupo : Convert.ToDateTime(read["ori_data_entrega_original"]);

                        percIpiGrupo = read["ipi"] != DBNull.Value ? Convert.ToDouble(read["ipi"].ToString()) : 0;
                        percIcmGrupo = read["icms"] != DBNull.Value ? Convert.ToDouble(read["icms"].ToString()) : 0;

                        primeiraSublinha = false;
                        observacaoPedido = read["ori_obs_padrao_espelho"].ToString();
                    }

                    toRet.Add(
                        new PedidoEspelhoClass(
                            PedidoOrcamento.Orcamento,
                            tmp,
                            Convert.ToInt32(read["id_cliente"].ToString()),
                            read["cli_nome"].ToString(),
                            read["cli_cnpj"].ToString(),
                            read["cli_endereco_cob"].ToString() + ", " + read["cli_endereco_numero_cob"] + " " + read["cli_complemento_cob"],
                            read["cli_bairro_cob"].ToString(),
                            read["cli_cep_cob"].ToString(),
                            read["cid_nome"].ToString(),
                            read["cli_fone1"].ToString(),
                            read["est_sigla"].ToString(),
                            read["cli_ie"].ToString(),
                            read["ori_numero"].ToString(),
                            int.Parse(read["ori_posicao"].ToString()),
                            read["ope_descricao"].ToString(),
                            read["ori_projeto_cliente"].ToString(),
                            read["ori_armazenagem_cliente"].ToString(),
                            read["ori_ordem_venda"].ToString(),
                            Convert.ToDateTime(read["ori_data_entrada"].ToString()),
                            read["fop_descricao"].ToString(),
                            read["representante_envio_email"] != DBNull.Value &&
                            Convert.ToBoolean(Convert.ToInt16(read["representante_envio_email"].ToString())),
                            read["representante_email"].ToString(),
                            observacaoPedido,
                            "",
                            numeroPosicaoHeader,
                            idProdutoGrupo,
                            codProdutoGrupo,
                            codProdutoClienteGrupo,
                            descricaoGrupo,
                            qtdGrupo,
                            valorUnitarioGrupo,
                            valorTotalGrupo,
                            ncmGrupo,
                            informacoesEspeciaisGrupo,
                            dataEntregaGrupo,
                            dataEntregaOriginalGrupo,
                            percIpiGrupo,
                            percIcmGrupo,
                            int.Parse(read["ori_sub_linha"].ToString()),
                            read["pro_codigo"].ToString(),
                            read["ori_produto_codigo_cliente"].ToString(),
                            read["ori_produto_descricao_cliente"].ToString(),
                            double.Parse(read["ori_quantidade"].ToString()),
                            true
                            )
                        );

                    toRet[toRet.Count - 1].primeiraSublinha = primeiraSublinha;
                    if (toRet[toRet.Count - 1].linha != 0)
                    {
                        primeiraSublinha = false;
                    }
                    else
                    {
                        primeiraSublinha = true;
                    }

                }
                read.Close();

                if (toRet.Count == 0)
                {
                    throw new ExcecaoTratada("Os parâmetros informados não geraram nenhum registro no relatório");
                }
                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter os dados do orçamento.\r\n" + e.Message, e);
            }
        }

        public static List<PedidoEspelhoClass> GerarRelatorio(PedidoAgrupador AgrupadorPedido)
        {
            try
            {
                byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);
                if (tmp != null)
                {
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    tmp = ms.ToArray();
                }

                List<PedidoEspelhoClass> toRet = new List<PedidoEspelhoClass>();

                if (AgrupadorPedido.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    //Declaração das variáveis do grupo
                    long idProdutoGrupo = 0;
                    string codProdutoGrupo = "";
                    string codProdutoClienteGrupo = "";
                    string descricaoGrupo = "";
                    double qtdGrupo = 0.0;
                    double valorUnitarioGrupo = 0.0;
                    double valorTotalGrupo = 0.0;
                    string ncmGrupo = "";
                    string informacoesEspeciaisGrupo = "";
                    DateTime dataEntregaGrupo = new DateTime();
                    DateTime dataEntregaOriginalGrupo = new DateTime();
                    double percIpiGrupo = 0.0;
                    double percIcmGrupo = 0.0;
                    string numeroPosicaoHeader = "";

                    bool primeiraSublinha = true;
                    string observacaoPedido = "";
                    string ultimaRevisaoPedido = "";

                    string descricaoOperacao = "";

                    foreach (PedidoItemClass item in AgrupadorPedido.Pedidos.OrderBy(a=>a.SubLinha))
                    {
                       
                        if (item.SubLinha== 0)
                        {
                            numeroPosicaoHeader = item.Numero + "/" + item.Posicao;
                            idProdutoGrupo = item.Produto.ID;
                            codProdutoGrupo = item.Produto.Codigo;
                            codProdutoClienteGrupo = item.Produto.CodigoCliente;
                            descricaoGrupo = item.Produto.Descricao;
                            qtdGrupo = item.Quantidade;
                            valorUnitarioGrupo = item.PrecoUnitario;
                            valorTotalGrupo = item.PrecoTotal;
                            ncmGrupo = item.Ncm != null ? item.Ncm.Codigo : "";
                            informacoesEspeciaisGrupo = item.InformacaoEspecial;
                            dataEntregaGrupo = item.DataEntrega;
                            dataEntregaOriginalGrupo = item.DataEntregaOriginal.HasValue ? item.DataEntregaOriginal.Value : dataEntregaGrupo;

                           
                            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                            {
                                percIpiGrupo = item.OperacaoCompleta.IpiIncide == IncidenciaIPI.Incide ? item.OperacaoCompleta.IpiAliquota : 0;
                                percIcmGrupo = item.OperacaoCompleta.IcmsIncide == IncidenciaImposto.Incide ? item.OperacaoCompleta.CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.First(a => a.Estado == item.Cliente.EstadoCob).Aliquota
                                    : 0;
                                descricaoOperacao = item.OperacaoCompleta.Descricao;
                            }
                            else
                            {
                                percIpiGrupo = item.Operacao.IncideIpi == IncidenciaImposto.Incide && item.Produto.CollectionProdutoFiscalClassProduto != null && item.Produto.CollectionProdutoFiscalClassProduto.Count > 0 ? item.Produto.CollectionProdutoFiscalClassProduto[0].Ncm.IpiAliquota : 0;
                                percIcmGrupo = item.Operacao.IncideIcms == IncidenciaImposto.Incide && item.Produto.CollectionProdutoFiscalClassProduto != null && item.Produto.CollectionProdutoFiscalClassProduto.Count > 0 && item.Produto.CollectionProdutoFiscalClassProduto[0].ModeloFiscalIcms != null && item.Produto.CollectionProdutoFiscalClassProduto[0].ModeloFiscalIcms.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms != null && item.Produto.CollectionProdutoFiscalClassProduto[0].ModeloFiscalIcms.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Count > 0
                                    ? item.Produto.CollectionProdutoFiscalClassProduto[0].ModeloFiscalIcms.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.First(a => a.Estado == item.Cliente.EstadoCob).Aliquota
                                    : 0;
                                descricaoOperacao = item.Operacao.Descricao;
                            }

                            primeiraSublinha = false;
                            observacaoPedido = item.ObsPadraoEspelho;
                            ultimaRevisaoPedido = item.DataUltimaAlteracao.ToString("dd/MM/yyyy HH:mm:ss");

                        }

                        toRet.Add(
                            new PedidoEspelhoClass(
                                PedidoOrcamento.Pedido,
                                tmp,
                                item.Cliente.ID,
                                item.Cliente.Nome,
                                item.Cliente.Cnpj,
                                item.Cliente.EnderecoCob +", "+item.Cliente.EnderecoNumeroCob+" "+item.Cliente.ComplementoCob,
                                item.Cliente.BairroCob,
                                item.Cliente.CepCob,
                                item.Cliente.CidadeCob.ToString(),
                                item.Cliente.Fone1,
                                item.Cliente.CidadeCob.Estado.ToString(),
                                item.Cliente.Ie,
                                item.Numero,
                                item.Posicao,
                                descricaoOperacao,
                                item.ProjetoCliente,
                                item.ArmazenagemCliente,
                                item.OrdemVenda,
                                item.DataEntrada,
                                item.FormaPagamento !=null ?item.FormaPagamento.Descricao:"",
                                item.Representante != null && item.Representante.EnvioEmail,
                                item.Representante != null ? item.Representante.Email : "",
                                observacaoPedido,
                                ultimaRevisaoPedido,
                                numeroPosicaoHeader,
                                idProdutoGrupo,
                                codProdutoGrupo,
                                codProdutoClienteGrupo,
                                descricaoGrupo,
                                qtdGrupo,
                                valorUnitarioGrupo,
                                valorTotalGrupo,
                                ncmGrupo,
                                informacoesEspeciaisGrupo,
                                dataEntregaGrupo,
                                dataEntregaOriginalGrupo,
                                percIpiGrupo,
                                percIcmGrupo,
                                item.SubLinha,
                                item.Produto.Codigo,
                                item.Produto.CodigoCliente,
                                item.Produto.Descricao,
                                item.Quantidade,
                                true
                                )
                            );

                        toRet[toRet.Count - 1].primeiraSublinha = primeiraSublinha;
                        if (toRet[toRet.Count - 1].linha != 0)
                        {
                            primeiraSublinha = false;
                        }
                        else
                        {
                            primeiraSublinha = true;
                        }
                    }
                    return toRet;
                }

                else
                {
                    //Declaração das variáveis do grupo
                    long idProdutoGrupo = 0;
                    string codProdutoGrupo = "";
                    string codProdutoClienteGrupo = "";
                    string descricaoGrupo = "";
                    double qtdGrupo = 0.0;
                    double valorUnitarioGrupo = 0.0;
                    double valorTotalGrupo = 0.0;
                    string ncmGrupo = "";
                    string informacoesEspeciaisGrupo = "";
                    DateTime dataEntregaGrupo = new DateTime();
                    double percIpiGrupo = 0.0;
                    double percIcmGrupo = 0.0;
                    string numeroPosicaoHeader = "";
                    DateTime dataEntregaOriginalGrupo = new DateTime();
                    bool primeiraSublinha = true;
                    string observacaoPedido = "";

                    foreach (OrcamentoItemClass item in AgrupadorPedido.Orcamentos)
                    {

                        if (item.SubLinha == 0)
                        {
                            numeroPosicaoHeader = item.Numero + "/" + item.Posicao;
                            idProdutoGrupo = item.Produto.ID;
                            codProdutoGrupo = item.Produto.Codigo;
                            codProdutoClienteGrupo = item.Produto.CodigoCliente;
                            descricaoGrupo = item.Produto.Descricao;
                            qtdGrupo = item.Quantidade;
                            valorUnitarioGrupo = item.PrecoUnitario;
                            valorTotalGrupo = item.PrecoTotal;
                            ncmGrupo = item.Ncm != null ? item.Ncm.Codigo : null;
                            informacoesEspeciaisGrupo = item.InformacaoEspecial;
                            dataEntregaGrupo = item.DataEntrega;
                            dataEntregaOriginalGrupo = item.DataEntregaOriginal.HasValue ? item.DataEntregaOriginal.Value : dataEntregaGrupo;


                            percIpiGrupo = item.Operacao.IncideIpi == IncidenciaImposto.Incide && item.Produto.CollectionProdutoFiscalClassProduto != null && item.Produto.CollectionProdutoFiscalClassProduto.Count > 0 ? item.Produto.CollectionProdutoFiscalClassProduto[0].Ncm.IpiAliquota : 0;
                            percIcmGrupo = item.Operacao.IncideIcms == IncidenciaImposto.Incide && item.Produto.CollectionProdutoFiscalClassProduto != null && item.Produto.CollectionProdutoFiscalClassProduto.Count > 0 && item.Produto.CollectionProdutoFiscalClassProduto[0].ModeloFiscalIcms != null && item.Produto.CollectionProdutoFiscalClassProduto[0].ModeloFiscalIcms.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms != null && item.Produto.CollectionProdutoFiscalClassProduto[0].ModeloFiscalIcms.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Count > 0
                                ? item.Produto.CollectionProdutoFiscalClassProduto[0].ModeloFiscalIcms.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.First(a => a.Estado == item.Cliente.Estado).Aliquota
                                : 0;





                            primeiraSublinha = false;
                            observacaoPedido = item.ObsPadraoEspelho;


                        }

                        toRet.Add(
                            new PedidoEspelhoClass(
                                PedidoOrcamento.Pedido,
                                tmp,
                                item.Cliente.ID,
                                item.Cliente.Nome,
                                item.Cliente.Cnpj,
                                item.Cliente.EnderecoCob + ", " + item.Cliente.EnderecoNumeroCob + " " + item.Cliente.ComplementoCob,
                                item.Cliente.BairroCob,
                                item.Cliente.CepCob,
                                item.Cliente.CidadeCob.ToString(),
                                item.Cliente.Fone1,
                                item.Cliente.CidadeCob.Estado.ToString(),
                                item.Cliente.Ie,
                                item.Numero,
                                item.Posicao,
                                item.Operacao.Descricao,
                                item.ProjetoCliente,
                                item.ArmazenagemCliente,
                                item.OrdemVenda,
                                item.DataEntrada,
                                item.FormaPagamento.Descricao,
                                item.Representante != null && item.Representante.EnvioEmail,
                                item.Representante != null ? item.Representante.Email : "",
                                observacaoPedido,
                                "",
                                numeroPosicaoHeader,
                                idProdutoGrupo,
                                codProdutoGrupo,
                                codProdutoClienteGrupo,
                                descricaoGrupo,
                                qtdGrupo,
                                valorUnitarioGrupo,
                                valorTotalGrupo,
                                ncmGrupo,
                                informacoesEspeciaisGrupo,
                                dataEntregaGrupo,
                                dataEntregaOriginalGrupo,
                                percIpiGrupo,
                                percIcmGrupo,
                                item.SubLinha,
                                item.Produto.Codigo,
                                item.Produto.CodigoCliente,
                                item.Produto.Descricao,
                                item.Quantidade,
                                true
                                )
                            );

                        toRet[toRet.Count - 1].primeiraSublinha = primeiraSublinha;
                        if (toRet[toRet.Count - 1].linha != 0)
                        {
                            primeiraSublinha = false;
                        }
                        else
                        {
                            primeiraSublinha = true;
                        }
                    }
                    return toRet;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter os dados do pedido.\r\n" + e.Message, e);
            }
        }

    }
}
