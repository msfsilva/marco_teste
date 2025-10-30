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
    public class NfPagamentoClass : NfPagamentoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfPagamentoClass";
        protected new const string ErroDelete = "Erro ao excluir o NfPagamentoClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfPagamentoClass.";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NfPagamentoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfPagamentoClass está sendo utilizada.";

        #endregion

        public bool SemNfPrincipal { get; set; } = false;

        public NfPagamentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

         
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public string TipoTraduzido
        {
            get
            {
                switch (Tipo)
                {
                    case NfPagamentoTipo.TransferenciaBancaria:
                        return "Transferência Bancária";
                        break;
                    case NfPagamentoTipo.BoletoBancario:
                        return "Boleto Bancário";
                        break;
                    case NfPagamentoTipo.SemPagamento:
                        return "Sem Pagamento";
                        break;
                    case NfPagamentoTipo.Outros:
                    case NfPagamentoTipo.Dinheiro:
                    case NfPagamentoTipo.Cheque:
                    case NfPagamentoTipo.Pix:
                    case NfPagamentoTipo.ProgramaFidelidade:
                    case NfPagamentoTipo.DepositoBancario:
                    return Tipo.ToString();
                        break;
                    case NfPagamentoTipo.CartaoCredito:
                        return "Cartão de Crédito";
                        break;
                    case NfPagamentoTipo.CartaoDebito:
                        return "Cartão de Débito";
                        break;
                    case NfPagamentoTipo.CreditoLoja:
                        return "Crédito da Loja";
                        break;
                    case NfPagamentoTipo.ValeAlimentacao:
                        return "Vale Alimentação";
                        break;
                    case NfPagamentoTipo.ValeRefeicao:
                        return "Vale Refeição";
                        break;
                    case NfPagamentoTipo.ValePresente:
                        return "Vale Presente";
                        break;
                    case NfPagamentoTipo.ValeCombustivel:
                        return "Vale Combustível";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
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

        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            if (!SemNfPrincipal)
            {
                return base.ValidateData(ref command);
            }
            return true;
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public void LimparId()
        {
            this.ID = -1;
        }
    }
}
