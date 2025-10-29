using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadDocumentoCopiaForm : IWTForm
    {
        private readonly DocumentoTipoFamiliaClass _documentoTipoFamilia;
        private bool loading;

        public CadDocumentoCopiaForm(DocumentoCopiaClass entidade, DocumentoTipoFamiliaClass documentoTipoFamilia, IWTPostgreNpgsqlConnection singleConnection)
            : base(entidade, typeof(DocumentoCopiaClass), LoginClass.UsuarioLogado.loggedUser,singleConnection)
        {
            _documentoTipoFamilia = documentoTipoFamilia;
            InitializeComponent();

            this.ensEstoque.FormSelecao = new CadEstoqueListForm(desabilitarOperacaoes:true);
          
        }

        private void InitCorredor()
        {
            try
            {
                if (this.ensEstoque.EntidadeSelecionada == null)
                {
                    this.ensCorredor.forceDisable();
                    this.ensCorredor.FormSelecao = null;
                    this.ensCorredor.EntidadeSelecionada = null;
                }
                else
                {
                    this.ensCorredor.FormSelecao = new CadEstoqueCorredorListForm(true, (EstoqueClass)this.ensEstoque.EntidadeSelecionada);
                    this.ensCorredor.EntidadeSelecionada = null;
                    this.ensCorredor.removeForceDisable();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar o Corredor\r\n" + e.Message);
            }
        }

        private void InitPrateleira()
        {
            try
            {
                if (this.ensCorredor.EntidadeSelecionada == null)
                {
                    this.ensPrateleira.forceDisable();
                    this.ensPrateleira.FormSelecao = null;
                    this.ensPrateleira.EntidadeSelecionada = null;
                }
                else
                {
                    this.ensPrateleira.FormSelecao = new CadEstoquePrateleiraListForm(true, (EstoqueCorredorClass)this.ensCorredor.EntidadeSelecionada);
                    this.ensPrateleira.EntidadeSelecionada = null;
                    this.ensPrateleira.removeForceDisable();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar a Prateleira\r\n" + e.Message);
            }
        }

        private void InitGaveta()
        {
            try
            {
                if (this.ensPrateleira.EntidadeSelecionada == null)
                {
                    this.ensGaveta.forceDisable();
                    this.ensGaveta.FormSelecao = null;
                    this.ensGaveta.EntidadeSelecionada = null;
                }
                else
                {
                    this.ensGaveta.FormSelecao = new CadEstoqueGavetaListForm((EstoquePrateleiraClass)this.ensPrateleira.EntidadeSelecionada);
                    this.ensGaveta.EntidadeSelecionada = null;
                    this.ensGaveta.removeForceDisable();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao inicializar a Gaveta\r\n" + e.Message);
            }
        }


        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {

            if (this.ensGaveta.EntidadeSelecionada== null)
            {
                throw new Exception("Você deve selecionar uma gaveta do estoque.");
            }

            if (this.Entity.ID == -1)
            {
                if (!this.Identificacao.Enabled)
                {
                    ((DocumentoCopiaClass) this.Entity).Identificacao = Configurations.DataIndependenteClass.GetData().ToString("yyyyMMdd-HHmmss");
                }

                ((DocumentoCopiaClass) this.Entity).DataCriacao = Configurations.DataIndependenteClass.GetData();
                ((DocumentoCopiaClass) this.Entity).DocumentoTipoFamilia = this._documentoTipoFamilia;
                this._documentoTipoFamilia.CollectionDocumentoCopiaClassDocumentoTipoFamilia.Add((DocumentoCopiaClass) this.Entity);
            }

            ((DocumentoCopiaClass) this.Entity).NovaLocalizacaoEstoque = (EstoqueGavetaClass) this.ensGaveta.EntidadeSelecionada;
            
            base.Salvar(command);
        }

        #region Eventos
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);



            if (this.Entity.ID != -1)
            {
                if (((DocumentoCopiaClass) this.Entity).LocalizacaoEstoque != null)
                {
                    this.ensEstoque.EntidadeSelecionada = ((DocumentoCopiaClass) this.Entity).LocalizacaoEstoque.EstoquePrateleira.EstoqueCorredor.Estoque;
                    this.ensCorredor.EntidadeSelecionada = ((DocumentoCopiaClass) this.Entity).LocalizacaoEstoque.EstoquePrateleira.EstoqueCorredor;
                    this.ensPrateleira.EntidadeSelecionada = ((DocumentoCopiaClass) this.Entity).LocalizacaoEstoque.EstoquePrateleira;
                    this.ensGaveta.EntidadeSelecionada = ((DocumentoCopiaClass) this.Entity).LocalizacaoEstoque;
                }
                else
                {
                    this.ensCorredor.forceDisable();
                    this.ensPrateleira.forceDisable();
                    this.ensGaveta.forceDisable();
                }
            }
            else
            {
                this.ensCorredor.forceDisable();
                this.ensPrateleira.forceDisable();
                this.ensGaveta.forceDisable();
            }
            
        }

        private void chkIDAuto_CheckedChanged(object sender, EventArgs e)
        {
            this.Identificacao.Enabled = !this.chkIDAuto.Checked;
        }
      
        private void ensEstoque_EntityChange(object sender, EventArgs e)
        {
            try
            {
                InitCorredor();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void ensCorredor_EntityChange(object sender, EventArgs e)
        {
            try
            {
                InitPrateleira();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ensPrateleira_EntityChange(object sender, EventArgs e)
        {
            try
            {
                InitGaveta();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
