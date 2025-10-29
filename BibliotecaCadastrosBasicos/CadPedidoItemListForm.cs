using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.ClassesAuxiliares;
using BibliotecaComunicacaoGAD.api;
using BibliotecaComunicacaoGAD.dto;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaPedidos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTDotNetLib.TelaProgresso;
using IWTPostgreNpgsql;
using ProjectConstants;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemListForm : IWTListForm
    {
        private TipoForm Tipo;
        private readonly bool _somentePendentes;
        private readonly ClienteClass _cliente;
        private readonly bool _somentePais;

        private System.Windows.Forms.DataGridViewTextBoxColumn _colunaSituacaoGad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colunaMensagemSituacaoGad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colunaProgramacaoDataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colunaProgramacaoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colunaProgramacaoSituacaoGad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colunaProgramacaoSituacaoGadMensagem;

        public CadPedidoItemListForm(TipoForm tipo, bool somentePendentes = false, ClienteClass cliente = null, bool somentePais = false)
        {
            InitializeComponent();
            this.Tipo = tipo;
            _somentePendentes = somentePendentes;
            _cliente = cliente;
            _somentePais = somentePais;
        }


        #region Funcoes ListForm

        public override Type getTipoEntidade()
        {
            return typeof(PedidoItemClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                if (entidade == null || entidade.ID == -1)
                {
                    if (!LoginClass.UsuarioLogado.HasAccess("MODULO_PCP_PEDIDOS_VALORES", AcsTipoAcesso.Escrita))
                    {
                        MessageBox.Show(this, "Desculpe não é possível utilizar essa funcionalidade pois o seu usuário não possui acesso aos valores dos pedidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }

                }

                CadPedidoItemForm form = new CadPedidoItemForm((PedidoItemClass) entidade, this, this.Tipo);
                form.VerificaUtilizacao = false;
                form.ShowDialog();
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
            List<SearchParameterClass> toRet = new List<SearchParameterClass>()
            {
                new SearchParameterClass("SubLinha", 0),
                new SearchParameterClass("Numero", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                new SearchParameterClass("Posicao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
            };

            if (_somentePendentes)
            {
                toRet.Add(new SearchParameterClass("Pendente", true));
            }

            if (_cliente != null)
            {
                toRet.Add(new SearchParameterClass("Cliente", _cliente));
            }

            if (_somentePais)
            {
                toRet.Add(new SearchParameterClass("SubLinha", 0));
            }


            return toRet;
        }

        #endregion

        private void Cancelar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.getDataGrid().SelectedRows.Count < 1)
                {
                    throw new Exception("Selecione ao menos um pedido para ser cancelado.");
                }



                if (MessageBox.Show(this, "Você deseja Cancelar o(s) pedido(s) selecionado(s)?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<PedidoItemClass> pedidos = new List<PedidoItemClass>();

                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        PedidoItemClass pedido = (PedidoItemClass) row.DataBoundItem;
                        if (pedido.Status != StatusPedido.Pendente && pedido.Status != StatusPedido.Reaberto)
                        {
                            throw new Exception("Só é possível cancelar pedidos pendentes ou reabertos (" + pedido + ").");
                        }

                        pedidos.Add(pedido);
                    }

                    CadPedidoItemCancelamentoForm form = new CadPedidoItemCancelamentoForm();
                    form.ShowDialog();

                    if (form.Confirmado)
                    {

                        command = SingleConnection.CreateCommand();
                        command.Transaction = command.Connection.BeginTransaction();
                        foreach (PedidoItemClass pedido in pedidos)
                        {
                            pedido.Cancelar(form.Justificativa, command);
                        }
                        command.Transaction.Commit();

                        MessageBox.Show(this, "Pedidos/Orçamentos cancelados com sucesso!", "Cancelamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ForceInitializeDataGrid();
                    }
                }

                else
                {
                    return;
                }

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao cancelar o item selecionado.\r\n" + e.Message);
            }
        }

        private void Encerrar()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count != 1)
                {
                    throw new Exception("Selecione um pedido para encerrar.");
                }

                if (MessageBox.Show(this, "Você deseja Encerrar o item selecionado?", "Encerramento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PedidoItemClass pedido = (PedidoItemClass) ((IWTDataGridViewRow) this.getDataGrid().SelectedRows[0]).DataBoundItem;


                    if (pedido.Status != StatusPedido.Pendente && pedido.Status != StatusPedido.Reaberto)
                    {
                        throw new Exception("Só é possível encerrar pedidos pendentes ou reabertos.");
                    }
                    else
                    {


                        if (pedido.Saldo == 0)
                        {
                            pedido.EncerrarSemSaldo(this.getUsuarioAtual());
                        }
                        else
                        {
                            if (DialogResult.Yes ==
                                MessageBox.Show(this, "Esse pedido possui saldo pendente, você deseja cancelar o saldo e encerrar o pedido? Caso a resposta seja \"Não\", será apresentada a opção de lançamento manual de NF.", "Cancelamento de Saldo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {

                                pedido.EncerrarSemSaldo(this.getUsuarioAtual());
                            }
                            else
                            {

                                CadPedidoItemEncerramentoForm form = new CadPedidoItemEncerramentoForm(pedido, this.getUsuarioAtual());
                                form.ShowDialog();
                            }
                        }
                        this.getDataGrid().InvalidateRow(this.getDataGrid().SelectedRows[0].Index);
                    }
                }

                else
                {
                    return;
                }

            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao encerrar o item selecionado.\r\n" + e.Message);
            }
        }

        private void relatorioMateriais()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    List<PedidoSelecaoClass> selecionados = new List<PedidoSelecaoClass>();
                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        PedidoItemClass pedido = (PedidoItemClass) row.DataBoundItem;

                        if (pedido.Configurado)
                        {
                            selecionados.Add(new PedidoSelecaoClass(pedido.Numero, pedido.Posicao, pedido.Cliente.ID));

                        }
                        else
                        {
                            throw new Exception("Não é possível verificar os materiais de um pedido (" + pedido + ") não configurado .");
                        }
                    }

                    if (selecionados.Count > 0)
                    {
                        MateriaisPedidoReportForm form = new MateriaisPedidoReportForm(selecionados);
                        form.Show();
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o consumo de materiais.\r\n" + e.Message, e);
            }
        }

        private void imprimirPedidos()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {

                    List<PedidoEspelhoParametrosBuscaClass> parametrosBusca = new List<PedidoEspelhoParametrosBuscaClass>();
                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        PedidoItemClass pedido = (PedidoItemClass) row.DataBoundItem;
                        PedidoEspelhoParametrosBuscaClass parametros = new PedidoEspelhoParametrosBuscaClass
                        {
                            idCliente = pedido.Cliente.ID,
                            numero = pedido.Numero,
                            posicao = pedido.Posicao
                        };
                        parametrosBusca.Add(parametros);
                    }


                    PedidoEspelhoReportForm form = new PedidoEspelhoReportForm(parametrosBusca, PedidoOrcamento.Pedido);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show(this, "Selecione um pedido para imprimir.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FaturarPedido()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    if (
                        MessageBox.Show(this, "Essa operação irá criar um embarque já liberado para faturamento contendo os pedidos selecionados, dispensando-os da realização do processo de expedição e conferência. Deseja continuar?",
                            "Faturar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }


                    List<PedidoItemClass> pedidosFaturar = new List<PedidoItemClass>();
                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {

                        pedidosFaturar.Add((PedidoItemClass) row.DataBoundItem);

                    }

                    if (pedidosFaturar.Count == 0)
                    {
                        throw new ExcecaoTratada("Não foi possível encontrar nenhum registro para os pedidos selecionados, entre em contato com a equipe IWT");
                    }

                    int numeroPallet;
                    long numeroEmbarque;
                    PedidoItemClass.FaturarPedidos(pedidosFaturar, out numeroPallet, out numeroEmbarque, this.SingleConnection);

                    MessageBox.Show(this, "O embarque para os pedidos foi criado com sucesso! Os pedidos foram incluídos no pallet " + numeroPallet + ". O embarque " + numeroEmbarque + " foi criado e liberado para o faturamento", "Faturar Pedidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("\r\n" + e.Message, e);
            }
        }

        private void Suspender()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count == 1)
                {

                    PedidoItemClass pedido = (PedidoItemClass) ((IWTDataGridViewRow) this.getDataGrid().SelectedRows[0]).DataBoundItem;

                    string mensagem;
                    if (pedido.Status == StatusPedido.Suspenso)
                    {
                        mensagem = "Essa operação irá retirar o pedido da suspensão, deseja continuar?";
                    }
                    else
                    {
                        mensagem = "Essa operação irá suspender a produção do pedido, deseja continuar?";
                    }

                    if (

                        MessageBox.Show(this, mensagem, "Suspensão do Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }


                    CadPedidoItemJustificativaForm form = new CadPedidoItemJustificativaForm(pedido);
                    form.ShowDialog(this);
                    if (!form.Abortar)
                    {
                        if (pedido.Status_Suspenso)
                        {
                            pedido.RemoverSuspencao(form.Justificativa);
                            MessageBox.Show(this, "Pedido retirado de suspensão com sucesso!", "Retirada de suspensão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            pedido.Suspender(form.Justificativa);
                            MessageBox.Show(this, "Pedido suspenso com sucesso!", "Suspensão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        this.getDataGrid().InvalidateRow(this.getDataGrid().SelectedRows[0].Index);
                        this.GerenciarBotaoSuspensao();
                    }


                }
                else
                {
                    throw new ExcecaoTratada("Selecione um pedido para suspender/retirar suspensão");
                }

            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("\r\n" + e.Message, e);
            }
        }

        private void GerenciarBotaoSuspensao()
        {
            if (this.getDataGrid().SelectedRows.Count == 1)
            {
                PedidoItemClass pedido = (PedidoItemClass) ((IWTDataGridViewRow) this.getDataGrid().SelectedRows[0]).DataBoundItem;

                if (pedido != null)
                {
                    this.btnSuspender.Text = pedido.Status_Suspenso ? "Retirar Suspensão" : "Suspender";
                }
            }
        }

        private void NovoFeedback(bool secundario)
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count < 1)
                {
                    throw new Exception("Selecione ao menos um pedido para incluir um feedback.");
                }

                List<PedidoItemClass> pedidos = new List<PedidoItemClass>();

                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    PedidoItemClass pedido = (PedidoItemClass) row.DataBoundItem;
                    //if (pedido.Status != StatusPedido.Pendente && pedido.Status != StatusPedido.Reaberto)
                    //{
                    //    throw new Exception("Só é possível incluir feedbacks em pedidos pendentes ou reabertos (" + pedido + ").");
                    //}
                    //else
                    //{
                        pedidos.Add(pedido);
                    //}
                }

                CadPedidoItemFeedbackForm form = new CadPedidoItemFeedbackForm(pedidos, secundario);
                form.ShowDialog(this);

                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    this.getDataGrid().InvalidateRow(row.Index);
                }



            }
            catch (ExcecaoTratada)
            {
                BufferAbstractEntity.limparBuffer();
                this.ForceInitializeDataGrid();
                throw;
            }
            catch (Exception e)
            {
                BufferAbstractEntity.limparBuffer();
                this.ForceInitializeDataGrid();
                throw new Exception("Erro inesperado ao inserir um novo feedback.\r\n" + e.Message, e);
            }
        }

        private void AlterarUrgencia()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count < 1)
                {
                    throw new Exception("Selecione ao menos um pedido para alterar a urgência.");
                }

                List<PedidoItemClass> pedidos = new List<PedidoItemClass>();

                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    PedidoItemClass pedido = (PedidoItemClass) row.DataBoundItem;
                    if (pedido.Status != StatusPedido.Pendente && pedido.Status != StatusPedido.Reaberto)
                    {
                        throw new Exception("Só é possível alterar a urgência de pedidos pendentes ou reabertos (" + pedido + ").");
                    }
                    else
                    {
                        pedidos.Add(pedido);
                    }
                }

                CadPedidoItemUrgenteForm form = new CadPedidoItemUrgenteForm(pedidos);
                form.ShowDialog(this);

                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    this.getDataGrid().InvalidateRow(row.Index);
                }



            }
            catch (ExcecaoTratada)
            {
                BufferAbstractEntity.limparBuffer();
                this.ForceInitializeDataGrid();
                throw;
            }
            catch (Exception e)
            {
                BufferAbstractEntity.limparBuffer();
                this.ForceInitializeDataGrid();
                throw new Exception("Erro inesperado ao alterar a urgência.\r\n" + e.Message, e);
            }
        }



        #region Ações GAD
        private void VerificarSituacaoPedidosGad()
        {
            TelaProgressoRunner progressoRunner = null;
            try
            {
                if (getDataGrid().SelectedRowsIwt.Count == 0)
                {

                }


                List<PedidoItemClass> pedidos = new List<PedidoItemClass>();
                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRowsIwt)
                {
                    pedidos.Add((PedidoItemClass) row.DataBoundItem);
                }

                //Lista de DTO para chamada da API do GAD
                List<PedidoSituacaoDto> dtoList = pedidos.Select(a => new PedidoSituacaoDto() { idFornecedor = ConexaoGad.IdFornecedor, numeroPedido = a.Numero, posicaoPedido = a.Posicao }).ToList();

                progressoRunner = new TelaProgressoRunner("Aguarde... Estamos obtendo as situações atualizadas do GAD", null, this);

                //Chamada da API do GAD
                dtoList = PedidoControll.VerificaSituacaoPedidos(dtoList);

                //Atualiza os pedidos
                foreach (PedidoSituacaoDto retorno in dtoList)
                {
                    if (retorno.atualizar)
                    {
                        GadIntegracaoPedidoSituacao novaSituacao;

                        PedidoItemClass pedido = pedidos.FirstOrDefault(a => a.Numero == retorno.numeroPedido && a.Posicao == retorno.posicaoPedido);
                        if (pedido == null)
                        {
                            throw new ExcecaoTratada("Erro inesperado ao verificar os pedidos no gad, pedido não encontrado na base do cliente. " + retorno.numeroPedido + "/" + retorno.posicaoPedido);
                        }

                        if (GadIntegracaoPedidoSituacao.TryParse(retorno.situacaoPedido.ToString(), out novaSituacao))
                        {
                            pedido.SituacaoGad = novaSituacao;
                        }
                        pedido.SituacaoGadMensagem = retorno.situacaoMensagem;
                        pedido.GadProgramacaoNome = retorno.programacaoNome;
                        pedido.GadProgramacaoData = retorno.programacaoDataCriacao;
                        pedido.Save();
                    }
                }
                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRowsIwt)
                {
                    getDataGrid().InvalidateRow(row.Index);
                }

                progressoRunner.Finished();

                MessageBox.Show(this, "Atualização dos pedidos concluída", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ExcecaoTratada a)
            {
                throw a;
            }
            catch (Exception a)
            {
                throw new Exception("Erro inesperado ao verificar a situação dos pedidos que estão no GAD. " + a.Message);
            }
            finally
            {
                if (progressoRunner != null && progressoRunner.Running)
                {
                    progressoRunner.Finished();
                }
            }
        }

        private void CancelarPedidoGad()
        {
            TelaProgressoRunner progressoRunner = null;
            try
            {
                if (getDataGrid().SelectedRowsIwt.Count == 0)
                {
                    throw new ExcecaoTratada("Selecione um pedido para cancelar");
                }

                if (DialogResult.No == MessageBox.Show(this, "Confirma a solicitação de cancelamento dos pedidos no GAD?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }


                progressoRunner = new TelaProgressoRunner("Aguarde... Estamos solicitando o cancelamento do pedido", null, this);

                List<PedidoAcaoDto> pedidos = new List<PedidoAcaoDto>();
                foreach (IWTDataGridViewRow row in getDataGrid().SelectedRowsIwt)
                {
                    pedidos.Add(new PedidoAcaoDto()
                    {
                        idFornecedor = ConexaoGad.IdFornecedor,
                        numero = ((PedidoItemClass)row.DataBoundItem).Numero,
                        posicao = ((PedidoItemClass)row.DataBoundItem).Posicao
                    });
                }


                //Chamada da API do GAD
                pedidos = PedidoControll.CancelarPedidos(pedidos);

                PedidoItemClass pesquisa = new PedidoItemClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                //Atualiza os pedidos
                string mensagem = "";
                int pedidoAtualizados = 0;
                foreach (PedidoAcaoDto acao in pedidos)
                {
                    if (acao.acaoExecutada)
                    {
                        try
                        {
                            PedidoItemClass pedido = (PedidoItemClass)pesquisa.Search(new List<SearchParameterClass>()
                            {
                                new SearchParameterClass("NumeroExato", acao.numero),
                                new SearchParameterClass("Posicao", acao.posicao)
                            }).FirstOrDefault();
                            if (pedido != null)
                            {
                                pedido.SituacaoGad = GadIntegracaoPedidoSituacao.Cancelado;
                                pedido.Save();
                                pedidoAtualizados++;
                            }
                        }
                        catch (Exception e)
                        {
                            mensagem += acao.numero + "/" + acao.posicao + " : Pedido cancelado no GAD. Erro inesperado ao atualizar o pedido no sistema" + e.Message;
                        }
                    }
                    else
                    {
                        mensagem += acao.numero + "/" + acao.posicao + " : " + acao.mensagem + Environment.NewLine;
                    }
                }
                this.ForceInitializeDataGrid();

                progressoRunner.Finished();

                if (string.IsNullOrEmpty(mensagem))
                {
                    string txt = (pedidoAtualizados > 1 ? "Pedidos cancelados" : "Pedido cancelado") + " com sucesso";
                    MessageBox.Show(this, txt, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string txt = "";
                    if (pedidoAtualizados > 0)
                    {
                        txt = pedidoAtualizados + (pedidoAtualizados > 1 ? " pedidos cancelados." : "pedido cancelado.") + Environment.NewLine;
                    }
                    mensagem = txt + "Pedidos não atualizados:" + Environment.NewLine + mensagem;

                    ScrollableMessageBox msgBox = new ScrollableMessageBox(this, mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    msgBox.ShowDialog();
                }
            }
            catch (ExcecaoTratada a)
            {
                throw a;
            }
            catch (Exception a)
            {
                throw new Exception("Erro inesperado ao verificar a situação dos pedidos que estão no GAD. " + a.Message);
            }
            finally
            {
                if (progressoRunner != null && progressoRunner.Running)
                {
                    progressoRunner.Finished();
                }
            }
        }

        #endregion


        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            if (!ConfiguraConexaoGad.GadAtivo)
            {
                
                this.getDataGrid().Columns.Remove(SituacaoGadTraduzidaColumn);
                this.getDataGrid().Columns.Remove(SituacaoGadMensagemColumn);
                this.getDataGrid().Columns.Remove(ProgramacaoDataCriacaoColumn);
                this.getDataGrid().Columns.Remove(ProgramacaoNomeColumn);
                this.getDataGrid().Columns.Remove(ProgramacaoSituacaoGadColumn);
                this.getDataGrid().Columns.Remove(ProgramacaoSituacaoGadMensagemColumn);

                btnAtualizarGad.Visible = false;
                btnCancelarGad.Visible = false;

            }
            else
            {
                btnAtualizarGad.Visible = true;
                btnCancelarGad.Visible = true;
            }


            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                this.getDataGrid().Columns.Remove(Operacao);
            }
            else
            {
                this.getDataGrid().Columns.Remove(OperacaoCompletaColumn);
            }


            if (Tipo == TipoForm.PCP && !LoginClass.UsuarioLogado.HasAccess("MODULO_PCP_PEDIDOS_VALORES", AcsTipoAcesso.Escrita))
            {
                this.getDataGrid().Columns.Remove(PrecoUnitario);
                this.getDataGrid().Columns.Remove(PrecoTotal);
                this.getDataGrid().Columns.Remove(PrecoTotalOriginal);
                this.getDataGrid().Columns.Remove(Frete);

            }


            if (!IWTConfiguration.Conf.getBoolConf(Constants.FEEDBACK_SECUNDARIO_HABILITADO))
            {
                this.getDataGrid().Columns.Remove(FeedbackSecundarioColumn);
                FeedbackSecundarioColumn.Visible = false;
                this.btnFeedbackSecundario.Visible = false;
                this.btnFeedbackSecundario.forceDisable();

                grbPlanejamento.Visible = false;

            }
           

            base.OnShown(e);
            this.rdbPendentes.Checked = true;
            rdbUrgenteTodos.Checked = true;
            rdbConfiguradoTodos.Checked = true;
            rdbFeedbackSecundarioTodos.Checked = true;
            rdbFeedbackTodos.Checked = true;

            if (!IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.FATURAMENTO_DIRETO_HABILITADO))
            {
                this.btnFaturar.forceDisable();
            }

            if (!IWTConfiguration.Conf.getBoolConf(Constants.TRABALHAR_COM_BLOQUEIO_PRODUTO_POR_PRECO_VENCIDO))
            {
                this.getDataGrid().Columns.Remove(ProdutoBloqueioPrecoVencidoColumn);
            }
        }

        private void btnSuspender_Click(object sender, EventArgs e)
        {

            try
            {
                this.Suspender();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Encerrar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cancelar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFaturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LoginClass.UsuarioLogado.HasAccess("MODULO_PCP_PEDIDOS_VALORES", AcsTipoAcesso.Escrita))
                {
                    throw new ExcecaoTratada("Desculpe não é possível utilizar essa funcionalidade pois o seu usuário não possui acesso aos valores dos pedidos");
                }

                this.FaturarPedido();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRelatorioMateriais_Click(object sender, EventArgs e)
        {
            try
            {
                this.relatorioMateriais();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LoginClass.UsuarioLogado.HasAccess("MODULO_PCP_PEDIDOS_VALORES", AcsTipoAcesso.Escrita))
                {
                    throw new ExcecaoTratada("Desculpe não é possível utilizar essa funcionalidade pois o seu usuário não possui acesso aos valores dos pedidos");
                }

                imprimirPedidos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iwtDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.GerenciarBotaoSuspensao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {

                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    string toClipboard = "";


                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        PedidoItemClass pedido = (PedidoItemClass) row.DataBoundItem;
                        toClipboard += pedido.Numero + "/" + pedido.Posicao + "\r\n";
                    }


                    Clipboard.SetDataObject(toClipboard);
                }
            }
        }


        private void btnFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoFeedback(false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAlterarUrgencia_Click(object sender, EventArgs e)
        {
            try
            {
                this.AlterarUrgencia();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkDataEntrada_CheckedChanged(object sender, EventArgs e)
        {
            this.grbDataEntrada.Enabled = chkDataEntrada.Checked;
        }

        private void chkDataEntrega_CheckedChanged(object sender, EventArgs e)
        {
            this.grbDataEntrega.Enabled = chkDataEntrega.Checked;
        }


        private void btnAtualizarGad_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarSituacaoPedidosGad();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarGad_Click(object sender, EventArgs e)
        {
            try
            {
                CancelarPedidoGad();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


  
        private void btnEditarSimplificado_Click(object sender, EventArgs e)
        {
            try
            {
                if (iwtDataGridView1.SelectedRowsIwt.Count != 1)
                {
                    throw new ExcecaoTratada("Selecione uma linha, e somente uma, para editar");
                }

                CadPedidoSimplificadoForm form = new CadPedidoSimplificadoForm((PedidoItemClass) iwtDataGridView1.SelectedRowsIwt.First().DataBoundItem, SingleConnection, getUsuarioAtual(), Tipo);
                form.ShowDialog(this);
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
                ForceInitializeDataGrid();
            }
        }

        private void btnFeedbackSecundario_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoFeedback(true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void iwtDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == NumeroPosicao.Index)
            {
                PedidoItemClass pedidoItem = (PedidoItemClass)((IWTDataGridViewRow)iwtDataGridView1.Rows[e.RowIndex]).DataBoundItem;

                if (pedidoItem.possuiProdutoVencido())
                {
                    foreach (DataGridViewCell cell in iwtDataGridView1.Rows[e.RowIndex].Cells)
                    {
                        cell.Style.BackColor = Color.Orange;
                    }
                }
            }
        }

        #endregion

    }
}
    