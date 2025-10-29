#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;

#endregion

namespace BibliotecaCNC
{
    public partial class CNCForm : IWTBaseForm
    {
        
        DataSet dataSet;
        private ItemCNC itemAtivo = null;
        private bool updatingItem= false;
        private bool updatingCNC = false;
        private bool updatingDimensao = false;
        private bool updatingClassificacao = false;

        readonly SortedList<string, bool> itensItem = new SortedList<string, bool>();
        //readonly SortedList<int, bool> itensDimensao = new SortedList<int, bool>(); #Alteração Marcelo
        readonly SortedList<string, bool> itensDimensao = new SortedList<string, bool>();
        readonly SortedList<string, bool> itensCNC = new SortedList<string, bool>();
        readonly SortedList<string, bool> itensClassificacao = new SortedList<string, bool>();


        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;
        private readonly byte[] logoEmpresa;

        private bool ordenadoDimensao = false;
        private bool ordenadoDimensaoAsc = false;


        private bool ordenadoPPSAtual = false;
        private bool ordenadoPPSAtualAsc = false;

        private string _tipoCalculoSemana;
        private string _diaCalculoSemana;


        public CNCForm(byte[] logo, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            this.conn = conn;
            this.Usuario = Usuario;
            this.txtEditProgramador.Text = this.Usuario.Login;

            _tipoCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO);
            _diaCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA);

            #region Logo

            logoEmpresa = logo;

            if (logoEmpresa != null)
            {
                MemoryStream ms = new MemoryStream(logoEmpresa);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                logoEmpresa = ms.ToArray();
            }


            #endregion


