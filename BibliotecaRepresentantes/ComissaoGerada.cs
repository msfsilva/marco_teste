using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaRepresentantes
{
    internal class ComissaoGerada
    {
        public VendedorClass Vendedor { get; set; }
        public RepresentanteClass Representante { get; set; }
        public ContaBancariaClass ContaBancaria { get; set; }
        public string Tipo { get; set; }
        public CentroCustoLucroClass CentroCusto { get; set; }
        public DateTime dataVencimento { get; set; }
        public List<ComissaoReportDataSource> Comissoes { get; set; }
        public double ValorTotal
        {
            get
            {
                return Comissoes.Sum(comissao => comissao.Valor);
            }
        }

        public ComissaoGerada()
        {
            this.Comissoes = new List<ComissaoReportDataSource>();
        }

        public void Salvar(ref IWTPostgreNpgsqlCommand command)
        {
            try{

                ContaPagarClass cp = new ContaPagarClass(LoginClass.UsuarioLogado.loggedUser, command.Connection)
                                         {
                                             CentroCustoLucro = this.CentroCusto,
                                             ContaBancaria = this.ContaBancaria,
                                             DataVencimento = this.dataVencimento,
                                             Valor = this.ValorTotal,
                                             Historico = "Comissão de " + Tipo,
                                             DataEmissao = Configurations.DataIndependenteClass.GetData(),
                                             DataCadastro = Configurations.DataIndependenteClass.GetData(),
                                             Representante = this.Representante,
                                             Vendedor = this.Vendedor,
                                             ContaEmRevisao = true,
                                             AgrupadorConta = new AgrupadorContaClass(LoginClass.UsuarioLogado.loggedUser, command.Connection)
                                             {
                                                 Data = Configurations.DataIndependenteClass.GetData()
                                             }
                                         };
                cp.Save(ref command);

                foreach (ComissaoReportDataSource comissao in Comissoes)
                {
                    if (comissao.EntidadeGeradora is PedidoItemClass)
                    {
                        ((PedidoItemClass)comissao.EntidadeGeradora).ComissaoGerada = true;
                    }
                    else
                    {
                        if (comissao.EntidadeGeradora is AtendimentoClass)
                        {
                            ((AtendimentoClass)comissao.EntidadeGeradora).ComissaoGerada = true;
                        }
                        else
                        {

                            if (comissao.EntidadeGeradora is ContaReceberClass)
                            {
                                ((ContaReceberClass) comissao.EntidadeGeradora).ComissaoGerada = true;
                            }
                            else
                            {
                                throw new Exception("Entidade geradora da comissão de tipo inválido");
                            }
                        }
                    }

                    comissao.EntidadeGeradora.Save(ref command);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a comissão gerada.\r\n" + e.Message, e);
            }
        }
    }
}