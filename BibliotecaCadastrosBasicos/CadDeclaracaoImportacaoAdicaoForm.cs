using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDeclaracaoImportacaoAdicaoForm : IWTForm
    {
        public bool salvar { get; private set; }

        private DeclaracaoImportacaoAdicaoClass Adicao
        {
            get { return (DeclaracaoImportacaoAdicaoClass) this.Entity; }
        }

        public CadDeclaracaoImportacaoAdicaoForm(DeclaracaoImportacaoAdicaoClass entidade)
            : base(entidade, typeof (DeclaracaoImportacaoAdicaoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.btnCancelar.Visible = false;
            this.DesabilitarAvisoAlteradoAoFechar = true;
        }

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {

            if ( this.Adicao.DeclaracaoImportacao.Fornecedor != null)
            {
                this.Adicao.CodigoFabricante = this.Adicao.DeclaracaoImportacao.Fornecedor.ID.ToString(CultureInfo.InvariantCulture);
            }
            else
            {

                this.Adicao.CodigoFabricante = "XXXX";
            }

            this.Entity.ValidateData(ref command);

            this.Adicao.DeclaracaoImportacao.setAlterado(true);
            this.Entity.ForceClean();
            this.Close();
        }

        private void InitializeGridItens()
        {
            try
            {
                this.dgvItens.DataSource = Adicao.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar o grid de itens.\r\n" + e.Message, e);
            }
        }

        private void AdicionarItem()
        {
            try
            {

                if (this.Adicao.DeclaracaoImportacao.Fornecedor == null)
                {
                    throw new ExcecaoTratada("Não é posível incluir itens na adição antes de selecionar um fornecedor. Selecione um fornecedor e tente novamente.");
                }

                CadDeclaracaoImportacaoAdicaoItemForm form = new CadDeclaracaoImportacaoAdicaoItemForm(this.Adicao);
                form.ShowDialog(this);
                if (form.Saved)
                {
                    this.Adicao.IncluirItem(form.Item);
                    this.InitializeGridItens();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Adicionar o item\r\n" + e.Message, e);
            }
        }

        private void EditarItem()
        {
            try
            {
                if (this.dgvItens.SelectedRows.Count!=1)
                {
                    throw new ExcecaoTratada("Selecione um item para editar.");
                }

                if (this.Adicao.DeclaracaoImportacao.Fornecedor == null)
                {
                    throw new ExcecaoTratada("Não é posível editar itens da adição antes de selecionar um fornecedor. Selecione um fornecedor e tente novamente.");
                }

                CadDeclaracaoImportacaoAdicaoItemForm form = new CadDeclaracaoImportacaoAdicaoItemForm((DeclaracaoImportacaoAdicaoItemClass) ((IWTDataGridViewRow)this.dgvItens.SelectedRows[0]).DataBoundItem);
                form.ShowDialog(this);
                if (!form.Saved)
                {
                    form.Item.RollbackSomenteEntidade();
                }
                this.InitializeGridItens();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao editar o item\r\n" + e.Message, e);
            }
        }

        private void ExcluirItem()
        {
            try
            {
                if (this.dgvItens.SelectedRows.Count != 1)
                {
                    throw new ExcecaoTratada("Selecione um item para excluir.");
                }

                if (DialogResult.Yes!=MessageBox.Show(this,"Deseja excluir o item selecionado da Adição?","Exclusão de Item",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    return;
                }

                this.Adicao.ExcluirItem((DeclaracaoImportacaoAdicaoItemClass) ((IWTDataGridViewRow) this.dgvItens.SelectedRows[0]).DataBoundItem);
                this.InitializeGridItens();

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao remover o item\r\n" + e.Message, e);
            }
        }


        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                this.InitializeGridItens();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.AdicionarItem();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEditarItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.EditarItem();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExcluirItem();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion




    }
}
