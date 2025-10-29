using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaEntidades
{
    public partial class ComplementoEtiquetaGadForm : IWTBaseForm
    {
        public string CodigoBarrasLido { get; private set; } = null;

        public ComplementoEtiquetaGadForm()
        {
            InitializeComponent();
        }

        private void txtBarcode_OperacaoBarcodeEncerrada(object sender, string valor)
        {
            try
            {
                if (!valor.StartsWith("GAD2"))
                {
                    txtBarcode.Clear();
                    throw new ExcecaoTratada("Código de barras inválido: " + valor);
                }

                CodigoBarrasLido = valor;
                Close();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
    }
}
