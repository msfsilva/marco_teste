using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.NFe;
using IWTNF.Entidades.Base;
using PresencaComprador = IWTNF.Entidades.Base.PresencaComprador;

namespace BibliotecaNotasFiscais
{
    internal class organizaNfClass
    {
        internal string idClienteAccess { get; private set; }
        internal string armazenagemCliente { get; private set; }
        internal string naturezaOperacao { get; private set; }
        internal Dictionary<OrganizaNfSubItemKey,OrganizaNfItemClass> itens { get; private set; }
        internal bool matAdicional { get; private set; }
        internal int idCliente { get; private set; }
        internal int cliEspecial { get; private set; }
        internal bool utilizaControleEspecialCliente { get; private set; }
        internal string cliNome { get; private set; }
        internal bool pedidoNovo { get; private set; }
        internal int idTransporte { get; private set; }
        internal bool devolverMateriaisCliente { get; private set; }
        internal List<int> IdsPedidoItemLinha0 { get; private set; }
        internal ModalidadeFrete responsavelFrete { get; private set; }
        internal FormaFretePedido FormaFrete { get; private set; }

        internal int idCentroCustoLucro { get; private set; }
        internal int idContaBancaria { get; private set; }
        internal int idFormaPagamento { get; private set; }

        internal long IdTipoPagamento { get; private set; }

        public bool EnvioTerceiros { get; }

        public long IdClienteEnvioTerceiros { get; }

        public long IdOperacaoEnvioTerceiros { get; }

        public long IdOperacaoCompletaEnvioTerceiros { get; }

        internal List<organizaNfMaterialClienteClass> Materiais { get; private set; }


        public EasiEmissorNFe EmissorNFe { get; private set; }

        public bool SomaFreteBcIcms { get; private set; }
        public bool SomaFreteBcIpi { get; private set; }
        public string Pedidos
        {
            get {
                string toRet = "";
                if (this.itens != null && this.itens.Count > 0)
                {
                    toRet = itens.Aggregate(toRet, (current, item) => current + (", " + item.Value.Pedido));
                    if (toRet.Length > 0)
                    {
                        toRet = toRet.Substring(1);
                    }
                }
                return toRet;
            }
           
        }

        public bool ConsumidorFinal { get; private set; }
        public PresencaComprador PresencaComprador { get; private set; }

        public bool GerarContasReceber { get; private set; }

        public CargaTributosDto TributosItemPrincipalNf { get; set; }


        public bool DevolverMaterialClienteNfSeparada { get; private set; }
        public string DevolverMaterialClienteNfSeparadaNaturezaOp { get; private set; }

        public bool DescontarImcsBcPis { get; private set; }
        public bool DescontarImcsBcCofins { get; private set; }


        //Utilizar o idPedidoItemLinha0 somente para notas fiscais com devolução do material do cliente, para separa cada pedido em uma nota
        internal organizaNfClass(
            string idClienteAccess, string armazenagemCliente, string naturezaOperacao, bool matAdicional, int idCliente,
            int cliEspecial, bool utilizaControleEspecialCliente,  string cliNome, bool pedidoNovo, int idTransporte, bool devolverMateriaisCliente, 
            ModalidadeFrete responsavelFrete, int idCentroCustoLucro, int idContaBancaria, int idFormaPagamento, long idTipoPagamento, FormaFretePedido formaFrete, bool consumidorFinal, PresencaComprador presencaComprador,
            bool gerarContasReceber, EasiEmissorNFe emissorNFe, bool somaFreteBcIcms, bool somaFreteBcIpi, CargaTributosDto tributosItemPrincipalNf,
            bool envioTerceiros, long idClienteEnvioTerceiros, long idOperacaoEnvioTerceiros, long idOperacaoCompletaEnvioTerceiros, bool devolverMaterialClienteNfSeparada,  string devolverMaterialClienteNfSeparadaNaturezaOp,
            bool descontarImcsBcPis, bool descontarImcsBcCofins
            )
        {
            this.idClienteAccess = idClienteAccess;
            this.armazenagemCliente = armazenagemCliente;
            this.naturezaOperacao = naturezaOperacao;
            this.itens = new Dictionary<OrganizaNfSubItemKey, OrganizaNfItemClass>();
            this.Materiais = new List<organizaNfMaterialClienteClass>();
            this.matAdicional = matAdicional;
            this.idCliente = idCliente;
            this.cliEspecial = cliEspecial;
            this.cliNome = cliNome;
            this.pedidoNovo = pedidoNovo;
            this.idTransporte = idTransporte;
            this.devolverMateriaisCliente = devolverMateriaisCliente;
            this.utilizaControleEspecialCliente = utilizaControleEspecialCliente;
            this.responsavelFrete = responsavelFrete;

            this.idCentroCustoLucro = idCentroCustoLucro;
            this.idContaBancaria = idContaBancaria;
            this.idFormaPagamento = idFormaPagamento;

            this.FormaFrete = formaFrete;
            this.ConsumidorFinal = consumidorFinal;
            this.PresencaComprador = presencaComprador;

            this.GerarContasReceber = gerarContasReceber;
            EmissorNFe = emissorNFe;
            SomaFreteBcIcms = somaFreteBcIcms;
            SomaFreteBcIpi = somaFreteBcIpi;
            TributosItemPrincipalNf = tributosItemPrincipalNf;

            EnvioTerceiros = envioTerceiros;
            IdClienteEnvioTerceiros = idClienteEnvioTerceiros;
            IdOperacaoEnvioTerceiros = idOperacaoEnvioTerceiros;
            IdOperacaoCompletaEnvioTerceiros = idOperacaoCompletaEnvioTerceiros;
            DevolverMaterialClienteNfSeparada = devolverMaterialClienteNfSeparada;
            DevolverMaterialClienteNfSeparadaNaturezaOp = devolverMaterialClienteNfSeparadaNaturezaOp;
            DescontarImcsBcPis = descontarImcsBcPis;
            DescontarImcsBcCofins = descontarImcsBcCofins;

            IdTipoPagamento = idTipoPagamento;

            IdsPedidoItemLinha0 = new List<int>();
        }

        


        internal OrganizaNfItemClass getItemLinha0(int idPedidoItemLinha0)
        {
            try
            {
                if (idPedidoItemLinha0 == -1)
                {
                    throw new Exception("Não é possível identificar o item sublinha 0");
                }
                List<OrganizaNfItemClass> tmp = new List<OrganizaNfItemClass>(this.itens.Values.Where(a => Convert.ToInt32(a.IdPedidoItem) == idPedidoItemLinha0));

                if (tmp.Count == 0)
                {
                    throw new Exception("Não é possível identificar o item sublinha 0.");
                }

                return tmp[0];

            }
            catch (Exception e)
            {

                throw new Exception("Erro ao identificar a sublinha 0 do pedido\r\n" + e.Message, e);
            }


        }
    }
}