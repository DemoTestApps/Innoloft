using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Demo.Api.Models
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string message, int statusCode, string apiVersion, object error = null)
        {
            Message = message;
            StatusCode = statusCode;
            Error = error;
            Version = apiVersion;
        }

        public string Version { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Error { get; set; }
    }
}
