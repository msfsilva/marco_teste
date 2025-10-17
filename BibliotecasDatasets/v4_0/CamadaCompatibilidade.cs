using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace IWTNFCompleto.BibliotecaDatasets.v4_0
{
    // AVISO: Este arquivo contém classes parciais que atuam como uma camada de compatibilidade
    // para permitir que o código legado funcione com as novas classes de dados da NFe 4.0.
    // Ele recria propriedades e métodos que existiam na estrutura antiga, traduzindo as chamadas
    // para a nova estrutura de objetos fortemente tipados.

    #region Enums e Constantes de Compatibilidade

    /// <summary>
    /// Enum de compatibilidade para a alíquota interestadual de ICMS.
    /// </summary>
    public enum TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado
    {
        [System.Xml.Serialization.XmlEnumAttribute("4.00")]
        Item400,
        [System.Xml.Serialization.XmlEnumAttribute("7.00")]
        Item700,
        [System.Xml.Serialization.XmlEnumAttribute("12.00")]
        Item1200,
    }

    /// <summary>
    /// Enum de compatibilidade para o formato de impressão do DANFE.
    /// </summary>
    public enum TNFeInfNFeIdeTpImpLegado
    {
        SemDANFE,
        DANFENormalRetrato,
        DANFENormalPaisagem,
        DANFESimplificado,
        DANFENFCe,
        DANFENFCeEletronico
    }

    /// <summary>
    /// Enum de compatibilidade para a Lista de Serviços da LC 116/03.
    /// </summary>
    public enum TCListServLegado
    {
        [System.Xml.Serialization.XmlEnumAttribute("01.01")]
        Item0101,
        [System.Xml.Serialization.XmlEnumAttribute("01.02")]
        Item0102,
        [System.Xml.Serialization.XmlEnumAttribute("01.03")]
        Item0103,
        [System.Xml.Serialization.XmlEnumAttribute("01.04")]
        Item0104,
        [System.Xml.Serialization.XmlEnumAttribute("01.05")]
        Item0105,
        [System.Xml.Serialization.XmlEnumAttribute("01.06")]
        Item0106,
        [System.Xml.Serialization.XmlEnumAttribute("01.07")]
        Item0107,
        [System.Xml.Serialization.XmlEnumAttribute("01.08")]
        Item0108,
        [System.Xml.Serialization.XmlEnumAttribute("01.09")]
        Item0109,
        [System.Xml.Serialization.XmlEnumAttribute("02.01")]
        Item0201,
        [System.Xml.Serialization.XmlEnumAttribute("03.02")]
        Item0302,
        [System.Xml.Serialization.XmlEnumAttribute("03.03")]
        Item0303,
        [System.Xml.Serialization.XmlEnumAttribute("03.04")]
        Item0304,
        [System.Xml.Serialization.XmlEnumAttribute("03.05")]
        Item0305,
        [System.Xml.Serialization.XmlEnumAttribute("04.01")]
        Item0401,
        [System.Xml.Serialization.XmlEnumAttribute("04.02")]
        Item0402,
        [System.Xml.Serialization.XmlEnumAttribute("04.03")]
        Item0403,
        [System.Xml.Serialization.XmlEnumAttribute("04.04")]
        Item0404,
        [System.Xml.Serialization.XmlEnumAttribute("04.05")]
        Item0405,
        [System.Xml.Serialization.XmlEnumAttribute("04.06")]
        Item0406,
        [System.Xml.Serialization.XmlEnumAttribute("04.07")]
        Item0407,
        [System.Xml.Serialization.XmlEnumAttribute("04.08")]
        Item0408,
        [System.Xml.Serialization.XmlEnumAttribute("04.09")]
        Item0409,
        [System.Xml.Serialization.XmlEnumAttribute("04.10")]
        Item0410,
        [System.Xml.Serialization.XmlEnumAttribute("04.11")]
        Item0411,
        [System.Xml.Serialization.XmlEnumAttribute("04.12")]
        Item0412,
        [System.Xml.Serialization.XmlEnumAttribute("04.13")]
        Item0413,
        [System.Xml.Serialization.XmlEnumAttribute("04.14")]
        Item0414,
        [System.Xml.Serialization.XmlEnumAttribute("04.15")]
        Item0415,
        [System.Xml.Serialization.XmlEnumAttribute("04.16")]
        Item0416,
        [System.Xml.Serialization.XmlEnumAttribute("04.17")]
        Item0417,
        [System.Xml.Serialization.XmlEnumAttribute("04.18")]
        Item0418,
        [System.Xml.Serialization.XmlEnumAttribute("04.19")]
        Item0419,
        [System.Xml.Serialization.XmlEnumAttribute("04.20")]
        Item0420,
        [System.Xml.Serialization.XmlEnumAttribute("04.21")]
        Item0421,
        [System.Xml.Serialization.XmlEnumAttribute("04.22")]
        Item0422,
        [System.Xml.Serialization.XmlEnumAttribute("04.23")]
        Item0423,
        [System.Xml.Serialization.XmlEnumAttribute("05.01")]
        Item0501,
        [System.Xml.Serialization.XmlEnumAttribute("05.02")]
        Item0502,
        [System.Xml.Serialization.XmlEnumAttribute("05.03")]
        Item0503,
        [System.Xml.Serialization.XmlEnumAttribute("05.04")]
        Item0504,
        [System.Xml.Serialization.XmlEnumAttribute("05.05")]
        Item0505,
        [System.Xml.Serialization.XmlEnumAttribute("05.06")]
        Item0506,
        [System.Xml.Serialization.XmlEnumAttribute("05.07")]
        Item0507,
        [System.Xml.Serialization.XmlEnumAttribute("05.08")]
        Item0508,
        [System.Xml.Serialization.XmlEnumAttribute("05.09")]
        Item0509,
        [System.Xml.Serialization.XmlEnumAttribute("06.01")]
        Item0601,
        [System.Xml.Serialization.XmlEnumAttribute("06.02")]
        Item0602,
        [System.Xml.Serialization.XmlEnumAttribute("06.03")]
        Item0603,
        [System.Xml.Serialization.XmlEnumAttribute("06.04")]
        Item0604,
        [System.Xml.Serialization.XmlEnumAttribute("06.05")]
        Item0605,
        [System.Xml.Serialization.XmlEnumAttribute("06.06")]
        Item0606,
        [System.Xml.Serialization.XmlEnumAttribute("07.01")]
        Item0701,
        [System.Xml.Serialization.XmlEnumAttribute("07.02")]
        Item0702,
        [System.Xml.Serialization.XmlEnumAttribute("07.03")]
        Item0703,
        [System.Xml.Serialization.XmlEnumAttribute("07.04")]
        Item0704,
        [System.Xml.Serialization.XmlEnumAttribute("07.05")]
        Item0705,
        [System.Xml.Serialization.XmlEnumAttribute("07.06")]
        Item0706,
        [System.Xml.Serialization.XmlEnumAttribute("07.07")]
        Item0707,
        [System.Xml.Serialization.XmlEnumAttribute("07.08")]
        Item0708,
        [System.Xml.Serialization.XmlEnumAttribute("07.09")]
        Item0709,
        [System.Xml.Serialization.XmlEnumAttribute("07.10")]
        Item0710,
        [System.Xml.Serialization.XmlEnumAttribute("07.11")]
        Item0711,
        [System.Xml.Serialization.XmlEnumAttribute("07.12")]
        Item0712,
        [System.Xml.Serialization.XmlEnumAttribute("07.13")]
        Item0713,
        [System.Xml.Serialization.XmlEnumAttribute("07.16")]
        Item0716,
        [System.Xml.Serialization.XmlEnumAttribute("07.17")]
        Item0717,
        [System.Xml.Serialization.XmlEnumAttribute("07.18")]
        Item0718,
        [System.Xml.Serialization.XmlEnumAttribute("07.19")]
        Item0719,
        [System.Xml.Serialization.XmlEnumAttribute("07.20")]
        Item0720,
        [System.Xml.Serialization.XmlEnumAttribute("07.21")]
        Item0721,
        [System.Xml.Serialization.XmlEnumAttribute("07.22")]
        Item0722,
        [System.Xml.Serialization.XmlEnumAttribute("08.01")]
        Item0801,
        [System.Xml.Serialization.XmlEnumAttribute("08.02")]
        Item0802,
        [System.Xml.Serialization.XmlEnumAttribute("09.01")]
        Item0901,
        [System.Xml.Serialization.XmlEnumAttribute("09.02")]
        Item0902,
        [System.Xml.Serialization.XmlEnumAttribute("09.03")]
        Item0903,
        [System.Xml.Serialization.XmlEnumAttribute("10.01")]
        Item1001,
        [System.Xml.Serialization.XmlEnumAttribute("10.02")]
        Item1002,
        [System.Xml.Serialization.XmlEnumAttribute("10.03")]
        Item1003,
        [System.Xml.Serialization.XmlEnumAttribute("10.04")]
        Item1004,
        [System.Xml.Serialization.XmlEnumAttribute("10.05")]
        Item1005,
        [System.Xml.Serialization.XmlEnumAttribute("10.06")]
        Item1006,
        [System.Xml.Serialization.XmlEnumAttribute("10.07")]
        Item1007,
        [System.Xml.Serialization.XmlEnumAttribute("10.08")]
        Item1008,
        [System.Xml.Serialization.XmlEnumAttribute("10.09")]
        Item1009,
        [System.Xml.Serialization.XmlEnumAttribute("10.10")]
        Item1010,
        [System.Xml.Serialization.XmlEnumAttribute("11.01")]
        Item1101,
        [System.Xml.Serialization.XmlEnumAttribute("11.02")]
        Item1102,
        [System.Xml.Serialization.XmlEnumAttribute("11.03")]
        Item1103,
        [System.Xml.Serialization.XmlEnumAttribute("11.04")]
        Item1104,
        [System.Xml.Serialization.XmlEnumAttribute("12.01")]
        Item1201,
        [System.Xml.Serialization.XmlEnumAttribute("12.02")]
        Item1202,
        [System.Xml.Serialization.XmlEnumAttribute("12.03")]
        Item1203,
        [System.Xml.Serialization.XmlEnumAttribute("12.04")]
        Item1204,
        [System.Xml.Serialization.XmlEnumAttribute("12.05")]
        Item1205,
        [System.Xml.Serialization.XmlEnumAttribute("12.06")]
        Item1206,
        [System.Xml.Serialization.XmlEnumAttribute("12.07")]
        Item1207,
        [System.Xml.Serialization.XmlEnumAttribute("12.08")]
        Item1208,
        [System.Xml.Serialization.XmlEnumAttribute("12.09")]
        Item1209,
        [System.Xml.Serialization.XmlEnumAttribute("12.10")]
        Item1210,
        [System.Xml.Serialization.XmlEnumAttribute("12.11")]
        Item1211,
        [System.Xml.Serialization.XmlEnumAttribute("12.12")]
        Item1212,
        [System.Xml.Serialization.XmlEnumAttribute("12.13")]
        Item1213,
        [System.Xml.Serialization.XmlEnumAttribute("12.14")]
        Item1214,
        [System.Xml.Serialization.XmlEnumAttribute("12.15")]
        Item1215,
        [System.Xml.Serialization.XmlEnumAttribute("12.16")]
        Item1216,
        [System.Xml.Serialization.XmlEnumAttribute("12.17")]
        Item1217,
        [System.Xml.Serialization.XmlEnumAttribute("13.02")]
        Item1302,
        [System.Xml.Serialization.XmlEnumAttribute("13.03")]
        Item1303,
        [System.Xml.Serialization.XmlEnumAttribute("13.04")]
        Item1304,
        [System.Xml.Serialization.XmlEnumAttribute("13.05")]
        Item1305,
        [System.Xml.Serialization.XmlEnumAttribute("14.01")]
        Item1401,
        [System.Xml.Serialization.XmlEnumAttribute("14.02")]
        Item1402,
        [System.Xml.Serialization.XmlEnumAttribute("14.03")]
        Item1403,
        [System.Xml.Serialization.XmlEnumAttribute("14.04")]
        Item1404,
        [System.Xml.Serialization.XmlEnumAttribute("14.05")]
        Item1405,
        [System.Xml.Serialization.XmlEnumAttribute("14.06")]
        Item1406,
        [System.Xml.Serialization.XmlEnumAttribute("14.07")]
        Item1407,
        [System.Xml.Serialization.XmlEnumAttribute("14.08")]
        Item1408,
        [System.Xml.Serialization.XmlEnumAttribute("14.09")]
        Item1409,
        [System.Xml.Serialization.XmlEnumAttribute("14.10")]
        Item1410,
        [System.Xml.Serialization.XmlEnumAttribute("14.11")]
        Item1411,
        [System.Xml.Serialization.XmlEnumAttribute("14.12")]
        Item1412,
        [System.Xml.Serialization.XmlEnumAttribute("14.13")]
        Item1413,
        [System.Xml.Serialization.XmlEnumAttribute("14.14")]
        Item1414,
        [System.Xml.Serialization.XmlEnumAttribute("15.01")]
        Item1501,
        [System.Xml.Serialization.XmlEnumAttribute("15.02")]
        Item1502,
        [System.Xml.Serialization.XmlEnumAttribute("15.03")]
        Item1503,
        [System.Xml.Serialization.XmlEnumAttribute("15.04")]
        Item1504,
        [System.Xml.Serialization.XmlEnumAttribute("15.05")]
        Item1505,
        [System.Xml.Serialization.XmlEnumAttribute("15.06")]
        Item1506,
        [System.Xml.Serialization.XmlEnumAttribute("15.07")]
        Item1507,
        [System.Xml.Serialization.XmlEnumAttribute("15.08")]
        Item1508,
        [System.Xml.Serialization.XmlEnumAttribute("15.09")]
        Item1509,
        [System.Xml.Serialization.XmlEnumAttribute("15.10")]
        Item1510,
        [System.Xml.Serialization.XmlEnumAttribute("15.11")]
        Item1511,
        [System.Xml.Serialization.XmlEnumAttribute("15.12")]
        Item1512,
        [System.Xml.Serialization.XmlEnumAttribute("15.13")]
        Item1513,
        [System.Xml.Serialization.XmlEnumAttribute("15.14")]
        Item1514,
        [System.Xml.Serialization.XmlEnumAttribute("15.15")]
        Item1515,
        [System.Xml.Serialization.XmlEnumAttribute("15.16")]
        Item1516,
        [System.Xml.Serialization.XmlEnumAttribute("15.17")]
        Item1517,
        [System.Xml.Serialization.XmlEnumAttribute("15.18")]
        Item1518,
        [System.Xml.Serialization.XmlEnumAttribute("16.01")]
        Item1601,
        [System.Xml.Serialization.XmlEnumAttribute("16.02")]
        Item1602,
        [System.Xml.Serialization.XmlEnumAttribute("17.01")]
        Item1701,
        [System.Xml.Serialization.XmlEnumAttribute("17.02")]
        Item1702,
        [System.Xml.Serialization.XmlEnumAttribute("17.03")]
        Item1703,
        [System.Xml.Serialization.XmlEnumAttribute("17.04")]
        Item1704,
        [System.Xml.Serialization.XmlEnumAttribute("17.05")]
        Item1705,
        [System.Xml.Serialization.XmlEnumAttribute("17.06")]
        Item1706,
        [System.Xml.Serialization.XmlEnumAttribute("17.08")]
        Item1708,
        [System.Xml.Serialization.XmlEnumAttribute("17.09")]
        Item1709,
        [System.Xml.Serialization.XmlEnumAttribute("17.10")]
        Item1710,
        [System.Xml.Serialization.XmlEnumAttribute("17.11")]
        Item1711,
        [System.Xml.Serialization.XmlEnumAttribute("17.12")]
        Item1712,
        [System.Xml.Serialization.XmlEnumAttribute("17.13")]
        Item1713,
        [System.Xml.Serialization.XmlEnumAttribute("17.14")]
        Item1714,
        [System.Xml.Serialization.XmlEnumAttribute("17.15")]
        Item1715,
        [System.Xml.Serialization.XmlEnumAttribute("17.16")]
        Item1716,
        [System.Xml.Serialization.XmlEnumAttribute("17.17")]
        Item1717,
        [System.Xml.Serialization.XmlEnumAttribute("17.18")]
        Item1718,
        [System.Xml.Serialization.XmlEnumAttribute("17.19")]
        Item1719,
        [System.Xml.Serialization.XmlEnumAttribute("17.20")]
        Item1720,
        [System.Xml.Serialization.XmlEnumAttribute("17.21")]
        Item1721,
        [System.Xml.Serialization.XmlEnumAttribute("17.22")]
        Item1722,
        [System.Xml.Serialization.XmlEnumAttribute("17.23")]
        Item1723,
        [System.Xml.Serialization.XmlEnumAttribute("17.24")]
        Item1724,
        [System.Xml.Serialization.XmlEnumAttribute("17.25")]
        Item1725,
        [System.Xml.Serialization.XmlEnumAttribute("18.01")]
        Item1801,
        [System.Xml.Serialization.XmlEnumAttribute("19.01")]
        Item1901,
        [System.Xml.Serialization.XmlEnumAttribute("20.01")]
        Item2001,
        [System.Xml.Serialization.XmlEnumAttribute("20.02")]
        Item2002,
        [System.Xml.Serialization.XmlEnumAttribute("20.03")]
        Item2003,
        [System.Xml.Serialization.XmlEnumAttribute("21.01")]
        Item2101,
        [System.Xml.Serialization.XmlEnumAttribute("22.01")]
        Item2201,
        [System.Xml.Serialization.XmlEnumAttribute("23.01")]
        Item2301,
        [System.Xml.Serialization.XmlEnumAttribute("24.01")]
        Item2401,
        [System.Xml.Serialization.XmlEnumAttribute("25.01")]
        Item2501,
        [System.Xml.Serialization.XmlEnumAttribute("25.02")]
        Item2502,
        [System.Xml.Serialization.XmlEnumAttribute("25.03")]
        Item2503,
        [System.Xml.Serialization.XmlEnumAttribute("25.04")]
        Item2504,
        [System.Xml.Serialization.XmlEnumAttribute("25.05")]
        Item2505,
        [System.Xml.Serialization.XmlEnumAttribute("26.01")]
        Item2601,
        [System.Xml.Serialization.XmlEnumAttribute("27.01")]
        Item2701,
        [System.Xml.Serialization.XmlEnumAttribute("28.01")]
        Item2801,
        [System.Xml.Serialization.XmlEnumAttribute("29.01")]
        Item2901,
        [System.Xml.Serialization.XmlEnumAttribute("30.01")]
        Item3001,
        [System.Xml.Serialization.XmlEnumAttribute("31.01")]
        Item3101,
        [System.Xml.Serialization.XmlEnumAttribute("32.01")]
        Item3201,
        [System.Xml.Serialization.XmlEnumAttribute("33.01")]
        Item3301,
        [System.Xml.Serialization.XmlEnumAttribute("34.01")]
        Item3401,
        [System.Xml.Serialization.XmlEnumAttribute("35.01")]
        Item3501,
        [System.Xml.Serialization.XmlEnumAttribute("36.01")]
        Item3601,
        [System.Xml.Serialization.XmlEnumAttribute("37.01")]
        Item3701,
        [System.Xml.Serialization.XmlEnumAttribute("38.01")]
        Item3801,
        [System.Xml.Serialization.XmlEnumAttribute("39.01")]
        Item3901,
        [System.Xml.Serialization.XmlEnumAttribute("40.01")]
        Item4001,
    }

    /// <summary>
    /// Enum de compatibilidade para a versão do layout de consulta de situação da NF-e.
    /// </summary>
    public enum TVerConsSitNFeLegado
    {
        [System.Xml.Serialization.XmlEnumAttribute("4.00")]
        Item400,
    }

    /// <summary>
    /// Enum de compatibilidade que espelha os nomes da estrutura antiga para TAmb.
    /// </summary>
    public enum TAmbLegado
    {
        Producao = 1,
        Homologacao = 2
    }

    /// <summary>
    /// Enum de compatibilidade que espelha os nomes da estrutura antiga para TCodUfIBGE.
    /// </summary>
    public enum TCodUfIBGELegado
    {
        RO = 11,
        AC = 12,
        AM = 13,
        RR = 14,
        PA = 15,
        AP = 16,
        TO = 17,
        MA = 21,
        PI = 22,
        CE = 23,
        RN = 24,
        PB = 25,
        PE = 26,
        AL = 27,
        SE = 28,
        BA = 29,
        MG = 31,
        ES = 32,
        RJ = 33,
        SP = 35,
        PR = 41,
        SC = 42,
        RS = 43,
        MS = 50,
        MT = 51,
        GO = 52,
        DF = 53,
    }


    /// <summary>
    /// Enum de compatibilidade que espelha os nomes da estrutura antiga para TEnviNFeIndSinc.
    /// </summary>
    public enum TEnviNFeIndSincLegado
    {
        Assincrono,
        Sincrono
    }

    /// <summary>
    /// Enum de compatibilidade que espelha os nomes da estrutura antiga para TNFeInfNFeIdeTpEmis.
    /// </summary>
    public enum TNFeInfNFeIdeTpEmisLegado
    {
        EmissaoNormal,
        ContingenciaFS,
        SCAN,
        ContingenciaDPEC,
        ContingenciaFSDA,
        ContingenciaSVCAN,
        ContingenciaSVCRS,
        ContingenciaOffLineNFCe
    }

    /// <summary>
    /// Enum de compatibilidade que espelha os nomes da estrutura antiga para TNFeInfNFePagDetPagTPag.
    /// </summary>
    public enum TNFeInfNFePagDetPagTPagLegado
    {
        Dinheiro,
        Cheque,
        CartaoCredito,
        CartaoDebito,
        CreditoLoja,
        ValeAlimentacao,
        ValeRefeicao,
        ValePresente,
        ValeCombustivel,
        DuplicataMercantil,
        BoletoBancario,
        DepositoBancario,
        Pix,
        TransfereciaBancaria,
        ProgramaFidelidade,
        SemPagamento,
        Outros,
    }

    /// <summary>
    /// Enum de compatibilidade para as bandeiras de cartão.
    /// </summary>
    public enum TNFeInfNFePagDetPagCardTBandLegado
    {
        Visa,
        Mastercard,
        AmericanExpress,
        Sorocred,
        DinersClub,
        Elo,
        Hipercard,
        Aura,
        Cabal,
        Outros,
    }

    #endregion

    #region Classes Parciais de Compatibilidade

    public partial class TConsStatServ
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cUF.ToString().Replace("Item", "")); }
            set { this.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }
    }

    public partial class TNFeInfNFeIde
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cUF.ToString().Replace("Item", "")); }
            set { this.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TNFeInfNFeIdeTpImpLegado tpImpLegado
        {
            get
            {
                switch (this.tpImp)
                {
                    case TNFeInfNFeIdeTpImp.Item0: return TNFeInfNFeIdeTpImpLegado.SemDANFE;
                    case TNFeInfNFeIdeTpImp.Item1: return TNFeInfNFeIdeTpImpLegado.DANFENormalRetrato;
                    case TNFeInfNFeIdeTpImp.Item2: return TNFeInfNFeIdeTpImpLegado.DANFENormalPaisagem;
                    case TNFeInfNFeIdeTpImp.Item3: return TNFeInfNFeIdeTpImpLegado.DANFESimplificado;
                    case TNFeInfNFeIdeTpImp.Item4: return TNFeInfNFeIdeTpImpLegado.DANFENFCe;
                    case TNFeInfNFeIdeTpImp.Item5: return TNFeInfNFeIdeTpImpLegado.DANFENFCeEletronico;
                    default: throw new InvalidCastException("Valor de tpImp desconhecido.");
                }
            }
            set
            {
                switch (value)
                {
                    case TNFeInfNFeIdeTpImpLegado.SemDANFE: this.tpImp = TNFeInfNFeIdeTpImp.Item0; break;
                    case TNFeInfNFeIdeTpImpLegado.DANFENormalRetrato: this.tpImp = TNFeInfNFeIdeTpImp.Item1; break;
                    case TNFeInfNFeIdeTpImpLegado.DANFENormalPaisagem: this.tpImp = TNFeInfNFeIdeTpImp.Item2; break;
                    case TNFeInfNFeIdeTpImpLegado.DANFESimplificado: this.tpImp = TNFeInfNFeIdeTpImp.Item3; break;
                    case TNFeInfNFeIdeTpImpLegado.DANFENFCe: this.tpImp = TNFeInfNFeIdeTpImp.Item4; break;
                    case TNFeInfNFeIdeTpImpLegado.DANFENFCeEletronico: this.tpImp = TNFeInfNFeIdeTpImp.Item5; break;
                }
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TNFeInfNFeIdeTpEmisLegado TpEmisLegado
        {
            get
            {
                switch (this.tpEmis)
                {
                    case TNFeInfNFeIdeTpEmis.Item1: return TNFeInfNFeIdeTpEmisLegado.EmissaoNormal;
                    case TNFeInfNFeIdeTpEmis.Item2: return TNFeInfNFeIdeTpEmisLegado.ContingenciaFS;
                    case TNFeInfNFeIdeTpEmis.Item3: return TNFeInfNFeIdeTpEmisLegado.SCAN;
                    case TNFeInfNFeIdeTpEmis.Item4: return TNFeInfNFeIdeTpEmisLegado.ContingenciaDPEC;
                    case TNFeInfNFeIdeTpEmis.Item5: return TNFeInfNFeIdeTpEmisLegado.ContingenciaFSDA;
                    case TNFeInfNFeIdeTpEmis.Item6: return TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN;
                    case TNFeInfNFeIdeTpEmis.Item7: return TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS;
                    case TNFeInfNFeIdeTpEmis.Item9: return TNFeInfNFeIdeTpEmisLegado.ContingenciaOffLineNFCe;
                    default:
                        throw new InvalidCastException("Valor de tpEmis desconhecido.");
                }
            }
            set
            {
                switch (value)
                {
                    case TNFeInfNFeIdeTpEmisLegado.EmissaoNormal:
                        tpEmis = TNFeInfNFeIdeTpEmis.Item1;
                        break;
                    case TNFeInfNFeIdeTpEmisLegado.ContingenciaFS:
                        tpEmis = TNFeInfNFeIdeTpEmis.Item2;
                        break;
                    case TNFeInfNFeIdeTpEmisLegado.SCAN:
                        tpEmis = TNFeInfNFeIdeTpEmis.Item3;
                        break;
                    case TNFeInfNFeIdeTpEmisLegado.ContingenciaDPEC:
                        tpEmis = TNFeInfNFeIdeTpEmis.Item4;
                        break;
                    case TNFeInfNFeIdeTpEmisLegado.ContingenciaFSDA:
                        tpEmis = TNFeInfNFeIdeTpEmis.Item5;
                        break;
                    case TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN:
                        tpEmis = TNFeInfNFeIdeTpEmis.Item6;
                        break;
                    case TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS:
                        tpEmis = TNFeInfNFeIdeTpEmis.Item7;
                        break;
                    case TNFeInfNFeIdeTpEmisLegado.ContingenciaOffLineNFCe:
                        tpEmis = TNFeInfNFeIdeTpEmis.Item9;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }
    }

    public partial class TRetConsSitNFe
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cUF.ToString().Replace("Item", "")); }
            set { this.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TVerConsSitNFeLegado versaoLegado
        {
            get
            {
                if (this.versao == TVerConsSitNFe.Item4Period00)
                    return TVerConsSitNFeLegado.Item400;
                throw new InvalidCastException("Versão de layout de retorno de consulta de situação de NF-e incompatível.");
            }
            set
            {
                if (value == TVerConsSitNFeLegado.Item400)
                    this.versao = TVerConsSitNFe.Item4Period00;
            }
        }
    }

    public partial class TRetConsStatServ
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cUF.ToString().Replace("Item", "")); }
            set { this.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }
    }

    public partial class TInutNFeInfInut
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cUF.ToString().Replace("Item", "")); }
            set { this.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }
    }

    public partial class TRetInutNFeInfInut
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cUF.ToString().Replace("Item", "")); }
            set { this.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }
    }

    public partial class TNFeInfNFeIdeNFrefRefNFP
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cUF.ToString().Replace("Item", "")); }
            set { this.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }

        public enum ItemChoiceType { CNPJ, CPF }
        [System.Xml.Serialization.XmlIgnore]
        public ItemChoiceType ItemElementName { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string Item
        {
            get { return this.CNPJ ?? this.CPF; }
        }

        public void SetItem(string value)
        {
            if (ItemElementName == ItemChoiceType.CNPJ) this.CNPJ = value;
            else this.CPF = value;
        }
    }

    public partial class TNFeInfNFeIdeNFrefRefNF
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cUF.ToString().Replace("Item", "")); }
            set { this.cUF = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }
    }

    public partial class TNFeInfNFeDetProdCombOrigComb
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cUFOrigLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.CUFOrig.ToString().Replace("Item", "")); }
            set { this.CUFOrig = (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), "Item" + ((int)value).ToString()); }
        }
    }

    public partial class TConsReciNFe
    {
        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }
    }

    public partial class TConsSitNFe
    {
        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TVerConsSitNFeLegado versaoLegado
        {
            get
            {
                if (this.versao == TVerConsSitNFe.Item4Period00)
                    return TVerConsSitNFeLegado.Item400;
                throw new InvalidCastException("Versão de layout de retorno de consulta de situação de NF-e incompatível.");
            }
            set
            {
                if (value == TVerConsSitNFeLegado.Item400)
                    this.versao = TVerConsSitNFe.Item4Period00;
            }
        }
    }

    public partial class TRetEnviNFe
    {
        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }
    }

    public partial class TRetEventoInfEvento
    {
        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }
    }

    public partial class TEnviNFe
    {
        [System.Xml.Serialization.XmlIgnore]
        public TEnviNFeIndSincLegado indSincLegado
        {
            get
            {
                return this.indSinc == TEnviNFeIndSinc.Item1 ? TEnviNFeIndSincLegado.Sincrono : TEnviNFeIndSincLegado.Assincrono;
            }
            set
            {
                this.indSinc = (value == TEnviNFeIndSincLegado.Sincrono) ? TEnviNFeIndSinc.Item1 : TEnviNFeIndSinc.Item0;
            }
        }
    }

    public partial class TNFeInfNFePagDetPag
    {
        [System.Xml.Serialization.XmlIgnore]
        public TNFeInfNFePagDetPagTPagLegado tPagLegado
        {
            get
            {
                switch (this.tPag)
                {
                    case "01": return TNFeInfNFePagDetPagTPagLegado.Dinheiro;
                    case "02": return TNFeInfNFePagDetPagTPagLegado.Cheque;
                    case "03": return TNFeInfNFePagDetPagTPagLegado.CartaoCredito;
                    case "04": return TNFeInfNFePagDetPagTPagLegado.CartaoDebito;
                    case "05": return TNFeInfNFePagDetPagTPagLegado.CreditoLoja;
                    case "10": return TNFeInfNFePagDetPagTPagLegado.ValeAlimentacao;
                    case "11": return TNFeInfNFePagDetPagTPagLegado.ValeRefeicao;
                    case "12": return TNFeInfNFePagDetPagTPagLegado.ValePresente;
                    case "13": return TNFeInfNFePagDetPagTPagLegado.ValeCombustivel;
                    case "14": return TNFeInfNFePagDetPagTPagLegado.DuplicataMercantil;
                    case "15": return TNFeInfNFePagDetPagTPagLegado.BoletoBancario;
                    case "16": return TNFeInfNFePagDetPagTPagLegado.DepositoBancario;
                    case "17": return TNFeInfNFePagDetPagTPagLegado.Pix;
                    case "18": return TNFeInfNFePagDetPagTPagLegado.TransfereciaBancaria;
                    case "19": return TNFeInfNFePagDetPagTPagLegado.ProgramaFidelidade;
                    case "90": return TNFeInfNFePagDetPagTPagLegado.SemPagamento;
                    default: return TNFeInfNFePagDetPagTPagLegado.Outros;
                }
            }
            set
            {
                switch (value)
                {
                    case TNFeInfNFePagDetPagTPagLegado.Dinheiro: this.tPag = "01"; break;
                    case TNFeInfNFePagDetPagTPagLegado.Cheque: this.tPag = "02"; break;
                    case TNFeInfNFePagDetPagTPagLegado.CartaoCredito: this.tPag = "03"; break;
                    case TNFeInfNFePagDetPagTPagLegado.CartaoDebito: this.tPag = "04"; break;
                    case TNFeInfNFePagDetPagTPagLegado.CreditoLoja: this.tPag = "05"; break;
                    case TNFeInfNFePagDetPagTPagLegado.ValeAlimentacao: this.tPag = "10"; break;
                    case TNFeInfNFePagDetPagTPagLegado.ValeRefeicao: this.tPag = "11"; break;
                    case TNFeInfNFePagDetPagTPagLegado.ValePresente: this.tPag = "12"; break;
                    case TNFeInfNFePagDetPagTPagLegado.ValeCombustivel: this.tPag = "13"; break;
                    case TNFeInfNFePagDetPagTPagLegado.DuplicataMercantil: this.tPag = "14"; break;
                    case TNFeInfNFePagDetPagTPagLegado.BoletoBancario: this.tPag = "15"; break;
                    case TNFeInfNFePagDetPagTPagLegado.DepositoBancario: this.tPag = "16"; break;
                    case TNFeInfNFePagDetPagTPagLegado.Pix: this.tPag = "17"; break;
                    case TNFeInfNFePagDetPagTPagLegado.TransfereciaBancaria: this.tPag = "18"; break;
                    case TNFeInfNFePagDetPagTPagLegado.ProgramaFidelidade: this.tPag = "19"; break;
                    case TNFeInfNFePagDetPagTPagLegado.SemPagamento: this.tPag = "90"; break;
                    case TNFeInfNFePagDetPagTPagLegado.Outros: this.tPag = "99"; break;
                }
            }
        }
    }

    public partial class TNFeInfNFePagDetPagCard
    {
        /// <summary>
        /// Propriedade de compatibilidade para o código legado que checa se o campo foi especificado.
        /// De acordo com o schema, se o grupo card existe, tpIntegra é obrigatório.
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public bool tpIntegraSpecified
        {
            get { return true; }
            set { /* Apenas para manter a compatibilidade de compilação. O 'set' não realiza operações. */ }
        }

        [System.Xml.Serialization.XmlIgnore]
        public bool tBandSpecified
        {
            get { return !string.IsNullOrEmpty(this.tBand); }
            set { }
        }


        /// <summary>
        /// Propriedade de compatibilidade para traduzir a string 'tBand' para o enum legado.
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public TNFeInfNFePagDetPagCardTBandLegado tBandLegado
        {
            get
            {
                switch (this.tBand)
                {
                    case "01": return TNFeInfNFePagDetPagCardTBandLegado.Visa;
                    case "02": return TNFeInfNFePagDetPagCardTBandLegado.Mastercard;
                    case "03": return TNFeInfNFePagDetPagCardTBandLegado.AmericanExpress;
                    case "04": return TNFeInfNFePagDetPagCardTBandLegado.Sorocred;
                    case "05": return TNFeInfNFePagDetPagCardTBandLegado.DinersClub;
                    case "06": return TNFeInfNFePagDetPagCardTBandLegado.Elo;
                    case "07": return TNFeInfNFePagDetPagCardTBandLegado.Hipercard;
                    case "08": return TNFeInfNFePagDetPagCardTBandLegado.Aura;
                    case "09": return TNFeInfNFePagDetPagCardTBandLegado.Cabal;
                    default: return TNFeInfNFePagDetPagCardTBandLegado.Outros;
                }
            }
            set
            {
                switch (value)
                {
                    case TNFeInfNFePagDetPagCardTBandLegado.Visa: this.tBand = "01"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.Mastercard: this.tBand = "02"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.AmericanExpress: this.tBand = "03"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.Sorocred: this.tBand = "04"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.DinersClub: this.tBand = "05"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.Elo: this.tBand = "06"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.Hipercard: this.tBand = "07"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.Aura: this.tBand = "08"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.Cabal: this.tBand = "09"; break;
                    case TNFeInfNFePagDetPagCardTBandLegado.Outros: this.tBand = "99"; break;
                }
            }
        }
    }

    public partial class TNFeInfNFeDetImposto
    {
        [System.Xml.Serialization.XmlIgnore]
        public object[] Items
        {
            get
            {
                var list = new List<object>();
                if (this.ICMS != null) list.Add(this.ICMS);
                if (this.IPISpecified && this.IPI != null)
                {
                    list.AddRange(this.IPI);
                }
                if (this.II != null) list.Add(this.II);
                if (this.PIS != null) list.Add(this.PIS);
                if (this.PISST != null) list.Add(this.PISST);
                if (this.COFINS != null) list.Add(this.COFINS);
                if (this.COFINSST != null) list.Add(this.COFINSST);
                if (this.ISSQN != null) list.Add(this.ISSQN);
                return list.ToArray();
            }
        }

        public void AddImposto(object imposto)
        {
            if (imposto is TNFeInfNFeDetImpostoICMS) this.ICMS = (TNFeInfNFeDetImpostoICMS)imposto;
            else if (imposto is TIpi) { if (this.IPI == null) this.IPI = new System.Collections.ObjectModel.Collection<TIpi>(); this.IPI.Add((TIpi)imposto); }
            else if (imposto is TNFeInfNFeDetImpostoII) this.II = (TNFeInfNFeDetImpostoII)imposto;
            else if (imposto is TNFeInfNFeDetImpostoPIS) this.PIS = (TNFeInfNFeDetImpostoPIS)imposto;
            else if (imposto is TNFeInfNFeDetImpostoPISST) this.PISST = (TNFeInfNFeDetImpostoPISST)imposto;
            else if (imposto is TNFeInfNFeDetImpostoCOFINS) this.COFINS = (TNFeInfNFeDetImpostoCOFINS)imposto;
            else if (imposto is TNFeInfNFeDetImpostoCOFINSST) this.COFINSST = (TNFeInfNFeDetImpostoCOFINSST)imposto;
            else if (imposto is TNFeInfNFeDetImpostoISSQN) this.ISSQN = (TNFeInfNFeDetImpostoISSQN)imposto;
        }
    }

    public partial class TNFeInfNFeDetImpostoICMS
    {
        [System.Xml.Serialization.XmlIgnore]
        public object Item
        {
            get
            {
                if (this.ICMS00 != null) return this.ICMS00;
                if (this.ICMS02 != null) return this.ICMS02;
                if (this.ICMS10 != null) return this.ICMS10;
                if (this.ICMS15 != null) return this.ICMS15;
                if (this.ICMS20 != null) return this.ICMS20;
                if (this.ICMS30 != null) return this.ICMS30;
                if (this.ICMS40 != null) return this.ICMS40;
                if (this.ICMS51 != null) return this.ICMS51;
                if (this.ICMS53 != null) return this.ICMS53;
                if (this.ICMS60 != null) return this.ICMS60;
                if (this.ICMS61 != null) return this.ICMS61;
                if (this.ICMS70 != null) return this.ICMS70;
                if (this.ICMS90 != null) return this.ICMS90;
                if (this.ICMSPart != null) return this.ICMSPart;
                if (this.ICMSST != null) return this.ICMSST;
                if (this.ICMSSN101 != null) return this.ICMSSN101;
                if (this.ICMSSN102 != null) return this.ICMSSN102;
                if (this.ICMSSN201 != null) return this.ICMSSN201;
                if (this.ICMSSN202 != null) return this.ICMSSN202;
                if (this.ICMSSN500 != null) return this.ICMSSN500;
                if (this.ICMSSN900 != null) return this.ICMSSN900;
                return null;
            }
        }

        public void SetItem(object value)
        {
            ICMS00 = null; ICMS02 = null; ICMS10 = null; ICMS15 = null; ICMS20 = null;
            ICMS30 = null; ICMS40 = null; ICMS51 = null; ICMS53 = null; ICMS60 = null;
            ICMS61 = null; ICMS70 = null; ICMS90 = null; ICMSPart = null; ICMSST = null;
            ICMSSN101 = null; ICMSSN102 = null; ICMSSN201 = null; ICMSSN202 = null;
            ICMSSN500 = null; ICMSSN900 = null;

            if (value is TNFeInfNFeDetImpostoICMSICMS00) ICMS00 = (TNFeInfNFeDetImpostoICMSICMS00)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS02) ICMS02 = (TNFeInfNFeDetImpostoICMSICMS02)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS10) ICMS10 = (TNFeInfNFeDetImpostoICMSICMS10)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS15) ICMS15 = (TNFeInfNFeDetImpostoICMSICMS15)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS20) ICMS20 = (TNFeInfNFeDetImpostoICMSICMS20)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS30) ICMS30 = (TNFeInfNFeDetImpostoICMSICMS30)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS40) ICMS40 = (TNFeInfNFeDetImpostoICMSICMS40)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS51) ICMS51 = (TNFeInfNFeDetImpostoICMSICMS51)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS53) ICMS53 = (TNFeInfNFeDetImpostoICMSICMS53)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS60) ICMS60 = (TNFeInfNFeDetImpostoICMSICMS60)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS61) ICMS61 = (TNFeInfNFeDetImpostoICMSICMS61)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS70) ICMS70 = (TNFeInfNFeDetImpostoICMSICMS70)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMS90) ICMS90 = (TNFeInfNFeDetImpostoICMSICMS90)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMSPart) ICMSPart = (TNFeInfNFeDetImpostoICMSICMSPart)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMSST) ICMSST = (TNFeInfNFeDetImpostoICMSICMSST)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMSSN101) ICMSSN101 = (TNFeInfNFeDetImpostoICMSICMSSN101)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMSSN102) ICMSSN102 = (TNFeInfNFeDetImpostoICMSICMSSN102)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMSSN201) ICMSSN201 = (TNFeInfNFeDetImpostoICMSICMSSN201)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMSSN202) ICMSSN202 = (TNFeInfNFeDetImpostoICMSICMSSN202)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMSSN500) ICMSSN500 = (TNFeInfNFeDetImpostoICMSICMSSN500)value;
            else if (value is TNFeInfNFeDetImpostoICMSICMSSN900) ICMSSN900 = (TNFeInfNFeDetImpostoICMSICMSSN900)value;
        }
    }

    public partial class TIpi
    {
        [System.Xml.Serialization.XmlIgnore]
        public object Item
        {
            get { return (object)this.IPITrib ?? this.IPINT; }
        }

        public void SetItem(object value)
        {
            IPITrib = null; IPINT = null;
            if (value is TIpiIPITrib) IPITrib = (TIpiIPITrib)value;
            else if (value is TIpiIPINT) IPINT = (TIpiIPINT)value;
        }
    }

    public partial class TIpiIPITrib
    {
        public enum ItemsChoiceType { pIPI, qUnid, vBC, vUnid }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<ItemsChoiceType> ItemsElementName
        {
            get
            {
                var list = new List<ItemsChoiceType>();
                if (!string.IsNullOrEmpty(vBC)) list.Add(ItemsChoiceType.vBC);
                if (!string.IsNullOrEmpty(PIPI)) list.Add(ItemsChoiceType.pIPI);
                if (!string.IsNullOrEmpty(QUnid)) list.Add(ItemsChoiceType.qUnid);
                if (!string.IsNullOrEmpty(vUnid)) list.Add(ItemsChoiceType.vUnid);
                return list;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<string> Items
        {
            get
            {
                var list = new List<string>();
                if (!string.IsNullOrEmpty(vBC)) list.Add(vBC);
                if (!string.IsNullOrEmpty(PIPI)) list.Add(PIPI);
                if (!string.IsNullOrEmpty(QUnid)) list.Add(QUnid);
                if (!string.IsNullOrEmpty(vUnid)) list.Add(vUnid);
                return list;
            }
        }

        public void SetItems(ItemsChoiceType[] names, string[] values)
        {
            if (values == null || names == null || values.Length != names.Length) return;

            for (int i = 0; i < names.Length; i++)
            {
                switch (names[i])
                {
                    case ItemsChoiceType.vBC: this.vBC = values[i]; break;
                    case ItemsChoiceType.pIPI: this.PIPI = values[i]; break;
                    case ItemsChoiceType.qUnid: this.QUnid = values[i]; break;
                    case ItemsChoiceType.vUnid: this.vUnid = values[i]; break;
                }
            }
        }

        public void SetItem(ItemsChoiceType name, string value)
        {
            switch (name)
            {
                case ItemsChoiceType.vBC: this.vBC = value; break;
                case ItemsChoiceType.pIPI: this.PIPI = value; break;
                case ItemsChoiceType.qUnid: this.QUnid = value; break;
                case ItemsChoiceType.vUnid: this.vUnid = value; break;
            }
        }
    }

    public partial class TNFeInfNFeDetImpostoPIS
    {
        [System.Xml.Serialization.XmlIgnore]
        public object Item
        {
            get
            {
                if (this.PISAliq != null) return this.PISAliq;
                if (this.PISQtde != null) return this.PISQtde;
                if (this.PISNT != null) return this.PISNT;
                if (this.PISOutr != null) return this.PISOutr;
                return null;
            }
        }
        public void SetItem(object value)
        {
            PISAliq = null; PISQtde = null; PISNT = null; PISOutr = null;
            if (value is TNFeInfNFeDetImpostoPISPISAliq) PISAliq = (TNFeInfNFeDetImpostoPISPISAliq)value;
            else if (value is TNFeInfNFeDetImpostoPISPISQtde) PISQtde = (TNFeInfNFeDetImpostoPISPISQtde)value;
            else if (value is TNFeInfNFeDetImpostoPISPISNT) PISNT = (TNFeInfNFeDetImpostoPISPISNT)value;
            else if (value is TNFeInfNFeDetImpostoPISPISOutr) PISOutr = (TNFeInfNFeDetImpostoPISPISOutr)value;
        }
    }

    public partial class TNFeInfNFeDetImpostoPISPISOutr
    {
        public enum ItemsChoiceType1 { vBC, pPIS, qBCProd, vAliqProd }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<ItemsChoiceType1> ItemsElementName
        {
            get
            {
                var list = new List<ItemsChoiceType1>();
                if (!string.IsNullOrEmpty(vBC)) list.Add(ItemsChoiceType1.vBC);
                if (!string.IsNullOrEmpty(pPIS)) list.Add(ItemsChoiceType1.pPIS);
                if (!string.IsNullOrEmpty(qBCProd)) list.Add(ItemsChoiceType1.qBCProd);
                if (!string.IsNullOrEmpty(vAliqProd)) list.Add(ItemsChoiceType1.vAliqProd);
                return list;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<string> Items
        {
            get
            {
                var list = new List<string>();
                if (vBC != null) list.Add(vBC);
                if (pPIS != null) list.Add(pPIS);
                if (qBCProd != null) list.Add(qBCProd);
                if (vAliqProd != null) list.Add(vAliqProd);
                return list;
            }
        }

        public void SetItem(ItemsChoiceType1 name, string value)
        {
            switch (name)
            {
                case ItemsChoiceType1.vBC: this.vBC = value; break;
                case ItemsChoiceType1.pPIS: this.pPIS = value; break;
                case ItemsChoiceType1.qBCProd: this.qBCProd = value; break;
                case ItemsChoiceType1.vAliqProd: this.vAliqProd = value; break;
            }
        }
    }


    public partial class TNFeInfNFeDetImpostoCOFINS
    {
        [System.Xml.Serialization.XmlIgnore]
        public object Item
        {
            get
            {
                if (this.COFINSAliq != null) return this.COFINSAliq;
                if (this.COFINSQtde != null) return this.COFINSQtde;
                if (this.COFINSNT != null) return this.COFINSNT;
                if (this.COFINSOutr != null) return this.COFINSOutr;
                return null;
            }
        }
        public void SetItem(object value)
        {
            COFINSAliq = null; COFINSQtde = null; COFINSNT = null; COFINSOutr = null;
            if (value is TNFeInfNFeDetImpostoCOFINSCOFINSAliq) COFINSAliq = (TNFeInfNFeDetImpostoCOFINSCOFINSAliq)value;
            else if (value is TNFeInfNFeDetImpostoCOFINSCOFINSQtde) COFINSQtde = (TNFeInfNFeDetImpostoCOFINSCOFINSQtde)value;
            else if (value is TNFeInfNFeDetImpostoCOFINSCOFINSNT) COFINSNT = (TNFeInfNFeDetImpostoCOFINSCOFINSNT)value;
            else if (value is TNFeInfNFeDetImpostoCOFINSCOFINSOutr) COFINSOutr = (TNFeInfNFeDetImpostoCOFINSCOFINSOutr)value;
        }
    }

    public partial class TNFeInfNFeDetImpostoCOFINSCOFINSOutr
    {
        public enum ItemsChoiceType3 { vBC, pCOFINS, qBCProd, vAliqProd }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<ItemsChoiceType3> ItemsElementName
        {
            get
            {
                var list = new List<ItemsChoiceType3>();
                if (!string.IsNullOrEmpty(vBC)) list.Add(ItemsChoiceType3.vBC);
                if (!string.IsNullOrEmpty(pCOFINS)) list.Add(ItemsChoiceType3.pCOFINS);
                if (!string.IsNullOrEmpty(qBCProd)) list.Add(ItemsChoiceType3.qBCProd);
                if (!string.IsNullOrEmpty(vAliqProd)) list.Add(ItemsChoiceType3.vAliqProd);
                return list;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<string> Items
        {
            get
            {
                var list = new List<string>();
                if (vBC != null) list.Add(vBC);
                if (pCOFINS != null) list.Add(pCOFINS);
                if (qBCProd != null) list.Add(qBCProd);
                if (vAliqProd != null) list.Add(vAliqProd);
                return list;
            }
        }

        public void SetItem(ItemsChoiceType3 name, string value)
        {
            switch (name)
            {
                case ItemsChoiceType3.vBC: this.vBC = value; break;
                case ItemsChoiceType3.pCOFINS: this.pCOFINS = value; break;
                case ItemsChoiceType3.qBCProd: this.qBCProd = value; break;
                case ItemsChoiceType3.vAliqProd: this.vAliqProd = value; break;
            }
        }
    }

    public partial class TNFeInfNFeDetImpostoPISST
    {
        public enum ItemsChoiceType2 { vBC, pPIS, qBCProd, vAliqProd }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<ItemsChoiceType2> ItemsElementName
        {
            get
            {
                var list = new List<ItemsChoiceType2>();
                if (!string.IsNullOrEmpty(vBC)) list.Add(ItemsChoiceType2.vBC);
                if (!string.IsNullOrEmpty(pPIS)) list.Add(ItemsChoiceType2.pPIS);
                if (!string.IsNullOrEmpty(qBCProd)) list.Add(ItemsChoiceType2.qBCProd);
                if (!string.IsNullOrEmpty(vAliqProd)) list.Add(ItemsChoiceType2.vAliqProd);
                return list;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<string> Items
        {
            get
            {
                var list = new List<string>();
                if (vBC != null) list.Add(vBC);
                if (pPIS != null) list.Add(pPIS);
                if (qBCProd != null) list.Add(qBCProd);
                if (vAliqProd != null) list.Add(vAliqProd);
                return list;
            }
        }

        public void SetItems(ItemsChoiceType2[] names, string[] values)
        {
            if (values == null || names == null || values.Length != names.Length) return;

            for (int i = 0; i < names.Length; i++)
            {
                switch (names[i])
                {
                    case ItemsChoiceType2.vBC: this.vBC = values[i]; break;
                    case ItemsChoiceType2.pPIS: this.pPIS = values[i]; break;
                    case ItemsChoiceType2.qBCProd: this.qBCProd = values[i]; break;
                    case ItemsChoiceType2.vAliqProd: this.vAliqProd = values[i]; break;
                }
            }
        }

        public void SetItem(ItemsChoiceType2 name, string value)
        {
            switch (name)
            {
                case ItemsChoiceType2.vBC: this.vBC = value; break;
                case ItemsChoiceType2.pPIS: this.pPIS = value; break;
                case ItemsChoiceType2.qBCProd: this.qBCProd = value; break;
                case ItemsChoiceType2.vAliqProd: this.vAliqProd = value; break;
            }
        }
    }

    public partial class TNFeInfNFeDetImpostoCOFINSST
    {
        public enum ItemsChoiceType4 { vBC, pCOFINS, qBCProd, vAliqProd }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<ItemsChoiceType4> ItemsElementName
        {
            get
            {
                var list = new List<ItemsChoiceType4>();
                if (!string.IsNullOrEmpty(vBC)) list.Add(ItemsChoiceType4.vBC);
                if (!string.IsNullOrEmpty(pCOFINS)) list.Add(ItemsChoiceType4.pCOFINS);
                if (!string.IsNullOrEmpty(qBCProd)) list.Add(ItemsChoiceType4.qBCProd);
                if (!string.IsNullOrEmpty(vAliqProd)) list.Add(ItemsChoiceType4.vAliqProd);
                return list;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<string> Items
        {
            get
            {
                var list = new List<string>();
                if (vBC != null) list.Add(vBC);
                if (pCOFINS != null) list.Add(pCOFINS);
                if (qBCProd != null) list.Add(qBCProd);
                if (vAliqProd != null) list.Add(vAliqProd);
                return list;
            }
        }

        public void SetItems(ItemsChoiceType4[] names, string[] values)
        {
            if (values == null || names == null || values.Length != names.Length) return;

            for (int i = 0; i < names.Length; i++)
            {
                switch (names[i])
                {
                    case ItemsChoiceType4.vBC: this.vBC = values[i]; break;
                    case ItemsChoiceType4.pCOFINS: this.pCOFINS = values[i]; break;
                    case ItemsChoiceType4.qBCProd: this.qBCProd = values[i]; break;
                    case ItemsChoiceType4.vAliqProd: this.vAliqProd = values[i]; break;
                }
            }
        }

        public void SetItem(ItemsChoiceType4 name, string value)
        {
            switch (name)
            {
                case ItemsChoiceType4.vBC: this.vBC = value; break;
                case ItemsChoiceType4.pCOFINS: this.pCOFINS = value; break;
                case ItemsChoiceType4.qBCProd: this.qBCProd = value; break;
                case ItemsChoiceType4.vAliqProd: this.vAliqProd = value; break;
            }
        }
    }

    public partial class TNFeInfNFeDetImpostoICMSICMS10
    {
        [System.Xml.Serialization.XmlIgnore]
        public bool motDesICMSSTSpecified
        {
            get { return this.MotDesICMSSTSpecified; }
            set { this.MotDesICMSSTSpecified = value; }
        }
    }

    public partial class TNFeInfNFeDetImpostoICMSICMS70
    {
        [System.Xml.Serialization.XmlIgnore]
        public bool motDesICMSSTSpecified
        {
            get { return this.MotDesICMSSTSpecified; }
            set { this.MotDesICMSSTSpecified = value; }
        }
    }

    public partial class TNFeInfNFeDetImpostoICMSICMS90
    {
        [System.Xml.Serialization.XmlIgnore]
        public bool motDesICMSSTSpecified
        {
            get { return this.MotDesICMSSTSpecified; }
            set { this.MotDesICMSSTSpecified = value; }
        }
    }

    public partial class TNFeInfNFeTransp
    {
        public enum ItemsChoiceType5 { balsa, reboque, vagao, veicTransp }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<object> Items
        {
            get
            {
                var list = new List<object>();
                if (veicTransp != null) list.Add(veicTransp);
                if (reboque != null && reboque.Any())
                {
                    list.AddRange(reboque);
                }
                if (!string.IsNullOrEmpty(Vagao)) list.Add(Vagao);
                if (!string.IsNullOrEmpty(Balsa)) list.Add(Balsa);
                return list;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public IReadOnlyList<ItemsChoiceType5> ItemsElementName
        {
            get
            {
                var list = new List<ItemsChoiceType5>();
                if (veicTransp != null) list.Add(ItemsChoiceType5.veicTransp);
                if (reboque != null && reboque.Any())
                {
                    list.AddRange(reboque.Select(r => ItemsChoiceType5.reboque));
                }
                if (!string.IsNullOrEmpty(Vagao)) list.Add(ItemsChoiceType5.vagao);
                if (!string.IsNullOrEmpty(Balsa)) list.Add(ItemsChoiceType5.balsa);
                return list;
            }
        }

        public void SetItems(ItemsChoiceType5[] names, object[] values)
        {
            if (values == null || names == null || values.Length != names.Length) return;

            this.veicTransp = null;
            if (this.reboque != null) this.reboque.Clear();
            this.Vagao = null;
            this.Balsa = null;

            for (int i = 0; i < values.Length; i++)
            {
                switch (names[i])
                {
                    case ItemsChoiceType5.veicTransp: this.veicTransp = values[i] as TVeiculo; break;
                    case ItemsChoiceType5.reboque: if (values[i] is TVeiculo) { if (this.reboque == null) this.reboque = new System.Collections.ObjectModel.Collection<TVeiculo>(); this.reboque.Add((TVeiculo)values[i]); } break;
                    case ItemsChoiceType5.vagao: this.Vagao = values[i] as string; break;
                    case ItemsChoiceType5.balsa: this.Balsa = values[i] as string; break;
                }
            }
        }

        public void AddItem(ItemsChoiceType5 name, object value)
        {
            switch (name)
            {
                case ItemsChoiceType5.veicTransp: this.veicTransp = value as TVeiculo; break;
                case ItemsChoiceType5.reboque: if (value is TVeiculo) { if (this.reboque == null) this.reboque = new System.Collections.ObjectModel.Collection<TVeiculo>(); this.reboque.Add((TVeiculo)value); } break;
                case ItemsChoiceType5.vagao: this.Vagao = value as string; break;
                case ItemsChoiceType5.balsa: this.Balsa = value as string; break;
            }
        }
    }

    public partial class TNFeInfNFeTranspTransporta
    {
        public enum ItemChoiceType6 { CNPJ, CPF }
        [System.Xml.Serialization.XmlIgnore]
        public ItemChoiceType6 ItemElementName { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string Item
        {
            get { return !string.IsNullOrEmpty(this.CNPJ) ? this.CNPJ : this.CPF; }
        }

        public void SetItem(string value)
        {
            if (string.IsNullOrEmpty(value)) { this.CNPJ = null; this.CPF = null; }
            else if (value.Length > 11) { this.CNPJ = value; this.CPF = null; }
            else { this.CPF = value; this.CNPJ = null; }
        }
    }

    public partial class TNFeInfNFeDetProd
    {
        [System.Xml.Serialization.XmlIgnore]
        public IEnumerable<object> Items
        {
            get
            {
                if (this.VeicProd != null) yield return this.VeicProd;
                if (this.Med != null) yield return this.Med;
                if (this.Arma != null && this.Arma.Any())
                {
                    foreach (var a in this.Arma) yield return a;
                }
                if (this.Comb != null) yield return this.Comb;
                if (this.NRECOPI != null) yield return this.NRECOPI;
            }
        }

        public void AddItem(object item)
        {
            if (item is TNFeInfNFeDetProdVeicProd) this.VeicProd = (TNFeInfNFeDetProdVeicProd)item;
            else if (item is TNFeInfNFeDetProdMed) this.Med = (TNFeInfNFeDetProdMed)item;
            else if (item is TNFeInfNFeDetProdArma) { if (this.Arma == null) this.Arma = new System.Collections.ObjectModel.Collection<TNFeInfNFeDetProdArma>(); this.Arma.Add((TNFeInfNFeDetProdArma)item); }
            else if (item is TNFeInfNFeDetProdComb) this.Comb = (TNFeInfNFeDetProdComb)item;
            else if (item is string && !string.IsNullOrEmpty((string)item)) this.NRECOPI = (string)item;
        }
    }

    public partial class TNFeInfNFeIdeNFref
    {
        public enum ItemChoiceType1 { refCTe, refECF, refNF, refNFP, refNFe }

        [System.Xml.Serialization.XmlIgnore]
        public ItemChoiceType1 ItemElementName { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public object Item
        {
            get
            {
                if (this.RefNFe != null) return this.RefNFe;
                if (this.RefNF != null) return this.RefNF;
                if (this.RefNFP != null) return this.RefNFP;
                if (this.RefCTe != null) return this.RefCTe;
                if (this.RefECF != null) return this.RefECF;
                return null;
            }
        }

        public void SetItem(object value)
        {
            RefNFe = null; RefNF = null; RefNFP = null; RefCTe = null; RefECF = null;
            switch (ItemElementName)
            {
                case ItemChoiceType1.refNFe: RefNFe = value as string; break;
                case ItemChoiceType1.refNF: RefNF = value as TNFeInfNFeIdeNFrefRefNF; break;
                case ItemChoiceType1.refNFP: RefNFP = value as TNFeInfNFeIdeNFrefRefNFP; break;
                case ItemChoiceType1.refCTe: RefCTe = value as string; break;
                case ItemChoiceType1.refECF: RefECF = value as TNFeInfNFeIdeNFrefRefECF; break;
            }
        }
    }

    public partial class TNFeInfNFeEmit
    {
        public enum ItemChoiceType2 { CNPJ, CPF }
        [System.Xml.Serialization.XmlIgnore]
        public ItemChoiceType2 ItemElementName { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string Item
        {
            get { return this.CNPJ ?? this.CPF; }
        }

        public void SetItem(string value)
        {
            if (ItemElementName == ItemChoiceType2.CNPJ) this.CNPJ = value;
            else this.CPF = value;
        }
    }

    public partial class TNFeInfNFeDest
    {
        public enum ItemChoiceType3 { CNPJ, CPF, idEstrangeiro }
        [System.Xml.Serialization.XmlIgnore]
        public ItemChoiceType3 ItemElementName { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string Item
        {
            get { return this.CNPJ ?? this.CPF ?? this.IdEstrangeiro; }
        }

        public void SetItem(string value)
        {
            if (ItemElementName == ItemChoiceType3.CNPJ) this.CNPJ = value;
            else if (ItemElementName == ItemChoiceType3.CPF) this.CPF = value;
            else this.IdEstrangeiro = value;
        }
    }

    public partial class TLocal
    {
        public enum ItemChoiceType4 { CNPJ, CPF }
        [System.Xml.Serialization.XmlIgnore]
        public ItemChoiceType4 ItemElementName { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string Item
        {
            get { return this.CNPJ ?? this.CPF; }
        }

        public void SetItem(string value)
        {
            if (ItemElementName == ItemChoiceType4.CNPJ) this.CNPJ = value;
            else this.CPF = value;
        }
    }

    public partial class TNFeInfNFeAutXML
    {
        public enum ItemChoiceType5 { CNPJ, CPF }
        [System.Xml.Serialization.XmlIgnore]
        public ItemChoiceType5 ItemElementName { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public string Item
        {
            get { return this.CNPJ ?? this.CPF; }
        }

        public void SetItem(string value)
        {
            if (ItemElementName == ItemChoiceType5.CNPJ) this.CNPJ = value;
            else this.CPF = value;
        }
    }

    public partial class TRetEnviNFe
    {
        [System.Xml.Serialization.XmlIgnore]
        public object Item
        {
            get { return (object)this.infRec ?? this.protNFe; }
        }

        public void SetItem(object value)
        {
            if (value is TRetEnviNFeInfRec) this.infRec = (TRetEnviNFeInfRec)value;
            else if (value is TProtNFe) this.protNFe = (TProtNFe)value;
        }
    }

    public partial class TNFeInfNFeDetImpostoISSQN
    {
        [System.Xml.Serialization.XmlIgnore]
        public TCListServLegado cListServLegado
        {
            get
            {
                if (string.IsNullOrEmpty(this.cListServ))
                {
                    throw new InvalidOperationException("cListServ está nulo ou vazio e não pode ser convertido.");
                }
                string enumString = "Item" + this.cListServ.Replace(".", "");
                return (TCListServLegado)Enum.Parse(typeof(TCListServLegado), enumString);
            }
            set
            {
                string enumString = value.ToString();
                string numericPart = enumString.Substring(4);
                this.cListServ = $"{numericPart.Substring(0, 2)}.{numericPart.Substring(2, 2)}";
            }
        }
    }

    public partial class TNFeInfNFeDetImpostoICMSUFDest
    {
        [System.Xml.Serialization.XmlIgnore]
        public TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado pICMSInterLegado
        {
            get
            {
                switch (this.pICMSInter)
                {
                    case TNFeInfNFeDetImpostoICMSUFDestPICMSInter.Item4Period00: return TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item400;
                    case TNFeInfNFeDetImpostoICMSUFDestPICMSInter.Item7Period00: return TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item700;
                    case TNFeInfNFeDetImpostoICMSUFDestPICMSInter.Item12Period00: return TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item1200;
                    default: throw new InvalidCastException("Valor de pICMSInter desconhecido.");
                }
            }
            set
            {
                switch (value)
                {
                    case TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item400: this.pICMSInter = TNFeInfNFeDetImpostoICMSUFDestPICMSInter.Item4Period00; break;
                    case TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item700: this.pICMSInter = TNFeInfNFeDetImpostoICMSUFDestPICMSInter.Item7Period00; break;
                    case TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item1200: this.pICMSInter = TNFeInfNFeDetImpostoICMSUFDestPICMSInter.Item12Period00; break;
                }
            }
        }
    }

    #endregion
}

