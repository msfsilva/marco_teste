using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ConciliacaoBancariaClass:ConciliacaoBancariaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ConciliacaoBancariaClass";
protected new const string ErroDelete = "Erro ao excluir o ConciliacaoBancariaClass  ";
protected new const string ErroSave = "Erro ao salvar o ConciliacaoBancariaClass.";
protected new const string ErroCollectionTransferenciaBancariaClassConciliacaoBancaria = "Erro ao carregar a coleção de TransferenciaBancariaClass.";
protected new const string ErroCollectionContaReceberClassConciliacaoBancaria = "Erro ao carregar a coleção de ContaReceberClass.";
protected new const string ErroCollectionContaPagarClassConciliacaoBancaria = "Erro ao carregar a coleção de ContaPagarClass.";
protected new const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do ConciliacaoBancariaClass.";
protected new const string MensagemUtilizadoCollectionTransferenciaBancariaClassConciliacaoBancaria =  "A entidade ConciliacaoBancariaClass está sendo utilizada nos seguintes TransferenciaBancariaClass:";
protected new const string MensagemUtilizadoCollectionContaReceberClassConciliacaoBancaria =  "A entidade ConciliacaoBancariaClass está sendo utilizada nos seguintes ContaReceberClass:";
protected new const string MensagemUtilizadoCollectionContaPagarClassConciliacaoBancaria =  "A entidade ConciliacaoBancariaClass está sendo utilizada nos seguintes ContaPagarClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ConciliacaoBancariaClass está sendo utilizada.";
#endregion


        public ConciliacaoBancariaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
