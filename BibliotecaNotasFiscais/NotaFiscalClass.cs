#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.NFe;
using BibliotecaEntidades.Operacoes.VisualizacaoNf;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using CrystalDecisions.CrystalReports.Engine;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTLog;
using IWTNF;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTPostgreNpgsql;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using IWTNFIndicadorIE = IWTNF.Entidades.Base.IWTNFIndicadorIE;
using PresencaComprador = IWTNF.Entidades.Base.PresencaComprador;

#endregion

namespace BibliotecaNotasFiscais
{
    public class NotaFiscalEasiClass
    {
        private readonly IWTPostgreNpgsqlConnection conn;
        private readonly AcsUsuarioClass Usuario;
        
        
        private readonly VersaoLayoutNF versoesAEmitir;
        
        private readonly ArredondamentoNF arrendodamentoNF;
        


        public NotaFiscalEasiClass(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario, VersaoLayoutNF versoesAEmitir,
                                   ArredondamentoNF arrendodamentoNF)
        {
            this.conn = conn;
            this.Usuario = usuario;
            this.versoesAEmitir = versoesAEmitir;
        this.arrendodamentoNF = arrendodamentoNF;
        }

        public void emitirNFEmbarque(string idEmbarque, IObservacaoCustomizada observacaoCustomizada, bool semVisualizacao = false)
        {
            IWTPostgreNpgsqlCommand command = null;
            List<NfPrincipalClass> nfs = new List<NfPrincipalClass>();
            List<string> filesGenerated = new List<string>();


            try
            {
                command = this.conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                TipoEmissaoNFe tipoEmissaoNFe = (TipoEmissaoNFe) Enum.ToObject(typeof (TipoEmissaoNFe), int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)));

                List<nfEmitida> notasEmitidas;
                List<ContaReceberClass> contasReceber;

