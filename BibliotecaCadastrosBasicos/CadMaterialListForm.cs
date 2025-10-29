using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.Relatórios;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadMaterialListForm : IWTListForm
    {
        private TipoForm Tipo;
        private FornecedorClass _fornecedor;
        private readonly bool _somenteAtivos;


        public CadMaterialListForm(TipoForm tipo, bool modoSelecao = false, string filtroSelecao = null, FornecedorClass fornecedor = null, bool somenteAtivos = true)
        {
            InitializeComponent();

            this.Tipo = tipo;
            _fornecedor = fornecedor;
            _somenteAtivos = somenteAtivos;
            base.FiltroSelecao = filtroSelecao;
            base.ModoSelecao = modoSelecao;

            if (_somenteAtivos)
            {
                rdbInativos.Visible = false; 
            }

        }

        #region Funções List

        public override Type getTipoEntidade()
        {
            return typeof (MaterialClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadMaterialForm form = new CadMaterialForm((MaterialClass) entidade, this);
                form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
                form.ShowDialog();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override IWTDataGridView getDataGrid()
        {
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            List<SearchParameterClass> toRet = new List<SearchParameterClass>()
                       {
                           new SearchParameterClass("FamiliaCodigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String),
                           new SearchParameterClass("Codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                       };

            if (_fornecedor!=null)
            {
                toRet.Add(new SearchParameterClass("MateriaisFornecedor", _fornecedor));
            }

            if (_somenteAtivos)
            {
                toRet.Add(new SearchParameterClass("Ativo", true));
            }
            
            return toRet;
        }

        #endregion

        private void setScreenMode()
        {
            switch (this.Tipo)
            {
                case TipoForm.PCP:
                    this.btnEditar.Enabled = true;
                    this.btnEtiqueta.Enabled = true;
                    this.btnExcluir.Enabled = true;
                    this.btnFiscal.Enabled = false;
                    this.btnNovo.Enabled = false;
                    break;

                case TipoForm.Gerencial:
                    this.btnEditar.Enabled = true;
                    this.btnEtiqueta.Enabled = true;
                    this.btnExcluir.Enabled = true;
                    this.btnFiscal.Enabled = true;
                    this.btnNovo.Enabled = true;
                    break;

                case TipoForm.Engenharia:
                    this.btnEditar.Enabled = true;
                    this.btnEtiqueta.Enabled = true;
                    this.btnExcluir.Enabled = true;
                    this.btnFiscal.Enabled = false;
                    this.btnNovo.Enabled = true;
                    break;

                case TipoForm.Financeiro:
                    this.btnEditar.Enabled = false;
                    this.btnEtiqueta.Enabled = false;
                    this.btnExcluir.Enabled = false;
                    this.btnFiscal.Enabled = true;
                    this.btnNovo.Enabled = false;
                    break;

                default:
                    this.btnEditar.Enabled = false;
                    this.btnEtiqueta.Enabled = false;
                    this.btnExcluir.Enabled = false;
                    this.btnFiscal.Enabled = false;
                    this.btnNovo.Enabled = false;
                    break;
            }




        }

        private void EtiquetaCompraRepetitiva()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    List<MaterialClass> materiais = new List<MaterialClass>();
                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        materiais.Add(((MaterialClass) row.DataBoundItem));
                    }

                    EtiquetaCompraRepetitivaReportForm form = new EtiquetaCompraRepetitivaReportForm(null, null, materiais, null);

                    if (!form.Abort)
                    {
                        form.Show();
                    }
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar as etiquetas de Kanban.\r\n" + e.Message, e);
            }
        }

        private void Fiscal()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    long? id = ((MaterialClass) (((IWTDataGridViewRow)this.getDataGrid().SelectedRows[0]).DataBoundItem)).ID;
                    CadMaterialFiscalForm form = new CadMaterialFiscalForm(id);
                    form.ShowDialog();

                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o cadastro fiscal.\r\n" + e.Message, e);
            }
        }

        private void HistoricoCompra()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count <= 0)
                {
                    throw new ExcecaoTratada("Selecione ao menos um material antes de abrir o histórico de compra");

                }

                List<AbstractEntity> materiais = new List<AbstractEntity>();
                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    materiais.Add((AbstractEntity)row.DataBoundItem);
                }


                EvolucaoPrecoCompraReportForm form = new EvolucaoPrecoCompraReportForm(materiais, EvolucaoPrecoCompraReportClass.SelecaoEntidadeRelatorio.Material);
                form.Show(this);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }
        }

        private void AtivarDesativar()
        {
            try
            {
                string operacao;
                if (this.rdbAtivos.Checked)
                {
                    operacao = "Desativar";
                }
                else
                {
                    operacao = "Reativar";
                }


                if (MessageBox.Show(this, "Essa operação irá " + operacao + " os materiais selecionados, deseja continuar?", operacao + " materiais", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                JustificativaForm form = new JustificativaForm("Entre com a justificativa para a operação:");
                form.ShowDialog(this);

                if (form.Abortar)
                {
                    return;
                }

                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {

                    MaterialClass material = (MaterialClass) row.DataBoundItem;

                    bool controleRevisaoAnterior = material.ControleRevisaoHabilitado;
                    try
                    {
                        material.ControleRevisaoHabilitado = false;
                        material.Ativo = !material.Ativo;
                        material.UltimaRevisao = form.Justificativa;
                        material.UltimaRevisaoData = DataIndependenteClass.GetData();
                        material.UltimaRevisaoUsuario = getUsuarioAtual();
                        material.Save();
                     
                    }
                    finally
                    {
                        material.ControleRevisaoHabilitado = controleRevisaoAnterior;
                    }
                }

                this.ForceInitializeDataGrid();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao desativar ou reativar o material.\r\n" + e.Message, e);
            }
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            this.setScreenMode();
            base.OnShown(e);

            this.iwtTextBox1.Focus();
            if (this.ModoSelecao)
            {
                this.rdbAtivos.Checked = true;
                this.rdbAtivos.Visible = false;
                this.rdbInativos.Visible = false;
            }
        }

        private void btnEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                this.EtiquetaCompraRepetitiva();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                this.Fiscal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnHistoricoCompra_Click(object sender, EventArgs e)
        {
            try
            {
                HistoricoCompra();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtivarDesativar_Click(object sender, EventArgs e)
        {
            try
            {
                AtivarDesativar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbAtivos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbAtivos.Checked)
            {
                this.btnAtivarDesativar.Text = "Desativar";
            }
            else
            {
                this.btnAtivarDesativar.Text = "Reativar";
            }
        }

        private void rdbInativos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbAtivos.Checked)
            {
                this.btnAtivarDesativar.Text = "Desativar";
            }
            else
            {
                this.btnAtivarDesativar.Text = "Reativar";
            }
        }

        #endregion


    }
}
