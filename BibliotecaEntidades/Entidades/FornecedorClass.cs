using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;
using ProjectConstants;


namespace BibliotecaEntidades.Entidades
{
    public class FornecedorClass : FornecedorBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do FornecedorClass";
        protected new const string ErroDelete = "Erro ao excluir o FornecedorClass  ";
        protected new const string ErroSave = "Erro ao salvar o FornecedorClass.";
        protected new const string ErroCollectionContaRecorrenteClassFornecedor = "Erro ao carregar a coleção de ContaRecorrenteClass.";
        protected new const string ErroCollectionContratoFornecimentoClassFornecedor = "Erro ao carregar a coleção de ContratoFornecimentoClass.";
        protected new const string ErroCollectionHistoricoCompraEpiClassFornecedor = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
        protected new const string ErroCollectionHistoricoCompraMaterialClassFornecedor = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
        protected new const string ErroCollectionHistoricoCompraProdutoClassFornecedor = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
        protected new const string ErroCollectionMaterialFornecedorClassFornecedor = "Erro ao carregar a coleção de MaterialFornecedorClass.";
        protected new const string ErroCollectionLoteClassFornecedor = "Erro ao carregar a coleção de LoteClass.";
        protected new const string ErroCollectionOrcamentoCompraClassFornecedor = "Erro ao carregar a coleção de OrcamentoCompraClass.";
        protected new const string ErroCollectionOrdemCompraClassFornecedor = "Erro ao carregar a coleção de OrdemCompraClass.";
        protected new const string ErroCollectionProdutoFornecedorClassFornecedor = "Erro ao carregar a coleção de ProdutoFornecedorClass.";
        protected new const string ErroCollectionNotaFiscalEntradaClassFornecedor = "Erro ao carregar a coleção de NotaFiscalEntradaClass.";
        protected new const string ErroCollectionEpiFornecedorClassFornecedor = "Erro ao carregar a coleção de EpiFornecedorClass.";
        protected new const string ErroCollectionContaPagarClassFornecedor = "Erro ao carregar a coleção de ContaPagarClass.";
        protected new const string ErroCollectionServicoClassFornecedor = "Erro ao carregar a coleção de ServicoClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do FornecedorClass.";
        protected new const string MensagemUtilizadoCollectionContaRecorrenteClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
        protected new const string MensagemUtilizadoCollectionContratoFornecimentoClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes ContratoFornecimentoClass:";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraEpiClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
        protected new const string MensagemUtilizadoCollectionMaterialFornecedorClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes MaterialFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionLoteClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes LoteClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoCompraClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes OrcamentoCompraClass:";
        protected new const string MensagemUtilizadoCollectionOrdemCompraClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes OrdemCompraClass:";
        protected new const string MensagemUtilizadoCollectionProdutoFornecedorClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes ProdutoFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionNotaFiscalEntradaClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes NotaFiscalEntradaClass:";
        protected new const string MensagemUtilizadoCollectionEpiFornecedorClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes EpiFornecedorClass:";
        protected new const string MensagemUtilizadoCollectionContaPagarClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes ContaPagarClass:";
        protected new const string MensagemUtilizadoCollectionServicoClassFornecedor = "A entidade FornecedorClass está sendo utilizada nos seguintes ServicoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade FornecedorClass está sendo utilizada.";

        #endregion

        public FornecedorClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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

        public bool IsentoIE
        {
            get
            {
                if (this.InscEstadual != "ISENTO")
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

            }
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

            set
            {
                if (!value)
                {
                    this.CentroCustoLucro = null;
                }
            }
        }


