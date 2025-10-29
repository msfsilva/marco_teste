using System;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTNF.Entidades.Base;
using PresencaComprador = IWTNF.Entidades.Base.PresencaComprador;

namespace BibliotecaNotasFiscais
{
    /// <summary>
    /// Classe que divide as notas fiscais, documentação em https://iwtv2s.atlassian.net/l/c/tVwGGH2W
    /// </summary>
    internal class organizaNfClassKey{

        //Qualquer mudança nessa classe deve ser refletida no documento em https://iwtv2s.atlassian.net/l/c/tVwGGH2W - Marco - 2020-12-02

        internal string idClienteAccess { get; }
        internal string armazenagemCliente { get; }
        internal string naturezaOperacao { get; }
        internal bool matAdicional { get; }
        internal int idCliente { get; }
        internal bool pedidoNovo { get; }
        internal int idTransporte { get; }
        internal bool devolverMateriaisCliente { get; }
        internal ModalidadeFrete responsavelFrete { get; }
        internal FormaFretePedido FormaFrete { get; }

        internal int idCentroCustoLucro { get; }
        internal int idContaBancaria { get; }
        internal int idFormaPagamento { get; }

        public bool ConsumidorFinal { get; }
        public PresencaComprador PresencaComprador { get; }

        public bool GerarContasReceber { get; }


        public  EasiEmissorNFe EmissorNfe { get; }

        public string PlantaCliente { get; }

        public bool SomaFreteBcIcms { get; }

        public bool SomaFreteBcIpi { get; }
        public long IdTipoPagamento { get; }

        public bool EnvioTerceiros { get; }

        public long IdClienteEnvioTerceiros { get; }

        public long IdOperacaoEnvioTerceiros { get; }

        public long IdOperacaoCompletaEnvioTerceiros { get; }

        public bool DevolverMaterialClienteNfSeparada { get; }
        public string DevolverMaterialClienteNfSeparadaNaturezaOp { get; }
        public bool DescontarImcsBcPis { get;  }
        public bool DescontarImcsBcCofins { get; }

        internal organizaNfClassKey(bool pedidoNovo, string idClienteAccess, int idCliente, string armazenagemCliente, string naturezaOperacao,
            bool matAdicional, int idTransporte, bool devolverMateriaisCliente,
            ModalidadeFrete responsavelFrete, int idCentroCustoLucro, int idContaBancaria, int idFormaPagamento, FormaFretePedido formaFrete,
            bool consumidorFinal, PresencaComprador presencaComprador, bool gerarContasReceber, EasiEmissorNFe emissorNFe, string plantaCliente, 
            bool somaFreteBcIcms, bool somaFreteBcIpi, long idTipoPagamento, bool envioTerceiros, long idClienteEnvioTerceiros, long idOperacaoEnvioTerceiros, long idOperacaoCompletaEnvioTerceiros,
            bool devolverMaterialClienteNfSeparada,  string devolverMaterialClienteNfSeparadaNaturezaOp,
            bool descontarImcsBcPis, bool descontarImcsBcCofins)
        {
            this.idClienteAccess = idClienteAccess;
            this.armazenagemCliente = armazenagemCliente;
            this.naturezaOperacao = naturezaOperacao;
            this.matAdicional = matAdicional;
            this.idCliente = idCliente;
            this.pedidoNovo = pedidoNovo;
            this.idTransporte = idTransporte;
            this.devolverMateriaisCliente = devolverMateriaisCliente;
            this.responsavelFrete = responsavelFrete;
            
            this.idCentroCustoLucro = idCentroCustoLucro;
            this.idContaBancaria = idContaBancaria;
            this.idFormaPagamento = idFormaPagamento;
            this.FormaFrete = formaFrete;

            this.ConsumidorFinal = consumidorFinal;
            this.PresencaComprador = presencaComprador;

            this.GerarContasReceber = gerarContasReceber;

            EmissorNfe = emissorNFe;
            PlantaCliente = plantaCliente;
            SomaFreteBcIcms = somaFreteBcIcms;
            SomaFreteBcIpi = somaFreteBcIpi;

            IdTipoPagamento = idTipoPagamento;

            EnvioTerceiros = envioTerceiros;
            IdClienteEnvioTerceiros = idClienteEnvioTerceiros;
            IdOperacaoEnvioTerceiros = idOperacaoEnvioTerceiros;
            IdOperacaoCompletaEnvioTerceiros = idOperacaoCompletaEnvioTerceiros;
            DevolverMaterialClienteNfSeparada = devolverMaterialClienteNfSeparada;
            DevolverMaterialClienteNfSeparadaNaturezaOp = devolverMaterialClienteNfSeparadaNaturezaOp;
            DescontarImcsBcPis = descontarImcsBcPis;
            DescontarImcsBcCofins = descontarImcsBcCofins;
        }


