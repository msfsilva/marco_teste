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
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTNFCompleto.BibliotecaEntidades.EntidadesAlteradas.Entidades;
using IWTPostgreNpgsql;

namespace IWTNFCompleto
{
    public enum TipoEmailNF
    {
        ClienteDanfe,
        ClienteXML,
        ClienteAmbos,
        CopiaDanfe,
        CopiaXML,
        CopiaAmbos
    }



    public class EnvioEmailNFe
    {


        private readonly byte[] _logoDanfe;

        public EnvioEmailNFe(byte[] logoDanfe)
        {
            _logoDanfe = logoDanfe;
        }

        public void enviaEmail(string emailTo, RetornoNFe nota, NfeCompletoNotaClass notaEmitida, TNfeProc nfe, Stream xml, string xmlNome, Stream danfe, string danfeNome, TipoEmailNF tipoEmail, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command, string remetente)
        {

            try
            {
                if (!utilizarBufferEmail(command))
                {
                    enviaEmailDireto(emailTo, nota, notaEmitida, nfe, xml, xmlNome, danfe, danfeNome, tipoEmail,remetente );
                }
                else
                {
                    enviaEmailBuffer(emailTo, nota, notaEmitida, nfe, xml, xmlNome, danfe, danfeNome, tipoEmail, usuario, command, remetente);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar o email.\r\n" + e.Message);
            }
        }

        private void adicionarAnexos(NfeCompletoNotaClass nota, TipoEmailNF tipoEmail, ref MailMessage message, TNfeProc nfe, Stream xml, string xmlNome, Stream danfe, string danfeNome)
        {
            if (danfe != null)
            {
                danfe.Seek(0, SeekOrigin.Begin);
            }

            if (xml != null)
            {
                xml.Seek(0, SeekOrigin.Begin);
            }


            switch (tipoEmail)
            {
                case TipoEmailNF.ClienteDanfe:
                    if (danfe != null)
                    {
                        message.Attachments.Add(new Attachment(danfe, danfeNome));
                    }

                    break;
                case TipoEmailNF.ClienteXML:
                    if (xml != null)
                    {
                        message.Attachments.Add(new Attachment(xml, xmlNome));
                    }

                    break;
                case TipoEmailNF.ClienteAmbos:
                    if (danfe != null)
                    {
                        message.Attachments.Add(new Attachment(danfe, danfeNome));
                    }

                    if (xml != null)
                    {
                        message.Attachments.Add(new Attachment(xml, xmlNome));
                    }

                    break;
                case TipoEmailNF.CopiaDanfe:
                    if (danfe != null)
                    {
                        message.Attachments.Add(new Attachment(danfe, danfeNome));
                    }

                    break;
                case TipoEmailNF.CopiaXML:
                    if (xml != null)
                    {
                        message.Attachments.Add(new Attachment(xml, xmlNome));
                    }

                    break;
                case TipoEmailNF.CopiaAmbos:
                    if (danfe != null)
                    {
                        message.Attachments.Add(new Attachment(danfe, danfeNome));
                    }

                    if (xml != null)
                    {
                        message.Attachments.Add(new Attachment(xml, xmlNome));
                    }

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
                        return "DANFE " + nfe.NFe.infNFe.emit.xFant + " - NFe " + nota.Numero;
                        break;
                    case TipoEmailNF.ClienteXML:
                    case TipoEmailNF.CopiaXML:
                        return "XML " + nfe.NFe.infNFe.emit.xFant + " - NFe " + nota.Numero;
                        break;
                    case TipoEmailNF.ClienteAmbos:
                    case TipoEmailNF.CopiaAmbos:
                        return "NFe " + nfe.NFe.infNFe.emit.xFant + " - NFe " + nota.Numero;
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
                        return "Você está recebendo o DANFE da NFe nº " + nota.Numero + " emitida por " + nfe.NFe.infNFe.emit.xFant;
                        break;
                    case TipoEmailNF.ClienteXML:
                        return "Você está recebendo o XML da NFe nº " + nota.Numero + " emitida por " + nfe.NFe.infNFe.emit.xFant;
                        break;
                    case TipoEmailNF.ClienteAmbos:
                        return "Você está recebendo o DANFE e o XML da NFe nº " + nota.Numero + " emitida por " + nfe.NFe.infNFe.emit.xFant;
                        break;
                    case TipoEmailNF.CopiaDanfe:
                        return "Você está recebendo uma cópia do DANFE da NFe nº " + nota.Numero + " emitida por " + nfe.NFe.infNFe.emit.xFant;
                        break;
                    case TipoEmailNF.CopiaXML:
                        return "Você está recebendo uma cópia do XML da NFe nº " + nota.Numero + " emitida por " + nfe.NFe.infNFe.emit.xFant;
                        break;
                    case TipoEmailNF.CopiaAmbos:
                        return "Você está recebendo uma cópia do DANFE e o XML da NFe nº " + nota.Numero + " emitida por " + nfe.NFe.infNFe.emit.xFant;
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


        private bool utilizarBufferEmail(IWTPostgreNpgsqlCommand command)
        {
            command.CommandText =
                "    SELECT EXISTS( " +
                "    SELECT 1 " +
                " FROM   information_schema.tables " +
                " WHERE  table_schema = 'public' " +
                " AND    table_name = 'buffer_email' " +
                "                );";

            return Convert.ToBoolean(command.ExecuteScalar());
        }



        private void enviaEmailDireto(string emailTo, RetornoNFe nota, NfeCompletoNotaClass notaEmitida, TNfeProc nfe, Stream xml, string xmlNome, Stream danfe, string danfeNome, TipoEmailNF tipoEmail, string remetente)
        {
            if (emailTo != "")
            {
                string smtpServer;
                int? smtpPort;
                bool smtpAuthentication;
                bool smtpAuthenticationSSH;
                string smtpUser;
                string smtpPassword;
        

                smtpServer = IWTConfiguration.Conf.getConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_HOST);
                smtpPort = int.Parse(IWTConfiguration.Conf.getConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_PORT));
                smtpAuthentication = IWTConfiguration.Conf.getBoolConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_AUTHENTICATION);
                smtpAuthenticationSSH = IWTConfiguration.Conf.getBoolConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_AUTHENTICATION_SSH);
                smtpUser = IWTConfiguration.Conf.getConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_USER);
                smtpPassword = IWTConfiguration.Conf.getConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_PASSWORD);
        


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
                            if (smtpAuthenticationSSH)
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
                    this.adicionarAnexos(notaEmitida, tipoEmail, ref message, nfe, xml, xmlNome, danfe, danfeNome);

