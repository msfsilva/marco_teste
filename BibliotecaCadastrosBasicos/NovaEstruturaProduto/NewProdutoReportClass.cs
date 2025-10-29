#region Referencias

using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using BibliotecaCadastrosBasicos.EstruturaProduto;
using BibliotecaEntidades.Entidades;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public enum TipoRelatorioEstrutura
    {
        PrimeiroFilhos,
        PrimeiroComponentesPai
    }

    public static class NewProdutoReportClass
    {
       


        public static EstruturaProdutoReportDataSet fillReport(NewProdutoTreeClass InicioArvore, TipoRelatorioEstrutura tipoRelatorio)
        {
            EstruturaProdutoReportDataSet toRet = new EstruturaProdutoReportDataSet();
            
            string nivel = "1";
            fillReport(InicioArvore, ref toRet, nivel, "", 1, "", tipoRelatorio);
            return toRet;
           
        }

        private static void fillReport(NewProdutoTreeClass InicioArvore, ref EstruturaProdutoReportDataSet ds, string nivel, string nivelPai, double Qtd, string posicaoEstruturaPai, TipoRelatorioEstrutura tipoRelatorio)
        {
            EstruturaProdutoReportDataSet.itemRow row = ds.item.NewitemRow();
            row.nivel = nivel;
            row.codigo = InicioArvore.Produto.Codigo;
            row.nome = InicioArvore.Produto.Descricao;
            if (InicioArvore.Acabamento != null)
            {
                row.prop_1 = InicioArvore.Acabamento.Descricao + " - " + InicioArvore.Acabamento;
            }
            row.prop_2 = InicioArvore.Produto.PossuiVariavel1 ? InicioArvore.Produto.Variavel1.Nome : "";
            row.prop_3 = InicioArvore.Produto.PossuiVariavel2 ? InicioArvore.Produto.Variavel2.Nome : "";
            row.prop_4 = InicioArvore.Produto.PossuiVariavel3 ? InicioArvore.Produto.Variavel3.Nome : "";
            row.prop_5 = InicioArvore.Produto.PossuiVariavel4 ? InicioArvore.Produto.Variavel4.Nome : "";
            row.tipo = "PRODUTO";
            if (!InicioArvore.QtdCondicional)
            {
                row.qtd = Qtd.ToString("G5", CultureInfo.CurrentCulture);
            }
            else
            {
                row.qtd = InicioArvore.QtdCondicionalRegra;
            }
            row.nivel_pai = nivelPai;
            row.revisao = InicioArvore.Produto.VersaoEstruturaCarregada.ToString(CultureInfo.InvariantCulture);
            row.observacao_revisao = InicioArvore.Produto.UltimaRevisaoEstruturaMotivo;
            row.posicao_desenho_pai = posicaoEstruturaPai;
            ds.item.AdditemRow(row);



            string inicioNivel = nivel;
            int ultimaParteNivel = 0;

            if (tipoRelatorio == TipoRelatorioEstrutura.PrimeiroComponentesPai)
            {
                fillDocumentos(InicioArvore, ref ds, inicioNivel, inicioNivel, ref ultimaParteNivel);
                fillMateriais(InicioArvore, ref ds, inicioNivel, inicioNivel, ref ultimaParteNivel);
            }


            if (InicioArvore.Filhos.Any())
            {

                foreach (NewProdutoTreeClass filho in InicioArvore.Filhos.OrderBy(a => a.Produto.Codigo))
                {
                    ultimaParteNivel++;
                    
                    fillReport(filho, ref ds, inicioNivel + "." + ultimaParteNivel.ToString(CultureInfo.InvariantCulture), inicioNivel, filho.getQuantidade(), filho.PosicaoDesenhoPai,tipoRelatorio);
                }
            }

            if (tipoRelatorio == TipoRelatorioEstrutura.PrimeiroFilhos)
            {
                fillDocumentos(InicioArvore, ref ds, inicioNivel, inicioNivel, ref ultimaParteNivel);
                fillMateriais(InicioArvore, ref ds, inicioNivel, inicioNivel, ref ultimaParteNivel);
            }

        }


        private static void fillDocumentos(NewProdutoTreeClass InicioArvore, ref EstruturaProdutoReportDataSet ds, string inicioNivel, string nivelPai, ref int ultimaParteNivel)
        {
            EstruturaProdutoReportDataSet.itemRow row;
            foreach (ProdutoDocumentoTipoClass doc in InicioArvore.Produto.Documentos.OrderBy(a => a.DocumentoTipoFamilia.ToString()))
            {
                ultimaParteNivel++;
                row = ds.item.NewitemRow();
                row.codigo = doc.DocumentoTipoFamilia.DocumentoTipo.Identificacao;
                row.nome = doc.DocumentoTipoFamilia.DocumentoTipo.Descricao;
                row.qtd = "1";
                row.nivel = inicioNivel + "." + ultimaParteNivel.ToString();
                row.prop_1 = doc.DocumentoTipoFamilia.DocumentoTipo.RevisaoAtual;
                row.prop_2 = doc.DocumentoTipoFamilia.FamiliaDocumento.ToString();
                row.tipo = "DOCUMENTO";
                row.nivel_pai = nivelPai;

                ds.item.AdditemRow(row);
            }
        }

        private static void fillMateriais(NewProdutoTreeClass InicioArvore, ref EstruturaProdutoReportDataSet ds, string inicioNivel, string nivelPai, ref int ultimaParteNivel)
        {
            EstruturaProdutoReportDataSet.itemRow row;
            foreach (ProdutoMaterialClass mat in InicioArvore.Produto.Materiais.OrderBy(a => a.Material.ToString()))
            {
                ultimaParteNivel++;
                row = ds.item.NewitemRow();
                row.codigo = mat.Material.ToString();
                row.nome = mat.Material.Descricao;
                if (!mat.QtdCondicional)
                {
                    row.qtd = mat.Quantidade.ToString("G5", CultureInfo.CurrentCulture) + " " + mat.Material.UnidadeMedida;
                }
                else
                {
                    row.qtd = mat.QtdCondicionalRegra;
                }
                
                row.nivel = inicioNivel + "." + ultimaParteNivel.ToString(CultureInfo.InvariantCulture);
                row.prop_1 = mat.Material.Medida.ToString("F2", CultureInfo.CurrentCulture);
                row.prop_2 = mat.Material.MedidaLargura.ToString("F2", CultureInfo.CurrentCulture);
                row.prop_3 = mat.Material.MedidaComprimento.ToString("F2", CultureInfo.CurrentCulture);
                row.prop_4 = mat.Material.Acabamento.DescricaoTecnica + " - " + mat.Material.Acabamento;
                row.prop_5 = mat.Material.PoliticaEstoqueTela;
                row.tipo = "MATERIAL";
                row.nivel_pai = nivelPai;

                ds.item.AdditemRow(row);
            }
        }

    }
}
