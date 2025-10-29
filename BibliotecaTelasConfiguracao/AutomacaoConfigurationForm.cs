#region Referencias

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTFunctions;
using IWTNF.Entidades.Entidades;
using ProjectConstants;

#endregion

namespace BibliotecaTelasConfiguracao
{
    public partial class AutomacaoConfigurationForm : IWTBaseForm
    {
        private Dictionary<string, X509Certificate2> certificados;


        private EmitenteClass  _emitentePrimario;
        private EmitenteClass _emitenteSecundario;

        public AutomacaoConfigurationForm()
        {

            InitializeComponent();          

            if (IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)=="0")
            {
                this.grbCertificado.Visible = false;
            }
            else
            {
                PisCofinsInfo tmp2;
                NotaFiscalFuncoesAuxiliares.CarregaEmitente(SingleConnection, out _emitentePrimario, EasiEmissorNFe.Primario, out tmp2);

                if (IWTConfiguration.Conf.getBoolConf(Constants.EMITENTE_NF_SECUNDARIO_HABILITADO))
                {
                    NotaFiscalFuncoesAuxiliares.CarregaEmitente(SingleConnection, out _emitenteSecundario, EasiEmissorNFe.Secundario, out tmp2);
                }
                else
                {
                    this.label2.Visible = false;
                    this.cmbCertificadosSecundario.Visible = false;
                }

                this.carregarCertificados();
            }
        }



        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this.grbCertificado.Visible)
            {
                this.salvarCertificados();
            }

            IWTConfiguration.Conf.RefreshConfs();
            this.Close();
        }

   
        private void carregarCertificados()
        {
            try
            {

                certificados = new Dictionary<string, X509Certificate2>();

                this.cmbCertificados.Items.Clear();
                this.cmbCertificados.DataSource = null;

                this.cmbCertificadosSecundario.Items.Clear();
                this.cmbCertificadosSecundario.DataSource = null;

                X509Store store = new X509Store(StoreName.My);
                store.Open(OpenFlags.ReadOnly);

                List<LoadClass> ds = new List<LoadClass>();
                foreach (X509Certificate2 certificate in store.Certificates)
                {
                    if (Configurations.DataIndependenteClass.GetData() <= certificate.NotAfter && Configurations.DataIndependenteClass.GetData() >= certificate.NotBefore)
                    {
                        if (certificate.SerialNumber != null)
                        {
                            certificados.Add(certificate.SerialNumber, certificate);
                            cmbCertificados.Items.Add(certificate.SerialNumber + " (" + certificate.Subject + ")");
                            cmbCertificadosSecundario.Items.Add(certificate.SerialNumber + " (" + certificate.Subject + ")");
                        }
                    }
                }

                string certificado = _emitentePrimario.SerialCertificado;
                if (!string.IsNullOrWhiteSpace(certificado))
                {
                    foreach (string item in this.cmbCertificados.Items)
                    {
                        if (item.StartsWith(certificado + " ("))
                        {
                            this.cmbCertificados.SelectedItem = item;
                        }
                    }
                }


                if (IWTConfiguration.Conf.getBoolConf(Constants.EMITENTE_NF_SECUNDARIO_HABILITADO))
                {
                    string certificadoSecundario = _emitenteSecundario.SerialCertificado;
                    if (!string.IsNullOrWhiteSpace(certificadoSecundario))
                    {
                        foreach (string item in this.cmbCertificadosSecundario.Items)
                        {
                            if (item.StartsWith(certificadoSecundario + " ("))
                            {
                                this.cmbCertificadosSecundario.SelectedItem = item;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os certificados\r\n" + e.Message, e);
            }
        }

        private string salvarCertificados()
        {
            
            
            string err = "";
            if (cmbCertificados.SelectedItem != null)
            {
                string numeroSerie = this.cmbCertificados.SelectedItem.ToString().Substring(0, this.cmbCertificados.SelectedItem.ToString().IndexOf("(", StringComparison.Ordinal)).Trim();

                _emitentePrimario.SerialCertificado = certificados[numeroSerie].SerialNumber;
                
                NotaFiscalFuncoesAuxiliares.SalvaEmitente(_emitentePrimario,EasiEmissorNFe.Primario);

                

            }

            if (IWTConfiguration.Conf.getBoolConf(Constants.EMITENTE_NF_SECUNDARIO_HABILITADO))
            {
                if (cmbCertificadosSecundario.SelectedItem != null)
                {
                    string numeroSerie = this.cmbCertificadosSecundario.SelectedItem.ToString().Substring(0, this.cmbCertificadosSecundario.SelectedItem.ToString().IndexOf("(", StringComparison.Ordinal)).Trim();

                    _emitenteSecundario.SerialCertificado = certificados[numeroSerie].SerialNumber;
                
                    NotaFiscalFuncoesAuxiliares.SalvaEmitente(_emitenteSecundario,EasiEmissorNFe.Secundario);

                }
            }

            return err;
        }

    }
}
