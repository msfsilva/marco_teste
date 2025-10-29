using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCompras
{
    public partial class RecebimentoAprovacaoDivergencia : IWTBaseForm
    {
        private readonly string _divergenciaPreco;
        private readonly string _divergenciaIcms;
        private readonly string _divergenciaIpi;

        public bool Aprovado { get; set; } = false;
        public AcsUsuarioClass UsuarioAprovador { get; set; } = null;


        public RecebimentoAprovacaoDivergencia(string divergenciaPreco, string divergenciaIcms, string divergenciaIpi)
        {
            _divergenciaPreco = divergenciaPreco;
            _divergenciaIcms = divergenciaIcms;
            _divergenciaIpi = divergenciaIpi;
            InitializeComponent();

            lblDivergerncias.Text =
                _divergenciaPreco + Environment.NewLine +
                _divergenciaIcms + Environment.NewLine +
                _divergenciaIpi + Environment.NewLine;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            UsuarioAprovador = null;
            Aprovado = false;

            Close();
        }

        private void btnAprovarDivergencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginClass.UsuarioLogado.HasAccess(ProjectConstants.Constants.APROVACAO_DIVERGENCIA_RECEBIMENTO, AcsTipoAcesso.Escrita))
                {
                    UsuarioAprovador = LoginClass.UsuarioLogado.loggedUser;
                    Aprovado = true;
                    Close();
                }
                else
                {
                    LoginForm form = new LoginForm(null, SingleConnection, definirUsuarioLogado:false);
                    form.Titulo = "Usuário Aprovador";
                    form.ShowDialog(this);

                    LoginClass usuarioTmp = form.loginResult;
                    if (usuarioTmp == null)
                    {
                        throw new ExcecaoTratada("O usuário aprovador não completou a autenticação.");
                    }

                    if (usuarioTmp.HasAccess(ProjectConstants.Constants.APROVACAO_DIVERGENCIA_RECEBIMENTO, AcsTipoAcesso.Escrita))
                    {
                        UsuarioAprovador = usuarioTmp.loggedUser;
                        Aprovado = true;
                        Close();
                    }
                    else
                    {
                        throw new ExcecaoTratada("O usuário "+usuarioTmp.loggedUser.Name+" não possui a permissão necessária para efetuar a aprovação");
                    }
                }
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
