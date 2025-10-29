using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.SDC.dto
{
    public class FornecedorDto: ISimuladorDto
    {
        [Range(1,long.MaxValue)]
        public long id { get; set; }
        [Required]
        [MinLength(1)]
        public string nome { get; set; }
        public string enderecoLogradouro { get; set; }
        public string enderecoNumero { get; set; }
        public string enderecoComplemento { get; set; }
        public string enderecoBairro { get; set; }
        public string enderecoCep { get; set; }
        [Required]
        [MinLength(1)]
        public string cidade { get; set; }
        [Required]
        [MinLength(1)]
        public string estado { get; set; }
        [Required]
        [MinLength(1)]
        public string pais { get; set; }
        public string cpfCnpj { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string contato { get; set; }
        public string observacoes { get; set; }

        public override string ToString()
        {
            return "Fornecedor - [ID:" + id + "]";
        }
    }
}
