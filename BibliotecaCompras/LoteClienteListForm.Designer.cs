namespace BibliotecaCompras
{
    partial class LoteClienteListForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnForcarEncerramento = new System.Windows.Forms.Button();
            this.rdbCancelados = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbEncerrados = new System.Windows.Forms.RadioButton();
            this.rdbAbertos = new System.Windows.Forms.RadioButton();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.iwtButton1 = new IWTDotNetLib.IWTButton(this.components);
            this.iwtButton2 = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.iwtButton2);
            this.splitContainer1.Panel2.Controls.Add(this.iwtButton1);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnForcarEncerramento);
            this.splitContainer1.Panel2.Controls.Add(this.rdbCancelados);
            this.splitContainer1.Panel2.Controls.Add(this.rdbTodos);
            this.splitContainer1.Panel2.Controls.Add(this.rdbEncerrados);
            this.splitContainer1.Panel2.Controls.Add(this.rdbAbertos);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer1.Size = new System.Drawing.Size(731, 364);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 7;
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
            this.dataGridView1.Size = new System.Drawing.Size(731, 256);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(580, 69);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(139, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnForcarEncerramento
            // 
            this.btnForcarEncerramento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForcarEncerramento.Location = new System.Drawing.Point(426, 69);
            this.btnForcarEncerramento.Name = "btnForcarEncerramento";
            this.btnForcarEncerramento.Size = new System.Drawing.Size(148, 23);
            this.btnForcarEncerramento.TabIndex = 8;
            this.btnForcarEncerramento.Text = "Forçar Encerramento";
            this.btnForcarEncerramento.UseVisualStyleBackColor = true;
            this.btnForcarEncerramento.Click += new System.EventHandler(this.btnForcarEncerramento_Click);
            // 
            // rdbCancelados
            // 
            this.rdbCancelados.AutoSize = true;
            this.rdbCancelados.Location = new System.Drawing.Point(275, 53);
            this.rdbCancelados.Name = "rdbCancelados";
            this.rdbCancelados.Size = new System.Drawing.Size(81, 17);
            this.rdbCancelados.TabIndex = 3;
            this.rdbCancelados.Text = "Cancelados";
            this.rdbCancelados.UseVisualStyleBackColor = true;
            this.rdbCancelados.CheckedChanged += new System.EventHandler(this.rdbCancelados_CheckedChanged);
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(275, 71);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 4;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbEncerrados
            // 
            this.rdbEncerrados.AutoSize = true;
            this.rdbEncerrados.Location = new System.Drawing.Point(275, 35);
            this.rdbEncerrados.Name = "rdbEncerrados";
            this.rdbEncerrados.Size = new System.Drawing.Size(79, 17);
            this.rdbEncerrados.TabIndex = 2;
            this.rdbEncerrados.Text = "Encerrados";
            this.rdbEncerrados.UseVisualStyleBackColor = true;
            this.rdbEncerrados.CheckedChanged += new System.EventHandler(this.rdbEncerrados_CheckedChanged);
            // 
            // rdbAbertos
            // 
            this.rdbAbertos.AutoSize = true;
            this.rdbAbertos.Checked = true;
            this.rdbAbertos.Location = new System.Drawing.Point(275, 17);
            this.rdbAbertos.Name = "rdbAbertos";
            this.rdbAbertos.Size = new System.Drawing.Size(74, 17);
            this.rdbAbertos.TabIndex = 1;
            this.rdbAbertos.TabStop = true;
            this.rdbAbertos.Text = "Em Aberto";
            this.rdbAbertos.UseVisualStyleBackColor = true;
            this.rdbAbertos.CheckedChanged += new System.EventHandler(this.rdbPendentes_CheckedChanged);
            // 
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBusca.Location = new System.Drawing.Point(77, 49);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(177, 20);
            this.txtBusca.TabIndex = 0;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número Lote";
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.Location = new System.Drawing.Point(426, 11);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(293, 23);
            this.btnNovo.TabIndex = 5;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // timerBusca
            // 
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // iwtButton1
            // 
            this.iwtButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtButton1.Location = new System.Drawing.Point(426, 40);
            this.iwtButton1.Name = "iwtButton1";
            this.iwtButton1.Size = new System.Drawing.Size(148, 23);
            this.iwtButton1.TabIndex = 6;
            this.iwtButton1.Text = "Visualizar Dados";
            this.iwtButton1.UseVisualStyleBackColor = true;
            this.iwtButton1.Click += new System.EventHandler(this.iwtButton1_Click);
            // 
            // iwtButton2
            // 
            this.iwtButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtButton2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtButton2.Location = new System.Drawing.Point(580, 40);
            this.iwtButton2.Name = "iwtButton2";
            this.iwtButton2.Size = new System.Drawing.Size(139, 23);
            this.iwtButton2.TabIndex = 7;
            this.iwtButton2.Text = "Verificar Utilização";
            this.iwtButton2.UseVisualStyleBackColor = true;
            this.iwtButton2.Click += new System.EventHandler(this.iwtButton2_Click);
            // 
            // LoteClienteListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(731, 364);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LoteClienteListForm";
            this.Text = "Lotes de Materiais ou Produtos de Clientes";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbAbertos;
        private System.Windows.Forms.RadioButton rdbCancelados;
        private System.Windows.Forms.RadioButton rdbEncerrados;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnForcarEncerramento;
        private IWTDotNetLib.IWTButton iwtButton1;
        private IWTDotNetLib.IWTButton iwtButton2;
    }
}