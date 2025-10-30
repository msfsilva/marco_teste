using System; 
using System.Collections.Generic; 
using System.Diagnostics;
using System.Globalization;
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
     public class NfeCompletoLoteClass:NfeCompletoLoteBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfeCompletoLoteClass";
protected new const string ErroDelete = "Erro ao excluir o NfeCompletoLoteClass  ";
protected new const string ErroSave = "Erro ao salvar o NfeCompletoLoteClass.";
protected new const string ErroCollectionNfeCompletoNotaClassNfeCompletoLote = "Erro ao carregar a coleção de NfeCompletoNotaClass.";
protected new const string ErroCnpjTransmissorObrigatorio = "O campo CnpjTransmissor é obrigatório";
protected new const string ErroCnpjTransmissorComprimento = "O campo CnpjTransmissor deve ter no máximo 30 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do NfeCompletoLoteClass.";
protected new const string MensagemUtilizadoCollectionNfeCompletoNotaClassNfeCompletoLote =  "A entidade NfeCompletoLoteClass está sendo utilizada nos seguintes NfeCompletoNotaClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletoLoteClass está sendo utilizada.";
#endregion

  

        public NfeCompletoLoteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool GerarDanfeOffline { get; set; }

        public bool Retry { get; set; }


        protected override void InitClass()
        {
            ControleRevisaoHabilitado = false;
        }

        
       public override string ToString()
        {
            return this.NumeroLote.ToString(CultureInfo.InvariantCulture);
        }
       public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
           switch (parametro.FieldName)
            {
                case "CnpjTransmissorExato":
                    if (parametro.Fieldvalue is string)
                    {
                        whereClause += " AND ( " +
                                       " ncl_cnpj_transmissor = :CnpjTransmissorExato " +
                                       ") ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("CnpjTransmissorExato", NpgsqlDbType.Varchar,parametro.Fieldvalue));
                    }
                    else
                    {
                        throw new Exception("Parâmetro Inválido, esperado string");
                    }
                    return true;

                case "ExisteRecibo":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool) parametro.Fieldvalue)
                        {
                            whereClause += " AND ( " +
                                           " ncl_recibo IS NOT NULL " +
                                           ") ";
                        }
                        
                    }
                    else
                    {
                        throw new Exception("Parâmetro Inválido, esperado string");
                    }
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
