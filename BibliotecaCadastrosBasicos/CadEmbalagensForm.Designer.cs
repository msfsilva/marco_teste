namespace BibliotecaCadastrosBasicos
{
    partial class CadEmbalagensForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.nuLargura = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudAltura = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudComprimento = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel8 = new IWTDotNetLib.IWTLabel(this.components);
            this.rdbLarguraVar = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbAlturaVar = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbComprimentoVar = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbNenhumaVar = new IWTDotNetLib.IWTRadioButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuLargura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprimento)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdbNenhumaVar);
            this.splitContainer1.Panel1.Controls.Add(this.rdbComprimentoVar);
            this.splitContainer1.Panel1.Controls.Add(this.rdbAlturaVar);
            this.splitContainer1.Panel1.Controls.Add(this.rdbLarguraVar);
            this.splitContainer1.Panel1.Controls.Add(this.nudComprimento);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel8);
            this.splitContainer1.Panel1.Controls.Add(this.nudAltura);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.nuLargura);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(409, 326);
            this.splitContainer1.SplitterDistance = 260;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(322, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRevisao);
            this.groupBox1.Controls.Add(this.lblRevisaoData);
            this.groupBox1.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox1.Controls.Add(this.iwtLabel7);
            this.groupBox1.Controls.Add(this.iwtLabel6);
            this.groupBox1.Controls.Add(this.iwtLabel5);
            this.groupBox1.Location = new System.Drawing.Point(15, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 94);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revisão";
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.BindingField = "UltimaRevisao";
            this.lblRevisao.Location = new System.Drawing.Point(100, 62);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(0, 13);
            this.lblRevisao.TabIndex = 5;
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.Location = new System.Drawing.Point(100, 39);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 4;
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(100, 16);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 3;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
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
            this.iwtLabel5.Location = new System.Drawing.Point(35, 16);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(43, 13);
            this.iwtLabel5.TabIndex = 0;
            this.iwtLabel5.Text = "Usuário";
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.BindingField = "Descricao";
            this.iwtTextBox2.Location = new System.Drawing.Point(86, 42);
            this.iwtTextBox2.MaxLength = 255;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.Size = new System.Drawing.Size(311, 20);
            this.iwtTextBox2.TabIndex = 1;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Codigo";
            this.iwtTextBox1.Location = new System.Drawing.Point(86, 16);
            this.iwtTextBox1.MaxLength = 10;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.Size = new System.Drawing.Size(111, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.Location = new System.Drawing.Point(25, 45);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(55, 13);
            this.iwtLabel2.TabIndex = 12;
            this.iwtLabel2.Text = "Descrição";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.Location = new System.Drawing.Point(40, 19);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(40, 13);
            this.iwtLabel1.TabIndex = 10;
            this.iwtLabel1.Text = "Código";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.Location = new System.Drawing.Point(37, 70);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(43, 13);
            this.iwtLabel3.TabIndex = 15;
            this.iwtLabel3.Text = "Largura";
            // 
            // nuLargura
            // 
            this.nuLargura.BindingField = "Largura";
            this.nuLargura.DecimalPlaces = 2;
            this.nuLargura.Location = new System.Drawing.Point(86, 68);
            this.nuLargura.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.nuLargura.Name = "nuLargura";
            this.nuLargura.Size = new System.Drawing.Size(120, 20);
            this.nuLargura.TabIndex = 2;
            // 
            // nudAltura
            // 
            this.nudAltura.BindingField = "Altura";
            this.nudAltura.DecimalPlaces = 2;
            this.nudAltura.Location = new System.Drawing.Point(86, 94);
            this.nudAltura.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.nudAltura.Name = "nudAltura";
            this.nudAltura.Size = new System.Drawing.Size(120, 20);
            this.nudAltura.TabIndex = 3;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.Location = new System.Drawing.Point(46, 94);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(34, 13);
            this.iwtLabel4.TabIndex = 17;
            this.iwtLabel4.Text = "Altura";
            // 
            // nudComprimento
            // 
            this.nudComprimento.BindingField = "Comprimento";
            this.nudComprimento.DecimalPlaces = 2;
            this.nudComprimento.Location = new System.Drawing.Point(86, 120);
            this.nudComprimento.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.nudComprimento.Name = "nudComprimento";
            this.nudComprimento.Size = new System.Drawing.Size(120, 20);
            this.nudComprimento.TabIndex = 4;
            // 
            // iwtLabel8
            // 
            this.iwtLabel8.AutoSize = true;
            this.iwtLabel8.BindingField = null;
            this.iwtLabel8.Location = new System.Drawing.Point(12, 122);
            this.iwtLabel8.Name = "iwtLabel8";
            this.iwtLabel8.Size = new System.Drawing.Size(68, 13);
            this.iwtLabel8.TabIndex = 19;
            this.iwtLabel8.Text = "Comprimento";
            // 
            // rdbLarguraVar
            // 
            this.rdbLarguraVar.AutoSize = true;
            this.rdbLarguraVar.BindingField = "UtilLarguraDimVariavel";
            this.rdbLarguraVar.Location = new System.Drawing.Point(212, 68);
            this.rdbLarguraVar.Name = "rdbLarguraVar";
            this.rdbLarguraVar.Size = new System.Drawing.Size(131, 17);
            this.rdbLarguraVar.TabIndex = 5;
            this.rdbLarguraVar.TabStop = true;
            this.rdbLarguraVar.Text = "Utilizar largura variável";
            this.rdbLarguraVar.UseVisualStyleBackColor = true;
            this.rdbLarguraVar.CheckedChanged += new System.EventHandler(this.rdbLarguraVar_CheckedChanged);
            // 
            // rdbAlturaVar
            // 
            this.rdbAlturaVar.AutoSize = true;
            this.rdbAlturaVar.BindingField = "UtilAlturaDimVariavel";
            this.rdbAlturaVar.Location = new System.Drawing.Point(212, 94);
            this.rdbAlturaVar.Name = "rdbAlturaVar";
            this.rdbAlturaVar.Size = new System.Drawing.Size(125, 17);
            this.rdbAlturaVar.TabIndex = 6;
            this.rdbAlturaVar.TabStop = true;
            this.rdbAlturaVar.Text = "Utilizar altura variável";
            this.rdbAlturaVar.UseVisualStyleBackColor = true;
            this.rdbAlturaVar.CheckedChanged += new System.EventHandler(this.rdbAlturaVar_CheckedChanged);
            // 
            // rdbComprimentoVar
            // 
            this.rdbComprimentoVar.AutoSize = true;
            this.rdbComprimentoVar.BindingField = "UtilComprimentoDimVariavel";
            this.rdbComprimentoVar.Location = new System.Drawing.Point(212, 120);
            this.rdbComprimentoVar.Name = "rdbComprimentoVar";
            this.rdbComprimentoVar.Size = new System.Drawing.Size(159, 17);
            this.rdbComprimentoVar.TabIndex = 7;
            this.rdbComprimentoVar.TabStop = true;
            this.rdbComprimentoVar.Text = "Utilizar comprimento variável";
            this.rdbComprimentoVar.UseVisualStyleBackColor = true;
            this.rdbComprimentoVar.CheckedChanged += new System.EventHandler(this.rdbComprimentoVar_CheckedChanged);
            // 
            // rdbNenhumaVar
            // 
            this.rdbNenhumaVar.AutoSize = true;
            this.rdbNenhumaVar.BindingField = "UtilNenhumaDimVariavel";
            this.rdbNenhumaVar.Location = new System.Drawing.Point(212, 143);
            this.rdbNenhumaVar.Name = "rdbNenhumaVar";
            this.rdbNenhumaVar.Size = new System.Drawing.Size(148, 17);
            this.rdbNenhumaVar.TabIndex = 8;
            this.rdbNenhumaVar.TabStop = true;
            this.rdbNenhumaVar.Text = "Nenhuma medida variável";
            this.rdbNenhumaVar.UseVisualStyleBackColor = true;
            this.rdbNenhumaVar.CheckedChanged += new System.EventHandler(this.rdbNenhumaVar_CheckedChanged);
            // 
            // CadEmbalagensForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(409, 326);
            this.Name = "CadEmbalagensForm";
            this.Text = "Dimensionamento Volumétrico";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuLargura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAltura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprimento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTNumericUpDown nudComprimento;
        private IWTDotNetLib.IWTLabel iwtLabel8;
        private IWTDotNetLib.IWTNumericUpDown nudAltura;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTNumericUpDown nuLargura;
        private IWTDotNetLib.IWTRadioButton rdbNenhumaVar;
        private IWTDotNetLib.IWTRadioButton rdbComprimentoVar;
        private IWTDotNetLib.IWTRadioButton rdbAlturaVar;
        private IWTDotNetLib.IWTRadioButton rdbLarguraVar;

    }
}