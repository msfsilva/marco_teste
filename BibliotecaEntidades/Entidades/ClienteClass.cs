using System;
using System.Net.Mail;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;


namespace BibliotecaEntidades.Entidades
{
    public class ClienteClass : ClienteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ClienteClass";
        protected new const string ErroDelete = "Erro ao excluir o ClienteClass  ";
        protected new const string ErroSave = "Erro ao salvar o ClienteClass.";
        protected new const string ErroCollectionCliEassaIdentificaClienteClassCliente = "Erro ao carregar a coleção de CliEassaIdentificaClienteClass.";
        protected new const string ErroCollectionContaRecorrenteClassCliente = "Erro ao carregar a coleção de ContaRecorrenteClass.";
        protected new const string ErroCollectionLoteClassCliente = "Erro ao carregar a coleção de LoteClass.";
        protected new const string ErroCollectionOrcamentoKitClassCliente = "Erro ao carregar a coleção de OrcamentoKitClass.";
        protected new const string ErroCollectionOrcamentoItemClassCliente = "Erro ao carregar a coleção de OrcamentoItemClass.";
        protected new const string ErroCollectionOrcamentoVariavelClassCliente = "Erro ao carregar a coleção de OrcamentoVariavelClass.";
        protected new const string ErroCollectionOrcamentoItemVariavelClassCliente = "Erro ao carregar a coleção de OrcamentoItemVariavelClass.";
        protected new const string ErroCollectionOrderItemEtiquetaClassClienteAccess = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
        protected new const string ErroCollectionOrderItemEtiquetaClassCliente = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
        protected new const string ErroCollectionPedidoKitClassCliente = "Erro ao carregar a coleção de PedidoKitClass.";
        protected new const string ErroCollectionPedidoItemClassCliente = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroCollectionPedidoVariavelClassCliente = "Erro ao carregar a coleção de PedidoVariavelClass.";
        protected new const string ErroCollectionPedidoItemVariavelClassCliente = "Erro ao carregar a coleção de PedidoItemVariavelClass.";
        protected new const string ErroCollectionOrcamentoConfiguradoClassClienteAccess = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
        protected new const string ErroCollectionOrcamentoConfiguradoClassCliente = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
        protected new const string ErroCollectionContaReceberClassCliente = "Erro ao carregar a coleção de ContaReceberClass.";
        protected new const string ErroCollectionProdutoClassCliente = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
        protected new const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do ClienteClass.";
        protected new const string MensagemUtilizadoCollectionCliEassaIdentificaClienteClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes CliEassaIdentificaClienteClass:";
        protected new const string MensagemUtilizadoCollectionContaRecorrenteClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
        protected new const string MensagemUtilizadoCollectionLoteClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes LoteClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoKitClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoKitClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoItemClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoVariavelClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoVariavelClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemVariavelClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoItemVariavelClass:";
        protected new const string MensagemUtilizadoCollectionOrderItemEtiquetaClassClienteAccess = "A entidade ClienteClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
        protected new const string MensagemUtilizadoCollectionOrderItemEtiquetaClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
        protected new const string MensagemUtilizadoCollectionPedidoKitClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes PedidoKitClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string MensagemUtilizadoCollectionPedidoVariavelClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes PedidoVariavelClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemVariavelClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes PedidoItemVariavelClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassClienteAccess = "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
        protected new const string MensagemUtilizadoCollectionContaReceberClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes ContaReceberClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassCliente = "A entidade ClienteClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ClienteClass está sendo utilizada.";

        #endregion

        


        public ClienteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public override string Cnpj
        {
            get { return base.Cnpj; }
            set
            {
                if (value == "  .   .   /    -")
                {
                    value = "";
                }

                if (!this.loading && !string.IsNullOrWhiteSpace(value) && base.Cnpj != value)
                {
                    validaExistenciaCpfCnpj(value);
                }

                base.Cnpj = value;
            }
        }

        public bool TipoPF
        {
            get
            {
                string tmpCNPJ = this.Cnpj.Replace("/", "").Replace("-", "").Replace(".", "");
                if (tmpCNPJ.Length == 11)
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

        public bool TipoPJ
        {
            get
            {
                string tmpCNPJ = this.Cnpj.Replace("/", "").Replace("-", "").Replace(".", "");
                if (tmpCNPJ.Length == 11)
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

        public bool TipoDimCubagem
        {
            get
            {
                if (this.TipoDimensionamentoVolumetrico == ClienteTipoDimensionamentoVolumetrico.Cubagem)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.TipoDimensionamentoVolumetrico = ClienteTipoDimensionamentoVolumetrico.Cubagem;
                }
            }
        }

        public bool TipoDimDimensoes
        {
            get
            {
                if (this.TipoDimensionamentoVolumetrico == ClienteTipoDimensionamentoVolumetrico.Dimensoes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.TipoDimensionamentoVolumetrico = ClienteTipoDimensionamentoVolumetrico.Dimensoes;
                }
            }
        }

        public bool RespEmitente
        {
            get
            {
                if (this.ResponsavelFrete == ResponsavelFrete.Emitente)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.ResponsavelFrete = ResponsavelFrete.Emitente;
                }
            }
        }

        public bool RespCliente
        {
            get
            {
                if (this.ResponsavelFrete == ResponsavelFrete.Cliente)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.ResponsavelFrete = ResponsavelFrete.Cliente;
                }
            }
        }

        public bool RespTerceiros
        {
            get
            {
                if (this.ResponsavelFrete == ResponsavelFrete.Terceiros)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.ResponsavelFrete = ResponsavelFrete.Terceiros;
                }
            }
        }

