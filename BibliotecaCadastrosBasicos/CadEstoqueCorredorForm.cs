using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEstoqueCorredorForm : IWTForm
    {
        public CadEstoqueCorredorForm(EstoqueCorredorClass entidade, CadEstoqueCorredorListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.Estoque.FormSelecao = new CadEstoqueListForm();
        }

        public CadEstoqueCorredorForm(EstoqueCorredorClass entidade)
            : base(entidade, typeof(EstoqueCorredorClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.Estoque.FormSelecao = new CadEstoqueListForm();
        }

    }
}
