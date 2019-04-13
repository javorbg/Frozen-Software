using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace FrozenSoftware.Models.WebApiClient
{
    [GeneratedCode("NSwag", "12.1.0.0 (NJsonSchema v9.13.28.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, int statusCode, string response, Dictionary<string, IEnumerable<string>> headers, TResult result, Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }
}