using System;

namespace SeraphSecure.FlaUI.Core.Exceptions
{
    public class ElementNotEnabledException : FlaUIException
    {
        public ElementNotEnabledException()
        {
        }

        public ElementNotEnabledException(string message)
            : base(message)
        {
        }

        public ElementNotEnabledException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public ElementNotEnabledException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
