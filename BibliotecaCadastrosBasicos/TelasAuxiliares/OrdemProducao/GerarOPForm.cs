#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;
using OrdemProducaoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoClass;

#endregion

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class GerarOPForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        readonly int diasArmazenarOp;
        readonly string ImpressoraOP;
        private readonly bool UtilizarEstoqueOP;
        IOrdemProducaoFactory iOrdemProducaoFactory;
        private ICarregarDocumentosImpressaoOp _carregarDocumentosImpressaoOp;

        public GerarOPForm(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory, ICarregarDocumentosImpressaoOp carregarDocumentosImpressaoOp = null)
        {
            InitializeComponent();
            this.conn = conn;
            this.Usuario = Usuario;
            this.tipoCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO);
            this.diaCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA);
            this.diasArmazenarOp = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.PRAZO_ARMAZENAMENTO_OP));
            this.ImpressoraOP = IWTConfiguration.Conf.getConf(Constants.IMPRESSORA_OP);
            this.UtilizarEstoqueOP = IWTConfiguration.Conf.getBoolConf(Constants.UTILIZA_ESTOQUE_OP);
            this.iOrdemProducaoFactory = iOrdemProducaoFactory;
            _carregarDocumentosImpressaoOp = carregarDocumentosImpressaoOp;


            this.ensProduto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, somenteAtivos: true);
        }

        private void gerar()
        {
            try
            {
                List<int> idsOrderItemEtiquetaPlanoCorteAvulsos = null;
                List<OrdemProducaoOc> ocsSemProduto;
                List<OrdemProducaoClass> OPs;
                OrdemProducaoGeradorClass gerador = new OrdemProducaoGeradorClass(this.Usuario, this.conn, this.tipoCalculoSemana, this.diaCalculoSemana, this.UtilizarEstoqueOP, iOrdemProducaoFactory);

                List<OrdemProducaoOc> listOcs = new List<OrdemProducaoOc>();

                TipoItemSelecao tipoItem = TipoItemSelecao.Todos;
                if (rdbKits.Checked)
                {
                    tipoItem = TipoItemSelecao.SomenteKit;
                }

                if (rdbNaoKits.Checked)
                {
                    tipoItem = TipoItemSelecao.SomenteNaoKit;
                }


                if (rdbPps.Checked)
                {
                    
                    listOcs = gerador.listarOcsParaGeracao(this.txtPps.Text,tipoItem,out idsOrderItemEtiquetaPlanoCorteAvulsos);
                    //OPs = gerador.gerarOps(this.txtPps.Text, out ocsSemProduto);
                }

                if (rdbData.Checked)
                {
                    listOcs = gerador.listarOcsParaGeracao(this.dtpData.Value, tipoItem, null, null, null,null, out idsOrderItemEtiquetaPlanoCorteAvulsos);
                    //OPs = gerador.gerarOps(this.dtpData.Value, out ocsSemProduto);
                }

                if (rdbTodosPedidos.Checked)
                {
                    listOcs = gerador.listarOcsParaGeracao((DateTime?)null, tipoItem, null, null, null, null, out idsOrderItemEtiquetaPlanoCorteAvulsos);
                }


                if (rdbProduto.Checked)
                {
                    if (this.ensProduto.EntidadeSelecionada==null)
                    {
                        throw new ExcecaoTratada("Selecione um produto ou troque o tipo de seleção.");
                    }

                    listOcs = gerador.listarOcsParaGeracao((DateTime?) null, tipoItem, null, null, null, (ProdutoClass) this.ensProduto.EntidadeSelecionada, out idsOrderItemEtiquetaPlanoCorteAvulsos);
                }



                if (rdbOcPos.Checked)
                {
                    if (!string.IsNullOrWhiteSpace(this.txtOc.Text))
                    {
                        string pedido = this.txtOc.Text.Trim();
                        int? pos = null;
                        if (!string.IsNullOrWhiteSpace(this.txtPos.Text))
                        {
                            pos = int.Parse(this.txtPos.Text.Trim());
                        }
                        //listOcs.Add(new OrdemProducaoOc() { oc = this.txtOc.Text.Trim(), pos = this.txtPos.Text.Trim() });
                        listOcs = gerador.listarOcsParaGeracao(null, tipoItem, pedido, pos, null,null, out idsOrderItemEtiquetaPlanoCorteAvulsos);
                    }
                    else
                    {
                        throw new Exception("OC e posição são obrigatórios para a opção selecionada.");
                    }
                }


                SelecaoOCsForm form1 = new SelecaoOCsForm(listOcs, tipoItem);
                form1.ShowDialog();

                if (form1.okPressed)
                {
                    string erroGeral;

                    listOcs = form1.OcsSelecionadas;

                    OPs = gerador.gerarOps(listOcs,idsOrderItemEtiquetaPlanoCorteAvulsos, out ocsSemProduto, out erroGeral);


                    if (IWTConfiguration.Conf.getBoolConf(Constants.SUPRIMIR_IMPRESSAO_OP_KB_ZERADA))
                    {
                        foreach (OrdemProducaoClass op in OPs.Where(a=>a.Quantidade==0 && a.ProdutoK!=null))
                        {
                            op.Encerrar(LoginClass.UsuarioLogado.loggedUser, false, false);
                        }
                    }


                    if (OPs.Count > 0)
                    {
                        OpReportForm form;
                        List<string> recursosImprimir = new List<string>();
                        if (MessageBox.Show(this, "Você deseja imprimir as ops geradas agora?\r\nSim: Imprime as Ordens\r\nNão: Somente Visualização em tela", "Impressão de OP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (OrdemProducaoClass OP in OPs)
                            {
                                OP.setImpressao(this.Usuario);
                                OP.Save();

                                recursosImprimir.AddRange(OP.Recursos.Where(a => a.recursoTipo == TipoRecurso.Formulario).Select(recurso => recurso.recursoCaminhoArquivo));
                            }


                            List<OrdemProducaoClass> opsImprimir = OPs;
                            //IMprime somente as que não são KB ou que são kb e tem qtd maior que zero

                            if (IWTConfiguration.Conf.getBoolConf(Constants.SUPRIMIR_IMPRESSAO_OP_KB_ZERADA))
                            {
                                opsImprimir = new List<OrdemProducaoClass>(OPs.Where(a => (a.Quantidade != 0 && a.ProdutoK!=null) || a.ProdutoK == null));
                            }

                            form = new OpReportForm(opsImprimir, true, this.Usuario, this.conn, _carregarDocumentosImpressaoOp);

                        }
                        else
                        {

                            form = new OpReportForm(OPs,  false, this.Usuario,this.conn, _carregarDocumentosImpressaoOp);

                        }
                        if (!form.IsDisposed)
                        {
                            form.ShowDialog();
                        }

                        if (recursosImprimir.Count > 0)
                        {
                            MessageBox.Show(this, "As ordens de produção que foram impressas possuem formulários para imprimir, esses arquivos serão abertos agora um a um, imprima e feche o arquivo para abrir o próximo.", "Formulários", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process pr = new Process();
                            foreach (string rec in recursosImprimir)
                            {
                                pr.StartInfo.FileName = rec;
                                pr.Start();
                                pr.WaitForExit();
                            }
                        }


                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Não é possível gerar nenhuma OP para os parâmetros selecionados.");
                    }
                }
                


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar a OP.\r\n" + e.Message);
            }
        }

        #region eventos
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.gerar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbPps_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxData.Enabled = rdbData.Checked;
            this.gbxOcPos.Enabled = rdbOcPos.Checked;
            this.gbxPps.Enabled = rdbPps.Checked;
            this.grbProduto.Enabled = rdbProduto.Checked;
        }

        private void rdbData_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxData.Enabled = rdbData.Checked;
            this.gbxOcPos.Enabled = rdbOcPos.Checked;
            this.gbxPps.Enabled = rdbPps.Checked;
            this.grbProduto.Enabled = rdbProduto.Checked;
        }

        private void rdbOcPos_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxData.Enabled = rdbData.Checked;
            this.gbxOcPos.Enabled = rdbOcPos.Checked;
            this.gbxPps.Enabled = rdbPps.Checked;
            this.grbProduto.Enabled = rdbProduto.Checked;
        }


        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxData.Enabled = rdbData.Checked;
            this.gbxOcPos.Enabled = rdbOcPos.Checked;
            this.gbxPps.Enabled = rdbPps.Checked;
            this.grbProduto.Enabled = rdbProduto.Checked;
        }

        #endregion

    }
}
