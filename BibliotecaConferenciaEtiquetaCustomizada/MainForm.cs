#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using dbProvider;

#endregion

namespace ModuloConferenciaEtiquetaCustomizada
{
    public partial class MainForm : IWTBaseForm
    {
        ConferenciaEtiquetaCustomizadaClass conf;

        public MainForm()
        {
            InitializeComponent();
            this.loadComboSemanas();
            this.loadComboClassificacao();
        }

        private void loadComboSemanas()
        {
            try
            {
                this.cmbPPS.Items.Clear();
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText = "SELECT distinct(oie_pps) as semana FROM order_item_etiqueta LEFT JOIN codigo_barra ON cob_codigo_item = oie_codigo_item AND cob_dimensao = oie_dimensao WHERE oie_tipo_item=1 AND oie_etiqueta_interna = 1 AND oie_conferencia_customizada_realizada = 0 AND id_codigo_barra IS NOT NULL AND oie_etiqueta_interna_impressa = 1 ORDER BY oie_pps";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    this.cmbPPS.Items.Add(read["semana"].ToString());
                }

                read.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao carregar as semanas.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void loadComboClassificacao()
        {
            try
            {
                string sql =
                    "SELECT  " +
                    "  id_classificacao_produto, " +
                    "  clp_descricao " +
                    "FROM  " +
                    "  public.classificacao_produto " +
                    "ORDER BY  clp_descricao";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbClassificacao.DataSource = binding;
                    this.cmbClassificacao.ValueMember = "id_classificacao_produto";
                    this.cmbClassificacao.DisplayMember = "clp_descricao";

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da classificação.\r\n" + e.Message);
            }
        }

        private void resetForm()
        {
            this.rdbCNC.Enabled = true;
            this.rdbPPS.Enabled = true;
            this.rdbOCPos.Enabled = true;

            if (this.txtCNC.Text.Trim().Length > 0)
            {
                this.rdbCNC.Checked = true;
                this.txtCNC.Enabled = true;
            }
            else
            {
                if (this.txtOC.Text.Trim().Length > 0)
                {
                    this.rdbOCPos.Checked = true;
                    this.txtOC.Enabled = true;
                }
                else
                {
                    this.rdbPPS.Checked = true;
                    this.cmbPPS.Enabled = true;
                }
            }
        
            this.txtItem.Enabled = false;
            this.timer1.Enabled = false;
            this.btnOK.Enabled = true;
            this.btnLimpar.Enabled = false;
            this.btnSave.Enabled = false;

            this.lstAConferir.Items.Clear();
            this.lstConferidos.Items.Clear();
            this.lblAviso.Visible = false;
            this.chkClassificacao.Checked = false;
            this.chkClassificacao.Enabled = true;
            this.txtItem.Clear();
            this.txtCNC.Clear();
        }

        private void populateLists()
        {
            if (this.conf.itensSemEtiqueta.Count > 0)
            {
                lblAviso.Visible = true;
                if (this.rdbCNC.Checked)
                {
                    this.lblAviso.Text = "Existem itens sem etiqueta impressa para o CNC " + this.txtCNC.Text;
                }
                else
                {
                    this.lblAviso.Text = "Existem itens sem etiqueta impressa para a semana " + this.cmbPPS.SelectedItem + " ou anteriores";
                }
            }
            else
            {
                lblAviso.Visible = false;
            }

            this.lstAConferir.Items.Clear();
            this.lstConferidos.Items.Clear();

            foreach (EtiquetaCustomizada item in this.conf.aConferir)
            {
                this.lstAConferir.Items.Add(item.ToString());
            }

            foreach (EtiquetaCustomizada item in this.conf.Conferidas)
            {
                this.lstConferidos.Items.Add(item.ToString());
            }


        }

        private void conferirItem(string codigo)
        {
            try
            {
                List<string> codigosBarra = new List<string>(codigo.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries));

                foreach (string codigoBarra in codigosBarra)
                {
                    this.conf.confereItem(codigoBarra);    
                }
                
                this.txtItem.Clear();
                this.populateLists();

                if (this.conf.aConferir.Count == 0)
                {
                    this.Salvar();
                }

            }
            catch (Exception e)
            {
                this.txtItem.Clear();
                throw new Exception("Erro ao conferir o item.\r\n" + e.Message);
            }
        }

