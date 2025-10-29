using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using BibliotecaEntidades.Entidades;
using Configurations;
using ProjectConstants;

namespace BibliotecaEntidades.Relatorios
{
    public class BaixaEstoqueConsumoReportClass
    {
        private readonly EstoqueGavetaItemClass _item;

        public string Identificacao
        {
            get { return _item.CodigoItem; }
        }

        public string Descricao
        {
            get { return _item.DescricaoItem; }
        }

        public string TipoItem
        {
            get { return _item.TipoConteudoTela; }
        }

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

        public double QtdBaixada { get; private set; }


        public BaixaEstoqueConsumoReportClass(EstoqueGavetaItemClass item, double qtdBaixada)
        {
            _item = item;
            QtdBaixada = qtdBaixada;
        }
    }
}
