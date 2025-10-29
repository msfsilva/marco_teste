#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTFunctions;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaCadastrosBasicos
{

    public partial class CadOrcamentoItemVariavelListForm : IWTBaseForm
    {
        private OrcamentoItemClass Orcamento;

        public CadOrcamentoItemVariavelListForm(OrcamentoItemClass orcamento)
        {
            InitializeComponent();
            this.Orcamento = orcamento;

            this.loadComboVariaveis();
            this.loadComboSubLinhas();

            this.InitializeGridPedido();
            this.InitializeGridItem();
        }


        private void loadComboVariaveis()
        {
            try
            {

                List<SearchParameterClass> searchParameters = new List<SearchParameterClass>()
                                                                  {
                                                                      new SearchParameterClass("var_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)

                                                                  };

                if (this.Orcamento.Cliente != null)
                {
                    searchParameters.Add(new SearchParameterClass("FamiliaClienteOrNull", this.Orcamento.Cliente.FamiliaCliente));
                }
                else
                {
                    searchParameters.Add(new SearchParameterClass("FamiliaCliente", null));
                }

                VariavelClass search = new VariavelClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<VariavelClass> entidades =
                    search.Search(searchParameters).
                        ConvertAll(a => (VariavelClass) a);



                this.cmbVariavel.DataSource = entidades;
                this.cmbVariavel.DisplayMember = "Nome";
                this.cmbVariavel.ValueMember = "ID";
                this.cmbVariavel.autoSize = true;
                this.cmbVariavel.Table = entidades;
                this.cmbVariavel.ColumnsToDisplay = new[] {"Nome", "Descricao", "FamiliaCliente"};
                this.cmbVariavel.HeadersToDisplay = new string[] {"Código", "Descrição", "Familia Cliente"};



                this.cmbVariavelItem.DataSource = new List<VariavelClass>(entidades);
                this.cmbVariavelItem.DisplayMember = "Nome";
                this.cmbVariavelItem.ValueMember = "ID";
                this.cmbVariavelItem.autoSize = true;
                this.cmbVariavelItem.Table = new List<VariavelClass>(entidades);
                this.cmbVariavelItem.ColumnsToDisplay = new[] {"Nome", "Descricao", "FamiliaCliente"};
                this.cmbVariavelItem.HeadersToDisplay = new string[] {"Código", "Descrição", "Familia Cliente"};


            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar o combo de variáveis.\r\n" + e.Message, e);
            }
        }

        private void loadComboSubLinhas()
        {
            try
            {
                List<LoadClass> list = new List<LoadClass>();
                list.Add(new LoadClass("0", this.Orcamento.Produto.Codigo));
                foreach (OrcamentoItemClass pedidoItem in this.Orcamento.CollectionOrcamentoItemClassOrcamentoItemPai)
                {
                    list.Add(new LoadClass(pedidoItem.SubLinha.ToString(CultureInfo.InvariantCulture), pedidoItem.Produto.ToString()));
                }

                BindingSource binding = new BindingSource();
                binding.DataSource = list;
                this.cmbSublinha.DataSource = binding;
                this.cmbSublinha.ValueMember = "id";
                this.cmbSublinha.DisplayMember = "descricao";

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o combo de SubLinhas.\r\n" + e.Message, e);
            }
        }


        #region Variáveis do Orcamento

        private void InitializeGridPedido()
        {
            try
            {
                this.dgvVariaveisPedido.AutoGenerateColumns = false;
                this.dgvVariaveisPedido.DataSource = this.Orcamento.CollectionOrcamentoVariavelClassOrcamentoItem;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao inicializar o grid de variáveis do orcamento\r\n" + e.Message, e);
            }
        }

        private void SelecionarLinhaGridPedido()
        {
            try
            {
                if (this.dgvVariaveisPedido.SelectedRows.Count == 0) return;

                PedidoVariavelClass selecionado = (PedidoVariavelClass) ((IWTDataGridViewRow) this.dgvVariaveisPedido.SelectedRows[0]).DataBoundItem;
                this.txtValor.Text = selecionado.Valor;
                this.cmbVariavel.SelectedItem = selecionado.Variavel;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao selecionar a linha do grid de variáveis do orcamento\r\n" + e.Message, e);
            }
        }

        private void SalvarVariavelPedido()
        {
            try
            {
                if (this.cmbVariavel.SelectedItem==null)
                {
                    throw new ExcecaoTratada("A seleção da variável é obrigatória");
                }

                if (string.IsNullOrWhiteSpace(this.txtValor.Text))
                {
                    throw new ExcecaoTratada("O Valor da variável é obrigatório");
                }


                this.Orcamento.AtualizarIncluirVariavel((VariavelClass)this.cmbVariavel.SelectedItem, this.txtValor.Text.Trim());

            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao  atualizar/adicionar a variável no orcamento\r\n" + e.Message, e);
            }
        }

        private void ExcluirVariavelPedido()
        {
            try
            {
                if (this.dgvVariaveisPedido.SelectedRows.Count == 0) throw new ExcecaoTratada("Selecione ao menos uma variável para ser excluída");
                if (MessageBox.Show(this,"Deseja excluir os itens selecionados?","Exclusão",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes)return;
                foreach (IWTDataGridViewRow row in this.dgvVariaveisPedido.SelectedRows)
                {
                    OrcamentoVariavelClass selecionado = (OrcamentoVariavelClass)row.DataBoundItem;

                    this.Orcamento.ExcluirVariavelOrcamento(selecionado);
                }
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao excluir a variável do orcamento\r\n" + e.Message, e);
            }
        }

        #endregion

        #region Variáveis dos Itens Orcamento

        private void InitializeGridItem()
        {
            try
            {
                this.dgvVariaveisItensPedido.AutoGenerateColumns = false;



                List<OrcamentoItemVariavelClass> tmp = new List<OrcamentoItemVariavelClass>(this.Orcamento.CollectionOrcamentoItemVariavelClassOrcamentoItem);
                foreach (OrcamentoItemClass item in this.Orcamento.CollectionOrcamentoItemClassOrcamentoItemPai)
                {
                    tmp.AddRange(item.CollectionOrcamentoItemVariavelClassOrcamentoItem);
                }

                this.dgvVariaveisItensPedido.DataSource = tmp;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao inicializar o grid de variáveis do orcamento\r\n" + e.Message, e);
            }
        }

        private void SelecionarLinhaGridItemPedido()
        {
            try
            {
                if (this.dgvVariaveisItensPedido.SelectedRows.Count == 0) return;

                PedidoItemVariavelClass selecionado = (PedidoItemVariavelClass)((IWTDataGridViewRow)this.dgvVariaveisItensPedido.SelectedRows[0]).DataBoundItem;
                this.txtValorItem.Text = selecionado.Valor;
                this.cmbVariavelItem.SelectedItem = selecionado.Variavel;
                this.cmbSublinha.SelectedValue = selecionado.PedidoItem.SubLinha;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao selecionar a linha do grid de variáveis dos itens do orcamento\r\n" + e.Message, e);
            }
        }

        private void SalvarVariavelItemPedido()
        {
            try
            {
                if (this.cmbVariavelItem.SelectedItem == null)
                {
                    throw new ExcecaoTratada("A seleção da variável é obrigatória");
                }

                if (this.cmbSublinha.SelectedItem == null)
                {
                    throw new ExcecaoTratada("A seleção da sublinha é obrigatória");
                }

                if (string.IsNullOrWhiteSpace(this.txtValorItem.Text))
                {
                    throw new ExcecaoTratada("O Valor da variável é obrigatório");
                }


                this.Orcamento.AtualizarIncluirVariavelItem((VariavelClass)this.cmbVariavelItem.SelectedItem, this.txtValorItem.Text.Trim(), (int)this.cmbSublinha.SelectedValue);
                InitializeGridItem();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar/adicionar a variável no item do orcamento\r\n" + e.Message, e);
            }
        }

        private void ExcluirVariavelItemPedido()
        {
            try
            {
                if (this.dgvVariaveisItensPedido.SelectedRows.Count == 0) throw new ExcecaoTratada("Selecione ao menos uma variável para ser excluída");
                if (MessageBox.Show(this, "Deseja excluir os itens selecionados?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                foreach (IWTDataGridViewRow row in this.dgvVariaveisItensPedido.SelectedRows)
                {
                    OrcamentoItemVariavelClass selecionado = (OrcamentoItemVariavelClass)row.DataBoundItem;

                    this.Orcamento.ExcluirVariavelItemOrcamento(selecionado);

                }
                InitializeGridItem();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao excluir a variável do orcamento\r\n" + e.Message, e);
            }
        }

        #endregion

        #region Eventos Variáveis do Orcamento

        private void dgvVariaveisPedido_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelecionarLinhaGridPedido();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.SalvarVariavelPedido();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExcluirVariavelPedido();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos Variáveis dos Itens Orcamento

        private void dgvVariaveisItensPedido_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelecionarLinhaGridItemPedido();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOkItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SalvarVariavelItemPedido();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExcluirVariavelItemPedido();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
