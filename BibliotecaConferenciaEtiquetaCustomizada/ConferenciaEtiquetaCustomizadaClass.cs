#region Referencias

using System;
using System.Collections.Generic;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule;

#endregion

namespace ModuloConferenciaEtiquetaCustomizada
{
    internal class ConferenciaEtiquetaCustomizadaClass
    {
        internal List<EtiquetaCustomizada> aConferir;
        internal List<EtiquetaCustomizada> Conferidas;
        internal List<string> itensSemEtiqueta;
        private readonly string CNC = null;
        private readonly string PPS = null;
        private readonly string OC = null;
        private readonly IWTPostgreNpgsqlConnection _conn;


        internal ConferenciaEtiquetaCustomizadaClass(string CNC, string PPS,string OC, int? idClassificacao, IWTPostgreNpgsqlConnection conn)
        {


            this.CNC = CNC;
            this.PPS = PPS;
            this.OC = OC;
            _conn = conn;
            try
            {
                string filtroKit = "";

                if (idClassificacao.HasValue)
                {
                    filtroKit = " AND produto.id_classificacao_produto = " + idClassificacao + " ";
                }


                IWTPostgreNpgsqlCommand command = _conn.CreateCommand();
                Dictionary<string, string> listOcs = new Dictionary<string, string>();
                this.aConferir = new List<EtiquetaCustomizada>();
                this.Conferidas = new List<EtiquetaCustomizada>();
                this.itensSemEtiqueta = new List<string>();

                command.CommandText = "SELECT id_order_item_etiqueta,oie_order_number,oie_order_pos FROM order_item_etiqueta WHERE oie_nivel_item=0 AND oie_nota_fiscal=1 ORDER BY oie_order_number, oie_order_pos";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    try
                    {
                        listOcs.Add(read["oie_order_number"] + "_" + read["oie_order_pos"], read["id_order_item_etiqueta"].ToString());

                    }
                    catch (ArgumentException a)
                    {
                    }
                }
                read.Close();


                if (this.CNC != null)
                {
                    command.CommandText =
                    "SELECT " +
                    "  id_codigo_barra, " +
                    "  oie_etiqueta_interna_impressa, " +
                    "  oie_qtd_etiquetas, " +
                    "  oie_order_number, " +
                    "  oie_order_pos, " +
                    "  oie_codigo_item, " +
                    "  id_order_item_etiqueta, " +
                    "  oie_pps, " +
                    "  pek_tipo_kit, " +
                    "  public.classificacao_produto.clp_identificacao " +
                    "FROM " +
                    "  public.order_item_etiqueta " +
                    "  LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = public.pedido_kit.pek_oc) " +
                    "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_kit.pek_pos) " +
                    "  LEFT OUTER JOIN public.codigo_barra ON (public.order_item_etiqueta.oie_codigo_item = public.codigo_barra.cob_codigo_item) " +
                    "  AND (public.order_item_etiqueta.oie_dimensao = public.codigo_barra.cob_dimensao) " +
                    "  LEFT OUTER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto) " +
                    "  LEFT OUTER JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) " +
                    "WHERE " +
                    "  oie_tipo_item=1 AND " +
                    "  oie_etiqueta_interna = 1 AND " +
                    "  oie_conferencia_customizada_realizada = 0 AND " +
                    "  oie_cnc='" + this.CNC + "' " +
                    filtroKit +
                    "ORDER BY " +
                    "  oie_pps, " +
                    "  oie_order_number, " +
                    "  oie_order_pos, " +
                    "  oie_codigo_item";
                }
                else
                {
                    if (this.PPS != null)
                    {
                        command.CommandText =
                            "SELECT " +
                            "  id_codigo_barra, " +
                            "  oie_etiqueta_interna_impressa, " +
                            "  oie_qtd_etiquetas, " +
                            "  oie_order_number, " +
                            "  oie_order_pos, " +
                            "  oie_codigo_item, " +
                            "  id_order_item_etiqueta, " +
                            "  oie_pps, " +
                            "  pek_tipo_kit, " +
                            "  public.classificacao_produto.clp_identificacao " +
                            "FROM " +
                            "  public.order_item_etiqueta " +
                            "  LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = public.pedido_kit.pek_oc) " +
                            "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_kit.pek_pos) " +
                            "  LEFT OUTER JOIN public.codigo_barra ON (public.order_item_etiqueta.oie_codigo_item = public.codigo_barra.cob_codigo_item) " +
                            "  AND (public.order_item_etiqueta.oie_dimensao = public.codigo_barra.cob_dimensao) " +
                            "  LEFT OUTER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto) " +
                            "  LEFT OUTER JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) " +
                            "WHERE " +
                            "  oie_tipo_item=1 AND " +
                            "  oie_etiqueta_interna = 1 AND " +
                            "  oie_conferencia_customizada_realizada = 0 AND " +
                            "  oie_pps <= " + this.PPS + " " +
                            filtroKit +
                            "ORDER BY " +
                            "  oie_pps, " +
                            "  oie_order_number, " +
                            "  oie_order_pos, " +
                            "  oie_codigo_item";
                    }
                    else
                    {
                        if (this.OC != null)
                        {
                            command.CommandText =
                                "SELECT " +
                                "  id_codigo_barra, " +
                                "  oie_etiqueta_interna_impressa, " +
                                "  oie_qtd_etiquetas, " +
                                "  oie_order_number, " +
                                "  oie_order_pos, " +
                                "  oie_codigo_item, " +
                                "  id_order_item_etiqueta, " +
                                "  oie_pps, " +
                                "  pek_tipo_kit, " +
                                "  public.classificacao_produto.clp_identificacao " +
                                "FROM " +
                                "  public.order_item_etiqueta " +
                                "  LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = public.pedido_kit.pek_oc) " +
                                "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_kit.pek_pos) " +
                                "  LEFT OUTER JOIN public.codigo_barra ON (public.order_item_etiqueta.oie_codigo_item = public.codigo_barra.cob_codigo_item) " +
                                "  AND (public.order_item_etiqueta.oie_dimensao = public.codigo_barra.cob_dimensao) " +
                                "  LEFT OUTER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto) " +
                                "  LEFT OUTER JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) " +
                                "WHERE " +
                                "  oie_tipo_item=1 AND " +
                                "  oie_etiqueta_interna = 1 AND " +
                                "  oie_conferencia_customizada_realizada = 0 AND " +
                                "  oie_order_number LIKE '%" + this.OC + "%' " +
                                filtroKit +
                                "ORDER BY " +
                                "  oie_pps, " +
                                "  oie_order_number, " +
                                "  oie_order_pos, " +
                                "  oie_codigo_item";
                        }
                        else
                        {
                            throw new Exception("Selecione a Semana, o CNC ou a OC");
                        }
                    }
                }

                read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    if (this.PPS != null)
                    {
                        throw new Exception("USR:A semana " + this.PPS + " não possui nenhum item para ser conferido para as opções selecionadas");
                    }
                    else
                    {
                        if (this.CNC != null)
                        {
                            throw new Exception("USR:O CNC " + this.CNC + " não possui nenhum item para ser conferido para as opções selecionadas");
                        }
                        else
                        {
                            throw new Exception("USR:A OC " + this.OC + " não possui nenhum item para ser conferido para as opções selecionadas");
                        }
                    }

                }

