using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadPedidoItemListForm 
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.grbPlanejamento = new System.Windows.Forms.GroupBox();
            this.rdbFeedbackSecundarioTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.radioButton8 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.radioButton9 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbFeedbackTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.radioButton5 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.radioButton6 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbConfiguradoTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.radioButton2 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.radioButton1 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.chkDataEntrega = new IWTDotNetLib.IWTCheckBox(this.components);
            this.grbDataEntrega = new System.Windows.Forms.GroupBox();
            this.iwtDateTimePicker3 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtDateTimePicker4 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.chkDataEntrada = new IWTDotNetLib.IWTCheckBox(this.components);
            this.grbDataEntrada = new System.Windows.Forms.GroupBox();
            this.iwtDateTimePicker2 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtDateTimePicker1 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbUrgenteTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton4 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton3 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton2 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton1 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbPendentes = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbSuspenso = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbReaberto = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbEncerrado = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbCancelado = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPosicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusTraduzido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassificacaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjetoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemanaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataConfiguracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaNf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataUltimaNf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEncerramento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Feedback = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeedbackSecundarioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuspensaoObs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoDescricaoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnpjCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArmazenagemCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ncm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperacaoCompletaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PermiteEntregaParcial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VolumeUnico = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Configurado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Exportacao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrecoTotalOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JustificativaCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Urgente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrgenteSolicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrgenteDataPrometida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrgenteInformacoesComplementares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntregaOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InformacaoEspecial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RastreamentoMaterial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ContaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CentroCustoLucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponsavelFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdemVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercComissaoRepresentante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObsPadraoEspelho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataUltimaAlteracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioResponsavelSuspensao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercComissaoVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SituacaoGadTraduzidaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SituacaoGadMensagemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramacaoDataCriacaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramacaoNomeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramacaoSituacaoGadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramacaoSituacaoGadMensagemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvioTerceirosColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OperacaoEnvioTerceirosColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClienteEnvioTerceirosColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AplicacaoClienteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescontoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorFinalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoClassificacaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoBloqueioPrecoVencidoColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSuspender = new IWTDotNetLib.IWTButton(this.components);
            this.btnFaturar = new IWTDotNetLib.IWTButton(this.components);
            this.btnImprimirPedido = new IWTDotNetLib.IWTButton(this.components);
            this.btnRelatorioMateriais = new IWTDotNetLib.IWTButton(this.components);
            this.btnEncerrar = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.btnEditar = new IWTDotNetLib.IWTEditarButton(this.components);
            this.btnNovo = new IWTDotNetLib.IWTNovoButton(this.components);
            this.btnFeedback = new IWTDotNetLib.IWTButton(this.components);
            this.btnAlterarUrgencia = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelarGad = new System.Windows.Forms.Button();
            this.btnAtualizarGad = new System.Windows.Forms.Button();
            this.btnEditarSimplificado = new IWTDotNetLib.IWTButton(this.components);
            this.btnFeedbackSecundario = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            this.grbPlanejamento.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grbDataEntrega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker4)).BeginInit();
            this.grbDataEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 231);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnFeedbackSecundario);
            this.splitContainer2.Panel2.Controls.Add(this.btnEditarSimplificado);
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelarGad);
            this.splitContainer2.Panel2.Controls.Add(this.btnAlterarUrgencia);
            this.splitContainer2.Panel2.Controls.Add(this.btnAtualizarGad);
            this.splitContainer2.Panel2.Controls.Add(this.btnFeedback);
            this.splitContainer2.Panel2.Controls.Add(this.btnSuspender);
            this.splitContainer2.Panel2.Controls.Add(this.btnFaturar);
            this.splitContainer2.Panel2.Controls.Add(this.btnImprimirPedido);
            this.splitContainer2.Panel2.Controls.Add(this.btnRelatorioMateriais);
            this.splitContainer2.Panel2.Controls.Add(this.btnEncerrar);
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btnEditar);
            this.splitContainer2.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer2.Size = new System.Drawing.Size(1224, 163);
            this.splitContainer2.SplitterDistance = 837;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(1224, 197);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.grbPlanejamento);
            this.iwtSearchPanel1.Controls.Add(this.groupBox4);
            this.iwtSearchPanel1.Controls.Add(this.groupBox3);
            this.iwtSearchPanel1.Controls.Add(this.chkDataEntrega);
            this.iwtSearchPanel1.Controls.Add(this.grbDataEntrega);
            this.iwtSearchPanel1.Controls.Add(this.chkDataEntrada);
            this.iwtSearchPanel1.Controls.Add(this.grbDataEntrada);
            this.iwtSearchPanel1.Controls.Add(this.groupBox2);
            this.iwtSearchPanel1.Controls.Add(this.groupBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(837, 163);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // grbPlanejamento
            // 
            this.grbPlanejamento.Controls.Add(this.rdbFeedbackSecundarioTodos);
            this.grbPlanejamento.Controls.Add(this.radioButton8);
            this.grbPlanejamento.Controls.Add(this.radioButton9);
            this.grbPlanejamento.Location = new System.Drawing.Point(641, 82);
            this.grbPlanejamento.Name = "grbPlanejamento";
            this.grbPlanejamento.Size = new System.Drawing.Size(168, 75);
            this.grbPlanejamento.TabIndex = 15;
            this.grbPlanejamento.TabStop = false;
            this.grbPlanejamento.Text = "Planejamento";
            // 
            // rdbFeedbackSecundarioTodos
            // 
            this.rdbFeedbackSecundarioTodos.AutoSize = true;
            this.rdbFeedbackSecundarioTodos.BindingField = null;
            this.rdbFeedbackSecundarioTodos.Checked = true;
            this.rdbFeedbackSecundarioTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbFeedbackSecundarioTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbFeedbackSecundarioTodos.Location = new System.Drawing.Point(6, 55);
            this.rdbFeedbackSecundarioTodos.Name = "rdbFeedbackSecundarioTodos";
            this.rdbFeedbackSecundarioTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbFeedbackSecundarioTodos.TabIndex = 2;
            this.rdbFeedbackSecundarioTodos.TabStop = true;
            this.rdbFeedbackSecundarioTodos.Text = "Todos";
            this.rdbFeedbackSecundarioTodos.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.BindingField = "SomenteSemFeedbackSecundario";
            this.radioButton8.LiberadoQuandoCadastroUtilizado = false;
            this.radioButton8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.radioButton8.Location = new System.Drawing.Point(6, 37);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(156, 17);
            this.radioButton8.TabIndex = 1;
            this.radioButton8.Text = "Somente sem Planejamento";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.BindingField = "SomenteComFeedbackSecundario";
            this.radioButton9.LiberadoQuandoCadastroUtilizado = false;
            this.radioButton9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.radioButton9.Location = new System.Drawing.Point(6, 19);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(157, 17);
            this.radioButton9.TabIndex = 0;
            this.radioButton9.Text = "Somente com Planejamento";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbFeedbackTodos);
            this.groupBox4.Controls.Add(this.radioButton5);
            this.groupBox4.Controls.Add(this.radioButton6);
            this.groupBox4.Location = new System.Drawing.Point(473, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(162, 75);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Feedback";
            // 
            // rdbFeedbackTodos
            // 
            this.rdbFeedbackTodos.AutoSize = true;
            this.rdbFeedbackTodos.BindingField = null;
            this.rdbFeedbackTodos.Checked = true;
            this.rdbFeedbackTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbFeedbackTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbFeedbackTodos.Location = new System.Drawing.Point(6, 55);
            this.rdbFeedbackTodos.Name = "rdbFeedbackTodos";
            this.rdbFeedbackTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbFeedbackTodos.TabIndex = 2;
            this.rdbFeedbackTodos.TabStop = true;
            this.rdbFeedbackTodos.Text = "Todos";
            this.rdbFeedbackTodos.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.BindingField = "SomenteSemFeedback";
            this.radioButton5.LiberadoQuandoCadastroUtilizado = false;
            this.radioButton5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.radioButton5.Location = new System.Drawing.Point(6, 37);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(140, 17);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Text = "Somente sem Feedback";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.BindingField = "SomenteComFeedback";
            this.radioButton6.LiberadoQuandoCadastroUtilizado = false;
            this.radioButton6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.radioButton6.Location = new System.Drawing.Point(6, 19);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(141, 17);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.Text = "Somente com Feedback";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbConfiguradoTodos);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(473, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 75);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurado";
            // 
            // rdbConfiguradoTodos
            // 
            this.rdbConfiguradoTodos.AutoSize = true;
            this.rdbConfiguradoTodos.BindingField = null;
            this.rdbConfiguradoTodos.Checked = true;
            this.rdbConfiguradoTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbConfiguradoTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbConfiguradoTodos.Location = new System.Drawing.Point(6, 55);
            this.rdbConfiguradoTodos.Name = "rdbConfiguradoTodos";
            this.rdbConfiguradoTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbConfiguradoTodos.TabIndex = 2;
            this.rdbConfiguradoTodos.TabStop = true;
            this.rdbConfiguradoTodos.Text = "Todos";
            this.rdbConfiguradoTodos.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BindingField = "SomenteNaoConfigurados";
            this.radioButton2.LiberadoQuandoCadastroUtilizado = false;
            this.radioButton2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.radioButton2.Location = new System.Drawing.Point(6, 37);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(155, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Somente Não Configurados";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BindingField = "SomenteConfigurados";
            this.radioButton1.LiberadoQuandoCadastroUtilizado = false;
            this.radioButton1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(132, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Somente Configurados";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // chkDataEntrega
            // 
            this.chkDataEntrega.AutoSize = true;
            this.chkDataEntrega.BindingField = null;
            this.chkDataEntrega.LiberadoQuandoCadastroUtilizado = false;
            this.chkDataEntrega.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkDataEntrega.Location = new System.Drawing.Point(437, 112);
            this.chkDataEntrega.Name = "chkDataEntrega";
            this.chkDataEntrega.Size = new System.Drawing.Size(15, 14);
            this.chkDataEntrega.TabIndex = 12;
            this.chkDataEntrega.UseVisualStyleBackColor = true;
            this.chkDataEntrega.CheckedChanged += new System.EventHandler(this.chkDataEntrega_CheckedChanged);
            // 
            // grbDataEntrega
            // 
            this.grbDataEntrega.Controls.Add(this.iwtDateTimePicker3);
            this.grbDataEntrega.Controls.Add(this.iwtDateTimePicker4);
            this.grbDataEntrega.Enabled = false;
            this.grbDataEntrega.Location = new System.Drawing.Point(305, 82);
            this.grbDataEntrega.Name = "grbDataEntrega";
            this.grbDataEntrega.Size = new System.Drawing.Size(126, 72);
            this.grbDataEntrega.TabIndex = 11;
            this.grbDataEntrega.TabStop = false;
            this.grbDataEntrega.Text = "Data de Entrega";
            // 
            // iwtDateTimePicker3
            // 
            this.iwtDateTimePicker3.BindingField = "Entrega_Fim";
            this.iwtDateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker3.Location = new System.Drawing.Point(6, 45);
            this.iwtDateTimePicker3.Name = "iwtDateTimePicker3";
            this.iwtDateTimePicker3.Size = new System.Drawing.Size(114, 20);
            this.iwtDateTimePicker3.TabIndex = 1;
            this.iwtDateTimePicker3.Value = new System.DateTime(2025, 8, 6, 12, 30, 40, 787);
            // 
            // iwtDateTimePicker4
            // 
            this.iwtDateTimePicker4.BindingField = "Entrega_Inicio";
            this.iwtDateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker4.Location = new System.Drawing.Point(6, 19);
            this.iwtDateTimePicker4.Name = "iwtDateTimePicker4";
            this.iwtDateTimePicker4.Size = new System.Drawing.Size(114, 20);
            this.iwtDateTimePicker4.TabIndex = 0;
            this.iwtDateTimePicker4.Value = new System.DateTime(2025, 8, 6, 12, 30, 40, 788);
            // 
            // chkDataEntrada
            // 
            this.chkDataEntrada.AutoSize = true;
            this.chkDataEntrada.BindingField = null;
            this.chkDataEntrada.LiberadoQuandoCadastroUtilizado = false;
            this.chkDataEntrada.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkDataEntrada.Location = new System.Drawing.Point(437, 34);
            this.chkDataEntrada.Name = "chkDataEntrada";
            this.chkDataEntrada.Size = new System.Drawing.Size(15, 14);
            this.chkDataEntrada.TabIndex = 10;
            this.chkDataEntrada.UseVisualStyleBackColor = true;
            this.chkDataEntrada.CheckedChanged += new System.EventHandler(this.chkDataEntrada_CheckedChanged);
            // 
            // grbDataEntrada
            // 
            this.grbDataEntrada.Controls.Add(this.iwtDateTimePicker2);
            this.grbDataEntrada.Controls.Add(this.iwtDateTimePicker1);
            this.grbDataEntrada.Enabled = false;
            this.grbDataEntrada.Location = new System.Drawing.Point(305, 4);
            this.grbDataEntrada.Name = "grbDataEntrada";
            this.grbDataEntrada.Size = new System.Drawing.Size(126, 72);
            this.grbDataEntrada.TabIndex = 9;
            this.grbDataEntrada.TabStop = false;
            this.grbDataEntrada.Text = "Data de Entrada";
            // 
            // iwtDateTimePicker2
            // 
            this.iwtDateTimePicker2.BindingField = "Entrada_Fim";
            this.iwtDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker2.Location = new System.Drawing.Point(6, 45);
            this.iwtDateTimePicker2.Name = "iwtDateTimePicker2";
            this.iwtDateTimePicker2.Size = new System.Drawing.Size(114, 20);
            this.iwtDateTimePicker2.TabIndex = 1;
            this.iwtDateTimePicker2.Value = new System.DateTime(2025, 8, 6, 12, 30, 40, 794);
            // 
            // iwtDateTimePicker1
            // 
            this.iwtDateTimePicker1.BindingField = "Entrada_Inicio";
            this.iwtDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker1.Location = new System.Drawing.Point(6, 19);
            this.iwtDateTimePicker1.Name = "iwtDateTimePicker1";
            this.iwtDateTimePicker1.Size = new System.Drawing.Size(114, 20);
            this.iwtDateTimePicker1.TabIndex = 0;
            this.iwtDateTimePicker1.Value = new System.DateTime(2025, 8, 6, 12, 30, 40, 795);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbUrgenteTodos);
            this.groupBox2.Controls.Add(this.iwtRadioButton4);
            this.groupBox2.Controls.Add(this.iwtRadioButton3);
            this.groupBox2.Controls.Add(this.iwtRadioButton2);
            this.groupBox2.Controls.Add(this.iwtRadioButton1);
            this.groupBox2.Location = new System.Drawing.Point(193, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 117);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criticidade";
            // 
            // rdbUrgenteTodos
            // 
            this.rdbUrgenteTodos.AutoSize = true;
            this.rdbUrgenteTodos.BindingField = "";
            this.rdbUrgenteTodos.Checked = true;
            this.rdbUrgenteTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteTodos.Location = new System.Drawing.Point(6, 84);
            this.rdbUrgenteTodos.Name = "rdbUrgenteTodos";
            this.rdbUrgenteTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbUrgenteTodos.TabIndex = 4;
            this.rdbUrgenteTodos.TabStop = true;
            this.rdbUrgenteTodos.Text = "Todos";
            this.rdbUrgenteTodos.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton4
            // 
            this.iwtRadioButton4.AutoSize = true;
            this.iwtRadioButton4.BindingField = "Urgente_Critico";
            this.iwtRadioButton4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton4.Location = new System.Drawing.Point(6, 67);
            this.iwtRadioButton4.Name = "iwtRadioButton4";
            this.iwtRadioButton4.Size = new System.Drawing.Size(56, 17);
            this.iwtRadioButton4.TabIndex = 3;
            this.iwtRadioButton4.Text = "Crítico";
            this.iwtRadioButton4.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton3
            // 
            this.iwtRadioButton3.AutoSize = true;
            this.iwtRadioButton3.BindingField = "Urgente_Urgente";
            this.iwtRadioButton3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton3.Location = new System.Drawing.Point(6, 50);
            this.iwtRadioButton3.Name = "iwtRadioButton3";
            this.iwtRadioButton3.Size = new System.Drawing.Size(63, 17);
            this.iwtRadioButton3.TabIndex = 2;
            this.iwtRadioButton3.Text = "Urgente";
            this.iwtRadioButton3.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton2
            // 
            this.iwtRadioButton2.AutoSize = true;
            this.iwtRadioButton2.BindingField = "Urgente_Antecipacao";
            this.iwtRadioButton2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton2.Location = new System.Drawing.Point(6, 33);
            this.iwtRadioButton2.Name = "iwtRadioButton2";
            this.iwtRadioButton2.Size = new System.Drawing.Size(85, 17);
            this.iwtRadioButton2.TabIndex = 1;
            this.iwtRadioButton2.Text = "Antecipação";
            this.iwtRadioButton2.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton1
            // 
            this.iwtRadioButton1.AutoSize = true;
            this.iwtRadioButton1.BindingField = "Urgente_Normal";
            this.iwtRadioButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton1.Location = new System.Drawing.Point(6, 16);
            this.iwtRadioButton1.Name = "iwtRadioButton1";
            this.iwtRadioButton1.Size = new System.Drawing.Size(58, 17);
            this.iwtRadioButton1.TabIndex = 0;
            this.iwtRadioButton1.Text = "Normal";
            this.iwtRadioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbPendentes);
            this.groupBox1.Controls.Add(this.rdbTodos);
            this.groupBox1.Controls.Add(this.rdbSuspenso);
            this.groupBox1.Controls.Add(this.rdbReaberto);
            this.groupBox1.Controls.Add(this.rdbEncerrado);
            this.groupBox1.Controls.Add(this.rdbCancelado);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 124);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Satus";
            // 
            // rdbPendentes
            // 
            this.rdbPendentes.AutoSize = true;
            this.rdbPendentes.BindingField = "Pendente_List";
            this.rdbPendentes.Checked = true;
            this.rdbPendentes.LiberadoQuandoCadastroUtilizado = false;
            this.rdbPendentes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbPendentes.Location = new System.Drawing.Point(15, 19);
            this.rdbPendentes.Name = "rdbPendentes";
            this.rdbPendentes.Size = new System.Drawing.Size(71, 17);
            this.rdbPendentes.TabIndex = 1;
            this.rdbPendentes.TabStop = true;
            this.rdbPendentes.Text = "Pendente";
            this.rdbPendentes.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.BindingField = "Todos_List";
            this.rdbTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodos.Location = new System.Drawing.Point(15, 104);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 6;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            // 
            // rdbSuspenso
            // 
            this.rdbSuspenso.AutoSize = true;
            this.rdbSuspenso.BindingField = "Suspenso_List";
            this.rdbSuspenso.LiberadoQuandoCadastroUtilizado = false;
            this.rdbSuspenso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbSuspenso.Location = new System.Drawing.Point(15, 36);
            this.rdbSuspenso.Name = "rdbSuspenso";
            this.rdbSuspenso.Size = new System.Drawing.Size(72, 17);
            this.rdbSuspenso.TabIndex = 3;
            this.rdbSuspenso.Text = "Suspenso";
            this.rdbSuspenso.UseVisualStyleBackColor = true;
            // 
            // rdbReaberto
            // 
            this.rdbReaberto.AutoSize = true;
            this.rdbReaberto.BindingField = "Reaberto_List";
            this.rdbReaberto.LiberadoQuandoCadastroUtilizado = false;
            this.rdbReaberto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbReaberto.Location = new System.Drawing.Point(15, 87);
            this.rdbReaberto.Name = "rdbReaberto";
            this.rdbReaberto.Size = new System.Drawing.Size(69, 17);
            this.rdbReaberto.TabIndex = 4;
            this.rdbReaberto.Text = "Reaberto";
            this.rdbReaberto.UseVisualStyleBackColor = true;
            // 
            // rdbEncerrado
            // 
            this.rdbEncerrado.AutoSize = true;
            this.rdbEncerrado.BindingField = "Encerrado_List";
            this.rdbEncerrado.LiberadoQuandoCadastroUtilizado = false;
            this.rdbEncerrado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEncerrado.Location = new System.Drawing.Point(15, 53);
            this.rdbEncerrado.Name = "rdbEncerrado";
            this.rdbEncerrado.Size = new System.Drawing.Size(74, 17);
            this.rdbEncerrado.TabIndex = 5;
            this.rdbEncerrado.Text = "Encerrado";
            this.rdbEncerrado.UseVisualStyleBackColor = true;
            // 
            // rdbCancelado
            // 
            this.rdbCancelado.AutoSize = true;
            this.rdbCancelado.BindingField = "Cancelado_List";
            this.rdbCancelado.LiberadoQuandoCadastroUtilizado = false;
            this.rdbCancelado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbCancelado.Location = new System.Drawing.Point(15, 70);
            this.rdbCancelado.Name = "rdbCancelado";
            this.rdbCancelado.Size = new System.Drawing.Size(76, 17);
            this.rdbCancelado.TabIndex = 2;
            this.rdbCancelado.Text = "Cancelado";
            this.rdbCancelado.UseVisualStyleBackColor = true;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(49, 3);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(231, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(9, 6);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
            // 
            // iwtDataGridView1
            // 
            this.iwtDataGridView1.AllowUserToAddRows = false;
            this.iwtDataGridView1.AllowUserToDeleteRows = false;
            this.iwtDataGridView1.AllowUserToOrderColumns = true;
            this.iwtDataGridView1.AllowUserToResizeRows = false;
            this.iwtDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.iwtDataGridView1.CacheDados = null;
            this.iwtDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iwtDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Cliente,
            this.NumeroPosicao,
            this.StatusTraduzido,
            this.ProdutoCodigoCliente,
            this.ClassificacaoProduto,
            this.ProjetoCliente,
            this.Quantidade,
            this.Saldo,
            this.DataEntrega,
            this.SemanaEntrega,
            this.DataEntrada,
            this.DataConfiguracao,
            this.UltimaNf,
            this.DataUltimaNf,
            this.DataEncerramento,
            this.Feedback,
            this.FeedbackSecundarioColumn,
            this.SuspensaoObs,
            this.Numero,
            this.Posicao,
            this.SubLinha,
            this.Produto,
            this.ProdutoDescricaoCliente,
            this.PrecoUnitario,
            this.PrecoTotal,
            this.CnpjCliente,
            this.ArmazenagemCliente,
            this.Frete,
            this.Ncm,
            this.Operacao,
            this.OperacaoCompletaColumn,
            this.PermiteEntregaParcial,
            this.VolumeUnico,
            this.Configurado,
            this.Exportacao,
            this.PrecoTotalOriginal,
            this.AcsUsuarioCancelamento,
            this.DataCancelamento,
            this.JustificativaCancelamento,
            this.Urgente,
            this.UrgenteSolicitante,
            this.UrgenteDataPrometida,
            this.UrgenteInformacoesComplementares,
            this.DataEntregaOriginal,
            this.InformacaoEspecial,
            this.RastreamentoMaterial,
            this.ContaBancaria,
            this.CentroCustoLucro,
            this.FormaPagamento,
            this.FormaFrete,
            this.ResponsavelFrete,
            this.OrdemVenda,
            this.Representante,
            this.PercComissaoRepresentante,
            this.ObsPadraoEspelho,
            this.DataUltimaAlteracao,
            this.AcsUsuarioResponsavelSuspensao,
            this.Vendedor,
            this.PercComissaoVendedor,
            this.ProdutoDescricao,
            this.SituacaoGadTraduzidaColumn,
            this.SituacaoGadMensagemColumn,
            this.ProgramacaoDataCriacaoColumn,
            this.ProgramacaoNomeColumn,
            this.ProgramacaoSituacaoGadColumn,
            this.ProgramacaoSituacaoGadMensagemColumn,
            this.EnvioTerceirosColumn,
            this.OperacaoEnvioTerceirosColumn,
            this.ClienteEnvioTerceirosColumn,
            this.AplicacaoClienteColumn,
            this.DescontoColumn,
            this.ValorFinalColumn,
            this.PedidoClassificacaoColumn,
            this.ProdutoBloqueioPrecoVencidoColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(1224, 159);
            this.iwtDataGridView1.TabIndex = 0;
            this.iwtDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.iwtDataGridView1_CellFormatting);
            this.iwtDataGridView1.SelectionChanged += new System.EventHandler(this.iwtDataGridView1_SelectionChanged);
            this.iwtDataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
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
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // NumeroPosicao
            // 
            this.NumeroPosicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumeroPosicao.DataPropertyName = "NumeroPosicao";
            this.NumeroPosicao.HeaderText = "OC/Pos";
            this.NumeroPosicao.Name = "NumeroPosicao";
            this.NumeroPosicao.ReadOnly = true;
            // 
            // StatusTraduzido
            // 
            this.StatusTraduzido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StatusTraduzido.DataPropertyName = "StatusTraduzido";
            this.StatusTraduzido.HeaderText = "Status";
            this.StatusTraduzido.Name = "StatusTraduzido";
            this.StatusTraduzido.ReadOnly = true;
            this.StatusTraduzido.Width = 60;
            // 
            // ProdutoCodigoCliente
            // 
            this.ProdutoCodigoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoCodigoCliente.DataPropertyName = "ProdutoCodigoCliente";
            this.ProdutoCodigoCliente.HeaderText = "Código";
            this.ProdutoCodigoCliente.Name = "ProdutoCodigoCliente";
            this.ProdutoCodigoCliente.ReadOnly = true;
            // 
            // ClassificacaoProduto
            // 
            this.ClassificacaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClassificacaoProduto.DataPropertyName = "ClassificacaoProduto";
            this.ClassificacaoProduto.HeaderText = "Classificação";
            this.ClassificacaoProduto.Name = "ClassificacaoProduto";
            this.ClassificacaoProduto.ReadOnly = true;
            this.ClassificacaoProduto.Width = 90;
            // 
            // ProjetoCliente
            // 
            this.ProjetoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProjetoCliente.DataPropertyName = "ProjetoCliente";
            this.ProjetoCliente.HeaderText = "Projeto";
            this.ProjetoCliente.Name = "ProjetoCliente";
            this.ProjetoCliente.ReadOnly = true;
            this.ProjetoCliente.Width = 65;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            this.Quantidade.Width = 70;
            // 
            // Saldo
            // 
            this.Saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Saldo.DataPropertyName = "Saldo";
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 50;
            // 
            // DataEntrega
            // 
            this.DataEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEntrega.DataPropertyName = "DataEntrega";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.DataEntrega.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataEntrega.HeaderText = "Data Entrega";
            this.DataEntrega.Name = "DataEntrega";
            this.DataEntrega.ReadOnly = true;
            this.DataEntrega.Width = 80;
            // 
            // SemanaEntrega
            // 
            this.SemanaEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SemanaEntrega.DataPropertyName = "SemanaEntrega";
            this.SemanaEntrega.HeaderText = "Semana Entrega";
            this.SemanaEntrega.Name = "SemanaEntrega";
            this.SemanaEntrega.ReadOnly = true;
            this.SemanaEntrega.Width = 80;
            // 
            // DataEntrada
            // 
            this.DataEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEntrada.DataPropertyName = "DataEntrada";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.DataEntrada.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataEntrada.HeaderText = "Cadastro";
            this.DataEntrada.Name = "DataEntrada";
            this.DataEntrada.ReadOnly = true;
            this.DataEntrada.Width = 95;
            // 
            // DataConfiguracao
            // 
            this.DataConfiguracao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataConfiguracao.DataPropertyName = "DataConfiguracao";
            this.DataConfiguracao.HeaderText = "Configuração";
            this.DataConfiguracao.Name = "DataConfiguracao";
            this.DataConfiguracao.ReadOnly = true;
            this.DataConfiguracao.Width = 95;
            // 
            // UltimaNf
            // 
            this.UltimaNf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaNf.DataPropertyName = "UltimaNf";
            this.UltimaNf.HeaderText = "Última NF";
            this.UltimaNf.Name = "UltimaNf";
            this.UltimaNf.ReadOnly = true;
            this.UltimaNf.Width = 60;
            // 
            // DataUltimaNf
            // 
            this.DataUltimaNf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataUltimaNf.DataPropertyName = "DataUltimaNf";
            this.DataUltimaNf.HeaderText = "Data última NF";
            this.DataUltimaNf.Name = "DataUltimaNf";
            this.DataUltimaNf.ReadOnly = true;
            this.DataUltimaNf.Width = 80;
            // 
            // DataEncerramento
            // 
            this.DataEncerramento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEncerramento.DataPropertyName = "DataEncerramento";
            this.DataEncerramento.HeaderText = "Encerramento";
            this.DataEncerramento.Name = "DataEncerramento";
            this.DataEncerramento.ReadOnly = true;
            // 
            // Feedback
            // 
            this.Feedback.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Feedback.DataPropertyName = "FeedbackAtual";
            this.Feedback.HeaderText = "Feedback";
            this.Feedback.Name = "Feedback";
            this.Feedback.ReadOnly = true;
            this.Feedback.Width = 350;
            // 
            // FeedbackSecundarioColumn
            // 
            this.FeedbackSecundarioColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FeedbackSecundarioColumn.DataPropertyName = "FeedbackSecundarioAtual";
            this.FeedbackSecundarioColumn.HeaderText = "Planejamento";
            this.FeedbackSecundarioColumn.Name = "FeedbackSecundarioColumn";
            this.FeedbackSecundarioColumn.ReadOnly = true;
            this.FeedbackSecundarioColumn.Width = 350;
            // 
            // SuspensaoObs
            // 
            this.SuspensaoObs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SuspensaoObs.DataPropertyName = "SuspensaoObs";
            this.SuspensaoObs.HeaderText = "Observação de Suspensão / Retirada de Suspensão";
            this.SuspensaoObs.Name = "SuspensaoObs";
            this.SuspensaoObs.ReadOnly = true;
            this.SuspensaoObs.Width = 350;
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Visible = false;
            this.Numero.Width = 150;
            // 
            // Posicao
            // 
            this.Posicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Posicao.DataPropertyName = "Posicao";
            this.Posicao.HeaderText = "Posição";
            this.Posicao.Name = "Posicao";
            this.Posicao.ReadOnly = true;
            this.Posicao.Visible = false;
            this.Posicao.Width = 70;
            // 
            // SubLinha
            // 
            this.SubLinha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SubLinha.DataPropertyName = "SubLinha";
            this.SubLinha.HeaderText = "SubLinha";
            this.SubLinha.Name = "SubLinha";
            this.SubLinha.ReadOnly = true;
            this.SubLinha.Visible = false;
            this.SubLinha.Width = 70;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.Visible = false;
            this.Produto.Width = 150;
            // 
            // ProdutoDescricaoCliente
            // 
            this.ProdutoDescricaoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoDescricaoCliente.DataPropertyName = "ProdutoDescricaoCliente";
            this.ProdutoDescricaoCliente.HeaderText = "Produto Descrição Cliente";
            this.ProdutoDescricaoCliente.Name = "ProdutoDescricaoCliente";
            this.ProdutoDescricaoCliente.ReadOnly = true;
            this.ProdutoDescricaoCliente.Visible = false;
            this.ProdutoDescricaoCliente.Width = 150;
            // 
            // PrecoUnitario
            // 
            this.PrecoUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PrecoUnitario.DataPropertyName = "PrecoUnitario";
            this.PrecoUnitario.HeaderText = "Preço Unitário";
            this.PrecoUnitario.Name = "PrecoUnitario";
            this.PrecoUnitario.ReadOnly = true;
            this.PrecoUnitario.Visible = false;
            // 
            // PrecoTotal
            // 
            this.PrecoTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PrecoTotal.DataPropertyName = "PrecoTotal";
            this.PrecoTotal.HeaderText = "Preço Total";
            this.PrecoTotal.Name = "PrecoTotal";
            this.PrecoTotal.ReadOnly = true;
            this.PrecoTotal.Visible = false;
            // 
            // CnpjCliente
            // 
            this.CnpjCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CnpjCliente.DataPropertyName = "CnpjCliente";
            this.CnpjCliente.HeaderText = "Cnpj Cliente";
            this.CnpjCliente.Name = "CnpjCliente";
            this.CnpjCliente.ReadOnly = true;
            this.CnpjCliente.Visible = false;
            this.CnpjCliente.Width = 150;
            // 
            // ArmazenagemCliente
            // 
            this.ArmazenagemCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ArmazenagemCliente.DataPropertyName = "ArmazenagemCliente";
            this.ArmazenagemCliente.HeaderText = "Armazenagem Cliente";
            this.ArmazenagemCliente.Name = "ArmazenagemCliente";
            this.ArmazenagemCliente.ReadOnly = true;
            this.ArmazenagemCliente.Visible = false;
            this.ArmazenagemCliente.Width = 150;
            // 
            // Frete
            // 
            this.Frete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Frete.DataPropertyName = "Frete";
            this.Frete.HeaderText = "Frete";
            this.Frete.Name = "Frete";
            this.Frete.ReadOnly = true;
            this.Frete.Visible = false;
            // 
            // Ncm
            // 
            this.Ncm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Ncm.DataPropertyName = "Ncm";
            this.Ncm.HeaderText = "NCM";
            this.Ncm.Name = "Ncm";
            this.Ncm.ReadOnly = true;
            this.Ncm.Visible = false;
            this.Ncm.Width = 150;
            // 
            // Operacao
            // 
            this.Operacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operacao.DataPropertyName = "OperacaoList";
            this.Operacao.HeaderText = "Operação";
            this.Operacao.Name = "Operacao";
            this.Operacao.ReadOnly = true;
            this.Operacao.Visible = false;
            this.Operacao.Width = 150;
            // 
            // OperacaoCompletaColumn
            // 
            this.OperacaoCompletaColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OperacaoCompletaColumn.DataPropertyName = "OperacaoCompleta";
            this.OperacaoCompletaColumn.HeaderText = "Operação ";
            this.OperacaoCompletaColumn.Name = "OperacaoCompletaColumn";
            this.OperacaoCompletaColumn.ReadOnly = true;
            this.OperacaoCompletaColumn.Visible = false;
            this.OperacaoCompletaColumn.Width = 150;
            // 
            // PermiteEntregaParcial
            // 
            this.PermiteEntregaParcial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PermiteEntregaParcial.DataPropertyName = "PermiteEntregaParcial";
            this.PermiteEntregaParcial.HeaderText = "Permite Entrega Parcial";
            this.PermiteEntregaParcial.Name = "PermiteEntregaParcial";
            this.PermiteEntregaParcial.ReadOnly = true;
            this.PermiteEntregaParcial.Visible = false;
            this.PermiteEntregaParcial.Width = 70;
            // 
            // VolumeUnico
            // 
            this.VolumeUnico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VolumeUnico.DataPropertyName = "VolumeUnico";
            this.VolumeUnico.HeaderText = "Volume Único";
            this.VolumeUnico.Name = "VolumeUnico";
            this.VolumeUnico.ReadOnly = true;
            this.VolumeUnico.Visible = false;
            this.VolumeUnico.Width = 70;
            // 
            // Configurado
            // 
            this.Configurado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Configurado.DataPropertyName = "Configurado";
            this.Configurado.HeaderText = "Configurado";
            this.Configurado.Name = "Configurado";
            this.Configurado.ReadOnly = true;
            this.Configurado.Visible = false;
            this.Configurado.Width = 70;
            // 
            // Exportacao
            // 
            this.Exportacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Exportacao.DataPropertyName = "Exportacao";
            this.Exportacao.HeaderText = "Exportação";
            this.Exportacao.Name = "Exportacao";
            this.Exportacao.ReadOnly = true;
            this.Exportacao.Visible = false;
            this.Exportacao.Width = 70;
            // 
            // PrecoTotalOriginal
            // 
            this.PrecoTotalOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PrecoTotalOriginal.DataPropertyName = "PrecoTotalOriginal";
            this.PrecoTotalOriginal.HeaderText = "Preço Total Original";
            this.PrecoTotalOriginal.Name = "PrecoTotalOriginal";
            this.PrecoTotalOriginal.ReadOnly = true;
            this.PrecoTotalOriginal.Visible = false;
            // 
            // AcsUsuarioCancelamento
            // 
            this.AcsUsuarioCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioCancelamento.DataPropertyName = "AcsUsuarioCancelamento";
            this.AcsUsuarioCancelamento.HeaderText = "Usuário Cancelamento";
            this.AcsUsuarioCancelamento.Name = "AcsUsuarioCancelamento";
            this.AcsUsuarioCancelamento.ReadOnly = true;
            this.AcsUsuarioCancelamento.Visible = false;
            this.AcsUsuarioCancelamento.Width = 150;
            // 
            // DataCancelamento
            // 
            this.DataCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataCancelamento.DataPropertyName = "DataCancelamento";
            this.DataCancelamento.HeaderText = "Data Cancelamento";
            this.DataCancelamento.Name = "DataCancelamento";
            this.DataCancelamento.ReadOnly = true;
            this.DataCancelamento.Visible = false;
            // 
            // JustificativaCancelamento
            // 
            this.JustificativaCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.JustificativaCancelamento.DataPropertyName = "JustificativaCancelamento";
            this.JustificativaCancelamento.HeaderText = "Justificativa Cancelamento";
            this.JustificativaCancelamento.Name = "JustificativaCancelamento";
            this.JustificativaCancelamento.ReadOnly = true;
            this.JustificativaCancelamento.Visible = false;
            this.JustificativaCancelamento.Width = 150;
            // 
            // Urgente
            // 
            this.Urgente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Urgente.DataPropertyName = "Urgente";
            this.Urgente.HeaderText = "Urgente";
            this.Urgente.Name = "Urgente";
            this.Urgente.ReadOnly = true;
            this.Urgente.Visible = false;
            this.Urgente.Width = 150;
            // 
            // UrgenteSolicitante
            // 
            this.UrgenteSolicitante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UrgenteSolicitante.DataPropertyName = "UrgenteSolicitante";
            this.UrgenteSolicitante.HeaderText = "Urgente Solicitante";
            this.UrgenteSolicitante.Name = "UrgenteSolicitante";
            this.UrgenteSolicitante.ReadOnly = true;
            this.UrgenteSolicitante.Visible = false;
            this.UrgenteSolicitante.Width = 150;
            // 
            // UrgenteDataPrometida
            // 
            this.UrgenteDataPrometida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UrgenteDataPrometida.DataPropertyName = "UrgenteDataPrometida";
            this.UrgenteDataPrometida.HeaderText = "Urgente Data Prometida";
            this.UrgenteDataPrometida.Name = "UrgenteDataPrometida";
            this.UrgenteDataPrometida.ReadOnly = true;
            this.UrgenteDataPrometida.Visible = false;
            // 
            // UrgenteInformacoesComplementares
            // 
            this.UrgenteInformacoesComplementares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UrgenteInformacoesComplementares.DataPropertyName = "UrgenteInformacoesComplementares";
            this.UrgenteInformacoesComplementares.HeaderText = "Urgente Informações Complementares";
            this.UrgenteInformacoesComplementares.Name = "UrgenteInformacoesComplementares";
            this.UrgenteInformacoesComplementares.ReadOnly = true;
            this.UrgenteInformacoesComplementares.Visible = false;
            this.UrgenteInformacoesComplementares.Width = 150;
            // 
            // DataEntregaOriginal
            // 
            this.DataEntregaOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEntregaOriginal.DataPropertyName = "DataEntregaOriginal";
            this.DataEntregaOriginal.HeaderText = "Data Entrega Original";
            this.DataEntregaOriginal.Name = "DataEntregaOriginal";
            this.DataEntregaOriginal.ReadOnly = true;
            this.DataEntregaOriginal.Visible = false;
            // 
            // InformacaoEspecial
            // 
            this.InformacaoEspecial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InformacaoEspecial.DataPropertyName = "InformacaoEspecial";
            this.InformacaoEspecial.HeaderText = "Informação Especial";
            this.InformacaoEspecial.Name = "InformacaoEspecial";
            this.InformacaoEspecial.ReadOnly = true;
            this.InformacaoEspecial.Visible = false;
            this.InformacaoEspecial.Width = 150;
            // 
            // RastreamentoMaterial
            // 
            this.RastreamentoMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RastreamentoMaterial.DataPropertyName = "RastreamentoMaterial";
            this.RastreamentoMaterial.HeaderText = "Rastreamento Material";
            this.RastreamentoMaterial.Name = "RastreamentoMaterial";
            this.RastreamentoMaterial.ReadOnly = true;
            this.RastreamentoMaterial.Visible = false;
            this.RastreamentoMaterial.Width = 70;
            // 
            // ContaBancaria
            // 
            this.ContaBancaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ContaBancaria.DataPropertyName = "ContaBancaria";
            this.ContaBancaria.HeaderText = "Conta Bancária";
            this.ContaBancaria.Name = "ContaBancaria";
            this.ContaBancaria.ReadOnly = true;
            this.ContaBancaria.Visible = false;
            this.ContaBancaria.Width = 150;
            // 
            // CentroCustoLucro
            // 
            this.CentroCustoLucro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CentroCustoLucro.DataPropertyName = "CentroCustoLucro";
            this.CentroCustoLucro.HeaderText = "Centro Custo";
            this.CentroCustoLucro.Name = "CentroCustoLucro";
            this.CentroCustoLucro.ReadOnly = true;
            this.CentroCustoLucro.Visible = false;
            this.CentroCustoLucro.Width = 150;
            // 
            // FormaPagamento
            // 
            this.FormaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FormaPagamento.DataPropertyName = "FormaPagamento";
            this.FormaPagamento.HeaderText = "Forma Pagamento";
            this.FormaPagamento.Name = "FormaPagamento";
            this.FormaPagamento.ReadOnly = true;
            this.FormaPagamento.Visible = false;
            this.FormaPagamento.Width = 150;
            // 
            // FormaFrete
            // 
            this.FormaFrete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FormaFrete.DataPropertyName = "FormaFrete";
            this.FormaFrete.HeaderText = "Forma Frete";
            this.FormaFrete.Name = "FormaFrete";
            this.FormaFrete.ReadOnly = true;
            this.FormaFrete.Visible = false;
            this.FormaFrete.Width = 150;
            // 
            // ResponsavelFrete
            // 
            this.ResponsavelFrete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ResponsavelFrete.DataPropertyName = "ResponsavelFrete";
            this.ResponsavelFrete.HeaderText = "Responsável Frete";
            this.ResponsavelFrete.Name = "ResponsavelFrete";
            this.ResponsavelFrete.ReadOnly = true;
            this.ResponsavelFrete.Visible = false;
            this.ResponsavelFrete.Width = 150;
            // 
            // OrdemVenda
            // 
            this.OrdemVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrdemVenda.DataPropertyName = "OrdemVenda";
            this.OrdemVenda.HeaderText = "Ordem Venda";
            this.OrdemVenda.Name = "OrdemVenda";
            this.OrdemVenda.ReadOnly = true;
            this.OrdemVenda.Visible = false;
            this.OrdemVenda.Width = 150;
            // 
            // Representante
            // 
            this.Representante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Representante.DataPropertyName = "Representante";
            this.Representante.HeaderText = "Representante";
            this.Representante.Name = "Representante";
            this.Representante.ReadOnly = true;
            this.Representante.Visible = false;
            this.Representante.Width = 150;
            // 
            // PercComissaoRepresentante
            // 
            this.PercComissaoRepresentante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PercComissaoRepresentante.DataPropertyName = "PercComissaoRepresentante";
            this.PercComissaoRepresentante.HeaderText = "Comissão Representante";
            this.PercComissaoRepresentante.Name = "PercComissaoRepresentante";
            this.PercComissaoRepresentante.ReadOnly = true;
            this.PercComissaoRepresentante.Visible = false;
            // 
            // ObsPadraoEspelho
            // 
            this.ObsPadraoEspelho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ObsPadraoEspelho.DataPropertyName = "ObsPadraoEspelho";
            this.ObsPadraoEspelho.HeaderText = "Obs Padrão Espelho";
            this.ObsPadraoEspelho.Name = "ObsPadraoEspelho";
            this.ObsPadraoEspelho.ReadOnly = true;
            this.ObsPadraoEspelho.Visible = false;
            this.ObsPadraoEspelho.Width = 150;
            // 
            // DataUltimaAlteracao
            // 
            this.DataUltimaAlteracao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataUltimaAlteracao.DataPropertyName = "DataUltimaAlteracao";
            this.DataUltimaAlteracao.HeaderText = "Data Última Alteração";
            this.DataUltimaAlteracao.Name = "DataUltimaAlteracao";
            this.DataUltimaAlteracao.ReadOnly = true;
            this.DataUltimaAlteracao.Visible = false;
            // 
            // AcsUsuarioResponsavelSuspensao
            // 
            this.AcsUsuarioResponsavelSuspensao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioResponsavelSuspensao.DataPropertyName = "AcsUsuarioResponsavelSuspensao";
            this.AcsUsuarioResponsavelSuspensao.HeaderText = "Usuário Responsável Suspensão";
            this.AcsUsuarioResponsavelSuspensao.Name = "AcsUsuarioResponsavelSuspensao";
            this.AcsUsuarioResponsavelSuspensao.ReadOnly = true;
            this.AcsUsuarioResponsavelSuspensao.Visible = false;
            this.AcsUsuarioResponsavelSuspensao.Width = 150;
            // 
            // Vendedor
            // 
            this.Vendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Vendedor.DataPropertyName = "Vendedor";
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            this.Vendedor.Visible = false;
            this.Vendedor.Width = 150;
            // 
            // PercComissaoVendedor
            // 
            this.PercComissaoVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PercComissaoVendedor.DataPropertyName = "PercComissaoVendedor";
            this.PercComissaoVendedor.HeaderText = "Comissão Vendedor";
            this.PercComissaoVendedor.Name = "PercComissaoVendedor";
            this.PercComissaoVendedor.ReadOnly = true;
            this.PercComissaoVendedor.Visible = false;
            // 
            // ProdutoDescricao
            // 
            this.ProdutoDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoDescricao.DataPropertyName = "ProdutoDescricao";
            this.ProdutoDescricao.HeaderText = "Descrição Produto";
            this.ProdutoDescricao.Name = "ProdutoDescricao";
            this.ProdutoDescricao.ReadOnly = true;
            this.ProdutoDescricao.Width = 150;
            // 
            // SituacaoGadTraduzidaColumn
            // 
            this.SituacaoGadTraduzidaColumn.DataPropertyName = "SituacaoGadTraduzida";
            this.SituacaoGadTraduzidaColumn.HeaderText = "Situação GAD";
            this.SituacaoGadTraduzidaColumn.Name = "SituacaoGadTraduzidaColumn";
            this.SituacaoGadTraduzidaColumn.ReadOnly = true;
            // 
            // SituacaoGadMensagemColumn
            // 
            this.SituacaoGadMensagemColumn.DataPropertyName = "SituacaoGadMensagem";
            this.SituacaoGadMensagemColumn.HeaderText = "Mensagem GAD";
            this.SituacaoGadMensagemColumn.Name = "SituacaoGadMensagemColumn";
            this.SituacaoGadMensagemColumn.ReadOnly = true;
            // 
            // ProgramacaoDataCriacaoColumn
            // 
            this.ProgramacaoDataCriacaoColumn.DataPropertyName = "GadProgramacaoData";
            this.ProgramacaoDataCriacaoColumn.HeaderText = "Data da Programação";
            this.ProgramacaoDataCriacaoColumn.Name = "ProgramacaoDataCriacaoColumn";
            this.ProgramacaoDataCriacaoColumn.ReadOnly = true;
            // 
            // ProgramacaoNomeColumn
            // 
            this.ProgramacaoNomeColumn.DataPropertyName = "GadProgramacaoNome";
            this.ProgramacaoNomeColumn.HeaderText = "Nome da Programação";
            this.ProgramacaoNomeColumn.Name = "ProgramacaoNomeColumn";
            this.ProgramacaoNomeColumn.ReadOnly = true;
            // 
            // ProgramacaoSituacaoGadColumn
            // 
            this.ProgramacaoSituacaoGadColumn.DataPropertyName = "ProgramacaoSituacaoGad";
            this.ProgramacaoSituacaoGadColumn.HeaderText = "Programação Situação GAD";
            this.ProgramacaoSituacaoGadColumn.Name = "ProgramacaoSituacaoGadColumn";
            this.ProgramacaoSituacaoGadColumn.ReadOnly = true;
            // 
            // ProgramacaoSituacaoGadMensagemColumn
            // 
            this.ProgramacaoSituacaoGadMensagemColumn.DataPropertyName = "ProgramacaoSituacaoGadMensagem";
            this.ProgramacaoSituacaoGadMensagemColumn.HeaderText = "Programação Mensagem GAD";
            this.ProgramacaoSituacaoGadMensagemColumn.Name = "ProgramacaoSituacaoGadMensagemColumn";
            this.ProgramacaoSituacaoGadMensagemColumn.ReadOnly = true;
            // 
            // EnvioTerceirosColumn
            // 
            this.EnvioTerceirosColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EnvioTerceirosColumn.DataPropertyName = "EnvioTerceiros";
            this.EnvioTerceirosColumn.HeaderText = "Envio para Terceiros";
            this.EnvioTerceirosColumn.Name = "EnvioTerceirosColumn";
            this.EnvioTerceirosColumn.ReadOnly = true;
            this.EnvioTerceirosColumn.Visible = false;
            this.EnvioTerceirosColumn.Width = 70;
            // 
            // OperacaoEnvioTerceirosColumn
            // 
            this.OperacaoEnvioTerceirosColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OperacaoEnvioTerceirosColumn.DataPropertyName = "OperacaoEnvioTerceirosList";
            this.OperacaoEnvioTerceirosColumn.HeaderText = "Operação Envio para Terceiros";
            this.OperacaoEnvioTerceirosColumn.Name = "OperacaoEnvioTerceirosColumn";
            this.OperacaoEnvioTerceirosColumn.ReadOnly = true;
            this.OperacaoEnvioTerceirosColumn.Visible = false;
            // 
            // ClienteEnvioTerceirosColumn
            // 
            this.ClienteEnvioTerceirosColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClienteEnvioTerceirosColumn.DataPropertyName = "ClienteEnvioTerceiros";
            this.ClienteEnvioTerceirosColumn.HeaderText = "Cliente Envio Terceiros";
            this.ClienteEnvioTerceirosColumn.Name = "ClienteEnvioTerceirosColumn";
            this.ClienteEnvioTerceirosColumn.ReadOnly = true;
            this.ClienteEnvioTerceirosColumn.Visible = false;
            // 
            // AplicacaoClienteColumn
            // 
            this.AplicacaoClienteColumn.DataPropertyName = "AplicacaoCliente";
            this.AplicacaoClienteColumn.HeaderText = "Aplicação no Cliente";
            this.AplicacaoClienteColumn.Name = "AplicacaoClienteColumn";
            this.AplicacaoClienteColumn.ReadOnly = true;
            this.AplicacaoClienteColumn.Visible = false;
            // 
            // DescontoColumn
            // 
            this.DescontoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescontoColumn.DataPropertyName = "Desconto";
            this.DescontoColumn.HeaderText = "Desconto";
            this.DescontoColumn.Name = "DescontoColumn";
            this.DescontoColumn.ReadOnly = true;
            this.DescontoColumn.Visible = false;
            // 
            // ValorFinalColumn
            // 
            this.ValorFinalColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorFinalColumn.DataPropertyName = "PrecoFinal";
            this.ValorFinalColumn.HeaderText = "Preço Final";
            this.ValorFinalColumn.Name = "ValorFinalColumn";
            this.ValorFinalColumn.ReadOnly = true;
            this.ValorFinalColumn.Visible = false;
            // 
            // PedidoClassificacaoColumn
            // 
            this.PedidoClassificacaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PedidoClassificacaoColumn.DataPropertyName = "PedidoClassificacao";
            this.PedidoClassificacaoColumn.HeaderText = "Classificação de Pedidos";
            this.PedidoClassificacaoColumn.Name = "PedidoClassificacaoColumn";
            this.PedidoClassificacaoColumn.ReadOnly = true;
            this.PedidoClassificacaoColumn.Visible = false;
            this.PedidoClassificacaoColumn.Width = 150;
            // 
            // ProdutoBloqueioPrecoVencidoColumn
            // 
            this.ProdutoBloqueioPrecoVencidoColumn.DataPropertyName = "ProdutoBloqueioPrecoVencido";
            this.ProdutoBloqueioPrecoVencidoColumn.HeaderText = "Possui Produto Bloqueado por Preço Vencido";
            this.ProdutoBloqueioPrecoVencidoColumn.Name = "ProdutoBloqueioPrecoVencidoColumn";
            this.ProdutoBloqueioPrecoVencidoColumn.ReadOnly = true;
            // 
            // btnSuspender
            // 
            this.btnSuspender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuspender.LiberadoQuandoCadastroUtilizado = false;
            this.btnSuspender.Location = new System.Drawing.Point(18, 35);
            this.btnSuspender.Name = "btnSuspender";
            this.btnSuspender.Size = new System.Drawing.Size(110, 23);
            this.btnSuspender.TabIndex = 3;
            this.btnSuspender.Text = "Suspender";
            this.btnSuspender.UseVisualStyleBackColor = true;
            this.btnSuspender.Click += new System.EventHandler(this.btnSuspender_Click);
            // 
            // btnFaturar
            // 
            this.btnFaturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFaturar.LiberadoQuandoCadastroUtilizado = false;
            this.btnFaturar.Location = new System.Drawing.Point(18, 64);
            this.btnFaturar.Name = "btnFaturar";
            this.btnFaturar.Size = new System.Drawing.Size(110, 23);
            this.btnFaturar.TabIndex = 6;
            this.btnFaturar.Text = "Faturar";
            this.btnFaturar.UseVisualStyleBackColor = true;
            this.btnFaturar.Click += new System.EventHandler(this.btnFaturar_Click);
            // 
            // btnImprimirPedido
            // 
            this.btnImprimirPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirPedido.LiberadoQuandoCadastroUtilizado = false;
            this.btnImprimirPedido.Location = new System.Drawing.Point(250, 64);
            this.btnImprimirPedido.Name = "btnImprimirPedido";
            this.btnImprimirPedido.Size = new System.Drawing.Size(121, 23);
            this.btnImprimirPedido.TabIndex = 8;
            this.btnImprimirPedido.Text = "Imprimir";
            this.btnImprimirPedido.UseVisualStyleBackColor = true;
            this.btnImprimirPedido.Click += new System.EventHandler(this.btnImprimirPedido_Click);
            // 
            // btnRelatorioMateriais
            // 
            this.btnRelatorioMateriais.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelatorioMateriais.LiberadoQuandoCadastroUtilizado = false;
            this.btnRelatorioMateriais.Location = new System.Drawing.Point(134, 64);
            this.btnRelatorioMateriais.Name = "btnRelatorioMateriais";
            this.btnRelatorioMateriais.Size = new System.Drawing.Size(110, 23);
            this.btnRelatorioMateriais.TabIndex = 7;
            this.btnRelatorioMateriais.Text = "Consumo Materiais";
            this.btnRelatorioMateriais.UseVisualStyleBackColor = true;
            this.btnRelatorioMateriais.Click += new System.EventHandler(this.btnRelatorioMateriais_Click);
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncerrar.LiberadoQuandoCadastroUtilizado = false;
            this.btnEncerrar.Location = new System.Drawing.Point(134, 35);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(110, 23);
            this.btnEncerrar.TabIndex = 4;
            this.btnEncerrar.Text = "Encerrar";
            this.btnEncerrar.UseVisualStyleBackColor = true;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(250, 35);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(121, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditar.Location = new System.Drawing.Point(134, 6);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.LiberadoQuandoCadastroUtilizado = false;
            this.btnNovo.Location = new System.Drawing.Point(18, 6);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(110, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnFeedback
            // 
            this.btnFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedback.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedback.Location = new System.Drawing.Point(250, 6);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(121, 23);
            this.btnFeedback.TabIndex = 2;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // btnAlterarUrgencia
            // 
            this.btnAlterarUrgencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterarUrgencia.LiberadoQuandoCadastroUtilizado = false;
            this.btnAlterarUrgencia.Location = new System.Drawing.Point(18, 93);
            this.btnAlterarUrgencia.Name = "btnAlterarUrgencia";
            this.btnAlterarUrgencia.Size = new System.Drawing.Size(110, 23);
            this.btnAlterarUrgencia.TabIndex = 9;
            this.btnAlterarUrgencia.Text = "Alterar Urgência";
            this.btnAlterarUrgencia.UseVisualStyleBackColor = true;
            this.btnAlterarUrgencia.Click += new System.EventHandler(this.btnAlterarUrgencia_Click);
            // 
            // btnCancelarGad
            // 
            this.btnCancelarGad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarGad.Image = global::BibliotecaCadastrosBasicos.Properties.Resources.block_black;
            this.btnCancelarGad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarGad.Location = new System.Drawing.Point(200, 129);
            this.btnCancelarGad.Name = "btnCancelarGad";
            this.btnCancelarGad.Size = new System.Drawing.Size(154, 25);
            this.btnCancelarGad.TabIndex = 13;
            this.btnCancelarGad.Text = "     Cancelar no Gad";
            this.btnCancelarGad.UseVisualStyleBackColor = true;
            this.btnCancelarGad.Click += new System.EventHandler(this.btnCancelarGad_Click);
            // 
            // btnAtualizarGad
            // 
            this.btnAtualizarGad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizarGad.Image = global::BibliotecaCadastrosBasicos.Properties.Resources.autorenew_black;
            this.btnAtualizarGad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualizarGad.Location = new System.Drawing.Point(40, 129);
            this.btnAtualizarGad.Name = "btnAtualizarGad";
            this.btnAtualizarGad.Size = new System.Drawing.Size(154, 25);
            this.btnAtualizarGad.TabIndex = 12;
            this.btnAtualizarGad.Text = "Atualizar Situação do Gad";
            this.btnAtualizarGad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtualizarGad.UseVisualStyleBackColor = true;
            this.btnAtualizarGad.Click += new System.EventHandler(this.btnAtualizarGad_Click);
            // 
            // btnEditarSimplificado
            // 
            this.btnEditarSimplificado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarSimplificado.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditarSimplificado.Location = new System.Drawing.Point(134, 93);
            this.btnEditarSimplificado.Name = "btnEditarSimplificado";
            this.btnEditarSimplificado.Size = new System.Drawing.Size(110, 23);
            this.btnEditarSimplificado.TabIndex = 10;
            this.btnEditarSimplificado.Text = "Editar Simplificado";
            this.btnEditarSimplificado.UseVisualStyleBackColor = true;
            this.btnEditarSimplificado.Click += new System.EventHandler(this.btnEditarSimplificado_Click);
            // 
            // btnFeedbackSecundario
            // 
            this.btnFeedbackSecundario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedbackSecundario.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedbackSecundario.Location = new System.Drawing.Point(250, 93);
            this.btnFeedbackSecundario.Name = "btnFeedbackSecundario";
            this.btnFeedbackSecundario.Size = new System.Drawing.Size(121, 23);
            this.btnFeedbackSecundario.TabIndex = 11;
            this.btnFeedbackSecundario.Text = "Planejamento";
            this.btnFeedbackSecundario.UseVisualStyleBackColor = true;
            this.btnFeedbackSecundario.Click += new System.EventHandler(this.btnFeedbackSecundario_Click);
            // 
            // CadPedidoItemListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1224, 394);
            this.Name = "CadPedidoItemListForm";
            this.Text = "Pedidos";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            this.grbPlanejamento.ResumeLayout(false);
            this.grbPlanejamento.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbDataEntrega.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker4)).EndInit();
            this.grbDataEntrada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTRadioButton rdbTodos;
        private IWTDotNetLib.IWTRadioButton rdbReaberto;
        private IWTDotNetLib.IWTRadioButton rdbCancelado;
        private IWTDotNetLib.IWTRadioButton rdbEncerrado;
        private IWTDotNetLib.IWTRadioButton rdbSuspenso;
        private IWTDotNetLib.IWTRadioButton rdbPendentes;
        private IWTDotNetLib.IWTButton btnSuspender;
        private IWTDotNetLib.IWTButton btnFaturar;
        private IWTDotNetLib.IWTButton btnImprimirPedido;
        private IWTDotNetLib.IWTButton btnRelatorioMateriais;
        private IWTDotNetLib.IWTButton btnEncerrar;
        private IWTDotNetLib.IWTButton btnCancelar;
        private IWTDotNetLib.IWTEditarButton btnEditar;
        private IWTDotNetLib.IWTNovoButton btnNovo;
        private IWTButton btnFeedback;
        private IWTButton btnAlterarUrgencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTRadioButton iwtRadioButton4;
        private IWTRadioButton iwtRadioButton3;
        private IWTRadioButton iwtRadioButton2;
        private IWTRadioButton iwtRadioButton1;
        private IWTRadioButton rdbUrgenteTodos;
        private System.Windows.Forms.GroupBox grbDataEntrada;
        private IWTCheckBox chkDataEntrada;
        private System.Windows.Forms.GroupBox grbDataEntrega;
        private IWTDateTimePicker iwtDateTimePicker3;
        private IWTDateTimePicker iwtDateTimePicker4;
        private IWTDateTimePicker iwtDateTimePicker2;
        private IWTDateTimePicker iwtDateTimePicker1;
        private System.Windows.Forms.Button btnCancelarGad;
        private System.Windows.Forms.Button btnAtualizarGad;
        private IWTButton btnEditarSimplificado;
        private IWTButton btnFeedbackSecundario;
        private System.Windows.Forms.GroupBox groupBox3;
        private IWTCheckBox chkDataEntrega;
        private System.Windows.Forms.GroupBox groupBox4;
        private IWTRadioButton rdbFeedbackTodos;
        private IWTRadioButton radioButton5;
        private IWTRadioButton radioButton6;
        private IWTRadioButton rdbConfiguradoTodos;
        private IWTRadioButton radioButton2;
        private IWTRadioButton radioButton1;
        private System.Windows.Forms.GroupBox grbPlanejamento;
        private IWTRadioButton rdbFeedbackSecundarioTodos;
        private IWTRadioButton radioButton8;
        private IWTRadioButton radioButton9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPosicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusTraduzido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassificacaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjetoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemanaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataConfiguracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaNf;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataUltimaNf;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEncerramento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feedback;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeedbackSecundarioColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuspensaoObs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoDescricaoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CnpjCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArmazenagemCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ncm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperacaoCompletaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermiteEntregaParcial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VolumeUnico;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Configurado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Exportacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoTotalOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioCancelamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCancelamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn JustificativaCancelamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Urgente;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrgenteSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrgenteDataPrometida;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrgenteInformacoesComplementares;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntregaOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn InformacaoEspecial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RastreamentoMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CentroCustoLucro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponsavelFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdemVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representante;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercComissaoRepresentante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObsPadraoEspelho;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataUltimaAlteracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioResponsavelSuspensao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercComissaoVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn SituacaoGadTraduzidaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SituacaoGadMensagemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgramacaoDataCriacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgramacaoNomeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgramacaoSituacaoGadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgramacaoSituacaoGadMensagemColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnvioTerceirosColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperacaoEnvioTerceirosColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteEnvioTerceirosColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AplicacaoClienteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescontoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorFinalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoClassificacaoColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ProdutoBloqueioPrecoVencidoColumn;
    }
} 
