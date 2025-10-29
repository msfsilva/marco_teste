using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoMaterialClass:OrdemProducaoMaterialBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoMaterialClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoMaterialClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoMaterialClass.";
protected new const string ErroMaterialDescricaoObrigatorio = "O campo MaterialDescricao é obrigatório";
protected new const string ErroMaterialDescricaoComprimento = "O campo MaterialDescricao deve ter no máximo 255 caracteres";
protected new const string ErroMaterialUnidadeMedidaObrigatorio = "O campo MaterialUnidadeMedida é obrigatório";
protected new const string ErroMaterialUnidadeMedidaComprimento = "O campo MaterialUnidadeMedida deve ter no máximo 255 caracteres";
protected new const string ErroMaterialTipoAcabamentoObrigatorio = "O campo MaterialTipoAcabamento é obrigatório";
protected new const string ErroMaterialTipoAcabamentoComprimento = "O campo MaterialTipoAcabamento deve ter no máximo 255 caracteres";
protected new const string ErroMaterialCodigoObrigatorio = "O campo MaterialCodigo é obrigatório";
protected new const string ErroMaterialCodigoComprimento = "O campo MaterialCodigo deve ter no máximo 255 caracteres";
protected new const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected new const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoMaterialClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoMaterialClass está sendo utilizada.";
#endregion

        


        public OrdemProducaoMaterialClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
