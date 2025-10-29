using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;
using OpReportForm = BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao.OpReportForm;
using OrdemProducaoAntigaClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoClass;
using OrdemProducaoClass = BibliotecaEntidades.Entidades.OrdemProducaoClass;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadOrdemProducaoListForm : IWTListForm
    {
        private readonly IOrdemProducaoFactory _factory;
        private ICarregarDocumentosImpressaoOp _carregarDocumentosImpressaoOp;

        public CadOrdemProducaoListForm(IOrdemProducaoFactory factory, ICarregarDocumentosImpressaoOp carregarDocumentosImpressaoOp = null)
        {
            _factory = factory;
            _carregarDocumentosImpressaoOp = carregarDocumentosImpressaoOp;
            InitializeComponent();

          
        }

        #region ListForm

        public override Type getTipoEntidade()
        {
            return typeof (BibliotecaEntidades.Entidades.OrdemProducaoClass);
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
            return new List<SearchParameterClass>() {new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)};
        }

        #endregion

        private void Gerar()
        {

            try
            {
                GerarOPForm form = new GerarOPForm(LoginClass.UsuarioLogado.loggedUser,this.SingleConnection,this._factory, _carregarDocumentosImpressaoOp);
                form.ShowDialog();
                this.ForceInitializeDataGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar op.\r\n" + e.Message);
            }
        }

        private void Reimprimir()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    command = this.SingleConnection.CreateCommand();
                    command.Transaction = this.SingleConnection.BeginTransaction();


                    List<OrdemProducaoAntigaClass> lst = new List<OrdemProducaoAntigaClass>();

                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        OrdemProducaoClass opNova = (OrdemProducaoClass) row.DataBoundItem;

                        
                        if (opNova.DataImpressao.HasValue)
                        {
                            
                            OrdemProducaoAntigaClass Op = this._factory.getInstanceOp(opNova.ID, null, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                            if (Op.Situacao == 2 || Op.Situacao == 3)
                            {
                                throw new Exception(
                                    "Não é possível imprimir uma OP encerrada ou cancelada, utilize a visualização.");
                            }

                            lst.Add(Op);

                            Op.setReimpressao(LoginClass.UsuarioLogado.loggedUser);

                            Op.Save(ref command);
                            BufferAbstractEntity.invalidarEntidade(opNova.GetType(),opNova.ID);
                        }
                        else
                        {
                            throw new Exception("Não é possível reimprimir uma OP que não foi impressa.");
                        }
                    }

                    OpReportForm form = new OpReportForm(lst,true,  LoginClass.UsuarioLogado.loggedUser, this.SingleConnection, _carregarDocumentosImpressaoOp);
                    if (!form.IsDisposed)
                    {
                        form.Show();
                    }

                    command.Transaction.Commit();


                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao reimprimir as OPs.\r\n" + e.Message);
            }
            finally
            {
                this.ForceInitializeDataGrid();
            }

        }

        private void Visualizar()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    List<OrdemProducaoAntigaClass> lst = new List<OrdemProducaoAntigaClass>();

                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        OrdemProducaoClass opNova = (OrdemProducaoClass)row.DataBoundItem;

                        OrdemProducaoAntigaClass Op = this._factory.getInstanceOp(opNova.ID, null, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                        lst.Add(Op);

                    }

                    OpReportForm form = new OpReportForm(lst,false,   LoginClass.UsuarioLogado.loggedUser, this.SingleConnection, _carregarDocumentosImpressaoOp);
                    if (!form.IsDisposed)
                    {
                        form.Show();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao visualizar as OPs.\r\n" + e.Message);
            }
            finally
            {
                this.ForceInitializeDataGrid();
            }
        }

        private void Imprimir()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    command = this.SingleConnection.CreateCommand();
                    command.Transaction = this.SingleConnection.BeginTransaction();



                    List<OrdemProducaoAntigaClass> lst = new List<OrdemProducaoAntigaClass>();
                    List<string> recursosImprimir = new List<string>();

                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        OrdemProducaoClass opNova = (OrdemProducaoClass)row.DataBoundItem;


                        if (!opNova.DataImpressao.HasValue)
                        {
                            OrdemProducaoAntigaClass Op = this._factory.getInstanceOp(opNova.ID, null, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                            if (Op.Situacao == 2 || Op.Situacao == 3)
                            {
                                throw new Exception(
                                    "Não é possível imprimir uma OP encerrada ou cancelada, utilize a visualização.");
                            }
                            lst.Add(Op);

                            Op.setImpressao(LoginClass.UsuarioLogado.loggedUser);

                            Op.Save(ref command);

                            BufferAbstractEntity.invalidarEntidade(opNova.GetType(), opNova.ID);
                            recursosImprimir.AddRange(
                                Op.Recursos.Where(a => a.recursoTipo == TipoRecurso.Formulario).Select(
                                    recurso => recurso.recursoCaminhoArquivo));
                        }
                        else
                        {
                            throw new Exception(
                                "Não é possível imprimir uma OP já impressa, utilize a visualização ou a reimpressão.");
                        }
                    }

                    OpReportForm form = new OpReportForm(lst, true,
                                                         LoginClass.UsuarioLogado.loggedUser,
                                                         this.SingleConnection, _carregarDocumentosImpressaoOp);
                    if (!form.IsDisposed)
                    {
                        form.ShowDialog();
                    }



                    if (recursosImprimir.Count > 0)
                    {
                        MessageBox.Show(this,
                                        "As ordens de produção que foram impressas possuem formulários para imprimir, esses arquivos serão abertos agora um a um, imprima e feche o arquivo para abrir o próximo.",
                                        "Formulários", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process pr = new Process();
                        foreach (string rec in recursosImprimir)
                        {
                            pr.StartInfo.FileName = rec;
                            pr.Start();
                            pr.WaitForExit();
                        }
                    }

                    command.Transaction.Commit();


                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao imprimir as OPs.\r\n" + e.Message);
            }
            finally
            {
                this.ForceInitializeDataGrid();
            }
        }

        private void Cancelar()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Deseja Cancelar as Ordens de Produção Selecionadas?", "Cancelamento de OP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                        {
                            OrdemProducaoClass opNova = (OrdemProducaoClass)row.DataBoundItem;

                            OrdemProducaoAntigaClass Op = this._factory.getInstanceOp(opNova.ID, null, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                            Op.Cancelar();
                            BufferAbstractEntity.invalidarEntidade(opNova.GetType(), opNova.ID);
                        }

                        MessageBox.Show(this, "OPs Canceladas com sucesso.", "Cancelamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.ForceInitializeDataGrid();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cancelar as OPs.\r\n" + e.Message);
            }
        }

        private void Encerrar()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Deseja Encerrar as Ordens de Produção Selecionadas?", "Encerrar de OP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                        {
                            OrdemProducaoClass opNova = (OrdemProducaoClass)row.DataBoundItem;

                            OrdemProducaoAntigaClass Op = this._factory.getInstanceOp(opNova.ID, null, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                            if (Op.Pendencia && !Op.Suspensa)
                            {
                                string ret = Op.resolverPendencia(LoginClass.UsuarioLogado.loggedUser);
                                if (ret.Length > 0)
                                {
                                    MessageBox.Show(this, ret, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            if (opNova.Situacao == StatusOrdemProducao.AguardandoServicoExterno)
                            {
                                throw new ExcecaoTratada("A ordem de produção "+opNova+" está em situação de \"Aguardando Serviço Externo\" e por isso não pode ser encerrada." );
                            }

                            if (Op.Suspensa)
                            {
                                switch (MessageBox.Show(this, "Essa ordem de produção está suspensa, você deseja encerra-la agora?", "OP Suspensa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                                {
                                    case DialogResult.No:
                                    case DialogResult.Cancel:
                                        return;
                                        break;
                                    case DialogResult.Yes:
                                        Op.retirarSuspensao(LoginClass.UsuarioLogado.loggedUser);

                                        break;


                                }
                            }
                            Op.Encerrar(LoginClass.UsuarioLogado.loggedUser, true, true);
                            BufferAbstractEntity.invalidarEntidade(opNova.GetType(), opNova.ID);
                        }
                        this.ForceInitializeDataGrid();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao encerrar as OPs.\r\n" + e.Message);
            }
        }

        private void ResolverPendencia()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        OrdemProducaoClass opNova = (OrdemProducaoClass)row.DataBoundItem;

                        OrdemProducaoAntigaClass Op = this._factory.getInstanceOp(opNova.ID, null, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                        if (Op.Pendencia)
                        {
                            string ret = Op.resolverPendencia(LoginClass.UsuarioLogado.loggedUser);
                            if (ret.Length > 0)
                            {
                                MessageBox.Show(this, ret, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        Op.Save();
                        BufferAbstractEntity.invalidarEntidade(opNova.GetType(), opNova.ID);
                    }

                    this.ForceInitializeDataGrid();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao resolver as pendencias das OPs.\r\n" + e.Message);
            }
        }

        private void RetirarSuspensao()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {
                        OrdemProducaoClass opNova = (OrdemProducaoClass)row.DataBoundItem;

                        OrdemProducaoAntigaClass Op = this._factory.getInstanceOp(opNova.ID, null, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                        if (Op.Suspensa)
                        {
                            Op.retirarSuspensao(LoginClass.UsuarioLogado.loggedUser);
                        }
                        Op.Save();
                        BufferAbstractEntity.invalidarEntidade(opNova.GetType(), opNova.ID);
                    }

                    this.ForceInitializeDataGrid();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao retirar a suspensão das OPs.\r\n" + e.Message);
            }
        }

        private void GerarAvulsas()
        {
            try
            {
                GerarOpAvulsaForm form = new GerarOpAvulsaForm(
                  
                    LoginClass.UsuarioLogado.loggedUser,
                    this.SingleConnection,
                    this._factory, _carregarDocumentosImpressaoOp);
                form.ShowDialog();
                this.ForceInitializeDataGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar op avulsa.\r\n" + e.Message);
            }
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                this.rdbNova.Checked = true;
                this.iwtTextBox1.Focus();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Gerar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Reimprimir();
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


        private void btnRetirarSuspensao_Click(object sender, EventArgs e)
        {
            try
            {
                this.RetirarSuspensao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResolverPendencia_Click(object sender, EventArgs e)
        {
            try
            {
                this.ResolverPendencia();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visualizar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Imprimir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnGerarAvulsas_Click(object sender, EventArgs e)
        {
            try
            {
                this.GerarAvulsas();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dhkBuscaDataImpressao_CheckedChanged(object sender, EventArgs e)
        {
            grbBuscaDataImpressao.Enabled = chkBuscaDataImpressao.Checked;
        }



        #endregion

    }
}
