using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ModeloFiscalIcmsClass:ModeloFiscalIcmsBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ModeloFiscalIcmsClass";
protected new const string ErroDelete = "Erro ao excluir o ModeloFiscalIcmsClass  ";
protected new const string ErroSave = "Erro ao salvar o ModeloFiscalIcmsClass.";
protected new const string ErroCollectionMaterialFiscalClassModeloFiscalIcms = "Erro ao carregar a coleção de MaterialFiscalClass.";
protected new const string ErroCollectionProdutoFiscalClassModeloFiscalIcms = "Erro ao carregar a coleção de ProdutoFiscalClass.";
protected new const string ErroCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms = "Erro ao carregar a coleção de ModeloFiscalIcmsEstadoClass.";
protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected new const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected new const string ErroCstObrigatorio = "O campo Cst é obrigatório";
protected new const string ErroCstComprimento = "O campo Cst deve ter no máximo 3 caracteres";
protected new const string ErroObsDiferimentoObrigatorio = "O campo ObsDiferimento é obrigatório";
protected new const string ErroObsDiferimentoComprimento = "O campo ObsDiferimento deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do ModeloFiscalIcmsClass.";
protected new const string MensagemUtilizadoCollectionMaterialFiscalClassModeloFiscalIcms =  "A entidade ModeloFiscalIcmsClass está sendo utilizada nos seguintes MaterialFiscalClass:";
protected new const string MensagemUtilizadoCollectionProdutoFiscalClassModeloFiscalIcms =  "A entidade ModeloFiscalIcmsClass está sendo utilizada nos seguintes ProdutoFiscalClass:";
protected new const string MensagemUtilizadoCollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms =  "A entidade ModeloFiscalIcmsClass está sendo utilizada nos seguintes ModeloFiscalIcmsEstadoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ModeloFiscalIcmsClass está sendo utilizada.";
#endregion

        public ModeloFiscalIcmsClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public override string ToString()
        {
            return this.Nome;
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

       protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
       {
           if (this.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms == null || this.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Count == 0)
           {
               this.CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms = new BindingList<ModeloFiscalIcmsEstadoClass>();

               EstadoClass estado = new EstadoClass(LoginClass.UsuarioLogado.loggedUser,this.SingleConnection);
               List<EstadoClass> estados = estado.Search(new List<SearchParameterClass>() { new SearchParameterClass("est_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (EstadoClass)a);
               ModeloFiscalIcmsEstadoClass aliquotaModeloEstado;

               foreach (EstadoClass est in estados)
               {
                   aliquotaModeloEstado = new ModeloFiscalIcmsEstadoClass(this.UsuarioAtual, this.SingleConnection)
                   {
                       ModeloFiscalIcms = this,
                       Estado = est,
                       Aliquota = 0.0
                   };
                   CollectionModeloFiscalIcmsEstadoClassModeloFiscalIcms.Add(aliquotaModeloEstado);
               }

           }
       }

      protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
       {
           if (string.IsNullOrEmpty(this.Cst))
           {
               throw new Exception("Campo CST é obrigatório.");
           }

           if ((this.Cst == "90" || this.Cst == "90b") && this.ReducaoBc)
           {
               if (this.PercentualReducaoBc == null)
               {
                   throw new Exception("Campo Percentual de Redução da BC é obrigatório.");
               }
           }

           if ((this.Cst == "90" || this.Cst == "90b") && this.St== TipoTributacaoST.STComReducaoBCST)
           {
               if (this.PercentualReducaoBcSt == null)
               {
                   throw new Exception("Campo Percentual de Redução da BC ST é obrigatório.");
               }
           }

           if ((this.Cst == "90" || this.Cst == "90b") && (this.St == TipoTributacaoST.SomenteST || this.St == TipoTributacaoST.STComReducaoBCST))
           {
               if (this.PercentualMvaSt == null)
               {
                   throw new Exception("Campo Percentual MVA ST é obrigatório.");
               }
           }
           if ((this.Cst == "90" || this.Cst == "90b") && (this.St == TipoTributacaoST.SomenteST || this.St == TipoTributacaoST.STComReducaoBCST))
           {
               if (this.EstadoSt == null)
               {
                   throw new Exception("Campo UF do ICMS ST devido na operação é obrigatório.");
               }
           }

           return true;
       }

     
    }
}
