using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaQualidade
{
    public partial class ObsolescenciaRelatForm : IWTBaseForm
    {
        IWTPostgreNpgsqlConnection conn;
        public ObsolescenciaRelatForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

         private void Gerar()
         {
             try
             {
                 if (string.IsNullOrEmpty(this.maskedTextBox1.Text) )
                 {
                     throw new Exception("Preecha o campo de mês e ano");
                 }

                 string[] tmp = this.maskedTextBox1.Text.Split(new string[]{"/"},StringSplitOptions.RemoveEmptyEntries);
                 if (tmp.Length!=2)
                 {
                     throw new Exception("Dados inválidos");
                 }

                 int mes = Convert.ToInt32(tmp[0]);
                 int ano = Convert.ToInt32(tmp[1]);
                 if (mes>12)
                 {
                     throw new Exception("Mês Inválido");
                 }

                 ObsolescenciaRelatClass dataClass = new ObsolescenciaRelatClass(this.conn);
                 dataClass.Gerar(mes,ano);

                 ObsolescenciaRelatReport rep = new ObsolescenciaRelatReport();
                 rep.SetDataSource(dataClass.Itens);
                 rep.SetParameterValue("intervaloData",this.maskedTextBox1.Text);

                 this.crystalReportViewer1.ReportSource = rep;

             }
             catch (Exception e)
             {
                 throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
             }
         }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Gerar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
