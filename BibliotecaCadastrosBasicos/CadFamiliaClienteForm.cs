using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFamiliaClienteForm : IWTForm
    {
        public CadFamiliaClienteForm(FamiliaClienteClass familiaCliente, CadFamiliaClienteListForm listForm)
            : base(familiaCliente, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadFamiliaClienteForm(FamiliaClienteClass familiaCliente):base(familiaCliente, typeof(FamiliaClienteClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }
    }
}
