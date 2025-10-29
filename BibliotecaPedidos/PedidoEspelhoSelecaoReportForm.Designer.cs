namespace BibliotecaPedidos
{
    partial class PedidoEspelhoSelecaoReportForm
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
            this.cmbCliente = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtNumeroPedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnvioEmail = new System.Windows.Forms.CheckBox();
            this.chkEnviarEmailRepresentante = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.ColumnsToDisplay = null;
            this.cmbCliente.DropDownHeight = 1;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.IntegralHeight = false;
            this.cmbCliente.Location = new System.Drawing.Point(72, 34);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.SelectedRow = null;
            this.cmbCliente.Size = new System.Drawing.Size(252, 21);
            this.cmbCliente.TabIndex = 1;
            this.cmbCliente.Table = null;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Cliente";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(281, 135);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 37;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(12, 135);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 38;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtNumeroPedido
            // 
            this.txtNumeroPedido.Location = new System.Drawing.Point(72, 61);
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroPedido.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Pedido";
            // 
            // chkEnvioEmail
            // 
            this.chkEnvioEmail.AutoSize = true;
            this.chkEnvioEmail.Enabled = false;
            this.chkEnvioEmail.Location = new System.Drawing.Point(72, 87);
            this.chkEnvioEmail.Name = "chkEnvioEmail";
            this.chkEnvioEmail.Size = new System.Drawing.Size(168, 17);
            this.chkEnvioEmail.TabIndex = 42;
            this.chkEnvioEmail.Text = "Enviar para o e-mail do cliente";
            this.chkEnvioEmail.UseVisualStyleBackColor = true;
            // 
            // chkEnviarEmailRepresentante
            // 
            this.chkEnviarEmailRepresentante.AutoSize = true;
            this.chkEnviarEmailRepresentante.Location = new System.Drawing.Point(72, 105);
            this.chkEnviarEmailRepresentante.Name = "chkEnviarEmailRepresentante";
            this.chkEnviarEmailRepresentante.Size = new System.Drawing.Size(207, 17);
            this.chkEnviarEmailRepresentante.TabIndex = 43;
            this.chkEnviarEmailRepresentante.Text = "Enviar para o e-mail do Representante";
            this.chkEnviarEmailRepresentante.UseVisualStyleBackColor = true;
            // 
            // PedidoEspelhoSelecaoReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(368, 170);
            this.Controls.Add(this.chkEnviarEmailRepresentante);
            this.Controls.Add(this.chkEnvioEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumeroPedido);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCliente);
            this.Name = "PedidoEspelhoSelecaoReportForm";
            this.Text = "Impressão de Pedido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TextBox txtNumeroPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEnvioEmail;
        private System.Windows.Forms.CheckBox chkEnviarEmailRepresentante;
    }
}