using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using CSScriptLibrary;

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public class Configurador
    {
        private Dictionary<string, Variavel> variaveisDoPedido;


        public Configurador(Dictionary<string, Variavel> variaveis)
        {
            this.variaveisDoPedido = variaveis;
        }

        public void atualizarVariaveis(Dictionary<string, Variavel> variaveis)
        {
            this.variaveisDoPedido = variaveis;
        }


        //public void testaRegras(string Regra, ConfiguradorTipoRegra Tipo, string codProduto)
        //{

        //    try
        //    {
        //        CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
        //        CompilerParameters parameters = new CompilerParameters();
        //        parameters.GenerateInMemory = true;
        //        parameters.ReferencedAssemblies.Add("System.dll");
        //        parameters.TreatWarningsAsErrors = false;


        //        CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, Regra);


        //        if (results.Errors.Count > 0)
        //        {
        //            string errorMsg = " Erro de sintaxe nas regras do produto: " + codProduto + " ";
        //            foreach (CompilerError CompErr in results.Errors)
        //            {
        //                errorMsg += CompErr.ErrorText + ";" + Environment.NewLine;
        //            }

        //            throw new Exception(errorMsg);
        //        }
        //    }
        //    catch (Exception a)
        //    {
        //        throw new Exception("Erro ao validar as regras do produto: " + codProduto + "!\r\n" + a.Message);
        //    }
        //}

        private string montaCodigo(string Regra, ConfiguradorTipoRegra Tipo, string nomeRegra)
        {
            string toRetCodigo = Regra.Trim();

            if (toRetCodigo.Length > 0)
            {
                //Substitui as Variaveis que serão utilizadas
                try
                {
                    if (!toRetCodigo.ToLower().Contains("$_valor_final_$"))
                    {
                        toRetCodigo = "$_valor_final_$=" + toRetCodigo;
                    }

                    if (toRetCodigo.Trim()[toRetCodigo.Trim().Length - 1] != ';')
                    {
                        toRetCodigo = toRetCodigo.Trim() + ";";
                    }
                }
                catch (Exception A)
                {
                    throw new Exception("Erro ao preparar a regra para execução!\r\n" + A.Message);
                }
                
            }

            toRetCodigo = this.substituicaoVariaveis(toRetCodigo, Tipo, nomeRegra);

            string codigo = "" +
                            "using System;" + Environment.NewLine +
                            "using System.Collections.Generic;" + Environment.NewLine +
                            "using System.Text;" + Environment.NewLine +
                            "using System.Linq;" + Environment.NewLine +
                            "using BibliotecaEntidades.Operacoes.Configurador;" + Environment.NewLine +
                            "" + Environment.NewLine +
                            "" + Environment.NewLine +
                            "namespace BibliotecaEntidades.Operacoes.Configurador" + Environment.NewLine +
                            "{" + Environment.NewLine +
                            "   public partial class IWTConfRegras : IIwtConfRegras" + Environment.NewLine +
                            "   {" + Environment.NewLine +
                            "       public IWTConfRegras()" + Environment.NewLine +
                            "       {" + Environment.NewLine +
                            "       }" + Environment.NewLine;


            codigo +=
                "       private double se(bool condicao, double v, double f)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "           if (condicao)" + Environment.NewLine +
                "           {" + Environment.NewLine +
                "               return v;" + Environment.NewLine +
                "           }" + Environment.NewLine +
                "           else" + Environment.NewLine +
                "           {" + Environment.NewLine +
                "               return f;" + Environment.NewLine +
                "           }" + Environment.NewLine +
                "       }" + Environment.NewLine;

            codigo +=
                "       private bool se(bool condicao, bool v, bool f)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "           if (condicao)" + Environment.NewLine +
                "           {" + Environment.NewLine +
                "               return v;" + Environment.NewLine +
                "           }" + Environment.NewLine +
                "           else" + Environment.NewLine +
                "           {" + Environment.NewLine +
                "               return f;" + Environment.NewLine +
                "           }" + Environment.NewLine +
                "       }" + Environment.NewLine;

            codigo +=
                "       private string se(bool condicao, string v, string f)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "           if (condicao)" + Environment.NewLine +
                "           {" + Environment.NewLine +
                "               return v;" + Environment.NewLine +
                "           }" + Environment.NewLine +
                "           else" + Environment.NewLine +
                "           {" + Environment.NewLine +
                "               return f;" + Environment.NewLine +
                "           }" + Environment.NewLine +
                "       }" + Environment.NewLine;

            codigo +=
                "       private bool e(params bool[] condicoes)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "          return new List<bool>(condicoes).All(a=>a); " + Environment.NewLine +
                "       }" + Environment.NewLine;


            codigo +=
                "       private bool E(params bool[] condicoes)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "           return e(condicoes);" + Environment.NewLine +
                "       }" + Environment.NewLine
                ;

            codigo +=
                "       private bool ou(params bool[] condicoes)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "          return new List<bool>(condicoes).Any(a=>a); ; " + Environment.NewLine +
                "       }" + Environment.NewLine
                ;

            codigo +=
                "       private bool Ou(params bool[] condicoes)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "           return ou(condicoes);" + Environment.NewLine +
                "       }" + Environment.NewLine
                ;

            codigo +=
                "       private bool OU(params bool[] condicoes)" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "           return ou(condicoes);" + Environment.NewLine +
                "       }" + Environment.NewLine
                ;

            codigo +=
                "       public object regra()" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "           " + toRetCodigo + Environment.NewLine +
                "       }" + Environment.NewLine +
                "   }" + Environment.NewLine +
                "}" + Environment.NewLine +
                "";

            return codigo;

        }

        private bool validaRegra(string regra, out string erro)
        {
            if (regra == "")
            {
                erro = "";
                return true;
            }
            regra = regra.ToLower();
            if (regra.Contains("int "))
            {
                erro = "Palavra reservada 'int ' encontrada";
                return false;
            }
            if (regra.Contains("double "))
            {
                erro = "Palavra reservada 'double ' encontrada";
                return false;
            }
            if (regra.Contains("float "))
            {
                erro = "Palavra reservada 'float ' encontrada";
                return false;
            }
            if (regra.Contains("bool "))
            {
                erro = "Palavra reservada 'bool ' encontrada";
                return false;
            }
            if (regra.Contains("string "))
            {
                erro = "Palavra reservada 'string ' encontrada";
                return false;
            }
            if (regra.Contains("boolean "))
            {
                erro = "Palavra reservada 'boolean ' encontrada";
                return false;
            }
            if (regra.Contains("for("))
            {
                erro = "Palavra reservada 'for( ' encontrada";
                return false;
            }
            if (regra.Contains("while("))
            {
                erro = "Palavra reservada 'while( ' encontrada";
                return false;
            }
            if (regra.Contains("for ("))
            {
                erro = "Palavra reservada 'for (' encontrada";
                return false;
            }
            if (regra.Contains("while ("))
            {
                erro = "Palavra reservada 'while (' encontrada";
                return false;
            }
            //if (!regra.Contains("$_valor_final_$")) { erro = "Não existe identificação de valor de saída. A variável $_VALOR_FINAL_$ é obrigatória."; return false; }

            erro = "";
            return true;

        }

        private string substituicaoVariaveis(string regra, ConfiguradorTipoRegra Tipo, string nomeRegra)
        {
            //Valida a Regra em busca de coisas não permitidas

            string erro;
            if (regra.Trim() == "" || regra.Trim() == ";")
            {
                switch (Tipo)
                {
                    case ConfiguradorTipoRegra.RegraDouble:
                        return "return 0;";
                        break;

                    case ConfiguradorTipoRegra.RegraBoolean:
                        return "return true;";
                        break;
                    case ConfiguradorTipoRegra.RegraString:
                        return "return '';";
                        break;
                    default:
                        throw new Exception("Tipo Inválido.");
                        break;
                }


            }

            if (!validaRegra(regra, out erro))
            {
                throw new Exception(erro);
                return null;
            }





            int inicio = 0;
            bool iniFound = false;
            for (int i = 0; i < regra.Length; i++)
            {
                if (regra[i] == '$')
                {
                    if (iniFound)
                    {
                        string varNomeOriginal = regra.Substring(inicio + 1, i - (inicio + 1));
                        string varNome = varNomeOriginal.ToUpper();

                        switch (varNome)
                        {

                            case "_VALOR_FINAL_":
                                switch (Tipo)
                                {
                                    case ConfiguradorTipoRegra.RegraDouble:
                                        regra = regra.Replace("$" + varNomeOriginal + "$=", "return ");
                                        regra = regra.Replace("$" + varNomeOriginal + "$ =", "return ");
                                        break;

                                    case ConfiguradorTipoRegra.RegraBoolean:
                                        regra = regra.Replace("$" + varNomeOriginal + "$=", "return ");
                                        regra = regra.Replace("$" + varNomeOriginal + "$ =", "return ");
                                        break;
                                    default:
                                        throw new Exception("Tipo Inválido.");
                                        break;
                                }


                                iniFound = false;
                                inicio = 0;
                                i = 0;
                                break;

                            default:
                                if (this.variaveisDoPedido.ContainsKey(varNome))
                                {
                                    //Verifica se o conteúdo da variável é um número real
                                    double tmpValor;
                                    if (double.TryParse(this.variaveisDoPedido[varNome].Valor, NumberStyles.Any, CultureInfo.CurrentCulture, out tmpValor))
                                    {
                                        regra = regra.Replace("$" + varNomeOriginal + "$", tmpValor.ToString("F5", CultureInfo.InvariantCulture));
                                    }
                                    else
                                    {
                                        if (double.TryParse(this.variaveisDoPedido[varNome].Valor, NumberStyles.Any, CultureInfo.InvariantCulture, out tmpValor))
                                        {
                                            regra = regra.Replace("$" + varNomeOriginal + "$", tmpValor.ToString("F5", CultureInfo.InvariantCulture));
                                        }
                                        else
                                        {
                                            regra = regra.Replace("$" + varNomeOriginal + "$", "\"" + this.variaveisDoPedido[varNome].Valor + "\"");
                                        }
                                    }


                                    iniFound = false;
                                    inicio = 0;
                                    i = 0;
                                }
                                else
                                {
                                    throw new Exception("Variável '" + varNomeOriginal + "' não foi encontrada no pedido. Variável exigida pela " + nomeRegra);
                                    return null;
                                }
                                break;
                        }

                    }
                    else
                    {
                        iniFound = true;
                        inicio = i;
                    }
                }
            }




            return regra;

        }

        public bool Start(string Regra, ConfiguradorTipoRegra Tipo, string codProduto,string nomeRegra, bool material, out object Retorno)
        {
            if (string.IsNullOrWhiteSpace(Regra))
            {
                switch (Tipo)
                {
                    case ConfiguradorTipoRegra.RegraDouble:
                        Retorno = 0;
                        break;
                    case ConfiguradorTipoRegra.RegraBoolean:
                        Retorno = true;
                        break;
                    case ConfiguradorTipoRegra.RegraString:
                        Retorno = "";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Tipo");
                }
               
                return true;
            }

            Regra = this.montaCodigo(Regra, Tipo, nomeRegra);
            //this.testaRegras(Regra, Tipo, codProduto);


            try
            {
                Assembly creator = CSScript.LoadCode(Regra);

                IIwtConfRegras script = creator.CreateInstance("BibliotecaEntidades.Operacoes.Configurador.IWTConfRegras").AlignToInterface<IIwtConfRegras>();

                object result = script.regra();

                string tipoResult = result.GetType().Name;
                switch (tipoResult)
                {
                    case "Int32":
                    case "Double":
                        Retorno = Convert.ToDouble(result);
                        break;

                    case "Boolean":
                        Retorno = (bool)result;
                        break;

                    case "String":
                        Retorno = result;
                        break;

                    default:
                        throw new Exception("Tipo Inválido.");
                        break;

                }

                return true;




                //CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                //CompilerParameters parameters = new CompilerParameters();
                //parameters.GenerateInMemory = true;
                //parameters.ReferencedAssemblies.Add("System.dll");
                //parameters.TreatWarningsAsErrors = false;


                //CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, Regra);


                //if (results.Errors.Count > 0)
                //{
                //    string errorMsg = " Erro de sintaxe nas regras do produto:" + codProduto + " ";
                //    foreach (CompilerError CompErr in results.Errors)
                //    {
                //        errorMsg += CompErr.ErrorText + ";" + Environment.NewLine;
                //    }

                //    throw new Exception(errorMsg);
                //}
                //else
                //{
                //    //Successful Compile

                //    object Instance = results.CompiledAssembly.CreateInstance("BibliotecaConfigurador.IWTConfRegras");

                //    object result = results.CompiledAssembly.GetType("BibliotecaConfigurador.IWTConfRegras").GetMethod("regra").Invoke(Instance, null);



                //    string tipoResult = result.GetType().Name;
                //    switch (tipoResult)
                //    {
                //        case "Int32":
                //        case "Double":
                //            Retorno = Convert.ToDouble(result);
                //            break;

                //        case "Boolean":
                //            Retorno = (bool) result;
                //            break;

                //        case "String":
                //            Retorno = result;
                //            break;

                //        default:
                //            throw new Exception("Tipo Inválido.");
                //            break;

                //    }

                //    return true;

                //}


            }
            catch (Exception a)
            {

                throw new Exception("Erro ao configurar o " + (material ? "material" : "produto") + ": " + codProduto + " (" + nomeRegra + ")" + "\r\n" + a.Message);

            }

        }


    }
}