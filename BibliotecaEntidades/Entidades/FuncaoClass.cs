using System;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{
    public class FuncaoClass : FuncaoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados da Função";
        protected new const string ErroDelete = "Erro ao excluir a Função  ";
        protected new const string ErroSave = "Erro ao salvar a Função.";

        protected new const string ErroCollectionFuncionarioFuncaoClassFuncao =
            "Erro ao carregar a coleção de Funcionários.";

        protected new const string ErroCollectionFuncaoEpiClassFuncao = "Erro ao carregar a coleção de EPIs.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificação é obrigatório";

        protected new const string ErroIdentificacaoComprimento =
            "O campo Identificação deve ter no máximo 50 caracteres";

        protected new const string ErroDescricaoObrigatorio = "O campo Descrição é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descrição deve ter no máximo 255 caracteres";
        protected new const string ErroUltimaRevisaoObrigatorio = "O campo UltimaRevisao é obrigatório";

        protected new const string ErroUltimaRevisaoComprimento =
            "O campo UltimaRevisao deve ter no máximo 255 caracteres";

        protected new const string ErroValidate = "Erro ao validar os dados da Função.";

        protected new const string MensagemUtilizadoCollectionFuncionarioFuncaoClassFuncao =
            "A entidade Função está sendo utilizada nos seguintes Funcionários:";

        protected new const string MensagemUtilizadoCollectionFuncaoEpiClassFuncao =
            "A entidade Função está sendo utilizada nos seguintes EPIs:";

        protected new const string ErroUtilizado = "Erro ao verificar se a entidade Função está sendo utilizada.";

        #endregion


        public FuncaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

      

        public override string ToString()
        {
            return this.Identificacao;
        }

        public void addEpi(EpiClass epi)
        {
            if (this.CollectionFuncaoEpiClassFuncao.Any(a => a.Epi.Equals(epi)))
            {
                throw new Exception("O Epi ja existe na Função");
            }

            this.CollectionFuncaoEpiClassFuncao.Add(new FuncaoEpiClass(this.UsuarioAtual, this.SingleConnection)
            {
                Funcao = this,
                Epi = epi
            });

        }

        public void removeEpi(FuncaoEpiClass itemDeletar)
        {
            if (this.CollectionFuncaoEpiClassFuncao.Contains(itemDeletar))
            {
                this.CollectionFuncaoEpiClassFuncao.Remove(itemDeletar);
                this.adicionarObjetoDeletar(itemDeletar);
            }
            else
            {
                throw new Exception("Item não encontrado");
            }
        }
    }
}
