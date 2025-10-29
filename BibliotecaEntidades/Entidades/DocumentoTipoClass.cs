using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;


namespace BibliotecaEntidades.Entidades 
{
    public class DocumentoTipoClass : DocumentoTipoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do DocumentoTipoClass";
        protected new const string ErroDelete = "Erro ao excluir o DocumentoTipoClass  ";
        protected new const string ErroSave = "Erro ao salvar o DocumentoTipoClass.";
        protected new const string ErroCollectionDocumentoTipoRevisaoClassDocumentoTipo = "Erro ao carregar a coleção de DocumentoTipoRevisaoClass.";
        protected new const string ErroCollectionDocumentoTipoFamiliaClassDocumentoTipo = "Erro ao carregar a coleção de DocumentoTipoFamiliaClass.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
        protected new const string ErroRevisaoAtualObrigatorio = "O campo RevisaoAtual é obrigatório";
        protected new const string ErroRevisaoAtualComprimento = "O campo RevisaoAtual deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do DocumentoTipoClass.";
        protected new const string MensagemUtilizadoCollectionDocumentoTipoRevisaoClassDocumentoTipo = "A entidade DocumentoTipoClass está sendo utilizada nos seguintes DocumentoTipoRevisaoClass:";
        protected new const string MensagemUtilizadoCollectionDocumentoTipoFamiliaClassDocumentoTipo = "A entidade DocumentoTipoClass está sendo utilizada nos seguintes DocumentoTipoFamiliaClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade DocumentoTipoClass está sendo utilizada.";

        #endregion


        public DocumentoTipoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

      

        protected override void InitClass()
        {
            this.ControleRevisaoHabilitado = true;
        }


        public override string ToString()
        {
            return Identificacao;
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


        public DocumentoTipoFamiliaClass incluirFamilia(FamiliaDocumentoClass familia, TipoValidacaoDocumento tipoValidacao, string documentoPedidoFamilia, string documentoPedido, string documentoPedidoRevisao)
        {
            try
            {

                DocumentoTipoFamiliaClass docFamilia = this.CollectionDocumentoTipoFamiliaClassDocumentoTipo.FirstOrDefault(a => a.FamiliaDocumento == familia);

                if (docFamilia == null)
                {
                    //Nova
                    docFamilia = new DocumentoTipoFamiliaClass(this.UsuarioAtual, this.SingleConnection ?? this.SingleConnection);
                    docFamilia.FamiliaDocumento = familia;
                    docFamilia.DocumentoTipo = this;
                    this.CollectionDocumentoTipoFamiliaClassDocumentoTipo.Add(docFamilia);
                }


                docFamilia.TipoValidacao = tipoValidacao;
                docFamilia.DocumentoPedidoFamilia = documentoPedidoFamilia;
                docFamilia.DocumentoPedido = documentoPedido;
                docFamilia.DocumentoPedidoRevisao = documentoPedidoRevisao;



                return docFamilia;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir uma nova familia no documento.\r\n" + e.Message);
            }
        }

        public void excluirFamilia(DocumentoTipoFamiliaClass docFamilia)
        {
            try
            {
                if (!this.CollectionDocumentoTipoFamiliaClassDocumentoTipo.Any(a => a == docFamilia))
                {
                    throw new Exception("Familia não encontrada");
                }

                this.adicionarObjetoDeletar(docFamilia);
                this.CollectionDocumentoTipoFamiliaClassDocumentoTipo.Remove(docFamilia);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir a familia do documento.\r\n" + e.Message);
            }
        }


       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            DocumentoTipoClass search = new DocumentoTipoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
            List<DocumentoTipoClass> documentos = search.Search(new List<SearchParameterClass>()
                                                                    {
                                                                        new SearchParameterClass("IdentificacaoExata", this.Identificacao),
                                                                        new SearchParameterClass("RevisaoAtual", this.RevisaoAtual)
                                                                    }).ConvertAll(a => (DocumentoTipoClass) a);

            if ( documentos.Any(a => a.ID != this.ID))
            {
                throw new ExcecaoTratada("Já existe um documento cadastrado com a mesma identificação e revisão");
            }



            return true;
        }

        public override bool Utilizado(out string mensagemUtilizado)
        {

            try
            {
                mensagemUtilizado = "";
                if (this.ID == -1)
                {
                    return false;
                }
                if (CollectionDocumentoTipoFamiliaClassDocumentoTipo.Count > 0)
                {
                    foreach (DocumentoTipoFamiliaClass documentoTipoFamiliaClass in this.CollectionDocumentoTipoFamiliaClassDocumentoTipo)
                    {
                        if (documentoTipoFamiliaClass.CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia.Count > 0)
                        {
                            mensagemUtilizado = DocumentoTipoFamiliaClass.MensagemUtilizadoCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia + "\r\n";
                            foreach (Entidades.ProdutoDocumentoTipoClass tmp in documentoTipoFamiliaClass.CollectionProdutoDocumentoTipoClassDocumentoTipoFamilia)
                            {
                                mensagemUtilizado += tmp.ToString() + "\r\n";
                            }
                            return true;
                        }
                        if (documentoTipoFamiliaClass.CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia.Count > 0)
                        {
                            mensagemUtilizado = DocumentoTipoFamiliaClass.MensagemUtilizadoCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia + "\r\n";
                            foreach (Entidades.OrdemProducaoDocumentoClass tmp in documentoTipoFamiliaClass.CollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia)
                            {
                                mensagemUtilizado += tmp.ToString() + "\r\n";
                            }
                            return true;
                        }
                        if (documentoTipoFamiliaClass.CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia.Count > 0)
                        {
                            mensagemUtilizado = DocumentoTipoFamiliaClass.MensagemUtilizadoCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia + "\r\n";
                            foreach (Entidades.OrdemCompraDocumentoEnviadoClass tmp in documentoTipoFamiliaClass.CollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia)
                            {
                                mensagemUtilizado += tmp.ToString() + "\r\n";
                            }
                            return true;
                        }
                    }
                }
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(ErroUtilizado + "\r\n" + e.Message, e);
            }
        }

    }
}
