using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class OperacaoClass : OperacaoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do OperacaoClass";
        protected new const string ErroDelete = "Erro ao excluir o OperacaoClass  ";
        protected new const string ErroSave = "Erro ao salvar o OperacaoClass.";
        protected new const string ErroCollectionOrcamentoItemClassOperacao = "Erro ao carregar a coleção de OrcamentoItemClass.";
        protected new const string ErroCollectionPedidoItemClassOperacao = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroCollectionPostoTrabalhoClassOperacaoNotaRemessa = "Erro ao carregar a coleção de PostoTrabalhoClass.";
        protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
        protected new const string ErroNaturezaOperacaoObrigatorio = "O campo NaturezaOperacao é obrigatório";
        protected new const string ErroNaturezaOperacaoComprimento = "O campo NaturezaOperacao deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do OperacaoClass.";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemClassOperacao = "A entidade OperacaoClass está sendo utilizada nos seguintes OrcamentoItemClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassOperacao = "A entidade OperacaoClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string MensagemUtilizadoCollectionPostoTrabalhoClassOperacaoNotaRemessa = "A entidade OperacaoClass está sendo utilizada nos seguintes PostoTrabalhoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade OperacaoClass está sendo utilizada.";

        #endregion




        public OperacaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }


        #region PropriedadesRadioButtons

        public bool IcmsIncide
        {
            get
            {
                if (IncideIcms == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.IncideIcms = IncidenciaImposto.Incide;
                }
                else
                {
                    this.IncideIcms = IncidenciaImposto.Suspenso;
                }
            }
        }

        public bool IcmsIsento
        {
            get
            {
                if (IncideIcms == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.IncideIcms = IncidenciaImposto.Suspenso;
                }
                else
                {
                    this.IncideIcms = IncidenciaImposto.Incide;
                }
            }
        }

        public bool IpiIncide
        {
            get
            {
                if (IncideIpi == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.IncideIpi = IncidenciaImposto.Incide;
                }
                else
                {
                    this.IncideIpi = IpiNaoIncide ? IncidenciaImposto.NaoIncide : IncidenciaImposto.Suspenso;
                }
            }
        }

        public bool IpiNaoIncide
        {
            get
            {
                if (IncideIpi == IncidenciaImposto.NaoIncide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.IncideIpi = 0;
                }
                else
                {
                    this.IncideIpi = IpiIncide ? IncidenciaImposto.Incide : IncidenciaImposto.Suspenso;

                }
            }
        }

        public bool IpiIsento
        {
            get
            {
                if (IncideIpi == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.IncideIpi = IncidenciaImposto.Suspenso;
                }
                else
                {
                    this.IncideIpi = IpiIncide ? IncidenciaImposto.Incide : IncidenciaImposto.NaoIncide;
                }
            }
        }

        public bool PisIncide
        {
            get
            {
                if (IncidePis == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set { this.IncidePis = value ? IncidenciaImposto.Incide : IncidenciaImposto.Suspenso; }
        }

        public bool PisIsento
        {
            get
            {
                if (IncidePis == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set { this.IncidePis = value ? IncidenciaImposto.Suspenso : IncidenciaImposto.Incide; }
        }

        public bool CofinsIncide
        {
            get
            {
                if (IncideCofins == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set { this.IncideCofins = value ? IncidenciaImposto.Incide : IncidenciaImposto.Suspenso; }
        }

        public bool CofinsIsento
        {
            get
            {
                if (IncideCofins == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set { this.IncideCofins = value ? IncidenciaImposto.Suspenso : IncidenciaImposto.Incide; }
        }

        public bool IssIncide
        {
            get
            {
                if (IncideIss == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.IncideIss = IncidenciaImposto.Incide;
                }
                else
                {
                    this.IncideIss = IssNaoIncide ? IncidenciaImposto.NaoIncide : IncidenciaImposto.Suspenso;
                }
            }
        }

        public bool IssNaoIncide
        {
            get
            {
                if (IncideIss == IncidenciaImposto.NaoIncide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.IncideIss = IncidenciaImposto.NaoIncide;
                }
                else
                {
                    this.IncideIss = IssIncide ? IncidenciaImposto.Incide : IncidenciaImposto.Suspenso;

                }
            }
        }

        public bool IssIsento
        {
            get
            {
                if (IncideIss == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.IncideIss = IncidenciaImposto.Suspenso;
                }
                else
                {
                    this.IncideIss = IssIncide ? IncidenciaImposto.Incide : IncidenciaImposto.NaoIncide;
                }
            }
        }

        //Devolucoes
        public bool DevIcmsIncide
        {
            get
            {
                if (DevolucaoMaterialIncideIcms == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.DevolucaoMaterialIncideIcms = IncidenciaImposto.Incide;
                }
                else
                {
                    this.DevolucaoMaterialIncideIcms = IncidenciaImposto.Suspenso;
                }
            }
        }

        public bool DevIcmsIsento
        {
            get
            {
                if (DevolucaoMaterialIncideIcms == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.DevolucaoMaterialIncideIcms = IncidenciaImposto.Suspenso;
                }
                else
                {
                    this.DevolucaoMaterialIncideIcms = IncidenciaImposto.Incide;
                }
            }
        }

        public bool DevIpiIncide
        {
            get
            {
                if (DevolucaoMaterialIncideIpi == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.DevolucaoMaterialIncideIpi = IncidenciaImposto.Incide;
                }
                else
                {
                    this.DevolucaoMaterialIncideIpi = DevIpiNaoIncide ? IncidenciaImposto.NaoIncide : IncidenciaImposto.Suspenso;
                }
            }
        }

        public bool DevIpiNaoIncide
        {
            get
            {
                if (DevolucaoMaterialIncideIpi == IncidenciaImposto.NaoIncide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.DevolucaoMaterialIncideIpi = IncidenciaImposto.NaoIncide;
                }
                else
                {
                    this.DevolucaoMaterialIncideIpi = DevIpiIncide ? IncidenciaImposto.Incide : IncidenciaImposto.Suspenso;

                }
            }
        }

        public bool DevIpiIsento
        {
            get
            {
                if (DevolucaoMaterialIncideIpi == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.DevolucaoMaterialIncideIpi = IncidenciaImposto.Suspenso;
                }
                else
                {
                    this.DevolucaoMaterialIncideIpi = DevIpiIncide ? IncidenciaImposto.Incide : IncidenciaImposto.NaoIncide;
                }
            }
        }

        public bool DevPisIncide
        {
            get
            {
                if (DevolucaoMaterialIncidePis == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set { this.DevolucaoMaterialIncidePis = value ? IncidenciaImposto.Incide : IncidenciaImposto.Suspenso; }
        }

        public bool DevPisIsento
        {
            get
            {
                if (DevolucaoMaterialIncidePis == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set { this.DevolucaoMaterialIncidePis = value ? IncidenciaImposto.Suspenso : IncidenciaImposto.Incide; }
        }

        public bool DevCofinsIncide
        {
            get
            {
                if (DevolucaoMaterialIncideCofins == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set { this.DevolucaoMaterialIncideCofins = value ? IncidenciaImposto.Incide : IncidenciaImposto.Suspenso; }
        }

        public bool DevCofinsIsento
        {
            get
            {
                if (DevolucaoMaterialIncideCofins == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set { this.DevolucaoMaterialIncideCofins = value ? IncidenciaImposto.Suspenso : IncidenciaImposto.Incide; }
        }

        public bool DevIssIncide
        {
            get
            {
                if (DevolucaoMaterialIncideIss == IncidenciaImposto.Incide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.DevolucaoMaterialIncideIss = IncidenciaImposto.Incide;
                }
                else
                {
                    this.DevolucaoMaterialIncideIss = DevIssNaoIncide ? IncidenciaImposto.NaoIncide : IncidenciaImposto.Suspenso;
                }
            }
        }

        public bool DevIssNaoIncide
        {
            get
            {
                if (DevolucaoMaterialIncideIss == IncidenciaImposto.NaoIncide)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.DevolucaoMaterialIncideIss = IncidenciaImposto.NaoIncide;
                }
                else
                {
                    this.DevolucaoMaterialIncideIss = DevIssIncide ? IncidenciaImposto.Incide : IncidenciaImposto.Suspenso;

                }
            }
        }

        public bool DevIssIsento
        {
            get
            {
                if (DevolucaoMaterialIncideIss == IncidenciaImposto.Suspenso)
                    return true;
                else
                {
                    return false;
                }
            }
            set
            {
                if (value)
                {
                    this.DevolucaoMaterialIncideIss = IncidenciaImposto.Suspenso;
                }
                else
                {
                    this.DevolucaoMaterialIncideIss = DevIssIncide ? IncidenciaImposto.Incide : IncidenciaImposto.NaoIncide;
                }
            }
        }

        #endregion


        public override string ToString()
        {
            return this.Descricao;
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
            #region Itens Normais

            if (this.Cfop.ToString().Length > 4)
            {
                throw new Exception("Campo CFOP dentro do estado é inválido.");
            }

            if (this.CfopForaEstado.ToString().Length > 4)
            {
                throw new Exception("Campo CFOP fora do estado é inválido.");
            }

            if (this.IncideIcms == IncidenciaImposto.Suspenso && this.IcmsCstSuspenso == null)
            {
                throw new Exception("Selecione o CST do ICMS para a isenção");
            }

            if (this.IncideIpi == IncidenciaImposto.Suspenso && this.IpiCstSuspenso == null)
            {
                throw new Exception("Selecione o CST do IPI para a isenção");
            }

            if (this.IncidePis == IncidenciaImposto.Suspenso && this.PisCstSuspenso == null)
            {
                throw new Exception("Selecione o CST do PIS para a isenção");
            }

            if (this.IncideCofins == IncidenciaImposto.Suspenso && this.CofinsCstSuspenso == null)
            {
                throw new Exception("Selecione o CST do Cofins para a isenção");
            }

            #endregion

            #region Devolução Materiais

            if (this.DevolucaoMaterial)
            {
                if (this.DevolucaoMaterialCfop.ToString().Length > 4)
                {
                    throw new Exception("Campo Devolução de Materiais CFOP dentro do estado é inválido.");
                }

                if (this.DevolucaoMaterialCfopForaEstado.ToString().Length > 4)
                {
                    throw new Exception("Campo Devolução de Materiais CFOP fora do estado é inválido.");
                }

                if (this.DevolucaoMaterialIncideIcms == IncidenciaImposto.Suspenso && this.DevolucaoMaterialIcmsCstSuspenso == null)
                {
                    throw new Exception("Selecione o CST do ICMS para a isenção (Devolução de Materiais)");
                }

                if (this.DevolucaoMaterialIncideIpi == IncidenciaImposto.Suspenso && this.DevolucaoMaterialIpiCstSuspenso == null)
                {
                    throw new Exception("Selecione o CST do IPI para a isenção (Devolução de Materiais)");
                }

                if (this.DevolucaoMaterialIncidePis == IncidenciaImposto.Suspenso && this.DevolucaoMaterialPisCstSuspenso == null)
                {
                    throw new Exception("Selecione o CST do PIS para a isenção (Devolução de Materiais)");
                }

                if (this.DevolucaoMaterialIncideCofins == IncidenciaImposto.Suspenso && this.DevolucaoMaterialCofinsCstSuspenso == null)
                {
                    throw new Exception("Selecione o CST do Cofins para a isenção (Devolução de Materiais)");
                }

                if (DevolucaoMaterialSeparada && string.IsNullOrEmpty(DevolucaoMaterialSeparadaNatuezaOperacao))
                {
                    throw new Exception("Preencha o campo de Natureza de Operação para a Nota de devolução de Materiais");
                }
            }

            return true;

            #endregion
        }


        public void getCSTSuspensaoICMS(out string cstSuspensaoICMS, out int? csoSuspensaoICMS)
        {
            csoSuspensaoICMS = null;
            cstSuspensaoICMS = IcmsCstSuspenso;

            if (cstSuspensaoICMS == "300" || cstSuspensaoICMS == "400")
            {
                csoSuspensaoICMS = Convert.ToInt32(cstSuspensaoICMS);
                cstSuspensaoICMS = "SN";
            }
            
        }
    }
}
