using System;

namespace FlaUI.Core.Exceptions
{
    public class NotSupportedException : FlaUIException
    {
        public NotSupportedException()
        {
        }

        public NotSupportedException(string message)
            : base(message)
        {
        }

        public NotSupportedException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public NotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
