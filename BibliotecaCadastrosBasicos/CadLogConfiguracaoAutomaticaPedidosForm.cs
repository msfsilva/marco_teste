using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadLogConfiguracaoAutomaticaPedidosForm : IWTForm
    {
        public CadLogConfiguracaoAutomaticaPedidosForm(LogConfiguracaoAutomaticaPedidosClass entidade, CadLogConfiguracaoAutomaticaPedidosListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadLogConfiguracaoAutomaticaPedidosForm(LogConfiguracaoAutomaticaPedidosClass entidade)
            : base(entidade, typeof(LogConfiguracaoAutomaticaPedidosClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Conteudo.removeForceDisable();
        }
    }
}
