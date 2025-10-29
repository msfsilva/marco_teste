#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

#endregion

namespace BibliotecaExpedicao
{
    public class EmbarqueClass
    {
        public List<EmbarqueItemClass> itens { get; private set; }
        public List<int> pallets { get; private set; }
        public List<long> itensAvulsos { get; private set; }

        public bool LiberadoNF { get; private set; }
        public bool NFEmitida { get; private set; }
        public bool NFAutorizada { get; private set; }
        public string usuarioLiberacao { get; private set; }
        public string idEmbarque { get; private set; }
        public string UsuarioCriacao { get; private set; }
        public DateTime? dtLiberacao { get; private set; }

        public int? idTransporte { get; internal set; }

        private List<PalletConferencia> palletSalvar;

        readonly IWTPostgreNpgsqlConnection conn;
        AcsUsuarioClass Usuario;

        public EmbarqueClass(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;

            this.LiberadoNF = false;
            this.NFEmitida = false;
            this.NFAutorizada = false;
            this.dtLiberacao = null;
            this.itens = new List<EmbarqueItemClass>();
            this.pallets = new List<int>();
            this.itensAvulsos = new List<long>();
            this.Usuario = Usuario;

            this.idTransporte = null;
            this.UsuarioCriacao = Usuario.Login;
            this.palletSalvar = new List<PalletConferencia>();
        }

        public static EmbarqueClass getEmbarqueClean(string idEmbarque, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM embarque WHERE id_embarque=" + idEmbarque;
            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

            if (read.HasRows)
            {
                EmbarqueClass toRet = new EmbarqueClass(Usuario,conn);
                read.Read();
                toRet.LiberadoNF = Convert.ToBoolean(Convert.ToInt16(read["emb_liberado_nf"]));
                toRet.NFEmitida = Convert.ToBoolean(Convert.ToInt16(read["emb_nf_emitida"]));
                toRet.NFAutorizada = Convert.ToBoolean(Convert.ToInt16(read["emb_nf_autorizada"]));
                toRet.usuarioLiberacao = read["emb_liberacao_usuario"].ToString();
                toRet.UsuarioCriacao = read["emb_usuario"].ToString();
                toRet.idEmbarque = read["id_embarque"].ToString();
                if (read["emb_liberacao_hora"] != DBNull.Value)
                {
                    toRet.dtLiberacao = Convert.ToDateTime(read["emb_liberacao_hora"]);
                }

                if (read["id_transporte"] != DBNull.Value)
                {
                    toRet.idTransporte = Convert.ToInt32(read["id_transporte"]);
                }
                
                read.Close();

                return toRet;

            }
            else
            {
                throw new Exception("Número do embarque inválido.");
            }

        }

