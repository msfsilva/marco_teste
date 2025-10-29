using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaAutomacoes
{
    public class VerificaVencimentoEpiRunnerClass
    {
        readonly Semaphore geralRunning;
        private readonly IWTPostgreNpgsqlConnection _conn;


        public Boolean running;
        private Boolean _toStop;
        private AcsUsuarioClass usuario;
       

        
        public VerificaVencimentoEpiRunnerClass(ref Semaphore geralRunning, IWTPostgreNpgsqlConnection conn)
        {
            this.geralRunning = geralRunning;
            _conn = conn;
            usuario =  LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID,conn,true).loggedUser;
        }

        public void Start()
        {
            while (!_toStop)
            {
                try
                {
                    running = true;
                    geralRunning?.WaitOne();

                    FuncionarioEpiClass search = new FuncionarioEpiClass(usuario, _conn);
                    List<FuncionarioEpiClass> funcionarioEpis =
                        search.Search(new List<SearchParameterClass>
                        {
                            new SearchParameterClass("EpisVencidos", DataIndependenteClass.GetData(), SearchOperacao.FiltroNormal, SearchOrdenacao.Asc, TipoOrdenacao.String)
                        }).ConvertAll(a => (FuncionarioEpiClass) a);


                    foreach (FuncionarioEpiClass funcionarioEpi in funcionarioEpis)
                    {
                        if (funcionarioEpi.Situacao == SituacaoFuncionarioEpi.Ativo || funcionarioEpi.Situacao == SituacaoFuncionarioEpi.Pendente)
                        {
                            funcionarioEpi.Situacao = SituacaoFuncionarioEpi.Vencido;
                            funcionarioEpi.Save();
                        }
                    }


                    IWTPostgreNpgsqlCommand command = _conn.CreateCommand();
                    command.CommandText =
                        "SELECT  " +
                        "  public.epi_ca.id_epi_ca " +
                        "FROM " +
                        "  public.epi_ca " +
                        "WHERE " +
                        "  (public.epi_ca.eca_validade < :hoje AND  " +
                        "  public.epi_ca.eca_vencido = 0) " +
                        "  OR  " +
                        "  (public.epi_ca.eca_validade >= :hoje AND  " +
                        "  public.epi_ca.eca_vencido = 1) ";
                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hoje", NpgsqlDbType.Date));
                    command.Parameters[command.Parameters.Count - 1].Value = DataIndependenteClass.GetData().Date;
                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        EpiCaClass ca = EpiCaClass.GetEntidade(Convert.ToInt32(read["id_epi_ca"]), usuario, _conn);
                        ca.AtualizaVencido();
                        ca.ControleRevisaoHabilitado = false;
                        ca.Save();
                        ca.ControleRevisaoHabilitado = true;
                    }
                    read.Close();

                    running = false;

                }
                catch (Exception a)
                {
                    MessageBox.Show(null, "Erro ao rodar a verificacao de vencimento de EPIs.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    geralRunning?.Release();
                }
                Thread.Sleep(3600000);

               
            }

        }

        public void SafeStop()
        {
            _toStop = true;
        }
    }
}
