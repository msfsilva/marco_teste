#region Referencias

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos.Estoque
{
    public partial class InventarioReportForm : IWTBaseForm
    {
        private readonly EstoqueClass _estoque;
        private readonly EstoqueCorredorClass _corredor;
        private readonly EstoquePrateleiraClass _prateleira;
        private readonly EstoqueGavetaClass _gaveta;
        private readonly IWTPostgreNpgsqlConnection _conn;


        public InventarioReportForm(EstoqueClass estoque, EstoqueCorredorClass corredor, EstoquePrateleiraClass prateleira, EstoqueGavetaClass gaveta, IWTPostgreNpgsqlConnection conn)
        {
            _estoque = estoque;
            _corredor = corredor;
            _prateleira = prateleira;
            _gaveta = gaveta;
            _conn = conn;

            InitializeComponent();
            this.GerarRelatorio();
        }

        private void GerarRelatorio()
        {
            try
            {
                if (this.rdbLista.Checked && chkIncluirPrecos.Checked && chkIncluirColunaUltimaUtilizacao.Checked)
                {
                    throw new ExcecaoTratada("Para o relatório em Lista não é possível incluir as colunas de Preços e Data da Última Utilização ao mesmo tempo.");
                }

                IWTPostgreNpgsqlCommand command = _conn.CreateCommand();


                List<InventarioReportClass> dados = EstoqueMovimentacao.Inventario(_estoque, _corredor, _prateleira, _gaveta, this.rdb90Dias.Checked,
                    (this.grbDataUltimaUtilizacao.Enabled && this.dtpDataInicial.Enabled ? this.dtpDataInicial.Value : (DateTime?) null),
                    (this.grbDataUltimaUtilizacao.Enabled && this.dtpDataFinal.Enabled ? this.dtpDataFinal.Value : (DateTime?) null),
                    ref command, LoginClass.UsuarioLogado.loggedUser);

                
                if (this.rdbOrdenacaoCodigo.Checked)
                {
                    if (this.rdbLista.Checked)
                    {
                        dados = dados.OrderBy(b => b.CodigoItem).ToList();
                    }
                    else
                    {
                        dados = dados.OrderBy(a => a.EstoqueString).ThenBy(b => b.CorredorString).ThenBy(b => b.PrateleiraString).ThenBy(b => b.GavetaString).ThenBy(b => b.CodigoItem).ToList();
                    }
                }

                if (this.rdbOrdenacaoDataMovimentacao.Checked)
                {
                    if (this.rdbLista.Checked)
                    {
                        dados = dados.OrderByDescending(b => b.DataUltimaUtilizacao).ToList();
                    }
                    else
                    {
                        dados = dados.OrderBy(a => a.EstoqueString).ThenBy(b => b.CorredorString).ThenBy(b => b.PrateleiraString).ThenBy(b => b.GavetaString).ThenByDescending(b => b.DataUltimaUtilizacao).ToList();
                    }
                }


                if (!chkSepararMateriais.Checked)
                {
                    foreach (InventarioReportClass item in dados)
                    {
                        item.SuprimirConteudo = true;
                    }
                }


                //TODO: Migração Estoque - Verificar e atualizar os campos desses dois relatórios de inventário
                CrystalDecisions.CrystalReports.Engine.ReportClass rep;
                if (this.rdbLista.Checked)
                {
                    rep = new InventarioListaReport();
                }
                else
                {
                    rep = new InventarioReport();
                }
                rep.SetDataSource(dados);
                rep.SetParameterValue("ExibirValores",this.chkIncluirPrecos.Checked);
                rep.SetParameterValue("ExibirLocalizacaoCompleta", this.chkIncluirColunaLocalizacao.Checked);
                rep.SetParameterValue("ExibirDataUltimaUtilizacao", this.chkIncluirColunaUltimaUtilizacao.Checked);
                this.crystalReportViewer1.ReportSource = rep;

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        #region Eventos

        private void rdbDataUltimaUtilizacao_CheckedChanged(object sender, EventArgs e)
        {
            this.grbDataUltimaUtilizacao.Enabled = this.rdbDataUltimaUtilizacao.Checked;

        }

        private void chkDataInicial_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDataInicial.Enabled = this.chkDataInicial.Checked;
        }

        private void chkDataFinal_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDataFinal.Enabled = this.chkDataFinal.Checked;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.GerarRelatorio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbLista_CheckedChanged(object sender, EventArgs e)
        {
            chkIncluirColunaLocalizacao.Enabled = rdbLista.Checked;
            if (!this.chkIncluirColunaLocalizacao.Enabled)
            {
                this.chkIncluirColunaLocalizacao.Checked = false;
            }

            chkSepararMateriais.Enabled = rdbLista.Checked;
            if (!this.chkSepararMateriais.Enabled)
            {
                this.chkSepararMateriais.Checked = false;
            }



        }

        #endregion
    }
}
