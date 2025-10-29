using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFuncionarioDemissaoForm : IWTBaseForm
    {
        public DateTime DataSelecionada { get; private set; }
        public bool Confirmado { get; private set; }


        public CadFuncionarioDemissaoForm(string funcionario)
        {
            InitializeComponent();
            this.Text += " " + funcionario;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DataSelecionada = dtpDataDemissao.Value;
            this.Confirmado = true;
            this.Close();
        }
    }
}
