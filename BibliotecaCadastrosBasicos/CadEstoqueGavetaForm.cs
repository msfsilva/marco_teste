using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEstoqueGavetaForm : IWTForm
    {
        public CadEstoqueGavetaForm(EstoqueGavetaClass entidade, CadEstoqueGavetaListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.Estoque.FormSelecao = new CadEstoqueListForm();
            this.EstoqueCorredor.FormSelecao = new CadEstoqueCorredorListForm();
            this.EstoquePrateleira.FormSelecao = new CadEstoquePrateleiraListForm();
        }

        public CadEstoqueGavetaForm(EstoqueGavetaClass entidade)
            : base(entidade, typeof(EstoqueGavetaClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.Estoque.FormSelecao = new CadEstoqueListForm();
            this.EstoqueCorredor.FormSelecao = new CadEstoqueCorredorListForm();
            this.EstoquePrateleira.FormSelecao = new CadEstoquePrateleiraListForm();
        }

    }
}
