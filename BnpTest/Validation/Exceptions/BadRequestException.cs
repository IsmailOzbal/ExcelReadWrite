using System;

namespace BnpTest.Validation.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string code, string message) :
            base(message)
        {
            Code = code;
        }

        public BadRequestException(string code, string message, Exception inner) :
            base(message, inner)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
