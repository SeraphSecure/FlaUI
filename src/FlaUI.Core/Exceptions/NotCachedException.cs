using System;

namespace FlaUI.Core.Exceptions
{
    public class NotCachedException : FlaUIException
    {
        public NotCachedException()
        {
        }

        public NotCachedException(string message)
            : base(message)
        {
        }

        public NotCachedException(Exception innerException) :
            base(String.Empty, innerException)
        {
        }

        public NotCachedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
