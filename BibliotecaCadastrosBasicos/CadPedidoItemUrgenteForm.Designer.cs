namespace BibliotecaCadastrosBasicos
{
    partial class CadPedidoItemUrgenteForm
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
            this.gbxUrgente = new System.Windows.Forms.GroupBox();
            this.txtUrgenteInfos = new IWTDotNetLib.IWTTextBox(this.components);
            this.label13 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpUrgenteData = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label12 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtUrgenteSolicitante = new IWTDotNetLib.IWTTextBox(this.components);
            this.label6 = new IWTDotNetLib.IWTLabel(this.components);
            this.rdbUrgenteCritico = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbUrgenteUrgente = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbUrgenteAntecipacao = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbUrgenteNormal = new IWTDotNetLib.IWTRadioButton(this.components);
            this.btnSalvar = new IWTDotNetLib.IWTButton(this.components);
            this.gbxUrgente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpUrgenteData)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxUrgente
            // 
            this.gbxUrgente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxUrgente.Controls.Add(this.txtUrgenteInfos);
            this.gbxUrgente.Controls.Add(this.label13);
            this.gbxUrgente.Controls.Add(this.dtpUrgenteData);
            this.gbxUrgente.Controls.Add(this.label12);
            this.gbxUrgente.Controls.Add(this.txtUrgenteSolicitante);
            this.gbxUrgente.Controls.Add(this.label6);
            this.gbxUrgente.Enabled = false;
            this.gbxUrgente.Location = new System.Drawing.Point(12, 35);
            this.gbxUrgente.Name = "gbxUrgente";
            this.gbxUrgente.Size = new System.Drawing.Size(376, 157);
            this.gbxUrgente.TabIndex = 21;
            this.gbxUrgente.TabStop = false;
            this.gbxUrgente.Text = "Urgente";
            // 
            // txtUrgenteInfos
            // 
            this.txtUrgenteInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrgenteInfos.BindingField = "";
            this.txtUrgenteInfos.DebugMode = false;
            this.txtUrgenteInfos.LiberadoQuandoCadastroUtilizado = false;
            this.txtUrgenteInfos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtUrgenteInfos.Location = new System.Drawing.Point(9, 80);
            this.txtUrgenteInfos.ModoBarcode = false;
            this.txtUrgenteInfos.Multiline = true;
            this.txtUrgenteInfos.Name = "txtUrgenteInfos";
            this.txtUrgenteInfos.Size = new System.Drawing.Size(361, 71);
            this.txtUrgenteInfos.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BindingField = null;
            this.label13.LiberadoQuandoCadastroUtilizado = false;
            this.label13.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label13.Location = new System.Drawing.Point(6, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Informações Complementares";
            // 
            // dtpUrgenteData
            // 
            this.dtpUrgenteData.BindingField = "";
            this.dtpUrgenteData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUrgenteData.LiberadoQuandoCadastroUtilizado = false;
            this.dtpUrgenteData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpUrgenteData.Location = new System.Drawing.Point(99, 40);
            this.dtpUrgenteData.Name = "dtpUrgenteData";
            this.dtpUrgenteData.Size = new System.Drawing.Size(95, 20);
            this.dtpUrgenteData.TabIndex = 1;
            this.dtpUrgenteData.Value = new System.DateTime(2015, 5, 12, 16, 31, 18, 889);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BindingField = null;
            this.label12.LiberadoQuandoCadastroUtilizado = false;
            this.label12.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label12.Location = new System.Drawing.Point(13, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Data Prometida";
            // 
            // txtUrgenteSolicitante
            // 
            this.txtUrgenteSolicitante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrgenteSolicitante.BindingField = "";
            this.txtUrgenteSolicitante.DebugMode = false;
            this.txtUrgenteSolicitante.LiberadoQuandoCadastroUtilizado = false;
            this.txtUrgenteSolicitante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtUrgenteSolicitante.Location = new System.Drawing.Point(99, 14);
            this.txtUrgenteSolicitante.ModoBarcode = false;
            this.txtUrgenteSolicitante.Name = "txtUrgenteSolicitante";
            this.txtUrgenteSolicitante.Size = new System.Drawing.Size(271, 20);
            this.txtUrgenteSolicitante.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BindingField = null;
            this.label6.LiberadoQuandoCadastroUtilizado = false;
            this.label6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label6.Location = new System.Drawing.Point(37, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Solicitante";
            // 
            // rdbUrgenteCritico
            // 
            this.rdbUrgenteCritico.AutoSize = true;
            this.rdbUrgenteCritico.BindingField = "";
            this.rdbUrgenteCritico.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteCritico.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteCritico.Location = new System.Drawing.Point(230, 12);
            this.rdbUrgenteCritico.Name = "rdbUrgenteCritico";
            this.rdbUrgenteCritico.Size = new System.Drawing.Size(56, 17);
            this.rdbUrgenteCritico.TabIndex = 20;
            this.rdbUrgenteCritico.Text = "Crítico";
            this.rdbUrgenteCritico.UseVisualStyleBackColor = true;
            this.rdbUrgenteCritico.CheckedChanged += new System.EventHandler(this.rdbUrgenteCritico_CheckedChanged);
            // 
            // rdbUrgenteUrgente
            // 
            this.rdbUrgenteUrgente.AutoSize = true;
            this.rdbUrgenteUrgente.BindingField = "";
            this.rdbUrgenteUrgente.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteUrgente.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteUrgente.Location = new System.Drawing.Point(167, 12);
            this.rdbUrgenteUrgente.Name = "rdbUrgenteUrgente";
            this.rdbUrgenteUrgente.Size = new System.Drawing.Size(63, 17);
            this.rdbUrgenteUrgente.TabIndex = 19;
            this.rdbUrgenteUrgente.Text = "Urgente";
            this.rdbUrgenteUrgente.UseVisualStyleBackColor = true;
            this.rdbUrgenteUrgente.CheckedChanged += new System.EventHandler(this.rdbUrgenteUrgente_CheckedChanged);
            // 
            // rdbUrgenteAntecipacao
            // 
            this.rdbUrgenteAntecipacao.AutoSize = true;
            this.rdbUrgenteAntecipacao.BindingField = "";
            this.rdbUrgenteAntecipacao.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteAntecipacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteAntecipacao.Location = new System.Drawing.Point(76, 12);
            this.rdbUrgenteAntecipacao.Name = "rdbUrgenteAntecipacao";
            this.rdbUrgenteAntecipacao.Size = new System.Drawing.Size(85, 17);
            this.rdbUrgenteAntecipacao.TabIndex = 18;
            this.rdbUrgenteAntecipacao.Text = "Antecipação";
            this.rdbUrgenteAntecipacao.UseVisualStyleBackColor = true;
            this.rdbUrgenteAntecipacao.CheckedChanged += new System.EventHandler(this.rdbUrgenteAntecipacao_CheckedChanged);
            // 
            // rdbUrgenteNormal
            // 
            this.rdbUrgenteNormal.AutoSize = true;
            this.rdbUrgenteNormal.BindingField = "";
            this.rdbUrgenteNormal.Checked = true;
            this.rdbUrgenteNormal.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteNormal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteNormal.Location = new System.Drawing.Point(12, 12);
            this.rdbUrgenteNormal.Name = "rdbUrgenteNormal";
            this.rdbUrgenteNormal.Size = new System.Drawing.Size(58, 17);
            this.rdbUrgenteNormal.TabIndex = 17;
            this.rdbUrgenteNormal.TabStop = true;
            this.rdbUrgenteNormal.Text = "Normal";
            this.rdbUrgenteNormal.UseVisualStyleBackColor = true;
            this.rdbUrgenteNormal.CheckedChanged += new System.EventHandler(this.rdbUrgenteNormal_CheckedChanged);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.LiberadoQuandoCadastroUtilizado = false;
            this.btnSalvar.Location = new System.Drawing.Point(313, 198);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 22;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // CadPedidoItemUrgenteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(400, 229);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbxUrgente);
            this.Controls.Add(this.rdbUrgenteCritico);
            this.Controls.Add(this.rdbUrgenteUrgente);
            this.Controls.Add(this.rdbUrgenteAntecipacao);
            this.Controls.Add(this.rdbUrgenteNormal);
            this.Name = "CadPedidoItemUrgenteForm";
            this.Text = "Alteração da Urgência do Pedido";
            this.gbxUrgente.ResumeLayout(false);
            this.gbxUrgente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpUrgenteData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxUrgente;
        private IWTDotNetLib.IWTTextBox txtUrgenteInfos;
        private IWTDotNetLib.IWTLabel label13;
        private IWTDotNetLib.IWTDateTimePicker dtpUrgenteData;
        private IWTDotNetLib.IWTLabel label12;
        private IWTDotNetLib.IWTTextBox txtUrgenteSolicitante;
        private IWTDotNetLib.IWTLabel label6;
        private IWTDotNetLib.IWTRadioButton rdbUrgenteCritico;
        private IWTDotNetLib.IWTRadioButton rdbUrgenteUrgente;
        private IWTDotNetLib.IWTRadioButton rdbUrgenteAntecipacao;
        private IWTDotNetLib.IWTRadioButton rdbUrgenteNormal;
        private IWTDotNetLib.IWTButton btnSalvar;
    }
}