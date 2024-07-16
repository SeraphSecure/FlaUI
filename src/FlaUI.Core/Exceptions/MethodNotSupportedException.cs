using System;

namespace SeraphSecure.FlaUI.Core.Exceptions
{
    public class MethodNotSupportedException : FlaUIException
    {
        public MethodNotSupportedException()
        {
        }

        public MethodNotSupportedException(string message)
            : base(message)
        {
        }

        public MethodNotSupportedException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public MethodNotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
