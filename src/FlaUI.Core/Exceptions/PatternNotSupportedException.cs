using System;
using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core.Exceptions
{
    public class PatternNotSupportedException : NotSupportedException
    {
        private const string DefaultMessage = "The requested pattern is not supported";
        private const string DefaultMessageWithData = "The requested pattern '{0}' is not supported";

        public PatternNotSupportedException() : base(DefaultMessage)
        {
        }

        public PatternNotSupportedException(PatternId pattern)
            : base(String.Format(DefaultMessageWithData, pattern))
        {
            Pattern = pattern;
        }

        public PatternNotSupportedException(string message, PatternId pattern)
            : base(message)
        {
            Pattern = pattern;
        }

        public PatternNotSupportedException(PatternId pattern, Exception innerException)
            : base(String.Format(DefaultMessageWithData, pattern), innerException)
        {
            Pattern = pattern;
        }

        public PatternNotSupportedException(string message, PatternId pattern, Exception innerException)
            : base(message, innerException)
        {
            Pattern = pattern;
        }

        public PatternId Pattern { get; }
    }
}
