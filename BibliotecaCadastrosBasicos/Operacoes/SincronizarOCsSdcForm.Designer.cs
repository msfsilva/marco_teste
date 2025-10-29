namespace BibliotecaCadastrosBasicos.Operacoes
{
    partial class SincronizarOCsSdcForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ensFormaPagamento = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.btnConfirmar = new IWTDotNetLib.IWTButton(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtObservacoes = new IWTDotNetLib.IWTTextBox(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fornecedor:";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFornecedor.Location = new System.Drawing.Point(82, 21);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(0, 13);
            this.lblFornecedor.TabIndex = 1;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(82, 49);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 13);
            this.lblData.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(82, 77);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(0, 13);
            this.lblValor.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Forma de Pagamento:";
            // 
            // ensFormaPagamento
            // 
            this.ensFormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensFormaPagamento.BindingField = null;
            this.ensFormaPagamento.ColunasDropdown = null;
            this.ensFormaPagamento.DesabilitarAutoCompletar = false;
            this.ensFormaPagamento.DesabilitarChekBox = true;
            this.ensFormaPagamento.DesabilitarLupa = false;
            this.ensFormaPagamento.DesabilitarSeta = false;
            this.ensFormaPagamento.EntidadeSelecionada = null;
            this.ensFormaPagamento.FormSelecao = null;
            this.ensFormaPagamento.LiberadoQuandoCadastroUtilizado = false;
            this.ensFormaPagamento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFormaPagamento.Location = new System.Drawing.Point(120, 111);
            this.ensFormaPagamento.ModoVisualizacaoGrid = null;
            this.ensFormaPagamento.Name = "ensFormaPagamento";
            this.ensFormaPagamento.ParametroBuscaGuiada = null;
            this.ensFormaPagamento.ParametrosBuscaObrigatorios = null;
            this.ensFormaPagamento.Size = new System.Drawing.Size(487, 23);
            this.ensFormaPagamento.TabIndex = 9;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.LiberadoQuandoCadastroUtilizado = false;
            this.btnConfirmar.Location = new System.Drawing.Point(532, 253);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 10;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Observações:";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacoes.BindingField = null;
            this.txtObservacoes.DebugMode = false;
            this.txtObservacoes.LiberadoQuandoCadastroUtilizado = false;
            this.txtObservacoes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtObservacoes.Location = new System.Drawing.Point(120, 150);
            this.txtObservacoes.ModoBarcode = false;
            this.txtObservacoes.ModoBusca = false;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.NaoLimparDepoisBarcode = false;
            this.txtObservacoes.Size = new System.Drawing.Size(487, 97);
            this.txtObservacoes.TabIndex = 12;
            // 
            // SincronizarOCsSdcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 288);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.ensFormaPagamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.label1);
            this.Name = "SincronizarOCsSdcForm";
            this.Text = "Sincronização de Ordem Gerada no Simulador de Compras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private IWTDotNetLib.IWTEntitySelection ensFormaPagamento;
        private IWTDotNetLib.IWTButton btnConfirmar;
        private System.Windows.Forms.Label label4;
        private IWTDotNetLib.IWTTextBox txtObservacoes;
    }
}