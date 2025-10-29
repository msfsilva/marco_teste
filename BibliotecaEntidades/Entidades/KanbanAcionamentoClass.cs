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
using Configurations;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades
{
    [Serializable()]
    public class KanbanAcionamentoClass : KanbanAcionamentoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do KanbanAcionamentoClass";
        protected new const string ErroDelete = "Erro ao excluir o KanbanAcionamentoClass  ";
        protected new const string ErroSave = "Erro ao salvar o KanbanAcionamentoClass.";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroAcsUsuarioAcionamentoObrigatorio = "O campo AcsUsuarioAcionamento é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do KanbanAcionamentoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade KanbanAcionamentoClass está sendo utilizada.";

        #endregion


        public string TipoEntidade
        {
            get
            {
                if (Material != null)
                {
                    return "Material";
                }

                if (Produto != null)
                {
                    return "Produto";
                }

                if (ProdutoK != null)
                {
                    return "Kanban de Itens Manufaturados";
                }

                if (Epi != null)
                {
                    return "Epi";
                }

                throw new Exception("KanbanAcionamentoClass sem target. Informe o suporte IWT");
            }
        }

        public string Identificacao
        {
            get
            {
                if (Material != null)
                {
                    return Material.IdentificacaoCompleta;
                }

                if (Produto != null)
                {
                    return Produto.ToString();
                }

                if (ProdutoK != null)
                {
                    return ProdutoK.ToString();
                }

                if (Epi != null)
                {
                    return Epi.ToString();
                }

                throw new Exception("KanbanAcionamentoClass sem target. Informe o suporte IWT");
            }
        }

        public string Descricao
        {
            get
            {
                if (Material != null)
                {
                    return Material.Descricao;
                }

                if (Produto != null)
                {
                    return Produto.Descricao;
                }

                if (ProdutoK != null)
                {
                    return ProdutoK.Descricao;
                }

                if (Epi != null)
                {
                    return Epi.Descricao;
                }

                throw new Exception("KanbanAcionamentoClass sem target. Informe o suporte IWT");
            }
        }

        public string Dimensao
        {
            get
            {
                if (Material != null)
                {
                    return Material.MedidaCompleta;
                }

                if (Produto != null)
                {
                    return "";
                }

                if (ProdutoK != null)
                {
                    return ProdutoK.Dimensao;
                }

                if (Epi != null)
                {
                    return "";
                }

                throw new Exception("KanbanAcionamentoClass sem target. Informe o suporte IWT");
            }
        }

        public KanbanAcionamentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
                    whereClause += " AND ( UPPER(kanban_acionamento.kba_entidade_retirada_automatica) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(kanban_acionamento.kba_entidade_retirada_automatica) LIKE :buscaCompletaLower ";
                    whereClause += " OR UPPER(kanban_acionamento.entity_uid) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(kanban_acionamento.entity_uid) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(epiBuscaCompleta.epi_identificacao) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(epiBuscaCompleta.epi_identificacao) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(epiBuscaCompleta.epi_descricao) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(epiBuscaCompleta.epi_descricao) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(materialBuscaCompleta.mat_descricao) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(materialBuscaCompleta.mat_descricao) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(agrupadorBuscaCompleta.agm_identificacao ||' '|| familiaMaterialBuscaCompleta.fam_codigo ||' '||materialBuscaCompleta.mat_codigo||' (M'||materialBuscaCompleta.id_material||')') LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(agrupadorBuscaCompleta.agm_identificacao ||' '|| familiaMaterialBuscaCompleta.fam_codigo ||' '||materialBuscaCompleta.mat_codigo||' (M'||materialBuscaCompleta.id_material||')') LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(produtoBuscaCompleta.pro_codigo) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(produtoBuscaCompleta.pro_codigo) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(produtoBuscaCompleta.pro_descricao) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(produtoBuscaCompleta.pro_descricao) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(produtoKBuscaCompleta.prk_codigo) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(produtoKBuscaCompleta.prk_codigo) LIKE :buscaCompletaLower ";

                    whereClause += " OR UPPER(produtoKBuscaCompleta.prk_descricao) LIKE :buscaCompletaUpper ";
                    whereClause += " OR LOWER(produtoKBuscaCompleta.prk_descricao) LIKE :buscaCompletaLower) ";

                    command.CommandText +=
                        "  LEFT OUTER JOIN public.epi as epiBuscaCompleta ON (public.kanban_acionamento.id_epi = epiBuscaCompleta.id_epi) " +
                        "  LEFT OUTER JOIN public.material as materialBuscaCompleta ON(public.kanban_acionamento.id_material = materialBuscaCompleta.id_material) " +
                        "  LEFT OUTER JOIN public.familia_material as familiaMaterialBuscaCompleta ON(materialBuscaCompleta.id_familia_material = familiaMaterialBuscaCompleta.id_familia_material) " +
                        "  LEFT OUTER JOIN public.agrupador_material as agrupadorBuscaCompleta ON(familiaMaterialBuscaCompleta.id_agrupador_material = agrupadorBuscaCompleta.id_agrupador_material) " +
                        "  LEFT OUTER JOIN public.produto as produtoBuscaCompleta ON(public.kanban_acionamento.id_produto = produtoBuscaCompleta.id_produto) " +
                        "  LEFT OUTER JOIN public.produto_k produtoKBuscaCompleta ON(public.kanban_acionamento.id_produto_k = produtoKBuscaCompleta.id_produto_k) ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                    return true;

                case "TipoItemMaterial":
                    if (parametro.Fieldvalue is bool && ((bool) parametro.Fieldvalue))
                    {
                        whereClause += " AND (kanban_acionamento.id_material IS NOT NULL) ";
                    }
                    return true;
                case "TipoItemEpi":
                    if (parametro.Fieldvalue is bool && ((bool)parametro.Fieldvalue))
                    {
                        whereClause += " AND (kanban_acionamento.id_epi IS NOT NULL) ";
                    }
                    return true;
                case "TipoItemProduto":
                    if (parametro.Fieldvalue is bool && ((bool)parametro.Fieldvalue))
                    {
                        whereClause += " AND (kanban_acionamento.id_produto IS NOT NULL) ";
                    }
                    return true;
                case "TipoItemProdutoK":
                    if (parametro.Fieldvalue is bool && ((bool)parametro.Fieldvalue))
                    {
                        whereClause += " AND (kanban_acionamento.id_produto_k IS NOT NULL) ";
                    }
                    return true;
                case "Tipo_Vermelho":
                    if (parametro.Fieldvalue is bool && ((bool)parametro.Fieldvalue))
                    {
                        whereClause += " AND (kanban_acionamento.kba_tipo = 3) ";
                    }
                    return true;

                case "Tipo_Verde":
                    if (parametro.Fieldvalue is bool && ((bool)parametro.Fieldvalue))
                    {
                        whereClause += " AND (kanban_acionamento.kba_tipo = 1) ";
                    }
                    return true;

                case "Tipo_Amarelo":
                    if (parametro.Fieldvalue is bool && ((bool)parametro.Fieldvalue))
                    {
                        whereClause += " AND (kanban_acionamento.kba_tipo = 2) ";
                    }
                    return true;

       

                case "DataAcionamentoDe":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND (kanban_acionamento.kba_data_acionamento >= :DataAcionamentoDe) ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("DataAcionamentoDe", NpgsqlDbType.Timestamp, ((DateTime)parametro.Fieldvalue).Date));
                        return true;

                    }
                    else
                    {
                        throw new Exception("Tipo inválido para o filtro DataAcionamentoDe");
                    }
                case "DataAcionamentoDeHora":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND (kanban_acionamento.kba_data_acionamento >= :DataAcionamentoDeHora) ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("DataAcionamentoDeHora", NpgsqlDbType.Timestamp, ((DateTime)parametro.Fieldvalue)));
                        return true;

                    }
                    else
                    {
                        throw new Exception("Tipo inválido para o filtro DataAcionamentoDeHora");
                    }
                    
                case "DataAcionamentoAte":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND (kanban_acionamento.kba_data_acionamento < :DataAcionamentoAte) ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("DataAcionamentoAte", NpgsqlDbType.Timestamp, ((DateTime) parametro.Fieldvalue).AddDays(1).Date));
                        return true;

                    }
                    else
                    {
                        throw new Exception("Tipo inválido para o filtro DataAcionamentoAte");
                    }

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

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Identificacao":

                    orderByClause += ", CASE " +
                                     " WHEN kanban_acionamento.id_epi IS NOT NULL THEN epiIdentificacao.epi_identificacao " +
                                     " WHEN kanban_acionamento.id_material IS NOT NULL THEN agrupadorIdentificacao.agm_identificacao ||' '|| familiaMaterialIdentificacao.fam_codigo ||' '||materialIdentificacao.mat_codigo||' (M'||materialIdentificacao.id_material||')' " +
                                     " WHEN kanban_acionamento.id_produto IS NOT NULL THEN produtoIdentificacao.pro_codigo " +
                                     " WHEN kanban_acionamento.id_produto_k IS NOT NULL THEN produtoKIdentificacao.prk_codigo " +
                                     "ELSE '' END " + ordenacao.ToString();

                    command.CommandText +=
                        "  LEFT OUTER JOIN public.epi as epiIdentificacao ON (public.kanban_acionamento.id_epi = epiIdentificacao.id_epi) " +
                        "  LEFT OUTER JOIN public.material as materialIdentificacao ON(public.kanban_acionamento.id_material = materialIdentificacao.id_material) " +
                        "  LEFT OUTER JOIN public.familia_material as familiaMaterialIdentificacao ON(materialIdentificacao.id_familia_material = familiaMaterialIdentificacao.id_familia_material) " +
                        "  LEFT OUTER JOIN public.agrupador_material as agrupadorIdentificacao ON(familiaMaterialIdentificacao.id_agrupador_material = agrupadorIdentificacao.id_agrupador_material) " +
                        "  LEFT OUTER JOIN public.produto as produtoIdentificacao ON(public.kanban_acionamento.id_produto = produtoIdentificacao.id_produto) " +
                        "  LEFT OUTER JOIN public.produto_k produtoKIdentificacao ON(public.kanban_acionamento.id_produto_k = produtoKIdentificacao.id_produto_k) ";

                    return true;

                case "Descricao":

                    orderByClause += ", CASE " +
                                     " WHEN kanban_acionamento.id_epi IS NOT NULL THEN epiDescricao.epi_descricao " +
                                     " WHEN kanban_acionamento.id_material IS NOT NULL THEN materialDescricao.mat_descricao " +
                                     " WHEN kanban_acionamento.id_produto IS NOT NULL THEN produtoDescricao.pro_descricao " +
                                     " WHEN kanban_acionamento.id_produto_k IS NOT NULL THEN produtoKDescricao.prk_descricao " +
                                     "ELSE '' END " + ordenacao.ToString();

                    command.CommandText +=
                        "  LEFT OUTER JOIN public.epi as epiDescricao ON (public.kanban_acionamento.id_epi = epiDescricao.id_epi) " +
                        "  LEFT OUTER JOIN public.material as materialDescricao ON(public.kanban_acionamento.id_material = materialDescricao.id_material) " +
                        "  LEFT OUTER JOIN public.familia_material as familiaMaterialDescricao ON(materialDescricao.id_familia_material = familiaMaterialDescricao.id_familia_material) " +
                        "  LEFT OUTER JOIN public.agrupador_material as agrupadorDescricao ON(familiaMaterialDescricao.id_agrupador_material = agrupadorDescricao.id_agrupador_material) " +
                        "  LEFT OUTER JOIN public.produto as produtoDescricao ON(public.kanban_acionamento.id_produto = produtoDescricao.id_produto) " +
                        "  LEFT OUTER JOIN public.produto_k produtoKDescricao ON(public.kanban_acionamento.id_produto_k = produtoKDescricao.id_produto_k) ";

                    return true;
                case "TipoEntidade":

                    orderByClause += ", CASE " +
                                     " WHEN kanban_acionamento.id_epi IS NOT NULL THEN 1 " +
                                     " WHEN kanban_acionamento.id_material IS NOT NULL THEN 3 " +
                                     " WHEN kanban_acionamento.id_produto IS NOT NULL THEN 4 " +
                                     " WHEN kanban_acionamento.id_produto_k IS NOT NULL THEN 2 " +
                                     "ELSE 0 END " + ordenacao.ToString();
                    return true;

                case "Dimensao":

                    orderByClause += ", CASE " +
                                     " WHEN kanban_acionamento.id_epi IS NOT NULL THEN '' " +
                                     " WHEN kanban_acionamento.id_material IS NOT NULL THEN materialDimensao.mat_medida || ' '||materialDimensao.mat_medida_largura||' ' ||materialDimensao.mat_medida_comprimento " +
                                     " WHEN kanban_acionamento.id_produto IS NOT NULL THEN '' " +
                                     " WHEN kanban_acionamento.id_produto_k IS NOT NULL THEN produtoKDimensao.prk_dimensao " +
                                     "ELSE '' END " + ordenacao.ToString() +" ";

                    command.CommandText +=
                        "  LEFT OUTER JOIN public.material as materialDimensao ON(public.kanban_acionamento.id_material = materialDimensao.id_material) " +
                        "  LEFT OUTER JOIN public.produto_k produtoKDimensao ON(public.kanban_acionamento.id_produto_k = produtoKDimensao.id_produto_k) ";

                    return true;
                    
                default:
                    return false;
            }
        }

        public void Encerrar(AcsUsuarioClass usuario, bool manual, string entidadeGeradoraRetirada)
        {
            if (Encerrado)
            {
                throw new ExcecaoTratada("Não é possivel encerrar um aviso que já foi encerrado anteriormente");
            }
            Encerrado = true;
            RetiradaManual = manual;
            DataRetirada = DataIndependenteClass.GetData();
            AcsUsuarioRetirada = usuario;
            EntidadeRetiradaAutomatica = entidadeGeradoraRetirada;
        }

        public static List<KanbanAcionamentoClass> GetUltimosAvisos(int intervalo, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection singleConnection)
        {
            List<KanbanAcionamentoClass> dados = new KanbanAcionamentoClass(usuario,singleConnection).Search(
                new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Encerrado",false),
                    new SearchParameterClass("DataAcionamentoDeHora",DataIndependenteClass.GetData().AddSeconds(intervalo*-1))

                }).ToList().ConvertAll(a=>(KanbanAcionamentoClass)a);

            return dados;
        }
    }
}
