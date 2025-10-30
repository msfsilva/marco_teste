using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes
{
    public interface IValidacao
    {
        bool Validar(TNFe nfe, out string error);
    }
}
