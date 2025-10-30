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
    public class NfCobrancaClass : NfCobrancaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfCobrancaClass";
        protected new const string ErroDelete = "Erro ao excluir o NfCobrancaClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfCobrancaClass.";
        protected new const string ErroCollectionNfFaturaClassNfCobranca = "Erro ao carregar a coleção de NfFaturaClass.";
        protected new const string ErroCollectionNfDuplicataClassNfCobranca = "Erro ao carregar a coleção de NfDuplicataClass.";
        protected new const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NfCobrancaClass.";
        protected new const string MensagemUtilizadoCollectionNfFaturaClassNfCobranca = "A entidade NfCobrancaClass está sendo utilizada nos seguintes NfFaturaClass:";
        protected new const string MensagemUtilizadoCollectionNfDuplicataClassNfCobranca = "A entidade NfCobrancaClass está sendo utilizada nos seguintes NfDuplicataClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfCobrancaClass está sendo utilizada.";

        #endregion

        

        public NfCobrancaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
        public NfFaturaClass NfFatura
        {
            get { return this.NfPrincipal.CollectionNfFaturaClassNfPrincipal != null && this.NfPrincipal.CollectionNfFaturaClassNfPrincipal.Count > 0 ? this.NfPrincipal.CollectionNfFaturaClassNfPrincipal[0] : null; }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public BindingList<NfDuplicataClass> CollectionNfDuplicataClassNfCobranca
        {
            get { return this.NfPrincipal.CollectionNfDuplicataClassNfPrincipal; }
            set { this.NfPrincipal.CollectionNfDuplicataClassNfPrincipal = value; }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public BindingList<NfFaturaClass> CollectionNfFaturaClassNfCobranca
        {
            get { return this.NfPrincipal.CollectionNfFaturaClassNfPrincipal; }
            set { this.NfPrincipal.CollectionNfFaturaClassNfPrincipal = value; }
        }

        #endregion

      
    }
}
