using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;


namespace BibliotecaEntidades.Entidades
{
    public class RecursoClass : RecursoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do RecursoClass";
        protected new const string ErroDelete = "Erro ao excluir o RecursoClass  ";
        protected new const string ErroSave = "Erro ao salvar o RecursoClass.";
        protected new const string ErroCollectionOrdemProducaoRecursoClassRecurso = "Erro ao carregar a coleção de OrdemProducaoRecursoClass.";
        protected new const string ErroCollectionProdutoRecursoClassRecurso = "Erro ao carregar a coleção de ProdutoRecursoClass.";
        protected new const string ErroCollectionEstoqueGavetaItemClassRecurso = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
        protected new const string ErroPostoTrabalhoObrigatorio = "O campo PostoTrabalho é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do RecursoClass.";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoRecursoClassRecurso = "A entidade RecursoClass está sendo utilizada nos seguintes OrdemProducaoRecursoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoRecursoClassRecurso = "A entidade RecursoClass está sendo utilizada nos seguintes ProdutoRecursoClass:";
        protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassRecurso = "A entidade RecursoClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade RecursoClass está sendo utilizada.";

        #endregion

        

        public RecursoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public bool TipoNormal
        {
            get
            {
                if (this.Tipo == TipoRecurso.Normal)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    this.Tipo = TipoRecurso.Normal;
            }
        }

        public bool TipoFormulario
        {
            get
            {
                if (this.Tipo == TipoRecurso.Formulario)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    this.Tipo = TipoRecurso.Formulario;
            }
        }

        public bool TipoCnc
        {
            get
            {
                if (this.Tipo == TipoRecurso.CNC)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    this.Tipo = TipoRecurso.CNC;
            }
        }

        public EstoqueClass Estoque
        {
            get
            {
                return this.EstoqueGaveta != null ? this.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor.Estoque : null;
            }
        }

     

        public EstoqueCorredorClass EstoqueCorredor
        {
            get
            {
                return this.EstoqueGaveta != null ? this.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor: null;
            }
        }

        public EstoquePrateleiraClass EstoquePrateleira
        {
            get
            {
                return this.EstoqueGaveta != null ? this.EstoqueGaveta.EstoquePrateleira: null;
            }

        }

        private EstoqueGavetaClass _valueEstoqueGaveta;
        public EstoqueGavetaClass EstoqueGaveta
        {
            get
            {
                if (this._valueEstoqueGaveta == null)
                {
                    this.LoadEstoque();
                }

                return this._valueEstoqueGaveta;
            }
            set
            {
                this._valueEstoqueGaveta = value;

            }
        }

        public EstoqueGavetaClass EstoqueGavetaAnterior { get; set; }







        public override string ToString()
        {
            return this.FamiliaRecurso.Identificacao + " " + Codigo + " " + Revisao;
        }

        public string IdentificacaoCompleta
        {
            get { return this.FamiliaRecurso.Identificacao + " " + Codigo; }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "CodigoCaseInsensitive":
                    whereClause += " AND (UPPER(public.recurso.rec_codigo) LIKE :codigo_exato OR LOWER(public.recurso.rec_codigo) LIKE :codigo_exato)";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("codigo_exato", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = parametro.Fieldvalue;
                    return true;

                case "RevisaoExato":
                    whereClause += " AND (UPPER(public.recurso.rec_revisao) LIKE :revisao_exato OR LOWER(public.recurso.rec_revisao) LIKE :revisao_exato)";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("revisao_exato", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = parametro.Fieldvalue;
                    return true;
                default:
                    return false;
            }
        }

       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (TipoCnc)
            {
                if (string.IsNullOrEmpty(DiretorioOrigem))
                {
                    throw new Exception("Para o tipo CNC o campo Arquivo é obrigatório.");
                }

                if (string.IsNullOrEmpty(DiretorioDestino))
                {
                    throw new Exception("Para o tipo CNC o campo Destino é obrigatório.");
                }
            }

            if (TipoFormulario)
            {
                if (string.IsNullOrEmpty(DiretorioOrigem))
                {
                    throw new Exception("Para o tipo Formulário o campo Arquivo é obrigatório.");
                }
            }

            //Duplicado

            IList<RecursoClass> recursos = this.Search(new List<SearchParameterClass>()
                                                           {
                                                               new SearchParameterClass("CodigoCaseInsensitive", this.Codigo),
                                                               new SearchParameterClass("FamiliaRecurso", this.FamiliaRecurso),
                                                               new SearchParameterClass("RevisaoExato", this.Revisao),
                                                           }).ConvertAll(a => (RecursoClass) a).ToList();

            if (recursos.Any(a => a.ID != this.ID))
            {
                throw new ExcecaoTratada("Já existe um recurso cadastrado com identificação, revisão  e familia iguais ao atuais.");
            }

            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (!this.EstoqueGaveta.Equals(this.EstoqueGavetaAnterior))
            {
                EstoqueGavetaItemClass gavetaItem = EstoqueMovimentacao.BuscaGavetaItemRecurso(this);

                if (gavetaItem != null)
                {
                    EstoqueMovimentacao.TrocaItemGavetaTotalRecurso(gavetaItem, this.EstoqueGaveta, this, this.UsuarioAtual, ref command);
                }
                else
                {
                    EstoqueMovimentacao.LancaMovimentoEstoqueRecurso(this.EstoqueGaveta, this, 1, "Inclusão na Gaveta", "Cadastro", this.UsuarioAtual, false, ref command);
                }

                this.EstoqueGavetaAnterior = null;
                this.LoadEstoque(ref command);

            }
        }
        private void LoadEstoque()
        {
            IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
            this.LoadEstoque(ref command);
        }

        private void LoadEstoque(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.ID == -1)
                {
                    return;
                }

                List<EstoqueGavetaClass> gavetas = EstoqueMovimentacao.BuscaTodasGavetasRecursos(this);
                if (gavetas.Count>0)
                {
                    this.EstoqueGaveta = gavetas[0];
                    this.EstoqueGavetaAnterior = this.EstoqueGaveta;
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao carregar o estoque do recurso.\r\n" + e.Message, e);
            }
        }

        public void SalvarComo(ref IWTPostgreNpgsqlCommand command)
        {

            try
            {


                IList<RecursoClass> recursos = this.Search(new List<SearchParameterClass>()
                                                               {
                                                                   new SearchParameterClass("CodigoCaseInsensitive", this.Codigo),
                                                                   new SearchParameterClass("FamiliaRecurso", this.FamiliaRecurso),
                                                                   new SearchParameterClass("RevisaoExato", this.Revisao),
                                                               }).ConvertAll(a => (RecursoClass) a).ToList();

                BufferAbstractEntity.invalidarEntidade(this.GetType(),this.ID);

                if (recursos.Any())
                {
                    throw new ExcecaoTratada("Já existe um recurso cadastrado com identificação, revisão  e familia iguais ao atuais.");
                }
                this.ID = -1;

                this.DataInicio = Configurations.DataIndependenteClass.GetData();
                this.DataTermino = null;

                this.CollectionOrdemProducaoRecursoClassRecurso = new BindingList<OrdemProducaoRecursoClass>();
                this._valueCollectionOrdemProducaoRecursoClassRecursoLoaded = true;

                this.CollectionProdutoRecursoClassRecurso = new BindingList<ProdutoRecursoClass>();
                this._valueCollectionProdutoRecursoClassRecursoLoaded = true;

                EstoqueGavetaAnterior = null;

                this.Save(ref command);

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao salvar como o recurso\r\n" + e.Message, e);
            }
        }
    }
}
