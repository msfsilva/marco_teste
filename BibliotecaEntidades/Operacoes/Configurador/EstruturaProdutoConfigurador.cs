using System;
using System.Collections.Generic;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using CrystalDecisions.CrystalReports.Engine;
using IWTPostgreNpgsql;
using Npgsql;

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public class EstruturaProdutoConfigurador
    {
        public string Oc { get; private set; }
        public int Pos { get; private set; }
        public string IdCliente { get; private set; }
        public int SubLinha { get; private set; }
        public PedidoOrcamento TipoEntidade { get; private set; }
        public IWTPostgreNpgsqlConnection Conn { get; private set; }

        public ProdutoClass Produto { private set; get; }
        public double quantidade { internal set; get; }
        public bool itemOriginalPedido { private set; get; }
        public string regraDimensao { private set; get; }
        public ProdutoClass ProdutoPai { private set; get; }
        public int profundidadeInterna { private set; get; }
        public int versaoEstrutura { private set; get; }
        public bool Condicional { get; private set; }
        public string CondicionalRegra { get; set; }
        public bool QtdCondicional { get; set; }
        public string QtdCondicionalRegra { get; set; }

        public string regraVariavel1 { private set; get; }
        public string regraVariavel2 { private set; get; }
        public string regraVariavel3 { private set; get; }
        public string regraVariavel4 { private set; get; }

        public EstruturaProdutoConfigurador ItemPaiConfigurador { get; private set; }
        public PedidoConfigurado ItemPedidoConfigurado { get; set; }

        public Dictionary<string, Variavel> VariaveisSublinha { get; private set; }

        public EstruturaProdutoConfigurador(ProdutoClass produto, double quantidade, bool itemOriginalPedido, ProdutoClass produtoPai, int profundidadeInterna, int versaoEstrutura, bool condicional, string condicionalRegra, bool qtdCondicional, string qtdCondicionalRegra, string oc, int pos, string idCliente, int subLinha, PedidoOrcamento tipoEntidade, Dictionary<string, Variavel> variaveis, IWTPostgreNpgsqlConnection conn, EstruturaProdutoConfigurador itemPaiConfigurador)
        {
            Oc = oc;
            Pos = pos;
            IdCliente = idCliente;
            SubLinha = subLinha;
            TipoEntidade = tipoEntidade;
            Conn = conn;
            ItemPaiConfigurador = itemPaiConfigurador;
            Condicional = condicional;

            this.Produto = produto;
            this.quantidade = quantidade;
            this.itemOriginalPedido = itemOriginalPedido;
            
            this.ProdutoPai = produtoPai;
            this.profundidadeInterna = profundidadeInterna;
            this.versaoEstrutura = versaoEstrutura;
            CondicionalRegra = condicionalRegra;
            QtdCondicional = qtdCondicional;
            QtdCondicionalRegra = qtdCondicionalRegra;

            this.regraDimensao = produto.RegraDimensao;
            this.regraVariavel1 = produto.RegraValidVar1;
            this.regraVariavel2 = produto.RegraValidVar2;
            this.regraVariavel3 = produto.RegraValidVar3;
            this.regraVariavel4 = produto.RegraValidVar4;

            this.VariaveisSublinha = variaveis;


        }


    }
}