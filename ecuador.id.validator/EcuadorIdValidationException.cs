using System;

namespace ecuador.id.validator
{
    public class EcuadorIdValidationException : Exception
    {
        public EcuadorIdValidationException() : base("Document is not valid")
        {
        }

        public EcuadorIdValidationException(string message) : base(message)
        {
        }
    }
}