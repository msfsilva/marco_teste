namespace BibliotecaCadastrosBasicos.EstruturaProduto
{
    partial class CadProdutoRecursoForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rdbPrimario = new System.Windows.Forms.RadioButton();
            this.rdbSecundario = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(238, 58);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(12, 58);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rdbPrimario
            // 
            this.rdbPrimario.AutoSize = true;
            this.rdbPrimario.Checked = true;
            this.rdbPrimario.Location = new System.Drawing.Point(12, 23);
            this.rdbPrimario.Name = "rdbPrimario";
            this.rdbPrimario.Size = new System.Drawing.Size(62, 17);
            this.rdbPrimario.TabIndex = 0;
            this.rdbPrimario.TabStop = true;
            this.rdbPrimario.Text = "Primário";
            this.rdbPrimario.UseVisualStyleBackColor = true;
            // 
            // rdbSecundario
            // 
            this.rdbSecundario.AutoSize = true;
            this.rdbSecundario.Location = new System.Drawing.Point(99, 23);
            this.rdbSecundario.Name = "rdbSecundario";
            this.rdbSecundario.Size = new System.Drawing.Size(79, 17);
            this.rdbSecundario.TabIndex = 1;
            this.rdbSecundario.Text = "Secundário";
            this.rdbSecundario.UseVisualStyleBackColor = true;
            // 
            // ProdutoRecursoForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(325, 93);
            this.Controls.Add(this.rdbSecundario);
            this.Controls.Add(this.rdbPrimario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Name = "ProdutoRecursoForm";
            this.Text = "Inclusão de Recurso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton rdbPrimario;
        private System.Windows.Forms.RadioButton rdbSecundario;
    }
}