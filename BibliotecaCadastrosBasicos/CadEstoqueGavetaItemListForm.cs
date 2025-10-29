using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEstoqueGavetaItemListForm : IWTListForm
    {
        private readonly ProdutoClass _produto;
        private readonly MaterialClass _material;
        private readonly EpiClass _epi;
        private readonly bool _somenteAtivos;

        public CadEstoqueGavetaItemListForm(ProdutoClass produto = null, MaterialClass material = null, EpiClass epi = null, bool somenteAtivos = true)
        {

            InitializeComponent();

            _produto = produto;
            _material = material;
            _epi = epi;
            _somenteAtivos = somenteAtivos;

        }

        public override Type getTipoEntidade()
        {
            return typeof(EstoqueGavetaItemClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {

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
            List<SearchParameterClass> torRet = new List<SearchParameterClass>() {new SearchParameterClass("IdentificacaoCompleta", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)};
            if (_somenteAtivos)
            {
                torRet.Add(new SearchParameterClass("Ativo",true));
            }

            if (_produto != null)
            {
                torRet.Add(new SearchParameterClass("Produto", _produto));
            }

            if (_material != null)
            {
                torRet.Add(new SearchParameterClass("Material", _material));
            }

            if (_epi != null)
            {
                torRet.Add(new SearchParameterClass("Epi", _epi));
            }
            return torRet;
        }
    }
}
