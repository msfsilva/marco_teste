#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.EstruturaProduto;
using BibliotecaCadastrosBasicos.Properties;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.TelaProgresso;
using IWTLineComponent;
using IWTPostgreNpgsql;
using IWTTreeComponent;
using Npgsql;
using ThreadState = System.Threading.ThreadState;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public partial class CadProdutoEstruturaFormNew : IWTBaseForm
    {
        private ScrollPanelMessageFilter filter;

        private ProdutoClass Produto;
        private Point localizacaoUltimoClique;
        private bool alterado;
        private TipoForm Tipo;
        private NewProdutoTreeClass InicioArvore;

        private bool ModoSomenteLeitura;


        internal static DateTime? chaveUnicaAbertura;
        private NewProdutoTreeClass produtoSelecionadoAtual;
        private IWTTreeNode noSelecionado;
        private IWTTreeNode noProdutoRoteiroAberto;

        private List<ProdutoEstruturaLockClass> locks;
        private Thread trLocks;
        private LockKeepAliveRunner lockKeepAliveRunner;
        private IWTPostgreNpgsqlConnection lockConnn;


        
        public CadProdutoEstruturaFormNew(ProdutoClass _produto, TipoForm tipo, bool modoSomenteLeitura = false)
        {
            InitializeComponent();

            this.ModoSomenteLeitura = modoSomenteLeitura;
            this.Tipo = tipo;

            this.Produto = _produto;

          
        }

        private void InitForm()
        {
           

            string mensagem;

            this.locks = new List<ProdutoEstruturaLockClass>();

            if (!this.ModoSomenteLeitura)
            {
                if (!NewEstruturaProdutoClass.LockItensRelacionados(Produto, this.SingleConnection, out mensagem, ref this.locks))
                {
                    if (MessageBox.Show(this, "Não é possível editar a estrutura. " + mensagem + "\r\n\r\nDeseja abrir a estrutura em modo de visualização?", "Item Bloqueado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.ModoSomenteLeitura = true;
                    }
                    else
                    {
                        BeginInvoke(new MethodInvoker(CloseIt));
                        return;
                    }
                }

                lockConnn = new IWTPostgreNpgsqlConnection(this.SingleConnection.ConnectionString);
                lockConnn.Open();

                lockKeepAliveRunner = new LockKeepAliveRunner(lockConnn, this);
                trLocks = new Thread(lockKeepAliveRunner.Start);
                trLocks.Start();
            }

            Produto = marretadaNova(Produto,true,SingleConnection);

          

            
            chaveUnicaAbertura = Configurations.DataIndependenteClass.GetData();


            TelaProgressoRunner telaProgresso = new TelaProgressoRunner("Carregando a Estrutura", null, this);
            
            telaProgresso.InformWork(null, "Carregando a estrutura");
            NewEstruturaProdutoClass.VerificaEstrutura(this.Produto);
            
            telaProgresso.InformWork(null, "Verificando integridade dos dados da estrutura");
            InicializarArvore();

            InicializarRoteiro(this.InicioArvore);
            noProdutoRoteiroAberto = this.iwtTreeDisplay1.Arvore.Cabeca;


            telaProgresso.Finished();



            switch (this.InicioArvore.TipoExibicao)
            {
                case tipoExibicao.Vertical:
                    this.rdbVertical.Checked = true;
                    this.rdbHorizontal.Checked = false;
                    this.rdbArvoreHorizontal.Checked = false;
                    break;
                case tipoExibicao.Horizontal:
                    this.rdbVertical.Checked = false;
                    this.rdbHorizontal.Checked = true;
                    this.rdbArvoreHorizontal.Checked = false;
                    break;
                case tipoExibicao.HorizontalNovo:
                    this.rdbVertical.Checked = false;
                    this.rdbHorizontal.Checked = false;
                    this.rdbArvoreHorizontal.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.AtualizaTextoForm();


            if (this.ModoSomenteLeitura)
            {
                this.btnCopiarEstrutura.Visible = false;
                this.btnCopiarRoteiro.Visible = false;
                this.btnSalvar2.Visible = false;
                this.btnFechar.Visible = false;

                this.splitContainer2.Panel2Collapsed = true;
                this.splitContainer2.IsSplitterFixed = true;

                this.iwtTreeDisplay1.ReadOnly = true;

            }
            else
            {
                this.LoadProdutos();
                this.LoadMateriais();
                this.LoadAcabamentos();
                this.LoadDocumentos();
                this.LoadPostoTrabalho();
                this.LoadRecursos();
            }

        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void AtualizaTextoForm()
        {
            this.Text = "Estrutura do Item: " + this.Produto + " - Rev. " + this.Produto.VersaoEstruturaCarregada + " ( " + this.Produto.UltimaRevisaoEstruturaMotivo + " )";
        }

        private void GerarImagem()
        {
            try
            {
                Font fonte = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                Font fonteGrafico = new Font(FontFamily.GenericSansSerif, 5, FontStyle.Regular);
                Brush brush = new SolidBrush(Color.Black);
                string titulo = "Estrutura do Item: " + this.Produto + " - Rev. " + this.Produto.VersaoEstruturaAtual;
                string titulo2 = this.Produto.UltimaRevisaoEstruturaMotivo;



                Image bmp = new Bitmap(1, 1);
                SizeF size = this.iwtTreeDisplay1.Arvore.imprimirArvore(Graphics.FromImage(bmp),0);
                size.Height = size.Height + 20;
                size.Width = size.Width + 20;
                Graphics g = Graphics.FromImage(bmp);

                SizeF tamanhoTexto = g.MeasureString(titulo, fonte);
                SizeF tamanhoTexto2 = g.MeasureString(titulo2, fonte);
                if (tamanhoTexto2.Width > tamanhoTexto.Width)
                {
                    tamanhoTexto.Width = tamanhoTexto2.Width;
                }

                if (size.Width < (tamanhoTexto.Width) + 150) size.Width = (int) Math.Round((tamanhoTexto.Width) + 150);


                bmp = new Bitmap((int)Math.Round(size.Width), (int)Math.Round(size.Height + 150));
                g = Graphics.FromImage(bmp);
                g.FillRegion(new SolidBrush(Color.White), new Region(new Rectangle(0, 0, bmp.Size.Width, bmp.Size.Height)));

                short cont = 32;
                short cont2 = 65;


                for (int x = 0; x < bmp.Size.Width; x += 25)
                {
                    g.DrawLine(new Pen(Color.LightGray), x, 0, x, bmp.Size.Height);
                    if (x%50 == 0)
                    {

                        g.DrawString((char) cont + "" + (char) cont2, fonteGrafico, brush, x, bmp.Size.Height - 10);
                        cont2++;
                        if (cont2 > 90)
                        {
                            if (cont == 32)
                            {
                                cont = 65;
                            }
                            else
                            {
                                cont++;
                            }
                            cont2 = 65;
                        }

                        if (cont > 90)
                        {
                            cont = 32;
                        }

                    }
                }


                List<string> legendas = new List<string>();
                cont = 0;
                for (int y = 0; y < bmp.Size.Height; y += 25)
                {
                    g.DrawLine(new Pen(Color.LightGray), 0, y, bmp.Size.Width, y);
                    if (y%50 == 0)
                    {
                        legendas.Add(cont.ToString());
                        cont++;
                    }
                }

                int pos = 0;
                for (int x = legendas.Count - 1; x >= 0; x--)
                {
                    g.DrawString(legendas[x], fonteGrafico, brush, 0, pos);
                    pos += 50;
                }




                g.TranslateTransform(10, 10);

                g.TranslateTransform(0, 100);

                this.iwtTreeDisplay1.Arvore.imprimirArvore(g,0);


                g.TranslateTransform(0, -100);

                Bitmap logo = new Bitmap(Resources.Logo_Easi);

                g.DrawImage(logo, 0, 0, 91, 80);

                g.DrawString(titulo, fonte, brush, 98, 40);
                g.DrawString(titulo2, fonte, brush, 98, 40 + tamanhoTexto.Height);

                if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    bmp.Save(this.saveFileDialog1.FileName);
                    Process.Start(this.saveFileDialog1.FileName);
                    MessageBox.Show(this, "Imagem gerada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao gerar a imagem da estrutura\r\n" + e.Message, e);
            }
        }

        private void CopiarRoteiro()
        {
            try
            {
                if (noSelecionado == null)
                {
                    throw new ExcecaoTratada("Selecione o produto que terá seu roteiro subsituido antes de iniciar a operação de cópia");
                }

                if (MessageBox.Show(this, "Essa operação irá apagar o roteiro atual e substitui-lo pelo do item selecionado para cópia. Deseja Continuar?", "Cópia de roteiro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.alterado = true;
                    CadProdutoListForm form = new CadProdutoListForm(this.Tipo, true,somenteAtivos:true);
                    form.ShowDialog();

                    if (form.ItemSelecionado != null)
                    {
                        if (
                            MessageBox.Show(this, "Essa operação irá apagar o roteiro atual e substitui-lo pelo do item selecionado para cópia.\r\n\r\nAtenção!!\r\nEssa operação não poderá ser desfeita.\r\n\r\nDeseja Continuar?", "Cópia",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            ProdutoClass produtoSelecionado = (ProdutoClass)form.ItemSelecionado;
                            

                            if (noSelecionado.Conteudo is NewProdutoTreeClass)
                            {
                                NewProdutoTreeClass tmp = (NewProdutoTreeClass) noSelecionado.Conteudo;
                                tmp.CopiarRoteiro(produtoSelecionado, noSelecionado);
                                
                                tmp.LimparRoteiroGerado();
                                this.InicializarRoteiro(tmp);
                            }
                            else
                            {
                                throw new ExcecaoTratada("O nó selecionado atualmente na árvore não é do tipo produto");
                            }
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao copiar o roteiro.\r\n" + e.Message, e);
            }
        }

        private void CopiarEstrutura()
        {
            try
            {
                if (MessageBox.Show(this, "Essa operação irá apagar a estrutura atual e substituir a mesma pela do item selecionado para cópia. Deseja Continuar?", "Cópia de estrutura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    this.alterado = true;
                    CadProdutoListForm form = new CadProdutoListForm(this.Tipo, true, somenteAtivos: true);
                    form.ShowDialog();
                    if (form.ItemSelecionado != null)
                    {

                        if (
                            MessageBox.Show(this, "Essa operação irá apagar a estrutura atual e substituir a mesma pela do item selecionado para cópia.\r\n\r\nAtenção!!\r\nEssa operação não poderá ser desfeita.\r\n\r\nDeseja Continuar?", "Cópia",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            ProdutoClass produtoSelecionado = (ProdutoClass)form.ItemSelecionado;
                            this.Produto.CopiarEstrutura(produtoSelecionado);

                            this.InicioArvore.LimpaArvoreGeradaAcima(null);

                            this.InicializarArvore();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao copiar a estrutura.\r\n" + e.Message);
            }
        }

        private void Salvar()
        {
            TelaProgressoRunner telaProgresso = null;
            try
            {


                string justificativa = "";
                if (!this.Produto.EstruturaEmRevisao)
                {

                    if (this.Produto.ID != -1)
                    {

                        JustificativaForm formJustificativa =
                            new JustificativaForm("Sr(a). " + LoginClass.UsuarioLogado.loggedUser.Login + " (" + LoginClass.UsuarioLogado.loggedUser.Login +
                                                   ") essa operação será registrada como uma revisão da estrutura do produto em seu nome. Você deseja prosseguir?");
                        formJustificativa.ShowDialog();

                        if (formJustificativa.Abortar)
                        {
                            return;
                        }

                        justificativa = formJustificativa.Justificativa;
                    }

                }

                telaProgresso = new TelaProgressoRunner("Salvando a Estrutura", 4, this);

                ProdutoClass tmp = NewEstruturaProdutoClass.SalvarEstrutura(Produto, justificativa, ref telaProgresso,false);

                telaProgresso.Finished();
                if (tmp != null)
                {
                    chaveUnicaAbertura = new DateTime();
                    Produto = tmp;

                    this.InicializarArvore();
                    this.InicializarRoteiro(this.InicioArvore);

                    this.AtualizaTextoForm();

                    this.alterado = false;

                    lockKeepAliveRunner.ToStop = true;
                    trLocks.Join();

                    NewEstruturaProdutoClass.Unlock(locks, this.SingleConnection);
                    this.locks = new List<ProdutoEstruturaLockClass>();

                    string mensagem;
                    if (!NewEstruturaProdutoClass.LockItensRelacionados(Produto, SingleConnection, out mensagem, ref locks))
                    {
                        MessageBox.Show(this, "O produto foi salvo com sucesso mas não foi possível adquir as travas necessárias no banco de dados para continuar a edição:\r\n" + mensagem, "Item Bloqueado", MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                   

                    trLocks = new Thread(lockKeepAliveRunner.Start);
                    trLocks.Start();

                    MessageBox.Show(this, "Produto Salvo com sucesso!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    throw new Exception("Salvar não retornou a estrutura");
                }



            }
            catch (Exception e)
            {
             
                throw new Exception("Erro ao salvar.\r\n" + e.Message);
            }
            finally
            {
                marretadaNova(Produto, false, SingleConnection);

                if (telaProgresso!=null)
                {
                    telaProgresso.Finished();
                }

               
            }
        }

        public static ProdutoClass marretadaNova(ProdutoClass produto, bool reloadProduto, IWTPostgreNpgsqlConnection connection)
        {
            try
            {

                bool CorrecoesFeitas = false;

                IWTPostgreNpgsqlCommand command = connection.CreateCommand();
                IWTPostgreNpgsqlDataReader read;
                string sql = "";

                #region Identificação estruturas vazias

                //Marco - 2021-04-07 - Não pode ser ativado pois se for não é possível limpar uma estrutra de produto de um item qualquer que o código abaixo recupera a antiga

                //command.CommandText =
                //    "SELECT itens.id_produto,                                                        																														" +
                //    "itens.pro_versao_estrutura_atual,                                                                                                          " +
                //    "versao_revisao,                                                                                                                            " +
                //    "data_revisao                                                                                                                               " +
                //    "                                                                                                                                           " +
                //    "FROM (                                                                                                                                     " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "id_produto,                                                                                                                                " +
                //    "pro_versao_estrutura_atual,                                                                                                                " +
                //    "SUM(qtd_filhos) as qtd_total                                                                                                               " +
                //    "FROM (                                                                                                                                     " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  0 AS qtd_filhos                                                                                                                          " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  COUNT(public.produto_acabamento.id_produto_acabamento) AS qtd_filhos                                                                     " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_acabamento ON (public.produto.id_produto = public.produto_acabamento.id_produto)                               " +
                //    "  AND (public.produto.pro_versao_estrutura_atual = public.produto_acabamento.pac_versao_estrutura)                                         " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  COUNT(public.produto_documento_tipo.id_produto_documento_tipo) AS qtd_filhos                                                             " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_documento_tipo ON (public.produto.id_produto = public.produto_documento_tipo.id_produto)                       " +
                //    "  AND (public.produto.pro_versao_estrutura_atual = public.produto_documento_tipo.pdt_versao_estrutura)                                     " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  COUNT(public.produto_material.id_produto_material) AS qtd_filhos                                                                         " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_material ON (public.produto.id_produto = public.produto_material.id_produto)                                   " +
                //    "  AND (public.produto.pro_versao_estrutura_atual = public.produto_material.prm_versao_estrutura)                                           " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  COUNT(public.produto_pai_filho.id_produto_pai_filho) AS qtd_filhos                                                                       " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_pai_filho ON (public.produto.id_produto = public.produto_pai_filho.id_produto_pai)                             " +
                //    "  AND (public.produto.pro_versao_estrutura_atual = public.produto_pai_filho.ppf_versao_estrutura)                                          " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  COUNT(public.produto_recurso.id_produto_recurso) AS qtd_filhos                                                                           " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_recurso ON (public.produto.id_produto = public.produto_recurso.id_produto)                                     " +
                //    "  AND (public.produto.pro_versao_estrutura_atual = public.produto_recurso.prr_versao_estrutura)                                            " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    ") filhos                                                                                                                                   " +
                //    "GROUP BY                                                                                                                                   " +
                //    "id_produto,                                                                                                                                " +
                //    "pro_versao_estrutura_atual                                                                                                                 " +
                //    "HAVING SUM(qtd_filhos) = 0                                                                                                                 " +
                //    ") as itens                                                                                                                                 " +
                //    "JOIN                                                                                                                                       " +
                //    "(                                                                                                                                          " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto_revisao.id_produto,                                                                                                       " +
                //    "  COUNT(public.produto_revisao.id_produto_revisao) AS qtd_revisoes,                                                                        " +
                //    "  MAX(public.produto_revisao.prr_versao_estrutura) AS versao_revisao,                                                                      " +
                //    "  MAX(public.produto_revisao.prr_data) AS data_revisao                                                                                     " +
                //    "                                                                                                                                           " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto_revisao                                                                                                                   " +
                //    "WHERE                                                                                                                                      " +
                //    "  public.produto_revisao.prr_tipo = 3                                                                                                      " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto_revisao.id_produto                                                                                                        " +
                //    "HAVING                                                                                                                                     " +
                //    " COUNT(public.produto_revisao.id_produto_revisao) > 0                                                                                      " +
                //    ")                                                                                                                                          " +
                //    "as revisoes ON itens.id_produto = revisoes.id_produto                                                                                      " +
                //    "JOIN                                                                                                                                       " +
                //    "(                                                                                                                                          " +
                //    "SELECT                                                                                                                                     " +
                //    "  id_produto                                                                                                                               " +
                //    "FROM (                                                                                                                                     " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual-1 as versao_anterior,                                                                          " +
                //    "  0 AS qtd_filhos                                                                                                                          " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual-1,                                                                                             " +
                //    "  COUNT(public.produto_acabamento.id_produto_acabamento) AS qtd_filhos                                                                     " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_acabamento ON (public.produto.id_produto = public.produto_acabamento.id_produto)                               " +
                //    "  AND (public.produto.pro_versao_estrutura_atual-1 = public.produto_acabamento.pac_versao_estrutura)                                       " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual-1,                                                                                             " +
                //    "  COUNT(public.produto_documento_tipo.id_produto_documento_tipo) AS qtd_filhos                                                             " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_documento_tipo ON (public.produto.id_produto = public.produto_documento_tipo.id_produto)                       " +
                //    "  AND (public.produto.pro_versao_estrutura_atual-1 = public.produto_documento_tipo.pdt_versao_estrutura)                                   " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual-1,                                                                                             " +
                //    "  COUNT(public.produto_material.id_produto_material) AS qtd_filhos                                                                         " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_material ON (public.produto.id_produto = public.produto_material.id_produto)                                   " +
                //    "  AND (public.produto.pro_versao_estrutura_atual-1 = public.produto_material.prm_versao_estrutura)                                         " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual-1,                                                                                             " +
                //    "  COUNT(public.produto_pai_filho.id_produto_pai_filho) AS qtd_filhos                                                                       " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_pai_filho ON (public.produto.id_produto = public.produto_pai_filho.id_produto_pai)                             " +
                //    "  AND (public.produto.pro_versao_estrutura_atual-1 = public.produto_pai_filho.ppf_versao_estrutura)                                        " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    "UNION ALL                                                                                                                                  " +
                //    "                                                                                                                                           " +
                //    "SELECT                                                                                                                                     " +
                //    "  public.produto.id_produto,                                                                                                               " +
                //    "  public.produto.pro_versao_estrutura_atual-1,                                                                                             " +
                //    "  COUNT(public.produto_recurso.id_produto_recurso) AS qtd_filhos                                                                           " +
                //    "FROM                                                                                                                                       " +
                //    "  public.produto                                                                                                                           " +
                //    "  INNER JOIN public.produto_recurso ON (public.produto.id_produto = public.produto_recurso.id_produto)                                     " +
                //    "  AND (public.produto.pro_versao_estrutura_atual-1 = public.produto_recurso.prr_versao_estrutura)                                          " +
                //    "GROUP BY                                                                                                                                   " +
                //    "  public.produto.pro_versao_estrutura_atual,                                                                                               " +
                //    "  public.produto.id_produto                                                                                                                " +
                //    "                                                                                                                                           " +
                //    ") filhos_anterior                                                                                                                          " +
                //    "GROUP BY                                                                                                                                   " +
                //    "id_produto,                                                                                                                                " +
                //    "versao_anterior                                                                                                                            " +
                //    "HAVING SUM(qtd_filhos) > 0 AND versao_anterior>=0                                                                                          " +
                //    ") as estr_anterior ON itens.id_produto = estr_anterior.id_produto                                                                          " +
                //    "                                                                                                                                           " +
                //    "                                                                                                                                           " +
                //    "WHERE data_revisao > '2013-09-12'                                                                                                          ";

                //read = command.ExecuteReader();

                //sql = "";
                //if (read.HasRows)
                //{
                //    while (read.Read())
                //    {
                //        produto = ProdutoClass.GetEntidade(Convert.ToInt64(read["id_produto"]), LoginClass.UsuarioLogado.loggedUser,
                //            connection);

                //        ProdutoEstruturaInconsistenciaClass toSave = new ProdutoEstruturaInconsistenciaClass(LoginClass.UsuarioLogado.loggedUser,
                //            connection)
                //        {
                //            Dados = "Produto com estrutura limpa. Data da revisão: " + read["data_revisao"],
                //            Data = Configurations.DataIndependenteClass.GetData(),
                //            Produto =produto,
                //            ProdutoPaiFilho = null,
                //            VersaoEstrutura = Convert.ToInt32(read["pro_versao_estrutura_atual"])
                //        };
                            

                //        toSave.Save();

                //        sql += "UPDATE produto SET pro_versao_estrutura_atual = pro_versao_estrutura_atual-1 WHERE id_produto = " + read["id_produto"] + "; ";
                //        sql += "DELETE FROM produto_revisao WHERE  id_produto = " + read["id_produto"] + " AND prr_versao_estrutura = " + read["pro_versao_estrutura_atual"] + "; ";

                //        CorrecoesFeitas = true;
                //    }

                //    read.Close();

                //    command.CommandText = sql;
                //    command.ExecuteScalar();
                //}
                //else
                //{
                //    read.Close();
                //}

                #endregion


                #region Identificação Filhos na versão errada

                command.CommandText =
                    "SELECT  " +
                    "  public.produto_pai_filho.id_produto_pai_filho, " +
                    "  public.produto_pai_filho.id_produto_pai, " +
                    "  public.produto_pai_filho.ppf_versao_estrutura, " +
                    "  public.produto_pai_filho.ppf_versao_estrutura_filho," +
                    "  filho.pro_versao_estrutura_atual "+
                    "FROM " +
                    "  public.produto_pai_filho " +
                    "  INNER JOIN public.produto pai ON (public.produto_pai_filho.id_produto_pai = pai.id_produto) " +
                    "  AND (public.produto_pai_filho.ppf_versao_estrutura = pai.pro_versao_estrutura_atual) " +
                    "  INNER JOIN public.produto filho ON (public.produto_pai_filho.id_produto_filho = filho.id_produto) " +
                    "WHERE " +
                    "  public.produto_pai_filho.ppf_versao_estrutura_filho <> filho.pro_versao_estrutura_atual ";

                read = command.ExecuteReader();
                if (read.HasRows)
                 {

                     while (read.Read())
                     {

                         ProdutoEstruturaInconsistenciaClass toSave = new ProdutoEstruturaInconsistenciaClass(LoginClass.UsuarioLogado.loggedUser,
                                                                                                              connection)
                                                                          {
                                                                              Produto = ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto_pai"]), LoginClass.UsuarioLogado.loggedUser, connection),
                                                                              ProdutoPaiFilho = ProdutoPaiFilhoClass.GetEntidade(Convert.ToInt32(read["id_produto_pai_filho"]), LoginClass.UsuarioLogado.loggedUser, connection),
                                                                              Data = Configurations.DataIndependenteClass.GetData(),
                                                                              Dados =
                                                                                  "Produto com filho em versão da estrutura diferente da esperada. Encontrada: " + read["ppf_versao_estrutura_filho"] + " espererada: " +
                                                                                  read["pro_versao_estrutura_atual"],
                                                                              VersaoEstrutura = Convert.ToInt32(read["ppf_versao_estrutura"])
                                                                          };

                         
                         toSave.Save();

                         CorrecoesFeitas = true;
                     }

                     command.CommandText =
                         "UPDATE produto_pai_filho SET ppf_versao_estrutura_filho = ( " +
                         "SELECT  " +
                         "  filho.pro_versao_estrutura_atual " +
                         "FROM " +
                         " produto filho " +
                         "WHERE public.produto_pai_filho.id_produto_filho = filho.id_produto " +
                         ") " +
                         " " +
                         "WHERE produto_pai_filho.id_produto_pai_filho IN ( " +
                         " " +
                         "SELECT  " +
                         "  public.produto_pai_filho.id_produto_pai_filho " +
                         "FROM " +
                         "  public.produto_pai_filho " +
                         "  INNER JOIN public.produto pai ON (public.produto_pai_filho.id_produto_pai = pai.id_produto) " +
                         "  AND (public.produto_pai_filho.ppf_versao_estrutura = pai.pro_versao_estrutura_atual) " +
                         "  INNER JOIN public.produto filho ON (public.produto_pai_filho.id_produto_filho = filho.id_produto) " +
                         "WHERE " +
                         "public.produto_pai_filho.ppf_versao_estrutura_filho <>  filho.pro_versao_estrutura_atual " +
                         ")";
                     command.ExecuteNonQuery();

                 }

                read.Close();
                #endregion


                #region Correção Filhos Maiores que a revisão atual

                command.CommandText =
                    "SELECT                                                                                                                                      " +
                    "id_produto,                                                                                                                                 " +
                    "MAX(pro_versao_estrutura_atual) as versao_estrutura,                                                                                        " +
                    "SUM(qtd_filhos) as qtd_total                                                                                                                " +
                    "FROM (                                                                                                                                      " +
                    "                                                                                                                                            " +
                    "SELECT                                                                                                                                      " +
                    "  public.produto.id_produto,                                                                                                                " +
                    "  public.produto.pro_versao_estrutura_atual,                                                                                                " +
                    "  0 AS qtd_filhos                                                                                                                           " +
                    "FROM                                                                                                                                        " +
                    "  public.produto                                                                                                                            " +
                    "                                                                                                                                            " +
                    "UNION ALL                                                                                                                                   " +
                    "                                                                                                                                            " +
                    "SELECT                                                                                                                                      " +
                    "  public.produto.id_produto,                                                                                                                " +
                    "  -1,                                                                                                                                       " +
                    "  COUNT(public.produto_acabamento.id_produto_acabamento) AS qtd_filhos                                                                      " +
                    "FROM                                                                                                                                        " +
                    "  public.produto                                                                                                                            " +
                    "  INNER JOIN public.produto_acabamento ON (public.produto.id_produto = public.produto_acabamento.id_produto)                                " +
                    "WHERE public.produto.pro_versao_estrutura_atual < public.produto_acabamento.pac_versao_estrutura                                            " +
                    "GROUP BY                                                                                                                                    " +
                    "  public.produto.id_produto                                                                                                                 " +
                    "                                                                                                                                            " +
                    "UNION ALL                                                                                                                                   " +
                    "                                                                                                                                            " +
                    "SELECT                                                                                                                                      " +
                    "  public.produto.id_produto,                                                                                                                " +
                    "    -1,                                                                                                                                     " +
                    "  COUNT(public.produto_documento_tipo.id_produto_documento_tipo) AS qtd_filhos                                                              " +
                    "FROM                                                                                                                                        " +
                    "  public.produto                                                                                                                            " +
                    "  INNER JOIN public.produto_documento_tipo ON (public.produto.id_produto = public.produto_documento_tipo.id_produto)                        " +
                    "WHERE public.produto.pro_versao_estrutura_atual < public.produto_documento_tipo.pdt_versao_estrutura                                        " +
                    "GROUP BY                                                                                                                                    " +
                    "  public.produto.id_produto                                                                                                                 " +
                    "                                                                                                                                            " +
                    "UNION ALL                                                                                                                                   " +
                    "                                                                                                                                            " +
                    "SELECT                                                                                                                                      " +
                    "  public.produto.id_produto,                                                                                                                " +
                    "    -1,                                                                                                                                     " +
                    "  COUNT(public.produto_material.id_produto_material) AS qtd_filhos                                                                          " +
                    "FROM                                                                                                                                        " +
                    "  public.produto                                                                                                                            " +
                    "  INNER JOIN public.produto_material ON (public.produto.id_produto = public.produto_material.id_produto)                                    " +
                    "WHERE (public.produto.pro_versao_estrutura_atual < public.produto_material.prm_versao_estrutura)                                            " +
                    "GROUP BY                                                                                                                                    " +
                    "  public.produto.id_produto                                                                                                                 " +
                    "                                                                                                                                            " +
                    "UNION ALL                                                                                                                                   " +
                    "                                                                                                                                            " +
                    "SELECT                                                                                                                                      " +
                    "  public.produto.id_produto,                                                                                                                " +
                    "    -1,                                                                                                                                     " +
                    "  COUNT(public.produto_pai_filho.id_produto_pai_filho) AS qtd_filhos                                                                        " +
                    "FROM                                                                                                                                        " +
                    "  public.produto                                                                                                                            " +
                    "  INNER JOIN public.produto_pai_filho ON (public.produto.id_produto = public.produto_pai_filho.id_produto_pai)                              " +
                    "WHERE (public.produto.pro_versao_estrutura_atual < public.produto_pai_filho.ppf_versao_estrutura)                                           " +
                    "GROUP BY                                                                                                                                    " +
                    "  public.produto.id_produto                                                                                                                 " +
                    "                                                                                                                                            " +
                    "UNION ALL                                                                                                                                   " +
                    "                                                                                                                                            " +
                    "SELECT                                                                                                                                      " +
                    "  public.produto.id_produto,                                                                                                                " +
                    "    -1,                                                                                                                                     " +
                    "  COUNT(public.produto_recurso.id_produto_recurso) AS qtd_filhos                                                                            " +
                    "FROM                                                                                                                                        " +
                    "  public.produto                                                                                                                            " +
                    "  INNER JOIN public.produto_recurso ON (public.produto.id_produto = public.produto_recurso.id_produto)                                      " +
                    "WHERE (public.produto.pro_versao_estrutura_atual < public.produto_recurso.prr_versao_estrutura)                                             " +
                    "GROUP BY                                                                                                                                    " +
                    "  public.produto.id_produto                                                                                                                 " +
                    "                                                                                                                                            " +
                    ") itens                                                                                                                                     " +
                    "GROUP BY                                                                                                                                    " +
                    "id_produto                                                                                                                                  " +
                    "HAVING                                                                                                                                      " +
                    "SUM(qtd_filhos) >0                                                                                                                          " +
                    "                                                                                                                                            ";

                read = command.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {

                        ProdutoEstruturaInconsistenciaClass toSave = new ProdutoEstruturaInconsistenciaClass(LoginClass.UsuarioLogado.loggedUser,
                                                                                                              connection)
                        {
                            Produto = ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]), LoginClass.UsuarioLogado.loggedUser, connection),
                            ProdutoPaiFilho = null,
                            Data = Configurations.DataIndependenteClass.GetData(),
                            Dados =
                                "Filho com revisão maior do que o pai.",
                            VersaoEstrutura = read["versao_estrutura"] as int?
                        };


                        toSave.Save();


                        sql += "DELETE FROM produto_revisao WHERE  id_produto = " + read["id_produto"] + " AND prr_versao_estrutura > " + read["versao_estrutura"] + "; ";
                        sql += "DELETE FROM produto_acabamento WHERE  id_produto = " + read["id_produto"] + " AND pac_versao_estrutura > " + read["versao_estrutura"] + "; ";
                        sql += "DELETE FROM produto_documento_tipo WHERE  id_produto = " + read["id_produto"] + " AND pdt_versao_estrutura > " + read["versao_estrutura"] + "; ";
                        sql += "DELETE FROM produto_material WHERE  id_produto = " + read["id_produto"] + " AND prm_versao_estrutura > " + read["versao_estrutura"] + "; ";
                        sql += "DELETE FROM produto_pai_filho WHERE  id_produto_pai = " + read["id_produto"] + " AND ppf_versao_estrutura > " + read["versao_estrutura"] + "; ";
                        sql += "DELETE FROM produto_pai_filho WHERE  id_produto_filho = " + read["id_produto"] + " AND ppf_versao_estrutura_filho > " + read["versao_estrutura"] + "; ";
                        sql += "DELETE FROM produto_recurso WHERE  id_produto = " + read["id_produto"] + " AND prr_versao_estrutura > " + read["versao_estrutura"] + "; ";

                        CorrecoesFeitas = true;
                    }

                    read.Close();

                    command.CommandText = sql;
                    command.ExecuteScalar();
                }
                else
                {
                    read.Close();
                }

                #endregion

                if (CorrecoesFeitas)
                {
                    if (reloadProduto)
                    {
                        produto = ProdutoBaseClass.GetEntidade(produto.ID, LoginClass.UsuarioLogado.loggedUser, produto.SingleConnection);
                    }
                    
                }

                
            }
            catch 
            {
     
            }
            return produto;
        }

        internal List<ProdutoEstruturaLockClass> getLocksAtuais()
        {
            return locks;
        }


        private void CloseIt()
        {
            Close();
            
        }

        #region Tabs de Seleção

        private void LoadProdutos()
        {

            try
            {

                this.livProdutos.CacheDados = new IWTListViewCache(
                    typeof (ProdutoClass),
                    new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("BuscaCompleta", this.txtBuscaProd.Text.Trim()),
                            new SearchParameterClass("IdDiferente", this.Produto.ID),
                            new SearchParameterClass("Ativo", true),
                            new SearchParameterClass("Codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                        },
                    ConversaoProdutoGrid
                    ,
                    LoginClass.UsuarioLogado.loggedUser,
                    this.SingleConnection,
                    this.livProdutos
                    );

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao preencher a listagem de produtos\r\n" + e.Message, e);
            }





        }

        private ListViewItem ConversaoProdutoGrid(AbstractEntity arg)
        {

            if (!(arg is ProdutoClass))
            {
                throw new ExcecaoTratada("Não é possivel converter " + arg.ToString() + " do tipo " + arg.GetType() + " em ProdutoClass");
            }

            ProdutoClass produto = (ProdutoClass) arg;
            ListViewItem item = new ListViewItem(produto.ToString());
            item.SubItems.Add(produto.Descricao);
            item.SubItems.Add(produto.CodigoCliente);

            item.Tag = produto;

            return item;
        }

        private void NovoProduto()
        {
            try
            {
                CadProdutoForm form = new CadProdutoForm(null, this.Tipo);
                form.LocationChanged += form_LocationChanged;
                form.ShowDialog();
                this.LoadProdutos();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao incluir um novo produto.\r\n" + e.Message, e);
            }
        }

        private void LoadMateriais()
        {

            try
            {

                this.livMateriais.CacheDados = new IWTListViewCache(
                    typeof (MaterialClass),
                    new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("BuscaCompletaCustom", this.txtBuscaMat.Text.Trim()),
                            new SearchParameterClass("Ativo", true),
                            new SearchParameterClass("FamiliaMaterial", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("Codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                        },
                    ConversaoMaterialGrid
                    ,
                    LoginClass.UsuarioLogado.loggedUser,
                    this.SingleConnection,
                    this.livMateriais

                    );

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao preencher a listagem de materiais\r\n" + e.Message, e);
            }

        }

        private ListViewItem ConversaoMaterialGrid(AbstractEntity arg)
        {

            if (!(arg is MaterialClass))
            {
                throw new ExcecaoTratada("Não é possivel converter " + arg.ToString() + " do tipo " + arg.GetType() + " em MaterialClass");
            }

            MaterialClass material = (MaterialClass) arg;


            ListViewItem item = new ListViewItem(material.FamiliaMaterial.Codigo);
            item.SubItems.Add(material.Codigo);
            item.SubItems.Add(material.Descricao);
            item.SubItems.Add(material.UnidadeMedida.ToString());
            item.SubItems.Add(material.Medida.ToString(CultureInfo.CurrentCulture));
            item.SubItems.Add(material.MedidaLargura.ToString(CultureInfo.CurrentCulture));
            item.SubItems.Add(material.MedidaComprimento.ToString(CultureInfo.CurrentCulture));
            item.SubItems.Add(material.Acabamento != null ? material.Acabamento.Identificacao.ToString(CultureInfo.CurrentCulture) : "");
            item.SubItems.Add(material.Acabamento != null ? material.Acabamento.DescricaoTecnica.ToString(CultureInfo.CurrentCulture) : "");
            item.SubItems.Add(material.CodigoInterno);
            item.SubItems.Add(material.DescricaoAdicional);
            item.Tag = material;
            return item;

        }

        private void NovoMaterial()
        {
            try
            {
                CadMaterialForm form = new CadMaterialForm(null) {VerificaUtilizacao = this.Tipo != TipoForm.Gerencial};
                form.LocationChanged += form_LocationChanged;
                form.ShowDialog();
                this.LoadMateriais();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao incluir um novo material.\r\n" + e.Message, e);
            }
        }

        private void LoadDocumentos()
        {
            try
            {

                this.livDocumentos.CacheDados = new IWTListViewCache(
                    typeof (DocumentoTipoFamiliaClass),
                    new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("BuscaCompleta", this.txtBuscaDocumento.Text.Trim()),
                            new SearchParameterClass("FamiliaDocumento", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("DocumentoTipo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                        },
                    ConversaoDocumentoGrid
                    ,
                    LoginClass.UsuarioLogado.loggedUser,
                    this.SingleConnection,
                    this.livDocumentos
                    );

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao preencher a listagem de Documentos\r\n" + e.Message, e);
            }



        }

        private ListViewItem ConversaoDocumentoGrid(AbstractEntity arg)
        {

            if (!(arg is DocumentoTipoFamiliaClass))
            {
                throw new ExcecaoTratada("Não é possivel converter " + arg.ToString() + " do tipo " + arg.GetType() + " em DocumentoTipoFamiliaClass");
            }

            DocumentoTipoFamiliaClass documentoTipoFamilia = (DocumentoTipoFamiliaClass) arg;


            ListViewItem item = new ListViewItem(documentoTipoFamilia.FamiliaDocumento.Codigo);
            item.SubItems.Add(documentoTipoFamilia.DocumentoTipo.Identificacao);
            item.SubItems.Add(documentoTipoFamilia.DocumentoTipo.RevisaoAtual);
            item.Tag = documentoTipoFamilia;

            return item;

        }

        private void NovoDocumento()
        {
            try
            {
                CadDocumentoTipoForm form = new CadDocumentoTipoForm(null) {VerificaUtilizacao = this.Tipo != TipoForm.Gerencial};
                form.LocationChanged += form_LocationChanged;
                form.ShowDialog();
                this.LoadDocumentos();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao incluir um novo documento\r\n" + e.Message, e);
            }
        }

        private void LoadRecursos()
        {

            try
            {

                this.livRecursos.CacheDados = new IWTListViewCache(
                    typeof (RecursoClass),
                    new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("BuscaCompleta", this.txtBuscaRecursos.Text.Trim()),
                            new SearchParameterClass("Codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                        },
                    ConversaoRecursoGrid
                    ,
                    LoginClass.UsuarioLogado.loggedUser,
                    this.SingleConnection,
                    this.livRecursos
                    );

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao preencher a listagem de Recursos\r\n" + e.Message, e);
            }




        }

        private ListViewItem ConversaoRecursoGrid(AbstractEntity arg)
        {

            if (!(arg is RecursoClass))
            {
                throw new ExcecaoTratada("Não é possivel converter " + arg.ToString() + " do tipo " + arg.GetType() + " em RecursoClass");
            }

            RecursoClass recurso = (RecursoClass) arg;


            ListViewItem item = new ListViewItem(recurso.FamiliaRecurso.ToString());
            item.SubItems.Add(recurso.Codigo);
            item.SubItems.Add(recurso.Nome);
            item.SubItems.Add(recurso.Revisao);
            item.SubItems.Add(recurso.PostoTrabalho != null ? recurso.PostoTrabalho.Codigo : "");
            item.Tag = recurso;

            return item;

        }

        private void NovoRecurso()
        {
            try
            {
                CadRecursoForm form = new CadRecursoForm(null) {VerificaUtilizacao = this.Tipo != TipoForm.Gerencial};
                form.LocationChanged += form_LocationChanged;
                form.ShowDialog();
                this.LoadRecursos();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado o incluir um novo recurso\r\n" + e.Message, e);
            }
        }

        private void LoadAcabamentos()
        {

            try
            {

                this.livAcabamentos.CacheDados = new IWTListViewCache(
                    typeof (AcabamentoClass),
                    new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("BuscaCompleta", this.txtBuscaAcabamento.Text.Trim()),
                            new SearchParameterClass("Identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                        },
                    ConversaoAcabamentoGrid
                    ,
                    LoginClass.UsuarioLogado.loggedUser,
                    this.SingleConnection,
                    this.livAcabamentos
                    );

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao preencher a listagem de Acabamentos\r\n" + e.Message, e);
            }


        }

        private ListViewItem ConversaoAcabamentoGrid(AbstractEntity arg)
        {

            if (!(arg is AcabamentoClass))
            {
                throw new ExcecaoTratada("Não é possivel converter " + arg.ToString() + " do tipo " + arg.GetType() + " em AcabamentoClass");
            }

            AcabamentoClass acabamento = (AcabamentoClass) arg;


            ListViewItem item = new ListViewItem(acabamento.ToString());
            item.SubItems.Add(acabamento.DescricaoTecnica);
            item.SubItems.Add(acabamento.NormaCliente);
            item.SubItems.Add(acabamento.Obs);
            item.Tag = acabamento;

            return item;

        }

        private void NovoAcabamento()
        {
            try
            {
                CadAcabamentoForm form = new CadAcabamentoForm(null) {VerificaUtilizacao = this.Tipo != TipoForm.Gerencial};
                form.LocationChanged += form_LocationChanged;
                form.ShowDialog();
                this.LoadAcabamentos();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao incluir um novo acabamento.\r\n" + e.Message, e);
            }
        }

        private void LoadPostoTrabalho()
        {

            try
            {

                this.livPostoTrabalho.CacheDados = new IWTListViewCache(
                    typeof (PostoTrabalhoClass),
                    new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("BuscaCompleta", this.txtBuscaPostoTrabalho.Text.Trim()),
                            new SearchParameterClass("Codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("Nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("Operacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                            new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                        },
                    ConversaoPostoTrabalhoGrid
                    ,
                    LoginClass.UsuarioLogado.loggedUser,
                    this.SingleConnection,
                    this.livPostoTrabalho
                    );

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao preencher a listagem de Postos de Trabalho\r\n" + e.Message, e);
            }

        }

        private ListViewItem ConversaoPostoTrabalhoGrid(AbstractEntity arg)
        {

            if (!(arg is PostoTrabalhoClass))
            {
                throw new ExcecaoTratada("Não é possivel converter " + arg.ToString() + " do tipo " + arg.GetType() + " em PostoTrabalhoClass");
            }

            PostoTrabalhoClass postoTrabalho = (PostoTrabalhoClass) arg;


            ListViewItem item = new ListViewItem(postoTrabalho.ToString());
            item.SubItems.Add(postoTrabalho.Nome);
            item.SubItems.Add(postoTrabalho.OperacaoPosto);
            item.Tag = postoTrabalho;

            return item;

        }

        private void NovoPostoTrabalho()
        {
            try
            {
                CadPostoTrabalhoForm form = new CadPostoTrabalhoForm(null) {VerificaUtilizacao = this.Tipo != TipoForm.Gerencial};
                form.LocationChanged += form_LocationChanged;
                form.ShowDialog();
                this.LoadPostoTrabalho();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao incluir um novo posto de trabalho\r\n" + e.Message, e);
            }
        }

        private void TrocarCorTabs(TabControl tab, DrawItemEventArgs e)
        {
            try
            {
                Brush BackBrush = new SolidBrush(Color.Green); //Set background color
                Brush ForeBrush = new SolidBrush(Color.Black); //Set foreground color

                switch (e.Index)
                {
                    case 0:
                        BackBrush = new SolidBrush(Color.FromArgb(204, 255, 255));
                        tabItens.BackColor = Color.FromArgb(204, 255, 255);
                        break;
                    case 1:
                        BackBrush = new SolidBrush(Color.FromArgb(255, 204, 204));
                        tabDocumentos.BackColor = Color.FromArgb(255, 204, 204);
                        break;
                    case 2:
                        BackBrush = new SolidBrush(Color.FromArgb(229, 229, 229));
                        tabAcabamentos.BackColor = Color.FromArgb(229, 229, 229);
                        break;
                    case 3:
                        BackBrush = new SolidBrush(Color.FromArgb(200, 255, 200));
                        tabMateriais.BackColor = Color.FromArgb(200, 255, 200);
                        break;
                    case 4:
                        BackBrush = new SolidBrush(Color.FromArgb(255, 255, 204));
                        tabRecursos.BackColor = Color.FromArgb(255, 255, 204);
                        break;
                    case 5:
                        BackBrush = new SolidBrush(Color.FromArgb(102, 255, 255));
                        //tabRoteiro.BackColor = Color.LawnGreen;
                        break;
                }

                Font TabFont;

                if (e.Index == tab.SelectedIndex)
                {
                    TabFont = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Italic);
                }
                else
                {
                    TabFont = e.Font;
                }

                string TabName = tab.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                e.Graphics.FillRectangle(BackBrush, e.Bounds);
                Rectangle r = e.Bounds;
                r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
                e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
                //Dispose objects
                sf.Dispose();
                if (e.Index == tab.SelectedIndex)
                {
                    TabFont.Dispose();
                    BackBrush.Dispose();
                }
                else
                {
                    BackBrush.Dispose();
                    ForeBrush.Dispose();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception a)
            {
                throw new Exception("Erro inesperado ao definir a cor do tab\r\n" + a.Message, a);
            }
        }

        #endregion

        #region Estrutura de Produtos(Árvore)

        private void InicializarArvore()
        {
            try
            {
                InicioArvore = new NewProdutoTreeClass(Produto);
                this.iwtTreeDisplay1.Arvore = InicioArvore.getArvore();
                this.iwtTreeDisplay1.Invalidate();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar a estrutura de produtos.\r\n" + e.Message, e);
            }
        }

        private void InicializarRoteiro(NewProdutoTreeClass produtoSelecionado)
        {
            this.produtoSelecionadoAtual = produtoSelecionado;
            this.iwtLineDisplay1.Linha = produtoSelecionado.getRoteiro();
            this.iwtLineDisplay1.Invalidate();
        }

        private void AlteraVerticalArvore()
        {
            if (this.rdbArvoreHorizontal.Checked)
            {
                this.InicioArvore.ChangeVerticalMode(tipoExibicao.HorizontalNovo);
            }

            if (this.rdbHorizontal.Checked)
            {
                this.InicioArvore.ChangeVerticalMode(tipoExibicao.Horizontal);
            }

            if (this.rdbVertical.Checked)
            {
                this.InicioArvore.ChangeVerticalMode(tipoExibicao.Vertical);
            }

            this.iwtTreeDisplay1.Invalidate();
        }

        internal void AplicarMudancasEstrutura(tipoExibicao _tipoExibicao, int larguraVertical, int alturaVertical, int larguraHorizontal, int alturaHorizontal, int larguraArvoreHorizontal, int alturaArvoreHorizontal, bool Negrito, int tamanhoFonte,
                                               bool negritoLigacao, int tamanhoFonteLigacao)
        {

            this.InicioArvore.getArvore().changePropriedadesImpressao(_tipoExibicao, larguraVertical, alturaVertical, larguraHorizontal, alturaHorizontal, larguraArvoreHorizontal, alturaArvoreHorizontal, Negrito, tamanhoFonte, negritoLigacao,
                                                                      tamanhoFonteLigacao);

            switch (_tipoExibicao)
            {
                case tipoExibicao.Vertical:
                    this.rdbVertical.Checked = true;
                    this.rdbArvoreHorizontal.Checked = false;
                    this.rdbHorizontal.Checked = false;
                    break;
                case tipoExibicao.Horizontal:
                    this.rdbVertical.Checked = false;
                    this.rdbArvoreHorizontal.Checked = false;
                    this.rdbHorizontal.Checked = true;
                    break;
                case tipoExibicao.HorizontalNovo:
                    this.rdbVertical.Checked = false;
                    this.rdbArvoreHorizontal.Checked = true;
                    this.rdbHorizontal.Checked = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("_tipoExibicao");
            }

            this.iwtTreeDisplay1.Invalidate();


        }

        private void ImprimirEstrutura()
        {
            try
            {
                if (this.Produto.ID != -1)
                {
                    EstruturaProdutoReportFormNew form = new EstruturaProdutoReportFormNew(this.Produto);
                    form.LocationChanged += (form_LocationChanged);
                    form.ShowDialog(this);

                    this.Produto.VersaoEstruturaCarregada = Produto.VersaoEstruturaAtual;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao imprimir a estrutura\r\n" + e.Message, e);
            }
        }

        private void MudarModoPainelOpcoes(bool visivel)
        {
            try
            {
                this.panel1.Height = visivel ? 301 : 20;
                this.panel1.Width = visivel ? 171 : 65;
                this.panel1.Location = new Point(this.Location.X + this.Width - this.panel1.Width - 10, this.panel1.Location.Y);
                this.lnkAbrir.Visible = !visivel;
                this.rdbHorizontal.Visible = visivel;
                this.rdbVertical.Visible = visivel;
                this.rdbArvoreHorizontal.Visible = visivel;
                this.lnkOcultar.Visible = visivel;
                this.btnFechar.Visible = visivel;
                this.btnImprimir.Visible = visivel;
                this.btnImagem.Visible = visivel;
                this.grbLegenda.Visible = visivel;

                if (!ModoSomenteLeitura)
                {
                    this.btnCopiarEstrutura.Visible = visivel;
                    this.btnSalvar2.Visible = visivel;
                    this.btnCopiarRoteiro.Visible = visivel;
                    this.btnFechar.Visible = visivel;
                }
                else
                {
                    this.btnCopiarEstrutura.Visible = false;
                    this.btnSalvar2.Visible = false;
                    this.btnCopiarRoteiro.Visible = false;
                    this.btnFechar.Visible = false;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao mudar a exibição do painel de opções\r\n" + e.Message, e);
            }

        }

        private void ConfigurarExibicaoArvore()
        {
            try
            {
                NewConfigurarExibicaoEstruturaForm form = new NewConfigurarExibicaoEstruturaForm(this, this.InicioArvore.getArvore().TipoExibicao,
                                                                                                 this.InicioArvore.getArvore().larguraOriginalVertical, this.InicioArvore.getArvore().alturaOriginalVertical,
                                                                                                 this.InicioArvore.getArvore().larguraOriginalHorizontal, this.InicioArvore.getArvore().alturaOriginalHorizontal,
                                                                                                 this.InicioArvore.getArvore().larguraOriginalArvoreHorizontal, this.InicioArvore.getArvore().alturaOriginalArvoreHorizontal,
                                                                                                 this.InicioArvore.getArvore().getNegrito(), this.InicioArvore.getArvore().getTamanhoFonte(),
                                                                                                 this.InicioArvore.getArvore().negritoLigacao, this.InicioArvore.getArvore().TamanhoFonteLigacaoOriginal, LoginClass.UsuarioLogado.loggedUser);
                form.LocationChanged += (form_LocationChanged);
                form.Show();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao configura a exibição da árvore.\r\n" + e.Message, e);
            }
        }

        private void ReexibirTodosNos()
        {
            try
            {


                this.iwtTreeDisplay1.Arvore.reexibirTodosNos();
                this.iwtTreeDisplay1.Invalidate();
                this.AtualizaOcultos();

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao reexibir os nos.\r\n" + e.Message, e);
            }
        }

        private void AbrirNoArvore(Point location)
        {
            try
            {
                IWTTreeNode no = this.iwtTreeDisplay1.buscaNoPosicao(location);
                if (no != null)
                {
                    this.AbrirEntidade((AbstractEntity)no.Conteudo.getEntidadeOrigem());
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao abrir o nó da árvore.\r\n" + e.Message, e);
            }
        }

        private void SelecionaNoArvore(Point location)
        {
            try
            {
                this.alterado = true;

                noSelecionado = this.iwtTreeDisplay1.buscaNoPosicao(location);
                if (noSelecionado != null)
                {
                    if (noSelecionado.Conteudo.GetType().FullName == "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewProdutoTreeClass")
                    {
                        noProdutoRoteiroAberto = noSelecionado;
                        InicializarRoteiro((NewProdutoTreeClass) noSelecionado.Conteudo);
                    }

                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao selecionar um no na árvore\r\n" + e.Message, e);
            }
        }

        private void AtualizaOcultos()
        {
            try
            {
                int qtdOcultos = this.iwtTreeDisplay1.Arvore.qtdNosOcultos;
                if (qtdOcultos > 0)
                {
                    this.lblOcultos.Text = "Nós Ocultos: " + qtdOcultos;
                    this.lblOcultos.Visible = true;
                    this.btnReexibir.Visible = true;
                }
                else
                {
                    this.lblOcultos.Visible = false;
                    this.btnReexibir.Visible = false;

                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao atulizar a quantidade de nós ocultos.\r\n" + e.Message, e);
            }

        }

        private void EditarLigacaoNo(IWTTreeNode no)
        {

            try
            {
                if (no != null)
                {
                    switch (no.Conteudo.GetType().FullName)
                    {
                        case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewProdutoTreeClass":
                            CadProdutoFilhoProdutoForm form = new CadProdutoFilhoProdutoForm(
                                ((NewProdutoTreeClass) no.Conteudo).getQuantidade(),
                                ((NewProdutoTreeClass) no.Conteudo).PosicaoDesenhoPai,
                                ((NewProdutoTreeClass)no.Conteudo).Condicional,
                                ((NewProdutoTreeClass)no.Conteudo).RegraCondicional,
                                ((NewProdutoTreeClass)no.Conteudo).QtdCondicional,
                                ((NewProdutoTreeClass)no.Conteudo).QtdCondicionalRegra
                                
                                );
                            form.ShowDialog(this);
                            if (form.Quantidade.HasValue)
                            {
                                ((NewProdutoTreeClass)no.Conteudo).setQuantidade(form.Quantidade.Value);
                                ((NewProdutoTreeClass)no.Conteudo).PosicaoDesenhoPai = form.LocalizacaoDesenhoPai;
                                ((NewProdutoTreeClass)no.Conteudo).Condicional = form.Condicional;
                                ((NewProdutoTreeClass)no.Conteudo).RegraCondicional = form.CondicionalRegra;
                                ((NewProdutoTreeClass)no.Conteudo).QtdCondicional = form.QtdCondicional;
                                ((NewProdutoTreeClass)no.Conteudo).QtdCondicionalRegra = form.QtdCondicionalRegra;

                                this.BuscaProdutoArvore(((NewProdutoTreeClass)((IWTTreeNode)no.getNoPai()).Conteudo));
                                this.InicializarArvore();
                                
                            }

                            break;
                        case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewMaterialTreeClass":

                            IWTTreeNode noPai = (IWTTreeNode) no.getNoPai();
                            InicializarRoteiro((NewProdutoTreeClass) noPai.Conteudo);

                            NewMaterialTreeClass mat = (NewMaterialTreeClass) no.Conteudo;
                            CadProdutoMaterialFormNew qtdForm = new CadProdutoMaterialFormNew(
                                this.iwtLineDisplay1.Linha,
                                mat.Quantidade.Value,
                                mat.PlanoCorte,
                                mat.PlanoCorteQuantidade,
                                mat.Dimensao1,
                                mat.Dimensao1Valor,
                                mat.Dimensao2,
                                mat.Dimensao2Valor,
                                mat.Dimensao3,
                                mat.Dimensao3Valor,
                                mat.PostoTrabalhoCorte,
                                mat.PlanoCorteInformacoesAdicionais,
                                mat.Unidade1,
                                mat.Unidade2,
                                mat.Unidade3,
                                mat.ToString(),
                                mat.unidadeMedida,
                                mat.Condicional,
                                mat.CondicionalRegra,
                                mat.QuantidadeCondicional,
                                mat.QuantidadeCondicionalRegra
                                );


                            qtdForm.LocationChanged += (form_LocationChanged);
                            qtdForm.ShowDialog();


                            if (qtdForm.Quantidade != null)
                            {

                                mat.setQuantidade((double) qtdForm.Quantidade );
                                mat.setQtdCondicional(qtdForm.QuantidadeCondicional, qtdForm.QuantidadeCondicionalRegra);
                                if (qtdForm.PlanoCorte)
                                {
                                    mat.setPlanoCorte(
                                        qtdForm.PlanoCorteQuantidade,
                                        qtdForm.PlanoCorteInformacoesAdicionais,
                                        qtdForm.PostoTrabalhoCorte,
                                        qtdForm.Dimensao1,
                                        qtdForm.Dimensao1Valor,
                                        qtdForm.Unidade1,
                                        qtdForm.Dimensao2,
                                        qtdForm.Dimensao2Valor,
                                        qtdForm.Unidade2,
                                        qtdForm.Dimensao3,
                                        qtdForm.Dimensao3Valor,
                                        qtdForm.Unidade3
                                        );
                                }
                                else
                                {
                                    mat.limparPlanoCorte();
                                }


                                mat.setCondicional(qtdForm.Condicional, qtdForm.CondicionalRegra);
                                

                                this.BuscaProdutoArvore(((NewProdutoTreeClass)noPai.Conteudo));
                                this.InicializarArvore();
                            }

                            break;
                        case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewDocumentoTreeClass":

                            break;
                        case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewRecursoTreeClass":
                            CadProdutoRecursoForm recursoForm = new CadProdutoRecursoForm(((NewRecursoTreeClass) no.Conteudo).Secundario);
                            recursoForm.LocationChanged += (form_LocationChanged);
                            recursoForm.ShowDialog();
                            if (!recursoForm.abortar)
                            {
                                ((NewRecursoTreeClass) no.Conteudo).Secundario = recursoForm.Secundario;
                                this.BuscaProdutoArvore(((NewProdutoTreeClass)((IWTTreeNode)no.getNoPai()).Conteudo));
                                this.InicializarArvore();

                            }
                            break;
                        case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewAcabamentoTreeClass":

                            break;

                    }

                    no.Alterado = true;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao editar a ligação do nó.\r\n" + e.Message, e);
            }



        }

        private void BuscaProdutoArvore(NewProdutoTreeClass produtoPai)
        {
            foreach (IWTTreeNivel treeNivel in this.iwtTreeDisplay1.Arvore.arvoreLargura.Values)
            {
                foreach (IWTTreeNode no in treeNivel.Nos)
                {
                    if (!(no.Conteudo is NewProdutoTreeClass)) continue;
                    if (no.Conteudo.getEntidadeOrigem() == produtoPai.getEntidadeOrigem())
                    {
                        ((NewProdutoTreeClass)no.Conteudo).LimpaArvoreGeradaAcima(no);
                    }
                }
            }




        }

        private void ExcluirNo(IWTTreeNode no)
        {
            try
            {
                ((NewProdutoTreeClass) (no.Pai.Conteudo)).ExcluirFilho(no.Pai, no.Conteudo);
                this.BuscaProdutoArvore((NewProdutoTreeClass) no.Pai.Conteudo);
                this.InicializarArvore();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inexperado ao excluir o No.\r\n" + e.Message, e);
            }
        }

        #endregion

        #region Roteiro (Line)

        private void AbrirNoRoteiro(Point location)
        {
            try
            {
                IWTLineNode no = this.iwtLineDisplay1.buscaNoPosicao(location);
                if (no != null)
                {
                    this.AbrirEntidade((AbstractEntity)no.Conteudo.getEntidadeOrigem());
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao abrir o nó do roteiro.\r\n" + e.Message, e);
            }
        }

        private void ExcluirNoRoteiro(IWTLineNode no)
        {
            ((NewPostoTrabalhoTreeClass) (no.Conteudo)).ProdutoPai.ExcluirPostoTrabalho((NewPostoTrabalhoTreeClass) (no.Conteudo), noSelecionado);

            this.BuscaProdutoArvore(((NewPostoTrabalhoTreeClass) (no.Conteudo)).ProdutoPai);
            this.InicializarRoteiro(((NewPostoTrabalhoTreeClass)(no.Conteudo)).ProdutoPai);
        }

        private void EditarNoRoteiro(IWTLineNode no)
        {
            NewPostoTrabalhoTreeClass postoTrabalho = (NewPostoTrabalhoTreeClass) (no.Conteudo);
            CadProdutoPostoTrabalhoForm form = new CadProdutoPostoTrabalhoForm(postoTrabalho.TempoSetup, postoTrabalho.TempoProducao);
            form.ShowDialog(this);
            if (!form.Abortar)
            {
                postoTrabalho.TempoSetup = form.TempoSetup;
                postoTrabalho.TempoProducao = form.TempoProducao;

                
                postoTrabalho.ProdutoPai.setProdutoAlterado(noProdutoRoteiroAberto);
                this.iwtLineDisplay1.Invalidate();
            }

        }

        #endregion

        #region Vizualização de Entidades

        private void AbrirEntidade(AbstractEntity entidade)
        {

            try
            {
                switch (entidade.GetType().FullName)
                {
                    case "BibliotecaEntidades.Entidades.ProdutoClass":
                        this.VisualizarProduto((ProdutoClass) entidade);
                        break;
                    case "BibliotecaEntidades.Entidades.ProdutoPaiFilhoClass":
                        this.VisualizarProduto(((ProdutoPaiFilhoClass) entidade).ProdutoFilho);
                        break;
                    case "BibliotecaEntidades.Entidades.ProdutoMaterialClass":
                        this.VisualizarMaterial(((ProdutoMaterialClass) entidade).Material);
                        break;
                    case "BibliotecaEntidades.Entidades.ProdutoDocumentoTipoClass":
                        this.VisualizarDocumento(((ProdutoDocumentoTipoClass) entidade).DocumentoTipoFamilia.DocumentoTipo);
                        break;
                    case "BibliotecaEntidades.Entidades.ProdutoRecursoClass":
                        this.VisualizarRecurso(((ProdutoRecursoClass) entidade).Recurso);
                        break;
                    case "BibliotecaEntidades.Entidades.ProdutoAcabamentoClass":
                        this.VisualizarAcabamento(((ProdutoAcabamentoClass) entidade).Acabamento);
                        break;
                    case "BibliotecaEntidades.Entidades.ProdutoPostoTrabalhoClass":
                        this.VisualizarPostoTrabalho(((ProdutoPostoTrabalhoClass) entidade).PostoTrabalho);
                        break;

                    case "BibliotecaEntidades.Entidades.MaterialClass":
                        this.VisualizarMaterial(((MaterialClass) entidade));
                        break;
                    case "BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass":
                        this.VisualizarDocumento(((DocumentoTipoFamiliaClass) entidade).DocumentoTipo);
                        break;
                    case "BibliotecaEntidades.Entidades.RecursoClass":
                        this.VisualizarRecurso(((RecursoClass) entidade));
                        break;
                    case "BibliotecaEntidades.Entidades.AcabamentoClass":
                        this.VisualizarAcabamento(((AcabamentoClass) entidade));
                        break;
                    case "BibliotecaEntidades.Entidades.PostoTrabalhoClass":
                        this.VisualizarPostoTrabalho(((PostoTrabalhoClass) entidade));
                        break;
                    default:
                        throw new Exception("Tipo Inválido de Entidade " + entidade.GetType().FullName);
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao selecionar o tipo de visualização de entidade.\r\n" + e.Message, e);
            }

        }

        private void VisualizarPostoTrabalho(PostoTrabalhoClass postoTrabalho)
        {
            try
            {
                CadPostoTrabalhoForm form = new CadPostoTrabalhoForm(postoTrabalho);
                form.SomenteLeitura = true;
                form.LocationChanged += (form_LocationChanged);
                form.Show();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o posto de trabalho para visualização.\r\n" + e.Message, e);
            }
        }

        private void VisualizarAcabamento(AcabamentoClass acabamento)
        {
            try
            {
                CadAcabamentoForm form6 = new CadAcabamentoForm(acabamento)
                                              {
                                                  SomenteLeitura = true,
                                                  VerificaUtilizacao = this.Tipo != TipoForm.Gerencial
                                              };
                form6.LocationChanged += (form_LocationChanged);
                form6.ShowDialog();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o acabamento para visualização.\r\n" + e.Message, e);
            }
        }

        private void VisualizarRecurso(RecursoClass recurso)
        {
            try
            {
                CadRecursoForm form5 = new CadRecursoForm(recurso) {SomenteLeitura = true};
                form5.LocationChanged += (form_LocationChanged);
                form5.ShowDialog();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o recurso para visualização.\r\n" + e.Message, e);
            }
        }

        private void VisualizarDocumento(DocumentoTipoClass documento)
        {
            try
            {
                CadDocumentoTipoForm form4 = new CadDocumentoTipoForm(documento)
                                                 {
                                                     VerificaUtilizacao = this.Tipo != TipoForm.Gerencial,
                                                     SomenteLeitura = true
                                                 };
                form4.LocationChanged += (form_LocationChanged);
                form4.ShowDialog();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o documento para visualização.\r\n" + e.Message, e);
            }
        }

        private void VisualizarMaterial(MaterialClass material)
        {
            try
            {
                CadMaterialForm form2 = new CadMaterialForm(material) {SomenteLeitura = true};
                form2.LocationChanged += (form_LocationChanged);
                form2.ShowDialog();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o material para visualização.\r\n" + e.Message, e);
            }
        }

        private void VisualizarProduto(ProdutoClass produto)
        {
            try
            {
                CadProdutoForm form = new CadProdutoForm(produto, TipoModulo.Tipo) {SomenteLeitura = true};
                form.LocationChanged += (form_LocationChanged);
                form.Show();

                CadProdutoPCPForm formPcp = new CadProdutoPCPForm(produto, true);
                formPcp.Show();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o produto para visualização.\r\n" + e.Message, e);
            }
        }

        #endregion

        #region Eventos

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Salvar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alterado = false;
                BufferAbstractEntity.limparBuffer();
                this.Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {

            try
            {
                NovoProduto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnNovoMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoMaterial();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNovoDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoDocumento();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnNovoRecurso_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoRecurso();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNovoAcabamento_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoAcabamento();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovoPostoTrabalho_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoPostoTrabalho();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopiarEstrutura_Click(object sender, EventArgs e)
        {
            try
            {
                this.CopiarEstrutura();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbVertical_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.AlteraVerticalArvore();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.AlteraVerticalArvore();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbArvoreHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.AlteraVerticalArvore();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeTabColor(object sender, DrawItemEventArgs e)
        {
            try
            {
                this.TrocarCorTabs((TabControl) sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.ImprimirEstrutura();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void lnkOcultar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.MudarModoPainelOpcoes(false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void lnkAbrir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.MudarModoPainelOpcoes(true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadProdutoEstruturaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModoSomenteLeitura) return;

            if (!this.alterado)
            {
                if (this.lockKeepAliveRunner != null && this.trLocks != null)
                {
                    this.lockKeepAliveRunner.ToStop = true;
                    trLocks.Join();
                    if (lockConnn != null)
                    {
                        lockConnn.Close();
                    }

                    NewEstruturaProdutoClass.Unlock(locks, this.SingleConnection);
                    this.locks = new List<ProdutoEstruturaLockClass>();
                }
                return;
            }

            DialogResult res = MessageBox.Show(this, "O produto foi alterado e não foi salvo, deseja salvar antes de sair?", "Salvar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (res)
            {

                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    this.btnSalvar_Click(null, null);
                    if (this.lockKeepAliveRunner != null && this.trLocks != null)
                    {
                        this.lockKeepAliveRunner.ToStop = true;
                        trLocks.Join();
                        if (lockConnn != null)
                        {
                            lockConnn.Close();
                        }

                        NewEstruturaProdutoClass.Unlock(locks, this.SingleConnection);
                        this.locks = new List<ProdutoEstruturaLockClass>();
                    }
                    break;
                case DialogResult.No:
                    if (this.lockKeepAliveRunner != null && this.trLocks != null)
                    {
                        this.lockKeepAliveRunner.ToStop = true;
                        trLocks.Join();
                        if (lockConnn != null)
                        {
                            lockConnn.Close();
                        }

                        NewEstruturaProdutoClass.Unlock(locks, this.SingleConnection);
                        this.locks = new List<ProdutoEstruturaLockClass>();

                        this.Produto.RollbackSomenteEntidade();
                    }
                    break;
            }
        }

        private void configurarExibiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.ConfigurarExibicaoArvore();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void form_LocationChanged(object sender, EventArgs e)
        {
            this.iwtTreeDisplay1.Invalidate();
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            try
            {

                this.GerarImagem();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadProdutoEstruturaForm_Activated(object sender, EventArgs e)
        {
            filter = new ScrollPanelMessageFilter(this.iwtTreeDisplay1);
            Application.AddMessageFilter(filter);

        }

        private void CadProdutoEstruturaForm_Deactivate(object sender, EventArgs e)
        {
            Application.RemoveMessageFilter(filter);
        }

        private void btnReexibir_Click(object sender, EventArgs e)
        {

            try
            {
                this.ReexibirTodosNos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopiarRoteiro_Click(object sender, EventArgs e)
        {
            try
            {
                this.CopiarRoteiro();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadProdutoEstruturaFormNew_Shown(object sender, EventArgs e)
        {
            try
            {
                this.InitForm();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Eventos Árvore

        private void iwtTreeDisplay1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.AbrirNoArvore(e.Location);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void livProdutos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.AbrirEntidade(this.livProdutos.GetItensSelecionados()[0]);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void livMateriais_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                this.AbrirEntidade(this.livMateriais.GetItensSelecionados()[0]);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void livDocumentos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.AbrirEntidade(this.livDocumentos.GetItensSelecionados()[0]);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void livRecursos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.AbrirEntidade(this.livRecursos.GetItensSelecionados()[0]);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void livAcabamentos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.AbrirEntidade(this.livAcabamentos.GetItensSelecionados()[0]);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void livPostoTrabalho_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.AbrirEntidade(this.livPostoTrabalho.GetItensSelecionados()[0]);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iwtTreeDisplay1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                this.alterado = true;
                if (e.Button == MouseButtons.Right)
                {
                    this.localizacaoUltimoClique = e.Location;
                    contextMenuStrip1.Show(this, e.Location);

                }
                else
                {
                    this.SelecionaNoArvore(e.Location);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void iwtLineDisplay1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.alterado = true;
                if (e.Button == MouseButtons.Right)
                {
                    this.localizacaoUltimoClique = e.Location;
                    contextMenuStrip2.Show(this, tabControl2.PointToScreen(e.Location));

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void iwtLineDisplay1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.AbrirNoRoteiro(e.Location);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            try
            {

                this.alterado = true;
                IWTTreeNode no = this.iwtTreeDisplay1.buscaNoPosicao(this.localizacaoUltimoClique);
                switch (e.ClickedItem.ToString())
                {
                    case "Excluir":

                        if (no != null && no.Pai != null)
                        {
                            this.ExcluirNo(no);

                        }
                        break;

                    case "Ocultar":
                        if (no != null && no.Pai != null)
                        {
                            no.Ocultar(true);
                        }


                        break;

                    case "Editar Ligação":
                        if (no != null && no.Pai != null)
                        {
                            this.EditarLigacaoNo(no);
                        }
                        break;

                }

                this.AtualizaOcultos();

                this.contextMenuStrip1.Visible = false;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                this.alterado = true;
                IWTLineNode no;
                switch (e.ClickedItem.ToString())
                {
                    case "Excluir":
                        no = this.iwtLineDisplay1.buscaNoPosicao(this.localizacaoUltimoClique);
                        if (no != null && no.Anterior != null)
                        {
                            this.ExcluirNoRoteiro(no);
                        }
                        break;
                    case "Editar Ligação":
                        no = this.iwtLineDisplay1.buscaNoPosicao(this.localizacaoUltimoClique);
                        if (no != null && no.Anterior != null)
                        {
                            this.EditarNoRoteiro(no);
                        }
                        break;

                }

                this.contextMenuStrip1.Visible = false;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region Eventos Drag - Árvore

        private void iwtTreeDisplay1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                this.alterado = true;
                IWTTreeNode destinationNode = this.iwtTreeDisplay1.buscaNoPosicao(iwtTreeDisplay1.PointToClient(new Point(e.X, e.Y)));
                ListViewItem tmp = (ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem");
                

                if (destinationNode != null)
                {
                    if (destinationNode.Conteudo.GetType().FullName == "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewProdutoTreeClass")
                    {

                        NewProdutoTreeClass produtoPai = (NewProdutoTreeClass) destinationNode.Conteudo;

                        switch (tmp.Tag.GetType().FullName)
                        {
                            case "BibliotecaEntidades.Entidades.ProdutoClass":

                                ProdutoClass produtoAdicionar = (ProdutoClass) tmp.Tag;

                                this.lockKeepAliveRunner.ToStop = true;
                                this.trLocks.Join();

                                string mensagem;
                                if (!NewEstruturaProdutoClass.LockItensRelacionados(produtoAdicionar, this.SingleConnection, out mensagem, ref locks,this.Produto.Codigo))
                                {
                                    trLocks = new Thread(lockKeepAliveRunner.Start);
                                    this.trLocks.Start();
                                    throw new ExcecaoTratada("Não é possível incluir esse item na estrutura:\r\n" + mensagem);
                                }

                                trLocks = new Thread(lockKeepAliveRunner.Start);
                                this.trLocks.Start();

                                produtoAdicionar = ProdutoBaseClass.GetEntidade(produtoAdicionar.ID, LoginClass.UsuarioLogado.loggedUser, produtoAdicionar.SingleConnection);


                                CadProdutoFilhoProdutoForm form = new CadProdutoFilhoProdutoForm();
                                form.LocationChanged += (form_LocationChanged);
                                form.ShowDialog();

                                if (form.Quantidade != null)
                                {

                                    produtoPai.AdicionarFilho(destinationNode, produtoAdicionar, (double) form.Quantidade, form.LocalizacaoDesenhoPai, form.Condicional, form.CondicionalRegra, form.QtdCondicional, form.QtdCondicionalRegra);

                                }
                                break;
                            case "BibliotecaEntidades.Entidades.MaterialClass":


                                IWTTreeNode noPai = destinationNode;
                                InicializarRoteiro((NewProdutoTreeClass) noPai.Conteudo);



                                MaterialClass material = (MaterialClass) tmp.Tag;

                                CadProdutoMaterialFormNew qtdForm = new CadProdutoMaterialFormNew(this.iwtLineDisplay1.Linha, material.ToString(), material.UnidadeMedida.ToString());
                                qtdForm.LocationChanged += (form_LocationChanged);
                                qtdForm.ShowDialog();
                                if (qtdForm.Quantidade != null)
                                {
                                    produtoPai.AdicionarMaterial(
                                        destinationNode,
                                        material,
                                        (double) qtdForm.Quantidade,
                                        qtdForm.PlanoCorte,
                                        qtdForm.PlanoCorteQuantidade,
                                        qtdForm.PlanoCorteInformacoesAdicionais,
                                        qtdForm.PostoTrabalhoCorte,
                                        qtdForm.Dimensao1,
                                        qtdForm.Dimensao1Valor,
                                        qtdForm.Unidade1,
                                        qtdForm.Dimensao2,
                                        qtdForm.Dimensao2Valor,
                                        qtdForm.Unidade2,
                                        qtdForm.Dimensao3,
                                        qtdForm.Dimensao3Valor,
                                        qtdForm.Unidade3, 
                                        qtdForm.Condicional,
                                        qtdForm.CondicionalRegra,
                                        qtdForm.QuantidadeCondicional,
                                        qtdForm.QuantidadeCondicionalRegra);




                                }

                                break;



                            case "BibliotecaEntidades.Entidades.DocumentoTipoFamiliaClass":

                                DocumentoTipoFamiliaClass doc = (DocumentoTipoFamiliaClass) tmp.Tag;
                                produtoPai.AdicionarDocumento(destinationNode, doc);



                                break;

                            case "BibliotecaEntidades.Entidades.RecursoClass":
                                CadProdutoRecursoForm recursoForm = new CadProdutoRecursoForm();
                                recursoForm.LocationChanged += (form_LocationChanged);
                                recursoForm.ShowDialog();
                                if (!recursoForm.abortar)
                                {
                                    RecursoClass recurso = (RecursoClass) tmp.Tag;
                                    produtoPai.AdicionarRecurso(destinationNode, recurso, recursoForm.Secundario);

                                }

                                break;
                            case "BibliotecaEntidades.Entidades.AcabamentoClass":
                                AcabamentoClass acabamento = (AcabamentoClass) tmp.Tag;
                                produtoPai.AdicionarAcabamento(destinationNode, acabamento);



                                break;
                            default:
                                throw new Exception("Tipo inválido para esse campo");
                                break;
                        }

                        this.BuscaProdutoArvore(produtoPai);
                        InicializarArvore();
                    }
                    else
                    {
                        throw new Exception("Só é possível fazer inclusões em itens.");
                    }
                }
                else
                {
                    throw new Exception("É obrigatório indicar o local para incluir o novo item.");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void iwtTreeDisplay1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void iwtTreeDisplay1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void iwtLineDisplay1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                

                this.alterado = true;
                IWTLineNode destinationNode = this.iwtLineDisplay1.buscaNoPosicao(iwtLineDisplay1.PointToClient(new Point(e.X, e.Y)));
                ListViewItem tmp = (ListViewItem)e.Data.GetData("System.Windows.Forms.ListViewItem");
                

                if (destinationNode == null && this.iwtLineDisplay1.Linha.Inicio.Proximo == null)
                {
                    destinationNode = this.iwtLineDisplay1.Linha.Inicio;
                }

                if (destinationNode != null)
                {
                    
                    NewPostoTrabalhoTreeClass postoPai = (NewPostoTrabalhoTreeClass) destinationNode.Conteudo;
                  
                    if (tmp.Tag.GetType().FullName == "BibliotecaEntidades.Entidades.PostoTrabalhoClass")
                    {
                        CadProdutoPostoTrabalhoForm postoForm = new CadProdutoPostoTrabalhoForm();
                        postoForm.LocationChanged += (form_LocationChanged);
                        postoForm.ShowDialog();
                        if (!postoForm.Abortar)
                        {
                            PostoTrabalhoClass posto = (PostoTrabalhoClass) tmp.Tag;

                            if (postoPai == null)
                            {
                                this.produtoSelecionadoAtual.AdcionarPostoTrabalho(posto, postoForm.TempoProducao, postoForm.TempoSetup, 0, noSelecionado);
                                this.BuscaProdutoArvore(this.produtoSelecionadoAtual);
                                this.InicializarRoteiro(this.produtoSelecionadoAtual);
                            }
                            else
                            {
                                postoPai.AdicionarProximo(destinationNode, posto, postoForm.TempoProducao, postoForm.TempoSetup, noSelecionado);
                                this.BuscaProdutoArvore(postoPai.ProdutoPai);
                                this.InicializarRoteiro(postoPai.ProdutoPai);
                            }
                           
                        }
                    }
                    else
                    {
                        throw new Exception("Tipo inválido para esse campo");
                    }
                }
                else
                {
                    throw new Exception("É obrigatório indicar o local para incluir o novo item.");
                }
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void iwtLineDisplay1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void iwtLineDisplay1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void livProdutos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void livMateriais_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void livDocumentos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void livRecursos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void livAcabamentos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void livPostoTrabalho_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.DoDragDrop(e.Item, DragDropEffects.Move);
        }


        private void iwtTreeDisplay1_OnUpdateNeeded(object sender, EventArgs e)
        {
            try
            {
                this.InicializarArvore();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos Busca Tabs de Dados

        private void txtBuscaProd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                timer1.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscaMat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer2.Stop();
                timer2.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscaDocumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timDocumento.Stop();
                timDocumento.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscaRecursos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timRecurso.Stop();
                timRecurso.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscaAcabamento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timAcabamento.Stop();
                timAcabamento.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscaPostoTrabalho_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timPostoTrabalho.Stop();
                timPostoTrabalho.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                this.LoadProdutos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                timer2.Enabled = false;

                this.LoadMateriais();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void timDocumento_Tick(object sender, EventArgs e)
        {
            try
            {
                timDocumento.Enabled = false;
                this.LoadDocumentos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void timRecurso_Tick(object sender, EventArgs e)
        {
            try
            {
                timRecurso.Enabled = false;
                this.LoadRecursos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void timAcabamento_Tick(object sender, EventArgs e)
        {
            try
            {
                timAcabamento.Enabled = false;
                this.LoadAcabamentos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void timPostoTrabalho_Tick(object sender, EventArgs e)
        {
            try
            {
                timPostoTrabalho.Enabled = false;
                this.LoadPostoTrabalho();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        private void grbLegenda_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Black, 15, 18, 10, 10);
            e.Graphics.DrawEllipse(Pens.Black, 15, 18, 10, 10);
            e.Graphics.FillEllipse(Brushes.LightGray, 15, 35, 10, 10);
            e.Graphics.DrawEllipse(Pens.Black, 15, 35, 10, 10);

        }


        #endregion

      
     

    }

    public class LockKeepAliveRunner
    {
        private IWTPostgreNpgsqlConnection connection;
        private const int interval = 20000;
        public bool ToStop { get; internal set; }

        private CadProdutoEstruturaFormNew form;
        private List<ProdutoEstruturaLockClass> _locks;
        private  List<ProdutoEstruturaLockClass> locks
        {
            get
            {
                if (this.form!=null)
                {
                    return this.form.getLocksAtuais();
                }
                else
                {
                    return this._locks;
                }
            }
        }

        public LockKeepAliveRunner(IWTPostgreNpgsqlConnection connection, CadProdutoEstruturaFormNew form)
        {
            this.connection = connection;
            this.form = form;

            ToStop = false;
        }

        public LockKeepAliveRunner(IWTPostgreNpgsqlConnection connection, List<ProdutoEstruturaLockClass> locks)
        {
            this.connection = connection;
            _locks = locks;

            ToStop = false;
        }

        public void Start()
        {
            this.ToStop = false;
            try
            {
                while (!ToStop)
                {
                    NewEstruturaProdutoClass.KeepAliveLock(locks, connection);
                    int segundos = interval/5000;
                    while (!ToStop && segundos > 0)
                    {
                        Thread.Sleep(5000);
                        segundos--;
                    }
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao atualizar os tempos dos locks\r\n" + e.Message, e);
            }
        }


    }
}