                try
                {
                    LogClass.EscreverLog("EmissãoNfe-Embarque:" + idEmbarque, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                }
                catch { }

                if (this.EmitirNF(idEmbarque, out nfs, out filesGenerated, out notasEmitidas, out contasReceber, observacaoCustomizada, ref command, semVisualizacao))
                {
                    try
                    {
                        LogClass.EscreverLog("EmissãoNfe-NfEmitida:" + idEmbarque, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch { }

                    // ReSharper disable ForCanBeConvertedToForeach
                    for (int i = 0; i < notasEmitidas.Count; i++)
                        // ReSharper restore ForCanBeConvertedToForeach
                    {
                        nfEmitida nf = notasEmitidas[i];
                        this.updateSaldos(ref nf, ref command);
                        this.insertAtendimento(nf, ref command);

                        this.baixaMateriaisProdutos(nf, ref command);
                    }

                    this.updateEmbarque(idEmbarque, ref command, tipoEmissaoNFe);

                    foreach (ContaReceberClass receber in contasReceber)
                    {
                        try
                        {
                            LogClass.EscreverLog("EmissãoNfe-ContaReceber:" + receber.NumDocumento + "-" + receber.Historico, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                        }
                        catch { }

                        if (receber.AgrupadorConta.IsDirty())
                        {
                            receber.AgrupadorConta.Save(ref command);
                        }
                        receber.Save(ref command);
                    }

                    command?.Transaction.Commit();


                    if (!semVisualizacao)
                    {
                        MessageBox.Show(null,
                            tipoEmissaoNFe == TipoEmissaoNFe.EASI
                                ? "Nota(s) Fiscal(is) emitidas com sucesso, as notas serão enviadas para receita pelo módulo de automações do EASI e assim que autorizadas serão impressas, armazenadas e/ou enviadas por email conforme a configuração definida"
                                : "Nota(s) Fiscal(is) emitidas com sucesso",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    try
                    {
                        LogClass.EscreverLog("EmissãoNfe-LimpaNotas:" + idEmbarque, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch { }
                    //Limpa as notas ja emitidas
                    string notDeleted = "";

                    foreach (NfPrincipalClass nf in nfs)
                    {
                        try
                        {
                            LogClass.EscreverLog("EmissãoNfe-LimpaNotas:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                        }
                        catch { }

                        try
                        {


                            if (command != null && command.Connection.State == ConnectionState.Open)
                            {

                                try
                                {
                                    LogClass.EscreverLog("EmissãoNfe-LimpaNotasDelete:" + nf.ID, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                                }
                                catch { }

                                command.CommandText = "DELETE FROM nf_principal WHERE id_nf_principal = " + nf.ID;
                                command.ExecuteNonQuery();

                            }
                            else
                            {
                                try
                                {
                                    LogClass.EscreverLog("EmissãoNfe-LimpaNotasNotDelete:" + nf.ID, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                                }
                                catch { }
                                notDeleted += "Nº. " + nf.Numero.ToString() + "\r\n";
                            }
                        }
                        catch
                        {
                            if (nf != null)
                            {
                                notDeleted += "Nº. " + nf.Numero.ToString() + "\r\n";
                            }
                        }

                    }

                    string error = "";
                    if (notDeleted.Length > 0)
                    {
                        error += "Não foi possível cancelar a emissão das notas fiscais abaixo pois a conexão com o banco de dados não está disponível. Solicite ao gestor do sistema que execute a rotina de manutenção do banco de dados.\r\n" +
                                 notDeleted;
                        throw new Exception(error);
                    }
                    command?.Transaction.Commit();

                }

               

                try
                {
                    List<EmitenteClass> emitentes = notasEmitidas.Select(a => a.Emitente).Distinct().ToList();

                    foreach (EmitenteClass emitente in emitentes)
                    {
                        if (emitente.AvisoNFAtivo)
                        {
                            AvisoNotaEmitidaClass aviso = new AvisoNotaEmitidaClass(emitente.RazaoSocial,
                                emitente.AvisoNFEnderecoInterno, emitente.AvisoNFEnderecoExterno,
                                emitente.AvisoNFDestinatario,
                                emitente.AvisoNFRemetente,
                                Usuario,
                                conn
                            );

                            aviso.Enviar();
                        }
                    }
                    
                    
                }
                catch (Exception a)
                {
                    throw new ExcecaoTratada("Erro ao enviar o aviso de emissão da nota fiscal. O processo de emissão continuará normalmente!" + Environment.NewLine + a.Message);
                }



            }
            catch (Exception a)
            {
                try
                {
                    LogClass.EscreverLog("EmissãoNfe-LimpaNotasRollback:" + idEmbarque + " - " + a.Message, ProjectConstants.Constants.CAMINHO_LOG_NF, true);   
                }
                catch { }

                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }


                string notDeleted = "";

                foreach (NfPrincipalClass t in nfs)
                {

                    try
                    {

                        if (command != null && command.Connection.State == ConnectionState.Open)
                        {
                            command.CommandText = "DELETE FROM nf_principal WHERE id_nf_principal = " + t.ID;
                            int affectedRows = command.ExecuteNonQuery();
                        }
                        else
                        {
                            notDeleted += "Nº. " + t.Numero.ToString() + "\r\n";
                        }
                    }
                    catch
                    {
                        if (t != null)
                        {
                            notDeleted += "Nº. " + t.Numero.ToString() + "\r\n";
                        }
                    }
                }

                foreach (string file in filesGenerated)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }

                string error = a.Message;
                if (notDeleted.Length > 0)
                {
                    error += "\r\nNão foi possível cancelar a emissão das notas fiscais abaixo pois a conexão com o banco de dados não está disponível. Solicite ao gestor do sistema que execute a rotina de manutenção do banco de dados.\r\n" +
                             notDeleted;
                }

                throw new Exception(error);



            }


        }

        private void baixaMateriaisProdutos(nfEmitida nfEmitida, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                //Verifica se o item é Não emite OP
                //Se ele for KB quem manda é o cadastro do KB
                //Caso contrário utilizar cadastro de produto
                foreach (OrganizaNfItemClass item in nfEmitida.infosNota.itens.Values)
                {


                    ProdutoClass Produto = ProdutoBaseClass.GetEntidade(Convert.ToInt32(item.IdProduto), this.Usuario, command.Connection);
                    ProdutoKClass produtoK = null;
                    if (!string.IsNullOrEmpty(item.IdProdutoK))
                    {
                        produtoK = ProdutoKClass.GetEntidade(Convert.ToInt32(item.IdProdutoK), Usuario, command.Connection);
                    }
                    bool EmiteOp;
                    double multiplicadorQuantidadeItemK = 1;
                    if (produtoK == null)
                    {
                        EmiteOp = Produto.EmiteOp;
                    }
                    else
                    {

                        EmiteOp = produtoK.EmiteOp;
                        if (produtoK.UtilizaDimensaoQuantidadeBaixa)
                        {
                            //Utiliza a dimensão do agrupador para indicar a quantidade de itens que devem ser baixados
                            //do estoque por unidade do agrupador
                            double tmp;

                            if (double.TryParse(produtoK.Dimensao, out tmp))
                            {
                                multiplicadorQuantidadeItemK = tmp;
                            }
                            else
                            {
                                throw new Exception("O item " + Produto.CodigoCliente + " possui um item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                            }

                        }
                        else
                        {
                            EmiteOp = Produto.EmiteOp;
                        }

                    }

                    if (EmiteOp)
                    {
                        //Item emite OP - baixa o item acabado 
                        if (produtoK!=null)
                        {
                            EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                produtoK,
                                item.Quantidade*-1,
                                "Baixa de Produto KB na Emissão da NF",
                                "NF Nº" + nfEmitida.nf.Numero + " linha " + item.IndiceLinha,
                                this.Usuario, false, ref command);
                        }
                        else
                        {
                            EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                Produto,
                                item.Quantidade*-1*multiplicadorQuantidadeItemK,
                                "Baixa de Produto na Emissão da NF",
                                "NF Nº" + nfEmitida.nf.Numero + " linha " + item.IndiceLinha,
                                this.Usuario, false, ref command, false);
                        }
                    }
                    else
                    {
                        //Item não emite OP 
                        //if (item.itemOriginalPedido)
                        //{
                        switch (Produto.TipoAquisicao)
                        {
                            case TipoAquisicao.Fabricado:

                                //Verifica se existe estoque do produto acabado, se existir ele tem precedencia sobre a baixa de materiais
                                double qtdBaixar = item.Quantidade*multiplicadorQuantidadeItemK;

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
                                                "Baixa de produto acabado na Emissão da NF",
                                                "NF Nº" + nfEmitida.nf.Numero + " linha " + item.IndiceLinha,
                                                this.Usuario, false, ref command, false);
                                            qtdBaixar = 0;
                                        }
                                        else
                                        {
                                            EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                                Produto,
                                                qtdEstoque*-1,
                                                "Baixa de produto acabado na Emissão da NF",
                                                "NF Nº" + nfEmitida.nf.Numero + " linha " + item.IndiceLinha,
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
                                                "Baixa de produto KB na Emissão da NF",
                                                "NF Nº" + nfEmitida.nf.Numero + " linha " + item.IndiceLinha,
                                                this.Usuario, false, ref command);
                                            qtdBaixar = 0;
                                        }
                                        else
                                        {
                                            EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProdutoK(
                                                produtoK,
                                                qtdEstoque*-1,
                                                "Baixa de produto KB na Emissão da NF",
                                                "NF Nº" + nfEmitida.nf.Numero + " linha " + item.IndiceLinha,
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
                                            "Baixa de Materiais na Emissão da NF",
                                            "NF Nº" + nfEmitida.nf.Numero + " linha " + item.IndiceLinha,
                                            this.Usuario, false, ref command, false);

                                    }
                                }
                                break;

                            case TipoAquisicao.Comprado:
                                EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(
                                    Produto,
                                    item.Quantidade*-1*multiplicadorQuantidadeItemK,
                                    "Baixa de Materiais na Emissão da NF",
                                    "NF Nº" + nfEmitida.nf.Numero + " linha " + item.IndiceLinha,
                                    this.Usuario, false, ref command, false);
                                break;


                        }
                        //}


                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a baixa de estoque dos produtos e materiais.\r\n" + e.Message);
            }
        }

        private Dictionary<organizaNfClassKey, organizaNfClass> dividirPedidosEmNotas(string idEmbarque, EmitenteClass emitenteCompletoPrimario, EmitenteClass emitenteCompletoSecundario, PisCofinsInfo pisCofinsDefaultPrimario, PisCofinsInfo pisCofinsDefaultSecundario)
        {

            try
            {
                Dictionary<organizaNfClassKey, organizaNfClass> toRet = new Dictionary<organizaNfClassKey, organizaNfClass>();


                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =

                    "SELECT  " +
                    "  public.pedido_item.id_pedido_item, " +
                    "  public.order_item_etiqueta.oie_order_number, " +
                    "  public.order_item_etiqueta.oie_order_pos, " +
                    "  public.order_item_etiqueta.oie_status_pedido, " +
                    "  public.order_item.changed_status, " +
                    "  public.order_item.status, " +
                    "  public.order_item.evolution_status, " +
                    "  public.order_item.order_number, " +
                    "  public.pedido_item.id_cliente, " +
                    "  public.order_item_etiqueta.id_externo_cliente_access, " +
                    "  public.order_item_etiqueta.oie_armazenagem_cliente, " +
                    "  public.order_item_etiqueta.oie_natureza_operacao, " +
                    "  public.order_item_etiqueta_conferencia.oic_quantidade_conferida, " +
                    "  public.order_item_etiqueta.oie_preco_unitario, " +
                    "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                    "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia, " +
                    "  public.pedido_item.pei_preco_unitario, " +
                    "  public.pedido_item.pei_status, " +
                    "  public.pedido_item.pei_armazenagem_cliente, " +
                    "  public.pedido_item.pei_quantidade, " +
                    "  public.cliente.cli_utilizar_controles_cliente, " +
                    "  public.familia_cliente.fac_tipo_especial, " +
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.order_item_etiqueta.id_produto, " +
                    "  public.order_item_etiqueta.id_produto_k, " +
                    "  public.order_item_etiqueta.oie_item_original_pedido, " +
                    "  public.embarque.id_transporte, " +
                    "  ped_pai.id_pedido_item as id_pedido_item_pai, " +
                    "  public.order_item_etiqueta.oie_rastreamento_material, " +
                    "  public.order_item_etiqueta.oie_responsavel_frete, " +
                    "  ped_pai.id_conta_bancaria, " +
                    "  ped_pai.id_centro_custo_lucro, " +
                    "  ped_pai.id_forma_pagamento, " +
                    "  cliente.id_conta_bancaria as cli_id_conta_bancaria, " +
                    "  cliente.id_centro_custo_lucro as cli_id_centro_custo_lucro, " +
                    "  cliente.id_forma_pagamento as cli_id_forma_pagamento, " +
                    "  ped_pai.pei_forma_frete, " +
                    "  ped_pai.pei_responsavel_frete, " +
                    "  order_item_etiqueta_conferencia.oic_volumes, " +
                    "  ped_pai.pei_observacao_nf, " +
                    "  ped_pai.pei_emissor_nfe, " +
                    "  order_item.buyer_plant_id, " +
                    "  pedido_item.id_tipo_pagamento, " +
                    "  pedido_item.ped_envio_terceiros," +
                    "  pedido_item.id_cliente_envio_terceiros," +
                    "  pedido_item.id_operacao_envio_terceiros," +
                    "  pedido_item.id_operacao_completa_envio_terceiros," +
                    "  cliente.id_tipo_pagamento as tipoPagamentoCliente, " +
                    "  cliente.cli_responsavel_frete, "+
                    "  produto.pro_responsavel_frete, "+
                    "  pedido_item.pei_desconto "+
                    "FROM " +
                    "  public.embarque " +
                    "  INNER JOIN public.order_item_etiqueta_conferencia ON public.order_item_etiqueta_conferencia.id_embarque = public.embarque.id_embarque " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                    "  INNER JOIN produto ON public.order_item_etiqueta.id_produto = produto.id_produto  "+
                    "  LEFT OUTER JOIN public.order_item ON (public.order_item_etiqueta.oie_order_number = public.order_item.order_number) " +
                    "  AND (public.order_item_etiqueta.oie_order_pos = public.order_item.order_pos) " +
                    "  LEFT OUTER JOIN public.pedido_item ON (public.order_item_etiqueta.id_pedido_item = public.pedido_item.id_pedido_item) " +
                    "  LEFT OUTER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                    "  LEFT OUTER JOIN public.familia_cliente ON (public.cliente.id_familia_cliente = public.familia_cliente.id_familia_cliente) " +
                    "  LEFT OUTER JOIN ( " +
                    "  	SELECT pei_numero, pei_posicao, id_cliente, id_pedido_item, id_conta_bancaria, id_centro_custo_lucro, id_forma_pagamento, pei_forma_frete, pei_responsavel_frete, pei_observacao_nf, pei_emissor_nfe FROM pedido_item WHERE pei_sub_linha = 0 " +
                    "  ) as ped_pai ON  " +
                    "  pedido_item.pei_numero = ped_pai.pei_numero  " +
                    "  AND pedido_item.pei_posicao = ped_pai.pei_posicao " +
                    "  AND pedido_item.id_cliente = ped_pai.id_cliente " +
                    "WHERE " +
                    "  public.order_item_etiqueta.oie_nota_fiscal = 1 AND " +
                    "  public.embarque.id_embarque =  " + idEmbarque + " " +
                    "ORDER BY " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    bool matAdicional = false;
                    string plantaCliente = "";

                    #region Tratatamento EASSA

                    if (read["fac_tipo_especial"] != DBNull.Value && Convert.ToInt16(read["fac_tipo_especial"]) == 1)
                    {
                        if (Convert.ToBoolean(Convert.ToInt16(read["cli_utilizar_controles_cliente"])))
                        {
                            if (read["changed_status"].ToString() == "2")
                            {
                                throw new Exception("Não é possível emitir a nota fiscal do embarque pois o pedido " + read["oie_order_number"] + "/" + read["oie_order_pos"] +
                                                    " possui uma solicitação de exclusão do cliente.\r\nConsulte o administrador do sistema.");
                            }

                            if (read["status"].ToString().Equals("ORDER_SENT") && read["oie_status_pedido"].ToString() != "R")
                            {
                                throw new Exception("Não é possível emitir a nota fiscal do embarque pois o pedido " + read["oie_order_number"] + "/" + read["oie_order_pos"] +
                                                    " consta como encerrado/cancelado no controle de pedidos do cliente.\r\nConsulte o administrador do sistema.");
                            }
                        }

                        if (read["evolution_status"].ToString() == "224")
                        {
                            matAdicional = true;
                        }

                        if (read["order_number"] != DBNull.Value && !read["order_number"].ToString().StartsWith("45") && !read["order_number"].ToString().StartsWith("47"))
                        {
                            matAdicional = true;
                        }

                        plantaCliente = read["buyer_plant_id"].ToString();
                    }

                    #endregion


                    /*if (read["changed_status"].ToString() == "1")
                {
                    throw new Exception("Não é possível emitir a nota fiscal do embarque pois o pedido " + read["oic_order_number"].ToString() + "/" + read["oic_order_pos"].ToString() + " possui uma solicitação de alteração do cliente.\r\nConsulte o administrador do sistema.");
                }*/

                    organizaNfClassKey tmpKey;
                    int cliEspecial = -1;
                    bool utilizaControleEspecialCliente = false;
                    double valorUnitarioPedido;
                    string cliNome;
                    int idPedidoItemLinha0 = -1;

                    #region Pedido Novo

                    if (read["pei_status"].ToString() != "0" && read["pei_status"].ToString() != "3")
                    {
                        throw new Exception("Não é possível emitir a nota fiscal do embarque pois o pedido " + read["oie_order_number"] + "/" + read["oie_order_pos"] + " não está em um status válido. Status atual: " + read["oie_status_pedido"] +
                                            "\r\nConsulte o administrador do sistema.");
                    }

                    if (read["fac_tipo_especial"] != DBNull.Value)
                    {
                        cliEspecial = Convert.ToInt16(read["fac_tipo_especial"]);
                    }

                    utilizaControleEspecialCliente = Convert.ToBoolean(Convert.ToInt16(read["cli_utilizar_controles_cliente"]));

                    valorUnitarioPedido = Convert.ToDouble(read["pei_preco_unitario"]);
                    cliNome = read["cli_nome_resumido"].ToString();

                    int idTransporte = -1;

                    if (read["id_transporte"] != DBNull.Value)
                    {
                        idTransporte = Convert.ToInt32(read["id_transporte"]);
                    }


                    EasiEmissorNFe emissor = (EasiEmissorNFe) Enum.ToObject(typeof(EasiEmissorNFe), Convert.ToInt16(read["pei_emissor_nfe"]));

                    long idUfEmissor;
                    PisCofinsInfo pisCofinsDefault;

                    switch (emissor)
                    {
                        case EasiEmissorNFe.Primario:
                            idUfEmissor = emitenteCompletoPrimario._cidade.Estado.ID;
                            pisCofinsDefault = pisCofinsDefaultPrimario;
                            break;
                        case EasiEmissorNFe.Secundario:
                            idUfEmissor = emitenteCompletoSecundario._cidade.Estado.ID;
                            pisCofinsDefault = pisCofinsDefaultSecundario;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    PedidoItemClass pedidoItem = PedidoItemClass.GetEntidade(Convert.ToInt64(read["id_pedido_item"]), Usuario, conn);


                    if (pedidoItem.Cliente.EstadoCob == null || pedidoItem.Cliente.CidadeCob == null)
                    {
                        throw new ExcecaoTratada("Cadastro do cliente sem cidade e/ou estado de cobrança. Por favor revise o cadastro do cliente antes de seguir com o faturamento");
                    }

                    CargaTributosDto dtoTributos = CargaTributosDto.CarregaTributos(pedidoItem, idUfEmissor, ref command, pisCofinsDefault);


                    bool devolverMp = dtoTributos.DevolucaoMaterial;

                    
                    idPedidoItemLinha0 = Convert.ToInt32(read["id_pedido_item_pai"]);
                    

                    int idContaBancaria = -1;
                    int idFormaPagamento = -1;
                    int idCentroCustoLucro = -1;
                    long idTipoPagamento = -1;

                    if (read["id_conta_bancaria"] != DBNull.Value)
                    {
                        idContaBancaria = Convert.ToInt32(read["id_conta_bancaria"]);
                    }
                    else
                    {
                        if (read["cli_id_conta_bancaria"] != DBNull.Value)
                        {
                            idContaBancaria = Convert.ToInt32(read["cli_id_conta_bancaria"]);
                        }
                        else
                        {
                            idContaBancaria = -1;
                        }
                    }

                    if (read["id_forma_pagamento"] != DBNull.Value)
                    {
                        idFormaPagamento = Convert.ToInt32(read["id_forma_pagamento"]);
                    }
                    else
                    {
                        if (read["cli_id_forma_pagamento"] != DBNull.Value)
                        {
                            idFormaPagamento = Convert.ToInt32(read["cli_id_forma_pagamento"]);
                        }
                        else
                        {
                            idFormaPagamento = -1;
                        }
                    }

                    if (read["id_centro_custo_lucro"] != DBNull.Value)
                    {
                        idCentroCustoLucro = Convert.ToInt32(read["id_centro_custo_lucro"]);
                    }
                    else
                    {
                        if (read["cli_id_centro_custo_lucro"] != DBNull.Value)
                        {
                            idCentroCustoLucro = Convert.ToInt32(read["cli_id_centro_custo_lucro"]);
                        }
                        else
                        {
                            idCentroCustoLucro = -1;
                        }
                    }

                    if (read["id_tipo_pagamento"] != DBNull.Value)
                    {
                        idTipoPagamento = Convert.ToInt64(read["id_tipo_pagamento"]);
                    }
                    else
                    {
                        if (read["tipoPagamentoCliente"] != DBNull.Value)
                        {
                            idTipoPagamento = Convert.ToInt64(read["tipoPagamentoCliente"]);
                        }
                        else
                        {
                            idTipoPagamento = -1;
                        }
                    }



                    string naturezaOp = dtoTributos.NaturezaOperacao;

                    if (dtoTributos.EntregaFutura)
                    {
                        naturezaOp = dtoTributos.EntregaFuturaNaturezaOperacaoRemessa;

                    }


                    bool envioTerceiros = Convert.ToBoolean(Convert.ToInt16(read["ped_envio_terceiros"]));
                    long idClienteEnvioTerceiros = -1;
                    long idOperacaoEnvioTerceiros = -1;
                    long idOperacaoCompletaEnvioTerceiros = -1;
                    if (envioTerceiros)
                    {
                        idClienteEnvioTerceiros = Convert.ToInt64(read["id_cliente_envio_terceiros"]);
                        if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                        {
                            idOperacaoCompletaEnvioTerceiros = Convert.ToInt64(read["id_operacao_completa_envio_terceiros"]);
                        }
                        else
                        {
                            idOperacaoEnvioTerceiros = Convert.ToInt64(read["id_operacao_envio_terceiros"]);
                        }
                    }



                    IWTNF.Entidades.Base.ModalidadeFrete? tipoFrete = null;
                    if (read["pei_responsavel_frete"] != DBNull.Value)
                    {
                        tipoFrete = (ModalidadeFrete) Enum.ToObject(typeof(ModalidadeFrete), read["pei_responsavel_frete"]);
                    }
                    else
                    {
                        if (read["pro_responsavel_frete"] != DBNull.Value)
                        {
                            tipoFrete = (ModalidadeFrete) Enum.ToObject(typeof(ModalidadeFrete), read["pro_responsavel_frete"]);
                        }
                        else
                        {
                            tipoFrete = (ModalidadeFrete) Enum.ToObject(typeof(ModalidadeFrete), read["cli_responsavel_frete"]);

                        }
                    }


                    bool devolverMaterialClienteNfSeparada = false;
                    string devolverMaterialClienteNfSeparadaNaturezaOp = "";

                    PedidoItemClass pedidoLinhaPai = PedidoItemClass.GetEntidade(idPedidoItemLinha0, Usuario, conn);

                    if (devolverMp && idPedidoItemLinha0 != -1)
                    {
                        if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                        {
                            devolverMaterialClienteNfSeparada = pedidoLinhaPai.OperacaoCompleta.DevolucaoMaterialSeparada;
                            devolverMaterialClienteNfSeparadaNaturezaOp = pedidoLinhaPai.OperacaoCompleta.DevolucaoMaterialSeparadaNatuezaOperacao;
                        }
                        else
                        {
                            devolverMaterialClienteNfSeparada = pedidoLinhaPai.Operacao.DevolucaoMaterialSeparada;
                            devolverMaterialClienteNfSeparadaNaturezaOp = pedidoLinhaPai.Operacao.DevolucaoMaterialSeparadaNatuezaOperacao;
                        }

                    }


                    bool descontarImcsBcPis;
                    bool descontarImcsBcCofins;
                    if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                    {
                        descontarImcsBcPis = pedidoLinhaPai.OperacaoCompleta.PisDescontarIcmsBc;
                        descontarImcsBcCofins = pedidoLinhaPai.OperacaoCompleta.CofinsDescontarIcmsBc;
                    }
                    else
                    {
                        descontarImcsBcPis = pedidoLinhaPai.Operacao.PisDescontarIcmsBc;
                        descontarImcsBcCofins = pedidoLinhaPai.Operacao.CofinsDescontarIcmsBc;
                    }


                    
                    tmpKey = new organizaNfClassKey(
                        true,
                        "",
                        Convert.ToInt32(read["id_cliente"]),
                        read["pei_armazenagem_cliente"].ToString(),
                        naturezaOp,
                        matAdicional,
                        idTransporte,
                        devolverMp,
                        (ModalidadeFrete)
                        tipoFrete,
                        idCentroCustoLucro,
                        idContaBancaria,
                        idFormaPagamento,
                        (FormaFretePedido) Enum.ToObject(typeof(FormaFretePedido), read["pei_forma_frete"]),
                        dtoTributos.ConsumidorFinal,
                        dtoTributos.PresencaConsumidor,
                        dtoTributos.GerarContasReceber,
                        emissor,
                        plantaCliente,
                        dtoTributos.IcmsSomaFreteBc,
                        dtoTributos.IpiSomaFreteBc,
                        idTipoPagamento,
                        envioTerceiros,
                        idClienteEnvioTerceiros,
                        idOperacaoEnvioTerceiros,
                        idOperacaoCompletaEnvioTerceiros,
                        devolverMaterialClienteNfSeparada,
                        devolverMaterialClienteNfSeparadaNaturezaOp,
                        descontarImcsBcPis,
                        descontarImcsBcCofins
                    );

                    #endregion


                    if (!toRet.ContainsKey(tmpKey))
                    {
                        organizaNfClass nf = new organizaNfClass(
                            tmpKey.idClienteAccess,
                            tmpKey.armazenagemCliente,
                            tmpKey.naturezaOperacao,
                            tmpKey.matAdicional,
                            tmpKey.idCliente,
                            cliEspecial,
                            utilizaControleEspecialCliente,
                            cliNome,
                            tmpKey.pedidoNovo,
                            tmpKey.idTransporte,
                            tmpKey.devolverMateriaisCliente,
                            tmpKey.responsavelFrete,
                            tmpKey.idCentroCustoLucro,
                            tmpKey.idContaBancaria,
                            tmpKey.idFormaPagamento,
                            tmpKey.IdTipoPagamento,
                            tmpKey.FormaFrete,
                            tmpKey.ConsumidorFinal,
                            tmpKey.PresencaComprador,
                            tmpKey.GerarContasReceber,
                            tmpKey.EmissorNfe,
                            tmpKey.SomaFreteBcIcms,
                            tmpKey.SomaFreteBcIpi,
                            dtoTributos,
                            tmpKey.EnvioTerceiros,
                            tmpKey.IdClienteEnvioTerceiros,
                            tmpKey.IdOperacaoEnvioTerceiros,
                            tmpKey.IdOperacaoCompletaEnvioTerceiros,
                            tmpKey.DevolverMaterialClienteNfSeparada,
                            tmpKey.DevolverMaterialClienteNfSeparadaNaturezaOp,
                            tmpKey.DescontarImcsBcPis,
                            tmpKey.DescontarImcsBcCofins
                            );

                        toRet.Add(tmpKey, nf);

                    }

                    toRet[tmpKey].IdsPedidoItemLinha0.Add(idPedidoItemLinha0);

                    OrganizaNfSubItemKey chaveItem = new OrganizaNfSubItemKey(
                        Convert.ToInt32(read["id_order_item_etiqueta"]),
                        read["oie_order_number"].ToString(),
                        read["oie_order_pos"].ToString(),
                        tmpKey.idCliente,
                        tmpKey.pedidoNovo,
                        read["id_pedido_item"].ToString(),
                        read["id_produto"].ToString(),
                        read["id_produto_k"].ToString(),
                        Convert.ToBoolean(Convert.ToInt16(read["oie_item_original_pedido"])),
                        read["pei_observacao_nf"].ToString(),
                        valorUnitarioPedido,
                        Convert.ToDouble(read["pei_quantidade"]),
                        Convert.ToDouble(read["pei_desconto"])

                    );


                    if (!toRet[tmpKey].itens.ContainsKey(chaveItem))
                    {
                        toRet[tmpKey].itens.Add(chaveItem, new OrganizaNfItemClass(chaveItem, dtoTributos));
                    }


                    toRet[tmpKey].itens[chaveItem].SubItens.Add(new OrganizaNfSubItem(
                        Convert.ToDouble(read["oic_quantidade_conferida"]),
                        Convert.ToInt32(read["oic_volumes"]),
                        Convert.ToInt32(read["id_order_item_etiqueta_conferencia"])
                    ));


                }

                read.Close();


                return toRet;
            }
            catch (Exception e)
            {

                throw new Exception("Erro ao dividir os pedidos em notas.\r\n" + e.Message, e);

            }
        }

        private bool EmitirNF(string idEmbarque, out List<NfPrincipalClass> nfs, out List<string> filesGenerated, out List<nfEmitida> notasEmitidas,
            out List<ContaReceberClass> contasReceber, IObservacaoCustomizada observacaoCustomizada, ref IWTPostgreNpgsqlCommand command, bool semVisualizacao)
        {

            TipoEmissaoNFe tipoEmissaoNFe = (TipoEmissaoNFe) Enum.ToObject(typeof (TipoEmissaoNFe), int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)));
            InclusaoPedidoNota inclusaoPedidoNota = (InclusaoPedidoNota)Enum.ToObject(typeof(InclusaoPedidoNota), int.Parse(IWTConfiguration.Conf.getConf(Constants.NF_INCLUIR_NUMERO_PEDIDO_NF)));

            Ambiente AmbienteEmissaoNFe = Ambiente.Producao;
            if (IWTConfiguration.Conf.getBoolConf(Constants.AMBIENTE_EMISSAO_NFE_HOMOLOGACAO))
            {
                AmbienteEmissaoNFe = Ambiente.Homologacao;
            }


            filesGenerated = new List<string>();
            nfs = new List<NfPrincipalClass>();
            notasEmitidas = new List<nfEmitida>();
            contasReceber = new List<ContaReceberClass>();
            string cliObsPadraoNfe = "";
            try
            {
                EmitenteClass emitenteCompletoPrimario;
                PisCofinsInfo pisCofinsPrimario;

                NfEmitenteClass emitentePrimario = NotaFiscalFuncoesAuxiliares.CarregaEmitente(conn, out emitenteCompletoPrimario, EasiEmissorNFe.Primario, out pisCofinsPrimario);

                EmitenteClass emitenteCompletoSecundario;
                PisCofinsInfo pisCofinsSecundario;

                NfEmitenteClass emitenteSecundario = NotaFiscalFuncoesAuxiliares.CarregaEmitente(conn, out emitenteCompletoSecundario, EasiEmissorNFe.Secundario, out pisCofinsSecundario);


                PisCofinsInfo pisCofinsDefaultPrimario = new PisCofinsInfo(
                    emitenteCompletoPrimario.PisCst,
                    Convert.ToInt16(emitenteCompletoPrimario.PisImpostoRetido),
                    emitenteCompletoPrimario.PisModalidade,
                    emitenteCompletoPrimario.PisAliquota,

                    emitenteCompletoPrimario.CofinsCst,
                    Convert.ToInt16(emitenteCompletoPrimario.CofinsImpostoRetido),
                    emitenteCompletoPrimario.CofinsModalidade,
                    emitenteCompletoPrimario.CofinsAliquota
                );

                PisCofinsInfo pisCofinsDefaultSecundario = new PisCofinsInfo(
                    emitenteCompletoSecundario.PisCst,
                    Convert.ToInt16(emitenteCompletoSecundario.PisImpostoRetido),
                    emitenteCompletoSecundario.PisModalidade,
                    emitenteCompletoSecundario.PisAliquota,

                    emitenteCompletoSecundario.CofinsCst,
                    Convert.ToInt16(emitenteCompletoSecundario.CofinsImpostoRetido),
                    emitenteCompletoSecundario.CofinsModalidade,
                    emitenteCompletoSecundario.CofinsAliquota
                );


                Dictionary<organizaNfClassKey, organizaNfClass> notasAEmitir = this.dividirPedidosEmNotas(idEmbarque, emitenteCompletoPrimario, emitenteCompletoSecundario, pisCofinsDefaultPrimario, pisCofinsDefaultSecundario);

                if (!semVisualizacao)
                {
                    if (notasAEmitir.Count > 1)
                    {
                        if (MessageBox.Show(null, "Foram selecionados pedidos que devem gerar " + notasAEmitir.Count.ToString() + " notas diferentes, você deseja continuar?", "Emissão de NF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                            DialogResult.No)
                        {
                            return false;
                        }
                    }
                }



                List<organizaNfClass> listaNFs = new List<organizaNfClass>(notasAEmitir.Values);
                // ReSharper disable ForCanBeConvertedToForeach
                for (int index = 0; index < listaNFs.Count; index++)
                    // ReSharper restore ForCanBeConvertedToForeach
                {
                    organizaNfClass nfTmp = listaNFs[index];

                    NfEmitenteClass emitente;
                    NfEmitenteEnderecoClass emitenteEndereco;
                    EmitenteClass emitenteCompleto;
                    PisCofinsInfo pisCofinsDefault;
                    switch (nfTmp.EmissorNFe)
                    {
                        case EasiEmissorNFe.Primario:
                            emitente = emitentePrimario;
                            emitenteCompleto = emitenteCompletoPrimario;
                            pisCofinsDefault = pisCofinsDefaultPrimario;
                            break;
                        case EasiEmissorNFe.Secundario:
                            emitente = emitenteSecundario;
                            emitenteCompleto = emitenteCompletoSecundario;
                            pisCofinsDefault = pisCofinsDefaultSecundario;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    emitenteEndereco = emitente.NfEmitenteEndereco;

      


                    #region Dados Principais NF

                    NfPrincipalClass nf;
                    try
                    {
                        int numeroNota;
                        int serie = 1;

                        numeroNota = NFeOperacoes.getProximoNumeroNf(emitente.CnpjCpf, "55", command, AmbienteEmissaoNFe == Ambiente.Homologacao ? TAmb.Homologacao : TAmb.Producao, out serie);


                        FormaPagamento formaPagto = FormaPagamento.AVista;
                        if (emitenteCompleto.DiasPagamentoPadrao > 0)
                        {
                            formaPagto = FormaPagamento.APrazo;
                        }

                        Processo procEmi;
                        procEmi = Processo.AplicativoContribuinte;
                        nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            Numero = numeroNota,
                            NaturezaOperacao = nfTmp.naturezaOperacao,
                            Serie = serie,
                            FormaPagamento = formaPagto,
                            ModeloDocFiscal = "55",
                            DataEmissao = Configurations.DataIndependenteClass.GetData(),
                            DataSaidaEntrada = Configurations.DataIndependenteClass.GetData(),
                            Tipo = TipoNota.Saida,
                            CodMunicipioFatoGerador = emitenteEndereco.CodMunicipio,
                            FormatoImpressao = FormatoImpressao.Retrato,
                            FormaEmissao = FormaEmissaoNFe.Normal,
                            IdentificacaoAmbiente = AmbienteEmissaoNFe == Ambiente.Producao ? 1 : 2,
                            FinalidadeEmissao = Finalidade.Normal,
                            ProcessoEmissao = procEmi,
                            VersaoProcessoEmissao = emitenteCompleto.VersaoEmissorNFe,
                            Observacoes = "",
                            TipoEmitente = "P",
                            Situacao = "N",
                            ConsumidorFinal = nfTmp.ConsumidorFinal,
                            PresencaComprador = nfTmp.PresencaComprador,
                            EnviarNfeReceita = true
                        };

                        nf.Homologacao = AmbienteEmissaoNFe == Ambiente.Homologacao;

                        nf.NfAtributo = new NfAtributoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            VersaoLayout = "3.10",
                            IdNfe = "NFe"
                        };
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os campos principais da NF.\r\n" + e.Message);
                    }

                    try
                    {
                        nf.NfEmitente = new NfEmitenteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            Razao = emitente.Razao,
                            NomeFantasia = emitente.NomeFantasia,
                            Ie = emitente.Ie,
                            IeSt = emitente.IeSt,
                            Im = emitente.Im,
                            Cnae = emitente.Cnae,
                            CnpjCpf = emitente.CnpjCpf,
                            Crt = emitente.Crt,
                            AliquotaSimplesServico = 0
                        };


                        nf.NfEmitente.NfEmitenteEndereco = new NfEmitenteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            NfEmitente = nf.NfEmitente,
                            Logradouro = emitenteEndereco.Logradouro,
                            Numero = emitenteEndereco.Numero,
                            Complemento = emitenteEndereco.Complemento,
                            Bairro = emitenteEndereco.Bairro,
                            CodMunicipio = emitenteEndereco.CodMunicipio,
                            NomeMunicipio = emitenteEndereco.NomeMunicipio,
                            SiglaUf = emitenteEndereco.SiglaUf,
                            Cep = emitenteEndereco.Cep,
                            CodPais = emitenteEndereco.CodPais,
                            NomePais = emitenteEndereco.NomePais,
                            Telefone = emitenteEndereco.Telefone
                        };
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados do Emitente da NF.\r\n" + e.Message);
                    }


                    try
                    {
                        if (emitenteCompleto.AutorizadosDownloadNf != null && emitenteCompleto.AutorizadosDownloadNf.Count > 0)
                        {
                            foreach (string autorizado in emitenteCompleto.AutorizadosDownloadNf)
                            {
                                nf.CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Add(new NfPrincipalAutorizacaoXmlClass(Usuario, conn)
                                {
                                    Documento = autorizado.Replace("/", "").Replace(".", "").Replace("-", ""),
                                    NfPrincipal = nf
                                });
                            }

                        }


                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados do Emitente da NF.\r\n" + e.Message);
                    }


                    #endregion

                    #region Cliente


                    ClienteClass cliente = null;
                    try
                    {
                        cliente = ClienteClass.GetEntidade(nfTmp.idCliente, Usuario, conn);

                        if (cliente == null)
                        {
                            throw new Exception("Cliente não cadastrado!");
                        }



                        if (cliente.EstadoCob == null || string.IsNullOrWhiteSpace(cliente.EstadoCob.Sigla))
                        {
                            throw new Exception("Estado do endereço principal do cliente é inválido.");
                        }

                        if (cliente.CidadeCob == null || cliente.CidadeCob.CodigoIbge == 0)
                        {
                            throw new Exception("Municipio do endereço principal do cliente é inválido.");
                        }

                        if (!semVisualizacao)
                        {
                            if (!string.IsNullOrWhiteSpace(cliente.AvisoFaturamento))
                            {
                                ScrollableMessageBox messageBox = new ScrollableMessageBox(null, cliente.AvisoFaturamento, "Aviso de Faturamento - " + cliente.Nome, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                messageBox.ShowDialog();
                            }
                        }

                        IWTNFIndicadorIE? indicadorIE = null;
                        switch (cliente.IndicadorIe)
                        {
                            case BibliotecaEntidades.Base.IWTNFIndicadorIE.ContribuinteICMS:
                                indicadorIE = IWTNFIndicadorIE.ContribuinteICMS;
                                break;
                            case BibliotecaEntidades.Base.IWTNFIndicadorIE.Isento:
                                indicadorIE = IWTNFIndicadorIE.Isento;
                                break;
                            case BibliotecaEntidades.Base.IWTNFIndicadorIE.NaoContribuinte:
                                indicadorIE = IWTNFIndicadorIE.NaoContribuinte;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }



                        nf.NfCliente = new NfClienteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            Razao = cliente.Nome,
                            NomeFantasia = cliente.Nome,
                            Ie = cliente.Ie?.Trim().Replace(".", "").Replace("/", "").Replace("-", ""),
                            CnpjCpf = cliente.Cnpj?.Replace(".", "").Replace("/", "").Replace("-", ""),
                            Isuf = cliente.InscricaoSuframa,
                            Email = cliente.Email.ToString(),
                            IndicadorIe = indicadorIE,
                        };

                        string cepCliente = cliente.CepCob.Trim().Replace("-", "");
                        if (cepCliente.Length != 8)
                        {
                            throw new ExcecaoTratada("O cep de cobrança do cliente é inválido: " + cliente.CepCob);
                        }

                        if (cliente.CidadeCob == null)
                        {
                            throw new ExcecaoTratada("O cliente não possui cidade de cobrança definda");
                        }

                        if (cliente.EstadoCob == null)
                        {
                            throw new ExcecaoTratada("O cliente não possui estado de cobrança defindo");
                        }

                        if (!cliente.CodigoPaisCob.HasValue)
                        {
                            throw new ExcecaoTratada("O cliente não possui código do país de cobrança defindo");
                        }

                        nf.NfCliente.NfClienteEndereco = new NfClienteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            Logradouro = cliente.EnderecoCob.ToString(),
                            Numero = cliente.EnderecoNumeroCob.ToString(),
                            Complemento = cliente.ComplementoCob.ToString(),
                            Bairro = cliente.BairroCob.ToString(),
                            CodMunicipio = cliente.CidadeCob.CodigoIbge,
                            NomeMunicipio = cliente.CidadeCob.Nome.ToString(),
                            SiglaUf = cliente.EstadoCob.Sigla.ToString(),
                            Cep = cepCliente,
                            CodPais = cliente.CodigoPaisCob.Value,
                            NomePais = cliente.PaisCob.ToString(),
                            Telefone = cliente.Fone1.ToString().Replace("(", "").Trim().Replace(")", "").Replace("-", "").Replace(" ", "")

                        };

                        cliObsPadraoNfe = cliente.ObservacaoPadraoNfe;



                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados do Cliente da NF.\r\n" + e.Message);
                    }

                    #endregion

                    #region Itens do Pedido

                    int totalVolumes = 0;

                    OrganizaNfItemClass itemExt = null;
                    int numeroLinhaNF = 1;
                    double pesoTotalItens = 0;

                    string obsEntregaFutura = "";
                    List<string> notasReferenciadas = new List<string>();


                    List<string> observacoesAdd = new List<string>();
                    List<string> observacoesFiscoAdd = new List<string>();


                    try
                    {
                        nf.CollectionNfItemClassNfPrincipal = new BindingList<NfItemClass>();



                        foreach (OrganizaNfItemClass item in nfTmp.itens.Values)
                        {
                            if (item.Quantidade <= 0)
                            {
                                continue;
                            }

                            totalVolumes += item.Volumes;
                            itemExt = item;

                            OrderItemEtiquetaClass itemPedidoConfigurado = OrderItemEtiquetaClass.GetEntidade(item.Id, Usuario, conn);
                            PedidoItemClass itemPedido = itemPedidoConfigurado.PedidoItem;

                            CargaTributosDto tributos = item.DtoTributos;
                            DadosFiscaisItemDto dadosFiscaisItem = DadosFiscaisItemDto.GetDadosFiscaisProduto(itemPedidoConfigurado.Produto);

                            double precoTotal;
                            EasiValidaPrecos validaPreco;

                            string descricao = "";
                            if (inclusaoPedidoNota == InclusaoPedidoNota.DescricaoItens)
                            {
                                descricao = item.Pedido + " - ";
                            }



                            string codItem;
                            NcmClass ncm;
                            int CFOP;
                            string codigoBeneficioFiscal = null;


                            BibliotecaEntidades.Base.IncidenciaImposto incideIcms = IncidenciaImposto.Incide;
                            string cstSuspensaoIcms = null;
                            int csoSuspensaoIcms = 0;
                            IncidenciaImposto incideIPI = IncidenciaImposto.Incide;
                            string cstSuspensaoIPI = null;
                            IncidenciaImposto incidePIS = IncidenciaImposto.Incide;
                            string cstSuspensaoPIS = null;
                            IncidenciaImposto incideCofins = IncidenciaImposto.Incide;
                            string cstSuspensaoCofins = null;

                         
                                #region Busca dados Pedido Novo

                                validaPreco = tributos.ValidaPrecos;



                                //Descrição do Item
                                if (itemPedido.ProdutoDescricaoCliente.Length == 0)
                                {
                                    descricao += itemPedidoConfigurado.Descricao;
                                }
                                else
                                {
                                    descricao += itemPedido.ProdutoDescricaoCliente;
                                }

                                codItem = itemPedido.ProdutoCodigoCliente;
                                if (codItem.Length == 0)
                                {
                                    codItem = itemPedidoConfigurado.CodigoItem;
                                }


                                //CFOP
                                bool entregaFutura = tributos.EntregaFutura;
                                if (entregaFutura)
                                {
                                    CFOP = tributos.EntregaFuturaCfopRemessa.Value;

                                }
                                else
                                {
                                    CFOP = tributos.Cfop;
                                }
                         

                                ncm = itemPedido.Ncm;
                                
                         

                                //Obs Entrega Futura + Nfs Relacionadas
                                if (entregaFutura)
                                {

                                    PedidoItemClass pedidoPai = itemPedidoConfigurado.PedidoItemLinhaPrincipalPedido;

                                    if (!pedidoPai.FaturamentoAntecipadoRealizado)
                                    {
                                        throw new ExcecaoTratada("Não é possível realizar a entrega de um pedido de faturamento antecipado sem que a primeira nota tenha sido emitida.");
                                    }

                                    obsEntregaFutura += "Ref. Nota Fiscal de Simples Faturamento Nº " + pedidoPai.NfPrincipalFaturamentoAntecipado.Numero + " de " +
                                                        pedidoPai.NfPrincipalFaturamentoAntecipado.DataEmissao.ToString("dd/MM/yyyy") +
                                                        ", valor total de R$ " + pedidoPai.NfPrincipalFaturamentoAntecipado.NfTotais.ValorTotalNf.ToString("F2", CultureInfo.GetCultureInfo("pt-Br")) + ". ";

                                    if (tipoEmissaoNFe == TipoEmissaoNFe.EASI)
                                    {
                                        NfeCompletoNotaClass nfeCompleto = (NfeCompletoNotaClass) new NfeCompletoNotaClass(Usuario, conn).Search(
                                            new List<SearchParameterClass>()
                                            {
                                                new SearchParameterClass("NfPrincipal", pedidoPai.NfPrincipalFaturamentoAntecipado)
                                            }).FirstOrDefault();

                                        notasReferenciadas.Add(nfeCompleto.Chave);
                                    }


                                }


                                incideIcms = tributos.IcmsIncide;
                                if (incideIcms == IncidenciaImposto.Suspenso)
                                {
                                    cstSuspensaoIcms = tributos.IcmsCst;
                                    if (cstSuspensaoIcms == "300" || cstSuspensaoIcms == "400")
                                    {
                                        csoSuspensaoIcms = Convert.ToInt32(cstSuspensaoIcms);
                                        cstSuspensaoIcms = "SN";
                                    }
                                }

                                if (!entregaFutura)
                                {

                                    incideIPI = tributos.IpiIncide;
                                    if (incideIPI == IncidenciaImposto.Suspenso)
                                    {
                                        cstSuspensaoIPI = tributos.IpiCst;
                                    }
                                }
                                else
                                {
                                    incideIPI = IncidenciaImposto.NaoIncide;
                                }


                                incideCofins = tributos.CofinsIncide;
                                if (incideCofins == IncidenciaImposto.Suspenso)
                                {
                                    cstSuspensaoCofins = tributos.CofinsCst;
                                }

                                incidePIS = tributos.PisIncide;
                                if (incidePIS == IncidenciaImposto.Suspenso)
                                {
                                    cstSuspensaoPIS = tributos.PisCst;
                                }




                                #endregion
                            
                          

                            #region Validação de Preço

                            if (validaPreco != EasiValidaPrecos.NaoValida)
                            {
                                //Conferencia Preços 
                                precoTotal = item.ValorTotal;
                                bool precoTabelaEncontrado = false;

                                //busca o preço variável
                                IWTPostgreNpgsqlCommand command2 = this.conn.CreateCommand();
                                double precoTmp = 0;
                                command2.CommandText =
                                    "SELECT  tpv_preco FROM tabela_preco_item_variavel WHERE tpv_order_number LIKE '" + itemPedidoConfigurado.OrderNumber + "' AND tpv_pos=" + itemPedidoConfigurado.OrderPos + " AND id_cliente = " + itemPedidoConfigurado.Cliente.ID + ";";
                                IWTPostgreNpgsqlDataReader read2 = command2.ExecuteReader();
                                if (read2.HasRows)
                                {
                                    read2.Read();
                                    precoTmp += Convert.ToDouble(read2["tpv_preco"]);
                                    precoTabelaEncontrado = true;
                                }

                                read2.Close();

                                if (!precoTabelaEncontrado)
                                {
                                    string mensagem = "Pedido não encontrado na tabela de preços.\r\nPedido: " +
                                                      item.Pedido + "\r\nCódigo do Item: " + itemPedidoConfigurado.Produto.Codigo;

                                    switch (validaPreco)
                                    {
                                        case EasiValidaPrecos.ValidaComBloqueio:
                                            throw new Exception(mensagem);
                                        case EasiValidaPrecos.ValidaSemBloqueio:
                                            MessageBox.Show(mensagem, "Aviso da Validação de Preços", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            break;
                                        default:
                                            throw new ArgumentOutOfRangeException();
                                    }
                                    
                                }

                                //Traz o preço da tabela para a quantidade que está sendo faturada
                                if (Math.Abs(item.Quantidade - item.QtdTotalPedido) > 0.000001)
                                {
                                    precoTmp = (precoTmp / item.QtdTotalPedido) * item.Quantidade;
                                }


                                if (precoTotal <= (precoTmp + 0.1) && precoTotal >= (precoTmp - 0.1))
                                {
                                }
                                else
                                {
                                    string mensagem = "Preço inconsistente no pedido e na Tabela de Preços " +
                                                      item.Pedido + ".\r\nPreço Tabela: R$ " +
                                                      precoTmp.ToString("F2", CultureInfo.CurrentCulture) +
                                                      " \rPreço Pedido: R$ " +
                                                      item.ValorTotal.ToString("F2", CultureInfo.CurrentCulture);

                                    switch (validaPreco)
                                    {
                                        case EasiValidaPrecos.ValidaComBloqueio:
                                            throw new Exception(mensagem);
                                        case EasiValidaPrecos.ValidaSemBloqueio:
                                            MessageBox.Show(mensagem, "Aviso da Validação de Preços", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            break;
                                        default:
                                            throw new ArgumentOutOfRangeException();
                                    }

                                }

                                if (nfTmp.cliEspecial == 1 && nfTmp.utilizaControleEspecialCliente)
                                {
                                    //Valida preço SO
                                    command2.CommandText =
                                        "SELECT  price_per_unit FROM order_item WHERE order_number LIKE '" +
                                        itemPedidoConfigurado.OrderNumber + "' AND order_pos=" + itemPedidoConfigurado.OrderPos + ";";
                                    read2 = command2.ExecuteReader();
                                    double precoSO = 0;
                                    if (read2.HasRows)
                                    {
                                        read2.Read();
                                        precoSO += Convert.ToDouble(read2["price_per_unit"]);
                                    }

                                    read2.Close();

                                    precoSO = precoSO * item.Quantidade;
                                    if (precoTotal <= (precoSO + 0.1) && precoTotal >= (precoSO - 0.1))
                                    {
                                    }
                                    else
                                    {
                                        string mensagem = "Preço inconsistente no pedido e no pedido do cliente " +
                                                          item.Pedido + ".\r\nPreço Cliente: R$ " +
                                                          precoSO.ToString("F2", CultureInfo.CurrentCulture) +
                                                          " \rPreço Pedido: R$ " +
                                                          item.ValorTotal.ToString("F2", CultureInfo.CurrentCulture);

                                        switch (validaPreco)
                                        {
                                            case EasiValidaPrecos.ValidaComBloqueio:
                                                throw new Exception(mensagem);
                                            case EasiValidaPrecos.ValidaSemBloqueio:
                                                MessageBox.Show(mensagem, "Aviso da Validação de Preços", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                break;
                                            default:
                                                throw new ArgumentOutOfRangeException();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                precoTotal = item.ValorTotal;
                            }

                            #endregion

                            if (!itemPedidoConfigurado.Produto.PermiteVenda)
                            {
                                throw new ExcecaoTratada("Não é possível faturar o pedido " + item.Pedido + " pois o item " + itemPedidoConfigurado.Produto.Codigo + " não possui autorização de venda");
                            }

                            //carrega o frete
                            double valorFrete = 0;
                            if (nfTmp.FormaFrete == FormaFretePedido.RateadoItens)
                            {
                                double valorFreteTotal = itemPedido.Frete;
                                precoTotal = precoTotal + valorFreteTotal;
                                item.FreteRateado = valorFreteTotal / item.Quantidade;
                                valorFrete = 0;
                            }
                            else
                            {
                                valorFrete = itemPedido.Frete;
                            }


                            if (descricao.Length > 60)
                            {
                                descricao = descricao.Substring(0, 60);
                            }

                            if (ncm == null)
                            {
                                ncm = dadosFiscaisItem.NCM;
                                
                            }
                            
                            
                            if (ncm != null)
                            {
                                NcmBeneficioFiscalClass beneficioFiscal = ncm.CollectionNcmBeneficioFiscalClassNcm.FirstOrDefault(a => a.Estado == cliente.EstadoCob && a.Cfop == CFOP);
                                codigoBeneficioFiscal = beneficioFiscal?.CodigoBeneficioFiscal;
                            }

                            


                            pesoTotalItens += (itemPedidoConfigurado.Produto.PesoUnitario) * item.Quantidade;


                            double valorDesconto = Math.Round((item.Desconto * item.Quantidade) / item.QtdTotalPedido, 3);


                            nf.CollectionNfItemClassNfPrincipal.Add(new NfItemClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                            {
                                NfPrincipal = nf,
                                NumeroItem = numeroLinhaNF,
                                Cfop = CFOP,
                            });

                            nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto =
                                new NfProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                    Codigo = codItem,
                                    Descricao = descricao,
                                    Gtin = dadosFiscaisItem.GTIN,
                                    Ncm = ncm.Codigo,
                                    Cest = ncm.Cest,
                                    CodigoBeneficio = codigoBeneficioFiscal,
                                    Extipi = dadosFiscaisItem.exTIPI,
                                    Genero = dadosFiscaisItem.Genero,
                                    Unidade = itemPedidoConfigurado.Produto.UnidadeMedida?.Abreviada,
                                    ValorUnitario = item.ValorUnitario,
                                    GtimUnidadeTrinutacao = dadosFiscaisItem.GTIN,
                                    UnidadeTributacao = itemPedidoConfigurado.Produto.UnidadeMedida?.Abreviada,
                                    ValorUnitarioTrinutacao = item.ValorUnitario,
                                    QuantidadeTributavel = item.Quantidade,
                                    ValorTotalTributavel = Math.Round(item.ValorTotal, 2),
                                    ValorFrete = valorFrete,
                                    ValorDesconto = valorDesconto,
                                    ValorSeguro = 0,
                                    Quantidade = item.Quantidade,
                                    Xped = item.Oc,
                                    NumeroItemPedido = int.Parse(item.Pos),
                                    
                                };

                            string cstCsosn = "";
                            switch (incideIcms)
                            {
                                case IncidenciaImposto.Incide:
                                    cstCsosn = tributos.IcmsCst;


                                    switch (tributos.IcmsCst)
                                    {
                                        case "41a":
                                            IcmsRetidoForm form2 = new IcmsRetidoForm(codItem + " - " + descricao);
                                            form2.ShowDialog();

                                            nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                                new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                                {
                                                    NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                    Cst = tributos.IcmsCst,
                                                    Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                    ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                    Aliquota = tributos.IcmsAliquota,
                                                    AliquotaSt = tributos.IcmsAliquotaSt,
                                                    PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                    ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                    PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                    PercentualMvaSt = tributos.IcmsMvaSt,
                                                    CodigoAntecipacaoSt = "X",
                                                    PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                    ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                    PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                    SiglaUfDevidoIcms = null,
                                                    ValorBcStRetidoRemetente = form2.remetenteBC,
                                                    ValorIcmsStRetidoRemetente = form2.remetenteValor,
                                                    ValorBcStRetidoDestinatario = form2.destBC,
                                                    ValorIcmsStRetidoDestinatario = form2.destValor,
                                                    CsoSimples = tributos.IcmsCsoSimples,
                                                    AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                    ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                    MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                                };
                                            break;

                                        case "90b":
                                            nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                                new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                                {
                                                    NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                    Cst = "90",
                                                    Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                    ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                    Aliquota = tributos.IcmsAliquota,
                                                    AliquotaSt = tributos.IcmsAliquotaSt,
                                                    PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                    ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                    PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                    PercentualMvaSt = tributos.IcmsMvaSt,
                                                    CodigoAntecipacaoSt = "X",
                                                    PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                    ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                    PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                    SiglaUfDevidoIcms = null,
                                                    ValorBcStRetidoRemetente = 0,
                                                    ValorIcmsStRetidoRemetente = 0,
                                                    ValorBcStRetidoDestinatario = 0,
                                                    ValorIcmsStRetidoDestinatario = 0,
                                                    CsoSimples = tributos.IcmsCsoSimples,
                                                    AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                    ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                    MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                                };

                                            break;

                                        default:
                                            nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                                new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                                {
                                                    NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                    Cst = tributos.IcmsCst,
                                                    Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                    ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                    Aliquota = tributos.IcmsAliquota,
                                                    AliquotaSt = tributos.IcmsAliquotaSt,
                                                    PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                    ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                    PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                    PercentualMvaSt = tributos.IcmsMvaSt,
                                                    CodigoAntecipacaoSt = "X",
                                                    PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                    ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                    PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                    SiglaUfDevidoIcms = null,
                                                    ValorBcStRetidoRemetente = 0,
                                                    ValorIcmsStRetidoRemetente = 0,
                                                    ValorBcStRetidoDestinatario = 0,
                                                    ValorIcmsStRetidoDestinatario = 0,
                                                    CsoSimples = tributos.IcmsCsoSimples,
                                                    AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                    ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                    MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                                };
                                            break;
                                    }

                                    break;

                                case IncidenciaImposto.NaoIncide:
                                    throw new Exception("Icms é obrigatório.");

                                case IncidenciaImposto.Suspenso:
                                    cstCsosn = cstSuspensaoIcms;
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                        new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                        {
                                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                            Cst = cstSuspensaoIcms,
                                            Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                            ModalidadeDeterminacaoBc = ModalidadeDeterminacaoBCICMS.ValorOperacao,
                                            Aliquota = 0,
                                            AliquotaSt = 0,
                                            PercentualReducaoBc = 0,
                                            ModalidadeDeterminacaoBcSt = ModalidadeDeterminacaoBCICMSST.MargemValorAgregado,
                                            PercentualReducaoBcSt = 0,
                                            PercentualMvaSt = 0,
                                            CodigoAntecipacaoSt = "X",
                                            PercentualDiferimento = 0,
                                            ObsDiferimento = "",
                                            PercentualBcOperacaoPropria = 0,
                                            SiglaUfDevidoIcms = null,
                                            ValorBcStRetidoRemetente = 0,
                                            ValorIcmsStRetidoRemetente = 0,
                                            ValorBcStRetidoDestinatario = 0,
                                            ValorIcmsStRetidoDestinatario = 0,
                                            CsoSimples = csoSuspensaoIcms,
                                            AliquotaCreditoSimples = 0
                                        };

                                    break;
                            }


                            switch (incideIPI)
                            {
                                case IncidenciaImposto.NaoIncide:
                                    break;
                                case IncidenciaImposto.Incide:
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                        new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                        {
                                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                            ClasseEnquadramentoCigarrosBebidas = null,
                                            CnpjProdutor = null,
                                            ClasseEnquadramento = tributos.IpiCodEnquadramento,
                                            Cst = tributos.IpiCst,
                                            Aliquota = tributos.IpiAliquota,
                                            ModalidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributos.IpiModTributacao),
                                            QuantidadeVendida = 0
                                        };
                                    break;
                                case IncidenciaImposto.Suspenso:
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                        new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                        {
                                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                            ClasseEnquadramentoCigarrosBebidas = null,
                                            CnpjProdutor = null,
                                            ClasseEnquadramento = tributos.IpiCodEnquadramento,
                                            Cst = cstSuspensaoIPI,
                                            Aliquota = 0,
                                            ModalidadeTributacao = ModalidadeTributacao.NaoTributado,
                                            QuantidadeVendida = 0
                                        };
                                    break;
                            }


                            switch (incidePIS)
                            {
                                case IncidenciaImposto.NaoIncide:
                                    throw new Exception("PIS é obrigatório.");
                                case IncidenciaImposto.Incide:
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                                        new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                        {
                                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                            Cst = tributos.PisCst,
                                            Aliquota = tributos.PisAliquota,
                                            ModadlidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributos.PisModTributacao),
                                            ImpostoRetido = tributos.PisImpostoRetido?(short)1: (short)0
                                        };
                                    break;
                                case IncidenciaImposto.Suspenso:
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                                        new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                        {
                                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                            Cst = cstSuspensaoPIS,
                                            Aliquota = 0,
                                            ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                            ImpostoRetido = 0
                                        };
                                    break;
                            }


                            switch (incideCofins)
                            {
                                case IncidenciaImposto.NaoIncide:
                                    throw new Exception("Cofins é obrigatório.");
                                case IncidenciaImposto.Incide:
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                                        new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                        {
                                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                            Cst = tributos.CofinsCst,
                                            Aliquota = tributos.CofinsAliquota,
                                            ModadlidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributos.CofinsModTributacao),
                                            ImpostoRetido = tributos.CofinsImpostoRetido ? (short)1 : (short)0
                                        };
                                    break;
                                case IncidenciaImposto.Suspenso:
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                                        new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                        {
                                            NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                            Cst = cstSuspensaoCofins,
                                            Aliquota = 0,
                                            ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                            ImpostoRetido = 0
                                        };
                                    break;
                            }

                            nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].CfopPartilhaIcms = tributos.IcmsPartilha;


                            NcmClass ncmReal = (NcmClass) new NcmClass(Usuario, conn).Search(new List<SearchParameterClass>()
                            {
                                new SearchParameterClass("CodigoExato", nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.Ncm)
                            }).FirstOrDefault();

                            if (ncmReal != null)
                            {
                                AliquotaFundoCombatePobrezaClass aliquotaFCP = ncmReal.CollectionAliquotaFundoCombatePobrezaClassNcm.FirstOrDefault(a => a.Estado == cliente.EstadoCob);
                                if (aliquotaFCP != null)
                                {
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].AlquotaFundoCombatePobreza = aliquotaFCP.Aliquota;
                                }
                                else
                                {
                                    nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].AlquotaFundoCombatePobreza = 0;
                                }



                                BuscaObservacoesAdicionais(CFOP, ncmReal, cstCsosn, ref observacoesAdd, ref observacoesFiscoAdd);
                            }


                            item.IndiceLinha = numeroLinhaNF;
                            numeroLinhaNF++;

                            itemExt = null;
                        }


                        if (nf.CollectionNfItemClassNfPrincipal.Count == 0)
                        {
                            throw new Exception("Ao menos um item deve ser selecionado.");
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados dos itens da NF: " + itemExt.Pedido + "\r\n" +
                                            e.Message);
                    }

                    #endregion

                    #region Devolução Material Cliente

                    NfPrincipalClass nfDevolucaoMateriais = nf;
                    bool nfMateriaisSeparada = false;
                    int numeroLinhaNFDevolucao = numeroLinhaNF;

                    List<string> observacoesMateriaisAdd = new List<string>();
                    List<string> observacoesFiscoMateriaisAdd = new List<string>();


                    string observacaoDevolucaoMaterial = "";

                    if (nfTmp.devolverMateriaisCliente)
                    {
                        try
                        {
                            this.carregarMateriaisCliente(ref nfTmp);

                            #region Busca dados Gerais

                            int CFOP;


                            IncidenciaImposto incideIcms = IncidenciaImposto.Incide;
                            string cstSuspensaoIcms = null;
                            int csoSuspensaoIcms = 0;
                            IncidenciaImposto incideIPI = IncidenciaImposto.Incide;
                            string cstSuspensaoIPI = null;
                            IncidenciaImposto incidePIS = IncidenciaImposto.Incide;
                            string cstSuspensaoPIS = null;
                            IncidenciaImposto incideCofins = IncidenciaImposto.Incide;
                            string cstSuspensaoCofins = null;



                            CFOP = nfTmp.TributosItemPrincipalNf.DevolucaoMaterialCfop.Value;
                            incideIcms = nfTmp.TributosItemPrincipalNf.DevolucaoMaterialIcmsIncide.Value;

                            if (incideIcms == IncidenciaImposto.Suspenso)
                            {
                                cstSuspensaoIcms = nfTmp.TributosItemPrincipalNf.DevolucaoMaterialIcmsCst;
                                if (cstSuspensaoIcms == "300" || cstSuspensaoIcms == "400")
                                {
                                    csoSuspensaoIcms = Convert.ToInt32(cstSuspensaoIcms);
                                    cstSuspensaoIcms = "SN";
                                }
                            }

                            bool carregarIpiProduto = false;
                            string codEnquadramentoIpi = null;
                            if (nfTmp.TributosItemPrincipalNf.DevolucaoMaterialIpiIncide.Value == IncidenciaIPI.UtilizaDadosProdutoNcm)
                            {
                                carregarIpiProduto = true;
                                incideIPI = IncidenciaImposto.Incide;
                            }
                            else
                            {
                                carregarIpiProduto = false;
                                incideIPI = (IncidenciaImposto) Enum.ToObject(typeof(IncidenciaImposto), Convert.ToInt16(nfTmp.TributosItemPrincipalNf.DevolucaoMaterialIpiIncide.Value));
                            }
                            if (incideIPI == IncidenciaImposto.Suspenso)
                            {
                                cstSuspensaoIPI = nfTmp.TributosItemPrincipalNf.DevolucaoMaterialIpiCst;
                            }

                            incideCofins = nfTmp.TributosItemPrincipalNf.DevolucaoMaterialCofinsIncide.Value;
                            if (incideCofins == IncidenciaImposto.Suspenso)
                            {
                                cstSuspensaoCofins = nfTmp.TributosItemPrincipalNf.DevolucaoMaterialCofinsCst;
                            }

                            incidePIS = nfTmp.TributosItemPrincipalNf.DevolucaoMaterialPisIncide.Value;
                            {
                                cstSuspensaoPIS = nfTmp.TributosItemPrincipalNf.DevolucaoMaterialPisCst;
                            }


                            #endregion


                          
                            if (nfTmp.DevolverMaterialClienteNfSeparada)
                            {
                                nfMateriaisSeparada = true;

                                nfDevolucaoMateriais = new NfPrincipalClass(Usuario,conn)
                                {
                                    Numero = nf.Numero+1,
                                    NaturezaOperacao = nfTmp.DevolverMaterialClienteNfSeparadaNaturezaOp,
                                    Serie = nf.Serie,
                                    FormaPagamento = nf.FormaPagamento,
                                    ModeloDocFiscal = nf.ModeloDocFiscal,
                                    DataEmissao = Configurations.DataIndependenteClass.GetData(),
                                    DataSaidaEntrada = Configurations.DataIndependenteClass.GetData(),
                                    Tipo = TipoNota.Saida,
                                    CodMunicipioFatoGerador = nf.CodMunicipioFatoGerador,
                                    FormatoImpressao = nf.FormatoImpressao,
                                    FormaEmissao = nf.FormaEmissao,
                                    IdentificacaoAmbiente = nf.IdentificacaoAmbiente,
                                    FinalidadeEmissao = nf.FinalidadeEmissao,
                                    ProcessoEmissao = nf.ProcessoEmissao,
                                    VersaoProcessoEmissao = nf.VersaoProcessoEmissao,
                                    Observacoes = "",
                                    TipoEmitente = nf.TipoEmitente,
                                    Situacao = nf.Situacao,
                                    ConsumidorFinal = nf.ConsumidorFinal,
                                    PresencaComprador = nf.PresencaComprador,
                                    EnviarNfeReceita = true
                                        
                                };

                                nfDevolucaoMateriais.Homologacao = nf.Homologacao;

                                nfDevolucaoMateriais.NfAtributo = new NfAtributoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfPrincipal = nfDevolucaoMateriais,
                                    VersaoLayout = nf.NfAtributo.VersaoLayout,
                                    IdNfe = nf.NfAtributo.IdNfe
                                };

                                nfDevolucaoMateriais.NfEmitente = new NfEmitenteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfPrincipal = nfDevolucaoMateriais,
                                    Razao = nf.NfEmitente.Razao,
                                    NomeFantasia = nf.NfEmitente.NomeFantasia,
                                    Ie = nf.NfEmitente.Ie,
                                    IeSt = nf.NfEmitente.IeSt,
                                    Im = nf.NfEmitente.Im,
                                    Cnae = nf.NfEmitente.Cnae,
                                    CnpjCpf = nf.NfEmitente.CnpjCpf,
                                    Crt = nf.NfEmitente.Crt,
                                    AliquotaSimplesServico = nf.NfEmitente.AliquotaSimplesServico
                                };


                                nfDevolucaoMateriais.NfEmitente.NfEmitenteEndereco = new NfEmitenteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfPrincipal = nfDevolucaoMateriais,
                                    NfEmitente = nfDevolucaoMateriais.NfEmitente,
                                    Logradouro = nf.NfEmitente.NfEmitenteEndereco.Logradouro,
                                    Numero = nf.NfEmitente.NfEmitenteEndereco.Numero,
                                    Complemento = nf.NfEmitente.NfEmitenteEndereco.Complemento,
                                    Bairro = nf.NfEmitente.NfEmitenteEndereco.Bairro,
                                    CodMunicipio = nf.NfEmitente.NfEmitenteEndereco.CodMunicipio,
                                    NomeMunicipio = nf.NfEmitente.NfEmitenteEndereco.NomeMunicipio,
                                    SiglaUf = nf.NfEmitente.NfEmitenteEndereco.SiglaUf,
                                    Cep = nf.NfEmitente.NfEmitenteEndereco.Cep,
                                    CodPais = nf.NfEmitente.NfEmitenteEndereco.CodPais,
                                    NomePais = nf.NfEmitente.NfEmitenteEndereco.NomePais,
                                    Telefone = nf.NfEmitente.NfEmitenteEndereco.Telefone
                                };

                                foreach (NfPrincipalAutorizacaoXmlClass auto in nf.CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal)
                                {
                                    nfDevolucaoMateriais.CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Add(new NfPrincipalAutorizacaoXmlClass(Usuario, conn)
                                    {
                                        Documento = auto.Documento,
                                        NfPrincipal = nfDevolucaoMateriais
                                    });
                                }
                              

                                
                                nfDevolucaoMateriais.NfCliente = new NfClienteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfPrincipal = nfDevolucaoMateriais,
                                    Razao = nf.NfCliente.Razao,
                                    NomeFantasia = nf.NfCliente.NomeFantasia,
                                    Ie = nf.NfCliente.Ie,
                                    CnpjCpf = nf.NfCliente.CnpjCpf,
                                    Isuf = nf.NfCliente.Isuf,
                                    Email = nf.NfCliente.Email,
                                    IndicadorIe = nf.NfCliente.IndicadorIe,
                                };

                                nfDevolucaoMateriais.NfCliente.NfClienteEndereco = new NfClienteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfPrincipal = nfDevolucaoMateriais,
                                    Logradouro = nf.NfCliente.NfClienteEndereco.Logradouro,
                                    Numero = nf.NfCliente.NfClienteEndereco.Numero,
                                    Complemento = nf.NfCliente.NfClienteEndereco.Complemento,
                                    Bairro = nf.NfCliente.NfClienteEndereco.Bairro,
                                    CodMunicipio =nf.NfCliente.NfClienteEndereco.CodMunicipio,
                                    NomeMunicipio = nf.NfCliente.NfClienteEndereco.NomeMunicipio,
                                    SiglaUf = nf.NfCliente.NfClienteEndereco.SiglaUf,
                                    Cep = nf.NfCliente.NfClienteEndereco.Cep,
                                    CodPais = nf.NfCliente.NfClienteEndereco.CodPais,
                                    NomePais = nf.NfCliente.NfClienteEndereco.NomePais,
                                    Telefone = nf.NfCliente.NfClienteEndereco.Telefone

                                };

                                nfDevolucaoMateriais.NfTransporte = new NfTransporteClass(Usuario, conn)
                                {
                                    NfPrincipal = nfDevolucaoMateriais,
                                    Modalidade = ModalidadeFrete.SemFrete
                                };

                                nfDevolucaoMateriais.CollectionNfPagamentoClassNfPrincipal.Add(new NfPagamentoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfPrincipal = nfDevolucaoMateriais,
                                    Tipo = NfPagamentoTipo.SemPagamento,
                                    TipoDescricao = null,
                                    Valor = 0,
                                });

