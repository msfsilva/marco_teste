using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class OrdemCompraDto:ISimuladorDto
    {
        public long id { get; set; }
        public long fornecedorId { get; set; }
        public double valor { get; set; }
        public DateTime data { get; set; }
        public double valorComImpostos { get; set; }
        public string observacao { get; set; }
        public double descontoP { get; set; }
        public double descontoR { get; set; }
        public double frete { get; set; }
        public double valorComDesconto { get; set; }
        public List<SolicitacaoCompraDto> collectionSolicitacaoCompra { get; set; }

    }
}
