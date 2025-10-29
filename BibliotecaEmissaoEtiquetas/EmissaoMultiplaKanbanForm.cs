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
    public partial class EmissaoMultiplaKanbanForm : IWTBaseForm
    {
        BindingSource binding = new BindingSource();
        readonly BindingSource bindTemp = new BindingSource();
        readonly List<ItemQtd> list = new List<ItemQtd>();
        readonly IWTPostgreNpgsqlConnection conn;
        Ref<string> seqInterna;
        readonly string internalLaberPrinter;
        readonly string internalLabelPaper;
        readonly AcsUsuarioClass Usuario;

        public EmissaoMultiplaKanbanForm(ref Ref<string> seqInterna, string internalLaberPrinter, string internalLabelPaper, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            this.conn = conn;
            this.seqInterna = seqInterna;
            this.internalLabelPaper = internalLabelPaper;
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

                string sql =
                    "SELECT    " +
                    "  0 as emitir,   " +
                    "  prk_codigo || ' - ' || prk_dimensao as texto,   " +
                    "  public.produto_k_etiqueta.pke_quantidade_por_etiqueta, " +
                    "  1 as qtd_emitir,   " +
                    "  public.produto_k.prk_codigo,   " +
                    "  public.produto_k.prk_dimensao,   " +
                    "  iwt_agregate_clientes_nf(produto.pro_codigo) as produtos, " +
                    "  iwt_agregate_clientes_nf(public.familia_documento.fad_codigo || public.documento_tipo.dot_identificacao) as documentos   " +
                    "FROM   " +
                    "  public.produto_k    " +
                    "  INNER JOIN public.produto_k_etiqueta ON (public.produto_k.id_produto_k = public.produto_k_etiqueta.id_produto_k) " +
                    "  INNER JOIN public.produto_k_produto ON (public.produto_k.id_produto_k = public.produto_k_produto.id_produto_k) " +
                    "  LEFT OUTER JOIN public.produto ON (public.produto_k_produto.id_produto = public.produto.id_produto)   " +
                    "  LEFT OUTER JOIN public.produto_documento_tipo ON (public.produto.id_produto = public.produto_documento_tipo.id_produto AND public.produto.pro_versao_estrutura_atual = produto_documento_tipo.pdt_versao_estrutura)   " +
                    "  LEFT OUTER JOIN public.documento_tipo_familia ON (public.produto_documento_tipo.id_documento_tipo_familia = public.documento_tipo_familia.id_documento_tipo_familia)   " +
                    "  LEFT OUTER JOIN public.documento_tipo ON (public.documento_tipo_familia.id_documento_tipo = public.documento_tipo.id_documento_tipo)   " +
                    "  LEFT OUTER JOIN public.familia_documento ON (public.documento_tipo_familia.id_familia_documento = public.familia_documento.id_familia_documento)   " +
                    "WHERE   " +
                    "  public.produto_k.prk_ativo = 1 AND   " +
                    "  public.produto_k.prk_imprime_etiqueta = 1   " +
                    "GROUP BY " +
                    "  prk_codigo, " +
                    "  prk_dimensao, " +
                    "  public.produto_k_etiqueta.pke_quantidade_por_etiqueta, " +
                    "  public.produto_k.prk_codigo,   " +
                    "  public.produto_k.prk_dimensao " +
                    "ORDER BY   " +
                    "  prk_codigo,   " +
                    "  prk_dimensao,  " +
                    "  pke_quantidade_por_etiqueta ;";

                adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                
                if (adapter != null)
                {
                    ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    this.dataGridView1.Columns[1].HeaderText = "Agrupador";
                    this.dataGridView1.Columns[1].MinimumWidth = 272;
                    this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[1].ReadOnly = true;
                    this.dataGridView1.Columns[2].HeaderText = "Qtd. por Etiqueta";
                    this.dataGridView1.Columns[2].Width = 50;
                    this.dataGridView1.Columns[2].ReadOnly = true; 
                    this.dataGridView1.Columns[3].HeaderText = "Qtd a Emitir";
                    this.dataGridView1.Columns[3].Width = 80;
                    this.dataGridView1.Columns[4].Visible = false;
                    this.dataGridView1.Columns[5].Visible = false;
                    this.dataGridView1.Columns[6].Visible = false;
                    this.dataGridView1.Columns[7].Visible = false;

                    DataGridViewColumn column = dataGridView1.Columns["emitir"];
                    DataGridViewCheckBoxColumn tmp2 = null;

                    tmp2 = new DataGridViewCheckBoxColumn();
                    tmp2.FalseValue = "0";
                    tmp2.TrueValue = "1";
                    tmp2.DataPropertyName = column.DataPropertyName;

                    tmp2.DisplayIndex = column.DisplayIndex;
                    tmp2.ReadOnly = false;
                    tmp2.Width = 40;
                    tmp2.Name = column.Name;
                    tmp2.HeaderText = "Emitir";
                    dataGridView1.Columns.Remove(tmp2.Name);
                    dataGridView1.Columns.Add(tmp2);             
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados dos pedidos.\r\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ItemQtd itemQtd;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["emitir"].Value.ToString() == "1")
                    {
                        itemQtd = new ItemQtd();
                        itemQtd.codigo = row.Cells["prk_codigo"].Value.ToString();
                        itemQtd.desenho = row.Cells["documentos"].Value.ToString();
                        itemQtd.dimensao = row.Cells["prk_dimensao"].Value.ToString();
                        itemQtd.qtd = Convert.ToInt32(row.Cells["qtd_emitir"].Value);
                        itemQtd.qtdPorEtiqueta = Convert.ToDouble(row.Cells["pke_quantidade_por_etiqueta"].Value);
                        list.Add(itemQtd);                        
                    }                   
                }

                EtiquetaInternaKanbanReportForm form = new EtiquetaInternaKanbanReportForm(list, ref this.seqInterna, internalLaberPrinter, internalLabelPaper, this.conn,this.Usuario);
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

            if (txtProduto.Text != "")
            {
                binding.Filter = " texto LIKE '%" + txtProduto.Text + "%'";
            }
            else
            {
                binding.Filter = "";
            }
            bindTemp.Filter = binding.Filter;
        }

        private void txtPedido_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void txtOC_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        #endregion

        

        
    }

    public class ItemQtd
    {
        public string codigo;
        public string dimensao;
        public string desenho;
        public int qtd;
        public double qtdPorEtiqueta;



    }



    public class Ref<T>
    {
        private readonly Func<T> getter;
        private readonly Action<T> setter;
        public Ref(Func<T> getter, Action<T> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }
        public T Value
        {
            get { return getter(); }
            set { setter(value); }
        }
    }

}
