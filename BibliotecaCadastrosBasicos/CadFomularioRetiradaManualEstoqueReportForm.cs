using System;
using System.Collections.Generic;
using BibliotecaCadastrosBasicos.ClassesAuxiliares;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using Configurations;
using IWTDotNetLib;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFomularioRetiradaManualEstoqueReportForm : IWTBaseForm
    {
        public CadFomularioRetiradaManualEstoqueReportForm(List<FomularioRetiradaManualEstoqueClass> formularios, bool etiqueta, bool automatico)
        {
            InitializeComponent();
            CrystalDecisions.CrystalReports.Engine.ReportClass rep;
            if (automatico)
            {
                string tipo = IWTConfiguration.Conf.getConf(Constants.TIPO_FORMULARIO_MOVIMENTACAO);

                if (tipo == null) throw new Exception("Não há configuração do tipo do formulário de movimentação");

                if (tipo == "0")
                {
                    rep = new FomularioRetiradaManualEstoqueReport();

                }
                else
                {
                    rep = new FomularioRetiradaManualEstoqueEtqReport();

                }
            }
            else
            {
                if (etiqueta)
                {
                    rep = new FomularioRetiradaManualEstoqueEtqReport();

                }
                else
                {
                    rep = new FomularioRetiradaManualEstoqueReport();

                }
            }

            rep.SetDataSource(formularios.ConvertAll(a => new FomularioRetiradaManualEstoqueReportClass(a)));
            this.crystalReportViewer1.ReportSource = rep;
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
