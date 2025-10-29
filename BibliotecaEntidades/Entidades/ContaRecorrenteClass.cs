using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ContaRecorrenteClass:ContaRecorrenteBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ContaRecorrenteClass";
protected new const string ErroDelete = "Erro ao excluir o ContaRecorrenteClass  ";
protected new const string ErroSave = "Erro ao salvar o ContaRecorrenteClass.";
protected new const string ErroCollectionContaReceberClassContaRecorrente = "Erro ao carregar a coleção de ContaReceberClass.";
protected new const string ErroCollectionContaPagarClassContaRecorrente = "Erro ao carregar a coleção de ContaPagarClass.";
protected new const string ErroHistoricoObrigatorio = "O campo Historico é obrigatório";
protected new const string ErroHistoricoComprimento = "O campo Historico deve ter no máximo 255 caracteres";
protected new const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected new const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do ContaRecorrenteClass.";
protected new const string MensagemUtilizadoCollectionContaReceberClassContaRecorrente =  "A entidade ContaRecorrenteClass está sendo utilizada nos seguintes ContaReceberClass:";
protected new const string MensagemUtilizadoCollectionContaPagarClassContaRecorrente =  "A entidade ContaRecorrenteClass está sendo utilizada nos seguintes ContaPagarClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ContaRecorrenteClass está sendo utilizada.";
#endregion

        



        public ContaRecorrenteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        public override string ToString()
        {
            return Historico;
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
