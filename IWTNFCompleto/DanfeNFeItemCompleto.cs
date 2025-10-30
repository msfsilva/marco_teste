using System;
using System.Collections.Generic;

namespace IWTNFCompleto
{
    public class DanfeNFeItemCompleto
    {
        private DanfeNFeItemClass item;
        private DanfeNFeClass nfe;
        public int NumeroPagina { get; private set; }
        public int TotalPagina { get; private set; }

        #region Principal/NFe

        public string DfeChaveAcesso
        {
            get { return nfe.DfeChaveAcesso; }
        }

        public string DfeNumeroNFe
        {
            get { return nfe.DfeNumeroNFe; }
        }

        public string DfeSerieNFe
        {
            get { return nfe.DfeSerieNFe; }
        }

        public string DfeTipoNFe
        {
            get { return nfe.DfeTipoNFe; }
        }

        public string DfeNaturezaOperacao
        {
            get { return nfe.DfeNaturezaOperacao; }
        }

        public string DfeProtocoloAutorizacaoUso
        {
            get { return nfe.DfeProtocoloAutorizacaoUso; }
        }

        public byte[] Barcode
        {
            get { return nfe.Barcode; }
        }

        #endregion

        #region Emitente

        public string EmitRazaoSocial
        {
            get { return nfe.EmitRazaoSocial; }
        }

        public string EmitIncricaoEstadual
        {
            get { return nfe.EmitIncricaoEstadual; }
        }

        public string EmitIncricaoEstadualST
        {
            get { return nfe.EmitIncricaoEstadualST; }
        }

        public string EmitCNPJ
        {
            get { return nfe.EmitCNPJ; }
        }

        public string EmitEndereco
        {
            get { return nfe.EmitEndereco; }
        }

        public string EmitEndNumero
        {
            get { return nfe.EmitEndNumero; }
        }

        public string EmitEndComplemento
        {
            get { return nfe.EmitEndComplemento; }
        }

        public string EmitBairro
        {
            get { return nfe.EmitBairro; }
        }

        public string EmitCidade
        {
            get { return nfe.EmitCidade; }
        }

        public string EmitUF
        {
            get { return nfe.EmitUF; }
        }

        public string EmitPais
        {
            get { return nfe.EmitPais; }
        }

        public string EmitCEP
        {
            get { return nfe.EmitCEP; }
        }

        public string EmitFone
        {
            get { return nfe.EmitFone; }
        }

        public string EmitFax
        {
            get { return nfe.EmitFax; }
        }

        public byte[] EmitLogo
        {
            get { return nfe.EmitLogo; }
        }

        #endregion

        #region Destinatário/Remetente

        public string RemetRazaoSocial
        {
            get { return nfe.RemetRazaoSocial; }
        }

        public string RemetCnpjCpf
        {
            get { return nfe.RemetCnpjCpf; }
        }

        public DateTime RemetDataEmissao
        {
            get { return nfe.RemetDataEmissao; }
        }

        public string RemetEndereco
        {
            get { return nfe.RemetEndereco; }
        }

        public string RemetEndNumero
        {
            get { return nfe.RemetEndNumero; }
        }

        public string RemetBairro
        {
            get { return nfe.RemetBairro; }
        }

        public string RemetCEP
        {
            get { return nfe.RemetCEP; }
        }

        public string RemetDataEntradaSaida
        {
            get { return nfe.RemetDataEntradaSaida; }
        }

        public string RemetCidade
        {
            get { return nfe.RemetCidade; }
        }

        public string RemetFoneFax
        {
            get { return nfe.RemetFoneFax; }
        }

        public string RemetUF
        {
            get { return nfe.RemetUF; }
        }

        public string RemetIE
        {
            get { return nfe.RemetIE; }
        }

        public string RemetHoraSaida
        {
            get { return nfe.RemetHoraSaida; }
        }

        #endregion

        #region Fatura/Duplicatas

        public string FatNumero
        {
            get { return nfe.FatNumero; }
        }

        public string FatValorOriginal
        {
            get { return nfe.FatValorOriginal; }
        }

        //double
        public string FatValorDesconto
        {
            get { return nfe.FatValorDesconto; }
        }

        //double
        public string FatValorLiquido
        {
            get { return nfe.FatValorLiquido; }
        }

        //double

        public List<DanfeNFeDuplicataClass> DfeDuplicatas
        {
            get { return nfe.DfeDuplicatas; }
        }

        #endregion

        #region Cálculo do Imposto

        public double ImpBcIcms
        {
            get { return nfe.ImpBcIcms; }
        }

        public double ImpValorIcms
        {
            get { return nfe.ImpValorIcms; }
        }

        public double ImpBcIcmsSt
        {
            get { return nfe.ImpBcIcmsSt; }
        }

        public double ImpValorIcmsSt
        {
            get { return nfe.ImpValorIcmsSt; }
        }

        public double ImpValorTotalProdutos
        {
            get { return nfe.ImpValorTotalProdutos; }
        }

