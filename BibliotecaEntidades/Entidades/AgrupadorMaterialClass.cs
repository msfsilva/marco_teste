using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class AgrupadorMaterialClass : AgrupadorMaterialBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do AgrupadorMaterialClass";
        protected new const string ErroDelete = "Erro ao excluir o AgrupadorMaterialClass  ";
        protected new const string ErroSave = "Erro ao salvar o AgrupadorMaterialClass.";
        protected new const string ErroCollectionFamiliaMaterialClassAgrupadorMaterial = "Erro ao carregar a coleção de FamiliaMaterialClass.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do AgrupadorMaterialClass.";
        protected new const string MensagemUtilizadoCollectionFamiliaMaterialClassAgrupadorMaterial = "A entidade AgrupadorMaterialClass está sendo utilizada nos seguintes FamiliaMaterialClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade AgrupadorMaterialClass está sendo utilizada.";

        #endregion

        

        public AgrupadorMaterialClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public string TipoConsumoEstoqueTela
        {
            get
            {
                switch (TipoConsumoEstoque)
                {
                    case EASITipoConsumoEstoque.MateriaPrima:
                        return "Matéria Prima";
                        break;
                    case EASITipoConsumoEstoque.Consumo:
                        return "Consumo";
                        break;
                    case EASITipoConsumoEstoque.Escolher:
                        return "Definir na SC";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            return this.Identificacao;
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "TipoConsumoEstoqueTela":
                    orderByClause += ", agm_tipo_consumo_estoque " + ordenacao.ToString() + " ";
                    return true;
                default:
                    return false;
            }
            
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
