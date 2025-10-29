using System;
using System.Collections.Generic;
using System.IO;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaPedidos
{
    public class EnviaEmailPedidoEspelhoClass :  EnvioEmailClass
    {
        
        PedidoOrcamento tipoPedidoOrcamento;
        string numero;
        string posicao;
        Stream pdfPedidoOrcamento;
        List<Stream> Anexos;
        List<string> NomesAnexos;
        private string corpoEmail;


        public EnviaEmailPedidoEspelhoClass(AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn) 
            : base( usuario, conn)
        {
            
        }

        public override string getTituloEmail()
        {
            string posTemp = "";
            if (!String.IsNullOrWhiteSpace(posicao))
            {
                posTemp = "/" + posicao;
            }

            if (this.tipoPedidoOrcamento == PedidoOrcamento.Pedido)
            {
                return "Pedido Nº. " + numero + posTemp; //+ " - " + this.Empresa;
            }
            else
            {
                return "Orçamento Nº. " + numero + posTemp;// + " - " + this.Empresa;
            }
        }

        public override string getCorpoEmail()
        {
            if (string.IsNullOrEmpty(corpoEmail))
            {
                string toRet = "Favor avaliar ";
                if (this.tipoPedidoOrcamento == PedidoOrcamento.Pedido)
                {
                    toRet += "Pedido ";
                }
                else
                {
                    toRet += "Orçamento ";
                }
                toRet += "em anexo.";

                return toRet;
            }
            else
            {

                return this.corpoEmail;
            }
        }

        public override bool isHtmlEmail()
        {
            return false;
        }


        public void setPedidoOrcamento(string numero, string posicao, Stream pdfPedidoOrcamento, PedidoOrcamento Tipo, List<Stream> anexos, List<string> nomesAnexos)
        {
            this.numero = numero;
            this.posicao = posicao;
            this.pdfPedidoOrcamento = pdfPedidoOrcamento;
            this.tipoPedidoOrcamento = Tipo;
            this.Anexos = anexos;
            this.NomesAnexos = nomesAnexos;
        }

        public void Enviar(string Destinatario, string Remetente, string CorpoEmail)
        {
            this.corpoEmail = CorpoEmail;
            string nome = "";

            string posTemp = "";
            if (!String.IsNullOrWhiteSpace(posicao))
            {
                posTemp = "_"+posicao;
            }
            if (this.tipoPedidoOrcamento == PedidoOrcamento.Pedido)
            {
                nome = "PEDIDO_" + numero + posTemp + ".pdf";
            }
            else
            {
                nome = "ORÇAMENTO_" + numero + posTemp + ".pdf";
            }

            List<Stream> anexosEnviar = new List<Stream>() { pdfPedidoOrcamento };
            List<string> nomesAnexosEnviar = new List<string>() { nome };
            if (this.Anexos.Count != this.NomesAnexos.Count)
            {
                throw new Exception("A quantidade de anexos não é compatível com a quantidade de nome dos anexos");
            }
            for (int i = 0; i < this.Anexos.Count; i++)
            {
                anexosEnviar.Add(this.Anexos[i]);
                nomesAnexosEnviar.Add(this.NomesAnexos[i]);
            }

            base.EnviaEmail(Destinatario, Remetente, anexosEnviar, nomesAnexosEnviar);
        }
    }
}
