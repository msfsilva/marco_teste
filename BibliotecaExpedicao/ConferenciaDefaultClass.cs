#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

#endregion

namespace BibliotecaExpedicao
{
    public abstract class ConferenciaDefaultClass:IDisposable
    {
        public string OrderNumber { get; protected set; }
        public int OrderPos { get; protected set; }

        public string Projeto { get; protected set; }

        public int idCliente { get; protected set; }
        public int IdOrderItemEtiqueta { get; protected set; }

        public string EstacaoConferencia { get; protected set; }
        public AcsUsuarioClass Usuario { get; protected set; }

        public PalletConferencia Pallet { get; protected set; }
        public short SituacaoConferencia { get; protected set; }
        
        public int QtdVolumes
        {
            get
            {
                return this.Volumes.Count;
            }
        }

        public string CodItemPai { get; protected set; }
        public double QtdItemPai;

        public double QtdItemPaiOriginal;
        public double QtdConferidaAnteriormente { get; set; }

        public double SaldoNf;

        protected readonly bool _utilizarTimer;
        public bool UtilizarTimer
        {
            get { return _utilizarTimer; }
        }

        protected readonly bool _permitirParcial;
        public bool PermitirParcial
        {
            get { return _permitirParcial; }
        }

        protected readonly bool _permitirEntregaParcial;
        public bool PermitirEntregaParcial
        {
            get { return _permitirEntregaParcial; }
        }
 
        public List<ItemConferencia> Itens;

        public double PesoPaiUnitario { get; set; }

        public List<Volume> Volumes { get; protected set; }
        protected readonly Dictionary<string, List<int>> _sequenciaisUtilizados;

        public bool VolumeUnico { get; protected set; }

        public bool Abort { get; protected set; }

        protected string tipoCalculoSemana;
        protected string diaCalculoSemana;
        protected readonly IWTPostgreNpgsqlConnection conn;
        private readonly ConferenciaPedidosForm _formBase;
        protected readonly bool UtilizarEstoqueOP;
        protected IOrdemProducaoFactory iOrdemProducaoFactory;

        public string Cliente;
        public string DescItemPai;

        public bool ExigeValidacaoPesoExpedicao { get; protected set; }
        protected int idProdutoPai;

        protected ProdutoClass produto;
        private string _arquivoLogEmbalagem = null;

        protected ClienteClass ClienteEntidade { get; private set; }

        protected ConferenciaDefaultClass(string barCode, IOrdemProducaoFactory iOrdemProducaoFactory, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, ConferenciaPedidosForm formBase)
        {
            
            this.tipoCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO);
            this.diaCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA); 
            this.UtilizarEstoqueOP = IWTConfiguration.Conf.getBoolConf(Constants.UTILIZA_ESTOQUE_OP); 
            this.EstacaoConferencia = Environment.MachineName;

            this.conn = conn;
            _formBase = formBase;
            this.iOrdemProducaoFactory = iOrdemProducaoFactory;

            _permitirEntregaParcial = false;
            _permitirParcial = false;
            _utilizarTimer = true;


