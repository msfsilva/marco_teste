using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Configurations;

namespace BibliotecaCadastrosBasicos.ClassesAuxiliares
{
    public partial class TelaPosicaoInicialImpressaoEtiqueta : Form
    {
        public int Linha { get; private set; }
        public int Coluna { get; private set; }

        public TelaPosicaoInicialImpressaoEtiqueta(int etiquetaColunas, int etiquetaLinhas)
        {
            InitializeComponent();

            if (etiquetaColunas == 0)
            {
                etiquetaColunas = 1;
            }

            if (etiquetaLinhas == 0)
            {
                etiquetaLinhas = 1;
            }

            this.nudLinhaInicial.Maximum = etiquetaLinhas;
            this.nudColunaInicial.Maximum = etiquetaColunas;

            this.Linha = 0;
            this.Coluna = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.Linha = (int) (this.nudLinhaInicial.Value - 1);
            this.Coluna = (int)(this.nudColunaInicial.Value - 1);

            this.Close();
        }
    }
}
