using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 

using IWTNF.Entidades.Base;

namespace IWTNF.Entidades.Entidades
{
    [Serializable()]
    public partial class NfPrincipalClass : NfPrincipalBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfPrincipalClass";
        protected new const string ErroDelete = "Erro ao excluir o NfPrincipalClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfPrincipalClass.";
        protected new const string ErroCollectionNfClienteClassNfPrincipal = "Erro ao carregar a coleção de NfClienteClass.";
        protected new const string ErroCollectionNfAtributoClassNfPrincipal = "Erro ao carregar a coleção de NfAtributoClass.";
        protected new const string ErroCollectionNfExtrasClassNfPrincipal = "Erro ao carregar a coleção de NfExtrasClass.";
        protected new const string ErroCollectionNfNotasRelacionadasClassNfPrincipal = "Erro ao carregar a coleção de NfNotasRelacionadasClass.";
        protected new const string ErroCollectionNfCobrancaClassNfPrincipal = "Erro ao carregar a coleção de NfCobrancaClass.";
        protected new const string ErroCollectionNfFaturaClassNfPrincipal = "Erro ao carregar a coleção de NfFaturaClass.";
        protected new const string ErroCollectionNfItemClassNfPrincipal = "Erro ao carregar a coleção de NfItemClass.";
        protected new const string ErroCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal = "Erro ao carregar a coleção de NfPrincipalCancelamentoJustificativaClass.";
        protected new const string ErroCollectionNfEmitenteClassNfPrincipal = "Erro ao carregar a coleção de NfEmitenteClass.";
        protected new const string ErroCollectionNfEmitenteEnderecoClassNfPrincipal = "Erro ao carregar a coleção de NfEmitenteEnderecoClass.";
        protected new const string ErroCollectionNfDuplicataClassNfPrincipal = "Erro ao carregar a coleção de NfDuplicataClass.";
        protected new const string ErroCollectionNfTotaisClassNfPrincipal = "Erro ao carregar a coleção de NfTotaisClass.";
        protected new const string ErroCollectionNfTransporteClassNfPrincipal = "Erro ao carregar a coleção de NfTransporteClass.";
        protected new const string ErroCollectionNfClienteEnderecoClassNfPrincipal = "Erro ao carregar a coleção de NfClienteEnderecoClass.";
        protected new const string ErroNaturezaOperacaoObrigatorio = "O campo NaturezaOperacao é obrigatório";
        protected new const string ErroNaturezaOperacaoComprimento = "O campo NaturezaOperacao deve ter no máximo 60 caracteres";
        protected new const string ErroModeloDocFiscalObrigatorio = "O campo ModeloDocFiscal é obrigatório";
        protected new const string ErroModeloDocFiscalComprimento = "O campo ModeloDocFiscal deve ter no máximo 2 caracteres";
        protected new const string ErroVersaoProcessoEmissaoObrigatorio = "O campo VersaoProcessoEmissao é obrigatório";
        protected new const string ErroVersaoProcessoEmissaoComprimento = "O campo VersaoProcessoEmissao deve ter no máximo 20 caracteres";
        protected new const string ErroTipoEmitenteObrigatorio = "O campo TipoEmitente é obrigatório";
        protected new const string ErroTipoEmitenteComprimento = "O campo TipoEmitente deve ter no máximo 1 caracteres";
        protected new const string ErroSituacaoObrigatorio = "O campo Situacao é obrigatório";
        protected new const string ErroSituacaoComprimento = "O campo Situacao deve ter no máximo 1 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do NfPrincipalClass.";
        protected new const string MensagemUtilizadoCollectionNfClienteClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfClienteClass:";
        protected new const string MensagemUtilizadoCollectionNfAtributoClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfAtributoClass:";
        protected new const string MensagemUtilizadoCollectionNfExtrasClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfExtrasClass:";
        protected new const string MensagemUtilizadoCollectionNfNotasRelacionadasClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfNotasRelacionadasClass:";
        protected new const string MensagemUtilizadoCollectionNfCobrancaClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfCobrancaClass:";
        protected new const string MensagemUtilizadoCollectionNfFaturaClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfFaturaClass:";
        protected new const string MensagemUtilizadoCollectionNfItemClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfItemClass:";
        protected new const string MensagemUtilizadoCollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfPrincipalCancelamentoJustificativaClass:";
        protected new const string MensagemUtilizadoCollectionNfEmitenteClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfEmitenteClass:";
        protected new const string MensagemUtilizadoCollectionNfEmitenteEnderecoClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfEmitenteEnderecoClass:";
        protected new const string MensagemUtilizadoCollectionNfDuplicataClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfDuplicataClass:";
        protected new const string MensagemUtilizadoCollectionNfTotaisClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfTotaisClass:";
        protected new const string MensagemUtilizadoCollectionNfTransporteClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfTransporteClass:";
        protected new const string MensagemUtilizadoCollectionNfClienteEnderecoClassNfPrincipal = "A entidade NfPrincipalClass está sendo utilizada nos seguintes NfClienteEnderecoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfPrincipalClass está sendo utilizada.";

