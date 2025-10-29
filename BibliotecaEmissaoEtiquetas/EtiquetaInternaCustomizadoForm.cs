#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaEmissaoEtiquetas
{
    public partial class EtiquetaInternaCustomizadoForm : IWTBaseForm
    {
        readonly string internalLabelPrinter;
        readonly string internalLabelPaper;
        readonly IWTPostgreNpgsqlConnection conn;
        AcsUsuarioClass Usuario;

        public EtiquetaInternaCustomizadoForm(string internalLabelPrinter, string internalLabelPaper, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.internalLabelPaper = internalLabelPaper;
            this.internalLabelPrinter = internalLabelPrinter;
            this.conn = conn;
            this.Usuario = usuario;
        }

        #region Eventos

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {


                EtiquetaInternaCustomizadoReportForm form;
                if (this.rdbSemana.Checked)
                {
                    if (string.IsNullOrEmpty(this.txtSemana.Text))
                    {
                        throw new ExcecaoTratada("Digite a semana antes de continuar.");
                    }

                    if (this.rdbSomenteSemana.Checked)
                    {
                        form = new EtiquetaInternaCustomizadoReportForm(txtSemana.Text, false, this.internalLabelPrinter, this.internalLabelPaper, this.Usuario, this.conn);
                    }
                    else
                    {
                        form = new EtiquetaInternaCustomizadoReportForm(txtSemana.Text, true, this.internalLabelPrinter, this.internalLabelPaper, this.Usuario, this.conn);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(this.txtOc.Text) && this.txtPos.Text.Length > 0)
                    {
                        //Verificar se ja foi impressa, apenas etiquetas ja impressas pela opção de "Semana" que podem gerar re-impressão de etiquetas.
                        try
                        {
                            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                            command.CommandText = "SELECT oie_etiqueta_interna_impressa FROM order_item_etiqueta WHERE oie_order_number='" + this.txtOc.Text.Trim() + "' AND oie_order_pos=" + this.txtPos.Text.Trim() + " AND oie_codigo_item='" +
                                                  this.txtCodItem.Text.Trim() + "' AND oie_tipo_item=1 AND oie_etiqueta_interna=1";
                            IWTPostgreNpgsqlDataReader rd = command.ExecuteReader();

                            rd.Read();

                            if (rd.HasRows && (rd["oie_etiqueta_interna_impressa"].ToString() == "1"))
                            {
                                form = new EtiquetaInternaCustomizadoReportForm(txtOc.Text, txtPos.Text, this.txtCodItem.Text.Trim(), this.internalLabelPrinter, this.internalLabelPaper, this.Usuario, this.conn);
                            }
                            else
                            {
                                throw new ExcecaoTratada("Não é possível reimprimir esta etiqueta, pois o item está incorreto ou a etiqueta nunca foi impressa.");
                                
                            }
                        }
                        catch (Exception exx)
                        {
                            throw new ExcecaoTratada("Erro ao reimprimir etiqueta.\r\n" + exx.Message);

                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada( "OC e/ou Pos inválido.");
                        return;
                    }
                }

                form.ShowDialog();
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbSemana_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbSemana.Checked)
            {
                this.grbSemana.Enabled = true;
                //this.txtOc.Enabled = false;
                //this.txtPos.Enabled = false;
                this.groupBox1.Enabled = false;
            }
            else
            {
                this.grbSemana.Enabled = false;
                this.groupBox1.Enabled = true;
                //this.txtOc.Enabled = true;
                //this.txtPos.Enabled = true;
            }
        }

        private void rdbOc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbSemana.Checked)
            {
                this.txtSemana.Enabled = true;
                //this.txtOc.Enabled = false;
                //this.txtPos.Enabled = false;
                this.groupBox1.Enabled = false;
            }
            else
            {
                this.txtSemana.Enabled = false;
                this.groupBox1.Enabled = true;
                //this.txtOc.Enabled = true;
                //this.txtPos.Enabled = true;
            }
        }
        #endregion

    }
}
