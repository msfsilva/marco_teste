using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoClassificacaoForm : IWTForm
    {
        public CadPedidoClassificacaoForm(PedidoClassificacaoClass entidade, CadPedidoClassificacaoListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadPedidoClassificacaoForm(PedidoClassificacaoClass entidade)
            : base(entidade, typeof(PedidoClassificacaoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }

    }
}
