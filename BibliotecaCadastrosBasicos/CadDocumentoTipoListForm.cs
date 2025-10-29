using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDocumentoTipoListForm : IWTListForm
    {
        private TipoForm Tipo;

        public CadDocumentoTipoListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;

            if (
                (TipoModulo.Tipo == TipoForm.Engenharia && !LoginClass.UsuarioLogado.HasAccess("MODULO_ENGENHARIA_CADASTROS_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita)) ||
                (TipoModulo.Tipo == TipoForm.Gerencial && !LoginClass.UsuarioLogado.HasAccess("MODULO_GERENCIAL_CADASTROS_OPERACIONAIS_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita)) ||
                (TipoModulo.Tipo == TipoForm.Qualidade && !LoginClass.UsuarioLogado.HasAccess("MODULO_QUALIDADE_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita))
                )
            {
                this.grbAcessoDiretoCopias.Visible = false;
            }


            this.ensFamiliaDocumento.FormSelecao = new CadFamiliaDocumentoListForm(TipoModulo.Tipo);
        }

        public override Type getTipoEntidade()
        {
            return typeof (DocumentoTipoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadDocumentoTipoForm form = new CadDocumentoTipoForm((DocumentoTipoClass) entidade, this);
                form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
                form.ShowDialog();
            }
            catch (ExcecaoTratada)
            {
                throw;
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
            return new List<SearchParameterClass>()
                       {
                           new SearchParameterClass("Identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                           new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Numerica)
                       };

        }


        private void Copias()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count!=1)
                {
                    throw new ExcecaoTratada("Selecione um documento para visualizar as cópias");
                }

                if(this.ensFamiliaDocumento.EntidadeSelecionada==null)
                {
                    throw new ExcecaoTratada("Selecione a familia do documento para acessar as cópias");
                }

                
                DocumentoTipoFamiliaClass search = new DocumentoTipoFamiliaClass(this.getUsuarioAtual(),this.SingleConnection);

                DocumentoTipoFamiliaClass result = search.Search(new List<SearchParameterClass>()
                                                                     {
                                                                         new SearchParameterClass("DocumentoTipo", ((IWTDataGridViewRow) this.getDataGrid().SelectedRows[0]).DataBoundItem),
                                                                         new SearchParameterClass("FamiliaDocumento", this.ensFamiliaDocumento.EntidadeSelecionada)
                                                                     }).ConvertAll(a => (DocumentoTipoFamiliaClass) a).FirstOrDefault();

                if (result==null)
                {
                    throw new ExcecaoTratada("A familia selecionada não existe no documento selecionado");
                }


                CadDocumentoTipoFamiliaForm form = new CadDocumentoTipoFamiliaForm(result, TipoModulo.Tipo);
                form.ShowDialog(this);

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

        private void btnCopias_Click(object sender, EventArgs e)
        {
            try
            {
                this.Copias();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
