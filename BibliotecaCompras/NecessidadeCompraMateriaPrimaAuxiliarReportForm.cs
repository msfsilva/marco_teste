#region Referencias

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCompras
{
    public partial class NecessidadeCompraMateriaPrimaAuxiliarReportForm : IWTBaseForm
    {
        readonly NecessidadeMateriaPrima necMp;
        public NecessidadeCompraMateriaPrimaAuxiliarReportForm(DateTime Fim,List<int> idsAgrupadores,string tipoCalculoSemana,string diaCalculoSemana, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.necMp = new NecessidadeMateriaPrima(Fim, idsAgrupadores, tipoCalculoSemana, diaCalculoSemana, conn);

        }

        private void NecessidadeCompraMateriaPrimaAuxiliarReportFormForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.necMp.Start();

                if (this.necMp.ItensRelatorio.Count > 0)
                {
                    NecessidadeManteriaPrimaAuxiliarReport rep = new NecessidadeManteriaPrimaAuxiliarReport();
                    rep.SetDataSource(this.necMp.ItensRelatorio.Values);

                    this.crystalReportViewer1.ReportSource = rep;
                    this.crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show(this, "Erro ao gerar o relatório, não existem itens para serem gerados.", "Não existem itens", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void NecessidadeCompraMateriaPrimaAuxiliarReportFormForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.necMp != null && this.necMp.ItensRelatorio.Count > 0)
                {
                    DialogResult res = MessageBox.Show(this, "Você deseja salvar a baixa dos itens do relatório?", "Baixa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    switch (res)
                    {
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        case DialogResult.Yes:
                            this.necMp.saveReport();
                            break;
                    }
                }
            }
            catch (Exception a)
            {
                e.Cancel = true;
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
