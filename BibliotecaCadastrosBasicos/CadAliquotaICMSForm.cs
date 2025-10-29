using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAliquotaICMSForm : IWTForm
    {
       public CadAliquotaICMSForm(ModeloFiscalIcmsEstadoClass modeloFiscalIcmsEstado, CadAliquotaICMSListForm listForm)
            : base(modeloFiscalIcmsEstado, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadAliquotaICMSForm(ModeloFiscalIcmsEstadoClass modeloFiscalIcmsEstado):base(modeloFiscalIcmsEstado, typeof(ModeloFiscalIcmsEstadoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }
    }
}
