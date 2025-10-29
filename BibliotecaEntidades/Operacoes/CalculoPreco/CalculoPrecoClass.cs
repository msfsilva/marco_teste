#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Configurador;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaEntidades.Operacoes.CalculoPreco
{
    public class CalculoPrecoClass
    {
        //AcsUsuarioClass Usuario;
        readonly IWTPostgreNpgsqlConnection conn;
        private string tabela;
        private string identCampos;
        private string tabelaInterna;
        private string identCamposInterna;
        private AcsUsuarioClass _usuarioAtual;
        public CalculoPrecoClass(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuarioAtual)
        {
            this.conn = conn;
            _usuarioAtual = usuarioAtual;
        }


        public double calulaPrecoPedido(string Oc, string Pos, string idCliente, out string avisos, bool orcamento, out string logCalculo)
        {
            return calulaPrecoPedido(Oc, Pos, idCliente, out avisos, orcamento ? PedidoOrcamento.Orcamento : PedidoOrcamento.Pedido, out logCalculo);
        }

        public double calulaPrecoPedido(string Oc, string Pos, string idCliente, out string avisos, PedidoOrcamento tipoEntidade, out string logCalculo)
        {
            try
            {
                tabela = "pedido_item";
                identCampos = "pei_";

                if (tipoEntidade == PedidoOrcamento.Orcamento)
                {
                    tabela = "orcamento_item";
                    identCampos = "ori_";
                }

                tabelaInterna = "order_item_etiqueta";
                identCamposInterna = "oie_";

                if (tipoEntidade == PedidoOrcamento.Orcamento)
                {
                    tabela = "orcamento_configurado";
                    identCampos = "orc_";
                }

                avisos = "";

                double toRet = 0;
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public." + tabela + "." + identCampos + "quantidade, " +
                    "  public." + tabela + ".id_produto, " +
                    "  public." + tabela + "." + identCampos + "posicao, " +
                    "  public."+tabelaInterna+".id_"+tabelaInterna+" as idConfigurado "+
                    "FROM " +
                    "  public." + tabela + " " +
                    "  JOIN public."+tabelaInterna+" ON "+tabela+".id_"+tabela+" = "+tabelaInterna+".id_"+tabela+" "+
                    "WHERE " +
                    "  public." + tabela + "." + identCampos + "sub_linha = 0 AND  " +
                    "  public." + tabela + "." + identCampos + "numero LIKE '" + Oc + "' AND  " +
                    "  public." + tabela + ".id_cliente =" + idCliente + " ";

                if (!string.IsNullOrEmpty(Pos))
                {
                    command.CommandText += " AND public." + tabela + "." + identCampos + "posicao = " + Pos + " ";
                }

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    read.Close();
                    //throw new Exception("Linha 0 do Pedido/Orçamento não encontrada.");
                    read.Close();
                    logCalculo = "Linha 0 do Pedido/Orçamento não encontrada. Verifique se o pedido/orçamento está configurado antes de rodar o calculo de preço";
                    return 0;
                }
                logCalculo = "";
                while (read.Read())
                {
                    logCalculo += "Iniciando Cálculo de Preços" + Environment.NewLine;
                    double? dimensaoPai = null;
                    double tmp = this.calculaPrecoProduto(Convert.ToInt32(read["id_produto"]), Convert.ToDouble(read[identCampos + "quantidade"]), ref dimensaoPai, Oc, read[identCampos + "posicao"].ToString(), idCliente, 0, tipoEntidade, ref logCalculo, read["idConfigurado"] as int?);
                    toRet += tmp;

                    if (string.IsNullOrEmpty(Pos))
                    {
                        avisos += "Preço da linha " + Oc + "/" + read[identCampos + "posicao"] + " R$ " + tmp.ToString("F2", CultureInfo.CurrentCulture) + "\r\n";
                    }

                    logCalculo += "Término do Cálculo de Preços" + Environment.NewLine;
                }


                if (toRet == 0)
                {
                    logCalculo += "O valor do pedido/orçamento deve ser maior do que zero.";
                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Pedido/Orçamento " + Oc + "/" + Pos + " : " + e.Message);
            }
        }

        private double calculaPrecoProduto(int idProduto, double Qtd, ref double? dimensaoPai, string Oc, string Pos, string idCliente, int? subLinha, PedidoOrcamento tipoEntidade, ref string logCalculo, int? idItemPaiConfigurado)
        {

            ProdutoClass Produto = ProdutoBaseClass.GetEntidade(idProduto, _usuarioAtual, this.conn);
            try
            {

                if (Produto.CadastroPreco)
                {
                    logCalculo += "Calculando: " + Produto.Codigo;
                    if (dimensaoPai == null && subLinha == 0)
                    {
                        try
                        {
                            //É o item pai, calcula a dimensão dele
                            Dictionary<string, Variavel> variaveis = this.getTodasVariaveisItem(Oc, Pos, idCliente, subLinha, Produto, 0,tipoEntidade);
                            Configurador.Configurador conf = new Configurador.Configurador(variaveis);
                            object retorno;
                            conf.Start(Produto.RegraDimensao, ConfiguradorTipoRegra.RegraDouble,Produto.Codigo, "REGRA DE DIMENSÃO",false, out retorno);
                            if (retorno is double)
                            {
                                dimensaoPai = (double)retorno;
                            }
                            else
                            {
                                dimensaoPai = 0;
                            }

                        }
                        catch (Exception a)
                        {
                            throw new Exception(a.Message.Substring(a.Message.LastIndexOf("\r\n") + 2));
                        }

                        logCalculo += " (" + dimensaoPai + ")";
                    }

                    double valorUnitario;
                    double valorTotal;
                    switch (Produto.CalculoPreco)
                    {
                        case TipoCalculoPrecoProdudo.Fixo:
                            logCalculo += " - Preço Fixo: ";
                            valorUnitario = this.getPrecoFixo(Produto);
                            logCalculo += " Unit. "+valorUnitario;
                            valorTotal = valorUnitario*Qtd;
                            logCalculo += " Total " + valorTotal + Environment.NewLine;
                            return valorTotal;

                        case TipoCalculoPrecoProdudo.VariavelRegra:
                            logCalculo += " - Preço Variável: ";
                            valorUnitario = this.getPrecoVariavelRegra(Produto, Oc, Pos, idCliente, subLinha, ref dimensaoPai, tipoEntidade,ref logCalculo);
                            logCalculo += " Unit. "+valorUnitario;
                            valorTotal = valorUnitario*Qtd;
                            logCalculo += " Total " + valorTotal + Environment.NewLine;
                            return valorTotal;

                        case TipoCalculoPrecoProdudo.VariavelSomaFilhosPedidoSelecionados:
                            if (subLinha == 0)
                            {
                                logCalculo += " - SomaPrecoFilhosIndicados" + Environment.NewLine;
                                valorTotal = this.getPrecoSomaFilhosIndicados(Produto, Oc, Pos, idCliente, ref dimensaoPai, tipoEntidade, ref logCalculo);
                                logCalculo += "Valor total " + Produto.Codigo + " " + valorTotal + Environment.NewLine;
                            }
                            else
                            {
                                logCalculo += " - SomaPrecoFilhosIndicados" + Environment.NewLine;
                                valorTotal = this.getPrecoSomaFilhosIndicadosEstrutura(Produto, Oc, Pos, idCliente, subLinha, ref dimensaoPai, tipoEntidade, ref logCalculo, idItemPaiConfigurado);
                                logCalculo += "Valor total " + Produto.Codigo + " " + valorTotal + Environment.NewLine;
                            }
                            
                            return valorTotal;

                        case TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedido:
                            if (subLinha != 0)
                            {
                                throw new Exception("Não é permitido utilizar a soma dos itens filhos para um em item que não é item pai.");
                            }
                            logCalculo += " - SomaPrecoTodosFilhos" + Environment.NewLine;
                            valorTotal = this.getPrecoSomaTodosFilhos(Oc, Pos, idCliente, ref dimensaoPai, tipoEntidade, ref logCalculo);
                            logCalculo += "Valor total " + Produto.Codigo + " " + valorTotal + Environment.NewLine;
                            return valorTotal;
                        case TipoCalculoPrecoProdudo.VariavelSomaTodosFilhosPedidoEEstrutura:
                            logCalculo += " - SomaPrecoTodosFilhosPedidoEEstrutura" + Environment.NewLine;
                            valorTotal = 0;
                            if (subLinha == 0)
                            {
                                valorTotal += this.getPrecoSomaTodosFilhos(Oc, Pos, idCliente, ref dimensaoPai,  tipoEntidade, ref logCalculo);
                            }

                            valorTotal += this.getPrecoSomaTodosFilhosEstrutura(Produto, Oc, Pos, idCliente, subLinha, ref dimensaoPai, tipoEntidade, ref logCalculo, idItemPaiConfigurado);

                            logCalculo += "Valor total " + Produto.Codigo + " " + valorTotal + Environment.NewLine;
                            return valorTotal;
                        default:
                            throw new Exception("Tipo de Cálculo Inválido");
                            break;
                    }
                }
                else
                {
                    throw new Exception("O produto não teve o cadastro de preços realizado.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Item " + Produto.Codigo + " : " + e.Message);
            }

        }

        private double getPrecoSomaTodosFilhosEstrutura(ProdutoClass produto, string oc, string pos, string idCliente, int? subLinha, ref double? dimensaoPai, PedidoOrcamento tipoEntidade, ref string logCalculo, int? idItemPaiConfigurado)
        {

            try
            {
                if (!idItemPaiConfigurado.HasValue)
                {
                    return 0;
                }

                double toRet = 0;
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
              

                command.CommandText =
                    "SELECT  " +
                    "  public." + tabelaInterna + ".id_"+tabelaInterna+" as idPai, " +
                    "  public." + tabelaInterna + ".id_produto, " +
                    "  public." + tabelaInterna + "." + identCamposInterna + "quantidade as quant " +
                    "FROM " +
                    "  public." + tabelaInterna + " " +
                    "WHERE " +
                    "  public." + tabelaInterna + "." + "id_"+tabelaInterna+"_pai = :idPai ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("idPai", NpgsqlDbType.Integer, idItemPaiConfigurado));

                

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();


                while (read.Read())
                {
                    toRet += this.calculaPrecoProduto(Convert.ToInt32(read["id_produto"]), Convert.ToDouble(read["quant"]), ref dimensaoPai, oc, pos, idCliente, subLinha, tipoEntidade, ref logCalculo, read["idPai"] as int?);
                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private double getPrecoFixo(ProdutoClass Produto)
        {
            try
            {
                //Busca a regra vigente
                foreach (ProdutoPrecoClass preco in Produto.CollectionProdutoPrecoClassProduto)
                {
                    if (Configurations.DataIndependenteClass.GetData().Date >= preco.InicioVigencia && (preco.FimVigencia == null || Configurations.DataIndependenteClass.GetData().Date < preco.FimVigencia))
                    {
                        return preco.Preco;
                    }
                }

                throw new Exception("Não foi encontrado preço com a vigência válida para a data de hoje.");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private double getPrecoVariavelRegra(ProdutoClass Produto, string Oc, string Pos, string idCliente, int? subLinha, ref double? dimensaoPai, PedidoOrcamento tipoEntidade, ref string logCalculo)
        {
            try
            {
                //Busca a regra vigente
                string regraVigente = null;
                foreach (ProdutoPrecoClass preco in Produto.CollectionProdutoPrecoClassProduto)
                {
                    if (Configurations.DataIndependenteClass.GetData().Date >= preco.InicioVigencia && (preco.FimVigencia == null || Configurations.DataIndependenteClass.GetData().Date < preco.FimVigencia))
                    {
                        regraVigente = preco.Regra;
                        break;
                    }
                }

                if (regraVigente == null)
                {
                    throw new Exception("Não foi encontrada regra com a vigência válida para a data de hoje.");
                }

                logCalculo += " - Regra: " + regraVigente;

                //Carrega as variaveis do pedido
                Dictionary<string, Variavel> variaveis = this.getTodasVariaveisItem(Oc, Pos, idCliente, subLinha, Produto, dimensaoPai, tipoEntidade);
                try
                {
                    Configurador.Configurador conf = new Configurador.Configurador(variaveis);
                    object retorno;
                    conf.Start(regraVigente, ConfiguradorTipoRegra.RegraDouble, Produto.Codigo, "REGRA DE PREÇO", false, out retorno);
                    return (double)retorno;
                }
                catch (Exception a)
                {
                    string tmp = a.Message.Trim();
                    if (tmp.Contains(Environment.NewLine))
                    {
                        tmp = tmp.Substring(tmp.LastIndexOf(Environment.NewLine) + Environment.NewLine.Length);
                    }
                    throw new Exception(tmp);
                }
             

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private double getPrecoSomaFilhosIndicados(ProdutoClass Produto, string Oc, string Pos, string idCliente, ref double? dimensaoPai, PedidoOrcamento tipoEntidade, ref string logCalculo)
        {
            try
            {
                double toRet = 0;
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public." + tabela + "." + identCampos + "quantidade, " +
                    "  public." + tabela + ".id_produto, " +
                    "  public." + tabela + "." + identCampos + "sub_linha, " +
                    "  public." + tabelaInterna + ".id_" + tabelaInterna + " as idConfigurado " +
                    "FROM " +
                    "  public." + tabela + " " +
                    "  JOIN public." + tabelaInterna + " ON " + tabela + ".id_" + tabela + " = " + tabelaInterna + ".id_" + tabela + " " +
                    "WHERE " +
                    "  public." + tabela + "." + identCampos + "sub_linha <> 0 AND  " +
                    "  public." + tabela + "." + identCampos + "numero LIKE '" + Oc + "' AND  " +
                    "  public." + tabela + "." + identCampos + "posicao = " + Pos + " AND " +
                    "  public." + tabela + ".id_cliente =" + idCliente + ";";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    foreach (ProdutoPaiFilhoClass filho in Produto.CollectionProdutoPaiFilhoClassProdutoPai)
                    {
                        if (filho.ProdutoFilho.ID == Convert.ToInt32(read["id_produto"]) && filho.SomaPreco)
                        {
                            toRet += this.calculaPrecoProduto(Convert.ToInt32(read["id_produto"]), Convert.ToDouble(read["pei_quantidade"]), ref dimensaoPai, Oc, Pos, idCliente, Convert.ToInt32(read["pei_sub_linha"]), tipoEntidade, ref logCalculo, read["idConfigurado"] as int?);
                            break;
                        }
                    }
                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private double getPrecoSomaFilhosIndicadosEstrutura(ProdutoClass produto, string oc, string pos, string idCliente, int? subLinha, ref double? dimensaoPai, PedidoOrcamento tipoEntidade, ref string logCalculo, int? idItemPaiConfigurado)
        {
            try
            {
                if (!idItemPaiConfigurado.HasValue)
                {
                    return 0;
                }

                double toRet = 0;
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();


                command.CommandText =
                    "SELECT  " +
                    "  public." + tabelaInterna + ".id_" + tabelaInterna + " as idPai, " +
                    "  public." + tabelaInterna + ".id_produto, " +
                    "  public." + tabelaInterna + "." + identCamposInterna + "quantidade as quant " +
                    "FROM " +
                    "  public." + tabelaInterna + " " +
                    "WHERE " +
                    "  public." + tabelaInterna + "." + "id_" + tabelaInterna + "_pai = :idPai ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("idPai", NpgsqlDbType.Integer, idItemPaiConfigurado));



                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();


                while (read.Read())
                {
                    foreach (ProdutoPaiFilhoClass filho in produto.CollectionProdutoPaiFilhoClassProdutoPai)
                    {
                        if (filho.ProdutoFilho.ID == Convert.ToInt32(read["id_produto"]) && filho.SomaPreco)
                        {
                            toRet += this.calculaPrecoProduto(Convert.ToInt32(read["id_produto"]), Convert.ToDouble(read["quant"]), ref dimensaoPai, oc, pos, idCliente, subLinha, tipoEntidade, ref logCalculo, read["idPai"] as int?);
                        }
                    }
                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private double getPrecoSomaTodosFilhos(string Oc, string Pos, string idCliente, ref double? dimensaoPai, PedidoOrcamento tipoEntidade, ref string logCalculo)
        {
            try
            {
                double toRet = 0;
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                

                command.CommandText =
                    "SELECT  " +
                    "  public." + tabela + "." + identCampos + "quantidade, " +
                    "  public." + tabela + ".id_produto, " +
                    "  public." + tabela + "." + identCampos + "sub_linha, "+
                    "  public." + tabelaInterna + ".id_" + tabelaInterna + " as idConfigurado " +
                    "FROM " +
                    "  public." + tabela + " " +
                    "  JOIN public." + tabelaInterna + " ON " + tabela + ".id_" + tabela + " = " + tabelaInterna + ".id_" + tabela + " " +
                    "WHERE " +
                    "  public." + tabela + "." + identCampos + "sub_linha <> 0 AND  " +
                    "  public." + tabela + "." + identCampos + "numero LIKE '" + Oc + "' AND  " +
                    "  public." + tabela + "." + identCampos + "posicao = " + Pos + " AND " +
                    "  public." + tabela + ".id_cliente =" + idCliente + ";";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();


                while (read.Read())
                {
                    toRet += this.calculaPrecoProduto(Convert.ToInt32(read["id_produto"]), Convert.ToDouble(read["pei_quantidade"]), ref dimensaoPai, Oc, Pos, idCliente, Convert.ToInt32(read["pei_sub_linha"]), tipoEntidade, ref logCalculo, read["idConfigurado"] as int?);
                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

   
        private Dictionary<string, Variavel> getTodasVariaveisItem(string oc, string pos, string idCliente, int? subLinha, ProdutoClass Produto, double? dimensaoPai, PedidoOrcamento tipoEntidade)
        {
            //Carrega as variaveis do pedido
            Dictionary<string, Variavel> variaveisPedido = this.getVariaveis(oc, pos, idCliente, tipoEntidade);

            if (subLinha == null)
            {
                //Tenta identificar a sublinha do pedido pelo íd do produto
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public." + tabela + "." + identCampos + "sub_linha " +
                    "FROM " +
                    "  public." + tabela + " " +
                    "WHERE " +
                   "  public." + tabela + "." + identCampos + "numero LIKE '" + oc + "' AND  " +
                    "  public." + tabela + "." + identCampos + "posicao = " + pos + " AND " +
                    "  public." + tabela + ".id_cliente = " + idCliente + " AND " +
                    "  public." + tabela + ".id_produto = " + Produto.ID + " ";

                object tmp = command.ExecuteScalar();
                if (tmp != null)
                {
                    subLinha = Convert.ToInt32(tmp);
                }
            }

            Dictionary<string, Variavel> variaveisSublinha = new Dictionary<string, Variavel>();
            if (subLinha != null)
            {
                //Busca e utiliza as variaveis da sublinha com prioridade
                variaveisSublinha = this.getVariaveisItem(oc, pos, idCliente, subLinha.Value, tipoEntidade);
            }


            foreach (KeyValuePair<string, Variavel> kvp in variaveisPedido)
            {
                if (!variaveisSublinha.ContainsKey(kvp.Key))
                {
                    variaveisSublinha.Add(kvp.Key, kvp.Value);
                }
            }

            double dimensaoLinha;
            Configurador.Configurador conf = null;
            if (subLinha != 0)
            {
                conf = new Configurador.Configurador(variaveisSublinha);
                object retorno;
                conf.Start(Produto.RegraDimensao,ConfiguradorTipoRegra.RegraDouble,Produto.Codigo, "REGRA DE DIMENSÃO", false, out retorno);
                dimensaoLinha = (double)retorno;
            }
            else
            {
                dimensaoLinha = dimensaoPai.Value;
            }

            variaveisSublinha.Add("$CALC_DIM_ITEM$", new Variavel("$CALC_DIM_ITEM$", dimensaoLinha.ToString("F5", CultureInfo.InvariantCulture)));
            variaveisSublinha.Add("$CALC_DIM_ITEM_PAI$", new Variavel("$CALC_DIM_ITEM_PAI$", dimensaoPai.Value.ToString("F5", CultureInfo.InvariantCulture)));


            return variaveisSublinha;
        }

        private Dictionary<string, Variavel> getVariaveis(string oc, string pos, string idCliente, PedidoOrcamento tipoEntidade)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                if (tipoEntidade == PedidoOrcamento.Pedido)
                {
                    command.CommandText = "SELECT pev_codigo as codigo, pev_valor as valor FROM pedido_variavel WHERE pev_pedido_numero LIKE '" + oc + "' AND pev_pedido_posicao = " + pos + " AND id_cliente=" + idCliente + " ";
                }
                else
                {
                    command.CommandText = "SELECT orv_codigo as codigo, orv_valor as valor FROM orcamento_variavel WHERE orv_pedido_numero LIKE '" + oc + "' AND orv_pedido_posicao = " + pos + " AND id_cliente=" + idCliente + " ";
                }
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                Dictionary<string, Variavel> toRet = new Dictionary<string, Variavel>();
                while (read.Read())
                {
                    toRet.Add(read["codigo"].ToString().ToUpper(), new Variavel(read["codigo"].ToString().ToUpper(), read["valor"].ToString()));
                }

                read.Close();

                return toRet;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as variáveis do pedido. " + e.Message);
            }
        }

        private Dictionary<string, Variavel> getVariaveisItem(string oc, string pos, string idCliente, int subLinha, PedidoOrcamento tipoEntidade)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                if (tipoEntidade == PedidoOrcamento.Pedido)
                {
                    command.CommandText = "SELECT piv_codigo as codigo, piv_valor as valor FROM pedido_item_variavel WHERE piv_pedido_numero LIKE '" + oc + "' AND piv_pedido_posicao = " + pos + " AND id_cliente=" + idCliente + " AND piv_sub_linha = " + subLinha + " ";
                }
                else
                {
                    command.CommandText = "SELECT oiv_codigo as codigo, oiv_valor as valor FROM orcamento_item_variavel WHERE oiv_pedido_numero LIKE '" + oc + "' AND oiv_pedido_posicao = " + pos + " AND id_cliente=" + idCliente + " AND oiv_sub_linha = " + subLinha + " ";
                }

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                Dictionary<string, Variavel> toRet = new Dictionary<string, Variavel>();
                while (read.Read())
                {
                    toRet.Add(read["codigo"].ToString().ToUpper(), new Variavel(read["codigo"].ToString().ToUpper(), read["valor"].ToString()));
                }

                read.Close();

                return toRet;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as variáveis do item. " + e.Message);
            }
        }


    }
}
