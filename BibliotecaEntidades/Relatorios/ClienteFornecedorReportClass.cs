using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaEntidades.Relatorios
{
    public class ClienteFornecedorReportClass
    {
        private readonly ClienteClass _cliente;
        private readonly FornecedorClass _fornecedor;

        public string Nome
        {
            get {
                return _cliente != null ? _cliente.Nome : _fornecedor.RazaoSocial;
            }
        }
        public string NomeResumido
        {
            get
            {
                return _cliente != null ? _cliente.NomeResumido : _fornecedor.NomeFantasia;
            }
        }
        public string Agrupador
        {
            get
            {
                return _cliente != null ? _cliente.FamiliaCliente.ToString() : "";
            }
        }
        public string CNPJ
        {
            get
            {
                return _cliente != null ? _cliente.Cnpj : _fornecedor.Cnpj;
            }
        }
        public string IE
        {
            get
            {
                return _cliente != null ? _cliente.Ie : _fornecedor.InscEstadual;
            }
        }
        public string Fone1
        {
            get
            {
                string toRet = _cliente != null ? _cliente.Fone1 : _fornecedor.Fone1;

                if (_cliente != null && !string.IsNullOrEmpty(_cliente.Ramal1))
                {
                    toRet += " R " + _cliente.Ramal1;
                }

                return toRet;
            }
        }
        public string Email
        {
            get
            {
                return _cliente != null ? _cliente.Email : _fornecedor.Email;
            }
        }
        public string Contato
        {
            get
            {
                return _cliente != null ? _cliente.CompradorCliente : _fornecedor.Contato;
            }
        }


        //Endereço Principal
        public string Endereco
        {
            get
            {
                string toRet = _cliente != null ? _cliente.EnderecoCob + ", " + _cliente.EnderecoNumeroCob : _fornecedor.Endereco + ", " + _fornecedor.EndNumero;
                if (_cliente != null)
                {
                    if (!string.IsNullOrWhiteSpace(_cliente.ComplementoCob))
                    {
                        toRet += " - " + _cliente.ComplementoCob;
                    }

                    if (!string.IsNullOrWhiteSpace(_cliente.BairroCob))
                    {
                        toRet += " - " + _cliente.BairroCob;
                    }

                }


                if (_fornecedor != null)
                {
                    if (!string.IsNullOrWhiteSpace(_fornecedor.EndComplemento))
                    {
                        toRet += " - " + _fornecedor.EndComplemento;
                    }

                    if (!string.IsNullOrWhiteSpace(_fornecedor.Bairro))
                    {
                        toRet += " - " + _fornecedor.Bairro;
                    }

                }
                

                return toRet;
            }
        }
        public string CEP
        {
            get
            {
                return _cliente != null ? _cliente.CepCob : _fornecedor.Cep;
            }
        }
        public string Cidade
        {
            get
            {
                if (_cliente != null && _cliente.Cidade != null)
                {
                    return _cliente.Cidade.NomeCompleto;
                }

                if (_fornecedor != null && _fornecedor.Cidade != null)
                {
                    return _fornecedor.Cidade.NomeCompleto;
                }
                return "";
            }
        }

        public string Representante
        {
            get
            {
                if (_cliente != null && _cliente.Representante != null)
                {
                    return _cliente.Representante.ToString();
                }
                return "";
            }
        }

        public string Vendedor
        {
            get
            {
                if (_cliente != null && _cliente.Vendedor != null)
                {
                    return _cliente.Vendedor.ToString();
                }
                return "";
            }
        }


        public static byte[] _logoCliente = null;
        public byte[] LogoCliente
        {
            get
            {
                if (_logoCliente == null)
                {
                    LoadLogoCliente();
                }

                return _logoCliente;
            }
        }

        private static void LoadLogoCliente()
        {

            #region Logo

            byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

            if (tmp != null)
            {
                MemoryStream ms = new MemoryStream(tmp);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                tmp = ms.ToArray();
                _logoCliente = tmp;
            }

            #endregion
        }

        public ClienteFornecedorReportClass(ClienteClass cliente, FornecedorClass fornecedor)
        {
            _cliente = cliente;
            _fornecedor = fornecedor;

            if (_cliente != null && _fornecedor != null)
            {
                throw new Exception("Informe somente o cliente ou o fonecedor.");
            }

            if (_cliente == null && _fornecedor == null)
            {
                throw new Exception("Informe o cliente ou o fonecedor.");
            }
        }


        public static List<ClienteFornecedorReportClass> getClientes(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection conn)
        {
            ClienteClass search = new ClienteClass(usuarioAtual, conn);
            List<ClienteFornecedorReportClass> toRet =
                search.Search(new List<SearchParameterClass>() {new SearchParameterClass("Nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)})
                    .ToList()
                    .ConvertAll(a => new ClienteFornecedorReportClass((ClienteClass) a, null));

            return toRet;
        }

        public static List<ClienteFornecedorReportClass> getFornecedores(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection conn)
        {
            FornecedorClass search = new FornecedorClass(usuarioAtual, conn);
            List<ClienteFornecedorReportClass> toRet =
                search.Search(new List<SearchParameterClass>() {new SearchParameterClass("RazaoSocial", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)})
                    .ToList()
                    .ConvertAll(a => new ClienteFornecedorReportClass(null, (FornecedorClass) a));

            return toRet;
        }
    }
}
