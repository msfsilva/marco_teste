using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class ConsumirOrdemCompraDto : ISimuladorDto
    {
        public List<long> ordensParaConsumir { get; set; } = new List<long>();

    }
}
