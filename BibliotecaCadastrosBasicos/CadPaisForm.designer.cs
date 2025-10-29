namespace BibliotecaCadastrosBasicos
{
    partial class CadPaisForm
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
this.NomeLabel = new IWTDotNetLib.IWTLabel(this.components);
this.Nome = new IWTDotNetLib.IWTTextBox(this.components);
this.CodigoLabel = new IWTDotNetLib.IWTLabel(this.components);
 this.Codigo = new IWTDotNetLib.IWTNumericUpDown(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
  this.splitContainer1.Panel1.Controls.Add(this.NomeLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Nome);
 this.splitContainer1.Panel1.Controls.Add(this.CodigoLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Codigo);
            this.splitContainer1.Size = new System.Drawing.Size(370, 208);
            this.splitContainer1.SplitterDistance = 142;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(283, 20); 
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.BindingField = null;
            this.NomeLabel.Location = new System.Drawing.Point(20, 16);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(40, 13);
            this.NomeLabel.TabIndex = 0;
            this.NomeLabel.Text = "Nome";
            // 
            // Nome
            // 
            this.Nome.BindingField = "Nome";
            this.Nome.Location = new System.Drawing.Point(200, 12);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(150, 21);
            this.Nome.TabIndex = 1;
            this.Nome.MaxLength = 255;
            // 
            // CodigoLabel
            // 
            this.CodigoLabel.AutoSize = true;
            this.CodigoLabel.BindingField = null;
            this.CodigoLabel.Location = new System.Drawing.Point(20, 43);
            this.CodigoLabel.Name = "CodigoLabel";
            this.CodigoLabel.Size = new System.Drawing.Size(40, 13);
            this.CodigoLabel.TabIndex = 2;
            this.CodigoLabel.Text = "Código";
            // 
            // Codigo
            // 
            this.Codigo.BindingField = "Codigo";
            this.Codigo.Location = new System.Drawing.Point(200, 39);
            this.Codigo.Maximum = new decimal(2147483647 );
            this.Codigo.Minimum = new decimal(-2147483648 );
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(150, 21);
            this.Codigo.TabIndex = 3;
            this.Codigo.Value = new decimal(0);
            this.Codigo.DecimalPlaces = 0;
            // 
            // CadPaisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.Name = "CadPaisForm";
            this.Text = "País";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel NomeLabel;
        private IWTDotNetLib.IWTTextBox Nome;
        private IWTDotNetLib.IWTLabel CodigoLabel;
        private IWTDotNetLib.IWTNumericUpDown Codigo;
    }
} 
