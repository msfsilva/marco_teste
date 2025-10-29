using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades
{
    public class ProdutoPrecoClass : ProdutoPrecoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoPrecoClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoPrecoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoPrecoClass.";
        protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
        protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoPrecoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoPrecoClass está sendo utilizada.";

        #endregion

        

        public ProdutoPrecoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        
        public bool Vigente
        {
            get { return !this.FimVigencia.HasValue; }
        }


   
        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
        }

        public string PoliticaPrecoTela
        {
            get { return this.Produto.PoliticaPrecoTela; }
        }

        
        public string InicioVigenciaFormatada
        {
            get { return this.InicioVigencia.ToString("dd/MM/yyyy"); }

        }

        public string ClienteProduto
        {
            get
            {
                if (this.Produto.Cliente != null)
                {
                    return this.Produto.Cliente.ToString();
                }
                return "";
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PrecoFixo
        {
            get { return this.Produto != null && this.Produto.CalculoPreco == TipoCalculoPrecoProdudo.Fixo; }
            set
            {
                if (this.Produto != null && value)
                {
                    this.Produto.CalculoPreco = TipoCalculoPrecoProdudo.Fixo;
                    
                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PrecoVariavelRegra
        {
            get { return this.Produto != null && this.Produto.CalculoPreco == TipoCalculoPrecoProdudo.VariavelRegra; }
            set
            {
                if (this.Produto != null && value)
                {
                    this.Produto.CalculoPreco = TipoCalculoPrecoProdudo.VariavelRegra;

                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PrecoSomarFilhos
        {
            get
            {
                return
                    this.Produto != null && (
                        this.Produto.CalculoPreco == TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados ||
                        this.Produto.CalculoPreco == TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido ||
                        this.Produto.CalculoPreco == TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedidoEEstrutura);
            }
            set
            {
                if (value)
                {
                    if ( this.Produto != null && 
                        this.Produto.CalculoPreco != TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados &&
                        this.Produto.CalculoPreco != TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido &&
                        this.Produto.CalculoPreco != TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedidoEEstrutura
                        )
                    {
                        this.Produto.CalculoPreco = TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido;
                    }
                }
                
            }

        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PrecoVariavelSomaFilhosPedidoSelecionados
        {
            get { return this.Produto != null && this.Produto.CalculoPreco == TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados; }
            set
            {
                if (this.Produto != null && value)
                {
                    this.Produto.CalculoPreco = TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados;

                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PrecoVariavelSomaTodosFilhosPedido
        {
            get { return this.Produto != null && this.Produto.CalculoPreco == TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido; }
            set
            {
                if (this.Produto != null && value)
                {
                    this.Produto.CalculoPreco = TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido;

                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool PrecoVariavelSomaTodosFilhosPedidoEEstrutura
        {
            get { return this.Produto != null && this.Produto.CalculoPreco == TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedidoEEstrutura; }
            set
            {
                if (this.Produto != null && value)
                {
                    this.Produto.CalculoPreco = TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedidoEEstrutura;

                }
            }
        }

        
        public string ProdutoDescricao
        {
            get { return Produto.Descricao; }
        }

        public DateTime? DataUltimaVenda
        {
            get
            {
                OrderItemEtiquetaClass pedidoPai = this.Produto.CollectionOrderItemEtiquetaClassProduto.Where(a => a.PedidoItemLinhaPrincipalPedido != null).OrderByDescending(a => a.PedidoItemLinhaPrincipalPedido.DataEntrada).FirstOrDefault();
                if (pedidoPai != null)
                {
                    return pedidoPai.PedidoItemLinhaPrincipalPedido.DataEntrada;
                }
                return null;

                
            }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Vigentes":
                    bool? vigente = parametro.Fieldvalue as bool?;
                    if (vigente.HasValue)
                    {
                        if (vigente.Value)
                        {
                            whereClause += " AND (prp_fim_vigencia IS NULL) ";
                        }
                    }
                    else
                    {
                        throw new Exception("Parâmetro de tipo Inválido");
                    }
                    return true;

                case "Encerradas":
                    bool? encerradas = parametro.Fieldvalue as bool?;
                    if (encerradas.HasValue)
                    {
                        if (encerradas.Value)
                        {
                            whereClause += " AND (prp_fim_vigencia IS NOT NULL) ";
                        }
                    }
                    else
                    {
                        throw new Exception("Parâmetro de tipo Inválido");
                    }
                    return true;
                case "BuscaCompleta":
                    whereClause += " AND ( " +
                                   " produto_preco.prp_regra ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " produto_preco.prp_justificativa ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pppp1.pro_codigo ILIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " pppp1.pro_descricao ILIKE '%" + parametro.Fieldvalue + "%' " +
                                   ") ";

                    command.CommandText +="  INNER JOIN public.produto pppp1 ON (public.produto_preco.id_produto = pppp1.id_produto) ";
                        
                    return true;

                case "BuscaClienteString":
                    command.CommandText += "  INNER JOIN public.produto pppp4 ON (public.produto_preco.id_produto = pppp4.id_produto) ";
                    command.CommandText += "  LEFT OUTER JOIN public.cliente cccc1 ON (cccc1.id_cliente = pppp4.id_cliente) ";

                    whereClause += " AND (" +
                                   " cccc1.cli_nome_resumido ILIKE :BuscaClienteString " +
                                   ") ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("BuscaClienteString", NpgsqlDbType.Varchar, "%"+parametro.Fieldvalue+"%"));
                    return true;
                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "PoliticaPrecoTela":
                    orderByClause += ", ProdutoPoliticaPrecoTela.pro_calculo_preco " + ordenacao.ToString() + " ";
                    command.CommandText += " JOIN produto ProdutoPoliticaPrecoTela ON ProdutoPoliticaPrecoTela.id_produto = produto_preco.id_produto ";
                    return true;
                case "ProdutoDescricao":
                    orderByClause += ", pppp2.pro_descricao " + ordenacao.ToString() + " ";
                    command.CommandText += "  INNER JOIN public.produto pppp2 ON (public.produto_preco.id_produto = pppp2.id_produto) ";
                    return true;
                case "DataUltimaVenda":

                    orderByClause += ", puv3.ultima_data_entrada " + ordenacao.ToString() + " ";
                    command.CommandText += "  INNER JOIN public.produto pppp3 ON (public.produto_preco.id_produto = pppp3.id_produto) " +
                                           "  LEFT OUTER JOIN public.produto_ultima_venda puv3 ON pppp3.id_produto = puv3.id_produto ";
                    return true;

                case "ClienteProduto":
                    orderByClause += ", cccs1.cli_nome_resumido " + ordenacao.ToString() + " ";
                    command.CommandText += "  INNER JOIN public.produto pppps4 ON (public.produto_preco.id_produto = pppps4.id_produto) ";
                    command.CommandText += "  LEFT OUTER JOIN public.cliente cccs1 ON (cccs1.id_cliente = pppps4.id_cliente) ";
                    return true;

                case "InicioVigenciaFormatada":
                    orderByClause += ", prp_inicio_vigencia " + ordenacao.ToString() + " ";
                    return true;

                default:
                    return false;
            }
        }

        public void LimparID()
        {
            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;
        }

        protected override void InitClass()
        {
            this.ControleRevisaoHabilitado = false;
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            //Teste de 2020 incluído para ignorar registros mto antigos no banco de dados da mqa
            if (FimVigencia.HasValue && FimVigencia.Value.Year >= 2020)
            {
                if (InicioVigencia > FimVigencia.Value)
                {
                    throw new ExcecaoTratada("Erro no cadastro de preço do produto " + this.Produto + ": A data de término da vigência (" + FimVigencia.Value.ToString("dd/MM/yyyy") + ") deve ser maior ou igual a data de inicio" + InicioVigenciaFormatada + "");
                }
            }


            return base.ValidateDataCustom(ref command);
        }

        public ProdutoPrecoClass Revisar()
        {
            if ((this.ID == -1))
            {
                this.Justificativa = "Cadastro Inicial";
                this.AcsUsuario = UsuarioAtual;
                this.FimVigencia = null;

                IWTPostgreNpgsqlCommand command = null;

                try
                {
                    command = SingleConnection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();


                    this.Save(ref command);
                    if (!this.Produto.CollectionProdutoPrecoClassProduto.Contains(this))
                    {
                        this.Produto.CollectionProdutoPrecoClassProduto.Add(this);
                    }
                    this.Produto.CadastroPreco = true;

                    this.Produto.DesabilitarJustificativaRevisaoProduto = true;
                    this.Produto.Save(ref command);
                    this.Produto.DesabilitarJustificativaRevisaoProduto = false;

                    command.Transaction.Commit();

                    return this;
                }
                catch (ExcecaoTratada e)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }

                    this.RollbackSomenteEntidade();
                    throw;
                }
                catch (Exception e)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }

                    this.RollbackSomenteEntidade();
                    throw new ExcecaoTratada("Erro inesperao ao revisar o preço\r\n" + e.Message, e);
                }
            }
            else
            {
                if (!this.FimVigencia.HasValue)
                {
                    throw new Exception("Fim da Vigência Inválido");
                }

                if (InicioVigencia > FimVigencia.Value)
                {
                    throw new ExcecaoTratada("A data de término da vigência deve ser maior ou igual a data de inicio ");
                }

                if (this.Justificativa.Trim().Length < 10)
                {
                    throw new ExcecaoTratada("A justificativa deve ter ao menos 10 caracteres válidos");
                }


                long idOriginal = this.ID;

                DateTime dataFimVigencia = this.FimVigencia.Value;

                IWTPostgreNpgsqlCommand command = null;

                try
                {
                    command = SingleConnection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    

                    ProdutoPrecoClass novaRevisao = CopiarEntidade(this, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                    this.RollbackSomenteEntidade();
                    this.FimVigencia = dataFimVigencia;

                    novaRevisao.FimVigencia = null;
                    novaRevisao.InicioVigencia = dataFimVigencia;
                    novaRevisao.AcsUsuario = LoginClass.UsuarioLogado.loggedUser;
                    this.Produto.CollectionProdutoPrecoClassProduto.Add(novaRevisao);

                    this.Produto.CadastroPreco = true;

                    this.Produto.DesabilitarJustificativaRevisaoProduto = true;
                    this.Produto.Save(ref command);
                    this.Produto.DesabilitarJustificativaRevisaoProduto = false;

                    command.Transaction.Commit();

                    return this;
                }
                catch (ExcecaoTratada e)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    this.ID = idOriginal;
                    this.RollbackSomenteEntidade();
                    throw;
                }
                catch (Exception e)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    this.ID = idOriginal;
                    this.RollbackSomenteEntidade();
                    throw new ExcecaoTratada("Erro inesperao ao revisar o preço\r\n" + e.Message, e);
                }
            }
        }
    }
}
