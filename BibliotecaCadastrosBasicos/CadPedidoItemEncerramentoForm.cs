#region Referencias

using System;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemEncerramentoForm : IWTBaseForm
    {
        readonly PedidoItemClass Pedido;
        readonly AcsUsuarioClass Usuario;

        public CadPedidoItemEncerramentoForm(PedidoItemClass pedido, AcsUsuarioClass usuario)
        {
            InitializeComponent();
            this.Pedido = pedido;
            this.Usuario = usuario;

            this.txtCNPJEmitente.Text = IWTConfiguration.Conf.getConf(ProjectConstants.Constants.NF_EMITENTE_CNPJ);
            this.dtpDataNF.Value = Configurations.DataIndependenteClass.GetData();

        }

        private void EncerrarPedido()
        {
            if (MessageBox.Show(this, "Você está encerrando um pedido com emissão de nota fiscal manual, essa operação não poderá ser desfeita. Deseja continuar?", "Emissão NF Manual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Pedido.Encerrar((int)this.nudNumero.Value, (int)this.nudLinha.Value, this.txtCNPJEmitente.Text, this.dtpDataNF.Value, this.Usuario);
                this.Close();
            }
        }

        #region Eventos
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.EncerrarPedido();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
     
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
