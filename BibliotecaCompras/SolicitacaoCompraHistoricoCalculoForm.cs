using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaCompras
{
    public partial class SolicitacaoCompraHistoricoCalculoForm : IWTBaseForm{

        public SolicitacaoCompraHistoricoCalculoForm(string historicoCalculo)
        {
            InitializeComponent();

            this.txtHistoricoCalculo.Text = historicoCalculo;
        }
    }
}
