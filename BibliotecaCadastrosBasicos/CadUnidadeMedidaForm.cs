using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadUnidadeMedidaForm : IWTForm
    {
        public CadUnidadeMedidaForm(UnidadeMedidaClass unidadeMedida, CadUnidadeMedidaListForm listForm)
            : base(unidadeMedida, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


        public CadUnidadeMedidaForm(UnidadeMedidaClass unidadeMedida)
            : base(unidadeMedida, typeof(UnidadeMedidaClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }

       

    }
}
