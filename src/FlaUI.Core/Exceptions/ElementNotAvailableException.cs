using System;

namespace FlaUI.Core.Exceptions
{
    public class ElementNotAvailableException : FlaUIException
    {
        public ElementNotAvailableException()
        {
        }

        public ElementNotAvailableException(string message)
            : base(message)
        {
        }

        public ElementNotAvailableException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public ElementNotAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
