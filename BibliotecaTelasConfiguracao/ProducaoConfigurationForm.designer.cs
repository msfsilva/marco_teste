namespace BibliotecaTelasConfiguracao
{
    partial class ProducaoConfigurationForm
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
          this.button1 = new System.Windows.Forms.Button();
          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this.cmbPapelExpedicao = new System.Windows.Forms.ComboBox();
          this.cmbImpressoraExpedicao = new System.Windows.Forms.ComboBox();
          this.label29 = new System.Windows.Forms.Label();
          this.label32 = new System.Windows.Forms.Label();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.cmbPapelInterno = new System.Windows.Forms.ComboBox();
          this.cmbImpressoraInterna = new System.Windows.Forms.ComboBox();
          this.label30 = new System.Windows.Forms.Label();
          this.label31 = new System.Windows.Forms.Label();
          this.groupBox2.SuspendLayout();
          this.groupBox1.SuspendLayout();
          this.SuspendLayout();
          // 
          // button1
          // 
          this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.button1.Location = new System.Drawing.Point(441, 284);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 23);
          this.button1.TabIndex = 4;
          this.button1.Text = "Salvar";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // openFileDialog1
          // 
          this.openFileDialog1.FileName = "openFileDialog1";
          // 
          // groupBox2
          // 
          this.groupBox2.Controls.Add(this.cmbPapelExpedicao);
          this.groupBox2.Controls.Add(this.cmbImpressoraExpedicao);
          this.groupBox2.Controls.Add(this.label29);
          this.groupBox2.Controls.Add(this.label32);
          this.groupBox2.Location = new System.Drawing.Point(20, 149);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(496, 118);
          this.groupBox2.TabIndex = 1;
          this.groupBox2.TabStop = false;
          this.groupBox2.Text = "Etiqueta Expedição (10,8 cm x 18,9 cm)";
          // 
          // cmbPapelExpedicao
          // 
          this.cmbPapelExpedicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbPapelExpedicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbPapelExpedicao.Enabled = false;
          this.cmbPapelExpedicao.FormattingEnabled = true;
          this.cmbPapelExpedicao.Location = new System.Drawing.Point(26, 82);
          this.cmbPapelExpedicao.Name = "cmbPapelExpedicao";
          this.cmbPapelExpedicao.Size = new System.Drawing.Size(446, 21);
          this.cmbPapelExpedicao.TabIndex = 1;
          // 
          // cmbImpressoraExpedicao
          // 
          this.cmbImpressoraExpedicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbImpressoraExpedicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbImpressoraExpedicao.FormattingEnabled = true;
          this.cmbImpressoraExpedicao.Location = new System.Drawing.Point(26, 32);
          this.cmbImpressoraExpedicao.Name = "cmbImpressoraExpedicao";
          this.cmbImpressoraExpedicao.Size = new System.Drawing.Size(446, 21);
          this.cmbImpressoraExpedicao.TabIndex = 0;
          this.cmbImpressoraExpedicao.SelectedIndexChanged += new System.EventHandler(this.cmbImpressoraExpedicao_SelectedIndexChanged);
          // 
          // label29
          // 
          this.label29.AutoSize = true;
          this.label29.Location = new System.Drawing.Point(10, 66);
          this.label29.Name = "label29";
          this.label29.Size = new System.Drawing.Size(80, 13);
          this.label29.TabIndex = 14;
          this.label29.Text = "Nome do Papel";
          // 
          // label32
          // 
          this.label32.AutoSize = true;
          this.label32.Location = new System.Drawing.Point(10, 16);
          this.label32.Name = "label32";
          this.label32.Size = new System.Drawing.Size(104, 13);
          this.label32.TabIndex = 13;
          this.label32.Text = "Nome da Impressora";
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.cmbPapelInterno);
          this.groupBox1.Controls.Add(this.cmbImpressoraInterna);
          this.groupBox1.Controls.Add(this.label30);
          this.groupBox1.Controls.Add(this.label31);
          this.groupBox1.Location = new System.Drawing.Point(20, 12);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(496, 118);
          this.groupBox1.TabIndex = 0;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Etiqueta Interna (8 cm x 3,3 cm)";
          // 
          // cmbPapelInterno
          // 
          this.cmbPapelInterno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbPapelInterno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbPapelInterno.Enabled = false;
          this.cmbPapelInterno.FormattingEnabled = true;
          this.cmbPapelInterno.Location = new System.Drawing.Point(26, 82);
          this.cmbPapelInterno.Name = "cmbPapelInterno";
          this.cmbPapelInterno.Size = new System.Drawing.Size(446, 21);
          this.cmbPapelInterno.TabIndex = 1;
          // 
          // cmbImpressoraInterna
          // 
          this.cmbImpressoraInterna.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbImpressoraInterna.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbImpressoraInterna.FormattingEnabled = true;
          this.cmbImpressoraInterna.Location = new System.Drawing.Point(26, 32);
          this.cmbImpressoraInterna.Name = "cmbImpressoraInterna";
          this.cmbImpressoraInterna.Size = new System.Drawing.Size(446, 21);
          this.cmbImpressoraInterna.TabIndex = 0;
          this.cmbImpressoraInterna.SelectedIndexChanged += new System.EventHandler(this.cmbImpressoraInterna_SelectedIndexChanged);
          // 
          // label30
          // 
          this.label30.AutoSize = true;
          this.label30.Location = new System.Drawing.Point(10, 66);
          this.label30.Name = "label30";
          this.label30.Size = new System.Drawing.Size(80, 13);
          this.label30.TabIndex = 14;
          this.label30.Text = "Nome do Papel";
          // 
          // label31
          // 
          this.label31.AutoSize = true;
          this.label31.Location = new System.Drawing.Point(10, 16);
          this.label31.Name = "label31";
          this.label31.Size = new System.Drawing.Size(104, 13);
          this.label31.TabIndex = 13;
          this.label31.Text = "Nome da Impressora";
          // 
          // ConfigurationForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
          this.ClientSize = new System.Drawing.Size(538, 319);
          this.Controls.Add(this.groupBox2);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.button1);
          this.Name = "ConfigurationForm";
          this.Text = "Configurações";
          this.Shown += new System.EventHandler(this.ConfigurationForm_Shown);
          this.groupBox2.ResumeLayout(false);
          this.groupBox2.PerformLayout();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ComboBox cmbPapelExpedicao;
      private System.Windows.Forms.ComboBox cmbImpressoraExpedicao;
      private System.Windows.Forms.Label label29;
      private System.Windows.Forms.Label label32;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox cmbPapelInterno;
      private System.Windows.Forms.ComboBox cmbImpressoraInterna;
      private System.Windows.Forms.Label label30;
      private System.Windows.Forms.Label label31;
   }
}