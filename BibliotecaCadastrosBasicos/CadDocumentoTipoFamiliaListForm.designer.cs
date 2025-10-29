namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadDocumentoTipoFamiliaListForm 
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
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento_Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoTipoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoTipoRevisaoAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revisão = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataRevisão = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FamiliaDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoValidacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoPedidoFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoPedidoRevisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bloqueado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AcsUsuarioBloqueio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BloqueioData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGerenciarCopias = new IWTDotNetLib.IWTEditarButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 274);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnGerenciarCopias);
            this.splitContainer2.Size = new System.Drawing.Size(756, 62);
            this.splitContainer2.SplitterDistance = 482;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(756, 240);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(482, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 20);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(231, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 23);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
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
            this.ID,
            this.Documento_Familia,
            this.DocumentoTipoDescricao,
            this.DocumentoTipoRevisaoAtual,
            this.Revisor,
            this.Revisão,
            this.DataRevisão,
            this.DocumentoTipo,
            this.FamiliaDocumento,
            this.TipoValidacao,
            this.DocumentoPedidoFamilia,
            this.DocumentoPedido,
            this.DocumentoPedidoRevisao,
            this.DocumentoNome,
            this.Bloqueado,
            this.AcsUsuarioBloqueio,
            this.BloqueioData});
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
            this.iwtDataGridView1.Size = new System.Drawing.Size(756, 202);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 70;
            // 
            // Documento_Familia
            // 
            this.Documento_Familia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Documento_Familia.DataPropertyName = "Documento_Familia";
            this.Documento_Familia.HeaderText = "Documento / Familia";
            this.Documento_Familia.Name = "Documento_Familia";
            this.Documento_Familia.ReadOnly = true;
            // 
            // DocumentoTipoDescricao
            // 
            this.DocumentoTipoDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocumentoTipoDescricao.DataPropertyName = "descricaoFamilia";
            this.DocumentoTipoDescricao.HeaderText = "Descrição";
            this.DocumentoTipoDescricao.Name = "DocumentoTipoDescricao";
            this.DocumentoTipoDescricao.ReadOnly = true;
            this.DocumentoTipoDescricao.Width = 120;
            // 
            // DocumentoTipoRevisaoAtual
            // 
            this.DocumentoTipoRevisaoAtual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocumentoTipoRevisaoAtual.DataPropertyName = "DocumentoTipoRevisaoAtual";
            this.DocumentoTipoRevisaoAtual.FillWeight = 50F;
            this.DocumentoTipoRevisaoAtual.HeaderText = "Revisão Atual";
            this.DocumentoTipoRevisaoAtual.Name = "DocumentoTipoRevisaoAtual";
            this.DocumentoTipoRevisaoAtual.ReadOnly = true;
            // 
            // Revisor
            // 
            this.Revisor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Revisor.DataPropertyName = "DocumentoTipoRevisor";
            this.Revisor.FillWeight = 80F;
            this.Revisor.HeaderText = "Revisor";
            this.Revisor.Name = "Revisor";
            this.Revisor.ReadOnly = true;
            // 
            // Revisão
            // 
            this.Revisão.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Revisão.DataPropertyName = "DocumentoTipoRevisao";
            this.Revisão.HeaderText = "Revisão";
            this.Revisão.Name = "Revisão";
            this.Revisão.ReadOnly = true;
            // 
            // DataRevisão
            // 
            this.DataRevisão.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataRevisão.DataPropertyName = "DocumentoTipoDataRevisao";
            this.DataRevisão.HeaderText = "Data Revisão";
            this.DataRevisão.Name = "DataRevisão";
            this.DataRevisão.ReadOnly = true;
            // 
            // DocumentoTipo
            // 
            this.DocumentoTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocumentoTipo.DataPropertyName = "DocumentoTipo";
            this.DocumentoTipo.HeaderText = "Documento";
            this.DocumentoTipo.Name = "DocumentoTipo";
            this.DocumentoTipo.ReadOnly = true;
            this.DocumentoTipo.Visible = false;
            this.DocumentoTipo.Width = 150;
            // 
            // FamiliaDocumento
            // 
            this.FamiliaDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FamiliaDocumento.DataPropertyName = "FamiliaDocumento";
            this.FamiliaDocumento.HeaderText = "Familia Documento";
            this.FamiliaDocumento.Name = "FamiliaDocumento";
            this.FamiliaDocumento.ReadOnly = true;
            this.FamiliaDocumento.Width = 150;
            // 
            // TipoValidacao
            // 
            this.TipoValidacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TipoValidacao.DataPropertyName = "TipoValidacao";
            this.TipoValidacao.HeaderText = "Tipo Validação";
            this.TipoValidacao.Name = "TipoValidacao";
            this.TipoValidacao.ReadOnly = true;
            this.TipoValidacao.Visible = false;
            this.TipoValidacao.Width = 150;
            // 
            // DocumentoPedidoFamilia
            // 
            this.DocumentoPedidoFamilia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocumentoPedidoFamilia.DataPropertyName = "DocumentoPedidoFamilia";
            this.DocumentoPedidoFamilia.HeaderText = "Documento Pedido Familia";
            this.DocumentoPedidoFamilia.Name = "DocumentoPedidoFamilia";
            this.DocumentoPedidoFamilia.ReadOnly = true;
            this.DocumentoPedidoFamilia.Visible = false;
            this.DocumentoPedidoFamilia.Width = 150;
            // 
            // DocumentoPedido
            // 
            this.DocumentoPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocumentoPedido.DataPropertyName = "DocumentoPedido";
            this.DocumentoPedido.HeaderText = "Documento Pedido";
            this.DocumentoPedido.Name = "DocumentoPedido";
            this.DocumentoPedido.ReadOnly = true;
            this.DocumentoPedido.Visible = false;
            this.DocumentoPedido.Width = 150;
            // 
            // DocumentoPedidoRevisao
            // 
            this.DocumentoPedidoRevisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocumentoPedidoRevisao.DataPropertyName = "DocumentoPedidoRevisao";
            this.DocumentoPedidoRevisao.HeaderText = "Documento Pedido Revisão";
            this.DocumentoPedidoRevisao.Name = "DocumentoPedidoRevisao";
            this.DocumentoPedidoRevisao.ReadOnly = true;
            this.DocumentoPedidoRevisao.Visible = false;
            this.DocumentoPedidoRevisao.Width = 150;
            // 
            // DocumentoNome
            // 
            this.DocumentoNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocumentoNome.DataPropertyName = "DocumentoNome";
            this.DocumentoNome.HeaderText = "Documento Nome";
            this.DocumentoNome.Name = "DocumentoNome";
            this.DocumentoNome.ReadOnly = true;
            this.DocumentoNome.Visible = false;
            this.DocumentoNome.Width = 150;
            // 
            // Bloqueado
            // 
            this.Bloqueado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Bloqueado.DataPropertyName = "Bloqueado";
            this.Bloqueado.HeaderText = "Bloqueado";
            this.Bloqueado.Name = "Bloqueado";
            this.Bloqueado.ReadOnly = true;
            this.Bloqueado.Visible = false;
            this.Bloqueado.Width = 70;
            // 
            // AcsUsuarioBloqueio
            // 
            this.AcsUsuarioBloqueio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioBloqueio.DataPropertyName = "AcsUsuarioBloqueio";
            this.AcsUsuarioBloqueio.HeaderText = "Usuário Bloqueio";
            this.AcsUsuarioBloqueio.Name = "AcsUsuarioBloqueio";
            this.AcsUsuarioBloqueio.ReadOnly = true;
            this.AcsUsuarioBloqueio.Visible = false;
            this.AcsUsuarioBloqueio.Width = 150;
            // 
            // BloqueioData
            // 
            this.BloqueioData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BloqueioData.DataPropertyName = "BloqueioData";
            this.BloqueioData.HeaderText = "Bloqueio Data";
            this.BloqueioData.Name = "BloqueioData";
            this.BloqueioData.ReadOnly = true;
            this.BloqueioData.Visible = false;
            // 
            // btnGerenciarCopias
            // 
            this.btnGerenciarCopias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerenciarCopias.LiberadoQuandoCadastroUtilizado = false;
            this.btnGerenciarCopias.Location = new System.Drawing.Point(29, 18);
            this.btnGerenciarCopias.Name = "btnGerenciarCopias";
            this.btnGerenciarCopias.Size = new System.Drawing.Size(212, 23);
            this.btnGerenciarCopias.TabIndex = 0;
            this.btnGerenciarCopias.Text = "Gerenciar Cópias";
            this.btnGerenciarCopias.UseVisualStyleBackColor = true;
            // 
            // CadDocumentoTipoFamiliaListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(756, 336);
            this.Name = "CadDocumentoTipoFamiliaListForm";
            this.Text = "Documentos";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTEditarButton btnGerenciarCopias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento_Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoTipoDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoTipoRevisaoAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revisão;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRevisão;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FamiliaDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoValidacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoPedidoFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoPedidoRevisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoNome;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Bloqueado;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioBloqueio;
        private System.Windows.Forms.DataGridViewTextBoxColumn BloqueioData;
    }
} 
