using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BibliotecaEntidades.Entidades;
using Configurations;
using ProjectConstants;

namespace BibliotecaEntidades.Relatorios
{
    public class EpiVencidoReportClass
    {
        private readonly FuncionarioEpiClass funcionarioEpi;
        private readonly byte[] logoCli;
        private readonly DateTime? venceAte;

        public EpiVencidoReportClass(FuncionarioEpiClass funcionarioEpi, DateTime? venceAte)
        {
            this.funcionarioEpi = funcionarioEpi;
            this.venceAte = venceAte;

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

        public long IdFuncionario
        {
            get { return this.funcionarioEpi.Funcionario.ID; }
        }

        public string NomeFuncionario
        {
            get { return this.funcionarioEpi.Funcionario.Nome; }
        }

        public string RGFuncionario
        {
            get { return this.funcionarioEpi.Funcionario.Rg; }
        }

        public string IdentificacaoEpi
        {
            get { return this.funcionarioEpi.Epi.Identificacao; }
        }

        public string DescricaoEpi
        {
            get { return this.funcionarioEpi.Epi.Descricao; }
        }

        public DateTime DataVencimento
        {
            get { return (DateTime) this.funcionarioEpi.DataVencimentoPrevista; }
        }

        public byte[] LogoCliente
        {
            get { return this.logoCli; }
        }

        public string VenceAte
        {
            get { return venceAte != null ? "Vencimentos Previstos até " + this.venceAte.Value.ToString("dd/MM/yyyy") : ""; }
        }

        

    }
}
