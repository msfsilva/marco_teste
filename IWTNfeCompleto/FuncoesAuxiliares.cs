using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace IWTNFCompleto
{
    public static class FuncoesAuxiliares
    {
        /*
        internal static TUfCons TCodUfIBGE2TUfCons(TCodUfIBGE estado)
        {
            switch (estado)
            {
                case TCodUfIBGELegado.Rondonia:
                    return TUfCons.RO;
                    break;
                case TCodUfIBGELegado.Acre:
                    return TUfCons.AC;
                    break;
                case TCodUfIBGELegado.Amazonas:
                    return TUfCons.AM;
                    break;
                case TCodUfIBGELegado.Roraima:
                    return TUfCons.RR;
                    break;
                case TCodUfIBGELegado.Para:
                    return TUfCons.PA;
                    break;
                case TCodUfIBGELegado.Amapa:
                    return TUfCons.AP;
                    break;
                case TCodUfIBGELegado.Tocantins:
                    return TUfCons.TO;
                    break;
                case TCodUfIBGELegado.Maranhao:
                    return TUfCons.MA;
                    break;
                case TCodUfIBGELegado.Piaui:
                    return TUfCons.PI;
                    break;
                case TCodUfIBGELegado.Ceara:
                    return TUfCons.CE;
                    break;
                case TCodUfIBGELegado.RioGrandeDoNorte:
                    return TUfCons.RN;
                    break;
                case TCodUfIBGELegado.Paraiba:
                    return TUfCons.PB;
                    break;
                case TCodUfIBGELegado.Pernambuco:
                    return TUfCons.PE;
                    break;
                case TCodUfIBGELegado.Alagoas:
                    return TUfCons.AL;
                    break;
                case TCodUfIBGELegado.Sergipe:
                    return TUfCons.SE;
                    break;
                case TCodUfIBGELegado.Bahia:
                    return TUfCons.BA;
                    break;
                case TCodUfIBGELegado.MinasGerais:
                    return TUfCons.MG;
                    break;
                case TCodUfIBGELegado.EspiritoSanto:
                    return TUfCons.ES;
                    break;
                case TCodUfIBGELegado.RioDeJaneiro:
                    return TUfCons.RJ;
                    break;
                case TCodUfIBGELegado.SaoPaulo:
                    return TUfCons.SP;
                    break;
                case TCodUfIBGELegado.Parana:
                    return TUfCons.PR;
                    break;
                case TCodUfIBGELegado.SantaCatarina:
                    return TUfCons.SC;
                    break;
                case TCodUfIBGELegado.RioGrandeDoSul:
                    return TUfCons.RS;
                    break;
                case TCodUfIBGELegado.MatoGrossoDoSul:
                    return TUfCons.MS;
                    break;
                case TCodUfIBGELegado.MatoGrosso:
                    return TUfCons.MT;
                    break;
                case TCodUfIBGELegado.Goias:
                    return TUfCons.GO;
                    break;
                case TCodUfIBGELegado.DistritoFederal:
                    return TUfCons.DF;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("estado");
            }
        }
        */

        internal static TUfEmi TCodUfIBGE2TUfEmi(TCodUfIBGELegado estado)
        {
            switch (estado)
            {
                case TCodUfIBGELegado.RO:
                    return TUfEmi.RO;
                    break;
                case TCodUfIBGELegado.AC:
                    return TUfEmi.AC;
                    break;
                case TCodUfIBGELegado.AM:
                    return TUfEmi.AM;
                    break;
                case TCodUfIBGELegado.RR:
                    return TUfEmi.RR;
                    break;
                case TCodUfIBGELegado.PA:
                    return TUfEmi.PA;
                    break;
                case TCodUfIBGELegado.AP:
                    return TUfEmi.AP;
                    break;
                case TCodUfIBGELegado.TO:
                    return TUfEmi.TO;
                    break;
                case TCodUfIBGELegado.MA:
                    return TUfEmi.MA;
                    break;
                case TCodUfIBGELegado.PI:
                    return TUfEmi.PI;
                    break;
                case TCodUfIBGELegado.CE:
                    return TUfEmi.CE;
                    break;
                case TCodUfIBGELegado.RN:
                    return TUfEmi.RN;
                    break;
                case TCodUfIBGELegado.PB:
                    return TUfEmi.PB;
                    break;
                case TCodUfIBGELegado.PE:
                    return TUfEmi.PE;
                    break;
                case TCodUfIBGELegado.AL:
                    return TUfEmi.AL;
                    break;
                case TCodUfIBGELegado.SE:
                    return TUfEmi.SE;
                    break;
                case TCodUfIBGELegado.BA:
                    return TUfEmi.BA;
                    break;
                case TCodUfIBGELegado.MG:
                    return TUfEmi.MG;
                    break;
                case TCodUfIBGELegado.ES:
                    return TUfEmi.ES;
                    break;
                case TCodUfIBGELegado.RJ:
                    return TUfEmi.RJ;
                    break;
                case TCodUfIBGELegado.SP:
                    return TUfEmi.SP;
                    break;
                case TCodUfIBGELegado.PR:
                    return TUfEmi.PR;
                    break;
                case TCodUfIBGELegado.SC:
                    return TUfEmi.SC;
                    break;
                case TCodUfIBGELegado.RS:
                    return TUfEmi.RS;
                    break;
                case TCodUfIBGELegado.MS:
                    return TUfEmi.MS;
                    break;
                case TCodUfIBGELegado.MT:
                    return TUfEmi.MT;
                    break;
                case TCodUfIBGELegado.GO:
                    return TUfEmi.GO;
                    break;
                case TCodUfIBGELegado.DF:
                    return TUfEmi.DF;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("estado");
            }
        }

        public static TUfEmi Sigla2TUfEmi(string Sigla)
        {
            switch (Sigla)
            {
                case "RO":
                    return TUfEmi.RO;
                    break;
                case "AC":
                    return TUfEmi.AC;
                    break;
                case "AM":
                    return TUfEmi.AM;
                    break;
                case "RR":
                    return TUfEmi.RR;
                    break;
                case "PA":
                    return TUfEmi.PA;
                    break;
                case "AP":
                    return TUfEmi.AP;
                    break;
                case "TO":
                    return TUfEmi.TO;
                    break;
                case "MA":
                    return TUfEmi.MA;
                    break;
                case "PI":
                    return TUfEmi.PI;
                    break;
                case "CE":
                    return TUfEmi.CE;
                    break;
                case "RN":
                    return TUfEmi.RN;
                    break;
                case "PB":
                    return TUfEmi.PB;
                    break;
                case "PE":
                    return TUfEmi.PE;
                    break;
                case "AL":
                    return TUfEmi.AL;
                    break;
                case "SE":
                    return TUfEmi.SE;
                    break;
                case "BA":
                    return TUfEmi.BA;
                    break;
                case "MG":
                    return TUfEmi.MG;
                    break;
                case "ES":
                    return TUfEmi.ES;
                    break;
                case "RJ":
                    return TUfEmi.RJ;
                    break;
                case "SP":
                    return TUfEmi.SP;
                    break;
                case "PR":
                    return TUfEmi.PR;
                    break;
                case "SC":
                    return TUfEmi.SC;
                    break;
                case "RS":
                    return TUfEmi.RS;
                    break;
                case "MS":
                    return TUfEmi.MS;
                    break;
                case "MT":
                    return TUfEmi.MT;
                    break;
                case "GO":
                    return TUfEmi.GO;
                    break;
                case "DF":
                    return TUfEmi.DF;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("estado");
            }
        }

        public static TUf Sigla2TUf(string Sigla)
        {
            switch (Sigla)
            {
                case "RO":
                    return TUf.RO;
                    break;
                case "AC":
                    return TUf.AC;
                    break;
                case "AM":
                    return TUf.AM;
                    break;
                case "RR":
                    return TUf.RR;
                    break;
                case "PA":
                    return TUf.PA;
                    break;
                case "AP":
                    return TUf.AP;
                    break;
                case "TO":
                    return TUf.TO;
                    break;
                case "MA":
                    return TUf.MA;
                    break;
                case "PI":
                    return TUf.PI;
                    break;
                case "CE":
                    return TUf.CE;
                    break;
                case "RN":
                    return TUf.RN;
                    break;
                case "PB":
                    return TUf.PB;
                    break;
                case "PE":
                    return TUf.PE;
                    break;
                case "AL":
                    return TUf.AL;
                    break;
                case "SE":
                    return TUf.SE;
                    break;
                case "BA":
                    return TUf.BA;
                    break;
                case "MG":
                    return TUf.MG;
                    break;
                case "ES":
                    return TUf.ES;
                    break;
                case "RJ":
                    return TUf.RJ;
                    break;
                case "SP":
                    return TUf.SP;
                    break;
                case "PR":
                    return TUf.PR;
                    break;
                case "SC":
                    return TUf.SC;
                    break;
                case "RS":
                    return TUf.RS;
                    break;
                case "MS":
                    return TUf.MS;
                    break;
                case "MT":
                    return TUf.MT;
                    break;
                case "GO":
                    return TUf.GO;
                    break;
                case "DF":
                    return TUf.DF;
                    break;
                case "EX":
                    return TUf.EX;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("estado");
            }
        }

        public static TCodUfIBGELegado Sigla2TCodUfIBGE(string Sigla)
        {
            switch (Sigla)
            {
                case "RO":
                    return TCodUfIBGELegado.RO;
                    break;
                case "AC":
                    return TCodUfIBGELegado.AC;
                    break;
                case "AM":
                    return TCodUfIBGELegado.AM;
                    break;
                case "RR":
                    return TCodUfIBGELegado.RR;
                    break;
                case "PA":
                    return TCodUfIBGELegado.PA;
                    break;
                case "AP":
                    return TCodUfIBGELegado.AP;
                    break;
                case "TO":
                    return TCodUfIBGELegado.TO;
                    break;
                case "MA":
                    return TCodUfIBGELegado.MA;
                    break;
                case "PI":
                    return TCodUfIBGELegado.PI;
                    break;
                case "CE":
                    return TCodUfIBGELegado.CE;
                    break;
                case "RN":
                    return TCodUfIBGELegado.RN;
                    break;
                case "PB":
                    return TCodUfIBGELegado.PB;
                    break;
                case "PE":
                    return TCodUfIBGELegado.PE;
                    break;
                case "AL":
                    return TCodUfIBGELegado.AL;
                    break;
                case "SE":
                    return TCodUfIBGELegado.SE;
                    break;
                case "BA":
                    return TCodUfIBGELegado.BA;
                    break;
                case "MG":
                    return TCodUfIBGELegado.MG;
                    break;
                case "ES":
                    return TCodUfIBGELegado.ES;
                    break;
                case "RJ":
                    return TCodUfIBGELegado.RJ;
                    break;
                case "SP":
                    return TCodUfIBGELegado.SP;
                    break;
                case "PR":
                    return TCodUfIBGELegado.PR;
                    break;
                case "SC":
                    return TCodUfIBGELegado.SC;
                    break;
                case "RS":
                    return TCodUfIBGELegado.RS;
                    break;
                case "MS":
                    return TCodUfIBGELegado.MS;
                    break;
                case "MT":
                    return TCodUfIBGELegado.MT;
                    break;
                case "GO":
                    return TCodUfIBGELegado.GO;
                    break;
                case "DF":
                    return TCodUfIBGELegado.DF;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("estado");
            }
        }

        public static TCOrgaoIBGE Codigo2TCOrgaoIBGE(int codigoEstado)
        {
            TCOrgaoIBGE toRet;
            if(Enum.TryParse("Item"+codigoEstado,true,out toRet))
            {
                return toRet;
            }


            throw new Exception("Código do orgão de recepção do evento inválido: " + codigoEstado);
        }

        public static string ValidaCampoOpcional(string valor)
        {
            if (valor == null)
            {
                return null;
            }

            if (valor == "00000000")
            {
                return valor;
            }
            
            valor = valor.Trim();

            double tmp;
            if (Double.TryParse(valor, out tmp))
            {
                if (tmp == 0)
                {
                    return null;
                }
                else
                {
                    return valor.Trim();
                }
            }

            valor = RemoveInvalidXmlChars(valor);

            return string.IsNullOrWhiteSpace(valor) ? null : valor;
        }

        public static string RemoveInvalidXmlChars(string text)
        {
            var validXmlChars = text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
            return new string(validXmlChars);
        }


        public static int DigitoModulo11(string intNumero)
        {

            int[] intPesos = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9 };
            string strText = intNumero;

            if (strText.Length > 64)

                throw new Exception("Número não suportado pela função!");

            int intSoma = 0;
            int intIdx = 0;
            for (int intPos = strText.Length - 1; intPos >= 0; intPos--)
            {
                intSoma += int.Parse(strText[intPos].ToString()) * intPesos[intIdx];
                intIdx++;
            }
            int intDigito;

            int intResto = (intSoma) % 11;
            if (intResto == 0 || intResto == 1)
            {
                intDigito = 0;
            }
            else
            {
                intDigito = 11 - intResto;
            }


            return intDigito;
        }

        public static string CortaComprimentoMaximo(string valor, int comprimento )
        {
            if (valor != null)
            {
                valor = valor.Trim();
                return valor.Length > comprimento ? valor.Substring(0, comprimento) : valor;

            }
            return null;
        }

        public static long LimparTextoConverterInt(string valor)
        {
            string tmp = valor.Where(t => char.IsDigit(t) || t == '.').Aggregate("", (current, t) => current + t);
            long saida;
            if (long.TryParse(tmp,out saida))
            {
                return saida;
            }

            throw new Exception("Não é possível converter "+valor+" em um inteiro ");
        }

        public static string FormataValorSintegra(double valor)
        {
            return valor.ToString("F2", CultureInfo.InvariantCulture).Replace(",", "").Replace(".", "");
        }

        public static string ConverteParaStringHexa(string entrada)
        {
            return string.Join("", entrada.Select(c => ((int)c).ToString("x2"))); ;
        }

        public static string CalcularHashSHA1(string entrada)
        {
            SHA1 hasher = SHA1.Create();
            UTF8Encoding encoding = new UTF8Encoding();

            byte[] array = encoding.GetBytes(entrada);
            array = hasher.ComputeHash(array);

            StringBuilder strHexa = new StringBuilder();

            foreach (byte item in array)
            {
                // Convertendo  para Hexadecimal
                strHexa.Append(item.ToString("X2"));
            }

            return strHexa.ToString();
        }

        public static string GetXmlEnumAttributeValueFromEnum<TEnum>(this TEnum value) where TEnum : struct, IConvertible
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum) return null;//or string.Empty, or throw exception

            var member = enumType.GetMember(value.ToString()).FirstOrDefault(a=>a.MemberType == MemberTypes.Field);
            if (member == null) return null;//or string.Empty, or throw exception

            var attribute = member.GetCustomAttributes(false).OfType<XmlEnumAttribute>().FirstOrDefault();
            if (attribute == null) return null;//or string.Empty, or throw exception
            return attribute.Name;
        }

    }
}
