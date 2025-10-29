#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.Estoque
{
    public partial class CadEstoqueMovimentacaoForm : IWTBaseForm
    {
        int idProduto;
        int idEstoque;
        readonly double Quantidade;
        readonly string codProduto;
        AcsUsuarioClass Usuario;
        IWTPostgreNpgsqlCommand command;


        public CadEstoqueMovimentacaoForm(int idProduto, int idEstoque, double Quantidade, string codProduto,string unidadeMedida, AcsUsuarioClass Usuario, ref IWTPostgreNpgsqlCommand command)
        {
            InitializeComponent();
            this.idEstoque = idEstoque;
            this.idProduto = idProduto;
            this.Quantidade = Quantidade;
            this.codProduto = codProduto;
            this.Usuario = Usuario;
            this.command = command;

            this.lblCodigoProduto.Text = "Produto Selecionado: " + this.codProduto;
            this.lblUnidadeMedidaUso.Text = unidadeMedida;
            this.nudQuantidade.Value = (decimal)this.Quantidade;
        }

        private void Salvar()
        {
            try
            {
                if (txtDescricao.Text.Trim().Length < 5)
                {
                    throw new Exception("O campo de descrição deve ter ao menos 5 caracteres.");
                }

                double movQtd = (double)nudQuantidade.Value - this.Quantidade;
                if (movQtd != 0)
                {
                    //EstoqueClass.lancaMovimentoEstoque(this.idEstoque, this.idProduto, movQtd, true, this.txtDescricao.Text.Trim(), this.Usuario, ref this.command);
                }

                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar a quantidade em estoque.\r\n" + e.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Salvar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
    }
}
