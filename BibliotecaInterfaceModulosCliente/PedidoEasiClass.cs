#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;

#endregion

namespace BibliotecaInterfaceModulosCliente
{
    public enum PedidoEasiUrgente { Normal, Antecipacao, Urgente, Critico }
    public enum PedidoEasiStatus { Pendente, Encerrado, Cancelado, Reaberto, Suspenso }

    public class PedidoEasi
    {
        public PedidoEasi()
        {
            this.ItemPai = new PedidoEasiItem();
            this.SubLinhas = new List<PedidoEasiItem>();
            this.VariaveisPedido = new List<PedidoEasiVariavel>();
            this.urgenteDataPrometida = null;
            this.Feedbacks = new List<string>();
        }
        
        public string Numero { get; set; }
        public int Posicao{ get; set; }
        public long idCliente { get; set; }
        public string CNPJCliente{ get; set; }
        public string armazenagemCliente{ get; set; }
        public string projetoCliente{ get; set; }
        public double Frete{ get; set; }
        public string NBM{ get; set; }
        public DateTime dataEntrega{ get; set; }
        public PedidoEasiStatus Status{ get; set; }
        public DateTime dataEntrada{ get; set; }
        public long idOperacao { get; set; }
        public bool permiteEntregaParcial{ get; set; }
        public bool volumeUnico{ get; set; }
        public bool Exportacao{ get; set; }
        public PedidoEasiUrgente Urgente{ get; set; }
        public string urgenteSolicitante{ get; set; }
        public DateTime? urgenteDataPrometida{ get; set; }
        public string informacaoEspecial { get; set; }

        public string tipoKit{ get; set; }

        public PedidoEasiItem ItemPai{ get; set; }
        public List<PedidoEasiItem> SubLinhas{ get; set; }

        public List<PedidoEasiVariavel> VariaveisPedido{ get; set; }

        public List<string> Feedbacks { get; set; } = new List<string>();


        public GadIntegracaoPedidoSituacao SituacaoGad { get; set; }
        public string SituacaoGadMensagem { get; set; }

        public string getVariavel(string codigo)
        {
            if(this.VariaveisPedido != null)
            {
                List<PedidoEasiVariavel> vars = new List<PedidoEasiVariavel>(this.VariaveisPedido.Where(a => a.Codigo == codigo));
                if(vars.Count > 0)
                {
                    return vars[0].Valor;
                }
                return "";
            }
            return null;
        }

        public void updateVariavel(string codigo, string valor)
        {
            if(this.VariaveisPedido != null)
            {
                this.VariaveisPedido.First(a => a.Codigo == codigo).Valor = valor;
            }
        }
    }

    public class PedidoEasiItem
    {
        public PedidoEasiItem()
        {
            this.VariaveisItem = new List<PedidoEasiVariavel>();
            this.DocumentosItem = new List<PedidoEasiDocumento>();
            
        }
        
        public int? idPedidoItem{ get; internal set; }
        public int subLinha{ get; set; }
        public long idProduto { get; set; }
        public string codigoProdutoCliente{ get; set; }//item pai so, filhos mk
        public string descricaoProdutoCliente { get; set; }//item pai so, filhos mk
        public double Quantidade{ get; set; } //mk
        public double precoUnitario{ get; set; }//so
        public double precoTotal
        {
            get
            {
                return this.Quantidade * this.precoUnitario;
            }
        }

        public List<PedidoEasiVariavel> VariaveisItem{ get; set; }
        public List<PedidoEasiDocumento> DocumentosItem{ get; set; }

        public PedidoEasiItem copia()
        {
            PedidoEasiItem itemCopiado = new PedidoEasiItem();
            itemCopiado.codigoProdutoCliente = this.codigoProdutoCliente;
            itemCopiado.descricaoProdutoCliente = this.descricaoProdutoCliente;
            itemCopiado.idProduto = this.idProduto;
            itemCopiado.precoUnitario = this.precoUnitario;
            itemCopiado.Quantidade = this.Quantidade;
            itemCopiado.subLinha = this.subLinha;
            //itemCopiado.VariaveisItem = this.VariaveisItem;
            
            //A lista de documentos permance a mesma
            itemCopiado.DocumentosItem = this.DocumentosItem;
            
            //Realiza a copia das variaveis do item
            if (this.VariaveisItem != null && this.VariaveisItem.Count > 0)
            {
                itemCopiado.VariaveisItem = new List<PedidoEasiVariavel>();
                foreach (PedidoEasiVariavel var in this.VariaveisItem)
                {
                    itemCopiado.VariaveisItem.Add(var);
                }
            }
          
            return itemCopiado;
        }

        public PedidoEasiVariavel getVariavel(string codigo)
        {
            if (this.VariaveisItem != null)
            {
                List<PedidoEasiVariavel> vars = new List<PedidoEasiVariavel>(this.VariaveisItem.Where(a => a.Codigo == codigo));
                if (vars.Count > 0)
                {
                    return vars[0];
                }
            }
            return null;
        }

        public void updateValorVariavel(string codigoVar, string novoValor)
        {
            PedidoEasiVariavel v = this.getVariavel(codigoVar);
            if(v == null)
            {
                throw new EasiException("Erro ao tentar definir o valor da váriavel " + codigoVar);
            }
            v.Valor = novoValor;
        }
    }

    public class PedidoEasiVariavel
    {
        public PedidoEasiVariavel(string cod, string val)
        {
            Codigo = cod;
            Valor = val;
        }
        
        public string Codigo{ get; set; }
        public string Valor{ get; set; }

        public PedidoEasiVariavel copia()
        {
            return new PedidoEasiVariavel(this.Codigo, this.Valor);
        }
    }

    public class PedidoEasiDocumento
    {
        public PedidoEasiDocumento(string t, string c, string r)
        {
            Tipo = t;
            Codigo = c;
            Revisao = r;
        }
        public string Tipo{ get; set; }
        public string Codigo{ get; set; }
        public string Revisao{ get; set; }
    }

    public class PedidoEasiRejeitado
    {
        public int idPedidoRejeitado { get; internal set; }
        public string nomeArquivo { get; set; }
        public byte[] Arquivo { get; set; }
        public string motivoRejeicao { get; set; }
        private string _obs;
        public string Obs
        {
            get { return _obs; }
            set
            {
                if (!value.Contains("Exception of type 'BibliotecaInterfaceModulosCliente.EasiException' was thrown."))
                {
                    _obs = value;
                }
                else
                {
                    _obs = "";
                }
            }
        }

        public string moduloImportador { get; set; }
        public DateTime dataEntrada { get; internal set; }
        public DateTime dataUltimoProcessamento { get; internal set; }
        public string tipoArquivo { get; set; }
    }
}
