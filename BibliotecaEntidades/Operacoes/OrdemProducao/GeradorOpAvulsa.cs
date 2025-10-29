using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTCustomControls;
using IWTDotNetLib.ComplexLoginModule;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{


    public class GeradorOpAvulsa
    {
        public class GerarOpAvulsaParametros
        {
            public ProdutoClass Produto { get; set; }
            public double Quantidade { get; set; }
        }



        public static List<OrdemProducaoClass> Gerar(List<GerarOpAvulsaParametros> itens, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory)
        {



            IWTPostgreNpgsqlCommand command = null;
            try
            {
                List<OrdemProducaoClass> OPs = new List<OrdemProducaoClass>();
                OrdemProducaoGrupoClass Grupo = iOrdemProducaoFactory.getInstanceOPGrupo(conn, usuario);

                Dictionary<ProdutoClass, double> itensGerar = new Dictionary<ProdutoClass, double>();

                command = conn.CreateCommand();
                command.Transaction = conn.BeginTransaction();

                foreach (GerarOpAvulsaParametros item in itens)
                {
                    AddOpItem(item.Produto, item.Quantidade, ref itensGerar);
                }


                foreach (KeyValuePair<ProdutoClass, double> itemGerar in itensGerar)
                {
                    //Gera a OP para o item
                    OPs.Add(
                        Grupo.addOrdemProducao(
                            (int) itemGerar.Key.ID,
                            itemGerar.Key.VersaoEstruturaAtual,
                            itemGerar.Key.Codigo,
                            itemGerar.Key.Descricao,
                            "",
                            "",
                            "",
                            "",
                            false,
                            false,
                            null
                        )
                    );

                    OPs[OPs.Count - 1].qtdExtra = Math.Round(itemGerar.Value, 2, MidpointRounding.ToEven);
                    OPs[OPs.Count - 1].quantidadeEstoque = Math.Round(EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(itemGerar.Key, ref command), 2, MidpointRounding.ToEven);
                    OPs[OPs.Count - 1].qtdExtra += Math.Round(OPs[OPs.Count - 1].quantidadeEstoque, 2, MidpointRounding.ToEven);
                }


                List<OrdemProducaoErroDocumentoClass> Erros = new List<OrdemProducaoErroDocumentoClass>();
                string erroGeral = "";
                PlanoCorteClass planoCorte = new PlanoCorteClass(LoginClass.UsuarioLogado.loggedUser, conn);

                for (int i = 0; i < OPs.Count; i++)
                {

                    OrdemProducaoClass Value = OPs[i];


                    string error = "";

                    List<PedidoItemConfiguradoMaterialClass> itensIncluirPlanoCorte;
                    if (Value.preencherOP(ref command, out error, ref Erros, out itensIncluirPlanoCorte))
                    {
                        foreach (PedidoItemConfiguradoMaterialClass pedidoMaterial in itensIncluirPlanoCorte)
                        {
                            Value.ItensPlanoCorte.Add(planoCorte.AdicionarItemOP(pedidoMaterial, Value));
                        }
                    }
                    else
                    {
                        erroGeral += error + "\r\n";
                        OPs.RemoveAt(i);
                        Grupo.OPs.Remove(Value);
                        i--;

                    }

                    if (Value.Produto != null)
                    {


                        foreach (ProdutoPaiFilhoClass filho in Value.Produto.Filhos)
                        {
                            if (filho.FilhoCondicional)
                            {
                                continue;
                            }

                            double qtd = Math.Round(filho.QuantidadeFilho * Value.Quantidade, 5);

                            Value.addProdutoComponente(
                                filho.ProdutoFilho.ID,
                                null,
                                filho.ProdutoFilho.Codigo,
                                filho.ProdutoFilho.Descricao,
                                qtd,
                                null);
                        }
                    }
                }

                if (erroGeral.Length > 0)
                {

                    DialogResult res = DialogResult.No;

                    if (erroGeral.Length > 1000)
                    {
                        ScrollableMessageBox message = new ScrollableMessageBox(null, "Algumas ops não foram geradas pelos seguintes motivos.\r\n" + erroGeral + "\r\nVocê deseja continuar com a geração das ops das ordens que não apresentaram erros?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        res = message.ShowDialog();
                    }
                    else
                    {
                        res = MessageBox.Show(null, "Algumas ops não foram geradas pelos seguintes motivos.\r\n" + erroGeral + "\r\nVocê deseja continuar com a geração das ops das ordens que não apresentaram erros?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }

                    if (res == DialogResult.No)
                    {
                        command.Transaction.Rollback();
                        return new List<OrdemProducaoClass>();
                    }

                }


                Grupo.Save(ref command);

                Grupo.ordernaOPs();


                command.Transaction.Commit();

                foreach (OrdemProducaoClass op in OPs)
                {
                    op.AtualizarItensPlanoCorte();
                }

                if (planoCorte.CollectionPlanoCorteItemClassPlanoCorte.Count > 0)
                {
                    planoCorte.Save();
                }

                return Grupo.OPs;

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao gerar as Ordens de Produção\r\n" + e.Message, e);
            }

        }

        private static void AddOpItem(ProdutoClass produtoPai, double qtdPai, ref Dictionary<ProdutoClass, double> itensGerar)
        {

            if (produtoPai.EmiteOp)
            {
                if (!itensGerar.ContainsKey(produtoPai))
                {
                    itensGerar.Add(produtoPai, 0);
                }

                itensGerar[produtoPai] = Math.Round(itensGerar[produtoPai] + qtdPai, 2, MidpointRounding.ToEven);
            }

            foreach (ProdutoPaiFilhoClass paiFilho in produtoPai.Filhos)
            {
                if (paiFilho.FilhoCondicional)
                {
                    continue;
                }


                AddOpItem(paiFilho.ProdutoFilho, Math.Round(qtdPai * paiFilho.QuantidadeFilho, 2, MidpointRounding.ToEven), ref itensGerar);
            }
        }
    }
}
