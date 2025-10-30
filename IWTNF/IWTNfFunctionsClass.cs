#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;

#endregion

namespace IWTNF
{
  
    internal enum TipoFill{Esquerda,Direita};
    internal static class IWTNfFunctionsClass
    {
        internal const string LINE_BREAK_CHAR = "\r\n";
        internal static string validateMaxLength(string input, int maxLength, bool cut, string nomeCampo)
        {
            if (input.Length > maxLength)
            {
                if (cut)
                {
                    return input.Substring(0, maxLength);
                    
                }
                else
                {
                    throw new Exception("Comprimento máximo do campo " + nomeCampo + " é de " + maxLength + " caracteres.");
                    
                }
            }
            else
            {
                return input;
            }

        }

        internal static double validateInterval(double input, double minValue, double maxValue, string nomeCampo)
        {
            if (input >= minValue && input <= maxValue)
            {
                return input;
            }
            else
            {
                throw new Exception("Valor do Campo " + nomeCampo + " não faz parte do intervalo válido(" + minValue.ToString(CultureInfo.CurrentCulture) + " - " + maxValue.ToString(CultureInfo.CurrentCulture) + ").");
            }
        }

        internal static int validateOptions(int input, List<int> options, string nomeCampo)
        {
            if (options.Contains(input))
            {
                return input;
            }
            else
            {
                throw new Exception("Valor do Campo " + nomeCampo + " não é um valor válido.");
            }
        }

        internal static string fillValue(string input, int length, char toUseChar, TipoFill fill)
        {
            while (input.Length < length)
            {
                if (fill == TipoFill.Esquerda)
                {
                    input = toUseChar + input;
                }
                else
                {
                    input = input + toUseChar;
                }
            }
            return input;
        }

        internal static string validateOptions(string input, List<string> options, string nomeCampo)
        {
            if (options.Contains(input))
            {
                return input;
            }
            else
            {
                throw new Exception("Valor do Campo " + nomeCampo + " não é um valor válido.");
            }
        }
    }


}
