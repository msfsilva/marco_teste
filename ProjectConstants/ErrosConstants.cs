using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConstants
{
    public static class ErrosConstants
    {
        public static string VERIFICA_INSTANCIAS_AUTOMACAO_PARSE = "ERRO-01: Verificação de estação ativa inválida, acione o suporte IWT";
        public static string VERIFICA_INSTANCIAS_AUTOMACAO_OUTRA_SESSAO = "ERRO-02: O Módulo de automação já está sendo executado em outro computador. Encerre-o para poder abrir nesse computador.";

        public static string VERIFICA_AUTORIZACAO_AUTOMACAO = "ERRO-03: O computador atual não está autorizado a rodar o módulo de automação do EASI.";

        public static string VERIFICA_MULTIPLAS_INSTANCIAS_AUTOMACAO = "ERRO-04: Não é possível abrir mais de uma cópia do módulo de Automação do EASI";

    }
}
