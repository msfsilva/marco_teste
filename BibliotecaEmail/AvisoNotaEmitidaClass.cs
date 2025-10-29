namespace BibliotecaEmail
{
    public class AvisoNotaEmitidaClass: EnvioEmailClass
    {
        readonly string nomeEmpresa;
        readonly string enderecoSistemaDentroRede;
        readonly string enderecoSistemaForaRede;
        readonly string emailTo;
        readonly string emailFrom;



        public AvisoNotaEmitidaClass(string nomeEmpresa, string enderecoSistemaDentroRede, string enderecoSistemaForaRede, string emailTo, string emailFrom, string smtpServer, int? smtpPort, bool smtpAuthentication,bool smtpSSH, string smtpUser, string smtpPassword)
            : base( smtpServer, smtpPort, smtpAuthentication,smtpSSH, smtpUser, smtpPassword)
        {
            this.nomeEmpresa = nomeEmpresa;
            this.enderecoSistemaDentroRede = enderecoSistemaDentroRede;
            this.enderecoSistemaForaRede = enderecoSistemaForaRede;
            this.emailTo = emailTo;
            this.emailFrom = emailFrom;
        }

        public override string getTituloEmail()
        {
            return "Aviso de Nota Fiscal Emitida (" + this.nomeEmpresa + ")";
        }

        public override string getCorpoEmail()
        {
            return
                "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\"> " +
                "<html> " +
                "<head> " +
                "  <meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\"> " +
                "  <meta name=\"generator\" content=\"IWT\"> " +
                "  <title>Aviso de Emissão de Nota Fiscal</title> " +
                "</head> " +
                "   <body> " +
                    "Foi emitida uma nova nota fiscal no sistema EASI da empresa " + this.nomeEmpresa + " <br> " +
                    "Para acompanhar o que foi emitido você pode acessar o relatório online no endereço:<br> " +
                    "<a href=" + this.enderecoSistemaDentroRede + ">Acesso ao EASI (Dentro da rede da empresa) </a><br>" +
                    "<a href=" + this.enderecoSistemaForaRede + ">Acesso ao EASI (Fora da rede da empresa) </a><br>" +
                "   </body> " +
                "</html>";
        }

        public override bool isHtmlEmail()
        {
            return true;
        }

        public void Enviar()
        {
            base.EnviaEmail(this.emailTo, this.emailFrom, null);
        }
    }
}
