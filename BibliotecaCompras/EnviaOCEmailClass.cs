#region Referencias

using System;
using System.Collections.Generic;
using System.IO;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCompras
{
    public class EnviaOCEmailClass : EnvioEmailClass
    {
        readonly string Empresa;
        TipoOC Tipo;
        int idOC;
        Stream pdfOC;
        List<Stream> Anexos;
        List<string> NomesAnexos;
        private string corpoEmail;

        public EnviaOCEmailClass(string empresa, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
            : base( usuario,conn)
        {      
            this.Empresa = empresa;
        }


        public override string getTituloEmail()
        {
            if (this.Tipo == TipoOC.OC)
            {
                return "Pedido de Compra Nº. " + idOC + " - " + this.Empresa;
            }
            else
            {
                return "Solicitação de Orçamento Nº. " + idOC + " - " + this.Empresa;
            }
        }

        public override string getCorpoEmail()
        {
            if (string.IsNullOrEmpty(corpoEmail))
            {
                string toRet = "Favor avaliar ";
                if (this.Tipo == TipoOC.OC)
                {
                    toRet += "Pedido de Compra ";
                }
                else
                {
                    toRet += "Solicitação de Orçamento ";
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

        public void setOC(int idOC, Stream pdfOC, TipoOC Tipo, List<Stream> anexos, List<string> nomesAnexos  )
        {
            this.idOC = idOC;
            this.pdfOC = pdfOC;
            this.Tipo = Tipo;
            this.Anexos = anexos;
            this.NomesAnexos = nomesAnexos;
        }

        public void Enviar(string Destinatario, string Remetente, string CorpoEmail)
        {
            this.corpoEmail = CorpoEmail;
            string nome = "";
            if (this.Tipo == TipoOC.OC)
            {
                nome = "OC_" + idOC + ".pdf";
            }
            else
            {
                nome = "COTACAO_" + idOC + ".pdf";
            }

            List<Stream> anexosEnviar = new List<Stream>(){pdfOC};
            List<string> nomesAnexosEnviar = new List<string>(){ nome };
            if (this.Anexos.Count!=this.NomesAnexos.Count)
            {
                throw new Exception("A quantidade de anexos não é compatível com a quantidade de nome dos anexos");
            }
            for (int i =0;i<this.Anexos.Count;i++)
            {
                anexosEnviar.Add(this.Anexos[i]);
                nomesAnexosEnviar.Add(this.NomesAnexos[i]);
            }

            base.EnviaEmail(Destinatario, Remetente, anexosEnviar,nomesAnexosEnviar);
        }
    }
}
