using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadCidadeForm : IWTForm
    {
        private EstadoClass estadoEstrangeiro = null;
        private bool loading=false;

        public CadCidadeForm(CidadeClass cidade, CadCidadeListForm listForm)
            : base(cidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.Estado.FormSelecao = new CadEstadoListForm();
            this.Pais.FormSelecao = new CadPaisListForm();
            estadoEstrangeiro = EstadoClass.GetEntidade(-10, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
        }

        public CadCidadeForm(CidadeClass cidade)
            : base(cidade, typeof(CidadeClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            this.Estado.FormSelecao = new CadEstadoListForm();
            this.Pais.FormSelecao = new CadPaisListForm();
            estadoEstrangeiro = EstadoClass.GetEntidade(-10, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
        }

        protected override void OnShown(EventArgs e)
        {
            this.loading = true;
            base.OnShown(e);
            this.loading = false;
        }

        private void Pais_EntityChange(object sender, EventArgs e)
        {
            try
            {

                AjustaCamposForm();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjustaCamposForm()
        {
            try
            {
                if (this.loading) return;

                if (this.Pais.EntidadeSelecionada != null)
                {
                    if (((PaisClass) this.Pais.EntidadeSelecionada).Codigo == 1058)
                    {
                        this.Estado.removeForceDisable();
                        this.iwtNumericUpDown1.Enabled = true;
                        this.Estado.EntidadeSelecionada = null;
                    }
                    else
                    {
                        this.Estado.forceDisable();
                        this.iwtNumericUpDown1.Enabled = false;
                        this.Estado.EntidadeSelecionada = estadoEstrangeiro;
                        ((CidadeClass) this.Entity).Estado = estadoEstrangeiro;                        
                    }
                }
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao selecionar país.\r\n" + e.Message, e);
            }
        }        
    }
}
