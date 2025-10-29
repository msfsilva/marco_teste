namespace BibliotecaCadastrosBasicos
{
    partial class CadTransporteForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCNPJ = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbPF = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbPJ = new IWTDotNetLib.IWTRadioButton(this.components);
            this.txtRazao = new IWTDotNetLib.IWTTextBox(this.components);
            this.lblRazao = new IWTDotNetLib.IWTLabel(this.components);
            this.lblCNPJ = new IWTDotNetLib.IWTLabel(this.components);
            this.label11 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtIe = new IWTDotNetLib.IWTTextBox(this.components);
            this.label9 = new IWTDotNetLib.IWTLabel(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtEndereco = new IWTDotNetLib.IWTTextBox(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPlaca = new IWTDotNetLib.IWTTextBox(this.components);
            this.label13 = new IWTDotNetLib.IWTLabel(this.components);
            this.label14 = new IWTDotNetLib.IWTLabel(this.components);
            this.label15 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtRegAntt = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtIdentficacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtDesc = new IWTDotNetLib.IWTTextBox(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox3 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iesCidade = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.labEstado = new IWTDotNetLib.IWTLabel(this.components);
            this.iesEstadoVeiculo = new IWTDotNetLib.IWTEntitySelection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.txtIdentficacao);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtDesc);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(436, 564);
            this.splitContainer1.SplitterDistance = 498;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(349, 20);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labEstado);
            this.groupBox2.Controls.Add(this.iesCidade);
            this.groupBox2.Controls.Add(this.txtCNPJ);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.txtRazao);
            this.groupBox2.Controls.Add(this.lblRazao);
            this.groupBox2.Controls.Add(this.lblCNPJ);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtIe);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtEndereco);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(8, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 270);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transportador";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.BindingField = "CpfCnpj";
            this.txtCNPJ.LiberadoQuandoCadastroUtilizado = false;
            this.txtCNPJ.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCNPJ.Location = new System.Drawing.Point(90, 111);
            this.txtCNPJ.Mask = "00\\.000\\.000\\/0000\\-00";
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(208, 20);
            this.txtCNPJ.TabIndex = 2;
            this.txtCNPJ.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbPF);
            this.groupBox5.Controls.Add(this.rdbPJ);
            this.groupBox5.Location = new System.Drawing.Point(89, 29);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(228, 47);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipo de Pessoa";
            // 
            // rdbPF
            // 
            this.rdbPF.AutoSize = true;
            this.rdbPF.BindingField = null;
            this.rdbPF.LiberadoQuandoCadastroUtilizado = false;
            this.rdbPF.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbPF.Location = new System.Drawing.Point(11, 21);
            this.rdbPF.Name = "rdbPF";
            this.rdbPF.Size = new System.Drawing.Size(92, 17);
            this.rdbPF.TabIndex = 0;
            this.rdbPF.Text = "Pessoa Física";
            this.rdbPF.UseVisualStyleBackColor = true;
            this.rdbPF.CheckedChanged += new System.EventHandler(this.rdbPF_CheckedChanged);
            // 
            // rdbPJ
            // 
            this.rdbPJ.AutoSize = true;
            this.rdbPJ.BindingField = null;
            this.rdbPJ.Checked = true;
            this.rdbPJ.LiberadoQuandoCadastroUtilizado = false;
            this.rdbPJ.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbPJ.Location = new System.Drawing.Point(121, 21);
            this.rdbPJ.Name = "rdbPJ";
            this.rdbPJ.Size = new System.Drawing.Size(101, 17);
            this.rdbPJ.TabIndex = 1;
            this.rdbPJ.TabStop = true;
            this.rdbPJ.Text = "Pessoa Jurídica";
            this.rdbPJ.UseVisualStyleBackColor = true;
            this.rdbPJ.CheckedChanged += new System.EventHandler(this.rdbPJ_CheckedChanged);
            // 
            // txtRazao
            // 
            this.txtRazao.BindingField = "Razao";
            this.txtRazao.LiberadoQuandoCadastroUtilizado = false;
            this.txtRazao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtRazao.Location = new System.Drawing.Point(90, 86);
            this.txtRazao.MaxLength = 50;
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(311, 20);
            this.txtRazao.TabIndex = 1;
            // 
            // lblRazao
            // 
            this.lblRazao.AutoSize = true;
            this.lblRazao.BindingField = null;
            this.lblRazao.LiberadoQuandoCadastroUtilizado = false;
            this.lblRazao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRazao.Location = new System.Drawing.Point(46, 89);
            this.lblRazao.Name = "lblRazao";
            this.lblRazao.Size = new System.Drawing.Size(38, 13);
            this.lblRazao.TabIndex = 28;
            this.lblRazao.Text = "Razão";
            // 
            // lblCNPJ
            // 
            this.lblCNPJ.AutoSize = true;
            this.lblCNPJ.BindingField = null;
            this.lblCNPJ.LiberadoQuandoCadastroUtilizado = false;
            this.lblCNPJ.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblCNPJ.Location = new System.Drawing.Point(53, 114);
            this.lblCNPJ.Name = "lblCNPJ";
            this.lblCNPJ.Size = new System.Drawing.Size(34, 13);
            this.lblCNPJ.TabIndex = 38;
            this.lblCNPJ.Text = "CNPJ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BindingField = null;
            this.label11.LiberadoQuandoCadastroUtilizado = false;
            this.label11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label11.Location = new System.Drawing.Point(28, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Município";
            // 
            // txtIe
            // 
            this.txtIe.BindingField = "Ie";
            this.txtIe.LiberadoQuandoCadastroUtilizado = false;
            this.txtIe.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtIe.Location = new System.Drawing.Point(90, 137);
            this.txtIe.MaxLength = 50;
            this.txtIe.Name = "txtIe";
            this.txtIe.Size = new System.Drawing.Size(311, 20);
            this.txtIe.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BindingField = null;
            this.label9.LiberadoQuandoCadastroUtilizado = false;
            this.label9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label9.Location = new System.Drawing.Point(61, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "UF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(67, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "IE";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BindingField = "Endereco";
            this.txtEndereco.LiberadoQuandoCadastroUtilizado = true;
            this.txtEndereco.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtEndereco.Location = new System.Drawing.Point(90, 163);
            this.txtEndereco.MaxLength = 50;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(311, 20);
            this.txtEndereco.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(29, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Endereço";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.iesEstadoVeiculo);
            this.groupBox1.Controls.Add(this.txtPlaca);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtRegAntt);
            this.groupBox1.Location = new System.Drawing.Point(8, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veículo";
            // 
            // txtPlaca
            // 
            this.txtPlaca.BindingField = "Placa";
            this.txtPlaca.LiberadoQuandoCadastroUtilizado = false;
            this.txtPlaca.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtPlaca.Location = new System.Drawing.Point(90, 19);
            this.txtPlaca.MaxLength = 8;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(311, 20);
            this.txtPlaca.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BindingField = null;
            this.label13.LiberadoQuandoCadastroUtilizado = false;
            this.label13.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label13.Location = new System.Drawing.Point(50, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Placa";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BindingField = null;
            this.label14.LiberadoQuandoCadastroUtilizado = false;
            this.label14.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label14.Location = new System.Drawing.Point(6, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Registro ANTT";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BindingField = null;
            this.label15.LiberadoQuandoCadastroUtilizado = false;
            this.label15.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label15.Location = new System.Drawing.Point(8, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "UF do Veículo";
            // 
            // txtRegAntt
            // 
            this.txtRegAntt.BindingField = "RegistroAntt";
            this.txtRegAntt.LiberadoQuandoCadastroUtilizado = false;
            this.txtRegAntt.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtRegAntt.Location = new System.Drawing.Point(90, 45);
            this.txtRegAntt.MaxLength = 50;
            this.txtRegAntt.Name = "txtRegAntt";
            this.txtRegAntt.Size = new System.Drawing.Size(311, 20);
            this.txtRegAntt.TabIndex = 1;
            // 
            // txtIdentficacao
            // 
            this.txtIdentficacao.BindingField = "Identificacao";
            this.txtIdentficacao.LiberadoQuandoCadastroUtilizado = false;
            this.txtIdentficacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtIdentficacao.Location = new System.Drawing.Point(103, 10);
            this.txtIdentficacao.MaxLength = 15;
            this.txtIdentficacao.Name = "txtIdentficacao";
            this.txtIdentficacao.Size = new System.Drawing.Size(311, 20);
            this.txtIdentficacao.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(29, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Identificação";
            // 
            // txtDesc
            // 
            this.txtDesc.BindingField = "Descricao";
            this.txtDesc.LiberadoQuandoCadastroUtilizado = true;
            this.txtDesc.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtDesc.Location = new System.Drawing.Point(103, 36);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(311, 20);
            this.txtDesc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(42, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descrição";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Contato";
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(103, 62);
            this.iwtTextBox1.MaxLength = 50;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.Size = new System.Drawing.Size(124, 20);
            this.iwtTextBox1.TabIndex = 2;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(53, 65);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(44, 13);
            this.iwtLabel1.TabIndex = 13;
            this.iwtLabel1.Text = "Contato";
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.BindingField = "Telefone";
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(288, 62);
            this.iwtTextBox2.MaxLength = 50;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.Size = new System.Drawing.Size(126, 20);
            this.iwtTextBox2.TabIndex = 3;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(233, 65);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(49, 13);
            this.iwtLabel2.TabIndex = 15;
            this.iwtLabel2.Text = "Telefone";
            // 
            // iwtTextBox3
            // 
            this.iwtTextBox3.BindingField = "Email";
            this.iwtTextBox3.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox3.Location = new System.Drawing.Point(103, 88);
            this.iwtTextBox3.MaxLength = 50;
            this.iwtTextBox3.Name = "iwtTextBox3";
            this.iwtTextBox3.Size = new System.Drawing.Size(311, 20);
            this.iwtTextBox3.TabIndex = 4;
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(65, 91);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(32, 13);
            this.iwtLabel3.TabIndex = 17;
            this.iwtLabel3.Text = "Email";
            // 
            // iesCidade
            // 
            this.iesCidade.BindingField = "Cidade";
            this.iesCidade.DesabilitarAutoCompletar = false;
            this.iesCidade.DesabilitarChekBox = false;
            this.iesCidade.DesabilitarLupa = false;
            this.iesCidade.DesabilitarSeta = false;
            this.iesCidade.EntidadeSelecionada = null;
            this.iesCidade.FormSelecao = null;
            this.iesCidade.LiberadoQuandoCadastroUtilizado = false;
            this.iesCidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iesCidade.Location = new System.Drawing.Point(90, 189);
            this.iesCidade.ModoVisualizacaoGrid = null;
            this.iesCidade.Name = "iesCidade";
            this.iesCidade.ParametrosBuscaObrigatorios = null;
            this.iesCidade.Size = new System.Drawing.Size(310, 23);
            this.iesCidade.TabIndex = 39;
            this.iesCidade.EntityChange += new System.EventHandler(this.iesCidade_EntityChange);
            // 
            // labEstado
            // 
            this.labEstado.AutoSize = true;
            this.labEstado.BindingField = "Estado";
            this.labEstado.LiberadoQuandoCadastroUtilizado = false;
            this.labEstado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.labEstado.Location = new System.Drawing.Point(89, 216);
            this.labEstado.Name = "labEstado";
            this.labEstado.Size = new System.Drawing.Size(0, 13);
            this.labEstado.TabIndex = 40;
            // 
            // iesEstadoVeiculo
            // 
            this.iesEstadoVeiculo.BindingField = "EstadoVeiculo";
            this.iesEstadoVeiculo.DesabilitarAutoCompletar = false;
            this.iesEstadoVeiculo.DesabilitarChekBox = false;
            this.iesEstadoVeiculo.DesabilitarLupa = false;
            this.iesEstadoVeiculo.DesabilitarSeta = false;
            this.iesEstadoVeiculo.EntidadeSelecionada = null;
            this.iesEstadoVeiculo.FormSelecao = null;
            this.iesEstadoVeiculo.LiberadoQuandoCadastroUtilizado = false;
            this.iesEstadoVeiculo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iesEstadoVeiculo.Location = new System.Drawing.Point(92, 72);
            this.iesEstadoVeiculo.ModoVisualizacaoGrid = null;
            this.iesEstadoVeiculo.Name = "iesEstadoVeiculo";
            this.iesEstadoVeiculo.ParametrosBuscaObrigatorios = null;
            this.iesEstadoVeiculo.Size = new System.Drawing.Size(309, 23);
            this.iesEstadoVeiculo.TabIndex = 45;
            // 
            // CadTransporteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(436, 564);
            this.Name = "CadTransporteForm";
            this.Text = "Transporte";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTTextBox txtRazao;
        private IWTDotNetLib.IWTLabel lblRazao;
        private IWTDotNetLib.IWTLabel lblCNPJ;
        private IWTDotNetLib.IWTLabel label11;
        private IWTDotNetLib.IWTTextBox txtIe;
        private IWTDotNetLib.IWTLabel label9;
        private IWTDotNetLib.IWTLabel label7;
        private IWTDotNetLib.IWTTextBox txtEndereco;
        private IWTDotNetLib.IWTLabel label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTTextBox txtPlaca;
        private IWTDotNetLib.IWTLabel label13;
        private IWTDotNetLib.IWTLabel label14;
        private IWTDotNetLib.IWTLabel label15;
        private IWTDotNetLib.IWTTextBox txtRegAntt;
        private IWTDotNetLib.IWTTextBox txtIdentficacao;
        private IWTDotNetLib.IWTLabel label4;
        private IWTDotNetLib.IWTTextBox txtDesc;
        private IWTDotNetLib.IWTLabel label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private IWTDotNetLib.IWTRadioButton rdbPF;
        private IWTDotNetLib.IWTRadioButton rdbPJ;
        private IWTDotNetLib.IWTMaskedTextBox txtCNPJ;
        private IWTDotNetLib.IWTTextBox iwtTextBox3;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel labEstado;
        private IWTDotNetLib.IWTEntitySelection iesCidade;
        private IWTDotNetLib.IWTEntitySelection iesEstadoVeiculo;
    }
}