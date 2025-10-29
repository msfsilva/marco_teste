using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;
using ProjectConstants;

namespace BibliotecaEntidades.Entidades
{
    public class NcmClass : NcmBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NcmClass";
        protected new const string ErroDelete = "Erro ao excluir o NcmClass  ";
        protected new const string ErroSave = "Erro ao salvar o NcmClass.";
        protected new const string ErroCollectionMaterialFiscalClassNcm = "Erro ao carregar a coleção de MaterialFiscalClass.";
        protected new const string ErroCollectionProdutoFiscalClassNcm = "Erro ao carregar a coleção de ProdutoFiscalClass.";
        protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
        protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 8 caracteres";
        protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
        protected new const string ErroIpiCodigoEnquadramentoObrigatorio = "O campo IpiCodigoEnquadramento é obrigatório";
        protected new const string ErroIpiCodigoEnquadramentoComprimento = "O campo IpiCodigoEnquadramento deve ter no máximo 3 caracteres";
        protected new const string ErroIpiCstObrigatorio = "O campo IpiCst é obrigatório";
        protected new const string ErroIpiCstComprimento = "O campo IpiCst deve ter no máximo 2 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do NcmClass.";
        protected new const string MensagemUtilizadoCollectionMaterialFiscalClassNcm = "A entidade NcmClass está sendo utilizada nos seguintes MaterialFiscalClass:";
        protected new const string MensagemUtilizadoCollectionProdutoFiscalClassNcm = "A entidade NcmClass está sendo utilizada nos seguintes ProdutoFiscalClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NcmClass está sendo utilizada.";

        #endregion


        public NcmClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            return this.Codigo;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "CodigoExato":
                    whereClause += " AND (ncm_codigo LIKE :CodigoExato) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("CodigoExato", NpgsqlDbType.Varchar, parametro.Fieldvalue));
                    return true;
                default:
                    return false;
            }
        }


        protected override void CalcularCamposAntesValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {
            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                if (ID == -1)
                {
                    IpiCodigoEnquadramento = "999";
                    IpiCst = "00";
                    IpiAliquota = 0;
                    IpiModalidadeTributacao = 0;
                    IiAliquota = 0;
                }
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {



            if (string.IsNullOrEmpty(this.IpiCodigoEnquadramento) && (IpiCst == "00" || IpiCst == "49" || IpiCst == "50" || IpiCst == "99"))
            {
                throw new Exception("Campo Código Enquadramento do IPI é obrigatório.");
            }


            return true;
        }

        public void AdicionarAliquotaFCP(AliquotaFundoCombatePobrezaClass aliquota)
        {
            if (CollectionAliquotaFundoCombatePobrezaClassNcm.Any(a => a.Estado == aliquota.Estado))
            {
                throw new ExcecaoTratada("Esse NCM já possui uma aliquota cadastrada para o estado " + aliquota.Estado);
            }
            CollectionAliquotaFundoCombatePobrezaClassNcm.Add(aliquota);

        }

        public void RemoverAliquotaFCP(AliquotaFundoCombatePobrezaClass aliquota)
        {
            AliquotaFundoCombatePobrezaClass toRemove = CollectionAliquotaFundoCombatePobrezaClassNcm.FirstOrDefault(a => a == aliquota);
            if (toRemove == null)
            {
                throw new ExcecaoTratada("Não foi encontrada a alíquota no NCM");
            }

            adicionarObjetoDeletar(toRemove);
            CollectionAliquotaFundoCombatePobrezaClassNcm.Remove(aliquota);

        }

        public void AdicionarBeneficioFiscal(NcmBeneficioFiscalClass beneficio)
        {
            if (CollectionNcmBeneficioFiscalClassNcm.Any(a => a.Estado == beneficio.Estado && a.Cfop == beneficio.Cfop))
            {
                throw new ExcecaoTratada("Esse NCM já possui um beneficio fiscal cadastrado para o estado " + beneficio.Estado + " e com o CFOP "+beneficio.Cfop);
            }
            CollectionNcmBeneficioFiscalClassNcm.Add(beneficio);

        }

        public void RemoverBeneficioFiscal(NcmBeneficioFiscalClass beneficio)
        {
            NcmBeneficioFiscalClass toRemove = CollectionNcmBeneficioFiscalClassNcm.FirstOrDefault(a => a == beneficio);
            if (toRemove == null)
            {
                throw new ExcecaoTratada("Não foi encontrado o benefício no NCM");
            }

            adicionarObjetoDeletar(toRemove);
            CollectionNcmBeneficioFiscalClassNcm.Remove(beneficio);

        }

        public static NcmClass GetNcmPorCodigo(string codigo, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            NcmClass toRet = (NcmClass) new NcmClass(usuario, conn).Search(
                new List<SearchParameterClass>()
                {
                    new SearchParameterClass("CodigoExato", codigo)
                }).FirstOrDefault();

            return toRet;
        }
    }
}
