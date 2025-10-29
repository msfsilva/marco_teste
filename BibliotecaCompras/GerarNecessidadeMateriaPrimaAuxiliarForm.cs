#region Referencias

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaCompras
{
    public partial class GerarNecessidadeMateriaPrimaAuxiliarForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        public GerarNecessidadeMateriaPrimaAuxiliarForm(string tipoCalculoSemana,string diaCalculoSemana,IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.initializeListAgrupadores();
        }

        private void initializeListAgrupadores()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.agrupador_material.id_agrupador_material, "+
                    "  public.agrupador_material.agm_identificacao, "+
                    "  public.agrupador_material.agm_descricao "+
                    "FROM "+
                    "  public.agrupador_material "+
                    "ORDER BY "+
                    "  public.agrupador_material.agm_identificacao, "+
                    "  public.agrupador_material.agm_descricao ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    agrupadorMaterial tmp = new agrupadorMaterial()
                    {
                        idAgrupador = Convert.ToInt32(read["id_agrupador_material"]),
                        Identificacao = read["agm_identificacao"].ToString(),
                        Descricao = read["agm_descricao"].ToString()
                    };

                    this.livAgrupadores.Items.Add(tmp.ToString());
                    this.livAgrupadores.Items[this.livAgrupadores.Items.Count - 1].SubItems.Add(tmp.Descricao);
                    this.livAgrupadores.Items[this.livAgrupadores.Items.Count - 1].Tag = tmp;


                }
                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados dos agrupadores.\r\n" + e.Message);
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> idsAgrupadores = null;

                if (livAgrupadores.Enabled)
                {
                    if (livAgrupadores.SelectedItems.Count > 0)
                    {
                        idsAgrupadores = new List<int>();
                        foreach (ListViewItem agr in this.livAgrupadores.SelectedItems)
                        {
                            idsAgrupadores.Add(((agrupadorMaterial)agr.Tag).idAgrupador);
                        }
                    }
                    else
                    {
                        throw new Exception("Selecione ao menos um agrupador para gerar o relatório.");
                    }
                }

                NecessidadeCompraMateriaPrimaAuxiliarReportForm form = new NecessidadeCompraMateriaPrimaAuxiliarReportForm(this.dtpFim.Value,
                    idsAgrupadores,
                    this.tipoCalculoSemana, this.diaCalculoSemana, this.conn);
                form.ShowDialog();
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao gerar o relatório.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTodosAgrupadores_CheckedChanged(object sender, EventArgs e)
        {
            this.livAgrupadores.Enabled = !this.chkTodosAgrupadores.Checked;
        }
    }

    internal class agrupadorMaterial
    {
        public int idAgrupador { get; set; }
        public string Identificacao { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return this.Identificacao;
        }

    }
}
