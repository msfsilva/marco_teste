namespace BibliotecaCadastrosBasicos.Estoque
{
    partial class BaixaEstoquePorConsumoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaixaEstoquePorConsumoForm));
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensEstoque = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensCorredor = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensPrateleira = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensGaveta = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnRealizarBaixa = new IWTDotNetLib.IWTButton(this.components);
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 139);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(67, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Almoxarifado";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(32, 180);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(47, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "Corredor";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(28, 221);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(51, 13);
            this.iwtLabel3.TabIndex = 2;
            this.iwtLabel3.Text = "Prateleira";
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(37, 262);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(42, 13);
            this.iwtLabel4.TabIndex = 3;
            this.iwtLabel4.Text = "Gaveta";
            // 
            // ensEstoque
            // 
            this.ensEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensEstoque.BindingField = null;
            this.ensEstoque.DesabilitarAutoCompletar = false;
            this.ensEstoque.DesabilitarChekBox = true;
            this.ensEstoque.DesabilitarLupa = false;
            this.ensEstoque.DesabilitarSeta = false;
            this.ensEstoque.EntidadeSelecionada = null;
            this.ensEstoque.FormSelecao = null;
            this.ensEstoque.LiberadoQuandoCadastroUtilizado = false;
            this.ensEstoque.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensEstoque.Location = new System.Drawing.Point(85, 135);
            this.ensEstoque.ModoVisualizacaoGrid = null;
            this.ensEstoque.Name = "ensEstoque";
            this.ensEstoque.ParametrosBuscaObrigatorios = null;
            this.ensEstoque.Size = new System.Drawing.Size(410, 23);
            this.ensEstoque.TabIndex = 4;
            this.ensEstoque.EntityChange += new System.EventHandler(this.ensEstoque_EntityChange);
            // 
            // ensCorredor
            // 
            this.ensCorredor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensCorredor.BindingField = null;
            this.ensCorredor.DesabilitarAutoCompletar = false;
            this.ensCorredor.DesabilitarChekBox = false;
            this.ensCorredor.DesabilitarLupa = false;
            this.ensCorredor.DesabilitarSeta = false;
            this.ensCorredor.EntidadeSelecionada = null;
            this.ensCorredor.FormSelecao = null;
            this.ensCorredor.LiberadoQuandoCadastroUtilizado = false;
            this.ensCorredor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensCorredor.Location = new System.Drawing.Point(85, 177);
            this.ensCorredor.ModoVisualizacaoGrid = null;
            this.ensCorredor.Name = "ensCorredor";
            this.ensCorredor.ParametrosBuscaObrigatorios = null;
            this.ensCorredor.Size = new System.Drawing.Size(434, 23);
            this.ensCorredor.TabIndex = 5;
            this.ensCorredor.EntityChange += new System.EventHandler(this.ensCorredor_EntityChange);
            this.ensCorredor.EnabledChanged += new System.EventHandler(this.ensCorredor_EnabledChanged);
            // 
            // ensPrateleira
            // 
            this.ensPrateleira.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensPrateleira.BindingField = null;
            this.ensPrateleira.DesabilitarAutoCompletar = false;
            this.ensPrateleira.DesabilitarChekBox = false;
            this.ensPrateleira.DesabilitarLupa = false;
            this.ensPrateleira.DesabilitarSeta = false;
            this.ensPrateleira.EntidadeSelecionada = null;
            this.ensPrateleira.FormSelecao = null;
            this.ensPrateleira.LiberadoQuandoCadastroUtilizado = false;
            this.ensPrateleira.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensPrateleira.Location = new System.Drawing.Point(85, 217);
            this.ensPrateleira.ModoVisualizacaoGrid = null;
            this.ensPrateleira.Name = "ensPrateleira";
            this.ensPrateleira.ParametrosBuscaObrigatorios = null;
            this.ensPrateleira.Size = new System.Drawing.Size(434, 23);
            this.ensPrateleira.TabIndex = 6;
            this.ensPrateleira.EntityChange += new System.EventHandler(this.ensPrateleira_EntityChange);
            this.ensPrateleira.EnabledChanged += new System.EventHandler(this.ensPrateleira_EnabledChanged);
            // 
            // ensGaveta
            // 
            this.ensGaveta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensGaveta.BindingField = null;
            this.ensGaveta.DesabilitarAutoCompletar = false;
            this.ensGaveta.DesabilitarChekBox = false;
            this.ensGaveta.DesabilitarLupa = false;
            this.ensGaveta.DesabilitarSeta = false;
            this.ensGaveta.EntidadeSelecionada = null;
            this.ensGaveta.FormSelecao = null;
            this.ensGaveta.LiberadoQuandoCadastroUtilizado = false;
            this.ensGaveta.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensGaveta.Location = new System.Drawing.Point(85, 257);
            this.ensGaveta.ModoVisualizacaoGrid = null;
            this.ensGaveta.Name = "ensGaveta";
            this.ensGaveta.ParametrosBuscaObrigatorios = null;
            this.ensGaveta.Size = new System.Drawing.Size(434, 23);
            this.ensGaveta.TabIndex = 7;
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(12, 9);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(509, 123);
            this.iwtLabel5.TabIndex = 8;
            this.iwtLabel5.Text = resources.GetString("iwtLabel5.Text");
            this.iwtLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRealizarBaixa
            // 
            this.btnRealizarBaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRealizarBaixa.LiberadoQuandoCadastroUtilizado = false;
            this.btnRealizarBaixa.Location = new System.Drawing.Point(325, 350);
            this.btnRealizarBaixa.Name = "btnRealizarBaixa";
            this.btnRealizarBaixa.Size = new System.Drawing.Size(194, 23);
            this.btnRealizarBaixa.TabIndex = 9;
            this.btnRealizarBaixa.Text = "Realizar a Baixa por Consumo";
            this.btnRealizarBaixa.UseVisualStyleBackColor = true;
            this.btnRealizarBaixa.Click += new System.EventHandler(this.btnRealizarBaixa_Click);
            // 
            // BaixaEstoquePorConsumoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(531, 385);
            this.Controls.Add(this.btnRealizarBaixa);
            this.Controls.Add(this.iwtLabel5);
            this.Controls.Add(this.ensGaveta);
            this.Controls.Add(this.ensPrateleira);
            this.Controls.Add(this.ensCorredor);
            this.Controls.Add(this.ensEstoque);
            this.Controls.Add(this.iwtLabel4);
            this.Controls.Add(this.iwtLabel3);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "BaixaEstoquePorConsumoForm";
            this.Text = "Baixa de Estoque Por Utilização";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTEntitySelection ensEstoque;
        private IWTDotNetLib.IWTEntitySelection ensCorredor;
        private IWTDotNetLib.IWTEntitySelection ensPrateleira;
        private IWTDotNetLib.IWTEntitySelection ensGaveta;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTButton btnRealizarBaixa;
    }
}