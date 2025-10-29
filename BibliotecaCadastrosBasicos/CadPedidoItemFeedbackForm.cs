using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemFeedbackForm : IWTBaseForm
    {
        private readonly List<PedidoItemClass> _pedidos;
        private readonly bool _secundario;

        public CadPedidoItemFeedbackForm( List<PedidoItemClass> pedidos, bool secundario)
        {
            _pedidos = pedidos;
            _secundario = secundario;
            InitializeComponent();
            if (pedidos.Count == 1)
            {
                this.txtFeedback.Text = _secundario? pedidos.First().FeedbackSecundarioAtual:pedidos.First().FeedbackAtual;
            }
        }

        private void btnFeedbackOk_Click(object sender, EventArgs e)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtFeedback.Text))
                {
                    throw new Exception("O feedback não pode ser vazio");
                }

                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                foreach (PedidoItemClass pedido in _pedidos)
                {
                    if (!_secundario)
                    {
                        PedidoItemFeedbackClass feedback = new PedidoItemFeedbackClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            Texto = this.txtFeedback.Text.Trim(),
                            PedidoItem = pedido,
                            AcsUsuario = LoginClass.UsuarioLogado.loggedUser,
                            Data = Configurations.DataIndependenteClass.GetData(),
                            Atual = true
                        };

                        pedido.CollectionPedidoItemFeedbackClassPedidoItem.Add(feedback);

                    }
                    else
                    {
                        PedidoItemFeedbackSecundarioClass feedback = new PedidoItemFeedbackSecundarioClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                        {
                            Texto = this.txtFeedback.Text.Trim(),
                            PedidoItem = pedido,
                            AcsUsuario = LoginClass.UsuarioLogado.loggedUser,
                            Data = Configurations.DataIndependenteClass.GetData(),
                            Atual = true
                        };

                        pedido.CollectionPedidoItemFeedbackSecundarioClassPedidoItem.Add(feedback);
                    }

                    pedido.Save(ref command);

                }

                command.Transaction.Commit();


                this.Close();
            }
            catch (Exception a)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao incluir o novo feedback no pedido\r\n" + a.Message, a);
            }

        }
    }
}
