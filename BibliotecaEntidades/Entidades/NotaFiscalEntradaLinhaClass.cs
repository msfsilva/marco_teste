using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class NotaFiscalEntradaLinhaClass:NotaFiscalEntradaLinhaBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NotaFiscalEntradaLinhaClass";
protected new const string ErroDelete = "Erro ao excluir o NotaFiscalEntradaLinhaClass  ";
protected new const string ErroSave = "Erro ao salvar o NotaFiscalEntradaLinhaClass.";
protected new const string ErroCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
protected new const string ErroCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
protected new const string ErroCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected new const string ErroNcmObrigatorio = "O campo Ncm é obrigatório";
protected new const string ErroNcmComprimento = "O campo Ncm deve ter no máximo 255 caracteres";
protected new const string ErroUnidadeObrigatorio = "O campo Unidade é obrigatório";
protected new const string ErroUnidadeComprimento = "O campo Unidade deve ter no máximo 255 caracteres";
protected new const string ErroNotaFiscalEntradaObrigatorio = "O campo NotaFiscalEntrada é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NotaFiscalEntradaLinhaClass.";
protected new const string MensagemUtilizadoCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha =  "A entidade NotaFiscalEntradaLinhaClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
protected new const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha =  "A entidade NotaFiscalEntradaLinhaClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
protected new const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha =  "A entidade NotaFiscalEntradaLinhaClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NotaFiscalEntradaLinhaClass está sendo utilizada.";
#endregion


        public NotaFiscalEntradaLinhaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