            if (barCode.StartsWith("OC_"))
            {
                string[] tmp = barCode.Split('_');
                if (tmp.Length == 3 && tmp[0] == "OC")
                {
                    this.OrderNumber = tmp[1].Replace(';', ' ');
                    this.OrderPos = int.Parse(tmp[2]);
                    this.IdOrderItemEtiqueta = -1;
                }
                else
                {
                    throw new Exception("Código inválido para oc.");
                }
            }
            else
            {
                if (barCode.StartsWith("OIE_"))
                {
                    this.IdOrderItemEtiqueta = int.Parse(barCode.Remove(0, 4));
                }
                else
                {
                    throw new Exception("Código inválido para oc.");
                }
            }


           
            this.Usuario = Usuario;
            this.Itens = new List<ItemConferencia>();
            this._sequenciaisUtilizados = new Dictionary<string, List<int>>();

            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

            
            try
            {

                if (this.IdOrderItemEtiqueta == -1)
                {
                    command.CommandText = "SELECT * FROM order_item_etiqueta LEFT JOIN produto ON order_item_etiqueta.id_produto = produto.id_produto WHERE oie_order_number='" + this.OrderNumber + "' AND oie_order_pos= " + this.OrderPos + " AND oie_nivel_item=0 AND oie_nota_fiscal=1";
                }
                else
                {

                    command.CommandText =
                        "SELECT " +
                        "pedido_item.pei_status, " +
                        "order_item_etiqueta.oie_volumes, " +
                        "order_item_etiqueta.oie_codigo_item, " +
                        "order_item_etiqueta.oie_descricao, " +
                        "order_item_etiqueta.oie_saldo_conferencia, " +
                        "order_item_etiqueta.oie_quantidade, " +
                        "order_item_etiqueta.oie_saldo, " +
                        "produto.id_produto, " +
                        "order_item_etiqueta.oie_situacao_conferencia, " +
                        "order_item_etiqueta.id_order_item_etiqueta, " +
                        "order_item_etiqueta.oie_usar_timer, " +
                        "order_item_etiqueta.oie_permitir_parcial, " +
                        "order_item_etiqueta.oie_emissao_parcial, " +
                        "order_item_etiqueta.oie_volume_unico, " +
                        "order_item_etiqueta.oie_order_number, " +
                        "order_item_etiqueta.oie_order_pos, " +
                        "order_item_etiqueta.oie_ovm, " +
                        "cliente.id_cliente, " +
                        "cliente.cli_nome_resumido, " +
                        "produto.pro_validacao_peso_expedicao, " +
                        "order_item_etiqueta.oie_altura, "+
                        "order_item_etiqueta.oie_largura, "+
                        "order_item_etiqueta.oie_comprimento "+
                        "FROM " +
                        "  order_item_etiqueta " +
                        "  LEFT OUTER JOIN produto ON (order_item_etiqueta.id_produto = produto.id_produto) " +
                        "  LEFT OUTER JOIN public.pedido_item ON (order_item_etiqueta.id_pedido_item = public.pedido_item.id_pedido_item) " +
                        "  LEFT OUTER JOIN public.cliente ON (public.cliente.id_cliente = public.pedido_item.id_cliente) " +
                        "WHERE " +
                        "  id_order_item_etiqueta = " + this.IdOrderItemEtiqueta;
                }

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

              

                if (!read.HasRows)
                {
                    read.Close();
                    throw new Exception("OC/Pos Inválida");
                }

                read.Read();

                StatusPedido status = (StatusPedido) Enum.Parse(typeof (BibliotecaEntidades.Base.StatusPedido), read["pei_status"].ToString());

                if (status != StatusPedido.Pendente && status != StatusPedido.Reaberto)
                {
                    throw new Exception("O Pedido possui status inválido. Status do pedido: " + status);
                }

                int volumesBd = Convert.ToInt32(read["oie_volumes"]);
                this.CodItemPai = read["oie_codigo_item"].ToString();
                this.DescItemPai = read["oie_descricao"].ToString();
                this.QtdItemPai = Convert.ToDouble(read["oie_saldo_conferencia"]);
                this.QtdItemPaiOriginal = Convert.ToDouble(read["oie_quantidade"]);
                this.QtdConferidaAnteriormente = QtdItemPaiOriginal - QtdItemPai;
                this.SaldoNf = Convert.ToDouble(read["oie_saldo"]);

                double? altura = read["oie_altura"] as double?;
                double? largura = read["oie_largura"] as double?;
                double? comprimento = read["oie_comprimento"] as double?;

                string cubagemM3;
                string cubagem = _formBase.getCubagem(altura, largura, comprimento, out cubagemM3);

                //if (read["oie_peso"] != DBNull.Value)
                //{
                //    this.PesoPai = Convert.ToDouble(read["oie_peso"]);
                //}

                produto = ProdutoBaseClass.GetEntidade(Convert.ToInt32(read["id_produto"]), this.Usuario, this.conn);
                this.PesoPaiUnitario = produto.PesoUnitario;


                
                

                if (read["oie_situacao_conferencia"].ToString() == "2")
                {
                    read.Close();
                    throw new Exception("A oc já foi conferida totalmente");
                }

                this.IdOrderItemEtiqueta = Convert.ToInt32(read["id_order_item_etiqueta"]);
                this._utilizarTimer = Convert.ToBoolean(Convert.ToInt16(read["oie_usar_timer"]));
                this._permitirParcial = Convert.ToBoolean(Convert.ToInt16(read["oie_permitir_parcial"]));
                this._permitirEntregaParcial = Convert.ToBoolean(Convert.ToInt16(read["oie_emissao_parcial"]));
                this.VolumeUnico = Convert.ToBoolean(Convert.ToInt16(read["oie_volume_unico"]));
                this.OrderNumber = read["oie_order_number"].ToString();
                this.OrderPos = Convert.ToInt32(read["oie_order_pos"]);

                this.Projeto = read["oie_ovm"].ToString();

                this.idCliente = Convert.ToInt32(read["id_cliente"]);
                this.Cliente = read["cli_nome_resumido"].ToString();

                this.ExigeValidacaoPesoExpedicao = Convert.ToBoolean(Convert.ToInt16(read["pro_validacao_peso_expedicao"]));
                this.idProdutoPai = Convert.ToInt32(read["id_produto"]);
                read.Close();


                //Verifica se tem customizados sem conferencia 

                command.CommandText = "SELECT count(id_order_item_etiqueta) FROM order_item_etiqueta WHERE oie_order_number='" + this.OrderNumber + "' AND oie_order_pos= " + this.OrderPos + " AND id_cliente = " + this.idCliente +
                                      " AND oie_tipo_item=1 AND oie_conferencia_customizada_realizada = 0 AND oie_etiqueta_interna=1";
                read = command.ExecuteReader();
                read.Read();
                if (read[0] != DBNull.Value && Convert.ToInt32(read[0])>0)
                {
                    read.Close();
                    throw new Exception("Não é possível realizar a conferência desse pedido pois existem itens customizados não recebidos");
                }
                read.Close();




                //Verifica se tem ops em aberto
                command.CommandText =
                    "SELECT  " +
                    "  COUNT(public.ordem_producao.id_ordem_producao)  " +
                    "FROM " +
                    "  public.ordem_producao_pedido " +
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_pedido.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "  INNER JOIN order_item_etiqueta ON ordem_producao_pedido.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta " +
                    "WHERE " +
                    "  (public.ordem_producao.orp_situacao = 0 OR  " +
                    "  public.ordem_producao.orp_situacao = 1 OR " +
                    "  public.ordem_producao.orp_situacao = 4 ) AND  " +
                    "  public.ordem_producao_pedido.opp_order_number LIKE '" + this.OrderNumber + "' AND " +
                    "  public.ordem_producao_pedido.opp_order_pos = " + this.OrderPos + " AND " +
                    "  order_item_etiqueta.id_cliente = " + this.idCliente;


                object tmp1 = command.ExecuteScalar();
                int opsAbertas = Convert.ToInt32(tmp1);

                if (opsAbertas > 0)
                {
                    throw new Exception("Não é possível realizar a conferência desse pedido pois ele possui ordens de produção em aberto.");
                }


                //Verifica se tem OPs que não foram geradas
                OrdemProducaoGeradorClass ordemProducao = new OrdemProducaoGeradorClass(this.Usuario, this.conn, this.tipoCalculoSemana, this.diaCalculoSemana, this.UtilizarEstoqueOP, this.iOrdemProducaoFactory);
                List<int> idsOrderItemEtiquetaPlanoCorteAvulsos;
                List<OrdemProducaoOc> listOps = ordemProducao.listarOcsParaGeracao(null, TipoItemSelecao.Todos, this.OrderNumber, this.OrderPos, idCliente,null, out idsOrderItemEtiquetaPlanoCorteAvulsos);
                if (listOps.Any(a => !a.opImpressa))
                {
                    if (ordemProducao.existeOpsGerar(listOps, idsOrderItemEtiquetaPlanoCorteAvulsos))
                    {
                        throw new Exception("Não é possível realizar a conferência desse pedido pois ele possui ordens de produção para serem geradas.");
                    }
                }



                //Carrega o cliente 
                ClienteEntidade = ClienteClass.GetEntidade(idCliente, Usuario, conn);
                

                if (!this.PermitirEntregaParcial)
                {
                    //Conferencia normal, deve conferir os subitens no total da sua quantidade

                    if (!this.VolumeUnico)
                    {
                        VolumeParcialForm form2 = new VolumeParcialForm(
                            volumesBd,
                            Convert.ToInt32(this.QtdItemPai),
                            "Pedido: " + this.OrderNumber + "/" + this.OrderPos,
                            "Cliente: " + this.Cliente,
                            "Item: " + this.CodItemPai + " - " + this.DescItemPai,
                            "Cubagem: " + cubagemM3);

                        form2.ShowDialog();

                        if (form2.abort)
                        {
                            this.Abort = true;
                            return;
                        }

                        this.Volumes = new List<Volume>(form2.volumes.Values);
                    }
                    else
                    {
                        this.Volumes = new List<Volume> {new Volume(1, this.QtdItemPai)};
                    }

                    command.CommandText = "SELECT * FROM order_item_etiqueta WHERE oie_order_number='" + this.OrderNumber + "' AND oie_order_pos= " + this.OrderPos + "  AND oie_etiqueta_interna=1 AND id_cliente = " + this.idCliente + ";";
                    read = command.ExecuteReader();

                    if (!read.HasRows)
                    {
                        read.Close();
                        //throw new Exception("A oc já foi conferida totalmente");

                    }
                    else
                    {
                        try
                        {
                            
                          


                            while (read.Read())
                            {
                                //calcula a quantidade por etiqueta
                                double qtdItens = Convert.ToDouble(read["oie_saldo_conferencia"]);

                                TipoItem tipo = (TipoItem)Enum.ToObject(typeof(TipoItem), read["oie_tipo_item"]);

                                ItemConferenciaKey key = new ItemConferenciaKey(this.OrderNumber, this.OrderPos,this.idCliente,
                                                                                read["oie_codigo_item"].ToString(),
                                                                                read["oie_codigo_cliente"].ToString(),
                                                                                read["id_produto"].ToString(),
                                                                                read["id_produto_k"].ToString(),
                                                                                read["oie_descricao"].ToString(), tipo,
                                                                                read["oie_dimensao"].ToString(),
                                                                                read["oie_var_1_nome"].ToString(),
                                                                                read["oie_var_1_valor"].ToString(),
                                                                                read["oie_var_2_nome"].ToString(),
                                                                                read["oie_var_2_valor"].ToString(),
                                                                                read["oie_var_3_nome"].ToString(),
                                                                                read["oie_var_3_valor"].ToString(),
                                                                                read["oie_var_4_nome"].ToString(),
                                                                                read["oie_var_4_valor"].ToString(),
                                                                                Convert.ToBoolean(Convert.ToInt16(read["oie_item_original_pedido"])),
                                                                                Convert.ToBoolean(Convert.ToInt16(read["oie_nota_fiscal"]))
                                                                                
                                                                                );

                                
                                if (tipo == TipoItem.Kanban)
                                {
                                    bool found = false;
                                    foreach (ItemConferencia t in this.Itens.Where(t => t.Key.Equals(key)))
                                    {
                                        
                                        t.AddItemFilho(Convert.ToInt32(read["id_order_item_etiqueta"]),
                                                       Convert.ToDouble(read["oie_quantidade"]),
                                                       Convert.ToDouble(read["oie_saldo_conferencia"]),
                                                       Convert.ToInt32(read["oie_situacao_conferencia"]),
                                                       qtdItens,
                                                       this.Usuario);
                                        found = true;
                                        break;
                                    }

                                    if (!found)
                                    {
                                        this.Itens.Add(new ItemConferencia(key, this));
                                        this.Itens[this.Itens.Count - 1].AddItemFilho(
                                            Convert.ToInt32(read["id_order_item_etiqueta"]),
                                            Convert.ToDouble(read["oie_quantidade"]),
                                            Convert.ToDouble(read["oie_saldo_conferencia"]),
                                            Convert.ToInt32(read["oie_situacao_conferencia"]),
                                            qtdItens,
                                            this.Usuario);
                                    }
                                }
                                else
                                {

                                    this.Itens.Add(new ItemConferencia(key, this));
                                    this.Itens[this.Itens.Count - 1].AddItemFilho(
                                        Convert.ToInt32(read["id_order_item_etiqueta"]),
                                        Convert.ToDouble(read["oie_quantidade"]),
                                        Convert.ToDouble(read["oie_saldo_conferencia"]),
                                        Convert.ToInt32(read["oie_situacao_conferencia"]),
                                        qtdItens,
                                        this.Usuario);

                                }


                            }
                            read.Close();
                        }
                        catch (Exception a)
                        {
                            throw new Exception("Erro ao carregar os dados dos itens da oc nº " + this.OrderNumber + "/" + this.OrderPos + ".\r\n" + a.Message);
                        }



                    }
                }
                else
                {
                    //Entrega Parcial - não confere filhos, o usuário informa a quantidade e ao ler o primeiro código daquele item a quantidade é baixada e a conferencia encerrada.

                    command.CommandText = "SELECT * FROM order_item_etiqueta WHERE oie_order_number='" + this.OrderNumber + "' AND oie_order_pos= " + this.OrderPos + " AND id_cliente = " + this.idCliente + " AND oie_etiqueta_agrupada=1;";
                    read = command.ExecuteReader();

                    if (!read.HasRows)
                    {
                        read.Close();
                        throw new Exception("A oc não possui etiqueta de expedição para ser impressa");

                    }
                    read.Read();

                    if (Convert.ToDouble(read["oie_saldo_conferencia"]) <= 0 || read["oie_situacao_conferencia"].ToString() == "2")
                    {
                        read.Close();
                        throw new Exception("A oc já foi conferida totalmente");
                    }

                    int qtdMaximaVolumes = Math.Max(Convert.ToInt32(read["oie_volumes"]), 1);

                    QuantidadeParcialForm form = new QuantidadeParcialForm(Convert.ToDouble(read["oie_saldo_conferencia"]), qtdMaximaVolumes);
                    form.ShowDialog();

                    if (form.QtdVolumes != null) volumesBd = (int)form.QtdVolumes;

                    this.QtdItemPai = Convert.ToDouble(form.QtdSelecionada);
                    //this.QtdItemPaiOriginal = Convert.ToDouble(read["oie_saldo_conferencia"]);

                    read.Close();

                    VolumeParcialForm form2 = new VolumeParcialForm(
                        volumesBd,
                        this.QtdItemPai,
                        "Pedido: " + this.OrderNumber + "/" + this.OrderPos,
                        "Cliente: " + this.Cliente,
                        "Item: " + this.CodItemPai + " - " + this.DescItemPai,
                        "Cubagem: " + cubagemM3);
                    form2.ShowDialog();

                    if (form2.abort)
                    {
                        this.Abort = true;
                        return;
                    }

                    this.Volumes = new List<Volume>(form2.volumes.Values);

                    command.CommandText = "SELECT * FROM order_item_etiqueta WHERE oie_order_number='" + this.OrderNumber + "' AND oie_order_pos= " + this.OrderPos + " AND id_cliente = " + this.idCliente + "  AND oie_etiqueta_interna=1;";
                    read = command.ExecuteReader();

                    while (read.Read())
                    {
                        //Faz a conferencia parcial dos filhos caso eles existam

                        //calcula a quantidade a conferir com base na quantidade selecionada para o pai
                        double saldoConferencia = Convert.ToDouble(read["oie_saldo_conferencia"]);
                        double qtdOriginalItem= Convert.ToDouble(read["oie_quantidade"]);
                        double razaoPai = (QtdItemPai / this.QtdItemPaiOriginal);
                        double qtdConferir = Math.Round(razaoPai*qtdOriginalItem, 5);
                        if (qtdConferir > saldoConferencia)
                        {
                            throw new ExcecaoTratada("Quantidade a conferir inválida no item filho");
                        }

                        TipoItem tipo = (TipoItem)Enum.ToObject(typeof(TipoItem), read["oie_tipo_item"]);

                        ItemConferenciaKey key = new ItemConferenciaKey(this.OrderNumber, this.OrderPos,
                                                                        this.idCliente,
                                                                        read["oie_codigo_item"].ToString(),
                                                                        read["oie_codigo_cliente"].ToString(),
                                                                        read["id_produto"].ToString(),
                                                                        read["id_produto_k"].ToString(),
                                                                        read["oie_descricao"].ToString(), tipo,
                                                                        read["oie_dimensao"].ToString(),
                                                                        read["oie_var_1_nome"].ToString(),
                                                                        read["oie_var_1_valor"].ToString(),
                                                                        read["oie_var_2_nome"].ToString(),
                                                                        read["oie_var_2_valor"].ToString(),
                                                                        read["oie_var_3_nome"].ToString(),
                                                                        read["oie_var_3_valor"].ToString(),
                                                                        read["oie_var_4_nome"].ToString(),
                                                                        read["oie_var_4_valor"].ToString(),
                                                                        Convert.ToBoolean(Convert.ToInt16(read["oie_item_original_pedido"])),
                                                                        Convert.ToBoolean(Convert.ToInt16(read["oie_nota_fiscal"]))

                            );


                        if (tipo == TipoItem.Kanban)
                        {
                            bool found = false;
                            foreach (ItemConferencia t in this.Itens.Where(t => t.Key.Equals(key)))
                            {

                                t.AddItemFilho(Convert.ToInt32(read["id_order_item_etiqueta"]),
                                               Convert.ToDouble(read["oie_quantidade"]),
                                               Convert.ToDouble(read["oie_saldo_conferencia"]),
                                               Convert.ToInt32(read["oie_situacao_conferencia"]),
                                               qtdConferir,
                                               this.Usuario);
                                found = true;
                                break;
                            }

                            if (!found)
                            {
                                this.Itens.Add(new ItemConferencia(key, this));
                                this.Itens[this.Itens.Count - 1].AddItemFilho(
                                    Convert.ToInt32(read["id_order_item_etiqueta"]),
                                    Convert.ToDouble(read["oie_quantidade"]),
                                    Convert.ToDouble(read["oie_saldo_conferencia"]),
                                    Convert.ToInt32(read["oie_situacao_conferencia"]),
                                    qtdConferir,
                                    this.Usuario);
                            }
                        }
                        else
                        {

                            this.Itens.Add(new ItemConferencia(key, this));
                            this.Itens[this.Itens.Count - 1].AddItemFilho(
                                Convert.ToInt32(read["id_order_item_etiqueta"]),
                                Convert.ToDouble(read["oie_quantidade"]),
                                Convert.ToDouble(read["oie_saldo_conferencia"]),
                                Convert.ToInt32(read["oie_situacao_conferencia"]),
                                qtdConferir,
                                this.Usuario);

                        }




                        //MessageBox.Show(null, "Esse pedido está configurado como entrega parcial, no entanto ele possui etiquetas internas que não serão conferidas.\r\nPor favor reporte essa inconsistência para o administrador do sistema.", "Conferência Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    read.Close();
                }

               

                foreach (Volume volume in Volumes)
                {
                    double pesoVolume = Math.Round(this.PesoPaiUnitario*volume.Qtd, 2);
                    if (pesoVolume < 1)
                    {
                        pesoVolume = 1;
                    }
                    volume.setPesoCubagem(pesoVolume, cubagem);
                }

            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar os dados da oc nº " + this.OrderNumber+"/"+this.OrderPos+ ".\r\n" + a.Message);
            }


        }

        

