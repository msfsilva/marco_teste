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
    public class HistoricoCompraProdutoClass : HistoricoCompraClass
    {
        private ProdutoClass _produto;
        

        public HistoricoCompraProdutoClass(int ID, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn) :
            base(ID, usuario, conn)
        {

        }

        public HistoricoCompraProdutoClass(FornecedorClass fornecedor, int? idMarca, string numeroNF,
            DateTime dataRecebimento, DateTime dataOC,
            double precoUnitario, double icmsIncluso, double ipiNaoIncluso, int idLinhaNF,
            ProdutoClass produto, LoteClass Lote, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn) :
            base(fornecedor, idMarca, numeroNF, dataRecebimento, dataOC, precoUnitario, icmsIncluso, ipiNaoIncluso,
            idLinhaNF, Lote, usuario, conn)
        {
            _produto = produto;
        }


        protected override void Load()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                        "SELECT  " +
                        "  id_produto, " +
                        "  id_fornecedor, " +
                        "  id_marca, " +
                        "  hcp_numero_nota_entrada, " +
                        "  hcp_data_oc, " +
                        "  hcp_data_recebimento, " +
                        "  hcp_preco_unitario, " +
                        "  hcp_icm_incluso, " +
                        "  hcp_ipi_nao_incluso, " +
                        "  id_nota_fiscal_entrada_linha, " +
                        "  id_lote " +
                        "FROM  " +
                        "  public.historico_compra_produto " +
                        "WHERE " +
                        "  id_historico_compra_produto = :id_historico_compra_produto ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_historico_compra_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }
                read.Read();

                this._produto = ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]), Usuario, conn);
                this.Fornecedor = FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]), Usuario, conn);
                if (read["id_marca"] != DBNull.Value)
                {
                    this.idMarca = Convert.ToInt32(read["id_marca"]);
                }
                this.numeroNF = read["hcp_numero_nota_entrada"].ToString();
                this.dataOC = Convert.ToDateTime(read["hcp_data_oc"]);
                this.dataRecebimento = Convert.ToDateTime(read["hcp_data_recebimento"]);
                this.precoUnitario = Convert.ToDouble(read["hcp_preco_unitario"]);
                this.icmsIncluso = Convert.ToDouble(read["hcp_icm_incluso"]);
                this.ipiNaoIncluso = Convert.ToDouble(read["hcp_ipi_nao_incluso"]);
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
                throw new Exception("Erro ao carregar os dados do histórico de produto\r\n" + e.Message, e);
            }
        }

        internal override void Salvar(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.ID == null)
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.historico_compra_produto " +
                        "( " +
                        "  id_produto, " +
                        "  id_fornecedor, " +
                        "  id_marca, " +
                        "  hcp_numero_nota_entrada, " +
                        "  hcp_data_oc, " +
                        "  hcp_data_recebimento, " +
                        "  hcp_preco_unitario, " +
                        "  hcp_icm_incluso, " +
                        "  hcp_ipi_nao_incluso, " +
                        "  id_nota_fiscal_entrada_linha, " +
                        "  id_lote " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto, " +
                        "  :id_fornecedor, " +
                        "  :id_marca, " +
                        "  :hcp_numero_nota_entrada, " +
                        "  :hcp_data_oc, " +
                        "  :hcp_data_recebimento, " +
                        "  :hcp_preco_unitario, " +
                        "  :hcp_icm_incluso, " +
                        "  :hcp_ipi_nao_incluso, " +
                        "  :id_nota_fiscal_entrada_linha, " +
                        "  :id_lote " +
                        ") RETURNING id_historico_compra_produto;";
                }
                else
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.historico_compra_produto   " +
                        "SET  " +
                        "  id_produto = :id_produto, " +
                        "  id_fornecedor = :id_fornecedor, " +
                        "  id_marca = :id_marca, " +
                        "  hcp_numero_nota_entrada = :hcp_numero_nota_entrada, " +
                        "  hcp_data_oc = :hcp_data_oc, " +
                        "  hcp_data_recebimento = :hcp_data_recebimento, " +
                        "  hcp_preco_unitario = :hcp_preco_unitario, " +
                        "  hcp_icm_incluso = :hcp_icm_incluso, " +
                        "  hcp_ipi_nao_incluso = :hcp_ipi_nao_incluso, " +
                        "  id_nota_fiscal_entrada_linha = :id_nota_fiscal_entrada_linha, " +
                        "  id_lote = :id_lote " +
                        "WHERE  " +
                        "  id_historico_compra_produto = :id_historico_compra_produto " +
                        "RETURNING id_historico_compra_produto ;";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_historico_compra_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this._produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_marca", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idMarca;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcp_numero_nota_entrada", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.numeroNF;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcp_data_oc", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataOC;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcp_data_recebimento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataRecebimento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcp_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.precoUnitario;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcp_icm_incluso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.icmsIncluso;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcp_ipi_nao_incluso", NpgsqlDbType.Double));
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
                    foreach (ProdutoFornecedorClass pf in _produto.CollectionProdutoFornecedorClassProduto.Where(a => a.Fornecedor == Fornecedor))
                    {
                        pf.UltimoPreco = precoUnitario;
                        pf.DataUltimaCompra = dataRecebimento;
                        pf.Ipi = ipiNaoIncluso;
                        pf.Icms = icmsIncluso;

                        //pf.Save(ref command);
                    }
                }
                

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o histórico de produtos\r\n" + e.Message, e);
            }
        }
    }
}