        private void loadCNC(string CNC, string PPS, string OC)
        {
            try
            {
                string cnc = null, pps = null, oc = null;
                if (CNC != null && CNC.Trim().Length > 0)
                {
                    cnc = CNC.Trim();
                }


                if (PPS != null && PPS.Trim().Length > 0)
                {
                    pps = PPS.Trim();
                }



                if (OC != null && OC.Trim().Length > 0)
                {
                    oc = OC.Trim();
                }


                int? idClassificacao = null;
                if (this.cmbClassificacao.Enabled && this.cmbClassificacao.SelectedValue != null)
                {
                    idClassificacao = Convert.ToInt32(this.cmbClassificacao.SelectedValue);
                }



                conf = new ConferenciaEtiquetaCustomizadaClass(cnc, pps, oc, idClassificacao, SingleConnection);

                this.txtCNC.Enabled = false;
                this.cmbPPS.Enabled = false;
                this.txtOC.Enabled = false;
                this.rdbCNC.Enabled = false;
                this.rdbPPS.Enabled = false;
                this.rdbOCPos.Enabled = false;
                this.txtItem.Enabled = true;
                this.btnLimpar.Enabled = true;
                this.btnOK.Enabled = false;
                this.btnSave.Enabled = true;
                this.chkClassificacao.Enabled = false;
                this.cmbClassificacao.Enabled = false;
                this.populateLists();

            }
            catch (Exception e)
            {
                this.resetForm();
                if (e.Message.Contains("USR:"))
                {
                    throw new Exception(e.Message.Substring(e.Message.IndexOf("USR:") + 4));
                }
                else
                {
                    throw new Exception("Erro ao buscar os dados do CNC.\r\n" + e.Message);
                }
            }
        }

        private void Salvar()
        {
            try
            {
                if (this.conf.aConferir.Count > 0)
                {
                    if (MessageBox.Show(this, "Ainda existem itens a ser conferidos, deseja salvar a conferência mesmo assim?", "Conferência parcial", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                this.conf.Save();
                MessageBox.Show(this, "Conferência salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.resetForm();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a conferência.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbCNC.Checked)
                {
                    this.loadCNC(this.txtCNC.Text, null, null);
                }

                if (this.rdbPPS.Checked)
                {
                    if (this.cmbPPS.SelectedItem == null)
                    {
                        throw new Exception("Selecione uma semana para continuar.");
                    }
                    this.loadCNC(null, this.cmbPPS.SelectedItem.ToString(),null);
                }

                if (this.rdbOCPos.Checked)
                {
                    this.loadCNC(null, null, this.txtOC.Text);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.txtItem.Text.Trim() != "")
                {
                    this.timer1.Enabled = false;
                    this.conferirItem(this.txtItem.Text);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (this.conf != null)
            {
                if (MessageBox.Show(this, "Existe uma conferência sendo realizada e não salva, você deseja salva-la antes de limpar a tela?", "Conferência em Processo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Salvar();
                }
                this.resetForm();
            }
           
        }

        private void txtCNC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.btnOK_Click(null, null);
            }
        }
   
        private void rdbCNC_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCNC.Enabled = rdbCNC.Checked;
            this.cmbPPS.Enabled = rdbPPS.Checked;
            this.txtOC.Enabled = this.rdbOCPos.Checked;


        }

        private void rdbPPS_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCNC.Enabled = rdbCNC.Checked;
            this.cmbPPS.Enabled = rdbPPS.Checked;
            this.txtOC.Enabled = this.rdbOCPos.Checked;
        }

        private void rdbOCPos_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCNC.Enabled = rdbCNC.Checked;
            this.cmbPPS.Enabled = rdbPPS.Checked;
            this.txtOC.Enabled = this.rdbOCPos.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Salvar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.conf != null)
                {
                    if (MessageBox.Show(this, "Existe uma conferência sendo realizada e não salva, você deseja salva-la antes de encerrar o sistema?", "Conferência em Processo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Salvar();
                    }
                }
            }
            catch (Exception a)
            {
                e.Cancel = true;
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void chkClassificação_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbClassificacao.Enabled = this.chkClassificacao.Checked;
        }
        #endregion



    }
}
