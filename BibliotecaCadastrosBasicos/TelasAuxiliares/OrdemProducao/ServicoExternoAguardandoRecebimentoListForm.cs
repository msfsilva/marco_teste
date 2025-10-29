using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class ServicoExternoAguardandoRecebimentoListForm : IWTListForm
    {
        private readonly bool _somenteVisualizacao;

        public ServicoExternoAguardandoRecebimentoListForm(bool somenteVisualizacao = false)
        {
            _somenteVisualizacao = somenteVisualizacao;
            InitializeComponent();
        }

        #region ListForm
        public override Type getTipoEntidade()
        {
            return typeof(OrdemProducaoEnvioTerceirosClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
               
            }
            catch (ExcecaoTratada)
            {
                throw;
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
            return new List<SearchParameterClass>()
            {
                new SearchParameterClass("OrdemProducao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                new SearchParameterClass("TotalmenteRecebido",false)
            };
        }

        #endregion

        private void CancelamentoSaldoRecebimento()
        {
            if (this.getDataGrid().SelectedRowsIwt.Count == 0)
            {
                throw new ExcecaoTratada("Nenhuma linha foi selecionada");
            }

            if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá cancelar o saldo pendente de recebimento do posto de serviço externo e não poderá ser desfeita, deseja continuar?", "Cancelamento de Saldo de Recebimento de Serviço Externo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            JustificativaForm form = new JustificativaForm("Informe o motivo para o cancelamento do saldo de envio para posto de serviço externo");
            form.ShowDialog(this);
            if (form.Abortar)
            {
                return;
            }

            foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRowsIwt)
            {
                IWTPostgreNpgsqlCommand command = null;
                try
                {
                    command = SingleConnection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    OrdemProducaoEnvioTerceirosClass opEnvio = (OrdemProducaoEnvioTerceirosClass)row.DataBoundItem;

                    opEnvio.CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros.Add(new OrdemProducaoEnvioTerceirosCancSaldoRecebClass(getUsuarioAtual(), SingleConnection)
                    {
                        OrdemProducaoEnvioTerceiros = opEnvio,
                        AcsUsuario = getUsuarioAtual(),
                        Quantidade = opEnvio.SaldoRecebimento,
                        Data = DataIndependenteClass.GetData(),
                        Justificativa = form.Justificativa,
                    });

                    opEnvio.VerificaEncerramentoRecebimento(ref command);


                    command.Transaction.Commit();

                }
                catch
                {
                    command?.Transaction?.Rollback();
                    BufferAbstractEntity.limparBuffer();

                    throw;
                }
                finally
                {
                    ForceInitializeDataGrid();
                }

            }
        }


        private void RecebimentoManual()
        {
            try
            {
                if (this.getDataGrid().SelectedRowsIwt.Count == 0)
                {
                    throw new ExcecaoTratada("Nenhuma linha foi selecionada");
                }

                if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá realizar o recebimento do material enviado anteriormente ao posto de serviço externo e não poderá ser desfeita, deseja continuar?", "Recebimento Manual de Posto de Serviço Externo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                foreach (IWTDataGridViewRow row in getDataGrid().SelectedRowsIwt)
                {
                    ServicoExternoRecebimentoManualForm form = new ServicoExternoRecebimentoManualForm((OrdemProducaoEnvioTerceirosClass) row.DataBoundItem);
                    form.ShowDialog(this);
                }

            }
            catch
            {
                BufferAbstractEntity.limparBuffer();
                throw;
            }
            finally
            {
                ForceInitializeDataGrid();
            }

        }

        #region Eventos

        private void chkIdOP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIdOP.Checked)
            {
                this.nudIdOrdemProducao.removeForceDisable();
            }
            else
            {
                this.nudIdOrdemProducao.forceDisable();
            }
        }

        private void btnCancelamentoSaldoRecebimento_Click(object sender, EventArgs e)
        {
            try
            {
                CancelamentoSaldoRecebimento();
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

        private void btnRecebimentoManual_Click(object sender, EventArgs e)
        {
            try
            {
                RecebimentoManual();
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnCancelamentoSaldoRecebimento.Visible = !_somenteVisualizacao;
            this.btnRecebimentoManual.Visible = !_somenteVisualizacao;
        }

        #endregion

    }
}
