namespace BibliotecaCadastrosBasicos
{
    partial class CadProgramacaoForm
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
            this.NomeLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Nome = new IWTDotNetLib.IWTTextBox(this.components);
            this.dgPedidos = new IWTDotNetLib.IWTDataGridView(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.labUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.labData = new IWTDotNetLib.IWTLabel(this.components);
            this.Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemanaEntregaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusTraduzidoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.labData);
            this.splitContainer1.Panel1.Controls.Add(this.labUsuario);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.dgPedidos);
            this.splitContainer1.Panel1.Controls.Add(this.NomeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Nome);
            this.splitContainer1.Size = new System.Drawing.Size(798, 480);
            this.splitContainer1.SplitterDistance = 414;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.Text = "   Fechar";
            // 
            // btnSalvar
            // 
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(711, 20);
            this.btnSalvar.Size = new System.Drawing.Size(75, 25);
            this.btnSalvar.Text = "   Salvar";
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.BindingField = null;
            this.NomeLabel.LiberadoQuandoCadastroUtilizado = false;
            this.NomeLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.NomeLabel.Location = new System.Drawing.Point(67, 16);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(35, 13);
            this.NomeLabel.TabIndex = 0;
            this.NomeLabel.Text = "Nome";
            // 
            // Nome
            // 
            this.Nome.BindingField = "Nome";
            this.Nome.DebugMode = false;
            this.Nome.LiberadoQuandoCadastroUtilizado = false;
            this.Nome.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Nome.Location = new System.Drawing.Point(106, 12);
            this.Nome.MaxLength = 255;
            this.Nome.ModoBarcode = false;
            this.Nome.ModoBusca = false;
            this.Nome.Name = "Nome";
            this.Nome.NaoLimparDepoisBarcode = false;
            this.Nome.Size = new System.Drawing.Size(552, 20);
            this.Nome.TabIndex = 1;
            // 
            // dgPedidos
            // 
            this.dgPedidos.AllowUserToAddRows = false;
            this.dgPedidos.AllowUserToDeleteRows = false;
            this.dgPedidos.AllowUserToOrderColumns = true;
            this.dgPedidos.AllowUserToResizeRows = false;
            this.dgPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgPedidos.CacheDados = null;
            this.dgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pedido,
            this.SemanaEntregaColumn,
            this.StatusTraduzidoColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPedidos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgPedidos.Dock = System.Windows.Forms.DockStyle.None;
            this.dgPedidos.Location = new System.Drawing.Point(12, 147);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.ReadOnly = true;
            this.dgPedidos.RowHeadersVisible = false;
            this.dgPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPedidos.Size = new System.Drawing.Size(774, 254);
            this.dgPedidos.TabIndex = 2;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 126);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(150, 18);
            this.iwtLabel1.TabIndex = 3;
            this.iwtLabel1.Text = "Lista de Pedidos";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(20, 46);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(82, 13);
            this.iwtLabel2.TabIndex = 4;
            this.iwtLabel2.Text = "Usuário Criação";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(33, 76);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(69, 13);
            this.iwtLabel3.TabIndex = 5;
            this.iwtLabel3.Text = "Data Criação";
            // 
            // labUsuario
            // 
            this.labUsuario.AutoSize = true;
            this.labUsuario.BindingField = "AcsUsuarioCriacao";
            this.labUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.labUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.labUsuario.Location = new System.Drawing.Point(106, 46);
            this.labUsuario.Name = "labUsuario";
            this.labUsuario.Size = new System.Drawing.Size(110, 15);
            this.labUsuario.TabIndex = 6;
            this.labUsuario.Text = "Usuário Criação";
            // 
            // labData
            // 
            this.labData.AutoSize = true;
            this.labData.BindingField = "DataCriacao";
            this.labData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labData.LiberadoQuandoCadastroUtilizado = false;
            this.labData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.labData.Location = new System.Drawing.Point(106, 76);
            this.labData.Name = "labData";
            this.labData.Size = new System.Drawing.Size(90, 15);
            this.labData.TabIndex = 7;
            this.labData.Text = "Data Criação";
            // 
            // Pedido
            // 
            this.Pedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pedido.DataPropertyName = "NumeroPosicao";
            this.Pedido.HeaderText = "Pedido";
            this.Pedido.MinimumWidth = 150;
            this.Pedido.Name = "Pedido";
            this.Pedido.ReadOnly = true;
            // 
            // SemanaEntregaColumn
            // 
            this.SemanaEntregaColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SemanaEntregaColumn.DataPropertyName = "SemanaEntrega";
            this.SemanaEntregaColumn.HeaderText = "Semana";
            this.SemanaEntregaColumn.Name = "SemanaEntregaColumn";
            this.SemanaEntregaColumn.ReadOnly = true;
            this.SemanaEntregaColumn.Width = 71;
            // 
            // StatusTraduzidoColumn
            // 
            this.StatusTraduzidoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StatusTraduzidoColumn.DataPropertyName = "StatusTraduzido";
            this.StatusTraduzidoColumn.HeaderText = "Status";
            this.StatusTraduzidoColumn.Name = "StatusTraduzidoColumn";
            this.StatusTraduzidoColumn.ReadOnly = true;
            this.StatusTraduzidoColumn.Width = 62;
            // 
            // CadProgramacaoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(798, 480);
            this.Name = "CadProgramacaoForm";
            this.Text = "Programação";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel NomeLabel;
        private IWTDotNetLib.IWTTextBox Nome;
        private IWTDotNetLib.IWTDataGridView dgPedidos;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel labData;
        private IWTDotNetLib.IWTLabel labUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemanaEntregaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusTraduzidoColumn;
    }
} 
