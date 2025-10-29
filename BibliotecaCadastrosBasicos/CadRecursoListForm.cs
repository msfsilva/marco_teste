using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadRecursoListForm : IWTListForm
    {
        private TipoForm Tipo;

        public CadRecursoListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }

        public override Type getTipoEntidade()
        {
            return typeof(RecursoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadRecursoForm form = new CadRecursoForm((RecursoClass)entidade, this);
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
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            return new List<SearchParameterClass>() { new SearchParameterClass("rec_codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) };
        }

        private void btnEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                this.Etiqueta();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Etiqueta()
        {
            try
            {
                if (this.iwtDataGridView1.SelectedRows.Count > 0)
                {   
          
                    List<int> ids = (from DataGridViewRow row in this.iwtDataGridView1.SelectedRows select Convert.ToInt32(row.Cells[0].Value)).ToList();
                    CadRecursoReportForm form = new CadRecursoReportForm(ids, this.getUsuarioAtual());
                    form.ShowDialog();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar as etiquetas de recurso.\r\n" + e.Message);
            }
        }
    
    }
}
