using System;
using System.Runtime.Serialization;

namespace MathSite.Api.Core
{
    [Serializable]
    public class ApiExecutionException : ApplicationException
    {
        public ApiExecutionException()
        {
        }

        protected ApiExecutionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ApiExecutionException(string message) : base(message)
        {
        }

        public ApiExecutionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}