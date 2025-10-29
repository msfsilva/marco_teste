using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.Relatorios
{
    public class FomularioRetiradaManualEstoqueReportClass
    {
        private readonly FomularioRetiradaManualEstoqueClass _formulario;


        public string produtoMaterialCodigoTexto
        {
            get
            {
                if (this._formulario.Produto != null)
                {
                    return this._formulario.Produto.Codigo;
                }
                else
                {
                    if (this._formulario.Epi != null)
                    {
                        return this._formulario.Epi.Identificacao;
                    }
                    else
                    {
                        return this._formulario.Material.ToString();
                    }
                }
            }
        }

        public string produtoMaterialDimensao
        {
            get
            {
                if (this._formulario.Produto != null)
                {
                    return "";
                }
                else
                {
                    if (this._formulario.Epi != null)
                    {
                        return "";
                    }
                    else
                    {
                        return
                            this._formulario.Material.MedidaCompleta;
                    }
                }
            }
        }


        public string produtoMaterialUnidadeMedida
        {
            get
            {
                if (this._formulario.Produto != null)
                {
                    return this._formulario.Produto.UnidadeMedida.ToString();
                }
                else
                {
                    if (this._formulario.Epi != null)
                    {
                        return this._formulario.Epi.UnidadeMedidaUso.ToString();
                    }
                    else
                    {
                            return this._formulario.Material.UnidadeMedida.ToString();
                    }
                }
            }
        }

        public string produtoMaterialDescricaoTexto
        {
            get
            {
                if (this._formulario.Produto != null)
                {
                    return this._formulario.Produto.Descricao;
                }
                else
                {
                    if (this._formulario.Epi != null)
                    {
                        return this._formulario.Epi.Descricao;
                    }
                    else
                    {
                        return this._formulario.Material.Descricao;
                    }
                }
            }
        }

        public string localEstoqueTexto
        {
            get
            {
                return this._formulario.EstoqueGaveta.ToString();
            }
        }

        public string localEstoqueDestinoTexto
        {
            get
            {
                if (this._formulario.EstoqueGavetaDestino != null)
                {
                    return this._formulario.EstoqueGavetaDestino.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public string usuarioAberturaTexto
        {
            get
            {
                return this._formulario.AcsUsuarioAbertura.ToString();
            }

        }

        public double Quantidade
        {
            get { return this._formulario.Quantidade; }
        }

        public string Observacoes
        {
            get { return this._formulario.Observacao; }
        }

        public DateTime DataAbertura
        {
            get { return this._formulario.DataAbertura; }
        }


        public byte[] CodigoBarras
        {
            get { return this._formulario.CodigoBarras; }
        }

        public long NumeroFormulario
        {
            get { return this._formulario.ID; }
        }

        public FomularioRetiradaManualEstoqueReportClass(FomularioRetiradaManualEstoqueClass formulario)
        {
            _formulario = formulario;
        }
    }
}
