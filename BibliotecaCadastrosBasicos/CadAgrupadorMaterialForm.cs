using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAgrupadorMaterialForm : IWTForm
    {
        public CadAgrupadorMaterialForm(AgrupadorMaterialClass agrupador, CadAgrupadorMaterialListForm listForm)
            : base(agrupador, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadAgrupadorMaterialForm(AgrupadorMaterialClass agrupador):base(agrupador, typeof(AgrupadorMaterialClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
