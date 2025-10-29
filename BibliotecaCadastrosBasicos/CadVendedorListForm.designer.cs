namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadVendedorListForm 
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
            this.iwtDefaultListButtons1 = new IWTDotNetLib.IWTDefaultListButtons();
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazaoSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InscricaoEstadual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InscricaoMunicipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnderecoNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnderecoComplemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvioEmail = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CentroCustoLucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.splitContainer2.Panel2.Controls.Add(this.iwtDefaultListButtons1);
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
            // iwtDefaultListButtons1
            // 
            this.iwtDefaultListButtons1.Location = new System.Drawing.Point(0, 0);
            this.iwtDefaultListButtons1.Name = "iwtDefaultListButtons1";
            this.iwtDefaultListButtons1.Size = new System.Drawing.Size(270, 62);
            this.iwtDefaultListButtons1.TabIndex = 0;
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
            this.TipoPessoa,
            this.RazaoSocial,
            this.Cnpj,
            this.InscricaoEstadual,
            this.InscricaoMunicipal,
            this.Endereco,
            this.EnderecoNumero,
            this.EnderecoComplemento,
            this.Bairro,
            this.Cep,
            this.Fone1,
            this.Fone2,
            this.Cidade,
            this.Email,
            this.EnvioEmail,
            this.Banco,
            this.Agencia,
            this.Conta,
            this.ContaBancaria,
            this.CentroCustoLucro,
            this.Comissao});
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
            this.ID.Width = 70;
            // 
            // TipoPessoa
            // 
            this.TipoPessoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TipoPessoa.DataPropertyName = "TipoPessoa";
            this.TipoPessoa.HeaderText = "Tipo";
            this.TipoPessoa.Name = "TipoPessoa";
            this.TipoPessoa.ReadOnly = true;
            this.TipoPessoa.Visible = false;
            this.TipoPessoa.Width = 150;
            // 
            // RazaoSocial
            // 
            this.RazaoSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RazaoSocial.DataPropertyName = "RazaoSocial";
            this.RazaoSocial.HeaderText = "Razão Social";
            this.RazaoSocial.Name = "RazaoSocial";
            this.RazaoSocial.ReadOnly = true;
            this.RazaoSocial.Width = 150;
            // 
            // Cnpj
            // 
            this.Cnpj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cnpj.DataPropertyName = "Cnpj";
            this.Cnpj.HeaderText = "CNPJ";
            this.Cnpj.Name = "Cnpj";
            this.Cnpj.ReadOnly = true;
            this.Cnpj.Width = 150;
            // 
            // InscricaoEstadual
            // 
            this.InscricaoEstadual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InscricaoEstadual.DataPropertyName = "InscricaoEstadual";
            this.InscricaoEstadual.HeaderText = "Inscrição Estadual";
            this.InscricaoEstadual.Name = "InscricaoEstadual";
            this.InscricaoEstadual.ReadOnly = true;
            this.InscricaoEstadual.Visible = false;
            this.InscricaoEstadual.Width = 150;
            // 
            // InscricaoMunicipal
            // 
            this.InscricaoMunicipal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InscricaoMunicipal.DataPropertyName = "InscricaoMunicipal";
            this.InscricaoMunicipal.HeaderText = "Inscrição Municipal";
            this.InscricaoMunicipal.Name = "InscricaoMunicipal";
            this.InscricaoMunicipal.ReadOnly = true;
            this.InscricaoMunicipal.Visible = false;
            this.InscricaoMunicipal.Width = 150;
            // 
            // Endereco
            // 
            this.Endereco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Endereco.DataPropertyName = "Endereco";
            this.Endereco.HeaderText = "Endereço";
            this.Endereco.Name = "Endereco";
            this.Endereco.ReadOnly = true;
            this.Endereco.Visible = false;
            this.Endereco.Width = 150;
            // 
            // EnderecoNumero
            // 
            this.EnderecoNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EnderecoNumero.DataPropertyName = "EnderecoNumero";
            this.EnderecoNumero.HeaderText = "Número";
            this.EnderecoNumero.Name = "EnderecoNumero";
            this.EnderecoNumero.ReadOnly = true;
            this.EnderecoNumero.Visible = false;
            this.EnderecoNumero.Width = 150;
            // 
            // EnderecoComplemento
            // 
            this.EnderecoComplemento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EnderecoComplemento.DataPropertyName = "EnderecoComplemento";
            this.EnderecoComplemento.HeaderText = "Complemento";
            this.EnderecoComplemento.Name = "EnderecoComplemento";
            this.EnderecoComplemento.ReadOnly = true;
            this.EnderecoComplemento.Visible = false;
            this.EnderecoComplemento.Width = 150;
            // 
            // Bairro
            // 
            this.Bairro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Bairro.DataPropertyName = "Bairro";
            this.Bairro.HeaderText = "Bairro";
            this.Bairro.Name = "Bairro";
            this.Bairro.ReadOnly = true;
            this.Bairro.Visible = false;
            this.Bairro.Width = 150;
            // 
            // Cep
            // 
            this.Cep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cep.DataPropertyName = "Cep";
            this.Cep.HeaderText = "Cep";
            this.Cep.Name = "Cep";
            this.Cep.ReadOnly = true;
            this.Cep.Visible = false;
            this.Cep.Width = 150;
            // 
            // Fone1
            // 
            this.Fone1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fone1.DataPropertyName = "Fone1";
            this.Fone1.HeaderText = "Fone1";
            this.Fone1.Name = "Fone1";
            this.Fone1.ReadOnly = true;
            this.Fone1.Width = 150;
            // 
            // Fone2
            // 
            this.Fone2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fone2.DataPropertyName = "Fone2";
            this.Fone2.HeaderText = "Fone2";
            this.Fone2.Name = "Fone2";
            this.Fone2.ReadOnly = true;
            this.Fone2.Visible = false;
            this.Fone2.Width = 150;
            // 
            // Cidade
            // 
            this.Cidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cidade.DataPropertyName = "Cidade";
            this.Cidade.HeaderText = "Cidade";
            this.Cidade.Name = "Cidade";
            this.Cidade.ReadOnly = true;
            this.Cidade.Width = 150;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // EnvioEmail
            // 
            this.EnvioEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EnvioEmail.DataPropertyName = "EnvioEmail";
            this.EnvioEmail.HeaderText = "Envio de Email";
            this.EnvioEmail.Name = "EnvioEmail";
            this.EnvioEmail.ReadOnly = true;
            this.EnvioEmail.Visible = false;
            this.EnvioEmail.Width = 70;
            // 
            // Banco
            // 
            this.Banco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Banco.DataPropertyName = "Banco";
            this.Banco.HeaderText = "Banco";
            this.Banco.Name = "Banco";
            this.Banco.ReadOnly = true;
            this.Banco.Visible = false;
            this.Banco.Width = 150;
            // 
            // Agencia
            // 
            this.Agencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Agencia.DataPropertyName = "Agencia";
            this.Agencia.HeaderText = "Agência";
            this.Agencia.Name = "Agencia";
            this.Agencia.ReadOnly = true;
            this.Agencia.Visible = false;
            this.Agencia.Width = 150;
            // 
            // Conta
            // 
            this.Conta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Conta.DataPropertyName = "Conta";
            this.Conta.HeaderText = "Conta";
            this.Conta.Name = "Conta";
            this.Conta.ReadOnly = true;
            this.Conta.Visible = false;
            this.Conta.Width = 150;
            // 
            // ContaBancaria
            // 
            this.ContaBancaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ContaBancaria.DataPropertyName = "ContaBancaria";
            this.ContaBancaria.HeaderText = "Conta Bancária Padrão";
            this.ContaBancaria.Name = "ContaBancaria";
            this.ContaBancaria.ReadOnly = true;
            this.ContaBancaria.Visible = false;
            this.ContaBancaria.Width = 150;
            // 
            // CentroCustoLucro
            // 
            this.CentroCustoLucro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CentroCustoLucro.DataPropertyName = "CentroCustoLucro";
            this.CentroCustoLucro.HeaderText = "Centro Custo Padrão";
            this.CentroCustoLucro.Name = "CentroCustoLucro";
            this.CentroCustoLucro.ReadOnly = true;
            this.CentroCustoLucro.Visible = false;
            this.CentroCustoLucro.Width = 150;
            // 
            // Comissao
            // 
            this.Comissao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Comissao.DataPropertyName = "Comissao";
            this.Comissao.HeaderText = "% Comissão";
            this.Comissao.Name = "Comissao";
            this.Comissao.ReadOnly = true;
            this.Comissao.Visible = false;
            // 
            // CadVendedorListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(582, 336);
            this.Name = "CadVendedorListForm";
            this.Text = "Vendedores";
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
        private IWTDotNetLib.IWTDefaultListButtons iwtDefaultListButtons1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazaoSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn InscricaoEstadual;
        private System.Windows.Forms.DataGridViewTextBoxColumn InscricaoMunicipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnderecoNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnderecoComplemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnvioEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CentroCustoLucro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comissao;
    }
} 