        public virtual bool ConferirItem(string barCode)
        {
            string codItem = "";
            string dimensaoItem = "";
            string numeroSequencial = "";
            int? sequencialKb = null;
            try
            {
                //Antigos
                //IK -> Item Interno Kanban: IK|COD_DO_ITEM|Dimensao
                //IC -> Item Interno Customizado: IC|ID_ORDER_NUMBER_ETIQUETA_PAI|COD_DO_ITEM|Dimensao

                //Novos
                //IK -> Item Interno Kanban: IK|ID Código de Barras
                //IK -> Item Interno Kanban: IK|ID Código de Barras|Número Sequencial
                //ICN -> Item Interno Customizado: IC|ID_ORDER_NUMBER_ETIQUETA_PAI|ID Código de Barras|numero do item sequencial

                //codItem = barCode.Trim().Replace("-", " ").Replace("\r\n", "");

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;

                barCode = barCode.Trim().Replace("-", " ").Replace("\r\n", "").Replace('}', '|');

                if (ConfiguraConexaoGad.GadAtivo)
                {
                    barCode = ConfiguraConexaoGad.ConverteCodigoBarrasGadCustomizado(barCode, Usuario, conn);
                }

                bool continuar;
                barCode = TratarBarcodeItem(barCode, out continuar);
                if (!continuar)
                {
                    return false;
                }

                string[] item = barCode.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                TipoItem tipoItem;
                double? qtdPorEtiqueta;
                switch (item[0])
                {
                    case "IK":
                        if (item.Length == 2 || item.Length == 3)
                        {


                            //Buscar Código de Barras
                            command.CommandText = "SELECT * FROM codigo_barra WHERE id_codigo_barra=" + item[1];
                            read = command.ExecuteReader();
                            if (read.HasRows)
                            {
                                read.Read();

                                codItem = read["cob_codigo_item"].ToString();
                                dimensaoItem = read["cob_dimensao"].ToString();
                                qtdPorEtiqueta = Convert.ToDouble(read["cob_qtd_por_etiqueta"]);

                                if (dimensaoItem.ToUpper() == "FIXO")
                                {
                                    dimensaoItem = "0";
                                }

                                read.Close();

                                if (item.Length == 3)
                                {
                                    if (this._sequenciaisUtilizados.ContainsKey(codItem))
                                    {
                                        if (this._sequenciaisUtilizados[codItem].Contains(Convert.ToInt32(item[2])))
                                        {
                                            throw new Exception("Essa etiqueta já foi utilizada nesse pedido.");
                                        }

                                        sequencialKb = Convert.ToInt32(item[2]);
                                    }
                                    else
                                    {
                                        sequencialKb = Convert.ToInt32(item[2]);
                                    }
                                }
                            }
                            else
                            {
                                read.Close();
                                throw new Exception("Código de identificação da etiqueta inválido. Não encontrado.");
                            }

                            tipoItem = TipoItem.Kanban;

                        }
                        else
                        {

                            throw new Exception("Quantidade de campos inválida para etiqueta do tipo IK");

                        }
                        break;
                    case "ICN":
                        if (item.Length == 4)
                        {
                            int idTemp = int.Parse(item[1]);
                            if (this.IdOrderItemEtiqueta == idTemp)
                            {
                                //codItem = item[2].Replace("G*", "G00").Replace("X*", "X00");

                                //Buscar Código de Barras
                                command.CommandText = "SELECT * FROM codigo_barra WHERE id_codigo_barra=" + item[2];
                                read = command.ExecuteReader();
                                if (read.HasRows)
                                {
                                    read.Read();

                                    codItem = read["cob_codigo_item"].ToString();
                                    numeroSequencial = item[3];
                                    qtdPorEtiqueta = Convert.ToDouble(read["cob_qtd_por_etiqueta"]);

                                    read.Close();
                                }
                                else
                                {
                                    read.Close();
                                    throw new Exception("Código de identificação da etiqueta inválido. Não encontrado.");
                                }    

                                tipoItem = TipoItem.Customizado;
                            }
                            else
                            {
                                throw new Exception("Essa etiqueta não pertence a oc sendo conferida");
                            }
                        }
                        else
                        {
                            throw new Exception("Quantidade de campos inválida para etiqueta do tipo IC");
                        }
                        break;

                    case "IC":
                        if (item.Length == 3)
                        {
                            int idTemp = int.Parse(item[1]);
                            if (this.IdOrderItemEtiqueta == idTemp)
                            {
                                codItem = item[2].Replace("G*", "G00").Replace("X*", "X00");
                                tipoItem = TipoItem.Customizado;
                                qtdPorEtiqueta = 1;
                            }
                            else
                            {
                                throw new Exception("Essa etiqueta não pertence a oc sendo conferida");
                            }
                        }
                        else
                        {
                            throw new Exception("Quantidade de campos inválida para etiqueta do tipo IC");
                        }
                        break;
                    default:
                        throw new Exception("Código de identificação da etiqueta inválido");
                }





                bool found = false;
                for (int i = 0; i < this.Itens.Count && !found; i++)
                {
                    //converter cod de conferencia
                    if (this.Itens[i].Situacao != 2 && this.Itens[i].Key.CodProduto == codItem)
                    {
                        if (tipoItem == this.Itens[i].Key.Tipo)
                        {
                            if (tipoItem == TipoItem.Kanban)
                            {
                                if (dimensaoItem == this.Itens[i].Key.Medida)
                                {
                                    if (this.Itens[i].Saldo >= qtdPorEtiqueta)
                                    {
                                        this.Itens[i].Baixa("", qtdPorEtiqueta);
                                        found = true;

                                        if (sequencialKb != null)
                                        {
                                            if (!this._sequenciaisUtilizados.ContainsKey(codItem))
                                            {
                                                this._sequenciaisUtilizados.Add(codItem, new List<int>());
                                            }

                                            this._sequenciaisUtilizados[codItem].Add((int) sequencialKb);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (this.Itens[i].IsSequencialLivre(numeroSequencial))
                                {
                                    if (this.Itens[i].Saldo >= qtdPorEtiqueta)
                                    {
                                        this.Itens[i].Baixa(numeroSequencial, qtdPorEtiqueta);
                                        found = true;
                                    }
                                    else
                                    {
                                        if (qtdPorEtiqueta == 1 && this.Itens[i].Saldo > 0 && this.Itens[i].Saldo < 1)
                                        {
                                            this.Itens[i].Baixa(numeroSequencial, this.Itens[i].Saldo);
                                            found = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (!found)
                {
                    throw new Exception("Item inválido para a oc selecionada ou sem saldo disponível");
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao baixar o item: " + codItem + ".\r\n" + a.Message);
            }

            return true;

        }

        public virtual void Salvar(out OrderItemEtiquetaConferenciaClass conferencia)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                bool ss = this.Salvar(ref command, out conferencia);

                if (ss)
                {
                    command.Transaction.Commit();
                }
                else
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    } 
                }
            }
            catch (Exception)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
        }

        public virtual bool Salvar(ref IWTPostgreNpgsqlCommand command, out OrderItemEtiquetaConferenciaClass conferencia)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Antes Validar: " + OrderNumber + "/" + OrderPos , _arquivoLogEmbalagem, true);

                if (!this.ValidarSave())
                {
                    conferencia = null;
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Validar: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);

                bool existeSituacao0 = false;
                bool existeSituacao1 = false;
                bool existeSituacao2 = false;

                if (this.QtdItemPai == this.QtdItemPaiOriginal)
                {

                    foreach (ItemConferencia item in this.Itens)
                    {
                        switch (item.Situacao)
                        {
                            case 0:
                                existeSituacao0 = true;
                                break;
                            case 1:
                                existeSituacao1 = true;
                                break;
                            case 2:
                                existeSituacao2 = true;
                                break;

                        }
                    }
                }
                else
                {
                    existeSituacao1 = true;
                }

                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Existe Situacao: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);



                //Atualiza a OC    

                if (this._permitirEntregaParcial)
                {

                    //Parcial
                    if (this.QtdItemPai == Math.Round(this.QtdItemPaiOriginal - this.QtdConferidaAnteriormente, 5))
                    {
                        this.SituacaoConferencia = 2;
                    }
                    else
                    {
                        this.SituacaoConferencia = (short) (this.QtdItemPai == 0 ? 0 : 1);
                    }
                }
                else
                {
                    if (existeSituacao1)
                    {
                        //Parcial
                        this.SituacaoConferencia = 1;

                    }
                    else
                    {
                        if (existeSituacao0)
                        {
                            this.SituacaoConferencia = (short) (existeSituacao2 ? 1 : 0);
                        }
                        else
                        {
                            //Total
                            this.SituacaoConferencia = 2;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Situação: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);

                if (this.Pallet != null)
                {
                    command.CommandText = "UPDATE order_item_etiqueta SET oie_saldo_conferencia = oie_saldo_conferencia - :oie_saldo_conferencia, oie_situacao_conferencia=" + this.SituacaoConferencia + ", oie_pallet=" + this.Pallet.Numero + " WHERE id_order_item_etiqueta=" + this.IdOrderItemEtiqueta;
                }
                else
                {
                    command.CommandText = "UPDATE order_item_etiqueta SET oie_saldo_conferencia = oie_saldo_conferencia - :oie_saldo_conferencia, oie_situacao_conferencia=" + this.SituacaoConferencia + " WHERE id_order_item_etiqueta=" + this.IdOrderItemEtiqueta;
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_saldo_conferencia", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.QtdItemPai;

                command.ExecuteNonQuery();

                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Update: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);

                if (this.SituacaoConferencia == 2)
                {
                    command.CommandText =
                        "UPDATE order_item_etiqueta SET oie_etiqueta_expedicao_impressa=1 WHERE id_order_item_etiqueta=" +
                        this.IdOrderItemEtiqueta;
                    command.ExecuteNonQuery();

                    if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Impressa: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);

                    this.baixaQuantidadesItensNaoConferidos(ref command);

                    if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois baixa itens nao conferidos: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);
                }


                //Salva a conferencia do item pai para emissão de nf

                conferencia = new OrderItemEtiquetaConferenciaClass(Usuario, command.Connection)
                {
                    OrderNumber = this.OrderNumber,
                    OrderPos = this.OrderPos,
                    CodigoItem = this.CodItemPai,
                    QuantidadeConferida = this.QtdItemPai,
                    DataConferencia = DataIndependenteClass.GetData(),
                    IdentificacaoEstacao = this.EstacaoConferencia,
                    OrderItemEtiqueta = OrderItemEtiquetaClass.GetEntidade(this.IdOrderItemEtiqueta, Usuario, command.Connection),
                    Volumes = this.QtdVolumes,
                    ConferenciaPai = true,
                    IdentificacaoUsuario = this.Usuario.Login,
                    Pallet = (Pallet != null ? (short?) this.Pallet.Numero : null),
                    PalletSequencia = (Pallet != null ? (short?) this.Pallet.Sequencia : null),
                    PesoUnitario = this.PesoPaiUnitario,
                    OrderItemEtiquetaConferenciaPai = null
                };

                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Init OrderItemConferencia: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);


                if (Volumes == null || Volumes.Count == 0)
                {
                    throw new Exception("Conferência não gerou nenhum volume, consulte a equipe IWT");
                }

                foreach (Volume volume in Volumes)
                {
                    conferencia.CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia.Add(new OrderItemEtiquetaConferenciaVolumesClass(Usuario, command.Connection)
                    {
                        NumeroVolume = volume.NumeroVolume,
                        Quantidade = volume.Qtd,
                        TotalVolumes = Volumes.Count,
                        OrderItemEtiquetaConferencia = conferencia,
                        Peso = volume.Peso,
                        Cubagem = volume.Cubagem
                    });
                }

                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Volumes: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);

                conferencia.Save(ref command);

                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Save Conferencia: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);

                foreach (ItemConferencia item in this.Itens)
                {
                    item.Save(command.Connection, conferencia.ID);
                }

                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Save Itens: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);

                if (!IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET))
                {
                    //Se não exigir conferencia de pallet já faz o como se ela tivesse sido realizada
                    ocConferenciaClass itemPallet = new ocConferenciaClass(
                        this.IdOrderItemEtiqueta,
                        this.OrderNumber,
                        this.OrderPos,
                        conferencia.ID,
                        DataIndependenteClass.GetData(),
                        this.Usuario.Login,
                        this.CodItemPai,
                        this.Pallet,
                        Environment.MachineName,
                        this.conn,
                        this.idCliente,
                        Usuario);

                    itemPallet.Save(ref command);

                    if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Save Pallet: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);
                }

