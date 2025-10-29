using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFamiliaDocumentoForm : IWTForm
    {
        public CadFamiliaDocumentoForm(FamiliaDocumentoClass familia, CadFamiliaDocumentoListForm listForm)
            : base(familia, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadFamiliaDocumentoForm(FamiliaDocumentoClass familia):base(familia, typeof(FamiliaDocumentoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }
    }
}
