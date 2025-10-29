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
     public class CobBoletoClass:CobBoletoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do CobBoletoClass";
protected new const string ErroDelete = "Erro ao excluir o CobBoletoClass  ";
protected new const string ErroSave = "Erro ao salvar o CobBoletoClass.";
protected new const string ErroCollectionCobBoletoHistoricoClassCobBoleto = "Erro ao carregar a coleção de CobBoletoHistoricoClass.";
protected new const string ErroCollectionCobBoletoInstrucoesClassCobBoleto = "Erro ao carregar a coleção de CobBoletoInstrucoesClass.";
protected new const string ErroCollectionCobBoletoRetornoClassCobBoleto = "Erro ao carregar a coleção de CobBoletoRetornoClass.";
protected new const string ErroCollectionContaReceberBoletoClassCobBoleto = "Erro ao carregar a coleção de ContaReceberBoletoClass.";
protected new const string ErroNossoNumeroObrigatorio = "O campo NossoNumero é obrigatório";
protected new const string ErroNossoNumeroComprimento = "O campo NossoNumero deve ter no máximo 100 caracteres";
protected new const string ErroDvNossoNumeroObrigatorio = "O campo DvNossoNumero é obrigatório";
protected new const string ErroDvNossoNumeroComprimento = "O campo DvNossoNumero deve ter no máximo 1 caracteres";
protected new const string ErroAgenciaObrigatorio = "O campo Agencia é obrigatório";
protected new const string ErroAgenciaComprimento = "O campo Agencia deve ter no máximo 100 caracteres";
protected new const string ErroNumeroContaObrigatorio = "O campo NumeroConta é obrigatório";
protected new const string ErroNumeroContaComprimento = "O campo NumeroConta deve ter no máximo 100 caracteres";
protected new const string ErroDvContaObrigatorio = "O campo DvConta é obrigatório";
protected new const string ErroDvContaComprimento = "O campo DvConta deve ter no máximo 1 caracteres";
protected new const string ErroEspecieObrigatorio = "O campo Especie é obrigatório";
protected new const string ErroEspecieComprimento = "O campo Especie deve ter no máximo 2 caracteres";
protected new const string ErroAceiteObrigatorio = "O campo Aceite é obrigatório";
protected new const string ErroAceiteComprimento = "O campo Aceite deve ter no máximo 1 caracteres";
protected new const string ErroSacadoNumeroDocumentoObrigatorio = "O campo SacadoNumeroDocumento é obrigatório";
protected new const string ErroSacadoNumeroDocumentoComprimento = "O campo SacadoNumeroDocumento deve ter no máximo 20 caracteres";
protected new const string ErroSacadoNomeObrigatorio = "O campo SacadoNome é obrigatório";
protected new const string ErroSacadoNomeComprimento = "O campo SacadoNome deve ter no máximo 255 caracteres";
protected new const string ErroSacadoLogradouroObrigatorio = "O campo SacadoLogradouro é obrigatório";
protected new const string ErroSacadoLogradouroComprimento = "O campo SacadoLogradouro deve ter no máximo 40 caracteres";
protected new const string ErroSacadoRuaObrigatorio = "O campo SacadoRua é obrigatório";
protected new const string ErroSacadoRuaComprimento = "O campo SacadoRua deve ter no máximo 255 caracteres";
protected new const string ErroSacadoNumeroEnderecoObrigatorio = "O campo SacadoNumeroEndereco é obrigatório";
protected new const string ErroSacadoNumeroEnderecoComprimento = "O campo SacadoNumeroEndereco deve ter no máximo 20 caracteres";
protected new const string ErroSacadoBairroObrigatorio = "O campo SacadoBairro é obrigatório";
protected new const string ErroSacadoBairroComprimento = "O campo SacadoBairro deve ter no máximo 50 caracteres";
protected new const string ErroSacadoCepObrigatorio = "O campo SacadoCep é obrigatório";
protected new const string ErroSacadoCepComprimento = "O campo SacadoCep deve ter no máximo 8 caracteres";
protected new const string ErroCidadeSacadoObrigatorio = "O campo CidadeSacado é obrigatório";
protected new const string ErroCidadeSacadoComprimento = "O campo CidadeSacado deve ter no máximo 50 caracteres";
protected new const string ErroUfSacadoObrigatorio = "O campo UfSacado é obrigatório";
protected new const string ErroUfSacadoComprimento = "O campo UfSacado deve ter no máximo 2 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do CobBoletoClass.";
protected new const string MensagemUtilizadoCollectionCobBoletoHistoricoClassCobBoleto =  "A entidade CobBoletoClass está sendo utilizada nos seguintes CobBoletoHistoricoClass:";
protected new const string MensagemUtilizadoCollectionCobBoletoInstrucoesClassCobBoleto =  "A entidade CobBoletoClass está sendo utilizada nos seguintes CobBoletoInstrucoesClass:";
protected new const string MensagemUtilizadoCollectionCobBoletoRetornoClassCobBoleto =  "A entidade CobBoletoClass está sendo utilizada nos seguintes CobBoletoRetornoClass:";
protected new const string MensagemUtilizadoCollectionContaReceberBoletoClassCobBoleto =  "A entidade CobBoletoClass está sendo utilizada nos seguintes ContaReceberBoletoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade CobBoletoClass está sendo utilizada.";
#endregion
        public CobBoletoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

       public override string ToString()
       {
           return this.NossoNumero.ToString();
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
    }
}
