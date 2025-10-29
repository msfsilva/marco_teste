#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTTreeComponent;
using ProjectConstants;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public partial class NewConfigurarExibicaoEstruturaForm : IWTBaseForm
    {
        readonly AcsUsuarioClass Usuario;
        readonly CadProdutoEstruturaFormNew formPai;
        public NewConfigurarExibicaoEstruturaForm(CadProdutoEstruturaFormNew formPai, tipoExibicao _tipoExibicao, int larguraVertical, int alturaVertical,
            int larguraHorizontal, int alturaHorizontal, int larguraArvoreHorizontal, int alturaArvoreHorizontal, bool Negrito, int tamanhoFonte, bool negritoLigacao, int tamanhoFonteLigacao, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            this.formPai = formPai;
            switch (_tipoExibicao)
            {
                case tipoExibicao.Vertical:
                    this.rdbVertical.Checked = true;
                    this.rdbHorizontal.Checked = false;
                    this.rdbArvoreHorizontal.Checked = false;
                    break;
                case tipoExibicao.Horizontal:
                    this.rdbVertical.Checked = false;
                    this.rdbHorizontal.Checked = true;
                    this.rdbArvoreHorizontal.Checked = false;
                    break;
                case tipoExibicao.HorizontalNovo:
                    this.rdbVertical.Checked = false;
                    this.rdbHorizontal.Checked = false;
                    this.rdbArvoreHorizontal.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.nudLarguraVertical.Value = larguraVertical;
            this.nudAlturaVertical.Value = alturaVertical;
            this.nudLarguraHorizontal.Value = larguraHorizontal;
            this.nudAlturaHorizontal.Value = alturaHorizontal;
            this.nudLarguraArvoreHorizontal.Value = larguraArvoreHorizontal;
            this.nudAlturaArvoreHorizontal.Value = alturaArvoreHorizontal;

            this.chkNegrito.Checked = Negrito;
            this.nudTamanhoFonte.Value = tamanhoFonte;

            this.chkNegritoLigacao.Checked = negritoLigacao;
            this.nudTamanhoFonteLigacao.Value = tamanhoFonteLigacao;
            this.Usuario = Usuario;

        }

        private void Aplicar()
        {
            try
            {
                tipoExibicao tipo = tipoExibicao.Horizontal;

                if (this.rdbArvoreHorizontal.Checked)
                {
                    tipo = tipoExibicao.HorizontalNovo;
                }

                if (this.rdbHorizontal.Checked)
                {
                    tipo = tipoExibicao.Horizontal;
                }

                if (this.rdbVertical.Checked)
                {
                    tipo = tipoExibicao.Vertical;
                }

                this.formPai.AplicarMudancasEstrutura(tipo, (int)this.nudLarguraVertical.Value,
                    (int)this.nudAlturaVertical.Value, (int)this.nudLarguraHorizontal.Value,
                    (int)this.nudAlturaHorizontal.Value, 
                    (int)this.nudLarguraArvoreHorizontal.Value,(int)this.nudAlturaArvoreHorizontal.Value,
                    this.chkNegrito.Checked, (int)this.nudTamanhoFonte.Value, this.chkNegritoLigacao.Checked,
                    (int)this.nudTamanhoFonteLigacao.Value);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao aplicar as alterações na tela de estrutura.\r\n" + e.Message);
            }
        }

        private void SalvarConfs()
        {
            try
            {
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_ALTURA_HORIZONTAL, this.nudAlturaHorizontal.Value.ToString());
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_ALTURA_VERTICAL, this.nudAlturaVertical.Value.ToString());
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_LARGURA_HORIZONTAL, this.nudLarguraHorizontal.Value.ToString());
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_LARGURA_VERTICAL, this.nudLarguraVertical.Value.ToString());
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_NEGRITO, this.chkNegrito.Checked.ToString());
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_NEGRITO_LIGACAO, this.chkNegritoLigacao.Checked.ToString());
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_TAMANHO_FONTE, Math.Truncate(this.nudTamanhoFonte.Value).ToString());
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_TAMANHO_FONTE_LIGACAO, Math.Truncate(this.nudTamanhoFonteLigacao.Value).ToString());

                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_ALTURA_ARVORE_HORIZONTAL, this.nudAlturaArvoreHorizontal.Value.ToString());
                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_LARGURA_ARVORE_HORIZONTAL, this.nudLarguraArvoreHorizontal.Value.ToString());

                tipoExibicao _tipoExibicao = tipoExibicao.Horizontal;
                if (this.rdbArvoreHorizontal.Checked)
                {
                    _tipoExibicao = tipoExibicao.HorizontalNovo;
                }

                if (this.rdbHorizontal.Checked)
                {
                    _tipoExibicao = tipoExibicao.Horizontal;
                }

                if (this.rdbVertical.Checked)
                {
                    _tipoExibicao = tipoExibicao.Vertical;
                }


                ConfiguracaUsuario.ConfUsuario.saveConf(Constants.ESTRUTURA_MODO_PADRAO, Convert.ToInt16(_tipoExibicao).ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar as alterações da tela de estrutura nas configurações.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Aplicar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (this.editado)
                {
                    DialogResult res = MessageBox.Show(this, "Você está saindo sem aplicar as alterações, deseja que o sistema aplique antes de sair?", "Mudanças detectadas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    switch (res)
                    {
                        case DialogResult.Cancel:
                            return;
                            break;
                        case DialogResult.Yes:
                            this.Aplicar();
                            break;
                        case DialogResult.No:
                            break;
                    }

                }
                */
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void nudTamanhoFonte_ValueChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void chkNegrito_CheckedChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void nudAltura_ValueChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void nudLargura_ValueChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void rdbHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void rdbVertical_CheckedChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }
   
        private void chkNegritoLigacao_CheckedChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void nudTamanhoFonteLigacao_ValueChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }
       

        private void nudLarguraHorizontal_ValueChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void nudAlturaHorizontal_ValueChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }
      
   

        private void ConfigurarExibicaoEstruturaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.SalvarConfs();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbArvoreHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void nudLarguraArvoreHorizontal_ValueChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        private void nudAlturaArvoreHorizontal_ValueChanged(object sender, EventArgs e)
        {
            this.Aplicar();
        }

        #endregion
    }
}
