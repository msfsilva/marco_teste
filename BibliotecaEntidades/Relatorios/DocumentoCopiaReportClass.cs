using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.Relatorios
{
    public class DocumentoCopiaReportClass
    {

        private DocumentoCopiaClass copia;

       
        public string Identificacao
        {
            get { return this.copia.Identificacao; }
        }
        
        public DateTime DataCriacao
        {
            get { return this.copia.DataCriacao; }
        }


        public string Familia
        {
            get { return this.copia.DocumentoTipoFamilia.FamiliaDocumento.ToString(); }
        }


        public string Documento
        {
            get { return this.copia.DocumentoTipoFamilia.DocumentoTipo.ToString(); }
        }

        public string RevisaoPai
        {
            get { return this.copia.DocumentoTipoFamilia.DocumentoTipo.RevisaoAtual; }
        }

        public string Usuario
        {
            get { return this.copia.AcsUsuarioImpressao.ToString(); }
        }

        public string Estoque
        {
            get { return this.copia.LocalizacaoEstoque.ToString(); }
        }

        public byte[] CodigoBarras
        {
            get { return this.copia.codigoBarras; }
        }


        public DocumentoCopiaReportClass(DocumentoCopiaClass copia)
        {
            this.copia = copia;
        }

    }
}
