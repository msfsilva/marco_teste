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
    public class DeclaracaoImportacaoAdicaoItemClass : DeclaracaoImportacaoAdicaoItemBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do DeclaracaoImportacaoAdicaoItemClass";
        protected new const string ErroDelete = "Erro ao excluir o DeclaracaoImportacaoAdicaoItemClass  ";
        protected new const string ErroSave = "Erro ao salvar o DeclaracaoImportacaoAdicaoItemClass.";
        protected new const string ErroDeclaracaoImportacaoAdicaoObrigatorio = "O campo DeclaracaoImportacaoAdicao é obrigatório";
        protected new const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do DeclaracaoImportacaoAdicaoItemClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade DeclaracaoImportacaoAdicaoItemClass está sendo utilizada.";

        #endregion

        

    

        public DeclaracaoImportacaoAdicaoItemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }



        public override string ToString()
        {
            return this.Material.ToString();
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
            if (this.NumeroSequencialNaAdicao <= 0)
            {
                throw new ExcecaoTratada("O número sequencial na adição deve ser maior do que zero.");
            }

            this.ValorTotalDolares = this.ValorUnitarioDolares*this.Quantidade;
            this.ValorUnitarioReais = this.ValorUnitarioDolares*this.DeclaracaoImportacaoAdicao.DeclaracaoImportacao.CotacaoDolar;
            this.ValorTotalReais = this.ValorTotalDolares * this.DeclaracaoImportacaoAdicao.DeclaracaoImportacao.CotacaoDolar;

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


    }
}
