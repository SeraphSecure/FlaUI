using System;
using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core.Exceptions
{
    public class PropertyNotCachedException : NotCachedException
    {
        private const string DefaultMessage = "The requested property is not cached";
        private const string DefaultMessageWithData = "The requested property '{0}' is not cached";

        public PropertyNotCachedException() : base(DefaultMessage)
        {
        }

        public PropertyNotCachedException(PropertyId property)
            : base(String.Format(DefaultMessageWithData, property))
        {
            Property = property;
        }

        public PropertyNotCachedException(string message, PropertyId property)
            : base(message)
        {
            Property = property;
        }

        public PropertyNotCachedException(PropertyId property, Exception innerException)
            : base(String.Format(DefaultMessageWithData, property), innerException)
        {
            Property = property;
        }

        public PropertyNotCachedException(string message, PropertyId property, Exception innerException)
            : base(message, innerException)
        {
            Property = property;
        }

        public PropertyId Property { get; }
    }
}
