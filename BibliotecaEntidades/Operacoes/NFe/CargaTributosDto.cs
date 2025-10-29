using System;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaTributos;
using Configurations;
using IWTDotNetLib;
using IWTNF.Entidades.Base;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaEntidades.Operacoes.NFe
{
    public class CargaTributosDto
    {
        public bool TributacaoOperacao { get; private set; }

        public IncidenciaImposto CofinsIncide { get; private set; }
        public IncidenciaImposto? DevolucaoMaterialCofinsIncide { get; private set; }
        public IncidenciaImposto? DevolucaoMaterialIcmsIncide { get; private set; }
        public IncidenciaImposto? DevolucaoMaterialPisIncide { get; private set; }
        public IncidenciaImposto IcmsIncide { get; private set; }
        public IncidenciaImposto PisIncide { get; private set; }
        public IncidenciaIPI? DevolucaoMaterialIpiIncide { get; private set; }
        public IncidenciaImposto IpiIncide { get; private set; }
        
        public bool CofinsImpostoRetido { get; private set; }
        public bool ConsumidorFinal { get; private set; }
        public bool DevolucaoMaterial { get; private set; }
        public bool DevolucaoMaterialCofinsImpostoRetido { get; private set; }
        public bool DevolucaoMaterialIcmsPartilha { get; private set; }
        public bool DevolucaoMaterialIcmsReducaoBc { get; private set; }
        public bool DevolucaoMaterialIcmsSomaFreteBc { get; private set; }
        public bool DevolucaoMaterialPisImpostoRetido { get; private set; }
        public bool EntregaFutura { get; private set; }
        public bool GerarContasReceber { get; private set; }
        public bool IcmsPartilha { get; private set; }
        public bool IcmsReducaoBc { get; private set; }
        public bool IcmsSomaFreteBc { get; private set; }
        public bool PisImpostoRetido { get; private set; }
        public EasiValidaPrecos ValidaPrecos { get; private set; }
        public double CofinsAliquota { get; private set; }
        public double DevolucaoMaterialCofinsAliquota { get; private set; }
        public double DevolucaoMaterialIcmsAliquotaCredito { get; private set; }
        public double DevolucaoMaterialIcmsMvaSt { get; private set; }
        public double DevolucaoMaterialIcmsPercentualBcOperacaoPropria { get; private set; }
        public double DevolucaoMaterialIcmsPercentualDiferimento { get; private set; }
        public double DevolucaoMaterialIcmsPercentualReducaoBc { get; private set; }
        public double DevolucaoMaterialIcmsPercentualReducaoBcSt { get; private set; }
        public double DevolucaoMaterialIpiAliquota { get; private set; }
        public double DevolucaoMaterialPisAliquota { get; private set; }
        public double IcmsAliquotaCredito { get; private set; }
        public double IcmsMvaSt { get; private set; }
        public double IcmsPercentualBcOperacaoPropria { get; private set; }
        public double IcmsPercentualDiferimento { get; private set; }
        public double IcmsPercentualReducaoBc { get; private set; }
        public double IcmsPercentualReducaoBcSt { get; private set; }
        public double IpiAliquota { get; private set; }
        public double PisAliquota { get; private set; }
        public int Cfop { get; private set; }
        public int? DevolucaoMaterialCfop { get; private set; }
        public int? EntregaFuturaCfopRemessa { get; private set; }
        public short CofinsModTributacao { get; private set; }
        public short DevolucaoMaterialCofinsModTributacao { get; private set; }
        public short DevolucaoMaterialIcmsModDetBc { get; private set; }
        public short DevolucaoMaterialIcmsModDetBcSt { get; private set; }
        public short DevolucaoMaterialIpiModTributacao { get; private set; }
        public short DevolucaoMaterialPisModTributacao { get; private set; }
        public short IcmsModDetBc { get; private set; }
        public short IcmsModDetBcSt { get; private set; }
        public short IpiModTributacao { get; private set; }
        public short PisModTributacao { get; private set; }
        public IWTNF.Entidades.Base.PresencaComprador PresencaConsumidor { get; private set; }
        public string CofinsCst { get; private set; }
        public string DevolucaoMaterialCofinsCst { get; private set; }
        public string DevolucaoMaterialIcmsCst { get; private set; }
        public string DevolucaoMaterialIcmsObservacaoDiferimento { get; private set; }
        public string DevolucaoMaterialIpiCodEnquadramento { get; private set; }
        public string DevolucaoMaterialIpiCst { get; private set; }
        public string DevolucaoMaterialPisCst { get; private set; }
        public string EntregaFuturaNaturezaOperacaoRemessa { get; private set; }
        public string IcmsCst { get; private set; }
        public string IcmsObservacaoDiferimento { get; private set; }
        public string IpiCodEnquadramento { get; private set; }
        public string IpiCst { get; private set; }
        public string NaturezaOperacao { get; private set; }
        
        public string PisCst { get; private set; }



        public string DevolucaoMaterialIcmsObsevacaoCredito { get; private set; }
        public string IcmsObsevacaoCredito { get; private set; }

        public short? IcmsMotivoDesoneracao { get; set; }
        public short? DevolucaoMaterialIcmsMotivoDesoneracao { get; set; }

        public bool IpiSomaFreteBc { get; private set; }

        public bool DevolucaoMaterialIpiSomaFreteBc { get; private set; }


        //Calculados


        public double IcmsAliquota { get; private set; }
        public double IcmsAliquotaSt { get; private set; }
        public int? IcmsCsoSimples { get; private set; }
        public double DevolucaoMaterialIcmsAliquota { get; private set; }
        public double DevolucaoMaterialIcmsAliquotaSt { get; private set; }
        public int? DevolucaoMaterialIcmsCsoSimples { get; private set; }




        public static CargaTributosDto CarregaTributos(PedidoItemClass pedidoItem, long idUfEmissor, ref IWTPostgreNpgsqlCommand command, PisCofinsInfo pisCofinsInfo)
        {
            try
            {

                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    if (pedidoItem.OperacaoCompleta == null)
                    {
                        throw new ExcecaoTratada("O pedido " + pedidoItem + " não pode ser faturado pois não possui operação vinculada");
                    }


                    return CarregaTritutosOperacaoCompleta(pedidoItem.Produto, pedidoItem.OperacaoCompleta, idUfEmissor, pedidoItem.Cliente.EstadoCob);
                }
                else
                {
                    if (pedidoItem.Operacao == null)
                    {
                        throw new ExcecaoTratada("O pedido " + pedidoItem + " não pode ser faturado pois não possui operação vinculada");
                    }

                    return CarregaTritutosModeloFiscal(pedidoItem.Produto, pedidoItem.Operacao, idUfEmissor,ref command, pisCofinsInfo,pedidoItem.Cliente.EstadoCob);
                }

            }
            catch (ExcecaoTratada a)
            {
                throw a;
            }
            catch (Exception a)
            {
                throw new Exception("Erro inesperado ao carregar os tributos para o faturamento. "+a.Message);
            }


        }


        public static CargaTributosDto CarregaTributosEnvioTerceiros(PedidoItemClass pedidoItem, long idUfEmissor, ref IWTPostgreNpgsqlCommand command, PisCofinsInfo pisCofinsInfo)
        {
            try
            {
                if (!pedidoItem.EnvioTerceiros)
                {
                    throw new ExcecaoTratada("Não é possível carregar os tributos para envio para terceiros pois o pedido " + pedidoItem + " não tem essa configuração");

                }



                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    if (pedidoItem.OperacaoCompletaEnvioTerceiros == null)
                    {
                        throw new ExcecaoTratada("O pedido " + pedidoItem + " não pode ser faturado para envio para terceiros pois não possui operação vinculada");
                    }


                    return CarregaTritutosOperacaoCompleta(pedidoItem.Produto, pedidoItem.OperacaoCompletaEnvioTerceiros, idUfEmissor, pedidoItem.ClienteEnvioTerceiros.EstadoCob);
                }
                else
                {
                    if (pedidoItem.OperacaoEnvioTerceiros == null)
                    {
                        throw new ExcecaoTratada("O pedido " + pedidoItem + " não pode ser faturado para envio para terceiros pois não possui operação vinculada");
                    }

                    return CarregaTritutosModeloFiscal(pedidoItem.Produto, pedidoItem.OperacaoEnvioTerceiros, idUfEmissor, ref command, pisCofinsInfo, pedidoItem.ClienteEnvioTerceiros.EstadoCob);
                }

            }
            catch (ExcecaoTratada a)
            {
                throw a;
            }
            catch (Exception a)
            {
                throw new Exception("Erro inesperado ao carregar os tributos para o faturamento de envio para terceiros. " + a.Message);
            }


        }



        public static CargaTributosDto CarregaTributos(FaturamentoRemessaDto faturamentoRemessaDto, long idUfEmissor, ref IWTPostgreNpgsqlCommand command, PisCofinsInfo pisCofinsInfo)
        {
            try
            {

                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    if (faturamentoRemessaDto.OperacaoCompleta == null)
                    {
                        throw new ExcecaoTratada("A OP " + faturamentoRemessaDto.OrdemProducao + " não pode ser faturada pois não possui operação vinculada");
                    }


                    return CarregaTritutosOperacaoCompleta(faturamentoRemessaDto.OrdemProducao.Produto, faturamentoRemessaDto.OperacaoCompleta, idUfEmissor, faturamentoRemessaDto.Fornecedor.Estado);
                }
                else
                {
                    if (faturamentoRemessaDto.Operacao == null)
                    {
                        throw new ExcecaoTratada("A OP " + faturamentoRemessaDto.OrdemProducao + " não pode ser faturada pois não possui operação vinculada");
                    }

                    return CarregaTritutosModeloFiscal(faturamentoRemessaDto.OrdemProducao.Produto, faturamentoRemessaDto.Operacao, idUfEmissor, ref command, pisCofinsInfo, faturamentoRemessaDto.Fornecedor.Estado);
                }

            }
            catch (ExcecaoTratada a)
            {
                throw a;
            }
            catch (Exception a)
            {
                throw new Exception("Erro inesperado ao carregar os tributos para o faturamento. " + a.Message);
            }


        }



        private static CargaTributosDto CarregaTritutosModeloFiscal(ProdutoClass produto, OperacaoClass operacao, long idUfEmissor, ref IWTPostgreNpgsqlCommand command, PisCofinsInfo pisCofinsDefault, EstadoClass estadoDestino)
        {

            string prefixo = "";
            string prefixo2 = "";

            long idProduto =produto.ID;

          
            CargaTributosDto toRet = new CargaTributosDto();

            bool dentroEstado = idUfEmissor == estadoDestino.ID;




            toRet.ConsumidorFinal = operacao.ConsumidorFinal;
            toRet.EntregaFutura = operacao.EntregaFutura;
            toRet.EntregaFuturaCfopRemessa = dentroEstado ? operacao.EntregaFuturaCfopRemessa : operacao.EntregaFuturaCfopRemessaForaEstado;
            toRet.EntregaFuturaNaturezaOperacaoRemessa = operacao.EntregaFuturaNaturezaOperacaoRemessa;
            toRet.GerarContasReceber = operacao.GerarContasReceber;
            toRet.NaturezaOperacao = operacao.NaturezaOperacao;
            toRet.PresencaConsumidor = (IWTNF.Entidades.Base.PresencaComprador)Enum.Parse(typeof(IWTNF.Entidades.Base.PresencaComprador), Convert.ToInt16(operacao.PresencaConsumidor).ToString());
            toRet.TributacaoOperacao = false;
            toRet.ValidaPrecos = operacao.ValidaPrecos;
            toRet.IcmsSomaFreteBc = operacao.SomaFreteBcIcms;
            toRet.IpiSomaFreteBc = operacao.SomaFreteBcIpi;
            toRet.IcmsPartilha = operacao.PartilhaIcms;


            command.CommandText =
                "SELECT * " +
                "FROM " +
                "  public.produto_fiscal " +
                "  INNER JOIN produto ON produto_fiscal.id_produto = produto.id_produto " +
                "  INNER JOIN public.modelo_fiscal_icms ON (public.produto_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms.id_modelo_fiscal_icms) " +
                "  INNER JOIN public.ncm ON (public.produto_fiscal.id_ncm = public.ncm.id_ncm) " +
                "  LEFT OUTER JOIN " +
                "        ( " +
                "            SELECT * " +
                "                FROM public.ncm_beneficio_fiscal " +
                "            WHERE public.ncm_beneficio_fiscal.nbf_cfop = " + (dentroEstado ? operacao.Cfop : operacao.CfopForaEstado) + " AND " +
                "        public.ncm_beneficio_fiscal.id_estado = " + estadoDestino.ID + " " +
                "        ) as benefFiscal ON(public.ncm.id_ncm = benefFiscal.id_ncm) " +
                "WHERE " +
                "  public.produto_fiscal.id_produto = " + idProduto + "";

            prefixo = "prf";
            prefixo2 = "pro";

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

            if (read.HasRows)
            {
                read.Read();



                toRet.Cfop = dentroEstado ? operacao.Cfop : operacao.CfopForaEstado;

                toRet.DevolucaoMaterial = operacao.DevolucaoMaterial;
                toRet.DevolucaoMaterialCfop = dentroEstado ? operacao.DevolucaoMaterialCfop : operacao.DevolucaoMaterialCfopForaEstado;
                toRet.DevolucaoMaterialIcmsIncide = operacao.DevolucaoMaterialIncideIcms;
                toRet.DevolucaoMaterialIcmsCst = operacao.DevolucaoMaterialIcmsCstSuspenso;
                toRet.DevolucaoMaterialIpiIncide = (IncidenciaIPI?) Enum.ToObject(typeof(IncidenciaIPI),Convert.ToInt16(operacao.DevolucaoMaterialIncideIpi));
                toRet.DevolucaoMaterialIpiCst = operacao.DevolucaoMaterialIpiCstSuspenso;
                toRet.DevolucaoMaterialCofinsIncide = operacao.DevolucaoMaterialIncideCofins;
                toRet.DevolucaoMaterialCofinsCst = operacao.DevolucaoMaterialCofinsCstSuspenso;
                toRet.DevolucaoMaterialPisIncide = operacao.DevolucaoMaterialIncidePis;
                toRet.DevolucaoMaterialPisCst = operacao.DevolucaoMaterialPisCstSuspenso;
                



                string idModeloFiscalICMS = read["id_modelo_fiscal_icms"].ToString();


                //PIS
                if (read[prefixo + "_pis"].ToString() == "1")
                {
                    toRet.PisAliquota = Convert.ToDouble(read[prefixo + "_pis_aliquota"]);
                    toRet.PisCst = read[prefixo + "_pis_cst"].ToString();
                    toRet.PisImpostoRetido = Convert.ToBoolean(Convert.ToInt16(read[prefixo + "_pis_imposto_retido"]));
                    toRet.PisIncide = operacao.IncidePis;
                    toRet.PisModTributacao = Convert.ToInt16(read[prefixo + "_pis_modalidade_tributacao"]);

                    
                }
                else
                {
                    //Usa o default do sistema

                    toRet.PisAliquota = pisCofinsDefault.PisAliquota;
                    toRet.PisCst = pisCofinsDefault.PisCST;
                    toRet.PisImpostoRetido = Convert.ToBoolean(Convert.ToInt16(pisCofinsDefault.PisImpostoRetido));
                    toRet.PisIncide = operacao.IncidePis;
                    toRet.PisModTributacao = Convert.ToInt16(pisCofinsDefault.PisModalidadeTributacao);
                }


                if (toRet.PisIncide == IncidenciaImposto.Suspenso)
                {
                    toRet.PisCst = operacao.PisCstSuspenso;
                    toRet.PisModTributacao = Convert.ToInt16(ModalidadeTributacao.NaoTributado);
                }



                //COFINS
                if (read[prefixo + "_cofins"].ToString() == "1")
                {

                    toRet.CofinsAliquota = Convert.ToDouble(read[prefixo + "_cofins_aliquota"]);
                    toRet.CofinsCst = read[prefixo + "_cofins_cst"].ToString();
                    toRet.CofinsImpostoRetido = Convert.ToBoolean(Convert.ToInt16(read[prefixo + "_cofins_imposto_retido"]));
                    toRet.CofinsIncide = operacao.IncideCofins;
                    toRet.CofinsModTributacao = Convert.ToInt16(read[prefixo + "_cofins_modalidade_tributacao"]);
                    
                }
                else
                {
                    //Usa o default do sistema

                    toRet.CofinsAliquota = pisCofinsDefault.CofinsAliquota;
                    toRet.CofinsCst = pisCofinsDefault.CofinsCST;
                    toRet.CofinsImpostoRetido = Convert.ToBoolean(Convert.ToInt16(pisCofinsDefault.CofinsImpostoRetido));
                    toRet.CofinsIncide = operacao.IncideCofins;
                    toRet.CofinsModTributacao = Convert.ToInt16(pisCofinsDefault.CofinsModalidadeTributacao);
                }

                if (toRet.CofinsIncide == IncidenciaImposto.Suspenso)
                {
                    toRet.CofinsCst = operacao.CofinsCstSuspenso;
                    toRet.CofinsModTributacao = Convert.ToInt16(ModalidadeTributacao.NaoTributado);
                }

                //IPI


                toRet.IpiAliquota = Convert.ToDouble(read["ncm_ipi_aliquota"]);
                toRet.IpiCodEnquadramento = read["ncm_ipi_codigo_enquadramento"].ToString(); 
                toRet.IpiCst = read["ncm_ipi_cst"].ToString();
                toRet.IpiIncide = operacao.IncideIpi;
                toRet.IpiModTributacao = Convert.ToInt16(read["ncm_ipi_modalidade_tributacao"]);

                if (toRet.IpiIncide == IncidenciaImposto.Suspenso)
                {
                    toRet.IpiCst = operacao.IpiCstSuspenso;
                    toRet.IpiModTributacao = Convert.ToInt16(ModalidadeTributacao.NaoTributado);
                }

                toRet.DevolucaoMaterialIpiCodEnquadramento = toRet.IpiCodEnquadramento;

                //ICMS

                
                toRet.IcmsIncide = operacao.IncideIcms;
                toRet.IcmsCst = read["mfi_cst"].ToString();
                
                if (toRet.IcmsIncide == IncidenciaImposto.Suspenso)
                {
                    toRet.IcmsCst = operacao.IcmsCstSuspenso;
                }



                toRet.IcmsModDetBc = Convert.ToInt16(read["mfi_modalidade_determinacao_bc"] == DBNull.Value ? 0 : read["mfi_modalidade_determinacao_bc"]);
                toRet.IcmsModDetBcSt = Convert.ToInt16(read["mfi_modalidade_determinicao_bc_st"] == DBNull.Value ? 0 : read["mfi_modalidade_determinicao_bc_st"]);

                toRet.IcmsMvaSt = Convert.ToDouble("0" + read["mfi_percentual_mva_st"]);
                toRet.IcmsObservacaoDiferimento = read["mfi_obs_diferimento"].ToString();
                


                toRet.IcmsPercentualBcOperacaoPropria = Convert.ToDouble(read["mfi_percentual_bc_propria"] == DBNull.Value ? 0: read["mfi_percentual_bc_propria"]);
                toRet.IcmsPercentualDiferimento = Convert.ToDouble(read["mfi_percentual_diferimento"] == DBNull.Value ? 0 : read["mfi_percentual_diferimento"]);
                toRet.IcmsPercentualReducaoBc = Convert.ToDouble(read["mfi_percentual_reducao_bc"] == DBNull.Value ? 0 : read["mfi_percentual_reducao_bc"]);
                toRet.IcmsPercentualReducaoBcSt = Convert.ToDouble(read["mfi_percentual_reducao_bc_st"] == DBNull.Value ? 0 : read["mfi_percentual_reducao_bc_st"]);
                toRet.IcmsReducaoBc = Convert.ToBoolean(Convert.ToInt16(read["mfi_reducao_bc"]));

                bool st = Convert.ToInt16(read["mfi_st"]) == 1 || Convert.ToInt16(read["mfi_st"]) == 2;
                
                switch (toRet.IcmsCst)
                {
                    case "101":
                    case "102":
                    case "103":
                    case "201":
                    case "202":
                    case "203":
                    case "300":
                    case "400":
                    case "500":
                    case "900":
                        toRet.IcmsCsoSimples = int.Parse(toRet.IcmsCst);
                        toRet.IcmsCst = "SN";
                        break;
                }

                if (read["mfi_aliquota_credito"] != DBNull.Value)
                {

                    toRet.IcmsAliquotaCredito = Convert.ToDouble(read["mfi_aliquota_credito"]);
                    toRet.IcmsObsevacaoCredito= read["mfi_observacao_credito_icms"].ToString();
                }

                read.Close();

                //Aliquota ICMS do estado do emissor
                command.CommandText =
                    "SELECT  " +
                    "  public.modelo_fiscal_icms_estado.mfe_aliquota " +
                    "FROM " +
                    "  public.modelo_fiscal_icms_estado  " +
                    "WHERE " +
                    "  public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms = " + idModeloFiscalICMS + " AND " +
                    "  public.modelo_fiscal_icms_estado.id_estado=" + idUfEmissor;

                read = command.ExecuteReader();
                read.Read();
                double icmsAliquotaEstadoEmissor = Convert.ToDouble(read["mfe_aliquota"]);
                read.Close();
               
                    command.CommandText =
                        "SELECT  " +
                        "  public.modelo_fiscal_icms_estado.mfe_aliquota " +
                        "FROM " +
                        "  estado  " +
                        "  INNER JOIN public.modelo_fiscal_icms_estado ON (public.estado.id_estado = public.modelo_fiscal_icms_estado.id_estado) " +
                        "WHERE " +
                        "  public.estado.id_estado  = " + estadoDestino.ID + " AND " +
                        "  public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms = " + idModeloFiscalICMS + "";
               

                read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    if (st)
                    {
                        //Carrega a aliquota dentro do estado para complementar as infos

                        toRet.IcmsAliquotaSt = icmsAliquotaEstadoEmissor;
                        toRet.IcmsAliquota = Convert.ToDouble(read["mfe_aliquota"]);
                    }
                    else
                    {
                        toRet.IcmsAliquota = Convert.ToDouble(read["mfe_aliquota"]);
                    }

                    read.Close();
                }
                else
                {
                    throw new Exception("Erro ao identificar a aliquota do ICMS, verifique o cadastro das aliquotas e do cliente.");
                }

            }
            else
            {
                throw new Exception("Cadastro fiscal do item " + produto.CodigoCliente + " inválido. Verifique o cadastro.");
            }


            return toRet;
        }

        private static CargaTributosDto CarregaTritutosOperacaoCompleta(ProdutoClass produto,OperacaoCompletaClass operacao, long idUfEmissor, EstadoClass estadoDestino)
        {
            try
            {

             
                

                CargaTributosDto toRet = new CargaTributosDto() ;

                bool dentroEstado = idUfEmissor == estadoDestino.ID;



                toRet.IcmsObsevacaoCredito = operacao.IcmsObservacaoCredito;
                toRet.DevolucaoMaterialIcmsObsevacaoCredito = operacao.DevolucaoMaterialIcmsObservacaoCredito;
                



                toRet.Cfop =dentroEstado ? operacao.Cfop : operacao.CfopForaEstado;
                
                toRet.CofinsAliquota = operacao.CofinsAliquota;
                toRet.CofinsCst = operacao.CofinsCst;
                toRet.CofinsImpostoRetido = operacao.CofinsImpostoRetido;
                toRet.CofinsIncide = operacao.CofinsIncide;
                toRet.CofinsModTributacao = operacao.CofinsModTributacao;
                toRet.ConsumidorFinal = operacao.ConsumidorFinal;

                
                toRet.DevolucaoMaterial = operacao.DevolucaoMaterial;
                toRet.DevolucaoMaterialCfop = dentroEstado ? operacao.DevolucaoMaterialCfop : operacao.DevolucaoMaterialCfopForaEstado;
                toRet.DevolucaoMaterialCofinsAliquota = operacao.DevolucaoMaterialCofinsAliquota;
                toRet.DevolucaoMaterialCofinsCst = operacao.DevolucaoMaterialCofinsCst;
                toRet.DevolucaoMaterialCofinsImpostoRetido = operacao.DevolucaoMaterialCofinsImpostoRetido;
                toRet.DevolucaoMaterialCofinsIncide = operacao.DevolucaoMaterialCofinsIncide;
                toRet.DevolucaoMaterialCofinsModTributacao = operacao.DevolucaoMaterialCofinsModTributacao;

                toRet.DevolucaoMaterialIcmsAliquotaCredito = operacao.DevolucaoMaterialIcmsAliquotaCredito;
        
                toRet.DevolucaoMaterialIcmsCst = operacao.DevolucaoMaterialIcmsCst;
                toRet.DevolucaoMaterialIcmsIncide = operacao.DevolucaoMaterialIcmsIncide;
                toRet.DevolucaoMaterialIcmsModDetBc = operacao.DevolucaoMaterialIcmsModDetBc;
                toRet.DevolucaoMaterialIcmsModDetBcSt = operacao.DevolucaoMaterialIcmsModDetBcSt;

                toRet.DevolucaoMaterialIcmsObservacaoDiferimento = operacao.DevolucaoMaterialIcmsObservacaoDiferimento;
                
                toRet.DevolucaoMaterialIcmsPartilha = operacao.DevolucaoMaterialIcmsPartilha;
                toRet.DevolucaoMaterialIcmsPercentualBcOperacaoPropria = operacao.DevolucaoMaterialIcmsPercentualBcOperacaoPropria;
                toRet.DevolucaoMaterialIcmsPercentualDiferimento = operacao.DevolucaoMaterialIcmsPercentualDiferimento;
                toRet.DevolucaoMaterialIcmsPercentualReducaoBc = operacao.DevolucaoMaterialIcmsPercentualReducaoBc;
                toRet.DevolucaoMaterialIcmsPercentualReducaoBcSt = operacao.DevolucaoMaterialIcmsPercentualReducaoBcSt;
                toRet.DevolucaoMaterialIcmsReducaoBc = operacao.DevolucaoMaterialIcmsReducaoBc;
                toRet.DevolucaoMaterialIcmsSomaFreteBc = operacao.DevolucaoMaterialIcmsSomaFreteBc;


                if (operacao.DevolucaoMaterialIpiIncide == IncidenciaIPI.UtilizaDadosProdutoNcm)
                {
                    if (!produto.CollectionProdutoFiscalClassProduto.Any())
                    {
                        throw new ExcecaoTratada("Produto fiscal não cadastrado para o item " + produto);
                    }

                    ProdutoFiscalClass prf = produto.CollectionProdutoFiscalClassProduto.First();

                    toRet.DevolucaoMaterialIpiAliquota = prf.Ncm.IpiAliquota;
                    toRet.DevolucaoMaterialIpiCodEnquadramento = prf.Ncm.IpiCodigoEnquadramento;
                    toRet.DevolucaoMaterialIpiCst = prf.Ncm.IpiCst;
                    toRet.DevolucaoMaterialIpiIncide = operacao.DevolucaoMaterialIpiIncide;
                    toRet.DevolucaoMaterialIpiModTributacao = (short)prf.Ncm.IpiModalidadeTributacao;
                }

                else
                {
                    toRet.DevolucaoMaterialIpiAliquota = operacao.DevolucaoMaterialIpiAliquota;
                    toRet.DevolucaoMaterialIpiCodEnquadramento = operacao.DevolucaoMaterialIpiCodEnquadramento;
                    toRet.DevolucaoMaterialIpiCst = operacao.DevolucaoMaterialIpiCst;
                    toRet.DevolucaoMaterialIpiIncide = operacao.DevolucaoMaterialIpiIncide;
                    toRet.DevolucaoMaterialIpiModTributacao = operacao.DevolucaoMaterialIpiModTributacao;
                }

              




                toRet.DevolucaoMaterialPisAliquota = operacao.DevolucaoMaterialPisAliquota;
                toRet.DevolucaoMaterialPisCst = operacao.DevolucaoMaterialPisCst;
                toRet.DevolucaoMaterialPisImpostoRetido = operacao.DevolucaoMaterialPisImpostoRetido;
                toRet.DevolucaoMaterialPisIncide = operacao.DevolucaoMaterialPisIncide;
                toRet.DevolucaoMaterialPisModTributacao = operacao.DevolucaoMaterialPisModTributacao;
                

                toRet.EntregaFutura = operacao.EntregaFutura;
                toRet.EntregaFuturaCfopRemessa = dentroEstado? operacao.EntregaFuturaCfopRemessa: operacao.EntregaFuturaCfopRemessaForaEstado;
                toRet.EntregaFuturaNaturezaOperacaoRemessa = operacao.EntregaFuturaNaturezaOperacaoRemessa;
        

                toRet.GerarContasReceber = operacao.GerarContasReceber;
                toRet.IcmsAliquotaCredito = operacao.IcmsAliquotaCredito;
                toRet.IcmsCst = operacao.IcmsCst;
                toRet.IcmsIncide = operacao.IcmsIncide;
                toRet.IcmsModDetBc = operacao.IcmsModDetBc;
                toRet.IcmsModDetBcSt = operacao.IcmsModDetBcSt;





                toRet.IcmsObservacaoDiferimento = operacao.IcmsObservacaoDiferimento;
                toRet.IcmsPartilha = operacao.IcmsPartilha;


                toRet.IcmsPercentualBcOperacaoPropria = operacao.IcmsPercentualBcOperacaoPropria;
                toRet.IcmsPercentualDiferimento = operacao.IcmsPercentualDiferimento;
                toRet.IcmsPercentualReducaoBc = operacao.IcmsPercentualReducaoBc;
                toRet.IcmsPercentualReducaoBcSt = operacao.IcmsPercentualReducaoBcSt;
                toRet.IcmsReducaoBc = operacao.IcmsReducaoBc;
                toRet.IcmsSomaFreteBc = operacao.IcmsSomaFreteBc;



                if (operacao.IpiIncide == IncidenciaIPI.UtilizaDadosProdutoNcm)
                {
                    if (!produto.CollectionProdutoFiscalClassProduto.Any())
                    {
                        throw new ExcecaoTratada("Produto fiscal não cadastrado para o item "+ produto);
                    }

                    ProdutoFiscalClass prf = produto.CollectionProdutoFiscalClassProduto.First();

                    toRet.IpiAliquota = prf.Ncm.IpiAliquota;
                    toRet.IpiCodEnquadramento = prf.Ncm.IpiCodigoEnquadramento;
                    toRet.IpiCst = prf.Ncm.IpiCst;
                    toRet.IpiIncide = IncidenciaImposto.Incide;
                    toRet.IpiModTributacao =  (short) prf.Ncm.IpiModalidadeTributacao;
                }

                else
                {
                    toRet.IpiAliquota = operacao.IpiAliquota;
                    toRet.IpiCodEnquadramento = operacao.IpiCodEnquadramento;
                    toRet.IpiCst = operacao.IpiCst;
                    toRet.IpiIncide = (IncidenciaImposto) Enum.ToObject(typeof(IncidenciaImposto), Convert.ToInt16(operacao.IpiIncide));
                    toRet.IpiModTributacao = operacao.IpiModTributacao;
                }

                toRet.NaturezaOperacao = operacao.NaturezaOperacao;
                toRet.PisAliquota = operacao.PisAliquota;
                toRet.PisCst = operacao.PisCst;
                toRet.PisImpostoRetido = operacao.PisImpostoRetido;
                toRet.PisIncide = operacao.PisIncide;
                toRet.PisModTributacao = operacao.PisModTributacao;
                toRet.PresencaConsumidor = (IWTNF.Entidades.Base.PresencaComprador)Enum.Parse(typeof(IWTNF.Entidades.Base.PresencaComprador),Convert.ToInt16(operacao.PresencaConsumidor).ToString());
                toRet.TributacaoOperacao = true;
                toRet.ValidaPrecos = operacao.ValidaPrecos;


                switch (toRet.DevolucaoMaterialIcmsCst)
                {
                    case "101":
                    case "102":
                    case "103":
                    case "201":
                    case "202":
                    case "203":
                    case "300":
                    case "400":
                    case "500":
                    case "900":
                        toRet.DevolucaoMaterialIcmsCsoSimples = int.Parse(toRet.DevolucaoMaterialIcmsCst);
                        toRet.DevolucaoMaterialIcmsCst = "SN";
                        break;
                }


                switch (toRet.IcmsCst)
                {
                    case "101":
                    case "102":
                    case "103":
                    case "201":
                    case "202":
                    case "203":
                    case "300":
                    case "400":
                    case "500":
                    case "900":
                        toRet.IcmsCsoSimples = int.Parse(toRet.IcmsCst);
                        toRet.IcmsCst = "SN";
                        break;
                }


                //Encontra a aliquota no estado do emissor
                double aliquotaEstadoEmissor = 0;
                OperacaoCompletaIcmsAliquotaClass estadoAliquotaObj = operacao.CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.FirstOrDefault(a => a.Estado.ID == idUfEmissor);
                if (estadoAliquotaObj != null)
                {
                    aliquotaEstadoEmissor = estadoAliquotaObj.Aliquota;
                }


                double aliquotaEstadoCliente = 0;
                estadoAliquotaObj = operacao.CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.FirstOrDefault(a => a.Estado.ID == estadoDestino.ID);
                if (estadoAliquotaObj != null)
                {
                    aliquotaEstadoCliente = estadoAliquotaObj.Aliquota;
                    toRet.IcmsMvaSt = estadoAliquotaObj.MvaSt;
                    toRet.DevolucaoMaterialIcmsMvaSt = estadoAliquotaObj.MvaSt;
                }

                if (operacao.IcmsSt == 1 || operacao.IcmsSt == 2)
                {
                    toRet.IcmsAliquotaSt = aliquotaEstadoEmissor;
                    toRet.IcmsAliquota = aliquotaEstadoCliente;
                }
                else
                {
                    toRet.IcmsAliquota = aliquotaEstadoCliente;
                }



                if (operacao.DevolucaoMaterialIcmsSt == 1 || operacao.DevolucaoMaterialIcmsSt == 2)
                {
                    toRet.DevolucaoMaterialIcmsAliquotaSt = aliquotaEstadoEmissor;
                    toRet.DevolucaoMaterialIcmsAliquota = aliquotaEstadoCliente;
                }
                else
                {
                    toRet.DevolucaoMaterialIcmsAliquota = aliquotaEstadoCliente;
                }



                toRet.IcmsMotivoDesoneracao = operacao.IcmsMotivoDesoneracao;
                toRet.DevolucaoMaterialIcmsMotivoDesoneracao = operacao.DevolucaoMaterialIcmsMotivoDesoneracao;

                toRet.IpiSomaFreteBc = operacao.IpiSomaFreteBc;
                toRet.DevolucaoMaterialIpiSomaFreteBc = operacao.DevolucaoMaterialIpiSomaFreteBc;

                return toRet;
            }
            catch (ExcecaoTratada a)
            {
                throw a;
            }
            catch (Exception a)
            {
                throw new Exception("Erro inesperado ao carregar os tributos pela operação completa. " + a.Message);
            }
        }

 
        public static CargaTributosDto CarregaTributosDevolucao(int? idProduto, int? idMaterial, int idCliente, long idEstadoEmissor, PisCofinsInfo pisCofinsDefault, string codigo, IWTPostgreNpgsqlCommand command, long idEstadoCob, int cfop)
        {

            string join = "INNER";
            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                join = "LEFT OUTER";
            }
            
            //Modo novo de buscar os dados, busca os dados direto do cadastro do produto ou material

                string prefixo = "";
            string prefixo2 = "";
            if (idProduto.HasValue)
            {
                command.CommandText =
                    "SELECT * " +
                    "FROM " +
                    "  public.produto_fiscal " +
                    "  INNER JOIN produto ON produto_fiscal.id_produto = produto.id_produto " +
                    "  "+join+" JOIN public.modelo_fiscal_icms ON (public.produto_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms.id_modelo_fiscal_icms) " +
                    "  INNER JOIN public.ncm ON (public.produto_fiscal.id_ncm = public.ncm.id_ncm) " +
                    "  LEFT OUTER JOIN " +
                    "        ( " +
                    "            SELECT * " +
                    "                FROM public.ncm_beneficio_fiscal " +
                    "            WHERE public.ncm_beneficio_fiscal.nbf_cfop = " + cfop + " AND " +
                    "        public.ncm_beneficio_fiscal.id_estado = " + idEstadoCob + " " +
                    "        ) as benefFiscal ON(public.ncm.id_ncm = benefFiscal.id_ncm) " +
                    "WHERE " +
                    "  public.produto_fiscal.id_produto = " + idProduto + "";

                prefixo = "prf";
                prefixo2 = "pro";
            }
            else
            {
                command.CommandText =
                    "SELECT * " +
                    "FROM " +
                    "  public.material_fiscal " +
                    "  INNER JOIN material ON material_fiscal.id_material = material.id_material " +
                    "  " + join + " JOIN public.modelo_fiscal_icms ON (public.material_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms.id_modelo_fiscal_icms) " +
                    "  INNER JOIN public.ncm ON (public.material_fiscal.id_ncm = public.ncm.id_ncm) " +
                    "  LEFT OUTER JOIN " +
                    "        ( " +
                    "            SELECT * " +
                    "                FROM public.ncm_beneficio_fiscal " +
                    "            WHERE public.ncm_beneficio_fiscal.nbf_cfop = " + cfop + " AND " +
                    "        public.ncm_beneficio_fiscal.id_estado = " + idEstadoCob + " " +
                    "        ) as benefFiscal ON(public.ncm.id_ncm = benefFiscal.id_ncm) " +
                    "WHERE " +
                    "  public.material_fiscal.id_material = " + idMaterial + "";

                prefixo = "mfs";
                prefixo2 = "mat";
            }

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

            CargaTributosDto toRet = new CargaTributosDto();
            if (read.HasRows)
            {
                read.Read();

                toRet.DevolucaoMaterial = true;
                toRet.DevolucaoMaterialCfop = cfop;
              

                string idModeloFiscalIcms = read["id_modelo_fiscal_icms"].ToString();


                //PIS
                if (read[prefixo + "_pis"].ToString() == "1")
                {
                    toRet.DevolucaoMaterialPisImpostoRetido = Convert.ToBoolean(Convert.ToInt16(read[prefixo + "_pis_imposto_retido"]));
                    toRet.DevolucaoMaterialPisModTributacao = Convert.ToInt16(read[prefixo + "_pis_modalidade_tributacao"]);
                    toRet.DevolucaoMaterialPisAliquota = Convert.ToDouble(read[prefixo + "_pis_aliquota"]);
                    toRet.DevolucaoMaterialPisCst = read[prefixo + "_pis_cst"].ToString();
                }
                else
                {
                    //Usa o default do sistema
                    toRet.DevolucaoMaterialPisImpostoRetido = Convert.ToBoolean(Convert.ToInt16(pisCofinsDefault.PisImpostoRetido));
                    toRet.DevolucaoMaterialPisModTributacao = Convert.ToInt16(pisCofinsDefault.PisModalidadeTributacao);
                    toRet.DevolucaoMaterialPisAliquota = pisCofinsDefault.PisAliquota;
                    toRet.DevolucaoMaterialPisCst = pisCofinsDefault.PisCST;
                }



                //COFINS
                if (read[prefixo + "_cofins"].ToString() == "1")
                {
                    toRet.DevolucaoMaterialCofinsImpostoRetido = Convert.ToBoolean(Convert.ToInt16(read[prefixo + "_cofins_imposto_retido"]));
                    toRet.DevolucaoMaterialCofinsModTributacao = Convert.ToInt16(read[prefixo + "_cofins_modalidade_tributacao"]);
                    toRet.DevolucaoMaterialCofinsAliquota = Convert.ToDouble(read[prefixo + "_cofins_aliquota"]);
                    toRet.DevolucaoMaterialCofinsCst = read[prefixo + "_cofins_cst"].ToString();
                }
                else
                {
                    //Usa o default do sistema
                    toRet.DevolucaoMaterialCofinsImpostoRetido = Convert.ToBoolean(Convert.ToInt16(pisCofinsDefault.CofinsImpostoRetido));
                    toRet.DevolucaoMaterialCofinsModTributacao = Convert.ToInt16(pisCofinsDefault.CofinsModalidadeTributacao);
                    toRet.DevolucaoMaterialCofinsAliquota = pisCofinsDefault.CofinsAliquota;
                    toRet.DevolucaoMaterialCofinsCst = pisCofinsDefault.CofinsCST;
                }

 
                //IPI
                toRet.DevolucaoMaterialIpiModTributacao = Convert.ToInt16(read["ncm_ipi_modalidade_tributacao"]);
                toRet.DevolucaoMaterialIpiAliquota = Convert.ToDouble(read["ncm_ipi_aliquota"]);
                toRet.DevolucaoMaterialIpiCst = read["ncm_ipi_cst"].ToString();
                toRet.DevolucaoMaterialIpiCodEnquadramento = read["ncm_ipi_codigo_enquadramento"].ToString();




                //ICMS
                toRet.DevolucaoMaterialIcmsCst = read["mfi_cst"].ToString();

                toRet.DevolucaoMaterialIcmsModDetBc = Convert.ToInt16(read["mfi_modalidade_determinacao_bc"] == DBNull.Value ? 0 : read["mfi_modalidade_determinacao_bc"]);
                toRet.DevolucaoMaterialIcmsPercentualReducaoBc = Convert.ToDouble(read["mfi_percentual_reducao_bc"] == DBNull.Value ? 0 : read["mfi_percentual_reducao_bc"]);

                toRet.DevolucaoMaterialIcmsReducaoBc = toRet.DevolucaoMaterialIcmsPercentualReducaoBc > 0;

                toRet.DevolucaoMaterialIcmsModDetBcSt = Convert.ToInt16(read["mfi_modalidade_determinicao_bc_st"] == DBNull.Value ? 0 : read["mfi_modalidade_determinicao_bc_st"]);
                toRet.DevolucaoMaterialIcmsMvaSt = Convert.ToDouble("0" + read["mfi_percentual_mva_st"]);
                toRet.DevolucaoMaterialIcmsPercentualReducaoBcSt = Convert.ToDouble("0" + read["mfi_percentual_reducao_bc_st"]);
                bool st = read["mfi_st"] != DBNull.Value && (Convert.ToInt16(read["mfi_st"]) == 1 || Convert.ToInt16(read["mfi_st"]) == 2);


                toRet.DevolucaoMaterialIcmsPercentualDiferimento = Convert.ToDouble(read["mfi_percentual_diferimento"] == DBNull.Value ? 0: read["mfi_percentual_diferimento"]);
                toRet.DevolucaoMaterialIcmsObservacaoDiferimento = read["mfi_obs_diferimento"].ToString();


                if (read["mfi_percentual_bc_propria"] != DBNull.Value)
                {
                    toRet.DevolucaoMaterialIcmsPercentualBcOperacaoPropria = Convert.ToDouble(read["mfi_percentual_bc_propria"]);
                }


                

                switch (toRet.DevolucaoMaterialIcmsCst)
                {
                    case "101":
                    case "102":
                    case "103":
                    case "201":
                    case "202":
                    case "203":
                    case "300":
                    case "400":
                    case "500":
                    case "900":
                        toRet.DevolucaoMaterialIcmsCsoSimples = int.Parse(toRet.DevolucaoMaterialIcmsCst);
                        toRet.DevolucaoMaterialIcmsCst = "SN";
                        break;
                }

                if (read["mfi_aliquota_credito"] != DBNull.Value)
                {
                    toRet.DevolucaoMaterialIcmsAliquotaCredito = Convert.ToDouble(read["mfi_aliquota_credito"]);
                    toRet.DevolucaoMaterialIcmsObsevacaoCredito = read["mfi_observacao_credito_icms"].ToString();
                }

                read.Close();

                if (!string.IsNullOrEmpty(idModeloFiscalIcms))
                {
                    //Aliquota ICMS do estado do emissor
                    command.CommandText =
                        "SELECT  " +
                        "  public.modelo_fiscal_icms_estado.mfe_aliquota " +
                        "FROM " +
                        "  public.modelo_fiscal_icms_estado  " +
                        "WHERE " +
                        "  public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms = " + idModeloFiscalIcms + " AND " +
                        "  public.modelo_fiscal_icms_estado.id_estado=" + idEstadoEmissor;

                    read = command.ExecuteReader();
                    read.Read();
                    double icmsAliquotaEstadoEmissor = Convert.ToDouble(read["mfe_aliquota"]);
                    read.Close();

                    command.CommandText =
                        "SELECT  " +
                        "  public.modelo_fiscal_icms_estado.mfe_aliquota " +
                        "FROM " +
                        "  public.cliente " +
                        "  INNER JOIN public.estado ON (public.cliente.id_estado_cob = public.estado.id_estado) " +
                        "  INNER JOIN public.modelo_fiscal_icms_estado ON (public.estado.id_estado = public.modelo_fiscal_icms_estado.id_estado) " +
                        "WHERE " +
                        "  public.cliente.id_cliente  = " + idCliente + " AND " +
                        "  public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms = " + idModeloFiscalIcms + "";


                    read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        if (st)
                        {
                            //Carrega a aliquota dentro do estado para complementar as infos

                            toRet.DevolucaoMaterialIcmsAliquotaSt = icmsAliquotaEstadoEmissor;
                            toRet.DevolucaoMaterialIcmsAliquota = Convert.ToDouble(read["mfe_aliquota"]);
                        }
                        else
                        {
                            toRet.DevolucaoMaterialIcmsAliquota = Convert.ToDouble(read["mfe_aliquota"]);
                        }

                        read.Close();
                    }
                    else
                    {
                        throw new Exception("Erro ao identificar a aliquota do ICMS, verifique o cadastro das aliquotas e do cliente.");
                    }
                }


                //Marco - 2020-11-25 - Desoneração do ICMS não implementada na estrutura antiga pois ela não se encaixa no modelo de dados atual, ela deveria ser configurada na operação e ao mesmo tempo no modelo fiscal do ICMS.
                toRet.IcmsMotivoDesoneracao = null;
                toRet.DevolucaoMaterialIcmsMotivoDesoneracao = null;

            }
            else
            {
                throw new Exception("Cadastro fiscal do item " + codigo + " inválido. Verifique o cadastro.");
            }

            return toRet;
        }

      
    }
}
