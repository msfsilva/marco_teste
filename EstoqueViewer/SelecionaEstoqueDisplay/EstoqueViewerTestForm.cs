#region Referencias

using System;
using System.Windows.Forms;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace EstoqueViewer
{
    public partial class EstoqueViewerTestForm : Form
    {
        IWTPostgreNpgsqlConnection conn;
        public EstoqueViewerTestForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.selecionaEstoqueDisplay1.Estoque = new EstoqueDesignerClass(11, "Teste", conn);
            this.conn = conn;
           
        }

        private void EstoqueViewerTestForm_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
