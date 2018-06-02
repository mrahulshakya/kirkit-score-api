

using System.Net;

namespace Kirkit.Score.Common.Exception
{
    public class ScoreException : System.Exception
    {
        public HttpStatusCode StatusCode { get; }
        public object Response { get; }
        public ScoreException(HttpStatusCode code, object response)
        {
            StatusCode = code;
            Response = response;
        }
    }
}