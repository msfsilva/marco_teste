namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class GerarOPForm
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
            this.rdbData = new System.Windows.Forms.RadioButton();
            this.gbxData = new System.Windows.Forms.GroupBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbOcPos = new System.Windows.Forms.RadioButton();
            this.rdbPps = new System.Windows.Forms.RadioButton();
            this.gbxPps = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPps = new System.Windows.Forms.TextBox();
            this.gbxOcPos = new System.Windows.Forms.GroupBox();
            this.txtOc = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNaoKits = new System.Windows.Forms.RadioButton();
            this.rdbKits = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbTodosPedidos = new System.Windows.Forms.RadioButton();
            this.rdbProduto = new System.Windows.Forms.RadioButton();
            this.grbProduto = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ensProduto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.gbxData.SuspendLayout();
            this.gbxPps.SuspendLayout();
            this.gbxOcPos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbProduto.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbData
            // 
            this.rdbData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbData.AutoSize = true;
            this.rdbData.Location = new System.Drawing.Point(368, 85);
            this.rdbData.Name = "rdbData";
            this.rdbData.Size = new System.Drawing.Size(14, 13);
            this.rdbData.TabIndex = 2;
            this.rdbData.UseVisualStyleBackColor = true;
            this.rdbData.CheckedChanged += new System.EventHandler(this.rdbData_CheckedChanged);
            // 
            // gbxData
            // 
            this.gbxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxData.Controls.Add(this.dtpData);
            this.gbxData.Controls.Add(this.label4);
            this.gbxData.Enabled = false;
            this.gbxData.Location = new System.Drawing.Point(12, 75);
            this.gbxData.Name = "gbxData";
            this.gbxData.Size = new System.Drawing.Size(350, 57);
            this.gbxData.TabIndex = 3;
            this.gbxData.TabStop = false;
            this.gbxData.Text = "Data de Entrega";
            // 
            // dtpData
            // 
            this.dtpData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(60, 16);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(273, 20);
            this.dtpData.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data";
            // 
            // rdbOcPos
            // 
            this.rdbOcPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbOcPos.AutoSize = true;
            this.rdbOcPos.Location = new System.Drawing.Point(368, 160);
            this.rdbOcPos.Name = "rdbOcPos";
            this.rdbOcPos.Size = new System.Drawing.Size(14, 13);
            this.rdbOcPos.TabIndex = 4;
            this.rdbOcPos.UseVisualStyleBackColor = true;
            this.rdbOcPos.CheckedChanged += new System.EventHandler(this.rdbOcPos_CheckedChanged);
            // 
            // rdbPps
            // 
            this.rdbPps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbPps.AutoSize = true;
            this.rdbPps.Checked = true;
            this.rdbPps.Location = new System.Drawing.Point(368, 31);
            this.rdbPps.Name = "rdbPps";
            this.rdbPps.Size = new System.Drawing.Size(14, 13);
            this.rdbPps.TabIndex = 0;
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
            this.gbxPps.Size = new System.Drawing.Size(350, 57);
            this.gbxPps.TabIndex = 1;
            this.gbxPps.TabStop = false;
            this.gbxPps.Text = "Semana de Entrega (AASS)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Semana";
            // 
            // txtPps
            // 
            this.txtPps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPps.Location = new System.Drawing.Point(60, 19);
            this.txtPps.Name = "txtPps";
            this.txtPps.Size = new System.Drawing.Size(273, 20);
            this.txtPps.TabIndex = 0;
            // 
            // gbxOcPos
            // 
            this.gbxOcPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOcPos.Controls.Add(this.txtOc);
            this.gbxOcPos.Controls.Add(this.label18);
            this.gbxOcPos.Controls.Add(this.txtPos);
            this.gbxOcPos.Controls.Add(this.label2);
            this.gbxOcPos.Enabled = false;
            this.gbxOcPos.Location = new System.Drawing.Point(12, 138);
            this.gbxOcPos.Name = "gbxOcPos";
            this.gbxOcPos.Size = new System.Drawing.Size(350, 61);
            this.gbxOcPos.TabIndex = 5;
            this.gbxOcPos.TabStop = false;
            this.gbxOcPos.Text = "Pedido";
            // 
            // txtOc
            // 
            this.txtOc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOc.AsciiOnly = true;
            this.txtOc.Location = new System.Drawing.Point(60, 19);
            this.txtOc.Mask = "AAAAAAAAAA";
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(214, 20);
            this.txtOc.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(280, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "/";
            // 
            // txtPos
            // 
            this.txtPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPos.Location = new System.Drawing.Point(298, 19);
            this.txtPos.Mask = "999";
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(35, 20);
            this.txtPos.TabIndex = 1;
            this.txtPos.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pedido";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 396);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(307, 396);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 38);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbNaoKits);
            this.groupBox1.Controls.Add(this.rdbKits);
            this.groupBox1.Controls.Add(this.rdbTodos);
            this.groupBox1.Location = new System.Drawing.Point(12, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 51);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Item";
            // 
            // rdbNaoKits
            // 
            this.rdbNaoKits.AutoSize = true;
            this.rdbNaoKits.Location = new System.Drawing.Point(201, 19);
            this.rdbNaoKits.Name = "rdbNaoKits";
            this.rdbNaoKits.Size = new System.Drawing.Size(108, 17);
            this.rdbNaoKits.TabIndex = 2;
            this.rdbNaoKits.TabStop = true;
            this.rdbNaoKits.Text = "Somente não Kits";
            this.rdbNaoKits.UseVisualStyleBackColor = true;
            // 
            // rdbKits
            // 
            this.rdbKits.AutoSize = true;
            this.rdbKits.Location = new System.Drawing.Point(95, 19);
            this.rdbKits.Name = "rdbKits";
            this.rdbKits.Size = new System.Drawing.Size(87, 17);
            this.rdbKits.TabIndex = 1;
            this.rdbKits.TabStop = true;
            this.rdbKits.Text = "Somente Kits";
            this.rdbKits.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Checked = true;
            this.rdbTodos.Location = new System.Drawing.Point(21, 19);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 0;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            // 
            // rdbTodosPedidos
            // 
            this.rdbTodosPedidos.AutoSize = true;
            this.rdbTodosPedidos.Location = new System.Drawing.Point(12, 283);
            this.rdbTodosPedidos.Name = "rdbTodosPedidos";
            this.rdbTodosPedidos.Size = new System.Drawing.Size(150, 17);
            this.rdbTodosPedidos.TabIndex = 7;
            this.rdbTodosPedidos.TabStop = true;
            this.rdbTodosPedidos.Text = "Todos Pedidos Pendentes";
            this.rdbTodosPedidos.UseVisualStyleBackColor = true;
            // 
            // rdbProduto
            // 
            this.rdbProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.Location = new System.Drawing.Point(368, 227);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(14, 13);
            this.rdbProduto.TabIndex = 6;
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // grbProduto
            // 
            this.grbProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbProduto.Controls.Add(this.ensProduto);
            this.grbProduto.Controls.Add(this.label5);
            this.grbProduto.Enabled = false;
            this.grbProduto.Location = new System.Drawing.Point(12, 205);
            this.grbProduto.Name = "grbProduto";
            this.grbProduto.Size = new System.Drawing.Size(350, 61);
            this.grbProduto.TabIndex = 9;
            this.grbProduto.TabStop = false;
            this.grbProduto.Text = "Produto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Produto";
            // 
            // ensProduto
            // 
            this.ensProduto.BindingField = null;
            this.ensProduto.DesabilitarAutoCompletar = false;
            this.ensProduto.DesabilitarChekBox = true;
            this.ensProduto.DesabilitarLupa = false;
            this.ensProduto.DesabilitarSeta = false;
            this.ensProduto.EntidadeSelecionada = null;
            this.ensProduto.FormSelecao = null;
            this.ensProduto.LiberadoQuandoCadastroUtilizado = false;
            this.ensProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensProduto.Location = new System.Drawing.Point(60, 19);
            this.ensProduto.ModoVisualizacaoGrid = null;
            this.ensProduto.Name = "ensProduto";
            this.ensProduto.ParametrosBuscaObrigatorios = null;
            this.ensProduto.Size = new System.Drawing.Size(273, 23);
            this.ensProduto.TabIndex = 1;
            // 
            // GerarOPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(397, 442);
            this.Controls.Add(this.rdbProduto);
            this.Controls.Add(this.rdbTodosPedidos);
            this.Controls.Add(this.grbProduto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rdbData);
            this.Controls.Add(this.gbxData);
            this.Controls.Add(this.rdbOcPos);
            this.Controls.Add(this.rdbPps);
            this.Controls.Add(this.gbxPps);
            this.Controls.Add(this.gbxOcPos);
            this.Name = "GerarOPForm";
            this.Text = "Gerar Ordens de Produção e Planos de Corte";
            this.gbxData.ResumeLayout(false);
            this.gbxData.PerformLayout();
            this.gbxPps.ResumeLayout(false);
            this.gbxPps.PerformLayout();
            this.gbxOcPos.ResumeLayout(false);
            this.gbxOcPos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbProduto.ResumeLayout(false);
            this.grbProduto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbData;
        private System.Windows.Forms.GroupBox gbxData;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbOcPos;
        private System.Windows.Forms.RadioButton rdbPps;
        private System.Windows.Forms.GroupBox gbxPps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPps;
        private System.Windows.Forms.GroupBox gbxOcPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbNaoKits;
        private System.Windows.Forms.RadioButton rdbKits;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbTodosPedidos;
        private System.Windows.Forms.MaskedTextBox txtOc;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox txtPos;
        private System.Windows.Forms.RadioButton rdbProduto;
        private System.Windows.Forms.GroupBox grbProduto;
        private System.Windows.Forms.Label label5;
        private IWTDotNetLib.IWTEntitySelection ensProduto;
    }
}