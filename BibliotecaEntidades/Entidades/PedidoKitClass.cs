using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PedidoKitClass:PedidoKitBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PedidoKitClass";
protected new const string ErroDelete = "Erro ao excluir o PedidoKitClass  ";
protected new const string ErroSave = "Erro ao salvar o PedidoKitClass.";
protected new const string ErroOcObrigatorio = "O campo Oc é obrigatório";
protected new const string ErroOcComprimento = "O campo Oc deve ter no máximo 255 caracteres";
protected new const string ErroTipoKitObrigatorio = "O campo TipoKit é obrigatório";
protected new const string ErroTipoKitComprimento = "O campo TipoKit deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do PedidoKitClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoKitClass está sendo utilizada.";
#endregion


        public PedidoKitClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        


        public override string ToString()
        {
            return Oc;
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

        public void LimparID(PedidoItemClass pedidoItem)
        {
            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;
            this.PedidoItem = pedidoItem;

            this.Oc = pedidoItem.Numero;
            this.Pos = pedidoItem.Posicao;
            this.Cliente = pedidoItem.Cliente;
        }
    }
}
