using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.Relatórios;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEpiListForm : IWTListForm
    {
        private TipoForm Tipo;
        private bool modoSelecao;
        private string filtroSelecao;

        public CadEpiListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
            this.btnSelecionar.Visible = modoSelecao = false;
            this.iwtExcluirButton1.Visible = true;
        }

        public CadEpiListForm(bool modoSelecao, string filtroSelecao)
        {
            InitializeComponent();
            this.modoSelecao = modoSelecao;
            this.filtroSelecao = filtroSelecao;
            this.btnSelecionar.Visible = modoSelecao;
            this.iwtExcluirButton1.Visible = !modoSelecao;

        }

        public override Type getTipoEntidade()
        {
            return typeof(EpiClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadEpiForm form = new CadEpiForm((EpiClass)entidade, this);
                form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
                form.ShowDialog();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override IWTDataGridView getDataGrid()
        {
            return this.dgEpi;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            List<SearchParameterClass> toRet = new List<SearchParameterClass>() { new SearchParameterClass("epi_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) };
            if (modoSelecao)
            {
                toRet.Add(new SearchParameterClass("BuscaCompleta", this.filtroSelecao, SearchOperacao.FiltroNormal, SearchOrdenacao.Asc, TipoOrdenacao.String));
            }

            return toRet;
        }



        private void EtiquetaCompraRepetitiva()
        {
            try
            {
                if (this.dgEpi.SelectedRows.Count > 0)
                {
                    List<EpiClass> epis = new List<EpiClass>();
                    foreach (IWTDataGridViewRow row in this.dgEpi.SelectedRows)
                    {
                        epis.Add((EpiClass) row.DataBoundItem);
                    }

                    EtiquetaCompraRepetitivaReportForm form = new EtiquetaCompraRepetitivaReportForm(null, epis, null, null);

                    if (!form.Abort)
                    {
                        form.Show();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar as etiquetas de Kanban.\r\n" + e.Message, e);
            }
        }


        private void HistoricoCompra()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count <= 0)
                {
                    throw new ExcecaoTratada("Selecione ao menos um epi antes de abrir o histórico de compra");

                }

                List<AbstractEntity> epis = new List<AbstractEntity>();
                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    epis.Add((AbstractEntity) row.DataBoundItem);
                }

                
                EvolucaoPrecoCompraReportForm form = new EvolucaoPrecoCompraReportForm(epis,EvolucaoPrecoCompraReportClass.SelecaoEntidadeRelatorio.Epi);
                form.Show(this);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }
        }

        #region Eventos

        private void btnEtiquetasKb_Click(object sender, EventArgs e)
        {
            try
            {
                this.EtiquetaCompraRepetitiva();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistoricoCompra_Click(object sender, EventArgs e)
        {
            try
            {
                HistoricoCompra();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
