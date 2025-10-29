namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    partial class GeracaoEtiquetaCustomizadaSemCNCForm
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
            this.rdbOcPos = new System.Windows.Forms.RadioButton();
            this.rdbPps = new System.Windows.Forms.RadioButton();
            this.gbxPps = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPps = new System.Windows.Forms.TextBox();
            this.gbxOcPos = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGerar = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.gbxPps.SuspendLayout();
            this.gbxOcPos.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbOcPos
            // 
            this.rdbOcPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbOcPos.AutoSize = true;
            this.rdbOcPos.Location = new System.Drawing.Point(370, 97);
            this.rdbOcPos.Name = "rdbOcPos";
            this.rdbOcPos.Size = new System.Drawing.Size(14, 13);
            this.rdbOcPos.TabIndex = 8;
            this.rdbOcPos.TabStop = true;
            this.rdbOcPos.UseVisualStyleBackColor = true;
            this.rdbOcPos.CheckedChanged += new System.EventHandler(this.rdbOcPos_CheckedChanged);
            // 
            // rdbPps
            // 
            this.rdbPps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbPps.AutoSize = true;
            this.rdbPps.Location = new System.Drawing.Point(370, 34);
            this.rdbPps.Name = "rdbPps";
            this.rdbPps.Size = new System.Drawing.Size(14, 13);
            this.rdbPps.TabIndex = 6;
            this.rdbPps.TabStop = true;
            this.rdbPps.UseVisualStyleBackColor = true;
            this.rdbPps.CheckedChanged += new System.EventHandler(this.rdbPps_CheckedChanged);
            // 
            // gbxPps
            // 
            this.gbxPps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPps.Controls.Add(this.label3);
            this.gbxPps.Controls.Add(this.txtPps);
            this.gbxPps.Location = new System.Drawing.Point(12, 12);
            this.gbxPps.Name = "gbxPps";
            this.gbxPps.Size = new System.Drawing.Size(352, 57);
            this.gbxPps.TabIndex = 7;
            this.gbxPps.TabStop = false;
            this.gbxPps.Text = "PPS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "PPS";
            // 
            // txtPps
            // 
            this.txtPps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPps.Location = new System.Drawing.Point(65, 19);
            this.txtPps.Name = "txtPps";
            this.txtPps.Size = new System.Drawing.Size(281, 20);
            this.txtPps.TabIndex = 0;
            // 
            // gbxOcPos
            // 
            this.gbxOcPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOcPos.Controls.Add(this.label1);
            this.gbxOcPos.Controls.Add(this.label2);
            this.gbxOcPos.Controls.Add(this.txtPos);
            this.gbxOcPos.Controls.Add(this.txtOc);
            this.gbxOcPos.Enabled = false;
            this.gbxOcPos.Location = new System.Drawing.Point(12, 75);
            this.gbxOcPos.Name = "gbxOcPos";
            this.gbxOcPos.Size = new System.Drawing.Size(352, 61);
            this.gbxOcPos.TabIndex = 9;
            this.gbxOcPos.TabStop = false;
            this.gbxOcPos.Text = "Pedido";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OC / Pos";
            // 
            // txtPos
            // 
            this.txtPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPos.Location = new System.Drawing.Point(295, 19);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(51, 20);
            this.txtPos.TabIndex = 1;
            // 
            // txtOc
            // 
            this.txtOc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOc.Location = new System.Drawing.Point(65, 19);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(206, 20);
            this.txtOc.TabIndex = 0;
            // 
            // rdbTodos
            // 
            this.rdbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(370, 161);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(14, 13);
            this.rdbTodos.TabIndex = 10;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Todos Pendentes";
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.LiberadoQuandoCadastroUtilizado = false;
            this.btnGerar.Location = new System.Drawing.Point(309, 220);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 11;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(12, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // GeracaoEtiquetaCustomizadaSemCNCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 255);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdbTodos);
            this.Controls.Add(this.rdbOcPos);
            this.Controls.Add(this.rdbPps);
            this.Controls.Add(this.gbxPps);
            this.Controls.Add(this.gbxOcPos);
            this.Name = "GeracaoEtiquetaCustomizadaSemCNCForm";
            this.Text = "Geração de Etiqueta Customizada Sem CNC";
            this.gbxPps.ResumeLayout(false);
            this.gbxPps.PerformLayout();
            this.gbxOcPos.ResumeLayout(false);
            this.gbxOcPos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbOcPos;
        private System.Windows.Forms.RadioButton rdbPps;
        private System.Windows.Forms.GroupBox gbxPps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPps;
        private System.Windows.Forms.GroupBox gbxOcPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.Label label4;
        private IWTDotNetLib.IWTButton btnGerar;
        private IWTDotNetLib.IWTButton btnCancelar;
    }
}