using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;

namespace BibliotecaEntidades.Operacoes.NFe
{
    public class DadosFiscaisItemDto
    {
        public NcmClass NCM { get; private set; }
        
        public string GTIN { get; private set; }
        public string exTIPI { get; private set; }
        public string Genero { get; private set; }
        public Origem Origem { get; private set; }
        

        public static DadosFiscaisItemDto GetDadosFiscaisProduto(ProdutoClass produto)
        {
            if (produto.CollectionProdutoFiscalClassProduto.Count == 0)
            {
                throw new ExcecaoTratada("O cadastro fiscal do produto " + produto + " não foi encontrado");
            }

            if (produto.CollectionProdutoFiscalClassProduto.Count >1)
            {
                throw new ExcecaoTratada("O cadastro fiscal do produto " + produto + " está inconsistente, informe o Suporte IWT");
            }

            ProdutoFiscalClass produtoFiscal = produto.CollectionProdutoFiscalClassProduto.First();




            DadosFiscaisItemDto toRet = new DadosFiscaisItemDto()
            {
                NCM = produtoFiscal.Ncm,
                GTIN = produto.Gtin,
                exTIPI = produtoFiscal.Extipi,
                Genero = produtoFiscal.Genero?.ToString(),
                Origem = produtoFiscal.Origem,
            };
            return toRet;
        }

        public static DadosFiscaisItemDto GetDadosFiscaisMaterial(MaterialClass material)
        {
            if (material.CollectionMaterialFiscalClassMaterial.Count == 0)
            {
                throw new ExcecaoTratada("O cadastro fiscal do material " + material + " não foi encontrado");
            }

            if (material.CollectionMaterialFiscalClassMaterial.Count > 1)
            {
                throw new ExcecaoTratada("O cadastro fiscal do material " + material + " está inconsistente, informe o Suporte IWT");
            }

            MaterialFiscalClass materialFiscal = material.CollectionMaterialFiscalClassMaterial.First();


            DadosFiscaisItemDto toRet = new DadosFiscaisItemDto()
            {
                NCM = materialFiscal.Ncm,
                GTIN = material.Gtin,
                exTIPI = materialFiscal.Extipi,
                Genero = materialFiscal.Genero?.ToString(),
                Origem = materialFiscal.Origem,
            };
            return toRet;
        }

        

    }
}