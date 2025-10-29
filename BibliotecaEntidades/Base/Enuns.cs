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
using BibliotecaEntidades.Base;
namespace BibliotecaEntidades.Base
{
    [Serializable()]
    public enum EASITipoConsumoEstoque { MateriaPrima = 0, Consumo = 1, Escolher = 2}

    [Serializable()]
    public enum EasiSituacaoBudget { EmElaboracao = 0, Aprovado = 1, EmRevisao = 2}

    [Serializable()]
    public enum BufferEmailSituacao { Pendente = 0, Enviado = 1, Erro = 2}

    [Serializable()]
    public enum CentroCustoLucroNatureza { Neutro = -1, Custo = 0, Lucro = 1}

    [Serializable()]
    public enum EasiConfiguracaoAutomaticaReferencia { DataCadastro = 0, DataEntrega = 1}

    [Serializable()]
    public enum ClienteTipoDimensionamentoVolumetrico { Cubagem = 0, Dimensoes = 1}

    [Serializable()]
    public enum ResponsavelFrete { ProprioRemetente = 3, ProprioDestinatario = 4, Emitente = 0, Cliente = 1, Terceiros = 2, SemFrete = 9}

    [Serializable()]
    public enum IWTNFIndicadorIE { ContribuinteICMS = 0, Isento = 1, NaoContribuinte = 2}

    [Serializable()]
    public enum CobrancaStatusBoleto { GeradoNaoEnviado = 0, EnviadoAgConfirmacao = 1, ConfirmadoEmCarteira = 2, Rejeitado = 3, Pago = 4, Cancelado = 5}

    [Serializable()]
    public enum CobrancaTipoDocumento { CPF = 1, CNPJ = 2}

    [Serializable()]
    public enum CobrancaTipoInstrucao { LocalPagamrnto = 9, InstrucaoAoSacado = 0, Instrucao1 = 1, Instrucao2 = 2, Instrucao3 = 3, Instrucao4 = 4, Instrucao5 = 5, Instrucao6 = 6, Instrucao7 = 7, Instrucao8 = 8}

    [Serializable()]
    public enum NaturezaConta { ContaPagar = 0, ContaReceber = 1}

    [Serializable()]
    public enum TipoContaRecorrente { ValorFixo = 0, Media = 1, ValorDefinir = 2}

    [Serializable()]
    public enum StatusContratoFornecimento { Normal = 0, Encerrado = 1, Cancelado = 2}

    [Serializable()]
    public enum EasiDashboardSituacaoPedido { Bloqueado = 0, Atrasado = 3, Finalizado = 4, ParaSemana = 2, NoPrazo = 1}

    [Serializable()]
    public enum SipaDashboardSituacaoProcesso { NaoConcluido = 0, Concluido = 1, ConcluidoComAtraso = 2}

    [Serializable()]
    public enum StatusDivergenciaPreco { Pendente = 0, Encerrada = 1}

    [Serializable()]
    public enum TipoValidacaoDocumento { NaoValidar = 0, ValidarAviso = 1, ValidarBloqueio = 2}

    [Serializable()]
    public enum DimensaoVariavelEmbalagem { Nenhuma = 0, Largura = 1, Altura = 2, Comprimento = 3}

    [Serializable()]
    public enum EstoqueSeguranca { NaoUtilizando = 0, Verde = 1, Amarelo = 2, Vermelho = 3}

    [Serializable()]
    public enum EASITipoAlocacaoEstoque { MateriaPrima = 0, Consumo = 1}

    [Serializable()]
    public enum TipoFamiliaEspecial { ClienteComum = 0, EASSA = 1}

    [Serializable()]
    public enum TipoPessoa { PJ = 0, PF = 1}

    [Serializable()]
    public enum SituacaoFuncionarioEpi { Pendente = 0, Ativo = 1, Vencido = 2, Descartado = 3}

    [Serializable()]
    public enum TipoLogPrecos { Erro = 0, Aviso = 1}

    [Serializable()]
    public enum StatusLote { EmAberto = 0, Encerrado = 1, Cancelado = 2}

