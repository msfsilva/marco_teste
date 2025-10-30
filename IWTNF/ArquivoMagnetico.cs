#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;

#endregion

namespace IWTNF
{
    
    public enum FinalidadeArquivoMagnetico { Normal = 1, RetificacaoTotal = 2, RetificacaoAditiva = 3, Desfazimento = 5 }
    public enum TipoPosse { PoderInformante = 1, PoderTerceiros = 2, PropriedadeTerceiros = 3 }
               
    public class ArquivoMagnetico
    {
        readonly reg10 Registro10;
        readonly reg11 Registro11;
        //internal SortedDictionary<DateTime, reg50> Registro50;
        internal List<reg50> Registro50;
        //internal SortedDictionary<DateTime, reg51> Registro51;
        internal List<reg51> Registro51;
        //internal SortedDictionary<DateTime, reg53> Registro53;
        internal List<reg53> Registro53;
        //internal SortedDictionary<reg54SortingKey, reg54> Registro54;
        internal List<reg54> Registro54;
        //internal SortedDictionary<DateTime, reg55> Registro55;
        internal List<reg55> Registro55;
        //internal SortedDictionary<reg74SortingKey, reg74> Registro74;
        internal List<reg74> Registro74;
        //internal SortedDictionary<string, reg75> Registro75;
        internal List<reg75> Registro75;
        readonly reg90 Registro90;

        public ArquivoMagnetico(reg10 Registro10, reg11 Registro11)
        {
            this.Registro10 = Registro10;
            this.Registro11 = Registro11;
            //this.Registro50 = new SortedDictionary<DateTime, reg50>();
            this.Registro50 = new List<reg50>();
            //this.Registro51 = new SortedDictionary<DateTime, reg51>();
            this.Registro51 = new List<reg51>();
            //this.Registro53 = new SortedDictionary<DateTime, reg53>();
            this.Registro53 = new List<reg53>();
            //this.Registro54 = new SortedDictionary<reg54SortingKey, reg54>(new Reg54Comparer());
            this.Registro54 = new List<reg54>();
            //this.Registro55 = new SortedDictionary<DateTime, reg55>();
            this.Registro55 = new List<reg55>();
            //this.Registro74 = new SortedDictionary<reg74SortingKey, reg74>(new Reg74Comparer());
            this.Registro74 = new List<reg74>();
            //this.Registro75 = new SortedDictionary<string, reg75>();
            this.Registro75 = new List<reg75>();
            this.Registro90 = new reg90(Registro10.getCNPJ(), Registro10.getInscricaoEstadual(), this);
        }

        public void addReg50(reg50 regToAdd)
        {
            this.Registro50.Add(regToAdd);
        }

        public void addReg51(reg51 regToAdd)
        {
            this.Registro51.Add(regToAdd);
        }

        public void addReg53(reg53 regToAdd)
        {
            this.Registro53.Add(regToAdd);
        }

        public void addReg54(reg54 regToAdd)
        {
            this.Registro54.Add(regToAdd);
        }

        public void addReg55(reg55 regToAdd)
        {
            this.Registro55.Add(regToAdd);
        }

        public void addReg74(reg74 regToAdd)
        {
            this.Registro74.Add(regToAdd);
        }

        public void addReg75(reg75 regToAdd)
        {
            this.Registro75.Add(regToAdd);
        }

        public string GenerateString()
        {
            string toRet = this.Registro10.GenerateString() + this.Registro11.GenerateString();
            if (this.Registro50.Count > 0)
            {
                this.Registro50.Sort(new Reg50Comparer());
                foreach (reg50 reg in this.Registro50)
                {
                    toRet += reg.GenerateString();
                }
            }
            if (this.Registro51.Count > 0)
            {
                this.Registro51.Sort(new Reg51Comparer());
                foreach (reg51 reg in this.Registro51)
                {
                    toRet += reg.GenerateString();
                }
            }
            if (this.Registro53.Count > 0)
            {
                this.Registro53.Sort(new Reg53Comparer());
                foreach (reg53 reg in this.Registro53)
                {
                    toRet += reg.GenerateString();
                }
            }
            if (this.Registro54.Count > 0)
            {
                this.Registro54.Sort(new Reg54Comparer());
                foreach (reg54 reg in this.Registro54)
                {
                    toRet += reg.GenerateString();
                }
            }
            if (this.Registro55.Count > 0)
            {
                this.Registro55.Sort(new Reg55Comparer());
                foreach (reg55 reg in this.Registro55)
                {
                    toRet += reg.GenerateString();
                }
            }
            if (this.Registro74.Count > 0)
            {
                this.Registro74.Sort(new Reg74Comparer());
                foreach (reg74 reg in this.Registro74)
                {
                    toRet += reg.GenerateString();
                }
            }
            if (this.Registro75.Count > 0)
            {
                this.Registro75.Sort(new Reg75Comparer());
                foreach (reg75 reg in this.Registro75)
                {
                    toRet += reg.GenerateString();
                }
            }

            toRet += this.Registro90.GenerateString();
            return toRet;

        }
    }

    public class reg10
    {
        private readonly string _CNPJ;
        private readonly string _InscricaoEstadual;
        private readonly string _NomeContribuinte;
        private readonly string _Municipio;
        private readonly string _UF;
        private readonly Int64 _Fax;
        private DateTime _DataInicial;
        private DateTime _DataFinal;
        private readonly int _CodigoConvenio; //Código da Identificação do convenio
        private readonly int _CodigoNaturezaOperacao;//Código da Identificação das naturezas das operações informadas
        private readonly FinalidadeArquivoMagnetico _CodigoFinalidadeArquivo;     //Código da finalidade do arquivo magnético

        internal reg10(string CNPJ, string InscricaoEstadual, string NomeContribuinte, string Municipio, string UF, Int64 Fax, DateTime DataInicial, DateTime DataFinal, int CodigoConvenio, int CodigoNaturezaOperacao, FinalidadeArquivoMagnetico CodigoFinalidadeArquivo)
        {
            try
            {
                this._CNPJ = IWTNfFunctionsClass.validateMaxLength(CNPJ, 14, false, "CNPJ");
                this._InscricaoEstadual = IWTNfFunctionsClass.validateMaxLength(InscricaoEstadual, 14, false, "Inscrição Estadual");
                this._NomeContribuinte = IWTNfFunctionsClass.validateMaxLength(NomeContribuinte, 35, true, "Nome do Contribuinte");
                this._Municipio = IWTNfFunctionsClass.validateMaxLength(Municipio, 30, true, "Municipio");
                this._UF = IWTNfFunctionsClass.validateMaxLength(UF, 2, false, "UF");
                this._Fax = (Int64)IWTNfFunctionsClass.validateInterval((double)Fax, 0, 9999999999, "Fax");
                this._DataInicial = DataInicial;
                this._DataFinal = DataFinal;
                this._CodigoConvenio = IWTNfFunctionsClass.validateOptions(CodigoConvenio, new List<int> { 1, 2, 3 }, "Código do Convênio");
                this._CodigoNaturezaOperacao = IWTNfFunctionsClass.validateOptions(CodigoNaturezaOperacao, new List<int> { 1, 2, 3 }, "Código da Natureza da Operação");
                this._CodigoFinalidadeArquivo = CodigoFinalidadeArquivo;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 10.\r\n" + e.Message);
            }
        }

