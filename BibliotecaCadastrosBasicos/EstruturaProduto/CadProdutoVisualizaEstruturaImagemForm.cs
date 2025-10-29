#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.NovaEstruturaProduto;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using IWTTreeComponent;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaCadastrosBasicos.EstruturaProduto
{
    public partial class CadProdutoVisualizaEstruturaImagemForm : IWTBaseForm
    {
        private readonly IWTPostgreNpgsqlConnection conn;
        private readonly AcsUsuarioClass Usuario;


        private ProdutoClass Produto;
        public CadProdutoVisualizaEstruturaImagemForm(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.Usuario = Usuario;

            this.ensProduto.FormSelecao = new CadProdutoListForm(TipoForm.Expedicao, modoSelecao: true, somenteAtivos: true);
            this.ensProduto.forceDisable();



#if DEBUG
            this.txtBarcode.DebugMode = true;
#endif
        }



        private void CarregaItem(string barcode)
        {
            try
            {
                if (string.IsNullOrEmpty(barcode.Trim()))
                {
                    LimparTela();
                    return;
                }


                //Identifica o tipo de código de barras
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;
                barcode = barcode.Trim().Replace("\r", "").Replace("\n", "").Replace('}', '|');
                int idProduto;

                //Etiqueta de Identificação Genérica
                if (barcode.StartsWith("EI"))
                {
                    string idProdutoTmp = barcode.Substring(2);
                    idProduto = Convert.ToInt32(idProdutoTmp);
                }
                else
                {


                    //Etiqueta de KB
                    //Etiqueta de Item Customizado
                    //ICN -> Item Interno Customizado: IC|ID_ORDER_NUMBER_ETIQUETA_PAI|ID Código de Barras|numero do item sequencial
                    //IK -> Item Interno Kanban: IK|ID Código de Barras
                    //IK -> Item Interno Kanban: IK|ID Código de Barras|Número Sequencial

                    if (barcode.StartsWith("ICN") || barcode.StartsWith("IK"))
                    {
                        string[] item = barcode.Replace("-", " ").Split(new[] {'|'},
                            StringSplitOptions.RemoveEmptyEntries);

                        switch (item[0])
                        {
                            case "IK":
                                if (item.Length == 2 || item.Length == 3)
                                {
                                    //Buscar Código de Barras
                                    command.CommandText =
                                        "SELECT  " +
                                        "  public.produto.id_produto " +
                                        "FROM " +
                                        "  public.produto " +
                                        "  INNER JOIN public.codigo_barra ON (public.produto.pro_codigo = public.codigo_barra.cob_codigo_item) " +
                                        "WHERE " +
                                        "  public.codigo_barra.id_codigo_barra = :id_codigo_barra ";
                                    command.Parameters.Clear();

                                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_codigo_barra", NpgsqlDbType.Integer));
                                    command.Parameters[command.Parameters.Count - 1].Value = item[1];


                                    read = command.ExecuteReader();
                                    if (read.HasRows)
                                    {
                                        read.Read();
                                        idProduto = (int) read["id_produto"];
                                        read.Close();
                                    }
                                    else
                                    {
                                        read.Close();
                                        throw new Exception(
                                            "Código de identificação da etiqueta inválido. Não encontrado.");
                                    }

                                }
                                else
                                {

                                    throw new Exception("Quantidade de campos inválida para etiqueta do tipo IK");

                                }

                                break;
                            case "ICN":
                                if (item.Length == 4)
                                {


                                    //Buscar Código de Barras
                                    command.CommandText =
                                        "SELECT  " +
                                        "  public.produto.id_produto " +
                                        "FROM " +
                                        "  public.produto " +
                                        "  INNER JOIN public.codigo_barra ON (public.produto.pro_codigo = public.codigo_barra.cob_codigo_item) " +
                                        "WHERE " +
                                        "  public.codigo_barra.id_codigo_barra = :id_codigo_barra ";
                                    command.Parameters.Clear();

                                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_codigo_barra", NpgsqlDbType.Integer));
                                    command.Parameters[command.Parameters.Count - 1].Value = item[2];


                                    read = command.ExecuteReader();
                                    if (read.HasRows)
                                    {
                                        read.Read();
                                        idProduto = (int) read["id_produto"];
                                        read.Close();
                                    }
                                    else
                                    {
                                        read.Close();
                                        throw new Exception(
                                            "Código de identificação da etiqueta inválido. Não encontrado.");
                                    }

                                }
                                else
                                {
                                    throw new Exception("Quantidade de campos inválida para etiqueta do tipo IC");
                                }

                                break;

                            default:
                                throw new Exception("Código de identificação da etiqueta inválido");
                        }
                    }
                    else
                    {
                        if (barcode.StartsWith("OIE"))
                        {

                            command.CommandText =
                                "SELECT  " +
                                "  public.order_item_etiqueta.id_produto " +
                                "FROM " +
                                "  public.order_item_etiqueta " +
                                "WHERE " +
                                "  public.order_item_etiqueta.id_order_item_etiqueta = :id_order_item_etiqueta ";

                            command.Parameters.Clear();

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = barcode.Substring(4);

                            object retorno = command.ExecuteScalar();
                            if (retorno == null || retorno == DBNull.Value)
                            {
                                throw new ExcecaoTratada("Não foi encontrado nenhum pedido para esse código de barras");
                            }

                            idProduto = (int) retorno;
                        }
                        else
                        {
                            if (barcode.StartsWith("OP"))
                            {
                                command.CommandText =
                                    "SELECT  " +
                                    "  public.ordem_producao.id_produto " +
                                    "FROM " +
                                    "  public.ordem_producao " +
                                    "WHERE " +
                                    "  public.ordem_producao.id_ordem_producao = :id_ordem_producao ";

                                command.Parameters.Clear();

                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                                command.Parameters[command.Parameters.Count - 1].Value = barcode.Substring(3);

                                object retorno = command.ExecuteScalar();
                                if (retorno == null || retorno == DBNull.Value)
                                {
                                    throw new ExcecaoTratada("Não foi encontrado nenhuma OP para esse código de barras");
                                }

                                idProduto = (int) retorno;
                            }
                            else
                            {
                                //Etiqueta de Identificação Somente código do produto do cliente ou interno
                                command.CommandText =
                                    "SELECT  " +
                                    "  public.produto.id_produto " +
                                    "FROM " +
                                    "  public.produto " +
                                    "WHERE " +
                                    "  public.produto.pro_codigo = :pro_codigo OR " +
                                    "  public.produto.pro_codigo_cliente = :pro_codigo ";

                                command.Parameters.Clear();

                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pro_codigo", NpgsqlDbType.Varchar));
                                command.Parameters[command.Parameters.Count - 1].Value = barcode;

                                read = command.ExecuteReader();
                                if (read.HasRows)
                                {
                                    read.Read();
                                    idProduto = Convert.ToInt32(read["id_produto"]);
                                    read.Close();
                                }
                                else
                                {
                                    read.Close();
                                    command.CommandText =
                                        "SELECT  " +
                                        "  public.produto.id_produto " +
                                        "FROM " +
                                        "  public.produto " +
                                        "WHERE " +
                                        "  public.produto.pro_gtin = :pro_codigo ";

                                    read = command.ExecuteReader();
                                    if (read.HasRows)
                                    {
                                        read.Read();
                                        idProduto = Convert.ToInt32(read["id_produto"]);
                                        read.Close();
                                    }
                                    else
                                    {
                                        read.Close();
                                        throw new ExcecaoTratada("Produto não encontrado no cadastro.");
                                    }

                                }
                            }
                        }

                    }
                }

                ProdutoClass produto = ProdutoBaseClass.GetEntidade(idProduto, this.Usuario, this.conn);


                CarregaProduto(produto);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o item\r\n" + e.Message, e);
            }
            finally
            {
                this.txtBarcode.Clear();
            }

        }


        private void CarregaProduto(ProdutoClass produto)
        {
            if (produto == null)
            {
                LimparTela();
                return;
            }

            Produto = produto;

            if (produto.Imagem != null)
            {
                MemoryStream ms = new MemoryStream(produto.Imagem);
                this.pcbImagem.Image = Image.FromStream(ms);
            }
            else
            {
                this.pcbImagem.Image = null;
            }

            NewProdutoTreeClass inicioArvore = new NewProdutoTreeClass(produto);
            this.iwtTreeDisplay1.Arvore = inicioArvore.getArvore();
            this.iwtTreeDisplay1.Invalidate();

            this.Text = "Visualizar Estrura e Imagem do Produto: "+produto.ToString();
        }

        private void LimparTela()
        {
            this.pcbImagem.Image = null;
            this.iwtTreeDisplay1.Arvore = null;
            this.iwtTreeDisplay1.Invalidate();

            this.Text = "Visualizar Estrura e Imagem do Produto";

            Produto = null;
        }



        private void Historico()
        {
            if (this.Produto!=null && this.Produto.ID != -1)
            {
                EstruturaProdutoReportFormNew form = new EstruturaProdutoReportFormNew(this.Produto);
                form.LocationChanged += (form_LocationChanged);
                form.ShowDialog(this);

                this.Produto.VersaoEstruturaCarregada = Produto.VersaoEstruturaAtual;
            }
        }

        private void AbrirNoArvore(Point location)
        {
            try
            {
                IWTTreeNode no = this.iwtTreeDisplay1.buscaNoPosicao(location);
                if (no != null)
                {
                    this.AbrirEntidade((AbstractEntity) no.Conteudo.getEntidadeOrigem());
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
                    VerificaUtilizacao = TipoModulo.Tipo != TipoForm.Gerencial
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
                    VerificaUtilizacao = TipoModulo.Tipo != TipoForm.Gerencial,
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


        private void txtBarcode_OperacaoBarcodeEncerrada(object sender, string valor)
        {
            try
            {
                this.CarregaItem(valor);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void iwtTreeDisplay1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.AbrirNoArvore(e.Location);
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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



        private void rdbBarcode_CheckedChanged(object sender, EventArgs e)
        {
            this.txtBarcode.Enabled = this.rdbBarcode.Checked;
            if (rdbProduto.Checked)
            {
                this.ensProduto.removeForceDisable();
            }
            else
            {
                this.ensProduto.forceDisable();
            }
        }


        private void ensProduto_EntityChange(object sender, EventArgs e)
        {
            try {
                this.CarregaProduto((ProdutoClass) ensProduto.EntidadeSelecionada);
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


     
        private void btnHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                Historico();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
