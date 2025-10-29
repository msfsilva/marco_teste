namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class OpAguardandoExpedicaoServicoExternoDadosForm
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
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensOperacao = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensOperacaoCompleta = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensFornecedor = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensTransporte = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.btnOk = new IWTDotNetLib.IWTButton(this.components);
            this.lblDados = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQuantidade = new IWTDotNetLib.IWTNumericUpDown(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(19, 56);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(54, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Operação";
            // 
            // ensOperacao
            // 
            this.ensOperacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensOperacao.BindingField = null;
            this.ensOperacao.ColunasDropdown = null;
            this.ensOperacao.DesabilitarAutoCompletar = false;
            this.ensOperacao.DesabilitarChekBox = true;
            this.ensOperacao.DesabilitarLupa = false;
            this.ensOperacao.DesabilitarSeta = false;
            this.ensOperacao.EntidadeSelecionada = null;
            this.ensOperacao.FormSelecao = null;
            this.ensOperacao.LiberadoQuandoCadastroUtilizado = false;
            this.ensOperacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensOperacao.Location = new System.Drawing.Point(79, 53);
            this.ensOperacao.ModoVisualizacaoGrid = null;
            this.ensOperacao.Name = "ensOperacao";
            this.ensOperacao.ParametroBuscaGuiada = null;
            this.ensOperacao.ParametrosBuscaObrigatorios = null;
            this.ensOperacao.Size = new System.Drawing.Size(463, 23);
            this.ensOperacao.TabIndex = 0;
            // 
            // ensOperacaoCompleta
            // 
            this.ensOperacaoCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensOperacaoCompleta.BindingField = null;
            this.ensOperacaoCompleta.ColunasDropdown = null;
            this.ensOperacaoCompleta.DesabilitarAutoCompletar = false;
            this.ensOperacaoCompleta.DesabilitarChekBox = true;
            this.ensOperacaoCompleta.DesabilitarLupa = false;
            this.ensOperacaoCompleta.DesabilitarSeta = false;
            this.ensOperacaoCompleta.EntidadeSelecionada = null;
            this.ensOperacaoCompleta.FormSelecao = null;
            this.ensOperacaoCompleta.LiberadoQuandoCadastroUtilizado = false;
            this.ensOperacaoCompleta.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensOperacaoCompleta.Location = new System.Drawing.Point(79, 53);
            this.ensOperacaoCompleta.ModoVisualizacaoGrid = null;
            this.ensOperacaoCompleta.Name = "ensOperacaoCompleta";
            this.ensOperacaoCompleta.ParametroBuscaGuiada = null;
            this.ensOperacaoCompleta.ParametrosBuscaObrigatorios = null;
            this.ensOperacaoCompleta.Size = new System.Drawing.Size(463, 23);
            this.ensOperacaoCompleta.TabIndex = 0;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(12, 98);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(61, 13);
            this.iwtLabel2.TabIndex = 3;
            this.iwtLabel2.Text = "Fornecedor";
            // 
            // ensFornecedor
            // 
            this.ensFornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensFornecedor.BindingField = null;
            this.ensFornecedor.ColunasDropdown = null;
            this.ensFornecedor.DesabilitarAutoCompletar = false;
            this.ensFornecedor.DesabilitarChekBox = true;
            this.ensFornecedor.DesabilitarLupa = false;
            this.ensFornecedor.DesabilitarSeta = false;
            this.ensFornecedor.EntidadeSelecionada = null;
            this.ensFornecedor.FormSelecao = null;
            this.ensFornecedor.LiberadoQuandoCadastroUtilizado = false;
            this.ensFornecedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFornecedor.Location = new System.Drawing.Point(79, 93);
            this.ensFornecedor.ModoVisualizacaoGrid = null;
            this.ensFornecedor.Name = "ensFornecedor";
            this.ensFornecedor.ParametroBuscaGuiada = null;
            this.ensFornecedor.ParametrosBuscaObrigatorios = null;
            this.ensFornecedor.Size = new System.Drawing.Size(463, 23);
            this.ensFornecedor.TabIndex = 1;
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(15, 138);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(58, 13);
            this.iwtLabel3.TabIndex = 5;
            this.iwtLabel3.Text = "Transporte";
            // 
            // ensTransporte
            // 
            this.ensTransporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensTransporte.BindingField = null;
            this.ensTransporte.ColunasDropdown = null;
            this.ensTransporte.DesabilitarAutoCompletar = false;
            this.ensTransporte.DesabilitarChekBox = true;
            this.ensTransporte.DesabilitarLupa = false;
            this.ensTransporte.DesabilitarSeta = false;
            this.ensTransporte.EntidadeSelecionada = null;
            this.ensTransporte.FormSelecao = null;
            this.ensTransporte.LiberadoQuandoCadastroUtilizado = false;
            this.ensTransporte.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensTransporte.Location = new System.Drawing.Point(79, 134);
            this.ensTransporte.ModoVisualizacaoGrid = null;
            this.ensTransporte.Name = "ensTransporte";
            this.ensTransporte.ParametroBuscaGuiada = null;
            this.ensTransporte.ParametrosBuscaObrigatorios = null;
            this.ensTransporte.Size = new System.Drawing.Size(460, 23);
            this.ensTransporte.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.LiberadoQuandoCadastroUtilizado = false;
            this.btnOk.Location = new System.Drawing.Point(467, 221);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblDados
            // 
            this.lblDados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDados.BindingField = null;
            this.lblDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDados.LiberadoQuandoCadastroUtilizado = false;
            this.lblDados.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblDados.Location = new System.Drawing.Point(12, 9);
            this.lblDados.Name = "lblDados";
            this.lblDados.Size = new System.Drawing.Size(530, 30);
            this.lblDados.TabIndex = 8;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(11, 186);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel4.TabIndex = 9;
            this.iwtLabel4.Text = "Quantidade";
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.BindingField = null;
            this.nudQuantidade.DecimalPlaces = 5;
            this.nudQuantidade.LiberadoQuandoCadastroUtilizado = false;
            this.nudQuantidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQuantidade.Location = new System.Drawing.Point(79, 183);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 20);
            this.nudQuantidade.TabIndex = 3;
            // 
            // OpAguardandoExpedicaoServicoExternoDadosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 256);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.iwtLabel4);
            this.Controls.Add(this.lblDados);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ensTransporte);
            this.Controls.Add(this.iwtLabel3);
            this.Controls.Add(this.ensFornecedor);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.ensOperacaoCompleta);
            this.Controls.Add(this.ensOperacao);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "OpAguardandoExpedicaoServicoExternoDadosForm";
            this.Text = "Dados Para Emissão de Nota Fiscal de Remessa";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTEntitySelection ensOperacao;
        private IWTDotNetLib.IWTEntitySelection ensOperacaoCompleta;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTEntitySelection ensFornecedor;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTEntitySelection ensTransporte;
        private IWTDotNetLib.IWTButton btnOk;
        private IWTDotNetLib.IWTLabel lblDados;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTNumericUpDown nudQuantidade;
    }
}