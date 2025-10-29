using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public interface IConfiguradorEASIFactory
    {
        IConfiguradorEASI getInstance(IWTPostgreNpgsqlConnection conn,AcsUsuarioClass usuario, string tipoCalculoSemana, string diaCalculoSemana);
    }
}
