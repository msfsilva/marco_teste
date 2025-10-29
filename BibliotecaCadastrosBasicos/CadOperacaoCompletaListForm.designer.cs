namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadOperacaoCompletaListForm 
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
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cfop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CfopForaEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NaturezaOperacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidaPrecos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ConsumidorFinal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PresencaConsumidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GerarContasReceber = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IcmsIncide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsPartilha = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IcmsSomaFreteBc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IcmsCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsAliquotaCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsModDetBc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsReducaoBc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IcmsPercentualReducaoBc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsPercentualBcOperacaoPropria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsModDetBcSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsPercentualReducaoBcSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsMvaSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsPercentualDiferimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsObservacaoDiferimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpiIncide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpiCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpiModTributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpiCodEnquadramento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpiAliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PisIncide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PisCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PisModTributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PisAliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PisImpostoRetido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CofinsIncide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CofinsCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CofinsModTributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CofinsAliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CofinsImpostoRetido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EntregaFutura = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EntregaFuturaCfopRemessa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntregaFuturaCfopRemessaForaEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntregaFuturaNaturezaOperacaoRemessa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DevolucaoMaterialCfop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialCfopForaEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsIncide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsPartilha = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DevolucaoMaterialIcmsSomaFreteBc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DevolucaoMaterialIcmsCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsAliquotaCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsModDetBc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsReducaoBc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DevolucaoMaterialIcmsPercentualReducaoBc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsModDetBcSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsPercentualReducaoBcSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsMvaSt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsPercentualDiferimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIcmsObservacaoDiferimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIpiIncide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIpiCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIpiModTributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIpiCodEnquadramento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialIpiAliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialPisIncide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialPisCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialPisModTributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialPisAliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialPisImpostoRetido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DevolucaoMaterialCofinsIncide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialCofinsCst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialCofinsModTributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialCofinsAliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolucaoMaterialCofinsImpostoRetido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 274);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(582, 62);
            this.splitContainer2.SplitterDistance = 308;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(582, 240);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(308, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 20);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(231, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 23);
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
            this.Identificacao,
            this.Descricao,
            this.Cfop,
            this.CfopForaEstado,
            this.NaturezaOperacao,
            this.ValidaPrecos,
            this.ConsumidorFinal,
            this.PresencaConsumidor,
            this.GerarContasReceber,
            this.IcmsIncide,
            this.IcmsPartilha,
            this.IcmsSomaFreteBc,
            this.IcmsCst,
            this.IcmsAliquotaCredito,
            this.IcmsModDetBc,
            this.IcmsReducaoBc,
            this.IcmsPercentualReducaoBc,
            this.IcmsPercentualBcOperacaoPropria,
            this.IcmsSt,
            this.IcmsModDetBcSt,
            this.IcmsPercentualReducaoBcSt,
            this.IcmsMvaSt,
            this.IcmsPercentualDiferimento,
            this.IcmsObservacaoDiferimento,
            this.IpiIncide,
            this.IpiCst,
            this.IpiModTributacao,
            this.IpiCodEnquadramento,
            this.IpiAliquota,
            this.PisIncide,
            this.PisCst,
            this.PisModTributacao,
            this.PisAliquota,
            this.PisImpostoRetido,
            this.CofinsIncide,
            this.CofinsCst,
            this.CofinsModTributacao,
            this.CofinsAliquota,
            this.CofinsImpostoRetido,
            this.EntregaFutura,
            this.EntregaFuturaCfopRemessa,
            this.EntregaFuturaCfopRemessaForaEstado,
            this.EntregaFuturaNaturezaOperacaoRemessa,
            this.DevolucaoMaterial,
            this.DevolucaoMaterialCfop,
            this.DevolucaoMaterialCfopForaEstado,
            this.DevolucaoMaterialIcmsIncide,
            this.DevolucaoMaterialIcmsPartilha,
            this.DevolucaoMaterialIcmsSomaFreteBc,
            this.DevolucaoMaterialIcmsCst,
            this.DevolucaoMaterialIcmsAliquotaCredito,
            this.DevolucaoMaterialIcmsModDetBc,
            this.DevolucaoMaterialIcmsReducaoBc,
            this.DevolucaoMaterialIcmsPercentualReducaoBc,
            this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria,
            this.DevolucaoMaterialIcmsSt,
            this.DevolucaoMaterialIcmsModDetBcSt,
            this.DevolucaoMaterialIcmsPercentualReducaoBcSt,
            this.DevolucaoMaterialIcmsMvaSt,
            this.DevolucaoMaterialIcmsPercentualDiferimento,
            this.DevolucaoMaterialIcmsObservacaoDiferimento,
            this.DevolucaoMaterialIpiIncide,
            this.DevolucaoMaterialIpiCst,
            this.DevolucaoMaterialIpiModTributacao,
            this.DevolucaoMaterialIpiCodEnquadramento,
            this.DevolucaoMaterialIpiAliquota,
            this.DevolucaoMaterialPisIncide,
            this.DevolucaoMaterialPisCst,
            this.DevolucaoMaterialPisModTributacao,
            this.DevolucaoMaterialPisAliquota,
            this.DevolucaoMaterialPisImpostoRetido,
            this.DevolucaoMaterialCofinsIncide,
            this.DevolucaoMaterialCofinsCst,
            this.DevolucaoMaterialCofinsModTributacao,
            this.DevolucaoMaterialCofinsAliquota,
            this.DevolucaoMaterialCofinsImpostoRetido});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(582, 202);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Identificacao
            // 
            this.Identificacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Identificacao.DataPropertyName = "Identificacao";
            this.Identificacao.HeaderText = "Identificação";
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.ReadOnly = true;
            this.Identificacao.Width = 150;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 150;
            // 
            // Cfop
            // 
            this.Cfop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cfop.DataPropertyName = "Cfop";
            this.Cfop.HeaderText = "Cfop";
            this.Cfop.Name = "Cfop";
            this.Cfop.ReadOnly = true;
            this.Cfop.Width = 70;
            // 
            // CfopForaEstado
            // 
            this.CfopForaEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CfopForaEstado.DataPropertyName = "CfopForaEstado";
            this.CfopForaEstado.HeaderText = "Cfop Fora Estado";
            this.CfopForaEstado.Name = "CfopForaEstado";
            this.CfopForaEstado.ReadOnly = true;
            this.CfopForaEstado.Width = 70;
            // 
            // NaturezaOperacao
            // 
            this.NaturezaOperacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NaturezaOperacao.DataPropertyName = "NaturezaOperacao";
            this.NaturezaOperacao.HeaderText = "Natureza Operação";
            this.NaturezaOperacao.Name = "NaturezaOperacao";
            this.NaturezaOperacao.ReadOnly = true;
            this.NaturezaOperacao.Width = 150;
            // 
            // ValidaPrecos
            // 
            this.ValidaPrecos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValidaPrecos.DataPropertyName = "ValidaPrecos";
            this.ValidaPrecos.HeaderText = "Valida Precos";
            this.ValidaPrecos.Name = "ValidaPrecos";
            this.ValidaPrecos.ReadOnly = true;
            this.ValidaPrecos.Width = 70;
            // 
            // ConsumidorFinal
            // 
            this.ConsumidorFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ConsumidorFinal.DataPropertyName = "ConsumidorFinal";
            this.ConsumidorFinal.HeaderText = "Consumidor Final";
            this.ConsumidorFinal.Name = "ConsumidorFinal";
            this.ConsumidorFinal.ReadOnly = true;
            this.ConsumidorFinal.Width = 70;
            // 
            // PresencaConsumidor
            // 
            this.PresencaConsumidor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PresencaConsumidor.DataPropertyName = "PresencaConsumidor";
            this.PresencaConsumidor.HeaderText = "Presenca Consumidor";
            this.PresencaConsumidor.Name = "PresencaConsumidor";
            this.PresencaConsumidor.ReadOnly = true;
            this.PresencaConsumidor.Width = 70;
            // 
            // GerarContasReceber
            // 
            this.GerarContasReceber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GerarContasReceber.DataPropertyName = "GerarContasReceber";
            this.GerarContasReceber.HeaderText = "Gerar Contas Receber";
            this.GerarContasReceber.Name = "GerarContasReceber";
            this.GerarContasReceber.ReadOnly = true;
            this.GerarContasReceber.Width = 70;
            // 
            // IcmsIncide
            // 
            this.IcmsIncide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsIncide.DataPropertyName = "IcmsIncide";
            this.IcmsIncide.HeaderText = "Icms Incide";
            this.IcmsIncide.Name = "IcmsIncide";
            this.IcmsIncide.ReadOnly = true;
            this.IcmsIncide.Visible = false;
            this.IcmsIncide.Width = 150;
            // 
            // IcmsPartilha
            // 
            this.IcmsPartilha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsPartilha.DataPropertyName = "IcmsPartilha";
            this.IcmsPartilha.HeaderText = "Icms Partilha";
            this.IcmsPartilha.Name = "IcmsPartilha";
            this.IcmsPartilha.ReadOnly = true;
            this.IcmsPartilha.Visible = false;
            this.IcmsPartilha.Width = 70;
            // 
            // IcmsSomaFreteBc
            // 
            this.IcmsSomaFreteBc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsSomaFreteBc.DataPropertyName = "IcmsSomaFreteBc";
            this.IcmsSomaFreteBc.HeaderText = "Icms Soma Frete Bc";
            this.IcmsSomaFreteBc.Name = "IcmsSomaFreteBc";
            this.IcmsSomaFreteBc.ReadOnly = true;
            this.IcmsSomaFreteBc.Visible = false;
            this.IcmsSomaFreteBc.Width = 70;
            // 
            // IcmsCst
            // 
            this.IcmsCst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsCst.DataPropertyName = "IcmsCst";
            this.IcmsCst.HeaderText = "Icms Cst";
            this.IcmsCst.Name = "IcmsCst";
            this.IcmsCst.ReadOnly = true;
            this.IcmsCst.Visible = false;
            this.IcmsCst.Width = 150;
            // 
            // IcmsAliquotaCredito
            // 
            this.IcmsAliquotaCredito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsAliquotaCredito.DataPropertyName = "IcmsAliquotaCredito";
            this.IcmsAliquotaCredito.HeaderText = "Icms Aliquota Credito";
            this.IcmsAliquotaCredito.Name = "IcmsAliquotaCredito";
            this.IcmsAliquotaCredito.ReadOnly = true;
            this.IcmsAliquotaCredito.Visible = false;
            // 
            // IcmsModDetBc
            // 
            this.IcmsModDetBc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsModDetBc.DataPropertyName = "IcmsModDetBc";
            this.IcmsModDetBc.HeaderText = "Icms Mod Det Bc";
            this.IcmsModDetBc.Name = "IcmsModDetBc";
            this.IcmsModDetBc.ReadOnly = true;
            this.IcmsModDetBc.Visible = false;
            this.IcmsModDetBc.Width = 70;
            // 
            // IcmsReducaoBc
            // 
            this.IcmsReducaoBc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsReducaoBc.DataPropertyName = "IcmsReducaoBc";
            this.IcmsReducaoBc.HeaderText = "Icms Redução Bc";
            this.IcmsReducaoBc.Name = "IcmsReducaoBc";
            this.IcmsReducaoBc.ReadOnly = true;
            this.IcmsReducaoBc.Visible = false;
            this.IcmsReducaoBc.Width = 70;
            // 
            // IcmsPercentualReducaoBc
            // 
            this.IcmsPercentualReducaoBc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsPercentualReducaoBc.DataPropertyName = "IcmsPercentualReducaoBc";
            this.IcmsPercentualReducaoBc.HeaderText = "Icms Percentual Redução Bc";
            this.IcmsPercentualReducaoBc.Name = "IcmsPercentualReducaoBc";
            this.IcmsPercentualReducaoBc.ReadOnly = true;
            this.IcmsPercentualReducaoBc.Visible = false;
            // 
            // IcmsPercentualBcOperacaoPropria
            // 
            this.IcmsPercentualBcOperacaoPropria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsPercentualBcOperacaoPropria.DataPropertyName = "IcmsPercentualBcOperacaoPropria";
            this.IcmsPercentualBcOperacaoPropria.HeaderText = "Icms Percentual Bc Operação Propria";
            this.IcmsPercentualBcOperacaoPropria.Name = "IcmsPercentualBcOperacaoPropria";
            this.IcmsPercentualBcOperacaoPropria.ReadOnly = true;
            this.IcmsPercentualBcOperacaoPropria.Visible = false;
            // 
            // IcmsSt
            // 
            this.IcmsSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsSt.DataPropertyName = "IcmsSt";
            this.IcmsSt.HeaderText = "Icms St";
            this.IcmsSt.Name = "IcmsSt";
            this.IcmsSt.ReadOnly = true;
            this.IcmsSt.Visible = false;
            this.IcmsSt.Width = 70;
            // 
            // IcmsModDetBcSt
            // 
            this.IcmsModDetBcSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsModDetBcSt.DataPropertyName = "IcmsModDetBcSt";
            this.IcmsModDetBcSt.HeaderText = "Icms Mod Det Bc St";
            this.IcmsModDetBcSt.Name = "IcmsModDetBcSt";
            this.IcmsModDetBcSt.ReadOnly = true;
            this.IcmsModDetBcSt.Visible = false;
            this.IcmsModDetBcSt.Width = 70;
            // 
            // IcmsPercentualReducaoBcSt
            // 
            this.IcmsPercentualReducaoBcSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsPercentualReducaoBcSt.DataPropertyName = "IcmsPercentualReducaoBcSt";
            this.IcmsPercentualReducaoBcSt.HeaderText = "Icms Percentual Redução Bc St";
            this.IcmsPercentualReducaoBcSt.Name = "IcmsPercentualReducaoBcSt";
            this.IcmsPercentualReducaoBcSt.ReadOnly = true;
            this.IcmsPercentualReducaoBcSt.Visible = false;
            // 
            // IcmsMvaSt
            // 
            this.IcmsMvaSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsMvaSt.DataPropertyName = "IcmsMvaSt";
            this.IcmsMvaSt.HeaderText = "Icms Mva St";
            this.IcmsMvaSt.Name = "IcmsMvaSt";
            this.IcmsMvaSt.ReadOnly = true;
            this.IcmsMvaSt.Visible = false;
            // 
            // IcmsPercentualDiferimento
            // 
            this.IcmsPercentualDiferimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsPercentualDiferimento.DataPropertyName = "IcmsPercentualDiferimento";
            this.IcmsPercentualDiferimento.HeaderText = "Icms Percentual Diferimento";
            this.IcmsPercentualDiferimento.Name = "IcmsPercentualDiferimento";
            this.IcmsPercentualDiferimento.ReadOnly = true;
            this.IcmsPercentualDiferimento.Visible = false;
            // 
            // IcmsObservacaoDiferimento
            // 
            this.IcmsObservacaoDiferimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IcmsObservacaoDiferimento.DataPropertyName = "IcmsObservacaoDiferimento";
            this.IcmsObservacaoDiferimento.HeaderText = "Icms Observação Diferimento";
            this.IcmsObservacaoDiferimento.Name = "IcmsObservacaoDiferimento";
            this.IcmsObservacaoDiferimento.ReadOnly = true;
            this.IcmsObservacaoDiferimento.Visible = false;
            this.IcmsObservacaoDiferimento.Width = 150;
            // 
            // IpiIncide
            // 
            this.IpiIncide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IpiIncide.DataPropertyName = "IpiIncide";
            this.IpiIncide.HeaderText = "Ipi Incide";
            this.IpiIncide.Name = "IpiIncide";
            this.IpiIncide.ReadOnly = true;
            this.IpiIncide.Visible = false;
            this.IpiIncide.Width = 150;
            // 
            // IpiCst
            // 
            this.IpiCst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IpiCst.DataPropertyName = "IpiCst";
            this.IpiCst.HeaderText = "Ipi Cst";
            this.IpiCst.Name = "IpiCst";
            this.IpiCst.ReadOnly = true;
            this.IpiCst.Visible = false;
            this.IpiCst.Width = 150;
            // 
            // IpiModTributacao
            // 
            this.IpiModTributacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IpiModTributacao.DataPropertyName = "IpiModTributacao";
            this.IpiModTributacao.HeaderText = "Ipi Mod Tributação";
            this.IpiModTributacao.Name = "IpiModTributacao";
            this.IpiModTributacao.ReadOnly = true;
            this.IpiModTributacao.Visible = false;
            this.IpiModTributacao.Width = 70;
            // 
            // IpiCodEnquadramento
            // 
            this.IpiCodEnquadramento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IpiCodEnquadramento.DataPropertyName = "IpiCodEnquadramento";
            this.IpiCodEnquadramento.HeaderText = "Ipi Cod Enquadramento";
            this.IpiCodEnquadramento.Name = "IpiCodEnquadramento";
            this.IpiCodEnquadramento.ReadOnly = true;
            this.IpiCodEnquadramento.Visible = false;
            this.IpiCodEnquadramento.Width = 150;
            // 
            // IpiAliquota
            // 
            this.IpiAliquota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IpiAliquota.DataPropertyName = "IpiAliquota";
            this.IpiAliquota.HeaderText = "Ipi Aliquota";
            this.IpiAliquota.Name = "IpiAliquota";
            this.IpiAliquota.ReadOnly = true;
            this.IpiAliquota.Visible = false;
            // 
            // PisIncide
            // 
            this.PisIncide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PisIncide.DataPropertyName = "PisIncide";
            this.PisIncide.HeaderText = "Pis Incide";
            this.PisIncide.Name = "PisIncide";
            this.PisIncide.ReadOnly = true;
            this.PisIncide.Visible = false;
            this.PisIncide.Width = 150;
            // 
            // PisCst
            // 
            this.PisCst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PisCst.DataPropertyName = "PisCst";
            this.PisCst.HeaderText = "Pis Cst";
            this.PisCst.Name = "PisCst";
            this.PisCst.ReadOnly = true;
            this.PisCst.Visible = false;
            this.PisCst.Width = 150;
            // 
            // PisModTributacao
            // 
            this.PisModTributacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PisModTributacao.DataPropertyName = "PisModTributacao";
            this.PisModTributacao.HeaderText = "Pis Mod Tributação";
            this.PisModTributacao.Name = "PisModTributacao";
            this.PisModTributacao.ReadOnly = true;
            this.PisModTributacao.Visible = false;
            this.PisModTributacao.Width = 70;
            // 
            // PisAliquota
            // 
            this.PisAliquota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PisAliquota.DataPropertyName = "PisAliquota";
            this.PisAliquota.HeaderText = "Pis Aliquota";
            this.PisAliquota.Name = "PisAliquota";
            this.PisAliquota.ReadOnly = true;
            this.PisAliquota.Visible = false;
            // 
            // PisImpostoRetido
            // 
            this.PisImpostoRetido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PisImpostoRetido.DataPropertyName = "PisImpostoRetido";
            this.PisImpostoRetido.HeaderText = "Pis Imposto Retido";
            this.PisImpostoRetido.Name = "PisImpostoRetido";
            this.PisImpostoRetido.ReadOnly = true;
            this.PisImpostoRetido.Visible = false;
            this.PisImpostoRetido.Width = 70;
            // 
            // CofinsIncide
            // 
            this.CofinsIncide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CofinsIncide.DataPropertyName = "CofinsIncide";
            this.CofinsIncide.HeaderText = "Cofins Incide";
            this.CofinsIncide.Name = "CofinsIncide";
            this.CofinsIncide.ReadOnly = true;
            this.CofinsIncide.Visible = false;
            this.CofinsIncide.Width = 150;
            // 
            // CofinsCst
            // 
            this.CofinsCst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CofinsCst.DataPropertyName = "CofinsCst";
            this.CofinsCst.HeaderText = "Cofins Cst";
            this.CofinsCst.Name = "CofinsCst";
            this.CofinsCst.ReadOnly = true;
            this.CofinsCst.Visible = false;
            this.CofinsCst.Width = 150;
            // 
            // CofinsModTributacao
            // 
            this.CofinsModTributacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CofinsModTributacao.DataPropertyName = "CofinsModTributacao";
            this.CofinsModTributacao.HeaderText = "Cofins Mod Tributação";
            this.CofinsModTributacao.Name = "CofinsModTributacao";
            this.CofinsModTributacao.ReadOnly = true;
            this.CofinsModTributacao.Visible = false;
            this.CofinsModTributacao.Width = 70;
            // 
            // CofinsAliquota
            // 
            this.CofinsAliquota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CofinsAliquota.DataPropertyName = "CofinsAliquota";
            this.CofinsAliquota.HeaderText = "Cofins Aliquota";
            this.CofinsAliquota.Name = "CofinsAliquota";
            this.CofinsAliquota.ReadOnly = true;
            this.CofinsAliquota.Visible = false;
            // 
            // CofinsImpostoRetido
            // 
            this.CofinsImpostoRetido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CofinsImpostoRetido.DataPropertyName = "CofinsImpostoRetido";
            this.CofinsImpostoRetido.HeaderText = "Cofins Imposto Retido";
            this.CofinsImpostoRetido.Name = "CofinsImpostoRetido";
            this.CofinsImpostoRetido.ReadOnly = true;
            this.CofinsImpostoRetido.Visible = false;
            this.CofinsImpostoRetido.Width = 70;
            // 
            // EntregaFutura
            // 
            this.EntregaFutura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EntregaFutura.DataPropertyName = "EntregaFutura";
            this.EntregaFutura.HeaderText = "Entrega Futura";
            this.EntregaFutura.Name = "EntregaFutura";
            this.EntregaFutura.ReadOnly = true;
            this.EntregaFutura.Width = 70;
            // 
            // EntregaFuturaCfopRemessa
            // 
            this.EntregaFuturaCfopRemessa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EntregaFuturaCfopRemessa.DataPropertyName = "EntregaFuturaCfopRemessa";
            this.EntregaFuturaCfopRemessa.HeaderText = "Entrega Futura Cfop Remessa";
            this.EntregaFuturaCfopRemessa.Name = "EntregaFuturaCfopRemessa";
            this.EntregaFuturaCfopRemessa.ReadOnly = true;
            this.EntregaFuturaCfopRemessa.Visible = false;
            this.EntregaFuturaCfopRemessa.Width = 70;
            // 
            // EntregaFuturaCfopRemessaForaEstado
            // 
            this.EntregaFuturaCfopRemessaForaEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EntregaFuturaCfopRemessaForaEstado.DataPropertyName = "EntregaFuturaCfopRemessaForaEstado";
            this.EntregaFuturaCfopRemessaForaEstado.HeaderText = "Entrega Futura Cfop Remessa Fora Estado";
            this.EntregaFuturaCfopRemessaForaEstado.Name = "EntregaFuturaCfopRemessaForaEstado";
            this.EntregaFuturaCfopRemessaForaEstado.ReadOnly = true;
            this.EntregaFuturaCfopRemessaForaEstado.Visible = false;
            this.EntregaFuturaCfopRemessaForaEstado.Width = 70;
            // 
            // EntregaFuturaNaturezaOperacaoRemessa
            // 
            this.EntregaFuturaNaturezaOperacaoRemessa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EntregaFuturaNaturezaOperacaoRemessa.DataPropertyName = "EntregaFuturaNaturezaOperacaoRemessa";
            this.EntregaFuturaNaturezaOperacaoRemessa.HeaderText = "Entrega Futura Natureza Operação Remessa";
            this.EntregaFuturaNaturezaOperacaoRemessa.Name = "EntregaFuturaNaturezaOperacaoRemessa";
            this.EntregaFuturaNaturezaOperacaoRemessa.ReadOnly = true;
            this.EntregaFuturaNaturezaOperacaoRemessa.Visible = false;
            this.EntregaFuturaNaturezaOperacaoRemessa.Width = 150;
            // 
            // DevolucaoMaterial
            // 
            this.DevolucaoMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterial.DataPropertyName = "DevolucaoMaterial";
            this.DevolucaoMaterial.HeaderText = "Devolução Material";
            this.DevolucaoMaterial.Name = "DevolucaoMaterial";
            this.DevolucaoMaterial.ReadOnly = true;
            this.DevolucaoMaterial.Width = 70;
            // 
            // DevolucaoMaterialCfop
            // 
            this.DevolucaoMaterialCfop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialCfop.DataPropertyName = "DevolucaoMaterialCfop";
            this.DevolucaoMaterialCfop.HeaderText = "Devolução Material Cfop";
            this.DevolucaoMaterialCfop.Name = "DevolucaoMaterialCfop";
            this.DevolucaoMaterialCfop.ReadOnly = true;
            this.DevolucaoMaterialCfop.Visible = false;
            this.DevolucaoMaterialCfop.Width = 70;
            // 
            // DevolucaoMaterialCfopForaEstado
            // 
            this.DevolucaoMaterialCfopForaEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialCfopForaEstado.DataPropertyName = "DevolucaoMaterialCfopForaEstado";
            this.DevolucaoMaterialCfopForaEstado.HeaderText = "Devolução Material Cfop Fora Estado";
            this.DevolucaoMaterialCfopForaEstado.Name = "DevolucaoMaterialCfopForaEstado";
            this.DevolucaoMaterialCfopForaEstado.ReadOnly = true;
            this.DevolucaoMaterialCfopForaEstado.Visible = false;
            this.DevolucaoMaterialCfopForaEstado.Width = 70;
            // 
            // DevolucaoMaterialIcmsIncide
            // 
            this.DevolucaoMaterialIcmsIncide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsIncide.DataPropertyName = "DevolucaoMaterialIcmsIncide";
            this.DevolucaoMaterialIcmsIncide.HeaderText = "Devolução Material Icms Incide";
            this.DevolucaoMaterialIcmsIncide.Name = "DevolucaoMaterialIcmsIncide";
            this.DevolucaoMaterialIcmsIncide.ReadOnly = true;
            this.DevolucaoMaterialIcmsIncide.Visible = false;
            this.DevolucaoMaterialIcmsIncide.Width = 150;
            // 
            // DevolucaoMaterialIcmsPartilha
            // 
            this.DevolucaoMaterialIcmsPartilha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsPartilha.DataPropertyName = "DevolucaoMaterialIcmsPartilha";
            this.DevolucaoMaterialIcmsPartilha.HeaderText = "Devolução Material Icms Partilha";
            this.DevolucaoMaterialIcmsPartilha.Name = "DevolucaoMaterialIcmsPartilha";
            this.DevolucaoMaterialIcmsPartilha.ReadOnly = true;
            this.DevolucaoMaterialIcmsPartilha.Visible = false;
            this.DevolucaoMaterialIcmsPartilha.Width = 70;
            // 
            // DevolucaoMaterialIcmsSomaFreteBc
            // 
            this.DevolucaoMaterialIcmsSomaFreteBc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsSomaFreteBc.DataPropertyName = "DevolucaoMaterialIcmsSomaFreteBc";
            this.DevolucaoMaterialIcmsSomaFreteBc.HeaderText = "Devolução Material Icms Soma Frete Bc";
            this.DevolucaoMaterialIcmsSomaFreteBc.Name = "DevolucaoMaterialIcmsSomaFreteBc";
            this.DevolucaoMaterialIcmsSomaFreteBc.ReadOnly = true;
            this.DevolucaoMaterialIcmsSomaFreteBc.Visible = false;
            this.DevolucaoMaterialIcmsSomaFreteBc.Width = 70;
            // 
            // DevolucaoMaterialIcmsCst
            // 
            this.DevolucaoMaterialIcmsCst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsCst.DataPropertyName = "DevolucaoMaterialIcmsCst";
            this.DevolucaoMaterialIcmsCst.HeaderText = "Devolução Material Icms Cst";
            this.DevolucaoMaterialIcmsCst.Name = "DevolucaoMaterialIcmsCst";
            this.DevolucaoMaterialIcmsCst.ReadOnly = true;
            this.DevolucaoMaterialIcmsCst.Visible = false;
            this.DevolucaoMaterialIcmsCst.Width = 150;
            // 
            // DevolucaoMaterialIcmsAliquotaCredito
            // 
            this.DevolucaoMaterialIcmsAliquotaCredito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsAliquotaCredito.DataPropertyName = "DevolucaoMaterialIcmsAliquotaCredito";
            this.DevolucaoMaterialIcmsAliquotaCredito.HeaderText = "Devolução Material Icms Aliquota Credito";
            this.DevolucaoMaterialIcmsAliquotaCredito.Name = "DevolucaoMaterialIcmsAliquotaCredito";
            this.DevolucaoMaterialIcmsAliquotaCredito.ReadOnly = true;
            this.DevolucaoMaterialIcmsAliquotaCredito.Visible = false;
            // 
            // DevolucaoMaterialIcmsModDetBc
            // 
            this.DevolucaoMaterialIcmsModDetBc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsModDetBc.DataPropertyName = "DevolucaoMaterialIcmsModDetBc";
            this.DevolucaoMaterialIcmsModDetBc.HeaderText = "Devolução Material Icms Mod Det Bc";
            this.DevolucaoMaterialIcmsModDetBc.Name = "DevolucaoMaterialIcmsModDetBc";
            this.DevolucaoMaterialIcmsModDetBc.ReadOnly = true;
            this.DevolucaoMaterialIcmsModDetBc.Visible = false;
            this.DevolucaoMaterialIcmsModDetBc.Width = 70;
            // 
            // DevolucaoMaterialIcmsReducaoBc
            // 
            this.DevolucaoMaterialIcmsReducaoBc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsReducaoBc.DataPropertyName = "DevolucaoMaterialIcmsReducaoBc";
            this.DevolucaoMaterialIcmsReducaoBc.HeaderText = "Devolução Material Icms Redução Bc";
            this.DevolucaoMaterialIcmsReducaoBc.Name = "DevolucaoMaterialIcmsReducaoBc";
            this.DevolucaoMaterialIcmsReducaoBc.ReadOnly = true;
            this.DevolucaoMaterialIcmsReducaoBc.Visible = false;
            this.DevolucaoMaterialIcmsReducaoBc.Width = 70;
            // 
            // DevolucaoMaterialIcmsPercentualReducaoBc
            // 
            this.DevolucaoMaterialIcmsPercentualReducaoBc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsPercentualReducaoBc.DataPropertyName = "DevolucaoMaterialIcmsPercentualReducaoBc";
            this.DevolucaoMaterialIcmsPercentualReducaoBc.HeaderText = "Devolução Material Icms Percentual Redução Bc";
            this.DevolucaoMaterialIcmsPercentualReducaoBc.Name = "DevolucaoMaterialIcmsPercentualReducaoBc";
            this.DevolucaoMaterialIcmsPercentualReducaoBc.ReadOnly = true;
            this.DevolucaoMaterialIcmsPercentualReducaoBc.Visible = false;
            // 
            // DevolucaoMaterialIcmsPercentualBcOperacaoPropria
            // 
            this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria.DataPropertyName = "DevolucaoMaterialIcmsPercentualBcOperacaoPropria";
            this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria.HeaderText = "Devolução Material Icms Percentual Bc Operação Propria";
            this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria.Name = "DevolucaoMaterialIcmsPercentualBcOperacaoPropria";
            this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria.ReadOnly = true;
            this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria.Visible = false;
            // 
            // DevolucaoMaterialIcmsSt
            // 
            this.DevolucaoMaterialIcmsSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsSt.DataPropertyName = "DevolucaoMaterialIcmsSt";
            this.DevolucaoMaterialIcmsSt.HeaderText = "Devolução Material Icms St";
            this.DevolucaoMaterialIcmsSt.Name = "DevolucaoMaterialIcmsSt";
            this.DevolucaoMaterialIcmsSt.ReadOnly = true;
            this.DevolucaoMaterialIcmsSt.Visible = false;
            this.DevolucaoMaterialIcmsSt.Width = 70;
            // 
            // DevolucaoMaterialIcmsModDetBcSt
            // 
            this.DevolucaoMaterialIcmsModDetBcSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsModDetBcSt.DataPropertyName = "DevolucaoMaterialIcmsModDetBcSt";
            this.DevolucaoMaterialIcmsModDetBcSt.HeaderText = "Devolução Material Icms Mod Det Bc St";
            this.DevolucaoMaterialIcmsModDetBcSt.Name = "DevolucaoMaterialIcmsModDetBcSt";
            this.DevolucaoMaterialIcmsModDetBcSt.ReadOnly = true;
            this.DevolucaoMaterialIcmsModDetBcSt.Visible = false;
            this.DevolucaoMaterialIcmsModDetBcSt.Width = 70;
            // 
            // DevolucaoMaterialIcmsPercentualReducaoBcSt
            // 
            this.DevolucaoMaterialIcmsPercentualReducaoBcSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsPercentualReducaoBcSt.DataPropertyName = "DevolucaoMaterialIcmsPercentualReducaoBcSt";
            this.DevolucaoMaterialIcmsPercentualReducaoBcSt.HeaderText = "Devolução Material Icms Percentual Redução Bc St";
            this.DevolucaoMaterialIcmsPercentualReducaoBcSt.Name = "DevolucaoMaterialIcmsPercentualReducaoBcSt";
            this.DevolucaoMaterialIcmsPercentualReducaoBcSt.ReadOnly = true;
            this.DevolucaoMaterialIcmsPercentualReducaoBcSt.Visible = false;
            // 
            // DevolucaoMaterialIcmsMvaSt
            // 
            this.DevolucaoMaterialIcmsMvaSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsMvaSt.DataPropertyName = "DevolucaoMaterialIcmsMvaSt";
            this.DevolucaoMaterialIcmsMvaSt.HeaderText = "Devolução Material Icms Mva St";
            this.DevolucaoMaterialIcmsMvaSt.Name = "DevolucaoMaterialIcmsMvaSt";
            this.DevolucaoMaterialIcmsMvaSt.ReadOnly = true;
            this.DevolucaoMaterialIcmsMvaSt.Visible = false;
            // 
            // DevolucaoMaterialIcmsPercentualDiferimento
            // 
            this.DevolucaoMaterialIcmsPercentualDiferimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsPercentualDiferimento.DataPropertyName = "DevolucaoMaterialIcmsPercentualDiferimento";
            this.DevolucaoMaterialIcmsPercentualDiferimento.HeaderText = "Devolução Material Icms Percentual Diferimento";
            this.DevolucaoMaterialIcmsPercentualDiferimento.Name = "DevolucaoMaterialIcmsPercentualDiferimento";
            this.DevolucaoMaterialIcmsPercentualDiferimento.ReadOnly = true;
            this.DevolucaoMaterialIcmsPercentualDiferimento.Visible = false;
            // 
            // DevolucaoMaterialIcmsObservacaoDiferimento
            // 
            this.DevolucaoMaterialIcmsObservacaoDiferimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIcmsObservacaoDiferimento.DataPropertyName = "DevolucaoMaterialIcmsObservacaoDiferimento";
            this.DevolucaoMaterialIcmsObservacaoDiferimento.HeaderText = "Devolução Material Icms Observação Diferimento";
            this.DevolucaoMaterialIcmsObservacaoDiferimento.Name = "DevolucaoMaterialIcmsObservacaoDiferimento";
            this.DevolucaoMaterialIcmsObservacaoDiferimento.ReadOnly = true;
            this.DevolucaoMaterialIcmsObservacaoDiferimento.Visible = false;
            this.DevolucaoMaterialIcmsObservacaoDiferimento.Width = 150;
            // 
            // DevolucaoMaterialIpiIncide
            // 
            this.DevolucaoMaterialIpiIncide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIpiIncide.DataPropertyName = "DevolucaoMaterialIpiIncide";
            this.DevolucaoMaterialIpiIncide.HeaderText = "Devolução Material Ipi Incide";
            this.DevolucaoMaterialIpiIncide.Name = "DevolucaoMaterialIpiIncide";
            this.DevolucaoMaterialIpiIncide.ReadOnly = true;
            this.DevolucaoMaterialIpiIncide.Visible = false;
            this.DevolucaoMaterialIpiIncide.Width = 150;
            // 
            // DevolucaoMaterialIpiCst
            // 
            this.DevolucaoMaterialIpiCst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIpiCst.DataPropertyName = "DevolucaoMaterialIpiCst";
            this.DevolucaoMaterialIpiCst.HeaderText = "Devolução Material Ipi Cst";
            this.DevolucaoMaterialIpiCst.Name = "DevolucaoMaterialIpiCst";
            this.DevolucaoMaterialIpiCst.ReadOnly = true;
            this.DevolucaoMaterialIpiCst.Visible = false;
            this.DevolucaoMaterialIpiCst.Width = 150;
            // 
            // DevolucaoMaterialIpiModTributacao
            // 
            this.DevolucaoMaterialIpiModTributacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIpiModTributacao.DataPropertyName = "DevolucaoMaterialIpiModTributacao";
            this.DevolucaoMaterialIpiModTributacao.HeaderText = "Devolução Material Ipi Mod Tributação";
            this.DevolucaoMaterialIpiModTributacao.Name = "DevolucaoMaterialIpiModTributacao";
            this.DevolucaoMaterialIpiModTributacao.ReadOnly = true;
            this.DevolucaoMaterialIpiModTributacao.Visible = false;
            this.DevolucaoMaterialIpiModTributacao.Width = 70;
            // 
            // DevolucaoMaterialIpiCodEnquadramento
            // 
            this.DevolucaoMaterialIpiCodEnquadramento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIpiCodEnquadramento.DataPropertyName = "DevolucaoMaterialIpiCodEnquadramento";
            this.DevolucaoMaterialIpiCodEnquadramento.HeaderText = "Devolução Material Ipi Cod Enquadramento";
            this.DevolucaoMaterialIpiCodEnquadramento.Name = "DevolucaoMaterialIpiCodEnquadramento";
            this.DevolucaoMaterialIpiCodEnquadramento.ReadOnly = true;
            this.DevolucaoMaterialIpiCodEnquadramento.Visible = false;
            this.DevolucaoMaterialIpiCodEnquadramento.Width = 150;
            // 
            // DevolucaoMaterialIpiAliquota
            // 
            this.DevolucaoMaterialIpiAliquota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialIpiAliquota.DataPropertyName = "DevolucaoMaterialIpiAliquota";
            this.DevolucaoMaterialIpiAliquota.HeaderText = "Devolução Material Ipi Aliquota";
            this.DevolucaoMaterialIpiAliquota.Name = "DevolucaoMaterialIpiAliquota";
            this.DevolucaoMaterialIpiAliquota.ReadOnly = true;
            this.DevolucaoMaterialIpiAliquota.Visible = false;
            // 
            // DevolucaoMaterialPisIncide
            // 
            this.DevolucaoMaterialPisIncide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialPisIncide.DataPropertyName = "DevolucaoMaterialPisIncide";
            this.DevolucaoMaterialPisIncide.HeaderText = "Devolução Material Pis Incide";
            this.DevolucaoMaterialPisIncide.Name = "DevolucaoMaterialPisIncide";
            this.DevolucaoMaterialPisIncide.ReadOnly = true;
            this.DevolucaoMaterialPisIncide.Visible = false;
            this.DevolucaoMaterialPisIncide.Width = 150;
            // 
            // DevolucaoMaterialPisCst
            // 
            this.DevolucaoMaterialPisCst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialPisCst.DataPropertyName = "DevolucaoMaterialPisCst";
            this.DevolucaoMaterialPisCst.HeaderText = "Devolução Material Pis Cst";
            this.DevolucaoMaterialPisCst.Name = "DevolucaoMaterialPisCst";
            this.DevolucaoMaterialPisCst.ReadOnly = true;
            this.DevolucaoMaterialPisCst.Visible = false;
            this.DevolucaoMaterialPisCst.Width = 150;
            // 
            // DevolucaoMaterialPisModTributacao
            // 
            this.DevolucaoMaterialPisModTributacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialPisModTributacao.DataPropertyName = "DevolucaoMaterialPisModTributacao";
            this.DevolucaoMaterialPisModTributacao.HeaderText = "Devolução Material Pis Mod Tributação";
            this.DevolucaoMaterialPisModTributacao.Name = "DevolucaoMaterialPisModTributacao";
            this.DevolucaoMaterialPisModTributacao.ReadOnly = true;
            this.DevolucaoMaterialPisModTributacao.Visible = false;
            this.DevolucaoMaterialPisModTributacao.Width = 70;
            // 
            // DevolucaoMaterialPisAliquota
            // 
            this.DevolucaoMaterialPisAliquota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialPisAliquota.DataPropertyName = "DevolucaoMaterialPisAliquota";
            this.DevolucaoMaterialPisAliquota.HeaderText = "Devolução Material Pis Aliquota";
            this.DevolucaoMaterialPisAliquota.Name = "DevolucaoMaterialPisAliquota";
            this.DevolucaoMaterialPisAliquota.ReadOnly = true;
            this.DevolucaoMaterialPisAliquota.Visible = false;
            // 
            // DevolucaoMaterialPisImpostoRetido
            // 
            this.DevolucaoMaterialPisImpostoRetido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialPisImpostoRetido.DataPropertyName = "DevolucaoMaterialPisImpostoRetido";
            this.DevolucaoMaterialPisImpostoRetido.HeaderText = "Devolução Material Pis Imposto Retido";
            this.DevolucaoMaterialPisImpostoRetido.Name = "DevolucaoMaterialPisImpostoRetido";
            this.DevolucaoMaterialPisImpostoRetido.ReadOnly = true;
            this.DevolucaoMaterialPisImpostoRetido.Visible = false;
            this.DevolucaoMaterialPisImpostoRetido.Width = 70;
            // 
            // DevolucaoMaterialCofinsIncide
            // 
            this.DevolucaoMaterialCofinsIncide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialCofinsIncide.DataPropertyName = "DevolucaoMaterialCofinsIncide";
            this.DevolucaoMaterialCofinsIncide.HeaderText = "Devolução Material Cofins Incide";
            this.DevolucaoMaterialCofinsIncide.Name = "DevolucaoMaterialCofinsIncide";
            this.DevolucaoMaterialCofinsIncide.ReadOnly = true;
            this.DevolucaoMaterialCofinsIncide.Visible = false;
            this.DevolucaoMaterialCofinsIncide.Width = 150;
            // 
            // DevolucaoMaterialCofinsCst
            // 
            this.DevolucaoMaterialCofinsCst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialCofinsCst.DataPropertyName = "DevolucaoMaterialCofinsCst";
            this.DevolucaoMaterialCofinsCst.HeaderText = "Devolução Material Cofins Cst";
            this.DevolucaoMaterialCofinsCst.Name = "DevolucaoMaterialCofinsCst";
            this.DevolucaoMaterialCofinsCst.ReadOnly = true;
            this.DevolucaoMaterialCofinsCst.Visible = false;
            this.DevolucaoMaterialCofinsCst.Width = 150;
            // 
            // DevolucaoMaterialCofinsModTributacao
            // 
            this.DevolucaoMaterialCofinsModTributacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialCofinsModTributacao.DataPropertyName = "DevolucaoMaterialCofinsModTributacao";
            this.DevolucaoMaterialCofinsModTributacao.HeaderText = "Devolução Material Cofins Mod Tributação";
            this.DevolucaoMaterialCofinsModTributacao.Name = "DevolucaoMaterialCofinsModTributacao";
            this.DevolucaoMaterialCofinsModTributacao.ReadOnly = true;
            this.DevolucaoMaterialCofinsModTributacao.Visible = false;
            this.DevolucaoMaterialCofinsModTributacao.Width = 70;
            // 
            // DevolucaoMaterialCofinsAliquota
            // 
            this.DevolucaoMaterialCofinsAliquota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialCofinsAliquota.DataPropertyName = "DevolucaoMaterialCofinsAliquota";
            this.DevolucaoMaterialCofinsAliquota.HeaderText = "Devolução Material Cofins Aliquota";
            this.DevolucaoMaterialCofinsAliquota.Name = "DevolucaoMaterialCofinsAliquota";
            this.DevolucaoMaterialCofinsAliquota.ReadOnly = true;
            this.DevolucaoMaterialCofinsAliquota.Visible = false;
            // 
            // DevolucaoMaterialCofinsImpostoRetido
            // 
            this.DevolucaoMaterialCofinsImpostoRetido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialCofinsImpostoRetido.DataPropertyName = "DevolucaoMaterialCofinsImpostoRetido";
            this.DevolucaoMaterialCofinsImpostoRetido.HeaderText = "Devolução Material Cofins Imposto Retido";
            this.DevolucaoMaterialCofinsImpostoRetido.Name = "DevolucaoMaterialCofinsImpostoRetido";
            this.DevolucaoMaterialCofinsImpostoRetido.ReadOnly = true;
            this.DevolucaoMaterialCofinsImpostoRetido.Visible = false;
            this.DevolucaoMaterialCofinsImpostoRetido.Width = 70;
            // 
            // CadOperacaoCompletaListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(582, 336);
            this.Name = "CadOperacaoCompletaListForm";
            this.Text = "Operações Completas";
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CfopColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CfopForaEstadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NaturezaOperacaoColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ValidaPrecosColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ConsumidorFinalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresencaConsumidorColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GerarContasReceberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponsavelFreteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsIncideColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IcmsPartilhaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IcmsSomaFreteBcColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsCstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsAliquotaCreditoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsModDetBcColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IcmsReducaoBcColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualReducaoBcColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualBcOperacaoPropriaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsStColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsModDetBcStColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualReducaoBcStColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsMvaStColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualDiferimentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsObservacaoDiferimentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiIncideColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiCstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiModTributacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiCodEnquadramentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiAliquotaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisIncideColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisCstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisModTributacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisAliquotaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PisImpostoRetidoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsIncideColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsCstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsModTributacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsAliquotaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CofinsImpostoRetidoColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EntregaFuturaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntregaFuturaCfopRemessaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntregaFuturaCfopRemessaForaEstadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntregaFuturaNaturezaOperacaoRemessaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCfopColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCfopForaEstadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsIncideColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialIcmsPartilhaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialIcmsSomaFreteBcColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsCstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsAliquotaCreditoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsModDetBcColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialIcmsReducaoBcColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsPercentualReducaoBcColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsPercentualBcOperacaoPropriaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsStColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsModDetBcStColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsPercentualReducaoBcStColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsMvaStColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsPercentualDiferimentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsObservacaoDiferimentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiIncideColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiCstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiModTributacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiCodEnquadramentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiAliquotaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialPisIncideColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialPisCstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialPisModTributacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialPisAliquotaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialPisImpostoRetidoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCofinsIncideColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCofinsCstColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCofinsModTributacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCofinsAliquotaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialCofinsImpostoRetidoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cfop;
        private System.Windows.Forms.DataGridViewTextBoxColumn CfopForaEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NaturezaOperacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ValidaPrecos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ConsumidorFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresencaConsumidor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GerarContasReceber;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsIncide;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IcmsPartilha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IcmsSomaFreteBc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsAliquotaCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsModDetBc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IcmsReducaoBc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualReducaoBc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualBcOperacaoPropria;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsModDetBcSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualReducaoBcSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsMvaSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualDiferimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsObservacaoDiferimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiIncide;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiModTributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiCodEnquadramento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiAliquota;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisIncide;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisModTributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisAliquota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PisImpostoRetido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsIncide;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsModTributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsAliquota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CofinsImpostoRetido;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EntregaFutura;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntregaFuturaCfopRemessa;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntregaFuturaCfopRemessaForaEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntregaFuturaNaturezaOperacaoRemessa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCfop;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCfopForaEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsIncide;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialIcmsPartilha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialIcmsSomaFreteBc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsAliquotaCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsModDetBc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialIcmsReducaoBc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsPercentualReducaoBc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsPercentualBcOperacaoPropria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsModDetBcSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsPercentualReducaoBcSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsMvaSt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsPercentualDiferimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIcmsObservacaoDiferimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiIncide;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiModTributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiCodEnquadramento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialIpiAliquota;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialPisIncide;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialPisCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialPisModTributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialPisAliquota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialPisImpostoRetido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCofinsIncide;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCofinsCst;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCofinsModTributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucaoMaterialCofinsAliquota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialCofinsImpostoRetido;
    }
} 
