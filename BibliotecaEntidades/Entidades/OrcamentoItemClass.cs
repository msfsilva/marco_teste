using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;
using ProjectConstants;


namespace BibliotecaEntidades.Entidades
{
    public class OrcamentoItemClass : OrcamentoItemBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do OrcamentoItemClass";
        protected new const string ErroDelete = "Erro ao excluir o OrcamentoItemClass  ";
        protected new const string ErroSave = "Erro ao salvar o OrcamentoItemClass.";
        protected new const string ErroCollectionOrcamentoKitClassOrcamentoItem = "Erro ao carregar a coleção de OrcamentoKitClass.";
        protected new const string ErroCollectionOrcamentoVariavelClassOrcamentoItem = "Erro ao carregar a coleção de OrcamentoVariavelClass.";
        protected new const string ErroCollectionOrcamentoItemVariavelClassOrcamentoItem = "Erro ao carregar a coleção de OrcamentoItemVariavelClass.";
        protected new const string ErroCollectionOrcamentoConfiguradoClassOrcamentoItem = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
        protected new const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
        protected new const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 255 caracteres";
        protected new const string ErroProdutoCodigoClienteObrigatorio = "O campo ProdutoCodigoCliente é obrigatório";
        protected new const string ErroProdutoCodigoClienteComprimento = "O campo ProdutoCodigoCliente deve ter no máximo 255 caracteres";
        protected new const string ErroProdutoDescricaoClienteObrigatorio = "O campo ProdutoDescricaoCliente é obrigatório";
        protected new const string ErroProdutoDescricaoClienteComprimento = "O campo ProdutoDescricaoCliente deve ter no máximo 255 caracteres";
        protected new const string ErroCnpjClienteObrigatorio = "O campo CnpjCliente é obrigatório";
        protected new const string ErroCnpjClienteComprimento = "O campo CnpjCliente deve ter no máximo 100 caracteres";
        protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
        protected new const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
        protected new const string ErroOperacaoObrigatorio = "O campo Operacao é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do OrcamentoItemClass.";
        protected new const string MensagemUtilizadoCollectionOrcamentoKitClassOrcamentoItem = "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoKitClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoVariavelClassOrcamentoItem = "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoVariavelClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemVariavelClassOrcamentoItem = "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoItemVariavelClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassOrcamentoItem = "A entidade OrcamentoItemClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade OrcamentoItemClass está sendo utilizada.";

        #endregion


        public OrcamentoItemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        public string NumeroPosicao
        {
            get { return this.Numero + "/" + this.Posicao; }
        }

        public string StatusTraduzido
        {
            get { return this.Status.ToString(); }
        }

        public string ClassificacaoProduto
        {
            get { return this.Produto.ClassificacaoProduto != null ? this.Produto.ClassificacaoProduto.ToString() : ""; }
        }

        private int? _semanaEntrega = null;

        public int SemanaEntrega
        {
            get
            {
                if (!_semanaEntrega.HasValue)
                {
                    int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(this.DataEntrega, IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO), IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA));
                    this._semanaEntrega = Convert.ToInt32(this.DataEntrega.ToString("yy") + weekNum.ToString().PadLeft(2, '0'));
                }

