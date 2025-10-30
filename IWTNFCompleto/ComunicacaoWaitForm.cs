using System.Windows.Forms;

namespace IWTNFCompleto
{
    public partial class ComunicacaoWaitForm : Form
    {
        private delegate void FechaTelaThreadSafeDelegate();
        private delegate void MudaMensagemThreadSafeDelegate(string novaMensagem);

        public ComunicacaoWaitForm()
        {
            InitializeComponent();
        }


        public void Fechar()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new FechaTelaThreadSafeDelegate(Fechar), new object[] { });
            }
            else
            {
                this.Close();
            }
        }

        public void MudaMensagem(string mensagemNova)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MudaMensagemThreadSafeDelegate(MudaMensagem), new object[] { mensagemNova });
            }
            else
            {
                this.label1.Text = mensagemNova;
            }
        }
    }


}
