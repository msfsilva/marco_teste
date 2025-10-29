using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadFuncionarioForm : IWTForm
    {

        FuncionarioClass Funcionario
        {
            get { return (FuncionarioClass) Entity; }
        }

        public CadFuncionarioForm(FuncionarioClass funcao, CadFuncionarioListForm listForm)
            : base(funcao, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.iesEstadoCtps.FormSelecao = new CadEstadoListForm();
            this.iesCidade.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
        }

        public CadFuncionarioForm(FuncionarioClass funcao)
            : base(funcao, typeof(FuncionarioClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.iesEstadoCtps.FormSelecao = new CadEstadoListForm();
            this.iesCidade.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
        }

        private void initializeGridFuncao()
        {
            this.dgvFuncao.DataSource = null;
            this.dgvFuncao.AutoGenerateColumns = false;
            this.dgvFuncao.DataSource =
                new AdvancedList<FuncionarioFuncaoClass>(((FuncionarioClass) this.Entity)
                    .CollectionFuncionarioFuncaoClassFuncionario);
            this.dgvFuncao.Refresh();

            ListSortDirection ls = ListSortDirection.Ascending;
            if (this.dgvFuncao.SortOrder == SortOrder.Descending)
            {
                ls = ListSortDirection.Descending;
            }

            this.dgvFuncao.Sort(this.dgvFuncao.SortedColumn ?? this.dgvFuncao.Columns[0], ls);
        }

        private void loadComboEpi()
        {
            try
            {
                EpiClass search = new EpiClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<EpiClass> epis =
                    search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("epi_identificacao", null, SearchOperacao.SomenteOrdenacao,
                            SearchOrdenacao.Asc, TipoOrdenacao.String)

                    }).ConvertAll(a => (EpiClass) a);

                this.cmbEpi.DataSource = epis;
                this.cmbEpi.DisplayMember = "Identificacao";
                this.cmbEpi.ValueMember = "ID";
                this.cmbEpi.autoSize = true;
                this.cmbEpi.Table = epis;
                this.cmbEpi.ColumnsToDisplay = new[] {"Identificacao", "Descricao"};
                this.cmbEpi.HeadersToDisplay = new[] {"Identificação", "Descrição"};



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Epi.\r\n" + e.Message);
            }
        }

        private void loadComboFuncao()
        {
            try
            {
                FuncaoClass search = new FuncaoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<FuncaoClass> funcoes =
                    search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("fun_identificacao", null, SearchOperacao.SomenteOrdenacao,
                            SearchOrdenacao.Asc, TipoOrdenacao.String)
                    }).ConvertAll(a => (FuncaoClass) a);

                this.cmbFuncao.DataSource = funcoes;
                this.cmbFuncao.DisplayMember = "Identificacao";
                this.cmbFuncao.ValueMember = "ID";
                this.cmbFuncao.autoSize = true;
                this.cmbFuncao.Table = funcoes;
                this.cmbFuncao.ColumnsToDisplay = new[] {"Identificacao", "Descricao"};
                this.cmbFuncao.HeadersToDisplay = new[] {"Identificação", "Descrição"};



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da Função.\r\n" + e.Message);
            }
        }

        private void initializeGridEpi()
        {
            this.btnRetiradaEpi.Visible = this.rdbTodos.Checked || this.rdbPendRet.Checked;
            this.dgvEpi.DataSource = null;
            this.dgvEpi.AutoGenerateColumns = false;

            SituacaoFuncionarioEpi? situacaoEpi = null;
            if (rdbPendRet.Checked)
            {
                situacaoEpi = SituacaoFuncionarioEpi.Pendente;
            }

            if (rdbRet.Checked)
            {
                situacaoEpi = SituacaoFuncionarioEpi.Ativo;
            }

            if (rdbVenc.Checked)
            {
                situacaoEpi = SituacaoFuncionarioEpi.Vencido;
            }

            if (rdbDescart.Checked)
            {
                situacaoEpi = SituacaoFuncionarioEpi.Descartado;
            }

            if (situacaoEpi != null)
            {
                this.dgvEpi.DataSource =
                    new AdvancedList<FuncionarioEpiClass>(
                        ((FuncionarioClass) this.Entity).CollectionFuncionarioEpiClassFuncionario.Where(a =>
                            a.Situacao == situacaoEpi));
            }
            else
            {
                this.dgvEpi.DataSource =
                    new AdvancedList<FuncionarioEpiClass>(((FuncionarioClass) this.Entity)
                        .CollectionFuncionarioEpiClassFuncionario);
            }

            this.dgvEpi.Refresh();

            ListSortDirection ls = ListSortDirection.Ascending;
            if (this.dgvEpi.SortOrder == SortOrder.Descending)
            {
                ls = ListSortDirection.Descending;
            }

            this.dgvEpi.Sort(this.dgvEpi.SortedColumn ?? this.dgvEpi.Columns[0], ls);
        }

        private void retiradaEpi()
        {
            IWTPostgreNpgsqlCommand command = null;

            try
            {
                command = this.SingleConnection.CreateCommand();

                List<FuncionarioClass> funcionarios = new List<FuncionarioClass>();
                funcionarios.Add((FuncionarioClass) this.Entity);
                List<FuncionarioEpiClass> funcionarioEpis = new List<FuncionarioEpiClass>();

                command.Transaction = command.Connection.BeginTransaction();

                foreach (DataGridViewRow row in this.dgvEpi.SelectedRows)
                {
                    ((FuncionarioClass) this.Entity).retirarEpi((FuncionarioEpiClass) row.DataBoundItem, ref command);
                    funcionarioEpis.Add((FuncionarioEpiClass) row.DataBoundItem);
                }

                command.Transaction.Commit();

                if (funcionarioEpis.Count > 0)
                {
                    CadRetiradaEpiReportForm form = new CadRetiradaEpiReportForm(funcionarios, funcionarioEpis,
                        LoginClass.UsuarioLogado.loggedUser);
                    form.ShowDialog();
                }




            }
            catch (Exception a)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                MessageBox.Show("Erro ao retirar Epi(s).\r\n" + a.Message, "Retirada de Epi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.initializeGridEpi();
            }
        }

        private void SelecionaCidade()
        {
            try
            {
                this.labEstado.Text = ((CidadeClass) this.iesCidade.EntidadeSelecionada).Estado.ToString();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao selecionar a cidade.\r\n" + e.Message, e);
            }
        }

        #region Documentos

        private void InitializeGridDocumentos()
        {
            this.dgvDocumentos.DataSource = null;
            this.dgvDocumentos.DataSource =
                new AdvancedList<FuncionarioDocumentoClass>(Funcionario.CollectionFuncionarioDocumentoClassFuncionario);


        }

        private void AdicionarDocumento()
        {
           

                FuncionarioDocumentoClass documento =
                    new FuncionarioDocumentoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                    {
                        Funcionario = Funcionario
                    };
                CadFuncionarioDocumentoForm form = new CadFuncionarioDocumentoForm(documento)
                {
                    ModoMasterDetail = true
                };

                form.ShowDialog(this);


                if (form.Salvo)
                {
                    this.Funcionario.AdicionarDocumento(documento);
                    documento.ForceDirty();
                }

                InitializeGridDocumentos();

          
        }

        private void ExcluirDocumento()
        {
           
                if (this.dgvDocumentos.SelectedRows.Count == 0) return;

                if (DialogResult.Yes != MessageBox.Show(this, "Deseja excluir o Documento selecionado?",
                        "Exclusão de Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                FuncionarioDocumentoClass documento =
                    (FuncionarioDocumentoClass) ((IWTDataGridViewRow) this.dgvDocumentos.SelectedRows[0]).DataBoundItem;
                this.Funcionario.ExcluirDocumento(documento);

                InitializeGridDocumentos();
     
        }

        private void VisualizarDocumento()
        {
            if (this.dgvDocumentos.SelectedRows.Count == 0) return;

            FuncionarioDocumentoClass doc =
                (FuncionarioDocumentoClass) ((IWTDataGridViewRow) this.dgvDocumentos.SelectedRows[0]).DataBoundItem;
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                string tempDir = Environment.GetEnvironmentVariable("temp");
                if (tempDir != null)
                {
                    string nome = doc.NomeArquivo;
                    byte[] documento = doc.Arquivo;


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

        #endregion


        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            this.loadComboEpi();
            this.loadComboFuncao();
            this.initializeGridEpi();
            this.initializeGridFuncao();
            InitializeGridDocumentos();

            base.OnShown(e);

            if (SomenteLeitura)
            {
                btnDocumentoAbrir.removeForceDisable();
            }
        }

        private void btnAddFuncao_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbFuncao.SelectedItem != null)
                {
                    ((FuncionarioClass) this.Entity).addFuncao((FuncaoClass) this.cmbFuncao.SelectedItem);
                    this.initializeGridFuncao();
                    this.initializeGridEpi();
                }
                else
                {
                    throw new Exception("Selecione um Epi para ser adicionado.");
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao adicionar Função.\r\n" + a.Message, "Adicionar Função", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRemoveFuncao_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvFuncao.SelectedRows)
                {
                    ((FuncionarioClass) this.Entity).removeFuncao((FuncionarioFuncaoClass) row.DataBoundItem);
                }

                this.initializeGridFuncao();
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao remover Função.\r\n" + a.Message, "Remover Função", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAddEpi_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbEpi.SelectedItem != null)
                {
                    int qtdEpiAdd = (int) this.nudQtdEpi.Value;
                    while (qtdEpiAdd > 0)
                    {
                        ((FuncionarioClass) this.Entity).addEpi((EpiClass) this.cmbEpi.SelectedItem);
                        qtdEpiAdd--;
                    }

                }
                else
                {
                    throw new Exception("Selecione um Epi para ser adicionado.");
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao adicionar Epi.\r\n" + a.Message, "Adicionar Epi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.initializeGridEpi();
            }
        }

        private void btnRemoverEpi_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Você deseja descartar os EPIs selecionados?", "Descarte de EPI",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                foreach (DataGridViewRow row in this.dgvEpi.SelectedRows)
                {
                    ((FuncionarioClass) this.Entity).removeEpi((FuncionarioEpiClass) row.DataBoundItem);
                }

                initializeGridEpi();
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao remover Epi.\r\n" + a.Message, "Remover Epi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRelatEpi_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.retiradaEpi();
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao gerar relatório de Epi.\r\n" + a.Message, "Relatório", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void rdbPendRet_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGridEpi();
        }

        private void rdbRet_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGridEpi();
        }

        private void rdbVenc_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGridEpi();
        }

        private void rdbDescart_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGridEpi();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGridEpi();
        }

        private void iesCidade_EntityChange(object sender, EventArgs e)
        {
            try
            {
                SelecionaCidade();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDocumentoNovo_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarDocumento();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDocumentoExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluirDocumento();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void btnDocumentoAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                VisualizarDocumento();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        #endregion

    }
}