                                numeroLinhaNFDevolucao = 1;

                            }

                           

                            foreach (organizaNfMaterialClienteClass mat in nfTmp.Materiais)
                            {
                                string tipoDevolucao = "PARCIAL";
                                if (Math.Abs(mat.Saldo - mat.saldoTotalLote) < 0.000001)
                                {
                                    tipoDevolucao = "TOTAL";
                                }

                                observacaoDevolucaoMaterial += "RETORNO " + tipoDevolucao + " DO ITEM " + mat.Codigo +
                                                               " DA NF " + mat.nfNumero + " SÉRIE " + mat.nfSerie +
                                                               " DE " + mat.nfData.ToString("dd/MM/yyyy") + ". ";

                                CargaTributosDto tributos;
                                CargaTributosDto tributosIpi;
                                
                                if (nfTmp.TributosItemPrincipalNf.TributacaoOperacao)
                                {
                                    tributos = nfTmp.TributosItemPrincipalNf;
                                }
                                else
                                {
                                    tributos = CargaTributosDto.CarregaTributosDevolucao(mat.idProduto, mat.idMaterial, nfTmp.idCliente, emitenteCompleto.CidadeEntidade.Estado.ID, pisCofinsDefault, mat.Codigo, command, cliente.EstadoCob.ID, CFOP);
                                }

                                if (carregarIpiProduto)
                                {
                                    tributosIpi = CargaTributosDto.CarregaTributosDevolucao(mat.idProduto, mat.idMaterial, nfTmp.idCliente, emitenteCompleto.CidadeEntidade.Estado.ID, pisCofinsDefault, mat.Codigo, command, cliente.EstadoCob.ID, CFOP);
                                    codEnquadramentoIpi = tributosIpi.DevolucaoMaterialIpiCodEnquadramento;
                                }
                                else
                                {
                                    tributosIpi = tributos;
                                    CargaTributosDto tribTmp = CargaTributosDto.CarregaTributosDevolucao(mat.idProduto, mat.idMaterial, nfTmp.idCliente, emitenteCompleto.CidadeEntidade.Estado.ID, pisCofinsDefault, mat.Codigo, command, cliente.EstadoCob.ID, CFOP);
                                    codEnquadramentoIpi = tribTmp.DevolucaoMaterialIpiCodEnquadramento;
                                }


                                DadosFiscaisItemDto dadosFiscaisItem = null;

                                if (mat.idProduto.HasValue)
                                {
                                    ProdutoClass produto = ProdutoClass.GetEntidade(mat.idProduto.Value, Usuario, conn);
                                    dadosFiscaisItem = DadosFiscaisItemDto.GetDadosFiscaisProduto(produto);
                                }
                                else
                                {
                                    MaterialClass material = MaterialClass.GetEntidade(mat.idMaterial.Value, Usuario, conn);
                                    dadosFiscaisItem = DadosFiscaisItemDto.GetDadosFiscaisMaterial(material);
                                }
                                


                                string ncm = mat.NCM;
                                string cest = mat.CEST;

                                string codigoBeneficioFiscal = mat.CodigoBeneficioFiscal;

                                if (string.IsNullOrEmpty(codigoBeneficioFiscal))
                                {
                                    if (!string.IsNullOrEmpty(ncm))
                                    {

                                        NcmClass ncmEntidade = NcmClass.GetNcmPorCodigo(ncm, Usuario, conn);
                                        if (ncmEntidade != null)
                                        {
                                            NcmBeneficioFiscalClass beneficioFiscal = ncmEntidade.CollectionNcmBeneficioFiscalClassNcm.FirstOrDefault(a => a.Estado == cliente.EstadoCob && a.Cfop == CFOP);
                                            codigoBeneficioFiscal = beneficioFiscal?.CodigoBeneficioFiscal;
                                        }
                                    }
                                }

                         

                            
                                nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Add(new NfItemClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfPrincipal = nfDevolucaoMateriais,
                                    NumeroItem = numeroLinhaNFDevolucao,
                                    Cfop = CFOP,
                                    ItemDevolucao = true
                                });
                                
