using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF.Entidades.Base;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using IWTNFCompleto.BibliotecaEntidades.Base;

namespace IWTNFCompleto.BibliotecaEntidades.Entidades
{
    [Serializable()]
    public class NfeSituacaoTransmissaoClass : NfeSituacaoTransmissaoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfeSituacaoTransmissaoClass";
        protected new const string ErroDelete = "Erro ao excluir o NfeSituacaoTransmissaoClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfeSituacaoTransmissaoClass.";
        protected new const string ErroMensagemObrigatorio = "O campo Mensagem é obrigatório";
        protected new const string ErroNotaModeloObrigatorio = "O campo NotaModelo é obrigatório";
        protected new const string ErroNotaEmitenteObrigatorio = "O campo NotaEmitente é obrigatório";
        protected new const string ErroNotaDestinatarioObrigatorio = "O campo NotaDestinatario é obrigatório";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do NfeSituacaoTransmissaoClass.";

        protected new const string ErroUtilizado =
            "Erro ao verificar se a entidade NfeSituacaoTransmissaoClass está sendo utilizada.";

        #endregion

        public NfeSituacaoTransmissaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            return this.NotaNumero.ToString() + " " + this.NotaSerie.ToString() + " " + this.NotaModelo.ToString();
        }


        public string SituacaoTraduzida
        {
            get
            {
                switch (Situacao)
                {
                    case IWTNFSituacaoTransmissao.AguardandoEnvio:
                        return "Aguardando envio Para a Receita";
                        break;
                    case IWTNFSituacaoTransmissao.AguardandoResposta:
                        return "Aguardando a Resposta da Receita";
                        break;
                    case IWTNFSituacaoTransmissao.Processada:
                        return "Processada com Sucesso";
                        break;
                    case IWTNFSituacaoTransmissao.Rejeitada:
                        return "Nota Rejeitada";

                        break;
                    case IWTNFSituacaoTransmissao.Denegada:
                        return "Nota Denegada";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string TipoTraduzido
        {
            get
            {
                switch (NotaTipo)
                {
                    case IWTNFTipoNota.NFe:
                        return "NFe";
                        break;
                    case IWTNFTipoNota.NFCe:
                        return "NFCe";
                        break;
                    case IWTNFTipoNota.NFServicosLondrina:
                        return "Nota Fisca de Serviços - Londrina";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause,
            ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "DataEmissaoIni":
                    if (parametro.Fieldvalue as DateTime? != null)
                    {
                        whereClause += " AND ( " +
                                       " nst_nota_data_emissao > :dataIni " +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dataIni", NpgsqlDbType.Date));
                        command.Parameters["dataIni"].Value = ((DateTime)parametro.Fieldvalue).Date.AddDays(-1);
                    }
                    return true;

                case "DataEmissaoFim":
                    if (parametro.Fieldvalue as DateTime? != null)
                    {
                        whereClause += " AND ( " +
                                       " nst_nota_data_emissao < :dataFim " +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dataFim", NpgsqlDbType.Date));
                        command.Parameters["dataFim"].Value = ((DateTime)parametro.Fieldvalue).Date.AddDays(1);
                    }
                    return true;

                case "SomenteNFe":
                    whereClause += parametro.Fieldvalue as bool? == true
                        ? " AND ( " +
                          " nst_nota_tipo = 0 " +
                          ") "

                        : "";
                    return true;
                case "SomenteNFCe":
                    whereClause += parametro.Fieldvalue as bool? == true
                        ? " AND ( " +
                          " nst_nota_tipo = 1 " +
                          ") "

                        : "";
                    return true;
                case "SomenteNFSL":
                    whereClause += parametro.Fieldvalue as bool? == true
                        ? " AND ( " +
                          " nst_nota_tipo = 2 " +
                          ") "

                        : "";
                    return true;
                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "SituacaoTraduzida":
                    orderByClause += " , nst_situacao " + orderByClause.ToString() + " ";
                    return true;

                case "TipoTraduzido":
                    orderByClause += " , nst_nota_tipo " + orderByClause.ToString() + " ";
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
