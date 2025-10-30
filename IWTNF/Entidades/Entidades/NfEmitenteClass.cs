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
    public class NfEmitenteClass : NfEmitenteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfEmitenteClass";
        protected new const string ErroDelete = "Erro ao excluir o NfEmitenteClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfEmitenteClass.";
        protected new const string ErroCollectionNfEmitenteEnderecoClassNfEmitente = "Erro ao carregar a coleção de NfEmitenteEnderecoClass.";
        protected new const string ErroRazaoObrigatorio = "O campo Razao é obrigatório";
        protected new const string ErroRazaoComprimento = "O campo Razao deve ter no máximo 60 caracteres";
        protected new const string ErroIeObrigatorio = "O campo Ie é obrigatório";
        protected new const string ErroIeComprimento = "O campo Ie deve ter no máximo 14 caracteres";
        protected new const string ErroCnpjCpfObrigatorio = "O campo CnpjCpf é obrigatório";
        protected new const string ErroCnpjCpfComprimento = "O campo CnpjCpf deve ter no máximo 14 caracteres";
        protected new const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NfEmitenteClass.";
        protected new const string MensagemUtilizadoCollectionNfEmitenteEnderecoClassNfEmitente = "A entidade NfEmitenteClass está sendo utilizada nos seguintes NfEmitenteEnderecoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfEmitenteClass está sendo utilizada.";

        #endregion




 
        public NfEmitenteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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

        public NfEmitenteClass CloneClean()
        {
            NfEmitenteClass toRet = new NfEmitenteClass(this.UsuarioAtual, this.SingleConnection)
                                        {
                                            AliquotaSimplesServico = this.AliquotaSimplesServico,
                                            BufferSecundario = this.BufferSecundario,
                                            Cnae = this.Cnae,
                                            CnpjCpf = this.CnpjCpf,
                                            Crt = this.Crt,
                                            Ie = this.Ie,
                                            IeSt = this.IeSt,
                                            Im = this.Im,
                                            NomeFantasia = this.NomeFantasia,
                                            Razao = this.Razao,
                                            Version = this.Version,
                                            NfEmitenteEndereco = this.NfEmitenteEndereco.CloneClean()
                                        };
            toRet.NfEmitenteEndereco.NfEmitente = toRet;
            return toRet;
        }

        #region Propriedades Manuais

        [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
        public NfEmitenteEnderecoClass NfEmitenteEndereco
        {
            get { return this.CollectionNfEmitenteEnderecoClassNfEmitente.FirstOrDefault(); }
            set
            {

                if (CollectionNfEmitenteEnderecoClassNfEmitente.Count == 0)
                {
                    if (value != null)
                        CollectionNfEmitenteEnderecoClassNfEmitente.Add(value);
                }
                else
                {
                    CollectionNfEmitenteEnderecoClassNfEmitente[0] = value;
                }
            }
        }

        #endregion
       
    }
}
