namespace BibliotecaFinanceiro
{
    partial class EmbarqueForm
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
            this.btnEmitirNF = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lnkAtualizar = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnTransportadora = new IWTDotNetLib.IWTButton(this.components);
            this.rdbNFEmitidaAutorizada = new System.Windows.Forms.RadioButton();
            this.rdbNfEmitida = new System.Windows.Forms.RadioButton();
            this.rdbLiberado = new System.Windows.Forms.RadioButton();
            this.rdbNaoLiberado = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEmitirNF
            // 
            this.btnEmitirNF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmitirNF.Location = new System.Drawing.Point(633, 36);
            this.btnEmitirNF.Name = "btnEmitirNF";
            this.btnEmitirNF.Size = new System.Drawing.Size(75, 23);
            this.btnEmitirNF.TabIndex = 5;
            this.btnEmitirNF.Text = "Emitir NF";
            this.btnEmitirNF.UseVisualStyleBackColor = true;
            this.btnEmitirNF.Click += new System.EventHandler(this.btnEmitirNF_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(719, 288);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // lnkAtualizar
            // 
            this.lnkAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAtualizar.AutoSize = true;
            this.lnkAtualizar.Location = new System.Drawing.Point(661, 20);
            this.lnkAtualizar.Name = "lnkAtualizar";
            this.lnkAtualizar.Size = new System.Drawing.Size(47, 13);
            this.lnkAtualizar.TabIndex = 4;
            this.lnkAtualizar.TabStop = true;
            this.lnkAtualizar.Text = "Atualizar";
            this.lnkAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizar_LinkClicked);
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnTransportadora);
            this.splitContainer1.Panel2.Controls.Add(this.rdbNFEmitidaAutorizada);
            this.splitContainer1.Panel2.Controls.Add(this.rdbNfEmitida);
            this.splitContainer1.Panel2.Controls.Add(this.rdbLiberado);
            this.splitContainer1.Panel2.Controls.Add(this.rdbNaoLiberado);
            this.splitContainer1.Panel2.Controls.Add(this.lnkAtualizar);
            this.splitContainer1.Panel2.Controls.Add(this.btnEmitirNF);
            this.splitContainer1.Size = new System.Drawing.Size(719, 360);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnTransportadora
            // 
            this.btnTransportadora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransportadora.LiberadoQuandoCadastroUtilizado = false;
            this.btnTransportadora.Location = new System.Drawing.Point(483, 36);
            this.btnTransportadora.Name = "btnTransportadora";
            this.btnTransportadora.Size = new System.Drawing.Size(130, 23);
            this.btnTransportadora.TabIndex = 6;
            this.btnTransportadora.Text = "Alterar Transportadora";
            this.btnTransportadora.UseVisualStyleBackColor = true;
            this.btnTransportadora.Click += new System.EventHandler(this.btnTransportadora_Click);
            // 
            // rdbNFEmitidaAutorizada
            // 
            this.rdbNFEmitidaAutorizada.AutoSize = true;
            this.rdbNFEmitidaAutorizada.Location = new System.Drawing.Point(251, 37);
            this.rdbNFEmitidaAutorizada.Name = "rdbNFEmitidaAutorizada";
            this.rdbNFEmitidaAutorizada.Size = new System.Drawing.Size(185, 17);
            this.rdbNFEmitidaAutorizada.TabIndex = 3;
            this.rdbNFEmitidaAutorizada.Text = "NF Emitida e Autorizada pela RFB";
            this.rdbNFEmitidaAutorizada.UseVisualStyleBackColor = true;
            // 
            // rdbNfEmitida
            // 
            this.rdbNfEmitida.AutoSize = true;
            this.rdbNfEmitida.Location = new System.Drawing.Point(40, 37);
            this.rdbNfEmitida.Name = "rdbNfEmitida";
            this.rdbNfEmitida.Size = new System.Drawing.Size(205, 17);
            this.rdbNfEmitida.TabIndex = 2;
            this.rdbNfEmitida.Text = "NF Emitida e Aguardando Autorização";
            this.rdbNfEmitida.UseVisualStyleBackColor = true;
            this.rdbNfEmitida.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdbLiberado
            // 
            this.rdbLiberado.AutoSize = true;
            this.rdbLiberado.Checked = true;
            this.rdbLiberado.Location = new System.Drawing.Point(251, 14);
            this.rdbLiberado.Name = "rdbLiberado";
            this.rdbLiberado.Size = new System.Drawing.Size(195, 17);
            this.rdbLiberado.TabIndex = 1;
            this.rdbLiberado.TabStop = true;
            this.rdbLiberado.Text = "Liberado e Aguardando Emissão NF";
            this.rdbLiberado.UseVisualStyleBackColor = true;
            this.rdbLiberado.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbNaoLiberado
            // 
            this.rdbNaoLiberado.AutoSize = true;
            this.rdbNaoLiberado.Location = new System.Drawing.Point(40, 14);
            this.rdbNaoLiberado.Name = "rdbNaoLiberado";
            this.rdbNaoLiberado.Size = new System.Drawing.Size(89, 17);
            this.rdbNaoLiberado.TabIndex = 0;
            this.rdbNaoLiberado.Text = "Não Liberado";
            this.rdbNaoLiberado.UseVisualStyleBackColor = true;
            this.rdbNaoLiberado.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // EmbarqueForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(719, 360);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EmbarqueForm";
            this.Text = "Embarques";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmitirNF;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel lnkAtualizar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rdbNfEmitida;
        private System.Windows.Forms.RadioButton rdbLiberado;
        private System.Windows.Forms.RadioButton rdbNaoLiberado;
        private System.Windows.Forms.RadioButton rdbNFEmitidaAutorizada;
        private IWTDotNetLib.IWTButton btnTransportadora;
    }
}