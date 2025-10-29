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
    public class ProdutoPermissaoVendaPeriodosClass : ProdutoPermissaoVendaPeriodosBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoPermissaoVendaPeriodosClass";
        protected new const string ErroDelete = "Erro ao excluir o ProdutoPermissaoVendaPeriodosClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProdutoPermissaoVendaPeriodosClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do ProdutoPermissaoVendaPeriodosClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProdutoPermissaoVendaPeriodosClass está sendo utilizada.";

        #endregion

        public ProdutoPermissaoVendaPeriodosClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
                case "BuscaCompleta":
                    whereClause += " AND (" +
                                   " UPPER(pr1.pro_codigo) LIKE UPPER(:BuscaCompleta) OR " +
                                   " UPPER(pvp_inicio_justificativa) LIKE UPPER(:BuscaCompleta) OR " +
                                   " UPPER(pvp_termino_justificativa) LIKE UPPER(:BuscaCompleta) " +
                                   ")";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("BuscaCompleta", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = "%" + parametro.Fieldvalue + "%";

                    command.CommandText += " JOIN produto pr1 ON pr1.id_produto = produto_permissao_venda_periodos.id_produto ";

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
