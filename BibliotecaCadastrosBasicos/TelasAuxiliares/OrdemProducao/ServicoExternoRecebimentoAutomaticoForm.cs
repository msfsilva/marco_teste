using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class ServicoExternoRecebimentoAutomaticoForm : IWTBaseForm
    {
        public ServicoExternoRecebimentoAutomaticoForm()
        {
            InitializeComponent();

#if DEBUG
            this.txtChaveNota.DebugMode = true;
#endif
        }

        private void CarregarNFe(string chaveNfe)
        {
            try
            {
                NotaFiscalEntradaClass.ReceberServicoExternoAutomatico(chaveNfe, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                MessageBox.Show(this, "Nota Fiscal recebida com sucesso!", "Recebimento Automático de NFe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                BufferAbstractEntity.limparBuffer();
                throw;
                
            }
            finally
            {
                this.txtChaveNota.Clear();
                this.txtChaveNota.Focus();
            }
        }

        #region Eventos
        private void txtChaveNota_OperacaoBarcodeEncerrada(object sender, string valor)
        {
            try
            {
                CarregarNFe(valor);
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
