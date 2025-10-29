using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
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
     public class PaisClass:PaisBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PaisClass";
protected new const string ErroDelete = "Erro ao excluir o PaisClass  ";
protected new const string ErroSave = "Erro ao salvar o PaisClass.";
protected new const string ErroCollectionCidadeClassPais = "Erro ao carregar a coleção de CidadeClass.";
protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected new const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do PaisClass.";
protected new const string MensagemUtilizadoCollectionCidadeClassPais =  "A entidade PaisClass está sendo utilizada nos seguintes CidadeClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PaisClass está sendo utilizada.";
#endregion
        public PaisClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }


       public override string ToString()
       {
           return this.Nome.ToString();
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
