using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadLocalFabricacaoForm : IWTForm
    {
       public CadLocalFabricacaoForm(LocalFabricacaoClass localFabricacao, CadLocalFabricacaoListForm listForm)
            : base(localFabricacao, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


       public CadLocalFabricacaoForm(LocalFabricacaoClass localFabricacao)
           : base(localFabricacao, typeof(LocalFabricacaoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }
    }
}
