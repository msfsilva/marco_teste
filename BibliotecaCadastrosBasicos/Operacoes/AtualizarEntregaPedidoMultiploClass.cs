using System;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;

using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using order;

namespace BibliotecaCadastrosBasicos.Operacoes
{
    public class AtualizarEntregaPedidoMultiploClass
    {
        public string Pedido { get; set; }
        public int Posicao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public string Justificativa { get; set; }
       
        public PedidoItemClass PedidoEasi { get; set; }

        public void Save(ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario)
        {
            try
            {
                if (DataEntrega.HasValue && (string.IsNullOrWhiteSpace(Justificativa) || Justificativa.Length < 5))
                {
                    throw new ExcecaoTratada("Campo de justificativa inv�lida para o pedido " + PedidoEasi.ToString());
                }

                if (!DataEntrega.HasValue) return;

                PedidoEasi.DataEntrega = DataEntrega.Value;

                if (IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.HISTORICO_ALTERACOES_PEDIDO))
                {
                    PedidoEasi.JustificativaAlteracaoAtual = Justificativa;
                }
                else
                {
                    PedidoEasi.CollectionPedidoItemFeedbackClassPedidoItem.Add(new PedidoItemFeedbackClass(usuario, command.Connection)
                    {
                        Texto = "Altera��o de Data de Entrega em lote (" + Justificativa + ") ",
                        Atual = true,
                        Data = DataIndependenteClass.GetData(),
                        PedidoItem = PedidoEasi,
                        AcsUsuario = usuario
                    });
                }


                PedidoEasi.SalvarJustificativa(command);
                PedidoEasi.Save(ref command);

                if (PedidoEasi.Cliente.FamiliaCliente.TipoEspecial == TipoFamiliaEspecial.EASSA && IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.USE_SUPPLYON))
                {
                    Order order = new Order();
                    order.readFromBD(command.Connection, Pedido, Posicao.ToString());

                    order.DeliveryDate = this.DataEntrega.Value.ToString("dd.MM.yyyy");


                    order.ChangeStatus("changed_status", "0", command);
                    order.ChangeStatus("status", "TO_CONFIRM", command);
                    order.WriteToBd(command, "EDISHEET", "111");

                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao salvar o pedido \r\n" + e.Message, e);
            }
        }
    }
}