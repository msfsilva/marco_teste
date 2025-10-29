using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTFunctions;

namespace BibliotecaCadastrosBasicos
{

    public partial class CadModeloFiscalICMSForm : IWTForm
    {
        bool loading = true;

        public CadModeloFiscalICMSForm(ModeloFiscalIcmsClass modelo, CadModeloFiscalICMSListForm listForm)
            : base(modelo, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            if (((ModeloFiscalIcmsClass)this.Entity).ObsDiferimento==null)
            {
                ((ModeloFiscalIcmsClass) this.Entity).ObsDiferimento = "";
            }
            this.iesEstadoSt.FormSelecao = new CadEstadoListForm();
        }

        public CadModeloFiscalICMSForm(ModeloFiscalIcmsClass modelo):base(modelo, typeof(ModeloFiscalIcmsClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            this.iesEstadoSt.FormSelecao = new CadEstadoListForm();
        }


        protected override void OnShown(EventArgs e)
        {
            loading = true;

            base.OnShown(e);
            loadCombos();

            
            if (this.Entity != null)
            {

                if (((ModeloFiscalIcmsClass) this.Entity).ModalidadeDeterminacaoBc == null)
                {
                    ((ModeloFiscalIcmsClass) this.Entity).ModalidadeDeterminacaoBc = 0;
                }

                if (((ModeloFiscalIcmsClass)this.Entity).ModalidadeDeterminicaoBcSt == null)
                {
                    ((ModeloFiscalIcmsClass)this.Entity).ModalidadeDeterminicaoBcSt = 0;
                }

                if (((ModeloFiscalIcmsClass)this.Entity).ID != -1)
                {
                    if (((ModeloFiscalIcmsClass) this.Entity).Cst != null)
                    {
                        cmbCST.SelectedValue = ((ModeloFiscalIcmsClass) this.Entity).Cst;
                    }


                    cmbReducaoBC.SelectedValue = Convert.ToInt16(((ModeloFiscalIcmsClass) this.Entity).ReducaoBc).ToString();

                    if (((ModeloFiscalIcmsClass) this.Entity).ModalidadeDeterminacaoBc != null)
                    {
                        cmbModalidadeDetBC.SelectedValue =
                            ((ModeloFiscalIcmsClass) this.Entity).ModalidadeDeterminacaoBc.ToString();
                    }

                    cmbST.SelectedValue =  Convert.ToInt16(((ModeloFiscalIcmsClass) this.Entity).St).ToString();

                    if (((ModeloFiscalIcmsClass) this.Entity).ModalidadeDeterminicaoBcSt != null)
                    {
                        cmbModalidadeDetBCST.SelectedValue =
                            ((ModeloFiscalIcmsClass)this.Entity).ModalidadeDeterminicaoBcSt.ToString();
                    }
                }
            }
            
            this.ICMSFields();
            this.ReducaoBCFields();
            this.STFields();
            

            loading = false;
        }



        private void loadCombos()
        {
            List<LoadClass> loadCST = new List<LoadClass>();
            loadCST.Add(new LoadClass("00", "00  - Tributado Integralmente"));
            loadCST.Add(new LoadClass("10", "10  - Tributado com cobrança do ICMS por ST"));
            loadCST.Add(new LoadClass("10a", "10a - Tributado com cobrança do ICMS por ST (Partilha do ICMS entre UF origem e Destino)"));
            loadCST.Add(new LoadClass("20", "20  - Com redução da base de cálculo"));
            loadCST.Add(new LoadClass("30", "30  - Isenta ou não tributada e com cobrança do ICMS por ST"));
            loadCST.Add(new LoadClass("40", "40  - Isenta"));
            loadCST.Add(new LoadClass("41", "41  - Não tributada"));
            loadCST.Add(new LoadClass("41a", "41a - Não tributada (ICMSST devido para a UF de destino, nas operações interestaduais de produtos que tiveram retenção antecipada de ICMS por ST na UF do remetente)"));
            loadCST.Add(new LoadClass("50", "50  - Suspensão"));
            loadCST.Add(new LoadClass("51", "51  - Diferimento"));
            loadCST.Add(new LoadClass("60", "60  - Cobrado Anteriormente por ST"));
            loadCST.Add(new LoadClass("70", "70  - Com redução da BC e cobrança do ICMS por ST     "));
            loadCST.Add(new LoadClass("90", "90  - Outras"));
            loadCST.Add(new LoadClass("90a", "90a - Outras (Partilha do ICMS entre UF origem e Destino)"));
            loadCST.Add(new LoadClass("90b", "90b  - Outras - Diferimento Parcial"));
            loadCST.Add(new LoadClass("101", "101 - Simples Nacional - Tributada com Permissão de Crédito"));
            loadCST.Add(new LoadClass("102", "102 - Simples Nacional - Tributada sem Permissão de Crédito"));
            loadCST.Add(new LoadClass("103", "103 - Simples Nacional - Isenção do ICMS para faixa de Receita Bruta"));
            loadCST.Add(new LoadClass("201", "201 - Simples Nacional - Tributada com Permissão de Crédito e com cobrança de ICMS por ST"));
            loadCST.Add(new LoadClass("202", "202 - Simples Nacional - Tributada sen Permissão de Crédito e com cobrança de ICMS por ST"));
            loadCST.Add(new LoadClass("203", "203 - Simples Nacional - Isenção do ICMS para faixa de Receita Bruta e com cobrança de ICMS por ST"));
            loadCST.Add(new LoadClass("300", "300 - Simples Nacional - Imune"));
            loadCST.Add(new LoadClass("400", "400 - Simples Nacional - Não tributado"));
            loadCST.Add(new LoadClass("500", "500 - Simples Nacional - ICMS cobrado anteriormente por ST ou por antecipação"));
            loadCST.Add(new LoadClass("900", "900 - Simples Nacional - Outros"));

            cmbCST.ValueMember = "id";
            cmbCST.DisplayMember = "descricao";
            cmbCST.DataSource = loadCST;


            List<LoadClass> loadModDetBC = new List<LoadClass>();
            loadModDetBC.Add(new LoadClass("0", "Margem Valor Agregado (%)"));
            loadModDetBC.Add(new LoadClass("1", "Pauta (Valor)"));
            loadModDetBC.Add(new LoadClass("2", "Preço Tabelado Max. (valor)"));
            loadModDetBC.Add(new LoadClass("3", "Valor da Operação"));

            cmbModalidadeDetBC.ValueMember = "id";
            cmbModalidadeDetBC.DisplayMember = "descricao";
            cmbModalidadeDetBC.DataSource = loadModDetBC;


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


            EstadoClass estado = new EstadoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
            List<EstadoClass> estados =
                estado.Search(new List<SearchParameterClass>() { new SearchParameterClass("est_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (EstadoClass)a);
        }

        private void ICMSFields()
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
               500 - Simples Nacional - ICMS cobrado anteriormente por ST ou por antecipação
               900 - Simples Nacional - Outros
            */

            string CST = this.cmbCST.SelectedValue.ToString();

            switch (CST)
            {
                case "00":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 0;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "10":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 2;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "20":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 0;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 1;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "30":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 2;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "40":
                case "41":
                case "50":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 0;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "51":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 0;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 1;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "60":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 1;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "70":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 2;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 1;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "90":
                    this.cmbCST.Enabled = true;
                    this.cmbModalidadeDetBCST.Enabled = true;
                    this.cmbST.Enabled = true;
                    this.cmbReducaoBC.Enabled = true;
                    this.nudPercReducaoBC.Enabled = true;
                    this.nudPercReducaoBCST.Enabled = true;
                    this.nudMvaST.Enabled = true;
                    this.nudPercentuaBCPropria.Enabled = true;
                    this.iesEstadoSt.removeForceDisable();
                    //this.grpDiferimento.Enabled = false;
                    this.nudAliquotaCredito.Enabled = true;
                    break;

                case "10a":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 2;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 1;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "41a":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 0;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "90a":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 2;
                    this.cmbST.Enabled = true;
                    this.cmbReducaoBC.SelectedIndex = 1;
                    this.cmbReducaoBC.Enabled = true;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "101":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 0;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = true;
                    //this.grpDiferimento.Enabled = false;
                    break;


                case "102":
                case "103":
                case "300":
                case "400":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 0;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "201":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 2;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = true;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "202":
                case "203":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 2;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "500":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 1;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 0;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = false;
                    this.nudAliquotaCredito.Value = 0;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "900":
                    this.cmbCST.Enabled = true;
                    this.cmbST.SelectedIndex = 2;
                    this.cmbST.Enabled = false;
                    this.cmbReducaoBC.SelectedIndex = 1;
                    this.cmbReducaoBC.Enabled = false;
                    this.nudAliquotaCredito.Enabled = true;
                    //this.grpDiferimento.Enabled = false;
                    break;

                case "90b":
                    this.cmbCST.Enabled = true;
                    this.cmbModalidadeDetBCST.Enabled = true;
                    this.cmbST.Enabled = true;
                    this.cmbReducaoBC.Enabled = true;
                    this.nudPercReducaoBC.Enabled = true;
                    this.nudPercReducaoBCST.Enabled = true;
                    this.nudMvaST.Enabled = true;
                    this.nudPercentuaBCPropria.Enabled = true;
                    this.iesEstadoSt.removeForceDisable();
                    //this.grpDiferimento.Enabled = true;
                    this.nudAliquotaCredito.Enabled = true;
                    break;
            }

            this.ReducaoBCFields();
            this.STFields();

        
        }

        private void ReducaoBCFields()
        {

            switch (Convert.ToInt32(cmbReducaoBC.SelectedValue))
            {
                case 0:                   
                    this.nudPercReducaoBC.Enabled = false;
                    this.nudPercReducaoBC.Value = 0;
                    this.nudPercentuaBCPropria.Enabled = false;
                    this.nudPercentuaBCPropria.Value = 0;
                    break;

                case 1:
                    this.nudPercReducaoBC.Enabled = true;
                    this.nudPercentuaBCPropria.Enabled = true;
                    break;

                default:
                    break;
            }

        }

        private void STFields()
        {
            string CST = this.cmbCST.SelectedValue.ToString();
            switch (Convert.ToInt32(cmbST.SelectedValue))
            {
                case 0: //Não possui ST
                    this.cmbModalidadeDetBCST.Enabled = false;
                    this.nudPercReducaoBCST.Enabled = false;
                    this.nudPercReducaoBCST.Value = 0;
                    this.nudMvaST.Enabled = false;
                    this.nudMvaST.Value = 0;
                    this.iesEstadoSt.forceDisable();
                    break;

                case 1: //Possui Somente ST                       
                    this.cmbModalidadeDetBCST.Enabled = true;
                    this.nudPercReducaoBCST.Enabled = false;
                    this.nudPercReducaoBCST.Value = 0;
                    this.nudMvaST.Enabled = true;
                    if (CST == "90" || CST == "90b")
                    {
                        this.iesEstadoSt.removeForceDisable();
                    }
                    else
                    {
                        this.iesEstadoSt.forceDisable();
                    }

                    break;

                case 2: //Possui ST com redução de BC ST                       
                    this.cmbModalidadeDetBCST.Enabled = true;
                    this.nudPercReducaoBCST.Enabled = true;
                    this.nudMvaST.Enabled = true;
                    if (CST == "90" || CST == "90b")
                    {
                        this.iesEstadoSt.removeForceDisable();
                    }
                    else
                    {
                        this.iesEstadoSt.forceDisable();
                    }
                    break;

                default:
                    break;
            }
        }


        #region eventos


        private void cmbCST_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!loading)
            {
                try
                {
                    ((ModeloFiscalIcmsClass) this.Entity).Cst = cmbCST.SelectedValue.ToString();
                    this.ICMSFields();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbReducaoBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                try
                {
                    ((ModeloFiscalIcmsClass) this.Entity).ReducaoBc = Convert.ToBoolean(Convert.ToInt32(cmbReducaoBC.SelectedValue));
                    this.ReducaoBCFields();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbModalidadeDetBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                try
                {
                    ((ModeloFiscalIcmsClass)this.Entity).ModalidadeDeterminacaoBc = Convert.ToInt32(cmbModalidadeDetBC.SelectedValue);
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void cmbST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                try
                {
                    ((ModeloFiscalIcmsClass) this.Entity).St = (TipoTributacaoST) Enum.ToObject(typeof (TipoTributacaoST), Convert.ToInt32(cmbST.SelectedValue));
                    this.STFields();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void cmbModalidadeDetBCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                try
                {
                    ((ModeloFiscalIcmsClass)this.Entity).ModalidadeDeterminicaoBcSt = Convert.ToInt32(cmbModalidadeDetBCST.SelectedValue);
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        #endregion
    }
}
