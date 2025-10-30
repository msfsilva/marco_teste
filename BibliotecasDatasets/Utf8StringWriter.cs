using System.IO;
using System.Text;

namespace IWTNFCompleto.BibliotecaDatasets
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }

}
