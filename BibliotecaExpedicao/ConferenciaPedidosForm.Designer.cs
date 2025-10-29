using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IWTCustomControls;

namespace BibliotecaExpedicao
{
    partial class ConferenciaPedidosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            this.timerCaixa = new Timer(this.components);
            this.label1 = new Label();
            this.txtBarcodeCaixa = new BarcodeTextBox(this.components);
            this.rdbBarCode = new RadioButton();
            this.rdbManual = new RadioButton();
            this.btnCaixa = new Button();
            this.grbModoOperacao = new GroupBox();
            this.grbCaixa = new GroupBox();
            this.splitContainer1 = new SplitContainer();
            this.groupBox1 = new GroupBox();
            this.lblItem = new Label();
            this.lblCliente = new Label();
            this.lblPedido = new Label();
            this.lblPallet = new Label();
            this.label6 = new Label();
            this.lblUsuario = new Label();
            this.label5 = new Label();
            this.lblTempo = new Label();
            this.label3 = new Label();
            this.grbItem = new GroupBox();
            this.txtBarcodeItem = new BarcodeTextBox(this.components);
            this.btnItem = new Button();
            this.label2 = new Label();
            this.splitContainer2 = new SplitContainer();
            this.splitContainer3 = new SplitContainer();
            this.lstDisponiveis = new ListBox();
            this.lstConferidos = new ListBox();
            this.btnCancelar = new Button();
            this.btnSalvar = new Button();
            this.timerItem = new Timer(this.components);
            this.timerConferencia = new Timer(this.components);
            this.grbModoOperacao.SuspendLayout();
            this.grbCaixa.SuspendLayout();
            ((ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbItem.SuspendLayout();
            ((ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerCaixa
            // 
            this.timerCaixa.Tick += new EventHandler(this.timerCaixa_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificador da OC";
            // 
            // txtBarcodeCaixa
            // 
            this.txtBarcodeCaixa.Location = new Point(126, 17);
            this.txtBarcodeCaixa.Name = "txtBarcodeCaixa";
            this.txtBarcodeCaixa.Size = new Size(149, 20);
            this.txtBarcodeCaixa.TabIndex = 0;
            this.txtBarcodeCaixa.TextChanged += new EventHandler(this.txtBarcodeCaixa_TextChanged);
            this.txtBarcodeCaixa.KeyDown += new KeyEventHandler(this.txtBarcodeCaixa_KeyDown);
            // 
            // rdbBarCode
            // 
            this.rdbBarCode.AutoSize = true;
            this.rdbBarCode.Checked = true;
            this.rdbBarCode.Location = new Point(6, 19);
            this.rdbBarCode.Name = "rdbBarCode";
            this.rdbBarCode.Size = new Size(91, 17);
            this.rdbBarCode.TabIndex = 2;
            this.rdbBarCode.TabStop = true;
            this.rdbBarCode.Text = "Código Barras";
            this.rdbBarCode.UseVisualStyleBackColor = true;
            this.rdbBarCode.CheckedChanged += new EventHandler(this.rdbBarCode_CheckedChanged);
            // 
            // rdbManual
            // 
            this.rdbManual.AutoSize = true;
            this.rdbManual.Location = new Point(97, 19);
            this.rdbManual.Name = "rdbManual";
            this.rdbManual.Size = new Size(60, 17);
            this.rdbManual.TabIndex = 3;
            this.rdbManual.Text = "Manual";
            this.rdbManual.UseVisualStyleBackColor = true;
            this.rdbManual.CheckedChanged += new EventHandler(this.rdbManual_CheckedChanged);
            // 
            // btnCaixa
            // 
            this.btnCaixa.Enabled = false;
            this.btnCaixa.Location = new Point(281, 15);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new Size(47, 23);
            this.btnCaixa.TabIndex = 1;
            this.btnCaixa.Text = "OK";
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Click += new EventHandler(this.btnCaixa_Click);
            // 
            // grbModoOperacao
            // 
            this.grbModoOperacao.Controls.Add(this.rdbBarCode);
            this.grbModoOperacao.Controls.Add(this.rdbManual);
            this.grbModoOperacao.Location = new Point(12, 12);
            this.grbModoOperacao.Name = "grbModoOperacao";
            this.grbModoOperacao.Size = new Size(185, 51);
            this.grbModoOperacao.TabIndex = 5;
            this.grbModoOperacao.TabStop = false;
            this.grbModoOperacao.Text = "Modo de Operação";
            // 
            // grbCaixa
            // 
            this.grbCaixa.Controls.Add(this.label1);
            this.grbCaixa.Controls.Add(this.txtBarcodeCaixa);
            this.grbCaixa.Controls.Add(this.btnCaixa);
            this.grbCaixa.Location = new Point(245, 12);
            this.grbCaixa.Name = "grbCaixa";
            this.grbCaixa.Size = new Size(355, 51);
            this.grbCaixa.TabIndex = 0;
            this.grbCaixa.TabStop = false;
            this.grbCaixa.Text = "Seleção da OC";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblPallet);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.lblUsuario);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.lblTempo);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.grbItem);
            this.splitContainer1.Panel1.Controls.Add(this.grbModoOperacao);
            this.splitContainer1.Panel1.Controls.Add(this.grbCaixa);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new Size(879, 592);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblItem);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.lblPedido);
            this.groupBox1.Location = new Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(588, 68);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pedido Selecionado";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new Point(10, 42);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new Size(0, 13);
            this.lblItem.TabIndex = 2;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new Point(193, 24);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new Size(0, 13);
            this.lblCliente.TabIndex = 1;
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.Location = new Point(10, 24);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new Size(0, 13);
            this.lblPedido.TabIndex = 0;
            // 
            // lblPallet
            // 
            this.lblPallet.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblPallet.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblPallet.Location = new Point(726, 93);
            this.lblPallet.Name = "lblPallet";
            this.lblPallet.Size = new Size(150, 31);
            this.lblPallet.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new Point(636, 102);
            this.label6.Name = "label6";
            this.label6.Size = new Size(33, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Pallet";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblUsuario.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new Point(726, 48);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new Size(150, 31);
            this.lblUsuario.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new Point(636, 57);
            this.label5.Name = "label5";
            this.label5.Size = new Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Usuário";
            // 
            // lblTempo
            // 
            this.lblTempo.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblTempo.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new Point(726, 3);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new Size(150, 31);
            this.lblTempo.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new Point(636, 12);
            this.label3.Name = "label3";
            this.label3.Size = new Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tempo Restante:";
            // 
            // grbItem
            // 
            this.grbItem.Controls.Add(this.txtBarcodeItem);
            this.grbItem.Controls.Add(this.btnItem);
            this.grbItem.Controls.Add(this.label2);
            this.grbItem.Enabled = false;
            this.grbItem.Location = new Point(12, 143);
            this.grbItem.Name = "grbItem";
            this.grbItem.Size = new Size(588, 51);
            this.grbItem.TabIndex = 1;
            this.grbItem.TabStop = false;
            this.grbItem.Text = "Conferência Item";
            // 
            // txtBarcodeItem
            // 
            this.txtBarcodeItem.AcceptsReturn = true;
            this.txtBarcodeItem.Location = new Point(119, 18);
            this.txtBarcodeItem.Multiline = true;
            this.txtBarcodeItem.Name = "txtBarcodeItem";
            this.txtBarcodeItem.Size = new Size(389, 20);
            this.txtBarcodeItem.TabIndex = 0;
            this.txtBarcodeItem.TextChanged += new EventHandler(this.txtBarcodeItem_TextChanged);
            this.txtBarcodeItem.KeyDown += new KeyEventHandler(this.txtBarcodeItem_KeyDown);
            // 
            // btnItem
            // 
            this.btnItem.Enabled = false;
            this.btnItem.Location = new Point(514, 16);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new Size(47, 23);
            this.btnItem.TabIndex = 1;
            this.btnItem.Text = "OK";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new EventHandler(this.btnItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new Size(103, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Identificador do Item";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = DockStyle.Fill;
            this.splitContainer2.FixedPanel = FixedPanel.Panel2;
            this.splitContainer2.Location = new Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btnSalvar);
            this.splitContainer2.Size = new Size(879, 384);
            this.splitContainer2.SplitterDistance = 337;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = DockStyle.Fill;
            this.splitContainer3.Location = new Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lstDisponiveis);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lstConferidos);
            this.splitContainer3.Size = new Size(879, 337);
            this.splitContainer3.SplitterDistance = 435;
            this.splitContainer3.TabIndex = 0;
            // 
            // lstDisponiveis
            // 
            this.lstDisponiveis.Dock = DockStyle.Fill;
            this.lstDisponiveis.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lstDisponiveis.FormattingEnabled = true;
            this.lstDisponiveis.Location = new Point(0, 0);
            this.lstDisponiveis.Name = "lstDisponiveis";
            this.lstDisponiveis.Size = new Size(435, 337);
            this.lstDisponiveis.Sorted = true;
            this.lstDisponiveis.TabIndex = 0;
            this.lstDisponiveis.SelectedValueChanged += new EventHandler(this.lstDisponiveis_SelectedValueChanged);
            this.lstDisponiveis.KeyDown += new KeyEventHandler(this.lstDisponiveis_KeyDown);
            // 
            // lstConferidos
            // 
            this.lstConferidos.Dock = DockStyle.Fill;
            this.lstConferidos.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lstConferidos.FormattingEnabled = true;
            this.lstConferidos.Location = new Point(0, 0);
            this.lstConferidos.Name = "lstConferidos";
            this.lstConferidos.Size = new Size(440, 337);
            this.lstConferidos.Sorted = true;
            this.lstConferidos.TabIndex = 0;
            this.lstConferidos.SelectedValueChanged += new EventHandler(this.lstConferidos_SelectedValueChanged);
            this.lstConferidos.KeyDown += new KeyEventHandler(this.lstConferidos_KeyDown);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new Point(12, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new Point(747, 8);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new Size(120, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar Conferência";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);
            // 
            // timerItem
            // 
            this.timerItem.Tick += new EventHandler(this.timerItem_Tick);
            // 
            // timerConferencia
            // 
            this.timerConferencia.Tick += new EventHandler(this.timerConferencia_Tick);
            // 
            // ConferenciaPedidosForm
            // 
            this.AutoScaleMode = AutoScaleMode.Inherit;
            this.ClientSize = new Size(879, 592);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConferenciaPedidosForm";
            this.Text = "Conferência de Pedidos";
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new EventHandler(this.MainForm_Load);
            this.Shown += new EventHandler(this.MainForm_Shown);
            this.grbModoOperacao.ResumeLayout(false);
            this.grbModoOperacao.PerformLayout();
            this.grbCaixa.ResumeLayout(false);
            this.grbCaixa.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbItem.ResumeLayout(false);
            this.grbItem.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Timer timerCaixa;
        private Label label1;
        private BarcodeTextBox txtBarcodeCaixa;
        private RadioButton rdbBarCode;
        private RadioButton rdbManual;
        private Button btnCaixa;
        private GroupBox grbModoOperacao;
        private GroupBox grbCaixa;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button btnCancelar;
        private Button btnSalvar;
        private GroupBox grbItem;
        private Button btnItem;
        private Label label2;
        private ListBox lstDisponiveis;
        private ListBox lstConferidos;
        private Timer timerItem;
        private Timer timerConferencia;
        private Label lblTempo;
        private Label label3;
        private Label lblUsuario;
        private Label label5;
        private Label lblPallet;
        private Label label6;
        private BarcodeTextBox txtBarcodeItem;
        private GroupBox groupBox1;
        private Label lblItem;
        private Label lblCliente;
        private Label lblPedido;
    }
}

