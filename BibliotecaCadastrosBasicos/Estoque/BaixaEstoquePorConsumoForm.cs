using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.TelasAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos.Estoque
{
    public partial class BaixaEstoquePorConsumoForm : IWTBaseForm
    {
        public BaixaEstoquePorConsumoForm()
        {
            InitializeComponent();

            this.ensCorredor.forceDisable();
            this.ensPrateleira.forceDisable();
            this.ensGaveta.forceDisable();

            this.ensEstoque.FormSelecao = new CadEstoqueListForm(true);
 
        }

        private void SelecionarEstoque()
        {
            try
            {
                if (this.ensEstoque.EntidadeSelecionada != null)
                {
                    this.ensCorredor.removeForceDisable();
                    this.ensCorredor.EntidadeSelecionada = null;
                    this.ensCorredor.FormSelecao = new CadEstoqueCorredorListForm(true, (EstoqueClass) this.ensEstoque.EntidadeSelecionada);
                }
                else
                {
                    this.ensCorredor.EntidadeSelecionada = null;
                    this.ensCorredor.FormSelecao = null;
                    this.ensCorredor.forceDisable();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Selecionar o estoque.\r\n" + e.Message, e);
            }

        }

        private void SelecionarCorredor()
        {
            try
            {
                if (this.ensCorredor.Enabled && this.ensCorredor.EntidadeSelecionada != null)
                {
                    this.ensPrateleira.removeForceDisable();
                    this.ensPrateleira.EntidadeSelecionada = null;
                    this.ensPrateleira.FormSelecao = new CadEstoquePrateleiraListForm(true, (EstoqueCorredorClass) this.ensCorredor.EntidadeSelecionada);
                }
                else
                {
                    this.ensPrateleira.EntidadeSelecionada = null;
                    this.ensPrateleira.FormSelecao = null;
                    this.ensPrateleira.forceDisable();
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Selecionar o corredor.\r\n" + e.Message, e);
            }
        }

        private void SelecionarPrateleira()
        {
            try
            {
                if (this.ensPrateleira.Enabled && this.ensPrateleira.EntidadeSelecionada != null)
                {
                    this.ensGaveta.removeForceDisable();
                    this.ensGaveta.EntidadeSelecionada = null;
                    this.ensGaveta.FormSelecao = new CadEstoqueGavetaListForm((EstoquePrateleiraClass)this.ensPrateleira.EntidadeSelecionada);
                }
                else
                {
                    this.ensGaveta.EntidadeSelecionada = null;
                    this.ensGaveta.FormSelecao = null;
                    this.ensGaveta.forceDisable();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Selecionar a prateleira.\r\n" + e.Message, e);
            }
        }

        private void Baixar()
        {
            try
            {
                if (this.ensEstoque.EntidadeSelecionada == null)
                {
                    throw new ExcecaoTratada("Ao menos o almoxarifado deve ser selecionado");
                }

                if (DialogResult.Yes != MessageBox.Show(this, "Essa operação irá realizar a baixa de todos os itens contidos no Almoxarifado, Corredor, Prateleira ou Gaveta selecionado. Irá ser gerado um relatório a ser enviado para contablidade. A operação NÃO poderá ser desfeita. Deseja Continuar?", "Baixa de estoque por Consumo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                List<EstoqueGavetaItemClass> gavetasItemBaixar = new List<EstoqueGavetaItemClass>();

                if (ensGaveta.Enabled)
                {
                    if (ensGaveta.EntidadeSelecionada == null)
                    {
                        throw new ExcecaoTratada("Selecione a gaveta ou desabilite o campo");
                    }
                    gavetasItemBaixar.AddRange(((EstoqueGavetaClass) ensGaveta.EntidadeSelecionada).CollectionEstoqueGavetaItemClassEstoqueGaveta.Where(a => a.Ativo && a.Quantidade > 0));
                }
                else
                {
                    if (ensPrateleira.Enabled)
                    {
                        if (ensPrateleira.EntidadeSelecionada == null)
                        {
                            throw new ExcecaoTratada("Selecione a prateleira ou desabilite o campo");
                        }
                        EstoquePrateleiraClass prateleira = (EstoquePrateleiraClass) ensPrateleira.EntidadeSelecionada;
                        foreach (EstoqueGavetaClass gaveta in prateleira.CollectionEstoqueGavetaClassEstoquePrateleira)
                        {
                            gavetasItemBaixar.AddRange(gaveta.CollectionEstoqueGavetaItemClassEstoqueGaveta.Where(a => a.Ativo && a.Quantidade > 0));
                        }
                    }
                    else
                    {
                        if (ensCorredor.Enabled)
                        {
                            if (ensCorredor.EntidadeSelecionada == null)
                            {
                                throw new ExcecaoTratada("Selecione o Corredor ou desabilite o campo de seleção");
                            }
                            EstoqueCorredorClass corredor = (EstoqueCorredorClass) ensCorredor.EntidadeSelecionada;

                            foreach (EstoquePrateleiraClass prateleira in corredor.CollectionEstoquePrateleiraClassEstoqueCorredor)
                            {
                                foreach (EstoqueGavetaClass gaveta in prateleira.CollectionEstoqueGavetaClassEstoquePrateleira)
                                {
                                    gavetasItemBaixar.AddRange(gaveta.CollectionEstoqueGavetaItemClassEstoqueGaveta.Where(a => a.Ativo && a.Quantidade > 0));
                                }
                            }

                        }
                        else
                        {

                            EstoqueClass estoque = (EstoqueClass) this.ensEstoque.EntidadeSelecionada;
                            foreach (EstoqueCorredorClass corredor in estoque.CollectionEstoqueCorredorClassEstoque)
                            {
                                foreach (EstoquePrateleiraClass prateleira in corredor.CollectionEstoquePrateleiraClassEstoqueCorredor)
                                {
                                    foreach (EstoqueGavetaClass gaveta in prateleira.CollectionEstoqueGavetaClassEstoquePrateleira)
                                    {
                                        gavetasItemBaixar.AddRange(gaveta.CollectionEstoqueGavetaItemClassEstoqueGaveta.Where(a => a.Ativo && a.Quantidade > 0));
                                    }
                                }
                            }
                        }
                    }
                }




                List<BaixaEstoqueConsumoReportClass> ds = gavetasItemBaixar.ConvertAll(a => new BaixaEstoqueConsumoReportClass(a, a.Quantidade));
                

                BaixaEstoqueConsumoReport rep = new BaixaEstoqueConsumoReport();
                rep.SetDataSource(ds);

                ViewReportPadraoForm form = new ViewReportPadraoForm("Baixa de Estoque Por Consumo",rep);
                form.ShowDialog(this);

                IWTPostgreNpgsqlCommand command = null;
                try
                {
                    command = SingleConnection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    foreach (EstoqueGavetaItemClass gavetaItem in gavetasItemBaixar)
                    {
                        EstoqueMovimentacao.LancaBaixaTotalGavetaItem(
                            gavetaItem,
                            "Baixa de Estoque Por Consumo (Sistema)",
                            "Baixa de Estoque Por Consumo",
                            LoginClass.UsuarioLogado.loggedUser,
                            true,
                            ref command
                            );
                    }


                    command.Transaction.Commit();
                }
                catch (Exception e)
                {
                    if (command != null && command.Transaction != null && command.Transaction.IsActive)
                    {
                        command.Transaction.Rollback();
                    }
                    throw;
                }


                MessageBox.Show(this, "Operação concluída com sucesso!", "Baixa de Estoque por Consumo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao realizar a baixa de estoque por consumo.\r\n" + e.Message, e);
            }
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void ensEstoque_EntityChange(object sender, EventArgs e)
        {
             try
             {
                 this.SelecionarEstoque();
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
                 this.SelecionarCorredor();
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
                 this.SelecionarPrateleira();

             }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ensCorredor_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelecionarCorredor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ensPrateleira_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                this.SelecionarPrateleira();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRealizarBaixa_Click(object sender, EventArgs e)
        {
             try
             {
                 Baixar();
             }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion



    }
}
