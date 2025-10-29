#region Referencias

using System;
using System.Globalization;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCompras
{
    public partial class CadNFEntradaItemForm : IWTBaseForm
    {
        public NFEntradaItemClass item { get; private set; }
        NFEntradaClass NF;
        public bool Abortado { get; private set; }

        public CadNFEntradaItemForm(ref NFEntradaClass NF, ref NFEntradaItemClass item, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            if (item == null)
            {
                this.item = new NFEntradaItemClass(null, NF, conn);
            }
            else
            {
                this.item = item;
                this.dadosTela();
            }
            this.NF = NF;
            this.recalcularTotal();
            this.Abortado = false;
        }

        private void dadosTela()
        {
            try
            {
                if (this.item != null)
                {
                    this.txtCodigo.Text = this.item.Codigo;
                    this.txtDescricao.Text = this.item.Descricao;
                    this.txtNCM.Text = this.item.NCM;
                    this.nudValorUnitario.Value = Convert.ToDecimal(this.item.valorUnitario);
                    this.nudQuantidade.Value = Convert.ToDecimal(this.item.Quantidade);
                    this.nudImcsIncluso.Value = Convert.ToDecimal(this.item.icmsIncluso);
                    this.nudIPINaoIncluso.Value = Convert.ToDecimal(this.item.ipiNaoIncluso);
                    this.txtUnidade.Text = this.item.Unidade;


                    this.txtXped.Text = item.XPed;
                    this.nudPosicao.Value = (decimal) (item.Posicao??1);

                }
                this.recalcularTotal();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao preencher os dados da tela.\r\n" + e.Message, e);
            }
        }

        private void Ok()
        {
            try
            {
                if (this.txtCodigo.Text.Trim().Length == 0)
                {
                    throw new Exception("O campo de código é obrigatório");
                }

                if (this.txtDescricao.Text.Trim().Length == 0)
                {
                    throw new Exception("O campo de descrição é obrigatório");
                }

                if (this.txtNCM.Text.Trim().Length == 0)
                {
                    throw new Exception("O campo de NCM é obrigatório");
                }

                if (this.txtUnidade.Text.Trim().Length == 0)
                {
                    throw new Exception("O campo de Unidade é obrigatório");
                }

                this.item.Codigo = this.txtCodigo.Text;
                this.item.Descricao = this.txtDescricao.Text;
                this.item.NCM = this.txtNCM.Text;
                this.item.Unidade = this.txtUnidade.Text;
                this.item.valorUnitario = Convert.ToDouble(this.nudValorUnitario.Value);
                this.item.Quantidade = Convert.ToDouble(this.nudQuantidade.Value);
                this.item.icmsIncluso = Convert.ToDouble(this.nudImcsIncluso.Value);
                this.item.ipiNaoIncluso = Convert.ToDouble(this.nudIPINaoIncluso.Value);
                this.item.valorTotal = this.item.valorUnitario * this.item.Quantidade;

                this.item.XPed = this.txtXped.Text;
                this.item.Posicao = (int)this.nudPosicao.Value;
                this.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir os dados.\r\n" + e.Message, e);
            }
        }

        private void recalcularTotal()
        {
            try
            {
                this.lblValorTotal.Text = "R$ "+
                    Convert.ToDouble(this.nudQuantidade.Value * this.nudValorUnitario.Value)
                    .ToString("F2", CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular o valor total.\r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Ok();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Abortado = true;
            this.Close();
        }
     
        private void nudValorUnitario_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.recalcularTotal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudQuantidade_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.recalcularTotal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