        #region Gets
        internal string getCNPJ()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CNPJ), 14, ' ', TipoFill.Direita);
        }

        internal string getInscricaoEstadual()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._InscricaoEstadual), 14, ' ', TipoFill.Direita);
        }

        internal string getNomeContribuinte()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._NomeContribuinte), 35, ' ', TipoFill.Direita);
        }

        internal string getMunicipio()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Municipio), 30, ' ', TipoFill.Direita);
        }

        internal string getUF()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._UF), 2, ' ', TipoFill.Direita);
        }

        internal string getFax()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Fax.ToString()), 10, '0', TipoFill.Esquerda);
        }

        internal string getDataInicial()
        {
            return this._DataInicial.ToString("yyyyMMdd");
        }

        internal string getDataFinal()
        {
            return this._DataFinal.ToString("yyyyMMdd");
        }

        internal string getCodigoConvenio()
        {
            return IWTNfFunctionsClass.fillValue(this._CodigoConvenio.ToString(), 1, '0', TipoFill.Esquerda);
        }

        internal string getCodigoNaturezaOperacao()
        {
            return IWTNfFunctionsClass.fillValue(this._CodigoNaturezaOperacao.ToString(), 1, '0', TipoFill.Esquerda);
        }

        internal string getCodigoFinalidadeArquivo()
        {
            return ((int)this._CodigoFinalidadeArquivo).ToString();
        }
        #endregion

        internal string GenerateString()
        {
            return "10" + this.getCNPJ() + this.getInscricaoEstadual() + this.getNomeContribuinte() + this.getMunicipio() + this.getUF() + this.getFax() + this.getDataInicial() + this.getDataFinal() + this.getCodigoConvenio() + this.getCodigoNaturezaOperacao() + this.getCodigoFinalidadeArquivo() + IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }
    }

    public class reg11
    {
        private readonly string _Logradouro;
        private readonly Int64 _Numero;
        private readonly string _Complemento;
        private readonly string _Bairro;
        private readonly Int64 _CEP;
        private readonly string _NomeContato;
        private readonly Int64 _Fone;

        internal reg11(string Logradouro, Int64 Numero, string Complemento, string Bairro, Int64 CEP, string NomeContato, Int64 Fone)
        {
            try
            {
                this._Logradouro = IWTNfFunctionsClass.validateMaxLength(Logradouro, 34, true, "Logradouro");
                this._Numero = (Int64)IWTNfFunctionsClass.validateInterval((double)Numero, 0, 99999, "Número");
                this._Complemento = IWTNfFunctionsClass.validateMaxLength(Complemento, 22, true, "Complemento");
                this._Bairro = IWTNfFunctionsClass.validateMaxLength(Bairro, 22, true, "Bairro");
                this._CEP = (Int64)IWTNfFunctionsClass.validateInterval((double)CEP, 0, 99999999, "CEP");
                this._NomeContato = IWTNfFunctionsClass.validateMaxLength(NomeContato, 28, true, "NomeContato");
                this._Fone = (Int64)IWTNfFunctionsClass.validateInterval((double)Fone, 0, 999999999999, "Fone");

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 11.\r\n" + e.Message);
            }
        }

        #region Gets
        internal string getLogradouro()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Logradouro), 34, ' ', TipoFill.Direita);
        }

        internal string getNumero()
        {
            return IWTNfFunctionsClass.fillValue(this._Numero.ToString(), 5, '0', TipoFill.Esquerda);
        }

        internal string getComplemento()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Complemento), 22, ' ', TipoFill.Direita);
        }

        internal string getBairro()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Bairro), 15, ' ', TipoFill.Direita);
        }

        internal string getCEP()
        {
            return IWTNfFunctionsClass.fillValue(this._CEP.ToString(), 8, '0', TipoFill.Esquerda);
        }

        internal string getNomeContato()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._NomeContato), 28, ' ', TipoFill.Direita);
        }

        internal string getFone()
        {
            return IWTNfFunctionsClass.fillValue(this._Fone.ToString(), 12, '0', TipoFill.Esquerda);
        }
        #endregion

        internal string GenerateString()
        {
            return "11" + this.getLogradouro() + this.getNumero() + this.getComplemento() + this.getBairro() + this.getCEP() + this.getNomeContato() + this.getFone() + IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }
    }

    public class reg50
    {
        private readonly string _CNPJ;
        private readonly string _InscricaoEstadual;
        internal DateTime _Data { get; private set; } //Data de Emissao ou recebimento
        private readonly string _UF;
        private readonly Int32 _Modelo;
        private readonly string _Serie;
        internal Int64 _Numero { get; private set; }
        private readonly Int64 _CFOP;
        private readonly string _Emitente;
        private readonly double _ValorTotal;
        private readonly double _BaseCalculoICMS;
        private readonly double _ValorICMS;
        private readonly double _Isenta;
        private readonly double _Outras;
        private readonly double _Aliquota;
        private readonly string _Situacao;

        internal reg50(string CNPJ, string InscricaoEstadual, DateTime Data, string UF, Int32 Modelo, string Serie, Int64 Numero, Int64 CFOP, string Emitente, double ValorTotal, double BaseCalculoICMS, double ValorICMS, double Isenta, double Outras, double Aliquota, string Situacao)
        {
            try
            {
                this._CNPJ = IWTNfFunctionsClass.validateMaxLength(CNPJ, 14, false, "CNPJ");
                this._InscricaoEstadual = IWTNfFunctionsClass.validateMaxLength(InscricaoEstadual, 14, false, "Inscrição Estadual");
                this._Data = Data;
                this._UF = IWTNfFunctionsClass.validateMaxLength(UF, 2, false, "UF");
                this._Modelo = (Int32)IWTNfFunctionsClass.validateInterval((double)Modelo, 0, 99, "Modelo");
                this._Serie = IWTNfFunctionsClass.validateMaxLength(Serie, 3, false, "Série");
                this._Numero = (Int64)IWTNfFunctionsClass.validateInterval((double)Numero, 0, 999999, "Número");
                this._CFOP = (Int64)IWTNfFunctionsClass.validateInterval((double)CFOP, 0, 9999, "CFOP");
                this._Emitente = IWTNfFunctionsClass.validateMaxLength(Emitente, 1, false, "Emitente");
                this._ValorTotal = IWTNfFunctionsClass.validateInterval(ValorTotal, 0, 99999999999.99, "Valor Total");
                this._BaseCalculoICMS = IWTNfFunctionsClass.validateInterval(BaseCalculoICMS, 0, 99999999999.99, "Base de Calculo ICMS");
                this._ValorICMS = IWTNfFunctionsClass.validateInterval(ValorICMS, 0, 99999999999.99, "Valor do ICMS");
                this._Isenta = IWTNfFunctionsClass.validateInterval(Isenta, 0, 99999999999.99, "Isenta ou não tributada");
                this._Outras = IWTNfFunctionsClass.validateInterval(Outras, 0, 99999999999.99, "Outras");
                this._Aliquota = IWTNfFunctionsClass.validateInterval(Aliquota, 0, 99.99, "Alíquota ICMS");
                this._Situacao = IWTNfFunctionsClass.validateMaxLength(Situacao, 1, false, "Situação");
               

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 50.\r\n" + e.Message);
            }
        }


        #region Gets
        internal string getCNPJ()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CNPJ), 14, ' ', TipoFill.Direita);
        }

        internal string getInscricaoEstadual()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._InscricaoEstadual), 14, ' ', TipoFill.Direita);
        }

        internal string getData()
        {
            return this._Data.ToString("yyyyMMdd");
        }

        internal string getUF()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._UF), 2, ' ', TipoFill.Direita);
        }

        internal string getModelo()
        {
            return IWTNfFunctionsClass.fillValue(this._Modelo.ToString(), 2, '0', TipoFill.Esquerda);
        }

        internal string getSerie()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Serie), 3, ' ', TipoFill.Direita);
        }

        internal string getNumero()
        {
            return IWTNfFunctionsClass.fillValue(this._Numero.ToString(), 6, '0', TipoFill.Esquerda);
        }

        internal string getCFOP()
        {
            return IWTNfFunctionsClass.fillValue(this._CFOP.ToString(), 4, '0', TipoFill.Esquerda);
        }

        internal string getEmitente()
        {
            return this._Emitente;
        }

        internal string getValorTotal()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorTotal.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getBaseCalculoICMS()
        {
            return IWTNfFunctionsClass.fillValue(this._BaseCalculoICMS.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getValorICMS()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorICMS.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getIsenta()
        {
            return IWTNfFunctionsClass.fillValue(this._Isenta.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getOutras()
        {
            return IWTNfFunctionsClass.fillValue(this._Outras.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getAliquota()
        {
            return IWTNfFunctionsClass.fillValue(this._Aliquota.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 4, '0', TipoFill.Esquerda);
        }

        internal string getSituacao()
        {
            return this._Situacao;
        }    

        #endregion

        internal string GenerateString()
        {
            return "50" + this.getCNPJ() + this.getInscricaoEstadual() + this.getData() + this.getUF() + this.getModelo() + this.getSerie() + this.getNumero() + this.getCFOP() +
                this.getEmitente() + this.getValorTotal() + this.getBaseCalculoICMS() + this.getValorICMS() + this.getIsenta() + this.getOutras() + this.getAliquota() + this.getSituacao()+IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }

    }

    public class reg51
    {
        private readonly string _CNPJ;
        private readonly string _InscricaoEstadual;
        internal DateTime _Data { get; private set; } //Data de Emissao ou recebimento
        private readonly string _UF;
        private readonly string _Serie;
        internal Int64 _Numero { get; private set; } 
        private readonly Int64 _CFOP;
        private readonly double _ValorTotal;
        private readonly double _ValorIPI;
        private readonly double _Isenta;
        private readonly double _Outras;
        private readonly string _Situacao;

        internal reg51(string CNPJ, string InscricaoEstadual, DateTime Data, string UF, string Serie, Int64 Numero, Int64 CFOP, double ValorTotal, double ValorIPI, double Isenta, double Outras, string Situacao)
        {
            try
            {
                this._CNPJ = IWTNfFunctionsClass.validateMaxLength(CNPJ, 14, false, "CNPJ");
                this._InscricaoEstadual = IWTNfFunctionsClass.validateMaxLength(InscricaoEstadual, 14, false, "Inscrição Estadual");
                this._Data = Data;
                this._UF = IWTNfFunctionsClass.validateMaxLength(UF, 2, false, "UF");
                this._Serie = IWTNfFunctionsClass.validateMaxLength(Serie, 3, false, "Série");
                this._Numero = (Int64)IWTNfFunctionsClass.validateInterval((double)Numero, 0, 999999, "Número");
                this._CFOP = (Int64)IWTNfFunctionsClass.validateInterval((double)CFOP, 0, 9999, "CFOP");
                this._ValorTotal = IWTNfFunctionsClass.validateInterval(ValorTotal, 0, 99999999999.99, "Valor Total");
                this._ValorIPI = IWTNfFunctionsClass.validateInterval(ValorIPI, 0, 99999999999.99, "Valor do IPI");
                this._Isenta = IWTNfFunctionsClass.validateInterval(Isenta, 0, 99999999999.99, "Isenta ou não tributada");
                this._Outras = IWTNfFunctionsClass.validateInterval(Outras, 0, 99999999999.99, "Outras");
                this._Situacao = IWTNfFunctionsClass.validateMaxLength(Situacao, 1, false, "Situação");
               

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 51.\r\n" + e.Message);
            }
        }

        #region Gets
        internal string getCNPJ()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CNPJ), 14, ' ', TipoFill.Direita);
        }

        internal string getInscricaoEstadual()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._InscricaoEstadual), 14, ' ', TipoFill.Direita);
        }

        internal string getData()
        {
            return this._Data.ToString("yyyyMMdd");
        }

        internal string getUF()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._UF), 2, ' ', TipoFill.Direita);
        }

       

        internal string getSerie()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Serie), 3, ' ', TipoFill.Direita);
        }

        internal string getNumero()
        {
            return IWTNfFunctionsClass.fillValue(this._Numero.ToString(), 6, '0', TipoFill.Esquerda);
        }

        internal string getCFOP()
        {
            return IWTNfFunctionsClass.fillValue(this._CFOP.ToString(), 4, '0', TipoFill.Esquerda);
        }

        

        internal string getValorTotal()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorTotal.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        

        internal string getValorIPI()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorIPI.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getIsenta()
        {
            return IWTNfFunctionsClass.fillValue(this._Isenta.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getOutras()
        {
            return IWTNfFunctionsClass.fillValue(this._Outras.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }


        internal string getSituacao()
        {
            return this._Situacao;
        }

        #endregion

        internal string GenerateString()
        {
            return "51" + this.getCNPJ() + this.getInscricaoEstadual() + this.getData() + this.getUF() + this.getSerie() + this.getNumero() + this.getCFOP() + this.getValorTotal() +
                this.getValorIPI() + this.getIsenta() + this.getOutras() + IWTNfFunctionsClass.fillValue("", 20, ' ', TipoFill.Esquerda) + this.getSituacao() + IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }
    }

    public class reg53
    {
        private readonly string _CNPJ;
        private readonly string _InscricaoEstadual;
        internal DateTime _Data { get; private set; } //Data de Emissao ou recebimento
        private readonly string _UF;
        private readonly Int32 _Modelo;
        private readonly string _Serie;
        internal Int64 _Numero { get; private set; }
        private readonly Int64 _CFOP;
        private readonly string _Emitente;
        private readonly double _BaseCalculoICMSST;
        private readonly double _ICMSRetido;
        private readonly double _DespesasAcessorias;
        private readonly string _Situacao;
        private readonly string _CodigoAntecipacao;

        internal reg53(string CNPJ, string InscricaoEstadual, DateTime Data, string UF, Int32 Modelo, string Serie, Int64 Numero, Int64 CFOP, string Emitente, double BaseCalculoICMSST, double ICMSRetido, double DespesasAcessorias, string Situacao, string CodigoAntecipacao)
        {
            try
            {
                this._CNPJ = IWTNfFunctionsClass.validateMaxLength(CNPJ, 14, false, "CNPJ");
                this._InscricaoEstadual = IWTNfFunctionsClass.validateMaxLength(InscricaoEstadual, 14, false, "Inscrição Estadual");
                this._Data = Data;
                this._UF = IWTNfFunctionsClass.validateMaxLength(UF, 2, false, "UF");
                this._Modelo = (Int32)IWTNfFunctionsClass.validateInterval((double)Modelo, 0, 99, "Modelo");
                this._Serie = IWTNfFunctionsClass.validateMaxLength(Serie, 3, false, "Série");
                this._Numero = (Int64)IWTNfFunctionsClass.validateInterval((double)Numero, 0, 999999, "Número");
                this._CFOP = (Int64)IWTNfFunctionsClass.validateInterval((double)CFOP, 0, 9999, "CFOP");
                this._Emitente = IWTNfFunctionsClass.validateMaxLength(Emitente, 1, false, "Emitente");
                this._BaseCalculoICMSST = IWTNfFunctionsClass.validateInterval(BaseCalculoICMSST, 0, 99999999999.99, "Base de Calculo ICMS ST");
                this._ICMSRetido = IWTNfFunctionsClass.validateInterval(ICMSRetido, 0, 99999999999.99, "Valor do ICMS Retido");
                this._DespesasAcessorias = IWTNfFunctionsClass.validateInterval(DespesasAcessorias, 0, 99999999999.99, "Despesas Acessórias");
                this._Situacao = IWTNfFunctionsClass.validateMaxLength(Situacao, 1, false, "Situacao");
                this._CodigoAntecipacao = IWTNfFunctionsClass.validateOptions(CodigoAntecipacao, new List<string>() { "1", "2", "3", "4", "5", "6", "" }, "Código da Antecipação");

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 53.\r\n" + e.Message);
            }
        }


        #region Gets
        internal string getCNPJ()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CNPJ), 14, ' ', TipoFill.Direita);
        }

        internal string getInscricaoEstadual()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._InscricaoEstadual), 14, ' ', TipoFill.Direita);
        }

        internal string getData()
        {
            return this._Data.ToString("yyyyMMdd");
        }

        internal string getUF()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._UF), 2, ' ', TipoFill.Direita);
        }

        internal string getModelo()
        {
            return IWTNfFunctionsClass.fillValue(this._Modelo.ToString(), 2, '0', TipoFill.Esquerda);
        }

        internal string getSerie()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Serie), 3, ' ', TipoFill.Direita);
        }

        internal string getNumero()
        {
            return IWTNfFunctionsClass.fillValue(this._Numero.ToString(), 6, '0', TipoFill.Esquerda);
        }

        internal string getCFOP()
        {
            return IWTNfFunctionsClass.fillValue(this._CFOP.ToString(), 4, '0', TipoFill.Esquerda);
        }

        internal string getEmitente()
        {
            return this._Emitente;
        }


        internal string getBaseCalculoICMSST()
        {
            return IWTNfFunctionsClass.fillValue(this._BaseCalculoICMSST.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getICMSRetido()
        {
            return IWTNfFunctionsClass.fillValue(this._ICMSRetido.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getDespesasAcessorias()
        {
            return IWTNfFunctionsClass.fillValue(this._DespesasAcessorias.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getSituacao()
        {
            return this._Situacao;
        }

        internal string getCodigoAntecipacao()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CodigoAntecipacao), 1, ' ', TipoFill.Direita);
        } 

        #endregion

        internal string GenerateString()
        {
            return "53" + this.getCNPJ() + this.getInscricaoEstadual() + this.getData() + this.getUF()+ this.getModelo() + this.getSerie() + this.getNumero() + this.getCFOP() + this.getEmitente() +
                this.getBaseCalculoICMSST() + this.getICMSRetido() + this.getDespesasAcessorias() + this.getSituacao() + this.getCodigoAntecipacao() + IWTNfFunctionsClass.fillValue("", 29, ' ', TipoFill.Esquerda) + IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }
    }

    public class reg54
    {
        internal string _CNPJ { get; private set; } 
        private readonly Int32 _Modelo;
        internal string _Serie { get; private set; }
        internal Int32 _Numero { get; private set; } 
        private readonly Int64 _CFOP;
        private readonly string _CST;
        internal Int64 _NumeroItem { get; private set; } 
        private readonly string _CodigoProdutoServico;
        private readonly double _Quantidade;
        private readonly double _ValorProduto;
        private readonly double _ValorDesconto;
        private readonly double _BaseCalculoICMS;
        private readonly double _BaseCalculoICMSST;
        private readonly double _ValorIPI;
        private readonly double _AliquotaICMS;

        internal reg54(string CNPJ, Int32 Modelo, string Serie, Int64 Numero, Int64 CFOP, string CST, Int32 NumeroItem,string CodigoProdutoServico, double Quantidade, double ValorProduto,double ValorDesconto,double BaseCalculoICMS,double BaseCalculoICMSST,double ValorIPI,double AliquotaICMS)
        {
            try
            {
                this._CNPJ = IWTNfFunctionsClass.validateMaxLength(CNPJ, 14, false, "CNPJ");
                this._Modelo = (Int32)IWTNfFunctionsClass.validateInterval((double)Modelo, 0, 99, "Modelo");
                this._Serie = IWTNfFunctionsClass.validateMaxLength(Serie, 3, false, "Série");
                this._Numero = (Int32)IWTNfFunctionsClass.validateInterval((double)Numero, 0, 999999, "Número");
                this._CFOP = (Int64)IWTNfFunctionsClass.validateInterval((double)CFOP, 0, 9999, "CFOP");
                this._CST = IWTNfFunctionsClass.validateMaxLength(CST, 3, false, "CST");
                this._NumeroItem = (Int32)IWTNfFunctionsClass.validateInterval((double)NumeroItem, 0, 999, "Número Item");
                this._CodigoProdutoServico = IWTNfFunctionsClass.validateMaxLength(CodigoProdutoServico, 14, true, "Código do Produto ou Servico");
                this._Quantidade = IWTNfFunctionsClass.validateInterval(Quantidade, 0, 99999999.999, "Quantidade");
                this._ValorProduto = IWTNfFunctionsClass.validateInterval(ValorProduto, 0, 9999999999.99, "Valor do Produto");
                this._ValorDesconto = IWTNfFunctionsClass.validateInterval(ValorDesconto, 0, 9999999999.99, "Valor do Desconto");
                this._BaseCalculoICMS = IWTNfFunctionsClass.validateInterval(BaseCalculoICMS, 0, 9999999999.99, "Base de Calculo ICMS");
                this._BaseCalculoICMSST = IWTNfFunctionsClass.validateInterval(BaseCalculoICMSST, 0, 9999999999.99, "Base de Calculo ICMS ST");
                this._ValorIPI = IWTNfFunctionsClass.validateInterval(ValorIPI, 0, 9999999999.99, "Valor do IPI");
                this._AliquotaICMS = IWTNfFunctionsClass.validateInterval(AliquotaICMS, 0, 99.99, "Alíquota ICMS");
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 54.\r\n" + e.Message);
            }
        }


        #region Gets
        internal string getCNPJ()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CNPJ), 14, ' ', TipoFill.Direita);
        }

        internal string getModelo()
        {
            return IWTNfFunctionsClass.fillValue(this._Modelo.ToString(), 2, '0', TipoFill.Esquerda);
        }

        internal string getSerie()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Serie), 3, ' ', TipoFill.Direita);
        }

        internal string getNumero()
        {
            return IWTNfFunctionsClass.fillValue(this._Numero.ToString(), 6, '0', TipoFill.Esquerda);
        }

        internal string getCFOP()
        {
            return IWTNfFunctionsClass.fillValue(this._CFOP.ToString(), 4, '0', TipoFill.Esquerda);
        }

        internal string getCST()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CST), 3, ' ', TipoFill.Direita);
        }

        internal string getNumeroItem()
        {
            return IWTNfFunctionsClass.fillValue(this._NumeroItem.ToString(), 3, '0', TipoFill.Esquerda);
        }

        internal string getCodigoProdutoServico()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CodigoProdutoServico), 14, ' ', TipoFill.Direita);
        }

        internal string getQuantidade()
        {
            return IWTNfFunctionsClass.fillValue(this._Quantidade.ToString("F3", CultureInfo.InvariantCulture).Replace(".", ""), 11, '0', TipoFill.Esquerda);
        }

        internal string getValorProduto()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorProduto.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 12, '0', TipoFill.Esquerda);
        }

        internal string getValorDesconto()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorDesconto.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 12, '0', TipoFill.Esquerda);
        }

        internal string getBaseCalculoICMS()
        {
            return IWTNfFunctionsClass.fillValue(this._BaseCalculoICMS.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 12, '0', TipoFill.Esquerda);
        }

        internal string getBaseCalculoICMSST()
        {
            return IWTNfFunctionsClass.fillValue(this._BaseCalculoICMSST.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 12, '0', TipoFill.Esquerda);
        }

        internal string getValorIPI()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorIPI.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 12, '0', TipoFill.Esquerda);
        }

        internal string getAliquotaICMS()
        {
            return IWTNfFunctionsClass.fillValue(this._AliquotaICMS.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 4, '0', TipoFill.Esquerda);
        }


        #endregion

        internal string GenerateString()
        {
            return "54" + this.getCNPJ() + this.getModelo() + this.getSerie() + this.getNumero() + this.getCFOP() + this.getCST() + this.getNumeroItem() + this.getCodigoProdutoServico() +
                this.getQuantidade() + this.getValorProduto() + this.getValorDesconto() + this.getBaseCalculoICMS() + this.getBaseCalculoICMSST() + this.getValorIPI() + this.getAliquotaICMS() + IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }
    }

    public class reg55
    {
        private readonly string _CNPJ;
        private readonly string _InscricaoEstadual;
        internal DateTime _DataGNRE { get; private set; } 
        private readonly string _UFSubstituto;
        private readonly string _UFFavorecida;
        private readonly Int32 _BancoGNRE;
        private readonly Int32 _AgenciaGNRE;
        private readonly string _NumeroGNRE;
        private readonly double _ValorGNRE;
        private DateTime _DataVencimento;
        private readonly Int64 _MesAnoReferencia;
        private readonly string _NumeroConvenioProtocoloMercadoria;

        internal reg55(string CNPJ, string InscricaoEstadual, DateTime DataGNRE, string UFSubstituto,string UFFavorecida,Int32 BancoGNRE,Int32 AgenciaGNRE,string NumeroGNRE,double ValorGNRE,DateTime DataVencimento,Int64 MesAnoReferencia,string NumeroConvenioProtocoloMercadoria)
        {
            try
            {
                this._CNPJ = IWTNfFunctionsClass.validateMaxLength(CNPJ, 14, false, "CNPJ");
                this._InscricaoEstadual = IWTNfFunctionsClass.validateMaxLength(InscricaoEstadual, 14, false, "Inscrição Estadual");
                this._DataGNRE = DataGNRE;
                this._UFSubstituto = IWTNfFunctionsClass.validateMaxLength(UFSubstituto, 2, false, "UF Substituto");
                this._UFFavorecida = IWTNfFunctionsClass.validateMaxLength(UFFavorecida, 2, false, "UF Favorecida");
                this._BancoGNRE = (Int32)IWTNfFunctionsClass.validateInterval((double)BancoGNRE, 0, 999, "Banco da GNRE");
                this._AgenciaGNRE = (Int32)IWTNfFunctionsClass.validateInterval((double)AgenciaGNRE, 0, 9999, "Agencia da GNRE");
                this._NumeroGNRE = IWTNfFunctionsClass.validateMaxLength(NumeroGNRE, 20, false, "Numero da autenticação da GNRE");
                this._ValorGNRE = IWTNfFunctionsClass.validateInterval(ValorGNRE, 0, 99999999999.99, "Valor GNRE");
                this._DataVencimento = DataVencimento;
                this._MesAnoReferencia = (Int64)IWTNfFunctionsClass.validateInterval((double)MesAnoReferencia, 0, 999999, "Mês e Ano de Referência");
                this._NumeroConvenioProtocoloMercadoria = IWTNfFunctionsClass.validateMaxLength(NumeroConvenioProtocoloMercadoria, 30, false, "Número do Convênio ou Protocolo/Mercadoria");

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 55.\r\n" + e.Message);
            }
        }

        #region Gets
        internal string getCNPJ()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CNPJ), 14, ' ', TipoFill.Direita);
        }

        internal string getInscricaoEstadual()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._InscricaoEstadual), 14, ' ', TipoFill.Direita);
        }

        internal string getDataGNRE()
        {
            return this._DataGNRE.ToString("yyyyMMdd");
        }

        internal string getUFSubstituto()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._UFSubstituto), 2, ' ', TipoFill.Direita);
        }

        internal string getUFFavorecida()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._UFFavorecida), 2, ' ', TipoFill.Direita);
        }

        internal string getBancoGNRE()
        {
            return IWTNfFunctionsClass.fillValue(this._BancoGNRE.ToString(), 3, '0', TipoFill.Esquerda);
        }

        internal string getAgenciaGNRE()
        {
            return IWTNfFunctionsClass.fillValue(this._AgenciaGNRE.ToString(), 4, '0', TipoFill.Esquerda);
        }

        internal string getNumeroGNRE()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._NumeroGNRE), 20, ' ', TipoFill.Direita);
        }

        internal string getValorGNRE()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorGNRE.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getDataVencimento()
        {
            return this._DataVencimento.ToString("yyyyMMdd");
        }

        internal string getMesAnoReferencia()
        {
            return IWTNfFunctionsClass.fillValue(this._MesAnoReferencia.ToString(), 6, '0', TipoFill.Esquerda);
        }

        internal string getNumeroConvenioProtocoloMercadoria()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._NumeroConvenioProtocoloMercadoria), 30, ' ', TipoFill.Direita);
        }

        #endregion

        internal string GenerateString()
        {
            return "55" + this.getCNPJ() + this.getInscricaoEstadual() + this.getDataGNRE() + this.getUFSubstituto() + this.getUFFavorecida() + this.getBancoGNRE() + this.getAgenciaGNRE() +
                this.getNumeroGNRE() + this.getValorGNRE() + this.getDataVencimento() + this.getMesAnoReferencia() + this.getNumeroConvenioProtocoloMercadoria() + IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }

    }

    public class reg74
    {
        internal DateTime _DataInventario { get; private set; }
        internal string _CodigoProduto { get; private set; } 
        private readonly double _Quantidade;
        private readonly double _ValorProdutos;
        private readonly TipoPosse _CodigoPosse;
        private readonly string _CNPJ;
        private readonly string _InscricaoEstadual;
        private readonly string _UF;

        internal reg74(DateTime DataInventario,string CodigoProduto,double Quantidade,double ValorProdutos,TipoPosse CodigoPosse,string CNPJ,string InscricaoEstadual,string UF)
        {
            try
            {
                this._DataInventario = DataInventario;
                this._CodigoProduto = IWTNfFunctionsClass.validateMaxLength(CodigoProduto, 14, true, "Código do Produto");
                this._Quantidade = IWTNfFunctionsClass.validateInterval(Quantidade, 0, 9999999999.999, "Quantidade");
                this._ValorProdutos = IWTNfFunctionsClass.validateInterval(ValorProdutos, 0, 99999999999.99, "Valor dos Produtos");
                this._CodigoPosse = CodigoPosse;
                this._CNPJ = IWTNfFunctionsClass.validateMaxLength(CNPJ, 14, false, "CNPJ");
                this._InscricaoEstadual = IWTNfFunctionsClass.validateMaxLength(InscricaoEstadual, 14, false, "Inscrição Estadual");
                this._UF = IWTNfFunctionsClass.validateMaxLength(UF, 2, false, "UF");
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 74.\r\n" + e.Message);
            }
        }


        #region Gets
        internal string getDataInventario()
        {
            return this._DataInventario.ToString("yyyyMMdd");
        }

        internal string getCodigoProduto()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CodigoProduto), 14, ' ', TipoFill.Direita);
        }

        internal string getQuantidade()
        {
            return IWTNfFunctionsClass.fillValue(this._Quantidade.ToString("F3", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getValorProdutos()
        {
            return IWTNfFunctionsClass.fillValue(this._ValorProdutos.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        internal string getCodigoPosse()
        {
            return ((int)this._CodigoPosse).ToString();
        } 

        internal string getCNPJ()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CNPJ), 14, ' ', TipoFill.Direita);
        }

        internal string getInscricaoEstadual()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._InscricaoEstadual), 14, ' ', TipoFill.Direita);
        }

        internal string getUF()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._UF), 2, ' ', TipoFill.Direita);
        }
        #endregion

        internal string GenerateString()
        {
            return "74" + this.getDataInventario() + this.getCodigoProduto() + this.getQuantidade() + this.getValorProdutos() + this.getCodigoPosse() +
                this.getCNPJ() + this.getInscricaoEstadual() + this.getUF() + IWTNfFunctionsClass.fillValue("", 45, ' ', TipoFill.Esquerda) + IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }

    }

    public class reg75
    {
        private DateTime _DataInicial;
        private DateTime _DataFinal;
        internal string _CodigoProdutoServico { get; private set; }
        private readonly string _CodigoNCM;
        private readonly string _Descricao;
        private readonly string _UnidadeMedida;
        private readonly double _AliquotaIPI;
        private readonly double _AliquotaICMS;
        private readonly double _ReducaoBaseCalculoICMS;
        private readonly double _BaseCalculoICMSST;

        public reg75(DateTime DataInicial,DateTime DataFinal,string CodigoProdutoServico,string CodigoNCM,string Descricao,string UnidadeMedida,double AliquotaIPI,double AliquotaICMS,double ReducaoBaseCalculoICMS,double BaseCalculoICMSST)
        {
            try{
                this._DataInicial = DataInicial;
                this._DataFinal = DataFinal;
                this._CodigoProdutoServico = IWTNfFunctionsClass.validateMaxLength(CodigoProdutoServico, 14, true, "Código do Produto ou Serviço");
                this._CodigoNCM = IWTNfFunctionsClass.validateMaxLength(CodigoNCM, 8, false, "Código NCM");
                this._Descricao = IWTNfFunctionsClass.validateMaxLength(Descricao, 53, true, "Descrição");
                this._UnidadeMedida = IWTNfFunctionsClass.validateMaxLength(UnidadeMedida, 6, true, "Unidade de Medida");
                this._AliquotaIPI = IWTNfFunctionsClass.validateInterval(AliquotaIPI, 0, 999.99, "Alíquota IPI");
                this._AliquotaICMS = IWTNfFunctionsClass.validateInterval(AliquotaICMS, 0, 99.99, "Alíquota ICMS");
                this._ReducaoBaseCalculoICMS = IWTNfFunctionsClass.validateInterval(ReducaoBaseCalculoICMS, 0, 999.99, "Redução da Base de Cálculo ICMS");
                this._BaseCalculoICMSST = IWTNfFunctionsClass.validateInterval(BaseCalculoICMSST, 0, 99999999999.99, "Base de Cálculo ICMS ST");
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar registro 75.\r\n" + e.Message);
            }

        }

        #region Gets
        internal string getDataInicial()
        {
            return this._DataInicial.ToString("yyyyMMdd");
        }

        internal string getDataFinal()
        {
            return this._DataFinal.ToString("yyyyMMdd");
        }

        internal string getCodigoProdutoServico()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CodigoProdutoServico), 14, ' ', TipoFill.Direita);
        }

        internal string getCodigoNCM()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CodigoNCM), 8, ' ', TipoFill.Direita);
        }

        internal string getDescricao()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._Descricao), 53, ' ', TipoFill.Direita);
        }

        internal string getUnidadeMedida()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._UnidadeMedida), 6, ' ', TipoFill.Direita);
        }

        internal string getAliquotaIPI()
        {
            return IWTNfFunctionsClass.fillValue(this._AliquotaIPI.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 5, '0', TipoFill.Esquerda);
        }

        internal string getAliquotaICMS()
        {
            return IWTNfFunctionsClass.fillValue(this._AliquotaICMS.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 4, '0', TipoFill.Esquerda);
        }

        internal string getReducaoBaseCalculoICMS()
        {
            return IWTNfFunctionsClass.fillValue(this._ReducaoBaseCalculoICMS.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 5, '0', TipoFill.Esquerda);
        }

        internal string getBaseCalculoICMSST()
        {
            return IWTNfFunctionsClass.fillValue(this._BaseCalculoICMSST.ToString("F2", CultureInfo.InvariantCulture).Replace(".", ""), 13, '0', TipoFill.Esquerda);
        }

        #endregion

        internal string GenerateString()
        {
            return "75" + this.getDataInicial() + this.getDataFinal() + this.getCodigoProdutoServico() + this.getCodigoNCM() + this.getDescricao() + this.getUnidadeMedida() +
                this.getAliquotaIPI() + this.getAliquotaICMS() + this.getReducaoBaseCalculoICMS() + this.getBaseCalculoICMSST() + IWTNfFunctionsClass.LINE_BREAK_CHAR;
        }
    }

    internal class reg90
    {
        private readonly string _CNPJ;
        private readonly string _InscricaoEstadual;
        private readonly Dictionary<Int16, Int64> _TotalRegistros;
        private int _NumRegTip90 =0;
        private readonly ArquivoMagnetico Parent;

        internal reg90(string CNPJ, string InscricaoEstadual, ArquivoMagnetico Parent)
        {
            this._CNPJ = IWTNfFunctionsClass.validateMaxLength(CNPJ, 14, false, "CNPJ");
            this._InscricaoEstadual = IWTNfFunctionsClass.validateMaxLength(InscricaoEstadual, 14, false, "Inscrição Estadual");
            this.Parent = Parent;

            this._TotalRegistros = new Dictionary<Int16, Int64>();

        }

        private void populateTotalRegistros()
        {
            if (this.Parent.Registro50.Count > 0)
            {
                this._TotalRegistros.Add(50, this.Parent.Registro50.Count);
            }
            if (this.Parent.Registro51.Count > 0)
            {
                this._TotalRegistros.Add(51, this.Parent.Registro51.Count);
            }
            if (this.Parent.Registro53.Count > 0)
            {
                this._TotalRegistros.Add(53, this.Parent.Registro53.Count);
            }
            if (this.Parent.Registro54.Count > 0)
            {
                this._TotalRegistros.Add(54, this.Parent.Registro54.Count);
            }
            if (this.Parent.Registro55.Count > 0)
            {
                this._TotalRegistros.Add(55, this.Parent.Registro55.Count);
            }
            if (this.Parent.Registro74.Count > 0)
            {
                this._TotalRegistros.Add(74, this.Parent.Registro74.Count);
            }
            if (this.Parent.Registro75.Count > 0)
            {
                this._TotalRegistros.Add(75, this.Parent.Registro75.Count);
            }
         }

        #region Gets
        internal string getCNPJ()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._CNPJ), 14, ' ', TipoFill.Direita);
        }

        internal string getInscricaoEstadual()
        {
            return IWTNfFunctionsClass.fillValue(IWTFunctions.IWTFunctions.stringCleaner(this._InscricaoEstadual), 14, ' ', TipoFill.Direita);
        }

        internal string getNumRegTip90()
        {
            return IWTNfFunctionsClass.fillValue(this._NumRegTip90.ToString(), 1, '0', TipoFill.Esquerda);
        }

        #endregion

        internal string GenerateString()
        {
            if (this._TotalRegistros.Count == 0)
            {
                this.populateTotalRegistros();
            }

            string toRet = "";
            int countCaracteres = 0;
            int ocupadoUmaEntrada = 10;
            int limiteCaracteres = 95;
            List<string> tmp = new List<string>() ;
            tmp.Add("");
            long totalReg = 2;
            foreach (KeyValuePair<Int16, Int64> tipo in this._TotalRegistros)
            {
                if (countCaracteres + ocupadoUmaEntrada > limiteCaracteres)
                {
                    tmp[tmp.Count - 1] += IWTNfFunctionsClass.fillValue("", limiteCaracteres - countCaracteres, ' ', TipoFill.Esquerda);
                    tmp.Add("");
                    countCaracteres = 0;
                }

                tmp[tmp.Count - 1] += IWTNfFunctionsClass.fillValue(tipo.Key.ToString(), 2, '0', TipoFill.Esquerda);
                tmp[tmp.Count - 1] += IWTNfFunctionsClass.fillValue(tipo.Value.ToString(), 8, '0', TipoFill.Esquerda);
                countCaracteres += ocupadoUmaEntrada;
                totalReg += tipo.Value;
            }
            if (countCaracteres + ocupadoUmaEntrada > limiteCaracteres)
            {
                tmp[tmp.Count - 1] += IWTNfFunctionsClass.fillValue("", limiteCaracteres - countCaracteres, ' ', TipoFill.Esquerda);
                tmp.Add("");
                countCaracteres = 0;
            }
            totalReg += tmp.Count;
            tmp[tmp.Count - 1] += IWTNfFunctionsClass.fillValue("99", 2, '0', TipoFill.Esquerda);
            tmp[tmp.Count - 1] += IWTNfFunctionsClass.fillValue(totalReg.ToString(), 8, '0', TipoFill.Esquerda);
            countCaracteres += ocupadoUmaEntrada;

            tmp[tmp.Count - 1] += IWTNfFunctionsClass.fillValue("", limiteCaracteres - countCaracteres, ' ', TipoFill.Esquerda);
            this._NumRegTip90 = tmp.Count;

            foreach (string linha in tmp)
            {
                toRet += "90" + this.getCNPJ() + this.getInscricaoEstadual() + linha + this.getNumRegTip90() + IWTNfFunctionsClass.LINE_BREAK_CHAR;
            }

            return toRet;

        }
        
    }

    #region Classes Auxiliares

    internal class Reg50Comparer : IComparer<reg50>
    {

        public int Compare(reg50 a, reg50 b)
        {
            //a vem antes retorna -1 a vem depois retorna 1
            if (DateTime.Compare(a._Data.Date, b._Data.Date) < 0)
            {
                return -1;
            }
            else
            {
                if (DateTime.Compare(a._Data.Date, b._Data.Date) > 0)
                {
                    return 1;
                }
                else
                {
                    //Data Igual
                    if (a._Numero<b._Numero)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;   
                    }
                }
            }
        }
    }

    internal class Reg51Comparer : IComparer<reg51>
    {

        public int Compare(reg51 a, reg51 b)
        {
            //a vem antes retorna -1 a vem depois retorna 1
            if (DateTime.Compare(a._Data.Date, b._Data.Date) < 0)
            {
                return -1;
            }
            else
            {
                if (DateTime.Compare(a._Data.Date, b._Data.Date) > 0)
                {
                    return 1;
                }
                else
                {
                    //Data Igual
                    if (a._Numero < b._Numero)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }
    }

    internal class Reg53Comparer : IComparer<reg53>
    {

        public int Compare(reg53 a, reg53 b)
        {
            //a vem antes retorna -1 a vem depois retorna 1
            if (DateTime.Compare(a._Data.Date, b._Data.Date) < 0)
            {
                return -1;
            }
            else
            {
                if (DateTime.Compare(a._Data.Date, b._Data.Date) > 0)
                {
                    return 1;
                }
                else
                {
                    //Data Igual
                    if (a._Numero < b._Numero)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }
    }

    internal class reg54SortingKey
    {
        internal string CNPJ;
        internal string Serie;
        internal Int32 Numero;
        internal Int64 NumeroItem;
    }

    internal class Reg54Comparer : IComparer<reg54>
    {

        public int Compare(reg54 a, reg54 b)
        {
            //a vem antes retorna -1 a vem depois retorna 1
            if (string.Compare(a._CNPJ, b._CNPJ, StringComparison.CurrentCultureIgnoreCase) < 0)
            {
                return -1;
            }
            else
            {
                if (string.Compare(a._CNPJ, b._CNPJ, StringComparison.CurrentCultureIgnoreCase) > 0)
                {
                    return 1;
                }
                else
                {
                    //CNPJ Igual
                    if (string.Compare(a._Serie, b._Serie, StringComparison.CurrentCultureIgnoreCase) < 0)
                    {
                        return -1;
                    }
                    else
                    {
                        if (string.Compare(a._Serie, b._Serie, StringComparison.CurrentCultureIgnoreCase) > 0)
                        {
                            return 1;
                        }
                        else
                        {
                            //Série Igual
                            if (a._Numero < b._Numero)
                            {
                                return -1;
                            }
                            else
                            {
                                if (a._Numero > b._Numero)
                                {
                                    return 1;
                                }
                                else
                                {
                                    //Número Igual
                                    if (a._NumeroItem < b._NumeroItem)
                                    {
                                        return -1;
                                    }
                                    else
                                    {
                                        return 1;

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    internal class Reg55Comparer : IComparer<reg55>
    {

        public int Compare(reg55 a, reg55 b)
        {
            //a vem antes retorna -1 a vem depois retorna 1
            if (DateTime.Compare(a._DataGNRE.Date, b._DataGNRE.Date) < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    internal class reg74SortingKey
    {
        internal DateTime DataInventario;
        internal string CodigoProduto;
    }

    internal class Reg74Comparer : IComparer<reg74>
    {
        public int Compare(reg74 a, reg74 b)
        {
            if (a._DataInventario.Date < b._DataInventario.Date)
            {
                return -1;
            }
            else
            {
                if (a._DataInventario.Date > b._DataInventario.Date)
                {
                    return 1;
                }
                else
                {
                    //Data Igual
                    if (string.Compare(a._CodigoProduto, b._CodigoProduto, StringComparison.CurrentCultureIgnoreCase) < 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }
    }

    internal class Reg75Comparer : IComparer<reg75>
    {

        public int Compare(reg75 a, reg75 b)
        {
            //a vem antes retorna -1 a vem depois retorna 1
            if (String.Compare(a._CodigoProdutoServico, b._CodigoProdutoServico, StringComparison.CurrentCultureIgnoreCase) < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    #endregion
}
