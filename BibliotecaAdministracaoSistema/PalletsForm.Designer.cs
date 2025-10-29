namespace BibliotecaAdministracaoSistema
{
    partial class PalletsForm
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
            this.btnFechamento = new System.Windows.Forms.Button();
            this.btnDesfazerConferencia = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLiberar = new System.Windows.Forms.Button();
            this.btnBloquear = new System.Windows.Forms.Button();
            this.btnAlterarPallet = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbConferidoTodos = new System.Windows.Forms.RadioButton();
            this.rdbConferidoNao = new System.Windows.Forms.RadioButton();
            this.rdbConferidoSim = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbFechadoTodos = new System.Windows.Forms.RadioButton();
            this.rdbFechadoNao = new System.Windows.Forms.RadioButton();
            this.rdbFechadoSim = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbOcupadoTodos = new System.Windows.Forms.RadioButton();
            this.rdbOcupadoNao = new System.Windows.Forms.RadioButton();
            this.rdbOcupadoSim = new System.Windows.Forms.RadioButton();
            this.lnkAtualizar = new System.Windows.Forms.LinkLabel();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnFechamento);
            this.splitContainer1.Panel2.Controls.Add(this.btnDesfazerConferencia);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.btnLiberar);
            this.splitContainer1.Panel2.Controls.Add(this.btnBloquear);
            this.splitContainer1.Panel2.Controls.Add(this.btnAlterarPallet);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lnkAtualizar);
            this.splitContainer1.Panel2.Controls.Add(this.txtNumero);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(683, 367);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
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
            this.dataGridView1.Size = new System.Drawing.Size(683, 266);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnFechamento
            // 
            this.btnFechamento.Location = new System.Drawing.Point(557, 19);
            this.btnFechamento.Name = "btnFechamento";
            this.btnFechamento.Size = new System.Drawing.Size(123, 23);
            this.btnFechamento.TabIndex = 10;
            this.btnFechamento.Text = "Forçar Fechamento";
            this.btnFechamento.UseVisualStyleBackColor = true;
            this.btnFechamento.Click += new System.EventHandler(this.btnFechamento_Click);
            // 
            // btnDesfazerConferencia
            // 
            this.btnDesfazerConferencia.Location = new System.Drawing.Point(557, 65);
            this.btnDesfazerConferencia.Name = "btnDesfazerConferencia";
            this.btnDesfazerConferencia.Size = new System.Drawing.Size(123, 23);
            this.btnDesfazerConferencia.TabIndex = 8;
            this.btnDesfazerConferencia.Text = "Desfazer Conferência";
            this.btnDesfazerConferencia.UseVisualStyleBackColor = true;
            this.btnDesfazerConferencia.Click += new System.EventHandler(this.btnDesfazerConferencia_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Liberar Utilizado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.Location = new System.Drawing.Point(451, 65);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(100, 23);
            this.btnLiberar.TabIndex = 6;
            this.btnLiberar.Text = "Forçar Liberação";
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.Location = new System.Drawing.Point(557, 42);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(123, 23);
            this.btnBloquear.TabIndex = 7;
            this.btnBloquear.Text = "Bloquear/Desbloquear";
            this.btnBloquear.UseVisualStyleBackColor = true;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // btnAlterarPallet
            // 
            this.btnAlterarPallet.Location = new System.Drawing.Point(451, 19);
            this.btnAlterarPallet.Name = "btnAlterarPallet";
            this.btnAlterarPallet.Size = new System.Drawing.Size(100, 23);
            this.btnAlterarPallet.TabIndex = 4;
            this.btnAlterarPallet.Text = "Alterar Pallet";
            this.btnAlterarPallet.UseVisualStyleBackColor = true;
            this.btnAlterarPallet.Click += new System.EventHandler(this.btnAlterarPallet_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbConferidoTodos);
            this.groupBox3.Controls.Add(this.rdbConferidoNao);
            this.groupBox3.Controls.Add(this.rdbConferidoSim);
            this.groupBox3.Location = new System.Drawing.Point(365, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(80, 77);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conferidos";
            // 
            // rdbConferidoTodos
            // 
            this.rdbConferidoTodos.AutoSize = true;
            this.rdbConferidoTodos.Checked = true;
            this.rdbConferidoTodos.Location = new System.Drawing.Point(6, 53);
            this.rdbConferidoTodos.Name = "rdbConferidoTodos";
            this.rdbConferidoTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbConferidoTodos.TabIndex = 2;
            this.rdbConferidoTodos.TabStop = true;
            this.rdbConferidoTodos.Text = "Todos";
            this.rdbConferidoTodos.UseVisualStyleBackColor = true;
            this.rdbConferidoTodos.CheckedChanged += new System.EventHandler(this.rdbConferidoTodos_CheckedChanged);
            // 
            // rdbConferidoNao
            // 
            this.rdbConferidoNao.AutoSize = true;
            this.rdbConferidoNao.Location = new System.Drawing.Point(6, 36);
            this.rdbConferidoNao.Name = "rdbConferidoNao";
            this.rdbConferidoNao.Size = new System.Drawing.Size(45, 17);
            this.rdbConferidoNao.TabIndex = 1;
            this.rdbConferidoNao.Text = "Não";
            this.rdbConferidoNao.UseVisualStyleBackColor = true;
            this.rdbConferidoNao.CheckedChanged += new System.EventHandler(this.rdbConferidoNao_CheckedChanged);
            // 
            // rdbConferidoSim
            // 
            this.rdbConferidoSim.AutoSize = true;
            this.rdbConferidoSim.Location = new System.Drawing.Point(6, 18);
            this.rdbConferidoSim.Name = "rdbConferidoSim";
            this.rdbConferidoSim.Size = new System.Drawing.Size(42, 17);
            this.rdbConferidoSim.TabIndex = 0;
            this.rdbConferidoSim.Text = "Sim";
            this.rdbConferidoSim.UseVisualStyleBackColor = true;
            this.rdbConferidoSim.CheckedChanged += new System.EventHandler(this.rdbConferidoSim_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbFechadoTodos);
            this.groupBox2.Controls.Add(this.rdbFechadoNao);
            this.groupBox2.Controls.Add(this.rdbFechadoSim);
            this.groupBox2.Location = new System.Drawing.Point(274, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fechados";
            // 
            // rdbFechadoTodos
            // 
            this.rdbFechadoTodos.AutoSize = true;
            this.rdbFechadoTodos.Checked = true;
            this.rdbFechadoTodos.Location = new System.Drawing.Point(6, 53);
            this.rdbFechadoTodos.Name = "rdbFechadoTodos";
            this.rdbFechadoTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbFechadoTodos.TabIndex = 2;
            this.rdbFechadoTodos.TabStop = true;
            this.rdbFechadoTodos.Text = "Todos";
            this.rdbFechadoTodos.UseVisualStyleBackColor = true;
            this.rdbFechadoTodos.CheckedChanged += new System.EventHandler(this.rdbFechadoTodos_CheckedChanged);
            // 
            // rdbFechadoNao
            // 
            this.rdbFechadoNao.AutoSize = true;
            this.rdbFechadoNao.Location = new System.Drawing.Point(6, 36);
            this.rdbFechadoNao.Name = "rdbFechadoNao";
            this.rdbFechadoNao.Size = new System.Drawing.Size(45, 17);
            this.rdbFechadoNao.TabIndex = 1;
            this.rdbFechadoNao.Text = "Não";
            this.rdbFechadoNao.UseVisualStyleBackColor = true;
            this.rdbFechadoNao.CheckedChanged += new System.EventHandler(this.rdbFechadoNao_CheckedChanged);
            // 
            // rdbFechadoSim
            // 
            this.rdbFechadoSim.AutoSize = true;
            this.rdbFechadoSim.Location = new System.Drawing.Point(6, 18);
            this.rdbFechadoSim.Name = "rdbFechadoSim";
            this.rdbFechadoSim.Size = new System.Drawing.Size(42, 17);
            this.rdbFechadoSim.TabIndex = 0;
            this.rdbFechadoSim.Text = "Sim";
            this.rdbFechadoSim.UseVisualStyleBackColor = true;
            this.rdbFechadoSim.CheckedChanged += new System.EventHandler(this.rdbFechadoSim_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbOcupadoTodos);
            this.groupBox1.Controls.Add(this.rdbOcupadoNao);
            this.groupBox1.Controls.Add(this.rdbOcupadoSim);
            this.groupBox1.Location = new System.Drawing.Point(183, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ocupados";
            // 
            // rdbOcupadoTodos
            // 
            this.rdbOcupadoTodos.AutoSize = true;
            this.rdbOcupadoTodos.Checked = true;
            this.rdbOcupadoTodos.Location = new System.Drawing.Point(6, 53);
            this.rdbOcupadoTodos.Name = "rdbOcupadoTodos";
            this.rdbOcupadoTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbOcupadoTodos.TabIndex = 2;
            this.rdbOcupadoTodos.TabStop = true;
            this.rdbOcupadoTodos.Text = "Todos";
            this.rdbOcupadoTodos.UseVisualStyleBackColor = true;
            this.rdbOcupadoTodos.CheckedChanged += new System.EventHandler(this.rdbOcupadoTodos_CheckedChanged);
            // 
            // rdbOcupadoNao
            // 
            this.rdbOcupadoNao.AutoSize = true;
            this.rdbOcupadoNao.Location = new System.Drawing.Point(6, 36);
            this.rdbOcupadoNao.Name = "rdbOcupadoNao";
            this.rdbOcupadoNao.Size = new System.Drawing.Size(45, 17);
            this.rdbOcupadoNao.TabIndex = 1;
            this.rdbOcupadoNao.Text = "Não";
            this.rdbOcupadoNao.UseVisualStyleBackColor = true;
            this.rdbOcupadoNao.CheckedChanged += new System.EventHandler(this.rdbOcupadoNao_CheckedChanged);
            // 
            // rdbOcupadoSim
            // 
            this.rdbOcupadoSim.AutoSize = true;
            this.rdbOcupadoSim.Location = new System.Drawing.Point(6, 19);
            this.rdbOcupadoSim.Name = "rdbOcupadoSim";
            this.rdbOcupadoSim.Size = new System.Drawing.Size(42, 17);
            this.rdbOcupadoSim.TabIndex = 0;
            this.rdbOcupadoSim.Text = "Sim";
            this.rdbOcupadoSim.UseVisualStyleBackColor = true;
            this.rdbOcupadoSim.CheckedChanged += new System.EventHandler(this.rdbOcupadoSim_CheckedChanged);
            // 
            // lnkAtualizar
            // 
            this.lnkAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAtualizar.AutoSize = true;
            this.lnkAtualizar.Location = new System.Drawing.Point(633, 0);
            this.lnkAtualizar.Name = "lnkAtualizar";
            this.lnkAtualizar.Size = new System.Drawing.Size(47, 13);
            this.lnkAtualizar.TabIndex = 9;
            this.lnkAtualizar.TabStop = true;
            this.lnkAtualizar.Text = "Atualizar";
            this.lnkAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizar_LinkClicked);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(62, 28);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PalletsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(683, 367);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PalletsForm";
            this.Text = "Situação dos Pallets";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel lnkAtualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbFechadoNao;
        private System.Windows.Forms.RadioButton rdbFechadoSim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbOcupadoNao;
        private System.Windows.Forms.RadioButton rdbOcupadoSim;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rdbOcupadoTodos;
        private System.Windows.Forms.RadioButton rdbFechadoTodos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbConferidoTodos;
        private System.Windows.Forms.RadioButton rdbConferidoNao;
        private System.Windows.Forms.RadioButton rdbConferidoSim;
        private System.Windows.Forms.Button btnAlterarPallet;
        private System.Windows.Forms.Button btnBloquear;
        private System.Windows.Forms.Button btnLiberar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDesfazerConferencia;
        private System.Windows.Forms.Button btnFechamento;
    }
}