        public bool PossuiFormaPagamento
        {
            get
            {
                if (this.FormaPagamento != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool TipoPF
        {
            get {
                return this.TipoPessoa == Base.TipoPessoa.PF;
            }

            set
            {
                if (value)
                {
                    this.TipoPessoa = Base.TipoPessoa.PF;
                }
            }
        }

        public bool TipoPJ
        {
            get {
                return this.TipoPessoa == Base.TipoPessoa.PJ;
            }

            set
            {
                if (value)
                {
                    this.TipoPessoa = Base.TipoPessoa.PJ;
                }
            }
        }



        public override string ToString()
        {
            return this.NomeFantasia;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "IDDiferente":
                    whereClause += " AND (fornecedor.id_fornecedor <> :id_fornecedor_diferente) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor_diferente", NpgsqlDbType.Integer, parametro.Fieldvalue));
                    return true;
                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Cnpj":
                    orderByClause += " , fornecedor.for_cnpj " + ordenacao.ToString() + " ";
                    return true;
                default:
                    return false;
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (IWTConfiguration.Conf.getBoolConf(Constants.CONTROLE_CONTABIL_ENTRADA_HABILITADO) || !string.IsNullOrWhiteSpace(this.Cnpj))
            {
                if (this.TipoPessoa == Base.TipoPessoa.PF)
                {
                    if (!IWTFunctions.IWTFunctions.validaCPF(this.Cnpj))
                    {
                        throw new ExcecaoTratada("CPF Inválido.");
                    }
                }
                else
                {
                    if (!IWTFunctions.IWTFunctions.validaCNPJ(this.Cnpj))
                    {
                        throw new ExcecaoTratada("CNPJ Inválido.");
                    }
                }
            }
            if (IndicadorIe == IWTNFIndicadorIE.ContribuinteICMS)
            {
                if (string.IsNullOrWhiteSpace(this.InscEstadual))
                {
                    throw new ExcecaoTratada("Informe a Inscrição Estadual.");
                }
            }

            if (!string.IsNullOrEmpty(InscEstadual) && !this.IsentoIE)
            {
                if(this.Cidade == null)
                {
                    throw new ExcecaoTratada("Se o fornecedor possui inscrição estadual, deve-se informar a cidade do fornecedor.");
                }
                if (!IWTFunctions.IWTFunctions.validaIE(Convert.ToInt32(this.Cidade.Estado.ID), this.InscEstadual))
                {
                    throw new ExcecaoTratada("Inscrição Estadual Inválida.\nVerifique o número e a UF. ");
                }
            }

            
            if (PossuiContaBancaria && this.ContaBancaria == null)
            {
                throw new ExcecaoTratada("Selecione uma conta bancária ou desabilite o campo");
            }

            if (PossuiCentroCusto && this.CentroCustoLucro == null)
            {
                throw new ExcecaoTratada("Selecione um centro de custo ou desabilite o campo");
            }

            return true;
        }

        private void validaExistenciaCpfCnpj(string cpfCnpj)
        {
            try
            {


                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT COUNT(f.id_fornecedor) as total FROM fornecedor f WHERE f.for_cnpj = :cpf_cnpj";
                command.Parameters.Clear();

                if (this.ID != -1)
                {
                    command.CommandText += " AND f.id_fornecedor <> :id_fornecedor ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cpf_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = cpfCnpj;

                string count = command.ExecuteScalar().ToString();

                if (int.Parse(count) > 0)
                {
                    throw new Exception("CPF/CNPJ já existente para outro fornecedor.");
                }
            }
            catch (Exception e)
            {
                if (e.Message == "CPF/CNPJ já existente para outro fornecedor.")
                {
                    throw;
                }
                else
                {
                    throw new Exception("Erro ao validar CPF/CNPJ do fornecedor.\r\n" + e.Message, e);
                }
            }
        }

        public void AdicionarFornecedorContato(FornecedorContatoClass contato)
        {
            this.CollectionFornecedorContatoClassFornecedor.Add(contato);
        }

        public void ExcluirFornecedorContato(FornecedorContatoClass contato)
        {


            try
            {
                if (!this.CollectionFornecedorContatoClassFornecedor.Contains(contato))
                {
                    throw new ExcecaoTratada("O Fornecedor Contato " + contato + " não foi encontrado no fornecedor");
                }

                this.CollectionFornecedorContatoClassFornecedor.Remove(contato);
                this.adicionarObjetoDeletar(contato);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir o contato do fornecedor.\r\n" + e.Message, e);
            }
        }


        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            FornecedorDto dto = new FornecedorDto()
            {
                id = ID,
                cidade = Cidade?.Nome,
                contato = Contato,
                email = Email,
                cpfCnpj = Cnpj,
                enderecoBairro = Bairro,
                enderecoCep = Cep,
                enderecoComplemento = EndComplemento,
                enderecoLogradouro = Endereco,
                enderecoNumero = EndNumero,
                estado = Cidade?.Estado?.Sigla,
                nome = NomeFantasia,
                observacoes = Obs,
                pais = Pais,
                telefone = Fone1
            };

            if (inserting)
            {
                ApiSimuladorCompras.CriarFornecedor(UsuarioAtual, command, dto);
            }
            else
            {
                ApiSimuladorCompras.AtualizarFornecedor(UsuarioAtual, command, dto);
            }

            ApiEasiFinanceiroNovo.AtualizarFornecedor(this, UsuarioAtual, command);

        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            ExcluirDto dto = new ExcluirDto()
            {
                ids = new List<long>() {this.ID}
            };
            ApiSimuladorCompras.ExcluirFornecedor(UsuarioAtual, command, dto);

            ApiEasiFinanceiroNovo.ExcluirFornecedor(this, command);
        }


        public void SincronizarSDC(IWTPostgreNpgsqlConnection conn)
        {
            FornecedorDto dto = new FornecedorDto()
            {
                id = ID,
                cidade = Cidade?.Nome,
                contato = Contato,
                email = Email,
                cpfCnpj = Cnpj,
                enderecoBairro = Bairro,
                enderecoCep = Cep,
                enderecoComplemento = EndComplemento,
                enderecoLogradouro = Endereco,
                enderecoNumero = EndNumero,
                estado = Cidade?.Estado?.Sigla,
                nome = NomeFantasia,
                observacoes = Obs,
                pais = Pais,
                telefone = Fone1
            };

            ApiSimuladorCompras.AtualizarFornecedor(UsuarioAtual, conn, dto);
        }
    }
}
