#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaExpedicao;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using dbProvider;
using ProjectConstants;

#endregion

namespace BibliotecaAdministracaoSistema
{
    public partial class AlterarPalletForm : IWTBaseForm
    {
        readonly string numPallet;
        readonly string sequencia;
        public AlterarPalletForm(string numPallet, string sequencia, bool somenteVisualizacao)
        {
            this.numPallet = numPallet;
            this.sequencia = sequencia;

            InitializeComponent();
            this.initializeGrid();



            if (somenteVisualizacao)
            {
                this.btnMover.Visible = false;
                this.btnRemover.Visible = false;
            }

        }

        private void initializeGrid()
        {
            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {
                string sql =
                    "SELECT                                                                                                           " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number,                                                       " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos,                                                          " +
                    "  public.order_item_etiqueta_conferencia.oic_quantidade_conferida,                                               " +
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia,                                                   " +
                    "  public.order_item_etiqueta_conferencia.oic_volumes,                                                            " +
                    "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia,                                     " +
                    "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta,                                                 " +
                    "  public.order_item_etiqueta_conferencia.id_embarque                                                             " +
                    "FROM                                                                                                             " +
                    "  public.order_item_etiqueta_conferencia                                                                         " +
                    "  INNER JOIN public.pallet ON (public.order_item_etiqueta_conferencia.oic_pallet = public.pallet.pal_numero)     " +
                    "  AND (public.order_item_etiqueta_conferencia.oic_pallet_sequencia = public.pallet.pal_sequencia)                " +
                    "WHERE                                                                                                            " +
                    "  public.pallet.pal_numero = " + this.numPallet + " AND                                                          " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pai = 1                                                 ";

                adapter = new IWTPostgreNpgsqlAdapter(sql, this.SingleConnection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].HeaderText = "OC";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].MinimumWidth = 100;
                    dataGridView1.Columns[1].HeaderText = "Pos";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].HeaderText = "Qtd";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].HeaderText = "Data Conferida";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].HeaderText = "Volumes";
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;

                }
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void removeItem(int idOrderItemEtiquetaConferencia)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (MessageBox.Show(this, "Você deseja remover o item selecionado do pallet? Essa operação não poderá ser desfeita.", "Remover Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = this.SingleConnection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    OrderItemEtiquetaConferenciaClass conferenciaPai = OrderItemEtiquetaConferenciaClass.GetEntidade(idOrderItemEtiquetaConferencia, LoginClass.UsuarioLogado.loggedUser, command.Connection);
                    //Buscar quantidades baixadas

                    OrderItemEtiquetaConferenciaClass.DesfazerConferencia(conferenciaPai, LoginClass.UsuarioLogado.loggedUser, command);
                    string sql = "";

                    if (!IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET))
                    {
                        List<OrderItemEtiquetaConferenciaNfClass> toDelete = new OrderItemEtiquetaConferenciaNfClass(LoginClass.UsuarioLogado.loggedUser, command.Connection).Search(new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("Pallet", short.Parse(this.numPallet)),
                            new SearchParameterClass("PalletSequencia", long.Parse(this.sequencia)),
                            new SearchParameterClass("OrderItemEtiqueta", conferenciaPai.OrderItemEtiqueta)
                        }).ConvertAll(a=>(OrderItemEtiquetaConferenciaNfClass)a).ToList();

                        foreach (OrderItemEtiquetaConferenciaNfClass delete in toDelete)
                        {
                            delete.OrderItemEtiqueta.SituacaoConferenciaNf = SituacaoConferencia.Parcial;
                            delete.OrderItemEtiqueta.CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta.Remove(delete);
                            delete.OrderItemEtiqueta.Save(ref command);
                            delete.Delete(ref command);
                        }
                    }
                    else
                    {

                        List<OrderItemEtiquetaConferenciaNfClass> toDelete = new OrderItemEtiquetaConferenciaNfClass(LoginClass.UsuarioLogado.loggedUser, command.Connection).Search(new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("Pallet", short.Parse(this.numPallet)),
                            new SearchParameterClass("PalletSequencia", long.Parse(this.sequencia)),

                        }).ConvertAll(a => (OrderItemEtiquetaConferenciaNfClass)a).ToList();

                        foreach (OrderItemEtiquetaConferenciaNfClass delete in toDelete)
                        {
                            delete.OrderItemEtiqueta.SituacaoConferenciaNf = SituacaoConferencia.Parcial;
                            delete.OrderItemEtiqueta.CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta.Remove(delete);
                            delete.OrderItemEtiqueta.Save(ref command);
                            delete.Delete(ref command);
                        }

                        //reabrir pallet para conferencia
                        sql += "UPDATE pallet SET pal_conferido=0 WHERE pal_numero=" + this.numPallet + "; ";

                        //liberar a conferencia de pallet para os outros itens
                        sql += "UPDATE order_item_etiqueta_conferencia SET oic_conferencia_pallet=0, oic_conferencia_pallet_usuario = NULL,oic_conferencia_pallet_data = NULL  WHERE oic_pallet = " +
                               this.numPallet + " AND oic_pallet_sequencia=" + this.sequencia + "; ";
                    }


                   
                   



                    if (sql.Length > 0)
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }



                    //teste pallet vazio
                    command.CommandText = "SELECT  " +
                                          "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia " +
                                          "FROM " +
                                          "  public.order_item_etiqueta_conferencia " +
                                          "  INNER JOIN public.pallet ON (public.order_item_etiqueta_conferencia.oic_pallet = public.pallet.pal_numero) " +
                                          "  AND (public.order_item_etiqueta_conferencia.oic_pallet_sequencia = public.pallet.pal_sequencia) " +
                                          "WHERE " +
                                          "  public.pallet.pal_numero = " + this.numPallet + " AND pal_sequencia=" +
                                          this.sequencia + ";";

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    if (!read.HasRows)
                    {
                        read.Close();
                        command.CommandText =
                            "UPDATE pallet SET pal_ocupado = 0, pal_fechado=0, pal_conferido=0 WHERE public.pallet.pal_numero = " +
                            this.numPallet + " AND pal_sequencia=" + this.sequencia + ";";

                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        read.Close();
                    }

                    command.Transaction.Commit();


                }
                else
                {
                    return;
                }


            }
            catch (Exception e)
            {
                if (command != null)
                {
                    try
                    {
                        if (command.Transaction != null)
                        {
                            command.Transaction.Rollback();
                        }
                    }
                    catch
                    {
                    }
                }

                throw new Exception("Erro inesperado ao editar o pallet.\r\n" + e.Message);

            }
            finally
            {
                BufferAbstractEntity.limparBuffer();
            }
        }


        private void moverItem(string idOrderItemEtiquetaConferencia, string idOrderItemEtiqueta, string oc, string pos)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();


                AlterarPalletSelecaoPalletForm form = new AlterarPalletSelecaoPalletForm(ref command, Convert.ToInt32(this.numPallet));
                form.ShowDialog();

                if (form.Cancelar)
                {
                    command.Transaction.Rollback();
                    return;
                }


                PalletConferencia palletOrigem = new PalletConferencia(Convert.ToInt32(this.numPallet), this.SingleConnection);
                PalletConferencia palletDestino = form.PalletSelecionado;

                palletOrigem.setConferido(false);
                palletDestino.setConferido(false);

                palletOrigem.Save(command);
                palletDestino.Save(command);

                command.CommandText = "UPDATE order_item_etiqueta SET oie_pallet = " + palletDestino.Numero.ToString() + " WHERE oie_order_number LIKE '" + oc + "' AND oie_order_pos=" + pos + "; ";
                command.CommandText += "UPDATE order_item_etiqueta_conferencia SET oic_pallet = " + palletDestino.Numero.ToString() + ", oic_pallet_sequencia=" + palletDestino.Sequencia.ToString() + " WHERE oic_order_number LIKE '" + oc + "' AND oic_order_pos=" + pos + ";";

                command.CommandText += "UPDATE order_item_etiqueta_conferencia SET oic_conferencia_pallet=0, oic_conferencia_pallet_usuario = NULL,oic_conferencia_pallet_data = NULL  WHERE oic_pallet = " +palletOrigem.Numero + " AND oic_pallet_sequencia=" + palletOrigem.Sequencia + "; ";
                command.CommandText += "UPDATE order_item_etiqueta_conferencia SET oic_conferencia_pallet=0, oic_conferencia_pallet_usuario = NULL,oic_conferencia_pallet_data = NULL  WHERE oic_pallet = " + palletDestino.Numero + " AND oic_pallet_sequencia=" + palletDestino.Sequencia + "; ";

                command.CommandText +=
                    "UPDATE order_item_etiqueta SET oie_situacao_conferencia_nf= 0 WHERE id_order_item_etiqueta IN ( " +
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia_nf.id_order_item_etiqueta " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia_nf " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia_nf.oin_pallet = " + palletOrigem.Numero + " AND  " +
                    "  public.order_item_etiqueta_conferencia_nf.oin_pallet_sequencia = " + palletOrigem.Sequencia + " " +
                    ");";

                command.CommandText +=
                    "UPDATE order_item_etiqueta SET oie_situacao_conferencia_nf= 0 WHERE id_order_item_etiqueta IN ( " +
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia_nf.id_order_item_etiqueta " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia_nf " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia_nf.oin_pallet = " + palletDestino.Numero + " AND  " +
                    "  public.order_item_etiqueta_conferencia_nf.oin_pallet_sequencia = " + palletDestino.Sequencia + " " +
                    ");";

                command.CommandText += "DELETE FROM order_item_etiqueta_conferencia_nf WHERE oin_pallet= " + palletOrigem.Numero + " AND oin_pallet_sequencia = " + palletOrigem.Sequencia + "; ";
                command.CommandText += "DELETE FROM order_item_etiqueta_conferencia_nf WHERE oin_pallet= " + palletDestino.Numero + " AND  oin_pallet_sequencia = " + palletDestino.Sequencia + "; ";

                    
                command.ExecuteNonQuery();

                //teste pallet vazio
                command.CommandText = "SELECT  " +
                                      "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia " +
                                      "FROM " +
                                      "  public.order_item_etiqueta_conferencia " +
                                      "  INNER JOIN public.pallet ON (public.order_item_etiqueta_conferencia.oic_pallet = public.pallet.pal_numero) " +
                                      "  AND (public.order_item_etiqueta_conferencia.oic_pallet_sequencia = public.pallet.pal_sequencia) " +
                                      "WHERE " +
                                      "  public.pallet.pal_numero = " + palletOrigem.Numero + " AND pal_sequencia=" +
                                      palletOrigem.Sequencia + ";";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    read.Close();
                    command.CommandText =
                        "UPDATE pallet SET pal_ocupado = 0, pal_fechado=0, pal_conferido=0 WHERE public.pallet.pal_numero = " +
                        palletOrigem.Numero + " AND pal_sequencia=" + palletOrigem.Sequencia + ";";

                    command.ExecuteNonQuery();
                }
                else
                {
                    read.Close();
                }

                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                if (command != null)
                {
                    try
                    {
                       command.Transaction.Rollback();
                    }
                    catch { }
                }

                throw new Exception("Erro inesperado ao mover o item.\r\n" + e.Message);

            }
        }
        #region eventos

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    
                    int idOrderItemEtiquetaConferencia = int.Parse(this.dataGridView1.SelectedRows[0].Cells["id_order_item_etiqueta_conferencia"].Value.ToString());
                    string idEmbarque = this.dataGridView1.SelectedRows[0].Cells["id_embarque"].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(idEmbarque))
                    {
                        throw new ExcecaoTratada("Não é possível remover esse item do pallet pois ele ja foi incluído em um embarque. Desmonte o embarque antes de remover o item.");
                    }

                    this.removeItem(idOrderItemEtiquetaConferencia);
                    this.initializeGrid();
                }
                else
                {
                    throw new Exception("Selecione um item para ser removido.");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnMover_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string idOrderItemEtiqueta = this.dataGridView1.SelectedRows[0].Cells["id_order_item_etiqueta"].Value.ToString();
                    string idOrderItemEtiquetaConferencia = this.dataGridView1.SelectedRows[0].Cells["id_order_item_etiqueta_conferencia"].Value.ToString();
                    string oc = this.dataGridView1.SelectedRows[0].Cells["oic_order_number"].Value.ToString();
                    string pos = this.dataGridView1.SelectedRows[0].Cells["oic_order_pos"].Value.ToString();

                    string idEmbarque = this.dataGridView1.SelectedRows[0].Cells["id_embarque"].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(idEmbarque))
                    {
                        throw new ExcecaoTratada("Não é possível remover esse item do pallet pois ele ja foi incluído em um embarque. Desmonte o embarque antes de remover o item.");
                    }

                    this.moverItem(idOrderItemEtiquetaConferencia, idOrderItemEtiqueta, oc, pos);
                    this.initializeGrid();
                }
                else
                {
                    throw new Exception("Selecione um item para ser movido.");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}