        public bool SemFrete
        {
            get
            {
                if (this.ResponsavelFrete == ResponsavelFrete.SemFrete)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    this.ResponsavelFrete = ResponsavelFrete.SemFrete;
                }
            }
        }

     

        public bool PossuiContaBancaria
        {
            get
            {
                if (this.ContaBancaria == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

           
        }

        public bool PossuiCentroCustoLucro
        {
            get
            {
                if (this.CentroCustoLucro == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                if (!value)
                {
                    this.CentroCustoLucro = null;
                }
                else
                {
                }
            }



        }

        public bool PossuiFormaPagamento
        {
            get
            {
                if (this.FormaPagamento == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            
        }

        public bool PossuiRepresentante
        {
            get
            {
                if (this.Representante == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }

        public bool PossuiVendedor
        {
            get
            {
                if (this.Vendedor == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }

        public bool PossuiComissaoRepresentante
        {
            get
            {
                if (!this.PercComissaoRepresentante.HasValue)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }

        public bool PossuiComissaoVendedor
        {
            get
            {
                if (!this.PercComissaoVendedor.HasValue)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }
        
        public override string ToString()
        {
            return this.NomeResumido;
        }

        public override string Nome { get; set; }
        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    orderByClause += " , cli_cnpj " + ordenacao.ToString() + " ";
                    return true;
                default:
                    return false;
            }
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
            if (this.TipoPJ)
            {
                if (!IWTFunctions.IWTFunctions.validaCNPJ(this.Cnpj))
                {
                    throw new ExcecaoTratada("CNPJ Inválido.");
                }
            }
            else
            {
                if (!IWTFunctions.IWTFunctions.validaCPF(this.Cnpj))
                {
                    throw new ExcecaoTratada("CPF Inválido.");
                }
            }

            if (IndicadorIe == IWTNFIndicadorIE.ContribuinteICMS)
            {
                if (string.IsNullOrWhiteSpace(this.Ie))
                {
                    throw new ExcecaoTratada("Informe a Inscrição Estadual.");
                }
            }

            if (!string.IsNullOrEmpty(Ie) && Ie != "ISENTO")
            {
                if (this.EstadoCob == null)
                {
                    throw new ExcecaoTratada("Informe a Cidade do Endereço Principal para que a Inscrição Estadual seja validada.");
                }

                if (!IWTFunctions.IWTFunctions.validaIE((int) this.EstadoCob.ID, this.Ie.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "").Trim()))
                {
                    throw new ExcecaoTratada("Inscrição Estadual Inválida.\nVerifique o número e a UF. ");
                }
            }

            if (PossuiContaBancaria && this.ContaBancaria == null)
            {
                throw new ExcecaoTratada("Selecione uma conta bancária ou desabilite o campo");
            }

            if (PossuiCentroCustoLucro && this.CentroCustoLucro == null)
            {
                throw new ExcecaoTratada("Selecione um centro de custo ou desabilite o campo");
            }

            if (PossuiFormaPagamento && this.FormaPagamento == null)
            {
                throw new ExcecaoTratada("Selecione uma forma de pagamento ou desabilite o campo");
            }

            if (this.FamiliaCliente == null)
            {
                throw new ExcecaoTratada("O campo agrupador é obrigatório");
            }


            if (!string.IsNullOrWhiteSpace(this.Email))
            {
                Email = Email.Trim();
                if (this.Email.EndsWith(";"))
                {
                    Email = Email.Substring(0, Email.Length - 1);

                }

                if (this.Email.Length>60)
                {
                    throw new ExcecaoTratada("O campo de email deve ter menos de 60 caracteres");
                }

                
                

                try
                {
                    MailAddress m = new MailAddress(this.Email);
                }
                catch (FormatException)
                {
                    throw new ExcecaoTratada("O campo de email é inválido");
                } 
            }

            return true;
        }

        private void validaExistenciaCpfCnpj(string cpfCnpj)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT COUNT(c.id_cliente) as total FROM cliente c WHERE c.cli_cnpj = :cpf_cnpj";
                command.Parameters.Clear();

                if (this.ID != -1)
                {
                    command.CommandText += " AND c.id_cliente <> :id_cliente ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cpf_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = cpfCnpj;

                string count = command.ExecuteScalar().ToString();

                if (int.Parse(count) > 0)
                {
                    throw new Exception("CPF/CNPJ já existente para outro cliente.");
                }

            }
            catch (Exception e)
            {
                if (e.Message == "CPF/CNPJ já existente para outro cliente.")
                {
                    throw;
                }
                else
                {
                    throw new Exception("Erro ao validar CPF/CNPJ do cliente.\r\n" + e.Message, e);
                }
            }
        }

        public void AdicionarClienteContato(ClienteContatoClass contato)
        {
            this.CollectionClienteContatoClassCliente.Add(contato);
        }

        public void ExcluirClienteContato(ClienteContatoClass contato)
        {


            try
            {
                if (!this.CollectionClienteContatoClassCliente.Contains(contato))
                {
                    throw new ExcecaoTratada("O Cliente Contato " + contato + " não foi encontrado no cliente");
                }

                this.CollectionClienteContatoClassCliente.Remove(contato);
                this.adicionarObjetoDeletar(contato);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir o contato do cliente.\r\n" + e.Message, e);
            }
        }

        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            ApiEasiFinanceiroNovo.AtualizarCliente(this, UsuarioAtual, command);
        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            ApiEasiFinanceiroNovo.ExcluirCliente(this, command);
        }


    }
}
