using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public class ConfiguradorEASIFactory:IConfiguradorEASIFactory
    {
        

        public IConfiguradorEASI getInstance(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario, string tipoCalculoSemana, string diaCalculoSemana)
        {
            return new ConfiguradorEASI(conn, usuario,  tipoCalculoSemana, diaCalculoSemana);
        }
    }
}
