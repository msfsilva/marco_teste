namespace BibliotecaCadastrosBasicos
{
    partial class CadEstoqueCorredorForm
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
            // IdentificacaoLabel
            // 
            this.IdentificacaoLabel.AutoSize = true;
            this.IdentificacaoLabel.BindingField = null;
            this.IdentificacaoLabel.Location = new System.Drawing.Point(20, 43);
            this.IdentificacaoLabel.Name = "IdentificacaoLabel";
            this.IdentificacaoLabel.Size = new System.Drawing.Size(40, 13);
            this.IdentificacaoLabel.TabIndex = 2;
            this.IdentificacaoLabel.Text = "Identificação";
            // 
            // Identificacao
            // 
            this.Identificacao.BindingField = "Identificacao";
            this.Identificacao.Location = new System.Drawing.Point(200, 39);
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.Size = new System.Drawing.Size(150, 21);
            this.Identificacao.TabIndex = 3;
            this.Identificacao.MaxLength = 255;
            // 
            // DescricaoLabel
            // 
            this.DescricaoLabel.AutoSize = true;
            this.DescricaoLabel.BindingField = null;
            this.DescricaoLabel.Location = new System.Drawing.Point(20, 70);
            this.DescricaoLabel.Name = "DescricaoLabel";
            this.DescricaoLabel.Size = new System.Drawing.Size(40, 13);
            this.DescricaoLabel.TabIndex = 4;
            this.DescricaoLabel.Text = "Descrição";
            // 
            // Descricao
            // 
            this.Descricao.BindingField = "Descricao";
            this.Descricao.Location = new System.Drawing.Point(200, 66);
            this.Descricao.Name = "Descricao";
            this.Descricao.Size = new System.Drawing.Size(150, 21);
            this.Descricao.TabIndex = 5;
            this.Descricao.MaxLength = 255;
            // 
            // AtivoLabel
            // 
            this.AtivoLabel.AutoSize = true;
            this.AtivoLabel.BindingField = null;
            this.AtivoLabel.Location = new System.Drawing.Point(20, 97);
            this.AtivoLabel.Name = "AtivoLabel";
            this.AtivoLabel.Size = new System.Drawing.Size(40, 13);
            this.AtivoLabel.TabIndex = 6;
            this.AtivoLabel.Text = "Ativo";
            // 
            // Ativo
            // 
            this.Ativo.AutoSize = true;
            this.Ativo.BindingField = "Ativo";
            this.Ativo.Location = new System.Drawing.Point(200, 93);
            this.Ativo.Name = "Ativo";
            this.Ativo.Size = new System.Drawing.Size(150, 150);
            this.Ativo.TabIndex = 7;
            this.Ativo.UseVisualStyleBackColor = true; 
            // 
            // CadEstoqueCorredorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.Name = "CadEstoqueCorredorForm";
            this.Text = "Corredor";
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
        private IWTDotNetLib.IWTLabel IdentificacaoLabel;
        private IWTDotNetLib.IWTTextBox Identificacao;
        private IWTDotNetLib.IWTLabel DescricaoLabel;
        private IWTDotNetLib.IWTTextBox Descricao;
        private IWTDotNetLib.IWTLabel AtivoLabel;
        private IWTDotNetLib.IWTCheckBox Ativo;
    }
} 
