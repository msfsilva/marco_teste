#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaProdutos;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTNF.Entidades.Base;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

#endregion

namespace BibliotecaFiscal
{
    public partial class CadProdutoFiscalForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        ProdutoClass produto;
        readonly AcsUsuarioClass Usuario;
        readonly int id;
        bool loading = true;
        string idICMS="";
        public CadProdutoFiscalForm(IWTPostgreNpgsqlConnection conn, int id, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
            this.Usuario = Usuario;
            this.gbxICMS.Enabled = false;
            this.rdbModeloICMS.Checked = true;
            this.gbxPIS.Enabled = false;
            this.gbxCOFINS.Enabled = false;
            this.cbxSobrescreverPIS.Checked = false;
            this.cbxSobrescreverCOFINS.Checked = false;

            ensNCM.FormSelecao = new CadNcmListForm(TipoModulo.Tipo);

            this.loadCombos();
            this.loadToolTips();
            this.loadEdit();
            
        }

        private void loadToolTips()
        {
            toolTip1.SetToolTip(txtExtipi, "Preencher de acordo com código EX da TIPI. Em caso de serviço não preencher.");
            toolTip3.SetToolTip(nudGenero, "Gênero do produto ou serviço. Preencher de acordo com a tabela de capítulos da NCM");
        }

