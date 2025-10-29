namespace BibliotecaCadastrosBasicos
{
    partial class CadEstoqueGavetaForm
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
this.EstoqueLabel = new IWTDotNetLib.IWTLabel(this.components);
this.Estoque = new IWTDotNetLib.IWTEntitySelection(this.components);
this.EstoqueCorredorLabel = new IWTDotNetLib.IWTLabel(this.components);
this.EstoqueCorredor = new IWTDotNetLib.IWTEntitySelection(this.components);
this.EstoquePrateleiraLabel = new IWTDotNetLib.IWTLabel(this.components);
this.EstoquePrateleira = new IWTDotNetLib.IWTEntitySelection(this.components);
this.IdentificacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
this.Identificacao = new IWTDotNetLib.IWTTextBox(this.components);
this.DescricaoLabel = new IWTDotNetLib.IWTLabel(this.components);
this.Descricao = new IWTDotNetLib.IWTTextBox(this.components);
this.AtivoLabel = new IWTDotNetLib.IWTLabel(this.components);
this.Ativo = new IWTDotNetLib.IWTCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
  this.splitContainer1.Panel1.Controls.Add(this.EstoqueLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Estoque);
 this.splitContainer1.Panel1.Controls.Add(this.EstoqueCorredorLabel);
 this.splitContainer1.Panel1.Controls.Add(this.EstoqueCorredor);
 this.splitContainer1.Panel1.Controls.Add(this.EstoquePrateleiraLabel);
 this.splitContainer1.Panel1.Controls.Add(this.EstoquePrateleira);
 this.splitContainer1.Panel1.Controls.Add(this.IdentificacaoLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Identificacao);
 this.splitContainer1.Panel1.Controls.Add(this.DescricaoLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Descricao);
 this.splitContainer1.Panel1.Controls.Add(this.AtivoLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Ativo);
            this.splitContainer1.Size = new System.Drawing.Size(370, 208);
            this.splitContainer1.SplitterDistance = 142;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(283, 20); 
            // 
            // EstoqueLabel
            // 
            this.EstoqueLabel.AutoSize = true;
            this.EstoqueLabel.BindingField = null;
            this.EstoqueLabel.Location = new System.Drawing.Point(20, 16);
            this.EstoqueLabel.Name = "EstoqueLabel";
            this.EstoqueLabel.Size = new System.Drawing.Size(40, 13);
            this.EstoqueLabel.TabIndex = 0;
            this.EstoqueLabel.Text = "Estoque";
            // 
            // Estoque
            // 
            this.Estoque.BindingField = "Estoque";
            this.Estoque.Location = new System.Drawing.Point(200, 12);
            this.Estoque.Name = "Estoque";
            this.Estoque.Size = new System.Drawing.Size(150, 21);
            this.Estoque.TabIndex = 1;
            this.Estoque.DesabilitarAutoCompletar = false;
            this.Estoque.DesabilitarChekBox = true;
            this.Estoque.DesabilitarLupa = false;
            this.Estoque.DesabilitarSeta = false;
            this.Estoque.EntidadeSelecionada = null;
            this.Estoque.FormSelecao = null;
            this.Estoque.ModoVisualizacaoGrid = null;
            this.Estoque.ParametrosBuscaObrigatorios = null;
            // 
            // EstoqueCorredorLabel
            // 
            this.EstoqueCorredorLabel.AutoSize = true;
            this.EstoqueCorredorLabel.BindingField = null;
            this.EstoqueCorredorLabel.Location = new System.Drawing.Point(20, 43);
            this.EstoqueCorredorLabel.Name = "EstoqueCorredorLabel";
            this.EstoqueCorredorLabel.Size = new System.Drawing.Size(40, 13);
            this.EstoqueCorredorLabel.TabIndex = 2;
            this.EstoqueCorredorLabel.Text = "Corredor";
            // 
            // EstoqueCorredor
            // 
            this.EstoqueCorredor.BindingField = "EstoqueCorredor";
            this.EstoqueCorredor.Location = new System.Drawing.Point(200, 39);
            this.EstoqueCorredor.Name = "EstoqueCorredor";
            this.EstoqueCorredor.Size = new System.Drawing.Size(150, 21);
            this.EstoqueCorredor.TabIndex = 3;
            this.EstoqueCorredor.DesabilitarAutoCompletar = false;
            this.EstoqueCorredor.DesabilitarChekBox = true;
            this.EstoqueCorredor.DesabilitarLupa = false;
            this.EstoqueCorredor.DesabilitarSeta = false;
            this.EstoqueCorredor.EntidadeSelecionada = null;
            this.EstoqueCorredor.FormSelecao = null;
            this.EstoqueCorredor.ModoVisualizacaoGrid = null;
            this.EstoqueCorredor.ParametrosBuscaObrigatorios = null;
            // 
            // EstoquePrateleiraLabel
            // 
            this.EstoquePrateleiraLabel.AutoSize = true;
            this.EstoquePrateleiraLabel.BindingField = null;
            this.EstoquePrateleiraLabel.Location = new System.Drawing.Point(20, 70);
            this.EstoquePrateleiraLabel.Name = "EstoquePrateleiraLabel";
            this.EstoquePrateleiraLabel.Size = new System.Drawing.Size(40, 13);
            this.EstoquePrateleiraLabel.TabIndex = 4;
            this.EstoquePrateleiraLabel.Text = "Prateleira";
            // 
            // EstoquePrateleira
            // 
            this.EstoquePrateleira.BindingField = "EstoquePrateleira";
            this.EstoquePrateleira.Location = new System.Drawing.Point(200, 66);
            this.EstoquePrateleira.Name = "EstoquePrateleira";
            this.EstoquePrateleira.Size = new System.Drawing.Size(150, 21);
            this.EstoquePrateleira.TabIndex = 5;
            this.EstoquePrateleira.DesabilitarAutoCompletar = false;
            this.EstoquePrateleira.DesabilitarChekBox = true;
            this.EstoquePrateleira.DesabilitarLupa = false;
            this.EstoquePrateleira.DesabilitarSeta = false;
            this.EstoquePrateleira.EntidadeSelecionada = null;
            this.EstoquePrateleira.FormSelecao = null;
            this.EstoquePrateleira.ModoVisualizacaoGrid = null;
            this.EstoquePrateleira.ParametrosBuscaObrigatorios = null;
            // 
            // IdentificacaoLabel
            // 
            this.IdentificacaoLabel.AutoSize = true;
            this.IdentificacaoLabel.BindingField = null;
            this.IdentificacaoLabel.Location = new System.Drawing.Point(20, 97);
            this.IdentificacaoLabel.Name = "IdentificacaoLabel";
            this.IdentificacaoLabel.Size = new System.Drawing.Size(40, 13);
            this.IdentificacaoLabel.TabIndex = 6;
            this.IdentificacaoLabel.Text = "Identificação";
            // 
            // Identificacao
            // 
            this.Identificacao.BindingField = "Identificacao";
            this.Identificacao.Location = new System.Drawing.Point(200, 93);
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.Size = new System.Drawing.Size(150, 21);
            this.Identificacao.TabIndex = 7;
            this.Identificacao.MaxLength = 255;
            // 
            // DescricaoLabel
            // 
            this.DescricaoLabel.AutoSize = true;
            this.DescricaoLabel.BindingField = null;
            this.DescricaoLabel.Location = new System.Drawing.Point(20, 124);
            this.DescricaoLabel.Name = "DescricaoLabel";
            this.DescricaoLabel.Size = new System.Drawing.Size(40, 13);
            this.DescricaoLabel.TabIndex = 8;
            this.DescricaoLabel.Text = "Descrição";
            // 
            // Descricao
            // 
            this.Descricao.BindingField = "Descricao";
            this.Descricao.Location = new System.Drawing.Point(200, 120);
            this.Descricao.Name = "Descricao";
            this.Descricao.Size = new System.Drawing.Size(150, 21);
            this.Descricao.TabIndex = 9;
            this.Descricao.MaxLength = 255;
            // 
            // AtivoLabel
            // 
            this.AtivoLabel.AutoSize = true;
            this.AtivoLabel.BindingField = null;
            this.AtivoLabel.Location = new System.Drawing.Point(20, 151);
            this.AtivoLabel.Name = "AtivoLabel";
            this.AtivoLabel.Size = new System.Drawing.Size(40, 13);
            this.AtivoLabel.TabIndex = 10;
            this.AtivoLabel.Text = "Ativo";
            // 
            // Ativo
            // 
            this.Ativo.AutoSize = true;
            this.Ativo.BindingField = "Ativo";
            this.Ativo.Location = new System.Drawing.Point(200, 147);
            this.Ativo.Name = "Ativo";
            this.Ativo.Size = new System.Drawing.Size(150, 150);
            this.Ativo.TabIndex = 11;
            this.Ativo.UseVisualStyleBackColor = true; 
            // 
            // CadEstoqueGavetaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.Name = "CadEstoqueGavetaForm";
            this.Text = "Gaveta";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel EstoqueLabel;
        private IWTDotNetLib.IWTEntitySelection Estoque;
        private IWTDotNetLib.IWTLabel EstoqueCorredorLabel;
        private IWTDotNetLib.IWTEntitySelection EstoqueCorredor;
        private IWTDotNetLib.IWTLabel EstoquePrateleiraLabel;
        private IWTDotNetLib.IWTEntitySelection EstoquePrateleira;
        private IWTDotNetLib.IWTLabel IdentificacaoLabel;
        private IWTDotNetLib.IWTTextBox Identificacao;
        private IWTDotNetLib.IWTLabel DescricaoLabel;
        private IWTDotNetLib.IWTTextBox Descricao;
        private IWTDotNetLib.IWTLabel AtivoLabel;
        private IWTDotNetLib.IWTCheckBox Ativo;
    }
} 
