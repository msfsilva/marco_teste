namespace BibliotecaCadastrosBasicos
{
    partial class CadDeclaracaoImportacaoAdicaoItemForm
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
            this.MaterialLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Material = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.AliquotaIiLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.AliquotaIi = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.QuantidadeLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Quantidade = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.ValorUnitarioDolaresLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.ValorUnitarioDolares = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.ValorTotalDolaresLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.NumeroSequencialNaAdicaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.NumeroSequencialNaAdicao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.lblValorTotalDolar = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblAliquotaII = new IWTDotNetLib.IWTLabel(this.components);
            this.lblAliquotaIPI = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblAliquotaPis = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblAliquotaCofins = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel8 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblAliquotaICMS = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel10 = new IWTDotNetLib.IWTLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AliquotaIi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValorUnitarioDolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroSequencialNaAdicao)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.lblAliquotaICMS);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel10);
            this.splitContainer1.Panel1.Controls.Add(this.lblAliquotaCofins);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel8);
            this.splitContainer1.Panel1.Controls.Add(this.lblAliquotaPis);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel6);
            this.splitContainer1.Panel1.Controls.Add(this.lblAliquotaIPI);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.lblAliquotaII);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.lblValorTotalDolar);
            this.splitContainer1.Panel1.Controls.Add(this.MaterialLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Material);
            this.splitContainer1.Panel1.Controls.Add(this.AliquotaIiLabel);
            this.splitContainer1.Panel1.Controls.Add(this.AliquotaIi);
            this.splitContainer1.Panel1.Controls.Add(this.QuantidadeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Quantidade);
            this.splitContainer1.Panel1.Controls.Add(this.ValorUnitarioDolaresLabel);
            this.splitContainer1.Panel1.Controls.Add(this.ValorUnitarioDolares);
            this.splitContainer1.Panel1.Controls.Add(this.ValorTotalDolaresLabel);
            this.splitContainer1.Panel1.Controls.Add(this.NumeroSequencialNaAdicaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.NumeroSequencialNaAdicao);
            this.splitContainer1.Size = new System.Drawing.Size(582, 414);
            this.splitContainer1.SplitterDistance = 348;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(495, 20);
            // 
            // MaterialLabel
            // 
            this.MaterialLabel.AutoSize = true;
            this.MaterialLabel.BindingField = null;
            this.MaterialLabel.LiberadoQuandoCadastroUtilizado = false;
            this.MaterialLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.MaterialLabel.Location = new System.Drawing.Point(150, 41);
            this.MaterialLabel.Name = "MaterialLabel";
            this.MaterialLabel.Size = new System.Drawing.Size(44, 13);
            this.MaterialLabel.TabIndex = 2;
            this.MaterialLabel.Text = "Material";
            // 
            // Material
            // 
            this.Material.BindingField = "Material";
            this.Material.DesabilitarAutoCompletar = false;
            this.Material.DesabilitarChekBox = true;
            this.Material.DesabilitarLupa = false;
            this.Material.DesabilitarSeta = false;
            this.Material.EntidadeSelecionada = null;
            this.Material.FormSelecao = null;
            this.Material.LiberadoQuandoCadastroUtilizado = false;
            this.Material.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Material.Location = new System.Drawing.Point(200, 39);
            this.Material.ModoVisualizacaoGrid = null;
            this.Material.Name = "Material";
            this.Material.ParametrosBuscaObrigatorios = null;
            this.Material.Size = new System.Drawing.Size(314, 21);
            this.Material.TabIndex = 1;
            this.Material.EntityChange += new System.EventHandler(this.Material_EntityChange);
            // 
            // AliquotaIiLabel
            // 
            this.AliquotaIiLabel.AutoSize = true;
            this.AliquotaIiLabel.BindingField = null;
            this.AliquotaIiLabel.LiberadoQuandoCadastroUtilizado = false;
            this.AliquotaIiLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.AliquotaIiLabel.Location = new System.Drawing.Point(138, 208);
            this.AliquotaIiLabel.Name = "AliquotaIiLabel";
            this.AliquotaIiLabel.Size = new System.Drawing.Size(56, 13);
            this.AliquotaIiLabel.TabIndex = 4;
            this.AliquotaIiLabel.Text = "Alíquota II";
            // 
            // AliquotaIi
            // 
            this.AliquotaIi.BindingField = "AliquotaIi";
            this.AliquotaIi.DecimalPlaces = 4;
            this.AliquotaIi.LiberadoQuandoCadastroUtilizado = false;
            this.AliquotaIi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.AliquotaIi.Location = new System.Drawing.Point(200, 206);
            this.AliquotaIi.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.AliquotaIi.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.AliquotaIi.Name = "AliquotaIi";
            this.AliquotaIi.Size = new System.Drawing.Size(150, 20);
            this.AliquotaIi.TabIndex = 2;
            // 
            // QuantidadeLabel
            // 
            this.QuantidadeLabel.AutoSize = true;
            this.QuantidadeLabel.BindingField = null;
            this.QuantidadeLabel.LiberadoQuandoCadastroUtilizado = false;
            this.QuantidadeLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.QuantidadeLabel.Location = new System.Drawing.Point(132, 235);
            this.QuantidadeLabel.Name = "QuantidadeLabel";
            this.QuantidadeLabel.Size = new System.Drawing.Size(62, 13);
            this.QuantidadeLabel.TabIndex = 6;
            this.QuantidadeLabel.Text = "Quantidade";
            // 
            // Quantidade
            // 
            this.Quantidade.BindingField = "Quantidade";
            this.Quantidade.DecimalPlaces = 4;
            this.Quantidade.LiberadoQuandoCadastroUtilizado = false;
            this.Quantidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Quantidade.Location = new System.Drawing.Point(200, 233);
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
            this.Quantidade.TabIndex = 3;
            this.Quantidade.ValueChanged += new System.EventHandler(this.Quantidade_ValueChanged);
            // 
            // ValorUnitarioDolaresLabel
            // 
            this.ValorUnitarioDolaresLabel.AutoSize = true;
            this.ValorUnitarioDolaresLabel.BindingField = null;
            this.ValorUnitarioDolaresLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ValorUnitarioDolaresLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ValorUnitarioDolaresLabel.Location = new System.Drawing.Point(79, 262);
            this.ValorUnitarioDolaresLabel.Name = "ValorUnitarioDolaresLabel";
            this.ValorUnitarioDolaresLabel.Size = new System.Drawing.Size(115, 13);
            this.ValorUnitarioDolaresLabel.TabIndex = 8;
            this.ValorUnitarioDolaresLabel.Text = "Valor Unitário em Dólar";
            // 
            // ValorUnitarioDolares
            // 
            this.ValorUnitarioDolares.BindingField = "ValorUnitarioDolares";
            this.ValorUnitarioDolares.DecimalPlaces = 4;
            this.ValorUnitarioDolares.LiberadoQuandoCadastroUtilizado = false;
            this.ValorUnitarioDolares.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ValorUnitarioDolares.Location = new System.Drawing.Point(200, 260);
            this.ValorUnitarioDolares.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ValorUnitarioDolares.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.ValorUnitarioDolares.Name = "ValorUnitarioDolares";
            this.ValorUnitarioDolares.Size = new System.Drawing.Size(150, 20);
            this.ValorUnitarioDolares.TabIndex = 4;
            this.ValorUnitarioDolares.ValueChanged += new System.EventHandler(this.ValorUnitarioDolares_ValueChanged);
            // 
            // ValorTotalDolaresLabel
            // 
            this.ValorTotalDolaresLabel.AutoSize = true;
            this.ValorTotalDolaresLabel.BindingField = null;
            this.ValorTotalDolaresLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ValorTotalDolaresLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ValorTotalDolaresLabel.Location = new System.Drawing.Point(91, 310);
            this.ValorTotalDolaresLabel.Name = "ValorTotalDolaresLabel";
            this.ValorTotalDolaresLabel.Size = new System.Drawing.Size(103, 13);
            this.ValorTotalDolaresLabel.TabIndex = 12;
            this.ValorTotalDolaresLabel.Text = "Valor Total em Dólar";
            // 
            // NumeroSequencialNaAdicaoLabel
            // 
            this.NumeroSequencialNaAdicaoLabel.AutoSize = true;
            this.NumeroSequencialNaAdicaoLabel.BindingField = null;
            this.NumeroSequencialNaAdicaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.NumeroSequencialNaAdicaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.NumeroSequencialNaAdicaoLabel.Location = new System.Drawing.Point(43, 15);
            this.NumeroSequencialNaAdicaoLabel.Name = "NumeroSequencialNaAdicaoLabel";
            this.NumeroSequencialNaAdicaoLabel.Size = new System.Drawing.Size(151, 13);
            this.NumeroSequencialNaAdicaoLabel.TabIndex = 16;
            this.NumeroSequencialNaAdicaoLabel.Text = "Número Sequencial na Adição";
            // 
            // NumeroSequencialNaAdicao
            // 
            this.NumeroSequencialNaAdicao.BindingField = "NumeroSequencialNaAdicao";
            this.NumeroSequencialNaAdicao.LiberadoQuandoCadastroUtilizado = false;
            this.NumeroSequencialNaAdicao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.NumeroSequencialNaAdicao.Location = new System.Drawing.Point(200, 13);
            this.NumeroSequencialNaAdicao.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.NumeroSequencialNaAdicao.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NumeroSequencialNaAdicao.Name = "NumeroSequencialNaAdicao";
            this.NumeroSequencialNaAdicao.Size = new System.Drawing.Size(150, 20);
            this.NumeroSequencialNaAdicao.TabIndex = 0;
            // 
            // lblValorTotalDolar
            // 
            this.lblValorTotalDolar.AutoSize = true;
            this.lblValorTotalDolar.BindingField = null;
            this.lblValorTotalDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalDolar.LiberadoQuandoCadastroUtilizado = false;
            this.lblValorTotalDolar.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblValorTotalDolar.Location = new System.Drawing.Point(200, 310);
            this.lblValorTotalDolar.Name = "lblValorTotalDolar";
            this.lblValorTotalDolar.Size = new System.Drawing.Size(0, 13);
            this.lblValorTotalDolar.TabIndex = 18;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(138, 74);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(56, 13);
            this.iwtLabel1.TabIndex = 19;
            this.iwtLabel1.Text = "Alíquota II";
            // 
            // lblAliquotaII
            // 
            this.lblAliquotaII.AutoSize = true;
            this.lblAliquotaII.BindingField = null;
            this.lblAliquotaII.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAliquotaII.LiberadoQuandoCadastroUtilizado = false;
            this.lblAliquotaII.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblAliquotaII.Location = new System.Drawing.Point(200, 74);
            this.lblAliquotaII.Name = "lblAliquotaII";
            this.lblAliquotaII.Size = new System.Drawing.Size(0, 13);
            this.lblAliquotaII.TabIndex = 20;
            // 
            // lblAliquotaIPI
            // 
            this.lblAliquotaIPI.AutoSize = true;
            this.lblAliquotaIPI.BindingField = null;
            this.lblAliquotaIPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAliquotaIPI.LiberadoQuandoCadastroUtilizado = false;
            this.lblAliquotaIPI.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblAliquotaIPI.Location = new System.Drawing.Point(200, 98);
            this.lblAliquotaIPI.Name = "lblAliquotaIPI";
            this.lblAliquotaIPI.Size = new System.Drawing.Size(0, 13);
            this.lblAliquotaIPI.TabIndex = 22;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(131, 98);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(63, 13);
            this.iwtLabel4.TabIndex = 21;
            this.iwtLabel4.Text = "Alíquota IPI";
            // 
            // lblAliquotaPis
            // 
            this.lblAliquotaPis.AutoSize = true;
            this.lblAliquotaPis.BindingField = null;
            this.lblAliquotaPis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAliquotaPis.LiberadoQuandoCadastroUtilizado = false;
            this.lblAliquotaPis.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblAliquotaPis.Location = new System.Drawing.Point(200, 122);
            this.lblAliquotaPis.Name = "lblAliquotaPis";
            this.lblAliquotaPis.Size = new System.Drawing.Size(0, 13);
            this.lblAliquotaPis.TabIndex = 24;
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(130, 122);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(64, 13);
            this.iwtLabel6.TabIndex = 23;
            this.iwtLabel6.Text = "Alíquota Pis";
            // 
            // lblAliquotaCofins
            // 
            this.lblAliquotaCofins.AutoSize = true;
            this.lblAliquotaCofins.BindingField = null;
            this.lblAliquotaCofins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAliquotaCofins.LiberadoQuandoCadastroUtilizado = false;
            this.lblAliquotaCofins.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblAliquotaCofins.Location = new System.Drawing.Point(200, 146);
            this.lblAliquotaCofins.Name = "lblAliquotaCofins";
            this.lblAliquotaCofins.Size = new System.Drawing.Size(0, 13);
            this.lblAliquotaCofins.TabIndex = 26;
            // 
            // iwtLabel8
            // 
            this.iwtLabel8.AutoSize = true;
            this.iwtLabel8.BindingField = null;
            this.iwtLabel8.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel8.Location = new System.Drawing.Point(115, 146);
            this.iwtLabel8.Name = "iwtLabel8";
            this.iwtLabel8.Size = new System.Drawing.Size(79, 13);
            this.iwtLabel8.TabIndex = 25;
            this.iwtLabel8.Text = "Alíquota Cofins";
            // 
            // lblAliquotaICMS
            // 
            this.lblAliquotaICMS.AutoSize = true;
            this.lblAliquotaICMS.BindingField = null;
            this.lblAliquotaICMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAliquotaICMS.LiberadoQuandoCadastroUtilizado = false;
            this.lblAliquotaICMS.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblAliquotaICMS.Location = new System.Drawing.Point(200, 170);
            this.lblAliquotaICMS.Name = "lblAliquotaICMS";
            this.lblAliquotaICMS.Size = new System.Drawing.Size(0, 13);
            this.lblAliquotaICMS.TabIndex = 28;
            // 
            // iwtLabel10
            // 
            this.iwtLabel10.AutoSize = true;
            this.iwtLabel10.BindingField = null;
            this.iwtLabel10.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel10.Location = new System.Drawing.Point(118, 170);
            this.iwtLabel10.Name = "iwtLabel10";
            this.iwtLabel10.Size = new System.Drawing.Size(76, 13);
            this.iwtLabel10.TabIndex = 27;
            this.iwtLabel10.Text = "Alíquota ICMS";
            // 
            // CadDeclaracaoImportacaoAdicaoItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(582, 414);
            this.Name = "CadDeclaracaoImportacaoAdicaoItemForm";
            this.Text = "Item da Adição da Declaração de Importação";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AliquotaIi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValorUnitarioDolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroSequencialNaAdicao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel MaterialLabel;
        private IWTDotNetLib.IWTEntitySelection Material;
        private IWTDotNetLib.IWTLabel AliquotaIiLabel;
        private IWTDotNetLib.IWTNumericUpDown AliquotaIi;
        private IWTDotNetLib.IWTLabel QuantidadeLabel;
        private IWTDotNetLib.IWTNumericUpDown Quantidade;
        private IWTDotNetLib.IWTLabel ValorUnitarioDolaresLabel;
        private IWTDotNetLib.IWTNumericUpDown ValorUnitarioDolares;
        private IWTDotNetLib.IWTLabel ValorTotalDolaresLabel;
        private IWTDotNetLib.IWTLabel NumeroSequencialNaAdicaoLabel;
        private IWTDotNetLib.IWTNumericUpDown NumeroSequencialNaAdicao;
        private IWTDotNetLib.IWTLabel lblValorTotalDolar;
        private IWTDotNetLib.IWTLabel lblAliquotaICMS;
        private IWTDotNetLib.IWTLabel iwtLabel10;
        private IWTDotNetLib.IWTLabel lblAliquotaCofins;
        private IWTDotNetLib.IWTLabel iwtLabel8;
        private IWTDotNetLib.IWTLabel lblAliquotaPis;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel lblAliquotaIPI;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTLabel lblAliquotaII;
        private IWTDotNetLib.IWTLabel iwtLabel1;
    }
} 
