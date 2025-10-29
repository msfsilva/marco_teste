using System;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;

namespace BibliotecaEntidades.Entidades
{
    public class EmbarqueClass : EmbarqueBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EmbarqueClass";
        protected new const string ErroDelete = "Erro ao excluir o EmbarqueClass  ";
        protected new const string ErroSave = "Erro ao salvar o EmbarqueClass.";
        protected new const string ErroCollectionOrderItemEtiquetaConferenciaClassEmbarque = "Erro ao carregar a coleção de OrderItemEtiquetaConferenciaClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do EmbarqueClass.";
        protected new const string MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaClassEmbarque = "A entidade EmbarqueClass está sendo utilizada nos seguintes OrderItemEtiquetaConferenciaClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EmbarqueClass está sendo utilizada.";

        #endregion

        

        public EmbarqueClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }



        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);

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

        public static void MarcarEmbarqueEncerrado(int idEmbarque, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                //busca os pallets
                command.CommandText = "SELECT distinct(oic_pallet) FROM order_item_etiqueta_conferencia WHERE id_embarque=" + idEmbarque + " AND oic_nf_emitida=0";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                string sqlPallets = "";
                while (read.Read())
                {
                    sqlPallets += " OR (pal_numero = " + read[0] + " ) ";
                }
                read.Close();


                command.CommandText = "UPDATE order_item_etiqueta_conferencia SET oic_nf_emitida=1 WHERE id_embarque=" + idEmbarque + "; ";
                if (sqlPallets.Length > 0)
                {
                    command.CommandText += "UPDATE pallet SET pal_ocupado=0, pal_fechado=0, pal_conferido=0 WHERE " + sqlPallets.Substring(4) + " ;";
                }
                command.ExecuteNonQuery();

                command.CommandText = "UPDATE embarque SET emb_nf_emitida = 1, emb_nf_autorizada = 1 WHERE id_embarque=" + idEmbarque;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar o encerramento do embarque\r\n" + e.Message, e);
            }

        }

        public static void DeleteEmbarque(int idEmbarque,IWTPostgreNpgsqlCommand command, bool permitirDeletarComNf = false) 
        {
            try
            {


                //Verifica se existe nota emitida
                EmbarqueClass embarque = EmbarqueClass.GetEntidade(idEmbarque, LoginClass.UsuarioLogado.loggedUser, command.Connection);
                if (!permitirDeletarComNf && embarque.NfEmitida)
                {
                    throw new ExcecaoTratada("Não é possível deletar esse embarque pois ele possui notas emitidas. Realize o cancelamento da Nota");
                }


                //remover todas conferencia nf
                command.CommandText =
                    "DELETE FROM  " +
                    "  public.order_item_etiqueta_conferencia_nf   " +
                    "  WHERE  oin_pallet||'-'||oin_pallet_sequencia IN( " +
                    "SELECT DISTINCT  " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet||'-'|| " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet_sequencia " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.id_embarque = " + idEmbarque + " " +
                    "); ";
                command.ExecuteNonQuery();

                //reabrir pallet para conferencia
                command.CommandText =
                    "UPDATE pallet SET pal_ocupado = 0, pal_fechado=0, pal_conferido=0 WHERE pal_numero IN ( " +
                    "SELECT DISTINCT  " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.id_embarque = " + idEmbarque + " " +
                    "); ";

                command.ExecuteNonQuery();

                //Buscar quantidades baixadas
                
                foreach (OrderItemEtiquetaConferenciaClass conferenciaPai in embarque.CollectionOrderItemEtiquetaConferenciaClassEmbarque.Where(a => a.ConferenciaPai))
                {
                    OrderItemEtiquetaConferenciaClass.DesfazerConferencia(conferenciaPai, LoginClass.UsuarioLogado.loggedUser, command);
                }

                command.CommandText = "DELETE FROM embarque WHERE id_embarque=" + idEmbarque;
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
               
                throw new Exception("Erro ao excluir o embarque.\r\n" + e.Message, e);
            }
        }
    }
}
