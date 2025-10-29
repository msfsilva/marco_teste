using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadRecursoForm : IWTForm
    {
        private bool loading = false;
        private bool _salvarComo = false;

        protected RecursoClass Recurso
        {
            get { return (RecursoClass) this.Entity; }

        }

        public CadRecursoForm(RecursoClass recurso, CadRecursoListForm listForm)
            : base(recurso, listForm, listForm.SingleConnection)
        {
            InitializeComponent();

            this.cmbFamilia.FormSelecao = new CadFamiliaRecursoListForm(TipoModulo.Tipo);
            this.ensEstoque.FormSelecao = new CadEstoqueListForm(desabilitarOperacaoes: true);

            this.cmbPostoTrabalho.FormSelecao = new CadPostoTrabalhoListForm(TipoModulo.Tipo);

        }

        public CadRecursoForm(RecursoClass recurso):base(recurso, typeof(RecursoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();

            this.cmbFamilia.FormSelecao = new CadFamiliaRecursoListForm(TipoModulo.Tipo);
            this.ensEstoque.FormSelecao = new CadEstoqueListForm(desabilitarOperacaoes: true);
            this.cmbPostoTrabalho.FormSelecao = new CadPostoTrabalhoListForm(TipoModulo.Tipo);
        }


        private void InitCorredor()
        {
            try
            {
                if (this.ensEstoque.EntidadeSelecionada == null)
                {
                    this.ensCorredor.forceDisable();
                    this.ensCorredor.FormSelecao = null;
                    this.ensCorredor.EntidadeSelecionada = null;
                }
                else
                {
                    this.ensCorredor.FormSelecao = new CadEstoqueCorredorListForm(true, (EstoqueClass)this.ensEstoque.EntidadeSelecionada);
                    this.ensCorredor.EntidadeSelecionada = null;
                    this.ensCorredor.removeForceDisable();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar o Corredor\r\n" + e.Message);
            }
        }

        private void InitPrateleira()
        {
            try
            {
                if (this.ensCorredor.EntidadeSelecionada == null)
                {
                    this.ensPrateleira.forceDisable();
                    this.ensPrateleira.FormSelecao = null;
                    this.ensPrateleira.EntidadeSelecionada = null;
                }
                else
                {
                    this.ensPrateleira.FormSelecao = new CadEstoquePrateleiraListForm(true, (EstoqueCorredorClass)this.ensCorredor.EntidadeSelecionada);
                    this.ensPrateleira.EntidadeSelecionada = null;
                    this.ensPrateleira.removeForceDisable();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar a Prateleira\r\n" + e.Message);
            }
        }

        private void InitGaveta()
        {
            try
            {
                if (this.ensPrateleira.EntidadeSelecionada == null)
                {
                    this.ensGaveta.forceDisable();
                    this.ensGaveta.FormSelecao = null;
                    this.ensGaveta.EntidadeSelecionada = null;
                }
                else
                {
                    this.ensGaveta.FormSelecao = new CadEstoqueGavetaListForm((EstoquePrateleiraClass)this.ensPrateleira.EntidadeSelecionada);
                    this.ensGaveta.EntidadeSelecionada = null;
                    this.ensGaveta.removeForceDisable();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar a Gaveta\r\n" + e.Message);
            }
        }

        private void GavetaSelecionada()
        {
            try
            {
                if (this.ensGaveta.EntidadeSelecionada != null)
                {

                    ((RecursoClass) this.Entity).EstoqueGaveta = (EstoqueGavetaClass) this.ensGaveta.EntidadeSelecionada;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao selecioanar a Gaveta\r\n" + e.Message);
            }
        }



        private void SalvarComo()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                this.Recurso.SalvarComo(ref command);

                command.Transaction.Commit();
                if (this.ListForm != null)
                {
                    this.ListForm.ForceInitializeDataGrid();
                }
                MessageBox.Show(this, "Cópia do recurso realizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void habilitarCopia()
        {
            this.Text = "COPIANDO Recurso: " + this.iwtTextBox1.Text + " - " + this.iwtTextBox2.Text;
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

            iwtTextBox1.removeForceDisable();
            iwtTextBox2.removeForceDisable();
            cmbFamilia.removeForceDisable();
            dtDataInicio.removeForceDisable();
            dtDataTermino.removeForceDisable();



            this._salvarComo = true;
            this.DesabilitarAvisoAlteradoAoFechar = true;
        }




        private void btnEncerrarVigencia_Click(object sender, EventArgs e)
        {
            try
            {
                this.encerrarModelo();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void encerrarModelo()
        {
            try
            {
                if (MessageBox.Show(this, "Você deseja encerrar a vigência desse recurso?", "Encerramento de vigência", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.btnEncerrarVigencia.Visible = false;
                    this.dtDataTermino.Visible = true;
                    this.dtDataTermino.Value = Configurations.DataIndependenteClass.GetData();
                    this.dtDataTermino.Enabled = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao encerrar a vigência.\r\n" + e.Message);
            }
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                this.selecionaArquivo();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void selecionaArquivo()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.txtArquivo.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o arquivo\r\n" + e.Message, e);
            }
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            try
            {
                this.selecionaDestino();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void selecionaDestino()
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtDestino.Text = folderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o arquivo\r\n" + e.Message, e);
            }
        }

      


  


        private void trocaTipoRecurso()
        {
            if (this.rdbNormal.Checked)
            {
                this.lblArquivo.Visible = false;
                this.lblDestino.Visible = false;
                this.txtArquivo.Visible = false;
                this.txtDestino.Visible = false;
                this.btnArquivo.Visible = false;
                this.btnDestino.Visible = false;
                return;
            }

            if (this.rdbFormulario.Checked)
            {
                this.lblArquivo.Visible = true;
                this.lblDestino.Visible = false;
                this.txtArquivo.Visible = true;
                this.txtDestino.Visible = false;
                this.btnArquivo.Visible = true;
                this.btnDestino.Visible = false;
                return;
            }

            if (this.rdbCNC.Checked)
            {
                this.lblArquivo.Visible = true;
                this.lblDestino.Visible = true;
                this.txtArquivo.Visible = true;
                this.txtDestino.Visible = true;
                this.btnArquivo.Visible = true;
                this.btnDestino.Visible = true;
                return;
            }
        }

        private void rdbNormal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.trocaTipoRecurso();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbCNC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.trocaTipoRecurso();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbFormulario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.trocaTipoRecurso();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {

            this.btnEncerrarVigencia.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.loading = true;


            if (this.Entity.ID != -1)
            {
                if (((RecursoClass)this.Entity).EstoqueGaveta != null)
                {
                    this.ensEstoque.EntidadeSelecionada = ((RecursoClass)this.Entity).EstoqueGaveta.EstoquePrateleira.EstoqueCorredor.Estoque;
                    this.ensCorredor.EntidadeSelecionada = ((RecursoClass)this.Entity).EstoqueGaveta.EstoquePrateleira.EstoqueCorredor;
                    this.ensPrateleira.EntidadeSelecionada = ((RecursoClass)this.Entity).EstoqueGaveta.EstoquePrateleira;
                    this.ensGaveta.EntidadeSelecionada = ((RecursoClass)this.Entity).EstoqueGaveta;
                }
                else
                {
                    this.ensCorredor.forceDisable();
                    this.ensPrateleira.forceDisable();
                    this.ensGaveta.forceDisable();
                }
            }
            else
            {
                this.ensCorredor.forceDisable();
                this.ensPrateleira.forceDisable();
                this.ensGaveta.forceDisable();
            }

            if (Recurso != null)
            {
               
                if (Recurso.DataInicio != null) dtDataInicio.Value = (DateTime)Recurso.DataInicio;

                if (Recurso.DataTermino != null)
                {

                   
                    dtDataTermino.Visible = true;
                    btnEncerrarVigencia.Visible = false;

                    this.SomenteLeitura = true;

                }
            }
            else
            {
                dtDataInicio.Value = Configurations.DataIndependenteClass.GetData();
            }

            this.loading = false;

            base.OnShown(e);

          
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

        private void ensEstoque_EntityChange(object sender, EventArgs e)
        {
            try
            {
                InitCorredor();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ensCorredor_EntityChange(object sender, EventArgs e)
        {
            try
            {
                InitPrateleira();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ensPrateleira_EntityChange(object sender, EventArgs e)
        {
            try
            {
                InitGaveta();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensGaveta_EntityChange(object sender, EventArgs e)
        {
            try
            {
                GavetaSelecionada();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}
