#region Referencias

using System;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaExpedicao
{
    public class PalletConferencia
    {
        public int Numero { get; internal set; }
        public bool Ocupado { get; private set; }
        public bool Fechado { get; private set; }
        public bool Especial { get; private set; }
        public bool Conferido { get; private set; }
        public bool Bloqueado { get; private set; }
        public Int64 Sequencia { get; private set; }
        public AcsUsuarioClass Usuario { get; private set; }
        public bool UtilizadoMomento { get; private set; }

        IWTPostgreNpgsqlConnection conn;

        public PalletConferencia(int Numero, IWTPostgreNpgsqlConnection conn)
        {
            this.initPallet(Numero,conn);
        }

        public PalletConferencia(string barcode, IWTPostgreNpgsqlConnection conn)
        {
            string[] barcodeSplit = barcode.Replace("\r", "").Replace("\n", "").Replace('}', '|').Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            if (barcodeSplit.Length == 2 && barcodeSplit[0] == "IP")
            {
                this.initPallet(int.Parse(barcodeSplit[1]),conn);
            }
            else
            {
                throw new Exception("Código do pallet inválido");
            }
        }

        private void initPallet(int Numero, IWTPostgreNpgsqlConnection conn)
        {
            this.Numero = Numero;
            this.conn = conn;
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT * FROM pallet WHERE pal_numero=" + this.Numero.ToString();

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    this.Fechado = Convert.ToBoolean(Convert.ToInt16(read["pal_fechado"]));
                    this.Ocupado = Convert.ToBoolean(Convert.ToInt16(read["pal_ocupado"]));
                    this.Especial = Convert.ToBoolean(Convert.ToInt16(read["pal_especial"]));
                    this.Bloqueado = Convert.ToBoolean(Convert.ToInt16(read["pal_bloqueado"]));
                    this.Conferido = Convert.ToBoolean(Convert.ToInt16(read["pal_conferido"]));
                    this.UtilizadoMomento = Convert.ToBoolean(Convert.ToInt16(read["pal_utilizado_momento"]));

                    if (read["id_usuario"] != DBNull.Value)
                    {
                        this.Usuario = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_usuario"]), LoginClass.UsuarioLogado.loggedUser, conn);
                    }
                    else
                    {
                        this.Usuario = null;
                    }

                    this.Sequencia = Convert.ToInt64(read["pal_sequencia"]);
                    if (!this.Ocupado)
                    {
                        this.Sequencia++;
                    }
                    read.Close();


                }
                else
                {
                    read.Close();
                    throw new Exception("Pallet Inexistente");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do pallet.\r\n" + e.Message);
            }
        }

        public void setOcupado(bool situacao, AcsUsuarioClass usuario)
        {
            if (!this.Especial)
            {
                this.Ocupado = situacao;
                if (situacao)
                {
                    this.Usuario = usuario;
                }
            }
        }

        public void setFechado(bool situacao)
        {
            if (!this.Especial)
            {
                this.Fechado = situacao;
                if (situacao)
                {
                    this.Usuario = null;
                }
            }
        }

        public void setConferido(bool situacao)
        {
            if (!this.Especial)
            {
                this.Conferido = situacao;
            }
        }

        public void setUtilizadoMomento(bool situacao)
        {
            this.UtilizadoMomento = situacao;
        }


        public void Save()
        {

            this.Save(this.conn.CreateCommand());
        }


        public void Save(IWTPostgreNpgsqlCommand command)
        {
            if (!this.Especial)
            {
                command.CommandText = "UPDATE  " +
                                    "  public.pallet   " +
                                    "SET  " +
                                    "  pal_ocupado = :pal_ocupado, " +
                                    "  pal_fechado = :pal_fechado, " +
                                    "  pal_conferido = :pal_conferido, " +
                                    "  pal_sequencia = :pal_sequencia, " +
                                    "  pal_utilizado_momento = :pal_utilizado_momento, " +
                                    "  id_usuario = :id_usuario " +
                                    "WHERE  " +
                                    "  pal_numero = :pal_numero " +
                                    ";";
                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_ocupado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Ocupado);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_fechado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Fechado);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_conferido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Conferido);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_numero", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_sequencia", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = this.Sequencia;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (this.Usuario != null) ? this.Usuario.ID : (long?) null;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_utilizado_momento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.UtilizadoMomento);

                command.ExecuteNonQuery();
            }
        }


    }
}