        public static EmbarqueClass getEmbarque(string idEmbarque, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {

            try
            {
                IWTPostgreNpgsqlCommand command = conn.CreateCommand();


                EmbarqueClass toRet = getEmbarqueClean(idEmbarque, Usuario, conn);
                toRet.itens = new List<EmbarqueItemClass>();

                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos, " +
                    "  public.order_item_etiqueta_conferencia.oic_volumes, " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet, " +
                    "  public.pallet.pal_especial, " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet_data, " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario, " +
                    "  public.order_item_etiqueta_conferencia.oic_codigo_item, " +
                    "  public.order_item_etiqueta_conferencia.oic_quantidade_conferida, "+
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pai, "+
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia, "+
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_usuario " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "  INNER JOIN public.pallet ON (public.order_item_etiqueta_conferencia.oic_pallet = public.pallet.pal_numero) " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.id_embarque = :id_embarque ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_embarque", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = toRet.idEmbarque;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    bool palletEspecial = Convert.ToBoolean(Convert.ToInt16(read["pal_especial"]));


                    toRet.itens.Add(new EmbarqueItemClass(
                                        read["id_order_item_etiqueta"].ToString(),
                                        read["oic_order_number"].ToString(),
                                        read["oic_order_pos"].ToString(),
                                        Convert.ToInt32(read["oic_volumes"]),
                                        read["oic_pallet"].ToString(),
                                        palletEspecial,
                                        1,
                                        palletEspecial ? read["oic_data_conferencia"] as DateTime? : read["oic_conferencia_pallet_data"] as DateTime?,
                                        palletEspecial ? read["oic_identificacao_usuario"].ToString() : read["oic_conferencia_pallet_usuario"].ToString(),
                                        read["oic_codigo_item"].ToString(),
                                        Convert.ToDouble(read["oic_quantidade_conferida"]),
                                        Convert.ToBoolean(Convert.ToInt16(read["oic_conferencia_pai"])))
                        );
                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o embarque.\r\n" + e.Message, e);
            }

        }

        public string inserirItem(string barcode)
        {
            string[] barcodeSplit = barcode.Replace("\r", "").Replace("\n", "").Replace('}', '|').Trim().Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);

            if (barcodeSplit.Length == 2 && barcodeSplit[0] == "IP2")
            {
                return this.inserirPallet(barcodeSplit[1], false);
            }
            else
            {
                if (barcodeSplit.Length == 2 && barcodeSplit[0] == "IP")
                {
                    if (IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET))
                    {
                        throw new Exception("Não é possível fazer o embarque de um pallet com o código de barras do pallet, o relatório de conferência do mesmo deve ser utilizado.");
                    }

                    return this.inserirPallet(barcodeSplit[1], true);

                }
                else
                {
                    int totalVolumes;
                    int volume;
                    string orderPos;
                    string orderNumber;
                    int? idOrderItemEtiqueta;

                    if (barcode.StartsWith("EXCV_"))
                    {
                        int idVolume;
                        if (!int.TryParse(barcode.Substring(5), out idVolume))
                        {
                            throw new Exception("Código de barras inválido para oc volume.");
                        }


                        OrderItemEtiquetaConferenciaVolumesClass volumeConferencia = OrderItemEtiquetaConferenciaVolumesClass.GetEntidade(idVolume, Usuario, conn);
                        return inserirOCConferencia(volumeConferencia.OrderItemEtiquetaConferencia);
                    }
                    else
                    {
                        if (barcode.StartsWith("EX_"))
                        {
                            string[] tmp = barcode.Remove(0, 3).Split(new string[] {"_"}, StringSplitOptions.RemoveEmptyEntries);
                            if (tmp.Length == 3)
                            {
                                idOrderItemEtiqueta = int.Parse(tmp[0]);
                                volume = int.Parse(tmp[1]);
                                totalVolumes = int.Parse(tmp[2]);

                                return inserirOC(idOrderItemEtiqueta, null, null, totalVolumes);
                            }
                            else
                            {
                                throw new Exception("Código de barras inválido para oc.");
                            }
                        }
                        else
                        {

                            barcode = barcode.Replace("\r", "").Replace("\n", "").Trim();
                            if (barcode.Length >= 9 && barcode[0] == 'K')
                            {
                                totalVolumes = int.Parse(barcode.Substring(barcode.Length - 2, 2));
                                volume = int.Parse(barcode.Substring(barcode.Length - 4, 2));
                                orderPos = int.Parse(barcode.Substring(barcode.Length - 7, 3)).ToString();
                                orderNumber = barcode.Substring(1, barcode.Length - 8).Replace(';', ' ');

                                return this.inserirOC(null, orderNumber, orderPos, totalVolumes);
                            }
                            else
                            {
                                throw new Exception("Código de barras inválido para volume ou Pallet.");
                            }
                        }
                    }
                }
            }
        }

