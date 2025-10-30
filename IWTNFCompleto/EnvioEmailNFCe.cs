using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using CrystalDecisions.Shared;
using IWTDotNetLib;
using IWTNFCompleto.BibliotecaEntidades.Entidades;

namespace IWTNFCompleto
{


    public class EnvioEmailNFCe
    {
        private readonly string smtpServer;
        private readonly int? smtpPort;
        private readonly bool smtpAuthentication;
        private readonly bool smtpAuthenticationSSH;
        private readonly string smtpUser;
        private readonly string smtpPassword;
        private readonly string remetente;


        public EnvioEmailNFCe(string remetente)
        {
            this.smtpServer = IWTConfiguration.Conf.getConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_HOST);
            this.smtpPort = int.Parse(IWTConfiguration.Conf.getConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_PORT));
            this.smtpAuthentication = IWTConfiguration.Conf.getBoolConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_AUTHENTICATION);
            this.smtpAuthenticationSSH = IWTConfiguration.Conf.getBoolConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_AUTHENTICATION_SSH);
            this.smtpUser = IWTConfiguration.Conf.getConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_USER);
            this.smtpPassword = IWTConfiguration.Conf.getConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_PASSWORD);
            this.remetente = remetente;


            //if (ProxyClass.ComProxy)
            //{
            //    WebRequest.DefaultWebProxy = new WebProxy(ProxyClass.EnderecoProxy, false)
            //    {
            //        Credentials = new NetworkCredential(ProxyClass.UsuarioProxy, ProxyClass.SenhaProxy, ProxyClass.DomainProxy)
            //    };
            //}
        }

        public void enviaEmail(string emailTo, NfeCompletoNotaClass notaEmitida, TNfeProc nfe, Stream xml, string xmlNome, TipoEmailNF tipoEmail)
        {

            try
            {
                if (emailTo != "")
                {

                    MailMessage message = new MailMessage();
                    SmtpClient smtp;

                    if (smtpServer != null)
                    {
                        if (smtpPort != null)
                        {
                            smtp = new SmtpClient(smtpServer, (int) smtpPort);
                            
                        }
                        else
                        {
                            smtp = new SmtpClient(smtpServer);
                        }

                        if (smtpAuthentication)
                        {
                            //autenticado
                            if (smtpUser == null || smtpPassword == null)
                            {
                                throw new Exception("Usuário ou senha inválidos");
                            }
                            else
                            {
                                if (this.smtpAuthenticationSSH)
                                {
                                    smtp.EnableSsl = true;
                                }

                                smtp.Timeout = 600000;
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new NetworkCredential(smtpUser, smtpPassword);

                            }

                        }


                        if (remetente != null)
                        {
                            message.From = new MailAddress(remetente);
                        }
                        else
                        {
                            throw new Exception("Email do remetente inválido");
                        }


                        if (emailTo.Contains(';'))
                        {
                            string[] tmp = emailTo.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string email in tmp)
                            {
                                message.To.Add(email);
                            }
                        }
                        else
                        {
                            message.To.Add(emailTo);
                        }




                        message.Subject = this.getTituloEmail(tipoEmail, notaEmitida, nfe);
                        message.Body = this.getCorpoEmail(tipoEmail, notaEmitida, nfe);
                        this.adicionarAnexos( tipoEmail, ref message,  xml, xmlNome);

                        message.IsBodyHtml = true;
                        smtp.Send(message);
                        
                    }

                }
                else
                {
                    throw new Exception("Email do destinatário inválido");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar o email.\r\n" + e.Message);
            }
        }

        private void adicionarAnexos(TipoEmailNF tipoEmail, ref MailMessage message, Stream xml, string xmlNome)
        {
          

            if (xml != null)
            {
                xml.Seek(0, SeekOrigin.Begin);
            }


            switch (tipoEmail)
            {

                case TipoEmailNF.ClienteXML:
                    if (xml != null)
                    {
                        message.Attachments.Add(new Attachment(xml, xmlNome));
                    }
                    break;
                case TipoEmailNF.ClienteAmbos:

                    if (xml != null)
                    {
                        message.Attachments.Add(new Attachment(xml, xmlNome));
                    }



                    break;
                case TipoEmailNF.CopiaXML:
                    if (xml != null)
                    {
                        message.Attachments.Add(new Attachment(xml, xmlNome));
                    }
                    break;
                case TipoEmailNF.CopiaAmbos:

                    if (xml != null)
                    {
                        message.Attachments.Add(new Attachment(xml, xmlNome));
                    }
                    break;
                case TipoEmailNF.CopiaDanfe:
                case TipoEmailNF.ClienteDanfe:
                    throw new Exception("Não é possível enviar por email o danfe para NFCe");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoEmail");
            }

        }

       

        private string getTituloEmail(TipoEmailNF tipoEmail, NfeCompletoNotaClass nota, TNfeProc nfe)
        {
            String tituloCadastroBd = IWTConfiguration.Conf.getConf(NFeConstantes.NFE_TITULO_EMAIL);
            if (String.IsNullOrWhiteSpace(tituloCadastroBd))
            {
                switch (tipoEmail)
                {
                    case TipoEmailNF.ClienteDanfe:
                    case TipoEmailNF.CopiaDanfe:
                        throw new Exception("Não é possível enviar por email o danfe para NFCe");
                        break;
                    case TipoEmailNF.ClienteXML:
                    case TipoEmailNF.CopiaXML:
                    case TipoEmailNF.ClienteAmbos:
                    case TipoEmailNF.CopiaAmbos:
                        return "NFCe " + nfe.NFe.infNFe.emit.xFant + " - NFCe " + nota.Numero;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("tipoEmail");
                }
            }
            else
            {
                return tituloCadastroBd;
            }
        }

        private string getCorpoEmail(TipoEmailNF tipoEmail, NfeCompletoNotaClass nota, TNfeProc nfe)
        {
            String corpoEmailBd = IWTConfiguration.Conf.getConf(NFeConstantes.NFE_CORPO_EMAIL);
            if (String.IsNullOrWhiteSpace(corpoEmailBd))
            {
                switch (tipoEmail)
                {
                    case TipoEmailNF.ClienteDanfe:
                    case TipoEmailNF.CopiaDanfe:
                        throw new Exception("Não é possível enviar por email o danfe para NFCe");
                        break;
                    case TipoEmailNF.ClienteXML:
                    case TipoEmailNF.ClienteAmbos:

                        return "Você está recebendo o XML da NFCe nº " + nota.Numero + " emitida por " + nfe.NFe.infNFe.emit.xFant;
                        break;

                    case TipoEmailNF.CopiaXML:
                    case TipoEmailNF.CopiaAmbos:
                        return "Você está recebendo uma cópia do XML da NFCe nº " + nota.Numero + " emitida por " + nfe.NFe.infNFe.emit.xFant;
                        break;


                    default:
                        throw new ArgumentOutOfRangeException("tipoEmail");
                }
            }
            else
            {
                return corpoEmailBd;
            }
        }
    }
}
