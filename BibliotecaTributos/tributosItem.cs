#region Referencias

using System;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaTributos
{
    public class TributosItem
    {
        public string NCM { private set; get; }
        public string CEST { private set; get; }
        public string CodigoBeneficioFiscal { private set; get; }

        public double AliquotaFCP { private set; get; }

        public string GTIN { private set; get; }
        public string exTIPI { private set; get; }
        public string Genero { private set; get; }

        public double ICMSPercentualDiferimento { private set; get; }
        public string ICMSObsDiferimento { private set; get; }
        public string ICMSCst { private set; get; }
        public short ICMSOrigem { private set; get; }
        public short ICMSModalidadeDeterminacaoBC { private set; get; }
        public double ICMSAliquota { private set; get; }
        public double ICMSAliquotaST { private set; get; }
        public double ICMSAliquotaEstadoEmissor { private set; get; }
        public double ICMSPercentualReducaoBC { private set; get; }
        public short ICMSModalidadeDeterminacaoBCST { private set; get; }
        public double ICMSPercentualReducaoBCST { private set; get; }
        public double ICMSPercentualMVAST { private set; get; }

        public double ICMSPercentualBCOperacaoPropria { private set; get; }
        public string ICMSSiglaUfDevido { private set; get; }
        public int ICMSCsoSimples { private set; get; }
        public double ICMSAliquotaCreditoSimples { private set; get; }
        public string ICMSObsevacaoCreditoSimples { private set; get; }



        public string IPIClasseEnquadramentoCigarrosBebidas { private set; get; }
        public string IPICNPJProdutor { private set; get; }
        public string IPIClasseEnquadramento { private set; get; }
        public string IPICst { private set; get; }
        public double IPIAliquota { private set; get; }
        public short IPIModalidadeTributacao { private set; get; }

        public string PISCst { private set; get; }
        public double PISAliquota { private set; get; }
        public short PISModalidadeTributacao { private set; get; }
        public short PISImpostoRetido { private set; get; }

        public string CofinsCst { private set; get; }
        public double CofinsAliquota { private set; get; }
        public short CofinsModalidadeTributacao { private set; get; }
        public short CofinsImpostoRetido { private set; get; }

        public double IIAliquota { private set; get; }

        public double? ICMSPercentualCreditoPresumido { private set; get; }
        public double? ICMSPercentualLimiteCreditoPresumido { private set; get; }
        public string ICMSObservacaoCreditoPresumido { private set; get; }
        
        public TributosItem(long? idProduto, long? idMaterial, long? idCliente, long? idFornecedor, long idUfEmissor, PisCofinsInfo pisCofinsDefault, string codProduto, IWTPostgreNpgsqlCommand command, long idUfDestinatario, int cfop )
        {
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
                    "  INNER JOIN public.modelo_fiscal_icms ON (public.produto_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms.id_modelo_fiscal_icms) " +
                    "  INNER JOIN public.ncm ON (public.produto_fiscal.id_ncm = public.ncm.id_ncm) " +
                    "  LEFT OUTER JOIN " +
                    "        ( " +
                    "            SELECT * " +
                    "                FROM public.ncm_beneficio_fiscal " +
                    "            WHERE public.ncm_beneficio_fiscal.nbf_cfop = " + cfop+" AND " +
                    "        public.ncm_beneficio_fiscal.id_estado = "+ idUfDestinatario + " " +
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
                 "  INNER JOIN public.modelo_fiscal_icms ON (public.material_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms.id_modelo_fiscal_icms) " +
                 "  INNER JOIN public.ncm ON (public.material_fiscal.id_ncm = public.ncm.id_ncm) " +
                 "  LEFT OUTER JOIN " +
                 "        ( " +
                 "            SELECT * " +
                 "                FROM public.ncm_beneficio_fiscal " +
                 "            WHERE public.ncm_beneficio_fiscal.nbf_cfop = " + cfop + " AND " +
                 "        public.ncm_beneficio_fiscal.id_estado = " + idUfDestinatario + " " +
                 "        ) as benefFiscal ON(public.ncm.id_ncm = benefFiscal.id_ncm) " +
                 "WHERE " +
                 "  public.material_fiscal.id_material = " + idMaterial + "";

                prefixo = "mfs";
                prefixo2 = "mat";
            }
            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

            if (read.HasRows)
            {
                read.Read();

                string idModeloFiscalICMS = read["id_modelo_fiscal_icms"].ToString();

                this.exTIPI = read[prefixo + "_extipi"].ToString();
                this.Genero = read[prefixo + "_genero"].ToString();
                this.GTIN = read[prefixo2 + "_gtin"].ToString();
                this.NCM = read["ncm_codigo"].ToString();
                this.CEST = read["ncm_cest"].ToString();
                this.CodigoBeneficioFiscal = read["nbf_codigo_beneficio_fiscal"].ToString();
                this.ICMSOrigem = Convert.ToInt16(read[prefixo + "_origem"]);


                //PIS
                if (read[prefixo + "_pis"].ToString() == "1")
                {
                    this.PISImpostoRetido = Convert.ToInt16(read[prefixo + "_pis_imposto_retido"]);
                    this.PISModalidadeTributacao = Convert.ToInt16(read[prefixo + "_pis_modalidade_tributacao"]);
                    this.PISAliquota = Convert.ToDouble(read[prefixo + "_pis_aliquota"]);
                    this.PISCst = read[prefixo + "_pis_cst"].ToString();
                }
                else
                {
                    //Usa o default do sistema
                    this.PISImpostoRetido = Convert.ToInt16(pisCofinsDefault.PisImpostoRetido);
                    this.PISModalidadeTributacao = Convert.ToInt16(pisCofinsDefault.PisModalidadeTributacao);
                    this.PISAliquota = pisCofinsDefault.PisAliquota;
                    this.PISCst = pisCofinsDefault.PisCST;
                }

                //COFINS
                if (read[prefixo + "_cofins"].ToString() == "1")
                {
                    this.CofinsImpostoRetido = Convert.ToInt16(read[prefixo + "_cofins_imposto_retido"]);
                    this.CofinsModalidadeTributacao = Convert.ToInt16(read[prefixo + "_cofins_modalidade_tributacao"]);
                    this.CofinsAliquota = Convert.ToDouble(read[prefixo + "_cofins_aliquota"]);
                    this.CofinsCst = read[prefixo + "_cofins_cst"].ToString();
                }
                else
                {
                    //Usa o default do sistema
                    this.CofinsImpostoRetido = Convert.ToInt16(pisCofinsDefault.CofinsImpostoRetido);
                    this.CofinsModalidadeTributacao = Convert.ToInt16(pisCofinsDefault.CofinsModalidadeTributacao);
                    this.CofinsAliquota = pisCofinsDefault.CofinsAliquota;
                    this.CofinsCst = pisCofinsDefault.CofinsCST;
                }

                //IPI
                this.IPIModalidadeTributacao = Convert.ToInt16(read["ncm_ipi_modalidade_tributacao"]);
                this.IPIAliquota = Convert.ToDouble(read["ncm_ipi_aliquota"]);
                this.IPICst = read["ncm_ipi_cst"].ToString();
                this.IPIClasseEnquadramento = read["ncm_ipi_codigo_enquadramento"].ToString();


                this.IIAliquota = Convert.ToDouble(read["ncm_ii_aliquota"]);

                //ICMS
                this.ICMSCst = read["mfi_cst"].ToString();

                this.ICMSModalidadeDeterminacaoBC = Convert.ToInt16(read["mfi_modalidade_determinacao_bc"] == DBNull.Value ? 0 : read["mfi_modalidade_determinacao_bc"]);
                this.ICMSPercentualReducaoBC = Convert.ToDouble(read["mfi_percentual_reducao_bc"] == DBNull.Value ? 0 : read["mfi_percentual_reducao_bc"]);
                this.ICMSModalidadeDeterminacaoBCST = Convert.ToInt16(read["mfi_modalidade_determinicao_bc_st"] == DBNull.Value ? 0 : read["mfi_modalidade_determinicao_bc_st"]);
                this.ICMSPercentualMVAST = Convert.ToDouble("0" + read["mfi_percentual_mva_st"]);
                this.ICMSPercentualReducaoBCST = Convert.ToDouble("0" + read["mfi_percentual_reducao_bc_st"]);
                bool st = Convert.ToInt16(read["mfi_st"]) == 1 || Convert.ToInt16(read["mfi_st"]) == 2;


                this.ICMSPercentualDiferimento = Convert.ToDouble(read["mfi_percentual_diferimento"]);
                this.ICMSObsDiferimento = read["mfi_obs_diferimento"].ToString();

                this.ICMSPercentualCreditoPresumido = read["mfi_percentual_credito_presumido"] as double?;
                this.ICMSPercentualLimiteCreditoPresumido = read["mfi_percentual_limite_credito_presumido"] as double?;
                this.ICMSObservacaoCreditoPresumido = read["mfi_observacao_credito_presumido"].ToString();

                if (read["mfi_percentual_bc_propria"] != DBNull.Value)
                {
                    this.ICMSPercentualBCOperacaoPropria = Convert.ToDouble(read["mfi_percentual_bc_propria"]);
                }


                this.ICMSSiglaUfDevido = read["mfi_uf_st"].ToString();

                switch (this.ICMSCst)
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
                        this.ICMSCsoSimples = int.Parse(this.ICMSCst);
                        this.ICMSCst = "SN";
                        break;
                }

                if (read["mfi_aliquota_credito"] != DBNull.Value)
                {
                    this.ICMSAliquotaCreditoSimples = Convert.ToDouble(read["mfi_aliquota_credito"]);
                    this.ICMSObsevacaoCreditoSimples = read["mfi_observacao_credito_icms"].ToString();
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
                this.ICMSAliquotaEstadoEmissor = Convert.ToDouble(read["mfe_aliquota"]);
                read.Close();
                if (!idFornecedor.HasValue)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  public.modelo_fiscal_icms_estado.mfe_aliquota " +
                        "FROM " +
                        "  public.cliente " +
                        "  INNER JOIN public.estado ON (public.cliente.id_estado_cob = public.estado.id_estado) " +
                        "  INNER JOIN public.modelo_fiscal_icms_estado ON (public.estado.id_estado = public.modelo_fiscal_icms_estado.id_estado) " +
                        "WHERE " +
                        "  public.cliente.id_cliente  = " + idCliente + " AND " +
                        "  public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms = " + idModeloFiscalICMS + "";
                }
                else
                {
                    command.CommandText =
                        "SELECT  " +
                        "  public.modelo_fiscal_icms_estado.mfe_aliquota " +
                        "FROM " +
                        "  public.fornecedor " +
                        "  INNER JOIN public.estado ON (public.fornecedor.id_estado = public.estado.id_estado) " +
                        "  INNER JOIN public.modelo_fiscal_icms_estado ON (public.estado.id_estado = public.modelo_fiscal_icms_estado.id_estado) " +
                        "WHERE " +
                        "  public.fornecedor.id_fornecedor  = " + idFornecedor + " AND " +
                        "  public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms = " + idModeloFiscalICMS + "";
                }

                read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    if (st)
                    {
                        //Carrega a aliquota dentro do estado para complementar as infos

                        this.ICMSAliquotaST = this.ICMSAliquotaEstadoEmissor;
                        this.ICMSAliquota = Convert.ToDouble(read["mfe_aliquota"]);
                    }
                    else
                    {
                        this.ICMSAliquota = Convert.ToDouble(read["mfe_aliquota"]);
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
                throw new Exception("Cadastro fiscal do item " + codProduto + " inválido. Verifique o cadastro.");
            }

        }








    }
}
