using System;

namespace FlaUI.Core.Exceptions
{
    public class NoClickablePointException : FlaUIException
    {
        public NoClickablePointException()
        {
        }

        public NoClickablePointException(string message)
            : base(message)
        {
        }

        public NoClickablePointException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public NoClickablePointException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
