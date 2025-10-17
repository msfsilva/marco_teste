using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace IWTNFCompleto
{
    public static partial class NFeOperacoes
    {

        public static string versaoLayout = "4.00";
        public static string versaoLayoutConsultaString = "4.00";
        public static TVerConsSitNFeLegado versaoLayoutConsulta = TVerConsSitNFeLegado.Item400;

        internal static int timeoutPadrao = 120000;
        public static string versaoAplicativoEmissor = "1.00";


        public static int getProximoNumeroNf(string cnpjEmitente, string modelo, IWTPostgreNpgsqlCommand command, TAmbLegado ambiente, out int serieNFe)
        {
            try
            {
                //Busca a série atual
                command.CommandText =
                    "SELECT  " +
                    "  MAX(public.nfe_completo_nota.nfn_serie) " +
                    "FROM " +
                    "  public.nfe_completo_nota " +
                    "WHERE " +
                    "  public.nfe_completo_nota.nfn_cnpj_emitente = :nfn_cnpj_emitente AND " +
                    "  public.nfe_completo_nota.nfn_modelo = :nfn_modelo AND ";

                command.CommandText += " public.nfe_completo_nota.nfn_serie <= 889 AND ";
              

                if (ambiente == TAmbLegado.Homologacao)
                {
                    command.CommandText += " public.nfe_completo_nota.nfn_homologacao = 1 ";
                }
                else
                {
                    command.CommandText += " public.nfe_completo_nota.nfn_homologacao = 0 ";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_cnpj_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = cnpjEmitente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = modelo;
                


                object tmpSerie = command.ExecuteScalar();
                int serieUltimaNFEmitida = 0;
                if (tmpSerie != null && tmpSerie != DBNull.Value)
                {
                    serieUltimaNFEmitida = (int)tmpSerie;
                }


                int serieUltimaNotaEmitidaModuloAntigo = 0;

                serieUltimaNotaEmitidaModuloAntigo = NfPrincipalClass.maxSerieNf(cnpjEmitente, modelo, ambiente == TAmbLegado.Homologacao, false, command);
                serieNFe = Math.Max(serieUltimaNFEmitida, serieUltimaNotaEmitidaModuloAntigo);

                if (serieNFe == 0)
                {

                    serieNFe = 1;

                }


                //Busca o numero dentro da série atual
                command.CommandText =
                    "SELECT  " +
                    "  MAX(public.nfe_completo_nota.nfn_numero) " +
                    "FROM " +
                    "  public.nfe_completo_nota " +
                    "WHERE " +
                    "  public.nfe_completo_nota.nfn_serie = :nfn_serie AND " +
                    "  public.nfe_completo_nota.nfn_cnpj_emitente = :nfn_cnpj_emitente AND "+
                    "  public.nfe_completo_nota.nfn_modelo = :nfn_modelo AND ";

                if (ambiente == TAmbLegado.Homologacao)
                {
                    command.CommandText += " public.nfe_completo_nota.nfn_homologacao = 1 ";
                }
                else
                {
                    command.CommandText += " public.nfe_completo_nota.nfn_homologacao = 0 ";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = serieNFe;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_cnpj_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = cnpjEmitente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = modelo;

                object tmp1 = command.ExecuteScalar();
                int ultimaNFEmitida = 0;
                if (tmp1 != null && tmp1 != DBNull.Value)
                {
                    ultimaNFEmitida = (int) tmp1;
                }

                int ultimaNotaEmitidaModuloAntigo = 0;


                ultimaNotaEmitidaModuloAntigo = NfPrincipalClass.maxNumeroNf(cnpjEmitente, serieNFe, modelo, ambiente == TAmbLegado.Homologacao, false, command);



                int toRet = Math.Max(ultimaNFEmitida, ultimaNotaEmitidaModuloAntigo) + 1;

                //Testa faixas inutilizadas
                command.CommandText =
                    "SELECT  " +
                    "  MAX(public.nfe_completo_inutilizacao.nci_fim) " +
                    "FROM " +
                    "  public.nfe_completo_inutilizacao " +
                    "WHERE " +
                    "  :numeroteste >= public.nfe_completo_inutilizacao.nci_inicio AND  " +
                    "  :numeroteste <= public.nfe_completo_inutilizacao.nci_fim AND " +
                    "  public.nfe_completo_inutilizacao.nci_cnpj =:nfn_cnpj_emitente AND  " +
                    "  public.nfe_completo_inutilizacao.nci_serie = :nfn_serie AND ";

                if (ambiente == TAmbLegado.Homologacao)
                {
                    command.CommandText += " public.nfe_completo_inutilizacao.nci_homologacao = 1 ";
                }
                else
                {
                    command.CommandText += " public.nfe_completo_inutilizacao.nci_homologacao = 0 ";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = serieNFe;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_cnpj_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = cnpjEmitente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("numeroteste", NpgsqlDbType.Integer));

                bool numeroEncontrado = false;
                while (!numeroEncontrado)
                {
                    command.Parameters["numeroteste"].Value = toRet;
                    object tmp = command.ExecuteScalar();
                    if (tmp == null || tmp == DBNull.Value)
                    {
                        numeroEncontrado = true;
                    }
                    else
                    {
                        toRet = Convert.ToInt32(tmp) + 1;
                    }
                }

                while (toRet > 999999999)
                {
                    serieNFe++;
                    toRet = 1;
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_serie", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = serieNFe;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_cnpj_emitente", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = cnpjEmitente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("numeroteste", NpgsqlDbType.Integer));

                    numeroEncontrado = false;
                    while (!numeroEncontrado)
                    {
                        command.Parameters["numeroteste"].Value = toRet;
                        object tmp = command.ExecuteScalar();
                        if (tmp == null || tmp == DBNull.Value)
                        {
                            numeroEncontrado = true;
                        }
                        else
                        {
                            toRet = Convert.ToInt32(tmp) + 1;
                        }
                    }
                }

                return toRet;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o próximo numero de NF.\r\n" + e.Message, e);
            }
        }

      
    }
}
