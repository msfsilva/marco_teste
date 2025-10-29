using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDocumentoTipoFamiliaListForm : IWTListForm
    {
       private TipoForm Tipo;

       public CadDocumentoTipoFamiliaListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;

            if (
                 (TipoModulo.Tipo == TipoForm.Engenharia && !LoginClass.UsuarioLogado.HasAccess("MODULO_ENGENHARIA_CADASTROS_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita)) ||
                 (TipoModulo.Tipo == TipoForm.Gerencial && !LoginClass.UsuarioLogado.HasAccess("MODULO_GERENCIAL_CADASTROS_OPERACIONAIS_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita)) ||
                 (TipoModulo.Tipo == TipoForm.Qualidade && !LoginClass.UsuarioLogado.HasAccess("MODULO_QUALIDADE_DOCUMENTOS_COPIAS", AcsTipoAcesso.Escrita))
                 )
            {
                this.btnGerenciarCopias.Visible = false;
            }
        }

        public override Type getTipoEntidade()
        {
            return typeof(DocumentoTipoFamiliaClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadDocumentoTipoFamiliaForm form = new CadDocumentoTipoFamiliaForm((DocumentoTipoFamiliaClass)entidade, this, this.Tipo);
                form.VerificaUtilizacao = false;
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
                           new SearchParameterClass("Documento_Familia", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                           };
        }





   


    }
}
