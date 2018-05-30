using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kirkit.Score.Model.Payload
{
    public class ScoreException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ScoreException(HttpStatusCode code, string message) : base(message)
        {
            StatusCode = code;
        }
    }
}
