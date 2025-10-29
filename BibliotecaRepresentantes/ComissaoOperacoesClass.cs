using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

namespace BibliotecaRepresentantes
{
    public class ComissaoOperacoesClass
    {

        public static List<ComissaoReportDataSource> GerarRelatorioComissoes(RepresentanteClass representante, VendedorClass vendedor, int mes, int ano, bool somenteNaoGeradas, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
         

                #region Logo
                byte[] logo = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);
                if (logo != null)
                {
                    MemoryStream ms = new MemoryStream(logo);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    logo = ms.ToArray();
                }
                #endregion


                List<ComissaoReportDataSource> ret;

                switch (ControleComissao.Modo)
                {
                    case ModoControleComissao.Pedido:
                        ret = gerarRelatorioComissoesPorPedidos(representante, vendedor, logo, mes, ano, somenteNaoGeradas, singleConnection);
                        break;
                    case ModoControleComissao.Faturamento:
                        ret = gerarRelatorioComissoesPorFaturamento(representante, vendedor, logo, mes, ano, somenteNaoGeradas, singleConnection);
                        break;
                    case ModoControleComissao.ContaReceber:
                        ret = gerarRelatorioComissoesPorContaReceber(representante, vendedor, logo, mes, ano, somenteNaoGeradas, singleConnection);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                ret.Sort(new ComissaoReportSorterClass());


                return ret;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar os dados para o relatorio de representantes.\r\n" + e.Message, e);
            }
        }

