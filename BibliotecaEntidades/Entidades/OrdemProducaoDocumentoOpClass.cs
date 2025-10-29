using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrdemProducaoDocumentoOpClass:OrdemProducaoDocumentoOpBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoDocumentoOpClass";
protected new const string ErroDelete = "Erro ao excluir o OrdemProducaoDocumentoOpClass  ";
protected new const string ErroSave = "Erro ao salvar o OrdemProducaoDocumentoOpClass.";
protected new const string ErroOrdemProducaoDocumentoObrigatorio = "O campo OrdemProducaoDocumento é obrigatório";
protected new const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrdemProducaoDocumentoOpClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoDocumentoOpClass está sendo utilizada.";
#endregion

        

        public OrdemProducaoDocumentoOpClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public string OpStatus
        {
            get { return this.OrdemProducao.SituacaoTraduzida; }
        }

        public DateTime OpData
        {
            get { return this.OrdemProducao.Data; }
        }

        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
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
