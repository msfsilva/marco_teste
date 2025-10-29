using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Base;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDocumentoTipoForm : IWTForm
    {
        private bool loading;
        private byte[] novoDocumentoScaneado;
        private string novoDocumentoScaneadoNome;

        public CadDocumentoTipoForm(DocumentoTipoClass entidade, CadDocumentoTipoListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
           init();
        }

        public CadDocumentoTipoForm(DocumentoTipoClass entidade)
            : base(entidade, typeof(DocumentoTipoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            loadComboFamiliaDocumento();

            if (
                (TipoModulo.Tipo == TipoForm.Engenharia && !LoginClass.UsuarioLogado.HasAccess("MODULO_ENGENHARIA_CADASTROS_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita)) ||
                (TipoModulo.Tipo == TipoForm.Gerencial && !LoginClass.UsuarioLogado.HasAccess("MODULO_GERENCIAL_CADASTROS_OPERACIONAIS_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita)) ||
                (TipoModulo.Tipo == TipoForm.Qualidade && !LoginClass.UsuarioLogado.HasAccess("MODULO_QUALIDADE_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita))
                )
            {
                this.btnCopias.Visible = false;
            }
        }

        private void loadComboFamiliaDocumento()
        {
            try
            {
                BibliotecaEntidades.Entidades.FamiliaDocumentoClass search = new BibliotecaEntidades.Entidades.FamiliaDocumentoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<BibliotecaEntidades.Entidades.FamiliaDocumentoClass> resultados =
                    search.Search(new List<SearchParameterClass>() {new SearchParameterClass("Codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)}).ConvertAll(
                        a => (BibliotecaEntidades.Entidades.FamiliaDocumentoClass) a);


                this.cmbFamilia.DataSource = resultados;
                this.cmbFamilia.DisplayMember = "Codigo";
                this.cmbFamilia.ValueMember = "ID";
                this.cmbFamilia.autoSize = true;
                this.cmbFamilia.Table = resultados;
                this.cmbFamilia.ColumnsToDisplay = new[] {"Codigo", "Descricao"};
                this.cmbFamilia.HeadersToDisplay = new[] {"Código", "Descricão"};


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

        private void updateGridFamilias()
        {
            try
            {

                this.loading = true;
                dgvFamilias.Columns.Clear();
                dgvFamilias.DataSource = null;

                dgvFamilias.AutoGenerateColumns = false;


                this.dgvFamilias.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].DataPropertyName = "FamiliaDocumento";
                this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].HeaderText = "Identificação";
                this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dgvFamilias.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].DataPropertyName = "descricaoFamilia";
                this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].HeaderText = "Descrição";
                this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (Configurations.IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.VALIDACAO_REVISAO_DOCUMENTO_HABILITADA))
                {
                    this.dgvFamilias.Columns.Add(new DataGridViewTextBoxColumn());
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].DataPropertyName = "TipoValidacaoTraduzido";
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].HeaderText = "Tipo Validação";
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    this.dgvFamilias.Columns.Add(new DataGridViewTextBoxColumn());
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].DataPropertyName = "DocumentoPedidoFamilia";
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].HeaderText = "Validação Familia";
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                    this.dgvFamilias.Columns.Add(new DataGridViewTextBoxColumn());
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].DataPropertyName = "DocumentoPedido";
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].HeaderText = "Validação Documento";
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                    this.dgvFamilias.Columns.Add(new DataGridViewTextBoxColumn());
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].DataPropertyName = "DocumentoPedidoRevisao";
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].HeaderText = "Validação Revisão";
                    this.dgvFamilias.Columns[this.dgvFamilias.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }



                dgvFamilias.DataSource = ((DocumentoTipoClass) this.Entity).CollectionDocumentoTipoFamiliaClassDocumentoTipo;

                dgvFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFamilias.MultiSelect = false;

                this.loading = false;

                if (this.dgvFamilias.RowCount>0)
                {
                    this.dgvFamilias.Rows[0].Selected = true;
                }

                this.selecionarLinha();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados das familias para edição.\r\n" + e.Message);
            }
        }

        private void adicionarFamilia()
        {
            try
            {
                if (this.cmbFamilia.SelectedValue != null)
                {
                    FamiliaDocumentoClass idFamilia = (FamiliaDocumentoClass) this.cmbFamilia.SelectedItem;
                    TipoValidacaoDocumento tipoValidacao = TipoValidacaoDocumento.NaoValidar;

                    string DocumentoPedidoFamilia = null;
                    string DocumentoPedido = null;
                    string DocumentoPedidoRevisao = null;

                    if (this.rdbPermitirComAviso.Checked)
                    {
                        tipoValidacao = TipoValidacaoDocumento.ValidarAviso;
                        DocumentoPedidoFamilia = this.txtClienteDocumentoFamilia.Text;
                        DocumentoPedido = this.txtClienteDocumento.Text;
                        DocumentoPedidoRevisao = this.txtClienteDocumentoRevisao.Text;
                    }

                    if (this.rdbNaoPermitir.Checked)
                    {
                        tipoValidacao = TipoValidacaoDocumento.ValidarBloqueio;
                        DocumentoPedidoFamilia = this.txtClienteDocumentoFamilia.Text;
                        DocumentoPedido = this.txtClienteDocumento.Text;
                        DocumentoPedidoRevisao = this.txtClienteDocumentoRevisao.Text;
                    }

                    DocumentoTipoFamiliaClass familia = ((DocumentoTipoClass) this.Entity).incluirFamilia(idFamilia, tipoValidacao, DocumentoPedidoFamilia, DocumentoPedido, DocumentoPedidoRevisao);
                    if (this.novoDocumentoScaneado != null)
                    {
                        familia.Documento = this.novoDocumentoScaneado;
                        familia.DocumentoNome = this.novoDocumentoScaneadoNome;

                        this.novoDocumentoScaneado = null;
                        this.novoDocumentoScaneadoNome = null;
                    }

                    familia.setBloqueado(this.chkBloqueado.Checked);


                    this.updateGridFamilias();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void excluirFamilia()
        {
            try
            {
                if (this.dgvFamilias.SelectedRows.Count > 0)
                {
                    ((DocumentoTipoClass) this.Entity).excluirFamilia((DocumentoTipoFamiliaClass) (((IWTDataGridViewRow) this.dgvFamilias.SelectedRows[0]).DataBoundItem));
                    this.updateGridFamilias();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void selecionarLinha()
        {
            try
            {
                if (!this.loading)
                {
                    if (this.dgvFamilias.SelectedRows.Count > 0)
                    {


                        DocumentoTipoFamiliaClass familiaSelecionada = (DocumentoTipoFamiliaClass) ((IWTDataGridViewRow)this.dgvFamilias.SelectedRows[0]).DataBoundItem;

                        this.cmbFamilia.SelectedItem = familiaSelecionada.FamiliaDocumento;
                        switch (familiaSelecionada.TipoValidacao)
                        {



                            case TipoValidacaoDocumento.NaoValidar:
                                this.rdbNaoValidar.Checked = true;
                                this.txtClienteDocumento.Text = "";
                                this.txtClienteDocumentoFamilia.Text = "";
                                this.txtClienteDocumentoRevisao.Text = "";
                                break;
                            case TipoValidacaoDocumento.ValidarAviso:
                                this.rdbPermitirComAviso.Checked = true;
                                this.txtClienteDocumento.Text = familiaSelecionada.DocumentoPedido;
                                this.txtClienteDocumentoFamilia.Text = familiaSelecionada.DocumentoPedidoFamilia;
                                this.txtClienteDocumentoRevisao.Text = familiaSelecionada.DocumentoPedidoRevisao;
                                break;
                            case TipoValidacaoDocumento.ValidarBloqueio:
                                this.rdbNaoPermitir.Checked = true;
                                this.txtClienteDocumento.Text = familiaSelecionada.DocumentoPedido;
                                this.txtClienteDocumentoFamilia.Text = familiaSelecionada.DocumentoPedidoFamilia;
                                this.txtClienteDocumentoRevisao.Text = familiaSelecionada.DocumentoPedidoRevisao;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        if (familiaSelecionada.Documento != null)
                        {
                            this.lnkDocumento.Text = "Baixar: " + familiaSelecionada.DocumentoNome;
                            this.lnkDocumento.Visible = true;
                        }
                        else
                        {
                            this.lnkDocumento.Visible = false;
                        }

                        if (familiaSelecionada.Bloqueado)
                        {
                            this.chkBloqueado.Checked = true;
                        }
                        else
                        {
                            this.chkBloqueado.Checked = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar a linha\r\n" + e.Message, e);
            }
        }

        private void SelecioneDocumento()
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                if (this.ofdDocumento.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(this.ofdDocumento.FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    if (fs.Length > 10485760)
                    {
                        throw new Exception("O arquivo deve possuir menos de 10Mb");
                    }


                    this.novoDocumentoScaneado = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    this.novoDocumentoScaneadoNome = new FileInfo(this.ofdDocumento.FileName).Name;


                    this.lnkDocumento.Text = "Baixar: " + novoDocumentoScaneadoNome;
                    this.lnkDocumento.Visible = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o documento escaneado.\r\n" + e.Message, e);
            }
            finally
            {
                if (br != null)
                {

                    br.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }

            }


        }

        private void DownloadDocumento()
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                string tempDir = Environment.GetEnvironmentVariable("temp");
                if (tempDir != null)
                {
                    DocumentoTipoFamiliaClass familiaSelecionada = (DocumentoTipoFamiliaClass)((IWTDataGridViewRow)this.dgvFamilias.SelectedRows[0]).DataBoundItem;

                    


                    string nome = this.novoDocumentoScaneadoNome ?? familiaSelecionada.DocumentoNome;
                    byte[] documento = this.novoDocumentoScaneado ?? familiaSelecionada.Documento;


                    fs = new FileStream(tempDir + "\\" + nome, FileMode.Create);
                    bw = new BinaryWriter(fs);
                    bw.Write(documento);
                    Process.Start(tempDir + "\\" + nome);


                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o documento escaneado\r\n" + e.Message, e);
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

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            this.adicionarFamilia();
            ((DocumentoTipoClass) this.Entity).Identificacao = ((DocumentoTipoClass) this.Entity).Identificacao;
            base.Salvar(command);
        }




        private void Copias()
        {
            try
            {
                if (this.dgvFamilias.SelectedRows.Count != 1)
                {
                    throw new ExcecaoTratada("Inclua e selecione na listagem uma familia antes de acessar as cópias.");
                }

                DocumentoTipoFamiliaClass familiaSelecionada = (DocumentoTipoFamiliaClass) ((IWTDataGridViewRow) this.dgvFamilias.SelectedRows[0]).DataBoundItem;
                if (familiaSelecionada.ID==-1)
                {
                    if (DialogResult.Yes!=MessageBox.Show(this,"Antes de acessar as cópias o EASI irá salvar as alterações feitas no documento, deseja continuar?","Salvar",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                    {
                        return;
                    }
                    this.DesabilitaMensagens = true;
                    this.Salvar();
                    this.DesabilitaMensagens = false;
                }


                CadDocumentoTipoFamiliaForm form = new CadDocumentoTipoFamiliaForm(familiaSelecionada, TipoModulo.Tipo);
                form.ShowDialog(this);

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



        #region Eventos
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            if (Configurations.IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.VALIDACAO_REVISAO_DOCUMENTO_HABILITADA))
            {
                this.grbValidacaoDocumento.Visible = true;
            }
            else
            {
                this.grbValidacaoDocumento.Visible = false;
                this.rdbNaoValidar.Checked = true;
            }

            if (this.Entity.ID != -1)
            {
                this.txtRevisao.ReadOnly = true;
            }

            updateGridFamilias();


            if (this.SomenteLeitura)
            {
                this.lnkDocumento.Enabled = true;
            }
        }
        
        private void btnDocumentoEscaneado_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelecioneDocumento();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkDocumento_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
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

        private void rdbNaoValidar_CheckedChanged(object sender, EventArgs e)
        {
            this.txtClienteDocumento.Enabled = !this.rdbNaoValidar.Checked;
            this.txtClienteDocumentoFamilia.Enabled = !this.rdbNaoValidar.Checked;
            this.txtClienteDocumentoRevisao.Enabled = !this.rdbNaoValidar.Checked;
            this.label8.Enabled = !this.rdbNaoValidar.Checked;
            this.label6.Enabled = !this.rdbNaoValidar.Checked;
            this.label7.Enabled = !this.rdbNaoValidar.Checked; 
        }

        private void rdbPermitirComAviso_CheckedChanged(object sender, EventArgs e)
        {
            this.txtClienteDocumento.Enabled = !this.rdbNaoValidar.Checked;
            this.txtClienteDocumentoFamilia.Enabled = !this.rdbNaoValidar.Checked;
            this.txtClienteDocumentoRevisao.Enabled = !this.rdbNaoValidar.Checked;
            this.label8.Enabled = !this.rdbNaoValidar.Checked;
            this.label6.Enabled = !this.rdbNaoValidar.Checked;
            this.label7.Enabled = !this.rdbNaoValidar.Checked; 
        }

        private void rdbNaoPermitir_CheckedChanged(object sender, EventArgs e)
        {
            this.txtClienteDocumento.Enabled = !this.rdbNaoValidar.Checked;
            this.txtClienteDocumentoFamilia.Enabled = !this.rdbNaoValidar.Checked;
            this.txtClienteDocumentoRevisao.Enabled = !this.rdbNaoValidar.Checked;
            this.label8.Enabled = !this.rdbNaoValidar.Checked;
            this.label6.Enabled = !this.rdbNaoValidar.Checked;
            this.label7.Enabled = !this.rdbNaoValidar.Checked; 
        }

        private void btnFamiliaAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.adicionarFamilia();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFamiliaDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.excluirFamilia();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFamilias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.selecionarLinha();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rdbNaoValidar.Checked = true;
            this.txtClienteDocumento.Text = "";
            this.txtClienteDocumentoFamilia.Text = "";
            this.txtClienteDocumentoRevisao.Text = "";

            this.lnkDocumento.Visible = false;
            this.chkBloqueado.Checked = false;
        }


        private void btnCopias_Click(object sender, EventArgs e)
        {
            try
            {
                this.Copias();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
