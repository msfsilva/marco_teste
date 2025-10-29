using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEstoqueGavetaListForm : IWTListForm
    {
        private readonly EstoquePrateleiraClass _prateleira;

        public CadEstoqueGavetaListForm(EstoquePrateleiraClass prateleira = null)
        {
            _prateleira = prateleira;
            InitializeComponent();
        }

        public override Type getTipoEntidade()
        {
            return typeof(EstoqueGavetaClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadEstoqueGavetaForm form = new CadEstoqueGavetaForm((EstoqueGavetaClass)entidade, this);
                form.VerificaUtilizacao = TipoModulo.Tipo != TipoForm.Gerencial;
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
            List<SearchParameterClass> toRet = new List<SearchParameterClass>() { new SearchParameterClass("Identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica) };

            if (_prateleira != null)
            {
                toRet.Add(new SearchParameterClass("EstoquePrateleira", _prateleira));
            }
            return toRet;
        } 
    }
}
