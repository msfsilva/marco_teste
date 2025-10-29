#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaCadastrosBasicos.Estoque;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaProdutos;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;
using MaterialClass = BibliotecaEntidades.Entidades.MaterialClass;

#endregion

namespace BibliotecaCompras
{
    public partial class LoteClienteForm : IWTBaseForm
    {
        IWTPostgreNpgsqlConnection conn;
        LoteClass loteSelecionado;
        TipoForm Tipo;
        AcsUsuarioClass Usuario;

        string internalLabelPrinter; 
        string internalLabelPaper;
        private int? _id;

        protected MaterialClass MaterialSelecionado
        {
            get { return (MaterialClass)(this.ensMaterial.Enabled ? this.ensMaterial.EntidadeSelecionada : null); }
        }

        protected ProdutoClass ProdutoSelecionado
        {
            get { return (ProdutoClass)(this.ensProduto.Enabled ? this.ensProduto.EntidadeSelecionada : null); }
        }


        public LoteClienteForm(IWTPostgreNpgsqlConnection conn, int? id, string internalLabelPrinter, string internalLabelPaper, TipoForm Tipo, AcsUsuarioClass Usuario)
        {
            this.initForm(conn, id,internalLabelPrinter,internalLabelPaper, false, Tipo, Usuario);
        }

        public LoteClienteForm(IWTPostgreNpgsqlConnection conn, int? id, string internalLabelPrinter, string internalLabelPaper, bool somenteVisualizacao, TipoForm Tipo, AcsUsuarioClass Usuario)
        {
            this.initForm(conn, id, internalLabelPrinter, internalLabelPaper, somenteVisualizacao, Tipo, Usuario);
        }


        private void initForm(IWTPostgreNpgsqlConnection conn, int? id, string internalLabelPrinter, string internalLabelPaper, bool somenteVisualizacao, TipoForm Tipo, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            this.conn = conn;
            
            this.Tipo = Tipo;
            this.Usuario = Usuario;
            this.internalLabelPaper = internalLabelPaper;
            this.internalLabelPrinter = internalLabelPrinter;
           
            this.initializeComboEmissorCertificado();
            this.ensCliente.FormSelecao = new CadClienteListForm(Tipo);
            //this.initializeComboMaterial();
            //this.initializeComboProduto();
            this.initializeComboUnidade();


            this.ensMaterial.FormSelecao = new CadMaterialListForm(this.Tipo);
            this.ensProduto.FormSelecao = new CadProdutoListForm(this.Tipo, somenteAtivos: true);


            if (id != null)
            {
                _id = id.Value;
                this.loadEdit(id.Value);
            }
            else
            {
                this.loteSelecionado = new LoteClass(null, this.Usuario, this.conn);
            }

            if (somenteVisualizacao)
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }
            }

