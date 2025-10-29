using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoOc
    {
        private readonly int? _idProduto;
        private readonly AcsUsuarioClass _usuarioAtual;
        private readonly IWTPostgreNpgsqlConnection _conn;
        public int idOrderItemEtiqueta { get; set; }

        public string oc { get; set; }
        public string pos { get; set; }
        public bool semProduto { get; set; }
        public bool produtoCadastrado
        {
            get
            {
                return !semProduto;
            }
        }
        public string codProduto { get; set; }
        public string descProduto { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string revDocumento { get; set; }
        public string Cliente { get; set; }
        public string Dimensao { get; set; }
        public DateTime dataEntrega { get; set; }
        public bool opImpressa { get; set; }
        public DateTime? dataImpressaoOp { get; set; }
        public bool kit { get; set; }
        public string produtoCodigoAgrupador { get; set; }

        private bool _gerar = true;
        public bool Gerar
        {
            get { return _gerar; }
            set { _gerar = value; }
        }

        private ProdutoClass _produto;

        private bool _documentoMaisRestritivoLoaded = false;
        private string _documentoMaisRestritivo;

        public string getDocumentoMaisRestritivo(IWTPostgreNpgsqlCommand command)
        {
            
                if (!_documentoMaisRestritivoLoaded)
                {
                    LoadDocumentoMaisRestritivo(command);
                }
                return _documentoMaisRestritivo;
            
            
        }

        private void LoadDocumentoMaisRestritivo(IWTPostgreNpgsqlCommand command)
        {
            if (!semProduto)
            {
                if (_idProduto.HasValue)
                {
                    _produto = ProdutoClass.GetEntidade(_idProduto.Value, _usuarioAtual, _conn);
                    //List<ProdutoDocumentoTipoClass> docs = _produto.GetDocumentosFast(command);
                    List<ProdutoDocumentoTipoClass> docs = _produto.Documentos;

                    if (docs.Count > 0)
                    {
                        TipoValidacaoDocumento validacao = docs.Max(a => a.DocumentoTipoFamilia.TipoValidacao);
                        switch (validacao)
                        {
                            case TipoValidacaoDocumento.NaoValidar:
                                _documentoMaisRestritivo = "Não Validar";
                                break;
                            case TipoValidacaoDocumento.ValidarAviso:
                                _documentoMaisRestritivo = "Permitir documento inválido com Aviso";
                                break;
                            case TipoValidacaoDocumento.ValidarBloqueio:
                                _documentoMaisRestritivo = "Não Permitir documento inválido";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
                else
                {
                    throw new Exception("Tentativa de gerar OP com produto mas sem ID Produto");
                }
            }
            _documentoMaisRestritivoLoaded = true;
        }

        public string Feedback { get; set; }


        public OrdemProducaoOc(string cliente, string codProduto, DateTime dataEntrega, DateTime? dataImpressaoOp, string descProduto, string dimensao, int idOrderItemEtiqueta, bool kit, string numeroDocumento, string oc, bool opImpressa, string pos, string produtoCodigoAgrupador, string revDocumento, bool semProduto, string tipoDocumento, int? idProduto, string feedback, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection conn)
        {
            _idProduto = idProduto;
            _usuarioAtual = usuarioAtual;
            _conn = conn;
            Cliente = cliente;
            this.codProduto = codProduto;
            this.dataEntrega = dataEntrega;
            this.dataImpressaoOp = dataImpressaoOp;
            this.descProduto = descProduto;
            Dimensao = dimensao;
            this.idOrderItemEtiqueta = idOrderItemEtiqueta;
            this.kit = kit;
            this.numeroDocumento = numeroDocumento;
            this.oc = oc;
            this.opImpressa = opImpressa;
            this.pos = pos;
            this.produtoCodigoAgrupador = produtoCodigoAgrupador;
            this.revDocumento = revDocumento;
            this.semProduto = semProduto;
            this.tipoDocumento = tipoDocumento;
            Feedback = feedback;

        }

        public OrdemProducaoOc(string oc, string pos, string codProduto)
        {
            this.oc = oc;
            this.pos = pos;
            this.codProduto = codProduto;
            this.semProduto = true;
        }
    }
}