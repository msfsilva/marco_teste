#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTNF;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using dbProvider;

#endregion

namespace BibliotecaCalculoCusto
{
    public class CalculoCustoClass
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public CalculoCustoClass(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }


        public double Calcular(long idProduto, int versaoEstruturaAtual, string codigo, string descricao, out string Avisos, out List<CalculoCustoComponentesClass> componentes, out Dictionary<int, CalculoCustoAgrupadorClass> Agrupadores)
        {
            try
            {
                Agrupadores = new Dictionary<int, CalculoCustoAgrupadorClass>();
                componentes = new List<CalculoCustoComponentesClass>();
                double toRet = 0;
                Avisos = "";
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                command.CommandText =
                    "SELECT " +
                    "  public.produto.pro_tipo_aquisicao " +
                    "FROM " +
                    "  public.produto " +
                    "WHERE " +
                    "  public.produto.id_produto = :id_produto ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idProduto;
                

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }

                read.Read();
                string aqusicao = read["pro_tipo_aquisicao"].ToString();
                read.Close();

                string tmp;

                if (aqusicao == "1")
                {
                    //Comprado
                    CalculoCustoComponentesClass componenteTmp;
                    toRet += this.ultimoPrecoCompra(idProduto, codigo, descricao, out tmp, out componenteTmp);
                    componenteTmp.Quantidade = 1;
                    componentes.Add(componenteTmp);
                    if (tmp.Length > 0)
                    {
                        Avisos += tmp + "\r\n";
                    }
                }
                else
                {
                    //Fabricado

                    //Busca os agrupadores de posto do item em questão

                    DateTime dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1 * int.Parse(IWTConfiguration.Conf.getConf(Constants.MESES_CALCULO_CUSTO_HORA)));
                    DateTime dataFim = Configurations.DataIndependenteClass.GetData().Date;

                    //Busca os tempos dos agrupadores

                    this.custoMaoObraItem(idProduto, versaoEstruturaAtual, dataInicio, dataFim, ref Agrupadores, ref command, 1);


                    //Busca os filhos
                    command.CommandText =
                        "SELECT " +
                        "  public.produto_pai_filho.id_produto_filho, " +
                        "  public.produto_pai_filho.ppf_quantidade_filho, " +
                        "  public.produto_pai_filho.ppf_versao_estrutura_filho, " +
                        "  public.produto.pro_codigo, " +
                        "  public.produto.pro_descricao " +
                        "FROM " +
                        "  public.produto_pai_filho " +
                        "  INNER JOIN public.produto ON (public.produto_pai_filho.id_produto_filho = public.produto.id_produto) " +
                        "WHERE " +
                        "  public.produto_pai_filho.id_produto_pai = :id_produto AND " +
                        "  ppf_versao_estrutura = :ppf_versao_estrutura ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_versao_estrutura", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = versaoEstruturaAtual;

                    read = command.ExecuteReader();

                    List<CalculoCustoComponentesClass> compTmp;
                    Dictionary<int, CalculoCustoAgrupadorClass> agrTmp;

                    while (read.Read())
                    {
                        
                        toRet += this.Calcular(
                            Convert.ToInt32(read["id_produto_filho"]),
                            Convert.ToInt32(read["ppf_versao_estrutura_filho"]),
                            read["pro_codigo"].ToString(),
                            read["pro_descricao"].ToString(),
                            out tmp, out compTmp, out agrTmp)

                                 *Convert.ToDouble(read["ppf_quantidade_filho"])
                            ;

                        foreach (CalculoCustoComponentesClass componente in compTmp)
                        {
                            componente.Quantidade *= Convert.ToDouble(read["ppf_quantidade_filho"]);
                            componentes.Add(componente);
                        }

                        foreach (KeyValuePair<int, CalculoCustoAgrupadorClass> agr in agrTmp)
                        {
                            if (!Agrupadores.ContainsKey(agr.Key))
                            {
                                Agrupadores.Add(agr.Key, agr.Value);
                                foreach (CalculoCustoAgrupadorProdutoClass prod in Agrupadores[agr.Key].Produtos.Values)
                                {
                                    prod.Quantidade *= Convert.ToDouble(read["ppf_quantidade_filho"]);
                                }
                            }
                            else
                            {

                                foreach (KeyValuePair<CalculoCustoAgrupadorProdutoKeyClass, CalculoCustoAgrupadorProdutoClass> produto in Agrupadores[agr.Key].Produtos)
                                {
                                    if (!Agrupadores[agr.Key].Produtos.ContainsKey(produto.Key))
                                    {
                                        Agrupadores[agr.Key].Produtos.Add(produto.Key, produto.Value);
                                        Agrupadores[agr.Key].Produtos[produto.Key].Quantidade *= Convert.ToDouble(read["ppf_quantidade_filho"]);
                                    }
                                    else
                                    {
                                        Agrupadores[agr.Key].Produtos[produto.Key].Quantidade += (produto.Value.Quantidade*Convert.ToDouble(read["ppf_quantidade_filho"]));
                                    }
                                }

                            }
                        }


                        if (tmp.Length > 0)
                        {
                            Avisos += tmp + "\r\n";
                        }

                    }
                    read.Close();


                    //Soma os Materiais
                    command.CommandText =
                        "SELECT  " +
                        "  public.produto_material.id_material, " +
                        "  public.produto_material.prm_quantidade, " +
                        "  public.familia_material.fam_codigo ||' '|| public.material.mat_codigo as mat, " +
                        "  public.material.mat_descricao " +
                        "FROM " +
                        "  public.produto_material " +
                        "  INNER JOIN public.material ON (public.produto_material.id_material = public.material.id_material) " +
                        "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                        "WHERE " +
                        "  public.produto_material.id_produto = :id_produto " +
                        " AND prm_versao_estrutura = :prm_versao_estrutura ";


                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = idProduto;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_versao_estrutura", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = versaoEstruturaAtual;

                    read = command.ExecuteReader();
                    while (read.Read())
                    {
                        CalculoCustoComponentesClass componenteTmp;
                        toRet += this.ultimoPrecoCompraMaterial(
                            Convert.ToInt32(read["id_material"]),
                            read["mat"].ToString(),
                            read["mat_descricao"].ToString(),
                            out tmp,
                            out componenteTmp)
                                 *Convert.ToDouble(read["prm_quantidade"]);
                        componenteTmp.Quantidade = Convert.ToDouble(read["prm_quantidade"]);
                        componentes.Add(componenteTmp);


                        if (tmp.Length > 0)
                        {
                            Avisos += tmp + "\r\n";
                        }
                    }
                    read.Close();


                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular o custo do produto.\r\n" + e.Message, e);
            }

        }

        private void custoMaoObraItem(long idProduto, int versaoEstrutura,DateTime dataInicio, DateTime dataFim, ref Dictionary<int, CalculoCustoAgrupadorClass> Agrupadores, ref IWTPostgreNpgsqlCommand command, double qtdItem )
        {
            command.CommandText =
                "SELECT  " +
                "  SUM((public.ordem_producao_posto_trabalho.opt_tempo_setup * 3600) + (public.ordem_producao_posto_trabalho.opt_tempo_producao * public.ordem_producao.orp_quantidade)) AS tempoSegundos, " +
                "  SUM(orp_quantidade) as quantidade, " +
                "  public.agrupador_posto_trabalho.id_agrupador_posto_trabalho, " +
                "  public.agrupador_posto_trabalho.id_centro_custo_lucro, " +
                "  public.agrupador_posto_trabalho.apt_identificacao, " +
                "  public.agrupador_posto_trabalho.apt_descricao, " +
                "  public.agrupador_posto_trabalho.apt_custo_hora_adicional " +
                "FROM " +
                "  public.ordem_producao " +
                "  INNER JOIN public.ordem_producao_posto_trabalho ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_posto_trabalho.id_ordem_producao) " +
                "  INNER JOIN public.posto_trabalho ON (public.ordem_producao_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) " +
                "  INNER JOIN public.agrupador_posto_trabalho ON (public.posto_trabalho.id_agrupador_posto_trabalho = public.agrupador_posto_trabalho.id_agrupador_posto_trabalho) " +
                "WHERE " +
                "  public.ordem_producao.orp_data BETWEEN :datainicio AND :datafim AND  " +
                "  public.ordem_producao.id_produto = :id_produto AND " +
                "  public.ordem_producao.orp_versao_estrutura_produto = :versao_estrutura_produto " +
                "GROUP BY " +
                "  public.agrupador_posto_trabalho.id_agrupador_posto_trabalho, " +
                "  public.agrupador_posto_trabalho.id_centro_custo_lucro, " +
                "  public.agrupador_posto_trabalho.apt_identificacao, " +
                "  public.agrupador_posto_trabalho.apt_descricao, " +
                "  public.agrupador_posto_trabalho.apt_custo_hora_adicional ";

            command.Parameters.Clear();

            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = idProduto;
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("versao_estrutura_produto", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = versaoEstrutura;
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("datainicio", NpgsqlDbType.Date));
            command.Parameters[command.Parameters.Count - 1].Value = dataInicio;
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("datafim", NpgsqlDbType.Date));
            command.Parameters[command.Parameters.Count - 1].Value = dataFim;

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                int idAgrupador = Convert.ToInt32(read["id_agrupador_posto_trabalho"]);

                if (!Agrupadores.ContainsKey(idAgrupador))
                {
                    CalculoCustoAgrupadorClass componente = new CalculoCustoAgrupadorClass(
                        idAgrupador,
                        read["apt_identificacao"].ToString(),
                        read["apt_descricao"].ToString(),
                        Convert.ToDouble(read["apt_custo_hora_adicional"].ToString()),
                        command.Connection);

                    Agrupadores.Add(idAgrupador, componente);
                }

                CalculoCustoAgrupadorProdutoKeyClass chave = new CalculoCustoAgrupadorProdutoKeyClass(idProduto,versaoEstrutura);

                if (!Agrupadores[idAgrupador].Produtos.ContainsKey(chave))
                {
                    Agrupadores[idAgrupador].Produtos.Add(chave,
                                                          new CalculoCustoAgrupadorProdutoClass(
                                                              idProduto,
                                                              Convert.ToDouble(read["tempoSegundos"])/Convert.ToDouble(read["quantidade"]),
                                                              Agrupadores[idAgrupador], this.conn));
                }

                Agrupadores[idAgrupador].Produtos[chave].Quantidade += qtdItem;

            }
            read.Close();
        }

        private double ultimoPrecoCompraMaterial(int idMaterial, string Material, string descricao, out string Avisos, out CalculoCustoComponentesClass componente)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.historico_compra_material.hcm_preco_unitario /  COALESCE( public.material_fornecedor.maf_unidades_por_un_compra, public.material.mat_unidades_por_un_compra) valor " +
                    "FROM " +
                    "  public.historico_compra_material " +
                    "  INNER JOIN public.material ON (public.historico_compra_material.id_material = public.material.id_material) " +
                    "  INNER JOIN public.material_fornecedor ON (public.material.id_material = public.material_fornecedor.id_material) " +
                    "  AND (public.historico_compra_material.id_fornecedor = public.material_fornecedor.id_fornecedor) " +
                    "WHERE " +
                    "  public.historico_compra_material.id_material = :id_material " +
                    "ORDER BY " +
                    "  public.historico_compra_material.hcm_preco_unitario /  COALESCE( public.material_fornecedor.maf_unidades_por_un_compra, public.material.mat_unidades_por_un_compra) DESC ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idMaterial;

                object tmp = command.ExecuteScalar();
                if (tmp == null || tmp == DBNull.Value)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  MIN(public.material_fornecedor.maf_ultimo_preco/COALESCE(public.material_fornecedor.maf_unidades_por_un_compra,public.material.mat_unidades_por_un_compra)) AS preco " +
                        "FROM "+
                        "  public.material_fornecedor "+
                        "    INNER JOIN public.material ON (public.material_fornecedor.id_material = public.material.id_material) "+
                        "WHERE "+
                        "  public.material_fornecedor.id_material = :id_material AND " +
                        "  public.material_fornecedor.maf_ativo = 1 ";

                    tmp = command.ExecuteScalar();
                    if (tmp == null || tmp == DBNull.Value)
                    {
                        Avisos = "O material " + Material + " não possui histórico de preços nem valores cadastrados nos fornecedores, seu valor foi desprezado.";
                        componente = new CalculoCustoComponentesClass("Materiais", Material,descricao, 0);
                        return 0;
                    }
                    else
                    {
                        Avisos = "O material " + Material + " não possui histórico de preços, foi utilizado o menor valor cadastrado nos fornecedores.";
                        componente = new CalculoCustoComponentesClass("Materiais", Material, descricao, Convert.ToDouble(tmp));
                        return Convert.ToDouble(tmp);
                    }
                    
                }
                else
                {
                    Avisos = "";
                    componente = new CalculoCustoComponentesClass("Materiais", Material, descricao, Convert.ToDouble(tmp));
                    return Convert.ToDouble(tmp);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar o ultimo valor de compra do material\r\n" + e.Message, e);
            }
        }

        private double ultimoPrecoCompra(long idProduto, string Produto, string descricao,out string Avisos, out CalculoCustoComponentesClass componente)
        {
            try
            {
                
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.historico_compra_produto.hcp_preco_unitario /  COALESCE( public.produto_fornecedor.prf_unidades_por_un_compra, public.produto.pro_unidades_por_un_compra) valor " +
                    "FROM " +
                    "  public.historico_compra_produto " +
                    "  INNER JOIN public.produto ON (public.historico_compra_produto.id_produto = public.produto.id_produto) " +
                    "  INNER JOIN public.produto_fornecedor ON (public.produto.id_produto = public.produto_fornecedor.id_produto) " +
                    "  AND (public.historico_compra_produto.id_fornecedor = public.produto_fornecedor.id_fornecedor) " +
                    "WHERE " +
                    "  public.historico_compra_produto.id_produto = :id_produto " +
                    "ORDER BY " +
                    "  public.historico_compra_produto.hcp_preco_unitario /  COALESCE( public.produto_fornecedor.prf_unidades_por_un_compra, public.produto.pro_unidades_por_un_compra) DESC ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idProduto;

                object tmp = command.ExecuteScalar();
                if (tmp == null || tmp == DBNull.Value)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  MIN(public.produto_fornecedor.prf_ultimo_preco/COALESCE(public.produto_fornecedor.prf_unidades_por_un_compra,public.produto.pro_unidades_por_un_compra)) AS preco " +
                        "FROM " +
                        "  public.produto_fornecedor " +
                        "    INNER JOIN public.produto ON (public.produto_fornecedor.id_produto = public.produto.id_produto) " +
                        "WHERE " +
                        "  public.produto_fornecedor.id_produto = :id_produto AND " +
                        "  public.produto_fornecedor.prf_ativo = 1 ";

                    tmp = command.ExecuteScalar();
                    if (tmp == null || tmp == DBNull.Value)
                    {
                        Avisos = "O produto " + Produto + " não possui histórico de preços nem valores cadastrados nos fornecedores, seu valor foi desprezado.";
                        componente = new CalculoCustoComponentesClass("Produtos", Produto, descricao, 0);
                        return 0;
                    }
                    else
                    {
                        Avisos = "O produto " + Produto + " não possui histórico de preços, foi utilizado o menor valor cadastrado nos fornecedores.";
                        componente = new CalculoCustoComponentesClass("Produtos", Produto, descricao, Convert.ToDouble(tmp));
                        return Convert.ToDouble(tmp);
                    }
                }
                else
                {
                    Avisos = "";
                    componente = new CalculoCustoComponentesClass("Produtos", Produto, descricao, Convert.ToDouble(tmp));
                    return Convert.ToDouble(tmp);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar o ultimo valor de compra do produto comprado\r\n" + e.Message, e);
            }
        }

        internal SimulacaoPrecoClass simularPreco(
            long idProduto,
            int versaoEstruturaProduto,
            string codigoProduto,
            string descricaoProduto,
            out string Avisos,
            long idCliente,
            double margemPretendida,
            ArredondamentoNF arrendodamentoNF
            )
        {
            List<CalculoCustoComponentesClass> tmp;
            Dictionary<int, CalculoCustoAgrupadorClass> Agrupadores;
            double custoInicial = this.Calcular(idProduto, versaoEstruturaProduto, codigoProduto, descricaoProduto, out Avisos, out tmp, out Agrupadores);

            DateTime dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1*int.Parse(IWTConfiguration.Conf.getConf(Constants.MESES_CALCULO_CUSTO_HORA)));
            DateTime dataFim = Configurations.DataIndependenteClass.GetData().Date;

            IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
            double custoMaoObra = 0;
            foreach (CalculoCustoAgrupadorClass agrupador in Agrupadores.Values)
            {
                agrupador.CarregarDados(ref command, dataInicio, dataFim);
                custoMaoObra += agrupador.ValorTotalAgrupador;
                tmp.Add(agrupador.getCalculoCustoComponentesClass());
            }

            return this.simularPreco(idProduto, codigoProduto, idCliente, margemPretendida, arrendodamentoNF, custoInicial, custoMaoObra, tmp, ref Avisos);
        }

        internal SimulacaoPrecoClass simularPreco(
            long idProduto,
            string codigoProduto,
            long idCliente,
            double margemPretendida,
            ArredondamentoNF arrendodamentoNF,
            double custoInicial,
            double custoMaoObra,
            List<CalculoCustoComponentesClass> componentes,
            ref string Avisos
            )
        {
            try
            {
                SimulacaoPrecoClass sim = new SimulacaoPrecoClass();
                sim.custoInicial = custoInicial;
                sim.custoMaoObra = custoMaoObra;
                margemPretendida = Math.Round((margemPretendida / 100), 4);

                sim.valorFinal = custoInicial + custoMaoObra;

                do
                {
                    double difMargem = margemPretendida - sim.pMargem;
                    sim.valorFinal = sim.valorFinal + (sim.valorFinal * difMargem);
                    this.rodarNF(idProduto,idCliente, arrendodamentoNF, ref sim);


                    double teste = 1 - sim.aliquotaImposto - (sim.aliquotaImposto * sim.pMargem);
                    if (Math.Round(teste,5) <= 0)
                    {
                        Avisos += "O cálculo da margem foi interrompido pois ela atingiu o limite.";
                        break;
                    }
                }
                while (Math.Round(sim.pMargem,4) != margemPretendida);

                sim.Componentes = componentes;
                return sim;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao simular o preço de venda\r\n" + e.Message, e);
            }


        }


        private SimulacaoPrecoClass rodarNF(long idProduto, long idCliente,
            ArredondamentoNF arrendodamentoNF,
            ref SimulacaoPrecoClass toRet)
        {
            try
            {
                EmitenteClass emitenteCompleto;
                PisCofinsInfo pisCofinsDefault;
                NfEmitenteClass emitente = NotaFiscalFuncoesAuxiliares.CarregaEmitente(conn, out emitenteCompleto, EasiEmissorNFe.Primario, out pisCofinsDefault);

                NfPrincipalClass nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, this.conn);


                nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                         {
                             Numero = 9999,
                             NaturezaOperacao = "",
                             Serie = 1,
                             FormaPagamento = 0,
                             ModeloDocFiscal = "55",
                             DataEmissao = Configurations.DataIndependenteClass.GetData(),
                             DataSaidaEntrada = Configurations.DataIndependenteClass.GetData(),
                             Tipo = TipoNota.Saida,
                             CodMunicipioFatoGerador = emitente.NfEmitenteEndereco.CodMunicipio,
                             FormatoImpressao = FormatoImpressao.Retrato,
                             FormaEmissao = FormaEmissaoNFe.Normal,
                             IdentificacaoAmbiente = 1,
                             FinalidadeEmissao = Finalidade.Normal,
                             ProcessoEmissao = Processo.ContribuinteAplicativoFisco,
                             VersaoProcessoEmissao = "XX",
                             Observacoes = "",
                             TipoEmitente = "P",
                             Situacao = "N"
                         };

                nf.NfAtributo = new NfAtributoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                {
                    VersaoLayout = "3.10",
                    IdNfe = "NFe",
                    NfPrincipal = nf, 
                };


                nf.NfEmitente = emitente;
                nf.NfEmitente.NfPrincipal = nf;
                nf.NfEmitente.NfEmitenteEndereco.NfPrincipal = nf;
                nf.NfEmitente.NfEmitenteEndereco.NfEmitente = nf.NfEmitente;

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;



                command.CommandText =
                    "SELECT  " +
                    "  public.familia_cliente.fac_tipo_especial, " +
                    "  public.cliente.cli_nome, " +
                    "  public.cliente.cli_ie, " +
                    "  public.cliente.cli_email, " +
                    "  public.cliente.cli_cnpj, " +
                    "  public.cliente.cli_endereco_cob, " +
                    "  public.cliente.cli_bairro_cob, " +
                    "  public.cliente.cli_cep_cob, " +
                    "  public.cliente.cli_pais_cob, " +
                    "  public.cliente.cli_endereco_numero_cob, " +
                    "  public.cliente.cli_complemento_cob, " +
                    "  public.cliente.cli_codigo_pais_cob, " +
                    "  public.cliente.cli_fone1, " +
                    "  public.cidade.cid_nome, " +
                    "  public.cidade.cid_codigo_ibge, " +
                    "  public.estado.est_sigla " +
                    "FROM " +
                    "  public.cliente " +
                    "  LEFT OUTER JOIN public.estado ON (public.cliente.id_estado_cob = public.estado.id_estado) " +
                    "  LEFT OUTER JOIN public.familia_cliente ON (public.cliente.id_familia_cliente = public.familia_cliente.id_familia_cliente) " +
                    "  LEFT OUTER JOIN public.cidade ON (public.cliente.id_cidade_cob = public.cidade.id_cidade) " +
                    "WHERE " +
                    "  public.cliente.id_cliente = " + idCliente + " ";
                read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new Exception("Cliente não cadastrado!");
                }

                read.Read();

                if (read["est_sigla"] == DBNull.Value)
                {
                    throw new Exception("Estado do endereço principal do cliente é inválido.");
                }

                if (read["cid_codigo_ibge"] == DBNull.Value)
                {
                    throw new Exception("Municipio do endereço principal do cliente é inválido.");
                }





                nf.NfCliente = new NfClienteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                   {
                                       NfPrincipal = nf,
                                       Razao = read["cli_nome"].ToString(),
                                       NomeFantasia = read["cli_nome"].ToString(),
                                       Ie = read["cli_ie"].ToString(),
                                       CnpjCpf = read["cli_cnpj"].ToString().Replace(".", "").Replace("/", "").Replace("-", ""),
                                       Isuf = "",
                                       Email = read["cli_email"].ToString()
                                   };

                nf.NfCliente.NfClienteEndereco = new NfClienteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                                     {
                                                         NfPrincipal = nf,
                                                         Logradouro = read["cli_endereco_cob"].ToString(),
                                                         Numero = read["cli_endereco_numero_cob"].ToString(),
                                                         Complemento = read["cli_complemento_cob"].ToString(),
                                                         Bairro = read["cli_bairro_cob"].ToString(),
                                                         CodMunicipio = Convert.ToInt32("0" + read["cid_codigo_ibge"]),
                                                         NomeMunicipio = read["cid_nome"].ToString(),
                                                         SiglaUf = read["est_sigla"].ToString(),
                                                         Cep = read["cli_cep_cob"].ToString().Replace("-", ""),
                                                         CodPais = Convert.ToInt32("0" + read["cli_codigo_pais_cob"]),
                                                         NomePais = read["cli_pais_cob"].ToString(),
                                                         Telefone = read["cli_fone1"].ToString().Replace("(", "").Trim().Replace(")", "").Replace("-", "").Replace(" ", "")
                                                     };


                read.Close();



                nf.CollectionNfItemClassNfPrincipal = new BindingList<NfItemClass>();
                TributosItem tributos = null;
                //Tributos
                tributos = new TributosItem(idProduto, null, idCliente,null, emitenteCompleto.CidadeEntidade.Estado.ID, pisCofinsDefault, "", command,1,1);

                nf.CollectionNfItemClassNfPrincipal.Add(new NfItemClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                {
                    NfPrincipal = nf,
                    NumeroItem = 1,
                    Cfop = 5101
                });
                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto =
                    new NfProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                            Codigo = "",
                            Descricao = "",
                            Gtin = tributos.GTIN,
                            Ncm = "99",
                            Extipi = tributos.exTIPI,
                            Genero = tributos.Genero,
                            Unidade = "",
                            ValorUnitario = toRet.valorFinal,
                            GtimUnidadeTrinutacao = tributos.GTIN,
                            UnidadeTributacao = "",
                            ValorUnitarioTrinutacao = toRet.valorFinal,
                            QuantidadeTributavel = 1,
                            ValorTotalTributavel = toRet.valorFinal,
                            ValorFrete = 0,
                            ValorSeguro = 0,
                            ValorDesconto = 0,
                            Quantidade = 1
                        };

            switch (tributos.ICMSCst)
            {

                case "41a":
                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                        new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                            {
                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Cst = tributos.ICMSCst,
                                Origem = (OrigemMercadoria) Enum.ToObject(typeof (OrigemMercadoria), tributos.ICMSOrigem),
                                ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof (ModalidadeDeterminacaoBCICMS), tributos.ICMSModalidadeDeterminacaoBC),
                                Aliquota = tributos.ICMSAliquota,
                                AliquotaSt = tributos.ICMSAliquotaST,
                                PercentualReducaoBc = tributos.ICMSPercentualReducaoBC,
                                ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof (ModalidadeDeterminacaoBCICMSST), tributos.ICMSModalidadeDeterminacaoBCST),
                                PercentualReducaoBcSt = tributos.ICMSPercentualReducaoBCST,
                                PercentualMvaSt = tributos.ICMSPercentualMVAST,
                                CodigoAntecipacaoSt = "X",
                                PercentualDiferimento = tributos.ICMSPercentualDiferimento,
                                ObsDiferimento = tributos.ICMSObsDiferimento,
                                PercentualBcOperacaoPropria = tributos.ICMSPercentualBCOperacaoPropria,
                                SiglaUfDevidoIcms = tributos.ICMSSiglaUfDevido,
                                ValorBcStRetidoRemetente = 0,
                                ValorIcmsStRetidoRemetente = 0,
                                ValorBcStRetidoDestinatario = 0,
                                ValorIcmsStRetidoDestinatario = 0,
                                CsoSimples = tributos.ICMSCsoSimples,
                                AliquotaCreditoSimples = tributos.ICMSAliquotaCreditoSimples
                            };
                break;

                    case "90b":
                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                        new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                            {
                               NfItem= nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Cst = "90",
                               Origem = (OrigemMercadoria)Enum.ToObject(typeof(OrigemMercadoria), tributos.ICMSOrigem),
                               ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.ICMSModalidadeDeterminacaoBC),
                               Aliquota = tributos.ICMSAliquota,
                               AliquotaSt = tributos.ICMSAliquotaST,
                               PercentualReducaoBc = tributos.ICMSPercentualReducaoBC,
                               ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.ICMSModalidadeDeterminacaoBCST),
                               PercentualReducaoBcSt = tributos.ICMSPercentualReducaoBCST,
                               PercentualMvaSt = tributos.ICMSPercentualMVAST,
                               CodigoAntecipacaoSt = "X",
                               PercentualDiferimento = tributos.ICMSPercentualDiferimento,
                               ObsDiferimento = tributos.ICMSObsDiferimento,
                               PercentualBcOperacaoPropria = tributos.ICMSPercentualBCOperacaoPropria,
                               SiglaUfDevidoIcms = tributos.ICMSSiglaUfDevido,
                               ValorBcStRetidoRemetente = 0,
                               ValorIcmsStRetidoRemetente = 0,
                               ValorBcStRetidoDestinatario = 0,
                               ValorIcmsStRetidoDestinatario = 0,
                               CsoSimples = tributos.ICMSCsoSimples,
                               AliquotaCreditoSimples = tributos.ICMSAliquotaCreditoSimples
                            };

                        break;

                    default:
                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                        new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                            {
                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Cst = tributos.ICMSCst,
                                Origem = (OrigemMercadoria)Enum.ToObject(typeof(OrigemMercadoria), tributos.ICMSOrigem),
                                ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.ICMSModalidadeDeterminacaoBC),
                                Aliquota = tributos.ICMSAliquota,
                                AliquotaSt = tributos.ICMSAliquotaST,
                                PercentualReducaoBc = tributos.ICMSPercentualReducaoBC,
                                ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.ICMSModalidadeDeterminacaoBCST),
                                PercentualReducaoBcSt = tributos.ICMSPercentualReducaoBCST,
                                PercentualMvaSt = tributos.ICMSPercentualMVAST,
                                CodigoAntecipacaoSt = "X",
                                PercentualDiferimento = tributos.ICMSPercentualDiferimento,
                                ObsDiferimento = tributos.ICMSObsDiferimento,
                                PercentualBcOperacaoPropria = tributos.ICMSPercentualBCOperacaoPropria,
                                SiglaUfDevidoIcms = tributos.ICMSSiglaUfDevido,
                                ValorBcStRetidoRemetente = 0,
                                ValorIcmsStRetidoRemetente = 0,
                                ValorBcStRetidoDestinatario = 0,
                                ValorIcmsStRetidoDestinatario = 0,
                                CsoSimples = tributos.ICMSCsoSimples,
                                AliquotaCreditoSimples = tributos.ICMSAliquotaCreditoSimples
                            };
                        break;
                }




                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                    new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                            ClasseEnquadramentoCigarrosBebidas = tributos.IPIClasseEnquadramentoCigarrosBebidas,
                            CnpjProdutor = tributos.IPICNPJProdutor,
                            ClasseEnquadramento = tributos.IPIClasseEnquadramento,
                            Cst = tributos.IPICst,
                            Aliquota = tributos.IPIAliquota,
                            ModalidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof (ModalidadeTributacao), tributos.IPIModalidadeTributacao),
                            QuantidadeVendida = 0
                        };


                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                    new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                            Cst = tributos.PISCst,
                            Aliquota = tributos.PISAliquota,
                            ModadlidadeTributacao = (ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), tributos.PISModalidadeTributacao),
                            ImpostoRetido = tributos.PISImpostoRetido
                        };

                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                    new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                            Cst = tributos.CofinsCst,
                            Aliquota = tributos.CofinsAliquota,
                            ModadlidadeTributacao = (ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), tributos.CofinsModalidadeTributacao),
                            ImpostoRetido = tributos.CofinsImpostoRetido
                        };

                read.Close();

                //public NfTransporte(NfPrincipal nfPrincipal, short nftModalidade, string nftRazao, string nftIe, string nftEndereco, string nftSiglaUf, string nftMunicipio, string nftCpfCnpj,
                //int? nftVolumes, double nftPesoLiquido, double nftPesoBruto, string nftPlaca, string nftRegistroAntt, string nftSiglaUfVeiculo, string nftVolumeEspecie, string nftVolumeMarca)
                nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                      {
                                          NfPrincipal = nf,
                                          Modalidade = ModalidadeFrete.Destinatario,
                                          Razao = "",
                                          Ie = "",
                                          Endereco = "",
                                          SiglaUf = "",
                                          Municipio = "",
                                          CpfCnpj = "",
                                          Volumes = 1,
                                          PesoLiquido = 0,
                                          PesoBruto = 0,
                                          Placa = null,
                                          RegistroAntt = null,
                                          SiglaUfVeiculo = null,
                                          VolumeEspecie = "Volume",
                                          VolumeMarca = ""
                                      };


                try
                {
                    NfPrincipalClass.calculaNf(ref nf, arrendodamentoNF, LoginClass.UsuarioLogado.loggedUser, DbConnection.Connection, null);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao calcular a NF.\r\n" + e.Message);

                }


                if (nf.CollectionNfItemClassNfPrincipal[0].NfItemTributo.NfItemTributoCofins != null)
                {
                    toRet.valorCofins = nf.CollectionNfItemClassNfPrincipal[0].NfItemTributo.NfItemTributoCofins.ValorCofins;
                }

                if (nf.CollectionNfItemClassNfPrincipal[0].NfItemTributo.NfItemTributoIcms != null)
                {
                    toRet.valorICMS = nf.CollectionNfItemClassNfPrincipal[0].NfItemTributo.NfItemTributoIcms.ValorIcms;
                }

                if (nf.CollectionNfItemClassNfPrincipal[0].NfItemTributo.NfItemTributoIpi != null)
                {
                    toRet.valorIPI = nf.CollectionNfItemClassNfPrincipal[0].NfItemTributo.NfItemTributoIpi.ValorIpi;
                }

                if (nf.CollectionNfItemClassNfPrincipal[0].NfItemTributo.NfItemTributoPis != null)
                {
                    toRet.valorPIS = nf.CollectionNfItemClassNfPrincipal[0].NfItemTributo.NfItemTributoPis.ValorPis;
                }


                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a simulação dos impostos.\r\n" + e.Message, e);
            }
        }
    }

    public class SimulacaoPrecoClass
    {
        public List<CalculoCustoComponentesClass> Componentes { get; set; }
        public double valorICMS { get; set; }
        public double valorIPI { get; set; }
        public double valorPIS { get; set; }
        public double valorCofins { get; set; }

        public double custoTotal
        {
            get { return custoInicial + custoImposto + custoMaoObra; }
        }

        public double custoImposto
        {
            get
            {
                return valorICMS + valorIPI + valorPIS + valorCofins;
            }
        }

        public double valorMargem
        {
            get
            {
                return valorFinal - custoTotal;
            }
        }
        public double pMargem
        {
            get
            {
                if (custoTotal == 0)
                {
                    return 0;
                }

                return valorMargem / custoTotal;            
            }
        }

        public double custoInicial { get; set; }

        public double custoMaoObra { get; set; }
        public double valorFinal { get; set; }

        public double aliquotaImposto
        {
            get
            {
                return this.custoImposto / this.valorFinal;
            }
        }
    }

    public class CalculoCustoAgrupadorClass
    {
        private AgrupadorPostoTrabalhoClass Agrupador;
        private IWTPostgreNpgsqlConnection SingleConnection;
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }

        public double ValorPorSegundo{ get; private set; }
        public double CustoHoraAdicional { get; private set; }
        public Dictionary<CalculoCustoAgrupadorProdutoKeyClass, CalculoCustoAgrupadorProdutoClass> Produtos { get; private set; }

        public double ValorTotalAgrupador
        {
            get { return this.Produtos.Values.Sum(a => a.ValorTotal); }
        }

        public double TempoTotalAgrupadorSegundos
        {
            get { return this.Produtos.Values.Sum(a => a.TempoMedioSegundo*a.Quantidade); }
        }

        public CalculoCustoAgrupadorClass(int idAgrupador, string codigo, string descricao, double CustoHoraAdicional, IWTPostgreNpgsqlConnection singleConnection)
        {
            SingleConnection = singleConnection;
            this.Agrupador = AgrupadorPostoTrabalhoBaseClass.GetEntidade(idAgrupador, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
            Codigo = codigo;
            Descricao = descricao;
            this.CustoHoraAdicional = CustoHoraAdicional;
            
            this.Produtos = new Dictionary<CalculoCustoAgrupadorProdutoKeyClass, CalculoCustoAgrupadorProdutoClass>();
        }
        
        internal void CarregarDados(ref IWTPostgreNpgsqlCommand command, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                command.CommandText =
                    "SELECT  " +
                    "  SUM((public.ordem_producao_posto_trabalho.opt_tempo_setup * 3600) + (public.ordem_producao_posto_trabalho.opt_tempo_producao * public.ordem_producao.orp_quantidade)) AS tempoSegundos " +
                    "FROM " +
                    "  public.ordem_producao " +
                    "  INNER JOIN public.ordem_producao_posto_trabalho ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_posto_trabalho.id_ordem_producao) " +
                    "  INNER JOIN public.posto_trabalho ON (public.ordem_producao_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) " +
                    "WHERE " +
                    "  public.ordem_producao.orp_data BETWEEN :datainicio AND :datafim AND  " +
                    "  public.posto_trabalho.id_agrupador_posto_trabalho = :id_agrupador_posto_trabalho ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_agrupador_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Agrupador.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("datainicio", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataInicio;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("datafim", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataFim;

                double? tmp = command.ExecuteScalar() as double?;

                double TempoTotalUtilizadoSegundos = tmp.HasValue ? tmp.Value : 0;

                command.CommandText =
                    "SELECT  " +
                    "  sum(conta_pagar.cop_valor_pago) " +
                    "FROM " +
                    "  public.conta_pagar " +
                    "WHERE " +
                    "  public.conta_pagar.cop_data_pagamento BETWEEN :datainicio AND :datafim AND " +
                    "  public.conta_pagar.id_centro_custo_lucro = :id_centro_custo_lucro ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Agrupador.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("datainicio", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataInicio;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("datafim", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataFim;

                tmp = command.ExecuteScalar() as double?;

                double ValorTotalCentroCusto = tmp.HasValue ? tmp.Value : 0;
                ValorTotalCentroCusto = ValorTotalCentroCusto*Convert.ToDouble(Agrupador.PorcentagemCentroCusto/100);

             
                this.ValorPorSegundo = ((ValorTotalCentroCusto/TempoTotalUtilizadoSegundos) + (this.CustoHoraAdicional / 3600));
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do agrupador\r\n" + e.Message, e);
            }

        }

        internal CalculoCustoComponentesClass getCalculoCustoComponentesClass()
        {
            return new CalculoCustoComponentesClass("Mão de Obra",
                                                    this.Codigo,
                                                    this.Descricao,
                                                    this.TempoTotalAgrupadorSegundos,
                                                    this.ValorPorSegundo);
        }
    }

     public class CalculoCustoAgrupadorProdutoKeyClass : IEquatable<CalculoCustoAgrupadorProdutoKeyClass>
     {
         private long idProduto;
         private int versaoAtualEstrutura;

         public CalculoCustoAgrupadorProdutoKeyClass(long idProduto, int versaoAtualEstrutura)
         {
             this.idProduto = idProduto;
             this.versaoAtualEstrutura = versaoAtualEstrutura;
         }

         public bool Equals(CalculoCustoAgrupadorProdutoKeyClass other)
         {
             if (ReferenceEquals(null, other)) return false;
             if (ReferenceEquals(this, other)) return true;
             return other.idProduto == idProduto && other.versaoAtualEstrutura == versaoAtualEstrutura;
         }

         public override bool Equals(object obj)
         {
             if (ReferenceEquals(null, obj)) return false;
             if (ReferenceEquals(this, obj)) return true;
             if (obj.GetType() != typeof (CalculoCustoAgrupadorProdutoKeyClass)) return false;
             return Equals((CalculoCustoAgrupadorProdutoKeyClass) obj);
         }

         public override int GetHashCode()
         {
             unchecked
             {
                 return (int) ((idProduto*397) ^ versaoAtualEstrutura);
             }
         }

         public static bool operator ==(CalculoCustoAgrupadorProdutoKeyClass left, CalculoCustoAgrupadorProdutoKeyClass right)
         {
             return Equals(left, right);
         }

         public static bool operator !=(CalculoCustoAgrupadorProdutoKeyClass left, CalculoCustoAgrupadorProdutoKeyClass right)
         {
             return !Equals(left, right);
         }
     }
    
    public class CalculoCustoAgrupadorProdutoClass
    {
        public double TempoMedioSegundo { get; set; }
        public CalculoCustoAgrupadorClass Agrupador { get; set; }
        public ProdutoClass Produto { get; private set; }
        public double Quantidade { get; internal set; }

        public double ValorTotal
        {
            get { return this.Quantidade*(this.TempoMedioSegundo*this.Agrupador.ValorPorSegundo); }
        }

        public CalculoCustoAgrupadorProdutoClass(long idProduto,double tempoMedioSegundo, CalculoCustoAgrupadorClass agrupador, IWTPostgreNpgsqlConnection singleConnection)
        {
            TempoMedioSegundo = tempoMedioSegundo;
            Agrupador = agrupador;


            Produto = ProdutoBaseClass.GetEntidade(idProduto, LoginClass.UsuarioLogado.loggedUser, singleConnection);
            Quantidade = 0;
        }

        internal CalculoCustoComponentesClass getCalculoCustoComponentesClass()
        {
            return new CalculoCustoComponentesClass("Mão de Obra",
                                                    this.Agrupador.Codigo,
                                                    this.Agrupador.Descricao,
                                                    this.Quantidade,
                                                    this.Agrupador.ValorPorSegundo*this.TempoMedioSegundo);
        }

        
    }

    public class CalculoCustoComponentesClass
    {
        public string Tipo { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public double Quantidade { get; internal set; }
        public double ValorUnitário { get; internal set; }
        public double ValorTotal
        {
            get { return this.Quantidade*this.ValorUnitário; }
        }

        public CalculoCustoComponentesClass(string tipo, string codigo,string descricao, double valorUnitário)
        {
            Tipo = tipo;
            Codigo = codigo;
            Descricao = descricao;
            ValorUnitário = valorUnitário;
        }

        public CalculoCustoComponentesClass(string tipo, string codigo, string descricao, double quantidade, double valorUnitário)
        {
            Tipo = tipo;
            Codigo = codigo;
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitário = valorUnitário;
        }
    }
    
}
