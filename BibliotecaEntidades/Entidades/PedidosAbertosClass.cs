using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PedidosAbertosClass:PedidosAbertosBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PedidosAbertosClass";
protected new const string ErroDelete = "Erro ao excluir o PedidosAbertosClass  ";
protected new const string ErroSave = "Erro ao salvar o PedidosAbertosClass.";
protected new const string ErroOcObrigatorio = "O campo Oc é obrigatório";
protected new const string ErroOcComprimento = "O campo Oc deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do PedidosAbertosClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PedidosAbertosClass está sendo utilizada.";
#endregion

        

        public PedidosAbertosClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            return this.Oc;

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
    }
}
