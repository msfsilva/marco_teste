using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class RepresentanteClass : RepresentanteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do RepresentanteClass";
        protected new const string ErroDelete = "Erro ao excluir o RepresentanteClass  ";
        protected new const string ErroSave = "Erro ao salvar o RepresentanteClass.";
        protected new const string ErroCollectionOrcamentoItemClassRepresentante = "Erro ao carregar a coleção de OrcamentoItemClass.";
        protected new const string ErroCollectionPedidoItemClassRepresentante = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroCollectionRepresentanteComissaoClassRepresentante = "Erro ao carregar a coleção de RepresentanteComissaoClass.";
        protected new const string ErroCollectionContaPagarClassRepresentante = "Erro ao carregar a coleção de ContaPagarClass.";
        protected new const string ErroRazaoSocialObrigatorio = "O campo RazaoSocial é obrigatório";
        protected new const string ErroCnpjObrigatorio = "O campo Cnpj é obrigatório";
        protected new const string ErroCnpjComprimento = "O campo Cnpj deve ter no máximo 20 caracteres";
        protected new const string ErroInscricaoEstadualObrigatorio = "O campo InscricaoEstadual é obrigatório";
        protected new const string ErroInscricaoEstadualComprimento = "O campo InscricaoEstadual deve ter no máximo 50 caracteres";
        protected new const string ErroEnderecoObrigatorio = "O campo Endereco é obrigatório";
        protected new const string ErroEnderecoComprimento = "O campo Endereco deve ter no máximo 255 caracteres";
        protected new const string ErroEnderecoNumeroObrigatorio = "O campo EnderecoNumero é obrigatório";
        protected new const string ErroEnderecoNumeroComprimento = "O campo EnderecoNumero deve ter no máximo 50 caracteres";
        protected new const string ErroBairroObrigatorio = "O campo Bairro é obrigatório";
        protected new const string ErroBairroComprimento = "O campo Bairro deve ter no máximo 50 caracteres";
        protected new const string ErroCepObrigatorio = "O campo Cep é obrigatório";
        protected new const string ErroCepComprimento = "O campo Cep deve ter no máximo 10 caracteres";
        protected new const string ErroCidadeObrigatorio = "O campo Cidade é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do RepresentanteClass.";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemClassRepresentante = "A entidade RepresentanteClass está sendo utilizada nos seguintes OrcamentoItemClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassRepresentante = "A entidade RepresentanteClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string MensagemUtilizadoCollectionRepresentanteComissaoClassRepresentante = "A entidade RepresentanteClass está sendo utilizada nos seguintes RepresentanteComissaoClass:";
        protected new const string MensagemUtilizadoCollectionContaPagarClassRepresentante = "A entidade RepresentanteClass está sendo utilizada nos seguintes ContaPagarClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade RepresentanteClass está sendo utilizada.";

        #endregion

        

        public RepresentanteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public bool IsentoIE
        {
            get
            {
                if (this.InscricaoEstadual != "ISENTO")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set { }
        }

        public bool PossuiContaBancaria
        {
            get
            {
                if (this.ContaBancaria != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set { }
        }

        public bool PossuiCentroCusto
        {
            get
            {
                if (this.CentroCustoLucro != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set { }
        }

        public bool TipoPF
        {
            get { return this.TipoPessoa == TipoPessoa.PF; }

            set
            {
                if (value)
                {
                    this.TipoPessoa = TipoPessoa.PF;
                }
            }
        }

        public bool TipoPJ
        {
            get { return this.TipoPessoa == TipoPessoa.PJ; }

            set
            {
                if (value)
                {
                    this.TipoPessoa = TipoPessoa.PJ;
                }
            }
        }





        public override string ToString()
        {
            return this.RazaoSocial;
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
            //Se for true é pessoa Física
            if (this.TipoPessoa == TipoPessoa.PF)
            {
                if (!IWTFunctions.IWTFunctions.validaCPF(this.Cnpj))
                {
                    throw new Exception("CPF Inválido.");
                }
            }
            else
            {
                if (!IWTFunctions.IWTFunctions.validaCNPJ(this.Cnpj))
                {
                    throw new Exception("CNPJ Inválido.");
                }
            }

            if (!this.IsentoIE)
            {
                if (!IWTFunctions.IWTFunctions.validaIE(Convert.ToInt32(this.Cidade.Estado.ID), this.InscricaoEstadual))
                {
                    throw new Exception("Inscrição Estadual Inválida.\nVerifique o número e a UF. ");
                }
            }

            if (this.EnvioEmail && this.Email.Trim().Length == 0)
            {
                throw new Exception("Entre com um email para envio de pedidos ou desabilite o envio automático.");
            }

            if (PossuiContaBancaria && this.ContaBancaria == null)
            {
                throw new Exception("Selecione uma conta bancária ou desabilite o campo");
            }

            if (PossuiCentroCusto && this.CentroCustoLucro == null)
            {
                throw new Exception("Selecione um centro de custo ou desabilite o campo");
            }

            return true;
        }

    }
}
