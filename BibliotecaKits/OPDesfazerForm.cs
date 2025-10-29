#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;

#endregion

namespace ModuloKits
{
    public partial class OPDesfazerForm : IWTBaseForm
    {
        public OPDesfazerForm()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = Configurations.DataIndependenteClass.GetData();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText = "UPDATE order_item_etiqueta SET oie_packinglist_kit_impresso=0, oie_data_impressao_op = NULL WHERE oie_data_impressao_op ='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ";
                command.ExecuteNonQuery();

                MessageBox.Show(this, "Operação concluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao liberar impressão de OP.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