                                nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto =
                                    new NfProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Codigo = mat.Codigo,
                                        Descricao = mat.Descricao,
                                        Gtin = dadosFiscaisItem.GTIN,
                                        Ncm = ncm,
                                        Cest = cest,
                                        CodigoBeneficio = codigoBeneficioFiscal,
                                        Extipi = dadosFiscaisItem.exTIPI,
                                        Genero = dadosFiscaisItem.Genero,
                                        Unidade = mat.Unidade,
                                        ValorUnitario = mat.valorUnitario,
                                        GtimUnidadeTrinutacao = dadosFiscaisItem.GTIN,
                                        UnidadeTributacao = mat.Unidade,
                                        ValorUnitarioTrinutacao = mat.valorUnitario,
                                        QuantidadeTributavel = mat.Quantidade,
                                        ValorTotalTributavel = Math.Round(mat.valorTotal, 2),
                                        ValorFrete = 0,
                                        ValorDesconto = 0,
                                        ValorSeguro = 0,
                                        Quantidade = mat.Quantidade,
                                        

                                    };

                                string cstCsosn = "";
                                switch (incideIcms)
                                {
                                    case IncidenciaImposto.Incide:
                                        cstCsosn = tributos.DevolucaoMaterialIcmsCst;
                                        switch (tributos.DevolucaoMaterialIcmsCst)
                                        {
                                            case "41a":
                                                IcmsRetidoForm form2 =
                                                    new IcmsRetidoForm(mat.valorUnitario + " - " + mat.Descricao);
                                                form2.ShowDialog();

                                                nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                                    new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                                    {
                                                        NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                        Cst = tributos.IcmsCst,
                                                        Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                        ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.DevolucaoMaterialIcmsModDetBc),
                                                        Aliquota = tributos.DevolucaoMaterialIcmsAliquota,
                                                        AliquotaSt = tributos.DevolucaoMaterialIcmsAliquotaSt,
                                                        PercentualReducaoBc = tributos.DevolucaoMaterialIcmsPercentualReducaoBc,
                                                        ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.DevolucaoMaterialIcmsModDetBcSt),
                                                        PercentualReducaoBcSt = tributos.DevolucaoMaterialIcmsPercentualReducaoBcSt,
                                                        PercentualMvaSt = tributos.DevolucaoMaterialIcmsMvaSt,
                                                        CodigoAntecipacaoSt = "X",
                                                        PercentualDiferimento = tributos.DevolucaoMaterialIcmsPercentualDiferimento,
                                                        ObsDiferimento = tributos.DevolucaoMaterialIcmsObservacaoDiferimento,
                                                        PercentualBcOperacaoPropria = tributos.DevolucaoMaterialIcmsPercentualBcOperacaoPropria,
                                                        SiglaUfDevidoIcms = null,
                                                        ValorBcStRetidoRemetente = form2.remetenteBC,
                                                        ValorIcmsStRetidoRemetente = form2.remetenteValor,
                                                        ValorBcStRetidoDestinatario = form2.destBC,
                                                        ValorIcmsStRetidoDestinatario = form2.destValor,
                                                        CsoSimples = tributos.DevolucaoMaterialIcmsCsoSimples,
                                                        AliquotaCreditoSimples = tributos.DevolucaoMaterialIcmsAliquotaCredito,
                                                        MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                                    };
                                                break;

                                            case "90b":
                                                nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                                    new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                                    {
                                                        NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                        Cst = "90",
                                                        Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                        ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.DevolucaoMaterialIcmsModDetBc),
                                                        Aliquota = tributos.DevolucaoMaterialIcmsAliquota,
                                                        AliquotaSt = tributos.DevolucaoMaterialIcmsAliquotaSt,
                                                        PercentualReducaoBc = tributos.DevolucaoMaterialIcmsPercentualReducaoBc,
                                                        ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.DevolucaoMaterialIcmsModDetBcSt),
                                                        PercentualReducaoBcSt = tributos.DevolucaoMaterialIcmsPercentualReducaoBcSt,
                                                        PercentualMvaSt = tributos.DevolucaoMaterialIcmsMvaSt,
                                                        CodigoAntecipacaoSt = "X",
                                                        PercentualDiferimento = tributos.DevolucaoMaterialIcmsPercentualDiferimento,
                                                        ObsDiferimento = tributos.DevolucaoMaterialIcmsObservacaoDiferimento,
                                                        PercentualBcOperacaoPropria = tributos.DevolucaoMaterialIcmsPercentualBcOperacaoPropria,
                                                        SiglaUfDevidoIcms = null,
                                                        ValorBcStRetidoRemetente = 0,
                                                        ValorIcmsStRetidoRemetente = 0,
                                                        ValorBcStRetidoDestinatario = 0,
                                                        ValorIcmsStRetidoDestinatario = 0,
                                                        CsoSimples = tributos.DevolucaoMaterialIcmsCsoSimples,
                                                        AliquotaCreditoSimples = tributos.DevolucaoMaterialIcmsAliquotaCredito,
                                                        MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                                    };

                                                break;

                                            default:
                                                nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                                    new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                                    {
                                                        NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                        Cst = tributos.DevolucaoMaterialIcmsCst,
                                                        Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                        ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.DevolucaoMaterialIcmsModDetBc),
                                                        Aliquota = tributos.DevolucaoMaterialIcmsAliquota,
                                                        AliquotaSt = tributos.DevolucaoMaterialIcmsAliquotaSt,
                                                        PercentualReducaoBc = tributos.DevolucaoMaterialIcmsPercentualReducaoBc,
                                                        ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.DevolucaoMaterialIcmsModDetBcSt),
                                                        PercentualReducaoBcSt = tributos.DevolucaoMaterialIcmsPercentualReducaoBcSt,
                                                        PercentualMvaSt = tributos.DevolucaoMaterialIcmsMvaSt,
                                                        CodigoAntecipacaoSt = "X",
                                                        PercentualDiferimento = tributos.DevolucaoMaterialIcmsPercentualDiferimento,
                                                        ObsDiferimento = tributos.DevolucaoMaterialIcmsObservacaoDiferimento,
                                                        PercentualBcOperacaoPropria = tributos.DevolucaoMaterialIcmsPercentualBcOperacaoPropria,
                                                        SiglaUfDevidoIcms = null,
                                                        ValorBcStRetidoRemetente = 0,
                                                        ValorIcmsStRetidoRemetente = 0,
                                                        ValorBcStRetidoDestinatario = 0,
                                                        ValorIcmsStRetidoDestinatario = 0,
                                                        CsoSimples = tributos.DevolucaoMaterialIcmsCsoSimples,
                                                        AliquotaCreditoSimples = tributos.DevolucaoMaterialIcmsAliquotaCredito,
                                                        ObservacaoCreditoSimples = tributos.DevolucaoMaterialIcmsObsevacaoCredito,
                                                        MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                                    };

                                                break;
                                        }

                                        break;

                                    case IncidenciaImposto.NaoIncide:
                                        throw new Exception("Icms é obrigatório.");
                                    case IncidenciaImposto.Suspenso:
                                        cstCsosn = cstSuspensaoIcms;

                                        nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                            new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = cstSuspensaoIcms,
                                                Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                ModalidadeDeterminacaoBc = ModalidadeDeterminacaoBCICMS.ValorOperacao,
                                                Aliquota = 0,
                                                AliquotaSt = 0,
                                                PercentualReducaoBc = 0,
                                                ModalidadeDeterminacaoBcSt = ModalidadeDeterminacaoBCICMSST.MargemValorAgregado,
                                                PercentualReducaoBcSt = 0,
                                                PercentualMvaSt = 0,
                                                CodigoAntecipacaoSt = "X",
                                                PercentualDiferimento = 0,
                                                ObsDiferimento = "",
                                                PercentualBcOperacaoPropria = 0,
                                                SiglaUfDevidoIcms = null,
                                                ValorBcStRetidoRemetente = 0,
                                                ValorIcmsStRetidoRemetente = 0,
                                                ValorBcStRetidoDestinatario = 0,
                                                ValorIcmsStRetidoDestinatario = 0,
                                                CsoSimples = csoSuspensaoIcms,
                                                AliquotaCreditoSimples = 0
                                            };

                                        break;
                                }


                                switch (incideIPI)
                                {
                                    case IncidenciaImposto.NaoIncide:
                                        break;
                                    case IncidenciaImposto.Incide:
                                        nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                            new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {

                                                NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                ClasseEnquadramentoCigarrosBebidas = null,
                                                CnpjProdutor = null,
                                                ClasseEnquadramento = codEnquadramentoIpi,
                                                Cst = tributosIpi.DevolucaoMaterialIpiCst,
                                                Aliquota = tributosIpi.DevolucaoMaterialIpiAliquota,
                                                ModalidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributosIpi.DevolucaoMaterialIpiModTributacao),
                                                QuantidadeVendida = 0 
                                            };
                                        break;
                                    case IncidenciaImposto.Suspenso:
                                        nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                            new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                ClasseEnquadramentoCigarrosBebidas = null,
                                                CnpjProdutor = null,
                                                ClasseEnquadramento = codEnquadramentoIpi,
                                                Cst = cstSuspensaoIPI,
                                                Aliquota = 0,
                                                ModalidadeTributacao = ModalidadeTributacao.NaoTributado,
                                                QuantidadeVendida = 0
                                            };
                                        break;
                                }


                                switch (incidePIS)
                                {
                                    case IncidenciaImposto.NaoIncide:
                                        throw new Exception("PIS é obrigatório.");
                                    case IncidenciaImposto.Incide:
                                        nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                                            new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = tributos.DevolucaoMaterialPisCst,
                                                Aliquota = tributos.DevolucaoMaterialPisAliquota,
                                                ModadlidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributos.DevolucaoMaterialPisModTributacao),
                                                ImpostoRetido = tributos.DevolucaoMaterialPisImpostoRetido ? (short) 1 : (short) 0
                                            };
                                        break;
                                    case IncidenciaImposto.Suspenso:
                                        nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                                            new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = cstSuspensaoPIS,
                                                Aliquota = 0,
                                                ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                                ImpostoRetido = 0
                                            };
                                        break;
                                }


                                switch (incideCofins)
                                {
                                    case IncidenciaImposto.NaoIncide:
                                        throw new Exception("Cofins é obrigatório.");
                                    case IncidenciaImposto.Incide:
                                        nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                                            new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = tributos.DevolucaoMaterialCofinsCst,
                                                Aliquota = tributos.DevolucaoMaterialCofinsAliquota,
                                                ModadlidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributos.DevolucaoMaterialCofinsModTributacao),
                                                ImpostoRetido = tributos.DevolucaoMaterialCofinsImpostoRetido ? (short) 1 : (short) 0
                                            };
                                        break;
                                    case IncidenciaImposto.Suspenso:
                                        nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                                            new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = cstSuspensaoCofins,
                                                Aliquota = 0,
                                                ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                                ImpostoRetido = 0
                                            };
                                        break;
                                }

                                NcmClass ncmReal = (NcmClass) new NcmClass(Usuario, conn).Search(new List<SearchParameterClass>()
                                {
                                    new SearchParameterClass("CodigoExato", nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal[nfDevolucaoMateriais.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.Ncm)
                                }).FirstOrDefault();


                                if (ncmReal != null)
                                {
                                    if (nfMateriaisSeparada)
                                    {
                                        BuscaObservacoesAdicionais(CFOP, ncmReal, cstCsosn, ref observacoesMateriaisAdd, ref observacoesFiscoMateriaisAdd);
                                    }
                                    else
                                    {
                                        BuscaObservacoesAdicionais(CFOP, ncmReal, cstCsosn, ref observacoesAdd, ref observacoesFiscoAdd);
                                    }
                                    
                                }

                                numeroLinhaNFDevolucao++;
                            }

                            if (nfMateriaisSeparada)
                            {
                                nfDevolucaoMateriais.Observacoes = cliObsPadraoNfe + " " + observacaoDevolucaoMaterial;
                                observacaoDevolucaoMaterial = null;
                            }
                            else
                            {
                                numeroLinhaNF = numeroLinhaNFDevolucao ;
                            }

                        }
                        catch (Exception e)
                        {
                            throw new Exception("Erro ao preencher a devolução de materiais.\r\n" + e.Message, e);
                        }
                    }

                    #endregion

                    #region Transporte

                    double pesoLiquidoTotal = pesoTotalItens;
                    double pesoBrutoTotal = pesoTotalItens;

                    if (IWTConfiguration.Conf.getBoolConf(Constants.VALIDAR_PESO_VOLUMES_NFE))
                    {

                        ConferePesoVolumeForm form = new ConferePesoVolumeForm(pesoTotalItens, pesoTotalItens, totalVolumes);
                        form.ShowDialog();

                        pesoLiquidoTotal = form.PesoLiquido;
                        pesoBrutoTotal = form.PesoBruto;
                        totalVolumes = form.Volumes;

                    }


                    try
                    {
                        if (nfTmp.idTransporte == -1)
                        {
                            //public NfTransporte(NfPrincipal nfPrincipal, short nftModalidade, string nftRazao, string nftIe, string nftEndereco, string nftSiglaUf, string nftMunicipio,
                            //string nftCpfCnpj, int? nftVolumes, double nftPesoLiquido, double nftPesoBruto, string nftPlaca, string nftRegistroAntt, string nftSiglaUfVeiculo,
                            //string nftVolumeEspecie, string nftVolumeMarca)
                            nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                            {
                                NfPrincipal = nf,
                                Modalidade = nfTmp.responsavelFrete,
                                Razao = "",
                                Ie = "",
                                Endereco = "",
                                SiglaUf = "",
                                Municipio = "",
                                CpfCnpj = "",
                                Volumes = totalVolumes,
                                PesoLiquido = pesoLiquidoTotal,
                                PesoBruto = pesoBrutoTotal,
                                Placa = null,
                                RegistroAntt = null,
                                SiglaUfVeiculo = null,
                                VolumeEspecie = "Volume",
                                VolumeMarca = ""
                            };
                        }
                        else
                        {

                            TransporteClass transporte = TransporteClass.GetEntidade(nfTmp.idTransporte, Usuario, conn);




                            nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                            {
                                NfPrincipal = nf,
                                Modalidade = nfTmp.responsavelFrete,
                                Razao = transporte.Razao,
                                Ie = string.IsNullOrEmpty(transporte.Ie) ? transporte.Ie : transporte.Ie.Replace("-", "").Replace(".", ""),
                                Endereco = transporte.Endereco,
                                SiglaUf = transporte.Cidade?.Estado?.Sigla,
                                Municipio = transporte.Cidade?.Nome,
                                CpfCnpj = transporte.CpfCnpj,
                                Volumes = totalVolumes,
                                PesoLiquido = pesoLiquidoTotal,
                                PesoBruto = pesoBrutoTotal,
                                Placa = transporte.Placa.Replace("-", ""),
                                RegistroAntt = transporte.RegistroAntt.ToString(),
                                SiglaUfVeiculo = transporte.EstadoVeiculo?.Sigla,
                                VolumeEspecie = "Volume",
                                VolumeMarca = ""
                            };


                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados do transporte da NF.\r\n" + e.Message);
                    }

                    #endregion

                    try
                    {


                        NfPrincipalClass.calculaNf(ref nf, this.arrendodamentoNF, Usuario, conn, observacaoCustomizada, nfTmp.SomaFreteBcIcms, nfTmp.SomaFreteBcIpi, descontarIcmsBCCofins: nfTmp.DescontarImcsBcCofins, descontarIcmsBCPis: nfTmp.DescontarImcsBcPis);

                        if (nfMateriaisSeparada)
                        {
                            NfPrincipalClass.calculaNf(ref nfDevolucaoMateriais, this.arrendodamentoNF, Usuario, conn, observacaoCustomizada, nfTmp.SomaFreteBcIcms, nfTmp.SomaFreteBcIpi);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao calcular a NF.\r\n" + e.Message);
                    }

                    #region Dados Cobrança



                    #region  Calcula o valor dos itens de devolução que não devem ser somados na fatura
                    double valorItensDevolucao = 0;
                    foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal.Where(a=>a.ItemDevolucao))
                    {
                        double valorItem = 0;

                        if (item.NfItemTributo.NfItemTributoIcms != null)
                        {
                            valorItem =
                                Math.Round(
                                    valorItem
                                    + item.NfProduto.ValorTotalTributavel
                                    + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt, 2, MidpointRounding.AwayFromZero);
                        }

                        if (item.NfItemTributo.NfItemTributoIss != null)
                        {
                            valorItem = Math.Round(valorItem + item.NfProduto.ValorTotalTributavel, 2, MidpointRounding.AwayFromZero);
                        }

                        if (item.NfItemTributo.NfItemTributoIimp != null)
                        {
                            valorItem = Math.Round(valorItem + item.NfItemTributo.NfItemTributoIimp.ValorIimp, 2, MidpointRounding.AwayFromZero);
                        }

                        if (item.NfItemTributo.NfItemTributoIpi != null)
                        {
                            valorItem = Math.Round(valorItem + item.NfItemTributo.NfItemTributoIpi.ValorIpi, 2, MidpointRounding.AwayFromZero);
                        }


                        valorItem = Math.Round(valorItem
                                               - item.NfProduto.ValorDesconto
                                               + item.NfProduto.ValorFrete
                                               + item.NfProduto.ValorSeguro
                                               + item.NfProduto.OutrasDespesasAcessorias, 2, MidpointRounding.AwayFromZero);

                        valorItensDevolucao = Math.Round(valorItensDevolucao + valorItem, 2, MidpointRounding.AwayFromZero);

                    }


                    double valorContasFaturas = Math.Round(nf.NfTotais.ValorTotalNf - valorItensDevolucao, 2, MidpointRounding.AwayFromZero);

                    #endregion



                    List<ContaReceberClass> contasNotaAtual = null;
                    AgrupadorContaClass agrupador = new AgrupadorContaClass(Usuario, conn)
                    {
                        Data = Configurations.DataIndependenteClass.GetData()
                    };

                    try
                    {
                        nf.NfCobranca = new NfCobrancaClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            CollectionNfDuplicataClassNfCobranca = new BindingList<NfDuplicataClass>(new List<NfDuplicataClass>())
                        };

                        TipoPagamentoClass tipoPagamento = null;
                        if (nfTmp.IdTipoPagamento != -1)
                        {
                            tipoPagamento = TipoPagamentoClass.GetEntidade(nfTmp.IdTipoPagamento, Usuario, conn);
                        }


                        if (nfTmp.GerarContasReceber)
                        {
                            if (nfTmp.idFormaPagamento == -1 && nfTmp.idContaBancaria == -1 && nfTmp.idCentroCustoLucro == -1)
                            {
                                nf.NfCobranca.CollectionNfDuplicataClassNfCobranca.Add(new NfDuplicataClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                {
                                    NfPrincipal = nf,
                                    Numero = "001",
                                    Valor = valorContasFaturas,
                                    Vencimento = Configurations.DataIndependenteClass.GetData().AddDays(emitenteCompleto.DiasPagamentoPadrao)
                                });

                            }
                            else
                            {

                                if (nfTmp.idFormaPagamento == -1)
                                {
                                    throw new Exception(
                                        "Não é possível emitir a NFe pois a forma de pagamento não foi selecionada, verifique o pedido e/ou o cliente.\r\n" +
                                        nfTmp.Pedidos);
                                }

                                if (nfTmp.idContaBancaria == -1)
                                {
                                    throw new Exception(
                                        "Não é possível emitir a NFe pois a conta bancária não foi selecionada, verifique o pedido e/ou o cliente.\r\n" +
                                        nfTmp.Pedidos);
                                }

                                if (nfTmp.idCentroCustoLucro == -1)
                                {
                                    throw new Exception(
                                        "Não é possível emitir a NFe pois o centro de lucro não foi selecionado, verifique o pedido e/ou o cliente.\r\n" +
                                        nfTmp.Pedidos);
                                }

                                CentroCustoLucroClass centroCusto = CentroCustoLucroClass.GetEntidade(nfTmp.idCentroCustoLucro, Usuario, conn);
                                FormaPagamentoClass formaPagamento = FormaPagamentoClass.GetEntidade(nfTmp.idFormaPagamento, Usuario, conn);
                                ContaBancariaClass contaBancaria = ContaBancariaClass.GetEntidade(nfTmp.idContaBancaria, Usuario, conn);

                               
                                

                                if (!centroCusto.Ativo)
                                {
                                    throw new Exception(
                                        "Não é possível emitir a NFe pois o centro de lucro selecionado (" + centroCusto + ") não está ativo, verifique o pedido e/ou o cliente.\r\n" +
                                        nfTmp.Pedidos);
                                }

                                if (!formaPagamento.Ativo)
                                {
                                    throw new Exception(
                                        "Não é possível emitir a NFe pois a forma de pagamento selecionada (" + formaPagamento + ") não está ativo, verifique o pedido e/ou o cliente.\r\n" +
                                        nfTmp.Pedidos);
                                }



                                double valorRestante = valorContasFaturas;


                                int totalParcelas = formaPagamento.QuantidadeParcelas;
                                if (formaPagamento.Entrada)
                                    totalParcelas++;


                                contasNotaAtual = new List<ContaReceberClass>();
                                double valorPrevistoParcela = Math.Round((valorRestante / totalParcelas), 2);
                                DateTime dataAtual = Configurations.DataIndependenteClass.GetData().Date;

                                CredorDevedorClass cr = cliente.CollectionCredorDevedorClassCliente.FirstOrDefault();

                                for (int indiceParcela = 1; indiceParcela <= totalParcelas; indiceParcela++)
                                {
                                    ContaReceberClass tmp;
                                    if (formaPagamento.Entrada && indiceParcela == 1)
                                    {
                                        dataAtual = dataAtual.AddDays(formaPagamento.DiasEntrada);
                                        //Entrada
                                        tmp = new ContaReceberClass(Usuario, conn)
                                        {
                                            NfPrincipal = nf,
                                            IdDevedor = cr.ID,
                                            CentroCustoLucro = centroCusto,
                                            ContaBancaria = contaBancaria,
                                            //NumDocumento = "NFe " + nf.Numero.ToString(),
                                            NumDocumento = (nf.Numero.ToString() + "-" + indiceParcela).PadLeft(10, '0'),
                                            DataVencimento = dataAtual,
                                            Valor = valorPrevistoParcela,
                                            Historico = "Parcela " + indiceParcela + "/" + totalParcelas,
                                            TipoPagamento = tipoPagamento,
                                            MeioPagamento =  formaPagamento.MeioPagamento,
                                            AgrupadorConta = agrupador

                                        };

                                    }
                                    else
                                    {
                                        if (indiceParcela == totalParcelas)
                                        {
                                            //Ultima Parcela ajustar valor
                                            dataAtual = dataAtual.AddDays(formaPagamento.Periodicidade);

                                            tmp = new ContaReceberClass(Usuario, conn)
                                            {
                                                NfPrincipal = nf,
                                                IdDevedor = cr.ID,
                                                CentroCustoLucro = centroCusto,
                                                ContaBancaria = contaBancaria,
                                                //NumDocumento = "NFe " + nf.Numero.ToString(),
                                                NumDocumento = (nf.Numero.ToString() + "-" + indiceParcela).PadLeft(10, '0'),
                                                DataVencimento = dataAtual,
                                                Valor = valorRestante,
                                                Historico = "Parcela " + indiceParcela + "/" + totalParcelas,
                                                TipoPagamento = tipoPagamento,
                                                MeioPagamento = formaPagamento.MeioPagamento,
                                                AgrupadorConta = agrupador

                                            };


                                        }
                                        else
                                        {
                                            //Demais Parcelas
                                            dataAtual = dataAtual.AddDays(formaPagamento.Periodicidade);


                                            tmp = new ContaReceberClass(Usuario, conn)
                                            {
                                                NfPrincipal = nf,
                                                IdDevedor = cr.ID,
                                                CentroCustoLucro = centroCusto,
                                                ContaBancaria = contaBancaria,
                                                //NumDocumento = "NFe " + nf.Numero.ToString(),
                                                NumDocumento = (nf.Numero.ToString() + "-" + indiceParcela).PadLeft(10, '0'),
                                                DataVencimento = dataAtual,
                                                Valor = valorPrevistoParcela,
                                                Historico = "Parcela " + indiceParcela + "/" + totalParcelas,
                                                TipoPagamento = tipoPagamento,
                                                MeioPagamento = formaPagamento.MeioPagamento,
                                                AgrupadorConta = agrupador

                                            };



                                        }
                                    }
                                    agrupador.CollectionContaReceberClassAgrupadorConta.Add(tmp);
                                    contasNotaAtual.Add(tmp);
                                    valorRestante -= tmp.Valor;
                                    valorRestante = Math.Round(valorRestante, 2);
                                }

                                contasNotaAtual = contasNotaAtual.OrderBy(a => a.DataVencimento).ToList();

                                for (var i = 0; i < contasNotaAtual.Count; i++)
                                {
                                    ContaReceberClass receber = contasNotaAtual[i];
                                    nf.NfCobranca.CollectionNfDuplicataClassNfCobranca.Add(
                                        new NfDuplicataClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                        {
                                            NfPrincipal = nf,
                                            Numero = (i + 1).ToString().PadLeft(3, '0'),
                                            Vencimento = receber.DataVencimento,
                                            Valor = receber.Valor
                                        });
                                }

                                if (formaPagamento.Entrada && formaPagamento.DiasEntrada == 0 && formaPagamento.QuantidadeParcelas == 0)
                                {
                                    nf.FormaPagamento = FormaPagamento.AVista;
                                }
                                else
                                {
                                    nf.FormaPagamento = FormaPagamento.APrazo;
                                }
                            }
                        }

                        NfPagamentoTipo pagto = NfPagamentoTipo.Outros;
                        string xPagto = null;
                        if (tipoPagamento == null || tipoPagamento.Identificacao.ToUpperInvariant().Contains("BOLETO"))
                        {
                            pagto = NfPagamentoTipo.BoletoBancario;
                        }
                        else
                        {
                            switch (tipoPagamento.TipoPagamentoNf)
                            {
                                case TipoPagamentoNfe.Dinheiro:
                                    pagto = NfPagamentoTipo.Dinheiro;
                                    break;
                                case TipoPagamentoNfe.Cheque:
                                    pagto = NfPagamentoTipo.Cheque;
                                    break;
                                case TipoPagamentoNfe.CartaodeCredito:
                                    pagto = NfPagamentoTipo.CartaoCredito;
                                    break;
                                case TipoPagamentoNfe.CartaodeDebito:
                                    pagto = NfPagamentoTipo.CartaoDebito;
                                    break;
                                case TipoPagamentoNfe.CreditoLoja:
                                    pagto = NfPagamentoTipo.CreditoLoja;
                                    break;
                                case TipoPagamentoNfe.ValeAlimentacao:
                                    pagto = NfPagamentoTipo.ValeAlimentacao;
                                    break;
                                case TipoPagamentoNfe.ValeRefeicao:
                                    pagto = NfPagamentoTipo.ValeRefeicao;
                                    break;
                                case TipoPagamentoNfe.ValePresente:
                                    pagto = NfPagamentoTipo.ValePresente;
                                    break;
                                case TipoPagamentoNfe.ValeCombustivel:
                                    pagto = NfPagamentoTipo.ValeCombustivel;
                                    break;
                                case TipoPagamentoNfe.BoletoBancario:
                                    pagto = NfPagamentoTipo.BoletoBancario;
                                    break;
                                case TipoPagamentoNfe.DepositoBancario:
                                    pagto = NfPagamentoTipo.DepositoBancario;
                                    break;
                                case TipoPagamentoNfe.Pix:
                                    pagto = NfPagamentoTipo.Pix;
                                    break;
                                case TipoPagamentoNfe.TransferenciaBancaria:
                                    pagto = NfPagamentoTipo.TransferenciaBancaria;
                                    break;
                                case TipoPagamentoNfe.ProgramaFidelidade:
                                    pagto = NfPagamentoTipo.ProgramaFidelidade;
                                    break;
                                case TipoPagamentoNfe.SemPagamento:
                                    pagto = NfPagamentoTipo.SemPagamento;
                                    break;
                                case TipoPagamentoNfe.Outros:
                                    pagto = NfPagamentoTipo.Outros;
                                    xPagto = tipoPagamento.TipoPagamentoNfDescricao;
                                    break;
                                case null:
                                    throw new ExcecaoTratada("O tipo de pagamento "+tipoPagamento.Identificacao + " não possui tipo de pagamento pra nota fiscal definido");
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                          
                        }



                        nf.CollectionNfPagamentoClassNfPrincipal.Add(new NfPagamentoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            Tipo = pagto,
                            TipoDescricao = xPagto,
                            Valor = valorContasFaturas,
                        });
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao preencher os dados das duplicatas da NF.\r\n" + e.Message);
                    }

                    #endregion

                    #region Pedido Urgente (Obs)

                    if (nfTmp.matAdicional)
                    {
                        nf.Observacoes += "MAT ADICIONAL URGENTE";
                    }

                    #endregion

                    #region Observações

                    string observacaoPedidos = "";
                    foreach (OrganizaNfItemClass item in nfTmp.itens.Values.Where(a => !string.IsNullOrWhiteSpace(a.ObservacaoPedido)))
                    {
                        observacaoPedidos += "Observação do Pedido " + item.Pedido + ": " + item.ObservacaoPedido + " ";
                    }

                    if (inclusaoPedidoNota == InclusaoPedidoNota.Observacao)
                    {
                        if (observacaoPedidos.Length > 0)
                        {
                            observacaoPedidos += " ";
                        }

                        observacaoPedidos += "Pedidos Faturados: ";
                        foreach (OrganizaNfItemClass item in nfTmp.itens.Values)
                        {
                            observacaoPedidos += "" + item.Pedido + " - ";
                        }

                        observacaoPedidos = observacaoPedidos.Substring(0, observacaoPedidos.Length - 3);
                    }



                    nf.Observacoes += observacaoDevolucaoMaterial + " " + emitenteCompleto.ObservacaoEmitente + " " + cliObsPadraoNfe + " " + observacaoPedidos;

                    if (!string.IsNullOrWhiteSpace(obsEntregaFutura))
                    {
                        nf.Observacoes += " " + obsEntregaFutura;
                    }

                    foreach (string obsAdd in observacoesAdd)
                    {
                        nf.Observacoes += " " + obsAdd;
                    }

                    foreach (string obsAdd in observacoesFiscoAdd)
                    {
                        nf.ObservacoesFisco += " " + obsAdd ;
                    }

                    if (nfMateriaisSeparada)
                    {
                        foreach (string obsAdd in observacoesMateriaisAdd)
                        {
                            nfDevolucaoMateriais.Observacoes += " " + obsAdd;
                        }

                        foreach (string obsAdd in observacoesFiscoMateriaisAdd)
                        {
                            nfDevolucaoMateriais.ObservacoesFisco += " " + obsAdd ;
                        }
                    }



                    #endregion

                    if (notasReferenciadas.Count > 0)
                    {
                        nf.CollectionNfNotasRelacionadasClassNfPrincipal = new BindingList<NfNotasRelacionadasClass>();
                        foreach (string notaReferenciada in notasReferenciadas)
                        {
                            nf.CollectionNfNotasRelacionadasClassNfPrincipal.Add(
                                new NfNotasRelacionadasClass(Usuario, conn)
                                {
                                    Chave = notaReferenciada,
                                    NfPrincipal = nf
                                });
                        }
                    }


                    //Visualiza a NF
                    if (!semVisualizacao)
                    {
                        VisualNFeForm form = new VisualNFeForm(nf, idEmbarque, VisualNFeFormUtilizacao.Aceite);
                        form.ShowDialog();
                        if (form.NFeRecusada)
                        {
                            return false;
                        }

                        if (nfMateriaisSeparada)
                        {
                            form = new VisualNFeForm(nfDevolucaoMateriais, idEmbarque, VisualNFeFormUtilizacao.Aceite);
                            form.ShowDialog();
                            if (form.NFeRecusada)
                            {
                                return false;
                            }
                        }
                    }

                    //NFe nova, envio automático receita

                    if (AmbienteEmissaoNFe == Ambiente.Homologacao)
                    {
                        nf.NfCliente.Razao = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                        nf.IdentificacaoAmbiente = 2;
                        if (nfMateriaisSeparada)
                        {
                            nfDevolucaoMateriais.NfCliente.Razao = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                            nfDevolucaoMateriais.IdentificacaoAmbiente = 2;
                        }
                    }

                    try
                    {

                        nf.Save(ref command);
                        if (nfMateriaisSeparada)
                        {
                            nfDevolucaoMateriais.Save(ref command);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao salvar a NF.\r\n" + e.Message);
                    }

                    if (contasNotaAtual != null)
                    {
                        foreach (ContaReceberClass receber in contasNotaAtual)
                        {
                            receber.NfPrincipal = nf;
                            contasReceber.Add(receber);
                        }
                    }

                    nfs.Add(nf);
                    notasEmitidas.Add(new nfEmitida(nfTmp, nf, emitenteCompleto));




                    

                    if (nfTmp.EnvioTerceiros)
                    {
                        NfPrincipalClass nfTerceiro = EmiteNFTerceiro(nfTmp, observacaoCustomizada, ref command);
                        NfDependeClass depende = new NfDependeClass(Usuario,conn)
                        {
                            NfPrincipal = nfTerceiro,
                            NfPrincipalDepende = nf
                        };

                        nfTerceiro.EnviarNfeReceita = false;
                        nfTerceiro.Save(ref command);

                        depende.Save(ref command);
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao emitir a Nota Fiscal.\r\n" + e.Message);
            }

            return true;
        }


        private void BuscaObservacoesAdicionais(int cfop, NcmClass ncm, string cst, ref List<string> observacoes, ref List<string> observacoesFisco)
        {

            List<ObservacaoAdicionalNfeClass> possiveisObs = new ObservacaoAdicionalNfeClass(Usuario, conn).Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("Cfop", cfop)
            }).ConvertAll(a => (ObservacaoAdicionalNfeClass) a);


            

            foreach (ObservacaoAdicionalNfeClass obs in possiveisObs)
            {
                if (obs.Ncm == null || obs.Ncm == ncm)
                {
                    if (string.IsNullOrEmpty(obs.CstIcms) || obs.CstIcms == cst)
                    {
                        if (!string.IsNullOrEmpty(obs.Observacao) && !observacoes.Contains(obs.Observacao))
                        {
                            observacoes.Add(obs.Observacao);
                        }

                        if (!string.IsNullOrEmpty(obs.ObservacaoFisco) && !observacoesFisco.Contains(obs.ObservacaoFisco))
                        {
                            observacoesFisco.Add(obs.ObservacaoFisco);
                        }
                    }
                }
            }
        }

        private class ProdutoMaterialKey : IEquatable<ProdutoMaterialKey>
        {
            public long? IdProduto { get; }
            public long? IdMaterial { get; }

            public ProdutoMaterialKey(long? idProduto, long? idMaterial)
            {
                IdProduto = idProduto;
                IdMaterial = idMaterial;
            }

            public bool Equals(ProdutoMaterialKey other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return IdProduto == other.IdProduto && IdMaterial == other.IdMaterial;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ProdutoMaterialKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (IdProduto.GetHashCode() * 397) ^ IdMaterial.GetHashCode();
                }
            }
        }

        private void carregarMateriaisCliente(ref organizaNfClass nfTmp)
        {
            try
            {

                var distinctItems = nfTmp.IdsPedidoItemLinha0.Distinct();

                foreach (int idPedidoItemLinha0 in distinctItems)
                {
           

                    Dictionary<ProdutoMaterialKey, List<PedidoItemLoteClienteClass>> itensDevolver = new Dictionary<ProdutoMaterialKey, List<PedidoItemLoteClienteClass>>();

                    PedidoItemClass pedidoItem = PedidoItemClass.GetEntidade(idPedidoItemLinha0, Usuario, conn);

                    List<PedidoItemLoteClienteClass> possiveisLotes = pedidoItem.CollectionPedidoItemLoteClienteClassPedidoItem.ToList();
                    foreach (PedidoItemLoteClienteClass pedidoLote in possiveisLotes)
                    {
                        ProdutoMaterialKey chave = new ProdutoMaterialKey(pedidoLote.Lote.Produto?.ID, pedidoLote.Lote.Material?.ID);
                        if (!itensDevolver.ContainsKey(chave))
                        {
                            itensDevolver.Add(chave,new List<PedidoItemLoteClienteClass>());
                        }
                        itensDevolver[chave].Add(pedidoLote);
                    }



                    foreach (KeyValuePair<ProdutoMaterialKey, List<PedidoItemLoteClienteClass>> pair in itensDevolver)
                    {
                        double qtdTotalDevolverItem = pair.Value.Sum(a => a.Quantidade);
                        double saldoDevolucao = pair.Value.Sum(a => a.SaldoDevolucao);

                        OrganizaNfItemClass itemNivel0 = nfTmp.getItemLinha0(idPedidoItemLinha0);
                        double qtdProdutoNota = itemNivel0.Quantidade;

                        double qtdFaturar = Math.Round((qtdProdutoNota * qtdTotalDevolverItem) / pedidoItem.Quantidade, 4);

                        if (qtdFaturar > saldoDevolucao)
                        {
                            qtdFaturar = saldoDevolucao;
                        }

                        int i = 0;
                        while (qtdFaturar>0)
                        {
                            if (i >= pair.Value.Count)
                            {
                                throw new ExcecaoTratada("Quantidade de lotes cliente insuficiente pra atender a quantidade prevista. Acione o Suporte IWT");
                            }

                            PedidoItemLoteClienteClass lote = pair.Value[i];

                            double qtdDoLote = 0;
                            if (lote.SaldoDevolucao >= qtdFaturar)
                            {
                                qtdDoLote = qtdFaturar;
                            }
                            else
                            {
                                qtdDoLote = lote.SaldoDevolucao;
                            }

                            if (qtdDoLote > 0)
                            {
                                nfTmp.Materiais.Add(new organizaNfMaterialClienteClass(
                                        Convert.ToInt32(lote.ID),
                                        Convert.ToInt32(lote.Lote.ID),
                                        lote.Lote.CodigoItemFornecedorCliente,
                                        lote.Lote.DescricaoItemFornecedorCliente,
                                        lote.Lote.NcmItemFornecedorCliente,
                                        null,
                                        lote.Lote.CodBenefFiscalItemFornecedorCliente,
                                        lote.Lote.UnidadeItemFornecedorCliente,
                                        (int?)(pair.Key.IdProduto),
                                        (int?)pair.Key.IdMaterial,
                                        qtdDoLote,
                                        lote.SaldoDevolucao,
                                        lote.Lote.ValorUnitario,
                                        lote.Lote.NfSerie,
                                        lote.Lote.NfNumero,
                                        lote.Lote.NfData,
                                        lote.Lote.SaldoDevolucao
                                    )
                                );
                            }

                            qtdFaturar = Math.Round(qtdFaturar - qtdDoLote, 4);
                            i++;
                        }

                       

                    }



                    //Antiga
                    /*
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    command.CommandText =
                        "SELECT  " +
                        "  public.pedido_item_lote_cliente.id_pedido_item_lote_cliente, " +
                        "  public.lote.id_lote, " +
                        "  public.pedido_item_lote_cliente.plc_quantidade, " +
                        "  public.pedido_item_lote_cliente.plc_saldo_devolucao, " +
                        "  public.lote.id_produto, " +
                        "  public.lote.id_material, " +
                        "  public.lote.lot_nf_serie, " +
                        "  public.lote.lot_nf_numero, " +
                        "  public.lote.lot_nf_data, " +
                        "  public.lote.lot_valor_unitario, " +
                        "  public.lote.lot_codigo_item_fornecedor_cliente, " +
                        "  public.lote.lot_descricao_item_fornecedor_cliente, " +
                        "  public.lote.lot_ncm_item_fornecedor_cliente, " +
                        "  public.lote.lot_cod_benef_fiscal_item_fornecedor_cliente, " +
                        "  public.lote.lot_unidade_item_fornecedor_cliente, " +
                        "  public.pedido_item.pei_quantidade, " +
                        "  public.lote.lot_saldo_devolucao " +
                        "FROM " +
                        "  public.pedido_item_lote_cliente " +
                        "  INNER JOIN public.lote ON (public.pedido_item_lote_cliente.id_lote = public.lote.id_lote) " +
                        "  INNER JOIN public.pedido_item ON (public.pedido_item_lote_cliente.id_pedido_item = public.pedido_item.id_pedido_item) " +
                        "WHERE " +
                        "  public.pedido_item_lote_cliente.id_pedido_item = :id_pedido_item ";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = idPedidoItemLinha0;

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        int? idProduto = null;
                        if (read["id_produto"] != DBNull.Value)
                        {
                            idProduto = Convert.ToInt32(read["id_produto"]);
                        }

                        int? idMaterial = null;
                        if (read["id_material"] != DBNull.Value)
                        {
                            idMaterial = Convert.ToInt32(read["id_material"]);
                        }

                        double saldo = Convert.ToDouble(read["plc_saldo_devolucao"]);

                        if (saldo <= 0)
                        {
                            throw new Exception("O lote do cliente não possui mais saldo disponível.");
                        }

                        double quantidadeOriginal = Convert.ToDouble(read["plc_quantidade"]);
                        double quantidadeOriginalPedido = Convert.ToDouble(read["pei_quantidade"]);

                        OrganizaNfItemClass itemNivel0 = nfTmp.getItemLinha0(idPedidoItemLinha0);
                        double qtdFaturar = Math.Round((itemNivel0.Quantidade*quantidadeOriginal)/quantidadeOriginalPedido, 4);

                        if (qtdFaturar > saldo)
                        {
                            qtdFaturar = saldo;
                        }

                        nfTmp.Materiais.Add(new organizaNfMaterialClienteClass(
                            Convert.ToInt32(read["id_pedido_item_lote_cliente"]),
                            Convert.ToInt32(read["id_lote"]),
                            read["lot_codigo_item_fornecedor_cliente"].ToString(),
                            read["lot_descricao_item_fornecedor_cliente"].ToString(),
                            read["lot_ncm_item_fornecedor_cliente"].ToString(),
                            null,
                            read["lot_cod_benef_fiscal_item_fornecedor_cliente"].ToString(),
                            read["lot_unidade_item_fornecedor_cliente"].ToString(),
                            idProduto,
                            idMaterial,
                            qtdFaturar,
                            saldo,
                            Convert.ToDouble(read["lot_valor_unitario"]),
                            read["lot_nf_serie"].ToString(),
                            read["lot_nf_numero"].ToString(),
                            Convert.ToDateTime(read["lot_nf_data"]),
                            Convert.ToDouble(read["lot_saldo_devolucao"])
                            )
                            );





                    }

                    read.Close();
                 */  
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os itens de materiais do cliente.\r\n" + e.Message, e);
            }
        }

        private void updateSaldos(ref nfEmitida nfEmitida, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                try
                {
                    LogClass.EscreverLog("EmissãoNfe-UpdateSaldos:" + nfEmitida.nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                }
                catch
                {
                }

                string sql1;
                foreach (OrganizaNfItemClass item in nfEmitida.infosNota.itens.Values)
                {
                    sql1 = "";
                    string sql2 = "";

                    //Atualizar Saldos
                    if (item.PedidoNovo)
                    {
                        sql1 += "UPDATE pedido_item SET pei_saldo = pei_saldo - " + item.Quantidade.ToString("F5", CultureInfo.InvariantCulture) + " WHERE id_pedido_item=" + item.IdPedidoItem + "; ";
                        sql2 += "UPDATE pedido_item SET pei_status= CASE pei_saldo WHEN 0 THEN 1 ELSE pei_status END, pei_data_encerramento=CASE pei_saldo WHEN 0 THEN NOW() ELSE NULL END WHERE id_pedido_item=" + item.IdPedidoItem + "; ";
                    }
                    else
                    {
                        sql1 += "UPDATE pedido_item SET pei_saldo = pei_saldo - " + item.Quantidade.ToString("F5", CultureInfo.InvariantCulture) + " WHERE pei_numero LIKE '" + item.Oc + "' AND pei_posicao=" + item.Pos + " AND pei_sub_linha=0; ";
                        sql2 += "UPDATE pedido_item SET pei_status= CASE pei_saldo WHEN 0 THEN 1 ELSE pei_status END WHERE pei_numero LIKE '" + item.Oc + "' AND pei_posicao=" + item.Pos + " AND pei_sub_linha=0; ";
                    }



                    //Atualiza o saldo do item configurado;
                    sql1 += "UPDATE order_item_etiqueta SET oie_saldo = oie_saldo-" + item.Quantidade.ToString("F5", CultureInfo.InvariantCulture) + " WHERE id_order_item_etiqueta=" + item.Id + "; ";
                    sql2 += "UPDATE order_item_etiqueta SET oie_status_pedido= CASE oie_saldo WHEN 0 THEN 'E' ELSE oie_status_pedido END WHERE id_order_item_etiqueta=" + item.Id + "; ";

                    command.CommandText = sql1;
                    command.ExecuteNonQuery();

                    command.CommandText =
                        "SELECT  " +
                        "  public.pedido_item.pei_saldo / public.pedido_item.pei_quantidade AS razao " +
                        "FROM " +
                        "  public.pedido_item " +
                        " WHERE id_pedido_item=" + item.IdPedidoItem + "; ";
                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    read.Read();
                    double razao = Convert.ToDouble(read["razao"]);
                    read.Close();
                    try
                    {
                        command.CommandText = sql2;
                        command.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        throw new Exception("Erro ao atualizar Status dos pedidos.\r\n" + e.Message);
                    }

                    command.CommandText =
                        "UPDATE public.order_item_etiqueta SET oie_saldo = oie_quantidade*" + razao.ToString("F10", CultureInfo.InvariantCulture) + " WHERE  public.order_item_etiqueta.oie_order_number = '" + item.Oc +
                        "' AND public.order_item_etiqueta.oie_order_pos = 	" + item.Pos + " AND id_cliente =	" + item.IdCliente + "	";

                    command.ExecuteNonQuery();

                }


                #region Saldos Materiais Cliente

                sql1 = "";


                if (nfEmitida.infosNota.devolverMateriaisCliente)
                {

                    //try
                    //{

                    //    JsonSerializerSettings settings = new JsonSerializerSettings()
                    //    {
                    //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    //    };
                    //    string dados = JsonConvert.SerializeObject(nfEmitida, settings);

                    //    Log.Registrar(IWTLogSeveridade.Info, "BAIXA-MATERIAIS-LOTE", this.GetType().ToString(), "updateSaldos", dados, conn.ConnectionString);
                    //}
                    //catch { }



                    foreach (organizaNfMaterialClienteClass mat in nfEmitida.infosNota.Materiais)
                    {
                        sql1 += "UPDATE pedido_item_lote_cliente SET plc_saldo_devolucao = plc_saldo_devolucao - " + mat.Quantidade.ToString("F5", CultureInfo.InvariantCulture) + " WHERE id_pedido_item_lote_cliente=" + mat.idPedidoItemLoteCliente + "; ";
                        sql1 += "UPDATE lote SET lot_saldo_devolucao = lot_saldo_devolucao -" + mat.Quantidade.ToString("F5", CultureInfo.InvariantCulture) + " WHERE id_lote = " + mat.idLote + "; ";
                        sql1 += "UPDATE lote SET lot_situacao = 1, lot_saldo_devolucao = 0 WHERE lot_saldo_devolucao < 0.00001; ";


                        if (mat.idMaterial.HasValue)
                        {
                            EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoMaterial(MaterialClass.GetEntidade(mat.idMaterial.Value, Usuario, conn), mat.Quantidade * -1,
                                "Devolução Material do Cliente",
                                " NF Nº" + nfEmitida.nf.Numero,
                                this.Usuario, false, ref command, false);
                        }
                        else
                        {
                            EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoProduto(ProdutoClass.GetEntidade(mat.idProduto.Value, Usuario, conn), mat.Quantidade * -1,
                                "Devolução Produtos do Cliente",
                                " NF Nº" + nfEmitida.nf.Numero,
                                this.Usuario, false, ref command, false);
                        }
                    }

                    command.CommandText = sql1;
                    command.ExecuteNonQuery();
                }

                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar os saldos.\r\n" + e.Message);
            }
        }

        private void insertAtendimento(nfEmitida nfEmitida, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                LogClass.EscreverLog("EmissãoNfe-Atendimentos:" + nfEmitida.nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
            }
            catch { }

            try
            {
                command.CommandText = " INSERT INTO                 " +
                                       "   public.atendimento        " +
                                       " (                           " +
                                       "   id_nf_principal,          " +
                                       "   id_order_item_etiqueta,   " +
                                       "   id_order_item_etiqueta_conferencia, " +
                                       "   id_pedido_item, " +
                                       "   ate_quantidade,           " +
                                       "   ate_volumes,              " +
                                       "   ate_atlas,                " +
                                       "   ate_linha_nf,             " +
                                       "   ate_usuario,              " +
                                       "   ate_data_hora             " +
                                       " )                           " +
                                       " VALUES (                    " +
                                       "   :id_nf_principal,         " +
                                       "   :id_order_item_etiqueta,  " +
                                       "   :id_order_item_etiqueta_conferencia, " +
                                       "   :id_pedido_item, " +
                                       "   :ate_quantidade,          " +
                                       "   :ate_volumes,             " +
                                       "   :ate_atlas,               " +
                                       "   :ate_linha_nf,            " +
                                       "   :ate_usuario,             " +
                                       "   :ate_data_hora            " +
                                       " );";


                foreach (OrganizaNfItemClass item in nfEmitida.infosNota.itens.Values)
                {

                    foreach (OrganizaNfSubItem subItem in item.SubItens)
                    {



                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = nfEmitida.nf.ID;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = item.Id;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta_conferencia", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = subItem.IdOrderItemEtiquetaConferencia;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                        if (item.PedidoNovo)
                        {
                            command.Parameters[command.Parameters.Count - 1].Value = item.IdPedidoItem;
                        }
                        else
                        {
                            command.Parameters[command.Parameters.Count - 1].Value = null;
                        }

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_quantidade", NpgsqlDbType.Double));
                        command.Parameters[command.Parameters.Count - 1].Value = subItem.Quantidade;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_volumes", NpgsqlDbType.Double));
                        command.Parameters[command.Parameters.Count - 1].Value = 1;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_atlas", NpgsqlDbType.Double));

                        if (item.PedidoNovo)
                        {
                            if (nfEmitida.infosNota.cliEspecial == 1 && nfEmitida.infosNota.utilizaControleEspecialCliente)
                            {
                                command.Parameters[command.Parameters.Count - 1].Value = 1;

                            }
                            else
                            {
                                command.Parameters[command.Parameters.Count - 1].Value = 0;
                            }
                        }
                        else
                        {
                            if (nfEmitida.infosNota.idClienteAccess.Trim().ToUpper() == "ATLAS EL" || nfEmitida.infosNota.idClienteAccess.Trim().ToUpper() == "ATLAS ER")
                            {
                                command.Parameters[command.Parameters.Count - 1].Value = 1;
                            }
                            else
                            {
                                command.Parameters[command.Parameters.Count - 1].Value = 0;
                            }
                        }

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_linha_nf", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = item.IndiceLinha;

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_usuario", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = this.Usuario.Login;

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ate_data_hora", NpgsqlDbType.Timestamp));
                        command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();

                        command.ExecuteNonQuery();

                        try
                        {
                            LogClass.EscreverLog("EmissãoNfe-AtendimentoSave:" + nfEmitida.nf.Numero+" - "+item.IndiceLinha, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                        }
                        catch { }
                    }
                }

            }
            catch (Exception b)
            {
                throw new Exception("Erro ao Inserir Atendimento.\r\n" + b.Message);
            }
        }

        private void updateEmbarque(string idEmbarque, ref IWTPostgreNpgsqlCommand command, TipoEmissaoNFe emissaoNFe)
        {

            try
            {
                LogClass.EscreverLog("EmissãoNfe-UpdateEmbarque:" + idEmbarque, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
            }
            catch { }
            if (emissaoNFe == TipoEmissaoNFe.EASI)
            {
                //Coloca o embarque em espera da autorização da NFe
                command.CommandText = "UPDATE embarque SET emb_nf_emitida = 1 WHERE id_embarque=" + idEmbarque;
                command.ExecuteNonQuery();
            }
            else
            {
                //encerra o embarque normalmente
                EmbarqueClass.MarcarEmbarqueEncerrado(int.Parse(idEmbarque), ref command);
            }
        }

        public NfPrincipalClass EmitirNFRemessa(List<FaturamentoRemessaDto> itensFaturar,IObservacaoCustomizada observacaoCustomizada, ref IWTPostgreNpgsqlCommand command, EasiEmissorNFe emitenteNfe)
        {


            TipoEmissaoNFe tipoEmissaoNFe = (TipoEmissaoNFe)Enum.ToObject(typeof(TipoEmissaoNFe), int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)));

            Ambiente ambienteEmissaoNFe = Ambiente.Producao;
            if (IWTConfiguration.Conf.getBoolConf(Constants.AMBIENTE_EMISSAO_NFE_HOMOLOGACAO))
            {
                ambienteEmissaoNFe = Ambiente.Homologacao;
            }


            try
            {
                EmitenteClass emitenteCompleto;
                PisCofinsInfo pisCofins;
                NfEmitenteClass emitente;

                emitente = NotaFiscalFuncoesAuxiliares.CarregaEmitente(conn, out emitenteCompleto, emitenteNfe, out pisCofins);
                PisCofinsInfo pisCofinsDefault = new PisCofinsInfo(
                    emitenteCompleto.PisCst,
                    Convert.ToInt16(emitenteCompleto.PisImpostoRetido),
                    emitenteCompleto.PisModalidade,
                    emitenteCompleto.PisAliquota,

                    emitenteCompleto.CofinsCst,
                    Convert.ToInt16(emitenteCompleto.CofinsImpostoRetido),
                    emitenteCompleto.CofinsModalidade,
                    emitenteCompleto.CofinsAliquota
                );

                FaturamentoRemessaDto dadosItemPrincipal = itensFaturar[0];

                NfEmitenteEnderecoClass emitenteEndereco;
                emitenteEndereco = emitente.NfEmitenteEndereco;


                CargaTributosDto dtoTributosPrincipal = CargaTributosDto.CarregaTributos(dadosItemPrincipal, emitenteCompleto.CidadeEntidade.Estado.ID, ref command, pisCofinsDefault);

                #region Dados Principais NF

                NfPrincipalClass nf;
                try
                {
                    int numeroNota;
                    int serie = 1;

                    numeroNota = NFeOperacoes.getProximoNumeroNf(emitente.CnpjCpf, "55", command, ambienteEmissaoNFe == Ambiente.Homologacao ? TAmb.Homologacao : TAmb.Producao, out serie);


                    FormaPagamento formaPagto = FormaPagamento.AVista;
             

                    Processo procEmi;
                    procEmi = Processo.AplicativoContribuinte;
                    nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        Numero = numeroNota,
                        NaturezaOperacao = dtoTributosPrincipal.NaturezaOperacao,
                        Serie = serie,
                        FormaPagamento = formaPagto,
                        ModeloDocFiscal = "55",
                        DataEmissao = Configurations.DataIndependenteClass.GetData(),
                        DataSaidaEntrada = Configurations.DataIndependenteClass.GetData(),
                        Tipo = TipoNota.Saida,
                        CodMunicipioFatoGerador = emitenteEndereco.CodMunicipio,
                        FormatoImpressao = FormatoImpressao.Retrato,
                        FormaEmissao = FormaEmissaoNFe.Normal,
                        IdentificacaoAmbiente = ambienteEmissaoNFe == Ambiente.Producao ? 1 : 2,
                        FinalidadeEmissao = Finalidade.Normal,
                        ProcessoEmissao = procEmi,
                        VersaoProcessoEmissao = emitenteCompleto.VersaoEmissorNFe,
                        Observacoes = "",
                        TipoEmitente = "P",
                        Situacao = "N",
                        ConsumidorFinal = dtoTributosPrincipal.ConsumidorFinal,
                        PresencaComprador = dtoTributosPrincipal.PresencaConsumidor,
                        EnviarNfeReceita = true
                    };

                    nf.Homologacao = ambienteEmissaoNFe == Ambiente.Homologacao;

                    nf.NfAtributo = new NfAtributoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        VersaoLayout = "3.10",
                        IdNfe = "NFe"
                    };
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os campos principais da NF.\r\n" + e.Message);
                }

                try
                {
                    nf.NfEmitente = new NfEmitenteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        Razao = emitente.Razao,
                        NomeFantasia = emitente.NomeFantasia,
                        Ie = emitente.Ie,
                        IeSt = emitente.IeSt,
                        Im = emitente.Im,
                        Cnae = emitente.Cnae,
                        CnpjCpf = emitente.CnpjCpf,
                        Crt = emitente.Crt,
                        AliquotaSimplesServico = 0
                    };


                    nf.NfEmitente.NfEmitenteEndereco = new NfEmitenteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        NfEmitente = nf.NfEmitente,
                        Logradouro = emitenteEndereco.Logradouro,
                        Numero = emitenteEndereco.Numero,
                        Complemento = emitenteEndereco.Complemento,
                        Bairro = emitenteEndereco.Bairro,
                        CodMunicipio = emitenteEndereco.CodMunicipio,
                        NomeMunicipio = emitenteEndereco.NomeMunicipio,
                        SiglaUf = emitenteEndereco.SiglaUf,
                        Cep = emitenteEndereco.Cep,
                        CodPais = emitenteEndereco.CodPais,
                        NomePais = emitenteEndereco.NomePais,
                        Telefone = emitenteEndereco.Telefone
                    };
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do Emitente da NF.\r\n" + e.Message);
                }


                try
                {
                    if (emitenteCompleto.AutorizadosDownloadNf != null && emitenteCompleto.AutorizadosDownloadNf.Count > 0)
                    {
                        foreach (string autorizado in emitenteCompleto.AutorizadosDownloadNf)
                        {
                            nf.CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Add(new NfPrincipalAutorizacaoXmlClass(Usuario, conn)
                            {
                                Documento = autorizado.Replace("/", "").Replace(".", "").Replace("-", ""),
                                NfPrincipal = nf
                            });
                        }

                    }


                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do Emitente da NF.\r\n" + e.Message);
                }


                #endregion

                #region Fornecedor


                FornecedorClass fornecedor = null;
                try
                {
                    fornecedor = dadosItemPrincipal.Fornecedor;

                    if (fornecedor == null)
                    {
                        throw new Exception("Fornecedor não cadastrado!");
                    }



                    if (fornecedor.Estado == null || string.IsNullOrWhiteSpace(fornecedor.Estado.Sigla))
                    {
                        throw new Exception("Estado do endereço do fornecedor é inválido.");
                    }

                    if (fornecedor.Cidade == null || fornecedor.Cidade.CodigoIbge == 0)
                    {
                        throw new Exception("Municipio do endereço fornecedor é inválido.");
                    }



                    IWTNFIndicadorIE? indicadorIE = null;
                    switch (fornecedor.IndicadorIe)
                    {
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.ContribuinteICMS:
                            indicadorIE = IWTNFIndicadorIE.ContribuinteICMS;
                            break;
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.Isento:
                            indicadorIE = IWTNFIndicadorIE.Isento;
                            break;
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.NaoContribuinte:
                            indicadorIE = IWTNFIndicadorIE.NaoContribuinte;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }



                    nf.NfCliente = new NfClienteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        Razao = fornecedor.RazaoSocial,
                        NomeFantasia = fornecedor.NomeFantasia,
                        Ie = fornecedor.InscEstadual?.Trim().Replace(".", "").Replace("/", "").Replace("-", ""),
                        CnpjCpf = fornecedor.Cnpj?.Replace(".", "").Replace("/", "").Replace("-", ""),
                        Isuf = fornecedor.InscricaoSuframa,
                        Email = fornecedor.Email.ToString(),
                        IndicadorIe = indicadorIE,
                    };

                    string cepCliente = fornecedor.Cep.Trim().Replace("-", "");
                    if (cepCliente.Length != 8)
                    {
                        throw new ExcecaoTratada("O cep do fornecedor é inválido: " + fornecedor.Cep);
                    }

                    if (fornecedor.Cidade == null)
                    {
                        throw new ExcecaoTratada("O fornecedor não possui cidade definda");
                    }

                    if (fornecedor.Estado == null)
                    {
                        throw new ExcecaoTratada("O fornecedor não possui estado defindo");
                    }

                    if (!fornecedor.CodigoPais.HasValue)
                    {
                        throw new ExcecaoTratada("O fornecedor não possui código do país defindo");
                    }

                    nf.NfCliente.NfClienteEndereco = new NfClienteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        Logradouro = fornecedor.Endereco.ToString(),
                        Numero = fornecedor.EndNumero.ToString(),
                        Complemento = fornecedor.EndComplemento.ToString(),
                        Bairro = fornecedor.Bairro.ToString(),
                        CodMunicipio = fornecedor.Cidade.CodigoIbge,
                        NomeMunicipio = fornecedor.Cidade.Nome.ToString(),
                        SiglaUf = fornecedor.Estado.Sigla.ToString(),
                        Cep = cepCliente,
                        CodPais = fornecedor.CodigoPais.Value,
                        NomePais = fornecedor.Pais.ToString(),
                        Telefone = fornecedor.Fone1.ToString().Replace("(", "").Trim().Replace(")", "").Replace("-", "").Replace(" ", "")

                    };


                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do fornecedor da NF.\r\n" + e.Message);
                }

                #endregion

                #region Itens do Pedido

                int totalVolumes = 0;

                
                int numeroLinhaNF = 1;
                double pesoTotalItens = 0;

                


                List<string> observacoesAdd = new List<string>();
                List<string> observacoesFiscoAdd = new List<string>();
                string opAtual = null;

                try
                {
                    nf.CollectionNfItemClassNfPrincipal = new BindingList<NfItemClass>();

                    

                    foreach (FaturamentoRemessaDto item in itensFaturar)
                    {
                        if (item.Quantidade <= 0)
                        {
                            continue;
                        }

                        opAtual = item.OrdemProducao.ID.ToString();


                        item.OrdemProducaoEnvioTerceiros.NfPrincipal = nf;

                        //TODO: Verificar se isso faz sentido ou se o sistema deve perguntar pro usuário a qtd de volumes
                        totalVolumes += (int) Math.Ceiling(item.Quantidade);



                        CargaTributosDto tributos = CargaTributosDto.CarregaTributos(item, emitenteCompleto.CidadeEntidade.Estado.ID, ref command, pisCofinsDefault);
                        DadosFiscaisItemDto dadosFiscaisItem = DadosFiscaisItemDto.GetDadosFiscaisProduto(item.OrdemProducao.Produto);

                        double precoTotal;
                        EasiValidaPrecos validaPreco;

                        string descricao = "";


                        string codItem;
                        NcmClass ncm;
                        int CFOP;
                        string codigoBeneficioFiscal = null;


                        BibliotecaEntidades.Base.IncidenciaImposto incideIcms = IncidenciaImposto.Incide;
                        string cstSuspensaoIcms = null;
                        int csoSuspensaoIcms = 0;
                        IncidenciaImposto incideIPI = IncidenciaImposto.Incide;
                        string cstSuspensaoIPI = null;
                        IncidenciaImposto incidePIS = IncidenciaImposto.Incide;
                        string cstSuspensaoPIS = null;
                        IncidenciaImposto incideCofins = IncidenciaImposto.Incide;
                        string cstSuspensaoCofins = null;


                        #region Busca dados Pedido Novo

                        //Descrição do Item
                        descricao += item.OrdemProducao.Produto.Descricao;

                        codItem = item.OrdemProducao.Produto.Codigo;


                        //CFOP
                       
                            CFOP = tributos.Cfop;
                       


                        incideIcms = tributos.IcmsIncide;
                        if (incideIcms == IncidenciaImposto.Suspenso)
                        {
                            cstSuspensaoIcms = tributos.IcmsCst;
                            if (cstSuspensaoIcms == "300" || cstSuspensaoIcms == "400")
                            {
                                csoSuspensaoIcms = Convert.ToInt32(cstSuspensaoIcms);
                                cstSuspensaoIcms = "SN";
                            }
                        }

                       

                            incideIPI = tributos.IpiIncide;
                            if (incideIPI == IncidenciaImposto.Suspenso)
                            {
                                cstSuspensaoIPI = tributos.IpiCst;
                            }
                       


                        incideCofins = tributos.CofinsIncide;
                        if (incideCofins == IncidenciaImposto.Suspenso)
                        {
                            cstSuspensaoCofins = tributos.CofinsCst;
                        }

                        incidePIS = tributos.PisIncide;
                        if (incidePIS == IncidenciaImposto.Suspenso)
                        {
                            cstSuspensaoPIS = tributos.PisCst;
                        }

                        #endregion


                        ProdutoPrecoClass regraPreco = item.OrdemProducao.Produto.CollectionProdutoPrecoClassProduto.Where(a => a.Vigente).FirstOrDefault();
                        if (regraPreco == null)
                        {
                            throw new ExcecaoTratada("Não existe preço vigente para o item " + item.OrdemProducao.Produto);
                        }

                        if (item.OrdemProducao.Produto.CalculoPreco != TipoCalculoPrecoProdudo.Fixo)
                        {
                            throw new ExcecaoTratada("Para que o produto " + item.OrdemProducao.Produto + " possa ser faturado na remessa ele deve ter um preço fixo cadastrado");
                        }

                        double precoUnitario = regraPreco.Preco;
                        precoTotal = precoUnitario * item.Quantidade;





                        if (descricao.Length > 60)
                        {
                            descricao = descricao.Substring(0, 60);
                        }

                        ncm = dadosFiscaisItem.NCM;



                        if (ncm != null)
                        {
                            NcmBeneficioFiscalClass beneficioFiscal = ncm.CollectionNcmBeneficioFiscalClassNcm.FirstOrDefault(a => a.Estado == fornecedor.Estado && a.Cfop == CFOP);
                            codigoBeneficioFiscal = beneficioFiscal?.CodigoBeneficioFiscal;
                        }




                        pesoTotalItens += (item.OrdemProducao.Produto.PesoUnitario) * item.Quantidade;



                        nf.CollectionNfItemClassNfPrincipal.Add(new NfItemClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            NumeroItem = numeroLinhaNF,
                            Cfop = CFOP,
                        });
                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto =
                            new NfProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                            {
                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Codigo = codItem,
                                Descricao = descricao,
                                Gtin = dadosFiscaisItem.GTIN,
                                Ncm = ncm.Codigo,
                                Cest = ncm.Cest,
                                CodigoBeneficio = codigoBeneficioFiscal,
                                Extipi = dadosFiscaisItem.exTIPI,
                                Genero = dadosFiscaisItem.Genero,
                                Unidade = item.OrdemProducao.Produto.UnidadeMedida?.Abreviada,
                                ValorUnitario = precoUnitario,
                                GtimUnidadeTrinutacao = dadosFiscaisItem.GTIN,
                                UnidadeTributacao = item.OrdemProducao.Produto.UnidadeMedida?.Abreviada,
                                ValorUnitarioTrinutacao = precoUnitario,
                                QuantidadeTributavel = item.Quantidade,
                                ValorTotalTributavel = Math.Round(precoTotal, 2),
                                ValorFrete = 0,
                                ValorDesconto = 0,
                                ValorSeguro = 0,
                                Quantidade = item.Quantidade,
                                Xped = "OPET"+item.OrdemProducaoEnvioTerceiros.ID,
                                NumeroItemPedido = 1
                            };

                        string cstCsosn = "";
                        switch (incideIcms)
                        {
                            case IncidenciaImposto.Incide:
                                cstCsosn = tributos.IcmsCst;


                                switch (tributos.IcmsCst)
                                {
                                    case "41a":
                                        IcmsRetidoForm form2 = new IcmsRetidoForm(codItem + " - " + descricao);
                                        form2.ShowDialog();

                                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                            new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = tributos.IcmsCst,
                                                Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                Aliquota = tributos.IcmsAliquota,
                                                AliquotaSt = tributos.IcmsAliquotaSt,
                                                PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                PercentualMvaSt = tributos.IcmsMvaSt,
                                                CodigoAntecipacaoSt = "X",
                                                PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                SiglaUfDevidoIcms = null,
                                                ValorBcStRetidoRemetente = form2.remetenteBC,
                                                ValorIcmsStRetidoRemetente = form2.remetenteValor,
                                                ValorBcStRetidoDestinatario = form2.destBC,
                                                ValorIcmsStRetidoDestinatario = form2.destValor,
                                                CsoSimples = tributos.IcmsCsoSimples,
                                                AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                            };
                                        break;

                                    case "90b":
                                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                            new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = "90",
                                                Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                Aliquota = tributos.IcmsAliquota,
                                                AliquotaSt = tributos.IcmsAliquotaSt,
                                                PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                PercentualMvaSt = tributos.IcmsMvaSt,
                                                CodigoAntecipacaoSt = "X",
                                                PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                SiglaUfDevidoIcms = null,
                                                ValorBcStRetidoRemetente = 0,
                                                ValorIcmsStRetidoRemetente = 0,
                                                ValorBcStRetidoDestinatario = 0,
                                                ValorIcmsStRetidoDestinatario = 0,
                                                CsoSimples = tributos.IcmsCsoSimples,
                                                AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                            };

                                        break;

                                    default:
                                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                            new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = tributos.IcmsCst,
                                                Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                Aliquota = tributos.IcmsAliquota,
                                                AliquotaSt = tributos.IcmsAliquotaSt,
                                                PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                PercentualMvaSt = tributos.IcmsMvaSt,
                                                CodigoAntecipacaoSt = "X",
                                                PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                SiglaUfDevidoIcms = null,
                                                ValorBcStRetidoRemetente = 0,
                                                ValorIcmsStRetidoRemetente = 0,
                                                ValorBcStRetidoDestinatario = 0,
                                                ValorIcmsStRetidoDestinatario = 0,
                                                CsoSimples = tributos.IcmsCsoSimples,
                                                AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                            };
                                        break;
                                }

                                break;

                            case IncidenciaImposto.NaoIncide:
                                throw new Exception("Icms é obrigatório.");

                            case IncidenciaImposto.Suspenso:
                                cstCsosn = cstSuspensaoIcms;
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                    new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = cstSuspensaoIcms,
                                        Origem = (OrigemMercadoria) Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                        ModalidadeDeterminacaoBc = ModalidadeDeterminacaoBCICMS.ValorOperacao,
                                        Aliquota = 0,
                                        AliquotaSt = 0,
                                        PercentualReducaoBc = 0,
                                        ModalidadeDeterminacaoBcSt = ModalidadeDeterminacaoBCICMSST.MargemValorAgregado,
                                        PercentualReducaoBcSt = 0,
                                        PercentualMvaSt = 0,
                                        CodigoAntecipacaoSt = "X",
                                        PercentualDiferimento = 0,
                                        ObsDiferimento = "",
                                        PercentualBcOperacaoPropria = 0,
                                        SiglaUfDevidoIcms = null,
                                        ValorBcStRetidoRemetente = 0,
                                        ValorIcmsStRetidoRemetente = 0,
                                        ValorBcStRetidoDestinatario = 0,
                                        ValorIcmsStRetidoDestinatario = 0,
                                        CsoSimples = csoSuspensaoIcms,
                                        AliquotaCreditoSimples = 0
                                    };

                                break;
                        }


                        switch (incideIPI)
                        {
                            case IncidenciaImposto.NaoIncide:
                                break;
                            case IncidenciaImposto.Incide:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                    new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        ClasseEnquadramentoCigarrosBebidas = null,
                                        CnpjProdutor = null,
                                        ClasseEnquadramento = tributos.IpiCodEnquadramento,
                                        Cst = tributos.IpiCst,
                                        Aliquota = tributos.IpiAliquota,
                                        ModalidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributos.IpiModTributacao),
                                        QuantidadeVendida = 0
                                    };
                                break;
                            case IncidenciaImposto.Suspenso:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                    new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        ClasseEnquadramentoCigarrosBebidas = null,
                                        CnpjProdutor = null,
                                        ClasseEnquadramento = tributos.IpiCodEnquadramento,
                                        Cst = cstSuspensaoIPI,
                                        Aliquota = 0,
                                        ModalidadeTributacao = ModalidadeTributacao.NaoTributado,
                                        QuantidadeVendida = 0
                                    };
                                break;
                        }


                        switch (incidePIS)
                        {
                            case IncidenciaImposto.NaoIncide:
                                throw new Exception("PIS é obrigatório.");
                            case IncidenciaImposto.Incide:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                                    new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = tributos.PisCst,
                                        Aliquota = tributos.PisAliquota,
                                        ModadlidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributos.PisModTributacao),
                                        ImpostoRetido = tributos.PisImpostoRetido ? (short) 1 : (short) 0
                                    };
                                break;
                            case IncidenciaImposto.Suspenso:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                                    new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = cstSuspensaoPIS,
                                        Aliquota = 0,
                                        ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                        ImpostoRetido = 0
                                    };
                                break;
                        }


                        switch (incideCofins)
                        {
                            case IncidenciaImposto.NaoIncide:
                                throw new Exception("Cofins é obrigatório.");
                            case IncidenciaImposto.Incide:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                                    new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = tributos.CofinsCst,
                                        Aliquota = tributos.CofinsAliquota,
                                        ModadlidadeTributacao = (ModalidadeTributacao) Enum.ToObject(typeof(ModalidadeTributacao), tributos.CofinsModTributacao),
                                        ImpostoRetido = tributos.CofinsImpostoRetido ? (short) 1 : (short) 0
                                    };
                                break;
                            case IncidenciaImposto.Suspenso:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                                    new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = cstSuspensaoCofins,
                                        Aliquota = 0,
                                        ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                        ImpostoRetido = 0
                                    };
                                break;
                        }

                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].CfopPartilhaIcms = tributos.IcmsPartilha;


                        NcmClass ncmReal = (NcmClass) new NcmClass(Usuario, conn).Search(new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("CodigoExato", nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.Ncm)
                        }).FirstOrDefault();

                        if (ncmReal != null)
                        {
                            AliquotaFundoCombatePobrezaClass aliquotaFCP = ncmReal.CollectionAliquotaFundoCombatePobrezaClassNcm.FirstOrDefault(a => a.Estado == fornecedor.Estado);
                            if (aliquotaFCP != null)
                            {
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].AlquotaFundoCombatePobreza = aliquotaFCP.Aliquota;
                            }
                            else
                            {
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].AlquotaFundoCombatePobreza = 0;
                            }



                            BuscaObservacoesAdicionais(CFOP, ncmReal, cstCsosn, ref observacoesAdd, ref observacoesFiscoAdd);
                        }

                        numeroLinhaNF++;

                        opAtual = null;
                    }


                    if (nf.CollectionNfItemClassNfPrincipal.Count == 0)
                    {
                        throw new Exception("Ao menos um item deve ser selecionado.");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados dos itens da NF: OP " + opAtual + "\r\n" +
                                        e.Message);
                }

                #endregion

                #region Transporte

                try
                {
                    if (dadosItemPrincipal.Transporte == null)
                    {
                        //public NfTransporte(NfPrincipal nfPrincipal, short nftModalidade, string nftRazao, string nftIe, string nftEndereco, string nftSiglaUf, string nftMunicipio,
                        //string nftCpfCnpj, int? nftVolumes, double nftPesoLiquido, double nftPesoBruto, string nftPlaca, string nftRegistroAntt, string nftSiglaUfVeiculo,
                        //string nftVolumeEspecie, string nftVolumeMarca)
                        nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            Modalidade = ModalidadeFrete.SemFrete,
                            Razao = "",
                            Ie = "",
                            Endereco = "",
                            SiglaUf = "",
                            Municipio = "",
                            CpfCnpj = "",
                            Volumes = totalVolumes,
                            PesoLiquido = pesoTotalItens,
                            PesoBruto = pesoTotalItens,
                            Placa = null,
                            RegistroAntt = null,
                            SiglaUfVeiculo = null,
                            VolumeEspecie = "Volume",
                            VolumeMarca = ""
                        };
                    }
                    else
                    {

                        TransporteClass transporte = dadosItemPrincipal.Transporte;




                        nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            Modalidade = ModalidadeFrete.Emitente,
                            Razao = transporte.Razao,
                            Ie = string.IsNullOrEmpty(transporte.Ie) ? transporte.Ie : transporte.Ie.Replace("-", "").Replace(".", ""),
                            Endereco = transporte.Endereco,
                            SiglaUf = transporte.Cidade?.Estado?.Sigla,
                            Municipio = transporte.Cidade?.Nome,
                            CpfCnpj = transporte.CpfCnpj,
                            Volumes = totalVolumes,
                            PesoLiquido = pesoTotalItens,
                            PesoBruto = pesoTotalItens,
                            Placa = transporte.Placa.Replace("-", ""),
                            RegistroAntt = transporte.RegistroAntt.ToString(),
                            SiglaUfVeiculo = transporte.EstadoVeiculo?.Sigla,
                            VolumeEspecie = "Volume",
                            VolumeMarca = ""
                        };


                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do transporte da NF.\r\n" + e.Message);
                }

                #endregion

                try
                {
                    NfPrincipalClass.calculaNf(ref nf, this.arrendodamentoNF, Usuario, conn, observacaoCustomizada, false, false);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao calcular a NF.\r\n" + e.Message);
                }

                #region Dados Cobrança
  
                try
                {
                    nf.NfCobranca = new NfCobrancaClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        CollectionNfDuplicataClassNfCobranca = new BindingList<NfDuplicataClass>(new List<NfDuplicataClass>())
                    };

                    nf.CollectionNfPagamentoClassNfPrincipal.Add(new NfPagamentoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        Tipo = NfPagamentoTipo.SemPagamento,
                        Valor = 0,
                    });
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados das duplicatas da NF.\r\n" + e.Message);
                }

                #endregion

                #region Pedido Urgente (Obs)



                #endregion

                #region Observações

                nf.Observacoes += emitenteCompleto.ObservacaoEmitente;


                foreach (string obsAdd in observacoesAdd)
                {
                    nf.Observacoes += " " + obsAdd;
                }

                foreach (string obsAdd in observacoesFiscoAdd)
                {
                    nf.ObservacoesFisco += " " + obsAdd;
                }




                #endregion

       
                //Visualiza a NF
                VisualNFeForm form = new VisualNFeForm(nf, "-1", VisualNFeFormUtilizacao.Aceite);
                form.ShowDialog();
                if (form.NFeRecusada)
                {
                    return null;
                }


                //NFe nova, envio automático receita

                if (ambienteEmissaoNFe == Ambiente.Homologacao)
                {
                    nf.NfCliente.Razao = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                    nf.IdentificacaoAmbiente = 2;
                }

                try
                {

                    nf.Save(ref command);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao salvar a NF.\r\n" + e.Message);
                }

                
                return nf;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao emitir a Nota Fiscal.\r\n" + e.Message);
            }

        }

        private NfPrincipalClass EmiteNFTerceiro(organizaNfClass nfTmp, IObservacaoCustomizada observacaoCustomizada, ref IWTPostgreNpgsqlCommand command)
        {


            TipoEmissaoNFe tipoEmissaoNFe = (TipoEmissaoNFe)Enum.ToObject(typeof(TipoEmissaoNFe), int.Parse(IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)));

            Ambiente ambienteEmissaoNFe = Ambiente.Producao;
            if (IWTConfiguration.Conf.getBoolConf(Constants.AMBIENTE_EMISSAO_NFE_HOMOLOGACAO))
            {
                ambienteEmissaoNFe = Ambiente.Homologacao;
            }


            try
            {
                EmitenteClass emitenteCompleto;
                PisCofinsInfo pisCofins;
                NfEmitenteClass emitente;

                emitente = NotaFiscalFuncoesAuxiliares.CarregaEmitente(conn, out emitenteCompleto, nfTmp.EmissorNFe, out pisCofins);
                PisCofinsInfo pisCofinsDefault = new PisCofinsInfo(
                    emitenteCompleto.PisCst,
                    Convert.ToInt16(emitenteCompleto.PisImpostoRetido),
                    emitenteCompleto.PisModalidade,
                    emitenteCompleto.PisAliquota,

                    emitenteCompleto.CofinsCst,
                    Convert.ToInt16(emitenteCompleto.CofinsImpostoRetido),
                    emitenteCompleto.CofinsModalidade,
                    emitenteCompleto.CofinsAliquota
                );

                NfEmitenteEnderecoClass emitenteEndereco;
                emitenteEndereco = emitente.NfEmitenteEndereco;


                PedidoItemClass pedidoItemPrincipal = PedidoItemClass.GetEntidade(Convert.ToInt64(nfTmp.itens.First().Value.IdPedidoItem), Usuario, conn);

                CargaTributosDto dtoTributosPrincipal = CargaTributosDto.CarregaTributosEnvioTerceiros(pedidoItemPrincipal, emitenteCompleto.CidadeEntidade.Estado.ID, ref command, pisCofinsDefault);

                

                #region Dados Principais NF

                NfPrincipalClass nf;
                try
                {
                    int numeroNota;
                    int serie = 1;

                    numeroNota = NFeOperacoes.getProximoNumeroNf(emitente.CnpjCpf, "55", command, ambienteEmissaoNFe == Ambiente.Homologacao ? TAmb.Homologacao : TAmb.Producao, out serie);


                    FormaPagamento formaPagto = FormaPagamento.AVista;


                    Processo procEmi;
                    procEmi = Processo.AplicativoContribuinte;
                    nf = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        Numero = numeroNota,
                        NaturezaOperacao = dtoTributosPrincipal.NaturezaOperacao,
                        Serie = serie,
                        FormaPagamento = formaPagto,
                        ModeloDocFiscal = "55",
                        DataEmissao = Configurations.DataIndependenteClass.GetData(),
                        DataSaidaEntrada = Configurations.DataIndependenteClass.GetData(),
                        Tipo = TipoNota.Saida,
                        CodMunicipioFatoGerador = emitenteEndereco.CodMunicipio,
                        FormatoImpressao = FormatoImpressao.Retrato,
                        FormaEmissao = FormaEmissaoNFe.Normal,
                        IdentificacaoAmbiente = ambienteEmissaoNFe == Ambiente.Producao ? 1 : 2,
                        FinalidadeEmissao = Finalidade.Normal,
                        ProcessoEmissao = procEmi,
                        VersaoProcessoEmissao = emitenteCompleto.VersaoEmissorNFe,
                        Observacoes = "",
                        TipoEmitente = "P",
                        Situacao = "N",
                        ConsumidorFinal = dtoTributosPrincipal.ConsumidorFinal,
                        PresencaComprador = dtoTributosPrincipal.PresencaConsumidor,
                        EnviarNfeReceita = true
                    };

                    nf.Homologacao = ambienteEmissaoNFe == Ambiente.Homologacao;

                    nf.NfAtributo = new NfAtributoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        VersaoLayout = "3.10",
                        IdNfe = "NFe"
                    };
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os campos principais da NF.\r\n" + e.Message);
                }

                try
                {
                    nf.NfEmitente = new NfEmitenteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        Razao = emitente.Razao,
                        NomeFantasia = emitente.NomeFantasia,
                        Ie = emitente.Ie,
                        IeSt = emitente.IeSt,
                        Im = emitente.Im,
                        Cnae = emitente.Cnae,
                        CnpjCpf = emitente.CnpjCpf,
                        Crt = emitente.Crt,
                        AliquotaSimplesServico = 0
                    };


                    nf.NfEmitente.NfEmitenteEndereco = new NfEmitenteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        NfEmitente = nf.NfEmitente,
                        Logradouro = emitenteEndereco.Logradouro,
                        Numero = emitenteEndereco.Numero,
                        Complemento = emitenteEndereco.Complemento,
                        Bairro = emitenteEndereco.Bairro,
                        CodMunicipio = emitenteEndereco.CodMunicipio,
                        NomeMunicipio = emitenteEndereco.NomeMunicipio,
                        SiglaUf = emitenteEndereco.SiglaUf,
                        Cep = emitenteEndereco.Cep,
                        CodPais = emitenteEndereco.CodPais,
                        NomePais = emitenteEndereco.NomePais,
                        Telefone = emitenteEndereco.Telefone
                    };
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do Emitente da NF.\r\n" + e.Message);
                }


                try
                {
                    if (emitenteCompleto.AutorizadosDownloadNf != null && emitenteCompleto.AutorizadosDownloadNf.Count > 0)
                    {
                        foreach (string autorizado in emitenteCompleto.AutorizadosDownloadNf)
                        {
                            nf.CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Add(new NfPrincipalAutorizacaoXmlClass(Usuario, conn)
                            {
                                Documento = autorizado.Replace("/", "").Replace(".", "").Replace("-", ""),
                                NfPrincipal = nf
                            });
                        }

                    }


                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do Emitente da NF.\r\n" + e.Message);
                }


                #endregion

                #region Cliente

                string cliObsPadraoNfe = "";
                ClienteClass cliente = null;
                try
                {
                    cliente = ClienteClass.GetEntidade(nfTmp.IdClienteEnvioTerceiros,Usuario,command.Connection);

                    IWTNFIndicadorIE? indicadorIE = null;
                    switch (cliente.IndicadorIe)
                    {
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.ContribuinteICMS:
                            indicadorIE = IWTNFIndicadorIE.ContribuinteICMS;
                            break;
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.Isento:
                            indicadorIE = IWTNFIndicadorIE.Isento;
                            break;
                        case BibliotecaEntidades.Base.IWTNFIndicadorIE.NaoContribuinte:
                            indicadorIE = IWTNFIndicadorIE.NaoContribuinte;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }



                    nf.NfCliente = new NfClienteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        Razao = cliente.Nome,
                        NomeFantasia = cliente.Nome,
                        Ie = cliente.Ie?.Trim().Replace(".", "").Replace("/", "").Replace("-", ""),
                        CnpjCpf = cliente.Cnpj?.Replace(".", "").Replace("/", "").Replace("-", ""),
                        Isuf = cliente.InscricaoSuframa,
                        Email = cliente.Email.ToString(),
                        IndicadorIe = indicadorIE,
                    };

                    string cepCliente = cliente.CepCob.Trim().Replace("-", "");
                    if (cepCliente.Length != 8)
                    {
                        throw new ExcecaoTratada("O cep de cobrança do cliente é inválido: " + cliente.CepCob);
                    }

                    if (cliente.CidadeCob == null)
                    {
                        throw new ExcecaoTratada("O cliente não possui cidade de cobrança definda");
                    }

                    if (cliente.EstadoCob == null)
                    {
                        throw new ExcecaoTratada("O cliente não possui estado de cobrança defindo");
                    }

                    if (!cliente.CodigoPaisCob.HasValue)
                    {
                        throw new ExcecaoTratada("O cliente não possui código do país de cobrança defindo");
                    }

                    nf.NfCliente.NfClienteEndereco = new NfClienteEnderecoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        Logradouro = cliente.EnderecoCob.ToString(),
                        Numero = cliente.EnderecoNumeroCob.ToString(),
                        Complemento = cliente.ComplementoCob.ToString(),
                        Bairro = cliente.BairroCob.ToString(),
                        CodMunicipio = cliente.CidadeCob.CodigoIbge,
                        NomeMunicipio = cliente.CidadeCob.Nome.ToString(),
                        SiglaUf = cliente.EstadoCob.Sigla.ToString(),
                        Cep = cepCliente,
                        CodPais = cliente.CodigoPaisCob.Value,
                        NomePais = cliente.PaisCob.ToString(),
                        Telefone = cliente.Fone1.ToString().Replace("(", "").Trim().Replace(")", "").Replace("-", "").Replace(" ", "")

                    };

                    cliObsPadraoNfe = cliente.ObservacaoPadraoNfe;



                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do Cliente da NF.\r\n" + e.Message);
                }

                #endregion

                #region Itens do Pedido

                int totalVolumes = 0;

                OrganizaNfItemClass itemExt = null;
                int numeroLinhaNF = 1;
                double pesoTotalItens = 0;

                string obsEntregaFutura = "";
                List<string> notasReferenciadas = new List<string>();


                List<string> observacoesAdd = new List<string>();
                List<string> observacoesFiscoAdd = new List<string>();

                InclusaoPedidoNota inclusaoPedidoNota = (InclusaoPedidoNota)Enum.ToObject(typeof(InclusaoPedidoNota), int.Parse(IWTConfiguration.Conf.getConf(Constants.NF_INCLUIR_NUMERO_PEDIDO_NF)));

                try
                {
                    nf.CollectionNfItemClassNfPrincipal = new BindingList<NfItemClass>();



                    foreach (OrganizaNfItemClass item in nfTmp.itens.Values)
                    {
                        if (item.Quantidade <= 0)
                        {
                            continue;
                        }

                        totalVolumes += item.Volumes;
                        itemExt = item;

                        OrderItemEtiquetaClass itemPedidoConfigurado = OrderItemEtiquetaClass.GetEntidade(item.Id, Usuario, conn);
                        PedidoItemClass itemPedido = itemPedidoConfigurado.PedidoItem;

                        CargaTributosDto tributos = CargaTributosDto.CarregaTributosEnvioTerceiros(itemPedido, emitenteCompleto.CidadeEntidade.Estado.ID, ref command, pisCofinsDefault);
                        DadosFiscaisItemDto dadosFiscaisItem = DadosFiscaisItemDto.GetDadosFiscaisProduto(itemPedidoConfigurado.Produto);

                        double precoTotal;
                        EasiValidaPrecos validaPreco;

                        string descricao = "";
                        if (inclusaoPedidoNota == InclusaoPedidoNota.DescricaoItens)
                        {
                            descricao = item.Pedido + " - ";
                        }



                        string codItem;
                        NcmClass ncm;
                        int CFOP;
                        string codigoBeneficioFiscal = null;


                        BibliotecaEntidades.Base.IncidenciaImposto incideIcms = IncidenciaImposto.Incide;
                        string cstSuspensaoIcms = null;
                        int csoSuspensaoIcms = 0;
                        IncidenciaImposto incideIPI = IncidenciaImposto.Incide;
                        string cstSuspensaoIPI = null;
                        IncidenciaImposto incidePIS = IncidenciaImposto.Incide;
                        string cstSuspensaoPIS = null;
                        IncidenciaImposto incideCofins = IncidenciaImposto.Incide;
                        string cstSuspensaoCofins = null;


                        #region Busca dados Pedido Novo


                        //Descrição do Item
                        if (itemPedido.ProdutoDescricaoCliente.Length == 0)
                        {
                            descricao += itemPedidoConfigurado.Descricao;
                        }
                        else
                        {
                            descricao += itemPedido.ProdutoDescricaoCliente;
                        }

                        codItem = itemPedido.ProdutoCodigoCliente;
                        if (codItem.Length == 0)
                        {
                            codItem = itemPedidoConfigurado.CodigoItem;
                        }


                        //CFOP
                        bool entregaFutura = tributos.EntregaFutura;
                        if (entregaFutura)
                        {
                            CFOP = tributos.EntregaFuturaCfopRemessa.Value;

                        }
                        else
                        {
                            CFOP = tributos.Cfop;
                        }


                        ncm = itemPedido.Ncm;



                        //Obs Entrega Futura + Nfs Relacionadas
                        if (entregaFutura)
                        {

                            PedidoItemClass pedidoPai = itemPedidoConfigurado.PedidoItemLinhaPrincipalPedido;

                            if (!pedidoPai.FaturamentoAntecipadoRealizado)
                            {
                                throw new ExcecaoTratada("Não é possível realizar a entrega de um pedido de faturamento antecipado sem que a primeira nota tenha sido emitida.");
                            }

                            obsEntregaFutura += "Ref. Nota Fiscal de Simples Faturamento Nº " + pedidoPai.NfPrincipalFaturamentoAntecipado.Numero + " de " +
                                                pedidoPai.NfPrincipalFaturamentoAntecipado.DataEmissao.ToString("dd/MM/yyyy") +
                                                ", valor total de R$ " + pedidoPai.NfPrincipalFaturamentoAntecipado.NfTotais.ValorTotalNf.ToString("F2", CultureInfo.GetCultureInfo("pt-Br")) + ". ";

                            if (tipoEmissaoNFe == TipoEmissaoNFe.EASI)
                            {
                                NfeCompletoNotaClass nfeCompleto = (NfeCompletoNotaClass)new NfeCompletoNotaClass(Usuario, conn).Search(
                                    new List<SearchParameterClass>()
                                    {
                                                new SearchParameterClass("NfPrincipal", pedidoPai.NfPrincipalFaturamentoAntecipado)
                                    }).FirstOrDefault();

                                notasReferenciadas.Add(nfeCompleto.Chave);
                            }


                        }


                        incideIcms = tributos.IcmsIncide;
                        if (incideIcms == IncidenciaImposto.Suspenso)
                        {
                            cstSuspensaoIcms = tributos.IcmsCst;
                            if (cstSuspensaoIcms == "300" || cstSuspensaoIcms == "400")
                            {
                                csoSuspensaoIcms = Convert.ToInt32(cstSuspensaoIcms);
                                cstSuspensaoIcms = "SN";
                            }
                        }

                        if (!entregaFutura)
                        {

                            incideIPI = tributos.IpiIncide;
                            if (incideIPI == IncidenciaImposto.Suspenso)
                            {
                                cstSuspensaoIPI = tributos.IpiCst;
                            }
                        }
                        else
                        {
                            incideIPI = IncidenciaImposto.NaoIncide;
                        }


                        incideCofins = tributos.CofinsIncide;
                        if (incideCofins == IncidenciaImposto.Suspenso)
                        {
                            cstSuspensaoCofins = tributos.CofinsCst;
                        }

                        incidePIS = tributos.PisIncide;
                        if (incidePIS == IncidenciaImposto.Suspenso)
                        {
                            cstSuspensaoPIS = tributos.PisCst;
                        }




                        #endregion

                        precoTotal = item.ValorTotal;

                        //carrega o frete
                        double valorFrete = 0;
                        if (nfTmp.FormaFrete == FormaFretePedido.RateadoItens)
                        {
                            double valorFreteTotal = itemPedido.Frete;
                            precoTotal = precoTotal + valorFreteTotal;
                            item.FreteRateado = valorFreteTotal / item.Quantidade;
                            valorFrete = 0;
                        }
                        else
                        {
                            valorFrete = itemPedido.Frete;
                        }


                        if (descricao.Length > 60)
                        {
                            descricao = descricao.Substring(0, 60);
                        }

                        if (ncm == null)
                        {
                            ncm = dadosFiscaisItem.NCM;

                        }


                        if (ncm != null)
                        {
                            NcmBeneficioFiscalClass beneficioFiscal = ncm.CollectionNcmBeneficioFiscalClassNcm.FirstOrDefault(a => a.Estado == cliente.EstadoCob && a.Cfop == CFOP);
                            codigoBeneficioFiscal = beneficioFiscal?.CodigoBeneficioFiscal;
                        }




                        pesoTotalItens += (itemPedidoConfigurado.Produto.PesoUnitario) * item.Quantidade;



                        nf.CollectionNfItemClassNfPrincipal.Add(new NfItemClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            NumeroItem = numeroLinhaNF,
                            Cfop = CFOP,
                        });
                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto =
                            new NfProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                            {
                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                Codigo = codItem,
                                Descricao = descricao,
                                Gtin = dadosFiscaisItem.GTIN,
                                Ncm = ncm.Codigo,
                                Cest = ncm.Cest,
                                CodigoBeneficio = codigoBeneficioFiscal,
                                Extipi = dadosFiscaisItem.exTIPI,
                                Genero = dadosFiscaisItem.Genero,
                                Unidade = itemPedidoConfigurado.Produto.UnidadeMedida?.Abreviada,
                                ValorUnitario = item.ValorUnitario,
                                GtimUnidadeTrinutacao = dadosFiscaisItem.GTIN,
                                UnidadeTributacao = itemPedidoConfigurado.Produto.UnidadeMedida?.Abreviada,
                                ValorUnitarioTrinutacao = item.ValorUnitario,
                                QuantidadeTributavel = item.Quantidade,
                                ValorTotalTributavel = Math.Round(item.ValorTotal, 2),
                                ValorFrete = valorFrete,
                                ValorDesconto = 0,
                                ValorSeguro = 0,
                                Quantidade = item.Quantidade,
                                Xped = item.Oc,
                                NumeroItemPedido = int.Parse(item.Pos)
                            };

                        string cstCsosn = "";
                        switch (incideIcms)
                        {
                            case IncidenciaImposto.Incide:
                                cstCsosn = tributos.IcmsCst;


                                switch (tributos.IcmsCst)
                                {
                                    case "41a":
                                        IcmsRetidoForm form2 = new IcmsRetidoForm(codItem + " - " + descricao);
                                        form2.ShowDialog();

                                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                            new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = tributos.IcmsCst,
                                                Origem = (OrigemMercadoria)Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                Aliquota = tributos.IcmsAliquota,
                                                AliquotaSt = tributos.IcmsAliquotaSt,
                                                PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                PercentualMvaSt = tributos.IcmsMvaSt,
                                                CodigoAntecipacaoSt = "X",
                                                PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                SiglaUfDevidoIcms = null,
                                                ValorBcStRetidoRemetente = form2.remetenteBC,
                                                ValorIcmsStRetidoRemetente = form2.remetenteValor,
                                                ValorBcStRetidoDestinatario = form2.destBC,
                                                ValorIcmsStRetidoDestinatario = form2.destValor,
                                                CsoSimples = tributos.IcmsCsoSimples,
                                                AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                            };
                                        break;

                                    case "90b":
                                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                            new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = "90",
                                                Origem = (OrigemMercadoria)Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                Aliquota = tributos.IcmsAliquota,
                                                AliquotaSt = tributos.IcmsAliquotaSt,
                                                PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                PercentualMvaSt = tributos.IcmsMvaSt,
                                                CodigoAntecipacaoSt = "X",
                                                PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                SiglaUfDevidoIcms = null,
                                                ValorBcStRetidoRemetente = 0,
                                                ValorIcmsStRetidoRemetente = 0,
                                                ValorBcStRetidoDestinatario = 0,
                                                ValorIcmsStRetidoDestinatario = 0,
                                                CsoSimples = tributos.IcmsCsoSimples,
                                                AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                            };

                                        break;

                                    default:
                                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                            new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                            {
                                                NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                                Cst = tributos.IcmsCst,
                                                Origem = (OrigemMercadoria)Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                                ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), tributos.IcmsModDetBc),
                                                Aliquota = tributos.IcmsAliquota,
                                                AliquotaSt = tributos.IcmsAliquotaSt,
                                                PercentualReducaoBc = tributos.IcmsPercentualReducaoBc,
                                                ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST)Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), tributos.IcmsModDetBcSt),
                                                PercentualReducaoBcSt = tributos.IcmsPercentualReducaoBcSt,
                                                PercentualMvaSt = tributos.IcmsMvaSt,
                                                CodigoAntecipacaoSt = "X",
                                                PercentualDiferimento = tributos.IcmsPercentualDiferimento,
                                                ObsDiferimento = tributos.IcmsObservacaoDiferimento,
                                                PercentualBcOperacaoPropria = tributos.IcmsPercentualBcOperacaoPropria,
                                                SiglaUfDevidoIcms = null,
                                                ValorBcStRetidoRemetente = 0,
                                                ValorIcmsStRetidoRemetente = 0,
                                                ValorBcStRetidoDestinatario = 0,
                                                ValorIcmsStRetidoDestinatario = 0,
                                                CsoSimples = tributos.IcmsCsoSimples,
                                                AliquotaCreditoSimples = tributos.IcmsAliquotaCredito,
                                                ObservacaoCreditoSimples = tributos.IcmsObsevacaoCredito,
                                                MotivoDesoneracaoIcms = tributos.IcmsMotivoDesoneracao
                                            };
                                        break;
                                }

                                break;

                            case IncidenciaImposto.NaoIncide:
                                throw new Exception("Icms é obrigatório.");

                            case IncidenciaImposto.Suspenso:
                                cstCsosn = cstSuspensaoIcms;
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIcms =
                                    new NfProdutoIcmsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = cstSuspensaoIcms,
                                        Origem = (OrigemMercadoria)Enum.ToObject(typeof(OrigemMercadoria), dadosFiscaisItem.Origem),
                                        ModalidadeDeterminacaoBc = ModalidadeDeterminacaoBCICMS.ValorOperacao,
                                        Aliquota = 0,
                                        AliquotaSt = 0,
                                        PercentualReducaoBc = 0,
                                        ModalidadeDeterminacaoBcSt = ModalidadeDeterminacaoBCICMSST.MargemValorAgregado,
                                        PercentualReducaoBcSt = 0,
                                        PercentualMvaSt = 0,
                                        CodigoAntecipacaoSt = "X",
                                        PercentualDiferimento = 0,
                                        ObsDiferimento = "",
                                        PercentualBcOperacaoPropria = 0,
                                        SiglaUfDevidoIcms = null,
                                        ValorBcStRetidoRemetente = 0,
                                        ValorIcmsStRetidoRemetente = 0,
                                        ValorBcStRetidoDestinatario = 0,
                                        ValorIcmsStRetidoDestinatario = 0,
                                        CsoSimples = csoSuspensaoIcms,
                                        AliquotaCreditoSimples = 0
                                    };

                                break;
                        }


                        switch (incideIPI)
                        {
                            case IncidenciaImposto.NaoIncide:
                                break;
                            case IncidenciaImposto.Incide:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                    new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        ClasseEnquadramentoCigarrosBebidas = null,
                                        CnpjProdutor = null,
                                        ClasseEnquadramento = tributos.IpiCodEnquadramento,
                                        Cst = tributos.IpiCst,
                                        Aliquota = tributos.IpiAliquota,
                                        ModalidadeTributacao = (ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), tributos.IpiModTributacao),
                                        QuantidadeVendida = 0
                                    };
                                break;
                            case IncidenciaImposto.Suspenso:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoIpi =
                                    new NfProdutoIpiClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        ClasseEnquadramentoCigarrosBebidas = null,
                                        CnpjProdutor = null,
                                        ClasseEnquadramento = tributos.IpiCodEnquadramento,
                                        Cst = cstSuspensaoIPI,
                                        Aliquota = 0,
                                        ModalidadeTributacao = ModalidadeTributacao.NaoTributado,
                                        QuantidadeVendida = 0
                                    };
                                break;
                        }


                        switch (incidePIS)
                        {
                            case IncidenciaImposto.NaoIncide:
                                throw new Exception("PIS é obrigatório.");
                            case IncidenciaImposto.Incide:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                                    new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = tributos.PisCst,
                                        Aliquota = tributos.PisAliquota,
                                        ModadlidadeTributacao = (ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), tributos.PisModTributacao),
                                        ImpostoRetido = tributos.PisImpostoRetido ? (short)1 : (short)0
                                    };
                                break;
                            case IncidenciaImposto.Suspenso:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoPis =
                                    new NfProdutoPisClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = cstSuspensaoPIS,
                                        Aliquota = 0,
                                        ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                        ImpostoRetido = 0
                                    };
                                break;
                        }


                        switch (incideCofins)
                        {
                            case IncidenciaImposto.NaoIncide:
                                throw new Exception("Cofins é obrigatório.");
                            case IncidenciaImposto.Incide:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                                    new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = tributos.CofinsCst,
                                        Aliquota = tributos.CofinsAliquota,
                                        ModadlidadeTributacao = (ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), tributos.CofinsModTributacao),
                                        ImpostoRetido = tributos.CofinsImpostoRetido ? (short)1 : (short)0
                                    };
                                break;
                            case IncidenciaImposto.Suspenso:
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.NfProdutoCofins =
                                    new NfProdutoCofinsClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                                    {
                                        NfItem = nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1],
                                        Cst = cstSuspensaoCofins,
                                        Aliquota = 0,
                                        ModadlidadeTributacao = ModalidadeTributacao.NaoTributado,
                                        ImpostoRetido = 0
                                    };
                                break;
                        }

                        nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].CfopPartilhaIcms = tributos.IcmsPartilha;


                        NcmClass ncmReal = (NcmClass)new NcmClass(Usuario, conn).Search(new List<SearchParameterClass>()
                            {
                                new SearchParameterClass("CodigoExato", nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].NfProduto.Ncm)
                            }).FirstOrDefault();

                        if (ncmReal != null)
                        {
                            AliquotaFundoCombatePobrezaClass aliquotaFCP = ncmReal.CollectionAliquotaFundoCombatePobrezaClassNcm.FirstOrDefault(a => a.Estado == cliente.EstadoCob);
                            if (aliquotaFCP != null)
                            {
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].AlquotaFundoCombatePobreza = aliquotaFCP.Aliquota;
                            }
                            else
                            {
                                nf.CollectionNfItemClassNfPrincipal[nf.CollectionNfItemClassNfPrincipal.Count - 1].AlquotaFundoCombatePobreza = 0;
                            }



                            BuscaObservacoesAdicionais(CFOP, ncmReal, cstCsosn, ref observacoesAdd, ref observacoesFiscoAdd);
                        }


                        item.IndiceLinha = numeroLinhaNF;
                        numeroLinhaNF++;

                        itemExt = null;
                    }


                    if (nf.CollectionNfItemClassNfPrincipal.Count == 0)
                    {
                        throw new Exception("Ao menos um item deve ser selecionado.");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados dos itens da NF: " + itemExt.Pedido + "\r\n" +
                                        e.Message);
                }

                #endregion

                #region Transporte

                try
                {
                    if (nfTmp.idTransporte == -1)
                    {
                        //public NfTransporte(NfPrincipal nfPrincipal, short nftModalidade, string nftRazao, string nftIe, string nftEndereco, string nftSiglaUf, string nftMunicipio,
                        //string nftCpfCnpj, int? nftVolumes, double nftPesoLiquido, double nftPesoBruto, string nftPlaca, string nftRegistroAntt, string nftSiglaUfVeiculo,
                        //string nftVolumeEspecie, string nftVolumeMarca)
                        nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            Modalidade = nfTmp.responsavelFrete,
                            Razao = "",
                            Ie = "",
                            Endereco = "",
                            SiglaUf = "",
                            Municipio = "",
                            CpfCnpj = "",
                            Volumes = totalVolumes,
                            PesoLiquido = pesoTotalItens,
                            PesoBruto = pesoTotalItens,
                            Placa = null,
                            RegistroAntt = null,
                            SiglaUfVeiculo = null,
                            VolumeEspecie = "Volume",
                            VolumeMarca = ""
                        };
                    }
                    else
                    {

                        TransporteClass transporte = TransporteClass.GetEntidade(nfTmp.idTransporte, Usuario, conn);




                        nf.NfTransporte = new NfTransporteClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                        {
                            NfPrincipal = nf,
                            Modalidade = nfTmp.responsavelFrete,
                            Razao = transporte.Razao,
                            Ie = string.IsNullOrEmpty(transporte.Ie) ? transporte.Ie : transporte.Ie.Replace("-", "").Replace(".", ""),
                            Endereco = transporte.Endereco,
                            SiglaUf = transporte.Cidade?.Estado?.Sigla,
                            Municipio = transporte.Cidade?.Nome,
                            CpfCnpj = transporte.CpfCnpj,
                            Volumes = totalVolumes,
                            PesoLiquido = pesoTotalItens,
                            PesoBruto = pesoTotalItens,
                            Placa = transporte.Placa.Replace("-", ""),
                            RegistroAntt = transporte.RegistroAntt.ToString(),
                            SiglaUfVeiculo = transporte.EstadoVeiculo?.Sigla,
                            VolumeEspecie = "Volume",
                            VolumeMarca = ""
                        };


                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados do transporte da NF.\r\n" + e.Message);
                }

                #endregion

                try
                {
                    NfPrincipalClass.calculaNf(ref nf, this.arrendodamentoNF, Usuario, conn, observacaoCustomizada, false, false, descontarIcmsBCCofins:nfTmp.DescontarImcsBcCofins, descontarIcmsBCPis:nfTmp.DescontarImcsBcPis);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao calcular a NF.\r\n" + e.Message);
                }

                #region Dados Cobrança

                try
                {
                    nf.NfCobranca = new NfCobrancaClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        CollectionNfDuplicataClassNfCobranca = new BindingList<NfDuplicataClass>(new List<NfDuplicataClass>())
                    };

                    nf.CollectionNfPagamentoClassNfPrincipal.Add(new NfPagamentoClass(LoginClass.UsuarioLogado.loggedUser, this.conn)
                    {
                        NfPrincipal = nf,
                        Tipo = NfPagamentoTipo.SemPagamento,
                        Valor = 0,
                    });
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao preencher os dados das duplicatas da NF.\r\n" + e.Message);
                }

                #endregion

                #region Pedido Urgente (Obs)



                #endregion

                #region Observações

                    string observacaoPedidos = "";
                    foreach (OrganizaNfItemClass item in nfTmp.itens.Values.Where(a => !string.IsNullOrWhiteSpace(a.ObservacaoPedido)))
                    {
                        observacaoPedidos += "Observação do Pedido " + item.Pedido + ": " + item.ObservacaoPedido + " ";
                    }

                    if (inclusaoPedidoNota == InclusaoPedidoNota.Observacao)
                    {
                        if (observacaoPedidos.Length > 0)
                        {
                            observacaoPedidos += " ";
                        }

                        observacaoPedidos += "Pedidos Faturados: ";
                        foreach (OrganizaNfItemClass item in nfTmp.itens.Values)
                        {
                            observacaoPedidos += "" + item.Pedido + " - ";
                        }

                        observacaoPedidos = observacaoPedidos.Substring(0, observacaoPedidos.Length - 3);
                    }



                    nf.Observacoes += emitenteCompleto.ObservacaoEmitente + " " + cliObsPadraoNfe + " " + observacaoPedidos;

                    if (!string.IsNullOrWhiteSpace(obsEntregaFutura))
                    {
                        nf.Observacoes += " " + obsEntregaFutura;
                    }

                    foreach (string obsAdd in observacoesAdd)
                    {
                        nf.Observacoes += " " + obsAdd;
                    }

                    foreach (string obsAdd in observacoesFiscoAdd)
                    {
                        nf.ObservacoesFisco += " " + obsAdd ;
                    }




                #endregion




                //Visualiza a NF
                VisualNFeForm form = new VisualNFeForm(nf, "-1", VisualNFeFormUtilizacao.Visualizacao);
                form.ShowDialog();


                //NFe nova, envio automático receita

                if (ambienteEmissaoNFe == Ambiente.Homologacao)
                {
                    nf.NfCliente.Razao = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                    nf.IdentificacaoAmbiente = 2;
                }

                try
                {

                    nf.Save(ref command);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao salvar a NF.\r\n" + e.Message);
                }


                return nf;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao emitir a Nota Fiscal.\r\n" + e.Message);
            }

        }

    }
}
