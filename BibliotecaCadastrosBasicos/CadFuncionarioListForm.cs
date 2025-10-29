using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.Relatórios;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFuncionarioListForm : IWTListForm
    {
        private readonly bool _somenteAtivos;
        private readonly bool _somenteDadosBasicos;

        public CadFuncionarioListForm(bool somenteAtivos = false, bool somenteDadosBasicos = false)
        {
            _somenteAtivos = somenteAtivos;
            _somenteDadosBasicos = somenteDadosBasicos;
            InitializeComponent();

            btnDemitir.Visible = !somenteDadosBasicos;
            btnResumoEPI.Visible = !somenteDadosBasicos;
            iwtEditarButton1.Visible = !somenteDadosBasicos;
            iwtExcluirButton1.Visible = !somenteDadosBasicos;
            iwtNovoButton1.Visible = !somenteDadosBasicos;
        }


        private void Demitir()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count != 1)
                {
                    throw new ExcecaoTratada("Selecione um funcionário para realizar a demissão.");
                }

                FuncionarioClass func = (FuncionarioClass) ((IWTDataGridViewRow) this.getDataGrid().SelectedRows[0]).DataBoundItem;

                CadFuncionarioDemissaoForm form = new CadFuncionarioDemissaoForm(func.ToString());
                form.ShowDialog(this);

                if (!form.Confirmado) return;

                if (func.PossuiEpisNaoDescartados)
                {
                    if (DialogResult.Yes != MessageBox.Show(this, "O funcionário possui EPIs não descartados, se a demissão for realizada os EPIs serão descartados automaticamente. Deseja Continuar?", "Funcionário com EPIs não descartados", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    }
                }

                func.Demitir(form.DataSelecionada);
                

                this.ForceInitializeDataGrid();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao demitir\r\n" + e.Message, e);
            }
        }

        private void ResumoEPI()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count != 1)
                {
                    throw new ExcecaoTratada("Selecione um funcionário para gerar o relatório.");
                }

                FuncionarioClass func = (FuncionarioClass) ((IWTDataGridViewRow) this.getDataGrid().SelectedRows[0]).DataBoundItem;

                ResumoEPIReportForm form = new ResumoEPIReportForm(func);
                form.Show(this);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao demitir\r\n" + e.Message, e);
            }
        }

        #region ListForm

        public override Type getTipoEntidade()
        {
            return typeof (FuncionarioClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadFuncionarioForm form = new CadFuncionarioForm((FuncionarioClass) entidade, this);
                form.VerificaUtilizacao = TipoModulo.Tipo != TipoForm.Gerencial;

                if (entidade != null)
                {
                    if (!((FuncionarioClass) entidade).Ativo)
                    {
                        form.SomenteLeitura = true;
                    }
                }
                form.ShowDialog();
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
            List<SearchParameterClass> toRet = new List<SearchParameterClass>() {new SearchParameterClass("fuc_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)};

            if (_somenteAtivos)
            {
                this.rdbAtivos.Visible = false;
                this.rdbInativos.Visible = false;

                toRet.Add(new SearchParameterClass("Ativo", true));
            }

            return toRet;
        }

        public override List<DataGridViewColumn> getColunasGrid(string modoVisualizacaoGrid)
        {
            if (!_somenteDadosBasicos)
            {
                return base.getColunasGrid(modoVisualizacaoGrid);
            }

            return new List<DataGridViewColumn>()
            {
                ID,
                Nome
            };
        }

        #endregion

        #region Eventos

        private void btnDemitir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Demitir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnResumoEPI_Click(object sender, EventArgs e)
        {
            try
            {
                this.ResumoEPI();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion



    }
}
