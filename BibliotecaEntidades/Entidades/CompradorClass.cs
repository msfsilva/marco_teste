using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{
    public class CompradorClass : CompradorBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do CompradorClass";
        protected new const string ErroDelete = "Erro ao excluir o CompradorClass  ";
        protected new const string ErroSave = "Erro ao salvar o CompradorClass.";
        protected new const string ErroCollectionFamiliaMaterialClassComprador = "Erro ao carregar a coleção de FamiliaMaterialClass.";
        protected new const string ErroCollectionOrdemCompraClassComprador = "Erro ao carregar a coleção de OrdemCompraClass.";
        protected new const string ErroCollectionClassificacaoProdutoClassComprador = "Erro ao carregar a coleção de ClassificacaoProdutoClass.";
        protected new const string ErroCollectionMaterialClassComprador = "Erro ao carregar a coleção de MaterialClass.";
        protected new const string ErroCollectionProdutoClassComprador = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroApelidoObrigatorio = "O campo Apelido é obrigatório";
        protected new const string ErroApelidoComprimento = "O campo Apelido deve ter no máximo 255 caracteres";
        protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
        protected new const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
        protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do CompradorClass.";
        protected new const string MensagemUtilizadoCollectionFamiliaMaterialClassComprador = "A entidade CompradorClass está sendo utilizada nos seguintes FamiliaMaterialClass:";
        protected new const string MensagemUtilizadoCollectionOrdemCompraClassComprador = "A entidade CompradorClass está sendo utilizada nos seguintes OrdemCompraClass:";
        protected new const string MensagemUtilizadoCollectionClassificacaoProdutoClassComprador = "A entidade CompradorClass está sendo utilizada nos seguintes ClassificacaoProdutoClass:";
        protected new const string MensagemUtilizadoCollectionMaterialClassComprador = "A entidade CompradorClass está sendo utilizada nos seguintes MaterialClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassComprador = "A entidade CompradorClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade CompradorClass está sendo utilizada.";

        #endregion



        public CompradorClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public override string ToString()
        {
            return this.Apelido;
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


        public static CompradorClass GetComprador(AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {

                List<CompradorClass> compradoresPossiveis = new CompradorClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("AcsUsuario", usuario)
                }).ConvertAll(a => (CompradorClass) a);

                if (compradoresPossiveis.Count == 0)
                {
                    throw new ExcecaoTratada("Você não possui nenhum comprador cadastrado. Cadastre um comprador antes de continuar.");
                }


                return compradoresPossiveis.First();
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o comprador.\r\n" + e.Message, e);
            }

        }
    }
}
