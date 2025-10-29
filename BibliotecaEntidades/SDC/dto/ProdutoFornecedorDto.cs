using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class ProdutoFornecedorDto : ISimuladorDto
    {
        [Range(1,long.MaxValue)]
        public long id { get; set; }
        [Range(1, long.MaxValue)]
        public long produtoId { get; set; }
        [Range(1, long.MaxValue)]
        public long fornecedorId { get; set; }
        [Range(1, long.MaxValue)]
        public long unidadeMedidaId { get; set; }
        public double conversaoUnidade { get; set; }
        public bool fornecedorPreferencial { get; set; }
        public double loteMinimo { get; set; }
        public double lotePadrao { get; set; }
        public double precoUnitario { get; set; }
        public double aliquotaIpi { get; set; }
        public double aliquotaIcms { get; set; }

        public DateTime? dataUltimaCompra { get; set; }

        public DateTime? dataUltimoRecebimento { get; set; }

        public override string ToString()
        {
            return "ProdutoFornecedor - [ID:" + id + "]";
        }


    }
}