        protected bool Equals(organizaNfClassKey other)
        {
            return string.Equals(idClienteAccess, other.idClienteAccess) && string.Equals(armazenagemCliente, other.armazenagemCliente) && string.Equals(naturezaOperacao, other.naturezaOperacao) && matAdicional.Equals(other.matAdicional) && idCliente == other.idCliente && pedidoNovo.Equals(other.pedidoNovo) && idTransporte == other.idTransporte && devolverMateriaisCliente.Equals(other.devolverMateriaisCliente) && responsavelFrete == other.responsavelFrete && FormaFrete == other.FormaFrete && idCentroCustoLucro == other.idCentroCustoLucro && idContaBancaria == other.idContaBancaria && idFormaPagamento == other.idFormaPagamento && ConsumidorFinal.Equals(other.ConsumidorFinal) && PresencaComprador == other.PresencaComprador && GerarContasReceber == other.GerarContasReceber  && EmissorNfe == other.EmissorNfe && PlantaCliente == other.PlantaCliente && SomaFreteBcIcms == other.SomaFreteBcIcms && SomaFreteBcIpi == other.SomaFreteBcIpi && IdTipoPagamento == other.IdTipoPagamento 
                   && DevolverMaterialClienteNfSeparada == other.DevolverMaterialClienteNfSeparada
                   && string.Equals(DevolverMaterialClienteNfSeparadaNaturezaOp, other.DevolverMaterialClienteNfSeparadaNaturezaOp)
                   && DescontarImcsBcPis == other.DescontarImcsBcPis
                   && DescontarImcsBcCofins == other.DescontarImcsBcCofins
                ;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((organizaNfClassKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (idClienteAccess != null ? idClienteAccess.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (armazenagemCliente != null ? armazenagemCliente.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (naturezaOperacao != null ? naturezaOperacao.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ matAdicional.GetHashCode();
                hashCode = (hashCode*397) ^ idCliente;
                hashCode = (hashCode*397) ^ pedidoNovo.GetHashCode();
                hashCode = (hashCode*397) ^ idTransporte;
                hashCode = (hashCode*397) ^ devolverMateriaisCliente.GetHashCode();
                hashCode = (hashCode*397) ^ (int) responsavelFrete;
                hashCode = (hashCode*397) ^ (int) FormaFrete;
                hashCode = (hashCode*397) ^ idCentroCustoLucro;
                hashCode = (hashCode*397) ^ idContaBancaria;
                hashCode = (hashCode*397) ^ idFormaPagamento;
                hashCode = (hashCode*397) ^ ConsumidorFinal.GetHashCode();
                hashCode = (hashCode*397) ^ (int) PresencaComprador;
                hashCode = (hashCode * 397) ^ GerarContasReceber.GetHashCode();
                hashCode = (hashCode * 397) ^ EmissorNfe.GetHashCode();
                hashCode = (hashCode * 397) ^ PlantaCliente.GetHashCode();
                hashCode = (hashCode * 397) ^ SomaFreteBcIcms.GetHashCode();
                hashCode = (hashCode * 397) ^ SomaFreteBcIpi.GetHashCode();
                hashCode = (hashCode * 397) ^ IdTipoPagamento.GetHashCode();

                hashCode = (hashCode * 397) ^ EnvioTerceiros.GetHashCode();
                hashCode = (hashCode * 397) ^ IdClienteEnvioTerceiros.GetHashCode();
                hashCode = (hashCode * 397) ^ IdOperacaoEnvioTerceiros.GetHashCode();
                hashCode = (hashCode * 397) ^ IdOperacaoCompletaEnvioTerceiros.GetHashCode();

                hashCode = (hashCode * 397) ^ DevolverMaterialClienteNfSeparada.GetHashCode();

                hashCode = (hashCode * 397) ^ DescontarImcsBcPis.GetHashCode();
                hashCode = (hashCode * 397) ^ DescontarImcsBcCofins.GetHashCode();

                if (DevolverMaterialClienteNfSeparadaNaturezaOp != null)
                {
                    hashCode = (hashCode * 397) ^ DevolverMaterialClienteNfSeparadaNaturezaOp.GetHashCode();
                }


                return hashCode;
            }
        }
    }
}