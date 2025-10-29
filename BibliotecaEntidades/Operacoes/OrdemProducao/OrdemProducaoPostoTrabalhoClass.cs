using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoPostoTrabalhoClass
    {
        public long? idOrdemProducaoPostoTrabalho { get; private set; }
        public long idPostoTrabalho { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Operacao { get; private set; }
        public bool Rastreamento { get; private set; }
        public bool rastreamentoMP { get; private set; }

        public PostoTrabalhoAcompanhamento Acompanhamento { get; private set; }
        public double tempoProducao { get; private set; }
        public double tempoSetup { get; private set; }
        public int Sequencia { get; private set; }


        public DateTime? Tempo1 { get; private set; }
        public int? idUserProgramTempo1 { get; private set; }
        public string operadorTempo1 { get; private set; }

        public DateTime? Tempo2 { get; private set; }
        public int? idUserProgramTempo2 { get; private set; }
        public string operadorTempo2 { get; private set; }

        public DateTime? Tempo3 { get; private set; }
        public int? idUserProgramTempo3 { get; private set; }
        public string operadorTempo3 { get; private set; }

        public DateTime? Tempo4 { get; private set; }
        public int? idUserProgramTempo4 { get; private set; }
        public string operadorTempo4 { get; private set; }

        public Double? qtdEntrada { get; private set; }
        public Double? qtdSaida { get; private set; }

        public int? idJustificativaQtd { get; private set; }

        public List<OrdemProducaoPostoTrabalhoProducaoClass> Producao { get; private set; }

        public double qtdProduzida
        {
            get
            {
                double toRet = 0;

                if (this.Producao != null)
                {
                    foreach (OrdemProducaoPostoTrabalhoProducaoClass producao in this.Producao)
                    {
                        toRet += producao.Quantidade;
                    }
                }

                return toRet;
            }
        }


        private readonly IWTPostgreNpgsqlConnection conn;
        public OrdemProducaoClass Parent { private set; get; }

        public bool toDelete { get; private set; }


        private PostoTrabalhoClass _postoTrabalho = null;

        public PostoTrabalhoClass PostoTrabalho
        {
            get
            {
                if (_postoTrabalho == null)
                {
                    _postoTrabalho = PostoTrabalhoClass.GetEntidade(idPostoTrabalho, LoginClass.UsuarioLogado.loggedUser, conn);
                }

                return _postoTrabalho;
            }
        }



        public OrdemProducaoPostoTrabalhoClass(long? idOrdemProducaoPostoTrabalho, long idPostoTrabalho, string Codigo, string Nome, string Operacao,
                                               bool Rastreamento, bool rastreamentoMP, PostoTrabalhoAcompanhamento Acompanhamento, double tempoProducao, double tempoSetup, int Sequencia,
                                               DateTime? Tempo1, int? idUserProgramTempo1, string operadorTempo1, DateTime? Tempo2, int? idUserProgramTempo2, string operadorTempo2,
                                               DateTime? Tempo3, int? idUserProgramTempo3, string operadorTempo3, DateTime? Tempo4, int? idUserProgramTempo4, string operadorTempo4,
                                               Double? qtdEntrada, Double? qtdSaida, int? idJustificativaQtd,
                                               OrdemProducaoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.idOrdemProducaoPostoTrabalho = idOrdemProducaoPostoTrabalho;
            this.idPostoTrabalho = idPostoTrabalho;
            this.Codigo = Codigo;
            this.Nome = Nome;
            this.Operacao = Operacao;
            this.Rastreamento = Rastreamento;
            this.rastreamentoMP = rastreamentoMP;
            this.Acompanhamento = Acompanhamento;
            this.tempoProducao = tempoProducao;
            this.tempoSetup = tempoSetup;
            this.Sequencia = Sequencia;

            this.Tempo1 = Tempo1;
            this.idUserProgramTempo1 = idUserProgramTempo1;
            this.operadorTempo1 = operadorTempo1;

            this.Tempo2 = Tempo2;
            this.idUserProgramTempo2 = idUserProgramTempo2;
            this.operadorTempo2 = operadorTempo2;

            this.Tempo3 = Tempo3;
            this.idUserProgramTempo3 = idUserProgramTempo3;
            this.operadorTempo3 = operadorTempo3;

            this.Tempo4 = Tempo4;
            this.idUserProgramTempo4 = idUserProgramTempo4;
            this.operadorTempo4 = operadorTempo4;

            this.qtdEntrada = qtdEntrada;
            this.qtdSaida = qtdSaida;

            this.idJustificativaQtd = idJustificativaQtd;

            this.conn = conn;
            this.Parent = Parent;

            this.toDelete = false;

            this.Producao = new List<OrdemProducaoPostoTrabalhoProducaoClass>();
            if (this.idOrdemProducaoPostoTrabalho != null)
            {
                this.loadProducao();
            }
        }

        private void loadProducao()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  id_ordem_producao_posto_trabalho_producao, " +
                    "  id_acs_usuario, " +
                    "  opo_data_hora, " +
                    "  opo_quantidade, " +
                    "  opo_encerrada, " +
                    "  opo_data_hora_fim " +
                    "FROM " +
                    "  public.ordem_producao_posto_trabalho_producao " +
                    "WHERE " +
                    "  id_ordem_producao_posto_trabalho = " + this.idOrdemProducaoPostoTrabalho + " ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {

                    DateTime? horaFim = null;
                    if (read["opo_data_hora_fim"] != DBNull.Value)
                    {
                        horaFim = Convert.ToDateTime(read["opo_data_hora_fim"]);
                    }

                    this.Producao.Add(
                        new OrdemProducaoPostoTrabalhoProducaoClass(
                            Convert.ToInt32(read["id_ordem_producao_posto_trabalho_producao"]),
                            AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),LoginClass.UsuarioLogado.loggedUser, this.conn),
                            Convert.ToDouble(read["opo_quantidade"]),
                            Convert.ToBoolean(Convert.ToInt16(read["opo_encerrada"])),
                            Convert.ToDateTime(read["opo_data_hora"]),
                            horaFim,
                            this, this.conn));
                }
                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a produção do posto de trabalho.\r\n" + e.Message);
            }
        }

        public void Delete()
        {
            this.toDelete = true;
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (idOrdemProducaoPostoTrabalho != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_posto_trabalho  " +
                            "WHERE  " +
                            "  id_ordem_producao_posto_trabalho = :id_ordem_producao_posto_trabalho " +
                            ";";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPostoTrabalho;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (this.idOrdemProducaoPostoTrabalho == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_posto_trabalho " +
                            "( " +
                            "  id_ordem_producao, " +
                            "  id_posto_trabalho, " +
                            "  opt_posto_codigo, " +
                            "  opt_posto_nome, " +
                            "  opt_posto_operacao, " +
                            "  opt_sequencia, " +
                            "  opt_tempo_setup, " +
                            "  opt_tempo_producao, " +
                            "  opt_operador_tempo_1, " +
                            "  id_acs_usuario_tempo_1, " +
                            "  opt_tempo1, " +
                            "  opt_tempo2, " +
                            "  opt_tempo3, " +
                            "  opt_tempo4, " +
                            "  opt_quantidade_entrada, " +
                            "  opt_quantidade_saida, " +
                            "  opt_operador_tempo_2, " +
                            "  id_acs_usuario_tempo_2, " +
                            "  opt_operador_tempo_3, " +
                            "  id_acs_usuario_tempo_3, " +
                            "  opt_operador_tempo_4, " +
                            "  id_acs_usuario_tempo_4, " +
                            "  id_motivo_alteracao_qtd_op " +
                            ")  " +
                            "VALUES ( " +
                            "  :id_ordem_producao, " +
                            "  :id_posto_trabalho, " +
                            "  :opt_posto_codigo, " +
                            "  :opt_posto_nome, " +
                            "  :opt_posto_operacao, " +
                            "  :opt_sequencia, " +
                            "  :opt_tempo_setup, " +
                            "  :opt_tempo_producao, " +
                            "  :opt_operador_tempo_1, " +
                            "  :id_acs_usuario_tempo_1, " +
                            "  :opt_tempo1, " +
                            "  :opt_tempo2, " +
                            "  :opt_tempo3, " +
                            "  :opt_tempo4, " +
                            "  :opt_quantidade_entrada, " +
                            "  :opt_quantidade_saida, " +
                            "  :opt_operador_tempo_2, " +
                            "  :id_acs_usuario_tempo_2, " +
                            "  :opt_operador_tempo_3, " +
                            "  :id_acs_usuario_tempo_3, " +
                            "  :opt_operador_tempo_4, " +
                            "  :id_acs_usuario_tempo_4, " +
                            "  :id_motivo_alteracao_qtd_op " +
                            ") RETURNING id_ordem_producao_posto_trabalho;";

                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_posto_trabalho   " +
                            "SET  " +
                            "  id_ordem_producao = :id_ordem_producao, " +
                            "  id_posto_trabalho = :id_posto_trabalho, " +
                            "  opt_posto_codigo = :opt_posto_codigo, " +
                            "  opt_posto_nome = :opt_posto_nome, " +
                            "  opt_posto_operacao = :opt_posto_operacao, " +
                            "  opt_sequencia = :opt_sequencia, " +
                            "  opt_tempo_setup = :opt_tempo_setup, " +
                            "  opt_tempo_producao = :opt_tempo_producao, " +
                            "  opt_operador_tempo_1 = :opt_operador_tempo_1, " +
                            "  id_acs_usuario_tempo_1 = :id_acs_usuario_tempo_1, " +
                            "  opt_tempo1 = :opt_tempo1, " +
                            "  opt_tempo2 = :opt_tempo2, " +
                            "  opt_tempo3 = :opt_tempo3, " +
                            "  opt_tempo4 = :opt_tempo4, " +
                            "  opt_quantidade_entrada = :opt_quantidade_entrada, " +
                            "  opt_quantidade_saida = :opt_quantidade_saida, " +
                            "  opt_operador_tempo_2 = :opt_operador_tempo_2, " +
                            "  id_acs_usuario_tempo_2 = :id_acs_usuario_tempo_2, " +
                            "  opt_operador_tempo_3 = :opt_operador_tempo_3, " +
                            "  id_acs_usuario_tempo_3 = :id_acs_usuario_tempo_3, " +
                            "  opt_operador_tempo_4 = :opt_operador_tempo_4, " +
                            "  id_acs_usuario_tempo_4 = :id_acs_usuario_tempo_4, " +
                            "  id_motivo_alteracao_qtd_op = :id_motivo_alteracao_qtd_op " +
                            "WHERE  " +
                            "  id_ordem_producao_posto_trabalho = :id_ordem_producao_posto_trabalho " +
                            "RETURNING  id_ordem_producao_posto_trabalho;";
                    }


                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPostoTrabalho;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idPostoTrabalho;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_posto_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Codigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_posto_nome", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Nome;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_posto_operacao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Operacao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_sequencia", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Sequencia;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo_setup", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.tempoSetup;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo_producao", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.tempoProducao;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_operador_tempo_1", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.operadorTempo1;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_tempo_1", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idUserProgramTempo1;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo1", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Tempo1;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo2", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Tempo2;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo3", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Tempo3;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo4", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Tempo4;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_quantidade_entrada", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.qtdEntrada;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_quantidade_saida", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.qtdSaida;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_operador_tempo_2", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.operadorTempo2;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_tempo_2", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idUserProgramTempo2;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_operador_tempo_3", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.operadorTempo3;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_tempo_3", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idUserProgramTempo3;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_operador_tempo_4", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.operadorTempo4;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_tempo_4", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idUserProgramTempo4;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_motivo_alteracao_qtd_op", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idJustificativaQtd;


                    this.idOrdemProducaoPostoTrabalho = Convert.ToInt32(command.ExecuteScalar());

                    //Salvar Producao
                    for (int i = 0; i < this.Producao.Count; i++)
                    {
                        this.Producao[i].Save(ref command);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o Posto de Trabalho.\r\n" + e.Message);
            }
        }

        public void setQtdEntrada(double qtd)
        {
            this.qtdEntrada = qtd;
        }

        public void setQtdSaida(double qtd, AcsUsuarioClass Usuario)
        {
            if (!this.existeProducaoAberta())
            {
                throw new Exception("Não existe produção aberta.");
            }

            foreach (OrdemProducaoPostoTrabalhoProducaoClass prod in this.Producao.Where(a => !a.Encerrada))
            {
                prod.Encerrar(qtd);
            }


            this.qtdSaida = this.qtdProduzida;

            if (this.qtdSaida < this.qtdEntrada)
            {
                //Justificativa de qtd Menor

                JustificarQtdMenorForm form = new JustificarQtdMenorForm(this.conn, false);
                form.ShowDialog();

                this.idJustificativaQtd = form.idJustificativa;
                this.Parent.setPendencia(true, Usuario);
            }
        }

        public void setTempo(int indiceTempo, DateTime tempo, AcsUsuarioClass Usuario, string Operador, List<LoteClass> lotesMP)
        {
            try
            {
                int idUserProgram = Convert.ToInt32(Usuario.ID);
                switch (indiceTempo)
                {
                    case 1:
                        this.idUserProgramTempo1 = idUserProgram;
                        this.Tempo1 = tempo;
                        this.operadorTempo1 = Operador;
                        break;
                    case 2:
                        this.idUserProgramTempo2 = idUserProgram;
                        this.Tempo2 = tempo;
                        this.operadorTempo2 = Operador;
                        break;
                    case 3:
                        this.idUserProgramTempo3 = idUserProgram;
                        this.Tempo3 = tempo;
                        this.operadorTempo3 = Operador;
                        break;
                    case 4:
                        this.idUserProgramTempo4 = idUserProgram;
                        this.Tempo4 = tempo;
                        this.operadorTempo4 = Operador;
                        break;
                    default:
                        throw new Exception("Indice de tempo inválido");
                        break;
                }
                if (indiceTempo == 1)
                {

                    this.abrirProducao(Usuario, lotesMP);

                }

                this.Parent.setEmProducao();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao setar o tempo.\r\n" + e.Message);
            }
        }

        public void interromperProcesso(AcsUsuarioClass usuarioAntigo, double qtdProduzida)
        {
            if (!this.existeProducaoAberta())
            {
                throw new Exception("Não existe produção aberta.");
            }

            foreach (OrdemProducaoPostoTrabalhoProducaoClass prod in this.Producao.Where(a => !a.Encerrada))
            {
                prod.Encerrar(qtdProduzida);
            }

            this.Parent.addHistorico(usuarioAntigo, Configurations.DataIndependenteClass.GetData(), "Processo interrompido no posto " + this.Codigo);
        }

        public bool existeProducaoAberta()
        {
            if (this.Producao.Where(a => !a.Encerrada).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void abrirProducao(AcsUsuarioClass Usuario, List<LoteClass> lotesMP)
        {
            try
            {
                OrdemProducaoPostoTrabalhoProducaoClass tmp =
                    new OrdemProducaoPostoTrabalhoProducaoClass(
                        null,
                        Usuario,
                        0,
                        false,
                        Configurations.DataIndependenteClass.GetData(),
                        null,
                        this,
                        this.conn);

                tmp.adicionarLotes(lotesMP);
                this.Producao.Add(tmp);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir a produção do posto.\r\n" + e.Message, e);
            }
        }
    }
}