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
     public class EstoqueClass:EstoqueBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do EstoqueClass";
protected new const string ErroDelete = "Erro ao excluir o EstoqueClass  ";
protected new const string ErroSave = "Erro ao salvar o EstoqueClass.";
protected new const string ErroCollectionEstoqueCorredorClassEstoque = "Erro ao carregar a coleção de EstoqueCorredorClass.";
protected new const string ErroCollectionEstoqueGavetaClassEstoque = "Erro ao carregar a coleção de EstoqueGavetaClass.";
protected new const string ErroCollectionEstoqueGavetaItemClassEstoque = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected new const string ErroCollectionEstoqueHistoricoValorClassEstoque = "Erro ao carregar a coleção de EstoqueHistoricoValorClass.";
protected new const string ErroCollectionEstoquePrateleiraClassEstoque = "Erro ao carregar a coleção de EstoquePrateleiraClass.";
protected new const string ErroCollectionOrdemProducaoDiferencaClassEstoque = "Erro ao carregar a coleção de OrdemProducaoDiferencaClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do EstoqueClass.";
protected new const string MensagemUtilizadoCollectionEstoqueCorredorClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes EstoqueCorredorClass:";
protected new const string MensagemUtilizadoCollectionEstoqueGavetaClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes EstoqueGavetaClass:";
protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected new const string MensagemUtilizadoCollectionEstoqueHistoricoValorClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes EstoqueHistoricoValorClass:";
protected new const string MensagemUtilizadoCollectionEstoquePrateleiraClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes EstoquePrateleiraClass:";
protected new const string MensagemUtilizadoCollectionOrdemProducaoDiferencaClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes OrdemProducaoDiferencaClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade EstoqueClass está sendo utilizada.";
#endregion
        public EstoqueClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
           return this.Identificacao.ToString();
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
                        foreach (EstoqueCorredorClass corredor in CollectionEstoqueCorredorClassEstoque)
                        {
                            corredor.Ativo = false;
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
                    whereClause += " AND (est_identificacao ILIKE :IdentificacaoExata) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("IdentificacaoExata", NpgsqlDbType.Varchar, parametro.Fieldvalue));
                    return true;
                default:
                    return false;
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (this.Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("IdentificacaoExata", this.Identificacao)
            }).Any(a => a.ID != this.ID))
            {
                throw new ExcecaoTratada("Já existe um almoxarifado cadastrado com essa identificação.");
            }

            foreach (EstoqueCorredorClass corredor in CollectionEstoqueCorredorClassEstoque)
            {
                if (!Ativo &&  corredor.Ativo)
                {
                    throw new ExcecaoTratada("Não é possível um estoque " + (Ativo ? "Ativo" : "Inativo") + " possuir um Corredor (" + corredor + ") " + (corredor.Ativo ? "Ativo" : "Inativo") + "");
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
            while (CollectionEstoqueCorredorClassEstoque.Count > 0)
            {
                CollectionEstoqueCorredorClassEstoque[0].Delete(ref command);
                CollectionEstoqueCorredorClassEstoque.RemoveAt(0);
            }

            base.AcoesExtrasAntesDelete(ref command);
        }

        protected override bool ValidateDelete()
        {
            if (CollectionEstoqueCorredorClassEstoque.Any(a => !a.PodeExcluir()))
            {
                throw new ExcecaoTratada("Não é possível excluir esse estoque pois ele possui itens em suas gavetas");
            }

            return base.ValidateDelete();
        }

        public void ExcluirCorredor(EstoqueCorredorClass corredor)
        {

            if (!this.CollectionEstoqueCorredorClassEstoque.Contains(corredor))
            {
                throw new ExcecaoTratada("Corredor não encontrado na collection do estoque: " + corredor);
            }

            if (!corredor.PodeExcluir())
            {
                throw new ExcecaoTratada("Não é possível excluir esse corredor pois ele possui itens em suas gavetas");
            }


            this.adicionarObjetoDeletar(corredor);
            this.CollectionEstoqueCorredorClassEstoque.Remove(corredor);
        }

        public EstoqueCorredorClass AdicionarCorredor(string identificacao, string descricao, bool ativo)
        {
            try
            {
                
                if (this.CollectionEstoqueCorredorClassEstoque.Any(a => a.Ativo && a.Identificacao.ToUpperInvariant() == identificacao.ToUpperInvariant()))
                {
                    throw new ExcecaoTratada("Já existe um corredor ativo e com a mesma identificação nesse almoxarifado");
                }

                EstoqueCorredorClass toRet = new EstoqueCorredorClass(UsuarioAtual,SingleConnection)
                {
                    Ativo = ativo,
                    Identificacao = identificacao,
                    Descricao = descricao,
                    Estoque = this
                };

                this.CollectionEstoqueCorredorClassEstoque.Add(toRet);

                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao adicionar o corredor \r\n" + e.Message);
            }
        }
    }
}
