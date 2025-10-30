using System; 
using System.Collections.Generic; 
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

using IWTNFCompleto.BibliotecaEntidades.Base;

namespace IWTNFCompleto.BibliotecaEntidades.Entidades
{
    [Serializable()]
    public class NfeCompletaPendentesCancelamentoClass : NfeCompletaPendentesCancelamentoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfeCompletaPendentesCancelamentoClass";
        protected new const string ErroDelete = "Erro ao excluir o NfeCompletaPendentesCancelamentoClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfeCompletaPendentesCancelamentoClass.";
        protected new const string ErroCnpjEmitenteObrigatorio = "O campo CnpjEmitente é obrigatório";
        protected new const string ErroCnpjEmitenteComprimento = "O campo CnpjEmitente deve ter no máximo 30 caracteres";
        protected new const string ErroJustificativaObrigatorio = "O campo Justificativa é obrigatório";
        protected new const string ErroJustificativaComprimento = "O campo Justificativa deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do NfeCompletaPendentesCancelamentoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfeCompletaPendentesCancelamentoClass está sendo utilizada.";

        #endregion



        public NfeCompletaPendentesCancelamentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

        protected override void InitClass()
        {
            ControleRevisaoHabilitado = false;
        }


        public override string ToString()
        {
            return this.Numero.ToString(CultureInfo.InvariantCulture);
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
    }
}
