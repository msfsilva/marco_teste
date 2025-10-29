using System;
using System.Diagnostics;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaExportacaoDados
{

    public partial class ExportarContasCSVForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public ExportarContasCSVForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Exportar()
        {
            try
            {

                if (this.textBox1.Text.Trim().Length == 0)
                {
                    throw new Exception("Selecione o diretório de saída para o arquivo gerado.");
                }

                ExportContasCSV exp = new ExportContasCSV(this.conn);

                DateTime? dataInicio = null;
                if (this.dtpDataInicio.Enabled)
                {
                    dataInicio = this.dtpDataInicio.Value;
                }

                DateTime? dataFim = null;
                if (this.dtpDataFim.Enabled)
                {
                    dataFim = this.dtpDataFim.Value;
                }


                TipoContaExportCSV tipo = TipoContaExportCSV.Todas;
                if (this.rdbPagar.Checked)
                {
                    tipo = TipoContaExportCSV.Pagar;
                }
                if (this.rdbReceber.Checked)
                {
                    tipo = TipoContaExportCSV.Receber;
                }

                BaixadasContaExportCSV baixados = BaixadasContaExportCSV.Todas;
                if (this.rdbSituacaoAbertas.Checked)
                {
                    baixados = BaixadasContaExportCSV.Abertas;
                }

                if (this.rdbSituacaoPagas.Checked)
                {
                    baixados = BaixadasContaExportCSV.Pagas;
                }

                string arquivo = exp.gerarCSV(dataInicio, dataFim, tipo, baixados, this.textBox1.Text);

                if (MessageBox.Show(this, "O arquivo foi gerado com sucesso, deseja visualiza-lo agora?", "Abrir arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process pr = new Process();
                    pr.StartInfo.FileName = arquivo;
                    pr.Start();
                }

            }
            catch (Exception e)
            {

                throw new Exception("Erro ao gerar o arquivo de exportação.\r\n" + e.Message);
            }
        }

        #region Eventos

        private void chkDataInicio_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDataInicio.Enabled = chkDataInicio.Checked;
        }

        private void chkDataFim_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDataFim.Enabled = chkDataFim.Checked;
        }

        private void btnDiretorioSaida_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Exportar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
