using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics; 
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
    public class NfProdutoClass : NfProdutoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfProdutoClass";
        protected new const string ErroDelete = "Erro ao excluir o NfProdutoClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfProdutoClass.";
        protected new const string ErroCollectionNfProdutoCofinsClassNfProduto = "Erro ao carregar a coleção de NfProdutoCofinsClass.";
        protected new const string ErroCollectionNfProdutoIpiClassNfProduto = "Erro ao carregar a coleção de NfProdutoIpiClass.";
        protected new const string ErroCollectionNfProdutoIssClassNfProduto = "Erro ao carregar a coleção de NfProdutoIssClass.";
        protected new const string ErroCollectionNfProdutoPisClassNfProduto = "Erro ao carregar a coleção de NfProdutoPisClass.";
        protected new const string ErroCollectionNfProdutoIcmsClassNfProduto = "Erro ao carregar a coleção de NfProdutoIcmsClass.";
        protected new const string ErroCollectionNfProdutoIimpClassNfProduto = "Erro ao carregar a coleção de NfProdutoIimpClass.";
        protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
        protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 60 caracteres";
        protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 60 caracteres";
        protected new const string ErroGtinObrigatorio = "O campo Gtin é obrigatório";
        protected new const string ErroGtinComprimento = "O campo Gtin deve ter no máximo 14 caracteres";
        protected new const string ErroUnidadeObrigatorio = "O campo Unidade é obrigatório";
        protected new const string ErroUnidadeComprimento = "O campo Unidade deve ter no máximo 6 caracteres";
        protected new const string ErroGtimUnidadeTrinutacaoObrigatorio = "O campo GtimUnidadeTrinutacao é obrigatório";
        protected new const string ErroGtimUnidadeTrinutacaoComprimento = "O campo GtimUnidadeTrinutacao deve ter no máximo 14 caracteres";
        protected new const string ErroUnidadeTributacaoObrigatorio = "O campo UnidadeTributacao é obrigatório";
        protected new const string ErroUnidadeTributacaoComprimento = "O campo UnidadeTributacao deve ter no máximo 6 caracteres";
        protected new const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NfProdutoClass.";
        protected new const string MensagemUtilizadoCollectionNfProdutoCofinsClassNfProduto = "A entidade NfProdutoClass está sendo utilizada nos seguintes NfProdutoCofinsClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoIpiClassNfProduto = "A entidade NfProdutoClass está sendo utilizada nos seguintes NfProdutoIpiClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoIssClassNfProduto = "A entidade NfProdutoClass está sendo utilizada nos seguintes NfProdutoIssClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoPisClassNfProduto = "A entidade NfProdutoClass está sendo utilizada nos seguintes NfProdutoPisClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoIcmsClassNfProduto = "A entidade NfProdutoClass está sendo utilizada nos seguintes NfProdutoIcmsClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoIimpClassNfProduto = "A entidade NfProdutoClass está sendo utilizada nos seguintes NfProdutoIimpClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfProdutoClass está sendo utilizada.";

        #endregion

        

        public NfProdutoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            throw new NotImplementedException();
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

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        #region Propriedades Manuais

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfProdutoIcmsClass NfProdutoIcms
        {
            get { return this.NfItem.CollectionNfProdutoIcmsClassNfItem != null && this.NfItem.CollectionNfProdutoIcmsClassNfItem.Count > 0 ? this.NfItem.CollectionNfProdutoIcmsClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfProdutoIcmsClassNfItem == null) NfItem.CollectionNfProdutoIcmsClassNfItem = new BindingList<NfProdutoIcmsClass>();
                if (NfItem.CollectionNfProdutoIcmsClassNfItem.Count == 0)
                {
                    if (value != null)
                        NfItem.CollectionNfProdutoIcmsClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfProdutoIcmsClassNfItem[0] = value;
                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfProdutoIssClass NfProdutoIss
        {
            get { return this.NfItem.CollectionNfProdutoIssClassNfItem != null && this.NfItem.CollectionNfProdutoIssClassNfItem.Count > 0 ? this.NfItem.CollectionNfProdutoIssClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfProdutoIssClassNfItem == null) NfItem.CollectionNfProdutoIssClassNfItem = new BindingList<NfProdutoIssClass>();
                if (NfItem.CollectionNfProdutoIssClassNfItem.Count == 0)
                {
                    if (value != null)
                        NfItem.CollectionNfProdutoIssClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfProdutoIssClassNfItem[0] = value;
                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfProdutoPisClass NfProdutoPis
        {
            get { return this.NfItem.CollectionNfProdutoPisClassNfItem != null && this.NfItem.CollectionNfProdutoPisClassNfItem.Count > 0 ? this.NfItem.CollectionNfProdutoPisClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfProdutoPisClassNfItem == null) NfItem.CollectionNfProdutoPisClassNfItem = new BindingList<NfProdutoPisClass>();
                if (NfItem.CollectionNfProdutoPisClassNfItem.Count == 0)
                {
                    if (value != null)
                        NfItem.CollectionNfProdutoPisClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfProdutoPisClassNfItem[0] = value;
                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfProdutoIpiClass NfProdutoIpi
        {
            get { return this.NfItem.CollectionNfProdutoIpiClassNfItem != null && this.NfItem.CollectionNfProdutoIpiClassNfItem.Count > 0 ? this.NfItem.CollectionNfProdutoIpiClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfProdutoIpiClassNfItem == null) NfItem.CollectionNfProdutoIpiClassNfItem = new BindingList<NfProdutoIpiClass>();
                if (NfItem.CollectionNfProdutoIpiClassNfItem.Count == 0)
                {
                    if (value != null)
                        NfItem.CollectionNfProdutoIpiClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfProdutoIpiClassNfItem[0] = value;
                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfProdutoIimpClass NfProdutoIimp
        {
            get { return this.NfItem.CollectionNfProdutoIimpClassNfItem != null && this.NfItem.CollectionNfProdutoIimpClassNfItem.Count > 0 ? this.NfItem.CollectionNfProdutoIimpClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfProdutoIimpClassNfItem == null) NfItem.CollectionNfProdutoIimpClassNfItem = new BindingList<NfProdutoIimpClass>();
                if (NfItem.CollectionNfProdutoIimpClassNfItem.Count == 0)
                {
                    if (value != null)
                        NfItem.CollectionNfProdutoIimpClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfProdutoIimpClassNfItem[0] = value;
                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfProdutoCofinsClass NfProdutoCofins
        {
            get { return this.NfItem.CollectionNfProdutoCofinsClassNfItem != null && this.NfItem.CollectionNfProdutoCofinsClassNfItem.Count > 0 ? this.NfItem.CollectionNfProdutoCofinsClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfProdutoCofinsClassNfItem == null) NfItem.CollectionNfProdutoCofinsClassNfItem = new BindingList<NfProdutoCofinsClass>();
                if (NfItem.CollectionNfProdutoCofinsClassNfItem.Count == 0)
                {
                    if (value != null)
                        NfItem.CollectionNfProdutoCofinsClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfProdutoCofinsClassNfItem[0] = value;
                }
            }
        }

        #endregion

        public void ExcluirRastreabilidade(NfProdutoRastreabilidadeClass rastreabilidade)
        {
            try
            {
                if (!this.CollectionNfProdutoRastreabilidadeClassNfProduto.Contains(rastreabilidade))
                {
                    throw new ExcecaoTratada("A rastreabilidade " + rastreabilidade.NumeroLote + " não foi encontrada no produto");
                }

                this.CollectionNfProdutoRastreabilidadeClassNfProduto.Remove(rastreabilidade);
                this.adicionarObjetoDeletar(rastreabilidade);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir a rastreabilidade.\r\n" + e.Message, e);
            }
        }

        public void LimparId()
        {
            this.ID = -1;

            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
                if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded)
                {
                    foreach (NfProdutoRastreabilidadeClass item in CollectionNfProdutoRastreabilidadeClassNfProduto)
                    {
                        item.LimparId();
                    }
                }

            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado;
                DisableLoadCollection = sitAnteriorDisableLoadCollection;
            }
        }
    }
}
