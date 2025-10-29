#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaTributos;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

#endregion

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public class ConfiguradorEASI : IConfiguradorEASI
    {
        protected internal IWTPostgreNpgsqlConnection conn { get; private set; }
        protected readonly AcsUsuarioClass _usuario;
        
        private readonly string tipoCalculoSemana;
        private readonly string diaCalculoSemana;
        private readonly bool validacaoRevisaoDocumentosHabilitada;

        private bool _avisoItemSemPedido;
        private DateTime _avisoItemSemPedidodataLimite;

        public ConfiguradorEASI(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario,  string tipoCalculoSemana, string diaCalculoSemana)
        {
            this.conn = conn;
            _usuario = usuario;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            validacaoRevisaoDocumentosHabilitada = Configurations.IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.VALIDACAO_REVISAO_DOCUMENTO_HABILITADA);

            
            _avisoItemSemPedido = Configurations.IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.AVISO_PEDIDO_ITEM_SEM_FATURAMENTO);
            int tmp;
            int dias = int.TryParse(IWTConfiguration.Conf.getConf(ProjectConstants.Constants.AVISO_PEDIDO_ITEM_SEM_FATURAMENTO_DIAS), out tmp) ? tmp : 0;
            _avisoItemSemPedidodataLimite = DataIndependenteClass.GetData().AddDays(-1 * dias);
        }

        //Cliente Especial
        //0 Geral
        //1 EASSA
        public void configurarPedido(string oc, int pos, string idCliente, int clienteEspecial, PedidoOrcamento tipoEntidade, out string avisos)
        {
            IWTPostgreNpgsqlCommand command = null;
            string codItemAtual = "";
            try
            {
                string tabela = "pedido_item";
                string identCampos = "pei_";

                if (tipoEntidade == PedidoOrcamento.Orcamento)
                {
                    tabela = "orcamento_item";
                    identCampos = "ori_";
                }




                //Busca ps dados do pedido
                command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT * FROM " +
                    "  public." + tabela + " " ;


                string prefixoOperacao = "";
                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    command.CommandText += "  INNER JOIN public.operacao_completa ON (public." + tabela + ".id_operacao_completa  = public.operacao_completa .id_operacao_completa ) ";
                    prefixoOperacao = "opc";
                }

                else
                {
                    command.CommandText += "  INNER JOIN public.operacao ON (public." + tabela + ".id_operacao = public.operacao.id_operacao) ";
                    prefixoOperacao = "ope";
                }
                    
                command.CommandText +=
                    "  LEFT OUTER JOIN public.ncm ON (public." + tabela + ".id_ncm = public.ncm.id_ncm) " +
                    "  WHERE " + identCampos + "numero LIKE '" + oc + "' AND " + identCampos + "posicao=" + pos + " AND " + tabela + ".id_cliente = " + idCliente + " AND " + identCampos + "configurado = 0 ORDER BY " + identCampos + "sub_linha;";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                string codPaiGeral = "";
                string desPaiGeral = "";
                string acabamentoPaiGeral = "";


                Dictionary<string, Variavel> variaveisPedido = this.getVariaveis(oc, pos, idCliente, tipoEntidade);

                if (read.HasRows)
                {

                    List<PedidoConfigurado> pedidosConfigurados = new List<PedidoConfigurado>();
                    ProdutoClass ProdutoNivelZero = null;
                    int maiorSubLinha = 0;
                    PedidoItemClass linhaPrincipalPedido = null;
                    while (read.Read())
                    {

                        if (read["pei_status"].ToString() == "4")
                        {
                            throw new ExcecaoTratada("Não é possível configurar o pedido " + oc + "/" + pos + " pois ele está suspenso");
                        }


                        ProdutoClass produtoAtual = ProdutoBaseClass.GetEntidade(Convert.ToInt32(read["id_produto"]), this._usuario, this.conn);
                        codItemAtual = produtoAtual.Codigo;

                        if (produtoAtual.Temporario || produtoAtual.EstruturaEmRevisao)
                        {
                            throw new Exception("Produto é temporário ou está com a estrutura em revisão: " + codItemAtual);
                        }

                        //Busca e utiliza as variaveis da sublinha com prioridade
                        short sublinha = 0;
                        if (read[identCampos + "sub_linha"] != DBNull.Value)
                        {
                            sublinha = Convert.ToInt16(read[identCampos + "sub_linha"]);
                        }

                        Dictionary<string, Variavel> variaveisSublinha = this.getVariaveisItem(oc, pos, idCliente, sublinha, tipoEntidade);

                        foreach (KeyValuePair<string, Variavel> kvp in variaveisPedido)
                        {
                            if (!variaveisSublinha.ContainsKey(kvp.Key))
                            {
                                variaveisSublinha.Add(kvp.Key, kvp.Value);
                            }
                        }




                        PedidoConfigurado toInsert = new PedidoConfigurado(tipoEntidade, this.conn, this._usuario, variaveisSublinha);
                        //Dados Básicos
                        toInsert.cliente = ClienteBaseClass.GetEntidade(Convert.ToInt32(read["id_cliente"]), this._usuario, this.conn);
                        toInsert.oie_armazenagem_cliente = read[identCampos + "armazenagem_cliente"].ToString().PadLeft(1, ' ');
                        toInsert.oie_cfop = Convert.ToInt32(read[prefixoOperacao+"_cfop"]);
                        toInsert.oie_cnpj_pedido = read[identCampos + "cnpj_cliente"].ToString();
                        toInsert.oie_data_entrega = Convert.ToDateTime(read[identCampos + "data_entrega"]);

                        toInsert.oie_frete = Convert.ToDouble(read[identCampos + "frete"]);
                        toInsert.oie_natureza_operacao = read[prefixoOperacao + "_natureza_operacao"].ToString();
                        toInsert.oie_nbm_pedido = read["ncm_codigo"].ToString();


                        toInsert.oie_nivel_item = sublinha;

                        toInsert.oie_order_number = oc;
                        toInsert.oie_order_pos = pos;
                        toInsert.oie_informacoes_especiais = read[identCampos + "informacao_especial"].ToString();

                        bool pedidoRastrearMP = false;
                        if (tipoEntidade == PedidoOrcamento.Pedido)
                        {
                            pedidoRastrearMP = Convert.ToBoolean(Convert.ToInt16(read[identCampos + "rastreamento_material"]));
                        }

                        bool produtoRastrearMP = produtoAtual.RastreamentoMaterial;

                        toInsert.rastrearMP = pedidoRastrearMP || produtoRastrearMP;






                        if (toInsert.oie_nivel_item > maiorSubLinha)
                        {
                            maiorSubLinha = (int) toInsert.oie_nivel_item;
                        }
                        /*
                        0: Pendente
                        1: Encerrado ou Aprovado
                        2: Cancelado
                        3: Reaberto
                        4: Suspenso
                        */
                        switch (read[identCampos + "status"].ToString())
                        {
                            case "0":
                                toInsert.oie_status_pedido = "P";
                                break;
                            case "1":
                                if (tipoEntidade == PedidoOrcamento.Pedido)
                                {
                                    toInsert.oie_status_pedido = "E";
                                }
                                else
                                {
                                    toInsert.oie_status_pedido = "A";
                                }
                                break;
                            case "2":
                                toInsert.oie_status_pedido = "C";
                                break;
                            case "3":
                                toInsert.oie_status_pedido = "R";
                                break;
                            case "4":
                                toInsert.oie_status_pedido = "S";
                                break;
                            default:
                                throw new Exception("Status do pedido inválido: " + read[identCampos + "status"]);
                                break;
                        }




                        int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(toInsert.oie_data_entrega.Value, tipoCalculoSemana, diaCalculoSemana);
                        toInsert.oie_pps = Convert.ToInt32(toInsert.oie_data_entrega.Value.ToString("yy") + weekNum.ToString().PadLeft(2, '0'));



                        if (clienteEspecial == 1)
                        {

                            IWTPostgreNpgsqlCommand commandEspecial = command.Connection.CreateCommand();
                            commandEspecial.CommandText = "SELECT deps, peps, ovm FROM order_item WHERE order_number LIKE '" + oc + "' AND order_pos=" + pos + " AND engineering_level=0";
                            IWTPostgreNpgsqlDataReader tmpReader = commandEspecial.ExecuteReader();
                            if (tmpReader.HasRows)
                            {
                                tmpReader.Read();
                                toInsert.oie_deps = tmpReader["deps"].ToString();

                                string ovm = tmpReader["ovm"].ToString();
                                if (ovm.Length > 3)
                                {
                                    ovm = ovm.Substring(0, ovm.Length - 3);
                                    Int64 ovmTmp;

                                    toInsert.oie_ovm = Int64.TryParse(ovm, out ovmTmp) ? ovmTmp.ToString() : ovm;
                                }
                                else
                                {
                                    toInsert.oie_ovm = ovm;
                                }
                                toInsert.oie_peps = tmpReader["peps"].ToString();
                                tmpReader.Close();
                            }

                        }
                        else
                        {
                            toInsert.oie_deps = "";
                            toInsert.oie_ovm = read[identCampos + "ordem_venda"].ToString();
                            toInsert.oie_peps = "";
                        }







                        
                        //Preencher sub item 0 - Item Pai
                        if (Convert.ToInt32(read[identCampos + "sub_linha"]) == 0)
                        {

                            toInsert.oie_emissao_parcial = Convert.ToBoolean(Convert.ToInt16(read[identCampos + "permite_entrega_parcial"]));
                            toInsert.oie_permitir_parcial = Convert.ToBoolean(Convert.ToInt16(read[identCampos + "permite_entrega_parcial"]));

                            toInsert.oie_nota_fiscal = true;
                            toInsert.oie_etiqueta_agrupada = true;
                            toInsert.oie_etiqueta_interna = produtoAtual.EtiquetaInterna;

                            codPaiGeral = produtoAtual.Codigo;
                            if (produtoAtual.Acabamento != null)
                            {
                                acabamentoPaiGeral = produtoAtual.Acabamento.Identificacao;
                            }
                            else
                            {
                                acabamentoPaiGeral = "";
                            }
                            desPaiGeral = produtoAtual.Descricao;
                            ProdutoNivelZero = produtoAtual;

                            if (Convert.ToBoolean(Convert.ToInt16(read[identCampos + "volume_unico"])))
                            {
                                toInsert.oie_volumes = 1;
                            }
                            else
                            {
                                toInsert.oie_volumes = Convert.ToInt32(read[identCampos + "saldo"]);
                            }

                            toInsert.volumeUnico = Convert.ToBoolean(Convert.ToInt16(read[identCampos + "volume_unico"]));

                            toInsert.responsavelFrete = produtoAtual.ResponsavelFrete == null ? toInsert.cliente.ResponsavelFrete : produtoAtual.ResponsavelFrete.Value;
                            if (tipoEntidade == PedidoOrcamento.Pedido)
                            {
                                linhaPrincipalPedido = PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item"]), _usuario, conn);
                            }

                        }
                        else
                        {
                            toInsert.oie_nota_fiscal = false;
                            toInsert.oie_etiqueta_agrupada = false;
                            toInsert.oie_etiqueta_interna = true;
                            toInsert.oie_volumes = 0;

                        }
                        toInsert.LinhaPrincipalPedido = linhaPrincipalPedido;

                        EstruturaProdutoConfigurador itemAtual = new EstruturaProdutoConfigurador(
                            produtoAtual,
                            Convert.ToDouble(read[identCampos + "quantidade"]),
                            true,
                            ProdutoNivelZero,
                            0,
                            produtoAtual.VersaoEstruturaAtual,
                            false,
                            null,
                            false,
                            null,
                            oc,
                            pos,
                            idCliente,
                            0,
                            tipoEntidade,
                            toInsert.Variaveis,
                            conn,
                            null
                            );

                        


                        #region Validação de Documentos

                        if (validacaoRevisaoDocumentosHabilitada)
                        {
                            if (tipoEntidade == PedidoOrcamento.Pedido)
                            {
                                List<PedidoDocumentoConfigurador> documentos = this.getDocumentos(Convert.ToInt32(read["id_" + tabela + ""]));


                                IWTPostgreNpgsqlCommand commandDocumentos = this.conn.CreateCommand();
                                commandDocumentos.CommandText =
                                    "SELECT  " +
                                    "  public.documento_tipo_familia.dtf_tipo_validacao, " +
                                    "  public.documento_tipo_familia.dtf_documento_pedido_familia, " +
                                    "  public.documento_tipo_familia.dtf_documento_pedido, " +
                                    "  public.documento_tipo_familia.dtf_documento_pedido_revisao " +
                                    "FROM " +
                                    "  public.produto_documento_tipo " +
                                    "  INNER JOIN public.documento_tipo_familia ON (public.produto_documento_tipo.id_documento_tipo_familia = public.documento_tipo_familia.id_documento_tipo_familia) " +
                                    "WHERE " +
                                    "  public.produto_documento_tipo.id_produto = :id_produto AND " +
                                    "  public.produto_documento_tipo.pdt_versao_estrutura = :pdt_versao_estrutura ";
                                commandDocumentos.Parameters.Clear();

                                commandDocumentos.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                                commandDocumentos.Parameters[commandDocumentos.Parameters.Count - 1].Value = itemAtual.Produto.ID;
                                commandDocumentos.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pdt_versao_estrutura", NpgsqlDbType.Integer));
                                commandDocumentos.Parameters[commandDocumentos.Parameters.Count - 1].Value = itemAtual.versaoEstrutura;

                                IWTPostgreNpgsqlDataReader readDocumentos = commandDocumentos.ExecuteReader();
                                while (readDocumentos.Read())
                                {
                                    TipoValidacaoDocumento TipoValidacao = (TipoValidacaoDocumento) Enum.ToObject(typeof (TipoValidacaoDocumento), readDocumentos["dtf_tipo_validacao"]);
                                    string DocumentoPedidoFamilia = readDocumentos["dtf_documento_pedido_familia"].ToString();
                                    string DocumentoPedido = readDocumentos["dtf_documento_pedido"].ToString();
                                    string DocumentoPedidoRevisao = readDocumentos["dtf_documento_pedido_revisao"].ToString();

                                    string avisoDocumento = "";
                                    if (TipoValidacao != TipoValidacaoDocumento.NaoValidar)
                                    {
                                        PedidoDocumentoConfigurador tmp = new PedidoDocumentoConfigurador(DocumentoPedidoFamilia, DocumentoPedido, DocumentoPedidoRevisao);

                                        if (documentos.Contains(tmp))
                                        {
                                            continue;
                                        }

                                        if (TipoValidacao == TipoValidacaoDocumento.ValidarBloqueio)
                                        {
                                            if (!this.validaDocumentosItemFilho(oc, pos, toInsert.cliente, itemAtual.Produto))
                                            {
                                                throw new Exception("Não foi encontrado no pedido do cliente (" + oc + "/" +
                                                                    pos + ") o documento " + DocumentoPedidoFamilia + " " +
                                                                    DocumentoPedido + " " + DocumentoPedidoRevisao);
                                            }
                                        }
                                    }
                                }

                                readDocumentos.Close();
                            }
                        }

                        #endregion

                        List<EstruturaProdutoConfigurador> itens = new List<EstruturaProdutoConfigurador>();
                        itens.Add(itemAtual);


                        int profundidadeInterna = 0;
                        itens.AddRange(this.getEstruturaProduto(itemAtual, ref command, ref profundidadeInterna));







                        foreach (EstruturaProdutoConfigurador prod in itens)
                        {

                            PedidoConfigurado toInsertInterno = toInsert.cloneBasico();
                            if (prod.Produto == null)
                            {
                                toInsertInterno.produto = null;
                                toInsertInterno.versaoEstruturaItem = 0;
                            }
                            else
                            {
                                toInsertInterno.produto = prod.Produto;
                                toInsertInterno.versaoEstruturaItem = prod.versaoEstrutura;

                            }

                            toInsert.id_produto_pai = prod.ProdutoPai.ID;
                            toInsert.profundidadeInterna = prod.profundidadeInterna;


                            Configurador conf = new Configurador(prod.VariaveisSublinha);


                            codItemAtual = prod.Produto.Codigo;





                            if (validacaoRevisaoDocumentosHabilitada)
                            {
                                if (!this.validaDocumentosItemFilho(oc, pos, toInsert.cliente, prod.Produto))
                                {
                                    throw new Exception("Não foi encontrado no pedido do cliente (" + oc + "/" +
                                                        pos + ") os documentos");
                                }
                            }






                            //Roda o configurador para verificar variaveis impossiveis

                            //Var 1
                            object validaVariaveisResult;
                            if (conf.Start(prod.regraVariavel1, ConfiguradorTipoRegra.RegraBoolean, prod.Produto.Codigo,"REGRA DE VALIDAÇÃO 1", false, out validaVariaveisResult))
                            {
                                if (!(bool) validaVariaveisResult)
                                {
                                    throw new Exception("Variável 1 do produto não atende a regra de validação.");
                                }
                            }
                            else
                            {
                                throw new Exception("Erro ao validar a variável 1");
                            }

                            //Var 2
                            if (conf.Start(prod.regraVariavel2, ConfiguradorTipoRegra.RegraBoolean, prod.Produto.Codigo, "REGRA DE VALIDAÇÃO 2", false, out validaVariaveisResult))
                            {
                                if (!(bool) validaVariaveisResult)
                                {
                                    throw new Exception("Variável 2 do produto não atende a regra de validação.");
                                }
                            }
                            else
                            {
                                throw new Exception("Erro ao validar a variável 2");
                            }

                            //Var 3
                            if (conf.Start(prod.regraVariavel3, ConfiguradorTipoRegra.RegraBoolean, prod.Produto.Codigo, "REGRA DE VALIDAÇÃO 3", false, out validaVariaveisResult))
                            {
                                if (!(bool) validaVariaveisResult)
                                {
                                    throw new Exception("Variável 3 do produto não atende a regra de validação.");
                                }
                            }
                            else
                            {
                                throw new Exception("Erro ao validar a variável 3");
                            }

                            //Var 4
                            if (conf.Start(prod.regraVariavel4, ConfiguradorTipoRegra.RegraBoolean, prod.Produto.Codigo, "REGRA DE VALIDAÇÃO 4", false, out validaVariaveisResult))
                            {
                                if (!(bool) validaVariaveisResult)
                                {
                                    throw new Exception("Variável 4 do produto não atende a regra de validação.");
                                }
                            }
                            else
                            {
                                throw new Exception("Erro ao validar a variável 4");
                            }



                            //Roda o configurador para a dimensão
                            object retornoDimensao;

                            if (conf.Start(prod.regraDimensao, ConfiguradorTipoRegra.RegraDouble, prod.Produto.Codigo, "REGRA DE DIMENSÃO", false, out retornoDimensao))
                            {
                                if (retornoDimensao is double)
                                {
                                    toInsertInterno.oie_dimensao = ((double) retornoDimensao).ToString("G", CultureInfo.InvariantCulture);
                                    toInsertInterno.oie_dimensao_double = (double) retornoDimensao;
                                }
                                else
                                {
                                    toInsertInterno.oie_dimensao = retornoDimensao.ToString();
                                    toInsertInterno.oie_dimensao_double = 0;
                                }
                            }
                            else
                            {
                                throw new Exception("Erro ao calcular a dimensão");
                            }






                            toInsertInterno.utilizaDimensaoMaiorFilho = prod.Produto.UtilizaDimensaoMaiorFilho;


                            if (prod.itemOriginalPedido)
                            {
                                if (tipoEntidade == PedidoOrcamento.Pedido)
                                {
                                    toInsertInterno.id_pedido_item = PedidoItemBaseClass.GetEntidade(Convert.ToInt32(read["id_" + tabela + ""]), this._usuario, this.conn);
                                }
                                else
                                {
                                    toInsertInterno.id_pedido_item = OrcamentoItemBaseClass.GetEntidade(Convert.ToInt32(read["id_" + tabela + ""]), this._usuario, this.conn);
                                }

                                toInsertInterno.oie_codigo_cliente = read[identCampos + "produto_codigo_cliente"].ToString();
                                toInsertInterno.oie_descricao_cliente = read[identCampos + "produto_descricao_cliente"].ToString();
                                toInsertInterno.oie_item_original_pedido = true;
                                toInsertInterno.oie_preco_total = Convert.ToDouble(read[identCampos + "preco_total"]);
                                toInsertInterno.oie_preco_unitario = Convert.ToDouble(read[identCampos + "preco_unitario"]);
                                if (toInsert.oie_nivel_item == 0)
                                {
                                    if (itens.Count > 1)
                                    {
                                        toInsertInterno.oie_tipo_ligacao = "PAI";
                                    }
                                    else
                                    {
                                        toInsertInterno.oie_tipo_ligacao = "ORFÃO";
                                    }
                                }
                                else
                                {
                                    toInsertInterno.oie_tipo_ligacao = "FILHO";
                                }
                            }
                            else
                            {
                                toInsertInterno.oie_codigo_cliente = prod.Produto.CodigoCliente;
                                toInsertInterno.oie_descricao_cliente = prod.Produto.Descricao;
                                toInsertInterno.oie_item_original_pedido = false;
                                toInsertInterno.oie_preco_total = 0;
                                toInsertInterno.oie_preco_unitario = 0;
                                toInsertInterno.oie_tipo_ligacao = "FILHO";
                                toInsertInterno.oie_nota_fiscal = false;
                                toInsertInterno.oie_etiqueta_agrupada = false;
                            }

                            if (!toInsertInterno.oie_item_original_pedido || toInsertInterno.oie_nivel_item != 0)
                            {
                                toInsertInterno.oie_etiqueta_interna = prod.Produto.EtiquetaInterna;

                            }




                            //Dimensão Embalagem
                            if (prod.Produto.Embalagem != null)
                            {
                                toInsertInterno.oie_altura = prod.Produto.Embalagem.Altura;
                                toInsertInterno.oie_largura = prod.Produto.Embalagem.Largura;
                                toInsertInterno.oie_comprimento = prod.Produto.Embalagem.Comprimento;
                                toInsertInterno.dimensaoVariavel = prod.Produto.Embalagem.DimensaoVariavel;


                                switch (prod.Produto.Embalagem.DimensaoVariavel)
                                {

                                    case DimensaoVariavelEmbalagem.Largura:
                                        toInsertInterno.oie_largura = toInsert.oie_dimensao_double;
                                        break;
                                    case DimensaoVariavelEmbalagem.Altura:
                                        toInsertInterno.oie_altura = toInsert.oie_dimensao_double;
                                        break;
                                    case DimensaoVariavelEmbalagem.Comprimento:
                                        toInsertInterno.oie_comprimento = toInsert.oie_dimensao_double;
                                        break;
                                }
                            }


                            toInsertInterno.oie_codigo_item = prod.Produto.Codigo;
                            toInsertInterno.oie_codigo_item_pai = codPaiGeral;
                            toInsertInterno.oie_acab_item_pai = acabamentoPaiGeral;
                            toInsertInterno.oie_desc_item_pai = desPaiGeral;
                            toInsertInterno.oie_descricao = prod.Produto.Descricao;
                            toInsertInterno.oie_descricao_en = prod.Produto.DescricaoIngles;
                            toInsertInterno.oie_descricao_es = prod.Produto.DescricaoEspanhol;
                            toInsertInterno.oie_descricao_pt = prod.Produto.Descricao;
                            if (prod.Produto.ClassificacaoProduto != null)
                            {
                                toInsertInterno.oie_kit_fantasia = prod.Produto.ClassificacaoProduto.Identificacao;
                            }
                            else
                            {
                                toInsertInterno.oie_kit_fantasia = "";
                            }


                            toInsertInterno.ModeloEtiquetaExpedicao = prod.Produto.ModeloEtiquetaExpedicao;



                            //if (toInsertInterno.oie_nivel_item == 0 && toInsertInterno.oie_item_original_pedido && Convert.ToInt32(readInterno["pro_qtd_etiqueta_expedicao_volume"]) == 0)
                            if (toInsertInterno.oie_etiqueta_agrupada.Value && prod.Produto.QtdEtiquetaExpedicaoVolume == 0)
                            {
                                throw new Exception(
                                    "O item principal do pedido está configurado para não emitir etiqueta de expedição. Essa configuração impediria a expedição do mesmo, por favor verifique o cadastro e configure o pedido novamente.");
                            }

                            toInsertInterno.oie_qtd_etiqueta_exp_volume = prod.Produto.QtdEtiquetaExpedicaoVolume;
                            toInsertInterno.oie_peso = prod.Produto.PesoUnitario*prod.quantidade;
                            toInsertInterno.oie_quantidade = prod.quantidade;
                            toInsertInterno.oie_saldo = toInsertInterno.oie_saldo_conferencia = prod.quantidade;

                            CalculaQtdEtiquetas(ref toInsertInterno, prod);

                            if (codPaiGeral == "51914268" || codPaiGeral == "51914269" || codPaiGeral == "51914270")
                            {
                                toInsertInterno.oie_tipo_baseboard = "LISO";
                            }
                            else
                            {
                                toInsertInterno.oie_tipo_baseboard = prod.Produto.Codigo;
                            }


                            toInsertInterno.oie_var_1_nome = (prod.Produto.Variavel1 != null ? prod.Produto.Variavel1.Nome : "");


                            if (!string.IsNullOrWhiteSpace(toInsertInterno.oie_var_1_nome) && toInsertInterno.oie_var_1_nome.Trim() != "FIXO")
                            {
                                if (toInsertInterno.oie_var_1_nome.Trim().Length > 0)
                                {
                                    if (toInsertInterno.oie_var_1_nome.Length > 0)
                                    {
                                        if (prod.VariaveisSublinha.ContainsKey(toInsertInterno.oie_var_1_nome.ToUpper()))
                                        {
                                            double teste;
                                            if (double.TryParse(prod.VariaveisSublinha[toInsertInterno.oie_var_1_nome.ToUpper()].Valor, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out teste))
                                            {
                                                toInsertInterno.oie_var_1_valor = teste.ToString(CultureInfo.GetCultureInfo("pt-BR"));
                                            }
                                            else
                                            {
                                                toInsertInterno.oie_var_1_valor = prod.VariaveisSublinha[toInsertInterno.oie_var_1_nome.ToUpper()].Valor;
                                            }


                                        }
                                        else
                                        {
                                            throw new Exception("A variável " + toInsertInterno.oie_var_1_nome + " exigida pelo produto não foi encontrada no pedido.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                toInsertInterno.oie_var_1_valor = "FIXO";
                            }

                            toInsertInterno.oie_var_2_nome = (prod.Produto.Variavel2 != null ? prod.Produto.Variavel2.Nome : "");
                            if (!string.IsNullOrWhiteSpace(toInsertInterno.oie_var_2_nome) && toInsertInterno.oie_var_2_nome.Trim() != "FIXO")
                            {
                                if (toInsertInterno.oie_var_2_nome.Trim().Length > 0)
                                {

                                    if (toInsertInterno.oie_var_2_nome.Length > 0)
                                    {
                                        if (prod.VariaveisSublinha.ContainsKey(toInsertInterno.oie_var_2_nome.ToUpper()))
                                        {
                                            double teste;
                                            if (double.TryParse(prod.VariaveisSublinha[toInsertInterno.oie_var_2_nome.ToUpper()].Valor, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out teste))
                                            {
                                                toInsertInterno.oie_var_2_valor = teste.ToString(CultureInfo.GetCultureInfo("pt-BR"));
                                            }
                                            else
                                            {
                                                toInsertInterno.oie_var_2_valor = prod.VariaveisSublinha[toInsertInterno.oie_var_2_nome.ToUpper()].Valor;
                                            }

                                        }
                                        else
                                        {
                                            throw new Exception("A variável " + toInsertInterno.oie_var_2_nome + " exigida pelo produto não foi encontrada no pedido.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                toInsertInterno.oie_var_2_valor = "FIXO";
                            }

                            toInsertInterno.oie_var_3_nome = (prod.Produto.Variavel3 != null ? prod.Produto.Variavel3.Nome : "");
                            if (!string.IsNullOrWhiteSpace(toInsertInterno.oie_var_3_nome) && toInsertInterno.oie_var_3_nome.Trim() != "FIXO")
                            {
                                if (toInsertInterno.oie_var_3_nome.Trim().Length > 0)
                                {

                                    if (toInsertInterno.oie_var_3_nome.Length > 0)
                                    {
                                        if (prod.VariaveisSublinha.ContainsKey(toInsertInterno.oie_var_3_nome.ToUpper()))
                                        {
                                            double teste;
                                            if (double.TryParse(prod.VariaveisSublinha[toInsertInterno.oie_var_3_nome.ToUpper()].Valor, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out teste))
                                            {
                                                toInsertInterno.oie_var_3_valor = teste.ToString(CultureInfo.GetCultureInfo("pt-BR"));
                                            }
                                            else
                                            {
                                                toInsertInterno.oie_var_3_valor = prod.VariaveisSublinha[toInsertInterno.oie_var_3_nome.ToUpper()].Valor;
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception("A variável " + toInsertInterno.oie_var_3_nome + " exigida pelo produto não foi encontrada no pedido.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                toInsertInterno.oie_var_3_valor = "FIXO";
                            }

                            toInsertInterno.oie_var_4_nome = (prod.Produto.Variavel4 != null ? prod.Produto.Variavel4.Nome : "");
                            if (!string.IsNullOrWhiteSpace(toInsertInterno.oie_var_4_nome) && toInsertInterno.oie_var_4_nome.Trim() != "FIXO")
                            {
                                if (toInsertInterno.oie_var_4_nome.Trim().Length > 0)
                                {
                                    if (toInsertInterno.oie_var_4_nome.Length > 0)
                                    {
                                        if (prod.VariaveisSublinha.ContainsKey(toInsertInterno.oie_var_4_nome.ToUpper()))
                                        {
                                            double teste;
                                            if (double.TryParse(prod.VariaveisSublinha[toInsertInterno.oie_var_4_nome.ToUpper()].Valor, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out teste))
                                            {
                                                toInsertInterno.oie_var_4_valor = teste.ToString(CultureInfo.GetCultureInfo("pt-BR"));
                                            }
                                            else
                                            {
                                                toInsertInterno.oie_var_4_valor = prod.VariaveisSublinha[toInsertInterno.oie_var_4_nome.ToUpper()].Valor;
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception("A variável " + toInsertInterno.oie_var_4_nome + " exigida pelo produto não foi encontrada no pedido.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                toInsertInterno.oie_var_4_valor = "FIXO";
                            }

                            ProdutoKProdutoClass produtok = prod.Produto.CollectionProdutoKProdutoClassProduto.FirstOrDefault(a => a.ProdutoK.Dimensao == toInsertInterno.oie_dimensao && a.ProdutoK.Ativo);

                            if (produtok != null)
                            {

                                toInsertInterno.oie_tipo_item = TipoControleEtiquetaProduto.Kanban;
                                toInsertInterno.oie_codigo_item = produtok.ProdutoK.Codigo;
                                toInsertInterno.id_produto_k = produtok.ProdutoK;
                                toInsertInterno.oie_etiqueta_interna = produtok.ProdutoK.ImprimeEtiqueta;

                            }
                            else
                            {
                                toInsertInterno.oie_tipo_item = TipoControleEtiquetaProduto.Customizado;
                                toInsertInterno.id_produto_k = null;
                            }

                            prod.ItemPedidoConfigurado = toInsertInterno;
                            if (prod.ItemPaiConfigurador != null)
                            {
                                toInsertInterno.IdOrderItemEtiquetaPai = prod.ItemPaiConfigurador.ItemPedidoConfigurado;
                            }



                            toInsertInterno.TipoAquisicaoProduto = prod.Produto.TipoAquisicao;

                            toInsertInterno.oie_unidade_medida = prod.Produto.UnidadeMedida;

                            pedidosConfigurados.Add(toInsertInterno);
                        }

                    }

                    codItemAtual = "";

                    read.Close();

                    //Ajusta Dimensão no caso de utilizar dimensão maior filho

                    //Inicia a busca de baixo para cima ajustanto as dimensões variaveis

                    //Acerta a dimensão de todas as sublinhas
                    for (int i = maiorSubLinha; i >= 0; i--)
                    {
                        List<PedidoConfigurado> nivelAtual = new List<PedidoConfigurado>(pedidosConfigurados.Where(t => t.oie_nivel_item == i));
                        if (nivelAtual.Count == 0)
                        {
                            continue;
                        }
                        int maxProfundidadeNivel = nivelAtual.Max(t => t.profundidadeInterna);

                        for (int j = maxProfundidadeNivel - 1; j >= 0; j--)
                        {
                            List<PedidoConfigurado> nivelAtualProfundidadeAtual = new List<PedidoConfigurado>(nivelAtual.Where(t => t.profundidadeInterna == j));

                            foreach (PedidoConfigurado ped in nivelAtualProfundidadeAtual)
                            {
                                if (ped.utilizaDimensaoMaiorFilho)
                                {
                                    double maxDimensaoFilhos = nivelAtual.Where(t => t.profundidadeInterna == j + 1 && t.id_produto_pai == ped.produto.ID).Max(t => t.oie_dimensao_double);
                                    ped.oie_dimensao = maxDimensaoFilhos.ToString("G", CultureInfo.InvariantCulture);

                                    switch (ped.dimensaoVariavel)
                                    {

                                        case DimensaoVariavelEmbalagem.Largura:
                                            ped.oie_largura = maxDimensaoFilhos;
                                            break;
                                        case DimensaoVariavelEmbalagem.Altura:
                                            ped.oie_altura = maxDimensaoFilhos;
                                            break;
                                        case DimensaoVariavelEmbalagem.Comprimento:
                                            ped.oie_comprimento = maxDimensaoFilhos;
                                            break;

                                    }
                                }
                            }
                        }
                    }

                    //Ajusta a dimensão variável da sublinha 0 pois o item original dela deve considerar as outras sublinhas como "filhos"
                    List<PedidoConfigurado> nivelZero = new List<PedidoConfigurado>(pedidosConfigurados.Where(t => t.oie_nivel_item == 0 && t.oie_item_original_pedido));
                    if (nivelZero[0].utilizaDimensaoMaiorFilho)
                    {
                        if (new List<PedidoConfigurado>(pedidosConfigurados.Where(t => t.oie_nivel_item > 0 && t.oie_item_original_pedido)).Count > 0)
                        {
                            double maxDimensaoOutrasLinhas = pedidosConfigurados.Where(t => t.oie_nivel_item > 0 && t.oie_item_original_pedido).Max(t => t.oie_dimensao_double);
                            if (maxDimensaoOutrasLinhas > nivelZero[0].oie_dimensao_double)
                            {
                                nivelZero[0].oie_dimensao = maxDimensaoOutrasLinhas.ToString("G", CultureInfo.InvariantCulture);
                                ;

                                switch (nivelZero[0].dimensaoVariavel)
                                {
                                    case DimensaoVariavelEmbalagem.Largura:
                                        nivelZero[0].oie_largura = maxDimensaoOutrasLinhas;
                                        break;
                                    case DimensaoVariavelEmbalagem.Altura:
                                        nivelZero[0].oie_altura = maxDimensaoOutrasLinhas;
                                        break;
                                    case DimensaoVariavelEmbalagem.Comprimento:
                                        nivelZero[0].oie_comprimento = maxDimensaoOutrasLinhas;
                                        break;

                                }

                            }
                        }

                    }

                    //Fim ajuste Dimensão


                    //Verifica documentos bloqueados

                    string avisoFull = "";
                     foreach (PedidoConfigurado ped in pedidosConfigurados)
                    {
                        if (ped.produto.CollectionProdutoDocumentoTipoClassProduto.Where(a=>a.VersaoEstrutura == ped.produto.VersaoEstruturaAtual).Any(documentoTipoClass => documentoTipoClass.DocumentoTipoFamilia.Bloqueado))
                        {
                            string documentosBloqurados = ped.produto.CollectionProdutoDocumentoTipoClassProduto.Where(a => a.VersaoEstrutura == ped.produto.VersaoEstruturaAtual).Where(documentoTipoClass => documentoTipoClass.DocumentoTipoFamilia.Bloqueado).Aggregate("", (current, doc) => current + ("\r\n" + doc.DocumentoTipoFamilia));
                            throw new Exception("Existem documentos bloqueados na estrutura do item, consulte a engenharia:"+ documentosBloqurados);
                        }


                        if (tipoEntidade == PedidoOrcamento.Pedido && _avisoItemSemPedido)
                        {
                         string tmp = VerificaItensSemPedido(ped);
                            if (!string.IsNullOrWhiteSpace(tmp))
                            {
                                avisoFull += Environment.NewLine + tmp;
                            }
                        }

                    }


                    avisos = avisoFull;

                    command.Transaction = this.conn.BeginTransaction();

                    foreach (PedidoConfigurado ped in pedidosConfigurados)
                    {
                        this.ValidaProduto(ped, ref command, _usuario);
                    }





                    foreach (PedidoConfigurado ped in pedidosConfigurados)
                    {
                        ped.Salvar(ref command);
                    }

                    if (tipoEntidade == PedidoOrcamento.Pedido)
                    {
                        command.CommandText = "UPDATE pedido_item SET pei_configurado = 1, pei_data_configuracao =:data_configurador WHERE pei_numero LIKE '" + oc + "' AND pei_posicao=" + pos + " AND id_cliente = " + idCliente + " ;";

                    }
                    else
                    {
                        command.CommandText = "UPDATE orcamento_item SET ori_configurado = 1, ori_data_configuracao = :data_configurador WHERE ori_numero LIKE '" + oc + "' AND ori_posicao=" + pos + " AND id_cliente = " + idCliente + " ;";


                    }
                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data_configurador", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                    command.ExecuteNonQuery();


                    command.Transaction.Commit();

                }
                else
                {
                    throw new Exception("Pedido inválido ou já configurado. Verifique se o pedido está em aberto e se a operação está selecionada");
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao executar a configuração do pedido " + oc + "/" + pos + (string.IsNullOrWhiteSpace(codItemAtual) ? "" : ":" + codItemAtual) + ".\r\n" + e.Message);
            }

        }

        private string VerificaItensSemPedido(PedidoConfigurado pedido)
        {

            try
            {
                if (!pedido.oie_item_original_pedido) return null;

                PedidoItemClass search = new PedidoItemClass(_usuario, conn);
                List<PedidoItemClass> pedidos = search.Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Produto", pedido.produto),
                    new SearchParameterClass("Entrada_Inicio", _avisoItemSemPedidodataLimite),
                    new SearchParameterClass("Encerrado",true)
                }).ToList().ConvertAll(a => (PedidoItemClass) a);
                if (!pedidos.Any(a => a.ID != pedido.id_pedido_item.ID))
                {
                    return "Pedido " + pedido.oie_order_number + "/" + pedido.oie_order_pos + ":Não foram encontrados pedidos encerrados com data de entrada depois de " + (_avisoItemSemPedidodataLimite.ToString("dd/MM/yyyy") + " para o item " + pedido.produto);
                }

                return "";

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao verificar se o pedido possui itens antigos:" + e.Message, e);
            }
        }

        protected virtual void ValidaProduto(PedidoConfigurado pedidoConfigurado, ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario)
        {
            return;
        }

        public virtual bool validaDocumentosItemFilho(string oc, int pos, ClienteClass cliente, ProdutoClass produto)
        {
            return true;
        }

        private List<EstruturaProdutoConfigurador> getEstruturaProduto(EstruturaProdutoConfigurador produtoPai, ref IWTPostgreNpgsqlCommand commmand, ref int profundidadeInterna)
        {
            string filhoAtual = "";
            try
            {

                List<EstruturaProdutoConfigurador> toRet = new List<EstruturaProdutoConfigurador>();
                profundidadeInterna++;
                commmand.CommandText =
                    "SELECT  " +
                    "  public.produto_pai_filho.id_produto_filho, " +
                    "  public.produto.pro_codigo, " +
                    "  public.produto_pai_filho.ppf_quantidade_filho, " +
                    "  public.produto.pro_regra_dimensao, " +
                    "  pro_versao_estrutura_atual, " +
                    "  pro_regra_valid_var1, " +
                    "  pro_regra_valid_var2, " +
                    "  pro_regra_valid_var3, " +
                    "  pro_regra_valid_var4, " +
                    "  pro_temporario, " +
                    "  pro_estrutura_em_revisao, " +
                    "  public.produto_pai_filho.ppf_filho_condicional, " +
                    "  public.produto_pai_filho.ppf_filho_condicional_regra, " +
                    "  public.produto_pai_filho.ppf_qtd_condicional, " +
                    "  public.produto_pai_filho.ppf_qtd_condicional_regra " +
                    "FROM " +
                    "  public.produto " +
                    "  INNER JOIN public.produto_pai_filho ON (public.produto.id_produto = public.produto_pai_filho.id_produto_filho) " +
                    "WHERE " +
                    "  id_produto_pai = " + produtoPai.Produto.ID + " AND " +
                    "  ppf_versao_estrutura = " + produtoPai.versaoEstrutura + " AND " +
                    "  produto.pro_versao_estrutura_atual = ppf_versao_estrutura_filho ";


               
                IWTPostgreNpgsqlDataReader read = commmand.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        if (read["pro_temporario"].ToString() == "1" || read["pro_estrutura_em_revisao"].ToString() == "1")
                        {
                            throw new Exception("Produto é temporário ou está com a estrutura em revisão:" + read["pro_codigo"]);
                        }

                        filhoAtual = read["pro_codigo"].ToString();


                        EstruturaProdutoConfigurador tmp = new EstruturaProdutoConfigurador(
                            ProdutoBaseClass.GetEntidade(Convert.ToInt32(read["id_produto_filho"]), this._usuario, this.conn),
                            Convert.ToDouble(read["ppf_quantidade_filho"])*produtoPai.quantidade,
                            false,
                            produtoPai.Produto,
                            profundidadeInterna,
                            Convert.ToInt32(read["pro_versao_estrutura_atual"]),
                            Convert.ToBoolean(Convert.ToInt16(read["ppf_filho_condicional"])),
                            read["ppf_filho_condicional_regra"] + "",
                            Convert.ToBoolean(Convert.ToInt16(read["ppf_qtd_condicional"])),
                            read["ppf_qtd_condicional_regra"] + "",
                            produtoPai.Oc,
                            produtoPai.Pos,
                            produtoPai.IdCliente,
                            produtoPai.SubLinha,
                            produtoPai.TipoEntidade,
                            produtoPai.VariaveisSublinha,
                            conn,
                            produtoPai
                            );

                        Configurador conf = new Configurador(tmp.VariaveisSublinha);
                        object validaCondicionalResult;

                        if (tmp.Condicional)
                        {

                            if (conf.Start(tmp.CondicionalRegra, ConfiguradorTipoRegra.RegraBoolean, tmp.Produto.Codigo, "REGRA DE CONDIÇÃO DE EXISTÊNCIA", false, out validaCondicionalResult))
                            {
                                if (!(bool) validaCondicionalResult)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                throw new Exception("Erro ao verificar a existência de um item condicional");
                            }
                        }

                        if (tmp.QtdCondicional)
                        {


                            if (conf.Start(tmp.QtdCondicionalRegra, ConfiguradorTipoRegra.RegraBoolean, tmp.Produto.Codigo, "REGRA DE QUANTIDADE CONDICIONAL", false, out validaCondicionalResult))
                            {
                                double? qtdItem = validaCondicionalResult as double?;
                                if (!qtdItem.HasValue)
                                {
                                    throw new Exception("Erro ao verificar a quantidade condicional: resultado da configuração inválido " + validaCondicionalResult);
                                }

                                tmp.quantidade = qtdItem.Value*produtoPai.quantidade;
                            }
                            else
                            {
                                throw new Exception("Erro ao verificar a quantidade condicional");
                            }
                        }

                        if (tmp.quantidade == 0)continue;

                        toRet.Add(tmp);
                        toRet.AddRange(this.getEstruturaProduto(tmp, ref commmand, ref profundidadeInterna));
                    }
                }

                return toRet;


            }
            catch (Exception e)
            {

                throw new Exception("Erro ao buscar a estrutura do item " + produtoPai.Produto.Codigo + (!string.IsNullOrWhiteSpace(filhoAtual) ? ". Processando item Filho: " + filhoAtual : "") + ".\r\n" + e.Message);
            }
        }

        public Dictionary<string, Variavel> getVariaveis(string oc, int pos, string idCliente, PedidoOrcamento tipoEntidade)
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
                    string codigo = read["codigo"].ToString().ToUpper();
                    if (toRet.ContainsKey(codigo))
                    {
                        throw new Exception("A variável do pedido " + codigo + " está duplicada.");
                    }

                    toRet.Add(codigo, new Variavel(read["codigo"].ToString().ToUpper(), read["valor"].ToString()));
                }

                read.Close();

                return toRet;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as variáveis do pedido.\r\n" + e.Message);
            }
        }

        public Dictionary<string, Variavel> getVariaveisItem(string oc, int pos, string idCliente, int subLinha, PedidoOrcamento tipoEntidade)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                if (tipoEntidade == PedidoOrcamento.Pedido)
                {
                    command.CommandText = "SELECT piv_codigo as codigo, piv_valor as valor  FROM pedido_item_variavel WHERE piv_pedido_numero LIKE '" + oc + "' AND piv_pedido_posicao = " + pos + " AND id_cliente=" + idCliente +
                                          " AND piv_sub_linha = " + subLinha + " ";
                }
                else
                {
                    command.CommandText = "SELECT oiv_codigo as codigo, oiv_valor as valor  FROM orcamento_item_variavel WHERE oiv_pedido_numero LIKE '" + oc + "' AND oiv_pedido_posicao = " + pos + " AND id_cliente=" + idCliente +
                                          " AND oiv_sub_linha = " + subLinha + " ";
                }
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                Dictionary<string, Variavel> toRet = new Dictionary<string, Variavel>();
                while (read.Read())
                {
                    string codigo = read["codigo"].ToString().ToUpper();
                    if (toRet.ContainsKey(codigo))
                    {
                        throw new Exception("A variável do item " + codigo + " está duplicada.");
                    }
                    toRet.Add(codigo, new Variavel(read["codigo"].ToString().ToUpper(), read["valor"].ToString()));
                }

                read.Close();

                return toRet;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as variáveis do item.\r\n" + e.Message);
            }
        }


        public List<PedidoDocumentoConfigurador> getDocumentos(int idPedidoItem)
        {
            try
            {
                List<PedidoDocumentoConfigurador> toRet = new List<PedidoDocumentoConfigurador>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT " +
                    "  public.pedido_documento.peo_tipo, " +
                    "  public.pedido_documento.peo_codigo, " +
                    "  public.pedido_documento.peo_revisao " +
                    "FROM " +
                    "  public.pedido_documento " +
                    "WHERE " +
                    "  public.pedido_documento.id_pedido_item = :id_pedido_item ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idPedidoItem;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    toRet.Add(new PedidoDocumentoConfigurador(read["peo_tipo"].ToString(),
                        read["peo_codigo"].ToString(),
                        read["peo_revisao"].ToString()));

                }
                read.Close();

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os documentos do pedido.\r\n" + e.Message, e);
            }
        }

        public void desconfigurarPedido(string oc, int pos, string idCliente, PedidoOrcamento tipoEntidade)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                //Busca se existe NF emitida
                if (tipoEntidade == PedidoOrcamento.Pedido)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  public.nf_principal.nfp_numero, " +
                        "  public.nf_principal.nfp_data_emissao " +
                        "FROM " +
                        "  public.order_item_etiqueta " +
                        "  INNER JOIN public.atendimento ON (public.order_item_etiqueta.id_order_item_etiqueta = public.atendimento.id_order_item_etiqueta) " +
                        "  INNER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal) " +
                        "WHERE " +
                        "  public.order_item_etiqueta.oie_order_number LIKE '" + oc + "' AND  " +
                        "  public.order_item_etiqueta.oie_order_pos =" + pos + " AND  " +
                        "  public.order_item_etiqueta.oie_nota_fiscal = 1 AND  " +
                        "  public.order_item_etiqueta.id_cliente = " + idCliente + " AND " +
                        "  public.nf_principal.nfp_situacao <> 'C' ";

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        throw new Exception("Não é possível desfazer a configuração pois esse pedido já possui nota fiscal emitida. NF: " + read["nfp_numero"]);
                    }
                    read.Close();


                    ValidaProdutosDesconfiguracao(oc, pos, idCliente, ref command, _usuario);

                    //Busca se existe OP Gerada e não cancelada
                    command.CommandText =
                        "SELECT  " +
                        "  public.ordem_producao.id_ordem_producao, " +
                        "  public.ordem_producao.orp_situacao " +
                        "FROM " +
                        "  public.ordem_producao " +
                        "  INNER JOIN public.ordem_producao_pedido ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao) " +
                        "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.ordem_producao_pedido.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                        "WHERE " +
                        "  public.ordem_producao.orp_situacao <> 3 AND  " +
                        "  public.ordem_producao_pedido.opp_order_number LIKE '" + oc + "' AND  " +
                        "  public.ordem_producao_pedido.opp_order_pos = " + pos + " AND " +
                        "  (public.order_item_etiqueta.id_cliente IS NULL OR public.order_item_etiqueta.id_cliente = " + idCliente + ") ";

                    read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        string ops = "";
                        while (read.Read())
                        {
                            ops += ", " + read["id_ordem_producao"] + "";
                        }

                        throw new Exception("Não é possível desfazer a configuração pois esse pedido possui ordens de produção emitidas e não canceladas.OPs:\r\n" + ops.Substring(1));
                    }
                    read.Close();

                    //Busca se existe Programação
                    command.CommandText =
                        "SELECT " +
                        "  public.programacao.prg_nome " +
                        "FROM " +
                        "  public.pedido_item " +
                        "  INNER JOIN public.programacao ON(public.pedido_item.id_programacao = public.programacao.id_programacao) " +
                        "WHERE " +
                        "  public.pedido_item.pei_numero LIKE '" + oc + "'  AND " +
                        "  public.pedido_item.pei_posicao = " + pos + " AND " +
                        "  public.pedido_item.id_cliente = " + idCliente + " ";

                    read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        string programacoes = "";
                        while (read.Read())
                        {
                            programacoes += ", " + read["prg_nome"] + "";
                        }

                        throw new Exception("Não é possível desfazer a configuração pois esse pedido possui programações do GAD. Programações:\r\n" + programacoes.Substring(1));
                    }
                    read.Close();

                    command.CommandText = "DELETE FROM order_item_etiqueta WHERE oie_order_number LIKE '" + oc + "' AND oie_order_pos=" + pos + " AND id_cliente = " + idCliente + "; ";
                    command.CommandText += "UPDATE pedido_item SET pei_configurado = 0, pei_data_configuracao = NULL WHERE pei_numero LIKE '" + oc + "' AND pei_posicao=" + pos + " AND id_cliente = " + idCliente + " ;";
                }
                else
                {
                    command.CommandText = "DELETE FROM orcamento_configurado WHERE orc_order_number LIKE '" + oc + "' AND orc_order_pos=" + pos + " AND id_cliente = " + idCliente + "; ";
                    command.CommandText += "UPDATE orcamento_item SET ori_configurado = 0, ori_data_configuracao = NULL WHERE ori_numero LIKE '" + oc + "' AND ori_posicao=" + pos + " AND id_cliente = " + idCliente + " ;";
                }

               

                command.ExecuteNonQuery();

               

                command.Transaction.Commit();

            }
            catch (Exception e)
            {

                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                BufferAbstractEntity.limparBuffer();
                throw new Exception("Erro ao desfazer a configuração do pedido/orçamento.\r\n" + e.Message);
            }
        }

        protected virtual void ValidaProdutosDesconfiguracao(string pedido, int posicao, string idCliente, ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario)
        {
            return;
        }

        public virtual List<PedidoDocumentoConfigurador> searchDocumentosCliente()
        {
            return new List<PedidoDocumentoConfigurador>();
        }


        protected virtual void CalculaQtdEtiquetas(ref PedidoConfigurado toInsertInterno,  EstruturaProdutoConfigurador prod)
        {
            toInsertInterno.oie_qtd_etiquetas = Convert.ToInt32(prod.quantidade);

            //tratativa para itens com quantidade fracionária abaixo de 1
            if (toInsertInterno.oie_qtd_etiquetas < 1) toInsertInterno.oie_qtd_etiquetas = 1;
        }

    }

    public enum ConfiguradorTipoRegra
    {
        RegraDouble,
        RegraBoolean,
        RegraString
    }
}
