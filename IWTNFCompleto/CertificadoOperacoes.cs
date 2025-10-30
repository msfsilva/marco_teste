using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using Configurations;

namespace IWTNFCompleto
{
    public static class CertificadoOperacoes
    {
        public static X509Certificate2 BuscaCertficado(string serialCertificado)
        {
            try
            {
                X509Certificate2 certificado = null;
                X509Store store = new X509Store(StoreName.My);
                store.Open(OpenFlags.ReadOnly);

                //X509Certificate2Collection collection = store.Certificates.Find(X509FindType.FindBySerialNumber, serialCertificado, false);
                foreach (X509Certificate2 certificate in store.Certificates)
                {
                    if (certificate.SerialNumber != null && certificate.SerialNumber.Equals(serialCertificado, StringComparison.InvariantCulture))
                    {
                        certificado = certificate;
                        break;
                    }
                }

                if (certificado == null)
                {
                    store = new X509Store(StoreName.TrustedPublisher);
                    store.Open(OpenFlags.ReadOnly);

                    foreach (X509Certificate2 certificate in store.Certificates)
                    {
                        if (certificate.SerialNumber != null && certificate.SerialNumber.Equals(serialCertificado, StringComparison.InvariantCulture))
                        {
                            certificado = certificate;
                            break;
                        }
                    }

                    if (certificado == null)
                    {
                        throw new Exception("Não foi encontrado nenhum certificado cadastrado com o serial " + serialCertificado + ", certifique-se que o certificado foi cadastrado corretamente no repositório de certificados do windows.");
                    }
                }


                if (DataIndependenteClass.GetData() < certificado.NotBefore)
                {
                    throw new Exception("O certificado selecionado não pode ser utilizado antes de " + certificado.NotBefore);
                }

                if (DataIndependenteClass.GetData() > certificado.NotAfter)
                {
                    throw new Exception("O certificado selecionado está vencido, ele não pode ser utilizado após " + certificado.NotAfter);
                }

                //if (!certificado.Verify())
                //{

                string diagnostico = "";
                try
                {
                    X509Chain chain = new X509Chain();
                    chain.ChainPolicy = new X509ChainPolicy()
                    {
                        RevocationMode = X509RevocationMode.NoCheck,
                        //VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid,
                        //UrlRetrievalTimeout = new TimeSpan(0, 1, 0)
                    };
                    var chainBuilt = chain.Build(certificado);

                    if (chainBuilt == false)
                    {
                        diagnostico += (string.Format("Chain building status: {0}", chainBuilt)) + Environment.NewLine;
                        foreach (X509ChainStatus chainStatus in chain.ChainStatus)
                        {
                            diagnostico += string.Format("Chain error: {0} {1}", chainStatus.Status, chainStatus.StatusInformation) + Environment.NewLine;
                        }
                    }

                }
                catch (Exception e)
                {
                    diagnostico += "Erro ao obter as informações de diagnostico: " + e.Message;
                }

                if (!string.IsNullOrWhiteSpace(diagnostico))
                {
                    throw new Exception("O certificado selecionado (" + certificado.FriendlyName + ") não é um certificado válido." + Environment.NewLine + diagnostico);
                }
                //}


                return certificado;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o certificado.\r\n" + e.Message, e);
            }
        }


        public static void AssinaDocumento(X509Certificate2 certificado, ref XmlDocument documentoXml, string URI)
        {
            try
            {
                if (documentoXml == null)
                {
                    throw new Exception("Documento Inválido para ser assinado: NULL");
                }

                if (certificado == null)
                {
                    throw new Exception("Certificado Inválido: NULL");
                }




            

                

              
                RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider) certificado.PrivateKey;
                

                // Create a SignedXml object.
                SignedXml signedXml = new SignedXml(documentoXml);

                // Add the key to the SignedXml document.
                signedXml.SigningKey = rsaKey;

                // Get the signature object from the SignedXml object.
                Signature XMLSignature = signedXml.Signature;

                // Create a reference to be signed.
                Reference reference = new Reference();
                reference.Uri = URI;


                // Add an enveloped transformation to the reference.
                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                System.Security.Cryptography.Xml.XmlDsigC14NTransform env2 = new XmlDsigC14NTransform();
                reference.AddTransform(env);
                reference.AddTransform(env2);

                // Add the reference to the SignedXml object.
                signedXml.AddReference(reference);



                // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
                KeyInfo keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(certificado));

                // Add the KeyInfo object to the Reference object.
                XMLSignature.KeyInfo = keyInfo;

                // Compute the signature.

                // Compute the signature.
                signedXml.ComputeSignature();

                // Get the XML representation of the signature and save
                // it to an XmlElement object.
                XmlElement xmlDigitalSignature = signedXml.GetXml();

                // Append the element to the XML document.
                if (documentoXml.DocumentElement == null)
                {
                    throw new Exception("Documento Inválido para ser assinado: Document Element");
                }

                documentoXml.DocumentElement.AppendChild(documentoXml.ImportNode(xmlDigitalSignature, true));
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao assinar o documento.\r\n" + e.Message, e);
            }
        }

        public static void AssinaDocumento(X509Certificate2 certificado, ref XmlElement documentoXml, string URI)
        {
            try
            {
                if (documentoXml == null)
                {
                    throw new Exception("Documento Inválido para ser assinado: NULL");
                }

                if (certificado == null)
                {
                    throw new Exception("Certificado Inválido: NULL");
                }

                RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)certificado.PrivateKey;
                
                // Create a SignedXml object.
                SignedXml signedXml = new SignedXml(documentoXml);

                // Add the key to the SignedXml document.
                signedXml.SigningKey = rsaKey;

                // Get the signature object from the SignedXml object.
                Signature XMLSignature = signedXml.Signature;

                // Create a reference to be signed.
                Reference reference = new Reference();
                reference.Uri = URI;


                // Add an enveloped transformation to the reference.
                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                System.Security.Cryptography.Xml.XmlDsigC14NTransform env2 = new XmlDsigC14NTransform();
                reference.AddTransform(env);
                reference.AddTransform(env2);

                // Add the reference to the SignedXml object.
                signedXml.AddReference(reference);



                // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
                KeyInfo keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(certificado));

                // Add the KeyInfo object to the Reference object.
                XMLSignature.KeyInfo = keyInfo;

                // Compute the signature.

                // Compute the signature.
                signedXml.ComputeSignature();

                // Get the XML representation of the signature and save
                // it to an XmlElement object.
                XmlElement xmlDigitalSignature = signedXml.GetXml();


                if (documentoXml.OwnerDocument != null)
                    documentoXml.AppendChild(documentoXml.OwnerDocument.ImportNode(xmlDigitalSignature, true));
                else
                {
                    throw new Exception("Documento Inválido para ser assinado: OwnerDocument");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao assinar o documento.\r\n" + e.Message, e);
            }
        }
    }
}
