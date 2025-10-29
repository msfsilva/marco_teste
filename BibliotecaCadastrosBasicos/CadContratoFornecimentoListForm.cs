using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadContratoFornecimentoListForm : IWTListForm
    {
        private TipoForm Tipo;

        public CadContratoFornecimentoListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }

        public override Type getTipoEntidade()
        {
            return typeof(ContratoFornecimentoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadContratoFornecimentoForm form = new CadContratoFornecimentoForm((ContratoFornecimentoClass)entidade, this);
                form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
                form.ShowDialog();
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
            return new List<SearchParameterClass>() { new SearchParameterClass("cfo_inicio", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Data) };
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Editar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Editar()
        {


            try
            {
                if (this.iwtDataGridView1.SelectedRows.Count > 0)
                {
                    if (((ContratoFornecimentoClass)((IWTDataGridViewRow)this.iwtDataGridView1.SelectedRows[0]).DataBoundItem).Situacao != StatusContratoFornecimento.Normal)
                    {
                        throw new Exception("Só é possível editar um contrato ativo.");
                    }


                    CadContratoFornecimentoForm form = new CadContratoFornecimentoForm(((ContratoFornecimentoClass)((IWTDataGridViewRow)this.iwtDataGridView1.SelectedRows[0]).DataBoundItem), this);
                    form.ShowDialog();
                    this.initializeDataGrid(this.parametroBuscaAtuais);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar o item.\r\n" + e.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.iwtDataGridView1.SelectedRows.Count > 0)
                {

                    if (MessageBox.Show(this, "Você deseja cancelar o item selecionado?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        if (((ContratoFornecimentoClass)((IWTDataGridViewRow)this.iwtDataGridView1.SelectedRows[0]).DataBoundItem).Situacao != 0)
                        {
                            throw new Exception("Só é possível editar um contrato ativo.");
                        }

                        ((ContratoFornecimentoClass) ((IWTDataGridViewRow)this.iwtDataGridView1.SelectedRows[0]).DataBoundItem).Cancelar();


                        this.initializeDataGrid(this.parametroBuscaAtuais);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja cancelar.");
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this,"Erro ao cancelar o item.\r\n"+ a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected override void OnShown(EventArgs e)
        {
            
            base.OnShown(e);
            this.rdbAtivos.Checked = true;
        }
    }
}
