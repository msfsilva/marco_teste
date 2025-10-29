using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;

namespace BibliotecaNFeCompleta
{
    public class NFeEasiCompletoRunner : NFeCompletoRunnerClass
    {
        public NFeEasiCompletoRunner(string certificado, Semaphore semaforoEmissaoNf, string ufEmitente, string cnpjTransmissor, AcsUsuarioClass usuarioAtual, string connectionString, byte[] logoDanfe, DadosSalvarEnviarNfe dadosSalvarEnviarNfe)
            : base(certificado, semaforoEmissaoNf, ufEmitente, cnpjTransmissor, usuarioAtual, connectionString, logoDanfe, dadosSalvarEnviarNfe)
        {

            ExibirDuplicatas = true;
            ExibirFaturas = false;

            IWTNFCompleto.DanfeNFeClass.IncluirDuplicatasObs = false;
            base.ImprimirZerosTributosVazios = IWTConfiguration.Conf.getBoolConf(Constants.IMPRESSAO_VALORES_ZERO_DANFE);

        }

        #region Processamento NFe

        protected override void ProcessaNFeRejeitadaAntesTransmissao(NfPrincipalClass nf, string motivo, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE) == "1")
                {
                    MessageBox.Show(null, "A nota fiscal " + nf.Numero + " foi rejeitada com o seguinte motivo: " + motivo, "Nota fiscal REJEITADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        LogClass.EscreverLog("NotaRejeitadaAntes:" + nf.Numero + " - " + motivo, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch
                    {
                    }

                    string mensagemUsuario;
                    NFeEasiFuncoesAuxiliaresClass.RejeicaoNFe(nf, motivo, _usuarioAtual, command, out mensagemUsuario);

                    MessageBox.Show(null, mensagemUsuario, "Nota fiscal REJEITADA antes da transmissão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {
                try
                {
                    LogClass.EscreverLog("ProcessaNFeRejeitadaAntesTransmissaoException:" + nf.Numero + " " + e.Message, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                }
                catch { }

                throw e;
            }
        }

        protected override void ProcessaLoteRejeitado(LoteEnviar lote, List<NfPrincipalClass> notasLote, IWTPostgreNpgsqlCommand command)
        {
            try
            {
                //TipoEmissaoNFe.SistemaReceitaSPEasiHomologacao
                if (IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE) == "1")
                {
                    MessageBox.Show(null, "O lote de notas fiscais foi rejeitado com o seguinte motivo: " + lote.Observacao, "Lote Rejeitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        string notas = notasLote.Aggregate("", (res, registro) => res + "/" + registro.Numero);
                        LogClass.EscreverLog("LoteRejeitado:" + notas + " - " + lote.Observacao, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch
                    {
                    }

                    string mensagemUsuarioCompleta = "O lote de notas fiscais foi rejeitado, as seguintes nota foram rejeitas indiretamente:";

                    foreach (NfPrincipalClass nf in notasLote)
                    {
                        string mensagemUsuario;
                        NFeEasiFuncoesAuxiliaresClass.RejeicaoNFe(nf, lote.Observacao, _usuarioAtual, command, out mensagemUsuario);

                        mensagemUsuarioCompleta += Environment.NewLine + mensagemUsuario;

                    }

                    MessageBox.Show(null, mensagemUsuarioCompleta, "Lote Rejeitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


            }
            catch (Exception e)
            {



                try
                {
                    string notas = notasLote.Aggregate("", (res, registro) => res + "/" + registro.Numero);
                    LogClass.EscreverLog("ProcessaLoteRejeitadoException:" + notas + " " + e.Message, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                }
                catch
                {
                }
                throw new Exception("Erro ao tratar o lote rejeitado.\r\n" + e.Message, e);
            }
        }

        protected override void ProcessaNotasAEnviar(NfPrincipalClass notasAEnviar, bool homologacao, IWTPostgreNpgsqlCommand command)
        {

        }
        #endregion

        #region Processamento de Resultado


        protected override void ProcessaNFeDenegada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            MessageBox.Show(null, "A nota fiscal " + nota.NFeEmitida.Numero + " foi denegada com o seguinte motivo: " + nota.codigoRetorno + "(" + nota.observacaoRetorno + ")", "Nota fiscal DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        protected override void ProcessaNFeRejeitada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                //TipoEmissaoNFe.SistemaReceitaSPEasiHomologacao
                if (IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE) == "1")
                {
                    MessageBox.Show(null,
                        "A nota fiscal " + nota.NFeEmitida.Numero + " foi rejeitada com o seguinte motivo: " + nota.codigoRetorno + "(" + nota.observacaoRetorno + ")", "Nota fiscal REJEITADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    try
                    {
                        LogClass.EscreverLog("NotaRejeitada:" + nota.NFeEmitida.Numero + " - " + nota.codigoRetorno + "-" + nota.observacaoRetorno, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch
                    {
                    }


                    string mensagemUsuario;
                    if (nota.NFeEmitida.NfPrincipal != null)
                    {
                        NFeEasiFuncoesAuxiliaresClass.RejeicaoNFe(nota.NFeEmitida.NfPrincipal, nota.observacaoRetorno, _usuarioAtual, command, out mensagemUsuario);
                    }
                    else
                    {
                        mensagemUsuario = "A nota fiscal " + nota.NFeEmitida.Numero + " foi rejeitada com o seguinte motivo: " + nota.observacaoRetorno + "";
                    }

                    MessageBox.Show(null, mensagemUsuario, "Nota fiscal REJEITADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            catch (Exception e)
            {
                try
                {
                    LogClass.EscreverLog("ProcessaNFeRejeitadaoException:" + nota.NFeEmitida.Numero + " " + e.Message, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                }
                catch
                {
                }

                throw e;
            }
        }

        protected override void ProcessaNFeProcessada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            if (nota.NFeEmitida.NfPrincipal == null)
            {
                return;
            }

            if (nota.NotaFiscal.infNFe.ide.tpNF == TNFeInfNFeIdeTpNF.Item1)
            {
                //Verifica se tem nota dependente para liberar

                command.CommandText = "SELECT * FROM nf_depende WHERE id_nf_principal_depende = :id_nf_principal";
                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Bigint, nota.NFeEmitida.NfPrincipal.ID));

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                string sqlToRun = "";
                while (read.Read())
                {
                    sqlToRun += "INSERT INTO nf_notas_relacionadas (id_nf_principal, nfn_chave) VALUES(" + read["id_nf_principal"] + ",'" + nota.NFeEmitida.Chave + "'); " + Environment.NewLine;
                    sqlToRun += "UPDATE nf_principal SET nfp_enviar_nfe_receita = 1, version = version + 1 WHERE id_nf_principal = " + read["id_nf_principal"] + ";" + Environment.NewLine;
                    sqlToRun += "DELETE FROM public.nf_depende WHERE id_nf_depende = " + read["id_nf_depende"] + "; " + Environment.NewLine;
                }

                read.Close();

                if (!string.IsNullOrWhiteSpace(sqlToRun))
                {
                    command.CommandText = sqlToRun;
                    command.Parameters.Clear();
                    command.ExecuteNonQuery();
                }


                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia.id_embarque " +
                    "FROM " +
                    "  public.nf_principal " +
                    "  INNER JOIN public.nf_emitente ON (public.nf_principal.id_nf_principal = public.nf_emitente.id_nf_principal) " +
                    "  INNER JOIN public.atendimento ON (public.nf_principal.id_nf_principal = public.atendimento.id_nf_principal) " +
                    "  INNER JOIN public.order_item_etiqueta_conferencia ON (public.atendimento.id_order_item_etiqueta_conferencia = public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) " +
                    "WHERE " +
                    "  public.nf_principal.nfp_numero = :nfp_numero AND " +
                    "  public.nf_principal.nfp_serie = :nfp_serie AND  " +
                    "  public.nf_emitente.nfe_cnpj_cpf = :nfe_cnpj_cpf ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = nota.NFeEmitida.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = nota.NFeEmitida.Serie;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_cnpj_cpf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = nota.NFeEmitida.CnpjEmitente;

                object tmp2 = command.ExecuteScalar();
                int idEmbarque;
                if (tmp2 != DBNull.Value && tmp2 != null)
                {
                    idEmbarque = Convert.ToInt32(tmp2);
                }
                else
                {
                    //Não é vinculada a embarque
                    return;
                }

                //Verifica se é a última NFe do embarque, se for encerra o embarque

                command.CommandText =
                    "SELECT  " +
                    "COUNT(public.nfe_completo_nota.id_nfe_completo_nota) " +
                    "FROM " +
                    "  public.atendimento " +
                    "  INNER JOIN public.order_item_etiqueta_conferencia ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia = public.atendimento.id_order_item_etiqueta_conferencia) " +
                    "  INNER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal) " +
                    "  INNER JOIN public.nf_emitente ON (public.nf_principal.id_nf_principal = public.nf_emitente.id_nf_principal) " +
                    "  RIGHT OUTER JOIN public.nfe_completo_nota ON (public.nf_emitente.nfe_cnpj_cpf = public.nfe_completo_nota.nfn_cnpj_emitente) " +
                    "  AND (public.nf_principal.nfp_numero = public.nfe_completo_nota.nfn_numero) " +
                    "  AND (public.nf_principal.nfp_serie = public.nfe_completo_nota.nfn_serie) " +
                    "  AND (public.nf_principal.nfp_homologacao = public.nfe_completo_nota.nfn_homologacao) " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.id_embarque = :id_embarque AND  " +
                    "  (public.nfe_completo_nota.nfn_situacao IS NULL OR  " +
                    "  public.nfe_completo_nota.nfn_situacao != 1) ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_embarque", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idEmbarque;

                object tmp3 = command.ExecuteScalar();
                int notasPendentes = 0;
                if (tmp3 != DBNull.Value && tmp3 != null)
                {
                    notasPendentes = Convert.ToInt32(tmp3);
                }

                if (notasPendentes == 0)
                {
                    EmbarqueClass.MarcarEmbarqueEncerrado(idEmbarque, ref command);
                }
                return;
            }

        }

        protected override void getEmailsCliente(NfPrincipalClass nf, out string emailXML, out string emailDanfe, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                if (IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE) == "1")
                {
                    emailXML = null;
                    emailDanfe = null;
                    return;
                }

                if (nf == null)
                {
                    emailXML = null;
                    emailDanfe = null;
                    return;
                };

                long idNfPrincipal = nf.ID;

                command.CommandText =
                    "SELECT  " +
                    "    public.pedido_item.id_cliente " +
                    "FROM " +
                    "    public.atendimento " +
                    "    INNER JOIN public.pedido_item ON (public.atendimento.id_pedido_item = public.pedido_item.id_pedido_item) " +
                    "WHERE " +
                    "    public.atendimento.id_nf_principal = :id_nf_principal  ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idNfPrincipal;

                int idCliente = Convert.ToInt32(command.ExecuteScalar());
                if (idCliente > 0)
                {
                    ClienteClass cliente = ClienteBaseClass.GetEntidade(idCliente, LoginClass.UsuarioLogado.loggedUser, command.Connection);

                    if (cliente.EnvioEmail)
                    {
                        emailDanfe = cliente.EmailDanfe;
                        emailXML = cliente.EmailXml;
                    }
                    else
                    {
                        emailDanfe = null;
                        emailXML = null;
                    }
                }
                else
                {
                    emailDanfe = !string.IsNullOrWhiteSpace(nf.NfCliente.EmailDanfe) ? nf.NfCliente.EmailDanfe : nf.NfCliente.Email;
                    emailXML = !string.IsNullOrWhiteSpace(nf.NfCliente.EmailXml) ? nf.NfCliente.EmailXml : nf.NfCliente.Email;
                }

            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao identificar os emails do cliente para envio da NFe\r\n" + e.Message, e);
            }
        }
        
        #endregion
    }
}
