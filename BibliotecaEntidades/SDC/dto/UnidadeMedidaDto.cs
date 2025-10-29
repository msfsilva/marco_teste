using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class UnidadeMedidaDto: ISimuladorDto
    {
        [Range(1, long.MaxValue)]
        public long id { get; set; }
        [Required]
        [MinLength(1)]
        public string abreviatura { get; set; }
        [Required]
        [MinLength(1)]
        public string nomeExtenso { get; set; }

        public override string ToString()
        {
            return "UnidadeMedida - [ID:" + id + "]";
        }

    }
}
