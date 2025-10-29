using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTFunctions;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadNcmForm : IWTForm
    {
        NcmClass _ncm
        {
            get { return (NcmClass) Entity; }
        }


        public ToolTip totCST;
        public ToolTip toolTip1;
        public ToolTip toolTip2;
        public ToolTip toolTip3;

        private bool loadingCombo = false;



        public CadNcmForm(NcmClass ncm, CadNcmListForm listForm)
            : base(ncm, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadNcmForm(NcmClass ncm)
            : base(ncm, typeof(NcmClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }


        protected override void OnShown(EventArgs e)
        {


            base.OnShown(e);

            loadTips();
            loadCombos();

            InitializeGridAliquotaFundoCombatePobreza();
            InitializeGridBeneficioFiscal();

            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                grbII.Visible = false;
                //grbIPI.Visible = false;
            }
        }

        private void loadTips()
        {
            totCST = new ToolTip();
            toolTip1 = new ToolTip();
            toolTip2 = new ToolTip();
            toolTip3 = new ToolTip();

            totCST.SetToolTip(this.cmbCST, "Código da situação tributária do IPI");
            toolTip1.SetToolTip(this.txtIPICodEnquadramento, "Tabela a ser criada pela RFB, informar 999 enquanto a tabela não for criada");
            toolTip2.SetToolTip(this.cmbModalidadeTributacao, "Forma como o IPI será calculado");
            toolTip3.SetToolTip(this.nudAliquota, "Aliquota do IPI");

        }

        private void loadCombos()
        {
            this.loadingCombo = true;

            List<LoadClass> loadCST = new List<LoadClass>();
            loadCST.Add(new LoadClass("00", "(00)Entrada com recuperação de crédito"));
            loadCST.Add(new LoadClass("01", "(01)Entrada tributada com alíquota zero"));
            loadCST.Add(new LoadClass("02", "(02)Entrada isenta"));
            loadCST.Add(new LoadClass("03", "(03)Entrada não-tributada"));
            loadCST.Add(new LoadClass("04", "(04)Entrada imune"));
            loadCST.Add(new LoadClass("05", "(05)Entrada com suspensão"));
            loadCST.Add(new LoadClass("49", "(49)Outras entradas"));
            loadCST.Add(new LoadClass("50", "(50)Saída tributada"));
            loadCST.Add(new LoadClass("51", "(51)Saída tributada com alíquota zero"));
            loadCST.Add(new LoadClass("52", "(52)Saída isenta"));
            loadCST.Add(new LoadClass("53", "(53)Saída não-tributada"));
            loadCST.Add(new LoadClass("54", "(54)Saída imune"));
            loadCST.Add(new LoadClass("55", "(55)Saída com suspensão"));
            loadCST.Add(new LoadClass("99", "(99)Outras saídas"));

            List<LoadClass> loadModTribut = new List<LoadClass>();
            loadModTribut.Add(new LoadClass("0", "Tributado por Valor"));
            loadModTribut.Add(new LoadClass("1", "Tributado por Quantidade"));
            loadModTribut.Add(new LoadClass("2", "Não Tributado"));


            cmbCST.DataSource = loadCST;
            cmbCST.ValueMember = "id";
            cmbCST.DisplayMember = "descricao";

            cmbModalidadeTributacao.ValueMember = "id";
            cmbModalidadeTributacao.DisplayMember = "descricao";
            cmbModalidadeTributacao.DataSource = loadModTribut;

            this.loadingCombo = false;

            if (((NcmClass) this.Entity).ID != -1)
            {
                cmbCST.SelectedValue = ((NcmClass) this.Entity).IpiCst;
                cmbModalidadeTributacao.SelectedValue = ((NcmClass) this.Entity).IpiModalidadeTributacao.ToString();
            }

        }


        #region Funções AliquotaFundoCombatePobreza

        private void InitializeGridAliquotaFundoCombatePobreza()
        {
            try
            {
                this.dgvAliquotasFCP.DataSource = _ncm.CollectionAliquotaFundoCombatePobrezaClassNcm;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao montar a listagem de aliquotas\r\n" + e.Message, e);
            }
        }

        private void EditarAliquotaFundoCombatePobreza()
        {
            try
            {
                if (this.dgvAliquotasFCP.SelectedRows.Count == 0) return;

                AliquotaFundoCombatePobrezaClass aliquota = (AliquotaFundoCombatePobrezaClass) ((IWTDataGridViewRow) this.dgvAliquotasFCP.SelectedRows[0]).DataBoundItem;
                CadAliquotaFundoCombatePobrezaForm form = new CadAliquotaFundoCombatePobrezaForm(aliquota)
                {
                    ModoMasterDetail = true
                };
                form.ShowDialog(this);

                this.dgvAliquotasFCP.InvalidateRow(this.dgvAliquotasFCP.SelectedRows[0].Index);

                if (form.Salvo)
                {
                    aliquota.ForceDirty();
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao editar a aliquota.\r\n" + e.Message, e);
            }
        }

        private void NovaAliquotaFundoCombatePobreza()
        {
            AliquotaFundoCombatePobrezaClass aliquota = new AliquotaFundoCombatePobrezaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
            {
                Ncm = _ncm
            };

            CadAliquotaFundoCombatePobrezaForm form = new CadAliquotaFundoCombatePobrezaForm(aliquota)
            {
                ModoMasterDetail = true
            };
            form.ShowDialog(this);

            if (form.Salvo)
            {
                _ncm.AdicionarAliquotaFCP(aliquota);
                aliquota.ForceDirty();
            }
        }

        private void ExcluirAliquotaFundoCombatePobreza()
        {
            try
            {
                if (this.dgvAliquotasFCP.SelectedRows.Count == 0) return;

                if (DialogResult.Yes != MessageBox.Show(this, "Deseja excluir a aliquota selecionada?", "Exclusão de Alíquota FCP", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                AliquotaFundoCombatePobrezaClass aliquota = (AliquotaFundoCombatePobrezaClass) ((IWTDataGridViewRow) this.dgvAliquotasFCP.SelectedRows[0]).DataBoundItem;
                _ncm.RemoverAliquotaFCP(aliquota);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir a aliquota.\r\n" + e.Message, e);
            }
        }

        #endregion


        #region Funções BeneficioFiscal

        private void InitializeGridBeneficioFiscal()
        {
            try
            {
                this.dgvBeneficios.DataSource = _ncm.CollectionNcmBeneficioFiscalClassNcm;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao montar a listagem de Beneficios Fiscal\r\n" + e.Message, e);
            }
        }

        private void EditarBeneficioFiscal()
        {
            try
            {
                if (this.dgvBeneficios.SelectedRows.Count == 0) return;

                NcmBeneficioFiscalClass beneficio = (NcmBeneficioFiscalClass) ((IWTDataGridViewRow) this.dgvBeneficios.SelectedRows[0]).DataBoundItem;
                CadNcmBeneficioFiscalForm form = new CadNcmBeneficioFiscalForm(beneficio)
                {
                    ModoMasterDetail = true
                };
                form.ShowDialog(this);

                this.dgvBeneficios.InvalidateRow(this.dgvBeneficios.SelectedRows[0].Index);

                if (form.Salvo)
                {
                    beneficio.ForceDirty();
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao editar o beneficio fiscal.\r\n" + e.Message, e);
            }
        }

        private void NovaBeneficioFiscal()
        {
            NcmBeneficioFiscalClass beneficio = new NcmBeneficioFiscalClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
            {
                Ncm = _ncm
            };

            CadNcmBeneficioFiscalForm form = new CadNcmBeneficioFiscalForm(beneficio)
            {
                ModoMasterDetail = true
            };
            form.ShowDialog(this);

            if (form.Salvo)
            {
                _ncm.AdicionarBeneficioFiscal(beneficio);
                beneficio.ForceDirty();
            }
        }

        private void ExcluirBeneficioFiscal()
        {
            try
            {
                if (this.dgvBeneficios.SelectedRows.Count == 0) return;

                if (DialogResult.Yes != MessageBox.Show(this, "Deseja excluir o benefício selecionado?", "Exclusão de benefício fiscal", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                NcmBeneficioFiscalClass beneficio = (NcmBeneficioFiscalClass) ((IWTDataGridViewRow) this.dgvBeneficios.SelectedRows[0]).DataBoundItem;
                _ncm.RemoverBeneficioFiscal(beneficio);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir a aliquota.\r\n" + e.Message, e);
            }
        }

        #endregion

        #region Eventos



        private void cmbCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.loadingCombo)
                return;
            try
            {
                if (this.cmbCST.SelectedValue != null)
                {
                    ((NcmClass) this.Entity).IpiCst = cmbCST.SelectedValue.ToString();


                    switch (this.cmbCST.SelectedValue.ToString())
                    {

                        case "00":
                        case "49":
                        case "50":
                        case "99":
                            this.cmbModalidadeTributacao.Enabled = true;
                            break;


                        case "01":
                        case "02":
                        case "03":
                        case "04":
                        case "05":
                        case "51":
                        case "52":
                        case "53":
                        case "54":
                        case "55":
                            this.cmbModalidadeTributacao.Enabled = false;
                            this.cmbModalidadeTributacao.SelectedValue = "2";
                            break;


                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbModalidadeTributacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.loadingCombo)
                return;
            try
            {
                if (this.cmbModalidadeTributacao.SelectedValue != null)
                {
                    ((NcmClass) this.Entity).IpiModalidadeTributacao = Convert.ToInt32(cmbModalidadeTributacao.SelectedValue);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                NovaAliquotaFundoCombatePobreza();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                EditarAliquotaFundoCombatePobreza();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluirAliquotaFundoCombatePobreza();
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

        private void btnBeneficioNovo_Click(object sender, EventArgs e)
        {
            try
            {
                NovaBeneficioFiscal();
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

        private void btnBeneficioEditar_Click(object sender, EventArgs e)
        {
            try
            {
                EditarBeneficioFiscal();
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

        private void btnBeneficioExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluirBeneficioFiscal();
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
    }
}
