#region Referencias

using System;
using System.Windows.Forms;
using BibliotecaExpedicao;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using NpgsqlTypes;
using ProjectConstants;
using dbProvider;

#endregion

namespace BibliotecaAdministracaoSistema
{
    public partial class AlterarPalletSelecaoPalletForm : IWTBaseForm
    {
        IWTPostgreNpgsqlCommand command;
        readonly int numPalletAtual;
        public bool Cancelar { get; private set; }

        public PalletConferencia PalletSelecionado { get; private set; }


        public AlterarPalletSelecaoPalletForm(ref IWTPostgreNpgsqlCommand command, int numPalletAtual)
        {
            InitializeComponent();
            this.command = command;
            this.numPalletAtual = numPalletAtual;
        }

       

        private void validateData()
        {
            try
            {
                if (this.Cancelar)
                {
                    return;
                }

                if ((int)this.numericUpDown1.Value == this.numPalletAtual)
                {
                    throw new Exception("Não é possível mover um item para o mesmo pallet em que ele está atualmente.");
                }

                PalletConferencia pallet = new PalletConferencia((int)this.numericUpDown1.Value, this.SingleConnection);
                if (pallet.Bloqueado)
                {
                    throw new Exception("Não é possível mover um item para um pallet bloqueado.");
                }


                if (!pallet.Fechado)
                {
                    throw new Exception("Não é possível mover um item para um pallet aberto.");
                }



                this.command.CommandText =
                    "SELECT  " +
                    "  COUNT(public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia)  " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet = :numero_pallet AND  " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet_sequencia = :sequencia_pallet AND  " +
                    "  public.order_item_etiqueta_conferencia.id_embarque IS NOT NULL ";

                this.command.Parameters.Clear();
                this.command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("numero_pallet", NpgsqlDbType.Smallint, pallet.Numero));
                this.command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sequencia_pallet", NpgsqlDbType.Bigint, pallet.Sequencia));

                object tmp = command.ExecuteScalar();
                if (tmp != null)
                {
                    long qtdRegistros = (long)tmp;
                    if (qtdRegistros > 0)
                    {
                        throw new ExcecaoTratada("Não é possível utilizar esse pallet pois ele já possui itens com embarque");
                    }
                }

                if (IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET))
                {

                    if (pallet.Conferido)
                    {
                        if (DialogResult.Yes !=
                            MessageBox.Show(this, "O pallet selecionado está conferido, ao prosseguir com essa operação será necessário refazer a conferência dele. Deseja Continuar?", "Pallet Coferido", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question))
                        {
                            return;
                        }
                    }
                }

                PalletSelecionado = pallet;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os dados selecionados.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlterarPalletSelecaoPalletForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.validateData();
            }
            catch (Exception a)
            {
                e.Cancel = true;
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancelar = true;
            this.Close();
        }
        #endregion

    }
}
