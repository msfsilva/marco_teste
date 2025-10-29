namespace BibliotecaCadastrosBasicos
{
    partial class CadAgrupadorMaterialForm
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
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtColorSelector1 = new IWTDotNetLib.IWTColorSelector(this.components);
            this.TipoConsumoEstoque_MateriaPrimaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.TipoConsumoEstoque_MateriaPrima = new IWTDotNetLib.IWTRadioButton(this.components);
            this.TipoConsumoEstoque_ConsumoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.TipoConsumoEstoque_Consumo = new IWTDotNetLib.IWTRadioButton(this.components);
            this.TipoConsumoEstoque_EscolherLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.TipoConsumoEstoque_Escolher = new IWTDotNetLib.IWTRadioButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_MateriaPrimaLabel);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_MateriaPrima);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_ConsumoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_Consumo);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_EscolherLabel);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_Escolher);
            this.splitContainer1.Panel1.Controls.Add(this.iwtColorSelector1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(603, 376);
            this.splitContainer1.SplitterDistance = 310;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(516, 20);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(203, 12);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(68, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Identificação";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(216, 38);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(55, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "Descrição";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(248, 63);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(23, 13);
            this.iwtLabel3.TabIndex = 2;
            this.iwtLabel3.Text = "Cor";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Identificacao";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(277, 9);
            this.iwtTextBox1.MaxLength = 10;
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.Size = new System.Drawing.Size(217, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox2.BindingField = "Descricao";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(277, 35);
            this.iwtTextBox2.MaxLength = 255;
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.Size = new System.Drawing.Size(319, 20);
            this.iwtTextBox2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblRevisao);
            this.groupBox1.Controls.Add(this.lblRevisaoData);
            this.groupBox1.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox1.Controls.Add(this.iwtLabel7);
            this.groupBox1.Controls.Add(this.iwtLabel6);
            this.groupBox1.Controls.Add(this.iwtLabel5);
            this.groupBox1.Location = new System.Drawing.Point(24, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 94);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revisão";
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.BindingField = "UltimaRevisao";
            this.lblRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisao.Location = new System.Drawing.Point(100, 62);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(0, 13);
            this.lblRevisao.TabIndex = 5;
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(100, 39);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 4;
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(100, 16);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 3;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(16, 62);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel7.TabIndex = 2;
            this.iwtLabel7.Text = "Justificativa";
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(48, 39);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(30, 13);
            this.iwtLabel6.TabIndex = 1;
            this.iwtLabel6.Text = "Data";
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(35, 16);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(43, 13);
            this.iwtLabel5.TabIndex = 0;
            this.iwtLabel5.Text = "Usuário";
            // 
            // iwtColorSelector1
            // 
            this.iwtColorSelector1.BindingField = "Cor";
            this.iwtColorSelector1.LiberadoQuandoCadastroUtilizado = true;
            this.iwtColorSelector1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtColorSelector1.Location = new System.Drawing.Point(277, 58);
            this.iwtColorSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.iwtColorSelector1.Name = "iwtColorSelector1";
            this.iwtColorSelector1.SelectedColor = System.Drawing.SystemColors.Control;
            this.iwtColorSelector1.SelectedColorString = null;
            this.iwtColorSelector1.Size = new System.Drawing.Size(76, 23);
            this.iwtColorSelector1.TabIndex = 2;
            // 
            // TipoConsumoEstoque_MateriaPrimaLabel
            // 
            this.TipoConsumoEstoque_MateriaPrimaLabel.AutoSize = true;
            this.TipoConsumoEstoque_MateriaPrimaLabel.BindingField = null;
            this.TipoConsumoEstoque_MateriaPrimaLabel.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_MateriaPrimaLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_MateriaPrimaLabel.Location = new System.Drawing.Point(200, 105);
            this.TipoConsumoEstoque_MateriaPrimaLabel.Name = "TipoConsumoEstoque_MateriaPrimaLabel";
            this.TipoConsumoEstoque_MateriaPrimaLabel.Size = new System.Drawing.Size(71, 13);
            this.TipoConsumoEstoque_MateriaPrimaLabel.TabIndex = 12;
            this.TipoConsumoEstoque_MateriaPrimaLabel.Text = "Matéria Prima";
            // 
            // TipoConsumoEstoque_MateriaPrima
            // 
            this.TipoConsumoEstoque_MateriaPrima.AutoSize = true;
            this.TipoConsumoEstoque_MateriaPrima.BindingField = "TipoConsumoEstoque_MateriaPrima";
            this.TipoConsumoEstoque_MateriaPrima.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_MateriaPrima.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_MateriaPrima.Location = new System.Drawing.Point(277, 105);
            this.TipoConsumoEstoque_MateriaPrima.Name = "TipoConsumoEstoque_MateriaPrima";
            this.TipoConsumoEstoque_MateriaPrima.Size = new System.Drawing.Size(14, 13);
            this.TipoConsumoEstoque_MateriaPrima.TabIndex = 3;
            this.TipoConsumoEstoque_MateriaPrima.UseVisualStyleBackColor = true;
            // 
            // TipoConsumoEstoque_ConsumoLabel
            // 
            this.TipoConsumoEstoque_ConsumoLabel.AutoSize = true;
            this.TipoConsumoEstoque_ConsumoLabel.BindingField = null;
            this.TipoConsumoEstoque_ConsumoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_ConsumoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_ConsumoLabel.Location = new System.Drawing.Point(18, 132);
            this.TipoConsumoEstoque_ConsumoLabel.Name = "TipoConsumoEstoque_ConsumoLabel";
            this.TipoConsumoEstoque_ConsumoLabel.Size = new System.Drawing.Size(253, 13);
            this.TipoConsumoEstoque_ConsumoLabel.TabIndex = 14;
            this.TipoConsumoEstoque_ConsumoLabel.Text = "Consumo (Permite Compra SEM aprovação do PCP)";
            // 
            // TipoConsumoEstoque_Consumo
            // 
            this.TipoConsumoEstoque_Consumo.AutoSize = true;
            this.TipoConsumoEstoque_Consumo.BindingField = "TipoConsumoEstoque_Consumo";
            this.TipoConsumoEstoque_Consumo.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_Consumo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_Consumo.Location = new System.Drawing.Point(277, 132);
            this.TipoConsumoEstoque_Consumo.Name = "TipoConsumoEstoque_Consumo";
            this.TipoConsumoEstoque_Consumo.Size = new System.Drawing.Size(14, 13);
            this.TipoConsumoEstoque_Consumo.TabIndex = 4;
            this.TipoConsumoEstoque_Consumo.UseVisualStyleBackColor = true;
            // 
            // TipoConsumoEstoque_EscolherLabel
            // 
            this.TipoConsumoEstoque_EscolherLabel.AutoSize = true;
            this.TipoConsumoEstoque_EscolherLabel.BindingField = null;
            this.TipoConsumoEstoque_EscolherLabel.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_EscolherLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_EscolherLabel.Location = new System.Drawing.Point(110, 159);
            this.TipoConsumoEstoque_EscolherLabel.Name = "TipoConsumoEstoque_EscolherLabel";
            this.TipoConsumoEstoque_EscolherLabel.Size = new System.Drawing.Size(161, 13);
            this.TipoConsumoEstoque_EscolherLabel.TabIndex = 16;
            this.TipoConsumoEstoque_EscolherLabel.Text = "Definir na Solicitação de Compra";
            // 
            // TipoConsumoEstoque_Escolher
            // 
            this.TipoConsumoEstoque_Escolher.AutoSize = true;
            this.TipoConsumoEstoque_Escolher.BindingField = "TipoConsumoEstoque_Escolher";
            this.TipoConsumoEstoque_Escolher.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_Escolher.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_Escolher.Location = new System.Drawing.Point(277, 159);
            this.TipoConsumoEstoque_Escolher.Name = "TipoConsumoEstoque_Escolher";
            this.TipoConsumoEstoque_Escolher.Size = new System.Drawing.Size(14, 13);
            this.TipoConsumoEstoque_Escolher.TabIndex = 5;
            this.TipoConsumoEstoque_Escolher.UseVisualStyleBackColor = true;
            // 
            // CadAgrupadorMaterialForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(603, 376);
            this.Name = "CadAgrupadorMaterialForm";
            this.Text = "Agrupador de Material";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTColorSelector iwtColorSelector1;
        private IWTDotNetLib.IWTLabel TipoConsumoEstoque_MateriaPrimaLabel;
        private IWTDotNetLib.IWTRadioButton TipoConsumoEstoque_MateriaPrima;
        private IWTDotNetLib.IWTLabel TipoConsumoEstoque_ConsumoLabel;
        private IWTDotNetLib.IWTRadioButton TipoConsumoEstoque_Consumo;
        private IWTDotNetLib.IWTLabel TipoConsumoEstoque_EscolherLabel;
        private IWTDotNetLib.IWTRadioButton TipoConsumoEstoque_Escolher;
    }
}