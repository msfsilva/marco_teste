using System;
using Configurations;
using ProjectConstants;

namespace BibliotecaEntidades.Operacoes.EnvioEmail
{
    public class ServidorEmailClass
    {
        public bool SmtpSsh { get; set; }
        public string SmtpServer { get; set; }
        public int? SmtpPort { get; set; }
        public bool SmtpAuthentication { get;  set; }
        public string SmtpUser { get;  set; }
        public string SmtpPassword { get;  set; }
        
        
        public string RemetentePadrao{ get;  set; }

        public ServidorEmailClass(string smtpServer, int? smtpPort, bool smtpAuthentication,bool smtpSSH, string smtpUser, string smtpPassword)
        {
            SmtpSsh = smtpSSH;
            SmtpServer = smtpServer;
            SmtpPort = smtpPort;
            SmtpAuthentication = smtpAuthentication;
            SmtpUser = smtpUser;
            SmtpPassword = smtpPassword;
        }


        public static ServidorEmailClass GetServidorEmailPadrao()
        {


            int? smtpPort = null;
            try
            {
                smtpPort = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.SMTP_PORT));
            }
            catch
            {
            }


            return new ServidorEmailClass(
                IWTConfiguration.Conf.getConf(Constants.SMTP_HOST),
                smtpPort,
                IWTConfiguration.Conf.getBoolConf(Constants.SMTP_AUTHENTICATION),
                IWTConfiguration.Conf.getBoolConf(Constants.SMTP_AUTHENTICATION_SSH),
                IWTConfiguration.Conf.getConf(Constants.SMTP_USER),
                IWTConfiguration.Conf.getConf(Constants.SMTP_PASSWORD)
            )
            {
                RemetentePadrao = IWTConfiguration.Conf.getConf(Constants.PEDIDO_EMAIL_REMETENTE)
            };
        }
    }
}
