using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class PlanoCorteItemClass:PlanoCorteItemBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do PlanoCorteItemClass";
protected new const string ErroDelete = "Erro ao excluir o PlanoCorteItemClass  ";
protected new const string ErroSave = "Erro ao salvar o PlanoCorteItemClass.";
protected new const string ErroCollectionPlanoCorteItemPedidoClassPlanoCorteItem = "Erro ao carregar a coleção de PlanoCorteItemPedidoClass.";
protected new const string ErroCollectionPlanoCorteItemOpClassPlanoCorteItem = "Erro ao carregar a coleção de PlanoCorteItemOpClass.";
protected new const string ErroMaterialCodigoObrigatorio = "O campo MaterialCodigo é obrigatório";
protected new const string ErroMaterialCodigoComprimento = "O campo MaterialCodigo deve ter no máximo 255 caracteres";
protected new const string ErroMaterialFamiliaObrigatorio = "O campo MaterialFamilia é obrigatório";
protected new const string ErroMaterialFamiliaComprimento = "O campo MaterialFamilia deve ter no máximo 255 caracteres";
protected new const string ErroMaterialAgrupadorObrigatorio = "O campo MaterialAgrupador é obrigatório";
protected new const string ErroMaterialAgrupadorComprimento = "O campo MaterialAgrupador deve ter no máximo 255 caracteres";
protected new const string ErroPostoNomeObrigatorio = "O campo PostoNome é obrigatório";
protected new const string ErroPostoNomeComprimento = "O campo PostoNome deve ter no máximo 255 caracteres";
protected new const string ErroPostoDescricaoObrigatorio = "O campo PostoDescricao é obrigatório";
protected new const string ErroPostoDescricaoComprimento = "O campo PostoDescricao deve ter no máximo 255 caracteres";
protected new const string ErroPlanoCorteObrigatorio = "O campo PlanoCorte é obrigatório";
protected new const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected new const string ErroPostoTrabalhoCorteObrigatorio = "O campo PostoTrabalhoCorte é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do PlanoCorteItemClass.";
protected new const string MensagemUtilizadoCollectionPlanoCorteItemPedidoClassPlanoCorteItem =  "A entidade PlanoCorteItemClass está sendo utilizada nos seguintes PlanoCorteItemPedidoClass:";
protected new const string MensagemUtilizadoCollectionPlanoCorteItemOpClassPlanoCorteItem =  "A entidade PlanoCorteItemClass está sendo utilizada nos seguintes PlanoCorteItemOpClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade PlanoCorteItemClass está sendo utilizada.";
#endregion


        public PlanoCorteItemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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
        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }


        public void CancelarItemPC(string justificativa, IWTPostgreNpgsqlCommand command = null)
        {
            try
            {
                

                justificativa = justificativa.Trim();
                if (string.IsNullOrWhiteSpace(justificativa) || justificativa.Length < 10)
                {
                    throw new ExcecaoTratada("A justificativa deve possuir ao menos 10 caracteres.");
                }

                if (this.Cancelado)
                {
                    throw new ExcecaoTratada("O plano de corte já foi cancelado anteriormente.");
                }

                this.Cancelado = true;
                this.CancelamentoData = Configurations.DataIndependenteClass.GetData();
                this.CancelamentoJustificativa = justificativa;
                this.AcsUsuarioCancelamento = UsuarioAtual;

                if (command != null)
                {
                    this.Save(ref command);
                }
                else
                {
                    this.Save();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Cancelar o item do Plano de Corte.\r\n" + e.Message, e);
            }
        }
    }
}
