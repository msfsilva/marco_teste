using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BibliotecaEntidades.Operacoes.AtualizacaoPreco
{
    public class AtualizacaoPrecoMassaClass
    {


        public static void ProcessarTabela(string arquivo, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            IWorkbook book;

            FileStream fs = new FileStream(arquivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // Try to read workbook as XLSX:
            try
            {
                book = new XSSFWorkbook(fs);
            }
            catch
            {
                book = null;
            }

            // If reading fails, try to read workbook as XLS:
            if (book == null)
            {
                book = new HSSFWorkbook(fs);
            }


            ISheet sheet = book.GetSheetAt(0);


            int linhasVazias = 0;
            int nLinha = 0;

            int colunaIdProduto = -1;
            int colunaPreco = -1;
            int colunaRegra = -1;
            int colunaInicioVigencia = -1;
            int colunaJustificativa = -1;

            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.Transaction = command.Connection.BeginTransaction();

            try
            {
                while (linhasVazias < 50 && nLinha < sheet.LastRowNum)
                {
                    try
                    {
                        IRow row = sheet.GetRow(nLinha);
                        if (nLinha == 0)
                        {
                            //Linha de Titulos
                            for (int coluna = row.FirstCellNum; coluna < row.LastCellNum; coluna++)
                            {
                                switch (row.GetCell(coluna).StringCellValue?.ToLowerInvariant())
                                {
                                    case "id_produto":
                                        colunaIdProduto = coluna;
                                        break;
                                    case "prp_preco":
                                        colunaPreco = coluna;
                                        break;
                                    case "prp_regra":
                                        colunaRegra = coluna;
                                        break;
                                    case "prp_inicio_vigencia":
                                        colunaInicioVigencia = coluna;
                                        break;
                                    case "prp_justificativa":
                                        colunaJustificativa = coluna;
                                        break;
                                }
                            }

                            if (colunaIdProduto == -1)
                            {
                                throw new ExcecaoTratada("Não foi possível identificar a coluna de ID do produto");
                            }

                            if (colunaPreco == -1)
                            {
                                throw new ExcecaoTratada("Não foi possível identificar a coluna de Preço");
                            }

                            if (colunaRegra == -1)
                            {
                                throw new ExcecaoTratada("Não foi possível identificar a coluna de Regra");
                            }

                            if (colunaInicioVigencia == -1)
                            {
                                throw new ExcecaoTratada("Não foi possível identificar a coluna de Inicio de Vigência");
                            }

                            if (colunaJustificativa == -1)
                            {
                                throw new ExcecaoTratada("Não foi possível identificar a coluna de Justificativa");
                            }

                            continue;
                        }

                        XSSFCell cell = (XSSFCell) row.GetCell(colunaIdProduto);
                        if (cell == null || cell.GetRawValue() == null)
                        {
                            linhasVazias++;
                            continue;
                        }

                        if (row.GetCell(colunaIdProduto).CellType == CellType.Numeric && string.IsNullOrWhiteSpace(row.GetCell(colunaIdProduto).NumericCellValue.ToString()))
                        {
                            linhasVazias++;
                            continue;
                        }

                        if (row.GetCell(colunaIdProduto).CellType == CellType.String && string.IsNullOrWhiteSpace(row.GetCell(colunaIdProduto).StringCellValue))
                        {
                            linhasVazias++;
                            continue;
                        }

                        long idProduto = Convert.ToInt64(row.GetCell(colunaIdProduto).NumericCellValue);
                        if (idProduto < 1)
                        {
                            linhasVazias++;
                            continue;
                        }

                        ProdutoClass produto = ProdutoClass.GetEntidade(idProduto, usuario, conn);
                        if (produto == null)
                        {
                            throw new ExcecaoTratada("Não foi encontrado produto com o ID " + idProduto);
                        }

                        double preco = Math.Round(row.GetCell(colunaPreco).NumericCellValue, 5);
                        string regra = row.GetCell(colunaRegra)?.StringCellValue;

                        if (!string.IsNullOrWhiteSpace(regra) && regra.Trim().ToLowerInvariant() != "null")
                        {
                            preco = 0;
                            regra = regra.Trim();
                        }
                        else
                        {
                            regra = null;
                        }


                        DateTime inicioVigencia = row.GetCell(colunaInicioVigencia).DateCellValue;

                        if (inicioVigencia.Year < 2020)
                        {
                            throw new ExcecaoTratada("Data Inválida na vigência na linha " + (nLinha + 1));
                        }

                        DateTime fimVigenciaAnterior = inicioVigencia.AddDays(-1);

                        string justificativa = row.GetCell(colunaJustificativa).StringCellValue;

                        ProdutoPrecoClass precoAtual = produto.CollectionProdutoPrecoClassProduto.FirstOrDefault(a => !a.FimVigencia.HasValue);

                        if (precoAtual != null)
                        {
                            precoAtual.FimVigencia = fimVigenciaAnterior;
                        }

                        //Novo Preço

                        ProdutoPrecoClass novoPreco = new ProdutoPrecoClass(usuario, conn)
                        {
                            Produto = produto,
                            InicioVigencia = inicioVigencia,
                            Justificativa = justificativa,
                            AcsUsuario = usuario,
                            FimVigencia = null,
                            Preco = preco,
                            Regra = regra
                        };

                        produto.CollectionProdutoPrecoClassProduto.Add(novoPreco);
                        produto.DesabilitarJustificativaRevisaoProduto = true;
                        produto.Save(ref command);
                        produto.DesabilitarJustificativaRevisaoProduto = false;
                    }
                    catch (ExcecaoTratada)
                    {
                        throw;
                    }
                    catch (Exception e)
                    {
                        throw new ExcecaoTratada("Erro inesperado na linha " + (nLinha + 1) + ": " + e.Message);
                    }
                    finally
                    {
                        nLinha++;
                    }
                }

                command.Transaction.Commit();
            }
            catch
            {
                command?.Transaction?.Rollback();
                throw;
            }

        }


        public static void ExportarDados(string nomeArquivo, IWTPostgreNpgsqlConnection conn)
        {

            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.CommandText =

                "SELECT " +
                "        public.produto.id_produto, " +
                "        public.produto.pro_codigo, " +
                "        public.produto.pro_codigo_cliente, " +
                "        public.produto.pro_descricao, " +
                "        CASE public.produto.pro_calculo_preco " +
                "            WHEN 0 THEN 'Preço Fixo' " +
                "        WHEN 1 THEN 'Preço Variável - Regra' " +
                "        WHEN 2 THEN 'Preço Variável - Soma TODOS Filhos' " +
                "        WHEN 3 THEN 'Preço Variável - Soma Filhos SELECIONADOS' " +
                "        ELSE 'Não Aplicavel' " +
                "        END as politica_preco, " +
                "        public.produto_preco.prp_preco, " +
                "        public.produto_preco.prp_regra, " +
                "        public.produto_preco.prp_inicio_vigencia, " +
                "        public.produto_preco.prp_justificativa, " +
                "        public.cliente.cli_nome, " +
                "        public.aplicacao_cliente.apc_identificacao, " +
                "        public.produto_ultima_venda.ultima_data_entrada " +
                "            FROM " +
                "        public.produto " +
                "            INNER JOIN public.produto_preco ON(public.produto.id_produto = public.produto_preco.id_produto) " +
                "        LEFT OUTER JOIN public.cliente ON(public.produto.id_cliente = public.cliente.id_cliente) " +
                "        LEFT OUTER JOIN public.aplicacao_cliente ON(public.produto.id_aplicacao_cliente = public.aplicacao_cliente.id_aplicacao_cliente) " +
                "        LEFT OUTER JOIN public.produto_ultima_venda ON(public.produto.id_produto = public.produto_ultima_venda.id_produto) " +
                "        WHERE produto_preco.prp_fim_vigencia IS NULL";

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

            IWorkbook book;
            

            FileStream fs = new FileStream(nomeArquivo, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            book = new XSSFWorkbook();

            var newDataFormat = book.CreateDataFormat();
            var styleData = book.CreateCellStyle();
            styleData.DataFormat = newDataFormat.GetFormat("dd/MM/yyyy");

            var styleDataHora = book.CreateCellStyle();
            styleDataHora.DataFormat = newDataFormat.GetFormat("dd/MM/yyyy HH:mm:ss");


            ISheet sheet = book.CreateSheet();
            IRow row = sheet.CreateRow(0);
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("id_produto");
            cell = row.CreateCell(1);
            cell.SetCellValue("pro_codigo");
            cell = row.CreateCell(2);
            cell.SetCellValue("pro_codigo_cliente");
            cell = row.CreateCell(3);
            cell.SetCellValue("pro_descricao");
            cell = row.CreateCell(4);
            cell.SetCellValue("politica_preco");
            cell = row.CreateCell(5);
            cell.SetCellValue("prp_preco");
            cell = row.CreateCell(6);
            cell.SetCellValue("prp_regra");
            cell = row.CreateCell(7);
            cell.SetCellValue("prp_inicio_vigencia");
            cell = row.CreateCell(8);
            cell.SetCellValue("prp_justificativa");
            cell = row.CreateCell(9);
            cell.SetCellValue("cli_nome");
            cell = row.CreateCell(10);
            cell.SetCellValue("apc_identificacao");
            cell = row.CreateCell(11);
            cell.SetCellValue("ultima_data_entrada");


            int indiceLinha = 1;
            while (read.Read())
            {
                row = sheet.CreateRow(indiceLinha);
                cell = row.CreateCell(0);
                cell.SetCellValue(Convert.ToInt64(read["id_produto"]));

                cell = row.CreateCell(1);
                cell.SetCellValue(read["pro_codigo"].ToString());

                cell = row.CreateCell(2);
                cell.SetCellValue(read["pro_codigo_cliente"].ToString());

                cell = row.CreateCell(3);
                cell.SetCellValue(read["pro_descricao"].ToString());

                cell = row.CreateCell(4);
                cell.SetCellValue(read["politica_preco"].ToString());

                cell = row.CreateCell(5);
                cell.SetCellValue(Convert.ToDouble(read["prp_preco"]));

                cell = row.CreateCell(6);
                cell.SetCellValue(read["prp_regra"].ToString());

                cell = row.CreateCell(7);
                cell.SetCellValue(Convert.ToDateTime(read["prp_inicio_vigencia"]));
                cell.CellStyle = styleData;

                cell = row.CreateCell(8);
                cell.SetCellValue(read["prp_justificativa"].ToString());

                cell = row.CreateCell(9);
                cell.SetCellValue(read["cli_nome"].ToString());

                cell = row.CreateCell(10);
                cell.SetCellValue(read["apc_identificacao"].ToString());

                cell = row.CreateCell(11);
                if (read["ultima_data_entrada"] != DBNull.Value)
                {
                    cell.SetCellValue(Convert.ToDateTime(read["ultima_data_entrada"]));
                }
                cell.CellStyle = styleDataHora;

                indiceLinha++;
            }

            for (int i = 0; i < 12; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            read.Close();

            book.Write(fs);
        }
    }
}
