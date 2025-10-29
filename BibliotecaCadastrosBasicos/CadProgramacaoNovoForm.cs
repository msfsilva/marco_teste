using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadProgramacaoNovoForm : IWTForm
    {
        private List<PedidoItemClass> _pedidosLivres;
        private ProgramacaoClass Programacao => (ProgramacaoClass) this.Entity;

        List<PedidoItemClass>_pedidosAvulsosSalvar= new List<PedidoItemClass>();

        public CadProgramacaoNovoForm(CadProgramacaoListForm listForm)
            : base(null, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        private void CarregaPedidosLivres()
        {
            _pedidosLivres = new PedidoItemClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection).Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("Status", StatusPedido.Pendente),
                new SearchParameterClass("Programacao", null),
                new SearchParameterClass("Configurado", true),
                new SearchParameterClass("SubLinha", 0),
                new SearchParameterClass("SituacaoGad",GadIntegracaoPedidoSituacao.Liberado)
            }).ConvertAll(a => (PedidoItemClass) a).ToList();

            this.BuscaDisponiveis("");
            this.BuscaProgramados("");
        }


        private void BuscaDisponiveis(string busca)
        {
            List<PedidoItemClass> dsLivres = _pedidosLivres;
            


            if (!string.IsNullOrWhiteSpace(busca))
            {
                dsLivres = dsLivres.Where(a => a.NumeroPosicao.Contains(busca) || a.SemanaEntrega.ToString().Contains(busca) || a.Produto.ToString().Contains(busca) || a.ProdutoDescricao.ToString().Contains(busca) || a.ProjetoCliente.ToString().Contains(busca)).ToList();
            }

            dgvPedidosDisponiveis.DataSource = new BindingList<PedidoItemClass>(dsLivres.OrderBy(a => a.SemanaEntrega).ThenBy(a => a.NumeroPosicao).ToList());
        }

        private void BuscaProgramados(string busca)
        {
            List<PedidoItemClass> dsProgramados = ((ProgramacaoClass)this.Entity).CollectionPedidoItemClassProgramacao.ToList();


            if (!string.IsNullOrWhiteSpace(busca))
            {
                dsProgramados = dsProgramados.Where(a => a.NumeroPosicao.Contains(busca) || a.SemanaEntrega.ToString().Contains(busca) || a.Produto.ToString().Contains(busca) || a.ProdutoDescricao.ToString().Contains(busca) || a.ProjetoCliente.ToString().Contains(busca)).ToList();
            }

            dgvPedidos.DataSource = new BindingList<PedidoItemClass>(dsProgramados.OrderBy(a => a.SemanaEntrega).ThenBy(a=>a.NumeroPosicao).ToList());
            }

        private void RemoverSelecionados()
        {
            try
            {
                foreach (IWTDataGridViewRow row in dgvPedidos.SelectedRowsIwt)
                {
                    PedidoItemClass pedido = (PedidoItemClass)row.DataBoundItem;
                    this.Programacao.CollectionPedidoItemClassProgramacao.Remove(pedido);
                    pedido.Programacao = null;
                    this._pedidosLivres.Add(pedido);
                    _pedidosAvulsosSalvar.Add(pedido);
                }
            }
            finally
            {
                BuscaDisponiveis(txtBuscaDisponiveis.Text.Trim());
                BuscaProgramados(txtBuscaProgramados.Text.Trim());
            }
        }



        private void IncluirSelecionados()
        {
            try
            {
                foreach (IWTDataGridViewRow row in dgvPedidosDisponiveis.SelectedRowsIwt)
                {
                    PedidoItemClass pedido = (PedidoItemClass) row.DataBoundItem;
                    this.Programacao.CollectionPedidoItemClassProgramacao.Add(pedido);
                    pedido.Programacao = Programacao;
                    this._pedidosLivres.Remove(pedido);
                }
            }
            finally
            {
                BuscaDisponiveis(txtBuscaDisponiveis.Text.Trim());
                BuscaProgramados(txtBuscaProgramados.Text.Trim());
            }

        }

      

        #region Eventos

        protected override void OnShown(EventArgs e)
        {

            try
            {
                base.OnShown(e);
                CarregaPedidosLivres();
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

        private void btnInclui1_Click(object sender, EventArgs e)
        {
            try
            {
                IncluirSelecionados();
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
        
        private void btnRemove1_Click(object sender, EventArgs e)
        {
            try
            {
                RemoverSelecionados();
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

        private void txtBusca_OperacaoBuscaEncerrada(object sender, string valor)
        {
            try
            {
                BuscaDisponiveis(valor);
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

        private void txtBuscaProgramados_OperacaoBuscaEncerrada(object sender, string valor)
        {
            try
            {
                BuscaProgramados(valor);
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