                    message.IsBodyHtml = true;
                    smtp.Send(message);

                }

            }
            else
            {
                throw new Exception("Email do destinatário inválido");
            }
        }


        private void enviaEmailBuffer(string emailTo, RetornoNFe nota, NfeCompletoNotaClass notaEmitida, TNfeProc nfe, Stream xml, string xmlNome, Stream danfe, string danfeNome, TipoEmailNF tipoEmail, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command, string remetente)
        {


            


            if (string.IsNullOrWhiteSpace(remetente))
            {
                throw new Exception("Email do remetente inválido");
            }


            List<string> destinatarios = new List<string>();

            if (!string.IsNullOrWhiteSpace(emailTo))
            {
                List<string> tmp = new List<string>(emailTo.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries));
                foreach (string des in tmp)
                {
                    destinatarios.AddRange(des.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries));
                }
            }


            if (destinatarios.Count == 0) return;

            foreach (string destinatario in destinatarios)
            {
                BufferEmail2Class message = new BufferEmail2Class(usuario, command.Connection)
                {
                    Titulo = this.getTituloEmail(tipoEmail, notaEmitida, nfe),
                    CorpoHtml = 1,
                    CorpoMensagem = this.getCorpoEmail(tipoEmail, notaEmitida, nfe),
                    DataEntrada = DataIndependenteClass.GetData(),
                    Destinatario = destinatario,
                    Remetente = remetente,
                    Situacao = BufferEmailSituacao.Pendente,
                    NumeroTentativasEnvio = 0
                };

                this.adicionarAnexosBuffer(notaEmitida, tipoEmail, ref message, nfe, xml, xmlNome, danfe, danfeNome, usuario, command.Connection);

                message.Save(ref command);
            }
            
        }

        private void adicionarAnexosBuffer(NfeCompletoNotaClass nota, TipoEmailNF tipoEmail, ref BufferEmail2Class message, TNfeProc nfe, Stream xml, string xmlNome, Stream danfe, string danfeNome, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            byte[] danfeBytes = null;
            if (danfe != null)
            {
                danfe.Seek(0, SeekOrigin.Begin);
                using (MemoryStream ms = new MemoryStream())
                {
                    danfe.CopyTo(ms);
                    danfeBytes = ms.ToArray();
                }

            }

            byte[] xmlBytes = null;
            if (xml != null)
            {
                xml.Seek(0, SeekOrigin.Begin);
                using (MemoryStream ms = new MemoryStream())
                {
                    xml.CopyTo(ms);
                    xmlBytes = ms.ToArray();
                }
            }





            switch (tipoEmail)
            {
                case TipoEmailNF.CopiaDanfe:
                case TipoEmailNF.ClienteDanfe:
                    if (danfeBytes != null)
                    {
                        message.CollectionBufferEmailAnexoClassBufferEmail.Add(new BufferEmailAnexo2Class(usuario, conn)
                        {
                            BufferEmail2 = message,
                            Arquivo = danfeBytes,
                            NomeArquivo = danfeNome
                        });
                    }

                    break;

                case TipoEmailNF.CopiaXML:
                case TipoEmailNF.ClienteXML:
                    if (xmlBytes != null)
                    {
                        message.CollectionBufferEmailAnexoClassBufferEmail.Add(new BufferEmailAnexo2Class(usuario, conn)
                        {
                            BufferEmail2 = message,
                            Arquivo = xmlBytes,
                            NomeArquivo = xmlNome
                        });
                    }

                    break;
                case TipoEmailNF.CopiaAmbos:
                case TipoEmailNF.ClienteAmbos:
                    if (danfeBytes != null)
                    {
                        message.CollectionBufferEmailAnexoClassBufferEmail.Add(new BufferEmailAnexo2Class(usuario, conn)
                        {
                            BufferEmail2 = message,
                            Arquivo = danfeBytes,
                            NomeArquivo = danfeNome
                        });
                    }

                    if (xmlBytes != null)
                    {
                        message.CollectionBufferEmailAnexoClassBufferEmail.Add(new BufferEmailAnexo2Class(usuario, conn)
                        {
                            BufferEmail2 = message,
                            Arquivo = xmlBytes,
                            NomeArquivo = xmlNome
                        });
                    }


                    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoEmail");
            }

        }
    }
}
