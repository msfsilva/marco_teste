using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadCompradorForm : IWTForm
    {
        public CadCompradorForm(CompradorClass comprador, CadCompradorListForm listForm)
            : base(comprador, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.loadComboUsuario();

            if (comprador != null)
            {
                this.cmbUsuario.SelectedValue = ((CompradorClass)this.Entity).AcsUsuario.ID;
            }
        }


        public CadCompradorForm(CompradorClass comprador)
            : base(comprador, typeof(CompradorClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            this.loadComboUsuario();

            if (comprador!=null)
            {
                this.cmbUsuario.SelectedValue = ((CompradorClass) this.Entity).AcsUsuario.ID;
            }
        }

        private void loadComboUsuario()
        {


            try
            {
                string sql = "SELECT  " +
                                   "  public.acs_usuario.id_acs_usuario, " +
                                   "  public.acs_usuario.aus_login, " +
                                   "  public.acs_usuario.aus_name " +
                                   "FROM " +
                                   "  public.acs_usuario " +
                                   "ORDER BY " +
                                   "  public.acs_usuario.aus_login ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.SingleConnection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource {DataSource = ds.Tables[0]};
                this.cmbUsuario.DataSource = binding;
                this.cmbUsuario.ValueMember = "id_acs_usuario";
                this.cmbUsuario.DisplayMember = "aus_login";
                this.cmbUsuario.autoSize = true;
                this.cmbUsuario.Table = ds.Tables[0];
                this.cmbUsuario.ColumnsToDisplay = new string[] {"aus_login", "aus_name"};
                this.cmbUsuario.HeadersToDisplay = new string[] {"Login", "Nome"};

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do usuário.\r\n" + e.Message);
            }



        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbUsuario.SelectedValue!=null)
                {
                    ((CompradorClass) this.Entity).AcsUsuario = AcsUsuarioClass.GetEntidade((int) this.cmbUsuario.SelectedValue, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
