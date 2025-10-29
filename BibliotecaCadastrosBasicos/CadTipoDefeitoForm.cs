using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadTipoDefeitoForm : IWTForm
    {
      public CadTipoDefeitoForm(TipoDefeitoClass tipoDefeito, CadTipoDefeitoListForm listForm)
            : base(tipoDefeito, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadTipoDefeitoForm(TipoDefeitoClass tipoDefeito):base(tipoDefeito, typeof(TipoDefeitoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }
    }
}
