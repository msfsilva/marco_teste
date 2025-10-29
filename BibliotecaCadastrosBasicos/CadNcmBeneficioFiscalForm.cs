using System;
using System.Collections.Generic;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadNcmBeneficioFiscalForm : IWTForm
    {
        

        public CadNcmBeneficioFiscalForm(NcmBeneficioFiscalClass entidade)
            : base(entidade, typeof(NcmBeneficioFiscalClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.Estado.FormSelecao = new CadEstadoListForm();
        }

    }
}
