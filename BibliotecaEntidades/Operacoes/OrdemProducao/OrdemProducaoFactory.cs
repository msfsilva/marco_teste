using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoFactory:IOrdemProducaoFactory
    {
        
        public OrdemProducaoClass getInstanceOp(long idProduto, int versaoEstruturaProduto, string produtoCodigo, string produtoDescricao, string tipoDocumento, string numeroDocumento, string revisaoDocumento, string Dimensao, bool rastrearMP, bool imprimeOpsRelacionadas,int? idProdutoK, OrdemProducaoGrupoClass Grupo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            return new OrdemProducao(idProduto, versaoEstruturaProduto, produtoCodigo, produtoDescricao, tipoDocumento, numeroDocumento, revisaoDocumento, Dimensao, rastrearMP, imprimeOpsRelacionadas, idProdutoK, Grupo, Usuario, conn, this);
        }

        public OrdemProducaoClass getInstanceOp(long idOrdemProducao, OrdemProducaoGrupo Grupo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            return new OrdemProducao(idOrdemProducao, Grupo, Usuario, conn, this);
        }
        
        public OrdemProducaoGrupoClass getInstanceOPGrupo(long idOrdemProducaoGrupo, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario, OrdemProducaoClass OPAtual, bool loadAllOps)
        {
            return new OrdemProducaoGrupo(idOrdemProducaoGrupo, conn, Usuario, OPAtual, loadAllOps,this);
        }

        public OrdemProducaoGrupoClass getInstanceOPGrupo(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            return new OrdemProducaoGrupo(conn, Usuario, this);
        }
         
        
    }
}
