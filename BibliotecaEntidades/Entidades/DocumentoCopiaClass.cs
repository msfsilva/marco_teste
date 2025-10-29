using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

using iTextSharp.text.pdf;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades
{
    public class DocumentoCopiaClass : DocumentoCopiaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do DocumentoCopiaClass";
        protected new const string ErroDelete = "Erro ao excluir o DocumentoCopiaClass  ";
        protected new const string ErroSave = "Erro ao salvar o DocumentoCopiaClass.";
        protected new const string ErroCollectionLiberacaoDocumentoClassDocumentoCopia = "Erro ao carregar a coleção de LiberacaoDocumentoClass.";
        protected new const string ErroCollectionEstoqueGavetaItemClassDocumentoCopia = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
        protected new const string ErroCollectionOrdemProducaoDocumentoClassDocumentoCopia = "Erro ao carregar a coleção de OrdemProducaoDocumentoClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do DocumentoCopiaClass.";
        protected new const string MensagemUtilizadoCollectionLiberacaoDocumentoClassDocumentoCopia = "A entidade DocumentoCopiaClass está sendo utilizada nos seguintes LiberacaoDocumentoClass:";
        protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassDocumentoCopia = "A entidade DocumentoCopiaClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoDocumentoClassDocumentoCopia = "A entidade DocumentoCopiaClass está sendo utilizada nos seguintes OrdemProducaoDocumentoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade DocumentoCopiaClass está sendo utilizada.";

        #endregion

        

        private EstoqueGavetaItemClass _localizacaoEstoque = null;


        public DocumentoCopiaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public string LocalizacaoEstoqueString
        {
            get
            {
                if (LocalizacaoEstoque != null)
                {
                    return LocalizacaoEstoque.ToString();
                }
                return "";
            }

        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public EstoqueGavetaClass LocalizacaoEstoque
        {
            get
            {
                if (this._localizacaoEstoque == null)
                {
                    this._localizacaoEstoque = EstoqueMovimentacao.BuscaGavetaItemDocumentoCopia(this);
                }

                if (this._localizacaoEstoque!=null)
                {
                    return this._localizacaoEstoque.EstoqueGaveta;
                }
                return null;

            }
        }

        public EstoqueGavetaClass NovaLocalizacaoEstoque { get; set; }

        private byte[] _codigoBarras;
        public byte[] codigoBarras
        {
            get
            {
                if (this._codigoBarras == null)
                {
                    this.loadCodigoBarras();
                }
                return this._codigoBarras;
            }
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            
            if (NovaLocalizacaoEstoque == null)
            {
                return;
            }


            if (this.LocalizacaoEstoque == null)
            {
                EstoqueMovimentacao.LancaMovimentoEstoqueDocumentoCopia(this.NovaLocalizacaoEstoque, this, 1, "Criação de Cópia de documento", this.ToString(), this.UsuarioAtual, false, ref command);
            }
            else
            {
                if (!this.LocalizacaoEstoque.Equals(NovaLocalizacaoEstoque))
                {
                    EstoqueMovimentacao.TrocaItemGavetaTotalDocumentoCopia(this._localizacaoEstoque, NovaLocalizacaoEstoque, this, this.UsuarioAtual, ref command);
                }
            }

            this._localizacaoEstoque = null;
            this.NovaLocalizacaoEstoque = null;

        }

        public override string ToString()
        {
            return Identificacao;
        }

        public string IdentificacaoCompleta
        {
            get { return this.DocumentoTipoFamilia.FamiliaDocumento.Codigo + " " + DocumentoTipoFamilia.DocumentoTipo.Identificacao; }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }


        public void Liberar(ref IWTPostgreNpgsqlCommand command, string Justificativa)
        {
            try
            {


                OrdemProducaoDocumentoClass search = new OrdemProducaoDocumentoClass(this.UsuarioAtual, this.SingleConnection);
                List<OrdemProducaoDocumentoClass> opsDocumentos = search.Search(new List<SearchParameterClass>() {new SearchParameterClass("DocumentoCopia", this)}).ConvertAll(a => (OrdemProducaoDocumentoClass) a);

                //Dentre os documentos op mantem somente aqueles que fazem parte de pelo menos uma Op aberta
                opsDocumentos =
                    opsDocumentos.Where(
                        a => a.CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento.Any(b => b.OrdemProducao.Situacao == StatusOrdemProducao.AguardandoInicioProducao || b.OrdemProducao.Situacao == StatusOrdemProducao.Producao|| b.OrdemProducao.Situacao == StatusOrdemProducao.AguardandoServicoExterno)).ToList();

                //Dentre os documentos op mantem somente aqueles que não possuem nenhuma liberação 
               opsDocumentos = opsDocumentos.Where(a => a.CollectionLiberacaoDocumentoClassOrdemProducaoDocumento.Count == 0).ToList();


                foreach (OrdemProducaoDocumentoClass opDocumento in opsDocumentos)
                {
                    this.CollectionLiberacaoDocumentoClassDocumentoCopia.Add(new LiberacaoDocumentoClass(this.UsuarioAtual, this.SingleConnection)
                    {
                        DocumentoCopia = this,
                        AcsUsuario = this.UsuarioAtual,
                        Data = Configurations.DataIndependenteClass.GetData(),
                        Justificativa = Justificativa,
                        OrdemProducaoDocumento = opDocumento
                    });
                }

                this.Ocupada = false;

                this.Save(ref command);

                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao liberar a cópia\r\n" + e.Message, e);
            }
        }

        public static DocumentoCopiaClass loadFromBarcode(string barcode, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                int idCopia;

                barcode = barcode.Replace("\r", "").Replace("\n", "").Replace('}', '|');
                if (barcode.StartsWith("DC|"))
                {
                    idCopia = int.Parse(barcode.Substring(3));
                }
                else
                {
                    throw new Exception("Código de barras inválido.");
                }

                return DocumentoCopiaBaseClass.GetEntidade(idCopia, Usuario, conn);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a cópia\r\n" + e.Message, e);
            }
        }

        public void SetEtiquetaEmitida()
        {
            this.EtiquetaImpressa = true;
            this.DataImpressao = Configurations.DataIndependenteClass.GetData();
            this.AcsUsuarioImpressao = this.UsuarioAtual;

        }

        private void loadCodigoBarras()
        {
            try
            {
                if (this.ID == -1)
                {
                    return;
                }

                //string tempDir = Environment.GetEnvironmentVariable("temp");

                Barcode128 code128 = new Barcode128();
                code128.CodeType = Barcode.CODE128;
                code128.ChecksumText = true;
                code128.GenerateChecksum = true;
                code128.StartStopText = true;
                code128.BarHeight = 100;
                code128.Code = "DC|" + this.ID.ToString();
                Bitmap codeBar = new Bitmap(code128.CreateDrawingImage(Color.Black, Color.White));
                //codeBar.Save(@tempDir + "\\code.bmp");

                ImageConverter converter = new ImageConverter();
                this._codigoBarras = (byte[])converter.ConvertTo(codeBar, typeof(byte[]));

             

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o código de barras.\r\n" + e.Message, e);
            }

        }

        public string getUltimaUtilizacao()
        {
            try
            {
                if (this.ID == -1)
                {
                    return "";
                }



                List<OrdemProducaoDocumentoOpClass> documentoOps = new List<OrdemProducaoDocumentoOpClass>();
                foreach (OrdemProducaoDocumentoClass ordemProducaoDocumentoClass in this.CollectionOrdemProducaoDocumentoClassDocumentoCopia)
                {
                    documentoOps.AddRange(ordemProducaoDocumentoClass.CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento);
                }


                OrdemProducaoDocumentoOpClass tmp = documentoOps.OrderByDescending(a => a.OpData).FirstOrDefault();
                if (tmp == null) return "";

                return "OP "+tmp.OrdemProducao.ID+" - "+ tmp.OrdemProducao.SituacaoTraduzida;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar a ultima utilização da cópia.\r\n" + e.Message, e);
            }

        }
    }
}
