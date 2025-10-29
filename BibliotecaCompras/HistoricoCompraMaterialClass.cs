#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;

#endregion

namespace BibliotecaCompras
{
    public class HistoricoCompraMaterialClass : HistoricoCompraClass
    {
        private MaterialClass _material;


        public HistoricoCompraMaterialClass(int ID, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn) :
            base(ID, usuario, conn)
        {

        }

        public HistoricoCompraMaterialClass(FornecedorClass fornecedor, int? idMarca, string numeroNF, 
            DateTime dataRecebimento, DateTime dataOC,
            double precoUnitario, double icmsIncluso, double ipiNaoIncluso, int idLinhaNF,
            MaterialClass material, LoteClass Lote, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn) :
            base(fornecedor, idMarca, numeroNF, dataRecebimento, dataOC, precoUnitario, icmsIncluso,
            ipiNaoIncluso,
            idLinhaNF, Lote, usuario, conn)
        {
            _material = material;
        }


        protected override void Load()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                        "SELECT  " +
                        "  id_material, " +
                        "  id_fornecedor, " +
                        "  id_marca, " +
                        "  hcm_numero_nota_entrada, " +
                        "  hcm_data_oc, " +
                        "  hcm_data_recebimento, " +
                        "  hcm_preco_unitario, " +
                        "  hcm_icm_incluso, " +
                        "  hcm_ipi_nao_incluso, " +
                        "  id_nota_fiscal_entrada_linha, " +
                        "  id_lote "+
                        "FROM  " +
                        "  public.historico_compra_material " +
                        "WHERE " +
                        "  id_historico_compra_material = :id_historico_compra_material ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_historico_compra_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }
                read.Read();

                this._material = MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]), Usuario, conn);
                this.Fornecedor = FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]), Usuario, conn);
                if (read["id_marca"] != DBNull.Value)
                {
                    this.idMarca = Convert.ToInt32(read["id_marca"]);
                }
                this.numeroNF = read["hcm_numero_nota_entrada"].ToString();
                this.dataOC = Convert.ToDateTime(read["hcm_data_oc"]);
                this.dataRecebimento = Convert.ToDateTime(read["hcm_data_recebimento"]);
                this.precoUnitario = Convert.ToDouble(read["hcm_preco_unitario"]);
                this.icmsIncluso = Convert.ToDouble(read["hcm_icm_incluso"]);
                this.ipiNaoIncluso = Convert.ToDouble(read["hcm_ipi_nao_incluso"]);
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
                throw new Exception("Erro ao carregar os dados do histórico de material\r\n" + e.Message, e);
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
                        "  public.historico_compra_material " +
                        "( " +
                        "  id_material, " +
                        "  id_fornecedor, " +
                        "  id_marca, " +
                        "  hcm_numero_nota_entrada, " +
                        "  hcm_data_oc, " +
                        "  hcm_data_recebimento, " +
                        "  hcm_preco_unitario, " +
                        "  hcm_icm_incluso, " +
                        "  hcm_ipi_nao_incluso, " +
                        "  id_nota_fiscal_entrada_linha, " +
                        "  id_lote "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_material, " +
                        "  :id_fornecedor, " +
                        "  :id_marca, " +
                        "  :hcm_numero_nota_entrada, " +
                        "  :hcm_data_oc, " +
                        "  :hcm_data_recebimento, " +
                        "  :hcm_preco_unitario, " +
                        "  :hcm_icm_incluso, " +
                        "  :hcm_ipi_nao_incluso, " +
                        "  :id_nota_fiscal_entrada_linha, " +
                        "  :id_lote " +
                        ") RETURNING id_historico_compra_material;";
                }
                else
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.historico_compra_material   " +
                        "SET  " +
                        "  id_material = :id_material, " +
                        "  id_fornecedor = :id_fornecedor, " +
                        "  id_marca = :id_marca, " +
                        "  hcm_numero_nota_entrada = :hcm_numero_nota_entrada, " +
                        "  hcm_data_oc = :hcm_data_oc, " +
                        "  hcm_data_recebimento = :hcm_data_recebimento, " +
                        "  hcm_preco_unitario = :hcm_preco_unitario, " +
                        "  hcm_icm_incluso = :hcm_icm_incluso, " +
                        "  hcm_ipi_nao_incluso = :hcm_ipi_nao_incluso, " +
                        "  id_nota_fiscal_entrada_linha = :id_nota_fiscal_entrada_linha, " +
                        "  id_lote = :id_lote "+
                        "WHERE  " +
                        "  id_historico_compra_material = :id_historico_compra_material " +
                        "RETURNING id_historico_compra_material ;";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_historico_compra_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this._material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_marca", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idMarca;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_numero_nota_entrada", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.numeroNF;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_data_oc", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataOC;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_data_recebimento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataRecebimento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.precoUnitario;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_icm_incluso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.icmsIncluso;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_ipi_nao_incluso", NpgsqlDbType.Double));
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
                    foreach (MaterialFornecedorClass mf in _material.CollectionMaterialFornecedorClassMaterial.Where(a => a.Fornecedor == Fornecedor))
                    {
                        mf.UltimoPreco = precoUnitario;
                        mf.DataUltimaCompra = dataRecebimento;
                        mf.Ipi = ipiNaoIncluso;
                        mf.Icms = icmsIncluso;

                        //mf.Save(ref command);
                    }
                }
                    


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o histórico de material\r\n" + e.Message, e);
            }
        }
    }
}
