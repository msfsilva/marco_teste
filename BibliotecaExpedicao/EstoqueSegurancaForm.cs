#region Referencias

using System;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;



#endregion

namespace BibliotecaExpedicao
{
    public partial class EstoqueSegurancaForm : IWTBaseForm
    {
        private readonly AcsUsuarioClass Usuario;
        private readonly IWTPostgreNpgsqlConnection conn;

        public EstoqueSegurancaForm(AcsUsuarioClass Usuario,IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.Usuario = Usuario;
            this.conn = conn;
        }

        private void codigoLido()
        {
            //"CR|" + gaveta.ID + "|" + Material.idMaterial + " "
            try
            {
                if (string.IsNullOrEmpty(this.txtBarcode.Text.Trim()))
                {
                    return;

                }

                string barcode = this.txtBarcode.Text.Trim().Replace("\r", "").Replace("\n", "").Replace('}', '|');
                if (!barcode.StartsWith("CR|") && !barcode.StartsWith("CR2|") && !barcode.StartsWith("CRK|") && !barcode.StartsWith("CREP|"))
                {
                    throw new Exception("Código de barras inválido");
                }

                string[] tmp = barcode.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                if (tmp.Length != 3 && tmp.Length != 4)
                {
                    throw new Exception("Código de barras inválido");
                }

                EstoqueSeguranca tipoEstoqueSeguranca = EstoqueSeguranca.NaoUtilizando;
                if (tmp.Length == 4)
                {
                    tipoEstoqueSeguranca = (EstoqueSeguranca) Enum.ToObject(typeof(EstoqueSeguranca), int.Parse(tmp[3]));
                }

                switch (tmp[0])
                {
                    case "CR":
                        int idMaterial = int.Parse(tmp[2]);
                        int idGavetaMaterial = int.Parse(tmp[1]);

                        MaterialClass material = MaterialBaseClass.GetEntidade(idMaterial, this.Usuario, this.conn);
                        material.ControleRevisaoHabilitado = false;
                        material.SetUtilizandoEstoqueSeguranca(tipoEstoqueSeguranca, false);
                        material.Save();

                        break;
                    case "CR2":

                        int idProduto = int.Parse(tmp[2]);
                        int idGavetaProduto = int.Parse(tmp[1]);

                        ProdutoClass produto = ProdutoBaseClass.GetEntidade(idProduto, this.Usuario, this.conn);
                        produto.SetUtilizandoEstoqueSeguranca(tipoEstoqueSeguranca, false);
                        produto.DesabilitarJustificativaRevisaoProduto = true;
                        produto.ControleRevisaoHabilitado = false;
                        produto.Save();
                        produto.DesabilitarJustificativaRevisaoProduto = false;
                        produto.ControleRevisaoHabilitado = true;
                        break;
                    case "CRK":

                        int idProdutoK = int.Parse(tmp[2]);
                        int idGavetaProdutoK = int.Parse(tmp[1]);

                        ProdutoKClass produtoK = ProdutoKBaseClass.GetEntidade(idProdutoK, this.Usuario, this.SingleConnection);
                        produtoK.ControleRevisaoHabilitado = false;
                        produtoK.SetUtilizandoEstoqueSeguranca(tipoEstoqueSeguranca, false);
                        produtoK.Save();

                        break;
                    case "CREP":
                        int idEPI = int.Parse(tmp[2]);
                        int idGavetaEpi = int.Parse(tmp[1]);

                        EpiClass epi = EpiBaseClass.GetEntidade(idEPI, this.Usuario, this.SingleConnection);
                        epi.ControleRevisaoHabilitado = false;
                        epi.SetUtilizandoEstoqueSeguranca(tipoEstoqueSeguranca, false);
                        epi.Save();
                        break;
                    default:
                        throw new Exception("Código de barras inválido");
                        break;
                }


                MessageBox.Show(this, "Estoque de segurança informado com sucesso!", "Sucesso", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao marcar o item como em estoque de segurança\r\n" + e.Message, e);
            }
            finally
            {
                this.LimparTela();
            }

        }

        private void LimparTela()
        {
            txtBarcode.Clear();
            txtBarcode.Focus();

        }

        #region eventos
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Enabled = false;
                this.codigoLido();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
