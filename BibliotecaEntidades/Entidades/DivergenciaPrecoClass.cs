using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class DivergenciaPrecoClass:DivergenciaPrecoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do DivergenciaPrecoClass";
protected new const string ErroDelete = "Erro ao excluir o DivergenciaPrecoClass  ";
protected new const string ErroSave = "Erro ao salvar o DivergenciaPrecoClass.";
protected new const string ErroValidate = "Erro ao validar os dados do DivergenciaPrecoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade DivergenciaPrecoClass está sendo utilizada.";
#endregion

     

        public DivergenciaPrecoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        public override string ToString()
        {
            return this.Mensagem;
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
