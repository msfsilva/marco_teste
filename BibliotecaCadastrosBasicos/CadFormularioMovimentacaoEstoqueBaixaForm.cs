using System;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFormularioMovimentacaoEstoqueBaixaForm : IWTBaseForm
    {
        AcsUsuarioClass Usuario;
        IWTPostgreNpgsqlConnection conn;
        public CadFormularioMovimentacaoEstoqueBaixaForm(AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.Usuario = usuario;
            this.conn = conn;
        }


        private void Liberar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.txtBarcode.Text.Trim().Length == 0) return;

                FomularioRetiradaManualEstoqueClass formulario = FomularioRetiradaManualEstoqueClass.GetByBarcode(this.txtBarcode.Text,this.Usuario,this.conn);
                    
                
                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();
                formulario.SetRetirado();
                formulario.Save(ref command);

                if (formulario.Produto != null)
                {
                    EstoqueMovimentacao.LancaMovimentoEstoqueProduto(
                        formulario.EstoqueGaveta,
                        formulario.Produto,
                        formulario.Quantidade * -1,
                        "Movimentação manual de estoque - " + formulario.Observacao,
                        "Formulário de Movimentação Manual nº" + formulario.ID,
                        this.Usuario,
                        false,
                        ref command
                        );

                    if (formulario.EstoqueGavetaDestino != null)
                    {
                       EstoqueMovimentacao.LancaMovimentoEstoqueProduto(
                       formulario.EstoqueGavetaDestino,
                       formulario.Produto,
                       formulario.Quantidade,
                       "Movimentação manual de estoque - " + formulario.Observacao,
                       "Formulário de Movimentação Manual nº" + formulario.ID,
                       this.Usuario,
                       false,
                       ref command
                       );
                    }
                }
                else
                {
                    if (formulario.Material != null)
                    {

                        EstoqueMovimentacao.LancaMovimentoEstoqueMaterial(
                            formulario.EstoqueGaveta,
                            formulario.Material,
                            formulario.Quantidade*-1,
                            "Movimentação manual de estoque - " + formulario.Observacao,
                            "Formulário de Movimentação Manual nº" + formulario.ID,
                            this.Usuario,
                            false,
                            ref command
                            );

                        if (formulario.EstoqueGavetaDestino != null)
                        {
                            EstoqueMovimentacao.LancaMovimentoEstoqueMaterial(
                                formulario.EstoqueGavetaDestino,
                                formulario.Material,
                                formulario.Quantidade,
                                "Movimentação manual de estoque - " + formulario.Observacao,
                                "Formulário de Movimentação Manual nº" + formulario.ID,
                                this.Usuario,
                                false,
                                ref command
                                );
                        }
                    }
                    else
                    {
                        if (formulario.Epi != null)
                        {
                            EstoqueMovimentacao.LancaMovimentoEstoqueEpi(
                                formulario.EstoqueGaveta,
                                formulario.Epi,
                                formulario.Quantidade*-1,
                                "Movimentação manual de estoque - " + formulario.Observacao,
                                "Formulário de Movimentação Manual nº" + formulario.ID,
                                this.Usuario,
                                false,
                                ref command
                                );

                            if (formulario.EstoqueGavetaDestino != null)
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueEpi(
                                    formulario.EstoqueGavetaDestino,
                                    formulario.Epi,
                                    formulario.Quantidade,
                                    "Movimentação manual de estoque - " + formulario.Observacao,
                                    "Formulário de Movimentação Manual nº" + formulario.ID,
                                    this.Usuario,
                                    false,
                                    ref command
                                    );
                            }
                        }
                        else
                        {
                            throw new Exception("Tipo de conteúdo inválido para a baixa do formulário");
                        }
                    }

                }


                command.Transaction.Commit();
                MessageBox.Show(this, "Movimentação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao retirar do estoque\r\n" + e.Message, e);
            }
            finally
            {
                this.txtBarcode.Clear();
            }
        }

        #region Eventos
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Enabled = false;
                this.Liberar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
