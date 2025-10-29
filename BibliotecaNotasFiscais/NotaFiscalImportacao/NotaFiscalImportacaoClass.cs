using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.VisualizacaoNf;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTNF;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaNotasFiscais.NotaFiscalImportacao
{
    public class NotaFiscalImportacaoClass
    {

        

        public void GerarNotaFiscalImportacao(List<DeclaracaoImportacaoClass> dis, OperacaoClass operacao,TransporteClass transporte, IWTPostgreNpgsqlConnection singleConnection, IWTPostgreNpgsqlCommand command )
        {
            try
            {
                //Obtem uma lista de DI e agrupa elas para emitir o maximo de DI em uma mesma nota fiscal
                Dictionary<NotaFiscalImportacaoKeyClass, List<DeclaracaoImportacaoClass>> declaracoesPorFornecedor = new Dictionary<NotaFiscalImportacaoKeyClass, List<DeclaracaoImportacaoClass>>();
                List<NfPrincipalClass> nfsEmitidas = new List<NfPrincipalClass>();
                foreach (DeclaracaoImportacaoClass declaracaoImportacaoClass in dis)
                {
                    //As DIs do mesmo fornecedor e tipo de volume serão agrupadas na mesma nota fiscal
                    NotaFiscalImportacaoKeyClass chaveTeste = new NotaFiscalImportacaoKeyClass(declaracaoImportacaoClass.Fornecedor, declaracaoImportacaoClass.EspecieVolumes);
                    if (!declaracoesPorFornecedor.ContainsKey(chaveTeste))
                    {
                        declaracoesPorFornecedor.Add(chaveTeste, new List<DeclaracaoImportacaoClass>());
                    }
                    declaracoesPorFornecedor[chaveTeste].Add(declaracaoImportacaoClass);
                }

                #region Dados do Emitente
                EmitenteClass emitenteCompleto;
                PisCofinsInfo pisCofinsDefault;
                NfEmitenteClass nfEmitente = NotaFiscalFuncoesAuxiliares.CarregaEmitente(singleConnection, out emitenteCompleto,EasiEmissorNFe.Primario, out pisCofinsDefault);
                #endregion

                #region Definição do tipo de Emissão da NFe

                TipoEmissaoNFe tipoEmissaoNFe = (TipoEmissaoNFe)Enum.ToObject(typeof(TipoEmissaoNFe), int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)));
                Ambiente AmbienteEmissaoNFe = Ambiente.Producao;
                if (IWTConfiguration.Conf.getBoolConf(Constants.AMBIENTE_EMISSAO_NFE_HOMOLOGACAO))
                {
                    AmbienteEmissaoNFe = Ambiente.Homologacao;
                }

                
                if (tipoEmissaoNFe == TipoEmissaoNFe.EASI)
                {
                    string retornoDetalhado;
                    if (!NotaFiscalFuncoesAuxiliares.VerificaSituacaoServicosReceita(AmbienteEmissaoNFe, emitenteCompleto.Estado, emitenteCompleto.SerialCertificado, out retornoDetalhado))
                    {
                        throw new ExcecaoTratada("Não é possível se comunicar com os servidores da receita:\r\n" + retornoDetalhado);
                    }
                }

                #endregion


                foreach (KeyValuePair<NotaFiscalImportacaoKeyClass, List<DeclaracaoImportacaoClass>> item in declaracoesPorFornecedor)
                {
                    NfPrincipalClass nf = PreencherDadosNFImportacao(item.Value, item.Key, operacao, transporte, singleConnection, command, tipoEmissaoNFe, nfEmitente.CloneClean(), AmbienteEmissaoNFe, emitenteCompleto, pisCofinsDefault);
                    if (nf != null)
                    {
                        nfsEmitidas.Add(nf);

                        #region Salvar as notas para posterior Recebimento

                        NotaFiscalEntradaClass nfEntrada = new NotaFiscalEntradaClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                               {
                                                                   Cnpj = item.Key.Fornecedor.Cnpj,
                                                                   DataImportacao = Configurations.DataIndependenteClass.GetData(),
                                                                   DataNf = nf.DataEmissao,
                                                                   Fornecedor = item.Key.Fornecedor,
                                                                   NomeArquivo = "Nota Emitida EASI",
                                                                   NumeroNf = nf.Numero.ToString(CultureInfo.InvariantCulture),
                                                                   RazaoFornecedor = item.Key.Fornecedor.RazaoSocial,
                                                                   SerieNf = nf.Serie.ToString(CultureInfo.InvariantCulture),
                                                                   ValorTotal = nf.NfTotais.ValorTotalNf,
                                                                   NfPrincipal = nf
                                                               };
                        foreach (NfItemClass itemNf in nf.CollectionNfItemClassNfPrincipal)
                        {
                            nfEntrada.CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Add(new NotaFiscalEntradaLinhaClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                                                                     {
                                                                                                         Codigo = itemNf.NfProduto.Codigo,
                                                                                                         Descricao = itemNf.NfProduto.Descricao,
                                                                                                         ImcsIncluso = itemNf.NfItemTributo.NfItemTributoIcms.Aliquota,
                                                                                                         IpiNaoIncluso = itemNf.NfItemTributo.NfItemTributoIpi.Aliquota,
                                                                                                         Linha = itemNf.NumeroItem,
                                                                                                         Ncm = itemNf.NfProduto.Ncm,
                                                                                                         NotaFiscalEntrada = nfEntrada,
                                                                                                         Quantidade = itemNf.NfProduto.QuantidadeTributavel,
                                                                                                         Unidade = itemNf.NfProduto.UnidadeTributacao,
                                                                                                         ValorTotal = itemNf.NfProduto.ValorTotalTributavel,
                                                                                                         ValorUnitario = itemNf.NfProduto.ValorUnitarioTrinutacao,
                                                                                                         Vinculada = false
                                                                                                     });
                        }
                        nfEntrada.Save(ref command);
                        #endregion

                        //Update na DI indicando que já teve NFe gerada e vinculando com a NFe
                        foreach (DeclaracaoImportacaoClass di in item.Value)
                        {
                            di.NfGerada = true;
                            di.NfPrincipal = nf;
                            di.Save(ref command);
                        }
                    }
                }
                
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao gerar nota fiscal de importação.\r\n" + e.Message, e);
            }
        }

        private NfPrincipalClass PreencherDadosNFImportacao(List<DeclaracaoImportacaoClass> listaDIs, NotaFiscalImportacaoKeyClass chaveJuncaoNotas, OperacaoClass operacao, TransporteClass transporte, IWTPostgreNpgsqlConnection singleConnection, IWTPostgreNpgsqlCommand command, TipoEmissaoNFe tipoEmissaoNFe, NfEmitenteClass nfEmitente, Ambiente AmbienteEmissaoNFe, EmitenteClass emitenteCompleto, PisCofinsInfo pisCofinsDefault)
        {
            FornecedorClass fornecedor = chaveJuncaoNotas.Fornecedor;
            try
            {
                #region Dados Principais NF

                NfPrincipalClass nf;
                try
                {
                    int numeroNota;
                    int serie = 1;
                  
                    numeroNota = NFeOperacoes.getProximoNumeroNf(nfEmitente.CnpjCpf, "55", command, AmbienteEmissaoNFe == Ambiente.Homologacao ? TAmb.Homologacao : TAmb.Producao, out serie);
                    

                    FormaPagamento formaPagto = FormaPagamento.APrazo;


                    string versaoEmissor = emitenteCompleto.VersaoEmissorNFe;
                    nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                             {
                                 Numero = numeroNota,
                                 NaturezaOperacao = operacao.NaturezaOperacao,
                                 Serie = serie,
                                 FormaPagamento = formaPagto,
                                 ModeloDocFiscal = "55",
                                 DataEmissao = Configurations.DataIndependenteClass.GetData(),
                                 DataSaidaEntrada = Configurations.DataIndependenteClass.GetData(),
                                 Tipo = TipoNota.Entrada,
                                 CodMunicipioFatoGerador = nfEmitente.NfEmitenteEndereco.CodMunicipio,
                                 FormatoImpressao = FormatoImpressao.Retrato,
                                 FormaEmissao = FormaEmissaoNFe.Normal,
                                 IdentificacaoAmbiente = AmbienteEmissaoNFe == Ambiente.Homologacao ? 2 : 1,
                                 FinalidadeEmissao = Finalidade.Normal,
                                 ProcessoEmissao = Processo.ContribuinteAplicativoFisco,
                                 VersaoProcessoEmissao = versaoEmissor,
                                 Observacoes = "",
                                 TipoEmitente = "P",
                                 Situacao = "N"
                             };

                    nf.Homologacao = AmbienteEmissaoNFe == Ambiente.Homologacao;

                    nf.NfAtributo = new NfAtributoClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                        {
                                            NfPrincipal = nf,
                                            VersaoLayout = "2.00",
                                            IdNfe = "NFe"
                                        };

                    nf.NfEmitente = nfEmitente;
                    nfEmitente.NfPrincipal = nf;
                    nfEmitente.NfEmitenteEndereco.NfPrincipal = nf;

                    nf.EnviarNfeReceita = tipoEmissaoNFe == TipoEmissaoNFe.EASI;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os campos principais da NF.\r\n" + e.Message);
                }

                #endregion

                #region Fornecedor

                try
                {
                    if (fornecedor == null)
                    {
                        throw new Exception("Não é possível emitir uma nota fiscal sem fornecedor!");
                    }
                    
                    if (fornecedor.Cidade == null)
                    {
                        throw new Exception("Municipio do endereço principal do fornecedor é inválido.");
                    }
                    
                    if (fornecedor.Cidade.Estado == null)
                    {
                        throw new Exception("Estado do endereço principal do fornecedor é inválido.");
                    }

                    if (fornecedor.Cidade.Pais == null)
                    {
                        throw new Exception("País do endereço principal do fornecedor é inválido.");
                    }

                    nf.NfCliente = new NfClienteClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                       {
                                           NfPrincipal = nf,
                                           Razao = fornecedor.RazaoSocial,
                                           NomeFantasia = fornecedor.NomeFantasia,
                                           Ie = "",
                                           CnpjCpf = "",
                                           Isuf = fornecedor.InscricaoSuframa,
                                           Email = fornecedor.Email
                                       };

                    nf.NfCliente.NfClienteEndereco = new NfClienteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                         {
                                                             NfPrincipal = nf,
                                                             Logradouro = fornecedor.Endereco,
                                                             Numero = fornecedor.EndNumero,
                                                             Complemento = fornecedor.EndComplemento,
                                                             Bairro = fornecedor.Bairro,
                                                             CodMunicipio = 9999999,
                                                             NomeMunicipio = "EXTERIOR",
                                                             SiglaUf = fornecedor.Cidade.Estado.Sigla,
                                                             Cep = fornecedor.Cep.Replace("-", ""),
                                                             CodPais = fornecedor.Cidade.Pais.Codigo,
                                                             NomePais = fornecedor.Cidade.Pais.Nome,
                                                             Telefone = fornecedor.Fone1.Replace("(", "").Trim().Replace(")", "").Replace("-", "").Replace(" ", "")
                                                         };


                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do fornecedor da NF.\r\n" + e.Message);
                }

                #endregion

                #region Preenchimento dados dos Itens

                int numeroItem = 0;
                double valorTotalProdutosAntesII = 0;
                double valorTotalPisImportacao = 0;
                double valorTotalCofinsImportacao = 0;
                Dictionary<ValoresAcumuladosICMSObsKey,ValoresAcumuladosICMSObs> icmsObservacoes = new Dictionary<ValoresAcumuladosICMSObsKey, ValoresAcumuladosICMSObs>();

                foreach (DeclaracaoImportacaoClass di in listaDIs)
                {                    
                    //double valorDIReais = di.ValorMercadoria * di.CotacaoDolar;
                    double vmcvGeral = di.CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Sum(a => a.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao.Sum(b => b.ValorTotalReais));
                    
                    foreach (DeclaracaoImportacaoAdicaoClass adicao in di.CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao)
                    {
                        foreach (DeclaracaoImportacaoAdicaoItemClass itemAdicao in adicao.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao)
                        {      
                            TributosItem tributos = new TributosItem(null, itemAdicao.Material.ID,
                                                                     null, di.Fornecedor.ID, emitenteCompleto.CidadeEntidade.Estado.ID,
                                                                     pisCofinsDefault, itemAdicao.Material.IdentificacaoCompleta, command, fornecedor.Estado.ID,operacao.Cfop);

                            numeroItem++;
                            NfItemClass item = new NfItemClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                   {
                                                       NfPrincipal = nf,
                                                       NumeroItem = numeroItem,
                                                       Cfop = operacao.Cfop
                                                   };

                            MaterialClass material = itemAdicao.Material;

                            MaterialFiscalClass materialFiscal = itemAdicao.Material.CollectionMaterialFiscalClassMaterial.FirstOrDefault();
                            if (materialFiscal == null)
                            {
                                throw new ExcecaoTratada("Não é possível fazer a nota de importação de um material sem fiscal cadastrado.");
                            }

                            MaterialFornecedorClass materialFornecedor = material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == di.Fornecedor);
                            if (materialFornecedor == null)
                            {
                                throw new ExcecaoTratada("Não é possível fazer a nota de importação de um material cujo fornecedor da DI não esteja no cadastro de material-fornecedor.");
                            }

                            item.NfProduto = new NfProdutoClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                 {
                                                     NfItem = item,
                                                     Codigo = material.IdentificacaoCompleta,
                                                     Descricao = material.Descricao,
                                                     Extipi = materialFiscal.Extipi,
                                                     Genero = materialFiscal.Genero.HasValue ? materialFiscal.Genero.Value.ToString(CultureInfo.InvariantCulture) : null,
                                                     GtimUnidadeTrinutacao = material.Gtin,
                                                     Gtin = material.Gtin,
                                                     Ncm = materialFiscal.Ncm.Codigo,
                                                     Quantidade = itemAdicao.Quantidade,
                                                     QuantidadeTributavel = itemAdicao.Quantidade,
                                                     Unidade =
                                                         (materialFornecedor.UnidadeMedidaCompra != null
                                                              ? materialFornecedor.UnidadeMedidaCompra.ToString()
                                                              : (material.UnidadeMedidaCompra != null ? material.UnidadeMedidaCompra.ToString() : material.UnidadeMedida.ToString())),
                                                     UnidadeTributacao =
                                                         (materialFornecedor.UnidadeMedidaCompra != null
                                                              ? materialFornecedor.UnidadeMedidaCompra.ToString()
                                                              : (material.UnidadeMedidaCompra != null ? material.UnidadeMedidaCompra.ToString() : material.UnidadeMedida.ToString())),
                                                     ValorTotalTributavel = itemAdicao.ValorTotalReais,
                                                     ValorUnitario = itemAdicao.ValorUnitarioReais,
                                                     ValorUnitarioTrinutacao = itemAdicao.ValorUnitarioReais,
                                                     CodigoBeneficio = tributos.CodigoBeneficioFiscal
                                                 };

                            #region DI

                            NfProdutoDeclaracaoImportacaoClass diClass = new NfProdutoDeclaracaoImportacaoClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                                             {
                                                                                 CodigoExportador = adicao.CodigoFabricante,
                                                                                 DataDesembaraco = di.DataDesembaraco,
                                                                                 DataRegistroDi = di.DataRegistro,
                                                                                 LocalDesembaraco = di.LocalDesembaracoAduaneiro.Identificacao,
                                                                                 NfItem = item,
                                                                                 NumeroDocImportacao = di.Numero,
                                                                                 UfDesembaraco = di.LocalDesembaracoAduaneiro.Estado.Sigla

                                                                             };

                            diClass.CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Add(new NfProdutoDeclaracaoImportacaoAdicaoClass(LoginClass.UsuarioLogado.loggedUser,singleConnection)
                                                                                                                            {
                                                                                                                                CodigoFabricante = adicao.CodigoFabricante,
                                                                                                                                NfProdutoDeclaracaoImportacao = diClass,
                                                                                                                                Numero = adicao.Numero,
                                                                                                                                NumeroSequencialItem = itemAdicao.NumeroSequencialNaAdicao
                                                                                                                            });
                            item.CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Add(diClass);
                            #endregion

                            #region ICMS

                            switch (operacao.IncideIcms)
                            {
                                case IncidenciaImposto.Incide:
                                    switch (tributos.ICMSCst)
                                    {
                                        case "41a":
                                            IcmsRetidoForm form2 = new IcmsRetidoForm(material.IdentificacaoCompleta + " - " + material.Descricao);
                                            form2.ShowDialog();

                                            item.NfProduto.NfProdutoIcms =
                                                new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                    {
                                                        NfItem = item,
                                                        Cst = tributos.ICMSCst,
                                                        Origem = (OrigemMercadoria) Enum.ToObject(typeof (OrigemMercadoria), tributos.ICMSOrigem),
                                                        ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof (ModalidadeDeterminacaoBCICMS), tributos.ICMSModalidadeDeterminacaoBC),
                                                        Aliquota = tributos.ICMSAliquotaEstadoEmissor,
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
                                                        ValorBcStRetidoRemetente = form2.remetenteBC,
                                                        ValorIcmsStRetidoRemetente = form2.remetenteValor,
                                                        ValorBcStRetidoDestinatario = form2.destBC,
                                                        ValorIcmsStRetidoDestinatario = form2.destValor,
                                                        CsoSimples = tributos.ICMSCsoSimples,
                                                        AliquotaCreditoSimples = tributos.ICMSAliquotaCreditoSimples,
                                                        PercentualCreditoPresumido = tributos.ICMSPercentualCreditoPresumido,
                                                        PercentualLimiteCreditoPresumido = tributos.ICMSPercentualLimiteCreditoPresumido,
                                                        ObservacaoCreditoPresumido = tributos.ICMSObservacaoCreditoPresumido
                                                    };
                                            break;

                                        case "90b":
                                            item.NfProduto.NfProdutoIcms =
                                                new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                    {
                                                        NfItem = item,
                                                        Cst = "90",
                                                        Origem = (OrigemMercadoria) Enum.ToObject(typeof (OrigemMercadoria), tributos.ICMSOrigem),
                                                        ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof (ModalidadeDeterminacaoBCICMS), tributos.ICMSModalidadeDeterminacaoBC),
                                                        Aliquota = tributos.ICMSAliquotaEstadoEmissor,
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
                                                        AliquotaCreditoSimples = tributos.ICMSAliquotaCreditoSimples,
                                                        PercentualCreditoPresumido = tributos.ICMSPercentualCreditoPresumido,
                                                        PercentualLimiteCreditoPresumido = tributos.ICMSPercentualLimiteCreditoPresumido,
                                                        ObservacaoCreditoPresumido = tributos.ICMSObservacaoCreditoPresumido
                                                    };

                                            break;

                                        default:
                                            item.NfProduto.NfProdutoIcms =
                                                new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                    {
                                                        NfItem = item,
                                                        Cst = tributos.ICMSCst,
                                                        Origem = (OrigemMercadoria) Enum.ToObject(typeof (OrigemMercadoria), tributos.ICMSOrigem),
                                                        ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof (ModalidadeDeterminacaoBCICMS), tributos.ICMSModalidadeDeterminacaoBC),
                                                        Aliquota = tributos.ICMSAliquotaEstadoEmissor,
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
                                                        AliquotaCreditoSimples = tributos.ICMSAliquotaCreditoSimples,
                                                        PercentualCreditoPresumido = tributos.ICMSPercentualCreditoPresumido,
                                                        PercentualLimiteCreditoPresumido = tributos.ICMSPercentualLimiteCreditoPresumido,
                                                        ObservacaoCreditoPresumido = tributos.ICMSObservacaoCreditoPresumido
                                                    };
                                            break;
                                    }
                                    break;

                                case IncidenciaImposto.NaoIncide:
                                    throw new Exception("O ICMS é obrigatório. Verifique o modelo fiscal utilizado para o material " + material);

                                case IncidenciaImposto.Suspenso:
                                    string cstSuspensaoICMS;
                                    int? csoSuspensaoICMS;

                                    operacao.getCSTSuspensaoICMS(out cstSuspensaoICMS, out csoSuspensaoICMS);


                                    item.NfProduto.NfProdutoIcms =
                                        new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                            {
                                                NfItem = item,
                                                Cst = cstSuspensaoICMS,
                                                Origem = (OrigemMercadoria) Enum.ToObject(typeof (OrigemMercadoria), tributos.ICMSOrigem),
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
                                                SiglaUfDevidoIcms = tributos.ICMSSiglaUfDevido,
                                                ValorBcStRetidoRemetente = 0,
                                                ValorIcmsStRetidoRemetente = 0,
                                                ValorBcStRetidoDestinatario = 0,
                                                ValorIcmsStRetidoDestinatario = 0,
                                                CsoSimples = csoSuspensaoICMS,
                                                AliquotaCreditoSimples = 0,
                                                PercentualCreditoPresumido = null,
                                                PercentualLimiteCreditoPresumido = null,
                                                ObservacaoCreditoPresumido = null
                                            };

                                    break;
                            }

                            #endregion

                            #region IPI

                            switch (operacao.IncideIpi)
                            {
                                case IncidenciaImposto.NaoIncide:
                                    break;
                                case IncidenciaImposto.Incide:
                                    item.NfProduto.NfProdutoIpi =
                                        new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                            {
                                                NfItem = item,
                                                ClasseEnquadramentoCigarrosBebidas = tributos.IPIClasseEnquadramentoCigarrosBebidas,
                                                CnpjProdutor = tributos.IPICNPJProdutor,
                                                ClasseEnquadramento = tributos.IPIClasseEnquadramento,
                                                Cst = tributos.IPICst,
                                                Aliquota = tributos.IPIAliquota,
                                                ModalidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof (ModalidadeTributacao), tributos.IPIModalidadeTributacao),
                                                QuantidadeVendida = 0
                                            };
                                    break;
                                case IncidenciaImposto.Suspenso:
                                    item.NfProduto.NfProdutoIpi =
                                        new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                            {
                                                NfItem = item,
                                                ClasseEnquadramentoCigarrosBebidas = tributos.IPIClasseEnquadramentoCigarrosBebidas,
                                                CnpjProdutor = tributos.IPICNPJProdutor,
                                                ClasseEnquadramento = tributos.IPIClasseEnquadramento,
                                                Cst = operacao.IpiCstSuspenso,
                                                Aliquota = 0,
                                                ModalidadeTributacao = ModalidadeTributacao.NaoTributado,
                                                QuantidadeVendida = 0
                                            };
                                    break;
                            }

                            #endregion

                            #region Pis

                            switch (operacao.IncidePis)
                            {
                                case IncidenciaImposto.NaoIncide:
                                    throw new Exception("PIS é obrigatório.");
                                case IncidenciaImposto.Incide:
                                    item.NfProduto.NfProdutoPis =
                                        new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                            {
                                                NfItem = item,
                                                Cst = tributos.PISCst,
                                                Aliquota = tributos.PISAliquota,
                                                ModadlidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof (ModalidadeTributacao), tributos.PISModalidadeTributacao),
                                                ImpostoRetido = tributos.PISImpostoRetido
                                            };
                                    break;
                                case IncidenciaImposto.Suspenso:
                                    item.NfProduto.NfProdutoPis =
                                        new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                            {
                                                NfItem = item,
                                                Cst = operacao.PisCstSuspenso,
                                                Aliquota = 0,
                                                ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                                ImpostoRetido = 0
                                            };
                                    break;
                            }

                            #endregion

                            #region Cofins

                            switch (operacao.IncideCofins)
                            {
                                case IncidenciaImposto.NaoIncide:
                                    throw new Exception("Cofins é obrigatório.");
                                case IncidenciaImposto.Incide:
                                    item.NfProduto.NfProdutoCofins =
                                        new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                            {
                                                NfItem = item,
                                                Cst = tributos.CofinsCst,
                                                Aliquota = tributos.CofinsAliquota,
                                                ModadlidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof (ModalidadeTributacao), tributos.CofinsModalidadeTributacao),
                                                ImpostoRetido = tributos.CofinsImpostoRetido
                                            };
                                    break;
                                case IncidenciaImposto.Suspenso:
                                    item.NfProduto.NfProdutoCofins =
                                        new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                            {
                                                NfItem = item,
                                                Cst = operacao.CofinsCstSuspenso,
                                                Aliquota = 0,
                                                ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                                ImpostoRetido = 0
                                            };
                                    break;
                            }

                            #endregion

                            #region II

                            item.NfProduto.NfProdutoIimp = new NfProdutoIimpClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                                               {
                                                                   Aliquota = tributos.IIAliquota,
                                                                   ModalidadeTributacao = ModalidadeTributacao.Valor,
                                                                   NfItem = item
                                                               };

                            #endregion

                            nf.CollectionNfItemClassNfPrincipal.Add(item);

                            //Composição da obs relativa ao ICMS
                            

                            #region Cálculo dos Impostos

                             ValoresAcumuladosICMSObsKey chaveICMS = new ValoresAcumuladosICMSObsKey(tributos.ICMSAliquotaEstadoEmissor, item.NfProduto.NfProdutoIcms.ObsDiferimento, item.NfProduto.NfProdutoIcms.PercentualDiferimento);

                            if (!icmsObservacoes.ContainsKey(chaveICMS))
                            {
                                icmsObservacoes.Add(chaveICMS,new ValoresAcumuladosICMSObs());
                            }

                             ValoresAcumuladosICMSObs icmsObs = icmsObservacoes[chaveICMS];

                            double percentualDeParticipacaoDoItem = (itemAdicao.ValorTotalReais/vmcvGeral);
                            
                            double vmldProduto = percentualDeParticipacaoDoItem * di.ValorTotalReais; // (VUCV*QTD) / VMCV => % do item no valor da DI
                            valorTotalProdutosAntesII += vmldProduto;

                            NfItemTributoClass itTributo = new NfItemTributoClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                            itTributo.NfItem = item;
                            item.NfItemTributo = itTributo;

                            //Cálculo do PIS Importação
                            double valorPisImportacao = vmldProduto * (tributos.PISAliquota/100);

                            //Cálculo do COFINS Importação
                            double valorCofinsImportacao = vmldProduto * (tributos.CofinsAliquota/100);

                            //Despesas Aduaneiras (AFRMM + SISCOMEX)
                            double despesasAduaneiras = (di.TaxaAfrmm + di.TaxaSiscomex) * percentualDeParticipacaoDoItem;


                            valorTotalPisImportacao += valorPisImportacao;
                            valorTotalCofinsImportacao += valorCofinsImportacao;

                            //Cálculo do Imposto de Importação
                            itTributo.NfItemTributoIimp = new NfItemTributoIimpClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                            itTributo.NfItemTributoIimp.NfItem = item;
                            
                            itTributo.NfItemTributoIimp.ModalidadeTributacao = ModalidadeTributacao.Valor;
                            itTributo.NfItemTributoIimp.NfItem = item;
                            itTributo.NfItemTributoIimp.QuantidadeVendida = item.NfProduto.QuantidadeTributavel;
                            itTributo.NfItemTributoIimp.ValorDespesasAduaneiras = despesasAduaneiras + valorPisImportacao + valorCofinsImportacao;
                            itTributo.NfItemTributoIimp.ValorIof = 0;

                            itTributo.NfItemTributoIimp.Aliquota = item.NfProduto.NfProdutoIimp.Aliquota;
                            itTributo.NfItemTributoIimp.ValorBc = vmldProduto;
                            itTributo.NfItemTributoIimp.ValorIimp = itTributo.NfItemTributoIimp.ValorBc * (itTributo.NfItemTributoIimp.Aliquota/100);
                            
                            //Cálculo do IPI
                            itTributo.NfItemTributoIpi = new NfItemTributoIpiClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                            itTributo.NfItemTributoIpi.NfItem = item;
                            
                            itTributo.NfItemTributoIpi.ClasseEnquadramento = item.NfProduto.NfProdutoIpi.ClasseEnquadramento;
                            itTributo.NfItemTributoIpi.ClasseEnquadramentoCigarrosBebidas = item.NfProduto.NfProdutoIpi.ClasseEnquadramentoCigarrosBebidas;
                            itTributo.NfItemTributoIpi.CnpjProdutor = item.NfProduto.NfProdutoIpi.CnpjProdutor;                            
                            itTributo.NfItemTributoIpi.Cst = item.NfProduto.NfProdutoIpi.Cst;
                            itTributo.NfItemTributoIpi.ModalidadeTributacao = item.NfProduto.NfProdutoIpi.ModalidadeTributacao;
                            itTributo.NfItemTributoIpi.QuantidadeVendida = item.NfProduto.NfProdutoIpi.QuantidadeVendida;

                            //A base de cálculo do IPI é o valor do produto somado com o valor do II
                            switch (itTributo.NfItemTributoIpi.ModalidadeTributacao)
                            {
                                case ModalidadeTributacao.Valor:
                                    itTributo.NfItemTributoIpi.Aliquota = item.NfProduto.NfProdutoIpi.Aliquota;
                                    itTributo.NfItemTributoIpi.ValorBc = itTributo.NfItemTributoIimp.ValorBc + itTributo.NfItemTributoIimp.ValorIimp;
                                    itTributo.NfItemTributoIpi.ValorIpi = itTributo.NfItemTributoIpi.ValorBc*(itTributo.NfItemTributoIpi.Aliquota/100);
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    itTributo.NfItemTributoIpi.Aliquota = item.NfProduto.NfProdutoIpi.Aliquota;
                                    itTributo.NfItemTributoIpi.ValorBc = item.NfProduto.QuantidadeTributavel;
                                    itTributo.NfItemTributoIpi.ValorIpi = itTributo.NfItemTributoIpi.ValorBc*itTributo.NfItemTributoIpi.Aliquota;
                                    break;
                                case ModalidadeTributacao.NaoTributado:
                                    itTributo.NfItemTributoIpi.Aliquota = 0;
                                    itTributo.NfItemTributoIpi.ValorBc = itTributo.NfItemTributoIimp.ValorBc + itTributo.NfItemTributoIimp.ValorIimp;
                                    itTributo.NfItemTributoIpi.ValorIpi = 0;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }




                            //Cálculo do PIS
                            itTributo.NfItemTributoPis = new NfItemTributoPisClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                            itTributo.NfItemTributoPis.NfItem = item;
                            
                            itTributo.NfItemTributoPis.Cst = item.NfProduto.NfProdutoPis.Cst;
                            itTributo.NfItemTributoPis.ImpostoRetido = item.NfProduto.NfProdutoPis.ImpostoRetido;
                            itTributo.NfItemTributoPis.ModalidadeTributacao = item.NfProduto.NfProdutoPis.ModadlidadeTributacao;
                            itTributo.NfItemTributoPis.QuantidadeVendida = 0;
                            
                            itTributo.NfItemTributoPis.Aliquota = 0;
                            itTributo.NfItemTributoPis.ValorBc = 0;
                            itTributo.NfItemTributoPis.ValorPis = itTributo.NfItemTributoPis.ValorBc * (itTributo.NfItemTributoPis.Aliquota/100);


                            //Cálculo do COFINS
                            itTributo.NfItemTributoCofins = new NfItemTributoCofinsClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                            itTributo.NfItemTributoCofins.NfItem = item;

                            itTributo.NfItemTributoCofins.Cst = item.NfProduto.NfProdutoCofins.Cst;
                            itTributo.NfItemTributoCofins.ImpostoRetido = item.NfProduto.NfProdutoCofins.ImpostoRetido;
                            itTributo.NfItemTributoCofins.ModalidadeTributacao = item.NfProduto.NfProdutoCofins.ModadlidadeTributacao;
                            itTributo.NfItemTributoCofins.QuantidadeVendida = 0;

                            itTributo.NfItemTributoCofins.Aliquota = 0;
                            itTributo.NfItemTributoCofins.ValorBc = 0;
                            itTributo.NfItemTributoCofins.ValorCofins = itTributo.NfItemTributoCofins.Aliquota * (itTributo.NfItemTributoCofins.ValorBc/100);
                            
                            //Cálculo do ICMS 

                            //BC1 (Sem ICMS = VMLD + II + IPI + PIS + COFINS + SISCOMEX + AFRMM)
                            double bc1 = vmldProduto + itTributo.NfItemTributoIimp.ValorIimp + itTributo.NfItemTributoIpi.ValorIpi + valorPisImportacao + valorCofinsImportacao + despesasAduaneiras;
                            
                            //Aliquota do ICMS "por dentro"(?)
                            //Identifica o estado da aduana (local do desembaraço aduaneiro)
                            double aliquotaIcmsPorDentro = 0.0;
                            command.CommandText =
                            "SELECT mfe_aliquota " +
                            " FROM "+
                            "  public.modelo_fiscal_icms"+
                            "  INNER JOIN public.modelo_fiscal_icms_estado ON (public.modelo_fiscal_icms.id_modelo_fiscal_icms = public.modelo_fiscal_icms_estado.id_modelo_fiscal_icms)"+
                            "  INNER JOIN public.estado ON (public.modelo_fiscal_icms_estado.id_estado = public.estado.id_estado)"+
                            " WHERE"+
                            "  public.modelo_fiscal_icms.id_modelo_fiscal_icms = "+ materialFiscal.ModeloFiscalIcms.ID +" AND "+
                            "  public.estado.est_sigla = '"+ diClass.UfDesembaraco +"'";

                            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                            if (read.HasRows)
                            {
                                read.Read();
                                aliquotaIcmsPorDentro = Convert.ToDouble(read["mfe_aliquota"]);
                                read.Close();
                            }

                            //BC do ICMS
                            double bcICMS = bc1 / (1 - (aliquotaIcmsPorDentro / 100));

                            itTributo.NfItemTributoIcms = new NfItemTributoIcmsClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                            itTributo.NfItemTributoIcms.NfItem = item;

                            itTributo.NfItemTributoIcms.Origem = item.NfProduto.NfProdutoIcms.Origem;
                            itTributo.NfItemTributoIcms.CsoSimples = item.NfProduto.NfProdutoIcms.CsoSimples;
                            itTributo.NfItemTributoIcms.Cst = item.NfProduto.NfProdutoIcms.Cst;
                            itTributo.NfItemTributoIcms.ModalidadeBcIcms = item.NfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                            itTributo.NfItemTributoIcms.MotivoDesoneracaoIcms = item.NfProduto.NfProdutoIcms.MotivoDesoneracaoIcms;
                            itTributo.NfItemTributoIcms.PercentualBcOperacaoPropria = item.NfProduto.NfProdutoIcms.PercentualBcOperacaoPropria;
                            
                            //ST
                            itTributo.NfItemTributoIcms.AliquotaSt = item.NfProduto.NfProdutoIcms.AliquotaSt;                            
                            itTributo.NfItemTributoIcms.CodigoAntecipacaoSt = item.NfProduto.NfProdutoIcms.CodigoAntecipacaoSt;
                            itTributo.NfItemTributoIcms.ModalidadeBcSt = item.NfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                            itTributo.NfItemTributoIcms.PercentualMvaSt = item.NfProduto.NfProdutoIcms.PercentualMvaSt;
                            itTributo.NfItemTributoIcms.PercentualReducaoBcSt = item.NfProduto.NfProdutoIcms.PercentualReducaoBcSt;
                            itTributo.NfItemTributoIcms.ValorBcSt = 0;
                            itTributo.NfItemTributoIcms.ValorBcStRetidoDestinatario = 0;
                            itTributo.NfItemTributoIcms.ValorBcStRetidoRemetente = 0;
                            itTributo.NfItemTributoIcms.ValorIcmsSt = 0;
                            itTributo.NfItemTributoIcms.ValorIcmsStRetidoDestinatario = 0;
                            itTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente = 0;


                            itTributo.NfItemTributoIcms.Aliquota = item.NfProduto.NfProdutoIcms.Aliquota;                            
                            itTributo.NfItemTributoIcms.AliquotaCreditoSimples = item.NfProduto.NfProdutoIcms.AliquotaCreditoSimples;                            
                            itTributo.NfItemTributoIcms.SiglaUfDevidoIcms = item.NfProduto.NfProdutoIcms.SiglaUfDevidoIcms;
                            
                            //Redução da base se cálculo
                            itTributo.NfItemTributoIcms.PercentualReducaoBc = item.NfProduto.NfProdutoIcms.PercentualReducaoBc;                            
                            if(itTributo.NfItemTributoIcms.PercentualReducaoBc > 0)
                            {
                                bcICMS = bcICMS*(1 - (itTributo.NfItemTributoIcms.PercentualReducaoBc/100));
                            }
                            
                            //Calculo do ICMS Devido
                            itTributo.NfItemTributoIcms.ValorBc = bcICMS;
                            itTributo.NfItemTributoIcms.ValorCreditoIcmsSimples = item.NfProduto.NfProdutoIcms.AliquotaCreditoSimples; 
                            itTributo.NfItemTributoIcms.ValorIcms = itTributo.NfItemTributoIcms.ValorBc * (itTributo.NfItemTributoIcms.Aliquota/100);

                            icmsObs.ValorIcms += itTributo.NfItemTributoIcms.ValorIcms;
                            
                            //Diferimento
                            itTributo.NfItemTributoIcms.PercentualDiferimento = item.NfProduto.NfProdutoIcms.PercentualDiferimento;                            
                            itTributo.NfItemTributoIcms.IcmsDiferido = 0; 
                            itTributo.NfItemTributoIcms.ObsDiferimento = "";
                            if (itTributo.NfItemTributoIcms.PercentualDiferimento > 0)
                            {
                                itTributo.NfItemTributoIcms.IcmsDiferido = itTributo.NfItemTributoIcms.ValorIcms * (itTributo.NfItemTributoIcms.PercentualDiferimento / 100);
                                itTributo.NfItemTributoIcms.ObsDiferimento = itTributo.NfItemTributoIcms.ObsDiferimento;
                                itTributo.NfItemTributoIcms.ValorIcms -= itTributo.NfItemTributoIcms.IcmsDiferido;
                            }

                            //Crédito Presumido de ICMS
                            if(item.NfProduto.NfProdutoIcms.PercentualCreditoPresumido != null)
                            {
                                double? creditoPresumido = itTributo.NfItemTributoIcms.ValorIcms*(item.NfProduto.NfProdutoIcms.PercentualCreditoPresumido/100);
                                double? limiteCreditoPresumido = itTributo.NfItemTributoIcms.ValorBc*(item.NfProduto.NfProdutoIcms.PercentualLimiteCreditoPresumido/100);
                                
                                if(creditoPresumido > limiteCreditoPresumido)
                                {
                                    itTributo.NfItemTributoIcms.ValorCreditoPresumido = limiteCreditoPresumido;
                                }
                                else
                                {
                                    itTributo.NfItemTributoIcms.ValorCreditoPresumido = creditoPresumido;
                                }

                                itTributo.NfItemTributoIcms.ValorIcms -= itTributo.NfItemTributoIcms.ValorCreditoPresumido.Value;

                                itTributo.NfItemTributoIcms.ObservacaoCreditoPresumido =  item.NfProduto.NfProdutoIcms.ObservacaoCreditoPresumido;
                            }

                            icmsObs.ValorDiferido += itTributo.NfItemTributoIcms.IcmsDiferido;
                            icmsObs.ValorIcmsRecolhido += itTributo.NfItemTributoIcms.ValorIcms - (itTributo.NfItemTributoIcms.ValorCreditoPresumido.HasValue ? itTributo.NfItemTributoIcms.ValorCreditoPresumido.Value : 0);
                            icmsObs.ValorCreditoPresumido += itTributo.NfItemTributoIcms.ValorCreditoPresumido ?? 0;


                            //Outras Despesas Acessorias (PIS + COFINS + Despesas Aduaneiras)
                            item.NfProduto.OutrasDespesasAcessorias = despesasAduaneiras + valorPisImportacao + valorCofinsImportacao;

                            //Adequar o valor do produto (VMLD + II)
                            item.NfProduto.ValorTotalTributavel = vmldProduto + itTributo.NfItemTributoIimp.ValorIimp;
                            item.NfProduto.ValorUnitario = item.NfProduto.ValorTotalTributavel/item.NfProduto.Quantidade;
                            item.NfProduto.ValorUnitarioTrinutacao = item.NfProduto.ValorUnitario;
                            #endregion
                        }
                    }
                }

                #endregion

                #region Transporte

                try
                {
                    int totalVolumes = listaDIs.Sum(a => a.QtdVolumes.HasValue ? a.QtdVolumes : 0) ?? 0;
                    double pesoLiquido = listaDIs.Sum(a => a.PesoLiquido.HasValue ? a.PesoLiquido : 0) ?? 0;
                    double pesoBruto = listaDIs.Sum(a => a.PesoBruto.HasValue ? a.PesoBruto : 0) ?? 0;
                    string tipoVolume = chaveJuncaoNotas.TipoVolume;


                    nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, singleConnection)
                                          {
                                              NfPrincipal = nf,
                                              Modalidade = ModalidadeFrete.Emitente,
                                              Razao = transporte.Razao,
                                              Ie = transporte.Ie,
                                              Endereco = transporte.Endereco,
                                              SiglaUf = transporte.Cidade.Estado.Sigla,
                                              Municipio = transporte.Cidade.Nome,
                                              CpfCnpj = transporte.CpfCnpj,
                                              Volumes = totalVolumes,
                                              PesoLiquido = pesoLiquido,
                                              PesoBruto = pesoBruto,
                                              Placa = transporte.Placa != null ? transporte.Placa.Replace("-", "").Trim() : null,
                                              RegistroAntt = transporte.RegistroAntt,
                                              SiglaUfVeiculo = transporte.EstadoVeiculo.Sigla,
                                              VolumeEspecie = tipoVolume,
                                              VolumeMarca = ""
                                          };
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do transporte da NF.\r\n" + e.Message);
                }

                #endregion


                #region Totais

                NfTotaisClass totais = new NfTotaisClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                totais.NfPrincipal = nf;
                nf.NfTotais = totais;


                foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
                {
                    //ICMS
                    if (item.NfItemTributo.NfItemTributoIcms != null)
                    {
                        totais.BaseCalculoIcms += item.NfItemTributo.NfItemTributoIcms.ValorBc;
                        totais.BaseCalculoIcmsSt += item.NfItemTributo.NfItemTributoIcms.ValorBcSt;

                        totais.ValorTotalProdutosServicosIcms += item.NfProduto.ValorTotalTributavel;

                        totais.ValorTotalIcms += item.NfItemTributo.NfItemTributoIcms.ValorIcms;
                        totais.ValorTotalIcmsSt += item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt;

                        totais.ValorTotalIcmsDiferido += item.NfItemTributo.NfItemTributoIcms.IcmsDiferido;

  
                    }

                    //IPI
                    if (item.NfItemTributo.NfItemTributoIpi != null)
                    {
                        double teste = Math.Round(item.NfItemTributo.NfItemTributoIpi.ValorIpi, 2, MidpointRounding.AwayFromZero);
                        totais.ValorTotalIpi += teste;
                        totais.ValorTotalIpi = Math.Round(totais.ValorTotalIpi, 2, MidpointRounding.AwayFromZero);
                    }

                    //ISS
                    if (item.NfItemTributo.NfItemTributoIss != null)
                    {
                        totais.ValorTotalServicos += item.NfProduto.ValorTotalTributavel;
                        totais.ValorTotalIss += item.NfItemTributo.NfItemTributoIss.ValorIss;
                        totais.BaseCalculoIss += item.NfItemTributo.NfItemTributoIss.Bc;
                    }

                    //PIS
                    if (item.NfItemTributo.NfItemTributoPis != null)
                    {
                        if (item.NfItemTributo.NfItemTributoPis.ImpostoRetido == 0)
                        {
                            totais.ValorTotalPis += item.NfItemTributo.NfItemTributoPis.ValorPis;
                        }
                        else
                        {
                            totais.ValorRetidoPis += item.NfItemTributo.NfItemTributoPis.ValorPis;
                        }
                    }
                    totais.ValorTotalPisServicos += 0;

                    //COFINS
                    if (item.NfItemTributo.NfItemTributoCofins != null)
                    {
                        if (item.NfItemTributo.NfItemTributoCofins.ImpostoRetido == 0)
                        {
                            totais.ValorTotalCofins += item.NfItemTributo.NfItemTributoCofins.ValorCofins;
                        }
                        else
                        {
                            totais.ValorRetidoCofins += item.NfItemTributo.NfItemTributoCofins.ValorCofins;
                        }
                    }
                    totais.ValorTotalCofinsServicos += 0;

                    //IIMP
                    if (item.NfItemTributo.NfItemTributoIimp != null)
                    {
                        totais.ValorTotalIimp += item.NfItemTributo.NfItemTributoIimp.ValorIimp;
                    }

                    //Independentes
                    totais.ValorTotalDesconto += item.NfProduto.ValorDesconto;
                    totais.OutrasDespesas += item.NfProduto.OutrasDespesasAcessorias;
                    totais.ValorTotalDescontoIi += 0;
                    totais.ValorTotalFrete += item.NfProduto.ValorFrete;
                    totais.ValorTotalSeguro += item.NfProduto.ValorSeguro;
                }

                totais.ValorTotalNf +=
                    totais.ValorTotalProdutosServicosIcms
                    - totais.ValorTotalDesconto
                    + totais.ValorTotalIcmsSt
                    + totais.ValorTotalFrete
                    + totais.ValorTotalSeguro
                    + totais.OutrasDespesas
                    + totais.ValorTotalIimp
                    + totais.ValorTotalIpi
                    + (totais.ValorTotalServicos.HasValue ? totais.ValorTotalServicos.Value : 0);


 

                #endregion

                string obsAnterior = nf.Observacoes;

                nf.Observacoes = "T. Prod: " + valorTotalProdutosAntesII.ToString("C2", CultureInfo.CurrentCulture) + " (CIF) + " + nf.NfTotais.ValorTotalIimp.ToString("C2", CultureInfo.CurrentCulture) + "(I.I): " +
                                 nf.NfTotais.ValorTotalProdutosServicosIcms.ToString("C2", CultureInfo.CurrentCulture) + " | ";

                nf.Observacoes += "D. Acess: " + valorTotalPisImportacao.ToString("C2", CultureInfo.CurrentCulture) + " (PIS) + " + valorTotalCofinsImportacao.ToString("C2", CultureInfo.CurrentCulture) + " (Cofins) + " +
                                  listaDIs.Sum(a => a.TaxaSiscomex).ToString("C2", CultureInfo.CurrentCulture) + " (T.S) + " + listaDIs.Sum(a => a.TaxaAfrmm).ToString("C2", CultureInfo.CurrentCulture) + " (AFRMM): " +
                                  nf.NfTotais.OutrasDespesas.ToString("C2", CultureInfo.CurrentCulture) + " | ";

                foreach (KeyValuePair<ValoresAcumuladosICMSObsKey, ValoresAcumuladosICMSObs> icmsObs in icmsObservacoes.Where(a=>a.Key.PercentualDiferimento != 0))
                {
                    nf.Observacoes += "ICMS Recolhido: " + icmsObs.Value.ValorIcmsRecolhido.ToString("C2", CultureInfo.CurrentCulture) + " (Alíquota Própria(" + icmsObs.Key.AliquotaIcms + "%): " +
                                      icmsObs.Value.ValorIcms.ToString("C2", CultureInfo.CurrentCulture) + " - Diferimento (" + icmsObs.Key.PercentualDiferimento + "%):" + icmsObs.Value.ValorDiferido.ToString("C2", CultureInfo.CurrentCulture) + " - " + 
                                      "Crédito Presumido: "+icmsObs.Value.ValorCreditoPresumido.ToString("C2", CultureInfo.CurrentCulture) +") | ";
                }

                if (nf.CollectionNfItemClassNfPrincipal.Any(a=>a.NfItemTributo.NfItemTributoIcms!=null && a.NfItemTributo.NfItemTributoIcms.ValorCreditoPresumido != 0 ))
                {
                    IEnumerable<IGrouping<string, NfItemClass>> aaa = nf.CollectionNfItemClassNfPrincipal.GroupBy(a => a.NfItemTributo.NfItemTributoIcms.ObservacaoCreditoPresumido);
                    Dictionary<string, List<NfItemClass>> bbb = aaa.ToDictionary(g => g.Key, g => g.ToList());
                    foreach ( KeyValuePair<string, List<NfItemClass>> nfItemClasses in bbb)
                    {
                        nf.Observacoes += "Crédito Presumido: " + nfItemClasses.Value.Sum(a => a.NfItemTributo.NfItemTributoIcms.ValorCreditoPresumido).Value.ToString("C2", CultureInfo.CurrentCulture) + " " + nfItemClasses.Key + " | ";
                    }
                }

                nf.Observacoes += "D.I: ";
                foreach (DeclaracaoImportacaoClass di in listaDIs)
                {
                    nf.Observacoes += di.Numero + " ";
                }
                nf.Observacoes += " | ";


                foreach (KeyValuePair<ValoresAcumuladosICMSObsKey, ValoresAcumuladosICMSObs> icmsObs in icmsObservacoes.Where(a => a.Key.PercentualDiferimento != 0))
                {
                    nf.Observacoes += icmsObs.Key.ObsDiferimento + " | ";
                }

                nf.Observacoes += obsAnterior;

                //Visualiza a NF
                VisualNFeForm form = new VisualNFeForm(nf, "-1", VisualNFeFormUtilizacao.Aceite);
                form.ShowDialog();
                if (form.NFeRecusada)
                {
                    return null;
                }

                try
                {
                    nf.Save(ref command);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao salvar a NF.\r\n" + e.Message);
                }
                return nf;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao gerar nota fiscal de importação para o fornecedor " + fornecedor.ToString() + "\r\n" + e.Message, e);
            }
        }

        class NotaFiscalImportacaoKeyClass : IEquatable<NotaFiscalImportacaoKeyClass>
        {
            public FornecedorClass Fornecedor { get; private set; }
            public string TipoVolume { get; private set; }

            public NotaFiscalImportacaoKeyClass(FornecedorClass fornecedor, string tipoVolume)
            {
                this.Fornecedor = fornecedor;
                TipoVolume = tipoVolume;
            }

            public bool Equals(NotaFiscalImportacaoKeyClass other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(other.Fornecedor, Fornecedor) && Equals(other.TipoVolume, TipoVolume);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (NotaFiscalImportacaoKeyClass)) return false;
                return Equals((NotaFiscalImportacaoKeyClass) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Fornecedor != null ? Fornecedor.GetHashCode() : 0)*397) ^ (TipoVolume != null ? TipoVolume.GetHashCode() : 0);
                }
            }

            public static bool operator ==(NotaFiscalImportacaoKeyClass left, NotaFiscalImportacaoKeyClass right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(NotaFiscalImportacaoKeyClass left, NotaFiscalImportacaoKeyClass right)
            {
                return !Equals(left, right);
            }
        }

        class ValoresAcumuladosICMSObs
        {
            public double ValorIcmsRecolhido { get; set; }
            public double ValorIcms { get; set; }
            public double ValorDiferido { get; set; }
            public double ValorCreditoPresumido { get; set; }
        }

        private class ValoresAcumuladosICMSObsKey : IEquatable<ValoresAcumuladosICMSObsKey>
        {
            public double AliquotaIcms { get; private set; }
            public double PercentualDiferimento { get; private set; }
            public string ObsDiferimento { get; private set; }

            public ValoresAcumuladosICMSObsKey(double aliquotaIcms, string obsDiferimento, double percentualDiferimento)
            {
                AliquotaIcms = aliquotaIcms;
                ObsDiferimento = obsDiferimento;
                PercentualDiferimento = percentualDiferimento;
            }

            public bool Equals(ValoresAcumuladosICMSObsKey other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other.AliquotaIcms.Equals(AliquotaIcms) && other.PercentualDiferimento.Equals(PercentualDiferimento) && Equals(other.ObsDiferimento, ObsDiferimento);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (ValoresAcumuladosICMSObsKey)) return false;
                return Equals((ValoresAcumuladosICMSObsKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int result = AliquotaIcms.GetHashCode();
                    result = (result*397) ^ PercentualDiferimento.GetHashCode();
                    result = (result*397) ^ (ObsDiferimento != null ? ObsDiferimento.GetHashCode() : 0);
                    return result;
                }
            }

            public static bool operator ==(ValoresAcumuladosICMSObsKey left, ValoresAcumuladosICMSObsKey right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(ValoresAcumuladosICMSObsKey left, ValoresAcumuladosICMSObsKey right)
            {
                return !Equals(left, right);
            }
        }
    }

     
}
