using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using BibiliotecaGerenciamentoKB;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.GerenciamentoKb;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;


namespace BibliotecaEntidades.Entidades
{
    public class MaterialClass : MaterialBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do MaterialClass";
        protected new const string ErroDelete = "Erro ao excluir o MaterialClass  ";
        protected new const string ErroSave = "Erro ao salvar o MaterialClass.";
        protected new const string ErroCollectionContratoFornecimentoClassMaterial = "Erro ao carregar a coleção de ContratoFornecimentoClass.";
        protected new const string ErroCollectionHistoricoCompraMaterialClassMaterial = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
        protected new const string ErroCollectionFomularioRetiradaManualEstoqueClassMaterial = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
        protected new const string ErroCollectionMaterialFornecedorClassMaterial = "Erro ao carregar a coleção de MaterialFornecedorClass.";
        protected new const string ErroCollectionLoteClassMaterial = "Erro ao carregar a coleção de LoteClass.";
        protected new const string ErroCollectionMaterialFiscalClassMaterial = "Erro ao carregar a coleção de MaterialFiscalClass.";
        protected new const string ErroCollectionOrdemProducaoMaterialClassMaterial = "Erro ao carregar a coleção de OrdemProducaoMaterialClass.";
        protected new const string ErroCollectionProdutoMaterialClassMaterial = "Erro ao carregar a coleção de ProdutoMaterialClass.";
        protected new const string ErroCollectionSolicitacaoCompraClassMaterial = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
        protected new const string ErroCollectionEstoqueGavetaItemClassMaterial = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
        protected new const string ErroCollectionOrcamentoCompraItemClassMaterial = "Erro ao carregar a coleção de OrcamentoCompraItemClass.";
        protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
        protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
        protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
        protected new const string ErroUnidadeMedidaObrigatorio = "O campo UnidadeMedida é obrigatório";
        protected new const string ErroFamiliaMaterialObrigatorio = "O campo FamiliaMaterial é obrigatório";
        protected new const string ErroAcabamentoObrigatorio = "O campo Acabamento é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do MaterialClass.";
        protected new const string MensagemUtilizadoCollectionContratoFornecimentoClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes ContratoFornecimentoClass:";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
        protected new const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
        protected new const string MensagemUtilizadoCollectionMaterialFornecedorClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes MaterialFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionLoteClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes LoteClass:";
        protected new const string MensagemUtilizadoCollectionMaterialFiscalClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes MaterialFiscalClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoMaterialClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes OrdemProducaoMaterialClass:";
        protected new const string MensagemUtilizadoCollectionProdutoMaterialClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes ProdutoMaterialClass:";
        protected new const string MensagemUtilizadoCollectionSolicitacaoCompraClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
        protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoCompraItemClassMaterial = "A entidade MaterialClass está sendo utilizada nos seguintes OrcamentoCompraItemClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade MaterialClass está sendo utilizada.";

        #endregion

        

        public MaterialClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        public string FamiliaCodigo
        {
            get { return this.FamiliaMaterial.Codigo; }

        }

        public string MedidaCompleta
        {
            get
            {
                return
                    this.Medida.ToString("F2", CultureInfo.CurrentCulture) + " x " +
                    this.MedidaLargura.ToString("F2", CultureInfo.CurrentCulture) + " x " +
                    this.MedidaComprimento.ToString("F2", CultureInfo.CurrentCulture);
            }
        }

        public string CodigoInterno
        {
            get { return "M" + this.ID; }
        }

        public string CodigoComFamilia
        {
            get { return this.FamiliaMaterial != null ? this.FamiliaMaterial.ToString() + " " + this.Codigo : ""; }
        }

