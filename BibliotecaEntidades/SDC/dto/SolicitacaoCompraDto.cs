using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class SolicitacaoCompraDto:ISimuladorDto
    {
        [Range(1,long.MaxValue)]
        public long id { get;  set; }
        [Range(1, long.MaxValue)]
        public long produtoId { get;  set; }
        public long? ordemCompraId { get;  set; }
        public double qtdUnidadeUso { get;  set; }
        [Required]
        [MinLength(1)]
        public string unidadeUso { get;  set; }
        public DateTime? entregaPrevista { get;  set; }
        public DateTime? dataAprovacaoLiberacao { get;  set; }
        public string solicitante { get;  set; }
        public double qtdUnidadeCompra { get; set; }
        public string unidadeCompra { get; set; }
        public double valorUnitarioOc { get; set; }
        public double valorTotalOc { get; set; }
        public double aliquotaIpiOc { get; set; }
        public double aliquotaIcmsOc { get; set; }
        public long idUnidadeMedidaCompra { get; set; }

        public override string ToString()
        {
            return "SolicitacaoCompra - [ID:" + id + "]";
        }
    }
}
