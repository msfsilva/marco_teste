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
    public class NfeCompletoNotaClass : NfeCompletoNotaBaseClass
    {


        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfeCompletoNotaClass";
        protected new const string ErroDelete = "Erro ao excluir o NfeCompletoNotaClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfeCompletoNotaClass.";
        protected new const string ErroCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota = "Erro ao carregar a coleção de NfeCompletoCartaCorrecaoClass.";
        protected new const string ErroXmlObrigatorio = "O campo Xml é obrigatório";
        protected new const string ErroChaveObrigatorio = "O campo Chave é obrigatório";
        protected new const string ErroChaveComprimento = "O campo Chave deve ter no máximo 50 caracteres";
        protected new const string ErroCnpjEmitenteObrigatorio = "O campo CnpjEmitente é obrigatório";
        protected new const string ErroCnpjEmitenteComprimento = "O campo CnpjEmitente deve ter no máximo 50 caracteres";
        protected new const string ErroNfeCompletoLoteObrigatorio = "O campo NfeCompletoLote é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NfeCompletoNotaClass.";
        protected new const string MensagemUtilizadoCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota = "A entidade NfeCompletoNotaClass está sendo utilizada nos seguintes NfeCompletoCartaCorrecaoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfeCompletoNotaClass está sendo utilizada.";

        #endregion

        public NfeCompletoNotaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        protected override void InitClass()
        {
            ControleRevisaoHabilitado = false;
        }

        public override string ToString()
        {
            return "NFe Série " + this.Serie + " nº " + this.Numero;
        }

        [UnCloneable(UnCloneableAttributeType.RetNull)]
        public string CNPJDestinatario
        {
            get
            {
                string toRet = "";
                if (!string.IsNullOrWhiteSpace(this.Xml))
                {
                    int indexInicial = this.Xml.IndexOf("<dest>");
                    if (indexInicial == -1) return "";

                    int indexFinal = this.Xml.IndexOf("</dest>");

                    int start = this.Xml.IndexOf("<CNPJ>", indexInicial);
                    if (start != -1)
                    {
                        if (start > indexFinal) return "";
                        toRet = this.Xml.Substring(start + 6, 14);
                    }
                    else
                    {
                        start = this.Xml.IndexOf("<CPF>", indexInicial);
                        if (start != -1)
                        {
                            if (start > indexFinal) return "";
                            toRet = this.Xml.Substring(start + 5, 11);
                        }
                    }
                }

                return toRet;
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetNull)]
        public string NomeDestinatario
        {
            get
            {
                string toRet = "";
                if (!string.IsNullOrWhiteSpace(this.Xml))
                {
                    int indexInicial = this.Xml.IndexOf("<dest>");
                    if (indexInicial == -1) return "";
                    int indexFinal = this.Xml.IndexOf("</dest>");

                    int start = this.Xml.IndexOf("<xNome>", indexInicial);
                    if (start != -1)
                    {
                        start += 7;
                       
                    }

                    if (start != -1)
                    {
                        if (start > indexFinal) return "";
                        int stop =  this.Xml.IndexOf("</xNome>",start);
                        if (stop != -1)
                        {

                            toRet = this.Xml.Substring(start, stop - start);
                        }
                    }

                }


                return toRet;
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetNull)]
        public double ValorNota
        {
            get
            {
                double toRet = 0;
                if (!string.IsNullOrWhiteSpace(this.Xml))
                {
                    int indexInicial = this.Xml.IndexOf("<total>");
                    if (indexInicial == -1) return 0;
                    int indexFinal = this.Xml.IndexOf("</total>");

                    int start = this.Xml.IndexOf("<vNF>", indexInicial);
                    if (start != -1)
                    {
                        start += 5;

                    }

                    if (start != -1)
                    {
                        if (start > indexFinal) return 0;
                        int stop = Xml.IndexOf("</vNF>", start);
                        if (stop != -1)
                        {
                            string tmp = this.Xml.Substring(start, stop - start);

                            if (double.TryParse(tmp, NumberStyles.Any, CultureInfo.InvariantCulture, out toRet))
                            {
                                return toRet;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }

                }


                return toRet;
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetNull)]
        public double ValorBc
        {
            get
            {
                double toRet = 0;
                if (!string.IsNullOrWhiteSpace(this.Xml))
                {
                    int indexInicial = this.Xml.IndexOf("<total>");
                    if (indexInicial == -1) return 0;
                    int indexFinal = this.Xml.IndexOf("</total>");

                    int start = this.Xml.IndexOf("<vBC>", indexInicial);
                    if (start != -1)
                    {
                        start += 5;

                    }

                    if (start != -1)
                    {
                        if (start > indexFinal) return 0;
                        int stop = Xml.IndexOf("</vBC>", start);
                        if (stop != -1)
                        {
                            string tmp = this.Xml.Substring(start, stop - start);

                            if (double.TryParse(tmp, NumberStyles.Any, CultureInfo.InvariantCulture, out toRet))
                            {
                                return toRet;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }

                }


                return toRet;
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetNull)]
        public double ValorIcms
        {
            get
            {
                double toRet = 0;
                if (!string.IsNullOrWhiteSpace(this.Xml))
                {
                    int indexInicial = this.Xml.IndexOf("<total>");
                    if (indexInicial == -1) return 0;
                    int indexFinal = this.Xml.IndexOf("</total>");

                    int start = this.Xml.IndexOf("<vICMS>", indexInicial);
                    if (start != -1)
                    {
                        start += 7;

                    }

                    if (start != -1)
                    {
                        if (start > indexFinal) return 0;
                        int stop = Xml.IndexOf("</vICMS>", start);
                        if (stop != -1)
                        {
                            string tmp = this.Xml.Substring(start, stop - start);

                            if (double.TryParse(tmp, NumberStyles.Any, CultureInfo.InvariantCulture, out toRet))
                            {
                                return toRet;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }

                }


                return toRet;
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetNull)]
        public double ValorIpi
        {
            get
            {
                double toRet = 0;
                if (!string.IsNullOrWhiteSpace(this.Xml))
                {
                    int indexInicial = this.Xml.IndexOf("<total>");
                    if (indexInicial == -1) return 0;
                    int indexFinal = this.Xml.IndexOf("</total>");

                    int start = this.Xml.IndexOf("<vIPI>", indexInicial);
                    if (start != -1)
                    {
                        start += 6;

                    }

                    if (start != -1)
                    {
                        if (start > indexFinal) return 0;
                        int stop = Xml.IndexOf("</vIPI>", start);
                        if (stop != -1)
                        {
                            string tmp = this.Xml.Substring(start, stop - start);

                            if (double.TryParse(tmp, NumberStyles.Any, CultureInfo.InvariantCulture, out toRet))
                            {
                                return toRet;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }

                }


                return toRet;
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetNull)]
        public string DataEntradaSaida
        {
            get
            {
                string toRet = "";
                if (!string.IsNullOrWhiteSpace(this.Xml))
                {
                    int indexInicial = this.Xml.IndexOf("<ide>");
                    if (indexInicial == -1) return "";
                    int indexFinal = this.Xml.IndexOf("</ide>");

                    int start = this.Xml.IndexOf("<dhSaiEnt>", indexInicial);
                    if (start != -1)
                    {
                        start += 10;

                    }

                    if (start != -1)
                    {
                        if (start > indexFinal) return "";
                        int stop = Xml.IndexOf("</dhSaiEnt>", start);
                        if (stop != -1)
                        {
                            string tmp = this.Xml.Substring(start, stop - start);
                            DateTime tmp2;
                            if (DateTime.TryParse(tmp, CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp2))
                            {
                                return tmp2.ToString("dd/MM/yyyy HH:mm:ss");
                            }
                            else
                            {
                                return tmp;
                            }
                            
                           
                        }
                    }

                }

                return toRet;
            }
        }


        [UnCloneable(UnCloneableAttributeType.RetNull)]
        public string CartaCorrecaoString
        {
            get
            {

                string toRet = "";

                foreach (NfeCompletoCartaCorrecaoClass cce in CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota)
                {
                    toRet += cce.Texto + " / ";
                }

                if (toRet.EndsWith(" / "))
                {
                    toRet = toRet.Substring(0, toRet.Length - 3);
                }
                return toRet;
            }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Enviadas":
                    if (parametro.Fieldvalue as bool? == true)
                    {
                        whereClause += " AND ( " +
                                       " nfn_situacao = 0 " +
                                       ") ";
                    }
                    return true;
                case "Autorizadas":
                    if (parametro.Fieldvalue as bool? == true)
                    {
                        whereClause += " AND ( " +
                                       " nfn_situacao = 1 " +
                                       ") ";
                    }
                    return true;
                case "Denegadas":
                    if (parametro.Fieldvalue as bool? == true)
                    {
                        whereClause += " AND ( " +
                                       " nfn_situacao = 2 " +
                                       ") ";
                    }
                    return true;
                case "Canceladas":
                    if (parametro.Fieldvalue as bool? == true)
                    {
                        whereClause += " AND ( " +
                                       " nfn_situacao = 3 " +
                                       ") ";
                    }
                    return true;
                case "Todas":
                    return true;

                case "DataEmissaoIni":
                    if (parametro.Fieldvalue as DateTime? != null)
                    {
                        whereClause += " AND ( " +
                                       " nfn_data_emissao > :dataIni " +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dataIni", NpgsqlDbType.Date));
                        command.Parameters["dataIni"].Value = ((DateTime) parametro.Fieldvalue).Date.AddDays(-1);
                    }
                    return true;

                case "DataEmissaoFim":
                    if (parametro.Fieldvalue as DateTime? != null)
                    {
                        whereClause += " AND ( " +
                                       " nfn_data_emissao < :dataFim " +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dataFim", NpgsqlDbType.Date));
                        command.Parameters["dataFim"].Value = ((DateTime) parametro.Fieldvalue).Date.AddDays(1);
                    }
                    return true;

                case "Homologacao":
                    whereClause += parametro.Fieldvalue as bool? == true
                                       ? " AND ( " +
                                         " nfn_homologacao = 1 " +
                                         ") "

                                       : " AND ( " +
                                         " nfn_homologacao = 0 " +
                                         ") ";
                    return true;

                case "Producao":
                    whereClause += parametro.Fieldvalue as bool? == true
                                       ? " AND ( " +
                                         " nfn_homologacao = 0 " +
                                         ") "

                                       : " AND ( " +
                                         " nfn_homologacao = 1 " +
                                         ") ";
                    return true;
               case "CnpjEmitenteExato":
                    if (parametro.Fieldvalue is string)
                    {
                        whereClause += " AND ( " +
                                       " nfn_cnpj_emitente = :CnpjEmitenteExato " +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("CnpjEmitenteExato", NpgsqlDbType.Varchar));
                        command.Parameters["CnpjEmitenteExato"].Value = parametro.Fieldvalue;
                    }
                    else
                    {
                        throw new Exception("Parâmetro Inválido, esperado string");
                    }
                    return true;

                case "SomenteNFe":
                    whereClause += parametro.Fieldvalue as bool? == true
                        ? " AND ( " +
                          " nfn_modelo = '55' " +
                          ") "

                        : "";
                    return true;
                case "SomenteNFCe":
                    whereClause += parametro.Fieldvalue as bool? == true
                        ? " AND ( " +
                          " nfn_modelo = '65' " +
                          ") "

                        : "";
                    return true;

                case "CartaCorrecao":
                    command.CommandText +=
                        "   INNER JOIN \r\n(\r\n  SELECT   \r\n\tnfe_completo_carta_correcao.id_nfe_completo_nota, \r\n  \tiwt_agregate_gavetas_estoque(public.nfe_completo_carta_correcao.ncc_texto) as texto\r\n  FROM nfe_completo_carta_correcao\r\n  GROUP BY\r\n  nfe_completo_carta_correcao.id_nfe_completo_nota\r\n )cce ON (public.nfe_completo_nota.id_nfe_completo_nota = cce.id_nfe_completo_nota) ";
                    whereClause += " AND ( cce.texto ILIKE :CartaCorrecao) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("CartaCorrecao", NpgsqlDbType.Varchar));
                    command.Parameters["CartaCorrecao"].Value = "%" + parametro.Fieldvalue + "%";

                    return true;

                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "NomeDestinatario":
                case "CNPJDestinatario":
                case "CartaCorrecaoString":
                    return true;
                default:
                    return false;
            }

        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                if (this.Serie > 999)
                {
                    throw new Exception("A série deve ser menor que 1000");
                }


                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os dados da NFe.\r\n" + e.Message, e);
            }
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public void setCancelamento(string justificativa, string xml, DateTime? dataCancelamento = null)
        {
            this.Situacao = Base.SituacaoNFe.Cancelada;
            this.JustificativaCancelamento = justificativa;
            this.UsuarioCancelamento = UsuarioAtual.Login;
            this.XmlCancelamento = xml;
            if (dataCancelamento.HasValue)
            {
                this.DataCancelamento = dataCancelamento.Value;
            }
            else
            {
                this.DataCancelamento = DateTime.Now;
            }
            


        }

        public void ReloadCartaCorrecao(IWTPostgreNpgsqlCommand command = null)
        {
            bool sozinho = false;
            if (command == null)
            {

                loading = true;
                sozinho = true;
            }

            this.LoadCollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota();


            if (sozinho)
            {
                loading = false;
            }

        }

        public NfeCompletoCartaCorrecaoClass CartaCorrecao
        {
            get
            {
                if (this.CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Count > 0)
                {
                    return this.CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota[0];
                }
                return null;
            }

            set
            {
                if (this.CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Count > 0)
                {
                    this.CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota[0] = value;
                }
                else
                {
                    this.CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Add(value);
                }
            }
        }




    }
}
