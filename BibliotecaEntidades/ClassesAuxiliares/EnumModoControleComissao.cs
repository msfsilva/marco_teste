using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public static class ControleComissao
    {
        private static ModoControleComissao _modo = ModoControleComissao.Pedido;
        private static bool _carregado = false;

        public static ModoControleComissao Modo
        {
            get
            {
                if (!_carregado)
                {
                    try
                    {
                        _modo = (ModoControleComissao) Enum.ToObject(typeof (ModoControleComissao), int.Parse(Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.MODO_CONTROLE_COMISSOES), NumberStyles.Integer));
                        _carregado = true;
                    }
                    catch
                    {
                    }
                }

                return _modo;
            }
        }
    }

    public enum ModoControleComissao
    {
        Pedido,
        Faturamento,
        ContaReceber
    }


}
