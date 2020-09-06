using System;

namespace Darla.ESI
{
    public class RateLimitedException : Exception
    {
        public string Reason { get; }

        internal RateLimitedException()
        {
            Reason = "ESI returned a rate limit response.";
        }

        internal RateLimitedException(string reason)
        {
            Reason = reason;
        }
    }

    public class ESIServerErrorException : Exception
    {
        public string Error { get; }

        internal ESIServerErrorException()
        {
            Error = "ESI encountered an error.";
        }

        internal ESIServerErrorException(string error)
        {
            Error = error;
        }
    }
}
