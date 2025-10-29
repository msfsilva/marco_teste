using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class CadEmbarqueTransportadoraForm : IWTBaseForm
    {
        private readonly EmbarqueClass _embarque;

        public CadEmbarqueTransportadoraForm(EmbarqueClass embarque)
        {
            _embarque = embarque;
            InitializeComponent();

            ensTransportadora.FormSelecao = new CadTransporteListForm(TipoModulo.Tipo);

            ensTransportadora.EntidadeSelecionada = _embarque.Transporte;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
             try
            {
                _embarque.Transporte = (TransporteClass) ensTransportadora.EntidadeSelecionada;
                _embarque.Save();
                this.Close();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         


        }
    }
}
