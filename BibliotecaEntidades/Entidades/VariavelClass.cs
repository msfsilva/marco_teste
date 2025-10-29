using System;
using System.Globalization;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class VariavelClass : VariavelBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do VariavelClass";
        protected new const string ErroDelete = "Erro ao excluir o VariavelClass  ";
        protected new const string ErroSave = "Erro ao salvar o VariavelClass.";
        protected new const string ErroCollectionProdutoClassVariavel1 = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroCollectionProdutoClassVariavel2 = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroCollectionProdutoClassVariavel3 = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroCollectionProdutoClassVariavel4 = "Erro ao carregar a coleção de ProdutoClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do VariavelClass.";
        protected new const string MensagemUtilizadoCollectionProdutoClassVariavel1 = "A entidade VariavelClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassVariavel2 = "A entidade VariavelClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassVariavel3 = "A entidade VariavelClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoClassVariavel4 = "A entidade VariavelClass está sendo utilizada nos seguintes ProdutoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade VariavelClass está sendo utilizada.";

        #endregion


        public VariavelClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }


        public string TipoTraduzido
        {
            get
            {
                switch (Tipo)
                {
                    case TipoRegra.RetornoNumero:
                        return "Numérica";
                        break;
                    case TipoRegra.RetornoBoolean:
                        return "Verdadeiro/Falso";
                        break;
                    case TipoRegra.RetornoTexto:
                        return "Texto";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        public bool PossuiFamilia
        {
            get
            {
                if (this.FamiliaCliente != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
          
        }

        public TipoRegra TipoOriginal
        {
            get { return _tipoOriginal; }
        }

        public override string ToString()
        {
            return this.Nome;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "FamiliaClienteOrNull":
                    if (parametro.Fieldvalue is FamiliaClienteClass)
                    {

                        whereClause = "  AND ( public.variavel.id_familia_cliente = " +
                                      ((FamiliaClienteClass) parametro.Fieldvalue).ID + " OR  " +
                                      "  public.variavel.id_familia_cliente IS NULL ) ";
                    }
                    else
                    {
                        throw new ExcecaoTratada("O parâmetro informado não é do tipo FamiliaClienteClass");
                    }
                    return true;

                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause,
            SearchOrdenacao ordenacao,
            ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "TipoTraduzido":
                    orderByClause += " , var_tipo " + ordenacao.ToString() + " ";
                    return true;
                default:
                    return false;
            }
        }


        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            string motivo;
            bool toRet = CustomizacoesClienteFactory.Factory.ValidaAlteracaoVariavelClass(this,UsuarioAtual,command, out motivo);
            if (!toRet)
            {
                throw new ExcecaoTratada(motivo);
            }

            return true;
        }

        public bool ComparaValor(string valor1, string valor2)
        {
            CultureInfo ptBr = CultureInfo.GetCultureInfo("pt-BR");

            switch (Tipo)
            {
                case TipoRegra.RetornoNumero:
                    double doubleTmp1;
                    if (!double.TryParse(valor1, NumberStyles.Any, ptBr, out doubleTmp1))
                    {
                        return false;
                    }
                    double doubleTmp2;
                    if (!double.TryParse(valor2, NumberStyles.Any, ptBr, out doubleTmp2))
                    {
                        return false;
                    }

                    return Math.Abs(doubleTmp1 - doubleTmp2) < 0.000001;
                case TipoRegra.RetornoBoolean:
                    short shortTmp1;
                    if (!short.TryParse(valor1, NumberStyles.Any, ptBr, out shortTmp1))
                    {
                        return false;
                    }
                    short shortTmp2;
                    if (!short.TryParse(valor2, NumberStyles.Any, ptBr, out shortTmp2))
                    {
                        return false;
                    }

                    return shortTmp1 == shortTmp2;
                case TipoRegra.RetornoTexto:
                    return valor1.Trim().ToUpperInvariant() == valor2.Trim().ToUpperInvariant();

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
