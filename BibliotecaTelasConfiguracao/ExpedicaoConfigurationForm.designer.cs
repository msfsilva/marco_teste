namespace BibliotecaTelasConfiguracao
{
    partial class ExpedicaoConfigurationForm
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
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this.cmbImpressoraPKL = new System.Windows.Forms.ComboBox();
          this.label4 = new System.Windows.Forms.Label();
          this.groupBox3 = new System.Windows.Forms.GroupBox();
          this.cmbPapelMedio = new System.Windows.Forms.ComboBox();
          this.cmbImpressoraMedia = new System.Windows.Forms.ComboBox();
          this.label1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.cmbPapelExpedicao = new System.Windows.Forms.ComboBox();
          this.cmbImpressoraExpedicao = new System.Windows.Forms.ComboBox();
          this.label29 = new System.Windows.Forms.Label();
          this.label32 = new System.Windows.Forms.Label();
          this.groupBox4 = new System.Windows.Forms.GroupBox();
          this.cmbPapelInterno = new System.Windows.Forms.ComboBox();
          this.cmbImpressoraInterna = new System.Windows.Forms.ComboBox();
          this.label30 = new System.Windows.Forms.Label();
          this.label31 = new System.Windows.Forms.Label();
          this.groupBox2.SuspendLayout();
          this.groupBox3.SuspendLayout();
          this.groupBox1.SuspendLayout();
          this.groupBox4.SuspendLayout();
          this.SuspendLayout();
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(455, 465);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 23);
          this.button1.TabIndex = 2;
          this.button1.Text = "Salvar";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // groupBox2
          // 
          this.groupBox2.Controls.Add(this.cmbImpressoraPKL);
          this.groupBox2.Controls.Add(this.label4);
          this.groupBox2.Location = new System.Drawing.Point(12, 384);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(362, 61);
          this.groupBox2.TabIndex = 1;
          this.groupBox2.TabStop = false;
          this.groupBox2.Text = "Relatórios/Packing List";
          // 
          // cmbImpressoraPKL
          // 
          this.cmbImpressoraPKL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbImpressoraPKL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbImpressoraPKL.FormattingEnabled = true;
          this.cmbImpressoraPKL.Location = new System.Drawing.Point(23, 34);
          this.cmbImpressoraPKL.Name = "cmbImpressoraPKL";
          this.cmbImpressoraPKL.Size = new System.Drawing.Size(316, 21);
          this.cmbImpressoraPKL.TabIndex = 0;
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(7, 18);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(104, 13);
          this.label4.TabIndex = 11;
          this.label4.Text = "Nome da Impressora";
          // 
          // groupBox3
          // 
          this.groupBox3.Controls.Add(this.cmbPapelMedio);
          this.groupBox3.Controls.Add(this.cmbImpressoraMedia);
          this.groupBox3.Controls.Add(this.label1);
          this.groupBox3.Controls.Add(this.label2);
          this.groupBox3.Location = new System.Drawing.Point(12, 136);
          this.groupBox3.Name = "groupBox3";
          this.groupBox3.Size = new System.Drawing.Size(496, 118);
          this.groupBox3.TabIndex = 23;
          this.groupBox3.TabStop = false;
          this.groupBox3.Text = "Etiqueta Média (8,5 cm x 5 cm)";
          // 
          // cmbPapelMedio
          // 
          this.cmbPapelMedio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbPapelMedio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbPapelMedio.FormattingEnabled = true;
          this.cmbPapelMedio.Location = new System.Drawing.Point(26, 82);
          this.cmbPapelMedio.Name = "cmbPapelMedio";
          this.cmbPapelMedio.Size = new System.Drawing.Size(446, 21);
          this.cmbPapelMedio.TabIndex = 16;
          // 
          // cmbImpressoraMedia
          // 
          this.cmbImpressoraMedia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbImpressoraMedia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbImpressoraMedia.FormattingEnabled = true;
          this.cmbImpressoraMedia.Location = new System.Drawing.Point(26, 32);
          this.cmbImpressoraMedia.Name = "cmbImpressoraMedia";
          this.cmbImpressoraMedia.Size = new System.Drawing.Size(446, 21);
          this.cmbImpressoraMedia.TabIndex = 15;
          this.cmbImpressoraMedia.SelectedIndexChanged += new System.EventHandler(this.cmbImpressoraMedia_SelectedIndexChanged);
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(10, 66);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(80, 13);
          this.label1.TabIndex = 14;
          this.label1.Text = "Nome do Papel";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(10, 16);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(104, 13);
          this.label2.TabIndex = 13;
          this.label2.Text = "Nome da Impressora";
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.cmbPapelExpedicao);
          this.groupBox1.Controls.Add(this.cmbImpressoraExpedicao);
          this.groupBox1.Controls.Add(this.label29);
          this.groupBox1.Controls.Add(this.label32);
          this.groupBox1.Location = new System.Drawing.Point(12, 260);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(496, 118);
          this.groupBox1.TabIndex = 22;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Etiqueta Expedição (10,8 cm x 18,9 cm)";
          // 
          // cmbPapelExpedicao
          // 
          this.cmbPapelExpedicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbPapelExpedicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbPapelExpedicao.FormattingEnabled = true;
          this.cmbPapelExpedicao.Location = new System.Drawing.Point(26, 82);
          this.cmbPapelExpedicao.Name = "cmbPapelExpedicao";
          this.cmbPapelExpedicao.Size = new System.Drawing.Size(446, 21);
          this.cmbPapelExpedicao.TabIndex = 16;
          // 
          // cmbImpressoraExpedicao
          // 
          this.cmbImpressoraExpedicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbImpressoraExpedicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbImpressoraExpedicao.FormattingEnabled = true;
          this.cmbImpressoraExpedicao.Location = new System.Drawing.Point(26, 32);
          this.cmbImpressoraExpedicao.Name = "cmbImpressoraExpedicao";
          this.cmbImpressoraExpedicao.Size = new System.Drawing.Size(446, 21);
          this.cmbImpressoraExpedicao.TabIndex = 15;
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
          // groupBox4
          // 
          this.groupBox4.Controls.Add(this.cmbPapelInterno);
          this.groupBox4.Controls.Add(this.cmbImpressoraInterna);
          this.groupBox4.Controls.Add(this.label30);
          this.groupBox4.Controls.Add(this.label31);
          this.groupBox4.Location = new System.Drawing.Point(12, 12);
          this.groupBox4.Name = "groupBox4";
          this.groupBox4.Size = new System.Drawing.Size(496, 118);
          this.groupBox4.TabIndex = 21;
          this.groupBox4.TabStop = false;
          this.groupBox4.Text = "Etiqueta Interna (8 cm x 3,3 cm)";
          // 
          // cmbPapelInterno
          // 
          this.cmbPapelInterno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbPapelInterno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbPapelInterno.FormattingEnabled = true;
          this.cmbPapelInterno.Location = new System.Drawing.Point(26, 82);
          this.cmbPapelInterno.Name = "cmbPapelInterno";
          this.cmbPapelInterno.Size = new System.Drawing.Size(446, 21);
          this.cmbPapelInterno.TabIndex = 16;
          // 
          // cmbImpressoraInterna
          // 
          this.cmbImpressoraInterna.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
          this.cmbImpressoraInterna.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cmbImpressoraInterna.FormattingEnabled = true;
          this.cmbImpressoraInterna.Location = new System.Drawing.Point(26, 32);
          this.cmbImpressoraInterna.Name = "cmbImpressoraInterna";
          this.cmbImpressoraInterna.Size = new System.Drawing.Size(446, 21);
          this.cmbImpressoraInterna.TabIndex = 15;
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
          this.ClientSize = new System.Drawing.Size(542, 500);
          this.Controls.Add(this.groupBox3);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.groupBox4);
          this.Controls.Add(this.groupBox2);
          this.Controls.Add(this.button1);
          this.Name = "ConfigurationForm";
          this.Text = "Configurações";
          this.Shown += new System.EventHandler(this.ConfigurationForm_Shown);
          this.groupBox2.ResumeLayout(false);
          this.groupBox2.PerformLayout();
          this.groupBox3.ResumeLayout(false);
          this.groupBox3.PerformLayout();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.groupBox4.ResumeLayout(false);
          this.groupBox4.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ComboBox cmbImpressoraPKL;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox cmbPapelMedio;
      private System.Windows.Forms.ComboBox cmbImpressoraMedia;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox cmbPapelExpedicao;
      private System.Windows.Forms.ComboBox cmbImpressoraExpedicao;
      private System.Windows.Forms.Label label29;
      private System.Windows.Forms.Label label32;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.ComboBox cmbPapelInterno;
      private System.Windows.Forms.ComboBox cmbImpressoraInterna;
      private System.Windows.Forms.Label label30;
      private System.Windows.Forms.Label label31;
   }
}