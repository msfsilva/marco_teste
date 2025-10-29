using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadProdutoPrecoForm : IWTForm
    {

        private ProdutoPrecoClass _produtoPreco
        {
            get { return (ProdutoPrecoClass) this.Entity; }
        }

        public CadProdutoPrecoForm(ProdutoPrecoClass entidade, CadProdutoPrecoListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.ensProduto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, true, somenteSemPreco: true);
        }




        /*
               public void atualizarPreco(ProdutoPrecoClass precoEncerrando)
        {

            if (this.CollectionProdutoPrecoClassProduto.Count > 0)
            {
                foreach (ProdutoPrecoClass produtoPreco in this.CollectionProdutoPrecoClassProduto.Where(a=>a!=precoEncerrando && !a.FimVigencia.HasValue))
                {
                    produtoPreco.FimVigencia = precoEncerrando.FimVigencia;
                }
            }

            
            ProdutoPrecoClass novoPreco = new ProdutoPrecoClass(this.UsuarioAtual, this.SingleConnection)
            {
                AcsUsuario = this.UsuarioAtual,
                InicioVigencia = precoEncerrando.FimVigencia.Value,
                Produto = this,
                FimVigencia = null,
                Justificativa = Justificativa,
                Preco = precoFixo,
                Regra = Regra


            };
            this.CollectionProdutoPrecoClassProduto.Add(novoPreco);
            this.CadastroPreco = true;

        }
        */

        #region Menu de Contexto

        private void CarregaDadosMenuContexto()
        {
            try
            {
                if (_produtoPreco.Produto == null)
                {
                    return;
                }

                //Carrega Context Menu
                if (this._produtoPreco.Produto.Variavel1 != null)
                {
                    this.cmsVariaveis.Items[0].Text = this._produtoPreco.Produto.Variavel1.Nome;
                }
                else
                {
                    this.cmsVariaveis.Items[0].Visible = false;
                }

                if (this._produtoPreco.Produto.Variavel2 != null)
                {
                    this.cmsVariaveis.Items[1].Text = this._produtoPreco.Produto.Variavel2.Nome;
                }
                else
                {
                    this.cmsVariaveis.Items[1].Visible = false;
                }

                if (this._produtoPreco.Produto.Variavel3 != null)
                {
                    this.cmsVariaveis.Items[2].Text = this._produtoPreco.Produto.Variavel3.Nome;
                }
                else
                {
                    this.cmsVariaveis.Items[2].Visible = false;
                }


                if (this._produtoPreco.Produto.Variavel4 != null)
                {
                    this.cmsVariaveis.Items[3].Text = this._produtoPreco.Produto.Variavel4.Nome;
                }
                else
                {
                    this.cmsVariaveis.Items[3].Visible = false;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar os dados do menu de contexto.\r\n" + e.Message, e);
            }
        }

        private void InsereVariavelMenuContexto(ContextMenuStrip sender, string itemClicado)
        {
            try
            {


                if (itemClicado == this._produtoPreco.Produto.Variavel1.Nome)
                {
                    ((TextBox) sender.SourceControl).Text += "$" + this._produtoPreco.Produto.Variavel1.Nome + "$";
                    ((TextBox) sender.SourceControl).SelectionStart = ((TextBox) sender.SourceControl).Text.Length;
                    return;
                }

                if (itemClicado == this._produtoPreco.Produto.Variavel2.Nome)
                {
                    ((TextBox) sender.SourceControl).Text += "$" + this._produtoPreco.Produto.Variavel2.Nome + "$";
                    ((TextBox) sender.SourceControl).SelectionStart = ((TextBox) sender.SourceControl).Text.Length;
                    return;
                }

                if (itemClicado == this._produtoPreco.Produto.Variavel3.Nome)
                {
                    ((TextBox) sender.SourceControl).Text += "$" + this._produtoPreco.Produto.Variavel3.Nome + "$";
                    ((TextBox) sender.SourceControl).SelectionStart = ((TextBox) sender.SourceControl).Text.Length;
                    return;
                }

                if (itemClicado == this._produtoPreco.Produto.Variavel4.Nome)
                {
                    ((TextBox) sender.SourceControl).Text += "$" + this._produtoPreco.Produto.Variavel4.Nome + "$";
                    ((TextBox) sender.SourceControl).SelectionStart = ((TextBox) sender.SourceControl).Text.Length;
                    return;
                }

                if (itemClicado == "Dimensão do Item")
                {
                    ((TextBox) sender.SourceControl).Text += "$CALC_DIM_ITEM$";
                    ((TextBox) sender.SourceControl).SelectionStart = ((TextBox) sender.SourceControl).Text.Length;
                    return;
                }

                if (itemClicado == "Dimensão do Item Pai")
                {
                    ((TextBox) sender.SourceControl).Text += "$CALC_DIM_ITEM_PAI$";
                    ((TextBox) sender.SourceControl).SelectionStart = ((TextBox) sender.SourceControl).Text.Length;
                    return;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inserir a variável.\r\n" + e.Message, e);
            }
        }

        #endregion


        private void LoadGrid()
        {
            try
            {
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = new BindingList<ProdutoPaiFilhoClass>(this._produtoPreco.Produto.Filhos);
                this.dataGridView1.ReadOnly = false;
                SomaPrecoColumn.ReadOnly = false;
                ProdutoFilhoColumn.ReadOnly = true;
                QuantidadeFilhoColumn.ReadOnly = true;


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar o grid dos itens.\r\n" + e.Message, e);
            }
        }

        private void RevisarPreco()
        {
            try
            {
                if (MessageBox.Show(this, "Essa operação irá realizar a revisão do preço do produto. Você deseja continuar?", "Revisão de Preço", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.VerificaUtilizacao = false;

                    this.Entity = _produtoPreco.Revisar();
                    if (this.ListForm != null)
                    {
                        this.ListForm.ForceInitializeDataGrid();
                    }

                    this.Close();
                }
                else
                {
                    return;
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao revisar o preço do produto.\r\n" + e.Message, e);
            }
        }



        #region Eventos

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.RevisarPreco();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                if (this.Entity.ID == -1)
                {
                    this.pnlNovo.Visible = true;
                    this.pnlRevisao.Visible = false;
                    this.FimVigencia.forceDisable();


                }
                else
                {
                    this.pnlNovo.Visible = false;
                    this.pnlRevisao.Visible = true;
                    this.FimVigencia.removeForceDisable();
                    CarregaDadosMenuContexto();
                    LoadGrid();
                }




            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void rdbPrecoFixo_CheckedChanged(object sender, EventArgs e)
        {
            this.grbFixo.Enabled = rdbPrecoFixo.Checked;
            this.grbRegra.Enabled = rdbRegra.Checked;
            this.grbSomarFilhos.Enabled = rdbSomarPrecosFilhos.Checked;
        }

        private void rdbRegra_CheckedChanged(object sender, EventArgs e)
        {
            this.grbFixo.Enabled = rdbPrecoFixo.Checked;
            this.grbRegra.Enabled = rdbRegra.Checked;
            this.grbSomarFilhos.Enabled = rdbSomarPrecosFilhos.Checked;
        }

        private void rdbSomarPrecosFilhos_CheckedChanged(object sender, EventArgs e)
        {
            this.grbFixo.Enabled = rdbPrecoFixo.Checked;
            this.grbRegra.Enabled = rdbRegra.Checked;
            this.grbSomarFilhos.Enabled = rdbSomarPrecosFilhos.Checked;
            if (rdbSomarPrecosFilhos.Checked)
            {
                if (_produtoPreco.PrecoFixo || _produtoPreco.PrecoVariavelRegra)
                {
                    rdbTodosFilhos.Checked = true;
                }
            }
        }

        private void rdbTodosFilhos_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Enabled = this.rdbSomenteSelecionados.Checked;
        }

        private void rdbSomenteSelecionados_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Enabled = this.rdbSomenteSelecionados.Checked;
        }

        private void rdbTodosFilhosPedidoEstrutura_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Enabled = this.rdbSomenteSelecionados.Checked;
        }

        private void cmsVariaveis_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                InsereVariavelMenuContexto((ContextMenuStrip) sender, e.ClickedItem.Text);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensProduto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this._produtoPreco.Produto != null)
                {
                    CarregaDadosMenuContexto();
                    LoadGrid();

                    this.rdbPrecoFixo.Checked = true;
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion





    }
}
