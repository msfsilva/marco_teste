using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadProgramacaoForm : IWTForm
    {
        public CadProgramacaoForm(ProgramacaoClass entidade, CadProgramacaoListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadProgramacaoForm(ProgramacaoClass entidade)
            : base(entidade, typeof(ProgramacaoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dgPedidos.DataSource = ((ProgramacaoClass) this.Entity).CollectionPedidoItemClassProgramacao;
        }
    }
}
