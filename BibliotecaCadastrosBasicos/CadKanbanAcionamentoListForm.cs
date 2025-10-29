using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadKanbanAcionamentoListForm : IWTListForm
    {

        public CadKanbanAcionamentoListForm()
        {
            InitializeComponent();
        }

        public override Type getTipoEntidade()
        {
            return typeof(KanbanAcionamentoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override IWTDataGridView getDataGrid()
        {
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            return new List<SearchParameterClass>() {new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)};
        }

        private void RetirarAviso()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count == 0)
                {
                    throw new ExcecaoTratada("Selecione o item para o qual deseja retirar o aviso");
                }

                if (MessageBox.Show(this, "Essa operação irá encerrar os avisos de etoque de segurança, deseja continuar?", "Estoque de Segurança", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                IWTPostgreNpgsqlCommand command = SingleConnection.CreateCommand();
                foreach (IWTDataGridViewRow row in getDataGrid().SelectedRowsIwt)
                {

                    try
                    {
                        command.Transaction = command.Connection.BeginTransaction();

                        KanbanAcionamentoClass entidade = (KanbanAcionamentoClass) row.DataBoundItem;
                        bool controleOriginal = true;
                        switch (entidade.TipoEntidade)
                        {
                            case "Material":
                                try
                                {
                                    controleOriginal = entidade.Material.ControleRevisaoHabilitado;
                                    entidade.Material.ControleRevisaoHabilitado = false;
                                    entidade.Material.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, true, kbEncerrar: entidade);
                                    entidade.Material.Save(ref command);
                                }
                                finally
                                {
                                    entidade.Material.ControleRevisaoHabilitado = controleOriginal;
                                }

                                break;

                            case "Produto":
                                try
                                {
                                    controleOriginal = entidade.Produto.ControleRevisaoHabilitado;
                                    entidade.Produto.ControleRevisaoHabilitado = false;
                                    entidade.Produto.DesabilitarJustificativaRevisaoProduto = true;
                                    entidade.Produto.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, true, kbEncerrar: entidade);
                                    entidade.Produto.Save(ref command);
                                }
                                finally
                                {
                                    entidade.Produto.ControleRevisaoHabilitado = controleOriginal;
                                    entidade.Produto.DesabilitarJustificativaRevisaoProduto = false;
                                }

                                break;

                            case "Epi":
                                try
                                {
                                    controleOriginal = entidade.Epi.ControleRevisaoHabilitado;
                                    entidade.Epi.ControleRevisaoHabilitado = false;
                                    entidade.Epi.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, true, kbEncerrar: entidade);
                                    entidade.Epi.Save(ref command);
                                }
                                finally
                                {
                                    entidade.Epi.ControleRevisaoHabilitado = controleOriginal;
                                }

                                break;

                            case "Kanban de Itens Manufaturados":
                                try
                                {
                                    controleOriginal = entidade.ProdutoK.ControleRevisaoHabilitado;
                                    entidade.ProdutoK.ControleRevisaoHabilitado = false;
                                    entidade.ProdutoK.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, true, kbEncerrar: entidade);
                                    entidade.ProdutoK.Save(ref command);
                                }
                                finally
                                {
                                    entidade.ProdutoK.ControleRevisaoHabilitado = controleOriginal;
                                }

                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        entidade.Save(ref command);
                        command.Transaction.Commit();
                    }
                    catch
                    {
                        command?.Transaction?.Rollback();
                        throw;
                    }
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao retirar o aviso:" + e.Message, e);
            }
            finally
            {
                this.ForceInitializeDataGrid();
            }
        }

        #region Eventos
        private void chkDataAcionamento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                grbDataAcionamento.Enabled = chkDataAcionamento.Checked;
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

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                        try
            {
             this.ForceInitializeDataGrid();
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

        private void btnRetirarAviso_Click(object sender, EventArgs e)
        {            try
            {
                RetirarAviso();
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

        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);

            this.rdbEmAberto.Checked =true;
          
        }

        #endregion
    }
}
