using System;
using System.Windows.Forms;
using BibliotecaCentroCusto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAgrupadorPostoTrabalhoForm : IWTForm
    {
        public CadAgrupadorPostoTrabalhoForm(AgrupadorPostoTrabalhoClass agrupadorPostoTrabalho, CadAgrupadorPostoTrabalhoListForm listForm)
            : base(agrupadorPostoTrabalho, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


        public CadAgrupadorPostoTrabalhoForm(AgrupadorPostoTrabalhoClass agrupadorPostoTrabalho)
            : base(agrupadorPostoTrabalho, typeof(AgrupadorPostoTrabalhoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }


        private void selecionarCentroCusto()
        {
            try
            {
                SelecaoCentroCustoLucroForm form = new SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza.Custo);
                form.ShowDialog();

                if (form.CentroSelecionado != null)
                {
                    this.txtCentroCusto.Text = form.CentroSelecionado.ToString();
                    ((AgrupadorPostoTrabalhoClass)this.Entity).CentroCustoLucro = form.CentroSelecionado;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o centro de custo\r\n" + e.Message, e);
            }
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.Entity != null && ((AgrupadorPostoTrabalhoClass)this.Entity).CentroCustoLucro!=null)
            {
                this.txtCentroCusto.Text = ((AgrupadorPostoTrabalhoClass) this.Entity).CentroCustoLucro.ToString();
            }
        }

        private void btnCentroCusto_Click(object sender, EventArgs e)
        {
            try
            {
                this.selecionarCentroCusto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
