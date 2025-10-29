namespace BibliotecaExpedicao
{
    partial class EtiquetaExpedicaoReimprimirForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.grbUnitaria = new System.Windows.Forms.GroupBox();
            this.ensCliente = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.nudPosicao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.rdbUnitaria = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbMultipla = new IWTDotNetLib.IWTRadioButton(this.components);
            this.grbMultipla = new System.Windows.Forms.GroupBox();
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtPedidos = new IWTDotNetLib.IWTTextBox(this.components);
            this.ensClienteMultiplos = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.chk = new IWTDotNetLib.IWTCheckBox(this.components);
            this.txt = new IWTDotNetLib.IWTTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.grbUnitaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosicao)).BeginInit();
            this.grbMultipla.SuspendLayout();
            this.ensClienteMultiplos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pós:";
            // 
            // txtOc
            // 
            this.txtOc.Location = new System.Drawing.Point(50, 18);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(138, 20);
            this.txtOc.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(460, 298);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 47);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 13);
            this.label30.TabIndex = 150;
            this.label30.Text = "Cliente";
            // 
            // grbUnitaria
            // 
            this.grbUnitaria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbUnitaria.Controls.Add(this.ensCliente);
            this.grbUnitaria.Controls.Add(this.nudPosicao);
            this.grbUnitaria.Controls.Add(this.txtOc);
            this.grbUnitaria.Controls.Add(this.label1);
            this.grbUnitaria.Controls.Add(this.label2);
            this.grbUnitaria.Controls.Add(this.label30);
            this.grbUnitaria.Location = new System.Drawing.Point(12, 12);
            this.grbUnitaria.Name = "grbUnitaria";
            this.grbUnitaria.Size = new System.Drawing.Size(506, 87);
            this.grbUnitaria.TabIndex = 0;
            this.grbUnitaria.TabStop = false;
            this.grbUnitaria.Text = "Emissão Unitária";
            // 
            // ensCliente
            // 
            this.ensCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensCliente.BindingField = null;
            this.ensCliente.DesabilitarAutoCompletar = false;
            this.ensCliente.DesabilitarChekBox = true;
            this.ensCliente.DesabilitarLupa = false;
            this.ensCliente.DesabilitarSeta = false;
            this.ensCliente.EntidadeSelecionada = null;
            this.ensCliente.FormSelecao = null;
            this.ensCliente.LiberadoQuandoCadastroUtilizado = false;
            this.ensCliente.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensCliente.Location = new System.Drawing.Point(50, 44);
            this.ensCliente.ModoVisualizacaoGrid = null;
            this.ensCliente.Name = "ensCliente";
            this.ensCliente.ParametrosBuscaObrigatorios = null;
            this.ensCliente.Size = new System.Drawing.Size(450, 23);
            this.ensCliente.TabIndex = 152;
            // 
            // nudPosicao
            // 
            this.nudPosicao.BindingField = null;
            this.nudPosicao.LiberadoQuandoCadastroUtilizado = false;
            this.nudPosicao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPosicao.Location = new System.Drawing.Point(232, 18);
            this.nudPosicao.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudPosicao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPosicao.Name = "nudPosicao";
            this.nudPosicao.Size = new System.Drawing.Size(120, 20);
            this.nudPosicao.TabIndex = 151;
            this.nudPosicao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdbUnitaria
            // 
            this.rdbUnitaria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbUnitaria.AutoSize = true;
            this.rdbUnitaria.BindingField = null;
            this.rdbUnitaria.Checked = true;
            this.rdbUnitaria.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUnitaria.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUnitaria.Location = new System.Drawing.Point(524, 51);
            this.rdbUnitaria.Name = "rdbUnitaria";
            this.rdbUnitaria.Size = new System.Drawing.Size(14, 13);
            this.rdbUnitaria.TabIndex = 1;
            this.rdbUnitaria.TabStop = true;
            this.rdbUnitaria.UseVisualStyleBackColor = true;
            this.rdbUnitaria.CheckedChanged += new System.EventHandler(this.rdbUnitaria_CheckedChanged);
            // 
            // rdbMultipla
            // 
            this.rdbMultipla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbMultipla.AutoSize = true;
            this.rdbMultipla.BindingField = null;
            this.rdbMultipla.LiberadoQuandoCadastroUtilizado = false;
            this.rdbMultipla.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbMultipla.Location = new System.Drawing.Point(524, 185);
            this.rdbMultipla.Name = "rdbMultipla";
            this.rdbMultipla.Size = new System.Drawing.Size(14, 13);
            this.rdbMultipla.TabIndex = 3;
            this.rdbMultipla.UseVisualStyleBackColor = true;
            this.rdbMultipla.CheckedChanged += new System.EventHandler(this.rdbMultipla_CheckedChanged);
            // 
            // grbMultipla
            // 
            this.grbMultipla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbMultipla.Controls.Add(this.iwtLabel1);
            this.grbMultipla.Controls.Add(this.txtPedidos);
            this.grbMultipla.Controls.Add(this.ensClienteMultiplos);
            this.grbMultipla.Controls.Add(this.label5);
            this.grbMultipla.Enabled = false;
            this.grbMultipla.Location = new System.Drawing.Point(12, 105);
            this.grbMultipla.Name = "grbMultipla";
            this.grbMultipla.Size = new System.Drawing.Size(506, 187);
            this.grbMultipla.TabIndex = 2;
            this.grbMultipla.TabStop = false;
            this.grbMultipla.Text = "Emissão Múltipla";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(6, 51);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(255, 13);
            this.iwtLabel1.TabIndex = 156;
            this.iwtLabel1.Text = "Pedidos (No formato numero/posicao e um por linha)";
            // 
            // txtPedidos
            // 
            this.txtPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPedidos.BindingField = null;
            this.txtPedidos.DebugMode = false;
            this.txtPedidos.LiberadoQuandoCadastroUtilizado = false;
            this.txtPedidos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtPedidos.Location = new System.Drawing.Point(50, 67);
            this.txtPedidos.ModoBarcode = false;
            this.txtPedidos.Multiline = true;
            this.txtPedidos.Name = "txtPedidos";
            this.txtPedidos.Size = new System.Drawing.Size(450, 114);
            this.txtPedidos.TabIndex = 155;
            // 
            // ensClienteMultiplos
            // 
            this.ensClienteMultiplos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensClienteMultiplos.BindingField = null;
            this.ensClienteMultiplos.Controls.Add(this.chk);
            this.ensClienteMultiplos.Controls.Add(this.txt);
            this.ensClienteMultiplos.DesabilitarAutoCompletar = false;
            this.ensClienteMultiplos.DesabilitarChekBox = true;
            this.ensClienteMultiplos.DesabilitarLupa = false;
            this.ensClienteMultiplos.DesabilitarSeta = false;
            this.ensClienteMultiplos.EntidadeSelecionada = null;
            this.ensClienteMultiplos.FormSelecao = null;
            this.ensClienteMultiplos.LiberadoQuandoCadastroUtilizado = false;
            this.ensClienteMultiplos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensClienteMultiplos.Location = new System.Drawing.Point(50, 19);
            this.ensClienteMultiplos.ModoVisualizacaoGrid = null;
            this.ensClienteMultiplos.Name = "ensClienteMultiplos";
            this.ensClienteMultiplos.ParametrosBuscaObrigatorios = null;
            this.ensClienteMultiplos.Size = new System.Drawing.Size(450, 23);
            this.ensClienteMultiplos.TabIndex = 154;
            // 
            // chk
            // 
            this.chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk.AutoSize = true;
            this.chk.BindingField = "";
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.LiberadoQuandoCadastroUtilizado = false;
            this.chk.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chk.Location = new System.Drawing.Point(774, 4);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(15, 14);
            this.chk.TabIndex = 1;
            this.chk.UseVisualStyleBackColor = true;
            this.chk.Visible = false;
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.BindingField = "";
            this.txt.DebugMode = false;
            this.txt.LiberadoQuandoCadastroUtilizado = false;
            this.txt.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txt.Location = new System.Drawing.Point(0, 1);
            this.txt.ModoBarcode = false;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(409, 20);
            this.txt.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "Cliente";
            // 
            // EtiquetaExpedicaoReimprimirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(547, 333);
            this.Controls.Add(this.rdbMultipla);
            this.Controls.Add(this.rdbUnitaria);
            this.Controls.Add(this.grbMultipla);
            this.Controls.Add(this.grbUnitaria);
            this.Controls.Add(this.btnOk);
            this.Name = "EtiquetaExpedicaoReimprimirForm";
            this.Text = "Emissão Manual de Etiqueta de Expedição";
            this.grbUnitaria.ResumeLayout(false);
            this.grbUnitaria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosicao)).EndInit();
            this.grbMultipla.ResumeLayout(false);
            this.grbMultipla.PerformLayout();
            this.ensClienteMultiplos.ResumeLayout(false);
            this.ensClienteMultiplos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox grbUnitaria;
        private IWTDotNetLib.IWTRadioButton rdbUnitaria;
        private IWTDotNetLib.IWTRadioButton rdbMultipla;
        private System.Windows.Forms.GroupBox grbMultipla;
        private IWTDotNetLib.IWTNumericUpDown nudPosicao;
        private IWTDotNetLib.IWTEntitySelection ensCliente;
        private IWTDotNetLib.IWTEntitySelection ensClienteMultiplos;
        private IWTDotNetLib.IWTCheckBox chk;
        private IWTDotNetLib.IWTTextBox txt;
        private System.Windows.Forms.Label label5;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox txtPedidos;
    }
}