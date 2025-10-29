namespace BibliotecaCadastrosBasicos
{
    partial class CadFamiliaClienteForm
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
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(384, 234);
            this.splitContainer1.SplitterDistance = 168;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(297, 20);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.Location = new System.Drawing.Point(17, 29);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(35, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Nome";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Nome";
            this.iwtTextBox1.Location = new System.Drawing.Point(58, 26);
            this.iwtTextBox1.MaxLength = 10;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.Size = new System.Drawing.Size(301, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRevisao);
            this.groupBox1.Controls.Add(this.lblRevisaoData);
            this.groupBox1.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox1.Controls.Add(this.iwtLabel7);
            this.groupBox1.Controls.Add(this.iwtLabel6);
            this.groupBox1.Controls.Add(this.iwtLabel5);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 94);
            this.groupBox1.TabIndex = 9;
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
            // CadFamiliaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(384, 234);
            this.Name = "CadFamiliaClienteForm";
            this.Text = "Cliente Agrupador";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel iwtLabel5;
    }
}