using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BibliotecaEntidades.Base;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class ProdutoKClass : ProdutoKBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoKClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoKClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoKClass.";
        protected new const string ErroCollectionOrderItemEtiquetaClassProdutoK = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
        protected new const string ErroCollectionOrdemProducaoClassProdutoK = "Erro ao carregar a coleção de OrdemProducaoClass.";
        protected new const string ErroCollectionEstoqueGavetaItemClassProdutoK = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
        protected new const string ErroCollectionOrcamentoConfiguradoClassProdutoK = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
        protected new const string ErroCollectionProdutoKEtiquetaClassProdutoK = "Erro ao carregar a coleção de ProdutoKEtiquetaClass.";
        protected new const string ErroCollectionProdutoKProdutoClassProdutoK = "Erro ao carregar a coleção de ProdutoKProdutoClass.";
        protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
        protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
        protected new const string ErroDimensaoObrigatorio = "O campo Dimensao é obrigatório";
        protected new const string ErroDimensaoComprimento = "O campo Dimensao deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoKClass.";
        protected new const string MensagemUtilizadoCollectionOrderItemEtiquetaClassProdutoK = "A entidade ProdutoKClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoClassProdutoK = "A entidade ProdutoKClass está sendo utilizada nos seguintes OrdemProducaoClass:";
        protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassProdutoK = "A entidade ProdutoKClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassProdutoK = "A entidade ProdutoKClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoKEtiquetaClassProdutoK = "A entidade ProdutoKClass está sendo utilizada nos seguintes ProdutoKEtiquetaClass:";
        protected new const string MensagemUtilizadoCollectionProdutoKProdutoClassProdutoK = "A entidade ProdutoKClass está sendo utilizada nos seguintes ProdutoKProdutoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoKClass está sendo utilizada.";

        #endregion

        
        public ProdutoKClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        


        public override string ToString()
        {
            return this.Codigo + " - " + this.Dimensao;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "CodigoCaseInsensitive":
                    whereClause += " AND (UPPER(prk_codigo) LIKE '" + parametro.Fieldvalue.ToString().ToUpper() + "' OR  LOWER(prk_codigo) LIKE '" + parametro.Fieldvalue.ToString().ToLower() + "') ";
                    return true;
                case "DimensaoExata":
                    whereClause += " AND (prk_dimensao LIKE '" + parametro.Fieldvalue.ToString().ToUpper() + "') ";
                    return true;
                default:
                    return false;
            }
        }

        public void AdicionarProduto(ProdutoClass produto)
        {
            if (this.findProduto(produto) != null)
            {
                throw new Exception("Esse produto já está na lista de produtos do Agrupador");
            }

            this.CollectionProdutoKProdutoClassProdutoK.Add(new ProdutoKProdutoClass(this.UsuarioAtual, this.SingleConnection)
            {
                Produto = produto,
                ProdutoK = this
            });
        }

        public void RemoverProduto(ProdutoKProdutoClass itemDeletar)
        {
            if (this.CollectionProdutoKProdutoClassProdutoK.Contains(itemDeletar))
            {
                this.CollectionProdutoKProdutoClassProdutoK.Remove(itemDeletar);
                this.adicionarObjetoDeletar(itemDeletar);
            }
            else
            {
                throw new Exception("Item não encontrado");
            }
        }

        private ProdutoKProdutoClass findProduto(ProdutoClass produto)
        {

            return this.CollectionProdutoKProdutoClassProdutoK.FirstOrDefault(a => a.Produto.Equals(produto));
        }

        public void AdicionarEtiqueta(double quantidade)
        {
            if (this.findEtiqueta(quantidade) != null)
            {
                throw new Exception("Essa quantidade já está na lista de etiquetas do Agrupador");
            }

            this.CollectionProdutoKEtiquetaClassProdutoK.Add(new ProdutoKEtiquetaClass(this.UsuarioAtual, this.SingleConnection)
            {
                ProdutoK = this,
                QuantidadePorEtiqueta = quantidade
               
            });
        }

        public void RemoverEtiqueta(ProdutoKEtiquetaClass itemDeletar)
        {
            if (this.CollectionProdutoKEtiquetaClassProdutoK.Contains(itemDeletar))
            {
                this.CollectionProdutoKEtiquetaClassProdutoK.Remove(itemDeletar);
                this.adicionarObjetoDeletar(itemDeletar);
            }

            else
            {
                throw new Exception("Item não encontrado");
            }
        }

        private ProdutoKEtiquetaClass findEtiqueta(double quantidade)
        {
            return this.CollectionProdutoKEtiquetaClassProdutoK.FirstOrDefault(a => a.QuantidadePorEtiqueta == quantidade);
        }

        public void SetUtilizandoEstoqueSeguranca(EstoqueSeguranca estoqueSeguranca, bool manual, string entidadeGeradoraRetirada = null, KanbanAcionamentoClass kbEncerrar = null)
        {
            if (estoqueSeguranca == EstoqueSeguranca.NaoUtilizando && this.UtilizandoEstoqueSeguranca == EstoqueSeguranca.NaoUtilizando) return;

            if (estoqueSeguranca != EstoqueSeguranca.NaoUtilizando)
            {

                if (CollectionKanbanAcionamentoClassProdutoK.Any(a => !a.Encerrado && a.Tipo == estoqueSeguranca))
                {
                    throw new ExcecaoTratada("Já existe um registro de acionamento de Estoque de Segurança não encerrado para o tipo de estoque de segurança " + estoqueSeguranca);
                }

                //Entrada no registro de Kb
                if (!this.UtilizandoEstoqueSegurancaData.HasValue)
                {
                    //Não existe um registro
                    this.UtilizandoEstoqueSegurancaData = Configurations.DataIndependenteClass.GetData();
                }

                this.CollectionKanbanAcionamentoClassProdutoK.Add(new KanbanAcionamentoClass(UsuarioAtual, SingleConnection)
                {
                    Produto = null,
                    ProdutoK = this,
                    Material = null,
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

                    if (CollectionKanbanAcionamentoClassProdutoK.Count(a => !a.Encerrado) == 1)
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

                    foreach (KanbanAcionamentoClass acionamento in CollectionKanbanAcionamentoClassProdutoK.Where(a => !a.Encerrado))
                    {
                        acionamento.Encerrar(UsuarioAtual, manual, entidadeGeradoraRetirada);
                    }
                }
            }
        }


        public String LoteProducaoString
        {
            get
            {
                return LoteProducao.ToString();
            }

            set
            {
                if (value != null)
                {
                    this.LoteProducao = Convert.ToDouble(value);
                }
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {

            ProdutoClass search = new ProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
            List<ProdutoClass> produtos = search.Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("CodigoCaseInsensitive", this.Codigo),
            }).ConvertAll(a => (ProdutoClass) a);


            if (produtos.Count !=0)
            {
                throw new Exception("Não é possível cadastar um Kanban de manufaturados com o mesmo código que um produto");
            }


            
            List<ProdutoKClass> produtosK = this.Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("CodigoCaseInsensitive", this.Codigo),
                new SearchParameterClass("DimensaoExata", this.Dimensao)
            }).ConvertAll(a => (ProdutoKClass)a).Where(a => a.ID != ID).ToList();


            if (produtosK.Count != 0)
            {
                throw new Exception("Não é possível cadastar um Kanban de manufaturados com o mesmo código e dimensão de outro já cadastrado.");
            }

            return true;

        }

        public void SalvarComo(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.Search(new List<SearchParameterClass>()
                                                          {
                                                              new SearchParameterClass("CodigoCaseInsensitive", this.Codigo),
                                                              new SearchParameterClass("DimensaoExata", this.Dimensao),
                                                          }).Any())
                {
                    throw new ExcecaoTratada("Já existe um Kanban cadastrado com o código e dimensão iguais ao atual.");
                }

                this.CollectionOrcamentoConfiguradoClassProdutoK = new BindingList<OrcamentoConfiguradoClass>();
                this._valueCollectionOrcamentoConfiguradoClassProdutoKLoaded = true;

                this.CollectionOrdemProducaoClassProdutoK = new BindingList<OrdemProducaoClass>();
                this._valueCollectionOrdemProducaoClassProdutoKLoaded = true;

                this.CollectionOrderItemEtiquetaClassProdutoK = new BindingList<OrderItemEtiquetaClass>();
                this._valueCollectionOrderItemEtiquetaClassProdutoKLoaded = true;

                foreach (ProdutoKEtiquetaClass produtoKEtiquetaClass in CollectionProdutoKEtiquetaClassProdutoK)
                {
                    produtoKEtiquetaClass.LimparID();
                }

                foreach (ProdutoKProdutoClass produtoKProdutoClass in CollectionProdutoKProdutoClassProdutoK)
                {
                    produtoKProdutoClass.LimparID();
                }

                this.objetosDeletar.Clear();

                BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
                this.ID = -1;


                this.Save(ref command);

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao salvar a cópia do kanban de itens manufaturados. \r\n" + e.Message, e);
            }
        }
    }
}
