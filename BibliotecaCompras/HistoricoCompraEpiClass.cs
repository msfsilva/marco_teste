#region Referencias

using System;
using System.Linq;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;

#endregion

namespace BibliotecaCompras
{
    public class HistoricoCompraEpiClass : HistoricoCompraClass
    {
        private EpiClass _epi;


        public HistoricoCompraEpiClass(int ID, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn) :
            base(ID, usuario, conn)
        {

        }

        public HistoricoCompraEpiClass(FornecedorClass fornecedor, int? idMarca, string numeroNF, 
            DateTime dataRecebimento, DateTime dataOC,
            double precoUnitario, double icmsIncluso, double ipiNaoIncluso, int idLinhaNF,
            EpiClass epi, LoteClass Lote, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn) :
            base(fornecedor, idMarca, numeroNF, dataRecebimento, dataOC, precoUnitario, icmsIncluso,
            ipiNaoIncluso,
            idLinhaNF, Lote, usuario, conn)
        {
            _epi = epi;
            
        }


        protected override void Load()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                        "SELECT  " +
                        "  idEpi, " +
                        "  id_fornecedor, " +
                        "  id_marca, " +
                        "  hce_numero_nota_entrada, " +
                        "  hce_data_oc, " +
                        "  hce_data_recebimento, " +
                        "  hce_preco_unitario, " +
                        "  hce_icm_incluso, " +
                        "  hce_ipi_nao_incluso, " +
                        "  id_nota_fiscal_entrada_linha, " +
                        "  id_lote "+
                        "FROM  " +
                        "  public.historico_compra_epi " +
                        "WHERE " +
                        "  id_historico_compra_epi = :id_historico_compra_epi ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_historico_compra_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }
                read.Read();

                this._epi = EpiClass.GetEntidade(Convert.ToInt32(read["id_epi"]), Usuario, conn);

                this.Fornecedor = FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]), Usuario, conn);
                if (read["id_marca"] != DBNull.Value)
                {
                    this.idMarca = Convert.ToInt32(read["id_marca"]);
                }
                this.numeroNF = read["hce_numero_nota_entrada"].ToString();
                this.dataOC = Convert.ToDateTime(read["hce_data_oc"]);
                this.dataRecebimento = Convert.ToDateTime(read["hce_data_recebimento"]);
                this.precoUnitario = Convert.ToDouble(read["hce_preco_unitario"]);
                this.icmsIncluso = Convert.ToDouble(read["hce_icm_incluso"]);
                this.ipiNaoIncluso = Convert.ToDouble(read["hce_ipi_nao_incluso"]);
                if (read["id_nota_fiscal_entrada_linha"] != DBNull.Value)
                {
                    this.idLinhaNF = Convert.ToInt32(read["id_nota_fiscal_entrada_linha"]);
                }

                if (read["id_lote"] != DBNull.Value)
                {
                    this.Lote = new LoteClass(Convert.ToInt32(read["id_lote"]), this.Usuario, this.conn);
                }
               

                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do histórico de epi\r\n" + e.Message, e);
            }
        }

        internal override void Salvar(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.ID == null)
                {
                    command.CommandText =
                       "INSERT INTO                       " +
                        "  public.historico_compra_epi     " +
                        "(                                 " +
                        "  id_epi,                         " +
                        "  id_fornecedor,                  " +
                        "  id_marca,                       " +
                        "  hce_numero_nota_entrada,        " +
                        "  hce_data_oc,                    " +
                        "  hce_data_recebimento,           " +
                        "  hce_preco_unitario,             " +
                        "  hce_icm_incluso,                " +
                        "  hce_ipi_nao_incluso,            " +
                        "  id_nota_fiscal_entrada_linha,   " +
                        "  id_lote                         " +
                        ")                                 " +
                        "VALUES (                          " +
                        "  :id_epi,                        " +
                        "  :id_fornecedor,                 " +
                        "  :id_marca,                      " +
                        "  :hce_numero_nota_entrada,       " +
                        "  :hce_data_oc,                   " +
                        "  :hce_data_recebimento,          " +
                        "  :hce_preco_unitario,            " +
                        "  :hce_icm_incluso,               " +
                        "  :hce_ipi_nao_incluso,           " +
                        "  :id_nota_fiscal_entrada_linha,  " +
                        "  :id_lote                        " +
                        "                                  " +
                        ") RETURNING id_historico_compra_epi;";
                }
                else
                {
                    command.CommandText =
                        "  public.historico_compra_epi                                    " +
                        "SET                                                              " +
                        "  id_epi = :id_epi,                                              " +
                        "  id_fornecedor = :id_fornecedor,                                " +
                        "  id_marca = :id_marca,                                          " +
                        "  hce_numero_nota_entrada = :hce_numero_nota_entrada,            " +
                        "  hce_data_oc = :hce_data_oc,                                    " +
                        "  hce_data_recebimento = :hce_data_recebimento,                  " +
                        "  hce_preco_unitario = :hce_preco_unitario,                      " +
                        "  hce_icm_incluso = :hce_icm_incluso,                            " +
                        "  hce_ipi_nao_incluso = :hce_ipi_nao_incluso,                    " +
                        "  id_nota_fiscal_entrada_linha = :id_nota_fiscal_entrada_linha,  " +
                        "  id_lote = :id_lote,                                            " +
                        "WHERE                                                            " +
                        "  id_historico_compra_epi = :id_historico_compra_epi             " +
                        "                                                                 " +
                        "RETURNING id_historico_compra_epi ;";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_historico_compra_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this._epi.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_marca", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idMarca;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hce_numero_nota_entrada", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.numeroNF;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hce_data_oc", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataOC;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hce_data_recebimento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataRecebimento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hce_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.precoUnitario;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hce_icm_incluso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.icmsIncluso;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hce_ipi_nao_incluso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.ipiNaoIncluso;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada_linha", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idLinhaNF;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Lote.getID();

                this.ID = Convert.ToInt32(command.ExecuteScalar());

                bool naoAtualizaPrecoRecebimento = false;

                if (this.Lote.solicitacoesCompraAtuais.Count > 0)
                {
                    naoAtualizaPrecoRecebimento =
                        this.Lote.solicitacoesCompraAtuais[0].Solicitacao.itemNaoDeveAtualizarPrecosNoRecebimento;
                }

                if (!naoAtualizaPrecoRecebimento)
                {
                    foreach (EpiFornecedorClass ef in _epi.CollectionEpiFornecedorClassEpi.Where(a => a.Fornecedor == Fornecedor))
                    {
                        ef.UltimoPreco = precoUnitario;
                        ef.DataUltimaCompra = dataRecebimento;
                        ef.Ipi = ipiNaoIncluso;
                        ef.Icms = icmsIncluso;

                        //ef.Save(ref command);
                    }
                }
                

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o histórico de Epi\r\n" + e.Message, e);
            }
        }
    }
}
