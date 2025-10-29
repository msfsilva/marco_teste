using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class FamiliaClienteClass : FamiliaClienteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do FamiliaClienteClass";
        protected new const string ErroDelete = "Erro ao excluir o FamiliaClienteClass  ";
        protected new const string ErroSave = "Erro ao salvar o FamiliaClienteClass.";
        protected new const string ErroCollectionVariavelClassFamiliaCliente = "Erro ao carregar a coleção de VariavelClass.";
        protected new const string ErroCollectionClienteClassFamiliaCliente = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroCollectionProdutoClassFamiliaCliente = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
        protected new const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do FamiliaClienteClass.";
        protected new const string MensagemUtilizadoCollectionVariavelClassFamiliaCliente = "A entidade FamiliaClienteClass está sendo utilizada nos seguintes VariavelClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassFamiliaCliente = "A entidade FamiliaClienteClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassFamiliaCliente = "A entidade FamiliaClienteClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade FamiliaClienteClass está sendo utilizada.";

        #endregion


        public FamiliaClienteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

      

        public override string ToString()
        {
            return this.Nome;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }
    }
}
