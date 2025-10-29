#region Referencias

using System;

#endregion

namespace BibliotecaCompras
{
    public class OrcamentoReportClass
    {
        public string identificacao { get; set; }
        public string tipo { get; set; }
        public double valor { get; set; }
        public string forRazaoSocial { get; set; }
        private string _forCnpj;
        public string forCnpj
        {
            get
            {
                if (!this._forCnpj.Contains("."))
                {
                    if (this._forCnpj.Length == 14)
                    {
                        this._forCnpj =
                            this._forCnpj.Substring(0, 2) + "." +
                            this._forCnpj.Substring(2, 3) + "." +
                            this._forCnpj.Substring(5, 3) + "/" +
                            this._forCnpj.Substring(8, 4) + "-" +
                            this._forCnpj.Substring(12, 2);
                    }

                    if (this._forCnpj.Length == 11)
                    {
                        this._forCnpj =
                            this._forCnpj.Substring(0, 3) + "." +
                            this._forCnpj.Substring(3, 3) + "." +
                            this._forCnpj.Substring(6, 3) + "-" +
                            this._forCnpj.Substring(9, 2);
                    }

                }
                return this._forCnpj;
            }
            set
            {
                this._forCnpj = value;
            }
        }
        private string _forFone1;
        public string forFone1
        {
            get
            {
                if (!this._forFone1.Contains("-"))
                {
                    if (this._forFone1.Length == 10)
                    {
                        this._forFone1 = "(" + this._forFone1.Substring(0, 2) + ") " + this._forFone1.Substring(2, 4) + " - " + this._forFone1.Substring(6);
                    }
                }

                return this._forFone1;

            }
            set
            {
                this._forFone1 = value;
            }
        }
        public string forEmail { get; set; }
        public string forEndereco { get; set; }
        public string forCidade { get; set; }
        public string forUf { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }

        public double qtd { get; set; }
        public double valorUnit { get; set; }              
        public byte[] barCode { get; set; }
        public string unid { get; set; }
        public string familiaMaterial { get; set; }
        public string descricaoAdicional { get; set; }
        public string marcasHomologadas { get; set; }
        public string Acabamento { get; set; }
        public string Dimensoes { get; set; }
     
        public string dataEntrega { get; set; }
        public string statusOC { get; set; }

        public string cliRazaoSocial { get; set; }

        private string _cliCnpj;
        public string cliCnpj
        {
            get
            {
                if (!this._cliCnpj.Contains("."))
                {
                    if (this._cliCnpj.Length == 14)
                    {
                        this._cliCnpj =
                            this._cliCnpj.Substring(0, 2) + "." +
                            this._cliCnpj.Substring(2, 3) + "." +
                            this._cliCnpj.Substring(5, 3) + "/" +
                            this._cliCnpj.Substring(8, 4) + "-" +
                            this._cliCnpj.Substring(12, 2);
                    }

                    if (this._cliCnpj.Length == 11)
                    {
                        this._cliCnpj =
                            this._cliCnpj.Substring(0, 3) + "." +
                            this._cliCnpj.Substring(3, 3) + "." +
                            this._cliCnpj.Substring(6, 3) + "-" +
                            this._cliCnpj.Substring(9, 2);
                    }

                }
                return this._cliCnpj;
            }
            set
            {
                this._cliCnpj = value;
            }
        }

        private string _cliFone1;
        public string cliFone1
        {
            get
            {
                if (!this._cliFone1.Contains("-"))
                {
                    if (this._cliFone1.Length == 10)
                    {
                        this._cliFone1 = "(" + this._cliFone1.Substring(0, 2) + ") " + this._cliFone1.Substring(2, 4) + " - " + this._cliFone1.Substring(6);
                    }
                }

                return this._cliFone1;

            }
            set
            {
                this._cliFone1 = value;
            }
        }

        public string cliEmail { get; set; }
        public string cliEndereco { get; set; }
        public string cliCidade { get; set; }
        public string cliUf { get; set; }
        public string cliContato { get; set; }

        public byte[] logoEmpresa { get; set; }

        public double aliquotaIPI { get; set; }
        public double aliquotaICMS { get; set; }
        public double valorIPI
        {
            get
            {
                return this.valorUnit * (aliquotaIPI/100);
            }
        }

        public double valorICMS
        {
            get
            {
                return this.valorUnit * (aliquotaICMS/100);
            }
        }

        public double valorUnitarioComImpostos
        {
            get
            {
                //return this.valorUnit + this.valorICMS + this.valorIPI;
                return this.valorUnit + this.valorIPI;
            }
        }

        public double valotTotalComImpostos
        {
            get
            {
                return this.valorUnitarioComImpostos * this.qtd;
            }
        }

        public double valotTotal
        {
            get
            {
                return this.valorUnit * this.qtd;
            }
        }

        public double ValorTotalOCcomImpostos { get; set; }

        public string Rodape { get; private set; }

        public OrcamentoReportClass(
            string identificacao,
            string statusOC,
            string tipo,
            double valor,
            string forRazaoSocial,
            string forCnpj,
            string forFone1,
            string forEmail,
            string forEndereco,
            string forCidade,
            string forUf,
            string codigo,
            string descricao,
            string descricaoAdicional ,
            string marcasHomologadas,
            double qtd,
            byte[] barCode,
            double valorUnit,
            string unid,
            string familiaMaterial,
            double totalItem,
            DateTime? dataEntrega,
            string cliRazaoSocial,
            string cliCnpj,
            string cliFone1,
            string cliEmail,
            string cliEndereco,
            string cliCidade,
            string cliUf,
            string cliContato,
            double aliquotaIPI,
            double aliquotaICMS,
            string Acabamento,
            string Dimensoes,
            byte[] logoEmpresa, 
            string rodape)
        {
            this.identificacao = identificacao;
            this.statusOC = statusOC;

            this.tipo = tipo;
            this.valor = valor;
            this.forRazaoSocial = forRazaoSocial;
            this.forCnpj = forCnpj;
            this.forFone1 = forFone1;
            this.forEmail = forEmail;
            this.forEndereco = forEndereco;
            this.forCidade = forCidade;
            this.forUf = forUf;
            this.codigo = codigo;
            this.descricao = descricao;
            this.qtd = qtd;
            this.valorUnit = valorUnit;
            this.barCode = barCode;
            this.unid = unid;
            this.familiaMaterial = familiaMaterial;
            this.descricaoAdicional = descricaoAdicional;
            this.marcasHomologadas = marcasHomologadas;

            if (dataEntrega != null)
            {
                this.dataEntrega = dataEntrega.Value.ToString("dd/MM/yyyy");
            }

            this.cliRazaoSocial = cliRazaoSocial;
            this.cliCnpj = cliCnpj;
            this.cliFone1 = cliFone1 ;
            this.cliEmail = cliEmail;
            this.cliEndereco = cliEndereco;
            this.cliCidade = cliCidade;
            this.cliUf = cliUf;
            this.cliContato = cliContato;

            this.aliquotaIPI = aliquotaIPI;
            this.aliquotaICMS = aliquotaICMS;
            this.Acabamento = Acabamento;
            this.Dimensoes = Dimensoes;
            this.logoEmpresa = logoEmpresa;

            this.Rodape = rodape;

        }
        
    }
}
