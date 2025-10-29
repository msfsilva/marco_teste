using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque;
using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.Operacoes.Estoque
{
    public class InventarioReportClass
    {

        private EstoqueGavetaItemClass _item;

        public InventarioReportClass(EstoqueGavetaItemClass item)
        {
            _item = item;
        }

        public string EstoqueString
        {
            get { return _item.EstoqueString; }
        }

        public string CorredorString
        {
            get { return _item.CorredorString; }
        }

        public string PrateleiraString
        {
            get { return _item.PrateleiraString; }
        }

        public string GavetaString
        {
            get { return _item.GavetaString; }
        }


        #region Ultima Utilização
        private DateTime? _dataUltimaUtilizacao = null;



        public DateTime DataUltimaUtilizacao
        {
            get
            {
                if (_dataUltimaUtilizacao.HasValue)
                {
                    return _dataUltimaUtilizacao.Value;
                }
                else
                {
                    return new DateTime(1900, 1, 1);
                }
            }
            set { this._dataUltimaUtilizacao = value; }
        }
 
        public string DataUltimaUtilizacaoFormatada
        {
            get
            {
                if (this._dataUltimaUtilizacao.HasValue)
                {
                    return this._dataUltimaUtilizacao.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
                return "";
            }
        }

        #endregion

        public bool SuprimirConteudo { get; set; }

        public string TipoConteudoString
        {
            get
            {
                if (SuprimirConteudo)
                {
                    return "";
                }

                switch (_item.TipoConteudo)
                {
                    case TipoConteudoEstoque.Produto:
                    case TipoConteudoEstoque.Material:
                    case TipoConteudoEstoque.Documento:
                    case TipoConteudoEstoque.Recurso:
                    case TipoConteudoEstoque.Epi:
                    case TipoConteudoEstoque.AgrupadorProdutoSemelhante:
                        return _item.TipoConteudo.ToString();

                    case TipoConteudoEstoque.SemConteudo:
                        return "";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }



        public string CodigoItem
        {
            get { return _item.CodigoItem; }
        }

        public string DescricaoItem
        {
            get { return _item.DescricaoItem; }
        }


        public string UnidadeItem
        {
            get { return _item.UnidadeItem; }
        }

        public double ValorTotal
        {
            get { return _item.ValorTotal; }
        }
        public double ValorUnitario
        {
            get { return _item.ValorUnitario; }
        }

        public string LocalizacaoCompleta
        {
            get { return _item.LocalizacaoCompleta; }
        }

        public double Quantidade
        {
            get { return _item.Quantidade; }
        }

        public bool Ativo
        {
            get { return _item.Ativo; }
        }
    }
}
