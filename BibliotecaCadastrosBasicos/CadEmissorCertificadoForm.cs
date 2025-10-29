using BibliotecaEntidades.Entidades;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEmissorCertificadoForm : IWTForm
    {
        public CadEmissorCertificadoForm(EmissorCertificadoClass emissores, CadEmissorCertificadoListForm listForm)
            : base(emissores, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }
    }
}
