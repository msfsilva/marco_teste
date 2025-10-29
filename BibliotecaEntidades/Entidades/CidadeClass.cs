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
    public class CidadeClass : CidadeBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do CidadeClass";
        protected new const string ErroDelete = "Erro ao excluir o CidadeClass  ";
        protected new const string ErroSave = "Erro ao salvar o CidadeClass.";
        protected new const string ErroCollectionFornecedorClassCidade2 = "Erro ao carregar a coleção de FornecedorClass.";
        protected new const string ErroCollectionFuncionarioClassCidade = "Erro ao carregar a coleção de FuncionarioClass.";
        protected new const string ErroCollectionRepresentanteClassCidade = "Erro ao carregar a coleção de RepresentanteClass.";
        protected new const string ErroCollectionClienteClassCidade2 = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroCollectionClienteClassCidadeCob2 = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroCollectionTransporteClassCidade = "Erro ao carregar a coleção de TransporteClass.";
        protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
        protected new const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
        protected new const string ErroEstadoObrigatorio = "O campo Estado é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do CidadeClass.";
        protected new const string MensagemUtilizadoCollectionFornecedorClassCidade2 = "A entidade CidadeClass está sendo utilizada nos seguintes FornecedorClass:";
        protected new const string MensagemUtilizadoCollectionFuncionarioClassCidade = "A entidade CidadeClass está sendo utilizada nos seguintes FuncionarioClass:";
        protected new const string MensagemUtilizadoCollectionRepresentanteClassCidade = "A entidade CidadeClass está sendo utilizada nos seguintes RepresentanteClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassCidade2 = "A entidade CidadeClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassCidadeCob2 = "A entidade CidadeClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string MensagemUtilizadoCollectionTransporteClassCidade = "A entidade CidadeClass está sendo utilizada nos seguintes TransporteClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade CidadeClass está sendo utilizada.";

        #endregion

        public CidadeClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public override string ToString()
        {
            return this.Nome;
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public string NomeCompleto
        {
            get { return this.Nome + (this.Estado != null ? " - " + this.Estado.Sigla : ""); }

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

       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if(this.Pais.Codigo == 1058)
            {
                //Cidade brasileira
                if (this.Estado == null)
                {
                    throw new ExcecaoTratada("O Estado é obrigatório");
                }

                if (this.CodigoIbge < 1000000 || this.CodigoIbge > 9999999)
                {
                    throw new ExcecaoTratada("O Código do IBGE é inválido");
                }

                //Verifica se o código do IBGE é único
                CidadeClass cidadeDuplicada = (CidadeClass) this.Search(new List<SearchParameterClass>()
                                                                            {
                                                                                new SearchParameterClass("CodigoIbge", this.CodigoIbge)
                                                                            }).FirstOrDefault(a => a.ID != this.ID);
                if (cidadeDuplicada != null)
                {
                    throw new ExcecaoTratada("O código IBGE informado já está sendo utilizado na cidade " + cidadeDuplicada.ToString());
                }
            }
            return true;
        }
    }
}