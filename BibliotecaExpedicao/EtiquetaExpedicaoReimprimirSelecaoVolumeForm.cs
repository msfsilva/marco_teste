using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaExpedicao
{
    public partial class EtiquetaExpedicaoReimprimirSelecaoVolumeForm : IWTBaseForm
    {
        public List<SelecaoVolumeEtiquetaEx> Volumes { get; private set; }

        public EtiquetaExpedicaoReimprimirSelecaoVolumeForm(List<SelecaoVolumeEtiquetaEx> pedidos)
        {

            InitializeComponent();

            this.LoadVolumes(pedidos);
        }

        private void LoadVolumes(List<SelecaoVolumeEtiquetaEx> pedidos)
        {
            try
            {
                Volumes = new List<SelecaoVolumeEtiquetaEx>();
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();

                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_numero_volume, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_total_volumes, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_quantidade, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_peso, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_cubagem, " +
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia, " +
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_estacao, " +
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_usuario " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia_volumes " +
                    "  INNER JOIN public.order_item_etiqueta_conferencia ON (public.order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia = public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number = :oic_order_number AND  " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos = :oic_order_pos AND  " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pai = 1 AND " +
                    "  public.order_item_etiqueta.id_cliente = :id_cliente " +
                    "ORDER BY " +
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia, " +
                    "  public.order_item_etiqueta_conferencia_volumes.ocv_numero_volume ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_order_number", NpgsqlDbType.Varchar));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_order_pos", NpgsqlDbType.Integer));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                foreach (SelecaoVolumeEtiquetaEx pedido in pedidos)
                {
                    command.Parameters["oic_order_number"].Value = pedido.Oc;
                    command.Parameters["oic_order_pos"].Value = pedido.Posicao;
                    command.Parameters["id_cliente"].Value = pedido.IdCliente;

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        this.Volumes.Add(new SelecaoVolumeEtiquetaEx(pedido.Oc, pedido.Posicao, pedido.IdCliente)
                        {
                            Cubagem = read["ocv_cubagem"].ToString(),
                            DataConferencia = Convert.ToDateTime(read["oic_data_conferencia"]),
                            EstacaoConferencia = read["oic_identificacao_estacao"].ToString(),
                            IdVolume = Convert.ToInt32(read["id_order_item_etiqueta_conferencia_volumes"]),
                            NumeroVolume = Convert.ToInt32(read["ocv_numero_volume"]),
                            Peso = Convert.ToDouble(read["ocv_peso"]),
                            Qtd = Convert.ToDouble(read["ocv_quantidade"]),
                            TotalVolumes = Convert.ToInt32(read["ocv_total_volumes"]),
                            UsuarioConferencia = read["oic_identificacao_usuario"].ToString()
                        });
                    }
                    read.Close();
                }



            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao buscar os volumes dos pedidos para reimpressão.\r\n" + e.Message, e);
            }
        }

        private void InitializeDataGrid()
        {
            try
            {
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.AutoGenerateColumns = true;
                this.dataGridView1.DataSource = this.Volumes;

                this.dataGridView1.Columns["IdVolume"].Visible = false;
                this.dataGridView1.Columns["IdCliente"].Visible = false;

                this.dataGridView1.Columns["NumeroVolume"].HeaderText = "Volume";
                this.dataGridView1.Columns["TotalVolumes"].HeaderText = "Total de Volumes";
                this.dataGridView1.Columns["DataConferencia"].HeaderText = "Data de Conferência";
                this.dataGridView1.Columns["EstacaoConferencia"].HeaderText = "Estação";
                this.dataGridView1.Columns["UsuarioConferencia"].HeaderText = "Usuário";

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar o datagrid.\r\n" + e.Message, e);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                this.InitializeDataGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }


    public class SelecaoVolumeEtiquetaEx
    {
        public bool Selecionado { get; set; }

        public string Oc { get; private set; }
        public int Posicao { get; private set; }
        public long IdCliente { get; private set; }

        public long IdVolume { get; internal set; }
        public int NumeroVolume { get; internal set; }
        public int TotalVolumes { get; internal set; }
        public double Qtd { get; internal set; }
        public double Peso { get; internal set; }
        public string Cubagem { get; internal set; }

        public DateTime DataConferencia { get; internal set; }
        public string EstacaoConferencia { get; internal set; }
        public string UsuarioConferencia { get; internal set; }


        public SelecaoVolumeEtiquetaEx(string oc, int posicao, long idCliente)
        {
            this.Oc = oc;
            this.Posicao = posicao;
            this.IdCliente = idCliente;
        }
    }
}
