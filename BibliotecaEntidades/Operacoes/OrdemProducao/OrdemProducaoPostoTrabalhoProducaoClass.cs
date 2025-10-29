using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoPostoTrabalhoProducaoClass
    {
        public int? idOrdemProducaoPostoTrabalhoProducao { private set; get; }
        public AcsUsuarioClass Usuario { private set; get; }
        public double Quantidade { private set; get; }
        public DateTime Hora { private set; get; }
        public DateTime? HoraFim { private set; get; }

        public bool Encerrada { private set; get; }

        public OrdemProducaoPostoTrabalhoClass Parent { private set; get; }
        readonly IWTPostgreNpgsqlConnection conn;

        public List<OrdemProducaoPostoTrabalhoProducaoLoteClass> LotesMP { private set; get; }

        public bool toDelete { get; private set; }

        public OrdemProducaoPostoTrabalhoProducaoClass(int? idOrdemProducaoPostoTrabalhoProducao, AcsUsuarioClass Usuario, double Quantidade,bool Encerrada,  DateTime Hora, DateTime? HoraFim, OrdemProducaoPostoTrabalhoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.idOrdemProducaoPostoTrabalhoProducao = idOrdemProducaoPostoTrabalhoProducao;
            this.Usuario = Usuario;
            this.Quantidade = Quantidade;
            this.Hora = Hora;
            this.HoraFim = HoraFim;
            this.Encerrada = Encerrada;

            this.Parent = Parent;
            this.conn = conn;

            this.LotesMP = new List<OrdemProducaoPostoTrabalhoProducaoLoteClass>();
            if (this.idOrdemProducaoPostoTrabalhoProducao != null)
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  id_ordem_producao_posto_trabalho_producao_lote, " +
                    "  id_lote " +
                    "FROM " +
                    "  public.ordem_producao_posto_trabalho_producao_lote  " +
                    "WHERE " +
                    "  id_ordem_producao_posto_trabalho_producao = :id_ordem_producao_posto_trabalho_producao ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPostoTrabalhoProducao;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    this.LotesMP.Add(new OrdemProducaoPostoTrabalhoProducaoLoteClass(
                                         Convert.ToInt32(read["id_ordem_producao_posto_trabalho_producao_lote"]),
                                         new LoteClass(Convert.ToInt32(read["id_lote"]), this.Usuario, this.conn),
                                         this,
                                         this.conn)
                        );
                }
                read.Close();
            }
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (idOrdemProducaoPostoTrabalhoProducao != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_posto_trabalho_producao  " +
                            "WHERE  " +
                            "  id_ordem_producao_posto_trabalho_producao = :id_ordem_producao_posto_trabalho_producao " +
                            ";";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho_producao", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPostoTrabalhoProducao;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (this.idOrdemProducaoPostoTrabalhoProducao == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_posto_trabalho_producao "+
                            "( "+
                            "  id_ordem_producao_posto_trabalho, "+
                            "  id_acs_usuario, "+
                            "  opo_quantidade, "+
                            "  opo_data_hora, "+
                            "  opo_encerrada, "+
                            "  opo_data_hora_fim "+
                            ")  "+
                            "VALUES ( "+
                            "  :id_ordem_producao_posto_trabalho, "+
                            "  :id_acs_usuario, "+
                            "  :opo_quantidade, "+
                            "  :opo_data_hora, "+
                            "  :opo_encerrada, " +
                            "  :opo_data_hora_fim "+
                            ") RETURNING id_ordem_producao_posto_trabalho_producao;";

                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_posto_trabalho_producao   "+
                            "SET  "+
                            "  id_ordem_producao_posto_trabalho = :id_ordem_producao_posto_trabalho, "+
                            "  id_acs_usuario = :id_acs_usuario, "+
                            "  opo_quantidade = :opo_quantidade, "+
                            "  opo_data_hora = :opo_data_hora, "+
                            "  opo_encerrada = :opo_encerrada, "+
                            "  opo_data_hora_fim = :opo_data_hora_fim "+
                            "WHERE  "+
                            "  id_ordem_producao_posto_trabalho_producao = :id_ordem_producao_posto_trabalho_producao "+
                            "RETURNING  id_ordem_producao_posto_trabalho_producao;";
                    }


                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPostoTrabalhoProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducaoPostoTrabalho;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Usuario.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opo_quantidade", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opo_data_hora", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Hora;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opo_encerrada", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Encerrada);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opo_data_hora_fim", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = this.HoraFim;
                    
                    this.idOrdemProducaoPostoTrabalhoProducao = Convert.ToInt32(command.ExecuteScalar());


                    if (this.LotesMP != null)
                    {

                        foreach (OrdemProducaoPostoTrabalhoProducaoLoteClass lote in this.LotesMP)
                        {
                            lote.Save(ref command);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a produção no Posto de Trabalho.\r\n" + e.Message);
            }
        }

        internal void Encerrar(double Quantidade)
        {
            try
            {
                if (this.Parent.rastreamentoMP && this.Parent.Parent.rastrearMP)
                {
                    //É obrigatório o rastreamento de MP
                    if (this.LotesMP == null || this.LotesMP.Count == 0)
                    {
                        throw new Exception("Esse posto exige que seja informado ao menos um lote de material.");
                    }
                }


                this.Encerrada = true;
                this.HoraFim = Configurations.DataIndependenteClass.GetData();
                this.Quantidade = Quantidade;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao encerrar a produção.\r\n" + e.Message, e);
            }

        }

        internal void adicionarLotes(List<LoteClass> lotesMP)
        {
            try
            {
                if (lotesMP != null)
                {
                    foreach (LoteClass lt in lotesMP)
                    {
                        this.LotesMP.Add(
                            new OrdemProducaoPostoTrabalhoProducaoLoteClass(
                                null,
                                lt,
                                this,
                                this.conn)
                            );
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar os lotes de mp\r\n" + e.Message, e);
            }
        }
    }
}