        private static List<ComissaoReportDataSource> gerarRelatorioComissoesPorPedidos(RepresentanteClass representante, VendedorClass vendedor, byte[] logo, int mes, int ano, bool somenteNaoGeradas, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
                List<ComissaoReportDataSource> toRet = new List<ComissaoReportDataSource>();

                List<SearchParameterClass> parametros = new List<SearchParameterClass>()
                                                            {
                                                                new SearchParameterClass("SubLinha", 0),
                                                                new SearchParameterClass("MesEntrada", mes),
                                                                new SearchParameterClass("AnoEntrada", ano),
                                                                new SearchParameterClass("Cancelado", false)
                                                            };

                if (representante!=null)
                {
                    parametros.Add(new SearchParameterClass("Representante", representante));
                }

                if (vendedor != null)
                {
                    parametros.Add(new SearchParameterClass("Vendedor", vendedor));
                }


                if (somenteNaoGeradas)
                {
                    parametros.Add(new SearchParameterClass("ComissaoGerada", false));
                }

                PedidoItemClass search = new PedidoItemClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                List<PedidoItemClass> pedidos = search.Search(parametros).ConvertAll(a => (PedidoItemClass) a);

                foreach (PedidoItemClass pedido in pedidos.Where(a => (a.Representante != null && a.PercComissaoRepresentante.HasValue) || (a.Vendedor != null && a.PercComissaoVendedor.HasValue)))
                {
                    if (pedido.Representante != null && ((representante == null && vendedor==null) || pedido.Representante == representante))
                    {
                        double pComissao = pedido.PercComissaoRepresentante.Value;
                        double valorComissao = Math.Round((pComissao*pedido.PrecoTotal)/100, 2);

                        toRet.Add(new ComissaoReportDataSource(logo)
                                      {
                                          Cliente = pedido.Cliente.ToString(),
                                          Data = pedido.DataEntrada,
                                          Pedido = pedido.Numero + "/" + pedido.Posicao,
                                          Pendentes = !pedido.ComissaoGerada,
                                          Representante = pedido.Representante,
                                          Porcentagem = pComissao,
                                          Valor = valorComissao,
                                          DataEncerramentoPedido = pedido.DataEncerramento.HasValue ? pedido.DataEncerramento.Value.ToString("dd/MM/yyyy") : null,
                                          ContaBancaria = pedido.Representante.ContaBancaria,
                                          CentroCusto = pedido.Representante.CentroCustoLucro,
                                          EntidadeGeradora = pedido
                                      });
                    }

                    if (pedido.Vendedor != null && ((representante == null && vendedor==null) || pedido.Vendedor == vendedor))
                    {
                        double pComissao = pedido.PercComissaoVendedor.Value;
                        double valorComissao = Math.Round((pComissao*pedido.PrecoTotal)/100, 2);

                        toRet.Add(new ComissaoReportDataSource(logo)
                        {
                            Cliente = pedido.Cliente.ToString(),
                            Data = pedido.DataEntrada,
                            Pedido = pedido.Numero + "/" + pedido.Posicao,
                            Pendentes = !pedido.ComissaoGerada,
                            Vendedor = pedido.Vendedor,
                            Porcentagem = pComissao,
                            Valor = valorComissao,
                            DataEncerramentoPedido = pedido.DataEncerramento.HasValue ? pedido.DataEncerramento.Value.ToString("dd/MM/yyyy") : null,
                            ContaBancaria = pedido.Vendedor.ContaBancaria,
                            CentroCusto = pedido.Vendedor.CentroCustoLucro,
                            EntidadeGeradora = pedido
                        });
                    }
                }


                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de comissão por data de entrada de pedidos.\r\n" + e.Message, e);
            }
        }

        private static List<ComissaoReportDataSource> gerarRelatorioComissoesPorFaturamento(RepresentanteClass representante, VendedorClass vendedor, byte[] logo, int mes, int ano, bool somenteNaoGeradas, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
                List<ComissaoReportDataSource> toRet = new List<ComissaoReportDataSource>();

                IWTPostgreNpgsqlCommand command = singleConnection.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.atendimento.id_atendimento, " +
                    "  (public.nf_produto.nfp_valor_total_tributavel/public.nf_produto.nfp_quantidade_tributavel)*public.atendimento.ate_quantidade as valor, "+
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.atendimento.ate_data_hora, " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao, " +
                    "  public.pedido_item.pei_status, " +
                    "  public.representante.rep_razao_social, " +
                    "  public.pedido_item.pei_perc_comissao_representante, " +
                    "  public.vendedor.ven_razao_social, " +
                    "  public.pedido_item.pei_perc_comissao_vendedor, " +
                    "  public.pedido_item.pei_data_encerramento, " +
                    "  public.representante.id_conta_bancaria as id_conta_bancaria_representante, " +
                    "  public.representante.id_centro_custo_lucro as id_centro_custo_lucro_representante, " +
                    "  public.vendedor.id_conta_bancaria as id_conta_bancaria_vendedor, " +
                    "  public.vendedor.id_centro_custo_lucro as id_centro_custo_lucro_vendedor, " +
                    "  public.representante.id_representante, "+
                    "  public.vendedor.id_vendedor, "+
                    "  public.atendimento.ate_comissao_gerada "+
                    "FROM " +
                    "  public.atendimento " +
                    "  INNER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal) " +
                    "  INNER JOIN public.nf_item ON (public.nf_principal.id_nf_principal = public.nf_item.id_nf_principal) " +
                    "  AND (public.nf_item.nfi_numero_item = public.atendimento.ate_linha_nf) " +
                    "  INNER JOIN public.pedido_item ON (public.atendimento.id_pedido_item = public.pedido_item.id_pedido_item) " +
                    "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                    "  LEFT OUTER JOIN public.representante ON (public.pedido_item.id_representante = public.representante.id_representante) " +
                    "  LEFT OUTER JOIN public.vendedor ON (public.pedido_item.id_vendedor = public.vendedor.id_vendedor) " +
                    "  INNER JOIN public.nf_produto ON (public.nf_produto.id_nf_item = public.nf_item.id_nf_item) " +
                    "WHERE " +
                    "  date_part('month', public.atendimento.ate_data_hora) = :mes AND  " +
                    "  date_part('year', public.atendimento.ate_data_hora) = :ano AND  " +
                    "  (public.representante.id_representante IS NOT NULL OR  " +
                    "  public.vendedor.id_vendedor IS NOT NULL) ";

                bool gerarRepresentante = true;
                bool gerarVendedor = true;

                if (representante != null)
                {
                    command.CommandText += " AND pedido_item.id_representante = " + representante.ID + " ";
                    gerarVendedor = false;
                }

                if (vendedor != null)
                {
                    command.CommandText += " AND pedido_item.id_vendedor = " + vendedor.ID + " ";
                    gerarRepresentante = false;
                }

                if (somenteNaoGeradas)
                {
                    command.CommandText += " AND public.atendimento.ate_comissao_gerada = 0 ";
                }


                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = mes;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ano", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = ano;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    StatusPedido status = (StatusPedido) Enum.ToObject(typeof (StatusPedido), read["pei_status"]);
                    DateTime? dataEncerramento = null;
                    if (read["pei_data_encerramento"] != DBNull.Value)
                    {
                        dataEncerramento = Convert.ToDateTime(read["pei_data_encerramento"]);
                    }

                    AtendimentoClass atendimento = AtendimentoBaseClass.GetEntidade(Convert.ToInt32(read["id_atendimento"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);

                    if (gerarRepresentante && read["id_representante"] != DBNull.Value)
                    {
                        double pComissao = Convert.ToDouble(read["pei_perc_comissao_representante"]);
                        double valorComissao = Math.Round((pComissao*Convert.ToDouble(read["valor"])) / 100, 2);

                        ContaBancariaClass conta = null;
                        if (read["id_conta_bancaria_representante"]!=DBNull.Value)
                        {
                            conta = ContaBancariaBaseClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria_representante"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);
                        }

                        CentroCustoLucroClass centroCusto = null;
                        if (read["id_centro_custo_lucro_representante"] != DBNull.Value)
                        {
                            centroCusto = CentroCustoLucroBaseClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro_representante"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);
                        }


                        toRet.Add(new ComissaoReportDataSource(logo)
                                      {
                                          Cliente = read["cli_nome_resumido"].ToString(),
                                          Data = Convert.ToDateTime(read["ate_data_hora"]),
                                          Pedido = read["pei_numero"].ToString() + "/" + read["pei_posicao"].ToString() + " (Conf: "+atendimento.ID+")",
                                          Pendentes = !Convert.ToBoolean(Convert.ToInt16(read["ate_comissao_gerada"])),
                                          Representante = RepresentanteBaseClass.GetEntidade(Convert.ToInt32(read["id_representante"]), LoginClass.UsuarioLogado.loggedUser, singleConnection),
                                          Porcentagem = pComissao,
                                          Valor = valorComissao,
                                          DataEncerramentoPedido = dataEncerramento.HasValue ? dataEncerramento.Value.ToString("dd/MM/yyyy") : null,
                                          ContaBancaria = conta,
                                          CentroCusto = centroCusto,
                                          EntidadeGeradora = atendimento

                                      });
                    }

                    if (gerarVendedor && read["id_vendedor"] != DBNull.Value)
                    {
                        double pComissao = Convert.ToDouble(read["pei_perc_comissao_vendedor"]);
                        double valorComissao = Math.Round((pComissao*Convert.ToDouble(read["nfp_valor_total_tributavel"])) / 100, 2);

                        ContaBancariaClass conta = null;
                        if (read["id_conta_bancaria_vendedor"] != DBNull.Value)
                        {
                            conta = ContaBancariaBaseClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria_vendedor"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);
                        }

                        CentroCustoLucroClass centroCusto = null;
                        if (read["id_centro_custo_lucro_vendedor"] != DBNull.Value)
                        {
                            centroCusto = CentroCustoLucroBaseClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro_vendedor"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);
                        }


                        toRet.Add(new ComissaoReportDataSource(logo)
                                      {
                                          Cliente = read["cli_nome_resumido"].ToString(),
                                          Data = Convert.ToDateTime(read["ate_data_hora"]),
                                          Pedido = read["pei_numero"].ToString() + "/" + read["pei_posicao"].ToString(),
                                          Pendentes = !Convert.ToBoolean(Convert.ToInt16(read["ate_comissao_gerada"])),
                                          Vendedor = VendedorBaseClass.GetEntidade(Convert.ToInt32(read["id_vendedor"]), LoginClass.UsuarioLogado.loggedUser, singleConnection),
                                          Porcentagem = pComissao,
                                          Valor = valorComissao,
                                          DataEncerramentoPedido = dataEncerramento.HasValue ? dataEncerramento.Value.ToString("dd/MM/yyyy") : null,
                                          ContaBancaria = conta,
                                          CentroCusto = centroCusto,
                                          EntidadeGeradora = atendimento
                                      });
                    }
                }


                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de comissão por faturamento.\r\n" + e.Message, e);
            }
        }

        private static List<ComissaoReportDataSource> gerarRelatorioComissoesPorContaReceber(RepresentanteClass representante, VendedorClass vendedor, byte[] logo, int mes, int ano, bool somenteNaoGeradas, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
                List<ComissaoReportDataSource> toRet = new List<ComissaoReportDataSource>();

                IWTPostgreNpgsqlCommand command = singleConnection.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.conta_receber.id_conta_receber, "+
                    "  public.conta_receber.id_nf_principal, "+
                    "  public.nf_produto.nfp_valor_total_tributavel, " +
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao, " +
                    "  public.pedido_item.pei_status, " +
                    "  public.representante.rep_razao_social, " +
                    "  public.pedido_item.pei_perc_comissao_representante, " +
                    "  public.vendedor.ven_razao_social, " +
                    "  public.pedido_item.pei_perc_comissao_vendedor, " +
                    "  public.pedido_item.pei_data_encerramento, " +
                    "  public.conta_receber.cor_data_pagamento, " +
                    "  public.nf_totais.nfo_valor_total_produtos_servicos_icms, " +
                    "  public.nf_totais.nfo_valor_total_nf, " +
                    "  public.conta_receber.cor_valor, "+
                    "  public.representante.id_conta_bancaria as id_conta_bancaria_representante, " +
                    "  public.representante.id_centro_custo_lucro as id_centro_custo_lucro_representante, " +
                    "  public.vendedor.id_conta_bancaria as id_conta_bancaria_vendedor, " +
                    "  public.vendedor.id_centro_custo_lucro as id_centro_custo_lucro_vendedor, " +
                    "  public.representante.id_representante, " +
                    "  public.vendedor.id_vendedor, " +
                    "  public.conta_receber.cor_comissao_gerada "+
                    "FROM " +
                    "  public.atendimento " +
                    "  INNER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal) " +
                    "  INNER JOIN public.nf_item ON (public.nf_principal.id_nf_principal = public.nf_item.id_nf_principal) " +
                    "  AND (public.nf_item.nfi_numero_item = public.atendimento.ate_linha_nf) " +
                    "  INNER JOIN public.pedido_item ON (public.atendimento.id_pedido_item = public.pedido_item.id_pedido_item) " +
                    "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                    "  LEFT OUTER JOIN public.representante ON (public.pedido_item.id_representante = public.representante.id_representante) " +
                    "  LEFT OUTER JOIN public.vendedor ON (public.pedido_item.id_vendedor = public.vendedor.id_vendedor) " +
                    "  INNER JOIN public.conta_receber ON (public.nf_principal.id_nf_principal = public.conta_receber.id_nf_principal) " +
                    "  INNER JOIN public.nf_produto ON (public.nf_produto.id_nf_item = public.nf_item.id_nf_item) " +
                    "  INNER JOIN public.nf_totais ON (public.nf_principal.id_nf_principal = public.nf_totais.id_nf_principal) " +
                    "WHERE " +
                    "  public.conta_receber.cor_data_pagamento IS NOT NULL AND  " +
                    "  date_part('month', public.conta_receber.cor_data_pagamento) = :mes AND  " +
                    "  date_part('year', public.conta_receber.cor_data_pagamento) = :ano AND  " +
                    "  (public.representante.id_representante IS NOT NULL OR  " +
                    "  public.vendedor.id_vendedor IS NOT NULL) ";


                bool gerarRepresentante = true;
                bool gerarVendedor = true;
                if (representante != null)
                {
                    command.CommandText += " AND pedido_item.id_representante = " + representante.ID + " ";
                    gerarVendedor = false;
                }

                if (vendedor != null)
                {
                    command.CommandText += " AND pedido_item.id_vendedor = " + vendedor.ID + " ";
                    gerarRepresentante = false;
                }

                if (somenteNaoGeradas)
                {
                    command.CommandText += " AND public.conta_receber.cor_comissao_gerada = 0 ";
                }


                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = mes;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ano", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = ano;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    StatusPedido status = (StatusPedido)Enum.ToObject(typeof(StatusPedido), read["pei_status"]);
                    DateTime? dataEncerramento = null;
                    if (read["pei_data_encerramento"] != DBNull.Value)
                    {
                        dataEncerramento = Convert.ToDateTime(read["pei_data_encerramento"]);
                    }

                    double valorItemNaParcela = Convert.ToDouble(read["nfp_valor_total_tributavel"]) / Convert.ToDouble(read["nfo_valor_total_produtos_servicos_icms"]);

                    //Calcula o valor ajustado da parcela para retirar os impostos da nf

                    double valorTotalParcelas = Convert.ToDouble(read["nfo_valor_total_nf"]);
                    double valorAjustadoParcela = (Convert.ToDouble(read["cor_valor"])/valorTotalParcelas)*Convert.ToDouble(read["nfo_valor_total_produtos_servicos_icms"]);


                    valorItemNaParcela = valorItemNaParcela*valorAjustadoParcela;

                    ContaReceberClass contaReceber = ContaReceberBaseClass.GetEntidade(Convert.ToInt32(read["id_conta_receber"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);

                    if (gerarRepresentante && read["id_representante"] != DBNull.Value)
                    {
                        double pComissao = Convert.ToDouble(read["pei_perc_comissao_representante"]);
                        double valorComissao = Math.Round((pComissao*valorItemNaParcela) / 100, 2);

                        ContaBancariaClass conta = null;
                        if (read["id_conta_bancaria_representante"] != DBNull.Value)
                        {
                            conta = ContaBancariaBaseClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria_representante"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);
                        }

                        CentroCustoLucroClass centroCusto = null;
                        if (read["id_centro_custo_lucro_representante"] != DBNull.Value)
                        {
                            centroCusto = CentroCustoLucroBaseClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro_representante"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);
                        }

                        toRet.Add(new ComissaoReportDataSource(logo)
                        {
                            Cliente = read["cli_nome_resumido"].ToString(),
                            Data = Convert.ToDateTime(read["cor_data_pagamento"]),
                            Pedido = read["pei_numero"].ToString() + "/" + read["pei_posicao"].ToString(),
                            Pendentes = !Convert.ToBoolean(Convert.ToInt16(read["cor_comissao_gerada"])),
                            Representante = RepresentanteBaseClass.GetEntidade(Convert.ToInt32(read["id_representante"]), LoginClass.UsuarioLogado.loggedUser, singleConnection),
                            Porcentagem = pComissao,
                            Valor = valorComissao,
                            DataEncerramentoPedido = dataEncerramento.HasValue ? dataEncerramento.Value.ToString("dd/MM/yyyy") : null,
                            ContaBancaria = conta,
                            CentroCusto = centroCusto,
                            EntidadeGeradora = contaReceber
                        });
                    }

                    if (gerarVendedor && read["id_vendedor"] != DBNull.Value)
                    {
                        double pComissao = Convert.ToDouble(read["pei_perc_comissao_vendedor"]);
                        double valorComissao = Math.Round((pComissao * valorItemNaParcela) / 100, 2);

                        ContaBancariaClass conta = null;
                        if (read["id_conta_bancaria_vendedor"] != DBNull.Value)
                        {
                            conta = ContaBancariaBaseClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria_vendedor"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);
                        }

                        CentroCustoLucroClass centroCusto = null;
                        if (read["id_centro_custo_lucro_vendedor"] != DBNull.Value)
                        {
                            centroCusto = CentroCustoLucroBaseClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro_vendedor"]), LoginClass.UsuarioLogado.loggedUser, singleConnection);
                        }

                        toRet.Add(new ComissaoReportDataSource(logo)
                        {
                            Cliente = read["cli_nome_resumido"].ToString(),
                            Data = Convert.ToDateTime(read["cor_data_pagamento"]),
                            Pedido = read["pei_numero"].ToString() + "/" + read["pei_posicao"].ToString(),
                            Pendentes = !Convert.ToBoolean(Convert.ToInt16(read["cor_comissao_gerada"])),
                            Vendedor = VendedorBaseClass.GetEntidade(Convert.ToInt32(read["id_vendedor"]), LoginClass.UsuarioLogado.loggedUser, singleConnection),
                            Porcentagem = pComissao,
                            Valor = valorComissao,
                            DataEncerramentoPedido = dataEncerramento.HasValue ? dataEncerramento.Value.ToString("dd/MM/yyyy") : null,
                            ContaBancaria = conta,
                            CentroCusto = centroCusto,
                            EntidadeGeradora = contaReceber
                        });
                    }
                }


                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de comissão por conta a receber.\r\n" + e.Message, e);
            }
        }




        public static void GerarContasPagarComissoes(RepresentanteClass representante,VendedorClass vendedor, int mes, int ano, DateTime dataVencimento, ContaBancariaClass contaBancaria, CentroCustoLucroClass centroCusto, IWTPostgreNpgsqlConnection singleConnection)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                List<ComissaoReportDataSource> comissoes = GerarRelatorioComissoes(representante, vendedor, mes, ano, true, singleConnection);

                Dictionary<ComissaoGeradaKey, ComissaoGerada> comissoesGeradas = new Dictionary<ComissaoGeradaKey, ComissaoGerada>();

                foreach (ComissaoReportDataSource comissao in comissoes)
                {
                    ComissaoGeradaKey key = new ComissaoGeradaKey(comissao.Representante, comissao.Vendedor, comissao.Tipo, comissao.ContaBancaria ?? contaBancaria, comissao.CentroCusto ?? centroCusto);
                    if (!comissoesGeradas.ContainsKey(key))
                    {
                        comissoesGeradas.Add(key, new ComissaoGerada()
                                                      {
                                                          CentroCusto = key.CentroCusto,
                                                          ContaBancaria = key.ContaBancaria,
                                                          Representante = key.Representante,
                                                          Vendedor = key.Vendedor,
                                                          Tipo = key.Tipo,
                                                          dataVencimento = dataVencimento
                                                      });
                    }

                    comissoesGeradas[key].Comissoes.Add(comissao);
                }


                command = singleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                foreach (ComissaoGerada comissaoGerada in comissoesGeradas.Values)
                {
                    comissaoGerada.Salvar(ref command);
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
                throw new Exception("Erro ao gerar as contas a Pagar das comissões do representante\r\n" + e.Message, e);
            }
        }

    }
}