    [Serializable()]
    public enum PoliticaEstoque { MRP = 0, Kanban = 1, NaoAplicavel = 2}

    [Serializable()]
    public enum Origem { Nacional = 0, ImportacaoDireta = 1, ImportacaoIndireta = 2}

    [Serializable()]
    public enum TipoTributacaoST { STComReducaoBCST = 2, SemST = 0, SomenteST = 1}

    [Serializable()]
    public enum TipoAlteracaoQuantidadeOP { AlteracaoParaMenor = 0, AlteracaoParaMaior = 1}

    [Serializable()]
    public enum IncidenciaImposto { NaoIncide = 0, Incide = 1, Suspenso = 2}

    [Serializable()]
    public enum PresencaComprador { ForaEstabelecimento = 5, NFCeEntregaDomicilio = 4, NaoAplicavel = 0, Presencial = 1, Internet = 2, Teleatendimento = 3, NaoPresencialOutros = 9}

    [Serializable()]
    public enum EasiValidaPrecos { NaoValida = 0, ValidaComBloqueio = 1, ValidaSemBloqueio = 2}

    [Serializable()]
    public enum IncidenciaIPI { NaoIncide = 0, Incide = 1, Suspenso = 2, UtilizaDadosProdutoNcm = 3}

    [Serializable()]
    public enum StatusOrcamentoCompra { Novo = 0, AguardandoRetorno = 1, RetornoParcial = 2, Encerrado = 3}

    [Serializable()]
    public enum TipoAquisicao { Fabricado = 0, Comprado = 1}

    [Serializable()]
    public enum SituacaoConferencia { NaoIniciada = 0, Parcial = 1, Total = 2}

    [Serializable()]
    public enum TipoControleEtiquetaProduto { Kanban = 0, Customizado = 1}

    [Serializable()]
    public enum StatusOrcamento { Pendente = 0, Aprovado = 1, Cancelado = 2}

    [Serializable()]
    public enum TipoOrdemCompra { OrdemCompra = 0, PedidoCotacao = 1}

    [Serializable()]
    public enum StatusOrdemCompra { Nova = 0, Enviada = 1, RecebidaParcial = 2, Recebida = 3, Cancelada = 4, AguardandoAprovacaoCompras = 5}

    [Serializable()]
    public enum StatusOrdemProducao { AguardandoInicioProducao = 0, Producao = 1, Encerrada = 2, Cancelada = 3, AguardandoServicoExterno = 4}

    [Serializable()]
    public enum DestinoDiferencaOP { Descarte = 0, Cliente = 1, Estoque = 2}

    [Serializable()]
    public enum TipoRecurso { Normal = 0, Formulario = 1, CNC = 2}

    [Serializable()]
    public enum GadIntegracaoPedidoSituacao { SemGad = 0, Enviado = 1, EmAnalise = 2, Liberado = 3, Programado = 4, Cancelado = 5, ErroNoPedido = 7, ErroRecepcionarPedido = 6, AguardandoEnvio = 8}

    [Serializable()]
    public enum FormaFretePedido { Normal = 0, RateadoItens = 1}

    [Serializable()]
    public enum StatusPedido { Pendente = 0, Encerrado = 1, Cancelado = 2, Reaberto = 3, Suspenso = 4}

    [Serializable()]
    public enum UrgenciaPedido { Normal = 0, Antecipacao = 1, Urgente = 2, Critico = 3}

    [Serializable()]
    public enum EasiEmissorNFe { Primario = 0, Secundario = 1}

    [Serializable()]
    public enum PostoTrabalhoAcompanhamento { SemAcompanhamento = 0, UmTempo = 1, DoisTempos = 2, TresTempos = 3, UmTempoComQtd = 4}

    [Serializable()]
    public enum TipoCalculoPrecoProdudo { Fixo = 0, VariavelRegra = 1, VariavelSomaTodosFilhosPedido = 2, VariavelSomaFilhosPedidoSelecionados = 3, VariavelSomaTodosFilhosPedidoEEstrutura = 4}

    [Serializable()]
    public enum HierarquiaRecursoEstrutura { Primario = 0, Secundario = 1}

