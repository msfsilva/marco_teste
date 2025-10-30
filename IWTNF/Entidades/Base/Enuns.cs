using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using IWTFunctions;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using IWTNF.Entidades.Base;
namespace IWTNF.Entidades.Base
{
    [Serializable()]
    public enum IWTNFIndicadorIE { ContribuinteICMS = 0, Isento = 1, NaoContribuinte = 2}

    [Serializable()]
    public enum ModalidadeTributacao { Valor = 0, Quantidade = 1, NaoTributado = 2}

    [Serializable()]
    public enum ModalidadeDeterminacaoBCICMSST { PrecoTabelado = 0, ListaNegativa = 1, ListaPositiva = 2, ListaNeutra = 3, MargemValorAgregado = 4, Pauta = 5}

    [Serializable()]
    public enum OrigemMercadoria { Nacional = 0, EstrangeiraImportacaoDireta = 1, EstrangeiraMercadoInterno = 2, NacionalComImportacao40a70 = 3, NacionalProducaoEmConformidade = 4, NacionalComImportacaoAte40 = 5, EstrangeiraImportacaoDiretaNaCamex = 6, EstrangeiraMercadoInternoNaCamex = 7, NacionalComImportacaoAcima70 = 8}

    [Serializable()]
    public enum ModalidadeDeterminacaoBCICMS { MargemValorAgregado = 0, Pauta = 1, PrecoTabeladoMax = 2, ValorOperacao = 3}

    [Serializable()]
    public enum NfPagamentoTipo { BoletoBancario = 15, SemPagamento = 90, Dinheiro = 1, Cheque = 2, CartaoCredito = 3, CartaoDebito = 4, CreditoLoja = 5, ValeAlimentacao = 10, Outros = 99, ValeRefeicao = 11, ValePresente = 12, ValeCombustivel = 13, DepositoBancario = 16, Pix = 17, TransferenciaBancaria = 18, ProgramaFidelidade = 19}

    [Serializable()]
    public enum NfPagamentoBandeira { Diners = 5, Elo = 6, Hipercard = 7, Aura = 8, Cabal = 9, Visa = 1, Mastercard = 2, American = 3, Sorocred = 4, Outros = 99}

    [Serializable()]
    public enum NfPagamentoTipoIntegracao { Integrado = 1, NaoIntegrado = 2}

    [Serializable()]
    public enum TipoNota { Entrada = 0, Saida = 1}

    [Serializable()]
    public enum Processo { AplicativoContribuinte = 0, AvulsaFisco = 1, AvulsaSiteFisco = 2, ContribuinteAplicativoFisco = 3}

    [Serializable()]
    public enum FormatoImpressao { Retrato = 1, Paisagem = 2}

    [Serializable()]
    public enum FormaEmissaoNFe { Normal = 1, ContingenciaScan = 3}

    [Serializable()]
    public enum Finalidade { Complementar = 2, Ajuste = 3, Normal = 1, DevolucaoMercadoria = 4}

    [Serializable()]
    public enum PresencaComprador { ForaEstabelecimento = 5, NFCeEntregaDomicilio = 4, NaoAplicavel = 0, Presencial = 1, Internet = 2, Teleatendimento = 3, NaoPresencialOutros = 9}

    [Serializable()]
    public enum FormaPagamento { AVista = 0, APrazo = 1, Outros = 2}

    [Serializable()]
    public enum NfeTipoProdutoEspecifico { Comum = 0, Medicamento = 1}

