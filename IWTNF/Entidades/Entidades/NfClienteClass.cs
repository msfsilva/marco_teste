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
    public class NfClienteClass : NfClienteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfClienteClass";
        protected new const string ErroDelete = "Erro ao excluir o NfClienteClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfClienteClass.";
        protected new const string ErroCollectionNfClienteEnderecoClassNfCliente = "Erro ao carregar a coleção de NfClienteEnderecoClass.";
        protected new const string ErroRazaoObrigatorio = "O campo Razao é obrigatório";
        protected new const string ErroRazaoComprimento = "O campo Razao deve ter no máximo 60 caracteres";
        protected new const string ErroCnpjCpfObrigatorio = "O campo CnpjCpf é obrigatório";
        protected new const string ErroCnpjCpfComprimento = "O campo CnpjCpf deve ter no máximo 14 caracteres";
        protected new const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NfClienteClass.";
        protected new const string MensagemUtilizadoCollectionNfClienteEnderecoClassNfCliente = "A entidade NfClienteClass está sendo utilizada nos seguintes NfClienteEnderecoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfClienteClass está sendo utilizada.";

        #endregion

        

        public NfClienteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
            if (string.IsNullOrWhiteSpace(this.CnpjCpf) && this.NfClienteEndereco.CodPais==1058)
            {
                throw new ExcecaoTratada(ErroCnpjCpfObrigatorio);
            }


            if (this.NfPrincipal.Homologacao)
            {
                this.Razao = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
            }
                

            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        #region Propriedades Manuais

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public NfClienteEnderecoClass NfClienteEndereco
        {
            get { return this.NfPrincipal.CollectionNfClienteEnderecoClassNfPrincipal != null && this.NfPrincipal.CollectionNfClienteEnderecoClassNfPrincipal.Count > 0 ? this.NfPrincipal.CollectionNfClienteEnderecoClassNfPrincipal[0] : null; }
            set
            {
                
                if (this.NfPrincipal.CollectionNfClienteEnderecoClassNfPrincipal == null) NfPrincipal.CollectionNfClienteEnderecoClassNfPrincipal = new BindingList<NfClienteEnderecoClass>();

                if (NfPrincipal.CollectionNfClienteEnderecoClassNfPrincipal.Count == 0)
                {
                    if (value != null)
                        NfPrincipal.CollectionNfClienteEnderecoClassNfPrincipal.Add(value);
                }
                else
                {
                    NfPrincipal.CollectionNfClienteEnderecoClassNfPrincipal[0] = value;
                }
            }
        }

        #endregion

    }
}
