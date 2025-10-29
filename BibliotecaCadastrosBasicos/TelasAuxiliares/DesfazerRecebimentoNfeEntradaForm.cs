using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class DesfazerRecebimentoNfeEntradaForm : IWTBaseForm
    {
        public DesfazerRecebimentoNfeEntradaForm()
        {
            InitializeComponent();
        }

        private void DesfazerRecebimentoNfeEntradaForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDesfazerRecebimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Deseja continuar com a operação de desfazer o recebimento?", "Desfazer o recebimento.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string erro = NotaFiscalEntradaFuncoesAuxiliares.DesfazerRecebimento(txtCNPJ.Text.Trim(), txtSerie.Text.Trim(), txtNumero.Text.Trim(), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                    if (string.IsNullOrEmpty(erro))
                    {
                        MessageBox.Show(this, "A operação foi concluída com sucesso, essa operação não desfaz as movimentações de estoque feitas pelo recebimento de estoque anterior, se desejar faça o ajuste manualmente através da tela de movimentação manual de estoque", "Operação concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        throw new ExcecaoTratada(erro);
                    }

                }
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BufferAbstractEntity.limparBuffer();
            }
        }
    }
}
