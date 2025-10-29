#region Referencias

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.Interfaces;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

#endregion

namespace BibliotecaCentroCusto
{
    public partial class SelecaoCentroCustoLucroForm : IWTBaseForm, ISelectableForm
    {
        readonly CentroCustoLucroNatureza TipoSelecao;
        
        public CentroCustoLucroClass CentroSelecionado { get; private set; }

        public SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza tipoSelecao)
        {

            InitializeComponent();
            this.TipoSelecao = tipoSelecao;

            switch (tipoSelecao)
            {
                case CentroCustoLucroNatureza.Custo:
                    this.Text += "Custo";
                    break;
                case CentroCustoLucroNatureza.Lucro:
                    this.Text += "Lucro";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoSelecao");
            }

            this.loadCentroCustos();

        }

        private void loadCentroCustos()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.centro_custo_lucro.id_centro_custo_lucro " +
                    "FROM " +
                    "  public.centro_custo_lucro " +
                    "WHERE " +
                    "  public.centro_custo_lucro.id_centro_custo_lucro_pai IS NULL AND " +
                    "  (public.centro_custo_lucro.ccl_natureza = :ccl_natureza OR public.centro_custo_lucro.ccl_natureza = -1 ) AND " +
                    "  ccl_ativo = true";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccl_natureza", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoSelecao);
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    this.treeView1.Nodes.Add(new CentroCustoLucroNodeClass(Convert.ToInt32(read["id_centro_custo_lucro"]), this.TipoSelecao,this.SingleConnection));
                }
                read.Close();

                this.treeView1.TreeViewNodeSorter = new CentroCustoLucroNodeSorter();
                this.treeView1.Sort();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Selecionar()
        {
            try
            {
                if (this.treeView1.SelectedNode == null)
                {
                    throw new Exception("Selecione um centro de custo/lucro antes de continuar.");
                }

                if (((CentroCustoLucroNodeClass)treeView1.SelectedNode).Filhos.Count > 0)
                {
                    throw new Exception("Você deve selecionar um centro de custo/lucro que não possua filhos antes de continuar.");
                }

                CentroCustoLucroClass tmp = ((CentroCustoLucroNodeClass) this.treeView1.SelectedNode).CentroCustoLucro;
                if (!tmp.Ativo)
                {
                    throw new Exception("Você deve selecionar um centro de custo/lucro ativo antes de continuar.");
                }

                this.CentroSelecionado = ((CentroCustoLucroNodeClass)this.treeView1.SelectedNode).CentroCustoLucro;
                this.Close(); 

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Selecionar\r\n" + e.Message, e);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Selecionar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public AbstractEntity getItemSelecionado()
        {
            return CentroSelecionado;
        }

        public void setModoSelecao(bool modoSelecao)
        {
            
        }

        public bool getModoSelecao()
        {
            return true;
        }

        public void setFiltroSelecao(string filtroSelecao)
        {
            
        }

        public string getFiltroSelecao()
        {
            return "";
        }

        public void AbrirTelaSelecao(IWin32Window owner)
        {
            this.ShowDialog(owner);
        }

        public List<DataGridViewColumn> getColunasGrid(string modoVisualizacaoGrid)
        {
            List<DataGridViewColumn> toRet = new List<DataGridViewColumn>();


            toRet.Add(new DataGridViewTextBoxColumn());
            toRet[toRet.Count - 1].DataPropertyName = "Codigo";
            toRet[toRet.Count - 1].Name = "Codigo";
            toRet[toRet.Count - 1].HeaderText = "Código";
            toRet[toRet.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            toRet.Add(new DataGridViewTextBoxColumn());
            toRet[toRet.Count - 1].DataPropertyName = "Identificacao";
            toRet[toRet.Count - 1].Name = "Identificacao";
            toRet[toRet.Count - 1].HeaderText = "Identificação";
            toRet[toRet.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            return toRet;
         
        }

        public Type getTipoEntidade()
        {
            return typeof (CentroCustoLucroClass);
        }

        public string getGridFullName()
        {
            return this.Name;
        }

        public AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            return new List<SearchParameterClass>()
            {
                new SearchParameterClass("Ativo", true, SearchOperacao.FiltroObrigatorio, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                new SearchParameterClass("NomeCompleto", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
            };
        }

        public IWTPostgreNpgsqlConnection getConnection()
        {
            return this.SingleConnection;
        }
    }
}
