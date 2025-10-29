#region Referencias

using System;
using System.Collections.Generic;
using System.IO;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCompras
{
    public class EnviaOrcamentoEmailClass : EnvioEmailClass
    {
        readonly string Empresa;
        long idOrc;
        Stream pdfOrc;
        List<Stream> Anexos;
        List<string> NomesAnexos;
        private string corpoEmail;

        public EnviaOrcamentoEmailClass(string empresa, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
            : base( usuario,conn)
        {      
            this.Empresa = empresa;
        }


        public override string getTituloEmail()
        {
            return "Solicitação de Orçamento Nº. " + idOrc + " - " + this.Empresa;
        }

        public override string getCorpoEmail()
        {
            if (string.IsNullOrEmpty(corpoEmail))
            {
                return "Favor avaliar Solicitação de Orçamento em anexo.";
            }
            else
            {
                return this.corpoEmail;
            }
        }

        public override bool isHtmlEmail()
        {
            return false;
        }

        public void setOrc(long idOrc, Stream pdfOrc)
        {
            this.idOrc = idOrc;
            this.pdfOrc = pdfOrc;
        }

        public void Enviar(string Destinatario, string Remetente, string CorpoEmail)
        {
            this.corpoEmail = CorpoEmail;
            string nome = "COTACAO_" + idOrc + ".pdf";
            
            List<Stream> anexosEnviar = new List<Stream>(){pdfOrc};
            List<string> nomesAnexosEnviar = new List<string>(){ nome };
           
            base.EnviaEmail(Destinatario, Remetente, anexosEnviar, nomesAnexosEnviar);
        }
    }
}
