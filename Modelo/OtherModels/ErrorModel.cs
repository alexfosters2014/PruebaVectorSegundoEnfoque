using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class ErrorModel
    {
        public ErrorModel(string errorMensaje, HttpStatusCode statusCode)
        {
            CodigoError = statusCode;
            ErrorMensaje = errorMensaje;
        }
        public HttpStatusCode CodigoError { get; set; }
        public string ErrorMensaje { get; set; }
    }
}
