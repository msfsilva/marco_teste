using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class OrdemCompraSaidaDto : ISimuladorDto
    {
        public List<OrdemCompraDto> ordemCompraDtoList { get; set; } = new List<OrdemCompraDto>();

    }
}
