using System.Windows.Forms.VisualStyles;
using IWTDotNetLib;

namespace BibliotecaCompras
{
    partial class OCEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ensFornecedor = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.lblValorTotalDesconto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ensFormaPagto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRemoverItenSelecionado = new System.Windows.Forms.Button();
            this.lblValorTotalImpostos = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComprasEmailTexto = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtComprasRodape = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Size = new System.Drawing.Size(864, 630);
            this.splitContainer1.SplitterDistance = 574;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ensFornecedor);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(864, 574);
            this.splitContainer2.SplitterDistance = 48;
            this.splitContainer2.TabIndex = 0;
            // 
            // ensFornecedor
            // 
            this.ensFornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensFornecedor.BindingField = null;
            this.ensFornecedor.ColunasDropdown = null;
            this.ensFornecedor.DesabilitarAutoCompletar = false;
            this.ensFornecedor.DesabilitarChekBox = true;
            this.ensFornecedor.DesabilitarLupa = false;
            this.ensFornecedor.DesabilitarSeta = false;
            this.ensFornecedor.EntidadeSelecionada = null;
            this.ensFornecedor.FormSelecao = null;
            this.ensFornecedor.LiberadoQuandoCadastroUtilizado = false;
            this.ensFornecedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFornecedor.Location = new System.Drawing.Point(79, 14);
            this.ensFornecedor.ModoVisualizacaoGrid = null;
            this.ensFornecedor.Name = "ensFornecedor";
            this.ensFornecedor.ParametroBuscaGuiada = null;
            this.ensFornecedor.ParametrosBuscaObrigatorios = null;
            this.ensFornecedor.Size = new System.Drawing.Size(773, 23);
            this.ensFornecedor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fornecedor";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lblValorTotalDesconto);
            this.splitContainer3.Panel2.Controls.Add(this.label7);
            this.splitContainer3.Panel2.Controls.Add(this.ensFormaPagto);
            this.splitContainer3.Panel2.Controls.Add(this.label5);
            this.splitContainer3.Panel2.Controls.Add(this.txtObservacao);
            this.splitContainer3.Panel2.Controls.Add(this.label4);
            this.splitContainer3.Panel2.Controls.Add(this.btnEditar);
            this.splitContainer3.Panel2.Controls.Add(this.btnRemoverItenSelecionado);
            this.splitContainer3.Panel2.Controls.Add(this.lblValorTotalImpostos);
            this.splitContainer3.Panel2.Controls.Add(this.lblValorTotal);
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Panel2.Controls.Add(this.txtComprasEmailTexto);
            this.splitContainer3.Panel2.Controls.Add(this.label24);
            this.splitContainer3.Panel2.Controls.Add(this.txtComprasRodape);
            this.splitContainer3.Panel2.Controls.Add(this.label23);
            this.splitContainer3.Size = new System.Drawing.Size(864, 522);
            this.splitContainer3.SplitterDistance = 224;
            this.splitContainer3.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CacheDados = null;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(864, 224);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblValorTotalDesconto
            // 
            this.lblValorTotalDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotalDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalDesconto.Location = new System.Drawing.Point(731, 38);
            this.lblValorTotalDesconto.Name = "lblValorTotalDesconto";
            this.lblValorTotalDesconto.Size = new System.Drawing.Size(121, 13);
            this.lblValorTotalDesconto.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(597, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Valor Total com Desconto:";
            // 
            // ensFormaPagto
            // 
            this.ensFormaPagto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ensFormaPagto.BindingField = null;
            this.ensFormaPagto.ColunasDropdown = null;
            this.ensFormaPagto.DesabilitarAutoCompletar = false;
            this.ensFormaPagto.DesabilitarChekBox = true;
            this.ensFormaPagto.DesabilitarLupa = false;
            this.ensFormaPagto.DesabilitarSeta = false;
            this.ensFormaPagto.EntidadeSelecionada = null;
            this.ensFormaPagto.FormSelecao = null;
            this.ensFormaPagto.LiberadoQuandoCadastroUtilizado = false;
            this.ensFormaPagto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFormaPagto.Location = new System.Drawing.Point(26, 56);
            this.ensFormaPagto.ModoVisualizacaoGrid = null;
            this.ensFormaPagto.Name = "ensFormaPagto";
            this.ensFormaPagto.ParametroBuscaGuiada = null;
            this.ensFormaPagto.ParametrosBuscaObrigatorios = null;
            this.ensFormaPagto.Size = new System.Drawing.Size(409, 23);
            this.ensFormaPagto.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Forma de Pagamento";
            // 
            // txtObservacao
            // 
            this.txtObservacao.AcceptsReturn = true;
            this.txtObservacao.AcceptsTab = true;
            this.txtObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacao.Location = new System.Drawing.Point(26, 235);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(826, 50);
            this.txtObservacao.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Observação";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(126, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(108, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar Linha";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRemoverItenSelecionado
            // 
            this.btnRemoverItenSelecionado.Location = new System.Drawing.Point(12, 3);
            this.btnRemoverItenSelecionado.Name = "btnRemoverItenSelecionado";
            this.btnRemoverItenSelecionado.Size = new System.Drawing.Size(108, 23);
            this.btnRemoverItenSelecionado.TabIndex = 0;
            this.btnRemoverItenSelecionado.Text = "Remover Linha";
            this.btnRemoverItenSelecionado.UseVisualStyleBackColor = true;
            this.btnRemoverItenSelecionado.Click += new System.EventHandler(this.btnRemoverItenSelecionado_Click);
            // 
            // lblValorTotalImpostos
            // 
            this.lblValorTotalImpostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotalImpostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalImpostos.Location = new System.Drawing.Point(731, 57);
            this.lblValorTotalImpostos.Name = "lblValorTotalImpostos";
            this.lblValorTotalImpostos.Size = new System.Drawing.Size(121, 13);
            this.lblValorTotalImpostos.TabIndex = 25;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(731, 21);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(121, 13);
            this.lblValorTotal.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(601, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Valor Total com Impostos:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Valor Total Bruto:";
            // 
            // txtComprasEmailTexto
            // 
            this.txtComprasEmailTexto.AcceptsReturn = true;
            this.txtComprasEmailTexto.AcceptsTab = true;
            this.txtComprasEmailTexto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComprasEmailTexto.Location = new System.Drawing.Point(26, 167);
            this.txtComprasEmailTexto.Multiline = true;
            this.txtComprasEmailTexto.Name = "txtComprasEmailTexto";
            this.txtComprasEmailTexto.Size = new System.Drawing.Size(826, 50);
            this.txtComprasEmailTexto.TabIndex = 4;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 150);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(262, 13);
            this.label24.TabIndex = 21;
            this.label24.Text = "Mensagem do Email para Envio de Ordens de Compra";
            // 
            // txtComprasRodape
            // 
            this.txtComprasRodape.AcceptsReturn = true;
            this.txtComprasRodape.AcceptsTab = true;
            this.txtComprasRodape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComprasRodape.Location = new System.Drawing.Point(26, 97);
            this.txtComprasRodape.Multiline = true;
            this.txtComprasRodape.Name = "txtComprasRodape";
            this.txtComprasRodape.Size = new System.Drawing.Size(826, 50);
            this.txtComprasRodape.TabIndex = 3;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(160, 13);
            this.label23.TabIndex = 20;
            this.label23.Text = "Rodapé para Ordens de Compra";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(12, 17);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(777, 17);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // OCEditForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(864, 630);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OCEditForm";
            this.Text = "Edição de Ordem de Compra";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox txtComprasEmailTexto;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtComprasRodape;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblValorTotalImpostos;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private IWTDataGridView dataGridView1;
        private System.Windows.Forms.Button btnRemoverItenSelecionado;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private IWTDotNetLib.IWTEntitySelection ensFormaPagto;
        private IWTDotNetLib.IWTEntitySelection ensFornecedor;
        private System.Windows.Forms.Label lblValorTotalDesconto;
        private System.Windows.Forms.Label label7;
    }
}