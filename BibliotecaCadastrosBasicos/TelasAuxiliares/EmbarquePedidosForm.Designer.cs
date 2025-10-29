namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    partial class EmbarquePedidosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtMaskedTextBox1 = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.btnBuscar = new IWTDotNetLib.IWTButton(this.components);
            this.dgvPedidos = new IWTDotNetLib.IWTDataGridView(this.components);
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeConferida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataConferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentificacaoEstacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentificacaoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volumes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 19);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(110, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Número do Embarque";
            // 
            // iwtMaskedTextBox1
            // 
            this.iwtMaskedTextBox1.BindingField = null;
            this.iwtMaskedTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtMaskedTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtMaskedTextBox1.Location = new System.Drawing.Point(132, 16);
            this.iwtMaskedTextBox1.Mask = "000000000";
            this.iwtMaskedTextBox1.Name = "iwtMaskedTextBox1";
            this.iwtMaskedTextBox1.Size = new System.Drawing.Size(80, 20);
            this.iwtMaskedTextBox1.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.LiberadoQuandoCadastroUtilizado = false;
            this.btnBuscar.Location = new System.Drawing.Point(218, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(36, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = ">>";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToOrderColumns = true;
            this.dgvPedidos.AllowUserToResizeRows = false;
            this.dgvPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.CacheDados = null;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNumber,
            this.OrderPos,
            this.CodigoItem,
            this.QuantidadeConferida,
            this.DataConferencia,
            this.IdentificacaoEstacao,
            this.IdentificacaoUsuario,
            this.Volumes});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.None;
            this.dgvPedidos.Location = new System.Drawing.Point(4, 43);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(632, 463);
            this.dgvPedidos.TabIndex = 3;
            // 
            // OrderNumber
            // 
            this.OrderNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "Pedido";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            this.OrderNumber.Width = 150;
            // 
            // OrderPos
            // 
            this.OrderPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderPos.DataPropertyName = "OrderPos";
            this.OrderPos.HeaderText = "Posição";
            this.OrderPos.Name = "OrderPos";
            this.OrderPos.ReadOnly = true;
            this.OrderPos.Width = 70;
            // 
            // CodigoItem
            // 
            this.CodigoItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodigoItem.DataPropertyName = "CodigoItem";
            this.CodigoItem.HeaderText = "Item";
            this.CodigoItem.Name = "CodigoItem";
            this.CodigoItem.ReadOnly = true;
            this.CodigoItem.Width = 150;
            // 
            // QuantidadeConferida
            // 
            this.QuantidadeConferida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuantidadeConferida.DataPropertyName = "QuantidadeConferida";
            this.QuantidadeConferida.HeaderText = "Quantidade";
            this.QuantidadeConferida.Name = "QuantidadeConferida";
            this.QuantidadeConferida.ReadOnly = true;
            // 
            // DataConferencia
            // 
            this.DataConferencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataConferencia.DataPropertyName = "DataConferencia";
            this.DataConferencia.HeaderText = "Data da Conferência";
            this.DataConferencia.Name = "DataConferencia";
            this.DataConferencia.ReadOnly = true;
            // 
            // IdentificacaoEstacao
            // 
            this.IdentificacaoEstacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdentificacaoEstacao.DataPropertyName = "IdentificacaoEstacao";
            this.IdentificacaoEstacao.HeaderText = "Estação da Conferência";
            this.IdentificacaoEstacao.Name = "IdentificacaoEstacao";
            this.IdentificacaoEstacao.ReadOnly = true;
            this.IdentificacaoEstacao.Width = 150;
            // 
            // IdentificacaoUsuario
            // 
            this.IdentificacaoUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdentificacaoUsuario.DataPropertyName = "IdentificacaoUsuario";
            this.IdentificacaoUsuario.HeaderText = "Usuário";
            this.IdentificacaoUsuario.Name = "IdentificacaoUsuario";
            this.IdentificacaoUsuario.ReadOnly = true;
            this.IdentificacaoUsuario.Width = 150;
            // 
            // Volumes
            // 
            this.Volumes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Volumes.DataPropertyName = "Volumes";
            this.Volumes.HeaderText = "Volumes";
            this.Volumes.Name = "Volumes";
            this.Volumes.ReadOnly = true;
            this.Volumes.Width = 70;
            // 
            // EmbarquePedidosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 510);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.iwtMaskedTextBox1);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "EmbarquePedidosForm";
            this.Text = "Pedidos do Embarque";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTMaskedTextBox iwtMaskedTextBox1;
        private IWTDotNetLib.IWTButton btnBuscar;
        private IWTDotNetLib.IWTDataGridView dgvPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeConferida;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataConferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificacaoEstacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificacaoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volumes;
    }
}