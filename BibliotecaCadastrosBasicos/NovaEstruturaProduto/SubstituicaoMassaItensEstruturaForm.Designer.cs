namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    partial class SubstituicaoMassaItensEstruturaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubstituicaoMassaItensEstruturaForm));
            this.btnConfirmar = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.rdbDocumento = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbRecurso = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbAcabamento = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensOrigem = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensSubstituto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.txtJustificativa = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.LiberadoQuandoCadastroUtilizado = false;
            this.btnConfirmar.Location = new System.Drawing.Point(542, 332);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(12, 332);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel1.ForeColor = System.Drawing.Color.Red;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 9);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(605, 99);
            this.iwtLabel1.TabIndex = 2;
            this.iwtLabel1.Text = resources.GetString("iwtLabel1.Text");
            this.iwtLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbDocumento
            // 
            this.rdbDocumento.AutoSize = true;
            this.rdbDocumento.BindingField = null;
            this.rdbDocumento.Checked = true;
            this.rdbDocumento.LiberadoQuandoCadastroUtilizado = false;
            this.rdbDocumento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbDocumento.Location = new System.Drawing.Point(138, 111);
            this.rdbDocumento.Name = "rdbDocumento";
            this.rdbDocumento.Size = new System.Drawing.Size(80, 17);
            this.rdbDocumento.TabIndex = 5;
            this.rdbDocumento.TabStop = true;
            this.rdbDocumento.Text = "Documento";
            this.rdbDocumento.UseVisualStyleBackColor = true;
            this.rdbDocumento.CheckedChanged += new System.EventHandler(this.rdbDocumento_CheckedChanged);
            // 
            // rdbRecurso
            // 
            this.rdbRecurso.AutoSize = true;
            this.rdbRecurso.BindingField = null;
            this.rdbRecurso.LiberadoQuandoCadastroUtilizado = false;
            this.rdbRecurso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbRecurso.Location = new System.Drawing.Point(247, 111);
            this.rdbRecurso.Name = "rdbRecurso";
            this.rdbRecurso.Size = new System.Drawing.Size(65, 17);
            this.rdbRecurso.TabIndex = 6;
            this.rdbRecurso.Text = "Recurso";
            this.rdbRecurso.UseVisualStyleBackColor = true;
            this.rdbRecurso.CheckedChanged += new System.EventHandler(this.rdbRecurso_CheckedChanged);
            // 
            // rdbAcabamento
            // 
            this.rdbAcabamento.AutoSize = true;
            this.rdbAcabamento.BindingField = null;
            this.rdbAcabamento.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAcabamento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAcabamento.Location = new System.Drawing.Point(356, 111);
            this.rdbAcabamento.Name = "rdbAcabamento";
            this.rdbAcabamento.Size = new System.Drawing.Size(85, 17);
            this.rdbAcabamento.TabIndex = 7;
            this.rdbAcabamento.Text = "Acabamento";
            this.rdbAcabamento.UseVisualStyleBackColor = true;
            this.rdbAcabamento.CheckedChanged += new System.EventHandler(this.rdbAcabamento_CheckedChanged);
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(22, 190);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(108, 13);
            this.iwtLabel2.TabIndex = 8;
            this.iwtLabel2.Text = "Item a ser substituído";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(55, 228);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(75, 13);
            this.iwtLabel3.TabIndex = 9;
            this.iwtLabel3.Text = "Item substituto";
            // 
            // ensOrigem
            // 
            this.ensOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensOrigem.BindingField = null;
            this.ensOrigem.ColunasDropdown = null;
            this.ensOrigem.DesabilitarAutoCompletar = false;
            this.ensOrigem.DesabilitarChekBox = true;
            this.ensOrigem.DesabilitarLupa = false;
            this.ensOrigem.DesabilitarSeta = false;
            this.ensOrigem.EntidadeSelecionada = null;
            this.ensOrigem.FormSelecao = null;
            this.ensOrigem.LiberadoQuandoCadastroUtilizado = false;
            this.ensOrigem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensOrigem.Location = new System.Drawing.Point(138, 184);
            this.ensOrigem.ModoVisualizacaoGrid = null;
            this.ensOrigem.Name = "ensOrigem";
            this.ensOrigem.ParametroBuscaGuiada = null;
            this.ensOrigem.ParametrosBuscaObrigatorios = null;
            this.ensOrigem.Size = new System.Drawing.Size(479, 23);
            this.ensOrigem.TabIndex = 10;
            // 
            // ensSubstituto
            // 
            this.ensSubstituto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensSubstituto.BindingField = null;
            this.ensSubstituto.ColunasDropdown = null;
            this.ensSubstituto.DesabilitarAutoCompletar = false;
            this.ensSubstituto.DesabilitarChekBox = true;
            this.ensSubstituto.DesabilitarLupa = false;
            this.ensSubstituto.DesabilitarSeta = false;
            this.ensSubstituto.EntidadeSelecionada = null;
            this.ensSubstituto.FormSelecao = null;
            this.ensSubstituto.LiberadoQuandoCadastroUtilizado = false;
            this.ensSubstituto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensSubstituto.Location = new System.Drawing.Point(138, 222);
            this.ensSubstituto.ModoVisualizacaoGrid = null;
            this.ensSubstituto.Name = "ensSubstituto";
            this.ensSubstituto.ParametroBuscaGuiada = null;
            this.ensSubstituto.ParametrosBuscaObrigatorios = null;
            this.ensSubstituto.Size = new System.Drawing.Size(479, 23);
            this.ensSubstituto.TabIndex = 11;
            // 
            // txtJustificativa
            // 
            this.txtJustificativa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJustificativa.BindingField = null;
            this.txtJustificativa.DebugMode = false;
            this.txtJustificativa.LiberadoQuandoCadastroUtilizado = false;
            this.txtJustificativa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtJustificativa.Location = new System.Drawing.Point(138, 294);
            this.txtJustificativa.ModoBarcode = false;
            this.txtJustificativa.ModoBusca = false;
            this.txtJustificativa.Name = "txtJustificativa";
            this.txtJustificativa.NaoLimparDepoisBarcode = false;
            this.txtJustificativa.Size = new System.Drawing.Size(440, 20);
            this.txtJustificativa.TabIndex = 12;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(68, 297);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel4.TabIndex = 13;
            this.iwtLabel4.Text = "Justificativa";
            // 
            // SubstituicaoMassaItensEstruturaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(629, 367);
            this.Controls.Add(this.iwtLabel4);
            this.Controls.Add(this.txtJustificativa);
            this.Controls.Add(this.ensSubstituto);
            this.Controls.Add(this.ensOrigem);
            this.Controls.Add(this.iwtLabel3);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.rdbAcabamento);
            this.Controls.Add(this.rdbRecurso);
            this.Controls.Add(this.rdbDocumento);
            this.Controls.Add(this.iwtLabel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "SubstituicaoMassaItensEstruturaForm";
            this.Text = "Substituição em Massa de Itens da Estrutura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTButton btnConfirmar;
        private IWTDotNetLib.IWTButton btnCancelar;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTRadioButton rdbDocumento;
        private IWTDotNetLib.IWTRadioButton rdbRecurso;
        private IWTDotNetLib.IWTRadioButton rdbAcabamento;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTEntitySelection ensOrigem;
        private IWTDotNetLib.IWTEntitySelection ensSubstituto;
        private IWTDotNetLib.IWTTextBox txtJustificativa;
        private IWTDotNetLib.IWTLabel iwtLabel4;
    }
}