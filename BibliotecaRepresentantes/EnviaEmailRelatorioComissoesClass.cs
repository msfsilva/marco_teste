using System.Collections.Generic;
using System.IO;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaRepresentantes
{
    public class EnviaEmailRelatorioComissoesClass :  EnvioEmailClass
    {
        private string _corpoEmail;


        public EnviaEmailRelatorioComissoesClass( AcsUsuarioClass usuario,IWTPostgreNpgsqlConnection conn) 
            : base(usuario,conn)
        {
        }

        public override string getTituloEmail()
        {

            return "Relatório de Comissões";

        }

        public override string getCorpoEmail()
        {
            return this._corpoEmail;
        }

        public override bool isHtmlEmail()
        {
            return false;
        }



        public void Enviar(string Destinatario, string Remetente, string nomeRepresentante, string mesAno, Stream relatorio)
        {
            _corpoEmail = "Você está recebendo o relatório de comissões de " + mesAno + " do representante " + nomeRepresentante;
            string nome = "COMISSOES_" + mesAno.Replace("/", "_") + ".pdf";


            List<Stream> anexosEnviar = new List<Stream>() { relatorio };
            List<string> nomesAnexosEnviar = new List<string>() { nome };

            base.EnviaEmail(Destinatario, Remetente, anexosEnviar, nomesAnexosEnviar);
        }
    }
}
