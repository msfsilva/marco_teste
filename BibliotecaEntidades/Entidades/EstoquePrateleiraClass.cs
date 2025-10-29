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
     public class EstoquePrateleiraClass:EstoquePrateleiraBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do EstoquePrateleiraClass";
protected new const string ErroDelete = "Erro ao excluir o EstoquePrateleiraClass  ";
protected new const string ErroSave = "Erro ao salvar o EstoquePrateleiraClass.";
protected new const string ErroCollectionEstoqueGavetaClassEstoquePrateleira = "Erro ao carregar a coleção de EstoqueGavetaClass.";
protected new const string ErroCollectionEstoqueGavetaItemClassEstoquePrateleira = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroEstoqueObrigatorio = "O campo Estoque é obrigatório";
protected new const string ErroEstoqueCorredorObrigatorio = "O campo EstoqueCorredor é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do EstoquePrateleiraClass.";
protected new const string MensagemUtilizadoCollectionEstoqueGavetaClassEstoquePrateleira =  "A entidade EstoquePrateleiraClass está sendo utilizada nos seguintes EstoqueGavetaClass:";
protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassEstoquePrateleira =  "A entidade EstoquePrateleiraClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade EstoquePrateleiraClass está sendo utilizada.";
#endregion
        public EstoquePrateleiraClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
            return this.EstoqueCorredor+ " > " + this.Identificacao;
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
                        foreach (EstoqueGavetaClass gaveta in CollectionEstoqueGavetaClassEstoquePrateleira)
                        {
                            gaveta.Ativo = false;
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
                    whereClause += " AND (esp_identificacao ILIKE :IdentificacaoExata) ";
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
                new SearchParameterClass("EstoqueCorredor",EstoqueCorredor)
            }).Any(a => a.ID != this.ID))
            {
                throw new ExcecaoTratada("Já existe uma prateleira cadastrada com essa identificação nesse corredor.");
            }

            foreach (EstoqueGavetaClass gaveta in CollectionEstoqueGavetaClassEstoquePrateleira)
            {
                if (!Ativo && gaveta.Ativo)
                {
                    throw new ExcecaoTratada("Não é possível uma prateleira ("+this+") " + (Ativo ? "Ativa" : "Inativa") + " possuir uma Gaveta (" + gaveta + ") " + (gaveta.Ativo ? "Ativa" : "Inativa") + "");
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
            while (CollectionEstoqueGavetaClassEstoquePrateleira.Count > 0)
            {
                CollectionEstoqueGavetaClassEstoquePrateleira[0].Delete(ref command);
                CollectionEstoqueGavetaClassEstoquePrateleira.RemoveAt(0);
            }

            base.AcoesExtrasAntesDelete(ref command);
        }

        protected override bool ValidateDelete()
        {
            if (CollectionEstoqueGavetaClassEstoquePrateleira.Any(a => !a.PodeExcluir()))
            {
                throw new ExcecaoTratada("Não é possível excluir essa prateleira pois ela possui itens em suas gavetas");
            }

            return base.ValidateDelete();
        }

        public void ExcluirGaveta(EstoqueGavetaClass gaveta)
        {

            if (!this.CollectionEstoqueGavetaClassEstoquePrateleira.Contains(gaveta))
            {
                throw new ExcecaoTratada("Gaveta não encontrada na collection da prateleira: " + gaveta);
            }

            if (!gaveta.PodeExcluir())
            {
                throw new ExcecaoTratada("Não é possível excluir essa gaveta pois ela possui itens com saldo");
            }

            this.adicionarObjetoDeletar(gaveta);
            this.CollectionEstoqueGavetaClassEstoquePrateleira.Remove(gaveta);
        }

        public EstoqueGavetaClass AdicionarGaveta(string identificacao, string descricao, bool ativo)
        {
            try
            {

                if (this.CollectionEstoqueGavetaClassEstoquePrateleira.Any(a => a.Ativo && a.Identificacao.ToUpperInvariant() == identificacao.ToUpperInvariant()))
                {
                    throw new ExcecaoTratada("Já existe uma gaveta ativa e com a mesma identificação nessa prateleira");
                }

                EstoqueGavetaClass toRet = new EstoqueGavetaClass(UsuarioAtual, SingleConnection)
                {
                    Ativo = ativo,
                    Identificacao = identificacao,
                    Descricao = descricao,
                    EstoquePrateleira = this
                };

                this.CollectionEstoqueGavetaClassEstoquePrateleira.Add(toRet);

                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao adicionar a gaveta \r\n" + e.Message);
            }
        }

        public bool PodeExcluir()
        {
            foreach (EstoqueGavetaClass gaveta in CollectionEstoqueGavetaClassEstoquePrateleira.Where(a => a.Ativo))
            {
                if (!gaveta.PodeExcluir())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
