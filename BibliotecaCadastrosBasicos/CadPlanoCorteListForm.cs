using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.Relatórios;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPlanoCorteListForm : IWTListForm
    {
        private TipoForm Tipo;

        public CadPlanoCorteListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }

        private void ImprimirPlanoCorte()
        {
            if (this.iwtDataGridView1.SelectedRows.Count!=1)
            {
                throw new Exception("Selecione um plano de corte para imprimir.");
            }

            PlanoCorteClass planoCorte = (PlanoCorteClass) ((IWTDataGridViewRow)this.iwtDataGridView1.SelectedRows[0]).DataBoundItem;
            PlanoCorteReportForm form = new PlanoCorteReportForm(planoCorte);
            form.Show(this);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadPlanoCorteForm form = new CadPlanoCorteForm((PlanoCorteClass) entidade, this);
                form.VerificaUtilizacao = false;
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

        public override Type getTipoEntidade()
        {
            return typeof (PlanoCorteClass);

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
            return new List<SearchParameterClass>() {new SearchParameterClass("plano_corte.id_plano_corte", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Numerica)};
        }

        private void Cancelar()
        {
            try
            {
                if (getDataGrid().SelectedRows.Count == 0)
                {
                    throw new ExcecaoTratada("Selecione ao menos um plao de corte para cancelar.");
                }

                JustificativaForm tela = new JustificativaForm("Informe a justificativa para o cancelamento do(s) plano(s) de corte", "Cancelamento de PC");
                tela.ShowDialog(this);
                if (tela.Abortar)
                {
                    return;
                }

                foreach (IWTDataGridViewRow row in this.iwtDataGridView1.SelectedRows)
                {
                    PlanoCorteClass pc = (PlanoCorteClass)row.DataBoundItem;
                    if (!pc.Cancelado)
                    {
                        pc.CancelarPC(tela.Justificativa);
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
                throw new Exception("Erro inesperado ao cancelar os planos de corte \r\n" + e.Message, e);
            }
        }



        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.ImprimirPlanoCorte();
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
                this.Cancelar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}
