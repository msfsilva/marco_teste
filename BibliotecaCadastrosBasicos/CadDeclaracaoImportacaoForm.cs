using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDeclaracaoImportacaoForm : IWTForm
    {
        private FornecedorClass _fornecedorAnterior = null;

        DeclaracaoImportacaoClass Declaracao
        {
            get { return (DeclaracaoImportacaoClass) this.Entity; }
        }

        public CadDeclaracaoImportacaoForm(DeclaracaoImportacaoClass entidade, CadDeclaracaoImportacaoListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.LocalDesembaracoAduaneiro.FormSelecao = new CadLocalDesembaracoAduaneiroListForm();
            this.Fornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo, true);
        }

        public CadDeclaracaoImportacaoForm(DeclaracaoImportacaoClass entidade)
            : base(entidade, typeof(DeclaracaoImportacaoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.LocalDesembaracoAduaneiro.FormSelecao = new CadLocalDesembaracoAduaneiroListForm();
            this.Fornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo, true);
        }



        private void IncluirAdicao()
        {
            try
            {
                this.Declaracao.CriarAdicao((short) this.nudNumeroAdicao.Value);
                this.InitializeGridAdicao();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao incluir a adição.\r\n" + e.Message, e);
            }
        }

        private void InitializeGridAdicao()
        {
            try
            {
                this.dgvAdicoes.DataSource = this.Declaracao.CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Inicializar o grid de adições.\r\n" + e.Message, e);
            }
        }

        private void EditarAdicao()
        {
            try
            {
                if (this.dgvAdicoes.SelectedRows.Count == 0)
                {
                    throw new ExcecaoTratada("Selecione somente uma adição para visualizar os itens.");
                }

                CadDeclaracaoImportacaoAdicaoForm form = new CadDeclaracaoImportacaoAdicaoForm((DeclaracaoImportacaoAdicaoClass)((IWTDataGridViewRow)this.dgvAdicoes.SelectedRows[0]).DataBoundItem);
                form.ShowDialog(this);

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao editar a adição.\r\n" + e.Message, e);
            };
        }

        private void ExcluirAdicao()
        {
            try
            {
                if (this.dgvAdicoes.SelectedRows.Count == 0)
                {
                    throw new ExcecaoTratada("Selecione somente uma adição para fazer a remoção.");
                }

                if (DialogResult.Yes != MessageBox.Show(this,"Deseja excluir a adição selecionada?","Exclusão de Adição",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    return;
                }


                this.Declaracao.ExcluirAdicao((DeclaracaoImportacaoAdicaoClass) ((IWTDataGridViewRow) this.dgvAdicoes.SelectedRows[0]).DataBoundItem);
                this.InitializeGridAdicao();
                

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir a adição.\r\n" + e.Message, e);
            }
        }

        private void CalcularValorTotal()
        {
            try
            {

                this.Declaracao.ValorTotalDolar = (double) (this.ValorFrete.Value + this.ValorSeguro.Value + this.ValorMercadoria.Value);
                this.lblValorTotalDolares.Text = "US$ " + this.Declaracao.ValorTotalDolar.ToString("F3", CultureInfo.CurrentCulture);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao calcular o valor total.\r\n" + e.Message, e);
            }
        }

        private void SelecionaFornecedor()
        {
            if (this._fornecedorAnterior == null)
            {
                _fornecedorAnterior = (FornecedorClass) this.Fornecedor.EntidadeSelecionada;
                return;
            }

            if (this._fornecedorAnterior == (FornecedorClass)this.Fornecedor.EntidadeSelecionada)
            {
                return;
            }


            if (this.Declaracao.CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Any(a => a.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao.Count > 0))
            {
                if (DialogResult.Yes ==
                    MessageBox.Show(this, "Essa declaração já possui materiais incluídos, alterar o fornecedor irá forçar a exclusão de TODOS os materiais, deseja continuar?", "Alteração de Fornecedor", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question))
                {
                    this.Declaracao.LimparMateriais();
                    this._fornecedorAnterior = (FornecedorClass) this.Fornecedor.EntidadeSelecionada;
                }
                else
                {
                    this.Fornecedor.EntidadeSelecionada = this._fornecedorAnterior;
                }
            }
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                this.InitializeGridAdicao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncluirAdicao_Click(object sender, EventArgs e)
        {
            try
            {
                this.IncluirAdicao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarAdicao_Click(object sender, EventArgs e)
        {
            try
            {
                this.EditarAdicao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirAdicao_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExcluirAdicao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValorFrete_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.CalcularValorTotal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValorSeguro_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.CalcularValorTotal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void ValorMercadoria_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.CalcularValorTotal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fornecedor_EntityChange(object sender, EventArgs e)
        {
            try
            {
                this.SelecionaFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        #endregion

       




    }
}
