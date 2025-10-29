using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaEntidades.Relatorios
{
    public class EstoqueGavetaReportClass
    {
        private static byte[] _logoCliente;
        public string Estoque { get; private set; }
        public string EstoqueDescricao { get; private set; }
        public string Endereco { get; private set; }
        public string BarcodeTexto { get; private set; }
        public byte[] Barcode { get; private set; }


        public byte[] LogoEmpresa
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

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 135, 135, false);
                imagem.RotateFlip(RotateFlipType.Rotate90FlipNone);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                tmp = ms.ToArray();
                _logoCliente = tmp;
            }

            #endregion
        }

        public static List<EstoqueGavetaReportClass> Gerar(List<EstoqueGavetaClass> gavetas)
        {
            List<EstoqueGavetaReportClass> toRet = new List<EstoqueGavetaReportClass>();

            foreach (EstoqueGavetaClass gaveta in gavetas)
            {
                toRet.Add(new EstoqueGavetaReportClass()
                {
                    Estoque = gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.Identificacao,
                    EstoqueDescricao = gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.Descricao,
                    Endereco = gaveta.GetLocalizacaoCompletaSemNomeEstoque(),
                    Barcode = gaveta.Barcode,
                    BarcodeTexto = gaveta.BarcodeText

                });
            }


            return toRet;
        }

    }
}
