using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoGrupo:OrdemProducaoGrupoClass
    {
        public OrdemProducaoGrupo(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario, IOrdemProducaoFactory iOrdemProducaoFactory) : base(conn, Usuario, iOrdemProducaoFactory)
        {
        }

        public OrdemProducaoGrupo(long idOrdemProducaoGrupo, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario, OrdemProducaoClass OPAtual, bool loadAllOps, IOrdemProducaoFactory iOrdemProducaoFactory)
            : base(idOrdemProducaoGrupo, conn, Usuario, OPAtual, loadAllOps, iOrdemProducaoFactory)
        {
        }
    }
}
