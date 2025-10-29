using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCompras
{
    public enum SituacaoOrcComp
    {
        Nova,
        AguardandoRetorno,
        RetornoParcial,
        Encerrada
    }

    public class OrcamentoCompraClass
    {
        public long? idOrcamentoCompra { get; private set; }
        public AcsUsuarioClass idUsuario { get; private set; }
        public DateTime dataAbertura { get; private set; }
        public int prazo { get; private set; }
        public SituacaoOrcComp situacao { get; private set; }
        public Dictionary<OrcamentoCompraItemKeyClass, OrcamentoCompraItemClass> orcamentoCompraItemList { get; private set; }
        
        private bool toDelete;
        public byte[] logoEmpresa;

        
        #region Fornecedor

        public int idFornecedor { get; private set; }
        private string _razaoFornecedor;
        public string razaoFornecedor
        {
            get
            {
                if (_forCnpj == null)
                {
                    this.loadDadosFornecedor();
                }
                return this._razaoFornecedor;
            }
        }
        private string _forCnpj;
        public string forCnpj
        {
            get
            {
                if (string.IsNullOrEmpty(_forCnpj))
                {
                    this.loadDadosFornecedor();
                }

                if (!this._forCnpj.Contains("."))
                {
                    if (this._forCnpj.Length == 14)
                    {
                        this._forCnpj =
                            this._forCnpj.Substring(0, 2) + "." +
                            this._forCnpj.Substring(2, 3) + "." +
                            this._forCnpj.Substring(5, 3) + "/" +
                            this._forCnpj.Substring(8, 4) + "-" +
                            this._forCnpj.Substring(12, 2);
                    }

                    if (this._forCnpj.Length == 11)
                    {
                        this._forCnpj =
                            this._forCnpj.Substring(0, 3) + "." +
                            this._forCnpj.Substring(3, 3) + "." +
                            this._forCnpj.Substring(6, 3) + "-" +
                            this._forCnpj.Substring(9, 2);
                    }

                }
                return this._forCnpj;
            }
        }
        private string _forFone1;
        public string forFone1
        {
            get
            {
                if (string.IsNullOrEmpty(_forFone1))
                {
                    this.loadDadosFornecedor();
                }

                if (!this._forFone1.Contains("-"))
                {
                    if (this._forFone1.Length == 10)
                    {
                        this._forFone1 = "(" + this._forFone1.Substring(0, 2) + ") " + this._forFone1.Substring(2, 4) +
                                         " - " + this._forFone1.Substring(6);
                    }
                }

                return this._forFone1;

            }
        }
        private string _forEmail;
        public string forEmail
        {
            get
            {
                if (string.IsNullOrEmpty(_forEmail))
                {
                    this.loadDadosFornecedor();
                }

                return _forEmail;
            }

        }
        private string _forEndereco;
        public string forEndereco
        {
            get
            {
                if (string.IsNullOrEmpty(_forEndereco))
                {
                    this.loadDadosFornecedor();
                }
                return this._forEndereco;
            }
        }
        private string _forCidade;
        public string forCidade
        {
            get
            {
                if (string.IsNullOrEmpty(_forCidade))
                {
                    this.loadDadosFornecedor();
                }
                return this._forCidade;
            }
        }
        private string _forUf;
        public string forUf
        {
            get
            {
                if (string.IsNullOrEmpty(_forCidade))
                {
                    this.loadDadosFornecedor();
                }
                return this._forCidade;
            }
        }
        private string _forContato;
        public string forContato
        {
            get
            {
                if (string.IsNullOrEmpty(_forContato))
                {
                    this.loadDadosFornecedor();
                }
                return this._forContato;
            }
        }
        private bool _fornecedorEnviaEmail;
        public bool fornecedorEnviaEmail
        {
            get
            {
                if (string.IsNullOrEmpty(_forCnpj))
                {
                    this.loadDadosFornecedor();
                }
                return this._fornecedorEnviaEmail;
            }
        } 

        #endregion
        
        public OrcamentoCompraClass(int? idToLoad)
            : this(idToLoad, null){}


        public OrcamentoCompraClass( int? idToLoad, byte[] logoEmpresa)
        {
            try
            {
           
                #region Logo

                byte[] tmp = logoEmpresa;

                if (tmp != null)
                {
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    //imagem.Save("C:\\teste.bmp");
                    tmp = ms.ToArray();
                    this.logoEmpresa = tmp;
                }

                #endregion




                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

                command.CommandText = "SELECT                      " +
                                      "  id_orcamento_compra,      " +
                                      "  id_fornecedor,            " +
                                      "  id_acs_usuario,           " +
                                      "  oco_data_abertura,        " +
                                      "  oco_prazo,                " +
                                      "  oco_situacao              " +
                                      "FROM                        " +
                                      "  public.orcamento_compra   " +
                                      "WHERE " +
                                      "  id_orcamento_compra = :id_orcamento_compra";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idToLoad;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                read.Read();

                if (read.HasRows)
                {

                    this.idOrcamentoCompra = idToLoad;
                    this.idFornecedor = Convert.ToInt32(read["id_fornecedor"]);
                    this.idUsuario = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),LoginClass.UsuarioLogado.loggedUser, DbConnection.Connection);
                    this.dataAbertura = Convert.ToDateTime(read["oco_data_abertura"]);
                    this.prazo = Convert.ToInt32(read["oco_prazo"]);
                    this.situacao = (SituacaoOrcComp) Enum.ToObject(typeof (SituacaoOrcComp), read["oco_situacao"]);

                    read.Close();

                    command.CommandText =
                        "SELECT id_orcamento_compra_item FROM orcamento_compra_item WHERE id_orcamento_compra = :id_orcamento_compra";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_compra",
                                                                                NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = idToLoad;

                    read = command.ExecuteReader();

                    OrcamentoCompraItemClass orcamentoCompraItem;
                    this.orcamentoCompraItemList =
                        new Dictionary<OrcamentoCompraItemKeyClass, OrcamentoCompraItemClass>();
                    while (read.Read())
                    {
                        orcamentoCompraItem = new OrcamentoCompraItemClass(
                            Convert.ToInt32(read["id_orcamento_compra_item"]), DbConnection.Connection, this, this.idUsuario);

                        OrcamentoCompraItemKeyClass key = new OrcamentoCompraItemKeyClass(
                            orcamentoCompraItem.Produto != null ? orcamentoCompraItem.Produto.ID : (long?) null,
                            orcamentoCompraItem.Material != null ? (int?) orcamentoCompraItem.Material.ID : null,
                            orcamentoCompraItem.Epi != null ? (int?) orcamentoCompraItem.Epi.ID : null);
                        
                        if (!this.orcamentoCompraItemList.ContainsKey(key))
                        {
                            this.orcamentoCompraItemList.Add(key, orcamentoCompraItem);
                        }
                        else
                        {
                            throw new Exception("Erro inesperado. Item filho duplicado");
                        }
                    }
                }
                if (!read.IsClosed) read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar dados do Orçamento.\r\n" + e.Message);
            }
        }

        public OrcamentoCompraClass(long? idOrcamentoCompra, long idFornecedor,
                                    string razaoFornecedor, AcsUsuarioClass idUsuario, DateTime dataAbertura, int prazo, SituacaoOrcComp situacao, byte[] logoEmpresa)
        {

            this.idOrcamentoCompra = idOrcamentoCompra;
            this.idFornecedor = (int) idFornecedor;
            this._razaoFornecedor = razaoFornecedor;
            this.idUsuario = idUsuario;
            this.dataAbertura = dataAbertura;
            this.prazo = prazo;
            this.situacao = situacao;


            #region Logo

            byte[] tmp = logoEmpresa;

            if (tmp != null)
            {
                MemoryStream ms = new MemoryStream(tmp);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                //imagem.Save("C:\\teste.bmp");
                tmp = ms.ToArray();
                this.logoEmpresa = tmp;
            }

            #endregion
        }

        public void ToDelete()
        {
            this.toDelete = true;
        }

        public void save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.toDelete)
                {
                    command.CommandText = "DELETE FROM orcamento_compra WHERE id_orcamento_compra = " + this.idOrcamentoCompra;
                    command.ExecuteNonQuery();
                }
                else
                {

                    if (this.idOrcamentoCompra == null)
                    {
                        command.CommandText = "INSERT INTO               " +
                                              "  public.orcamento_compra " +
                                              "(                         " +
                                              "  id_fornecedor,          " +
                                              "  id_acs_usuario,         " +
                                              "  oco_data_abertura,      " +
                                              "  oco_prazo,              " +
                                              "  oco_situacao            " +
                                              ")                         " +
                                              "VALUES (                  " +
                                              "  :id_fornecedor,         " +
                                              "  :id_acs_usuario,        " +
                                              "  NOW(),     " +
                                              "  :oco_prazo,             " +
                                              "  :oco_situacao           " +
                                              ")RETURNING id_orcamento_compra; ";
                    }
                    else
                    {
                        command.CommandText = "UPDATE                                        " +
                                                "  public.orcamento_compra                     " +
                                                "SET                                           " +
                                                "  id_fornecedor = :id_fornecedor,             " +
                                                "  id_acs_usuario = :id_acs_usuario,           " +
                                                "  oco_data_abertura = :oco_data_abertura,     " +
                                                "  oco_prazo = :oco_prazo,                     " +
                                                "  oco_situacao = :oco_situacao                " +
                                                "WHERE                                         " +
                                                "  id_orcamento_compra = :id_orcamento_compra  " +
                                                "RETURNING id_orcamento_compra;                                             ";
                    }

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_compra", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrcamentoCompra;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idFornecedor;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idUsuario.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oco_data_abertura", NpgsqlDbType.Date));
                    command.Parameters[command.Parameters.Count - 1].Value = this.dataAbertura;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oco_prazo", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.prazo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oco_situacao", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = this.situacao;

                    this.idOrcamentoCompra = Convert.ToInt32(command.ExecuteScalar());


                    foreach (OrcamentoCompraItemClass orcamentoCompraItem in orcamentoCompraItemList.Values)
                    {
                        orcamentoCompraItem.save(ref command);
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar Orçamento de Compra.\r\n" + e.Message);
            }

        }

        public void addItem(long? idProduto, long? idMaterial, long? idEpi, double qtd, IWTPostgreNpgsqlConnection conn)
        {
            if (this.orcamentoCompraItemList == null)
            {
                this.orcamentoCompraItemList = new Dictionary<OrcamentoCompraItemKeyClass, OrcamentoCompraItemClass>();
            }
            this.orcamentoCompraItemList.Add(new OrcamentoCompraItemKeyClass(idProduto, idMaterial, idEpi),
                                             new OrcamentoCompraItemClass(idProduto, idMaterial, idEpi, qtd, this.idUsuario, this,conn));
        }

        public void removeItem(long? idProduto, long? idMaterial, long? idEpi)
        {
            if (this.orcamentoCompraItemList == null)
            {
                this.orcamentoCompraItemList = new Dictionary<OrcamentoCompraItemKeyClass, OrcamentoCompraItemClass>();
            }
            this.orcamentoCompraItemList.Remove(new OrcamentoCompraItemKeyClass(idProduto, idMaterial, idEpi));
        }

        public OrcamentoCompraItemClass getItemLinha(int? idProduto, int? idMaterial, int? idEpi)
        {
            if (this.orcamentoCompraItemList == null)
            {
                this.orcamentoCompraItemList = new Dictionary<OrcamentoCompraItemKeyClass, OrcamentoCompraItemClass>();
            }
            return this.orcamentoCompraItemList[new OrcamentoCompraItemKeyClass(idProduto, idMaterial, idEpi)];
        }

        private void loadDadosFornecedor()
        {
            try
            {
                IWTPostgreNpgsqlCommand cmd = DbConnection.Connection.CreateCommand();
                cmd.CommandText =
                    "SELECT  " +
                    "  public.fornecedor.for_razao_social, " +
                    "  public.fornecedor.for_cnpj, " +
                    "  public.fornecedor.for_fone1, " +
                    "  public.fornecedor.for_email_cotacao, " +
                    "  public.fornecedor.for_endereco, " +
                    "  public.fornecedor.for_end_numero, " +
                    "  public.fornecedor.for_end_complemento, " +
                    "  public.cidade.cid_nome, " +
                    "  public.fornecedor.id_estado, " +
                    "  public.estado.est_sigla, " +
                    "  public.fornecedor.for_contato, " +
                    "  public.fornecedor.for_envio_email " +
                    "FROM " +
                    "  public.fornecedor " +
                    "  LEFT JOIN public.cidade ON (public.fornecedor.id_cidade = public.cidade.id_cidade) " +
                    "  LEFT JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                    "WHERE " +
                    "  id_fornecedor = :id_fornecedor ";


                cmd.Parameters.Clear();

                cmd.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                cmd.Parameters[cmd.Parameters.Count - 1].Value = this.idFornecedor;

                IWTPostgreNpgsqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    this._razaoFornecedor = read["for_razao_social"].ToString();
                    this._forCnpj = read["for_cnpj"].ToString();
                    this._forFone1 = read["for_fone1"].ToString();
                    this._forEmail = read["for_email_cotacao"].ToString();
                    this._forEndereco = read["for_endereco"].ToString() + ", " + read["for_end_numero"].ToString() + "  " +
                                       read["for_end_complemento"].ToString();
                    this._forFone1 = read["for_end_complemento"].ToString();
                    this._forCidade = read["cid_nome"].ToString();
                    this._forUf = read["est_sigla"].ToString();
                    this._forContato = read["for_contato"].ToString();
                    this._fornecedorEnviaEmail = Convert.ToBoolean(Convert.ToInt16(read["for_envio_email"]));
                }
                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar dados do fornecedor.\r\n" + e.Message, e);
            }
        }
        
        public void setEnviada()
        {
            this.situacao = SituacaoOrcComp.AguardandoRetorno;
        }

        public void setRetornoParcial()
        {
            this.situacao = SituacaoOrcComp.RetornoParcial;
        }

        public void setEncerrado()
        {
            this.situacao = SituacaoOrcComp.Encerrada;
        }

       
    }
}

