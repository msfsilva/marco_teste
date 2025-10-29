using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public class EtiquetaEnderecamentoReportClass
    {
        public string Nome { get; private set; }
        public string Endereço { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }

        static int resolucao = (int)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_DPI) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_DPI), CultureInfo.InvariantCulture) : 200);
        static float paginaAltura = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_ALTURA) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_ALTURA), CultureInfo.InvariantCulture) : 1);
        static float paginaLargura = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_LARGURA) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_LARGURA), CultureInfo.InvariantCulture) : 1);
        static float paginaMargemSuperior = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_SUP) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_SUP), CultureInfo.InvariantCulture) : 0);
        static float paginaMargemInferior = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_INF) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_INF), CultureInfo.InvariantCulture) : 0);
        static float paginaMargemEsquerda = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_ESQ) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_ESQ), CultureInfo.InvariantCulture) : 0);
        static float paginaMargemDireita = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_DIR) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_DIR), CultureInfo.InvariantCulture) : 0);
        static float etiquetaAltura = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_ALTURA) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_ALTURA), CultureInfo.InvariantCulture) : 1);
        static float etiquetaLargura = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LARGURA) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LARGURA), CultureInfo.InvariantCulture) : 1);
        static float etiquetaIntervaloHorizontal = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_HOR) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_HOR), CultureInfo.InvariantCulture) : 0);
        static float etiquetaIntevaloVertical = (float)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_VER) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_VER), CultureInfo.InvariantCulture) : 0);
        static int etiquetaColunas = (int)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_COLUNAS) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_COLUNAS), CultureInfo.InvariantCulture) : 1);
        static int etiquetaLinhas = (int)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LINHAS) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LINHAS), CultureInfo.InvariantCulture) : 1);
        static float multiplicadorDPImm = (float)(resolucao / 25.4);

        public static List<EtiquetaEnderecamentoReportClass> GerarEtiquetas(List<ClienteClass> clientes, bool gerarEtiquetaRemetente, IWTPostgreNpgsqlConnection SingleConnection)
        {
            try
            {
                List<EtiquetaEnderecamentoReportClass> toRet = new List<EtiquetaEnderecamentoReportClass>();
                EtiquetaEnderecamentoReportClass remetente = null;

                if (gerarEtiquetaRemetente)
                {
                    
                    CidadeClass cidade = CidadeBaseClass.GetEntidade(int.Parse(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CIDADE)), LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                    remetente = new EtiquetaEnderecamentoReportClass()
                                    {
                                        Nome = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_RAZAO),
                                        Endereço = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_ENDERECO) + ", " + IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_NUMERO) +
                                                   (string.IsNullOrWhiteSpace(IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COMPLEMENTO)) ? "" : " - " + IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_COMPLEMENTO)),
                                        Cep = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CEP),
                                        Cidade = cidade.Nome,
                                        Estado = cidade.Estado.Sigla
                                    };
                }

                foreach (ClienteClass cliente in clientes)
                {
                    toRet.Add(new EtiquetaEnderecamentoReportClass()
                                  {
                                      Nome = cliente.Nome,
                                      Endereço = cliente.Endereco + ", " + cliente.EnderecoNumero + (string.IsNullOrWhiteSpace(cliente.Complemento) ? "" : " - " + cliente.Complemento),
                                      Cep = cliente.Cep,
                                      Cidade = cliente.Cidade.Nome,
                                      Estado = cliente.Estado.Sigla
                                  });
                    if (gerarEtiquetaRemetente)
                    {
                        toRet.Add(remetente);
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
                throw new Exception("Erro inesperado ao montar as etiquetas de endereçamento. \r\n" + e.Message, e);
            }


        }


        public static List<Bitmap> GerarEtiquetasBmp(List<EtiquetaEnderecamentoReportClass> etiquetas, int linha, int coluna)
        {
            try
            {
                List<Bitmap> toRet = new List<Bitmap>();


               





                Bitmap paginaAtual = null;
                Graphics g = null;


                int linhaAtual = linha;
                int colunaAtual = coluna;






                foreach (EtiquetaEnderecamentoReportClass etiqueta in etiquetas)
                {



                    if (paginaAtual == null)
                    {
                        paginaAtual = new Bitmap((int) (paginaLargura*multiplicadorDPImm), (int) (paginaAltura*multiplicadorDPImm));
                        paginaAtual.SetResolution(resolucao, resolucao);
                        g = Graphics.FromImage(paginaAtual);

                        g.TextRenderingHint = TextRenderingHint.AntiAlias; //I also tried ClearTypeGridFit
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.CompositingMode = CompositingMode.SourceOver;
                    }

                    //Printa uma etiqueta



                    EtiquetaEnderecamentoReportClass.GetUmaEtiquetaBmp(
                        etiqueta,
                        colunaAtual,
                        linhaAtual,
                        ref g);


                    //Prepara para a próxima

                    colunaAtual++;

                    if (colunaAtual == etiquetaColunas)
                    {
                        linhaAtual = linhaAtual + 1;
                        colunaAtual = 0;
                    }

                    if (linhaAtual == etiquetaLinhas)
                    {
                        //Atingi a última etiqueta possível dessa página, começar uma nova
                        toRet.Add(paginaAtual);
                        paginaAtual = null;
                        linhaAtual = 0;
                        colunaAtual = 0;
                    }


                }

                if (paginaAtual!=null)
                {
                    toRet.Add(paginaAtual);
                }

                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inexperado ao gerar as etiquetas de clientes.\r\n" + e.Message, e);
            }

        }

        private static void GetUmaEtiquetaBmp(EtiquetaEnderecamentoReportClass etiqueta, int colunaAtual, int linhaAtual, ref Graphics g)
        {
            
            Pen p = new Pen(Color.Black);
            Font fTitulos = new Font("Arial", 10, FontStyle.Bold);
            Font f = new Font("Arial", 10, FontStyle.Regular);
            Brush b = new SolidBrush(Color.Black);


            

            RectangleF rec = new RectangleF(
                (paginaMargemEsquerda + (colunaAtual*etiquetaIntervaloHorizontal) + (colunaAtual*etiquetaLargura))*multiplicadorDPImm,
                (paginaMargemSuperior + (linhaAtual*etiquetaIntevaloVertical) + (linhaAtual*etiquetaAltura))*multiplicadorDPImm,
                (etiquetaLargura)*multiplicadorDPImm,
                (etiquetaAltura)*multiplicadorDPImm
                );


            #region Nome

            string textoNome = etiqueta.Nome;
            while (g.MeasureString(textoNome, fTitulos).Width > etiquetaLargura * multiplicadorDPImm)
            {
                if (textoNome.Length <= 5)
                    break;
                textoNome = textoNome.Substring(0, textoNome.Length - 1);
            }

            g.DrawString(
                textoNome,
                fTitulos,
                b,
                (paginaMargemEsquerda + (colunaAtual*etiquetaIntervaloHorizontal) + (colunaAtual*etiquetaLargura) + 1)*multiplicadorDPImm,
                (paginaMargemSuperior + (linhaAtual*etiquetaIntevaloVertical) + (linhaAtual*etiquetaAltura) + 1)*multiplicadorDPImm
                );
            #endregion

            #region Endereço

            string textoEndereco = etiqueta.Endereço;
            string textoEnderecoLinha2 = "";

            while (g.MeasureString(textoEndereco, f).Width > etiquetaLargura * multiplicadorDPImm)
            {
                if (textoEndereco.Length <= 5)
                    break;
                textoEnderecoLinha2 = (textoEndereco.Length - 2) + textoEnderecoLinha2;
                textoEndereco = textoEndereco.Substring(0, textoEndereco.Length - 1);
                
            }

            g.DrawString(
                textoEndereco,
                f,
                b,
                (paginaMargemEsquerda + (colunaAtual * etiquetaIntervaloHorizontal) + (colunaAtual * etiquetaLargura) + 1) * multiplicadorDPImm,
                (paginaMargemSuperior + (linhaAtual * etiquetaIntevaloVertical) + (linhaAtual * etiquetaAltura) + 8) * multiplicadorDPImm
                );

            if (!string.IsNullOrEmpty(textoEnderecoLinha2))
            {
                while (g.MeasureString(textoEnderecoLinha2, f).Width > etiquetaLargura * multiplicadorDPImm)
                {
                    if (textoEnderecoLinha2.Length <= 5)
                        break;
                    textoEnderecoLinha2 = textoEnderecoLinha2.Substring(0, textoEnderecoLinha2.Length - 1);

                }

                g.DrawString(
                    textoEnderecoLinha2,
                    f,
                    b,
                    (paginaMargemEsquerda + (colunaAtual*etiquetaIntervaloHorizontal) + (colunaAtual*etiquetaLargura) + 1)*multiplicadorDPImm,
                    (paginaMargemSuperior + (linhaAtual*etiquetaIntevaloVertical) + (linhaAtual*etiquetaAltura) + 15)*multiplicadorDPImm
                    );
            }

            #endregion

            #region CidadeEstado

            string textoCidadeEstado = etiqueta.Cidade + " - " + etiqueta.Estado;
            while (g.MeasureString(textoCidadeEstado, f).Width > etiquetaLargura * multiplicadorDPImm)
            {
                if (textoCidadeEstado.Length <= 5)
                    break;
                textoCidadeEstado = textoCidadeEstado.Substring(0, textoCidadeEstado.Length - 1);
            }

            g.DrawString(
                textoCidadeEstado,
                f,
                b,
                (paginaMargemEsquerda + (colunaAtual * etiquetaIntervaloHorizontal) + (colunaAtual * etiquetaLargura) + 1) * multiplicadorDPImm,
                (paginaMargemSuperior + (linhaAtual * etiquetaIntevaloVertical) + (linhaAtual * etiquetaAltura) + 22) * multiplicadorDPImm
                );
            #endregion

            #region CEP

            string textoCEP = "CEP: "+etiqueta.Cep;
            while (g.MeasureString(textoCEP, f).Width > etiquetaLargura * multiplicadorDPImm)
            {
                if (textoCEP.Length <= 5)
                    break;
                textoCEP = textoCEP.Substring(0, textoCEP.Length - 1);
            }

            g.DrawString(
                textoCEP,
                f,
                b,
                (paginaMargemEsquerda + (colunaAtual * etiquetaIntervaloHorizontal) + (colunaAtual * etiquetaLargura) + 1) * multiplicadorDPImm,
                (paginaMargemSuperior + (linhaAtual * etiquetaIntevaloVertical) + (linhaAtual * etiquetaAltura) + 29) * multiplicadorDPImm
                );
            #endregion



            //g.DrawRectangle(p, rec.X, rec.Y, rec.Width, rec.Height);

            
        }

    }
}
