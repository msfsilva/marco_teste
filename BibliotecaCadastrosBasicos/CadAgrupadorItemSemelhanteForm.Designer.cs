using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadAgrupadorItemSemelhanteForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label24 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.label25 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.label26 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.nudLoteProducao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdAgrupador = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdKbManufaturado = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label17 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblVermelhoSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.label18 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblVerdeSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.label19 = new IWTDotNetLib.IWTLabel(this.components);
            this.lbAmareloSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.txtDimensao = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtCodigo = new IWTDotNetLib.IWTTextBox(this.components);
            this.chkDimensaoQuantidade = new IWTDotNetLib.IWTCheckBox(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.cmbClassificacao = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label11 = new IWTDotNetLib.IWTLabel(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQtdContainer = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.chkAtivo = new IWTDotNetLib.IWTCheckBox(this.components);
            this.label10 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkEtiqueta = new IWTDotNetLib.IWTCheckBox(this.components);
            this.nudVermelho = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.chkEmiteOp = new IWTDotNetLib.IWTCheckBox(this.components);
            this.label9 = new IWTDotNetLib.IWTLabel(this.components);
            this.label6 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudAmarelo = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudVerde = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.ensProduto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.btnProdutoRemover = new IWTDotNetLib.IWTButton(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnProdutoAdicionar = new IWTDotNetLib.IWTButton(this.components);
            this.dgvProdutos = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btnEtiquetaAdicionar = new IWTDotNetLib.IWTButton(this.components);
            this.btnEtiquetaRemover = new IWTDotNetLib.IWTButton(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQtdPorEtiqueta = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.dgvEtiquetas = new IWTDotNetLib.IWTDataGridView(this.components);
            this.QtdPorEtiqueta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnSalvarComo = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoteProducao)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVermelho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmarelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdPorEtiqueta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSalvarComo);
            this.splitContainer1.Size = new System.Drawing.Size(800, 634);
            this.splitContainer1.SplitterDistance = 557;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 31);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(713, 31);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(290, 142);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Revisão";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.lblRevisao);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.lblRevisaoData);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 94);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revisão";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BindingField = null;
            this.label24.LiberadoQuandoCadastroUtilizado = false;
            this.label24.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label24.Location = new System.Drawing.Point(28, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 6;
            this.label24.Text = "Usuário";
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.BindingField = "UltimaRevisao";
            this.lblRevisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisao.Location = new System.Drawing.Point(111, 73);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(0, 13);
            this.lblRevisao.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BindingField = null;
            this.label25.LiberadoQuandoCadastroUtilizado = false;
            this.label25.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label25.Location = new System.Drawing.Point(41, 45);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(30, 13);
            this.label25.TabIndex = 7;
            this.label25.Text = "Data";
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(111, 45);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 10;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BindingField = null;
            this.label26.LiberadoQuandoCadastroUtilizado = false;
            this.label26.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label26.Location = new System.Drawing.Point(9, 73);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(62, 13);
            this.label26.TabIndex = 8;
            this.label26.Text = "Justificativa";
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(111, 17);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.nudLoteProducao);
            this.splitContainer2.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer2.Panel1.Controls.Add(this.txtDimensao);
            this.splitContainer2.Panel1.Controls.Add(this.txtCodigo);
            this.splitContainer2.Panel1.Controls.Add(this.chkDimensaoQuantidade);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.cmbClassificacao);
            this.splitContainer2.Panel1.Controls.Add(this.label11);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.nudQtdContainer);
            this.splitContainer2.Panel1.Controls.Add(this.chkAtivo);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.chkEtiqueta);
            this.splitContainer2.Panel1.Controls.Add(this.nudVermelho);
            this.splitContainer2.Panel1.Controls.Add(this.chkEmiteOp);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.nudAmarelo);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.nudVerde);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(786, 525);
            this.splitContainer2.SplitterDistance = 253;
            this.splitContainer2.TabIndex = 0;
            // 
            // nudLoteProducao
            // 
            this.nudLoteProducao.BindingField = "LoteProducao";
            this.nudLoteProducao.DecimalPlaces = 2;
            this.nudLoteProducao.LiberadoQuandoCadastroUtilizado = true;
            this.nudLoteProducao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLoteProducao.Location = new System.Drawing.Point(89, 228);
            this.nudLoteProducao.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudLoteProducao.Name = "nudLoteProducao";
            this.nudLoteProducao.Size = new System.Drawing.Size(106, 20);
            this.nudLoteProducao.TabIndex = 12;
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.BindingField = "Descricao";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(89, 86);
            this.iwtTextBox2.MaxLength = 255;
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.Size = new System.Drawing.Size(325, 20);
            this.iwtTextBox2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(15, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Descrição";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdAgrupador);
            this.groupBox5.Controls.Add(this.rdKbManufaturado);
            this.groupBox5.Location = new System.Drawing.Point(19, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(241, 50);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Modo de Operação";
            // 
            // rdAgrupador
            // 
            this.rdAgrupador.AutoSize = true;
            this.rdAgrupador.BindingField = null;
            this.rdAgrupador.LiberadoQuandoCadastroUtilizado = false;
            this.rdAgrupador.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdAgrupador.Location = new System.Drawing.Point(130, 19);
            this.rdAgrupador.Name = "rdAgrupador";
            this.rdAgrupador.Size = new System.Drawing.Size(74, 17);
            this.rdAgrupador.TabIndex = 1;
            this.rdAgrupador.Text = "Agrupador";
            this.rdAgrupador.UseVisualStyleBackColor = true;
            this.rdAgrupador.CheckedChanged += new System.EventHandler(this.rdAgrupador_CheckedChanged);
            // 
            // rdKbManufaturado
            // 
            this.rdKbManufaturado.AutoSize = true;
            this.rdKbManufaturado.BindingField = null;
            this.rdKbManufaturado.Checked = true;
            this.rdKbManufaturado.LiberadoQuandoCadastroUtilizado = false;
            this.rdKbManufaturado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdKbManufaturado.Location = new System.Drawing.Point(16, 19);
            this.rdKbManufaturado.Name = "rdKbManufaturado";
            this.rdKbManufaturado.Size = new System.Drawing.Size(108, 17);
            this.rdKbManufaturado.TabIndex = 0;
            this.rdKbManufaturado.TabStop = true;
            this.rdKbManufaturado.Text = "KB Manufaturado";
            this.rdKbManufaturado.UseVisualStyleBackColor = true;
            this.rdKbManufaturado.CheckedChanged += new System.EventHandler(this.rdKbManufaturado_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.lblVermelhoSugerido);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.lblVerdeSugerido);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.lbAmareloSugerido);
            this.groupBox4.Location = new System.Drawing.Point(217, 139);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(167, 83);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Demanda Sugerida";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BindingField = null;
            this.label17.LiberadoQuandoCadastroUtilizado = false;
            this.label17.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label17.Location = new System.Drawing.Point(12, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 51;
            this.label17.Text = "Vermelho";
            // 
            // lblVermelhoSugerido
            // 
            this.lblVermelhoSugerido.AutoSize = true;
            this.lblVermelhoSugerido.BackColor = System.Drawing.Color.Red;
            this.lblVermelhoSugerido.BindingField = null;
            this.lblVermelhoSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lblVermelhoSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblVermelhoSugerido.Location = new System.Drawing.Point(86, 59);
            this.lblVermelhoSugerido.Name = "lblVermelhoSugerido";
            this.lblVermelhoSugerido.Size = new System.Drawing.Size(0, 13);
            this.lblVermelhoSugerido.TabIndex = 44;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BindingField = null;
            this.label18.LiberadoQuandoCadastroUtilizado = false;
            this.label18.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label18.Location = new System.Drawing.Point(12, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 50;
            this.label18.Text = "Amarelo";
            // 
            // lblVerdeSugerido
            // 
            this.lblVerdeSugerido.AutoSize = true;
            this.lblVerdeSugerido.BackColor = System.Drawing.Color.Lime;
            this.lblVerdeSugerido.BindingField = null;
            this.lblVerdeSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lblVerdeSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblVerdeSugerido.Location = new System.Drawing.Point(86, 20);
            this.lblVerdeSugerido.Name = "lblVerdeSugerido";
            this.lblVerdeSugerido.Size = new System.Drawing.Size(0, 13);
            this.lblVerdeSugerido.TabIndex = 42;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BindingField = null;
            this.label19.LiberadoQuandoCadastroUtilizado = false;
            this.label19.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label19.Location = new System.Drawing.Point(12, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 49;
            this.label19.Text = "Verde";
            // 
            // lbAmareloSugerido
            // 
            this.lbAmareloSugerido.AutoSize = true;
            this.lbAmareloSugerido.BackColor = System.Drawing.Color.Yellow;
            this.lbAmareloSugerido.BindingField = null;
            this.lbAmareloSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lbAmareloSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lbAmareloSugerido.Location = new System.Drawing.Point(86, 38);
            this.lbAmareloSugerido.Name = "lbAmareloSugerido";
            this.lbAmareloSugerido.Size = new System.Drawing.Size(0, 13);
            this.lbAmareloSugerido.TabIndex = 43;
            // 
            // txtDimensao
            // 
            this.txtDimensao.BindingField = "Dimensao";
            this.txtDimensao.DebugMode = false;
            this.txtDimensao.LiberadoQuandoCadastroUtilizado = false;
            this.txtDimensao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtDimensao.Location = new System.Drawing.Point(308, 60);
            this.txtDimensao.ModoBarcode = false;
            this.txtDimensao.Name = "txtDimensao";
            this.txtDimensao.Size = new System.Drawing.Size(106, 20);
            this.txtDimensao.TabIndex = 2;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BindingField = "Codigo";
            this.txtCodigo.DebugMode = false;
            this.txtCodigo.LiberadoQuandoCadastroUtilizado = false;
            this.txtCodigo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCodigo.Location = new System.Drawing.Point(89, 60);
            this.txtCodigo.MaxLength = 15;
            this.txtCodigo.ModoBarcode = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(106, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // chkDimensaoQuantidade
            // 
            this.chkDimensaoQuantidade.AutoSize = true;
            this.chkDimensaoQuantidade.BindingField = "UtilizaDimensaoQuantidadeBaixa";
            this.chkDimensaoQuantidade.LiberadoQuandoCadastroUtilizado = true;
            this.chkDimensaoQuantidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkDimensaoQuantidade.Location = new System.Drawing.Point(583, 89);
            this.chkDimensaoQuantidade.Name = "chkDimensaoQuantidade";
            this.chkDimensaoQuantidade.Size = new System.Drawing.Size(191, 17);
            this.chkDimensaoQuantidade.TabIndex = 6;
            this.chkDimensaoQuantidade.Text = "Utiliza Dimensão como Quantidade";
            this.chkDimensaoQuantidade.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(248, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dimensão";
            // 
            // cmbClassificacao
            // 
            this.cmbClassificacao.BindingField = "ClassificacaoProduto";
            this.cmbClassificacao.ColumnsToDisplay = null;
            this.cmbClassificacao.DisableAutoSelectOnEmpty = false;
            this.cmbClassificacao.DropDownHeight = 1;
            this.cmbClassificacao.FormattingEnabled = true;
            this.cmbClassificacao.IntegralHeight = false;
            this.cmbClassificacao.LiberadoQuandoCadastroUtilizado = true;
            this.cmbClassificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbClassificacao.Location = new System.Drawing.Point(89, 112);
            this.cmbClassificacao.Name = "cmbClassificacao";
            this.cmbClassificacao.SelectedRow = null;
            this.cmbClassificacao.Size = new System.Drawing.Size(325, 21);
            this.cmbClassificacao.TabIndex = 8;
            this.cmbClassificacao.Table = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BindingField = null;
            this.label11.LiberadoQuandoCadastroUtilizado = false;
            this.label11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label11.Location = new System.Drawing.Point(14, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Classificação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(15, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Identificação";
            // 
            // nudQtdContainer
            // 
            this.nudQtdContainer.BindingField = "QtdContainer";
            this.nudQtdContainer.LiberadoQuandoCadastroUtilizado = true;
            this.nudQtdContainer.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtdContainer.Location = new System.Drawing.Point(308, 228);
            this.nudQtdContainer.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudQtdContainer.Name = "nudQtdContainer";
            this.nudQtdContainer.Size = new System.Drawing.Size(106, 20);
            this.nudQtdContainer.TabIndex = 13;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.BindingField = "Ativo";
            this.chkAtivo.LiberadoQuandoCadastroUtilizado = true;
            this.chkAtivo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkAtivo.Location = new System.Drawing.Point(507, 63);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 17);
            this.chkAtivo.TabIndex = 3;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BindingField = null;
            this.label10.LiberadoQuandoCadastroUtilizado = false;
            this.label10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label10.Location = new System.Drawing.Point(230, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Qtd Container";
            // 
            // chkEtiqueta
            // 
            this.chkEtiqueta.AutoSize = true;
            this.chkEtiqueta.BindingField = "ImprimeEtiqueta";
            this.chkEtiqueta.LiberadoQuandoCadastroUtilizado = true;
            this.chkEtiqueta.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkEtiqueta.Location = new System.Drawing.Point(583, 63);
            this.chkEtiqueta.Name = "chkEtiqueta";
            this.chkEtiqueta.Size = new System.Drawing.Size(104, 17);
            this.chkEtiqueta.TabIndex = 4;
            this.chkEtiqueta.Text = "Imprime Etiqueta";
            this.chkEtiqueta.UseVisualStyleBackColor = true;
            // 
            // nudVermelho
            // 
            this.nudVermelho.BindingField = "Vermelho";
            this.nudVermelho.DecimalPlaces = 2;
            this.nudVermelho.LiberadoQuandoCadastroUtilizado = true;
            this.nudVermelho.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudVermelho.Location = new System.Drawing.Point(89, 199);
            this.nudVermelho.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudVermelho.Name = "nudVermelho";
            this.nudVermelho.Size = new System.Drawing.Size(106, 20);
            this.nudVermelho.TabIndex = 11;
            // 
            // chkEmiteOp
            // 
            this.chkEmiteOp.AutoSize = true;
            this.chkEmiteOp.BindingField = "EmiteOp";
            this.chkEmiteOp.LiberadoQuandoCadastroUtilizado = true;
            this.chkEmiteOp.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkEmiteOp.Location = new System.Drawing.Point(507, 89);
            this.chkEmiteOp.Name = "chkEmiteOp";
            this.chkEmiteOp.Size = new System.Drawing.Size(70, 17);
            this.chkEmiteOp.TabIndex = 5;
            this.chkEmiteOp.Text = "Emite OP";
            this.chkEmiteOp.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BindingField = null;
            this.label9.LiberadoQuandoCadastroUtilizado = false;
            this.label9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label9.Location = new System.Drawing.Point(32, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Vermelho";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BindingField = null;
            this.label6.LiberadoQuandoCadastroUtilizado = false;
            this.label6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label6.Location = new System.Drawing.Point(38, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Produzir";
            // 
            // nudAmarelo
            // 
            this.nudAmarelo.BindingField = "Amarelo";
            this.nudAmarelo.DecimalPlaces = 2;
            this.nudAmarelo.LiberadoQuandoCadastroUtilizado = true;
            this.nudAmarelo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudAmarelo.Location = new System.Drawing.Point(89, 173);
            this.nudAmarelo.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudAmarelo.Name = "nudAmarelo";
            this.nudAmarelo.Size = new System.Drawing.Size(106, 20);
            this.nudAmarelo.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(38, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Amarelo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(48, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Verde";
            // 
            // nudVerde
            // 
            this.nudVerde.BindingField = "Verde";
            this.nudVerde.DecimalPlaces = 2;
            this.nudVerde.LiberadoQuandoCadastroUtilizado = true;
            this.nudVerde.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudVerde.Location = new System.Drawing.Point(89, 147);
            this.nudVerde.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudVerde.Name = "nudVerde";
            this.nudVerde.Size = new System.Drawing.Size(106, 20);
            this.nudVerde.TabIndex = 9;
            this.nudVerde.ValueChanged += new System.EventHandler(this.nudVerde_ValueChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer3.Size = new System.Drawing.Size(786, 268);
            this.splitContainer3.SplitterDistance = 390;
            this.splitContainer3.TabIndex = 30;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 268);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produtos";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(3, 16);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.ensProduto);
            this.splitContainer4.Panel1.Controls.Add(this.btnProdutoRemover);
            this.splitContainer4.Panel1.Controls.Add(this.label5);
            this.splitContainer4.Panel1.Controls.Add(this.btnProdutoAdicionar);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvProdutos);
            this.splitContainer4.Size = new System.Drawing.Size(384, 249);
            this.splitContainer4.SplitterDistance = 64;
            this.splitContainer4.TabIndex = 16;
            // 
            // ensProduto
            // 
            this.ensProduto.BindingField = null;
            this.ensProduto.DesabilitarAutoCompletar = false;
            this.ensProduto.DesabilitarChekBox = true;
            this.ensProduto.DesabilitarLupa = true;
            this.ensProduto.DesabilitarSeta = false;
            this.ensProduto.EntidadeSelecionada = null;
            this.ensProduto.FormSelecao = null;
            this.ensProduto.LiberadoQuandoCadastroUtilizado = true;
            this.ensProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensProduto.Location = new System.Drawing.Point(63, 7);
            this.ensProduto.ModoVisualizacaoGrid = null;
            this.ensProduto.Name = "ensProduto";
            this.ensProduto.ParametrosBuscaObrigatorios = null;
            this.ensProduto.Size = new System.Drawing.Size(318, 23);
            this.ensProduto.TabIndex = 0;
            this.ensProduto.EntityChange += new System.EventHandler(this.ensProduto_EntityChange);
            // 
            // btnProdutoRemover
            // 
            this.btnProdutoRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProdutoRemover.LiberadoQuandoCadastroUtilizado = true;
            this.btnProdutoRemover.Location = new System.Drawing.Point(306, 36);
            this.btnProdutoRemover.Name = "btnProdutoRemover";
            this.btnProdutoRemover.Size = new System.Drawing.Size(75, 23);
            this.btnProdutoRemover.TabIndex = 2;
            this.btnProdutoRemover.Text = "Remover";
            this.btnProdutoRemover.UseVisualStyleBackColor = true;
            this.btnProdutoRemover.Click += new System.EventHandler(this.btnProdutoRemover_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(13, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Produto";
            // 
            // btnProdutoAdicionar
            // 
            this.btnProdutoAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProdutoAdicionar.LiberadoQuandoCadastroUtilizado = true;
            this.btnProdutoAdicionar.Location = new System.Drawing.Point(225, 36);
            this.btnProdutoAdicionar.Name = "btnProdutoAdicionar";
            this.btnProdutoAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnProdutoAdicionar.TabIndex = 1;
            this.btnProdutoAdicionar.Text = "Adicionar";
            this.btnProdutoAdicionar.UseVisualStyleBackColor = true;
            this.btnProdutoAdicionar.Click += new System.EventHandler(this.btnProdutoAdicionar_Click);
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToOrderColumns = true;
            this.dgvProdutos.CacheDados = null;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.DescricaoProduto});
            this.dgvProdutos.Location = new System.Drawing.Point(0, 0);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(384, 181);
            this.dgvProdutos.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "CodigoProduto";
            this.Codigo.HeaderText = "Produto";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 150;
            // 
            // DescricaoProduto
            // 
            this.DescricaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescricaoProduto.DataPropertyName = "DescricaoProduto";
            this.DescricaoProduto.HeaderText = "Descrição";
            this.DescricaoProduto.Name = "DescricaoProduto";
            this.DescricaoProduto.ReadOnly = true;
            this.DescricaoProduto.Width = 180;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.splitContainer5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 268);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Etiquetas";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5.IsSplitterFixed = true;
            this.splitContainer5.Location = new System.Drawing.Point(3, 16);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btnEtiquetaAdicionar);
            this.splitContainer5.Panel1.Controls.Add(this.btnEtiquetaRemover);
            this.splitContainer5.Panel1.Controls.Add(this.label1);
            this.splitContainer5.Panel1.Controls.Add(this.nudQtdPorEtiqueta);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.dgvEtiquetas);
            this.splitContainer5.Size = new System.Drawing.Size(386, 249);
            this.splitContainer5.SplitterDistance = 64;
            this.splitContainer5.TabIndex = 30;
            // 
            // btnEtiquetaAdicionar
            // 
            this.btnEtiquetaAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEtiquetaAdicionar.LiberadoQuandoCadastroUtilizado = true;
            this.btnEtiquetaAdicionar.Location = new System.Drawing.Point(221, 36);
            this.btnEtiquetaAdicionar.Name = "btnEtiquetaAdicionar";
            this.btnEtiquetaAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnEtiquetaAdicionar.TabIndex = 2;
            this.btnEtiquetaAdicionar.Text = "Adicionar";
            this.btnEtiquetaAdicionar.UseVisualStyleBackColor = true;
            this.btnEtiquetaAdicionar.Click += new System.EventHandler(this.btnEtiquetaAdicionar_Click);
            // 
            // btnEtiquetaRemover
            // 
            this.btnEtiquetaRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEtiquetaRemover.LiberadoQuandoCadastroUtilizado = true;
            this.btnEtiquetaRemover.Location = new System.Drawing.Point(302, 36);
            this.btnEtiquetaRemover.Name = "btnEtiquetaRemover";
            this.btnEtiquetaRemover.Size = new System.Drawing.Size(75, 23);
            this.btnEtiquetaRemover.TabIndex = 3;
            this.btnEtiquetaRemover.Text = "Remover";
            this.btnEtiquetaRemover.UseVisualStyleBackColor = true;
            this.btnEtiquetaRemover.Click += new System.EventHandler(this.btnEtiquetaRemover_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Quantidade por Etiqueta";
            // 
            // nudQtdPorEtiqueta
            // 
            this.nudQtdPorEtiqueta.BindingField = null;
            this.nudQtdPorEtiqueta.DecimalPlaces = 2;
            this.nudQtdPorEtiqueta.LiberadoQuandoCadastroUtilizado = true;
            this.nudQtdPorEtiqueta.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtdPorEtiqueta.Location = new System.Drawing.Point(141, 10);
            this.nudQtdPorEtiqueta.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudQtdPorEtiqueta.Name = "nudQtdPorEtiqueta";
            this.nudQtdPorEtiqueta.Size = new System.Drawing.Size(106, 20);
            this.nudQtdPorEtiqueta.TabIndex = 1;
            this.nudQtdPorEtiqueta.ValueChanged += new System.EventHandler(this.nudQtdPorEtiqueta_ValueChanged);
            // 
            // dgvEtiquetas
            // 
            this.dgvEtiquetas.AllowUserToAddRows = false;
            this.dgvEtiquetas.AllowUserToDeleteRows = false;
            this.dgvEtiquetas.AllowUserToOrderColumns = true;
            this.dgvEtiquetas.CacheDados = null;
            this.dgvEtiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEtiquetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QtdPorEtiqueta});
            this.dgvEtiquetas.Location = new System.Drawing.Point(0, 0);
            this.dgvEtiquetas.Name = "dgvEtiquetas";
            this.dgvEtiquetas.ReadOnly = true;
            this.dgvEtiquetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEtiquetas.Size = new System.Drawing.Size(386, 181);
            this.dgvEtiquetas.TabIndex = 1;
            // 
            // QtdPorEtiqueta
            // 
            this.QtdPorEtiqueta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QtdPorEtiqueta.DataPropertyName = "QuantidadePorEtiqueta";
            this.QtdPorEtiqueta.HeaderText = "Quantidade de Itens por Etiqueta";
            this.QtdPorEtiqueta.Name = "QtdPorEtiqueta";
            this.QtdPorEtiqueta.ReadOnly = true;
            this.QtdPorEtiqueta.Width = 300;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 557);
            this.tabControl1.TabIndex = 43;
            // 
            // btnSalvarComo
            // 
            this.btnSalvarComo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarComo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvarComo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarComo.LiberadoQuandoCadastroUtilizado = true;
            this.btnSalvarComo.Location = new System.Drawing.Point(308, 31);
            this.btnSalvarComo.Name = "btnSalvarComo";
            this.btnSalvarComo.Size = new System.Drawing.Size(185, 23);
            this.btnSalvarComo.TabIndex = 3;
            this.btnSalvarComo.Text = "Copiar Kanban de Itens Manufaturados";
            this.btnSalvarComo.UseVisualStyleBackColor = false;
            this.btnSalvarComo.Click += new System.EventHandler(this.btnSalvarComo_Click);
            // 
            // CadAgrupadorItemSemelhanteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(800, 634);
            this.Name = "CadAgrupadorItemSemelhanteForm";
            this.Text = "Kanban de Itens Manufaturados";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLoteProducao)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVermelho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmarelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerde)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdPorEtiqueta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEtiquetas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private SplitContainer splitContainer2;
        private GroupBox groupBox4;
        private IWTDotNetLib.IWTLabel label17;
        private IWTDotNetLib.IWTLabel lblVermelhoSugerido;
        private IWTDotNetLib.IWTLabel label18;
        private IWTDotNetLib.IWTLabel lblVerdeSugerido;
        private IWTDotNetLib.IWTLabel label19;
        private IWTDotNetLib.IWTLabel lbAmareloSugerido;
        private IWTTextBox txtDimensao;
        private IWTTextBox txtCodigo;
        private IWTCheckBox chkDimensaoQuantidade;
        private IWTDotNetLib.IWTLabel label3;
        private IWTMultiColumnComboBox cmbClassificacao;
        private IWTDotNetLib.IWTLabel label11;
        private IWTDotNetLib.IWTLabel label4;
        private IWTNumericUpDown nudQtdContainer;
        private IWTCheckBox chkAtivo;
        private IWTDotNetLib.IWTLabel label10;
        private IWTCheckBox chkEtiqueta;
        private IWTNumericUpDown nudVermelho;
        private IWTCheckBox chkEmiteOp;
        private IWTDotNetLib.IWTLabel label9;
        private IWTDotNetLib.IWTLabel label6;
        private IWTNumericUpDown nudAmarelo;
        private IWTDotNetLib.IWTLabel label8;
        private IWTDotNetLib.IWTLabel label7;
        private IWTNumericUpDown nudVerde;
        private SplitContainer splitContainer3;
        private GroupBox groupBox2;
        private SplitContainer splitContainer4;
        private IWTDotNetLib.IWTButton btnProdutoRemover;
        private IWTDotNetLib.IWTLabel label5;
        private IWTDotNetLib.IWTButton btnProdutoAdicionar;
        private IWTDataGridView dgvProdutos;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn DescricaoProduto;
        private GroupBox groupBox3;
        private SplitContainer splitContainer5;
        private IWTDotNetLib.IWTButton btnEtiquetaAdicionar;
        private IWTDotNetLib.IWTButton btnEtiquetaRemover;
        private IWTDotNetLib.IWTLabel label1;
        private IWTNumericUpDown nudQtdPorEtiqueta;
        private IWTDataGridView dgvEtiquetas;
        private DataGridViewTextBoxColumn QtdPorEtiqueta;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private IWTDotNetLib.IWTLabel label24;
        private IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel label25;
        private IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel label26;
        private IWTLabel lblRevisaoUsuario;
        private GroupBox groupBox5;
        private IWTDotNetLib.IWTRadioButton rdAgrupador;
        private IWTDotNetLib.IWTRadioButton rdKbManufaturado;
        private IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTLabel label2;
        private IWTNumericUpDown nudLoteProducao;
        private IWTEntitySelection ensProduto;
        private IWTButton btnSalvarComo;

    }
}