        #endregion

 

        public NfPrincipalClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        protected override void InitClass()
        {
            //SalvarVetoresObjetosHabilitado = false;
        }

        public override string ToString()
        {
            return this.Numero.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Scan":
                    if (parametro.Fieldvalue as bool? == true)
                    {
                        whereClause += " AND ((public.nf_principal.nfp_serie >= 900 AND public.nf_principal.nfp_serie <= 999) OR public.nf_principal.nfp_forma_emissao = 3)  ";
                    }
                    else
                    {
                        whereClause += " AND ( public.nf_principal.nfp_serie <= 889 AND public.nf_principal.nfp_forma_emissao <> 3) ";
                    }
                    return true;
                case "DataEmissaoIni":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND ( " +
                                       "  public.nf_principal.nfp_data_emissao >= :nfp_data_emissao_ini " +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_data_emissao_ini", NpgsqlDbType.Timestamp));
                        command.Parameters["nfp_data_emissao"].Value = parametro.Fieldvalue;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo DateTime");
                    }
                    return true;
                case "DataEmissaoFim":
                    if (parametro.Fieldvalue is DateTime)
                    {
                        whereClause += " AND ( " +
                                       "  public.nf_principal.nfp_data_emissao <= :nfp_data_emissao_fim " +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_data_emissao_fim", NpgsqlDbType.Timestamp));
                        command.Parameters["nfp_data_emissao"].Value = parametro.Fieldvalue;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo DateTime");
                    }
                    return true;

                case "CnpjEmitente":
                    if (parametro.Fieldvalue is string)
                    {
                        whereClause += " AND (emit.nfe_cnpj_cpf = :emit_nfe_cnpj_cpf) ";
                        command.CommandText += " INNER JOIN public.nf_emitente emit ON (public.nf_principal.id_nf_principal = emit.id_nf_principal) ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emit_nfe_cnpj_cpf", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = parametro.Fieldvalue as string;

                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo string");
                    }
                    return true;

                case "ModeloDocFiscalExato":
                    if (parametro.Fieldvalue is string)
                    {
                        whereClause += " AND (public.nf_principal.nfp_modelo_doc_fiscal = :nfp_modelo_doc_fiscal_exato) ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_modelo_doc_fiscal_exato", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = parametro.Fieldvalue as string;

                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo string");
                    }
                    return true;

                default:
                    return false;
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            //Salvar os vetores de objetos para garantir que a sequencia está correta.
            //foreach (NfAtributoClass item in CollectionNfAtributoClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfClienteClass item in CollectionNfClienteClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfClienteEnderecoClass item in CollectionNfClienteEnderecoClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfCobrancaClass item in CollectionNfCobrancaClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfDuplicataClass item in CollectionNfDuplicataClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfEmitenteClass item in CollectionNfEmitenteClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfEmitenteEnderecoClass item in CollectionNfEmitenteEnderecoClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfExtrasClass item in CollectionNfExtrasClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfFaturaClass item in CollectionNfFaturaClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfItemClass item in CollectionNfItemClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfNotasRelacionadasClass item in CollectionNfNotasRelacionadasClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfPrincipalCancelamentoJustificativaClass item in CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfTotaisClass item in CollectionNfTotaisClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfTransporteClass item in CollectionNfTransporteClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfPagamentoClass item in CollectionNfPagamentoClassNfPrincipal.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}


        }

