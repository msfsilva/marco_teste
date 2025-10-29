namespace EstoqueViewer
{
    partial class EstoqueViewerTestForm
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
            this.selecionaEstoqueDisplay1 = new EstoqueViewer.SelecionaEstoqueDisplay(this.components);
            this.SuspendLayout();
            // 
            // selecionaEstoqueDisplay1
            // 
            this.selecionaEstoqueDisplay1.AutoScroll = true;
            this.selecionaEstoqueDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selecionaEstoqueDisplay1.Estoque = null;
            this.selecionaEstoqueDisplay1.Location = new System.Drawing.Point(0, 0);
            this.selecionaEstoqueDisplay1.Name = "selecionaEstoqueDisplay1";
            this.selecionaEstoqueDisplay1.Size = new System.Drawing.Size(666, 512);
            this.selecionaEstoqueDisplay1.TabIndex = 0;
            this.selecionaEstoqueDisplay1.Text = "selecionaEstoqueDisplay1";
            // 
            // EstoqueViewerTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(666, 512);
            this.Controls.Add(this.selecionaEstoqueDisplay1);
            this.Name = "EstoqueViewerTestForm";
            this.Text = "EstoqueViewerTestForm";
            this.Shown += new System.EventHandler(this.EstoqueViewerTestForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private SelecionaEstoqueDisplay selecionaEstoqueDisplay1;
    }
}