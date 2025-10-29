using System;
using System.Collections.Generic;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadContratoFornecimentoForm : IWTForm
    {
        public CadContratoFornecimentoForm(ContratoFornecimentoClass contrato, CadContratoFornecimentoListForm listForm)
            : base(contrato, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadContratoFornecimentoForm(ContratoFornecimentoClass contrato):base(contrato, typeof(ContratoFornecimentoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }




        protected override void OnShown(EventArgs e)
        {
            this.ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);
            this.ensMaterial.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo);
            this.ensProduto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, filtroSomenteComprados: true, somenteAtivos: true);

            if (this.Entity != null)
            {
                if (((ContratoFornecimentoClass) this.Entity).ID != -1)
                {
                    if (((ContratoFornecimentoClass)this.Entity).Material != null)
                    {
                        this.rdbMaterial.Checked = true;    
                    }else
                    {
                        this.rdbProduto.Checked = true;    
                    }
                }
                else
                {
                    this.rdbMaterial.Checked = true;    
                }
                onChangeRadioItens();
            }


            base.OnShown(e);

        }






        private void onChangeRadioItens()
        {
            if(this.rdbMaterial.Checked)
            {
                ensMaterial.removeForceDisable();
                ensProduto.forceDisable();
                ((ContratoFornecimentoClass) this.Entity).Produto = null;
            }else
            {
                ensMaterial.forceDisable();
                ensProduto.removeForceDisable();
                ((ContratoFornecimentoClass)this.Entity).Material = null;
            }
        }


        #region Eventos

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            onChangeRadioItens();
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            onChangeRadioItens();
        }


        #endregion
    }
}
