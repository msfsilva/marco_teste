namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadDeclaracaoImportacaoListForm 
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
            this.iwtCheckBox1 = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorMercadoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorSeguro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalDesembaracoAduaneiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataDesembaraco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdVolumes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EspecieVolumes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoLiquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CotacaoDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotalDolar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotalReais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxaSiscomex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxaAfrmm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NfGerada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NfPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtNovoButton1 = new IWTDotNetLib.IWTNovoButton(this.components);
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.iwtExcluirButton1 = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.btnEmitirNFe = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
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
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnEmitirNFe);
            this.splitContainer2.Panel2.Controls.Add(this.iwtExcluirButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtNovoButton1);
            this.splitContainer2.Size = new System.Drawing.Size(770, 62);
            this.splitContainer2.SplitterDistance = 496;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(770, 240);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtCheckBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(496, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtCheckBox1
            // 
            this.iwtCheckBox1.AutoSize = true;
            this.iwtCheckBox1.BindingField = "SomenteSemNF";
            this.iwtCheckBox1.Checked = true;
            this.iwtCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iwtCheckBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtCheckBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtCheckBox1.Location = new System.Drawing.Point(310, 22);
            this.iwtCheckBox1.Name = "iwtCheckBox1";
            this.iwtCheckBox1.Size = new System.Drawing.Size(156, 17);
            this.iwtCheckBox1.TabIndex = 2;
            this.iwtCheckBox1.Text = "Somente Sem Nota Gerada";
            this.iwtCheckBox1.UseVisualStyleBackColor = true;
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
            this.Numero,
            this.DataRegistro,
            this.ValorMercadoria,
            this.ValorFrete,
            this.ValorSeguro,
            this.LocalDesembaracoAduaneiro,
            this.DataDesembaraco,
            this.QtdVolumes,
            this.EspecieVolumes,
            this.PesoLiquido,
            this.PesoBruto,
            this.CotacaoDolar,
            this.ValorTotalDolar,
            this.ValorTotalReais,
            this.Fornecedor,
            this.TaxaSiscomex,
            this.TaxaAfrmm,
            this.NfGerada,
            this.NfPrincipal});
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
            this.iwtDataGridView1.Size = new System.Drawing.Size(770, 202);
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
            this.ID.Width = 70;
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 150;
            // 
            // DataRegistro
            // 
            this.DataRegistro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataRegistro.DataPropertyName = "DataRegistro";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.DataRegistro.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataRegistro.HeaderText = "Data do Registro";
            this.DataRegistro.Name = "DataRegistro";
            this.DataRegistro.ReadOnly = true;
            // 
            // ValorMercadoria
            // 
            this.ValorMercadoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorMercadoria.DataPropertyName = "ValorMercadoria";
            this.ValorMercadoria.HeaderText = "Valor da Mercadoria";
            this.ValorMercadoria.Name = "ValorMercadoria";
            this.ValorMercadoria.ReadOnly = true;
            // 
            // ValorFrete
            // 
            this.ValorFrete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorFrete.DataPropertyName = "ValorFrete";
            this.ValorFrete.HeaderText = "Valor do Frete";
            this.ValorFrete.Name = "ValorFrete";
            this.ValorFrete.ReadOnly = true;
            // 
            // ValorSeguro
            // 
            this.ValorSeguro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorSeguro.DataPropertyName = "ValorSeguro";
            this.ValorSeguro.HeaderText = "Valor do Seguro";
            this.ValorSeguro.Name = "ValorSeguro";
            this.ValorSeguro.ReadOnly = true;
            // 
            // LocalDesembaracoAduaneiro
            // 
            this.LocalDesembaracoAduaneiro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LocalDesembaracoAduaneiro.DataPropertyName = "LocalDesembaracoAduaneiro";
            this.LocalDesembaracoAduaneiro.HeaderText = "Local do Desembaraço Aduaneiro";
            this.LocalDesembaracoAduaneiro.Name = "LocalDesembaracoAduaneiro";
            this.LocalDesembaracoAduaneiro.ReadOnly = true;
            this.LocalDesembaracoAduaneiro.Width = 150;
            // 
            // DataDesembaraco
            // 
            this.DataDesembaraco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataDesembaraco.DataPropertyName = "DataDesembaraco";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.DataDesembaraco.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataDesembaraco.HeaderText = "Data do Desembaraço";
            this.DataDesembaraco.Name = "DataDesembaraco";
            this.DataDesembaraco.ReadOnly = true;
            // 
            // QtdVolumes
            // 
            this.QtdVolumes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QtdVolumes.DataPropertyName = "QtdVolumes";
            this.QtdVolumes.HeaderText = "Quantidade de Volumes";
            this.QtdVolumes.Name = "QtdVolumes";
            this.QtdVolumes.ReadOnly = true;
            this.QtdVolumes.Width = 70;
            // 
            // EspecieVolumes
            // 
            this.EspecieVolumes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EspecieVolumes.DataPropertyName = "EspecieVolumes";
            this.EspecieVolumes.HeaderText = "Espécie dos Volumes";
            this.EspecieVolumes.Name = "EspecieVolumes";
            this.EspecieVolumes.ReadOnly = true;
            this.EspecieVolumes.Width = 150;
            // 
            // PesoLiquido
            // 
            this.PesoLiquido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PesoLiquido.DataPropertyName = "PesoLiquido";
            this.PesoLiquido.HeaderText = "Peso Líquido";
            this.PesoLiquido.Name = "PesoLiquido";
            this.PesoLiquido.ReadOnly = true;
            // 
            // PesoBruto
            // 
            this.PesoBruto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PesoBruto.DataPropertyName = "PesoBruto";
            this.PesoBruto.HeaderText = "Peso Bruto";
            this.PesoBruto.Name = "PesoBruto";
            this.PesoBruto.ReadOnly = true;
            // 
            // CotacaoDolar
            // 
            this.CotacaoDolar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CotacaoDolar.DataPropertyName = "CotacaoDolar";
            this.CotacaoDolar.HeaderText = "Cotação do Dólar";
            this.CotacaoDolar.Name = "CotacaoDolar";
            this.CotacaoDolar.ReadOnly = true;
            // 
            // ValorTotalDolar
            // 
            this.ValorTotalDolar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorTotalDolar.DataPropertyName = "ValorTotalDolar";
            this.ValorTotalDolar.HeaderText = "Valor Total em Dólar";
            this.ValorTotalDolar.Name = "ValorTotalDolar";
            this.ValorTotalDolar.ReadOnly = true;
            // 
            // ValorTotalReais
            // 
            this.ValorTotalReais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorTotalReais.DataPropertyName = "ValorTotalReais";
            this.ValorTotalReais.HeaderText = "Valor Total em Reais";
            this.ValorTotalReais.Name = "ValorTotalReais";
            this.ValorTotalReais.ReadOnly = true;
            this.ValorTotalReais.Visible = false;
            // 
            // Fornecedor
            // 
            this.Fornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fornecedor.DataPropertyName = "Fornecedor";
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.ReadOnly = true;
            this.Fornecedor.Width = 150;
            // 
            // TaxaSiscomex
            // 
            this.TaxaSiscomex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaxaSiscomex.DataPropertyName = "TaxaSiscomex";
            this.TaxaSiscomex.HeaderText = "Taxa Siscomex";
            this.TaxaSiscomex.Name = "TaxaSiscomex";
            this.TaxaSiscomex.ReadOnly = true;
            this.TaxaSiscomex.Visible = false;
            // 
            // TaxaAfrmm
            // 
            this.TaxaAfrmm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaxaAfrmm.DataPropertyName = "TaxaAfrmm";
            this.TaxaAfrmm.HeaderText = "Taxa AFRMM";
            this.TaxaAfrmm.Name = "TaxaAfrmm";
            this.TaxaAfrmm.ReadOnly = true;
            this.TaxaAfrmm.Visible = false;
            // 
            // NfGerada
            // 
            this.NfGerada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NfGerada.DataPropertyName = "NfGerada";
            this.NfGerada.HeaderText = "Nota Fiscal Gerada";
            this.NfGerada.Name = "NfGerada";
            this.NfGerada.ReadOnly = true;
            this.NfGerada.Visible = false;
            this.NfGerada.Width = 70;
            // 
            // NfPrincipal
            // 
            this.NfPrincipal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NfPrincipal.DataPropertyName = "NotaFiscalTela";
            this.NfPrincipal.HeaderText = "Nota Fiscal";
            this.NfPrincipal.Name = "NfPrincipal";
            this.NfPrincipal.ReadOnly = true;
            this.NfPrincipal.Width = 150;
            // 
            // iwtNovoButton1
            // 
            this.iwtNovoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtNovoButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNovoButton1.Location = new System.Drawing.Point(21, 5);
            this.iwtNovoButton1.Name = "iwtNovoButton1";
            this.iwtNovoButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtNovoButton1.TabIndex = 0;
            this.iwtNovoButton1.Text = "Novo";
            this.iwtNovoButton1.UseVisualStyleBackColor = true;
            // 
            // iwtEditarButton1
            // 
            this.iwtEditarButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtEditarButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtEditarButton1.Location = new System.Drawing.Point(102, 5);
            this.iwtEditarButton1.Name = "iwtEditarButton1";
            this.iwtEditarButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtEditarButton1.TabIndex = 1;
            this.iwtEditarButton1.Text = "Editar";
            this.iwtEditarButton1.UseVisualStyleBackColor = true;
            // 
            // iwtExcluirButton1
            // 
            this.iwtExcluirButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtExcluirButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtExcluirButton1.Location = new System.Drawing.Point(183, 5);
            this.iwtExcluirButton1.Name = "iwtExcluirButton1";
            this.iwtExcluirButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtExcluirButton1.TabIndex = 2;
            this.iwtExcluirButton1.Text = "Excluir";
            this.iwtExcluirButton1.UseVisualStyleBackColor = true;
            // 
            // btnEmitirNFe
            // 
            this.btnEmitirNFe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmitirNFe.LiberadoQuandoCadastroUtilizado = false;
            this.btnEmitirNFe.Location = new System.Drawing.Point(21, 34);
            this.btnEmitirNFe.Name = "btnEmitirNFe";
            this.btnEmitirNFe.Size = new System.Drawing.Size(237, 23);
            this.btnEmitirNFe.TabIndex = 3;
            this.btnEmitirNFe.Text = "Emitir Nota Fiscal";
            this.btnEmitirNFe.UseVisualStyleBackColor = true;
            this.btnEmitirNFe.Click += new System.EventHandler(this.btnEmitirNFe_Click);
            // 
            // CadDeclaracaoImportacaoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(770, 336);
            this.Name = "CadDeclaracaoImportacaoListForm";
            this.Text = "Declarações de Importação";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRegistroColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMercadoriaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorFreteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorSeguroColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalDesembaracoAduaneiroColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataDesembaracoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdVolumesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EspecieVolumesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoLiquidoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoBrutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotacaoDolarColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotalDolarColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotalReaisColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FornecedorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxaSiscomexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxaAfrmmColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NfGeradaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NfPrincipalColumn;
        private IWTDotNetLib.IWTCheckBox iwtCheckBox1;
        private IWTDotNetLib.IWTExcluirButton iwtExcluirButton1;
        private IWTDotNetLib.IWTEditarButton iwtEditarButton1;
        private IWTDotNetLib.IWTNovoButton iwtNovoButton1;
        private IWTDotNetLib.IWTButton btnEmitirNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMercadoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorSeguro;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalDesembaracoAduaneiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataDesembaraco;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdVolumes;
        private System.Windows.Forms.DataGridViewTextBoxColumn EspecieVolumes;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoLiquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CotacaoDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotalDolar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotalReais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxaSiscomex;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxaAfrmm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NfGerada;
        private System.Windows.Forms.DataGridViewTextBoxColumn NfPrincipal;
    }
} 
