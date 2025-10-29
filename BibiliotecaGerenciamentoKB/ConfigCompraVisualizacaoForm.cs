#region Referencias

using IWTDotNetLib;

#endregion

namespace BibiliotecaGerenciamentoKB
{
    public partial class ConfigCompraVisualizacaoForm : IWTBaseForm
    {

        public ConfigCompraVisualizacaoForm(
            int diasVerde,
            int diasAmarelo, int diasVermelho, int mesesMedia,
            double margemAvisoKB
            )
        {
            InitializeComponent();
            this.nudEstoqueDiasVerde.Value = diasVerde;
            this.nudEstoqueDiasAmarelo.Value = diasAmarelo;
            this.nudEstoqueDiasVermelho.Value = diasVermelho;
            this.nudEstoqueMeses.Value = mesesMedia;
            this.nudEstoqueMargemRevisaoKb.Value = (decimal)margemAvisoKB;
        }
    }
}