        public string PoliticaEstoqueTela
        {
            get
            {
                switch (this.PoliticaEstoque)
                {
                    case PoliticaEstoque.MRP:
                        return "MRP";
                        break;
                    case PoliticaEstoque.Kanban:
                        return "Kanban";
                        break;
                    case PoliticaEstoque.NaoAplicavel:
                        return "Não Aplicável";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string IdentificacaoCompleta
        {
            get { return this.FamiliaMaterial.AgrupadorMaterial.ToString() + "  " + this.FamiliaMaterial.ToString() + " " + this.Codigo + "("+ CodigoInterno + ")"; }

        }

        
        public bool PossuiMargemRecebimento
        {
            get { return this.MargemRecebimento.HasValue; }
            set
            {
                if (value == false)
                {
                    this.MargemRecebimento = null;
                }
                
            }
        }

        
        public bool PossuiComprador
        {
            get { return this.Comprador != null; }
            set
            {
                if (value == false)
                {
                    this.Comprador = null;
                }

            }
        }


        
        public bool UnidadeCompraSelecionada
        {
            get { return this.UnidadeMedidaCompra != null; }
            set
            {
                if (value == false)
                {
                    this.UnidadeMedidaCompra = null;
                }

            }
        }

        public SugestaoKBClass _sugestaoKB = null;

        public SugestaoKBClass sugestaoKB
        {
            get
            {
                if (this._sugestaoKB == null)
                {
                    this.loadSugestaoKb();
                }
                return this._sugestaoKB;
            }
        }


        public override string ToString()
        {
            return this.FamiliaMaterial + " " + this.Codigo;
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "FamiliaCodigo":
                    orderByClause += " , fm1.fam_codigo " + ordenacao.ToString();
                    command.CommandText += " LEFT JOIN public.familia_material fm1 ON (public.material.id_familia_material = fm1.id_familia_material) ";
                    return true;

                case "MedidaCompleta":
                    orderByClause += " , material.mat_medida || ' x ' || mat_medida_largura || ' x ' || mat_medida_comprimento " + ordenacao.ToString();
                    return true;

                case "CodigoInterno":
                    orderByClause += " , material.id_material " + ordenacao.ToString();
                    return true;

                case "CodigoComFamilia":
                    orderByClause += " , fm2.fam_codigo || ' ' || material.mat_codigo " + ordenacao.ToString();
                    command.CommandText += " LEFT JOIN public.familia_material fm2 ON (public.material.id_familia_material = fm2.id_familia_material) ";
                    return true;

                case "PoliticaEstoqueTela":
                    orderByClause += " , CASE mat_politica_estoque WHEN 0 THEN 'MRP' WHEN 1 THEN 'Kanban' ELSE 'Não Aplicável' END " + ordenacao.ToString();
                    return true;

                case "IdentificacaoCompleta":
                    orderByClause += " , ag3.agm_identificacao || '  ' ||fm3.fam_codigo ||  ' ' || material.mat_codigo " + ordenacao.ToString();
                    command.CommandText += " LEFT JOIN public.familia_material fm3 ON (public.material.id_familia_material = fm3.id_familia_material) " +
                                           " LEFT JOIN public.agrupador_material ag3 ON (fm3.id_agrupador_material = ag3.id_agrupador_material) ";
                    return true;


                case "UnidadeCompraSelecionada":
                    orderByClause += " , id_unidade_medida_compra IS NOT NULL " + ordenacao.ToString();
                    return true;

                case "PossuiComprador":
                    orderByClause += " , id_comprador IS NOT NULL " + ordenacao.ToString();
                    return true;

                case "PossuiMargemRecebimento":
                    orderByClause += " , mat_margem_recebimento IS NOT NULL " + ordenacao.ToString();
                    return true;

                case "":
                    orderByClause += " ,  " + ordenacao.ToString();
                    return true;

                default:
                    return false;
            }
        }

       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (!string.IsNullOrWhiteSpace(this.Gtin))
            {

                if (this.Gtin.Length != 8 && this.Gtin.Length != 12 && this.Gtin.Length != 13 && this.Gtin.Length != 14)
                {
                    throw new ExcecaoTratada("O código GTIN deve ser de 8, 12, 13 ou 14 caracteres ou estar vazio");
                }

                Int64 tmp;

                if (!Int64.TryParse(this.Gtin, out tmp))
                {
                    throw new ExcecaoTratada("O código GTIN deve possuir somente números.");
                }

                List<MaterialClass> materiais = this.Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("GtinExato", this.Gtin)
                }).ConvertAll(a => (MaterialClass) a).Where(a => a.ID != this.ID).ToList();

                if (materiais.Count > 0)
                {
                    throw new ExcecaoTratada("Esse código GTIN já está cadastrado para o material " + materiais[0].IdentificacaoCompleta);
                }
            }

