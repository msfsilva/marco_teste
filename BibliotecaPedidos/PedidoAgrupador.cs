using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using Configurations;
using CrystalDecisions.Shared;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaPedidos
{
    public class PedidoAgrupador
    {
        private readonly AcsUsuarioClass _usuario;
        private readonly IWTPostgreNpgsqlConnection _conn;
        public List<PedidoItemClass> Pedidos;
        public List<OrcamentoItemClass> Orcamentos;
        public RepresentanteClass Representante { get; private set; }
        public VendedorClass Vendedor { get; private set; }
        public PedidoOrcamento TipoEntidade { get; private set; }
        public ClienteClass Cliente { get; private set; }
        public string Numero { get; private set; }

        private bool maisUmaPosicao = false;

        public PedidoAgrupador(PedidoOrcamento tipoEntidade, string numeroPedido, ClienteClass cliente, RepresentanteClass representante, VendedorClass vendedor, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            _usuario = usuario;
            _conn = conn;
            Numero = numeroPedido;
            Cliente = cliente;
            Representante = representante;
            Vendedor = vendedor;
            TipoEntidade = tipoEntidade;
            this.Pedidos = new List<PedidoItemClass>();
            this.Orcamentos = new List<OrcamentoItemClass>();
        }

        public void AdicionarPedido(PedidoItemClass pedido)
        {
            if (TipoEntidade != PedidoOrcamento.Pedido)
            {
                throw new Exception("O agrupador não é de pedidos");
            }

            if (pedido.Cliente == Cliente && pedido.Numero == this.Numero && ((pedido.Representante == this.Representante && pedido.Vendedor == this.Vendedor)|| pedido.SubLinha!=0))
            {
                if (!maisUmaPosicao && Pedidos.Count > 0)
                {
                    if (Pedidos.Any(a=>a.Posicao!=pedido.Posicao))
                    {
                        maisUmaPosicao = true;
                    }
                }
                this.Pedidos.Add(pedido);

                foreach (PedidoItemClass sublinha in pedido.CollectionPedidoItemClassPedidoItemPai)
                {
                    this.AdicionarPedido(sublinha);
                }
            }
            else
            {
                throw new Exception("O pedido não pertence ao agrupador indicado.");
            }
        }

        public void AdicionarOrcamento(OrcamentoItemClass orcamento)
        {

            if (TipoEntidade != PedidoOrcamento.Pedido)
            {
                throw new Exception("O agrupador não é de orçamentos");
            }

            if (orcamento.Cliente == Cliente && orcamento.Numero == this.Numero && ((orcamento.Representante == this.Representante && orcamento.Vendedor == this.Vendedor) || orcamento.SubLinha != 0))
            {
                if (!maisUmaPosicao && Orcamentos.Count > 0)
                {
                    if (Orcamentos.Any(a => a.Posicao != orcamento.Posicao))
                    {
                        maisUmaPosicao = true;
                    }
                }
                this.Orcamentos.Add(orcamento);
            }
            else
            {
                throw new Exception("O orçamento não pertence ao agrupador indicado.");
            }
        }

        public void EnviarEmail()
        {


            try
            {

                bool EnviarDestInterno;
                if (this.TipoEntidade == PedidoOrcamento.Pedido)
                {
                    EnviarDestInterno = IWTConfiguration.Conf.getBoolConf(Constants.ENVIO_EMAIL_DESTINATARIO_INTERNO_PEDIDO);
                }
                else
                {
                    EnviarDestInterno = IWTConfiguration.Conf.getBoolConf(Constants.ENVIO_EMAIL_DESTINATARIO_INTERNO_ORCAMENTO);
                }


                bool EnviarEmailRepresentante = this.Representante != null && this.Representante.EnvioEmail;
                bool EnviarEmailVendedor = this.Vendedor != null && this.Vendedor.EnvioEmail;

                if (Cliente.EnvioEmail || EnviarDestInterno || EnviarEmailRepresentante || EnviarEmailVendedor)
                {


                    List<PedidoEspelhoClass> dados = PedidoEspelhoClass.GerarRelatorio(this);

                    PedidoEspelhoReport report = new PedidoEspelhoReport();
                    report.SetDataSource(dados);


                    string remetente = IWTConfiguration.Conf.getConf(Constants.PEDIDO_EMAIL_REMETENTE);
                    Stream anexo = report.ExportToStream(ExportFormatType.PortableDocFormat);

                    EnviaEmailPedidoEspelhoClass enviaEmail = new EnviaEmailPedidoEspelhoClass(_usuario, _conn);




                    string posicao = maisUmaPosicao ? "" : Pedidos[0].Posicao.ToString(CultureInfo.InvariantCulture);

                    enviaEmail.setPedidoOrcamento(this.Numero,
                                                  posicao,
                                                  anexo,
                                                  this.TipoEntidade, new List<Stream>(),
                                                  new List<string>());
                    if (Cliente.EnvioEmail)
                    {

                        DialogResult confirm = MessageBox.Show(null,
                                                               "O cliente está configurado para receber e-mail de pedidos/orçamentos gerados no EASI. Deseja enviar?",
                                                               "Confirmação de Envio",
                                                               MessageBoxButtons.YesNo,
                                                               MessageBoxIcon.Question);
                        if (confirm == DialogResult.Yes)
                        {
                            enviaEmail.Enviar(Cliente.EmailPedido, remetente, enviaEmail.getCorpoEmail());
                        }
                    }

                    if (EnviarDestInterno)
                    {
                        string destinatarioInterno;
                        if (this.TipoEntidade == PedidoOrcamento.Pedido)
                        {
                            destinatarioInterno = IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_INTERNO_PEDIDO);
                        }
                        else
                        {
                            destinatarioInterno = IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_INTERNO_ORCAMENTO);
                        }

                        anexo.Position = 0;
                        enviaEmail.Enviar(destinatarioInterno, remetente, enviaEmail.getCorpoEmail());
                    }

                    if (this.Representante != null)
                    {
                        if (this.Representante.EnvioEmail)
                        {
                            anexo.Position = 0;
                            enviaEmail.Enviar(this.Representante.Email, remetente, enviaEmail.getCorpoEmail());
                        }
                    }

                    if (this.Vendedor != null)
                    {
                        if (this.Vendedor.EnvioEmail)
                        {
                            anexo.Position = 0;
                            enviaEmail.Enviar(this.Vendedor.Email, remetente, enviaEmail.getCorpoEmail());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "Erro ao enviar por e-mail. Pedido/Orçamento será salvo normalmente.\r\n" + e.Message,
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}