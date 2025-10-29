using IWTDotNetLib;

namespace ModuloKits
{
    partial class ChamadaKitDetalhesForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusca = new IWTDotNetLib.IWTTextBox(this.components);
            this.lnkDesmarcarTodos = new System.Windows.Forms.LinkLabel();
            this.lnkMarcarTodos = new System.Windows.Forms.LinkLabel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.lnkDesmarcarTodos);
            this.splitContainer1.Panel2.Controls.Add(this.lnkMarcarTodos);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnContinuar);
            this.splitContainer1.Size = new System.Drawing.Size(828, 418);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(828, 323);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Busca";
            // 
            // txtBusca
            // 
            this.txtBusca.BindingField = null;
            this.txtBusca.DebugMode = false;
            this.txtBusca.LiberadoQuandoCadastroUtilizado = false;
            this.txtBusca.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBusca.Location = new System.Drawing.Point(233, 24);
            this.txtBusca.ModoBarcode = false;
            this.txtBusca.ModoBusca = true;
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.NaoLimparDepoisBarcode = false;
            this.txtBusca.Size = new System.Drawing.Size(363, 20);
            this.txtBusca.TabIndex = 14;
            this.txtBusca.OperacaoBuscaEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBuscaEncerradaDelegate(this.txtBusca_OperacaoBuscaEncerrada);
            // 
            // lnkDesmarcarTodos
            // 
            this.lnkDesmarcarTodos.AutoSize = true;
            this.lnkDesmarcarTodos.Location = new System.Drawing.Point(88, 8);
            this.lnkDesmarcarTodos.Name = "lnkDesmarcarTodos";
            this.lnkDesmarcarTodos.Size = new System.Drawing.Size(91, 13);
            this.lnkDesmarcarTodos.TabIndex = 13;
            this.lnkDesmarcarTodos.TabStop = true;
            this.lnkDesmarcarTodos.Text = "Desmarcar Todos";
            this.lnkDesmarcarTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDesmarcarTodos_LinkClicked);
            // 
            // lnkMarcarTodos
            // 
            this.lnkMarcarTodos.AutoSize = true;
            this.lnkMarcarTodos.Location = new System.Drawing.Point(9, 8);
            this.lnkMarcarTodos.Name = "lnkMarcarTodos";
            this.lnkMarcarTodos.Size = new System.Drawing.Size(73, 13);
            this.lnkMarcarTodos.TabIndex = 12;
            this.lnkMarcarTodos.TabStop = true;
            this.lnkMarcarTodos.Text = "Marcar Todos";
            this.lnkMarcarTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMarcarTodos_LinkClicked);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(7, 56);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinuar.Location = new System.Drawing.Point(741, 56);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 0;
            this.btnContinuar.Text = "Imprimir";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // ChamadaKitDetalhesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(828, 418);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ChamadaKitDetalhesForm";
            this.Text = "OPs para serem Impressas";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel lnkDesmarcarTodos;
        private System.Windows.Forms.LinkLabel lnkMarcarTodos;
        private System.Windows.Forms.Label label1;
        private IWTTextBox txtBusca;
    }
}