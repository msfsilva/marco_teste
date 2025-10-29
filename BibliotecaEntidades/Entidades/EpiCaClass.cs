using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades
{
    [Serializable()]
    public class EpiCaClass : EpiCaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EpiCaClass";
        protected new const string ErroDelete = "Erro ao excluir o EpiCaClass  ";
        protected new const string ErroSave = "Erro ao salvar o EpiCaClass.";
        protected new const string ErroCollectionEpiClassEpiCa = "Erro ao carregar a coleção de EpiClass.";
        protected new const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
        protected new const string ErroNomeDocumentoObrigatorio = "O campo NomeDocumento é obrigatório";
        protected new const string ErroNomeDocumentoComprimento = "O campo NomeDocumento deve ter no máximo 255 caracteres";
        protected new const string ErroUltimaRevisaoObrigatorio = "O campo UltimaRevisao é obrigatório";
        protected new const string ErroUltimaRevisaoComprimento = "O campo UltimaRevisao deve ter no máximo 255 caracteres";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroDocumentoObrigatorio = "O campo Documento é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EpiCaClass.";
        protected new const string MensagemUtilizadoCollectionEpiClassEpiCa = "A entidade EpiCaClass está sendo utilizada nos seguintes EpiClass:";
        protected new const string ErroDocumentoLoad = "O campo Documento não pode ser carregado";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EpiCaClass está sendo utilizada.";

        #endregion

        public EpiCaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }


        
        public override string ToString()
        {
            return this.Numero.ToString();
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool VencidoTela
        {
            get { return this.Vencido; }
            set {  }
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
            AtualizaVencido();
            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public void AtualizaVencido()
        {
            
            this.Vencido = Validade.Date < Configurations.DataIndependenteClass.GetData().Date;
        }
    }
}