        private string inserirOCConferencia(OrderItemEtiquetaConferenciaClass conferencia)
        {

            IWTPostgreNpgsqlCommand command = null;
            IWTPostgreNpgsqlDataReader read = null;
            try
            {
                command = this.conn.CreateCommand();



                if (this.itensAvulsos.Contains(conferencia.ID))
                {
                    throw new Exception("A conferencia de número" + conferencia.ID + " já foi inserida nesse embarque");
                }
              


                command.CommandText =
                    "SELECT id_order_item_etiqueta_conferencia, " +
                    "       pal_especial, " +
                    "       pal_numero, " +
                    "       oic_data_conferencia, " +
                    "       oic_identificacao_usuario, " +
                    "       oic_codigo_item, " +
                    "       oie_status_pedido, " +
                    "       oic_quantidade_conferida, " +
                    "       oic_conferencia_pai " +
                    "FROM (order_item_etiqueta_conferencia " +
                    "     JOIN order_item_etiqueta ON order_item_etiqueta.id_order_item_etiqueta = " +
                    "      order_item_etiqueta_conferencia.id_order_item_etiqueta) " +
                    "     JOIN pallet ON pal_numero = oic_pallet " +
                    "WHERE order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia = " + conferencia.ID + " AND " +
                    "      oic_nf_emitida = 0 AND " +
                    "      id_embarque IS NULL";

                read = command.ExecuteReader();

                if (read.HasRows)
                {
                    int qtdInserida = 0;
                    while (read.Read())
                    {
                        if (Convert.ToBoolean(Convert.ToInt16(read["pal_especial"])))
                        {
                            if (read["oie_status_pedido"].ToString() != "P" && read["oie_status_pedido"].ToString() != "R")
                            {
                                throw new Exception("Não é possível incluir este pedido (" + read["oic_order_number"] + "/" + read["oic_order_pos"] + ") poie ele não está em um status válido. Status atual: " + read["oie_status_pedido"] + "\r\nConsulte o administrador do sistema.");
                            }

                            qtdInserida++;
                            this.itens.Add(new EmbarqueItemClass(
                                               read["id_order_item_etiqueta_conferencia"].ToString(),
                                               conferencia.OrderNumber,
                                               conferencia.OrderPos.ToString(),
                                               conferencia.Volumes??0,
                                               read["pal_numero"].ToString(),
                                               true,
                                               qtdInserida,
                                               Convert.ToDateTime(read["oic_data_conferencia"]),
                                               read["oic_identificacao_usuario"].ToString(),
                                               read["oic_codigo_item"].ToString(),
                                               Convert.ToDouble(read["oic_quantidade_conferida"]),
                                               Convert.ToBoolean(Convert.ToInt16(read["oic_conferencia_pai"]))
                                               ));

                            this.itensAvulsos.Add(conferencia.ID);

                        }
                        else
                        {
                            throw new Exception("A OC selecionada não faz parte de um pallet especial.");
                        }
                    }
                    if (qtdInserida > 1)
                    {
                        return "Existem etiquetas emitidas iguais a selecionada, todas foram incluídas no embarque.";
                    }
                }
                else
                {
                    throw new Exception("A OC não possui itens conferidos que não façam parte de embarques anteriores.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return "";
            
        }

        private string inserirOC(int? idOrderItemEtiqueta, string orderNumber, string orderPos,  int totalVolumes)
        {
            //Só insere OC de pallets especiais e não inserida em pallet ainda

          


            IWTPostgreNpgsqlCommand command = null;
            IWTPostgreNpgsqlDataReader read = null;
            try
            {
                command = this.conn.CreateCommand();

                if (!idOrderItemEtiqueta.HasValue)
                {
                    command.CommandText = "SELECT id_order_item_etiqueta FROM order_item_etiqueta WHERE oie_order_number = '" + orderNumber + "' AND oie_order_pos = " + orderPos + " AND oie_etiqueta_agrupada = 1";
                    idOrderItemEtiqueta = command.ExecuteScalar() as int?;
                    if (!idOrderItemEtiqueta.HasValue)
                    {
                        throw new Exception("Não foi possível identificar o id do pedido");
                    }
                }
                else
                {
                    command.CommandText = "SELECT oie_order_number,oie_order_pos  FROM order_item_etiqueta WHERE id_order_item_etiqueta = " + idOrderItemEtiqueta + "";
                    read = command.ExecuteReader();

                    if (!read.HasRows)
                    {
                        throw new Exception("Não foi possível identificar o id do pedido");
                    }
                    read.Read();
                    orderNumber = read["oie_order_number"].ToString();
                    orderPos = read["oie_order_pos"].ToString();

                    read.Close();

                }



                if (this.itensAvulsos.Contains(idOrderItemEtiqueta.Value))
                {
                    throw new Exception("A oc de número " + orderNumber + "_" + orderPos + " já foi inserida nesse embarque");
                }
                else
                {
                    this.itensAvulsos.Add(idOrderItemEtiqueta.Value);
                }


                command.CommandText =
                    "SELECT id_order_item_etiqueta_conferencia, " +
                    "       pal_especial, " +
                    "       pal_numero, " +
                    "       oic_data_conferencia, " +
                    "       oic_identificacao_usuario, " +
                    "       oic_codigo_item, " +
                    "       oie_status_pedido, " +
                    "       oic_quantidade_conferida, " +
                    "       oic_conferencia_pai " +
                    "FROM (order_item_etiqueta_conferencia " +
                    "     JOIN order_item_etiqueta ON order_item_etiqueta.id_order_item_etiqueta = " +
                    "      order_item_etiqueta_conferencia.id_order_item_etiqueta) " +
                    "     JOIN pallet ON pal_numero = oic_pallet " +
                    "WHERE order_item_etiqueta_conferencia.id_order_item_etiqueta = " + idOrderItemEtiqueta + " AND " +
                    "      oic_nf_emitida = 0 AND " +
                    "      id_embarque IS NULL";

                read = command.ExecuteReader();

                if (read.HasRows)
                {
                    int qtdInserida = 0;
                    while (read.Read())
                    {
                        if (Convert.ToBoolean(Convert.ToInt16(read["pal_especial"])))
                        {
                            if (read["oie_status_pedido"].ToString() != "P" && read["oie_status_pedido"].ToString() != "R")
                            {
                                throw new Exception("Não é possível incluir este pedido (" + read["oic_order_number"] + "/" + read["oic_order_pos"] + ") poie ele não está em um status válido. Status atual: " + read["oie_status_pedido"] + "\r\nConsulte o administrador do sistema.");
                            }

                            qtdInserida++;
                            this.itens.Add(new EmbarqueItemClass(
                                               read["id_order_item_etiqueta_conferencia"].ToString(),
                                               orderNumber,
                                               orderPos,
                                               totalVolumes,
                                               read["pal_numero"].ToString(),
                                               true,
                                               qtdInserida,
                                               Convert.ToDateTime(read["oic_data_conferencia"]),
                                               read["oic_identificacao_usuario"].ToString(), 
                                               read["oic_codigo_item"].ToString(),
                                               Convert.ToDouble(read["oic_quantidade_conferida"]),
                                               Convert.ToBoolean(Convert.ToInt16(read["oic_conferencia_pai"]))
                                               ));

                        }
                        else
                        {
                            throw new Exception("A OC selecionada não faz parte de um pallet especial.");
                        }
                    }
                    if (qtdInserida > 1)
                    {
                        return "Existem etiquetas emitidas iguais a selecionada, todas foram incluídas no embarque.";
                    }
                }
                else
                {
                    throw new Exception("A OC não possui itens conferidos que não façam parte de embarques anteriores.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return "";

        }

        private string inserirPallet(string numPallet, bool ignorarConferenciaPallet)
        {
            IWTPostgreNpgsqlCommand command = null;
            IWTPostgreNpgsqlDataReader read = null;
            try
            {
                if (this.pallets.Contains(int.Parse(numPallet)))
                {
                    throw new Exception("O pallet de número " + numPallet + " já foi inserido nesse embarque");
                }
                else
                {
                    this.pallets.Add(int.Parse(numPallet));
                    if (ignorarConferenciaPallet)
                    {
                        PalletConferencia tmp = new PalletConferencia(int.Parse(numPallet), this.conn);
                        tmp.setConferido(true);
                        this.palletSalvar.Add(tmp);
                    }
                }

                command = this.conn.CreateCommand();
                command.CommandText = "SELECT id_order_item_etiqueta_conferencia,pal_especial,pal_numero, pal_especial,pal_conferido,oic_order_number,oic_order_pos,oic_volumes,oic_conferencia_pallet_data,oic_conferencia_pallet_usuario,oic_codigo_item, oie_status_pedido,oic_quantidade_conferida, oic_conferencia_pai FROM (order_item_etiqueta_conferencia JOIN order_item_etiqueta ON order_item_etiqueta.id_order_item_etiqueta = order_item_etiqueta_conferencia.id_order_item_etiqueta) JOIN pallet ON pal_numero = oic_pallet WHERE oic_pallet=" + numPallet + " AND oic_nf_emitida = 0 AND id_embarque IS NULL";
                read = command.ExecuteReader();

                if (read.HasRows)
                {
                    read.Read();
                    if (!Convert.ToBoolean(Convert.ToInt16(read["pal_especial"])))
                    {
                        if (ignorarConferenciaPallet || Convert.ToBoolean(Convert.ToInt16(read["pal_conferido"])))
                        {

                            do
                            {
                                if (read["oie_status_pedido"].ToString() != "P" && read["oie_status_pedido"].ToString() != "R")
                                {
                                    throw new Exception("Não é possível incluir este pallet pois o pedido " + read["oic_order_number"] + "/" + read["oic_order_pos"] + " não está em um status válido. Status atual: " + read["oie_status_pedido"] +
                                                        "\r\nConsulte o administrador do sistema.");
                                }
                            } while (read.Read());

                            read.Close();

                            read = command.ExecuteReader();
                            read.Read();
                            do
                            {

                                if (read["oic_conferencia_pallet_data"] == DBNull.Value)
                                {
                                    this.itens.Add(new EmbarqueItemClass(
                                                       read["id_order_item_etiqueta_conferencia"].ToString(),
                                                       read["oic_order_number"].ToString(),
                                                       read["oic_order_pos"].ToString(),
                                                       Convert.ToInt32(read["oic_volumes"]),
                                                       read["pal_numero"].ToString(),
                                                       false,
                                                       0,
                                                       null,
                                                       read["oic_conferencia_pallet_usuario"].ToString(),
                                                       read["oic_codigo_item"].ToString(),
                                                       Convert.ToDouble(read["oic_quantidade_conferida"]),
                                                       Convert.ToBoolean(Convert.ToInt16(read["oic_conferencia_pai"])
                                                           )));
                                }
                                else
                                {
                                    this.itens.Add(new EmbarqueItemClass(
                                                       read["id_order_item_etiqueta_conferencia"].ToString(),
                                                       read["oic_order_number"].ToString(),
                                                       read["oic_order_pos"].ToString(),
                                                       Convert.ToInt32(read["oic_volumes"]),
                                                       read["pal_numero"].ToString(),
                                                       false,
                                                       0,
                                                       Convert.ToDateTime(read["oic_conferencia_pallet_data"]),
                                                       read["oic_conferencia_pallet_usuario"].ToString(),
                                                       read["oic_codigo_item"].ToString(),
                                                       Convert.ToDouble(read["oic_quantidade_conferida"]),
                                                       Convert.ToBoolean(Convert.ToInt16(read["oic_conferencia_pai"]))
                                                       ));
                                }

                            } while (read.Read());
                        }
                        else
                        {
                            throw new Exception("O pallet deve estar conferido para ser inserido em um embarque.");
                        }
                    }
                    else
                    {
                        throw new Exception("Não é possível inserir um pallet especial no embarque. Você deve inserir as ocs diretamente");
                    }
                }
                else
                {
                    throw new Exception("Não existem itens nesse pallet.");
                }
            }
            
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }

            return "";
        }

        public void liberarEmbarque(AcsUsuarioClass usuarioLiberacao)
        {
            this.usuarioLiberacao = usuarioLiberacao.Login;
            this.LiberadoNF = true;
        }

        public void Save()
        {
            IWTPostgreNpgsqlCommand command = null;
            IWTPostgreNpgsqlDataReader read = null;
            try
            {

                if (this.idEmbarque!= null && this.idEmbarque.Length>0)
                {
                    command = this.conn.CreateCommand();
                    command.Transaction = this.conn.BeginTransaction();

                    command.CommandText =
                        "UPDATE  " +
                        "  public.embarque   " +
                        "SET  " +
                        "  emb_liberado_nf = :emb_liberado_nf, " +
                        "  emb_nf_emitida = :emb_nf_emitida, " +
                        "  emb_liberacao_hora = :emb_liberacao_hora, " +
                        "  emb_liberacao_usuario = :emb_liberacao_usuario, " +
                        "  id_transporte = :id_transporte, "+
                        "  emb_nf_autorizada = :emb_nf_autorizada "+
                        "WHERE  " +
                        "  id_embarque = :id_embarque " +
                        ";";

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_embarque", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt32(this.idEmbarque);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberado_nf", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.LiberadoNF);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_nf_emitida", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.NFEmitida);

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_transporte", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idTransporte;
                 
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberacao_hora", NpgsqlDbType.Timestamp));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberacao_usuario", NpgsqlDbType.Varchar));

                    if (this.LiberadoNF)
                    {
                        command.Parameters[command.Parameters.Count - 2].Value = Configurations.DataIndependenteClass.GetData();
                        command.Parameters[command.Parameters.Count - 1].Value = this.usuarioLiberacao;
                    }
                    else
                    {
                        command.Parameters[command.Parameters.Count - 2].Value = null;
                        command.Parameters[command.Parameters.Count - 1].Value = null;
                    }

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_nf_autorizada", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.NFAutorizada);

                    command.ExecuteNonQuery();

                    if (palletSalvar != null)
                    {
                        foreach (PalletConferencia pallet in palletSalvar)
                        {
                            pallet.Save(command);
                        }
                    }
                    command.Transaction.Commit();
                }
                else
                {

                    if (this.itens.Count > 0)
                    {
                        command = this.conn.CreateCommand();
                       command.Transaction = this.conn.BeginTransaction();

                        command.CommandText = "INSERT INTO  " +
                        "  public.embarque " +
                        "( " +
                        "  emb_liberado_nf, " +
                        "  emb_nf_emitida, " +
                        "  emb_liberacao_hora, " +
                        "  emb_liberacao_usuario, " +
                        "  emb_usuario, " +
                        "  emb_data_hora,  " +
                        "  id_transporte,  " +
                        "  emb_nf_autorizada "+
                        ")  " +
                        "VALUES ( " +
                        "  :emb_liberado_nf, " +
                        "  :emb_nf_emitida, " +
                        "  :emb_liberacao_hora, " +
                        "  :emb_liberacao_usuario, " +
                        "  :emb_usuario, " +
                        "  :emb_data_hora,  " +
                        "  :id_transporte, " +
                        "  :emb_nf_autorizada " +
                        ");";


                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberado_nf", NpgsqlDbType.Smallint));
                        command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.LiberadoNF);
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_nf_emitida", NpgsqlDbType.Smallint));
                        command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.NFEmitida);

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_usuario", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = this.UsuarioCriacao;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_data_hora", NpgsqlDbType.Timestamp));
                        command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_transporte", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idTransporte;


                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberacao_hora", NpgsqlDbType.Timestamp));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_liberacao_usuario", NpgsqlDbType.Varchar));

