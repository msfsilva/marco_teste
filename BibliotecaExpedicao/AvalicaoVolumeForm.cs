using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaExpedicao
{
    public partial class AvalicaoVolumeForm : IWTBaseForm
    {
        public AvalicaoVolumeForm()
        {
            InitializeComponent();

#if DEBUG
            this.txtBarcode.DebugMode = true;
#endif
        }

        private void CarregaDadosPedido(string barcode)
        {
           try
            {
               if (string.IsNullOrWhiteSpace(barcode))return;

                OrderItemEtiquetaClass pedidoConfigurado = OrderItemEtiquetaClass.CarregarPorBarcode(barcode, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                if (pedidoConfigurado == null)
                {
                    throw new Exception("Pedido não encontrado para o código de baras: " + barcode);
                }

                lblPedido.Text = pedidoConfigurado.OrderNumber + "/" + pedidoConfigurado.OrderPos;
                lblProduto.Text = pedidoConfigurado.CodigoItem;


                double? altura = pedidoConfigurado.Altura;
                double? largura = pedidoConfigurado.Largura;
                double? comprimento = pedidoConfigurado.Comprimento;


                double cubagemM3 = 0;

                if (altura.HasValue && largura.HasValue && comprimento.HasValue)
                {
                    cubagemM3 = (altura.Value*largura.Value*comprimento.Value);
                }

                this.lblQuantidade.Text = pedidoConfigurado.Quantidade.ToString("F5", CultureInfo.GetCultureInfo("pt-BR"));
                this.lblSaldo.Text = pedidoConfigurado.SaldoConferencia.ToString("F5", CultureInfo.GetCultureInfo("pt-BR"));

                this.lblVolumeTotal.Text = (pedidoConfigurado.Quantidade * cubagemM3).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " M³";
                this.lblVolumeSaldo.Text = (pedidoConfigurado.SaldoConferencia * cubagemM3).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " M³"; ;



            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar os dados do pedido.\r\n" + e.Message, e);
            }
        }


        #region Eventos
        private void txtBarcode_OperacaoBarcodeEncerrada(object sender, string valor)
        {
            try
            {
                this.CarregaDadosPedido(valor.Trim());
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


 

    }
}
