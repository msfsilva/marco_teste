#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaEntidades.Operacoes.Estoque
{

    public static class EstoqueMovimentacao
    {

        private static bool? _controleTipoEstoqueHabilitado = null;

        public static bool ControleTipoEstoqueHabilitado
        {
            get
            {
                if (!_controleTipoEstoqueHabilitado.HasValue)
                {
                    LoadControleTipoEstoqueHabilitado();
                }

                if (_controleTipoEstoqueHabilitado.HasValue)
                {
                    return _controleTipoEstoqueHabilitado.Value;
                }

                return false;
            }
            set { _controleTipoEstoqueHabilitado = value; }
        }

        private static void LoadControleTipoEstoqueHabilitado()
        {
            _controleTipoEstoqueHabilitado = IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.CONTROLE_CONSUMO_MP_ESTOQUE_HABILITADO);
        }


        public static void LancaMovimentoEstoqueProduto(EstoqueGavetaClass gaveta, ProdutoClass produto, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {
            LancaMovimentoEstoque(gaveta, produto, null, null, null, null, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command);
        }

        public static void LancaMovimentoEstoqueMaterial(EstoqueGavetaClass gaveta, MaterialClass material, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {
            LancaMovimentoEstoque(gaveta, null, material, null, null, null, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command);
        }

        public static void LancaMovimentoEstoqueDocumentoCopia(EstoqueGavetaClass gaveta, DocumentoCopiaClass documentoCopia, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {
            LancaMovimentoEstoque(gaveta, null, null, documentoCopia, null, null, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command);
        }

        public static void LancaMovimentoEstoqueRecurso(EstoqueGavetaClass gaveta, RecursoClass recurso, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {
            LancaMovimentoEstoque(gaveta, null, null, null, recurso, null, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command);
        }

        public static void LancaMovimentoEstoqueProdutoK(EstoqueGavetaClass gaveta, ProdutoKClass produtok, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {
            LancaMovimentoEstoque(gaveta, null, null, null, null, produtok, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command);
        }

        public static void LancaMovimentoEstoqueEpi(EstoqueGavetaClass gaveta, EpiClass epi, double quantidade, string observacoes, string entidadeGeradora,
          AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {
            LancaMovimentoEstoque(gaveta, null, null, null, null, null, epi, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command);
        }

        internal static EstoqueGavetaItemClass LancaMovimentoEstoque(EstoqueGavetaClass gaveta, ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documentoCopia,
            RecursoClass recurso, ProdutoKClass produtok, EpiClass epi, double quantidade, string observacoes, string entidadeGeradora, AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command, EstoqueGavetaItemClass estoqueGavetaItem = null)
        {
            try
            {
                if (produto == null && material == null && recurso == null && documentoCopia == null && produtok == null && epi == null)
                {
                    throw new Exception("Indique o item a ser alterado no estoque.");
                }

                List<SearchParameterClass> parametros = new List<SearchParameterClass>();
                parametros.Add(new SearchParameterClass("EstoqueGaveta", gaveta));
                if (produto != null)
                {
                    parametros.Add(new SearchParameterClass("Produto", produto));
                }

                if (material != null)
                {
                    parametros.Add(new SearchParameterClass("Material", material));
                }
                if (recurso != null)
                {
                    parametros.Add(new SearchParameterClass("Recurso", recurso));
                }
                if (documentoCopia != null)
                {
                    parametros.Add(new SearchParameterClass("DocumentoCopia", documentoCopia));
                }
                if (produtok != null)
                {
                    parametros.Add(new SearchParameterClass("ProdutoK", produtok));
                }
                if (epi != null)
                {
                    parametros.Add(new SearchParameterClass("Epi", epi));
                }

                List<EstoqueGavetaItemClass> gavetasItem;
                if (estoqueGavetaItem == null)
                {
                    gavetasItem = new EstoqueGavetaItemClass(usuario, command.Connection).Search(parametros).ConvertAll(a => (EstoqueGavetaItemClass) a);

                }
                else
                {
                    gavetasItem = new List<EstoqueGavetaItemClass>()
                    {
                        estoqueGavetaItem
                    };
                }


                if (gavetasItem.Count > 1)
                {
                    throw new Exception("Inconsistência de estoque, encontrada mais de uma gaveta (" + gaveta.GetLocalizacaoCompleta() + ") item (" + gavetasItem[0].CodigoItem + ") para o processo de movimento. Consulte a equipe IWT.");
                }


              
                EASITipoConsumoEstoque tipoConsumoItem = EASITipoConsumoEstoque.Escolher;

                if (produto != null)
                {
                    if (ControleTipoEstoqueHabilitado)
                    {

                        if (produto.ClassificacaoProduto != null)
                        {
                            tipoConsumoItem = produto.ClassificacaoProduto.TipoConsumoEstoque;
                        }
                    }
                }



                if (material != null)
                {


                    if (ControleTipoEstoqueHabilitado)
                    {

                        if (material.FamiliaMaterial != null && material.FamiliaMaterial.AgrupadorMaterial != null)
                        {
                            tipoConsumoItem = material.FamiliaMaterial.AgrupadorMaterial.TipoConsumoEstoque;
                        }
                    }
                }

                
                if (produtok != null)
                {
                    if (ControleTipoEstoqueHabilitado)
                    {
                        tipoConsumoItem = EASITipoConsumoEstoque.MateriaPrima;
                    }

                }

                if (epi != null)
                {
                    if (ControleTipoEstoqueHabilitado)
                    {
                        tipoConsumoItem = EASITipoConsumoEstoque.Consumo;
                    }
                }

                if (tipoConsumoItem!=EASITipoConsumoEstoque.Escolher)
                {
                    if (
                        
                        (gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.TipoAlocacaoEstoque == EASITipoAlocacaoEstoque.Consumo && tipoConsumoItem != EASITipoConsumoEstoque.Consumo) &&
                        (gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.TipoAlocacaoEstoque == EASITipoAlocacaoEstoque.MateriaPrima && tipoConsumoItem != EASITipoConsumoEstoque.MateriaPrima)

                        )
                    {
                        string codigoItem = "";
                        string tipoItem = "";

                        BuscaCodigoItem(produto, material, documentoCopia, recurso, produtok, epi, ref command, out tipoItem, out codigoItem);

                        throw new Exception("Não é possível realizar o lançamento no estoque poi o estoque foi definido como armazenzando itens de " + (gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.TipoAlocacaoEstoque == EASITipoAlocacaoEstoque.Consumo? "consumo" : "matéria prima") + " e o item não é desse tipo (" + tipoItem + ":" + codigoItem + ")");
                    }
                }


                EstoqueGavetaItemClass gavetaItem = gavetasItem.FirstOrDefault();
                if (gavetaItem == null)
                {
                    if (gaveta.Ocupada())
                    {
                        if (MessageBox.Show(null, "A gaveta selecionada já possui outro item deseja continuar assim mesmo?", "gaveta Ocupada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            throw new Exception("Operação abortada pelo usuário.");
                        }
                    }

                    gavetaItem = new EstoqueGavetaItemClass(usuario,command.Connection)
                    {
                        EstoqueGaveta = gaveta,
                        Produto = produto,
                        Material = material,
                        Recurso = recurso,
                        DocumentoCopia = documentoCopia,
                        ProdutoK = produtok,
                        Epi = epi,
                        Ativo = true
                    };

                    bool tmp = gaveta.DisableLoadCollection;
                    try
                    {
                        gaveta.DisableLoadCollection = true;
                        gaveta.CollectionEstoqueGavetaItemClassEstoqueGaveta?.Add(gavetaItem);
                    }
                    finally
                    {
                        gaveta.DisableLoadCollection = tmp;
                    }
                    
                }

                if (!gavetaItem.Ativo)
                {
                    gavetaItem.Quantidade = 0;
                    gavetaItem.Ativo = true;
                }
                

                if (IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.BLOQUEAR_ESTOQUE_NEGATIVO))
                {

                    if (gavetaItem.Quantidade + quantidade < 0)
                    {
                        string codigoItem = "";
                        string tipoItem = "";

                        BuscaCodigoItem(produto, material, documentoCopia, recurso, produtok, epi, ref command, out tipoItem, out codigoItem);

                        double saldoBaixar = (gavetaItem.Quantidade + quantidade)*-1;
                        throw new Exception("Saldo insuficiente do " + tipoItem + " " + codigoItem + " no estoque para realizar a operação, faltam " + saldoBaixar + " unidades.");
                    }
                }


                gavetaItem.Quantidade = Math.Round(gavetaItem.Quantidade + quantidade, 5);


                EstoqueMovimentacaoClass movimentacao = new EstoqueMovimentacaoClass(usuario, command.Connection)
                {
                    AcsUsuario = usuario,
                    Quantidade = quantidade,
                    Observacao = observacoes + " - " + entidadeGeradora,
                    Manual = manual,
                    EstoqueGavetaItem = gavetaItem,
                    Data = DataIndependenteClass.GetData()
                };

                gavetaItem.Save(ref command);

                movimentacao.Save(ref command);
                

                return gavetaItem;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o movimento de estoque.\r\n" + e.Message, e);
            }
        }

        private static void BuscaCodigoItem(ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documentoCopia, RecursoClass recurso, ProdutoKClass produtok, EpiClass epi, ref IWTPostgreNpgsqlCommand command, out string tipoItem, out string codigoItem)
        {
            if (produto != null)
            {

                tipoItem = "Produto";
                codigoItem = produto.Codigo;
                return;
            }


            if (material != null)
            {
                tipoItem = "Material";
                codigoItem = material.IdentificacaoCompleta;
                return;
            }

            if (documentoCopia != null)
            {
                tipoItem = "Documento Cópia";
                codigoItem = documentoCopia.IdentificacaoCompleta;
                return;
            }

            if (recurso != null)
            {
                tipoItem = "Recurso";
                codigoItem = recurso.IdentificacaoCompleta;
                return;
            }

            if (produtok != null)
            {

                tipoItem = "Kanban de Itens Manufaturados";
                codigoItem = produtok.Codigo;
                return;
            }

            if (epi != null)
            {
                tipoItem = "EPI";
                codigoItem = epi.Identificacao;
                return;
            }

            throw new Exception("Erro ao identificar o item, gaveta sem conteúdo.");
        }

        public static List<EstoqueGavetaItemBaixaClass> LancaBaixaEstoqueAgrupadoProduto(ProdutoClass produto, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command, bool consumo)
        {
            return LancaBaixaEstoqueAgrupado(produto, null, null, null, null, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command, consumo);
        }

        public static List<EstoqueGavetaItemBaixaClass> LancaBaixaEstoqueAgrupadoProdutoK(ProdutoKClass produtok, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {
            return LancaBaixaEstoqueAgrupado(null, null, null, null, produtok, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command, false);
        }

        public static List<EstoqueGavetaItemBaixaClass> LancaBaixaEstoqueAgrupadoMaterial(MaterialClass material, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command, bool consumo)
        {
            return LancaBaixaEstoqueAgrupado(null, material, null, null, null, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command, consumo);
        }

        public static List<EstoqueGavetaItemBaixaClass> LancaBaixaEstoqueAgrupadoEpi(EpiClass epi, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command, bool consumo)
        {
            return LancaBaixaEstoqueAgrupado(null, null, null, null, null, epi, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command, true);
        }

        internal static List<EstoqueGavetaItemBaixaClass> LancaBaixaEstoqueAgrupado(ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documentoCopia,
            RecursoClass recurso, ProdutoKClass produtok, EpiClass epi, double quantidade, string observacoes, string entidadeGeradora, AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command,
            bool consumo)
        {
            try
            {
                if (produto == null && material == null && recurso == null && documentoCopia == null && produtok == null && epi == null)
                {
                    throw new Exception("Indique o item a ser alterado no estoque.");
                }

                if (quantidade > 0)
                {
                    throw new Exception("Essa função só deve ser utilizada para baixas de estoque.");
                }

                List<EstoqueGavetaItemClass> gavetasEncontradas = new List<EstoqueGavetaItemClass>();
                List<SearchParameterClass> parametrosBusca = new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Ativo", true)
                };



                if (ControleTipoEstoqueHabilitado)
                {
                    parametrosBusca.Add(new SearchParameterClass("TipoConsumo", consumo ? EASITipoAlocacaoEstoque.Consumo : EASITipoAlocacaoEstoque.MateriaPrima));
                }

                if (produto != null)
                {
                    parametrosBusca.Add(new SearchParameterClass("Produto", produto));
                }

                if (material != null)
                {
                    parametrosBusca.Add(new SearchParameterClass("Material", material));
                }

                if (documentoCopia != null)
                {
                    parametrosBusca.Add(new SearchParameterClass("DocumentoCopia", documentoCopia));
                }

                if (recurso != null)
                {
                    parametrosBusca.Add(new SearchParameterClass("Recurso", recurso));
                }

                if (produtok != null)
                {
                    parametrosBusca.Add(new SearchParameterClass("ProdutoK", produtok));
                }
                if (epi != null)
                {
                    parametrosBusca.Add(new SearchParameterClass("Epi", epi));
                }

                gavetasEncontradas = new EstoqueGavetaItemClass(usuario,command.Connection).Search(parametrosBusca).ToList().ConvertAll(a=>(EstoqueGavetaItemClass)a).OrderBy(a=>a.Quantidade).ToList();

                
                double saldoBaixar = quantidade*-1;
                EstoqueGavetaClass ultimaGaveta = null;
                
                List<EstoqueGavetaItemBaixaClass> gavetasBaixadas = new List<EstoqueGavetaItemBaixaClass>();

                int i = 0;
                while (saldoBaixar > 0 && i<gavetasEncontradas.Count)
                {
                    double qtdEstoque = gavetasEncontradas[i].Quantidade;
                    ultimaGaveta = gavetasEncontradas[i].EstoqueGaveta;
                    if (qtdEstoque > 0)
                    {
                        double qtdBaixar = 0;
                        if (qtdEstoque >= saldoBaixar)
                        {
                            qtdBaixar = saldoBaixar;
                        }
                        else
                        {
                            qtdBaixar = qtdEstoque;
                        }

                        EstoqueGavetaItemClass gavItem =
                            LancaMovimentoEstoque(ultimaGaveta, produto, material, documentoCopia, recurso, produtok, epi, qtdBaixar*-1,
                                observacoes, entidadeGeradora, usuario, manual, ref command);

                        gavetasBaixadas.Add(new EstoqueGavetaItemBaixaClass(gavItem, qtdBaixar));

                        saldoBaixar -= qtdBaixar;
                    }
                    i++;
                }



                if (saldoBaixar > 0)
                {
                    if (Configurations.IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.BLOQUEAR_ESTOQUE_NEGATIVO))
                    {
                        string codigoItem = "";
                        string tipoItem = "";

                        BuscaCodigoItem(produto, material, documentoCopia, recurso, produtok, epi, ref command, out tipoItem, out codigoItem);

                        throw new Exception("Saldo insuficiente do " + tipoItem + " " + codigoItem + " no estoque para realizar a operação, faltam " + saldoBaixar + " unidades (" + (consumo ? "Consumo" : "Matéria Prima") + ").");
                    }


                    if (ultimaGaveta != null)
                    {
                        EstoqueGavetaItemClass gavItem =
                            LancaMovimentoEstoque(ultimaGaveta, produto, material, documentoCopia, recurso, produtok, epi, saldoBaixar*-1,
                                observacoes, entidadeGeradora, usuario, manual, ref command);

                        gavetasBaixadas.Add(new EstoqueGavetaItemBaixaClass(gavItem, saldoBaixar));
                    }
                }

                return gavetasBaixadas;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao lançar a baixa do estoque agrupada.\r\n" + e.Message);
            }


        }

        public static double BuscaQuantidadeAtualEstoqueProduto(ProdutoClass produto, ref IWTPostgreNpgsqlCommand command)
        {
            return BuscaQuantidadeAtualEstoque(produto, null, null, null, null, null, ref command);
        }

        public static double BuscaQuantidadeAtualEstoqueProdutoK(ProdutoKClass produtok, ref IWTPostgreNpgsqlCommand command)
        {
            return BuscaQuantidadeAtualEstoque(null, null, null, null, produtok, null, ref command);
        }

        public static double BuscaQuantidadeAtualEstoqueMaterial(MaterialClass material, ref IWTPostgreNpgsqlCommand command)
        {
            return BuscaQuantidadeAtualEstoque(null, material, null, null, null, null, ref command);
        }

        public static double BuscaQuantidadeAtualEstoqueDocumentoCopia(DocumentoCopiaClass documentoCopia, ref IWTPostgreNpgsqlCommand command)
        {
            return BuscaQuantidadeAtualEstoque(null, null, documentoCopia, null, null, null, ref command);
        }

        public static double BuscaQuantidadeAtualEstoqueRecurso(RecursoClass recurso, ref IWTPostgreNpgsqlCommand command)
        {
            return BuscaQuantidadeAtualEstoque(null, null, null, recurso, null, null, ref command);
        }

        public static double BuscaQuantidadeAtualEstoqueEpi(EpiClass epi, ref IWTPostgreNpgsqlCommand command)
        {
            return BuscaQuantidadeAtualEstoque(null, null, null, null, null, epi, ref command);
        }

        internal static double BuscaQuantidadeAtualEstoque(ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documentoCopia,
            RecursoClass recurso,ProdutoKClass produtok, EpiClass epi, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                command.CommandText =
                    "SELECT  " +
                    "  SUM(public.estoque_gaveta_item.egi_quantidade) AS soma " +
                    "FROM " +
                    "  public.estoque_gaveta_item " +
                    "WHERE " +
                    "  public.estoque_gaveta_item.egi_ativo = 1 AND ";

                if (produto != null)
                {
                    command.CommandText += "  public.estoque_gaveta_item.id_produto = " + produto.ID + " ";
                }

                if (material != null)
                {
                    command.CommandText += "  public.estoque_gaveta_item.id_material = " + material.ID + " ";
                }

                if (documentoCopia != null)
                {
                    command.CommandText += "  public.estoque_gaveta_item.id_documento_copia = " + documentoCopia.ID + " ";
                }

                if (recurso != null)
                {
                    command.CommandText += "  public.estoque_gaveta_item.id_recurso = " + recurso.ID + " ";
                }

                if (produtok != null)
                {
                    command.CommandText += "  public.estoque_gaveta_item.id_produto_k = " + produtok.ID + " ";
                }

                if (epi != null)
                {
                    command.CommandText += "  public.estoque_gaveta_item.id_epi = " + epi.ID + " ";
                }

                object tmp = command.ExecuteScalar();
                if (tmp == null || tmp == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDouble(tmp);
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar a quantidade atual em Estoque.\r\n" + e.Message, e);
            }
        }
        
        public static List<EstoqueGavetaClass> BuscaTodasGavetasProduto(ProdutoClass produto, bool? consumo, IWTPostgreNpgsqlCommand command = null)
        {
            return BuscaTodasGavetas(produto, null, null, null,null, null,  consumo, command);
        }
        public static List<EstoqueGavetaClass> BuscaTodasGavetasMaterial(MaterialClass material,  bool? consumo, IWTPostgreNpgsqlCommand command = null)
        {
            return BuscaTodasGavetas(null, material, null, null, null, null, consumo, command);
        }
        public static List<EstoqueGavetaClass> BuscaTodasGavetasDocumentoCopia(DocumentoCopiaClass documentoCopia, IWTPostgreNpgsqlCommand command = null)
        {
            return BuscaTodasGavetas(null, null, documentoCopia, null, null, null, null, command);
        }
        public static List<EstoqueGavetaClass> BuscaTodasGavetasRecursos(RecursoClass recurso, IWTPostgreNpgsqlCommand command = null)
        {
            return BuscaTodasGavetas(null, null, null, recurso, null, null, true, command);
        }
        public static List<EstoqueGavetaClass> BuscaTodasGavetasProdutoK(ProdutoKClass produtok, IWTPostgreNpgsqlCommand command = null)
        {
            return BuscaTodasGavetas(null, null, null, null, produtok, null,  false, command);
        }
        public static List<EstoqueGavetaClass> BuscaTodasGavetasEpi(EpiClass epi, IWTPostgreNpgsqlCommand command = null)
        {
            return BuscaTodasGavetas(null, null, null, null, null, epi,  true, command);
        }

        private static List<EstoqueGavetaClass> BuscaTodasGavetas(
            ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documentoCopia, RecursoClass recurso,ProdutoKClass produtok, EpiClass epi, bool? consumo, IWTPostgreNpgsqlCommand command = null)
        {
            try
            {

                List<EstoqueGavetaItemClass> gavetas = new List<EstoqueGavetaItemClass>();
            
                if (produto != null)
                {
                    gavetas = new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, command != null ? command.Connection : produto.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Produto", produto),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass) a);
                }

                if (material != null)
                {
                    gavetas = new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, command != null ? command.Connection : material.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Material", material),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
                }

                if (documentoCopia != null)
                {
                    gavetas = new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, command != null ? command.Connection : documentoCopia.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("DocumentoCopia", documentoCopia),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
                }

                if (recurso != null)
                {
                    gavetas = new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, command != null ? command.Connection : recurso.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Recurso", recurso),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
                    
                }


                if (produtok != null)
                {
                    gavetas = new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, command != null ? command.Connection : produtok.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("ProdutoK", produtok),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
                }

             
                if (epi != null)
                {
                    gavetas = new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, command != null ? command.Connection : epi.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Epi", epi),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
                    gavetas = epi.CollectionEstoqueGavetaItemClassEpi.ToList();
                }

                if (ControleTipoEstoqueHabilitado)
                {
                    if (consumo.HasValue)
                    {
                        gavetas = gavetas.Where(a => consumo.Value ? a.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor.Estoque.TipoAlocacaoEstoque == EASITipoAlocacaoEstoque.Consumo : a.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor.Estoque.TipoAlocacaoEstoque == EASITipoAlocacaoEstoque.MateriaPrima).ToList();
                    }
                }

                return gavetas.ConvertAll(a=>a.EstoqueGaveta);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar as gavetas todas as gavetas item\r\n" + e.Message, e);
            }
        }

        public static List<EstoqueGavetaItemClass> BuscaTodasGavetasItemProduto(ProdutoClass produto)
        {
            return new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, produto.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Produto", produto),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
        }

        public static List<EstoqueGavetaItemClass> BuscaTodasGavetasItemEpi(EpiClass epi)
        {
            return new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, epi.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Epi", epi),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
        }

        public static List<EstoqueGavetaItemClass> BuscaTodasGavetasItemMaterial(MaterialClass material)
        {
            return new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, material.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Material", material),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
        }



        public static List<EstoqueGavetaItemClass> BuscaTodasGavetasItemProdutoK(ProdutoKClass produtok)
        {
            return new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, produtok.SingleConnection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("ProdutoK", produtok),
                        new SearchParameterClass("Ativo",true)
                    }).ToList().ConvertAll(a => (EstoqueGavetaItemClass)a);
        }


        public static EstoqueGavetaItemClass BuscaGavetaItemRecurso(RecursoClass recurso)
        {
            try
            {
                return (EstoqueGavetaItemClass) new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, recurso.SingleConnection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Recurso", recurso),
                    new SearchParameterClass("Ativo", true)
                }).FirstOrDefault();
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao a gaveta do recurso\r\n" + e.Message, e);
            }
        }

        public static EstoqueGavetaItemClass BuscaGavetaItemDocumentoCopia(DocumentoCopiaClass documentoCopia)
        {
            try
            {
                return (EstoqueGavetaItemClass)new EstoqueGavetaItemClass(LoginClass.UsuarioLogado.loggedUser, documentoCopia.SingleConnection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("DocumentoCopia", documentoCopia),
                    new SearchParameterClass("Ativo", true)
                }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao a gaveta do documento\r\n" + e.Message, e);
            }
        }




        public static void TrocaItemGavetaTotalProduto(EstoqueGavetaItemClass gavetaOrigem, EstoqueGavetaClass gavetaDestino,
            ProdutoClass produto, AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            TrocaItemGavetaTotal(gavetaOrigem, gavetaDestino, produto, null, null, null, null, null, usuario, ref command);
        }

        public static void TrocaItemGavetaTotalProdutoK(EstoqueGavetaItemClass gavetaOrigem, EstoqueGavetaClass gavetaDestino,
           ProdutoKClass produtok, AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            TrocaItemGavetaTotal(gavetaOrigem, gavetaDestino, null, null, null, null, produtok, null, usuario, ref command);
        }

        public static void TrocaItemGavetaTotalMaterial(EstoqueGavetaItemClass gavetaOrigem, EstoqueGavetaClass gavetaDestino,
            MaterialClass material, AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            TrocaItemGavetaTotal(gavetaOrigem, gavetaDestino, null, material, null, null, null, null, usuario, ref command);
        }

        public static void TrocaItemGavetaTotalDocumentoCopia(EstoqueGavetaItemClass gavetaOrigem, EstoqueGavetaClass gavetaDestino,
            DocumentoCopiaClass documentoCopia, AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            TrocaItemGavetaTotal(gavetaOrigem, gavetaDestino, null, null, documentoCopia, null, null, null, usuario, ref command);
        }

        public static void TrocaItemGavetaTotalRecurso(EstoqueGavetaItemClass gavetaOrigem, EstoqueGavetaClass gavetaDestino,
            RecursoClass recurso, AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            TrocaItemGavetaTotal(gavetaOrigem, gavetaDestino, null, null, null, recurso, null, null, usuario, ref command);
        }

        public static void TrocaItemGavetaTotalEpi(EstoqueGavetaItemClass gavetaOrigem, EstoqueGavetaClass gavetaDestino,
            EpiClass epi, AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            TrocaItemGavetaTotal(gavetaOrigem, gavetaDestino, null, null, null, null, null, epi, usuario, ref command);
        }

        private static void TrocaItemGavetaTotal(EstoqueGavetaItemClass gavetaOrigem, EstoqueGavetaClass gavetaDestino,
            ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documentoCopia, RecursoClass recurso,ProdutoKClass produtok, EpiClass epi,
             AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (produto == null && material == null && recurso == null && documentoCopia == null && produtok == null && epi == null)
                {
                    throw new Exception("Indique o item a ser alterado no estoque.");
                }
                if (ControleTipoEstoqueHabilitado)
                {
                    if (gavetaOrigem.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor.Estoque.TipoAlocacaoEstoque != gavetaDestino.EstoquePrateleira.EstoqueCorredor.Estoque.TipoAlocacaoEstoque)
                    {
                        throw new Exception("Não é possível realizar a troca de gavetas pois os estoques de origem e destino possuem tipos de itens diferentes (MP e Consumo)");
                    }
                }

                double qtdOriginal = gavetaOrigem.Quantidade;
                //Origem
                LancaMovimentoEstoque(gavetaOrigem.EstoqueGaveta, produto, material, documentoCopia,
                                                          recurso, produtok, epi, qtdOriginal * -1,
                                                          "Troca de gaveta de estoque - Destino " +
                                                          gavetaDestino.GetLocalizacaoCompleta(), "manual",
                                                          usuario, false, ref command);

                gavetaOrigem.Ativo = false;
                gavetaOrigem.Save(ref command);

                //Destino
                LancaMovimentoEstoque(gavetaDestino, produto, material, documentoCopia,
                                                          recurso, produtok, epi, qtdOriginal,
                                                          "Troca de gaveta de estoque - Origem " +
                                                          gavetaOrigem.EstoqueGaveta.GetLocalizacaoCompleta(), "manual",
                                                          usuario, false, ref command);




              
           


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao trocar o item de gaveta.\r\n" + e.Message, e);
            }
        }

        public static void ExcluiItemGavetaProduto(EstoqueGavetaItemClass gavetaOrigem,
           ProdutoClass produto,
            AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            ExcluiItemGaveta(gavetaOrigem, produto, null, null, null, null, null, usuario, ref command);
        }

        public static void ExcluiItemGavetaProdutoK(EstoqueGavetaItemClass gavetaOrigem,
          ProdutoKClass produtok,
           AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            ExcluiItemGaveta(gavetaOrigem, null, null, null, null, produtok, null, usuario, ref command);
        }

        public static void ExcluiItemGavetaMaterial(EstoqueGavetaItemClass gavetaOrigem,
          MaterialClass material,
           AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            ExcluiItemGaveta(gavetaOrigem, null, material, null, null, null, null, usuario, ref command);
        }

        public static void ExcluiItemGavetaDocumentoCopia(EstoqueGavetaItemClass gavetaOrigem,
          DocumentoCopiaClass documentoCopia,
           AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            ExcluiItemGaveta(gavetaOrigem, null, null, documentoCopia, null, null, null, usuario, ref command);
        }

        public static void ExcluiItemGavetaRecurso(EstoqueGavetaItemClass gavetaOrigem,
          RecursoClass recurso,
           AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            ExcluiItemGaveta(gavetaOrigem, null, null, null, recurso, null, null, usuario, ref command);
        }

        public static void ExcluiItemGavetaEpi(EstoqueGavetaItemClass gavetaOrigem, EpiClass epi, AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            ExcluiItemGaveta(gavetaOrigem, null, null, null, null, null, epi, usuario, ref command);
        }

        private static void ExcluiItemGaveta(EstoqueGavetaItemClass gavetaOrigem,
            ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documentoCopia, RecursoClass recurso,ProdutoKClass produtok, EpiClass epi,
             AcsUsuarioClass usuario, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (produto == null && material == null && recurso == null && documentoCopia == null && produtok == null && epi == null)
                {
                    throw new Exception("Indique o item a ser alterado no estoque.");
                }
                LancaMovimentoEstoque(gavetaOrigem.EstoqueGaveta, produto, material, documentoCopia, recurso, produtok, epi, gavetaOrigem.Quantidade*-1, "Exclusão da Gaveta", "", usuario, true, ref command);
               
                gavetaOrigem.Ativo = false;
                gavetaOrigem.Save(ref command);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o item de gaveta.\r\n" + e.Message, e);
            }
        }

        public static List<InventarioReportClass> Inventario(EstoqueClass estoque, EstoqueCorredorClass corredor, EstoquePrateleiraClass prateleira, EstoqueGavetaClass gaveta, bool somenteComMovimentacao90dias, DateTime? dataInicial, DateTime? dataFinal, ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuarioAtual)
        {
            try
            {
                command.CommandText =
                    "SELECT  " +
                    "  public.estoque_gaveta_item.id_estoque_gaveta_item, " +
                    "  esm_data " +
                    "FROM " +
                    "  public.estoque_gaveta_item " +
                    "  INNER JOIN public.estoque_gaveta ON(public.estoque_gaveta_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                    "  INNER JOIN public.estoque_prateleira ON(public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) " +
                    "  INNER JOIN public.estoque_corredor ON(public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) " +
                    "  INNER JOIN public.estoque ON(public.estoque_corredor.id_estoque = public.estoque.id_estoque) " +
                    "  LEFT JOIN " +
                    "		(         " +
                    "    SELECT id_estoque_gaveta_item, " +
                    "  	    mov.esm_data, " +
                    "        rank() OVER w AS ran " +
                    "    FROM estoque_movimentacao as mov WINDOW w AS (PARTITION BY " +
                    "    mov.id_estoque_gaveta_item " +
                    "    ORDER BY mov.esm_data DESC, mov.id_estoque_movimentacao) " +
                    "    )as mov ON ( public.estoque_gaveta_item.id_estoque_gaveta_item = mov.id_estoque_gaveta_item AND mov.ran = 1) ";
                

                command.CommandText += "WHERE " +
                                       "  public.estoque_gaveta_item.egi_ativo = 1 ";

                

                if (estoque != null)
                {
                    command.CommandText += "  AND public.estoque_corredor.id_estoque = " + estoque.ID + " ";
                }

                if (corredor != null)
                {
                    command.CommandText += "  AND public.estoque_prateleira.id_estoque_corredor = " + corredor.ID + " ";
                }

                if (prateleira != null)
                {
                    command.CommandText += "  AND public.estoque_gaveta.id_estoque_prateleira = " + prateleira.ID +
                                           " ";
                }

                if (gaveta != null)
                {
                    command.CommandText += "  AND public.estoque_gaveta_item.id_estoque_gaveta = " + gaveta.ID + " ";
                }
                if (somenteComMovimentacao90dias)
                {
                    command.CommandText +=
                        "  AND (mov.esm_data BETWEEN NOW() - CAST('90 days' AS INTERVAL) AND NOW() " + " )";
                }

                if (dataInicial.HasValue)
                {
                    command.CommandText += "  AND (mov.esm_data > '" + dataInicial.Value.ToString("yyyy-MM-dd") + "') ";
                }

                if (dataFinal.HasValue)
                {
                    command.CommandText += "  AND (mov.esm_data < '" + dataFinal.Value.AddDays(1).ToString("yyyy-MM-dd") + "') ";
                }

                command.CommandText += " GROUP BY  public.estoque_gaveta_item.id_estoque_gaveta_item, esm_data ";
                

                List<InventarioReportClass> toRet = new List<InventarioReportClass>();
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    EstoqueGavetaItemClass gavetaItem = EstoqueGavetaItemClass.GetEntidade(Convert.ToInt32(read["id_estoque_gaveta_item"]), usuarioAtual, command.Connection);
                    InventarioReportClass reportItem = new InventarioReportClass(gavetaItem);
                    if (read["esm_data"] != DBNull.Value)
                    {
                        reportItem.DataUltimaUtilizacao = Convert.ToDateTime(read["esm_data"]);
                    }

                    toRet.Add(reportItem);
                }
                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar os dados para o inventario\r\n" + e.Message, e);
            }
        }


        

        internal static bool EstornarBaixaEstoqueAgrupado(ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documentoCopia, RecursoClass recurso, ProdutoKClass produtok, EpiClass epi, double quantidade, string observacoes, string entidadeGeradora, AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command, bool consumo)
        {
            try
            {
                if (produto == null && material == null && recurso == null && documentoCopia == null && produtok == null && epi == null)
                {
                    throw new Exception("Indique o item a ser alterado no estoque.");
                }


                List<EstoqueGavetaClass> gavs = EstoqueMovimentacao.BuscaTodasGavetas(produto, material, documentoCopia, recurso, produtok,epi, consumo);

                if (gavs.Count == 0)
                {
                    return false;
                }

                EstoqueGavetaItemClass gavItem =
                    LancaMovimentoEstoque(gavs[0], produto, material, documentoCopia, recurso, produtok, epi, quantidade,
                                          observacoes, entidadeGeradora, usuario, manual, ref command);


                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao lançar a baixa do estoque agrupada.\r\n" + e.Message);
            }


        }



        public static bool EstornarBaixaEstoqueAgrupadoProduto(ProdutoClass produto, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command, bool consumo)
        {
            return EstornarBaixaEstoqueAgrupado(produto, null, null, null, null, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command, consumo);
        }

        public static bool EstornarBaixaEstoqueAgrupadoProdutoK(ProdutoKClass produtok, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {
           return EstornarBaixaEstoqueAgrupado(null, null, null, null, produtok, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command, false);
        }

        public static void EstornarBaixaEstoqueAgrupadoMaterial(MaterialClass material, double quantidade, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command, bool consumo)
        {
            EstornarBaixaEstoqueAgrupado(null, material, null, null, null, null, quantidade, observacoes, entidadeGeradora, usuario, manual, ref command, consumo);
        }

        public static void LancaBaixaTotalGavetaItem(EstoqueGavetaItemClass gavetaItem, string observacoes, string entidadeGeradora,
            AcsUsuarioClass usuario, bool manual, ref IWTPostgreNpgsqlCommand command)
        {

            LancaMovimentoEstoque(
                gavetaItem.EstoqueGaveta,
                gavetaItem.Produto,
                gavetaItem.Material,
                gavetaItem.DocumentoCopia,
                gavetaItem.Recurso,
                gavetaItem.ProdutoK,
                gavetaItem.Epi,
                gavetaItem.Quantidade * -1,
                observacoes,
                entidadeGeradora,
                usuario,
                manual,
                ref command,
                gavetaItem
                );
        }
    }
}
