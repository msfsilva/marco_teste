using System; 
using System.Collections.Generic; 
using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
 
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades
{
    [Serializable()]
    public class VendedorClass : VendedorBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do VendedorClass";
        protected new const string ErroDelete = "Erro ao excluir o VendedorClass  ";
        protected new const string ErroSave = "Erro ao salvar o VendedorClass.";
        protected new const string ErroCollectionOrcamentoItemClassVendedor = "Erro ao carregar a coleção de OrcamentoItemClass.";
        protected new const string ErroCollectionPedidoItemClassVendedor = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroCollectionContaPagarClassVendedor = "Erro ao carregar a coleção de ContaPagarClass.";
        protected new const string ErroCollectionClienteClassVendedor = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroCollectionVendedorComissaoClassVendedor = "Erro ao carregar a coleção de VendedorComissaoClass.";
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
        protected new const string ErroValidate = "Erro ao validar os dados do VendedorClass.";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemClassVendedor = "A entidade VendedorClass está sendo utilizada nos seguintes OrcamentoItemClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassVendedor = "A entidade VendedorClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string MensagemUtilizadoCollectionContaPagarClassVendedor = "A entidade VendedorClass está sendo utilizada nos seguintes ContaPagarClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassVendedor = "A entidade VendedorClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string MensagemUtilizadoCollectionVendedorComissaoClassVendedor = "A entidade VendedorClass está sendo utilizada nos seguintes VendedorComissaoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade VendedorClass está sendo utilizada.";

        #endregion

        

        public VendedorClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            ApiEasiFinanceiroNovo.AtualizarVendedor(this, UsuarioAtual, command);
        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            ApiEasiFinanceiroNovo.ExcluirVendedor(this, command);
        }
    }
}
