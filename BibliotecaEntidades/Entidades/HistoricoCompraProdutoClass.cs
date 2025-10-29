using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class HistoricoCompraProdutoClass:HistoricoCompraProdutoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do HistoricoCompraProdutoClass";
protected new const string ErroDelete = "Erro ao excluir o HistoricoCompraProdutoClass  ";
protected new const string ErroSave = "Erro ao salvar o HistoricoCompraProdutoClass.";
protected new const string ErroNumeroNotaEntradaObrigatorio = "O campo NumeroNotaEntrada é obrigatório";
protected new const string ErroNumeroNotaEntradaComprimento = "O campo NumeroNotaEntrada deve ter no máximo 255 caracteres";
protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do HistoricoCompraProdutoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade HistoricoCompraProdutoClass está sendo utilizada.";
#endregion

        

        public HistoricoCompraProdutoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
