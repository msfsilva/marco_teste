using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text;
using System.Text.RegularExpressions;
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 

namespace IWTNFCompleto.BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class MdfeModalRodoviarioClass:MdfeModalRodoviarioBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MdfeModalRodoviarioClass";
protected new const string ErroDelete = "Erro ao excluir o MdfeModalRodoviarioClass  ";
protected new const string ErroSave = "Erro ao salvar o MdfeModalRodoviarioClass.";
protected new const string ErroCollectionMdfeRodoCondutorClassMdfeModalRodoviario = "Erro ao carregar a coleção de MdfeRodoCondutorClass.";
protected new const string ErroCollectionMdfeRodoReboqueClassMdfeModalRodoviario = "Erro ao carregar a coleção de MdfeRodoReboqueClass.";
protected new const string ErroCollectionMdfeRodoValePedagioClassMdfeModalRodoviario = "Erro ao carregar a coleção de MdfeRodoValePedagioClass.";
protected new const string ErroVersaoObrigatorio = "O campo Versao é obrigatório";
protected new const string ErroVersaoComprimento = "O campo Versao deve ter no máximo 10 caracteres";
protected new const string ErroPlacaObrigatorio = "O campo Placa é obrigatório";
protected new const string ErroPlacaComprimento = "O campo Placa deve ter no máximo 7 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroUfLiceciamentoObrigatorio = "O campo UfLiceciamento é obrigatório";
protected new const string ErroUfLiceciamentoComprimento = "O campo UfLiceciamento deve ter no máximo 2 caracteres";
protected new const string ErroMdfeObrigatorio = "O campo Mdfe é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do MdfeModalRodoviarioClass.";
protected new const string MensagemUtilizadoCollectionMdfeRodoCondutorClassMdfeModalRodoviario =  "A entidade MdfeModalRodoviarioClass está sendo utilizada nos seguintes MdfeRodoCondutorClass:";
protected new const string MensagemUtilizadoCollectionMdfeRodoReboqueClassMdfeModalRodoviario =  "A entidade MdfeModalRodoviarioClass está sendo utilizada nos seguintes MdfeRodoReboqueClass:";
protected new const string MensagemUtilizadoCollectionMdfeRodoValePedagioClassMdfeModalRodoviario =  "A entidade MdfeModalRodoviarioClass está sendo utilizada nos seguintes MdfeRodoValePedagioClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeModalRodoviarioClass está sendo utilizada.";
#endregion
        public MdfeModalRodoviarioClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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
         protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
         {             
             /*
             if (!Regex.Match(this.Versao, MDFeConstantes.ER1).Success) { throw new ExcecaoTratada("Versão do layout do modal rodoviário inválida."); }
             if (!Regex.Match(this.Rntrc.ToString(), MDFeConstantes.ER38).Success) { throw new ExcecaoTratada("RNTRC do transportador inválida."); }
             //if (!Regex.Match(this.Ciot, MDFeConstantes.ER52).Success) { throw new ExcecaoTratada(""); }
             if (!Regex.Match(this.CodigoInternoVeiculo, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Código interno do veículo."); }
             if (!Regex.Match(this.Placa, MDFeConstantes.ER37).Success) { throw new ExcecaoTratada("Placa do veículo inválida."); }
             if (!Regex.Match(this.Renavam, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Renavam do veículo inválido."); }
             //if (!Regex.Match(this.Tara.ToString(), MDFeConstantes.ER53).Success) { throw new ExcecaoTratada(""); }
             //if (!Regex.Match(this.CapacidadeKg.ToString(), MDFeConstantes.ER).Success) { throw new ExcecaoTratada(""); }
             if (!Regex.Match(this.CapacidadeM3.ToString(), MDFeConstantes.ER30).Success) { throw new ExcecaoTratada("Capacidade em M3 do veículo inválida."); }
             if (!Regex.Match(this.CpfProprietario, MDFeConstantes.ER9).Success) { throw new ExcecaoTratada("CPF do proprietário do veículo inválido."); }
             if (!Regex.Match(this.CnpjProprietario, MDFeConstantes.ER8).Success) { throw new ExcecaoTratada("CNPJ do proprietário do veículo inválido."); }
             if (!Regex.Match(this.ProprietarioRntrc.ToString(), MDFeConstantes.ER38).Success) { throw new ExcecaoTratada("RNTRC do proprietário do veículo inválido."); }
             if (!Regex.Match(this.NomeRazaoProprietario, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Razão/Nome do proprietário do veículo inválido."); }
             if (!Regex.Match(this.IeProprietario, MDFeConstantes.ER27).Success) { throw new ExcecaoTratada("Inscrição estadual do proprietário do veículo inválido."); }
             */
             return true;
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
    }
}