            if (_id.HasValue)
            {
                btnSalvar.Enabled = false;
                btnSalvar.Visible = false;
            }
        }


        private void initializeComboUnidade()
        {
            try
            {
                string sql =
                    "SELECT  " +
                    "  public.unidade_medida.id_unidade_medida, " +
                    "  public.unidade_medida.unm_abreviada, " +
                    "  public.unidade_medida.unm_nome_unidade, " +
                    "  public.unidade_medida.unm_obs " +
                    "FROM " +
                    "  public.unidade_medida " +
                    "ORDER BY " +
                    "  public.unidade_medida.unm_abreviada ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbUnidade.DataSource = binding;
                    this.cmbUnidade.ValueMember = "unm_abreviada";
                    this.cmbUnidade.DisplayMember = "unm_abreviada";
                    this.cmbUnidade.autoSize = true;
                    this.cmbUnidade.Table = ds.Tables[0];
                    this.cmbUnidade.ColumnsToDisplay = new string[] { "unm_abreviada", "unm_nome_unidade", "unm_obs" };
                    this.cmbUnidade.HeadersToDisplay = new string[] { "Unidade", "Nome", "Obs." };


                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da Unidade.\r\n" + e.Message);
            }
        }

        private void initializeComboEmissorCertificado()
        {
            try
            {


                string sql =
                        "SELECT  " +
                        "  id_emissor_certificado, " +
                        "  emc_identificacao " +
                        "FROM  " +
                        "  public.emissor_certificado " +
                        "ORDER BY emc_identificacao";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbEntidadeCertificadora.DataSource = binding;
                    this.cmbEntidadeCertificadora.ValueMember = "id_emissor_certificado";
                    this.cmbEntidadeCertificadora.DisplayMember = "emc_identificacao";


                }
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }
        }

       

        private void loadEdit(int id)
        {
            try
            {
                this.loteSelecionado = new LoteClass(id, this.Usuario, this.conn);

                if (this.loteSelecionado.Cliente == null)
                {
                    throw new Exception("Não é possível editar um lote que não seja de cliente.");
                }

                this.ensCliente.EntidadeSelecionada = this.loteSelecionado.Cliente;
                if (this.loteSelecionado.getIdMaterial().HasValue)
                {
                    this.rdbMaterial.Checked = true;
                    this.ensMaterial.EntidadeSelecionada = MaterialBaseClass.GetEntidade(this.loteSelecionado.getIdMaterial().Value, this.Usuario, this.conn);
                }
                else
                {
                    this.rdbProduto.Checked = true;
                    this.ensProduto.EntidadeSelecionada = ProdutoBaseClass.GetEntidade(this.loteSelecionado.getIdProduto().Value, this.Usuario,
                                                               this.conn);
                    

                }

                this.nudQuantidade.Value = Convert.ToDecimal(this.loteSelecionado.qtdUnidadeUso);
                this.nudValorUnitario.Value = Convert.ToDecimal(this.loteSelecionado.valorUnitario);

                if (this.loteSelecionado.getDataFabricacao() != null)
                {
                    this.chkFabricacao.Checked = true;
                    this.dtpFabricacao.Value = this.loteSelecionado.getDataFabricacao().Value;
                }
                else
                {
                    this.chkFabricacao.Checked = false;
                }

                if (this.loteSelecionado.getDataEmbalagem() != null)
                {
                    this.chkEmbalagem.Checked = true;
                    this.dtpEmbalagem.Value = this.loteSelecionado.getDataEmbalagem().Value;
                }
                else
                {
                    this.chkEmbalagem.Checked = false;
                }

                if (this.loteSelecionado.getDataValidade() != null)
                {
                    this.chkValidade.Checked = true;
                    this.dtpValidade.Value = this.loteSelecionado.getDataValidade().Value;
                }
                else
                {
                    this.chkValidade.Checked = false;
                }


                if (this.loteSelecionado.getIdEmissorCertificado() != null)
                {
                    this.chkEntidadeCertificadora.Checked = true;
                    this.cmbEntidadeCertificadora.SelectedValue = this.loteSelecionado.getIdEmissorCertificado();
                }
                else
                {
                    this.chkEntidadeCertificadora.Checked = false;
                }

                this.txtNumeroLote.Text = this.loteSelecionado.Numero;
                this.txtCertificado.Text = this.loteSelecionado.Certificado;
                this.txtNumeroLote.Text = this.loteSelecionado.Numero;
                this.txtObs.Text = this.loteSelecionado.Observacoes;


                this.dtpDataEmissao.Value = this.loteSelecionado.nfData;
                this.txtSerie.Text = this.loteSelecionado.nfSerie;
                this.nudNumeroNota.Value = Convert.ToDecimal(this.loteSelecionado.nfNumero);

                this.txtCodigoCliente.Text = this.loteSelecionado.codigoItemFornecedorCliente;
                this.txtDescricaoCliente.Text = this.loteSelecionado.descricaoItemFornecedorCliente;
                this.txtNCMCliente.Text = this.loteSelecionado.ncmItemFornecedorCliente;
                this.txtBenefFiscalCliente.Text = this.loteSelecionado.beneficioFiscalFornecedorCliente;
                this.cmbUnidade.SelectedValue = this.loteSelecionado.unidadeItemFornecedorCliente;


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para edição.\r\n" + e.Message);
            }
        }

        private void Salvar()
        {
            if (_id.HasValue)
            {
                return;
            }

            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                this.validateRequiredFields();

                this.loteSelecionado.setFornecedorCliente(
                    null,
                    (ClienteClass) this.ensCliente.EntidadeSelecionada
                    );

                long? idMaterial = null, idProduto = null;
                string desc = "";
                string codigo = "";
                double unidadePorUnidadeCompra = 1;

                if (this.rdbMaterial.Checked)
                {
                    idMaterial = this.ensMaterial.EntidadeSelecionada.ID;
                    unidadePorUnidadeCompra = this.MaterialSelecionado.UnidadesPorUnCompra;
                    codigo = this.MaterialSelecionado.ToString();
                    desc = this.MaterialSelecionado.Descricao;
                }
                else
                {
                    idProduto = this.ProdutoSelecionado.ID;
                    unidadePorUnidadeCompra = this.ProdutoSelecionado.UnidadesPorUnCompra;
                    codigo = this.ProdutoSelecionado.Codigo;
                    desc = this.ProdutoSelecionado.Descricao;
                }


                this.loteSelecionado.setMaterialProduto(
                    this.MaterialSelecionado,
                    this.ProdutoSelecionado,
                    null,
                    codigo,
                    this.txtCodigoCliente.Text.Trim(),
                    this.txtDescricaoCliente.Text.Trim(),
                    this.txtNCMCliente.Text.Trim(),
                    txtBenefFiscalCliente.Text.Trim(),
                    this.cmbUnidade.SelectedValue.ToString(),
                    Convert.ToDouble(this.nudValorUnitario.Value)
                    );
                this.loteSelecionado.setQuantidade(Convert.ToDouble(this.nudQuantidade.Value), Convert.ToDouble(this.nudQuantidade.Value) / unidadePorUnidadeCompra, unidadePorUnidadeCompra);


                this.loteSelecionado.setNf(this.dtpDataEmissao.Value, this.txtSerie.Text.Trim(), this.nudNumeroNota.Value.ToString());

                //Busca Gaveta Estoque
                List<EstoqueGavetaClass> gavetas;
                if (this.loteSelecionado.getIdMaterial()!=null)
                {
                    gavetas = EstoqueMovimentacao.BuscaTodasGavetasMaterial(this.loteSelecionado.Material, false);
                }
                else
                {
                    gavetas = EstoqueMovimentacao.BuscaTodasGavetasProduto(this.loteSelecionado.Produto, false);
                }

                if (gavetas.Count == 0)
                {
                    gavetas = this.itemSemEstoque(MaterialSelecionado, ProdutoSelecionado, ref command);
                }


                this.loteSelecionado.setGavetasEstoque(gavetas);


                if (this.dtpEmbalagem.Enabled)
                {
                    this.loteSelecionado.setDataEmbalagem(this.dtpEmbalagem.Value);
                }
                else
                {
                    this.loteSelecionado.setDataEmbalagem(null);
                }


                if (this.dtpFabricacao.Enabled)
                {
                    this.loteSelecionado.setDataFabricacao(this.dtpFabricacao.Value);
                }
                else
                {
                    this.loteSelecionado.setDataFabricacao(null);
                }


                if (this.dtpValidade.Enabled)
                {
                    this.loteSelecionado.setDataValidade(this.dtpValidade.Value);
                }
                else
                {
                    this.loteSelecionado.setDataValidade(null);
                }


                if (this.cmbEntidadeCertificadora.Enabled && this.cmbEntidadeCertificadora.SelectedValue != null)
                {
                    this.loteSelecionado.setEmissorCertificado(Convert.ToInt32(this.cmbEntidadeCertificadora.SelectedValue), "");

                }

                this.loteSelecionado.Numero = this.txtNumeroLote.Text.Trim();
                this.loteSelecionado.Observacoes = this.txtObs.Text.Trim();
                this.loteSelecionado.Certificado = this.txtCertificado.Text.Trim();
                this.loteSelecionado.qtdEtiquetas = Convert.ToInt32(this.nudQtdEtiquetasLote.Value);



               

                this.loteSelecionado.Salvar(ref command);

                if (this.loteSelecionado.qtdEtiquetas > 0)
                {
                    List<LoteClass> lotesEtiqueta = new List<LoteClass>();
                    lotesEtiqueta.Add(this.loteSelecionado);

                    LoteEtiquetaReportForm form2 = new LoteEtiquetaReportForm(lotesEtiqueta, this.internalLabelPrinter, this.internalLabelPaper);
                    form2.ShowDialog();
                }

                command.Transaction.Commit();

                MessageBox.Show(this, "Lote salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.Close();
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao salvar.\r\n" + e.Message);
            }
        }



        private void validateRequiredFields()
        {
            try
            {
                if (this.ensCliente.EntidadeSelecionada == null)
                {
                    throw new Exception("Campo de Cliente é obrigatório.");
                }

                if (this.rdbMaterial.Checked && this.MaterialSelecionado == null)
                {
                    throw new Exception("Selecione o Material");
                }

                if (this.rdbProduto.Checked && this.ProdutoSelecionado == null)
                {
                    throw new Exception("Selecione o Produto");
                }

                if (this.txtCodigoCliente.Text.Length == 0)
                {
                    throw new Exception("Campo de código do item do cliente é obrigatório.");
                }

                if (this.txtDescricaoCliente.Text.Length == 0)
                {
                    throw new Exception("Campo de descrição do item do cliente é obrigatório.");
                }

                if (this.txtNCMCliente.Text.Length == 0)
                {
                    throw new Exception("Campo de NCM do item do cliente é obrigatório.");
                }

                if (this.cmbUnidade.Enabled && this.cmbUnidade.SelectedValue == null)
                {
                    throw new Exception("Campo de Unidade do item do cliente é obrigatório.");
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }



        private List<EstoqueGavetaClass> itemSemEstoque(MaterialClass material, ProdutoClass produto, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                MessageBox.Show(this, "Esse item não possui nenhuma localização de estoque selecionada. Você deverá escolher uma agora.", "Item sem localização de estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnviaItemEstoqueForm form;
                if (material != null)
                {
                    form = new EnviaItemEstoqueForm(
                        EnviaItemEstoqueForm.tipoUtilizacao.Material,
                        this.MaterialSelecionado.ToString(),
                        false,
                        0,
                        this.MaterialSelecionado.UnidadeMedida.Abreviada,
                        false,
                        "Criação da Gaveta",
                        material,
                        false,
                        null,
                        this.Usuario,
                        this.conn,
                        ref command,
                        "Lote do Cliente");
                }
                else
                {
                    form = new EnviaItemEstoqueForm(
                        EnviaItemEstoqueForm.tipoUtilizacao.Produto,
                        this.ProdutoSelecionado.Codigo,
                        false,
                        0,
                        this.ProdutoSelecionado.UnidadeMedida.ToString(),
                        false,
                        "Criação da Gaveta",
                        produto,
                        false,
                        null,
                        this.Usuario,
                        this.conn,
                        ref command,
                        "Lote do Cliente");
                }

                form.ShowDialog();

                if (material != null)
                {
                    return EstoqueMovimentacao.BuscaTodasGavetasMaterial(material, false, command);
                }
                else
                {
                    return EstoqueMovimentacao.BuscaTodasGavetasProduto(produto, false, command);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar um novo estoque para o item.\r\n" + e.Message, e);
            }
        }

      

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
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkFabricacao_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpFabricacao.Enabled = this.chkFabricacao.Checked;
        }

        private void chkEmbalagem_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpEmbalagem.Enabled = this.chkEmbalagem.Checked;
        }

        private void chkValidade_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpValidade.Enabled = this.chkValidade.Checked;
        }

        private void chkEntidadeCertificadora_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbEntidadeCertificadora.Enabled = chkEntidadeCertificadora.Checked;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
          

            this.ensProduto.Enabled = this.rdbProduto.Checked;
            this.ensMaterial.Enabled = this.rdbMaterial.Checked;
            
        }

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {

            this.ensProduto.Enabled = this.rdbProduto.Checked;
            this.ensMaterial.Enabled = this.rdbMaterial.Checked;
        }

        #endregion



    }
}
