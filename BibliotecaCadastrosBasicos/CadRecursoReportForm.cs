using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;

using PaperSize = CrystalDecisions.Shared.PaperSize;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadRecursoReportForm : IWTBaseForm
    {
        private readonly List<int> _idsRecursos;
        private readonly AcsUsuarioClass _user;

        public CadRecursoReportForm(List<int> idsRecursos, AcsUsuarioClass user)
        {
            _idsRecursos = idsRecursos;
            _user = user;
            InitializeComponent();
        }

        private void initReport()
        {
            try
            {
                RecursoDataSet ds = new RecursoDataSet();
                RecursoDataSet.recursosRow row;

                if (_idsRecursos == null || _idsRecursos.Count==0)
                {
                    throw new Exception("Selecione ao menos um recurso para gerar a etiqueta.");
                }

                string sql =
                    _idsRecursos.Aggregate("", (current, id) => current + (" OR recurso.id_recurso = " + id + " ")).
                        Substring(3);


                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText =
                    "SELECT " +
                    "  public.familia_recurso.far_identificacao, " +
                    "  public.recurso.rec_codigo, " +
                    "  public.recurso.rec_nome, " +
                    "  public.recurso.rec_revisao, " +
                    "  CASE public.recurso.rec_tipo WHEN 0 THEN 'Normal' WHEN 1 THEN 'Formulário' WHEN 2 THEN 'CNC' ELSE '' END as tipo, " +
                    "  public.posto_trabalho.pos_codigo, " +
                    "  public.estoque.est_identificacao || ' - ' || " +
                    "  public.estoque_corredor.esc_identificacao || ' - ' || " +
                    "  public.estoque_prateleira.esp_identificacao || ' - ' || " +
                    "  public.estoque_gaveta.esg_identificacao as armazenamento " +
                    "FROM " +
                    "  public.recurso " +
                    "  INNER JOIN public.familia_recurso ON (public.recurso.id_familia_recurso = public.familia_recurso.id_familia_recurso) " +
                    "  INNER JOIN public.posto_trabalho ON (public.recurso.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) " +
                    "  LEFT OUTER JOIN public.estoque_gaveta_item ON (public.recurso.id_recurso = public.estoque_gaveta_item.id_recurso) " +
                    "  LEFT OUTER JOIN public.estoque_gaveta ON (public.estoque_gaveta_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                    "  LEFT OUTER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) " +
                    "  LEFT OUTER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) " +
                    "  LEFT OUTER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) " +
                    "WHERE " +
                    "  (public.estoque_gaveta_item.egi_ativo = 1 OR  " +
                    "  public.estoque_gaveta_item.egi_ativo IS NULL) AND " + sql;

                 IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    row = ds.recursos.NewrecursosRow();
                    row.descricao = read["rec_nome"].ToString();
                    row.estoque = read["armazenamento"].ToString();
                    row.familia = read["far_identificacao"].ToString();
                    row.identificacao = read["rec_codigo"].ToString();
                    row.posto_trabalho = read["pos_codigo"].ToString();
                    row.revisao = read["rec_revisao"].ToString();
                    row.tipo = read["tipo"].ToString();
                    row.usuario = this._user.Login;
                    ds.recursos.AddrecursosRow(row);
                }
                read.Close();

                CadRecursoReport rep = new CadRecursoReport();
                rep.SetDataSource(ds);

                string printer = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PRINTER);
                string paper = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PAPER);

                try
                {
                    int j;
                    Boolean found1 = false;
                    string PaperList = "";
                    int rawKind1 = 0;
                    PrintDocument doctoprint = new PrintDocument();
                    doctoprint.PrinterSettings.PrinterName = printer;

                    if (!doctoprint.PrinterSettings.IsValid)
                    {
                        string PrinterList = "Você deve selecionar entre uma das impressoras abaixo, coloca-la na configuração e gerar o relatório novamente.\r\n";
                        foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                        {
                            PrinterList += "\r\n" + strPrinter;
                        }
                        MessageBox.Show("Impressora de Etiquetas não encontrada!\r\n\r\n" + PrinterList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        PrinterSettings.PaperSizeCollection paperSizeCollection = doctoprint.PrinterSettings.PaperSizes;
                        for (j = 0; j < paperSizeCollection.Count; j++)
                        {

                            PaperList += "\r\n" + paperSizeCollection[j].PaperName;
                            if (paperSizeCollection[j].PaperName == paper)
                            {
                                rawKind1 = (int)(paperSizeCollection[j].GetType().GetField("kind", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(paperSizeCollection[j]));
                                found1 = true;
                            }
                        }

                        if (!found1)
                        {
                            MessageBox.Show("Papel da Etiqueta não encontrado!\r\n Você deve selecionar entre os papeis abaixo, coloca-lo na configuração e gerar o relatório novamente.\r\n" + PaperList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        rep.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                        rep.PrintOptions.PaperSize = (PaperSize)rawKind1;
                    }
                }
                catch (Exception r)
                {
                    MessageBox.Show("Erro ao definir o tipo de papel correto! \r\n" + r, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                this.crystalReportViewer1.ReportSource = rep;
                this.crystalReportViewer1.RefreshReport();
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as etiquetas.\r\n" + e.Message, e);
            }
        }

        private void CadRecursoReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.initReport();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
