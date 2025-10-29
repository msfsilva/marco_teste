using System;
using System.Collections.Generic;
using System.Globalization;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;

namespace BibliotecaEntidades.Operacoes.VisualizacaoNf
{
    public class NfeReportClass
    {
        public int NumeroNFe { get; set; }
        public string NaturezaOperacao { get; set; }

        public string DestinatarioNome { get; set; }
        public string DestinatarioCnpj { get; set; }
        public string DestinatarioEndereco { get; set; }
        public string DestinatarioBairro { get; set; }
        public string DestinatarioCep { get; set; }
        public string DestinatarioCidade { get; set; }
        public string DestinatarioFone { get; set; }
        public string DestinatarioUf { get; set; }
        public string DestinatarioIe { get; set; }

        public double TotalBcIcms { get; set; }
        public double TotalIcms { get; set; }
        public double TotalBcIcmsst { get; set; }
        public double TotalIcmsst { get; set; }
        public double TotalProdutos { get; set; }
        public double TotalFrete { get; set; }
        public double TotalSeguro { get; set; }
        public double TotalDesconto { get; set; }
        public double TotalOutras { get; set; }
        public double TotalIpi { get; set; }
        public double TotalNFe { get; set; }

        public string TransporteRazao { get; set; }
        public string TransporteFretePorConta { get; set; }
        public string TransporteCodAntt { get; set; }
        public string TransporteVeiculoPlaca { get; set; }
        public string TransporteVeiculoUf { get; set; }
        public string TransporteCnpj { get; set; }
        public string TransporteEndereco { get; set; }
        public string TransporteCidade { get; set; }
        public string TransporteUf { get; set; }
        public string TransporteIe { get; set; }
        public string TransporteQuantidade { get; set; }
        public string TransporteEspecie { get; set; }
        public string TransporteMarca { get; set; }
        public string TransporteNumero { get; set; }
        public double TransportePesoBruto { get; set; }
        public double TransportePesoLiquido { get; set; }


        public string InformacoesComplementares { get; set; }

        public int idEmbarque { get; set; }

        public List<NfeItemReportClass> Itens { get; set; }

        public string EmissorRazao { get; set; }


