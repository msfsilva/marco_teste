using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaExpedicao
{
   public class EmbarqueReportClass
   {
       public int Numero { get; set;}
       public byte[] NumeroBc { get; set; }
       public string Item { get; set; }
        public string DataConferencia { get; set; }
        public string Conferidor { get; set; }
        public byte[] LogoEmpresa { get; set; }
        public double Quantidade { get; set; }
    }
}
