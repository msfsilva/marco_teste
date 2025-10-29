#region Referencias

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;

#endregion

namespace BibliotecaEmail
{
    public abstract class EnvioEmailClass
    {
        private readonly ServidorEmailClass _servidor;

        protected EnvioEmailClass(string smtpServer, int? smtpPort, bool smtpAuthentication,bool smtpSSH, string smtpUser, string smtpPassword)
        {
            
            _servidor = new ServidorEmailClass(smtpServer, smtpPort, smtpAuthentication, smtpSSH, smtpUser, smtpPassword);

        }

        protected EnvioEmailClass(ServidorEmailClass servidor)
        {
            _servidor = servidor;

        }

        protected void EnviaEmail(string emailTo, string emailFrom, List<string> Attachments)
        {

            List<Attachment> atta = new List<Attachment>();
            if (Attachments != null)
            {
                foreach (string attach in Attachments)
                {
                    atta.Add(new Attachment(attach));
                }
            }

            enviaEmail(emailTo, emailFrom, atta);

        }

        protected void EnviaEmail(string emailTo, string emailFrom, List<Stream> Attachments, List<string> streamNames)
        {
            List<Attachment> atta = new List<Attachment>();
            if (Attachments != null)
            {
                for (int i = 0; i < Attachments.Count; i++)
                {
                    if (streamNames!=null && i < streamNames.Count)
                    {
                        atta.Add(new Attachment(Attachments[i], streamNames[i]));
                    }
                    else
                    {
                        atta.Add(new Attachment(Attachments[i], "FILE_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")));
                    }
                }
            }

            enviaEmail(emailTo, emailFrom, atta);

        }

        private void enviaEmail(string emailTo, string emailFrom, List<Attachment> Attachments)
        {
            EnviaEmailDireto(emailTo, getTituloEmail(), getCorpoEmail(), isHtmlEmail(), Attachments, _servidor, emailFrom);

        }

        public abstract string getTituloEmail();
        public abstract string getCorpoEmail();
        public abstract bool isHtmlEmail();

        public static void EnviaEmailDireto(string destinatario, string titulo, string conteudo, bool isHtml,List<Attachment> anexos, ServidorEmailClass servidor, string remetente = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(destinatario))
                {
                    throw new Exception("Email do destinatário inválido");
                }


                if (string.IsNullOrWhiteSpace(remetente))
                {
                    remetente = servidor.RemetentePadrao;
                }

            

                BufferEmailClass


               
                message.Subject = titulo;
                message.Body = conteudo;

                if (anexos != null)
                {
                    foreach (Attachment attach in anexos)
                    {
                        message.Attachments.Add(attach);
                    }
                }
                message.IsBodyHtml = isHtml;

                smtp.Send(message);
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                Exception x = e.InnerException;
                while (x!=null)
                {
                    mensagem += Environment.NewLine + x.Message;
                    x = x.InnerException;
                }
                throw new Exception("Erro ao enviar o email.\r\n" + mensagem);
            }
        }
    }
}
