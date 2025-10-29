using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics;
using System.Globalization;
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades
{
    [Serializable()]
    public class DeclaracaoImportacaoClass : DeclaracaoImportacaoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do DeclaracaoImportacaoClass";
        protected new const string ErroDelete = "Erro ao excluir o DeclaracaoImportacaoClass  ";
        protected new const string ErroSave = "Erro ao salvar o DeclaracaoImportacaoClass.";
        protected new const string ErroCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao = "Erro ao carregar a coleção de DeclaracaoImportacaoAdicaoClass.";
        protected new const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
        protected new const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 255 caracteres";
        protected new const string ErroLocalDesembaracoAduaneiroObrigatorio = "O campo LocalDesembaracoAduaneiro é obrigatório";
        protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do DeclaracaoImportacaoClass.";
        protected new const string MensagemUtilizadoCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao = "A entidade DeclaracaoImportacaoClass está sendo utilizada nos seguintes DeclaracaoImportacaoAdicaoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade DeclaracaoImportacaoClass está sendo utilizada.";

        #endregion

        

    

        public DeclaracaoImportacaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

    


        protected override void InitClass()
        {
            this.EspecieVolumes = "VOLUMES";
        }

        public string NotaFiscalTela
        {
            get { return this.NfGerada ? this.NfPrincipal.ToString() : ""; }
        }

        public override string ToString()
        {
            return this.Numero.ToString();
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {

            switch (parametro.FieldName)
            {
                case "NotaFiscalTela":
                 
                    return true;
                default:
                    return false;
            }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "SomenteSemNF":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool)parametro.Fieldvalue)
                        {
                            whereClause += " AND dii_nf_gerada = 0 ";
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("O tipo esperado para a busca é boolean");
                    }
                    return true;
                default:
                    return false;
            }
        }

       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            this.CalcularTotal();

            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public DeclaracaoImportacaoAdicaoClass CriarAdicao(short numeroAdicao)
        {
            try
            {
                if (numeroAdicao<1 || numeroAdicao>999)
                {
                    throw new ExcecaoTratada("O número da adição deve ser entre 1 e 999");
                }

                if (this.CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Any(a=>a.Numero == numeroAdicao))
                {
                    throw new ExcecaoTratada("Já existe uma adição cadastrada com esse número (" + numeroAdicao.ToString(CultureInfo.InvariantCulture) + ").");
                }

                DeclaracaoImportacaoAdicaoClass adicao = new DeclaracaoImportacaoAdicaoClass(this.UsuarioAtual, this.SingleConnection)
                                                             {
                                                                 Numero = numeroAdicao,
                                                                 DeclaracaoImportacao = this
                                                             };
                this.CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Add(adicao);

                return adicao;

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao criar a adição na declaração de importação.\r\n" + e.Message, e);
            }
        }

        public void ExcluirAdicao(DeclaracaoImportacaoAdicaoClass adicao)
        {
            try
            {
                if (!this.CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Contains(adicao))
                {
                    throw new ExcecaoTratada("A adição não foi encontrada na declaração de importação.");
                }

                this.adicionarObjetoDeletar(adicao);
                this.CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Remove(adicao);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir a adição na declaração de importação.\r\n" + e.Message, e);
            }
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

        public void CalcularTotal()
        {
            this.ValorTotalDolar = this.ValorMercadoria + this.ValorFrete + this.ValorSeguro;
            this.ValorTotalReais = this.ValorTotalDolar*this.CotacaoDolar;
        }

        public void LimparMateriais()
        {
            try
            {
                foreach (DeclaracaoImportacaoAdicaoClass adicao in CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao)
                {
                    adicao.LimparMateriais();
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Limpar os materiais da declaração de importação.\r\n" + e.Message, e);
            }
        }
    }
}
