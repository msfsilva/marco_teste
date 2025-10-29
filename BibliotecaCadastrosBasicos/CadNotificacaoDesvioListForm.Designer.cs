namespace BibliotecaCadastrosBasicos
{
    partial class CadNotificacaoDesvioListForm
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
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Defeito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDefeito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdDefeito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdDevolvida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NFDevolucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataNfDevolucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorNfDevolucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Justificativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtDefaultListButtons1 = new IWTDotNetLib.IWTDefaultListButtons();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.iwtSearchPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 339);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.iwtDefaultListButtons1);
            this.splitContainer2.Size = new System.Drawing.Size(828, 62);
            this.splitContainer2.SplitterDistance = 443;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(828, 305);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtDataGridView1
            // 
            this.iwtDataGridView1.AllowUserToAddRows = false;
            this.iwtDataGridView1.AllowUserToDeleteRows = false;
            this.iwtDataGridView1.AllowUserToOrderColumns = true;
            this.iwtDataGridView1.AllowUserToResizeRows = false;
            this.iwtDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.iwtDataGridView1.CacheDados = null;
            this.iwtDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iwtDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pedido,
            this.Cliente,
            this.Numero,
            this.tip,
            this.Item,
            this.Data,
            this.Defeito,
            this.TipoDefeito,
            this.Posto,
            this.QtdDefeito,
            this.QtdDevolvida,
            this.NFDevolucao,
            this.DataNfDevolucao,
            this.ValorNfDevolucao,
            this.Justificativa,
            this.Usuario});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(828, 267);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // Pedido
            // 
            this.Pedido.DataPropertyName = "PedidoItem";
            this.Pedido.HeaderText = "Pedido";
            this.Pedido.Name = "Pedido";
            this.Pedido.ReadOnly = true;
            this.Pedido.Width = 140;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 80;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 80;
            // 
            // tip
            // 
            this.tip.DataPropertyName = "TipoNotificacaoDesvio";
            this.tip.HeaderText = "Tipo";
            this.tip.Name = "tip";
            this.tip.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.DataPropertyName = "Produto";
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 80;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "Data";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 80;
            // 
            // Defeito
            // 
            this.Defeito.DataPropertyName = "DescricaoDefeito";
            this.Defeito.HeaderText = "Defeito";
            this.Defeito.Name = "Defeito";
            this.Defeito.ReadOnly = true;
            this.Defeito.Width = 150;
            // 
            // TipoDefeito
            // 
            this.TipoDefeito.DataPropertyName = "TipoDefeito";
            this.TipoDefeito.HeaderText = "Tipo Defeito";
            this.TipoDefeito.Name = "TipoDefeito";
            this.TipoDefeito.ReadOnly = true;
            this.TipoDefeito.Width = 80;
            // 
            // Posto
            // 
            this.Posto.DataPropertyName = "PostoTrabalho";
            this.Posto.HeaderText = "Posto";
            this.Posto.Name = "Posto";
            this.Posto.ReadOnly = true;
            this.Posto.Width = 80;
            // 
            // QtdDefeito
            // 
            this.QtdDefeito.DataPropertyName = "QtdPecasDefeituosas";
            this.QtdDefeito.HeaderText = "Qtd Defeito";
            this.QtdDefeito.Name = "QtdDefeito";
            this.QtdDefeito.ReadOnly = true;
            this.QtdDefeito.Width = 80;
            // 
            // QtdDevolvida
            // 
            this.QtdDevolvida.DataPropertyName = "QtdPecasDevolvidas";
            this.QtdDevolvida.HeaderText = "Qtd Devolvida";
            this.QtdDevolvida.Name = "QtdDevolvida";
            this.QtdDevolvida.ReadOnly = true;
            this.QtdDevolvida.Width = 80;
            // 
            // NFDevolucao
            // 
            this.NFDevolucao.DataPropertyName = "NumeroNfCliente";
            this.NFDevolucao.HeaderText = "NF Devolução";
            this.NFDevolucao.Name = "NFDevolucao";
            this.NFDevolucao.ReadOnly = true;
            this.NFDevolucao.Width = 80;
            // 
            // DataNfDevolucao
            // 
            this.DataNfDevolucao.DataPropertyName = "DataEmissaoNfCliente";
            this.DataNfDevolucao.HeaderText = "Data NF Devolução";
            this.DataNfDevolucao.Name = "DataNfDevolucao";
            this.DataNfDevolucao.ReadOnly = true;
            this.DataNfDevolucao.Width = 80;
            // 
            // ValorNfDevolucao
            // 
            this.ValorNfDevolucao.DataPropertyName = "ValorNfCliente";
            this.ValorNfDevolucao.HeaderText = "Valor NF Devolucao";
            this.ValorNfDevolucao.Name = "ValorNfDevolucao";
            this.ValorNfDevolucao.ReadOnly = true;
            this.ValorNfDevolucao.Width = 80;
            // 
            // Justificativa
            // 
            this.Justificativa.DataPropertyName = "JustificativaProducao";
            this.Justificativa.HeaderText = "Justificativa";
            this.Justificativa.Name = "Justificativa";
            this.Justificativa.ReadOnly = true;
            this.Justificativa.Width = 80;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "AcsUsuarioNotificacao";
            this.Usuario.HeaderText = "Usuário";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 80;
            // 
            // iwtDefaultListButtons1
            // 
            this.iwtDefaultListButtons1.Location = new System.Drawing.Point(0, 0);
            this.iwtDefaultListButtons1.Name = "iwtDefaultListButtons1";
            this.iwtDefaultListButtons1.Size = new System.Drawing.Size(381, 62);
            this.iwtDefaultListButtons1.TabIndex = 0;
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(443, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(40, 21);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(323, 20);
            this.iwtTextBox1.TabIndex = 3;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(2, 23);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 2;
            this.iwtLabel1.Text = "Busca";
            // 
            // CadNotificacaoDesvioListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(828, 401);
            this.Name = "CadNotificacaoDesvioListForm";
            this.Text = "Notificações de Desvio";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTDefaultListButtons iwtDefaultListButtons1;
        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn tip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Defeito;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDefeito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posto;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdDefeito;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdDevolvida;
        private System.Windows.Forms.DataGridViewTextBoxColumn NFDevolucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataNfDevolucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorNfDevolucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Justificativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
    }
}