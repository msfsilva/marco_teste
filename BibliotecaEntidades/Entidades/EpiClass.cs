using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class EpiClass : EpiBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EpiClass";
        protected new const string ErroDelete = "Erro ao excluir o EpiClass  ";
        protected new const string ErroSave = "Erro ao salvar o EpiClass.";
        protected new const string ErroCollectionHistoricoCompraEpiClassEpi = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
        protected new const string ErroCollectionFomularioRetiradaManualEstoqueClassEpi = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
        protected new const string ErroCollectionLoteClassEpi = "Erro ao carregar a coleção de LoteClass.";
        protected new const string ErroCollectionSolicitacaoCompraClassEpi = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
        protected new const string ErroCollectionEstoqueGavetaItemClassEpi = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
        protected new const string ErroCollectionFuncaoEpiClassEpi = "Erro ao carregar a coleção de FuncaoEpiClass.";
        protected new const string ErroCollectionFuncionarioEpiClassEpi = "Erro ao carregar a coleção de FuncionarioEpiClass.";
        protected new const string ErroCollectionEpiFornecedorClassEpi = "Erro ao carregar a coleção de EpiFornecedorClass.";
        protected new const string ErroCollectionOrcamentoCompraItemClassEpi = "Erro ao carregar a coleção de OrcamentoCompraItemClass.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 50 caracteres";
        protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
        protected new const string ErroUltimaRevisaoObrigatorio = "O campo UltimaRevisao é obrigatório";
        protected new const string ErroUltimaRevisaoComprimento = "O campo UltimaRevisao deve ter no máximo 255 caracteres";
        protected new const string ErroUnidadeMedidaUsoObrigatorio = "O campo UnidadeMedidaUso é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EpiClass.";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraEpiClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
        protected new const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
        protected new const string MensagemUtilizadoCollectionLoteClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes LoteClass:";
        protected new const string MensagemUtilizadoCollectionSolicitacaoCompraClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
        protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
        protected new const string MensagemUtilizadoCollectionFuncaoEpiClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes FuncaoEpiClass:";
        protected new const string MensagemUtilizadoCollectionFuncionarioEpiClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes FuncionarioEpiClass:";
        protected new const string MensagemUtilizadoCollectionEpiFornecedorClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes EpiFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoCompraItemClassEpi = "A entidade EpiClass está sendo utilizada nos seguintes OrcamentoCompraItemClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EpiClass está sendo utilizada.";

        #endregion

        public SugestaoKBClass _sugestaoKB = null;


        public EpiClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

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


        public override string ToString()
        {
            return this.Identificacao;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "IdentificacaoExata":
                    whereClause += " AND (UPPER(epi.epi_identificacao) LIKE UPPER('" + parametro.Fieldvalue.ToString() + "')) ";
                    return true;
                default:
                    return false;
            }
        }

        public void AdicionarFornecedor(FornecedorClass fornecedor, bool ativo, double ultimoPreco, double ipi, double icms, UnidadeMedidaClass unidadeMedidaCompra, bool preferencial, double? unidadesPorUnidadeCompra, double? loteMinimo, double? lotePadrao)
        {

            if (preferencial)
            {
                if (CollectionEpiFornecedorClassEpi.Any(a => a.Preferencial && a.Fornecedor != fornecedor))
                {
                    throw new ExcecaoTratada("Não é possível ter dois fornecedores preferenciais em um mesmo epi");
                }
            }

            if (fornecedor == null) throw new Exception("Fornecedor não informado");

            if (this.findFornecedor(fornecedor) != null)
            {
                //throw new Exception("Esse Fornecedor já está na lista de fornecedores do Epi");
                EpiFornecedorClass epiFornecedor = this.CollectionEpiFornecedorClassEpi.First(a => a.Fornecedor.Equals(fornecedor));
                epiFornecedor.UltimoPreco = ultimoPreco;
                epiFornecedor.Ipi = ipi;
                epiFornecedor.Icms = icms;
                epiFornecedor.UnidadeMedidaCompra = unidadeMedidaCompra;
                epiFornecedor.UnidadesPorUnCompra = unidadesPorUnidadeCompra;
                epiFornecedor.LotePadrao = lotePadrao;
                epiFornecedor.LoteMinimo = loteMinimo;
                epiFornecedor.Preferencial = preferencial;
            }
            else
            {


                this.CollectionEpiFornecedorClassEpi.Add(new EpiFornecedorClass(this.UsuarioAtual, this.SingleConnection)
                {
                    Epi = this,
                    Fornecedor = fornecedor,
                    Ativo = ativo,
                    UltimoPreco = ultimoPreco,
                    Ipi = ipi,
                    Icms = icms,
                    UnidadeMedidaCompra = unidadeMedidaCompra,
                    UnidadesPorUnCompra = unidadesPorUnidadeCompra,
                    LotePadrao = lotePadrao,
                    LoteMinimo = loteMinimo,
                    DataUltimaCompra = null,
                    Preferencial = preferencial
            }
                    );
            }
        }

        public void RemoverFornecedor(EpiFornecedorClass itemDeletar)
        {
            if (this.CollectionEpiFornecedorClassEpi.Contains(itemDeletar))
            {
                this.CollectionEpiFornecedorClassEpi.Remove(itemDeletar);
                this.adicionarObjetoDeletar(itemDeletar);
            }
            else
            {
                throw new Exception("Item não encontrado");
            }
        }

        private EpiFornecedorClass findFornecedor(FornecedorClass fornecedor)
        {
            return this.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor.Equals(fornecedor));
        }

        public void loadSugestaoKb()
        {
            try
            {
                if (this.ID != null && this.ID != -1)
                {

                    CalculaSugestaoKBClass calc = new CalculaSugestaoKBClass(SingleConnection);

                    this._sugestaoKB = calc.CalcularEpi(this, this.Verde, this.Amarelo,
                                                        this.Vermelho,
                                                        this.UnidadeMedidaUso.NomeUnidade, this.LotePadrao);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as sugestões.\r\n" + e.Message, e);
            }
        }

        public DateTime? calculaDataProximaUtilizacao()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText =
                    "SELECT MIN(fue_data_vencimento_prevista) as data " +
                    "FROM " +
                    " funcionario_epi " +
                    "WHERE " +
                    "  public.funcionario_epi.id_epi = " + this.ID + " AND fue_data_vencimento_prevista > NOW()";

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
                throw new Exception("Erro ao calcular a data da próxima utilização.\r\n" + e.Message, e);
            }
        }

        public DateTime? calculaDataZeraEstoque()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                double qtdAtualEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueEpi(this, ref command);

                command.CommandText =
                    "SELECT  " +
                    "  fue_data_vencimento_prevista " +
                    "FROM " +
                    " funcionario_epi " +
                    "WHERE " +
                    "  public.funcionario_epi.id_epi = " + this.ID + " AND fue_data_vencimento_prevista > NOW() " +
                    "ORDER BY fue_data_vencimento_prevista ASC ";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    return null;
                }

                read.Read();
                DateTime dataAtual = Convert.ToDateTime(read["fue_data_vencimento_prevista"]);
                do
                {
                    dataAtual = Convert.ToDateTime(read["fue_data_vencimento_prevista"]);
                    qtdAtualEstoque--;

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
                throw new Exception("Erro ao calcular a data do fim do estoque.\r\n" + e.Message, e);
            }
        }

        public DateTime calculaEntregaPrevistaCompra(int diasPCP, DateTime dataReferencia)
        {

            bool pulaSabado = !IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_PERMITIR_SC_SABADO);
            bool pulaDomingo = !IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_PERMITIR_SC_DOMINGO);

            DateTime toRet = dataReferencia.AddDays(diasPCP+ this.LeadTimeCompra);

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

        public void SetUtilizandoEstoqueSeguranca(EstoqueSeguranca estoqueSeguranca, bool manual, string entidadeGeradoraRetirada = null, KanbanAcionamentoClass kbEncerrar = null)
        {
            if (estoqueSeguranca == EstoqueSeguranca.NaoUtilizando && this.UtilizandoEstoqueSeguranca == EstoqueSeguranca.NaoUtilizando) return;

            if (estoqueSeguranca != EstoqueSeguranca.NaoUtilizando)
            {

                if (CollectionKanbanAcionamentoClassEpi.Any(a => !a.Encerrado && a.Tipo == estoqueSeguranca))
                {
                    throw new ExcecaoTratada("Já existe um registro de acionamento de Estoque de Segurança não encerrado para o tipo de estoque de segurança " + estoqueSeguranca);
                }

                //Entrada no registro de Kb
                if (!this.UtilizandoEstoqueSegurancaData.HasValue)
                {
                    //Não existe um registro
                    this.UtilizandoEstoqueSegurancaData = Configurations.DataIndependenteClass.GetData();
                }

                this.CollectionKanbanAcionamentoClassEpi.Add(new KanbanAcionamentoClass(UsuarioAtual, SingleConnection)
                {
                    Produto = null,
                    ProdutoK = null,
                    Material = null,
                    Epi = this,
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

                    if (CollectionKanbanAcionamentoClassEpi.Count(a => !a.Encerrado) == 1)
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

                    foreach (KanbanAcionamentoClass acionamento in CollectionKanbanAcionamentoClassEpi.Where(a => !a.Encerrado))
                    {
                        acionamento.Encerrar(UsuarioAtual, manual, entidadeGeradoraRetirada);
                    }
                }
            }
        }

        public EpiClass SalvarComo()
        {
            long idOriginal = this.ID;

            IWTPostgreNpgsqlCommand command = null;
            try
            {

                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

              
                
                BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
                this.ID = -1;
                this.ValidateData(ref command);


                this.CollectionFomularioRetiradaManualEstoqueClassEpi = new BindingList<FomularioRetiradaManualEstoqueClass>();
                this._valueCollectionFomularioRetiradaManualEstoqueClassEpiLoaded = true;

                this.CollectionFuncaoEpiClassEpi = new BindingList<FuncaoEpiClass>();
                this._valueCollectionFuncaoEpiClassEpiLoaded = true;

                this.CollectionFuncionarioEpiClassEpi = new BindingList<FuncionarioEpiClass>();
                this._valueCollectionFuncionarioEpiClassEpiLoaded = true;

                this.CollectionHistoricoCompraEpiClassEpi = new BindingList<HistoricoCompraEpiClass>();
                this._valueCollectionHistoricoCompraEpiClassEpiLoaded = true;

                this.CollectionLoteClassEpi = new BindingList<LoteClass>();
                this._valueCollectionLoteClassEpiLoaded = true;

                this.CollectionOrcamentoCompraItemClassEpi = new BindingList<OrcamentoCompraItemClass>();
                this._valueCollectionOrcamentoCompraItemClassEpiLoaded = true;

                this.CollectionSolicitacaoCompraClassEpi = new BindingList<SolicitacaoCompraClass>();
                this._valueCollectionSolicitacaoCompraClassEpiLoaded = true;

     
                

                foreach (EpiFornecedorClass epiFornecedorClass in this.CollectionEpiFornecedorClassEpi)
                {
                    epiFornecedorClass.LimparID();
                }

                this.Save(ref command);
                command.Transaction.Commit();

                return this;
            }
            catch (ExcecaoTratada e)
            {
                 if (command != null && command.Transaction!=null)
                {
                    command.Transaction.Rollback();
                }
                this.ID = idOriginal;
                this.RollbackChangesEntidade();
                throw;
            }
            catch (Exception e)
            { if (command != null && command.Transaction!=null)
                {
                    command.Transaction.Rollback();
                }
                this.ID = idOriginal;
                this.RollbackChangesEntidade();
                throw new ExcecaoTratada("Erro inesperao ao limpar o EPI para salvar como\r\n" + e.Message, e);
            }
        }

       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            List<EpiClass> epis = this.Search(new List<SearchParameterClass>()
                                                   {
                                                       new SearchParameterClass("IdentificacaoExata", this.Identificacao)
                                                   }).ConvertAll(a => (EpiClass)a).Where(a => a.ID != this.ID).ToList();

            if (epis.Count > 0)
            {
                throw new ExcecaoTratada("Essa Identificação já está cadastrada para o epi " + epis[0].Identificacao);
            }

            return true;
        }

        public int getSugestaoLeadtime()
        {
            try
            {
                int mesesMedia = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
                DateTime dataFim = Configurations.DataIndependenteClass.GetData().Date;
                DateTime dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1 * mesesMedia);

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
                    "  public.lote.id_epi = :id_epi ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
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


        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
          SincronizarSDC(command.Connection);

        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            long idEpiSimulador = ID + 30000000;
            ApiSimuladorCompras.SincronizarEpi(idEpiSimulador,true, UsuarioAtual, command);
        }

        public void SincronizarSDC(IWTPostgreNpgsqlConnection conn)
        {
            StringBuilder erros = new StringBuilder();

            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            long idEpiSimulador = ID + 30000000;


            ProdutoDto dto = new ProdutoDto()
            {
                id = idEpiSimulador,
                classificacao = "Epi",
                codigo = Identificacao,
                descricao = Descricao,
                unidadeMedidaId = UnidadeMedidaUso.ID
            };


            ApiSimuladorCompras.SincronizarEpi(dto.id, false, UsuarioAtual, conn);

            foreach (EpiFornecedorClass fornecedor in CollectionEpiFornecedorClassEpi)
            {
                try
                {
                    if (fornecedor.ID != -1)
                    {
                        fornecedor.SincronizarSDC(conn);
                    }
                }
                catch (Exception e)
                {
                    erros.Append(e.Message);
                }
            }

            if (erros?.Length > 0)
            {
                throw new ExcecaoTratada(erros.ToString());
            }

        }
    }
}
