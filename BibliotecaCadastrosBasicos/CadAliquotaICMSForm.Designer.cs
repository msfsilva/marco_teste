namespace BibliotecaCadastrosBasicos
{
    partial class CadAliquotaICMSForm
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
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtNumericUpDown1 = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtNumericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(348, 183);
            this.splitContainer1.SplitterDistance = 117;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(261, 20);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.Location = new System.Drawing.Point(21, 24);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(101, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Modelo Fiscal ICMS";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.Location = new System.Drawing.Point(101, 50);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(21, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "UF";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.Location = new System.Drawing.Point(48, 75);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(74, 13);
            this.iwtLabel3.TabIndex = 2;
            this.iwtLabel3.Text = "Valor Alíquota";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Estado";
            this.iwtTextBox1.Location = new System.Drawing.Point(128, 47);
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.ReadOnly = true;
            this.iwtTextBox1.Size = new System.Drawing.Size(120, 20);
            this.iwtTextBox1.TabIndex = 3;
            // 
            // iwtNumericUpDown1
            // 
            this.iwtNumericUpDown1.BindingField = "Aliquota";
            this.iwtNumericUpDown1.DecimalPlaces = 4;
            this.iwtNumericUpDown1.Location = new System.Drawing.Point(128, 73);
            this.iwtNumericUpDown1.Name = "iwtNumericUpDown1";
            this.iwtNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.iwtNumericUpDown1.TabIndex = 4;
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.BindingField = "ModeloFiscalIcms";
            this.iwtTextBox2.Location = new System.Drawing.Point(128, 21);
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.ReadOnly = true;
            this.iwtTextBox2.Size = new System.Drawing.Size(197, 20);
            this.iwtTextBox2.TabIndex = 5;
            // 
            // CadAliquotaICMSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(348, 183);
            this.Name = "CadAliquotaICMSForm";
            this.Text = "Alíquota ICMS";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iwtNumericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTNumericUpDown iwtNumericUpDown1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
    }
}