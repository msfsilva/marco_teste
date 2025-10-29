using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.TelasAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque;
using BibliotecaEntidades.Relatorios;
using Configurations;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEstoqueForm : IWTForm
    {
        EstoqueClass Estoque
        {
            get { return (EstoqueClass) this.Entity; }
        }

        public CadEstoqueForm(EstoqueClass entidade, CadEstoqueListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadEstoqueForm(EstoqueClass entidade)
            : base(entidade, typeof(EstoqueClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }

        private void InitializeTreeEstoque()
        {
            this.treEstoque.Nodes.Add(new EstoqueEstruturaPrincipal(this.Estoque));

            this.treEstoque.CollapseAll();

        }

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            try
            {

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao executar o salvar da tela \r\n" + e.Message);
            }


            base.Salvar(command);
        }


        private void IncluirNovoItem()
        {
            try
            {
                if (this.txtSubIdentificacao.Text.Trim() != "")
                {
                    SubEstoque noSelecionado = (SubEstoque)this.treEstoque.SelectedNode;


                    if (noSelecionado != null)
                    {
                        noSelecionado.AddSubNivel(this.txtSubIdentificacao.Text.Trim(), this.txtSubDescricao.Text.Trim(), this.chkAtivo.Checked);
                        //this.treEstoque.ExpandAll();
                    }
                    else
                    {
                        throw new Exception("É necessário selecionar o nó que receberá o novo endereçamento.");
                    }
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao Incluir o item.\r\n" + a.Message);
            }
        }

        private void AtualizarItemSelecionado(SubEstoque noSelecionado)
        {
            try
            {
                if (this.txtSubIdentificacao.Text.Trim() != "")
                {
                    noSelecionado.AtualizarDados(this.txtSubIdentificacao.Text.Trim(), this.txtSubDescricao.Text.Trim(), this.chkAtivo.Checked);
                    //this.treEstoque.ExpandAll();

                }
                else
                {
                    throw new Exception("Não é possível atualizar o item principal.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar o item.\r\n" + e.Message);
            }
        }

        private void ExcluirItemSelecionado(SubEstoque noSelecionado)
        {
            try
            {
                if (noSelecionado.Pai == null)
                {
                    throw new ExcecaoTratada("Não é possível excluir o almoxarifado, utilize a operação de exclusão na listagem.");
                }
                noSelecionado.Pai.ExcluirSubNivel(noSelecionado);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o item.\r\n" + e.Message);
            }
        }

        private void GerarEtiqueta(SubEstoque noSelecionado)
        {
           try
            {
                List<EstoqueGavetaReportClass> dados = noSelecionado.GerarEtiqueta();

                if (dados.Count > 0)
                {
                    ReportDocument rep = new EstoqueGavetaReport();
                    rep.SetDataSource(dados);

                    string impressora = IWTConfiguration.Conf.getConf(ProjectConstants.Constants.EXPEDITION_LABEL_PRINTER);
                    string papel = IWTConfiguration.Conf.getConf(ProjectConstants.Constants.EXPEDITION_LABEL_PAPER);
                    IWTFunctions.IWTFunctions.DefineImpressoraReport(ref rep,
                        impressora,
                        papel
                    );
                    ViewReportPadraoForm view = new ViewReportPadraoForm("Etiqueta de Gaveta de Estoque", rep);
                    view.ShowDialog(this);
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao gerar a etiqueta" + Environment.NewLine + e.Message, e);
            }
        }

        private void SelecionarItem(SubEstoque noSelecionado)
        {
            try
            {
                if (noSelecionado != null)
                {
                    this.txtSubDescricao.Text = noSelecionado.Descricao;
                    this.txtSubIdentificacao.Text = noSelecionado.Identificacao;
                    this.chkAtivo.Checked = noSelecionado.GetAtivo();

                    //this.treEstoque.ExpandAll();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o item.\r\n" + e.Message);
            }
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                this.InitializeTreeEstoque();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.IncluirNovoItem();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSubAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treEstoque.SelectedNode != null)
                {
                    this.AtualizarItemSelecionado((SubEstoque)this.treEstoque.SelectedNode);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treEstoque.SelectedNode != null)
                {
                    this.ExcluirItemSelecionado((SubEstoque)this.treEstoque.SelectedNode);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSubEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treEstoque.SelectedNode != null)
                {
                    this.GerarEtiqueta((SubEstoque)this.treEstoque.SelectedNode);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        

        private void treEstoque_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (this.treEstoque.SelectedNode != null)
                {
                    this.SelecionarItem((SubEstoque)this.treEstoque.SelectedNode);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void treEstoque_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = false;
            switch (e.Node.GetType().ToString())
            {
                case "BibliotecaEstoque.EstoqueEstruturaPrincipal":
                    e.Graphics.DrawString(e.Node.Text, e.Node.TreeView.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                    break;
                case "BibliotecaEstoque.EstoqueEstruturaCorredor":
                    e.Graphics.DrawString(e.Node.Text, e.Node.TreeView.Font, Brushes.Brown, e.Bounds.X, e.Bounds.Y);
                    break;
                case "BibliotecaEstoque.EstoqueEstruturaPrateleira":
                    e.Graphics.DrawString(e.Node.Text, e.Node.TreeView.Font, Brushes.Green, e.Bounds.X, e.Bounds.Y);
                    break;
                case "BibliotecaEstoque.EstoqueEstruturaGaveta":
                    e.Graphics.DrawString(e.Node.Text, e.Node.TreeView.Font, Brushes.Blue, e.Bounds.X, e.Bounds.Y);
                    break;
                default:
                    e.DrawDefault = true;
                    break;
            }

            //Paint text of selected node in red color
            if ((e.State & TreeNodeStates.Selected) != 0)
            {


            }

            //Paint text of other nodes in default color
            else
            {

            }
        }
        #endregion

       
    }
}
