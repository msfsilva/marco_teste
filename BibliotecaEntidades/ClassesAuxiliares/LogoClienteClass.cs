using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurations;
using ProjectConstants;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public static class LogoEmpresaClass
    {
        public static byte[] GetLogo(int largura, int altura, bool girar = false)
        {
            byte[] logoBd = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

            if (logoBd == null) return null;

            byte[] tmp = new byte[logoBd.Length];

            for (int i = 0; i < logoBd.Length; i++)
            {
                tmp[i] = logoBd[i];
            }

            MemoryStream ms = new MemoryStream(tmp);
            MemoryStream mOut = new MemoryStream();

            Image imagem = Image.FromStream(ms);

            if (girar)
            {
                imagem.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, largura, altura, false);

            imagem.Save(mOut, ImageFormat.Bmp);
            return mOut.ToArray();


        }
    }
}
