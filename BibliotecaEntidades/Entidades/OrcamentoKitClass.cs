using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrcamentoKitClass:OrcamentoKitBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrcamentoKitClass";
protected new const string ErroDelete = "Erro ao excluir o OrcamentoKitClass  ";
protected new const string ErroSave = "Erro ao salvar o OrcamentoKitClass.";
protected new const string ErroOcObrigatorio = "O campo Oc é obrigatório";
protected new const string ErroOcComprimento = "O campo Oc deve ter no máximo 255 caracteres";
protected new const string ErroTipoKitObrigatorio = "O campo TipoKit é obrigatório";
protected new const string ErroTipoKitComprimento = "O campo TipoKit deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do OrcamentoKitClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoKitClass está sendo utilizada.";
#endregion

        
        

        public OrcamentoKitClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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

       public void LimparID()
       {
           BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
           this.ID = -1;
       }
    }
}
