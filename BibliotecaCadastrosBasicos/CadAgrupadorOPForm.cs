using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAgrupadorOPForm : IWTForm
    {
        public CadAgrupadorOPForm(AgrupadorOpClass agrupadorOp, CadAgrupadorOPListForm listForm)
            : base(agrupadorOp, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


        public CadAgrupadorOPForm(AgrupadorOpClass agrupadorOp):base(agrupadorOp, typeof(AgrupadorOpClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }


    }
}
