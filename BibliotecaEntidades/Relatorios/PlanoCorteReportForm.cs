using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib;

namespace BibliotecaEntidades.Relatorios
{
    public class PlanoCorteReportForm : IWTReportForm
    {
        private readonly PlanoCorteClass _planoCorte;

        public PlanoCorteReportForm(PlanoCorteClass planoCorte)
            : base("Plano de Corte")
        {
            _planoCorte = planoCorte;
        }

        protected override ReportDocument InitReportCustom()
        {
            try
            {
                List<PlanoCorteReportClass> ds = PlanoCorteReportClass.ImprimirPlanoCorte(_planoCorte, SingleConnection);

                if (ds.Count == 0)
                {
                    throw new ExcecaoTratada("Não existem dados de itens com quantidade para impressão desse plano de corte");
                }

                List<PlanoCorteLocalMaterialReportClass> dsMateriais = new List<PlanoCorteLocalMaterialReportClass>();
                foreach (PlanoCorteReportClass item in ds)
                {
                    foreach (PlanoCorteLocalMaterialReportClass localEstoque in item.LocaisEstoque)
                    {
                        if (!dsMateriais.Any(a => a.Equals(localEstoque)))
                        {
                            dsMateriais.Add(localEstoque);
                        }
                    }
                }

                ds = ds.Distinct().ToList();

                PlanoCorteReport toRet = new PlanoCorteReport();
                toRet.SetDataSource(ds);
                toRet.Subreports[0].SetDataSource(dsMateriais.Count==0?null:dsMateriais);
                toRet.SetParameterValue("usuario", LoginClass.UsuarioLogado.loggedUser.Login);
                

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o relatório do plano de corte.\r\n" + e.Message, e);
            }
        }
    }
}
