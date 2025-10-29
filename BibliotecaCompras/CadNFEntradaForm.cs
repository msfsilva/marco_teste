#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaCompras
{
    public partial class CadNFEntradaForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;

        NFEntradaClass NF;


        public CadNFEntradaForm(int? idNFEntrada, bool somenteVisualizacao, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            
            this.conn = conn;
            this.Usuario = Usuario;

            this.ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);

            if (idNFEntrada != null)
            {
                this.LoadEdit(idNFEntrada.Value);
            }
            else
            {
                this.NF = new NFEntradaClass(null, this.Usuario, this.conn);
            }

            if (somenteVisualizacao)
            {
                nudNumero.Enabled = false;
                txtSerie.Enabled = false;
                dtpDataEmissao.Enabled = false;
                ensFornecedor.Enabled = false;
                btnEditar.Enabled = false;
                btnNovo.Enabled = false;
                btnRemover.Enabled = false;
                btnSalvar.Enabled = false;
                txtChaveNFe.Enabled = false;
            }

            

        }

     

        private void LoadEdit(int idNFEntrada)
        {
            try
            {

                this.NF = new NFEntradaClass(idNFEntrada, this.Usuario, this.conn);
                this.nudNumero.Value = int.Parse(this.NF.Numero);
                this.txtSerie.Text = this.NF.Serie;
                this.txtChaveNFe.Text = this.NF.ChaveNota;

                if (this.NF.Fornecedor == null)
                {
                    MessageBox.Show(this, "Não foi possivel encontrar o fornecedor " + this.NF.razaoFornecedorNota + " (" + this.NF.CNPJFornecedorNota + ") automaticamente no cadastro de fornecedores. Antes de salvar a nota fiscal editada será necessário seleciona-lo manualmente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ensFornecedor.Enabled = true;
                }
                else
                {
                    this.ensFornecedor.EntidadeSelecionada = this.NF.Fornecedor;
                    this.ensFornecedor.Enabled = false;
                }
                this.dtpDataEmissao.Value = this.NF.dataNf;

                this.initializeGrid();

                this.nudNumero.Enabled = false;
                this.txtSerie.Enabled = false;
                this.dtpDataEmissao.Enabled = false;
               

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da NF de entrada\r\n" + e.Message, e);
            }
        }

        private void initializeGrid()
        {
            try
            {
                this.dgvLinhas.Columns.Clear();
                


                this.dgvLinhas.AutoGenerateColumns = false;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Linha";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Linha";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "Linha";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 55;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Codigo";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Código";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 90;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Descricao";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Descrição";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 150;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Quantidade";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Quantidade";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 78;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "valorUnitario";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Valor Unitário(R$)";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "valorUnitario";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 78;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "valorTotal";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Valor Total(R$)";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "valorTotal";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 78;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "icmsIncluso";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "ICMS Incluso(%)";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "icmsIncluso";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 78;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "ipiNaoIncluso";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "IPI Não Incluso(%)";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "ipiNaoIncluso";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 78;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "xPed";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Pedido Cliente";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "xPed";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 60;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "posicao";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Posição Pedido Cliente";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "posicao";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 50;

                this.dgvLinhas.Columns.Add(new DataGridViewCheckBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "vinculada";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Recebida/Vinculada";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "vinculada";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Width = 120;

                this.dgvLinhas.DataSource = new AdvancedList<NFEntradaItemClass>(this.NF.linhasAtuais.Values);

                this.dgvLinhas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvLinhas.MultiSelect = false;


                this.lblTotalNF.Text = "R$ " + this.NF.valorTotalCalculado.ToString("F2", CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar os dados das linhas\r\n" + e.Message, e);
            }
        }

        private void ItemNovo()
        {
            try
            {
                NFEntradaItemClass tmp = null;

                CadNFEntradaItemForm form = new CadNFEntradaItemForm(ref this.NF, ref tmp, this.conn);
                form.ShowDialog();
                if (!form.Abortado)
                {
                    this.NF.addicionarLinha(
                        null,
                        form.item.Codigo,
                        form.item.Descricao,
                        form.item.NCM,
                        form.item.Unidade,
                        form.item.Quantidade,
                        form.item.valorUnitario,
                        form.item.valorTotal,
                        form.item.icmsIncluso,
                        form.item.ipiNaoIncluso,                        
                        false,
                        form.item.XPed,
                        form.item.Posicao
                        );

                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o item novo\r\n" + e.Message, e);
            }
        }

        private void ItemEditar()
        {
            try
            {
                if (this.dgvLinhas.SelectedRows.Count <= 0)
                {
                    throw new Exception("Selecione uma linha antes de editar.");
                }

                int numeroLinha = Convert.ToInt32(this.dgvLinhas.SelectedRows[0].Cells["Linha"].Value);
                NFEntradaItemClass Linha = this.NF.linhasAtuais[numeroLinha];

                CadNFEntradaItemForm form = new CadNFEntradaItemForm(ref this.NF, ref Linha, this.conn);
                form.ShowDialog();
                if (!form.Abortado)
                {
                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar a linha\r\n" + e.Message, e);
            }
        }

        private void ItemRemover()
        {
            try
            {
                if (this.dgvLinhas.SelectedRows.Count <= 0)
                {
                    throw new Exception("Selecione uma linha para excluir.");
                }

                if (MessageBox.Show(this, "Você deseja excluir a linha selecionada?", "Excluir Linha", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int numeroLinha = Convert.ToInt32(this.dgvLinhas.SelectedRows[0].Cells["Linha"].Value);

                    this.NF.excluirLinha(numeroLinha);
                    this.initializeGrid();

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir a linha\r\n" + e.Message, e);
            }
        }

        private void Salvar()
        {
            try
            {
                if (txtSerie.Text.Trim().Length == 0)
                {
                    throw new Exception("O campo de série é obrigatório");
                }

                if (this.ensFornecedor.EntidadeSelecionada== null)
                {
                    throw new Exception("O campo de fornecedor é obrigatório");
                }

                if (this.NF.linhasAtuais.Count == 0)
                {
                    throw new Exception("A nota deve possuir ao menos uma linha");
                }

                this.NF.Numero = this.nudNumero.Value.ToString();
                this.NF.Serie = this.txtSerie.Text;
                this.NF.dataNf = this.dtpDataEmissao.Value;
                this.NF.Fornecedor = (FornecedorClass) this.ensFornecedor.EntidadeSelecionada;
                this.NF.CNPJFornecedorNota = this.NF.Fornecedor.Cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
                this.NF.razaoFornecedorNota = this.NF.Fornecedor.RazaoSocial;
                this.NF.nomeArquivo = "MANUAL";
                this.NF.valorTotal = this.NF.valorTotalCalculado;
                this.NF.definirFornecedor(this.NF.Fornecedor);
                this.NF.ChaveNota = this.txtChaveNFe.Text;
                this.NF.Salvar(this);

                MessageBox.Show(this, "Nota fiscal salva com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar.\r\n" + e.Message, e);
            }
        }

        private void Fechar()
        {
            this.Close();
        }



        private void LinhaSelecionada()
        {
            if (this.dgvLinhas.SelectedRows.Count <= 0)
            {
               return;
            }

            NFEntradaItemClass item = (NFEntradaItemClass) this.dgvLinhas.SelectedRows[0].DataBoundItem;
            btnEditar.Enabled = !item.Vinculada;
            btnRemover.Enabled = !item.Vinculada;

        }

        #region Eventos
        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                this.ItemNovo();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ItemEditar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                this.ItemRemover();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Salvar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Fechar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvLinhas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LinhaSelecionada();
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
}
