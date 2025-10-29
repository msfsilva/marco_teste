using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadContratoFornecimentoForm
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
            this.nudPrazoEntrega = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudValorUnitario = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label6 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpTermino = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpInicio = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbProduto = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbMaterial = new IWTDotNetLib.IWTRadioButton(this.components);
            this.ensProduto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensMaterial = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensFornecedor = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrazoEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnitario)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTermino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpInicio)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.nudPrazoEntrega);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.nudValorUnitario);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.ensFornecedor);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(570, 521);
            this.splitContainer1.SplitterDistance = 455;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(483, 20);
            // 
            // nudPrazoEntrega
            // 
            this.nudPrazoEntrega.BindingField = "PrazoEntrega";
            this.nudPrazoEntrega.LiberadoQuandoCadastroUtilizado = false;
            this.nudPrazoEntrega.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPrazoEntrega.Location = new System.Drawing.Point(206, 293);
            this.nudPrazoEntrega.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrazoEntrega.Name = "nudPrazoEntrega";
            this.nudPrazoEntrega.Size = new System.Drawing.Size(89, 20);
            this.nudPrazoEntrega.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(23, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Prazo de Entrega Negociado (dias)";
            // 
            // nudValorUnitario
            // 
            this.nudValorUnitario.BindingField = "ValorUnitario";
            this.nudValorUnitario.DecimalPlaces = 4;
            this.nudValorUnitario.LiberadoQuandoCadastroUtilizado = false;
            this.nudValorUnitario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudValorUnitario.Location = new System.Drawing.Point(206, 267);
            this.nudValorUnitario.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudValorUnitario.Name = "nudValorUnitario";
            this.nudValorUnitario.Size = new System.Drawing.Size(120, 20);
            this.nudValorUnitario.TabIndex = 24;
            this.nudValorUnitario.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BindingField = null;
            this.label6.LiberadoQuandoCadastroUtilizado = false;
            this.label6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label6.Location = new System.Drawing.Point(76, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Valor Unitário do Objeto";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpTermino);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpInicio);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(36, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 45);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Período de Validade";
            // 
            // dtpTermino
            // 
            this.dtpTermino.BindingField = "Termino";
            this.dtpTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTermino.LiberadoQuandoCadastroUtilizado = false;
            this.dtpTermino.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpTermino.Location = new System.Drawing.Point(346, 17);
            this.dtpTermino.Name = "dtpTermino";
            this.dtpTermino.Size = new System.Drawing.Size(128, 20);
            this.dtpTermino.TabIndex = 1;
            this.dtpTermino.Value = new System.DateTime(2013, 9, 10, 16, 49, 44, 913);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(296, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Término";
            // 
            // dtpInicio
            // 
            this.dtpInicio.BindingField = "Inicio";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.LiberadoQuandoCadastroUtilizado = false;
            this.dtpInicio.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpInicio.Location = new System.Drawing.Point(53, 17);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(128, 20);
            this.dtpInicio.TabIndex = 0;
            this.dtpInicio.Value = new System.DateTime(2013, 9, 10, 16, 49, 44, 917);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(13, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Início";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbProduto);
            this.groupBox2.Controls.Add(this.rdbMaterial);
            this.groupBox2.Controls.Add(this.ensProduto);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ensMaterial);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(36, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 95);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Objeto do Contrato";
            // 
            // rdbProduto
            // 
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.BindingField = "ObjetoProduto";
            this.rdbProduto.LiberadoQuandoCadastroUtilizado = false;
            this.rdbProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbProduto.Location = new System.Drawing.Point(480, 61);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(14, 13);
            this.rdbProduto.TabIndex = 2;
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // rdbMaterial
            // 
            this.rdbMaterial.AutoSize = true;
            this.rdbMaterial.BindingField = "ObjetoMaterial";
            this.rdbMaterial.Checked = true;
            this.rdbMaterial.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdbMaterial.LiberadoQuandoCadastroUtilizado = false;
            this.rdbMaterial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbMaterial.Location = new System.Drawing.Point(480, 26);
            this.rdbMaterial.Name = "rdbMaterial";
            this.rdbMaterial.Size = new System.Drawing.Size(14, 13);
            this.rdbMaterial.TabIndex = 0;
            this.rdbMaterial.TabStop = true;
            this.rdbMaterial.UseVisualStyleBackColor = true;
            this.rdbMaterial.CheckedChanged += new System.EventHandler(this.rdbMaterial_CheckedChanged);
            // 
            // ensProduto
            // 
            this.ensProduto.BindingField = "Produto";
            this.ensProduto.DesabilitarAutoCompletar = false;
            this.ensProduto.DesabilitarChekBox = true;
            this.ensProduto.DesabilitarLupa = false;
            this.ensProduto.DesabilitarSeta = false;
            this.ensProduto.Enabled = false;
            this.ensProduto.EntidadeSelecionada = null;
            this.ensProduto.FormSelecao = null;
            this.ensProduto.LiberadoQuandoCadastroUtilizado = false;
            this.ensProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensProduto.Location = new System.Drawing.Point(120, 58);
            this.ensProduto.ModoVisualizacaoGrid = null;
            this.ensProduto.Name = "ensProduto";
            this.ensProduto.ParametrosBuscaObrigatorios = null;
            this.ensProduto.Size = new System.Drawing.Size(354, 21);
            this.ensProduto.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(19, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Produto Comprado";
            // 
            // ensMaterial
            // 
            this.ensMaterial.BindingField = "Material";
            this.ensMaterial.DesabilitarAutoCompletar = false;
            this.ensMaterial.DesabilitarChekBox = true;
            this.ensMaterial.DesabilitarLupa = false;
            this.ensMaterial.DesabilitarSeta = false;
            this.ensMaterial.EntidadeSelecionada = null;
            this.ensMaterial.FormSelecao = null;
            this.ensMaterial.LiberadoQuandoCadastroUtilizado = false;
            this.ensMaterial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensMaterial.Location = new System.Drawing.Point(120, 23);
            this.ensMaterial.ModoVisualizacaoGrid = null;
            this.ensMaterial.Name = "ensMaterial";
            this.ensMaterial.ParametrosBuscaObrigatorios = null;
            this.ensMaterial.Size = new System.Drawing.Size(354, 21);
            this.ensMaterial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(70, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Material";
            // 
            // ensFornecedor
            // 
            this.ensFornecedor.BindingField = "Fornecedor";
            this.ensFornecedor.DesabilitarAutoCompletar = false;
            this.ensFornecedor.DesabilitarChekBox = true;
            this.ensFornecedor.DesabilitarLupa = false;
            this.ensFornecedor.DesabilitarSeta = false;
            this.ensFornecedor.EntidadeSelecionada = null;
            this.ensFornecedor.FormSelecao = null;
            this.ensFornecedor.LiberadoQuandoCadastroUtilizado = false;
            this.ensFornecedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFornecedor.Location = new System.Drawing.Point(115, 28);
            this.ensFornecedor.ModoVisualizacaoGrid = null;
            this.ensFornecedor.Name = "ensFornecedor";
            this.ensFornecedor.ParametrosBuscaObrigatorios = null;
            this.ensFornecedor.Size = new System.Drawing.Size(385, 21);
            this.ensFornecedor.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Fornecedor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRevisao);
            this.groupBox1.Controls.Add(this.lblRevisaoData);
            this.groupBox1.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox1.Controls.Add(this.iwtLabel7);
            this.groupBox1.Controls.Add(this.iwtLabel6);
            this.groupBox1.Controls.Add(this.iwtLabel5);
            this.groupBox1.Location = new System.Drawing.Point(25, 342);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 94);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revisão";
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.BindingField = "UltimaRevisao";
            this.lblRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisao.Location = new System.Drawing.Point(100, 62);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(0, 13);
            this.lblRevisao.TabIndex = 5;
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(100, 39);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 4;
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(100, 16);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 3;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(16, 62);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel7.TabIndex = 2;
            this.iwtLabel7.Text = "Justificativa";
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(48, 39);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(30, 13);
            this.iwtLabel6.TabIndex = 1;
            this.iwtLabel6.Text = "Data";
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(35, 16);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(43, 13);
            this.iwtLabel5.TabIndex = 0;
            this.iwtLabel5.Text = "Usuário";
            // 
            // CadContratoFornecimentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(570, 521);
            this.Name = "CadContratoFornecimentoForm";
            this.Text = "Contrato de Fornecimento Automático";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrazoEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnitario)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTermino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpInicio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTNumericUpDown nudPrazoEntrega;
        private IWTDotNetLib.IWTLabel label7;
        private IWTDotNetLib.IWTNumericUpDown nudValorUnitario;
        private IWTDotNetLib.IWTLabel label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private IWTDotNetLib.IWTDateTimePicker dtpTermino;
        private IWTDotNetLib.IWTLabel label5;
        private IWTDotNetLib.IWTDateTimePicker dtpInicio;
        private IWTDotNetLib.IWTLabel label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTRadioButton rdbProduto;
        private IWTDotNetLib.IWTRadioButton rdbMaterial;
        private IWTEntitySelection ensProduto;
        private IWTDotNetLib.IWTLabel label3;
        private IWTEntitySelection ensMaterial;
        private IWTDotNetLib.IWTLabel label2;
        private IWTEntitySelection ensFornecedor;
        private IWTDotNetLib.IWTLabel label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel iwtLabel5;
    }
}