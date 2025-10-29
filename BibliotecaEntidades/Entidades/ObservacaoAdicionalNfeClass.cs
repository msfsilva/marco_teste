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
     public class ObservacaoAdicionalNfeClass:ObservacaoAdicionalNfeBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ObservacaoAdicionalNfeClass";
protected new const string ErroDelete = "Erro ao excluir o ObservacaoAdicionalNfeClass  ";
protected new const string ErroSave = "Erro ao salvar o ObservacaoAdicionalNfeClass.";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do ObservacaoAdicionalNfeClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ObservacaoAdicionalNfeClass está sendo utilizada.";
#endregion
        public ObservacaoAdicionalNfeClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
               case "BuscaCompleta":
                   whereClause += " AND ( ";
                   whereClause += "    UPPER(observacao_adicional_nfe.oan_cst_icms) LIKE :buscaCompletaUpper ";
                   whereClause += " OR LOWER(observacao_adicional_nfe.oan_cst_icms) LIKE :buscaCompletaLower ";
                   whereClause += " OR UPPER(observacao_adicional_nfe.oan_observacao) LIKE :buscaCompletaUpper ";
                   whereClause += " OR LOWER(observacao_adicional_nfe.oan_observacao) LIKE :buscaCompletaLower ";
                   whereClause += " OR UPPER(observacao_adicional_nfe.oan_observacao_fisco) LIKE :buscaCompletaUpper ";
                   whereClause += " OR LOWER(observacao_adicional_nfe.oan_observacao_fisco) LIKE :buscaCompletaLower ";
                   whereClause += " OR UPPER(CAST (public.observacao_adicional_nfe.oan_cfop AS VARCHAR)) LIKE :buscaCompletaUpper ";
                   whereClause += " OR LOWER(CAST (public.observacao_adicional_nfe.oan_cfop AS VARCHAR)) LIKE :buscaCompletaLower ";
                   whereClause += " OR UPPER(public.ncm.ncm_codigo) LIKE :buscaCompletaUpper ";
                   whereClause += " OR LOWER(public.ncm.ncm_codigo) LIKE :buscaCompletaLower ";
                    
                   whereClause += " ) ";

                   command.CommandText += "   LEFT OUTER JOIN public.ncm ON (public.observacao_adicional_nfe.id_ncm = public.ncm.id_ncm) ";


                   command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                   command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));


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
    }
}
