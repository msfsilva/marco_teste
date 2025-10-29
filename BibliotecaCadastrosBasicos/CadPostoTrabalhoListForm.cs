using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.TelasAuxiliares;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using Configurations;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using ProjectConstants;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadPostoTrabalhoListForm : IWTListForm
    {
        private readonly TipoForm _tipo;

        public CadPostoTrabalhoListForm(TipoForm tipo)
        {
            InitializeComponent();
            this._tipo = tipo;
        }


        #region IWTListForm

        

        public override Type getTipoEntidade()
        {
            return typeof(PostoTrabalhoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadPostoTrabalhoForm form = new CadPostoTrabalhoForm((PostoTrabalhoClass)entidade, this);
                form.VerificaUtilizacao = this._tipo != TipoForm.Gerencial;
                form.ShowDialog();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override IWTDataGridView getDataGrid()
        {
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            return new List<SearchParameterClass>() { new SearchParameterClass("pos_codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) };
        }



        #endregion

        private void ImprimirEtiqueta()
        {
            try
            {
                if (this.getDataGrid().SelectedRowsIwt.Count <= 0)
                {
                    return;
                }


                List<PostoTrabalhoClass> postos = this.getDataGrid().SelectedRowsIwt.Select(a => a.DataBoundItem).ToList().ConvertAll(a => (PostoTrabalhoClass) a);
                List<EtiquetaPostoTrabalhoReportClass> ds = EtiquetaPostoTrabalhoReportClass.Gerar(postos);

                ReportDocument rep = new EtiquetaPostoTrabalhoReport();
                rep.SetDataSource(ds);

                IWTFunctions.IWTFunctions.DefineImpressoraReport(
                    ref rep,
                    IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PRINTER),
                IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PAPER)
                    );

                ViewReportPadraoForm form = new ViewReportPadraoForm("Etiqueta de Posto de trabalho",rep);
                form.Show();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao imprimir a etiqueta do item.\r\n" + e.Message);
            }
        }


        #region Eventos


        private void btnImprimirEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                this.ImprimirEtiqueta();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }
}
