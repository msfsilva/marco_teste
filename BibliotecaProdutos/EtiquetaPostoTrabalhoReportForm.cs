#region Referencias

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaProdutos
{
    public partial class EtiquetaPostoTrabalhoReportForm : Form
    {
        readonly string idPosto;
        readonly IWTPostgreNpgsqlConnection conn;
        public EtiquetaPostoTrabalhoReportForm(string idPosto, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.idPosto = idPosto;
            this.conn = conn;

            this.fillReport();
        }

        private void fillReport()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  pos_codigo, " +
                    "  pos_nome, " +
                    "  pos_operacao, " +
                    "  pos_rastreamento, " +
                    "  pos_acompanhamento, " +
                    "  pos_produtivo " +
                    "FROM  " +
                    "  public.posto_trabalho " +
                    "WHERE " +
                    "  id_posto_trabalho = " + this.idPosto;

                NpgsqlDataReader read = command.ExecuteReader();

                EtiquetaPostoTrabalhoDataSet ds = new EtiquetaPostoTrabalhoDataSet();
                EtiquetaPostoTrabalhoDataSet.posto_trabalhoRow row;

                string tempDir = Environment.GetEnvironmentVariable("temp");

                Process process = new Process();
                process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                if (read.HasRows)
                {
                    read.Read();

                    row = ds.posto_trabalho.Newposto_trabalhoRow();
                    row.id_posto_trabalho = Convert.ToInt32(this.idPosto);

                    row.pos_codigo = read["pos_codigo"].ToString();
                    row.pos_nome = read["pos_nome"].ToString();
                    row.pos_operacao = read["pos_operacao"].ToString();
                    row.pos_acompanhamento = Convert.ToInt16(read["pos_acompanhamento"]);
                    row.pos_produtivo = Convert.ToInt16(read["pos_produtivo"]);
                    row.pos_rastreamento = Convert.ToInt16(read["pos_rastreamento"]);



                    process.StartInfo.Arguments = "IDPT|" + this.idPosto + " " + tempDir + "\\code.bmp";
                    process.Start();
                    process.WaitForExit();

                    Bitmap codeBar = new Bitmap(@tempDir + "\\code.bmp");
                    codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    codeBar.Save(@tempDir + "\\code.bmp");

                    FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] array = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    row.pos_barcode = array;

                    ds.posto_trabalho.Addposto_trabalhoRow(row);
                    read.Close();
                }
                else
                {
                    throw new Exception("ID Inválido");
                }

                EtiquetaPostoTrabalhoReport rep = new EtiquetaPostoTrabalhoReport();
                rep.SetDataSource(ds);
                this.crystalReportViewer1.ReportSource = rep;


            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao gerar a etiqueta.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