                return this._semanaEntrega.Value;
            }
        }

        private NfPrincipalClass _ultimaNF = null;
        private string NumeroOrcamentoOriginal;
        private int PosOrcamentoOriginal;
        private List<AbstractEntity> EntidadesAvulsasSalvar = new List<AbstractEntity>();

        public bool Alterado
        {
            get { return base.IsDirty(); }
        }








        public bool PossuiNbm
        {
            get { return this.Ncm!=null; }
            set
            {
                if (!value)
                {
                    this.Ncm = null;
                }
                
            }
        }

        private double PrecoTotalAnterior
        {
            get
            {
                object obj = this._precoTotalOriginal;
                double? toret = obj as double?;
                if (toret.HasValue) return toret.Value;
                return 0;
            }
        }

        public bool PossuiKit
        {
            get { return this.CollectionOrcamentoKitClassOrcamentoItem.Count > 0; }
            set
            {
                if (!value)
                {
                    for (int i = 0; i < CollectionOrcamentoKitClassOrcamentoItem.Count; i++)
                    {
                        OrcamentoKitClass orcamentoKitClass = CollectionOrcamentoKitClassOrcamentoItem[i];
                        this.adicionarObjetoDeletar(orcamentoKitClass);
                        CollectionOrcamentoKitClassOrcamentoItem.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        public OrcamentoKitClass Kit
        {
            get { return this.CollectionOrcamentoKitClassOrcamentoItem.FirstOrDefault(); }
            set
            {
                if (value != null)
                {
                    this.CollectionOrcamentoKitClassOrcamentoItem.Add(value);
                }
            }
        }


        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Aprovado":
                    whereClause += " AND (ori_status = 1) ";
                    return true;
                case "Pendente":
                    whereClause += " AND (ori_status = 0) ";
                    return true;
                case "Cancelado":
                    whereClause += " AND (ori_status = 2) ";
                    return true;
                case "Todos":
                    whereClause += "  ";
                    return true;
                default:
                    return false;
            }
        }


        public void Cancelar(string Justificativa)
        {

            IWTPostgreNpgsqlCommand command = null;
            try
            {


                if (Justificativa.Trim().Length < 10)
                {
                    throw new Exception("O campo de justicativa deve conter pelo menos 10 caracteres válidos.");
                }

                command = (this.SingleConnection ?? this.SingleConnection).CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                this.DataCancelamento = Configurations.DataIndependenteClass.GetData();
                this.AcsUsuarioCancelamento = this.UsuarioAtual;
                this.JustificativaCancelamento = Justificativa.Trim();
                this.Status = StatusOrcamento.Cancelado;


                this.Save(ref command);

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = AcsUsuarioCancelamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_justificativa_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Justificativa.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_posicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Posicao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Cliente.ID;

                command.CommandText =
                    "UPDATE orcamento_configurado SET " +
                    " orc_status_orcamento = 'C' " +
                    "WHERE " +
                    " orc_order_number = :pei_numero AND " +
                    " orc_order_pos = :pei_posicao AND " +
                    " ((id_cliente = :id_cliente AND orc_item_original_orcamento = 1) OR (id_cliente IS NULL AND orc_item_original_orcamento = 0))";


                command.ExecuteNonQuery();

                command.Transaction.Commit();


            }
            catch (Exception a)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao cancelar o Orcamento\r\n" + a.Message, a);

            }

        }

        public void Aprovar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = (this.SingleConnection ?? this.SingleConnection).CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                this.Status = StatusOrcamento.Aprovado;
                this.Save(ref command);

                OrcamentoItemClass orcamento = ConvertToOrcamentoItem(this);

                foreach (OrcamentoItemClass item in this.CollectionOrcamentoItemClassOrcamentoItemPai)
                {
                    OrcamentoItemClass orcamentoItem = ConvertToOrcamentoItem(item);
                    orcamentoItem.OrcamentoItemPai = orcamento;
                    orcamento.CollectionOrcamentoItemClassOrcamentoItemPai.Add(orcamentoItem);
                }

                orcamento.Save(ref command);

                command.Transaction.Commit();

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                this.Status = StatusOrcamento.Pendente;
                throw new Exception("Erro ao aprovar o orçamento.\r\n" + e.Message, e);
            }
        }

        private static OrcamentoItemClass ConvertToOrcamentoItem(OrcamentoItemClass item)
        {
            return new OrcamentoItemClass(item.UsuarioAtual, item.SingleConnection)
                       {
                           ArmazenagemCliente = item.ArmazenagemCliente,
                           CentroCustoLucro = item.CentroCustoLucro,
                           Cliente = item.Cliente,
                           CnpjCliente = item.Cliente.Cnpj,
                           ContaBancaria = item.ContaBancaria,
                           DataEntrada = Configurations.DataIndependenteClass.GetData(),
                           DataEntrega = item.DataEntrega,
                           DataEntregaOriginal = item.DataEntrega,
                           Exportacao = item.Exportacao,
                           FormaPagamento = item.FormaPagamento,
                           InformacaoEspecial = item.InformacaoEspecial,
                           Ncm = item.Ncm,
                           Numero = item.Numero,
                           ObsPadraoEspelho = item.ObsPadraoEspelho,
                           Operacao = item.Operacao,
                           OrdemVenda = item.OrdemVenda,
                           PercComissaoRepresentante = item.PercComissaoRepresentante,
                           PercComissaoVendedor = item.PercComissaoVendedor,
                           PermiteEntregaParcial = item.PermiteEntregaParcial,
                           Posicao = item.Posicao,
                           PrecoTotal = item.PrecoTotal,
                           PrecoTotalOriginal = item.PrecoTotal,
                           PrecoUnitario = item.PrecoUnitario,
                           Produto = item.Produto,
                           ProdutoCodigoCliente = item.ProdutoCodigoCliente,
                           ProdutoDescricaoCliente = item.ProdutoDescricaoCliente,
                           ProjetoCliente = item.ProjetoCliente,
                           Quantidade = item.Quantidade,
                           Representante = item.Representante,
                           Status = StatusOrcamento.Pendente,
                           SubLinha = item.SubLinha
                       };
        }

        public void SalvarComo()
        {
            this.limparLinhaSalvarComo();
            this.Save();

        }

        private void limparLinhaSalvarComo()
        {
            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;

            this.Status = StatusOrcamento.Pendente;
            this.DataEntregaOriginal = this.DataEntrega;
            this.Configurado = false;
            this.DataConfiguracao = null;
            this.DataEntrada = Configurations.DataIndependenteClass.GetData();

            this.DataCancelamento = null;
            this.JustificativaCancelamento = null;
            this.AcsUsuarioCancelamento = null;


            foreach (OrcamentoItemVariavelClass itemVariavel in CollectionOrcamentoItemVariavelClassOrcamentoItem)
            {
                itemVariavel.LimparID();
            }

            foreach (OrcamentoVariavelClass variavel in CollectionOrcamentoVariavelClassOrcamentoItem)
            {
                variavel.LimparID();
            }



            foreach (OrcamentoItemClass subLinha in CollectionOrcamentoItemClassOrcamentoItemPai)
            {
                subLinha.limparLinhaSalvarComo();
            }

            if (this.Kit != null)
            {
                foreach (OrcamentoKitClass kit in CollectionOrcamentoKitClassOrcamentoItem)
                {
                    kit.LimparID();
                }
            }

        }







        public void SetKit(string tipoKit)
        {
            this.PossuiKit = false;
            if (string.IsNullOrEmpty(tipoKit))
            {
                this.PossuiKit = true;
                this.Kit = new OrcamentoKitClass( this.UsuarioAtual, this.SingleConnection)
                               {
                                   Oc = Numero,
                                   Pos = Posicao,
                                   TipoKit = tipoKit,
                                   Cliente = this.Cliente,
                                   OrcamentoItem = this
                               };

            }
        }


        public void adicionarSubitem(ProdutoClass produto, string codigoProdutoCliente,
            string descricaoProdutoCliente, double Quantidade, double valorUnitario, NcmClass NCMOrcamentoCliente)
        {
            try
            {
                int maiorSublinha = 0;
                if (this.CollectionOrcamentoItemClassOrcamentoItemPai.Count > 0)
                {
                    maiorSublinha = this.CollectionOrcamentoItemClassOrcamentoItemPai.Max(a => a.SubLinha);
                }


                if (!this.CollectionOrcamentoItemClassOrcamentoItemPai.Any(a => a.Produto == produto))
                {
                    this.CollectionOrcamentoItemClassOrcamentoItemPai.Add(
                        new OrcamentoItemClass(this.UsuarioAtual, this.SingleConnection)
                        {
                            SubLinha = (maiorSublinha + 1),
                            Produto = produto,
                            ProdutoCodigoCliente = codigoProdutoCliente,
                            ProdutoDescricaoCliente = descricaoProdutoCliente,
                            Quantidade = Quantidade,
                            PrecoUnitario = valorUnitario,
                            Ncm = NCMOrcamentoCliente,
                            OrcamentoItemPai = this
                        });

                }
                else
                {
                    throw new Exception("O produto: " + produto + " já foi existe no orcamento!");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o item ao orcamento.\r\n" + e.Message, e);
            }
        }

        public void excluirSubItem(OrcamentoItemClass subLinha)
        {
            try
            {
                if (this.CollectionOrcamentoItemClassOrcamentoItemPai.Contains(subLinha))
                {
                    this.CollectionOrcamentoItemClassOrcamentoItemPai.Remove(subLinha);
                    this.adicionarObjetoDeletar(subLinha);
                }
                else
                {
                    throw new Exception("Sublinha inválida para o orcamento");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o subitem.\r\n" + e.Message, e);
            }
        }

        public void AtualizarIncluirVariavel(VariavelClass variavel, string valor)
        {
            try
            {
                OrcamentoVariavelClass orcamentoVariavel = this.CollectionOrcamentoVariavelClassOrcamentoItem.FirstOrDefault(a => a.Variavel == variavel);
                if (orcamentoVariavel == null)
                {
                    orcamentoVariavel = new OrcamentoVariavelClass(this.UsuarioAtual, this.SingleConnection)
                    {
                        Cliente = this.Cliente,
                        Codigo = variavel.Nome,
                        OrcamentoItem = this,
                        PedidoNumero = this.Numero,
                        PedidoPosicao = this.Posicao,
                        Valor = valor
                    };

                    this.CollectionOrcamentoVariavelClassOrcamentoItem.Add(orcamentoVariavel);
                }
                else
                {
                    orcamentoVariavel.Valor = valor;
                }
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar/incluir a variável no orcamento.\r\n" + e.Message, e);
            }
        }

        public void ExcluirVariavelOrcamento(OrcamentoVariavelClass orcamentoVariavel)
        {
            try
            {
                if (!this.CollectionOrcamentoVariavelClassOrcamentoItem.Any(a => a == orcamentoVariavel))
                {
                    throw new ExcecaoTratada("A variável não foi encontrada no orcamento");
                }

                this.CollectionOrcamentoVariavelClassOrcamentoItem.Remove(orcamentoVariavel);
                this.adicionarObjetoDeletar(orcamentoVariavel);
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao exluir a variável do orcamento\r\n" + e.Message, e);
            }

        }

        public void AtualizarIncluirVariavelItem(VariavelClass variavel, string valor, int sublinha)
        {
            try
            {
                OrcamentoItemVariavelClass orcamentoVariavel = null;
                OrcamentoItemClass sublinhaOrcamento = null;
                if (sublinha == 0)
                {
                    orcamentoVariavel = this.CollectionOrcamentoItemVariavelClassOrcamentoItem.FirstOrDefault(a => a.Variavel == variavel);
                    sublinhaOrcamento = this;
                }
                else
                {
                    sublinhaOrcamento = this.CollectionOrcamentoItemClassOrcamentoItemPai.FirstOrDefault(a => a.SubLinha == sublinha);
                    if (sublinhaOrcamento == null)
                    {
                        throw new ExcecaoTratada("Sublinha não encontrada no orcamento");
                    }

                    orcamentoVariavel = sublinhaOrcamento.CollectionOrcamentoItemVariavelClassOrcamentoItem.FirstOrDefault(a => a.Variavel == variavel);
                }


                if (orcamentoVariavel == null)
                {
                    orcamentoVariavel = new OrcamentoItemVariavelClass(this.UsuarioAtual, this.SingleConnection)
                    {
                        Cliente = this.Cliente,
                        Codigo = variavel.Nome,
                        OrcamentoItem = sublinhaOrcamento,
                        PedidoNumero = this.Numero,
                        PedidoPosicao = this.Posicao,
                        Valor = valor,
                        SubLinha = sublinha,

                    };

                    sublinhaOrcamento.CollectionOrcamentoItemVariavelClassOrcamentoItem.Add(orcamentoVariavel);
                }
                else
                {
                    orcamentoVariavel.Valor = valor;
                }
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar/incluir a variável no item do orcamento.\r\n" + e.Message, e);
            }
        }

        public void ExcluirVariavelItemOrcamento(OrcamentoItemVariavelClass orcamentoItemVariavel)
        {
            try
            {
                OrcamentoItemClass sublinhaOrcamento = null;
                int sublinha = orcamentoItemVariavel.SubLinha;
                if (sublinha == 0)
                {
                    sublinhaOrcamento = this;
                }
                else
                {
                    sublinhaOrcamento = this.CollectionOrcamentoItemClassOrcamentoItemPai.FirstOrDefault(a => a.SubLinha == sublinha);
                    if (sublinhaOrcamento == null)
                    {
                        throw new ExcecaoTratada("Sublinha não encontrada no orcamento");
                    }

                }


                if (!sublinhaOrcamento.CollectionOrcamentoItemVariavelClassOrcamentoItem.Any(a => a == orcamentoItemVariavel))
                {
                    throw new ExcecaoTratada("A variável não foi encontrada no item do orcamento");
                }

                sublinhaOrcamento.CollectionOrcamentoItemVariavelClassOrcamentoItem.Remove(orcamentoItemVariavel);
                this.adicionarObjetoDeletar(orcamentoItemVariavel);
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao exluir a variável do item do orcamento\r\n" + e.Message, e);
            }
        }

        public void SetQuantidade(double novaQuantidade)
        {

            this.Quantidade = novaQuantidade;
        }
    }
}
