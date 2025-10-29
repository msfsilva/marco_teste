namespace BibiliotecaGerenciamentoKB
{
    partial class ConfigCompraVisualizacaoForm
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
            this.nudEstoqueMeses = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudEstoqueMargemRevisaoKb = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudEstoqueDiasVermelho = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudEstoqueDiasAmarelo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudEstoqueDiasVerde = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueMeses)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueMargemRevisaoKb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasVermelho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasAmarelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasVerde)).BeginInit();
            this.SuspendLayout();
            // 
            // nudEstoqueMeses
            // 
            this.nudEstoqueMeses.Enabled = false;
            this.nudEstoqueMeses.Location = new System.Drawing.Point(249, 16);
            this.nudEstoqueMeses.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudEstoqueMeses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstoqueMeses.Name = "nudEstoqueMeses";
            this.nudEstoqueMeses.Size = new System.Drawing.Size(138, 20);
            this.nudEstoqueMeses.TabIndex = 5;
            this.nudEstoqueMeses.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quantidade de Meses para Média de Utilização";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudEstoqueMargemRevisaoKb);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.nudEstoqueDiasVermelho);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.nudEstoqueDiasAmarelo);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.nudEstoqueDiasVerde);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(15, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(418, 135);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Kanban";
            // 
            // nudEstoqueMargemRevisaoKb
            // 
            this.nudEstoqueMargemRevisaoKb.Location = new System.Drawing.Point(268, 100);
            this.nudEstoqueMargemRevisaoKb.Name = "nudEstoqueMargemRevisaoKb";
            this.nudEstoqueMargemRevisaoKb.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueMargemRevisaoKb.TabIndex = 10;
            this.nudEstoqueMargemRevisaoKb.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Margem (%) para aviso de revisão";
            // 
            // nudEstoqueDiasVermelho
            // 
            this.nudEstoqueDiasVermelho.Location = new System.Drawing.Point(268, 74);
            this.nudEstoqueDiasVermelho.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstoqueDiasVermelho.Name = "nudEstoqueDiasVermelho";
            this.nudEstoqueDiasVermelho.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueDiasVermelho.TabIndex = 8;
            this.nudEstoqueDiasVermelho.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dias de Utilização Média para Estoque Vermelho";
            // 
            // nudEstoqueDiasAmarelo
            // 
            this.nudEstoqueDiasAmarelo.Location = new System.Drawing.Point(268, 48);
            this.nudEstoqueDiasAmarelo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstoqueDiasAmarelo.Name = "nudEstoqueDiasAmarelo";
            this.nudEstoqueDiasAmarelo.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueDiasAmarelo.TabIndex = 6;
            this.nudEstoqueDiasAmarelo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dias de Utilização Média para Estoque Amarelo";
            // 
            // nudEstoqueDiasVerde
            // 
            this.nudEstoqueDiasVerde.Location = new System.Drawing.Point(268, 22);
            this.nudEstoqueDiasVerde.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstoqueDiasVerde.Name = "nudEstoqueDiasVerde";
            this.nudEstoqueDiasVerde.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueDiasVerde.TabIndex = 4;
            this.nudEstoqueDiasVerde.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dias de Utilização Média para Estoque Verde";
            // 
            // ConfigCompraVisualizacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(452, 200);
            this.Controls.Add(this.nudEstoqueMeses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Name = "ConfigCompraVisualizacaoForm";
            this.Text = "Configurações de Compra";
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueMeses)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueMargemRevisaoKb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasVermelho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasAmarelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasVerde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudEstoqueMeses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown nudEstoqueMargemRevisaoKb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudEstoqueDiasVermelho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudEstoqueDiasAmarelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudEstoqueDiasVerde;
        private System.Windows.Forms.Label label2;
    }
}