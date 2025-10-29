using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class EstoqueCorredorClass:EstoqueCorredorBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do EstoqueCorredorClass";
protected new const string ErroDelete = "Erro ao excluir o EstoqueCorredorClass  ";
protected new const string ErroSave = "Erro ao salvar o EstoqueCorredorClass.";
protected new const string ErroCollectionEstoqueGavetaClassEstoqueCorredor = "Erro ao carregar a coleção de EstoqueGavetaClass.";
protected new const string ErroCollectionEstoqueGavetaItemClassEstoqueCorredor = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected new const string ErroCollectionEstoquePrateleiraClassEstoqueCorredor = "Erro ao carregar a coleção de EstoquePrateleiraClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroEstoqueObrigatorio = "O campo Estoque é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do EstoqueCorredorClass.";
protected new const string MensagemUtilizadoCollectionEstoqueGavetaClassEstoqueCorredor =  "A entidade EstoqueCorredorClass está sendo utilizada nos seguintes EstoqueGavetaClass:";
protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassEstoqueCorredor =  "A entidade EstoqueCorredorClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected new const string MensagemUtilizadoCollectionEstoquePrateleiraClassEstoqueCorredor =  "A entidade EstoqueCorredorClass está sendo utilizada nos seguintes EstoquePrateleiraClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade EstoqueCorredorClass está sendo utilizada.";
#endregion
        public EstoqueCorredorClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
            return this.Estoque + " > " + this.Identificacao;
        }

        public override bool Ativo
        {
            get { return base.Ativo; }
            set
            {
                if (!value)
                {
                    if (!loading)
                    {
                        foreach (EstoquePrateleiraClass prateleira in CollectionEstoquePrateleiraClassEstoqueCorredor)
                        {
                            prateleira.Ativo = false;
                        }
                    }
                }
                base.Ativo = value;
            }
        }


        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
           switch (parametro.FieldName)
            {
                case "IdentificacaoExata":
                    whereClause += " AND (esc_identificacao ILIKE :IdentificacaoExata) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("IdentificacaoExata", NpgsqlDbType.Varchar, parametro.Fieldvalue));
                    
                    return true;
                default:
                    return false;
            }
        }
         protected override bool ValidateDataCustom(ref  IWTPostgreNpgsqlCommand command)
         {
            if (this.Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("IdentificacaoExata", this.Identificacao),
                new SearchParameterClass("Estoque",Estoque)
            }).Any(a => a.ID != this.ID))
            {
                throw new ExcecaoTratada("Já existe um corredor cadastrado com essa identificação nesse almoxarifado.");
            }

            foreach (EstoquePrateleiraClass prateleira in CollectionEstoquePrateleiraClassEstoqueCorredor)
            {
                if (!Ativo && prateleira.Ativo )
                {
                    throw new ExcecaoTratada("Não é possível um corredor ("+this+")" + (Ativo ? "Ativo" : "Inativo") + " possuir uma Prateleira (" + prateleira + ") " + (prateleira.Ativo ? "Ativa" : "Inativa") + "");
                }
            }
            return true;
         }
        protected override void InternalSaveCustom(ref  IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        protected override void AcoesExtrasAntesDelete(ref IWTPostgreNpgsqlCommand command)
        {
            while (CollectionEstoquePrateleiraClassEstoqueCorredor.Count > 0)
            {

                CollectionEstoquePrateleiraClassEstoqueCorredor[0].Delete(ref command);
                CollectionEstoquePrateleiraClassEstoqueCorredor.RemoveAt(0);
            }

            base.AcoesExtrasAntesDelete(ref command);
        }

        protected override bool ValidateDelete()
        {
            if (CollectionEstoquePrateleiraClassEstoqueCorredor.Any(a => !a.PodeExcluir()))
            {
                throw new ExcecaoTratada("Não é possível excluir esse corredor pois ele possui itens em suas gavetas");
            }

            return base.ValidateDelete();
        }

        public void ExcluirPrateleira(EstoquePrateleiraClass prateleira)
        {

            if (!this.CollectionEstoquePrateleiraClassEstoqueCorredor.Contains(prateleira))
            {
                throw new ExcecaoTratada("Prateleira não encontrada na collection do corredor: " + prateleira);
            }

            if (!prateleira.PodeExcluir())
            {
                throw new ExcecaoTratada("Não é possível excluir essa prateleira pois ela possui itens em suas gavetas");
            }

            this.adicionarObjetoDeletar(prateleira);
            this.CollectionEstoquePrateleiraClassEstoqueCorredor.Remove(prateleira);
        }

        public EstoquePrateleiraClass AdicionarPrateleira(string identificacao, string descricao, bool ativo)
        {
            try
            {

                if (this.CollectionEstoquePrateleiraClassEstoqueCorredor.Any(a => a.Ativo && a.Identificacao.ToUpperInvariant() == identificacao.ToUpperInvariant()))
                {
                    throw new ExcecaoTratada("Já existe uma prateleira ativa e com a mesma identificação nesse corredor");
                }

                EstoquePrateleiraClass toRet = new EstoquePrateleiraClass(UsuarioAtual, SingleConnection)
                {
                    Ativo = ativo,
                    Identificacao = identificacao,
                    Descricao = descricao,
                     EstoqueCorredor= this
                };

                this.CollectionEstoquePrateleiraClassEstoqueCorredor.Add(toRet);

                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao adicionar a prateleira \r\n" + e.Message);
            }
        }

        public bool PodeExcluir()
        {
            foreach (EstoquePrateleiraClass prateleira in CollectionEstoquePrateleiraClassEstoqueCorredor.Where(a=>a.Ativo))
            {
                if (!prateleira.PodeExcluir())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
