using System;
using System.Net;

namespace IMDB.Domain.Services
{
    public class ApiException : Exception
    {
        public ApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
