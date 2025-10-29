using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaExpedicao
{
    internal class SubItemConferencia
    {
        public int IdOrderItemEtiqueta { get; private set; }
        public Double QtdOriginal { get; private set; }
        public Double QtdConferida
        {
            get
            {
                return this.QtdOriginal - this.Saldo;
            }
        }
        public Double QtdConferidaNessaOperacao { get; private set; }
        public Double Saldo { get; private set; }
        public Double SaldoNessaOperacao { get; private set; }
 
        public int Situacao { get; private set; }

        private readonly ItemConferencia _parent;
        readonly AcsUsuarioClass Usuario;

        public SubItemConferencia(int idOrderItemEtiqueta, Double qtdOriginal, Double saldo, int situacao, Double qtdAConferirNessaOperacao, ItemConferencia parent, AcsUsuarioClass Usuario)
        {
            this.IdOrderItemEtiqueta = idOrderItemEtiqueta;
            this.Saldo = saldo;
            this.QtdOriginal = qtdOriginal;
            this.Situacao = situacao;
            this.SaldoNessaOperacao = qtdAConferirNessaOperacao;
            this.QtdConferidaNessaOperacao = 0;
            this.Usuario = Usuario;

            this._parent = parent;
        }

        internal void Baixa( double qtdBaixar)
        {

            if (Saldo >= qtdBaixar)
            {
                this.QtdConferidaNessaOperacao += qtdBaixar;
                this.Saldo -= qtdBaixar;
                this.SaldoNessaOperacao -= qtdBaixar;


                /*if (Saldo < qtdBaixar)
                {
                    this.Saldo = 0;
                }

                if (SaldoNessaOperacao < qtdBaixar)
                {

                    this.SaldoNessaOperacao = 0;
                }
                */

                this.Situacao = Saldo == 0 ? 2 : 1;



            }
            else
            {
                throw new Exception("Item já foi totalmente Conferido ou sem Quantidade disponível para essa etiqueta");
            }

        }

        internal void Save(IWTPostgreNpgsqlConnection conn, bool somenteMovimentacaoEstoque, long idOrderItemEtiquetaConferenciaPai)
        {
            if (QtdConferidaNessaOperacao > 0)
            {
                IWTPostgreNpgsqlCommand command = conn.CreateCommand();

                try
                {
                    if (!somenteMovimentacaoEstoque)
                    {
                        command.CommandText = "UPDATE order_item_etiqueta SET oie_saldo_conferencia = " + this.Saldo.ToString(CultureInfo.InvariantCulture) + ", oie_situacao_conferencia=" + this.Situacao + " WHERE id_order_item_etiqueta=" +
                                              this.IdOrderItemEtiqueta;
                        command.ExecuteNonQuery();

                        command.CommandText = "INSERT INTO  " +
                                              "  public.order_item_etiqueta_conferencia " +
                                              "( " +
                                              "  oic_order_number, " +
                                              "  oic_order_pos, " +
                                              "  oic_codigo_item, " +
                                              "  oic_quantidade_conferida, " +
                                              "  oic_data_conferencia, " +
                                              "  oic_identificacao_estacao, " +
                                              "  id_order_item_etiqueta, " +
                                              "  oic_volumes, " +
                                              "  oic_identificacao_usuario, " +
                                              "  oic_pallet, " +
                                              "  oic_pallet_sequencia, " +
                                              "  id_order_item_etiqueta_conferencia_pai "+
                                              ")  " +
                                              "VALUES ( " +
                                              "  :oic_order_number, " +
                                              "  :oic_order_pos, " +
                                              "  :oic_codigo_item, " +
                                              "  :oic_quantidade_conferida, " +
                                              "  :oic_data_conferencia, " +
                                              "  :oic_identificacao_estacao, " +
                                              "  :id_order_item_etiqueta, " +
                                              "  :oic_volumes, " +
                                              "  :oic_identificacao_usuario, " +
                                              "  :oic_pallet, " +
                                              "  :oic_pallet_sequencia, " +
                                              "  :id_order_item_etiqueta_conferencia_pai " +
                                              ");";

                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_order_number", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = this._parent.Key.OrderNumber;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_order_pos", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this._parent.Key.OrderPos;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_codigo_item", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = this._parent.Key.CodProduto;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_quantidade_conferida", NpgsqlDbType.Double));
                        command.Parameters[command.Parameters.Count - 1].Value = this.QtdConferidaNessaOperacao;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_data_conferencia", NpgsqlDbType.Timestamp));
                        command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_identificacao_estacao", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = this._parent.Parent.EstacaoConferencia;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.IdOrderItemEtiqueta;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_identificacao_usuario", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = this._parent.Parent.Usuario.Login;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_volumes", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = 0;

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_pallet", NpgsqlDbType.Integer));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_pallet_sequencia", NpgsqlDbType.Bigint));

                        if (this._parent.Parent.Pallet == null)
                        {
                            command.Parameters["oic_pallet"].Value = null;
                            command.Parameters["oic_pallet_sequencia"].Value = null;
                        }
                        else
                        {
                            command.Parameters["oic_pallet"].Value = this._parent.Parent.Pallet.Numero;
                            command.Parameters["oic_pallet_sequencia"].Value = this._parent.Parent.Pallet.Sequencia;
                        }

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta_conferencia_pai", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = idOrderItemEtiquetaConferenciaPai;
                        

                        command.ExecuteNonQuery();




                    }


                    if (!this._parent.Key.itemEmiteNF)
                    {
                        try
                        {

                            //Verifica se o item é emite OP
                            //Se ele for KB quem manda é o cadastro do KB
                            //Caso contrário utilizar cadastro de produto

                            ProdutoClass Produto = ProdutoBaseClass.GetEntidade(Convert.ToInt32(this._parent.Key.idProduto), this.Usuario, command.Connection);

                            bool EmiteOp = false;
                            double multiplicadorQuantidadeItemK = 1;

                            if (string.IsNullOrEmpty(this._parent.Key.idProdutoK))
                            {
                                EmiteOp = Produto.EmiteOp;
                            }
                            else
                            {
                                command.CommandText = "SELECT prk_emite_op, prk_utiliza_dimensao_quantidade_baixa,prk_dimensao FROM produto_k WHERE id_produto_k = " + this._parent.Key.idProdutoK;
                                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                                
                                if (read.HasRows)
                                {
                                    read.Read();
                                    EmiteOp = Convert.ToBoolean(Convert.ToInt16(read["prk_emite_op"]));
                                    if (Convert.ToBoolean(Convert.ToInt16(read["prk_utiliza_dimensao_quantidade_baixa"])))
                                    {
                                        //Utiliza a dimensão do agrupador para indicar a quantidade de itens que devem ser baixados
                                        //do estoque por unidade do agrupador
                                        double tmp;

                                        if (double.TryParse(read["prk_dimensao"].ToString(), out  tmp))
                                        {
                                            multiplicadorQuantidadeItemK = tmp;
                                        }
                                        else
                                        {
                                            throw new Exception("O item " + this._parent.Key.CodProduto + " possui um item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                                        }
                                    }
                                }
                                else
                                {
                                    EmiteOp = Produto.EmiteOp;
                                }
                                read.Close(); 
                            }

                            ProdutoKClass produtoK = null;
                            if (!string.IsNullOrEmpty(this._parent.Key.idProdutoK))
                            {
                                produtoK = ProdutoKClass.GetEntidade(int.Parse(this._parent.Key.idProdutoK), Usuario, conn);
                            }


                            if (EmiteOp)
                            {
                                //item Emite OP, baixa o item produzido

                                if (produtoK == null)
                                {
                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                        Produto,
                                        this.QtdConferidaNessaOperacao*-1*multiplicadorQuantidadeItemK,
                                        "Baixa de Produto Produzido na Conferência",
                                        "Pedido " + this._parent.Key.OrderNumber + "/" + this._parent.Key.OrderPos,
                                        this.Usuario, false, ref command, false);
                                }
                                else
                                {


                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                      produtoK,
                                        this.QtdConferidaNessaOperacao * -1 * multiplicadorQuantidadeItemK,
                                        "Baixa de Produto Kanban Produzido na Conferência",
                                        "Pedido " + this._parent.Key.OrderNumber + "/" + this._parent.Key.OrderPos,
                                        this.Usuario, false, ref command);
                                }
                            }
                            else
                            {
                                //item é não emite OP, baixa os materiais ou  o produto comprado

                                //Identifica se o item é comprado



                                switch (Produto.TipoAquisicao)
                                {
                                    case TipoAquisicao.Fabricado:

                                        //Verifica se existe estoque do produto acabado, se existir ele tem precedencia sobre a baixa de materiais
                                        double qtdBaixar = this.QtdConferidaNessaOperacao * multiplicadorQuantidadeItemK;

                                        if (produtoK == null)
                                        {

                                            double qtdEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(Produto, ref command);
                                            if (qtdEstoque > 0)
                                            {
                                                if (qtdEstoque >= qtdBaixar)
                                                {
                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                                        Produto,
                                                        qtdBaixar*-1,
                                                        "Baixa de produto acabado na conferencia",
                                                        "Pedido " + this._parent.Key.OrderNumber + "/" + this._parent.Key.OrderPos,
                                                        this.Usuario, false, ref command, false);
                                                    qtdBaixar = 0;
                                                }
                                                else
                                                {
                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                                        Produto,
                                                        qtdEstoque*-1,
                                                        "Baixa de produto acabado na conferencia",
                                                        "Pedido " + this._parent.Key.OrderNumber + "/" + this._parent.Key.OrderPos,
                                                        this.Usuario, false, ref command, false);
                                                    qtdBaixar -= qtdEstoque;
                                                }
                                            }
                                        }
                                        else
                                        {

                                            //Item KB
                                            double qtdEstoque = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProdutoK(produtoK, ref command);
                                            if (qtdEstoque > 0)
                                            {
                                                if (qtdEstoque >= qtdBaixar)
                                                {
                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                                        produtoK,
                                                        qtdBaixar*-1,
                                                        "Baixa de produto KB na conferencia",
                                                        "Pedido " + this._parent.Key.OrderNumber + "/" + this._parent.Key.OrderPos,
                                                        this.Usuario, false, ref command);
                                                    qtdBaixar = 0;
                                                }
                                                else
                                                {
                                                    EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                                        produtoK,
                                                        qtdEstoque*-1,
                                                        "Baixa de produto KB na conferencia",
                                                        "Pedido " + this._parent.Key.OrderNumber + "/" + this._parent.Key.OrderPos,
                                                        this.Usuario, false, ref command);
                                                    qtdBaixar -= qtdEstoque;
                                                }
                                            }
                                        }


                                        if (qtdBaixar > 0)
                                        {
                                            foreach (ProdutoMaterialClass mat in Produto.Materiais)
                                            {

                                                EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoMaterial(
                                                    mat.Material,
                                                    -1*mat.Quantidade*qtdBaixar,
                                                    "Baixa de Materiais na Conferência",
                                                    "Pedido " + this._parent.Key.OrderNumber + "/" + this._parent.Key.OrderPos,
                                                    this.Usuario, false, ref command, false);

                                            }
                                        }
                                        break;

                                    case TipoAquisicao.Comprado:
                                        EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                            Produto,
                                            this.QtdConferidaNessaOperacao * -1 * multiplicadorQuantidadeItemK,
                                            "Baixa de Produto Comprado na Conferência",
                                            "Pedido " + this._parent.Key.OrderNumber + "/" + this._parent.Key.OrderPos,
                                            this.Usuario, false, ref command, false);
                                        break;


                                }
                            }
                        }

                        catch (Exception e)
                        {
                            throw new Exception("Erro ao realizar a baixa de estoque dos materiais.\r\n" + e.Message, e);
                        }


                    }
                   


                }
                catch (Exception a)
                {
                    throw new Exception("Erro ao salvar a conferência do item:" + this._parent.Key.CodProduto + ".\r\n" + a.Message);
                }

            }
        }
    }
}