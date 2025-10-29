using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaExpedicao
{
    public class ConferenciaClass:ConferenciaDefaultClass
    {
        public ConferenciaClass(string barCode, IOrdemProducaoFactory iOrdemProducaoFactory, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, ConferenciaPedidosForm formBase) :
            base(barCode, iOrdemProducaoFactory, Usuario, conn,formBase)
        {
        }
    }
}
