using System; 
using System.Collections.Generic; 
using System.Diagnostics;
using System.Globalization;
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
 
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class PedidoItemVolumeClass:PedidoItemVolumeBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PedidoItemVolumeClass";
protected new const string ErroDelete = "Erro ao excluir o PedidoItemVolumeClass  ";
protected new const string ErroSave = "Erro ao salvar o PedidoItemVolumeClass.";
protected new const string ErroPedidoItemObrigatorio = "O campo PedidoItem é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do PedidoItemVolumeClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoItemVolumeClass está sendo utilizada.";
#endregion


        public PedidoItemVolumeClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
