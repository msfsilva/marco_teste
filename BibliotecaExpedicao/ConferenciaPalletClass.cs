#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Entidades;
using Configurations;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaExpedicao
{
    public class ConferenciaPalletClass
    {
        internal PalletConferencia Pallet;
        public List<ocConferenciaClass> Itens { get; internal set; }
        internal string estacaoConferencia;
        internal AcsUsuarioClass Usuario;
        private readonly IWTPostgreNpgsqlConnection conn;
        readonly string impressoraRelatorioPallet;
        private readonly byte[] logoEmpresa;

        public ConferenciaPalletClass(string barcode, string estacaoConferencia, string impressoraRelatorioPallet, byte[] logo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.estacaoConferencia = estacaoConferencia;
            this.Usuario = Usuario;
            this.conn = conn;
            this.impressoraRelatorioPallet = impressoraRelatorioPallet;

            #region Logo

            logoEmpresa = logo;

            if (logoEmpresa != null)
            {
                MemoryStream ms = new MemoryStream(logoEmpresa);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                logoEmpresa = ms.ToArray();
            }


            #endregion

            try
            {
                string[] barcodeSplit = barcode.Replace("\r", "").Replace("\n", "").Trim().Replace('}', '|').Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (barcodeSplit.Length == 2 && barcodeSplit[0] == "IP")
                {

                    this.Pallet = new PalletConferencia(int.Parse(barcodeSplit[1]),this.conn);

                    if (this.Pallet.Especial)
                    {
                        throw new Exception("Impossível conferir um pallet especial.");
                    }


                    if (!this.Pallet.Especial && (!this.Pallet.Fechado || !this.Pallet.Ocupado))
                    {
                        throw new Exception("Impossível conferir um pallet que não esteja fechado e ocupado.");

                    }

                    if (this.Pallet.Conferido)
                    {
                        throw new Exception("Impossível conferir um pallet já conferido.");
                    }

                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    //command.CommandText = "SELECT * FROM order_item_etiqueta WHERE oie_pallet=" + this.Pallet.Numero + " AND oie_situacao_conferencia_nf=0 AND oie_etiqueta_agrupada = 1 AND oie_situacao_conferencia=2";
                    command.CommandText =

                        "SELECT  " +
                        "  public.order_item_etiqueta_conferencia.oic_order_number, " +
                        "  public.order_item_etiqueta_conferencia.oic_order_pos, " +
                        "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                        "  public.order_item_etiqueta_conferencia.oic_data_conferencia, " +
                        "  public.order_item_etiqueta_conferencia.oic_identificacao_usuario, " +
                        "  public.order_item_etiqueta_conferencia.oic_codigo_item, " +
                        "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia, " +
                        "  public.order_item_etiqueta.oie_status_pedido, " +
                        "  public.order_item_etiqueta.oie_preco_total, " +
                        "  public.order_item_etiqueta.id_externo_cliente_access, " +
                        "  public.order_item_etiqueta.oie_codigo_cliente, " +
                        "  public.order_item_etiqueta.id_cliente, " +
                        "  familia_cliente.fac_tipo_especial, " +
                        "  cliente.cli_nome_resumido, " +
                        "  pedido_item.pei_preco_total " +
                        "FROM " +
                        "  public.order_item_etiqueta " +
                        "  INNER JOIN public.order_item_etiqueta_conferencia ON (public.order_item_etiqueta.id_order_item_etiqueta = public.order_item_etiqueta_conferencia.id_order_item_etiqueta) " +
                        "  LEFT OUTER JOIN cliente ON (public.order_item_etiqueta.id_cliente = cliente.id_cliente) " +
                        "  LEFT OUTER JOIN familia_cliente ON (cliente.id_familia_cliente = familia_cliente.id_familia_cliente) " +
                        "  LEFT OUTER JOIN pedido_item ON (pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +                       
                        "WHERE " +
                        "  oic_pallet = " + this.Pallet.Numero + " AND " +
                        "  oic_conferencia_pallet = 0 AND  " +
                        "  oic_conferencia_pai = 1   AND" +
                        "  id_embarque IS NULL";

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    this.Itens = new List<ocConferenciaClass>();
                    while (read.Read())
                    {

                        if (read["oie_status_pedido"].ToString() != "P" && read["oie_status_pedido"].ToString() != "R")
                        {
                            throw new Exception("Não é possível conferir este pallet pois o pedido " + read["oic_order_number"] + "/" + read["oic_order_pos"] + " não está em um status válido. Status atual: " + read["oie_status_pedido"]+"\r\nConsulte o administrador do sistema.");
                        }


                        //if (!this.Itens.ContainsKey(read["oic_order_number"].ToString() + "_" + read["oic_order_pos"].ToString()))
                        //{
                        bool cliEspecial = false;
                        string cliente = "";

                        if (read["id_externo_cliente_access"] != DBNull.Value)
                        {
                            cliente = read["id_externo_cliente_access"].ToString();
                            if (cliente.ToUpper().StartsWith("ATLAS")){
                                cliEspecial = true;
                            }
                        }
                        else{
                         cliente = read["cli_nome_resumido"].ToString();
                            if (read["fac_tipo_especial"]!=DBNull.Value){
                                cliEspecial = Convert.ToBoolean(Convert.ToInt16(read["fac_tipo_especial"]));
                            }
                        }

                        double precoPedido = 0;
                        if (read["pei_preco_total"] != DBNull.Value)
                        {
                            precoPedido = Convert.ToDouble(read["pei_preco_total"]);
                        }
                        else
                        {
                            precoPedido = Convert.ToDouble(read["oie_preco_total"]);
                        }

                        this.Itens.Add(new ocConferenciaClass(
                                           Convert.ToInt32(read["id_order_item_etiqueta"]),
                                           read["oic_order_number"].ToString(),
                                           Convert.ToInt32(read["oic_order_pos"]),
                                           Convert.ToInt32(read["id_order_item_etiqueta_conferencia"]),
                                           Convert.ToDateTime(read["oic_data_conferencia"]),
                                           read["oic_identificacao_usuario"].ToString(),
                                           read["oic_codigo_item"].ToString(),
                                           precoPedido,
                                           cliente,
                                           cliEspecial,
                                           read["oie_codigo_cliente"].ToString(),
                                           this,
                                           this.conn,
                                           Convert.ToInt32(read["id_cliente"]),
                                           Usuario));
                        //}
                        //else
                        //{
                        //    throw new Exception("OC Duplicada: " + read["oic_order_number"].ToString() + "/" + read["oic_order_pos"].ToString());
                        //}
                    }
                    read.Close();

                }
                else
                {
                    throw new Exception("Código do pallet inválido");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do pallet.\r\n" + e.Message);
            }

        }

        public void ConfereItem(string barcode)
        {
            try
            {
                long idOrderItemEtiquetaConferenciaVolume = -1;
                long idOrderItemEtiquetaConferencia = -1;
                barcode = barcode.Replace("\r","").Replace("\n","").Trim();

                int totalVolumes = 0;
                int volume = 0;
                int orderPos = -1;
                string orderNumber = null;

                if (barcode.StartsWith("EXCV_"))
                {
                    if (!long.TryParse(barcode.Substring(5), out idOrderItemEtiquetaConferenciaVolume))
                    {
                        throw new Exception("Código de barras inválido para oc volume.");
                    }


                    OrderItemEtiquetaConferenciaVolumesClass volumeConferencia = OrderItemEtiquetaConferenciaVolumesClass.GetEntidade(idOrderItemEtiquetaConferenciaVolume, Usuario, conn);
                    idOrderItemEtiquetaConferencia = volumeConferencia.OrderItemEtiquetaConferencia.ID;

                }
                else
                {
                    if (barcode.StartsWith("EX_"))
                    {
                        string[] tmp = barcode.Remove(0, 3).Split(new string[] {"_"}, StringSplitOptions.RemoveEmptyEntries);
                        if (tmp.Length == 3)
                        {
                            int idOrderItemEtiqueta = int.Parse(tmp[0]);
                            volume = int.Parse(tmp[1]);
                            totalVolumes = int.Parse(tmp[2]);

                            OrderItemEtiquetaClass oie = OrderItemEtiquetaClass.GetEntidade(idOrderItemEtiqueta, Usuario, conn);
                            List<OrderItemEtiquetaConferenciaClass> conferencias = oie.CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Where(a => a.OrderItemEtiqueta == oie && a.Volumes == totalVolumes && a.ConferenciaPai && !a.ConferenciaPallet && !a.NfEmitida).ToList();
                            if (!conferencias.Any())
                            {
                                throw new ExcecaoTratada("Não foi encontrada nenhuma conferência ");
                            }

                            if (conferencias.Count>1)
                            {
                                throw new ExcecaoTratada("Foram encontradas multiplas conferências, reimprima a etiqueta de EX para seja gerado um código único");
                            }
                            OrderItemEtiquetaConferenciaClass conferencia = conferencias.First();
                            OrderItemEtiquetaConferenciaVolumesClass volumeConferencia = conferencia.CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia.FirstOrDefault(a => a.NumeroVolume == volume);
                            if (volumeConferencia == null)
                            {
                                throw new ExcecaoTratada("Não foi encontrado nenhum volume cadastrado com número " + volume + " na conferência " + conferencia.ID);
                            }

                            idOrderItemEtiquetaConferenciaVolume = volumeConferencia.ID;
                            idOrderItemEtiquetaConferencia = conferencia.ID;
                        }
                        else
                        {
                            throw new Exception("Código de barras inválido para oc.");
                        }
                    }
                    else
                    {
                        if (barcode.Length >= 9 && barcode[0] == 'K')
                        {
                            
                            totalVolumes = int.Parse(barcode.Substring(barcode.Length - 2, 2));
                            volume = int.Parse(barcode.Substring(barcode.Length - 4, 2));
                            string tmp = barcode.Substring(barcode.Length - 7, 3);
                            if (tmp.Contains("-"))
                            {
                                orderPos = (int.Parse(tmp.Replace("-", ""))*-1);
                            }
                            else
                            {
                                orderPos = int.Parse(tmp);
                            }

                            orderNumber = barcode.Substring(1, barcode.Length - 8).Replace(';', ' ');
                        }
                        else
                        {

                            throw new Exception("Código de barras inválido para oc.");
                        }
                    }
                }

                


                bool found = false;
                string error = "";

                if (idOrderItemEtiquetaConferenciaVolume != -1)
                {
                    //Conferencia Nova pelo id do volume
                    ocConferenciaClass item = Itens.FirstOrDefault(a => a.IdOrderItemEtiquetaConferencia == idOrderItemEtiquetaConferencia);
                    if (item == null)
                    {
                        throw new ExcecaoTratada("Item Inválido para o Pallet");
                    }


                    if (!item.baixaUnidade(idOrderItemEtiquetaConferenciaVolume, out error))
                    {
                        throw new Exception(error);
                    }
                }
                else
                {
                    found = BaixaPorOcPos(orderNumber, orderPos, totalVolumes, volume, out error);
                    //Tenta encontrar com total de volumes de 3 caracteres e nvolume com 2
                    if (!found)
                    {
                        totalVolumes = int.Parse(barcode.Substring(barcode.Length - 3, 3));
                        volume = int.Parse(barcode.Substring(barcode.Length - 5, 2));
                        string tmp = barcode.Substring(barcode.Length - 8, 3);
                        if (tmp.Contains("-"))
                        {
                            orderPos = (int.Parse(tmp.Replace("-", ""))*-1);
                        }
                        else
                        {
                            orderPos = int.Parse(tmp);
                        }

                        orderNumber = barcode.Substring(1, barcode.Length - 9).Replace(';', ' ');
                        found = BaixaPorOcPos(orderNumber, orderPos, totalVolumes, volume, out error);

                        if (!found)
                        {
                            //Tenta encontrar com total de volumes de 3 caracteres e nvolume com 3
                            totalVolumes = int.Parse(barcode.Substring(barcode.Length - 3, 3));
                            volume = int.Parse(barcode.Substring(barcode.Length - 6, 3));
                            tmp = barcode.Substring(barcode.Length - 9, 3);
                            if (tmp.Contains("-"))
                            {
                                orderPos = (int.Parse(tmp.Replace("-", ""))*-1);
                            }
                            else
                            {
                                orderPos = int.Parse(tmp);
                            }

                            orderNumber = barcode.Substring(1, barcode.Length - 10).Replace(';', ' ');
                            found = BaixaPorOcPos(orderNumber, orderPos, totalVolumes, volume, out error);



                        }

                    }

                    if (!found)
                    {
                        if (error.Length > 0)
                        {
                            throw new Exception(error);
                        }
                        else
                        {
                            throw new Exception("Item inválido para o pallet.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a conferência do item.\r\n" + e.Message);
            }

        }


        private bool BaixaPorOcPos(string orderNumber, int orderPos, int totalVolumes, int volume, out string error)
        {
            error = "";
            foreach (ocConferenciaClass item in this.Itens)
            {
                if (((item.Oc == orderNumber && item.Pos == orderPos)) && item.qtdVolumes == totalVolumes)
                {
                    if (item.baixaUnidadePorNumeroVolume(volume, out error))
                    {
                        error = "";
                        return  true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return false;
        }

        public void Save()
        {
            bool existeAberto = false;
            if (!this.Pallet.Especial)
            {
                foreach (ocConferenciaClass oc in this.Itens)
                {
                    if (oc.situacaoConferencia != 2)
                    {
                        existeAberto = true;
                        break;
                    }
                }
            }
            if (existeAberto)
            {
                throw new Exception("Não é possível salvar a conferência pois existem ocs não conferidas.");
            }
            else
            {

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                try
                {
                    command.Transaction = this.conn.BeginTransaction();

                    this.Pallet.setConferido(true);
                    this.Pallet.Save(command);

                    this.Pallet = new PalletConferencia(this.Pallet.Numero, this.conn);

                    //Imprime o report
                    PalletReportDataSet ds = new PalletReportDataSet();
                    PalletReportDataSet.palletRow row;
                    PalletReportDataSet.erros_precoRow rowErro;


                    string tempDir = Environment.GetEnvironmentVariable("temp");

                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";


                    process.StartInfo.Arguments = "IP2|" + this.Pallet.Numero.ToString() + " " + tempDir + "\\code.bmp";
                    process.Start();
                    process.WaitForExit();

                    FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] array = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();






                    foreach (ocConferenciaClass oc in this.Itens)
                    {
                        foreach (OcConferenciaVolumeClass volume in oc.Volumes)
                        {
                            row = ds.pallet.NewpalletRow();
                            row.numPallet = this.Pallet.Numero;
                            row.oc = oc.Oc;
                            row.pos = oc.Pos;
                            row.volume = volume.NumeroVolume;
                            row.totalVolumes = oc.qtdVolumes;
                            row.dataConferencia = oc.dataConferencia;
                            row.conferidor = oc.Conferidor;
                            row.codItem = oc.codItemCliente;
                            row.codigBarrasPallet = array;
                            row.logoEmpresa = logoEmpresa;
                            ds.pallet.AddpalletRow(row);
                        }


                        oc.Save(command.Connection);
                        string msg = "";
                        if (!oc.validaPreco(out msg))
                        {
                            //Insere no report de inconsistencia
                            rowErro = ds.erros_preco.Newerros_precoRow();
                            rowErro.pedido = oc.Oc + "/" + oc.Pos;
                            rowErro.observacao = msg;
                            if (msg.Length == 0)
                            {
                                rowErro.preco_tabela = oc.precoTabela;
                            }
                            rowErro.preco_pedido = oc.precoPedido;

                            if (oc.precoCliente != null)
                            {
                                rowErro.preco_cliente = (double)oc.precoCliente;
                            }
                            rowErro.produto = oc.codItem;
                            ds.erros_preco.Adderros_precoRow(rowErro);

                            try
                            {
                                command.CommandText = " INSERT INTO                " +
                                                        "   public.divergencia_preco " +
                                                        " (                          " +
                                                        "   div_oc,                  " +
                                                        "   div_pos,                 " +
                                                        "   div_mensagem,            " +
                                                        "   div_preco_tabela,        " +
                                                        "   div_preco_pedido,        " +
                                                        "   div_preco_cliente,       " +
                                                        "   div_codigo_item          " +
                                                        " )                          " +
                                                        " VALUES (                   " +
                                                        "   :div_oc,                 " +
                                                        "   :div_pos,                " +
                                                        "   :div_mensagem,           " +
                                                        "   :div_preco_tabela,       " +
                                                        "   :div_preco_pedido,       " +
                                                        "   :div_preco_cliente,      " +
                                                        "   :div_codigo_item         " +
                                                        " );";

                                command.Parameters.Clear();
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_oc", NpgsqlDbType.Varchar));
                                command.Parameters[command.Parameters.Count - 1].Value = oc.Oc;
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_pos", NpgsqlDbType.Integer));
                                command.Parameters[command.Parameters.Count - 1].Value = oc.Pos;
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_mensagem", NpgsqlDbType.Varchar));
                                command.Parameters[command.Parameters.Count - 1].Value = msg;
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_preco_tabela", NpgsqlDbType.Double));
                                command.Parameters[command.Parameters.Count - 1].Value = oc.precoTabela;
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_preco_pedido", NpgsqlDbType.Double));
                                command.Parameters[command.Parameters.Count - 1].Value = oc.precoPedido;
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_preco_cliente", NpgsqlDbType.Double));
                                command.Parameters[command.Parameters.Count - 1].Value = oc.precoCliente;
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_codigo_item", NpgsqlDbType.Varchar));
                                command.Parameters[command.Parameters.Count - 1].Value = oc.codItem;
                                command.ExecuteNonQuery();
                            }
                            catch (Exception aa)
                            {
                                throw new Exception("Erro ao inserir divergência de preço.\r\nMensagem: " + aa.Message);
                            }
                        }
                    }



                    if (ds.pallet.Rows.Count > 0)
                    {
                        //PalletReportForm form = new PalletReportForm(ds);
                        //form.Show();

                        ReportDocument rep = new PalletReport();
                        rep.SetDataSource(ds);
                        rep.Subreports[0].SetDataSource(ds);
                        rep.Refresh();

                        rep.SetParameterValue("ImpressoEm", "Impresso por " + Usuario.Login + " em " + DataIndependenteClass.GetData().ToString("dd/MM/yyyy HH:mm:ss"));
                        rep.SetParameterValue("conf", this.Usuario + " em " + Configurations.DataIndependenteClass.GetData().ToString("dd/MM/yyyy HH:mm:ss"));

                        rep.PrintOptions.PrinterName = this.impressoraRelatorioPallet;
                        IWTFunctions.IWTFunctions.DefineImpressoraReport(ref rep, impressoraRelatorioPallet, "A4");
                        rep.PrintToPrinter(1, false, 0, 99999);
                    }
                    else
                    {
                        if (this.Pallet.Conferido)
                        {
                            throw new Exception("O pallet selecionado já foi conferido");
                        }
                        else
                        {
                            throw new Exception("O pallet selecionado está vazio");
                        }
                    }

                    command.Transaction.Commit();
                }
                catch (Exception e)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }

                    throw new Exception("Erro ao salvar a conferência.\r\n" + e.Message);

                }
            }
        }

    }


    public class ocConferenciaClass
    {
        
        public long idOrderItemEtiqueta;
        public string Oc;
        public int Pos;
        private long idCliente;

        public int qtdVolumes
        {
            get { return Volumes.Count; }
        }
        public int qtdVolumesConferidos
        {
            get { return Volumes.Count(a=>a.Conferido); }
        }

        public int saldoVolumes
        {
            get
            {
                return this.qtdVolumes - this.qtdVolumesConferidos;
            }
        }




        public int situacaoConferencia = 0;
        private readonly ConferenciaPalletClass Parent;
        public long IdOrderItemEtiquetaConferencia { get; private set; }

        public DateTime dataConferencia { private set; get; }
        public string Conferidor { private set; get; }

        public string codItem { private set; get; }
        public string codItemCliente { private set; get; }

        public double precoPedido { private set; get; }
        public double precoTabela { private set; get; }
        public Double? precoCliente { private set; get; }

        public string Cliente { private set; get; }
        public bool cliEspecial { private set; get; }

        readonly IWTPostgreNpgsqlConnection conn;

        private bool validacaoPrecoHabilitada = true;
        private PalletConferencia Pallet;
        private string EstacaoConferencia;

        internal List<OcConferenciaVolumeClass> Volumes { get; set; }
        private AcsUsuarioClass _usuario;

        public ocConferenciaClass(int idOrderItemEtiqueta, string Oc, int Pos, int idOrderItemEtiquetaConferencia, DateTime dataConferencia, string Conferidor, string codItem, double precoPedido, string Cliente,bool cliEspecial, string codItemCliente, ConferenciaPalletClass Parent, IWTPostgreNpgsqlConnection conn, int idCliente, AcsUsuarioClass usuario)
        {
            this.idOrderItemEtiqueta = idOrderItemEtiqueta;
            this.IdOrderItemEtiquetaConferencia = idOrderItemEtiquetaConferencia;
            this.Oc = Oc;
            this.Pos = Pos;
            this.Parent = Parent;
            this.dataConferencia = dataConferencia;
            this.Conferidor = Conferidor;
            this.codItem = codItem;
            this.precoPedido = precoPedido;
            this.Cliente = Cliente;
            this.cliEspecial = cliEspecial;
            this.codItemCliente = codItemCliente;



            this.conn = conn;
            this.idCliente = idCliente;
            _usuario = usuario;

            this.CarregarVolumes();
        }

        //Construtor utilizado quando não é necessária a conferência de pallet, o sistema deverá ja lançar os volumes baixados.
        public ocConferenciaClass(long idOrderItemEtiqueta, string Oc, int Pos, long idOrderItemEtiquetaConferencia, DateTime dataConferencia, string Conferidor, string codItem,PalletConferencia pallet, string estacaoConferencia,  IWTPostgreNpgsqlConnection conn, int idCliente, AcsUsuarioClass usuario)
        {
            this.idOrderItemEtiqueta = idOrderItemEtiqueta;
            this.IdOrderItemEtiquetaConferencia = idOrderItemEtiquetaConferencia;
            this.Oc = Oc;
            this.Pos = Pos;
            this.dataConferencia = dataConferencia;
            this.Conferidor = Conferidor;
            this.codItem = codItem;

            this.conn = conn;
            this.idCliente = idCliente;
            _usuario = usuario;

            validacaoPrecoHabilitada = false;
            this.Parent = null;
            this.Pallet = pallet;
            this.EstacaoConferencia = estacaoConferencia;


            this.CarregarVolumes();
            string error;
            foreach (OcConferenciaVolumeClass volume in Volumes)
            {
                this.baixaUnidade(volume.IdOrderItemEtiquetaConferenciaVolumes, out error);
            }

           
            
        }


        void CarregarVolumes()
        {

            try
            {
                this.Volumes = new List<OcConferenciaVolumeClass>();

                OrderItemEtiquetaConferenciaClass conferencia = OrderItemEtiquetaConferenciaClass.GetEntidade(IdOrderItemEtiquetaConferencia, _usuario, conn);

                foreach (OrderItemEtiquetaConferenciaVolumesClass volume in conferencia.CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia)
                {
                    this.Volumes.Add(new OcConferenciaVolumeClass(volume.ID, volume.NumeroVolume));
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar os volumes da  Conferencia.\r\n" + e.Message, e);
            }
            
        }


        internal bool baixaUnidade(long idOrderItemEtiquetaConferenciaVolume, out string error)
        {
            OcConferenciaVolumeClass volumeEncontrado = this.Volumes.FirstOrDefault(a => a.IdOrderItemEtiquetaConferenciaVolumes == idOrderItemEtiquetaConferenciaVolume);

            if (volumeEncontrado == null)
            {
                error = "Esse volume é inválido para a conferência";
                return false;
            }

            if (volumeEncontrado.Conferido)
            {
                error = "Esse volume já foi conferido (" + volumeEncontrado.NumeroVolume.ToString() + ")";
                return false;
            }

            volumeEncontrado.Conferido = true;

            if (saldoVolumes == 0)
            {
                this.situacaoConferencia = 2;
            }
            else
            {
                if (this.qtdVolumesConferidos > 0)
                {
                    this.situacaoConferencia = 1;
                }
            }

            error = "";
            return true;
        }

        public bool baixaUnidadePorNumeroVolume(int volume, out string error)
        {

            OcConferenciaVolumeClass volumeEncontrado = this.Volumes.FirstOrDefault(a => a.NumeroVolume == volume);

            if (volumeEncontrado == null)
            {
                error = "Esse volume é inválido para a conferência";
                return false;
            }

            if (volumeEncontrado.Conferido)
            {
                error = "Esse volume já foi conferido (" + volumeEncontrado.NumeroVolume.ToString() + ")";
                return false;
            }

            volumeEncontrado.Conferido = true;


            if (saldoVolumes == 0)
            {
                this.situacaoConferencia = 2;
            }
            else
            {
                if (this.qtdVolumesConferidos > 0)
                {
                    this.situacaoConferencia = 1;
                }
            }

            error = "";
            return true;
        }

        internal void Save(IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            this.Save(ref  command);
        }

        internal void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                command.CommandText = "UPDATE order_item_etiqueta SET oie_situacao_conferencia_nf=" + this.situacaoConferencia + " WHERE id_order_item_etiqueta=" + this.idOrderItemEtiqueta;
                command.ExecuteNonQuery();

                if (this.situacaoConferencia != 0)
                {
                    command.CommandText = "INSERT INTO " +
                                          "  public.order_item_etiqueta_conferencia_nf " +
                                          "( " +
                                          "  oin_order_number, " +
                                          "  oin_order_pos, " +
                                          "  oin_pallet, " +
                                          "  oin_quantidade_conferida, " +
                                          "  oin_data_conferencia, " +
                                          "  oin_identificacao_estacao, " +
                                          "  id_order_item_etiqueta, " +
                                          "  oin_identificacao_usuario, " +
                                          "  oin_pallet_sequencia " +

                                          ")  " +
                                          "VALUES ( " +
                                          "  :oin_order_number, " +
                                          "  :oin_order_pos, " +
                                          "  :oin_pallet, " +
                                          "  :oin_quantidade_conferida, " +
                                          "  :oin_data_conferencia, " +
                                          "  :oin_identificacao_estacao, " +
                                          "  :id_order_item_etiqueta, " +
                                          "  :oin_identificacao_usuario, " +
                                          "  :oin_pallet_sequencia " +
                                          ");";

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_order_number", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Oc;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_order_pos", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Pos;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_pallet", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent != null ? this.Parent.Pallet.Numero : this.Pallet.Numero;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_quantidade_conferida", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.qtdVolumesConferidos;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_data_conferencia", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_identificacao_estacao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent != null ? this.Parent.estacaoConferencia : this.EstacaoConferencia;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrderItemEtiqueta;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_identificacao_usuario", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent != null ? this.Parent.Usuario.Login : this.Conferidor;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oin_pallet_sequencia", NpgsqlDbType.Bigint));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent != null ? this.Parent.Pallet.Sequencia : this.Pallet.Sequencia;

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "UPDATE " +
                                          "order_item_etiqueta_conferencia SET " +
                                          "oic_conferencia_pallet = 1," +
                                          "oic_conferencia_pallet_usuario=:oic_conferencia_pallet_usuario," +
                                          " oic_conferencia_pallet_data=:oic_conferencia_pallet_data " +
                                          "WHERE id_order_item_etiqueta_conferencia=:id_order_item_etiqueta_conferencia";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_conferencia_pallet_usuario", NpgsqlDbType.Varchar, (this.Parent != null ? this.Parent.Usuario.Login : Conferidor)));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_conferencia_pallet_data", NpgsqlDbType.Timestamp, Configurations.DataIndependenteClass.GetData()));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta_conferencia", NpgsqlDbType.Bigint, this.IdOrderItemEtiquetaConferencia));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao salvar a conferência da OC.\r\n" + a.Message);
            }
        }

        internal bool validaPreco(out string mensagem)
        {
            try
            {
                IWTPostgreNpgsqlCommand cmd = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader rd;

                if (this.cliEspecial)
                {
                    //Conferencia de Preço pedidos SO ATLAS


                    cmd.CommandText = "SELECT price_per_unit*item_qty as preco FROM order_item WHERE order_number = '" + this.Oc + "' AND order_pos = " + this.Pos + " AND engineering_level = 0";
                    rd = cmd.ExecuteReader();
                    rd.Read();
                    if (rd.HasRows)
                    {
                        this.precoCliente = Convert.ToDouble(rd["preco"]);
                    }
                    else
                    {
                        mensagem = "Pedido inexistente no SupplyOn.";
                        return false;
                    }
                }


                //validação genérica
                this.precoTabela = 0;
                bool precoTabelaEncontrado = false;

                //Preço Fixo
                /*cmd.CommandText = "SELECT tpf_preco FROM tabela_preco_item_fixo WHERE tpf_codigo LIKE '" + this.codItemCliente + "';";

                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    this.precoTabela += Convert.ToDouble(rd["tpf_preco"]);
                    precoTabelaEncontrado = true;
                }

                rd.Close();
                */

                //Preço Variável
                cmd.CommandText = "SELECT tpv_preco FROM tabela_preco_item_variavel WHERE tpv_order_number LIKE '" + this.Oc + "' AND tpv_pos=" + this.Pos + " AND (id_cliente = " + this.idCliente + " OR id_cliente IS NULL) ORDER BY id_cliente ASC ;";
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    this.precoTabela = Convert.ToDouble(rd["tpv_preco"]);
                    precoTabelaEncontrado = true;
                }
                rd.Close();

                if (!precoTabelaEncontrado)
                {
                    mensagem = "Item inexistente nas tabelas de preço.";
                    return false;
                }


                
                mensagem = "";

                List<double> temp = new List<double>();
                if (this.precoCliente != null)
                {
                    temp.Add((double)this.precoCliente);
                }
                temp.Add(this.precoPedido);
                temp.Add(this.precoTabela);
                temp.Sort();

                double maior = temp[temp.Count - 1];
                double menor = temp[0];

                if (maior - menor > 1)
                {

                    return false;
                }
                else
                {

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar o preço do pedido.\r\n" + e.Message);
            }
        }

        
    }
}
