namespace BibliotecaCadastrosBasicos
{
    partial class CadPedidoSimplificadoItemForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ensProduto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensNCM = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDataEntregaLinha = new System.Windows.Forms.DateTimePicker();
            this.lnkDetalhesPrincipal = new System.Windows.Forms.LinkLabel();
            this.chkRastrearMP = new System.Windows.Forms.CheckBox();
            this.txtInfoEspeciais = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkExportacao = new System.Windows.Forms.CheckBox();
            this.chkEntregaParc = new System.Windows.Forms.CheckBox();
            this.cbxVolumeUnico = new System.Windows.Forms.CheckBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nudValorUnit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudQtd = new System.Windows.Forms.NumericUpDown();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtd)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ensProduto);
            this.splitContainer1.Panel1.Controls.Add(this.ensNCM);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.dtpDataEntregaLinha);
            this.splitContainer1.Panel1.Controls.Add(this.lnkDetalhesPrincipal);
            this.splitContainer1.Panel1.Controls.Add(this.chkRastrearMP);
            this.splitContainer1.Panel1.Controls.Add(this.txtInfoEspeciais);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.chkExportacao);
            this.splitContainer1.Panel1.Controls.Add(this.chkEntregaParc);
            this.splitContainer1.Panel1.Controls.Add(this.cbxVolumeUnico);
            this.splitContainer1.Panel1.Controls.Add(this.lblTotal);
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.nudValorUnit);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.nudQtd);
            this.splitContainer1.Panel1.Controls.Add(this.txtDescricao);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodigo);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnOK);
            this.splitContainer1.Size = new System.Drawing.Size(621, 391);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 0;
            // 
            // ensProduto
            // 
            this.ensProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensProduto.BindingField = null;
            this.ensProduto.DesabilitarAutoCompletar = false;
            this.ensProduto.DesabilitarChekBox = true;
            this.ensProduto.DesabilitarLupa = false;
            this.ensProduto.DesabilitarSeta = false;
            this.ensProduto.EntidadeSelecionada = null;
            this.ensProduto.FormSelecao = null;
            this.ensProduto.LiberadoQuandoCadastroUtilizado = false;
            this.ensProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensProduto.Location = new System.Drawing.Point(135, 13);
            this.ensProduto.ModoVisualizacaoGrid = null;
            this.ensProduto.Name = "ensProduto";
            this.ensProduto.ParametrosBuscaObrigatorios = null;
            this.ensProduto.Size = new System.Drawing.Size(404, 23);
            this.ensProduto.TabIndex = 0;
            this.ensProduto.EntityChange += new System.EventHandler(this.ensProduto_EntityChange);
            // 
            // ensNCM
            // 
            this.ensNCM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensNCM.BindingField = null;
            this.ensNCM.DesabilitarAutoCompletar = false;
            this.ensNCM.DesabilitarChekBox = false;
            this.ensNCM.DesabilitarLupa = false;
            this.ensNCM.DesabilitarSeta = false;
            this.ensNCM.Enabled = false;
            this.ensNCM.EntidadeSelecionada = null;
            this.ensNCM.FormSelecao = null;
            this.ensNCM.LiberadoQuandoCadastroUtilizado = false;
            this.ensNCM.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensNCM.Location = new System.Drawing.Point(134, 116);
            this.ensNCM.ModoVisualizacaoGrid = null;
            this.ensNCM.Name = "ensNCM";
            this.ensNCM.ParametrosBuscaObrigatorios = null;
            this.ensNCM.Size = new System.Drawing.Size(428, 23);
            this.ensNCM.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 83;
            this.label7.Text = "Produto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 80;
            this.label6.Text = "Data Entrega";
            // 
            // dtpDataEntregaLinha
            // 
            this.dtpDataEntregaLinha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntregaLinha.Location = new System.Drawing.Point(134, 142);
            this.dtpDataEntregaLinha.Name = "dtpDataEntregaLinha";
            this.dtpDataEntregaLinha.Size = new System.Drawing.Size(122, 20);
            this.dtpDataEntregaLinha.TabIndex = 8;
            // 
            // lnkDetalhesPrincipal
            // 
            this.lnkDetalhesPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDetalhesPrincipal.AutoSize = true;
            this.lnkDetalhesPrincipal.Location = new System.Drawing.Point(545, 18);
            this.lnkDetalhesPrincipal.Name = "lnkDetalhesPrincipal";
            this.lnkDetalhesPrincipal.Size = new System.Drawing.Size(49, 13);
            this.lnkDetalhesPrincipal.TabIndex = 1;
            this.lnkDetalhesPrincipal.TabStop = true;
            this.lnkDetalhesPrincipal.Text = "Detalhes";
            this.lnkDetalhesPrincipal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetalhesPrincipal_LinkClicked);
            // 
            // chkRastrearMP
            // 
            this.chkRastrearMP.AutoSize = true;
            this.chkRastrearMP.Location = new System.Drawing.Point(134, 237);
            this.chkRastrearMP.Name = "chkRastrearMP";
            this.chkRastrearMP.Size = new System.Drawing.Size(133, 17);
            this.chkRastrearMP.TabIndex = 12;
            this.chkRastrearMP.Text = "Rastrear Matéria Prima";
            this.chkRastrearMP.UseVisualStyleBackColor = true;
            // 
            // txtInfoEspeciais
            // 
            this.txtInfoEspeciais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoEspeciais.Location = new System.Drawing.Point(134, 260);
            this.txtInfoEspeciais.MaxLength = 255;
            this.txtInfoEspeciais.Name = "txtInfoEspeciais";
            this.txtInfoEspeciais.Size = new System.Drawing.Size(365, 20);
            this.txtInfoEspeciais.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Inf. Especiais";
            // 
            // chkExportacao
            // 
            this.chkExportacao.AutoSize = true;
            this.chkExportacao.Location = new System.Drawing.Point(134, 214);
            this.chkExportacao.Name = "chkExportacao";
            this.chkExportacao.Size = new System.Drawing.Size(80, 17);
            this.chkExportacao.TabIndex = 11;
            this.chkExportacao.Text = "Exportação";
            this.chkExportacao.UseVisualStyleBackColor = true;
            // 
            // chkEntregaParc
            // 
            this.chkEntregaParc.AutoSize = true;
            this.chkEntregaParc.Location = new System.Drawing.Point(134, 168);
            this.chkEntregaParc.Name = "chkEntregaParc";
            this.chkEntregaParc.Size = new System.Drawing.Size(136, 17);
            this.chkEntregaParc.TabIndex = 9;
            this.chkEntregaParc.Text = "Permite Entrega Parcial";
            this.chkEntregaParc.UseVisualStyleBackColor = true;
            // 
            // cbxVolumeUnico
            // 
            this.cbxVolumeUnico.AutoSize = true;
            this.cbxVolumeUnico.Checked = true;
            this.cbxVolumeUnico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxVolumeUnico.Location = new System.Drawing.Point(134, 191);
            this.cbxVolumeUnico.Name = "cbxVolumeUnico";
            this.cbxVolumeUnico.Size = new System.Drawing.Size(92, 17);
            this.cbxVolumeUnico.TabIndex = 10;
            this.cbxVolumeUnico.Text = "Volume Único";
            this.cbxVolumeUnico.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(371, 92);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 60;
            this.lblTotal.Text = "Total: ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(97, 119);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 64;
            this.label21.Text = "NCM";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(222, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 59;
            this.label15.Text = "Valor Unit.";
            // 
            // nudValorUnit
            // 
            this.nudValorUnit.DecimalPlaces = 2;
            this.nudValorUnit.Location = new System.Drawing.Point(284, 90);
            this.nudValorUnit.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudValorUnit.Name = "nudValorUnit";
            this.nudValorUnit.Size = new System.Drawing.Size(72, 20);
            this.nudValorUnit.TabIndex = 5;
            this.nudValorUnit.ValueChanged += new System.EventHandler(this.nudValorUnit_ValueChanged);
            this.nudValorUnit.Click += new System.EventHandler(this.nudValorUnit_Click);
            this.nudValorUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudValorUnit_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Qtd";
            // 
            // nudQtd
            // 
            this.nudQtd.DecimalPlaces = 5;
            this.nudQtd.Location = new System.Drawing.Point(134, 90);
            this.nudQtd.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQtd.Name = "nudQtd";
            this.nudQtd.Size = new System.Drawing.Size(66, 20);
            this.nudQtd.TabIndex = 4;
            this.nudQtd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtd.ValueChanged += new System.EventHandler(this.nudQtd_ValueChanged);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(134, 64);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(365, 20);
            this.txtDescricao.TabIndex = 3;
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Descrição Faturamento";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Location = new System.Drawing.Point(134, 38);
            this.txtCodigo.MaxLength = 15;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(365, 20);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Código Faturamento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(534, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CadPedidoSimplificadoItemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(621, 391);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CadPedidoSimplificadoItemForm";
            this.Text = "Linha do Pedido";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudValorUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudQtd;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRastrearMP;
        private System.Windows.Forms.TextBox txtInfoEspeciais;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkExportacao;
        private System.Windows.Forms.CheckBox chkEntregaParc;
        private System.Windows.Forms.CheckBox cbxVolumeUnico;
        private System.Windows.Forms.LinkLabel lnkDetalhesPrincipal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDataEntregaLinha;
        private System.Windows.Forms.Label label7;
        private IWTDotNetLib.IWTEntitySelection ensNCM;
        private IWTDotNetLib.IWTEntitySelection ensProduto;
    }
}