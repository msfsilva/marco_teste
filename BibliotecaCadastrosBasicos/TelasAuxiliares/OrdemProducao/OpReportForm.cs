#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using BibliotecaCadastrosBasicos.EstruturaProduto;
using BibliotecaCadastrosBasicos.NovaEstruturaProduto;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;
using OrdemProducaoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoClass;
using OrdemProducaoDocumentoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoDocumentoClass;
using OrdemProducaoMaterialClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoMaterialClass;
using OrdemProducaoPedidoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoPedidoClass;
using OrdemProducaoPostoTrabalhoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoPostoTrabalhoClass;
using OrdemProducaoProdutoComponenteClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoProdutoComponenteClass;
using OrdemProducaoRecursoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoRecursoClass;

#endregion

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class OpReportForm : IWTBaseForm
    {
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        AcsUsuarioClass Usuario;
        IWTPostgreNpgsqlConnection conn;

        private ICarregarDocumentosImpressaoOp _carregarDocumentosImpressaoOp;

        private class PedidoOpKey : IEquatable<PedidoOpKey>
        {
            public bool Equals(PedidoOpKey other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return OrderNumber == other.OrderNumber && OrderPos == other.OrderPos && ValorVariavel1 == other.ValorVariavel1 && SemanaEntrega == other.SemanaEntrega && IdOrdemProducao == other.IdOrdemProducao && Variavel1 == other.Variavel1 && CodigoPai == other.CodigoPai && AcabamentoPai == other.AcabamentoPai && DescricaoPai == other.DescricaoPai && StatusAtual == other.StatusAtual && DataEntregaAtualPedido.Equals(other.DataEntregaAtualPedido);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((PedidoOpKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (OrderNumber != null ? OrderNumber.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ OrderPos;
                    hashCode = (hashCode * 397) ^ (ValorVariavel1 != null ? ValorVariavel1.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ SemanaEntrega;
                    hashCode = (hashCode * 397) ^ IdOrdemProducao.GetHashCode();
                    hashCode = (hashCode * 397) ^ (Variavel1 != null ? Variavel1.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (CodigoPai != null ? CodigoPai.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (AcabamentoPai != null ? AcabamentoPai.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (DescricaoPai != null ? DescricaoPai.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (StatusAtual != null ? StatusAtual.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ DataEntregaAtualPedido.GetHashCode();
                    return hashCode;
                }
            }


            public string OrderNumber { get; set; }
            public int OrderPos { get; set; }
            public string ValorVariavel1 { get; set; }
            public int SemanaEntrega { get; set; }
            public long IdOrdemProducao { get; set; }
            public string Variavel1 { get; set; }
            public string CodigoPai { get; set; }
            public string AcabamentoPai { get; set; }
            public string DescricaoPai { get; set; }
            public string StatusAtual { get; set; }
            public DateTime DataEntregaAtualPedido { get; set; }
        }

        public OpReportForm(List<OrdemProducaoClass> list, bool Impressao, AcsUsuarioClass Usuario,IWTPostgreNpgsqlConnection conn, ICarregarDocumentosImpressaoOp carregarDocumentosImpressaoOp)
        {
            InitializeComponent();

            this.Usuario = Usuario;
            this.conn = conn;
            _carregarDocumentosImpressaoOp = carregarDocumentosImpressaoOp;
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();

            if (Impressao)
            {
                this.crystalReportViewer1.ShowExportButton = true;
                this.crystalReportViewer1.ShowPrintButton = true;
            }
            else
            {
                this.crystalReportViewer1.ShowExportButton = false;
                this.crystalReportViewer1.ShowPrintButton = false;
            }

            this.tipoCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO);
            this.diaCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA);
            int diasArmazenar = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.PRAZO_ARMAZENAMENTO_OP));
            string Impressora = IWTConfiguration.Conf.getConf(Constants.IMPRESSORA_OP);
            

            OpReportDataSet ds = new OpReportDataSet();

            OpReportDataSet.ordem_producaoRow opRow;
            OpReportDataSet.ordem_producao_recursoRow recRow;
            OpReportDataSet.ordem_producao_posto_trabalhoRow posRow;
            OpReportDataSet.ordem_producao_pedidoRow pedRow;
            OpReportDataSet.ordem_producao_materialRow matRow;
            OpReportDataSet.ordem_producao_documentoRow docRow;
            OpReportDataSet.ordem_producao_estoqueRow estRow;
            OpReportDataSet.ordem_producao_relacionadasRow relRow;

            try
            {
                //criar barCode
                string tempDir = Environment.GetEnvironmentVariable("temp");
                Process process = new Process();
                process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                FileStream fs;
                BinaryReader br;
                Byte[] array;

                
                foreach (OrdemProducaoClass OP in list)
                {
                    //cabeçalho 
                    opRow = ds.ordem_producao.Newordem_producaoRow();

                    opRow.id_ordem_producao = Convert.ToInt32(OP.idOrdemProducao);
                    opRow.orp_produto_codigo = OP.produtoCodigo;
                    opRow.orp_quantidade = OP.Quantidade;
                    opRow.orp_tipo_documento = OP.tipoDocumento;
                    opRow.orp_numero_documento = OP.numeroDocumento;
                    opRow.orp_revisao_documento = OP.revisaoDocumento;
                    opRow.orp_produto_descricao = OP.produtoDescricao;
                    opRow.orp_dimensao = OP.Dimensao;
                    opRow.orp_data = OP.Data;
                    opRow.orp_quantidade_estoque = OP.quantidadeEstoque;
                    opRow.orp_quantidade_pedido = OP.quantidadePedidos;
                    opRow.orp_qtd_extra = OP.qtdExtra;
                    opRow.orp_situacao = (short)OP.Situacao;
                    opRow.id_produto = (int)OP.idProduto;
                    opRow.produto_acabamento = OP.Produto.Acabamento + "";
                    opRow.usuario = OP.Usuario.Login;
                    opRow.orp_agrupador_op = OP.agrupadorOP;
                    opRow.versao_estrutura_produto = OP.versaoEstruturaProduto;
                    opRow.orp_rastreamento_material = Convert.ToInt16(OP.rastrearMP);
                    opRow.orp_imprime_ops_relacionadas = OP.imprimeOpsRelacionadas;
                    if (OP.UsuarioReimpressao != null)
                    {
                        opRow.usuario_reimpressao = OP.UsuarioReimpressao.Login;
                        opRow.orp_data_reimpressao = OP.dataReimpressao.Value;
                    }
                    else
                    {
                        opRow.usuario_reimpressao = "";
                    }

                    opRow.data_armazenagem = "";
                    if (OP.UsuarioImpressao != null)
                    {
                        opRow.usuario_impressao = OP.UsuarioImpressao.Login;
                        opRow.orp_data_impressao = OP.dataImpressao.Value;

                        if (diasArmazenar > 0)
                        {
                            opRow.data_armazenagem = OP.dataImpressao.Value.AddDays(diasArmazenar).ToString("dd/MM/yyyy");
                        }

                    }
                    else
                    {
                        opRow.usuario_impressao = "";
                    }
                    opRow.local_fabricacao = OP.Produto.LocalFabricacao == null ? "" : OP.Produto.LocalFabricacao.ToString();


                    opRow.lote_economico = OP.Produto.LoteEconomico;
                    if (OP.Produto.UnidadeMedida != null)
                    {
                        opRow.unidade_medida = OP.Produto.UnidadeMedida.Abreviada;
                    }
                    else
                    {
                        opRow.unidade_medida = "S/U";
                    }

                    process.StartInfo.Arguments = "OP|" + OP.idOrdemProducao + " " + tempDir + "\\code.bmp";
                    process.Start();
                    process.WaitForExit();

                    fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                    br = new BinaryReader(fs);
                    array = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    opRow.id_ordem_producao_barcode = array;


                    opRow.orp_quantidade_texto = opRow.orp_quantidade.ToString(Math.Abs(opRow.orp_quantidade % 1) < 0.000001 ? "F0" : "F3", CultureInfo.GetCultureInfo("pt-BR"));
                    opRow.orp_quantidade_pedido_texto = opRow.orp_quantidade_pedido.ToString(Math.Abs(opRow.orp_quantidade_pedido % 1) < 0.000001 ? "F0" : "F3", CultureInfo.GetCultureInfo("pt-BR"));
                    opRow.orp_quantidade_estoque_texto = opRow.orp_quantidade_estoque.ToString(Math.Abs(opRow.orp_quantidade_estoque % 1) < 0.000001 ? "F0" : "F3", CultureInfo.GetCultureInfo("pt-BR"));
                    opRow.orp_qtd_extra_texto = opRow.orp_qtd_extra.ToString(Math.Abs(opRow.orp_qtd_extra % 1) < 0.000001 ? "F0" : "F3", CultureInfo.GetCultureInfo("pt-BR"));

                    
                    

                    ds.ordem_producao.Addordem_producaoRow(opRow);



                    //Roteiro de fabricação
                    foreach (OrdemProducaoPostoTrabalhoClass postoTrabalho in OP.postosTrabalho)
                    {
                        posRow = ds.ordem_producao_posto_trabalho.Newordem_producao_posto_trabalhoRow();
                        posRow.id_ordem_producao_posto_trabalho = (int)postoTrabalho.idOrdemProducaoPostoTrabalho;
                        posRow.id_posto_trabalho = (int)postoTrabalho.idPostoTrabalho;
                        posRow.opt_posto_codigo = postoTrabalho.Codigo;
                        posRow.opt_posto_nome = postoTrabalho.Nome;
                        posRow.opt_posto_operacao = postoTrabalho.Operacao;
                        posRow.opt_sequencia = postoTrabalho.Sequencia;
                        posRow.id_ordem_producao = (int)OP.idOrdemProducao;
                        posRow.pos_acompanhamento = (short)postoTrabalho.Acompanhamento;
                        posRow.pos_rastreamento = postoTrabalho.Rastreamento;
                        ds.ordem_producao_posto_trabalho.Addordem_producao_posto_trabalhoRow(posRow);
                    }

                    //Recursos
                    foreach (OrdemProducaoRecursoClass recurso in OP.Recursos)
                    {
                        if (recurso.Hierarquia == 0)
                        {
                            recRow = ds.ordem_producao_recurso.Newordem_producao_recursoRow();

                            recRow.opr_recurso_codigo = recurso.recursoCodigo;
                            recRow.opr_recurso_nome = recurso.recursoDescricao;
                            recRow.id_ordem_producao = (int) OP.idOrdemProducao;
                            recRow.id_recurso = (int)recurso.idRecurso;
                            recRow.opr_posto_trabalho_codigo = recurso.postoTrabalhoCodigo;
                            recRow.id_posto_trabalho = (int)recurso.idPostoTrabalho;
                            recRow.opr_recurso_familia = recurso.recursoFamilia;
                            recRow.opr_recurso_loc1 = recurso.recursoLoc1 + ">";
                            recRow.opr_recurso_loc2 = recurso.recursoLoc2 + ">";
                            recRow.opr_recurso_loc3 = recurso.recursoLoc3 + ">";
                            recRow.opr_recurso_loc4 = recurso.recursoLoc4;
                            recRow.opr_recurso_revisao = recurso.recursoRev;
                            recRow.opr_recurso_hierarquia = (int) recurso.Hierarquia;
                            recRow.id_ordem_producao_recurso = (int) recurso.idOrdemProducaoRecurso;
                            ds.ordem_producao_recurso.Addordem_producao_recursoRow(recRow);
                        }
                    }

                    //Documentos
                    foreach (OrdemProducaoDocumentoClass documento in OP.getDocumentos(command))
                    {
                        docRow = ds.ordem_producao_documento.Newordem_producao_documentoRow();

                        docRow.opd_documento_descricao = documento.Descricao;
                        docRow.opd_documento_copia = documento.Copia;
                        docRow.id_ordem_producao = (int)OP.idOrdemProducao;
                        docRow.id_documento = (int) documento.idDocumentoCopia;
                        docRow.id_documento_tipo = (int)documento.idDocumentoTipoFamilia;
                        docRow.opd_documento_tipo_codigo = documento.documentoTipoCodigo;
                        docRow.opd_documento_tipo_tipo = documento.documentoTipoTipo;
                        docRow.opd_documento_tipo_revisao = documento.documentoTipoRevisao;
                        docRow.opd_documento_l1 = documento.Loc1;
                        docRow.opd_documento_l2 = documento.Loc2;
                        docRow.opd_documento_l3 = documento.Loc3;
                        docRow.opd_documento_l4 = documento.Loc4;
                        docRow.ultima_utilizacao_documento = documento.UltimaOpUtilizando;
                        docRow.aviso = documento.AvisoDocumento;

                        ds.ordem_producao_documento.Addordem_producao_documentoRow(docRow);
                    }

                    //Materiais

                    bool suprimirQtdUnitariaMaterial = Configurations.IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.SUPRIMIR_IMPRESSAO_QTD_UNITARIA_OP);
                    
                    Dictionary<OrdemProducaoMateriaReportKey,OpReportDataSet.ordem_producao_materialRow> materiaisReport = new Dictionary<OrdemProducaoMateriaReportKey, OpReportDataSet.ordem_producao_materialRow>();


                    foreach (OrdemProducaoMaterialClass material in OP.Materiais)
                    {
                        OrdemProducaoMateriaReportKey key = new OrdemProducaoMateriaReportKey()
                        {
                            Codigo = material.Codigo,
                            Comprimento = material.Comprimento,
                            Descricao = material.Descricao,
                            Espessura = material.Espessura,
                            Familia = material.Familia,
                            Material = material.Material,
                            Largura = material.Largura,
                            tipoAcabamento = material.tipoAcabamento,
                            UnidadeMedida = material.unidadeMedida,
                            idOP = (int) OP.idOrdemProducao,
                        };


                        if (!materiaisReport.ContainsKey(key))
                        {
                            OpReportDataSet.ordem_producao_materialRow temp = ds.ordem_producao_material.Newordem_producao_materialRow();

                            temp.opm_material_descricao = material.Descricao;
                            temp.opm_material_unidade_medida = material.unidadeMedida;
                            temp.opm_material_medida = material.Espessura;
                            temp.opm_material_medida_comprimento = material.Comprimento;
                            temp.opm_material_medida_largura = material.Largura;
                            temp.opm_material_codigo = material.Codigo;
                            temp.opm_material_tipo_acabamento = material.tipoAcabamento;
                            temp.id_ordem_producao = key.idOP;
                            temp.id_material = (int)material.Material.ID;
                            temp.material_familia = material.Familia;
                            temp.suprimir_qtd_unitaria = suprimirQtdUnitariaMaterial;
                            temp.opm_quantidade = 0;

                            materiaisReport.Add(key, temp);
                        }

                        materiaisReport[key].opm_quantidade = Math.Round(materiaisReport[key].opm_quantidade + material.Quantidade, 6);
                    }


                    foreach (OpReportDataSet.ordem_producao_materialRow material in materiaisReport.Values.OrderBy(a=>a.material_familia).ThenBy(a=>a.opm_material_codigo))
                    {
                        ds.ordem_producao_material.Addordem_producao_materialRow(material);
                    }

                    CultureInfo brCulture = CultureInfo.GetCultureInfo("pt-BR");

                    Dictionary<PedidoOpKey, OpReportDataSet.ordem_producao_pedidoRow> pedidos = new Dictionary<PedidoOpKey, OpReportDataSet.ordem_producao_pedidoRow>();
                    foreach (OrdemProducaoPedidoClass pedido in OP.Pedidos)
                    {
                        string status = "";
                        switch (pedido.StatusAtual)
                        {
                            //pedRow.status_atual_pedido
                            case 0:
                                status = "P";
                                break;
                            case 1:
                                status = "E";
                                break;
                            case 2:
                                status = "C";
                                break;
                            case 3:
                                status = "R";
                                break;
                            case 4:
                                status = "S";
                                break;
                        }

                        PedidoOpKey chave = new PedidoOpKey()
                        {
                            OrderNumber = pedido.orderNumber,
                            OrderPos = pedido.orderPos,
                            SemanaEntrega = pedido.semanaEntrega,
                            Variavel1 = pedido.Variavel1,
                            ValorVariavel1 = pedido.valorVariavel1,
                            CodigoPai = pedido.produtoCodigoItemPai,
                            IdOrdemProducao = (int) OP.idOrdemProducao,
                            DescricaoPai = pedido.produtoDescricaoItemPai,
                            AcabamentoPai = pedido.produtoAcabamentoItemPai,
                            DataEntregaAtualPedido = pedido.dataEntregaAtual,
                            StatusAtual = status,

                        };

                        if (!pedidos.ContainsKey(chave))
                        {
                            OpReportDataSet.ordem_producao_pedidoRow tmp = ds.ordem_producao_pedido.Newordem_producao_pedidoRow();

                            tmp.opp_order_number = chave.OrderNumber;
                            tmp.opp_order_pos = chave.OrderPos;

                            tmp.opp_quantidade = 0;
                            tmp.opp_semana_entrega = chave.SemanaEntrega;

                            tmp.opp_cnc = pedido.CNC;
                            tmp.opp_saf = pedido.SAF;
                            tmp.opp_variavel_1 = chave.Variavel1;
                            tmp.opp_variavel_2 = pedido.Variavel2;
                            tmp.opp_variavel_3 = pedido.Variavel3;
                            tmp.opp_variavel_4 = pedido.Variavel4;
                            tmp.opp_valor_variavel_1 = chave.ValorVariavel1;
                            tmp.opp_valor_variavel_2 = pedido.valorVariavel2;
                            tmp.opp_valor_variavel_3 = pedido.valorVariavel3;
                            tmp.opp_valor_variavel_4 = pedido.valorVariavel4;
                            tmp.opp_produto_codigo_pai = chave.CodigoPai;
                            tmp.id_ordem_producao = (int) chave.IdOrdemProducao;
                            tmp.opp_produto_descricao_pai = chave.DescricaoPai;
                            tmp.opp_produto_acabamento_pai = chave.AcabamentoPai;
                            tmp.opp_cliente = pedido.Cliente;
                            tmp.status_atual_pedido = chave.StatusAtual;
                            tmp.data_entrega_atual_pedido = chave.DataEntregaAtualPedido;

                            if (pedido.idOrderItemEtiqueta.HasValue)
                            {
                                OrderItemEtiquetaClass oieItem = OrderItemEtiquetaClass.GetEntidade(pedido.idOrderItemEtiqueta.Value, Usuario, conn);

                                if (oieItem.OrderItemEtiquetaPai != null)
                                {

                                    if (oieItem.OrderItemEtiquetaPai.UnidadeMedida != null)
                                    {
                                        tmp.opp_unidade_medida_pai = oieItem.OrderItemEtiquetaPai.UnidadeMedida.Abreviada;
                                    }
                                    else
                                    {
                                        tmp.opp_unidade_medida_pai = "PÇ";
                                    }
                                    
                                }
                                else
                                {
                                    if (oieItem.UnidadeMedida != null)
                                    {
                                        tmp.opp_unidade_medida_pai = oieItem.UnidadeMedida.Abreviada;
                                    }
                                    else
                                    {
                                        tmp.opp_unidade_medida_pai = "PÇ";
                                    }
                                }
                            }
                            else
                            {
                                tmp.opp_unidade_medida_pai = "PÇ";
                            }


                            pedidos.Add(chave, tmp);

                        }

                        pedidos[chave].opp_quantidade = Math.Round(pedidos[chave].opp_quantidade + pedido.Quantidade, 3);


                    }

                    //Pedidos
                    foreach (OpReportDataSet.ordem_producao_pedidoRow linhaReport in pedidos.Values)
                    {

                        if (Math.Abs(linhaReport.opp_quantidade % 1) < 0.0001)
                        {
                            linhaReport.opp_quantidade_string = linhaReport.opp_quantidade.ToString("N0", brCulture);
                        }
                        else
                        {
                            linhaReport.opp_quantidade_string = linhaReport.opp_quantidade.ToString("N3", brCulture);
                        }

                        ds.ordem_producao_pedido.Addordem_producao_pedidoRow(linhaReport);
                    }

                    //Estoque

                    if (OP.quantidadeEstoque > 0 && OP.Quantidade < OP.quantidadePedidos)
                    {

                        List<EstoqueGavetaItemClass> gavetas;
                        if (OP.ProdutoK!=null)
                        {
                            gavetas = EstoqueMovimentacao.BuscaTodasGavetasItemProdutoK(OP.ProdutoK);
                        }
                        else
                        {
                            gavetas = EstoqueMovimentacao.BuscaTodasGavetasItemProduto(OP.Produto);
                            
                        }

                        foreach (EstoqueGavetaItemClass estoque in gavetas)
                        {
                            estRow = ds.ordem_producao_estoque.Newordem_producao_estoqueRow();
                            estRow.id_ordem_producao = (int)OP.idOrdemProducao;
                            estRow.ope_estoque_caminho = estoque.EstoqueGaveta.GetLocalizacaoCompleta();
                            estRow.ope_quantidade_total = estoque.Quantidade;

                            ds.ordem_producao_estoque.Addordem_producao_estoqueRow(estRow);
                        }
                    }
                  

                    Dictionary<ProdutoComponenteChave, OpReportDataSet.ordem_producao_produto_componenteRow > componentesAgrupados = new Dictionary<ProdutoComponenteChave, OpReportDataSet.ordem_producao_produto_componenteRow>();

                    //Produtos Componentes
                    foreach (OrdemProducaoProdutoComponenteClass componente in OP.ProdutosComponentes)
                    {
                        ProdutoComponenteChave chave = new ProdutoComponenteChave()
                        {
                            Codigo = componente.Codigo,
                            Descricao = componente.Descricao,
                            Dimensao = componente.Dimensao

                        };


                        if (!componentesAgrupados.ContainsKey(chave))
                        {
                            OpReportDataSet.ordem_producao_produto_componenteRow componenteRow = ds.ordem_producao_produto_componente.Newordem_producao_produto_componenteRow();
                            componenteRow.id_ordem_producao = (int) OP.idOrdemProducao;
                            componenteRow.produto_codigo = componente.Codigo;
                            componenteRow.produto_descricao = componente.Descricao;
                            componenteRow.dimensao = componente.Dimensao;
                            componenteRow.quantidade = 0;
                            componentesAgrupados.Add(chave, componenteRow);
                        }
                        else
                        {
                            
                        }
                        componentesAgrupados[chave].quantidade = Math.Round(componentesAgrupados[chave].quantidade + componente.Quantidade, 5);


                       
                    }

                    foreach (OpReportDataSet.ordem_producao_produto_componenteRow componenteRow in componentesAgrupados.Values.OrderBy(a=>a.produto_codigo))
                    {
                        ds.ordem_producao_produto_componente.Addordem_producao_produto_componenteRow(componenteRow);
                    }


                    //Relacionadas
                    if (OP.imprimeOpsRelacionadas)
                    {
                        List<OrdemProducaoClass> tmp = OP.carregaOpsRelacionadas().OrderBy(a => a.produtoCodigo).ToList();
                        foreach (OrdemProducaoClass relacionada in tmp)
                        {
                            relRow = ds.ordem_producao_relacionadas.Newordem_producao_relacionadasRow();
                            relRow.id_ordem_producao = (int)OP.idOrdemProducao;
                            relRow.numero_op_relacionada = (int)relacionada.idOrdemProducao.Value;
                            relRow.codigo_item = relacionada.produtoCodigo;
                            relRow.descricao_item = relacionada.produtoDescricao;
                            relRow.quantidade = relacionada.Quantidade;

                            ds.ordem_producao_relacionadas.Addordem_producao_relacionadasRow(relRow); 
                        }
                    }


                    if (carregarDocumentosImpressaoOp != null)
                    {
                        List<byte[]> documentosImprimir = _carregarDocumentosImpressaoOp.CarregarDocumentosImpressaoDireta(OP.idOrdemProducao.Value, this.Usuario, conn);
                        if (documentosImprimir == null || documentosImprimir.Count == 0)
                        {
                            opRow.imprimir_documento_direto = false;
                        }
                        else
                        {
                            opRow.imprimir_documento_direto = true;
                            OpReportDataSet.ordem_producao_documento_imprimirRow documentoImprimirRow;
                            foreach (byte[] docImprimir in documentosImprimir)
                            {
                                documentoImprimirRow = ds.ordem_producao_documento_imprimir.Newordem_producao_documento_imprimirRow();
                                documentoImprimirRow.documento_dados = docImprimir;
                                documentoImprimirRow.id_ordem_producao = opRow.id_ordem_producao;
                                ds.ordem_producao_documento_imprimir.Addordem_producao_documento_imprimirRow(documentoImprimirRow);
                            }
                        }
                    }
                    else
                    {
                        opRow.imprimir_documento_direto = false;

                    }

                }

                OpReport report = new OpReport();
                report.SetDataSource(ds);

                string semanaTmp = IWTFunctions.IWTFunctions.getNumeroSemana(Configurations.DataIndependenteClass.GetData(), this.tipoCalculoSemana, this.diaCalculoSemana).ToString();
                semanaTmp = Configurations.DataIndependenteClass.GetData().ToString("yy") + semanaTmp.PadLeft(2, '0');

                report.SetParameterValue("semanaImpressao",semanaTmp);

                if (Impressao && !string.IsNullOrEmpty(Impressora))
                {
                    report.PrintOptions.PrinterName = Impressora;
                    report.PrintToPrinter(1, false, 0, 99999);



                    //Imprimir as estruturas dos itens que precisarem
                    foreach (OrdemProducaoClass op in list.Where(a=>a.Produto.ImprimirEstruturaOp))
                    {
                        NewProdutoTreeClass estruturaAtual = new NewProdutoTreeClass(op.Produto);

                        EstruturaProdutoReport rep = new EstruturaProdutoReport();
                        rep.SetDataSource(NewProdutoReportClass.fillReport(estruturaAtual,TipoRelatorioEstrutura.PrimeiroFilhos));
                        
                     
                        rep.PrintOptions.PrinterName = Impressora;
                        rep.PrintToPrinter(1, false, 0, 99999);
                    }

                    this.Close();
                }
                else
                {
                    crystalReportViewer1.ReportSource = report;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao gerar relatório.\r\n" + a.Message);
                //MessageBox.Show("Erro ao gerar relatório.\r\n" + a.Message, "Ordem de Produção", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }


       

        private class OrdemProducaoMateriaReportKey : IEquatable<OrdemProducaoMateriaReportKey>
        {

            public MaterialClass Material { get; set; }
            public string Descricao { get; set; }
            public string UnidadeMedida { get; set; }
            public double Espessura { get; set; }

            public double Largura { get; set; }
            public double Comprimento { get; set; }
            public string tipoAcabamento { get; set; }
            public string Codigo { get; set; }

            public string Familia { get; set; }
            public int idOP { get; set; }

            public bool Equals(OrdemProducaoMateriaReportKey other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(Codigo, other.Codigo) && Comprimento.Equals(other.Comprimento) && string.Equals(Descricao, other.Descricao) && Espessura.Equals(other.Espessura) && string.Equals(Familia, other.Familia) && idOP == other.idOP && Largura.Equals(other.Largura) && Equals(Material, other.Material) && string.Equals(tipoAcabamento, other.tipoAcabamento) && string.Equals(UnidadeMedida, other.UnidadeMedida);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((OrdemProducaoMateriaReportKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (Codigo != null ? Codigo.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ Comprimento.GetHashCode();
                    hashCode = (hashCode*397) ^ (Descricao != null ? Descricao.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ Espessura.GetHashCode();
                    hashCode = (hashCode*397) ^ (Familia != null ? Familia.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ idOP;
                    hashCode = (hashCode*397) ^ Largura.GetHashCode();
                    hashCode = (hashCode*397) ^ (Material != null ? Material.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (tipoAcabamento != null ? tipoAcabamento.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (UnidadeMedida != null ? UnidadeMedida.GetHashCode() : 0);
                    return hashCode;
                }
            }

            public static bool operator ==(OrdemProducaoMateriaReportKey left, OrdemProducaoMateriaReportKey right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(OrdemProducaoMateriaReportKey left, OrdemProducaoMateriaReportKey right)
            {
                return !Equals(left, right);
            }
        }

        private class ProdutoComponenteChave : IEquatable<ProdutoComponenteChave>
        {
            public String Codigo { get; set; }
            public string Dimensao { get; set; }
            public string Descricao { get; set; }

            public bool Equals(ProdutoComponenteChave other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(Codigo, other.Codigo) && string.Equals(Dimensao, other.Dimensao) && string.Equals(Descricao, other.Descricao);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ProdutoComponenteChave) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (Codigo != null ? Codigo.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Dimensao != null ? Dimensao.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Descricao != null ? Descricao.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }
        

    }


}