                if (this.ExigeValidacaoPesoExpedicao)
                {
                    ProdutoClass produto = ProdutoBaseClass.GetEntidade(this.idProdutoPai, LoginClass.UsuarioLogado.loggedUser, this.conn);
                    produto.PesoUnitario = this.PesoPaiUnitario;
                    produto.DesabilitarJustificativaRevisaoProduto = true;
                    produto.Save(ref command);
                    produto.DesabilitarJustificativaRevisaoProduto = false;

                    if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois ExigeValidacaoPesoExpedicao: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);
                }

                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Antes Save Complementar: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);
                SalvarComplementar(ref command);
                if (!string.IsNullOrWhiteSpace(_arquivoLogEmbalagem)) LogClass.EscreverLog("Depois Save Complementar:: " + OrderNumber + "/" + OrderPos, _arquivoLogEmbalagem, true);
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao salvar as conferências dos itens.\r\n" + a.Message);
            }

            return true;
        }


        public virtual void baixaQuantidadesItensNaoConferidos(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta.oie_codigo_item, "+
                    "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                    "  public.order_item_etiqueta.id_produto, "+
                    "  public.produto_k.id_produto_k, "+
                    "  public.produto_k.prk_emite_op, "+
                    "  public.order_item_etiqueta.oie_quantidade, "+
                    "  public.produto_k.prk_utiliza_dimensao_quantidade_baixa, "+
                    "  public.produto_k.prk_dimensao "+
                    "FROM "+
                    "  public.order_item_etiqueta "+
                    "  LEFT OUTER JOIN public.produto_k ON (public.order_item_etiqueta.id_produto_k = public.produto_k.id_produto_k) "+
                    "WHERE " +
                    "  public.order_item_etiqueta.oie_order_number = '" + this.OrderNumber + "' AND  " +
                    "  public.order_item_etiqueta.oie_order_pos = " + this.OrderPos + " AND  " +
                    "  public.order_item_etiqueta.id_cliente = " + this.idCliente + " AND  " +
                    "  public.order_item_etiqueta.oie_nota_fiscal = 0 AND  " +
                    "  public.order_item_etiqueta.oie_etiqueta_interna = 0 ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while(read.Read())
                {
                    try
                    {

                        //Verifica se o item é emite OP
                        //Se ele for KB quem manda é o cadastro do KB
                        //Caso contrário utilizar cadastro de produto

                        ProdutoClass Produto = ProdutoBaseClass.GetEntidade(Convert.ToInt32(read["id_produto"]), this.Usuario, command.Connection);
                        OrderItemEtiquetaClass itemPedido = OrderItemEtiquetaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta"]), this.Usuario, command.Connection);
                        ProdutoKClass produtoK = null;
                        bool EmiteOp;
                        
                        double multiplicadorQuantidadeItemK = 1;
                        if (read["id_produto_k"] == DBNull.Value)
                        {
                            EmiteOp = Produto.EmiteOp;
                        }
                        else
                        {
                            EmiteOp = Convert.ToBoolean(Convert.ToInt16(read["prk_emite_op"]));
                            produtoK = ProdutoKClass.GetEntidade(Convert.ToInt32(read["id_produto_k"]), Usuario, conn);
                            if (Convert.ToBoolean(Convert.ToInt16(read["prk_utiliza_dimensao_quantidade_baixa"])))
                            {
                                //Utiliza a dimensão do agrupador para indicar a quantidade de itens que devem ser baixados
                                //do estoque por unidade do agrupador
                                double tmp;

                                if (double.TryParse(read["prk_dimensao"].ToString(), out  tmp))
                                {
                                    multiplicadorQuantidadeItemK = tmp;
                                }
                                else
                                {
                                    throw new Exception("O item " + read["oie_codigo_item"] + " possui um item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                                }
                            }
                        }

                        double QuantidadeItem = Convert.ToDouble(read["oie_quantidade"]);

                        if (EmiteOp)
                        {
                            //item Emite OP, baixa o item produzido
                            if (produtoK == null)
                            {
                                EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                    Produto,
                                    QuantidadeItem*-1,
                                    "Baixa de Produto Produzido na Conferência",
                                    "Pedido " + this.OrderNumber + "/" + this.OrderPos,
                                    this.Usuario, false, ref command, false);
                            }
                            else
                            {
                                EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                 produtoK,
                                 QuantidadeItem * -1,
                                 "Baixa de Produto Produzido na Conferência",
                                 "Pedido " + this.OrderNumber + "/" + this.OrderPos,
                                 this.Usuario, false, ref command);
                            }
                        }
                        else
                        {
                            //item é não emite OP, baixa os materiais ou  o produto comprado

                            //Identifica se o item é comprado

                            switch (Produto.TipoAquisicao)
                            {
                                case TipoAquisicao.Fabricado:

                                    //Verifica se existe estoque do produto acabado, se existir ele tem precedencia sobre a baixa de materiais
                                        double qtdBaixar = QuantidadeItem * multiplicadorQuantidadeItemK;
                                        if (produtoK == null)
                                        {

                                            double qtdEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(Produto, ref command);
                                            if (qtdEstoque >0)
                                            {
                                                if (qtdEstoque >= qtdBaixar)
                                                {
                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                                        Produto,
                                                        qtdBaixar*-1,
                                                        "Baixa de produto acabado na conferencia",
                                                        "Pedido " + this.OrderNumber + "/" + this.OrderPos,
                                                        this.Usuario, false, ref command, false);
                                                    qtdBaixar = 0;
                                                }
                                                else
                                                {
                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                                        Produto,
                                                        qtdEstoque*-1,
                                                        "Baixa de produto acabado na conferencia",
                                                        "Pedido " + this.OrderNumber + "/" + this.OrderPos,
                                                        this.Usuario, false, ref command, false);
                                                    qtdBaixar -= qtdEstoque;
                                                }
                                            }
                                        }
                                        else
                                        {

                                            //Item KB
                                            double qtdEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProdutoK(produtoK, ref command);
                                            if (qtdEstoque > 0)
                                            {
                                                if (qtdEstoque >= qtdBaixar)
                                                {
                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                                        produtoK,
                                                        qtdBaixar*-1,
                                                        "Baixa de produto KB na conferencia",
                                                        "Pedido " + this.OrderNumber + "/" + this.OrderPos,
                                                        this.Usuario, false, ref command);
                                                    qtdBaixar = 0;
                                                }
                                                else
                                                {
                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                                        produtoK,
                                                        qtdEstoque*-1,
                                                        "Baixa de produto KB na conferencia",
                                                        "Pedido " + this.OrderNumber + "/" + this.OrderPos,
                                                        this.Usuario, false, ref command);
                                                    qtdBaixar -= qtdEstoque;
                                                }
                                            }
                                        }


                                        if (qtdBaixar > 0)
                                        {

                                            foreach (PedidoItemConfiguradoMaterialClass mat in itemPedido.CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta)
                                            {

                                                EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoMaterial(
                                                    mat.Material,
                                                    -1*mat.QuantidadeUnidadePai*qtdBaixar,
                                                    "Baixa de Materiais na Conferência (" + itemPedido.Produto + ")",
                                                    "Pedido " + this.OrderNumber + "/" + this.OrderPos,
                                                    this.Usuario, false, ref command, false);

                                            }
                                        }
                                    break;

                                case TipoAquisicao.Comprado:
                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                        Produto,
                                        QuantidadeItem*-1,
                                        "Baixa de Produto Comprado na Conferência",
                                        "Pedido " + this.OrderNumber + "/" + this.OrderPos,
                                        this.Usuario, false, ref command, false);
                                    break;


                            }
                        }

                        command.CommandText =
                            "UPDATE order_item_etiqueta SET " +
                            "  oie_saldo_conferencia = 0, " +
                            "  oie_situacao_conferencia = 2 " +
                            "WHERE " +
                            "  id_order_item_etiqueta = :id_order_item_etiqueta";
                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = read["id_order_item_etiqueta"];
                        command.ExecuteNonQuery();

                    }

                    catch (Exception e)
                    {
                        throw new Exception("Erro ao realizar a baixa de estoque dos materiais.\r\n" + e.Message, e);
                    }


                }

                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao baixar do estoque os itens não conferidos\r\n" + e.Message, e);
            }

        }

        public virtual void SetPallet(PalletConferencia pallet)
        {
            this.Pallet = pallet;
        }

        protected virtual string TratarBarcodeItem(string barcode, out bool continuar)
        {
            continuar = true;
            return barcode;
        }

        protected virtual bool ValidarSave()
        {
            return true;
        }

        protected virtual void SalvarComplementar(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public virtual void Dispose()
        {
            
        }

        public void setCaminhoLog(string arquivoLogEmbalagem)
        {
            _arquivoLogEmbalagem = arquivoLogEmbalagem;
        }
    }
}
