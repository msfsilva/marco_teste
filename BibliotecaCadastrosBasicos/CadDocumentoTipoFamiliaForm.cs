using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.Relatórios;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadDocumentoTipoFamiliaForm : IWTForm
    {
        private TipoForm Tipo;
        private bool loadingGrid;
        private int qtdMaximaCopias = int.Parse(Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.DOCUMENTOS_QTD_MAXIMA_COPIAS));

        public CadDocumentoTipoFamiliaForm(DocumentoTipoFamiliaClass entidade, CadDocumentoTipoFamiliaListForm listForm, TipoForm tipo)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            Tipo = tipo;
            InitializeComponent();
        }

        public CadDocumentoTipoFamiliaForm(DocumentoTipoFamiliaClass entidade, TipoForm tipo)
            : base(entidade, typeof (DocumentoTipoFamiliaClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            Tipo = tipo;
            InitializeComponent();
        }


        private void setTipoTela()
        {
            this.Text = "Cópias do Documento " + ((DocumentoTipoFamiliaClass) this.Entity).FamiliaDocumento + " " + ((DocumentoTipoFamiliaClass) this.Entity).DocumentoTipo;


            switch (this.Tipo)
            {
                case TipoForm.Gerencial:
                    this.btnHistorico.Enabled = true;
                    this.btnDesativar.Enabled = true;
                    this.btnAdicionar.Enabled = true;
                    this.btnRemover.Enabled = true;
                    this.btnEtiqueta.Enabled = true;
                    this.btnAtivar.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnReimprimirEtiqueta.Enabled = true;
                    this.btnAbrirDocumento.Enabled = true;
                    break;
                case TipoForm.Engenharia:
                    this.btnHistorico.Enabled = false;
                    this.btnDesativar.Enabled = true;
                    this.btnAdicionar.Enabled = true;
                    this.btnRemover.Enabled = true;
                    this.btnEtiqueta.Enabled = true;
                    this.btnAtivar.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnReimprimirEtiqueta.Enabled = false;
                    this.btnAbrirDocumento.Enabled = true;
                    break;
                case TipoForm.PCP:
                    this.btnHistorico.Enabled = false;
                    this.btnDesativar.Enabled = true;
                    this.btnAdicionar.Enabled = true;
                    this.btnRemover.Enabled = true;
                    this.btnEtiqueta.Enabled = true;
                    this.btnAtivar.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnReimprimirEtiqueta.Enabled = false;
                    this.btnAbrirDocumento.Enabled = true;
                    break;
                case TipoForm.Qualidade:
                    this.btnHistorico.Enabled = false;
                    this.btnDesativar.Enabled = false;
                    this.btnAdicionar.Enabled = false;
                    this.btnRemover.Enabled = false;
                    this.btnEtiqueta.Enabled = false;
                    this.btnAtivar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnReimprimirEtiqueta.Enabled = false;
                    this.btnAbrirDocumento.Enabled = true;
                    break;
                default:
                    this.btnHistorico.Enabled = false;
                    this.btnDesativar.Enabled = true;
                    this.btnAdicionar.Enabled = false;
                    this.btnRemover.Enabled = false;
                    this.btnEtiqueta.Enabled = false;
                    this.btnAtivar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnReimprimirEtiqueta.Enabled = false;
                    this.btnAbrirDocumento.Enabled = false;
                    break;

            }
        }

        private void initializeGrid()
        {

            this.loadingGrid = true;
            dataGridView1.Columns.Clear();

            dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "ID";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Visible = false;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "ID";


            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Identificacao";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Identificação";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "Identificacao";

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "DataCriacao";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Criação";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Ativa";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Ativa";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Ocupada";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Ocupada";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "PermiteUtilizarOP";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Utiliza em OP";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "LocalizacaoEstoqueString";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Estoque";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "EtiquetaImpressa";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Etiqueta Impressa";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "DataImpressao";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Data Impressão";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "AcsUsuarioImpressao";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Usuário Impressão";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



            dataGridView1.DataSource = ((DocumentoTipoFamiliaClass)this.Entity).CollectionDocumentoCopiaClassDocumentoTipoFamilia;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            this.loadingGrid = false;
        }

        private void Excluir()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Deseja excluir a cópia de documento selecionada? Só será possível excluir uma cópia que nunca foi utilizada, as demais devem ser desativadas.", "Exclusão de Cópia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        DocumentoCopiaClass copia = (DocumentoCopiaClass) ((IWTDataGridViewRow) this.dataGridView1.SelectedRows[0]).DataBoundItem;
                        ((DocumentoTipoFamiliaClass) this.Entity).ExcluirCopia(copia);
                        this.initializeGrid();
                    }
                }
                else
                {
                    throw new Exception("Selecione o item a ser excluído.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir a cópia.\r\n" + e.Message);

            }
        }

        private void Adicionar()
        {
            try
            {

                CadDocumentoCopiaForm form = new CadDocumentoCopiaForm(null, (DocumentoTipoFamiliaClass) this.Entity,this.SingleConnection);
                form.ShowDialog();
                this.Entity.Save();
                

                this.initializeGrid();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar uma nova cópia.\r\n" + e.Message);

            }
        }

        private void AtivaDesativa(bool Ativa)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (Ativa)
                    {
                        if (((DocumentoTipoFamiliaClass) this.Entity).CollectionDocumentoCopiaClassDocumentoTipoFamilia.Count(a => a.Ativa) >= this.qtdMaximaCopias)
                        {
                            throw new Exception("Limite máximo de cópias ativas atingido. Consulte o administrador do sistema.");
                        }
                    }

                    DocumentoCopiaClass copia = (DocumentoCopiaClass)((IWTDataGridViewRow)this.dataGridView1.SelectedRows[0]).DataBoundItem;

                    if (copia.ID == -1)
                    {
                        if (MessageBox.Show(this, "Essa cópia ainda não foi salva, é necessário salvar o documento para realizar a ativação/desativacão. Deseja salvar agora?", "Cópia não salva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.Yes)
                        {
                            this.Entity.Save(); 

                            this.initializeGrid();
                        }
                        else
                        {
                            return;
                        }
                    }

                    CadDocumentoCopiaAtivaDesativaForm form = new CadDocumentoCopiaAtivaDesativaForm(ref copia, Ativa, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    form.ShowDialog();

                    this.initializeGrid();

                }
                else
                {
                    throw new Exception("Selecione o item a ser ativado/desativado.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao ativar/desativar a cópia.\r\n" + e.Message);

            }
        }

        private void HistoricoUtilizacao()
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {

                DocumentoCopiaClass copia = (DocumentoCopiaClass)((IWTDataGridViewRow)this.dataGridView1.SelectedRows[0]).DataBoundItem;
                CadDocumentoCopiaHistoricoForm form = new CadDocumentoCopiaHistoricoForm(ref copia, this.Tipo, this.SingleConnection);

                form.ShowDialog();

                this.initializeGrid();

            }
            else
            {
                throw new Exception("Selecione o item para visualizar o histórico.");
            }
        }

        private void etiquetaCopia(bool reimprimir)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    DocumentoCopiaClass copia = (DocumentoCopiaClass)((IWTDataGridViewRow)this.dataGridView1.SelectedRows[0]).DataBoundItem;
                    if (copia.ID == -1)
                    {
                        if (MessageBox.Show(this, "Essa cópia ainda não foi salva, é necessário salvar o documento para realizar a impressão da etiqueta. Deseja salvar agora?", "Cópia não salva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.Entity.Save();

                            this.initializeGrid();
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (!reimprimir)
                    {
                        if (copia.EtiquetaImpressa)
                        {
                            throw new Exception("Essa cópia já foi impressa anteriormente.");
                        }


                        copia.SetEtiquetaEmitida();
                    }
                    CadDocumentoCopiaReportForm form = new CadDocumentoCopiaReportForm(copia);



                    this.Entity.Save();

                    this.initializeGrid();
                }
                else
                {
                    throw new Exception("Selecione o item para imprimir a etiqueta.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Errro ao gerar a etiqueta.\r\n" + e.Message, e);
            }
        }

        private void Editar()
        {

            try
            {
                if (!this.loadingGrid && this.dataGridView1.SelectedRows.Count > 0)
                {
                    DocumentoCopiaClass copia = (DocumentoCopiaClass)((IWTDataGridViewRow)this.dataGridView1.SelectedRows[0]).DataBoundItem;

                    CadDocumentoCopiaForm form = new CadDocumentoCopiaForm(copia, (DocumentoTipoFamiliaClass)this.Entity,this.SingleConnection); 
                    form.ShowDialog();

                    this.Entity.Save();

                    this.initializeGrid();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar a cópia.\r\n" + e.Message);

            }

        }



        private void DownloadDocumento()
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                DocumentoTipoFamiliaClass familiaSelecionada = (DocumentoTipoFamiliaClass) this.Entity;
                if (familiaSelecionada.Documento == null)
                {
                    throw new Exception("Não existe documento escaneado disponível, consulte a engenharia.");
                }

                string tempDir = Environment.GetEnvironmentVariable("temp");
                if (tempDir != null)
                {
                    string nome = familiaSelecionada.DocumentoNome;
                    byte[] documento = familiaSelecionada.Documento;


                    fs = new FileStream(tempDir + "\\" + nome, FileMode.Create);
                    bw = new BinaryWriter(fs);
                    bw.Write(documento);
                    bw.Close();

                    Process.Start(tempDir + "\\" + nome);

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o documento.\r\n" + e.Message, e);
            }
            finally
            {
                if (bw != null)
                {
                    bw.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }

            }
        }





        #region Eventos
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.setTipoTela();
            initializeGrid();
        }

         private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Adicionar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Excluir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


         private void btnDesativar_Click(object sender, EventArgs e)
        {
            try
            {
                this.AtivaDesativa(false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                this.HistoricoUtilizacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                this.etiquetaCopia(false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            try
            {
                this.AtivaDesativa(true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Editar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReimprimirEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                this.etiquetaCopia(true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAbrirDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                this.DownloadDocumento();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

       
      
    }
}
