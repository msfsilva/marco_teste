namespace BibliotecaCadastrosBasicos
{
    partial class CadPlanoCorteForm
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
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialAgrupador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao1Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao2Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao3Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InformacoesAdicionais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostoTrabalhoCorte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostoNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedida1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedida2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedida3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancelado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CancelamentoJustificativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CancelamentoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelarItem = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.iwtDataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelarItem);
            this.splitContainer1.Size = new System.Drawing.Size(663, 480);
            this.splitContainer1.SplitterDistance = 414;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(576, 20);
            this.btnSalvar.Visible = false;
            // 
            // iwtDataGridView1
            // 
            this.iwtDataGridView1.AllowUserToAddRows = false;
            this.iwtDataGridView1.AllowUserToDeleteRows = false;
            this.iwtDataGridView1.AllowUserToOrderColumns = true;
            this.iwtDataGridView1.CacheDados = null;
            this.iwtDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iwtDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MaterialAgrupador,
            this.MaterialFamilia,
            this.MaterialCodigo,
            this.Quantidade,
            this.Dimensao1,
            this.Dimensao1Valor,
            this.Dimensao2,
            this.Dimensao2Valor,
            this.Dimensao3,
            this.Dimensao3Valor,
            this.InformacoesAdicionais,
            this.PostoTrabalhoCorte,
            this.PostoNome,
            this.PostoDescricao,
            this.UnidadeMedida1,
            this.UnidadeMedida2,
            this.UnidadeMedida3,
            this.Cancelado,
            this.CancelamentoJustificativa,
            this.CancelamentoData,
            this.AcsUsuarioCancelamento});
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(663, 414);
            this.iwtDataGridView1.TabIndex = 1;
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
            // MaterialAgrupador
            // 
            this.MaterialAgrupador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaterialAgrupador.DataPropertyName = "MaterialAgrupador";
            this.MaterialAgrupador.HeaderText = "Agrupador do Material";
            this.MaterialAgrupador.Name = "MaterialAgrupador";
            this.MaterialAgrupador.ReadOnly = true;
            this.MaterialAgrupador.Width = 150;
            // 
            // MaterialFamilia
            // 
            this.MaterialFamilia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaterialFamilia.DataPropertyName = "MaterialFamilia";
            this.MaterialFamilia.HeaderText = "Família do Material";
            this.MaterialFamilia.Name = "MaterialFamilia";
            this.MaterialFamilia.ReadOnly = true;
            this.MaterialFamilia.Width = 150;
            // 
            // MaterialCodigo
            // 
            this.MaterialCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaterialCodigo.DataPropertyName = "MaterialCodigo";
            this.MaterialCodigo.HeaderText = "Código de Material";
            this.MaterialCodigo.Name = "MaterialCodigo";
            this.MaterialCodigo.ReadOnly = true;
            this.MaterialCodigo.Width = 150;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // Dimensao1
            // 
            this.Dimensao1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dimensao1.DataPropertyName = "Dimensao1";
            this.Dimensao1.HeaderText = "Dimensão 1";
            this.Dimensao1.Name = "Dimensao1";
            this.Dimensao1.ReadOnly = true;
            this.Dimensao1.Width = 150;
            // 
            // Dimensao1Valor
            // 
            this.Dimensao1Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dimensao1Valor.DataPropertyName = "Dimensao1Valor";
            this.Dimensao1Valor.HeaderText = "Valor da Dimensão 1";
            this.Dimensao1Valor.Name = "Dimensao1Valor";
            this.Dimensao1Valor.ReadOnly = true;
            this.Dimensao1Valor.Width = 150;
            // 
            // Dimensao2
            // 
            this.Dimensao2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dimensao2.DataPropertyName = "Dimensao2";
            this.Dimensao2.HeaderText = "Dimensão 2";
            this.Dimensao2.Name = "Dimensao2";
            this.Dimensao2.ReadOnly = true;
            this.Dimensao2.Width = 150;
            // 
            // Dimensao2Valor
            // 
            this.Dimensao2Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dimensao2Valor.DataPropertyName = "Dimensao2Valor";
            this.Dimensao2Valor.HeaderText = "Valor da Dimensão 2";
            this.Dimensao2Valor.Name = "Dimensao2Valor";
            this.Dimensao2Valor.ReadOnly = true;
            this.Dimensao2Valor.Width = 150;
            // 
            // Dimensao3
            // 
            this.Dimensao3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dimensao3.DataPropertyName = "Dimensao3";
            this.Dimensao3.HeaderText = "Dimensão 3";
            this.Dimensao3.Name = "Dimensao3";
            this.Dimensao3.ReadOnly = true;
            this.Dimensao3.Width = 150;
            // 
            // Dimensao3Valor
            // 
            this.Dimensao3Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dimensao3Valor.DataPropertyName = "Dimensao3Valor";
            this.Dimensao3Valor.HeaderText = "Valor da Dimensão 3";
            this.Dimensao3Valor.Name = "Dimensao3Valor";
            this.Dimensao3Valor.ReadOnly = true;
            this.Dimensao3Valor.Width = 150;
            // 
            // InformacoesAdicionais
            // 
            this.InformacoesAdicionais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InformacoesAdicionais.DataPropertyName = "InformacoesAdicionais";
            this.InformacoesAdicionais.HeaderText = "Informações Adicionais";
            this.InformacoesAdicionais.Name = "InformacoesAdicionais";
            this.InformacoesAdicionais.ReadOnly = true;
            this.InformacoesAdicionais.Width = 150;
            // 
            // PostoTrabalhoCorte
            // 
            this.PostoTrabalhoCorte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PostoTrabalhoCorte.DataPropertyName = "PostoTrabalhoCorte";
            this.PostoTrabalhoCorte.HeaderText = "Posto de Trabalho de Corte";
            this.PostoTrabalhoCorte.Name = "PostoTrabalhoCorte";
            this.PostoTrabalhoCorte.ReadOnly = true;
            this.PostoTrabalhoCorte.Visible = false;
            this.PostoTrabalhoCorte.Width = 150;
            // 
            // PostoNome
            // 
            this.PostoNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PostoNome.DataPropertyName = "PostoNome";
            this.PostoNome.HeaderText = "Nome Posto Trabalho de Corte";
            this.PostoNome.Name = "PostoNome";
            this.PostoNome.ReadOnly = true;
            this.PostoNome.Width = 150;
            // 
            // PostoDescricao
            // 
            this.PostoDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PostoDescricao.DataPropertyName = "PostoDescricao";
            this.PostoDescricao.HeaderText = "Descrição do Posto de Trabalho";
            this.PostoDescricao.Name = "PostoDescricao";
            this.PostoDescricao.ReadOnly = true;
            this.PostoDescricao.Width = 150;
            // 
            // UnidadeMedida1
            // 
            this.UnidadeMedida1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadeMedida1.DataPropertyName = "UnidadeMedida1";
            this.UnidadeMedida1.HeaderText = "Unidade de Medida 1";
            this.UnidadeMedida1.Name = "UnidadeMedida1";
            this.UnidadeMedida1.ReadOnly = true;
            this.UnidadeMedida1.Width = 150;
            // 
            // UnidadeMedida2
            // 
            this.UnidadeMedida2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadeMedida2.DataPropertyName = "UnidadeMedida2";
            this.UnidadeMedida2.HeaderText = "Unidade de Medida 2";
            this.UnidadeMedida2.Name = "UnidadeMedida2";
            this.UnidadeMedida2.ReadOnly = true;
            this.UnidadeMedida2.Width = 150;
            // 
            // UnidadeMedida3
            // 
            this.UnidadeMedida3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadeMedida3.DataPropertyName = "UnidadeMedida3";
            this.UnidadeMedida3.HeaderText = "Unidade de Medida 3";
            this.UnidadeMedida3.Name = "UnidadeMedida3";
            this.UnidadeMedida3.ReadOnly = true;
            this.UnidadeMedida3.Width = 150;
            // 
            // Cancelado
            // 
            this.Cancelado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cancelado.DataPropertyName = "Cancelado";
            this.Cancelado.HeaderText = "Cancelado";
            this.Cancelado.Name = "Cancelado";
            this.Cancelado.ReadOnly = true;
            this.Cancelado.Width = 70;
            // 
            // CancelamentoJustificativa
            // 
            this.CancelamentoJustificativa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CancelamentoJustificativa.DataPropertyName = "CancelamentoJustificativa";
            this.CancelamentoJustificativa.HeaderText = "Cancelamento Justificativa";
            this.CancelamentoJustificativa.Name = "CancelamentoJustificativa";
            this.CancelamentoJustificativa.ReadOnly = true;
            this.CancelamentoJustificativa.Width = 150;
            // 
            // CancelamentoData
            // 
            this.CancelamentoData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CancelamentoData.DataPropertyName = "CancelamentoData";
            this.CancelamentoData.HeaderText = "Cancelamento Data";
            this.CancelamentoData.Name = "CancelamentoData";
            this.CancelamentoData.ReadOnly = true;
            // 
            // AcsUsuarioCancelamento
            // 
            this.AcsUsuarioCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioCancelamento.DataPropertyName = "AcsUsuarioCancelamento";
            this.AcsUsuarioCancelamento.HeaderText = "Usuário Cancelamento";
            this.AcsUsuarioCancelamento.Name = "AcsUsuarioCancelamento";
            this.AcsUsuarioCancelamento.ReadOnly = true;
            this.AcsUsuarioCancelamento.Width = 150;
            // 
            // btnCancelarItem
            // 
            this.btnCancelarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelarItem.Location = new System.Drawing.Point(480, 20);
            this.btnCancelarItem.Name = "btnCancelarItem";
            this.btnCancelarItem.Size = new System.Drawing.Size(171, 23);
            this.btnCancelarItem.TabIndex = 2;
            this.btnCancelarItem.Text = "Cancelar Item";
            this.btnCancelarItem.UseVisualStyleBackColor = true;
            this.btnCancelarItem.Click += new System.EventHandler(this.btnCancelarItem_Click);
            // 
            // CadPlanoCorteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(663, 480);
            this.Name = "CadPlanoCorteForm";
            this.Text = "Plano de Corte";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialAgrupador;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao1Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao2Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao3Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn InformacoesAdicionais;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostoTrabalhoCorte;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostoDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedida1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedida2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedida3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CancelamentoJustificativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn CancelamentoData;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioCancelamento;
        private IWTDotNetLib.IWTButton btnCancelarItem;

    }
} 
