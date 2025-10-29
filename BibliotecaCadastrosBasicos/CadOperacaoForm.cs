using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTFunctions;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadOperacaoForm : IWTForm
    {

        private bool _loading = true;

        public CadOperacaoForm(OperacaoClass operacao, CadOperacaoListForm listForm)
            : base(operacao, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadOperacaoForm(OperacaoClass operacao) : base(operacao, typeof(OperacaoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }


        private void LoadComboIcms()
        {
            List<LoadClass> loadCST = new List<LoadClass>();
            List<LoadClass> loadCST2 = new List<LoadClass>();

            loadCST.Add(new LoadClass("40", "40 - Isenta"));
            loadCST.Add(new LoadClass("41", "41 - Não tributada"));
            loadCST.Add(new LoadClass("50", "50 - Suspensão"));
            loadCST.Add(new LoadClass("51", "51 - Diferimento"));
            loadCST.Add(new LoadClass("300", "300 - Simples Nacional - Imune"));
            loadCST.Add(new LoadClass("400", "400 - Simples Nacional - Não tributado"));

            loadCST2.Add(new LoadClass("40", "40 - Isenta"));
            loadCST2.Add(new LoadClass("41", "41 - Não tributada"));
            loadCST2.Add(new LoadClass("50", "50 - Suspensão"));
            loadCST2.Add(new LoadClass("51", "51 - Diferimento"));
            loadCST2.Add(new LoadClass("300", "300 - Simples Nacional - Imune"));
            loadCST2.Add(new LoadClass("400", "400 - Simples Nacional - Não tributado"));

            cmbICMSCST.ValueMember = "id";
            cmbICMSCST.DisplayMember = "descricao";
            cmbICMSCST.DataSource = loadCST;



            cmbMateriaisICMSCST.ValueMember = "id";
            cmbMateriaisICMSCST.DisplayMember = "descricao";
            cmbMateriaisICMSCST.DataSource = loadCST2;
        }

        private void LoadComboIpi()
        {
            List<LoadClass> loadCST = new List<LoadClass>();
            List<LoadClass> loadCST2 = new List<LoadClass>();

            loadCST.Add(new LoadClass("51", "51 - Saída tributada com alíquota zero"));
            loadCST.Add(new LoadClass("52", "52 - Saída isenta"));
            loadCST.Add(new LoadClass("53", "53 - Saída não-tributada"));
            loadCST.Add(new LoadClass("54", "54 - Saída imune"));
            loadCST.Add(new LoadClass("55", "55 - Saída com suspensão"));

            loadCST2.Add(new LoadClass("51", "51 - Saída tributada com alíquota zero"));
            loadCST2.Add(new LoadClass("52", "52 - Saída isenta"));
            loadCST2.Add(new LoadClass("53", "53 - Saída não-tributada"));
            loadCST2.Add(new LoadClass("54", "54 - Saída imune"));
            loadCST2.Add(new LoadClass("55", "55 - Saída com suspensão"));

            cmbIPICST.ValueMember = "id";
            cmbIPICST.DisplayMember = "descricao";
            cmbIPICST.DataSource = loadCST;

            cmbMateriaisIPICST.ValueMember = "id";
            cmbMateriaisIPICST.DisplayMember = "descricao";
            cmbMateriaisIPICST.DataSource = loadCST2;
        }

        private void LoadComboPis()
        {
            List<LoadClass> loadCST = new List<LoadClass>();
            List<LoadClass> loadCST2 = new List<LoadClass>();

            loadCST.Add(new LoadClass("04", "04 - Operação Tributável(Tributação monofásica(alíquota zero))"));
            loadCST.Add(new LoadClass("06", "06 - Operação Tributável(Alíquota zero)"));
            loadCST.Add(new LoadClass("07", "07 - Operação Isenta da Contribuição"));
            loadCST.Add(new LoadClass("08", "08 - Operação Sem Incidência da Contribuição"));
            loadCST.Add(new LoadClass("09", "09 - Operação com Suspensão da Contribuição"));

            loadCST2.Add(new LoadClass("04", "04 - Operação Tributável(Tributação monofásica(alíquota zero))"));
            loadCST2.Add(new LoadClass("06", "06 - Operação Tributável(Alíquota zero)"));
            loadCST2.Add(new LoadClass("07", "07 - Operação Isenta da Contribuição"));
            loadCST2.Add(new LoadClass("08", "08 - Operação Sem Incidência da Contribuição"));
            loadCST2.Add(new LoadClass("09", "09 - Operação com Suspensão da Contribuição"));

            cmbPISCST.ValueMember = "id";
            cmbPISCST.DisplayMember = "descricao";
            cmbPISCST.DataSource = loadCST;

            cmbMateriaisPISCST.ValueMember = "id";
            cmbMateriaisPISCST.DisplayMember = "descricao";
            cmbMateriaisPISCST.DataSource = loadCST2;
        }

        private void LoadComboCofins()
        {
            List<LoadClass> loadCST = new List<LoadClass>();
            List<LoadClass> loadCST2 = new List<LoadClass>();

            loadCST.Add(new LoadClass("04", "04 - Operação Tributável(Tributação monofásica(alíquota zero))"));
            loadCST.Add(new LoadClass("06", "06 - Operação Tributável(Alíquota zero)"));
            loadCST.Add(new LoadClass("07", "07 - Operação Isenta da Contribuição"));
            loadCST.Add(new LoadClass("08", "08 - Operação Sem Incidência da Contribuição"));
            loadCST.Add(new LoadClass("09", "09 - Operação com Suspensão da Contribuição"));

            loadCST2.Add(new LoadClass("04", "04 - Operação Tributável(Tributação monofásica(alíquota zero))"));
            loadCST2.Add(new LoadClass("06", "06 - Operação Tributável(Alíquota zero)"));
            loadCST2.Add(new LoadClass("07", "07 - Operação Isenta da Contribuição"));
            loadCST2.Add(new LoadClass("08", "08 - Operação Sem Incidência da Contribuição"));
            loadCST2.Add(new LoadClass("09", "09 - Operação com Suspensão da Contribuição"));

            cmbCofinsCST.ValueMember = "id";
            cmbCofinsCST.DisplayMember = "descricao";
            cmbCofinsCST.DataSource = loadCST;

            cmbMateriaisCofinsCST.ValueMember = "id";
            cmbMateriaisCofinsCST.DisplayMember = "descricao";
            cmbMateriaisCofinsCST.DataSource = loadCST2;
        }

        private void AjsustaTabs()
        {

            if (chkDevolucaoMaterial.Checked)
            {
                this.chkPermiteEntregaFutura.forceDisable();
                this.chkPermiteEntregaFutura.Checked = false;
            }
            else
            {
                this.chkPermiteEntregaFutura.removeForceDisable();
            }

            if (chkPermiteEntregaFutura.Checked)
            {
                this.chkDevolucaoMaterial.forceDisable();
                this.chkDevolucaoMaterial.Checked = false;
            }
            else
            {
                this.chkDevolucaoMaterial.removeForceDisable();
            }


            if (chkDevolucaoMaterial.Checked)
            {
                if (!this.tabControlInfoAdicionais.TabPages.Contains(tabDevolucaoMateriais))
                {
                    this.tabControlInfoAdicionais.TabPages.Add(tabDevolucaoMateriais);
                }
            }
            else
            {
                this.tabControlInfoAdicionais.TabPages.Remove(tabDevolucaoMateriais);
            }

            if (chkPermiteEntregaFutura.Checked)
            {
                if (!this.tabControlInfoAdicionais.TabPages.Contains(tabEntregaFutura))
                {

                    this.tabControlInfoAdicionais.TabPages.Add(tabEntregaFutura);
                }
            }
            else
            {
                this.tabControlInfoAdicionais.TabPages.Remove(tabEntregaFutura);
            }

        }

        #region eventos

        protected override void OnShown(EventArgs e)
        {
            try
            {



                _loading = true;

                LoadComboIcms();
                LoadComboIpi();
                LoadComboPis();
                LoadComboCofins();

                base.OnShown(e);



                if (((OperacaoClass) this.Entity).ID != -1)
                {
                    if (((OperacaoClass) this.Entity).IcmsCstSuspenso != null)
                        cmbICMSCST.SelectedValue = ((OperacaoClass) this.Entity).IcmsCstSuspenso;

                    if (((OperacaoClass) this.Entity).IpiCstSuspenso != null)
                        cmbIPICST.SelectedValue = ((OperacaoClass) this.Entity).IpiCstSuspenso;

                    if (((OperacaoClass) this.Entity).PisCstSuspenso != null)
                        cmbPISCST.SelectedValue = ((OperacaoClass) this.Entity).PisCstSuspenso;

                    if (((OperacaoClass) this.Entity).CofinsCstSuspenso != null)
                        cmbCofinsCST.SelectedValue = ((OperacaoClass) this.Entity).CofinsCstSuspenso;

                    if (((OperacaoClass) this.Entity).DevolucaoMaterialIcmsCstSuspenso != null)
                        cmbMateriaisICMSCST.SelectedValue = ((OperacaoClass) this.Entity).DevolucaoMaterialIcmsCstSuspenso;

                    if (((OperacaoClass) this.Entity).DevolucaoMaterialIpiCstSuspenso != null)
                        cmbMateriaisIPICST.SelectedValue = ((OperacaoClass) this.Entity).DevolucaoMaterialIpiCstSuspenso;

                    if (((OperacaoClass) this.Entity).DevolucaoMaterialPisCstSuspenso != null)
                        cmbMateriaisPISCST.SelectedValue = ((OperacaoClass) this.Entity).DevolucaoMaterialPisCstSuspenso;

                    if (((OperacaoClass) this.Entity).DevolucaoMaterialCofinsCstSuspenso != null)
                        cmbMateriaisCofinsCST.SelectedValue = ((OperacaoClass) this.Entity).DevolucaoMaterialCofinsCstSuspenso;

                }

                cmbICMSCST.Enabled = rdbICMSIsento.Checked;
                cmbIPICST.Enabled = rdbIPIIsento.Checked;
                cmbPISCST.Enabled = rdbPISIsento.Checked;
                cmbCofinsCST.Enabled = rdbCofinsIsento.Checked;
                cmbISSCST.Enabled = rdbISSIsento.Checked;

                cmbMateriaisICMSCST.Enabled = rdbMatIcmsIsento.Checked;
                cmbMateriaisIPICST.Enabled = rdbMatIpiIsento.Checked;
                cmbMateriaisPISCST.Enabled = rdbMatPisIsento.Checked;
                cmbMateriaisCofinsCST.Enabled = rdbMatCofinsIsento.Checked;
                cmbMateriaisISSCST.Enabled = rdbMatCofinsIsento.Checked;

                AjsustaTabs();

                _loading = false;

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //normais

        private void rdbICMSIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbICMSCST.Enabled = rdbICMSIsento.Checked;

            if (_loading)
            {
                return;
            }

            if (!rdbICMSIsento.Checked)
            {
                ((OperacaoClass) this.Entity).IcmsCstSuspenso = null;
            }
            else
            {
                if (this.cmbICMSCST.SelectedValue == null) this.cmbICMSCST.SelectedIndex = 0;
                ((OperacaoClass) this.Entity).IcmsCstSuspenso = this.cmbICMSCST.SelectedValue.ToString();
            }
        }

        private void rdbIPIIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbIPICST.Enabled = rdbIPIIsento.Checked;

            if (_loading)
            {
                return;
            }

            if (!rdbIPIIsento.Checked)
            {
                ((OperacaoClass) this.Entity).IpiCstSuspenso = null;
            }
            else
            {
                if (this.cmbIPICST.SelectedValue == null) this.cmbIPICST.SelectedIndex = 0;
                ((OperacaoClass) this.Entity).IpiCstSuspenso = this.cmbIPICST.SelectedValue.ToString();
            }
        }

        private void rdbPISIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbPISCST.Enabled = rdbPISIsento.Checked;

            if (_loading)
            {
                return;
            }

            if (!rdbPISIsento.Checked)
            {
                ((OperacaoClass) this.Entity).PisCstSuspenso = null;
            }
            else
            {
                if (this.cmbPISCST.SelectedValue == null) this.cmbPISCST.SelectedIndex = 0;
                ((OperacaoClass) this.Entity).PisCstSuspenso = this.cmbPISCST.SelectedValue.ToString();
            }
        }

        private void rdbCofinsIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbCofinsCST.Enabled = rdbCofinsIsento.Checked;
            if (_loading)
            {
                return;
            }

            if (!rdbCofinsIsento.Checked)
            {
                ((OperacaoClass) this.Entity).CofinsCstSuspenso = null;
            }
            else
            {
                if (this.cmbCofinsCST.SelectedValue == null) this.cmbCofinsCST.SelectedIndex = 0;
                ((OperacaoClass) this.Entity).CofinsCstSuspenso = this.cmbCofinsCST.SelectedValue.ToString();
            }
        }

        private void rdbISSIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbISSCST.Enabled = rdbISSIsento.Checked;

        }

        //materiais

        private void rdbMatIcmsIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbMateriaisICMSCST.Enabled = rdbMatIcmsIsento.Checked;

            if (_loading)
            {
                return;
            }

            if (!rdbMatIcmsIsento.Checked)
            {
                ((OperacaoClass) this.Entity).DevolucaoMaterialIcmsCstSuspenso = null;
            }
            else
            {
                if (this.cmbMateriaisICMSCST.SelectedValue == null) this.cmbMateriaisICMSCST.SelectedIndex = 0;
                ((OperacaoClass) this.Entity).DevolucaoMaterialIcmsCstSuspenso = this.cmbMateriaisICMSCST.SelectedValue.ToString();
            }
        }

        private void rdbMatIpiIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbMateriaisIPICST.Enabled = rdbMatIpiIsento.Checked;

            if (_loading)
            {
                return;
            }

            if (!rdbMatIpiIsento.Checked)
            {
                ((OperacaoClass) this.Entity).DevolucaoMaterialIpiCstSuspenso = null;
            }
            else
            {
                if (this.cmbMateriaisIPICST.SelectedValue == null) this.cmbMateriaisIPICST.SelectedIndex = 0;
                ((OperacaoClass) this.Entity).DevolucaoMaterialIpiCstSuspenso = this.cmbMateriaisIPICST.SelectedValue.ToString();
            }
        }

        private void rdbMatPisIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbMateriaisPISCST.Enabled = rdbMatPisIsento.Checked;

            if (_loading)
            {
                return;
            }

            if (!rdbMatPisIsento.Checked)
            {
                ((OperacaoClass) this.Entity).DevolucaoMaterialPisCstSuspenso = null;
            }
            else
            {
                if (this.cmbMateriaisPISCST.SelectedValue == null) this.cmbMateriaisPISCST.SelectedIndex = 0;
                ((OperacaoClass) this.Entity).DevolucaoMaterialPisCstSuspenso = this.cmbMateriaisPISCST.SelectedValue.ToString();
            }

        }

        private void rdbMatCofinsIsento_CheckedChanged(object sender, EventArgs e)
        {
            cmbMateriaisCofinsCST.Enabled = rdbMatCofinsIsento.Checked;

            if (_loading)
            {
                return;
            }

            if (!rdbMatCofinsIsento.Checked)
            {
                ((OperacaoClass) this.Entity).DevolucaoMaterialCofinsCstSuspenso = null;
            }
            else
            {
                if (this.cmbMateriaisCofinsCST.SelectedValue == null) this.cmbMateriaisCofinsCST.SelectedIndex = 0;
                ((OperacaoClass) this.Entity).DevolucaoMaterialCofinsCstSuspenso = this.cmbMateriaisCofinsCST.SelectedValue.ToString();
            }

        }


        private void chkDevolucaoMaterial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjsustaTabs();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkPermiteEntregaFutura_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjsustaTabs();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Combos Normais
        private void cmbICMSCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                try
                {
                    ((OperacaoClass) this.Entity).IcmsCstSuspenso = cmbICMSCST.SelectedValue.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbIPICST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                try
                {
                    ((OperacaoClass) this.Entity).IpiCstSuspenso = cmbIPICST.SelectedValue.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbPISCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                try
                {
                    ((OperacaoClass) this.Entity).PisCstSuspenso = cmbPISCST.SelectedValue.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbCofinsCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                try
                {
                    ((OperacaoClass) this.Entity).CofinsCstSuspenso = cmbCofinsCST.SelectedValue.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Combos Devolucao

        private void cmbMateriaisICMSCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                try
                {
                    ((OperacaoClass) this.Entity).DevolucaoMaterialIcmsCstSuspenso = cmbMateriaisICMSCST.SelectedValue.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbMateriaisIPICST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                try
                {
                    ((OperacaoClass) this.Entity).DevolucaoMaterialIpiCstSuspenso = cmbMateriaisIPICST.SelectedValue.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbMateriaisPISCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                try
                {
                    ((OperacaoClass) this.Entity).DevolucaoMaterialPisCstSuspenso = cmbMateriaisPISCST.SelectedValue.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbMateriaisCofinsCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                try
                {
                    ((OperacaoClass) this.Entity).DevolucaoMaterialCofinsCstSuspenso = cmbMateriaisCofinsCST.SelectedValue.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        private void chkSomaFreteBcIcms_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkPartilhaIcms_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkNFDevolucaoSeparada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNFDevolucaoSeparada.Checked)
                {
                    txtNFDevolucaoSeparadaNatOp.removeForceDisable();
                }
                else
                {
                    txtNFDevolucaoSeparadaNatOp.forceDisable();
                }
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


        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            if (chkNFDevolucaoSeparada.Checked)
            {
                if (DialogResult.Yes != MessageBox.Show(this, "A operação está configurada para emissão de nota fiscal separada para os materiais. Nessa configuração, caso uma das notas (normal ou de materiais) apresente erros na hora do envio para a receita, a outra nota deverá ser cancelada manualmente. Deseja continuar?", "NFe de Materiais Separada", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    return;
                }
            }

            base.btnSalvar_Click(sender, e);
        }
    }
}
