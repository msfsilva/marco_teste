using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadLocalDesembaracoAduaneiroForm : IWTForm
    {
        public CadLocalDesembaracoAduaneiroForm(LocalDesembaracoAduaneiroClass entidade, CadLocalDesembaracoAduaneiroListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.Estado.FormSelecao = new CadEstadoListForm();
        }

        public CadLocalDesembaracoAduaneiroForm(LocalDesembaracoAduaneiroClass entidade)
            : base(entidade, typeof(LocalDesembaracoAduaneiroClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.Estado.FormSelecao = new CadEstadoListForm();
        }

    }
}
