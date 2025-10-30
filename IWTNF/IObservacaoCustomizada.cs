using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNF.Entidades.Entidades;

namespace IWTNF
{
    public interface IObservacaoCustomizada
    {
        string GetObservacaoCreditoSimples(NfPrincipalClass nf);
    }
}
