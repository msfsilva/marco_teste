#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaExpedicao
{
    public partial class EtiquetaExpedicaoReimprimirForm : IWTBaseForm
    {
        protected string ImpressoraEtiquetaExpedicao { get; private set; }
        protected string EtiquetaExpedicao { get; private set; }
        protected AcsUsuarioClass Usuario { get; private set; }


        protected string Fornecedor { get; private set; }
        protected byte[] FornecedorLogo { get; private set; }

        protected TipoEtiquetaExpedicao TipoEtiqueta { get; private set; }

        public EtiquetaExpedicaoReimprimirForm()
        {
            InitializeComponent();

            this.ImpressoraEtiquetaExpedicao = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PRINTER);
            this.EtiquetaExpedicao = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PAPER);
            this.Usuario = LoginClass.UsuarioLogado.loggedUser;
            
            this.Fornecedor =  IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_RAZAO);
            this.FornecedorLogo = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

            this.TipoEtiqueta = (TipoEtiquetaExpedicao)Enum.ToObject(typeof(TipoEtiquetaExpedicao), Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_EXPEDICAO)));

            this.ensCliente.FormSelecao = new CadClienteListForm(TipoModulo.Tipo);
            this.ensClienteMultiplos.FormSelecao = new CadClienteListForm(TipoModulo.Tipo);
        }


        private void Imprimir()
        {
            try
            {
                EtiquetaExpedicaoReimprimirSelecaoVolumeForm form = null;

                if (rdbMultipla.Checked)
                {
                    if (ensClienteMultiplos.EntidadeSelecionada == null)
                    {
                        throw new ExcecaoTratada("Selecione um cliente antes de continuar.");
                    }

                    string[] ocs = this.txtPedidos.Text.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                    if (ocs.Length == 0)
                    {
                        throw new ExcecaoTratada("Informe ao menos um pedido antes de continuar.");
                    }

                    List<SelecaoVolumeEtiquetaEx> pedidos = new List<SelecaoVolumeEtiquetaEx>();
                    foreach (string oc in ocs)
                    {
                        try
                        {
                            string[] ocPos = oc.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                            if (ocPos.Length != 2)
                            {
                                throw new ExcecaoTratada("Pedido em formato incorreto (" + oc + ") o pedido deve ser informado sempre no formato numero/posicao");
                            }

                            pedidos.Add(new SelecaoVolumeEtiquetaEx(ocPos[0], int.Parse(ocPos[1]), ((ClienteClass) ensClienteMultiplos.EntidadeSelecionada).ID));
                        }


                        catch (ExcecaoTratada a)
                        {
                            MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        catch (Exception a)
                        {
                            MessageBox.Show(this, "Erro inesperado ao imprimir a etiqueta para o pedido " + oc + "\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }

                    form = new EtiquetaExpedicaoReimprimirSelecaoVolumeForm(pedidos);
                    form.ShowDialog();

                }

                else
                {
                    if (rdbUnitaria.Checked)
                    {
                        if (ensCliente.EntidadeSelecionada == null)
                        {
                            throw new ExcecaoTratada("Selecione um cliente antes de continuar.");
                        }


                        if (string.IsNullOrWhiteSpace(this.txtOc.Text))
                        {
                            throw new ExcecaoTratada("Informe o pedido para imprimir as etiquetas.");
                        }



                        form = new EtiquetaExpedicaoReimprimirSelecaoVolumeForm(new List<SelecaoVolumeEtiquetaEx>()
                        {
                            new SelecaoVolumeEtiquetaEx(this.txtOc.Text.Trim(), (int) this.nudPosicao.Value, ensCliente.EntidadeSelecionada.ID)
                        });
                        form.ShowDialog(this);
                    }
                }

                if (form != null)
                {
                    List<SelecaoVolumeEtiquetaEx> volumesImprimir = form.Volumes.Where(a => a.Selecionado).ToList();
                    if (volumesImprimir.Count > 0)
                    {
                        this.PrintEtiqueta(volumesImprimir);
                        MessageBox.Show(this, "Etiquetas Impressas", "Impressão de Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                  
                }

               

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao definir os parâmetros para a reimpressão da etiqueta.\r\n" + e.Message, e);
            }
        }

        protected virtual void PrintEtiqueta(List<SelecaoVolumeEtiquetaEx> volumesImprimir)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();

                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                    "  public.order_item_etiqueta.oie_qtd_etiqueta_exp_volume, " +
                    "  public.order_item_etiqueta.oie_volumes, " +
                    "  public.order_item_etiqueta.oie_peso, " +
                    "  public.order_item_etiqueta.oie_saldo, " +
                    "  public.order_item_etiqueta.oie_codigo_cliente, " +
                    "  public.order_item_etiqueta.oie_ovm, " +
                    "  public.order_item_etiqueta.oie_descricao_cliente, " +
                    "  public.order_item_etiqueta.oie_altura, " +
                    "  public.order_item_etiqueta.oie_largura, " +
                    "  public.order_item_etiqueta.oie_comprimento, " +
                    "  public.order_item_etiqueta.oie_armazenagem_cliente, " +
                    "  public.order_item_etiqueta.oie_deps, " +
                    "  public.order_item_etiqueta.oie_peps, " +
                    "  public.cliente.cli_nome, " +
                    "  public.cliente.cli_endereco_cob, " +
                    "  public.cliente.cli_bairro_cob, " +
                    "  public.cliente.cli_cep_cob, " +
                    "  public.cliente.cli_endereco_numero_cob, " +
                    "  public.cliente.cli_complemento_cob, " +
                    "  public.cidade.cid_nome, " +
                    "  public.estado.est_sigla, " +
                    "  public.order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_numero_volume, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_total_volumes, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_quantidade, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_peso, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_cubagem, " +
                    "  public.order_item_etiqueta.oie_order_number, " +
                    "  public.order_item_etiqueta.oie_order_pos " +
                    "FROM " +
                    "  public.order_item_etiqueta " +
                    "  INNER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                    "  LEFT OUTER JOIN public.cidade ON (public.cliente.id_cidade_cob = public.cidade.id_cidade) " +
                    "  LEFT OUTER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                    "  INNER JOIN public.order_item_etiqueta_conferencia ON (public.order_item_etiqueta.id_order_item_etiqueta = public.order_item_etiqueta_conferencia.id_order_item_etiqueta) " +
                    "  INNER JOIN public.order_item_etiqueta_conferencia_volumes ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia = public.order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia) " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes = :id_order_item_etiqueta_conferencia_volumes ";
                                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta_conferencia_volumes", NpgsqlDbType.Integer));



                List<EtiquetaExpedicaoClass> etiquetasImprimir = new List<EtiquetaExpedicaoClass>();
                foreach (SelecaoVolumeEtiquetaEx volume in volumesImprimir)
                {

                    command.Parameters["id_order_item_etiqueta_conferencia_volumes"].Value = volume.IdVolume;
                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    

                    if (!read.HasRows)
                    {
                        throw new ExcecaoTratada("Etiqueta não encontrada para os dados selecionados.");
                    }

                    while (read.Read())
                    {
                        int volumes = Convert.ToInt32(read["ocv_total_volumes"]);
                        int copias = Convert.ToInt32(read["oie_qtd_etiqueta_exp_volume"]);





                        string endereco = read["cli_endereco_cob"] + ", " +
                                          read["cli_endereco_numero_cob"] +
                                          (String.IsNullOrWhiteSpace(read["cli_complemento_cob"].ToString()) ? ", " : " - " + read["cli_complemento_cob"] + ", ") +
                                          read["cli_bairro_cob"] + " CEP: " +
                                          read["cli_cep_cob"] + " - " +
                                          read["cid_nome"] + ", " +
                                          read["est_sigla"];


                        EtiquetaExpedicaoClass tmp = null;
                        for (int j = 0; j < copias; j++)
                        {
                            if (j == 0)
                            {




                                tmp = new EtiquetaExpedicaoClass(
                                    read["cli_nome"].ToString(),
                                    read["ocv_cubagem"].ToString(),
                                    this.Fornecedor,
                                    this.FornecedorLogo,
                                    read["oie_codigo_cliente"].ToString(),
                                    read["oie_descricao_cliente"].ToString(),
                                    Convert.ToDouble(read["ocv_quantidade"]),
                                    read["oie_armazenagem_cliente"].ToString(),
                                    read["oie_order_number"].ToString(),
                                    Convert.ToInt32(read["oie_order_pos"]),
                                    read["oie_ovm"].ToString(),
                                    Convert.ToDouble(read["ocv_peso"]),
                                    volume.NumeroVolume,
                                    volumes,
                                    this.Usuario.Login,
                                    "R",
                                    true,
                                    this.TipoEtiqueta,
                                    Convert.ToInt32(read["id_order_item_etiqueta"]),
                                    endereco,
                                    Convert.ToInt32(read["id_order_item_etiqueta_conferencia_volumes"])
                                    );

                                tmp.Sequencial = (j + 1) + "/" + copias.ToString();

                                etiquetasImprimir.Add(tmp);
                            }
                            else
                            {
                                EtiquetaExpedicaoClass tmp2 = tmp.Clone();
                                tmp2.Sequencial = (j + 1) + "/" + copias.ToString();

                                etiquetasImprimir.Add(tmp2);
                            }

                        }




                    }

                    read.Close();
                }

                ReportDocument rep;

                switch (TipoEtiqueta)
                {
                    case TipoEtiquetaExpedicao.Grande:
                        rep = new EtiquetaExpedicaoReport();
                        break;
                    case TipoEtiquetaExpedicao.Media:
                        rep = new EtiquetaExpedicaoMediaReport();
                        break;
                    case TipoEtiquetaExpedicao.Pequena:
                        rep = new EtiquetaExpedicaoPequenaReport();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                rep.SetDataSource(etiquetasImprimir);
                rep.Refresh();

                IWTFunctions.IWTFunctions.DefineImpressoraReport(ref rep, ImpressoraEtiquetaExpedicao, EtiquetaExpedicao);
                
                rep.PrintToPrinter(1, false, 0, 99999);

            }
            catch (Exception e)
            {
                if (e.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    throw new Exception("Erro ao imprimir a etiqueta.\r\n" + e.Message);
                }
            }
        }


       


        #region Eventos

        private void btnOk_Click(object sender, EventArgs e)
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

        private void rdbUnitaria_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.grbUnitaria.Enabled = this.rdbUnitaria.Checked;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbMultipla_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.grbMultipla.Enabled = this.rdbMultipla.Checked;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion



    }
}
