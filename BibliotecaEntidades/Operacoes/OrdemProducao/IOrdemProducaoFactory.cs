using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public interface IOrdemProducaoFactory
    {
        OrdemProducaoClass getInstanceOp(long idProduto, int versaoEstruturaProduto, string produtoCodigo,
                                  string produtoDescricao, string tipoDocumento, string numeroDocumento,
                                  string revisaoDocumento, string Dimensao, bool rastrearMP,
                                  bool imprimeOpsRelacionadas, int? idProdutoK, OrdemProducaoGrupoClass Grupo,
                                  AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn);


        OrdemProducaoClass getInstanceOp(long idOrdemProducao, OrdemProducaoGrupo Grupo, AcsUsuarioClass Usuario,
                                  IWTPostgreNpgsqlConnection conn);


        OrdemProducaoGrupoClass getInstanceOPGrupo(long idOrdemProducaoGrupo, IWTPostgreNpgsqlConnection conn,
                                              AcsUsuarioClass Usuario, OrdemProducaoClass OPAtual, bool loadAllOps);

        OrdemProducaoGrupoClass getInstanceOPGrupo(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario);
    }
}
