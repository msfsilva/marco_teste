namespace BibliotecaCadastrosBasicos
{
    partial class CadNcmForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.cmbCST = new IWTDotNetLib.IWTComboBox(this.components);
            this.cmbModalidadeTributacao = new IWTDotNetLib.IWTComboBox(this.components);
            this.txtIPICodEnquadramento = new IWTDotNetLib.IWTTextBox(this.components);
            this.nudAliquota = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.grbIPI = new System.Windows.Forms.GroupBox();
            this.grbII = new System.Windows.Forms.GroupBox();
            this.nudAliquotaII = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.iwtTextBox3 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvAliquotasFCP = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcluir = new IWTDotNetLib.IWTButton(this.components);
            this.btnEditar = new IWTDotNetLib.IWTButton(this.components);
            this.btnNovo = new IWTDotNetLib.IWTButton(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvBeneficios = new IWTDotNetLib.IWTDataGridView(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cfop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBeneficioFiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBeneficioEditar = new IWTDotNetLib.IWTButton(this.components);
            this.btnBeneficioExcluir = new IWTDotNetLib.IWTButton(this.components);
            this.btnBeneficioNovo = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquota)).BeginInit();
            this.grbIPI.SuspendLayout();
            this.grbII.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquotaII)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAliquotasFCP)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficios)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(537, 499);
            this.splitContainer1.SplitterDistance = 433;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(450, 20);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(101, 9);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(40, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Código";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(86, 35);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(55, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "Descrição";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(110, 21);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(28, 13);
            this.iwtLabel3.TabIndex = 2;
            this.iwtLabel3.Text = "CST";
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(22, 45);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(116, 13);
            this.iwtLabel4.TabIndex = 3;
            this.iwtLabel4.Text = "Modalidade Tributação";
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(15, 72);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(123, 13);
            this.iwtLabel5.TabIndex = 4;
            this.iwtLabel5.Text = "IPI Cod. Enquadramento";
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(93, 97);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(45, 13);
            this.iwtLabel6.TabIndex = 5;
            this.iwtLabel6.Text = "Aliquota";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox1.BindingField = "Codigo";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(147, 6);
            this.iwtTextBox1.MaxLength = 8;
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(374, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox2.BindingField = "Descricao";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(147, 32);
            this.iwtTextBox2.MaxLength = 255;
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.ModoBusca = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.NaoLimparDepoisBarcode = false;
            this.iwtTextBox2.Size = new System.Drawing.Size(374, 20);
            this.iwtTextBox2.TabIndex = 1;
            // 
            // cmbCST
            // 
            this.cmbCST.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCST.BindingField = "";
            this.cmbCST.FormattingEnabled = true;
            this.cmbCST.LiberadoQuandoCadastroUtilizado = false;
            this.cmbCST.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbCST.Location = new System.Drawing.Point(144, 18);
            this.cmbCST.Name = "cmbCST";
            this.cmbCST.Size = new System.Drawing.Size(344, 21);
            this.cmbCST.TabIndex = 0;
            this.cmbCST.SelectedIndexChanged += new System.EventHandler(this.cmbCST_SelectedIndexChanged);
            // 
            // cmbModalidadeTributacao
            // 
            this.cmbModalidadeTributacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModalidadeTributacao.BindingField = "";
            this.cmbModalidadeTributacao.FormattingEnabled = true;
            this.cmbModalidadeTributacao.LiberadoQuandoCadastroUtilizado = false;
            this.cmbModalidadeTributacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbModalidadeTributacao.Location = new System.Drawing.Point(144, 42);
            this.cmbModalidadeTributacao.Name = "cmbModalidadeTributacao";
            this.cmbModalidadeTributacao.Size = new System.Drawing.Size(344, 21);
            this.cmbModalidadeTributacao.TabIndex = 1;
            this.cmbModalidadeTributacao.SelectedIndexChanged += new System.EventHandler(this.cmbModalidadeTributacao_SelectedIndexChanged);
            // 
            // txtIPICodEnquadramento
            // 
            this.txtIPICodEnquadramento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIPICodEnquadramento.BindingField = "IpiCodigoEnquadramento";
            this.txtIPICodEnquadramento.DebugMode = false;
            this.txtIPICodEnquadramento.LiberadoQuandoCadastroUtilizado = false;
            this.txtIPICodEnquadramento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtIPICodEnquadramento.Location = new System.Drawing.Point(144, 69);
            this.txtIPICodEnquadramento.MaxLength = 3;
            this.txtIPICodEnquadramento.ModoBarcode = false;
            this.txtIPICodEnquadramento.ModoBusca = false;
            this.txtIPICodEnquadramento.Name = "txtIPICodEnquadramento";
            this.txtIPICodEnquadramento.NaoLimparDepoisBarcode = false;
            this.txtIPICodEnquadramento.Size = new System.Drawing.Size(344, 20);
            this.txtIPICodEnquadramento.TabIndex = 2;
            // 
            // nudAliquota
            // 
            this.nudAliquota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAliquota.BindingField = "IpiAliquota";
            this.nudAliquota.DecimalPlaces = 4;
            this.nudAliquota.LiberadoQuandoCadastroUtilizado = false;
            this.nudAliquota.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudAliquota.Location = new System.Drawing.Point(144, 95);
            this.nudAliquota.Name = "nudAliquota";
            this.nudAliquota.Size = new System.Drawing.Size(344, 20);
            this.nudAliquota.TabIndex = 3;
            // 
            // grbIPI
            // 
            this.grbIPI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbIPI.Controls.Add(this.cmbCST);
            this.grbIPI.Controls.Add(this.nudAliquota);
            this.grbIPI.Controls.Add(this.iwtLabel3);
            this.grbIPI.Controls.Add(this.txtIPICodEnquadramento);
            this.grbIPI.Controls.Add(this.iwtLabel4);
            this.grbIPI.Controls.Add(this.cmbModalidadeTributacao);
            this.grbIPI.Controls.Add(this.iwtLabel5);
            this.grbIPI.Controls.Add(this.iwtLabel6);
            this.grbIPI.Location = new System.Drawing.Point(8, 160);
            this.grbIPI.Name = "grbIPI";
            this.grbIPI.Size = new System.Drawing.Size(513, 139);
            this.grbIPI.TabIndex = 4;
            this.grbIPI.TabStop = false;
            this.grbIPI.Text = "IPI";
            // 
            // grbII
            // 
            this.grbII.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbII.Controls.Add(this.nudAliquotaII);
            this.grbII.Controls.Add(this.label1);
            this.grbII.Location = new System.Drawing.Point(8, 305);
            this.grbII.Name = "grbII";
            this.grbII.Size = new System.Drawing.Size(513, 76);
            this.grbII.TabIndex = 5;
            this.grbII.TabStop = false;
            this.grbII.Text = "Impostos para Importação";
            // 
            // nudAliquotaII
            // 
            this.nudAliquotaII.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAliquotaII.BindingField = "IiAliquota";
            this.nudAliquotaII.DecimalPlaces = 4;
            this.nudAliquotaII.LiberadoQuandoCadastroUtilizado = false;
            this.nudAliquotaII.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudAliquotaII.Location = new System.Drawing.Point(183, 31);
            this.nudAliquotaII.Name = "nudAliquotaII";
            this.nudAliquotaII.Size = new System.Drawing.Size(305, 20);
            this.nudAliquotaII.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alíquota do II";
            // 
            // iwtTextBox3
            // 
            this.iwtTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox3.BindingField = "Cest";
            this.iwtTextBox3.DebugMode = false;
            this.iwtTextBox3.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox3.Location = new System.Drawing.Point(147, 74);
            this.iwtTextBox3.MaxLength = 7;
            this.iwtTextBox3.ModoBarcode = false;
            this.iwtTextBox3.ModoBusca = false;
            this.iwtTextBox3.Name = "iwtTextBox3";
            this.iwtTextBox3.NaoLimparDepoisBarcode = false;
            this.iwtTextBox3.Size = new System.Drawing.Size(374, 20);
            this.iwtTextBox3.TabIndex = 2;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(106, 77);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(35, 13);
            this.iwtLabel7.TabIndex = 5;
            this.iwtLabel7.Text = "CEST";
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
            this.tabControl1.Size = new System.Drawing.Size(537, 433);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.iwtTextBox1);
            this.tabPage1.Controls.Add(this.iwtLabel1);
            this.tabPage1.Controls.Add(this.iwtLabel2);
            this.tabPage1.Controls.Add(this.iwtTextBox3);
            this.tabPage1.Controls.Add(this.iwtTextBox2);
            this.tabPage1.Controls.Add(this.iwtLabel7);
            this.tabPage1.Controls.Add(this.grbIPI);
            this.tabPage1.Controls.Add(this.grbII);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(529, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados NCM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvAliquotasFCP);
            this.tabPage2.Controls.Add(this.btnExcluir);
            this.tabPage2.Controls.Add(this.btnEditar);
            this.tabPage2.Controls.Add(this.btnNovo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(529, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alíquotas do Fundo de combate a pobreza";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAliquotasFCP
            // 
            this.dgvAliquotasFCP.AllowUserToAddRows = false;
            this.dgvAliquotasFCP.AllowUserToDeleteRows = false;
            this.dgvAliquotasFCP.AllowUserToOrderColumns = true;
            this.dgvAliquotasFCP.AllowUserToResizeRows = false;
            this.dgvAliquotasFCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAliquotasFCP.BackgroundColor = System.Drawing.Color.White;
            this.dgvAliquotasFCP.CacheDados = null;
            this.dgvAliquotasFCP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAliquotasFCP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Estado,
            this.Aliquota});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAliquotasFCP.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAliquotasFCP.Dock = System.Windows.Forms.DockStyle.None;
            this.dgvAliquotasFCP.Location = new System.Drawing.Point(3, 35);
            this.dgvAliquotasFCP.Name = "dgvAliquotasFCP";
            this.dgvAliquotasFCP.ReadOnly = true;
            this.dgvAliquotasFCP.RowHeadersVisible = false;
            this.dgvAliquotasFCP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAliquotasFCP.Size = new System.Drawing.Size(518, 366);
            this.dgvAliquotasFCP.TabIndex = 3;
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
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 150;
            // 
            // Aliquota
            // 
            this.Aliquota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Aliquota.DataPropertyName = "Aliquota";
            this.Aliquota.HeaderText = "Alíquota (%)";
            this.Aliquota.Name = "Aliquota";
            this.Aliquota.ReadOnly = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.LiberadoQuandoCadastroUtilizado = false;
            this.btnExcluir.Location = new System.Drawing.Point(446, 6);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditar.Location = new System.Drawing.Point(365, 6);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.LiberadoQuandoCadastroUtilizado = false;
            this.btnNovo.Location = new System.Drawing.Point(284, 6);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvBeneficios);
            this.tabPage3.Controls.Add(this.btnBeneficioEditar);
            this.tabPage3.Controls.Add(this.btnBeneficioExcluir);
            this.tabPage3.Controls.Add(this.btnBeneficioNovo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(529, 407);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Benefício Fiscal";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvBeneficios
            // 
            this.dgvBeneficios.AllowUserToAddRows = false;
            this.dgvBeneficios.AllowUserToDeleteRows = false;
            this.dgvBeneficios.AllowUserToOrderColumns = true;
            this.dgvBeneficios.AllowUserToResizeRows = false;
            this.dgvBeneficios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBeneficios.BackgroundColor = System.Drawing.Color.White;
            this.dgvBeneficios.CacheDados = null;
            this.dgvBeneficios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeneficios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Cfop,
            this.dataGridViewTextBoxColumn3,
            this.CodigoBeneficioFiscal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBeneficios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBeneficios.Dock = System.Windows.Forms.DockStyle.None;
            this.dgvBeneficios.Location = new System.Drawing.Point(3, 35);
            this.dgvBeneficios.Name = "dgvBeneficios";
            this.dgvBeneficios.ReadOnly = true;
            this.dgvBeneficios.RowHeadersVisible = false;
            this.dgvBeneficios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBeneficios.Size = new System.Drawing.Size(518, 366);
            this.dgvBeneficios.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Cfop
            // 
            this.Cfop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cfop.DataPropertyName = "Cfop";
            this.Cfop.HeaderText = "CFOP";
            this.Cfop.Name = "Cfop";
            this.Cfop.ReadOnly = true;
            this.Cfop.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Estado";
            this.dataGridViewTextBoxColumn3.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // CodigoBeneficioFiscal
            // 
            this.CodigoBeneficioFiscal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodigoBeneficioFiscal.DataPropertyName = "CodigoBeneficioFiscal";
            this.CodigoBeneficioFiscal.HeaderText = "Código Beneficio Fiscal";
            this.CodigoBeneficioFiscal.Name = "CodigoBeneficioFiscal";
            this.CodigoBeneficioFiscal.ReadOnly = true;
            this.CodigoBeneficioFiscal.Width = 150;
            // 
            // btnBeneficioEditar
            // 
            this.btnBeneficioEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeneficioEditar.LiberadoQuandoCadastroUtilizado = true;
            this.btnBeneficioEditar.Location = new System.Drawing.Point(365, 6);
            this.btnBeneficioEditar.Name = "btnBeneficioEditar";
            this.btnBeneficioEditar.Size = new System.Drawing.Size(75, 23);
            this.btnBeneficioEditar.TabIndex = 2;
            this.btnBeneficioEditar.Text = "Editar";
            this.btnBeneficioEditar.UseVisualStyleBackColor = true;
            this.btnBeneficioEditar.Click += new System.EventHandler(this.btnBeneficioEditar_Click);
            // 
            // btnBeneficioExcluir
            // 
            this.btnBeneficioExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeneficioExcluir.LiberadoQuandoCadastroUtilizado = true;
            this.btnBeneficioExcluir.Location = new System.Drawing.Point(446, 6);
            this.btnBeneficioExcluir.Name = "btnBeneficioExcluir";
            this.btnBeneficioExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnBeneficioExcluir.TabIndex = 1;
            this.btnBeneficioExcluir.Text = "Excluir";
            this.btnBeneficioExcluir.UseVisualStyleBackColor = true;
            this.btnBeneficioExcluir.Click += new System.EventHandler(this.btnBeneficioExcluir_Click);
            // 
            // btnBeneficioNovo
            // 
            this.btnBeneficioNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeneficioNovo.LiberadoQuandoCadastroUtilizado = true;
            this.btnBeneficioNovo.Location = new System.Drawing.Point(284, 6);
            this.btnBeneficioNovo.Name = "btnBeneficioNovo";
            this.btnBeneficioNovo.Size = new System.Drawing.Size(75, 23);
            this.btnBeneficioNovo.TabIndex = 0;
            this.btnBeneficioNovo.Text = "Novo";
            this.btnBeneficioNovo.UseVisualStyleBackColor = true;
            this.btnBeneficioNovo.Click += new System.EventHandler(this.btnBeneficioNovo_Click);
            // 
            // CadNcmForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(537, 499);
            this.Name = "CadNcmForm";
            this.Text = "NCM";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquota)).EndInit();
            this.grbIPI.ResumeLayout(false);
            this.grbIPI.PerformLayout();
            this.grbII.ResumeLayout(false);
            this.grbII.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquotaII)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAliquotasFCP)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeneficios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTComboBox cmbModalidadeTributacao;
        private IWTDotNetLib.IWTComboBox cmbCST;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTTextBox txtIPICodEnquadramento;
        private IWTDotNetLib.IWTNumericUpDown nudAliquota;
        private System.Windows.Forms.GroupBox grbII;
        private IWTDotNetLib.IWTNumericUpDown nudAliquotaII;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbIPI;
        private IWTDotNetLib.IWTTextBox iwtTextBox3;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private IWTDotNetLib.IWTButton btnExcluir;
        private IWTDotNetLib.IWTButton btnEditar;
        private IWTDotNetLib.IWTButton btnNovo;
        private IWTDotNetLib.IWTDataGridView dgvAliquotasFCP;
        private System.Windows.Forms.TabPage tabPage3;
        private IWTDotNetLib.IWTButton btnBeneficioEditar;
        private IWTDotNetLib.IWTButton btnBeneficioExcluir;
        private IWTDotNetLib.IWTButton btnBeneficioNovo;
        private IWTDotNetLib.IWTDataGridView dgvBeneficios;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aliquota;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cfop;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBeneficioFiscal;
    }
}