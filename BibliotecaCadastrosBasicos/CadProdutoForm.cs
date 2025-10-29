#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.NovaEstruturaProduto;
using BibliotecaControleRevisao;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTFunctions;
using IWTPostgreNpgsql;
using Npgsql;


#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadProdutoForm : IWTForm
    {
        
        TipoForm Tipo;
        private bool loading = false;
        private bool _salvarComo = false;

        public ProdutoClass Produto
        {
            get { return (ProdutoClass) this.Entity; }
        }

        public CadProdutoForm(ProdutoClass entidade, CadProdutoListForm listForm, TipoForm tipo)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            this.Tipo = tipo;
            InitializeComponent();

            if (this.Tipo == TipoForm.PCP)
            {
                SomenteLeitura = true;
            }

            this.ensAgrupadorOp.FormSelecao = new CadAgrupadorOPListForm(TipoModulo.Tipo);
            this.ensAplicacaoCliente.FormSelecao = new CadAplicacaoClienteListForm(TipoModulo.Tipo);
            this.ensClassificacaoProduto.FormSelecao = new CadClassificacaoProdutoListForm(TipoModulo.Tipo);
            this.ensCliente.FormSelecao = new CadClienteListForm(TipoModulo.Tipo);
            this.ensEmbalagem.FormSelecao = new CadEmbalagensListForm(TipoModulo.Tipo);
            this.ensLocalFabricacao.FormSelecao = new CadLocalFabricacaoListForm(TipoModulo.Tipo);
            this.ensUnidadeMedida.FormSelecao = new CadUnidadeMedidaListForm(TipoModulo.Tipo);
            this.ensModeloEtiquetaExpedicao.FormSelecao = new CadModeloEtiquetaExpedicaoListForm();


        }

        public CadProdutoForm(ProdutoClass entidade, TipoForm tipo)
             : base(entidade, typeof(ProdutoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            this.Tipo = tipo;
            InitializeComponent();
            if (this.Tipo == TipoForm.PCP)
            {
                SomenteLeitura = true;
            }

            this.ensAgrupadorOp.FormSelecao = new CadAgrupadorOPListForm(TipoModulo.Tipo);
            this.ensAplicacaoCliente.FormSelecao = new CadAplicacaoClienteListForm(TipoModulo.Tipo);
            this.ensClassificacaoProduto.FormSelecao = new CadClassificacaoProdutoListForm(TipoModulo.Tipo);
            this.ensCliente.FormSelecao = new CadClienteListForm(TipoModulo.Tipo);
            this.ensEmbalagem.FormSelecao = new CadEmbalagensListForm(TipoModulo.Tipo);
            this.ensLocalFabricacao.FormSelecao = new CadLocalFabricacaoListForm(TipoModulo.Tipo);
            this.ensUnidadeMedida.FormSelecao = new CadUnidadeMedidaListForm(TipoModulo.Tipo);
            this.ensModeloEtiquetaExpedicao.FormSelecao = new CadModeloEtiquetaExpedicaoListForm();
        }




        private void situacaoCadastrosProduto()
        {
            try
            {
                if (this.Entity.ID != -1)
                {


                    #region Cadastro de produto Fiscal


                    if (this.Produto.CollectionProdutoFiscalClassProduto.Count > 0)
                    {
                        this.lblSituacaoFiscal.Text = "Realizado";
                    }

                    #endregion

                    #region Cadastro de Estrutura
                    if (this.Produto.CadastroEngenharia)
                    {
                        this.lblSituacaoEstrutura.Text = "Realizado";
                    }
                    #endregion

                    #region Cadastro do PCP
                    if (this.Produto.CadastroPcp)
                    {
                        this.lblSituacaoPCP.Text = "Realizado";
                    }
                    #endregion

                    #region Cadastro de Preços
                    if (this.Produto.CadastroPreco)
                    {
                        this.lblSituacaoPreco.Text = "Realizado";
                    }
                    #endregion
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar a situação do cadastro.\r\n" + e.Message);
            }

        }

        private void atualizaLabelVariavel(int numeroVar)
        {
            try
            {
                switch (numeroVar)
                {
                    case 1:
                        if (this.cmbVariavel1.Enabled && this.cmbVariavel1.SelectedItem != null)
                        {
                            this.lblVar1.Text = this.cmbVariavel1.SelectedItem.ToString();
                        }
                        else
                        {
                            this.lblVar1.Text = "";
                            this.chkValidaVar1.Checked = false;
                        }
                        break;

                    case 2:
                        if (this.cmbVariavel2.Enabled && this.cmbVariavel2.SelectedItem != null)
                        {
                            this.lblVar2.Text = this.cmbVariavel2.SelectedItem.ToString();
                        }
                        else
                        {
                            this.lblVar2.Text = "";
                            this.chkValidaVar2.Checked = false;
                        }
                        break;

                    case 3:
                        if (this.cmbVariavel3.Enabled && this.cmbVariavel3.SelectedItem != null)
                        {
                            this.lblVar3.Text = this.cmbVariavel3.SelectedItem.ToString();
                        }
                        else
                        {
                            this.lblVar3.Text = "";
                            this.chkValidaVar3.Checked = false;
                        }
                        break;

                    case 4:
                        if (this.cmbVariavel4.Enabled && this.cmbVariavel4.SelectedItem != null)
                        {
                            this.lblVar4.Text = this.cmbVariavel4.SelectedItem.ToString();
                        }
                        else
                        {
                            this.lblVar4.Text = "";
                            this.chkValidaVar4.Checked = false;
                        }
                        break;


                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar o label da variável.\r\n" + e.Message, e);
            }

        }


        private void SalvarComo()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                CadProdutoSelecaoTipoCopiaForm form = new CadProdutoSelecaoTipoCopiaForm();
                form.ShowDialog(this);


                command = this.SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                this.Produto.SalvarComo(form.Estrutura, form.Fiscal, form.Precos, ref command);

                command.Transaction.Commit();


                this.Entity = CadProdutoEstruturaFormNew.marretadaNova(this.Produto, true, SingleConnection);

                MessageBox.Show(this, "Cópia do produto realizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);



                this.Close();
            }
            catch (ExcecaoTratada e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new ExcecaoTratada("\r\n" + e.Message, e);
            }
            finally
            {
                BufferAbstractEntity.limparBuffer();
                this.ListForm.ForceInitializeDataGrid();
            }
        }

        private void habilitarCopia()
        {
            this.Text = "COPIANDO Item: " + this.txtCodigo.Text;
            this.btnSalvar.Text = "Salvar Cópia";

            foreach (Control c in this.Controls)
            {
                if (c is IWTBaseControl)
                {
                    ((IWTBaseControl) c).removeForceDisable();
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

            this.txtCodigo.removeForceDisable();
            this.txtCodigoCliente.removeForceDisable();
            this.txtRegraDimesao.removeForceDisable();
            this.chkVar1.removeForceDisable();
            this.chkVar2.removeForceDisable();
            this.chkVar3.removeForceDisable();
            this.chkVar4.removeForceDisable();
            this.cmbVariavel1.removeForceDisable();
            this.cmbVariavel2.removeForceDisable();
            this.cmbVariavel3.removeForceDisable();
            this.cmbVariavel4.removeForceDisable();


            this.ensAgrupadorOp.removeForceDisable();
            this.ensAplicacaoCliente.removeForceDisable();
            this.ensClassificacaoProduto.removeForceDisable();
            this.ensCliente.removeForceDisable();
            this.ensEmbalagem.removeForceDisable();
            this.ensLocalFabricacao.removeForceDisable();
            this.ensUnidadeMedida.removeForceDisable();
            this.ensModeloEtiquetaExpedicao.removeForceDisable();

            this.chkVar1_CheckedChanged(null, null);
            this.chkVar2_CheckedChanged(null, null);
            this.chkVar3_CheckedChanged(null, null);
            this.chkVar4_CheckedChanged(null, null);



            this._salvarComo = true;
            this.DesabilitarAvisoAlteradoAoFechar = true;
        }

        private void InitializeGridBloqueios()
        {
            
            try
            {
                this.dgvBloqueios.AutoGenerateColumns = false;
                this.dgvBloqueios.DataSource = null;
                this.dgvBloqueios.DataSource = Produto.CollectionProdutoBloqueioQualidadeClassProduto;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar o grid de Bloqueios:" + e.Message, e);
            }
        }

        private void NovoBloqueio()
        {

            try
            {
                if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá incluir um novo bloqueio da qualidade no produto, deseja continuar?","Novo Bloqueio",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMotivoBloqueio.Text))
                {
                    throw new ExcecaoTratada("O campo de motivo deve ser preenchido");
                }


                ProdutoBloqueioQualidadeClass bloqueio = new ProdutoBloqueioQualidadeClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
                {
                    MotivoBloqueio = txtMotivoBloqueio.Text,
                    AcsUsuario = LoginClass.UsuarioLogado.loggedUser,
                    Ativo = true,
                    DataBloqueio = DataIndependenteClass.GetData(),
                    Produto = Produto,
                };

                Produto.CollectionProdutoBloqueioQualidadeClassProduto.Add(bloqueio);

                try
                {
                    Produto.DesabilitarJustificativaRevisaoProduto = true;
                    Produto.Save();
                }
                finally
                {
                    Produto.DesabilitarJustificativaRevisaoProduto = false;
                }
                

                InitializeGridBloqueios();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inserir um novo bloqueio:" + e.Message, e);
            }
        }

        private void EncerrarBloqueio()
        {
            
            try
            {
                if (dgvBloqueios.SelectedRowsIwt.Count != 1)
                {
                    throw new ExcecaoTratada("Selecione um e somente um bloqueio para encerrar");
                }

                if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá encerrar o bloqueio da qualidade selecionado, deseja continuar?", "Encerramento do Bloqueio", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                ProdutoBloqueioQualidadeClass bloqueio = (ProdutoBloqueioQualidadeClass) dgvBloqueios.SelectedRowsIwt[0].DataBoundItem;

                if (!bloqueio.Ativo)
                {
                    throw new ExcecaoTratada("O bloqueio selecionado não está ativo");
                }

                bloqueio.Ativo = false;
                bloqueio.DataEncerramentoBloqueio = DataIndependenteClass.GetData();
                bloqueio.AcsUsuarioEncerramentoBloqueio = LoginClass.UsuarioLogado.loggedUser;

                bloqueio.Save();

                dgvBloqueios.InvalidateRow(dgvBloqueios.SelectedRowsIwt[0].Index);

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao encerrar o bloqueio da qualidade:" + e.Message, e);
            }
        }


        #region Combos










        private void loadCombosVariavel()
        {
            try
            {
                List<SearchParameterClass> searchParameters = new List<SearchParameterClass>()
                                              {
                                                  new SearchParameterClass("var_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                                                  
                                              };

                if (this.Produto.Cliente!=null)
                {
                    searchParameters.Add(new SearchParameterClass("FamiliaClienteOrNull", this.Produto.Cliente.FamiliaCliente));
                }
                else
                {
                    searchParameters.Add(new SearchParameterClass("FamiliaCliente", null));
                }

                VariavelClass search = new VariavelClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<VariavelClass> entidades =
                    search.Search(searchParameters).
                        ConvertAll(a => (VariavelClass)a);


                VariavelClass selecaoAnterior1 = (VariavelClass) this.cmbVariavel1.SelectedItem; 
                this.cmbVariavel1.DataSource = entidades;
                this.cmbVariavel1.DisplayMember = "Nome";
                this.cmbVariavel1.ValueMember = "ID";
                this.cmbVariavel1.autoSize = true;
                this.cmbVariavel1.Table = entidades;
                this.cmbVariavel1.ColumnsToDisplay = new[] { "Nome", "Descricao", "FamiliaCliente" };
                this.cmbVariavel1.HeadersToDisplay = new string[] { "Código", "Descrição", "Familia Cliente" };
                this.cmbVariavel1.SelectedItem = selecaoAnterior1;


                VariavelClass selecaoAnterior2 = (VariavelClass)this.cmbVariavel2.SelectedItem;
                this.cmbVariavel2.DataSource = new List<VariavelClass>(entidades);
                this.cmbVariavel2.DisplayMember = "Nome";
                this.cmbVariavel2.ValueMember = "ID";
                this.cmbVariavel2.autoSize = true;
                this.cmbVariavel2.Table = entidades;
                this.cmbVariavel2.ColumnsToDisplay = new[] { "Nome", "Descricao", "FamiliaCliente" };
                this.cmbVariavel2.HeadersToDisplay = new string[] { "Código", "Descrição", "Familia Cliente" };
                this.cmbVariavel2.SelectedItem = selecaoAnterior2;


                VariavelClass selecaoAnterior3 = (VariavelClass)this.cmbVariavel3.SelectedItem;
                this.cmbVariavel3.DataSource = new List<VariavelClass>(entidades); 
                this.cmbVariavel3.DisplayMember = "Nome";
                this.cmbVariavel3.ValueMember = "ID";
                this.cmbVariavel3.autoSize = true;
                this.cmbVariavel3.Table = entidades;
                this.cmbVariavel3.ColumnsToDisplay = new[] { "Nome", "Descricao", "FamiliaCliente" };
                this.cmbVariavel3.HeadersToDisplay = new string[] { "Código", "Descrição", "Familia Cliente" };
                this.cmbVariavel3.SelectedItem = selecaoAnterior3;


                VariavelClass selecaoAnterior4 = (VariavelClass)this.cmbVariavel4.SelectedItem;
                this.cmbVariavel4.DataSource = new List<VariavelClass>(entidades); 
                this.cmbVariavel4.DisplayMember = "Nome";
                this.cmbVariavel4.ValueMember = "ID";
                this.cmbVariavel4.autoSize = true;
                this.cmbVariavel4.Table = entidades;
                this.cmbVariavel4.ColumnsToDisplay = new[] { "Nome", "Descricao", "FamiliaCliente" };
                this.cmbVariavel4.HeadersToDisplay = new string[] { "Código", "Descrição", "Familia Cliente" };
                this.cmbVariavel4.SelectedItem = selecaoAnterior4;


               


            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar os dados para seleção da Familia.\r\n" + e.Message);
            }
        }


        #endregion


        #region Eventos     

        protected override void OnShown(EventArgs e)
        {


            ModeloEtiquetaExpedicaoClass searchModeloEtiquetaExpedicao = new ModeloEtiquetaExpedicaoClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection);
            List<AbstractEntity> modelosEtiqueta = searchModeloEtiquetaExpedicao.Search(new List<SearchParameterClass>()).ToList();
            if (modelosEtiqueta.Count == 1)
            {
                this.ensModeloEtiquetaExpedicao.EntidadeSelecionada = modelosEtiqueta[0];
            }


            this.loadCombosVariavel();
            this.loading = true;
            base.OnShown(e);
            this.loading = false;
            if (this.Entity == null || this.Entity.ID == -1)
            {
                this.btnSalvarComo.Visible = false;
            }

            this.situacaoCadastrosProduto();

            this.atualizaLabelVariavel(1);
            this.atualizaLabelVariavel(2);
            this.atualizaLabelVariavel(3);
            this.atualizaLabelVariavel(4);

            this.Produto.Temporario = false;

            chkValidaVar1_CheckedChanged(null, null);
            chkValidaVar2_CheckedChanged(null, null);
            chkValidaVar3_CheckedChanged(null, null);
            chkValidaVar4_CheckedChanged(null, null);

            if (IWTLicensing.ControleLicenciamentoClass.Licenca != null && IWTLicensing.ControleLicenciamentoClass.Licenca.TipoLicenca != "COMPLETO")
            {
                this.label31.Visible = false;
                this.chkDimensaoMaiorFilho.Visible = false;

                this.chkEtiquetaInterna.Checked = false;
                this.chkEtiquetaInterna.Visible = false;

                this.chkValidacaoPesoExpedicao.Checked = false;
                this.chkValidacaoPesoExpedicao.Visible = false;


                this.nudQtdEtiquetaExpedicao.Value = 1;
                this.nudQtdEtiquetaExpedicao.Visible = false;
                this.label20.Visible = false;
                this.label21.Visible = false;

                this.nudTempoLimite.Visible = false;
                this.chkTempoLimite.Checked = false;
                this.chkTempoLimite.Visible = false;
                this.label7.Visible = false;

                this.Produto.EmiteOp = false;
                this.Produto.EmitePlanoCorte = false;

                this.chkVar1.Checked = false;
                this.chkVar1.Visible = false;
                this.cmbVariavel1.Visible = false;
                this.label14.Visible = false;

                this.chkVar2.Checked = false;
                this.chkVar2.Visible = false;
                this.cmbVariavel2.Visible = false;
                this.label15.Visible = false;

                this.chkVar3.Checked = false;
                this.chkVar3.Visible = false;
                this.cmbVariavel3.Visible = false;
                this.label16.Visible = false;

                this.chkVar4.Checked = false;
                this.chkVar4.Visible = false;
                this.cmbVariavel4.Visible = false;
                this.label17.Visible = false;

                this.label18.Visible = false;
                this.txtRegraDimesao.Visible = false;

                this.tabControl1.TabPages.Remove(tabValidacaoVariaveis);

            }

            InitializeGridBloqueios();
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

        private void chkVar1_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbVariavel1.Enabled = chkVar1.Checked;
            this.atualizaLabelVariavel(1);
        }

        private void chkVar2_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbVariavel2.Enabled = chkVar2.Checked;
            this.atualizaLabelVariavel(2);
        }

        private void chkVar3_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbVariavel3.Enabled = chkVar3.Checked;
            this.atualizaLabelVariavel(3);
        }

        private void chkVar4_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbVariavel4.Enabled = chkVar4.Checked;
            this.atualizaLabelVariavel(4);
        }
     
        private void cmsVariaveis_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.ToString())
                {
                    case "Variável 1":
                        if (this.cmbVariavel1.Enabled && this.cmbVariavel1.SelectedValue != null)
                        {
                            ((TextBox)((ContextMenuStrip)sender).SourceControl).Text += "$" + this.cmbVariavel1.Text+ "$";
                            ((TextBox)((ContextMenuStrip)sender).SourceControl).SelectionStart = ((TextBox)((ContextMenuStrip)sender).SourceControl).Text.Length;
                        }
                        else
                        {
                            throw new Exception("Variável 1 não foi selecionada.");
                        }

                        break;

                    case "Variável 2":
                        if (this.cmbVariavel2.Enabled && this.cmbVariavel2.SelectedValue != null)
                        {
                            ((TextBox)((ContextMenuStrip)sender).SourceControl).Text += "$" + this.cmbVariavel2.Text + "$";
                            ((TextBox)((ContextMenuStrip)sender).SourceControl).SelectionStart = ((TextBox)((ContextMenuStrip)sender).SourceControl).Text.Length;
                        }
                        else
                        {
                            throw new Exception("Variável 2 não foi selecionada.");
                        }


                        break;

                    case "Variável 3":
                        if (this.cmbVariavel3.Enabled && this.cmbVariavel3.SelectedValue != null)
                        {
                            ((TextBox)((ContextMenuStrip)sender).SourceControl).Text += "$" + this.cmbVariavel3.Text + "$";
                            ((TextBox)((ContextMenuStrip)sender).SourceControl).SelectionStart = ((TextBox)((ContextMenuStrip)sender).SourceControl).Text.Length;
                        }
                        else
                        {
                            throw new Exception("Variável 3 não foi selecionada.");
                        }

                        break;

                    case "Variável 4":
                        if (this.cmbVariavel4.Enabled && this.cmbVariavel4.SelectedValue != null)
                        {
                            ((TextBox)((ContextMenuStrip)sender).SourceControl).Text += "$" + this.cmbVariavel4.Text + "$";
                            ((TextBox)((ContextMenuStrip)sender).SourceControl).SelectionStart = ((TextBox)((ContextMenuStrip)sender).SourceControl).Text.Length;
                        }
                        else
                        {
                            throw new Exception("Variável 4 não foi selecionada.");
                        }

                        break;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao inserir a variável.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void chkTempoLimite_CheckedChanged(object sender, EventArgs e)
        {
            this.nudTempoLimite.Enabled = chkTempoLimite.Checked;
        }

        private void btnSalvarComo_Click(object sender, EventArgs e)
        {
            try
            {
                this.habilitarCopia();             
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkValidaVar1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.loading) return;
                if (this.chkValidaVar1.Checked)
                {
                    if (this.cmbVariavel1.Enabled && this.cmbVariavel1.SelectedValue != null)
                    {
                        this.txtValidaVar1.Enabled = true;
                    }
                    else
                    {
                        this.chkValidaVar1.Checked = false;
                        this.txtValidaVar1.Enabled = false;

                        throw new Exception("Selecione uma variável antes de definir a regra de validação.");
                    }
                }
                else
                {
                    this.txtValidaVar1.Enabled = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkValidaVar2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.loading) return;
                if (this.chkValidaVar2.Checked)
                {
                    if (this.cmbVariavel2.Enabled && this.cmbVariavel2.SelectedValue != null)
                    {
                        this.txtValidaVar2.Enabled = true;
                    }
                    else
                    {
                        this.chkValidaVar2.Checked = false;
                        this.txtValidaVar2.Enabled = false;

                        throw new Exception("Selecione uma variável antes de definir a regra de validação.");
                    }
                }
                else
                {
                    this.txtValidaVar2.Enabled = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkValidaVar3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.loading) return;
                if (this.chkValidaVar3.Checked)
                {
                    if (this.cmbVariavel3.Enabled && this.cmbVariavel3.SelectedValue != null)
                    {
                        this.txtValidaVar3.Enabled = true;
                    }
                    else
                    {
                        this.chkValidaVar3.Checked = false;
                        this.txtValidaVar3.Enabled = false;

                        throw new Exception("Selecione uma variável antes de definir a regra de validação.");
                    }
                }
                else
                {
                    this.txtValidaVar3.Enabled = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkValidaVar4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.loading) return;
                if (this.chkValidaVar4.Checked)
                {
                    if (this.cmbVariavel4.Enabled && this.cmbVariavel4.SelectedValue != null)
                    {
                        this.txtValidaVar4.Enabled = true;
                    }
                    else
                    {
                        this.chkValidaVar4.Checked = false;
                        this.txtValidaVar4.Enabled = false;

                        throw new Exception("Selecione uma variável antes de definir a regra de validação.");
                    }
                }
                else
                {
                    this.txtValidaVar4.Enabled = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbVariavel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.atualizaLabelVariavel(1);
        }

        private void cmbVariavel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.atualizaLabelVariavel(2);
        }

        private void cmbVariavel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.atualizaLabelVariavel(3);
        }

        private void cmbVariavel4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.atualizaLabelVariavel(4);
        }

        private void ensCliente_EntityChange(object sender, EventArgs e)
        {
            this.loadCombosVariavel();
        }

        private void btnNovoBloqueio_Click(object sender, EventArgs e)
        {
            try
            {
                NovoBloqueio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnEncerrarBloqueio_Click(object sender, EventArgs e)
        {
            try
            {
                EncerrarBloqueio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}

