using System;

namespace BibliotecaNotasFiscais
{
    internal class organizaNfMaterialClienteClass
    {
        public int idPedidoItemLoteCliente { get; private set; }
        public int idLote { get; private set; }        
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string NCM { get; private set; }
        public string CEST { get; private set; }

        public string CodigoBeneficioFiscal { get; private set; }

        public string Unidade { get; private set; }
        public int? idProduto { get; private set; }
        public int? idMaterial { get; private set; }
        public double Quantidade { get; private set; }
        public double Saldo { get; private set; }
        public double valorUnitario { get; private set; }
        public double valorTotal
        {
            get
            {
                return valorUnitario * Quantidade;
            }
        }

        public string nfSerie { get; private set; }
        public string nfNumero { get; private set; }
        public DateTime nfData { get; private set; }

        public double saldoTotalLote { get; private set; }

        public organizaNfMaterialClienteClass(int idPedidoItemLoteCliente, int idLote, string Codigo, string Descricao,
                                              string NCM,string cest,string codigoBeneficioFiscal,  string Unidade, 
                                              int? idProduto, int? idMaterial, double Quantidade, double Saldo, double valorUnitario, string nfSerie,
                                              string nfNumero, DateTime nfData, double saldoTotalLote)
        {
            this.idPedidoItemLoteCliente = idPedidoItemLoteCliente;
            this.idLote = idLote;
            this.Codigo = Codigo;
            this.Descricao = Descricao;
            this.NCM = NCM;
            CEST = cest;
            CodigoBeneficioFiscal = codigoBeneficioFiscal;
            this.Unidade = Unidade;
            this.idProduto = idProduto;
            this.idMaterial = idMaterial;
            this.Quantidade = Quantidade;
            this.Saldo = Saldo;
            this.valorUnitario = valorUnitario;
            this.nfSerie = nfSerie;
            this.nfNumero = nfNumero;
            this.nfData = nfData;
            this.saldoTotalLote = saldoTotalLote;
        }

    }
}