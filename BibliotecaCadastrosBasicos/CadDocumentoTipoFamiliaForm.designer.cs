using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadDocumentoTipoFamiliaForm
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.btnHistorico = new IWTDotNetLib.IWTButton(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDesativar = new IWTDotNetLib.IWTButton(this.components);
            this.btnRemover = new IWTDotNetLib.IWTButton(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReimprimirEtiqueta = new IWTDotNetLib.IWTButton(this.components);
            this.btnEditar = new IWTDotNetLib.IWTButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbrirDocumento = new IWTDotNetLib.IWTButton(this.components);
            this.btnAtivar = new IWTDotNetLib.IWTButton(this.components);
            this.btnAdicionar = new IWTDotNetLib.IWTButton(this.components);
            this.btnEtiqueta = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(758, 519);
            this.splitContainer1.SplitterDistance = 453;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(671, 20);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnHistorico);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(758, 453);
            this.splitContainer2.SplitterDistance = 566;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.CacheDados = null;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(566, 453);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnHistorico
            // 
            this.btnHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorico.LiberadoQuandoCadastroUtilizado = false;
            this.btnHistorico.Location = new System.Drawing.Point(3, 417);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(181, 23);
            this.btnHistorico.TabIndex = 5;
            this.btnHistorico.Text = "Histórico de Utilização da Cópia";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDesativar);
            this.groupBox3.Controls.Add(this.btnRemover);
            this.groupBox3.Location = new System.Drawing.Point(3, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 80);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remover Cópia";
            // 
            // btnDesativar
            // 
            this.btnDesativar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesativar.LiberadoQuandoCadastroUtilizado = false;
            this.btnDesativar.Location = new System.Drawing.Point(5, 19);
            this.btnDesativar.Name = "btnDesativar";
            this.btnDesativar.Size = new System.Drawing.Size(169, 23);
            this.btnDesativar.TabIndex = 0;
            this.btnDesativar.Text = "Desativar";
            this.btnDesativar.UseVisualStyleBackColor = true;
            this.btnDesativar.Click += new System.EventHandler(this.btnDesativar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemover.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemover.Location = new System.Drawing.Point(6, 48);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(168, 23);
            this.btnRemover.TabIndex = 1;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReimprimirEtiqueta);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Location = new System.Drawing.Point(3, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 77);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manutenção Cópia";
            // 
            // btnReimprimirEtiqueta
            // 
            this.btnReimprimirEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReimprimirEtiqueta.LiberadoQuandoCadastroUtilizado = false;
            this.btnReimprimirEtiqueta.Location = new System.Drawing.Point(5, 48);
            this.btnReimprimirEtiqueta.Name = "btnReimprimirEtiqueta";
            this.btnReimprimirEtiqueta.Size = new System.Drawing.Size(170, 23);
            this.btnReimprimirEtiqueta.TabIndex = 1;
            this.btnReimprimirEtiqueta.Text = "Reimprimir Etiqueta";
            this.btnReimprimirEtiqueta.UseVisualStyleBackColor = true;
            this.btnReimprimirEtiqueta.Click += new System.EventHandler(this.btnReimprimirEtiqueta_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditar.Location = new System.Drawing.Point(5, 19);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(170, 23);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAbrirDocumento);
            this.groupBox1.Controls.Add(this.btnAtivar);
            this.groupBox1.Controls.Add(this.btnAdicionar);
            this.groupBox1.Controls.Add(this.btnEtiqueta);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 137);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nova Cópia";
            // 
            // btnAbrirDocumento
            // 
            this.btnAbrirDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirDocumento.LiberadoQuandoCadastroUtilizado = false;
            this.btnAbrirDocumento.Location = new System.Drawing.Point(4, 48);
            this.btnAbrirDocumento.Name = "btnAbrirDocumento";
            this.btnAbrirDocumento.Size = new System.Drawing.Size(170, 23);
            this.btnAbrirDocumento.TabIndex = 1;
            this.btnAbrirDocumento.Text = "Abrir Documento";
            this.btnAbrirDocumento.UseVisualStyleBackColor = true;
            this.btnAbrirDocumento.Click += new System.EventHandler(this.btnAbrirDocumento_Click);
            // 
            // btnAtivar
            // 
            this.btnAtivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtivar.LiberadoQuandoCadastroUtilizado = false;
            this.btnAtivar.Location = new System.Drawing.Point(5, 108);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(169, 23);
            this.btnAtivar.TabIndex = 3;
            this.btnAtivar.Text = "Ativar";
            this.btnAtivar.UseVisualStyleBackColor = true;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.LiberadoQuandoCadastroUtilizado = false;
            this.btnAdicionar.Location = new System.Drawing.Point(5, 19);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(170, 23);
            this.btnAdicionar.TabIndex = 0;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEtiqueta
            // 
            this.btnEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEtiqueta.LiberadoQuandoCadastroUtilizado = false;
            this.btnEtiqueta.Location = new System.Drawing.Point(6, 79);
            this.btnEtiqueta.Name = "btnEtiqueta";
            this.btnEtiqueta.Size = new System.Drawing.Size(169, 23);
            this.btnEtiqueta.TabIndex = 2;
            this.btnEtiqueta.Text = "Imprimir Etiqueta";
            this.btnEtiqueta.UseVisualStyleBackColor = true;
            this.btnEtiqueta.Click += new System.EventHandler(this.btnEtiqueta_Click);
            // 
            // CadDocumentoTipoFamiliaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(758, 519);
            this.Name = "CadDocumentoTipoFamiliaForm";
            this.Text = "Cópias de Documento";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTButton btnAbrirDocumento;
        private IWTDotNetLib.IWTButton btnAtivar;
        private IWTDotNetLib.IWTButton btnAdicionar;
        private IWTDotNetLib.IWTButton btnEtiqueta;
        private System.Windows.Forms.GroupBox groupBox3;
        private IWTDotNetLib.IWTButton btnDesativar;
        private IWTDotNetLib.IWTButton btnRemover;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTButton btnReimprimirEtiqueta;
        private IWTDotNetLib.IWTButton btnEditar;
        private IWTDotNetLib.IWTButton btnHistorico;
        private IWTDotNetLib.IWTDataGridView dataGridView1;

    }
} 
