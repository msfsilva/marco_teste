using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class CodigoBarraClass:CodigoBarraBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do CodigoBarraClass";
protected new const string ErroDelete = "Erro ao excluir o CodigoBarraClass  ";
protected new const string ErroSave = "Erro ao salvar o CodigoBarraClass.";
protected new const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
protected new const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
protected new const string ErroDimensaoObrigatorio = "O campo Dimensao é obrigatório";
protected new const string ErroDimensaoComprimento = "O campo Dimensao deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do CodigoBarraClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade CodigoBarraClass está sendo utilizada.";
#endregion


        public CodigoBarraClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
    }
}