        public double ImpValorFrete
        {
            get { return nfe.ImpValorFrete; }
        }

        public double ImpValorSeguro
        {
            get { return nfe.ImpValorSeguro; }
        }

        public double ImpDesconto
        {
            get { return nfe.ImpDesconto; }
        }

        public double ImpOutrasDespesas
        {
            get { return nfe.ImpOutrasDespesas; }
        }

        public double ImpValorTotalIpi
        {
            get { return nfe.ImpValorTotalIpi; }
        }

        public double ImpValorTotalNF
        {
            get { return nfe.ImpValorTotalNF; }
        }

        #endregion

        #region Transportador/Volumes Trasportados

        public string TranspRazaoSocial
        {
            get { return nfe.TranspRazaoSocial; }
        }

        public string TranspResponsavelFrete
        {
            get { return nfe.TranspResponsavelFrete; }
        }

        public string TranspCodigoANTT
        {
            get { return nfe.TranspCodigoANTT; }
        }

        public string TranspPlacaVeiculo
        {
            get { return nfe.TranspPlacaVeiculo; }
        }

        public string TranspPlacaVeiculoUF
        {
            get { return nfe.TranspPlacaVeiculoUF; }
        }

        public string TranspCnpjCpf
        {
            get { return nfe.TranspCnpjCpf; }
        }

        public string TranspEndereco
        {
            get { return nfe.TranspEndereco; }
        }

        public string TranspCidade
        {
            get { return nfe.TranspCidade; }
        }

        public string TranspUF
        {
            get { return nfe.TranspUF; }
        }

        public string TranspIE
        {
            get { return nfe.TranspIE; }
        }

        public string TranspQuantidade
        {
            get { return nfe.TranspQuantidade; }
        }

        public string TranspEspecie
        {
            get { return nfe.TranspEspecie; }
        }

        public string TranspMarca
        {
            get { return nfe.TranspMarca; }
        }

        public string TranspNumeracao
        {
            get { return nfe.TranspNumeracao; }
        }

        public string TranspPesoBruto
        {
            get { return nfe.TranspPesoBruto; }
        }

        public string TranspPesoLiquido
        {
            get { return nfe.TranspPesoLiquido; }
        }

        #endregion

        #region Dados do Produto/Serviços

        public string ItemCodigo
        {
            get { return item.ItemCodigo; }
        }

        public string ItemDescricao
        {
            get { return item.ItemDescricao; }
        }

        public string ItemDescricaoAdicional
        {
            get { return item.ItemDescricaoAdicional; }
        }

        public string ItemNCM
        {
            get { return item.ItemNCM; }
        }

        public string ItemCST
        {
            get { return item.ItemCST; }
        }

        public string ItemCFOP
        {
            get { return item.ItemCFOP; }
        }

        public string ItemUnidade
        {
            get { return item.ItemUnidade; }
        }

        public double ItemQuantidade
        {
            get { return item.ItemQuantidade; }
        }

        public double ItemValorUnitario
        {
            get { return item.ItemValorUnitario; }
        }

        public string ItemDesconto
        {
            get { return item.ItemDesconto; }
        }

        public double ItemValorTotal
        {
            get { return item.ItemValorTotal; }
        }

        public string ItemBcIcms
        {
            get { return item.ItemBcIcms; }
        }

        public string ItemBcIcmsSt
        {
            get { return item.ItemBcIcmsSt; }
        }

        public string ItemValorIcms
        {
            get { return item.ItemValorIcms; }
        }

        public string ItemValorIcmsSt
        {
            get { return item.ItemValorIcmsSt; }
        }

        public string ItemValorIpi
        {
            get { return item.ItemValorIpi; }
        }

        public string ItemAliquotaIcms
        {
            get { return item.ItemAliquotaIcms; }
        }

        public string ItemAliquotaIpi
        {
            get { return item.ItemAliquotaIpi; }
        }

        #endregion

        #region ISSQN

        public string IssInscricaoMunicipal
        {
            get { return nfe.IssInscricaoMunicipal; }
        }

        public string IssValorTotalServicos
        {
            get { return nfe.IssValorTotalServicos; }
        }

        public string IssBCIssqn
        {
            get { return nfe.IssBCIssqn; }
        }

        public string IssValorIssqn
        {
            get { return nfe.IssValorIssqn; }
        }

        #endregion

        #region Dados Adicionais

        public string DfeInformacoesComplementares
        {
            get { return nfe.DfeInformacoesComplementares; }
        }

        public string DfeReservadoFisco
        {
            get { return nfe.DfeReservadoFisco; }
        }

        #endregion

        public DanfeNFeItemCompleto(DanfeNFeClass nfe, DanfeNFeItemClass item, int numeroPagina, int totalPagina)
        {
            this.nfe = nfe;
            this.item = item;
            this.NumeroPagina = numeroPagina;
            this.TotalPagina = totalPagina;
        }
    }
}