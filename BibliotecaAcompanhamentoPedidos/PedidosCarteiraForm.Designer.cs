namespace ModuloAcompanhamentoPedidos
{
    partial class PedidosCarteiraForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscaConferencia = new System.Windows.Forms.TextBox();
            this.lblQtdPedidos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkAtualizar = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFinalizado = new System.Windows.Forms.CheckBox();
            this.chkEmbarcado = new System.Windows.Forms.CheckBox();
            this.chkPalletConf = new System.Windows.Forms.CheckBox();
            this.chkConferido = new System.Windows.Forms.CheckBox();
            this.chkConfParcial = new System.Windows.Forms.CheckBox();
            this.chkFabricacao = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCancelado = new System.Windows.Forms.CheckBox();
            this.chkEncerrado = new System.Windows.Forms.CheckBox();
            this.chkPendente = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.btnFeedback = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnFeedback);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtBuscaConferencia);
            this.splitContainer1.Panel2.Controls.Add(this.lblQtdPedidos);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lnkAtualizar);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Size = new System.Drawing.Size(1007, 525);
            this.splitContainer1.SplitterDistance = 399;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1007, 399);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Busca Conferência";
            // 
            // txtBuscaConferencia
            // 
            this.txtBuscaConferencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaConferencia.Location = new System.Drawing.Point(115, 38);
            this.txtBuscaConferencia.Name = "txtBuscaConferencia";
            this.txtBuscaConferencia.Size = new System.Drawing.Size(273, 20);
            this.txtBuscaConferencia.TabIndex = 11;
            this.txtBuscaConferencia.TextChanged += new System.EventHandler(this.txtBuscaConferencia_TextChanged);
            // 
            // lblQtdPedidos
            // 
            this.lblQtdPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdPedidos.AutoSize = true;
            this.lblQtdPedidos.Location = new System.Drawing.Point(923, 54);
            this.lblQtdPedidos.Name = "lblQtdPedidos";
            this.lblQtdPedidos.Size = new System.Drawing.Size(0, 13);
            this.lblQtdPedidos.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(851, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade: ";
            // 
            // lnkAtualizar
            // 
            this.lnkAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAtualizar.AutoSize = true;
            this.lnkAtualizar.Location = new System.Drawing.Point(948, 101);
            this.lnkAtualizar.Name = "lnkAtualizar";
            this.lnkAtualizar.Size = new System.Drawing.Size(47, 13);
            this.lnkAtualizar.TabIndex = 10;
            this.lnkAtualizar.TabStop = true;
            this.lnkAtualizar.Text = "Atualizar";
            this.lnkAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizar_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkFinalizado);
            this.groupBox2.Controls.Add(this.chkEmbarcado);
            this.groupBox2.Controls.Add(this.chkPalletConf);
            this.groupBox2.Controls.Add(this.chkConferido);
            this.groupBox2.Controls.Add(this.chkConfParcial);
            this.groupBox2.Controls.Add(this.chkFabricacao);
            this.groupBox2.Location = new System.Drawing.Point(501, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 117);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // chkFinalizado
            // 
            this.chkFinalizado.AutoSize = true;
            this.chkFinalizado.Location = new System.Drawing.Point(6, 98);
            this.chkFinalizado.Name = "chkFinalizado";
            this.chkFinalizado.Size = new System.Drawing.Size(78, 17);
            this.chkFinalizado.TabIndex = 5;
            this.chkFinalizado.Text = "Finalizados";
            this.chkFinalizado.UseVisualStyleBackColor = true;
            this.chkFinalizado.CheckedChanged += new System.EventHandler(this.chkFinalizado_CheckedChanged);
            // 
            // chkEmbarcado
            // 
            this.chkEmbarcado.AutoSize = true;
            this.chkEmbarcado.Location = new System.Drawing.Point(6, 81);
            this.chkEmbarcado.Name = "chkEmbarcado";
            this.chkEmbarcado.Size = new System.Drawing.Size(85, 17);
            this.chkEmbarcado.TabIndex = 4;
            this.chkEmbarcado.Text = "Embarcados";
            this.chkEmbarcado.UseVisualStyleBackColor = true;
            this.chkEmbarcado.CheckedChanged += new System.EventHandler(this.chkEmbarcado_CheckedChanged);
            // 
            // chkPalletConf
            // 
            this.chkPalletConf.AutoSize = true;
            this.chkPalletConf.Location = new System.Drawing.Point(6, 64);
            this.chkPalletConf.Name = "chkPalletConf";
            this.chkPalletConf.Size = new System.Drawing.Size(100, 17);
            this.chkPalletConf.TabIndex = 3;
            this.chkPalletConf.Text = "Pallet Conferido";
            this.chkPalletConf.UseVisualStyleBackColor = true;
            this.chkPalletConf.CheckedChanged += new System.EventHandler(this.chkPalletConf_CheckedChanged);
            // 
            // chkConferido
            // 
            this.chkConferido.AutoSize = true;
            this.chkConferido.Location = new System.Drawing.Point(6, 47);
            this.chkConferido.Name = "chkConferido";
            this.chkConferido.Size = new System.Drawing.Size(144, 17);
            this.chkConferido.TabIndex = 2;
            this.chkConferido.Text = "Pedidos Conferidos Total";
            this.chkConferido.UseVisualStyleBackColor = true;
            this.chkConferido.CheckedChanged += new System.EventHandler(this.chkConferido_CheckedChanged);
            // 
            // chkConfParcial
            // 
            this.chkConfParcial.AutoSize = true;
            this.chkConfParcial.Location = new System.Drawing.Point(6, 30);
            this.chkConfParcial.Name = "chkConfParcial";
            this.chkConfParcial.Size = new System.Drawing.Size(127, 17);
            this.chkConfParcial.TabIndex = 1;
            this.chkConfParcial.Text = "Pedidos Conf. Parcial";
            this.chkConfParcial.UseVisualStyleBackColor = true;
            this.chkConfParcial.CheckedChanged += new System.EventHandler(this.chkConfParcial_CheckedChanged);
            // 
            // chkFabricacao
            // 
            this.chkFabricacao.AutoSize = true;
            this.chkFabricacao.Location = new System.Drawing.Point(6, 13);
            this.chkFabricacao.Name = "chkFabricacao";
            this.chkFabricacao.Size = new System.Drawing.Size(97, 17);
            this.chkFabricacao.TabIndex = 0;
            this.chkFabricacao.Text = "Em Fabricação";
            this.chkFabricacao.UseVisualStyleBackColor = true;
            this.chkFabricacao.CheckedChanged += new System.EventHandler(this.chkFabricacao_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkCancelado);
            this.groupBox1.Controls.Add(this.chkEncerrado);
            this.groupBox1.Controls.Add(this.chkPendente);
            this.groupBox1.Location = new System.Drawing.Point(394, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 117);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situação";
            // 
            // chkCancelado
            // 
            this.chkCancelado.AutoSize = true;
            this.chkCancelado.Location = new System.Drawing.Point(14, 47);
            this.chkCancelado.Name = "chkCancelado";
            this.chkCancelado.Size = new System.Drawing.Size(77, 17);
            this.chkCancelado.TabIndex = 2;
            this.chkCancelado.Text = "Cancelado";
            this.chkCancelado.UseVisualStyleBackColor = true;
            this.chkCancelado.CheckedChanged += new System.EventHandler(this.chkCancelado_CheckedChanged);
            // 
            // chkEncerrado
            // 
            this.chkEncerrado.AutoSize = true;
            this.chkEncerrado.Location = new System.Drawing.Point(14, 30);
            this.chkEncerrado.Name = "chkEncerrado";
            this.chkEncerrado.Size = new System.Drawing.Size(75, 17);
            this.chkEncerrado.TabIndex = 1;
            this.chkEncerrado.Text = "Encerrado";
            this.chkEncerrado.UseVisualStyleBackColor = true;
            this.chkEncerrado.CheckedChanged += new System.EventHandler(this.chkEncerrado_CheckedChanged);
            // 
            // chkPendente
            // 
            this.chkPendente.AutoSize = true;
            this.chkPendente.Checked = true;
            this.chkPendente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPendente.Location = new System.Drawing.Point(14, 13);
            this.chkPendente.Name = "chkPendente";
            this.chkPendente.Size = new System.Drawing.Size(72, 17);
            this.chkPendente.TabIndex = 0;
            this.chkPendente.Text = "Pendente";
            this.chkPendente.UseVisualStyleBackColor = true;
            this.chkPendente.CheckedChanged += new System.EventHandler(this.chkPendente_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Busca";
            // 
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusca.Location = new System.Drawing.Point(115, 12);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(273, 20);
            this.txtBusca.TabIndex = 4;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtOC_TextChanged);
            // 
            // timerBusca
            // 
            this.timerBusca.Interval = 200;
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // btnFeedback
            // 
            this.btnFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedback.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedback.Location = new System.Drawing.Point(874, 12);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(121, 23);
            this.btnFeedback.TabIndex = 13;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // PedidosCarteiraForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1007, 525);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PedidosCarteiraForm";
            this.Text = "Evolução dos Pedidos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQtdPedidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEncerrado;
        private System.Windows.Forms.CheckBox chkPendente;
        private System.Windows.Forms.CheckBox chkCancelado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkConferido;
        private System.Windows.Forms.CheckBox chkConfParcial;
        private System.Windows.Forms.CheckBox chkFabricacao;
        private System.Windows.Forms.LinkLabel lnkAtualizar;
        private System.Windows.Forms.CheckBox chkFinalizado;
        private System.Windows.Forms.CheckBox chkEmbarcado;
        private System.Windows.Forms.CheckBox chkPalletConf;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscaConferencia;
        private IWTDotNetLib.IWTButton btnFeedback;
    }
}