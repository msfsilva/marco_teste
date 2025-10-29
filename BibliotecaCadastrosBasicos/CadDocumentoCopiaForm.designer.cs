using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadDocumentoCopiaForm
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
            this.IdentificacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Identificacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.PermiteUtilizarOpLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.PermiteUtilizarOp = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkIDAuto = new IWTDotNetLib.IWTCheckBox(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensEstoque = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensCorredor = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.chk = new IWTDotNetLib.IWTCheckBox(this.components);
            this.txt = new IWTDotNetLib.IWTTextBox(this.components);
            this.ensPrateleira = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f = new IWTDotNetLib.IWTCheckBox(this.components);
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0 = new IWTDotNetLib.IWTTextBox(this.components);
            this.ensGaveta = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtCheckBox1 = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ensCorredor.SuspendLayout();
            this.ensPrateleira.SuspendLayout();
            this.ensGaveta.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.ensGaveta);
            this.splitContainer1.Panel1.Controls.Add(this.ensPrateleira);
            this.splitContainer1.Panel1.Controls.Add(this.ensCorredor);
            this.splitContainer1.Panel1.Controls.Add(this.ensEstoque);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.chkIDAuto);
            this.splitContainer1.Panel1.Controls.Add(this.IdentificacaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Identificacao);
            this.splitContainer1.Panel1.Controls.Add(this.PermiteUtilizarOpLabel);
            this.splitContainer1.Panel1.Controls.Add(this.PermiteUtilizarOp);
            this.splitContainer1.Size = new System.Drawing.Size(514, 249);
            this.splitContainer1.SplitterDistance = 183;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(427, 20);
            // 
            // IdentificacaoLabel
            // 
            this.IdentificacaoLabel.AutoSize = true;
            this.IdentificacaoLabel.BindingField = null;
            this.IdentificacaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.IdentificacaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.IdentificacaoLabel.Location = new System.Drawing.Point(126, 15);
            this.IdentificacaoLabel.Name = "IdentificacaoLabel";
            this.IdentificacaoLabel.Size = new System.Drawing.Size(68, 13);
            this.IdentificacaoLabel.TabIndex = 2;
            this.IdentificacaoLabel.Text = "Identificação";
            // 
            // Identificacao
            // 
            this.Identificacao.BindingField = "Identificacao";
            this.Identificacao.DebugMode = false;
            this.Identificacao.LiberadoQuandoCadastroUtilizado = false;
            this.Identificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Identificacao.Location = new System.Drawing.Point(200, 12);
            this.Identificacao.ModoBarcode = false;
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.Size = new System.Drawing.Size(175, 20);
            this.Identificacao.TabIndex = 1;
            // 
            // PermiteUtilizarOpLabel
            // 
            this.PermiteUtilizarOpLabel.AutoSize = true;
            this.PermiteUtilizarOpLabel.BindingField = null;
            this.PermiteUtilizarOpLabel.LiberadoQuandoCadastroUtilizado = false;
            this.PermiteUtilizarOpLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.PermiteUtilizarOpLabel.Location = new System.Drawing.Point(83, 158);
            this.PermiteUtilizarOpLabel.Name = "PermiteUtilizarOpLabel";
            this.PermiteUtilizarOpLabel.Size = new System.Drawing.Size(111, 13);
            this.PermiteUtilizarOpLabel.TabIndex = 10;
            this.PermiteUtilizarOpLabel.Text = "Permite Utilizar em OP";
            // 
            // PermiteUtilizarOp
            // 
            this.PermiteUtilizarOp.AutoSize = true;
            this.PermiteUtilizarOp.BindingField = "PermiteUtilizarOp";
            this.PermiteUtilizarOp.LiberadoQuandoCadastroUtilizado = false;
            this.PermiteUtilizarOp.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.PermiteUtilizarOp.Location = new System.Drawing.Point(200, 157);
            this.PermiteUtilizarOp.Name = "PermiteUtilizarOp";
            this.PermiteUtilizarOp.Size = new System.Drawing.Size(15, 14);
            this.PermiteUtilizarOp.TabIndex = 3;
            this.PermiteUtilizarOp.UseVisualStyleBackColor = true;
            // 
            // chkIDAuto
            // 
            this.chkIDAuto.AutoSize = true;
            this.chkIDAuto.BindingField = null;
            this.chkIDAuto.LiberadoQuandoCadastroUtilizado = false;
            this.chkIDAuto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkIDAuto.Location = new System.Drawing.Point(381, 14);
            this.chkIDAuto.Name = "chkIDAuto";
            this.chkIDAuto.Size = new System.Drawing.Size(79, 17);
            this.chkIDAuto.TabIndex = 0;
            this.chkIDAuto.Text = "Automático";
            this.chkIDAuto.UseVisualStyleBackColor = true;
            this.chkIDAuto.CheckedChanged += new System.EventHandler(this.chkIDAuto_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(104, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Estoque - Gaveta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(95, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Estoque - Prateleira";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(99, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Estoque - Corredor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(148, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Estoque";
            // 
            // ensEstoque
            // 
            this.ensEstoque.BindingField = null;
            this.ensEstoque.DesabilitarAutoCompletar = false;
            this.ensEstoque.DesabilitarChekBox = true;
            this.ensEstoque.DesabilitarLupa = false;
            this.ensEstoque.DesabilitarSeta = false;
            this.ensEstoque.EntidadeSelecionada = null;
            this.ensEstoque.FormSelecao = null;
            this.ensEstoque.LiberadoQuandoCadastroUtilizado = false;
            this.ensEstoque.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensEstoque.Location = new System.Drawing.Point(200, 38);
            this.ensEstoque.ModoVisualizacaoGrid = null;
            this.ensEstoque.Name = "ensEstoque";
            this.ensEstoque.ParametrosBuscaObrigatorios = null;
            this.ensEstoque.Size = new System.Drawing.Size(302, 23);
            this.ensEstoque.TabIndex = 2;
            this.ensEstoque.EntityChange += new System.EventHandler(this.ensEstoque_EntityChange);
            // 
            // ensCorredor
            // 
            this.ensCorredor.BindingField = null;
            this.ensCorredor.Controls.Add(this.chk);
            this.ensCorredor.Controls.Add(this.txt);
            this.ensCorredor.DesabilitarAutoCompletar = false;
            this.ensCorredor.DesabilitarChekBox = true;
            this.ensCorredor.DesabilitarLupa = false;
            this.ensCorredor.DesabilitarSeta = false;
            this.ensCorredor.EntidadeSelecionada = null;
            this.ensCorredor.FormSelecao = null;
            this.ensCorredor.LiberadoQuandoCadastroUtilizado = false;
            this.ensCorredor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensCorredor.Location = new System.Drawing.Point(200, 67);
            this.ensCorredor.ModoVisualizacaoGrid = null;
            this.ensCorredor.Name = "ensCorredor";
            this.ensCorredor.ParametrosBuscaObrigatorios = null;
            this.ensCorredor.Size = new System.Drawing.Size(302, 23);
            this.ensCorredor.TabIndex = 40;
            this.ensCorredor.EntityChange += new System.EventHandler(this.ensCorredor_EntityChange);
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
            this.chk.Location = new System.Drawing.Point(486, 5);
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
            this.txt.Size = new System.Drawing.Size(461, 20);
            this.txt.TabIndex = 0;
            // 
            // ensPrateleira
            // 
            this.ensPrateleira.BindingField = null;
            this.ensPrateleira.Controls.Add(this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f);
            this.ensPrateleira.Controls.Add(this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0);
            this.ensPrateleira.DesabilitarAutoCompletar = false;
            this.ensPrateleira.DesabilitarChekBox = true;
            this.ensPrateleira.DesabilitarLupa = false;
            this.ensPrateleira.DesabilitarSeta = false;
            this.ensPrateleira.EntidadeSelecionada = null;
            this.ensPrateleira.FormSelecao = null;
            this.ensPrateleira.LiberadoQuandoCadastroUtilizado = false;
            this.ensPrateleira.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensPrateleira.Location = new System.Drawing.Point(200, 96);
            this.ensPrateleira.ModoVisualizacaoGrid = null;
            this.ensPrateleira.Name = "ensPrateleira";
            this.ensPrateleira.ParametrosBuscaObrigatorios = null;
            this.ensPrateleira.Size = new System.Drawing.Size(302, 23);
            this.ensPrateleira.TabIndex = 41;
            this.ensPrateleira.EntityChange += new System.EventHandler(this.ensPrateleira_EntityChange);
            // 
            // object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f
            // 
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.AutoSize = true;
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.BindingField = "";
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.Checked = true;
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.CheckState = System.Windows.Forms.CheckState.Checked;
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.LiberadoQuandoCadastroUtilizado = false;
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.Location = new System.Drawing.Point(486, 5);
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.Name = "object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f";
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.Size = new System.Drawing.Size(15, 14);
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.TabIndex = 1;
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.UseVisualStyleBackColor = true;
            this.object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f.Visible = false;
            // 
            // object_ae774b32_53ed_4476_bd43_51aeb9730fc0
            // 
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.BindingField = "";
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.DebugMode = false;
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.LiberadoQuandoCadastroUtilizado = false;
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.Location = new System.Drawing.Point(0, 1);
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.ModoBarcode = false;
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.Name = "object_ae774b32_53ed_4476_bd43_51aeb9730fc0";
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.Size = new System.Drawing.Size(461, 20);
            this.object_ae774b32_53ed_4476_bd43_51aeb9730fc0.TabIndex = 0;
            // 
            // ensGaveta
            // 
            this.ensGaveta.BindingField = null;
            this.ensGaveta.Controls.Add(this.iwtCheckBox1);
            this.ensGaveta.Controls.Add(this.iwtTextBox1);
            this.ensGaveta.DesabilitarAutoCompletar = false;
            this.ensGaveta.DesabilitarChekBox = true;
            this.ensGaveta.DesabilitarLupa = false;
            this.ensGaveta.DesabilitarSeta = false;
            this.ensGaveta.EntidadeSelecionada = null;
            this.ensGaveta.FormSelecao = null;
            this.ensGaveta.LiberadoQuandoCadastroUtilizado = false;
            this.ensGaveta.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensGaveta.Location = new System.Drawing.Point(200, 125);
            this.ensGaveta.ModoVisualizacaoGrid = null;
            this.ensGaveta.Name = "ensGaveta";
            this.ensGaveta.ParametrosBuscaObrigatorios = null;
            this.ensGaveta.Size = new System.Drawing.Size(302, 23);
            this.ensGaveta.TabIndex = 42;
            // 
            // iwtCheckBox1
            // 
            this.iwtCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtCheckBox1.AutoSize = true;
            this.iwtCheckBox1.BindingField = "";
            this.iwtCheckBox1.Checked = true;
            this.iwtCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iwtCheckBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtCheckBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtCheckBox1.Location = new System.Drawing.Point(486, 5);
            this.iwtCheckBox1.Name = "iwtCheckBox1";
            this.iwtCheckBox1.Size = new System.Drawing.Size(15, 14);
            this.iwtCheckBox1.TabIndex = 1;
            this.iwtCheckBox1.UseVisualStyleBackColor = true;
            this.iwtCheckBox1.Visible = false;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox1.BindingField = "";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(0, 1);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.Size = new System.Drawing.Size(461, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // CadDocumentoCopiaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(514, 249);
            this.Name = "CadDocumentoCopiaForm";
            this.Text = "Adicionar Cópia";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ensCorredor.ResumeLayout(false);
            this.ensCorredor.PerformLayout();
            this.ensPrateleira.ResumeLayout(false);
            this.ensPrateleira.PerformLayout();
            this.ensGaveta.ResumeLayout(false);
            this.ensGaveta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel IdentificacaoLabel;
        private IWTDotNetLib.IWTTextBox Identificacao;
        private IWTDotNetLib.IWTLabel PermiteUtilizarOpLabel;
        private IWTDotNetLib.IWTCheckBox PermiteUtilizarOp;
        private IWTDotNetLib.IWTCheckBox chkIDAuto;
        private IWTDotNetLib.IWTLabel label5;
        private IWTDotNetLib.IWTLabel label4;
        private IWTDotNetLib.IWTLabel label3;
        private IWTDotNetLib.IWTLabel label2;
        private IWTEntitySelection ensGaveta;
        private IWTCheckBox iwtCheckBox1;
        private IWTTextBox iwtTextBox1;
        private IWTEntitySelection ensPrateleira;
        private IWTCheckBox object_0a5c2e06_b60f_453a_9cf3_46c94a1ee31f;
        private IWTTextBox object_ae774b32_53ed_4476_bd43_51aeb9730fc0;
        private IWTEntitySelection ensCorredor;
        private IWTCheckBox chk;
        private IWTTextBox txt;
        private IWTEntitySelection ensEstoque;
    }
} 
