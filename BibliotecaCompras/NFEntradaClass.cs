#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

#endregion

namespace BibliotecaCompras
{

    public class NFEntradaClass
    {
        public int? ID { get; private set; }

        public string CNPJFornecedor
        {
            get
            {
                if (this.Fornecedor != null)
                {
                    return this.Fornecedor.Cnpj;
                }
                return this.CNPJFornecedorNota;
            }
        }

        public string razaoFornecedor
        {
            get
            {
                if (this.Fornecedor != null)
                {
                    return this.Fornecedor.RazaoSocial;
                }
                return this.razaoFornecedorNota;
            }
        }

        public string Numero { get; internal set; }
        public string Serie { get; internal set; }
        public DateTime dataNf { get; internal set; }
        public double valorTotal { get; internal set; }
        public string nomeArquivo { get; internal set; }
        public DateTime dataImportacao { get; internal set; }

        private FornecedorClass _fornecedor = null;
        public FornecedorClass Fornecedor
        {
            get
            {
                if (this._fornecedor == null)
                {
                    this.identificarFornecedor();
                }
                return this._fornecedor;
            }
            internal set
            {
                this._fornecedor = value;
            }
        }

        public string nomeFornecedorSistema { get; private set; }

        internal List<FornecedorClass> possiveisFornecedores = new List<FornecedorClass>();

        private SortedDictionary<int, NFEntradaItemClass> _Linhas;
        public string razaoFornecedorNota;
        public string CNPJFornecedorNota;


        internal SortedDictionary<int, NFEntradaItemClass> linhasAtuais
        {
            get
            {
                return new SortedDictionary<int, NFEntradaItemClass>(this._Linhas.Where(a => !a.Value.toDelete).ToDictionary(a => a.Key, a => a.Value));
            }
        }

        internal List<NFEntradaItemClass> linhasNaoVinculadas
        {
            get
            {
                if (this.linhasAtuais != null)
                {
                    return new List<NFEntradaItemClass>(this.linhasAtuais.Values.Where(a => !a.toDelete && (!a.Vinculada || (a.Vinculada && a.pendenteSalvar))));
                }
                else
                {
                    return null;
                }
            }
        }

        internal double valorTotalCalculado
        {
            get
            {
                double toRet = 0;
                foreach (NFEntradaItemClass linha in this.linhasAtuais.Values)
                {
                    toRet += linha.valorTotal;
                }

                toRet = Math.Round(toRet, 4);
                return toRet;
            }
        }

        public List<ContaPagarClass> ContasPagar { get; set; }

        internal IWTPostgreNpgsqlConnection conn { get; private set; }
        internal AcsUsuarioClass Usuario { get; private set; }


        public string ChaveNota { get; set; }

        public NFEntradaClass(int? ID, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
            this.ID = ID;
            this._Linhas = new SortedDictionary<int, NFEntradaItemClass>();
            this.dataImportacao = Configurations.DataIndependenteClass.GetData();
            this.Usuario = usuario;

            this.ContasPagar = new List<ContaPagarClass>();
            if (this.ID != null)
            {
                this.Load();
            }
        }

