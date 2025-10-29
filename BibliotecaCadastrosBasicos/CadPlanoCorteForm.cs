using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPlanoCorteForm : IWTForm
    {
        public CadPlanoCorteForm(PlanoCorteClass entidade, CadPlanoCorteListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadPlanoCorteForm(PlanoCorteClass entidade)
            : base(entidade, typeof(PlanoCorteClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }


        private void InitializeGrid()
        {
            try
            {
                this.iwtDataGridView1.DataSource = null;
                this.iwtDataGridView1.DataSource = ((PlanoCorteClass) this.Entity).CollectionPlanoCorteItemClassPlanoCorte;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar a lista de itens do plano de corte.\r\n" + e.Message, e);
            }
        }

        private void Cancelar()
        {
            try
            {
                if (iwtDataGridView1.SelectedRows.Count==0)
                {
                    throw new ExcecaoTratada("Selecione ao menos um item para cancelar.");
                }

                JustificativaForm tela = new JustificativaForm("Informe a justificativa para o cancelamento do(s) item(ns) do plano de corte", "Cancelamento de Item de PC");
                tela.ShowDialog(this);
                if (tela.Abortar)
                {
                    return;
                }

                foreach (IWTDataGridViewRow row in this.iwtDataGridView1.SelectedRows)
                {
                    PlanoCorteItemClass item = (PlanoCorteItemClass) row.DataBoundItem;
                    if (!item.Cancelado)
                    {
                        item.CancelarItemPC(tela.Justificativa);
                    }
                }

                this.InitializeGrid();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Cancelar o item do plano de corte\r\n" + e.Message, e);
            }
        }

        #region Eventos
        protected override void OnShown(EventArgs e)
        {
            try
            {
                base.OnShown(e);
                this.btnSalvar.Visible = false;
                this.InitializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancelarItem_Click(object sender, EventArgs e)
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

        

        #endregion
    }
}
