using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaEntidades.Relatorios
{
    public class OrdemProducaoMateriaisReportClass
    {
        public long NumeroOp { get; private set; }
        public DateTime DataCriacaoOp { get; private set; }
        public DateTime DataEncerramentoOp { get; private set; }
        public string CodigoProduto { get; private set; }
        public double Quantidade { get; private set; }

        public string CodigoMaterial { get; private set; }
        public double QuantidadeMaterial { get; private set; }

        public static byte[] _logoCliente = null;
        public byte[] LogoCliente
        {
            get
            {
                if (_logoCliente == null)
                {
                    LoadLogoCliente();
                }

                return _logoCliente;
            }
        }

        private static void LoadLogoCliente()
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
                _logoCliente = tmp;
            }

            #endregion
        }


        public static List<OrdemProducaoMateriaisReportClass> Gerar(DateTime dataInicio, DateTime dataFim, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<OrdemProducaoMateriaisReportClass> toRet = new List<OrdemProducaoMateriaisReportClass>();

                List<OrdemProducaoClass> ops = new OrdemProducaoClass(usuario,conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("DataEncerramentoInicio",dataInicio),
                    new SearchParameterClass("DataEncerramentoFim",dataFim),
                    new SearchParameterClass("Situacao",StatusOrdemProducao.Encerrada),
                    new SearchParameterClass("ID",null,SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Numerica)
                }).ToList().ConvertAll(a => ((OrdemProducaoClass)a));

                foreach (OrdemProducaoClass op in ops)
                {
                    
                    foreach (OrdemProducaoMaterialClass material in op.CollectionOrdemProducaoMaterialClassOrdemProducao)
                    {
                        toRet.Add(new OrdemProducaoMateriaisReportClass()
                        {
                            CodigoMaterial = material.Material.CodigoComFamilia,
                            QuantidadeMaterial = material.Quantidade,
                            CodigoProduto = op.ProdutoCodigo,
                            DataEncerramentoOp = op.DataEncerramento.Value,
                            DataCriacaoOp = op.Data,
                            NumeroOp = op.ID,
                            Quantidade = op.Quantidade
                            
                        });
                    }
                }


                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao gerar o relatório de materiais das OPs.\r\n" + e.Message, e);
            }

        }

    }
}
