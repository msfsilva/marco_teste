using IWTDotNetLib;

namespace BibliotecaPontosControle
{
    partial class PontoControleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtPostoTrabalho = new IWTDotNetLib.IWTTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrdemProducao = new IWTDotNetLib.IWTTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblRelogio = new System.Windows.Forms.Label();
            this.timerRelogio = new System.Windows.Forms.Timer(this.components);
            this.lblTextoTempo = new System.Windows.Forms.Label();
            this.rdbNormal = new System.Windows.Forms.RadioButton();
            this.rdbTrocarOperador = new System.Windows.Forms.RadioButton();
            this.rdbSuspender = new System.Windows.Forms.RadioButton();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblPosto = new System.Windows.Forms.Label();
            this.lblOp = new System.Windows.Forms.Label();
            this.grbHistoricoOP = new System.Windows.Forms.GroupBox();
            this.lstHistoricoOp = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            this.grbHistoricoOP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BindingField = null;
            this.txtUsuario.DebugMode = false;
            this.txtUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.txtUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtUsuario.Location = new System.Drawing.Point(29, 29);
            this.txtUsuario.ModoBarcode = true;
            this.txtUsuario.ModoBusca = false;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.NaoLimparDepoisBarcode = false;
            this.txtUsuario.ShortcutsEnabled = false;
            this.txtUsuario.Size = new System.Drawing.Size(306, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.OperacaoBarcodeEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBarcodeEncerradaDelegate(this.txtUsuario_OperacaoBarcodeEncerrada);
            // 
            // txtPostoTrabalho
            // 
            this.txtPostoTrabalho.BindingField = null;
            this.txtPostoTrabalho.DebugMode = false;
            this.txtPostoTrabalho.Enabled = false;
            this.txtPostoTrabalho.LiberadoQuandoCadastroUtilizado = false;
            this.txtPostoTrabalho.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtPostoTrabalho.Location = new System.Drawing.Point(29, 76);
            this.txtPostoTrabalho.ModoBarcode = true;
            this.txtPostoTrabalho.ModoBusca = false;
            this.txtPostoTrabalho.Name = "txtPostoTrabalho";
            this.txtPostoTrabalho.NaoLimparDepoisBarcode = false;
            this.txtPostoTrabalho.ShortcutsEnabled = false;
            this.txtPostoTrabalho.Size = new System.Drawing.Size(306, 20);
            this.txtPostoTrabalho.TabIndex = 1;
            this.txtPostoTrabalho.OperacaoBarcodeEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBarcodeEncerradaDelegate(this.txtPostoTrabalho_OperacaoBarcodeEncerrada);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Posto de Trabalho";
            // 
            // txtOrdemProducao
            // 
            this.txtOrdemProducao.BindingField = null;
            this.txtOrdemProducao.DebugMode = false;
            this.txtOrdemProducao.Enabled = false;
            this.txtOrdemProducao.LiberadoQuandoCadastroUtilizado = false;
            this.txtOrdemProducao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtOrdemProducao.Location = new System.Drawing.Point(29, 123);
            this.txtOrdemProducao.ModoBarcode = true;
            this.txtOrdemProducao.ModoBusca = false;
            this.txtOrdemProducao.Name = "txtOrdemProducao";
            this.txtOrdemProducao.NaoLimparDepoisBarcode = false;
            this.txtOrdemProducao.ShortcutsEnabled = false;
            this.txtOrdemProducao.Size = new System.Drawing.Size(306, 20);
            this.txtOrdemProducao.TabIndex = 2;
            this.txtOrdemProducao.OperacaoBarcodeEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBarcodeEncerradaDelegate(this.txtOrdemProducao_OperacaoBarcodeEncerrada);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ordem de Produção";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(12, 250);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 6;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Enabled = false;
            this.nudQuantidade.Location = new System.Drawing.Point(29, 266);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(306, 20);
            this.nudQuantidade.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(276, 354);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpar.Location = new System.Drawing.Point(12, 354);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 5;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblRelogio
            // 
            this.lblRelogio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblRelogio.Location = new System.Drawing.Point(95, 354);
            this.lblRelogio.Name = "lblRelogio";
            this.lblRelogio.Size = new System.Drawing.Size(172, 23);
            this.lblRelogio.TabIndex = 10;
            this.lblRelogio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerRelogio
            // 
            this.timerRelogio.Enabled = true;
            this.timerRelogio.Interval = 1000;
            this.timerRelogio.Tick += new System.EventHandler(this.timerRelogio_Tick);
            // 
            // lblTextoTempo
            // 
            this.lblTextoTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTextoTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoTempo.Location = new System.Drawing.Point(12, 325);
            this.lblTextoTempo.Name = "lblTextoTempo";
            this.lblTextoTempo.Size = new System.Drawing.Size(334, 23);
            this.lblTextoTempo.TabIndex = 11;
            this.lblTextoTempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbNormal
            // 
            this.rdbNormal.AutoSize = true;
            this.rdbNormal.Checked = true;
            this.rdbNormal.Location = new System.Drawing.Point(20, 305);
            this.rdbNormal.Name = "rdbNormal";
            this.rdbNormal.Size = new System.Drawing.Size(58, 17);
            this.rdbNormal.TabIndex = 12;
            this.rdbNormal.TabStop = true;
            this.rdbNormal.Text = "Normal";
            this.rdbNormal.UseVisualStyleBackColor = true;
            // 
            // rdbTrocarOperador
            // 
            this.rdbTrocarOperador.AutoSize = true;
            this.rdbTrocarOperador.Location = new System.Drawing.Point(103, 305);
            this.rdbTrocarOperador.Name = "rdbTrocarOperador";
            this.rdbTrocarOperador.Size = new System.Drawing.Size(135, 17);
            this.rdbTrocarOperador.TabIndex = 13;
            this.rdbTrocarOperador.TabStop = true;
            this.rdbTrocarOperador.Text = "Trocar Operador / Lote";
            this.rdbTrocarOperador.UseVisualStyleBackColor = true;
            // 
            // rdbSuspender
            // 
            this.rdbSuspender.AutoSize = true;
            this.rdbSuspender.Location = new System.Drawing.Point(263, 305);
            this.rdbSuspender.Name = "rdbSuspender";
            this.rdbSuspender.Size = new System.Drawing.Size(76, 17);
            this.rdbSuspender.TabIndex = 14;
            this.rdbSuspender.TabStop = true;
            this.rdbSuspender.Text = "Suspender";
            this.rdbSuspender.UseVisualStyleBackColor = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(139, 13);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(196, 13);
            this.lblUsuario.TabIndex = 15;
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPosto
            // 
            this.lblPosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosto.Location = new System.Drawing.Point(139, 60);
            this.lblPosto.Name = "lblPosto";
            this.lblPosto.Size = new System.Drawing.Size(193, 13);
            this.lblPosto.TabIndex = 16;
            this.lblPosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOp
            // 
            this.lblOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOp.Location = new System.Drawing.Point(142, 107);
            this.lblOp.Name = "lblOp";
            this.lblOp.Size = new System.Drawing.Size(193, 13);
            this.lblOp.TabIndex = 17;
            this.lblOp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbHistoricoOP
            // 
            this.grbHistoricoOP.Controls.Add(this.lstHistoricoOp);
            this.grbHistoricoOP.Location = new System.Drawing.Point(29, 149);
            this.grbHistoricoOP.Name = "grbHistoricoOP";
            this.grbHistoricoOP.Size = new System.Drawing.Size(306, 89);
            this.grbHistoricoOP.TabIndex = 18;
            this.grbHistoricoOP.TabStop = false;
            this.grbHistoricoOP.Text = "Histórico OP";
            // 
            // lstHistoricoOp
            // 
            this.lstHistoricoOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHistoricoOp.FormattingEnabled = true;
            this.lstHistoricoOp.Location = new System.Drawing.Point(3, 16);
            this.lstHistoricoOp.Name = "lstHistoricoOp";
            this.lstHistoricoOp.ScrollAlwaysVisible = true;
            this.lstHistoricoOp.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstHistoricoOp.Size = new System.Drawing.Size(300, 70);
            this.lstHistoricoOp.TabIndex = 0;
            // 
            // PontoControleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(363, 389);
            this.Controls.Add(this.grbHistoricoOP);
            this.Controls.Add(this.lblOp);
            this.Controls.Add(this.lblPosto);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.rdbSuspender);
            this.Controls.Add(this.rdbTrocarOperador);
            this.Controls.Add(this.rdbNormal);
            this.Controls.Add(this.lblTextoTempo);
            this.Controls.Add(this.lblRelogio);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtOrdemProducao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPostoTrabalho);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.Name = "PontoControleForm";
            this.Text = "Ponto de Controle";
            this.Load += new System.EventHandler(this.PontoControleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.grbHistoricoOP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private IWTTextBox txtUsuario;
        private IWTTextBox txtPostoTrabalho;
        private System.Windows.Forms.Label label2;
        private IWTTextBox txtOrdemProducao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblRelogio;
        private System.Windows.Forms.Timer timerRelogio;
        private System.Windows.Forms.Label lblTextoTempo;
        private System.Windows.Forms.RadioButton rdbNormal;
        private System.Windows.Forms.RadioButton rdbTrocarOperador;
        private System.Windows.Forms.RadioButton rdbSuspender;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPosto;
        private System.Windows.Forms.Label lblOp;
        private System.Windows.Forms.GroupBox grbHistoricoOP;
        private System.Windows.Forms.ListBox lstHistoricoOp;
    }
}