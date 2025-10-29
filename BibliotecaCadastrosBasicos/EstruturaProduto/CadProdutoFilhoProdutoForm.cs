using System;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos.EstruturaProduto
{
    public partial class CadProdutoFilhoProdutoForm : IWTBaseForm
    {
        
        public double? Quantidade { get; set; }
        public string LocalizacaoDesenhoPai { get; set; }

        public bool Condicional { get; private set; }
        public string CondicionalRegra { get; private set; }

        public bool QtdCondicional { get; private set; }
        public string QtdCondicionalRegra { get; private set; }

        public CadProdutoFilhoProdutoForm()
        {
            InitializeComponent();
        }

        public CadProdutoFilhoProdutoForm(double quantidade, string localizacaoDesenhoPai, bool condicional, string condicionalRegra, bool qtdCondicional, string qtdCondicionalRegra)
        {
            QtdCondicional = qtdCondicional;
            QtdCondicionalRegra = qtdCondicionalRegra;
            InitializeComponent();
          
            this.txtPosicaoDesenhoPai.Text = localizacaoDesenhoPai;
            Condicional = condicional;
            CondicionalRegra = condicionalRegra;

            if (condicional)
            {
                this.chkCondicional.Checked = true;
                this.txtRegraCondicional.Text = condicionalRegra;
            }
            else
            {
                this.chkCondicional.Checked = false;
                this.txtRegraCondicional.Text = "";
            }


            if (qtdCondicional)
            {
                this.rdbQtdCondicional.Checked = true;
                this.rdbQtdFixa.Checked = false;
                this.txtQtdCondicionalRegra.Text = qtdCondicionalRegra;
                this.nudQuantidade.Value = 0;
            }
            else
            {
                this.rdbQtdCondicional.Checked = false;
                this.rdbQtdFixa.Checked = true;
                this.txtQtdCondicionalRegra.Text = "";
                this.nudQuantidade.Value = (decimal)quantidade;
            }
          
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (nudQuantidade.Enabled && Math.Round(this.nudQuantidade.Value, 5) <= 0)
            {
                throw new Exception("A quantidade do item filho deve ser maior do que zero.");
            }

            this.Quantidade = (double)this.nudQuantidade.Value;
            this.LocalizacaoDesenhoPai = this.txtPosicaoDesenhoPai.Text;

            this.Condicional = this.chkCondicional.Checked;
            this.CondicionalRegra = this.Condicional ? txtRegraCondicional.Text : null;

            this.QtdCondicional = this.rdbQtdCondicional.Checked;
            this.QtdCondicionalRegra = this.QtdCondicional ? txtQtdCondicionalRegra.Text : null;
            this.Quantidade = !this.QtdCondicional ? (double)this.nudQuantidade.Value : 0;

            this.Close();
        }

        private void chkCondicional_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRegraCondicional.Enabled = this.chkCondicional.Checked;
        }

        private void rdbQtdFixa_CheckedChanged(object sender, EventArgs e)
        {
            this.nudQuantidade.Enabled = this.rdbQtdFixa.Checked;
            this.txtQtdCondicionalRegra.Enabled = this.rdbQtdCondicional.Checked;
        }

        private void rdbQtdCondicional_CheckedChanged(object sender, EventArgs e)
        {
            this.nudQuantidade.Enabled = this.rdbQtdFixa.Checked;
            this.txtQtdCondicionalRegra.Enabled = this.rdbQtdCondicional.Checked;
        }
    }
}
