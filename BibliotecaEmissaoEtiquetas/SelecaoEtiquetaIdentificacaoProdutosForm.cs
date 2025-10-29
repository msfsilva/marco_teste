#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEmissaoEtiquetas
{
    public partial class SelecaoEtiquetaIdentificacaoProdutosForm : IWTBaseForm
    {

        BindingSource binding = new BindingSource();
        BindingSource bindTemp = new BindingSource();
        readonly List<ItemQtdEtiquetaIdentificacao> list = new List<ItemQtdEtiquetaIdentificacao>();
        readonly IWTPostgreNpgsqlConnection conn;
        readonly string internalLaberPrinter;
        readonly string internalLabelPaper;
        private readonly byte[] logoEmpresa;
        readonly AcsUsuarioClass Usuario;
        

        public SelecaoEtiquetaIdentificacaoProdutosForm(string internalLaberPrinter, string internalLabelPaper, byte[] _logoEmpresa, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            this.conn = conn;
            this.internalLabelPaper = internalLabelPaper;
            this.logoEmpresa = _logoEmpresa;
            this.internalLaberPrinter = internalLaberPrinter;
            this.Usuario = Usuario;
            InitializeGrid();          
        }      

        private void InitializeGrid()
        {
            try
            {
                IWTPostgreNpgsqlAdapter adapter;
                DataSet ds;

                string whereClause = "";

                if (this.txtProduto.Text.Trim().Length > 0)
                {
                    whereClause = " WHERE UPPER(pro_codigo) LIKE '%" + this.txtProduto.Text.Trim().ToUpper() + "%' OR " +
                                    " UPPER(pro_descricao) LIKE '%" + this.txtProduto.Text.Trim().ToUpper() + "%' OR " +
                                    " UPPER(clp_identificacao) LIKE '%" + this.txtProduto.Text.Trim().ToUpper() + "%' OR "+
                                    " LOWER(pro_codigo) LIKE '%" + this.txtProduto.Text.Trim().ToLower() + "%' OR " +
                                    " LOWER(pro_descricao) LIKE '%" + this.txtProduto.Text.Trim().ToLower() + "%' OR " +
                                    " LOWER(clp_identificacao) LIKE '%" + this.txtProduto.Text.Trim().ToLower() + "%' ";
                }

                string sql =
                    "SELECT  " +
                    "  public.produto.id_produto, " +
                    "  0 as emitir, " +
                    "  public.produto.pro_codigo, " +
                    "  public.produto.pro_descricao, " +
                    "  public.classificacao_produto.clp_identificacao, " +
                    "  1 as qtd_por_etiqueta, " +
                    "  1 as qtd_emitir, " +
                    "  pro_codigo_cliente, " +
                    "  '' as observacao, " +
                    "  pro_gtin " +
                    "FROM " +
                    "  public.produto " +
                    "  LEFT JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) " +
                    " " + whereClause + " " +
                    "ORDER BY " +
                    "  public.produto.pro_codigo ";

                adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                
                if (adapter != null)
                {
                    ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    this.dataGridView1.Columns[0].Visible = false;

                    this.dataGridView1.Columns[1].HeaderText = "Emitir";
                    this.dataGridView1.Columns[1].Width = 50;

                    this.dataGridView1.Columns[2].HeaderText = "Código Interno";
                    this.dataGridView1.Columns[2].Width = 150;
                    this.dataGridView1.Columns[2].ReadOnly = true;
                    this.dataGridView1.Columns[3].HeaderText = "Descrição";
                    this.dataGridView1.Columns[3].Width = 150;
                    this.dataGridView1.Columns[3].ReadOnly = true;
                    this.dataGridView1.Columns[4].HeaderText = "Classificação";
                    this.dataGridView1.Columns[4].Width = 150;
                    this.dataGridView1.Columns[4].ReadOnly = true;

                    this.dataGridView1.Columns[5].HeaderText = "Qtd por Etiqueta";
                    this.dataGridView1.Columns[5].Width = 50;
                    this.dataGridView1.Columns[5].ReadOnly = true;

                    this.dataGridView1.Columns[6].HeaderText = "Qtd a Emitir";
                    this.dataGridView1.Columns[6].Width = 50;
                    
                    this.dataGridView1.Columns[7].Visible = false;

                    this.dataGridView1.Columns[8].HeaderText = "Observações";
                    this.dataGridView1.Columns[8].Width = 150;
                    ((DataGridViewTextBoxColumn) this.dataGridView1.Columns[8]).MaxInputLength = 40;

                    this.dataGridView1.Columns[9].Visible = false;



                    DataGridViewColumn column = dataGridView1.Columns["emitir"];
                    DataGridViewCheckBoxColumn tmp = null;

                    tmp = new DataGridViewCheckBoxColumn();
                    tmp.FalseValue = "0";
                    tmp.TrueValue = "1";
                    tmp.DataPropertyName = column.DataPropertyName;
                    tmp.DisplayIndex = column.DisplayIndex;
                    tmp.ReadOnly = column.ReadOnly;
                    tmp.AutoSizeMode = column.AutoSizeMode;
                    tmp.Width = column.Width;
                    tmp.Name = column.Name;
                    tmp.HeaderText = column.HeaderText;
                    dataGridView1.Columns.Remove(tmp.Name);
                    dataGridView1.Columns.Add(tmp);         
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados dos produtos.\r\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }     

        #region eventos

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
        private void btnOk_Click(object sender, EventArgs e)
        {           
            try
            {
                ItemQtdEtiquetaIdentificacao itemQtd;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["emitir"].Value.ToString() == "1")
                    {
                        itemQtd = new ItemQtdEtiquetaIdentificacao();
                        itemQtd.Codigo = row.Cells["pro_codigo"].Value.ToString();
                        itemQtd.codigoCliente = row.Cells["pro_codigo_cliente"].Value.ToString();
                        itemQtd.qtdEtiquetas = Convert.ToInt32(row.Cells["qtd_emitir"].Value);
                        itemQtd.idProduto = Convert.ToInt32(row.Cells["id_produto"].Value);
                        itemQtd.Descricao = row.Cells["pro_descricao"].Value.ToString();
                        itemQtd.observacao = row.Cells["observacao"].Value.ToString();
                        itemQtd.Gtin = row.Cells["pro_gtin"].Value.ToString();
                        itemQtd.Usuario = this.Usuario.Login;
                        itemQtd.qtdPorEtiquetas = Convert.ToInt32(row.Cells["qtd_por_etiqueta"].Value);
                        list.Add(itemQtd);
                    }
                }
                EtiquetaIdentificacaoProdutosReportForm form = new EtiquetaIdentificacaoProdutosReportForm(list, internalLaberPrinter, internalLabelPaper,this.logoEmpresa, this.conn);
                form.ShowDialog();
                this.Close();
            }
            catch (Exception a)
            {        
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                binding.Sort = "emitir DESC";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.InitializeGrid();
        }

        private void txtPedido_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        #endregion
    }

    public class ItemQtdEtiquetaIdentificacao
    {

        public int idProduto { get; set; }
        public string Codigo { get; set; }
        public string codigoCliente { get; set; }
        public string Descricao { get; set; }
        public int qtdEtiquetas { get; set; }
        public int qtdPorEtiquetas { get; set; }
        public byte[] barcode { get; set; }
        public string barcodeTexto { get; set; }
        public string Usuario { get; set; }
        public int nEtiqueta { get; set; }
        public string observacao { get; set; }
        public string Gtin { get; set; }

        public byte[] logoEmpresa { get; set; }

    }

}
