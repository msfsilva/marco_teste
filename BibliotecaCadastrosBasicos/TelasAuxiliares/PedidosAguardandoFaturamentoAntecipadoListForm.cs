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

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class PedidosAguardandoFaturamentoAntecipadoListForm : IWTBaseForm
    {
        public PedidosAguardandoFaturamentoAntecipadoListForm()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            try
            {
                List<SearchParameterClass> parametrosBusca =
                    new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("SubLinha", 0),
                        new SearchParameterClass("RealizaFaturamentoFuturo", true),
                        new SearchParameterClass("FaturamentoAntecipadoRealizado", false),
                        new SearchParameterClass("Encerrado", false),
                        new SearchParameterClass("Cancelado", false),
                        new SearchParameterClass("Suspenso", false),
                        new SearchParameterClass("Numero", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                        new SearchParameterClass("Posicao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                    };

                if (!string.IsNullOrWhiteSpace(txtBusca.Text))
                {
                    parametrosBusca.Add(new SearchParameterClass("BuscaCompleta", txtBusca.Text));
                }
                    

                List<PedidoItemClass> pedidos = new PedidoItemClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection).Search(parametrosBusca).ConvertAll(a => (PedidoItemClass) a).ToList();

                this.dgvPedidos.DataSource = pedidos;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao atualizar o Grid\r\n" + e.Message);
            }
        }


        private void Faturar()
        {
            try
            {
                if (this.dgvPedidos.SelectedRows.Count != 1)
                {
                    throw new ExcecaoTratada("Selecione o pedido a ser faturado.");
                }

                PedidoItemClass pedido = (PedidoItemClass) ((IWTDataGridViewRow) this.dgvPedidos.SelectedRows[0]).DataBoundItem;
                pedido.RealizaFaturamentoAntecipado();

                MessageBox.Show(this, "Nota Fiscal gerada com Sucesso, aguarde a transmissão pelo módulo de automação", "Emissão Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadGrid();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao emitir a Nfe de Faturamento Antecipado\r\n" + e.Message);
            }
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                LoadGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iwtTextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void btnFaturar_Click(object sender, EventArgs e)
        {
            try
            {

                this.Faturar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

    }
}