using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades
{
    [Serializable()]
    public class EstoqueMovimentacaoClass : EstoqueMovimentacaoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EstoqueMovimentacaoClass";
        protected new const string ErroDelete = "Erro ao excluir o EstoqueMovimentacaoClass  ";
        protected new const string ErroSave = "Erro ao salvar o EstoqueMovimentacaoClass.";
        protected new const string ErroObservacaoObrigatorio = "O campo Observacao é obrigatório";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
        protected new const string ErroEstoqueGavetaItemObrigatorio = "O campo EstoqueGavetaItem é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EstoqueMovimentacaoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EstoqueMovimentacaoClass está sendo utilizada.";

        #endregion


        public string LocalizacaoCompleta
        {
            get { return this.EstoqueGavetaItem.LocalizacaoCompleta; }
        }

        public EstoqueMovimentacaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            return this.ID.ToString();
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Material":
                    command.CommandText += " INNER JOIN public.estoque_gaveta_item ON (public.estoque_movimentacao.id_estoque_gaveta_item = public.estoque_gaveta_item.id_estoque_gaveta_item) ";
                    whereClause += " AND (estoque_gaveta_item.id_material = :Material) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Material", NpgsqlDbType.Bigint, ((MaterialClass) parametro.Fieldvalue).ID));
                    return true;
                case "ProdutoK":
                    command.CommandText += " INNER JOIN public.estoque_gaveta_item ON (public.estoque_movimentacao.id_estoque_gaveta_item = public.estoque_gaveta_item.id_estoque_gaveta_item) ";
                    whereClause += " AND (estoque_gaveta_item.id_produto_k = :ProdutoK) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ProdutoK", NpgsqlDbType.Bigint, ((ProdutoKClass) parametro.Fieldvalue).ID));
                    return true;
                case "Produto":
                    command.CommandText += " INNER JOIN public.estoque_gaveta_item ON (public.estoque_movimentacao.id_estoque_gaveta_item = public.estoque_gaveta_item.id_estoque_gaveta_item) ";
                    whereClause += " AND (estoque_gaveta_item.id_produto = :Produto) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Produto", NpgsqlDbType.Bigint, ((ProdutoClass) parametro.Fieldvalue).ID));
                    return true;
                case "Epi":
                    command.CommandText += " INNER JOIN public.estoque_gaveta_item ON (public.estoque_movimentacao.id_estoque_gaveta_item = public.estoque_gaveta_item.id_estoque_gaveta_item) ";
                    whereClause += " AND (estoque_gaveta_item.id_epi = :Epi) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Epi", NpgsqlDbType.Bigint, ((EpiClass) parametro.Fieldvalue).ID));
                    return true;
                case "Recurso":
                    command.CommandText += " INNER JOIN public.estoque_gaveta_item ON (public.estoque_movimentacao.id_estoque_gaveta_item = public.estoque_gaveta_item.id_estoque_gaveta_item) ";
                    whereClause += " AND (estoque_gaveta_item.id_recurso = :Recurso) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("Recurso", NpgsqlDbType.Bigint, ((RecursoClass) parametro.Fieldvalue).ID));
                    return true;
                case "DocumentoCopia":
                    command.CommandText += " INNER JOIN public.estoque_gaveta_item ON (public.estoque_movimentacao.id_estoque_gaveta_item = public.estoque_gaveta_item.id_estoque_gaveta_item) ";
                    whereClause += " AND (estoque_gaveta_item.id_documento_copia = :DocumentoCopia) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("DocumentoCopia", NpgsqlDbType.Bigint, ((DocumentoCopiaClass) parametro.Fieldvalue).ID));
                    return true;
                default:
                    return false;
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }
    }
}
