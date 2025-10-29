using BibliotecaEntidades.Entidades;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFamiliaRecursoForm : IWTForm
    {
        public CadFamiliaRecursoForm(FamiliaRecursoClass familia, CadFamiliaRecursoListForm listForm)
            : base(familia, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }
    }
}
