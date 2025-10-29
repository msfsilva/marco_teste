using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PedidoRejeitadoClass:PedidoRejeitadoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PedidoRejeitadoClass";
protected new const string ErroDelete = "Erro ao excluir o PedidoRejeitadoClass  ";
protected new const string ErroSave = "Erro ao salvar o PedidoRejeitadoClass.";
protected new const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected new const string ErroNomeArquivoComprimento = "O campo NomeArquivo deve ter no máximo 255 caracteres";
protected new const string ErroMotivoRejeicaoObrigatorio = "O campo MotivoRejeicao é obrigatório";
protected new const string ErroMotivoRejeicaoComprimento = "O campo MotivoRejeicao deve ter no máximo 255 caracteres";
protected new const string ErroModuloImportadorObrigatorio = "O campo ModuloImportador é obrigatório";
protected new const string ErroModuloImportadorComprimento = "O campo ModuloImportador deve ter no máximo 255 caracteres";
protected new const string ErroArquivoObrigatorio = "O campo Arquivo é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do PedidoRejeitadoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoRejeitadoClass está sendo utilizada.";
#endregion

        public PedidoRejeitadoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        

        public override string ToString()
        {
            return this.NomeArquivo;
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
