using BibliotecaEntidades.Entidades;
using System.Linq;
using Configurations;
using ProjectConstants;

namespace BibliotecaEntidades.Relatorios
{
    public class RetiradaEpiReportClass
    {
        private readonly FuncionarioEpiClass funcionarioEpi;

        public long IdFuncionario
        {
            get { return this.funcionarioEpi.Funcionario.ID; }
        }

        public string IdentificacaoEpi
        {
            get { return this.funcionarioEpi.Epi.Identificacao; }
        }

        public string DescricaoEpi
        {
            get { return this.funcionarioEpi.Epi.Descricao; }
        }

        public RetiradaEpiReportClass(FuncionarioEpiClass funcionarioEpi)
        {
            this.funcionarioEpi = funcionarioEpi;
        }

        public string DescricaoAdicional
        {
            get { return this.funcionarioEpi.Epi.DescricaoAdicional; }
        }

        public string Observacao
        {
            get { return this.funcionarioEpi.Epi.Observacao; }
        }

        public string CA
        {
            get { return this.funcionarioEpi.Epi.EpiCa.ToString(); }
        }

        
    }
}
