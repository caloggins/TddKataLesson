using System;
using System.Runtime.Serialization;

namespace StringCalcKata
{
    [Serializable]
    public class NegativesNotAllowedException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public NegativesNotAllowedException()
        {
        }

        public NegativesNotAllowedException(string message) : base(message)
        {
        }

        public NegativesNotAllowedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NegativesNotAllowedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}