        public NfeReportClass(NfPrincipalClass nf, int idEmbarque)
        {
            this.NumeroNFe = nf.Numero;
            this.NaturezaOperacao = nf.NaturezaOperacao;

            this.DestinatarioNome = nf.NfCliente.Razao;
            this.DestinatarioCnpj = nf.NfCliente.CnpjCpf;
            this.DestinatarioEndereco = nf.NfCliente.NfClienteEndereco.Logradouro + ", " + nf.NfCliente.NfClienteEndereco.Numero + " " + nf.NfCliente.NfClienteEndereco.Complemento;
            this.DestinatarioBairro = nf.NfCliente.NfClienteEndereco.Bairro;
            this.DestinatarioCep = nf.NfCliente.NfClienteEndereco.Cep;
            this.DestinatarioCidade = nf.NfCliente.NfClienteEndereco.NomeMunicipio;
            this.DestinatarioFone = nf.NfCliente.NfClienteEndereco.Telefone;
            this.DestinatarioUf = nf.NfCliente.NfClienteEndereco.SiglaUf;
            this.DestinatarioIe = nf.NfCliente.Ie;

            this.TotalBcIcms = nf.NfTotais.BaseCalculoIcms;
            this.TotalIcms = nf.NfTotais.ValorTotalIcms;
            this.TotalBcIcmsst = nf.NfTotais.BaseCalculoIcmsSt;
            this.TotalIcmsst = nf.NfTotais.ValorTotalIcmsSt;
            this.TotalProdutos = nf.NfTotais.ValorTotalProdutosServicosIcms;
            this.TotalFrete = nf.NfTotais.ValorTotalFrete;
            this.TotalSeguro = nf.NfTotais.ValorTotalSeguro;
            this.TotalDesconto = nf.NfTotais.ValorTotalDesconto;
            this.TotalOutras = nf.NfTotais.OutrasDespesas;
            this.TotalIpi = nf.NfTotais.ValorTotalIpi;
            this.TotalNFe = nf.NfTotais.ValorTotalNf;

            if (nf.NfTransporte != null)
            {
                this.TransporteRazao = nf.NfTransporte.Razao;

                switch (nf.NfTransporte.Modalidade)
                {


                    case ModalidadeFrete.Emitente:
                        this.TransporteFretePorConta = "0 - EMITENTE";
                        break;
                    case ModalidadeFrete.Destinatario:
                        this.TransporteFretePorConta = "1 - DESTINATÁRIO";
                        break;
                    case ModalidadeFrete.Teceiros:
                        this.TransporteFretePorConta = "2 - TERCEIROS";
                        break;
                    case ModalidadeFrete.SemFrete:
                        this.TransporteFretePorConta = "9 - SEM FRETE";
                        break;

                }


                this.TransporteCodAntt = nf.NfTransporte.RegistroAntt;
                this.TransporteVeiculoPlaca = nf.NfTransporte.Placa;
                this.TransporteVeiculoUf = nf.NfTransporte.SiglaUfVeiculo;
                this.TransporteCnpj = nf.NfTransporte.CpfCnpj;
                this.TransporteEndereco = nf.NfTransporte.Endereco;
                this.TransporteCidade = nf.NfTransporte.Municipio;
                this.TransporteUf = nf.NfTransporte.SiglaUf;
                this.TransporteIe = nf.NfTransporte.Ie;
                this.TransporteQuantidade = nf.NfTransporte.Volumes.ToString();
                this.TransporteEspecie = "Volumes";
                this.TransporteMarca = "";
                this.TransporteNumero = "";
                this.TransportePesoBruto = nf.NfTransporte.PesoBruto ?? 0;
                this.TransportePesoLiquido = nf.NfTransporte.PesoLiquido ?? 0;
            }

            this.InformacoesComplementares = nf.Observacoes;
            this.InformacoesComplementares += " " + nf.ObservacoesFisco;
            if (nf.NfCobranca!=null)
            {
                if (nf.NfCobranca.NfFatura!=null)
                {
                    this.InformacoesComplementares += " FATURA: " + nf.NfCobranca.NfFatura.Numero + " - " + nf.NfCobranca.NfFatura.ValorLiquido.ToString("C", CultureInfo.CurrentCulture);
                }

                if (nf.NfCobranca.CollectionNfDuplicataClassNfCobranca != null && nf.NfCobranca.CollectionNfDuplicataClassNfCobranca.Count > 0)
                {
                    this.InformacoesComplementares += " DUPLICATAS: ";
                    foreach (NfDuplicataClass duplicata in nf.NfCobranca.CollectionNfDuplicataClassNfCobranca)
                    {
                        this.InformacoesComplementares += duplicata.Numero + " (" + duplicata.Vencimento.ToString("dd/MM/yyyy") + " - " + duplicata.Valor.ToString("C", CultureInfo.CurrentCulture) + ") ";
                    }
                    
                }
            }


            this.Itens = new List<NfeItemReportClass>();

            foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
            {
                this.Itens.Add(
                    new NfeItemReportClass()
                        {
                            AliquotaIcms = item.NfItemTributo.NfItemTributoIcms != null ? item.NfItemTributo.NfItemTributoIcms.Aliquota : 0,
                            AliquotaIpi = item.NfItemTributo.NfItemTributoIpi != null ? item.NfItemTributo.NfItemTributoIpi.Aliquota : 0,
                            BcIcms = item.NfItemTributo.NfItemTributoIcms != null ? item.NfItemTributo.NfItemTributoIcms.ValorBc : 0,
                            Cfop = item.Cfop,
                            Codigo = item.NfProduto.Codigo,

                            Desconto = item.NfProduto.ValorDesconto,
                            Descricao = item.NfProduto.Descricao,
                            Ncm = item.NfProduto.Ncm,
                            Quantidade = item.NfProduto.QuantidadeTributavel,
                            Un = item.NfProduto.UnidadeTributacao,
                            ValorIcms = item.NfItemTributo.NfItemTributoIcms != null ? item.NfItemTributo.NfItemTributoIcms.ValorIcms : 0,
                            ValorIpi = item.NfItemTributo.NfItemTributoIpi != null ? item.NfItemTributo.NfItemTributoIpi.ValorIpi : 0,
                            ValorTotal = item.NfProduto.ValorTotalTributavel,
                            ValorUnitario = item.NfProduto.ValorUnitarioTrinutacao,
                            ValorPis = item.NfItemTributo.NfItemTributoPis != null ? item.NfItemTributo.NfItemTributoPis.ValorPis : 0,
                            ValorCofins = item.NfItemTributo.NfItemTributoCofins != null ? item.NfItemTributo.NfItemTributoCofins.ValorCofins : 0,
                            AliquotaPis = item.NfItemTributo.NfItemTributoPis != null ? item.NfItemTributo.NfItemTributoPis.Aliquota : 0,
                            AliquotaCofins = item.NfItemTributo.NfItemTributoCofins != null ? item.NfItemTributo.NfItemTributoCofins.Aliquota : 0,

                            AliquotaII = item.NfItemTributo.NfItemTributoIimp != null ? item.NfItemTributo.NfItemTributoIimp.Aliquota : 0,
                            ValorII = item.NfItemTributo.NfItemTributoIimp != null ? item.NfItemTributo.NfItemTributoIimp.ValorIimp : 0
                        }
                    );
                if (item.NfItemTributo.NfItemTributoIcms != null)
                {
                    if (item.NfItemTributo.NfItemTributoIcms.Cst!="SN")
                    {
                        this.Itens[this.Itens.Count - 1].Cst = Convert.ToInt16(item.NfItemTributo.NfItemTributoIcms.Origem) + "" + item.NfItemTributo.NfItemTributoIcms.Cst;
                    }
                    else
                    {
                        this.Itens[this.Itens.Count - 1].Cst = item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString();
                    }
                    
                }
                
            }

            this.idEmbarque = idEmbarque;
            EmissorRazao = nf.NfEmitente.Razao;

        }
    }

    public class NfeItemReportClass
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Ncm { get; set; }
        public string Cst { get; set; }
        public int Cfop { get; set; }
        public string Un { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double Desconto { get; set; }
        public double ValorTotal { get; set; }
        public double BcIcms { get; set; }
        public double ValorIcms { get; set; }
        public double ValorIpi { get; set; }
        public double AliquotaIcms { get; set; }
        public double AliquotaIpi { get; set; }

        public double ValorPis { get; set; }
        public double ValorCofins { get; set; }
        public double AliquotaPis { get; set; }
        public double AliquotaCofins { get; set; }

        public double AliquotaII { get; set; }
        public double ValorII { get; set; }




    }


}
