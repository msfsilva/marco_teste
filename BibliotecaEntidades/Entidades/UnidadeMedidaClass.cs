using System;
using System.Collections.Generic;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class UnidadeMedidaClass : UnidadeMedidaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do UnidadeMedidaClass";
        protected new const string ErroDelete = "Erro ao excluir o UnidadeMedidaClass  ";
        protected new const string ErroSave = "Erro ao salvar o UnidadeMedidaClass.";
        protected new const string ErroCollectionMaterialFornecedorClassUnidadeMedidaCompra = "Erro ao carregar a coleção de MaterialFornecedorClass.";
        protected new const string ErroCollectionProdutoFornecedorClassUnidadeMedidaCompra = "Erro ao carregar a coleção de ProdutoFornecedorClass.";
        protected new const string ErroCollectionEpiFornecedorClassUnidadeMedidaCompra = "Erro ao carregar a coleção de EpiFornecedorClass.";
        protected new const string ErroCollectionMaterialClassUnidadeMedida = "Erro ao carregar a coleção de MaterialClass.";
        protected new const string ErroCollectionMaterialClassUnidadeMedidaCompra = "Erro ao carregar a coleção de MaterialClass.";
        protected new const string ErroCollectionProdutoClassUnidadeMedida = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroCollectionProdutoClassUnidadeMedidaCompra = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroCollectionEpiClassUnidadeMedidaCompra = "Erro ao carregar a coleção de EpiClass.";
        protected new const string ErroCollectionEpiClassUnidadeMedidaUso = "Erro ao carregar a coleção de EpiClass.";
        protected new const string ErroAbreviadaObrigatorio = "O campo Abreviada é obrigatório";
        protected new const string ErroAbreviadaComprimento = "O campo Abreviada deve ter no máximo 255 caracteres";
        protected new const string ErroNomeUnidadeObrigatorio = "O campo NomeUnidade é obrigatório";
        protected new const string ErroNomeUnidadeComprimento = "O campo NomeUnidade deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do UnidadeMedidaClass.";
        protected new const string MensagemUtilizadoCollectionMaterialFornecedorClassUnidadeMedidaCompra = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes MaterialFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionProdutoFornecedorClassUnidadeMedidaCompra = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionEpiFornecedorClassUnidadeMedidaCompra = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes EpiFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionMaterialClassUnidadeMedida = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes MaterialClass:";
        protected new const string MensagemUtilizadoCollectionMaterialClassUnidadeMedidaCompra = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes MaterialClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassUnidadeMedida = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassUnidadeMedidaCompra = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string MensagemUtilizadoCollectionEpiClassUnidadeMedidaCompra = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes EpiClass:";
        protected new const string MensagemUtilizadoCollectionEpiClassUnidadeMedidaUso = "A entidade UnidadeMedidaClass está sendo utilizada nos seguintes EpiClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade UnidadeMedidaClass está sendo utilizada.";

        #endregion

        public UnidadeMedidaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }
        
        public override string ToString()
        {
            return this.Abreviada;
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

        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            UnidadeMedidaDto dto = new UnidadeMedidaDto()
            {
                abreviatura = this.Abreviada,
                id = this.ID,
                nomeExtenso = this.NomeUnidade

            };

            if (inserting)
            {
                ApiSimuladorCompras.CriarUnidadeMedida(UsuarioAtual, command, dto);
            }
            else
            {
                ApiSimuladorCompras.AtualizarUnidadeMedida(UsuarioAtual, command, dto);
            }
        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            ExcluirDto dto = new ExcluirDto()
            {
                ids = new List<long>() { this.ID}
            };
            ApiSimuladorCompras.ExcluirUnidadeMedida(UsuarioAtual, command, dto);
        }


        public void SincronizarSDC(IWTPostgreNpgsqlConnection conn)
        {
            UnidadeMedidaDto dto = new UnidadeMedidaDto()
            {
                abreviatura = this.Abreviada,
                id = this.ID,
                nomeExtenso = this.NomeUnidade

            };


            ApiSimuladorCompras.AtualizarUnidadeMedida(UsuarioAtual, conn, dto);

        }
    }
}