        private void loadCombos()
        {
            try
            {
                string sql = "SELECT id_modelo_fiscal_icms, mfi_nome FROM public.modelo_fiscal_icms ORDER BY mfi_nome;";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbModeloICMS.ValueMember = "id_modelo_fiscal_icms";
                    this.cmbModeloICMS.DisplayMember = "mfi_nome";
                    this.cmbModeloICMS.DataSource = binding;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados dos combos.\r\n" + e.Message);
            }

            List<LoadClass> loadOrigem = new List<LoadClass>();
            loadOrigem.Add(new LoadClass("0", "Nacional"));
            loadOrigem.Add(new LoadClass("1", "Estrangeira - Importação Direta"));
            loadOrigem.Add(new LoadClass("2", "Estrangeira - Adquirida no mercado interno"));

            cmbOrigem.ValueMember = "id";
            cmbOrigem.DisplayMember = "descricao";
            cmbOrigem.DataSource = loadOrigem;


            List<LoadClass> loadCST_ICMS = new List<LoadClass>();
            loadCST_ICMS.Add(new LoadClass("00", "00  - Tributado Integralmente"));
            loadCST_ICMS.Add(new LoadClass("10", "10  - Tributado com cobrança do ICMS por ST"));
            loadCST_ICMS.Add(new LoadClass("10a", "10a - Tributado com cobrança do ICMS por ST (Partilha do ICMS entre UF origem e Destino)"));
            loadCST_ICMS.Add(new LoadClass("20", "20  - Com redução da base de cálculo"));
            loadCST_ICMS.Add(new LoadClass("30", "30  - Isenta ou não tributada e com cobrança do ICMS por ST"));
            loadCST_ICMS.Add(new LoadClass("40", "40  - Isenta"));
            loadCST_ICMS.Add(new LoadClass("41", "41  - Não tributada"));
            loadCST_ICMS.Add(new LoadClass("41a", "41a - Não tributada (ICMSST devido para a UF de destino, nas operações interestaduais de produtos que tiveram retenção antecipada de ICMS por ST na UF do remetente)"));
            loadCST_ICMS.Add(new LoadClass("50", "50  - Suspensão"));
            loadCST_ICMS.Add(new LoadClass("51", "51  - Diferimento"));
            loadCST_ICMS.Add(new LoadClass("60", "60  - Cobrado Anteriormente por ST"));
            loadCST_ICMS.Add(new LoadClass("70", "70  - Com redução da BC e cobrança do ICMS por ST     "));
            loadCST_ICMS.Add(new LoadClass("90", "90  - Outras"));
            loadCST_ICMS.Add(new LoadClass("90a", "90a - Outras (Partilha do ICMS entre UF origem e Destino)"));
            loadCST_ICMS.Add(new LoadClass("90b", "90b  - Outras - Diferimento Parcial"));
            loadCST_ICMS.Add(new LoadClass("101", "101 - Simples Nacional - Tributada com Permissão de Crédito"));
            loadCST_ICMS.Add(new LoadClass("102", "102 - Simples Nacional - Tributada sem Permissão de Crédito"));
            loadCST_ICMS.Add(new LoadClass("103", "103 - Simples Nacional - Isenção do ICMS para faixa de Receita Bruta"));
            loadCST_ICMS.Add(new LoadClass("201", "201 - Simples Nacional - Tributada com Permissão de Crédito e com cobrança de ICMS por ST"));
            loadCST_ICMS.Add(new LoadClass("202", "202 - Simples Nacional - Tributada sen Permissão de Crédito e com cobrança de ICMS por ST"));
            loadCST_ICMS.Add(new LoadClass("203", "203 - Simples Nacional - Isenção do ICMS para faixa de Receita Bruta e com cobrança de ICMS por ST"));
            loadCST_ICMS.Add(new LoadClass("300", "300 - Simples Nacional - Imune"));
            loadCST_ICMS.Add(new LoadClass("400", "400 - Simples Nacional - Não tributado"));
            loadCST_ICMS.Add(new LoadClass("500", "500 - Simples Nacional - ICMS cobrado anteriormente por ST ou por antecipação"));
            loadCST_ICMS.Add(new LoadClass("900", "900 - Simples Nacional - Outros"));

            cmbCST_ICMS.ValueMember = "id";
            cmbCST_ICMS.DisplayMember = "descricao";
            cmbCST_ICMS.DataSource = loadCST_ICMS;

            List<LoadClass> loadCST_PIS = new List<LoadClass>();
            loadCST_PIS.Add(new LoadClass("01", "(01)Operação Tributável(BC = valor da operação normal)"));
            loadCST_PIS.Add(new LoadClass("02", "(02)Operação Tributável(BC = valor da operação(alíquota diferenciada))"));
            loadCST_PIS.Add(new LoadClass("03", "(03)Operação Tributável(BC = quantidade vendida x aliquota por unidade de produto)"));
            loadCST_PIS.Add(new LoadClass("04", "(04)Operação Tributável(Tributação monofásica(alíquota zero))"));
            loadCST_PIS.Add(new LoadClass("06", "(06)Operação Tributável(Alíquota zero)"));
            loadCST_PIS.Add(new LoadClass("07", "(07)Operação Isenta da Contribuição"));
            loadCST_PIS.Add(new LoadClass("08", "(08)Operação Sem Incidência da Contribuição"));
            loadCST_PIS.Add(new LoadClass("09", "(09)Operação com Suspensão da Contribuição"));
            loadCST_PIS.Add(new LoadClass("49", "(49)Outras Operações de Saída"));
            loadCST_PIS.Add(new LoadClass("50", "(50)Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
            loadCST_PIS.Add(new LoadClass("51", "(51)Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno"));
            loadCST_PIS.Add(new LoadClass("52", "(52)Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação"));
            loadCST_PIS.Add(new LoadClass("53", "(53)Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
            loadCST_PIS.Add(new LoadClass("54", "(54)Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
            loadCST_PIS.Add(new LoadClass("55", "(55)Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
            loadCST_PIS.Add(new LoadClass("56", "(56)Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação"));
            loadCST_PIS.Add(new LoadClass("60", "(60)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
            loadCST_PIS.Add(new LoadClass("61", "(61)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno"));
            loadCST_PIS.Add(new LoadClass("62", "(62)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação"));
            loadCST_PIS.Add(new LoadClass("63", "(63)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
            loadCST_PIS.Add(new LoadClass("64", "(64)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
            loadCST_PIS.Add(new LoadClass("65", "(65)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
            loadCST_PIS.Add(new LoadClass("66", "(66)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação"));
            loadCST_PIS.Add(new LoadClass("67", "(67)Crédito Presumido - Outras Operações"));
            loadCST_PIS.Add(new LoadClass("70", "(70)Operação de Aquisição sem Direito a Crédito"));
            loadCST_PIS.Add(new LoadClass("71", "(71)Operação de Aquisição com Isenção"));
            loadCST_PIS.Add(new LoadClass("72", "(72)Operação de Aquisição com Suspensão"));
            loadCST_PIS.Add(new LoadClass("73", "(73)Operação de Aquisição a Alíquota Zero"));
            loadCST_PIS.Add(new LoadClass("74", "(74)Operação de Aquisição; sem Incidência da Contribuição"));
            loadCST_PIS.Add(new LoadClass("75", "(75)Operação de Aquisição por Substituição Tributária"));
            loadCST_PIS.Add(new LoadClass("98", "(98)Outras Operações de Entrada"));
            loadCST_PIS.Add(new LoadClass("99", "(99)Outras Operações"));

            cmbCSTPis.ValueMember = "id";
            cmbCSTPis.DisplayMember = "descricao";
            cmbCSTPis.DataSource = loadCST_PIS;

            List<LoadClass> loadCST_COFINS = new List<LoadClass>();
            loadCST_COFINS.Add(new LoadClass("01", "(01)Operação Tributável(BC = valor da operação normal)"));
            loadCST_COFINS.Add(new LoadClass("02", "(02)Operação Tributável(BC = valor da operação(alíquota diferenciada))"));
            loadCST_COFINS.Add(new LoadClass("03", "(03)Operação Tributável(BC = quantidade vendida x aliquota por unidade de produto)"));
            loadCST_COFINS.Add(new LoadClass("04", "(04)Operação Tributável(Tributação monofásica(alíquota zero))"));
            loadCST_COFINS.Add(new LoadClass("06", "(06)Operação Tributável(Alíquota zero)"));
            loadCST_COFINS.Add(new LoadClass("07", "(07)Operação Isenta da Contribuição"));
            loadCST_COFINS.Add(new LoadClass("08", "(08)Operação Sem Incidência da Contribuição"));
            loadCST_COFINS.Add(new LoadClass("09", "(09)Operação com Suspensão da Contribuição"));
            loadCST_COFINS.Add(new LoadClass("49", "(49)Outras Operações de Saída"));
            loadCST_COFINS.Add(new LoadClass("50", "(50)Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
            loadCST_COFINS.Add(new LoadClass("51", "(51)Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno"));
            loadCST_COFINS.Add(new LoadClass("52", "(52)Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação"));
            loadCST_COFINS.Add(new LoadClass("53", "(53)Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
            loadCST_COFINS.Add(new LoadClass("54", "(54)Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
            loadCST_COFINS.Add(new LoadClass("55", "(55)Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
            loadCST_COFINS.Add(new LoadClass("56", "(56)Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação"));
            loadCST_COFINS.Add(new LoadClass("60", "(60)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
            loadCST_COFINS.Add(new LoadClass("61", "(61)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno"));
            loadCST_COFINS.Add(new LoadClass("62", "(62)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação"));
            loadCST_COFINS.Add(new LoadClass("63", "(63)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
            loadCST_COFINS.Add(new LoadClass("64", "(64)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
            loadCST_COFINS.Add(new LoadClass("65", "(65)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
            loadCST_COFINS.Add(new LoadClass("66", "(66)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação"));
            loadCST_COFINS.Add(new LoadClass("67", "(67)Crédito Presumido - Outras Operações"));
            loadCST_COFINS.Add(new LoadClass("70", "(70)Operação de Aquisição sem Direito a Crédito"));
            loadCST_COFINS.Add(new LoadClass("71", "(71)Operação de Aquisição com Isenção"));
            loadCST_COFINS.Add(new LoadClass("72", "(72)Operação de Aquisição com Suspensão"));
            loadCST_COFINS.Add(new LoadClass("73", "(73)Operação de Aquisição a Alíquota Zero"));
            loadCST_COFINS.Add(new LoadClass("74", "(74)Operação de Aquisição; sem Incidência da Contribuição"));
            loadCST_COFINS.Add(new LoadClass("75", "(75)Operação de Aquisição por Substituição Tributária"));
            loadCST_COFINS.Add(new LoadClass("98", "(98)Outras Operações de Entrada"));
            loadCST_COFINS.Add(new LoadClass("99", "(99)Outras Operações"));
                  
            cmbCSTCofins.ValueMember = "id";
            cmbCSTCofins.DisplayMember = "descricao";
            cmbCSTCofins.DataSource = loadCST_COFINS;


            List<LoadClass> loadModDetBC = new List<LoadClass>();
            loadModDetBC.Add(new LoadClass("0", "Margem Valor Agregado (%)"));
            loadModDetBC.Add(new LoadClass("1", "Pauta (Valor)"));
            loadModDetBC.Add(new LoadClass("2", "Preço Tabelado Max. (valor)"));
            loadModDetBC.Add(new LoadClass("3", "Valor da Operação"));

            cmbModalidadeDetBC.ValueMember = "id";
            cmbModalidadeDetBC.DisplayMember = "descricao";
            cmbModalidadeDetBC.DataSource = loadModDetBC;

            List<LoadClass> loadModTributPis = new List<LoadClass>();
            loadModTributPis.Add(new LoadClass("0", "Valor"));
            loadModTributPis.Add(new LoadClass("1", "Quantidade"));
            loadModTributPis.Add(new LoadClass("2", "Não tributado"));
            
            cmbModTributPis.ValueMember = "id";
            cmbModTributPis.DisplayMember = "descricao";
            cmbModTributPis.DataSource = loadModTributPis;

            List<LoadClass> loadModDTributCofins = new List<LoadClass>();
            loadModDTributCofins.Add(new LoadClass("0", "Valor"));
            loadModDTributCofins.Add(new LoadClass("1", "Quantidade"));
            loadModDTributCofins.Add(new LoadClass("2", "Não tributado"));
           
            cmbModTributCofins.ValueMember = "id";
            cmbModTributCofins.DisplayMember = "descricao";
            cmbModTributCofins.DataSource = loadModDTributCofins;


            List<LoadClass> loadModDetBCST = new List<LoadClass>();
            loadModDetBCST.Add(new LoadClass("0", "Preço tabelado ou maximo sugerido"));
            loadModDetBCST.Add(new LoadClass("1", "Lista Negativa (valor)"));
            loadModDetBCST.Add(new LoadClass("2", "Lista Positiva (valor)"));
            loadModDetBCST.Add(new LoadClass("3", "Lista Neutra (valor)"));
            loadModDetBCST.Add(new LoadClass("4", "Margem Valor Agregado (%)"));
            loadModDetBCST.Add(new LoadClass("5", "Pauta (Valor)"));

            cmbModalidadeDetBCST.ValueMember = "id";
            cmbModalidadeDetBCST.DisplayMember = "descricao";
            cmbModalidadeDetBCST.DataSource = loadModDetBCST;


            List<LoadClass> loadReducaoBC = new List<LoadClass>();
            loadReducaoBC.Add(new LoadClass("0", "Não possui redução de base de cálculo"));
            loadReducaoBC.Add(new LoadClass("1", "Possui redução de base de cálculo"));

            cmbReducaoBC.ValueMember = "id";
            cmbReducaoBC.DisplayMember = "descricao";
            cmbReducaoBC.DataSource = loadReducaoBC;

            List<LoadClass> loadST = new List<LoadClass>();
            loadST.Add(new LoadClass("0", "Não possui ST"));
            loadST.Add(new LoadClass("1", "Possui Somente ST"));
            loadST.Add(new LoadClass("2", "Possui ST com redução de BC ST"));

            cmbST.ValueMember = "id";
            cmbST.DisplayMember = "descricao";
            cmbST.DataSource = loadST;

            loading = false;
        }

        private void loadEdit()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                   "SELECT                              " +                
                    "  prf_origem,                       " +
                    "  prf_extipi,                       " +
                    "  prf_genero,                       " +
                    "  prf_cofins,                       " +
                    "  prf_cofins_cst,                   " +
                    "  prf_cofins_aliquota,              " +
                    "  prf_cofins_modalidade_tributacao, " +
                    "  prf_cofins_imposto_retido,        " +
                    "  prf_pis,                          " +
                    "  prf_pis_cst,                      " +
                    "  prf_pis_aliquota,                 " +
                    "  prf_pis_modalidade_tributacao,    " +
                    "  prf_pis_imposto_retido,           " +
                    "  id_modelo_fiscal_icms,            " +
                    "  id_ncm                            " +
                    "FROM                                " +
                    "  public.produto_fiscal             " +   
                    "WHERE " +
                    "  id_produto = " + this.id;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    this.cmbOrigem.SelectedValue = read["prf_origem"].ToString();
                    this.txtExtipi.Text = read["prf_extipi"].ToString();
                    if (read["prf_genero"] != DBNull.Value)
                    {
                        this.nudGenero.Value = Convert.ToDecimal(read["prf_genero"], CultureInfo.InvariantCulture);
                    }

                    this.cbxSobrescreverPIS.Checked = Convert.ToBoolean(Convert.ToInt16(read["prf_pis"]));
                    if (this.cbxSobrescreverPIS.Checked)
                    {
                        this.cmbCSTPis.SelectedValue = read["prf_pis_cst"].ToString();
                        this.cmbModTributPis.SelectedValue = read["prf_pis_modalidade_tributacao"].ToString();
                        this.cbxImpRetidoPis.Checked = Convert.ToBoolean(Convert.ToInt16(read["prf_pis_imposto_retido"]));
                        if (read["prf_pis_aliquota"] != DBNull.Value)
                        {
                            this.nudAliquotaPis.Value = Convert.ToDecimal(read["prf_pis_aliquota"], CultureInfo.InvariantCulture);
                        }
                    }

                    this.cbxSobrescreverCOFINS.Checked = Convert.ToBoolean(Convert.ToInt16(read["prf_cofins"]));
                    if (this.cbxSobrescreverCOFINS.Checked)
                    {
                        this.cmbCSTCofins.SelectedValue = read["prf_cofins_cst"].ToString();
                        this.cmbModTributCofins.SelectedValue = read["prf_cofins_modalidade_tributacao"].ToString();
                        this.cbxImpRetidoCofins.Checked = Convert.ToBoolean(Convert.ToInt16(read["prf_cofins_imposto_retido"]));
                        if (read["prf_cofins_aliquota"] != DBNull.Value)
                        {
                            this.nudAliquotaCofins.Value = Convert.ToDecimal(read["prf_cofins_aliquota"], CultureInfo.InvariantCulture);
                        }
                    }

                    if (read["id_modelo_fiscal_icms"] != DBNull.Value)
                    {
                        this.cmbModeloICMS.SelectedValue = read["id_modelo_fiscal_icms"].ToString();
                    }

                    if (read["id_ncm"] != DBNull.Value)
                    {
                        long idNcm = Convert.ToInt64(read["id_ncm"]);

                        NcmClass ncm = NcmClass.GetEntidade(idNcm, Usuario, conn);
                        this.ensNCM.EntidadeSelecionada= ncm;
                    }

                    read.Close();
                }

                this.produto = ProdutoBaseClass.GetEntidade(this.id, this.Usuario, this.conn);


                if (produto.ResponsavelFrete == null)
                {
                    this.chkResponsavelFrete.Checked = false;
                }
                else
                {
                    this.chkResponsavelFrete.Checked = true;
                    switch (this.produto.ResponsavelFrete)
                    {
                        case ResponsavelFrete.Emitente:
                            this.rdbFreteEmitente.Checked = true;
                            break;

                        case ResponsavelFrete.Cliente:
                            this.rdbFreteCliente.Checked = true;
                            break;

                        case ResponsavelFrete.Terceiros:
                            this.rdbFreteTerceiros.Checked = true;
                            break;

                        case ResponsavelFrete.SemFrete:
                            this.rdbFreteSemFrete.Checked = true;
                            break;
                        case ResponsavelFrete.ProprioDestinatario:
                            rdbFreteProprioDestinatario.Checked = true;
                            break;
                        case ResponsavelFrete.ProprioRemetente:
                            rdbFreteProprioRemetente.Checked = true;
                            break;
                    }
                }

                List<ProdutoRevisaoClass> revisoesFiscal = produto.CollectionProdutoRevisaoClassProduto.Where(a => a.Tipo_Fiscal).ToList();
                ProdutoRevisaoClass ultimaRevisao = revisoesFiscal.OrderByDescending(a => a.Data).FirstOrDefault();

                if (ultimaRevisao != null)
                {
                    lblRevisaoData.Text = ultimaRevisao.Data.ToString("dd/MM/yyyy HH:mm:ss");
                    lblRevisaoUsuario.Text = ultimaRevisao.AcsUsuario.ToString();
                    lblRevisaoJustificativa.Text = ultimaRevisao.Observacao;
                }

                /*switch (produto.calculoPreco)
                {
                    case tipoCalculoPreco.Fixo:
                        this.rdbPrecoFixo.Checked = true;
                        break;
                    case tipoCalculoPreco.Variável:
                        this.rdbPrecoVariavel.Checked = true;
                        this.txtRegraPrecoVariavel.Text = produto.regraPrecoVariavel;
                        break;

                    case tipoCalculoPreco.NaoAplicavel:
                        this.rdbPrecoNaoAplicavel.Checked = true;
                        break;
                }
                */

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para edição.\r\n" + e.Message);
            }
        }

        private void Salvar()
        {
            try
            {
                this.validateRequiredFields();
                string justificativa = null;
                if (this.produto.ID != -1 != null)
                {

                    JustificativaForm formJustificativa = new JustificativaForm("Sr(a). " + this.Usuario.Name + " (" + this.Usuario.Login + ") essa operação será registrada como uma revisão do cadastro fiscal do produto em seu nome. Você deseja prosseguir?");
                    formJustificativa.ShowDialog();

                    if (formJustificativa.Abortar)
                    {
                        return;
                    }
                    else
                    {
                        justificativa = formJustificativa.Justificativa;
                    }
                }

                if (!IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {

                    if (rdbNovoIcms.Checked)
                    {
                        this.updadeICMS();

                        string sql = "SELECT id_modelo_fiscal_icms, mfi_nome FROM public.modelo_fiscal_icms;";

                        IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                        if (adapter != null)
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);

                            BindingSource binding = new BindingSource();
                            binding.DataSource = ds.Tables[0];
                            this.cmbModeloICMS.ValueMember = "id_modelo_fiscal_icms";
                            this.cmbModeloICMS.DisplayMember = "mfi_nome";
                            this.cmbModeloICMS.DataSource = binding;
                        }

                        this.cmbModeloICMS.SelectedValue = this.idICMS;
                    }
                }

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                command.CommandText = "DELETE FROM produto_fiscal WHERE id_produto = " + this.id;
                command.ExecuteNonQuery();

                if (id != null)
                {
                    command.CommandText =
                        "INSERT INTO                          " +
                        "  public.produto_fiscal              " +
                        "(                                    " +
                        "  id_produto,                        " +
                        "  prf_origem,                        " +
                        "  prf_extipi,                        " +
                        "  prf_genero,                        " +
                        "  prf_cofins,                        " +
                        "  prf_cofins_cst,                    " +
                        "  prf_cofins_aliquota,               " +
                        "  prf_cofins_modalidade_tributacao,  " +
                        "  prf_cofins_imposto_retido,         " +
                        "  prf_pis,                           " +
                        "  prf_pis_cst,                       " +
                        "  prf_pis_aliquota,                  " +
                        "  prf_pis_modalidade_tributacao,     " +
                        "  prf_pis_imposto_retido,            " +
                        "  id_modelo_fiscal_icms,             " +
                        "  id_ncm                             " +
                        ")                                    " +
                        "VALUES (                             " +
                        "  :id_produto,                       " +
                        "  :prf_origem,                       " +
                        "  :prf_extipi,                       " +
                        "  :prf_genero,                       " +
                        "  :prf_cofins,                       " +
                        "  :prf_cofins_cst,                   " +
                        "  :prf_cofins_aliquota,              " +
                        "  :prf_cofins_modalidade_tributacao, " +
                        "  :prf_cofins_imposto_retido,        " +
                        "  :prf_pis,                          " +
                        "  :prf_pis_cst,                      " +
                        "  :prf_pis_aliquota,                 " +
                        "  :prf_pis_modalidade_tributacao,    " +
                        "  :prf_pis_imposto_retido,           " +
                        "  :id_modelo_fiscal_icms,            " +
                        "  :id_ncm                            " +
                        ");                                   ";
                }


                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_origem", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbOrigem.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_extipi", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtExtipi.Text.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_genero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.nudGenero.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.cbxSobrescreverCOFINS.Checked);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbCSTCofins.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudAliquotaCofins.Value);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins_modalidade_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbModTributCofins.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_cofins_imposto_retido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.cbxImpRetidoCofins.Checked);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.cbxSobrescreverPIS.Checked);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbCSTPis.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudAliquotaPis.Value);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis_modalidade_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbModTributPis.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prf_pis_imposto_retido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.cbxImpRetidoPis.Checked);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_modelo_fiscal_icms", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = !IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO) ? Convert.ToInt32(this.cmbModeloICMS.SelectedValue) : (object) null;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ncm", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ensNCM.EntidadeSelecionada.ID;

                command.ExecuteNonQuery();



                /* if (this.rdbPrecoFixo.Checked)
                 {
                     this.produto.setTipoPreco(tipoCalculoPreco.Fixo, "");
                 }
 
                 if (this.rdbPrecoVariavel.Checked)
                 {
                     this.produto.setTipoPreco(tipoCalculoPreco.Variável, this.txtRegraPrecoVariavel.Text.Trim());
                 }
 
                 if (this.rdbPrecoNaoAplicavel.Checked)
                 {
                     this.produto.setTipoPreco(tipoCalculoPreco.NaoAplicavel, "");
                 }
                 */
                if (grbFrete.Enabled)
                {

                    if (this.rdbFreteEmitente.Checked)
                    {
                        this.produto.ResponsavelFrete = ResponsavelFrete.Emitente;
                    }

                    if (this.rdbFreteCliente.Checked)
                    {
                        this.produto.ResponsavelFrete = ResponsavelFrete.Cliente;
                    }

                    if (this.rdbFreteTerceiros.Checked)
                    {
                        this.produto.ResponsavelFrete = ResponsavelFrete.Terceiros;
                    }

                    if (this.rdbFreteSemFrete.Checked)
                    {
                        this.produto.ResponsavelFrete = ResponsavelFrete.SemFrete;
                    }

                    if (this.rdbFreteProprioRemetente.Checked)
                    {
                        this.produto.ResponsavelFrete = ResponsavelFrete.ProprioRemetente;
                    }

                    if (this.rdbFreteProprioDestinatario.Checked)
                    {
                        this.produto.ResponsavelFrete = ResponsavelFrete.ProprioDestinatario;
                    }
                }
                else
                {
                    this.produto.ResponsavelFrete = null;
                }

                bool tmp = this.produto.DesabilitarJustificativaRevisaoProduto;
                try
                {

                    this.produto.DesabilitarJustificativaRevisaoProduto = true;
                    this.produto.RevisarProduto(TipoRevisaoProduto.Fiscal, justificativa);
                    this.produto.Save();
                }
                finally
                {
                    this.produto.DesabilitarJustificativaRevisaoProduto = tmp;
                }


                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar.\r\n" + e.Message);
            }
            finally
            {
                BufferAbstractEntity.invalidarEntidade(typeof(ProdutoClass), id);

            }
        }

        private void updadeICMS()
        {
            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
            try
            {              

                if (this.cmbCST_ICMS.SelectedValue.ToString().Length == 0)
                {
                    throw new Exception("Campo CST do ICMS é obrigatório.");
                }

                if (this.nudPercReducaoBC.Enabled)
                {
                    if (this.nudPercReducaoBC.Value.ToString().Length == 0)
                    {
                        throw new Exception("Campo Percentual de Redução da BC é obrigatório.");
                    }
                }

                if (this.nudPercReducaoBCST.Enabled)
                {
                    if (this.nudPercReducaoBCST.Value.ToString().Length == 0)
                    {
                        throw new Exception("Campo Percentual de Redução da BC ST é obrigatório.");
                    }
                }

                if (this.nudMvaST.Enabled)
                {
                    if (this.nudMvaST.Value.ToString().Length == 0)
                    {
                        throw new Exception("Campo Percentual MVA ST é obrigatório.");
                    }
                }

                if (this.cmbUFST.Enabled)
                {
                    if (this.cmbUFST.SelectedItem == null)
                    {
                        throw new Exception("Campo UF do ICMS ST devido na operação é obrigatório.");
                    }
                }

               

command.Transaction = this.conn.BeginTransaction();

                if (idICMS == "")
                {
                    command.CommandText =
                    "INSERT INTO                          " +
                    "  public.modelo_fiscal_icms          " +
                    "(                                    " +
                    "  mfi_nome,                          " +
                    "  mfi_cst,                           " +
                    "  mfi_modalidade_determinacao_bc,    " +
                    "  mfi_reducao_bc,                    " +
                    "  mfi_percentual_reducao_bc,         " +
                    "  mfi_st,                            " +
                    "  mfi_modalidade_determinicao_bc_st, " +
                    "  mfi_percentual_reducao_bc_st,      " +
                    "  mfi_percentual_bc_propria,         " +
                    "  mfi_uf_st,                         " +
                    "  mfi_aliquota_credito,              " +
                    "  mfi_percentual_mva_st,              " +
                    "  mfi_percentual_diferimento, " +
                    "  mfi_obs_diferimento " +
                    ")                                    " +
                    "VALUES (                             " +
                    "  :mfi_nome,                         " +
                    "  :mfi_cst,                          " +
                    "  :mfi_modalidade_determinacao_bc,   " +
                    "  :mfi_reducao_bc,                   " +
                    "  :mfi_percentual_reducao_bc,        " +
                    "  :mfi_st,                           " +
                    "  :mfi_modalidade_determinicao_bc_st," +
                    "  :mfi_percentual_reducao_bc_st,     " +
                    "  :mfi_percentual_bc_propria,         " +
                    "  :mfi_uf_st,                         " +
                    "  :mfi_aliquota_credito,              " +
                    "  :mfi_percentual_mva_st,            " +
                    "  :mfi_percentual_diferimento, " +
                    "  :mfi_obs_diferimento " +
                    ") RETURNING id_modelo_fiscal_icms; ";
                }
                else
                {
                   command.CommandText =
                    "UPDATE                                                                    " +
                    "  public.modelo_fiscal_icms                                               " +
                    "SET                                                                       " +
                    "  mfi_nome = :mfi_nome,                                                   " +
                    "  mfi_cst = :mfi_cst,                                                     " +
                    "  mfi_modalidade_determinacao_bc = :mfi_modalidade_determinacao_bc,       " +
                    "  mfi_reducao_bc = :mfi_reducao_bc,                                       " +
                    "  mfi_percentual_reducao_bc = :mfi_percentual_reducao_bc,                 " +
                    "  mfi_st = :mfi_st,                                                       " +
                    "  mfi_modalidade_determinicao_bc_st = :mfi_modalidade_determinicao_bc_st, " +
                    "  mfi_percentual_reducao_bc_st = :mfi_percentual_reducao_bc_st,           " +
                    "  mfi_percentual_bc_propria = :mfi_percentual_bc_propria,         " +
                    "  mfi_uf_st = :mfi_uf_st,                         " +
                    "  mfi_aliquota_credito = :mfi_aliquota_credito,              " +
                    "  mfi_percentual_mva_st = :mfi_percentual_mva_st,                          " +
                    "  mfi_percentual_diferimento = :mfi_percentual_diferimento, " +
                    "  mfi_obs_diferimento = :mfi_obs_diferimento " +
                    "                                                                          " +
                    "WHERE                                                                     " +
                    "  id_modelo_fiscal_icms = :id_modelo_fiscal_icms                          " +
                    "RETURNING id_modelo_fiscal_icms;                                          ";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_modelo_fiscal_icms", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idICMS;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtNome.Text.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbCST_ICMS.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_modalidade_determinacao_bc", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbModalidadeDetBC.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_reducao_bc", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbReducaoBC.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_reducao_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudPercReducaoBC.Value);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbST.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_modalidade_determinicao_bc_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.cmbModalidadeDetBCST.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_reducao_bc_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudPercReducaoBCST.Value);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_mva_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudMvaST.Value);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_bc_propria", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudPercentuaBCPropria.Value);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_uf_st", NpgsqlDbType.Varchar));
                if (this.cmbUFST.Enabled)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.cmbUFST.SelectedItem.ToString();
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = "";
                }
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_aliquota_credito", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudAliquotaCredito.Value);

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_percentual_diferimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudPercentualDiferimento.Value);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mfi_obs_diferimento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtObsDiferimento.Text;



                this.idICMS = command.ExecuteScalar().ToString();

                command.CommandText = "SELECT id_estado FROM modelo_fiscal_icms_estado WHERE id_modelo_fiscal_icms = " + idICMS;
                object tmp = command.ExecuteScalar();

                if (tmp == null || tmp == DBNull.Value)
                {
                    //Inserir as aliquotas zeradas dos estados

                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.modelo_fiscal_icms_estado " +
                        "( " +
                        "  id_modelo_fiscal_icms, " +
                        "  id_estado, " +
                        "  mfe_aliquota " +
                        ")  " +
                        "SELECT  " +
                        "  " + idICMS + ", " +
                        "  id_estado, " +
                        "  0 " +
                        "FROM " +
                        "  public.estado ";

                    command.ExecuteNonQuery();
                }


             command.Transaction.Commit();

                this.Close();
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction!=null)
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
                if (this.ensNCM.EntidadeSelecionada == null)
                {
                    throw new Exception("Campo NCM é obrigatório.");
                }

                if (this.cmbOrigem.SelectedValue == null || this.cmbOrigem.SelectedValue.ToString().Length == 0)
                {
                    throw new Exception("Campo Origem é obrigatório.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        private void ICMSFields()
        {
            if (cmbCST_ICMS.SelectedValue != null)
            {
                /*
               00  - Tributado Integralmente
               10  - Tributado com cobrança do ICMS por ST
               10a - Tributado com cobrança do ICMS por ST (Partilha do ICMS entre UF origem e Destino)
               20  - Com redução da base de cálculo
               30  - Isenta ou não tributada e com cobrança do ICMS por ST
               40  - Isenta
               41  - Não tributada
               41a - Não tributada (ICMSST devido para a UF de destino, nas operações interestaduais de produtos que tiveram retenção antecipada de ICMS por ST na UF do remetente)
               50  - Suspensão
               51  - Diferimento
               60  - Cobrado Anteriormente por ST
               70  - Com redução da BC e cobrança do ICMS por ST
               90  - Outras
               90a - Outras (Partilha do ICMS entre UF origem e Destino)
               101 - Simples Nacional - Tributada com Permissão de Crédito
               102 - Simples Nacional - Tributada sem Permissão de Crédito
               103 - Simples Nacional - Isenção do ICMS para faixa de Receita Bruta
               201 - Simples Nacional - Tributada com Permissão de Crédito e com cobrança de ICMS por ST
               202 - Simples Nacional - Tributada sem Permissão de Crédito e com cobrança de ICMS por ST
               203 - Simples Nacional - Isenção do ICMS para faixa de Receita Bruta e com cobrança de ICMS por ST
               300 - Simples Nacional - Imune
               400 - Simples Nacional - Não tributado
            */

                string CST = this.cmbCST_ICMS.SelectedValue.ToString();

                switch (CST)
                {
                    case "00":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "10":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 2;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "20":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "30":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 2;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "40":
                    case "41":
                    case "50":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "51":
                        this.cmbCST_ICMS.Enabled = true;

                        this.cmbST.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbReducaoBC.Enabled = false;                       
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "60":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 1;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "70":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 2;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "90":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbModalidadeDetBCST.Enabled = true;
                        this.cmbST.Enabled = true;
                        this.cmbReducaoBC.Enabled = true;
                        this.nudPercReducaoBC.Enabled = true;
                        this.nudPercReducaoBCST.Enabled = true;
                        this.nudMvaST.Enabled = true;
                        this.nudPercentuaBCPropria.Enabled = true;
                        this.cmbUFST.Enabled = true;
                        this.nudAliquotaCredito.Enabled = true;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "10a":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 2;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "41a":
                        this.cmbCST_ICMS.Enabled = true;

                        this.cmbST.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "90a":
                        this.cmbCST_ICMS.Enabled = true;

                        this.cmbST.SelectedIndex = 2;
                        this.cmbST.Enabled = true;
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbReducaoBC.Enabled = true;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "101":
                        this.cmbCST_ICMS.Enabled = true;

                        this.cmbST.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = true;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "102":
                    case "103":
                    case "300":
                    case "400":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "201":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 2;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = true;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "202":
                    case "203":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 2;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "500":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 1;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "900":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbST.SelectedIndex = 2;
                        this.cmbST.Enabled = false;
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbReducaoBC.Enabled = false;
                        this.nudAliquotaCredito.Enabled = false;
                        this.nudAliquotaCredito.Value = 0;
                        this.grpDiferimento.Enabled = false;
                        break;

                    case "90b":
                        this.cmbCST_ICMS.Enabled = true;
                        this.cmbModalidadeDetBCST.Enabled = true;
                        this.cmbST.Enabled = true;
                        this.cmbReducaoBC.Enabled = true;
                        this.nudPercReducaoBC.Enabled = true;
                        this.nudPercReducaoBCST.Enabled = true;
                        this.nudMvaST.Enabled = true;
                        this.nudPercentuaBCPropria.Enabled = true;
                        this.cmbUFST.Enabled = true;
                        this.grpDiferimento.Enabled = true;
                        this.nudAliquotaCredito.Enabled = true;
                        break;
                }

                #region old
                /*
                switch (Convert.ToInt32(cmbCST_ICMS.SelectedValue))
                {
                        

                    case 0:
                        this.cmbModalidadeDetBC.Enabled = true;
                        this.cmbModalidadeDetBCST.Enabled = false;
                        this.nudPercReducaoBC.Enabled = false;
                        this.nudPercReducaoBC.Value = 0;
                        this.nudPercReducaoBCST.Enabled = false;
                        this.nudPercReducaoBCST.Value = 0;
                        this.nudMvaST.Enabled = false;
                        this.nudMvaST.Value = 0;

                        this.cmbReducaoBC.Enabled = false;                        
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbST.Enabled = false;                        
                        this.cmbST.SelectedIndex = 0;
                        break;

                    case 10:
                        this.cmbModalidadeDetBC.Enabled = true;
                        this.cmbModalidadeDetBCST.Enabled = true;
                        this.nudPercReducaoBC.Enabled = false;
                        this.nudPercReducaoBC.Value = 0;
                        this.nudPercReducaoBCST.Enabled = true;
                        this.nudMvaST.Enabled = true;

                        this.cmbReducaoBC.Enabled = false;
                      
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                      
                        this.cmbST.SelectedIndex = 2;
                        break;

                    case 20:
                        this.cmbModalidadeDetBC.Enabled = true;
                        this.cmbModalidadeDetBCST.Enabled = false;
                        this.nudPercReducaoBC.Enabled = true;
                        this.nudPercReducaoBCST.Enabled = false;
                        this.nudPercReducaoBCST.Value = 0;
                        this.nudMvaST.Enabled = false;
                        this.nudMvaST.Value = 0;

                        this.cmbReducaoBC.Enabled = false;
                        
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbST.Enabled = false;
                     
                        this.cmbST.SelectedIndex = 0;
                        break;

                    case 30:
                        this.cmbModalidadeDetBC.Enabled = false;
                        this.cmbModalidadeDetBCST.Enabled = true;
                        this.nudPercReducaoBC.Enabled = false;
                        this.nudPercReducaoBC.Value = 0;
                        this.nudPercReducaoBCST.Enabled = true;
                        this.nudMvaST.Enabled = true;

                        this.cmbReducaoBC.Enabled = false;
                      
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                       
                        this.cmbST.SelectedIndex = 2;
                        break;

                    case 40:
                    case 41:
                    case 50:
                        this.cmbModalidadeDetBC.Enabled = false;
                        this.cmbModalidadeDetBCST.Enabled = false;
                        this.nudPercReducaoBC.Enabled = false;
                        this.nudPercReducaoBC.Value = 0;
                        this.nudPercReducaoBCST.Enabled = false;
                        this.nudPercReducaoBCST.Value = 0;
                        this.nudMvaST.Enabled = false;
                        this.nudMvaST.Value = 0;

                        this.cmbReducaoBC.Enabled = false;
                       
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                      
                        this.cmbST.SelectedIndex = 0;
                        break;

                    case 51:
                        this.cmbModalidadeDetBC.Enabled = true;
                        this.cmbModalidadeDetBCST.Enabled = false;
                        this.nudPercReducaoBC.Enabled = true;
                        this.nudPercReducaoBCST.Enabled = false;
                        this.nudPercReducaoBCST.Value = 0;
                        this.nudMvaST.Enabled = false;
                        this.nudMvaST.Value = 0;

                        this.cmbReducaoBC.Enabled = false;
                       
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbST.Enabled = false;
                       
                        this.cmbST.SelectedIndex = 0;
                        break;

                    case 60:
                        this.cmbModalidadeDetBC.Enabled = false;
                        this.cmbModalidadeDetBCST.Enabled = false;
                        this.nudPercReducaoBC.Enabled = false;
                        this.nudPercReducaoBC.Value = 0;
                        this.nudPercReducaoBCST.Enabled = false;
                        this.nudPercReducaoBCST.Value = 0;
                        this.nudMvaST.Enabled = false;
                        this.nudMvaST.Value = 0;

                        this.cmbReducaoBC.Enabled = false;
                        
                        this.cmbReducaoBC.SelectedIndex = 0;
                        this.cmbST.Enabled = false;
                       
                        this.cmbST.SelectedIndex = 1;
                        break;

                    case 70:
                        this.cmbModalidadeDetBC.Enabled = true;
                        this.cmbModalidadeDetBCST.Enabled = true;
                        this.nudPercReducaoBC.Enabled = true;
                        this.nudPercReducaoBCST.Enabled = true;
                        this.nudMvaST.Enabled = true;

                       
                        this.cmbReducaoBC.SelectedIndex = 1;
                        this.cmbReducaoBC.Enabled = false;
                        this.cmbST.Enabled = false;
                       
                        this.cmbST.SelectedIndex = 2;
                        break;

                    case 90:
                        this.cmbModalidadeDetBC.Enabled = true;
                        this.cmbModalidadeDetBCST.Enabled = true;
                        this.nudPercReducaoBC.Enabled = true;
                        this.nudPercReducaoBCST.Enabled = true;
                        this.nudMvaST.Enabled = true;

                        this.cmbReducaoBC.Enabled = true;
                        this.cmbST.Enabled = true;
                        break;

                    default:
                        // erro
                        break;
                }
                 */
                
                #endregion

                this.ReducaoBCFields();
                this.STFields();
            }
        }

        private void ReducaoBCFields()
        {            
            switch (Convert.ToInt32(cmbReducaoBC.SelectedValue))
            {
                case 0:
                    this.cmbModalidadeDetBC.Enabled = false;
                    this.nudPercReducaoBC.Enabled = false;
                    this.nudPercReducaoBC.Value = 0;
                    this.nudPercentuaBCPropria.Enabled = false;
                    this.nudPercentuaBCPropria.Value = 0;
                    break;

                case 1:
                    this.cmbModalidadeDetBC.Enabled = true;
                    this.nudPercReducaoBC.Enabled = true;
                    this.nudPercentuaBCPropria.Enabled = true;                    
                    break;

                default:
                    break;
            }           
            
        }

        private void STFields()
        {
           
            switch (Convert.ToInt32(cmbST.SelectedValue))
            {
                case 0: //Não possui ST
                    this.cmbModalidadeDetBCST.Enabled = false;
                    this.nudPercReducaoBCST.Enabled = false;
                    this.nudPercReducaoBCST.Value = 0;
                    this.nudMvaST.Enabled = false;
                    this.nudMvaST.Value = 0;
                    this.cmbUFST.Enabled = false;
                    this.cmbUFST.SelectedIndex = -1;
                    break;

                case 1: //Possui Somente ST                       
                    this.cmbModalidadeDetBCST.Enabled = true;
                    this.nudPercReducaoBCST.Enabled = false;
                    this.nudPercReducaoBCST.Value = 0;
                    this.nudMvaST.Enabled = true;
                    this.cmbUFST.Enabled = true;                    

                    break;

                case 2: //Possui ST com redução de BC ST                       
                    this.cmbModalidadeDetBCST.Enabled = true;
                    this.nudPercReducaoBCST.Enabled = true;
                    this.nudMvaST.Enabled = true;
                    this.cmbUFST.Enabled = true;
                    break;

                default:
                    break;
            }
                    
        }
        
        private void PISFields()
        {

            switch (Convert.ToInt32(cmbCSTPis.SelectedValue))
            {
                case 1:
                case 2:
                    this.cmbModTributPis.SelectedIndex = 0;
                    this.nudAliquotaPis.Enabled = true;
                    this.cbxImpRetidoPis.Enabled = true;
                    this.cmbModTributPis.Enabled = false;
                    break;
                case 3:
                    this.cmbModTributPis.SelectedIndex = 1;
                    this.nudAliquotaPis.Enabled = true;
                    this.cbxImpRetidoPis.Enabled = true;
                    this.cmbModTributPis.Enabled = false;                   
                    break;
                case 4:
                case 6:
                case 7:
                case 8: 
                case 9:                   
                    this.nudAliquotaPis.Enabled = false;
                    this.cbxImpRetidoPis.Enabled = false;
                    this.cmbModTributPis.Enabled = false;
                    this.cmbModTributPis.SelectedIndex = 2;
                    this.nudAliquotaPis.Value = 0;
                    break;
                default:
                    this.nudAliquotaPis.Enabled = true;
                    this.cbxImpRetidoPis.Enabled = true;
                    this.cmbModTributPis.Enabled = true;
                    break;
            }
        }

        private void COFINSFields()
        {
            switch (Convert.ToInt32(cmbCSTCofins.SelectedValue))
            {
                case 1:
                case 2:
                    this.cmbModTributCofins.SelectedIndex = 0;
                    this.nudAliquotaCofins.Enabled = true;
                    this.cbxImpRetidoCofins.Enabled = true;
                    this.cmbModTributCofins.Enabled = false;
                    break;
                case 3:
                    this.cmbModTributCofins.SelectedIndex = 1;
                    this.nudAliquotaCofins.Enabled = true;
                    this.cbxImpRetidoCofins.Enabled = true;
                    this.cmbModTributCofins.Enabled = false;
                    break;
                case 4:
                case 6:
                case 7:
                case 8:
                case 9:
                    this.nudAliquotaCofins.Enabled = false;
                    this.nudAliquotaCofins.Value = 0;
                    this.cbxImpRetidoCofins.Enabled = false;
                    this.cmbModTributCofins.Enabled = false;
                    this.cmbModTributCofins.SelectedIndex = 2;
                    break;
                default:
                    this.nudAliquotaCofins.Enabled = true;
                    this.cbxImpRetidoCofins.Enabled = true;
                    this.cmbModTributCofins.Enabled = true;
                    break;
            }
        }

        private void editarDadosICMS()
        {
            try
            {
               
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT                               " +
                    "  mfi_nome,                          " +
                    "  mfi_cst,                           " +
                    "  mfi_modalidade_determinacao_bc,    " +
                    "  mfi_reducao_bc,                    " +
                    "  mfi_percentual_reducao_bc,         " +
                    "  mfi_st,                            " +
                    "  mfi_modalidade_determinicao_bc_st, " +
                    "  mfi_percentual_reducao_bc_st,      " +
                    "  mfi_percentual_bc_propria,         " +
                    "  mfi_uf_st,                         " +
                    "  mfi_aliquota_credito,              " +
                    "  mfi_percentual_mva_st,              " +
                    "  mfi_percentual_diferimento, " +
                    "  mfi_obs_diferimento " +
                    "FROM                                 " +
                    "  public.modelo_fiscal_icms          " +
                    "WHERE " +
                    "  id_modelo_fiscal_icms = " + this.idICMS;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    this.txtNome.Text = read["mfi_nome"].ToString();
                    this.cmbCST_ICMS.SelectedValue = read["mfi_cst"].ToString();
                    this.cmbModalidadeDetBC.SelectedValue = read["mfi_modalidade_determinacao_bc"].ToString();
                    this.cmbModalidadeDetBCST.SelectedValue = read["mfi_modalidade_determinicao_bc_st"].ToString();
                    this.cmbReducaoBC.SelectedValue = read["mfi_reducao_bc"].ToString();
                    this.cmbST.SelectedValue = read["mfi_st"].ToString();
                    this.nudPercReducaoBC.Value = Convert.ToDecimal(read["mfi_percentual_reducao_bc"] == DBNull.Value ? 0 : read["mfi_percentual_reducao_bc"]);
                    this.nudPercReducaoBCST.Value = Convert.ToDecimal(read["mfi_percentual_reducao_bc_st"] == DBNull.Value ? 0: read["mfi_percentual_reducao_bc_st"]);
                    this.nudMvaST.Value = Convert.ToDecimal(read["mfi_percentual_mva_st"] == DBNull.Value ? 0 : read["mfi_percentual_mva_st"]);
                    if (read["mfi_aliquota_credito"] != DBNull.Value)
                    {
                        this.nudAliquotaCredito.Value = Convert.ToDecimal(read["mfi_aliquota_credito"]);
                    }
                    if (read["mfi_percentual_bc_propria"] != DBNull.Value)
                    {
                        this.nudPercentuaBCPropria.Value = Convert.ToDecimal(read["mfi_percentual_bc_propria"]);
                    }
                    this.cmbUFST.SelectedItem = read["mfi_uf_st"].ToString();

                    if (read["mfi_aliquota_credito"] != DBNull.Value)
                    {
                        this.nudAliquotaCredito.Value = Convert.ToDecimal(read["mfi_aliquota_credito"]);
                    }

                    if (read["mfi_percentual_bc_propria"] != DBNull.Value)
                    {
                        this.nudPercentuaBCPropria.Value = Convert.ToDecimal(read["mfi_percentual_bc_propria"]);
                    }
                    this.cmbUFST.SelectedItem = read["mfi_uf_st"].ToString();

                    this.nudPercentualDiferimento.Value = Convert.ToDecimal(read["mfi_percentual_diferimento"] == DBNull.Value?0: read["mfi_percentual_diferimento"]);
                    this.txtObsDiferimento.Text = read["mfi_obs_diferimento"].ToString();



                    read.Close();
                }
                else
                {
                    throw new Exception("ID Inválido: " + this.idICMS);
                }
                rdbNovoIcms.Checked = true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para edição.\r\n" + e.Message);
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

        private void rdbModeloICMS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModeloICMS.Checked)
            {
                cmbModeloICMS.Enabled = true;
                btnEditarICMS.Enabled = true;
                gbxICMS.Enabled = false;
                
            }
            else
            {
                cmbModeloICMS.Enabled = false;
                btnEditarICMS.Enabled = false;
                gbxICMS.Enabled = true;
            }
        }

        private void rdbNovoIcms_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbModeloICMS.Checked)
            {
                cmbModeloICMS.Enabled = true;
                btnEditarICMS.Enabled = true;
                btnNovoICMS.Enabled = true;
                gbxICMS.Enabled = false;

            }
            else
            {
                cmbModeloICMS.Enabled = false;
                btnEditarICMS.Enabled = false;
                btnNovoICMS.Enabled = false;
                gbxICMS.Enabled = true;
            }
        }

        private void btnEditarICMS_Click(object sender, EventArgs e)
        {
            this.idICMS = this.cmbModeloICMS.SelectedValue.ToString();
            this.editarDadosICMS();
            this.ICMSFields();
            this.ReducaoBCFields();
            this.STFields();
        }              
           
        private void cmbCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                this.ICMSFields();
            }
        }

        private void cmbReducaoBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                this.ReducaoBCFields();
            }
        }

        private void cmbST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                this.STFields();
            }
        }

        private void cbxSobrescreverPIS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSobrescreverPIS.Checked)
            {
                gbxPIS.Enabled = true;
            }
            else
            {
                gbxPIS.Enabled = false;
            }
        }

        private void cbxSobrescreverCOFINS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSobrescreverCOFINS.Checked)
            {
                gbxCOFINS.Enabled = true;
            }
            else
            {
                gbxCOFINS.Enabled = false;
            }
        }

        private void cmbCSTCofins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                this.COFINSFields();
            }
        }

        private void cmbCSTPis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                this.PISFields();
            }
        }

        private void btnNovoICMS_Click(object sender, EventArgs e)
        {
            this.idICMS = "";
            this.rdbNovoIcms.Checked = true;

        }



        private void chkResponsavelFrete_CheckedChanged(object sender, EventArgs e)
        {
            this.grbFrete.Enabled = this.chkResponsavelFrete.Checked;
        }
        
        //private void rdbPrecoFixo_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.txtRegraPrecoVariavel.Enabled = this.rdbPrecoVariavel.Checked;
        //}

        //private void rdbPrecoVariavel_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.txtRegraPrecoVariavel.Enabled = this.rdbPrecoVariavel.Checked;


        //}

        //private void rdbPrecoNaoAplicavel_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.txtRegraPrecoVariavel.Enabled = this.rdbPrecoVariavel.Checked;
        //}


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                tabControl1.TabPages.Remove(tabCofins);
                tabControl1.TabPages.Remove(tabPis);
                tabControl1.TabPages.Remove(tabICMS);
            }
        }

        #endregion

       

        

        

      

     

        

        
       
        
    }
}
