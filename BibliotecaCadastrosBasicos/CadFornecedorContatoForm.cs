using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFornecedorContatoForm : IWTForm
    {
        public bool salvar { get; private set; }

        public CadFornecedorContatoForm(FornecedorContatoClass entidade)
            : base(entidade, typeof(FornecedorContatoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            this.Entity.ValidateData(ref command);

            this.salvar = true;
            this.Entity.ForceClean();
            this.Close();
        }

    }
}
