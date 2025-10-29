using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public class PedidoConfigurado
    {

        public double oie_dimensao_double { get; internal set; }
        public bool utilizaDimensaoMaiorFilho { get; internal set; }
        public long id_produto_pai { get; internal set; }
        public DimensaoVariavelEmbalagem dimensaoVariavel { get; internal set; }
        public int profundidadeInterna { get; internal set; }

        #region Propriedades Entidades

        public UnidadeMedidaClass oie_unidade_medida
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.UnidadeMedida : null; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.UnidadeMedida = value;
                }
            }
        }

        public bool oie_item_original_pedido
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.ItemOriginalPedido : Orcamento.ItemOriginalPedido; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.ItemOriginalPedido = value;
                }
                else
                {
                    Orcamento.ItemOriginalPedido = value;
                }
            }
        }

        public string oie_order_number
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.OrderNumber : Orcamento.OrderNumber; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.OrderNumber = value;
                }
                else
                {
                    Orcamento.OrderNumber = value;
                }
            }
        }

        public int? oie_order_pos
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.OrderPos : Orcamento.OrderPos; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.OrderPos = value;
                }
                else
                {
                    Orcamento.OrderPos = value;
                }
            }
        }

        public string oie_codigo_item
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.CodigoItem : Orcamento.CodigoItem; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.CodigoItem = value;
                }
                else
                {
                    Orcamento.CodigoItem = value;
                }
            }
        }

        public string oie_descricao
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Descricao : Orcamento.Descricao; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Descricao = value;
                }
                else
                {
                    Orcamento.Descricao = value;
                }
            }
        }

        public TipoControleEtiquetaProduto? oie_tipo_item
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.TipoItem : Orcamento.TipoItem; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.TipoItem = value;
                }
                else
                {
                    Orcamento.TipoItem = value;
                }
            }
        }

        public string oie_dimensao
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Dimensao : Orcamento.Dimensao; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Dimensao = value;
                }
                else
                {
                    Orcamento.Dimensao = value;
                }
            }
        }

        public int? oie_pps
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Pps : Orcamento.Pps; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Pps = value;
                }
                else
                {
                    Orcamento.Pps = value;
                }
            }
        }

        public int? oie_qtd_etiquetas
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.QtdEtiquetas : Orcamento.QtdEtiquetas; }
            set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.QtdEtiquetas = value;
                }
                else
                {
                    Orcamento.QtdEtiquetas = value;
                }
            }
        }

        public bool? oie_etiqueta_agrupada
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.EtiquetaAgrupada : Orcamento.EtiquetaAgrupada; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.EtiquetaAgrupada = value;
                }
                else
                {
                    Orcamento.EtiquetaAgrupada = value;
                }
            }
        }

        public double? oie_peso
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Peso : Orcamento.Peso; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Peso = value;
                }
                else
                {
                    Orcamento.Peso = value;
                }
            }
        }

        public int? oie_volumes
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Volumes : Orcamento.Volumes; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Volumes = value;
                }
                else
                {
                    Orcamento.Volumes = value;
                }
            }
        }

        public double oie_saldo
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Saldo : Orcamento.Saldo; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Saldo = value;
                }
                else
                {
                    Orcamento.Saldo = value;
                }
            }
        }

        public double oie_saldo_conferencia
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.SaldoConferencia : Orcamento.SaldoConferencia; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.SaldoConferencia = value;
                }
                else
                {
                    Orcamento.SaldoConferencia = value;
                }
            }
        }

        public short? oie_nivel_item
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.NivelItem : Orcamento.NivelItem; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.NivelItem = value;
                }
                else
                {
                    Orcamento.NivelItem = value;
                }
            }
        }

        public string oie_ovm
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Ovm : Orcamento.Ovm; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Ovm = value;
                }
                else
                {
                    Orcamento.Ovm = value;
                }
            }
        }

        public string oie_deps
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Deps : Orcamento.Deps; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Deps = value;
                }
                else
                {
                    Orcamento.Deps = value;
                }
            }
        }

        public string oie_peps
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Peps : Orcamento.Peps; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Peps = value;
                }
                else
                {
                    Orcamento.Peps = value;
                }
            }
        }

        public bool oie_usar_timer
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.UsarTimer : Orcamento.UsarTimer; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.UsarTimer = value;
                }
                else
                {
                    Orcamento.UsarTimer = value;
                }
            }
        }

        public bool oie_permitir_parcial
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.PermitirParcial : Orcamento.PermitirParcial; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.PermitirParcial = value;
                }
                else
                {
                    Orcamento.PermitirParcial = value;
                }
            }
        }

        public double oie_quantidade
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Quantidade : Orcamento.Quantidade; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Quantidade = value;
                }
                else
                {
                    Orcamento.Quantidade = value;
                }
            }
        }

        public double? oie_preco_total
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.PrecoTotal : Orcamento.PrecoTotal; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.PrecoTotal = value;
                }
                else
                {
                    Orcamento.PrecoTotal = value;
                }
            }
        }

        public double? oie_preco_unitario
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.PrecoUnitario : Orcamento.PrecoUnitario; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.PrecoUnitario = value;
                }
                else
                {
                    Orcamento.PrecoUnitario = value;
                }
            }
        }

        public bool oie_emissao_parcial
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.EmissaoParcial : Orcamento.EmissaoParcial; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.EmissaoParcial = value;
                }
                else
                {
                    Orcamento.EmissaoParcial = value;
                }
            }
        }

        public string oie_status_pedido
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.StatusPedido : Orcamento.StatusPedido; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.StatusPedido = value;
                }
                else
                {
                    Orcamento.StatusPedido = value;
                }
            }
        }

        public string oie_armazenagem_cliente
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.ArmazenagemCliente : Orcamento.ArmazenagemCliente; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.ArmazenagemCliente = value;
                }
                else
                {
                    Orcamento.ArmazenagemCliente = value;
                }
            }
        }

        public string oie_descricao_cliente
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.DescricaoCliente : Orcamento.DescricaoCliente; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.DescricaoCliente = value;
                }
                else
                {
                    Orcamento.DescricaoCliente = value;
                }
            }
        }

        public string oie_codigo_cliente
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.CodigoCliente : Orcamento.CodigoCliente; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.CodigoCliente = value;
                }
                else
                {
                    Orcamento.CodigoCliente = value;
                }
            }
        }

        public ClienteClass cliente
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Cliente : Orcamento.Cliente; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Cliente = value;
                }
                else
                {
                    Orcamento.Cliente = value;
                }
            }
        }

        public string oie_cnpj_pedido
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.CnpjPedido : Orcamento.CnpjPedido; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.CnpjPedido = value;
                }
                else
                {
                    Orcamento.CnpjPedido = value;
                }
            }
        }

        public int? oie_cfop
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Cfop : Orcamento.Cfop; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Cfop = value;
                }
                else
                {
                    Orcamento.Cfop = value;
                }
            }
        }

        public string oie_natureza_operacao
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.NaturezaOperacao : Orcamento.NaturezaOperacao; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.NaturezaOperacao = value;
                }
                else
                {
                    Orcamento.NaturezaOperacao = value;
                }
            }
        }

        public string oie_nbm_pedido
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.NbmPedido : Orcamento.NbmPedido; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.NbmPedido = value;
                }
                else
                {
                    Orcamento.NbmPedido = value;
                }
            }
        }

        public double oie_frete
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Frete : Orcamento.Frete; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Frete = value;
                }
                else
                {
                    Orcamento.Frete = value;
                }
            }
        }

        public bool? oie_nota_fiscal
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.NotaFiscal : Orcamento.NotaFiscal; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.NotaFiscal = value;
                }
                else
                {
                    Orcamento.NotaFiscal = value;
                }
            }
        }

        public bool oie_etiqueta_interna
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.EtiquetaInterna : Orcamento.EtiquetaInterna; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.EtiquetaInterna = value;
                }
                else
                {
                    Orcamento.EtiquetaInterna = value;
                }
            }
        }

        public string oie_cnc
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Cnc : Orcamento.Cnc; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Cnc = value;
                }
                else
                {
                    Orcamento.Cnc = value;
                }
            }
        }

        public string oie_coordenada_x
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.CoordenadaX : Orcamento.CoordenadaX; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.CoordenadaX = value;
                }
                else
                {
                    Orcamento.CoordenadaX = value;
                }
            }
        }

        public string oie_coordenada_y
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.CoordenadaY : Orcamento.CoordenadaY; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.CoordenadaY = value;
                }
                else
                {
                    Orcamento.CoordenadaY = value;
                }
            }
        }

        public string oie_informacoes_especiais
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.InformacoesEspeciais : Orcamento.InformacoesEspeciais; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.InformacoesEspeciais = value;
                }
                else
                {
                    Orcamento.InformacoesEspeciais = value;
                }
            }
        }

        public string oie_programador
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Programador : Orcamento.Programador; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Programador = value;
                }
                else
                {
                    Orcamento.Programador = value;
                }
            }
        }

        public ModeloEtiquetaExpedicaoClass ModeloEtiquetaExpedicao
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.ModeloEtiquetaExpedicao : Orcamento.ModeloEtiquetaExpedicao; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.ModeloEtiquetaExpedicao = value;
                }
                else
                {
                    Orcamento.ModeloEtiquetaExpedicao = value;
                }
            }
        }

        public int oie_qtd_etiqueta_exp_volume
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.QtdEtiquetaExpVolume : Orcamento.QtdEtiquetaExpVolume; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.QtdEtiquetaExpVolume = value;
                }
                else
                {
                    Orcamento.QtdEtiquetaExpVolume = value;
                }
            }
        }

        public string oie_descricao_pt
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.DescricaoPt : Orcamento.DescricaoPt; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.DescricaoPt = value;
                }
                else
                {
                    Orcamento.DescricaoPt = value;
                }
            }
        }

        public string oie_descricao_en
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.DescricaoEn : Orcamento.DescricaoEn; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.DescricaoEn = value;
                }
                else
                {
                    Orcamento.DescricaoEn = value;
                }
            }
        }

        public string oie_descricao_es
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.DescricaoEs : Orcamento.DescricaoEs; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.DescricaoEs = value;
                }
                else
                {
                    Orcamento.DescricaoEs = value;
                }
            }
        }

        public bool oie_imprime_packing_list
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.ImprimePackingList : Orcamento.ImprimePackingList; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.ImprimePackingList = value;
                }
                else
                {
                    Orcamento.ImprimePackingList = value;
                }
            }
        }

        public string oie_tipo_baseboard
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.TipoBaseboard : Orcamento.TipoBaseboard; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.TipoBaseboard = value;
                }
                else
                {
                    Orcamento.TipoBaseboard = value;
                }
            }
        }

        public double? oie_altura
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Altura : Orcamento.Altura; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Altura = value;
                }
                else
                {
                    Orcamento.Altura = value;
                }
            }
        }

        public double? oie_largura
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Largura : Orcamento.Largura; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Largura = value;
                }
                else
                {
                    Orcamento.Largura = value;
                }
            }
        }

        public double? oie_comprimento
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Comprimento : Orcamento.Comprimento; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Comprimento = value;
                }
                else
                {
                    Orcamento.Comprimento = value;
                }
            }
        }

        public string oie_tipo_ligacao
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.TipoLigacao : Orcamento.TipoLigacao; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.TipoLigacao = value;
                }
                else
                {
                    Orcamento.TipoLigacao = value;
                }
            }
        }

        public string oie_var_1_nome
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Var1Nome : Orcamento.Var1Nome; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Var1Nome = value;
                }
                else
                {
                    Orcamento.Var1Nome = value;
                }
            }
        }

        public string oie_var_1_valor
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Var1Valor : Orcamento.Var1Valor; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Var1Valor = value;
                }
                else
                {
                    Orcamento.Var1Valor = value;
                }
            }
        }

        public string oie_var_2_nome
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Var2Nome : Orcamento.Var2Nome; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Var2Nome = value;
                }
                else
                {
                    Orcamento.Var2Nome = value;
                }
            }
        }

        public string oie_var_2_valor
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Var2Valor : Orcamento.Var2Valor; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Var2Valor = value;
                }
                else
                {
                    Orcamento.Var2Valor = value;
                }
            }
        }

        public string oie_var_3_nome
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Var3Nome : Orcamento.Var3Nome; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Var3Nome = value;
                }
                else
                {
                    Orcamento.Var3Nome = value;
                }
            }
        }

        public string oie_var_3_valor
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Var3Valor : Orcamento.Var3Valor; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Var3Valor = value;
                }
                else
                {
                    Orcamento.Var3Valor = value;
                }
            }
        }

        public string oie_var_4_nome
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Var4Nome : Orcamento.Var4Nome; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Var4Nome = value;
                }
                else
                {
                    Orcamento.Var4Nome = value;
                }
            }
        }

        public string oie_var_4_valor
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Var4Valor : Orcamento.Var4Valor; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Var4Valor = value;
                }
                else
                {
                    Orcamento.Var4Valor = value;
                }
            }
        }

        public DateTime? oie_data_entrega
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.DataEntrega : Orcamento.DataEntrega; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.DataEntrega = value;
                }
                else
                {
                    Orcamento.DataEntrega = value;
                }
            }
        }

        public string oie_kit_fantasia
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.KitFantasia : Orcamento.KitFantasia; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.KitFantasia = value;
                }
                else
                {
                    Orcamento.KitFantasia = value;
                }
            }
        }

        public string oie_tipo_documento
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.TipoDocumento : Orcamento.TipoDocumento; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.TipoDocumento = value;
                }
                else
                {
                    Orcamento.TipoDocumento = value;
                }
            }
        }

        public string oie_numero_documento
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.NumeroDocumento : Orcamento.NumeroDocumento; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.NumeroDocumento = value;
                }
                else
                {
                    Orcamento.NumeroDocumento = value;
                }
            }
        }

        public string oie_revisao_desenho
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.RevisaoDesenho : Orcamento.RevisaoDesenho; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.RevisaoDesenho = value;
                }
                else
                {
                    Orcamento.RevisaoDesenho = value;
                }
            }
        }

        public string oie_codigo_item_pai
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.CodigoItemPai : Orcamento.CodigoItemPai; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.CodigoItemPai = value;
                }
                else
                {
                    Orcamento.CodigoItemPai = value;
                }
            }
        }

        public string oie_ver_oc
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.VerOc : Orcamento.VerOc; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.VerOc = value;
                }
                else
                {
                    Orcamento.VerOc = value;
                }
            }
        }

        public string oie_acabamento_superficial
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.AcabamentoSuperficial : Orcamento.AcabamentoSuperficial; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.AcabamentoSuperficial = value;
                }
                else
                {
                    Orcamento.AcabamentoSuperficial = value;
                }
            }
        }

        public AbstractEntity id_pedido_item
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? (AbstractEntity) Pedido.PedidoItem : Orcamento.OrcamentoItem; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.PedidoItem = (PedidoItemClass) value;
                }
                else
                {
                    Orcamento.OrcamentoItem = (OrcamentoItemClass) value;
                }
            }
        }

        public ProdutoClass produto
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.Produto : Orcamento.Produto; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.Produto = value;
                }
                else
                {
                    Orcamento.Produto = value;
                }
            }
        }

        public string oie_desc_item_pai
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.DescItemPai : Orcamento.DescItemPai; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.DescItemPai = value;
                }
                else
                {
                    Orcamento.DescItemPai = value;
                }
            }
        }

        public string oie_acab_item_pai
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.AcabItemPai : Orcamento.AcabItemPai; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.AcabItemPai = value;
                }
                else
                {
                    Orcamento.AcabItemPai = value;
                }
            }
        }

        public ProdutoKClass id_produto_k
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.ProdutoK : Orcamento.ProdutoK; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.ProdutoK = value;
                }
                else
                {
                    Orcamento.ProdutoK = value;
                }
            }
        }

        public int versaoEstruturaItem
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.VersaoEstruturaItem : Orcamento.VersaoEstruturaItem; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.VersaoEstruturaItem = value;
                }
                else
                {
                    Orcamento.VersaoEstruturaItem = value;
                }
            }
        }

        public bool rastrearMP
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.RastreamentoMaterial : Orcamento.RastreamentoMaterial; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.RastreamentoMaterial = value;
                }
                else
                {
                    Orcamento.RastreamentoMaterial = value;
                }
            }
        }

        public ResponsavelFrete responsavelFrete
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.ResponsavelFrete : Orcamento.ResponsavelFrete; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.ResponsavelFrete = value;
                }
                else
                {
                    Orcamento.ResponsavelFrete = value;
                }
            }
        }

        public bool volumeUnico
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.VolumeUnico : Orcamento.VolumeUnico; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.VolumeUnico = value;
                }
                else
                {
                    Orcamento.VolumeUnico = value;
                }
            }
        }

        public TipoAquisicao TipoAquisicaoProduto
        {
            get { return TipoEntidade == PedidoOrcamento.Pedido ? Pedido.TipoAquisicaoProduto : Orcamento.TipoAquisicaoProduto; }
            internal set
            {
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    Pedido.TipoAquisicaoProduto = value;
                }
                else
                {
                    Orcamento.TipoAquisicaoProduto = value;
                }
            }
        }


        public PedidoConfigurado IdOrderItemEtiquetaPai { get; set; }
        public PedidoItemClass LinhaPrincipalPedido { get; set; }

        #endregion;

        private OrderItemEtiquetaClass Pedido;
        private OrcamentoConfiguradoClass Orcamento;

        public PedidoOrcamento TipoEntidade { get; private set; }
        private IWTPostgreNpgsqlConnection conn;
        private AcsUsuarioClass _usuario;
        public Dictionary<string, Variavel> Variaveis { get; private set; }

        public PedidoConfigurado(PedidoOrcamento tipoEntidade, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario, Dictionary<string, Variavel> variaveis )
        {
            this.TipoEntidade = tipoEntidade;
            this.conn = conn;
            _usuario = usuario;
            Variaveis = variaveis;

            switch (tipoEntidade)
            {
                case PedidoOrcamento.Pedido:
                    this.Pedido = new OrderItemEtiquetaClass(this._usuario, this.conn);
                    break;
                case PedidoOrcamento.Orcamento:
                    this.Orcamento = new OrcamentoConfiguradoClass(this._usuario, this.conn);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoEntidade");
            }
        }

        internal void Salvar(ref IWTPostgreNpgsqlCommand command)
        {
            if (this.TipoEntidade == PedidoOrcamento.Pedido)
            {
                this.Pedido.CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta = new BindingList<PedidoItemConfiguradoMaterialClass>();
                foreach (ProdutoMaterialClass produtoMaterial in this.Pedido.Produto.CollectionProdutoMaterialClassProduto.Where(a=>a.VersaoEstrutura == this.versaoEstruturaItem))
                {
                    try
                    {
                        if (!produtoMaterial.Material.Ativo)
                        {
                            throw new ExcecaoTratada("O material " + produtoMaterial.Material + " não pode ser utilizado pois está inativo");
                        }

                        if (produtoMaterial.MaterialCondicional)
                        {
                            Configurador conf = new Configurador(Variaveis);
                            object validaCondicionalResult;
                            if (conf.Start(produtoMaterial.MaterialCondicionalRegra, ConfiguradorTipoRegra.RegraBoolean, produtoMaterial.Material.CodigoComFamilia, "REGRA DE EXISTÊNCIA DE MATERIAL", true, out validaCondicionalResult))
                            {
                                if (!(bool) validaCondicionalResult)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                throw new Exception("Erro ao verificar a existência de um material condicional");
                            }
                        }

                        double qtdUnidadePaiMaterial = produtoMaterial.Quantidade;
                        if (produtoMaterial.QtdCondicional)
                        {
                            Configurador conf = new Configurador(Variaveis);
                            object validaCondicionalResult;
                            if (conf.Start(produtoMaterial.QtdCondicionalRegra, ConfiguradorTipoRegra.RegraBoolean, produtoMaterial.Material.CodigoComFamilia, "REGRA DE QUANTIDADE CONDICIONAL DE MATERIAL", true, out validaCondicionalResult))
                            {
                                double? qtdItem = validaCondicionalResult as double?;
                                if (!qtdItem.HasValue)
                                {
                                    throw new Exception("Erro ao verificar a quantidade condicional: resultado da configuração inválido " + validaCondicionalResult);
                                }

                                qtdUnidadePaiMaterial = qtdItem.Value;
                            }
                            else
                            {
                                throw new Exception("Erro ao verificar a existência de um material condicional");
                            }
                        }


                        PedidoItemConfiguradoMaterialClass toAdd = new PedidoItemConfiguradoMaterialClass(this._usuario, this.conn)
                        {
                            Material = produtoMaterial.Material,
                            Acabamento = produtoMaterial.Material.Acabamento,
                            Codigo = produtoMaterial.Material.Codigo,
                            Descricao = produtoMaterial.Material.Descricao,
                            DescricaoAdicional = produtoMaterial.Material.DescricaoAdicional,
                            FamiliaMaterial = produtoMaterial.Material.FamiliaMaterial,
                            Medida = produtoMaterial.Material.Medida,
                            MedidaComprimento = produtoMaterial.Material.MedidaComprimento,
                            MedidaLargura = produtoMaterial.Material.MedidaLargura,
                            OrderItemEtiqueta = this.Pedido,
                            UnidadeMedida = produtoMaterial.Material.UnidadeMedida,
                            QuantidadeUnidadePai = qtdUnidadePaiMaterial,
                            QuantidadeTotal = qtdUnidadePaiMaterial * this.Pedido.Quantidade
                        };

                        if (produtoMaterial.PlanoCorte)
                        {
                            toAdd.PlanoCorte = produtoMaterial.PlanoCorte;

                            toAdd.DimensaoCorte1 = produtoMaterial.Dimensao1;
                            toAdd.PlanoCorteDimensao1Valor = produtoMaterial.PlanoCorteDimensao1 == "-1" ? this.oie_dimensao : produtoMaterial.PlanoCorteDimensao1;
                            toAdd.PlanoCorteDimensao1Identificacao = produtoMaterial.Dimensao1 != null ? produtoMaterial.Dimensao1.Identificacao : "";
                            toAdd.PlanoCorteDimensao1Descricao = produtoMaterial.Dimensao1 != null ? produtoMaterial.Dimensao1.Descricao : "";
                            toAdd.PlanoCorteDimensao1UnidadeMedida = produtoMaterial.UnidadeMedidaDimensao1 != null ? produtoMaterial.UnidadeMedidaDimensao1.Abreviada : "";
                            toAdd.UnidadeMedidaDimensao1 = produtoMaterial.UnidadeMedidaDimensao1;

                            toAdd.DimensaoCorte2 = produtoMaterial.Dimensao2;
                            toAdd.PlanoCorteDimensao2Valor = produtoMaterial.PlanoCorteDimensao2 == "-1" ? this.oie_dimensao : produtoMaterial.PlanoCorteDimensao2;
                            toAdd.PlanoCorteDimensao2Identificacao = produtoMaterial.Dimensao2 != null ? produtoMaterial.Dimensao2.Identificacao : "";
                            toAdd.PlanoCorteDimensao2Descricao = produtoMaterial.Dimensao2 != null ? produtoMaterial.Dimensao2.Descricao : "";
                            toAdd.PlanoCorteDimensao2UnidadeMedida = produtoMaterial.UnidadeMedidaDimensao2 != null ? produtoMaterial.UnidadeMedidaDimensao2.Abreviada : "";
                            toAdd.UnidadeMedidaDimensao2 = produtoMaterial.UnidadeMedidaDimensao2;

                            toAdd.DimensaoCorte3 = produtoMaterial.Dimensao3;
                            toAdd.PlanoCorteDimensao3Valor = produtoMaterial.PlanoCorteDimensao3 == "-1" ? this.oie_dimensao : produtoMaterial.PlanoCorteDimensao3;
                            toAdd.PlanoCorteDimensao3Identificacao = produtoMaterial.Dimensao3 != null ? produtoMaterial.Dimensao3.Identificacao : "";
                            toAdd.PlanoCorteDimensao3Descricao = produtoMaterial.Dimensao3 != null ? produtoMaterial.Dimensao3.Descricao : "";
                            toAdd.PlanoCorteDimensao3UnidadeMedida = produtoMaterial.UnidadeMedidaDimensao3 != null ? produtoMaterial.UnidadeMedidaDimensao3.Abreviada : "";
                            toAdd.UnidadeMedidaDimensao3 = produtoMaterial.UnidadeMedidaDimensao3;

                            toAdd.PlanoCorteInformacoesAdicionais = produtoMaterial.PlanoCorteInformacoesAdicionais;
                            toAdd.PlanoCorteQuantidade = produtoMaterial.PlanoCorteQuantidade * this.Pedido.Quantidade;
                            toAdd.PostoTrabalhoCorte = produtoMaterial.PostoTrabalhoCorte;
                            toAdd.PostoTrabalhoCorteIdentificacao = produtoMaterial.PostoTrabalhoCorte != null ? produtoMaterial.PostoTrabalhoCorte.Codigo : "";
                            toAdd.PostoTrabalhoCorteDescricao = produtoMaterial.PostoTrabalhoCorte != null ? produtoMaterial.PostoTrabalhoCorte.Nome : "";

                        }

                        this.Pedido.CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta.Add(toAdd);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao verificar os condicionais do produto " + produtoMaterial.Produto.Codigo + ": " + e.Message);
                    }
                }
                if (this.IdOrderItemEtiquetaPai != null)
                {
                    this.Pedido.OrderItemEtiquetaPai = this.IdOrderItemEtiquetaPai.Pedido;
                }
                this.Pedido.PedidoItemLinhaPrincipalPedido = this.LinhaPrincipalPedido;
                this.Pedido.Save(ref command);
            }
            else
            {
                if (this.IdOrderItemEtiquetaPai != null)
                {
                    this.Orcamento.OrcamentoConfiguradoPai = this.IdOrderItemEtiquetaPai.Orcamento;
                }
                this.Orcamento.Save(ref command);
            }
        }

        internal PedidoConfigurado cloneBasico()
        {
            PedidoConfigurado toRet = new PedidoConfigurado(TipoEntidade, this.conn, this._usuario, this.Variaveis);

            //Dados Básicos
            toRet.cliente = this.cliente;
            toRet.oie_armazenagem_cliente = this.oie_armazenagem_cliente;
            toRet.oie_cfop = this.oie_cfop;
            toRet.oie_cnpj_pedido = this.oie_cnpj_pedido;
            toRet.oie_data_entrega = this.oie_data_entrega;
            toRet.oie_deps = this.oie_deps;
            toRet.oie_frete = this.oie_frete;
            toRet.oie_natureza_operacao = this.oie_natureza_operacao;
            toRet.oie_nbm_pedido = this.oie_nbm_pedido;
            toRet.oie_nivel_item = this.oie_nivel_item;
            toRet.oie_order_number = this.oie_order_number;
            toRet.oie_order_pos = this.oie_order_pos;
            toRet.oie_ovm = this.oie_ovm;
            toRet.oie_peps = this.oie_peps;
            toRet.oie_pps = this.oie_pps;
            toRet.oie_status_pedido = this.oie_status_pedido;
            toRet.oie_emissao_parcial = this.oie_emissao_parcial;
            toRet.oie_permitir_parcial = this.oie_permitir_parcial;
            toRet.oie_nota_fiscal = this.oie_nota_fiscal;
            toRet.oie_etiqueta_agrupada = this.oie_etiqueta_agrupada;
            toRet.oie_etiqueta_interna = this.oie_etiqueta_interna;
            toRet.oie_volumes = this.oie_volumes;
            toRet.oie_informacoes_especiais = this.oie_informacoes_especiais;
            toRet.rastrearMP = this.rastrearMP;
            toRet.responsavelFrete = this.responsavelFrete;
            toRet.volumeUnico = this.volumeUnico;
            toRet.LinhaPrincipalPedido = this.LinhaPrincipalPedido;
            return toRet;
        }
    }
}