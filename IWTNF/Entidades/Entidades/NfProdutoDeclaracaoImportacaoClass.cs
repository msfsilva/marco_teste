using System; 
using System.Collections.Generic; 
using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 

using IWTNF.Entidades.Base; 
namespace IWTNF.Entidades.Entidades 
{
    [Serializable()]
    public class NfProdutoDeclaracaoImportacaoClass:NfProdutoDeclaracaoImportacaoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do NfProdutoDeclaracaoImportacaoClass";
protected new const string ErroDelete = "Erro ao excluir o NfProdutoDeclaracaoImportacaoClass  ";
protected new const string ErroSave = "Erro ao salvar o NfProdutoDeclaracaoImportacaoClass.";
protected new const string ErroNumeroDocImportacaoObrigatorio = "O campo Número Doc Importação é obrigatório";
protected new const string ErroNumeroDocImportacaoComprimento = "O campo Número Doc Importação deve ter no máximo 10 caracteres";
protected new const string ErroLocalDesembaracoObrigatorio = "O campo Local Desembaraço é obrigatório";
protected new const string ErroLocalDesembaracoComprimento = "O campo Local Desembaraço deve ter no máximo 60 caracteres";
protected new const string ErroUfDesembaracoObrigatorio = "O campo Uf Desembaraço é obrigatório";
protected new const string ErroUfDesembaracoComprimento = "O campo Uf Desembaraço deve ter no máximo 2 caracteres";
protected new const string ErroCodigoExportadorObrigatorio = "O campo Código Exportador é obrigatório";
protected new const string ErroCodigoExportadorComprimento = "O campo Código Exportador deve ter no máximo 60 caracteres";
protected new const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do NfProdutoDeclaracaoImportacaoClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoDeclaracaoImportacaoClass está sendo utilizada.";
        #endregion

        public bool TipoIntermedioProprio
        {
            get { return TipoIntermedio == 1; }
            set { if (value) TipoIntermedio = 1; }
        }
        public bool TipoIntermedioOrdem
        {
            get { return TipoIntermedio == 2; }
            set { if (value) TipoIntermedio = 2; }
        }
        public bool TipoIntermedioEncomenda
        {
            get { return TipoIntermedio == 3; }
            set { if (value) TipoIntermedio = 3; }
        }

        public String TipoIntermedioToString
        {
            get { return TipoIntermedio == 1 ? "Importação por conta própria" : TipoIntermedio == 2 ? "Importação por conta e ordem" : TipoIntermedio == 3 ? "Importação por encomenda" : ""; }
        }

        public bool ViaTransporteMaritima
        {
            get { return ViaTransporte == 1; }
            set { if (value) ViaTransporte = 1; }
        }

        public bool ViaTransporteFluvial
        {
            get { return ViaTransporte == 2; }
            set { if (value) ViaTransporte = 2; }
        }

        public bool ViaTransporteLacustre
        {
            get { return ViaTransporte == 3; }
            set { if (value) ViaTransporte = 3; }
        }

        public bool ViaTransporteAerea
        {
            get { return ViaTransporte == 4; }
            set { if (value) ViaTransporte = 4; }
        }

        public bool ViaTransportePostal
        {
            get { return ViaTransporte == 5; }
            set { if (value) ViaTransporte = 5; }
        }

        public bool ViaTransporteFerroviaria
        {
            get { return ViaTransporte == 6; }
            set { if (value) ViaTransporte = 6; }
        }

        public bool ViaTransporteRodoviaria
        {
            get { return ViaTransporte == 7; }
            set { if (value) ViaTransporte = 7; }
        }

        public String ViaTransporteToString
        {
            get { return ViaTransporte == 1 ? "Marítima" : ViaTransporte == 2 ? "Fluvial" : ViaTransporte == 3 ? "Lacustre" : ViaTransporte == 4 ? "Aérea" : ViaTransporte == 5 ? "Postal" : ViaTransporte == 6 ? "Ferroviária" : ViaTransporte == 7 ? "Rodoviária" : ""; }
        }


        public NfProdutoDeclaracaoImportacaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public override string ToString()
        {
           throw new NotImplementedException();
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
            if (CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Count == 0)
            {
                throw new Exception("A Declaração de Importação deve ter pelo menos uma Adição.\r\n");
            }
            return true;
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public void LimparId()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
                this.ID = -1;
                if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded)
                {
                    foreach (NfProdutoDeclaracaoImportacaoAdicaoClass item in CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao)
                    {
                        item.LimparId();
                    }
                }
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado;
                DisableLoadCollection = sitAnteriorDisableLoadCollection;
            }
        }



        #region Propriedades Manuais

        public void ExcluirDeclaracaoImportacaoAdicao(NfProdutoDeclaracaoImportacaoAdicaoClass declaracaoImportacaoAdicao)
        {
            try
            {
                if (!this.CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Contains(declaracaoImportacaoAdicao))
                {
                    throw new ExcecaoTratada("A adição " + declaracaoImportacaoAdicao.Numero + " não foi encontrada na declaração de importação");
                }

                this.CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Remove(declaracaoImportacaoAdicao);
                this.adicionarObjetoDeletar(declaracaoImportacaoAdicao);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir a adição.\r\n" + e.Message, e);
            }
        }


        #endregion
    }
}
