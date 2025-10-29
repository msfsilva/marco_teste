using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEmissaoEtiquetas;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class GeracaoEtiquetaCustomizadaSemCNCForm : IWTBaseForm
    {
        public GeracaoEtiquetaCustomizadaSemCNCForm()
        {
            InitializeComponent();
        }

        private void Gerar()
        {
            string oc = null;
            int pos = -1;
            int pps = -1;
            if (gbxOcPos.Enabled)
            {
                if (string.IsNullOrWhiteSpace(txtOc.Text) || string.IsNullOrWhiteSpace(txtPos.Text))
                {
                    throw new ExcecaoTratada("Indique a OC e a Posição ou selecione outro modo de geração");
                }

                if (!int.TryParse(txtPos.Text, out pos))
                {
                    throw new ExcecaoTratada("Campo de Posição preenchido com caracteres inválidos");
                }

                oc = txtOc.Text;
            }


            if (gbxPps.Enabled)
            {
                if (string.IsNullOrWhiteSpace(txtPps.Text))
                {
                    throw new ExcecaoTratada("Indique o PPS ou selecione outro modo de geração");
                }

                if (!int.TryParse(txtPps.Text, out pps))
                {
                    throw new ExcecaoTratada("Campo de PPS preenchido com caracteres inválidos");
                }
                
            }

            List<OrderItemEtiquetaClass> toPrint = OrderItemEtiquetaClass.GerarEtiquetasCustomizadasAvultas(oc, pos == -1 ? (int?) null : pos, pps == -1 ? (int?) null : pps, SingleConnection, LoginClass.UsuarioLogado.loggedUser);


            if (MessageBox.Show(this, "As etiquetas foram geradas com sucesso, deseja abrir a tela de impressão?", "Imprimir Etiquetas Customizadas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            EtiquetaInternaCustomizadoReportForm form = new EtiquetaInternaCustomizadoReportForm(
                toPrint, 
                IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PRINTER),
                IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PAPER),
                LoginClass.UsuarioLogado.loggedUser,
                SingleConnection
            );
            form.ShowDialog(this);

        }

        private void AjustaTela()
        {
            gbxOcPos.Enabled = rdbOcPos.Checked;
            gbxPps.Enabled = rdbPps.Checked;
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                Gerar();
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




        private void rdbPps_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjustaTela();
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



        private void rdbOcPos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjustaTela();
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

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjustaTela();
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


        #endregion
    }
}
