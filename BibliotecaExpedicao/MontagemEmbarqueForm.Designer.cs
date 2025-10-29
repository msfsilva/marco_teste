namespace BibliotecaExpedicao
{
    partial class MontagemEmbarqueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MontagemEmbarqueForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbTransporte = new System.Windows.Forms.GroupBox();
            this.chkTransporte = new System.Windows.Forms.CheckBox();
            this.cmbTransporte = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grbItem = new System.Windows.Forms.GroupBox();
            this.btnItem = new System.Windows.Forms.Button();
            this.txtBarcodeOc = new IWTCustomControls.BarcodeTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.grbModoOperacao = new System.Windows.Forms.GroupBox();
            this.rdbBarCode = new System.Windows.Forms.RadioButton();
            this.rdbManual = new System.Windows.Forms.RadioButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstInseridos = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.timerItem = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbTransporte.SuspendLayout();
            this.grbItem.SuspendLayout();
            this.grbModoOperacao.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grbTransporte);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.grbItem);
            this.splitContainer1.Panel1.Controls.Add(this.grbModoOperacao);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(721, 566);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // grbTransporte
            // 
            this.grbTransporte.Controls.Add(this.chkTransporte);
            this.grbTransporte.Controls.Add(this.cmbTransporte);
            this.grbTransporte.Location = new System.Drawing.Point(213, 12);
            this.grbTransporte.Name = "grbTransporte";
            this.grbTransporte.Size = new System.Drawing.Size(412, 51);
            this.grbTransporte.TabIndex = 12;
            this.grbTransporte.TabStop = false;
            this.grbTransporte.Text = "Transportador";
            // 
            // chkTransporte
            // 
            this.chkTransporte.AutoSize = true;
            this.chkTransporte.Location = new System.Drawing.Point(379, 22);
            this.chkTransporte.Name = "chkTransporte";
            this.chkTransporte.Size = new System.Drawing.Size(15, 14);
            this.chkTransporte.TabIndex = 1;
            this.chkTransporte.UseVisualStyleBackColor = true;
            this.chkTransporte.CheckedChanged += new System.EventHandler(this.chkTransporte_CheckedChanged);
            // 
            // cmbTransporte
            // 
            this.cmbTransporte.Enabled = false;
            this.cmbTransporte.FormattingEnabled = true;
            this.cmbTransporte.Location = new System.Drawing.Point(6, 19);
            this.cmbTransporte.Name = "cmbTransporte";
            this.cmbTransporte.Size = new System.Drawing.Size(367, 21);
            this.cmbTransporte.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(598, 33);
            this.label4.TabIndex = 11;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(413, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Para \"pallets normais\" o sistema aceita somente a leitura do código de barras do " +
                "pallet";
            // 
            // grbItem
            // 
            this.grbItem.Controls.Add(this.btnItem);
            this.grbItem.Controls.Add(this.txtBarcodeOc);
            this.grbItem.Controls.Add(this.label2);
            this.grbItem.Enabled = false;
            this.grbItem.Location = new System.Drawing.Point(12, 141);
            this.grbItem.Name = "grbItem";
            this.grbItem.Size = new System.Drawing.Size(588, 51);
            this.grbItem.TabIndex = 0;
            this.grbItem.TabStop = false;
            this.grbItem.Text = "Inclusão de Item/Pallet";
            // 
            // btnItem
            // 
            this.btnItem.Enabled = false;
            this.btnItem.Location = new System.Drawing.Point(514, 16);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(47, 23);
            this.btnItem.TabIndex = 1;
            this.btnItem.Text = "OK";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // txtBarcodeOc
            // 
            this.txtBarcodeOc.Location = new System.Drawing.Point(163, 18);
            this.txtBarcodeOc.Name = "txtBarcodeOc";
            this.txtBarcodeOc.Size = new System.Drawing.Size(345, 20);
            this.txtBarcodeOc.TabIndex = 0;
            this.txtBarcodeOc.TextChanged += new System.EventHandler(this.txtBarcodeOc_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Identificador do Item ou Pallet";
            // 
            // grbModoOperacao
            // 
            this.grbModoOperacao.Controls.Add(this.rdbBarCode);
            this.grbModoOperacao.Controls.Add(this.rdbManual);
            this.grbModoOperacao.Location = new System.Drawing.Point(12, 12);
            this.grbModoOperacao.Name = "grbModoOperacao";
            this.grbModoOperacao.Size = new System.Drawing.Size(185, 51);
            this.grbModoOperacao.TabIndex = 1;
            this.grbModoOperacao.TabStop = false;
            this.grbModoOperacao.Text = "Modo de Operação";
            // 
            // rdbBarCode
            // 
            this.rdbBarCode.AutoSize = true;
            this.rdbBarCode.Checked = true;
            this.rdbBarCode.Location = new System.Drawing.Point(6, 19);
            this.rdbBarCode.Name = "rdbBarCode";
            this.rdbBarCode.Size = new System.Drawing.Size(91, 17);
            this.rdbBarCode.TabIndex = 0;
            this.rdbBarCode.TabStop = true;
            this.rdbBarCode.Text = "Código Barras";
            this.rdbBarCode.UseVisualStyleBackColor = true;
            this.rdbBarCode.CheckedChanged += new System.EventHandler(this.rdbBarCode_CheckedChanged);
            // 
            // rdbManual
            // 
            this.rdbManual.AutoSize = true;
            this.rdbManual.Location = new System.Drawing.Point(97, 19);
            this.rdbManual.Name = "rdbManual";
            this.rdbManual.Size = new System.Drawing.Size(60, 17);
            this.rdbManual.TabIndex = 1;
            this.rdbManual.Text = "Manual";
            this.rdbManual.UseVisualStyleBackColor = true;
            this.rdbManual.CheckedChanged += new System.EventHandler(this.rdbManual_CheckedChanged);
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
            this.splitContainer2.Panel1.Controls.Add(this.lstInseridos);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btnSalvar);
            this.splitContainer2.Size = new System.Drawing.Size(721, 362);
            this.splitContainer2.SplitterDistance = 315;
            this.splitContainer2.TabIndex = 0;
            // 
            // lstInseridos
            // 
            this.lstInseridos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInseridos.FormattingEnabled = true;
            this.lstInseridos.Location = new System.Drawing.Point(0, 0);
            this.lstInseridos.Name = "lstInseridos";
            this.lstInseridos.Size = new System.Drawing.Size(721, 303);
            this.lstInseridos.Sorted = true;
            this.lstInseridos.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(589, 8);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Encerrar Embarque";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // timerItem
            // 
            this.timerItem.Tick += new System.EventHandler(this.timerItem_Tick);
            // 
            // MontagemEmbarqueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(721, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MontagemEmbarqueForm";
            this.Text = "Montagem do Embarque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grbTransporte.ResumeLayout(false);
            this.grbTransporte.PerformLayout();
            this.grbItem.ResumeLayout(false);
            this.grbItem.PerformLayout();
            this.grbModoOperacao.ResumeLayout(false);
            this.grbModoOperacao.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbItem;
        private System.Windows.Forms.Button btnItem;
        private IWTCustomControls.BarcodeTextBox txtBarcodeOc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbModoOperacao;
        private System.Windows.Forms.RadioButton rdbBarCode;
        private System.Windows.Forms.RadioButton rdbManual;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Timer timerItem;
        private System.Windows.Forms.ListBox lstInseridos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbTransporte;
        private System.Windows.Forms.CheckBox chkTransporte;
        private System.Windows.Forms.ComboBox cmbTransporte;
    }
}