                while (read.Read())
                {
                    if (read["id_codigo_barra"] != DBNull.Value && read["oie_etiqueta_interna_impressa"].ToString() == "1")
                    {
                        for (int i = 0; i < Convert.ToInt32(read["oie_qtd_etiquetas"]); i++)
                        {
                            this.aConferir.Add(new EtiquetaCustomizada(read["oie_codigo_item"].ToString(),
                                                                       read["oie_order_number"].ToString(),
                                                                       read["oie_order_pos"].ToString(),
                                                                       read["id_codigo_barra"].ToString(),
                                                                       listOcs[
                                                                           read["oie_order_number"] + "_" +
                                                                           read["oie_order_pos"]], (i + 1),
                                                                       Convert.ToInt32(read["oie_qtd_etiquetas"]),
                                                                       read["id_order_item_etiqueta"].ToString(),
                                                                       read["oie_pps"].ToString(),
                                                                       read["pek_tipo_kit"].ToString(),
                                                                       read["clp_identificacao"].ToString()));
                        }
                    }
                    else
                    {
                        this.itensSemEtiqueta.Add(read["oie_order_number"] + "/" + read["oie_order_pos"] + " - " + read["oie_codigo_item"]);
                    }
                }

                if (this.aConferir.Count == 0)
                {
                    throw new Exception("Nada a ser conferido para o cnc selecionado");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados.\r\n" + e.Message);
            }

        }

