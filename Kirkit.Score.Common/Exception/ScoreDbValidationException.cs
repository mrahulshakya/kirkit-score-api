using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kirkit.Score.Common.Exception
{
    public class ScoreDbValidationException : System.Exception
    {
        public Dictionary<string, IList<string>> Errors;
        public ScoreDbValidationException(HttpStatusCode code, string message) : base(message)
        {
        }
    }
}