        #region Propriedades Manuais

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfClienteClass NfCliente
        {
            get { return this.CollectionNfClienteClassNfPrincipal != null && this.CollectionNfClienteClassNfPrincipal.Count > 0 ? this.CollectionNfClienteClassNfPrincipal[0] : null; }
            set
            {
                if (this.CollectionNfClienteClassNfPrincipal == null) CollectionNfClienteClassNfPrincipal = new BindingList<NfClienteClass>();
                if (CollectionNfClienteClassNfPrincipal.Count == 0)
                {
                    if (value != null)
                        CollectionNfClienteClassNfPrincipal.Add(value);
                }
                else
                {
                    CollectionNfClienteClassNfPrincipal[0] = value;
                }

            }
        }


        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfEmitenteClass NfEmitente
        {
            get { return this.CollectionNfEmitenteClassNfPrincipal != null && this.CollectionNfEmitenteClassNfPrincipal.Count > 0 ? this.CollectionNfEmitenteClassNfPrincipal[0] : null; }
            set
            {
                if (this.CollectionNfEmitenteClassNfPrincipal == null) CollectionNfEmitenteClassNfPrincipal = new BindingList<NfEmitenteClass>();
                if (CollectionNfEmitenteClassNfPrincipal.Count == 0)
                {
                    if (value != null)
                        CollectionNfEmitenteClassNfPrincipal.Add(value);
                }
                else
                {
                    CollectionNfEmitenteClassNfPrincipal[0] = value;
                }

            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfAtributoClass NfAtributo
        {
            get { return this.CollectionNfAtributoClassNfPrincipal != null && this.CollectionNfAtributoClassNfPrincipal.Count > 0 ? this.CollectionNfAtributoClassNfPrincipal[0] : null; }
            set
            {
                if (this.CollectionNfAtributoClassNfPrincipal == null) CollectionNfAtributoClassNfPrincipal = new BindingList<NfAtributoClass>();
                if (CollectionNfAtributoClassNfPrincipal.Count == 0)
                {
                    if (value != null)
                        CollectionNfAtributoClassNfPrincipal.Add(value);
                }
                else
                {
                    CollectionNfAtributoClassNfPrincipal[0] = value;
                }

            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfTotaisClass NfTotais
        {
            get { return this.CollectionNfTotaisClassNfPrincipal != null && this.CollectionNfTotaisClassNfPrincipal.Count > 0 ? this.CollectionNfTotaisClassNfPrincipal[0] : null; }
            set
            {
                if (this.CollectionNfTotaisClassNfPrincipal == null) CollectionNfTotaisClassNfPrincipal = new BindingList<NfTotaisClass>();
                if (CollectionNfTotaisClassNfPrincipal.Count == 0)
                {
                    if (value != null)
                        CollectionNfTotaisClassNfPrincipal.Add(value);
                }
                else
                {
                    CollectionNfTotaisClassNfPrincipal[0] = value;
                }

            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfTransporteClass NfTransporte
        {
            get { return this.CollectionNfTransporteClassNfPrincipal != null && this.CollectionNfTransporteClassNfPrincipal.Count > 0 ? this.CollectionNfTransporteClassNfPrincipal[0] : null; }
            set
            {
                if (this.CollectionNfTransporteClassNfPrincipal == null) CollectionNfTransporteClassNfPrincipal = new BindingList<NfTransporteClass>();
                if (CollectionNfTransporteClassNfPrincipal.Count == 0)
                {
                    if (value != null)
                        CollectionNfTransporteClassNfPrincipal.Add(value);
                }
                else
                {
                    CollectionNfTransporteClassNfPrincipal[0] = value;
                }

            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfCobrancaClass NfCobranca
        {
            get { return this.CollectionNfCobrancaClassNfPrincipal != null && this.CollectionNfCobrancaClassNfPrincipal.Count > 0 ? this.CollectionNfCobrancaClassNfPrincipal[0] : null; }
            set
            {
                if (this.CollectionNfCobrancaClassNfPrincipal == null) CollectionNfCobrancaClassNfPrincipal = new BindingList<NfCobrancaClass>();
                if (CollectionNfCobrancaClassNfPrincipal.Count == 0)
                {
                    if (value != null)
                        CollectionNfCobrancaClassNfPrincipal.Add(value);
                }
                else
                {
                    CollectionNfCobrancaClassNfPrincipal[0] = value;
                }

            }
        }

        #endregion

    }
}
