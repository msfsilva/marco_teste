using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaComunicacaoGAD.api;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadProgramacaoListForm : IWTListForm
    {

       public CadProgramacaoListForm()
        {
            InitializeComponent();
        }

        public override Type getTipoEntidade()
        {
            return typeof(ProgramacaoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                if (entidade != null)
                {
                    CadProgramacaoForm form = new CadProgramacaoForm((ProgramacaoClass) entidade, this);
                    form.VerificaUtilizacao = false;
                    form.ShowDialog();
                }
                else
                {
                    CadProgramacaoNovoForm form = new CadProgramacaoNovoForm(this);
                    form.VerificaUtilizacao = false;
                    form.ShowDialog();
                }
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
            return new List<SearchParameterClass>() { new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica) };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadDocsProgramacao();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this,"Erro inesperado ao fazer o download dos documentos da programação. " + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void DownloadDocsProgramacao()
        {
            try
            {
                if (getDataGrid().SelectedRowsIwt.Count == 0)
                {
                    throw new ExcecaoTratada("Selecione uma programação para fazer o download dos documentos");
                }
                if (getDataGrid().SelectedRowsIwt.Count > 1)
                {
                    throw new ExcecaoTratada("Selecione apenas uma programação para fazer o download dos documentos");
                }

                ProgramacaoClass programacao = (ProgramacaoClass)getDataGrid().SelectedRowsIwt[0].DataBoundItem;

                if (!programacao.ProgramacaoGadId.HasValue)
                {
                    throw new ExcecaoTratada("A programação selecionada não possui uma programação correspondente no GAD.");
                }

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {                    
                    ProgramacaoControll.downloadArquivosProgramacao(programacao.ProgramacaoGadId.Value, "Download da programação " + programacao.Nome, folderBrowserDialog1.SelectedPath, programacao.Nome + ".zip");
                }
            }
            catch (ExcecaoTratada e)
            {
                throw e;
            }
            catch (Exception e)
            {                
                throw e;
            }
        }
    }
}
