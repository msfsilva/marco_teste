/*
 Alteração na metodologia de cálculo do preço para validação. Antigo utilizava ou preço fixo ou variável, agora soma os 2;
 */

#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.TelasAuxiliares;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using BibliotecaNotasFiscais;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTNF;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

#endregion

namespace BibliotecaFinanceiro
{
    public partial class EmbarqueForm : IWTBaseForm
    {
        BindingSource binding = null;
        
        private readonly AcsUsuarioClass _acsUsuario;
        private IObservacaoCustomizada _observacaoCustomizada;

        public EmbarqueForm(AcsUsuarioClass _acsUsuario, IObservacaoCustomizada observacaoCustomizada)
        {
            InitializeComponent();
            
            this._acsUsuario = _acsUsuario;
            _observacaoCustomizada = observacaoCustomizada;
            this.initializeGrid();

            TipoEmissaoNFe tipoEmissaoNFe = (TipoEmissaoNFe)Enum.ToObject(typeof(TipoEmissaoNFe), int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)));
            if (tipoEmissaoNFe!=TipoEmissaoNFe.EASI)
            {
                this.dataGridView1.Columns[4].Visible = false;
                this.rdbNFEmitidaAutorizada.Visible = false;
            }

        }

        private void initializeGrid()
        {
            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {

                string whereClause = "";
                if (rdbNaoLiberado.Checked)
                {
                    whereClause = "WHERE emb_liberado_nf = 0";
                }

                if (rdbLiberado.Checked)
                {
                    whereClause = "WHERE emb_liberado_nf = 1 AND emb_nf_emitida = 0";
                }

                if (rdbNfEmitida.Checked)
                {
                    whereClause = "WHERE emb_nf_emitida = 1 AND emb_nf_autorizada = 0";
                }

                if (rdbNFEmitidaAutorizada.Checked)
                {
                    whereClause = "WHERE emb_nf_autorizada = 1";
                }



                string sql =
                    " SELECT DISTINCT " +
                    "  embarque.id_embarque,     " +
                    "  CASE emb_liberado_nf WHEN 0 THEN 'Não' ELSE 'Sim' END as liberado,     " +
                    "  emb_liberacao_hora,    " +
                    "  CASE emb_nf_emitida WHEN 0 THEN 'Não' ELSE 'Sim' END as nf_emitida,     " +
                    "  CASE emb_nf_autorizada WHEN 0 THEN 'Não' ELSE 'Sim' END as nf_autorizada,   " +
                    "  emb_liberado_nf,     " +
                    "  emb_nf_emitida,     " +
                    "  emb_nf_autorizada,  " +
                    "  iwt_agregate_clientes_nf(COALESCE(id_externo_cliente_access, cli_nome_resumido)),   " +
                    "  iwt_agregate_clientes_nf(cliente.cli_nome) " +
                    "FROM " +
                    "  public.embarque " +
                    "  LEFT JOIN public.order_item_etiqueta_conferencia ON(public.embarque.id_embarque = public.order_item_etiqueta_conferencia.id_embarque)     " +
                    "  LEFT JOIN order_item_etiqueta ON(public.order_item_etiqueta_conferencia.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta)  " +
                    "  LEFT JOIN cliente ON order_item_etiqueta.id_cliente = cliente.id_cliente " +
                    " " + whereClause + " " +
                    "GROUP BY " +
                    "  embarque.id_embarque, " +
                    "  emb_liberado_nf, " +
                    "  emb_liberacao_hora, " +
                    "  emb_nf_emitida, " +
                    "  emb_liberado_nf, " +
                    "  emb_nf_autorizada " +
                    "ORDER BY id_embarque";

                adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);

                binding = new BindingSource();
                binding.DataSource = dataSet.Tables[0];



                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = binding;

                dataGridView1.Columns[0].HeaderText = "Número";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].HeaderText = "Liberado Emissão NF";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[2].HeaderText = "Data Liberação";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].HeaderText = "NF Emitida";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[4].HeaderText = "NF Autorizada";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[4].Width = 70;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].HeaderText = "Cliente(s) - Fantasia";
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[8].Width = 150;
                dataGridView1.Columns[9].HeaderText = "Cliente(s) - Razão";
                dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[9].Width = 200;

             
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

      

        private void emitirNfEmbarque(string idEmbarque)
        {
            try
            {
                VersaoLayoutNF versaoLayout = VersaoLayoutNF.Layout3_10;

                NotaFiscalEasiClass nfBuilder = new NotaFiscalEasiClass(DbConnection.Connection,  this._acsUsuario,
                                                                        versaoLayout,
                                                                        (ArredondamentoNF) Enum.ToObject(typeof (ArredondamentoNF), Constants.ArredondamentoNF)
                                                                        );

                nfBuilder.emitirNFEmbarque(idEmbarque,this._observacaoCustomizada);

                
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, "Aviso ao emitir a nota fiscal:"+Environment.NewLine+a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao emitir a nota fiscal:" + Environment.NewLine + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void showNfsEmbarque(string idEmbarque)
        {
            try
            {
                EmbarqueNFsForm form = new EmbarqueNFsForm(idEmbarque);
                form.Show();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar as notas fiscais do embarque");
            }


        }

        #region Eventos

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.initializeGrid();
        }

        private void btnEmitirNF_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string idEmbarque = this.dataGridView1.SelectedRows[0].Cells["id_embarque"].Value.ToString();
                    if (Convert.ToInt16(this.dataGridView1.SelectedRows[0].Cells["emb_liberado_nf"].Value) == 1)
                    {
                        if (Convert.ToInt16(this.dataGridView1.SelectedRows[0].Cells["emb_nf_emitida"].Value) == 0)
                        {
                            if (MessageBox.Show(this, "Essa operação emitirá a nota fiscal para o embarque selecionado. Deseja continuar?", "Emissão de NF de Embarque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.emitirNfEmbarque(idEmbarque);
                                this.initializeGrid();
                            }
                        }
                        else
                        {
                            throw new Exception("Nota fiscal já emitida para o embarque selecionado.");
                        }
                    }
                    else
                    {
                        throw new Exception("Impossível emitir nota fiscal para um embarque não liberado");
                    }


                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string idEmbarque = this.dataGridView1["id_embarque", e.RowIndex].Value.ToString();


                this.showNfsEmbarque(idEmbarque);

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnTransportadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    throw new ExcecaoTratada("Selecione um embarque para definir a transportadora");
                }

                long idEmbarque = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["id_embarque"].Value);

                EmbarqueClass embarque = EmbarqueClass.GetEntidade(idEmbarque, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                CadEmbarqueTransportadoraForm form = new CadEmbarqueTransportadoraForm(embarque);
                form.ShowDialog(this);

                this.initializeGrid();
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



        #endregion


    }


    internal class organizaNfClass
    {
        internal string idClienteAccess;
        internal string armazenagemCliente;
        internal string naturezaOperacao;
        internal List<organizaNfItemClass> itens = new List<organizaNfItemClass>();
        internal bool matAdicional;
        internal int? idCliente;

    }

    internal class organizaNfClassKey : IEquatable<organizaNfClassKey>
    {
        internal string idClienteAccess;
        internal string armazenagemCliente;
        internal string naturezaOperacao;
        internal bool matAdicional;
        internal int? idCliente;

        internal organizaNfClassKey(string idClienteAccess, int? idCliente, string armazenagemCliente, string naturezaOperacao, bool matAdicional)
        {
            this.idClienteAccess = idClienteAccess;
            this.armazenagemCliente = armazenagemCliente;
            this.naturezaOperacao = naturezaOperacao;
            this.matAdicional = matAdicional;
            this.idCliente = idCliente;
        }



        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is organizaNfClassKey))
                throw new InvalidCastException("The 'obj' argument is not a Person object.");
            else
                return Equals(obj as organizaNfClassKey);

        }

        public bool Equals(organizaNfClassKey o1)
        {
            if (this.idClienteAccess == o1.idClienteAccess && this.idCliente == o1.idCliente && this.armazenagemCliente == o1.armazenagemCliente && this.naturezaOperacao == o1.naturezaOperacao && this.matAdicional == o1.matAdicional)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int toRet = this.idClienteAccess.GetHashCode() * this.armazenagemCliente.GetHashCode() * this.naturezaOperacao.GetHashCode() * this.matAdicional.GetHashCode();
            if (this.idCliente != null)
            {
                toRet = toRet * this.idCliente.GetHashCode();
            }
            return toRet;
        }

        public static bool operator ==(organizaNfClassKey person1, organizaNfClassKey person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator !=(organizaNfClassKey person1, organizaNfClassKey person2)
        {
            return (!person1.Equals(person2));
        }



    }

    internal class organizaNfItemClass
    {
        internal string id;
        internal string pedido;
        internal double valorUnitario;
        internal double quantidade;
        internal int? idCliente;
        internal int indiceLinha;
        internal double valorTotal
        {
            get
            {
                return valorUnitario * quantidade;
            }
        }
        internal string idOrderItemEtiquetaConferencia;

    }

    internal class nfEmitida
    {
        public organizaNfClass infosNota { private set; get; }
        public NfPrincipalClass nf { private set; get; }

        public nfEmitida(organizaNfClass infosNota, NfPrincipalClass nf)
        {
            this.infosNota = infosNota;
            this.nf = nf;
        }


    }

}