    [Serializable()]
    public enum TipoRevisaoProduto { Principal = 0, PCP = 1, Fiscal = 2, Estrutura = 3, PermissaoVenda = 4}

    [Serializable()]
    public enum GadIntegracaoProgramacaoSituacao { Pendente = 0, Enviada = 1, ErroFinal = 2}

    [Serializable()]
    public enum StatusSolicitacaoCompra { Nova = 0, AprovadaPCP = 1, AprovadaCompras = 2, Comprada = 3, RecebidaParcial = 4, RecebidaTotal = 5, Cancelada = 6}

    [Serializable()]
    public enum TipoPagamentoNfe { Dinheiro = 1, Cheque = 2, CartaodeCredito = 3, CartaodeDebito = 4, CreditoLoja = 5, ValeAlimentacao = 10, ValeRefeicao = 11, ValePresente = 12, ValeCombustivel = 13, BoletoBancario = 15, DepositoBancario = 16, Pix = 17, TransferenciaBancaria = 18, ProgramaFidelidade = 19, SemPagamento = 90, Outros = 99}

    [Serializable()]
    public enum TipoRegra { RetornoNumero = 0, RetornoBoolean = 1, RetornoTexto = 2}

public class EnumHelperClass
{
   public static List<LoadClass> GetEnumOptionsList(Type enumType)
   {
       List<LoadClass> retorno = null;
       switch (enumType.Name)
       {
           case "EASITipoConsumoEstoque":
retorno = new List<LoadClass>(){
new LoadClass("0", "MateriaPrima"),new LoadClass("1", "Consumo"),new LoadClass("2", "Escolher"),};break;
case "EasiSituacaoBudget":
retorno = new List<LoadClass>(){
new LoadClass("0", "EmElaboracao"),new LoadClass("1", "Aprovado"),new LoadClass("2", "EmRevisao"),};break;
case "BufferEmailSituacao":
retorno = new List<LoadClass>(){
new LoadClass("0", "Pendente"),new LoadClass("1", "Enviado"),new LoadClass("2", "Erro"),};break;
case "CentroCustoLucroNatureza":
retorno = new List<LoadClass>(){
new LoadClass("-1", "Neutro"),new LoadClass("0", "Custo"),new LoadClass("1", "Lucro"),};break;
case "EasiConfiguracaoAutomaticaReferencia":
retorno = new List<LoadClass>(){
new LoadClass("0", "DataCadastro"),new LoadClass("1", "DataEntrega"),};break;
case "ClienteTipoDimensionamentoVolumetrico":
retorno = new List<LoadClass>(){
new LoadClass("0", "Cubagem"),new LoadClass("1", "Dimensoes"),};break;
case "ResponsavelFrete":
retorno = new List<LoadClass>(){
new LoadClass("3", "ProprioRemetente"),new LoadClass("4", "ProprioDestinatario"),new LoadClass("0", "Emitente"),new LoadClass("1", "Cliente"),new LoadClass("2", "Terceiros"),new LoadClass("9", "SemFrete"),};break;
case "IWTNFIndicadorIE":
retorno = new List<LoadClass>(){
new LoadClass("0", "ContribuinteICMS"),new LoadClass("1", "Isento"),new LoadClass("2", "NaoContribuinte"),};break;
case "CobrancaStatusBoleto":
retorno = new List<LoadClass>(){
new LoadClass("0", "GeradoNaoEnviado"),new LoadClass("1", "EnviadoAgConfirmacao"),new LoadClass("2", "ConfirmadoEmCarteira"),new LoadClass("3", "Rejeitado"),new LoadClass("4", "Pago"),new LoadClass("5", "Cancelado"),};break;
case "CobrancaTipoDocumento":
retorno = new List<LoadClass>(){
new LoadClass("1", "CPF"),new LoadClass("2", "CNPJ"),};break;
case "CobrancaTipoInstrucao":
retorno = new List<LoadClass>(){
new LoadClass("9", "LocalPagamrnto"),new LoadClass("0", "InstrucaoAoSacado"),new LoadClass("1", "Instrucao1"),new LoadClass("2", "Instrucao2"),new LoadClass("3", "Instrucao3"),new LoadClass("4", "Instrucao4"),new LoadClass("5", "Instrucao5"),new LoadClass("6", "Instrucao6"),new LoadClass("7", "Instrucao7"),new LoadClass("8", "Instrucao8"),};break;
case "NaturezaConta":
retorno = new List<LoadClass>(){
new LoadClass("0", "ContaPagar"),new LoadClass("1", "ContaReceber"),};break;
case "TipoContaRecorrente":
retorno = new List<LoadClass>(){
new LoadClass("0", "ValorFixo"),new LoadClass("1", "Media"),new LoadClass("2", "ValorDefinir"),};break;
case "StatusContratoFornecimento":
retorno = new List<LoadClass>(){
new LoadClass("0", "Normal"),new LoadClass("1", "Encerrado"),new LoadClass("2", "Cancelado"),};break;
case "EasiDashboardSituacaoPedido":
retorno = new List<LoadClass>(){
new LoadClass("0", "Bloqueado"),new LoadClass("3", "Atrasado"),new LoadClass("4", "Finalizado"),new LoadClass("2", "ParaSemana"),new LoadClass("1", "NoPrazo"),};break;
case "SipaDashboardSituacaoProcesso":
retorno = new List<LoadClass>(){
new LoadClass("0", "NaoConcluido"),new LoadClass("1", "Concluido"),new LoadClass("2", "ConcluidoComAtraso"),};break;
case "StatusDivergenciaPreco":
retorno = new List<LoadClass>(){
new LoadClass("0", "Pendente"),new LoadClass("1", "Encerrada"),};break;
case "TipoValidacaoDocumento":
retorno = new List<LoadClass>(){
new LoadClass("0", "NaoValidar"),new LoadClass("1", "ValidarAviso"),new LoadClass("2", "ValidarBloqueio"),};break;
case "DimensaoVariavelEmbalagem":
retorno = new List<LoadClass>(){
new LoadClass("0", "Nenhuma"),new LoadClass("1", "Largura"),new LoadClass("2", "Altura"),new LoadClass("3", "Comprimento"),};break;
case "EstoqueSeguranca":
retorno = new List<LoadClass>(){
new LoadClass("0", "NaoUtilizando"),new LoadClass("1", "Verde"),new LoadClass("2", "Amarelo"),new LoadClass("3", "Vermelho"),};break;
case "EASITipoAlocacaoEstoque":
retorno = new List<LoadClass>(){
new LoadClass("0", "MateriaPrima"),new LoadClass("1", "Consumo"),};break;
case "TipoFamiliaEspecial":
retorno = new List<LoadClass>(){
new LoadClass("0", "ClienteComum"),new LoadClass("1", "EASSA"),};break;
case "TipoPessoa":
retorno = new List<LoadClass>(){
new LoadClass("0", "PJ"),new LoadClass("1", "PF"),};break;
case "SituacaoFuncionarioEpi":
retorno = new List<LoadClass>(){
new LoadClass("0", "Pendente"),new LoadClass("1", "Ativo"),new LoadClass("2", "Vencido"),new LoadClass("3", "Descartado"),};break;
case "TipoLogPrecos":
retorno = new List<LoadClass>(){
new LoadClass("0", "Erro"),new LoadClass("1", "Aviso"),};break;
case "StatusLote":
retorno = new List<LoadClass>(){
new LoadClass("0", "EmAberto"),new LoadClass("1", "Encerrado"),new LoadClass("2", "Cancelado"),};break;
case "PoliticaEstoque":
retorno = new List<LoadClass>(){
new LoadClass("0", "MRP"),new LoadClass("1", "Kanban"),new LoadClass("2", "NaoAplicavel"),};break;
case "Origem":
retorno = new List<LoadClass>(){
new LoadClass("0", "Nacional"),new LoadClass("1", "ImportacaoDireta"),new LoadClass("2", "ImportacaoIndireta"),};break;
case "TipoTributacaoST":
retorno = new List<LoadClass>(){
new LoadClass("2", "STComReducaoBCST"),new LoadClass("0", "SemST"),new LoadClass("1", "SomenteST"),};break;
case "TipoAlteracaoQuantidadeOP":
retorno = new List<LoadClass>(){
new LoadClass("0", "AlteracaoParaMenor"),new LoadClass("1", "AlteracaoParaMaior"),};break;
case "IncidenciaImposto":
retorno = new List<LoadClass>(){
new LoadClass("0", "NaoIncide"),new LoadClass("1", "Incide"),new LoadClass("2", "Suspenso"),};break;
case "PresencaComprador":
retorno = new List<LoadClass>(){
new LoadClass("5", "ForaEstabelecimento"),new LoadClass("4", "NFCeEntregaDomicilio"),new LoadClass("0", "NaoAplicavel"),new LoadClass("1", "Presencial"),new LoadClass("2", "Internet"),new LoadClass("3", "Teleatendimento"),new LoadClass("9", "NaoPresencialOutros"),};break;
case "EasiValidaPrecos":
retorno = new List<LoadClass>(){
new LoadClass("0", "NaoValida"),new LoadClass("1", "ValidaComBloqueio"),new LoadClass("2", "ValidaSemBloqueio"),};break;
case "IncidenciaIPI":
retorno = new List<LoadClass>(){
new LoadClass("0", "NaoIncide"),new LoadClass("1", "Incide"),new LoadClass("2", "Suspenso"),new LoadClass("3", "UtilizaDadosProdutoNcm"),};break;
case "StatusOrcamentoCompra":
retorno = new List<LoadClass>(){
new LoadClass("0", "Novo"),new LoadClass("1", "AguardandoRetorno"),new LoadClass("2", "RetornoParcial"),new LoadClass("3", "Encerrado"),};break;
case "TipoAquisicao":
retorno = new List<LoadClass>(){
new LoadClass("0", "Fabricado"),new LoadClass("1", "Comprado"),};break;
case "SituacaoConferencia":
retorno = new List<LoadClass>(){
new LoadClass("0", "NaoIniciada"),new LoadClass("1", "Parcial"),new LoadClass("2", "Total"),};break;
case "TipoControleEtiquetaProduto":
retorno = new List<LoadClass>(){
new LoadClass("0", "Kanban"),new LoadClass("1", "Customizado"),};break;
case "StatusOrcamento":
retorno = new List<LoadClass>(){
new LoadClass("0", "Pendente"),new LoadClass("1", "Aprovado"),new LoadClass("2", "Cancelado"),};break;
case "TipoOrdemCompra":
retorno = new List<LoadClass>(){
new LoadClass("0", "OrdemCompra"),new LoadClass("1", "PedidoCotacao"),};break;
case "StatusOrdemCompra":
retorno = new List<LoadClass>(){
new LoadClass("0", "Nova"),new LoadClass("1", "Enviada"),new LoadClass("2", "RecebidaParcial"),new LoadClass("3", "Recebida"),new LoadClass("4", "Cancelada"),new LoadClass("5", "AguardandoAprovacaoCompras"),};break;
case "StatusOrdemProducao":
retorno = new List<LoadClass>(){
new LoadClass("0", "AguardandoInicioProducao"),new LoadClass("1", "Producao"),new LoadClass("2", "Encerrada"),new LoadClass("3", "Cancelada"),new LoadClass("4", "AguardandoServicoExterno"),};break;
case "DestinoDiferencaOP":
retorno = new List<LoadClass>(){
new LoadClass("0", "Descarte"),new LoadClass("1", "Cliente"),new LoadClass("2", "Estoque"),};break;
case "TipoRecurso":
retorno = new List<LoadClass>(){
new LoadClass("0", "Normal"),new LoadClass("1", "Formulario"),new LoadClass("2", "CNC"),};break;
case "GadIntegracaoPedidoSituacao":
retorno = new List<LoadClass>(){
new LoadClass("0", "SemGad"),new LoadClass("1", "Enviado"),new LoadClass("2", "EmAnalise"),new LoadClass("3", "Liberado"),new LoadClass("4", "Programado"),new LoadClass("5", "Cancelado"),new LoadClass("7", "ErroNoPedido"),new LoadClass("6", "ErroRecepcionarPedido"),new LoadClass("8", "AguardandoEnvio"),};break;
case "FormaFretePedido":
retorno = new List<LoadClass>(){
new LoadClass("0", "Normal"),new LoadClass("1", "RateadoItens"),};break;
case "StatusPedido":
retorno = new List<LoadClass>(){
new LoadClass("0", "Pendente"),new LoadClass("1", "Encerrado"),new LoadClass("2", "Cancelado"),new LoadClass("3", "Reaberto"),new LoadClass("4", "Suspenso"),};break;
case "UrgenciaPedido":
retorno = new List<LoadClass>(){
new LoadClass("0", "Normal"),new LoadClass("1", "Antecipacao"),new LoadClass("2", "Urgente"),new LoadClass("3", "Critico"),};break;
case "EasiEmissorNFe":
retorno = new List<LoadClass>(){
new LoadClass("0", "Primario"),new LoadClass("1", "Secundario"),};break;
case "PostoTrabalhoAcompanhamento":
retorno = new List<LoadClass>(){
new LoadClass("0", "SemAcompanhamento"),new LoadClass("1", "UmTempo"),new LoadClass("2", "DoisTempos"),new LoadClass("3", "TresTempos"),new LoadClass("4", "UmTempoComQtd"),};break;
case "TipoCalculoPrecoProdudo":
retorno = new List<LoadClass>(){
new LoadClass("0", "Fixo"),new LoadClass("1", "VariavelRegra"),new LoadClass("2", "VariavelSomaTodosFilhosPedido"),new LoadClass("3", "VariavelSomaFilhosPedidoSelecionados"),new LoadClass("4", "VariavelSomaTodosFilhosPedidoEEstrutura"),};break;
case "HierarquiaRecursoEstrutura":
retorno = new List<LoadClass>(){
new LoadClass("0", "Primario"),new LoadClass("1", "Secundario"),};break;
case "TipoRevisaoProduto":
retorno = new List<LoadClass>(){
new LoadClass("0", "Principal"),new LoadClass("1", "PCP"),new LoadClass("2", "Fiscal"),new LoadClass("3", "Estrutura"),new LoadClass("4", "PermissaoVenda"),};break;
case "GadIntegracaoProgramacaoSituacao":
retorno = new List<LoadClass>(){
new LoadClass("0", "Pendente"),new LoadClass("1", "Enviada"),new LoadClass("2", "ErroFinal"),};break;
case "StatusSolicitacaoCompra":
retorno = new List<LoadClass>(){
new LoadClass("0", "Nova"),new LoadClass("1", "AprovadaPCP"),new LoadClass("2", "AprovadaCompras"),new LoadClass("3", "Comprada"),new LoadClass("4", "RecebidaParcial"),new LoadClass("5", "RecebidaTotal"),new LoadClass("6", "Cancelada"),};break;
case "TipoPagamentoNfe":
retorno = new List<LoadClass>(){
new LoadClass("1", "Dinheiro"),new LoadClass("2", "Cheque"),new LoadClass("3", "CartaodeCredito"),new LoadClass("4", "CartaodeDebito"),new LoadClass("5", "CreditoLoja"),new LoadClass("10", "ValeAlimentacao"),new LoadClass("11", "ValeRefeicao"),new LoadClass("12", "ValePresente"),new LoadClass("13", "ValeCombustivel"),new LoadClass("15", "BoletoBancario"),new LoadClass("16", "DepositoBancario"),new LoadClass("17", "Pix"),new LoadClass("18", "TransferenciaBancaria"),new LoadClass("19", "ProgramaFidelidade"),new LoadClass("90", "SemPagamento"),new LoadClass("99", "Outros"),};break;
case "TipoRegra":
retorno = new List<LoadClass>(){
new LoadClass("0", "RetornoNumero"),new LoadClass("1", "RetornoBoolean"),new LoadClass("2", "RetornoTexto"),};break;
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
