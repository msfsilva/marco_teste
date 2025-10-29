namespace BibliotecaEntidades.Operacoes.CalculoPreco
{
    partial class SimuladorCalculoPrecoForm
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
            this.txtOc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.MaskedTextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblValorCalculado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCliente = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.rdbPedido = new System.Windows.Forms.RadioButton();
            this.rdbOrcamento = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // txtOc
            // 
            this.txtOc.Location = new System.Drawing.Point(24, 101);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(148, 20);
            this.txtOc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "/";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(196, 101);
            this.txtPos.Mask = "000";
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(36, 20);
            this.txtPos.TabIndex = 5;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcular.Location = new System.Drawing.Point(242, 349);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblValorCalculado
            // 
            this.lblValorCalculado.AutoSize = true;
            this.lblValorCalculado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCalculado.Location = new System.Drawing.Point(102, 168);
            this.lblValorCalculado.Name = "lblValorCalculado";
            this.lblValorCalculado.Size = new System.Drawing.Size(0, 13);
            this.lblValorCalculado.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Valor Calculado:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(15, 215);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(292, 118);
            this.textBox1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Log do Cálculo:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.ColumnsToDisplay = null;
            this.cmbCliente.DisableAutoSelectOnEmpty = false;
            this.cmbCliente.DropDownHeight = 1;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.IntegralHeight = false;
            this.cmbCliente.Location = new System.Drawing.Point(24, 25);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.SelectedRow = null;
            this.cmbCliente.Size = new System.Drawing.Size(283, 21);
            this.cmbCliente.TabIndex = 11;
            this.cmbCliente.Table = null;
            // 
            // rdbPedido
            // 
            this.rdbPedido.AutoSize = true;
            this.rdbPedido.Checked = true;
            this.rdbPedido.Enabled = false;
            this.rdbPedido.Location = new System.Drawing.Point(15, 78);
            this.rdbPedido.Name = "rdbPedido";
            this.rdbPedido.Size = new System.Drawing.Size(58, 17);
            this.rdbPedido.TabIndex = 12;
            this.rdbPedido.TabStop = true;
            this.rdbPedido.Text = "Pedido";
            this.rdbPedido.UseVisualStyleBackColor = true;
            // 
            // rdbOrcamento
            // 
            this.rdbOrcamento.AutoSize = true;
            this.rdbOrcamento.Enabled = false;
            this.rdbOrcamento.Location = new System.Drawing.Point(118, 78);
            this.rdbOrcamento.Name = "rdbOrcamento";
            this.rdbOrcamento.Size = new System.Drawing.Size(77, 17);
            this.rdbOrcamento.TabIndex = 13;
            this.rdbOrcamento.Text = "Orçamento";
            this.rdbOrcamento.UseVisualStyleBackColor = true;
            // 
            // SimuladorCalculoPrecoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(329, 384);
            this.Controls.Add(this.rdbOrcamento);
            this.Controls.Add(this.rdbPedido);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblValorCalculado);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOc);
            this.Controls.Add(this.label1);
            this.Name = "SimuladorCalculoPrecoForm";
            this.Text = "Simulador de Cálculo de Preço";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtPos;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblValorCalculado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbCliente;
        private System.Windows.Forms.RadioButton rdbPedido;
        private System.Windows.Forms.RadioButton rdbOrcamento;
    }
}