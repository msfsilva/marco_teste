#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaProdutos;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using CrystalDecisions.Shared;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using OrdemCompraClass = BibliotecaEntidades.Operacoes.Compras.OrdemCompraClass;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

#endregion

namespace BibliotecaCompras
{
    public partial class OcReportForm : IWTBaseForm
    {
        
        readonly EnviaOCEmailClass enviadorEmail;
        private EmitenteClass emitente;
        public OcReportForm(ref IWTPostgreNpgsqlCommand command, int? idOc,  byte[] logoEmpresa, EnviaOCEmailClass enviadorEmail, string Remetente)
        
        {
            InitializeComponent();
            PisCofinsInfo pisCofinsDefault;
            NotaFiscalFuncoesAuxiliares.CarregaEmitente(command.Connection, out emitente, EasiEmissorNFe.Primario, out pisCofinsDefault);

            this.enviadorEmail = enviadorEmail;

            List<OcReportClass> oc = new List<OcReportClass>();
            try
            {
                #region Logo

                byte[] tmp = logoEmpresa;

                if (logoEmpresa != null)
                {
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    //imagem.Save("C:\\teste.bmp");
                    tmp = ms.ToArray();
                }


                #endregion

                command.CommandText =
                    "SELECT                                                                                                                   " +
                    "   tipo,	                                                                                                                  " +
                    "   orc_valor,                                                                                                              " +
                    "   orc_desconto_p,                                                                                                              " +
                    "   orc_desconto_r,                                                                                                              " +
                    "   for_razao_social,                                                                                                    " +
                    "   for_cnpj,                                                                                                            " +
                    "   for_fone1,                                                                                                           " +
                    "   for_email,                                                                                                           " +
                    "   for_contato, "+
                    "   for_endereco,                                                                                                           " +
                    "   cid_nome,                                                                                                           " +
                    "   est_sigla,                                                                                                           " +
                    "   valor_unit,                                                                                                           " +
                    "   id_ordem_compra,                                                                                                           " +
                    "   codigo,                                                                                                              " +
                    "   descricao,                                                                                                           " +
                    "   soc_qtd,		                                                                                                     " +
                    "   familia,		                                                                                                     " +
                    "   unidade,	                                                                                                     " +
                    "   descricaoAdicional,                                                         " +
                    "   marcasHomologadas, " +
                    "   soc_entrega_prevista, " +
                    "   CASE orc_status WHEN 0 THEN 'Nova' WHEN 1 THEN 'Enviada' WHEN 2 THEN 'Recebida parcial' WHEN 3 THEN 'Recebida' WHEN 4 THEN 'Cancelada' ELSE '' END AS status_oc, " +
                    "   ipi, " +
                    "   icms, " +
                    "   acabamento, " +
                    "   medida1, " +
                    "   medida2, " +
                    "   medida3, " +
                    "   for_end_numero, " +
                    "   for_end_complemento, " +
                    "   for_envio_email, " +
                    "   for_email_pedido, " +
                    "   for_email_cotacao, " +
                    "   orc_tipo, " +
                    "   orc_rodape, " +
                    "   orc_msg_email, " +
                    "   com_nome, " +
                    "   com_email, " +
                    "   com_fone, " +
                    "   com_ramal, " +
                    "   com_observacao, " +
                    "   id_comprador, " +
                    "   fop_descricao, " +
                    "   orc_observacao, " +  
                    "   codigo_interno," +
                    "   id_fornecedor "+
                    "FROM (                                                                                                                   " +
                    "SELECT                                                                                                                   " +
                    "  'MATERIAL' AS tipo,                                                                                                    " +
                    "  public.ordem_compra.orc_valor,                                                                                         " +
                    "  public.ordem_compra.orc_desconto_p,                                                                                    " +
                    "  public.ordem_compra.orc_desconto_r,                                                                                    " +
                    "  public.fornecedor.for_razao_social,                                                                                    " +
                    "  public.fornecedor.for_cnpj,                                                                                            " +
                    "  public.fornecedor.for_fone1,                                                                                           " +
                    "  public.fornecedor.for_email,                                                                                           " +
                    "  public.fornecedor.for_contato,                                                                                           " +
                    "  public.fornecedor.for_endereco,                                                                                        " +
                    "  public.cidade.cid_nome,                                                                                          " +
                    "  public.material.mat_descricao AS descricao,                                                                            " +
                    "  public.material.mat_descricao_adicional AS descricaoAdicional,                                                         " +
                    "  public.material.mat_marcas_homologadas AS marcasHomologadas,                                                           " +
                    "  public.material.mat_codigo AS codigo,                                                                                  " +
                    "  public.solicitacao_compra.soc_qtd,                                                                                     " +
                    "  public.ordem_compra.id_ordem_compra,                                                                                   " +
                    "  public.estado.est_sigla,                                                                                               " +
                    "  COALESCE(soc_valor_unitario_oc, public.material_fornecedor.maf_ultimo_preco) AS valor_unit,                                                             " +
                    "  public.familia_material.fam_codigo AS familia,                                                                       " +
                    "  soc_unidade_compra as unidade, " +
                    "  soc_entrega_prevista, " +
                    "  public.ordem_compra.orc_status, " +
                    "  COALESCE(soc_aliquota_ipi_oc, public.material_fornecedor.maf_ipi) AS ipi, " +
                    "  COALESCE(soc_aliquota_icms_oc, public.material_fornecedor.maf_icms) AS icms, " +
                    "  public.acabamento.acb_identificacao AS acabamento, " +
                    "  public.material.mat_medida AS medida1, " +
                    "  public.material.mat_medida_largura AS medida2, " +
                    "  public.material.mat_medida_comprimento AS medida3, " +
                    "  soc_numero_linha_oc, " +
                    "  for_end_numero, " +
                    "  for_end_complemento, " +
                    "  for_envio_email, " +
                    "  for_email_pedido, " +
                    "  for_email_cotacao, " +
                    "  orc_tipo, " +
                    "  orc_rodape, " +
                    "  orc_msg_email, " +
                    "  public.comprador.com_nome, " +
                    "  public.comprador.com_email, " +
                    "  public.comprador.com_fone, " +
                    "  public.comprador.com_ramal, " +
                    "  public.comprador.com_observacao, " +
                    "  public.comprador.id_comprador, " +
                    "  public.forma_pagamento.fop_descricao, " +
                    "  public.ordem_compra.orc_observacao, " +    
                    "  'M'||public.material.id_material as codigo_interno, " +
                    "  fornecedor.id_fornecedor " +
                    "FROM                                                                                                                     " +
                    "  public.solicitacao_compra                                                                                              " +
                    "  INNER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra)    " +
                    "  LEFT JOIN public.forma_pagamento ON (public.ordem_compra.id_forma_pagamento = public.forma_pagamento.id_forma_pagamento)                  " +
                    "  INNER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor)                  " +
                    "  LEFT JOIN public.estado ON (public.fornecedor.id_estado = public.estado.id_estado)                                    " +
                    "  INNER JOIN public.material ON (public.solicitacao_compra.id_material = public.material.id_material)                    " +
                    //"  INNER JOIN public.unidade_medida ON (public.unidade_medida.id_unidade_medida = public.material.id_unidade_medida)                    " +
                    //"  LEFT JOIN public.unidade_medida u2 ON (u2.id_unidade_medida = public.material.id_unidade_medida_compra)                    " +
                    "  INNER JOIN public.familia_material ON (public.familia_material.id_familia_material = public.material.id_familia_material)                    " +
                    "  INNER JOIN public.material_fornecedor ON (public.material_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor AND public.material_fornecedor.id_material = public.material.id_material)   " +
                    "  INNER JOIN public.acs_usuario ON (public.ordem_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)          " +
                    "  LEFT JOIN public.acabamento ON (public.acabamento.id_acabamento = material.id_acabamento) " +
                    "  LEFT OUTER JOIN public.comprador ON (public.ordem_compra.id_comprador = public.comprador.id_comprador) " +
                    "  LEFT JOIN cidade ON (cidade.id_cidade = fornecedor.id_cidade) " +
                    "WHERE maf_ativo = 1 " +
                    "                                                                                                                         " +
                    "  UNION ALL                                                                                                                  " +
                    "                                                                                                                         " +
                    " SELECT                                                                                                                  " +
                    " 'PRODUTO' AS tipo,                                                                                                      " +
                    "  public.ordem_compra.orc_valor,                                                                                         " +
                    "  public.ordem_compra.orc_desconto_p,                                                                                    " +
                    "  public.ordem_compra.orc_desconto_r,                                                                                    " +
                    "  public.fornecedor.for_razao_social,                                                                                    " +
                    "  public.fornecedor.for_cnpj,                                                                                            " +
                    "  public.fornecedor.for_fone1,                                                                                           " +
                    "  public.fornecedor.for_email,                                                                                           " +
                    "  public.fornecedor.for_contato,                                                                                           " +
                    "  public.fornecedor.for_endereco,                                                                                        " +
                    "  public.cidade.cid_nome,                                                                                          " +
                    "  public.produto.pro_descricao AS descricao,                                                                             " +
                    "  public.produto.pro_descricao_adicional|| ' Revisão Nº '||pro_versao_estrutura_atual AS descricaoAdicional,                                                         " +
                    "  public.produto.pro_marcas_homologadas AS marcasHomologadas,                                                           " +
                    "  public.produto.pro_codigo AS codigo,                                                                                   " +
                    "  public.solicitacao_compra.soc_qtd,                                                                                     " +
                    "  public.ordem_compra.id_ordem_compra,                                                                                   " +
                    "  public.estado.est_sigla,                                                                                               " +
                    "  COALESCE(soc_valor_unitario_oc, public.produto_fornecedor.prf_ultimo_preco) AS valor_unit,                                                              " +
                    "  '' AS familia,                                                                                                         " +
                    "  soc_unidade_compra as unidade, "+
                    "  soc_entrega_prevista, " +
                    "  public.ordem_compra.orc_status, " +
                    "  COALESCE(soc_aliquota_ipi_oc, public.produto_fornecedor.prf_ipi) AS ipi, " +
                    "  COALESCE(soc_aliquota_icms_oc, public.produto_fornecedor.prf_icms) AS icms, " +
                    "  public.acabamento.acb_identificacao AS acabamento, " +
                    "  emb_comprimento AS medida1, " +
                    "  emb_largura AS medida2, " +
                    "  emb_altura AS medida3, " +
                    "  soc_numero_linha_oc, " +
                    "  for_end_numero, " +
                    "  for_end_complemento, " +
                    "  for_envio_email, " +
                    "  for_email_pedido, " +
                    "  for_email_cotacao, " +
                    "  orc_tipo, " +
                    "  orc_rodape, " +
                    "  orc_msg_email, " +
                    "  public.comprador.com_nome, " +
                    "  public.comprador.com_email, " +
                    "  public.comprador.com_fone, " +
                    "  public.comprador.com_ramal, " +
                    "  public.comprador.com_observacao, " +
                    "  public.comprador.id_comprador, " +
                    "  public.forma_pagamento.fop_descricao, " +
                    "  public.ordem_compra.orc_observacao, " +   
                    "  '' as codigo_interno, "+
                    "  fornecedor.id_fornecedor " +
                    "FROM                                                                                                                     " +
                    "  public.solicitacao_compra                                                                                              " +
                    "  INNER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra)    " +
                    "  LEFT JOIN public.forma_pagamento ON (public.ordem_compra.id_forma_pagamento = public.forma_pagamento.id_forma_pagamento)                  " +
                    "  INNER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor)                  " +
                    "  INNER JOIN public.acs_usuario ON (public.ordem_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)          " +
                    "  INNER JOIN public.produto ON (public.solicitacao_compra.id_produto = public.produto.id_produto)                        " +
                    "  INNER JOIN public.produto_fornecedor ON (public.produto_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor AND public.produto_fornecedor.id_produto = public.produto.id_produto)    " +
                    "  LEFT JOIN public.estado ON (public.fornecedor.id_estado = public.estado.id_estado)                                    " +
                    //"  INNER JOIN public.unidade_medida ON (public.unidade_medida.id_unidade_medida = public.produto.id_unidade_medida)       " +
                    //"  LEFT JOIN public.unidade_medida u2 ON (u2.id_unidade_medida = public.produto.id_unidade_medida_compra)                    " +
                    "  LEFT JOIN public.acabamento ON (public.acabamento.id_acabamento = produto.id_acabamento) " +
                    "  LEFT OUTER JOIN public.comprador ON (public.ordem_compra.id_comprador = public.comprador.id_comprador) " +
                    "  LEFT JOIN cidade ON (cidade.id_cidade = fornecedor.id_cidade) " +
                    "  LEFT JOIN embalagem ON (produto.id_embalagem = embalagem.id_embalagem )" +
                    "WHERE prf_ativo = 1 " +
                    "                                                                                                                       " +
                    " UNION ALL                                                                                                             " +
                    "                                                                                                                           " +
                    "SELECT                                                                                                                   " +
                    "  'EPI' AS tipo,                                                                                                    " +
                    "  public.ordem_compra.orc_valor,                                                                                         " +
                    "  public.ordem_compra.orc_desconto_p,                                                                                    " +
                    "  public.ordem_compra.orc_desconto_r,                                                                                    " +
                    "  public.fornecedor.for_razao_social,                                                                                    " +
                    "  public.fornecedor.for_cnpj,                                                                                            " +
                    "  public.fornecedor.for_fone1,                                                                                           " +
                    "  public.fornecedor.for_email,                                                                                           " +
                    "  public.fornecedor.for_contato,                                                                                           " +
                    "  public.fornecedor.for_endereco,                                                                                        " +
                    "  public.cidade.cid_nome,                                                                                          " +
                    "  public.epi.epi_descricao AS descricao,                                                                            " +
                    "  public.epi.epi_descricao_adicional AS descricaoAdicional,                                                         " +
                    "  public.epi.epi_marcas_homologadas AS marcasHomologadas,                                                           " +
                    "  public.epi.epi_identificacao AS codigo,                                                                                  " +
                    "  public.solicitacao_compra.soc_qtd,                                                                                     " +
                    "  public.ordem_compra.id_ordem_compra,                                                                                   " +
                    "  public.estado.est_sigla,                                                                                               " +
                    "  COALESCE(soc_valor_unitario_oc, public.epi_fornecedor.epf_ultimo_preco) AS valor_unit,                                                             " +
                    "  '' AS familia,                                                                       " +
                    "  soc_unidade_compra as unidade, " +
                    "  soc_entrega_prevista, " +
                    "  public.ordem_compra.orc_status, " +
                    "  COALESCE(soc_aliquota_ipi_oc, public.epi_fornecedor.epf_ipi) AS ipi, " +
                    "  COALESCE(soc_aliquota_icms_oc, public.epi_fornecedor.epf_icms) AS icms, " +
                    "  '' AS acabamento, " +
                    "  0 AS medida1, " +
                    "  0 AS medida2, " +
                    "  0 AS medida3, " +
                    "  soc_numero_linha_oc, " +
                    "  for_end_numero, " +
                    "  for_end_complemento, " +
                    "  for_envio_email, " +
                    "  for_email_pedido, " +
                    "  for_email_cotacao, " +
                    "  orc_tipo, " +
                    "  orc_rodape, " +
                    "  orc_msg_email, " +
                    "  public.comprador.com_nome, " +
                    "  public.comprador.com_email, " +
                    "  public.comprador.com_fone, " +
                    "  public.comprador.com_ramal, " +
                    "  public.comprador.com_observacao, " +
                    "  public.comprador.id_comprador, " +
                    "  public.forma_pagamento.fop_descricao, " +
                    "  public.ordem_compra.orc_observacao, " +
                    "  'CA: '||epi_ca.eca_numero as codigo_interno, " +
                    "  fornecedor.id_fornecedor " +
                    "FROM                                                                                                                     " +
                    "  public.solicitacao_compra                                                                                              " +
                    "  INNER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra)    " +
                    "  LEFT JOIN public.forma_pagamento ON (public.ordem_compra.id_forma_pagamento = public.forma_pagamento.id_forma_pagamento)                  " +
                    "  INNER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor)                  " +
                    "  LEFT JOIN public.estado ON (public.fornecedor.id_estado = public.estado.id_estado)                                    " +
                    "  INNER JOIN public.epi ON (public.solicitacao_compra.id_epi = public.epi.id_epi)                    " +
                    "  INNER JOIN public.epi_fornecedor ON (public.epi_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor AND public.epi_fornecedor.id_epi = public.epi.id_epi)   " +
                    "  INNER JOIN public.epi_ca ON (public.epi_ca.id_epi_ca = public.epi.id_epi_ca)   " +
                    "  INNER JOIN public.acs_usuario ON (public.ordem_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)          " +
                    "  LEFT OUTER JOIN public.comprador ON (public.ordem_compra.id_comprador = public.comprador.id_comprador) " +
                    "  LEFT JOIN cidade ON (cidade.id_cidade = fornecedor.id_cidade) " +
                    "WHERE epf_ativo = 1 " +
                    "  ) AS tab                                                                                                               " +
                    "WHERE                                                                                                                    " +
                    "  id_ordem_compra = " + idOc + " " +
                    "ORDER BY " +
                    "  soc_numero_linha_oc ";

                bool enviarEmail = false;
                string emailCompras = null;
                string emailCotacoes = null;
                string msgEmail = null;

                TipoOC Tipo = TipoOC.OC;

                double valorTotalOcComImpostos = 0;
                double valorTotalOcComDesconto = 0;

                OcReportClass ocReportClass;
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    bool first = true;
                    Byte[] array = new Byte[] {};
                    while (read.Read())
                    {
                        if (first)
                        {
                            string tempDir = Environment.GetEnvironmentVariable("temp");
                            Process process = new Process();
                            process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory +
                                                         "\\barcode\\barcode.exe";

                            process.StartInfo.Arguments = "OC_" + read["id_ordem_compra"] + " " + tempDir + "\\code.bmp";
                            process.Start();
                            process.WaitForExit();

                            FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                            BinaryReader br = new BinaryReader(fs);
                            array = br.ReadBytes((int) fs.Length);
                            br.Close();
                            fs.Close();

                            first = false;

                            enviarEmail = Convert.ToBoolean(Convert.ToInt16(read["for_envio_email"]));
                            emailCompras = read["for_email_pedido"].ToString();
                            emailCotacoes = read["for_email_cotacao"].ToString();
                            msgEmail = read["orc_msg_email"].ToString();


                            Tipo = (TipoOC) Enum.ToObject(typeof (TipoOC), read["orc_tipo"]);

                        }
                        double totalItem = 0;
                        double valorUnitario = 0;
                        if (read["valor_unit"] != DBNull.Value && read["valor_unit"] != null)
                        {
                            valorUnitario = Convert.ToDouble(read["valor_unit"]);
                            totalItem = (Convert.ToDouble(read["soc_qtd"])*valorUnitario);
                        }

                        double valorComDesconto = totalItem;

                        double ordemCompraValor = (Convert.ToDouble(read["orc_valor"]));
                        double ordemCompraDescontoR = (Convert.ToDouble(read["orc_desconto_r"]));
                        double ordemCompraDescontoP = (Convert.ToDouble(read["orc_desconto_p"]));

                        if (ordemCompraDescontoP > 0)
                        {
                            double desconto = ordemCompraDescontoP / 100;

                            Double? valorUnitarioOc = (valorUnitario * (1 - desconto));
                            Double? valorTotalOc = valorUnitarioOc * (Convert.ToDouble(read["soc_qtd"]));

                            if (valorTotalOc.HasValue)
                            {
                                valorComDesconto = Math.Round(valorTotalOc.Value, 2);
                            }

                        }

                        else if (ordemCompraDescontoR > 0)
                        {
                            double razao = Math.Round((totalItem / ordemCompraValor), 15, MidpointRounding.ToEven);
                            double desconto = Math.Round(ordemCompraDescontoR * razao, 4);

                            Double? valorTotalOc = totalItem - desconto;

                            if (valorTotalOc.HasValue)
                            {
                                valorComDesconto = Math.Round(valorTotalOc.Value, 2);

                            }

                        }

                        DateTime? dataEntrega = null;
                        if (read["soc_entrega_prevista"] != DBNull.Value && read["soc_entrega_prevista"] != null)
                        {
                            dataEntrega = Convert.ToDateTime(read["soc_entrega_prevista"]);
                        }

                        string medida = "0 x 0 x 0";
                        if (read["medida1"] != DBNull.Value && read["medida2"] != DBNull.Value && read["medida3"] != DBNull.Value)
                        {
                            medida =
                                Convert.ToDouble(read["medida1"]).ToString("F2", CultureInfo.CurrentCulture).Replace(",00",
                                    "") +
                                " x " +
                                Convert.ToDouble(read["medida2"]).ToString("F2", CultureInfo.CurrentCulture).Replace(",00",
                                    "") +
                                " x " +
                                Convert.ToDouble(read["medida3"]).ToString("F2", CultureInfo.CurrentCulture).Replace(",00",
                                    "");
                        }
                        

                        if (medida == "0 x 0 x 0")
                        {
                            medida = "";
                        }

                        string contato = emitente.Contato;
                        string fone = emitente.Telefone;
                        string email = IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_REMETENTE);

                        if (read["id_comprador"] != DBNull.Value)
                        {
                            contato = read["com_nome"].ToString();
                            fone = read["com_fone"].ToString();
                            if (read["com_ramal"] != DBNull.Value)
                            {
                                fone += " (" + read["com_ramal"] + ")";
                            }
                            email = read["com_email"].ToString();
                        }


                        oc.Add(ocReportClass = new OcReportClass(idOc.ToString(), read["status_oc"].ToString(),
                                                                 read["tipo"].ToString(),
                                                                 Convert.ToDouble(read["orc_valor"]),
                                                                 Convert.ToInt64(read["id_fornecedor"]),
                                                                 read["for_razao_social"].ToString(),
                                                                 read["for_cnpj"].ToString(),
                                                                 read["for_fone1"].ToString(),
                                                                 read["for_email"].ToString(),
                                                                 read["for_contato"].ToString(),
                                                                 read["for_endereco"] + ", " +
                                                                 read["for_end_numero"] + " " +
                                                                 read["for_end_complemento"],
                                                                 read["cid_nome"].ToString(),
                                                                 read["est_sigla"].ToString(), read["codigo"].ToString(),
                                                                 read["descricao"].ToString(),
                                                                 read["descricaoAdicional"].ToString(),
                                                                 read["marcasHomologadas"].ToString(),
                                                                 Convert.ToDouble(read["soc_qtd"]),
                                                                 array, valorUnitario, read["unidade"].ToString(),
                                                                 read["familia"].ToString(),
                                                                 dataEntrega,
                                                                 this.emitente.RazaoSocial,
                                                                 emitente.Cnpj,
                                                                 fone,
                                                                 email,
                                                                 emitente.EnderecoCompleto,
                                                                 emitente.Cidade,
                                                                 emitente.Estado,
                                                                 contato,
                                                                 Convert.ToDouble(read["ipi"]),
                                                                 Convert.ToDouble(read["icms"]),
                                                                 read["acabamento"].ToString(),
                                                                 medida, tmp, read["orc_rodape"].ToString(),
                                                                 read["orc_observacao"].ToString(),
                                                                 read["fop_descricao"].ToString(),
                                                                 read["codigo_interno"].ToString(),
                                                                 valorComDesconto
                                                                 )
                            );

                        valorTotalOcComImpostos += oc[oc.Count - 1].valotTotalComImpostos;
                        valorTotalOcComDesconto += valorComDesconto;
                    }

                    read.Close();

                    BibliotecaEntidades.Entidades.OrdemCompraClass ocEntidade = BibliotecaEntidades.Entidades.OrdemCompraClass.GetEntidade(Convert.ToInt64(idOc), LoginClass.UsuarioLogado.loggedUser, command.Connection);

                    foreach (OcReportClass reportClass in oc)
                    {
                        reportClass.ValorTotalOCcomImpostos = valorTotalOcComImpostos;
                        reportClass.valorTotalComDesconto = valorTotalOcComDesconto;
                        reportClass.AguardandoAprovacao = ocEntidade.Status == StatusOrdemCompra.AguardandoAprovacaoCompras;
                    }

                    OcReport rep = new OcReport();
                    rep.SetDataSource(oc);
                    this.crystalReportViewer1.ReportSource = rep;
                    this.crystalReportViewer1.RefreshReport();

                    if (this.enviadorEmail != null && enviarEmail)
                    {
                        if (
                            MessageBox.Show(this,
                                            "O EASI está configurado para e enviar automaticamente a Ordem de Compa/Solicitação de Orçamento para esse fornecedor. Deseja enviar agora?\r\nSim: Envia automaticamente para o fornecedor e abre o documento para visualização\r\nNão: Só abre para visualização",
                                            "Envio Automático de Email", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            string Destinatario = "";

                            if (Tipo == TipoOC.OC)
                            {
                                Destinatario = emailCompras;
                            }
                            else
                            {
                                Destinatario = emailCotacoes;
                            }

                            List<Stream> documentosEnviar = new List<Stream>();
                            List<string> nomesDocumentosEnviar = new List<string>();

                            OrdemCompraClass ordemCompra = new OrdemCompraClass(idOc.Value, ref command, LoginClass.UsuarioLogado.loggedUser, true);
                            foreach (SolicitacaoCompraClass solicitacao in ordemCompra.Solicitacoes.Values.Where(a => a.Produto != null))
                            {
                                foreach (ProdutoDocumentoTipoClass documento in solicitacao.Produto.Documentos.Where(a => a.DocumentoTipoFamilia.FamiliaDocumento.DocumentosCompra))
                                {
                                    if (documento.DocumentoTipoFamilia.Documento != null)
                                    {
                                        documentosEnviar.Add(new MemoryStream(documento.DocumentoTipoFamilia.Documento));
                                        nomesDocumentosEnviar.Add(documento.DocumentoTipoFamilia.DocumentoNome);
                                        ordemCompra.adicionarDocumento(documento);
                                    }
                                }
                            }

                            this.enviadorEmail.setOC(idOc.Value, rep.ExportToStream(ExportFormatType.PortableDocFormat),
                                                     Tipo, documentosEnviar, nomesDocumentosEnviar);
                            this.enviadorEmail.Enviar(Destinatario, Remetente, msgEmail);


                            ordemCompra.setEnviada();
                            ordemCompra.Salvar(ref command);

                        }

                    }


                }
                else
                {
                    throw new Exception("Não há dados para geração da OC");
                }
            }
            catch (Exception a)
            {
                throw new Exception(a.Message);
            }
         
        }
  
    }
}
