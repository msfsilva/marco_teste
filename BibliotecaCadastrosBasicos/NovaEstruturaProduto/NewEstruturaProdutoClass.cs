using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.EstruturaProduto;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.TelaProgresso;
using IWTLineComponent;
using IWTPostgreNpgsql;
using IWTTreeComponent;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public class NewEstruturaProdutoClass
    {

        private static string caminhoLog = AppDomain.CurrentDomain.BaseDirectory + "LogEstrutura-" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";

        private static List<ProdutoClass> alteradosEstrOriginal;

        private static List<NewProdutoTreeClass> bufferProdutos = new List<NewProdutoTreeClass>();
        private static DateTime? chaveUnicaUtilizaca = null;

        public static NewProdutoTreeClass CarregarEstrutura(ProdutoPaiFilhoClass itemFilhoACarregar)
        {
            try
            {
               

                if (chaveUnicaUtilizaca != CadProdutoEstruturaFormNew.chaveUnicaAbertura)
                {
                    bufferProdutos = new List<NewProdutoTreeClass>();
                    chaveUnicaUtilizaca = CadProdutoEstruturaFormNew.chaveUnicaAbertura;
                }



                NewProdutoTreeClass toRet = null;
                //if (itemFilhoACarregar.ID != -1)
                //{
                toRet = bufferProdutos.FirstOrDefault(a =>
                                                      a._produtoPaiFilho != null && (
                                                                                        (a._produtoPaiFilho.ID != -1 && a._produtoPaiFilho.ID == itemFilhoACarregar.ID) ||
                                                                                        (a._produtoPaiFilho.ID == -1 && a._produtoPaiFilho.ProdutoPai.ID == itemFilhoACarregar.ProdutoPai.ID && a._produtoPaiFilho.ProdutoFilho.ID == itemFilhoACarregar.ProdutoFilho.ID))
                    );
                //}

                if (toRet == null)
                {
                    //Item ainda não foi carregado 
                    ProdutoClass produtoFilho = itemFilhoACarregar.ProdutoFilho;
                    produtoFilho.VersaoEstruturaCarregada = itemFilhoACarregar.VersaoEstruturaFilho;

                    toRet = new NewProdutoTreeClass(itemFilhoACarregar);
                    bufferProdutos.Add(toRet);

                }


                return toRet;

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar o item \r\n" + e.Message, e);
            }
        }

        public static ProdutoClass SalvarEstrutura(ProdutoClass produtoSalvar, string justificativa, ref TelaProgressoRunner telaProgresso, bool retirarRevisao)
        {
            try
            {
                IWTFunctions.LogClass.EscreverLog("Inicio salvar Estrutura: " + produtoSalvar.Codigo, caminhoLog);

                Dictionary<long, ProdutoClass> bufferProdutosBD = new Dictionary<long, ProdutoClass>();
                alteradosEstrOriginal = new List<ProdutoClass>();

                //Limpa o buffer de entidades para garantir que a versão carregada para comparação seja a mais atual

                telaProgresso.InformWork(0, "Verificando integridade dos dados da estrutura");
                BufferAbstractEntity.ModoSecundario = true;
                //Verifica se nenhuma das estruturas foi alterada e se todas estão na versão atual
                VerificaEstrutura(produtoSalvar, ref bufferProdutosBD);
                BufferAbstractEntity.ModoSecundario = false;
                telaProgresso.InformWork(1, "Verificando produtos que necessitam de revisão");

                IWTFunctions.LogClass.EscreverLog("Fim Verifica Estrutura Geral: " + produtoSalvar.Codigo, caminhoLog);

                Dictionary<long, ProdutoRev> produtosRevisar = new Dictionary<long, ProdutoRev>();
                BuscaProdutosRelacionados(produtoSalvar, ref produtosRevisar, true, true);

                IWTFunctions.LogClass.EscreverLog("Fim Busca Relacionados Geral: " + produtoSalvar.Codigo, caminhoLog);

                if (produtosRevisar.Count == 0)
                {
                    IWTFunctions.LogClass.EscreverLog("Não existe nada para ser salvo: " + produtoSalvar.Codigo, caminhoLog);
                    MessageBox.Show(null, "Não existe nada para ser salvo", "Salvamento da Estrutura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                if (produtosRevisar.Count > 1)
                {
                    telaProgresso.Hide();
                    string itens = "";
                    foreach (ProdutoRev produto in produtosRevisar.Values)
                    {
                        itens += produto.Produto + "\r\n";
                    }

                    ScrollableMessageBox msgBox = new ScrollableMessageBox(null,
                        "Ao revisar esse item os seguintes itens serão revisados: \r\n\r\n" + itens +
                        "\r\nCaso você não queira que os itens sejam revisados, cancele a operação, crie um item novo para os itens que você não deseja alterar.\r\n\r\nDeseja continuar?", "Alteração",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    {
                        TopMost = true
                    };

                    if (msgBox.ShowDialog() != DialogResult.Yes)
                    {
                        //Voltar os status de alterado na estrutura antiga
                        foreach (ProdutoClass produtoClass in alteradosEstrOriginal)
                        {
                            IWTFunctions.LogClass.EscreverLog("Set Produto Alterado True: " + produtoClass.Codigo, caminhoLog);
                            produtoClass.setAlterado(true);
                        }
                        return null;
                    }

                    telaProgresso.Show();
                }



                telaProgresso.InformWork(3, "Salvando os produtos revisados");
                List<ProdutoClass> produtosRevisados = new List<ProdutoClass>();



                ProdutoClass toRet = null;
                IWTPostgreNpgsqlCommand command = null;
                try
                {
                 
                    IWTFunctions.LogClass.EscreverLog(produtosRevisar.Values.Aggregate("", (current, rev) => current + (rev.Produto.Codigo + "(" + rev.Revisao + ") / ")), caminhoLog);

                    BufferAbstractEntity.ModoSecundario = true;
                    string justificativa2 = "Revisão Item " + produtoSalvar.Codigo + (string.IsNullOrWhiteSpace(justificativa) ? "" : "(" + justificativa + ")");
                    command = produtoSalvar.SingleConnection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();
                    IWTFunctions.LogClass.EscreverLog("Inicio Transaction", caminhoLog);
                    while (produtosRevisar.Count > 0)
                    {
                        KeyValuePair<long, ProdutoRev> produtoRev = produtosRevisar.First();

                        IWTFunctions.LogClass.EscreverLog("ProdutoRevisar:" + produtoRev.Value.Produto.Codigo, caminhoLog);

                        ProdutoClass produtoBd;
                        if (produtoRev.Value.Produto.ID == produtoSalvar.ID)
                        {
                            IWTFunctions.LogClass.EscreverLog("ID Igual", caminhoLog);
                            produtoBd = salvarItem(produtoRev.Value.Produto, ref bufferProdutosBD, justificativa, justificativa2, ref produtosRevisados, ref produtosRevisar);
                            if (produtoBd.ID == produtoSalvar.ID)
                            {
                                toRet = produtoBd;
                                IWTFunctions.LogClass.EscreverLog("RetirarRevisao: " + retirarRevisao, caminhoLog);
                                if (retirarRevisao)
                                {

                                    produtoBd.EstruturaEmRevisao = false;
                                }
                            }
                        }
                        else
                        {
                            IWTFunctions.LogClass.EscreverLog("ID Diferente", caminhoLog);
                            produtoBd = salvarItem(produtoRev.Value.Produto, ref bufferProdutosBD, justificativa2, justificativa2, ref produtosRevisados, ref produtosRevisar);
                        }

                    }

                    foreach (ProdutoClass produto in produtosRevisados)
                    {
                        IWTFunctions.LogClass.EscreverLog("SaveProduto:" + produto.Codigo, caminhoLog);
                        produto.CadastroEngenharia = true;
                        produto.Save(ref command);
                    }

                    IWTFunctions.LogClass.EscreverLog("Limpar Buffer", caminhoLog);
                    BufferAbstractEntity.limparBuffer();
                    BufferAbstractEntity.ModoSecundario = false;
                    BufferAbstractEntity.limparBuffer();


                    command.Transaction.Commit();
                    IWTFunctions.LogClass.EscreverLog("Commit", caminhoLog);
                    IWTFunctions.LogClass.EscreverLog("Fim salvar Estrutura: " + produtoSalvar.Codigo, caminhoLog);


                }
                catch (Exception e)
                {
                    IWTFunctions.LogClass.EscreverLog("Exception: " + e.Message, caminhoLog);

                    if (command != null && command.Transaction != null)
                    {
                        IWTFunctions.LogClass.EscreverLog("Rollback", caminhoLog);
                        command.Transaction.Rollback();
                    }
                    throw;
                }



                IWTFunctions.LogClass.EscreverLog("Return: " + toRet, caminhoLog);
                return toRet;

            }
            catch (ExcecaoTratada e)
            {
                IWTFunctions.LogClass.EscreverLog("ExcecaoTratada: " + e.Message, caminhoLog);

                //Voltar os status de alterado na estrutura antiga
                foreach (ProdutoClass produtoClass in alteradosEstrOriginal)
                {
                    IWTFunctions.LogClass.EscreverLog("ProdutoAlterado(true): " + produtoClass, caminhoLog);
                    produtoClass.setAlterado(true);
                }
                throw;
            }
            catch (Exception e)
            {
                IWTFunctions.LogClass.EscreverLog("Exception: " + e.Message, caminhoLog);

                //Voltar os status de alterado na estrutura antiga
                foreach (ProdutoClass produtoClass in alteradosEstrOriginal)
                {
                    IWTFunctions.LogClass.EscreverLog("ProdutoAlterado(true): " + produtoClass, caminhoLog);
                    produtoClass.setAlterado(true);
                }

                throw new Exception("Erro inesperado ao salvar a estrutura.\r\n" + e.Message, e);
            }
            finally
            {
                IWTFunctions.LogClass.EscreverLog("  ", caminhoLog);
                IWTFunctions.LogClass.EscreverLog("--------------------------------------------", caminhoLog);
                IWTFunctions.LogClass.EscreverLog("  ", caminhoLog);
            }

        }

        private static ProdutoClass salvarItem(ProdutoClass produtoSalvar, ref Dictionary<long, ProdutoClass> bufferProdutosBd, string justificativa, string justificativa2, ref List<ProdutoClass> produtosRevisados, ref Dictionary<long, ProdutoRev> produtosRevisar)
        {

            IWTFunctions.LogClass.EscreverLog("Inicio Salvar Item: "+produtoSalvar.Codigo, caminhoLog);
            IWTFunctions.LogClass.EscreverLog("Alterado: " + produtoSalvar.getAlterado(), caminhoLog);

            if (produtoSalvar.getAlterado())
            {
                ProdutoClass produtoBd;
                if (bufferProdutosBd.ContainsKey(produtoSalvar.ID))
                {
                    IWTFunctions.LogClass.EscreverLog("Buffer:Sim", caminhoLog);
                    produtoBd = bufferProdutosBd[produtoSalvar.ID];
                }
                else
                {
                    IWTFunctions.LogClass.EscreverLog("Buffer:Não", caminhoLog);
                    produtoBd = ProdutoBaseClass.GetEntidade(produtoSalvar.ID, LoginClass.UsuarioLogado.loggedUser, produtoSalvar.SingleConnection);
                    bufferProdutosBd.Add(produtoBd.ID, produtoBd);
                }


                int novaVersaoEstrututura;
                IWTFunctions.LogClass.EscreverLog("Em Revisão:" + produtoBd.EstruturaEmRevisao, caminhoLog);
                if (!produtoBd.EstruturaEmRevisao)
                {
                    novaVersaoEstrututura = produtoBd.VersaoEstruturaAtual + 1;
                    produtoBd.VersaoEstruturaAtual = novaVersaoEstrututura;
                    produtoBd.VersaoEstruturaCarregada = novaVersaoEstrututura;

                    IWTFunctions.LogClass.EscreverLog("NovaVersãoEStrutura:"+novaVersaoEstrututura, caminhoLog);
                }
                else
                {
                    novaVersaoEstrututura = produtoBd.VersaoEstruturaAtual;
                    IWTFunctions.LogClass.EscreverLog("NovaVersãoEStrutura (Mantida):" + novaVersaoEstrututura, caminhoLog);
                    produtoBd.limparEstrutura(caminhoLog);
                }

                IWTFunctions.LogClass.EscreverLog("Alterado= false", caminhoLog);
                produtoSalvar.setAlterado(false);
                produtosRevisar.Remove(produtoSalvar.ID);
                produtosRevisados.Add(produtoBd);
                alteradosEstrOriginal.Add(produtoSalvar);

                IWTFunctions.LogClass.EscreverLog("InicioSalvarFilhos", caminhoLog);

                foreach (ProdutoPaiFilhoClass filho in produtoSalvar.Filhos)
                {
                    IWTFunctions.LogClass.EscreverLog("Filho:" + filho.codigoFilho, caminhoLog);

                    ProdutoClass filhoToAdd;
                    if (!produtosRevisados.Any(a=>a.ID == filho.ProdutoFilho.ID))
                    {
                        IWTFunctions.LogClass.EscreverLog("SalvarFilho:" + filho.codigoFilho, caminhoLog);
                        filhoToAdd = salvarItem(filho.ProdutoFilho, ref bufferProdutosBd, justificativa2, justificativa2, ref produtosRevisados, ref produtosRevisar);
                    }
                    else
                    {
                        IWTFunctions.LogClass.EscreverLog("FilhoSalvoAnteriormente:" + filho.codigoFilho, caminhoLog);
                        filhoToAdd = produtosRevisados.First(a => a.ID == filho.ProdutoFilho.ID);
                    }


                    IWTFunctions.LogClass.EscreverLog("AdicionarFilho:" + filho.codigoFilho, caminhoLog);
                    produtoBd.AdicionarFilho(filhoToAdd, filho.QuantidadeFilho, filho.PosicaoDesenhoPai, filho.FilhoCondicional, filho.FilhoCondicionalRegra, filho.QtdCondicional, filho.QtdCondicionalRegra,caminhoLog);
                }

                IWTFunctions.LogClass.EscreverLog("FimSalvarFilhos", caminhoLog);

                IWTFunctions.LogClass.EscreverLog("InicioSalvarMateriais", caminhoLog);
                foreach (ProdutoMaterialClass material in produtoSalvar.Materiais)
                {
                    produtoBd.AdicionarMaterial(
                        material.Material,
                        material.Quantidade,
                        material.PlanoCorte,
                        material.PlanoCorteQuantidade,
                        material.PlanoCorteInformacoesAdicionais,
                        material.PostoTrabalhoCorte,
                        material.Dimensao1,
                        material.PlanoCorteDimensao1,
                        material.UnidadeMedidaDimensao1,
                        material.Dimensao2,
                        material.PlanoCorteDimensao2,
                        material.UnidadeMedidaDimensao2,
                        material.Dimensao3,
                        material.PlanoCorteDimensao3,
                        material.UnidadeMedidaDimensao3,
                        material.MaterialCondicional,
                        material.MaterialCondicionalRegra, 
                        material.QtdCondicional,
                        material.QtdCondicionalRegra, caminhoLog);
                }

                IWTFunctions.LogClass.EscreverLog("FimSalvarMateriais", caminhoLog);

                IWTFunctions.LogClass.EscreverLog("InicioSalvarDocumentos", caminhoLog);
                foreach (ProdutoDocumentoTipoClass documento in produtoSalvar.Documentos)
                {
                    produtoBd.AdicionarDocumento(documento.DocumentoTipoFamilia, caminhoLog);
                }

                IWTFunctions.LogClass.EscreverLog("FimSalvarDocumentos", caminhoLog);

                IWTFunctions.LogClass.EscreverLog("InicioSalvarRecursos", caminhoLog);


                foreach (ProdutoRecursoClass recurso in produtoSalvar.Recursos)
                {
                    produtoBd.AdicionarRecurso(recurso.Recurso, recurso.Hierarquia_Secundario, caminhoLog);
                }

                IWTFunctions.LogClass.EscreverLog("FimSalvarRecursos", caminhoLog);

                IWTFunctions.LogClass.EscreverLog("InicioSalvarPostos", caminhoLog);

                while (produtoBd.CollectionProdutoPostoTrabalhoClassProduto.Count > 0)
                {
                    produtoBd.ExcluirPostoTrabalho(produtoBd.CollectionProdutoPostoTrabalhoClassProduto[0], caminhoLog);
                }

                foreach (ProdutoPostoTrabalhoClass posto in produtoSalvar.CollectionProdutoPostoTrabalhoClassProduto)
                {
                    produtoBd.AdcionarPostoTrabalho(posto.PostoTrabalho, posto.TempoProducao, posto.TempoSetup, posto.Sequencia, caminhoLog);
                }

                IWTFunctions.LogClass.EscreverLog("FimSalvarPostos", caminhoLog);

                IWTFunctions.LogClass.EscreverLog("InicioSalvarAcabamento", caminhoLog);

                if (produtoSalvar.AcabamentoEstruturaCarregada != null)
                {
                    produtoBd.AdicionarAcabamento(produtoSalvar.AcabamentoEstruturaCarregada.Acabamento, caminhoLog);
                }
                else
                {
                    produtoBd.SemAcabamento(caminhoLog);
                }

                 IWTFunctions.LogClass.EscreverLog("FimSalvarAcabamento", caminhoLog);
                produtoBd.DesabilitarJustificativaRevisaoProduto = true;
                if (!produtoBd.EstruturaEmRevisao)
                {
                    IWTFunctions.LogClass.EscreverLog("RevisarProduto: "+produtoBd, caminhoLog);
                    produtoBd.RevisarProduto(TipoRevisaoProduto.Estrutura, justificativa, novaVersaoEstrututura);
                }

               
                return produtoBd;
            }
            else
            {

                IWTFunctions.LogClass.EscreverLog("ProdutoNãoAlterado", caminhoLog);
                ProdutoClass tmp = produtosRevisados.FirstOrDefault(a => a.ID == produtoSalvar.ID);

                if (tmp == null)
                {
                    IWTFunctions.LogClass.EscreverLog("ProdutoNaoEncontradoNosRevisados", caminhoLog);
                    ProdutoClass produtoBd;
                    if (bufferProdutosBd.ContainsKey(produtoSalvar.ID))
                    {
                        IWTFunctions.LogClass.EscreverLog("ProdutoEncontradoBuffer", caminhoLog);
                        produtoBd = bufferProdutosBd[produtoSalvar.ID];
                    }
                    else
                    {
                        IWTFunctions.LogClass.EscreverLog("ProdutoCarregadoBd", caminhoLog);
                        produtoBd = ProdutoBaseClass.GetEntidade(produtoSalvar.ID, LoginClass.UsuarioLogado.loggedUser, produtoSalvar.SingleConnection);
                        bufferProdutosBd.Add(produtoBd.ID, produtoBd);
                    }

                    return produtoBd;
                }
                else
                {
                    IWTFunctions.LogClass.EscreverLog("ProdutoEncontradoNosRevisados", caminhoLog);
                    return tmp;
                }
            }
        }

        private class ProdutoRev
        {
            public ProdutoClass Produto { get; private set; }
            public int Revisao { get; private set; }
            public bool Tratado { get; internal set; }

            public ProdutoRev(ProdutoClass produto, int revisao)
            {
                Produto = produto;
                Revisao = revisao;
                Tratado = false;
            }
        }

        private static void BuscaProdutosRelacionados(ProdutoClass produtoSalvar,  ref Dictionary<long, ProdutoRev> produtosRevisar, bool buscarFilhos, bool somenteAlterados, bool forceFilhos = false, bool gerarLog = true)
        {
            if (gerarLog)
            {
                IWTFunctions.LogClass.EscreverLog("Inicio BuscaProdutos Relacionados: " + produtoSalvar.Codigo, caminhoLog);
                IWTFunctions.LogClass.EscreverLog("ForceFilhos:" + forceFilhos.ToString(), caminhoLog);
                IWTFunctions.LogClass.EscreverLog("SomenteAlterados:" + somenteAlterados.ToString(), caminhoLog);
                IWTFunctions.LogClass.EscreverLog("ProdutoAlterado:" + produtoSalvar.getAlterado(), caminhoLog);
                IWTFunctions.LogClass.EscreverLog("BuscarFilhos:" + buscarFilhos, caminhoLog);
            }
            if (somenteAlterados && !produtoSalvar.getAlterado())
            {
                
                return;
            }

            if (produtosRevisar==null)
            {
                produtosRevisar = new Dictionary<long, ProdutoRev>();
            }



            if (!produtosRevisar.ContainsKey(produtoSalvar.ID))
            {
                if (produtoSalvar.VersaoEstruturaCarregada != produtoSalvar.VersaoEstruturaAtual)
                {
                    string msgErro = "Não é possível salvar a estrutura pois o item " + produtoSalvar + " não está carregado na versão da estrutura atual.";
                    if (gerarLog)
                    {
                        IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                    }
                    throw new ExcecaoTratada(msgErro);
                }
                produtosRevisar.Add(produtoSalvar.ID, new ProdutoRev(produtoSalvar, produtoSalvar.VersaoEstruturaCarregada));
            }
            else
            {
                if (produtoSalvar.VersaoEstruturaCarregada != produtosRevisar[produtoSalvar.ID].Revisao)
                {

                    string msgErro = "Não é possível salvar a estrutura pois o item " + produtoSalvar + " está carregado com versões da estrutura diferentes.";
                    if (gerarLog)
                    {
                        IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                    }
                    throw new ExcecaoTratada(msgErro);
                }

                if (!forceFilhos)
                {
                    return;
                }
            }


            #region Busca Acima

            if (!forceFilhos)
            {
                IWTPostgreNpgsqlCommand command = produtoSalvar.SingleConnection.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.produto_pai_filho.id_produto_pai, " +
                    "  pai.pro_codigo as codigo_pai, " +
                    "  public.produto_pai_filho.ppf_versao_estrutura " +
                    "FROM " +
                    "  public.produto_pai_filho " +
                    "  INNER JOIN public.produto pai ON (public.produto_pai_filho.id_produto_pai = pai.id_produto) " +
                    "  AND (public.produto_pai_filho.ppf_versao_estrutura = pai.pro_versao_estrutura_atual) " +
                    "WHERE " +
                    "  public.produto_pai_filho.id_produto_filho = :id_produto_filho AND " +
                    "  public.produto_pai_filho.ppf_versao_estrutura_filho = :ppf_versao_estrutura_filho ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_filho", NpgsqlDbType.Integer, produtoSalvar.ID));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_versao_estrutura_filho", NpgsqlDbType.Integer, produtoSalvar.VersaoEstruturaAtual));

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();


                while (read.Read())
                {
                    int id = Convert.ToInt32(read["id_produto_pai"]);
                    int versaoEstrutura = Convert.ToInt32(read["ppf_versao_estrutura"]);
                    string codigoPai = read["codigo_pai"].ToString();
                    ProdutoClass prodBd;


                    if (!produtosRevisar.ContainsKey(id))
                    {
                        prodBd = ProdutoBaseClass.GetEntidade(id, LoginClass.UsuarioLogado.loggedUser, command.Connection);

                        if (gerarLog)
                        {
                            IWTFunctions.LogClass.EscreverLog("FilhoForcado: " + prodBd, caminhoLog);
                        }

                        if (prodBd.VersaoEstruturaAtual != versaoEstrutura)
                        {
                            string msgErro = "Não é possível salvar a estrutura pois o item " + prodBd + " não está carregado na versão da estrutura atual.";
                            if (gerarLog)
                            {
                                IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                            }
                            throw new ExcecaoTratada(msgErro);
                        }


                        if (somenteAlterados)
                        {
                            prodBd.setAlterado(true);
                        }

                        BuscaProdutosRelacionados(prodBd, ref produtosRevisar, false, somenteAlterados, gerarLog:gerarLog);
                    }
                    else
                    {
                        if (produtosRevisar[id].Revisao != versaoEstrutura)
                        {
                            string msgErro = "O produto " + codigoPai + " está sendo utilizado em duas revisões diferentes, não é possível continuar.";
                            if (gerarLog)
                            {
                                IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                            }
                            throw new ExcecaoTratada(msgErro);
                        }
                    }

                    //   bufferProdutosBd.Add(id, prodBd);
                    //}


                }

                read.Close();
            }

            #endregion

            if (buscarFilhos)
            {
                #region Busca Abaixo

                foreach (ProdutoPaiFilhoClass filho in produtoSalvar.Filhos)
                {
                    if (gerarLog)
                    {
                        IWTFunctions.LogClass.EscreverLog("Filho:" + filho.codigoFilho, caminhoLog);
                        IWTFunctions.LogClass.EscreverLog("FilhoAlterado:" + filho.ProdutoFilho.getAlterado(), caminhoLog);
                    }
                    if (produtosRevisar.ContainsKey(filho.ProdutoFilho.ID))
                    {
                        if (produtosRevisar[filho.ProdutoFilho.ID].Revisao != filho.VersaoEstruturaFilho)
                        {
                            string msgErro = "O produto " + filho + " está sendo utilizado em duas revisões diferentes, não é possível continuar.";
                            if (gerarLog)
                            {
                                IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                            }
                            throw new ExcecaoTratada(msgErro);
                        }

                        if (somenteAlterados)
                        {
                            if (filho.ProdutoFilho.Filhos.Any(a => a.ProdutoFilho.getAlterado()))
                            {
                                filho.ProdutoFilho.VersaoEstruturaCarregada = filho.VersaoEstruturaFilho;
                                BuscaProdutosRelacionados(filho.ProdutoFilho, ref produtosRevisar, true, somenteAlterados, true, gerarLog:gerarLog);
                            }
                        }

                    }
                    else
                    {
                        if (!somenteAlterados || filho.ProdutoFilho.getAlterado())
                        {
                            filho.ProdutoFilho.VersaoEstruturaCarregada = filho.VersaoEstruturaFilho;
                            BuscaProdutosRelacionados(filho.ProdutoFilho, ref produtosRevisar, true, somenteAlterados, gerarLog:gerarLog);
                        }
                    }
                }
                if (gerarLog)
                {
                    IWTFunctions.LogClass.EscreverLog("FimBuscaFilhos", caminhoLog);
                }


                #endregion

            }
            if (gerarLog)
            {
                IWTFunctions.LogClass.EscreverLog("Fim Busca Relacionados: " + produtoSalvar.Codigo, caminhoLog);
            }
        }

        public static void VerificaEstrutura(ProdutoClass produto)
        {
            Dictionary<long, ProdutoClass> bufferProdutosBd = new Dictionary<long, ProdutoClass>();
            VerificaEstrutura(produto, ref bufferProdutosBd, gerarLog:false);
        }

        private static void VerificaEstrutura(ProdutoClass produtoSalvar, ref Dictionary<long, ProdutoClass> bufferProdutosBd, bool gerarLog = true)
        {

            if (gerarLog)
            {
                IWTFunctions.LogClass.EscreverLog("Inicio Verifica Estrutura: " + produtoSalvar.Codigo, caminhoLog);
            }
            ProdutoClass produtoBd;
            if (bufferProdutosBd.ContainsKey(produtoSalvar.ID))
            {
                produtoBd = bufferProdutosBd[produtoSalvar.ID];
            }
            else
            {
                produtoBd = ProdutoBaseClass.GetEntidade(produtoSalvar.ID, LoginClass.UsuarioLogado.loggedUser, produtoSalvar.SingleConnection);
                bufferProdutosBd.Add(produtoBd.ID, produtoBd);
            }


            if (produtoSalvar.VersaoEstruturaCarregada != produtoBd.VersaoEstruturaAtual)
            {
                ProdutoRevisaoClass ultimaRevisao = produtoBd.CollectionProdutoRevisaoClassProduto.OrderBy(a => a.Data).Last(a => a.Tipo_Estrutura);


                string msgErro = "Não é possível salvar pois o produto " + produtoSalvar + " foi aberto na versão " + produtoSalvar.VersaoEstruturaCarregada + " e a versão atual dele é a " + produtoBd.VersaoEstruturaAtual +
                                 ". A última revisão do produto foi em " + ultimaRevisao.Data + " e feita por " + ultimaRevisao.AcsUsuario + " com a seguinte justificativa: " + ultimaRevisao.Observacao;
                if (gerarLog)
                {
                    IWTFunctions.LogClass.EscreverLog(msgErro, caminhoLog);
                }
                throw new ExcecaoTratada(msgErro);
            }

            foreach (ProdutoPaiFilhoClass filho in produtoSalvar.Filhos)
            {
                VerificaEstrutura(filho.ProdutoFilho, ref bufferProdutosBd, gerarLog: gerarLog);
            }
            if (gerarLog)
            {
                IWTFunctions.LogClass.EscreverLog("Fim Verifica Estrutura: " + produtoSalvar.Codigo, caminhoLog);
            }

        }

        internal static bool VerificaLockItensRelacionados(ProdutoClass produto, IWTPostgreNpgsqlConnection conn, out string mensagem, ref List<ProdutoEstruturaLockClass> locks )
        {
            try
            {

                Dictionary<long, ProdutoClass> buffer = new Dictionary<long, ProdutoClass>();
                Dictionary<long, ProdutoRev> produtosRelacionados = new Dictionary<long, ProdutoRev>();
                BuscaProdutosRelacionados(produto, ref produtosRelacionados, true, false, gerarLog:false);

                if (locks == null)
                {
                    locks = new List<ProdutoEstruturaLockClass>();
                }

                IWTPostgreNpgsqlCommand command = null;
                
                try
                {
                    command = conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();
                    
                    command.CommandText = "LOCK TABLE produto_estrutura_lock IN ACCESS EXCLUSIVE MODE";
                    command.ExecuteNonQuery();

                    List<ProdutoClass> produtosNaoTravados =new List<ProdutoClass>();
                    foreach (ProdutoRev produtoRev in produtosRelacionados.Values)
                    {
                        if (locks.Any(a=>a.Produto.ID == produtoRev.Produto.ID))
                        {
                            continue;
                        }
                        
                        produtosNaoTravados.Add(produtoRev.Produto);
                    }
                    if (produtosNaoTravados.Count > 0)
                    {

                        string where = produtosNaoTravados.Aggregate("", (current, next) => current + " OR produto_estrutura_lock.id_produto = " + next.ID + " ").Substring(3);

                        command.CommandText = "UPDATE produto_estrutura_lock SET prl_arquivado = 1 WHERE (" + where + ") AND prl_data < NOW() - CAST('60 seconds' AS INTERVAL) AND  prl_arquivado = 0 ";
                        command.ExecuteNonQuery();

                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_estrutura_lock.id_produto_estrutura_lock, " +
                            "  public.produto_estrutura_lock.id_produto, " +
                            "  public.produto_estrutura_lock.prl_data, " +
                            "  public.produto_estrutura_lock.prl_usuario, " +
                            "  public.produto_estrutura_lock.prl_mensagem, " +
                            "  public.produto.pro_codigo " +
                            "FROM " +
                            "  public.produto_estrutura_lock " +
                            "  INNER JOIN public.produto ON (public.produto_estrutura_lock.id_produto = public.produto.id_produto) " +
                            "WHERE " +
                            "  prl_arquivado = 0 AND ( "+
                            where + " ) " +
                            "LIMIT 1";

                        IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                        if (read.HasRows)
                        {
                            read.Read();
                            if (read["pro_codigo"].ToString() == produto.Codigo)
                            {
                                mensagem = "O item " + read["pro_codigo"] + " está bloqueado pelo usuário " + read["prl_usuario"] + " para a seguinte operação:\r\n" + read["prl_mensagem"];
                            }
                            else
                            {
                                mensagem = "O item relacionado " + read["pro_codigo"] + " está bloqueado pelo usuário " + read["prl_usuario"] + " para a seguinte operação:\r\n" + read["prl_mensagem"];
                            }
                            read.Close();
                            locks = null;
                            return false;
                        }

                        read.Close();
                    }
                    mensagem = null;
                    return true;
                }
                finally 
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao verificar os locks dos itens relacionados.\r\n" + e.Message, e);
            }
        }

        internal static bool LockItensRelacionados(ProdutoClass produto, IWTPostgreNpgsqlConnection conn, out string mensagem, ref List<ProdutoEstruturaLockClass> locks, string codigoItemPrincipal = null )
        {
            try
            {
                Dictionary<long, ProdutoClass> buffer = new Dictionary<long, ProdutoClass>();
                Dictionary<long, ProdutoRev> produtosRelacionados = new Dictionary<long, ProdutoRev>();
                BuscaProdutosRelacionados(produto, ref produtosRelacionados, true, false, gerarLog: false);

                if (locks == null)
                {
                    locks = new List<ProdutoEstruturaLockClass>();
                }

                //Inicia a Operação de Lock
                IWTPostgreNpgsqlCommand command = null;
                try
                {
                    command = conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    command.CommandText = "LOCK TABLE produto_estrutura_lock IN ACCESS EXCLUSIVE MODE";
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT NOW()";
                    DateTime dataAtualServidor = (DateTime) command.ExecuteScalar();

                    List<ProdutoClass> produtosNaoTravados = new List<ProdutoClass>();
                    foreach (ProdutoRev produtoRev in produtosRelacionados.Values)
                    {
                        if (locks.Any(a => a.Produto.ID == produtoRev.Produto.ID))
                        {
                            continue;
                        }

                        produtosNaoTravados.Add(produtoRev.Produto);
                    }


                    if (produtosNaoTravados.Count > 0)
                    {
                        string where = produtosNaoTravados.Aggregate("", (current, next) => current + " OR produto_estrutura_lock.id_produto = " + next.ID + " ").Substring(3);

                        command.CommandText = "UPDATE produto_estrutura_lock SET prl_arquivado = 1 WHERE (" + where + ") AND prl_data < NOW() - CAST('60 seconds' AS INTERVAL) AND  prl_arquivado = 0 ";
                        command.ExecuteNonQuery();


                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_estrutura_lock.id_produto_estrutura_lock, " +
                            "  public.produto_estrutura_lock.id_produto, " +
                            "  public.produto_estrutura_lock.prl_data, " +
                            "  public.produto_estrutura_lock.prl_usuario, " +
                            "  public.produto_estrutura_lock.prl_mensagem, " +
                            "  public.produto.pro_codigo " +
                            "FROM " +
                            "  public.produto_estrutura_lock " +
                            "  INNER JOIN public.produto ON (public.produto_estrutura_lock.id_produto = public.produto.id_produto) " +
                            "WHERE " +
                            "  prl_arquivado = 0 AND ( "+
                            where + " ) " +
                            "LIMIT 1";

                        IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                        if (read.HasRows)
                        {
                            read.Read();
                            if (read["pro_codigo"].ToString() == produto.Codigo)
                            {
                                mensagem = "O item " + read["pro_codigo"] + " está bloqueado pelo usuário " + read["prl_usuario"] + " para a seguinte operação:\r\n" + read["prl_mensagem"];
                            }
                            else
                            {
                                mensagem = "O item relacionado " + read["pro_codigo"] + " está bloqueado pelo usuário " + read["prl_usuario"] + " para a seguinte operação:\r\n" + read["prl_mensagem"];
                            }
                            read.Close();
                            command.Transaction.Rollback();
                            locks = null;
                            return false;
                        }

                        read.Close();

                        foreach (ProdutoClass produtoRel in produtosNaoTravados)
                        {
                            ProdutoEstruturaLockClass tmp = new ProdutoEstruturaLockClass(LoginClass.UsuarioLogado.loggedUser, conn)
                                                                {
                                                                    Produto = produtoRel,
                                                                    Data = dataAtualServidor,
                                                                    Usuario = LoginClass.UsuarioLogado.loggedUser.Login,
                                                                    Mensagem = "Edição da estrutura do item " + (codigoItemPrincipal ?? produto.ToString())
                                                                };
                            tmp.Save(ref command);
                            locks.Add(tmp);
                        }
                    }

                    command.Transaction.Commit();
                    mensagem = null;
                    return true;
                }
                catch (Exception)
                {

                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao adquirir o lock dos itens relacionados ao produto\r\n" + e.Message, e);
            }
        }

        internal static void Unlock(List<ProdutoEstruturaLockClass> locks, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = null;
                try
                {
                    command = conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();
                    command.CommandText = "LOCK TABLE produto_estrutura_lock IN ACCESS EXCLUSIVE MODE";
                    command.ExecuteNonQuery();


                    foreach (ProdutoEstruturaLockClass @lock in locks)
                    {
                        @lock.Delete(ref command);
                    }

                    command.Transaction.Commit();
                }
                catch (Exception)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao remover os locks da tabela \r\n" + e.Message, e);
            }
        }

        internal static void KeepAliveLock(List<ProdutoEstruturaLockClass> locks, IWTPostgreNpgsqlConnection conn)
        {
            try
            {

                if (locks == null || locks.Count == 0)
                {
                    return;
                }

                IWTPostgreNpgsqlCommand command = null;
                try
                {
                    command = conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    command.CommandText = "LOCK TABLE produto_estrutura_lock IN ACCESS EXCLUSIVE MODE";
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT NOW()";
                    DateTime dataAtualServidor = (DateTime) command.ExecuteScalar();

                    foreach (ProdutoEstruturaLockClass @lock in locks)
                    {
                        @lock.Data = dataAtualServidor;
                        @lock.Save(ref command);
                    }

                    command.Transaction.Commit();
                }
                catch (Exception)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao atualizar os locks da tabela \r\n" + e.Message, e);
            }
        }

    }
}
