namespace BibliotecaRelatoriosProducao
{
    partial class RelatorioPedidoDataEntradaForm
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
            this.btnGerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFim = new System.Windows.Forms.CheckBox();
            this.chkInicio = new System.Windows.Forms.CheckBox();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIncluirCancelados = new System.Windows.Forms.CheckBox();
            this.rdbOrdernarPedidos = new System.Windows.Forms.RadioButton();
            this.rdbOrdernaEntrega = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.Location = new System.Drawing.Point(189, 212);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Início";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(59, 23);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(114, 20);
            this.dtpInicio.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFim);
            this.groupBox1.Controls.Add(this.chkInicio);
            this.groupBox1.Controls.Add(this.dtpFim);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 87);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data de Entrada";
            // 
            // chkFim
            // 
            this.chkFim.AutoSize = true;
            this.chkFim.Checked = true;
            this.chkFim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFim.Location = new System.Drawing.Point(179, 52);
            this.chkFim.Name = "chkFim";
            this.chkFim.Size = new System.Drawing.Size(15, 14);
            this.chkFim.TabIndex = 6;
            this.chkFim.UseVisualStyleBackColor = true;
            this.chkFim.CheckedChanged += new System.EventHandler(this.chkFim_CheckedChanged);
            // 
            // chkInicio
            // 
            this.chkInicio.AutoSize = true;
            this.chkInicio.Checked = true;
            this.chkInicio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInicio.Location = new System.Drawing.Point(179, 26);
            this.chkInicio.Name = "chkInicio";
            this.chkInicio.Size = new System.Drawing.Size(15, 14);
            this.chkInicio.TabIndex = 5;
            this.chkInicio.UseVisualStyleBackColor = true;
            this.chkInicio.CheckedChanged += new System.EventHandler(this.chkInicio_CheckedChanged);
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(59, 49);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(114, 20);
            this.dtpFim.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fim";
            // 
            // chkIncluirCancelados
            // 
            this.chkIncluirCancelados.AutoSize = true;
            this.chkIncluirCancelados.Location = new System.Drawing.Point(12, 105);
            this.chkIncluirCancelados.Name = "chkIncluirCancelados";
            this.chkIncluirCancelados.Size = new System.Drawing.Size(154, 17);
            this.chkIncluirCancelados.TabIndex = 4;
            this.chkIncluirCancelados.Text = "Incluir Pedidos Cancelados";
            this.chkIncluirCancelados.UseVisualStyleBackColor = true;
            // 
            // rdbOrdernarPedidos
            // 
            this.rdbOrdernarPedidos.AutoSize = true;
            this.rdbOrdernarPedidos.Location = new System.Drawing.Point(6, 19);
            this.rdbOrdernarPedidos.Name = "rdbOrdernarPedidos";
            this.rdbOrdernarPedidos.Size = new System.Drawing.Size(122, 17);
            this.rdbOrdernarPedidos.TabIndex = 5;
            this.rdbOrdernarPedidos.Text = "Ordenar por Pedidos";
            this.rdbOrdernarPedidos.UseVisualStyleBackColor = true;
            // 
            // rdbOrdernaEntrega
            // 
            this.rdbOrdernaEntrega.AutoSize = true;
            this.rdbOrdernaEntrega.Checked = true;
            this.rdbOrdernaEntrega.Location = new System.Drawing.Point(6, 42);
            this.rdbOrdernaEntrega.Name = "rdbOrdernaEntrega";
            this.rdbOrdernaEntrega.Size = new System.Drawing.Size(162, 17);
            this.rdbOrdernaEntrega.TabIndex = 6;
            this.rdbOrdernaEntrega.TabStop = true;
            this.rdbOrdernaEntrega.Text = "Ordenar por Data de Entrega";
            this.rdbOrdernaEntrega.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbOrdernarPedidos);
            this.groupBox2.Controls.Add(this.rdbOrdernaEntrega);
            this.groupBox2.Location = new System.Drawing.Point(12, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 65);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenação Interna";
            // 
            // RelatorioPedidoDataEntradaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(276, 247);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkIncluirCancelados);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGerar);
            this.Name = "RelatorioPedidoDataEntradaForm";
            this.Text = "Pedidos por data de Entrada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFim;
        private System.Windows.Forms.CheckBox chkInicio;
        private System.Windows.Forms.CheckBox chkIncluirCancelados;
        private System.Windows.Forms.RadioButton rdbOrdernarPedidos;
        private System.Windows.Forms.RadioButton rdbOrdernaEntrega;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}