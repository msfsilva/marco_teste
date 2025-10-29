using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{
    public class FuncaoEpiClass : FuncaoEpiBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EPI da Função";
        protected new const string ErroDelete = "Erro ao excluir do EPI da Função  ";
        protected new const string ErroSave = "Erro ao salvar do EPI da Função.";
        protected new const string ErroFuncaoObrigatorio = "O campo Funcao é obrigatório";
        protected new const string ErroEpiObrigatorio = "O campo Epi é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EPI da Função.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EPI da Função está sendo utilizada.";

        #endregion

        

        public FuncaoEpiClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

      

        public string EpiDescricao
        {
            get { return this.Epi.Descricao; }
        }


        public override string ToString()
        {
            return "Função: " + this.Epi.ToString();
        }
        
    }
}
