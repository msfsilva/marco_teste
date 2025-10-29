using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class TransporteClass : TransporteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do TransporteClass";
        protected new const string ErroDelete = "Erro ao excluir o TransporteClass  ";
        protected new const string ErroSave = "Erro ao salvar o TransporteClass.";
        protected new const string ErroCollectionEmbarqueClassTransporte = "Erro ao carregar a coleção de EmbarqueClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do TransporteClass.";
        protected new const string MensagemUtilizadoCollectionEmbarqueClassTransporte = "A entidade TransporteClass está sendo utilizada nos seguintes EmbarqueClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade TransporteClass está sendo utilizada.";

        #endregion

        public TransporteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        public string PlacaSigla
        {
            get
            {
                if (this.EstadoVeiculo != null)
                {
                    return this.Placa + " " + this.EstadoVeiculo.Sigla;    
                }
                return this.Placa;
            }
        }



        public override string ToString()
        {
            return this.Identificacao;
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "PlacaSigla":
                    orderByClause += " , transporte.trp_placa || ' '|| est1.est_sigla " + ordenacao.ToString();
                    command.CommandText += "  LEFT OUTER JOIN public.estado est1 ON (public.transporte.id_estado_veiculo = est1.id_estado) ";
                    return true;
                default:
                    return false;
            }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }

       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (!string.IsNullOrEmpty(this.CpfCnpj))
            {
                string cpfCnpj = this.CpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
                if (cpfCnpj.Length == 11)
                {
                    if (!IWTFunctions.IWTFunctions.validaCPF(cpfCnpj))
                    {
                        throw new Exception("CPF Inválido.");
                    }
                }
                else
                {
                    if (cpfCnpj.Length == 14)
                    {
                        if (!IWTFunctions.IWTFunctions.validaCNPJ(cpfCnpj))
                        {
                            throw new Exception("CNPJ Inválido.");
                        }
                    }
                    else
                    {
                        throw new Exception("CPF/CNPJ Inválido.");
                    }
                }
            }
            return true;
        }
    }
}
