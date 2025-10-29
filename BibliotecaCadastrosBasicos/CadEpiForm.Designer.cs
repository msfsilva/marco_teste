using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadEpiForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblSugestaoLeadTime = new IWTDotNetLib.IWTLabel(this.components);
            this.ensUnidadeMedidaCompra = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.lblLeadtimeCompras = new IWTDotNetLib.IWTLabel(this.components);
            this.lblLeadtimePCP = new IWTDotNetLib.IWTLabel(this.components);
            this.lblUnidades = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtNumericUpDown7 = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtNumericUpDown4 = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel18 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQtdUtilUnidCompPrincipal = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel26 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel15 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudMargemRecebimento = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel13 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtNumericUpDown5 = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel12 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel11 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.iwtCheckBox1 = new IWTDotNetLib.IWTCheckBox(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRevisarVermelho = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisarAmarelo = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisarVerde = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtNumericUpDown3 = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtNumericUpDown2 = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtNumericUpDown1 = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel8 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel9 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblVermelhoSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.lblAmareloSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.lblVerdeSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ensUnidadeUso = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensCA = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox5 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel17 = new IWTDotNetLib.IWTLabel(this.components);
            this.cbxControleValidade = new IWTDotNetLib.IWTCheckBox(this.components);
            this.nudControleValidadeMeses = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel16 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox3 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox4 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel14 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtIdentificacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel10 = new IWTDotNetLib.IWTLabel(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chkFornecedorPreferencial = new IWTDotNetLib.IWTCheckBox(this.components);
            this.ensFornecedor = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.chk = new IWTDotNetLib.IWTCheckBox(this.components);
            this.txt = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtCheckBox2 = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtTextBox7 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel24 = new IWTDotNetLib.IWTLabel(this.components);
            this.cbxUnidadeCompraFornecedor = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtLabel28 = new IWTDotNetLib.IWTLabel(this.components);
            this.grbUnidadeCompraFornecedor = new System.Windows.Forms.GroupBox();
            this.cmbUnidCompraSobre = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel19 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel27 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudLotePadraoSob = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudLoteMinSob = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel25 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQtdUnidUtilComp = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel20 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnRemove = new IWTDotNetLib.IWTButton(this.components);
            this.btnAdd = new IWTDotNetLib.IWTButton(this.components);
            this.lblUnidCompraEpi = new IWTDotNetLib.IWTLabel(this.components);
            this.nudUltimoPreco = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel23 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudIcmsIncluso = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel22 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudIpiNaoIncluso = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel21 = new IWTDotNetLib.IWTLabel(this.components);
            this.dgvFornecedores = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimoPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedidaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadesPorUnidadeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoteMinimoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotePadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreferencialColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label24 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.label25 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.label26 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.btnSalvarComo = new System.Windows.Forms.Button();
            this.chkMargemRecebimento = new IWTDotNetLib.IWTCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdUtilUnidCompPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargemRecebimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown5)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudControleValidadeMeses)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ensFornecedor.SuspendLayout();
            this.grbUnidadeCompraFornecedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLotePadraoSob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoteMinSob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdUnidUtilComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUltimoPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIcmsIncluso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIpiNaoIncluso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFornecedores)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(849, 684);
            this.splitContainer1.SplitterDistance = 618;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(762, 20);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(849, 618);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(841, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EPI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkMargemRecebimento);
            this.groupBox5.Controls.Add(this.lblSugestaoLeadTime);
            this.groupBox5.Controls.Add(this.ensUnidadeMedidaCompra);
            this.groupBox5.Controls.Add(this.lblLeadtimeCompras);
            this.groupBox5.Controls.Add(this.lblLeadtimePCP);
            this.groupBox5.Controls.Add(this.lblUnidades);
            this.groupBox5.Controls.Add(this.iwtNumericUpDown7);
            this.groupBox5.Controls.Add(this.iwtNumericUpDown4);
            this.groupBox5.Controls.Add(this.iwtLabel18);
            this.groupBox5.Controls.Add(this.nudQtdUtilUnidCompPrincipal);
            this.groupBox5.Controls.Add(this.iwtLabel26);
            this.groupBox5.Controls.Add(this.iwtLabel15);
            this.groupBox5.Controls.Add(this.nudMargemRecebimento);
            this.groupBox5.Controls.Add(this.iwtLabel13);
            this.groupBox5.Controls.Add(this.iwtNumericUpDown5);
            this.groupBox5.Controls.Add(this.iwtLabel12);
            this.groupBox5.Controls.Add(this.iwtLabel11);
            this.groupBox5.Location = new System.Drawing.Point(8, 237);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(827, 190);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Compras";
            // 
            // lblSugestaoLeadTime
            // 
            this.lblSugestaoLeadTime.BindingField = null;
            this.lblSugestaoLeadTime.LiberadoQuandoCadastroUtilizado = false;
            this.lblSugestaoLeadTime.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblSugestaoLeadTime.Location = new System.Drawing.Point(520, 125);
            this.lblSugestaoLeadTime.Name = "lblSugestaoLeadTime";
            this.lblSugestaoLeadTime.Size = new System.Drawing.Size(298, 22);
            this.lblSugestaoLeadTime.TabIndex = 51;
            this.lblSugestaoLeadTime.Text = "Leadtime Aquisição Calculado";
            // 
            // ensUnidadeMedidaCompra
            // 
            this.ensUnidadeMedidaCompra.BindingField = "UnidadeMedidaCompra";
            this.ensUnidadeMedidaCompra.ColunasDropdown = null;
            this.ensUnidadeMedidaCompra.DesabilitarAutoCompletar = false;
            this.ensUnidadeMedidaCompra.DesabilitarChekBox = false;
            this.ensUnidadeMedidaCompra.DesabilitarLupa = false;
            this.ensUnidadeMedidaCompra.DesabilitarSeta = false;
            this.ensUnidadeMedidaCompra.EntidadeSelecionada = null;
            this.ensUnidadeMedidaCompra.FormSelecao = null;
            this.ensUnidadeMedidaCompra.LiberadoQuandoCadastroUtilizado = false;
            this.ensUnidadeMedidaCompra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensUnidadeMedidaCompra.Location = new System.Drawing.Point(152, 19);
            this.ensUnidadeMedidaCompra.ModoVisualizacaoGrid = null;
            this.ensUnidadeMedidaCompra.Name = "ensUnidadeMedidaCompra";
            this.ensUnidadeMedidaCompra.ParametroBuscaGuiada = null;
            this.ensUnidadeMedidaCompra.ParametrosBuscaObrigatorios = null;
            this.ensUnidadeMedidaCompra.Size = new System.Drawing.Size(360, 23);
            this.ensUnidadeMedidaCompra.TabIndex = 0;
            this.ensUnidadeMedidaCompra.EntityChange += new System.EventHandler(this.ensUnidadeMedidaCompra_EntityChange);
            this.ensUnidadeMedidaCompra.Leave += new System.EventHandler(this.ensUnidadeMedidaCompra_Leave);
            // 
            // lblLeadtimeCompras
            // 
            this.lblLeadtimeCompras.BindingField = null;
            this.lblLeadtimeCompras.LiberadoQuandoCadastroUtilizado = false;
            this.lblLeadtimeCompras.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblLeadtimeCompras.Location = new System.Drawing.Point(520, 100);
            this.lblLeadtimeCompras.Name = "lblLeadtimeCompras";
            this.lblLeadtimeCompras.Size = new System.Drawing.Size(298, 22);
            this.lblLeadtimeCompras.TabIndex = 50;
            // 
            // lblLeadtimePCP
            // 
            this.lblLeadtimePCP.BindingField = null;
            this.lblLeadtimePCP.LiberadoQuandoCadastroUtilizado = false;
            this.lblLeadtimePCP.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblLeadtimePCP.Location = new System.Drawing.Point(520, 74);
            this.lblLeadtimePCP.Name = "lblLeadtimePCP";
            this.lblLeadtimePCP.Size = new System.Drawing.Size(298, 22);
            this.lblLeadtimePCP.TabIndex = 49;
            // 
            // lblUnidades
            // 
            this.lblUnidades.BindingField = null;
            this.lblUnidades.LiberadoQuandoCadastroUtilizado = false;
            this.lblUnidades.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblUnidades.Location = new System.Drawing.Point(520, 49);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(298, 22);
            this.lblUnidades.TabIndex = 48;
            // 
            // iwtNumericUpDown7
            // 
            this.iwtNumericUpDown7.BindingField = "LoteMinimo";
            this.iwtNumericUpDown7.DecimalPlaces = 4;
            this.iwtNumericUpDown7.LiberadoQuandoCadastroUtilizado = true;
            this.iwtNumericUpDown7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtNumericUpDown7.Location = new System.Drawing.Point(323, 76);
            this.iwtNumericUpDown7.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.iwtNumericUpDown7.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iwtNumericUpDown7.Name = "iwtNumericUpDown7";
            this.iwtNumericUpDown7.Size = new System.Drawing.Size(189, 20);
            this.iwtNumericUpDown7.TabIndex = 2;
            this.iwtNumericUpDown7.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtNumericUpDown4
            // 
            this.iwtNumericUpDown4.BindingField = "LotePadrao";
            this.iwtNumericUpDown4.DecimalPlaces = 4;
            this.iwtNumericUpDown4.LiberadoQuandoCadastroUtilizado = true;
            this.iwtNumericUpDown4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtNumericUpDown4.Location = new System.Drawing.Point(323, 102);
            this.iwtNumericUpDown4.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.iwtNumericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iwtNumericUpDown4.Name = "iwtNumericUpDown4";
            this.iwtNumericUpDown4.Size = new System.Drawing.Size(189, 20);
            this.iwtNumericUpDown4.TabIndex = 3;
            this.iwtNumericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel18
            // 
            this.iwtLabel18.AutoSize = true;
            this.iwtLabel18.BindingField = null;
            this.iwtLabel18.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel18.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel18.Location = new System.Drawing.Point(56, 78);
            this.iwtLabel18.Name = "iwtLabel18";
            this.iwtLabel18.Size = new System.Drawing.Size(265, 13);
            this.iwtLabel18.TabIndex = 20;
            this.iwtLabel18.Text = "Lote Minimo de Fornecimento em Unidades de Compra";
            // 
            // nudQtdUtilUnidCompPrincipal
            // 
            this.nudQtdUtilUnidCompPrincipal.BindingField = "UnidadesPorUnidadeCompra";
            this.nudQtdUtilUnidCompPrincipal.DecimalPlaces = 4;
            this.nudQtdUtilUnidCompPrincipal.LiberadoQuandoCadastroUtilizado = false;
            this.nudQtdUtilUnidCompPrincipal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtdUtilUnidCompPrincipal.Location = new System.Drawing.Point(323, 50);
            this.nudQtdUtilUnidCompPrincipal.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudQtdUtilUnidCompPrincipal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtdUtilUnidCompPrincipal.Name = "nudQtdUtilUnidCompPrincipal";
            this.nudQtdUtilUnidCompPrincipal.Size = new System.Drawing.Size(189, 20);
            this.nudQtdUtilUnidCompPrincipal.TabIndex = 1;
            this.nudQtdUtilUnidCompPrincipal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtdUtilUnidCompPrincipal.ValueChanged += new System.EventHandler(this.iwtNumericUpDown12_ValueChanged);
            // 
            // iwtLabel26
            // 
            this.iwtLabel26.AutoSize = true;
            this.iwtLabel26.BindingField = null;
            this.iwtLabel26.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel26.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel26.Location = new System.Drawing.Point(56, 104);
            this.iwtLabel26.Name = "iwtLabel26";
            this.iwtLabel26.Size = new System.Drawing.Size(266, 13);
            this.iwtLabel26.TabIndex = 20;
            this.iwtLabel26.Text = "Lote Padrão de Fornecimento em Unidades de Compra";
            // 
            // iwtLabel15
            // 
            this.iwtLabel15.AutoSize = true;
            this.iwtLabel15.BindingField = null;
            this.iwtLabel15.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel15.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel15.Location = new System.Drawing.Point(126, 156);
            this.iwtLabel15.Name = "iwtLabel15";
            this.iwtLabel15.Size = new System.Drawing.Size(191, 13);
            this.iwtLabel15.TabIndex = 18;
            this.iwtLabel15.Text = "Margem de Aceite de Recebimento (%)";
            // 
            // nudMargemRecebimento
            // 
            this.nudMargemRecebimento.BindingField = "MargemRecebimento";
            this.nudMargemRecebimento.DecimalPlaces = 2;
            this.nudMargemRecebimento.LiberadoQuandoCadastroUtilizado = true;
            this.nudMargemRecebimento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudMargemRecebimento.Location = new System.Drawing.Point(323, 154);
            this.nudMargemRecebimento.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudMargemRecebimento.Name = "nudMargemRecebimento";
            this.nudMargemRecebimento.Size = new System.Drawing.Size(189, 20);
            this.nudMargemRecebimento.TabIndex = 5;
            // 
            // iwtLabel13
            // 
            this.iwtLabel13.AutoSize = true;
            this.iwtLabel13.BindingField = null;
            this.iwtLabel13.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel13.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel13.Location = new System.Drawing.Point(176, 130);
            this.iwtLabel13.Name = "iwtLabel13";
            this.iwtLabel13.Size = new System.Drawing.Size(142, 13);
            this.iwtLabel13.TabIndex = 14;
            this.iwtLabel13.Text = "Leadtime de Aquisição (dias)";
            // 
            // iwtNumericUpDown5
            // 
            this.iwtNumericUpDown5.BindingField = "LeadTimeCompra";
            this.iwtNumericUpDown5.LiberadoQuandoCadastroUtilizado = true;
            this.iwtNumericUpDown5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtNumericUpDown5.Location = new System.Drawing.Point(323, 128);
            this.iwtNumericUpDown5.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.iwtNumericUpDown5.Name = "iwtNumericUpDown5";
            this.iwtNumericUpDown5.Size = new System.Drawing.Size(189, 20);
            this.iwtNumericUpDown5.TabIndex = 4;
            // 
            // iwtLabel12
            // 
            this.iwtLabel12.AutoSize = true;
            this.iwtLabel12.BindingField = null;
            this.iwtLabel12.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel12.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel12.Location = new System.Drawing.Point(13, 52);
            this.iwtLabel12.Name = "iwtLabel12";
            this.iwtLabel12.Size = new System.Drawing.Size(304, 13);
            this.iwtLabel12.TabIndex = 12;
            this.iwtLabel12.Text = "Quantidade de Unidades de Utilização por Unidade de Compra";
            // 
            // iwtLabel11
            // 
            this.iwtLabel11.AutoSize = true;
            this.iwtLabel11.BindingField = null;
            this.iwtLabel11.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel11.Location = new System.Drawing.Point(47, 26);
            this.iwtLabel11.Name = "iwtLabel11";
            this.iwtLabel11.Size = new System.Drawing.Size(101, 13);
            this.iwtLabel11.TabIndex = 5;
            this.iwtLabel11.Text = "Unidade de Compra";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.iwtCheckBox1);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(8, 433);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(829, 153);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Política de Estoque";
            // 
            // iwtCheckBox1
            // 
            this.iwtCheckBox1.AutoSize = true;
            this.iwtCheckBox1.BindingField = "ImpedirSolicitacaoAutomatica";
            this.iwtCheckBox1.LiberadoQuandoCadastroUtilizado = true;
            this.iwtCheckBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtCheckBox1.Location = new System.Drawing.Point(11, 131);
            this.iwtCheckBox1.Name = "iwtCheckBox1";
            this.iwtCheckBox1.Size = new System.Drawing.Size(284, 17);
            this.iwtCheckBox1.TabIndex = 0;
            this.iwtCheckBox1.Text = "Impedir Geração Automática de Solicitação de Compra";
            this.iwtCheckBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblRevisarVermelho);
            this.groupBox4.Controls.Add(this.lblRevisarAmarelo);
            this.groupBox4.Controls.Add(this.lblRevisarVerde);
            this.groupBox4.Controls.Add(this.iwtNumericUpDown3);
            this.groupBox4.Controls.Add(this.iwtNumericUpDown2);
            this.groupBox4.Controls.Add(this.iwtNumericUpDown1);
            this.groupBox4.Controls.Add(this.iwtLabel7);
            this.groupBox4.Controls.Add(this.iwtLabel8);
            this.groupBox4.Controls.Add(this.iwtLabel9);
            this.groupBox4.Location = new System.Drawing.Point(250, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 106);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estoque de Segurança Configurados";
            // 
            // lblRevisarVermelho
            // 
            this.lblRevisarVermelho.AutoSize = true;
            this.lblRevisarVermelho.BindingField = null;
            this.lblRevisarVermelho.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisarVermelho.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisarVermelho.Location = new System.Drawing.Point(228, 77);
            this.lblRevisarVermelho.Name = "lblRevisarVermelho";
            this.lblRevisarVermelho.Size = new System.Drawing.Size(0, 13);
            this.lblRevisarVermelho.TabIndex = 15;
            // 
            // lblRevisarAmarelo
            // 
            this.lblRevisarAmarelo.AutoSize = true;
            this.lblRevisarAmarelo.BindingField = null;
            this.lblRevisarAmarelo.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisarAmarelo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisarAmarelo.Location = new System.Drawing.Point(228, 52);
            this.lblRevisarAmarelo.Name = "lblRevisarAmarelo";
            this.lblRevisarAmarelo.Size = new System.Drawing.Size(0, 13);
            this.lblRevisarAmarelo.TabIndex = 14;
            // 
            // lblRevisarVerde
            // 
            this.lblRevisarVerde.AutoSize = true;
            this.lblRevisarVerde.BindingField = null;
            this.lblRevisarVerde.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisarVerde.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisarVerde.Location = new System.Drawing.Point(228, 27);
            this.lblRevisarVerde.Name = "lblRevisarVerde";
            this.lblRevisarVerde.Size = new System.Drawing.Size(0, 13);
            this.lblRevisarVerde.TabIndex = 13;
            // 
            // iwtNumericUpDown3
            // 
            this.iwtNumericUpDown3.BindingField = "Vermelho";
            this.iwtNumericUpDown3.LiberadoQuandoCadastroUtilizado = true;
            this.iwtNumericUpDown3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtNumericUpDown3.Location = new System.Drawing.Point(76, 75);
            this.iwtNumericUpDown3.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.iwtNumericUpDown3.Name = "iwtNumericUpDown3";
            this.iwtNumericUpDown3.Size = new System.Drawing.Size(145, 20);
            this.iwtNumericUpDown3.TabIndex = 2;
            // 
            // iwtNumericUpDown2
            // 
            this.iwtNumericUpDown2.BindingField = "Amarelo";
            this.iwtNumericUpDown2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtNumericUpDown2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtNumericUpDown2.Location = new System.Drawing.Point(76, 49);
            this.iwtNumericUpDown2.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.iwtNumericUpDown2.Name = "iwtNumericUpDown2";
            this.iwtNumericUpDown2.Size = new System.Drawing.Size(145, 20);
            this.iwtNumericUpDown2.TabIndex = 1;
            // 
            // iwtNumericUpDown1
            // 
            this.iwtNumericUpDown1.BindingField = "Verde";
            this.iwtNumericUpDown1.LiberadoQuandoCadastroUtilizado = true;
            this.iwtNumericUpDown1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtNumericUpDown1.Location = new System.Drawing.Point(76, 23);
            this.iwtNumericUpDown1.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.iwtNumericUpDown1.Name = "iwtNumericUpDown1";
            this.iwtNumericUpDown1.Size = new System.Drawing.Size(145, 20);
            this.iwtNumericUpDown1.TabIndex = 0;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(19, 77);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(51, 13);
            this.iwtLabel7.TabIndex = 9;
            this.iwtLabel7.Text = "Vermelho";
            // 
            // iwtLabel8
            // 
            this.iwtLabel8.AutoSize = true;
            this.iwtLabel8.BindingField = null;
            this.iwtLabel8.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel8.Location = new System.Drawing.Point(19, 51);
            this.iwtLabel8.Name = "iwtLabel8";
            this.iwtLabel8.Size = new System.Drawing.Size(45, 13);
            this.iwtLabel8.TabIndex = 8;
            this.iwtLabel8.Text = "Amarelo";
            // 
            // iwtLabel9
            // 
            this.iwtLabel9.AutoSize = true;
            this.iwtLabel9.BindingField = null;
            this.iwtLabel9.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel9.Location = new System.Drawing.Point(19, 25);
            this.iwtLabel9.Name = "iwtLabel9";
            this.iwtLabel9.Size = new System.Drawing.Size(35, 13);
            this.iwtLabel9.TabIndex = 7;
            this.iwtLabel9.Text = "Verde";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.iwtLabel6);
            this.groupBox3.Controls.Add(this.iwtLabel5);
            this.groupBox3.Controls.Add(this.iwtLabel4);
            this.groupBox3.Controls.Add(this.lblVermelhoSugerido);
            this.groupBox3.Controls.Add(this.lblAmareloSugerido);
            this.groupBox3.Controls.Add(this.lblVerdeSugerido);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 106);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Demanda Sugerida";
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(16, 77);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(51, 13);
            this.iwtLabel6.TabIndex = 12;
            this.iwtLabel6.Text = "Vermelho";
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(16, 51);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(45, 13);
            this.iwtLabel5.TabIndex = 11;
            this.iwtLabel5.Text = "Amarelo";
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(16, 25);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(35, 13);
            this.iwtLabel4.TabIndex = 10;
            this.iwtLabel4.Text = "Verde";
            // 
            // lblVermelhoSugerido
            // 
            this.lblVermelhoSugerido.AutoSize = true;
            this.lblVermelhoSugerido.BackColor = System.Drawing.Color.Red;
            this.lblVermelhoSugerido.BindingField = null;
            this.lblVermelhoSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lblVermelhoSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblVermelhoSugerido.Location = new System.Drawing.Point(74, 77);
            this.lblVermelhoSugerido.Name = "lblVermelhoSugerido";
            this.lblVermelhoSugerido.Size = new System.Drawing.Size(0, 13);
            this.lblVermelhoSugerido.TabIndex = 9;
            // 
            // lblAmareloSugerido
            // 
            this.lblAmareloSugerido.AutoSize = true;
            this.lblAmareloSugerido.BackColor = System.Drawing.Color.Yellow;
            this.lblAmareloSugerido.BindingField = null;
            this.lblAmareloSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lblAmareloSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblAmareloSugerido.Location = new System.Drawing.Point(74, 51);
            this.lblAmareloSugerido.Name = "lblAmareloSugerido";
            this.lblAmareloSugerido.Size = new System.Drawing.Size(0, 13);
            this.lblAmareloSugerido.TabIndex = 8;
            // 
            // lblVerdeSugerido
            // 
            this.lblVerdeSugerido.AutoSize = true;
            this.lblVerdeSugerido.BackColor = System.Drawing.Color.Lime;
            this.lblVerdeSugerido.BindingField = null;
            this.lblVerdeSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lblVerdeSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblVerdeSugerido.Location = new System.Drawing.Point(74, 25);
            this.lblVerdeSugerido.Name = "lblVerdeSugerido";
            this.lblVerdeSugerido.Size = new System.Drawing.Size(0, 13);
            this.lblVerdeSugerido.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ensUnidadeUso);
            this.groupBox1.Controls.Add(this.ensCA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.iwtTextBox5);
            this.groupBox1.Controls.Add(this.iwtLabel17);
            this.groupBox1.Controls.Add(this.cbxControleValidade);
            this.groupBox1.Controls.Add(this.nudControleValidadeMeses);
            this.groupBox1.Controls.Add(this.iwtLabel16);
            this.groupBox1.Controls.Add(this.iwtTextBox3);
            this.groupBox1.Controls.Add(this.iwtLabel3);
            this.groupBox1.Controls.Add(this.iwtTextBox4);
            this.groupBox1.Controls.Add(this.iwtLabel14);
            this.groupBox1.Controls.Add(this.iwtTextBox2);
            this.groupBox1.Controls.Add(this.txtIdentificacao);
            this.groupBox1.Controls.Add(this.iwtLabel2);
            this.groupBox1.Controls.Add(this.iwtLabel1);
            this.groupBox1.Controls.Add(this.iwtLabel10);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // ensUnidadeUso
            // 
            this.ensUnidadeUso.BindingField = "UnidadeMedidaUso";
            this.ensUnidadeUso.ColunasDropdown = null;
            this.ensUnidadeUso.DesabilitarAutoCompletar = false;
            this.ensUnidadeUso.DesabilitarChekBox = true;
            this.ensUnidadeUso.DesabilitarLupa = false;
            this.ensUnidadeUso.DesabilitarSeta = false;
            this.ensUnidadeUso.EntidadeSelecionada = null;
            this.ensUnidadeUso.FormSelecao = null;
            this.ensUnidadeUso.LiberadoQuandoCadastroUtilizado = false;
            this.ensUnidadeUso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensUnidadeUso.Location = new System.Drawing.Point(152, 97);
            this.ensUnidadeUso.ModoVisualizacaoGrid = null;
            this.ensUnidadeUso.Name = "ensUnidadeUso";
            this.ensUnidadeUso.ParametroBuscaGuiada = null;
            this.ensUnidadeUso.ParametrosBuscaObrigatorios = null;
            this.ensUnidadeUso.Size = new System.Drawing.Size(472, 23);
            this.ensUnidadeUso.TabIndex = 3;
            this.ensUnidadeUso.EntityChange += new System.EventHandler(this.ensUnidadeUso_EntityChange);
            this.ensUnidadeUso.Leave += new System.EventHandler(this.ensUnidadeUso_Leave);
            // 
            // ensCA
            // 
            this.ensCA.BindingField = "EpiCa";
            this.ensCA.ColunasDropdown = null;
            this.ensCA.DesabilitarAutoCompletar = false;
            this.ensCA.DesabilitarChekBox = true;
            this.ensCA.DesabilitarLupa = false;
            this.ensCA.DesabilitarSeta = false;
            this.ensCA.EntidadeSelecionada = null;
            this.ensCA.FormSelecao = null;
            this.ensCA.LiberadoQuandoCadastroUtilizado = false;
            this.ensCA.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensCA.Location = new System.Drawing.Point(354, 154);
            this.ensCA.ModoVisualizacaoGrid = null;
            this.ensCA.Name = "ensCA";
            this.ensCA.ParametroBuscaGuiada = null;
            this.ensCA.ParametrosBuscaObrigatorios = null;
            this.ensCA.Size = new System.Drawing.Size(270, 23);
            this.ensCA.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(321, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "C.A.";
            // 
            // iwtTextBox5
            // 
            this.iwtTextBox5.BindingField = "Observacao";
            this.iwtTextBox5.DebugMode = false;
            this.iwtTextBox5.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox5.Location = new System.Drawing.Point(152, 180);
            this.iwtTextBox5.ModoBarcode = false;
            this.iwtTextBox5.ModoBusca = false;
            this.iwtTextBox5.Multiline = true;
            this.iwtTextBox5.Name = "iwtTextBox5";
            this.iwtTextBox5.NaoLimparDepoisBarcode = false;
            this.iwtTextBox5.Size = new System.Drawing.Size(473, 40);
            this.iwtTextBox5.TabIndex = 8;
            // 
            // iwtLabel17
            // 
            this.iwtLabel17.AutoSize = true;
            this.iwtLabel17.BindingField = null;
            this.iwtLabel17.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel17.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel17.Location = new System.Drawing.Point(81, 183);
            this.iwtLabel17.Name = "iwtLabel17";
            this.iwtLabel17.Size = new System.Drawing.Size(65, 13);
            this.iwtLabel17.TabIndex = 16;
            this.iwtLabel17.Text = "Observação";
            // 
            // cbxControleValidade
            // 
            this.cbxControleValidade.AutoSize = true;
            this.cbxControleValidade.BindingField = "ControleValidade";
            this.cbxControleValidade.Checked = true;
            this.cbxControleValidade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxControleValidade.LiberadoQuandoCadastroUtilizado = true;
            this.cbxControleValidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cbxControleValidade.Location = new System.Drawing.Point(278, 156);
            this.cbxControleValidade.Name = "cbxControleValidade";
            this.cbxControleValidade.Size = new System.Drawing.Size(15, 14);
            this.cbxControleValidade.TabIndex = 5;
            this.cbxControleValidade.UseVisualStyleBackColor = true;
            this.cbxControleValidade.CheckedChanged += new System.EventHandler(this.cbxControleValidade_CheckedChanged);
            // 
            // nudControleValidadeMeses
            // 
            this.nudControleValidadeMeses.BindingField = "ControleValidadeMeses";
            this.nudControleValidadeMeses.LiberadoQuandoCadastroUtilizado = true;
            this.nudControleValidadeMeses.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudControleValidadeMeses.Location = new System.Drawing.Point(152, 154);
            this.nudControleValidadeMeses.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudControleValidadeMeses.Name = "nudControleValidadeMeses";
            this.nudControleValidadeMeses.Size = new System.Drawing.Size(120, 20);
            this.nudControleValidadeMeses.TabIndex = 6;
            // 
            // iwtLabel16
            // 
            this.iwtLabel16.AutoSize = true;
            this.iwtLabel16.BindingField = null;
            this.iwtLabel16.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel16.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel16.Location = new System.Drawing.Point(4, 156);
            this.iwtLabel16.Name = "iwtLabel16";
            this.iwtLabel16.Size = new System.Drawing.Size(145, 13);
            this.iwtLabel16.TabIndex = 13;
            this.iwtLabel16.Text = "Controle de Validade (Meses)";
            // 
            // iwtTextBox3
            // 
            this.iwtTextBox3.BindingField = "DescricaoAdicional";
            this.iwtTextBox3.DebugMode = false;
            this.iwtTextBox3.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox3.Location = new System.Drawing.Point(152, 71);
            this.iwtTextBox3.MaxLength = 255;
            this.iwtTextBox3.ModoBarcode = false;
            this.iwtTextBox3.ModoBusca = false;
            this.iwtTextBox3.Name = "iwtTextBox3";
            this.iwtTextBox3.NaoLimparDepoisBarcode = false;
            this.iwtTextBox3.Size = new System.Drawing.Size(472, 20);
            this.iwtTextBox3.TabIndex = 2;
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(45, 74);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(101, 13);
            this.iwtLabel3.TabIndex = 10;
            this.iwtLabel3.Text = "Descrição Adicional";
            // 
            // iwtTextBox4
            // 
            this.iwtTextBox4.BindingField = "MarcasHomologadas";
            this.iwtTextBox4.DebugMode = false;
            this.iwtTextBox4.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox4.Location = new System.Drawing.Point(152, 128);
            this.iwtTextBox4.MaxLength = 255;
            this.iwtTextBox4.ModoBarcode = false;
            this.iwtTextBox4.ModoBusca = false;
            this.iwtTextBox4.Name = "iwtTextBox4";
            this.iwtTextBox4.NaoLimparDepoisBarcode = false;
            this.iwtTextBox4.Size = new System.Drawing.Size(473, 20);
            this.iwtTextBox4.TabIndex = 4;
            // 
            // iwtLabel14
            // 
            this.iwtLabel14.AutoSize = true;
            this.iwtLabel14.BindingField = null;
            this.iwtLabel14.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel14.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel14.Location = new System.Drawing.Point(36, 131);
            this.iwtLabel14.Name = "iwtLabel14";
            this.iwtLabel14.Size = new System.Drawing.Size(110, 13);
            this.iwtLabel14.TabIndex = 15;
            this.iwtLabel14.Text = "Marcas Homologadas";
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.BindingField = "Descricao";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(152, 45);
            this.iwtTextBox2.MaxLength = 255;
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.ModoBusca = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.NaoLimparDepoisBarcode = false;
            this.iwtTextBox2.Size = new System.Drawing.Size(472, 20);
            this.iwtTextBox2.TabIndex = 1;
            // 
            // txtIdentificacao
            // 
            this.txtIdentificacao.BindingField = "Identificacao";
            this.txtIdentificacao.DebugMode = false;
            this.txtIdentificacao.LiberadoQuandoCadastroUtilizado = false;
            this.txtIdentificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtIdentificacao.Location = new System.Drawing.Point(153, 19);
            this.txtIdentificacao.MaxLength = 20;
            this.txtIdentificacao.ModoBarcode = false;
            this.txtIdentificacao.ModoBusca = false;
            this.txtIdentificacao.Name = "txtIdentificacao";
            this.txtIdentificacao.NaoLimparDepoisBarcode = false;
            this.txtIdentificacao.Size = new System.Drawing.Size(472, 20);
            this.txtIdentificacao.TabIndex = 0;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(91, 48);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(55, 13);
            this.iwtLabel2.TabIndex = 7;
            this.iwtLabel2.Text = "Descrição";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(78, 22);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(68, 13);
            this.iwtLabel1.TabIndex = 6;
            this.iwtLabel1.Text = "Identificação";
            // 
            // iwtLabel10
            // 
            this.iwtLabel10.AutoSize = true;
            this.iwtLabel10.BindingField = null;
            this.iwtLabel10.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel10.Location = new System.Drawing.Point(62, 101);
            this.iwtLabel10.Name = "iwtLabel10";
            this.iwtLabel10.Size = new System.Drawing.Size(84, 13);
            this.iwtLabel10.TabIndex = 2;
            this.iwtLabel10.Text = "Unidade de Uso";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(841, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fornecedores";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chkFornecedorPreferencial);
            this.splitContainer2.Panel1.Controls.Add(this.ensFornecedor);
            this.splitContainer2.Panel1.Controls.Add(this.iwtLabel24);
            this.splitContainer2.Panel1.Controls.Add(this.cbxUnidadeCompraFornecedor);
            this.splitContainer2.Panel1.Controls.Add(this.iwtLabel28);
            this.splitContainer2.Panel1.Controls.Add(this.grbUnidadeCompraFornecedor);
            this.splitContainer2.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer2.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer2.Panel1.Controls.Add(this.lblUnidCompraEpi);
            this.splitContainer2.Panel1.Controls.Add(this.nudUltimoPreco);
            this.splitContainer2.Panel1.Controls.Add(this.iwtLabel23);
            this.splitContainer2.Panel1.Controls.Add(this.nudIcmsIncluso);
            this.splitContainer2.Panel1.Controls.Add(this.iwtLabel22);
            this.splitContainer2.Panel1.Controls.Add(this.nudIpiNaoIncluso);
            this.splitContainer2.Panel1.Controls.Add(this.iwtLabel21);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvFornecedores);
            this.splitContainer2.Size = new System.Drawing.Size(835, 586);
            this.splitContainer2.SplitterDistance = 223;
            this.splitContainer2.TabIndex = 0;
            // 
            // chkFornecedorPreferencial
            // 
            this.chkFornecedorPreferencial.AutoSize = true;
            this.chkFornecedorPreferencial.BindingField = null;
            this.chkFornecedorPreferencial.LiberadoQuandoCadastroUtilizado = false;
            this.chkFornecedorPreferencial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkFornecedorPreferencial.Location = new System.Drawing.Point(582, 49);
            this.chkFornecedorPreferencial.Name = "chkFornecedorPreferencial";
            this.chkFornecedorPreferencial.Size = new System.Drawing.Size(82, 17);
            this.chkFornecedorPreferencial.TabIndex = 3;
            this.chkFornecedorPreferencial.Text = "Preferencial";
            this.chkFornecedorPreferencial.UseVisualStyleBackColor = true;
            // 
            // ensFornecedor
            // 
            this.ensFornecedor.BindingField = null;
            this.ensFornecedor.ColunasDropdown = null;
            this.ensFornecedor.Controls.Add(this.chk);
            this.ensFornecedor.Controls.Add(this.txt);
            this.ensFornecedor.Controls.Add(this.iwtCheckBox2);
            this.ensFornecedor.Controls.Add(this.iwtTextBox7);
            this.ensFornecedor.DesabilitarAutoCompletar = false;
            this.ensFornecedor.DesabilitarChekBox = true;
            this.ensFornecedor.DesabilitarLupa = false;
            this.ensFornecedor.DesabilitarSeta = false;
            this.ensFornecedor.EntidadeSelecionada = null;
            this.ensFornecedor.FormSelecao = null;
            this.ensFornecedor.LiberadoQuandoCadastroUtilizado = false;
            this.ensFornecedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFornecedor.Location = new System.Drawing.Point(83, 17);
            this.ensFornecedor.ModoVisualizacaoGrid = null;
            this.ensFornecedor.Name = "ensFornecedor";
            this.ensFornecedor.ParametroBuscaGuiada = null;
            this.ensFornecedor.ParametrosBuscaObrigatorios = null;
            this.ensFornecedor.Size = new System.Drawing.Size(564, 23);
            this.ensFornecedor.TabIndex = 31;
            // 
            // chk
            // 
            this.chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk.AutoSize = true;
            this.chk.BindingField = "";
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.LiberadoQuandoCadastroUtilizado = false;
            this.chk.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chk.Location = new System.Drawing.Point(80, 4);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(15, 14);
            this.chk.TabIndex = 0;
            this.chk.UseVisualStyleBackColor = true;
            this.chk.Visible = false;
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.BindingField = "";
            this.txt.DebugMode = false;
            this.txt.LiberadoQuandoCadastroUtilizado = false;
            this.txt.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txt.Location = new System.Drawing.Point(0, 1);
            this.txt.ModoBarcode = false;
            this.txt.ModoBusca = false;
            this.txt.Name = "txt";
            this.txt.NaoLimparDepoisBarcode = false;
            this.txt.Size = new System.Drawing.Size(524, 20);
            this.txt.TabIndex = 1;
            // 
            // iwtCheckBox2
            // 
            this.iwtCheckBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtCheckBox2.AutoSize = true;
            this.iwtCheckBox2.BindingField = "";
            this.iwtCheckBox2.Checked = true;
            this.iwtCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iwtCheckBox2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtCheckBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtCheckBox2.Location = new System.Drawing.Point(1022, 4);
            this.iwtCheckBox2.Name = "iwtCheckBox2";
            this.iwtCheckBox2.Size = new System.Drawing.Size(15, 14);
            this.iwtCheckBox2.TabIndex = 1;
            this.iwtCheckBox2.UseVisualStyleBackColor = true;
            this.iwtCheckBox2.Visible = false;
            // 
            // iwtTextBox7
            // 
            this.iwtTextBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox7.BindingField = "";
            this.iwtTextBox7.DebugMode = false;
            this.iwtTextBox7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox7.Location = new System.Drawing.Point(0, 1);
            this.iwtTextBox7.ModoBarcode = false;
            this.iwtTextBox7.ModoBusca = false;
            this.iwtTextBox7.Name = "iwtTextBox7";
            this.iwtTextBox7.NaoLimparDepoisBarcode = false;
            this.iwtTextBox7.Size = new System.Drawing.Size(1005, 20);
            this.iwtTextBox7.TabIndex = 3;
            // 
            // iwtLabel24
            // 
            this.iwtLabel24.AutoSize = true;
            this.iwtLabel24.BindingField = null;
            this.iwtLabel24.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel24.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel24.Location = new System.Drawing.Point(13, 79);
            this.iwtLabel24.Name = "iwtLabel24";
            this.iwtLabel24.Size = new System.Drawing.Size(104, 13);
            this.iwtLabel24.TabIndex = 29;
            this.iwtLabel24.Text = "Unidade de Compra:";
            // 
            // cbxUnidadeCompraFornecedor
            // 
            this.cbxUnidadeCompraFornecedor.AutoSize = true;
            this.cbxUnidadeCompraFornecedor.BindingField = null;
            this.cbxUnidadeCompraFornecedor.LiberadoQuandoCadastroUtilizado = true;
            this.cbxUnidadeCompraFornecedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cbxUnidadeCompraFornecedor.Location = new System.Drawing.Point(480, 144);
            this.cbxUnidadeCompraFornecedor.Name = "cbxUnidadeCompraFornecedor";
            this.cbxUnidadeCompraFornecedor.Size = new System.Drawing.Size(15, 14);
            this.cbxUnidadeCompraFornecedor.TabIndex = 4;
            this.cbxUnidadeCompraFornecedor.UseVisualStyleBackColor = true;
            this.cbxUnidadeCompraFornecedor.CheckedChanged += new System.EventHandler(this.cbxUnidadeCompraFornecedor_CheckedChanged);
            // 
            // iwtLabel28
            // 
            this.iwtLabel28.AutoSize = true;
            this.iwtLabel28.BindingField = null;
            this.iwtLabel28.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel28.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel28.Location = new System.Drawing.Point(16, 22);
            this.iwtLabel28.Name = "iwtLabel28";
            this.iwtLabel28.Size = new System.Drawing.Size(61, 13);
            this.iwtLabel28.TabIndex = 25;
            this.iwtLabel28.Text = "Fornecedor";
            // 
            // grbUnidadeCompraFornecedor
            // 
            this.grbUnidadeCompraFornecedor.Controls.Add(this.cmbUnidCompraSobre);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.iwtLabel19);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.iwtLabel27);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.nudLotePadraoSob);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.nudLoteMinSob);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.iwtLabel25);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.nudQtdUnidUtilComp);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.iwtLabel20);
            this.grbUnidadeCompraFornecedor.Enabled = false;
            this.grbUnidadeCompraFornecedor.Location = new System.Drawing.Point(14, 95);
            this.grbUnidadeCompraFornecedor.Name = "grbUnidadeCompraFornecedor";
            this.grbUnidadeCompraFornecedor.Size = new System.Drawing.Size(460, 125);
            this.grbUnidadeCompraFornecedor.TabIndex = 5;
            this.grbUnidadeCompraFornecedor.TabStop = false;
            this.grbUnidadeCompraFornecedor.Text = "Sobrescrever Unidade de Compra";
            // 
            // cmbUnidCompraSobre
            // 
            this.cmbUnidCompraSobre.BindingField = null;
            this.cmbUnidCompraSobre.ColumnsToDisplay = null;
            this.cmbUnidCompraSobre.DisableAutoSelectOnEmpty = false;
            this.cmbUnidCompraSobre.DropDownHeight = 1;
            this.cmbUnidCompraSobre.FormattingEnabled = true;
            this.cmbUnidCompraSobre.IntegralHeight = false;
            this.cmbUnidCompraSobre.LiberadoQuandoCadastroUtilizado = true;
            this.cmbUnidCompraSobre.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbUnidCompraSobre.Location = new System.Drawing.Point(116, 21);
            this.cmbUnidCompraSobre.Name = "cmbUnidCompraSobre";
            this.cmbUnidCompraSobre.SelectedRow = null;
            this.cmbUnidCompraSobre.Size = new System.Drawing.Size(338, 21);
            this.cmbUnidCompraSobre.TabIndex = 46;
            this.cmbUnidCompraSobre.Table = null;
            // 
            // iwtLabel19
            // 
            this.iwtLabel19.AutoSize = true;
            this.iwtLabel19.BindingField = null;
            this.iwtLabel19.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel19.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel19.Location = new System.Drawing.Point(50, 100);
            this.iwtLabel19.Name = "iwtLabel19";
            this.iwtLabel19.Size = new System.Drawing.Size(263, 13);
            this.iwtLabel19.TabIndex = 45;
            this.iwtLabel19.Text = "Lote Padrão de Fornecimento em unidades de compra";
            // 
            // iwtLabel27
            // 
            this.iwtLabel27.AutoSize = true;
            this.iwtLabel27.BindingField = null;
            this.iwtLabel27.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel27.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel27.Location = new System.Drawing.Point(50, 74);
            this.iwtLabel27.Name = "iwtLabel27";
            this.iwtLabel27.Size = new System.Drawing.Size(262, 13);
            this.iwtLabel27.TabIndex = 45;
            this.iwtLabel27.Text = "Lote Minimo de Fornecimento em unidades de compra";
            // 
            // nudLotePadraoSob
            // 
            this.nudLotePadraoSob.BindingField = null;
            this.nudLotePadraoSob.DecimalPlaces = 4;
            this.nudLotePadraoSob.LiberadoQuandoCadastroUtilizado = true;
            this.nudLotePadraoSob.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLotePadraoSob.Location = new System.Drawing.Point(318, 98);
            this.nudLotePadraoSob.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudLotePadraoSob.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLotePadraoSob.Name = "nudLotePadraoSob";
            this.nudLotePadraoSob.Size = new System.Drawing.Size(136, 20);
            this.nudLotePadraoSob.TabIndex = 44;
            this.nudLotePadraoSob.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudLoteMinSob
            // 
            this.nudLoteMinSob.BindingField = null;
            this.nudLoteMinSob.DecimalPlaces = 4;
            this.nudLoteMinSob.LiberadoQuandoCadastroUtilizado = true;
            this.nudLoteMinSob.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLoteMinSob.Location = new System.Drawing.Point(318, 72);
            this.nudLoteMinSob.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudLoteMinSob.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLoteMinSob.Name = "nudLoteMinSob";
            this.nudLoteMinSob.Size = new System.Drawing.Size(136, 20);
            this.nudLoteMinSob.TabIndex = 44;
            this.nudLoteMinSob.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel25
            // 
            this.iwtLabel25.AutoSize = true;
            this.iwtLabel25.BindingField = null;
            this.iwtLabel25.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel25.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel25.Location = new System.Drawing.Point(8, 48);
            this.iwtLabel25.Name = "iwtLabel25";
            this.iwtLabel25.Size = new System.Drawing.Size(304, 13);
            this.iwtLabel25.TabIndex = 43;
            this.iwtLabel25.Text = "Quantidade de Unidades de Utilização por Unidade de Compra";
            // 
            // nudQtdUnidUtilComp
            // 
            this.nudQtdUnidUtilComp.BindingField = null;
            this.nudQtdUnidUtilComp.DecimalPlaces = 4;
            this.nudQtdUnidUtilComp.LiberadoQuandoCadastroUtilizado = true;
            this.nudQtdUnidUtilComp.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtdUnidUtilComp.Location = new System.Drawing.Point(318, 46);
            this.nudQtdUnidUtilComp.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudQtdUnidUtilComp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtdUnidUtilComp.Name = "nudQtdUnidUtilComp";
            this.nudQtdUnidUtilComp.Size = new System.Drawing.Size(136, 20);
            this.nudQtdUnidUtilComp.TabIndex = 42;
            this.nudQtdUnidUtilComp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel20
            // 
            this.iwtLabel20.AutoSize = true;
            this.iwtLabel20.BindingField = null;
            this.iwtLabel20.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel20.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel20.Location = new System.Drawing.Point(8, 21);
            this.iwtLabel20.Name = "iwtLabel20";
            this.iwtLabel20.Size = new System.Drawing.Size(101, 13);
            this.iwtLabel20.TabIndex = 7;
            this.iwtLabel20.Text = "Unidade de Compra";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.LiberadoQuandoCadastroUtilizado = true;
            this.btnRemove.Location = new System.Drawing.Point(707, 177);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(121, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remover";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.LiberadoQuandoCadastroUtilizado = true;
            this.btnAdd.Location = new System.Drawing.Point(707, 153);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Adicionar/Atualizar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblUnidCompraEpi
            // 
            this.lblUnidCompraEpi.AutoSize = true;
            this.lblUnidCompraEpi.BindingField = null;
            this.lblUnidCompraEpi.LiberadoQuandoCadastroUtilizado = false;
            this.lblUnidCompraEpi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblUnidCompraEpi.Location = new System.Drawing.Point(123, 79);
            this.lblUnidCompraEpi.Name = "lblUnidCompraEpi";
            this.lblUnidCompraEpi.Size = new System.Drawing.Size(0, 13);
            this.lblUnidCompraEpi.TabIndex = 19;
            // 
            // nudUltimoPreco
            // 
            this.nudUltimoPreco.BindingField = null;
            this.nudUltimoPreco.DecimalPlaces = 4;
            this.nudUltimoPreco.LiberadoQuandoCadastroUtilizado = true;
            this.nudUltimoPreco.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudUltimoPreco.Location = new System.Drawing.Point(83, 46);
            this.nudUltimoPreco.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudUltimoPreco.Name = "nudUltimoPreco";
            this.nudUltimoPreco.Size = new System.Drawing.Size(95, 20);
            this.nudUltimoPreco.TabIndex = 0;
            // 
            // iwtLabel23
            // 
            this.iwtLabel23.AutoSize = true;
            this.iwtLabel23.BindingField = null;
            this.iwtLabel23.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel23.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel23.Location = new System.Drawing.Point(388, 52);
            this.iwtLabel23.Name = "iwtLabel23";
            this.iwtLabel23.Size = new System.Drawing.Size(97, 13);
            this.iwtLabel23.TabIndex = 17;
            this.iwtLabel23.Text = "IPI Não Incluso (%)";
            // 
            // nudIcmsIncluso
            // 
            this.nudIcmsIncluso.BindingField = null;
            this.nudIcmsIncluso.DecimalPlaces = 2;
            this.nudIcmsIncluso.LiberadoQuandoCadastroUtilizado = true;
            this.nudIcmsIncluso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudIcmsIncluso.Location = new System.Drawing.Point(286, 48);
            this.nudIcmsIncluso.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudIcmsIncluso.Name = "nudIcmsIncluso";
            this.nudIcmsIncluso.Size = new System.Drawing.Size(69, 20);
            this.nudIcmsIncluso.TabIndex = 1;
            // 
            // iwtLabel22
            // 
            this.iwtLabel22.AutoSize = true;
            this.iwtLabel22.BindingField = null;
            this.iwtLabel22.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel22.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel22.Location = new System.Drawing.Point(193, 50);
            this.iwtLabel22.Name = "iwtLabel22";
            this.iwtLabel22.Size = new System.Drawing.Size(87, 13);
            this.iwtLabel22.TabIndex = 15;
            this.iwtLabel22.Text = "ICMS Incluso (%)";
            // 
            // nudIpiNaoIncluso
            // 
            this.nudIpiNaoIncluso.BindingField = null;
            this.nudIpiNaoIncluso.DecimalPlaces = 2;
            this.nudIpiNaoIncluso.LiberadoQuandoCadastroUtilizado = true;
            this.nudIpiNaoIncluso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudIpiNaoIncluso.Location = new System.Drawing.Point(491, 48);
            this.nudIpiNaoIncluso.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudIpiNaoIncluso.Name = "nudIpiNaoIncluso";
            this.nudIpiNaoIncluso.Size = new System.Drawing.Size(69, 20);
            this.nudIpiNaoIncluso.TabIndex = 2;
            // 
            // iwtLabel21
            // 
            this.iwtLabel21.AutoSize = true;
            this.iwtLabel21.BindingField = null;
            this.iwtLabel21.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel21.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel21.Location = new System.Drawing.Point(13, 48);
            this.iwtLabel21.Name = "iwtLabel21";
            this.iwtLabel21.Size = new System.Drawing.Size(67, 13);
            this.iwtLabel21.TabIndex = 13;
            this.iwtLabel21.Text = "Último Preço";
            // 
            // dgvFornecedores
            // 
            this.dgvFornecedores.AllowUserToAddRows = false;
            this.dgvFornecedores.AllowUserToDeleteRows = false;
            this.dgvFornecedores.AllowUserToOrderColumns = true;
            this.dgvFornecedores.AllowUserToResizeRows = false;
            this.dgvFornecedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvFornecedores.CacheDados = null;
            this.dgvFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFornecedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fornecedor,
            this.UltimoPreco,
            this.Ipi,
            this.Icms,
            this.UltimaCompra,
            this.UnidadeMedidaCompra,
            this.UnidadesPorUnidadeCompra,
            this.LoteMinimoColumn,
            this.LotePadrao,
            this.PreferencialColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFornecedores.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFornecedores.Location = new System.Drawing.Point(0, 0);
            this.dgvFornecedores.Name = "dgvFornecedores";
            this.dgvFornecedores.ReadOnly = true;
            this.dgvFornecedores.RowHeadersVisible = false;
            this.dgvFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFornecedores.Size = new System.Drawing.Size(835, 359);
            this.dgvFornecedores.TabIndex = 0;
            this.dgvFornecedores.SelectionChanged += new System.EventHandler(this.dgvFornecedores_SelectionChanged);
            // 
            // Fornecedor
            // 
            this.Fornecedor.DataPropertyName = "Fornecedor";
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.ReadOnly = true;
            this.Fornecedor.Width = 300;
            // 
            // UltimoPreco
            // 
            this.UltimoPreco.DataPropertyName = "UltimoPreco";
            this.UltimoPreco.HeaderText = "UltimoPreco";
            this.UltimoPreco.Name = "UltimoPreco";
            this.UltimoPreco.ReadOnly = true;
            // 
            // Ipi
            // 
            this.Ipi.DataPropertyName = "Ipi";
            this.Ipi.HeaderText = "IPI";
            this.Ipi.Name = "Ipi";
            this.Ipi.ReadOnly = true;
            this.Ipi.Width = 60;
            // 
            // Icms
            // 
            this.Icms.DataPropertyName = "Icms";
            this.Icms.HeaderText = "ICMS";
            this.Icms.Name = "Icms";
            this.Icms.ReadOnly = true;
            this.Icms.Width = 60;
            // 
            // UltimaCompra
            // 
            this.UltimaCompra.DataPropertyName = "DataUltimaCompra";
            this.UltimaCompra.HeaderText = "Última Compra";
            this.UltimaCompra.Name = "UltimaCompra";
            this.UltimaCompra.ReadOnly = true;
            // 
            // UnidadeMedidaCompra
            // 
            this.UnidadeMedidaCompra.DataPropertyName = "UnidadeMedidaCompra";
            this.UnidadeMedidaCompra.HeaderText = "Unidade de Medida de Compra";
            this.UnidadeMedidaCompra.Name = "UnidadeMedidaCompra";
            this.UnidadeMedidaCompra.ReadOnly = true;
            this.UnidadeMedidaCompra.Width = 50;
            // 
            // UnidadesPorUnidadeCompra
            // 
            this.UnidadesPorUnidadeCompra.DataPropertyName = "UnidadesPorUnCompra";
            this.UnidadesPorUnidadeCompra.HeaderText = "Unidades Por Unidade de Compra";
            this.UnidadesPorUnidadeCompra.Name = "UnidadesPorUnidadeCompra";
            this.UnidadesPorUnidadeCompra.ReadOnly = true;
            this.UnidadesPorUnidadeCompra.Width = 60;
            // 
            // LoteMinimoColumn
            // 
            this.LoteMinimoColumn.DataPropertyName = "LoteMinimo";
            this.LoteMinimoColumn.HeaderText = "Lote Mínimo";
            this.LoteMinimoColumn.Name = "LoteMinimoColumn";
            this.LoteMinimoColumn.ReadOnly = true;
            this.LoteMinimoColumn.Width = 60;
            // 
            // LotePadrao
            // 
            this.LotePadrao.DataPropertyName = "LotePadrao";
            this.LotePadrao.HeaderText = "Lote Padrão";
            this.LotePadrao.Name = "LotePadrao";
            this.LotePadrao.ReadOnly = true;
            this.LotePadrao.Width = 60;
            // 
            // PreferencialColumn
            // 
            this.PreferencialColumn.DataPropertyName = "Preferencial";
            this.PreferencialColumn.HeaderText = "Preferencial";
            this.PreferencialColumn.Name = "PreferencialColumn";
            this.PreferencialColumn.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(841, 592);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ultima Revisão";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.lblRevisao);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.lblRevisaoData);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox6.Location = new System.Drawing.Point(8, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(382, 94);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Revisão";
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
            // btnSalvarComo
            // 
            this.btnSalvarComo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarComo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvarComo.FlatAppearance.BorderSize = 0;
            this.btnSalvarComo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarComo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalvarComo.Location = new System.Drawing.Point(348, 20);
            this.btnSalvarComo.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalvarComo.Name = "btnSalvarComo";
            this.btnSalvarComo.Size = new System.Drawing.Size(152, 23);
            this.btnSalvarComo.TabIndex = 4;
            this.btnSalvarComo.Text = "Copiar EPI";
            this.btnSalvarComo.UseVisualStyleBackColor = false;
            this.btnSalvarComo.Click += new System.EventHandler(this.btnSalvarComo_Click);
            // 
            // chkMargemRecebimento
            // 
            this.chkMargemRecebimento.AutoSize = true;
            this.chkMargemRecebimento.BindingField = "PossuiMargemRecebimento";
            this.chkMargemRecebimento.LiberadoQuandoCadastroUtilizado = true;
            this.chkMargemRecebimento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkMargemRecebimento.Location = new System.Drawing.Point(523, 156);
            this.chkMargemRecebimento.Name = "chkMargemRecebimento";
            this.chkMargemRecebimento.Size = new System.Drawing.Size(15, 14);
            this.chkMargemRecebimento.TabIndex = 52;
            this.chkMargemRecebimento.UseVisualStyleBackColor = true;
            this.chkMargemRecebimento.CheckedChanged += new System.EventHandler(this.chkMargemRecebimento_CheckedChanged);
            // 
            // CadEpiForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(849, 684);
            this.Name = "CadEpiForm";
            this.Text = "EPI";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdUtilUnidCompPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargemRecebimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown5)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudControleValidadeMeses)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ensFornecedor.ResumeLayout(false);
            this.ensFornecedor.PerformLayout();
            this.grbUnidadeCompraFornecedor.ResumeLayout(false);
            this.grbUnidadeCompraFornecedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLotePadraoSob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoteMinSob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdUnidUtilComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUltimoPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIcmsIncluso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIpiNaoIncluso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFornecedores)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTTextBox iwtTextBox3;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTTextBox txtIdentificacao;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private IWTDotNetLib.IWTNumericUpDown iwtNumericUpDown3;
        private IWTDotNetLib.IWTNumericUpDown iwtNumericUpDown2;
        private IWTDotNetLib.IWTNumericUpDown iwtNumericUpDown1;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTLabel iwtLabel8;
        private IWTDotNetLib.IWTLabel iwtLabel9;
        private IWTDotNetLib.IWTLabel lblVermelhoSugerido;
        private IWTDotNetLib.IWTLabel lblAmareloSugerido;
        private IWTDotNetLib.IWTLabel lblVerdeSugerido;
        private System.Windows.Forms.GroupBox groupBox5;
        private IWTDotNetLib.IWTLabel iwtLabel11;
        private IWTDotNetLib.IWTLabel iwtLabel10;
        private IWTDotNetLib.IWTNumericUpDown iwtNumericUpDown5;
        private IWTDotNetLib.IWTLabel iwtLabel12;
        private IWTDotNetLib.IWTCheckBox iwtCheckBox1;
        private IWTDotNetLib.IWTTextBox iwtTextBox4;
        private IWTDotNetLib.IWTLabel iwtLabel14;
        private IWTDotNetLib.IWTLabel iwtLabel13;
        private IWTDotNetLib.IWTLabel iwtLabel15;
        private IWTDotNetLib.IWTNumericUpDown nudMargemRecebimento;
        private IWTDotNetLib.IWTCheckBox cbxControleValidade;
        private IWTDotNetLib.IWTNumericUpDown nudControleValidadeMeses;
        private IWTDotNetLib.IWTLabel iwtLabel16;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private IWTDotNetLib.IWTLabel iwtLabel20;
        private IWTDotNetLib.IWTNumericUpDown nudUltimoPreco;
        private IWTDotNetLib.IWTLabel iwtLabel23;
        private IWTDotNetLib.IWTNumericUpDown nudIcmsIncluso;
        private IWTDotNetLib.IWTLabel iwtLabel22;
        private IWTDotNetLib.IWTNumericUpDown nudIpiNaoIncluso;
        private IWTDotNetLib.IWTLabel iwtLabel21;
        private IWTDotNetLib.IWTLabel lblUnidCompraEpi;
        private System.Windows.Forms.GroupBox grbUnidadeCompraFornecedor;
        private IWTDotNetLib.IWTButton btnRemove;
        private IWTDotNetLib.IWTButton btnAdd;
        private IWTDotNetLib.IWTDataGridView dgvFornecedores;
        private IWTDotNetLib.IWTLabel iwtLabel25;
        private IWTDotNetLib.IWTNumericUpDown nudQtdUnidUtilComp;
        private IWTDotNetLib.IWTLabel iwtLabel26;
        private IWTDotNetLib.IWTLabel iwtLabel28;
        private IWTDotNetLib.IWTLabel iwtLabel27;
        private IWTDotNetLib.IWTNumericUpDown nudLoteMinSob;
        private IWTDotNetLib.IWTNumericUpDown iwtNumericUpDown4;
        private IWTDotNetLib.IWTNumericUpDown nudQtdUtilUnidCompPrincipal;
        private IWTDotNetLib.IWTCheckBox cbxUnidadeCompraFornecedor;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbUnidCompraSobre;
        private IWTDotNetLib.IWTLabel lblRevisarVermelho;
        private IWTDotNetLib.IWTLabel lblRevisarAmarelo;
        private IWTDotNetLib.IWTLabel lblRevisarVerde;
        private IWTDotNetLib.IWTLabel lblLeadtimeCompras;
        private IWTDotNetLib.IWTLabel lblLeadtimePCP;
        private IWTDotNetLib.IWTLabel lblUnidades;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTLabel iwtLabel24;
        private System.Windows.Forms.GroupBox groupBox6;
        private IWTDotNetLib.IWTLabel label24;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel label25;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel label26;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTTextBox iwtTextBox5;
        private IWTDotNetLib.IWTLabel iwtLabel17;
        private IWTDotNetLib.IWTLabel label1;
        private IWTEntitySelection ensFornecedor;
        private IWTCheckBox chk;
        private IWTTextBox txt;
        private IWTCheckBox iwtCheckBox2;
        private IWTTextBox iwtTextBox7;
        private IWTEntitySelection ensCA;
        private Button btnSalvarComo;
        private IWTEntitySelection ensUnidadeMedidaCompra;
        private IWTLabel lblSugestaoLeadTime;
        private IWTEntitySelection ensUnidadeUso;
        private IWTNumericUpDown iwtNumericUpDown7;
        private IWTLabel iwtLabel18;
        private IWTLabel iwtLabel19;
        private IWTNumericUpDown nudLotePadraoSob;
        private DataGridViewTextBoxColumn Fornecedor;
        private DataGridViewTextBoxColumn UltimoPreco;
        private DataGridViewTextBoxColumn Ipi;
        private DataGridViewTextBoxColumn Icms;
        private DataGridViewTextBoxColumn UltimaCompra;
        private DataGridViewTextBoxColumn UnidadeMedidaCompra;
        private DataGridViewTextBoxColumn UnidadesPorUnidadeCompra;
        private DataGridViewTextBoxColumn LoteMinimoColumn;
        private DataGridViewTextBoxColumn LotePadrao;
        private DataGridViewCheckBoxColumn PreferencialColumn;
        private IWTCheckBox chkFornecedorPreferencial;
        private IWTCheckBox chkMargemRecebimento;
    }
}