                        if (this.LiberadoNF)
                        {
                            command.Parameters[command.Parameters.Count - 2].Value = Configurations.DataIndependenteClass.GetData();
                            command.Parameters[command.Parameters.Count - 1].Value = this.usuarioLiberacao;
                        }
                        else
                        {
                            command.Parameters[command.Parameters.Count - 2].Value = null;
                            command.Parameters[command.Parameters.Count - 1].Value = null;
                        }

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_nf_autorizada", NpgsqlDbType.Smallint));
                        command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.NFAutorizada);

                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT currval('embarque_id_embarque_seq') ";
                        read = command.ExecuteReader();

                        read.Read();
                        this.idEmbarque = read[0].ToString();

                        read.Close();

                        foreach (EmbarqueItemClass item in this.itens)
                        {
                            item.Save(ref command, this.idEmbarque);
                        }

                        if (palletSalvar != null)
                        {
                            foreach (PalletConferencia pallet in palletSalvar)
                            {
                                pallet.Save(command);
                            }
                        }

                       command.Transaction.Commit();
                    }
                    else
                    {
                        throw new Exception("Não existem itens para serem salvos nesse embarque.");
                    }
                }

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction!=null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao salvar o embarque.\r\n" + e.Message);
            }
        }

        public static int getNumeroUltimoEmbarque()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText = "SELECT max(id_embarque) FROM embarque ";
                int? tmp =command.ExecuteScalar() as int?;
                return tmp.HasValue ? tmp.Value : -1;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o último embarque.\r\n" + e.Message, e);
            }
        }

     

        public static void DesmontarEmbarque(int idEmbarque)
        {

            IWTPostgreNpgsqlCommand command = null;
            try
            {


                //Verifica se existe nota emitida
                EmbarqueClass tmp = getEmbarqueClean(idEmbarque.ToString(), LoginClass.UsuarioLogado.loggedUser, DbConnection.Connection);
                if (tmp.NFEmitida)
                {
                    throw new Exception("O embarque não pode ser deletado pois possui nota emitida.");
                }

                command = DbConnection.Connection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                command.CommandText = "UPDATE order_item_etiqueta_conferencia SET id_embarque= NULL WHERE id_embarque = " + idEmbarque + "; ";
                command.CommandText += "DELETE FROM embarque WHERE id_embarque=" + idEmbarque;

                command.ExecuteNonQuery();


                command.Transaction.Commit();

            }
            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro inesperado ao desmontar o embarque.\r\n" + e.Message, e);
            }
        }
    }

    public class EmbarqueItemClass
    {
        private readonly string idOrderItemEtiqueta;
        public string OC { private set; get; }
        public string pos { private set; get; }
        private readonly int totalVolumes;
        public string numPallet { private set; get; }
        public bool palletEspecial { private set; get; }
        public DateTime? DataConferencia { private set; get; }
        public string Conferidor { private set; get; }
        private readonly int contador;
        public double Quantidade { get; private set; }
        public bool ConferenciaPai { get; set; }
        public string codItem { private set; get; }

        public EmbarqueItemClass(string idOrderItemEtiqueta, string OC, string pos, int totalVolumes, string numPallet, bool palletEspecial, int contador, DateTime? dataConferencia, string conferidor, string codItem, double quantidade, bool conferenciaPai)
        {
            this.idOrderItemEtiqueta = idOrderItemEtiqueta;
            this.OC = OC;
            this.pos = pos;
            this.totalVolumes = totalVolumes;
            this.numPallet = numPallet;
            this.palletEspecial = palletEspecial;
            this.contador = contador;
            Quantidade = quantidade;
            ConferenciaPai = conferenciaPai;
            DataConferencia = dataConferencia;
            Conferidor = conferidor;
            this.codItem = codItem;
        }

        internal void Save(ref IWTPostgreNpgsqlCommand command, string idEmbarque)
        {
            try
            {
                command.CommandText = "UPDATE order_item_etiqueta_conferencia SET id_embarque=" + idEmbarque + " WHERE id_order_item_etiqueta_conferencia=" + this.idOrderItemEtiqueta + "; ";
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o item do embarque.\r\n" + e.Message);
            }
        }

        public override string ToString()
        {
            string toRet = this.OC + "/" + this.pos + " - " + this.codItem + " - Volumes: " + this.totalVolumes + " - Pallet: " + this.numPallet + " - Qtd: "+this.Quantidade.ToString("F4",CultureInfo.CurrentCulture);
            if (this.contador > 1)
            {
                toRet += " - VOLUME REPETIDO";
            }
            return toRet;
        }
    }
}
