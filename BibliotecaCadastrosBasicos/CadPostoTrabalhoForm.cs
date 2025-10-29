using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPostoTrabalhoForm : IWTForm
    {

        PostoTrabalhoClass PostoTrabalho
        {
            get { return (PostoTrabalhoClass) Entity; }
        }


        public CadPostoTrabalhoForm(PostoTrabalhoClass posto, CadPostoTrabalhoListForm listForm)
            : base(posto, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            InitSelectors();

        }

        public CadPostoTrabalhoForm(PostoTrabalhoClass posto)
            : base(posto, typeof(PostoTrabalhoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            InitSelectors();



        }

        private void InitSelectors()
        {
            this.ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);
            this.ensOperacao.FormSelecao = new CadOperacaoListForm(TipoModulo.Tipo);
            this.ensOperacaoCompleta.FormSelecao = new CadOperacaoCompletaListForm();
            this.ensTransporte.FormSelecao = new CadTransporteListForm(TipoModulo.Tipo);
            this.ensAgrupadorPostoTrabalho.FormSelecao = new CadAgrupadorPostoTrabalhoListForm(TipoModulo.Tipo);
        }

        private void cbxPostoServExt_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxPostoServExt.Enabled = this.cbxPostoServExt.Checked;
            if (this.cbxPostoServExt.Checked)
            {
                this.cbxRastreamento.Checked = true;
                this.cbxRastreamento.Enabled = false;
                this.grbTipoAcompanhamento.Enabled = false;
                this.rdb2Tempos.Checked = true;

                PostoTrabalho.Acompanhamento = PostoTrabalhoAcompanhamento.DoisTempos;
                PostoTrabalho.Rastreamento = true;
            }
            else
            {
                this.cbxRastreamento.Enabled = true;
                this.grbTipoAcompanhamento.Enabled = true;

                this.ensFornecedor.Clear();
                this.ensOperacao.Clear();
                this.ensOperacaoCompleta.Clear();
                this.ensTransporte.Clear();
                
            }
        }

        protected override void OnShown(EventArgs e)
        {

            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                ensOperacao.forceDisable();
                ensOperacao.Visible = false;
            }
            else
            {
                ensOperacaoCompleta.forceDisable();
                ensOperacaoCompleta.Visible = false;
            }

            base.OnShown(e);
        }

    }

}
