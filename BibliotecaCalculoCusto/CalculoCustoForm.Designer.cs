namespace BibliotecaCalculoCusto
{
    partial class CalculoCustoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMargemBruta = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblICMS = new System.Windows.Forms.Label();
            this.lblIPI = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCofins = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPis = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPrecoBrutoCalculado = new System.Windows.Forms.Label();
            this.lblCustoTotalCalculado = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblValorFinal = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCustoBruto = new System.Windows.Forms.Button();
            this.lblMargemCalculada = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAvisos = new System.Windows.Forms.TextBox();
            this.lblCustoMaoObraCalculado = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargemBruta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto Selecionado:";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(120, 11);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(21, 13);
            this.lblProduto.TabIndex = 1;
            this.lblProduto.Text = "aa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Margem Pretendida (%)";
            // 
            // nudMargemBruta
            // 
            this.nudMargemBruta.DecimalPlaces = 2;
            this.nudMargemBruta.Location = new System.Drawing.Point(148, 228);
            this.nudMargemBruta.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMargemBruta.Name = "nudMargemBruta";
            this.nudMargemBruta.Size = new System.Drawing.Size(120, 20);
            this.nudMargemBruta.TabIndex = 3;
            this.nudMargemBruta.ValueChanged += new System.EventHandler(this.nudMargemBruta_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ICMS:";
            // 
            // lblICMS
            // 
            this.lblICMS.AutoSize = true;
            this.lblICMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblICMS.Location = new System.Drawing.Point(145, 38);
            this.lblICMS.Name = "lblICMS";
            this.lblICMS.Size = new System.Drawing.Size(21, 13);
            this.lblICMS.TabIndex = 5;
            this.lblICMS.Text = "aa";
            // 
            // lblIPI
            // 
            this.lblIPI.AutoSize = true;
            this.lblIPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPI.Location = new System.Drawing.Point(145, 62);
            this.lblIPI.Name = "lblIPI";
            this.lblIPI.Size = new System.Drawing.Size(21, 13);
            this.lblIPI.TabIndex = 7;
            this.lblIPI.Text = "aa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "IPI:";
            // 
            // lblCofins
            // 
            this.lblCofins.AutoSize = true;
            this.lblCofins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCofins.Location = new System.Drawing.Point(145, 110);
            this.lblCofins.Name = "lblCofins";
            this.lblCofins.Size = new System.Drawing.Size(21, 13);
            this.lblCofins.TabIndex = 11;
            this.lblCofins.Text = "aa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cofins:";
            // 
            // lblPis
            // 
            this.lblPis.AutoSize = true;
            this.lblPis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPis.Location = new System.Drawing.Point(145, 86);
            this.lblPis.Name = "lblPis";
            this.lblPis.Size = new System.Drawing.Size(21, 13);
            this.lblPis.TabIndex = 9;
            this.lblPis.Text = "aa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "PIS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Custo Bruto Calculado";
            // 
            // lblPrecoBrutoCalculado
            // 
            this.lblPrecoBrutoCalculado.AutoSize = true;
            this.lblPrecoBrutoCalculado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoBrutoCalculado.Location = new System.Drawing.Point(145, 134);
            this.lblPrecoBrutoCalculado.Name = "lblPrecoBrutoCalculado";
            this.lblPrecoBrutoCalculado.Size = new System.Drawing.Size(21, 13);
            this.lblPrecoBrutoCalculado.TabIndex = 13;
            this.lblPrecoBrutoCalculado.Text = "aa";
            // 
            // lblCustoTotalCalculado
            // 
            this.lblCustoTotalCalculado.AutoSize = true;
            this.lblCustoTotalCalculado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustoTotalCalculado.Location = new System.Drawing.Point(145, 182);
            this.lblCustoTotalCalculado.Name = "lblCustoTotalCalculado";
            this.lblCustoTotalCalculado.Size = new System.Drawing.Size(21, 13);
            this.lblCustoTotalCalculado.TabIndex = 15;
            this.lblCustoTotalCalculado.Text = "aa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Custo Total Calculado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Valor Final";
            // 
            // lblValorFinal
            // 
            this.lblValorFinal.AutoSize = true;
            this.lblValorFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorFinal.Location = new System.Drawing.Point(144, 278);
            this.lblValorFinal.Name = "lblValorFinal";
            this.lblValorFinal.Size = new System.Drawing.Size(21, 13);
            this.lblValorFinal.TabIndex = 17;
            this.lblValorFinal.Text = "aa";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblCustoMaoObraCalculado);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.btnCustoBruto);
            this.splitContainer1.Panel1.Controls.Add(this.lblMargemCalculada);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCliente);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblValorFinal);
            this.splitContainer1.Panel1.Controls.Add(this.lblProduto);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustoTotalCalculado);
            this.splitContainer1.Panel1.Controls.Add(this.nudMargemBruta);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblPrecoBrutoCalculado);
            this.splitContainer1.Panel1.Controls.Add(this.lblICMS);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.lblCofins);
            this.splitContainer1.Panel1.Controls.Add(this.lblIPI);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.lblPis);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(503, 545);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 18;
            // 
            // btnCustoBruto
            // 
            this.btnCustoBruto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustoBruto.Location = new System.Drawing.Point(342, 327);
            this.btnCustoBruto.Name = "btnCustoBruto";
            this.btnCustoBruto.Size = new System.Drawing.Size(149, 23);
            this.btnCustoBruto.TabIndex = 22;
            this.btnCustoBruto.Text = "Composição Custo Bruto";
            this.btnCustoBruto.UseVisualStyleBackColor = true;
            this.btnCustoBruto.Click += new System.EventHandler(this.btnCustoBruto_Click);
            // 
            // lblMargemCalculada
            // 
            this.lblMargemCalculada.AutoSize = true;
            this.lblMargemCalculada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMargemCalculada.Location = new System.Drawing.Point(144, 254);
            this.lblMargemCalculada.Name = "lblMargemCalculada";
            this.lblMargemCalculada.Size = new System.Drawing.Size(21, 13);
            this.lblMargemCalculada.TabIndex = 21;
            this.lblMargemCalculada.Text = "aa";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 254);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Margem Calculada";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(147, 203);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(305, 21);
            this.cmbCliente.TabIndex = 19;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Estado para Simulação";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAvisos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Observações do Cálculo";
            // 
            // txtAvisos
            // 
            this.txtAvisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAvisos.Location = new System.Drawing.Point(3, 16);
            this.txtAvisos.Multiline = true;
            this.txtAvisos.Name = "txtAvisos";
            this.txtAvisos.ReadOnly = true;
            this.txtAvisos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAvisos.Size = new System.Drawing.Size(497, 169);
            this.txtAvisos.TabIndex = 10;
            // 
            // lblCustoMaoObraCalculado
            // 
            this.lblCustoMaoObraCalculado.AutoSize = true;
            this.lblCustoMaoObraCalculado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustoMaoObraCalculado.Location = new System.Drawing.Point(145, 158);
            this.lblCustoMaoObraCalculado.Name = "lblCustoMaoObraCalculado";
            this.lblCustoMaoObraCalculado.Size = new System.Drawing.Size(21, 13);
            this.lblCustoMaoObraCalculado.TabIndex = 24;
            this.lblCustoMaoObraCalculado.Text = "aa";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Custo Mão Obra Calculado";
            // 
            // CalculoCustoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(503, 545);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CalculoCustoForm";
            this.Text = "Simulação de Custo do Produto";
            ((System.ComponentModel.ISupportInitialize)(this.nudMargemBruta)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMargemBruta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblICMS;
        private System.Windows.Forms.Label lblIPI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCofins;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrecoBrutoCalculado;
        private System.Windows.Forms.Label lblCustoTotalCalculado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblValorFinal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAvisos;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMargemCalculada;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCustoBruto;
        private System.Windows.Forms.Label lblCustoMaoObraCalculado;
        private System.Windows.Forms.Label label13;
    }
}