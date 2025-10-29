using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAliquotaFundoCombatePobrezaForm : IWTForm
    {
        public CadAliquotaFundoCombatePobrezaForm(AliquotaFundoCombatePobrezaClass entidade, CadAliquotaFundoCombatePobrezaListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.Estado.FormSelecao = new CadEstadoListForm();
        }

        public CadAliquotaFundoCombatePobrezaForm(AliquotaFundoCombatePobrezaClass entidade)
            : base(entidade, typeof(AliquotaFundoCombatePobrezaClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            this.Estado.FormSelecao = new CadEstadoListForm();
        }

    }
}
