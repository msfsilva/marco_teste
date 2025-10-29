using System;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEmbalagensForm : IWTForm
    {
        public CadEmbalagensForm(EmbalagemClass embalagem, CadEmbalagensListForm listForm)
            : base(embalagem, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


         public CadEmbalagensForm(EmbalagemClass embalagem)
             : base(embalagem, typeof(EmbalagemClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }

         private void rdbLarguraVar_CheckedChanged(object sender, EventArgs e)
         {
             this.nuLargura.Enabled = !this.rdbLarguraVar.Checked;
         }

         private void rdbAlturaVar_CheckedChanged(object sender, EventArgs e)
         {
             this.nudAltura.Enabled = !this.rdbAlturaVar.Checked;
         }

         private void rdbComprimentoVar_CheckedChanged(object sender, EventArgs e)
         {
             this.nudComprimento.Enabled = !this.rdbComprimentoVar.Checked;
         }

         private void rdbNenhumaVar_CheckedChanged(object sender, EventArgs e)
         {
             this.nuLargura.Enabled = true;
             this.nudAltura.Enabled = true;
             this.nudComprimento.Enabled = true;

         }
        
    }
}
