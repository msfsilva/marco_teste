using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics;
using System.Globalization;
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
    public class EstoqueHistoricoValorClass : EstoqueHistoricoValorBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EstoqueHistoricoValorClass";
        protected new const string ErroDelete = "Erro ao excluir o EstoqueHistoricoValorClass  ";
        protected new const string ErroSave = "Erro ao salvar o EstoqueHistoricoValorClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do EstoqueHistoricoValorClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EstoqueHistoricoValorClass está sendo utilizada.";

        #endregion

        public EstoqueHistoricoValorClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

      

        protected override void InitClass()
        {
            this.ControleRevisaoHabilitado = false;
        }


        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaCompleta":
                    whereClause += " AND ( " +
                                   "   UPPER(es1.est_identificacao) LIKE :buscaCompleta OR " +
                                   "   LOWER(es1.est_identificacao) LIKE :buscaCompleta OR " +
                                   "  (public.estoque_historico_valor.ehv_mes  ||'/'||   public.estoque_historico_valor.ehv_ano) LIKE :buscaCompleta  ) ";

                    command.CommandText += "   INNER JOIN public.estoque es1 ON (public.estoque_historico_valor.id_estoque = es1.id_estoque) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompleta", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = "%" + parametro.Fieldvalue + "%";

                    return true;
                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Estoque":
                    orderByClause += " , LOWER(es2.est_identificacao) " + ordenacao.ToString();
                    command.CommandText += "   INNER JOIN public.estoque es2 ON (public.estoque_historico_valor.id_estoque = es2.id_estoque) ";

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
