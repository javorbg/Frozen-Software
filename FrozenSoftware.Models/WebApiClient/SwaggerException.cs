using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace FrozenSoftware.Models
{
    [GeneratedCode("NSwag", "12.1.0.0 (NJsonSchema v9.13.28.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class SwaggerException : Exception
    {
        public SwaggerException(string message, int statusCode, string response, Dictionary<string, IEnumerable<string>> headers, Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public Dictionary<string, IEnumerable<string>> Headers { get; private set; }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }
}
