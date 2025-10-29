using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PadraoAsClass:PadraoAsBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PadraoAsClass";
protected new const string ErroDelete = "Erro ao excluir o PadraoAsClass  ";
protected new const string ErroSave = "Erro ao salvar o PadraoAsClass.";
protected new const string ErroKitObrigatorio = "O campo Kit é obrigatório";
protected new const string ErroKitComprimento = "O campo Kit deve ter no máximo 255 caracteres";
protected new const string ErroConteudoObrigatorio = "O campo Conteudo é obrigatório";
protected new const string ErroConteudoComprimento = "O campo Conteudo deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do PadraoAsClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PadraoAsClass está sendo utilizada.";
#endregion


        public PadraoAsClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
