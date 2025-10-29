namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    partial class PedidosConfiguradorForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDesfazer = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BotaoVariaveisPedido = new IWTDotNetLib.IWTButton(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnFeedback = new IWTDotNetLib.IWTButton(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSuspensos = new System.Windows.Forms.CheckBox();
            this.rdbAtrasados = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbEncerrados = new System.Windows.Forms.RadioButton();
            this.rdbPendentes = new System.Windows.Forms.RadioButton();
            this.lblQtdPedidos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbConfigurado = new System.Windows.Forms.RadioButton();
            this.rdbNaoConfigurados = new System.Windows.Forms.RadioButton();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(1061, 299);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(52, 21);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(203, 20);
            this.txtBusca.TabIndex = 4;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pedido";
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesfazer.Location = new System.Drawing.Point(920, 27);
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.Size = new System.Drawing.Size(129, 23);
            this.btnDesfazer.TabIndex = 2;
            this.btnDesfazer.Text = "Desfazer Configuração";
            this.btnDesfazer.UseVisualStyleBackColor = true;
            this.btnDesfazer.Click += new System.EventHandler(this.btnDesfazer_Click);
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
            this.splitContainer1.Panel2.Controls.Add(this.BotaoVariaveisPedido);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.btnFeedback);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lblQtdPedidos);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.rdbConfigurado);
            this.splitContainer1.Panel2.Controls.Add(this.rdbNaoConfigurados);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnDesfazer);
            this.splitContainer1.Panel2.Controls.Add(this.btnConfigurar);
            this.splitContainer1.Size = new System.Drawing.Size(1061, 419);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 4;
            // 
            // BotaoVariaveisPedido
            // 
            this.BotaoVariaveisPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotaoVariaveisPedido.LiberadoQuandoCadastroUtilizado = false;
            this.BotaoVariaveisPedido.Location = new System.Drawing.Point(839, 85);
            this.BotaoVariaveisPedido.Name = "BotaoVariaveisPedido";
            this.BotaoVariaveisPedido.Size = new System.Drawing.Size(75, 23);
            this.BotaoVariaveisPedido.TabIndex = 14;
            this.BotaoVariaveisPedido.Text = "Variáveis";
            this.BotaoVariaveisPedido.UseVisualStyleBackColor = true;
            this.BotaoVariaveisPedido.Click += new System.EventHandler(this.BotaoVariaveisPedido_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(920, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Verificar Variáveis";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFeedback
            // 
            this.btnFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedback.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedback.Location = new System.Drawing.Point(839, 56);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(75, 23);
            this.btnFeedback.TabIndex = 12;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(616, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 40);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Legenda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pedidos cujo produto está em revisão";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSuspensos);
            this.groupBox1.Controls.Add(this.rdbAtrasados);
            this.groupBox1.Controls.Add(this.rdbTodos);
            this.groupBox1.Controls.Add(this.rdbEncerrados);
            this.groupBox1.Controls.Add(this.rdbPendentes);
            this.groupBox1.Location = new System.Drawing.Point(277, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 56);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situação do Pedido";
            // 
            // chkSuspensos
            // 
            this.chkSuspensos.AutoSize = true;
            this.chkSuspensos.Location = new System.Drawing.Point(12, 33);
            this.chkSuspensos.Name = "chkSuspensos";
            this.chkSuspensos.Size = new System.Drawing.Size(109, 17);
            this.chkSuspensos.TabIndex = 4;
            this.chkSuspensos.Text = "Incluir Suspensos";
            this.chkSuspensos.UseVisualStyleBackColor = true;
            this.chkSuspensos.CheckedChanged += new System.EventHandler(this.chkSuspensos_CheckedChanged);
            this.chkSuspensos.EnabledChanged += new System.EventHandler(this.chkSuspensos_EnabledChanged);
            // 
            // rdbAtrasados
            // 
            this.rdbAtrasados.AutoSize = true;
            this.rdbAtrasados.Location = new System.Drawing.Point(94, 14);
            this.rdbAtrasados.Name = "rdbAtrasados";
            this.rdbAtrasados.Size = new System.Drawing.Size(72, 17);
            this.rdbAtrasados.TabIndex = 3;
            this.rdbAtrasados.Text = "Atrasados";
            this.rdbAtrasados.UseVisualStyleBackColor = true;
            this.rdbAtrasados.CheckedChanged += new System.EventHandler(this.rdbAtrasados_CheckedChanged);
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(257, 14);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 2;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbEncerrados
            // 
            this.rdbEncerrados.AutoSize = true;
            this.rdbEncerrados.Location = new System.Drawing.Point(172, 14);
            this.rdbEncerrados.Name = "rdbEncerrados";
            this.rdbEncerrados.Size = new System.Drawing.Size(79, 17);
            this.rdbEncerrados.TabIndex = 1;
            this.rdbEncerrados.Text = "Encerrados";
            this.rdbEncerrados.UseVisualStyleBackColor = true;
            this.rdbEncerrados.CheckedChanged += new System.EventHandler(this.rdbEncerrados_CheckedChanged);
            // 
            // rdbPendentes
            // 
            this.rdbPendentes.AutoSize = true;
            this.rdbPendentes.Checked = true;
            this.rdbPendentes.Location = new System.Drawing.Point(12, 14);
            this.rdbPendentes.Name = "rdbPendentes";
            this.rdbPendentes.Size = new System.Drawing.Size(76, 17);
            this.rdbPendentes.TabIndex = 0;
            this.rdbPendentes.TabStop = true;
            this.rdbPendentes.Text = "Pendentes";
            this.rdbPendentes.UseVisualStyleBackColor = true;
            this.rdbPendentes.CheckedChanged += new System.EventHandler(this.rdbPendentes_CheckedChanged);
            // 
            // lblQtdPedidos
            // 
            this.lblQtdPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdPedidos.AutoSize = true;
            this.lblQtdPedidos.Location = new System.Drawing.Point(981, 5);
            this.lblQtdPedidos.Name = "lblQtdPedidos";
            this.lblQtdPedidos.Size = new System.Drawing.Size(0, 13);
            this.lblQtdPedidos.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(854, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quantidade de Pedidos:";
            // 
            // rdbConfigurado
            // 
            this.rdbConfigurado.AutoSize = true;
            this.rdbConfigurado.Location = new System.Drawing.Point(168, 51);
            this.rdbConfigurado.Name = "rdbConfigurado";
            this.rdbConfigurado.Size = new System.Drawing.Size(87, 17);
            this.rdbConfigurado.TabIndex = 6;
            this.rdbConfigurado.Text = "Configurados";
            this.rdbConfigurado.UseVisualStyleBackColor = true;
            this.rdbConfigurado.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbNaoConfigurados
            // 
            this.rdbNaoConfigurados.AutoSize = true;
            this.rdbNaoConfigurados.Checked = true;
            this.rdbNaoConfigurados.Location = new System.Drawing.Point(52, 51);
            this.rdbNaoConfigurados.Name = "rdbNaoConfigurados";
            this.rdbNaoConfigurados.Size = new System.Drawing.Size(110, 17);
            this.rdbNaoConfigurados.TabIndex = 5;
            this.rdbNaoConfigurados.TabStop = true;
            this.rdbNaoConfigurados.Text = "Não Configurados";
            this.rdbNaoConfigurados.UseVisualStyleBackColor = true;
            this.rdbNaoConfigurados.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigurar.Location = new System.Drawing.Point(839, 27);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(75, 23);
            this.btnConfigurar.TabIndex = 1;
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // timerBusca
            // 
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // PedidosConfiguradorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1061, 419);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PedidosConfiguradorForm";
            this.Text = "Pedidos Configurados / Não Configurados";
            this.Shown += new System.EventHandler(this.PedidosConfiguradorForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDesfazer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rdbConfigurado;
        private System.Windows.Forms.RadioButton rdbNaoConfigurados;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.Label lblQtdPedidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbEncerrados;
        private System.Windows.Forms.RadioButton rdbPendentes;
        private System.Windows.Forms.RadioButton rdbAtrasados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSuspensos;
        private IWTDotNetLib.IWTButton btnFeedback;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private IWTDotNetLib.IWTButton BotaoVariaveisPedido;
    }
}