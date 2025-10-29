using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEpiForm : IWTForm
    {

        private bool _salvarComo = false;

        public CadEpiForm(EpiClass epi, CadEpiListForm listForm)
            : base(epi, listForm, listForm.SingleConnection)
        {
            InitializeComponent();

            this.ensCA.FormSelecao = new CadEpiCaListForm();
            this.ensUnidadeMedidaCompra.FormSelecao = new CadUnidadeMedidaListForm(TipoModulo.Tipo);
            this.ensUnidadeUso.FormSelecao = new CadUnidadeMedidaListForm(TipoModulo.Tipo);
            this.initializeGridFornecedores();
            this.exibeParametros();
        }
        
        public CadEpiForm(EpiClass epi)
            : base(epi, typeof(EpiClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            this.ensCA.FormSelecao = new CadEpiCaListForm();
            this.ensUnidadeMedidaCompra.FormSelecao = new CadUnidadeMedidaListForm(TipoModulo.Tipo);
            this.ensUnidadeUso.FormSelecao = new CadUnidadeMedidaListForm(TipoModulo.Tipo);

            this.initializeGridFornecedores();
            this.exibeParametros();

        }

        private void exibeParametros()
        {
            this.lblLeadtimeCompras.Text = "Leadtime Compras: " + ((EpiClass)this.Entity).LeadTimeCompra + " dias";
        }


        private void initializeGridFornecedores()
        {
            this.dgvFornecedores.DataSource = null;
            if (((EpiClass)this.Entity).CollectionEpiFornecedorClassEpi != null && ((EpiClass)this.Entity).CollectionEpiFornecedorClassEpi.Count > 0)
            {
                this.dgvFornecedores.DataSource = new AdvancedList<EpiFornecedorClass>(((EpiClass)this.Entity).CollectionEpiFornecedorClassEpi);
                this.dgvFornecedores.Refresh();

                ListSortDirection ls = ListSortDirection.Ascending;
                if (this.dgvFornecedores.SortOrder == SortOrder.Descending)
                {
                    ls = ListSortDirection.Descending;
                }

                this.dgvFornecedores.Sort(this.dgvFornecedores.SortedColumn ?? this.dgvFornecedores.Columns[0], ls);
            }
        }

        private void atualizaTextoConversaoUnidades()
        {
            try
            {
                if (((EpiClass)this.Entity).UnidadeMedidaCompra != null && ((EpiClass)this.Entity).UnidadeMedidaUso != null)
                {
                    this.lblUnidades.Text = " 1 " +
                                            ((EpiClass)this.Entity).UnidadeMedidaCompra.ToString() +
                                            " => " + this.nudQtdUtilUnidCompPrincipal.Value.ToString("F4") + " " +
                                            ((EpiClass)this.Entity).UnidadeMedidaUso.ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar conversão de unidades de medida.\r\n" + e.Message, e);
            }
        }

        private void atualizaTextoUnidadeFornecedor()
        {
            try
            {
                if (ensUnidadeMedidaCompra.Enabled)
                {
                    if (((EpiClass)this.Entity).UnidadeMedidaCompra != null)
                    {
                        this.lblUnidCompraEpi.Text = ((EpiClass)this.Entity).UnidadeMedidaCompra.ToString();
                    }
                }

                else
                {
                    if (((EpiClass)this.Entity).UnidadeMedidaUso != null)
                    {
                        this.lblUnidCompraEpi.Text = ((EpiClass)this.Entity).UnidadeMedidaUso.ToString();
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar conversão de unidades de medida.\r\n" + e.Message, e);
            }
        }

        private void atualizaSugestoes()
        {
            EpiClass epi = (EpiClass) this.Entity;

                if(((EpiClass)this.Entity).sugestaoKB != null)
                {
                    this.lblVerdeSugerido.Text = Convert.ToInt32(((EpiClass)this.Entity).sugestaoKB.Verde).ToString("D") + " " + ((EpiClass)this.Entity).sugestaoKB.Unidade;
                    this.lblAmareloSugerido.Text = Convert.ToInt32(((EpiClass)this.Entity).sugestaoKB.Amarelo).ToString("D") + " " + ((EpiClass)this.Entity).sugestaoKB.Unidade;
                    this.lblVermelhoSugerido.Text = Convert.ToInt32(((EpiClass)this.Entity).sugestaoKB.Vermelho).ToString("D") + " " + ((EpiClass)this.Entity).sugestaoKB.Unidade;
                    
                    this.lblRevisarVerde.Text = ((EpiClass)this.Entity).sugestaoKB.obsRevisarKBVerde;
                    this.lblRevisarAmarelo.Text = ((EpiClass)this.Entity).sugestaoKB.obsRevisarKBAmarelo;
                    this.lblRevisarVermelho.Text = ((EpiClass)this.Entity).sugestaoKB.obsRevisarKBVermelho;


                }

                
                    this.lblSugestaoLeadTime.Text = "Leadtime Aquisição Calculado: " + epi.getSugestaoLeadtime() + " dias";
               
        }
        
        private void AdicionarFornecedor()
        {
            try
            {
                if (this.ensFornecedor.EntidadeSelecionada == null)
                {
                    throw new Exception("Selecione um fornecedor para adicionar ou atualizar.");
                }

                if (cbxUnidadeCompraFornecedor.Checked)
                {
                    if (cmbUnidCompraSobre.SelectedItem == null)
                    {
                        throw new Exception("Selecione uma unidade de compra para o fornecedor ou desabilite a opção de sobrescrever.");
                    }
                }
                
                ((EpiClass) this.Entity).AdicionarFornecedor(
                    (FornecedorClass) ensFornecedor.EntidadeSelecionada,
                    true,
                    (double) this.nudUltimoPreco.Value,
                    (double) this.nudIpiNaoIncluso.Value,
                    (double) this.nudIcmsIncluso.Value,
                    this.cbxUnidadeCompraFornecedor.Checked ? (UnidadeMedidaClass) cmbUnidCompraSobre.SelectedItem : null,
                    chkFornecedorPreferencial.Checked,
                    this.cbxUnidadeCompraFornecedor.Checked ? (double?) nudQtdUnidUtilComp.Value : null,
                    this.cbxUnidadeCompraFornecedor.Checked ? (double?) nudLoteMinSob.Value : null,
                    this.cbxUnidadeCompraFornecedor.Checked ? (double?)nudLotePadraoSob.Value : null);

                    this.initializeGridFornecedores();
            
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o fornecedor.\r\n" + e.Message, e);
            }
        }

        private void RemoverFornecedor()
        {
            try
            {
                foreach (IWTDataGridViewRow row in this.dgvFornecedores.SelectedRows)
                {
                    ((EpiClass)this.Entity).RemoverFornecedor((EpiFornecedorClass)row.DataBoundItem);
                }
                this.initializeGridFornecedores();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao remover o fornecedor.\r\n" + e.Message, e);
            }
        }

        private void selecionarFornecedor()
        {
            if (this.dgvFornecedores.SelectedRows.Count > 0)
            {

                EpiFornecedorClass epiFornecedor = (EpiFornecedorClass)((IWTDataGridViewRow)dgvFornecedores.SelectedRows[0]).DataBoundItem;



                this.ensFornecedor.EntidadeSelecionada = epiFornecedor.Fornecedor;
                this.nudUltimoPreco.Value = (decimal)epiFornecedor.UltimoPreco;
                this.nudIpiNaoIncluso.Value = (decimal)epiFornecedor.Ipi;
                this.nudIcmsIncluso.Value = (decimal)epiFornecedor.Icms;
                if (epiFornecedor.UnidadeMedidaCompra != null)
                {
                    cmbUnidCompraSobre.SelectedItem = epiFornecedor.UnidadeMedidaCompra;
                    this.cbxUnidadeCompraFornecedor.Checked = true;
                }
                else
                {
                    this.cbxUnidadeCompraFornecedor.Checked = false;
                }

                if (epiFornecedor.UnidadesPorUnCompra != null)
                {
                    nudQtdUnidUtilComp.Value = (decimal)epiFornecedor.UnidadesPorUnCompra;
                    this.cbxUnidadeCompraFornecedor.Checked = true;
                }
                else
                {
                    this.cbxUnidadeCompraFornecedor.Checked = false;
                }

                if (epiFornecedor.LotePadrao != null)
                {
                    nudLotePadraoSob.Value = (decimal)epiFornecedor.LotePadrao;
                    
                    this.cbxUnidadeCompraFornecedor.Checked = true;
                }
                else
                {
                    this.cbxUnidadeCompraFornecedor.Checked = false;
                }

                if (epiFornecedor.LoteMinimo != null)
                {
                    nudLoteMinSob.Value = (decimal)epiFornecedor.LoteMinimo;
                }

                chkFornecedorPreferencial.Checked = epiFornecedor.Preferencial;
            }
        }
        
        private void SalvarComo()
        {
            if (MessageBox.Show(this, "Essa operação irá realizar uma cópia do EPI atual como um novo EPI, certifique-se de que a identificação foi alterada. Você deseja continuar?", "Salvar como...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.VerificaUtilizacao = false;

                this.Entity = ((EpiClass)this.Entity).SalvarComo();
                if (this.ListForm != null)
                {
                    this.ListForm.ForceInitializeDataGrid();
                }

                this.Close();
            }
            else
            {
                return;
            }
        }

        private void HabilitarCopiar()
        {
            this.Text = "COPIANDO Item: " + this.txtIdentificacao.Text;
            this.btnSalvar.Text = "Salvar Cópia";

            foreach (Control c in this.Controls)
            {
                if (c is IWTBaseControl)
                {
                    ((IWTBaseControl)c).removeForceDisable();
                }
                else
                {
                    c.Enabled = true;
                }
            }
            this.btnSalvar.Visible = true;
            this.btnSalvar.Enabled = true;
            this.btnCancelar.Enabled = true;

            this.btnSalvarComo.Visible = false;

            this.txtIdentificacao.removeForceDisable();
            this.ensCA.removeForceDisable();
            this.ensUnidadeMedidaCompra.removeForceDisable();
            this.ensFornecedor.removeForceDisable();
            
            this._salvarComo = true;
            this.DesabilitarAvisoAlteradoAoFechar = true;
        }


        private void loadComboFornecedorUnidadeMedidaCompra()
        {
            try
            {
                BibliotecaEntidades.Entidades.UnidadeMedidaClass search = new BibliotecaEntidades.Entidades.UnidadeMedidaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<BibliotecaEntidades.Entidades.UnidadeMedidaClass> resultados =
                    search.Search(new List<SearchParameterClass>() { new SearchParameterClass("Abreviada", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (BibliotecaEntidades.Entidades.UnidadeMedidaClass)a);


                this.cmbUnidCompraSobre.DataSource = resultados;
                this.cmbUnidCompraSobre.DisplayMember = "Abreviada";
                this.cmbUnidCompraSobre.ValueMember = "ID";
                this.cmbUnidCompraSobre.autoSize = true;
                this.cmbUnidCompraSobre.Table = resultados;
                this.cmbUnidCompraSobre.ColumnsToDisplay = new[] { "Abreviada", "NomeUnidade", "Obs" };
                this.cmbUnidCompraSobre.HeadersToDisplay = new[] { "Abreviada", "Nome", "Obs" };


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção.\r\n" + e.Message);
            }
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this._salvarComo)
            {
                this.SalvarComo();
            }
            else
            {
                base.btnSalvar_Click(sender, e);
            }
        }

        
       

        private void cbxControleValidade_CheckedChanged(object sender, EventArgs e)
        {
            this.nudControleValidadeMeses.Enabled = this.cbxControleValidade.Checked;
        }

        private void cbxUnidadeCompraFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            this.grbUnidadeCompraFornecedor.Enabled = this.cbxUnidadeCompraFornecedor.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.AdicionarFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                this.RemoverFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  

        private void iwtNumericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            this.atualizaTextoConversaoUnidades();
        }


        protected override void OnShown(EventArgs e)
        {
            loadComboFornecedorUnidadeMedidaCompra();

            ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);
            base.OnShown(e);
        }

        private void dgvFornecedores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.selecionarFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarComo_Click(object sender, EventArgs e)
        {
            try
            {
                this.HabilitarCopiar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensUnidadeMedidaCompra_EntityChange(object sender, EventArgs e)
        {
            try
            {
                this.atualizaTextoConversaoUnidades();
                this.atualizaSugestoes();
                this.atualizaTextoUnidadeFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensUnidadeUso_EntityChange(object sender, EventArgs e)
        {
            try
            {
                this.atualizaTextoConversaoUnidades();
                this.atualizaSugestoes();
                this.atualizaTextoUnidadeFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensUnidadeUso_Leave(object sender, EventArgs e)
        {
            try
            {
                this.atualizaTextoConversaoUnidades();
                this.atualizaSugestoes();
                this.atualizaTextoUnidadeFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensUnidadeMedidaCompra_Leave(object sender, EventArgs e)
        {
            try
            {
                this.atualizaTextoConversaoUnidades();
                this.atualizaSugestoes();
                this.atualizaTextoUnidadeFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkMargemRecebimento_CheckedChanged(object sender, EventArgs e)
        {
            this.nudMargemRecebimento.Enabled = this.chkMargemRecebimento.Checked;
        }
    }
}
