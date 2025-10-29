using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades
{
    public class FuncionarioEpiClass : FuncionarioEpiBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EPI do Funcionário";
        protected new const string ErroDelete = "Erro ao excluir o EPI do Funcionário  ";
        protected new const string ErroSave = "Erro ao salvar o EPI do Funcionário.";
        protected new const string ErroFuncionarioObrigatorio = "O campo Funcionario é obrigatório";
        protected new const string ErroEpiObrigatorio = "O campo Epi é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EPI do Funcionário.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade FuncionarioEpi está sendo utilizada.";

        #endregion

        


        public FuncionarioEpiClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        public string EpiInfo
        {
            get { return this.Epi.Identificacao + " - " + this.Epi.Descricao; }
        }

        public long IdFuncionario
        {
            get { return this.Funcionario.ID; }
        }



        
        public override string ToString()
        {
           return this.Epi.ToString();
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "EpisVencidos":
                    whereClause += " AND ( " +
                                        "  public.funcionario_epi.fue_data_vencimento_prevista < :vencimento " +
                                                   ") ";

                                    command.Parameters.Add( new IWTPostgreNpgsqlCommandParameter("vencimento", NpgsqlDbType.Date));
                                    command.Parameters["vencimento"].Value = parametro.Fieldvalue;
                    return true;
                default:
                    return false;
            }
        }
    }
}
