using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFomularioRetiradaManualEstoqueForm : IWTForm
    {

        FomularioRetiradaManualEstoqueClass FormularioRetirada
        {
            get { return (FomularioRetiradaManualEstoqueClass) this.Entity; }
        }

        public CadFomularioRetiradaManualEstoqueForm(FomularioRetiradaManualEstoqueClass entidade, CadFomularioRetiradaManualEstoqueListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.Produto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo,modoSelecao:true,somenteAtivos:true);
            this.Material.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo, modoSelecao: true);
            this.Epi.FormSelecao = new CadEpiListForm(TipoModulo.Tipo);

        }

        public CadFomularioRetiradaManualEstoqueForm(FomularioRetiradaManualEstoqueClass entidade)
            : base(entidade, typeof(FomularioRetiradaManualEstoqueClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.Produto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, modoSelecao: true, somenteAtivos: true);
            this.Material.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo, modoSelecao: true);
            this.Epi.FormSelecao = new CadEpiListForm(TipoModulo.Tipo);
        }


        private void InitiSelecaoEstoques()
        {
            try
            {
                if (
                    (!this.Produto.Enabled || this.Produto.EntidadeSelecionada == null) &&
                    (!this.Material.Enabled || this.Material.EntidadeSelecionada == null) &&
                    (!this.Epi.Enabled || this.Epi.EntidadeSelecionada == null)
                    )
                {

                    this.ensGavetaOrigem.forceDisable();
                    this.ensGavetaOrigem.EntidadeSelecionada = null;

                    this.ensGavetaDestino.forceDisable();
                    this.ensGavetaDestino.EntidadeSelecionada = null;

                    this.rdbConsumo.Enabled = false;
                    this.rdbMateriaPrima.Enabled = false;
                    this.rdbMateriaPrima.Checked = true;

                    return;
                }


                if (this.Epi.Enabled)
                {
                    this.rdbConsumo.Checked = true;
                    this.rdbConsumo.Enabled = false;
                    this.rdbMateriaPrima.Enabled = false;
                }
                else
                {
                    if (this.Produto.Enabled)
                    {
                        ProdutoClass produto = (ProdutoClass) this.Produto.EntidadeSelecionada;
                        if (produto != null && produto.ClassificacaoProduto != null)
                        {
                            switch (produto.ClassificacaoProduto.TipoConsumoEstoque)
                            {
                                case EASITipoConsumoEstoque.MateriaPrima:
                                    this.rdbMateriaPrima.Checked = true;
                                    this.rdbConsumo.Enabled = false;
                                    this.rdbMateriaPrima.Enabled = false;
                                    break;
                                case EASITipoConsumoEstoque.Consumo:
                                    this.rdbConsumo.Checked = true;
                                    this.rdbConsumo.Enabled = false;
                                    this.rdbMateriaPrima.Enabled = false;
                                    break;
                                case EASITipoConsumoEstoque.Escolher:
                                    this.rdbConsumo.Enabled = true;
                                    this.rdbMateriaPrima.Enabled = true;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                        }
                        else
                        {
                            this.rdbMateriaPrima.Checked = true;
                            this.rdbConsumo.Enabled = false;
                            this.rdbMateriaPrima.Enabled = false;

                        }
                    }
                    else
                    {
                        if (Material.Enabled)
                        {
                            MaterialClass material = (MaterialClass) this.Material.EntidadeSelecionada;
                            if (material != null && material.FamiliaMaterial != null && material.FamiliaMaterial.AgrupadorMaterial != null)
                            {
                                switch (material.FamiliaMaterial.AgrupadorMaterial.TipoConsumoEstoque)
                                {
                                    case EASITipoConsumoEstoque.MateriaPrima:
                                        this.rdbMateriaPrima.Checked = true;
                                        this.rdbConsumo.Enabled = false;
                                        this.rdbMateriaPrima.Enabled = false;
                                        break;
                                    case EASITipoConsumoEstoque.Consumo:
                                        this.rdbConsumo.Checked = true;
                                        this.rdbConsumo.Enabled = false;
                                        this.rdbMateriaPrima.Enabled = false;
                                        break;
                                    case EASITipoConsumoEstoque.Escolher:
                                        this.rdbConsumo.Enabled = true;
                                        this.rdbMateriaPrima.Enabled = true;
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }

                            }
                            else
                            {
                                this.rdbMateriaPrima.Checked = true;
                                this.rdbConsumo.Enabled = false;
                                this.rdbMateriaPrima.Enabled = false;

                            }
                        }
                    }
                }


                CadEstoqueGavetaItemListForm formSelecaoOrigem;
                AbstractEntity selecaoOrigem = null;
                CadEstoqueGavetaItemListForm formSelecaoDestino;
                AbstractEntity selecaoDestino = null;
                ;

                if (this.Produto.Enabled && this.Produto.EntidadeSelecionada != null)
                {
                    formSelecaoOrigem = new CadEstoqueGavetaItemListForm((ProdutoClass) this.Produto.EntidadeSelecionada);
                    if (this.FormularioRetirada.EstoqueGaveta != null)
                    {
                        selecaoOrigem = this.FormularioRetirada.EstoqueGaveta.CollectionEstoqueGavetaItemClassEstoqueGaveta.FirstOrDefault(a => a.Produto == (ProdutoClass) this.Produto.EntidadeSelecionada);
                    }
                    else
                    {
                        selecaoOrigem = EstoqueMovimentacao.BuscaTodasGavetasItemProduto((ProdutoClass) this.Produto.EntidadeSelecionada).FirstOrDefault();

                    }


                    formSelecaoDestino = new CadEstoqueGavetaItemListForm((ProdutoClass) this.Produto.EntidadeSelecionada);
                    if (this.FormularioRetirada.EstoqueGavetaDestino != null)
                    {
                        selecaoDestino = this.FormularioRetirada.EstoqueGavetaDestino.CollectionEstoqueGavetaItemClassEstoqueGaveta.FirstOrDefault(a => a.Produto == (ProdutoClass) this.Produto.EntidadeSelecionada);
                    }


                }
                else
                {
                    if (this.Epi.Enabled && this.Epi.EntidadeSelecionada != null)
                    {
                        formSelecaoOrigem = new CadEstoqueGavetaItemListForm(epi: (EpiClass) this.Epi.EntidadeSelecionada);
                        if (this.FormularioRetirada.EstoqueGaveta != null)
                        {
                            selecaoOrigem = this.FormularioRetirada.EstoqueGaveta.CollectionEstoqueGavetaItemClassEstoqueGaveta.FirstOrDefault(a => a.Epi == (EpiClass) this.Epi.EntidadeSelecionada);
                        }
                        else
                        {
                            selecaoOrigem = EstoqueMovimentacao.BuscaTodasGavetasItemEpi((EpiClass)this.Epi.EntidadeSelecionada).FirstOrDefault();

                        }

                        formSelecaoDestino = new CadEstoqueGavetaItemListForm(epi: (EpiClass) this.Epi.EntidadeSelecionada);
                        if (this.FormularioRetirada.EstoqueGavetaDestino != null)
                        {
                            selecaoDestino = this.FormularioRetirada.EstoqueGavetaDestino.CollectionEstoqueGavetaItemClassEstoqueGaveta.FirstOrDefault(a => a.Epi == (EpiClass) this.Epi.EntidadeSelecionada);
                        }
                    }
                    else
                    {
                        if (this.Material.Enabled && this.Material.EntidadeSelecionada != null)
                        {
                            formSelecaoOrigem = new CadEstoqueGavetaItemListForm(material: (MaterialClass) this.Material.EntidadeSelecionada);
                            if (this.FormularioRetirada.EstoqueGaveta != null)
                            {
                                selecaoOrigem = this.FormularioRetirada.EstoqueGaveta.CollectionEstoqueGavetaItemClassEstoqueGaveta.FirstOrDefault(a => a.Material == (MaterialClass) this.Material.EntidadeSelecionada);
                            }
                            else
                            {
                                selecaoOrigem = EstoqueMovimentacao.BuscaTodasGavetasItemMaterial((MaterialClass)this.Material.EntidadeSelecionada).FirstOrDefault();

                            }

                            formSelecaoDestino = new CadEstoqueGavetaItemListForm(material: (MaterialClass) this.Material.EntidadeSelecionada);
                            if (this.FormularioRetirada.EstoqueGavetaDestino != null)
                            {
                                selecaoDestino = this.FormularioRetirada.EstoqueGavetaDestino.CollectionEstoqueGavetaItemClassEstoqueGaveta.FirstOrDefault(a => a.Material == (MaterialClass) this.Material.EntidadeSelecionada);
                            }

                        }
                        else
                        {
                            throw new ExcecaoTratada("Tipo não identificado");
                        }
                    }
                }


                this.ensGavetaDestino.FormSelecao = formSelecaoDestino;
                this.ensGavetaOrigem.FormSelecao = formSelecaoOrigem;

                this.ensGavetaOrigem.removeForceDisable();
                this.ensGavetaDestino.removeForceDisable();

                this.ensGavetaDestino.Enabled = false;

                this.ensGavetaOrigem.EntidadeSelecionada = selecaoOrigem;
                this.ensGavetaDestino.EntidadeSelecionada = selecaoDestino;


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as gavetas para seleção.\r\n" + e.Message, e);
            }
        }


        private void OrigemSelecionada()
        {

            try
            {
                EstoqueGavetaItemClass gavetaItemSelecionado = (EstoqueGavetaItemClass) this.ensGavetaOrigem.EntidadeSelecionada;
                if (gavetaItemSelecionado == null)
                {
                    this.FormularioRetirada.EstoqueGaveta = null;
                }
                else
                {
                    this.FormularioRetirada.EstoqueGaveta = gavetaItemSelecionado.EstoqueGaveta;
                }
                
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao selecionar a origem\r\n" + e.Message);
            }

            
        }

        private void DestinoSelecionado()
        {

            try
            {
                EstoqueGavetaItemClass gavetaItemSelecionado = (EstoqueGavetaItemClass)this.ensGavetaDestino.EntidadeSelecionada;
                if (gavetaItemSelecionado == null)
                {
                    this.FormularioRetirada.EstoqueGavetaDestino = null;
                }
                else
                {
                    this.FormularioRetirada.EstoqueGavetaDestino = gavetaItemSelecionado.EstoqueGaveta;
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao selecionar o destino\r\n" + e.Message);
            }
        }


        #region  Eventos

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            base.Salvar(command);
            try
            {
                CadFomularioRetiradaManualEstoqueReportForm form = new CadFomularioRetiradaManualEstoqueReportForm(new List<FomularioRetiradaManualEstoqueClass>() { (FomularioRetiradaManualEstoqueClass)this.Entity }, false, true);
                form.ShowDialog();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
   

        private void Produto_EntityChange(object sender, EventArgs e)
        {
            InitiSelecaoEstoques();
        }

        private void Material_EntityChange(object sender, EventArgs e)
        {
          
            InitiSelecaoEstoques();
        }

        private void Epi_EntityChange(object sender, EventArgs e)
        {
         
            InitiSelecaoEstoques();
        }

    

     

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbProduto.Checked)
            {
                if (!FormularioRetirada.Retirado)
                {
                    this.Produto.removeForceDisable();
                }
                this.InitiSelecaoEstoques();
            }
            else
            {
                this.Produto.forceDisable();
                this.Produto.EntidadeSelecionada = null;
            }
        }

        private void rdbEPI_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbEPI.Checked)
            {
                if (!FormularioRetirada.Retirado)
                {
                    this.Epi.removeForceDisable();
                }
                this.InitiSelecaoEstoques();
            }
            else
            {
                this.Epi.forceDisable();
                this.Epi.EntidadeSelecionada = null;
            }
        }

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbMaterial.Checked)
            {
                if (!FormularioRetirada.Retirado)
                {
                    this.Material.removeForceDisable();
                }
                this.InitiSelecaoEstoques();
            }
            else
            {
                this.Material.forceDisable();
                this.Material.EntidadeSelecionada = null;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            this.ensGavetaOrigem.forceDisable();
            this.ensGavetaDestino.forceDisable();

            base.OnShown(e);

            

            if (this.Entity.ID != -1)
            {
                this.rdbProduto.Checked = this.FormularioRetirada.Produto != null;
                this.rdbMaterial.Checked = this.FormularioRetirada.Material != null;
                this.rdbEPI.Checked = this.FormularioRetirada.Epi != null;
            }
            rdbProduto_CheckedChanged(null,null);
            rdbEPI_CheckedChanged(null, null);
            rdbMaterial_CheckedChanged(null, null);
        }


        private void rdbMateriaPrima_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                InitiSelecaoEstoques();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ensGavetaOrigem_EntityChange(object sender, EventArgs e)
        {
            try
            {

                this.OrigemSelecionada();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ensGavetaDestino_EntityChange(object sender, EventArgs e)
        {
            try
            {
                this.DestinoSelecionado();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ensGavetaDestino_EnabledChanged(object sender, EventArgs e)
        {
            if (!ensGavetaDestino.Enabled)
            {
                ensGavetaDestino.EntidadeSelecionada = null;
            }
        }


        #endregion

    }
}
