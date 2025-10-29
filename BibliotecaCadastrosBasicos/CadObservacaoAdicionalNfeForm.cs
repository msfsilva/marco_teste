using System;
using System.Collections.Generic;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadObservacaoAdicionalNfeForm : IWTForm
    {
        public CadObservacaoAdicionalNfeForm(ObservacaoAdicionalNfeClass entidade, CadObservacaoAdicionalNfeListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.Ncm.FormSelecao = new CadNcmListForm(TipoModulo.Tipo);
        }

        public CadObservacaoAdicionalNfeForm(ObservacaoAdicionalNfeClass entidade)
            : base(entidade, typeof(ObservacaoAdicionalNfeClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.Ncm.FormSelecao = new CadNcmListForm(TipoModulo.Tipo);
        }

    }
}
