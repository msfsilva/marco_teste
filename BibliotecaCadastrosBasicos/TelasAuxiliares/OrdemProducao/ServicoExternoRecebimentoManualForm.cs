using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class ServicoExternoRecebimentoManualForm : IWTBaseForm
    {
        private readonly OrdemProducaoEnvioTerceirosClass _envio;
        private NotaFiscalEntradaClass _notaFiscalEntrada;
        private NotaFiscalEntradaLinhaClass _linha;

        public ServicoExternoRecebimentoManualForm(OrdemProducaoEnvioTerceirosClass envio)
        {
            _envio = envio;
            InitializeComponent();

        }

        private void CarregarNFe(string codigoBarras)
        {

            if (string.IsNullOrWhiteSpace(codigoBarras))
                return;


            NotaFiscalEntradaClass notaFiscalEntrada = NotaFiscalEntradaClass.GetByChave(codigoBarras, LoginClass.UsuarioLogado.loggedUser, SingleConnection);
            if (notaFiscalEntrada == null)
            {
                _notaFiscalEntrada = null;
                this.lblInformacoesNfe.Text = "";

                throw new ExcecaoTratada("Não foi encontrada nota fiscal importada com a chave " + codigoBarras);
            }

            if (notaFiscalEntrada.TotalmenteRecebida)
            {
                _notaFiscalEntrada = null;
                this.lblInformacoesNfe.Text = "";

                throw new ExcecaoTratada("A nota fiscal já foi recebida totalmente");
            }


            if (_envio.Fornecedor != notaFiscalEntrada.Fornecedor)
            {
                _notaFiscalEntrada = null;
                throw new ExcecaoTratada("O fornecedor identificado para a nota fiscal não corresponde ao fornecedor do envio selecionado");
            }

            _notaFiscalEntrada = notaFiscalEntrada;


            this.nudLinhaNota.Maximum = _notaFiscalEntrada.CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Max(a => a.Linha);
            this.nudLinhaNota.Minimum = _notaFiscalEntrada.CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Min(a => a.Linha);

            this.nudLinhaNota.Enabled = true;

            this.lblInformacoesNfe.Text =
                "Nota fiscal Nº. " + _notaFiscalEntrada.NumeroNf + Environment.NewLine +
                "Fornecedor: " + _notaFiscalEntrada.Fornecedor + Environment.NewLine +
                "Data da Nota: " + _notaFiscalEntrada.DataNf.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine +
                "Importação: " + _notaFiscalEntrada.DataImportacao.ToString("dd/MM/yyyy HH:mm:ss");


            this.txtChaveNota.forceDisable();
        }

        private void CarregaLinhaNfe()
        {
            NotaFiscalEntradaLinhaClass linha = _notaFiscalEntrada.CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.FirstOrDefault(a => a.Linha == nudLinhaNota.Value);
            if (linha == null)
            {
                _linha = null;
                this.lblInformacoesItens.Text = "";
                this.btnSalvar.Enabled = false;
                this.nudQuantidadeReceber.Enabled = false;
                throw new ExcecaoTratada("Não foi encontrada linha " + nudLinhaNota.Value + " na nota fiscal selecionada");
            }

            if (linha.Vinculada)
            {
                _linha = null;
                this.lblInformacoesItens.Text = "";
                this.btnSalvar.Enabled = false;
                this.nudQuantidadeReceber.Enabled = false;

                throw new ExcecaoTratada("A linha " + nudLinhaNota.Value + " na nota fiscal selecionada já foi totalmente recebida");
            }

            _linha = linha;

            lblInformacoesItens.Text =
                "Item Esperado: " + _envio.OrdemProducao.ProdutoCodigo + Environment.NewLine +
                "Quantidade Esperada: " + _envio.SaldoRecebimento.ToString("F", CultureInfo.GetCultureInfo("pt-BR")) + Environment.NewLine +
                Environment.NewLine +
                "Item da Nota: " + linha.Codigo + Environment.NewLine +
                "Quantidade na Nota: " + linha.Quantidade.ToString("F", CultureInfo.GetCultureInfo("pt-BR")) + Environment.NewLine +
                "Número do Pedido na Nota: " + linha.Xped + "/" + linha.Posicao;

            this.nudQuantidadeReceber.Enabled = true;

            this.nudQuantidadeReceber.Maximum = (decimal)linha.Quantidade;
            this.nudQuantidadeReceber.Value = (decimal) linha.Quantidade;
            

            this.btnSalvar.Enabled = true;
        }



        private void Salvar()
        {
            if (_notaFiscalEntrada == null || _linha == null)
            {
                throw new ExcecaoTratada("Informe a nota fiscal e a linha da nota antes de continuar.");
            }

            if (nudQuantidadeReceber.Value <= 0)
            { 
                throw new ExcecaoTratada("Não é possível salvar um recebimento com quantidade zero");
            }

            if (nudQuantidadeReceber.Value > (decimal) _envio.SaldoRecebimento)
            {
                if (DialogResult.Yes != MessageBox.Show(this, "A quantidade selecionada é maior do que o saldo de recebimento do envio, se você continuar com a operação o sistema irá encerrar esse envio com a quantidade a mais, o que poderá refletir na quantidade final da OP. Deseja Continuar?", "Recebimento de Material de Serviço Externo com quantidade maior", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }

            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                OrdemProducaoEnvioTerceirosRecebimentoClass receb = new OrdemProducaoEnvioTerceirosRecebimentoClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection)
                {
                    Quantidade = (double) nudQuantidadeReceber.Value,
                    OrdemProducaoEnvioTerceiros = _envio,
                    AcsUsuarioRecebimento = LoginClass.UsuarioLogado.loggedUser,
                    DataRecebimento = DataIndependenteClass.GetData(),
                    NotaFiscalEntradaLinha = _linha
                };

                receb.Save(ref command);

                _envio.CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Add(receb);

                _envio.VerificaEncerramentoRecebimento(ref command);


                _linha.Vinculada = true;
                _linha.Save(ref command);

                command.Transaction.Commit();
                
                Close();
            }
            catch
            {
                command?.Transaction?.Rollback();
                throw;
            }
        }


        #region Eventos


        private void nudLinhaNota_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CarregaLinhaNfe();
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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
                        try
                        {
                            Salvar();
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



        #endregion

        private void btnNota_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarNFe(txtChaveNota.Text);
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

        private void txtChaveNota_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnNota_Click(null, null);
                }
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
    }
}
