using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.ClassesAuxiliares;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoSimplificadoItemForm : IWTBaseForm
    {
        public PedidoLinhaTelaClass LinhaPedido { get; private set; }

        bool codigoAutomatico = true;
        bool descricaoAutomatica = true;
        private bool precoAutomatico = true;

        bool loading = false;

        public bool OkClicked { get; private set; }

        public DateTime dataEntTmp;
        private readonly bool _somenteLeitura;

        public CadPedidoSimplificadoItemForm(PedidoLinhaTelaClass linhaPedido,   DateTime dataEntregaTmp, bool somenteLeitura)
        {
            this.dataEntTmp = dataEntregaTmp;
            _somenteLeitura = somenteLeitura;

            InitializeComponent();

            this.ensProduto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, filtroSomenteVenda: true, somenteAtivos: true);
            this.ensNCM.FormSelecao = new CadNcmListForm(TipoModulo.Tipo);

            if (linhaPedido != null)
            {
                this.LinhaPedido = linhaPedido;
                this.Edit();
            }
            else
            {
                this.LinhaPedido = new PedidoLinhaTelaClass();
                this.dtpDataEntregaLinha.Value = this.dataEntTmp;
            }
        }
        
        private void Edit()
        {
            this.loading = true;
            this.ensProduto.EntidadeSelecionada = this.LinhaPedido.Produto;
            this.txtCodigo.Text = this.LinhaPedido.CodProdutoCliente;
            this.txtDescricao.Text = this.LinhaPedido.Descricao;
            this.nudQtd.Value = (decimal)this.LinhaPedido.Qtd;
            this.nudValorUnit.Value = (decimal)this.LinhaPedido.ValorUnitario;
            this.ensNCM.Enabled = this.LinhaPedido.Ncm != null;
            this.ensNCM.EntidadeSelecionada = this.LinhaPedido.Ncm;
            this.chkEntregaParc.Checked = this.LinhaPedido.EntregaParcial;
            this.cbxVolumeUnico.Checked = this.LinhaPedido.VolumeUnico;
            this.chkExportacao.Checked = this.LinhaPedido.Exportacao;
            this.chkRastrearMP.Checked = this.LinhaPedido.RastrearMp;
            this.txtInfoEspeciais.Text = this.LinhaPedido.InformacoesEspeciais;
            this.dtpDataEntregaLinha.Value = this.LinhaPedido.DataEntrega;

            this.codigoAutomatico = false;
            this.descricaoAutomatica = false;
            this.precoAutomatico = false;
       
            this.loading = false;
        }
 
        private void updateNCM()
        {
            if (!loading)
            {
                if (this.ensProduto.EntidadeSelecionada != null && ((ProdutoClass)this.ensProduto.EntidadeSelecionada).CollectionProdutoFiscalClassProduto.Count > 0 && ((ProdutoClass)this.ensProduto.EntidadeSelecionada).CollectionProdutoFiscalClassProduto[0].Ncm!=null)
                {
                    ensNCM.EntidadeSelecionada= ((ProdutoClass) this.ensProduto.EntidadeSelecionada).CollectionProdutoFiscalClassProduto[0].Ncm;
                }
                else
                {
                    ensNCM.EntidadeSelecionada = null;
                }
            }

        }

        private void updateTotalItem()
        {
            lblTotal.Text = "Total: R$ " + (nudQtd.Value * nudValorUnit.Value).ToString("F2", CultureInfo.CurrentCulture);
        }

        private void Confirmar()
        {
            try
            {
                if (this.txtDescricao.Enabled && this.txtDescricao.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Descrição é obrigatório.");
                }

                if (this.txtCodigo.Enabled && this.txtCodigo.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Código é obrigatório.");
                }

                if (this.ensNCM.Enabled && ensNCM.EntidadeSelecionada == null)
                {
                    throw new Exception("Campo NCM é obrigatório.");
                }

                if (this.ensProduto.EntidadeSelecionada == null)
                {
                    throw new Exception("Campo Produto é obrigatório.");
                }

                if ((double)this.nudQtd.Value * (double)this.nudValorUnit.Value<0.01)
                {
                    throw new Exception("O valor total da linha do pedido deve ser maior do que zero.");  
                }

                this.LinhaPedido.Produto = (ProdutoClass) this.ensProduto.EntidadeSelecionada;
                this.LinhaPedido.CodProduto = this.LinhaPedido.Produto.Codigo;
                this.LinhaPedido.CodProdutoCliente = !string.IsNullOrWhiteSpace(this.LinhaPedido.Produto.CodigoCliente) ? this.LinhaPedido.Produto.CodigoCliente : this.LinhaPedido.Produto.Codigo;
                this.LinhaPedido.Descricao = this.txtDescricao.Text;
                this.LinhaPedido.Qtd = (double)this.nudQtd.Value;
                this.LinhaPedido.ValorUnitario = (double)this.nudValorUnit.Value;
                
                if (this.ensNCM.Enabled)
                {
                    this.LinhaPedido.Ncm = (NcmClass) this.ensNCM.EntidadeSelecionada;
                }
                else
                {
                    this.LinhaPedido.Ncm = null;
                }

                this.LinhaPedido.EntregaParcial = this.chkEntregaParc.Checked;
                this.LinhaPedido.VolumeUnico = this.cbxVolumeUnico.Checked;
                this.LinhaPedido.Exportacao = this.chkExportacao.Checked;
                this.LinhaPedido.RastrearMp = this.chkRastrearMP.Checked;
                this.LinhaPedido.InformacoesEspeciais = this.txtInfoEspeciais.Text;
                this.LinhaPedido.DataEntrega = this.dtpDataEntregaLinha.Value;
             
                this.OkClicked = true;

                this.dataEntTmp = this.dtpDataEntregaLinha.Value;

                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao confirmar a operação\r\n" + e.Message, e);
            }
        }

         private void detalhesItem()
        {
            try
            {
                if (this.ensProduto.EntidadeSelecionada!=null)
                {

                    CadProdutoForm form = new CadProdutoForm((ProdutoClass) this.ensProduto.EntidadeSelecionada, TipoModulo.Tipo)
                                              {
                                                  SomenteLeitura = true
                                              };
                    form.Show();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir os detalhes do produto.\r\n" + e.Message, e);
            }
        }
   
    
        
        #region Eventos


        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            codigoAutomatico = false;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            descricaoAutomatica = false;
        }

        private void nudQtd_ValueChanged(object sender, EventArgs e)
        {
            this.updateTotalItem();
        }



        private void nudValorUnit_ValueChanged(object sender, EventArgs e)
        {
            this.updateTotalItem();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Confirmar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.OkClicked = false;
            this.Close();
        }
     
        private void lnkDetalhesPrincipal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.detalhesItem();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void ensProduto_EntityChange(object sender, EventArgs e)
        {
            try
            {
                this.updateNCM();
                if (this.codigoAutomatico)
                {
                    if (this.ensProduto.EntidadeSelecionada != null)
                    {
                        this.txtCodigo.Text = ((ProdutoClass) this.ensProduto.EntidadeSelecionada).Codigo;
                    }
                    else
                    {
                        this.txtCodigo.Clear();

                    }
                }

                if (this.descricaoAutomatica)
                {
                    if (this.ensProduto.EntidadeSelecionada != null)
                    {
                        this.txtDescricao.Text = ((ProdutoClass) this.ensProduto.EntidadeSelecionada).Descricao;
                    }
                    else
                    {
                         this.txtDescricao.Clear();
                    }
                }


                if (precoAutomatico)
                {
                    if (this.ensProduto.EntidadeSelecionada != null)
                    {
                        if (((ProdutoClass) this.ensProduto.EntidadeSelecionada).CalculoPreco_Fixo)
                        {
                            List<ProdutoPrecoClass> precos = ((ProdutoClass) this.ensProduto.EntidadeSelecionada).CollectionProdutoPrecoClassProduto.Where(
                                a => Configurations.DataIndependenteClass.GetData().Date >= a.InicioVigencia.Date && (!a.FimVigencia.HasValue || Configurations.DataIndependenteClass.GetData().Date <= a.FimVigencia.Value.Date)).ToList();
                            ProdutoPrecoClass preco = null;
                            if (precos.Count == 1)
                            {
                                preco = precos[0];
                            }

                            if (precos.Count > 1)
                            {
                                preco = precos.OrderByDescending(a => a.ID).First();
                            }



                            if (preco != null)
                            {
                                this.nudValorUnit.Value = (decimal) preco.Preco;
                            }
                            else
                            {
                                this.nudValorUnit.Value = 0;
                            }
                        }
                    }
                    else
                    {
                        this.nudValorUnit.Value = 0; 
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudValorUnit_Click(object sender, EventArgs e)
        {
            this.precoAutomatico = false;
        }

        private void nudValorUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.precoAutomatico = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (IWTLicensing.ControleLicenciamentoClass.Licenca != null && IWTLicensing.ControleLicenciamentoClass.Licenca.TipoLicenca != "COMPLETO")
            {
                this.chkEntregaParc.Checked = false;
                this.chkEntregaParc.Visible = false;

                this.chkRastrearMP.Checked = false;
                this.chkRastrearMP.Visible = false;

                this.cbxVolumeUnico.Checked = false;
                this.cbxVolumeUnico.Visible = false;
            }


            if (_somenteLeitura)
            {
                this.ensProduto.forceDisable();
                this.txtCodigo.Enabled = false;
                this.txtDescricao.Enabled = false;
                this.nudQtd.Enabled = false;
                this.nudValorUnit.Value = (decimal)this.LinhaPedido.ValorUnitario;
                this.ensNCM.Enabled = this.LinhaPedido.Ncm != null;
                this.ensNCM.EntidadeSelecionada = this.LinhaPedido.Ncm;
                this.chkEntregaParc.Enabled = false;
                this.cbxVolumeUnico.Enabled = false;
                this.chkExportacao.Enabled = false;
                this.chkRastrearMP.Enabled = false;
                this.txtInfoEspeciais.Enabled = false;
                this.dtpDataEntregaLinha.Enabled = false;


            }
        }

        #endregion




    }
}
