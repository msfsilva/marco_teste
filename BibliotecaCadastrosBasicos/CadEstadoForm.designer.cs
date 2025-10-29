namespace BibliotecaCadastrosBasicos
{
    partial class CadEstadoForm
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
this.SiglaLabel = new IWTDotNetLib.IWTLabel(this.components);
this.Sigla = new IWTDotNetLib.IWTTextBox(this.components);
this.NomeLabel = new IWTDotNetLib.IWTLabel(this.components);
this.Nome = new IWTDotNetLib.IWTTextBox(this.components);
this.AliquotaLabel = new IWTDotNetLib.IWTLabel(this.components);
 this.Aliquota = new IWTDotNetLib.IWTNumericUpDown(this.components);
this.CodigoIbgeLabel = new IWTDotNetLib.IWTLabel(this.components);
 this.CodigoIbge = new IWTDotNetLib.IWTNumericUpDown(this.components);
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
  this.splitContainer1.Panel1.Controls.Add(this.SiglaLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Sigla);
 this.splitContainer1.Panel1.Controls.Add(this.NomeLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Nome);
 this.splitContainer1.Panel1.Controls.Add(this.AliquotaLabel);
 this.splitContainer1.Panel1.Controls.Add(this.Aliquota);
 this.splitContainer1.Panel1.Controls.Add(this.CodigoIbgeLabel);
 this.splitContainer1.Panel1.Controls.Add(this.CodigoIbge);
            this.splitContainer1.Size = new System.Drawing.Size(370, 208);
            this.splitContainer1.SplitterDistance = 142;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(283, 20); 
            // 
            // SiglaLabel
            // 
            this.SiglaLabel.AutoSize = true;
            this.SiglaLabel.BindingField = null;
            this.SiglaLabel.Location = new System.Drawing.Point(20, 16);
            this.SiglaLabel.Name = "SiglaLabel";
            this.SiglaLabel.Size = new System.Drawing.Size(40, 13);
            this.SiglaLabel.TabIndex = 0;
            this.SiglaLabel.Text = "est_sigla";
            // 
            // Sigla
            // 
            this.Sigla.BindingField = "Sigla";
            this.Sigla.Location = new System.Drawing.Point(200, 12);
            this.Sigla.Name = "Sigla";
            this.Sigla.Size = new System.Drawing.Size(150, 21);
            this.Sigla.TabIndex = 1;
            this.Sigla.MaxLength = 2;
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.BindingField = null;
            this.NomeLabel.Location = new System.Drawing.Point(20, 43);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(40, 13);
            this.NomeLabel.TabIndex = 2;
            this.NomeLabel.Text = "est_nome";
            // 
            // Nome
            // 
            this.Nome.BindingField = "Nome";
            this.Nome.Location = new System.Drawing.Point(200, 39);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(150, 21);
            this.Nome.TabIndex = 3;
            // 
            // AliquotaLabel
            // 
            this.AliquotaLabel.AutoSize = true;
            this.AliquotaLabel.BindingField = null;
            this.AliquotaLabel.Location = new System.Drawing.Point(20, 70);
            this.AliquotaLabel.Name = "AliquotaLabel";
            this.AliquotaLabel.Size = new System.Drawing.Size(40, 13);
            this.AliquotaLabel.TabIndex = 4;
            this.AliquotaLabel.Text = "est_aliquota";
            // 
            // Aliquota
            // 
            this.Aliquota.BindingField = "Aliquota";
            this.Aliquota.Location = new System.Drawing.Point(200, 66);
            this.Aliquota.Maximum = new decimal(2147483647 );
            this.Aliquota.Minimum = new decimal(-2147483648 );
            this.Aliquota.Name = "Aliquota";
            this.Aliquota.Size = new System.Drawing.Size(150, 21);
            this.Aliquota.TabIndex = 5;
            this.Aliquota.Value = new decimal(0);
            this.Aliquota.DecimalPlaces = 4;
            // 
            // CodigoIbgeLabel
            // 
            this.CodigoIbgeLabel.AutoSize = true;
            this.CodigoIbgeLabel.BindingField = null;
            this.CodigoIbgeLabel.Location = new System.Drawing.Point(20, 97);
            this.CodigoIbgeLabel.Name = "CodigoIbgeLabel";
            this.CodigoIbgeLabel.Size = new System.Drawing.Size(40, 13);
            this.CodigoIbgeLabel.TabIndex = 6;
            this.CodigoIbgeLabel.Text = "est_codigo_ibge";
            // 
            // CodigoIbge
            // 
            this.CodigoIbge.BindingField = "CodigoIbge";
            this.CodigoIbge.Location = new System.Drawing.Point(200, 93);
            this.CodigoIbge.Maximum = new decimal(2147483647 );
            this.CodigoIbge.Minimum = new decimal(-2147483648 );
            this.CodigoIbge.Name = "CodigoIbge";
            this.CodigoIbge.Size = new System.Drawing.Size(150, 21);
            this.CodigoIbge.TabIndex = 7;
            this.CodigoIbge.Value = new decimal(0);
            this.CodigoIbge.DecimalPlaces = 0;
            // 
            // CadEstadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.Name = "CadEstadoForm";
            this.Text = "CadEstadoForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel SiglaLabel;
        private IWTDotNetLib.IWTTextBox Sigla;
        private IWTDotNetLib.IWTLabel NomeLabel;
        private IWTDotNetLib.IWTTextBox Nome;
        private IWTDotNetLib.IWTLabel AliquotaLabel;
        private IWTDotNetLib.IWTNumericUpDown Aliquota;
        private IWTDotNetLib.IWTLabel CodigoIbgeLabel;
        private IWTDotNetLib.IWTNumericUpDown CodigoIbge;
    }
} 
