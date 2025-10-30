using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using BibliotecaImpressoraTermica;
using IWTDotNetLib;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace IWTNFCompleto
{
    public static class NFCeImpressaoDanfeClass
    {
        public static void ImprimirDanfeV4(Image logo, IImpressoraTermicaFactory factoryImpressora, string enderecoImpressora, int larguraPapelMM, bool viaEstabelecimento, IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe nota = null, IWTNFCompleto.BibliotecaDatasets.v4_0.TNfeProc nfeProc = null)
        {
            ImpressoraTermica impressora = null;
            bool logoCarregado = false;
            const int indiceLogoMemoriaImpressora = 1;
            const int margem = 2;
            try
            {
                if (nota == null)
                {
                    if (nfeProc != null)
                    {
                        nota = nfeProc.NFe;
                    }
                    else
                    {
                        throw new Exception("A nota fiscal não pode ser vazia");
                    }

                }

                if (factoryImpressora == null)
                {
                    throw new Exception("O Factory da Impressora Térmica não pode ser vazio");
                }

                if (larguraPapelMM < 72)
                {
                    throw new ExcecaoTratada("A Danfe da NFCe não pode ser impressa em papel menor do que 72 mm");
                }

                impressora = factoryImpressora.getImpressoraTermica(enderecoImpressora);
                impressora.DefinirLarguraPapel(larguraPapelMM);
                impressora.DefinirFonte(7);
                impressora.DefinirAlturaLinha(3);
                float colunaCNPJ = margem;

                #region Divisão I

                impressora.DeslocarY(margem);
                if (logo != null)
                {
                    impressora.CarregarImagemMemoria(indiceLogoMemoriaImpressora, logo);
                    logoCarregado = true;
                    impressora.ImprimeImagem(1, margem, null, 12, 12, false, TipoAlinhamento.Esquerdo);
                    colunaCNPJ = margem + 12 + 2f;
                }


                string texto = nota.infNFe.emit.xNome;
                impressora.ImprimeLinhaTexto(texto, colunaCNPJ, larguraPapelMM - colunaCNPJ - margem, true, TipoAlinhamento.Esquerdo);

                texto = nota.infNFe.emit.Item;
                if (texto.Length == 14)
                {
                    texto = texto.Substring(0, 2) + "." + texto.Substring(2, 3) + "." + texto.Substring(5, 3) + "/" + texto.Substring(8, 4) + "-" + texto.Substring(12, 2);
                }

                if (texto.Length == 11)
                {
                    texto = texto.Substring(0, 3) + "." + texto.Substring(3, 3) + "." + texto.Substring(6, 3) + "-" + texto.Substring(9, 2);
                }

                texto = "CNPJ " + texto;
                impressora.ImprimeLinhaTexto(texto, colunaCNPJ, larguraPapelMM - colunaCNPJ - margem, true, TipoAlinhamento.Esquerdo);

                texto = "";
                if (!string.IsNullOrWhiteSpace(nota.infNFe.emit.IE))
                {
                    texto += " / IE " + nota.infNFe.emit.IE;
                }

                if (!string.IsNullOrWhiteSpace(nota.infNFe.emit.IM))
                {
                    texto += " / IM " + nota.infNFe.emit.IM;
                }
                if (texto.Length > 0)
                {
                    texto = texto.Substring(3);
                    impressora.ImprimeLinhaTexto(texto, colunaCNPJ, larguraPapelMM - colunaCNPJ - margem, true, TipoAlinhamento.Esquerdo);
                }

                texto = nota.infNFe.emit.enderEmit.xLgr + ", " + nota.infNFe.emit.enderEmit.nro + ", " + nota.infNFe.emit.enderEmit.xBairro + " - " + nota.infNFe.emit.enderEmit.xMun + " - " + nota.infNFe.emit.enderEmit.UF;
                impressora.ImprimeLinhaTexto(texto, colunaCNPJ, larguraPapelMM - colunaCNPJ - margem, true, TipoAlinhamento.Esquerdo);

                impressora.DeslocarY(1);
                impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                impressora.DeslocarY(1);

                #endregion

                #region Divisão II

                impressora.ImprimeLinhaTexto("DANFE NFC-e - Documento Auxiliar", 0, null, true, TipoAlinhamento.Centralizado);
                impressora.ImprimeLinhaTexto("da Nota Fiscal de Consumidor Eletrônica", 0, null, true, TipoAlinhamento.Centralizado);
                impressora.ImprimeLinhaTexto("Não permite aproveitamento de crédito de ICMS", 0, null, true, TipoAlinhamento.Centralizado);

                impressora.DeslocarY(1);
                impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);

                #endregion

                if (nota.infNFe.ide.TpEmisLegado == IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeIdeTpEmisLegado.ContingenciaOffLineNFCe)
                {
                    ImprimirAvisoContingencia(impressora, margem, larguraPapelMM);
                    impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                }

                #region Divisão III

                const int colunaCodigo = 2;
                const int colunaDescricao = 12;
                const int colunaQtd = 35;
                const int colunaUn = 42;
                const int colunaVlUnitario = 46;
                const int colunaVlTotal = 58;

                impressora.ImprimeLinhaVertical(colunaDescricao, 5, 0.2f);
                impressora.ImprimeLinhaVertical(colunaQtd, 5, 0.2f);
                impressora.ImprimeLinhaVertical(colunaUn, 5, 0.2f);
                impressora.ImprimeLinhaVertical(colunaVlUnitario, 5, 0.2f);
                impressora.ImprimeLinhaVertical(colunaVlTotal, 5, 0.2f);

                impressora.DeslocarY(1);

                impressora.ImprimeLinhaTexto("Código", colunaCodigo, colunaDescricao - colunaCodigo, false, TipoAlinhamento.Esquerdo);
                impressora.ImprimeLinhaTexto("Descrição", colunaDescricao, colunaQtd - colunaDescricao, false, TipoAlinhamento.Esquerdo);
                impressora.ImprimeLinhaTexto("Qtde", colunaQtd, colunaUn - colunaQtd, false, TipoAlinhamento.Direita);
                impressora.ImprimeLinhaTexto("Un", colunaUn, colunaVlUnitario - colunaUn, false, TipoAlinhamento.Esquerdo);
                impressora.ImprimeLinhaTexto("Vl Unit", colunaVlUnitario, colunaVlTotal - colunaVlUnitario, false, TipoAlinhamento.Direita);
                impressora.ImprimeLinhaTexto("Vl Total", colunaVlTotal, larguraPapelMM - margem - colunaVlTotal, true, TipoAlinhamento.Direita);

                impressora.DeslocarY(1);
                impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                impressora.DeslocarY(1);

                impressora.DefinirFonte(6);
                double tmpDouble;
                foreach (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet item in nota.infNFe.det)
                {

                    impressora.ImprimeLinhaTexto(item.prod.cProd, colunaCodigo, colunaDescricao - colunaCodigo, false, TipoAlinhamento.Esquerdo);

                    impressora.ImprimeLinhaTexto(item.prod.xProd, colunaDescricao, colunaQtd - colunaDescricao, false, TipoAlinhamento.Esquerdo);

                    tmpDouble = double.Parse(item.prod.qCom, NumberStyles.Any, CultureInfo.InvariantCulture);
                    texto = tmpDouble.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"));
                    while (texto.Contains(",") && (texto.EndsWith("0") || texto.EndsWith(",")))
                    {
                        texto = texto.Substring(0, texto.Length - 1);
                    }
                    impressora.ImprimeLinhaTexto(texto, colunaQtd, colunaUn - colunaQtd, false, TipoAlinhamento.Direita);

                    impressora.ImprimeLinhaTexto(item.prod.uCom, colunaUn, colunaVlUnitario - colunaUn, false, TipoAlinhamento.Esquerdo);

                    tmpDouble = double.Parse(item.prod.vUnCom, NumberStyles.Any, CultureInfo.InvariantCulture);
                    texto = tmpDouble.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"));
                    //while (texto.Contains(",") && (texto.EndsWith("0") || texto.EndsWith(",")))
                    //{
                    //    texto = texto.Substring(0, texto.Length - 1);
                    //}

                    impressora.ImprimeLinhaTexto(texto, colunaVlUnitario, colunaVlTotal - colunaVlUnitario, false, TipoAlinhamento.Direita);

                    tmpDouble = double.Parse(item.prod.vProd, NumberStyles.Any, CultureInfo.InvariantCulture);
                    texto = tmpDouble.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"));
                    //while (texto.Contains(",") && (texto.EndsWith("0") || texto.EndsWith(",")))
                    //{
                    //    texto = texto.Substring(0, texto.Length - 1);
                    //}
                    impressora.ImprimeLinhaTexto(texto, larguraPapelMM - margem - colunaVlTotal, colunaVlTotal, true, TipoAlinhamento.Direita);
                }

                impressora.DefinirFonte(7);
                impressora.DeslocarY(1);
                impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                impressora.DeslocarY(1);

                #endregion

                #region Divisão IV

                impressora.ImprimeLinhaTexto("Qtd. Total de Itens", margem, null, false, TipoAlinhamento.Esquerdo);
                impressora.ImprimeLinhaTexto(nota.infNFe.det.Count().ToString("D"), margem, larguraPapelMM - (2 * margem), true, TipoAlinhamento.Direita);


                impressora.ImprimeLinhaTexto("Valor Total R$", margem, null, false, TipoAlinhamento.Esquerdo);
                tmpDouble = double.Parse(nota.infNFe.total.ICMSTot.vNF, NumberStyles.Any, CultureInfo.InvariantCulture);
                impressora.ImprimeLinhaTexto(tmpDouble.ToString("F2", CultureInfo.GetCultureInfo("pt-BR")), margem, larguraPapelMM - (2 * margem), true, TipoAlinhamento.Direita);

                //impressora.ImprimeLinhaTexto("Valor Descontos R$", margem, null, false, TipoAlinhamento.Esquerdo);
                //tmpDouble = double.Parse(nota.infNFe.total.ICMSTot.vDesc, NumberStyles.Any, CultureInfo.InvariantCulture);
                //impressora.ImprimeLinhaTexto(tmpDouble.ToString("F2", CultureInfo.GetCultureInfo("pt-BR")), margem, larguraPapelMM - (2*margem), true, TipoAlinhamento.Direita);

                impressora.ImprimeLinhaTexto("FORMA DE PAGAMENTO", margem, null, false, TipoAlinhamento.Esquerdo);
                impressora.ImprimeLinhaTexto("VALOR PAGO", margem, larguraPapelMM - (2 * margem), true, TipoAlinhamento.Direita);

                if (nota.infNFe.pag != null)
                {

                    foreach (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPag pagamento in nota.infNFe.pag.detPag)
                    {
                        switch (pagamento.tPagLegado)
                        {

                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.Dinheiro:
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.Cheque:
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.Outros:
                                texto = pagamento.tPag.ToString();
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.CartaoCredito:
                                texto = "Cartão de Crédito";
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.CartaoDebito:
                                texto = "Cartão de Débito";
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.CreditoLoja:
                                texto = "Crédito Loja";
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.ValeAlimentacao:
                                texto = "Vale Alimentação";
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.ValeRefeicao:
                                texto = "Vale Refeição";
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.ValePresente:
                                texto = "Vale Presente";
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.ValeCombustivel:
                                texto = "Vale Combustível";
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.BoletoBancario:
                                texto = "Boleto Bancário";
                                break;
                            case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFePagDetPagTPagLegado.SemPagamento:
                                texto = "Sem Pagamento";
                                break;
                            case TNFeInfNFePagDetPagTPagLegado.DuplicataMercantil:
                                texto = "Duplicata Mercantil";
                                break;
                            case TNFeInfNFePagDetPagTPagLegado.DepositoBancario:
                                texto = "Depósito Bancario";
                                break;
                            case TNFeInfNFePagDetPagTPagLegado.Pix:
                                texto = "Pix";
                                break;
                            case TNFeInfNFePagDetPagTPagLegado.TransfereciaBancaria:
                                texto = "Transferecia Bancária";
                                break;
                            case TNFeInfNFePagDetPagTPagLegado.ProgramaFidelidade:
                                texto = "Programa de Fidelidade";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        impressora.ImprimeLinhaTexto(texto, margem, null, false, TipoAlinhamento.Esquerdo);
                        tmpDouble = double.Parse(pagamento.vPag, NumberStyles.Any, CultureInfo.InvariantCulture);
                        impressora.ImprimeLinhaTexto(tmpDouble.ToString("F2", CultureInfo.GetCultureInfo("pt-BR")), margem, larguraPapelMM - (2 * margem), true, TipoAlinhamento.Direita);

                    }
                }

                impressora.DeslocarY(1);
                impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                impressora.DeslocarY(1);

                #endregion

                #region Divisão V

                if (!string.IsNullOrWhiteSpace(nota.infNFe.total.ICMSTot.vTotTrib))
                {
                    impressora.DefinirFonte(5);
                    impressora.ImprimeLinhaTexto("Informação dos Tributos Totais Incidentes (Lei Federal 12.741/2012)", margem, null, false, TipoAlinhamento.Esquerdo);


                    tmpDouble = double.Parse(nota.infNFe.total.ICMSTot.vTotTrib, NumberStyles.Any, CultureInfo.InvariantCulture);
                    impressora.ImprimeLinhaTexto(tmpDouble.ToString("F2", CultureInfo.GetCultureInfo("pt-BR")), margem, larguraPapelMM - (2 * margem), true, TipoAlinhamento.Direita);

                    impressora.DefinirFonte(7);

                    impressora.DeslocarY(1);
                    impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                    impressora.DeslocarY(1);
                }

                #endregion

                #region Divisão Va

                if (!string.IsNullOrWhiteSpace(nota.infNFe.infAdic.infCpl))
                {

                    impressora.ImprimeLinhaTexto("INFORMAÇÕES ADICIONAIS DE INTERESSE", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                    impressora.ImprimeLinhaTexto("DO CONTRIBUINTE", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);

                    impressora.DeslocarY(1);

                    impressora.DefinirFonte(5);
                    string tmpString = nota.infNFe.infAdic.infCpl;
                    impressora.ImprimeLinhaTexto(tmpString, margem, 60, true, TipoAlinhamento.Esquerdo);

                    //while (tmpString.Length > 0)
                    //{
                    //    if (tmpString.Length > 57)
                    //    {
                    //        texto = tmpString.Substring(0, 57);
                    //        tmpString = tmpString.Substring(57);
                    //    }
                    //    else
                    //    {
                    //        texto = tmpString;
                    //        tmpString = "";
                    //    }
                    //    impressora.ImprimeLinhaTexto(texto, margem, null,true, TipoAlinhamento.Esquerdo);
                    //}
                    impressora.DefinirFonte(7);

                    impressora.DeslocarY(1);
                    impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                    impressora.DeslocarY(1);

                }

                #endregion

                #region Divisão VI

                if (nota.infNFe.ide.tpAmbLegado == IWTNFCompleto.BibliotecaDatasets.v4_0.TAmbLegado.Homologacao)
                {
                    impressora.ImprimeLinhaTexto("EMITIDA EM AMBIENTE DE HOMOLOGAÇÃO", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                    impressora.ImprimeLinhaTexto("SEM VALOR FISCAL", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                    impressora.DeslocarY(2);
                }


                if (!string.IsNullOrWhiteSpace(nota.infNFe.infAdic.infAdFisco))
                {
                    impressora.DeslocarY(1);

                    impressora.ImprimeLinhaTexto("INFORMAÇÕES ADICIONAIS DE INTERESSE", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                    impressora.ImprimeLinhaTexto("DO FISCO", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                    impressora.DeslocarY(1);

                    impressora.DefinirFonte(5);


                    string tmpString = nota.infNFe.infAdic.infAdFisco;
                    impressora.ImprimeLinhaTexto(tmpString, margem, 60, true, TipoAlinhamento.Esquerdo);
                    impressora.DefinirFonte(7);

                }
                impressora.DeslocarY(2);


                DateTime dataEmissao = DateTime.Parse(nota.infNFe.ide.dhEmi, CultureInfo.InvariantCulture, DateTimeStyles.None);
                texto = "Número: " + nota.infNFe.ide.nNF + " Série: " + nota.infNFe.ide.serie + " Emissão: " + dataEmissao.ToString("dd/MM/yyyy HH:mm:ss");
                impressora.ImprimeLinhaTexto(texto, margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);

                texto = viaEstabelecimento ? "Via Estabelecimento" : "Via Consumidor";
                impressora.ImprimeLinhaTexto(texto, margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);

                impressora.DeslocarY(1);

                texto = "Consulte pela Chave de Acesso em";
                impressora.ImprimeLinhaTexto(texto, margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);

                impressora.ImprimeLinhaTexto(NFCeOperacoes.GetEnderecoConsulta( nota.infNFe.ide.cUFLegado, nota.infNFe.ide.tpAmbLegado), margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                impressora.DeslocarY(1);

                impressora.ImprimeLinhaTexto("CHAVE DE ACESSO", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);

                string chaveAcesso = nota.infNFe.Id.Substring(3);
                texto = "";
                for (int i = 1; i <= chaveAcesso.Count(); i++)
                {
                    texto += chaveAcesso[i - 1];
                    if ((i % 4) == 0)
                    {
                        texto += " ";
                    }
                }

                impressora.DefinirFonte(6);
                impressora.ImprimeLinhaTexto(texto, margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                impressora.DefinirFonte(7);

                impressora.DeslocarY(1);
                impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                impressora.DeslocarY(1);
                #endregion

                #region Divisão VII

                impressora.ImprimeLinhaTexto("CONSUMIDOR", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                impressora.DeslocarY(1);
                if (nota.infNFe.dest == null)
                {
                    impressora.ImprimeLinhaTexto("CONSUMIDOR NÃO IDENTIFICADO", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                }
                else
                {

                    string doc = nota.infNFe.dest.Item;
                    switch (nota.infNFe.dest.ItemElementName)
                    {
                        case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDest.ItemChoiceType3.CNPJ:
                            texto = "CNPJ: ";
                            doc = doc.Substring(0, 2) + "." + doc.Substring(2, 3) + "." + doc.Substring(5, 3) + "/" + doc.Substring(8, 4) + "-" + doc.Substring(12, 2);
                            break;
                        case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDest.ItemChoiceType3.CPF:
                            texto = "CPF: ";
                            doc = doc.Substring(0, 3) + "." + doc.Substring(3, 3) + "." + doc.Substring(6, 3) + "-" + doc.Substring(9, 2);
                            break;
                        case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDest.ItemChoiceType3.idEstrangeiro:
                            texto = "Id. Estrangeiro: ";
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    texto += doc;
                    impressora.ImprimeLinhaTexto(texto, margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);

                    if (!string.IsNullOrWhiteSpace(nota.infNFe.dest.xNome))
                    {
                        impressora.ImprimeLinhaTexto(nota.infNFe.dest.xNome, margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                    }

                    if (nota.infNFe.dest.enderDest != null)
                    {
                        texto = nota.infNFe.dest.enderDest.xLgr + ", " + nota.infNFe.dest.enderDest.nro + ", " + (string.IsNullOrWhiteSpace(nota.infNFe.dest.enderDest.xCpl) ? "" : nota.infNFe.dest.enderDest.xCpl + ", ") + nota.infNFe.dest.enderDest.xBairro + " - " + nota.infNFe.dest.enderDest.xMun + " - " + nota.infNFe.dest.enderDest.UF;
                        impressora.ImprimeLinhaTexto(texto, margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                    }


                }

                impressora.DeslocarY(1);
                impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);

                #endregion

                if (nota.infNFe.ide.TpEmisLegado == IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeIdeTpEmisLegado.ContingenciaOffLineNFCe)
                {
                    ImprimirAvisoContingencia(impressora, margem, larguraPapelMM);
                    impressora.ImprimeLinha(margem, larguraPapelMM - (2 * margem), 0.2f);
                }

                #region Divisão VIII

                impressora.DeslocarY(1);

                impressora.ImprimeLinhaTexto("Consulta via leitor de QR Code", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                string conteudoQr = nota.infNFeSupl.qrCode;
                impressora.ImprimeCodigoBarrasQrCode(conteudoQr, "UTF-8", "M", margem, larguraPapelMM - (2f * margem), 40, 40, true, TipoAlinhamento.Centralizado);
                if (nota.infNFe.ide.TpEmisLegado != IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeIdeTpEmisLegado.ContingenciaOffLineNFCe)
                {
                    if (nfeProc == null)
                    {
                        throw new ExcecaoTratada("Nota sem Autorização e não emitida em contingência");
                    }

                    impressora.DefinirFonte(6);
                    DateTime dataAutorizacao = DateTime.Parse(nfeProc.protNFe.infProt.dhRecbto, CultureInfo.InvariantCulture, DateTimeStyles.None);
                    texto = "Protocolo de Autorização: " + nfeProc.protNFe.infProt.nProt + " " + dataAutorizacao.ToString("dd/MM/yyyy HH:mm:ss");
                    impressora.ImprimeLinhaTexto(texto, margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);
                    impressora.DefinirFonte(7);

                }

                impressora.DeslocarY(1);


                #endregion

                impressora.DeslocarY(margem);
                impressora.ImprimirBorda(margem, 0.3f);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao imprimir a Danfe da NFCe .\r\n" + e.Message, e);
            }
            finally
            {
                if (impressora != null)
                {
                    impressora.EncerrarImpressao();
                    if (logoCarregado)
                    {
                        impressora.DescarregarImagemMemoria(indiceLogoMemoriaImpressora);
                    }
                }
            }
        }


        private static void ImprimirAvisoContingencia(ImpressoraTermica impressora, int margem, int larguraPapelMM)
        {
            float fonteAtual = impressora.FonteAtual();
            float alturaLinhaAtual = impressora.AlturaLinhaAtual();
            try
            {

                impressora.ImprimirQuadrado(margem, impressora.GetY(), larguraPapelMM - (2f * margem), 4 + 4 + 1, Color.LightGray);

                impressora.DeslocarY(1);

                impressora.DefinirFonte(9);
                impressora.DefinirAlturaLinha(4);
                impressora.ImprimeLinhaTexto("EMITIDA EM CONTINGÊNCIA", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);

                impressora.DefinirFonte(7);
                impressora.DefinirAlturaLinha(4);
                impressora.ImprimeLinhaTexto("Pendente de autorização", margem, larguraPapelMM - (2f * margem), true, TipoAlinhamento.Centralizado);

                
            }
            finally
            {
                impressora.DefinirFonte(fonteAtual);
                impressora.DefinirAlturaLinha(alturaLinhaAtual);
                
            }
        }


        

    }
}
