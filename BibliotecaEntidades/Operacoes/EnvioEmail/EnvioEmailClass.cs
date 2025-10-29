#region Referencias

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.EnvioEmail
{
    public abstract class EnvioEmailClass
    {
        private readonly string _remetentePadrao;
        private readonly AcsUsuarioClass _usuario;
        private readonly IWTPostgreNpgsqlConnection _conn;
        
        protected EnvioEmailClass( AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn, string remetentePadrao = null)
        {
            _remetentePadrao = remetentePadrao;
            _usuario = usuario;
            _conn = conn;

            
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
            if (string.IsNullOrWhiteSpace(emailFrom))
            {
                emailFrom = _remetentePadrao;
            }
            EnviaEmailDireto(emailTo, emailFrom, getTituloEmail(), getCorpoEmail(), isHtmlEmail(), Attachments, _usuario,_conn);

        }

        public abstract string getTituloEmail();
        public abstract string getCorpoEmail();
        public abstract bool isHtmlEmail();

        public static void EnviaEmailDireto(string destinatario, string remetente, string titulo, string conteudo, bool isHtml,List<Attachment> anexos,  AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(destinatario))
                {
                    throw new Exception("Email do destinatário inválido");
                }


                if (string.IsNullOrWhiteSpace(remetente))
                {
                    throw new Exception("Email do remetente inválido");
                }

            
              
                BufferEmailClass message = new BufferEmailClass(usuario,conn)
                {
                    DataEntrada = DataIndependenteClass.GetData(),
                    CorpoHtml = isHtml,
                    CorpoMensagem = conteudo,
                    Destinatario = destinatario,
                    Remetente = remetente,
                    Titulo = titulo,
                    DataEnvio = null,
                    Situacao = BufferEmailSituacao.Pendente,
                    DataUltimaTentativa = null,
                    NumeroTentativasEnvio = 0,
                    UltimoErro = null

                };


                

                if (anexos != null)
                {
                    foreach (Attachment attach in anexos)
                    {
                        byte[] dados = null;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            attach.ContentStream.CopyTo(ms);
                            dados = ms.ToArray();
                        }

                        message.CollectionBufferEmailAnexoClassBufferEmail.Add(
                            new BufferEmailAnexoClass(usuario, conn)
                            {
                                Arquivo = dados,
                                NomeArquivo = attach.Name,
                                BufferEmail = message
                            });

                    }
                }

                message.Save();
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
