namespace ModuloKits
{
    partial class ChamadaKitReportForm
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
            this.gbxOcPos = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.gbxPps = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPps = new System.Windows.Forms.TextBox();
            this.rdbPps = new System.Windows.Forms.RadioButton();
            this.rdbOcPos = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxData = new System.Windows.Forms.GroupBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbData = new System.Windows.Forms.RadioButton();
            this.rdbEmbarqueImediato = new System.Windows.Forms.RadioButton();
            this.rdbReprovados = new System.Windows.Forms.RadioButton();
            this.rdbFabricante = new System.Windows.Forms.RadioButton();
            this.gbxFabricante = new System.Windows.Forms.GroupBox();
            this.cmbFabricante = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.rdbCliente = new System.Windows.Forms.RadioButton();
            this.gbxCliente = new System.Windows.Forms.GroupBox();
            this.cmbCliente = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.rdbProduto = new System.Windows.Forms.RadioButton();
            this.gbxProduto = new System.Windows.Forms.GroupBox();
            this.cmbProduto = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.rdbProjeto = new System.Windows.Forms.RadioButton();
            this.gbxProjeto = new System.Windows.Forms.GroupBox();
            this.txtProjeto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbxSaldo = new System.Windows.Forms.GroupBox();
            this.rdbSaldoSem = new System.Windows.Forms.RadioButton();
            this.rdbSaldoCom = new System.Windows.Forms.RadioButton();
            this.rdbSaldoTodos = new System.Windows.Forms.RadioButton();
            this.grbUrgente = new System.Windows.Forms.GroupBox();
            this.chkUrgenteCritico = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkUrgenteUrgente = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkUrgenteAntecipacao = new IWTDotNetLib.IWTCheckBox(this.components);
            this.rdbMatAdicional = new IWTDotNetLib.IWTRadioButton(this.components);
            this.gbxOcPos.SuspendLayout();
            this.gbxPps.SuspendLayout();
            this.gbxData.SuspendLayout();
            this.gbxFabricante.SuspendLayout();
            this.gbxCliente.SuspendLayout();
            this.gbxProduto.SuspendLayout();
            this.gbxProjeto.SuspendLayout();
            this.gbxSaldo.SuspendLayout();
            this.grbUrgente.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxOcPos
            // 
            this.gbxOcPos.Controls.Add(this.label1);
            this.gbxOcPos.Controls.Add(this.label2);
            this.gbxOcPos.Controls.Add(this.txtPos);
            this.gbxOcPos.Controls.Add(this.txtOc);
            this.gbxOcPos.Enabled = false;
            this.gbxOcPos.Location = new System.Drawing.Point(12, 138);
            this.gbxOcPos.Name = "gbxOcPos";
            this.gbxOcPos.Size = new System.Drawing.Size(310, 61);
            this.gbxOcPos.TabIndex = 5;
            this.gbxOcPos.TabStop = false;
            this.gbxOcPos.Text = "OC/Pos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OC / Pos";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(253, 19);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(51, 20);
            this.txtPos.TabIndex = 1;
            // 
            // txtOc
            // 
            this.txtOc.Location = new System.Drawing.Point(65, 19);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(164, 20);
            this.txtOc.TabIndex = 0;
            // 
            // gbxPps
            // 
            this.gbxPps.Controls.Add(this.label3);
            this.gbxPps.Controls.Add(this.txtPps);
            this.gbxPps.Location = new System.Drawing.Point(12, 12);
            this.gbxPps.Name = "gbxPps";
            this.gbxPps.Size = new System.Drawing.Size(310, 57);
            this.gbxPps.TabIndex = 1;
            this.gbxPps.TabStop = false;
            this.gbxPps.Text = "PPS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "PPS";
            // 
            // txtPps
            // 
            this.txtPps.Location = new System.Drawing.Point(65, 19);
            this.txtPps.Name = "txtPps";
            this.txtPps.Size = new System.Drawing.Size(239, 20);
            this.txtPps.TabIndex = 0;
            // 
            // rdbPps
            // 
            this.rdbPps.AutoSize = true;
            this.rdbPps.Location = new System.Drawing.Point(328, 34);
            this.rdbPps.Name = "rdbPps";
            this.rdbPps.Size = new System.Drawing.Size(14, 13);
            this.rdbPps.TabIndex = 0;
            this.rdbPps.TabStop = true;
            this.rdbPps.UseVisualStyleBackColor = true;
            this.rdbPps.CheckedChanged += new System.EventHandler(this.rdbPps_CheckedChanged);
            // 
            // rdbOcPos
            // 
            this.rdbOcPos.AutoSize = true;
            this.rdbOcPos.Location = new System.Drawing.Point(328, 160);
            this.rdbOcPos.Name = "rdbOcPos";
            this.rdbOcPos.Size = new System.Drawing.Size(14, 13);
            this.rdbOcPos.TabIndex = 4;
            this.rdbOcPos.TabStop = true;
            this.rdbOcPos.UseVisualStyleBackColor = true;
            this.rdbOcPos.CheckedChanged += new System.EventHandler(this.rdbOcPos_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(267, 623);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 38);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(12, 623);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbxData
            // 
            this.gbxData.Controls.Add(this.dtpData);
            this.gbxData.Controls.Add(this.label4);
            this.gbxData.Location = new System.Drawing.Point(12, 75);
            this.gbxData.Name = "gbxData";
            this.gbxData.Size = new System.Drawing.Size(310, 57);
            this.gbxData.TabIndex = 3;
            this.gbxData.TabStop = false;
            this.gbxData.Text = "Data";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(65, 18);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(239, 20);
            this.dtpData.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data";
            // 
            // rdbData
            // 
            this.rdbData.AutoSize = true;
            this.rdbData.Location = new System.Drawing.Point(328, 97);
            this.rdbData.Name = "rdbData";
            this.rdbData.Size = new System.Drawing.Size(14, 13);
            this.rdbData.TabIndex = 2;
            this.rdbData.TabStop = true;
            this.rdbData.UseVisualStyleBackColor = true;
            this.rdbData.CheckedChanged += new System.EventHandler(this.rdbData_CheckedChanged);
            // 
            // rdbEmbarqueImediato
            // 
            this.rdbEmbarqueImediato.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rdbEmbarqueImediato.AutoSize = true;
            this.rdbEmbarqueImediato.Location = new System.Drawing.Point(162, 595);
            this.rdbEmbarqueImediato.Name = "rdbEmbarqueImediato";
            this.rdbEmbarqueImediato.Size = new System.Drawing.Size(180, 17);
            this.rdbEmbarqueImediato.TabIndex = 17;
            this.rdbEmbarqueImediato.TabStop = true;
            this.rdbEmbarqueImediato.Text = "Pedidos com Embarque Imediato";
            this.rdbEmbarqueImediato.UseVisualStyleBackColor = true;
            this.rdbEmbarqueImediato.CheckedChanged += new System.EventHandler(this.rdbEmbarqueImediato_CheckedChanged);
            // 
            // rdbReprovados
            // 
            this.rdbReprovados.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rdbReprovados.AutoSize = true;
            this.rdbReprovados.Location = new System.Drawing.Point(23, 595);
            this.rdbReprovados.Name = "rdbReprovados";
            this.rdbReprovados.Size = new System.Drawing.Size(74, 17);
            this.rdbReprovados.TabIndex = 16;
            this.rdbReprovados.TabStop = true;
            this.rdbReprovados.Text = "Reabertos";
            this.rdbReprovados.UseVisualStyleBackColor = true;
            this.rdbReprovados.CheckedChanged += new System.EventHandler(this.rdbReprovados_CheckedChanged);
            // 
            // rdbFabricante
            // 
            this.rdbFabricante.AutoSize = true;
            this.rdbFabricante.Location = new System.Drawing.Point(328, 227);
            this.rdbFabricante.Name = "rdbFabricante";
            this.rdbFabricante.Size = new System.Drawing.Size(14, 13);
            this.rdbFabricante.TabIndex = 6;
            this.rdbFabricante.TabStop = true;
            this.rdbFabricante.UseVisualStyleBackColor = true;
            this.rdbFabricante.CheckedChanged += new System.EventHandler(this.rdbFabricante_CheckedChanged);
            // 
            // gbxFabricante
            // 
            this.gbxFabricante.Controls.Add(this.cmbFabricante);
            this.gbxFabricante.Controls.Add(this.label5);
            this.gbxFabricante.Location = new System.Drawing.Point(12, 205);
            this.gbxFabricante.Name = "gbxFabricante";
            this.gbxFabricante.Size = new System.Drawing.Size(310, 57);
            this.gbxFabricante.TabIndex = 7;
            this.gbxFabricante.TabStop = false;
            this.gbxFabricante.Text = "Local de Fabricação";
            // 
            // cmbFabricante
            // 
            this.cmbFabricante.ColumnsToDisplay = null;
            this.cmbFabricante.DisableAutoSelectOnEmpty = false;
            this.cmbFabricante.DropDownHeight = 1;
            this.cmbFabricante.FormattingEnabled = true;
            this.cmbFabricante.IntegralHeight = false;
            this.cmbFabricante.Location = new System.Drawing.Point(65, 22);
            this.cmbFabricante.Name = "cmbFabricante";
            this.cmbFabricante.SelectedRow = null;
            this.cmbFabricante.Size = new System.Drawing.Size(239, 21);
            this.cmbFabricante.TabIndex = 0;
            this.cmbFabricante.Table = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Local";
            // 
            // rdbCliente
            // 
            this.rdbCliente.AutoSize = true;
            this.rdbCliente.Location = new System.Drawing.Point(328, 290);
            this.rdbCliente.Name = "rdbCliente";
            this.rdbCliente.Size = new System.Drawing.Size(14, 13);
            this.rdbCliente.TabIndex = 8;
            this.rdbCliente.TabStop = true;
            this.rdbCliente.UseVisualStyleBackColor = true;
            this.rdbCliente.CheckedChanged += new System.EventHandler(this.rdbCliente_CheckedChanged);
            // 
            // gbxCliente
            // 
            this.gbxCliente.Controls.Add(this.cmbCliente);
            this.gbxCliente.Controls.Add(this.label6);
            this.gbxCliente.Enabled = false;
            this.gbxCliente.Location = new System.Drawing.Point(12, 268);
            this.gbxCliente.Name = "gbxCliente";
            this.gbxCliente.Size = new System.Drawing.Size(310, 57);
            this.gbxCliente.TabIndex = 9;
            this.gbxCliente.TabStop = false;
            this.gbxCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.ColumnsToDisplay = null;
            this.cmbCliente.DisableAutoSelectOnEmpty = false;
            this.cmbCliente.DropDownHeight = 1;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.IntegralHeight = false;
            this.cmbCliente.Location = new System.Drawing.Point(65, 22);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.SelectedRow = null;
            this.cmbCliente.Size = new System.Drawing.Size(239, 21);
            this.cmbCliente.TabIndex = 0;
            this.cmbCliente.Table = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cliente";
            // 
            // rdbProduto
            // 
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.Location = new System.Drawing.Point(328, 353);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(14, 13);
            this.rdbProduto.TabIndex = 10;
            this.rdbProduto.TabStop = true;
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // gbxProduto
            // 
            this.gbxProduto.Controls.Add(this.cmbProduto);
            this.gbxProduto.Controls.Add(this.label7);
            this.gbxProduto.Enabled = false;
            this.gbxProduto.Location = new System.Drawing.Point(12, 331);
            this.gbxProduto.Name = "gbxProduto";
            this.gbxProduto.Size = new System.Drawing.Size(310, 57);
            this.gbxProduto.TabIndex = 11;
            this.gbxProduto.TabStop = false;
            this.gbxProduto.Text = "Produto";
            // 
            // cmbProduto
            // 
            this.cmbProduto.ColumnsToDisplay = null;
            this.cmbProduto.DisableAutoSelectOnEmpty = false;
            this.cmbProduto.DropDownHeight = 1;
            this.cmbProduto.FormattingEnabled = true;
            this.cmbProduto.IntegralHeight = false;
            this.cmbProduto.Location = new System.Drawing.Point(65, 22);
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.SelectedRow = null;
            this.cmbProduto.Size = new System.Drawing.Size(239, 21);
            this.cmbProduto.TabIndex = 0;
            this.cmbProduto.Table = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Item";
            // 
            // rdbProjeto
            // 
            this.rdbProjeto.AutoSize = true;
            this.rdbProjeto.Location = new System.Drawing.Point(328, 416);
            this.rdbProjeto.Name = "rdbProjeto";
            this.rdbProjeto.Size = new System.Drawing.Size(14, 13);
            this.rdbProjeto.TabIndex = 12;
            this.rdbProjeto.TabStop = true;
            this.rdbProjeto.UseVisualStyleBackColor = true;
            this.rdbProjeto.CheckedChanged += new System.EventHandler(this.rdbProjeto_CheckedChanged);
            // 
            // gbxProjeto
            // 
            this.gbxProjeto.Controls.Add(this.txtProjeto);
            this.gbxProjeto.Controls.Add(this.label8);
            this.gbxProjeto.Enabled = false;
            this.gbxProjeto.Location = new System.Drawing.Point(12, 394);
            this.gbxProjeto.Name = "gbxProjeto";
            this.gbxProjeto.Size = new System.Drawing.Size(310, 57);
            this.gbxProjeto.TabIndex = 13;
            this.gbxProjeto.TabStop = false;
            this.gbxProjeto.Text = "Projeto";
            // 
            // txtProjeto
            // 
            this.txtProjeto.Location = new System.Drawing.Point(65, 22);
            this.txtProjeto.Name = "txtProjeto";
            this.txtProjeto.Size = new System.Drawing.Size(239, 20);
            this.txtProjeto.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Projeto";
            // 
            // gbxSaldo
            // 
            this.gbxSaldo.Controls.Add(this.rdbSaldoSem);
            this.gbxSaldo.Controls.Add(this.rdbSaldoCom);
            this.gbxSaldo.Controls.Add(this.rdbSaldoTodos);
            this.gbxSaldo.Location = new System.Drawing.Point(12, 457);
            this.gbxSaldo.Name = "gbxSaldo";
            this.gbxSaldo.Size = new System.Drawing.Size(310, 57);
            this.gbxSaldo.TabIndex = 14;
            this.gbxSaldo.TabStop = false;
            this.gbxSaldo.Text = "Saldo de Conferência";
            // 
            // rdbSaldoSem
            // 
            this.rdbSaldoSem.AutoSize = true;
            this.rdbSaldoSem.Location = new System.Drawing.Point(208, 25);
            this.rdbSaldoSem.Name = "rdbSaldoSem";
            this.rdbSaldoSem.Size = new System.Drawing.Size(76, 17);
            this.rdbSaldoSem.TabIndex = 2;
            this.rdbSaldoSem.TabStop = true;
            this.rdbSaldoSem.Text = "Sem Saldo";
            this.rdbSaldoSem.UseVisualStyleBackColor = true;
            // 
            // rdbSaldoCom
            // 
            this.rdbSaldoCom.AutoSize = true;
            this.rdbSaldoCom.Location = new System.Drawing.Point(107, 24);
            this.rdbSaldoCom.Name = "rdbSaldoCom";
            this.rdbSaldoCom.Size = new System.Drawing.Size(76, 17);
            this.rdbSaldoCom.TabIndex = 1;
            this.rdbSaldoCom.TabStop = true;
            this.rdbSaldoCom.Text = "Com Saldo";
            this.rdbSaldoCom.UseVisualStyleBackColor = true;
            // 
            // rdbSaldoTodos
            // 
            this.rdbSaldoTodos.AutoSize = true;
            this.rdbSaldoTodos.Checked = true;
            this.rdbSaldoTodos.Location = new System.Drawing.Point(27, 24);
            this.rdbSaldoTodos.Name = "rdbSaldoTodos";
            this.rdbSaldoTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbSaldoTodos.TabIndex = 0;
            this.rdbSaldoTodos.TabStop = true;
            this.rdbSaldoTodos.Text = "Todos";
            this.rdbSaldoTodos.UseVisualStyleBackColor = true;
            // 
            // grbUrgente
            // 
            this.grbUrgente.Controls.Add(this.chkUrgenteCritico);
            this.grbUrgente.Controls.Add(this.chkUrgenteUrgente);
            this.grbUrgente.Controls.Add(this.chkUrgenteAntecipacao);
            this.grbUrgente.Enabled = false;
            this.grbUrgente.Location = new System.Drawing.Point(12, 520);
            this.grbUrgente.Name = "grbUrgente";
            this.grbUrgente.Size = new System.Drawing.Size(310, 57);
            this.grbUrgente.TabIndex = 15;
            this.grbUrgente.TabStop = false;
            this.grbUrgente.Text = "Pedidos Urgentes";
            // 
            // chkUrgenteCritico
            // 
            this.chkUrgenteCritico.AutoSize = true;
            this.chkUrgenteCritico.BindingField = null;
            this.chkUrgenteCritico.LiberadoQuandoCadastroUtilizado = false;
            this.chkUrgenteCritico.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkUrgenteCritico.Location = new System.Drawing.Point(181, 23);
            this.chkUrgenteCritico.Name = "chkUrgenteCritico";
            this.chkUrgenteCritico.Size = new System.Drawing.Size(57, 17);
            this.chkUrgenteCritico.TabIndex = 14;
            this.chkUrgenteCritico.Text = "Crítico";
            this.chkUrgenteCritico.UseVisualStyleBackColor = true;
            // 
            // chkUrgenteUrgente
            // 
            this.chkUrgenteUrgente.AutoSize = true;
            this.chkUrgenteUrgente.BindingField = null;
            this.chkUrgenteUrgente.LiberadoQuandoCadastroUtilizado = false;
            this.chkUrgenteUrgente.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkUrgenteUrgente.Location = new System.Drawing.Point(107, 23);
            this.chkUrgenteUrgente.Name = "chkUrgenteUrgente";
            this.chkUrgenteUrgente.Size = new System.Drawing.Size(64, 17);
            this.chkUrgenteUrgente.TabIndex = 13;
            this.chkUrgenteUrgente.Text = "Urgente";
            this.chkUrgenteUrgente.UseVisualStyleBackColor = true;
            // 
            // chkUrgenteAntecipacao
            // 
            this.chkUrgenteAntecipacao.AutoSize = true;
            this.chkUrgenteAntecipacao.BindingField = null;
            this.chkUrgenteAntecipacao.LiberadoQuandoCadastroUtilizado = false;
            this.chkUrgenteAntecipacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkUrgenteAntecipacao.Location = new System.Drawing.Point(11, 23);
            this.chkUrgenteAntecipacao.Name = "chkUrgenteAntecipacao";
            this.chkUrgenteAntecipacao.Size = new System.Drawing.Size(86, 17);
            this.chkUrgenteAntecipacao.TabIndex = 12;
            this.chkUrgenteAntecipacao.Text = "Antecipação";
            this.chkUrgenteAntecipacao.UseVisualStyleBackColor = true;
            // 
            // rdbMatAdicional
            // 
            this.rdbMatAdicional.AutoSize = true;
            this.rdbMatAdicional.BindingField = null;
            this.rdbMatAdicional.LiberadoQuandoCadastroUtilizado = false;
            this.rdbMatAdicional.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbMatAdicional.Location = new System.Drawing.Point(328, 543);
            this.rdbMatAdicional.Name = "rdbMatAdicional";
            this.rdbMatAdicional.Size = new System.Drawing.Size(14, 13);
            this.rdbMatAdicional.TabIndex = 15;
            this.rdbMatAdicional.UseVisualStyleBackColor = true;
            this.rdbMatAdicional.CheckedChanged += new System.EventHandler(this.rdbMatAdicional_CheckedChanged_1);
            // 
            // ChamadaKitReportForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(359, 673);
            this.Controls.Add(this.rdbMatAdicional);
            this.Controls.Add(this.grbUrgente);
            this.Controls.Add(this.gbxSaldo);
            this.Controls.Add(this.rdbProjeto);
            this.Controls.Add(this.gbxProjeto);
            this.Controls.Add(this.rdbProduto);
            this.Controls.Add(this.gbxProduto);
            this.Controls.Add(this.rdbCliente);
            this.Controls.Add(this.gbxCliente);
            this.Controls.Add(this.rdbFabricante);
            this.Controls.Add(this.rdbReprovados);
            this.Controls.Add(this.gbxFabricante);
            this.Controls.Add(this.rdbEmbarqueImediato);
            this.Controls.Add(this.rdbData);
            this.Controls.Add(this.gbxData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rdbOcPos);
            this.Controls.Add(this.rdbPps);
            this.Controls.Add(this.gbxPps);
            this.Controls.Add(this.gbxOcPos);
            this.Name = "ChamadaKitReportForm";
            this.Text = "OP de Kits";
            this.gbxOcPos.ResumeLayout(false);
            this.gbxOcPos.PerformLayout();
            this.gbxPps.ResumeLayout(false);
            this.gbxPps.PerformLayout();
            this.gbxData.ResumeLayout(false);
            this.gbxData.PerformLayout();
            this.gbxFabricante.ResumeLayout(false);
            this.gbxFabricante.PerformLayout();
            this.gbxCliente.ResumeLayout(false);
            this.gbxCliente.PerformLayout();
            this.gbxProduto.ResumeLayout(false);
            this.gbxProduto.PerformLayout();
            this.gbxProjeto.ResumeLayout(false);
            this.gbxProjeto.PerformLayout();
            this.gbxSaldo.ResumeLayout(false);
            this.gbxSaldo.PerformLayout();
            this.grbUrgente.ResumeLayout(false);
            this.grbUrgente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxOcPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.GroupBox gbxPps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbPps;
        private System.Windows.Forms.RadioButton rdbOcPos;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbxData;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbData;
        private System.Windows.Forms.RadioButton rdbEmbarqueImediato;
        private System.Windows.Forms.RadioButton rdbReprovados;
        private System.Windows.Forms.RadioButton rdbFabricante;
        private System.Windows.Forms.GroupBox gbxFabricante;
        private System.Windows.Forms.Label label5;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbFabricante;
        private System.Windows.Forms.RadioButton rdbCliente;
        private System.Windows.Forms.GroupBox gbxCliente;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbProduto;
        private System.Windows.Forms.GroupBox gbxProduto;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbProduto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdbProjeto;
        private System.Windows.Forms.GroupBox gbxProjeto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProjeto;
        private System.Windows.Forms.GroupBox gbxSaldo;
        private System.Windows.Forms.RadioButton rdbSaldoTodos;
        private System.Windows.Forms.RadioButton rdbSaldoSem;
        private System.Windows.Forms.RadioButton rdbSaldoCom;
        private System.Windows.Forms.GroupBox grbUrgente;
        private IWTDotNetLib.IWTCheckBox chkUrgenteCritico;
        private IWTDotNetLib.IWTCheckBox chkUrgenteUrgente;
        private IWTDotNetLib.IWTCheckBox chkUrgenteAntecipacao;
        private IWTDotNetLib.IWTRadioButton rdbMatAdicional;
    }
}