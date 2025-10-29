namespace ModuloConferenciaEtiquetaCustomizada
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkClassificacao = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbClassificacao = new System.Windows.Forms.ComboBox();
            this.rdbOCPos = new System.Windows.Forms.RadioButton();
            this.txtOC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPPS = new System.Windows.Forms.ComboBox();
            this.rdbCNC = new System.Windows.Forms.RadioButton();
            this.rdbPPS = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCNC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lstAConferir = new System.Windows.Forms.ListBox();
            this.lstConferidos = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.chkClassificacao);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cmbClassificacao);
            this.splitContainer1.Panel1.Controls.Add(this.rdbOCPos);
            this.splitContainer1.Panel1.Controls.Add(this.txtOC);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cmbPPS);
            this.splitContainer1.Panel1.Controls.Add(this.rdbCNC);
            this.splitContainer1.Panel1.Controls.Add(this.rdbPPS);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblAviso);
            this.splitContainer1.Panel1.Controls.Add(this.txtItem);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnOK);
            this.splitContainer1.Panel1.Controls.Add(this.txtCNC);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(732, 530);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 0;
            // 
            // chkClassificacao
            // 
            this.chkClassificacao.AutoSize = true;
            this.chkClassificacao.Location = new System.Drawing.Point(513, 50);
            this.chkClassificacao.Name = "chkClassificacao";
            this.chkClassificacao.Size = new System.Drawing.Size(15, 14);
            this.chkClassificacao.TabIndex = 43;
            this.chkClassificacao.UseVisualStyleBackColor = true;
            this.chkClassificacao.CheckedChanged += new System.EventHandler(this.chkClassificação_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Classificação";
            // 
            // cmbClassificacao
            // 
            this.cmbClassificacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClassificacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClassificacao.Enabled = false;
            this.cmbClassificacao.FormattingEnabled = true;
            this.cmbClassificacao.Location = new System.Drawing.Point(329, 48);
            this.cmbClassificacao.Name = "cmbClassificacao";
            this.cmbClassificacao.Size = new System.Drawing.Size(178, 21);
            this.cmbClassificacao.TabIndex = 41;
            // 
            // rdbOCPos
            // 
            this.rdbOCPos.AutoSize = true;
            this.rdbOCPos.Location = new System.Drawing.Point(211, 51);
            this.rdbOCPos.Name = "rdbOCPos";
            this.rdbOCPos.Size = new System.Drawing.Size(14, 13);
            this.rdbOCPos.TabIndex = 39;
            this.rdbOCPos.UseVisualStyleBackColor = true;
            this.rdbOCPos.CheckedChanged += new System.EventHandler(this.rdbOCPos_CheckedChanged);
            // 
            // txtOC
            // 
            this.txtOC.Enabled = false;
            this.txtOC.Location = new System.Drawing.Point(47, 48);
            this.txtOC.Name = "txtOC";
            this.txtOC.Size = new System.Drawing.Size(158, 20);
            this.txtOC.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "OC";
            // 
            // cmbPPS
            // 
            this.cmbPPS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPPS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPPS.FormattingEnabled = true;
            this.cmbPPS.Location = new System.Drawing.Point(329, 22);
            this.cmbPPS.Name = "cmbPPS";
            this.cmbPPS.Size = new System.Drawing.Size(178, 21);
            this.cmbPPS.TabIndex = 10;
            // 
            // rdbCNC
            // 
            this.rdbCNC.AutoSize = true;
            this.rdbCNC.Location = new System.Drawing.Point(211, 25);
            this.rdbCNC.Name = "rdbCNC";
            this.rdbCNC.Size = new System.Drawing.Size(14, 13);
            this.rdbCNC.TabIndex = 9;
            this.rdbCNC.UseVisualStyleBackColor = true;
            this.rdbCNC.CheckedChanged += new System.EventHandler(this.rdbCNC_CheckedChanged);
            // 
            // rdbPPS
            // 
            this.rdbPPS.AutoSize = true;
            this.rdbPPS.Checked = true;
            this.rdbPPS.Location = new System.Drawing.Point(513, 25);
            this.rdbPPS.Name = "rdbPPS";
            this.rdbPPS.Size = new System.Drawing.Size(14, 13);
            this.rdbPPS.TabIndex = 8;
            this.rdbPPS.TabStop = true;
            this.rdbPPS.UseVisualStyleBackColor = true;
            this.rdbPPS.CheckedChanged += new System.EventHandler(this.rdbPPS_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Semana";
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(44, 84);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(64, 16);
            this.lblAviso.TabIndex = 5;
            this.lblAviso.Text = "lblAviso";
            this.lblAviso.Visible = false;
            // 
            // txtItem
            // 
            this.txtItem.AcceptsReturn = true;
            this.txtItem.Enabled = false;
            this.txtItem.Location = new System.Drawing.Point(47, 103);
            this.txtItem.Multiline = true;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(310, 20);
            this.txtItem.TabIndex = 3;
            this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(658, 51);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCNC
            // 
            this.txtCNC.Enabled = false;
            this.txtCNC.Location = new System.Drawing.Point(47, 22);
            this.txtCNC.Name = "txtCNC";
            this.txtCNC.Size = new System.Drawing.Size(158, 20);
            this.txtCNC.TabIndex = 0;
            this.txtCNC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCNC_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CNC";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Panel2.Controls.Add(this.btnLimpar);
            this.splitContainer2.Panel2.Controls.Add(this.btnSair);
            this.splitContainer2.Size = new System.Drawing.Size(732, 391);
            this.splitContainer2.SplitterDistance = 327;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lstAConferir);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lstConferidos);
            this.splitContainer3.Size = new System.Drawing.Size(732, 327);
            this.splitContainer3.SplitterDistance = 364;
            this.splitContainer3.TabIndex = 0;
            // 
            // lstAConferir
            // 
            this.lstAConferir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAConferir.FormattingEnabled = true;
            this.lstAConferir.Location = new System.Drawing.Point(0, 0);
            this.lstAConferir.Name = "lstAConferir";
            this.lstAConferir.Size = new System.Drawing.Size(364, 327);
            this.lstAConferir.TabIndex = 0;
            // 
            // lstConferidos
            // 
            this.lstConferidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConferidos.FormattingEnabled = true;
            this.lstConferidos.Location = new System.Drawing.Point(0, 0);
            this.lstConferidos.Name = "lstConferidos";
            this.lstConferidos.Size = new System.Drawing.Size(364, 327);
            this.lstConferidos.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(645, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Location = new System.Drawing.Point(329, 25);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 0;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSair.Location = new System.Drawing.Point(12, 25);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(732, 530);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Módulo de Conferencia de Etiquetas Customizadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtCNC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox lstAConferir;
        private System.Windows.Forms.ListBox lstConferidos;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.RadioButton rdbCNC;
        private System.Windows.Forms.RadioButton rdbPPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbPPS;
        private System.Windows.Forms.RadioButton rdbOCPos;
        private System.Windows.Forms.TextBox txtOC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkClassificacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbClassificacao;
    }
}

