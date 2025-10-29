using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public partial class SubstituicaoMassaItensEstruturaForm : IWTBaseForm
    {
        private TipoItemEstrutura _tipoAtual = TipoItemEstrutura.PostoTrabalho;
        public SubstituicaoMassaItensEstruturaForm()
        {
            InitializeComponent();

            TrocarTipo(TipoItemEstrutura.Documento);
        }

        private void TrocarTipo(TipoItemEstrutura tipo)
        {
            try
            {

                if (tipo == _tipoAtual)
                {
                    return;
                }
                ensOrigem.EntidadeSelecionada = null;
                ensSubstituto.EntidadeSelecionada = null;

                switch (tipo)
                {
                    case TipoItemEstrutura.Produto:
                        ensOrigem.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, true, somenteAtivos: true);
                        ensSubstituto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, true, somenteAtivos: true);
                        break;
                    case TipoItemEstrutura.Material:
                        ensOrigem.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo, true, somenteAtivos: true);
                        ensSubstituto.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo, true, somenteAtivos: true);
                        break;
                    case TipoItemEstrutura.Documento:
                        ensOrigem.FormSelecao = new CadDocumentoTipoFamiliaListForm(TipoModulo.Tipo);
                        ensSubstituto.FormSelecao = new CadDocumentoTipoFamiliaListForm(TipoModulo.Tipo);
                        break;
                    case TipoItemEstrutura.Recurso:
                        ensOrigem.FormSelecao = new CadRecursoListForm(TipoModulo.Tipo);
                        ensSubstituto.FormSelecao = new CadRecursoListForm(TipoModulo.Tipo);
                        break;
                    case TipoItemEstrutura.Acabamento:
                        ensOrigem.FormSelecao = new CadAcabamentoListForm(TipoModulo.Tipo);
                        ensSubstituto.FormSelecao = new CadAcabamentoListForm(TipoModulo.Tipo);
                        break;
                    case TipoItemEstrutura.PostoTrabalho:
                        ensOrigem.FormSelecao = new CadPostoTrabalhoListForm(TipoModulo.Tipo);
                        ensSubstituto.FormSelecao = new CadPostoTrabalhoListForm(TipoModulo.Tipo);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(tipo), tipo, null);
                }

                _tipoAtual = tipo;

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao trocar o tipo de entidade:" + e.Message, e);
            }
        }

        private void Confirmar()
        {

            try
            {
                if (ensOrigem.EntidadeSelecionada == null)
                {
                    throw new ExcecaoTratada("O item a ser substituído não foi selecionado");
                }

                if (ensSubstituto.EntidadeSelecionada == null)
                {
                    throw new ExcecaoTratada("O item substituto não foi selecionado");
                }


                if (ensSubstituto.EntidadeSelecionada == ensOrigem.EntidadeSelecionada)
                {
                    throw new ExcecaoTratada("O item substituto é igual ao item substituído");
                }

                if (string.IsNullOrWhiteSpace(txtJustificativa.Text) || txtJustificativa.Text.Length < 10)
                {
                    throw new ExcecaoTratada("A justificativa é obrigatória e deve ter ao menos 10 caracteres");
                }

                if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá realizar a substituição dos itens conforme solicitado. Ela não poderá ser desfeita, deseja continuar?", "Substituição", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    return;
                }

                string justificativa = txtJustificativa.Text + "(Realizada por: " + LoginClass.UsuarioLogado.loggedUser.Login + ")";
                ProdutoClass.SubstituirItemEstruturas(ensOrigem.EntidadeSelecionada, ensSubstituto.EntidadeSelecionada, _tipoAtual, justificativa, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                MessageBox.Show(this, "Substituição realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao efetivar a operação:" + e.Message, e);
            }
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            BufferAbstractEntity.limparBuffer();
            this.Close();
        }
        /*
        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbProduto.Checked)
                {
                    TrocarTipo(TipoItemEstrutura.Produto);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbMaterial.Checked)
                {
                    TrocarTipo(TipoItemEstrutura.Material);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
        private void rdbDocumento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbDocumento.Checked)
                {
                    TrocarTipo(TipoItemEstrutura.Documento);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbRecurso_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbRecurso.Checked)
                {
                    TrocarTipo(TipoItemEstrutura.Recurso);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbAcabamento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbAcabamento.Checked)
                {
                    TrocarTipo(TipoItemEstrutura.Acabamento);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Confirmar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        #endregion

    }
}
