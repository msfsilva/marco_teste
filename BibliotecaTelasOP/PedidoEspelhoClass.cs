using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using dbProvider;

namespace BibliotecaTelasOP
{
    class PedidoEspelhoClass
    {
        public byte[] logoEmpresa { get; private set; }

        //Dados do Cliente
        public int idCliente { get; private set; }
        public string cliente { get; private set; }
        public string cnpjCliente { get; private set; }
        public string enderecoCliente { get; private set; }
        public string bairroCliente { get; private set; }
        public string cepCliente { get; private set; }
        public string cidadeCliente { get; private set; }
        public string foneCliente { get; private set; }
        public string ufCliente { get; private set; }
        public string inscricaoEstadualCliente { get; private set; }

        //Dados do Pedido
        public string numero { get; private set; }
        public int posicao { get; private set; }
        public string operacao { get; private set; }
        public string projeto { get; private set; }
        public string armazenagem { get; private set; }
        public string ordemVenda { get; private set; }
        public DateTime dataPedido { get; private set; }
        public string formaPagamento { get; private set; }

        //Dados da linda do pedido (Produtos)
        public int idProduto { get; private set; }
        public string codProduto { get; private set; }
        public string codProdutoCliente { get; private set; }
        public string descricao { get; private set; }
        public double qtd { get; private set; }
        public double valorUnitario { get; private set; }
        public double valorTotal { get; private set; }

        public string ncm { get; private set; }
        public string informacoesEspeciais { get; private set; }
        public DateTime dataEntrega { get; private set; }


        public PedidoEspelhoClass(byte[] logoEmpresa, int idCliente, string cliente, string cnpjCliente, string enderecoCliente, string bairroCliente, string cepCliente,
                                  string cidadeCliente, string foneCliente, string ufCliente, string inscricaoEstadualCliente, string numero, int posicao,
                                  string operacao, string projeto, string armazenagem, string ordemVenda, DateTime dataPedido, string formaPagamento,
                                  int idProduto, string codProduto, string codProdutoCliente, string descricao, double qtd, double valorUnitario, double valorTotal,
                                  string ncm, string informacoesEspeciais, DateTime dataEntrega)
        {
            this.logoEmpresa = logoEmpresa;
            this.idCliente = idCliente;
            this.cliente = cliente;
            this.cnpjCliente = cnpjCliente;
            this.enderecoCliente = enderecoCliente;
            this.bairroCliente = bairroCliente;
            this.cepCliente = cepCliente;
            this.cidadeCliente = cidadeCliente;
            this.foneCliente = foneCliente;
            this.ufCliente = ufCliente;
            this.inscricaoEstadualCliente = inscricaoEstadualCliente;
            this.numero = numero;
            this.posicao = posicao;
            this.operacao = operacao;
            this.projeto = projeto;
            this.armazenagem = armazenagem;
            this.ordemVenda = ordemVenda;
            this.dataPedido = dataPedido;
            this.formaPagamento = formaPagamento;
            this.idProduto = idProduto;
            this.codProduto = codProduto;
            this.codProdutoCliente = codProdutoCliente;
            this.descricao = descricao;
            this.qtd = qtd;
            this.valorUnitario = valorUnitario;
            this.valorTotal = valorTotal;
            this.ncm = ncm;
            this.informacoesEspeciais = informacoesEspeciais;
            this.dataEntrega = dataEntrega;
        }


