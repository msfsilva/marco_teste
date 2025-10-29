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
using BibliotecaControleRevisao;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaNotasFiscais;
using Configurations;
using IWTDotNetLib;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class OpAguardandoExpedicaoServicoExternoDadosForm : IWTBaseForm
    {
        private readonly OrdemProducaoPostoTrabalhoClass _ordemProducaoPosto;


        public FaturamentoRemessaDto ToRet { get; private set; } = null;


        public OpAguardandoExpedicaoServicoExternoDadosForm(OrdemProducaoPostoTrabalhoClass ordemProducaoPosto)
        {
            _ordemProducaoPosto = ordemProducaoPosto;
            InitializeComponent();

            ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);
            ensOperacao.FormSelecao = new CadOperacaoListForm(TipoModulo.Tipo);
            ensOperacaoCompleta.FormSelecao = new CadOperacaoCompletaListForm();
            ensTransporte.FormSelecao = new CadTransporteListForm(TipoModulo.Tipo);

            this.lblDados.Text = "Ordem de Produção: " + _ordemProducaoPosto.OrdemProducao + " - Quantidade Máxima " + _ordemProducaoPosto.OrdemProducao.SaldoEnvioFornecedor.ToString("F5", CultureInfo.GetCultureInfo("pt-BR"));


            if (_ordemProducaoPosto.PostoTrabalho.Fornecedor != null)
            {
                ensFornecedor.EntidadeSelecionada = _ordemProducaoPosto.PostoTrabalho.Fornecedor;
                ensFornecedor.forceDisable();
            }

            if (_ordemProducaoPosto.PostoTrabalho.Transporte != null)
            {
                ensTransporte.EntidadeSelecionada = _ordemProducaoPosto.PostoTrabalho.Transporte;
                ensTransporte.forceDisable();
            }

            if (_ordemProducaoPosto.PostoTrabalho.Operacao != null)
            {
                ensOperacao.EntidadeSelecionada = _ordemProducaoPosto.PostoTrabalho.Operacao;
                ensOperacao.forceDisable();
            }

            if (_ordemProducaoPosto.PostoTrabalho.OperacaoCompleta != null)
            {
                ensOperacaoCompleta.EntidadeSelecionada = _ordemProducaoPosto.PostoTrabalho.OperacaoCompleta;
                ensOperacaoCompleta.forceDisable();
            }


            this.nudQuantidade.Maximum = (decimal) _ordemProducaoPosto.OrdemProducao.SaldoEnvioFornecedor;
            this.nudQuantidade.Value = this.nudQuantidade.Maximum;
        }

        private void Salvar()
        {
            if (this.ensFornecedor.EntidadeSelecionada == null)
            {
                throw new ExcecaoTratada("Indique o Fornecedor para a emissão da nota fiscal");
            }

            if (this.ensOperacao.EntidadeSelecionada == null && this.ensOperacaoCompleta.EntidadeSelecionada == null)
            {
                throw new ExcecaoTratada("Indique a Operação para a emissão da nota fiscal");
            }

            if (nudQuantidade.Value <= 0 || nudQuantidade.Value > (decimal) _ordemProducaoPosto.OrdemProducao.SaldoEnvioFornecedor)
            {
                throw new ExcecaoTratada("Quantidade Inválida");
            }

            ToRet = new FaturamentoRemessaDto()
            {
                Fornecedor =  (FornecedorClass) ensFornecedor.EntidadeSelecionada,
                OrdemProducao = _ordemProducaoPosto.OrdemProducao,
                Quantidade = (double) nudQuantidade.Value,
                Transporte = (TransporteClass) ensTransporte.EntidadeSelecionada,
                Operacao = (OperacaoClass) (!IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO)?ensOperacao.EntidadeSelecionada:null),
                OperacaoCompleta = (OperacaoCompletaClass) (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO) ? ensOperacaoCompleta.EntidadeSelecionada : null),
            };

            this.Close();
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                ensOperacao.forceDisable();
                ensOperacao.Visible = false;
            }
            else
            {
                ensOperacaoCompleta.forceDisable();
                ensOperacaoCompleta.Visible = false;
            }

            base.OnShown(e);
        }

        private void btnOk_Click(object sender, EventArgs e)
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

    }
}
