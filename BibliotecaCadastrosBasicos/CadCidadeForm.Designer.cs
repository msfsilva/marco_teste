namespace BibliotecaCadastrosBasicos
{
    partial class CadCidadeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtNumericUpDown1 = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.Pais = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e = new IWTDotNetLib.IWTCheckBox(this.components);
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615 = new IWTDotNetLib.IWTTextBox(this.components);
            this.Estado = new IWTDotNetLib.IWTEntitySelection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown1)).BeginInit();
            this.Pais.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Estado);
            this.splitContainer1.Panel1.Controls.Add(this.Pais);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtNumericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(498, 292);
            this.splitContainer1.SplitterDistance = 226;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(411, 20);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(32, 71);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(40, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Estado";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(35, 15);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(35, 13);
            this.iwtLabel2.TabIndex = 2;
            this.iwtLabel2.Text = "Nome";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Nome";
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(76, 12);
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.Size = new System.Drawing.Size(289, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtNumericUpDown1
            // 
            this.iwtNumericUpDown1.BindingField = "CodigoIbge";
            this.iwtNumericUpDown1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNumericUpDown1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtNumericUpDown1.Location = new System.Drawing.Point(76, 94);
            this.iwtNumericUpDown1.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.iwtNumericUpDown1.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.iwtNumericUpDown1.Name = "iwtNumericUpDown1";
            this.iwtNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.iwtNumericUpDown1.TabIndex = 2;
            this.iwtNumericUpDown1.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(16, 98);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(57, 13);
            this.iwtLabel3.TabIndex = 5;
            this.iwtLabel3.Text = "Cód. IBGE";
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(37, 43);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(29, 13);
            this.iwtLabel4.TabIndex = 6;
            this.iwtLabel4.Text = "País";
            // 
            // Pais
            // 
            this.Pais.BindingField = "Pais";
            this.Pais.Controls.Add(this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e);
            this.Pais.Controls.Add(this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615);
            this.Pais.DesabilitarAutoCompletar = false;
            this.Pais.DesabilitarChekBox = true;
            this.Pais.DesabilitarLupa = false;
            this.Pais.DesabilitarSeta = false;
            this.Pais.EntidadeSelecionada = null;
            this.Pais.FormSelecao = null;
            this.Pais.LiberadoQuandoCadastroUtilizado = false;
            this.Pais.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Pais.Location = new System.Drawing.Point(76, 38);
            this.Pais.ModoVisualizacaoGrid = null;
            this.Pais.Name = "Pais";
            this.Pais.ParametrosBuscaObrigatorios = null;
            this.Pais.Size = new System.Drawing.Size(331, 21);
            this.Pais.TabIndex = 9;
            this.Pais.EntityChange += new System.EventHandler(this.Pais_EntityChange);
            // 
            // object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e
            // 
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.AutoSize = true;
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.BindingField = "";
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.Checked = true;
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.CheckState = System.Windows.Forms.CheckState.Checked;
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.LiberadoQuandoCadastroUtilizado = false;
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.Location = new System.Drawing.Point(355, 4);
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.Name = "object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e";
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.Size = new System.Drawing.Size(15, 14);
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.TabIndex = 1;
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.UseVisualStyleBackColor = true;
            this.object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e.Visible = false;
            // 
            // object_75aa9b41_1d3b_472e_b280_77a0a32cb615
            // 
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615.BindingField = "";
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615.LiberadoQuandoCadastroUtilizado = false;
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615.Location = new System.Drawing.Point(0, 1);
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615.Name = "object_75aa9b41_1d3b_472e_b280_77a0a32cb615";
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615.Size = new System.Drawing.Size(338, 20);
            this.object_75aa9b41_1d3b_472e_b280_77a0a32cb615.TabIndex = 0;
            // 
            // Estado
            // 
            this.Estado.BindingField = "Estado";
            this.Estado.DesabilitarAutoCompletar = false;
            this.Estado.DesabilitarChekBox = false;
            this.Estado.DesabilitarLupa = false;
            this.Estado.DesabilitarSeta = false;
            this.Estado.EntidadeSelecionada = null;
            this.Estado.FormSelecao = null;
            this.Estado.LiberadoQuandoCadastroUtilizado = false;
            this.Estado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Estado.Location = new System.Drawing.Point(76, 67);
            this.Estado.ModoVisualizacaoGrid = null;
            this.Estado.Name = "Estado";
            this.Estado.ParametrosBuscaObrigatorios = null;
            this.Estado.Size = new System.Drawing.Size(353, 23);
            this.Estado.TabIndex = 1;
            // 
            // CadCidadeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(498, 292);
            this.Name = "CadCidadeForm";
            this.Text = "Cidade";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown1)).EndInit();
            this.Pais.ResumeLayout(false);
            this.Pais.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTNumericUpDown iwtNumericUpDown1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTEntitySelection Pais;
        private IWTDotNetLib.IWTCheckBox object_52b477b8_4c77_48bc_bbac_e34c4e84fe5e;
        private IWTDotNetLib.IWTTextBox object_75aa9b41_1d3b_472e_b280_77a0a32cb615;
        private IWTDotNetLib.IWTEntitySelection Estado;
    }
}