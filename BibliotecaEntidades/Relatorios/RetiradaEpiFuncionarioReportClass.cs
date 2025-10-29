using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BibliotecaEntidades.Entidades;
using Configurations;
using ProjectConstants;
using System.Linq;

namespace BibliotecaEntidades.Relatorios
{
    public class RetiradaEpiFuncionarioReportClass
    {
        private readonly FuncionarioClass funcionario;
        private readonly byte[] logoCli;

        public long Id
        {
            get { return this.funcionario.ID; }
        }

        public string nomeFuncionario
        {
            get { return this.funcionario.Nome; }
        }

        public string RGFuncionario
        {
            get { return this.funcionario.Rg; }
        }

        public string CPFFuncionario
        {
            get { return this.funcionario.Cpf; }
        }

        public byte[] LogoCliente
        {
            get { return this.logoCli; }
        }

        public RetiradaEpiFuncionarioReportClass(FuncionarioClass funcionario)
        {
            this.funcionario = funcionario;

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
                    this.logoCli = tmp;
                }

            #endregion
             
        }

        public string EmpresaCedente
        {
            get { return IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_RAZAO); }

        }

        public string Funcao
        {
            get
            {
                string toRet = this.funcionario.CollectionFuncionarioFuncaoClassFuncionario.Aggregate("", (current, funcao) => current + (funcao.Funcao.Identificacao + " / "));
                return toRet.Length > 0 ? toRet.Remove(toRet.Length - 3) : "";
            }
        }
    }
}
