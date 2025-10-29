using IWTCustomControls;

namespace BibliotecaExpedicao
{
    partial class ConferenciaPalletForm
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
            this.grbItem = new System.Windows.Forms.GroupBox();
            this.btnItem = new System.Windows.Forms.Button();
            this.txtBarcodeOc = new IWTCustomControls.BarcodeTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.grbModoOperacao = new System.Windows.Forms.GroupBox();
            this.rdbBarCode = new System.Windows.Forms.RadioButton();
            this.rdbManual = new System.Windows.Forms.RadioButton();
            this.grbCaixa = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcodePallet = new IWTCustomControls.BarcodeTextBox(this.components);
            this.btnPallet = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lstDisponiveis = new System.Windows.Forms.ListBox();
            this.lstConferidos = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.timerPallet = new System.Windows.Forms.Timer(this.components);
            this.timerOC = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbItem.SuspendLayout();
            this.grbModoOperacao.SuspendLayout();
            this.grbCaixa.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grbItem);
            this.splitContainer1.Panel1.Controls.Add(this.grbModoOperacao);
            this.splitContainer1.Panel1.Controls.Add(this.grbCaixa);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(721, 566);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.TabIndex = 8;
            // 
            // grbItem
            // 
            this.grbItem.Controls.Add(this.btnItem);
            this.grbItem.Controls.Add(this.txtBarcodeOc);
            this.grbItem.Controls.Add(this.label2);
            this.grbItem.Enabled = false;
            this.grbItem.Location = new System.Drawing.Point(12, 69);
            this.grbItem.Name = "grbItem";
            this.grbItem.Size = new System.Drawing.Size(588, 51);
            this.grbItem.TabIndex = 7;
            this.grbItem.TabStop = false;
            this.grbItem.Text = "Conferência OC";
            // 
            // btnItem
            // 
            this.btnItem.Enabled = false;
            this.btnItem.Location = new System.Drawing.Point(514, 16);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(47, 23);
            this.btnItem.TabIndex = 5;
            this.btnItem.Text = "OK";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // txtBarcodeOc
            // 
            this.txtBarcodeOc.Location = new System.Drawing.Point(119, 18);
            this.txtBarcodeOc.Multiline = true;
            this.txtBarcodeOc.Name = "txtBarcodeOc";
            this.txtBarcodeOc.Size = new System.Drawing.Size(389, 20);
            this.txtBarcodeOc.TabIndex = 1;
            this.txtBarcodeOc.TextChanged += new System.EventHandler(this.txtBarcodeOc_TextChanged);
            this.txtBarcodeOc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcodeOc_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Identificador da OC";
            // 
            // grbModoOperacao
            // 
            this.grbModoOperacao.Controls.Add(this.rdbBarCode);
            this.grbModoOperacao.Controls.Add(this.rdbManual);
            this.grbModoOperacao.Location = new System.Drawing.Point(12, 12);
            this.grbModoOperacao.Name = "grbModoOperacao";
            this.grbModoOperacao.Size = new System.Drawing.Size(185, 51);
            this.grbModoOperacao.TabIndex = 5;
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
            this.rdbBarCode.TabIndex = 2;
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
            this.rdbManual.TabIndex = 3;
            this.rdbManual.Text = "Manual";
            this.rdbManual.UseVisualStyleBackColor = true;
            this.rdbManual.CheckedChanged += new System.EventHandler(this.rdbManual_CheckedChanged);
            // 
            // grbCaixa
            // 
            this.grbCaixa.Controls.Add(this.label1);
            this.grbCaixa.Controls.Add(this.txtBarcodePallet);
            this.grbCaixa.Controls.Add(this.btnPallet);
            this.grbCaixa.Location = new System.Drawing.Point(245, 12);
            this.grbCaixa.Name = "grbCaixa";
            this.grbCaixa.Size = new System.Drawing.Size(355, 51);
            this.grbCaixa.TabIndex = 1;
            this.grbCaixa.TabStop = false;
            this.grbCaixa.Text = "Seleção do Pallet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificador do Pallet";
            // 
            // txtBarcodePallet
            // 
            this.txtBarcodePallet.Location = new System.Drawing.Point(126, 17);
            this.txtBarcodePallet.Name = "txtBarcodePallet";
            this.txtBarcodePallet.Size = new System.Drawing.Size(149, 20);
            this.txtBarcodePallet.TabIndex = 1;
            this.txtBarcodePallet.TextChanged += new System.EventHandler(this.txtBarcodePallet_TextChanged);
            this.txtBarcodePallet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcodePallet_KeyDown);
            // 
            // btnPallet
            // 
            this.btnPallet.Enabled = false;
            this.btnPallet.Location = new System.Drawing.Point(281, 15);
            this.btnPallet.Name = "btnPallet";
            this.btnPallet.Size = new System.Drawing.Size(47, 23);
            this.btnPallet.TabIndex = 4;
            this.btnPallet.Text = "OK";
            this.btnPallet.UseVisualStyleBackColor = true;
            this.btnPallet.Click += new System.EventHandler(this.btnPallet_Click);
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
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btnSalvar);
            this.splitContainer2.Size = new System.Drawing.Size(721, 435);
            this.splitContainer2.SplitterDistance = 388;
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
            this.splitContainer3.Panel1.Controls.Add(this.lstDisponiveis);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lstConferidos);
            this.splitContainer3.Size = new System.Drawing.Size(721, 388);
            this.splitContainer3.SplitterDistance = 356;
            this.splitContainer3.TabIndex = 0;
            // 
            // lstDisponiveis
            // 
            this.lstDisponiveis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDisponiveis.FormattingEnabled = true;
            this.lstDisponiveis.Location = new System.Drawing.Point(0, 0);
            this.lstDisponiveis.Name = "lstDisponiveis";
            this.lstDisponiveis.Size = new System.Drawing.Size(356, 388);
            this.lstDisponiveis.TabIndex = 0;
            // 
            // lstConferidos
            // 
            this.lstConferidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConferidos.FormattingEnabled = true;
            this.lstConferidos.Location = new System.Drawing.Point(0, 0);
            this.lstConferidos.Name = "lstConferidos";
            this.lstConferidos.Size = new System.Drawing.Size(361, 388);
            this.lstConferidos.Sorted = true;
            this.lstConferidos.TabIndex = 0;
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
            this.btnSalvar.Text = "Encerrar Conferência";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // timerPallet
            // 
            this.timerPallet.Tick += new System.EventHandler(this.timerPallet_Tick);
            // 
            // timerOC
            // 
            this.timerOC.Tick += new System.EventHandler(this.timerOC_Tick);
            // 
            // ConferenciaPalletForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(721, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConferenciaPalletForm";
            this.Text = "Conferência de Pallet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbItem.ResumeLayout(false);
            this.grbItem.PerformLayout();
            this.grbModoOperacao.ResumeLayout(false);
            this.grbModoOperacao.PerformLayout();
            this.grbCaixa.ResumeLayout(false);
            this.grbCaixa.PerformLayout();
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
        private System.Windows.Forms.GroupBox grbItem;
        private System.Windows.Forms.Button btnItem;
        private IWTCustomControls.BarcodeTextBox txtBarcodeOc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbModoOperacao;
        private System.Windows.Forms.RadioButton rdbBarCode;
        private System.Windows.Forms.RadioButton rdbManual;
        private System.Windows.Forms.GroupBox grbCaixa;
        private System.Windows.Forms.Label label1;
        private IWTCustomControls.BarcodeTextBox txtBarcodePallet;
        private System.Windows.Forms.Button btnPallet;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListBox lstDisponiveis;
        private System.Windows.Forms.ListBox lstConferidos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Timer timerPallet;
        private System.Windows.Forms.Timer timerOC;
    }
}