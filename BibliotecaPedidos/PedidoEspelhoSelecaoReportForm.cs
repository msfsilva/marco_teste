using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using CrystalDecisions.Shared;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using ProjectConstants;
using dbProvider;

namespace BibliotecaPedidos
{
    public partial class PedidoEspelhoSelecaoReportForm : IWTBaseForm
    {

        private PedidoOrcamento tipoRelatorio;
        private bool enviadoDestinatarioInterno = false;

        public PedidoEspelhoSelecaoReportForm(PedidoOrcamento tipoRelatorio)
        {
            InitializeComponent();
            loadClientes();
            this.tipoRelatorio = tipoRelatorio;
            if(tipoRelatorio == PedidoOrcamento.Orcamento)
            {
                this.Text = "Impressão de Orçamento";
            }
        }

        public PedidoEspelhoSelecaoReportForm()
        {
            InitializeComponent();
            loadClientes();
            this.tipoRelatorio = PedidoOrcamento.Pedido;
        }

        private void loadClientes()
        {
            try
            {
                string sql =
                   "SELECT " +
                   "  public.cliente.id_cliente, " +
                   "  public.cliente.cli_nome_resumido, " +
                   "  public.cliente.cli_nome " +
                   "FROM " +
                   "  public.cliente " +
                   "ORDER BY " +
                   "  cli_nome_resumido, " +
                   "  public.cliente.cli_nome ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbCliente.DataSource = binding;
                    this.cmbCliente.ValueMember = "id_cliente";
                    this.cmbCliente.DisplayMember = "cli_nome_resumido";
                    this.cmbCliente.autoSize = true;
                    this.cmbCliente.Table = ds.Tables[0];
                    this.cmbCliente.ColumnsToDisplay = new string[] { "cli_nome_resumido", "cli_nome" };
                    this.cmbCliente.HeadersToDisplay = new string[] { "Nome Resumido", "Razão" };
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados do cliente.\r\n" + a.Message, "Dados do Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void imprimirPedidos()
        {
            try
            {
                if (cmbCliente.SelectedRow != null)
                {
                    List<PedidoEspelhoParametrosBuscaClass> parametrosBusca = new List<PedidoEspelhoParametrosBuscaClass>();
                    PedidoEspelhoParametrosBuscaClass parametros = new PedidoEspelhoParametrosBuscaClass
                    {
                        idCliente = int.Parse(cmbCliente.SelectedValue.ToString()),
                        numero = txtNumeroPedido.Text != "" ? txtNumeroPedido.Text : null,
                        posicao = null
                    };
                    parametrosBusca.Add(parametros);

                    if(chkEnvioEmail.Enabled)
                    {
                        if(chkEnvioEmail.Checked)
                            enviarPorEmail();
                    }

                    if (chkEnviarEmailRepresentante.Checked)
                        enviarPorEmailRepresentante();

                    PedidoEspelhoReportForm form = new PedidoEspelhoReportForm(parametrosBusca, this.tipoRelatorio);
                    form.ShowDialog();
                

                }
                else
                {
                    MessageBox.Show(this, "Selecione um cliente para imprimir os pedidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void enviarPorEmail()
        {
           
                try
                {
                    IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

                    ClienteClass cliente = ClienteBaseClass.GetEntidade(int.Parse(cmbCliente.SelectedValue.ToString()),
                                                            LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    if (cliente.EnvioEmail)
                    {
                        List<PedidoEspelhoParametrosBuscaClass> parametros =
                            new List<PedidoEspelhoParametrosBuscaClass>();
                        string numPedido = txtNumeroPedido.Text != "" ? txtNumeroPedido.Text : null;
                        parametros.Add(new PedidoEspelhoParametrosBuscaClass(   cliente.ID, 
                                                                                numPedido , 
                                                                                null));

                        List<PedidoEspelhoClass> dados = PedidoEspelhoClass.gerar(parametros,
                                                                                  this.tipoRelatorio, true, ref command);
                        PedidoEspelhoReport report = new PedidoEspelhoReport();
                        report.SetDataSource(dados);


                        string remetente = IWTConfiguration.Conf.getConf(Constants.PEDIDO_EMAIL_REMETENTE);

                        EnviaEmailPedidoEspelhoClass enviaEmail = new EnviaEmailPedidoEspelhoClass(LoginClass.UsuarioLogado.loggedUser, command.Connection);

                        if(dados.ToArray().Length > 1)
                        {
                            numPedido = "Varios";
                        }
                        else
                        {
                            if (dados.ToArray()[0] != null)
                                numPedido = dados.ToArray()[0].numero;
                        }
                        enviaEmail.setPedidoOrcamento(  numPedido,
                                                        null,
                                                        report.ExportToStream(ExportFormatType.PortableDocFormat),
                                                        this.tipoRelatorio, 
                                                        new List<Stream>(),
                                                        new List<string>());

                        enviaEmail.Enviar(cliente.EmailPedido, remetente, enviaEmail.getCorpoEmail());
                        enviarPorEmailDestinatario();
                        enviadoDestinatarioInterno = true;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao enviar o pedido por e-mail ao cliente.\r\n" + e.Message, e);
                }
        }

        private void enviarPorEmailDestinatario()
        {

            try
            {
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

                ClienteClass cliente = ClienteBaseClass.GetEntidade(int.Parse(cmbCliente.SelectedValue.ToString()),
                                                        LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
              
                    List<PedidoEspelhoParametrosBuscaClass> parametros =
                        new List<PedidoEspelhoParametrosBuscaClass>();
                    string numPedido = txtNumeroPedido.Text != "" ? txtNumeroPedido.Text : null;
                    parametros.Add(new PedidoEspelhoParametrosBuscaClass(cliente.ID,
                                                                            numPedido,
                                                                            null));

                    List<PedidoEspelhoClass> dados = PedidoEspelhoClass.gerar(parametros, this.tipoRelatorio,true, ref command);
                    PedidoEspelhoReport report = new PedidoEspelhoReport();
                    report.SetDataSource(dados);

                    
                    string remetente = IWTConfiguration.Conf.getConf(Constants.PEDIDO_EMAIL_REMETENTE);

                    bool enviarDestinatarioInterno = IWTConfiguration.Conf.getBoolConf(Constants.ENVIO_EMAIL_DESTINATARIO_INTERNO_PEDIDO);
                    string emailDestinatarioIntenro = IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_INTERNO_PEDIDO);

                    EnviaEmailPedidoEspelhoClass enviaEmail = new EnviaEmailPedidoEspelhoClass(LoginClass.UsuarioLogado.loggedUser,command.Connection);

                    if (dados.ToArray().Length > 1)
                    {
                        numPedido = "Varios";
                    }
                    else
                    {
                        if (dados.ToArray()[0] != null)
                            numPedido = dados.ToArray()[0].numero;
                    }
                    enviaEmail.setPedidoOrcamento(numPedido,
                                                    null,
                                                    report.ExportToStream(ExportFormatType.PortableDocFormat),
                                                    this.tipoRelatorio,
                                                    new List<Stream>(),
                                                    new List<string>());

                    
                    if (enviarDestinatarioInterno)
                    {
                        enviaEmail.Enviar(emailDestinatarioIntenro, remetente, enviaEmail.getCorpoEmail());

                    }
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar o pedido por e-mail ao destinatário interno de pedidos.\r\n" + e.Message, e);
            }
        }

        private void enviarPorEmailRepresentante()
        {

            try
            {
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

                ClienteClass cliente = ClienteBaseClass.GetEntidade(int.Parse(cmbCliente.SelectedValue.ToString()), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                List<PedidoEspelhoParametrosBuscaClass> parametros = new List<PedidoEspelhoParametrosBuscaClass>();
                string numPedido = txtNumeroPedido.Text != "" ? txtNumeroPedido.Text : null;
                parametros.Add(new PedidoEspelhoParametrosBuscaClass(cliente.ID, numPedido,null));

                List<PedidoEspelhoClass> dados = PedidoEspelhoClass.gerar(parametros, this.tipoRelatorio, true, ref command);
                dados =
                    new List<PedidoEspelhoClass>(
                        dados.Where(a => a.representanteEnvioEmail && !string.IsNullOrWhiteSpace(a.representanteEmail)).OrderBy(a => a.representanteEmail));

                if (dados.Count == 0) return;

                
                string remetente = IWTConfiguration.Conf.getConf(Constants.PEDIDO_EMAIL_REMETENTE);

                EnviaEmailPedidoEspelhoClass enviaEmail = new EnviaEmailPedidoEspelhoClass(LoginClass.UsuarioLogado.loggedUser,command.Connection);

                string repAtual = dados[0].representanteEmail;

                List<PedidoEspelhoClass> toSend = new List<PedidoEspelhoClass>();
                foreach (PedidoEspelhoClass t in dados)
                {
                    if (t.representanteEmail == repAtual)
                    {
                        toSend.Add(t);
                    }
                    else
                    {
                        //Envia o email com os pedidos da toSend
                        PedidoEspelhoReport report = new PedidoEspelhoReport();
                        report.SetDataSource(toSend);

                        if (toSend.ToArray().Length > 1)
                        {
                            numPedido = "Varios";
                        }
                        else
                        {
                            if (toSend.ToArray()[0] != null)
                                numPedido = toSend.ToArray()[0].numero;
                        }
                        enviaEmail.setPedidoOrcamento(numPedido,
                                                        null,
                                                        report.ExportToStream(ExportFormatType.PortableDocFormat),
                                                        this.tipoRelatorio,
                                                        new List<Stream>(),
                                                        new List<string>());

                        enviaEmail.Enviar(repAtual, remetente, enviaEmail.getCorpoEmail());


                        repAtual = t.representanteEmail;
                        toSend = new List<PedidoEspelhoClass>(){t};
                    }
                }

                if (toSend.Count>0)
                {
                    //Envia o email pro ultimo representante
                    PedidoEspelhoReport report = new PedidoEspelhoReport();
                    report.SetDataSource(toSend);

                    if (toSend.ToArray().Length > 1)
                    {
                        numPedido = "Varios";
                    }
                    else
                    {
                        if (toSend.ToArray()[0] != null)
                            numPedido = toSend.ToArray()[0].numero;
                    }
                    enviaEmail.setPedidoOrcamento(numPedido,
                                                    null,
                                                    report.ExportToStream(ExportFormatType.PortableDocFormat),
                                                    this.tipoRelatorio,
                                                    new List<Stream>(),
                                                    new List<string>());

                    enviaEmail.Enviar(toSend.ToArray()[0].representanteEmail, remetente, enviaEmail.getCorpoEmail());
                }
                if(!enviadoDestinatarioInterno)
                {
                    enviarPorEmailDestinatario();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar o pedido por e-mail ao representante.\r\n" + e.Message, e);
            }
        }

        #region Eventos


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                imprimirPedidos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedRow != null)
            {
                ClienteClass cliente = ClienteBaseClass.GetEntidade(int.Parse(cmbCliente.SelectedValue.ToString()), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                chkEnvioEmail.Enabled = cliente.EnvioEmail;
            }

        }
    }
}
