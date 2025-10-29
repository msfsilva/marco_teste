using System.Net;

namespace BibliotecaEntidades.SDC.dto
{
    public class ErrorClass
    {
        public string status { get; set; }
        public string message { get; set; }
        public HttpStatusCode errorCode { get; set; }
    }
}
