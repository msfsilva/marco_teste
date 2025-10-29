using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public partial class AutorizacaoQualidadeForm : IWTBaseForm
    {
        public bool Liberado { get; private set; } = false;

        private readonly Entidades.OrdemProducaoClass _ordemProducao;
        private IWTPostgreNpgsqlCommand _command;

        public AutorizacaoQualidadeForm(Entidades.OrdemProducaoClass ordemProducao, IWTPostgreNpgsqlCommand command)
        {
            _ordemProducao = ordemProducao;
            _command = command;
            InitializeComponent();
        }
        private void Liberar()
        {
            
            try
            {
                LoginClass lg = new LoginClass(SingleConnection);
                lg.LoginUser(txtUsuario.Text, txtSenha.Text);

                if (!lg.loggedUser.HasAnyAccess(Constants.LIBERAÇAO_QUALIDADE_OP))
                {
                    throw new ExcecaoTratada("O usuário selecionado não possui a permissão necessária para fazer essa liberação, verifique o controle de acessos");
                }

                if (string.IsNullOrWhiteSpace(txtObservacaoQualidade.Text) || txtObservacaoQualidade.Text.Trim().Length < 6)
                {
                    throw new ExcecaoTratada("A observação da liberação é obrigatória e deve ter mais de 5 caracteres");
                }

                _ordemProducao.AcsUsuarioLiberacaoQualidade = lg.loggedUser;
                _ordemProducao.ObservacaoLiberacaoQualidade = txtObservacaoQualidade.Text.Trim();

                _ordemProducao.Save(ref _command);

                Liberado = true;

                this.Close();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao liberar:" + e.Message, e);
            }
            
        }
        private void AtualizaDadosTela()
        {
            
            try
            {
                if (_ordemProducao != null)
                {
                    lblOp.Text = _ordemProducao.ID.ToString();
                    lblProduto.Text = _ordemProducao.ProdutoCodigo;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao atualizar os dados da tela:" + e.Message, e);
            }
        }

        #region Eventos
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            try
            {
                Liberar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void AutorizacaoQualidadeForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.AtualizaDadosTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        #endregion
    }
}
