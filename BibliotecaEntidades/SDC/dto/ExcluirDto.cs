using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class ExcluirDto:ISimuladorDto
    {
        public List<long> ids { get; set; } = new List<long>();
    }

}
