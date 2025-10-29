#region Referencias



#endregion

using System;
using System.Collections.Generic;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using IWTDotNetLib.ComplexLoginModule;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public enum CRTTipo { Simples = 1, SimplesExcesso = 2, Normal = 3 }

    public class EmitenteClass : IEquatable<EmitenteClass>
    {

        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }

        public string Cidade
        {
            get { return this._cidade.Nome; }
        }

        public string Estado
        {
            get { return this._cidade.Estado.Sigla; }
        }

        public string Pais
        {
            get { return this._cidade.Pais.Nome; }
        }

        public int CodigoPais
        {
            get { return this._cidade.Pais.Codigo; }
        }

        public string Telefone { get; set; }
        public string Fax { get; set; }
        public string Contato { get; set; }

        public string PisCst { get; set; }
        public double PisAliquota { get;  set; }
        public int PisModalidade { get;  set; }
        public bool PisImpostoRetido { get;  set; }

        public string CofinsCst { get;  set; }
        public double CofinsAliquota { get; set; }
        public int CofinsModalidade { get;  set; }
        public bool CofinsImpostoRetido { get;  set; }

        public CRTTipo Crt { get;  set; }


        public string PastaSaidaNFe { get;  set; }
        public string VersaoEmissorNFe { get;  set; }


        public int DiasPagamentoPadrao { get; set; }

        public bool AvisoNFAtivo { get; set; }
        public string AvisoNFRemetente { get; set; }
        public string AvisoNFDestinatario { get; set; }
        public string AvisoNFEnderecoInterno { get; set; }
        public string AvisoNFEnderecoExterno { get; set; }
        
        public string ObservacaoEmitente { get; set; }

        public string Cnae { get; set; }

        public string InscricaoMunicipal { get; set; }


        public ServidorEmailClass ServidorEmail { get; set; }

        public string SerialCertificado { get; set; }
        
        public CidadeClass _cidade;
        public CidadeClass CidadeEntidade
        {
            get { return this._cidade; }
            set { this._cidade = value; }
        }


        public string EnderecoCompleto
        {
            get
            {
                string toRet = this.Endereco;
                if (!string.IsNullOrWhiteSpace(this.Numero))
                {
                    toRet += ", " + this.Numero;
                }

                if (!string.IsNullOrWhiteSpace(this.Complemento))
                {
                    toRet += " - " + this.Complemento;
                }

                return toRet;
            }
        }

        public List<string> AutorizadosDownloadNf { get; set; }

        public DadosSalvarEnviarNfe DadosSalvarEnviarNfe { get; set; }

        public EmitenteClass(string razaoSocial, string cnpj, string inscricaoEstadual, string endereco, string numero, string complemento, string cep, string bairro, int idCidade,  string telefone, string fax, string contato, string pisCst, double pisAliquota, int pisModalidade, bool pisImpostoRetido, string cofinsCst, double cofinsAliquota, int cofinsModalidade, bool cofinsImpostoRetido, CRTTipo crt, string pastaSaidaNFe, string versaoEmissorNFe, int diasPagamentoPadrao, bool avisoNfAtivo, string avisoNfRemetente, string avisoNfDestinatario, string avisoNfEnderecoInterno, string avisoNfEnderecoExterno, ServidorEmailClass servidorEmail, string observacaoEmitente, string serialCertificado, IWTPostgreNpgsqlConnection singleConnection, List<string> autorizadosDownloadNf, string cnae, string inscricaoMunicipal, bool impressaoDanfe, string impressoraDanfe1, string impressoraDanfe2, bool envioNfeEmail, bool envioXml, string envioXmlDestino, bool envioDanfe, string envioDanfeDestino, bool envioNFeCliente, string envioNFeRemetente, bool arquivamentoNFe, string pastaDanfe, string pastaXml)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Telefone = telefone;
            Fax = fax;
            Contato = contato;
            PisCst = pisCst;
            PisAliquota = pisAliquota;
            PisModalidade = pisModalidade;
            PisImpostoRetido = pisImpostoRetido;
            CofinsCst = cofinsCst;
            CofinsAliquota = cofinsAliquota;
            CofinsModalidade = cofinsModalidade;
            CofinsImpostoRetido = cofinsImpostoRetido;
            Crt = crt;
            PastaSaidaNFe = pastaSaidaNFe;
            VersaoEmissorNFe = versaoEmissorNFe;
            DiasPagamentoPadrao = diasPagamentoPadrao;
            AvisoNFAtivo = avisoNfAtivo;
            AvisoNFRemetente = avisoNfRemetente;
            AvisoNFDestinatario = avisoNfDestinatario;
            AvisoNFEnderecoInterno = avisoNfEnderecoInterno;
            AvisoNFEnderecoExterno = avisoNfEnderecoExterno;
            ServidorEmail = servidorEmail;
            ObservacaoEmitente = observacaoEmitente;
            SerialCertificado = serialCertificado;
            Cnae = cnae;
            InscricaoMunicipal = inscricaoMunicipal;


            DadosSalvarEnviarNfe = new DadosSalvarEnviarNfe()
            {
                ImprimirDanfeHabilitado = impressaoDanfe,
                ImprimirDanfeImpressora1 = impressoraDanfe1,
                ImprimirDanfeImpressora2 = impressoraDanfe2,
                EnvioEmailHabilitado = envioNfeEmail,
                EnvioEmailXmlHhabilitado = envioXml,
                EnvioEmailXmlDestino = envioXmlDestino,
                EnvioEmailDanfeHabilitado = envioDanfe,
                EnvioEmailDanfeDestino = envioDanfeDestino,
                EnvioEmailClienteHabilitado = envioNFeCliente,
                EnvioEmailRemetente = envioNFeRemetente,
                SalvarPastaHabilitado = arquivamentoNFe,
                SalvarPastaDanfe= pastaDanfe,
                SalvarPastaXml = pastaXml
            };
            
            AutorizadosDownloadNf = autorizadosDownloadNf;

            if (idCidade > 0)
            {
                this._cidade = CidadeBaseClass.GetEntidade(idCidade, LoginClass.UsuarioLogado.loggedUser, singleConnection);
            }

        }

        public bool Equals(EmitenteClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(RazaoSocial, other.RazaoSocial) && string.Equals(Cnpj, other.Cnpj) && string.Equals(InscricaoEstadual, other.InscricaoEstadual);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EmitenteClass) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (RazaoSocial != null ? RazaoSocial.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Cnpj != null ? Cnpj.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InscricaoEstadual != null ? InscricaoEstadual.GetHashCode() : 0);
                return hashCode;
            }
        }

        private sealed class EmitenteClassEqualityComparer : IEqualityComparer<EmitenteClass>
        {
            public bool Equals(EmitenteClass x, EmitenteClass y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.RazaoSocial, y.RazaoSocial) && string.Equals(x.Cnpj, y.Cnpj) && string.Equals(x.InscricaoEstadual, y.InscricaoEstadual);
            }

            public int GetHashCode(EmitenteClass obj)
            {
                unchecked
                {
                    var hashCode = (obj.RazaoSocial != null ? obj.RazaoSocial.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Cnpj != null ? obj.Cnpj.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.InscricaoEstadual != null ? obj.InscricaoEstadual.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<EmitenteClass> EmitenteClassComparer { get; } = new EmitenteClassEqualityComparer();
    }
}
