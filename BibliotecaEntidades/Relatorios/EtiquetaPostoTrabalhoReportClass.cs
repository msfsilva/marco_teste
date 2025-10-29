using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.Relatorios
{
    public class EtiquetaPostoTrabalhoReportClass
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Operacao { get; set; }
        public bool Rastreamento { get; set; }
        public string Acompanhamento { get; set; }
        public bool Produtivo { get; set; }
        public byte[] Barcode { get; set; }




        public static List<EtiquetaPostoTrabalhoReportClass> Gerar(List<PostoTrabalhoClass> postos)
        {
            List<EtiquetaPostoTrabalhoReportClass> ds = new List<EtiquetaPostoTrabalhoReportClass>();

            foreach (PostoTrabalhoClass posto in postos)
            {
                ds.Add(
                    new EtiquetaPostoTrabalhoReportClass()
                    {
                        Id = posto.ID,
                        Codigo = posto.Codigo,
                        Nome = posto.Nome,
                        Operacao = posto.OperacaoPosto,
                        Acompanhamento = posto.Acompanhamento.ToString(),
                        Rastreamento = posto.Rastreamento,
                        Produtivo = posto.Produtivo,
                        Barcode = posto.Barcode
                    }
                );
            }

            return ds;

        }
    }
}
