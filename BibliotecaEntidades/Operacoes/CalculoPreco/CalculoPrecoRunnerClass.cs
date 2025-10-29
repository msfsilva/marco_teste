#region Referencias

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaEntidades.Operacoes.CalculoPreco
{
    public class CalculoPrecoRunnerClass
    {
        readonly IWTPostgreNpgsqlConnection conn;
        //AcsUsuarioClass Usuario;
        string logPath;
        readonly string logFileComplete;
        string oc;
        string pos;
        string idCliente;
        private bool _toStop = false;
        private bool running;
        private int SleepTimeAfterRun;
        private Semaphore geralRunning;
        private AcsUsuarioClass _usuarioAtual;

        private readonly bool _automatico;
        private readonly int _horaRodar;
        private readonly int _minutosRodar;



        public CalculoPrecoRunnerClass(IWTPostgreNpgsqlConnection conn, string logPath, ref Semaphore geralRunning, AcsUsuarioClass usuarioAtual, bool automatico, int horaRodar, int minutosRodar)
        {
            this.conn = conn;
            this.logPath = logPath;
            this.geralRunning = geralRunning;
            _usuarioAtual = usuarioAtual;
            _automatico = automatico;
            _horaRodar = horaRodar;
            _minutosRodar = minutosRodar;
            //this.Usuario = Usuario;

            this.logFileComplete = logPath + "\\LogAjustePrecos_" + Configurations.DataIndependenteClass.GetData().ToString("dd_MM_yyyy") + ".txt";
            this.SleepTimeAfterRun = 30*60*1000;


        }

        public void setInicialParameters(string oc, string pos, string idCliente)
        {
            this.oc = oc;
            this.pos = pos;
            this.idCliente = idCliente;
        }


        public void RodarUmaVez()
        {
            string sqlLog =
                     "INSERT INTO  " +
                     "  public.log_conferencia_preco " +
                     "( " +
                     "  lcp_oc, " +
                     "  lcp_pos, " +
                     "  lcp_codigo_item, " +
                     "  lcp_tipo, " +
                     "  lcp_mensagem, " +
                     "  lcp_preco_original, " +
                     "  lcp_preco_calculado, " +
                     "  lcp_log_calculo "+
                     ")  " +
                     "VALUES ( " +
                     "  :lcp_oc, " +
                     "  :lcp_pos, " +
                     "  :lcp_codigo_item, " +
                     "  :lcp_tipo, " +
                     "  :lcp_mensagem, " +
                     "  :lcp_preco_original, " +
                     "  :lcp_preco_calculado, " +
                     "  :lcp_log_calculo " +
                     "); ";



            string sqlPedido =
                "UPDATE  " +
                "  public.pedido_item   " +
                "SET  " +
                "  pei_preco_unitario = :pei_preco_unitario, " +
                "  pei_preco_total = :pei_preco_total " +
                "WHERE  " +
                "  pei_numero = :pei_numero AND  " +
                "  pei_posicao = :pei_posicao AND  " +
                "  pei_sub_linha = 0 AND " +
                "  id_cliente = :id_cliente " +
                "; ";

            string sqlTabelaPreco =
                "INSERT INTO  " +
                "  public.tabela_preco_item_variavel " +
                "( " +
                "  tpv_order_number, " +
                "  tpv_pos, " +
                "  tpv_preco, " +
                "  id_cliente " +
                ")  " +
                "VALUES ( " +
                "  :tpv_order_number, " +
                "  :tpv_pos, " +
                "  :tpv_preco, " +
                "  :id_cliente " +
                "); ";

            string sqlClause = "";
            if (this.oc != null)
            {
                sqlClause += " pei_numero LIKE '" + this.oc + "' AND pei_posicao = " + this.pos + " AND id_cliente = " + this.idCliente + " AND ";
            }


            //Busca e roda todos os pedidos pendentes que não existem na tabela de preços de itens variáveis.
            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
            command.CommandText =
                "SELECT DISTINCT " +
                "  public.pedido_item.pei_numero, " +
                "  public.pedido_item.pei_posicao, " +
                "  public.pedido_item.id_cliente, " +
                "  public.pedido_item.pei_quantidade, " +
                "  public.pedido_item.pei_preco_unitario, " +
                "  public.pedido_item.pei_preco_total, " +
                "  public.pedido_item.pei_produto_codigo_cliente " +
                "FROM " +
                "  public.pedido_item " +
                "  LEFT JOIN tabela_preco_item_variavel ON pei_numero =  tpv_order_number AND pei_posicao = tpv_pos AND pedido_item.id_cliente = tabela_preco_item_variavel.id_cliente " +
                "  WHERE  " +
                "  " + sqlClause + " " +
                "  (pei_status = 0 OR pei_status = 3) AND  " +
                "  pei_sub_linha = 0 AND " +
                "  tabela_preco_item_variavel.id_tabela_preco_item_variavel IS NULL ";

            CalculoPrecoClass calcula = new CalculoPrecoClass(this.conn,_usuarioAtual);

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                IWTPostgreNpgsqlCommand command2 = null;
                try
                {
                    command2 = this.conn.CreateCommand();

                    command2.Transaction = this.conn.BeginTransaction();


                    string avisos;

                    string log;
                    double precoCalculado = calcula.calulaPrecoPedido(read["pei_numero"].ToString(),
                                                                      read["pei_posicao"].ToString(),
                                                                      read["id_cliente"].ToString(),
                                                                      out avisos, PedidoOrcamento.Pedido,
                                                                      out log);


                    double precoPedido = Convert.ToDouble(read["pei_preco_total"]);

                    if (Math.Abs(precoCalculado) < 0.001)
                    {

                        command2.CommandText = "";
                        command2.Parameters.Clear();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_oc", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_numero"].ToString();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_pos", NpgsqlDbType.Integer));
                        command2.Parameters[command2.Parameters.Count - 1].Value = Convert.ToInt32(read["pei_posicao"]);
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_codigo_item", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_produto_codigo_cliente"].ToString();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_tipo", NpgsqlDbType.Smallint));
                        command2.Parameters[command2.Parameters.Count - 1].Value = 1;
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_mensagem", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = "Valor Calculado do Pedido Zero - Não Válido.";

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_preco_original", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = precoPedido;
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_preco_calculado", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = precoCalculado;

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_numero", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_numero"].ToString();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_posicao", NpgsqlDbType.Integer));
                        command2.Parameters[command2.Parameters.Count - 1].Value = Convert.ToInt32(read["pei_posicao"]);

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_unitario", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = precoCalculado / Convert.ToDouble(read["pei_quantidade"]);
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_total", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = precoCalculado;

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_log_calculo", NpgsqlDbType.Text));
                        command2.Parameters[command2.Parameters.Count - 1].Value = log;
                        

                        command2.CommandText = sqlLog;
                        command2.ExecuteNonQuery();


                        command2.Transaction.Commit();

                        continue;
                    }


                    command2.CommandText = "";
                    command2.Parameters.Clear();


                    if (precoPedido > (precoCalculado + 1) || precoPedido < (precoCalculado - 1))
                    {

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_oc", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_numero"].ToString();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_pos", NpgsqlDbType.Integer));
                        command2.Parameters[command2.Parameters.Count - 1].Value = Convert.ToInt32(read["pei_posicao"]);
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_codigo_item", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_produto_codigo_cliente"].ToString();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_tipo", NpgsqlDbType.Smallint));
                        command2.Parameters[command2.Parameters.Count - 1].Value = 1;
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_mensagem", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = "Valor do pedido alterado de R$ " + precoPedido.ToString("F2", CultureInfo.CurrentCulture) + " para R$ " +
                                                                                   precoCalculado.ToString("F2", CultureInfo.CurrentCulture) + ".";
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_preco_original", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = precoPedido;
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_preco_calculado", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = precoCalculado;

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_numero", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_numero"].ToString();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_posicao", NpgsqlDbType.Integer));
                        command2.Parameters[command2.Parameters.Count - 1].Value = Convert.ToInt32(read["pei_posicao"]);

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_unitario", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = precoCalculado / Convert.ToDouble(read["pei_quantidade"]);
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_total", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = precoCalculado;

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_log_calculo", NpgsqlDbType.Text));
                        command2.Parameters[command2.Parameters.Count - 1].Value = log;

                        command2.CommandText = sqlLog + sqlPedido;
                    }


                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpv_order_number", NpgsqlDbType.Varchar));
                    command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_numero"].ToString();
                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpv_pos", NpgsqlDbType.Integer));
                    command2.Parameters[command2.Parameters.Count - 1].Value = Convert.ToInt32(read["pei_posicao"]);
                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpv_preco", NpgsqlDbType.Double));
                    command2.Parameters[command2.Parameters.Count - 1].Value = precoCalculado;
                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                    command2.Parameters[command2.Parameters.Count - 1].Value = Convert.ToInt32(read["id_cliente"]);

                    command2.CommandText += sqlTabelaPreco;
                    command2.ExecuteNonQuery();


                    command2.Transaction.Commit();





                }
                catch (Exception e)
                {
                    if (command2 != null && command2.Transaction != null)
                    {
                        command2.Transaction.Rollback();


                        command2.CommandText = sqlLog;
                        command2.Parameters.Clear();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_oc", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_numero"].ToString();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_pos", NpgsqlDbType.Integer));
                        command2.Parameters[command2.Parameters.Count - 1].Value =  Convert.ToInt32(read["pei_posicao"]);
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_codigo_item", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value =  read["pei_produto_codigo_cliente"].ToString();
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_tipo", NpgsqlDbType.Smallint));
                        command2.Parameters[command2.Parameters.Count - 1].Value = 0;
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_mensagem", NpgsqlDbType.Varchar));
                        command2.Parameters[command2.Parameters.Count - 1].Value = e.Message;
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_preco_original", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = read["pei_preco_total"];
                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_preco_calculado", NpgsqlDbType.Double));
                        command2.Parameters[command2.Parameters.Count - 1].Value = null;

                        command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_log_calculo", NpgsqlDbType.Text));
                        command2.Parameters[command2.Parameters.Count - 1].Value = null;
                        command2.ExecuteNonQuery();

                    }



                }

            }

            read.Close();
            command.CommandText =
                "DELETE FROM " +
                "  public.log_conferencia_preco  " +
                "WHERE  " +
                "  lcp_data_hora < :lcp_data_hora " +
                "; ";
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_data_hora", NpgsqlDbType.Timestamp));
            command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData().Date.AddDays(-7);
            command.ExecuteNonQuery();
        }



        public void Start()
        {
            while (!_toStop)
            {
                


                try
                {

                    running = true;
                    
                    this.geralRunning?.WaitOne();

                    if (!_automatico)
                    {
                        DateTime horaAtual = DateTime.Now;
                        if (horaAtual.Hour != _horaRodar || horaAtual.Minute != _minutosRodar)
                        {
                           
                            continue;
                        }
                    }


                    this.RodarUmaVez();

                    running = false;

                }
                catch (Exception a)
                {
                    try
                    {
                        if (File.Exists(this.logFileComplete))
                        {
                            FileInfo fi = new FileInfo(this.logFileComplete);
                            if (fi.Length > 104857600)
                            {
                                fi.Delete();
                            }
                        }

                        StreamWriter logWriter = new StreamWriter(this.logFileComplete, true);
                        logWriter.WriteLine("Erro não esperado: " + a);
                        logWriter.Close();
                        if (running)
                        {
                            running = false;
                            this.geralRunning.Release();
                        }
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    this.geralRunning?.Release();

                    if (_automatico)
                    {
                        Thread.Sleep(SleepTimeAfterRun);
                    }
                    else
                    {
                        Thread.Sleep(30 * 1000);
                    }
                }

               
           
            }


        }

        public void SafeStop()
        {
            this._toStop = true;
        }

        
    }
}
