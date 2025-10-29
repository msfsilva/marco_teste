namespace BibliotecaPedidos
{
    partial class PedidoEspelhoReportForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.chkExibirValores = new IWTDotNetLib.IWTCheckBox(this.components);
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 35);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1032, 545);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // chkExibirValores
            // 
            this.chkExibirValores.AutoSize = true;
            this.chkExibirValores.BindingField = null;
            this.chkExibirValores.Checked = true;
            this.chkExibirValores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExibirValores.LiberadoQuandoCadastroUtilizado = false;
            this.chkExibirValores.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkExibirValores.Location = new System.Drawing.Point(12, 9);
            this.chkExibirValores.Name = "chkExibirValores";
            this.chkExibirValores.Size = new System.Drawing.Size(89, 17);
            this.chkExibirValores.TabIndex = 1;
            this.chkExibirValores.Text = "Exibir Valores";
            this.chkExibirValores.UseVisualStyleBackColor = true;
            this.chkExibirValores.CheckedChanged += new System.EventHandler(this.chkExibirValores_CheckedChanged);
            // 
            // PedidoEspelhoReportForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1032, 580);
            this.Controls.Add(this.chkExibirValores);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "PedidoEspelhoReportForm";
            this.Text = "Pedido";
            this.Shown += new System.EventHandler(this.PedidoEspelhoReportForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private IWTDotNetLib.IWTCheckBox chkExibirValores;
    }
}