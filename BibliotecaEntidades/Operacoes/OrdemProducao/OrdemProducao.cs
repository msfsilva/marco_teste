using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducao:OrdemProducaoClass
    {
        public OrdemProducao(long idProduto, int versaoEstruturaProduto, string produtoCodigo, string produtoDescricao, string tipoDocumento, string numeroDocumento, string revisaoDocumento, string Dimensao, bool rastrearMP, bool imprimeOpsRelacionadas, int? idProdutoK, OrdemProducaoGrupoClass Grupo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory) : base(idProduto, versaoEstruturaProduto, produtoCodigo, produtoDescricao, tipoDocumento, numeroDocumento, revisaoDocumento, Dimensao, rastrearMP, imprimeOpsRelacionadas, idProdutoK, Grupo, Usuario, conn, iOrdemProducaoFactory)
        {
        }

        public OrdemProducao(long idOrdemProducao, OrdemProducaoGrupoClass Grupo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory) : base(idOrdemProducao, Grupo, Usuario, conn, iOrdemProducaoFactory)
        {
        }
    }
}
