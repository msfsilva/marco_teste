using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDeclaracaoImportacaoAdicaoItemForm : IWTForm
    {
        public bool Saved { get; private set; }

        internal DeclaracaoImportacaoAdicaoItemClass Item
        {
            get { return (DeclaracaoImportacaoAdicaoItemClass) this.Entity; }
        }

        internal DeclaracaoImportacaoAdicaoClass Adicao { get; set; }

        public CadDeclaracaoImportacaoAdicaoItemForm(DeclaracaoImportacaoAdicaoItemClass entidade)
            : base(entidade, typeof (DeclaracaoImportacaoAdicaoItemClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            Adicao = Item.DeclaracaoImportacaoAdicao;
            this.Material.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo, fornecedor: Adicao.DeclaracaoImportacao.Fornecedor);
            this.btnCancelar.Visible = false;
            this.DesabilitarAvisoAlteradoAoFechar = true;

        }

        public CadDeclaracaoImportacaoAdicaoItemForm(DeclaracaoImportacaoAdicaoClass adicao)
            : base(null, typeof (DeclaracaoImportacaoAdicaoItemClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            Adicao = adicao;
            this.Material.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo, fornecedor: Adicao.DeclaracaoImportacao.Fornecedor);
            this.btnCancelar.Visible = false;
            this.DesabilitarAvisoAlteradoAoFechar = true;
            
        }

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            this.Entity.ValidateData(ref command);
            this.Saved = true;
            this.Adicao.setAlterado(true);
            this.Entity.ForceClean();
            this.Close();
        }

        private void SelecionarMaterial()
        {
            try
            {
                if (this.Material.EntidadeSelecionada == null)
                {
                    this.lblAliquotaCofins.Text = "";
                    this.lblAliquotaICMS.Text = "";
                    this.lblAliquotaII.Text = "";
                    this.lblAliquotaIPI.Text = "";
                    this.lblAliquotaPis.Text = "";
                }
                else
                {
                    MaterialClass material = (MaterialClass) this.Material.EntidadeSelecionada;
                    if(material.CollectionMaterialFiscalClassMaterial.Count == 0)
                    {
                        this.Material.EntidadeSelecionada = null;
                        throw new ExcecaoTratada("Não é possível selecionar esse material pois ele não possui cadastro fiscal definido");
                    }


                    MaterialFiscalClass fiscal = material.CollectionMaterialFiscalClassMaterial[0];
                    if (fiscal.Cofins && fiscal.CofinsAliquota.HasValue)
                    {
                        this.lblAliquotaCofins.Text = fiscal.CofinsAliquota.Value.ToString("F3", CultureInfo.CurrentCulture)+"%";
                    }
                    else
                    {
                        this.lblAliquotaCofins.Text = Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.NF_EMITENTE_COFINS_ALIQUOTA) + "%";
                    }

                    if (fiscal.Pis && fiscal.PisAliquota.HasValue)
                    {
                        this.lblAliquotaPis.Text = fiscal.PisAliquota.Value.ToString("F3", CultureInfo.CurrentCulture) + "%";
                    }
                    else
                    {
                        this.lblAliquotaPis.Text = Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.NF_EMITENTE_PIS_ALIQUOTA) + "%";
                    }

                    this.lblAliquotaII.Text = fiscal.Ncm.IiAliquota.ToString("F3", CultureInfo.CurrentCulture) + "%";
                    this.AliquotaIi.Value = (decimal) fiscal.Ncm.IiAliquota;
                    this.lblAliquotaIPI.Text = fiscal.Ncm.IpiAliquota.ToString("F3", CultureInfo.CurrentCulture) + "%";

                    CidadeClass cidade = CidadeBaseClass.GetEntidade(int.Parse(Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.NF_EMITENTE_CIDADE)), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                    long idEstadoEmitente = cidade.Estado.ID;
                    ModeloFiscalIcmsEstadoClass modeloEstado = fiscal.ModeloFiscalIcms.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.First(a => a.Estado.ID == idEstadoEmitente);
                    this.lblAliquotaICMS.Text = modeloEstado.Aliquota.ToString("F3", CultureInfo.CurrentCulture) + "%"; ;
                    
                    
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Selecionar o material.\r\n" + e.Message, e);
            }
        }

        private void AtualizarTotal()
        {
            this.Item.ValorTotalDolares = (double)(this.Quantidade.Value * this.ValorUnitarioDolares.Value);
            this.lblValorTotalDolar.Text = "US$ " + this.Item.ValorTotalDolares.ToString("F4", CultureInfo.CurrentCulture);
        }



        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (this.Item.ID == -1)
            {
                this.Item.DeclaracaoImportacaoAdicao = Adicao;
            }
        }

        private void Material_EntityChange(object sender, EventArgs e)
        {
            try
            {
                this.SelecionarMaterial();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Quantidade_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.AtualizarTotal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ValorUnitarioDolares_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.AtualizarTotal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