        public static List<PedidoEspelhoClass> gerar(List<PedidoEspelhoParametrosBuscaClass> parametros)
        {
            try
            {
                byte[] tmp = Configurations.IWTConfiguration.Conf.getBinaryConf("B_1.1");
                if (tmp != null)
                {
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    //imagem.Save("C:\\teste.bmp");
                    tmp = ms.ToArray();
                }

                List<PedidoEspelhoClass> toRet = new List<PedidoEspelhoClass>();

                string whereClause = null;

                string sql =
                        "SELECT " +
                        "  public.cliente.id_cliente, " +
                        "  public.cliente.cli_nome, " +
                        "  public.cliente.cli_cnpj, " +
                        "  public.cliente.cli_endereco, " +
                        "  public.cliente.cli_bairro, " +
                        "  public.cliente.cli_cep, " +
                        "  public.cidade.cid_nome, " +
                        "  public.cliente.cli_fone1, " +
                        "  public.estado.est_sigla, " +
                        "  public.cliente.cli_ie, " +
                        "  public.pedido_item.pei_numero, " +
                        "  public.pedido_item.pei_posicao, " +
                        "  public.operacao.ope_descricao, " +
                        "  public.pedido_item.pei_projeto_cliente, " +
                        "  public.pedido_item.pei_armazenagem_cliente, " +
                        "  public.pedido_item.pei_ordem_venda,  " +
                        "  public.pedido_item.pei_data_entrada,  " +
                        "  public.forma_pagamento.fop_identificacao,  " +
                        "  public.produto.id_produto, " +
                        "  public.produto.pro_codigo, " +
                        "  public.produto.pro_codigo_cliente, " +
                        "  public.produto.pro_descricao, " +
                        "  public.pedido_item.pei_quantidade, " +
                        "  public.pedido_item.pei_preco_unitario, " +
                        "  public.pedido_item.pei_preco_total, " +
                        "  public.pedido_item.pei_nbm, " +
                        "  public.pedido_item.pei_informacao_especial, " +
                        "  public.pedido_item.pei_data_entrega " +
                        "FROM " +
                        "  public.pedido_item " +
                        "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                        "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto) " +
                        "  INNER JOIN public.cidade ON (public.cliente.id_cidade = public.cidade.id_cidade) " +
                        "  INNER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                        "  INNER JOIN public.operacao ON (public.pedido_item.id_operacao = public.operacao.id_operacao) " +
                        "  LEFT JOIN public.forma_pagamento ON (public.pedido_item.id_forma_pagamento = public.forma_pagamento.id_forma_pagamento) ";


                if(parametros.ToArray().Length > 0)
                {
                    int count = 0;
                    whereClause = " WHERE ";
                    while(count < parametros.ToArray().Length)
                    {
                        if (count == 0)
                        {
                            whereClause += " (public.cliente.id_cliente = " + parametros.ToArray()[count].idCliente +") ";
                        }else
                        {
                            whereClause += " OR (public.cliente.id_cliente = " + parametros.ToArray()[count].idCliente + ") ";
                        }

                        if (parametros.ToArray()[count].numero != null)
                        {
                            whereClause += "AND (public.pedido_item.pei_numero = '" + parametros.ToArray()[count].numero +
                                           "') ";
                        }
                        if (parametros.ToArray()[count].posicao != null)
                        {
                            whereClause += "AND (public.pedido_item.pei_posicao = " + parametros.ToArray()[count].posicao + ") ";
                        }
                        count++;
                    }
                    
                }

                sql += whereClause;


                IWTPostgreNpgsqlCommand command = dbProvider.DbConnection.Connection.CreateCommand();
                command.CommandText = sql;
             

                NpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    toRet.Add(
                        new PedidoEspelhoClass(
                            tmp,
                            Convert.ToInt32(read["id_cliente"].ToString()),
                            read["cli_nome"].ToString(),
                            read["cli_cnpj"].ToString(),
                            read["cli_endereco"].ToString(),
                            read["cli_bairro"].ToString(),
                            read["cli_cep"].ToString(),
                            read["cid_nome"].ToString(),
                            read["cli_fone1"].ToString(),
                            read["est_sigla"].ToString(),
                            read["cli_ie"].ToString(),
                            read["pei_numero"].ToString(),
                            int.Parse(read["pei_posicao"].ToString()),
                            read["ope_descricao"].ToString(),
                            read["pei_projeto_cliente"].ToString(),
                            read["pei_armazenagem_cliente"].ToString(),
                            read["pei_ordem_venda"].ToString(),
                            Convert.ToDateTime(read["pei_data_entrada"].ToString()),
                            read["fop_identificacao"].ToString(),
                            int.Parse(read["id_produto"].ToString()),
                            read["pro_codigo"].ToString(),
                            read["pro_codigo_cliente"].ToString(),
                            read["pro_descricao"].ToString(),
                            double.Parse(read["pei_quantidade"].ToString()),
                            double.Parse(read["pei_preco_unitario"].ToString()),
                            double.Parse(read["pei_preco_total"].ToString()),
                            read["pei_nbm"].ToString(),
                            read["pei_informacao_especial"].ToString(),
                            Convert.ToDateTime(read["pei_data_entrega"].ToString())
                         )
                    );
                }
                read.Close();

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter os dados do pedido.\r\n" + e.Message, e);
            }

            
        }



    }
}
