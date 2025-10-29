using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAcabamentoForm : IWTForm
    {
        public CadAcabamentoForm(AcabamentoClass acabamento, CadAcabamentoListForm listForm)
            : base(acabamento, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadAcabamentoForm(AcabamentoClass acabamento):base(acabamento, typeof(AcabamentoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }


    }
}
