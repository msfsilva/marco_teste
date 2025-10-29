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
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaNotasFiscais;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class OpAguardandoExpedicaoServicoExterno : IWTListForm
    {
        private IObservacaoCustomizada _observacaoCustomizada;

        public OpAguardandoExpedicaoServicoExterno(IObservacaoCustomizada observacaoCustomizada = null)
        {
            _observacaoCustomizada = observacaoCustomizada;
            InitializeComponent();
        }

        #region ListForm

        public override Type getTipoEntidade()
        {
            return typeof(BibliotecaEntidades.Entidades.OrdemProducaoClass);
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
                new SearchParameterClass("AguardandoServicoExterno",true),
                new SearchParameterClass("PossuiSaldoEnvioPostoExterno",true),
                new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
            };
        }

        #endregion

        private void EnviarFornecedor()
        {

            if (this.getDataGrid().SelectedRowsIwt.Count == 0)
            {
                throw new ExcecaoTratada("Nenhuma linha foi selecionada");
            }

            if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá realizar o faturamento para envio dos materiais ao posto de serviço externo, deseja continuar?", "Envio para posto de Serviço Externo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            List<FaturamentoRemessaDto> listDtosFaturamento = new List<FaturamentoRemessaDto>();
            foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRowsIwt)
            {
                OrdemProducaoClass op = (OrdemProducaoClass) row.DataBoundItem;

                if (op.PostoUltimaLeituraEntidade == null) continue;

                OpAguardandoExpedicaoServicoExternoDadosForm form = new OpAguardandoExpedicaoServicoExternoDadosForm(op.PostoUltimaLeituraEntidade);
                form.ShowDialog(this);
                if (form.ToRet != null)
                {
                    listDtosFaturamento.Add(form.ToRet);
                }
            }



            if (listDtosFaturamento.Count == 0)
            {
                return;
            }

            FornecedorClass fornecedor = null;
            OperacaoCompletaClass operacaoCompleta = null;
            OperacaoClass operacao = null;
            TransporteClass transporte = null;


            foreach (FaturamentoRemessaDto dto in listDtosFaturamento)
            {
                if (fornecedor == null)
                {
                    //Primeiro
                    fornecedor = dto.Fornecedor;
                    operacaoCompleta = dto.OperacaoCompleta;
                    operacao = dto.Operacao;
                    transporte = dto.Transporte;
                    continue;
                }

                if (!fornecedor.Equals(dto.Fornecedor))
                {
                    throw new ExcecaoTratada("Não é possível realizar um faturamento para dois fornecedores diferentes, todos os lotes selecionados devem ser enviados para o mesmo fornecedor");
                }

                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    if (!operacaoCompleta.Equals(dto.OperacaoCompleta))
                    {
                        throw new ExcecaoTratada("Não é possível realizar um faturamento com duas operações fiscais diferentes, todos os lotes selecionados devem estar vinculados a mesma operação fiscal");
                    }
                }
                else
                {
                    if (!operacao.Equals(dto.Operacao))
                    {
                        throw new ExcecaoTratada("Não é possível realizar um faturamento com duas operações fiscais diferentes, todos os lotes selecionados devem estar vinculados a mesma operação fiscal");
                    }
                }

                if (transporte!=dto.Transporte)
                {
                    throw new ExcecaoTratada("Não é possível realizar um faturamento com dois transportes diferentes, todos os lotes selecionados devem ser enviados pelo mesmo transporte");
                }
            }


            VersaoLayoutNF versaoLayout = VersaoLayoutNF.Layout3_10;

            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                foreach (FaturamentoRemessaDto dto in listDtosFaturamento)
                {
                    OrdemProducaoEnvioTerceirosClass opet = new OrdemProducaoEnvioTerceirosClass(getUsuarioAtual(),command.Connection)
                    {
                        OrdemProducao = dto.OrdemProducao,
                        Transporte = dto.Transporte,
                        OperacaoCompleta = dto.OperacaoCompleta,
                        Fornecedor = dto.Fornecedor,
                        Operacao = dto.Operacao,
                        Quantidade = dto.Quantidade,
                        AcsUsuarioEnvio = getUsuarioAtual(),
                        DataEnvio = DataIndependenteClass.GetData(),
                        TotalmenteRecebido = false,
                    };

                    opet.Save(ref command);
                    dto.OrdemProducaoEnvioTerceiros = opet;
                    dto.OrdemProducao.CollectionOrdemProducaoEnvioTerceirosClassOrdemProducao.Add(opet);
                }

                NotaFiscalEasiClass nf = new NotaFiscalEasiClass(SingleConnection, getUsuarioAtual(), versaoLayout, (ArredondamentoNF)Enum.ToObject(typeof(ArredondamentoNF), Constants.ArredondamentoNF));
                EasiEmissorNFe emitenteNfe = EasiEmissorNFe.Primario;
                if (IWTConfiguration.Conf.getBoolConf(Constants.EMITENTE_NF_SECUNDARIO_HABILITADO))
                {
                    if (IWTConfiguration.Conf.getConf(Constants.EMISSOR_NFE_SERVICO_EXT) != "0")
                    {
                        emitenteNfe = EasiEmissorNFe.Secundario;
                    }
                }
               
                NfPrincipalClass nfEmitida = nf.EmitirNFRemessa(listDtosFaturamento, _observacaoCustomizada, ref command, emitenteNfe);

                if (nfEmitida != null)
                {
                    foreach (FaturamentoRemessaDto dto in listDtosFaturamento)
                    {
                        dto.OrdemProducaoEnvioTerceiros.NfPrincipal = nfEmitida;
                        dto.OrdemProducaoEnvioTerceiros.Save(ref command);
                    }


                    command.Transaction.Commit();
                }
                else
                {
                    BufferAbstractEntity.limparBuffer();
                    command.Transaction.Rollback();
                }
            }
            catch (Exception e)
            {
                BufferAbstractEntity.limparBuffer();

                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw e;
            }
        }

        private void CancelarSaldoEnvio()
        {

            if (this.getDataGrid().SelectedRowsIwt.Count == 0)
            {
                throw new ExcecaoTratada("Nenhuma linha foi selecionada");
            }

            if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá cancelar o saldo pendente para envio ao posto de serviço externo e não poderá ser desfeita, deseja continuar?", "Cancelamento de Saldo de Envio para Serviço Externo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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

                    OrdemProducaoClass op = (OrdemProducaoClass) row.DataBoundItem;

                    op.CollectionOrdemProducaoEnvioTerceirosCancelamentoSaldoClassOrdemProducao.Add(new OrdemProducaoEnvioTerceirosCancelamentoSaldoClass(getUsuarioAtual(), SingleConnection)
                    {
                         OrdemProducao= op,
                        AcsUsuario = getUsuarioAtual(),
                        Quantidade = op.SaldoEnvioFornecedor,
                        Data = DataIndependenteClass.GetData(),
                        Justificativa = form.Justificativa,
                    });

                    op.VerificaEncerramentoEnvioExterno(ref command);


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

        #region Eventos
        private void chkBuscaDataImpressao_CheckedChanged(object sender, EventArgs e)
        {
            grbBuscaDataImpressao.Enabled = chkBuscaDataImpressao.Checked;
        }
        
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

   
        private void btnEnviarFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                EnviarFornecedor();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.ForceInitializeDataGrid();
            }
        }



     
        private void btnCancelarSaldoEnvio_Click(object sender, EventArgs e)
        {
                        try
                        {
                            CancelarSaldoEnvio();
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
