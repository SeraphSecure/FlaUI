using System;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Exceptions
{
    public class PropertyNotSupportedException : NotSupportedException
    {
        private const string DefaultMessage = "The requested property is not supported";
        private const string DefaultMessageWithData = "The requested property '{0}' is not supported";

        public PropertyNotSupportedException() : base(DefaultMessage)
        {
        }

        public PropertyNotSupportedException(PropertyId property)
            : base(String.Format(DefaultMessageWithData, property))
        {
            Property = property;
        }

        public PropertyNotSupportedException(string message, PropertyId property)
            : base(message)
        {
            Property = property;
        }

        public PropertyNotSupportedException(PropertyId property, Exception innerException)
            : base(String.Format(DefaultMessageWithData, property), innerException)
        {
            Property = property;
        }

        public PropertyNotSupportedException(string message, PropertyId property, Exception innerException)
            : base(message, innerException)
        {
            Property = property;
        }

        public PropertyId Property { get; }
    }
}
