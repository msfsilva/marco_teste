using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadClassificacaoServicoForm : IWTForm
    {
    
        public CadClassificacaoServicoForm(ClassificacaoServicoClass classificacaoServico, CadClassificacaoServicoListForm listForm)
            : base(classificacaoServico, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


        public CadClassificacaoServicoForm(ClassificacaoServicoClass classificacaoServico)
            : base(classificacaoServico, typeof(ClassificacaoServicoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }
    }
}
