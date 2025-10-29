using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaEntidades.Relatorios
{
    public class ResumoEPIReportClass
    {
        public string FuncionarioNome { get; private set; }
        public string FuncionarioCpf { get; private set; }
        public string FUncionarioRG { get; private set; }

        public string FuncaoIdentificacao { get; private set; }
        public string FuncaoDescricao { get; private set; }
        public DateTime FuncaoDataInicio { get; private set; }
        public string FuncaoDataFim { get; private set; }
        private DateTime? FuncaoDataFimDate;


        public long EpiID { get; private set; }
        public string EpiIdentificacao { get; private set; }
        public string EpiDescricao { get; private set; }
        public string EpiDescricaoAdicional { get; private set; }
        public string EpiCA { get; private set; }
        public DateTime EpiDataRetirada { get; private set; }
        public string EpiDataDescartePrevista { get; private set; }
        public string EpiDataDescarte { get; private set; }


        private static byte[] logoCli;
        public byte[] LogoCliente
        {
            get
            {
                if (logoCli == null)
                {
                    loadLogoCli();
                }
                return logoCli;
            }
        }

        private void loadLogoCli()
        {
            #region Logo

            byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

            if (tmp != null)
            {
                MemoryStream ms = new MemoryStream(tmp);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                tmp = ms.ToArray();
                logoCli = tmp;
            }

            #endregion
        }

        public static List<ResumoEPIReportClass> GerarReport(FuncionarioClass funcionario, DateTime dataInicio, DateTime dataFim, IWTPostgreNpgsqlConnection conn)
        {
            List<ResumoEPIReportClass> toRet = new List<ResumoEPIReportClass>();
            List<ResumoEPIReportClass> funcoes = new List<ResumoEPIReportClass>();

            foreach (FuncionarioFuncaoClass funcao in funcionario.CollectionFuncionarioFuncaoClassFuncionario.OrderBy(a=>a.InicioVigencia))
            {

                if (funcao.InicioVigencia < dataFim && dataInicio < (funcao.FimVigencia ?? DataIndependenteClass.GetData()))
                {
                    //Entra no relatório
                    funcoes.Add(new ResumoEPIReportClass()
                    {
                        FuncionarioNome = funcionario.Nome,
                        FuncionarioCpf = funcionario.Cpf,
                        FUncionarioRG = funcionario.Rg,
                        FuncaoIdentificacao = funcao.Funcao.Identificacao,
                        FuncaoDescricao = funcao.Funcao.Descricao,
                        FuncaoDataInicio = funcao.InicioVigencia,
                        FuncaoDataFim = (funcao.FimVigencia.HasValue ? funcao.FimVigencia.Value.ToString("dd/MM/yyyy") : ""),
                        FuncaoDataFimDate = funcao.FimVigencia
                    });
                }
                else
                {
                    continue;
                }
                
            }

            foreach (FuncionarioEpiClass epi in funcionario.CollectionFuncionarioEpiClassFuncionario.Where(a => a.Situacao!=SituacaoFuncionarioEpi.Pendente).OrderBy(a=>a.DataRetirada).ThenBy(a=>a.DataDescarte))
            {
                if (epi.DataRetirada < dataFim && dataInicio < (epi.DataDescarte ?? DataIndependenteClass.GetData()))
                {

                    foreach (ResumoEPIReportClass funcaoRep in funcoes)
                    {
                        if (epi.DataRetirada < (funcaoRep.FuncaoDataFimDate ?? DataIndependenteClass.GetData()) && funcaoRep.FuncaoDataInicio < (epi.DataDescarte ?? DataIndependenteClass.GetData()))
                        {
                            toRet.Add(new ResumoEPIReportClass()
                            {
                                FuncionarioNome = funcaoRep.FuncionarioNome,
                                FuncionarioCpf = funcaoRep.FuncionarioCpf,
                                FUncionarioRG = funcaoRep.FUncionarioRG,
                                FuncaoIdentificacao = funcaoRep.FuncaoIdentificacao,
                                FuncaoDescricao = funcaoRep.FuncaoDescricao,
                                FuncaoDataInicio = funcaoRep.FuncaoDataInicio,
                                FuncaoDataFim = funcaoRep.FuncaoDataFim,
                                EpiID = epi.ID,
                                EpiIdentificacao = epi.Epi.Identificacao,
                                EpiDescricao = epi.Epi.Descricao,
                                EpiDescricaoAdicional = epi.Epi.DescricaoAdicional,
                                EpiCA = epi.Epi.EpiCa.ToString(),
                                EpiDataRetirada = epi.DataRetirada.Value,
                                EpiDataDescartePrevista = (epi.DataVencimentoPrevista.HasValue ? epi.DataVencimentoPrevista.Value.ToString("dd/MM/yyyy") : ""),
                                EpiDataDescarte = (epi.DataDescarte.HasValue ? epi.DataDescarte.Value.ToString("dd/MM/yyyy") : ""),
                            });
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
                else
                {
                    continue;
                }
            }



            return toRet;
        }
    }
}
