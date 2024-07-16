using System;

namespace SeraphSecure.FlaUI.Core.Exceptions
{
    public class ProxyAssemblyNotLoadedException : FlaUIException
    {
        public ProxyAssemblyNotLoadedException()
        {
        }

        public ProxyAssemblyNotLoadedException(string message)
            : base(message)
        {
        }

        public ProxyAssemblyNotLoadedException(Exception innerException)
            : base(String.Empty, innerException)
        {
        }

        public ProxyAssemblyNotLoadedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
