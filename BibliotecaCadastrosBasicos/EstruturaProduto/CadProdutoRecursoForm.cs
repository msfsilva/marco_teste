#region Referencias

using System;
using IWTDotNetLib;

#endregion

namespace BibliotecaCadastrosBasicos.EstruturaProduto
{
    public partial class CadProdutoRecursoForm : IWTBaseForm
    {
        public bool Secundario { get; private set; }
        public bool abortar { get; private set; }

        public CadProdutoRecursoForm()
        {
            InitializeComponent();
            this.abortar = false;
        }

        public CadProdutoRecursoForm(bool secundario)
        {
            InitializeComponent();
            this.abortar = false;
            this.Secundario = secundario;
            this.rdbSecundario.Checked = secundario;
            this.rdbPrimario.Checked = !secundario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.abortar = true;
            this.Close();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.abortar = false;
            this.Secundario = rdbSecundario.Checked;
            this.Close();
        }
    }
}
