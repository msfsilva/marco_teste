using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class FuncionarioFuncaoClass : FuncionarioFuncaoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do FuncionarioFuncaoClass";
        protected new const string ErroDelete = "Erro ao excluir o FuncionarioFuncaoClass  ";
        protected new const string ErroSave = "Erro ao salvar o FuncionarioFuncaoClass.";
        protected new const string ErroFuncionarioObrigatorio = "O campo Funcionario é obrigatório";
        protected new const string ErroFuncaoObrigatorio = "O campo Funcao é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do FuncionarioFuncaoClass.";

        protected new const string ErroUtilizado =
            "Erro ao verificar se a entidade FuncionarioFuncaoClass está sendo utilizada.";

        #endregion

        


        public FuncionarioFuncaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        
        public override string ToString()
        {
            return Funcionario.Nome;
        }
    }
}
