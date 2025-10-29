#region Referencias

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCompras;
using BibliotecaEntidades.Operacoes.Compras;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaPontosControle
{
    public partial class PontoControleLoteMateriaForm : IWTBaseForm
    {
        public Dictionary<int, LoteClass> Lotes { get; private set; }
        readonly AcsUsuarioClass Usuario;
        readonly IWTPostgreNpgsqlConnection conn;
        public PontoControleLoteMateriaForm(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.Usuario = Usuario;
            this.conn = conn;

            this.Lotes = new Dictionary<int, LoteClass>();


            this.initializeGrid();
        }

        private void loadBarcode()
        {
            try
            {
                if (this.txtBarcode.Text.Trim().Length==0)
                {
                    return;    
                }

                string barcode = this.txtBarcode.Text.Trim().Replace("\r", "").Replace("\n", "").Replace('}', '|');

                string[] tmp = barcode.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (tmp.Length == 2 && tmp[0] == "LT")
                {
                    int idLote = Convert.ToInt32(tmp[1]);

                    if (!this.Lotes.ContainsKey(idLote))
                    {
                        this.Lotes.Add(idLote, new LoteClass(idLote, this.Usuario, this.conn));
                    }
                    else
                    {
                        throw new Exception("O lote já foi adicionado");
                    }

                }
                else
                {
                    throw new Exception("Código de barras inválido");
                }
                this.txtBarcode.Text = "";
                this.initializeGrid();

            }
            catch (Exception e)
            {
                this.txtBarcode.Text = "";
                throw new Exception("Erro ao carregar o lote a partir do código de barras.\r\n" + e.Message, e);
            }
        }

        private void initializeGrid()
        {
            try
            {
               

                dataGridView1.Columns.Clear();

                dataGridView1.AutoGenerateColumns = false;


                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Numero";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "Numero";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Lote";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "MaterialProduto";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "MaterialProduto";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Item";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                dataGridView1.DataSource = new List<LoteClass>(this.Lotes.Values);

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o grid.\r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                this.loadBarcode();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void PontoControleLoteMateriaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.Lotes == null || this.Lotes.Count == 0)
                {
                    e.Cancel = true;
                    throw new Exception("Carregue pelo menos um lote de matéria prima antes de continuar.");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
