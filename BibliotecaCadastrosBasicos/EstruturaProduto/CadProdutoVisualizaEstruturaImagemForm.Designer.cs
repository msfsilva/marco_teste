using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos.EstruturaProduto
{
    partial class CadProdutoVisualizaEstruturaImagemForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarcode = new IWTDotNetLib.IWTTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.iwtTreeDisplay1 = new IWTTreeComponent.IWTTreeDisplay(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pcbImagem = new System.Windows.Forms.PictureBox();
            this.ensProduto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.rdbBarcode = new System.Windows.Forms.RadioButton();
            this.rdbProduto = new System.Windows.Forms.RadioButton();
            this.btnHistorico = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdbProduto);
            this.splitContainer1.Panel1.Controls.Add(this.rdbBarcode);
            this.splitContainer1.Panel1.Controls.Add(this.ensProduto);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtBarcode);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(758, 605);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Produto";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.BindingField = null;
            this.txtBarcode.DebugMode = false;
            this.txtBarcode.LiberadoQuandoCadastroUtilizado = false;
            this.txtBarcode.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBarcode.Location = new System.Drawing.Point(104, 12);
            this.txtBarcode.ModoBarcode = true;
            this.txtBarcode.ModoBusca = false;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.NaoLimparDepoisBarcode = false;
            this.txtBarcode.ShortcutsEnabled = false;
            this.txtBarcode.Size = new System.Drawing.Size(611, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.OperacaoBarcodeEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBarcodeEncerradaDelegate(this.txtBarcode_OperacaoBarcodeEncerrada);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código de Barras";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnHistorico);
            this.splitContainer2.Size = new System.Drawing.Size(758, 517);
            this.splitContainer2.SplitterDistance = 465;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(758, 465);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.iwtTreeDisplay1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(750, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Estrutura";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // iwtTreeDisplay1
            // 
            this.iwtTreeDisplay1.AllowDrop = true;
            this.iwtTreeDisplay1.Arvore = null;
            this.iwtTreeDisplay1.AutoScroll = true;
            this.iwtTreeDisplay1.BackColor = System.Drawing.Color.White;
            this.iwtTreeDisplay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.iwtTreeDisplay1.CtrlPressed = false;
            this.iwtTreeDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iwtTreeDisplay1.Location = new System.Drawing.Point(3, 3);
            this.iwtTreeDisplay1.Name = "iwtTreeDisplay1";
            this.iwtTreeDisplay1.ReadOnly = false;
            this.iwtTreeDisplay1.Size = new System.Drawing.Size(744, 433);
            this.iwtTreeDisplay1.TabIndex = 0;
            this.iwtTreeDisplay1.Text = "iwtTreeDisplay1";
            this.iwtTreeDisplay1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.iwtTreeDisplay1_MouseDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pcbImagem);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(750, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Imagem";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pcbImagem
            // 
            this.pcbImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbImagem.Location = new System.Drawing.Point(3, 3);
            this.pcbImagem.Name = "pcbImagem";
            this.pcbImagem.Size = new System.Drawing.Size(744, 433);
            this.pcbImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbImagem.TabIndex = 11;
            this.pcbImagem.TabStop = false;
            // 
            // ensProduto
            // 
            this.ensProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensProduto.BindingField = null;
            this.ensProduto.ColunasDropdown = null;
            this.ensProduto.DesabilitarAutoCompletar = false;
            this.ensProduto.DesabilitarChekBox = true;
            this.ensProduto.DesabilitarLupa = true;
            this.ensProduto.DesabilitarSeta = false;
            this.ensProduto.EntidadeSelecionada = null;
            this.ensProduto.FormSelecao = null;
            this.ensProduto.LiberadoQuandoCadastroUtilizado = false;
            this.ensProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensProduto.Location = new System.Drawing.Point(104, 38);
            this.ensProduto.ModoVisualizacaoGrid = null;
            this.ensProduto.Name = "ensProduto";
            this.ensProduto.ParametroBuscaGuiada = null;
            this.ensProduto.ParametrosBuscaObrigatorios = null;
            this.ensProduto.Size = new System.Drawing.Size(611, 23);
            this.ensProduto.TabIndex = 2;
            this.ensProduto.EntityChange += new System.EventHandler(this.ensProduto_EntityChange);
            // 
            // rdbBarcode
            // 
            this.rdbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbBarcode.AutoSize = true;
            this.rdbBarcode.Checked = true;
            this.rdbBarcode.Location = new System.Drawing.Point(721, 15);
            this.rdbBarcode.Name = "rdbBarcode";
            this.rdbBarcode.Size = new System.Drawing.Size(14, 13);
            this.rdbBarcode.TabIndex = 1;
            this.rdbBarcode.TabStop = true;
            this.rdbBarcode.UseVisualStyleBackColor = true;
            this.rdbBarcode.CheckedChanged += new System.EventHandler(this.rdbBarcode_CheckedChanged);
            // 
            // rdbProduto
            // 
            this.rdbProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.Location = new System.Drawing.Point(721, 43);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(14, 13);
            this.rdbProduto.TabIndex = 3;
            this.rdbProduto.UseVisualStyleBackColor = true;
            // 
            // btnHistorico
            // 
            this.btnHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorico.LiberadoQuandoCadastroUtilizado = false;
            this.btnHistorico.Location = new System.Drawing.Point(610, 13);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(136, 23);
            this.btnHistorico.TabIndex = 0;
            this.btnHistorico.Text = "Impressão e Histórico";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // CadProdutoVisualizaEstruturaImagemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(758, 605);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CadProdutoVisualizaEstruturaImagemForm";
            this.Text = "Visualizar Estrura e Imagem do Produto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private IWTTextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pcbImagem;
        private IWTTreeComponent.IWTTreeDisplay iwtTreeDisplay1;
        private System.Windows.Forms.Label label2;
        private IWTEntitySelection ensProduto;
        private System.Windows.Forms.RadioButton rdbProduto;
        private System.Windows.Forms.RadioButton rdbBarcode;
        private IWTButton btnHistorico;
    }
}