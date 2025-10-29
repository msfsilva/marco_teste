using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadVariavelForm : IWTForm
    {
        public CadVariavelForm(VariavelClass variavel, CadVariavelListForm listForm)
            : base(variavel, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.loadComboFamiliaCliente();
        }

        public CadVariavelForm(VariavelClass variavel)
            : base(variavel, typeof(FamiliaMaterialClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();

        }

        private void loadComboFamiliaCliente()
        {
            try
            {
                FamiliaClienteClass familiaCliente = new FamiliaClienteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<FamiliaClienteClass> familiaClienteList =
                    familiaCliente.Search(new List<SearchParameterClass>() { new SearchParameterClass("fac_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (FamiliaClienteClass)a);


                this.cmbFamiliaCliente.DataSource = familiaClienteList;
                this.cmbFamiliaCliente.DisplayMember = "Nome";
                this.cmbFamiliaCliente.ValueMember = "ID";
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da Família.\r\n" + e.Message);
            }
        }

        private void cbxFamiliaCli_CheckedChanged(object sender, EventArgs e)
        {
            cmbFamiliaCliente.Enabled = cbxFamiliaCli.Checked;
        }

       
        
    }
}
