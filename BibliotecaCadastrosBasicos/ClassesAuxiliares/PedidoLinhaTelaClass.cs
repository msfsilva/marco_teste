using System;
using BibliotecaEntidades.Entidades;

namespace BibliotecaCadastrosBasicos.ClassesAuxiliares
{
    public class PedidoLinhaTelaClass
    {
        public int Posicao { get; internal set; }
        public ProdutoClass Produto { get; internal set; }
        public string CodProduto { get; internal set; }
        public string CodProdutoCliente { get; internal set; }
        public string Descricao { get; internal set; }
        public double Qtd { get; internal set; }
        public double ValorUnitario { get; internal set; }
        public double ValorTotal
        {
            get { return Math.Round(this.Qtd*this.ValorUnitario, 2,MidpointRounding.AwayFromZero); }
        }
        public NcmClass Ncm { get; internal set; }
        public bool EntregaParcial { get; internal set; }
        public bool VolumeUnico { get; internal set; }
        public bool Exportacao { get; internal set; }
        public bool RastrearMp { get; internal set; }
        public string InformacoesEspeciais { get; internal set; }
        public DateTime DataEntrega { get; internal set; }

        public PedidoItemClass Pedido  { get; internal set; }

    
    

        public PedidoLinhaTelaClass(int posicao, ProdutoClass produto, string codProduto, string codProdutoCliente, string descricao, double qtd, double valorUnitario, NcmClass ncm, bool entregaParcial, bool volumeUnico, bool exportacao, bool rastrearMp, string informacoesEspeciais, DateTime dadaEntrega)
        {
            Posicao = posicao;
            Produto = produto;
            CodProduto = codProduto;
            CodProdutoCliente = codProdutoCliente;
            Descricao = descricao;
            Qtd = qtd;
            ValorUnitario = valorUnitario;
            Ncm = ncm;
            EntregaParcial = entregaParcial;
            VolumeUnico = volumeUnico;
            Exportacao = exportacao;
            RastrearMp = rastrearMp;
            InformacoesEspeciais = informacoesEspeciais;
            DataEntrega = dadaEntrega;
        }

        public PedidoLinhaTelaClass()
        {
            
        }

      
    }
}