            this.initializeGrid();
            this.loadComboItem();
            this.loadComboCNC();
            this.loadComboDimensao();
            this.loadComboClassificacao();
        }

        private void loadComboClassificacao()
        {
            if (!updatingClassificacao)
            {
                updatingClassificacao = true;
                string oldClasssificacao = "";
                if (cmbClassificacao.SelectedItem != null && cmbClassificacao.SelectedItem.ToString().Trim().Length > 0)
                {
                    oldClasssificacao = cmbClassificacao.SelectedItem.ToString();
                }

                itensClassificacao.Clear();
                for (int i = 0; i < this.dataSet.Tables[0].Rows.Count; i++)
                {
                    if (!itensClassificacao.ContainsKey(this.dataSet.Tables[0].Rows[i]["clp_identificacao"].ToString()))
                    {
                        itensClassificacao.Add(this.dataSet.Tables[0].Rows[i]["clp_identificacao"].ToString(), true);
                    }
                }

                cmbClassificacao.Items.Clear();
                foreach (string item in itensClassificacao.Keys)
                {
                    cmbClassificacao.Items.Add(item);
                }
                if (oldClasssificacao.Length > 0)
                {
                    cmbClassificacao.SelectedItem = oldClasssificacao;
                }
                updatingClassificacao = false;
            }
        }

        private void initializeGrid()
        {
            IWTPostgreNpgsqlAdapter adapter;
            
            try
            {

                string sql = MontaQueryTela();

                BindingSource binding = new BindingSource();

                adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                  
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Classificacao", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Ordem", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Pos", 45, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Sublinha", 55, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "PPS", 50, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Data Entrega Atual", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "PPS - Entrega Atual", 50, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Item", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Medida", 65, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Quantidade", 65, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Programa CNC", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[12], "Coordenada X", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[13], "Coordenada Y", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[14], "Usuário", 100, DataGridViewAutoSizeColumnMode.None, true);
                    dataGridView1.Columns[15].Visible = false;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].Visible = false;

                    this.lblTotalItens.Text = "Total de Itens: " + this.dataSet.Tables[0].Rows.Count;
                }

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    DateTime? dataAtualEntrega = row["pei_data_entrega"] as DateTime?;
                    if (dataAtualEntrega.HasValue)
                    {
                        int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(dataAtualEntrega.Value, _tipoCalculoSemana, _diaCalculoSemana);
                        row["pps_atual"] = Convert.ToInt32(dataAtualEntrega.Value.ToString("yy") + weekNum.ToString().PadLeft(2, '0'));
                    }
                }

                if (nudPPSAtual.Enabled)
                {
                    binding.Filter = " pps_atual LIKE '" + nudPPSAtual.Value+"'";
                }
                else
                {
                    binding.Filter = "";
                }
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private string MontaQueryTela()
        {
            string searchClause = GerarSearch();


            if (!string.IsNullOrWhiteSpace(searchClause))
            {
                searchClause = " AND " + searchClause;
            }

            string ordenacaoDimensao = "";
            if (this.ordenadoDimensao)
            {
                string tipo = "ASC";
                if (!ordenadoDimensaoAsc)
                {
                    tipo = "DESC";
                }

                //Alteração Marcelo
                //ordenacaoDimensao = " CASE WHEN \"isNumber\"(order_item_etiqueta.oie_dimensao) THEN CAST(order_item_etiqueta.oie_dimensao AS DOUBLE PRECISION) ELSE 999999999 END " + tipo + ", order_item_etiqueta.oie_dimensao, ";
                ordenacaoDimensao = " CASE WHEN \"isNumber\"(translate(order_item_etiqueta.oie_dimensao,'/*+!@#$%', 'ssssssss')) THEN CAST(order_item_etiqueta.oie_dimensao AS DOUBLE PRECISION) ELSE 999999999 END " + tipo + ", order_item_etiqueta.oie_dimensao, ";

            }

            string orderByPpsAtual = "";
            if (this.ordenadoPPSAtual)
            {
                string tipo = "ASC";
                if (!ordenadoPPSAtualAsc)
                {
                    tipo = "DESC";
                }

                orderByPpsAtual = " public.pedido_item.pei_data_entrega " + tipo + ", ";

            }


            string sql =
                "SELECT                                                                                                           " +
                "  public.order_item_etiqueta.id_order_item_etiqueta,                                                             " +
                "  public.classificacao_produto.clp_identificacao, " +
                "  public.order_item_etiqueta.oie_order_number,                                                                   " +
                "  public.order_item_etiqueta.oie_order_pos,                                                                      " +
                "  public.order_item_etiqueta.oie_nivel_item,                                                                     " +
                "  public.order_item_etiqueta.oie_pps,                                                                            " +
                "  public.pedido_item.pei_data_entrega, "+
                "  '' as pps_atual, "+
                "  public.order_item_etiqueta.oie_codigo_item,                                                                 " +
                "  public.order_item_etiqueta.oie_dimensao,                                                                       " +
                "  public.order_item_etiqueta.oie_qtd_etiquetas,                                                                  " +
                "  public.order_item_etiqueta.oie_cnc,                                                                            " +
                "  public.order_item_etiqueta.oie_coordenada_x,                                                                   " +
                "  public.order_item_etiqueta.oie_coordenada_y,                                                                   " +
                "  public.order_item_etiqueta.oie_programador,                                                                     " +
                "  public.order_item_etiqueta.oie_saf, "+
                "  public.order_item_etiqueta.oie_tipo_baseboard, " +
                "  pedido_kit.pek_tipo_kit " +
                "FROM                                                                                                             " +
                "  public.order_item_etiqueta                                                                                     " +
                "  LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = public.pedido_kit.pek_oc)  " +
                "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_kit.pek_pos)                                     " +
                "  LEFT OUTER JOIN public.kit_tipo_kit ON (public.pedido_kit.pek_tipo_kit = public.kit_tipo_kit.pek_tipo_kit)     " +
                "  LEFT OUTER JOIN public.order_item_etiqueta oie2 ON (oie2.oie_order_number=order_item_etiqueta.oie_order_number AND oie2.oie_order_pos=order_item_etiqueta.oie_order_pos AND oie2.oie_nota_fiscal=1)     " +
                "  LEFT JOIN produto ON order_item_etiqueta.id_produto = produto.id_produto " +
                "  LEFT JOIN classificacao_produto ON produto.id_classificacao_produto = classificacao_produto.id_classificacao_produto " +
                "  LEFT JOIN pedido_item ON (order_item_etiqueta.id_pedido_item_linha_principal_pedido = pedido_item.id_pedido_item) " +
                "WHERE                                                                                                            " +
                "  public.order_item_etiqueta.oie_tipo_item = 1 AND                                                               " +
                "  public.order_item_etiqueta.oie_etiqueta_interna_impressa = 0 AND                                               " +
                "  public.order_item_etiqueta.oie_etiqueta_interna = 1 AND                                                        " +
                "  (oie2.oie_status_pedido='P' OR oie2.oie_status_pedido='R')         " +
                " " + searchClause + " " +
                "ORDER BY                                                                                                         " +
                " " + ordenacaoDimensao + " " +
                " " + orderByPpsAtual + " "+
                "  public.classificacao_produto.clp_identificacao, " +
                "  public.kit_tipo_kit.ktk_sequencia,                                                                             " +
                "  public.kit_tipo_kit.pek_tipo_kit,                                                                              " +
                "  public.pedido_item.pei_data_entrega                                                                             ";

            return sql;


        }

        private void OrdenarDimensao()
        {
            this.ordenadoDimensao = true;
            this.ordenadoDimensaoAsc = !this.ordenadoDimensaoAsc;
            this.initializeGrid();
        }

        private void OrdenarPPSAtual()
        {
            this.ordenadoPPSAtual = true;
            this.ordenadoPPSAtualAsc = !this.ordenadoPPSAtualAsc;
            this.initializeGrid();
        }

        private void loadComboItem()
        {
            if (!updatingItem)
            {
                updatingItem = true;
                string oldItem = "";
                if (cmbItem.SelectedItem != null && cmbItem.SelectedItem.ToString().Trim().Length > 0)
                {
                    oldItem = cmbItem.SelectedItem.ToString();
                }

                itensItem.Clear();
                for (int i = 0; i < this.dataSet.Tables[0].Rows.Count; i++)
                {
                    if (!itensItem.ContainsKey(this.dataSet.Tables[0].Rows[i]["oie_codigo_item"].ToString()))
                    {
                        itensItem.Add(this.dataSet.Tables[0].Rows[i]["oie_codigo_item"].ToString(), true);
                    }
                }

                cmbItem.Items.Clear();

                foreach (string item in itensItem.Keys)
                {
                    cmbItem.Items.Add(item);
                }

                if (oldItem.Length > 0)
                {
                    cmbItem.SelectedItem = oldItem;
                }
                updatingItem = false;
            }
        }

        private void loadComboDimensao()
        {
            if (!updatingDimensao)
            {
                updatingDimensao = true;
                string oldDimensao = "";
                if (cmbDimensao.SelectedItem != null && cmbDimensao.SelectedItem.ToString().Trim().Length > 0)
                {
                    oldDimensao = cmbDimensao.SelectedItem.ToString();
                }

                itensDimensao.Clear();
                for (int i = 0; i < this.dataSet.Tables[0].Rows.Count; i++)
                {
                    /* #Alteração Marcelo
                    if (!itensDimensao.ContainsKey(Convert.ToInt32(this.dataSet.Tables[0].Rows[i]["oie_dimensao"])))
                    {
                        itensDimensao.Add(Convert.ToInt32(this.dataSet.Tables[0].Rows[i]["oie_dimensao"]), true);
                    }
                    */
                    if (!itensDimensao.ContainsKey(this.dataSet.Tables[0].Rows[i]["oie_dimensao"].ToString()))
                    {
                        itensDimensao.Add(this.dataSet.Tables[0].Rows[i]["oie_dimensao"].ToString(), true);
                    }

                }

                cmbDimensao.Items.Clear();
                /* #alteração Marcelo
                foreach (int item in itensDimensao.Keys)
                {
                    cmbDimensao.Items.Add(item.ToString());
                }
                */
                foreach (string item in itensDimensao.Keys)
                {
                    cmbDimensao.Items.Add(item);
                }



                if (oldDimensao.Length > 0)
                {
                    cmbDimensao.SelectedItem = oldDimensao;
                }
                updatingDimensao = false;

            }
        }

        private void loadComboCNC()
        {

            if (!updatingCNC)
            {
                updatingCNC = true;
                string oldCNC = "";
                if (cmbCNC.SelectedItem != null && cmbCNC.SelectedItem.ToString().Trim().Length > 0)
                {
                    oldCNC = cmbCNC.SelectedItem.ToString();
                }

                itensCNC.Clear();
                for (int i = 0; i < this.dataSet.Tables[0].Rows.Count; i++)
                {
                    if (!itensCNC.ContainsKey(this.dataSet.Tables[0].Rows[i]["oie_cnc"].ToString()))
                    {
                        itensCNC.Add(this.dataSet.Tables[0].Rows[i]["oie_cnc"].ToString(), true);
                    }
                }

                cmbCNC.Items.Clear();
                foreach (string item in itensCNC.Keys)
                {
                    cmbCNC.Items.Add(item);
                }

                if (oldCNC.Length > 0)
                {
                    cmbCNC.SelectedItem = oldCNC;
                }
                updatingCNC = false;
            }

        }

        private string GerarSearch()
        {
            string searchClause = "";
            try
            {
            

                if (this.txtOC.Text.Trim().Length > 0)
                {
                    searchClause += " AND order_item_etiqueta.oie_order_number LIKE '%" + this.txtOC.Text.Trim() + "%' ";
                }

                if (this.txtPos.Text.Trim().Length > 0)
                {
                    searchClause += " AND order_item_etiqueta.oie_order_pos = " + this.txtPos.Text.Trim() + " ";
                }

                if (this.chkPPS.Checked)
                {
                    searchClause += "AND order_item_etiqueta.oie_pps = " + this.nudPPS.Value.ToString() + " ";
                }


                if (chkItem.Checked)
                {
                    if (this.cmbItem.Items.Count > 0)
                    {
                        if (this.cmbItem.SelectedItem == null)
                        {
                            cmbItem.SelectedIndex = 0;
                        }
                        if (this.cmbItem.SelectedItem.ToString().Trim().Length > 0)
                        {
                            searchClause += " AND order_item_etiqueta.oie_codigo_item LIKE '" + this.cmbItem.SelectedItem + "' ";
                        }
                        else
                        {
                            searchClause += " AND (order_item_etiqueta.oie_codigo_item LIKE '" + this.cmbItem.SelectedItem + "' OR order_item_etiqueta.oie_codigo_item IS NULL) ";
                        }
                    }
                }

                if (this.chkDimensao.Checked)
                {
                    if (this.cmbDimensao.Items.Count > 0)
                    {
                        if (this.cmbDimensao.SelectedItem == null)
                        {
                            cmbDimensao.SelectedIndex = 0;
                        }
                        if (this.cmbDimensao.SelectedItem.ToString().Trim().Length > 0)
                        {
                            searchClause += " AND order_item_etiqueta.oie_dimensao LIKE '" + this.cmbDimensao.SelectedItem + "' ";
                        }
                        else
                        {
                            searchClause += " AND (order_item_etiqueta.oie_dimensao LIKE '" + this.cmbDimensao.SelectedItem + "' OR order_item_etiqueta.oie_dimensao IS NULL) ";
                        }
                    }
                }

                if (this.chkCNC.Checked)
                {
                    if (this.cmbCNC.Items.Count > 0)
                    {
                        if (this.cmbCNC.SelectedItem == null)
                        {
                            cmbCNC.SelectedIndex = 0;
                        }
                        if (this.cmbCNC.SelectedItem.ToString().Trim().Length > 0)
                        {
                            searchClause += " AND order_item_etiqueta.oie_cnc LIKE '" + this.cmbCNC.SelectedItem + "' ";
                        }
                        else
                        {
                            searchClause += " AND (order_item_etiqueta.oie_cnc LIKE '" + this.cmbCNC.SelectedItem + "' OR order_item_etiqueta.oie_cnc IS NULL) ";
                        }
                    }
                }


                if (this.chkClassificacao.Checked)
                {
                    if (this.cmbClassificacao.Items.Count > 0)
                    {
                        if (this.cmbClassificacao.SelectedItem == null)
                        {
                            cmbClassificacao.SelectedIndex = 0;
                        }
                        if (this.cmbClassificacao.SelectedItem.ToString().Trim().Length > 0)
                        {
                            searchClause += " AND clp_identificacao LIKE '" + this.cmbClassificacao.SelectedItem + "' ";
                        }
                        else
                        {
                            searchClause += " AND (clp_identificacao LIKE '" + this.cmbClassificacao.SelectedItem + "' OR clp_identificacao IS NULL) ";
                        }
                    }
                }




                if (searchClause.Length > 0)
                {
                    searchClause = searchClause.Substring(4);
                }
                else
                {
                    searchClause = "";
                }



            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Valor inválido na busca.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchClause = "";

            }

            return searchClause;


        }

        private void Save()
        {
            try
            {
                if (this.txtEditCNC.Text.Trim().Length < 4)
                {
                    throw new Exception("Campo CNC deve conter exatamente 4 caracteres.");
                }

                if (this.txtEditCoordenadaX.Text.Trim().Length < 2)
                {
                    throw new Exception("Campo Coordenada X deve conter exatamente 2 caracteres.");
                }

                if (this.txtEditCoordenadaY.Text.Trim().Length < 1)
                {
                    throw new Exception("Campo Coordenada Y deve conter ao menos 1 caracter.");
                }




                if (this.itemAtivo != null)
                {
                    this.itemAtivo.CNC = this.txtEditCNC.Text.Trim();
                    this.itemAtivo.coordenadaX = this.txtEditCoordenadaX.Text.Trim();
                    this.itemAtivo.coordenadaY = this.txtEditCoordenadaY.Text.Trim();
                    this.itemAtivo.Programador = this.txtEditProgramador.Text.Trim();

                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    this.itemAtivo.Save(ref command);
                    
                    
                    this.dataGridView1.Rows[this.itemAtivo.indiceGrid].Cells["oie_cnc"].Value = this.itemAtivo.CNC;
                    this.dataGridView1.Rows[this.itemAtivo.indiceGrid].Cells["oie_coordenada_x"].Value = this.itemAtivo.coordenadaX;
                    this.dataGridView1.Rows[this.itemAtivo.indiceGrid].Cells["oie_coordenada_y"].Value = this.itemAtivo.coordenadaY;
                    this.dataGridView1.Rows[this.itemAtivo.indiceGrid].Cells["oie_programador"].Value = this.itemAtivo.Programador;

                    this.itemAtivo.Row.Row.SetField("oie_cnc", this.itemAtivo.CNC);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];
                  
                    int i = 0;
                    while (i < this.dataGridView1.Rows.Count)
                    {
                        if (this.dataGridView1.Rows[i].Selected)
                        {
                            this.dataGridView1.Rows[i].Selected = false;
                        }
                        else
                        {
                            this.dataGridView1.Rows[i].Selected = true;
                            break;
                        }

                    }
                  

                    this.loadComboCNC();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void loadItemTela()
        {
            if (this.itemAtivo != null)
            {
                this.txtEditCNC.Text = this.itemAtivo.CNC;
                this.txtEditCoordenadaX.Text = this.itemAtivo.coordenadaX;
                this.txtEditCoordenadaY.Text = this.itemAtivo.coordenadaY;
                this.txtEditProgramador.Text = this.itemAtivo.Programador;

                this.itemAtivo.alterado = false;
            }
        }

        private void printScreen()
        {
            try
            {
               


                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                string sql = MontaQueryTela();

                command.CommandText = sql;
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                CNCDataSet ds = new CNCDataSet();
                CNCDataSet.cncRow row;
                while (read.Read())
                {
                    row = ds.cnc.NewcncRow();
                    row.dimensao = read["oie_dimensao"].ToString();
                    row.oc = read["oie_order_number"].ToString();
                    row.pos = read["oie_order_pos"].ToString();
                    row.qtd = Convert.ToDouble(read["oie_qtd_etiquetas"]);
                    row.saf = read["oie_saf"].ToString();
                    row.tipoBaseBoard = read["oie_tipo_baseboard"].ToString();
                    row.kit = read["pek_tipo_kit"].ToString();
                    if (row.kit != "")
                    {
                        row.groupKit = row.kit.ToUpper().Replace("KIT", "").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    }

                    row.cnc_valor = read["oie_cnc"].ToString();
                    row.cnc_x = read["oie_coordenada_x"].ToString();
                    row.cnc_y = read["oie_coordenada_y"].ToString();

                    row.logoEmpresa = logoEmpresa;

                    ds.cnc.AddcncRow(row);
                }

                CNCReport rep = new CNCReport();
                rep.SetDataSource(ds);

                CNCReportForm form = new CNCReportForm(rep);
                form.Show();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao imprimir a tela.\r\n" + e.Message);
            }
        }

        #region Eventos

        private void txtOC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudPPS_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPPS_CheckedChanged(object sender, EventArgs e)
        {
            this.nudPPS.Enabled = this.chkPPS.Checked;
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Save();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (this.itemAtivo != null && this.itemAtivo.alterado)
                    {
                        if (MessageBox.Show(this, "O item ativo ainda não foi salvo, deseja salva-lo antes de trocar de item?", "Alteração de item ativo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.Save();
                        }
                    }


                    this.itemAtivo = new ItemCNC(
                        this.dataGridView1.SelectedRows[0].Cells["id_order_item_etiqueta"].Value.ToString(),
                        this.dataGridView1.SelectedRows[0].Cells["oie_cnc"].Value.ToString(),
                        this.dataGridView1.SelectedRows[0].Cells["oie_coordenada_x"].Value.ToString(),
                        this.dataGridView1.SelectedRows[0].Cells["oie_coordenada_y"].Value.ToString(),
                        this.dataGridView1.SelectedRows[0].Cells["oie_programador"].Value.ToString(),
                        this.dataGridView1.SelectedRows[0].Index,
                        (DataRowView)this.dataGridView1.SelectedRows[0].DataBoundItem
                        );



                    this.loadItemTela();

                    this.txtEditCNC.Enabled = true;
                    this.txtEditCoordenadaX.Enabled = true;
                    this.txtEditCoordenadaY.Enabled = true;
                    this.txtEditProgramador.Enabled = true;
                    this.btnSalvar.Enabled = true;
                }
                else
                {
                    this.txtEditCNC.Enabled = false;
                    this.txtEditCoordenadaX.Enabled = false;
                    this.txtEditCoordenadaY.Enabled = false;
                    this.txtEditProgramador.Enabled = false;
                    this.btnSalvar.Enabled = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   
        private void txtEditCNC_TextChanged(object sender, EventArgs e)
        {
            if (this.itemAtivo != null)
            {
                this.itemAtivo.alterado = true;
                this.txtEditProgramador.Text = this.Usuario.Login;
            }
        }

        private void txtEditCoordenadaX_TextChanged(object sender, EventArgs e)
        {
            if (this.itemAtivo != null)
            {
                this.itemAtivo.alterado = true;
                this.txtEditProgramador.Text = this.Usuario.Login;
            }
        }

        private void txtEditCoordenadaY_TextChanged(object sender, EventArgs e)
        {
            if (this.itemAtivo != null)
            {
                this.itemAtivo.alterado = true;
                this.txtEditProgramador.Text = this.Usuario.Login;
            }
        }

        private void txtEditProgramador_TextChanged(object sender, EventArgs e)
        {
            if (this.itemAtivo != null)
            {
                this.itemAtivo.alterado = true;
            }
        }



        private void chkBaseboard_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbItem.Enabled = this.chkItem.Checked;
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDimensao_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbDimensao.Enabled = this.chkDimensao.Checked;
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkCNC_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbCNC.Enabled = this.chkCNC.Checked;
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSaf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBaseboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDimensao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCNC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            try
            {
                this.printScreen();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

     
        private void cmbClassificacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkClassificacao_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbClassificacao.Enabled = this.chkClassificacao.Checked;
            try
            {
                
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                this.OrdenarDimensao();
            }
            else
            {
                this.ordenadoDimensao = false;
            }

            if (e.ColumnIndex == 7)
            {
                this.OrdenarPPSAtual();
            }
            else
            {
                this.ordenadoPPSAtual = false;
            }
        }

        


        private void chkPPSAtual_CheckedChanged(object sender, EventArgs e)
        {
            this.nudPPSAtual.Enabled = this.chkPPSAtual.Checked;
            try
            {

                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudPPSAtual_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }

    internal class ItemCNC
    {
        public string idOrderItemEtiqueta;
        public string CNC;
        public string coordenadaX;
        public string coordenadaY;
        public string Programador;
        public bool alterado = false;
        public int indiceGrid;
        public DataRowView Row;

        public ItemCNC(string idOrderItemEtiqueta, string CNC, string coordenadaX, string coordenadaY, string Programador, int indiceGrid, DataRowView Row)
        {
            this.CNC = CNC;
            this.coordenadaX = coordenadaX;
            this.coordenadaY = coordenadaY;
            this.idOrderItemEtiqueta = idOrderItemEtiqueta;
            this.Programador = Programador;
            this.indiceGrid = indiceGrid;
            this.Row = Row;

        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
              
                command.CommandText = "UPDATE order_item_etiqueta SET oie_cnc = '" + this.CNC + "', oie_coordenada_x='" + this.coordenadaX + "', oie_coordenada_y='" + this.coordenadaY + "', " +
                    "oie_programador='" + this.Programador + "' WHERE id_order_item_etiqueta=" + this.idOrderItemEtiqueta + ";";
                command.ExecuteNonQuery();

                this.alterado = false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o cnc do item.\r\n" + e.Message);
            }
        }
    }
}