        internal void confereItem(string barcode)
        {
            bool found = false;

            barcode = barcode.Trim().Replace("-", " ").Replace("\r\n", "").Replace('}', '|');
            if (ConfiguraConexaoGad.GadAtivo)
            {
                barcode = ConfiguraConexaoGad.ConverteCodigoBarrasGadCustomizado(barcode, LoginClass.UsuarioLogado.loggedUser,_conn);
            }
            string[] item  = barcode.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            if (item.Length == 4)
            {
                //ICN -> Item Interno Customizado: IC|ID_ORDER_NUMBER_ETIQUETA_PAI|ID Código de Barras|numero do item sequencial
                for (int i = 0; i < this.aConferir.Count; i++)
                {
                    if (!this.aConferir[i].conferida && this.aConferir[i].idPai == item[1] && this.aConferir[i].idCodigoBarras == item[2] && this.aConferir[i].numeroSequencia.ToString() == item[3])
                    {
                        this.aConferir[i].baixarUnidade();
                        this.Conferidas.Add(this.aConferir[i]);
                        this.aConferir.RemoveAt(i);
                        found = true;
                        break;

                    }
                }

                if (!found)
                {
                    if (this.CNC != null)
                    {
                        throw new Exception("Item inválido para o CNC " + this.CNC);
                    }
                    else
                    {
                        throw new Exception("Item inválido para a semana " + this.PPS);
                    }
                }
            }
            else
            {
                throw new Exception("Código de barras inválido.");
            }

        }

        internal void Save()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = _conn.CreateCommand();
                int parcial;
                if (this.aConferir.Count == 0 && this.itensSemEtiqueta.Count == 0)
                {
                    parcial = 0;
                }
                else
                {
                    parcial = 1;
                }


                command.Transaction = command.Connection.BeginTransaction();

                command.CommandText =
                    "INSERT INTO  " +
                    "  public.conferencia_cnc " +
                    "( " +
                    "  ccn_cnc, " +
                    "  ccn_pps, " +
                    "  ccn_parcial, " +
                    "  ccn_oc " +
                    ")  " +
                    "VALUES ( " +
                    "  :ccn_cnc, " +
                    "  :ccn_pps, " +
                    "  :ccn_parcial, " +
                    "  :ccn_oc " +
                    ");";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccn_cnc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.CNC;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccn_pps", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.PPS;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccn_parcial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = parcial;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccn_oc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.OC;

                command.ExecuteNonQuery();


                foreach (EtiquetaCustomizada et in this.Conferidas)
                {
                    et.Save(ref command);
                }

                command.Transaction.Commit();

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao salvar a conferencia de etiquetas customizadas.\r\n" + e.Message);
            }
        }
    }

    internal class EtiquetaCustomizada
    {
        internal string codigoItem;
        internal string oc;
        internal string pos;
        internal string idCodigoBarras;
        internal string idPai;
        internal int numeroSequencia;
        private readonly string idOrderItemEtiqueta;
        internal bool conferida { private set; get; }
        internal string pps { private set; get; }
        internal string tipoKit { private set; get; }
        internal string Classificacao { private set; get; }
        internal int qtdEtiquetasItem { private set; get; }
        

        internal EtiquetaCustomizada(string codigoItem, string oc, string pos, string idCodigoBarras, string idPai, int numeroSequencia,int qtdEtiquetasItem, string idOrderItemEtiqueta, string pps, string tipoKit, string classificacao)
        {
            this.codigoItem = codigoItem;
            this.oc = oc;
            this.pos = pos;
            this.numeroSequencia = numeroSequencia;
            this.idCodigoBarras = idCodigoBarras;
            this.idPai = idPai;
            this.idOrderItemEtiqueta = idOrderItemEtiqueta;
            this.pps = pps;
            this.qtdEtiquetasItem = qtdEtiquetasItem;
            this.tipoKit = tipoKit;
            this.conferida = false;
            this.Classificacao = classificacao;

        }


        internal void baixarUnidade()
        {
            this.conferida = true;
        }

        new internal string ToString()
        {
            return this.oc + "/" + this.pos + " - " + this.codigoItem + "   (" + this.pps + ")   : " + this.numeroSequencia + "/" + this.qtdEtiquetasItem;
        }

        internal void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                command.CommandText = "UPDATE order_item_etiqueta SET oie_conferencia_customizada_realizada = 1 WHERE id_order_item_etiqueta = " + this.idOrderItemEtiqueta + ";";
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a conferencia de etiquetas customizadas do item " + this.codigoItem + ".\r\n" + e.Message);
            }
        }
    }
}
