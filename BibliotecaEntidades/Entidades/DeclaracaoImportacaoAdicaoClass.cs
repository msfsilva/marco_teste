using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics;
using System.Globalization;
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
    public class DeclaracaoImportacaoAdicaoClass : DeclaracaoImportacaoAdicaoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do DeclaracaoImportacaoAdicaoClass";
        protected new const string ErroDelete = "Erro ao excluir o DeclaracaoImportacaoAdicaoClass  ";
        protected new const string ErroSave = "Erro ao salvar o DeclaracaoImportacaoAdicaoClass.";
        protected new const string ErroCollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao = "Erro ao carregar a coleção de DeclaracaoImportacaoAdicaoItemClass.";
        protected new const string ErroCodigoFabricanteObrigatorio = "O campo CodigoFabricante é obrigatório";
        protected new const string ErroCodigoFabricanteComprimento = "O campo CodigoFabricante deve ter no máximo 60 caracteres";
        protected new const string ErroDeclaracaoImportacaoObrigatorio = "O campo DeclaracaoImportacao é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do DeclaracaoImportacaoAdicaoClass.";
        protected new const string MensagemUtilizadoCollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao = "A entidade DeclaracaoImportacaoAdicaoClass está sendo utilizada nos seguintes DeclaracaoImportacaoAdicaoItemClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade DeclaracaoImportacaoAdicaoClass está sendo utilizada.";

        #endregion

        



        public DeclaracaoImportacaoAdicaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

 

        public override string ToString()
        {
            return this.Numero.ToString();
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

            if (this.DeclaracaoImportacao.Fornecedor!=null)
            {
                this.CodigoFabricante = this.DeclaracaoImportacao.Fornecedor.ID.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                this.CodigoFabricante = "XXXX";
            }

            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public void setAlterado(bool alterado)
        {
            this.RemoveForcesDirtyAndClean();
            if (alterado)
            {
                ForceDirty();
            }
            else
            {
                ForceClean();
            }
            
        }

        public void IncluirItem(DeclaracaoImportacaoAdicaoItemClass item)
        {
            try
            {
                this.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao.Add(item);
                item.DeclaracaoImportacaoAdicao = this;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao incluir o item na adição\r\n" + e.Message, e);
            }
        }

        public void ExcluirItem(DeclaracaoImportacaoAdicaoItemClass item)
        {
            try
            {
                if (!this.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao.Contains(item))
                {
                    throw new ExcecaoTratada("Item não encontrado na adição.");
                }

                this.adicionarObjetoDeletar(item);
                this.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao.Remove(item);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir o item da adição.\r\n" + e.Message, e);
            }
        }

        public void LimparMateriais()
        {
            try
            {
                while (this.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao.Count > 0)
                {
                    DeclaracaoImportacaoAdicaoItemClass item = this.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao.First();
                    this.adicionarObjetoDeletar(item);
                    this.CollectionDeclaracaoImportacaoAdicaoItemClassDeclaracaoImportacaoAdicao.Remove(item);
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Limpar os materiais da adição da declaração de importação.\r\n" + e.Message, e);
            }
        }
    }
}
