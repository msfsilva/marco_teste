using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDimensaoForm : IWTForm
    {
        public CadDimensaoForm(DimensaoClass dimensao, CadDimensaoListForm listForm)
            : base(dimensao, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


        public CadDimensaoForm(DimensaoClass dimensao)
            : base(dimensao, typeof(DimensaoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }


    }
}
