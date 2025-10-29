namespace BibliotecaCadastrosBasicos
{
    partial class CadVariavelForm
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
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.cbxFamiliaCli = new IWTDotNetLib.IWTCheckBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.cmbFamiliaCliente = new IWTDotNetLib.IWTComboBox(this.components);
            this.Tipo_RetornoNumeroLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Tipo_RetornoNumero = new IWTDotNetLib.IWTRadioButton(this.components);
            this.Tipo_RetornoBooleanLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Tipo_RetornoBoolean = new IWTDotNetLib.IWTRadioButton(this.components);
            this.Tipo_RetornoTextoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Tipo_RetornoTexto = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.cmbFamiliaCliente);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.cbxFamiliaCli);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(446, 341);
            this.splitContainer1.SplitterDistance = 275;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(359, 20);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(65, 15);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(35, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Nome";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(45, 41);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(55, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "Descrição";
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(9, 68);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(91, 13);
            this.iwtLabel4.TabIndex = 3;
            this.iwtLabel4.Text = "Cliente Agrupador";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Nome";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(109, 12);
            this.iwtTextBox1.MaxLength = 255;
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(311, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.BindingField = "Descricao";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(109, 38);
            this.iwtTextBox2.MaxLength = 255;
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.NaoLimparDepoisBarcode = false;
            this.iwtTextBox2.Size = new System.Drawing.Size(311, 20);
            this.iwtTextBox2.TabIndex = 1;
            // 
            // cbxFamiliaCli
            // 
            this.cbxFamiliaCli.AutoSize = true;
            this.cbxFamiliaCli.BindingField = "PossuiFamilia";
            this.cbxFamiliaCli.LiberadoQuandoCadastroUtilizado = true;
            this.cbxFamiliaCli.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cbxFamiliaCli.Location = new System.Drawing.Point(405, 69);
            this.cbxFamiliaCli.Name = "cbxFamiliaCli";
            this.cbxFamiliaCli.Size = new System.Drawing.Size(15, 14);
            this.cbxFamiliaCli.TabIndex = 2;
            this.cbxFamiliaCli.UseVisualStyleBackColor = true;
            this.cbxFamiliaCli.CheckedChanged += new System.EventHandler(this.cbxFamiliaCli_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRevisao);
            this.groupBox1.Controls.Add(this.lblRevisaoData);
            this.groupBox1.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox1.Controls.Add(this.iwtLabel7);
            this.groupBox1.Controls.Add(this.iwtLabel6);
            this.groupBox1.Controls.Add(this.iwtLabel5);
            this.groupBox1.Location = new System.Drawing.Point(38, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 94);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revisão";
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.BindingField = "UltimaRevisao";
            this.lblRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisao.Location = new System.Drawing.Point(100, 62);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(0, 13);
            this.lblRevisao.TabIndex = 5;
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(100, 39);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 4;
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(100, 16);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 3;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(16, 62);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel7.TabIndex = 2;
            this.iwtLabel7.Text = "Justificativa";
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(48, 39);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(30, 13);
            this.iwtLabel6.TabIndex = 1;
            this.iwtLabel6.Text = "Data";
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(35, 16);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(43, 13);
            this.iwtLabel5.TabIndex = 0;
            this.iwtLabel5.Text = "Usuário";
            // 
            // cmbFamiliaCliente
            // 
            this.cmbFamiliaCliente.BindingField = "FamiliaCliente";
            this.cmbFamiliaCliente.Enabled = false;
            this.cmbFamiliaCliente.FormattingEnabled = true;
            this.cmbFamiliaCliente.LiberadoQuandoCadastroUtilizado = true;
            this.cmbFamiliaCliente.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbFamiliaCliente.Location = new System.Drawing.Point(110, 65);
            this.cmbFamiliaCliente.Name = "cmbFamiliaCliente";
            this.cmbFamiliaCliente.Size = new System.Drawing.Size(289, 21);
            this.cmbFamiliaCliente.TabIndex = 3;
            // 
            // Tipo_RetornoNumeroLabel
            // 
            this.Tipo_RetornoNumeroLabel.AutoSize = true;
            this.Tipo_RetornoNumeroLabel.BindingField = null;
            this.Tipo_RetornoNumeroLabel.LiberadoQuandoCadastroUtilizado = false;
            this.Tipo_RetornoNumeroLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Tipo_RetornoNumeroLabel.Location = new System.Drawing.Point(142, 16);
            this.Tipo_RetornoNumeroLabel.Name = "Tipo_RetornoNumeroLabel";
            this.Tipo_RetornoNumeroLabel.Size = new System.Drawing.Size(52, 13);
            this.Tipo_RetornoNumeroLabel.TabIndex = 12;
            this.Tipo_RetornoNumeroLabel.Text = "Numérica";
            // 
            // Tipo_RetornoNumero
            // 
            this.Tipo_RetornoNumero.AutoSize = true;
            this.Tipo_RetornoNumero.BindingField = "Tipo_RetornoNumero";
            this.Tipo_RetornoNumero.LiberadoQuandoCadastroUtilizado = false;
            this.Tipo_RetornoNumero.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Tipo_RetornoNumero.Location = new System.Drawing.Point(200, 16);
            this.Tipo_RetornoNumero.Name = "Tipo_RetornoNumero";
            this.Tipo_RetornoNumero.Size = new System.Drawing.Size(14, 13);
            this.Tipo_RetornoNumero.TabIndex = 1;
            this.Tipo_RetornoNumero.UseVisualStyleBackColor = true;
            // 
            // Tipo_RetornoBooleanLabel
            // 
            this.Tipo_RetornoBooleanLabel.AutoSize = true;
            this.Tipo_RetornoBooleanLabel.BindingField = null;
            this.Tipo_RetornoBooleanLabel.LiberadoQuandoCadastroUtilizado = false;
            this.Tipo_RetornoBooleanLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Tipo_RetornoBooleanLabel.Location = new System.Drawing.Point(268, 16);
            this.Tipo_RetornoBooleanLabel.Name = "Tipo_RetornoBooleanLabel";
            this.Tipo_RetornoBooleanLabel.Size = new System.Drawing.Size(88, 13);
            this.Tipo_RetornoBooleanLabel.TabIndex = 14;
            this.Tipo_RetornoBooleanLabel.Text = "Verdadeiro/Falso";
            // 
            // Tipo_RetornoBoolean
            // 
            this.Tipo_RetornoBoolean.AutoSize = true;
            this.Tipo_RetornoBoolean.BindingField = "Tipo_RetornoBoolean";
            this.Tipo_RetornoBoolean.LiberadoQuandoCadastroUtilizado = false;
            this.Tipo_RetornoBoolean.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Tipo_RetornoBoolean.Location = new System.Drawing.Point(362, 16);
            this.Tipo_RetornoBoolean.Name = "Tipo_RetornoBoolean";
            this.Tipo_RetornoBoolean.Size = new System.Drawing.Size(14, 13);
            this.Tipo_RetornoBoolean.TabIndex = 2;
            this.Tipo_RetornoBoolean.UseVisualStyleBackColor = true;
            // 
            // Tipo_RetornoTextoLabel
            // 
            this.Tipo_RetornoTextoLabel.AutoSize = true;
            this.Tipo_RetornoTextoLabel.BindingField = null;
            this.Tipo_RetornoTextoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.Tipo_RetornoTextoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Tipo_RetornoTextoLabel.Location = new System.Drawing.Point(32, 16);
            this.Tipo_RetornoTextoLabel.Name = "Tipo_RetornoTextoLabel";
            this.Tipo_RetornoTextoLabel.Size = new System.Drawing.Size(34, 13);
            this.Tipo_RetornoTextoLabel.TabIndex = 16;
            this.Tipo_RetornoTextoLabel.Text = "Texto";
            // 
            // Tipo_RetornoTexto
            // 
            this.Tipo_RetornoTexto.AutoSize = true;
            this.Tipo_RetornoTexto.BindingField = "Tipo_RetornoTexto";
            this.Tipo_RetornoTexto.LiberadoQuandoCadastroUtilizado = false;
            this.Tipo_RetornoTexto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Tipo_RetornoTexto.Location = new System.Drawing.Point(72, 16);
            this.Tipo_RetornoTexto.Name = "Tipo_RetornoTexto";
            this.Tipo_RetornoTexto.Size = new System.Drawing.Size(14, 13);
            this.Tipo_RetornoTexto.TabIndex = 0;
            this.Tipo_RetornoTexto.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Tipo_RetornoNumeroLabel);
            this.groupBox2.Controls.Add(this.Tipo_RetornoTexto);
            this.groupBox2.Controls.Add(this.Tipo_RetornoNumero);
            this.groupBox2.Controls.Add(this.Tipo_RetornoTextoLabel);
            this.groupBox2.Controls.Add(this.Tipo_RetornoBooleanLabel);
            this.groupBox2.Controls.Add(this.Tipo_RetornoBoolean);
            this.groupBox2.Location = new System.Drawing.Point(38, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo da Variável";
            // 
            // CadVariavelForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(446, 341);
            this.Name = "CadVariavelForm";
            this.Text = "Variável";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTCheckBox cbxFamiliaCli;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTComboBox cmbFamiliaCliente;
        private IWTDotNetLib.IWTLabel Tipo_RetornoNumeroLabel;
        private IWTDotNetLib.IWTRadioButton Tipo_RetornoNumero;
        private IWTDotNetLib.IWTLabel Tipo_RetornoBooleanLabel;
        private IWTDotNetLib.IWTRadioButton Tipo_RetornoBoolean;
        private IWTDotNetLib.IWTLabel Tipo_RetornoTextoLabel;
        private IWTDotNetLib.IWTRadioButton Tipo_RetornoTexto;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}