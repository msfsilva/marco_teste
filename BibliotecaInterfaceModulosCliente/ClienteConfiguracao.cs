#region Referencias

using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaInterfaceModulosCliente
{
    public abstract class ClienteConfiguracao
    {
        readonly IWTPostgreNpgsqlConnection connection;
        public string nomeModulo { get; protected set; }
        readonly Dictionary<string, string> Configuracoes;
        
        public ClienteConfiguracao(string modulo, IWTPostgreNpgsqlConnection con)
        {
            this.nomeModulo = modulo;
            this.connection = con;
            this.Configuracoes = new Dictionary<string, string>();
            this.loadConfiguration();
        }

        private void loadConfiguration()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.connection.CreateCommand();
                command.CommandText = "SELECT * FROM configuracao_cliente WHERE coc_modulo='"+ nomeModulo +"'";                
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while(read.Read())
                {
                    /*if (read["coc_codigo"].ToString() == "01.01") //Diretorio de Entrada de Pedidos
                    {
                        this.dirEntrada = read["coc_valor"].ToString();
                    }

                    if (read["coc_codigo"].ToString() == "01.02") //Diretorio de Saida de Pedidos
                    {
                        this.dirSaida = read["coc_valor"].ToString();
                    }

                    if (read["coc_codigo"].ToString() == "02.01") //Id da operacao (CFOP)
                    {
                        this.idOperacao = Convert.ToInt32(read["coc_valor"]);
                    }
                    
                    if (read["coc_codigo"].ToString() == "03.01") //Nome padrao do arquivo de pedidos - Usado para listar o diretório
                    {
                        this.nomePadraoPedido = read["coc_valor"].ToString();
                    }

                    if (read["coc_codigo"].ToString() == "04.01") //Nome do Modulo que ira aparecer para o cliente
                    {
                        this.descricaoModulo = read["coc_valor"].ToString();
                    }*/
                    if (!this.Configuracoes.ContainsKey(read["coc_codigo"].ToString()))
                    {
                        this.Configuracoes.Add(read["coc_codigo"].ToString(), read["coc_valor"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao carregar as configurações do cliente " + this.nomeModulo + ".");
            }
        }

        public string getConf(string Codigo)
        {
            if (this.Configuracoes.ContainsKey(Codigo))
            {
                return this.Configuracoes[Codigo];
            }
            else
            {
                return null;
            }
        }

        public void saveConf(string Codigo, string Valor, string Descricao) 
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.connection.CreateCommand();
                if (this.getConf(Codigo) != null)
                {

                    command.CommandText =
                        "UPDATE  " +
                        "  public.configuracao_cliente   " +
                        "SET  " +
                        "  coc_valor = :coc_valor " +
                        "  ,coc_descricao = :coc_descricao " +
                        "WHERE " +
                        "  coc_modulo = :coc_modulo AND " +
                        "  coc_codigo = :coc_codigo " +
                        ";";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.configuracao_cliente " +
                        "( " +
                        "  coc_modulo, " +
                        "  coc_codigo, " +
                        "  coc_descricao, " +
                        "  coc_valor " +
                        ")  " +
                        "VALUES ( " +
                        "  :coc_modulo, " +
                        "  :coc_codigo, " +
                        "  :coc_descricao, " +
                        "  :coc_valor " +
                        ");";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("coc_modulo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.nomeModulo;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("coc_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Codigo;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("coc_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Valor;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("coc_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Descricao;

                command.ExecuteNonQuery();

                if (this.getConf(Codigo) != null)
                {
                    this.Configuracoes[Codigo] = Valor;
                }
                else
                {
                    this.Configuracoes.Add(Codigo, Valor);
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a configuração do Cliente.\r\n" + e.Message, e);
            }        
        }
        public abstract string getDirEntrada();
        public abstract string getDirSaida();
        public abstract string getNomePadraoPedido();
        public abstract string getDescricaoModulo();

    }


}
