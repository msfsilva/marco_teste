using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAplicacaoClienteForm : IWTForm
    {
        public CadAplicacaoClienteForm(AplicacaoClienteClass aplicacao, CadAplicacaoClienteListForm listForm)
            : base(aplicacao, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadAplicacaoClienteForm(AplicacaoClienteClass aplicacao):base(aplicacao, typeof(AplicacaoClienteClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }


    }

}
