namespace BibliotecaCompras
{
    partial class OCEditLinhaForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.nudNaoAtualizaPrecoRecebimento = new System.Windows.Forms.CheckBox();
            this.nudDataPrevista = new System.Windows.Forms.DateTimePicker();
            this.dataPrevista = new System.Windows.Forms.Label();
            this.nudValorTotal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudIPI = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudICMS = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudValorUnitario = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProdutoMaterial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudICMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnitario)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.nudNaoAtualizaPrecoRecebimento);
            this.splitContainer1.Panel1.Controls.Add(this.nudDataPrevista);
            this.splitContainer1.Panel1.Controls.Add(this.dataPrevista);
            this.splitContainer1.Panel1.Controls.Add(this.nudValorTotal);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.nudIPI);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.nudICMS);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.nudValorUnitario);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblProdutoMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnOK);
            this.splitContainer1.Size = new System.Drawing.Size(382, 296);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Não Atualiza Preço no Recebimento";
            // 
            // nudNaoAtualizaPrecoRecebimento
            // 
            this.nudNaoAtualizaPrecoRecebimento.AutoSize = true;
            this.nudNaoAtualizaPrecoRecebimento.Location = new System.Drawing.Point(197, 229);
            this.nudNaoAtualizaPrecoRecebimento.Name = "nudNaoAtualizaPrecoRecebimento";
            this.nudNaoAtualizaPrecoRecebimento.Size = new System.Drawing.Size(15, 14);
            this.nudNaoAtualizaPrecoRecebimento.TabIndex = 12;
            this.nudNaoAtualizaPrecoRecebimento.UseVisualStyleBackColor = true;
            this.nudNaoAtualizaPrecoRecebimento.CheckedChanged += new System.EventHandler(this.naoAtualizaPrecoRecebimento_CheckedChanged);
            // 
            // nudDataPrevista
            // 
            this.nudDataPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nudDataPrevista.Location = new System.Drawing.Point(107, 188);
            this.nudDataPrevista.Name = "nudDataPrevista";
            this.nudDataPrevista.Size = new System.Drawing.Size(200, 20);
            this.nudDataPrevista.TabIndex = 11;
            // 
            // dataPrevista
            // 
            this.dataPrevista.AutoSize = true;
            this.dataPrevista.Location = new System.Drawing.Point(30, 191);
            this.dataPrevista.Name = "dataPrevista";
            this.dataPrevista.Size = new System.Drawing.Size(71, 13);
            this.dataPrevista.TabIndex = 10;
            this.dataPrevista.Text = "Data Prevista";
            // 
            // nudValorTotal
            // 
            this.nudValorTotal.DecimalPlaces = 4;
            this.nudValorTotal.Enabled = false;
            this.nudValorTotal.Location = new System.Drawing.Point(107, 162);
            this.nudValorTotal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudValorTotal.Name = "nudValorTotal";
            this.nudValorTotal.Size = new System.Drawing.Size(120, 20);
            this.nudValorTotal.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Valor Total";
            // 
            // nudIPI
            // 
            this.nudIPI.DecimalPlaces = 2;
            this.nudIPI.Location = new System.Drawing.Point(107, 109);
            this.nudIPI.Name = "nudIPI";
            this.nudIPI.Size = new System.Drawing.Size(120, 20);
            this.nudIPI.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Aliquota IPI (%)";
            // 
            // nudICMS
            // 
            this.nudICMS.DecimalPlaces = 2;
            this.nudICMS.Location = new System.Drawing.Point(107, 83);
            this.nudICMS.Name = "nudICMS";
            this.nudICMS.Size = new System.Drawing.Size(120, 20);
            this.nudICMS.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Aliquota ICMS (%)";
            // 
            // nudValorUnitario
            // 
            this.nudValorUnitario.DecimalPlaces = 4;
            this.nudValorUnitario.Location = new System.Drawing.Point(107, 57);
            this.nudValorUnitario.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudValorUnitario.Name = "nudValorUnitario";
            this.nudValorUnitario.Size = new System.Drawing.Size(120, 20);
            this.nudValorUnitario.TabIndex = 3;
            this.nudValorUnitario.ValueChanged += new System.EventHandler(this.nudValorUnitario_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor Unitário";
            // 
            // lblProdutoMaterial
            // 
            this.lblProdutoMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdutoMaterial.Location = new System.Drawing.Point(107, 20);
            this.lblProdutoMaterial.Name = "lblProdutoMaterial";
            this.lblProdutoMaterial.Size = new System.Drawing.Size(263, 23);
            this.lblProdutoMaterial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto/Material:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(12, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(295, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // OCEditLinhaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(382, 296);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OCEditLinhaForm";
            this.Text = "Edição da Linha da OC";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudValorTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudICMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnitario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblProdutoMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudIPI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudICMS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudValorUnitario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudValorTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker nudDataPrevista;
        private System.Windows.Forms.Label dataPrevista;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox nudNaoAtualizaPrecoRecebimento;
    }
}