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

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class EmbarquePedidosForm : IWTBaseForm
    {
        public EmbarquePedidosForm()
        {
            InitializeComponent();
            this.btnBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvPedidos.DataSource = null;
                long idEmbarque;
                if (!Int64.TryParse(this.iwtMaskedTextBox1.Text, out idEmbarque))
                {
                    throw new ExcecaoTratada("Entre com um número de embarque válido");
                }

                EmbarqueClass embarque = EmbarqueClass.GetEntidade(idEmbarque, LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                if (embarque == null)
                {
                    throw new ExcecaoTratada("Não foi encontrado embarque com o número " + idEmbarque);
                }


                this.dgvPedidos.AutoGenerateColumns = false;
                this.dgvPedidos.DataSource = new BindingList<OrderItemEtiquetaConferenciaClass>(embarque.CollectionOrderItemEtiquetaConferenciaClassEmbarque.Where(a => a.ConferenciaPai).OrderBy(a=>a.OrderNumber).ThenBy(a=>a.OrderPos).ToList());

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
