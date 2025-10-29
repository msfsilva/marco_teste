using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadGerenciamentoEpiFuncionarioForm : IWTBaseForm
    {
        private FuncionarioClass _funcionario=null;
        private bool _fechar = false;

        public CadGerenciamentoEpiFuncionarioForm()
        {
            InitializeComponent();

            ensFuncionario.FormSelecao = new CadFuncionarioListForm(somenteAtivos: true, somenteDadosBasicos: true);
            LoadComboEpi();
        }


        private void LoadComboEpi()
        {
            try
            {
                EpiClass search = new EpiClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<EpiClass> epis =
                    search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("epi_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)

                    }).ConvertAll(a => (EpiClass)a);

                this.cmbEpi.DataSource = epis;
                this.cmbEpi.DisplayMember = "Identificacao";
                this.cmbEpi.ValueMember = "ID";
                this.cmbEpi.autoSize = true;
                this.cmbEpi.Table = epis;
                this.cmbEpi.ColumnsToDisplay = new[] { "Identificacao", "Descricao" };
                this.cmbEpi.HeadersToDisplay = new[] { "Identificação", "Descrição" };



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Epi.\r\n" + e.Message);
            }
        }

        private void SelecionaFuncionario()
        {

            if (_funcionario != null)
            {
                if (_funcionario.IsDirty())
                {
                    if (DialogResult.Yes == MessageBox.Show(this, "Foram feitas alterações no funcionário " + _funcionario.Nome + " e não foram salvas. Deseja salva-las antes de trocar de funcionário?", "Troca de Funcionário", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        bool tmp = _funcionario.ControleRevisaoHabilitado;
                        try
                        {
                            _funcionario.ControleRevisaoHabilitado = false;
                            _funcionario.Save();
                        }
                        finally
                        {
                            _funcionario.ControleRevisaoHabilitado = tmp;
                        }
                    }
                    else
                    {
                        _funcionario.RollbackSomenteEntidade();
                    }
                }
            }

            dgvEpi.DataSource = null;
            _funcionario = (FuncionarioClass) this.ensFuncionario.EntidadeSelecionada;
            grbEpi.Enabled = _funcionario != null;
            if (_funcionario != null)
            {
                InitializeGridEpi();
            }
            
        }

        private void InitializeGridEpi()
        {
           try
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
                            _funcionario.CollectionFuncionarioEpiClassFuncionario.Where(a => a.Situacao == situacaoEpi));
                }
                else
                {
                    this.dgvEpi.DataSource = new AdvancedList<FuncionarioEpiClass>(_funcionario.CollectionFuncionarioEpiClassFuncionario);
                }

                this.dgvEpi.Refresh();

                ListSortDirection ls = ListSortDirection.Ascending;
                if (this.dgvEpi.SortOrder == SortOrder.Descending)
                {
                    ls = ListSortDirection.Descending;
                }

                this.dgvEpi.Sort(this.dgvEpi.SortedColumn ?? this.dgvEpi.Columns[0], ls);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar o grid de EPI" + Environment.NewLine + e.Message, e);
            }
        }


        private void AdicionarEpi()
        {
            try
            {
                if (_funcionario == null)
                {
                    throw new ExcecaoTratada("Selecione um funcionário antes de adicionar um EPI");
                }

                if (this.cmbEpi.SelectedItem != null)
                {
                    int qtdEpiAdd = (int)this.nudQtdEpi.Value;
                    while (qtdEpiAdd > 0)
                    {
                        _funcionario.addEpi((EpiClass)this.cmbEpi.SelectedItem);
                        qtdEpiAdd--;
                    }

                }
                else
                {
                    throw new ExcecaoTratada("Selecione um Epi para ser adicionado.");
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao adicionar Epi.\r\n" + a.Message, "Adicionar Epi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.InitializeGridEpi();
            }
        }

      

        private void RemoverEpi()
        {
           try
            {
                if (_funcionario == null)
                {
                    throw new ExcecaoTratada("Selecione um funcionário antes de remover um EPI");
                }

                if (MessageBox.Show(this, "Você deseja descartar os EPIs selecionados?", "Descarte de EPI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                foreach (DataGridViewRow row in this.dgvEpi.SelectedRows)
                {
                    _funcionario.removeEpi((FuncionarioEpiClass)row.DataBoundItem);
                }
                InitializeGridEpi();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao remover o EPI" + Environment.NewLine + e.Message, e);
            }
        }

        private void RetiradaEpi()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (_funcionario == null)
                {
                    throw new ExcecaoTratada("Selecione um funcionário antes de realizar a retirada de um EPI");
                }

                command = SingleConnection.CreateCommand();

                List<FuncionarioClass> funcionarios = new List<FuncionarioClass>();
                funcionarios.Add(_funcionario);
                List<FuncionarioEpiClass> funcionarioEpis = new List<FuncionarioEpiClass>();

                command.Transaction = command.Connection.BeginTransaction();

                foreach (DataGridViewRow row in this.dgvEpi.SelectedRows)
                {
                    _funcionario.retirarEpi((FuncionarioEpiClass)row.DataBoundItem, ref command);
                    funcionarioEpis.Add((FuncionarioEpiClass)row.DataBoundItem);
                }

                command.Transaction.Commit();

                if (funcionarioEpis.Count > 0)
                {
                    CadRetiradaEpiReportForm form = new CadRetiradaEpiReportForm(funcionarios, funcionarioEpis, LoginClass.UsuarioLogado.loggedUser);
                    form.ShowDialog();
                }

            }

            catch (ExcecaoTratada)
            {
                command?.Transaction?.Rollback();
                throw;
            }
            catch (Exception e)
            {
                command?.Transaction?.Rollback();
                throw new Exception("Erro inesperado ao " + Environment.NewLine + e.Message, e);
            }
            finally
            {
                this.InitializeGridEpi();
            }
        }

        private void Salvar()
        {
            try
            {
                if (_funcionario == null)
                {
                    throw new ExcecaoTratada("Selecione um funcionário antes de Salvar");
                }

                bool tmp = _funcionario.ControleRevisaoHabilitado;
                try
                {
                    _funcionario.ControleRevisaoHabilitado = false;
                    _funcionario.Save();
                }
                finally
                {
                    _funcionario.ControleRevisaoHabilitado = tmp;
                }

                MessageBox.Show(this, "Dados salvos com Sucesso!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Salvar" + Environment.NewLine + e.Message, e);
            }
        }

        private void Cancelar()
        {
            _fechar = true;
            Close();
        }
        #region Eventos
        private void ensFuncionario_EntityChange(object sender, EventArgs e)
        {
              try
              {
                  SelecionaFuncionario();
              }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEpi_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarEpi();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverEpi_Click(object sender, EventArgs e)
        {
              try
              {
                  RemoverEpi();
              }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
              try
              {
                  Salvar();
              }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
              try
              {
                  Cancelar();
              }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetiradaEpi_Click(object sender, EventArgs e)
        {
              try
              {
                  RetiradaEpi();
              }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadGerenciamentoEpiFuncionarioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (_funcionario != null && _funcionario.IsDirty())
                {
                    if (DialogResult.Yes == MessageBox.Show(this, "Foram feitas alterações no funcionário " + _funcionario.Nome + " e não foram salvas. Deseja salva-las antes de fechar?", "Saindo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        bool tmp = _funcionario.ControleRevisaoHabilitado;
                        try
                        {
                            _funcionario.ControleRevisaoHabilitado = false;
                            _funcionario.Save();
                        }
                        finally
                        {
                            _funcionario.ControleRevisaoHabilitado = tmp;
                        }
                    }
                    else
                    {
                        _funcionario.RollbackSomenteEntidade();
                    }
                }

            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void rdbPendRet_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                InitializeGridEpi();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbRet_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                InitializeGridEpi();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbVenc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                InitializeGridEpi();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDescart_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                InitializeGridEpi();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                InitializeGridEpi();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion
    }
}
