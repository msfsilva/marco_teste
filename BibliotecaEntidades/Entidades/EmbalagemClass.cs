using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades
{
    public class EmbalagemClass : EmbalagemBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EmbalagemClass";
        protected new const string ErroDelete = "Erro ao excluir o EmbalagemClass  ";
        protected new const string ErroSave = "Erro ao salvar o EmbalagemClass.";
        protected new const string ErroCollectionProdutoClassEmbalagem = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
        protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
        protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do EmbalagemClass.";
        protected new const string MensagemUtilizadoCollectionProdutoClassEmbalagem = "A entidade EmbalagemClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EmbalagemClass está sendo utilizada.";

        #endregion


        public EmbalagemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

  
        public bool UtilNenhumaDimVariavel
        {
            get
            {
                if (this.DimensaoVariavel == DimensaoVariavelEmbalagem.Nenhuma)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.DimensaoVariavel = DimensaoVariavelEmbalagem.Nenhuma;
                }
            }
        }

        public bool UtilLarguraDimVariavel
        {
            get
            {
                if (this.DimensaoVariavel == DimensaoVariavelEmbalagem.Largura)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.DimensaoVariavel = DimensaoVariavelEmbalagem.Largura;
                }
            }
        }

        public bool UtilAlturaDimVariavel
        {
            get
            {
                if (this.DimensaoVariavel == DimensaoVariavelEmbalagem.Altura)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.DimensaoVariavel = DimensaoVariavelEmbalagem.Altura;
                }
            }
        }

        public bool UtilComprimentoDimVariavel
        {
            get
            {
                if (this.DimensaoVariavel == DimensaoVariavelEmbalagem.Comprimento)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.DimensaoVariavel = DimensaoVariavelEmbalagem.Comprimento;
                }
            }
        }




        public override string ToString()
        {
            return this.Codigo;
        }


        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            IList<EmbalagemClass> produtos = this.Search(new List<SearchParameterClass>()
                                                           {
                                                               new SearchParameterClass("CodigoCaseInsensitive", this.Codigo)
                                                           }).ConvertAll(a => (EmbalagemClass)a).Where(a => a.ID != this.ID).ToList();

            if (produtos.Any())
            {
                throw new ExcecaoTratada("Já existe um dimensionamento volumétrico cadastrado com o código igual ao atual.");
            }

            return base.ValidateDataCustom(ref command);
        }


        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "CodigoCaseInsensitive":
                    whereClause += " AND (embalagem.emb_codigo LIKE :CodigoCaseInsensitive) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("CodigoCaseInsensitive", NpgsqlDbType.Varchar, parametro.Fieldvalue));

                    return true;
                default:
                    return false;
            }
        }
    }
}
