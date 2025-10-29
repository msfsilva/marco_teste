using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;

namespace BibliotecaRepresentantes
{
    public class ComissaoReportDataSource
    {

        public byte[] logoEmpresa { get; private set; }

        public string RepresentanteVendedor
        {
            get
            {
                if (this.Vendedor != null)
                {
                    return this.Vendedor.ToString();
                }
                else
                {
                    return this.Representante.ToString();
                }
            }
        }

        public string Pedido { get; set; }

        public string Cliente { get; set; }

        public double Porcentagem { get; set; }

        public double Valor { get; set; }

        public DateTime Data { get; set; }

        public string DataEncerramentoPedido { get; set; }

        public Byte[] LogoCliente
        {
            get { return logoEmpresa; }
        }

        public bool Pendentes { get; set; }

        public string Tipo
        {
            get
            {
                if (this.Vendedor != null)
                {
                    return "Vendedor";
                }
                else
                {
                    return "Representante";
                }
            }
        }

        public ContaBancariaClass ContaBancaria { get; set; }

        public CentroCustoLucroClass CentroCusto { get; set; }

        public AbstractEntity EntidadeGeradora{ get; set; }

        public RepresentanteClass Representante { get; set; }

        public VendedorClass Vendedor { get; set; }

        public ComissaoReportDataSource(byte[] logoEmpresa)
        {
            
            this.logoEmpresa = logoEmpresa;
        }
    }
}