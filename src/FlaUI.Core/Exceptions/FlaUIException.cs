using System;

namespace FlaUI.Core.Exceptions
{
    public class FlaUIException : Exception
    {
        public FlaUIException()
        {
        }

        public FlaUIException(string message)
            : base(message)
        {
        }

        public FlaUIException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public FlaUIException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
