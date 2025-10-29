using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaNotasFiscais.NotaFiscalImportacao;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class EmissaoNfeImportacaoForm : IWTBaseForm
    {
        private readonly List<DeclaracaoImportacaoClass> _dis;

        public EmissaoNfeImportacaoForm(List<DeclaracaoImportacaoClass> dis )
        {
            InitializeComponent();
            _dis = dis;
            this.ensOperacao.FormSelecao = new CadOperacaoListForm(TipoModulo.Tipo);
            this.ensTransporte.FormSelecao = new CadTransporteListForm(TipoModulo.Tipo);
        }

        private void Gerar()
        {

            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.ensOperacao.EntidadeSelecionada == null)
                {
                    throw new ExcecaoTratada("A seleção da operação é obrigatório.");
                }

                if (this.ensTransporte.EntidadeSelecionada == null)
                {
                    throw new ExcecaoTratada("A seleção do transporte é obrigatório.");
                }


                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                NotaFiscalImportacaoClass gerador = new NotaFiscalImportacaoClass();
                gerador.GerarNotaFiscalImportacao(_dis, (OperacaoClass) this.ensOperacao.EntidadeSelecionada, (TransporteClass) this.ensTransporte.EntidadeSelecionada, this.SingleConnection, command);
                command.Transaction.Commit();
                this.Close();
            }
            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro inesperado ao geras as notas ficais das dis.\r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Gerar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        #endregion
    }
}
