using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Operacoes.Estoque;


using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using iTextSharp.text;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class FuncionarioClass : FuncionarioBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do Funcionário";
        protected new const string ErroDelete = "Erro ao excluir o Funcionário  ";
        protected new const string ErroSave = "Erro ao salvar o Funcionário.";

        protected new const string ErroCollectionFuncionarioFuncaoClassFuncionario = "Erro ao carregar a coleção de Funções do Funcionário.";

        protected new const string ErroCollectionContaReceberClassFuncionario = "Erro ao carregar a coleção de Contas a receber.";

        protected new const string ErroCollectionFuncionarioEpiClassFuncionario = "Erro ao carregar a coleção de EPIs do Funcionário.";

        protected new const string ErroCollectionContaPagarClassFuncionario = "Erro ao carregar a coleção de Contas a pagar.";

        protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
        protected new const string ErroCpfObrigatorio = "O campo Cpf é obrigatório";
        protected new const string ErroCpfComprimento = "O campo Cpf deve ter no máximo 20 caracteres";
        protected new const string ErroEnderecoObrigatorio = "O campo Endereço é obrigatório";
        protected new const string ErroEnderecoComprimento = "O campo Endereço deve ter no máximo 255 caracteres";
        protected new const string ErroEnderecoNumeroObrigatorio = "O campo Número do endereço é obrigatório";

        protected new const string ErroEnderecoNumeroComprimento = "O campo Número do endereço deve ter no máximo 50 caracteres";

        protected new const string ErroBairroObrigatorio = "O campo Bairro é obrigatório";
        protected new const string ErroBairroComprimento = "O campo Bairro deve ter no máximo 50 caracteres";
        protected new const string ErroCepObrigatorio = "O campo Cep é obrigatório";
        protected new const string ErroCepComprimento = "O campo Cep deve ter no máximo 10 caracteres";
        protected new const string ErroUltimaRevisaoObrigatorio = "O campo Ultima Revisão é obrigatório";

        protected new const string ErroUltimaRevisaoComprimento = "O campo Ultima Revisão deve ter no máximo 255 caracteres";

        protected new const string ErroCidadeObrigatorio = "O campo Cidade é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do Funcionario.";

        protected new const string MensagemUtilizadoCollectionFuncionarioFuncaoClassFuncionario = "A entidade Funcionário está sendo utilizada nas seguintes Funções do Funcionário:";

        protected new const string MensagemUtilizadoCollectionContaReceberClassFuncionario = "A entidade Funcionário está sendo utilizada nos seguintes Contas a receber:";

        protected new const string MensagemUtilizadoCollectionFuncionarioEpiClassFuncionario = "A entidade Funcionário está sendo utilizada nos seguintes EPIs do Funcionário:";

        protected new const string MensagemUtilizadoCollectionContaPagarClassFuncionario = "A entidade Funcionário está sendo utilizada nos seguintes Contas a pagar:";

        protected new const string ErroUtilizado = "Erro ao verificar se a entidade Funcionário está sendo utilizada.";

        #endregion

        
        

        public FuncionarioClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

    

        public EstadoClass Estado
        {
            get
            {
                if (this.Cidade != null)
                {
                    return this.Cidade.Estado;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool PossuiEpisNaoDescartados
        {
            get { return CollectionFuncionarioEpiClassFuncionario.Any(a => a.Situacao != SituacaoFuncionarioEpi.Descartado); }
        }


        public override string ToString()
        {
            return this.Nome;

            
        }

        public void addFuncao(FuncaoClass funcao)
        {
            if (this.CollectionFuncionarioFuncaoClassFuncionario.Any(a => a.Funcao.Equals(funcao) && a.FimVigencia == null))
            {
                throw new Exception("Ja existe a Função vigente para o Funcionário");
            }

            this.CollectionFuncionarioFuncaoClassFuncionario.Add(new FuncionarioFuncaoClass(this.UsuarioAtual, this.SingleConnection)
            {
                Funcionario = this,
                Funcao = funcao,
                InicioVigencia = Configurations.DataIndependenteClass.GetData(),
            });
            
            foreach (FuncaoEpiClass funcaoEpi in funcao.CollectionFuncaoEpiClassFuncao )
            {
                if (!CollectionFuncionarioEpiClassFuncionario.Any(a => a.Epi.Equals(funcaoEpi.Epi) && (a.Situacao == SituacaoFuncionarioEpi.Ativo || a.Situacao == SituacaoFuncionarioEpi.Pendente)))
                {
                    this.CollectionFuncionarioEpiClassFuncionario.Add(new FuncionarioEpiClass(this.UsuarioAtual, this.SingleConnection)
                    {
                        Funcionario = this,
                        Epi = funcaoEpi.Epi,
                        Situacao = SituacaoFuncionarioEpi.Pendente
                    });
                }
            }

            this.ForceDirty();
        }

        public void removeFuncao(FuncionarioFuncaoClass itemRemover)
        {
            if (this.CollectionFuncionarioFuncaoClassFuncionario.Contains(itemRemover))
            {
                FuncionarioFuncaoClass item = this.CollectionFuncionarioFuncaoClassFuncionario.FirstOrDefault(a => a == itemRemover);
                if (item != null)
                {
                    item.FimVigencia = Configurations.DataIndependenteClass.GetData();
                }

                this.ForceDirty();
            }
            else
            {
                throw new Exception("Item não encontrado");
            }
        }

        public void addEpi(EpiClass epi)
        {

            this.CollectionFuncionarioEpiClassFuncionario.Add(new FuncionarioEpiClass(this.UsuarioAtual, this.SingleConnection)
            {
                Funcionario = this, 
                Epi = epi,
                Situacao = SituacaoFuncionarioEpi.Pendente
            });
            this.ForceDirty();
        }

        public void removeEpi(FuncionarioEpiClass item)
        {
            if (item.Situacao == SituacaoFuncionarioEpi.Pendente)
            {
                this.CollectionFuncionarioEpiClassFuncionario.Remove(item);
                this.adicionarObjetoDeletar(item);
            }
            else
            {
                item.Situacao = SituacaoFuncionarioEpi.Descartado;
                item.DataDescarte = Configurations.DataIndependenteClass.GetData();
            }
            this.ForceDirty();

        }

        public void retirarEpi(FuncionarioEpiClass item, ref IWTPostgreNpgsqlCommand command)
        {


            if (item.Situacao == SituacaoFuncionarioEpi.Pendente)
            {
                try
                {

           
                    //retirar o epi do estoque
                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoEpi(item.Epi, -1, "Retirada do estoque por utilização do funcionário", this.Nome, this.UsuarioAtual, false, ref command, true);

                    item.Situacao = SituacaoFuncionarioEpi.Ativo;
                    item.DataRetirada = Configurations.DataIndependenteClass.GetData();
                    if (item.Epi.ControleValidade)
                    {
                        item.DataVencimentoPrevista = Configurations.DataIndependenteClass.GetData().AddMonths(item.Epi.ControleValidadeMeses.Value);
                    }

                    item.Save(ref command);
                }
                catch (Exception)
                {
                    item.RollbackSomenteEntidade();
                    throw;
                }
            }
            else
            {
                throw new Exception("O Epi " + item.Epi.Identificacao + " deve estar pendente para ser retirado");
            }

        }

        public void Demitir(DateTime dataDemissao)
        {
            if (this.Ativo && !DataDemissao.HasValue)
            {
                this.DataDemissao = dataDemissao;
                this.Ativo = false;

                foreach (FuncionarioFuncaoClass funcao in CollectionFuncionarioFuncaoClassFuncionario.Where(a=>!a.FimVigencia.HasValue))
                {
                    funcao.FimVigencia = dataDemissao;
                }

                List<FuncionarioEpiClass> episRemover = CollectionFuncionarioEpiClassFuncionario.Where(a => a.Situacao != SituacaoFuncionarioEpi.Descartado).ToList();

                
                foreach (FuncionarioEpiClass epi in episRemover)
                {
                    removeEpi(epi);
                }

                bool controleRevisao = this.ControleRevisaoHabilitado;
                try
                {
                    this.ControleRevisaoHabilitado = false;
                    Save();
                }
                finally
                {
                    this.ControleRevisaoHabilitado = controleRevisao;
                }
            }
            else
            {
                throw new ExcecaoTratada("Não é possível demitir um funcionário inativo e/ou já demitido.");
            }
        }

        public void AdicionarDocumento(FuncionarioDocumentoClass documento)
        {
     
            this.CollectionFuncionarioDocumentoClassFuncionario.Add(documento);
        }

        public void ExcluirDocumento(FuncionarioDocumentoClass documento)
        {
            if (!this.CollectionFuncionarioDocumentoClassFuncionario.Contains(documento))
            {
                throw new ExcecaoTratada("O Documento " + documento.Identificacao + " não foi encontrado no funcionário");
            }

            this.CollectionFuncionarioDocumentoClassFuncionario.Remove(documento);
            this.adicionarObjetoDeletar(documento);
        }

        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            ApiEasiFinanceiroNovo.AtualizarFuncionario(this, UsuarioAtual, command);
        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            ApiEasiFinanceiroNovo.ExcluirFuncionario(this, command);
        }

    }
}
