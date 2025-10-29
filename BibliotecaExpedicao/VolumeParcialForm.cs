#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;

#endregion

namespace BibliotecaExpedicao
{
    public partial class VolumeParcialForm : IWTBaseForm
    {
        int qtdVolumes;
        readonly double qtdItens;
        internal SortedList<int, Volume> volumes;
        int numeroVolumeSelecionado = -1;
        private bool atualizando = false;

        public bool abort = false;

        private double totalItensNosVolumes
        {
            get
            {
                double toRet = 0;
                if (this.volumes != null)
                {
                    foreach (Volume vol in this.volumes.Values)
                    {
                        toRet += vol.Qtd;
                    }
                }

                return toRet;
            }
        }


        public VolumeParcialForm(int qtdVolumes, double qtdItens, string pedido, string cliente, string item, string cubagemM3)
        {
            InitializeComponent();
            this.qtdVolumes = qtdVolumes;
            this.qtdItens = qtdItens;
            this.nudQtdVolumes.Value = qtdVolumes;
            this.criaVolumes();
            this.loadGrid();

            this.nudTotalItensAtual.Value = (decimal)qtdItens;

            this.lblCliente.Text = cliente;
            this.lblItem.Text = item;
            this.lblPedido.Text = pedido;
            this.lblCubagem.Text = cubagemM3;

        }

        private void criaVolumes()
        {
            this.volumes = new SortedList<int, Volume>();
            double tmp = this.qtdItens / this.qtdVolumes;
            int qtdPorVolume = Convert.ToInt32(Math.Round(tmp));
            int itensAlocados = 0;
            int i = 2;
            for (; i <= this.qtdVolumes; i++)
            {
                this.volumes.Add(i, new Volume(i, qtdPorVolume));
                itensAlocados += qtdPorVolume;
            }

            this.volumes.Add(1, new Volume(1, this.qtdItens - itensAlocados));

        }

        private void loadGrid()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add(new DataColumn("numVolume", Type.GetType("System.Int32")));
            ds.Tables[0].Columns.Add(new DataColumn("qtdVolume", Type.GetType("System.Double")));

            DataRow row;
            foreach (Volume vol in this.volumes.Values)
            {
                row = ds.Tables[0].NewRow();
                row["numVolume"] = vol.NumeroVolume;
                row["qtdVolume"] = vol.Qtd;
                ds.Tables[0].Rows.Add(row);
            }

            #region Salvando Posição do Grid
            int scrollIndex = 0;
            if (this.dataGridView1.FirstDisplayedScrollingRowIndex > 0)
            {
                scrollIndex = this.dataGridView1.FirstDisplayedScrollingRowIndex;
            }

            int selectRowIndex = 0;
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selectRowIndex = this.dataGridView1.SelectedRows[0].Index;
            }
            #endregion

            BindingSource binding = new BindingSource();
            binding.DataSource = ds.Tables[0];

            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = binding;

            this.dataGridView1.Columns[0].HeaderText = "Nº volume";
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[1].HeaderText = "Qtd";
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.nudQtdTotalItens.Value = (decimal)this.totalItensNosVolumes;

            #region Restaurando Posição do Grid
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                this.dataGridView1.SelectedRows[i].Selected = false;
            }
            if (this.dataGridView1.Rows.Count > 0)
            {
                while (selectRowIndex > 0 && selectRowIndex >= this.dataGridView1.Rows.Count)
                {
                    selectRowIndex--;
                }


                this.dataGridView1.Rows[selectRowIndex].Selected = true;

                while (scrollIndex > 0 && scrollIndex >= this.dataGridView1.Rows.Count)
                {
                    scrollIndex--;
                }

                this.dataGridView1.FirstDisplayedScrollingRowIndex = scrollIndex;
            }
            #endregion
        }

        private bool Sair()
        {
            if (!this.abort)
            {
                if (Math.Round(this.totalItensNosVolumes,4) != this.qtdItens)
                {
                    MessageBox.Show(this, "Não é possível continuar enquanto a quantidade de itens nos volumes não for igual a " + this.qtdItens.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }
                else
                {
                    return true;
                    this.abort = false;
                }
            }
            else
            {
                return true;
            }
        }

        private void AlterarQuantidadeVolumes()
        {
            if (this.nudQtdVolumes.Value == this.qtdVolumes) return;
            if (this.nudQtdVolumes.Value > this.qtdVolumes)
            {
                //Aumentando
                for (int i = this.volumes.Count+1; i <= this.nudQtdVolumes.Value; i++)
                {
                    this.volumes.Add(i, new Volume(i, 0));
                }
               
            }
            else
            {
                //Diminuindo
                List<int> chavesVolumes = new List<int>(this.volumes.Keys);
                foreach (int volume in chavesVolumes)
                {
                    if (volume > this.nudQtdVolumes.Value)
                    {
                        this.volumes.Remove(volume);
                    }
                }
            }
            this.qtdVolumes = (int)this.nudQtdVolumes.Value;
            
            this.loadGrid();
            
        }

        #region Eventos
        private void nudQtdItens_ValueChanged(object sender, EventArgs e)
        {
            if (this.numeroVolumeSelecionado != -1 && !this.atualizando)
            {
                this.volumes[this.numeroVolumeSelecionado].Qtd = (double)this.nudQtdItens.Value;
                this.nudQtdTotalItens.Value = (decimal)this.totalItensNosVolumes;
                this.loadGrid();
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.abort = false;
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                this.atualizando = true;

                Volume vol = this.volumes[Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value)];
                this.nudQtdItens.Value = (decimal)vol.Qtd;
                this.numeroVolumeSelecionado = vol.NumeroVolume;
                this.atualizando = false;
                this.nudNumeroVolume.Value = this.numeroVolumeSelecionado;
            }
        }

        private void nudNumeroVolume_ValueChanged(object sender, EventArgs e)
        {
            if (this.atualizando == false)
            {
                this.atualizando = true;
                for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                {
                    this.dataGridView1.SelectedRows[i].Selected = false;
                }

                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dataGridView1.Rows[i].Cells[0].Value) == this.nudNumeroVolume.Value)
                    {
                        this.atualizando = false;
                        this.dataGridView1.Rows[i].Selected = true;
                    }
                }

                if (atualizando == true)
                {
                    this.atualizando = false;
                    this.dataGridView1.Rows[0].Selected = true;
                }
            }
        }


        private void VolumeParcialForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.Sair();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.abort = true;
            this.Close();
        }



        private void nudQtdVolumes_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.AlterarQuantidadeVolumes();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }

    public class Volume
    {
        public int NumeroVolume { get; private set; }
        public double Qtd { get; internal set; }
        public double Peso { get; private set; }
        public string Cubagem { get; private set; }

        public Volume(int numeroVolume, double Qtd)
        {
            this.NumeroVolume = numeroVolume;
            this.Qtd = Qtd;
        }

        public void setPesoCubagem(double peso, string cubagem)
        {
            this.Peso = peso;
            this.Cubagem = cubagem;
        }
    }
}
