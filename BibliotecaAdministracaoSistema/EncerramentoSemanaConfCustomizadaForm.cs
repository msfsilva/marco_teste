#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using dbProvider;

#endregion

namespace BibliotecaAdministracaoSistema
{
    public partial class EncerramentoSemanaConfCustomizadaForm : IWTBaseForm
    {
        public EncerramentoSemanaConfCustomizadaForm()
        {
            InitializeComponent();
            this.loadComboSemanas();
        }

        private void loadComboSemanas()
        {
            try
            {
                this.cmbPPS.Items.Clear();
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT distinct(oie_pps) as semana FROM order_item_etiqueta LEFT JOIN codigo_barra ON cob_codigo_item = oie_codigo_item AND cob_dimensao = oie_dimensao WHERE oie_tipo_item=1 AND oie_etiqueta_interna = 1 AND oie_conferencia_customizada_realizada = 0 AND id_codigo_barra IS NOT NULL AND oie_etiqueta_interna_impressa = 1 ORDER BY oie_pps";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    this.cmbPPS.Items.Add(read["semana"].ToString());
                }

                read.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao carregar as semanas.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Você deseja realmente encerrar a conferência de itens customizados para a semana " + this.cmbPPS.SelectedItem + "?", "Encerramento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                    command.CommandText = "UPDATE order_item_etiqueta SET oie_conferencia_customizada_realizada=1, oie_conferencia_customizada_realizada_forcada =1 WHERE oie_pps=" + this.cmbPPS.SelectedItem + " AND oie_conferencia_customizada_realizada=0;";
                    command.ExecuteNonQuery();

                    MessageBox.Show(this, "Semana encerrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao encerrar a semana.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
