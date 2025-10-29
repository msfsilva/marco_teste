namespace BibliotecaCadastrosBasicos
{
    partial class CadFomularioRetiradaManualEstoqueForm
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
            this.ProdutoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Produto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.MaterialLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Material = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.QuantidadeLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Quantidade = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.IdEstoqueGavetaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.IdEstoqueGavetaDestinoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.ObservacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Observacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.EpiLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Epi = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.rdbProduto = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbMaterial = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbEPI = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbConsumo = new System.Windows.Forms.RadioButton();
            this.rdbMateriaPrima = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ensGavetaOrigem = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensGavetaDestino = new IWTDotNetLib.IWTEntitySelection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.ensGavetaDestino);
            this.splitContainer1.Panel1.Controls.Add(this.ensGavetaOrigem);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.rdbEPI);
            this.splitContainer1.Panel1.Controls.Add(this.rdbMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.rdbProduto);
            this.splitContainer1.Panel1.Controls.Add(this.ProdutoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Produto);
            this.splitContainer1.Panel1.Controls.Add(this.MaterialLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Material);
            this.splitContainer1.Panel1.Controls.Add(this.QuantidadeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Quantidade);
            this.splitContainer1.Panel1.Controls.Add(this.IdEstoqueGavetaLabel);
            this.splitContainer1.Panel1.Controls.Add(this.IdEstoqueGavetaDestinoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.ObservacaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Observacao);
            this.splitContainer1.Panel1.Controls.Add(this.EpiLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Epi);
            this.splitContainer1.Size = new System.Drawing.Size(503, 398);
            this.splitContainer1.SplitterDistance = 332;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(416, 20);
            // 
            // ProdutoLabel
            // 
            this.ProdutoLabel.AutoSize = true;
            this.ProdutoLabel.BindingField = null;
            this.ProdutoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ProdutoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ProdutoLabel.Location = new System.Drawing.Point(33, 15);
            this.ProdutoLabel.Name = "ProdutoLabel";
            this.ProdutoLabel.Size = new System.Drawing.Size(44, 13);
            this.ProdutoLabel.TabIndex = 0;
            this.ProdutoLabel.Text = "Produto";
            // 
            // Produto
            // 
            this.Produto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Produto.BindingField = "Produto";
            this.Produto.DesabilitarAutoCompletar = false;
            this.Produto.DesabilitarChekBox = true;
            this.Produto.DesabilitarLupa = false;
            this.Produto.DesabilitarSeta = false;
            this.Produto.EntidadeSelecionada = null;
            this.Produto.FormSelecao = null;
            this.Produto.LiberadoQuandoCadastroUtilizado = false;
            this.Produto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Produto.Location = new System.Drawing.Point(83, 12);
            this.Produto.ModoVisualizacaoGrid = null;
            this.Produto.Name = "Produto";
            this.Produto.ParametrosBuscaObrigatorios = null;
            this.Produto.Size = new System.Drawing.Size(383, 21);
            this.Produto.TabIndex = 1;
            this.Produto.EntityChange += new System.EventHandler(this.Produto_EntityChange);
            // 
            // MaterialLabel
            // 
            this.MaterialLabel.AutoSize = true;
            this.MaterialLabel.BindingField = null;
            this.MaterialLabel.LiberadoQuandoCadastroUtilizado = false;
            this.MaterialLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.MaterialLabel.Location = new System.Drawing.Point(33, 42);
            this.MaterialLabel.Name = "MaterialLabel";
            this.MaterialLabel.Size = new System.Drawing.Size(44, 13);
            this.MaterialLabel.TabIndex = 2;
            this.MaterialLabel.Text = "Material";
            // 
            // Material
            // 
            this.Material.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Material.BindingField = "Material";
            this.Material.DesabilitarAutoCompletar = false;
            this.Material.DesabilitarChekBox = true;
            this.Material.DesabilitarLupa = false;
            this.Material.DesabilitarSeta = false;
            this.Material.EntidadeSelecionada = null;
            this.Material.FormSelecao = null;
            this.Material.LiberadoQuandoCadastroUtilizado = false;
            this.Material.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Material.Location = new System.Drawing.Point(83, 39);
            this.Material.ModoVisualizacaoGrid = null;
            this.Material.Name = "Material";
            this.Material.ParametrosBuscaObrigatorios = null;
            this.Material.Size = new System.Drawing.Size(383, 21);
            this.Material.TabIndex = 3;
            this.Material.EntityChange += new System.EventHandler(this.Material_EntityChange);
            // 
            // QuantidadeLabel
            // 
            this.QuantidadeLabel.AutoSize = true;
            this.QuantidadeLabel.BindingField = null;
            this.QuantidadeLabel.LiberadoQuandoCadastroUtilizado = false;
            this.QuantidadeLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.QuantidadeLabel.Location = new System.Drawing.Point(15, 156);
            this.QuantidadeLabel.Name = "QuantidadeLabel";
            this.QuantidadeLabel.Size = new System.Drawing.Size(62, 13);
            this.QuantidadeLabel.TabIndex = 8;
            this.QuantidadeLabel.Text = "Quantidade";
            // 
            // Quantidade
            // 
            this.Quantidade.BindingField = "Quantidade";
            this.Quantidade.DecimalPlaces = 4;
            this.Quantidade.LiberadoQuandoCadastroUtilizado = false;
            this.Quantidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Quantidade.Location = new System.Drawing.Point(83, 153);
            this.Quantidade.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Quantidade.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.Size = new System.Drawing.Size(150, 20);
            this.Quantidade.TabIndex = 7;
            // 
            // IdEstoqueGavetaLabel
            // 
            this.IdEstoqueGavetaLabel.AutoSize = true;
            this.IdEstoqueGavetaLabel.BindingField = null;
            this.IdEstoqueGavetaLabel.LiberadoQuandoCadastroUtilizado = false;
            this.IdEstoqueGavetaLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.IdEstoqueGavetaLabel.Location = new System.Drawing.Point(37, 182);
            this.IdEstoqueGavetaLabel.Name = "IdEstoqueGavetaLabel";
            this.IdEstoqueGavetaLabel.Size = new System.Drawing.Size(40, 13);
            this.IdEstoqueGavetaLabel.TabIndex = 14;
            this.IdEstoqueGavetaLabel.Text = "Origem";
            // 
            // IdEstoqueGavetaDestinoLabel
            // 
            this.IdEstoqueGavetaDestinoLabel.AutoSize = true;
            this.IdEstoqueGavetaDestinoLabel.BindingField = null;
            this.IdEstoqueGavetaDestinoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.IdEstoqueGavetaDestinoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.IdEstoqueGavetaDestinoLabel.Location = new System.Drawing.Point(34, 209);
            this.IdEstoqueGavetaDestinoLabel.Name = "IdEstoqueGavetaDestinoLabel";
            this.IdEstoqueGavetaDestinoLabel.Size = new System.Drawing.Size(43, 13);
            this.IdEstoqueGavetaDestinoLabel.TabIndex = 16;
            this.IdEstoqueGavetaDestinoLabel.Text = "Destino";
            // 
            // ObservacaoLabel
            // 
            this.ObservacaoLabel.AutoSize = true;
            this.ObservacaoLabel.BindingField = null;
            this.ObservacaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ObservacaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ObservacaoLabel.Location = new System.Drawing.Point(12, 233);
            this.ObservacaoLabel.Name = "ObservacaoLabel";
            this.ObservacaoLabel.Size = new System.Drawing.Size(65, 13);
            this.ObservacaoLabel.TabIndex = 18;
            this.ObservacaoLabel.Text = "Observação";
            // 
            // Observacao
            // 
            this.Observacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Observacao.BindingField = "Observacao";
            this.Observacao.DebugMode = false;
            this.Observacao.LiberadoQuandoCadastroUtilizado = false;
            this.Observacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Observacao.Location = new System.Drawing.Point(83, 233);
            this.Observacao.ModoBarcode = false;
            this.Observacao.Multiline = true;
            this.Observacao.Name = "Observacao";
            this.Observacao.Size = new System.Drawing.Size(383, 87);
            this.Observacao.TabIndex = 10;
            // 
            // EpiLabel
            // 
            this.EpiLabel.AutoSize = true;
            this.EpiLabel.BindingField = null;
            this.EpiLabel.LiberadoQuandoCadastroUtilizado = false;
            this.EpiLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.EpiLabel.Location = new System.Drawing.Point(53, 69);
            this.EpiLabel.Name = "EpiLabel";
            this.EpiLabel.Size = new System.Drawing.Size(24, 13);
            this.EpiLabel.TabIndex = 20;
            this.EpiLabel.Text = "EPI";
            // 
            // Epi
            // 
            this.Epi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Epi.BindingField = "Epi";
            this.Epi.DesabilitarAutoCompletar = false;
            this.Epi.DesabilitarChekBox = true;
            this.Epi.DesabilitarLupa = false;
            this.Epi.DesabilitarSeta = false;
            this.Epi.EntidadeSelecionada = null;
            this.Epi.FormSelecao = null;
            this.Epi.LiberadoQuandoCadastroUtilizado = false;
            this.Epi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Epi.Location = new System.Drawing.Point(83, 66);
            this.Epi.ModoVisualizacaoGrid = null;
            this.Epi.Name = "Epi";
            this.Epi.ParametrosBuscaObrigatorios = null;
            this.Epi.Size = new System.Drawing.Size(383, 21);
            this.Epi.TabIndex = 5;
            this.Epi.EntityChange += new System.EventHandler(this.Epi_EntityChange);
            // 
            // rdbProduto
            // 
            this.rdbProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.BindingField = null;
            this.rdbProduto.LiberadoQuandoCadastroUtilizado = false;
            this.rdbProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbProduto.Location = new System.Drawing.Point(472, 15);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(14, 13);
            this.rdbProduto.TabIndex = 0;
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // rdbMaterial
            // 
            this.rdbMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbMaterial.AutoSize = true;
            this.rdbMaterial.BindingField = null;
            this.rdbMaterial.LiberadoQuandoCadastroUtilizado = false;
            this.rdbMaterial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbMaterial.Location = new System.Drawing.Point(472, 42);
            this.rdbMaterial.Name = "rdbMaterial";
            this.rdbMaterial.Size = new System.Drawing.Size(14, 13);
            this.rdbMaterial.TabIndex = 2;
            this.rdbMaterial.UseVisualStyleBackColor = true;
            this.rdbMaterial.CheckedChanged += new System.EventHandler(this.rdbMaterial_CheckedChanged);
            // 
            // rdbEPI
            // 
            this.rdbEPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbEPI.AutoSize = true;
            this.rdbEPI.BindingField = null;
            this.rdbEPI.LiberadoQuandoCadastroUtilizado = false;
            this.rdbEPI.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEPI.Location = new System.Drawing.Point(472, 69);
            this.rdbEPI.Name = "rdbEPI";
            this.rdbEPI.Size = new System.Drawing.Size(14, 13);
            this.rdbEPI.TabIndex = 4;
            this.rdbEPI.UseVisualStyleBackColor = true;
            this.rdbEPI.CheckedChanged += new System.EventHandler(this.rdbEPI_CheckedChanged);
            // 
            // rdbConsumo
            // 
            this.rdbConsumo.AutoSize = true;
            this.rdbConsumo.Location = new System.Drawing.Point(101, 19);
            this.rdbConsumo.Name = "rdbConsumo";
            this.rdbConsumo.Size = new System.Drawing.Size(69, 17);
            this.rdbConsumo.TabIndex = 1;
            this.rdbConsumo.Text = "Consumo";
            this.rdbConsumo.UseVisualStyleBackColor = true;
            // 
            // rdbMateriaPrima
            // 
            this.rdbMateriaPrima.AutoSize = true;
            this.rdbMateriaPrima.Checked = true;
            this.rdbMateriaPrima.Location = new System.Drawing.Point(6, 19);
            this.rdbMateriaPrima.Name = "rdbMateriaPrima";
            this.rdbMateriaPrima.Size = new System.Drawing.Size(89, 17);
            this.rdbMateriaPrima.TabIndex = 0;
            this.rdbMateriaPrima.TabStop = true;
            this.rdbMateriaPrima.Text = "Matéria Prima";
            this.rdbMateriaPrima.UseVisualStyleBackColor = true;
            this.rdbMateriaPrima.CheckedChanged += new System.EventHandler(this.rdbMateriaPrima_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbMateriaPrima);
            this.groupBox1.Controls.Add(this.rdbConsumo);
            this.groupBox1.Location = new System.Drawing.Point(83, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 55);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Movimentação";
            // 
            // ensGavetaOrigem
            // 
            this.ensGavetaOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensGavetaOrigem.BindingField = "";
            this.ensGavetaOrigem.DesabilitarAutoCompletar = false;
            this.ensGavetaOrigem.DesabilitarChekBox = true;
            this.ensGavetaOrigem.DesabilitarLupa = false;
            this.ensGavetaOrigem.DesabilitarSeta = false;
            this.ensGavetaOrigem.EntidadeSelecionada = null;
            this.ensGavetaOrigem.FormSelecao = null;
            this.ensGavetaOrigem.LiberadoQuandoCadastroUtilizado = false;
            this.ensGavetaOrigem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensGavetaOrigem.Location = new System.Drawing.Point(83, 179);
            this.ensGavetaOrigem.ModoVisualizacaoGrid = null;
            this.ensGavetaOrigem.Name = "ensGavetaOrigem";
            this.ensGavetaOrigem.ParametrosBuscaObrigatorios = null;
            this.ensGavetaOrigem.Size = new System.Drawing.Size(380, 23);
            this.ensGavetaOrigem.TabIndex = 8;
            this.ensGavetaOrigem.EntityChange += new System.EventHandler(this.ensGavetaOrigem_EntityChange);
            // 
            // ensGavetaDestino
            // 
            this.ensGavetaDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensGavetaDestino.BindingField = "";
            this.ensGavetaDestino.DesabilitarAutoCompletar = false;
            this.ensGavetaDestino.DesabilitarChekBox = false;
            this.ensGavetaDestino.DesabilitarLupa = false;
            this.ensGavetaDestino.DesabilitarSeta = false;
            this.ensGavetaDestino.EntidadeSelecionada = null;
            this.ensGavetaDestino.FormSelecao = null;
            this.ensGavetaDestino.LiberadoQuandoCadastroUtilizado = false;
            this.ensGavetaDestino.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensGavetaDestino.Location = new System.Drawing.Point(83, 204);
            this.ensGavetaDestino.ModoVisualizacaoGrid = null;
            this.ensGavetaDestino.Name = "ensGavetaDestino";
            this.ensGavetaDestino.ParametrosBuscaObrigatorios = null;
            this.ensGavetaDestino.Size = new System.Drawing.Size(403, 23);
            this.ensGavetaDestino.TabIndex = 9;
            this.ensGavetaDestino.EntityChange += new System.EventHandler(this.ensGavetaDestino_EntityChange);
            this.ensGavetaDestino.EnabledChanged += new System.EventHandler(this.ensGavetaDestino_EnabledChanged);
            // 
            // CadFomularioRetiradaManualEstoqueForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(503, 398);
            this.Name = "CadFomularioRetiradaManualEstoqueForm";
            this.Text = "Formulário de Movimentação Manual de Estoque";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel ProdutoLabel;
        private IWTDotNetLib.IWTEntitySelection Produto;
        private IWTDotNetLib.IWTLabel MaterialLabel;
        private IWTDotNetLib.IWTEntitySelection Material;
        private IWTDotNetLib.IWTLabel QuantidadeLabel;
        private IWTDotNetLib.IWTNumericUpDown Quantidade;
        private IWTDotNetLib.IWTLabel IdEstoqueGavetaLabel;
        private IWTDotNetLib.IWTLabel IdEstoqueGavetaDestinoLabel;
        private IWTDotNetLib.IWTLabel ObservacaoLabel;
        private IWTDotNetLib.IWTTextBox Observacao;
        private IWTDotNetLib.IWTLabel EpiLabel;
        private IWTDotNetLib.IWTEntitySelection Epi;
        private IWTDotNetLib.IWTRadioButton rdbProduto;
        private IWTDotNetLib.IWTRadioButton rdbEPI;
        private IWTDotNetLib.IWTRadioButton rdbMaterial;
        private System.Windows.Forms.RadioButton rdbMateriaPrima;
        private System.Windows.Forms.RadioButton rdbConsumo;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTEntitySelection ensGavetaOrigem;
        private IWTDotNetLib.IWTEntitySelection ensGavetaDestino;
    }
} 
