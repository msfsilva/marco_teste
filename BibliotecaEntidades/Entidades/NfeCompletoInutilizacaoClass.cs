using System; 
using System.Collections.Generic; 
using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using IWTNFCompleto.BibliotecaEntidades.Base; 
namespace IWTNFCompleto.BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class NfeCompletoInutilizacaoClass:NfeCompletoInutilizacaoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfeCompletoInutilizacaoClass";
protected new const string ErroDelete = "Erro ao excluir o NfeCompletoInutilizacaoClass  ";
protected new const string ErroSave = "Erro ao salvar o NfeCompletoInutilizacaoClass.";
protected new const string ErroCnpjObrigatorio = "O campo Cnpj é obrigatório";
protected new const string ErroCnpjComprimento = "O campo Cnpj deve ter no máximo 50 caracteres";
protected new const string ErroUfObrigatorio = "O campo Uf é obrigatório";
protected new const string ErroUfComprimento = "O campo Uf deve ter no máximo 50 caracteres";
protected new const string ErroJustificativaObrigatorio = "O campo Justificativa é obrigatório";
protected new const string ErroJustificativaComprimento = "O campo Justificativa deve ter no máximo 255 caracteres";
protected new const string ErroUsuarioObrigatorio = "O campo Usuario é obrigatório";
protected new const string ErroUsuarioComprimento = "O campo Usuario deve ter no máximo 255 caracteres";
protected new const string ErroXmlObrigatorio = "O campo Xml é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfeCompletoInutilizacaoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletoInutilizacaoClass está sendo utilizada.";
#endregion



        public NfeCompletoInutilizacaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        protected override void InitClass()
        {
            ControleRevisaoHabilitado = false;
        }


       public override string ToString()
       {
           return this.Inicio + " a " + this.Fim;
       }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool IsModelo55
        {
            get { return (this.Modelo == "55"); }
            set
            {
                if (value)
                {
                    this.Modelo = "55";
                }
            }
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool IsModelo65
        {
            get { return (this.Modelo == "65"); }
            set
            {
                if (value)
                {
                    this.Modelo = "65";
                }
            }
        }

       public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
           switch (parametro.FieldName)
            {
                case "Homologacao":
                    whereClause += parametro.Fieldvalue as bool? == true
                                       ?
                                       " AND ( " +
                                         " nci_homologacao = 1 " +
                                         ") "

                                       :
                                       " AND ( " +
                                         " nci_homologacao = 0 " +
                                         ") ";
                    return true;
                    

                case "Producao":
                    whereClause += parametro.Fieldvalue as bool? == true
                                       ?
                                       " AND ( " +
                                         " nci_homologacao = 0 " +
                                         ") "

                                       :
                                       " AND ( " +
                                         " nci_homologacao = 1 " +
                                         ") ";
                    return true;
                    
                default:
                    return false;
            }
        }
         protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
         {

             if (String.IsNullOrEmpty(Justificativa) || Justificativa.Trim().Length < 15)
             {
                 throw new ExcecaoTratada("Preencha a justificativa com ao menos 15 caracteres");
             }


             return true;
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
    }
}
