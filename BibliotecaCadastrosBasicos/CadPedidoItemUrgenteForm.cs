using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemUrgenteForm : IWTBaseForm
    {
        private readonly List<PedidoItemClass> _pedidos;

        public CadPedidoItemUrgenteForm(List<PedidoItemClass> pedidos )
        {
            InitializeComponent();
            _pedidos = pedidos;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (MessageBox.Show(this, "Deseja salvar as informações de Urgência para todos os pedidos selecionados?", "Alteração de Urgência", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                UrgenciaPedido urgente = UrgenciaPedido.Normal;
                if (rdbUrgenteAntecipacao.Checked)
                {
                    urgente = UrgenciaPedido.Antecipacao;
                }

                if (rdbUrgenteAntecipacao.Checked)
                {
                    urgente = UrgenciaPedido.Antecipacao;
                }

                if (rdbUrgenteCritico.Checked)
                {
                    urgente = UrgenciaPedido.Critico;
                }

                if (rdbUrgenteUrgente.Checked)
                {
                    urgente = UrgenciaPedido.Urgente;
                }
                string solicitante = txtUrgenteSolicitante.Text.Trim();
                string infos = txtUrgenteInfos.Text.Trim();
                DateTime dataPrometida = dtpUrgenteData.Value;


                foreach (PedidoItemClass pedido in _pedidos)
                {

                    pedido.Urgente = urgente;
                    pedido.UrgenteDataPrometida = dataPrometida;
                    pedido.UrgenteInformacoesComplementares = infos;
                    pedido.UrgenteSolicitante = solicitante;

                    pedido.Save(ref command);
                    pedido.SalvarJustificativa(command);

                }

                command.Transaction.Commit();


                this.Close();
            }
            catch (Exception a)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao incluir o novo feedback no pedido\r\n" + a.Message, a);
            }
        }

        private void rdbUrgenteNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;
        }

        private void rdbUrgenteAntecipacao_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;
        }

        private void rdbUrgenteUrgente_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;

        }

        private void rdbUrgenteCritico_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;

        }
    }
}
