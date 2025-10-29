using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEstadoForm : IWTForm
    {
        public CadEstadoForm(EstadoClass entidade, CadEstadoListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadEstadoForm(EstadoClass entidade)
            : base(entidade, typeof(EstadoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }

    }
}
