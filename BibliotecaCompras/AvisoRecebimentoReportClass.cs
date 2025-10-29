#region Referencias

using System;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.Operacoes.OrdemProducao;

#endregion

namespace BibliotecaCompras
{
    class AvisoRecebimentoReportClass : IComparable<AvisoRecebimentoReportClass>
    {
        public string nfNumero
        {
            get
            {
                return this.NF.Numero;
            }
        }

        public string nfSerie
        {
            get
            {
                return this.NF.Serie;
            }
        }

        public DateTime nfData
        {
            get
            {
                return this.NF.dataNf;
            }
        }

        public int nfLinha
        {
            get
            {
                return this.linhaNF.Linha;
            }
        }

        public string Fornecedor
        {
            get
            {
                return this.NF.nomeFornecedorSistema;
            }
        }

        public DateTime recebimentoData
        {
            get
            {
                return this.linhaNF.Lote.dataRecebimento;
            }
        }

        public string recebimentoUsuario
        {
            get
            {
                return this.linhaNF.Lote.usuarioCadastro.Login;
            }
        }

        public string itemCodigo
        {
            get
            {
               return this.linhaNF.codigoItemSistema;
            }
        }

        public string itemDescricao
        {
            get
            {
                return this.linhaNF.descricaoItemSistema;
            }
        }

        public double quantidadeUnidadeUso
        {
            get
            {
                return Math.Round(this.linhaNF.Lote.qtdUnidadeUso, 4);
                //return this._Estoque.Quantidade;
            }
        }

        public string Lote
        {
            get
            {
                return this.linhaNF.numeroLote;
            }
        }

        public string Estoque
        {
            get
            {
                return this._Estoque.Gaveta.ToString();
            }
        }

        public string unidadeUso
        {
            get
            {
                return this.linhaNF.Lote.unidadeUso;
            }
        }

        public string unidadeCompra
        {
            get
            {
                if (this.linhaNF.solicitacaoCompra != null)
                {

                    return this.linhaNF.solicitacaoCompra.UnidadeCompra;
                }
                else
                {
                    if (this.linhaNF.Lote.solicitacoesCompraAtuais != null && this.linhaNF.Lote.solicitacoesCompraAtuais.Count > 0)
                    {
                        return this.linhaNF.Lote.solicitacoesCompraAtuais[0].Solicitacao.UnidadeCompra;
                    }
                    else
                    {
                        return this.linhaNF.Lote.unidadeCompra;
                    }
                }
            }
        }

        public double quantidadeUnidadeCompra
        {
            get
            {
                return Math.Round(this.linhaNF.Lote.qtdUnidadeCompra, 4);
                //return Math.Round(this._Estoque.Quantidade / this.linhaNF.Lote.quantidadeUnidadesUsoPorUnidadeCompra, 4);
            }
        }


        readonly NFEntradaItemClass linhaNF;
        readonly NFEntradaClass NF;
        readonly LoteEstoque _Estoque;

        public AvisoRecebimentoReportClass(
            NFEntradaItemClass linhaNF,
            NFEntradaClass NF,
            LoteEstoque _Estoque
        )
        {
            this.linhaNF = linhaNF;
            this.NF = NF;
            this._Estoque = _Estoque;
        }

        #region IComparable<AvisoRecebimentoReportClass> Members

        public int CompareTo(AvisoRecebimentoReportClass other)
        {
            return this._Estoque.CompareTo(other._Estoque);
        }

        #endregion
    }
}
