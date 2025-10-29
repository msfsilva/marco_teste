using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemLoteClienteListForm : IWTListForm
    {
        private readonly LoteClass _lote;

        public CadPedidoItemLoteClienteListForm(LoteClass lote)
        {
            _lote = lote;
            InitializeComponent();
        }

        public override Type getTipoEntidade()
        {
            return typeof(PedidoItemLoteClienteClass);
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

            return new List<SearchParameterClass>()
            {
                new SearchParameterClass("Lote",_lote),
                new SearchParameterClass("PedidoItem", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
            };
        }
    }
}