    [Serializable()]
    public enum ModalidadeFrete { ProprioRemetente = 3, ProprioDestinatario = 4, Teceiros = 2, SemFrete = 9, Emitente = 0, Destinatario = 1}

public class EnumHelperClass
{
   public static List<LoadClass> GetEnumOptionsList(Type enumType)
   {
       List<LoadClass> retorno = null;
       switch (enumType.Name)
       {
           case "IWTNFIndicadorIE":
retorno = new List<LoadClass>(){
new LoadClass("0", "ContribuinteICMS"),new LoadClass("1", "Isento"),new LoadClass("2", "NaoContribuinte"),};break;
case "ModalidadeTributacao":
retorno = new List<LoadClass>(){
new LoadClass("0", "Valor"),new LoadClass("1", "Quantidade"),new LoadClass("2", "NaoTributado"),};break;
case "ModalidadeDeterminacaoBCICMSST":
retorno = new List<LoadClass>(){
new LoadClass("0", "PrecoTabelado"),new LoadClass("1", "ListaNegativa"),new LoadClass("2", "ListaPositiva"),new LoadClass("3", "ListaNeutra"),new LoadClass("4", "MargemValorAgregado"),new LoadClass("5", "Pauta"),};break;
case "OrigemMercadoria":
retorno = new List<LoadClass>(){
new LoadClass("0", "Nacional"),new LoadClass("1", "EstrangeiraImportacaoDireta"),new LoadClass("2", "EstrangeiraMercadoInterno"),new LoadClass("3", "NacionalComImportacao40a70"),new LoadClass("4", "NacionalProducaoEmConformidade"),new LoadClass("5", "NacionalComImportacaoAte40"),new LoadClass("6", "EstrangeiraImportacaoDiretaNaCamex"),new LoadClass("7", "EstrangeiraMercadoInternoNaCamex"),new LoadClass("8", "NacionalComImportacaoAcima70"),};break;
case "ModalidadeDeterminacaoBCICMS":
retorno = new List<LoadClass>(){
new LoadClass("0", "MargemValorAgregado"),new LoadClass("1", "Pauta"),new LoadClass("2", "PrecoTabeladoMax"),new LoadClass("3", "ValorOperacao"),};break;
case "NfPagamentoTipo":
retorno = new List<LoadClass>(){
new LoadClass("15", "BoletoBancario"),new LoadClass("90", "SemPagamento"),new LoadClass("1", "Dinheiro"),new LoadClass("2", "Cheque"),new LoadClass("3", "CartaoCredito"),new LoadClass("4", "CartaoDebito"),new LoadClass("5", "CreditoLoja"),new LoadClass("10", "ValeAlimentacao"),new LoadClass("99", "Outros"),new LoadClass("11", "ValeRefeicao"),new LoadClass("12", "ValePresente"),new LoadClass("13", "ValeCombustivel"),new LoadClass("16", "DepositoBancario"),new LoadClass("17", "Pix"),new LoadClass("18", "TransferenciaBancaria"),new LoadClass("19", "ProgramaFidelidade"),};break;
case "NfPagamentoBandeira":
retorno = new List<LoadClass>(){
new LoadClass("5", "Diners"),new LoadClass("6", "Elo"),new LoadClass("7", "Hipercard"),new LoadClass("8", "Aura"),new LoadClass("9", "Cabal"),new LoadClass("1", "Visa"),new LoadClass("2", "Mastercard"),new LoadClass("3", "American"),new LoadClass("4", "Sorocred"),new LoadClass("99", "Outros"),};break;
case "NfPagamentoTipoIntegracao":
retorno = new List<LoadClass>(){
new LoadClass("1", "Integrado"),new LoadClass("2", "NaoIntegrado"),};break;
case "TipoNota":
retorno = new List<LoadClass>(){
new LoadClass("0", "Entrada"),new LoadClass("1", "Saida"),};break;
case "Processo":
retorno = new List<LoadClass>(){
new LoadClass("0", "AplicativoContribuinte"),new LoadClass("1", "AvulsaFisco"),new LoadClass("2", "AvulsaSiteFisco"),new LoadClass("3", "ContribuinteAplicativoFisco"),};break;
case "FormatoImpressao":
retorno = new List<LoadClass>(){
new LoadClass("1", "Retrato"),new LoadClass("2", "Paisagem"),};break;
case "FormaEmissaoNFe":
retorno = new List<LoadClass>(){
new LoadClass("1", "Normal"),new LoadClass("3", "ContingenciaScan"),};break;
case "Finalidade":
retorno = new List<LoadClass>(){
new LoadClass("2", "Complementar"),new LoadClass("3", "Ajuste"),new LoadClass("1", "Normal"),new LoadClass("4", "DevolucaoMercadoria"),};break;
case "PresencaComprador":
retorno = new List<LoadClass>(){
new LoadClass("5", "ForaEstabelecimento"),new LoadClass("4", "NFCeEntregaDomicilio"),new LoadClass("0", "NaoAplicavel"),new LoadClass("1", "Presencial"),new LoadClass("2", "Internet"),new LoadClass("3", "Teleatendimento"),new LoadClass("9", "NaoPresencialOutros"),};break;
case "FormaPagamento":
retorno = new List<LoadClass>(){
new LoadClass("0", "AVista"),new LoadClass("1", "APrazo"),new LoadClass("2", "Outros"),};break;
case "NfeTipoProdutoEspecifico":
retorno = new List<LoadClass>(){
new LoadClass("0", "Comum"),new LoadClass("1", "Medicamento"),};break;
case "ModalidadeFrete":
retorno = new List<LoadClass>(){
new LoadClass("3", "ProprioRemetente"),new LoadClass("4", "ProprioDestinatario"),new LoadClass("2", "Teceiros"),new LoadClass("9", "SemFrete"),new LoadClass("0", "Emitente"),new LoadClass("1", "Destinatario"),};break;
           default:
                throw new ExcecaoTratada("O Enum "+enumType.Name+" não está registrado no gerador de classes.A utilização de GetEnumOptionsList depende deste registro.");
       }
       if (retorno == null){
           throw new ExcecaoTratada("O Enum "+enumType.Name+" não possui opções registradas no gerador de classes.");
       }
        return retorno;
   }
}
}
