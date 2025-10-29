using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrderItemEtiquetaClass:OrderItemEtiquetaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrderItemEtiquetaClass";
protected new const string ErroDelete = "Erro ao excluir o OrderItemEtiquetaClass  ";
protected new const string ErroSave = "Erro ao salvar o OrderItemEtiquetaClass.";
protected new const string ErroCollectionAtendimentoClassOrderItemEtiqueta = "Erro ao carregar a coleção de AtendimentoClass.";
protected new const string ErroCollectionOrdemProducaoPedidoClassOrderItemEtiqueta = "Erro ao carregar a coleção de OrdemProducaoPedidoClass.";
protected new const string ErroCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta = "Erro ao carregar a coleção de OrderItemEtiquetaConferenciaNfClass.";
protected new const string ErroCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta = "Erro ao carregar a coleção de OrderItemEtiquetaConferenciaClass.";
protected new const string ErroCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected new const string ErroStatusPedidoObrigatorio = "O campo StatusPedido é obrigatório";
protected new const string ErroStatusPedidoComprimento = "O campo StatusPedido deve ter no máximo 2 caracteres";
protected new const string ErroArmazenagemClienteObrigatorio = "O campo ArmazenagemCliente é obrigatório";
protected new const string ErroArmazenagemClienteComprimento = "O campo ArmazenagemCliente deve ter no máximo 100 caracteres";
protected new const string ErroModeloEtiquetaObrigatorio = "O campo ModeloEtiqueta é obrigatório";
protected new const string ErroModeloEtiquetaComprimento = "O campo ModeloEtiqueta deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do OrderItemEtiquetaClass.";
protected new const string MensagemUtilizadoCollectionAtendimentoClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes AtendimentoClass:";
protected new const string MensagemUtilizadoCollectionOrdemProducaoPedidoClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes OrdemProducaoPedidoClass:";
protected new const string MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes OrderItemEtiquetaConferenciaNfClass:";
protected new const string MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes OrderItemEtiquetaConferenciaClass:";
protected new const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrderItemEtiquetaClass está sendo utilizada.";
#endregion

        
        

        public OrderItemEtiquetaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        protected override void InitClass()
        {
            this.ControleRevisaoHabilitado = false;
        }


        public override string ToString()
        {
            return this.OrderNumber + " - " + this.OrderPos;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "OrderNumberExato":
                    whereClause += " AND (UPPER(order_item_etiqueta.oie_order_number) = UPPER(:OrderNumberExato) )";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("OrderNumberExato", NpgsqlDbType.Varchar, parametro.Fieldvalue.ToString()));
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

        public static OrderItemEtiquetaClass CarregarPorBarcode(string barcode, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection)
        {
            if (!barcode.StartsWith("OIE_"))
            {
                throw new ExcecaoTratada("Código de barras em um formato inválido para o Pedido Configurado.");
                
            }
            
            string id = barcode.Remove(0, 4);
            return GetEntidade(int.Parse(id), usuarioAtual, connection);
        }

        public static List<OrderItemEtiquetaClass> GerarEtiquetasCustomizadasAvultas(string oc, int? posicao, int? pps, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                List<SearchParameterClass> parametros = new List<SearchParameterClass>();
                parametros.Add(new SearchParameterClass("TipoItem", TipoControleEtiquetaProduto.Customizado));
                parametros.Add(new SearchParameterClass("EtiquetaInterna", true));
                parametros.Add(new SearchParameterClass("EtiquetaInternaImpressa", false));
                parametros.Add(new SearchParameterClass("CncExato", null));
                

                if (oc != null && posicao.HasValue)
                {
                    parametros.Add(new SearchParameterClass("OrderNumberExato",oc));
                    parametros.Add(new SearchParameterClass("OrderPos", posicao.Value));
                }

                if (pps.HasValue)
                {
                    parametros.Add(new SearchParameterClass("Pps", pps.Value));
                }

                

                List<OrderItemEtiquetaClass> toRet = new OrderItemEtiquetaClass(usuario,conn).Search(parametros).ConvertAll(a=>(OrderItemEtiquetaClass)a).ToList();

                if (toRet.Count == 0)
                {
                    throw new ExcecaoTratada("Não foram encontrados itens customizados para imprimir as etiquetas com os parâmetros informados");
                }

                foreach (OrderItemEtiquetaClass item in toRet)
                {
                    item.Cnc = "SCNC";
                    item.CoordenadaX = "00";
                    item.CoordenadaY = "0";
                    item.Programador = LoginClass.UsuarioLogado.loggedUser.Login;

                    
                    item.Save(ref command);
                }

                command.Transaction.Commit();

                return toRet;
            }
            catch (ExcecaoTratada)
            {
                command?.Transaction?.Rollback();
                throw;
            }
            catch (Exception e)
            {
                command?.Transaction?.Rollback();
                throw new Exception("Erro inesperado ao gerar as etiquetas customizadas avulsas." + Environment.NewLine + e.Message);
            }
        }
    }
}