        private void Load()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  nen_cnpj, " +
                    "  nen_razao_fornecedor, " +
                    "  nen_numero_nf, " +
                    "  nen_serie_nf, " +
                    "  nen_data_nf, " +
                    "  nen_valor_total, " +
                    "  nen_nome_arquivo, " +
                    "  nen_data_importacao, " +
                    "  id_fornecedor, " +
                    "  nen_chave_nota "+
                    "FROM  " +
                    "  public.nota_fiscal_entrada " +
                    "WHERE " +
                    "  id_nota_fiscal_entrada = :id_nota_fiscal_entrada ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido.");
                }


                read.Read();

                this.Numero = read["nen_numero_nf"].ToString();
                this.Serie = read["nen_serie_nf"].ToString();
                this.dataNf = Convert.ToDateTime(read["nen_data_nf"]);
                this.valorTotal = Convert.ToDouble(read["nen_valor_total"]);
                this.nomeArquivo = read["nen_nome_arquivo"].ToString();
                this.dataImportacao = Convert.ToDateTime(read["nen_data_importacao"]);

                this.CNPJFornecedorNota = read["nen_cnpj"].ToString();
                this.razaoFornecedorNota = read["nen_razao_fornecedor"].ToString();

                this.ChaveNota = read["nen_chave_nota"].ToString();

                if (read["id_fornecedor"] != DBNull.Value)
                {
                    this._fornecedor = FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]), Usuario, conn);
                    this.nomeFornecedorSistema = _fornecedor.RazaoSocial;
                }

                read.Close();

                command.CommandText =
                    "SELECT  " +
                    "  id_nota_fiscal_entrada_linha, " +
                    "  nel_linha, " +
                    "  nel_codigo, " +
                    "  nel_descricao, " +
                    "  nel_quantidade, " +
                    "  nel_valor_unitario, " +
                    "  nel_valor_total, " +
                    "  nel_imcs_incluso, " +
                    "  nel_ipi_nao_incluso, " +
                    "  nel_vinculada, " +
                    "  nel_ncm, "+
                    "  nel_unidade, "+
                    "  nel_xped, "+
                    "  nel_posicao "+
                    "FROM " +
                    "  public.nota_fiscal_entrada_linha " +
                    "WHERE " +
                    "  id_nota_fiscal_entrada = :id_nota_fiscal_entrada ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                read = command.ExecuteReader();
                while (read.Read())
                {
                    int numeroLinha = Convert.ToInt32(read["nel_linha"]);
                    this._Linhas.Add(numeroLinha, new NFEntradaItemClass(
                        Convert.ToInt32(read["id_nota_fiscal_entrada_linha"]),
                        numeroLinha,
                        read["nel_codigo"].ToString(),
                        read["nel_descricao"].ToString(),
                        read["nel_ncm"].ToString(),
                        read["nel_unidade"].ToString(),
                        Convert.ToDouble(read["nel_quantidade"]),
                        Convert.ToDouble(read["nel_valor_unitario"]),
                        Convert.ToDouble(read["nel_valor_total"]),
                        Convert.ToDouble(read["nel_imcs_incluso"]),
                        Convert.ToDouble(read["nel_ipi_nao_incluso"]),
                        Convert.ToBoolean(Convert.ToInt16(read["nel_vinculada"])),
                        read["nel_xped"] == DBNull.Value?null: read["nel_xped"].ToString(),
                        read["nel_posicao"] == DBNull.Value?(int?)null:Convert.ToInt32(read["nel_posicao"]),
                        this,
                        this.conn));
                }
                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da NF de Entrada.\r\n" + e.Message, e);
            }
        }

        public void addicionarLinha(int? Linha, string Codigo, string Descricao, string NCM, string Unidade,
            double Quantidade, double valorUnitario, double valorTotal, double icmsIncluso,
            double ipiNaoIncluso, bool Vinculada, string xPed, int? linhaPed)
        {
            try
            {
                if (Linha == null)
                {
                    Linha = this.linhasAtuais.Count+1;
                }


                if (this._Linhas.ContainsKey(Linha.Value))
                {
                    throw new Exception("Número de linha já existente.");
                }

                this._Linhas.Add(Linha.Value,
                    new NFEntradaItemClass(
                        null,
                        Linha.Value,
                        Codigo,
                        Descricao,
                        NCM,
                        Unidade,
                        Quantidade,
                        valorUnitario,
                        valorTotal,
                        icmsIncluso,
                        ipiNaoIncluso,
                        Vinculada,
                        xPed,
                        linhaPed,
                        this,
                        this.conn));
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar a linha.\r\n" + e.Message, e);
            }

        }

        public void Salvar(IWTBaseForm form)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();

                command.Transaction = this.conn.BeginTransaction();
                this.Salvar(form, ref command);
                command.Transaction.Commit();

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao salvar a nota fiscal.\r\n" + e.Message, e);
            }
        }

        internal void Salvar(IWTBaseForm form, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.CNPJFornecedorNota))
                {
                    throw new Exception("Não é possível cadastrar uma nota fiscal sem o CNPJ do fornecedor.");
                }

                //Teste Duplicidade

                if (this.ID == null)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  public.nota_fiscal_entrada.id_nota_fiscal_entrada " +
                        "FROM " +
                        "  public.nota_fiscal_entrada " +
                        "WHERE " +
                        "  public.nota_fiscal_entrada.nen_cnpj = :nen_cnpj AND  " +
                        "  public.nota_fiscal_entrada.nen_numero_nf = :nen_numero_nf AND " +
                        "  public.nota_fiscal_entrada.nen_serie_nf = :nen_serie_nf ";


                }
                else
                {
                    command.CommandText =
                       "SELECT  " +
                       "  public.nota_fiscal_entrada.id_nota_fiscal_entrada " +
                       "FROM " +
                       "  public.nota_fiscal_entrada " +
                       "WHERE " +
                       "  public.nota_fiscal_entrada.nen_cnpj = :nen_cnpj AND  " +
                       "  public.nota_fiscal_entrada.nen_numero_nf = :nen_numero_nf AND " +
                       "  public.nota_fiscal_entrada.nen_serie_nf = :nen_serie_nf AND " +
                       "  public.nota_fiscal_entrada.id_nota_fiscal_entrada <> :id_nota_fiscal_entrada";

                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.CNPJFornecedorNota;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_numero_nf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_serie_nf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Serie;

                object tmp = command.ExecuteScalar();
                if (tmp != null && tmp != DBNull.Value)
                {
                    throw new Exception("Já existe uma nota fiscal de entrada importada para o CNPJ (" + this.CNPJFornecedor + "), Série(" + this.Serie + ") e Número(" + this.Numero + ") fornecidos: " + this.nomeArquivo);
                }



                if (this.ID == null)
                {

                    command.CommandText =
                    "INSERT INTO  " +
                    "  public.nota_fiscal_entrada " +
                    "( " +
                    "  nen_cnpj, " +
                    "  nen_razao_fornecedor, " +
                    "  nen_numero_nf, " +
                    "  nen_serie_nf, " +
                    "  nen_data_nf, " +
                    "  nen_valor_total, " +
                    "  nen_nome_arquivo, " +
                    "  nen_data_importacao, " +
                    "  id_fornecedor, " +
                    "  nen_chave_nota "+
                    ")  " +
                    "VALUES ( " +
                    "  :nen_cnpj, " +
                    "  :nen_razao_fornecedor, " +
                    "  :nen_numero_nf, " +
                    "  :nen_serie_nf, " +
                    "  :nen_data_nf, " +
                    "  :nen_valor_total, " +
                    "  :nen_nome_arquivo, " +
                    "  :nen_data_importacao, " +
                    "  :id_fornecedor, " +
                    "  :nen_chave_nota " +
                    ") RETURNING id_nota_fiscal_entrada ;";

                }
                else
                {
                    command.CommandText =
                    "UPDATE  " +
                    "  public.nota_fiscal_entrada   " +
                    "SET  " +
                    "  nen_cnpj = :nen_cnpj, " +
                    "  nen_razao_fornecedor = :nen_razao_fornecedor, " +
                    "  nen_numero_nf = :nen_numero_nf, " +
                    "  nen_serie_nf = :nen_serie_nf, " +
                    "  nen_data_nf = :nen_data_nf, " +
                    "  nen_valor_total = :nen_valor_total, " +
                    "  nen_nome_arquivo = :nen_nome_arquivo, " +
                    "  nen_data_importacao = :nen_data_importacao, " +
                    "  id_fornecedor = :id_fornecedor, " +
                    "  nen_chave_nota = :nen_chave_nota "+
                    "WHERE  " +
                    "  id_nota_fiscal_entrada = :id_nota_fiscal_entrada " +
                    " RETURNING id_nota_fiscal_entrada;";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.CNPJFornecedorNota;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_razao_fornecedor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.razaoFornecedorNota;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_numero_nf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_serie_nf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Serie;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_data_nf", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataNf;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_valor_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.valorTotal;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_nome_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.nomeArquivo;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_data_importacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataImportacao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Fornecedor != null ? (object)this.Fornecedor.ID : null;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_chave_nota", NpgsqlDbType.Varchar, string.IsNullOrWhiteSpace(ChaveNota) ? null : ChaveNota));

                this.ID = Convert.ToInt32(command.ExecuteScalar());

                foreach (NFEntradaItemClass linha in this._Linhas.Values)
                {
                    linha.Salvar(form, ref command);
                }



                if (Fornecedor!=null && ContasPagar != null)
                {
                    NotaFiscalEntradaClass nfEntradaEntidade = NotaFiscalEntradaClass.GetEntidade(this.ID.Value, Usuario, conn);

                    foreach (ContaPagarClass contaPagar in ContasPagar)
                    {
                        contaPagar.NotaFiscalEntrada = nfEntradaEntidade;


                        if (contaPagar.Fornecedor != null)
                        {
                            contaPagar.ContaEmRevisao = contaPagar.Fornecedor.ContaRevisarRecebimento;
                        }
                        else
                        {
                            CredorDevedorClass cr = CredorDevedorClass.GetEntidade(contaPagar.IdCredor, Usuario, command.Connection);
                            if (cr.Fornecedor != null)
                            {
                                contaPagar.ContaEmRevisao = cr.Fornecedor.ContaRevisarRecebimento;
                            }

                        }

                        if (contaPagar.AgrupadorConta.IsDirty())
                        {
                            contaPagar.AgrupadorConta.Save(ref command);
                        }

                        contaPagar.Save(ref command);
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a nf de entrada.\r\n" + e.Message, e);
            }
        }

        internal void identificarFornecedor()
        {
            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
            identificarFornecedor(ref command);
        }

        internal void identificarFornecedor(ref IWTPostgreNpgsqlCommand command)
        {

            try
            {
                
                command.CommandText =
                    "SELECT  " +
                    "  public.fornecedor.id_fornecedor, " +
                    "  public.fornecedor.for_razao_social, " +
                    "  public.fornecedor.id_conta_bancaria, " +
                    "  public.fornecedor.id_centro_custo_lucro " +
                    "FROM " +
                    "  public.fornecedor " +
                    "WHERE " +
                    "  trim(replace(replace(replace(public.fornecedor.for_cnpj,'-',''),'.',''), '/','')) " +
                    " LIKE '" + this.CNPJFornecedorNota.Replace("/", "").Replace(".", "").Replace("-", "").Trim() + "' ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                string nomeForn = "";
                int idContaBancaria = -1;
                int idCentroCusto = -1;

                while (read.Read())
                {
                    this.possiveisFornecedores.Add(FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]), Usuario, conn));
                    nomeForn = read["for_razao_social"].ToString();
                    
                    if (read["id_conta_bancaria"] != DBNull.Value)
                    {
                        idContaBancaria = Convert.ToInt32(read["id_conta_bancaria"]);
                    }


                    if (read["id_centro_custo_lucro"] != DBNull.Value)
                    {
                        idCentroCusto = Convert.ToInt32(read["id_centro_custo_lucro"]);
                    }
                }

                if (this.possiveisFornecedores.Count == 1)
                {
                    this._fornecedor = this.possiveisFornecedores[0];
                    this.nomeFornecedorSistema = nomeForn;
                    
                    if (this.ContasPagar != null)
                    {

                        if (idContaBancaria != -1 && idCentroCusto != -1)
                        {
                            CentroCustoLucroClass centroCusto = CentroCustoLucroClass.GetEntidade(idCentroCusto, Usuario, conn);
                            
                            ContaBancariaClass contaBancaria = ContaBancariaClass.GetEntidade(idContaBancaria, Usuario, conn);

                            CredorDevedorClass cr = null;
                            if (_fornecedor != null)
                            {
                                 cr = _fornecedor.CollectionCredorDevedorClassFornecedor.FirstOrDefault();
                            }

                            foreach (ContaPagarClass conta in ContasPagar)
                            {

                                if (cr != null)
                                {
                                    conta.IdCredor = cr.ID;
                                }

                                conta.ContaBancaria = contaBancaria;
                                conta.CentroCustoLucro = centroCusto;
                            }
                        }
                        else
                        {


                            this.ContasPagar = new List<ContaPagarClass>();

                        }


                    }

                }
                else
                {
                    this.Fornecedor = null;
                    this.nomeFornecedorSistema = "";
                    this.ContasPagar = new List<ContaPagarClass>();
                }

                read.Close();


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identifcar o fornecedor.\r\n" + e.Message, e);
            }
        }

        internal void definirFornecedor(FornecedorClass fornecedor)
        {
            this.Fornecedor = fornecedor;
            this.nomeFornecedorSistema = razaoFornecedor;
        }

        internal bool todasLinhasVinculadas()
        {
            try
            {
                foreach (NFEntradaItemClass linha in this.linhasNaoVinculadas)
                {
                    if (!linha.Vinculada)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar se todas as linhas foram vinculadas.\r\n" + e.Message, e);
            }
        }

        internal void excluirLinha(int numeroLinha)
        {
            try
            {
                if (this._Linhas.ContainsKey(numeroLinha))
                {
                    NFEntradaItemClass linhaTmp = this._Linhas[numeroLinha];
                    linhaTmp.Excluir();
                    this._Linhas.Remove(numeroLinha);

                    int i = -1;
                    while (this._Linhas.ContainsKey(i))
                    {
                        i--;
                    }
                    this._Linhas.Add(i, linhaTmp);

                    this.reordernarLinhas();
                }
                else
                {
                    throw new Exception("Número de linha inválido.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir a linha\r\n" + e.Message, e);
            }
        }

        private void reordernarLinhas()
        {
            try
            {
                SortedDictionary<int, NFEntradaItemClass> novoLinhas = new SortedDictionary<int, NFEntradaItemClass>();

                int i = 1;
                foreach (KeyValuePair<int, NFEntradaItemClass> item in this._Linhas)
                {
                    if (item.Key < 0)
                    {
                        novoLinhas.Add(item.Key, item.Value);
                    }
                    else
                    {
                        item.Value.setLinha(i);
                        novoLinhas.Add(i, item.Value);
                        i++;
                    }
                }

                this._Linhas = novoLinhas;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao reordernar as linhas.\r\n" + e.Message, e);
            }

        }

        
    }

    public class NFEntradaItemClass
    {
        public int? ID { get; private set; }
        public int Linha { get; internal set; }
        public string Codigo { get; internal set; }
        public string Descricao { get; internal set; }
        public string NCM { get; internal set; }
        public string Unidade { get; internal set; }

        public double Quantidade { get; internal set; }
        public double valorUnitario { get; internal set; }
        public double valorTotal { get; internal set; }
        public double icmsIncluso { get; internal set; }
        public double ipiNaoIncluso { get; internal set; }

        public bool Vinculada { get; private set; }
        public bool pendenteSalvar { get; private set; }

        public BibliotecaEntidades.Entidades.ProdutoClass Produto { get; private set; }
        public BibliotecaEntidades.Entidades.MaterialClass Material { get; private set; }
        public EpiClass Epi { get; private set; }

        public string codigoItemSistema { get; private set; }
        public string descricaoItemSistema { get; private set; }

        public string XPed { get; set; }
        public int? Posicao { get; set; }


        public SolicitacaoCompraClass solicitacaoCompra { get; private set; }

        public BibliotecaEntidades.Operacoes.Compras.LoteClass Lote { get; private set; }
        private HistoricoCompraClass Historico;

        readonly NFEntradaClass Pai;
        readonly IWTPostgreNpgsqlConnection conn;
        OCsDisponiveisClass solicitacoesLivres;

        public bool toDelete { get; private set; }

        public string numeroLote
        {
            get
            {
                if (this.Lote != null)
                {
                    return this.Lote.Numero;
                }
                else
                {
                    return "";
                }
            }
        }

        private double margemAceite
        {
            get
            {
                if (this.Produto!=null)
                {
                    if (this.Produto.MargemRecebimento.HasValue)
                    {
                        return this.Produto.MargemRecebimento.Value/100;
                    }
                    else
                    {
                        return Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.MARGEM_PADRAO_ACEITE_RECEBIMENTO_COMPRAS))/100;
                    }
                }
                else
                {
                    if (this.Material!=null)
                    {
                        if (this.Material.MargemRecebimento.HasValue)
                        {
                            return this.Material.MargemRecebimento.Value / 100;
                        }
                        else
                        {
                            return Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.MARGEM_PADRAO_ACEITE_RECEBIMENTO_COMPRAS))/100;
                        }
                        
                    }

                    return 0;
                }
            }
        }

        public NFEntradaItemClass(int? ID, int Linha, string Codigo, string Descricao, string NCM,string Unidade,
            double Quantidade, double valorUnitario, double valorTotal, double icmsIncluso,
            double ipiNaoIncluso, bool Vinculada, string xPed, int? posicao, 
            NFEntradaClass Pai, IWTPostgreNpgsqlConnection conn)
        {
            this.ID = ID;
            this.Linha = Linha;
            this.Codigo = Codigo;
            this.Descricao = Descricao;
            this.NCM = NCM;
            this.Unidade = Unidade;
            this.Quantidade = Quantidade;
            this.valorUnitario = valorUnitario;
            this.valorTotal = valorTotal;
            this.icmsIncluso = icmsIncluso;
            this.ipiNaoIncluso = ipiNaoIncluso;
            this.Vinculada = Vinculada;
            this.Pai = Pai;
            this.conn = conn;
            XPed = xPed;
            Posicao = posicao;

            this.pendenteSalvar = true;
            this.toDelete = false;
        }

        internal NFEntradaItemClass(int? ID, NFEntradaClass Pai, IWTPostgreNpgsqlConnection conn)
        {
            this.ID = ID;
            this.Pai = Pai;
            this.conn = conn;
            this.pendenteSalvar = true;
            this.toDelete = false;

            if (this.ID != null)
            {
                this.Load();
            }

        }


        private void Load()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                "SELECT  " +
                "  public.nota_fiscal_entrada_linha.id_nota_fiscal_entrada, " +
                "  public.nota_fiscal_entrada_linha.nel_linha, " +
                "  public.nota_fiscal_entrada_linha.nel_codigo, " +
                "  public.nota_fiscal_entrada_linha.nel_descricao, " +
                "  public.nota_fiscal_entrada_linha.nel_quantidade, " +
                "  public.nota_fiscal_entrada_linha.nel_valor_unitario, " +
                "  public.nota_fiscal_entrada_linha.nel_valor_total, " +
                "  public.nota_fiscal_entrada_linha.nel_imcs_incluso, " +
                "  public.nota_fiscal_entrada_linha.nel_ipi_nao_incluso, " +
                "  public.nota_fiscal_entrada_linha.nel_vinculada, " +
                "  public.nota_fiscal_entrada_linha.nel_ncm, "+
                "  public.nota_fiscal_entrada_linha.nel_unidade, "+
                "  public.nota_fiscal_entrada_linha.nel_xped, " +
                "  public.nota_fiscal_entrada_linha.nel_posicao " +
                "FROM " +
                "  public.nota_fiscal_entrada_linha " +
                "WHERE " +
                "  id_nota_fiscal_entrada_linha = :id_nota_fiscal_entrada_linha ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada_linha", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }

                read.Read();

                this.Linha = Convert.ToInt32(read["nel_linha"]);
                this.Codigo = read["nel_codigo"].ToString();
                this.Descricao = read["nel_descricao"].ToString();
                this.Quantidade = Convert.ToDouble(read["nel_quantidade"]);
                this.valorUnitario = Convert.ToDouble(read["nel_valor_unitario"]);
                this.valorTotal = Convert.ToDouble(read["nel_valor_total"]);
                this.icmsIncluso = Convert.ToDouble(read["nel_imcs_incluso"]);
                this.ipiNaoIncluso = Convert.ToDouble(read["nel_ipi_nao_incluso"]);
                this.Vinculada = Convert.ToBoolean(Convert.ToInt16(read["nel_vinculada"]));
                this.NCM = read["nel_ncm"].ToString();
                this.Unidade = read["nel_unidade"].ToString();
                XPed = read["nel_xped"].ToString();
                Posicao = read["nel_posicao"] != DBNull.Value ? Convert.ToInt32(read["nel_posicao"]) : (int?) null;
                

                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da linha.\r\n" + e.Message, e);
            }
        }

        internal void setLote(
           ProdutoClass produto, MaterialClass material, EpiClass epi,
            SolicitacaoCompraClass Solicitacao,
            FornecedorClass fornecedor,
            string Numero, double quantidadeUnidadeUso,double quantidadeUnidadeCompra,
            double quantidadeUnidadesUsoPorUnidadeCompra, 
             DateTime? dataFabricacao, DateTime? dataEmbalagem, DateTime? dataValidade,
            string codigoItemSistema, string descricaoItemSistema,
            int? idEmissorCertificado, string emissorCertificado,
            string Obs,string Certificado, int qtdEtiquetasLote,
            ref OCsDisponiveisClass solicitacoesLivres, IWTBaseForm form )
        {

            try
            {
                if (material != null)
                {
                    this.Material = material;
                    this.Produto = null;
                    this.Epi = null;
                }
                else
                {
                    if (epi != null)
                    {
                        this.Epi = epi;
                        this.Produto = null;
                        this.Material = null;

                    }
                    else
                    {
                        this.Produto = produto;
                        this.Material = null;
                        this.Epi = null;
                    }

                }

                this.Vinculada = true;
                this.solicitacoesLivres = solicitacoesLivres;

                this.Lote = new LoteClass(null, this.Pai.Usuario, this.Pai.conn);
                this.Lote.setFornecedorCliente(fornecedor, null);

                /*if (Numero == null)
                {
                    Numero = Configurations.DataIndependenteClass.GetData().ToString("yyyyMMddHHmmss");
                }*/



                this.Lote.Numero = Numero;
                this.Lote.setQuantidade(quantidadeUnidadeUso, quantidadeUnidadeCompra, quantidadeUnidadesUsoPorUnidadeCompra);
                this.Lote.setDataFabricacao(dataFabricacao);
                this.Lote.setDataEmbalagem(dataEmbalagem);
                this.Lote.setDataValidade(dataValidade);
                this.Lote.dataRecebimento = this.Pai.dataImportacao;

                if (Solicitacao != null)
                {
                    bool aprovadoDivergencia;
                    AcsUsuarioClass aprovadorDivergencias;

                    ValidaPrecoTributos(Solicitacao,valorUnitario,icmsIncluso,ipiNaoIncluso,form,out aprovadoDivergencia, out aprovadorDivergencias);

                    this.Lote.adicionarSolicitacao(Solicitacao, quantidadeUnidadeUso, quantidadeUnidadeCompra,
                        Solicitacao.ValorUnitarioCompra.HasValue ? Solicitacao.ValorUnitarioCompra.Value : 0,
                        this.valorUnitario,
                        Solicitacao.AliquotaICMSCompra.HasValue ? Solicitacao.AliquotaICMSCompra.Value : 0,
                        icmsIncluso,
                        Solicitacao.AliquotaIPICompra.HasValue ? Solicitacao.AliquotaIPICompra.Value : 0,
                        ipiNaoIncluso,
                        aprovadoDivergencia,
                        aprovadorDivergencias
                    );
                    this.solicitacaoCompra = Solicitacao;
                }
                else
                {
                    this.preencherSolicitacoesLote(form); 
                }

                this.Lote.setMaterialProduto(material, produto, epi, codigoItemSistema, this.Codigo, this.Descricao, this.NCM, null, this.Unidade, this.valorUnitario);
              

                this.Lote.setEmissorCertificado(idEmissorCertificado, emissorCertificado);
                this.Lote.Observacoes = Obs;
                this.Lote.Certificado = Certificado;
                this.Lote.qtdEtiquetas = qtdEtiquetasLote;

                this.Lote.setNf(this.Pai.dataNf, this.Pai.Serie, this.Pai.Numero);

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                if (this.Material != null)
                {
                    this.Lote.setGavetasEstoque(EstoqueMovimentacao.BuscaTodasGavetasMaterial(Material,  null));
                }
                else
                {
                    if (this.Epi != null)
                    {
                        this.Lote.setGavetasEstoque(EstoqueMovimentacao.BuscaTodasGavetasEpi(Epi));
                    }
                    else
                    {
                        this.Lote.setGavetasEstoque(EstoqueMovimentacao.BuscaTodasGavetasProduto(Produto, null));
                    }
                }

                this.codigoItemSistema = codigoItemSistema;
                this.descricaoItemSistema = descricaoItemSistema;
            }
            catch (Exception e)
            {
                this.Material = null;
                this.Produto = null;
                this.Epi = null;
                this.Lote = null;
                throw new Exception("Erro ao definir o lote.\r\n" + e.Message, e);
            }


        }

        internal void alterarLote(ProdutoClass produto, MaterialClass material, EpiClass epi,
            SolicitacaoCompraClass Solicitacao,
            FornecedorClass fornecedor,
            string Numero, double quantidadeUnidadeUso, double quantidadeUnidadeCompra,
            double quantidadeUnidadesUsoPorUnidadeCompra, 
             DateTime? dataFabricacao, DateTime? dataEmbalagem, DateTime? dataValidade,
            string codigoItemSistema, string descricaoItemSistema,
            int? idEmissorCertificado, string emissorCertificado,
            string Obs, string Certificado, int qtdEtiquetasLote,
            ref OCsDisponiveisClass solicitacoesLivres,
            IWTBaseForm form)
        {
            try
            {

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                if (material != null)
                {
                    this.Material = material;
                    this.Produto = null;

                }
                else
                {
                    this.Material = null;
                    this.Produto = produto;
                }

                if (this.Produto != produto || this.Material != material)
                {
                    this.Lote.removerTodasGavetas();
                    if (this.Material != null)
                    {
                        this.Lote.setGavetasEstoque(EstoqueMovimentacao.BuscaTodasGavetasMaterial(this.Material, null));
                    }
                    else
                    {
                        this.Lote.setGavetasEstoque(EstoqueMovimentacao.BuscaTodasGavetasProduto(this.Produto, null));
                    }
                }


                if (this.Lote.solicitacoesCompraAtuais.Count > 0)
                {
                    this.Lote.removerTodasSolicitacoes();
                   
                }


                this.Lote.setFornecedorCliente(fornecedor, null);

                //if (Numero == null)
                //{
                //    Numero = Configurations.DataIndependenteClass.GetData().ToString("yyyyMMddHHmmss");
                //}

                this.Lote.Numero = Numero;
                this.Lote.setQuantidade(quantidadeUnidadeUso, quantidadeUnidadeCompra, quantidadeUnidadesUsoPorUnidadeCompra);
                this.Lote.setDataFabricacao(dataFabricacao);
                this.Lote.setDataEmbalagem(dataEmbalagem);
                this.Lote.setDataValidade(dataValidade);
                this.Lote.dataRecebimento = this.Pai.dataImportacao;

                if (Solicitacao != null)
                {
                    bool aprovadoDivergencia;
                    AcsUsuarioClass aprovadorDivergencias;

                    ValidaPrecoTributos(Solicitacao, valorUnitario, icmsIncluso, ipiNaoIncluso, form, out aprovadoDivergencia, out aprovadorDivergencias);

                    this.Lote.adicionarSolicitacao(Solicitacao, quantidadeUnidadeUso, quantidadeUnidadeCompra,
                        Solicitacao.ValorUnitarioCompra.HasValue ? Solicitacao.ValorUnitarioCompra.Value : 0,
                        this.valorUnitario,
                        Solicitacao.AliquotaICMSCompra.HasValue ? Solicitacao.AliquotaICMSCompra.Value : 0,
                        icmsIncluso,
                        Solicitacao.AliquotaIPICompra.HasValue ? Solicitacao.AliquotaIPICompra.Value : 0,
                        ipiNaoIncluso,
                        aprovadoDivergencia,
                        aprovadorDivergencias

                    );
                    this.solicitacaoCompra = Solicitacao;
                }
                else
                {
                    this.preencherSolicitacoesLote(form);
                }


                this.Lote.setMaterialProduto(material, produto, Epi, codigoItemSistema, this.Codigo,this.Descricao,this.NCM,null, this.Unidade, this.valorUnitario);
               

                this.codigoItemSistema = codigoItemSistema;
                this.descricaoItemSistema = descricaoItemSistema;

                this.Lote.Certificado = Certificado;
                this.Lote.Observacoes = Obs;
                this.Lote.setEmissorCertificado(idEmissorCertificado, emissorCertificado);
                this.Lote.qtdEtiquetas = qtdEtiquetasLote;

                this.Lote.setNf(this.Pai.dataNf, this.Pai.Serie, this.Pai.Numero);

            }
            catch (Exception e)
            {
                if (this.Lote!=null)
                {
                    this.Lote.removerTodasSolicitacoes();
                }

                this.Material = null;
                this.Produto = null;
                this.Epi = null;
                this.Lote = null;
                throw new Exception("Erro ao alterar os dados do Lote.\r\n" + e.Message, e);
            }

        }


        private void ValidaPrecoTributos(SolicitacaoCompraClass solicitacao, double valor, double icms, double ipi, IWTBaseForm formPai, out bool aprovadoDivergencia, out AcsUsuarioClass aprovadorDivergencias)
        {
            aprovadoDivergencia = false;
            aprovadorDivergencias = null;

            if (IWTConfiguration.Conf.getBoolConf(Constants.VALIDAR_PRECOS_RECEBIMENTO))
            {
                string divergenciaPreco = null;
                string divergenciaIcms = null;
                string divergenciaIpi = null;

                double valorComDesconto = solicitacao.ValorUnitarioComDesconto;

                if (solicitacao.ValorUnitarioCompra.HasValue)
                {
                    double difValor = Math.Abs(valorComDesconto - valor);
                    if (difValor >= 0.01)
                    {
                        divergenciaPreco = "O valor unitário definido na solicitação de compra é de " + solicitacao.ValorUnitarioCompra.Value.ToString("C", CultureInfo.CurrentCulture) + " e o valor recebido na nota fiscal é de " + valor.ToString("C", CultureInfo.CurrentCulture);
                    }
                }

                if (solicitacao.AliquotaICMSCompra.HasValue)
                {
                    if (Math.Abs(solicitacao.AliquotaICMSCompra.Value - icms) > 0.0001)
                    {

                        divergenciaIcms = "A aliquota do icms definida na solicitação de compra é de " + solicitacao.AliquotaICMSCompra.Value.ToString("F2", CultureInfo.CurrentCulture) + "% e o valor recebido na nota fiscal é de " + icms.ToString("F2", CultureInfo.CurrentCulture) + "%";
                    }
                }

                if (solicitacao.AliquotaIPICompra.HasValue)
                {
                    if (Math.Abs(solicitacao.AliquotaIPICompra.Value - ipi) > 0.0001)
                    {
                        divergenciaIpi = "A aliquota do ipi definida na solicitação de compra é de " + solicitacao.AliquotaIPICompra.Value.ToString("F2", CultureInfo.CurrentCulture) + "% e o valor recebido na nota fiscal é de " + ipi.ToString("F2", CultureInfo.CurrentCulture) + "%";
                    }
                }


                if (!string.IsNullOrEmpty(divergenciaPreco) || !string.IsNullOrEmpty(divergenciaIcms) || !string.IsNullOrEmpty(divergenciaIpi))
                {
                    RecebimentoAprovacaoDivergencia formAprovacaoDivergencia = new RecebimentoAprovacaoDivergencia(divergenciaPreco, divergenciaIcms, divergenciaIpi);
                    formAprovacaoDivergencia.ShowDialog(formPai);

                    if (!formAprovacaoDivergencia.Aprovado)
                    {
                        string msgException = "As divergências de preço abaixo não foram aprovadas, não é possível efetivar o recebimento desse item:" + Environment.NewLine;
                        if (!string.IsNullOrEmpty(divergenciaPreco))
                        {
                            msgException += divergenciaPreco + Environment.NewLine;
                        }
                        if (!string.IsNullOrEmpty(divergenciaIcms))
                        {
                            msgException += divergenciaIcms + Environment.NewLine;
                        }
                        if (!string.IsNullOrEmpty(divergenciaIpi))
                        {
                            msgException += divergenciaIpi;
                        }
                        throw new ExcecaoTratada(msgException);
                    }
                    else
                    {

                        aprovadoDivergencia = true;
                        aprovadorDivergencias = formAprovacaoDivergencia.UsuarioAprovador;
                    }


                }

            }
        }

        internal void recarregarEstoquesLote()
        {
            try
            {
                this.Lote.removerTodasGavetas();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                if (this.Material != null)
                {
                    this.Lote.setGavetasEstoque(EstoqueMovimentacao.BuscaTodasGavetasMaterial(this.Material, null));
                }
                else
                {
                    if (this.Produto != null)
                    {
                        this.Lote.setGavetasEstoque(EstoqueMovimentacao.BuscaTodasGavetasProduto(this.Produto, null));
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            this.Lote.setGavetasEstoque(EstoqueMovimentacao.BuscaTodasGavetasEpi(this.Epi));
                        }
                        else
                        {
                            throw new ExcecaoTratada("Tipo de item inválido para o recarregamento dos estoques");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao recarregar os estoques.\r\n" + e.Message, e);
            }
        }

        internal void Salvar(IWTBaseForm form, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (this.ID != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.nota_fiscal_entrada_linha  "+
                            "WHERE  "+
                            "  id_nota_fiscal_entrada_linha = :id_nota_fiscal_entrada_linha "+
                            "; ";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada_linha", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                        command.ExecuteNonQuery();
                    }

                }
                else
                {
                    if (this.ID == null)
                    {
                        command.CommandText =
                        "INSERT INTO  " +
                        "  public.nota_fiscal_entrada_linha " +
                        "( " +
                        "  id_nota_fiscal_entrada, " +
                        "  nel_linha, " +
                        "  nel_codigo, " +
                        "  nel_descricao, " +
                        "  nel_quantidade, " +
                        "  nel_valor_unitario, " +
                        "  nel_valor_total, " +
                        "  nel_imcs_incluso, " +
                        "  nel_ipi_nao_incluso, " +
                        "  nel_vinculada, " +
                        "  nel_ncm, "+
                        "  nel_unidade, "+
                        "  nel_xped, "  +
                        "  nel_posicao " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_nota_fiscal_entrada, " +
                        "  :nel_linha, " +
                        "  :nel_codigo, " +
                        "  :nel_descricao, " +
                        "  :nel_quantidade, " +
                        "  :nel_valor_unitario, " +
                        "  :nel_valor_total, " +
                        "  :nel_imcs_incluso, " +
                        "  :nel_ipi_nao_incluso, " +
                        "  :nel_vinculada, " +
                        "  :nel_ncm, " +
                        "  :nel_unidade, "+
                        "  :nel_xped, " +
                        "  :nel_posicao " +
                        ") RETURNING id_nota_fiscal_entrada_linha;";
                    }
                    else
                    {
                        command.CommandText =
                        "UPDATE  " +
                        "  public.nota_fiscal_entrada_linha   " +
                        "SET  " +
                        "  id_nota_fiscal_entrada = :id_nota_fiscal_entrada, " +
                        "  nel_linha = :nel_linha, " +
                        "  nel_codigo = :nel_codigo, " +
                        "  nel_descricao = :nel_descricao, " +
                        "  nel_quantidade = :nel_quantidade, " +
                        "  nel_valor_unitario = :nel_valor_unitario, " +
                        "  nel_valor_total = :nel_valor_total, " +
                        "  nel_imcs_incluso = :nel_imcs_incluso, " +
                        "  nel_ipi_nao_incluso = :nel_ipi_nao_incluso, " +
                        "  nel_vinculada = :nel_vinculada, " +
                        "  nel_ncm = :nel_ncm, "+
                        "  nel_unidade = :nel_unidade, "+
                        "  nel_xped = :nel_xped, " +
                        "  nel_posicao = :nel_posicao " +
                        "WHERE  " +
                        "  id_nota_fiscal_entrada_linha = :id_nota_fiscal_entrada_linha " +
                        " RETURNING id_nota_fiscal_entrada_linha; ";
                    }
                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada_linha", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Pai.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_linha", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Linha;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Codigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_descricao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Descricao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_quantidade", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_valor_unitario", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.valorUnitario;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_valor_total", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.valorTotal;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_imcs_incluso", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.icmsIncluso;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_ipi_nao_incluso", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.ipiNaoIncluso;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_vinculada", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Vinculada);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_ncm", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.NCM;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_unidade", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Unidade;
                    
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_xped",NpgsqlDbType.Varchar,XPed));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_posicao", NpgsqlDbType.Integer, Posicao));

                    this.ID = Convert.ToInt32(command.ExecuteScalar());

                    if (this.Lote != null)
                    {

                        this.salvarLoteHistorico(form, ref command);
                    }

                    this.pendenteSalvar = false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a linha.\r\n" + e.Message, e);
            }
        }

        private void salvarLoteHistorico(IWTBaseForm form, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                #region Lote

                if (this.Lote.solicitacoesCompraAtuais.Count == 0)
                {

                    this.preencherSolicitacoesLote(form);
                }

                this.Lote.Salvar(ref command);

                #endregion

                if (this.Lote.Fornecedor != null)
                {
                    #region Historico

                    DateTime dataAprovacao = Configurations.DataIndependenteClass.GetData();

                    if (this.Lote.solicitacoesCompraAtuais.Count > 0)
                    {
                        if (this.Lote.solicitacoesCompraAtuais[0].Solicitacao.dataAprovacaoCompras != null)
                        {
                            dataAprovacao = this.Lote.solicitacoesCompraAtuais[0].Solicitacao.dataAprovacaoCompras.Value;
                        }


                    }

                    if (this.Material != null)
                    {

                        this.Historico = new HistoricoCompraMaterialClass(
                            this.Lote.Fornecedor,
                            null,
                            this.Pai.Numero,
                            this.Pai.dataImportacao,
                            dataAprovacao,
                            this.valorUnitario,
                            this.icmsIncluso,
                            this.ipiNaoIncluso,
                            this.ID.Value,
                            this.Material,
                            this.Lote,
                            this.Pai.Usuario,
                            this.Pai.conn);

                    }
                    else
                    {
                        if (this.Epi != null)
                        {

                            this.Historico = new HistoricoCompraEpiClass(
                                this.Lote.Fornecedor,
                                null,
                                this.Pai.Numero,
                                this.Pai.dataImportacao,
                                dataAprovacao,
                                this.valorUnitario,
                                this.icmsIncluso,
                                this.ipiNaoIncluso,
                                this.ID.Value,
                                this.Epi,
                                this.Lote,
                                this.Pai.Usuario,
                                this.Pai.conn);

                        }
                        else
                        {
                            this.Historico = new HistoricoCompraProdutoClass(
                              this.Lote.Fornecedor,
                              null,
                              this.Pai.Numero,
                              this.Pai.dataImportacao,
                              dataAprovacao,
                              this.valorUnitario,
                              this.icmsIncluso,
                              this.ipiNaoIncluso,
                              this.ID.Value,
                              this.Produto,
                              this.Lote,
                              this.Pai.Usuario,
                              this.Pai.conn);
                        }
                    }

                    this.Historico.Salvar(ref command);
                    #endregion

                    this.Lote.Salvar2(ref command);
                }
          
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }
        }

        internal void Excluir()
        {
            this.toDelete = true;
        }

        internal void setLinha(int Linha)
        {
            this.Linha = Linha;
        }

        private void preencherSolicitacoesLote(IWTBaseForm formPai)
        {
            List<SolicitacaoDisponivel> SolicitacoesInterno;
            if (this.Material != null)
            {
                SolicitacoesInterno = this.solicitacoesLivres.getSolicitacoesMaterialComSaldo(this.Material.ID);
            }
            else
            {
                if (this.Epi != null)
                {
                    SolicitacoesInterno = this.solicitacoesLivres.getSolicitacoesEpiComSaldo(this.Epi.ID);
                }
                else
                {
                    SolicitacoesInterno = this.solicitacoesLivres.getSolicitacoesProdutoComSaldo(this.Produto.ID);
                }
            }

            if (this.Pai.Fornecedor!=null)
            {
                SolicitacoesInterno = new List<SolicitacaoDisponivel>(SolicitacoesInterno.Where(a => a.Solicitacao.Fornecedor == this.Pai.Fornecedor));
            }


            double saldo = this.Lote.qtdUnidadeCompra;
            for (int i = 0; i < SolicitacoesInterno.Count; i++)
            {


                bool aprovadoDivergencia;
                AcsUsuarioClass aprovadorDivergencias;

                ValidaPrecoTributos(SolicitacoesInterno[i].Solicitacao, valorUnitario, icmsIncluso, ipiNaoIncluso, formPai, out aprovadoDivergencia, out aprovadorDivergencias);

                double qtdPorUnidadeCompra = 1;

                qtdPorUnidadeCompra = SolicitacoesInterno[i].unidadesPorUnidadeCompraProdutoMaterial;



                if (saldo <= SolicitacoesInterno[i].saldoDisponivel)
                {
                    this.Lote.adicionarSolicitacao(SolicitacoesInterno[i].Solicitacao, saldo * qtdPorUnidadeCompra, saldo,
                        SolicitacoesInterno[i].Solicitacao.ValorUnitarioCompra.HasValue ? SolicitacoesInterno[i].Solicitacao.ValorUnitarioCompra.Value : 0,
                        this.valorUnitario,
                        SolicitacoesInterno[i].Solicitacao.AliquotaICMSCompra.HasValue ? SolicitacoesInterno[i].Solicitacao.AliquotaICMSCompra.Value : 0,
                        icmsIncluso,
                        SolicitacoesInterno[i].Solicitacao.AliquotaIPICompra.HasValue ? SolicitacoesInterno[i].Solicitacao.AliquotaIPICompra.Value : 0,
                        ipiNaoIncluso,
                        aprovadoDivergencia,
                        aprovadorDivergencias

                    );
                    saldo = 0;
                }
                else
                {
                    double qtdBaixar = SolicitacoesInterno[i].saldoDisponivel;
                    this.Lote.adicionarSolicitacao(SolicitacoesInterno[i].Solicitacao, SolicitacoesInterno[i].saldoDisponivel * qtdPorUnidadeCompra, SolicitacoesInterno[i].saldoDisponivel,
                        SolicitacoesInterno[i].Solicitacao.ValorUnitarioCompra.HasValue ? SolicitacoesInterno[i].Solicitacao.ValorUnitarioCompra.Value : 0,
                        this.valorUnitario,
                        SolicitacoesInterno[i].Solicitacao.AliquotaICMSCompra.HasValue ? SolicitacoesInterno[i].Solicitacao.AliquotaICMSCompra.Value : 0,
                        icmsIncluso,
                        SolicitacoesInterno[i].Solicitacao.AliquotaIPICompra.HasValue ? SolicitacoesInterno[i].Solicitacao.AliquotaIPICompra.Value : 0,
                        ipiNaoIncluso,
                        aprovadoDivergencia,
                        aprovadorDivergencias);

                    saldo = Math.Round(saldo - qtdBaixar, 5);
                }

                if (saldo <= 0)
                {
                    break;
                }
            }

            if (saldo > 0)
            {
                double qtdMaxima = this.Lote.solicitacoesCompraAtuais.Sum(a => a.Solicitacao.saldoEntregaOriginal);
                qtdMaxima = Math.Round(qtdMaxima * margemAceite,4);

                if (saldo <= qtdMaxima)
                {
                    //Saldo está dentro da margem, ajusta a SC para receber

                    LoteSolicitacao ultimaSolicitacaoAdicionada = this.Lote.solicitacoesCompraAtuais.Last();

                    double qtdAntigaCompraSC = ultimaSolicitacaoAdicionada.Solicitacao.Quantidade;

                    double qtdPorUnidadeCompra = 1;

                    qtdPorUnidadeCompra = ultimaSolicitacaoAdicionada.Solicitacao.UnidadesUsoPorUnidadeCompra;
                    

                    //Atualiza a SC
                    ultimaSolicitacaoAdicionada.Solicitacao.Quantidade = ultimaSolicitacaoAdicionada.Solicitacao.Quantidade + saldo;
                    //ultimaSolicitacaoAdicionada.Solicitacao.lancarBaixa(saldo);
                    //Atualiza o Lote Solicitação

                    double novaQuantidadeCompraLote = ultimaSolicitacaoAdicionada.quantidadeUnidadeCompra + saldo;
                    double novaQuantidadeUsoLote = novaQuantidadeCompraLote * qtdPorUnidadeCompra;


                    ultimaSolicitacaoAdicionada.alterarQuantidade(
                        novaQuantidadeUsoLote, novaQuantidadeCompraLote);


                    saldo = 0;
                }
                else
                {
                    this.limparLote();
                    throw new Exception(
                        "Não existem Solicitações de compra abertas com quantidade suficiente para atender a quantidade selecionada.");
                }
            }
        }

        public void limparLote()
        {
            try
            {
                this.codigoItemSistema = "";
                this.descricaoItemSistema = "";

                this.Vinculada = false;

                if (this.Lote != null)
                {
                    this.Lote.removerTodasSolicitacoes();
                    this.Lote.removerTodasGavetas();
                }
                this.Lote = null;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao limpar o lote.\r\n" + e.Message, e);
            }
        }

    }
}
