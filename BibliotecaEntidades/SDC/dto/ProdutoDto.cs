using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class ProdutoDto:ISimuladorDto
    {
        [Range(1,long.MaxValue)]
        public long id { get; set; }
        public long unidadeMedidaId { get; set; }
        [MinLength(1)]
        [Required]
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string classificacao { get; set; }

        public override string ToString()
        {
            return "Produto - [ID:" + id + "]";
        }
    }
}
