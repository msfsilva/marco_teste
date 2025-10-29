using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos.Operacoes
{

    public partial class AtualizarEntregaPedidoMultiploForm : IWTBaseForm
    {
        private BindingList<AtualizarEntregaPedidoMultiploClass> dataSource;

        public AtualizarEntregaPedidoMultiploForm()
        {
            InitializeComponent();
            dataSource = new BindingList<AtualizarEntregaPedidoMultiploClass>();

            this.dgvDados.AutoGenerateColumns = false;
            this.dgvDados.DataSource = dataSource;
        }

        private void Paste()
        {
            try
            {
                DataObject o = (DataObject) Clipboard.GetDataObject();
                if (o.GetDataPresent(DataFormats.Text))
                {
                    string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                    for (var i = 0; i < pastedRows.Length; i++)
                    {
                        string linha = pastedRows[i];
                        string[] cells = linha.Trim().Split(new char[] {'\t'});
                        if (cells.Length < 2)
                        {
                            throw new ExcecaoTratada("Linha do pedido está fora de padrão: " + linha);
                        }

                        string pedido = cells[0];
                        int pos;
                        if (!int.TryParse(cells[1], out pos))
                        {
                            throw new ExcecaoTratada("O campo de posição do pedido está inválido na linha " + (i + 1));
                        }

                        DateTime? dataEntrega = null;
                        if (cells.Length > 2)
                        {
                            DateTime tmpData;
                            if (!string.IsNullOrWhiteSpace(cells[2]))
                            {
                                if (!DateTime.TryParse(cells[2], out tmpData))
                                {
                                    throw new ExcecaoTratada("O campo de Data de Entrega está inválido na linha " + (i + 1));
                                }

                                dataEntrega = tmpData;
                            }
                        }

                        string justificativa = null;
                        if (cells.Length > 3)
                        {
                            justificativa = cells[3];
                        }



                        List<PedidoItemClass> pedidos = PedidoItemClass.BuscaPedidoPendente(pedido, pos, LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                        if (pedidos.Count == 0)
                        {
                            throw new ExcecaoTratada("Não foi encontrado pedido em aberto para a OC/Pos " + pedido + "/" + pos);
                        }

                        if (pedidos.Count > 1)
                        {
                            throw new ExcecaoTratada("Foram encontrados vários pedidos em aberto para a OC/Pos " + pedido + "/" + pos);
                        }

                        dataSource.Add(new AtualizarEntregaPedidoMultiploClass()
                        {
                            PedidoEasi = pedidos[0],
                            Pedido = pedido,
                            Posicao = pos,
                            DataEntrega = dataEntrega,
                            Justificativa = justificativa

                        });
                    }
                }

                dgvDados.Invalidate();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao separar os dados em colunas \r\n" + e.Message, e);
            }
        }

        private bool ValidarDados(int linha, int coluna, string valorFormatado, out string erro)
        {
            try
            {
                erro = null;
                //Validação da coluna de posicao
                if (this.dgvDados.Columns[coluna] == PosicaoColumn)
                {
                    int output;
                    if (!int.TryParse(valorFormatado, out output) || output < 1)
                    {
                        dgvDados.Rows[linha].ErrorText = "A posição digitada é inválida";
                        erro = dgvDados.Rows[linha].ErrorText;
                        return false;

                    }
                    else
                    {
                        dgvDados.Rows[linha].ErrorText = null;
                    }
                }

                //Validação da coluna de data prometida
                if (this.dgvDados.Columns[coluna] == NovaDataEntregaColumn)
                {
                    if (string.IsNullOrWhiteSpace(valorFormatado))
                    {
                        dgvDados.Rows[linha].ErrorText = null;
                    }
                    else
                    {
                        DateTime output;
                        if (!DateTime.TryParse(valorFormatado, out output))
                        {
                            dgvDados.Rows[linha].ErrorText = "A data de entrega digitada é inválida";
                            erro = dgvDados.Rows[linha].ErrorText;
                            return false;

                        }
                        else
                        {
                            dgvDados.Rows[linha].ErrorText = null;
                        }
                    }
                }



                return true;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao validar os dados digitados\r\n" + e.Message, e);
            }
        }


        private void Salvar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (dataSource.Count == 0)
                {
                    throw new ExcecaoTratada("Não há nenhum pedido para ser salvo");
                }

                if (MessageBox.Show(this, "Essa operação irá sobrescrever todos os dados dos pedidos na tabela, deseja continuar?", "Atualização de Pedidos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

      

                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                foreach (AtualizarEntregaPedidoMultiploClass pedido in dataSource)
                {
                    pedido.Save(ref command, LoginClass.UsuarioLogado.loggedUser);
                }

                command.Transaction.Commit();

                this.Close();
            }
            catch (ExcecaoTratada)
            {
                if (command?.Transaction != null && command.Transaction.IsActive)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command?.Transaction != null && command.Transaction.IsActive)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro inesperado ao salvar os dados de todos os pedidos \r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void dgvDados_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    Paste();
                    e.SuppressKeyPress = true;
                }
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
                  Salvar();
              }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dgvDados_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
              try
            {
                string error;
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    return;
                }

                e.Cancel = !this.ValidarDados(e.RowIndex, e.ColumnIndex, e.FormattedValue.ToString(), out error);
                if (e.Cancel)
                {
                    MessageBox.Show(this, error, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
