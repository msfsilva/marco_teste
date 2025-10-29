using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAliquotaFundoCombatePobrezaListForm : IWTListForm
    {
        private NcmClass _filtroNcm;

       public CadAliquotaFundoCombatePobrezaListForm(NcmClass filtroNcm)
       {
           _filtroNcm = filtroNcm;
           InitializeComponent();
       }

        public override Type getTipoEntidade()
        {
            return typeof(AliquotaFundoCombatePobrezaClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadAliquotaFundoCombatePobrezaForm form = new CadAliquotaFundoCombatePobrezaForm((AliquotaFundoCombatePobrezaClass)entidade, this);
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
                new SearchParameterClass("Estado", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                new SearchParameterClass("Ncm", _filtroNcm)
            };
        } 
    }
}
