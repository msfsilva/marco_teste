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
    public class OrdemProducaoEnvioTerceirosClass : OrdemProducaoEnvioTerceirosBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoEnvioTerceirosClass";
        protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoEnvioTerceirosClass  ";
        protected new const string ErroSave = "Erro ao salvar o OrdemProducaoEnvioTerceirosClass.";
        protected new const string ErroCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosRecebimentoClass.";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
        protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoEnvioTerceirosClass.";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros = "A entidade OrdemProducaoEnvioTerceirosClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosRecebimentoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade OrdemProducaoEnvioTerceirosClass está sendo utilizada.";

        #endregion


       public string Produto
        {
            get { return this.OrdemProducao.ProdutoCodigo; }
        }

        public double SaldoRecebimento { get
        {
            return this.Quantidade
                   - this.CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Sum(a => a.Quantidade)
                   - this.CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros.Sum(a => a.Quantidade);
        } }


        public OrdemProducaoEnvioTerceirosClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaCompleta":

                    command.CommandText += "   INNER JOIN public.ordem_producao ordemProducaoBuscaCompleta ON (public.ordem_producao_envio_terceiros.id_ordem_producao = ordemProducaoBuscaCompleta.id_ordem_producao) " +
                                           "   INNER JOIN public.fornecedor fornecedorBuscaCompleta ON(public.ordem_producao_envio_terceiros.id_fornecedor = fornecedorBuscaCompleta.id_fornecedor) ";

                    whereClause += " AND ( ";
                    whereClause += " UPPER(fornecedorBuscaCompleta.for_nome_fantasia) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(fornecedorBuscaCompleta.for_nome_fantasia) LIKE :buscaCompletaLower ";
                    whereClause += " OR UPPER(ordemProducaoBuscaCompleta.orp_produto_codigo) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(ordemProducaoBuscaCompleta.orp_produto_codigo) LIKE :buscaCompletaLower ";
                    
                    whereClause += ") ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                    return true;

                case "OrdemProducaoId":

                    whereClause += " AND ( ordem_producao_envio_terceiros.id_ordem_producao = :OrdemProducaoId ) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("OrdemProducaoId", NpgsqlDbType.Bigint, parametro.Fieldvalue.ToString().ToUpper()));
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

        public void VerificaEncerramentoRecebimento(ref IWTPostgreNpgsqlCommand command)
        {
            this.TotalmenteRecebido = this.SaldoRecebimento <= 0.00001;

            Save(ref command);

            if (TotalmenteRecebido)
            {
                OrdemProducao.VerificaEncerramentoEnvioExterno(ref command);
            }
           
        }
    }
}
