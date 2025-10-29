using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Operacoes.NFe;

namespace BibliotecaNotasFiscais
{
    internal class OrganizaNfItemClass
    {
        internal OrganizaNfSubItemKey DadosBasicos { get; private set; }
        public CargaTributosDto DtoTributos { get; }
        internal int IndiceLinha { get; set; }



        internal int Id
        {
            get { return DadosBasicos.Id; }
        }

        internal string Oc
        {
            get { return DadosBasicos.Oc; }
        }
        internal string Pos
        {
            get { return DadosBasicos.Pos; }
        }

        internal double ValorUnitario
        {
            get { return DadosBasicos.ValorUnitario + FreteRateado; }
        }

        public double FreteRateado { get; set; }

        internal double QtdTotalPedido
        {
            get { return DadosBasicos.QtdTotalPedido; }
        }
       
        internal int IdCliente
        {
            get { return DadosBasicos.IdCliente; }
        }

        
        internal bool PedidoNovo
        {
            get { return DadosBasicos.PedidoNovo; }
        }
        internal string IdPedidoItem
        {
            get { return DadosBasicos.IdPedidoItem; }
        }

        internal string IdProduto
        {
            get { return DadosBasicos.IdProduto; }
        }
        internal string IdProdutoK
        {
            get { return DadosBasicos.IdProdutoK; }
        }
        private bool ItemOriginalPedido
        {
            get { return DadosBasicos.ItemOriginalPedido; }
        }

        
        public string ObservacaoPedido
        {
            get { return DadosBasicos.ObservacaoPedido; }
        }



        internal string Pedido
        {
            get { return Oc + "/" + Pos; }
        }

        internal double ValorTotal
        {
            get { return ValorUnitario * Quantidade; }
        }

        internal int Volumes
        {
            get { return SubItens.Sum(a => a.Volumes); }
        }

        internal double Quantidade
        {
            get { return SubItens.Sum(a => a.Quantidade); }
        }

        internal double Desconto
        {
            get { return DadosBasicos.ValorDesconto; }
        }
        public List<OrganizaNfSubItem> SubItens { get; private set; }


        public OrganizaNfItemClass(OrganizaNfSubItemKey dadosBasicos, CargaTributosDto dtoTributos)
        {
            DadosBasicos = dadosBasicos;
            DtoTributos = dtoTributos;
            SubItens = new List<OrganizaNfSubItem>();
        }

      


    }

    internal class OrganizaNfSubItem
    {

        internal double Quantidade { get; private set; }
        internal int Volumes { get; private set; }
        internal int IdOrderItemEtiquetaConferencia { get; private set; }

        public OrganizaNfSubItem(double quantidade, int volumes, int idOrderItemEtiquetaConferencia)
        {

            Quantidade = quantidade;
            Volumes = volumes;
            IdOrderItemEtiquetaConferencia = idOrderItemEtiquetaConferencia;
        }
    }
}