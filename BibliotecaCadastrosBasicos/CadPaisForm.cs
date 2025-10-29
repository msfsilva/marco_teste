using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPaisForm : IWTForm
    {
        public CadPaisForm(PaisClass entidade, CadPaisListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadPaisForm(PaisClass entidade)
            : base(entidade, typeof(PaisClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }

    }
}
