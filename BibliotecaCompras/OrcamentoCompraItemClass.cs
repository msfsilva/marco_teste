using System;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaProdutos;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCompras
{
    public class OrcamentoCompraItemClass
    {
        private static EmitenteClass emitente;
        private static string emailCompras;



        internal int? idOrcamentoCompraItem { get; private set; }
        internal ProdutoClass Produto { get; private set; }
        internal MaterialClass Material { get; private set; }
        internal EpiClass Epi { get; private set; }
        internal double quantidade { get; private set; }
        internal double? valorRecebido { get; private set; }
        internal DateTime? dataRecebimento { get; private set; }
        internal AcsUsuarioClass usuarioRecebimento { get; private set; }
        internal OrcamentoCompraClass orcamentoCompra { get; private set; }
        internal double? ipiRecebimento { get; private set; }
        internal double? icmsRecebimento { get; private set; }
        internal short selecionado { get; private set; }

        #region Grid/Report Properties

        public string numeroOrcamento
        {
            get
            {
                return this.orcamentoCompra.idOrcamentoCompra.ToString();
            }
        }

        public long idProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.ID;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.ID;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.ID;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public ProdutoClass produto
        {
            get { return this.Produto; }
        }

        public MaterialClass material
        {
            get { return this.Material; }
        }

        public EpiClass epi
        {
            get { return this.Epi; }
        }

        public double Quantidade
        {
            get { return this.quantidade; }

            set { this.quantidade = value; }
        }

        public string codigoProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.Codigo;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.CodigoComFamilia;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.Identificacao;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public string descricaoProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.Descricao;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.Descricao;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.Descricao;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public string infoAdicionalProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.DescricaoAdicional;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.DescricaoAdicional;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.DescricaoAdicional;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public string unidadeCompraProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.UnidadeMedidaCompra != null ? this.Produto.UnidadeMedidaCompra.NomeUnidade : this.Produto.UnidadeMedida.NomeUnidade;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.UnidadeMedidaCompra != null ? this.Material.UnidadeMedidaCompra.NomeUnidade : this.Material.UnidadeMedida.NomeUnidade;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.UnidadeMedidaCompra != null ? this.Epi.UnidadeMedidaCompra.NomeUnidade : this.Epi.UnidadeMedidaUso.NomeUnidade;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public string unidadeUsoProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.UnidadeMedida.ToString();
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.UnidadeMedida.ToString();
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.UnidadeMedidaUso.NomeUnidade;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public double unidadesPorUnidadeCompraProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.UnidadesPorUnCompra;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.UnidadesPorUnCompra;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.UnidadesPorUnidadeCompra;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public double LotePadraoCompraProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    if (this.Produto.LotePadraoCompra.HasValue)
                        return this.Produto.LotePadraoCompra.Value;
                    return 0;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.LotePadrao;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.LotePadrao;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public string politicaEstoque
        {
            get
            {
                PoliticaEstoque toRet;

                if (this.Produto != null)
                {
                    toRet = this.Produto.PoliticaEstoque;
                }
                else
                {
                    if (this.Material != null)
                    {
                        toRet = this.Material.PoliticaEstoque;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            toRet = PoliticaEstoque.Kanban;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }

                switch (toRet)
                {
                    case PoliticaEstoque.MRP:
                        return "MRP";
                    case PoliticaEstoque.Kanban:
                        return "Kanban";
                    default:
                        return "Não Aplicável";
                }
            }
        }

        public string acabamentoProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.Acabamento.ToString();
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.Acabamento.ToString();
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return "";
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public string dimensoesProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return "";
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.MedidaCompleta;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return "";
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public string marcasHomologadas
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.MarcasHomologadas;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.MarcasHomologadas;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.MarcasHomologadas;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem Epi.");
                        }
                    }
                }
            }
        }

        public short Selecionado
        {
            get
            {
                return this.selecionado;
            }

            set { this.selecionado = value; }
        }

        public double IpiRecebimento
        {
            get
            {
                if (this.ipiRecebimento != null)
                {
                    return this.ipiRecebimento.Value;
                }
                else
                {
                    return 0;
                }
            }

            set { this.ipiRecebimento = value; }
        }
               
        public double IcmsRecebimento
        {
            get
            {
                if (this.icmsRecebimento != null)
                {
                    return this.icmsRecebimento.Value;
                }
                else
                {
                    return 0;
                }
            }

            set { this.icmsRecebimento = value; }
        }
        
        public double ValorRecebido
        {
            get
            {
                if (this.valorRecebido != null)
                {
                    return this.valorRecebido.Value;
                }
                else
                {
                    return 0;
                }
            }

            set { this.valorRecebido = value; }
        }
        
        public string DataRecebimento
        {
            get
            {
                if (this.dataRecebimento != null)
                {
                    return this.dataRecebimento.Value.ToString("dd/MM/yyyy");
                }
                return "";
                
            }
        }

        public string UsuarioRecebimento
        {
            get
            {
                if (this.usuarioRecebimento != null)
                {
                    return this.usuarioRecebimento.Name;
                }
                return "";
                
            }
        }

        //Fornecedor
        
        public string razaoFornecedor
        {
            get
            {
                return this.orcamentoCompra.razaoFornecedor;
            }
        }
        
        public string forCnpj
        {
            get
            {
                return this.orcamentoCompra.forCnpj;
            }
            
        }
        
        public string forFone1
        {
            get
            {
                return this.orcamentoCompra.forFone1;
            }
        }
        
        public string forEmail
        {
            get
            {
                return this.orcamentoCompra.forEmail;
            }

        }

        public string forEndereco
        {
            get
            {
                return this.orcamentoCompra.forEndereco;
            }
        }
       
        public string forCidade
        {
            get
            {
                return this.orcamentoCompra.forCidade;
            }
        }
        
        public string forUf
        {
            get
            {
                return this.orcamentoCompra.forUf;
            }
        }
        
        public string forContato
        {
            get
            {
                return this.orcamentoCompra.forContato;
            }
        }
        
        //Solicitante
        
        public string razaoSolictante
        {
            get
            {
                return emitente.RazaoSocial;
            }
        }

        public string cnpjSolictante
        {
            get
            {
                return emitente.Cnpj;
            }

        }

        public string foneSolictante
        {
            get 
            { 
                return emitente.Telefone;
            }
        }

        public string emailSolictante
        {
            get
            {
                return emailCompras;
            }

        }

        public string enderecoSolictante
        {
            get
            {
                return emitente.EnderecoCompleto;
            }
        }

        public string cidadeSolictante
        {
            get
            {
                return emitente.Cidade;
            }
        }

        public string ufSolictante
        {
            get
            {
                return emitente.Estado;
            }
        }

        public string contatoSolictante
        {
            get
            {
                return emitente.Contato;
            }
        }
            
        public byte[] logoEmpresa
        {
            get
            {
                return this.orcamentoCompra.logoEmpresa;
            }
            
        }

        #endregion
        
        public OrcamentoCompraItemClass(int idToLoad, IWTPostgreNpgsqlConnection conn, OrcamentoCompraClass parent, AcsUsuarioClass user)
        {
            try
            {
                IWTPostgreNpgsqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                                  "SELECT                           " +
                                  "  id_orcamento_compra_item,      " +
                                  "  id_produto,                    " +
                                  "  id_material,                   " +
                                  "  id_epi,                        " +
                                  "  oci_quantidade,                " +
                                  "  oci_valor_recebido,            " +
                                  "  oci_data_recebimento,          " +
                                  "  id_acs_usuario_recebimento,    " +
                                  "  id_orcamento_compra,           " +
                                  "  oci_ipi_recebimento,           " +
                                  "  oci_icms_recebimento           " +
                                  "FROM                             " +
                                  "  public.orcamento_compra_item   " +
                                  "WHERE " +
                                  " id_orcamento_compra_item = :id_orcamento_compra_item";

                cmd.Parameters.Clear();

                cmd.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_compra_item", NpgsqlDbType.Integer));
                cmd.Parameters[cmd.Parameters.Count - 1].Value = idToLoad;

                IWTPostgreNpgsqlDataReader read = cmd.ExecuteReader();

                read.Read();

                this.idOrcamentoCompraItem = idToLoad;
                if (read["id_produto"] != DBNull.Value)
                    this.Produto = ProdutoBaseClass.GetEntidade(Convert.ToInt32(read["id_produto"]), user, conn);                

                if (read["id_material"] != DBNull.Value)
                    this.Material = MaterialBaseClass.GetEntidade(Convert.ToInt32(read["id_material"]), user, conn);

                if (read["id_epi"] != DBNull.Value)
                    this.Epi = EpiBaseClass.GetEntidade(Convert.ToInt32(read["id_epi"]), user, conn);
                
                this.quantidade = Convert.ToDouble(read["oci_quantidade"]);
                
                if (read["oci_valor_recebido"] != DBNull.Value)
                    this.valorRecebido = Convert.ToDouble(read["oci_valor_recebido"]);
                
                if (read["oci_data_recebimento"] != DBNull.Value)
                    this.dataRecebimento = Convert.ToDateTime(read["oci_data_recebimento"]);

                if (read["id_acs_usuario_recebimento"] != DBNull.Value)
                    this.usuarioRecebimento = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_recebimento"]), LoginClass.UsuarioLogado.loggedUser, conn);

                if (read["oci_ipi_recebimento"] != DBNull.Value)
                    this.ipiRecebimento = Convert.ToDouble(read["oci_ipi_recebimento"]);

                if (read["oci_icms_recebimento"] != DBNull.Value)
                    this.icmsRecebimento = Convert.ToDouble(read["oci_icms_recebimento"]);

                this.orcamentoCompra = parent;

                read.Close();


                if (emitente == null)
                {
                    LoadEmitiente(conn);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar dados do Item do Orçamento de Compra.\r\n" + e.Message);
            }


        }

        public OrcamentoCompraItemClass(long? idProduto, long? idMaterial, long? idEpi, double qtd, AcsUsuarioClass user, OrcamentoCompraClass orc, IWTPostgreNpgsqlConnection conn)
        {
            if (idProduto != null)
            {
                this.Produto = ProdutoBaseClass.GetEntidade(idProduto.Value, user, conn);
            }
            if (idMaterial.HasValue)
            {
                this.Material = MaterialBaseClass.GetEntidade(idMaterial.Value, user, conn);
            }
            if (idEpi != null)
            {
                this.Epi = EpiBaseClass.GetEntidade(idEpi.Value, user, conn);
            }

            this.quantidade = qtd;
            this.orcamentoCompra = orc;

            if (emitente == null)
            {
                LoadEmitiente(conn);
            }
        }


        private void LoadEmitiente(IWTPostgreNpgsqlConnection conn)
        {
            PisCofinsInfo pisCofinsDefault;
            NotaFiscalFuncoesAuxiliares.CarregaEmitente(conn, out emitente,EasiEmissorNFe.Primario, out pisCofinsDefault);
            emailCompras = IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_REMETENTE);
        }



        public void save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (idOrcamentoCompraItem == null)
                {
                    command.CommandText = "INSERT INTO                      " +
                                          "  public.orcamento_compra_item   " +
                                          "(                                " +
                                          "  id_produto,                    " +
                                          "  id_material,                   " +
                                          "  id_epi,                        " +
                                          "  oci_quantidade,                " +
                                          "  oci_valor_recebido,            " +
                                          "  oci_data_recebimento,          " +
                                          "  oci_ipi_recebimento,           " +
                                          "  oci_icms_recebimento,          " +
                                          "  id_acs_usuario_recebimento,    " +
                                          "  id_orcamento_compra            " +
                                          ")                                " +
                                          "VALUES (                         " +                                         
                                          "  :id_produto,                   " +
                                          "  :id_material,                  " +
                                          "  :id_epi,                        " +
                                          "  :oci_quantidade,               " +
                                          "  :oci_valor_recebido,           " +
                                          "  :oci_data_recebimento,         " +
                                          "  :oci_ipi_recebimento,          " +
                                          "  :oci_icms_recebimento,         " +
                                          "  :id_acs_usuario_recebimento,   " +
                                          "  :id_orcamento_compra           " +
                                          ")RETURNING id_orcamento_compra_item; ";

                }
                else
                {
                    command.CommandText = "UPDATE                                                       " +
                                            "  public.orcamento_compra_item                             " +
                                            "SET                                                        " +
                                            "  id_produto = :id_produto,                                " +
                                            "  id_material = :id_material,                              " +
                                            "  id_epi = :id_epi,                                        " +
                                            "  oci_quantidade = :oci_quantidade,                        " +
                                            "  oci_valor_recebido = :oci_valor_recebido,                " +
                                            "  oci_data_recebimento = :oci_data_recebimento,            " +
                                            "  oci_ipi_recebimento = :oci_ipi_recebimento,              " +
                                            "  oci_icms_recebimento = :oci_icms_recebimento,            " +
                                            "  id_acs_usuario_recebimento = :id_acs_usuario_recebimento," +
                                            "  id_orcamento_compra = :id_orcamento_compra               " +
                                            "WHERE                                                      " +
                                            "  id_orcamento_compra_item = :id_orcamento_compra_item     " +
                                            "RETURNING id_orcamento_compra_item;                        ";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_compra_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrcamentoCompraItem;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                if (this.Produto != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Produto.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));

                if (this.Material != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Material.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));

                if (this.Epi != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Epi.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.quantidade;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_valor_recebido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.valorRecebido;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_data_recebimento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataRecebimento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_ipi_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.ipiRecebimento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_icms_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.icmsRecebimento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_recebimento", NpgsqlDbType.Integer));
                if (this.usuarioRecebimento != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.usuarioRecebimento.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.orcamentoCompra.idOrcamentoCompra;

                this.idOrcamentoCompraItem = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar Item do Orçamento de Compra.\r\n" + e.Message);
            }
        }

        public void setUsuarioRecebimento(AcsUsuarioClass acsUsuario)
        {
            this.usuarioRecebimento = acsUsuario;
        }

        public void setDataRecebimento()
        {
            this.dataRecebimento = Configurations.DataIndependenteClass.GetData();
        }
    }
}
