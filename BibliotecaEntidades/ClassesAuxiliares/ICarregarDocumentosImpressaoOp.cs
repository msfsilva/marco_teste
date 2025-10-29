using System.Collections.Generic;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public interface ICarregarDocumentosImpressaoOp
    {
        List<byte[]> CarregarDocumentosImpressaoDireta(long idOp, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn);
    }
}
