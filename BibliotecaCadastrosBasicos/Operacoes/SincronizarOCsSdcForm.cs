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
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos.Operacoes
{
    public partial class SincronizarOCsSdcForm : IWTBaseForm
    {
        private readonly OrdemCompraDto _dto;
        private readonly IWTPostgreNpgsqlConnection _conn;

        public FormaPagamentoClass FormaPagamento { get; private set; } = null;
        public string Observacoes { get; private set; } = null;

        public SincronizarOCsSdcForm(OrdemCompraDto dto, IWTPostgreNpgsqlConnection conn)
        {
            _dto = dto;
            _conn = conn;
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            try
            {
                FornecedorClass fornecedor = FornecedorClass.GetEntidade(_dto.fornecedorId, LoginClass.UsuarioLogado.loggedUser, _conn);

                if (fornecedor == null)
                {
                    throw new ExcecaoTratada("Fornecedor não encontrado com o ID " + _dto.id);
                }

                lblFornecedor.Text = fornecedor.ToString();
                lblData.Text = _dto.data.ToString("dd/MM/yyyy HH:mm:ss");
                txtObservacoes.Text = _dto.observacao;
                lblValor.Text = _dto.valorComDesconto.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));


                ensFormaPagamento.FormSelecao = new CadFormaPagamentoListForm(TipoModulo.Tipo);
                if (fornecedor.FormaPagamento != null)
                {
                    ensFormaPagamento.EntidadeSelecionada = fornecedor.FormaPagamento;
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ensFormaPagamento.EntidadeSelecionada == null)
                {
                    throw new ExcecaoTratada("Selecione a forma de pagamento antes de confirmar a sincronização");
                }

                FormaPagamento = (FormaPagamentoClass) ensFormaPagamento.EntidadeSelecionada;
                Observacoes = txtObservacoes.Text;

                this.Close();
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
