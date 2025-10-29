using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class CancelamentoOpEncerradaForm : IWTBaseForm
    {
        public CancelamentoOpEncerradaForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (string.IsNullOrWhiteSpace(txtOps.Text))
                {
                    return;
                }

                if (DialogResult.Yes != MessageBox.Show(this, "Deseja continuar com a alteração do status das Ordens de Produção informadas?", "Cancelamento de OP Encerrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                string[] ops = txtOps.Text.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string nOp in ops)
                {
                    long idOp;
                    if (!long.TryParse(nOp,out idOp))
                    {
                        throw new ExcecaoTratada("Número de Ordem de Produção Inválido: " + nOp);
                    }

                    OrdemProducaoClass op = OrdemProducaoClass.GetEntidade(idOp, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                    op.AlterarStatusEncerradoParaCancelado(ref command);
                }

                command.Transaction.Commit();

                MessageBox.Show(this, "Operação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (ExcecaoTratada a)
            {
                command?.Transaction?.Rollback();
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                command?.Transaction?.Rollback();
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
