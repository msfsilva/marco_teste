using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class DocumentoTipoFamiliaClass : DocumentoTipoFamiliaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do DocumentoTipoFamiliaClass";
        protected new const string ErroDelete = "Erro ao excluir o DocumentoTipoFamiliaClass  ";
        protected new const string ErroSave = "Erro ao salvar o DocumentoTipoFamiliaClass.";
        protected new const string ErroCollectionDocumentoCopiaClassDocumentoTipoFamilia = "Erro ao carregar a coleção de DocumentoCopiaClass.";
        protected new const string ErroCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia = "Erro ao carregar a coleção de ProdutoDocumentoTipoClass.";
        protected new const string ErroCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia = "Erro ao carregar a coleção de OrdemProducaoDocumentoClass.";
        protected new const string ErroCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia = "Erro ao carregar a coleção de OrdemCompraDocumentoEnviadoClass.";
        protected new const string ErroDocumentoTipoObrigatorio = "O campo DocumentoTipo é obrigatório";
        protected new const string ErroFamiliaDocumentoObrigatorio = "O campo FamiliaDocumento é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do DocumentoTipoFamiliaClass.";
        protected new const string MensagemUtilizadoCollectionDocumentoCopiaClassDocumentoTipoFamilia = "A entidade DocumentoTipoFamiliaClass está sendo utilizada nos seguintes DocumentoCopiaClass:";
        protected internal new const string MensagemUtilizadoCollectionProdutoDocumentoTipoClassDocumentoTipoFamilia = "A entidade DocumentoTipoFamiliaClass está sendo utilizada nos seguintes ProdutoDocumentoTipoClass:";
        protected internal new const string MensagemUtilizadoCollectionOrdemProducaoDocumentoClassDocumentoTipoFamilia = "A entidade DocumentoTipoFamiliaClass está sendo utilizada nos seguintes OrdemProducaoDocumentoClass:";
        protected internal new const string MensagemUtilizadoCollectionOrdemCompraDocumentoEnviadoClassDocumentoTipoFamilia = "A entidade DocumentoTipoFamiliaClass está sendo utilizada nos seguintes OrdemCompraDocumentoEnviadoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade DocumentoTipoFamiliaClass está sendo utilizada.";

        #endregion

        


        public DocumentoTipoFamiliaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

     

        protected override void InitClass()
        {
            this.ControleRevisaoHabilitado = false;
        }


        public string descricaoFamilia
        {
            get
            {
                if (this.FamiliaDocumento != null)
                {
                    return this.FamiliaDocumento.Descricao;
                }
                else
                {
                    return null;
                }
            }
        }

        public string TipoValidacaoTraduzido
        {
            get
            {
                switch (this.TipoValidacao)
                {
                    case TipoValidacaoDocumento.NaoValidar:
                        return "Não Validar";
                        break;
                    case TipoValidacaoDocumento.ValidarAviso:
                        return "Permitir documento inválido com Aviso";
                        break;
                    case TipoValidacaoDocumento.ValidarBloqueio:
                        return "Não Permitir documento inválido";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        
        public string Documento_Familia
        {
            get { return this.FamiliaDocumento + " " + this.DocumentoTipo; }
        }

        public string DocumentoTipoDescricao
        {
            get { return this.DocumentoTipo.Descricao; }
        }

        public string DocumentoTipoRevisaoAtual
        {
            get { return this.DocumentoTipo.RevisaoAtual; }
        }

        public string DocumentoTipoRevisor
        {
            get { return this.DocumentoTipo.UltimaRevisaoUsuario != null ? this.DocumentoTipo.UltimaRevisaoUsuario.ToString() : null; }
        }

        public string DocumentoTipoRevisao
        {
            get { return this.DocumentoTipo.UltimaRevisao; }
        }

        public DateTime? DocumentoTipoDataRevisao
        {
            get { return this.DocumentoTipo.UltimaRevisaoData; }
        }

        public void setBloqueado(bool bloqueado)
        {
            if (bloqueado)
            {
                this.Bloqueado = true;
                this.AcsUsuarioBloqueio = UsuarioAtual;
                this.BloqueioData = Configurations.DataIndependenteClass.GetData();
            }
            else
            {
                this.Bloqueado = false;
                this.AcsUsuarioBloqueio = null;
                this.BloqueioData = null;
            }
        }

        public override string ToString()
        {
            return this.FamiliaDocumento + " " + this.DocumentoTipo + " " + this.DocumentoTipoRevisao;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaCompleta":
                    whereClause += " AND ( " +
                                   "  f1.fad_codigo || ' ' || d1.dot_identificacao LIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " d1.dot_descricao LIKE '%" + parametro.Fieldvalue + "%' OR " +
                                   " d1.dot_identificacao LIKE '%" + parametro.Fieldvalue + "%' " +
                                   ") ";

                    command.CommandText +=
                        "  INNER JOIN public.documento_tipo d1 ON (public.documento_tipo_familia.id_documento_tipo = d1.id_documento_tipo) " +
                        "  INNER JOIN public.familia_documento f1 ON (public.documento_tipo_familia.id_familia_documento = f1.id_familia_documento) ";
                    return true;
                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {

             switch (parametro.FieldName)
            {
                case "Documento_Familia":

                    orderByClause += " , ( fo1.fad_codigo || ' ' || do1.dot_identificacao ) " + ordenacao.ToString();

                    command.CommandText +=
                        "  INNER JOIN public.documento_tipo do1 ON (public.documento_tipo_familia.id_documento_tipo = do1.id_documento_tipo) " +
                        "  INNER JOIN public.familia_documento fo1 ON (public.documento_tipo_familia.id_familia_documento = fo1.id_familia_documento) ";
                    return true;

                case "descricaoFamilia":

                    orderByClause += " , ( fo2.fad_descricao  ) " + ordenacao.ToString();

                    command.CommandText +=
                        "  INNER JOIN public.familia_documento fo2 ON (public.documento_tipo_familia.id_familia_documento = fo2.id_familia_documento) ";
                    return true;

                case "DocumentoTipoRevisaoAtual":

                    orderByClause += " , ( do2.dot_revisao_atual  ) " + ordenacao.ToString();

                    command.CommandText +=
                        "  INNER JOIN public.documento_tipo do2 ON (public.documento_tipo_familia.id_documento_tipo = do2.id_documento_tipo) ";
                    return true;

                case "DocumentoTipoRevisor":

                    orderByClause += " , ( acs3.aus_login  ) " + ordenacao.ToString();

                    command.CommandText +=
                        "  INNER JOIN public.documento_tipo do3 ON (public.documento_tipo_familia.id_documento_tipo = do3.id_documento_tipo) " +
                        "  LEFT OUTER JOIN public.acs_usuario acs3 ON (acs3.id_acs_usuario = do3.id_acs_usuario_ultima_revisao) ";
                    return true;

                case "DocumentoTipoRevisao":

                    orderByClause += " , ( do4.dot_ultima_revisao ) " + ordenacao.ToString();

                    command.CommandText +=
                        "  INNER JOIN public.documento_tipo do4 ON (public.documento_tipo_familia.id_documento_tipo = do4.id_documento_tipo) ";
                    return true;
                case "DocumentoTipoDataRevisao":

                    orderByClause += " , ( do5.dot_ultima_revisao_data  ) " + ordenacao.ToString();

                    command.CommandText +=
                        "  INNER JOIN public.documento_tipo do5 ON (public.documento_tipo_familia.id_documento_tipo = do5.id_documento_tipo) ";
                    return true;

                     
                default:
                    return false;
            }
            
            
        }

        public void ExcluirCopia(DocumentoCopiaClass copia)
        {
            string msg;
            if (copia.Utilizado(out msg))
            {
                throw new ExcecaoTratada("Não é possível excluir a cópia " + copia + " pois ela está sendo utilizada em: " + msg);
            }

            if (!this.CollectionDocumentoCopiaClassDocumentoTipoFamilia.Contains(copia))
            {
                throw new ExcecaoTratada("A cópia não foi encontrada no documento");
            }

            this.adicionarObjetoDeletar(copia);
            this.CollectionDocumentoCopiaClassDocumentoTipoFamilia.Remove(copia);
        }
    }
}
