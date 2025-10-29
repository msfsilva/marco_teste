using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using Configurations;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;
using OrdemCompraClass = BibliotecaEntidades.Entidades.OrdemCompraClass;


namespace BibliotecaCadastrosBasicos.Operacoes
{
    public class SincronizarOCsSdcClass
    {
        private IWTPostgreNpgsqlConnection _conn;
        private AcsUsuarioClass _usuario;

        private bool _suprimirErrosTela;
        private readonly string _arquivoLog;


        public SincronizarOCsSdcClass(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario, bool suprimirErrosTela = false, string arquivoLog = null)
        {
            _conn = conn;
            _usuario = usuario;
            _suprimirErrosTela = suprimirErrosTela;
            _arquivoLog = arquivoLog;
        }

        private OrdemCompraClass GerarOc(OrdemCompraDto dto,FormaPagamentoClass formaPagamento, string observacoes, IWTPostgreNpgsqlCommand command)
        {
            try
            {

                OrdemCompraClass oc = OrdemCompraClass.GerarOc(dto, formaPagamento,observacoes, _usuario, _conn);
                oc.Save(ref command);

                return oc;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar a ordem de compra\r\n" + e.Message, e);
            }

        }

        public void Start()
        {
            try
            {
                StringBuilder erros = new StringBuilder();

                OrdemCompraSaidaDto dto = ApiSimuladorCompras.GetOrdensCompraPendentes();

                if (dto != null)
                {
                    foreach (OrdemCompraDto ordemCompraDto in dto.ordemCompraDtoList)
                    {
                        IWTPostgreNpgsqlCommand command = null;

                        try
                        {

                            SincronizarOCsSdcForm form = new SincronizarOCsSdcForm(ordemCompraDto, _conn);
                            form.ShowDialog();

                            bool consumida = false;

                            if (form.FormaPagamento != null)
                            {
                                command = _conn.CreateCommand();
                                command.Transaction = command.Connection.BeginTransaction();


                                OrdemCompraClass oc = GerarOc(ordemCompraDto, form.FormaPagamento, form.Observacoes, command);
                                if (oc != null)
                                {
                                    consumida = true;
                                    if (IWTConfiguration.Conf.getBoolConf(Constants.FLUXO_APROVACAO_COMPRAS_HABILITADO) &&
                                        IWTConfiguration.Conf.getBoolConf(Constants.SIMULADOR_COMPRAS_HABILITADO))
                                    {
                                        OrdemCompraClass.GerarAprovacao(oc, _usuario, _conn, ref command);

                                        oc.Status = StatusOrdemCompra.AguardandoAprovacaoCompras;

                                        oc.Save(ref command);
                                    }
                                }
                            }
                           
                            if (consumida)
                            {
                                ApiSimuladorCompras.ConsumirOrdemCompra(new ConsumirOrdemCompraDto() {ordensParaConsumir = new List<long>() {ordemCompraDto.id}});
                                command.Transaction.Commit();
                            }
                            else
                            {
                                command?.Transaction?.Rollback();
                            }

                        }
                        catch (Exception e)
                        {
                            erros.AppendLine("Erro ao gerar a OC " + ordemCompraDto.id + ". " + e.Message);
                            command?.Transaction?.Rollback();
                        }
                    }
                }

                if (erros.Length > 0)
                {
                    if (!_suprimirErrosTela)
                    {
                        ScrollableMessageBox sc = new ScrollableMessageBox(null, erros.ToString(), "Erros na operação de sincronização", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sc.ShowDialog();
                    }

                    if (!string.IsNullOrWhiteSpace(_arquivoLog))
                    {
                        File.WriteAllText(_arquivoLog, erros.ToString());
                    }
                }


            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao sincronizar os cadastros: " + e.Message);
            }

        }
    }
}
