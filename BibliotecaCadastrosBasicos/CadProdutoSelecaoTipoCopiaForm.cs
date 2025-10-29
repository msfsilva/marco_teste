using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadProdutoSelecaoTipoCopiaForm : IWTDotNetLib.IWTBaseForm
    {
        public bool Estrutura { get; private set; }
        public bool Fiscal { get; private set; }
        public bool Precos { get; private set; }

        public CadProdutoSelecaoTipoCopiaForm()
        {
            InitializeComponent();
        }

        private void iwtButton1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void CadProdutoSelecaoTipoCopiaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Estrutura = chkEstrutura.Checked;
            this.Fiscal = chkFiscal.Checked;
            this.Precos = chkPrecos.Checked;
        }
    }
}

