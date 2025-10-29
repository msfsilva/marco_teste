using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWTDotNetLib;
using Configurations;
using IWTPostgreNpgsql;
using NpgsqlTypes;
using ProjectConstants;


namespace BibliotecaAutomacoes
{
    public class VerificaInstanciasClass
    {


        //Marco: A lógica ta pronta, mas envolve a complexidade de fazer cada thread que está rodando validar a sessão em cada loop o que não vai ser implementado agora devida a complexidade da integração com o NFe.

        private bool _toStop = false;
        readonly int _sleepTimeAfterRun = 60; //segundos
        private readonly string _logFile;

        private readonly string _connString;
        
        private string _confBase = "AUTOMA";

        public static bool SessaoValida { get; private set; } = false;

        public VerificaInstanciasClass(string connString)
        {
            _connString = connString;
            
            _logFile = AppDomain.CurrentDomain.BaseDirectory + "\\logVerificaInstancias-" + DataIndependenteClass.GetData().ToString("yyyMMdd") + ".txt";
        }


        public void Start()
        {
            while (!_toStop)
            {
                try
                {

                    IWTPostgreNpgsqlConnection conn = null;
                    try
                    {
                        conn = new IWTPostgreNpgsqlConnection(_connString);
                        conn.Open();

                        string sql = "SELECT value FROM configuration WHERE code LIKE :code";

                        IWTPostgreNpgsqlCommand command = conn.CreateCommand();

                        command.CommandText = sql;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("code", NpgsqlDbType.Varchar, _confBase));
                        IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                        if (!read.HasRows)
                        {
                            read.Close();

                            CriarNovaSessao(conn);
                            SessaoValida = true;
                        }
                        else
                        {
                            read.Read();
                            string texto = read["value"].ToString();
                            read.Close();

                            SessaoAtivaDto sessaoAtiva = SessaoAtivaDto.Parse(texto);
                            if (sessaoAtiva.DataHora.CompareTo(DataIndependenteClass.GetData().AddMinutes(-5)) < 0)
                            {
                                LimpaSessao(conn);
                                CriarNovaSessao(conn);
                                SessaoValida = true;
                            }
                            else
                            {
                                if (sessaoAtiva.NomeEstacao != Environment.MachineName)
                                {
                                    SessaoValida = false;
                                    throw new ExcecaoTratada(ErrosConstants.VERIFICA_INSTANCIAS_AUTOMACAO_OUTRA_SESSAO + Environment.NewLine + sessaoAtiva.NomeEstacao);
                                }

                                AtualizaSessao(conn, sessaoAtiva);
                                SessaoValida = true;
                            }
                        }
                    }
                    finally
                    {
                        try
                        {
                            conn?.ForceClose();
                        }
                        catch
                        {

                        }
                    }
                }
                catch (Exception a)
                {
                    SessaoValida = false;
                    MessageBox.Show(null, "Erro ao verificar a sessão." + Environment.NewLine + a.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    int segundos = _sleepTimeAfterRun;
                    while (!_toStop && segundos > 0)
                    {
                        Thread.Sleep(1000);
                        segundos--;
                    }

                    if (_toStop)
                    {
                        IWTPostgreNpgsqlConnection conn = null;
                        try
                        {
                            conn = new IWTPostgreNpgsqlConnection(_connString);
                            conn.Open();
                            LimpaSessao(conn);
                            SessaoValida = false;
                        }
                        catch
                        {

                        }
                        finally
                        {
                            conn?.ForceClose();
                        }
                    }
                }
            }

        }

        private void AtualizaSessao(IWTPostgreNpgsqlConnection conn, SessaoAtivaDto sessaoAtiva)
        {
            sessaoAtiva.DataHora = DataIndependenteClass.GetData();

            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.CommandText =
                "UPDATE " +
                "   public.configuration " +
                "SET value = :value " +
                "WHERE code LIKE :code ; ";

            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("code", NpgsqlDbType.Varchar, _confBase));
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("value", NpgsqlDbType.Varchar, CalculaStringTempo()));

            command.ExecuteNonQuery();

        }

        private void LimpaSessao(IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();

            command.CommandText = "DELETE FROM public.configuration WHERE code LIKE :code ";
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("code", NpgsqlDbType.Varchar, _confBase));

            command.ExecuteNonQuery();
        }

        private void CriarNovaSessao(IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.CommandText =
                "INSERT INTO  " +
                "public.configuration " +
                "( " +
                "    code, " +
                "    description, " +
                "    value " +
                ") " +
                "VALUES( " +
                " :code, " +
                " :description, " +
                " :value " +
                "); ";

            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("code", NpgsqlDbType.Varchar, _confBase));
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("description", NpgsqlDbType.Varchar, "Controle de sessões do Módulo de Automação"));
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("value", NpgsqlDbType.Varchar, CalculaStringTempo()));

            command.ExecuteNonQuery();
        }

        private string CalculaStringTempo()
        {
            SessaoAtivaDto dto = new SessaoAtivaDto
            {
                NomeEstacao = Environment.MachineName,
                DataHora = DataIndependenteClass.GetData()
            };

            return dto.ToString();
        }

        private class SessaoAtivaDto
        {
            public string NomeEstacao { get; set; }
            public DateTime DataHora { get; set; }


            public override string ToString()
            {
                return NomeEstacao + "|||" + DataHora.ToString(CultureInfo.InvariantCulture);
            }

            public static SessaoAtivaDto Parse(string texto)
            {
                texto = texto.Trim();

                SessaoAtivaDto toRet = new SessaoAtivaDto();

                if (!texto.Contains("|||"))
                {
                    throw new Exception(ErrosConstants.VERIFICA_INSTANCIAS_AUTOMACAO_PARSE);
                }

                toRet.NomeEstacao = texto.Substring(0, texto.IndexOf("|||"));

                DateTime dataSessao;
                if (!DateTime.TryParse(texto.Substring(texto.IndexOf("|||")), CultureInfo.InvariantCulture, DateTimeStyles.None, out dataSessao))
                {
                    throw new Exception(ErrosConstants.VERIFICA_INSTANCIAS_AUTOMACAO_PARSE);
                }

                toRet.DataHora = dataSessao;


                return toRet;
            }
        }

        public void SafeStop()
        {
            _toStop = true;
        }


    }
}
