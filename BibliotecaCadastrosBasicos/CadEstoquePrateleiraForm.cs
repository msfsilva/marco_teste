using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEstoquePrateleiraForm : IWTForm
    {
        public CadEstoquePrateleiraForm(EstoquePrateleiraClass entidade, CadEstoquePrateleiraListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.Estoque.FormSelecao = new CadEstoqueListForm();
            this.EstoqueCorredor.FormSelecao = new CadEstoqueCorredorListForm();
        }

        public CadEstoquePrateleiraForm(EstoquePrateleiraClass entidade)
            : base(entidade, typeof(EstoquePrateleiraClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.Estoque.FormSelecao = new CadEstoqueListForm();
            this.EstoqueCorredor.FormSelecao = new CadEstoqueCorredorListForm();
        }

    }
}
