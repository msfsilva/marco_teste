using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadTipoNotificacaoDesvioForm : IWTForm
    {
        public CadTipoNotificacaoDesvioForm(TipoNotificacaoDesvioClass tipoNotificacaoDesvio, CadTipoNotificacaoDesvioListForm listForm)
            : base(tipoNotificacaoDesvio, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


        public CadTipoNotificacaoDesvioForm(TipoNotificacaoDesvioClass tipoNotificacaoDesvio)
            : base(tipoNotificacaoDesvio, typeof(TipoNotificacaoDesvioClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }
    }
}
