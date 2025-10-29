using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public static class NotaFiscalFuncoesAuxiliares
    {
        public static void PularNFe(IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {




                int ultimaNFEmitida = NfPrincipalClass.maxNumeroNf(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CNPJ), 1, "55", false, false);


                if (
                    MessageBox.Show(null,
                                    "A última nota fiscal emitida foi a número " + ultimaNFEmitida.ToString() +
                                    ". Deseja pular um número?", "Pular um número de NFe", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //public NfPrincipalClass(int nfpNumero, string nfpNaturezaOperacao, int nfpSerie, int nfpFormaPagamento, string nfpModeloDocFiscal, DateTime nfpDataEmissao, DateTime nfpDataSaidaEntrada, int nfpTipo, int nfpCodMunicipioFatoGerador,
                    //int nfpFormatoImpressao, int nfpFormaEmissao, int nfpIdentificacaoAmbiente, int nfpFinalidadeEmissao, int nfpProcessoEmissao, string nfpVersaoProcessoEmissao, string nfpObservacoes,string nfpTipoEmitente,string nfpSituacao)
                    NfPrincipalClass nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                              {
                                                  Numero = ultimaNFEmitida + 1,
                                                  NaturezaOperacao = "Emissão Externa",
                                                  Serie = 1,
                                                  FormaPagamento = FormaPagamento.AVista,
                                                  ModeloDocFiscal = "55",
                                                  DataEmissao = Configurations.DataIndependenteClass.GetData(),
                                                  DataSaidaEntrada = Configurations.DataIndependenteClass.GetData(),
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


                    EmitenteClass emitenteCompleto;
                    PisCofinsInfo pisCofinsInfo;
                    nf.NfEmitente = NotaFiscalFuncoesAuxiliares.CarregaEmitente(singleConnection, out emitenteCompleto,EasiEmissorNFe.Primario, out pisCofinsInfo);
                    nf.NfEmitente.NfPrincipal = nf;
                    nf.NfEmitente.NfEmitenteEndereco.NfPrincipal = nf;
                    nf.NfEmitente.NfEmitenteEndereco.NfEmitente = nf.NfEmitente;
                    
                    
                    nf.Save();


                    MessageBox.Show(null,
                                    "A próxima nota fiscal emitida será a de número " + (ultimaNFEmitida + 2).ToString(),
                                    "Pular NFe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pular um número de NFe\r\n" + e.Message, e);
            }
        }

        public static bool ValidarCancelamentoNFe(NfPrincipalClass nf, ref IWTPostgreNpgsqlCommand command)
        {
            command.CommandText =
                "SELECT  " +
                "  COUNT(public.conta_receber.id_conta_receber) AS qtd " +
                "FROM " +
                "  public.conta_receber " +
                "WHERE " +
                "  public.conta_receber.id_nf_principal = :id_nf_principal AND  " +
                "  public.conta_receber.cor_data_pagamento IS NOT NULL ";

            command.Parameters.Clear();

            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = nf.ID;

            object tmp = command.ExecuteScalar();
            int qtdContasReceberPagas = Convert.ToInt32(tmp);

            if (qtdContasReceberPagas > 0)
            {
                throw new Exception("Já existem contas a receber pagas vinculadas a essa nota, realize o estorno antes de cancelar a NFe");
            }



            command.CommandText =
                "SELECT  " +
                "  COUNT(public.conta_receber.id_conta_receber) AS qtd " +
                "FROM " +
                "  public.conta_receber " +
                "WHERE " +
                "  public.conta_receber.id_nf_principal = :id_nf_principal AND  " +
                "  public.conta_receber.id_cobranca_boleto IS NOT NULL ";

            command.Parameters.Clear();

            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = nf.ID;

            tmp = command.ExecuteScalar();
            int qtdContasReceberComBoletos = Convert.ToInt32(tmp);

            if (qtdContasReceberComBoletos > 0)
            {
                throw new Exception("Já existem boletos vinculados a essa nota, realize o cancelamento dos boletos antes de cancelar a NFe");
            }



            return true;
        }

        public static void CancelarNFe(int idNFPrincipal, string justificativa, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlCommand command)
        {
            try
            {
                try
                {
                    NfPrincipalClass nf = NfPrincipalBaseClass.GetEntidade(idNFPrincipal, usuarioAtual, command.Connection);
                    CancelarNFe(nf, usuarioAtual, command, justificativa);

                }
                catch (Exception e)
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar o cancelamento da NFe no EASI\r\n" + e.Message, e);
            }
        }

        public static void CancelarNFe(int numeroNfe, int serie, string modelo, string justificativa, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlCommand command)
        {
            try
            {

                try
                {
                    NfPrincipalClass search = new NfPrincipalClass(usuarioAtual, command.Connection);

                    NfPrincipalClass nf = search.Search(numeroNfe, serie, modelo);
                    if (nf == null)
                    {
                        throw new Exception("Quantidade de notas fiscais encontradas inválido");
                    }


                    CancelarNFe(nf,usuarioAtual, command, justificativa);




                }
                catch (Exception e)
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar o cancelamento da NFe no EASI\r\n" + e.Message, e);
            }
        }

        public static void DesfazerEmissaoNFeFaturamentoAntecipado(PedidoItemClass pedido, NfPrincipalClass nota, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlCommand command)
        {
            try
            {
                LogClass.EscreverLog("TratamentoRejeicaoFaturamentoAntecipadoDesfazerEmissaoAntecipada:" + pedido.ID + "-" + nota.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
            }
            catch { }

            pedido.NfPrincipalFaturamentoAntecipado = null;
            pedido.FaturamentoAntecipadoRealizado = false;
            pedido.Save(ref command);

            List<ContaReceberClass> contasReceber = new ContaReceberClass(usuarioAtual, command.Connection).Search(
                new List<SearchParameterClass>()
                {
                    new SearchParameterClass("NfPrincipal", nota)
                }).ConvertAll(a => (ContaReceberClass)a).ToList();

            foreach (ContaReceberClass contaReceber in contasReceber)
            {
                if (!contaReceber.DataPagamento.HasValue)
                {
                    contaReceber.Delete(ref command);
                }
            }
        }

        public static void CancelarNFe(NfPrincipalClass nf, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlCommand command, object justificativa)
        {

         


            ValidarCancelamentoNFe(nf, ref command);


            string pedidosFaturamentoAntecipado = "";

           
                List<PedidoItemClass> pedidos = new PedidoItemClass(usuarioAtual, command.Connection).Search(
                    new List<SearchParameterClass>()
                    {
                                    new SearchParameterClass("NfPrincipalFaturamentoAntecipado", nf)
                    }).ConvertAll(a => (PedidoItemClass)a).ToList();


            if (pedidos.Count > 0)
            {
                foreach (PedidoItemClass pedido in pedidos)
                {
                    DesfazerEmissaoNFeFaturamentoAntecipado(pedido, nf, usuarioAtual, command);
                }

                return;
            }


            List<OrdemProducaoEnvioTerceirosClass> opsEnvioTerceiro = new OrdemProducaoEnvioTerceirosClass(usuarioAtual, command.Connection).Search(
                new List<SearchParameterClass>()
                {
                    new SearchParameterClass("NfPrincipal", nf)
                }).ConvertAll(a => (OrdemProducaoEnvioTerceirosClass)a).ToList();


            if (opsEnvioTerceiro.Count > 0)
            {
         
                foreach (OrdemProducaoEnvioTerceirosClass opEnvio in opsEnvioTerceiro)
                {
                    NotaFiscalFuncoesAuxiliares.DesfazerEmissaoNFeFaturamentoEnvioServicoExterno(opEnvio, nf, usuarioAtual, command);
                }

                return;
            }


            IWTPostgreNpgsqlCommand command2 = command.Connection.CreateCommand();
            command2.Transaction = command.Transaction;



            command.CommandText =
                "SELECT  " +
                "  public.pedido_item.pei_numero, " +
                "  public.pedido_item.pei_posicao, " +
                "  public.atendimento.id_order_item_etiqueta_conferencia, " +
                "  public.atendimento.id_order_item_etiqueta, " +
                "  public.pedido_item.id_pedido_item, " +
                "  public.atendimento.ate_quantidade, " +
                "  public.atendimento.ate_atlas, " +
                "  public.order_item_etiqueta_conferencia.oic_pallet, " +
                "  public.order_item_etiqueta_conferencia.oic_pallet_sequencia " +
                "FROM " +
                "  public.atendimento " +
                "  INNER JOIN public.pedido_item ON (public.atendimento.id_pedido_item = public.pedido_item.id_pedido_item) " +
                "  INNER JOIN public.order_item_etiqueta_conferencia ON (public.atendimento.id_order_item_etiqueta_conferencia = public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) " +
                "WHERE " +
                "  public.atendimento.id_nf_principal = :id_nf_principal";

            command.Parameters.Clear();
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = nf.ID;

            List<int> idsOrderItemEtiquetaConferencia =new List<int>();
            Dictionary<int,double> idsPedidoItem = new Dictionary<int, double>();
            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                command2.CommandText = "UPDATE order_item_etiqueta SET oie_saldo = oie_saldo + :qtdAtendimento, oie_status_pedido='P' WHERE id_order_item_etiqueta = " + read["id_order_item_etiqueta"] + "; ";
                command2.CommandText += "UPDATE pedido_item SET pei_saldo = pei_saldo + :qtdAtendimento, pei_status = 0 WHERE id_pedido_item = " + read["id_pedido_item"] + "; ";
                if (read["ate_atlas"].ToString() == "1")
                {
                    command2.CommandText += "UPDATE order_item SET \"status\" = 'WAIT_INVOI', saldo = saldo + :qtdAtendimento WHERE order_number='" + read["pei_numero"] + "' AND order_pos=" + read["pei_posicao"] + "; ";
                }

                command2.Parameters.Clear();
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("qtdAtendimento", NpgsqlDbType.Double));
                command2.Parameters[command2.Parameters.Count - 1].Value = read["ate_quantidade"];
                command2.ExecuteNonQuery();

                idsOrderItemEtiquetaConferencia.Add(Convert.ToInt32(read["id_order_item_etiqueta_conferencia"]));
                int id = Convert.ToInt32(read["id_pedido_item"]);
                if (!idsPedidoItem.ContainsKey(id))
                {
                    idsPedidoItem.Add(id, 0);
                }
                idsPedidoItem[id] = Math.Round(idsPedidoItem[id] + Convert.ToDouble(read["ate_quantidade"]), 5);
            }
            read.Close();

            #region Conferência
            foreach (int id in idsOrderItemEtiquetaConferencia)
            {

                OrderItemEtiquetaConferenciaClass confPai = OrderItemEtiquetaConferenciaClass.GetEntidade(id, usuarioAtual, command.Connection);
                if (!confPai.ConferenciaPai)
                {
                    continue;
                }

                //remover todas conferencia nf
                command.CommandText =
                    "DELETE FROM  " +
                    "  public.order_item_etiqueta_conferencia_nf   " +
                    "  WHERE  oin_pallet||'-'||oin_pallet_sequencia IN( " +
                    "SELECT DISTINCT  " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet||'-'|| " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet_sequencia " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia = " + confPai.ID + " " +
                    "); ";
                command.ExecuteNonQuery();

                OrderItemEtiquetaConferenciaClass.DesfazerConferencia(confPai, usuarioAtual, command, "Cancelamento de NFe");

                //Estorna o item nf que não foi estornado antes
                bool EmiteOp;
                double multiplicadorQuantidadeItemK = 1;
                if (confPai.OrderItemEtiqueta.ProdutoK == null)
                {
                    EmiteOp = confPai.OrderItemEtiqueta.Produto.EmiteOp;
                }
                else
                {
                    EmiteOp = confPai.OrderItemEtiqueta.ProdutoK.EmiteOp;

                    if (confPai.OrderItemEtiqueta.ProdutoK.UtilizaDimensaoQuantidadeBaixa)
                    {
                        //Utiliza a dimensão do agrupador para indicar a quantidade de itens que devem ser baixados
                        //do estoque por unidade do agrupador
                        double tmp;

                        if (double.TryParse(confPai.OrderItemEtiqueta.ProdutoK.Dimensao, out tmp))
                        {
                            multiplicadorQuantidadeItemK = tmp;
                        }
                        else
                        {
                            throw new Exception("O item " + confPai.OrderItemEtiqueta.CodigoItem + " possui um item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                        }
                    }
                }

                double QuantidadeItem = confPai.QuantidadeConferida;

                if (EmiteOp)
                {
                    //item Emite OP, baixa o item produzido
                    if (confPai.OrderItemEtiqueta.ProdutoK == null)
                    {
                        EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(
                            confPai.OrderItemEtiqueta.Produto,
                            QuantidadeItem,
                            "Estorno de  Produto Produzido por Cancelamento da NFe " + nf.Numero,
                            "Pedido " + confPai.OrderItemEtiqueta.OrderNumber + "/" + confPai.OrderItemEtiqueta.OrderPos,
                            usuarioAtual, false, ref command, false);
                    }
                    else
                    {
                        EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProdutoK(
                            confPai.OrderItemEtiqueta.ProdutoK,
                            QuantidadeItem,
                            "Estorno de  Produto KB Produzido por Cancelamento da NFe " + nf.Numero,
                            "Pedido " + confPai.OrderItemEtiqueta.OrderNumber + "/" + confPai.OrderItemEtiqueta.OrderPos,
                            usuarioAtual, false, ref command);
                    }
                }
                else
                {
                    //item é não emite OP, baixa os materiais ou  o produto comprado

                    //Identifica se o item é comprado

                    bool retEstorno = true;
                    switch (confPai.OrderItemEtiqueta.Produto.TipoAquisicao)
                    {
                        case TipoAquisicao.Fabricado:

                            //Verifica se existe estoque do produto acabado, se existir ele tem precedencia sobre a baixa de materiais


                            if (confPai.OrderItemEtiqueta.ProdutoK == null)
                            {
                                retEstorno = EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(
                                    confPai.OrderItemEtiqueta.Produto,
                                    QuantidadeItem,
                                    "Estorno de produto Fabricado por Cancelamento da NFe " + nf.Numero,
                                    "Pedido " + confPai.OrderItemEtiqueta.OrderNumber + "/" + confPai.OrderItemEtiqueta.OrderPos,
                                    usuarioAtual, false, ref command, false);

                            }
                            else
                            {
                                double qtdEstornar = QuantidadeItem*multiplicadorQuantidadeItemK;
                                retEstorno = EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProdutoK(
                                    confPai.OrderItemEtiqueta.ProdutoK,
                                    qtdEstornar,
                                    "Estorno de produto KB Fabricado por Cancelamento da NFe " + nf.Numero,
                                    "Pedido " + confPai.OrderItemEtiqueta.OrderNumber + "/" + confPai.OrderItemEtiqueta.OrderPos,
                                    usuarioAtual, false, ref command);
                            }

                            break;

                        case TipoAquisicao.Comprado:
                            retEstorno = EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(
                                confPai.OrderItemEtiqueta.Produto,
                                QuantidadeItem,
                                "Estorno de Produto Comprado por Cancelamento da NFe " + nf.Numero,
                                "Estorno " + confPai.OrderItemEtiqueta.OrderNumber + "/" + confPai.OrderItemEtiqueta.OrderPos,
                                usuarioAtual, false, ref command, false);
                            break;


                    }

                    if (!retEstorno)
                    {
                        foreach (PedidoItemConfiguradoMaterialClass material in confPai.OrderItemEtiqueta.CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta)
                        {
                            EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoMaterial(
                                material.Material,
                                QuantidadeItem*material.QuantidadeUnidadePai,
                                "Estorno de Material (Produto " + confPai.OrderItemEtiqueta.Produto + " sem local de estoque definido) por Cancelamento da NFe " + nf.Numero,
                                "Estorno " + confPai.OrderItemEtiqueta.OrderNumber + "/" + confPai.OrderItemEtiqueta.OrderPos,
                                usuarioAtual, false, ref command, false);
                        }
                    }
                }
            }
            #endregion


            #region Exclusão de contas a receber
            command2.CommandText =
                "DELETE FROM  " +
                "  public.conta_receber " +
                "WHERE " +
                "  public.conta_receber.id_nf_principal = :id_nf_principal";
            command2.Parameters.Clear();

            command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
            command2.Parameters[command2.Parameters.Count - 1].Value = nf.ID;

            command2.ExecuteNonQuery();
            #endregion

            #region Devolução de Materiais de Cliente

            foreach (KeyValuePair<int, double> itemPedido in idsPedidoItem)
            {
                PedidoItemClass pedido = PedidoItemClass.GetEntidade(itemPedido.Key, usuarioAtual, command.Connection);
                foreach (PedidoItemLoteClienteClass matCliente in pedido.CollectionPedidoItemLoteClienteClassPedidoItem.Where(a=>a.Lote.Situacao!=StatusLote.Cancelado))
                {

                    double razaoDev = itemPedido.Value / pedido.Quantidade;

                    double qtdDevolverMaterial = Math.Round(matCliente.Quantidade * razaoDev, 5);

                    matCliente.SaldoDevolucao = Math.Round(matCliente.SaldoDevolucao + qtdDevolverMaterial, 5);
                    matCliente.Lote.Situacao = StatusLote.EmAberto;
                    matCliente.Lote.SaldoDevolucao = Math.Round(matCliente.Lote.SaldoDevolucao + qtdDevolverMaterial, 5);

                    if (matCliente.Lote.Material!=null)
                    {
                        EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoMaterial(matCliente.Lote.Material, qtdDevolverMaterial, "Estorno da Devolução Material do Cliente por cancelamento de nota",
                            " NF Nº" + nf.Numero,
                            usuarioAtual, false, ref command, false);
                    }
                    else
                    {
                        EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(matCliente.Lote.Produto, qtdDevolverMaterial, "Estorno da Devolução Produto do Cliente por cancelamento de nota",
                                     " NF Nº" + nf.Numero,
                                     usuarioAtual, false, ref command, false);
                    }

                    matCliente.Lote.Save(ref command);
                    matCliente.Save(ref command);
                }

            }

            #endregion

            //Cancela a NFe
            nf.Situacao = "C";
            nf.Save(ref command2);

            command2.CommandText =
                "INSERT INTO  " +
                "  public.nf_principal_cancelamento_justificativa " +
                "( " +
                "  id_nf_principal, " +
                "  ncj_justificativa, " +
                "  id_acs_usuario " +
                ")  " +
                "VALUES ( " +
                "  :id_nf_principal, " +
                "  :ncj_justificativa, " +
                "  :id_acs_usuario " +
                ")";

            command2.Parameters.Clear();

            command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
            command2.Parameters[command2.Parameters.Count - 1].Value = nf.ID;
            command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncj_justificativa", NpgsqlDbType.Varchar));
            command2.Parameters[command2.Parameters.Count - 1].Value = justificativa;
            command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
            command2.Parameters[command2.Parameters.Count - 1].Value = LoginClass.UsuarioLogado.loggedUser.ID;

            command2.ExecuteNonQuery();

       
        }

        private static string GeraStringConfiguracoes(EasiEmissorNFe selecaoEmitente)
        {
            switch (selecaoEmitente)
            {
                case EasiEmissorNFe.Primario:
                    return "";
                    break;
                case EasiEmissorNFe.Secundario:
                    return "__2";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(selecaoEmitente), selecaoEmitente, null);
            }
        }

        public static string CarregaNomeEmpresa(EasiEmissorNFe selecaoEmitente = EasiEmissorNFe.Primario)
        {
            string complementoConfiguracoes = GeraStringConfiguracoes(selecaoEmitente);
            return IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_RAZAO + complementoConfiguracoes);
        }

        public static NfEmitenteClass CarregaEmitente(IWTPostgreNpgsqlConnection singleConnection, out EmitenteClass emitenteCompleto, EasiEmissorNFe selecaoEmitente, out PisCofinsInfo pisCofinsDefault)
        {
            string complementoConfiguracoes = GeraStringConfiguracoes(selecaoEmitente);

            

            int? smtpPort = null;
            try
            {
                smtpPort = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.SMTP_PORT));
            }
            catch
            {
            }

            emitenteCompleto = new EmitenteClass(
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_RAZAO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CNPJ + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_IE + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_ENDERECO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_NUMERO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COMPLEMENTO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CEP + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_BAIRRO + complementoConfiguracoes),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CIDADE + complementoConfiguracoes)),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_TELEFONE + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_FAX + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CONTATO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_CST + complementoConfiguracoes),
                Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_ALIQUOTA + complementoConfiguracoes),
                    CultureInfo.InvariantCulture),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_MODALIDADE + complementoConfiguracoes)),
                Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_IMPOSTO_RETIDO + complementoConfiguracoes))),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_CST + complementoConfiguracoes),
                Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_ALIQUOTA + complementoConfiguracoes),
                    CultureInfo.InvariantCulture),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_MODALIDADE + complementoConfiguracoes)),
                Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_IMPOSTO_RETIDO + complementoConfiguracoes))),
                (CRTTipo)
                Enum.ToObject(typeof(CRTTipo), Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CRT + complementoConfiguracoes))),
                IWTConfiguration.Conf.getConf(Constants.NF_PATH_OUT + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_VERSAO_EMISSOR),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_DAYS_TO_PAYMENT)),
                IWTConfiguration.Conf.getBoolConf(Constants.AVISO_NF_ATIVO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.AVISO_NF_REMETENTE + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.AVISO_NF_DESTINATARIO + complementoConfiguracoes),
                "",
                "",
                new ServidorEmailClass(
                    IWTConfiguration.Conf.getConf(Constants.SMTP_HOST),
                    smtpPort,
                    IWTConfiguration.Conf.getBoolConf(Constants.SMTP_AUTHENTICATION),
                    IWTConfiguration.Conf.getBoolConf(Constants.SMTP_AUTHENTICATION_SSH),
                    IWTConfiguration.Conf.getConf(Constants.SMTP_USER),
                    IWTConfiguration.Conf.getConf(Constants.SMTP_PASSWORD)),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_OBSERVACAO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CERTIFICADO + complementoConfiguracoes),
                singleConnection,
                IWTConfiguration.Conf.getConfiguracaoMultivalorada(Constants.NF_AUTORIZADOS_DOWNLOAD + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CNAE + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_IM + complementoConfiguracoes),
                IWTConfiguration.Conf.getBoolConf(Constants.NFE_IMPRIMIR_DANFE_HABILITADO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NFE_IMPRIMIR_DANFE_IMPRESSORA_1 + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NFE_IMPRIMIR_DANFE_IMPRESSORA_2 + complementoConfiguracoes),

                IWTConfiguration.Conf.getBoolConf(Constants.NFE_ENVIO_EMAIL_HABILITADO + complementoConfiguracoes),

                IWTConfiguration.Conf.getBoolConf(Constants.NFE_ENVIO_EMAIL_XML_HABILITADO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NFE_ENVIO_EMAIL_XML_DESTINO + complementoConfiguracoes),

                IWTConfiguration.Conf.getBoolConf(Constants.NFE_ENVIO_EMAIL_DANFE_HABILITADO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NFE_ENVIO_EMAIL_DANFE_DESTINO + complementoConfiguracoes),
                IWTConfiguration.Conf.getBoolConf(Constants.NFE_ENVIO_EMAIL_CLIENTE_HABILITADO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NFE_ENVIO_EMAIL_REMETENTE + complementoConfiguracoes),
                

                IWTConfiguration.Conf.getBoolConf(Constants.NFE_SALVAR_PASTA_HABILITADO + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NFE_SALVAR_PASTA_DANFE + complementoConfiguracoes),
                IWTConfiguration.Conf.getConf(Constants.NFE_SALVAR_PASTA_XML + complementoConfiguracoes)
            );



            NfEmitenteClass emitente = new NfEmitenteClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
            {
                NfPrincipal = null,
                Razao = emitenteCompleto.RazaoSocial,
                NomeFantasia = emitenteCompleto.RazaoSocial,
                Ie = emitenteCompleto.InscricaoEstadual,
                Im = "",
                Cnae = "",
                IeSt = "",
                CnpjCpf = emitenteCompleto.Cnpj,
                Crt = Convert.ToInt16(emitenteCompleto.Crt)
            };


            CidadeClass cidade = emitenteCompleto.CidadeEntidade;

            string UfEmissor = cidade?.Estado?.Sigla;

            NfEmitenteEnderecoClass emitenteEndreco = new NfEmitenteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                          {
                                                              NfPrincipal = null,
                                                              NfEmitente = emitente,
                                                              Logradouro = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_ENDERECO + complementoConfiguracoes),
                                                              Numero = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_NUMERO + complementoConfiguracoes),
                                                              Complemento = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COMPLEMENTO + complementoConfiguracoes),
                                                              Bairro = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_BAIRRO + complementoConfiguracoes),
                                                              CodMunicipio = cidade?.CodigoIbge??0,
                                                              NomeMunicipio = cidade?.Nome,
                                                              SiglaUf = UfEmissor,
                                                              Cep = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CEP + complementoConfiguracoes),
                                                              CodPais = cidade?.Pais?.Codigo??0,
                                                              NomePais = cidade?.Pais.Nome,
                                                              Telefone = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_TELEFONE + complementoConfiguracoes)
                                                          };

            pisCofinsDefault = new PisCofinsInfo(
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_CST + complementoConfiguracoes),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_IMPOSTO_RETIDO + complementoConfiguracoes)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_MODALIDADE + complementoConfiguracoes)),
                Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_ALIQUOTA + complementoConfiguracoes), CultureInfo.InvariantCulture), 
                IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_CST + complementoConfiguracoes),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_IMPOSTO_RETIDO + complementoConfiguracoes)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_MODALIDADE + complementoConfiguracoes)),
                Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_ALIQUOTA + complementoConfiguracoes), CultureInfo.InvariantCulture));

            emitente.NfEmitenteEndereco = emitenteEndreco;
            
            
            return emitente;
        }

        public static void SalvaEmitente(EmitenteClass emitente, EasiEmissorNFe selecaoEmitente)
        {
            string complementoConfiguracoes = GeraStringConfiguracoes(selecaoEmitente);

            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_RAZAO + complementoConfiguracoes, emitente.RazaoSocial, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_CNPJ + complementoConfiguracoes, emitente.Cnpj, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_IE + complementoConfiguracoes, emitente.InscricaoEstadual, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_ENDERECO + complementoConfiguracoes, emitente.Endereco, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_NUMERO + complementoConfiguracoes, emitente.Numero, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_COMPLEMENTO + complementoConfiguracoes, emitente.Complemento, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_BAIRRO + complementoConfiguracoes, emitente.Bairro, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_CEP + complementoConfiguracoes, emitente.Cep, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_CIDADE + complementoConfiguracoes, emitente.CidadeEntidade.ID.ToString(CultureInfo.InvariantCulture), LoginClass.UsuarioLogado.loggedUser.Login);
            
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_TELEFONE + complementoConfiguracoes, emitente.Telefone, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_FAX + complementoConfiguracoes, emitente.Fax, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_CONTATO + complementoConfiguracoes, emitente.Contato, LoginClass.UsuarioLogado.loggedUser.Login);

            
            IWTConfiguration.Conf.SetConf(Constants.NF_PATH_OUT + complementoConfiguracoes, emitente.PastaSaidaNFe, LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_PIS_CST + complementoConfiguracoes, emitente.PisCst, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_PIS_ALIQUOTA + complementoConfiguracoes, emitente.PisAliquota.ToString("F2", CultureInfo.InvariantCulture), LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_PIS_MODALIDADE + complementoConfiguracoes, emitente.PisModalidade.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_PIS_IMPOSTO_RETIDO + complementoConfiguracoes, Convert.ToInt16(emitente.PisImpostoRetido).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_COFINS_CST + complementoConfiguracoes, emitente.CofinsCst, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_COFINS_ALIQUOTA + complementoConfiguracoes, emitente.CofinsAliquota.ToString("F2", CultureInfo.InvariantCulture), LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_COFINS_MODALIDADE + complementoConfiguracoes, emitente.CofinsModalidade.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_COFINS_IMPOSTO_RETIDO + complementoConfiguracoes, Convert.ToInt16(emitente.CofinsImpostoRetido).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_CRT + complementoConfiguracoes, Convert.ToInt32(emitente.Crt).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_OBSERVACAO + complementoConfiguracoes, emitente.ObservacaoEmitente, LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NF_VERSAO_EMISSOR, emitente.VersaoEmissorNFe, LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.setConf(Constants.NF_AUTORIZADOS_DOWNLOAD + complementoConfiguracoes, emitente.AutorizadosDownloadNf, "DB", LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_CNAE + complementoConfiguracoes, emitente.Cnae, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NF_EMITENTE_IM + complementoConfiguracoes, emitente.InscricaoMunicipal, LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.setConf(Constants.NF_EMITENTE_CERTIFICADO + complementoConfiguracoes, emitente.SerialCertificado, "XML", LoginClass.UsuarioLogado.loggedUser.Login);



            IWTConfiguration.Conf.SetConf(Constants.NFE_IMPRIMIR_DANFE_HABILITADO + complementoConfiguracoes, Convert.ToInt16(emitente.DadosSalvarEnviarNfe.ImprimirDanfeHabilitado).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NFE_IMPRIMIR_DANFE_IMPRESSORA_1 + complementoConfiguracoes, emitente.DadosSalvarEnviarNfe.ImprimirDanfeImpressora1, LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NFE_IMPRIMIR_DANFE_IMPRESSORA_2 + complementoConfiguracoes,emitente.DadosSalvarEnviarNfe.ImprimirDanfeImpressora2, LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NFE_ENVIO_EMAIL_HABILITADO + complementoConfiguracoes, Convert.ToInt16(emitente.DadosSalvarEnviarNfe.EnvioEmailHabilitado).ToString(),LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NFE_ENVIO_EMAIL_XML_HABILITADO + complementoConfiguracoes, Convert.ToInt16(emitente.DadosSalvarEnviarNfe.EnvioEmailXmlHhabilitado).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NFE_ENVIO_EMAIL_XML_DESTINO + complementoConfiguracoes,emitente.DadosSalvarEnviarNfe.EnvioEmailXmlDestino, LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NFE_ENVIO_EMAIL_DANFE_HABILITADO + complementoConfiguracoes, Convert.ToInt16(emitente.DadosSalvarEnviarNfe.EnvioEmailDanfeHabilitado).ToString(),LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NFE_ENVIO_EMAIL_DANFE_DESTINO + complementoConfiguracoes, emitente.DadosSalvarEnviarNfe.EnvioEmailDanfeDestino, LoginClass.UsuarioLogado.loggedUser.Login);

            IWTConfiguration.Conf.SetConf(Constants.NFE_ENVIO_EMAIL_CLIENTE_HABILITADO + complementoConfiguracoes, Convert.ToInt16(emitente.DadosSalvarEnviarNfe.EnvioEmailClienteHabilitado).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NFE_ENVIO_EMAIL_REMETENTE + complementoConfiguracoes, emitente.DadosSalvarEnviarNfe.EnvioEmailRemetente, LoginClass.UsuarioLogado.loggedUser.Login);


            IWTConfiguration.Conf.SetConf(Constants.NFE_SALVAR_PASTA_HABILITADO + complementoConfiguracoes, Convert.ToInt16(emitente.DadosSalvarEnviarNfe.SalvarPastaHabilitado).ToString(),LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NFE_SALVAR_PASTA_DANFE + complementoConfiguracoes,emitente.DadosSalvarEnviarNfe.SalvarPastaDanfe ,LoginClass.UsuarioLogado.loggedUser.Login);
            IWTConfiguration.Conf.SetConf(Constants.NFE_SALVAR_PASTA_XML + complementoConfiguracoes,emitente.DadosSalvarEnviarNfe.SalvarPastaXml, LoginClass.UsuarioLogado.loggedUser.Login);



            IWTConfiguration.Conf.RefreshConfs();
        }

        public static bool VerificaSituacaoServicosReceita(Ambiente AmbienteEmissaoNFe, string siglaUfEmitente, string serialCertificado, out string retornoDetalhado)
        {
           
            SituacaoServico situacaoServicoNormal = NFeOperacoes.SituacaoServico(FuncoesAuxiliares.Sigla2TCodUfIBGE(siglaUfEmitente), AmbienteEmissaoNFe == Ambiente.Homologacao ? TAmb.Homologacao : TAmb.Producao,
                                                                                 serialCertificado, out retornoDetalhado, false, TMod.Item55);
            if (situacaoServicoNormal != SituacaoServico.EmOperacao)
            {
                string retornoDetalhadoScan;
                if (
                    NFeOperacoes.SituacaoServico(FuncoesAuxiliares.Sigla2TCodUfIBGE(siglaUfEmitente), AmbienteEmissaoNFe == Ambiente.Homologacao ? TAmb.Homologacao : TAmb.Producao, serialCertificado,
                                                 out retornoDetalhadoScan, true, TMod.Item55) == SituacaoServico.EmOperacao)
                {
                    string mensagem = "O serviço de envio de nota fiscal está desativado no momento com o status " + retornoDetalhado + ", deseja enviar em ambiente de contingência (SVC)?";
                    DialogResult result = MessageBox.Show(null, mensagem, "SCAN", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    retornoDetalhado = "O serviço de envio de nota fiscal está desativado no momento com o status " + retornoDetalhado + " e o envio em contingência também está desativado com o status " + retornoDetalhadoScan + ".";
                    return false;
                }
            }
            return true;
        }

        public static void DesfazerEmissaoNFeFaturamentoEnvioServicoExterno(OrdemProducaoEnvioTerceirosClass opEnvio, NfPrincipalClass nota, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command)
        {
            try
            {
                LogClass.EscreverLog("TratamentoRejeicaoFaturamentoEnvioServicoExterno:" + opEnvio.ID + "-" + nota.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
            }
            catch
            {
            }

            if (opEnvio.CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Count > 0)
            {
                throw new ExcecaoTratada("Não é possível desfazer um faturamento de serviço externo depois que um recebimento foi realizado");
            }

            opEnvio.Delete(ref command);

        }
    }


    internal class EstornarBaixasEstoqueAuxiliarClass : IEquatable<EstornarBaixasEstoqueAuxiliarClass>
    {
        public string Oc { get; internal set; }
        public int Pos { get; internal set; }
        public int IdCliente { get; internal set; }

        public bool Equals(EstornarBaixasEstoqueAuxiliarClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Oc, Oc) && other.Pos == Pos && other.IdCliente == IdCliente;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (EstornarBaixasEstoqueAuxiliarClass)) return false;
            return Equals((EstornarBaixasEstoqueAuxiliarClass) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Oc != null ? Oc.GetHashCode() : 0);
                result = (result*397) ^ Pos;
                result = (result*397) ^ IdCliente;
                return result;
            }
        }

        public static bool operator ==(EstornarBaixasEstoqueAuxiliarClass left, EstornarBaixasEstoqueAuxiliarClass right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EstornarBaixasEstoqueAuxiliarClass left, EstornarBaixasEstoqueAuxiliarClass right)
        {
            return !Equals(left, right);
        }
    }
}
