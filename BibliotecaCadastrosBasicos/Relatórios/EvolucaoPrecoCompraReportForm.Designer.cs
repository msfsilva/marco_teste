namespace BibliotecaCadastrosBasicos.Relatórios
{
    partial class EvolucaoPrecoCompraReportForm
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
            this.iwtButton1 = new IWTDotNetLib.IWTButton(this.components);
            this.rdbC = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbB = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbA = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.dtpFim = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpInicio = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpInicio)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.iwtButton1);
            this.splitContainer1.Panel1.Controls.Add(this.rdbC);
            this.splitContainer1.Panel1.Controls.Add(this.rdbB);
            this.splitContainer1.Panel1.Controls.Add(this.rdbA);
            this.splitContainer1.Panel1.Controls.Add(this.rdbTodos);
            this.splitContainer1.Panel1.Controls.Add(this.dtpFim);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.dtpInicio);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(635, 594);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.TabIndex = 0;
            // 
            // iwtButton1
            // 
            this.iwtButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtButton1.Location = new System.Drawing.Point(548, 45);
            this.iwtButton1.Name = "iwtButton1";
            this.iwtButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtButton1.TabIndex = 8;
            this.iwtButton1.Text = "Gerar";
            this.iwtButton1.UseVisualStyleBackColor = true;
            this.iwtButton1.Click += new System.EventHandler(this.iwtButton1_Click);
            // 
            // rdbC
            // 
            this.rdbC.AutoSize = true;
            this.rdbC.BindingField = null;
            this.rdbC.LiberadoQuandoCadastroUtilizado = false;
            this.rdbC.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbC.Location = new System.Drawing.Point(263, 48);
            this.rdbC.Name = "rdbC";
            this.rdbC.Size = new System.Drawing.Size(77, 17);
            this.rdbC.TabIndex = 7;
            this.rdbC.Text = "Somente C";
            this.rdbC.UseVisualStyleBackColor = true;
            // 
            // rdbB
            // 
            this.rdbB.AutoSize = true;
            this.rdbB.BindingField = null;
            this.rdbB.LiberadoQuandoCadastroUtilizado = false;
            this.rdbB.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbB.Location = new System.Drawing.Point(180, 48);
            this.rdbB.Name = "rdbB";
            this.rdbB.Size = new System.Drawing.Size(77, 17);
            this.rdbB.TabIndex = 6;
            this.rdbB.Text = "Somente B";
            this.rdbB.UseVisualStyleBackColor = true;
            // 
            // rdbA
            // 
            this.rdbA.AutoSize = true;
            this.rdbA.BindingField = null;
            this.rdbA.LiberadoQuandoCadastroUtilizado = false;
            this.rdbA.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbA.Location = new System.Drawing.Point(97, 48);
            this.rdbA.Name = "rdbA";
            this.rdbA.Size = new System.Drawing.Size(77, 17);
            this.rdbA.TabIndex = 5;
            this.rdbA.Text = "Somente A";
            this.rdbA.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.BindingField = null;
            this.rdbTodos.Checked = true;
            this.rdbTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodos.Location = new System.Drawing.Point(14, 48);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 4;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            // 
            // dtpFim
            // 
            this.dtpFim.BindingField = null;
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.LiberadoQuandoCadastroUtilizado = false;
            this.dtpFim.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpFim.Location = new System.Drawing.Point(247, 15);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(116, 20);
            this.dtpFim.TabIndex = 3;
            this.dtpFim.Value = new System.DateTime(2017, 8, 11, 10, 33, 0, 132);
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(218, 21);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(23, 13);
            this.iwtLabel2.TabIndex = 2;
            this.iwtLabel2.Text = "Fim";
            // 
            // dtpInicio
            // 
            this.dtpInicio.BindingField = null;
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.LiberadoQuandoCadastroUtilizado = false;
            this.dtpInicio.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpInicio.Location = new System.Drawing.Point(51, 15);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(116, 20);
            this.dtpInicio.TabIndex = 1;
            this.dtpInicio.Value = new System.DateTime(2017, 8, 11, 10, 33, 0, 164);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(11, 21);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(34, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Início";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(635, 513);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // EvolucaoPrecoCompraReportForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(635, 594);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EvolucaoPrecoCompraReportForm";
            this.Text = "Evolução de Compra";
            this.Shown += new System.EventHandler(this.EvolucaoPrecoCompraReportForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpFim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private IWTDotNetLib.IWTDateTimePicker dtpFim;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTDateTimePicker dtpInicio;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTRadioButton rdbC;
        private IWTDotNetLib.IWTRadioButton rdbB;
        private IWTDotNetLib.IWTRadioButton rdbA;
        private IWTDotNetLib.IWTRadioButton rdbTodos;
        private IWTDotNetLib.IWTButton iwtButton1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}