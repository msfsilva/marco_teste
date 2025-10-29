using IWTDotNetLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPalletForm : IWTBaseForm
    {
        private int numeroInicial;

        public CadPalletForm()
        {
            InitializeComponent();
        }

        private void CarregaDadosIniciais()
        {
            PalletClass pallet = PalletClass.GetPalletMaiorNumero(SingleConnection, LoginClass.UsuarioLogado.loggedUser);
            if (pallet == null)
            {
                numeroInicial = 1;
            }
            else
            {
                numeroInicial = pallet.Numero + 1;
            }


            lblNumeroInicial.Text = numeroInicial.ToString(CultureInfo.InvariantCulture);
            nudNumeroFinal.Value = numeroInicial;
            nudNumeroFinal.Minimum = numeroInicial;
        }

        private void Criar()
        {
            int qtdPalletsCriar = (int) nudNumeroFinal.Value - numeroInicial + 1;

            if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá criar " + qtdPalletsCriar + " pallets e não poderá ser desfeita, deseja continuar?", "Criação de Pallets", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            PalletClass.CriarMultiplosPallets(numeroInicial, (int) nudNumeroFinal.Value, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

            MessageBox.Show(this, "Pallets Criados com sucesso!", "Criação de Pallets", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            

        }

        #region eventos

        protected override void OnShown(EventArgs e)
        {

            try
            {
                base.OnShown(e);
                CarregaDadosIniciais();
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

        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {
                Criar();
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
