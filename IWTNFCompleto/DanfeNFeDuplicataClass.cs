using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace IWTNFCompleto
{
    public class DanfeNFeDuplicataClass
    {
        public string Numero { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public double Valor { get; private set; }

        public DanfeNFeDuplicataClass(string numero, DateTime dataVencimento, double valor)
        {
            Numero = numero;
            DataVencimento = dataVencimento;
            Valor = valor;
        }

        public override string ToString()
        {
            return "Nr: "+this.Numero + " Venc: " + this.DataVencimento.ToString("dd/MM/yyyy") + " Valor " + Valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        }
    }
}
