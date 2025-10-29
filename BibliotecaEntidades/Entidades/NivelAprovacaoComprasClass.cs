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
     public class NivelAprovacaoComprasClass:NivelAprovacaoComprasBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NivelAprovacaoComprasClass";
protected new const string ErroDelete = "Erro ao excluir o NivelAprovacaoComprasClass  ";
protected new const string ErroSave = "Erro ao salvar o NivelAprovacaoComprasClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NivelAprovacaoComprasClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NivelAprovacaoComprasClass está sendo utilizada.";
#endregion
        public NivelAprovacaoComprasClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
           throw new NotImplementedException();
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
         protected override bool ValidateDataCustom(ref  IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
        protected override void InternalSaveCustom(ref  IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public static List<NivelAprovacaoComprasClass> GetAllAprovacaoComprasClasses(AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {

                return new NivelAprovacaoComprasClass(usuario,conn).Search( new List<SearchParameterClass>()
                {
                    new SearchParameterClass("LimiteMaxAprovacao",null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc,TipoOrdenacao.Automatica)

                }).ConvertAll(a=>(NivelAprovacaoComprasClass)a);

         
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao buscar a lista de níveis de aprovação de compras \r\n" + e.Message, e);
            }
        }
    }
}
