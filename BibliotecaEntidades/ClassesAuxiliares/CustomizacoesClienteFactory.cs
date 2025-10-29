using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public class CustomizacoesClienteFactory
    {
        private static CustomizacoesClienteFactory _factory;

        public static CustomizacoesClienteFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new CustomizacoesClienteFactory();
                }

                return _factory;
            }
            set { _factory = value; }
        }


        public virtual bool ValidaAlteracaoVariavelClass(VariavelClass variavel, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlCommand command, out string motivo)
        {
            motivo = "?";
            return false;
        }

        public virtual string EtiquetaCustomizadaCarregaUnidadeMedida(long idOrderItemEtiqueta, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            return "MM";
        }

        public virtual bool EtiquetaCustomizadaExibeQtdEtiqueta(long idOrderItemEtiqueta, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            return false;
        }


    }
}
