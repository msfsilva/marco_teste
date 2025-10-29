using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PlanoCorteItemOpClass:PlanoCorteItemOpBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PlanoCorteItemOpClass";
protected new const string ErroDelete = "Erro ao excluir o PlanoCorteItemOpClass  ";
protected new const string ErroSave = "Erro ao salvar o PlanoCorteItemOpClass.";
protected new const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
protected new const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
protected new const string ErroPlanoCorteItemObrigatorio = "O campo PlanoCorteItem é obrigatório";
protected new const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do PlanoCorteItemOpClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PlanoCorteItemOpClass está sendo utilizada.";
#endregion


        public PlanoCorteItemOpClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
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
        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public void SetOP(long idOrdemProducao)
        {
            this.OrdemProducao = OrdemProducaoBaseClass.GetEntidade(idOrdemProducao, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
            this.CodigoItem = OrdemProducao.ProdutoCodigo;

        }
    }
}
