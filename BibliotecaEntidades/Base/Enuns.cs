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
using IWTNFCompleto.BibliotecaEntidades.Base;
namespace IWTNFCompleto.BibliotecaEntidades.Base
{
    [Serializable()]
    public enum BufferEmailSituacao { Pendente = 0, Enviado = 1, Erro = 2}

    [Serializable()]
    public enum MDFeModalidadeTransporte { Rodoviario = 1, Aereo = 2, Aquaviario = 3, Ferroviario = 4}

    [Serializable()]
    public enum MDFeFormaEmissao { Normal = 1, Contingencia = 2}

    [Serializable()]
    public enum MDFeUnidadeMedidaPeso { KG = 1, TON = 2}

    [Serializable()]
    public enum MDFeTipoEmitente { PrestadorServicoTransporte = 1, TransportadorCargaPropria = 2}

    [Serializable()]
    public enum MDFeTipoAmbiente { Producao = 1, Homologacao = 2}

    [Serializable()]
    public enum MDFeSituacaoLote { Contingencia = 0, Enviado = 1, Processado = 2}

    [Serializable()]
    public enum MDFeSituacaoMdfeCompleto { Enviado = 0, Autorizado = 1, Encerrado = 2, Cancelado = 3}

    [Serializable()]
    public enum MDFeTipoRodado { Truck = 1, Toco = 2, CavaloMecanico = 3, Van = 4, Utilitario = 5, Outros = 6}

    [Serializable()]
    public enum MDFeTipoProprietarioVeiculo { TACAgregado = 0, TACIndependente = 1, Outros = 2}

    [Serializable()]
    public enum MDFeTipoCarroceria { NaoAplicavel = 0, Aberta = 1, FechadaBau = 2, Granelera = 3, PortaContainer = 4, Sider = 5}

    [Serializable()]
    public enum SituacaoLote { Enviado = 0, Processado = 1, AguardandoEnvio = 2, ErroLote = 3}

    [Serializable()]
    public enum SituacaoNFe { Enviada = 0, Autorizada = 1, Denegada = 2, Cancelada = 3, NaoEncontrada = 4, Rejeitada = 5, NFCeAguardandoEnvio = 6}

    [Serializable()]
    public enum IWTNFTipoNota { NFe = 0, NFCe = 1, NFServicosLondrina = 2}

    [Serializable()]
    public enum IWTNFSituacaoTransmissao { AguardandoEnvio = 0, AguardandoResposta = 1, Processada = 2, Rejeitada = 3, Denegada = 4}

public class EnumHelperClass
{
   public static List<LoadClass> GetEnumOptionsList(Type enumType)
   {
       List<LoadClass> retorno = null;
       switch (enumType.Name)
       {
           case "BufferEmailSituacao":
retorno = new List<LoadClass>(){
new LoadClass("0", "Pendente"),new LoadClass("1", "Enviado"),new LoadClass("2", "Erro"),};break;
case "MDFeModalidadeTransporte":
retorno = new List<LoadClass>(){
new LoadClass("1", "Rodoviario"),new LoadClass("2", "Aereo"),new LoadClass("3", "Aquaviario"),new LoadClass("4", "Ferroviario"),};break;
case "MDFeFormaEmissao":
retorno = new List<LoadClass>(){
new LoadClass("1", "Normal"),new LoadClass("2", "Contingencia"),};break;
case "MDFeUnidadeMedidaPeso":
retorno = new List<LoadClass>(){
new LoadClass("1", "KG"),new LoadClass("2", "TON"),};break;
case "MDFeTipoEmitente":
retorno = new List<LoadClass>(){
new LoadClass("1", "PrestadorServicoTransporte"),new LoadClass("2", "TransportadorCargaPropria"),};break;
case "MDFeTipoAmbiente":
retorno = new List<LoadClass>(){
new LoadClass("1", "Producao"),new LoadClass("2", "Homologacao"),};break;
case "MDFeSituacaoLote":
retorno = new List<LoadClass>(){
new LoadClass("0", "Contingencia"),new LoadClass("1", "Enviado"),new LoadClass("2", "Processado"),};break;
case "MDFeSituacaoMdfeCompleto":
retorno = new List<LoadClass>(){
new LoadClass("0", "Enviado"),new LoadClass("1", "Autorizado"),new LoadClass("2", "Encerrado"),new LoadClass("3", "Cancelado"),};break;
case "MDFeTipoRodado":
retorno = new List<LoadClass>(){
new LoadClass("1", "Truck"),new LoadClass("2", "Toco"),new LoadClass("3", "CavaloMecanico"),new LoadClass("4", "Van"),new LoadClass("5", "Utilitario"),new LoadClass("6", "Outros"),};break;
case "MDFeTipoProprietarioVeiculo":
retorno = new List<LoadClass>(){
new LoadClass("0", "TACAgregado"),new LoadClass("1", "TACIndependente"),new LoadClass("2", "Outros"),};break;
case "MDFeTipoCarroceria":
retorno = new List<LoadClass>(){
new LoadClass("0", "NaoAplicavel"),new LoadClass("1", "Aberta"),new LoadClass("2", "FechadaBau"),new LoadClass("3", "Granelera"),new LoadClass("4", "PortaContainer"),new LoadClass("5", "Sider"),};break;
case "SituacaoLote":
retorno = new List<LoadClass>(){
new LoadClass("0", "Enviado"),new LoadClass("1", "Processado"),new LoadClass("2", "AguardandoEnvio"),new LoadClass("3", "ErroLote"),};break;
case "SituacaoNFe":
retorno = new List<LoadClass>(){
new LoadClass("0", "Enviada"),new LoadClass("1", "Autorizada"),new LoadClass("2", "Denegada"),new LoadClass("3", "Cancelada"),new LoadClass("4", "NaoEncontrada"),new LoadClass("5", "Rejeitada"),new LoadClass("6", "NFCeAguardandoEnvio"),};break;
case "IWTNFTipoNota":
retorno = new List<LoadClass>(){
new LoadClass("0", "NFe"),new LoadClass("1", "NFCe"),new LoadClass("2", "NFServicosLondrina"),};break;
case "IWTNFSituacaoTransmissao":
retorno = new List<LoadClass>(){
new LoadClass("0", "AguardandoEnvio"),new LoadClass("1", "AguardandoResposta"),new LoadClass("2", "Processada"),new LoadClass("3", "Rejeitada"),new LoadClass("4", "Denegada"),};break;
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
