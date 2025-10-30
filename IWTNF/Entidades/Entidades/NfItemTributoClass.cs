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
    public class NfItemTributoClass : NfItemTributoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfItemTributoClass";
        protected new const string ErroDelete = "Erro ao excluir o NfItemTributoClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfItemTributoClass.";
        protected new const string ErroCollectionNfItemTributoCofinsClassNfItemTributo = "Erro ao carregar a coleção de NfItemTributoCofinsClass.";
        protected new const string ErroCollectionNfItemTributoIpiClassNfItemTributo = "Erro ao carregar a coleção de NfItemTributoIpiClass.";
        protected new const string ErroCollectionNfItemTributoIssClassNfItemTributo = "Erro ao carregar a coleção de NfItemTributoIssClass.";
        protected new const string ErroCollectionNfItemTributoIimpClassNfItemTributo = "Erro ao carregar a coleção de NfItemTributoIimpClass.";
        protected new const string ErroCollectionNfItemTributoIcmsClassNfItemTributo = "Erro ao carregar a coleção de NfItemTributoIcmsClass.";
        protected new const string ErroCollectionNfItemTributoPisClassNfItemTributo = "Erro ao carregar a coleção de NfItemTributoPisClass.";
        protected new const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NfItemTributoClass.";
        protected new const string MensagemUtilizadoCollectionNfItemTributoCofinsClassNfItemTributo = "A entidade NfItemTributoClass está sendo utilizada nos seguintes NfItemTributoCofinsClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoIpiClassNfItemTributo = "A entidade NfItemTributoClass está sendo utilizada nos seguintes NfItemTributoIpiClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoIssClassNfItemTributo = "A entidade NfItemTributoClass está sendo utilizada nos seguintes NfItemTributoIssClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoIimpClassNfItemTributo = "A entidade NfItemTributoClass está sendo utilizada nos seguintes NfItemTributoIimpClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoIcmsClassNfItemTributo = "A entidade NfItemTributoClass está sendo utilizada nos seguintes NfItemTributoIcmsClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoPisClassNfItemTributo = "A entidade NfItemTributoClass está sendo utilizada nos seguintes NfItemTributoPisClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfItemTributoClass está sendo utilizada.";

        #endregion

        

        public NfItemTributoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
        public NfItemTributoIcmsClass NfItemTributoIcms
        {
            get { return this.NfItem.CollectionNfItemTributoIcmsClassNfItem != null && this.NfItem.CollectionNfItemTributoIcmsClassNfItem.Count > 0 ? this.NfItem.CollectionNfItemTributoIcmsClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfItemTributoIcmsClassNfItem == null) NfItem.CollectionNfItemTributoIcmsClassNfItem = new BindingList<NfItemTributoIcmsClass>();
                if (NfItem.CollectionNfItemTributoIcmsClassNfItem.Count == 0)
                {
                    if (value != null)
                    NfItem.CollectionNfItemTributoIcmsClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfItemTributoIcmsClassNfItem[0] = value;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
        public NfItemTributoIpiClass NfItemTributoIpi
        {
            get { return this.NfItem.CollectionNfItemTributoIpiClassNfItem != null && this.NfItem.CollectionNfItemTributoIpiClassNfItem.Count > 0 ? this.NfItem.CollectionNfItemTributoIpiClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfItemTributoIpiClassNfItem == null) NfItem.CollectionNfItemTributoIpiClassNfItem = new BindingList<NfItemTributoIpiClass>();
                if (NfItem.CollectionNfItemTributoIpiClassNfItem.Count == 0)
                {
                    if (value != null)
                    NfItem.CollectionNfItemTributoIpiClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfItemTributoIpiClassNfItem[0] = value;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
        public NfItemTributoIimpClass NfItemTributoIimp
        {
            get { return this.NfItem.CollectionNfItemTributoIimpClassNfItem != null && this.NfItem.CollectionNfItemTributoIimpClassNfItem.Count > 0 ? this.NfItem.CollectionNfItemTributoIimpClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfItemTributoIimpClassNfItem == null) NfItem.CollectionNfItemTributoIimpClassNfItem = new BindingList<NfItemTributoIimpClass>();
                if (NfItem.CollectionNfItemTributoIimpClassNfItem.Count == 0)
                {
                    if (value != null)
                    NfItem.CollectionNfItemTributoIimpClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfItemTributoIimpClassNfItem[0] = value;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
        public NfItemTributoIssClass NfItemTributoIss
        {
            get { return this.NfItem.CollectionNfItemTributoIssClassNfItem != null && this.NfItem.CollectionNfItemTributoIssClassNfItem.Count > 0 ? this.NfItem.CollectionNfItemTributoIssClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfItemTributoIssClassNfItem == null) NfItem.CollectionNfItemTributoIssClassNfItem = new BindingList<NfItemTributoIssClass>();
                if (NfItem.CollectionNfItemTributoIssClassNfItem.Count == 0)
                {
                    if (value != null)
                    NfItem.CollectionNfItemTributoIssClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfItemTributoIssClassNfItem[0] = value;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
        public NfItemTributoPisClass NfItemTributoPis
        {
            get { return this.NfItem.CollectionNfItemTributoPisClassNfItem != null && this.NfItem.CollectionNfItemTributoPisClassNfItem.Count > 0 ? this.NfItem.CollectionNfItemTributoPisClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfItemTributoPisClassNfItem == null) NfItem.CollectionNfItemTributoPisClassNfItem = new BindingList<NfItemTributoPisClass>();
                if (NfItem.CollectionNfItemTributoPisClassNfItem.Count == 0)
                {
                    if (value != null)
                    NfItem.CollectionNfItemTributoPisClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfItemTributoPisClassNfItem[0] = value;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
        public NfItemTributoCofinsClass NfItemTributoCofins
        {
            get { return this.NfItem.CollectionNfItemTributoCofinsClassNfItem != null && this.NfItem.CollectionNfItemTributoCofinsClassNfItem.Count > 0 ? this.NfItem.CollectionNfItemTributoCofinsClassNfItem[0] : null; }
            set
            {
                if (this.NfItem.CollectionNfItemTributoCofinsClassNfItem == null) NfItem.CollectionNfItemTributoCofinsClassNfItem = new BindingList<NfItemTributoCofinsClass>();
                if (NfItem.CollectionNfItemTributoCofinsClassNfItem.Count == 0)
                {
                    if (value != null)
                    NfItem.CollectionNfItemTributoCofinsClassNfItem.Add(value);
                }
                else
                {
                    NfItem.CollectionNfItemTributoCofinsClassNfItem[0] = value;
                }
            }
        }

        #endregion

        public void LimparId()
        {
            
                this.ID = -1;
                
           
        }
    }
}
