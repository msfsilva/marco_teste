using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.TelasAuxiliares;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDeclaracaoImportacaoListForm : IWTListForm
    {

       public CadDeclaracaoImportacaoListForm()
        {
            InitializeComponent();
        }

        public override Type getTipoEntidade()
        {
            return typeof(DeclaracaoImportacaoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadDeclaracaoImportacaoForm form = new CadDeclaracaoImportacaoForm((DeclaracaoImportacaoClass)entidade, this);
                form.VerificaUtilizacao = false;

                if (entidade != null && ((DeclaracaoImportacaoClass)entidade).NfGerada)
                {
                    form.SomenteLeitura = true;
                }

                form.ShowDialog();
            }
            catch (ExcecaoTratada)
            {
               throw;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        protected override bool ValidaExclusao(AbstractEntity entity, out string aviso)
        {
            aviso = null;

            if (((DeclaracaoImportacaoClass)entity).NfGerada)
            {
                aviso = "Não é possível excluir uma DI que já teve sua nota emitida.";
                return false;
            }

            
            return true;
        }

        public override IWTDataGridView getDataGrid()
        {
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            return new List<SearchParameterClass>() { new SearchParameterClass("Numero", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica) };
        }
        
        private void EmitirNFe()
        {
            try
            {
                List<DeclaracaoImportacaoClass> dis = new List<DeclaracaoImportacaoClass>();
                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    DeclaracaoImportacaoClass di = (DeclaracaoImportacaoClass) row.DataBoundItem;
                    
                    if(di.NfGerada)
                    {
                        throw new ExcecaoTratada("Não é possível emitir a nota fiscal da DI " + di.ToString() + ", pois já teve nota emitida anteriormente.");
                    }
                    dis.Add(di);
                }
                if (dis.Count == 0)
                {
                    throw new ExcecaoTratada("Selecione ao menos uma DI para emitir a NFe");
                }
                EmissaoNfeImportacaoForm form = new EmissaoNfeImportacaoForm(dis);
                form.ShowDialog(this);

                this.ForceInitializeDataGrid();
                
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao emitir a NFe\r\n" + e.Message, e);
            }
        }



        private void btnEmitirNFe_Click(object sender, EventArgs e)
        {
            try
            {
                this.EmitirNFe();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
