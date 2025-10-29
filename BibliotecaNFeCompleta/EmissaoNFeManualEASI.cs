using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.NFe;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEmissaoManual;
using IWTNFCompleto.BibliotecaEmissaoManual.ClassesComunicacao;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;
using dbProvider;
using IWTDotNetLib;

namespace BibliotecaNFeCompleta
{
    public class EmissaoNFeManualEASI : EmissaoManualNFeForm
    {
        private readonly EmitenteClass _emitente;

        public EmissaoNFeManualEASI(TAmb Ambiente, EmitenteClass emitente)
            : base(Ambiente, emitente.SerialCertificado)

        {
            _emitente = emitente;
        }


        protected override IList<Operacao> getListaOperacoes()
        {

            try
            {
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

                List<Operacao> toRet = new List<Operacao>();
                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    List<OperacaoCompletaClass> operacoes = new OperacaoCompletaClass(LoginClass.UsuarioLogado.loggedUser, command.Connection).Search(
                        new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("NaturezaOperacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                        }).ConvertAll(a => (OperacaoCompletaClass) a);

                    foreach (OperacaoCompletaClass operacaoCompleta in operacoes)
                    {
                        toRet.Add(new Operacao()
                            {
                                Codigo = operacaoCompleta.ID.ToString(),
                                NaturezaOperacao = operacaoCompleta.NaturezaOperacao,
                                SomaFreteBCIcms = operacaoCompleta.IcmsSomaFreteBc
                            }
                        );
                    }
                }
                else
                {

                    
                    command.CommandText =
                        "SELECT  " +
                        "  public.operacao.id_operacao, " +
                        "  public.operacao.ope_natureza_operacao, " +
                        "  public.operacao.ope_soma_frete_bc_icms " +
                        "FROM " +
                        "  public.operacao " +
                        "ORDER BY " +
                        "  public.operacao.ope_natureza_operacao ";
                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        toRet.Add(new Operacao()
                        {
                            Codigo = read["id_operacao"].ToString(),
                            NaturezaOperacao = read["ope_natureza_operacao"].ToString(),
                            SomaFreteBCIcms = Convert.ToBoolean(Convert.ToInt16(read["ope_soma_frete_bc_icms"]))
                        });

                    }
                    read.Close();
                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a lista de operações.\r\n" + e.Message, e);
            }

        }

        protected override IList<DestinatarioRemetente> getListaDestinatarios(TipoNFe tipoNFe)
        {

            try
            {
                IList<DestinatarioRemetente> toRet = new List<DestinatarioRemetente>();

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =
                    "SELECT * FROM " +
                    "( " +
                    "(SELECT    " +
                    "  public.cliente.cli_nome,   " +
                    "  public.cliente.cli_fone1,   " +
                    "  public.cliente.cli_fax,   " +
                    "  public.cliente.cli_email,   " +
                    "  public.cliente.cli_cnpj,   " +
                    "  public.cliente.cli_ie,   " +
                    "  public.cliente.cli_endereco_cob,   " +
                    "  public.cliente.cli_bairro_cob,   " +
                    "  public.cliente.cli_cep_cob,   " +
                    "  public.cliente.cli_pais_cob,   " +
                    "  public.cliente.cli_endereco_numero_cob,   " +
                    "  public.cliente.cli_complemento_cob,   " +
                    "  public.cliente.cli_codigo_pais_cob,   " +
                    "  public.cliente.cli_comprador_cliente,   " +
                    "  public.estado.est_sigla,   " +
                    "  public.cidade.cid_nome,   " +
                    "  public.cidade.cid_codigo_ibge, " +
                    "  public.cliente.cli_indicador_ie, "+
                    "  'Cliente' as tipo, " +
                    "  public.cliente.id_cliente, "+
                    "  public.cliente.cli_envio_email, " +
                    "  public.cliente.cli_email_danfe, " +
                    "  public.cliente.cli_email_xml, " +
                    "  public.cliente.cli_inscricao_suframa " +
                    "FROM   " +
                    "  public.cliente   " +
                    "  INNER JOIN public.cidade ON (public.cliente.id_cidade_cob = public.cidade.id_cidade)   " +
                    "  INNER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado)   " +
                    "ORDER BY   " +
                    "  public.cliente.cli_nome  " +
                    ")  " +
                    " " +
                    "UNION  " +
                    "( " +
                    "SELECT    " +
                    "  public.fornecedor.for_razao_social,   " +
                    "  public.fornecedor.for_fone1,   " +
                    "  public.fornecedor.for_fax,   " +
                    "  public.fornecedor.for_email,   " +
                    "  public.fornecedor.for_cnpj,   " +
                    "  public.fornecedor.for_insc_estadual,   " +
                    "  public.fornecedor.for_endereco,   " +
                    "  public.fornecedor.for_bairro,   " +
                    "  public.fornecedor.for_cep,   " +
                    "  public.fornecedor.for_pais,   " +
                    "  public.fornecedor.for_end_numero,   " +
                    "  public.fornecedor.for_end_complemento, " +
                    "  public.fornecedor.for_codigo_pais,   " +
                    "  public.fornecedor.for_contato,   " +
                    "  public.estado.est_sigla,   " +
                    "  public.cidade.cid_nome,   " +
                    "  public.cidade.cid_codigo_ibge, " +
                    "  NULL, " +
                    "  'Fornecedor',  " +
                    "  public.fornecedor.id_fornecedor, " +
                    "  public.fornecedor.for_envio_email, " +
                    "  public.fornecedor.for_email_danfe, " +
                    "  public.fornecedor.for_email_xml, " +
                    "  public.fornecedor.for_inscricao_suframa " +
                    "FROM   " +
                    "  public.fornecedor   " +
                    "  INNER JOIN public.cidade ON (public.fornecedor.id_cidade = public.cidade.id_cidade)   " +
                    "  INNER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado)   " +
                    "ORDER BY   " +
                    "  public.fornecedor.for_razao_social  " +
                    "  ) " +
                    "  ) as tab ORDER BY UPPER(TRIM(cli_nome)); ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();


                while (read.Read())
                {
                    IWTNF.Entidades.Base.IWTNFIndicadorIE indicadorIe;
                    if (read["cli_indicador_ie"] != DBNull.Value)
                    {
                        indicadorIe = (IWTNF.Entidades.Base.IWTNFIndicadorIE) Enum.Parse(typeof(IWTNF.Entidades.Base.IWTNFIndicadorIE), read["cli_indicador_ie"].ToString());
                    }
                    else
                    {
                        if (read["cli_ie"].ToString() == "ISENTO")
                        {
                            indicadorIe = IWTNF.Entidades.Base.IWTNFIndicadorIE.Isento;
                        }
                        else
                        {
                            indicadorIe = IWTNF.Entidades.Base.IWTNFIndicadorIE.ContribuinteICMS;
                        }
                    }

                    toRet.Add(new DestinatarioRemetente()
                    {
                        Documento = read["cli_cnpj"].ToString(),
                        Email = read["cli_email"].ToString(),
                        Endereco = new Endereco()
                        {
                            Bairro = read["cli_bairro_cob"].ToString(),
                            Cep = read["cli_cep_cob"].ToString(),
                            Cidade = new Cidade()
                            {
                                Codigo = read["cid_codigo_ibge"].ToString(),
                                Nome = read["cid_nome"].ToString(),
                                Uf = read["est_sigla"].ToString()
                            },
                            CodigoPais = Convert.ToInt32(read["cli_codigo_pais_cob"]),
                            Complemento = read["cli_complemento_cob"].ToString(),
                            Contato = read["cli_comprador_cliente"].ToString(),
                            Estado = read["est_sigla"].ToString(),
                            Fax = read["cli_fax"].ToString(),
                            Logradouro = read["cli_endereco_cob"].ToString(),
                            Numero = read["cli_endereco_numero_cob"].ToString(),
                            Pais = read["cli_pais_cob"].ToString(),
                            Telefone = read["cli_fone1"].ToString()
                        },
                        InscricaoEstadual = read["cli_ie"].ToString(),
                        InscricaoSUFRAMA = read["cli_inscricao_suframa"].ToString(),
                        RazaoSocial = read["cli_nome"].ToString(),
                        Tipo = read["tipo"].ToString(),
                        TipoDocumento = read["cli_cnpj"].ToString().Length == 18 ? TipoTipoDocumento.CNJP : TipoTipoDocumento.CPF,
                        IndicadorIe = indicadorIe,
                        EmailDanfe = Convert.ToBoolean(Convert.ToUInt16(read["cli_envio_email"])) ? read["cli_email_danfe"].ToString() : null,
                        EmailXml = Convert.ToBoolean(Convert.ToUInt16(read["cli_envio_email"])) ? read["cli_email_xml"].ToString() : null
                    });

                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a lista de destinatários.\r\n" + e.Message, e);
            }


        }

        protected override IList<Cidade> getListaCidades()
        {
            try
            {


                List<Cidade> toRet = new List<Cidade>();

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =

                    "SELECT  " +
                    "  public.estado.est_sigla, " +
                    "  public.cidade.cid_nome, " +
                    "  public.cidade.cid_codigo_ibge " +
                    "FROM " +
                    "  public.cidade " +
                    "  INNER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                    "ORDER BY " +
                    "  public.estado.est_sigla, " +
                    "  public.cidade.cid_nome ";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    toRet.Add(new Cidade()
                                  {
                                      Codigo = read["cid_codigo_ibge"].ToString(),
                                      Nome = read["cid_nome"].ToString(),
                                      Uf = read["est_sigla"].ToString()
                                  });

                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a lista de cidades.\r\n" + e.Message, e);
            }
        }


        private IList<Item> carregaProdutosEMateriaisTributacaoOperacao(string codigoOperacao, string estadoCliente, string estadoEmitente, IWTPostgreNpgsqlCommand command, PisCofinsInfo pisCofinsInfo)
        {
            IList<Item> toRet = new List<Item>();

            bool operacaoDefinida = false;
            bool incideICMS = true;
            bool incideIPI = false;
            bool incidePIS = false;
            bool incideCOFINS = false;
            string cfop = null;



            #region dados da operação

            long idOperacaoCompleta;
            IWTPostgreNpgsqlDataReader read;
            OperacaoCompletaClass operacaoCompleta = null;

            if (!string.IsNullOrWhiteSpace(codigoOperacao) && !string.IsNullOrWhiteSpace(estadoCliente) && !string.IsNullOrWhiteSpace(estadoEmitente))
            {
                if (!long.TryParse(codigoOperacao, out idOperacaoCompleta))
                {
                    operacaoDefinida = false;
                }
                else
                {
                    operacaoDefinida = true;
                    operacaoCompleta = OperacaoCompletaClass.GetEntidade(idOperacaoCompleta, LoginClass.UsuarioLogado.loggedUser, command.Connection);
                    

                    cfop = estadoCliente.Equals(estadoEmitente, StringComparison.OrdinalIgnoreCase) ? operacaoCompleta.Cfop.ToString() : operacaoCompleta.CfopForaEstado.ToString();

                    incideICMS = operacaoCompleta.IcmsIncide_Incide;
                    incideIPI = operacaoCompleta.IpiIncide_Incide;
                    incidePIS = operacaoCompleta.PisIncide_Incide;
                    incideCOFINS = operacaoCompleta.CofinsIncide_Incide;


                }
            }

            #endregion

            #region Produtos
            command.CommandText =
                 "SELECT  " +
                 "  public.produto.pro_codigo, " +
                 "  public.produto.pro_descricao, " +
                 "  public.unidade_medida.unm_abreviada, " +
                 "  public.produto_fiscal.prf_origem, " +
                 "  public.produto_fiscal.prf_extipi, " +
                 "  public.produto_fiscal.prf_genero, " +
                 "  public.produto.pro_gtin, " +
                 "  public.ncm.ncm_codigo, " +
                 "  public.ncm.ncm_cest, " +
                 "  public.produto_preco.prp_preco,  " +
                 "  nbf_codigo_beneficio_fiscal " +
                 "FROM " +
                 "  public.produto " + 
                 "  INNER JOIN produto_fiscal ON produto.id_produto = produto_fiscal.id_produto "+
                 "  INNER JOIN public.unidade_medida ON (public.produto.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                 "  INNER JOIN public.ncm ON (public.produto_fiscal.id_ncm = public.ncm.id_ncm) " +
                 "  LEFT OUTER JOIN public.produto_preco ON (public.produto.id_produto = public.produto_preco.id_produto) ";

            if (string.IsNullOrWhiteSpace(cfop))
            {
                command.CommandText +=
                    "  LEFT OUTER JOIN " +
                    "  ( " +
                    "      SELECT ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal, id_ncm " +
                    "         FROM public.ncm_beneficio_fiscal " +
                    "         WHERE public.ncm_beneficio_fiscal.nbf_cfop = 999999 " +
                    "  ) as benefFiscal ON(public.ncm.id_ncm = benefFiscal.id_ncm) ";
            }
            else
            {
                command.CommandText +=
                    "  LEFT OUTER JOIN " +
                    "  ( " +
                    "      SELECT ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal, id_ncm " +
                    "         FROM public.ncm_beneficio_fiscal JOIN estado ON ncm_beneficio_fiscal.id_estado = estado.id_estado " +
                    "         WHERE public.ncm_beneficio_fiscal.nbf_cfop = " + cfop + " AND " +
                    "               public.estado.est_sigla = '" + estadoCliente + "' " +
                    "  ) as benefFiscal ON(public.ncm.id_ncm = benefFiscal.id_ncm) ";
            }


            command.CommandText +=
                "WHERE " +
                "  NOW() BETWEEN public.produto_preco.prp_inicio_vigencia AND coalesce(public.produto_preco.prp_fim_vigencia, NOW()) ";

            read = command.ExecuteReader();

            while (read.Read())
            {
                Item item = new Item()
                {
                    CFOP = cfop,
                    Codigo = read["pro_codigo"].ToString(),
                    Descricao = read["pro_descricao"].ToString(),
                    EAN = read["pro_gtin"].ToString(),
                    EANTributacao = read["pro_gtin"].ToString(),
                    EX_TIPI = read["prf_extipi"].ToString(),
                    InformacoesAdicionais = "",
                    NCM = read["ncm_codigo"].ToString(),
                    CEST = read["ncm_cest"].ToString(),
                    UnidadeComercial = read["unm_abreviada"].ToString(),
                    UnidadeTributacao = read["unm_abreviada"].ToString(),
                    ValorUnitarioComercial = (read["prp_preco"] as double?) ?? 0,
                    ValorUnitarioTributacao = (read["prp_preco"] as double?) ?? 0,
                    TipoInterno = "PRODUTO",
                    CodigoBeneficio = read["nbf_codigo_beneficio_fiscal"] != DBNull.Value ? read["nbf_codigo_beneficio_fiscal"].ToString() : null
                };

                if (operacaoDefinida)
                {
                    if (incideICMS)
                    {
                        string cstICMS = operacaoCompleta.IcmsCst;
                        int CSONICMS = 0;
                        switch (cstICMS)
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
                                CSONICMS = int.Parse(cstICMS);
                                cstICMS = "SN";
                                break;
                        }

                        
                        double ICMSAliquota;
                        double ICMSAliquotaST = 0;



                        //Encontra a aliquota no estado do emissor
                        double aliquotaEstadoEmissor = 0;
                        OperacaoCompletaIcmsAliquotaClass estadoAliquotaObj = operacaoCompleta.CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.FirstOrDefault(a => a.Estado.Sigla == estadoEmitente);
                        if (estadoAliquotaObj != null)
                        {
                            aliquotaEstadoEmissor = estadoAliquotaObj.Aliquota;
                        }


                        double aliquotaEstadoCliente = 0;
                        estadoAliquotaObj = operacaoCompleta.CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.FirstOrDefault(a => a.Estado.Sigla == estadoCliente);
                        if (estadoAliquotaObj != null)
                        {
                            aliquotaEstadoCliente = estadoAliquotaObj.Aliquota;
                        }

                        if (operacaoCompleta.IcmsSt == 1 || operacaoCompleta.IcmsSt == 2)
                        {
                            ICMSAliquotaST = aliquotaEstadoEmissor;
                            ICMSAliquota = aliquotaEstadoCliente;
                        }
                        else
                        {
                            ICMSAliquota = aliquotaEstadoCliente;
                        }


         
                  

                        int modDetBcSt = 0;

                        modDetBcSt = Convert.ToInt32(operacaoCompleta.IcmsModDetBcSt);
                        

                        string aaa = read["pro_codigo"].ToString();


                        item.ICMS = new ItemICMS()
                        {
                            Aliquota = ICMSAliquota,
                            AliquotaCalculoCredito = operacaoCompleta.IcmsAliquotaCredito as double? ?? 0,
                            AliquotaST = ICMSAliquotaST,
                            CSON = CSONICMS,
                            CST = cstICMS,
                            ModalidadeDeterminacaoBc = (TipoModalidadeDeterminacaoBcICMS) Enum.ToObject(typeof(TipoModalidadeDeterminacaoBcICMS), operacaoCompleta.IcmsModDetBc),
                            ModalidadeDeterminacaoBcSt = (TipoModalidadeDeterminacaoBcICMSST) Enum.ToObject(typeof(TipoModalidadeDeterminacaoBcICMSST), modDetBcSt),
                            MotivoDesoneracaoICMS = 0,
                            Origem = (TipoOrigem) Enum.ToObject(typeof(TipoOrigem), read["prf_origem"]),
                            PercentualBCOperacaoPropria = operacaoCompleta.IcmsPercentualBcOperacaoPropria,
                            PercentualMargemValorAdicionadoST = 0,
                            PercentualReducaoBC = operacaoCompleta.IcmsPercentualReducaoBc,
                            PercentualReducaoBCST = operacaoCompleta.IcmsPercentualReducaoBcSt,
                            UFICMSSTDevidoOperacao = ""
                        };
                    }

                    if (incideIPI)
                    {

                        item.IPI = new ItemIPI()
                        {
                            Aliquota = operacaoCompleta.IpiAliquota,
                            ClasseEnquadramento = "",
                            CNPJProdutor = "",
                            CodigoEnquadramento = operacaoCompleta.IpiCodEnquadramento,
                            CodigoSeloControle = "",
                            CST = operacaoCompleta.IpiCst,
                            QuantidadeSeloControle = 0,
                            TipoTributacao = (TipoTributacao) Enum.ToObject(typeof(TipoTributacao), operacaoCompleta.IpiModTributacao)
                        };
                    }

                    if (incidePIS)
                    {
                        if (!string.IsNullOrWhiteSpace(operacaoCompleta.PisCst))
                        {
                            item.PIS = new ItemPIS()
                            {
                                Aliquota = operacaoCompleta.PisAliquota,
                                AliquotaST = 0,
                                CST = operacaoCompleta.PisCst,
                                TipoTributacao = (TipoTributacao) Enum.ToObject(typeof(TipoTributacao), operacaoCompleta.PisModTributacao)
                            };
                        }
                        else
                        {
                            item.PIS = new ItemPIS()
                            {
                                Aliquota = pisCofinsInfo.PisAliquota,
                                AliquotaST = 0,
                                CST = pisCofinsInfo.PisCST,
                                TipoTributacao = (TipoTributacao) Enum.ToObject(typeof(TipoTributacao), pisCofinsInfo.PisModalidadeTributacao)
                            };

                        }
                    }

                    if (incideCOFINS)
                    {
                        if (!string.IsNullOrWhiteSpace(operacaoCompleta.CofinsCst))
                        {
                            item.Cofins = new ItemCofins()
                            {
                                Aliquota = operacaoCompleta.CofinsAliquota,
                                AliquotaST = 0,
                                CST = operacaoCompleta.CofinsCst,
                                TipoTributacao = (TipoTributacao) Enum.ToObject(typeof(TipoTributacao), operacaoCompleta.CofinsModTributacao)
                            };
                        }
                        else
                        {
                            item.Cofins = new ItemCofins()
                            {
                                Aliquota = pisCofinsInfo.CofinsAliquota,
                                AliquotaST = 0,
                                CST = pisCofinsInfo.CofinsCST,
                                TipoTributacao = (TipoTributacao) Enum.ToObject(typeof(TipoTributacao), pisCofinsInfo.CofinsModalidadeTributacao)
                            };

                        }
                    }
                }


                toRet.Add(item);
            }

            read.Close();

            #endregion

            #region Materiais

            command.CommandText =
                "SELECT " +
                "  public.material.mat_codigo, " +
                "  public.material.mat_descricao, " +
                "  public.unidade_medida.unm_abreviada, " +
                "  public.material.mat_gtin, " +
                "  public.ncm.ncm_codigo, " +
                "  public.ncm.ncm_cest, " +
                "  public.ncm.ncm_ipi_codigo_enquadramento, " +
                "  public.ncm.ncm_ipi_cst, " +
                "  public.ncm.ncm_ipi_aliquota, " +
                "  public.ncm.ncm_ipi_modalidade_tributacao, " +
                "  COALESCE(public.material_menor_preco.menor_preco,0) as preco, " +
                "  public.material_fiscal.mfs_extipi, " +
                "  public.material_fiscal.mfs_origem, " +
                "  public.familia_material.fam_codigo, " +
                "  public.agrupador_material.agm_identificacao, " +
                "  public.material.id_material " +
                "FROM " +
                "  public.material " +
                "  INNER JOIN public.material_fiscal ON (public.material.id_material = public.material_fiscal.id_material) " +
                "  INNER JOIN public.unidade_medida ON (public.material.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                "  INNER JOIN public.ncm ON (public.material_fiscal.id_ncm = public.ncm.id_ncm) " +
                "  LEFT OUTER JOIN public.material_menor_preco ON (public.material.id_material = public.material_menor_preco.id_material) " +
                "  LEFT OUTER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                "  LEFT OUTER JOIN public.agrupador_material ON(public.familia_material.id_agrupador_material = public.agrupador_material.id_agrupador_material) ";

            read = command.ExecuteReader();


            while (read.Read())
            {
                Item item = new Item()
                {
                    CFOP = cfop,
                    Codigo = read["agm_identificacao"].ToString() + " " + read["fam_codigo"].ToString() + " " + read["mat_codigo"].ToString() + " (M" + read["id_material"].ToString() + ")",
                    Descricao = read["mat_descricao"].ToString(),
                    EAN = read["mat_gtin"].ToString(),
                    EANTributacao = read["mat_gtin"].ToString(),
                    EX_TIPI = read["mfs_extipi"].ToString(),
                    InformacoesAdicionais = "",
                    NCM = read["ncm_codigo"].ToString(),
                    CEST = read["ncm_cest"].ToString(),
                    UnidadeComercial = read["unm_abreviada"].ToString(),
                    UnidadeTributacao = read["unm_abreviada"].ToString(),
                    ValorUnitarioComercial = (read["preco"] as double?) ?? 0,
                    ValorUnitarioTributacao = (read["preco"] as double?) ?? 0,
                    TipoInterno = "MATERIAL"
                };

                if (operacaoDefinida)
                {
                    if (incideICMS)
                    {
                        string cstICMS = operacaoCompleta.IcmsCst;
                        int CSONICMS = 0;
                        switch (cstICMS)
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
                                CSONICMS = int.Parse(cstICMS);
                                cstICMS = "SN";
                                break;
                        }


                        double ICMSAliquota;
                        double ICMSAliquotaST = 0;



                        //Encontra a aliquota no estado do emissor
                        double aliquotaEstadoEmissor = 0;
                        OperacaoCompletaIcmsAliquotaClass estadoAliquotaObj = operacaoCompleta.CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.FirstOrDefault(a => a.Estado.Sigla == estadoEmitente);
                        if (estadoAliquotaObj != null)
                        {
                            aliquotaEstadoEmissor = estadoAliquotaObj.Aliquota;
                        }


                        double aliquotaEstadoCliente = 0;
                        estadoAliquotaObj = operacaoCompleta.CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.FirstOrDefault(a => a.Estado.Sigla == estadoCliente);
                        if (estadoAliquotaObj != null)
                        {
                            aliquotaEstadoCliente = estadoAliquotaObj.Aliquota;
                        }

                        if (operacaoCompleta.IcmsSt == 1 || operacaoCompleta.IcmsSt == 2)
                        {
                            ICMSAliquotaST = aliquotaEstadoEmissor;
                            ICMSAliquota = aliquotaEstadoCliente;
                        }
                        else
                        {
                            ICMSAliquota = aliquotaEstadoCliente;
                        }





                        int modDetBcSt = 0;

                        modDetBcSt = Convert.ToInt32(operacaoCompleta.IcmsModDetBcSt);




                        item.ICMS = new ItemICMS()
                        {
                            Aliquota = ICMSAliquota,
                            AliquotaCalculoCredito = operacaoCompleta.IcmsAliquotaCredito as double? ?? 0,
                            AliquotaST = ICMSAliquotaST,
                            CSON = CSONICMS,
                            CST = cstICMS,
                            ModalidadeDeterminacaoBc = (TipoModalidadeDeterminacaoBcICMS)Enum.ToObject(typeof(TipoModalidadeDeterminacaoBcICMS), operacaoCompleta.IcmsModDetBc),
                            ModalidadeDeterminacaoBcSt = (TipoModalidadeDeterminacaoBcICMSST)Enum.ToObject(typeof(TipoModalidadeDeterminacaoBcICMSST), modDetBcSt),
                            MotivoDesoneracaoICMS = 0,
                            Origem = (TipoOrigem)Enum.ToObject(typeof(TipoOrigem), read["mfs_origem"]),
                            PercentualBCOperacaoPropria = operacaoCompleta.IcmsPercentualBcOperacaoPropria,
                            PercentualMargemValorAdicionadoST = 0,
                            PercentualReducaoBC = operacaoCompleta.IcmsPercentualReducaoBc,
                            PercentualReducaoBCST = operacaoCompleta.IcmsPercentualReducaoBcSt,
                            UFICMSSTDevidoOperacao = ""
                        };
                    }

                    if (incideIPI)
                    {

                        item.IPI = new ItemIPI()
                        {
                            Aliquota = operacaoCompleta.IpiAliquota,
                            ClasseEnquadramento = "",
                            CNPJProdutor = "",
                            CodigoEnquadramento = operacaoCompleta.IpiCodEnquadramento,
                            CodigoSeloControle = "",
                            CST = operacaoCompleta.IpiCst,
                            QuantidadeSeloControle = 0,
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), operacaoCompleta.IpiModTributacao)
                        };
                    }

                    if (incidePIS)
                    {
                        if (!string.IsNullOrWhiteSpace(operacaoCompleta.PisCst))
                        {
                            item.PIS = new ItemPIS()
                            {
                                Aliquota = operacaoCompleta.PisAliquota,
                                AliquotaST = 0,
                                CST = operacaoCompleta.PisCst,
                                TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), operacaoCompleta.PisModTributacao)
                            };
                        }
                        else
                        {
                            item.PIS = new ItemPIS()
                            {
                                Aliquota = pisCofinsInfo.PisAliquota,
                                AliquotaST = 0,
                                CST = pisCofinsInfo.PisCST,
                                TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), pisCofinsInfo.PisModalidadeTributacao)
                            };

                        }
                    }

                    if (incideCOFINS)
                    {
                        if (!string.IsNullOrWhiteSpace(operacaoCompleta.CofinsCst))
                        {
                            item.Cofins = new ItemCofins()
                            {
                                Aliquota = operacaoCompleta.CofinsAliquota,
                                AliquotaST = 0,
                                CST = operacaoCompleta.CofinsCst,
                                TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), operacaoCompleta.CofinsModTributacao)
                            };
                        }
                        else
                        {
                            item.Cofins = new ItemCofins()
                            {
                                Aliquota = pisCofinsInfo.CofinsAliquota,
                                AliquotaST = 0,
                                CST = pisCofinsInfo.CofinsCST,
                                TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), pisCofinsInfo.CofinsModalidadeTributacao)
                            };

                        }
                    }
                }



                toRet.Add(item);
            }

            read.Close();

            #endregion

            return toRet;
        }

        private IList<Item> CarregaProdutosEMateriaisTributacaoProdutoFiscal(string codigoOperacao, string estadoCliente, string estadoEmitente, IWTPostgreNpgsqlCommand command, PisCofinsInfo pisCofinsInfo)
        {
            IList<Item> toRet = new List<Item>();

            bool operacaoDefinida = false;
            bool incideICMS = true;
            bool incideIPI = false;
            bool incidePIS = false;
            bool incideCOFINS = false;
            string cfop = null;



            #region dados da operação

            IWTPostgreNpgsqlDataReader read;
            if (!string.IsNullOrWhiteSpace(codigoOperacao) && !string.IsNullOrWhiteSpace(estadoCliente) && !string.IsNullOrWhiteSpace(estadoEmitente))
            {
                command.CommandText =
                    "SELECT  " +
                    "  public.operacao.ope_cfop, " +
                    "  public.operacao.ope_incide_icms, " +
                    "  public.operacao.ope_incide_ipi, " +
                    "  public.operacao.ope_incide_pis, " +
                    "  public.operacao.ope_incide_cofins, " +
                    "  public.operacao.ope_incide_iss, " +
                    "  public.operacao.ope_cfop_fora_estado " +
                    "FROM " +
                    "  public.operacao " +
                    "WHERE " +
                    "  public.operacao.id_operacao  = " + codigoOperacao + "";
                read = command.ExecuteReader();

                if (read.HasRows)
                {
                    read.Read();
                    operacaoDefinida = true;

                    if (estadoCliente.Equals(estadoEmitente, StringComparison.OrdinalIgnoreCase))
                    {
                        cfop = read["ope_cfop"].ToString();
                    }
                    else
                    {
                        cfop = read["ope_cfop_fora_estado"].ToString();
                    }

                    incideICMS = Convert.ToBoolean(Convert.ToInt16(read["ope_incide_icms"]));
                    incideIPI = Convert.ToBoolean(Convert.ToInt16(read["ope_incide_ipi"]));
                    incidePIS = Convert.ToBoolean(Convert.ToInt16(read["ope_incide_pis"]));
                    incideCOFINS = Convert.ToBoolean(Convert.ToInt16(read["ope_incide_cofins"]));
                }

                read.Close();
            }


            #endregion

            #region Produtos
            command.CommandText =
                 "SELECT  " +
                 "  public.produto.pro_codigo, " +
                 "  public.produto.pro_descricao, " +
                 "  public.unidade_medida.unm_abreviada, " +
                 "  public.produto_fiscal.prf_origem, " +
                 "  public.produto_fiscal.prf_extipi, " +
                 "  public.produto_fiscal.prf_genero, " +
                 "  public.produto.pro_gtin, " +
                 "  public.produto_fiscal.prf_cofins, " +
                 "  public.produto_fiscal.prf_cofins_cst, " +
                 "  public.produto_fiscal.prf_cofins_aliquota, " +
                 "  public.produto_fiscal.prf_cofins_modalidade_tributacao, " +
                 "  public.produto_fiscal.prf_cofins_imposto_retido, " +
                 "  public.produto_fiscal.prf_pis, " +
                 "  public.produto_fiscal.prf_pis_cst, " +
                 "  public.produto_fiscal.prf_pis_aliquota, " +
                 "  public.produto_fiscal.prf_pis_modalidade_tributacao, " +
                 "  public.produto_fiscal.prf_pis_imposto_retido, " +
                 "  public.ncm.ncm_codigo, " +
                 "  public.ncm.ncm_cest, " +
                 "  public.ncm.ncm_ipi_codigo_enquadramento, " +
                 "  public.ncm.ncm_ipi_cst, " +
                 "  public.ncm.ncm_ipi_aliquota, " +
                 "  public.ncm.ncm_ipi_modalidade_tributacao, " +
                 "  public.modelo_fiscal_icms.id_modelo_fiscal_icms, " +
                 "  public.modelo_fiscal_icms.mfi_cst, " +
                 "  public.modelo_fiscal_icms.mfi_modalidade_determinacao_bc, " +
                 "  public.modelo_fiscal_icms.mfi_reducao_bc, " +
                 "  public.modelo_fiscal_icms.mfi_percentual_reducao_bc, " +
                 "  public.modelo_fiscal_icms.mfi_st, " +
                 "  public.modelo_fiscal_icms.mfi_modalidade_determinicao_bc_st, " +
                 "  public.modelo_fiscal_icms.mfi_percentual_reducao_bc_st, " +
                 "  public.modelo_fiscal_icms.mfi_percentual_mva_st, " +
                 "  public.modelo_fiscal_icms.mfi_percentual_bc_propria, " +
                 "  public.modelo_fiscal_icms.mfi_uf_st, " +
                 "  public.modelo_fiscal_icms.mfi_aliquota_credito, " +
                 "  public.modelo_fiscal_icms.mfi_percentual_diferimento, " +
                 "  public.modelo_fiscal_icms.mfi_obs_diferimento, " +
                 "  estado_st.est_sigla as uf_st, " +
                 "  public.modelo_fiscal_icms_estado.mfe_aliquota, " +
                 "  public.produto_preco.prp_preco,  " +
                 "  nbf_codigo_beneficio_fiscal " +
                 "FROM " +
                 "  public.produto " +
                 "  INNER JOIN public.produto_fiscal ON (public.produto.id_produto = public.produto_fiscal.id_produto) " +
                 "  INNER JOIN public.modelo_fiscal_icms ON (public.produto_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms.id_modelo_fiscal_icms) " +
                 "  INNER JOIN public.modelo_fiscal_icms_estado ON (public.modelo_fiscal_icms.id_modelo_fiscal_icms = public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms) " +
                 "  INNER JOIN public.estado ON (public.modelo_fiscal_icms_estado.id_estado = public.estado.id_estado) " +
                 "  INNER JOIN public.unidade_medida ON (public.produto.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                 "  INNER JOIN public.ncm ON (public.produto_fiscal.id_ncm = public.ncm.id_ncm) " +
                 "  LEFT OUTER JOIN public.estado estado_st ON (public.modelo_fiscal_icms.id_estado_st = estado_st.id_estado) " +
                 "  LEFT OUTER JOIN public.produto_preco ON (public.produto.id_produto = public.produto_preco.id_produto) ";

            if (string.IsNullOrWhiteSpace(cfop))
            {
                command.CommandText +=
                    "  LEFT OUTER JOIN " +
                    "  ( " +
                    "      SELECT ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal, id_ncm " +
                    "         FROM public.ncm_beneficio_fiscal " +
                    "         WHERE public.ncm_beneficio_fiscal.nbf_cfop = 999999 " +
                    "  ) as benefFiscal ON(public.ncm.id_ncm = benefFiscal.id_ncm) ";
            }
            else
            {
                command.CommandText +=
                    "  LEFT OUTER JOIN " +
                    "  ( " +
                    "      SELECT ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal, id_ncm " +
                    "         FROM public.ncm_beneficio_fiscal JOIN estado ON ncm_beneficio_fiscal.id_estado = estado.id_estado " +
                    "         WHERE public.ncm_beneficio_fiscal.nbf_cfop = " + cfop + " AND " +
                    "               public.estado.est_sigla = '" + estadoCliente + "' " +
                    "  ) as benefFiscal ON(public.ncm.id_ncm = benefFiscal.id_ncm) ";
            }


            command.CommandText +=
                "WHERE " +
                "  public.estado.est_sigla = '" + estadoCliente + "' AND " +
                "  NOW() BETWEEN public.produto_preco.prp_inicio_vigencia AND coalesce(public.produto_preco.prp_fim_vigencia, NOW()) ";

            read = command.ExecuteReader();

            while (read.Read())
            {
                Item item = new Item()
                {
                    CFOP = cfop,
                    Codigo = read["pro_codigo"].ToString(),
                    Descricao = read["pro_descricao"].ToString(),
                    EAN = read["pro_gtin"].ToString(),
                    EANTributacao = read["pro_gtin"].ToString(),
                    EX_TIPI = read["prf_extipi"].ToString(),
                    InformacoesAdicionais = "",
                    NCM = read["ncm_codigo"].ToString(),
                    CEST = read["ncm_cest"].ToString(),
                    UnidadeComercial = read["unm_abreviada"].ToString(),
                    UnidadeTributacao = read["unm_abreviada"].ToString(),
                    ValorUnitarioComercial = (read["prp_preco"] as double?) ?? 0,
                    ValorUnitarioTributacao = (read["prp_preco"] as double?) ?? 0,
                    TipoInterno = "PRODUTO",
                    CodigoBeneficio = read["nbf_codigo_beneficio_fiscal"] != DBNull.Value ? read["nbf_codigo_beneficio_fiscal"].ToString() : null
                };


                if (incideICMS)
                {
                    string cstICMS = read["mfi_cst"].ToString();
                    int CSONICMS = 0;
                    switch (cstICMS)
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
                            CSONICMS = int.Parse(cstICMS);
                            cstICMS = "SN";
                            break;
                    }

                    bool st = Convert.ToBoolean(Convert.ToInt16(read["mfi_st"]));

                    double ICMSAliquota;
                    double ICMSAliquotaST = 0;
                    if (st)
                    {
                        ICMSAliquotaST = Convert.ToDouble(read["mfe_aliquota"]);
                        //Carrega a aliquota dentro do estado para complementar as infos

                        string idModeloFiscal = read["id_modelo_fiscal_icms"].ToString();


                        IWTPostgreNpgsqlCommand command2 = DbConnection.Connection.CreateCommand();
                        command2.CommandText =
                            "SELECT  " +
                            "  public.modelo_fiscal_icms_estado.mfe_aliquota " +
                            "FROM " +
                            "  public.modelo_fiscal_icms_estado  " +
                            "  INNER JOIN public.estado ON (public.modelo_fiscal_icms_estado.id_estado = public.estado.id_estado) " +
                            "WHERE " +
                            "  public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms = " + idModeloFiscal + " AND " +
                            "  public.estado.est_sigla = '" + estadoEmitente + "'";

                        IWTPostgreNpgsqlDataReader read2 = command.ExecuteReader();
                        read2.Read();
                        ICMSAliquota = Convert.ToDouble(read2["mfe_aliquota"]);
                        read2.Close();
                    }
                    else
                    {
                        ICMSAliquota = Convert.ToDouble(read["mfe_aliquota"]);
                    }


                    int modDetBcSt = 0;
                    if (read["mfi_modalidade_determinicao_bc_st"] != DBNull.Value)
                    {
                        modDetBcSt = Convert.ToInt32(read["mfi_modalidade_determinicao_bc_st"]);
                    }

                    string aaa = read["pro_codigo"].ToString();


                    item.ICMS = new ItemICMS()
                    {
                        Aliquota = ICMSAliquota,
                        AliquotaCalculoCredito = read["mfi_aliquota_credito"] as double? ?? 0,
                        AliquotaST = ICMSAliquotaST,
                        CSON = CSONICMS,
                        CST = cstICMS,
                        ModalidadeDeterminacaoBc = (TipoModalidadeDeterminacaoBcICMS)Enum.ToObject(typeof(TipoModalidadeDeterminacaoBcICMS), read["mfi_modalidade_determinacao_bc"] as short? ?? 0),
                        ModalidadeDeterminacaoBcSt = (TipoModalidadeDeterminacaoBcICMSST)Enum.ToObject(typeof(TipoModalidadeDeterminacaoBcICMSST), modDetBcSt),
                        MotivoDesoneracaoICMS = 0,
                        Origem = (TipoOrigem)Enum.ToObject(typeof(TipoOrigem), read["prf_origem"]),
                        PercentualBCOperacaoPropria = read["mfi_percentual_bc_propria"] as double? ?? 0,
                        PercentualMargemValorAdicionadoST = read["mfi_percentual_mva_st"] as double? ?? 0,
                        PercentualReducaoBC = read["mfi_percentual_reducao_bc"] as double? ?? 0,
                        PercentualReducaoBCST = read["mfi_percentual_reducao_bc_st"] as double? ?? 0,
                        UFICMSSTDevidoOperacao = read["uf_st"].ToString()
                    };
                }

                if (incideIPI)
                {

                    item.IPI = new ItemIPI()
                    {
                        Aliquota = Convert.ToDouble(read["ncm_ipi_aliquota"]),
                        ClasseEnquadramento = "",
                        CNPJProdutor = "",
                        CodigoEnquadramento = read["ncm_ipi_codigo_enquadramento"].ToString(),
                        CodigoSeloControle = "",
                        CST = read["ncm_ipi_cst"].ToString(),
                        QuantidadeSeloControle = 0,
                        TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), read["ncm_ipi_modalidade_tributacao"])
                    };
                }

                if (incidePIS)
                {
                    if (Convert.ToBoolean(Convert.ToInt16(read["prf_pis"])))
                    {
                        item.PIS = new ItemPIS()
                        {
                            Aliquota = Convert.ToDouble(read["prf_pis_aliquota"]),
                            AliquotaST = 0,
                            CST = read["prf_pis_cst"].ToString(),
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), read["prf_pis_modalidade_tributacao"])
                        };
                    }
                    else
                    {
                        item.PIS = new ItemPIS()
                        {
                            Aliquota = pisCofinsInfo.PisAliquota,
                            AliquotaST = 0,
                            CST = pisCofinsInfo.PisCST,
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), pisCofinsInfo.PisModalidadeTributacao)
                        };

                    }
                }

                if (incideCOFINS)
                {
                    if (Convert.ToBoolean(Convert.ToInt16(read["prf_cofins"])))
                    {
                        item.Cofins = new ItemCofins()
                        {
                            Aliquota = Convert.ToDouble(read["prf_cofins_aliquota"]),
                            AliquotaST = 0,
                            CST = read["prf_cofins_cst"].ToString(),
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), read["prf_cofins_modalidade_tributacao"])
                        };
                    }
                    else
                    {
                        item.Cofins = new ItemCofins()
                        {
                            Aliquota = pisCofinsInfo.CofinsAliquota,
                            AliquotaST = 0,
                            CST = pisCofinsInfo.CofinsCST,
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), pisCofinsInfo.CofinsModalidadeTributacao)
                        };

                    }
                }


                toRet.Add(item);
            }

            read.Close();

            #endregion

            #region Materiais

            command.CommandText =
                "SELECT " +
                "  public.material.mat_codigo, " +
                "  public.material.mat_descricao, " +
                "  public.unidade_medida.unm_abreviada, " +
                "  public.material_fiscal.mfs_origem, " +
                "  public.material_fiscal.mfs_extipi, " +
                "  public.material_fiscal.mfs_genero, " +
                "  public.material.mat_gtin, " +
                "  public.material_fiscal.mfs_cofins, " +
                "  public.material_fiscal.mfs_cofins_cst, " +
                "  public.material_fiscal.mfs_cofins_aliquota, " +
                "  public.material_fiscal.mfs_cofins_modalidade_tributacao, " +
                "  public.material_fiscal.mfs_cofins_imposto_retido, " +
                "  public.material_fiscal.mfs_pis, " +
                "  public.material_fiscal.mfs_pis_cst, " +
                "  public.material_fiscal.mfs_pis_aliquota, " +
                "  public.material_fiscal.mfs_pis_modalidade_tributacao, " +
                "  public.material_fiscal.mfs_pis_imposto_retido, " +
                "  public.ncm.ncm_codigo, " +
                "  public.ncm.ncm_cest, " +
                "  public.ncm.ncm_ipi_codigo_enquadramento, " +
                "  public.ncm.ncm_ipi_cst, " +
                "  public.ncm.ncm_ipi_aliquota, " +
                "  public.ncm.ncm_ipi_modalidade_tributacao, " +
                "  public.modelo_fiscal_icms.id_modelo_fiscal_icms, " +
                "  public.modelo_fiscal_icms.mfi_cst, " +
                "  public.modelo_fiscal_icms.mfi_modalidade_determinacao_bc, " +
                "  public.modelo_fiscal_icms.mfi_reducao_bc, " +
                "  public.modelo_fiscal_icms.mfi_percentual_reducao_bc, " +
                "  public.modelo_fiscal_icms.mfi_st, " +
                "  public.modelo_fiscal_icms.mfi_modalidade_determinicao_bc_st, " +
                "  public.modelo_fiscal_icms.mfi_percentual_reducao_bc_st, " +
                "  public.modelo_fiscal_icms.mfi_percentual_mva_st, " +
                "  public.modelo_fiscal_icms.mfi_percentual_bc_propria, " +
                "  public.modelo_fiscal_icms.mfi_uf_st, " +
                "  public.modelo_fiscal_icms.mfi_aliquota_credito, " +
                "  public.modelo_fiscal_icms.mfi_percentual_diferimento, " +
                "  public.modelo_fiscal_icms.mfi_obs_diferimento, " +
                "  estado_st.est_sigla AS uf_st, " +
                "  public.modelo_fiscal_icms_estado.mfe_aliquota, " +
                "  COALESCE(public.material_menor_preco.menor_preco,0) as preco, " +
                "  public.familia_material.fam_codigo, " +
                "  public.agrupador_material.agm_identificacao, " +
                "  public.material.id_material " +
                "FROM " +
                "  public.material " +
                "  INNER JOIN public.material_fiscal ON (public.material.id_material = public.material_fiscal.id_material) " +
                "  INNER JOIN public.modelo_fiscal_icms ON (public.material_fiscal.id_modelo_fiscal_icms = public.modelo_fiscal_icms.id_modelo_fiscal_icms) " +
                "  INNER JOIN public.modelo_fiscal_icms_estado ON (public.modelo_fiscal_icms.id_modelo_fiscal_icms = public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms) " +
                "  INNER JOIN public.estado ON (public.modelo_fiscal_icms_estado.id_estado = public.estado.id_estado) " +
                "  INNER JOIN public.unidade_medida ON (public.material.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                "  INNER JOIN public.ncm ON (public.material_fiscal.id_ncm = public.ncm.id_ncm) " +
                "  LEFT OUTER JOIN public.estado estado_st ON (public.modelo_fiscal_icms.id_estado_st = estado_st.id_estado) " +
                "  LEFT OUTER JOIN public.material_menor_preco ON (public.material.id_material = public.material_menor_preco.id_material) " +
                "  LEFT OUTER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                "  LEFT OUTER JOIN public.agrupador_material ON(public.familia_material.id_agrupador_material = public.agrupador_material.id_agrupador_material) " +
                "WHERE " +
                "  public.estado.est_sigla = '" + estadoCliente + "'";

            read = command.ExecuteReader();

            
            while (read.Read())
            {
                Item item = new Item()
                {
                    CFOP = cfop,
                    Codigo = read["agm_identificacao"].ToString() + " " + read["fam_codigo"].ToString() + " " + read["mat_codigo"].ToString() + " (M" + read["id_material"].ToString() + ")",
                    Descricao = read["mat_descricao"].ToString(),
                    EAN = read["mat_gtin"].ToString(),
                    EANTributacao = read["mat_gtin"].ToString(),
                    EX_TIPI = read["mfs_extipi"].ToString(),
                    InformacoesAdicionais = "",
                    NCM = read["ncm_codigo"].ToString(),
                    CEST = read["ncm_cest"].ToString(),
                    UnidadeComercial = read["unm_abreviada"].ToString(),
                    UnidadeTributacao = read["unm_abreviada"].ToString(),
                    ValorUnitarioComercial = (read["preco"] as double?) ?? 0,
                    ValorUnitarioTributacao = (read["preco"] as double?) ?? 0,
                    TipoInterno = "MATERIAL"
                };


                if (incideICMS)
                {
                    string cstICMS = read["mfi_cst"].ToString();
                    int CSONICMS = 0;
                    switch (cstICMS)
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
                            CSONICMS = int.Parse(cstICMS);
                            cstICMS = "SN";
                            break;
                    }

                    bool st = Convert.ToBoolean(Convert.ToInt16(read["mfi_st"]));

                    double ICMSAliquota;
                    double ICMSAliquotaST = 0;
                    if (st)
                    {
                        ICMSAliquotaST = Convert.ToDouble(read["mfe_aliquota"]);
                        //Carrega a aliquota dentro do estado para complementar as infos
                        read.Close();

                        IWTPostgreNpgsqlCommand command2 = DbConnection.Connection.CreateCommand();
                        command2.CommandText =
                            "SELECT  " +
                            "  public.modelo_fiscal_icms_estado.mfe_aliquota " +
                            "FROM " +
                            "  public.modelo_fiscal_icms_estado  " +
                            "  INNER JOIN public.estado ON (public.modelo_fiscal_icms_estado.id_estado = public.estado.id_estado) " +
                            "WHERE " +
                            "  public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms = " + read["id_modelo_fiscal_icms"] + " AND " +
                            "  public.estado.est_sigla = '" + estadoEmitente + "'";

                        IWTPostgreNpgsqlDataReader read2 = command.ExecuteReader();
                        read2.Read();
                        ICMSAliquota = Convert.ToDouble(read2["mfe_aliquota"]);
                        read2.Close();
                    }
                    else
                    {
                        ICMSAliquota = Convert.ToDouble(read["mfe_aliquota"]);
                    }





                    TipoModalidadeDeterminacaoBcICMS ModalidadeDeterminacaoBc = TipoModalidadeDeterminacaoBcICMS.ValorOperacao;
                    if (read["mfi_modalidade_determinacao_bc"] != DBNull.Value)
                    {
                        ModalidadeDeterminacaoBc = (TipoModalidadeDeterminacaoBcICMS)Enum.ToObject(typeof(TipoModalidadeDeterminacaoBcICMS), read["mfi_modalidade_determinacao_bc"]);
                    }

                    TipoModalidadeDeterminacaoBcICMSST ModalidadeDeterminacaoBcSt = TipoModalidadeDeterminacaoBcICMSST.Pauta;
                    if (read["mfi_modalidade_determinicao_bc_st"] != DBNull.Value)
                    {
                        ModalidadeDeterminacaoBcSt = ((TipoModalidadeDeterminacaoBcICMSST)Enum.ToObject(typeof(TipoModalidadeDeterminacaoBcICMSST), read["mfi_modalidade_determinicao_bc_st"]));
                    }


                    item.ICMS = new ItemICMS()
                    {
                        Aliquota = ICMSAliquota,
                        AliquotaCalculoCredito = read["mfi_aliquota_credito"] as double? ?? 0,
                        AliquotaST = ICMSAliquotaST,
                        CSON = CSONICMS,
                        CST = cstICMS,
                        ModalidadeDeterminacaoBc = ModalidadeDeterminacaoBc,
                        ModalidadeDeterminacaoBcSt = ModalidadeDeterminacaoBcSt,
                        MotivoDesoneracaoICMS = 0,
                        Origem = (TipoOrigem)Enum.ToObject(typeof(TipoOrigem), read["mfs_origem"]),
                        PercentualBCOperacaoPropria = read["mfi_percentual_bc_propria"] as double? ?? 0,
                        PercentualMargemValorAdicionadoST = read["mfi_percentual_mva_st"] as double? ?? 0,
                        PercentualReducaoBC = read["mfi_percentual_reducao_bc"] as double? ?? 0,
                        PercentualReducaoBCST = read["mfi_percentual_reducao_bc_st"] as double? ?? 0,
                        UFICMSSTDevidoOperacao = read["uf_st"].ToString()
                    };
                }

                if (incideIPI)
                {

                    item.IPI = new ItemIPI()
                    {
                        Aliquota = Convert.ToDouble(read["ncm_ipi_aliquota"]),
                        ClasseEnquadramento = "",
                        CNPJProdutor = "",
                        CodigoEnquadramento = read["ncm_ipi_codigo_enquadramento"].ToString(),
                        CodigoSeloControle = "",
                        CST = read["ncm_ipi_cst"].ToString(),
                        QuantidadeSeloControle = 0,
                        TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), read["ncm_ipi_modalidade_tributacao"])
                    };
                }

                if (incidePIS)
                {
                    if (Convert.ToBoolean(Convert.ToInt16(read["mfs_pis"])))
                    {
                        item.PIS = new ItemPIS()
                        {
                            Aliquota = Convert.ToDouble(read["mfs_pis_aliquota"]),
                            AliquotaST = 0,
                            CST = read["mfs_pis_cst"].ToString(),
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), read["mfs_pis_modalidade_tributacao"])
                        };
                    }
                    else
                    {
                        item.PIS = new ItemPIS()
                        {
                            Aliquota = pisCofinsInfo.PisAliquota,
                            AliquotaST = 0,
                            CST = pisCofinsInfo.PisCST,
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), pisCofinsInfo.PisModalidadeTributacao)
                        };

                    }
                }

                if (incideCOFINS)
                {
                    if (Convert.ToBoolean(Convert.ToInt16(read["mfs_cofins"])))
                    {
                        item.Cofins = new ItemCofins()
                        {
                            Aliquota = Convert.ToDouble(read["mfs_cofins_aliquota"]),
                            AliquotaST = 0,
                            CST = read["mfs_cofins_cst"].ToString(),
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), read["mfs_cofins_modalidade_tributacao"])
                        };
                    }
                    else
                    {
                        item.Cofins = new ItemCofins()
                        {
                            Aliquota = pisCofinsInfo.CofinsAliquota,
                            AliquotaST = 0,
                            CST = pisCofinsInfo.CofinsCST,
                            TipoTributacao = (TipoTributacao)Enum.ToObject(typeof(TipoTributacao), pisCofinsInfo.CofinsModalidadeTributacao)
                        };

                    }
                }


                toRet.Add(item);
            }

            read.Close();

            #endregion

            return toRet;
        }
        public override IList<Item> getListaitens(string CodigoOperacao, string estadoCliente, string estadoEmitente)
        {
            try
            {

                List<Item> toRet = new List<Item>();

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

                #region Carrega dados do PIS e Cofins Padrão

                PisCofinsInfo pisCofinsInfo = new PisCofinsInfo(
                    IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_CST),
                    Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_IMPOSTO_RETIDO)),
                    Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_MODALIDADE)),
                    Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_PIS_ALIQUOTA),
                        CultureInfo.InvariantCulture),
                    IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_CST),
                    Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_IMPOSTO_RETIDO)),
                    Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_MODALIDADE)),
                    Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COFINS_ALIQUOTA),
                        CultureInfo.InvariantCulture)
                );

                #endregion

                #region Produtos e Materiais

                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    toRet.AddRange(carregaProdutosEMateriaisTributacaoOperacao(CodigoOperacao, estadoCliente, estadoEmitente, command, pisCofinsInfo));
                }
                else
                {
                    toRet.AddRange(CarregaProdutosEMateriaisTributacaoProdutoFiscal(CodigoOperacao, estadoCliente, estadoEmitente, command, pisCofinsInfo));
                }

             

                #endregion

        

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a lista de itens.\r\n" + e.Message, e);
            }
        }

        protected override Emitente getEmitente()
        {
            try
            {
                return new Emitente()
                           {
                               Cnpj = _emitente.Cnpj,
                               CNAE = _emitente.Cnae,
                               Endereco = new Endereco()
                                              {
                                                  Bairro = _emitente.Bairro,
                                                  Cep = _emitente.Cep,
                                                  Cidade = new Cidade()
                                                               {
                                                                   Codigo = _emitente.CidadeEntidade.CodigoIbge.ToString(),
                                                                   Nome = _emitente.CidadeEntidade.Nome,
                                                                   Uf = _emitente.CidadeEntidade.Estado.Sigla
                                                               },
                                                  CodigoPais = _emitente.CidadeEntidade.Pais.Codigo,
                                                  Complemento = _emitente.Complemento,
                                                  Contato = _emitente.Contato,
                                                  Estado = _emitente.CidadeEntidade.Estado.Sigla,
                                                  Fax = _emitente.Fax,
                                                  Logradouro = _emitente.Endereco,
                                                  Numero = _emitente.Numero,
                                                  Pais = _emitente.CidadeEntidade.Pais.Nome,
                                                  Telefone = _emitente.Telefone
                                              },
                               InscricaoEstadual = _emitente.InscricaoEstadual, 
                               InscricaoEstadualST = "",
                               InscricaoMunicipal = _emitente.InscricaoMunicipal,
                               NomeFantasia = _emitente.RazaoSocial,
                               RazaoSocial = _emitente.RazaoSocial,
                               RegimeTributario = Convert.ToInt16(_emitente.Crt) == 1 ? TipoRegimeTributario.Simples : Convert.ToInt16(_emitente.Crt) == 2 ? TipoRegimeTributario.SimplesExcesso : TipoRegimeTributario.Normal,
                               AutorizadosDownload = _emitente.AutorizadosDownloadNf
                           };
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o emitente.\r\n" + e.Message, e);
            }
        }

        protected override IList<Transportador> getListaTransportes()
        {
            try
            {



                List<Transportador> toRet = new List<Transportador>();

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =

                    "SELECT  " +
                    "  public.transporte.trp_ie, " +
                    "  public.transporte.trp_endereco, " +
                    "  public.transporte.trp_cpf_cnpj, " +
                    "  public.transporte.trp_placa, " +
                    "  public.transporte.trp_registro_antt, " +
                    "  public.cidade.cid_nome, " +
                    "  public.cidade.cid_codigo_ibge, " +
                    "  public.estado.est_sigla as uf, " +
                    "  estado_veiculo.est_sigla as uf_veiculo, " +
                    "  public.transporte.trp_razao " +
                    "FROM " +
                    "  public.transporte " +
                    "  INNER JOIN public.cidade ON (public.transporte.id_cidade = public.cidade.id_cidade) " +
                    "  INNER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                    "  LEFT JOIN public.estado estado_veiculo ON (public.transporte.id_estado_veiculo = estado_veiculo.id_estado) " +
                    "ORDER BY " +
                    "  public.transporte.trp_razao ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                
                while (read.Read())
                {
                    string documento = read["trp_cpf_cnpj"].ToString().Replace("/", "").Replace(".", "").Replace("-", "");
                    string ie = read["trp_ie"].ToString().Replace("/", "").Replace(".", "").Replace("-", "");

                    toRet.Add(new Transportador()
                                  {
                                      Cidade = new Cidade()
                                                   {
                                                       Codigo = read["cid_codigo_ibge"].ToString(),
                                                       Nome = read["cid_nome"].ToString(),
                                                       Uf = read["uf"].ToString()
                                                   },
                                      Documento = documento,
                                      Endereco = read["trp_endereco"].ToString(),
                                      InscricaoEstadual = ie,
                                      Placa = read["trp_placa"].ToString(),
                                      RazaoSocial = read["trp_razao"].ToString(),
                                      RNTC = read["trp_registro_antt"].ToString(),
                                      TipoDocumento = documento.Length == 14 ? TipoTipoDocumento.CNJP : TipoTipoDocumento.CPF,
                                      UF = read["uf"].ToString(),
                                      UFPlaca = read["uf_veiculo"].ToString()
                                  });

                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os transportes.\r\n" + e.Message, e);
            }
        }
    }
}