            if (Ativo)
            {
                MaterialClass materialDuplicado = (MaterialClass) Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("FamiliaMaterial", FamiliaMaterial),
                    new SearchParameterClass("CodigoExato", Codigo),
                    new SearchParameterClass("Ativo",true)
                }).FirstOrDefault(a => a.ID != ID);
                if (materialDuplicado != null)
                {
                    throw new ExcecaoTratada("Não é possível salvar pois o material " + materialDuplicado.CodigoInterno + " possui a mesma identificação completa do material sendo salvo: " + this.IdentificacaoCompleta);
                }

            }

            this.CollectionMaterialFornecedorClassMaterial = new BindingList<MaterialFornecedorClass>(this.CollectionMaterialFornecedorClassMaterial.OrderBy(a => a.Ativo).ToList());



            if (this.UnidadeMedidaCompra == null)
            {
                this.UnidadesPorUnCompra = 1;
            }
            else
            {
                if (this.UnidadesPorUnCompra <= 0)
                {
                    throw new ExcecaoTratada("A quantidade por unidade de compra deve ser maior do que zero");
                }
            }

            return true;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaCompletaCustom":
                    whereClause += " AND (" +
                                   " UPPER(mat_descricao) LIKE '%" + parametro.Fieldvalue.ToString().ToUpper().Trim() + "%' " +
                                   " OR LOWER(mat_descricao) LIKE '%" + parametro.Fieldvalue.ToString().ToLower().Trim() + "%' " +
                                   " OR UPPER(fm.fam_codigo) LIKE '%" + parametro.Fieldvalue.ToString().ToUpper().Trim() + "%' " +
                                   " OR LOWER(fm.fam_codigo) LIKE '%" + parametro.Fieldvalue.ToString().ToLower().Trim() + "%' " +
                                   " OR UPPER(mat_codigo) LIKE '%" + parametro.Fieldvalue.ToString().ToUpper().Trim() + "%' " +
                                   " OR LOWER(mat_codigo) LIKE '%" + parametro.Fieldvalue.ToString().ToLower().Trim() + "%' " +
                                   " OR UPPER(mat_descricao_adicional) LIKE '%" + parametro.Fieldvalue.ToString().ToUpper().Trim() + "%'" +
                                   " OR LOWER(mat_descricao_adicional) LIKE '%" + parametro.Fieldvalue.ToString().ToLower().Trim() + "%'" +
                                   " OR UPPER(fm.fam_codigo || ' ' || mat_codigo) LIKE '%" + parametro.Fieldvalue.ToString().ToUpper().Trim() + "%' " +
                                   " OR LOWER(fm.fam_codigo || ' ' || mat_codigo) LIKE '%" + parametro.Fieldvalue.ToString().ToLower().Trim() + "%' " +
                                   " OR UPPER('M' || CAST(material.id_material as VARCHAR)) LIKE '%" + parametro.Fieldvalue.ToString().ToUpper().Trim() + "%' " +
                                   " OR LOWER('M' || CAST(material.id_material as VARCHAR)) LIKE '%" + parametro.Fieldvalue.ToString().ToLower().Trim() + "%' " +
                                   ")";

                    command.CommandText += "\r\n LEFT JOIN public.familia_material fm ON (public.material.id_familia_material = fm.id_familia_material) ";
                    return true;
                case "GtinExato":
                    whereClause += " AND (material.mat_gtin LIKE '" + parametro.Fieldvalue.ToString() + "') ";
                    return true;
                case "MateriaisFornecedor":
                    if (parametro.Fieldvalue is FornecedorClass)
                    {
                        FornecedorClass fornecedor = (FornecedorClass) parametro.Fieldvalue;
                        whereClause += " AND (mf11.id_fornecedor = " + fornecedor.ID + " AND mf11.maf_ativo = 1) ";
                        command.CommandText += " INNER JOIN material_fornecedor mf11 ON material.id_material = mf11.id_material "; 
                        return true;
                    }
                    throw new ExcecaoTratada("O campo esperado na busca é do tipo FornecedorClass");
                default:
                    return false;
            }
        }

        public void SetUtilizandoEstoqueSeguranca(EstoqueSeguranca estoqueSeguranca, bool manual, string entidadeGeradoraRetirada = null, KanbanAcionamentoClass kbEncerrar = null)
        {

            if (estoqueSeguranca == EstoqueSeguranca.NaoUtilizando && this.UtilizandoEstoqueSeguranca == EstoqueSeguranca.NaoUtilizando)return;
            
            if (estoqueSeguranca != EstoqueSeguranca.NaoUtilizando)
            {

                if (CollectionKanbanAcionamentoClassMaterial.Any(a => !a.Encerrado && a.Tipo == estoqueSeguranca))
                {
                    throw new ExcecaoTratada("Já existe um registro de acionamento de Estoque de Segurança não encerrado para o tipo de estoque de segurança " + estoqueSeguranca);
                }

                //Entrada no registro de Kb
                if (!this.UtilizandoEstoqueSegurancaData.HasValue)
                {
                    //Não existe um registro
                    this.UtilizandoEstoqueSegurancaData = Configurations.DataIndependenteClass.GetData();
                }
                
                this.CollectionKanbanAcionamentoClassMaterial.Add(new KanbanAcionamentoClass(UsuarioAtual,SingleConnection)
                {
                    Produto = null,
                    ProdutoK = null,
                    Material = this,
                    Epi = null,
                    Encerrado = false,
                    Tipo = estoqueSeguranca,
                    AcsUsuarioAcionamento = UsuarioAtual,
                    DataAcionamento = DataIndependenteClass.GetData()
                });

                this.UtilizandoEstoqueSeguranca = estoqueSeguranca;
            }
            else
            {
                //Encerramento do Registro
                if (manual)
                {
                    if (kbEncerrar == null)
                    {
                        throw new Exception("Baixa de Aviso de KB Manual sem indicar origem, informe o Suporte IWT");
                    }

                    if (CollectionKanbanAcionamentoClassMaterial.Count(a => !a.Encerrado) == 1)
                    {
                        this.UtilizandoEstoqueSeguranca = EstoqueSeguranca.NaoUtilizando;
                        this.UtilizandoEstoqueSegurancaData = null;
                    }

                    kbEncerrar.Encerrar(UsuarioAtual, manual, entidadeGeradoraRetirada);


                }
                else
                {
                    this.UtilizandoEstoqueSeguranca = EstoqueSeguranca.NaoUtilizando;
                    this.UtilizandoEstoqueSegurancaData = null;

                    foreach (KanbanAcionamentoClass acionamento in CollectionKanbanAcionamentoClassMaterial.Where(a => !a.Encerrado))
                    {
                        acionamento.Encerrar(UsuarioAtual, manual, entidadeGeradoraRetirada);
                    }
                }
            }
        }

        private void loadSugestaoKb()
        {
            try
            {

                if (this.ID != -1)
                {

                    CalculaSugestaoKBClass calc = new CalculaSugestaoKBClass(SingleConnection);

                    this._sugestaoKB = calc.Calcular(this,
                                                     this.Verde,
                                                     this.Amarelo,
                                                     this.Vermelho,
                                                     this.UnidadeMedida.ToString(),
                                                     this.LotePadrao);
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar as sugestões.\r\n" + e.Message, e);
            }
        }

        public void clearSugestaoKb()
        {
            this._sugestaoKB = null;
        }

        public MaterialClass SalvarComo()
        {
            try
            {

                BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
                this.ID = -1;
                this.CollectionContratoFornecimentoClassMaterial = new BindingList<ContratoFornecimentoClass>();
                this._valueCollectionContratoFornecimentoClassMaterialLoaded = true;

                this.CollectionFomularioRetiradaManualEstoqueClassMaterial = new BindingList<FomularioRetiradaManualEstoqueClass>();
                this._valueCollectionFomularioRetiradaManualEstoqueClassMaterialLoaded = true;

                this.CollectionHistoricoCompraMaterialClassMaterial = new BindingList<HistoricoCompraMaterialClass>();
                this._valueCollectionHistoricoCompraMaterialClassMaterialLoaded = true;

                this.CollectionLoteClassMaterial = new BindingList<LoteClass>();
                this._valueCollectionLoteClassMaterialLoaded = true;

                this.CollectionOrcamentoCompraItemClassMaterial = new BindingList<OrcamentoCompraItemClass>();
                this._valueCollectionOrcamentoCompraItemClassMaterialLoaded = true;

                this.CollectionOrdemProducaoMaterialClassMaterial = new BindingList<OrdemProducaoMaterialClass>();
                this._valueCollectionOrdemProducaoMaterialClassMaterialLoaded = true;

                this.CollectionPedidoItemConfiguradoMaterialClassMaterial = new BindingList<PedidoItemConfiguradoMaterialClass>();
                this._valueCollectionPedidoItemConfiguradoMaterialClassMaterialLoaded = true;

                this.CollectionPlanoCorteItemClassMaterial = new BindingList<PlanoCorteItemClass>();
                this._valueCollectionPlanoCorteItemClassMaterialLoaded = true;

                this.CollectionProdutoMaterialClassMaterial = new BindingList<ProdutoMaterialClass>();
                this._valueCollectionProdutoMaterialClassMaterialLoaded = true;

                this.CollectionSolicitacaoCompraClassMaterial = new BindingList<SolicitacaoCompraClass>();
                this._valueCollectionSolicitacaoCompraClassMaterialLoaded = true;


                foreach (MaterialFiscalClass fiscalClass in this.CollectionMaterialFiscalClassMaterial)
                {
                    fiscalClass.LimparID();
                }

                foreach (MaterialFornecedorClass materialFornecedorClass in this.CollectionMaterialFornecedorClassMaterial)
                {
                    materialFornecedorClass.LimparID();
                }

                this.Save();

                return this;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("\r\n" + e.Message, e);
            }
        }

        public void removerFornecedorMaterial(MaterialFornecedorClass mf)
        {
            try
            {
                if (!this.CollectionMaterialFornecedorClassMaterial.Contains(mf))
                {
                    throw new ExcecaoTratada("O Fornecedor não foi encontrado vinculado nesse material");
                }

                //this.adicionarObjetoDeletar(mf);
                //this.CollectionMaterialFornecedorClassMaterial.Remove(mf);

                mf.Ativo = false;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("\r\n" + e.Message, e);
            }
        }

        public void adicionarFornecedor(FornecedorClass fornecedor, double ultimoPreco, double icmsIncluso, double ipiNaoIncluso, UnidadeMedidaClass unidadeCompra, double? qtdUnidadeUso, bool preferencial, double? loteMinimo, double? lotePadrao)
        {
            try
            {

                if (preferencial)
                {
                    if (CollectionMaterialFornecedorClassMaterial.Any(a => a.Preferencial && a.Fornecedor != fornecedor))
                    {
                        throw new ExcecaoTratada("Não é possível ter dois fornecedores preferenciais em um mesmo material");
                    }
                }

                MaterialFornecedorClass mf;
                if (this.CollectionMaterialFornecedorClassMaterial.Any(a=>a.Fornecedor==fornecedor))
                {

                    //Atualiza Fornecedor
                    mf =
                        this.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == fornecedor && a.Ativo) ??
                        this.CollectionMaterialFornecedorClassMaterial.First(a => a.Fornecedor == fornecedor);
                    mf.UltimoPreco = ultimoPreco;
                    mf.Icms = icmsIncluso;
                    mf.Ipi = ipiNaoIncluso;
                    mf.UnidadeMedidaCompra = unidadeCompra;
                    if (unidadeCompra != null)
                    {
                        mf.UnidadesPorUnCompra = qtdUnidadeUso;
                        mf.LotePadrao = lotePadrao;
                        mf.LoteMinimo = loteMinimo;
                    }
                    else
                    {
                        mf.UnidadesPorUnCompra = null;
                        mf.LotePadrao = null;
                        mf.LoteMinimo = null;
                    }
                    mf.Ativo = true;

                    mf.Preferencial = preferencial;

                    return;
                }

                mf = new MaterialFornecedorClass(this.UsuarioAtual, this.SingleConnection)
                {
                    Material = this,
                    Fornecedor = fornecedor,
                    UltimoPreco = ultimoPreco,
                    Icms = icmsIncluso,
                    Ipi = ipiNaoIncluso,
                    UnidadeMedidaCompra = unidadeCompra,
                    Ativo = true,
                    Preferencial = preferencial
                };

                if (unidadeCompra != null)
                {
                    mf.UnidadesPorUnCompra = qtdUnidadeUso;
                    mf.LotePadrao = lotePadrao;
                    mf.LoteMinimo = loteMinimo;
                }
                else
                {
                    mf.UnidadesPorUnCompra = null;
                    mf.LotePadrao = null;
                    mf.LoteMinimo = null;
                }

                this.CollectionMaterialFornecedorClassMaterial.Add(mf);


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao adicionar ou atualizar o fornecedor do material\r\n" + e.Message, e);
            }
        }

        public DateTime calculaEntregaPrevistaCompra(DateTime dataReferencia)
        {
            int leadtimePCP = int.Parse(Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.DIAS_PROGRAMACAO_PCP));
            int leadtimeCompra = int.Parse(Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.DIAS_PROGRAMACAO_COMPRAS));

            bool pulaSabado = !IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_PERMITIR_SC_SABADO);
            bool pulaDomingo = !IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_PERMITIR_SC_DOMINGO);
            
            DateTime toRet = dataReferencia.AddDays(leadtimePCP + leadtimeCompra + this.LeadTimeCompra);

            if (pulaSabado && toRet.DayOfWeek == DayOfWeek.Saturday)
            {
                toRet = toRet.AddDays(1);
            }

            if (pulaDomingo && toRet.DayOfWeek == DayOfWeek.Sunday)
            {
                toRet = toRet.AddDays(1);
            }

            return toRet;
        }

        public DateTime? calculaDataProximaUtilizacao()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = (this.SingleConnection ?? this.SingleConnection).CreateCommand();
                command.CommandText =
                    "SELECT MIN(pei_data_entrega) as data  " +
                    "FROM " +
                    "    pedido_item_configurado_material mat " +
                    "    JOIN order_item_etiqueta ord ON mat.id_order_item_etiqueta = ord.id_order_item_etiqueta " +
                    "JOIN pedido_item ped ON ord.id_pedido_item_linha_principal_pedido = ped.id_pedido_item " +
                    "WHERE " +
                    "    (ped.pei_status = 0 OR ped.pei_status = 3) AND " +
                    "mat.id_material = :id_material ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material",NpgsqlDbType.Bigint,ID));

                object tmp = command.ExecuteScalar();

                if (tmp == null || tmp == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToDateTime(tmp);
                }
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao calcular a data da próxima utilização.\r\n" + e.Message, e);
            }
        }

        public DateTime? calculaDataZeraEstoque()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = (this.SingleConnection ?? this.SingleConnection).CreateCommand();
                double qtdAtualEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueMaterial(this, ref command);

                command.CommandText =

                    "    SELECT " +
                    "pei_data_entrega, " +
                    "SUM((mat.pcm_quantidade_total * (oie_saldo / ord.oie_quantidade))) as qtd " +
                    "FROM " +
                    "    pedido_item_configurado_material mat " +
                    "    JOIN order_item_etiqueta ord ON mat.id_order_item_etiqueta = ord.id_order_item_etiqueta " +
                    "JOIN pedido_item ped ON ord.id_pedido_item_linha_principal_pedido = ped.id_pedido_item " +
                    "WHERE " +
                    "    (ped.pei_status = 0 OR ped.pei_status = 3) AND " +
                    "mat.id_material = :id_material " +
                    "GROUP BY pei_data_entrega " +
                    "    ORDER BY pei_data_entrega ASC ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Bigint, ID));
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    return null;
                }

                read.Read();
                DateTime dataAtual;
                do
                {
                    dataAtual = Convert.ToDateTime(read["pei_data_entrega"]);
                    qtdAtualEstoque -= Convert.ToDouble(read["qtd"]);

                } while (qtdAtualEstoque > 0 && read.Read());

                read.Close();

                if (qtdAtualEstoque > 0)
                {
                    return null;
                }
                else
                {
                    return dataAtual;
                }

            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao calcular a data do fim do estoque.\r\n" + e.Message, e);
            }
        }

        public int getSugestaoLeadtime()
        {
            try
            {
                int mesesMedia = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
                DateTime dataFim = Configurations.DataIndependenteClass.GetData().Date;
                DateTime dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1*mesesMedia);

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  CAST (ceil(AVG( public.lote.lot_data_recebimento - CAST (public.ordem_compra.orc_data_envio AS DATE))) AS INTEGER)  " +
                    "FROM " +
                    "  public.lote " +
                    "  INNER JOIN public.lote_solicitacao_compra ON (public.lote.id_lote = public.lote_solicitacao_compra.id_lote) " +
                    "  INNER JOIN public.solicitacao_compra ON (public.lote_solicitacao_compra.id_solicitacao_compra = public.solicitacao_compra.id_solicitacao_compra) " +
                    " INNER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                    "WHERE " +
                    "  public.lote.lot_data_recebimento BETWEEN :inicio AND :termino AND  " +
                    "  public.lote.id_material = :id_material ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("inicio", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataInicio;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("termino", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataFim;

                int? leadtimeCalculado = command.ExecuteScalar() as int?;

                return leadtimeCalculado ?? 0;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao identificar o leadtime sugerido\r\n" + e.Message, e);
            }
        }

        protected override void CalcularCamposAntesValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {
            if (Math.Abs(this.UnidadesPorUnCompra) < 0.0001)
            {
                UnidadesPorUnCompra = 1;
            }
        }

        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            SincronizarSDC(command.Connection);
        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            long idMaterialSimulador = ID + 20000000;
            ApiSimuladorCompras.SincronizarMaterial(idMaterialSimulador, true, UsuarioAtual, command);
        }

        public void SincronizarSDC(IWTPostgreNpgsqlConnection conn)
        {
            StringBuilder erros = new StringBuilder();
            
            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            long idMaterialSimulador = ID + 20000000;

            if (Ativo)
            {
                ProdutoDto dto = new ProdutoDto()
                {
                    id = idMaterialSimulador,
                    classificacao = "Material",
                    codigo = IdentificacaoCompleta,
                    descricao = Descricao,
                    unidadeMedidaId = UnidadeMedida.ID
                };

                ApiSimuladorCompras.SincronizarMaterial(dto.id, false, UsuarioAtual, conn);

                foreach (MaterialFornecedorClass materialFornecedor in CollectionMaterialFornecedorClassMaterial)
                {
                    try
                    {
                        if (materialFornecedor.ID != -1)
                        {
                            materialFornecedor.SincronizarSDC(conn);
                        }
                    }
                    catch (Exception e)
                    {
                        erros.Append(e.Message);
                    }
                }
            }
            else
            {
                ApiSimuladorCompras.SincronizarMaterial(idMaterialSimulador, true, UsuarioAtual, conn);
            }

            if (erros?.Length > 0)
            {
                throw new ExcecaoTratada(erros.ToString());
            }
        }
    }


}
