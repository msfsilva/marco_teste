using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadRetiradaEpiReportForm : IWTBaseForm
    {
        private readonly List<FuncionarioClass> _funcionarios;
        private readonly List<FuncionarioEpiClass> _funcionarioEpis;
        private readonly AcsUsuarioClass _user;

        public CadRetiradaEpiReportForm(List<FuncionarioClass> funcionarios, List<FuncionarioEpiClass> funcionarioEpis, AcsUsuarioClass user)
        {
            _funcionarios = funcionarios;
            _funcionarioEpis = funcionarioEpis;
            _user = user;
            InitializeComponent();
        }

        private void initReport()
        {
            try
            {
                List<RetiradaEpiReportClass> epis = _funcionarioEpis.Select(epi => new RetiradaEpiReportClass(epi)).ToList();
                List<RetiradaEpiFuncionarioReportClass> funcionarios = _funcionarios.Select(funcionario => new RetiradaEpiFuncionarioReportClass(funcionario)).ToList();

                RetiradaEpiReport rep = new RetiradaEpiReport();                
                rep.SetDataSource(funcionarios);               
                rep.Subreports[0].SetDataSource(epis);
                rep.Subreports[1].SetDataSource(epis);
                rep.SetParameterValue(0,"Impresso por " + _user + " em " + Configurations.DataIndependenteClass.GetData().ToString("dd/MM/yyyy"));
                
                this.crystalReportViewer1.ReportSource = rep;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o recibo de retirada de EPIs.\r\n" + e.Message, e);
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
